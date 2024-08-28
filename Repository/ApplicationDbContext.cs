using DataModels.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
        {
        }

        public DbSet<ContactModel> Contacts { get; set; }
        public DbSet<PhoneModel> PhoneNums { get; set; }
        public DbSet<AddressModel> Addresses { get; set; }
    }
}
