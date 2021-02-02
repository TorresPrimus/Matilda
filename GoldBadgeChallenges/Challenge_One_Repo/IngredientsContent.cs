using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_One_Repo
{
    public class IngredientsContent
    {
        public string IngredientName { get; set; }

        public IngredientsContent() { }

        public IngredientsContent(string ingredientName)
        {
            IngredientName = ingredientName;
        }
    }
}
