using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;
using Models;
using Data;

namespace Repositories
{
    /// <summary>
    /// Implementação do repositório para gerenciar filmes.
    /// </summary>
    public class MovieRepository : IRepository<MovieModel>
    {
        private readonly IMongoCollection<MovieModel> _movies;

        /// <summary>
        /// Construtor que inicializa uma nova instância da classe <see cref="MovieRepository"/>.
        /// </summary>
        /// <param name="mongoDbFactory">Fábrica para criar a conexão com o MongoDB.</param>
        /// <param name="mongoDbSettings">Configurações do MongoDB.</param>
        public MovieRepository(MongoDbFactory mongoDbFactory, MongoDbSettings mongoDbSettings)
        {
            var database = mongoDbFactory.GetDatabase();
            _movies = database.GetCollection<MovieModel>(mongoDbSettings.CollectionName);
        }

        /// <summary>
        /// Obtém todos os filmes assíncronamente.
        /// </summary>
        /// <returns>Uma lista de <see cref="MovieModel"/>.</returns>
        public async Task<IEnumerable<MovieModel>> GetAllAsync()
        {
            return await _movies.Find(movie => true).ToListAsync();
        }

        /// <summary>
        /// Obtém um filme pelo seu ID assíncronamente.
        /// </summary>
        /// <param name="id">O ID do filme a ser obtido.</param>
        /// <returns>O filme correspondente ao ID.</returns>
        public async Task<MovieModel> GetByIdAsync(string id)
        {
            return await _movies.Find(Builders<MovieModel>.Filter.Eq(m => m.Id, id)).FirstOrDefaultAsync();
        }

        /// <summary>
        /// Adiciona um novo filme assíncronamente.
        /// </summary>
        /// <param name="movie">O filme a ser adicionado.</param>
        public async Task AddAsync(MovieModel movie)
        {
            await _movies.InsertOneAsync(movie);
        }

        /// <summary>
        /// Atualiza um filme existente assíncronamente.
        /// </summary>
        /// <param name="movie">O filme com as novas informações.</param>
        public async Task UpdateAsync(MovieModel movie)
        {
            await _movies.ReplaceOneAsync(Builders<MovieModel>.Filter.Eq(m => m.Id, movie.Id), movie);
        }

        /// <summary>
        /// Exclui um filme pelo seu ID assíncronamente.
        /// </summary>
        /// <param name="id">O ID do filme a ser excluído.</param>
        public async Task DeleteAsync(string id)
        {
            await _movies.DeleteOneAsync(Builders<MovieModel>.Filter.Eq(m => m.Id, id));
        }
    }
}
