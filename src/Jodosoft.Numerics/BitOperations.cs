﻿// Copyright (c) 2023 Joe Lawry-Short
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

namespace Jodosoft.Numerics
{
    public static class BitOperations
    {
        private const string IndexOutOfRange = "Index was out of range. Must be non-negative and less than the size of the collection.";
        private const string NotLongEnough = "Destination array is not long enough to copy all the items in the collection. Check array index and length.";

        public static float BitwiseComplement(float left)
        {
            int leftBits = BitConverter.ToInt32(BitConverter.GetBytes(left), 0);
            return BitConverter.ToSingle(BitConverter.GetBytes(~leftBits), 0);
        }

        public static double BitwiseComplement(double left)
        {
            long leftBits = BitConverter.ToInt64(BitConverter.GetBytes(left), 0);
            return BitConverter.ToDouble(BitConverter.GetBytes(~leftBits), 0);
        }

        public static decimal BitwiseComplement(decimal left)
        {
            int[]? bits = decimal.GetBits(left);
            bits[0] = ~bits[0];
            bits[1] = ~bits[1];
            bits[2] = ~bits[2];
            return new decimal(bits);
        }

        public static float LeftShift(float left, int right)
        {
            int leftBits = BitConverter.ToInt32(BitConverter.GetBytes(left), 0);
            return BitConverter.ToSingle(BitConverter.GetBytes(leftBits << right), 0);
        }

        public static double LeftShift(double left, int right)
        {
            long leftBits = BitConverter.ToInt64(BitConverter.GetBytes(left), 0);
            return BitConverter.ToDouble(BitConverter.GetBytes(leftBits << right), 0);
        }

        public static decimal LeftShift(decimal left, int right)
        {
            int[]? leftBits = decimal.GetBits(left);
            leftBits[0] = leftBits[0] << right;
            leftBits[1] = leftBits[1] << right;
            leftBits[2] = leftBits[2] << right;
            return new decimal(leftBits);
        }

        public static float LogicalAnd(float left, float right)
        {
            int leftBits = BitConverter.ToInt32(BitConverter.GetBytes(left), 0);
            int rightBits = BitConverter.ToInt32(BitConverter.GetBytes(right), 0);
            return BitConverter.ToSingle(BitConverter.GetBytes(leftBits & rightBits), 0);
        }

        public static double LogicalAnd(double left, double right)
        {
            long leftBits = BitConverter.ToInt64(BitConverter.GetBytes(left), 0);
            long rightBits = BitConverter.ToInt64(BitConverter.GetBytes(right), 0);
            return BitConverter.ToDouble(BitConverter.GetBytes(leftBits & rightBits), 0);
        }

        public static decimal LogicalAnd(decimal left, decimal right)
        {
            int[]? leftBits = decimal.GetBits(left);
            int[]? rightBits = decimal.GetBits(right);
            leftBits[0] = leftBits[0] & rightBits[0];
            leftBits[1] = leftBits[1] & rightBits[1];
            leftBits[2] = leftBits[2] & rightBits[2];
            return new decimal(leftBits);
        }

        public static float LogicalExclusiveOr(float left, float right)
        {
            int leftBits = BitConverter.ToInt32(BitConverter.GetBytes(left), 0);
            int rightBits = BitConverter.ToInt32(BitConverter.GetBytes(right), 0);
            return BitConverter.ToSingle(BitConverter.GetBytes(leftBits ^ rightBits), 0);
        }

        public static double LogicalExclusiveOr(double left, double right)
        {
            long leftBits = BitConverter.ToInt64(BitConverter.GetBytes(left), 0);
            long rightBits = BitConverter.ToInt64(BitConverter.GetBytes(right), 0);
            return BitConverter.ToDouble(BitConverter.GetBytes(leftBits ^ rightBits), 0);
        }

        public static decimal LogicalExclusiveOr(decimal left, decimal right)
        {
            int[]? leftBits = decimal.GetBits(left);
            int[]? rightBits = decimal.GetBits(right);
            leftBits[0] = leftBits[0] ^ rightBits[0];
            leftBits[1] = leftBits[1] ^ rightBits[1];
            leftBits[2] = leftBits[2] ^ rightBits[2];
            return new decimal(leftBits);
        }

        public static float LogicalOr(float left, float right)
        {
            int leftBits = BitConverter.ToInt32(BitConverter.GetBytes(left), 0);
            int rightBits = BitConverter.ToInt32(BitConverter.GetBytes(right), 0);
            return BitConverter.ToSingle(BitConverter.GetBytes(leftBits | rightBits), 0);
        }

        public static double LogicalOr(double left, double right)
        {
            long leftBits = BitConverter.ToInt64(BitConverter.GetBytes(left), 0);
            long rightBits = BitConverter.ToInt64(BitConverter.GetBytes(right), 0);
            return BitConverter.ToDouble(BitConverter.GetBytes(leftBits | rightBits), 0);
        }

        public static decimal LogicalOr(decimal left, decimal right)
        {
            int[]? leftBits = decimal.GetBits(left);
            int[]? rightBits = decimal.GetBits(right);
            leftBits[0] = leftBits[0] | rightBits[0];
            leftBits[1] = leftBits[1] | rightBits[1];
            leftBits[2] = leftBits[2] | rightBits[2];
            return new decimal(leftBits);
        }

        public static float RightShift(float left, int right)
        {
            int leftBits = BitConverter.ToInt32(BitConverter.GetBytes(left), 0);
            return BitConverter.ToSingle(BitConverter.GetBytes(leftBits >> right), 0);
        }

        public static double RightShift(double left, int right)
        {
            long leftBits = BitConverter.ToInt64(BitConverter.GetBytes(left), 0);
            return BitConverter.ToDouble(BitConverter.GetBytes(leftBits >> right), 0);
        }

        public static decimal RightShift(decimal left, int right)
        {
            int[]? leftBits = decimal.GetBits(left);
            leftBits[0] = leftBits[0] >> right;
            leftBits[1] = leftBits[1] >> right;
            leftBits[2] = leftBits[2] >> right;
            return new decimal(leftBits);
        }

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

#if HAS_SPANS
        public static decimal ToDecimal(ReadOnlySpan<byte> value)
        {
            if (value.Length < sizeof(decimal))
                throw new ArgumentOutOfRangeException(nameof(value));

            int part0 = BitConverter.ToInt32(value);
            int part1 = BitConverter.ToInt32(value.Slice(sizeof(int)));
            int part2 = BitConverter.ToInt32(value.Slice(sizeof(int) + sizeof(int)));
            int part3 = BitConverter.ToInt32(value.Slice(sizeof(int) + sizeof(int) + sizeof(int)));

            bool sign = (part3 & 0x80000000) != 0;
            byte scale = (byte)((part3 >> 16) & 0x7F);

            decimal result = new decimal(part0, part1, part2, sign, scale);

            return result;
        }
#endif

        public static byte ToByte(byte[] value, int startIndex)
        {
            if (value == null) throw new ArgumentNullException(nameof(value));

            if (startIndex >= value.Length) throw new ArgumentOutOfRangeException(nameof(startIndex), startIndex, IndexOutOfRange);

            if (startIndex > value.Length - sizeof(byte)) throw new ArgumentException(NotLongEnough, nameof(value));

            return value[startIndex];
        }

#if HAS_SPANS
        public static byte ToByte(ReadOnlySpan<byte> value)
        {
            if (value.Length < sizeof(byte))
                throw new ArgumentOutOfRangeException(nameof(value));

            return value[0];
        }
#endif

        [CLSCompliant(false)]
        public static sbyte ToSByte(byte[] value, int startIndex)
        {
            if (value == null) throw new ArgumentNullException(nameof(value));

            if (startIndex >= value.Length) throw new ArgumentOutOfRangeException(nameof(startIndex), startIndex, IndexOutOfRange);

            if (startIndex > value.Length - sizeof(byte)) throw new ArgumentException(NotLongEnough, nameof(value));

            return (sbyte)value[startIndex];
        }

#if HAS_SPANS
        [CLSCompliant(false)]
        public static sbyte ToSByte(ReadOnlySpan<byte> value)
        {
            if (value.Length < sizeof(sbyte))
                throw new ArgumentOutOfRangeException(nameof(value));

            return (sbyte)value[0];
        }
#endif

#if HAS_SPANS
        public static bool TryWriteByte(Span<byte> destination, byte value)
        {
            if (destination.Length < sizeof(byte))
                return false;

            destination[0] = value;
            return true;
        }

        [CLSCompliant(false)]
        public static bool TryWriteSByte(Span<byte> destination, sbyte value)
        {
            if (destination.Length < sizeof(sbyte))
                return false;

            destination[0] = (byte)value;
            return true;
        }

        public static bool TryWriteBytes(Span<byte> destination, decimal value)
        {
            if (destination.Length < sizeof(byte))
                return false;

            byte[] result = new byte[sizeof(decimal)];
            int[] parts = decimal.GetBits(value);
            Buffer.BlockCopy(parts, 0, result, 0, result.Length);
            result.CopyTo(destination);

            return true;
        }
#endif
    }
}
