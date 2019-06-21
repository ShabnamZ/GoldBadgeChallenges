using _02_ClaimRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_ClaimConsole
{
    public class ProgramUI
    {
        private ClaimRepository _claimRepo = new ClaimRepository();

        public void Run()
        {
            SeedClaimList();
            RunMenu();
        }

        private void RunMenu()
        {
            bool continueToRunMenu = true;

            while (continueToRunMenu)
            {
                Console.Clear();
                Console.WriteLine("welcome to Komodo Claims Department.\n" +
                    "1.See all claims list.\n" +
                    "2.Take care of next claim.\n" +
                    "3.Enter a new claim.\n" +
                    "4.Exit.");

                string userInput = Console.ReadLine();
                switch (userInput)
                {
                    case "1":
                        GetListOfClaims();
                        break;

                     case "2":
                        TakeNextClaim();
                         break;

                    case "3":
                        AddClaimToQueue();
                        break;

                    case "4":
                        continueToRunMenu = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid number between 1 and 5.\n" +
                         "Press any key to continue...");
                        Console.ReadKey();
                        break;
                }
            }
        }

        private void GetListOfClaims()
        {
            Queue<Claim> queueOfClaims = _claimRepo.GetListOfClaims();
            foreach (Claim claim in queueOfClaims)
            {
                Console.WriteLine($" {claim.ClaimID}    {claim.TypeOfClaim}      {claim.Description}      {claim.ClaimAmount}       {claim.DateOfIncident}       {claim.DateOfClaim}        {claim.IsValid}");
            }

            Console.WriteLine("Press any key to continue....");
            Console.ReadKey();
        }


        private void AddClaimToQueue()
        {
            Claim claim = new Claim();
            //Get Claim ID
            Console.Write("Please enter a claim ID: ");
            int claimID = int.Parse(Console.ReadLine());

            //Get ClaimType
            Console.Write("What is the claim type?\n " +
                "1.Car\n" +
                "2.Home\n" +
                "3.Theft");
            int claimNumber = int.Parse(Console.ReadLine());
            claim.TypeOfClaim = (ClaimType)claimNumber;

            //Get Description
            Console.Write("Please enter a description....");
            claim.Description = Console.ReadLine();


            //ClaimAmount
            Console.Write("Please enter the claim amount: $ ");
            decimal claimAmount = decimal.Parse(Console.ReadLine());

            //Date Of Incident
            Console.Write("Please enter the date of incident: mm/dd/yyyy ");
            claim.DateOfIncident = DateTime.Parse(Console.ReadLine());

            //Date of Claim
            Console.Write("Please enter the date of claim: mm/dd/yyyy ");
            claim.DateOfClaim = DateTime.Parse(Console.ReadLine());

            //Is claim valid
            Console.Write("This claim is valid.");
            Console.ReadKey();
            TimeSpan difference = claim.DateOfClaim - claim.DateOfIncident;
            double Days = difference.TotalDays;
            if (difference.TotalDays <= 30)
            {
                claim.IsValid = true;
            }
            else claim.IsValid = false;


            _claimRepo.AddClaimToQueue(claim);
        }


       private void TakeNextClaim()
        {
            Console.WriteLine("ClaimID:\n" +
                "TypeOfClaim:\n" +
                "Description:\n" +
                "ClaimAmount:\n" +
                "DateOfIncident:\n" +
                "DateOfClaim:\n" +
                "IsValid:");
            Console.WriteLine("Do you want to deal with this claim now(y/n)?" );

            string respond = Console.ReadLine();
            switch (respond)
            {
                case "y":
                    _claimRepo.TakeNextClaim();
                    break;

                case "n":
                    break;
            }
            Console.ReadKey();
        }

        private void SeedClaimList()
        {
            Claim car = new Claim(1, ClaimType.Car, "Car accident on 465", 400, Convert.ToDateTime("2018/4/25"), Convert.ToDateTime("2018/4/27"), true);
            Claim house = new Claim(2, ClaimType.Home, "House in fire", 4000, Convert.ToDateTime("2018/4/26"), Convert.ToDateTime("2018/4/28"), true);
            Claim theft = new Claim(3, ClaimType.Theft, "Stolen lawnmover", 150, Convert.ToDateTime("2018/4/27"), Convert.ToDateTime("2018/8/16"), false);

            _claimRepo.AddClaimToQueue(car);
            _claimRepo.AddClaimToQueue(house);
            _claimRepo.AddClaimToQueue(theft);
        }
    }
}
