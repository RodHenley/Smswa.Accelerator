using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using smswa.accelerator.sample.model;

namespace smswa.accelerator.data
{
    public class AcceleratorContext:DbContext
    {
        public AcceleratorContext() : base("accelerator")
        {
            Database.SetInitializer<AcceleratorContext>(null);
        }

        public AcceleratorContext(string connectionString) : base(connectionString)
        {
            Database.SetInitializer<AcceleratorContext>(null);
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            base.Configuration.LazyLoadingEnabled = false;
            base.Configuration.ProxyCreationEnabled = false;

            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

        public DbSet<Person> Persons { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Contact> Contacts { get; set; }
    }
}
