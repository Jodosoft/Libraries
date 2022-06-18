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
#if NETSTANDARD2_1_OR_GREATER
            return Math.Acosh(d);
#else
            // todo: near zero optimizations
            //Log1p(t + Sqrt(2*t+t*t))
            double t = d - 1;
            return Math.Log(1 + (t + Math.Sqrt((2 * t) + (t * t))));
#endif
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Asinh(double d)
        {
#if NETSTANDARD2_1_OR_GREATER
            return Math.Asinh(d);
#else
            // todo: near zero optimizations
            double result;
            bool negative = d < 0;
            result = negative ? -d : d;
            result = Math.Log(1 + (result * result / (1 + Math.Sqrt(result + (result * result)))));
            return negative ? -result : result;
#endif
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Atanh(double d)
        {
#if NETSTANDARD2_1_OR_GREATER
            return Math.Atanh(d);
#else
            // todo: near zero optimizations
            return -(.5d * Math.Log(1 + ((d + d) / (1 - d))));
#endif
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Cbrt(double d)
        {
#if NETSTANDARD2_1_OR_GREATER
            return Math.Cbrt(d);
#else
            return Math.Pow(d, 1d / 3d);
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
            bits += ((bits < 0) ? +1 : -1);
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
                return (bits == unchecked((long)(0xFFF00000_00000000))) ? double.MinValue : x;
            }

            if (bits == unchecked((long)(0x80000000_00000000)))
            {
                return double.Epsilon;
            }
            bits += ((bits < 0) ? -1 : +1);
            return BitConverter.Int64BitsToDouble(bits);
#endif
        }
    }
}
