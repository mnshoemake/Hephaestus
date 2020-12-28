using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Configuration;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Protocols;

namespace Hephaestus.Data
{
    public class HephaestusContext : DbContext
    {
        public IConfiguration Config { get; set; }
        public DbSet<Models.Hero> Heroes { get; set; }
        public DbSet<Models.User> Users { get; set; }
        

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    //var connectionString = Config.GetSection("ConnectionStrings")["mainConnectionString"];
        //    //optionsBuilder.UseSqlServer(connectionString);
        //    //optionsBuilder.UseSqlServer("Server=tcp:mnsserver.database.windows.net,1433;Initial Catalog=Hephaestus;Persist Security Info=False;User ID=sqluser;Password=Passw0rd!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
        //}

        public HephaestusContext(DbContextOptions<HephaestusContext> dbContextOptions)
        :base(dbContextOptions)
        
        {
        }
    }
}