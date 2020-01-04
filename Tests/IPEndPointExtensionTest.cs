using InjectorGames.SharedLibrary.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System.Net;

namespace InjectorGames.SharedLibrary.Tests
{
    [TestClass]
    public class IPEndPointExtensionTest
    {
        public void ByteConversion(IPEndPoint value)
        {
            var bytes = new byte[IPEndPointExtension.ByteSize];
            var newValue = value;

            using (var memoryStream = new MemoryStream(bytes))
            {
                using (var binaryWriter = new BinaryWriter(memoryStream))
                {
                    value.ToBytes(binaryWriter);
                    Assert.AreEqual(IPEndPointExtension.ByteSize, memoryStream.Position);

                    binaryWriter.Seek(0, SeekOrigin.Begin);

                    using (var binaryReader = new BinaryReader(memoryStream))
                    {
                        newValue = IPEndPointExtension.FromBytes(binaryReader);
                        Assert.AreEqual(IPEndPointExtension.ByteSize, memoryStream.Position);
                    }
                }
            }

            Assert.AreEqual(value, newValue);
        }

        [TestMethod]
        public void ByteConversion_IPv4()
        {
            ByteConversion(new IPEndPoint(IPAddress.Loopback, 12345));
        }

        [TestMethod]
        public void ByteConversion_IPv4_ZeroPort()
        {
            ByteConversion(new IPEndPoint(IPAddress.Loopback, IPEndPoint.MinPort));
        }

        [TestMethod]
        public void ByteConversion_IPv6()
        {
            ByteConversion(new IPEndPoint(IPAddress.IPv6Loopback, 12345));
        }

        [TestMethod]
        public void ByteConversion_IPv6_ZeroPort()
        {
            ByteConversion(new IPEndPoint(IPAddress.IPv6Loopback, IPEndPoint.MinPort));
        }
    }
}
