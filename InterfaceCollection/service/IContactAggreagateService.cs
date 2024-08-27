using DataModels.DTOs;
using Model_lib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceCollection.service
{
    public interface IContactAggreagateService
    {
        APIResponse<ContactAggregateDTO> Add(ContactAggregateDTO model);
        APIResponse<ContactAggregateDTO> GetById(int id);
        APIResponse<ContactAggregateDTO> Delete(int id);
        APIResponse<ContactAggregateDTO> Edit(ContactAggregateDTO model);
    }
}
