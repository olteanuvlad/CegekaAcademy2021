using Homework06.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework06.Models
{
    class CustomerPurchase : IEntity
    {
        public Guid Id { get; set; }

        [Required]
        public Guid CustomerId { get; set; }
        public virtual Customer Customer { get; set; }
        [Required]
        public Guid ActualCarId { get; set; }
        public virtual ActualCar ActualCar { get; set; }
        [Required]
        public DateTime Date { get; set; }
    }
}
