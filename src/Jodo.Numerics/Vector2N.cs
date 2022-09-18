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
using System.Diagnostics;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using Jodo.Primitives;
using Jodo.Primitives.Compatibility;

namespace Jodo.Numerics
{
    [Serializable]
    [DebuggerDisplay("{ToString(),nq}")]
    public readonly struct Vector2N<TNumeric> :
            IEquatable<Vector2N<TNumeric>>,
            IFormattable,
            IProvider<IVariantRandom<Vector2N<TNumeric>>>,
            ISerializable
        where TNumeric : struct, INumeric<TNumeric>
    {
        public readonly TNumeric X;
        public readonly TNumeric Y;

        public Vector2N(TNumeric x, TNumeric y)
        {
            X = x;
            Y = y;
        }

        private Vector2N(SerializationInfo info, StreamingContext context)
        {
            X = (TNumeric)info.GetValue(nameof(X), typeof(TNumeric));
            Y = (TNumeric)info.GetValue(nameof(Y), typeof(TNumeric));
        }

        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue(nameof(X), X, typeof(TNumeric));
            info.AddValue(nameof(Y), Y, typeof(TNumeric));
        }

        public Vector2N<TOther> Convert<TOther>(Func<TNumeric, TOther> convert) where TOther : struct, INumeric<TOther>
            => new Vector2N<TOther>(convert(X), convert(Y));

        public bool Equals(Vector2N<TNumeric> other) => X.Equals(other.X) && Y.Equals(other.Y);
        public override bool Equals(object? obj) => obj is Vector2N<TNumeric> vector && Equals(vector);
        public override int GetHashCode() => HashCodeShim.Combine(X, Y);
        public override string ToString() => ToString("G", CultureInfo.CurrentCulture);
        public string ToString(string? format) => ToString(format, CultureInfo.CurrentCulture);

        public string ToString(string? format, IFormatProvider? formatProvider)
        {
            string separator = NumberFormatInfo.GetInstance(formatProvider).NumberGroupSeparator;
            return $"<{X.ToString(format, formatProvider)}{separator} {Y.ToString(format, formatProvider)}>";
        }

        public static Vector2N<TNumeric> operator -(Vector2N<TNumeric> value) => new Vector2N<TNumeric>(value.X.Negative(), value.Y.Negative());
        public static Vector2N<TNumeric> operator -(Vector2N<TNumeric> value1, Vector2N<TNumeric> value2) => new Vector2N<TNumeric>(value1.X.Subtract(value2.X), value1.Y.Subtract(value2.Y));
        public static Vector2N<TNumeric> operator *(TNumeric scalar, Vector2N<TNumeric> value) => value * scalar;
        public static Vector2N<TNumeric> operator *(Vector2N<TNumeric> value, TNumeric scalar) => new Vector2N<TNumeric>(value.X.Multiply(scalar), value.Y.Multiply(scalar));
        public static Vector2N<TNumeric> operator *(Vector2N<TNumeric> value1, Vector2N<TNumeric> value2) => new Vector2N<TNumeric>(value1.X.Multiply(value2.X), value1.Y.Multiply(value2.Y));
        public static Vector2N<TNumeric> operator /(Vector2N<TNumeric> value, TNumeric scalar) => new Vector2N<TNumeric>(value.X.Divide(scalar), value.Y.Divide(scalar));
        public static Vector2N<TNumeric> operator /(Vector2N<TNumeric> value1, Vector2N<TNumeric> value2) => new Vector2N<TNumeric>(value1.X.Divide(value2.X), value1.Y.Divide(value2.Y));
        public static Vector2N<TNumeric> operator +(Vector2N<TNumeric> value) => value;
        public static Vector2N<TNumeric> operator +(Vector2N<TNumeric> value1, Vector2N<TNumeric> value2) => new Vector2N<TNumeric>(value1.X.Add(value2.X), value1.Y.Add(value2.Y));

#if HAS_VALUE_TUPLES
        public static implicit operator Vector2N<TNumeric>((TNumeric, TNumeric) value) => new Vector2N<TNumeric>(value.Item1, value.Item2);
        public static implicit operator (TNumeric, TNumeric)(Vector2N<TNumeric> value) => (value.X, value.Y);
#endif

        public static implicit operator Vector2N<TNumeric>(Tuple<TNumeric, TNumeric> value) => new Vector2N<TNumeric>(value.Item1, value.Item2);
        public static implicit operator Tuple<TNumeric, TNumeric>(Vector2N<TNumeric> value) => new Tuple<TNumeric, TNumeric>(value.X, value.Y);
        public static bool operator ==(Vector2N<TNumeric> left, Vector2N<TNumeric> right) => left.Equals(right);
        public static bool operator !=(Vector2N<TNumeric> left, Vector2N<TNumeric> right) => !(left == right);

        IVariantRandom<Vector2N<TNumeric>> IProvider<IVariantRandom<Vector2N<TNumeric>>>.GetInstance() => Utilities.Instance;

        private sealed class Utilities :
           IVariantRandom<Vector2N<TNumeric>>
        {
            public static readonly Utilities Instance = new Utilities();

            Vector2N<TNumeric> IVariantRandom<Vector2N<TNumeric>>.Next(Random random, Scenarios scenarios)
            {
                return new Vector2N<TNumeric>(
                    random.NextVariant<TNumeric>(scenarios),
                    random.NextVariant<TNumeric>(scenarios));
            }
        }
    }

    public static class Vector2N
    {
        public static Vector2N<TNumeric> Parse<TNumeric>(string s, NumberStyles? style, IFormatProvider? provider) where TNumeric : struct, INumeric<TNumeric>
        {
            string[] parts = StringUtilities.ParseVectorParts(s.Trim());
            if (parts.Length != 2) throw new FormatException();
            return new Vector2N<TNumeric>(
                Numeric.Parse<TNumeric>(parts[0], style, provider),
                Numeric.Parse<TNumeric>(parts[1], style, provider));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2N<TNumeric> Abs<TNumeric>(Vector2N<TNumeric> value) where TNumeric : struct, INumeric<TNumeric>
        {
            return new Vector2N<TNumeric>(
                MathN.Abs(value.X),
                MathN.Abs(value.Y)
            );
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2N<TNumeric> Add<TNumeric>(Vector2N<TNumeric> left, Vector2N<TNumeric> right) where TNumeric : struct, INumeric<TNumeric>
        {
            return left + right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2N<TNumeric> Clamp<TNumeric>(Vector2N<TNumeric> value1, Vector2N<TNumeric> min, Vector2N<TNumeric> max) where TNumeric : struct, INumeric<TNumeric>
        {
            return Min(Max(value1, min), max);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TNumeric Distance<TNumeric>(Vector2N<TNumeric> value1, Vector2N<TNumeric> value2) where TNumeric : struct, INumeric<TNumeric>
        {
            return MathN.Sqrt(DistanceSquared(value1, value2));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TNumeric DistanceSquared<TNumeric>(Vector2N<TNumeric> value1, Vector2N<TNumeric> value2) where TNumeric : struct, INumeric<TNumeric>
        {
            Vector2N<TNumeric> difference = value1 - value2;
            return Dot(difference, difference);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2N<TNumeric> Divide<TNumeric>(Vector2N<TNumeric> left, Vector2N<TNumeric> right) where TNumeric : struct, INumeric<TNumeric>
        {
            return left / right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2N<TNumeric> Divide<TNumeric>(Vector2N<TNumeric> left, TNumeric divisor) where TNumeric : struct, INumeric<TNumeric>
        {
            return left / divisor;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TNumeric Dot<TNumeric>(Vector2N<TNumeric> value1, Vector2N<TNumeric> value2) where TNumeric : struct, INumeric<TNumeric>
        {
            return value1.X.Multiply(value2.X).Add(value1.Y.Multiply(value2.Y));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2N<TNumeric> Lerp<TNumeric>(Vector2N<TNumeric> value1, Vector2N<TNumeric> value2, TNumeric amount) where TNumeric : struct, INumeric<TNumeric>
        {
            return (value1 * Numeric.One<TNumeric>().Subtract(amount)) + (value2 * amount);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2N<TNumeric> Max<TNumeric>(Vector2N<TNumeric> value1, Vector2N<TNumeric> value2) where TNumeric : struct, INumeric<TNumeric>
        {
            return new Vector2N<TNumeric>(
                MathN.Max(value1.X, value2.X),
                MathN.Max(value1.Y, value2.Y));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2N<TNumeric> Min<TNumeric>(Vector2N<TNumeric> value1, Vector2N<TNumeric> value2) where TNumeric : struct, INumeric<TNumeric>
        {
            return new Vector2N<TNumeric>(
                MathN.Min(value1.X, value2.X),
                MathN.Min(value1.Y, value2.Y));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2N<TNumeric> Multiply<TNumeric>(Vector2N<TNumeric> left, Vector2N<TNumeric> right) where TNumeric : struct, INumeric<TNumeric>
        {
            return left * right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2N<TNumeric> Multiply<TNumeric>(Vector2N<TNumeric> left, TNumeric right) where TNumeric : struct, INumeric<TNumeric>
        {
            return left * right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2N<TNumeric> Multiply<TNumeric>(TNumeric left, Vector2N<TNumeric> right) where TNumeric : struct, INumeric<TNumeric>
        {
            return left * right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2N<TNumeric> Negate<TNumeric>(Vector2N<TNumeric> value) where TNumeric : struct, INumeric<TNumeric>
        {
            return -value;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2N<TNumeric> Normalize<TNumeric>(Vector2N<TNumeric> value) where TNumeric : struct, INumeric<TNumeric>
        {
            return value / value.Length();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2N<TNumeric> Reflect<TNumeric>(Vector2N<TNumeric> vector, Vector2N<TNumeric> normal) where TNumeric : struct, INumeric<TNumeric>
        {
            return vector - (Dot(vector, normal).Double() * normal);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2N<TNumeric> SquareRoot<TNumeric>(Vector2N<TNumeric> value) where TNumeric : struct, INumeric<TNumeric>
        {
            return new Vector2N<TNumeric>(
                MathN.Sqrt(value.X),
                MathN.Sqrt(value.Y)
            );
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2N<TNumeric> Subtract<TNumeric>(Vector2N<TNumeric> left, Vector2N<TNumeric> right) where TNumeric : struct, INumeric<TNumeric>
        {
            return left - right;
        }
    }
}
