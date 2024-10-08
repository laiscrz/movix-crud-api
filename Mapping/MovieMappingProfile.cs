using AutoMapper;
using DTOs;
using Models;

namespace Mapping
{
    /// <summary>
    /// Configuração de mapeamento para objetos relacionados a filmes.
    /// </summary>
    public class MovieMappingProfile : Profile
    {
        /// <summary>
        /// Inicializa uma nova instância de <see cref="MovieMappingProfile"/> com configurações de mapeamento.
        /// </summary>
        public MovieMappingProfile()
        {
            // Mapeia MovieRequestDTO para MovieModel
            CreateMap<MovieRequestDTO, MovieModel>();

            // Mapeia MovieModel para MovieResponseDTO, convertendo Id para string
            CreateMap<MovieModel, MovieResponseDTO>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id.ToString()));
        }
    }
}
