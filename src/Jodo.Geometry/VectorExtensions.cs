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

using Jodo.Numerics;

namespace Jodo.Geometry
{
    public static class VectorExtensions
    {
        public static Vector2N<TNumeric> RotateAround<TNumeric>(this Vector2N<TNumeric> vector, Vector2N<TNumeric> pivot, Angle<TNumeric> angle) where TNumeric : struct, INumeric<TNumeric>
        {
            Angle<TNumeric> newAngle = -angle;
            Vector2N<TNumeric> difference = vector - pivot;
            return pivot + new Vector2N<TNumeric>(
                difference.X.Multiply(newAngle.Cos()).Subtract(difference.Y.Multiply(newAngle.Sin())),
                difference.X.Multiply(newAngle.Sin()).Add(difference.Y.Multiply(newAngle.Cos())));
        }

        public static TNumeric GetLengthSquared<TNumeric>(this Vector2N<TNumeric> vector) where TNumeric : struct, INumeric<TNumeric>
            => vector.X.Multiply(vector.X).Add(vector.Y.Multiply(vector.Y));

        public static TNumeric GetLength<TNumeric>(this Vector2N<TNumeric> vector) where TNumeric : struct, INumeric<TNumeric>
            => MathN.Sqrt(vector.GetLengthSquared());

        public static TNumeric DistanceFrom<TNumeric>(this Vector2N<TNumeric> vector, Vector2N<TNumeric> point) where TNumeric : struct, INumeric<TNumeric>
            => MathN.Sqrt(vector.X.Subtract(point.X).Squared().Add(vector.Y.Subtract(point.Y).Squared()));

        public static Vector2N<TNumeric> Translate<TNumeric>(this Vector2N<TNumeric> vector, Vector2N<TNumeric> delta) where TNumeric : struct, INumeric<TNumeric>
           => new Vector2N<TNumeric>(vector.X.Add(delta.X), vector.Y.Add(delta.Y));
    }
}
