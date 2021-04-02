using Homework06.Interfaces;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework06
{
    class MongoDbRepository<TEntity> : IRepository<TEntity>
        where TEntity : class, IEntity
    {

        private readonly IMongoDatabase database;

        public MongoDbRepository()
        {
            var client = new MongoClient("mongodb+srv://vlad:vlad@cluster0.vgntw.mongodb.net/myFirstDatabase?retryWrites=true&w=majority");
            database = client.GetDatabase("CarDealership");
        }

        public void Delete(TEntity entity)
        {
            database.GetCollection<TEntity>(typeof(TEntity).Name).DeleteOneAsync(e => e.Id == entity.Id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return database.GetCollection<TEntity>(typeof(TEntity).Name).Find(e => true).ToEnumerable();
        }

        public TEntity GetById(Guid id)
        {
            return database.GetCollection<TEntity>(typeof(TEntity).Name).Find(e => e.Id == id).SingleOrDefault();
        }

        public void Insert(TEntity entity)
        {
            database.GetCollection<TEntity>(typeof(TEntity).Name).InsertOne(entity);
        }

        public void Update(TEntity entity)
        {
            database.GetCollection<TEntity>(typeof(TEntity).Name).ReplaceOne(e => e.Id == entity.Id, entity);
        }
    }
}
