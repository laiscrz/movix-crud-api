using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Models;
using DTOs;

namespace WebApi.Controllers
{
    /// <summary>
    /// Interface que define as operações da controladora de filmes.
    /// </summary>
    public interface IMoviesController
    {
        /// <summary>
        /// Obtém todos os filmes.
        /// </summary>
        /// <returns>Uma lista de filmes.</returns>
        Task<ActionResult<IEnumerable<MovieResponseDTO>>> GetAllMovies();

        /// <summary>
        /// Obtém um filme pelo seu ID.
        /// </summary>
        /// <param name="id">ID do filme.</param>
        /// <returns>O filme correspondente ao ID.</returns>
        Task<ActionResult<MovieResponseDTO>> GetMovieById(string id);

        /// <summary>
        /// Adiciona um novo filme.
        /// </summary>
        /// <param name="movieDto">Modelo do filme a ser adicionado.</param>
        /// <returns>Uma ação resultante da criação do filme.</returns>
        Task<ActionResult> CreateMovie(MovieRequestDTO movieDto);

        /// <summary>
        /// Atualiza um filme existente.
        /// </summary>
        /// <param name="id">ID do filme a ser atualizado.</param>
        /// <param name="movieDto">Modelo do filme com as novas informações.</param>
        /// <returns>Uma ação resultante da atualização do filme.</returns>
        Task<ActionResult<string>> UpdateMovie(string id, MovieRequestDTO movieDto);

        /// <summary>
        /// Exclui um filme pelo seu ID.
        /// </summary>
        /// <param name="id">ID do filme a ser excluído.</param>
        /// <returns>Uma ação resultante da exclusão do filme.</returns>
        Task<ActionResult<string>> DeleteMovie(string id);

        /// <summary>
        /// Obtém filmes lançados em um ano específico.
        /// </summary>
        /// <param name="year">Ano de lançamento dos filmes.</param>
        /// <returns>Uma lista de filmes lançados no ano especificado.</returns>
        Task<ActionResult<IEnumerable<MovieResponseDTO>>> GetMoviesByYear(int year);
    }
}
