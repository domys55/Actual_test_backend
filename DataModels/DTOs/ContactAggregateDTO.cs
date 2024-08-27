using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModels.DTOs
{
    public class ContactAggregateDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public ICollection<PhoneDTO> PhoneNumbers { get; set; }
        public ICollection<AddressDTO>? Addresses { get; set; }
    }
}
