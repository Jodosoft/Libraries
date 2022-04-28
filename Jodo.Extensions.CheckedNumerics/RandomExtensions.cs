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

using Jodo.Extensions.CheckedNumerics;
using System.Collections.Generic;
using System.Numerics;

namespace System
{
    public static class RandomExtensions
    {
        public static T Next<T>(this Random random, IReadOnlyList<T> list) => list[random.Next(0, list.Count)];
        public static T Next<T>(this Random random, ReadOnlySpan<T> span) => span[random.Next(0, span.Length)];
        public static T Next<T>(this Random random, T minInclusive, T maxInclusive) where T : struct, INumeric<T> => default(T).Next(random, minInclusive, maxInclusive);
        public static T NextNumeric<T>(this Random random) where T : struct, INumeric<T> => default(T).Next(random, default(T).MinValue, default(T).MaxValue);
        public static bool NextBoolean(this Random random) => random.Next(0, 2) == 1;
        public static byte NextByte(this Random random) => (byte)random.Next(256);
        public static byte NextByte(this Random random, byte maxValue) => (byte)random.Next(maxValue);
        public static byte NextByte(this Random random, byte minValue, byte maxValue) => (byte)random.Next(minValue, maxValue);
        public static int NextInt32(this Random random) => BitConverter.ToInt32(random.NextBytes(32));
        public static long NextInt64(this Random random) => BitConverter.ToInt64(random.NextBytes(64));
        public static short NextInt16(this Random random) => BitConverter.ToInt16(random.NextBytes(16));
        public static uint NextUInt32(this Random random) => BitConverter.ToUInt32(random.NextBytes(32));
        public static ulong NextUInt64(this Random random) => BitConverter.ToUInt64(random.NextBytes(64));
        public static ushort NextUInt16(this Random random) => BitConverter.ToUInt16(random.NextBytes(16));
        public static float NextSingle(this Random random) => random.NextSingle(float.MinValue, float.MaxValue);
        public static fix64 NextFix64(this Random random) => fix64.FromBytes(random.NextBytes(64));

        public static float NextSingle(this Random random, float minValue, float maxValue)
        {
            if (!float.IsFinite(minValue)) throw new ArgumentOutOfRangeException(nameof(minValue), minValue, "Must be finite.");
            if (!float.IsFinite(maxValue)) throw new ArgumentOutOfRangeException(nameof(maxValue), maxValue, "Must be finite.");
            if (minValue > maxValue) throw new ArgumentOutOfRangeException(nameof(minValue), minValue, $"{nameof(minValue)}' cannot be greater than {nameof(maxValue)}");
            if (minValue == maxValue) return minValue;

            var minBits = BitConverter.SingleToInt32Bits(minValue);
            var maxBits = BitConverter.SingleToInt32Bits(maxValue);
            var index = random.Next(minValue < 0 ? int.MinValue - minBits : minBits, (maxValue < 0 ? int.MinValue - maxBits : maxBits) + 1);
            return BitConverter.Int32BitsToSingle(index < 0 ? int.MinValue - index : index);
        }

        public static double NextDouble(this Random random, double minValue, double maxValue)
        {
            if (!double.IsFinite(minValue)) throw new ArgumentOutOfRangeException(nameof(minValue), minValue, "Must be finite.");
            if (!double.IsFinite(maxValue)) throw new ArgumentOutOfRangeException(nameof(maxValue), maxValue, "Must be finite.");
            if (minValue > maxValue) throw new ArgumentOutOfRangeException(nameof(minValue), minValue, $"{nameof(minValue)}' cannot be greater than {nameof(maxValue)}");
            if (minValue == maxValue) return minValue;

            var minBits = BitConverter.DoubleToInt64Bits(minValue);
            var maxBits = BitConverter.DoubleToInt64Bits(maxValue);
            var index = random.NextInt64(minValue < 0 ? long.MinValue - minBits : minBits, (maxValue < 0 ? long.MinValue - maxBits : maxBits) + 1);
            return BitConverter.Int64BitsToDouble(index < 0 ? long.MinValue - index : index);
        }

        public static int NextInt32(this Random random, int minValue, int maxValue)
        {
            if (minValue > maxValue) throw new ArgumentOutOfRangeException(nameof(minValue), minValue, $"{nameof(minValue)}' cannot be greater than {nameof(maxValue)}");
            if (minValue == maxValue) return minValue;

            var range = new BigInteger(maxValue) - new BigInteger(minValue);
            var mask = (byte)(Math.Pow(2, 1 + (Math.Ceiling(BigInteger.Log(range, 2)) % 8)) - 1);
            var bytes = range.ToByteArray();
            BigInteger result;
            do
            {
                random.NextBytes(bytes);
                bytes[0] = (byte)(bytes[0] & mask);
                result = new BigInteger(bytes, true, true);
            } while (result > range);

            return (int)(minValue + result);
        }

        public static uint NextUInt32(this Random random, uint minValue, uint maxValue)
        {
            if (minValue > maxValue) throw new ArgumentOutOfRangeException(nameof(minValue), minValue, $"{nameof(minValue)}' cannot be greater than {nameof(maxValue)}");
            if (minValue == maxValue) return minValue;

            var range = new BigInteger(maxValue) - new BigInteger(minValue);
            var mask = (byte)(Math.Pow(2, 1 + (Math.Ceiling(BigInteger.Log(range, 2)) % 8)) - 1);
            var bytes = range.ToByteArray();
            BigInteger result;
            do
            {
                random.NextBytes(bytes);
                bytes[0] = (byte)(bytes[0] & mask);
                result = new BigInteger(bytes, true, true);
            } while (result > range);

            return (uint)(minValue + result);
        }

        public static long NextInt64(this Random random, long minValue, long maxValue)
        {
            if (minValue > maxValue) throw new ArgumentOutOfRangeException(nameof(minValue), minValue, $"{nameof(minValue)}' cannot be greater than {nameof(maxValue)}");
            if (minValue == maxValue) return minValue;

            var range = new BigInteger(maxValue) - new BigInteger(minValue);
            var mask = (byte)(Math.Pow(2, 1 + (Math.Ceiling(BigInteger.Log(range, 2)) % 8)) - 1);
            var bytes = range.ToByteArray();
            BigInteger result;
            do
            {
                random.NextBytes(bytes);
                bytes[0] = (byte)(bytes[0] & mask);
                result = new BigInteger(bytes, true, true);
            } while (result > range);

            return (long)(minValue + result);
        }

        public static ulong NextUInt64(this Random random, ulong minValue, ulong maxValue)
        {
            if (minValue > maxValue) throw new ArgumentOutOfRangeException(nameof(minValue), minValue, $"{nameof(minValue)}' cannot be greater than {nameof(maxValue)}");
            if (minValue == maxValue) return minValue;

            var range = new BigInteger(maxValue) - new BigInteger(minValue);
            var mask = (byte)(Math.Pow(2, 1 + (Math.Ceiling(BigInteger.Log(range, 2)) % 8)) - 1);
            var bytes = range.ToByteArray();
            BigInteger result;
            do
            {
                random.NextBytes(bytes);
                bytes[0] = (byte)(bytes[0] & mask);
                result = new BigInteger(bytes, true, true);
            } while (result > range);

            return (ulong)(minValue + result);
        }

        public static fix64 NextFix64(this Random random, fix64 minValue, fix64 maxValue)
        {
            if (minValue > maxValue) throw new ArgumentOutOfRangeException(nameof(minValue), minValue, $"{nameof(minValue)}' cannot be greater than {nameof(maxValue)}");
            if (minValue == maxValue) return minValue;

            return fix64.FromInternalRepresentation(
                random.NextInt64(fix64.GetInternalRepresentation(minValue), fix64.GetInternalRepresentation(maxValue)));
        }

        public static TEnum NextEnum<TEnum>(this Random random) where TEnum : Enum
        {
            var values = Enum.GetValues(typeof(TEnum));
            return (TEnum)values.GetValue(random.Next(0, values.Length));
        }

        public static ReadOnlySpan<byte> NextBytes(this Random random, int count)
        {
            var bytes = new byte[count];
            random.NextBytes(bytes);
            return new ReadOnlySpan<byte>(bytes);
        }
    }
}
