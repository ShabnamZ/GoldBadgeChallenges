using _05_Greet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05_GreetConsole
{
    public class ProgramUI
    {
        private GreetRepository _customerRepo = new GreetRepository();

        public void Run()
        {
            SeedCustomerList();
            RunMenu();
        }

        private void RunMenu()
        {
            bool continueToRunMenu = true;

            while (continueToRunMenu)
            {
                Console.Clear();
                Console.WriteLine("Welcome to Komodo Insurance.\n" +
                                  "1. Show all customers.\n" +
                                  "2. Add customer to the list.\n" +
                                  "3. Remove customer from the list.\n" +
                                  "4. Update the customer.\n" +
                                  "5.Exit.");
                string userInput = Console.ReadLine();
                switch (userInput)
                {

                    case "1":
                        ShowAllCustomers();
                        break;

                    case "2":
                        CreateAndAddCustomerToList();
                        break;

                    case "3":
                        RemoveCustomerFromList();
                        break;

                    case "4":
                        UpdateTheCustomerInfo();
                        break;

                    case "5":
                        continueToRunMenu = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid number between 1 and 5.\n" +
                            "Press any key to continue..");
                        Console.ReadKey();
                        break;

                }
            }
        }
        private void ShowAllCustomers()
        {
            List<Customer> listOfCustomer = _customerRepo.GetCustomerList().OrderBy(customer =>customer.FirstName).ToList();
            foreach (Customer customer in listOfCustomer)
            {
                Console.WriteLine($"{customer.FirstName}     {customer.LastName}        {customer.TypeOfCustomer}           {customer.Email}");
            }

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();

        }


        private void CreateAndAddCustomerToList()
        {
            Customer customer = new Customer();

            // Get FirstName
            Console.Write("Please enter your first name: ");
            customer.FirstName = Console.ReadLine();

            //Get LastName
            Console.Write("Please enter a last name: ");
            customer.LastName = Console.ReadLine();

            //Get CustomerType
            Console.Write("Who is the customer?\n" +
                "1. Potential\n" +
                "2. Current\n" +
                "3. Past");
            int customerNumber = int.Parse(Console.ReadLine());
            customer.TypeOfCustomer = (CustomerType)customerNumber;
            if (customer.TypeOfCustomer == CustomerType.Potential)
            {
                customer.Email = " We currently have the lowest rates on Helicopter Insurance!";
            }

            if (customer.TypeOfCustomer == CustomerType.Current)
            {
                customer.Email = "Thank you for your work with us. We appreciate your loyalty. Here's a coupon.";
            }

            if (customer.TypeOfCustomer == CustomerType.Past)
            {
                customer.Email = "It's been a long time since we've heard from you, we want you back";
            }
            _customerRepo.AddCustomerToList(customer);

        }

        private bool RemoveCustomerFromList()
        {
            Console.WriteLine("Enter a customer first name to remove from the menu.");
            string UserInput = Console.ReadLine();
            Customer customer = _customerRepo.GetCustomerByFirstName(UserInput);
            int initialCount = _customerRepo.GetCustomerList().Count;
            _customerRepo.RemoveCustomerFromList(customer);

            if (initialCount > _customerRepo.GetCustomerList().Count)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        private void UpdateTheCustomerInfo()
        {
            Console.WriteLine("Please enter a first name..");
            string originalFirstName = Console.ReadLine();
            Customer newCustomer = _customerRepo.GetCustomerByFirstName(originalFirstName);
            Console.Write("Please enter a new first name..\n");
            newCustomer.FirstName = Console.ReadLine();
            Console.Write("Please enter a new last name..\n");
            newCustomer.LastName = Console.ReadLine();
            Console.Write("Choose a new customer type?\n" +
                "1. Potential\n" +
                "2. Current\n" +
                "3. Past\n");
            int customerNumber = int.Parse(Console.ReadLine());
            newCustomer.TypeOfCustomer = (CustomerType)customerNumber;
            if (newCustomer.TypeOfCustomer == CustomerType.Potential)
            {
                newCustomer.Email = " We currently have the lowest rates on Helicopter Insurance!";
            }

            if (newCustomer.TypeOfCustomer == CustomerType.Current)
            {
                newCustomer.Email = "Thank you for your work with us. We appreciate your loyalty. Here's a coupon.";
            }

            if (newCustomer.TypeOfCustomer == CustomerType.Past)
            {
                newCustomer.Email = "It's been a long time since we've heard from you, we want you back";
            }

            _customerRepo.UpdateCustomersInfo(originalFirstName, newCustomer);
        }

        private void SeedCustomerList()
        {
            Customer jake = new Customer("Jake", "Smith", CustomerType.Potential, "We currently have the lowest rates on Helicopter Insurance!");
            Customer james = new Customer("James", "Smith", CustomerType.Current, "Thank you for your work with us. We appreciate your loyalty. Here's a coupon");
            Customer jane = new Customer("Jane", "Smith", CustomerType.Past, " It's been a long time since we've heard from you, we want you back");
            _customerRepo.AddCustomerToList(jake);
            _customerRepo.AddCustomerToList(james);
            _customerRepo.AddCustomerToList(jane);
        }
    }


}
