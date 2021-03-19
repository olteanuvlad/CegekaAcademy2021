using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace GenericsExercise.Console
{
    class PersistenceManager
    {
        private Persistence persistence;

        public PersistenceManager()
        {
            persistence = new Persistence();
        }

        public async Task<string> InsertAsyncVerbose<TEntity>(TEntity entity) where TEntity : IEntity
        {
            try
            {
                await persistence.InsertAsync(entity);
            }
            catch (ArgumentException)
            {
                return "[Invalid Id] Id must not be null, cannot contain %, and must not be longer than 10 characters.";
            }
            catch (InvalidOperationException)
            {
                return $"[Maximum capacity reached] No more objects of type {typeof(TEntity).Name} can be inserted.";
            }
            catch (Exception e)
            {
                return e.Message;
            }
            return $"Successfully inserted {typeof(TEntity).Name} - {entity.ToString()}";
        }

        public async Task<List<string>> GetAllAsyncVerbose<TEntity>() where TEntity : IEntity
        {
            var result = new List<string>();

            try
            {
                var entityEnumerable = await persistence.GetAllAsync<TEntity>();
                foreach(TEntity entity in entityEnumerable)
                {
                    result.Add(entity.ToString());
                }

            }
            catch (InvalidOperationException)
            {
                result.Add($"[Empty] There are no objects of type {typeof(TEntity).Name} in storage.");
            }

            catch (Exception e)
            {
                result.Add(e.Message);
            }

            return result;
        }
    }
}
