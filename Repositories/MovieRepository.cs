using MongoDB.Driver;
using Models;
using Data;

namespace Repositories
{
    /// <summary>
    /// Implementa o repositório de filmes, fornecendo métodos para operações CRUD e consultas específicas em objetos do tipo <see cref="MovieModel"/>.
    /// </summary>
    public class MovieRepository : Repository<MovieModel>, IMovieRepository
    {
        /// <summary>
        /// Inicializa uma nova instância da classe <see cref="MovieRepository"/>.
        /// </summary>
        /// <param name="mongoDbFactory">Fábrica para obter a conexão com o banco de dados.</param>
        /// <param name="mongoDbSettings">Configurações do MongoDB, incluindo o nome da coleção.</param>
        public MovieRepository(MongoDbFactory mongoDbFactory, MongoDbSettings mongoDbSettings)
            : base(mongoDbFactory, mongoDbSettings.CollectionName)
        {
        }

        /// <summary>
        /// Obtém uma lista de filmes lançados em um ano específico.
        /// </summary>
        /// <param name="year">O ano de lançamento dos filmes.</param>
        /// <returns>Uma lista de filmes do tipo <see cref="MovieModel"/> lançados no ano especificado.</returns>
        public async Task<IEnumerable<MovieModel>> GetMoviesByYearAsync(int year)
        {
            return await _collection.Find(movie => movie.AnoLancamento == year).ToListAsync();
        }
    }
}
