using MongoDB.Bson;
using MongoDB.Driver;
using Models;
using Data;

namespace Repositories
{
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
        /// Obtém todas as entidades assíncronamente.
        /// </summary>
        /// <returns>Uma lista de entidades do tipo <typeparamref name="T"/>.</returns>
        public async Task<IEnumerable<MovieModel>> GetAllAsync()
        {
            return await _movies.Find(movie => true).ToListAsync();
        }

        /// <summary>
        /// Obtém uma entidade pelo seu ID assíncronamente.
        /// </summary>
        /// <param name="id">O ID da entidade a ser obtida.</param>
        /// <returns>A entidade do tipo <typeparamref name="T"/> correspondente ao ID.</returns>
        public async Task<MovieModel> GetByIdAsync(string id)
        {
            var objectId = new ObjectId(id);
            return await _movies.Find(movie => movie.Id == objectId).FirstOrDefaultAsync();
        }

        /// <summary>
        /// Adiciona uma nova entidade assíncronamente.
        /// </summary>
        /// <param name="entity">A entidade a ser adicionada.</param>
        public async Task CreateAsync(MovieModel entity)
        {
            await _movies.InsertOneAsync(entity);
        }

        /// <summary>
        /// Atualiza uma entidade existente assíncronamente.
        /// </summary>
        /// <param name="id">O ID da entidade a ser atualizada.</param>
        /// <param name="entity">A entidade com as novas informações.</param>
        public async Task UpdateAsync(string id, MovieModel entity)
        {
            var objectId = new ObjectId(id);
            await _movies.ReplaceOneAsync(movie => movie.Id == objectId, entity);
        }

        /// <summary>
        /// Exclui uma entidade pelo seu ID assíncronamente.
        /// </summary>
        /// <param name="id">O ID da entidade a ser excluída.</param>
        public async Task DeleteAsync(string id)
        {
            var objectId = new ObjectId(id);
            await _movies.DeleteOneAsync(movie => movie.Id == objectId);
        }
    }
}
