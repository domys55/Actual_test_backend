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
            var data = _context.Contacts.Where(a => a.Id == id).FirstOrDefault();
            if (data != null)
            {
                _context.Contacts.Remove(data);
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public IEnumerable<ContactModel> GetAll()
        {
            var data = _context.Contacts;
            return data;
        }

        public ContactModel GetById(int id)
        {
            var data = _context.Contacts.Where(a=>a.Id==id).FirstOrDefault();
            return data;
        }

        public bool Update(ContactModel contact)
        {
            if(contact != null)
            {
                _context.Update(contact);
                _context.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
