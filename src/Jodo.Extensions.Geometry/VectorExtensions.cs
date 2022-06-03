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

using Jodo.Extensions.Numerics;

namespace Jodo.Extensions.Geometry
{
    public static class VectorExtensions
    {
        public static Vector2<N> RotateAround<N>(this Vector2<N> vector, Vector2<N> pivot, Angle<N> angle) where N : struct, INumeric<N>
        {
            var newAngle = -angle;
            var difference = vector - pivot;
            return pivot + new Vector2<N>(
                (difference.X * newAngle.Cosine) - (difference.Y * newAngle.Sine),
                (difference.X * newAngle.Sine) + (difference.Y * newAngle.Cosine));
        }

        public static N GetLengthSquared<N>(this Vector2<N> vector) where N : struct, INumeric<N>
            => (vector.X * vector.X) + (vector.Y * vector.Y);

        public static N GetLength<N>(this Vector2<N> vector) where N : struct, INumeric<N>
            => Math<N>.Sqrt(vector.GetLengthSquared());

        public static N DistanceFrom<N>(this Vector2<N> vector, Vector2<N> point) where N : struct, INumeric<N>
            => Math<N>.Sqrt(Math<N>.Pow(vector.X - point.X, Numeric<N>.Two) + Math<N>.Pow(vector.Y - point.Y, Numeric<N>.Two));

        public static Vector2<N> Translate<N>(this Vector2<N> vector, Vector2<N> delta) where N : struct, INumeric<N>
           => new Vector2<N>(vector.X + delta.X, vector.Y + delta.Y);

    }
}
