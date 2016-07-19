using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zensar.Domain.Entities;

namespace Zensar.API.DTO
{
    public class PersonDTO
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public string Phone { get; set; }
        public Boolean Active { get; set; }
    }
}
