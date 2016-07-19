using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zensar.Domain.Entities;

namespace Zensar.Service
{
    public interface IPricingSevice
    {
        Task<Person> InsertPerson(Person person);
        Task<List<Person>> GetPersonsAsync();
         void UpdatePerson(Person person);
    }
}
