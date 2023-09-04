// Copyright (c) 2023 Joe Lawry-Short
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

namespace Jodosoft.Primitives.Compatibility
{
    public static class MathFShim
    {
        public const float E = 2.71828175F;
        public const float PI = 3.14159274F;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Abs(float value)
        {
#if NETSTANDARD2_1_OR_GREATER
            return MathF.Abs(value);
#else
            return Math.Abs(value);
#endif
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Acos(float f)
        {
#if NETSTANDARD2_1_OR_GREATER
            return MathF.Acos(f);
#else
            return (float)Math.Acos(f);
#endif
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Acosh(float f)
        {
#if NETSTANDARD2_1_OR_GREATER
            return MathF.Acosh(f);
#else
            return (float)MathShim.Acosh(f);
#endif
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Asin(float f)
        {
#if NETSTANDARD2_1_OR_GREATER
            return MathF.Asin(f);
#else
            return (float)Math.Asin(f);
#endif
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Asinh(float f)
        {
#if NETSTANDARD2_1_OR_GREATER
            return MathF.Asinh(f);
#else
            return (float)MathShim.Asinh(f);
#endif
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Atan(float f)
        {
#if NETSTANDARD2_1_OR_GREATER
            return MathF.Atan(f);
#else
            return (float)Math.Atan(f);
#endif
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Atan2(float y, float x)
        {
#if NETSTANDARD2_1_OR_GREATER
            return MathF.Atan2(y, x);
#else
            return (float)Math.Atan2(y, x);
#endif
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Atanh(float f)
        {
#if NETSTANDARD2_1_OR_GREATER
            return MathF.Atanh(f);
#else
            return (float)MathShim.Atanh(f);
#endif
        }

        public static float BitDecrement(float x)
        {
#if NETCOREAPP3_0_OR_GREATER
            return MathF.BitDecrement(x);
#else
            int bits = BitConverterShim.SingleToInt32Bits(x);

            if ((bits & 0x7F800000) >= 0x7F800000)
            {
                // NaN returns NaN
                // -Infinity returns -Infinity
                // +Infinity returns float.MaxValue
                return (bits == 0x7F800000) ? float.MaxValue : x;
            }

            if (bits == 0x00000000)
            {
                // +0.0 returns -float.Epsilon
                return -float.Epsilon;
            }

            // Negative values need to be incremented
            // Positive values need to be decremented

            bits += (bits < 0) ? +1 : -1;
            return BitConverterShim.Int32BitsToSingle(bits);
#endif
        }

        public static float BitIncrement(float x)
        {
#if NETCOREAPP3_0_OR_GREATER
            return MathF.BitIncrement(x);
#else
            int bits = BitConverterShim.SingleToInt32Bits(x);

            if ((bits & 0x7F800000) >= 0x7F800000)
            {
                // NaN returns NaN
                // -Infinity returns float.MinValue
                // +Infinity returns +Infinity
                return (bits == unchecked((int)0xFF800000)) ? float.MinValue : x;
            }

            if (bits == unchecked((int)0x80000000))
            {
                // -0.0 returns float.Epsilon
                return float.Epsilon;
            }

            // Negative values need to be decremented
            // Positive values need to be incremented

            bits += (bits < 0) ? -1 : +1;
            return BitConverterShim.Int32BitsToSingle(bits);
#endif
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Cbrt(float f)
        {
#if NETSTANDARD2_1_OR_GREATER
            return MathF.Cbrt(f);
#else
            return (float)MathShim.Cbrt(f);
#endif
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Ceiling(float f)
        {
#if NETSTANDARD2_1_OR_GREATER
            return MathF.Ceiling(f);
#else
            return (float)Math.Ceiling(f);
#endif
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Cos(float f)
        {
#if NETSTANDARD2_1_OR_GREATER
            return MathF.Cos(f);
#else
            return (float)Math.Cos(f);
#endif
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Cosh(float value)
        {
#if NETSTANDARD2_1_OR_GREATER
            return MathF.Cosh(value);
#else
            return (float)Math.Cosh(value);
#endif
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Exp(float f)
        {
#if NETSTANDARD2_1_OR_GREATER
            return MathF.Exp(f);
#else
            return (float)Math.Exp(f);
#endif
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Floor(float f)
        {
#if NETSTANDARD2_1_OR_GREATER
            return MathF.Floor(f);
#else
            return (float)Math.Floor(f);
#endif
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float IEEERemainder(float x, float y)
        {
#if NETSTANDARD2_1_OR_GREATER
            return MathF.IEEERemainder(x, y);
#else
            return (float)Math.IEEERemainder(x, y);
#endif
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Log(float f)
        {
#if NETSTANDARD2_1_OR_GREATER
            return MathF.Log(f);
#else
            return (float)Math.Log(f);
#endif
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Log(float f, float newBase)
        {
#if NETSTANDARD2_1_OR_GREATER
            return MathF.Log(f, newBase);
#else
            return (float)Math.Log(f, newBase);
#endif
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Log10(float f)
        {
#if NETSTANDARD2_1_OR_GREATER
            return MathF.Log10(f);
#else
            return (float)Math.Log10(f);
#endif
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Max(float val1, float val2)
        {
#if NETSTANDARD2_1_OR_GREATER
            return MathF.Max(val1, val2);
#else
            return Math.Max(val1, val2);
#endif
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Min(float val1, float val2)
        {
#if NETSTANDARD2_1_OR_GREATER
            return MathF.Min(val1, val2);
#else
            return Math.Min(val1, val2);
#endif
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Pow(float val1, float val2)
        {
#if NETSTANDARD2_1_OR_GREATER
            return MathF.Pow(val1, val2);
#else
            return (float)Math.Pow(val1, val2);
#endif
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Round(float a)
        {
#if NETSTANDARD2_1_OR_GREATER
            return MathF.Round(a);
#else
            return (float)Math.Round(a);
#endif
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Round(float value, int digits)
        {
#if NETSTANDARD2_1_OR_GREATER
            return MathF.Round(value, digits);
#else
            return (float)Math.Round(value, digits);
#endif
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Round(float value, int digits, MidpointRounding mode)
        {
#if NETSTANDARD2_1_OR_GREATER
            return MathF.Round(value, digits, mode);
#else
            return (float)Math.Round(value, digits, mode);
#endif
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Round(float value, MidpointRounding mode)
        {
#if NETSTANDARD2_1_OR_GREATER
            return MathF.Round(value, mode);
#else
            return (float)Math.Round(value, mode);
#endif
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Sin(float a)
        {
#if NETSTANDARD2_1_OR_GREATER
            return MathF.Sin(a);
#else
            return (float)Math.Sin(a);
#endif
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Sinh(float value)
        {
#if NETSTANDARD2_1_OR_GREATER
            return MathF.Sinh(value);
#else
            return (float)Math.Sinh(value);
#endif
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Sqrt(float f)
        {
#if NETSTANDARD2_1_OR_GREATER
            return MathF.Sqrt(f);
#else
            return (float)Math.Sqrt(f);
#endif
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Tan(float a)
        {
#if NETSTANDARD2_1_OR_GREATER
            return MathF.Tan(a);
#else
            return (float)Math.Tan(a);
#endif
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Tanh(float value)
        {
#if NETSTANDARD2_1_OR_GREATER
            return MathF.Tanh(value);
#else
            return (float)Math.Tanh(value);
#endif
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Truncate(float f)
        {
#if NETSTANDARD2_1_OR_GREATER
            return MathF.Truncate(f);
#else
            return (float)Math.Truncate(f);
#endif
        }
    }
}
