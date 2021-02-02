using Challenge_One_Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_One_Console
{
    class ProgramUI
    {
        private CafeRepo _cafeRepo = new CafeRepo();
        private IngredientsRepo _iRepo = new IngredientsRepo();

        public void Run()
        {
            DefaultCafeListings();
            Menu();
        }

        public void Menu()
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                Console.WriteLine("Select option number:\n" +
                    "1. Add Meal\n" +
                    "2. Add Ingredient to a Meal\n" +
                    "3. Delete Meal\n" +
                    "4. Delete Ingredient from List\n" +
                    "5. View all Meals\n" +
                    "6. View all Available Ingredients\n" +
                    "7. Exit\n");

                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        AddMenuItem();
                        break;
                    case "2":
                        AddIngredientToMeal();
                        break;
                    case "3":
                        RemoveMenuItem();
                        break;
                    case "4":
                        RemoveIngredientFromList();
                        break;
                    case "5":
                        GetCafeContents();
                        break;
                    case "6":
                        GetIngredients();
                        break;
                    case "7":
                        Console.WriteLine("Thank you, good bye!");
                        keepRunning = false;
                        break;
                    default:
                        Console.WriteLine("Error, you did not follow instructions.");
                        break;
                }
                Console.WriteLine("Press any key to continue.");
                Console.ReadLine();
                Console.Clear();
            }
        }
        private void AddMenuItem()
        {
            Console.Clear();
            CafeContent newMeal = new CafeContent();

            Console.WriteLine("What is the meal number to be assigned:");
            string mealNumber = Console.ReadLine();
            newMeal.MealNumber = int.Parse(mealNumber);

            Console.WriteLine("What is the name of this meal:");
            newMeal.MealName = Console.ReadLine();

            Console.WriteLine("Description of the meal:");
            newMeal.Description = Console.ReadLine();

            Console.WriteLine("Price of Meal: (ex:14.99)");
            string price = Console.ReadLine();
            newMeal.Price = double.Parse(price);

            _cafeRepo.AddMenuItem(newMeal);
        }
        private void AddIngredientToMeal()
        {
                GetCafeContents();

                Console.WriteLine("\nEnter ID of meal you would like to add ingredient to:");
                string identAsInt = Console.ReadLine();
                int devID = Convert.ToInt32(identAsInt);
                CafeContent pulledID = _cafeRepo.GetMenuByID(devID);

            bool moreIngredients = true;
            while (moreIngredients == true)
            {
                GetIngredients();

                Console.WriteLine("What ingredient do you want to add to this meal:");
                string ingred = Console.ReadLine().Trim().ToLower();
                IngredientsContent pulledIngred = _iRepo.GetIngredientByName(ingred);

                pulledID.ListOfIngredients.Add(pulledIngred);

                Console.WriteLine("\nWould you like to add another ingredient?(yes/no)");
                string addAnother = Console.ReadLine().Trim().ToLower();
                if (addAnother == "yes")
                {
                    moreIngredients = true;
                }
                else
                {
                    moreIngredients = false;
                }
            }
        }
        private void RemoveMenuItem()
        {
            Console.Clear();
            GetCafeContents();
            Console.WriteLine("Which Meal would you like to remove:");
            string input = Console.ReadLine();
            int userInput = int.Parse(input);
            bool wasDeleted = _cafeRepo.RemoveMenuItem(userInput);
            if (wasDeleted == true)
            {
                Console.WriteLine("Menu Item was successfully deleted.");
            }
            else
            {
                Console.WriteLine("Error. try again.");
            }
        }
        private void RemoveIngredientFromList()
        {
            Console.Clear();
            GetIngredients();
            Console.WriteLine("Which ingredient would you like to remove:");
            string input = Console.ReadLine();
            bool wasDeleted = _iRepo.RemoveIngredient(input);
            if (wasDeleted == true)
            {
                Console.WriteLine("Ingredient was successfully deleted.");
            }
            else
            {
                Console.WriteLine("Error. try again.");
            }
        }
        private void GetCafeContents()
        {
            Console.Clear();
            List<CafeContent> listOfMenu = _cafeRepo.GetCafeContents();

            foreach (var menuItem in listOfMenu)
            {
                Console.WriteLine($"Number: {menuItem.MealNumber}\n" +
                    $"Name: {menuItem.MealName}\n" +
                    $"Description: {menuItem.Description}\n" +
                    $"Ingredients List:");
                foreach (var item in menuItem.ListOfIngredients)
                {
                    Console.WriteLine(item.IngredientName);
                }
                Console.WriteLine($"Price: ${menuItem.Price}\n");
            }

        }
        private void GetIngredients()
        {
            Console.Clear();
            List<IngredientsContent> listOfIngred = _iRepo.GetIngredients();

            foreach (var ingred in listOfIngred)
            {
                Console.WriteLine($"Name: {ingred.IngredientName}");
            }
        }

        private void GetIngredientByName()
        {
            Console.Clear();
            Console.WriteLine("Which ingredient are you looking for?");
            string value = Console.ReadLine();
            IngredientsContent content = _iRepo.GetIngredientByName(value);

            if (content != null)
            {
                Console.WriteLine($"Ingredient Name: {content.IngredientName}");
            }
            else
            {
                Console.WriteLine("Error.");
            }
        }



        private void DefaultCafeListings()
        {
            IngredientsContent bread = new IngredientsContent("bread");
            IngredientsContent cheese = new IngredientsContent("cheese");
            IngredientsContent butter = new IngredientsContent("butter");
            IngredientsContent ham = new IngredientsContent("ham");
            IngredientsContent turkey = new IngredientsContent("turkey");

            _iRepo.AddIngredient(bread);
            _iRepo.AddIngredient(cheese);
            _iRepo.AddIngredient(butter);
            _iRepo.AddIngredient(ham);
            _iRepo.AddIngredient(turkey);

            List<IngredientsContent> grilledCheeseList = new List<IngredientsContent>();
            grilledCheeseList.Add(bread);
            grilledCheeseList.Add(cheese);
            grilledCheeseList.Add(butter);

            List<IngredientsContent> hamSammichList = new List<IngredientsContent>();
            hamSammichList.Add(bread);
            hamSammichList.Add(cheese);
            hamSammichList.Add(ham);

            List<IngredientsContent> turkeyHamList = new List<IngredientsContent>();
            turkeyHamList.Add(bread);
            turkeyHamList.Add(cheese);
            turkeyHamList.Add(ham);
            turkeyHamList.Add(turkey);

            CafeContent grilledCheese = new CafeContent(1,"Grilled Cheese Sandwich", "Four pieces of cheeses of choice melted inbetween two slices of bread of choice",grilledCheeseList,5.99);
            CafeContent hamSammich = new CafeContent(2, "Ham and Cheese Sandwich", " Ten slices of ham and three slices of melted cheese of choice inbetween two slices of bread of choice.", hamSammichList, 7.99);
            CafeContent turkeyHam = new CafeContent(3, "Turkey Ham and Cheese Sandwich", "Six slices of turkey, six slices of ham, and four slices of melted cheese of choice inbetween two slices of bread of choice.", turkeyHamList, 9.99);

            _cafeRepo.AddMenuItem(grilledCheese);
            _cafeRepo.AddMenuItem(hamSammich);
            _cafeRepo.AddMenuItem(turkeyHam);
        }
    }
}
