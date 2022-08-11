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
using System.Text;
using Jodo.Primitives;

namespace Jodo.Testing
{
    public static class RandomExtensions
    {
        public static T NextExtreme<T>(this Random random)
        {
            if (typeof(T) == typeof(byte)) return (T)(object)random.NextByteExtreme();
            if (typeof(T) == typeof(decimal)) return (T)(object)random.NextDecimalExtreme();
            if (typeof(T) == typeof(double)) return (T)(object)random.NextDoubleExtreme();
            if (typeof(T) == typeof(float)) return (T)(object)random.NextSingleExtreme();
            if (typeof(T) == typeof(int)) return (T)(object)random.NextInt32Extreme();
            if (typeof(T) == typeof(long)) return (T)(object)random.NextInt64Extreme();
            if (typeof(T) == typeof(sbyte)) return (T)(object)random.NextSByteExtreme();
            if (typeof(T) == typeof(short)) return (T)(object)random.NextInt16Extreme();
            if (typeof(T) == typeof(uint)) return (T)(object)random.NextUInt32Extreme();
            if (typeof(T) == typeof(ulong)) return (T)(object)random.NextUInt64Extreme();
            if (typeof(T) == typeof(ushort)) return (T)(object)random.NextUInt16Extreme();

            if (typeof(T) == typeof(string)) return (T)(object)random.NextStringExtreme();

            throw new InvalidOperationException();
        }

        public static string NextStringExtreme(this Random random)
        {
            return random.Choose(
                null, string.Empty, "\t",
                "^.*$", $"<p>{Guid.NewGuid()}</p>", $"; DROP TABLE [{Guid.NewGuid()}]",
                random.NextDoubleExtreme().ToString(),
                Encoding.ASCII.GetString(random.NextBytes(100_000)),
                Encoding.UTF8.GetString(random.NextBytes(100_000)));
        }

        public static byte NextByteExtreme(this Random random)
        {
            return random.Choose(
                random.NextByte(byte.MinValue, byte.MaxValue),
                (byte)0, (byte)1, byte.MinValue, byte.MaxValue);
        }

        public static sbyte NextSByteExtreme(this Random random)
        {
            return random.Choose(
                random.NextSByte(sbyte.MinValue, sbyte.MaxValue),
                (sbyte)0, (sbyte)1, (sbyte)-1, sbyte.MinValue, sbyte.MaxValue);
        }

        public static short NextInt16Extreme(this Random random)
        {
            return random.Choose(
                random.NextInt16(short.MinValue, short.MaxValue),
                (short)0, (short)1, (short)-1, short.MinValue, short.MaxValue);
        }

        public static ushort NextUInt16Extreme(this Random random)
        {
            return random.Choose(
                random.NextUInt16(ushort.MinValue, ushort.MaxValue),
                (ushort)0, (ushort)1, ushort.MinValue, ushort.MaxValue);
        }

        public static int NextInt32Extreme(this Random random)
        {
            return random.Choose(
                random.NextInt32(int.MinValue, int.MaxValue),
                0, 1, -1, int.MinValue, int.MaxValue);
        }

        public static uint NextUInt32Extreme(this Random random)
        {
            return random.Choose(
                random.NextUInt32(uint.MinValue, uint.MaxValue),
                (uint)0, (uint)1, uint.MinValue, uint.MaxValue);
        }

        public static long NextInt64Extreme(this Random random)
        {
            return random.Choose(
                random.NextInt64(long.MinValue, long.MaxValue),
                0, 1, -1, long.MinValue, long.MaxValue);
        }

        public static ulong NextUInt64Extreme(this Random random)
        {
            return random.Choose(
                random.NextUInt64(ulong.MinValue, ulong.MaxValue),
                (ulong)0, (ulong)1, ulong.MinValue, ulong.MaxValue);
        }

        public static float NextSingleExtreme(this Random random)
        {
            return random.Choose(
                random.NextSingle(float.MinValue, float.MaxValue),
                0f, -0f, 1f, -1f,
                float.Epsilon, -float.Epsilon, float.MinValue, float.MaxValue,
                float.NaN, float.PositiveInfinity, float.NegativeInfinity);
        }

        public static double NextDoubleExtreme(this Random random)
        {
            return random.Choose(
                random.NextDouble(double.MinValue, double.MaxValue),
                0d, -0d, 1d, -1d,
                double.Epsilon, -double.Epsilon, double.MinValue, double.MaxValue,
                double.NaN, double.PositiveInfinity, double.NegativeInfinity);
        }

        public static decimal NextDecimalExtreme(this Random random)
        {
            return random.Choose(
                random.NextDecimal(decimal.MinValue, decimal.MaxValue),
                0m, -0m, 1m, -1m,
                decimal.MinValue, decimal.MaxValue);
        }
    }
}
