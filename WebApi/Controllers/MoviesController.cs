using Microsoft.AspNetCore.Mvc;
using Repositories;
using Swashbuckle.AspNetCore.Annotations;
using DTOs;

namespace WebApi.Controllers
{
    /// <summary>
    /// Controlador para gerenciar operações relacionadas a filmes.
    /// </summary>
    /// <remarks>
    /// Este controlador fornece endpoints para criar, ler, atualizar 
    /// e excluir filmes no catálogo.
    /// </remarks>
    [ApiController]
    [Route("api/[controller]")]
    public class MoviesController : ControllerBase, IMoviesController
    {
        private readonly IMovieRepository _movieRepository;

        public MoviesController(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }

        /// <summary>
        /// Obtém todos os filmes disponíveis no catálogo.
        /// </summary>
        /// <returns>Uma lista de filmes.</returns>
        [HttpGet]
        [Tags("Ler")]
        [SwaggerOperation(Summary = "Obter todos os filmes",
            Description = "Retorna uma lista de todos os filmes disponíveis no catálogo.")]
        [ProducesResponseType(typeof(IEnumerable<MovieResponseDTO>), StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<MovieResponseDTO>>> GetAllMovies()
        {
            var movies = await _movieRepository.GetAllAsync();
            var movieDtos = movies.Select(movie => new MovieResponseDTO(movie)).ToList();
            return Ok(movieDtos);
        }

        /// <summary>
        /// Obtém um filme específico com base no ID fornecido.
        /// </summary>
        /// <param name="id">ID do filme.</param>
        /// <returns>O filme correspondente ao ID, se encontrado.</returns>
        [HttpGet("{id}")]
        [Tags("Ler")]
        [SwaggerOperation(Summary = "Obter filme por ID",
            Description = "Retorna um filme específico com base no ID fornecido.")]
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
        /// Adiciona um novo filme ao catálogo.
        /// </summary>
        /// <param name="movieDto">Modelo do filme a ser adicionado.</param>
        /// <returns>Ação resultante da criação do filme.</returns>
        [HttpPost]
        [Tags("Criar")]
        [SwaggerOperation(Summary = "Adicionar um novo filme",
            Description = "Cria um novo filme no catálogo com base nos dados fornecidos.")]
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
        /// Atualiza as informações de um filme existente.
        /// </summary>
        /// <param name="id">ID do filme a ser atualizado.</param>
        /// <param name="movieDto">Modelo do filme com as novas informações.</param>
        /// <returns>Ação resultante da atualização do filme.</returns>
        [HttpPut("{id}")]
        [Tags("Atualizar")]
        [SwaggerOperation(Summary = "Atualizar um filme",
            Description = "Atualiza um filme existente com as novas informações fornecidas.")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<string>> UpdateMovie(string id, [FromBody] MovieRequestDTO movieDto)
        {
            var existingMovie = await _movieRepository.GetByIdAsync(id);
            if (existingMovie == null)
            {
                return NotFound();
            }

            var movieToUpdate = movieDto.ToModel();
            movieToUpdate.Id = existingMovie.Id;

            await _movieRepository.UpdateAsync(id, movieToUpdate);

            return Ok("Filme atualizado com sucesso."); 
        }

        /// <summary>
        /// Exclui um filme do catálogo com base no ID fornecido.
        /// </summary>
        /// <param name="id">ID do filme a ser excluído.</param>
        /// <returns>Ação resultante da exclusão do filme.</returns>
        [HttpDelete("{id}")]
        [Tags("Deletar")]
        [SwaggerOperation(Summary = "Excluir um filme",
            Description = "Remove um filme existente do catálogo com base no ID fornecido.")]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<string>> DeleteMovie(string id)
        {
            var existingMovie = await _movieRepository.GetByIdAsync(id);
            if (existingMovie == null)
            {
                return NotFound();
            }

            await _movieRepository.DeleteAsync(id);

            return Ok("Filme excluído com sucesso.");
        }

        /// <summary>
        /// Obtém uma lista de filmes lançados em um ano específico.
        /// </summary>
        /// <param name="year">Ano de lançamento dos filmes.</param>
        /// <returns>Uma lista de filmes lançados no ano especificado.</returns>
        [HttpGet("year/{year}")]
        [Tags("Ler")]
        [SwaggerOperation(Summary = "Obter filmes por ano",
            Description = "Retorna uma lista de filmes que foram lançados em um ano específico.")]
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
