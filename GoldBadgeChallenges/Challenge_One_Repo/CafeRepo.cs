using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_One_Repo
{
    public class CafeRepo
    {
        private List<CafeContent> _menuItems = new List<CafeContent>();

        
        public void AddMenuItem(CafeContent content)
        {
            _menuItems.Add(content);
        }

        
        public List<CafeContent> GetCafeContents()
        {
            return _menuItems;
        }

        
        public bool UpdateMenuItem(int originalMealNumber, CafeContent newCafeContent)
        {
            CafeContent oldCafeContent = GetMenuByID(originalMealNumber);

            if (oldCafeContent != null)
            {
                oldCafeContent.MealNumber = newCafeContent.MealNumber;
                oldCafeContent.MealName = newCafeContent.MealName;
                oldCafeContent.Description = newCafeContent.Description;
                oldCafeContent.ListOfIngredients = newCafeContent.ListOfIngredients;
                oldCafeContent.Price = newCafeContent.Price;
                return true;
            }
            else
            {
                return false;
            }

            int initialCount = _menuItems.Count;
            _menuItems.Remove(oldCafeContent);

            if (initialCount > _menuItems.Count)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        
        public bool RemoveMenuItem(int mealNumber)
        {
            CafeContent cafeContent = GetMenuByID(mealNumber);

            if (cafeContent == null)
            {
                return false;
            }

            int initialCount = _menuItems.Count;
            _menuItems.Remove(cafeContent);

            if (initialCount > _menuItems.Count)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        
        public CafeContent GetMenuByID(int mealNumber)
        {
            foreach (CafeContent content in _menuItems)
            {
                if (content.MealNumber == mealNumber)
                {
                    return content;
                }
            }

            return null;
        }
    }
}
