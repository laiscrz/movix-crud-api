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

        // GET: api/movies
        [HttpGet]
        [SwaggerOperation(Summary = "Obter todos os filmes", Description = "Recupera uma lista de todos os filmes.")]
        [Tags("Leitura")]
        [ProducesResponseType(typeof(IEnumerable<MovieModel>), StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<MovieModel>>> GetAllMoviesAsync()
        {
            var movies = await _movieRepository.GetAllAsync();
            return Ok(movies);
        }

        // GET: api/movies/{id}
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

        // POST: api/movies
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

        // PUT: api/movies/{id}
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

        // DELETE: api/movies/{id}
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
