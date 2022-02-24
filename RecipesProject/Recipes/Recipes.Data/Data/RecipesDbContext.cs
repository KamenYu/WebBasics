using Microsoft.EntityFrameworkCore;

using Recipes.Data.Data.Models;

namespace Recipes.Data.Data
{
    public class RecipesDbContext : DbContext
    {
        public RecipesDbContext()
        {

        }

        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<CategoryRecipe> CategoryRecipes { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<Rating> Ratings { get; set; }
        public DbSet<Tip> Tips { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if(optionsBuilder.IsConfigured == false)
            {
                optionsBuilder.UseSqlServer(DatabaseConfiguration.ConnectionString);
            }

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CategoryRecipe>()
                .HasKey(k => new { k.CategoryId, k.RecipeId });

            base.OnModelCreating(modelBuilder);
        }
    }
}
