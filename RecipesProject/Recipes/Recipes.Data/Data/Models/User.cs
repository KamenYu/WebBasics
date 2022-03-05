using System.ComponentModel.DataAnnotations;

namespace Recipes.Data.Data.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(DataConstants.User.UsernameMaxLength)]
        public string Username { get; set; }

        [Required]
        [MaxLength(DataConstants.User.PasswordMaxLength)]
        public string Password { get; set; }

        [Required]
        [MaxLength(DataConstants.User.EmailMaxLength)]
        public string Email { get; set; }

        public ICollection<Recipe> Recipes { get; set; } = new List<Recipe>();

        public ICollection<Rating> Ratings { get; set; } = new List<Rating>();
    }
}
