using InjectorGames.SharedLibrary.Credentials;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace InjectorGames.SharedLibrary.Tests
{
    [TestClass]
    public class UsernameTest
    {
        [TestMethod]
        public void Constructor()
        {
            var value = "test_username123";
            var username = new Username(value);
            Assert.AreEqual(value, (string)username);
        }

        [TestMethod]
        public void Equality()
        {
            var firstUsername = new Username("test_username2");
            var secondUsername = new Username("test_username2");
            Assert.AreEqual(firstUsername, secondUsername);
        }

        [TestMethod]
        public void NotEquality()
        {
            var firstUsername = new Username("first_username2");
            var secondUsername = new Username("second_username2");
            Assert.AreNotEqual(firstUsername, secondUsername);
        }

        [TestMethod]
        public void String()
        {
            var value = "test_username123";
            var username = new Username(value);
            Assert.AreEqual(value, username.ToString());
        }

        [TestMethod]
        public void HashCode()
        {
            var value = "test_username456";
            var username = new Username(value);
            Assert.AreEqual(value.GetHashCode(), username.GetHashCode());
        }

        [TestMethod]
        public void SpaceLetters()
        {
            var isThrowed = false;
            try { _ = new Username("test username123"); }
            catch { isThrowed = true; }
            Assert.IsTrue(isThrowed);
        }

        [TestMethod]
        public void BigLetters()
        {
            var isThrowed = false;
            try { _ = new Username("test_Username123"); }
            catch { isThrowed = true; }
            Assert.IsTrue(isThrowed);
        }

        [TestMethod]
        public void AlphanumericLetters()
        {
            var isThrowed = false;
            try { _ = new Username("test.username123"); }
            catch { isThrowed = true; }
            Assert.IsTrue(isThrowed);
        }

        [TestMethod]
        public void UpperBound()
        {
            var isThrowed = false;
            try { _ = new Username("012345678910111213"); }
            catch { isThrowed = true; }
            Assert.IsTrue(isThrowed);
        }

        [TestMethod]
        public void LowerBound()
        {
            var isThrowed = false;
            try { _ = new Username("012"); }
            catch { isThrowed = true; }
            Assert.IsTrue(isThrowed);
        }

        [TestMethod]
        public void ByteConversion()
        {
            var value = "test_username1";
            var username = new Username(value);
            var bytes = new byte[username.ByteArraySize];

            using (var memoryStream = new MemoryStream(bytes))
            {
                using (var binaryWriter = new BinaryWriter(memoryStream))
                {
                    username.ToBytes(binaryWriter);
                    Assert.AreEqual(username.ByteArraySize, memoryStream.Position);

                    binaryWriter.Seek(0, SeekOrigin.Begin);

                    using (var binaryReader = new BinaryReader(memoryStream))
                    {
                        username = new Username(binaryReader);
                        Assert.AreEqual(username.ByteArraySize, memoryStream.Position);
                    }
                }
            }

            // ASCII Symbols: 116 == 't', 95 == '_', 0 == null
            Assert.AreEqual(116, bytes[0]);
            Assert.AreEqual(95, bytes[4]);
            Assert.AreEqual(0, bytes[14]);

            Assert.AreEqual(value, (string)username);
        }

        [TestMethod]
        public void ByteConversion_Full()
        {
            var value = "test_username123";
            var username = new Username(value);
            var bytes = new byte[Username.ByteSize];

            using (var memoryStream = new MemoryStream(bytes))
            {
                using (var binaryWriter = new BinaryWriter(memoryStream))
                {
                    username.ToBytes(binaryWriter);
                    Assert.AreEqual(Username.ByteSize, memoryStream.Position);

                    binaryWriter.Seek(0, SeekOrigin.Begin);

                    using (var binaryReader = new BinaryReader(memoryStream))
                    {
                        username = new Username(binaryReader);
                        Assert.AreEqual(Username.ByteSize, memoryStream.Position);
                    }
                }
            }

            // ASCII Symbols: 116 == 't', 95 == '_'
            Assert.AreEqual(116, bytes[0]);
            Assert.AreEqual(95, bytes[4]);

            Assert.AreEqual(value, (string)username);
        }
    }
}
