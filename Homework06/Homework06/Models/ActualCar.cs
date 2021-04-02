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
    class ActualCar : IEntity
    {
        public Guid Id { get; set; }

        [Required]
        public DateTime ManufactureDate { get; set; }
        [Required]
        public Guid CarModelId { get; set; }
        public virtual CarModel CarModel { get; set; }
        [Required]
        public Guid FeatureId { get; set; }
        public virtual PossibleFeature Feature { get; set; }

    }
}
