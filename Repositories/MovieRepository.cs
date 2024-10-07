using MongoDB.Driver;
using Models;
using Data;
using MongoDB.Bson;

namespace Repositories
{
    /// <summary>
    /// Implementa o repositório de filmes, fornecendo métodos para operações CRUD e consultas específicas em objetos do tipo <see cref="MovieModel"/>.
    /// </summary>
    public class MovieRepository : BaseRepository<MovieModel>, IMovieRepository
    {
        private readonly IMongoCollection<MovieModel> _movie; 

        /// <summary>
        /// Inicializa o repositório de filmes com o contexto do MongoDB.
        /// </summary>
        /// <param name="context">Instância do <see cref="MongoDbContext"/> para acessar a coleção de filmes.</param>
        public MovieRepository(MongoDbContext context) : base(context.Movies)
        {
            _movie = context.Movies; 
        }


        /// <summary>
        /// Obtém uma lista de filmes lançados em um ano específico.
        /// </summary>
        /// <param name="year">O ano de lançamento dos filmes.</param>
        /// <returns>Uma lista de filmes do tipo <see cref="MovieModel"/> lançados no ano especificado.</returns>
        public async Task<IEnumerable<MovieModel>> GetMoviesByYearAsync(int year)
        {
            return await _movie.Find(movie => movie.AnoLancamento == year).ToListAsync();
        }

        /// <summary>
        /// Obtém uma lista de filmes cujo título contém uma parte específica do texto.
        /// </summary>
        /// <param name="partialTitle">Parte do título para busca.</param>
        /// <returns>Uma lista de filmes do tipo <see cref="MovieModel"/> que correspondem ao critério de busca.</returns>
        public async Task<IEnumerable<MovieModel>> GetMoviesByTitleAsync(string partialTitle)
        {
            var filter = Builders<MovieModel>.Filter.Regex(movie => movie.Titulo, new BsonRegularExpression(partialTitle, "i"));
            return await _movie.Find(filter).ToListAsync(); 
        }
    }
}
