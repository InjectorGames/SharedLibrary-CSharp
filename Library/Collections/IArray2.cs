using System.Numerics;

namespace InjectorGames.SharedLibrary.Collections
{
    /// <summary>
    /// Two-dimensional array container interface
    /// </summary>
    public interface IArray2<T>
    {
        /// <summary>
        /// Length of an array
        /// </summary>
        int Length { get; }

        /// <summary>
        /// Array size along X-axis
        /// </summary>
        int SizeX { get; }
        /// <summary>
        /// Array size along Y-axis
        /// </summary>
        int SizeY { get; }

        /// <summary>
        /// Returns value from an array
        /// </summary>
        T Get(int x, int y);
        /// <summary>
        /// Returns value from an array
        /// </summary>
        T Get(Vector2 position);

        /// <summary>
        /// Sets value to an array
        /// </summary>
        void Set(int x, int y, T value);
        /// <summary>
        /// Sets value to an array
        /// </summary>
        void Set(Vector2 position, T value);

        /// <summary>
        /// Returns this array items
        /// </summary>
        T[][] GetItems();

        /// <summary>
        /// Returns fragment from an three-dimensional array
        /// </summary>
        T[][] GetFragment(int sizeX, int sizeY);
        /// <summary>
        /// Returns fragment from an three-dimensional array
        /// </summary>
        T[][] GetFragment(int sizeX, int sizeY, int offsetX, int offsetY);

        /// <summary>
        /// Returns true if array fits into this array
        /// </summary>
        bool IsFits(IArray2<T> array);
        /// <summary>
        /// Returns true if array fits into this array
        /// </summary>
        bool IsFits(IArray2<T> array, int offsetX, int offsetY);

        /// <summary>
        /// Copies this three-dimensional array to another
        /// </summary>
        void CopyTo(IArray2<T> array);
        /// <summary>
        /// Copies this three-dimensional array to another
        /// </summary>
        void CopyTo(IArray2<T> array, int offsetX, int offsetY);
    }
}
