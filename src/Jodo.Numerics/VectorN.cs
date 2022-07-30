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
    public static class VectorN
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2<TNumeric> Abs<TNumeric>(Vector2<TNumeric> value) where TNumeric : struct, INumeric<TNumeric>
        {
            return new Vector2<TNumeric>(
                MathN.Abs(value.X),
                MathN.Abs(value.Y)
            );
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3<TNumeric> Abs<TNumeric>(Vector3<TNumeric> value) where TNumeric : struct, INumeric<TNumeric>
        {
            return new Vector3<TNumeric>(
                MathN.Abs(value.X),
                MathN.Abs(value.Y),
                MathN.Abs(value.Z)
            );
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2<TNumeric> Add<TNumeric>(Vector2<TNumeric> left, Vector2<TNumeric> right) where TNumeric : struct, INumeric<TNumeric>
        {
            return left + right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3<TNumeric> Add<TNumeric>(Vector3<TNumeric> left, Vector3<TNumeric> right) where TNumeric : struct, INumeric<TNumeric>
        {
            return left + right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2<TNumeric> Clamp<TNumeric>(Vector2<TNumeric> value1, Vector2<TNumeric> min, Vector2<TNumeric> max) where TNumeric : struct, INumeric<TNumeric>
        {
            return Min(Max(value1, min), max);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3<TNumeric> Clamp<TNumeric>(Vector3<TNumeric> value1, Vector3<TNumeric> min, Vector3<TNumeric> max) where TNumeric : struct, INumeric<TNumeric>
        {
            return Min(Max(value1, min), max);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3<TNumeric> Cross<TNumeric>(Vector3<TNumeric> vector1, Vector3<TNumeric> vector2) where TNumeric : struct, INumeric<TNumeric>
        {
            return new Vector3<TNumeric>(
                vector1.Y.Multiply(vector2.Z).Subtract(vector1.Z.Multiply(vector2.Y)),
                vector1.Z.Multiply(vector2.X).Subtract(vector1.X.Multiply(vector2.Z)),
                vector1.X.Multiply(vector2.Y).Subtract(vector1.Y.Multiply(vector2.X))
            );
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TNumeric Distance<TNumeric>(Vector2<TNumeric> value1, Vector2<TNumeric> value2) where TNumeric : struct, INumeric<TNumeric>
        {
            return MathN.Sqrt(DistanceSquared(value1, value2));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TNumeric Distance<TNumeric>(Vector3<TNumeric> value1, Vector3<TNumeric> value2) where TNumeric : struct, INumeric<TNumeric>
        {
            return MathN.Sqrt(DistanceSquared(value1, value2));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TNumeric DistanceSquared<TNumeric>(Vector2<TNumeric> value1, Vector2<TNumeric> value2) where TNumeric : struct, INumeric<TNumeric>
        {
            Vector2<TNumeric> difference = value1 - value2;
            return Dot(difference, difference);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TNumeric DistanceSquared<TNumeric>(Vector3<TNumeric> value1, Vector3<TNumeric> value2) where TNumeric : struct, INumeric<TNumeric>
        {
            Vector3<TNumeric> difference = value1 - value2;
            return Dot(difference, difference);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2<TNumeric> Divide<TNumeric>(Vector2<TNumeric> left, Vector2<TNumeric> right) where TNumeric : struct, INumeric<TNumeric>
        {
            return left / right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2<TNumeric> Divide<TNumeric>(Vector2<TNumeric> left, TNumeric divisor) where TNumeric : struct, INumeric<TNumeric>
        {
            return left / divisor;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3<TNumeric> Divide<TNumeric>(Vector3<TNumeric> left, Vector3<TNumeric> right) where TNumeric : struct, INumeric<TNumeric>
        {
            return left / right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3<TNumeric> Divide<TNumeric>(Vector3<TNumeric> left, TNumeric divisor) where TNumeric : struct, INumeric<TNumeric>
        {
            return left / divisor;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TNumeric Dot<TNumeric>(Vector2<TNumeric> value1, Vector2<TNumeric> value2) where TNumeric : struct, INumeric<TNumeric>
        {
            return value1.X.Multiply(value2.X).Add(value1.Y.Multiply(value2.Y));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TNumeric Dot<TNumeric>(Vector3<TNumeric> vector1, Vector3<TNumeric> vector2) where TNumeric : struct, INumeric<TNumeric>
        {
            return vector1.X.Multiply(vector2.X)
                 .Add(vector1.Y.Multiply(vector2.Y))
                 .Add(vector1.Z.Multiply(vector2.Z));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2<TNumeric> Lerp<TNumeric>(Vector2<TNumeric> value1, Vector2<TNumeric> value2, TNumeric amount) where TNumeric : struct, INumeric<TNumeric>
        {
            return (value1 * Numeric.One<TNumeric>().Subtract(amount)) + (value2 * amount);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3<TNumeric> Lerp<TNumeric>(Vector3<TNumeric> value1, Vector3<TNumeric> value2, TNumeric amount) where TNumeric : struct, INumeric<TNumeric>
        {
            return (value1 * Numeric.One<TNumeric>().Subtract(amount)) + (value2 * amount);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2<TNumeric> Max<TNumeric>(Vector2<TNumeric> value1, Vector2<TNumeric> value2) where TNumeric : struct, INumeric<TNumeric>
        {
            return new Vector2<TNumeric>(
                MathN.Max(value1.X, value2.X),
                MathN.Max(value1.Y, value2.Y));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3<TNumeric> Max<TNumeric>(Vector3<TNumeric> value1, Vector3<TNumeric> value2) where TNumeric : struct, INumeric<TNumeric>
        {
            return new Vector3<TNumeric>(
                MathN.Max(value1.X, value2.X),
                MathN.Max(value1.Y, value2.Y),
                MathN.Max(value1.Z, value2.Z));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2<TNumeric> Min<TNumeric>(Vector2<TNumeric> value1, Vector2<TNumeric> value2) where TNumeric : struct, INumeric<TNumeric>
        {
            return new Vector2<TNumeric>(
                MathN.Min(value1.X, value2.X),
                MathN.Min(value1.Y, value2.Y));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3<TNumeric> Min<TNumeric>(Vector3<TNumeric> value1, Vector3<TNumeric> value2) where TNumeric : struct, INumeric<TNumeric>
        {
            return new Vector3<TNumeric>(
                MathN.Min(value1.X, value2.X),
                MathN.Min(value1.Y, value2.Y),
                MathN.Min(value1.Z, value2.Z));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2<TNumeric> Multiply<TNumeric>(Vector2<TNumeric> left, Vector2<TNumeric> right) where TNumeric : struct, INumeric<TNumeric>
        {
            return left * right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2<TNumeric> Multiply<TNumeric>(Vector2<TNumeric> left, TNumeric right) where TNumeric : struct, INumeric<TNumeric>
        {
            return left * right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2<TNumeric> Multiply<TNumeric>(TNumeric left, Vector2<TNumeric> right) where TNumeric : struct, INumeric<TNumeric>
        {
            return left * right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3<TNumeric> Multiply<TNumeric>(Vector3<TNumeric> left, Vector3<TNumeric> right) where TNumeric : struct, INumeric<TNumeric>
        {
            return left * right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3<TNumeric> Multiply<TNumeric>(Vector3<TNumeric> left, TNumeric right) where TNumeric : struct, INumeric<TNumeric>
        {
            return left * right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3<TNumeric> Multiply<TNumeric>(TNumeric left, Vector3<TNumeric> right) where TNumeric : struct, INumeric<TNumeric>
        {
            return left * right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2<TNumeric> Negate<TNumeric>(Vector2<TNumeric> value) where TNumeric : struct, INumeric<TNumeric>
        {
            return -value;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3<TNumeric> Negate<TNumeric>(Vector3<TNumeric> value) where TNumeric : struct, INumeric<TNumeric>
        {
            return -value;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2<TNumeric> Normalize<TNumeric>(Vector2<TNumeric> value) where TNumeric : struct, INumeric<TNumeric>
        {
            return value / value.Length();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3<TNumeric> Normalize<TNumeric>(Vector3<TNumeric> value) where TNumeric : struct, INumeric<TNumeric>
        {
            return value / value.Length();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2<TNumeric> Reflect<TNumeric>(Vector2<TNumeric> vector, Vector2<TNumeric> normal) where TNumeric : struct, INumeric<TNumeric>
        {
            return vector - (Dot(vector, normal).Doubled() * normal);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3<TNumeric> Reflect<TNumeric>(Vector3<TNumeric> vector, Vector3<TNumeric> normal) where TNumeric : struct, INumeric<TNumeric>
        {
            TNumeric dot = Dot(vector, normal);
            return vector - (dot.Doubled() * normal);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2<TNumeric> SquareRoot<TNumeric>(Vector2<TNumeric> value) where TNumeric : struct, INumeric<TNumeric>
        {
            return new Vector2<TNumeric>(
                MathN.Sqrt(value.X),
                MathN.Sqrt(value.Y)
            );
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3<TNumeric> SquareRoot<TNumeric>(Vector3<TNumeric> value) where TNumeric : struct, INumeric<TNumeric>
        {
            return new Vector3<TNumeric>(
                MathN.Sqrt(value.X),
                MathN.Sqrt(value.Y),
                MathN.Sqrt(value.Z)
            );
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2<TNumeric> Subtract<TNumeric>(Vector2<TNumeric> left, Vector2<TNumeric> right) where TNumeric : struct, INumeric<TNumeric>
        {
            return left - right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3<TNumeric> Subtract<TNumeric>(Vector3<TNumeric> left, Vector3<TNumeric> right) where TNumeric : struct, INumeric<TNumeric>
        {
            return left - right;
        }
    }
}
