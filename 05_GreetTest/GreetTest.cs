using System;
using _05_Greet;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _05_GreetTest
{
    [TestClass]
    public class GreetTest
    {
        private GreetRepository _customerRepo;
        private Customer _customer;


        [TestInitialize]
        public void Arrange()
        {
            _customerRepo = new GreetRepository();
            _customer = new Customer("Jake", "Smith", CustomerType.Potential, "We currently have the lowest rates on Helicopter Insurance!");
        }

        [TestMethod]

        public void CustomerPOCOtests()
        {
            Customer customer = new Customer();

            Assert.AreEqual("Jake", _customer.FirstName);
            Assert.AreEqual("Smith", _customer.LastName);
            Assert.AreEqual(CustomerType.Potential, _customer.TypeOfCustomer);
            Assert.AreEqual("We currently have the lowest rates on Helicopter Insurance!", _customer.Email);
        }

        [TestMethod]

        public void GetCustomerByFirstName()
        {
            GreetRepository customerRepo = new GreetRepository();
            Customer customer = new Customer("Jake", "Smith", CustomerType.Potential, "We currently have the lowest rates on Helicopter Insurance!");

            customerRepo.AddCustomerToList(customer);
            Customer actual = customerRepo.GetCustomerByFirstName("Jake");

            Assert.AreEqual(customer, actual);
        }

        [TestMethod]
        public void AddCustomerToList()
        {
            GreetRepository customerRepo = new GreetRepository();
            Customer customer = new Customer("Jake", "Smith", CustomerType.Potential, "We currently have the lowest rates on Helicopter Insurance!");

            customerRepo.AddCustomerToList(customer);

            int expected = 1;
            int actual = customerRepo.GetCustomerList().Count;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void RemoveCustomerFromList()//needs to be checked not showing on test explorer.
        {
            GreetRepository customerRepo = new GreetRepository();
            Customer customer = new Customer("Jake", "Smith", CustomerType.Potential, "We currently have the lowest rates on Helicopter Insurance!");

            customerRepo.AddCustomerToList(customer);
            bool wasRemoved = customerRepo.RemoveCustomerFromList(customer);

            Assert.IsTrue(wasRemoved);
        }
        
    } 
  

 }
