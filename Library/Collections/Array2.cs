using System;
using System.Numerics;

namespace InjectorGames.SharedLibrary.Collections
{
    /// <summary>
    /// Two-dimensional array container class
    /// </summary>
    public class Array2<T> : IArray2<T>
    {
        /// <summary>
        /// Number of items in an array
        /// </summary>
        public int Length => length;

        /// <summary>
        /// Array size along X-axis
        /// </summary>
        public int SizeX => sizeX;
        /// <summary>
        /// Array size along Y-axis
        /// </summary>
        public int SizeY => sizeY;

        /// <summary>
        /// Number of items in an array
        /// </summary>
        protected readonly int length;
        /// <summary>
        /// Array size along axis
        /// </summary>
        protected readonly int sizeX, sizeY;

        /// <summary>
        /// Array instance
        /// </summary>
        protected readonly T[][] items;

        /// <summary>
        /// Creates a new array class instance
        /// </summary>
        public Array2(T[][] items)
        {
            sizeY = items.Length;
            sizeX = items[0].Length;
            length = sizeX * sizeY;
            this.items = items;
        }


        /// <summary>
        /// Creates a new array class instance
        /// </summary>
        public Array2(int sizeX, int sizeY)
        {
            this.sizeX = sizeX;
            this.sizeY = sizeY;
            length = sizeX * sizeY;
            items = new T[sizeY][];

            for (int y = 0; y < sizeY; y++)
                items[y] = new T[sizeX];
        }

        /// <summary>
        /// Returns value from an array
        /// </summary>
        public T Get(int x, int y)
        {
            return items[y][x];
        }
        /// <summary>
        /// Returns value from an array
        /// </summary>
        public T Get(Vector2 position)
        {
            return items[(int)position.Y][(int)position.X];
        }

        /// <summary>
        /// Sets value to an array
        /// </summary>
        public void Set(int x, int y, T value)
        {
            items[y][x] = value;
        }
        /// <summary>
        /// Sets value to an array
        /// </summary>
        public void Set(Vector2 position, T value)
        {
            items[(int)position.Y][(int)position.X] = value;
        }

        /// <summary>
        /// Returns this array items
        /// </summary>
        public T[][] GetItems()
        {
            return items;
        }

        /// <summary>
        /// Returns fragment from an three-dimensional array
        /// </summary>
        public T[][] GetFragment(int sizeX, int sizeY)
        {
            var otherItems = new T[sizeY][];

            for (int y = 0; y < sizeY; y++)
                Array.Copy(items[y], 0, otherItems[y], 0, sizeX);

            return otherItems;
        }
        /// <summary>
        /// Returns fragment from an three-dimensional array
        /// </summary>
        public T[][] GetFragment(int sizeX, int sizeY, int offsetX, int offsetY)
        {
            var otherItems = new T[sizeY][];

            for (int y = 0; y < sizeY; y++)
                Array.Copy(items[y + offsetY], offsetX, otherItems[y], 0, sizeX);

            return otherItems;
        }

        /// <summary>
        /// Returns true if array fits into this array
        /// </summary>
        public bool IsFits(IArray2<T> array)
        {
            return array.SizeX <= sizeX && array.SizeY <= sizeY;
        }
        /// <summary>
        /// Returns true if array fits into this array
        /// </summary>
        public bool IsFits(IArray2<T> array, int offsetX, int offsetY)
        {
            return offsetX >= 0 && array.SizeX + offsetX <= sizeX && offsetY >= 0 && array.SizeY + offsetY <= sizeY;
        }

        /// <summary>
        /// Copies this three-dimensional array to another
        /// </summary>
        public void CopyTo(IArray2<T> array)
        {
            var otherItems = array.GetItems();

            for (int y = 0; y < sizeY; y++)
                Array.Copy(items[y], 0, otherItems[y], 0, sizeX);
        }
        /// <summary>
        /// Copies this three-dimensional array to another
        /// </summary>
        public void CopyTo(IArray2<T> array, int offsetX, int offsetY)
        {
            var otherItems = array.GetItems();

            for (int y = 0; y < sizeY; y++)
                Array.Copy(items[y], 0, otherItems[y + offsetY], offsetX, sizeX);
        }
    }
}
