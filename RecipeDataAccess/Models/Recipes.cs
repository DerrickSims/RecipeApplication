using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeDataAccess.Models
{
    public class Recipes
    {
        public int RecipeId { get; set; }

        public string RecipeName { get; set; }

        public string MealType { get; set; }

        public string MainIngredients { get; set; }

        public int PrepTime { get; set; }

        public Recipes(int recipeId, string recipeName, string mealType, string mainIngredients, int prepTime)
        {
            RecipeId = recipeId;
            RecipeName = recipeName;
            MealType = mealType;
            MainIngredients = mainIngredients;
            PrepTime = prepTime;
        }

        public Recipes()
        {

        }
    }
}
