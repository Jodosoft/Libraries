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
using System.IO;
using System.Runtime.Serialization;
using Jodo.Numerics;
using Jodo.Primitives;

namespace Jodo.Geometry
{
    [Serializable]
    [DebuggerDisplay("{ToString(),nq}")]
    public readonly struct Angle<TNumeric> :
            IComparable,
            IComparable<Angle<TNumeric>>,
            IEquatable<Angle<TNumeric>>,
            IFormattable,
            IProvider<IBinaryIO<Angle<TNumeric>>>,
            IProvider<IVariantRandom<Angle<TNumeric>>>,
            ISerializable
        where TNumeric : struct, INumeric<TNumeric>
    {
        public readonly TNumeric Degrees;

        public Angle(TNumeric degrees)
        {
            Degrees = degrees;
        }

        private Angle(SerializationInfo info, StreamingContext context)
        {
            Degrees = (TNumeric)info.GetValue(nameof(Degrees), typeof(TNumeric));
        }

        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue(nameof(Degrees), Degrees, typeof(TNumeric));
        }

        public Angle<TNumeric> Normalise()
        {
            return new Angle<TNumeric>(Degrees.Remainder(ConvertN.ToNumeric<TNumeric>(360, Conversion.Cast)));
        }

        public int CompareTo(object? obj) => obj is Angle<TNumeric> other ? CompareTo(other) : 1;
        public int CompareTo(Angle<TNumeric> other) => Degrees.CompareTo(other.Degrees);
        public bool Equals(Angle<TNumeric> other) => Degrees.Equals(other.Degrees);
        public override bool Equals(object? obj) => obj is Angle<TNumeric> angle && Equals(angle);
        public override int GetHashCode() => Degrees.GetHashCode();
        public override string ToString() => $"{Degrees}°";
        public string ToString(string? format, IFormatProvider? formatProvider) => $"{Degrees.ToString(format, formatProvider)}°";

        public static bool operator !=(Angle<TNumeric> left, Angle<TNumeric> right) => !left.Equals(right);
        public static bool operator <(Angle<TNumeric> left, Angle<TNumeric> right) => left.Degrees.IsLessThan(right.Degrees);
        public static bool operator <=(Angle<TNumeric> left, Angle<TNumeric> right) => left.Degrees.IsLessThanOrEqualTo(right.Degrees);
        public static bool operator ==(Angle<TNumeric> left, Angle<TNumeric> right) => left.Equals(right);
        public static bool operator >(Angle<TNumeric> left, Angle<TNumeric> right) => left.Degrees.IsGreaterThan(right.Degrees);
        public static bool operator >=(Angle<TNumeric> left, Angle<TNumeric> right) => left.Degrees.IsGreaterThanOrEqualTo(right.Degrees);
        public static Angle<TNumeric> operator %(Angle<TNumeric> left, Angle<TNumeric> right) => new Angle<TNumeric>(left.Degrees.Remainder(right.Degrees));
        public static Angle<TNumeric> operator -(Angle<TNumeric> left, Angle<TNumeric> right) => new Angle<TNumeric>(left.Degrees.Subtract(right.Degrees));
        public static Angle<TNumeric> operator -(Angle<TNumeric> value) => new Angle<TNumeric>(value.Degrees.Negative());
        public static Angle<TNumeric> operator *(Angle<TNumeric> left, Angle<TNumeric> right) => new Angle<TNumeric>(left.Degrees.Multiply(right.Degrees));
        public static Angle<TNumeric> operator /(Angle<TNumeric> left, Angle<TNumeric> right) => new Angle<TNumeric>(left.Degrees.Divide(right.Degrees));
        public static Angle<TNumeric> operator +(Angle<TNumeric> left, Angle<TNumeric> right) => new Angle<TNumeric>(left.Degrees.Add(right.Degrees));
        public static Angle<TNumeric> operator +(Angle<TNumeric> value) => new Angle<TNumeric>(value.Degrees);

        IBinaryIO<Angle<TNumeric>> IProvider<IBinaryIO<Angle<TNumeric>>>.GetInstance() => Utilities.Instance;
        IVariantRandom<Angle<TNumeric>> IProvider<IVariantRandom<Angle<TNumeric>>>.GetInstance() => Utilities.Instance;

        private sealed class Utilities :
            IBinaryIO<Angle<TNumeric>>,
            IVariantRandom<Angle<TNumeric>>
        {
            public static readonly Utilities Instance = new Utilities();

            void IBinaryIO<Angle<TNumeric>>.Write(BinaryWriter writer, Angle<TNumeric> value)
            {
                writer.Write(value.Degrees);
            }

            Angle<TNumeric> IBinaryIO<Angle<TNumeric>>.Read(BinaryReader reader)
            {
                return new Angle<TNumeric>(reader.Read<TNumeric>());
            }

            Angle<TNumeric> IVariantRandom<Angle<TNumeric>>.Generate(Random random, Variants variants)
                => new Angle<TNumeric>(random.NextVariant<TNumeric>(variants));
        }
    }

    public static class Angle
    {
        public static Angle<TNumeric> Zero<TNumeric>() where TNumeric : struct, INumeric<TNumeric>
        {
            return new Angle<TNumeric>(Numeric.Zero<TNumeric>());
        }

        public static TNumeric RadiansToDegrees<TNumeric>(TNumeric radians) where TNumeric : struct, INumeric<TNumeric>
        {
            return radians.Multiply(ConvertN.ToNumeric<TNumeric>(Math.PI / 180d));
        }

        public static TNumeric DegreesToRadians<TNumeric>(TNumeric degrees) where TNumeric : struct, INumeric<TNumeric>
        {
            return degrees.Multiply(ConvertN.ToNumeric<TNumeric>(180d / Math.PI));
        }

        public static Angle<TNumeric> FromDegrees<TNumeric>(TNumeric degrees) where TNumeric : struct, INumeric<TNumeric>
            => new Angle<TNumeric>(degrees);

        public static Angle<TNumeric> FromRadians<TNumeric>(TNumeric radians) where TNumeric : struct, INumeric<TNumeric>
            => new Angle<TNumeric>(RadiansToDegrees(radians));

        public static Angle<TNumeric> Parse<TNumeric>(string s, NumberStyles? style, IFormatProvider? provider) where TNumeric : struct, INumeric<TNumeric>
        {
            string trimmed = s.Trim();

            if (TryParse(trimmed, "°", style, provider, out TNumeric number)) return FromDegrees(number);
            if (TryParse(trimmed, "Degrees", style, provider, out number)) return FromDegrees(number);
            if (TryParse(trimmed, "Degree", style, provider, out number)) return FromDegrees(number);
            if (TryParse(trimmed, "Deg", style, provider, out number)) return FromDegrees(number);
            if (TryParse(trimmed, "Radians", style, provider, out number)) return FromRadians(number);
            if (TryParse(trimmed, "Radian", style, provider, out number)) return FromRadians(number);
            if (TryParse(trimmed, "Rad", style, provider, out number)) return FromRadians(number);
            if (TryParse(trimmed, "C", style, provider, out number)) return FromRadians(number);
            if (TryParse(trimmed, "R", style, provider, out number)) return FromRadians(number);

            return FromDegrees(Numeric.Parse<TNumeric>(trimmed));
        }

        private static bool TryParse<TNumeric>(string value, string unit, NumberStyles? style, IFormatProvider? provider, out TNumeric number) where TNumeric : struct, INumeric<TNumeric>
        {
            if (value.EndsWith(unit, StringComparison.InvariantCultureIgnoreCase))
            {
                number = Numeric.Parse<TNumeric>(value.Substring(0, value.Length - unit.Length), style, provider);
                return true;
            }
            number = default;
            return false;
        }
    }
}
