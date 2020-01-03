using InjectorGames.SharedLibrary.Times;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading;

namespace InjectorGames.SharedLibrary.Tests
{
    [TestClass]
    public class ClockTest
    {
        [TestMethod]
        public void TestTicking()
        {
            var clock = new Clock();
            clock.Start();

            var firstTime = clock.MS;
            Thread.Sleep(1);
            var secondTime = clock.MS;

            Assert.IsTrue(firstTime <= secondTime);
        }
    }
}
