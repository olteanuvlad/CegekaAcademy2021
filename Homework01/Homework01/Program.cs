using System;
using System.Collections.Generic;

namespace Homework01
{

   class Package
    {
        public string Name { get; set; }
        public string Description { get; set; }

        private static List<Package> packages = new();

        public Package(string name, string description)
        {
            Name = name;
            Description = description;
            packages.Add(this);
        }

        public static int Count()
        {
            return packages.Count;
        }

        public static Package GetPackageAt(int index)
        {
            return packages[index];
        }

        public override string ToString()
        {
            return Name + ": " + Description;
        }
    }


    class Car 
    {
        public string Model { get; set; }
        private Package package;

        private static List<Car> cars = new();

        public Car(string model, Package package)
        {
            Model = model;
            this.package = package;
            cars.Add(this);
        }

       public static int Count()
        {
            return cars.Count;
        }

        public static Car GetCarAt (int index) 
        {
            return cars[index];
        }

        public override string ToString()
        {
            return Model + " " + package.Name;
        }

        public string Details()
        {
            return Model + " " + package.Name + " " + package.Description;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            new Package(name: "Advantage", description: "1.6 Turbo Diesel 90HP FWD");
            new Package(name: "Premium", description: "2.0 Gasoline 144HP FWD");
            new Package(name: "Exclusive", description: "2.2 Hybrid 142HP FWD");
            new Package(name: "Sport", description: "3.2 Turbo Gasoline 366HP AWD");

            new Car(model: "Citroen", package: Package.GetPackageAt(0));

            int option = 1;
            while( option != 0 )
            {
                Console.WriteLine("");
                Console.WriteLine("1. Print number of cars");
                Console.WriteLine("2. Print all cars");
                Console.WriteLine("3. Print car at index");
                Console.WriteLine("4. Print all packages");
                Console.WriteLine("5. Create new package");
                Console.WriteLine("6. Create new car");
                Console.WriteLine("0. Exit");
                Console.WriteLine("");

                option = Convert.ToInt32(Console.ReadLine());

                switch (option)
                {
                    case 0:
                        break;
                    case 1:
                        Console.WriteLine("==========================================");
                        Console.WriteLine($"Total number of cars: {Car.Count()}");
                        Console.WriteLine("==========================================");
                        break;
                    case 2:
                        Console.WriteLine("================ALL CARS==================");
                        for (int i=0; i<Car.Count(); i++)
                        {
                            Console.WriteLine($"{i + 1}. {Car.GetCarAt(i).ToString()}");
                        }
                        Console.WriteLine("==========================================");
                        break;
                    case 3:
                        Console.WriteLine("Index: ");
                        int index = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("===============CAR DETAILS================");
                        Console.WriteLine($"{ Car.GetCarAt(index-1).Details() } ");
                        Console.WriteLine("==========================================");
                        break;
                    case 4:
                        Console.WriteLine("===============ALL PACKAGES===============");
                        for (int i=0; i<Package.Count(); i++)
                        {
                            Console.WriteLine($"{i + 1}. { Package.GetPackageAt(i).ToString() }");
                        }
                        Console.WriteLine("==========================================");
                        break;
                    case 5:
                        Console.WriteLine("Name for new package: ");
                        string name = Console.ReadLine();
                        Console.WriteLine("Description for new package: ");
                        string description = Console.ReadLine();
                        new Package(name, description);
                        break;
                    case 6:
                        Console.WriteLine("Model of new car: ");
                        string model = Console.ReadLine();
                        Console.WriteLine("Package index for new car: ");
                        int packageIndex = Convert.ToInt32(Console.ReadLine());
                        new Car(model, Package.GetPackageAt(packageIndex - 1));
                        break;
                    default:
                        Console.WriteLine("Invalid option.");
                        break;
                }
            }
        }
    }
}
