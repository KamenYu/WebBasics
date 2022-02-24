namespace Recipes.Data.Data.Models
{
    public class Rating
    {
        public int Id { get; set; }

        public int Amount { get; set; }

        public string RecipeId { get; set; }

        public Recipe Recipe { get; set; }
        public int UserId { get; set; }

        //public User User { get; set; }
    }
}
