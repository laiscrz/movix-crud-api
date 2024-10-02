using Models;

namespace Repositories
{
    public interface IMovieRepository : IRepository<MovieModel>
    {
        Task<IEnumerable<MovieModel>> GetMoviesByYearAsync(int year);
        
    }
}
