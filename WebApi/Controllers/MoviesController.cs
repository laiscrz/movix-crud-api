using Microsoft.AspNetCore.Mvc;
using Models;
using Repositories;
using Swashbuckle.AspNetCore.Annotations;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    /// <summary>
    /// Controlador para gerenciar operações relacionadas a filmes.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class MoviesController : ControllerBase
    {
        private readonly IRepository<MovieModel> _movieRepository;

        /// <summary>
        /// Construtor que inicializa uma nova instância da classe <see cref="MoviesController"/>.
        /// </summary>
        /// <param name="movieRepository">Repositório para gerenciar filmes.</param>
        public MoviesController(IRepository<MovieModel> movieRepository)
        {
            _movieRepository = movieRepository;
        }

        /// <summary>
        /// Obtém todos os filmes.
        /// </summary>
        /// <returns>Uma lista de <see cref="MovieModel"/>.</returns>
        [HttpGet]
        [SwaggerOperation(Summary = "Obter todos os filmes", Description = "Recupera uma lista de todos os filmes.")]
        [Tags("Leitura")]
        [ProducesResponseType(typeof(IEnumerable<MovieModel>), StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<MovieModel>>> GetAllMoviesAsync()
        {
            var movies = await _movieRepository.GetAllAsync();
            return Ok(movies);
        }

        /// <summary>
        /// Obtém um filme pelo ID.
        /// </summary>
        /// <param name="id">O ID do filme a ser recuperado.</param>
        /// <returns>O filme correspondente ao ID.</returns>
        [HttpGet("{id}")]
        [SwaggerOperation(Summary = "Obter um filme pelo ID", Description = "Recupera um filme pelo seu identificador único.")]
        [Tags("Leitura")]
        [ProducesResponseType(typeof(MovieModel), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<MovieModel>> GetMovieByIdAsync(string id)
        {
            var movie = await _movieRepository.GetByIdAsync(id);
            if (movie == null)
            {
                return NotFound();
            }
            return Ok(movie);
        }

        /// <summary>
        /// Cria um novo filme.
        /// </summary>
        /// <param name="movie">O filme a ser criado.</param>
        /// <returns>O filme recém-criado.</returns>
        [HttpPost]
        [SwaggerOperation(Summary = "Criar um novo filme", Description = "Adiciona um novo filme à coleção.")]
        [Tags("Criação")]
        [ProducesResponseType(typeof(MovieModel), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<MovieModel>> CreateMovieAsync([FromBody] MovieModel movie)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _movieRepository.AddAsync(movie);
            return CreatedAtAction(nameof(GetMovieByIdAsync), new { id = movie.Id }, movie);
        }

        /// <summary>
        /// Atualiza um filme existente.
        /// </summary>
        /// <param name="id">O ID do filme a ser atualizado.</param>
        /// <param name="movie">O filme com as novas informações.</param>
        /// <returns>Um resultado indicando o sucesso da operação.</returns>
        [HttpPut("{id}")]
        [SwaggerOperation(Summary = "Atualizar um filme", Description = "Atualiza um filme existente.")]
        [Tags("Atualização")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateMovieAsync(string id, [FromBody] MovieModel movie)
        {
            if (id != movie.Id || !ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _movieRepository.UpdateAsync(movie);
            return NoContent();
        }

        /// <summary>
        /// Deleta um filme pelo ID.
        /// </summary>
        /// <param name="id">O ID do filme a ser removido.</param>
        /// <returns>Um resultado indicando o sucesso da operação.</returns>
        [HttpDelete("{id}")]
        [SwaggerOperation(Summary = "Deletar um filme", Description = "Remove um filme da coleção.")]
        [Tags("Exclusão")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteMovieAsync(string id)
        {
            var movie = await _movieRepository.GetByIdAsync(id);
            if (movie == null)
            {
                return NotFound();
            }
            await _movieRepository.DeleteAsync(id);
            return NoContent();
        }
    }
}
