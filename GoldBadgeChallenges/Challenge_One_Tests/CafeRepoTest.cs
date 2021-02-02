using Challenge_One_Repo;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Challenge_One_Tests
{
    [TestClass]
    public class CafeRepoTest
    {
        private CafeRepo _repo;
        private CafeContent _content;
        private IngredientsContent _iContent;
        private IngredientsRepo _iRepo;
        List<IngredientsContent> _listOfIngredients = new List<IngredientsContent>();

        [TestInitialize]
        public void DefaultValues()
        {
            _repo = new CafeRepo();
            _iRepo = new IngredientsRepo();
            _iContent = new IngredientsContent("bread");

            _listOfIngredients.Add(_iContent);
            _content = new CafeContent(1,"Grilled Cheese","Melted cheese between two pieces of bread.", _listOfIngredients,2.99);

            _repo.AddMenuItem(_content);
        }

        [TestMethod]
        public void AddMenuItem_ShouldGetNotNull()
        {
            CafeContent cereal = new CafeContent(2,"Cereal","Sugar puffs in milk.",_listOfIngredients,1.99);

            _repo.AddMenuItem(cereal);

            Assert.IsNotNull(cereal);
        }

        [DataTestMethod]
        [DataRow(1, true)]
        [DataRow(2, false)]
        [DataRow(3, false)]

        [TestMethod]
        public void UpdateMenuItem_ShouldReturnTrue(int originalID, bool shouldUpdate)
        {
            CafeContent newContent = new CafeContent(1,"Ham and Cheese", "Twenty slices of ham and five slices of melted cheese between two slices of bread.", _listOfIngredients, 5.99);

            bool updateResult = _repo.UpdateMenuItem(originalID, newContent);

            Assert.AreEqual(shouldUpdate, updateResult);
        }

        [TestMethod]
        public void RemoveIngredient_ShouldReturnTrue()
        {
            bool deleteResult = _repo.RemoveMenuItem(_content.MealNumber);

            Assert.IsTrue(deleteResult);
        }
    }
}
