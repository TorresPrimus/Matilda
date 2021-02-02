using Challenge_One_Repo;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Challenge_One_Tests
{
    [TestClass]
    public class IngredientsRepTests
    {
        private IngredientsRepo _repo;
        private IngredientsContent _content;

        [TestInitialize]
        public void DefaultValues()
        {
            _repo = new IngredientsRepo();
            _content = new IngredientsContent("Carrot");

            _repo.AddIngredient(_content);
        }

        [TestMethod]
        public void AddIngredient_ShouldGetNotNull()
        {
            IngredientsContent soySauce = new IngredientsContent("Soy Sauce");

            _repo.AddIngredient(soySauce);

            Assert.IsNotNull(soySauce);
        }

        [DataTestMethod]
        [DataRow("Carrot", true)]
        [DataRow("Salt", false)]
        [DataRow("Chicken", false)]
        [DataRow("Beef", false)]

        [TestMethod]
        public void UpdateIngredient_ShouldReturnTrue(string originalName, bool shouldUpdate)
        {
            IngredientsContent newContent = new IngredientsContent("Salt");

            bool updateResult = _repo.UpdateIngredient(originalName, newContent);

            Assert.AreEqual(shouldUpdate, updateResult);
        }

        [TestMethod]
        public void RemoveIngredient_ShouldReturnTrue()
        {
            bool deleteResult = _repo.RemoveIngredient(_content.IngredientName);

            Assert.IsTrue(deleteResult);
        }
    }
}
