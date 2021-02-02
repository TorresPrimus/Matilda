using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_One_Repo
{
    public class CafeContent
    {
        public int MealNumber { get; set; }
        public string MealName { get; set; }
        public string Description { get; set; }
        public List<IngredientsContent> ListOfIngredients { get; set; }
        public double Price { get; set; }

        public CafeContent() { }

        public CafeContent(int mealNumber, string mealName, string description, List<IngredientsContent> listOfIngredients, double price)
        {
            MealNumber = mealNumber;
            MealName = mealName;
            Description = description;
            ListOfIngredients = listOfIngredients;
            Price = price;
        }
    }
}
