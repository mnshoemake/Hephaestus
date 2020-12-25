using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Configuration;
using Microsoft.IdentityModel.Protocols;

namespace Hephaestus.Data
{
    public class HephaestusContext : DbContext
    {
        public DbSet<Models.Hero> Heroes { get; set; }
        public DbSet<Models.User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConfigurationManager.ConnectionStrings["mainConnectionString"].ConnectionString);
        }
    }
}
