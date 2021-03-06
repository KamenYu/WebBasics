// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Recipes.Data.Data;

#nullable disable

namespace Recipes.Data.Migrations
{
    [DbContext(typeof(RecipesDbContext))]
    partial class RecipesDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Recipes.Data.Data.Models.Category", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("Recipes.Data.Data.Models.CategoryRecipe", b =>
                {
                    b.Property<string>("CategoryId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RecipeId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("CategoryId", "RecipeId");

                    b.HasIndex("RecipeId");

                    b.ToTable("CategoryRecipes");
                });

            modelBuilder.Entity("Recipes.Data.Data.Models.Ingredient", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ExtraInformation")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("MetricValue")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<short?>("Quantity")
                        .HasColumnType("smallint");

                    b.Property<string>("RecipeId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RecipeId");

                    b.ToTable("Ingredients");
                });

            modelBuilder.Entity("Recipes.Data.Data.Models.Rating", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("Amount")
                        .HasColumnType("int");

                    b.Property<string>("RecipeId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RecipeId");

                    b.HasIndex("UserId");

                    b.ToTable("Ratings");
                });

            modelBuilder.Entity("Recipes.Data.Data.Models.Recipe", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("CookTime")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Directions")
                        .IsRequired()
                        .HasMaxLength(4000)
                        .HasColumnType("nvarchar(4000)");

                    b.Property<string>("ImageUrl")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("PreparationTime")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Recipes");
                });

            modelBuilder.Entity("Recipes.Data.Data.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(220)
                        .HasColumnType("nvarchar(220)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(75)
                        .HasColumnType("nvarchar(75)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Recipes.Data.Data.Models.CategoryRecipe", b =>
                {
                    b.HasOne("Recipes.Data.Data.Models.Category", "Category")
                        .WithMany("CategoryRecipes")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Recipes.Data.Data.Models.Recipe", "Recipe")
                        .WithMany("CategoryRecipes")
                        .HasForeignKey("RecipeId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("Recipe");
                });

            modelBuilder.Entity("Recipes.Data.Data.Models.Ingredient", b =>
                {
                    b.HasOne("Recipes.Data.Data.Models.Recipe", "Recipe")
                        .WithMany("Ingredients")
                        .HasForeignKey("RecipeId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Recipe");
                });

            modelBuilder.Entity("Recipes.Data.Data.Models.Rating", b =>
                {
                    b.HasOne("Recipes.Data.Data.Models.Recipe", "Recipe")
                        .WithMany("Ratigns")
                        .HasForeignKey("RecipeId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Recipes.Data.Data.Models.User", "User")
                        .WithMany("Ratings")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Recipe");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Recipes.Data.Data.Models.Recipe", b =>
                {
                    b.HasOne("Recipes.Data.Data.Models.User", "User")
                        .WithMany("Recipes")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Recipes.Data.Data.Models.Category", b =>
                {
                    b.Navigation("CategoryRecipes");
                });

            modelBuilder.Entity("Recipes.Data.Data.Models.Recipe", b =>
                {
                    b.Navigation("CategoryRecipes");

                    b.Navigation("Ingredients");

                    b.Navigation("Ratigns");
                });

            modelBuilder.Entity("Recipes.Data.Data.Models.User", b =>
                {
                    b.Navigation("Ratings");

                    b.Navigation("Recipes");
                });
#pragma warning restore 612, 618
        }
    }
}
