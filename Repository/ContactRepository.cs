using DataModels.Models;
using InterfaceCollection.repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class ContactRepository : IContactRepository
    {
        private readonly ApplicationDbContext _context;

        public ContactRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public ContactModel Add(ContactModel contact)
        {
            _context.Add(contact);
            _context.SaveChanges();
            return contact;
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ContactModel> GetAll()
        {
            throw new NotImplementedException();
        }

        public ContactModel GetById(int id)
        {
            throw new NotImplementedException();
        }

        public bool Update(ContactModel contact)
        {
            throw new NotImplementedException();
        }
    }
}
