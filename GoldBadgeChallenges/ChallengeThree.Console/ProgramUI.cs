using ChallengeThree.Repo;
using ChallengeThree_Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeThree_Console
{
    class ProgramUI
    {
        private BadgeRepo _badgeRepo = new BadgeRepo();
        private DoorRepo _doorRepo = new DoorRepo();
        private Dictionary<int, List<string>> _dic = new Dictionary<int, List<string>>();

        public void Run()
        {
            DefaultBadges();
            SecurityMenu();
        }

        public void SecurityMenu()
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                Console.Clear();
                Console.WriteLine("Chose a menu item:\n" +
                    "1. Add a Badge\n" +
                    "2. Edit a Badge\n" +
                    "3. List All Badges\n" +
                    "4. Exit");

                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        AddNewBadge();
                        break;
                    case "2":
                        UpdateBadgeDoors();
                        break;
                    case "3":
                        GetAllBadges();
                        break;
                    case "4":
                        Console.WriteLine("Thank you for using KomodoSecurityOS, Good Bye!");
                        keepRunning = false;
                        break;
                    default:
                        Console.WriteLine("Error... please enter valid number!");
                        break;
                }
            }
        }

        private void AddNewBadge()
        {
            Console.Clear();
            List<string> newDoor = new List<string>();
            Console.WriteLine("What is the new badge number:");
            string badgeAsString = Console.ReadLine();
            int badgeID = int.Parse(badgeAsString);

            bool moreDoors = true;
            while (moreDoors == true)
            {
                Console.WriteLine("List a door that it needs access to:");
                string door = Console.ReadLine();
                newDoor.Add(door);

                Console.WriteLine("Do you want to add another door? y/n");
                string userInput = Console.ReadLine().Trim().ToLower();
                if (userInput == "y")
                {
                    moreDoors = true;
                }
                else
                {
                    moreDoors = false;
                }
            }
                _dic.Add(badgeID, newDoor);
        }

        private void UpdateBadgeDoors()
        {
            Console.Clear();
            GetAllBadges();
            Console.WriteLine("\nWhat badge would you like to update:");
            string badgeAsString = Console.ReadLine();
            int userInput = int.Parse(badgeAsString);
            BadgeContent pulledID = _badgeRepo.GetBadgeContentByID(userInput);

            Console.Clear();
            Console.WriteLine($"What would you like to do with {badgeAsString}:\n" +
                $"1. Add a Door\n" +
                $"2. Remove a Door");
            string menuChoice = Console.ReadLine();

            if (menuChoice == "1")
            {
                Console.WriteLine("What door would you like to add?");
                string userDoor = Console.ReadLine();
                pulledID.ListOfDoors.Add(userDoor);
            }

            else if (menuChoice == "2")
            {
                Console.WriteLine("What door would you like to remove?");
                string userRemove = Console.ReadLine();
                pulledID.ListOfDoors.Remove(userRemove);
            }

            else
            {
                Console.WriteLine("Incorrect entry, please enter 1 or 2...");
                Console.ReadLine();
            }

        }

        private void GetAllBadges()
        {
            Console.Clear();

            Console.Write("{0,-10} {1,-30}", "Badge#", "Door Access");
            foreach (KeyValuePair<int, List<string>> content in _dic)
            {
                Console.Write($"\n{content.Key,-11}");

                foreach (string item in content.Value)
                {
                    Console.Write("{0,-1}" + " ", item);
                }
            }


            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }
        private void DefaultBadges()
        {
            DoorContent a = new DoorContent("Alpha");
            DoorContent e = new DoorContent("Echo");
            DoorContent f = new DoorContent("Foxtrot");
            DoorContent k = new DoorContent("Kilo");
            DoorContent n = new DoorContent("November");
            DoorContent w = new DoorContent("Whiskey");
            DoorContent z = new DoorContent("Zulu");

            _doorRepo.AddDoor(a);
            _doorRepo.AddDoor(e);
            _doorRepo.AddDoor(f);
            _doorRepo.AddDoor(k);
            _doorRepo.AddDoor(n);
            _doorRepo.AddDoor(w);
            _doorRepo.AddDoor(z);

            List<string> listOfDoors = new List<string>();
            List<string> listOfDoorsOne = new List<string>();
            List<string> listOfDoorsTwo = new List<string>();



            listOfDoors.Add("alpha");
            listOfDoors.Add("echo");
            listOfDoorsOne.Add("foxtrot");
            listOfDoorsOne.Add("kilo");
            listOfDoorsTwo.Add("november");
            listOfDoorsTwo.Add("whiskey");
            listOfDoorsTwo.Add("zulu");



            BadgeContent torres = new BadgeContent(39007, listOfDoors);
            BadgeContent owen = new BadgeContent(38235, listOfDoorsOne);
            BadgeContent ruudberg = new BadgeContent(31234, listOfDoorsTwo);

            _badgeRepo.AddNewBadge(torres);
            _badgeRepo.AddNewBadge(owen);
            _badgeRepo.AddNewBadge(ruudberg);

            _dic.Add(39007, listOfDoors);
            _dic.Add(38235, listOfDoorsOne);
            _dic.Add(31234, listOfDoorsTwo);
        }

    }
}
