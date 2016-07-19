using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zensar.Domain;
using Zensar.Domain.Entities;

namespace Zensar.Service
{
    public class PricingService : IPricingSevice
    {
        private ZensarDbContext context = new ZensarDbContext();

        public Task<Person> InsertPerson(Person person)
        {
            return Task<Person>.Factory.StartNew(() =>
            {
                person.Id=Guid.NewGuid();
                context.Persons.Attach(person);
                context.Entry(person).State = EntityState.Added;
                context.Persons.Add(person);
                context.SaveChanges();
                return person;
            });
        }

        public Task<List<Person>> GetPersonsAsync()
        {
            return Task<List<Person>>.Factory.StartNew(() => context.Persons.ToList());
        }



        
        public void UpdatePerson(Person person)
        {
            context.Persons.Attach(person);
            context.Entry(person).State=EntityState.Modified;
            context.Persons.Add(person);
            context.SaveChanges();

        }

   
      
    }
}
