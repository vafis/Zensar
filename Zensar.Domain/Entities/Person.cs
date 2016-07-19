using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zensar.Domain.Entities
{
    public class Person
    {
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        [Required]
        public string Surname { get; set; }
        [Required]
        public string Phone { get; set; }
        [Required]
        public Boolean Active { get; set; }
        public virtual List<Transactions> Transactions { get; set; }  

    }
}
