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

using System.Runtime.CompilerServices;

namespace Jodosoft.Numerics
{
    public static class VectorExtensions
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2N<TNumeric> Doubled<TNumeric>(this Vector2N<TNumeric> vector) where TNumeric : struct, INumeric<TNumeric>
        {
            return new Vector2N<TNumeric>(vector.X.Double(), vector.Y.Double());
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TNumeric Length<TNumeric>(this Vector2N<TNumeric> value) where TNumeric : struct, INumeric<TNumeric>
        {
            return MathN.Sqrt(value.LengthSquared());
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TNumeric LengthSquared<TNumeric>(this Vector2N<TNumeric> value) where TNumeric : struct, INumeric<TNumeric>
        {
            return Vector2N.Dot(value, value);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2N<TNumeric> Half<TNumeric>(this Vector2N<TNumeric> value) where TNumeric : struct, INumeric<TNumeric>
        {
            return new Vector2N<TNumeric>(value.X.Half(), value.Y.Half());
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2N<TNumeric> Add<TNumeric>(this Vector2N<TNumeric> value, Vector2N<TNumeric> amount) where TNumeric : struct, INumeric<TNumeric>
        {
            return value + amount;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2N<TNumeric> AddX<TNumeric>(this Vector2N<TNumeric> value, TNumeric x) where TNumeric : struct, INumeric<TNumeric>
        {
            return new Vector2N<TNumeric>(value.X.Add(x), value.Y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2N<TNumeric> AddY<TNumeric>(this Vector2N<TNumeric> value, TNumeric y) where TNumeric : struct, INumeric<TNumeric>
        {
            return new Vector2N<TNumeric>(value.X, value.Y.Add(y));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2N<TNumeric> Subtract<TNumeric>(this Vector2N<TNumeric> value, Vector2N<TNumeric> amount) where TNumeric : struct, INumeric<TNumeric>
        {
            return value - amount;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2N<TNumeric> SubtractX<TNumeric>(this Vector2N<TNumeric> value, TNumeric x) where TNumeric : struct, INumeric<TNumeric>
        {
            return new Vector2N<TNumeric>(value.X.Subtract(x), value.Y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2N<TNumeric> SubtractY<TNumeric>(this Vector2N<TNumeric> value, TNumeric y) where TNumeric : struct, INumeric<TNumeric>
        {
            return new Vector2N<TNumeric>(value.X, value.Y.Subtract(y));
        }
    }
}
