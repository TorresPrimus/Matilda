using ChellengeTwo.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeTwo_Console
{

    public class ProgramUI
    {
        private ClaimRepo _claimRepo = new ClaimRepo();

        public void Run()
        {
            DefaultClaims();
            MainMenu();
        }


        public void MainMenu()
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                Console.Clear();
                Console.WriteLine("Chose a menu item:\n" +
                    "1. See all claims\n" +
                    "2. Take care of next claim\n" +
                    "3. Enter a new claim\n" +
                    "4. Exit");

                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        GetClaimContents();
                        break;
                    case "2":
                        NextClaim();
                        break;
                    case "3":
                        AddNewClaim();
                        break;
                    case "4":
                        Console.WriteLine("Thank you for using KomodoOS, good bye!");
                        keepRunning = false;
                        break;
                    default:
                        Console.WriteLine("Error... please enter valid number!");
                        break;
                }
            }
        }

        private void GetClaimContents()
        {
            Console.Clear();
            Queue<ClaimContent> claimContents = _claimRepo.GetClaimContents();

            Console.WriteLine("{0,-15} {1,-10} {2,-30} {3,-15} {4,-20} {5,-20} {6,-10}", "ClaimID", "Type", "Description", "Amount", "DateOfIncident", "DateOfClaim", "IsValid");

            foreach (ClaimContent claim in claimContents)
            {
                Console.WriteLine($"{claim.ClaimID,-15} {claim.ClaimType,-10} {claim.Description,-30} {claim.ClaimAmount,-15:C} {claim.DateOfIncident.ToString("MM/dd/yyyy"),-20} {claim.DateOfClaim.ToString("MM/dd/yyyy"),-20} {claim.IsValid,-10}");
            }
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
        private void NextClaim()
        {
            Console.Clear();
            Queue<ClaimContent> nextClaim = _claimRepo.GetClaimContents();
            Console.WriteLine($"ClaimID: {nextClaim.Peek().ClaimID}\n" +
                $"Type: {nextClaim.Peek().ClaimType}\n" +
                $"Description: {nextClaim.Peek().Description}\n" +
                $"Amount: {nextClaim.Peek().ClaimAmount:C}\n" +
                $"DateOfAccident: {nextClaim.Peek().DateOfIncident.ToString("MM/dd/yyyy")}\n" +
                $"DateOfClaim: {nextClaim.Peek().DateOfClaim.ToString("MM/dd/yyyy")}\n" +
                $"IsValid: {nextClaim.Peek().IsValid}"); 

            Console.WriteLine("Do you want to deal with this claim now? (y/n)");
            string userInput = Console.ReadLine().Trim().ToLower();

            if (userInput == "y")
            {
                Console.WriteLine("Claim has been removed from Queue");
                nextClaim.Dequeue();
            }
            else
            {
                Console.WriteLine("Returning to Main Menu.");
                Console.ReadKey();
            }


        }
        private void AddNewClaim()
        {
            Console.Clear();
            ClaimContent newClaim = new ClaimContent();

            Console.WriteLine("Enter Claim ID:");
            string idOfClaim = Console.ReadLine();
            int newIDOfClaim = int.Parse(idOfClaim);
            newClaim.ClaimID = newIDOfClaim;

            Console.WriteLine("Enter claim type: (Enter NUMBER)\n" +
                "1. Car\n" +
                "2. Home\n" +
                "3. Theft");
            string typeOfClaim = Console.ReadLine();
            int intOfClaim = int.Parse(typeOfClaim);
            newClaim.ClaimType = (TypesOfClaims)intOfClaim;

            Console.WriteLine("Enter a claim description: ");
            string claimDesc = Console.ReadLine();
            newClaim.Description = claimDesc;

            Console.WriteLine("Amount of Damage: ");
            string claimCost = Console.ReadLine();
            double costAsDouble = double.Parse(claimCost);
            newClaim.ClaimAmount = costAsDouble;

            Console.WriteLine("Date of Accident:");
            string dateOfAcc = Console.ReadLine();
            DateTime dateAsDate = DateTime.Parse(dateOfAcc);
            newClaim.DateOfIncident = dateAsDate;

            Console.WriteLine("Date of Claim:");
            string dateOfClaim = Console.ReadLine();
            DateTime claimDateAsDate = DateTime.Parse(dateOfClaim);
            newClaim.DateOfClaim = claimDateAsDate;

            Console.WriteLine("Is this claim valid? (y/n)");
            string validate = Console.ReadLine().Trim().ToLower();
            if (validate == "y")
            {
                newClaim.IsValid = true;
            }
            else
            {
                newClaim.IsValid = false;
            }

            _claimRepo.AddClaim(newClaim);
        }
        private void DefaultClaims()
        {
            ClaimContent torres = new ClaimContent(1, TypesOfClaims.Car, "Car Accident on 465.", 400, new DateTime(2018, 4, 25), new DateTime(2018, 4, 27), true);
            ClaimContent owen = new ClaimContent(2, TypesOfClaims.Home, "House fire in kitchen.", 4000, new DateTime(2018, 4, 11), new DateTime(2018, 4, 12), true);
            ClaimContent ruudberg = new ClaimContent(3, TypesOfClaims.Theft, "Stolen bike.", 4, new DateTime(2018, 4, 27), new DateTime(2018, 6, 01), false);

            _claimRepo.AddClaim(torres);
            _claimRepo.AddClaim(owen);
            _claimRepo.AddClaim(ruudberg);
        }
    }
}
