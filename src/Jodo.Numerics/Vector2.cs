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
    public static class Vector2
    {
        public static Vector2<TNumeric> Parse<TNumeric>(string s, NumberStyles? style, IFormatProvider? provider) where TNumeric : struct, INumeric<TNumeric>
        {
            string[] parts = StringUtilities.ParseVectorParts(s.Trim());
            if (parts.Length != 2) throw new FormatException();
            return new Vector2<TNumeric>(
                Numeric.Parse<TNumeric>(parts[0], style, provider),
                Numeric.Parse<TNumeric>(parts[1], style, provider));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2<TNumeric> Abs<TNumeric>(Vector2<TNumeric> value) where TNumeric : struct, INumeric<TNumeric>
        {
            return new Vector2<TNumeric>(
                MathN.Abs(value.X),
                MathN.Abs(value.Y)
            );
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2<TNumeric> Add<TNumeric>(Vector2<TNumeric> left, Vector2<TNumeric> right) where TNumeric : struct, INumeric<TNumeric>
        {
            return left + right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2<TNumeric> Clamp<TNumeric>(Vector2<TNumeric> value1, Vector2<TNumeric> min, Vector2<TNumeric> max) where TNumeric : struct, INumeric<TNumeric>
        {
            return Min(Max(value1, min), max);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TNumeric Distance<TNumeric>(Vector2<TNumeric> value1, Vector2<TNumeric> value2) where TNumeric : struct, INumeric<TNumeric>
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
        public static TNumeric Dot<TNumeric>(Vector2<TNumeric> value1, Vector2<TNumeric> value2) where TNumeric : struct, INumeric<TNumeric>
        {
            return value1.X.Multiply(value2.X).Add(value1.Y.Multiply(value2.Y));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2<TNumeric> Lerp<TNumeric>(Vector2<TNumeric> value1, Vector2<TNumeric> value2, TNumeric amount) where TNumeric : struct, INumeric<TNumeric>
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
        public static Vector2<TNumeric> Min<TNumeric>(Vector2<TNumeric> value1, Vector2<TNumeric> value2) where TNumeric : struct, INumeric<TNumeric>
        {
            return new Vector2<TNumeric>(
                MathN.Min(value1.X, value2.X),
                MathN.Min(value1.Y, value2.Y));
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
        public static Vector2<TNumeric> Negate<TNumeric>(Vector2<TNumeric> value) where TNumeric : struct, INumeric<TNumeric>
        {
            return -value;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2<TNumeric> Normalize<TNumeric>(Vector2<TNumeric> value) where TNumeric : struct, INumeric<TNumeric>
        {
            return value / value.Length();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2<TNumeric> Reflect<TNumeric>(Vector2<TNumeric> vector, Vector2<TNumeric> normal) where TNumeric : struct, INumeric<TNumeric>
        {
            return vector - (Dot(vector, normal).Doubled() * normal);
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
        public static Vector2<TNumeric> Subtract<TNumeric>(Vector2<TNumeric> left, Vector2<TNumeric> right) where TNumeric : struct, INumeric<TNumeric>
        {
            return left - right;
        }
    }

    [Serializable]
    [DebuggerDisplay("{ToString(),nq}")]
    public readonly struct Vector2<TNumeric> :
            IEquatable<Vector2<TNumeric>>,
            IFormattable,
            IProvider<IBitConvert<Vector2<TNumeric>>>,
                        IProvider<IVariantRandom<Vector2<TNumeric>>>,
            ISerializable
        where TNumeric : struct, INumeric<TNumeric>
    {
        public readonly TNumeric X;
        public readonly TNumeric Y;

        public Vector2(TNumeric x, TNumeric y)
        {
            X = x;
            Y = y;
        }

        private Vector2(SerializationInfo info, StreamingContext context)
        {
            X = (TNumeric)info.GetValue(nameof(X), typeof(TNumeric));
            Y = (TNumeric)info.GetValue(nameof(Y), typeof(TNumeric));
        }

        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue(nameof(X), X, typeof(TNumeric));
            info.AddValue(nameof(Y), Y, typeof(TNumeric));
        }

        public Vector2<TOther> Convert<TOther>(Func<TNumeric, TOther> convert) where TOther : struct, INumeric<TOther>
            => new Vector2<TOther>(convert(X), convert(Y));

        public Vector2<TNumeric> Halved() => new Vector2<TNumeric>(X.Halved(), Y.Halved());
        public Vector2<TNumeric> Doubled() => new Vector2<TNumeric>(X.Doubled(), Y.Doubled());
        public Vector2<TNumeric> AddX(TNumeric x) => new Vector2<TNumeric>(X.Add(x), Y);
        public Vector2<TNumeric> AddY(TNumeric y) => new Vector2<TNumeric>(X, Y.Add(y));

        public bool Equals(Vector2<TNumeric> other) => X.Equals(other.X) && Y.Equals(other.Y);
        public override bool Equals(object? obj) => obj is Vector2<TNumeric> vector && Equals(vector);
        public override int GetHashCode() => HashCode.Combine(X, Y);
        public override string ToString() => ToString("G", CultureInfo.CurrentCulture);
        public string ToString(string? format) => ToString(format, CultureInfo.CurrentCulture);

        public string ToString(string? format, IFormatProvider? formatProvider)
        {
            string separator = NumberFormatInfo.GetInstance(formatProvider).NumberGroupSeparator;
            return $"<{X.ToString(format, formatProvider)}{separator} {Y.ToString(format, formatProvider)}>";
        }

        public static Vector2<TNumeric> operator -(Vector2<TNumeric> value) => new Vector2<TNumeric>(value.X.Negative(), value.Y.Negative());
        public static Vector2<TNumeric> operator -(Vector2<TNumeric> value1, Vector2<TNumeric> value2) => new Vector2<TNumeric>(value1.X.Subtract(value2.X), value1.Y.Subtract(value2.Y));
        public static Vector2<TNumeric> operator *(TNumeric scalar, Vector2<TNumeric> value) => value * scalar;
        public static Vector2<TNumeric> operator *(Vector2<TNumeric> value, TNumeric scalar) => new Vector2<TNumeric>(value.X.Multiply(scalar), value.Y.Multiply(scalar));
        public static Vector2<TNumeric> operator *(Vector2<TNumeric> value1, Vector2<TNumeric> value2) => new Vector2<TNumeric>(value1.X.Multiply(value2.X), value1.Y.Multiply(value2.Y));
        public static Vector2<TNumeric> operator /(Vector2<TNumeric> value, TNumeric scalar) => new Vector2<TNumeric>(value.X.Divide(scalar), value.Y.Divide(scalar));
        public static Vector2<TNumeric> operator /(Vector2<TNumeric> value1, Vector2<TNumeric> value2) => new Vector2<TNumeric>(value1.X.Divide(value2.X), value1.Y.Divide(value2.Y));
        public static Vector2<TNumeric> operator +(Vector2<TNumeric> value) => value;
        public static Vector2<TNumeric> operator +(Vector2<TNumeric> value1, Vector2<TNumeric> value2) => new Vector2<TNumeric>(value1.X.Add(value2.X), value1.Y.Add(value2.Y));

#if NETSTANDARD2_0_OR_GREATER
        public static implicit operator Vector2<TNumeric>((TNumeric, TNumeric) value) => new Vector2<TNumeric>(value.Item1, value.Item2);
        public static implicit operator (TNumeric, TNumeric)(Vector2<TNumeric> value) => (value.X, value.Y);
#endif

        public static implicit operator Vector2<TNumeric>(Tuple<TNumeric, TNumeric> value) => new Vector2<TNumeric>(value.Item1, value.Item2);
        public static implicit operator Tuple<TNumeric, TNumeric>(Vector2<TNumeric> value) => new Tuple<TNumeric, TNumeric>(value.X, value.Y);
        public static bool operator ==(Vector2<TNumeric> left, Vector2<TNumeric> right) => left.Equals(right);
        public static bool operator !=(Vector2<TNumeric> left, Vector2<TNumeric> right) => !(left == right);

        IBitConvert<Vector2<TNumeric>> IProvider<IBitConvert<Vector2<TNumeric>>>.GetInstance() => Utilities.Instance;
        IVariantRandom<Vector2<TNumeric>> IProvider<IVariantRandom<Vector2<TNumeric>>>.GetInstance() => Utilities.Instance;

        private sealed class Utilities :
           IBitConvert<Vector2<TNumeric>>,
           IVariantRandom<Vector2<TNumeric>>
        {
            public static readonly Utilities Instance = new Utilities();

            Vector2<TNumeric> IVariantRandom<Vector2<TNumeric>>.Next(Random random, Scenarios scenarios)
            {
                return new Vector2<TNumeric>(
                    random.NextVariant<TNumeric>(scenarios),
                    random.NextVariant<TNumeric>(scenarios));
            }

            Vector2<TNumeric> IBitConvert<Vector2<TNumeric>>.Read(IReader<byte> stream)
            {
                return new Vector2<TNumeric>(BitConvert.Read<TNumeric>(stream), BitConvert.Read<TNumeric>(stream));
            }

            void IBitConvert<Vector2<TNumeric>>.Write(Vector2<TNumeric> value, IWriter<byte> stream)
            {
                BitConvert.Write(stream, value.X);
                BitConvert.Write(stream, value.Y);
            }
        }
    }
}
