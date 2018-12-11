namespace SuperSocket.Common
{
    /// <summary>
    /// Array segment extension
    /// </summary>
    /// <typeparam name="T"></typeparam>
    class ArraySegmentEx<T>
    {
        public ArraySegmentEx(T[] array, int offset, int count)
        {
            Array = array;
            Offset = offset;
            Count = count;
        }
        
        /// <summary>
        /// Gets the array.
        /// </summary>
        public T[] Array { get; private set; }

        /// <summary>
        /// Gets the count.
        /// </summary>
        public int Count { get; private set; }

        /// <summary>
        /// Gets the offset.
        /// </summary>
        public int Offset { get; private set; }

        /// <summary>
        /// From
        /// </summary>
        public int From { get; set; }

        /// <summary>
        /// To
        /// </summary>
        public int To { get; set; }
    }
}
