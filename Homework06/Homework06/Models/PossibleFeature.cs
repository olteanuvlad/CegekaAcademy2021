using Homework06.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework06.Models
{
    class PossibleFeature : IEntity
    {
        public Guid Id { get; set; }

        public string PackageName { get; set; }
        public int EngineSizeCC { get; set; }
        public string Fuel { get; set; }
        public string Transmission { get; set; }
        public string Gearbox { get; set; }
        public int Horsepower { get; set; }
        public int PriceEuro { get; set; }

        [Required]
        public Guid CarModelId { get; set; }
        public virtual CarModel CarModel { get; set; }
    }
}
