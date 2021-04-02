using Homework06.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework06.Models
{
    class CustomerInterest : IEntity
    {
        public Guid Id { get; set; }
        [Required]
        public Guid CustomerId { get; set; }
        public virtual Customer Customer { get; set; }
        [Required]
        public Guid CarModelId { get; set; }
        public virtual CarModel CarModel { get; set; }
        [Required]
        public DateTime Date { get; set; }
    }
}
