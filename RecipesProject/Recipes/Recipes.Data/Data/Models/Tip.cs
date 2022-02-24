using System.ComponentModel.DataAnnotations;

namespace Recipes.Data.Data.Models
{
    public class Tip
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(DataConstants.DescriptionMaxLength)]
        public string Description { get; set; }

        public string RecipeId { get; set; }

        public Recipe Recipe { get; set; }
    }
}
