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

using Jodo.Extensions.Primitives;
using System.Collections.Generic;
using System.Numerics;

namespace System
{
    public static class RandomExtensions
    {
        public static bool NextBoolean(this Random random) => random.Next(0, 2) == 1;

        public static byte NextByte(this Random random) => (byte)random.Next(256);
        public static byte NextByte(this Random random, in byte bound1, in byte bound2) => (byte)random.Next(Math.Min(bound1, bound2), Math.Max(bound1, bound2) + 1);

        public static short NextInt16(this Random random) => NextInt16(random, short.MinValue, short.MaxValue);
        public static short NextInt16(this Random random, in short bound1, in short bound2) => (short)random.Next(Math.Min(bound1, bound2), Math.Max(bound1, bound2) + 1);

        public static ushort NextUInt16(this Random random) => NextUInt16(random, ushort.MinValue, ushort.MaxValue);
        public static ushort NextUInt16(this Random random, in ushort bound1, in ushort bound2) => (ushort)random.Next(Math.Min(bound1, bound2), Math.Max(bound1, bound2) + 1);

        public static int NextInt32(this Random random) => BitConverter.ToInt32(random.NextBytes(4));
        public static int NextInt32(this Random random, in int bound1, in int bound2)
        {
            var min = Math.Min(bound1, bound2);
            var max = Math.Max(bound1, bound2);

            var range = new BigInteger(max) - new BigInteger(min);
            var mask = (byte)(Math.Pow(2, 1 + (Math.Ceiling(BigInteger.Log(range, 2)) % 8)) - 1);
            var bytes = range.ToByteArray();
            BigInteger result;
            do
            {
                random.NextBytes(bytes);
                bytes[0] = (byte)(bytes[0] & mask);
                result = new BigInteger(bytes, true, true);
            } while (result > range);

            return (int)(min + result);
        }
        public static uint NextUInt32(this Random random) => BitConverter.ToUInt32(random.NextBytes(32));

        public static long NextInt64(this Random random) => BitConverter.ToInt64(random.NextBytes(64));

        public static ulong NextUInt64(this Random random) => BitConverter.ToUInt64(random.NextBytes(64));

        public static float NextSingle(this Random random) => random.NextSingle(float.MinValue, float.MaxValue);

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

        public static T NextElement<T>(this Random random, IReadOnlyList<T> list) => list[random.Next(0, list.Count)];
        public static T NextElement<T>(this Random random, in Span<T> span) => span[random.Next(0, span.Length)];
        public static T NextElement<T>(this Random random, in ReadOnlySpan<T> span) => span[random.Next(0, span.Length)];

        public static T Choose<T>(this Random random, T item, params T[] items)
        {
            if (items != null && items.Length > 0)
            {
                var index = random.Next(0, items.Length + 1);
                return index == items.Length ? item : items[index];
            }
            return item;
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

        public static T NextRandomizable<T>(this Random random) where T : IRandomGenerator<T>, new()
        {
            return new T().GetNext(random);
        }

        public static T NextRandomizable<T>(this Random random, T bound1, T bound2) where T : IRandomGenerator<T>, new()
        {
            return new T().GetNext(random, bound1, bound2);
        }
    }
}
