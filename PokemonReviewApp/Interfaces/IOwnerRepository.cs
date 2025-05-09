using PokemonReviewApp.Models;

namespace PokemonReviewApp.Interfaces
{
    public interface IOwnerRepository
    {
        ICollection<Owner> GetOwners();
        Owner GetOwner(int ownerId);
        ICollection<Owner> GetOwnerOfPokemon(int pokemonId);
        ICollection<Pokemon> GetPokemonOfAOwner(int ownerId);
        bool OwnerExists(int ownerId);

    }
}
