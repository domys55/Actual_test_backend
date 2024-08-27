using DataModels.DTOs;
using DataModels.Models;
using InterfaceCollection.repository;
using InterfaceCollection.service;
using Model_lib;
using Service.util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
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
                    ContactModel tempmodel = model.ToModel();
                    var saved=_repository.Add(tempmodel);
                    return APIResponse<ContactDTO>.Ok(saved.ToDTO());
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

        public APIResponse<ContactDTO> Delete(int id)
        {
            bool response=false;
            if(id != 0)
            {
                response = _repository.Delete(id);
            }

            if (response==false)
            {
                return APIResponse<ContactDTO>.NotFound();
            }
            return APIResponse<ContactDTO>.OkNoData();
        }

        public APIResponse<ContactDTO> Edit(ContactDTO model)
        {
            bool response = false;
            if (model != null)
            {
                response = _repository.Update(model.ToModel());
            }

            if (response == false)
            {
                return APIResponse<ContactDTO>.NotFound();
            }
            return APIResponse<ContactDTO>.Ok(model);
        }

        public APIResponse<IEnumerable<ContactDTO>> GetAll()
        {
            List<ContactDTO> list = new List<ContactDTO>();
            foreach (var a in _repository.GetAll())
            {
                ContactDTO tempModel = a.ToDTO();
                list.Add(tempModel);
            }

            return APIResponse<IEnumerable<ContactDTO>>.Ok(list);
        }

        public APIResponse<IEnumerable<ContactDTO>> GetAllPaged(PagingDTO dto)//paged
        {
            
            List<ContactDTO> list = new List<ContactDTO>();
            foreach (var a in _repository.GetAllPaged(dto.Page,dto.RecordNo))
            {
                ContactDTO tempModel = a.ToDTO();
                list.Add(tempModel);
            }
            int cnt = _repository.GetRecordCount();
            return APIResponse<IEnumerable<ContactDTO>>.OkRecordCount(list,cnt);
        }

        public APIResponse<ContactDTO> GetById(int id)
        {
            ContactDTO tempModel = _repository.GetById(id).ToDTO();
            return APIResponse<ContactDTO>.Ok(tempModel);
        }
    }
}
