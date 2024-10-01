using Microsoft.AspNetCore.Mvc;
using Models;
using Repositories;

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
        public async Task<ActionResult<IEnumerable<MovieModel>>> GetAllMoviesAsync()
        {
            var movies = await _movieRepository.GetAllAsync();
            return Ok(movies);
        }

        // GET: api/movies/{id}
        [HttpGet("{id}")]
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
