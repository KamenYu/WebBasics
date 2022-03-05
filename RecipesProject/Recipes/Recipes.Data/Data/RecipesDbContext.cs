using Microsoft.EntityFrameworkCore;

using Recipes.Data.Data.Models;

namespace Recipes.Data.Data
{
    public class RecipesDbContext : DbContext
    {
        public RecipesDbContext()
        {

        }

        public DbSet<Recipe> Recipes { get; init; }
        public DbSet<Category> Categories { get; init; }
        public DbSet<CategoryRecipe> CategoryRecipes { get; init; }
        public DbSet<Ingredient> Ingredients { get; init; }
        public DbSet<Rating> Ratings { get; init; }
        public DbSet<User> Users { get; init; }

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
            // cascade to restrict to all entities

            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }

            modelBuilder.Entity<CategoryRecipe>()
                .HasKey(k => new { k.CategoryId, k.RecipeId });

            base.OnModelCreating(modelBuilder);
        }
    }
}
