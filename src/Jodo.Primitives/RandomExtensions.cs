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

using System.Collections.Generic;
using System.Numerics;
using System.Runtime.CompilerServices;
using Jodo.Primitives;
using Jodo.Primitives.Compatibility;

namespace System
{
    public static class RandomExtensions
    {
        public static T Choose<T>(this Random random, T item, params T[] items)
        {
            if (items != null && items.Length > 0)
            {
                int index = random.Next(0, items.Length + 1);
                return index == items.Length ? item : items[index];
            }
            return item;
        }

        public static bool NextBoolean(this Random random)
            => random.Next(0, 2) == 1;

        public static byte NextByte(this Random random)
            => (byte)random.Next(256);

        public static byte NextByte(this Random random, byte bound1, byte bound2)
            => (byte)random.Next(Math.Min(bound1, bound2), Math.Max(bound1, bound2) + 1);

        [CLSCompliant(false)]
        public static sbyte NextSByte(this Random random)
            => (sbyte)random.Next(sbyte.MinValue, sbyte.MaxValue + 1);

        [CLSCompliant(false)]
        public static sbyte NextSByte(this Random random, sbyte bound1, sbyte bound2)
            => (sbyte)random.Next(Math.Min(bound1, bound2), Math.Max(bound1, bound2) + 1);

        public static short NextInt16(this Random random)
            => NextInt16(random, short.MinValue, short.MaxValue);

        public static short NextInt16(this Random random, short bound1, short bound2)
            => (short)random.Next(Math.Min(bound1, bound2), Math.Max(bound1, bound2) + 1);

        [CLSCompliant(false)]
        public static ushort NextUInt16(this Random random)
            => NextUInt16(random, ushort.MinValue, ushort.MaxValue);

        [CLSCompliant(false)]
        public static ushort NextUInt16(this Random random, ushort bound1, ushort bound2)
            => (ushort)random.Next(Math.Min(bound1, bound2), Math.Max(bound1, bound2) + 1);

        public static int NextInt32(this Random random)
            => BitConverter.ToInt32(random.NextBytes(4), 0);

        public static int NextInt32(this Random random, int bound1, int bound2)
            => (int)random.NextBigInteger(bound1, bound2);

        [CLSCompliant(false)]
        public static uint NextUInt32(this Random random)
            => BitConverter.ToUInt32(random.NextBytes(32), 0);

        [CLSCompliant(false)]
        public static uint NextUInt32(this Random random, uint bound1, uint bound2)
            => (uint)random.NextBigInteger(bound1, bound2);

        public static long NextInt64(this Random random)
            => BitConverter.ToInt64(random.NextBytes(64), 0);

        public static long NextInt64(this Random random, long bound1, long bound2)
            => (long)random.NextBigInteger(bound1, bound2);

        [CLSCompliant(false)]
        public static ulong NextUInt64(this Random random)
            => BitConverter.ToUInt64(random.NextBytes(64), 0);

        [CLSCompliant(false)]
        public static ulong NextUInt64(this Random random, ulong bound1, ulong bound2)
            => (ulong)random.NextBigInteger(bound1, bound2);

        private static BigInteger NextBigInteger(this Random random, BigInteger bound1, BigInteger bound2)
        {
            if (bound1 == bound2) return bound1;
            ValueTupleCompat.Swap(bound1 > bound2, ref bound1, ref bound2);
            BigInteger range = bound2 - bound1;

            byte[] bytes = range.ToByteArray();
            BigInteger result;
            do
            {
                random.NextBytes(bytes);
                result = new BigInteger(bytes);
            } while (result > range || result < 0);

            BigInteger rval = bound1 + result;
            return rval;
        }

        public static float NextSingle(this Random random)
            => random.NextSingle(float.MinValue, float.MaxValue);

        public static float NextSingle(this Random random, float bound1, float bound2)
        {
            if (!SingleCompat.IsFinite(bound1)) throw new ArgumentOutOfRangeException(nameof(bound1), bound1, "Must be finite.");
            if (!SingleCompat.IsFinite(bound2)) throw new ArgumentOutOfRangeException(nameof(bound2), bound2, "Must be finite.");
            ValueTupleCompat.Swap(bound1 > bound2, ref bound1, ref bound2);
            if (bound1 == bound2) return bound1;

            int minBits = BitConverterCompat.SingleToInt32Bits(bound1);
            int maxBits = BitConverterCompat.SingleToInt32Bits(bound2);

            int index = random.Next(bound1 < 0 ? int.MinValue - minBits : minBits, (bound2 < 0 ? int.MinValue - maxBits : maxBits) + 1);
            return BitConverterCompat.Int32BitsToSingle(index < 0 ? int.MinValue - index : index);
        }

        public static decimal NextDecimal(this Random random) => new decimal(random.NextInt32(), random.NextInt32(), random.NextInt32(), random.NextBoolean(), random.NextByte(0, 28));

        public static decimal NextDecimal(this Random random, decimal bound1, decimal bound2)
        {
            if (bound1 == bound2) return bound1;
            ValueTupleCompat.Swap(bound1 > bound2, ref bound1, ref bound2);

            decimal difference;
            try
            {
                checked { difference = bound2 - bound1; }

                decimal scalar = (decimal)(random.Next() / (1.0 * (int.MaxValue - 1)));
                decimal result = bound1 + (difference * scalar);
                return result;
            }
            catch (OverflowException)
            {
                decimal result;
                do
                {
                    result = new decimal(
                        random.NextInt32(),
                        random.NextInt32(),
                        random.NextInt32(),
                        random.NextBoolean(),
                        random.NextByte(0, 28));
                } while (result < bound1 || result > bound2);
                return result;
            }
        }

#if !NETSTANDARD2_0_OR_GREATER
        [MethodImpl(MethodImplOptions.NoOptimization)] // optimizer issue
#endif
        public static double NextDouble(this Random random, double bound1, double bound2)
        {
            if (!DoubleCompat.IsFinite(bound1)) throw new ArgumentOutOfRangeException(nameof(bound1), bound1, "Must be finite.");
            if (!DoubleCompat.IsFinite(bound2)) throw new ArgumentOutOfRangeException(nameof(bound2), bound2, "Must be finite.");
            if (bound1 == bound2) return bound1;
            ValueTupleCompat.Swap(bound1 > bound2, ref bound1, ref bound2);

            double difference = bound2 - bound1;
            if (double.IsPositiveInfinity(difference))
            {
                double result;
                do
                {
                    result = BitConverter.ToDouble(random.NextBytes(8), 0);
                } while (!DoubleCompat.IsFinite(result) || result < bound1 || result > bound2);
                return result;
            }
            else
            {
                double scalar = random.Next() / (1.0 * (int.MaxValue - 1));
                double result = bound1 + (difference * scalar);
                return result;
            }
        }

        public static T NextElement<T>(this Random random, IReadOnlyList<T> list)
            => list[random.Next(0, list.Count)];

#if NETSTANDARD2_1
        public static T NextElement<T>(this Random random, Span<T> span)
            => span[random.Next(0, span.Length)];

        public static T NextElement<T>(this Random random, ReadOnlySpan<T> span)
            => span[random.Next(0, span.Length)];

       
#endif

        public static byte[] NextBytes(this Random random, int count)
        {
            byte[]? bytes = new byte[count];
            random.NextBytes(bytes);
            return bytes;
        }

        public static TEnum NextEnum<TEnum>(this Random random) where TEnum : Enum
        {
            Array? values = Enum.GetValues(typeof(TEnum));
            return (TEnum)values.GetValue(random.Next(0, values.Length));
        }

        public static T NextRandomizable<T>(this Random random) where T : struct, IProvider<IRandom<T>>
            => default(T).GetInstance().Next(random);

        public static T NextRandomizable<T>(this Random random, T bound1, T bound2) where T : struct, IProvider<IRandom<T>>
            => default(T).GetInstance().Next(random, bound1, bound2);
    }
}
