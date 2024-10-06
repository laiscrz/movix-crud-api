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
    public class MovieRepositoryTests
    {
        private MovieRepository _movieRepository;
        private MongoDbFactory _mongoDbFactory;

        public MovieRepositoryTests()
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

            await _movieRepository.CreateAsync(movie);

            // Act
            var movies = await _movieRepository.GetMoviesByYearAsync(year);

            // Assert
            Assert.NotNull(movies);
            Assert.NotEmpty(movies);
            Assert.All(movies, m => Assert.Equal(year, m.AnoLancamento));
        }

        [Fact]
        public async Task GetByIdAsync_ReturnsMovieForGivenId()
        {
            // Arrange
            var movie = new MovieModel
            {
                Titulo = "A Era do Gelo",
                Diretor = "Chris Wedge",
                AnoLancamento = 2002,
                Genero = new List<string> { "Animação", "Aventura", "Comédia" },
                Sinopse = "Um grupo de animais pré-históricos se junta para devolver um bebê humano à sua família."
            };

            await _movieRepository.CreateAsync(movie);

            // Act
            var retrievedMovie = await _movieRepository.GetByIdAsync(movie.Id.ToString());

            // Assert
            Assert.NotNull(retrievedMovie);
            Assert.Equal(movie.Titulo, retrievedMovie.Titulo);
            Assert.Equal(movie.Diretor, retrievedMovie.Diretor);
            Assert.Equal(movie.AnoLancamento, retrievedMovie.AnoLancamento);
            Assert.Equal(movie.Genero, retrievedMovie.Genero);
            Assert.Equal(movie.Sinopse, retrievedMovie.Sinopse);
        }

        [Fact]
        public async Task UpdateAsync_UpdatesExistingMovie()
        {
            // Arrange
            var movie = new MovieModel
            {
                Titulo = "Alvin e os Esquilos",
                Diretor = "Tim Hill",
                AnoLancamento = 2007,
                Genero = new List<string> { "Comédia", "Família", "Animação" },
                Sinopse = "Três esquilos cantores se envolvem em uma série de aventuras com seu novo tutor."
            };

            await _movieRepository.CreateAsync(movie);

            // Atualiza o título do filme
            var updatedMovie = new MovieModel
            {
                Id = movie.Id,
                Titulo = "Alvin e os Esquilos: A Nova Aventura",
                Diretor = movie.Diretor,
                AnoLancamento = movie.AnoLancamento,
                Genero = movie.Genero,
                Sinopse = movie.Sinopse
            };

            // Act
            await _movieRepository.UpdateAsync(movie.Id.ToString(), updatedMovie);

            // Assert
            var retrievedMovie = await _movieRepository.GetByIdAsync(movie.Id.ToString());
            Assert.NotNull(retrievedMovie);
            Assert.Equal(updatedMovie.Titulo, retrievedMovie.Titulo);
        }


        [Fact]
        public async Task DeleteAsync_RemovesMovieFromDatabase()
        {
            // Arrange
            var movie = new MovieModel
            {
                Titulo = "Matrix",
                Diretor = "Lana Wachowski, Lilly Wachowski",
                AnoLancamento = 1999,
                Genero = new List<string> { "Ação", "Ficção Científica" },
                Sinopse = "Um programador descobre a verdade sobre sua realidade."
            };

            await _movieRepository.CreateAsync(movie);

            // Act
            await _movieRepository.DeleteAsync(movie.Id.ToString());

            // Assert
            var deletedMovie = await _movieRepository.GetByIdAsync(movie.Id.ToString());
            Assert.Null(deletedMovie);
        }

        [Fact]
        public async Task GetMoviesByTitleAsync_ReturnsMoviesForGivenTitle()
        {
            // Arrange
            var movie1 = new MovieModel
            {
                Titulo = "Orgulho e Preconceito",
                Diretor = "Joe Wright",
                AnoLancamento = 2005,
                Genero = new List<string> { "Romance", "Drama" },
                Sinopse = "A história de amor entre Elizabeth Bennet e Mr. Darcy."
            };

            var movie2 = new MovieModel
            {
                Titulo = "Orgulho e Preconceito e Zumbis",
                Diretor = "Burr Steers",
                AnoLancamento = 2016,
                Genero = new List<string> { "Ação", "Comédia", "Terror" },
                Sinopse = "Uma versão adaptada do romance clássico que envolve zumbis."
            };

            await _movieRepository.CreateAsync(movie1);
            await _movieRepository.CreateAsync(movie2);

            // Act
            var movies = await _movieRepository.GetMoviesByTitleAsync("Orgulho e Preconceito");

            // Assert
            Assert.NotNull(movies);
            Assert.NotEmpty(movies);
            Assert.Equal(2, movies.Count()); 
            Assert.All(movies, m => Assert.Contains("Orgulho e Preconceito", m.Titulo));
        }

    }


}
