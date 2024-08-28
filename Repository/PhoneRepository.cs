using DataModels.Models;
using InterfaceCollection.repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class PhoneRepository : IPhoneRepository
    {
        private readonly ApplicationDbContext _context;

        public PhoneRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public PhoneModel Add(PhoneModel phone)
        {
            _context.Add(phone);
            _context.SaveChanges();
            return phone;
        }

        public PhoneModel GetById(int id)
        {
            var data = _context.PhoneNums.Where(a => a.Id == id).FirstOrDefault();
            return data;
        }

        public PhoneModel GetByNumber(string number)
        {
            var data = _context.PhoneNums.Where(a => a.Number == number).FirstOrDefault();
            return data;
        }

        public bool CheckByNumber(string number)
        {
            bool exists = _context.PhoneNums.Where(a => a.Number == number).Any();
            return exists;
        }

        public IEnumerable<PhoneModel> GetByContactId(int id)
        {
            var data = _context.PhoneNums.Where(x => x.ContactId == id);
            return data;
        }

        public bool Delete(int id)
        {
            var data = _context.PhoneNums.Where(a => a.Id == id).FirstOrDefault();
            if (data != null)
            {
                _context.PhoneNums.Remove(data);
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public bool DeleteByContactID(int contactId)
        {
            var data = _context.PhoneNums.Where(a => a.ContactId == contactId);
            if (data != null)
            {
                _context.PhoneNums.RemoveRange(data);
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public PhoneModel Update(PhoneModel phone)
        {
            _context.Update(phone);
            _context.SaveChanges();
            return phone;
        }

        public bool CheckByNumberAndId(string number, int id)
        {
            bool exists = _context.PhoneNums.Where(a => a.Number == number && a.Id!=id).Any();
            return exists;
        }
    }
}
