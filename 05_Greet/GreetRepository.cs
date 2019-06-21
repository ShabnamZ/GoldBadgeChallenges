using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05_Greet
{
    public class GreetRepository
    {
        private List<Customer> _listOfCustomers = new List<Customer>();


        public void AddCustomerToList(Customer customer)
        {
            _listOfCustomers.Add(customer);
        }

        public List<Customer> GetCustomerList()
        {
            return _listOfCustomers;
        }


        public Customer GetCustomerByFirstName(string firstName)
        {
            foreach (Customer customer in _listOfCustomers)
            {
                if(customer.FirstName.ToLower() == firstName.ToLower())
                {
                    return customer;
                }
            }
            return null;
        }

        public void UpdateCustomersInfo(string originalFirstName, Customer newCustomer)
        {
            Customer oldCustomer = GetCustomerByFirstName(originalFirstName);
            oldCustomer = newCustomer;
            oldCustomer.FirstName = newCustomer.FirstName;
            oldCustomer.LastName = newCustomer.LastName;
            oldCustomer.TypeOfCustomer = newCustomer.TypeOfCustomer;
            oldCustomer.Email = newCustomer.Email;
        }

        public bool RemoveCustomerFromList(Customer customer)
        {
            int initialCount = _listOfCustomers.Count;
            _listOfCustomers.Remove(customer);

            if (initialCount > _listOfCustomers.Count)
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
