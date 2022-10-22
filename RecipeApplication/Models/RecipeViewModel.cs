using RecipeApplication.DataAccess;
using RecipeApplication.DataAccess.Model;
using RecipeApplication.DataAccess.Repositories;

namespace RecipeApplication.Models
{
    public class RecipeViewModel
    {
        private readonly Repository _db;

        public List<RecipeModel> RecipeList { get; set; }

        public RecipeModel CurrentMyRecipe { get; set; }

        public bool IsActionSuccess { get; set; }

        public string ActionMessage { get; set; }

        public RecipeViewModel(RecipeDbContext dbContext)
        {
            _db = new Repository(dbContext);
            RecipeList = GetAllRecipes();
            CurrentMyRecipe = RecipeList.FirstOrDefault()!;
        }

        public RecipeViewModel(RecipeDbContext dbContext, int recipeId)
        {
            _db = new Repository(dbContext);
            RecipeList = GetAllRecipes();

            if (recipeId > 0)
            {
                CurrentMyRecipe = GetMyRecipe(recipeId);
            }
             else
             {
                CurrentMyRecipe = new RecipeModel();
             }
        }

        public void SaveRecipe(RecipeModel recipes)
        {
            if (recipes.RecipeID > 0)
            {
                _db.Update(recipes);
            }
            else
            {
                recipes.RecipeID = _db.Create(recipes);
            }
        }

        public void RemoveRecipe(int recipID)
        {
            _db.Delete(recipID);
            RecipeList = GetAllRecipes();
            CurrentMyRecipe = RecipeList.FirstOrDefault()!;
}

        public List<RecipeModel> GetAllRecipes()
        {
            return _db.GetAllRecipeModels();
        }

        public RecipeModel GetMyRecipe(int recipeId)
        {
            return _db.GetRecipeByID(recipeId);
        }

    }
}
