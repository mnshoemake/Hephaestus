using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Design;

namespace Hephaestus.Data
{
    public class HephaestusContextFactory : IDesignTimeDbContextFactory<HephaestusContext>
    {
        public HephaestusContextFactory()
        {
            // A parameter-less constructor is required by the EF Core CLI tools.
        }

        public HephaestusContext CreateDbContext(string[] args)
        {
            var connectionString = Environment.GetEnvironmentVariable("HephaestusDB");
            if (string.IsNullOrEmpty(connectionString))
            {

                throw new InvalidOperationException("The connection string was not set " +
                                                    "in the 'HephaestusDB' environment variable.");
            }

            var options = new DbContextOptionsBuilder<HephaestusContext>()
                .UseSqlServer(connectionString)
                .Options;
            return new HephaestusContext(options);
        }

}
}
