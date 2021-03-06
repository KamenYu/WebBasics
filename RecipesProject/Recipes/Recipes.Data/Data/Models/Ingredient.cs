using System.ComponentModel.DataAnnotations;

namespace Recipes.Data.Data.Models
{
    public class Ingredient
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(DataConstants.Ingredient.NameMaxLength)]
        public string Name { get; set; } // Rice

        public short? Quantity { get; set; } // 2

        [MaxLength(DataConstants.Ingredient.MetricValueMaxLength)]
        public string? MetricValue { get; set; } // cups

        [MaxLength(DataConstants.Ingredient.ExtraInformationMaxLength)]
        public string? ExtraInformation { get; set; } // rinced thoroughly

        public string RecipeId { get; set; }

        public Recipe Recipe { get; set; }
    }
}
