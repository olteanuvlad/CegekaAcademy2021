using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Homework04.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public List<Car> BoughtCars { get; set; }

        public Customer()
        {
            BoughtCars = new List<Car>();
        }
    }
}
