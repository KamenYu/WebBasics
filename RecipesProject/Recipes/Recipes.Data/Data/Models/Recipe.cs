using System.ComponentModel.DataAnnotations;

namespace Recipes.Data.Data.Models
{
    public class Recipe
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();

        [Required]
        [MaxLength(DataConstants.Recipe.NameMaxLength)]
        public string Name { get; set; }

        [MaxLength(DataConstants.Recipe.UmageUrlMaxLength)]
        public string? ImageUrl { get; set; }

        [MaxLength(DataConstants.Recipe.TimeMaxLength)]
        public string? PreparationTime { get; set; }

        [MaxLength(DataConstants.Recipe.TimeMaxLength)]
        public string? CookTime { get; set; }

        [Required]
        [MaxLength(DataConstants.Recipe.DirectionsMaxLength)]
        public string Directions { get; set; }

        public int UserId { get; set; }

        public User User { get; set; }

        public ICollection<Rating> Ratigns { get; set; } = new List<Rating>();

        public ICollection<Ingredient> Ingredients { get; set; } = new List<Ingredient>();

        public ICollection<CategoryRecipe> CategoryRecipes { get; set; } = new List<CategoryRecipe>();
    }
}
