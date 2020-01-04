using InjectorGames.SharedLibrary.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System.Numerics;

namespace InjectorGames.SharedLibrary.Tests
{
    [TestClass]
    public class VectorExtensionTest
    {
        [TestMethod]
        public void ByteConversion_Vector2()
        {
            var value = new Vector2(0.123f, 456f);
            var bytes = new byte[VectorExtension.ByteSizeVector2];
            var newValue = value;

            using (var memoryStream = new MemoryStream(bytes))
            {
                using (var binaryWriter = new BinaryWriter(memoryStream))
                {
                    value.ToBytes(binaryWriter);
                    Assert.AreEqual(VectorExtension.ByteSizeVector2, memoryStream.Position);

                    binaryWriter.Seek(0, SeekOrigin.Begin);

                    using (var binaryReader = new BinaryReader(memoryStream))
                    {
                        newValue = VectorExtension.ToVector2(binaryReader);
                        Assert.AreEqual(VectorExtension.ByteSizeVector2, memoryStream.Position);
                    }
                }
            }

            Assert.AreEqual(value, newValue);
        }

        [TestMethod]
        public void ByteConversion_Vector2_Int()
        {
            var value = new Vector2(1.0f, 2.0f);
            var bytes = new byte[VectorExtension.ByteSizeVector2];
            var newValue = value;

            using (var memoryStream = new MemoryStream(bytes))
            {
                using (var binaryWriter = new BinaryWriter(memoryStream))
                {
                    value.ToBytesInt(binaryWriter);
                    Assert.AreEqual(VectorExtension.ByteSizeVector2, memoryStream.Position);

                    binaryWriter.Seek(0, SeekOrigin.Begin);

                    using (var binaryReader = new BinaryReader(memoryStream))
                    {
                        newValue = VectorExtension.ToVector2Int(binaryReader);
                        Assert.AreEqual(VectorExtension.ByteSizeVector2, memoryStream.Position);
                    }
                }
            }

            Assert.AreEqual(value, newValue);
        }

        [TestMethod]
        public void ByteConversion_Vector3()
        {
            var value = new Vector3(0.123f, 456f, 789.101112f);
            var bytes = new byte[VectorExtension.ByteSizeVector3];
            var newValue = value;

            using (var memoryStream = new MemoryStream(bytes))
            {
                using (var binaryWriter = new BinaryWriter(memoryStream))
                {
                    value.ToBytes(binaryWriter);
                    Assert.AreEqual(VectorExtension.ByteSizeVector3, memoryStream.Position);

                    binaryWriter.Seek(0, SeekOrigin.Begin);

                    using (var binaryReader = new BinaryReader(memoryStream))
                    {
                        newValue = VectorExtension.ToVector3(binaryReader);
                        Assert.AreEqual(VectorExtension.ByteSizeVector3, memoryStream.Position);
                    }
                }
            }

            Assert.AreEqual(value, newValue);
        }

        [TestMethod]
        public void ByteConversion_Vector3_Int()
        {
            var value = new Vector3(1.0f, 2.0f, 3.0f);
            var bytes = new byte[VectorExtension.ByteSizeVector3];
            var newValue = value;

            using (var memoryStream = new MemoryStream(bytes))
            {
                using (var binaryWriter = new BinaryWriter(memoryStream))
                {
                    value.ToBytesInt(binaryWriter);
                    Assert.AreEqual(VectorExtension.ByteSizeVector3, memoryStream.Position);

                    binaryWriter.Seek(0, SeekOrigin.Begin);

                    using (var binaryReader = new BinaryReader(memoryStream))
                    {
                        newValue = VectorExtension.ToVector3Int(binaryReader);
                        Assert.AreEqual(VectorExtension.ByteSizeVector3, memoryStream.Position);
                    }
                }
            }

            Assert.AreEqual(value, newValue);
        }
    }
}
