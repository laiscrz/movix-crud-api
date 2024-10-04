using AutoMapper;
using DTOs;
using Newtonsoft.Json;
using System.Text;
using Mapping;
using System.Net;

namespace Tests.Integration
{
    public class MoviesControllerIntegrationTests
    {
        private readonly HttpClient _httpClient;
        private readonly IMapper _mapper;

        public MoviesControllerIntegrationTests()
        {
            // Configuração do AutoMapper
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MovieMappingProfile>();
            });
            _mapper = config.CreateMapper();

            // Configuração do HttpClient
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri("http://localhost:5072/api/")
            };
        }

        [Fact]
        public async Task CreateMovie_ShouldReturnBadRequest_WhenDirectorIsNumber()
        {
            // Arrange
            var invalidMovie = new
            {
                Titulo = "A Origem", 
                Diretor = 12345, 
                AnoLancamento = 2024,
                Genero = new List<string> {"Ação", "Aventura"  },
                Sinopse = "Um ladrão que entra nos sonhos das pessoas para roubar suas ideias."
            };

            var jsonContent = JsonConvert.SerializeObject(invalidMovie);
            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            // Act
            var response = await _httpClient.PostAsync("movies", content);

            // Assert
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [Fact]
        public async Task CreateMovie_ShouldReturnBadRequest_WhenMovieRequestIsEmpty()
        {
            // Arrange
            var emptyMovie = new MovieRequestDTO(); // Um objeto MovieRequestDTO vazio
            var jsonContent = JsonConvert.SerializeObject(emptyMovie);
            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            // Act
            var response = await _httpClient.PostAsync("movies", content);

            // Assert
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [Fact]
        public async Task CreateMovie_ShouldReturnCreated_WhenMovieIsValid()
        {
            // Arrange
            var validMovie = new MovieRequestDTO
            {
                Titulo = "Os Vingadores",
                Diretor = "Joss Whedon",
                AnoLancamento = 2012,
                Genero = new List<string> { "Ação", "Aventura" },
                Sinopse = "Um grupo de super-heróis se une para salvar o planeta de uma ameaça alienígena."
            };

            var jsonContent = JsonConvert.SerializeObject(validMovie);
            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            // Act
            var response = await _httpClient.PostAsync("movies", content);

            // Assert
            Assert.Equal(HttpStatusCode.Created, response.StatusCode);
        }

        [Fact]
        public async Task GetMoviesByYear_ShouldReturnNotFound_WhenNoMoviesFoundForYear()
        {
            // Arrange
            var nonexistentYear = 3000; // não terá filmes cadastrados

            // Act
            var response = await _httpClient.GetAsync($"movies/year/{nonexistentYear}");

            // Assert
            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }

    }
}
