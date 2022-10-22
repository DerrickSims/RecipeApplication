using Microsoft.AspNetCore.Mvc;
using RecipeApplication.DataAccess;
using RecipeApplication.DataAccess.Model;
using RecipeApplication.Models;

namespace RecipeApplication.Controllers
{
    public class RecipeController : Controller
    {
        

        private readonly RecipeDbContext _dbContext;

        public RecipeController(RecipeDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            RecipeViewModel model = new RecipeViewModel(_dbContext);
            return View(model);
        }

        [HttpPost]
        public IActionResult Index(int recipeId, string recipeName, string mealType, string mainIngredient, byte prepTime)
        {
            RecipeViewModel model = new RecipeViewModel(_dbContext);

            RecipeModel recipes = new(recipeId, recipeName, mealType, mainIngredient, prepTime);

            model.SaveRecipe(recipes);
            model.IsActionSuccess = true;
            model.ActionMessage = "Recipe has been saved successfully";

            return View(model);
        }

        public IActionResult Update(int id)
        {
            RecipeViewModel model = new(_dbContext, id);

            return View(model);
        }

        public IActionResult Delete(int id)
        {
            RecipeViewModel model = new(_dbContext);

            if (id > 0)
            {
                model.RemoveRecipe(id);
                model.IsActionSuccess = true;
                model.ActionMessage = "Recipe has been deleted successfully";
            }

            return View("Index", model);
        }
    }
}
