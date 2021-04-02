using Homework06.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework06.Models
{
    class CarModel : IEntity
    {
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public Guid BrandId { get; set; }
        public virtual Brand Brand { get; set; }

        public virtual ICollection<PossibleFeature> PossibleFeatures { get; set; }

        public CarModel()
        {
            PossibleFeatures = new HashSet<PossibleFeature>();
        }
    }
}
