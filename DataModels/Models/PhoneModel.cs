﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModels.Models
{
    public class PhoneModel
    {
        public int Id { get; set; }
        public string Number { get; set; }

        //fk
        public int ContactId { get; set; }
        public ContactModel Contact { get; set; }
    }
}
