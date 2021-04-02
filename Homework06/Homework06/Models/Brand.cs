using Homework06.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework06.Models
{
    class Brand : IEntity
    {
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }

        public virtual ICollection<CarModel> CarModels { get; set; }

        public Brand()
        {
            CarModels = new HashSet<CarModel>();
        }
    }
}
