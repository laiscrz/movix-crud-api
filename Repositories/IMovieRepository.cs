using Models;

namespace Repositories
{
    /// <summary>
    /// Interface para o repositório de filmes, fornecendo métodos específicos para manipulação de objetos do tipo <see cref="MovieModel"/>.
    /// </summary>
    public interface IMovieRepository : IRepository<MovieModel>
    {
        /// <summary>
        /// Obtém uma lista de filmes lançados em um ano específico.
        /// </summary>
        /// <param name="year">O ano de lançamento dos filmes.</param>
        /// <returns>Uma lista de filmes do tipo <see cref="MovieModel"/> lançados no ano especificado.</returns>
        Task<IEnumerable<MovieModel>> GetMoviesByYearAsync(int year);
        
        /// <summary>
        /// Obtém uma lista de filmes cujo título contém a parte específica fornecida.
        /// </summary>
        /// <param name="partialTitle">A parte do título dos filmes a serem buscados.</param>
        /// <returns>Uma lista de filmes do tipo <see cref="MovieModel"/> cujo título contém a parte especificada.</returns>
        Task<IEnumerable<MovieModel>> GetMoviesByTitleAsync(string partialTitle);
    }
}
