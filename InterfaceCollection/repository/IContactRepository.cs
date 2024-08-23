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

        // Read - Get all contacts
        IEnumerable<ContactModel> GetAll();

        // Update
        bool Update(ContactModel contact);

        // Delete
        bool Delete(int id);
    }
}
