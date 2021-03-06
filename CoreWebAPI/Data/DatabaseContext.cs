using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreWebAPI.Data
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions options):base(options)
        {

        }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Hospital> Hospitals { get; set; } 
    }
}
