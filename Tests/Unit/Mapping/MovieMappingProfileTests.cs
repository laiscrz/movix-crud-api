using AutoMapper;
using DTOs;
using Mapping;
using Models;
using MongoDB.Bson;
using Xunit;

namespace Tests.Unit
{
    public class MovieMappingProfileUnitTests
    {
        private readonly IMapper _mapper;

        public MovieMappingProfileUnitTests()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MovieMappingProfile>();
            });
            _mapper = config.CreateMapper();
        }

        [Fact]
        public void ShouldMap_MovieRequestDTO_ToMovieModel()
        {
            // Arrange
            var movieRequest = new MovieRequestDTO
            {
                Titulo = "Trem-Bala",
                Diretor = "David Leitch",
                AnoLancamento = 2022,
                Genero = new List<string> { "Ação", "Suspense" },
                Sinopse = "Um grupo de assassinos se encontra em um trem-bala em movimento, com consequências mortais."
            };

            // Act
            var movieModel = _mapper.Map<MovieModel>(movieRequest);

            // Assert
            Assert.NotNull(movieModel);
            Assert.Equal(movieRequest.Titulo, movieModel.Titulo);
            Assert.Equal(movieRequest.Diretor, movieModel.Diretor);
            Assert.Equal(movieRequest.AnoLancamento, movieModel.AnoLancamento);
            Assert.Equal(movieRequest.Genero, movieModel.Genero);
            Assert.Equal(movieRequest.Sinopse, movieModel.Sinopse);
        }

        [Fact]
        public void ShouldMap_MovieModel_ToMovieResponseDTO()
        {
            // Arrange
            var movieModel = new MovieModel
            {
                Id = ObjectId.GenerateNewId(), 
                Titulo = "Transformers: O Despertar das Feras",
                Diretor = "Steven Caple Jr.",
                AnoLancamento = 2023,
                Genero = new List<string> { "Ação", "Ficção Científica" },
                Sinopse = "Os Autobots e Decepticons se unem a um novo grupo de Transformers para salvar a Terra."
            };

            // Act
            var movieResponse = _mapper.Map<MovieResponseDTO>(movieModel);

            // Assert
            Assert.NotNull(movieResponse);
            Assert.Equal(movieModel.Titulo, movieResponse.Titulo);
            Assert.Equal(movieModel.Diretor, movieResponse.Diretor);
            Assert.Equal(movieModel.AnoLancamento, movieResponse.AnoLancamento);
            Assert.Equal(movieModel.Genero, movieResponse.Genero);
            Assert.Equal(movieModel.Sinopse, movieResponse.Sinopse);
            Assert.Equal(movieModel.Id.ToString(), movieResponse.Id); 
        }
    }
}

