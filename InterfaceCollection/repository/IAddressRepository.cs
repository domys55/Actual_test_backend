using DataModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceCollection.repository
{
    public interface IAddressRepository
    {
        AddressModel Add(AddressModel contact);
        AddressModel Update(AddressModel contact);
        IEnumerable<AddressModel> GetByContactId(int id);
        bool Delete(int id);
        bool DeleteByContactID(int contactId);
    }
}
