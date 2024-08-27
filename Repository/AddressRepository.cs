using DataModels.Models;
using InterfaceCollection.repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class AddressRepository : IAddressRepository
    {
        private readonly ApplicationDbContext _context;

        public AddressRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public AddressModel Add(AddressModel address)
        {
            _context.Add(address);
            _context.SaveChanges();
            return address;
        }

        public bool Delete(int id)
        {
            var data = _context.Addresses.Where(a => a.Id == id).FirstOrDefault();
            if (data != null)
            {
                _context.Addresses.Remove(data);
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public bool DeleteByContactID(int contactId)
        {
            var data = _context.Addresses.Where(a => a.ContactId == contactId);
            if (data != null)
            {
                _context.Addresses.RemoveRange(data);
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public IEnumerable<AddressModel> GetByContactId(int id)
        {
            var data=_context.Addresses.Where(x => x.ContactId == id);
            return data;
        }

        public AddressModel Update(AddressModel address)
        {
            _context.Update(address);
            _context.SaveChanges();
            return address;
        }
    }
}
