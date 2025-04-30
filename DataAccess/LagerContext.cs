using DataAccess.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class LagerContext : DbContext
    {
        public LagerContext() { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(Environment.GetEnvironmentVariable("Power_DB_Connection_String"));
            optionsBuilder.LogTo(message => Debug.WriteLine(message));
        }

        public DbSet<Plads> Pladser { get; set; }
        public DbSet<Reol> Reoler { get; set; }
        public DbSet<Vare> Varer { get; set; }
    }
}
