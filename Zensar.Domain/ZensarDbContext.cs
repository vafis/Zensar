using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zensar.Domain.Entities;

namespace Zensar.Domain
{
    public class ZensarDbContext : DbContext
    {
        public ZensarDbContext() : base("name=ZensarDbContext")
        {

          //  this.Configuration.LazyLoadingEnabled = false;
         // this.Configuration.ProxyCreationEnabled = false;
        }

        public DbSet<Person> Persons { get; set; }
        public DbSet<Transactions> Transactions { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Transactions>()
                .HasRequired<Person>(t=>t.Person).WithMany(c=>c.Transactions).HasForeignKey(p=>p.PersonId).WillCascadeOnDelete(false);


            base.OnModelCreating(modelBuilder);
        }
    }

}
