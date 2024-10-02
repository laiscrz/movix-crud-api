using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using Repositories;
using Swashbuckle.AspNetCore.Annotations;
using DTOs;
using MongoDB.Bson;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MoviesController : ControllerBase
    {
        private readonly IMovieRepository _movieRepository;

        public MoviesController(IMovieRepository movieRepository)
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
        [ProducesResponseType(typeof(IEnumerable<MovieResponseDTO>), StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<MovieResponseDTO>>> GetAllMovies()
        {
            var movies = await _movieRepository.GetAllAsync();
            var movieDtos = movies.Select(movie => new MovieResponseDTO(movie)).ToList();
            return Ok(movieDtos);
        }

        /// <summary>
        /// Obtém um filme pelo seu ID.
        /// </summary>
        /// <param name="id">ID do filme.</param>
        /// <returns>O filme correspondente ao ID.</returns>
        [HttpGet("{id}")]
        [Tags("Ler")]
        [SwaggerOperation(Summary = "Obter filme por ID", Description = "Retorna um filme específico com base no ID.")]
        [ProducesResponseType(typeof(MovieResponseDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<MovieResponseDTO>> GetMovieById(string id)
        {
            var movie = await _movieRepository.GetByIdAsync(id);
            if (movie == null)
            {
                return NotFound();
            }
            return Ok(new MovieResponseDTO(movie));
        }

        /// <summary>
        /// Adiciona um novo filme.
        /// </summary>
        /// <param name="movieDto">Modelo do filme a ser adicionado.</param>
        /// <returns>Uma ação resultante da criação do filme.</returns>
        [HttpPost]
        [Tags("Criar")]
        [SwaggerOperation(Summary = "Adicionar um novo filme", Description = "Cria um novo filme.")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> CreateMovie([FromBody] MovieRequestDTO movieDto)
        {
            var movie = movieDto.ToModel();
            await _movieRepository.CreateAsync(movie);

            var movieResponseDto = new MovieResponseDTO(movie);
            return CreatedAtAction(nameof(GetMovieById), new { id = movie.Id.ToString() }, movieResponseDto);
        }

        /// <summary>
        /// Atualiza um filme existente.
        /// </summary>
        /// <param name="id">ID do filme a ser atualizado.</param>
        /// <param name="movieDto">Modelo do filme com as novas informações.</param>
        /// <returns>Uma ação resultante da atualização do filme.</returns>
        [HttpPut("{id}")]
        [Tags("Atualizar")]
        [SwaggerOperation(Summary = "Atualizar um filme", Description = "Atualiza um filme existente.")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> UpdateMovie(string id, [FromBody] MovieRequestDTO movieDto)
        {
            if (!ObjectId.TryParse(id, out var objectId))
            {
                return BadRequest("ID inválido.");
            }

            var existingMovie = await _movieRepository.GetByIdAsync(id);

            if (existingMovie == null)
            {
                return NotFound();
            }

            var movieToUpdate = movieDto.ToModel();
            movieToUpdate.Id = existingMovie.Id;

            await _movieRepository.UpdateAsync(id, movieToUpdate);
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
            if (!ObjectId.TryParse(id, out var objectId))
            {
                return BadRequest("ID inválido.");
            }

            var existingMovie = await _movieRepository.GetByIdAsync(id);
            if (existingMovie == null)
            {
                return NotFound();
            }

            await _movieRepository.DeleteAsync(id);
            return NoContent();
        }

        [HttpGet("year/{year}")]
        [Tags("Ler")]
        [SwaggerOperation(Summary = "Obter filmes por ano", Description = "Retorna uma lista de filmes lançados em um ano específico.")]
        [ProducesResponseType(typeof(IEnumerable<MovieResponseDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<MovieResponseDTO>>> GetMoviesByYear(int year)
        {
            var movies = await _movieRepository.GetMoviesByYearAsync(year);
            if (movies == null || !movies.Any())
            {
                return NotFound();
            }

            var movieDtos = movies.Select(movie => new MovieResponseDTO(movie)).ToList();
            return Ok(movieDtos);
        }
    }
}
