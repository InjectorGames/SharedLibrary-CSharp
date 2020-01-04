using InjectorGames.SharedLibrary.Credentials;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace InjectorGames.SharedLibrary.Tests
{
    [TestClass]
    public class EmailAddressTest
    {
        [TestMethod]
        public void Constructor()
        {
            var value = "a@b.c";
            var username = new EmailAddress(value);
            Assert.AreEqual(value, (string)username);
        }

        [TestMethod]
        public void ByteConversion()
        {
            var value = new EmailAddress("info@mail.com");
            var bytes = new byte[EmailAddress.ByteSize];
            var newValue = value;

            using (var memoryStream = new MemoryStream(bytes))
            {
                using (var binaryWriter = new BinaryWriter(memoryStream))
                {
                    value.ToBytes(binaryWriter);
                    Assert.AreEqual(EmailAddress.ByteSize, memoryStream.Position);

                    binaryWriter.Seek(0, SeekOrigin.Begin);

                    using (var binaryReader = new BinaryReader(memoryStream))
                    {
                        newValue = new EmailAddress(binaryReader);
                        Assert.AreEqual(EmailAddress.ByteSize, memoryStream.Position);
                    }
                }
            }

            Assert.AreEqual(value, newValue);
        }

        [TestMethod]
        public void LowerBound()
        {
            var isThrowed = false;
            try { _ = new EmailAddress("@g.c"); }
            catch { isThrowed = true; }
            Assert.IsTrue(isThrowed);
        }
    }
}
