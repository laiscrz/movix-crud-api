using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using Repositories;
using Swashbuckle.AspNetCore.Annotations;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MoviesController : ControllerBase
    {
        private readonly IRepository<MovieModel> _movieRepository;

        public MoviesController(IRepository<MovieModel> movieRepository)
        {
            _movieRepository = movieRepository;
        }

        /// <summary>
        /// Obtém todos os filmes.
        /// </summary>
        /// <returns>Uma lista de filmes.</returns>
        [HttpGet]
        [Tags("Ler")]
        [SwaggerOperation(Summary = "Obter todos os filmes", Description = "Retorna uma lista de todos os filmes.")]
        [ProducesResponseType(typeof(IEnumerable<MovieModel>), StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<MovieModel>>> GetAllMovies()
        {
            var movies = await _movieRepository.GetAllAsync();
            return Ok(movies);
        }

        /// <summary>
        /// Obtém um filme pelo seu ID.
        /// </summary>
        /// <param name="id">ID do filme.</param>
        /// <returns>O filme correspondente ao ID.</returns>
        [HttpGet("{id}")]
        [Tags("Ler")]
        [SwaggerOperation(Summary = "Obter filme por ID", Description = "Retorna um filme específico com base no ID.")]
        [ProducesResponseType(typeof(MovieModel), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<MovieModel>> GetMovieById(string id)
        {
            var movie = await _movieRepository.GetByIdAsync(id);
            if (movie == null)
            {
                return NotFound();
            }
            return Ok(movie);
        }

        /// <summary>
        /// Adiciona um novo filme.
        /// </summary>
        /// <param name="movie">Modelo do filme a ser adicionado.</param>
        /// <returns>Uma ação resultante da criação do filme.</returns>
        [HttpPost]
        [Tags("Criar")]
        [SwaggerOperation(Summary = "Adicionar um novo filme", Description = "Cria um novo filme.")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> CreateMovie([FromBody] MovieModel movie)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _movieRepository.CreateAsync(movie);
            return CreatedAtAction(nameof(GetMovieById), new { id = movie.Id.ToString() }, movie);
        }

        /// <summary>
        /// Atualiza um filme existente.
        /// </summary>
        /// <param name="id">ID do filme a ser atualizado.</param>
        /// <param name="movie">Modelo do filme com as novas informações.</param>
        /// <returns>Uma ação resultante da atualização do filme.</returns>
        [HttpPut("{id}")]
        [Tags("Atualizar")]
        [SwaggerOperation(Summary = "Atualizar um filme", Description = "Atualiza um filme existente.")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> UpdateMovie(string id, [FromBody] MovieModel movie)
        {
            var existingMovie = await _movieRepository.GetByIdAsync(id);

            if (existingMovie == null)
            {
                return NotFound();
            }

            // Mantenha o _id do filme existente
            movie.Id = existingMovie.Id;

            await _movieRepository.UpdateAsync(id, movie);
            return NoContent();
        }

        /// <summary>
        /// Exclui um filme pelo seu ID.
        /// </summary>
        /// <param name="id">ID do filme a ser excluído.</param>
        /// <returns>Uma ação resultante da exclusão do filme.</returns>
        [HttpDelete("{id}")]
        [Tags("Deletar")]
        [SwaggerOperation(Summary = "Excluir um filme", Description = "Remove um filme existente.")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> DeleteMovie(string id)
        {
            var existingMovie = await _movieRepository.GetByIdAsync(id);
            if (existingMovie == null)
            {
                return NotFound();
            }
            await _movieRepository.DeleteAsync(id);
            return NoContent();
        }
    }
}
