using AutoMapper;
using DTOs;
using Newtonsoft.Json;
using System.Text;
using Mapping;
using System.Net;

namespace Tests.Integration
{
    /// <summary>
    /// Classe de testes de integração para o MoviesController.
    /// Contém testes para operações CRUD de filmes na API, verificando o comportamento
    /// em diferentes cenários, incluindo entradas válidas e inválidas, e os códigos
    /// de status HTTP esperados.
    /// </summary>
    public class MoviesControllerTests
    {
        private readonly HttpClient _httpClient;

        public MoviesControllerTests()
        {
            // Configuração do HttpClient
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri("http://localhost:5072/api/")
            };
        }

        /// <summary>
        /// Testa a criação de um filme quando o diretor é um número.
        /// Espera um BadRequest (400).
        /// </summary>
        [Fact]
        public async Task CreateMovie_ShouldReturnBadRequest_WhenDirectorIsNumber()
        {
            // Arrange
            var invalidMovie = new
            {
                Titulo = "A Origem",
                Diretor = 12345, // Diretor inválido 
                AnoLancamento = 2024,
                Genero = new List<string> { "Ação", "Aventura" },
                Sinopse = "Um ladrão que entra nos sonhos das pessoas para roubar suas ideias."
            };

            var jsonContent = JsonConvert.SerializeObject(invalidMovie);
            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            // Act
            var response = await _httpClient.PostAsync("movies", content);

            // Assert
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }

        /// <summary>
        /// Testa a criação de um filme quando a solicitação está vazia.
        /// Espera um BadRequest (400).
        /// </summary>
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

        /// <summary>
        /// Testa a criação de um filme válido.
        /// Espera um Created (201).
        /// </summary>
        [Fact]
        public async Task CreateMovie_ShouldReturnCreated_WhenMovieIsValid()
        {
            // Arrange
            var validMovie = new MovieRequestDTO
            {
                Titulo = "A Culpa é das Estrelas",
                Diretor = "Josh Boone",
                AnoLancamento = 2014,
                Genero = new List<string> { "Drama", "Romance" },
                Sinopse = "Dois adolescentes com câncer se apaixonam e vivem uma história de amor intensa e emocionante."
            };

            var jsonContent = JsonConvert.SerializeObject(validMovie);
            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            // Act
            var response = await _httpClient.PostAsync("movies", content);

            // Assert
            Assert.Equal(HttpStatusCode.Created, response.StatusCode);
        }

        /// <summary>
        /// Testa a recuperação de filmes por ano quando nenhum filme é encontrado.
        /// Espera um NotFound (404).
        /// </summary>
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

        /// <summary>
        /// Testa a atualização de um filme.
        /// Espera um NoContent (204) se a atualização for bem-sucedida.
        /// </summary>
        [Fact]
        public async Task UpdateMovie_ShouldReturnOk_WhenMovieIsUpdatedSuccessfully()
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

            // Primeiro, crie o filme
            var jsonContent = JsonConvert.SerializeObject(validMovie);
            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
            var createResponse = await _httpClient.PostAsync("movies", content);
            var createdMovieResponse = JsonConvert.DeserializeObject<MovieResponseDTO>(await createResponse.Content.ReadAsStringAsync());

            // Atualizando o filme
            var updatedMovie = new MovieRequestDTO
            {
                Titulo = "Os Vingadores: Ultimato",
                Diretor = "Anthony e Joe Russo",
                AnoLancamento = 2019,
                Genero = new List<string> { "Ação", "Aventura" },
                Sinopse = "Os super-heróis se reúnem novamente para combater uma nova ameaça."
            };

            var updatedJsonContent = JsonConvert.SerializeObject(updatedMovie);
            var updatedContent = new StringContent(updatedJsonContent, Encoding.UTF8, "application/json");

            // Act
            var updateResponse = await _httpClient.PutAsync($"movies/{createdMovieResponse?.Id}", updatedContent);

            // Assert
            Assert.Equal(HttpStatusCode.NoContent, updateResponse.StatusCode);
        }

        /// <summary>
        /// Testa a exclusão de um filme.
        /// Espera um NoContent (204) se a exclusão for bem-sucedida.
        /// </summary>
        [Fact]
        public async Task DeleteMovie_ShouldReturnOk_WhenMovieIsDeletedSuccessfully()
        {
            // Arrange
            var validMovie = new MovieRequestDTO
            {
                Titulo = "O Rei Leão",
                Diretor = "Roger Allers, Rob Minkoff",
                AnoLancamento = 1994,
                Genero = new List<string> { "Animação", "Aventura", "Família" },
                Sinopse = "Um jovem leão, Simba, foge de casa após a morte de seu pai e retorna anos depois para reclamar seu lugar como rei."
            };

            // criando filme
            var jsonContent = JsonConvert.SerializeObject(validMovie);
            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
            var createResponse = await _httpClient.PostAsync("movies", content);
            var createdMovieResponse = JsonConvert.DeserializeObject<MovieResponseDTO>(await createResponse.Content.ReadAsStringAsync());

            // Act
            var deleteResponse = await _httpClient.DeleteAsync($"movies/{createdMovieResponse?.Id}");

            // Assert
            Assert.Equal(HttpStatusCode.NoContent, deleteResponse.StatusCode);
        }

        /// <summary>
        /// Testa a busca de filmes pelo título quando filmes são encontrados.
        /// Espera um Ok (200).
        /// </summary>
        [Fact]
        public async Task SearchByTitle_ShouldReturnOk_WhenMoviesFound()
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
            await _httpClient.PostAsync("movies", content);

            // Act
            var searchResponse = await _httpClient.GetAsync($"movies/search?title=Vingadores");

            // Assert
            Assert.Equal(HttpStatusCode.OK, searchResponse.StatusCode);
        }

        /// <summary>
        /// Testa a busca de filmes pelo título quando nenhum filme é encontrado.
        /// Espera um NotFound (404).
        /// </summary>
        [Fact]
        public async Task SearchByTitle_ShouldReturnNotFound_WhenNoMoviesFound()
        {
            // Act
            var searchResponse = await _httpClient.GetAsync($"movies/search?title=Inexistente");

            // Assert
            Assert.Equal(HttpStatusCode.NotFound, searchResponse.StatusCode);
        }
    }
}
