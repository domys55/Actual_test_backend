using DataModels.DTOs;
using DataModels.Models;
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
    public class PhoneService : IPhoneService
    {
        private readonly IPhoneRepository _repository;
        public PhoneService(IPhoneRepository repo)
        {
            _repository = repo;
        }

        public APIResponse<PhoneDTO> Add(PhoneDTO model)
        {
            try
            {
                if (model != null)
                {
                    _repository.Add(model.ToModel());
                    return APIResponse<PhoneDTO>.Ok(model);
                }
                else
                {
                    return APIResponse<PhoneDTO>.NotFound();
                }
            }
            catch (Exception ex)
            {
                return APIResponse<PhoneDTO>.ServerError();
            }
        }

        public APIResponse<PhoneDTO> GetById(int id)
        {
            PhoneDTO tempModel = _repository.GetById(id).ToDTO();
            return APIResponse<PhoneDTO>.Ok(tempModel);
        }

        public APIResponse<PhoneDTO> GetByNumber(string number)
        {
            PhoneDTO tempModel = _repository.GetByNumber(number).ToDTO();
            return APIResponse<PhoneDTO>.Ok(tempModel);
        }
    }
}
