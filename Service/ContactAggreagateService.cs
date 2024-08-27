using DataModels.DTOs;
using InterfaceCollection.repository;
using InterfaceCollection.service;
using Model_lib;
using Service.util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class ContactAggreagateService :IContactAggreagateService
    {
        private readonly IContactRepository _ContactRepository;
        private readonly IAddressRepository _AddressRepository;
        private readonly IPhoneRepository _PhoneRepository;
        public ContactAggreagateService(IContactRepository contactRepo, IAddressRepository addressRepo, IPhoneRepository phoneRepo)
        {
            _ContactRepository= contactRepo;
            _AddressRepository= addressRepo;
            _PhoneRepository= phoneRepo;
        }

        public APIResponse<ContactAggregateDTO> Add(ContactAggregateDTO model)
        {
            if (model != null)
            {
                foreach(var a in model.PhoneNumbers)
                {
                    if (_PhoneRepository.CheckByNumber(a.Number))
                    {
                        return APIResponse<ContactAggregateDTO>.PhoneExists();
                    }
                }
                ContactDTO temp = new ContactDTO
                {
                    FirstName=model.FirstName,
                    LastName=model.LastName,
                };
                var savedcontact=_ContactRepository.Add(temp.ToModel());
                //model.Id = savedcontact.Id;
                foreach (var a in model.PhoneNumbers)
                {
                    a.ContactId = savedcontact.Id;
                    _PhoneRepository.Add(a.ToModel());
                }
                foreach (var a in model.Addresses)//check if exists
                {
                    a.ContactId=savedcontact.Id;
                    _AddressRepository.Add(a.ToModel());
                }
                return APIResponse<ContactAggregateDTO>.Ok(model);
            }
            return APIResponse<ContactAggregateDTO>.ServerError();
        }

        public APIResponse<ContactAggregateDTO> Delete(int id)
        {
            if (id != 0)
            {
                _PhoneRepository.DeleteByContactID(id);
                _AddressRepository.DeleteByContactID(id);
                _ContactRepository.Delete(id);
               
                return APIResponse<ContactAggregateDTO>.OkNoData();
            }
            return APIResponse<ContactAggregateDTO>.ServerError();
        }

        public APIResponse<ContactAggregateDTO> Edit(ContactAggregateDTO model)
        {
            
            if (model != null)
            {
                foreach (var a in model.PhoneNumbers)
                {
                    if (_PhoneRepository.CheckByNumberAndId(a.Number,a.Id))
                    {
                        return APIResponse<ContactAggregateDTO>.PhoneExists();
                    }
                }
                ContactDTO temp = new ContactDTO
                {
                    Id=model.Id,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                };
                var savedcontact = _ContactRepository.Update(temp.ToModel());
                //model.Id = savedcontact.Id;
                foreach (var a in model.PhoneNumbers)
                {
                    //a.ContactId = savedcontact.Id;
                    if (a.Id==0)
                    {
                        a.ContactId = model.Id;
                        _PhoneRepository.Add(a.ToModel());
                    }
                    else
                    {
                        _PhoneRepository.Update(a.ToModel());
                    }
                    
                }
                foreach (var a in model.Addresses)//check if exists
                {
                    if (a.Id==0)
                    {
                        a.ContactId=model.Id;
                        _AddressRepository.Add(a.ToModel());
                    }
                    else
                    {
                        _AddressRepository.Update(a.ToModel());
                    }
                    
                }
                return APIResponse<ContactAggregateDTO>.Ok(model);
            }
            return APIResponse<ContactAggregateDTO>.ServerError();
        }

        public APIResponse<ContactAggregateDTO> GetById(int id)
        {
            try
            {
                ContactDTO contact = _ContactRepository.GetById(id).ToDTO();
                if (contact==null)
                {
                    return APIResponse<ContactAggregateDTO>.NotFound();
                }
                ContactAggregateDTO dto = new ContactAggregateDTO
                {
                    Id = contact.Id,
                    FirstName = contact.FirstName,
                    LastName = contact.LastName,
                    Addresses = _AddressRepository.GetByContactId(contact.Id).listToDTO(),
                    PhoneNumbers = _PhoneRepository.GetByContactId(contact.Id).listToDTO()
                };
                return APIResponse<ContactAggregateDTO>.Ok(dto);
            }
            catch (Exception ex)
            {
                return APIResponse<ContactAggregateDTO>.ServerError();
            }

            
        }
    }
}
