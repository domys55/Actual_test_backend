using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModels.Models
{
    public class ContactModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        //fks
        public ICollection<PhoneModel> PhoneNumbers { get; }
        public ICollection<AddressModel> Addresses { get; }
    }
}
