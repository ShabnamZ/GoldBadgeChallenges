using System;
using _01_CafeRepository;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _01_CafeTests
{
    [TestClass]
    public class CafeTests
    {
        private MenuRepository _itemRepo;
        private CafeMenu _item;


        [TestInitialize]
        public void Arrange()
        {
            _itemRepo = new MenuRepository();
            _item = new CafeMenu("Salmon Piccata", "Salmon filet grilled to perfection.", 45, 2, "Salmon");
            /* _itemRepo.AddCafeMenu(_item); need to be checked*/
        }

        [TestMethod]
        public void CafeMenuPOCOtests()
        {
            CafeMenu item = new CafeMenu();

            Assert.AreEqual("Salmon Piccata", _item.Meal);
            Assert.AreEqual("Salmon filet grilled to perfection.", _item.MealDescription);
            Assert.AreEqual(45, _item.Price);
            Assert.AreEqual(2, _item.MenuItemID);
            Assert.AreEqual("Salmon", _item.Ingredients);
        }

        [TestMethod]
        public void GetItemByIngredientsTest()
        {
            //Arrange
            MenuRepository itemRepo = new MenuRepository();
            CafeMenu item = new CafeMenu("Salmon Piccata", "Salmon filet grilled to perfection.", 45, 2, "Salmon");

            //Act
            itemRepo.AddItemToList(item);
            CafeMenu actual = itemRepo.GetItemByIngredients("Salmon");

            //Assert
            Assert.AreEqual(item, actual);
        }

        [TestMethod]
        public void MenuRepositoryAddToList()
        {
            //Arrange
            MenuRepository itemRepo = new MenuRepository();
            CafeMenu item = new CafeMenu("Salmon Piccata", "Salmon filet grilled to perfection.", 45, 2, "Salmon");

            //Act
            _itemRepo.AddItemToList(item);

            int expected = 0;
            int actual = itemRepo.GetCafeMenuList().Count;

            //Assert
            Assert.AreEqual(expected, actual);
        } 

        [TestMethod]
        public void RemoveFromListTest()
        {
            //Arrange
            MenuRepository itemRepo = new MenuRepository();
            CafeMenu item = new CafeMenu("Salmon Piccata", "Salmon filet grilled to perfection.", 45, 2, "Salmon");

            //Act
            itemRepo.AddItemToList(item);
            bool wasRemoved = itemRepo.RemoveItemFromList(item);

            //Assert
            Assert.IsTrue(wasRemoved);
        }

    }

}



