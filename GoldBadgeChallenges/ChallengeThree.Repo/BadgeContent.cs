using ChallengeThree.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeThree_Repo
{
    public class BadgeContent
    {
        public int BadgeID { get; set; }

        public List<string> ListOfDoors { get; set; }

        public BadgeContent() { }

        public BadgeContent(int badgeID, List<string> listOfDoors)
        {
            BadgeID = badgeID;
            ListOfDoors = listOfDoors;
        }
    }
}
