using RobsDerbyCars.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace RobsDerbyCars.DAL
{
    public class DerbyContext : DbContext
    {
        public DerbyContext()
            : base("DerbyContext") //"DerbyContext" is the Name of the connection string
        {
        }

        public DbSet<Car> Cars { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Heat> Heats { get; set; }
        public DbSet<Racer> Racers { get; set; }
        //public DbSet<Division> Divisions { get; set; }



        public System.Data.Entity.DbSet<RobsDerbyCars.Models.Division> Divisions { get; set; }

        public System.Data.Entity.DbSet<RobsDerbyCars.Models.Race> Races { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();  // used to prevent table names from being pluralized in the DB
        }


    }
}