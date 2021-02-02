using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeThree.Repo
{
    public class DoorContent
    {
        public string DoorName { get; set; }

        public DoorContent() { }

        public DoorContent(string doorName)
        {
            DoorName = doorName;
        }
    }
}
