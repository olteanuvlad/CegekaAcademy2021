using Homework06.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework06.Models
{
    class Customer : IEntity
    {
        public Guid Id { get; set; }

        [Required]
        public string Firstname { get; set; }
        [Required]
        public string Lastname { get; set; }

        public virtual ICollection<CustomerPurchase> CustomerPurchases { get; set; }
        public virtual ICollection<CustomerInterest> CustomerInterests { get; set; }

        public Customer()
        {
            CustomerPurchases = new HashSet<CustomerPurchase>();
            CustomerInterests = new HashSet<CustomerInterest>();
        }
    }
}
