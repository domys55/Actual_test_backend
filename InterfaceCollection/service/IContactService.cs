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
        APIResponse<IEnumerable<ContactDTO>> GetAllPaged(PagingDTO dto);
        APIResponse<ContactDTO> Add(ContactDTO model);
        APIResponse<ContactDTO> Edit(ContactDTO model);
        APIResponse<ContactDTO> Delete(int id);
    }
}
