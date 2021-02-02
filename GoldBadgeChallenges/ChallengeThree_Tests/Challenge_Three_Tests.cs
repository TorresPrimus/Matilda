using ChallengeThree.Repo;
using ChallengeThree_Repo;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace ChallengeThree_Tests
{
    [TestClass]
    public class Challenge_Three_Tests
    {
        private BadgeContent _content;
        private BadgeRepo _badgeRepo;
        private DoorContent _doorContent;
        Dictionary<int, BadgeContent> _dict = new Dictionary<int, BadgeContent>();
        List<string> _list = new List<string>();

        [TestInitialize]
        public void DefaultValues()
        {
            _content = new BadgeContent(1,_list);
            _badgeRepo = new BadgeRepo();
            _doorContent = new DoorContent("Whiskey");
            string a = "alpha";
            _list.Add(a);
            _badgeRepo.AddNewBadge(_content);
            _dict.Add(1, _content);
        }

        [TestMethod]
        public void AddNewBadge_ShouldBeNotNull()
        {
            BadgeContent badgeContent = new BadgeContent(1,_list);

            Assert.IsNotNull(badgeContent);
        }
        [TestMethod]
        public void GetDictList_ShouldBeNotNull()
        {
            _dict.Add(2, _content);

            var list = _badgeRepo.GetDictList();

            Assert.IsNotNull(list);
        }
        [TestMethod]
        public void DeleteBadge_ShouldBetrue()
        {
            bool deleteResult = _badgeRepo.DeleteBadge(1);

            Assert.IsTrue(deleteResult);
        }
    }
}
