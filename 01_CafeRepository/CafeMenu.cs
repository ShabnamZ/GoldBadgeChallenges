using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_CafeRepository
{
    public  class CafeMenu
    {
        
        public string Meal { get; set; }
        public string MealDescription { get; set; }
        public decimal Price { get; set; }
        public int MenuItemID { get; set; }
        public string Ingredients { get; set; }



        public CafeMenu() { }

        public CafeMenu(string meal, string mealDescription, decimal price, int menuItemID, string ingredients)
        {

            Meal = meal;
            MealDescription = mealDescription;
            Price = price;
            MenuItemID = menuItemID;
            Ingredients = ingredients;

        }
    }
}
