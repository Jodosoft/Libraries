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

#if NETSTANDARD2_0

using System;
using System.Runtime.CompilerServices;

namespace Jodo.Primitives.Compatibility
{
    public static class MathF
    {
        public const float E = 2.71828175F;
        public const float PI = 3.14159274F;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Abs(float value) => Math.Abs(value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Acos(float f) => (float)Math.Acos(f);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Acosh(float f) => (float)MathCompat.Acosh(f);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Asin(float f) => (float)Math.Asin(f);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Asinh(float f) => (float)MathCompat.Asinh(f);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Atan(float f) => (float)Math.Atan(f);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Atan2(float y, float x) => (float)Math.Atan2(y, x);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Atanh(float f) => (float)MathCompat.Atanh(f);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Cbrt(float f) => (float)Math.Pow(f, 1d / 3d);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Ceiling(float a) => (float)Math.Ceiling(a);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Cos(float f) => (float)Math.Cos(f);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Cosh(float value) => (float)Math.Cosh(value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Exp(float f) => (float)Math.Exp(f);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Floor(float f) => (float)Math.Floor(f);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float IEEERemainder(float x, float y) => (float)Math.IEEERemainder(x, y);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Log(float f) => (float)Math.Log(f);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Log(float f, float newBase) => (float)Math.Log(f, newBase);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Log10(float f) => (float)Math.Log10(f);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Max(float val1, float val2) => Math.Max(val1, val2);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Min(float val1, float val2) => Math.Min(val1, val2);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Pow(float val1, float val2) => (float)Math.Pow(val1, val2);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Round(float a) => (float)Math.Round(a);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Round(float value, int digits) => (float)Math.Round(value, digits);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Round(float value, int digits, MidpointRounding mode) => (float)Math.Round(value, digits, mode);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Round(float value, MidpointRounding mode) => (float)Math.Round(value, mode);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Sin(float a) => (float)Math.Sin(a);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Sinh(float value) => (float)Math.Sinh(value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Sqrt(float f) => (float)Math.Sqrt(f);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Tan(float a) => (float)Math.Tan(a);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Tanh(float value) => (float)Math.Tanh(value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Truncate(float f) => (float)Math.Truncate(f);
    }
}
#endif
