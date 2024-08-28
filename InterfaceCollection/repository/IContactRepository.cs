using DataModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceCollection.repository
{
    public interface IContactRepository
    {
        // Create
       ContactModel Add(ContactModel contact);

        // Read - Get a single contact by ID
        ContactModel GetById(int id);
        int GetRecordCount();
        int GetRecordCountSearch(string term ,int page, int pageCount);

        // Read - Get all contacts
        IEnumerable<ContactModel> GetAll();

        IEnumerable<ContactModel> GetAllPaged(int page,int pageCount);
        IEnumerable<ContactModel> GetAllPagedTable(int page, int pageCount, string search);
        // Update
        bool Update(ContactModel contact);

        // Delete
        bool Delete(int id);
    }
}
