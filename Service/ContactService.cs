using DataModels.DTOs;
using DataModels.Models;
using InterfaceCollection.repository;
using InterfaceCollection.service;
using Model_lib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class ContactService : IContactService
    {
        private readonly IContactRepository _repository;
        public ContactService(IContactRepository repo)
        {
            _repository = repo;
        }

        public APIResponse<ContactDTO> Add(ContactDTO model)
        {
            try
            {
                if (model != null)
                {
                    ContactModel tempmodel = new ContactModel()
                    {
                        firstName=model.firstName,
                        LastName=model.LastName,
                    };
                    _repository.Add(tempmodel);
                    return APIResponse<ContactDTO>.Ok(model);
                }
                else
                {
                    return APIResponse<ContactDTO>.NotFound();
                }
            }
            catch (Exception ex)
            {
                return APIResponse<ContactDTO>.ServerError();
            }
        }

        public APIResponse<ContactDTO> Delete(ContactModel model)
        {
            throw new NotImplementedException();
        }

        public APIResponse<ContactDTO> Edit(ContactModel model)
        {
            throw new NotImplementedException();
        }

        public APIResponse<IEnumerable<ContactDTO>> GetAll()
        {
            throw new NotImplementedException();
        }

        public APIResponse<ContactDTO> GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
