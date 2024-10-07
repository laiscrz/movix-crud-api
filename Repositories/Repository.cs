using MongoDB.Driver;
using MongoDB.Bson;
using System.Collections.Generic;
using System.Threading.Tasks;
using Data;

namespace Repositories
{
    /// <summary>
    /// Repositório genérico para operações CRUD em uma coleção do MongoDB.
    /// </summary>
    /// <typeparam name="T">Tipo de documento manipulável.</typeparam>
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly IMongoCollection<T> _collection;

        /// <summary>
        /// Inicializa uma nova instância do repositório.
        /// </summary>
        /// <param name="mongoDbFactory">Fábrica para obter a conexão com o banco de dados.</param>
        /// <param name="collectionName">Nome da coleção no MongoDB.</param>
        public Repository(MongoDbFactory mongoDbFactory, string collectionName)
        {
            _collection = mongoDbFactory.GetCollection<T>(collectionName);
        }

        /// <summary>
        /// Obtém todos os documentos da coleção.
        /// </summary>
        /// <returns>Lista de documentos do tipo <typeparamref name="T"/>.</returns>
        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _collection.Find(_ => true).ToListAsync();
        }

        /// <summary>
        /// Obtém um documento pelo ID.
        /// </summary>
        /// <param name="id">ID do documento.</param>
        /// <returns>Documento do tipo <typeparamref name="T"/> ou null.</returns>
        public async Task<T> GetByIdAsync(string id)
        {
            var objectId = new ObjectId(id);
            return await _collection.Find(Builders<T>.Filter.Eq("_id", objectId)).FirstOrDefaultAsync();
        }

        /// <summary>
        /// Cria um novo documento na coleção.
        /// </summary>
        /// <param name="entity">Documento a ser inserido.</param>
        public async Task CreateAsync(T entity)
        {
            await _collection.InsertOneAsync(entity);
        }

        /// <summary>
        /// Atualiza um documento existente na coleção.
        /// </summary>
        /// <param name="id">ID do documento a ser atualizado.</param>
        /// <param name="entity">Novo documento para substituir o existente.</param>
        public async Task UpdateAsync(string id, T entity)
        {
            var objectId = new ObjectId(id);
            await _collection.ReplaceOneAsync(Builders<T>.Filter.Eq("_id", objectId), entity);
        }

        /// <summary>
        /// Remove um documento da coleção pelo ID.
        /// </summary>
        /// <param name="id">ID do documento a ser removido.</param>
        public async Task DeleteAsync(string id)
        {
            var objectId = new ObjectId(id);
            await _collection.DeleteOneAsync(Builders<T>.Filter.Eq("_id", objectId));
        }
    }
}
