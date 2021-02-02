using ChellengeTwo.Repo;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace ChallengeTwo.Tests
{
    [TestClass]
    public class challenge_two_tests
    {
        private ClaimRepo _repo;
        private ClaimContent _content;
        Queue<ClaimContent> _queue = new Queue<ClaimContent>();

        [TestInitialize]
        public void DefaultValues()
        {
            _repo = new ClaimRepo();
            _content = new ClaimContent(1,TypesOfClaims.Car,"Crash",4999,new DateTime(2020,12,9),new DateTime(2020,12,10),true);

            _repo.AddClaim(_content);            
        }

        [TestMethod]
        public void AddClaim_ShouldGetNotNull()
        {
            ClaimContent torres = new ClaimContent(1, TypesOfClaims.Car, "Car Accident on 465.", 400, new DateTime(2018,4,25), new DateTime(2018,4,27), true);

            _repo.AddClaim(torres);

            Assert.IsNotNull(torres);
        }

        [TestMethod]
        public void RemoveClaim_ShouldReturnTrue()
        {
            bool deleteResult = _repo.RemoveClaimContent(_content.ClaimID);

            Assert.IsTrue(deleteResult);
        }

        [TestMethod]
        public void GetClaimContents_ShouldNotBeNull()
        {
            var list = _repo.GetClaimContents();

            Assert.IsNotNull(list);
        }
    }
}
