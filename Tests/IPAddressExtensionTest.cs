using InjectorGames.SharedLibrary.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System.Net;

namespace InjectorGames.SharedLibrary.Tests
{
    [TestClass]
    public class IPAddressExtensionTest
    {
        public void ByteConsversion(IPAddress value)
        {
            var bytes = new byte[IPAddressExtension.ByteSize];
            var newValue = value;

            using (var memoryStream = new MemoryStream(bytes))
            {
                using (var binaryWriter = new BinaryWriter(memoryStream))
                {
                    value.ToBytes(binaryWriter);
                    Assert.AreEqual(IPAddressExtension.ByteSize, memoryStream.Position);

                    binaryWriter.Seek(0, SeekOrigin.Begin);

                    using (var binaryReader = new BinaryReader(memoryStream))
                    {
                        newValue = IPAddressExtension.FromBytes(binaryReader);
                        Assert.AreEqual(IPAddressExtension.ByteSize, memoryStream.Position);
                    }
                }
            }

            Assert.AreEqual(value, newValue);
        }

        [TestMethod]
        public void ByteConversion_IPv4()
        {
            ByteConsversion(IPAddress.Parse("192.168.0.1"));
        }

        [TestMethod]
        public void ByteConversion_IPv4_Loopback()
        {
            ByteConsversion(IPAddress.Loopback);
        }

        [TestMethod]
        public void ByteConversion_IPv4_Any()
        {
            ByteConsversion(IPAddress.Any);
        }

        [TestMethod]
        public void ByteConversion_IPv6()
        {
            ByteConsversion(IPAddress.Parse("2001:0db8:85a3:0000:0000:8a2e:0370:7334"));
        }

        [TestMethod]
        public void ByteConversion_IPv6_Loopback()
        {
            ByteConsversion(IPAddress.IPv6Loopback);
        }

        [TestMethod]
        public void ByteConversion_IPv6_Any()
        {
            ByteConsversion(IPAddress.IPv6Any);
        }
    }
}
