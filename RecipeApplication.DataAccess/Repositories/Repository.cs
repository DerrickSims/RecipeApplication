using RecipeApplication.DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeApplication.DataAccess.Repositories
{
    public class Repository
    {
        private RecipeDbContext _dbContext;
        public Repository(RecipeDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public int Create(RecipeModel recipe)
        {
            _dbContext.Add(recipe);
            _dbContext.SaveChanges();

            return recipe.RecipeID;
        }


        public int Update(RecipeModel recipe)
        {
            RecipeModel existingRecipe = _dbContext.Recipes.Find(recipe.RecipeID)!;

            existingRecipe.RecipeName = recipe.RecipeName;
            existingRecipe.MealType = recipe.MealType;
            existingRecipe.MainIngredient = recipe.MainIngredient;
            existingRecipe.PrepTime = recipe.PrepTime;

            _dbContext.SaveChanges();
            return existingRecipe.RecipeID;

        }

        public bool Delete(int recipeID)
        {
            RecipeModel recipe = _dbContext.Recipes.Find(recipeID)!;
            _dbContext.Remove(recipe);

            _dbContext.SaveChanges();
            return true;
        }

        public List<RecipeModel> GetAllRecipeModels()
        {
            List<RecipeModel> recipeList = _dbContext.Recipes.ToList();
            return recipeList;
        }

        public RecipeModel GetRecipeByID(int recipeID)
        {
            RecipeModel recipe = _dbContext.Recipes.Find(recipeID)!;
            return recipe;
        }
    }
}
