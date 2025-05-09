using PokemonReviewApp.Models;

namespace PokemonReviewApp.Interfaces
{
    public interface ICountryRepository
    {
        ICollection<Country> GetCountries();
        Country GetCountry(int countryId);
        Country GetCountryByOwner(int ownerId);
        bool CountryExists(int countryId);
        ICollection<Owner> GetOwnersFromCountry(int countryId);

    }
}
