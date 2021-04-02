using Homework06.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework06.Database
{
    class CarDealershipContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=CarDealership2;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }


        public DbSet<Brand> Brands { get; set; }
        public DbSet<CarModel> CarModels { get; set; }
        public DbSet<PossibleFeature> PossibleFeatures { get; set; }
        public DbSet<ActualCar> ActualCars { get; set; }
        public DbSet<Inventory> Inventory { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<CustomerPurchase> CustomerPurchases { get; set; }
        public DbSet<CustomerInterest> CustomerInterests { get; set; }
    }
}
