using PokemonReviewApp.Models;

namespace PokemonReviewApp.Interfaces
{
    public interface ICountryRepository
    {
        ICollection<Country> GetCountries();
        Country GetCountry(int countryId);
        bool CountryExists(int countryId);
        ICollection<Owner> GetOwnersFromCountry(int countryId);

    }
}
