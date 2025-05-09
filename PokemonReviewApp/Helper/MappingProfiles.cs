using AutoMapper;

namespace PokemonReviewApp.Helper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Models.Pokemon, Dto.PokemonDto>();
            CreateMap<Models.Category, Dto.CategoryDto>();
            CreateMap<Models.Country, Dto.CountryDto>();
            CreateMap<Models.Owner, Dto.OwnerDto>();
            CreateMap<Models.Review, Dto.ReviewDto>();
            CreateMap<Models.Reviewer, Dto.ReviewerDto>();
        }
    }
}
