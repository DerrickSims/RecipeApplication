using Microsoft.EntityFrameworkCore;
using RecipeApplication.DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeApplication.DataAccess
{
    public class RecipeDbContext : DbContext
    {
        public RecipeDbContext()
        {

        }
        public RecipeDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<RecipeModel> Recipes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RecipeModel>(
                entity =>
                {
                    entity.HasKey(p => p.RecipeID);

                    entity.Property(e => e.RecipeID);

                    entity.Property(e => e.RecipeName).IsRequired(required: false);


                    entity.Property(e => e.MealType).IsRequired(required: false);



                    entity.Property(e => e.MainIngredient).IsRequired(required: false);



                    entity.Property(e => e.PrepTime);
                    
                 
                });
        }
    }
}
