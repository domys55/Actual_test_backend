using DataModels.DTOs;
using DataModels.Models;
using Model_lib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceCollection.service
{
    public interface IPhoneService
    {
        APIResponse<PhoneDTO> Add(PhoneDTO contact);
        APIResponse<PhoneDTO> GetById(int id);
        APIResponse<PhoneDTO> GetByNumber(string number);
    }
}
