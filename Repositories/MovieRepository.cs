using MongoDB.Driver;
using Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using Data;

namespace Repositories
{
    public class MovieRepository : Repository<MovieModel>, IMovieRepository
    {
        public MovieRepository(MongoDbFactory mongoDbFactory, MongoDbSettings mongoDbSettings)
            : base(mongoDbFactory, mongoDbSettings.CollectionName)
        {
        }

        public async Task<IEnumerable<MovieModel>> GetMoviesByYearAsync(int year)
        {
            return await _collection.Find(movie => movie.AnoLancamento == year).ToListAsync();
        }
    }
}
