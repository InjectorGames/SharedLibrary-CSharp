using InjectorGames.SharedLibrary.Games;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace InjectorGames.SharedLibrary.Tests
{
    [TestClass]
    public class ChanceTest
    {
        [TestMethod]
        public void TestConstructor()
        {
            var value = 12.345f;
            var chance = new Chance(value);
            Assert.AreEqual(value, (float)chance);
        }

        [TestMethod]
        public void TestBorder()
        {
            var isThrowed = false;
            try { _ = new Chance(12.345f); }
            catch { isThrowed = true; }
            Assert.IsFalse(isThrowed);
        }

        [TestMethod]
        public void TestUpperBorder()
        {
            var isThrowed = false;
            try { _ = new Chance(123.456f); }
            catch { isThrowed = true; }
            Assert.IsTrue(isThrowed);
        }

        [TestMethod]
        public void TestLowerBorder()
        {
            var isThrowed = false;
            try { _ = new Chance(-0.123f); }
            catch { isThrowed = true; }
            Assert.IsTrue(isThrowed);
        }
    }
}
