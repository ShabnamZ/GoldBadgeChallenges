using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_CafeRepository
{
    public class MenuRepository
    {
        private List<CafeMenu> _listOfItems = new List<CafeMenu>();

        public void AddItemToList(CafeMenu item)
        {
            _listOfItems.Add(item);
        }

        public List<CafeMenu> GetCafeMenuList()
        {
            return _listOfItems;
        }

        public CafeMenu GetItemByIngredients(string ingredients)
        {
            foreach (CafeMenu item in _listOfItems)
            {
                if (item.Ingredients.ToLower() == ingredients.ToLower())
                {
                    return item;
                }
            }
            return null;
        }

        public CafeMenu GetItemByItemID(int menuItemID)
        {
            foreach (CafeMenu itemID in _listOfItems)
            {
                if(itemID.MenuItemID == menuItemID)
                {
                    return itemID;
                }
            }
            return null;
        }



        public bool RemoveItemFromList(CafeMenu item)
        {
            int initialCount = _listOfItems.Count;
            _listOfItems.Remove(item);

            if (initialCount > _listOfItems.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }



}
