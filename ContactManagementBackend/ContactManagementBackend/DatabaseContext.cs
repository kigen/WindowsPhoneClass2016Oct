using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ContactManagementBackend
{
    public class DatabaseContext:DbContext
    {
        public DatabaseContext() : base("DefaultConnection")
        {  

        }

        public DbSet<Contact> Contacts { get; set; }

    }
}