using Homework04.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace Homework04.Controllers
{
    public class CarsController : Controller
    {
        private static readonly List<Customer> Customers = new();
        private static readonly List<Car> Cars = new()
        {
            new Car
            {
                Id = 1,
                Make = "Citroen",
                Model = "C4",
                ManufactureDate = Convert.ToDateTime("12/04/2006"),
                EngineSizeCC = 1600,
                Fuel = Fuel.DIESEL,
                Transmission = Transmission.FRONT_WHEEL_DRIVE,
                Gearbox = Gearbox.MANUAL,
                HorsePower = 90,
                PriceEuro = 1800
            },
            new Car
            {
                Id = 2,
                Make = "Dacia",
                Model = "Logan",
                ManufactureDate = Convert.ToDateTime("12/02/2010"),
                EngineSizeCC = 1400,
                Fuel = Fuel.GASOLINE,
                Transmission = Transmission.FRONT_WHEEL_DRIVE,
                Gearbox = Gearbox.MANUAL,
                HorsePower = 80,
                PriceEuro = 3500
            }
        };

        [HttpHead]
        [Route("cars/count", Name = "GetCarsCount")]
        public IActionResult CarsCount()
        {
            Response.Headers.Add( "content-length", Cars.Count.ToString() );
            return Ok();
        }

        [HttpGet]
        [Route("cars/all", Name = "GetAllCars")]
        public IActionResult Index()
        {
            if (Cars.Count == 0) return NoContent();

            List<LinksWrapper> carsList = new();

            foreach (Car car in Cars)
            {
                carsList.Add(new LinksWrapper
                {
                    Target = car,
                    Links = new List<LinkInfo> {
                    new LinkInfo {
                        Href = this.Url.Link("GetCarOptions", new { id = car.Id }),
                        Rel = "cars/options",
                        Method = "OPTIONS"
                    }
                }
                });
            }

            LinksWrapper wrappedCarsList = new LinksWrapper(carsList, GenerateCarsLinks());

            return Ok(wrappedCarsList);
        }

        [HttpOptions]
        [Route("cars/options/{id}", Name = "GetCarOptions")]
        public IActionResult GetCarOptions(int id)
        {
            Car car = Cars.Find(c => c.Id == id);
            if (car == null) return NotFound("No car with that Id exists.");

            LinksWrapper wrappedCar = new LinksWrapper(car, GenerateCarLinks(car));

            return Ok(new LinksWrapper(wrappedCar, GenerateCarsLinks()));
        }

        [HttpPost]
        [Route("cars/add", Name = "CreateCar")]
        public IActionResult AddCar(Car model)
        {
            if (Cars.Exists(c => c.Id == model.Id))
                return Conflict("There is already a car with that Id.");

            Cars.Add(model);

            LinksWrapper wrappedCar = new LinksWrapper(model, GenerateCarLinks(model));

            return Ok(new LinksWrapper(wrappedCar, GenerateCarsLinks()));
        }

        [HttpPut]
        [Route("cars/edit/{id}", Name = "EditCar")]
        public IActionResult UpdateCar(int id, Car model)
        {
            Car car = Cars.Find(c => c.Id == id);
            if (car == null) return NotFound("No car with that Id exists.");

            car.Make = model.Make;
            car.Model = model.Model;
            car.ManufactureDate = model.ManufactureDate;
            car.EngineSizeCC = model.EngineSizeCC;
            car.Fuel = model.Fuel;
            car.Transmission = model.Transmission;
            car.Gearbox = model.Gearbox;
            car.HorsePower = model.HorsePower;
            car.PriceEuro = model.PriceEuro;

            LinksWrapper wrappedCar = new LinksWrapper(car, GenerateCarLinks(car));

            return Ok(new LinksWrapper(wrappedCar, GenerateCarsLinks()));
        }

        [HttpPatch]
        [Route("cars/editprice/{id}", Name = "EditCarPrice")]
        public IActionResult UpdateCarPrice(int id, int newPriceEuro)
        {
            Car car = Cars.Find(c => c.Id == id);
            if (car == null) return NotFound("No car with that Id exists.");

            car.PriceEuro = newPriceEuro;

            LinksWrapper wrappedCar = new LinksWrapper(car, GenerateCarLinks(car));
            return Ok(new LinksWrapper(wrappedCar, GenerateCarsLinks()));
        }

        [HttpDelete]
        [Route("cars/delete/{id}", Name = "DeleteCar")]
        public IActionResult DeleteCar(int id)
        {
            Car car = Cars.Find(c => c.Id == id);
            if (car == null) return NotFound("No car with that Id exists.");
            Cars.Remove(car);

            LinksWrapper wrappedCar = new LinksWrapper(car, GenerateCarsLinks());

            return Ok(wrappedCar);
        }

        [HttpPost]
        [Route("cars/buy/{carId}", Name = "BuyCar")]
        public IActionResult BuyCar(int carId, Customer customerModel)
        {
            Car car = Cars.Find(c => c.Id == carId);
            if (car == null) return NotFound("No car with that Id exists.");

            Customer customer = Customers.Find(c => c.Id == customerModel.Id);
            if (customer == null)
            {
                customer = new Customer
                {
                    Id = customerModel.Id,
                    Firstname = customerModel.Firstname,
                    Lastname = customerModel.Lastname
                };
                Customers.Add(customer);
            }

            customer.BoughtCars.Add(car);

            LinksWrapper wrappedCar = new LinksWrapper(car, GenerateCarsLinks());

            return Ok(wrappedCar);
        }

        [HttpGet]
        [Route("cars/bought/{filterValue}/{itemsPerPage}/{page}", Name = "GetBoughtCarsByMake")]
        public IActionResult GetBoughtCarsByMake(string filterValue, int itemsPerPage = 10, int page = 1)
        {
            List<BoughtCarsModel> boughtCars = new();
            foreach (Customer customer in Customers)
            {
                var filteredBoughtCars = customer.BoughtCars.FindAll(b => b.Make.Equals(filterValue));
                foreach (Car car in filteredBoughtCars)
                {
                    boughtCars.Add(new BoughtCarsModel { CustomerId = customer.Id, Firstname = customer.Firstname, Lastname = customer.Lastname, Car = car });
                }
            }

            if (boughtCars.Count == 0) return NoContent();

            int index = (page - 1) * itemsPerPage;
            int count = (index + itemsPerPage - 1) < boughtCars.Count ? (index + itemsPerPage) : (boughtCars.Count - index);

            var boughtCarsPaginated = boughtCars.GetRange(index, count);
            if (boughtCarsPaginated == null) return NoContent();

            LinksWrapper wrappedBoughtCarsList = new LinksWrapper(boughtCarsPaginated, GenerateCarsLinks());

            return Ok(wrappedBoughtCarsList);
        }

        private List<LinkInfo> GenerateCarLinks(Car car)
        {
            List<LinkInfo> result = new();

            result.Add(new LinkInfo 
            {
                Href = this.Url.Link("EditCar", new { id = car.Id }),
                Rel = "cars/edit",
                Method = "PUT"
            });

            result.Add(new LinkInfo
            {
                Href = this.Url.Link("EditCarPrice", new { id = car.Id }),
                Rel = "cars/editprice",
                Method = "PATCH"
            });

            result.Add(new LinkInfo
            {
                Href = this.Url.Link("DeleteCar", new { id = car.Id }),
                Rel = "cars/delete",
                Method = "DELETE"
            });

            result.Add(new LinkInfo
            {
                Href = this.Url.Link("GetCarOptions", new { id = car.Id }),
                Rel = "cars/options",
                Method = "OPTIONS"
            });

            result.Add(new LinkInfo
            {
                Href = this.Url.Link("BuyCar", new { carId = car.Id }),
                Rel = "cars/buy",
                Method = "POST"
            });

            return result;
        }

        private List<LinkInfo> GenerateCarsLinks()
        {
            List<LinkInfo> result = new();

            result.Add(new LinkInfo
            {
                Href = this.Url.Link("GetCarsCount", null),
                Rel = "cars/count",
                Method = "HEAD"
            });

            result.Add(new LinkInfo
            {
                Href = this.Url.Link("GetAllCars", null),
                Rel = "cars/all",
                Method = "GET"
            });

            result.Add(new LinkInfo
            {
                Href = this.Url.Link("GetBoughtCarsByMake", new { filterValue = "Make", itemsPerPage = 10, page = 1}),
                Rel = "cars/bought",
                Method = "GET"
            });

            return result;
        }

    }
}
