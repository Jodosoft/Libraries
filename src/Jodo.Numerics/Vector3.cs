﻿// Copyright (c) 2022 Joseph J. Short
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
    public static class Vector3
    {
        public static Vector3<TNumeric> Parse<TNumeric>(string s, NumberStyles? style, IFormatProvider? provider) where TNumeric : struct, INumeric<TNumeric>
        {
            string[] parts = StringUtilities.ParseVectorParts(s.Trim());
            if (parts.Length != 3) throw new FormatException();
            return new Vector3<TNumeric>(
                Numeric.Parse<TNumeric>(parts[0], style, provider),
                Numeric.Parse<TNumeric>(parts[1], style, provider),
                Numeric.Parse<TNumeric>(parts[2], style, provider));
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
        public static Vector3<TNumeric> Add<TNumeric>(Vector3<TNumeric> left, Vector3<TNumeric> right) where TNumeric : struct, INumeric<TNumeric>
        {
            return left + right;
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
        public static TNumeric Distance<TNumeric>(Vector3<TNumeric> value1, Vector3<TNumeric> value2) where TNumeric : struct, INumeric<TNumeric>
        {
            return MathN.Sqrt(DistanceSquared(value1, value2));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TNumeric DistanceSquared<TNumeric>(Vector3<TNumeric> value1, Vector3<TNumeric> value2) where TNumeric : struct, INumeric<TNumeric>
        {
            Vector3<TNumeric> difference = value1 - value2;
            return Dot(difference, difference);
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
        public static TNumeric Dot<TNumeric>(Vector3<TNumeric> vector1, Vector3<TNumeric> vector2) where TNumeric : struct, INumeric<TNumeric>
        {
            return vector1.X.Multiply(vector2.X)
                 .Add(vector1.Y.Multiply(vector2.Y))
                 .Add(vector1.Z.Multiply(vector2.Z));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3<TNumeric> Lerp<TNumeric>(Vector3<TNumeric> value1, Vector3<TNumeric> value2, TNumeric amount) where TNumeric : struct, INumeric<TNumeric>
        {
            return (value1 * Numeric.One<TNumeric>().Subtract(amount)) + (value2 * amount);
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
        public static Vector3<TNumeric> Min<TNumeric>(Vector3<TNumeric> value1, Vector3<TNumeric> value2) where TNumeric : struct, INumeric<TNumeric>
        {
            return new Vector3<TNumeric>(
                MathN.Min(value1.X, value2.X),
                MathN.Min(value1.Y, value2.Y),
                MathN.Min(value1.Z, value2.Z));
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
        public static Vector3<TNumeric> Negate<TNumeric>(Vector3<TNumeric> value) where TNumeric : struct, INumeric<TNumeric>
        {
            return -value;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3<TNumeric> Normalize<TNumeric>(Vector3<TNumeric> value) where TNumeric : struct, INumeric<TNumeric>
        {
            return value / value.Length();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3<TNumeric> Reflect<TNumeric>(Vector3<TNumeric> vector, Vector3<TNumeric> normal) where TNumeric : struct, INumeric<TNumeric>
        {
            TNumeric dot = Dot(vector, normal);
            return vector - (dot.Doubled() * normal);
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
        public static Vector3<TNumeric> Subtract<TNumeric>(Vector3<TNumeric> left, Vector3<TNumeric> right) where TNumeric : struct, INumeric<TNumeric> => left - right;
    }

    [Serializable]
    [DebuggerDisplay("{ToString(),nq}")]
    public readonly struct Vector3<TNumeric> :
            IEquatable<Vector3<TNumeric>>,
            IFormattable,
            IProvider<IBitConvert<Vector3<TNumeric>>>,
                        IProvider<IVariantRandom<Vector3<TNumeric>>>,
            ISerializable
        where TNumeric : struct, INumeric<TNumeric>
    {
        public readonly TNumeric X;
        public readonly TNumeric Y;
        public readonly TNumeric Z;

        public Vector3(TNumeric x, TNumeric y, TNumeric z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        private Vector3(SerializationInfo info, StreamingContext context) : this(
            (TNumeric)info.GetValue(nameof(X), typeof(TNumeric)),
            (TNumeric)info.GetValue(nameof(Y), typeof(TNumeric)),
            (TNumeric)info.GetValue(nameof(Z), typeof(TNumeric)))
        { }

        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue(nameof(X), X, typeof(TNumeric));
            info.AddValue(nameof(Y), Y, typeof(TNumeric));
            info.AddValue(nameof(Z), Z, typeof(TNumeric));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly TNumeric Length()
        {
            return MathN.Sqrt(LengthSquared());
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly TNumeric LengthSquared()
        {
            return Vector3.Dot(this, this);
        }

        public bool Equals(Vector3<TNumeric> other) => X.Equals(other.X) && Y.Equals(other.Y) && Z.Equals(other.Z);
        public override bool Equals(object? obj) => obj is Vector3<TNumeric> vector && Equals(vector);
        public override int GetHashCode() => HashCode.Combine(X, Y, Z);
        public override string ToString() => ToString("G", CultureInfo.CurrentCulture);
        public string ToString(string? format) => ToString(format, CultureInfo.CurrentCulture);

        public string ToString(string? format, IFormatProvider? formatProvider)
        {
            string separator = NumberFormatInfo.GetInstance(formatProvider).NumberGroupSeparator;
            return $"<{X.ToString(format, formatProvider)}{separator} {Y.ToString(format, formatProvider)}{separator} {Z.ToString(format, formatProvider)}>";
        }

        public static bool operator !=(Vector3<TNumeric> left, Vector3<TNumeric> right) => !(left == right);
        public static bool operator ==(Vector3<TNumeric> left, Vector3<TNumeric> right) => left.Equals(right);
        public static Vector3<TNumeric> operator -(Vector3<TNumeric> value) => new Vector3<TNumeric>(value.X.Negative(), value.Y.Negative(), value.Z.Negative());
        public static Vector3<TNumeric> operator -(Vector3<TNumeric> value1, Vector3<TNumeric> value2) => new Vector3<TNumeric>(value1.X.Subtract(value2.X), value1.Y.Subtract(value2.Y), value1.Z.Subtract(value2.Z));
        public static Vector3<TNumeric> operator *(TNumeric scalar, Vector3<TNumeric> value) => value * scalar;
        public static Vector3<TNumeric> operator *(Vector3<TNumeric> value, TNumeric scalar) => new Vector3<TNumeric>(value.X.Multiply(scalar), value.Y.Multiply(scalar), value.Z.Multiply(scalar));
        public static Vector3<TNumeric> operator *(Vector3<TNumeric> value1, Vector3<TNumeric> value2) => new Vector3<TNumeric>(value1.X.Multiply(value2.X), value1.Y.Multiply(value2.Y), value1.Y.Multiply(value2.Z));
        public static Vector3<TNumeric> operator /(Vector3<TNumeric> value, TNumeric scalar) => new Vector3<TNumeric>(value.X.Divide(scalar), value.Y.Divide(scalar), value.Z.Divide(scalar));
        public static Vector3<TNumeric> operator /(Vector3<TNumeric> value1, Vector3<TNumeric> value2) => new Vector3<TNumeric>(value1.X.Divide(value2.X), value1.Y.Divide(value2.Y), value1.Y.Divide(value2.Z));
        public static Vector3<TNumeric> operator +(Vector3<TNumeric> value) => value;
        public static Vector3<TNumeric> operator +(Vector3<TNumeric> value1, Vector3<TNumeric> value2) => new Vector3<TNumeric>(value1.X.Add(value2.X), value1.Y.Add(value2.Y), value1.Z.Add(value2.Z));
        public static implicit operator Vector3<TNumeric>(Tuple<TNumeric, TNumeric, TNumeric> value) => new Vector3<TNumeric>(value.Item1, value.Item2, value.Item3);
        public static implicit operator Tuple<TNumeric, TNumeric, TNumeric>(Vector3<TNumeric> value) => new Tuple<TNumeric, TNumeric, TNumeric>(value.X, value.Y, value.Z);

#if NETSTANDARD2_0_OR_GREATER
        public static implicit operator Vector3<TNumeric>((TNumeric, TNumeric, TNumeric) value) => new Vector3<TNumeric>(value.Item1, value.Item2, value.Item3);
        public static implicit operator (TNumeric, TNumeric, TNumeric)(Vector3<TNumeric> value) => (value.X, value.Y, value.Z);
#endif

        IBitConvert<Vector3<TNumeric>> IProvider<IBitConvert<Vector3<TNumeric>>>.GetInstance() => Utilities.Instance;
        IVariantRandom<Vector3<TNumeric>> IProvider<IVariantRandom<Vector3<TNumeric>>>.GetInstance() => Utilities.Instance;

        private sealed class Utilities :
           IBitConvert<Vector3<TNumeric>>,
           IVariantRandom<Vector3<TNumeric>>
        {
            public static readonly Utilities Instance = new Utilities();

            Vector3<TNumeric> IVariantRandom<Vector3<TNumeric>>.Next(Random random, Scenarios scenarios)
            {
                return new Vector3<TNumeric>(
                    random.NextVariant<TNumeric>(scenarios),
                    random.NextVariant<TNumeric>(scenarios),
                    random.NextVariant<TNumeric>(scenarios));
            }

            Vector3<TNumeric> IBitConvert<Vector3<TNumeric>>.Read(IReader<byte> stream)
            {
                return new Vector3<TNumeric>(
                    BitConvert.Read<TNumeric>(stream),
                    BitConvert.Read<TNumeric>(stream),
                    BitConvert.Read<TNumeric>(stream));
            }

            void IBitConvert<Vector3<TNumeric>>.Write(Vector3<TNumeric> value, IWriter<byte> stream)
            {
                BitConvert.Write(stream, value.X);
                BitConvert.Write(stream, value.Y);
                BitConvert.Write(stream, value.Z);
            }
        }
    }
}
