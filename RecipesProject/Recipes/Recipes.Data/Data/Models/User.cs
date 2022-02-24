using System.ComponentModel.DataAnnotations;

namespace Recipes.Data.Data.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(DataConstants.UsernameMaxLength)]
        public string Username { get; set; }

        [Required]
        [MaxLength(DataConstants.PasswordMaxLength)]
        public string Password { get; set; }

        [Required]
        [MaxLength(DataConstants.EmailMaxLength)]
        public string Email { get; set; }

        public ICollection<Recipe> Recipes { get; set; } = new List<Recipe>();
    }
}
