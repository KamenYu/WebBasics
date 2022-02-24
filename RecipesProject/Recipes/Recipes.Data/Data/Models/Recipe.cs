using System.ComponentModel.DataAnnotations;

namespace Recipes.Data.Data.Models
{
    public class Recipe
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();

        [Required]
        [MaxLength(DataConstants.RecipeNameMaxLength)]
        public string Name { get; set; }

        [MaxLength(DataConstants.UmageUrlMaxLength)]
        public string? ImageUrl { get; set; }

        [MaxLength(DataConstants.TimeMaxLength)]
        public string? PreparationTime { get; set; }

        [MaxLength(DataConstants.TimeMaxLength)]
        public string? CookTime { get; set; }

        [Required]
        [MaxLength(DataConstants.TimeMaxLength)]
        public string TotalTime { get; set; }

        [Required]
        [MaxLength(DataConstants.DirectionsMaxLength)]
        public string Directions { get; set; }

        public ICollection<Rating> Ratigns { get; set; } = new List<Rating>();

        public ICollection<Tip> Tips { get; set; } = new List<Tip>();

        public ICollection<Ingredient> Ingredients { get; set; } = new List<Ingredient>();

        public ICollection<CategoryRecipe> CategoryRecipes { get; set; } = new List<CategoryRecipe>();
    }
}
