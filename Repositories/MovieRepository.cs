using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;
using Models;
using Data;

namespace Repositories
{
    public class MovieRepository : IRepository<MovieModel>
    {
        private readonly IMongoCollection<MovieModel> _movies;

        public MovieRepository(MongoDbFactory mongoDbFactory, MongoDbSettings mongoDbSettings)
        {
            var database = mongoDbFactory.GetDatabase();
            _movies = database.GetCollection<MovieModel>(mongoDbSettings.CollectionName);
        }


        public async Task<IEnumerable<MovieModel>> GetAllAsync()
        {
            return await _movies.Find(movie => true).ToListAsync();
        }

        public async Task<MovieModel> GetByIdAsync(string id)
        {
            return await _movies.Find(Builders<MovieModel>.Filter.Eq(m => m.Id, id)).FirstOrDefaultAsync();
        }

        public async Task AddAsync(MovieModel movie)
        {
            await _movies.InsertOneAsync(movie);
        }

        public async Task UpdateAsync(MovieModel movie)
        {
            await _movies.ReplaceOneAsync(Builders<MovieModel>.Filter.Eq(m => m.Id, movie.Id), movie);
        }

        public async Task DeleteAsync(string id)
        {
            await _movies.DeleteOneAsync(Builders<MovieModel>.Filter.Eq(m => m.Id, id));
        }
    }
}
