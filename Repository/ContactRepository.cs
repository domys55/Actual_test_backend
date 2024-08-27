using DataModels.Models;
using InterfaceCollection.repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Azure;

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

        public IEnumerable<ContactModel> GetAllPaged(int page,int pageCount)
        {
            var data=_context.Contacts.Skip((page-1)*pageCount).Take(pageCount);
            return data;
        }

        public IEnumerable<ContactModel> GetAllPagedTable(int page, int pageCount, string search)
        {
            if (!String.IsNullOrEmpty(search))
            {
               string searchTerm = search.ToLower();

                return _context.Contacts.Include(a => a.Addresses).Include(a => a.PhoneNumbers).Where(contact =>
                    contact.Id.ToString().Contains(searchTerm) ||
                    (!string.IsNullOrEmpty(contact.FirstName) && contact.FirstName.ToLower().Contains(searchTerm)) ||
                    (!string.IsNullOrEmpty(contact.LastName) && contact.LastName.ToLower().Contains(searchTerm)) ||
                    (!string.IsNullOrEmpty(contact.PhoneNumbers.Where(a=>a.Primary).First().Number) && contact.PhoneNumbers.Where(a => a.Primary).First().Number.ToLower().Contains(searchTerm)) ||
                    (!string.IsNullOrEmpty(contact.Addresses.Where(a => a.Primary).First().Street) && contact.Addresses.Where(a => a.Primary).First().Street.ToLower().Contains(searchTerm))
                ).Skip((page - 1) * pageCount).Take(pageCount).ToList();
            }
            var data = _context.Contacts.Include(a=>a.Addresses).Include(a=>a.PhoneNumbers).Skip((page - 1) * pageCount).Take(pageCount);
            return data;
        }

        public ContactModel GetById(int id)
        {
            var data = _context.Contacts.Where(a=>a.Id==id).FirstOrDefault();
            return data;
        }

        public int GetRecordCount()
        {
            int count=_context.Contacts.Count();
            return count;
        }

        public int GetRecordCountSearch(string searchTerm, int page, int pageCount)
        {
            return _context.Contacts.Include(a => a.Addresses).Include(a => a.PhoneNumbers).Where(contact =>
                     contact.Id.ToString().Contains(searchTerm) ||
                     (!string.IsNullOrEmpty(contact.FirstName) && contact.FirstName.ToLower().Contains(searchTerm)) ||
                     (!string.IsNullOrEmpty(contact.LastName) && contact.LastName.ToLower().Contains(searchTerm)) ||
                     (!string.IsNullOrEmpty(contact.PhoneNumbers.Where(a => a.Primary).First().Number) && contact.PhoneNumbers.Where(a => a.Primary).First().Number.ToLower().Contains(searchTerm)) ||
                     (!string.IsNullOrEmpty(contact.Addresses.Where(a => a.Primary).First().Street) && contact.Addresses.Where(a => a.Primary).First().Street.ToLower().Contains(searchTerm))
                 ).Skip((page - 1) * pageCount).Take(pageCount).Count();
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
