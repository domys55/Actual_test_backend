using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModels.Models
{
    public class AddressModel
    {
        public int Id { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public bool Primary { get; set; }

        //fk
        public int ContactId { get; set; }
        public ContactModel Contact { get; set; }
    }
}
