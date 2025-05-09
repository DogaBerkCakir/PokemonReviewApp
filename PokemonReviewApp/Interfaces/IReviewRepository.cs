using PokemonReviewApp.Models;

namespace PokemonReviewApp.Interfaces
{
    public interface IReviewRepository
    {
        ICollection<Review> GetReviews();
        Review GetReview(int ReviewId);
        ICollection<Review> GetReviewsOfPokemon(int pokemonId);
        bool ReviewExists(int ReviewId);
        bool CreateReview(Review review);
        bool UpdateReview(Review review);
        bool Save();


    }
}
