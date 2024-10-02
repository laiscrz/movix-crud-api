using MongoDB.Driver;
using MongoDB.Bson;
using System.Collections.Generic;
using System.Threading.Tasks;
using Data;

namespace Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly IMongoCollection<T> _collection;

        public Repository(MongoDbFactory mongoDbFactory, string collectionName)
        {
            var database = mongoDbFactory.GetDatabase();
            _collection = database.GetCollection<T>(collectionName);
        }


        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _collection.Find(_ => true).ToListAsync();
        }

        public async Task<T> GetByIdAsync(string id)
        {
            var objectId = new ObjectId(id);
            return await _collection.Find(Builders<T>.Filter.Eq("_id", objectId)).FirstOrDefaultAsync();
        }

        public async Task CreateAsync(T entity)
        {
            await _collection.InsertOneAsync(entity);
        }

        public async Task UpdateAsync(string id, T entity)
        {
            var objectId = new ObjectId(id);
            await _collection.ReplaceOneAsync(Builders<T>.Filter.Eq("_id", objectId), entity);
        }

        public async Task DeleteAsync(string id)
        {
            var objectId = new ObjectId(id);
            await _collection.DeleteOneAsync(Builders<T>.Filter.Eq("_id", objectId));
        }
    }
}
