using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace NotesAPP.BackendService
{
    public class NotesDbContext:DbContext
    {
        public NotesDbContext() : base("DefaultConnection")
        {
        }

        public DbSet<Notes> Notes { get; set; }
    }
}