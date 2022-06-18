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
using Jodo.Numerics;

namespace Jodo.Geometry
{
    [CLSCompliant(false)]
    public static class VectorExtensions
    {
        public static Vector2<N> RotateAround<N>(this Vector2<N> vector, Vector2<N> pivot, Angle<N> angle) where N : struct, INumeric<N>
        {
            Angle<N> newAngle = -angle;
            Vector2<N> difference = vector - pivot;
            return pivot + new Vector2<N>(
                difference.X.Multiply(newAngle.Cos()).Subtract(difference.Y.Multiply(newAngle.Sin())),
                difference.X.Multiply(newAngle.Sin()).Add(difference.Y.Multiply(newAngle.Cos())));
        }

        public static N GetLengthSquared<N>(this Vector2<N> vector) where N : struct, INumeric<N>
            => vector.X.Multiply(vector.X).Add(vector.Y.Multiply(vector.Y));

        public static N GetLength<N>(this Vector2<N> vector) where N : struct, INumeric<N>
            => Math<N>.Sqrt(vector.GetLengthSquared());

        public static N DistanceFrom<N>(this Vector2<N> vector, Vector2<N> point) where N : struct, INumeric<N>
            => Math<N>.Sqrt(vector.X.Subtract(point.X).Squared().Add(vector.Y.Subtract(point.Y).Squared()));

        public static Vector2<N> Translate<N>(this Vector2<N> vector, Vector2<N> delta) where N : struct, INumeric<N>
           => new Vector2<N>(vector.X.Add(delta.X), vector.Y.Add(delta.Y));
    }
}
