using Xunit;
using MongoDB.Driver;
using Data;
using Models;
using Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tests.Integration
{
    public class MovieRepositoryIntegrationTests
    {
        private MovieRepository _movieRepository;
        private MongoDbFactory _mongoDbFactory;

        public MovieRepositoryIntegrationTests()
        {
            var mongoDbSettings = new MongoDbSettings
            {
                ConnectionString = "mongodb+srv://lais_db:mongo552258@clusterdatabase.mn5ft.mongodb.net/?retryWrites=true&w=majority&appName=ClusterDatabase",
                DatabaseName = "movixBD",
                CollectionName = "movies"
            };

            _mongoDbFactory = new MongoDbFactory(mongoDbSettings);
            _movieRepository = new MovieRepository(_mongoDbFactory, mongoDbSettings);
        }

        [Fact]
        public async Task CreateMovie_InsertsMovieIntoDatabase()
        {
            // Arrange
            var movie = new MovieModel
            {
                Titulo = "O Senhor dos Anéis: A Sociedade do Anel",
                Diretor = "Peter Jackson",
                AnoLancamento = 2001,
                Genero = new List<string> { "Ação", "Aventura", "Fantasia" },
                Sinopse = "Um hobbit chamado Frodo Bolseiro é encarregado de destruir um poderoso anel."
            };

            // Act
            await _movieRepository.CreateAsync(movie);

            // Assert
            var insertedMovie = await _movieRepository.GetByIdAsync(movie.Id.ToString());
            Assert.NotNull(insertedMovie);
            Assert.Equal(movie.Titulo, insertedMovie.Titulo);
            Assert.Equal(movie.Diretor, insertedMovie.Diretor);
            Assert.Equal(movie.AnoLancamento, insertedMovie.AnoLancamento);
            Assert.Equal(movie.Genero, insertedMovie.Genero);
            Assert.Equal(movie.Sinopse, insertedMovie.Sinopse);
        }

        [Fact]
        public async Task GetMoviesByYear_ReturnsMoviesForGivenYear()
        {
            // Arrange
            var year = 2001; 
            var movie = new MovieModel
            {
                Titulo = "Harry Potter e a Pedra Filosofal",
                Diretor = "Chris Columbus",
                AnoLancamento = year,
                Genero = new List<string> { "Aventura", "Fantasia" },
                Sinopse = "Um menino descobre que é um bruxo e vai para uma escola de magia."
            };

            // Inserir o filme no banco de dados
            await _movieRepository.CreateAsync(movie);

            // Act
            var movies = await _movieRepository.GetMoviesByYearAsync(year);

            // Assert
            Assert.NotNull(movies);
            Assert.NotEmpty(movies);
            Assert.All(movies, m => Assert.Equal(year, m.AnoLancamento));
        }
    }
}
