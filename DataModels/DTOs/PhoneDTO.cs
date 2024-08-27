using DataModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModels.DTOs
{
    public class PhoneDTO
    {
        public int Id { get; set; }
        public string Number { get; set; }
        public bool Primary { get; set; }

        //fk
        public int ContactId { get; set; }
    }
}
