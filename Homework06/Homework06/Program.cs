using Homework06.Interfaces;
using Homework06.Models;
using System;

namespace Homework06
{
    class Program
    {
        static void Main(string[] args)
        {

            IRepository<Brand> brandRepo_EF = new EFRepository<Brand>();
            IRepository<Brand> brandRepo_Mongo = new MongoDbRepository<Brand>();

            IRepository<CarModel> modelRepo_EF = new EFRepository<CarModel>();
            IRepository<CarModel> modelRepo_Mongo = new MongoDbRepository<CarModel>();

            Brand mazda = new Brand
            {
                Name = "Mazda"
            };

            Brand bmw = new Brand
            {
                Name = "BMW"
            };

            brandRepo_EF.Insert(mazda);

            var enumerator = brandRepo_EF.GetAll().GetEnumerator();
            enumerator.MoveNext();
            var current = enumerator.Current;


            CarModel cx5 = new CarModel
            {
                Name = "CX-5",
                BrandId = current.Id
            };

            enumerator.Dispose();
            
            //brandRepo_Mongo.Insert(mazda);
            brandRepo_EF.Insert(bmw);
            //brandRepo_Mongo.Insert(bmw);

            brandRepo_EF.Delete(bmw);
            //brandRepo_Mongo.Delete(bmw);

            modelRepo_EF.Insert(cx5);
            //modelRepo_Mongo.Insert(cx5);

        }
    }
}
