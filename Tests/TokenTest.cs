using InjectorGames.SharedLibrary.Credentials;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace InjectorGames.SharedLibrary.Tests
{
    [TestClass]
    public class TokenTest
    {
        [TestMethod]
        public void ByteConversion()
        {
            var value = Token.Create();
            var bytes = new byte[Token.ByteSize];
            var newValue = value;

            using (var memoryStream = new MemoryStream(bytes))
            {
                using (var binaryWriter = new BinaryWriter(memoryStream))
                {
                    value.ToBytes(binaryWriter);
                    Assert.AreEqual(Token.ByteSize, memoryStream.Position);

                    binaryWriter.Seek(0, SeekOrigin.Begin);

                    using (var binaryReader = new BinaryReader(memoryStream))
                    {
                        newValue = new Token(binaryReader);
                        Assert.AreEqual(Token.ByteSize, memoryStream.Position);
                    }
                }
            }

            Assert.AreEqual(value, newValue);
        }

        [TestMethod]
        public void Base64Conversion()
        {
            var value = Token.Create();
            var base64 = value.ToBase64();
            var newValue = new Token(base64);
            Assert.AreEqual(value, newValue);
        }
    }
}
