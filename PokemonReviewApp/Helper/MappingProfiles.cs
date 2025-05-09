using AutoMapper;

namespace PokemonReviewApp.Helper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Dto.PokemonDto, Models.Pokemon>();
            CreateMap<Models.Pokemon, Dto.PokemonDto>();
            
            CreateMap<Dto.CategoryDto, Models.Category>();
            CreateMap<Models.Category, Dto.CategoryDto>();
            
            CreateMap<Dto.CountryDto,Models.Country>();
            CreateMap<Models.Country, Dto.CountryDto>();
            
            CreateMap<Dto.OwnerDto, Models.Owner>();
            CreateMap<Models.Owner, Dto.OwnerDto>();


            CreateMap<Dto.ReviewerDto, Models.Reviewer>();
            CreateMap<Models.Reviewer, Dto.ReviewerDto>();


            CreateMap<Dto.ReviewDto, Models.Review>();
            CreateMap<Models.Review, Dto.ReviewDto>();

        }
    }
}
