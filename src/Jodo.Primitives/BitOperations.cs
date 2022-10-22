// Copyright (c) 2022 Joseph J. Short
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to
// deal in the Software without restriction, including without limitation the
// rights to use, copy, modify, merge, publish, distribute, sublicense, and/or
// sell copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING
// FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS
// IN THE SOFTWARE.

using System;

namespace Jodo.Primitives
{
    // This class will replace the version the Jodo.Numerics namespace in version 2.0
    internal static class BitOperations
    {
        private const string IndexOutOfRange = "Index was out of range. Must be non-negative and less than the size of the collection.";
        private const string NotLongEnough = "Destination array is not long enough to copy all the items in the collection. Check array index and length.";

        public static byte[] GetBytes(decimal value)
        {
            byte[] result = new byte[sizeof(decimal)];
            int[] parts = decimal.GetBits(value);
            Buffer.BlockCopy(parts, 0, result, 0, result.Length);
            return result;
        }

        public static decimal ToDecimal(byte[] value, int startIndex)
        {
            if (value == null) throw new ArgumentNullException(nameof(value));

            if (startIndex >= value.Length) throw new ArgumentOutOfRangeException(nameof(startIndex), startIndex, IndexOutOfRange);

            if (startIndex > value.Length - sizeof(decimal)) throw new ArgumentException(NotLongEnough, nameof(value));

            int part0 = BitConverter.ToInt32(value, startIndex);
            int part1 = BitConverter.ToInt32(value, startIndex + sizeof(int));
            int part2 = BitConverter.ToInt32(value, startIndex + sizeof(int) + sizeof(int));
            int part3 = BitConverter.ToInt32(value, startIndex + sizeof(int) + sizeof(int) + sizeof(int));

            bool sign = (part3 & 0x80000000) != 0;
            byte scale = (byte)((part3 >> 16) & 0x7F);

            decimal result = new decimal(part0, part1, part2, sign, scale);
            return result;
        }
    }
}
