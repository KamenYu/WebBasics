using Recipes.Data.Data.Enums;
using System.ComponentModel.DataAnnotations;

namespace Recipes.Data.Data.Models
{
    public class Category
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();

        [Required]
        public CategoryType Type { get; set; }

        public ICollection<CategoryRecipe> CategoryRecipes { get; set; } = new List<CategoryRecipe>();
    }
}
