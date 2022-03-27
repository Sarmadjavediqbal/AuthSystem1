using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AuthSystem.Models;

namespace AuthSystem.Data
{
    public class AuthSystemDbContext : DbContext
    {
        public AuthSystemDbContext (DbContextOptions<AuthSystemDbContext> options)
            : base(options)
        {
        }

        public DbSet<AuthSystem.Models.Contact> Contact { get; set; }

        public DbSet<AuthSystem.Models.Parcel> Parcel { get; set; }


    }
}
