using DataModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceCollection.repository
{
    public interface IPhoneRepository
    {
        PhoneModel Add(PhoneModel contact);
        PhoneModel Update(PhoneModel contact);
        PhoneModel GetById(int id);
        PhoneModel GetByNumber(string number);
        bool CheckByNumber(string number);
        bool CheckByNumberAndId(string number,int id);
        IEnumerable<PhoneModel> GetByContactId(int id);
        bool Delete(int id);
        bool DeleteByContactID(int contactId);
    }
}
