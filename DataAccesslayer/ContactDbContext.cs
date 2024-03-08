using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactDetail.DataAccesslayer
{
    public class ContactDbContext:DbContext
    {
        public ContactDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<ContactForm> Contacts{ get; set; }
    }
}

