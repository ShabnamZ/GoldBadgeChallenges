using _01_CafeRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Console
{
    public class CafeUI
    {
        private MenuRepository _itemRepo = new MenuRepository();
        private object _listOfItems;

        public void Run()
        {

            SeedItemList();
            RunMenu();
        }

        private void RunMenu()
        {
            bool continueToRunMenu = true;

            while (continueToRunMenu)
            {
                Console.Clear();
                Console.WriteLine("Welcome to Komodo Cafe. What would you like to order?\n" +
                    "1. List all items on cafe's menu\n" +
                    "2. Find item by ingredients.\n" +
                    "3. Find item by item ID.\n"+
                    "4. Add new item to cafe menu.\n" +
                    "5. Remove a menu item.\n" +
                    "6. Exit.");

                string userInput = Console.ReadLine();
                switch (userInput)
                {
                    case "1":
                        {
                            GetCafeMenuList();
                            break;
                        }

                    case "2":
                        {
                            GetItemByIngredients();
                            break;
                        }
                    case "3":
                        {
                            GetItemByItemID();
                            break;
                        }

                    case "4":
                        {
                             AddItemToList();
                            break;
                        }
                    case "5":
                        {

                            RemoveItemFromList();
                            break;
                        }

                    case "6":
                        {
                            continueToRunMenu = false;
                            break;

                        }
                    default:
                        {
                            Console.WriteLine("Please enter a number between 1 and 6. Press any key to continue...");
                            Console.ReadKey();
                            break;
                        }
                }
            }
        }

        private void GetCafeMenuList()
        {
            List<CafeMenu> listOfItem = _itemRepo.GetCafeMenuList();
            foreach (CafeMenu item in listOfItem)
            {

                Console.WriteLine($"{item.Meal }: { item.MealDescription}");
            }
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }


        private void GetItemByIngredients()
        {
            Console.WriteLine("Enter an ingredient: ");
            string ingredients = Console.ReadLine();
            CafeMenu item = _itemRepo.GetItemByIngredients(ingredients);

            if (item == null)
            {

                Console.WriteLine("Could not find any results.");
            }

            else
            {
                Console.WriteLine($"Meal Name:{item.Meal}\n" +
                    $"Meal Description: {item.Meal}\n" +
                    $"Price: {item.Price}\n" +
                    $"MenuItemID: {item.MenuItemID}\n" +
                    $"Ingredients: {item.Ingredients}");
            }

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }


        private void GetItemByItemID()
        {
            Console.Write("Please enter a menu item ID: ");

            int MenuItemID = int.Parse(Console.ReadLine());
            CafeMenu item = _itemRepo.GetItemByItemID( MenuItemID);

            if(item== null)
            {
                Console.WriteLine("Invalid number. Could not find any results.");
            }
            else
            {
                Console.WriteLine($"Meal Name:{item.Meal}\n" +
                    $"Meal Description: {item.Meal}\n" +
                    $"Price: {item.Price}\n" +
                    $"MenuItemID: {item.MenuItemID}\n" +
                    $"Ingredients: {item.Ingredients}");
            }

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }


        private void AddItemToList()
        {
            CafeMenu item = new CafeMenu();
            
            Console.Write("Please enter a meal: ");
            item.Meal = Console.ReadLine();

            Console.Write("Please enter a meal description: ");
            item.MealDescription = Console.ReadLine();

            Console.Write("Please enter a price: ");
            item.Price = decimal.Parse(Console.ReadLine());

            Console.Write("Please enter a menu item iD: ");
            item.MenuItemID = int.Parse(Console.ReadLine());

            Console.Write("Please enter the ingredients: ");
            item.Ingredients = Console.ReadLine();

            _itemRepo.AddItemToList(item);
        }


        private bool RemoveItemFromList()
        {
            Console.WriteLine("Enter an ingredient to remove from the menu.");
            string UserInput = Console.ReadLine();
            CafeMenu menu= _itemRepo.GetItemByIngredients(UserInput);
            int initialCount = _itemRepo.GetCafeMenuList().Count;
            _itemRepo.RemoveItemFromList(menu);

            if (initialCount > _itemRepo.GetCafeMenuList().Count)
            {
                return true;
            }
            else
            {
                return false;
            }

        }


            public void SeedItemList()
        {
            CafeMenu salmon = new CafeMenu("Salmon Piccata",  "Salmon filet grilled to perfection.", 45, 2, "Salmon");
            CafeMenu shrimp = new CafeMenu("Shrimp Scampi",  "Shrimp sautéed in a garlic sauce", 25, 1, "Shrimp");
            CafeMenu chicken = new CafeMenu("Grilled Chicken",  "Grilled chicken breasts ", 40, 3, "Chicken breast");
            CafeMenu zucchini = new CafeMenu("Zoodles Primavera",  "Zucchini noodles tossed in a light basil cream sauce", 15, 4, "Zucchini");
            _itemRepo.AddItemToList(salmon);
            _itemRepo.AddItemToList(shrimp);
            _itemRepo.AddItemToList(chicken);
            _itemRepo.AddItemToList(zucchini);


        }

    }
}

/*The Komodo Cafe is getting a new menu.

The cafe manager at Komodo wants to be able to create a menu item, delete a menu item,
and list all items on the cafe's menu. She needs a console app. 

Each of their menu items will contain the following:
a meal number so employees can say "I'll have the #5", 
a meal name, 
a description,
a list of ingredients in the meal,
and a price.

Your task is to do the following:
1. Create a Menu class with properties, constructors, and fields.
2. Create a MenuRepository class that has methods needed.
3. Create a Test Class for your repository methods. (You don't need to test
your constructors or objects.Just the methods.)
4. Create a Program file that allows the restaurant manager to add, delete, 
and see all items in the menu list.

Notes:
We don't need to update the items right now.*/
