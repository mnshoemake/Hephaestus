﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Configuration;
using Microsoft.Extensions.Configuration;

namespace Hephaestus.Data
{
    public class HephaestusContext : DbContext
    {
        public IConfiguration Config { get; set; }
        public DbSet<Models.Hero> Heroes { get; set; }
        public DbSet<Models.User> Users { get; set; }
        

        public HephaestusContext(DbContextOptions<HephaestusContext> dbContextOptions)
        :base(dbContextOptions)
        
        {
        }
    }
}