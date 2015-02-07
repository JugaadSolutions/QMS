using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace QMS.Models
{
    public class QMS_db : DbContext
    {
        public QMS_db()
            : base("name=DefaultConnection")
        {

        }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<IP> IPs { get; set; }
        public DbSet<Config> Configs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Patient>()
                .MapToStoredProcedures(s => s.Insert(i => i.HasName("RegisterPatient")));

          

        }

       
        
    }
}