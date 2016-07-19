using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zensar.Domain.Entities;

namespace Zensar.API.DTO
{
    public class ProductDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<Person> Persons { get; set; }

    }
}
