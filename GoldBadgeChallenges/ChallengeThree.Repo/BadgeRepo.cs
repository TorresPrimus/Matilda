using ChallengeThree.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeThree_Repo
{
    public class BadgeRepo
    {
        private Dictionary<int, BadgeContent> _dictionBadge = new Dictionary<int, BadgeContent>();
        private BadgeContent _badgeInfo = new BadgeContent();


        public void AddNewBadge(BadgeContent content)
        {
            _dictionBadge.Add(content.BadgeID,content);
        }

        public Dictionary<int, BadgeContent> GetDictList()
        {
            return _dictionBadge;
        }

        public BadgeContent GetBadgeContent()
        {
            return _badgeInfo;
        }

        public bool UpdateBadgeID(int originalID, BadgeContent newBadgeContent)
        {
            BadgeContent oldBadgeContent = GetBadgeContentByID(originalID);

            if (oldBadgeContent != null)
            {
                oldBadgeContent.BadgeID = newBadgeContent.BadgeID;
                oldBadgeContent.ListOfDoors = newBadgeContent.ListOfDoors;
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool DeleteBadge(int badgeID)
        {
            BadgeContent badgeContent = GetBadgeContentByID(badgeID);

            if (badgeContent == null)
            {
                return false;
            }

            int initialCount = _dictionBadge.Count;
            _dictionBadge.Remove(badgeID);

            if (initialCount > _dictionBadge.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public BadgeContent GetBadgeContentByID(int badgeID)
        {
            foreach (KeyValuePair<int,BadgeContent> content in _dictionBadge)
            {
                if (content.Key == badgeID)
                {
                    return content.Value;
                }
            }
            return null;
        }
    }
}
