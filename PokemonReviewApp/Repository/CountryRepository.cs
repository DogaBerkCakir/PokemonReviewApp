using PokemonReviewApp.Interfaces;
using PokemonReviewApp.Models;

namespace PokemonReviewApp.Repository
{
    public class CountryRepository : ICountryRepository
    {
        public ICollection<Country> GetCountries()
        {
            throw new NotImplementedException();
        }
        public Country GetCountry(int countryId)
        {
            throw new NotImplementedException();
        }
        public bool CountryExists(int countryId)
        {
            throw new NotImplementedException();
        }
        public ICollection<Owner> GetOwnersFromCountry(int countryId)
        {
            throw new NotImplementedException();
        }
    }
    
    
}
