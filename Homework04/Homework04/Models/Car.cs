using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Homework04.Models
{
    public enum Fuel
    {
        GASOLINE,
        DIESEL,
        HYBRID,
        ELECTRIC
    }

    public enum Gearbox
    {
        MANUAL,
        AUTOMATIC,
        ELECTRIC
    }

    public enum Transmission
    {
        FRONT_WHEEL_DRIVE,
        REAR_WHEEL_DRIVE,
        ALL_WHEEL_DRIVE
    }

    public class Car
    {
        public int Id { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public DateTime ManufactureDate { get; set; }
        public int EngineSizeCC { get; set; }
        public Fuel Fuel { get; set; }
        public Transmission Transmission { get; set; }
        public Gearbox Gearbox { get; set; }
        public int HorsePower { get; set; }
        public int PriceEuro { get; set; }
    }
}
