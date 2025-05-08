using AutoMapper;

namespace PokemonReviewApp.Helper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Models.Pokemon, Dto.PokemonDto>();
            CreateMap<Models.Category, Dto.CategoryDto>();
        }
    }
}
