using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recipes.Data.Data.Models
{
    public class CategoryRecipe
    {
        public string CategoryId { get; set; }
        public Category Category { get; set; }
        public string RecipeId { get; set; }
        public Recipe Recipe { get; set; }
    }
}
