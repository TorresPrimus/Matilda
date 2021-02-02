using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_One_Repo
{
    public class IngredientsRepo
    {

        private List<IngredientsContent> _listOfIngredients = new List<IngredientsContent>();

        
        public void AddIngredient(IngredientsContent content)
        {
            _listOfIngredients.Add(content);
        }

        
        public List<IngredientsContent> GetIngredients()
        {
            return _listOfIngredients;
        }

        
        public bool UpdateIngredient(string originalIngredient, IngredientsContent newIngredient)
        {
            IngredientsContent oldIngredient = GetIngredientByName(originalIngredient);

            if (oldIngredient != null)
            {
                oldIngredient.IngredientName = newIngredient.IngredientName;
                return true;
            }
            else
            {
                return false;
            }

            int initialCount = _listOfIngredients.Count;
            _listOfIngredients.Remove(oldIngredient);

            if (initialCount > _listOfIngredients.Count)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        
        public bool RemoveIngredient(string ingredientName)
        {
            IngredientsContent ingredient = GetIngredientByName(ingredientName);

            if (ingredient == null)
            {
                return false;
            }

            int initialCount = _listOfIngredients.Count;
            _listOfIngredients.Remove(ingredient);

            if (initialCount > _listOfIngredients.Count)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        
        public IngredientsContent GetIngredientByName(string ingredientName)
        {
            foreach (IngredientsContent content in _listOfIngredients)
            {
                if (content.IngredientName == ingredientName)
                {
                    return content;
                }
            }

            return null;
        }
    }
}
