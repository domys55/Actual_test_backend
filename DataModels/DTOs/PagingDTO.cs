using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModels.DTOs
{
    public class PagingDTO
    {
        public string? search { get; set; }
        public int Page { get; set; }
        public int RecordNo { get; set; }
    }
}
