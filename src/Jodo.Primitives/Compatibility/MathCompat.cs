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
using System.Runtime.CompilerServices;

namespace Jodo.Primitives.Compatibility
{
    public static class MathCompat
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Acosh(double d)
        {
#if NETSTANDARD2_1
            return Math.Acosh(d);
#else
            if (d < 1 || double.IsNaN(d)) return double.NaN;
            if (d == 1) return 0;
            if (d >= 3E9) return Math.Log(d) + Math.Log(2);
            if (d > 2) return Math.Log((2 * d) - (1 / (d + Math.Sqrt((d * d) - 1))));
            d--;
            return Math.Log(1 + (d + Math.Sqrt((2 * d) + (d * d))));
#endif
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Asinh(double d)
        {
#if NETSTANDARD2_1
            return Math.Asinh(d);
#else
            if (!DoubleCompat.IsFinite(d) || (d > -3E-09 && d < 3E-09)) return d;

            double r = d < 0 ? -d : d;

            if (r > 2) r = Math.Log((2 * r) + (1 / (Math.Sqrt((r * r) + 1) + r)));
            else r = Math.Log(1 + (r + (r * r / (1 + Math.Sqrt(1 + (r * r))))));

            return d < 0 ? -r : r;
#endif
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Atanh(double d)
        {
#if NETSTANDARD2_1
            return Math.Atanh(d);
#else
            if (!DoubleCompat.IsFinite(d) || (d > -3E-09 && d < 3E-09)) return d;
            if (d < -1) return double.NegativeInfinity;
            if (d > 1) return double.PositiveInfinity;

            double r = d < 0 ? -d : d;
            if (r < 0.5) r = 0.5 * Math.Log(1 + (r + r + ((r + r) * r / (1 - r))));
            else r = 0.5 * Math.Log(1 + ((r + r) / (1 - r)));

            return d < 0 ? -r : r;
#endif
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Cbrt(double d)
        {
#if NETSTANDARD2_1
            return Math.Cbrt(d);
#else
            const double Exponent = 1d / 3d;
            if (d < 0) return -Math.Pow(-d, Exponent);
            return Math.Pow(d, Exponent);
#endif
        }

        public static double BitDecrement(double x)
        {
#if NETCOREAPP3_0_OR_GREATER
            return Math.BitDecrement(x);
#else
            long bits = BitConverter.DoubleToInt64Bits(x);

            if (((bits >> 32) & 0x7FF00000) >= 0x7FF00000)
            {
                return (bits == 0x7FF00000_00000000) ? double.MaxValue : x;
            }

            if (bits == 0x00000000_00000000)
            {
                return -double.Epsilon;
            }
            bits += (bits < 0) ? +1 : -1;
            return BitConverter.Int64BitsToDouble(bits);
#endif
        }

        public static double BitIncrement(double x)
        {
#if NETCOREAPP3_0_OR_GREATER
            return Math.BitIncrement(x);
#else
            long bits = BitConverter.DoubleToInt64Bits(x);

            if (((bits >> 32) & 0x7FF00000) >= 0x7FF00000)
            {
                return (bits == unchecked((long)0xFFF00000_00000000)) ? double.MinValue : x;
            }

            if (bits == unchecked((long)0x80000000_00000000))
            {
                return double.Epsilon;
            }
            bits += (bits < 0) ? -1 : +1;
            return BitConverter.Int64BitsToDouble(bits);
#endif
        }
    }
}
