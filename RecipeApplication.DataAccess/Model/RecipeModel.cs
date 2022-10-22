using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeApplication.DataAccess.Model
{
    public class RecipeModel
    {
        public int RecipeID { get; set; } 

        public string RecipeName { get; set; }

        public string MealType { get; set; }

        public string MainIngredient { get; set; }

        public byte PrepTime { get; set; }

        public RecipeModel(int recipeId, string recipeName, string mealType, string mainIngredient, byte prepTime)
        {
            RecipeID = recipeId;
            RecipeName = recipeName;
            MealType = mealType;
            MainIngredient = mainIngredient;
            PrepTime = prepTime;
        }

        public RecipeModel()
        {

        }
    }
}
