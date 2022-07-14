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

using System.Runtime.CompilerServices;

namespace Jodo.Numerics
{
    public static class VectorExtensions
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2<N> Double<N>(this Vector2<N> vector) where N : struct, INumeric<N>
        {
            return new Vector2<N>(vector.X.Double(), vector.Y.Double());
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static N Length<N>(this Vector2<N> value) where N : struct, INumeric<N>
        {
            return MathN.Sqrt(value.LengthSquared());
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static N LengthSquared<N>(this Vector2<N> value) where N : struct, INumeric<N>
        {
            return Vector2<N>.Dot(value, value);
        }

    }
}
