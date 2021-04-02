﻿using Homework06.Interfaces;
using Homework06.Models;
using System;

namespace Homework06
{
    class Program
    {
        static void Main(string[] args)
        {
            Brand mazda = new Brand
            {
                Name = "Mazda"
            };

            Brand bmw = new Brand
            {
                Name = "BMW"
            };

            CarModel cx5 = new CarModel
            {
                Name = "CX-5",
                BrandId = mazda.Id
            };

            IRepository<Brand> brandRepo_EF = new EFRepository<Brand>();
            IRepository<Brand> brandRepo_Mongo = new MongoDbRepository<Brand>();

            IRepository<CarModel> modelRepo_EF = new EFRepository<CarModel>();
            IRepository<CarModel> modelRepo_Mongo = new MongoDbRepository<CarModel>();


            //brandRepo_EF.Insert(mazda);
            brandRepo_Mongo.Insert(mazda);
           // brandRepo_EF.Insert(bmw);
            brandRepo_Mongo.Insert(bmw);

            //brandRepo_EF.Delete(bmw);
            brandRepo_Mongo.Delete(bmw);

            //modelRepo_EF.Insert(cx5);
            modelRepo_Mongo.Insert(cx5);

        }
    }
}
