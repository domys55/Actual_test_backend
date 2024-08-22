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
    public interface IContactService
    {
        APIResponse<ContactDTO> GetById(int id);
        APIResponse<IEnumerable<ContactDTO>> GetAll();
        APIResponse<ContactDTO> Add(ContactDTO model);
        APIResponse<ContactDTO> Edit(ContactModel model);
        APIResponse<ContactDTO> Delete(ContactModel model);
    }
}
