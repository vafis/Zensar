using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zensar.Domain.Entities
{
    public class Transactions
    {
        public Guid Id { get; set; }
       // [Key, ForeignKey("Person")]
        public Guid PersonId { get; set; }
        public double Amount { get; set; }
        public virtual Person Person { get; set; } 
    }
}
