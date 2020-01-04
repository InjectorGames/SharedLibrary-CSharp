using InjectorGames.SharedLibrary.Credentials;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace InjectorGames.SharedLibrary.Tests
{
    [TestClass]
    public class PasshashTest
    {
        [TestMethod]
        public void Equality()
        {
            var firstValue = Passhash.PasswordToPasshash("Str0ngPassw0rd123", 1024);
            var secondValue = Passhash.PasswordToPasshash("Str0ngPassw0rd123", 1024);
            Assert.AreEqual(firstValue, secondValue);
        }

        [TestMethod]
        public void NotEquality()
        {
            var firstValue = Passhash.PasswordToPasshash("Str0ngPassw0rd123", 1024);
            var secondValue = Passhash.PasswordToPasshash("OtherStr0ngPassw0rd123", 1024);
            Assert.AreNotEqual(firstValue, secondValue);
        }

        [TestMethod]
        public void LowerBound()
        {
            var isThrowed = false;
            try { _ = Passhash.PasswordToPasshash("12345", 123); }
            catch { isThrowed = true; }
            Assert.IsTrue(isThrowed);
        }

        [TestMethod]
        public void PasswordIteration()
        {
            var firstValue = Passhash.PasswordToPasshash("Str0ngPassw0rd123", 128);
            var secondValue = Passhash.PasswordToPasshash("Str0ngPassw0rd123", 1024);
            Assert.AreNotEqual(firstValue, secondValue);
        }

        [TestMethod]
        public void ByteConversion()
        {
            var value = Passhash.PasswordToPasshash("Str0ngPassw0rd123");
            var bytes = new byte[Passhash.ByteSize];
            var newValue = value;

            using (var memoryStream = new MemoryStream(bytes))
            {
                using (var binaryWriter = new BinaryWriter(memoryStream))
                {
                    value.ToBytes(binaryWriter);
                    Assert.AreEqual(Passhash.ByteSize, memoryStream.Position);

                    binaryWriter.Seek(0, SeekOrigin.Begin);

                    using (var binaryReader = new BinaryReader(memoryStream))
                    {
                        newValue = new Passhash(binaryReader);
                        Assert.AreEqual(Passhash.ByteSize, memoryStream.Position);
                    }
                }
            }

            Assert.AreEqual(value, newValue);
        }

        [TestMethod]
        public void Base64Conversion()
        {
            var value = Passhash.PasswordToPasshash("Str0ngPassw0rd123");
            var base64 = value.ToBase64();
            var newValue = new Passhash(base64);
            Assert.AreEqual(value, newValue);
        }
    }
}
