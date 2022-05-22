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
using Jodo.Extensions.Primitives;
using System;
using System.Runtime.Serialization;

namespace Jodo.Extensions.Geometry
{
    [Serializable]
    public readonly struct Angle<N> : IGeometric<Angle<N>> where N : struct, INumeric<N>
    {
        public static readonly Angle<N> Zero = default;
        public static readonly Angle<N> C90Degrees = FromDegrees(90);
        public static readonly Angle<N> C180Degrees = C90Degrees + C90Degrees;
        public static readonly Angle<N> C270Degrees = C90Degrees + C90Degrees + C90Degrees;

        public readonly N Degrees;

        public N Cosine => Math<N>.Cos(Radians);
        public N HyperbolicCosine => Math<N>.Cosh(Radians);
        public N HyperbolicSine => Math<N>.Sinh(Radians);
        public N HyperbolicTangent => Math<N>.Tanh(Radians);
        public N Radians => Math<N>.DegreesToRadians(Degrees);
        public N Sine => Math<N>.Sin(Radians);
        public N Tangent => Math<N>.Tan(Radians);

        IBitConverter<Angle<N>> IBitConvertible<Angle<N>>.BitConverter => throw new NotImplementedException();

        IRandom<Angle<N>> IRandomisable<Angle<N>>.Random => throw new NotImplementedException();

        IStringParser<Angle<N>> IStringParsable<Angle<N>>.StringParser => throw new NotImplementedException();

        public Angle(N degrees)
        {
            Degrees = degrees;
        }

        private Angle(SerializationInfo info, StreamingContext context) : this(
            (N)info.GetValue(nameof(Degrees), typeof(N)))
        { }

        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
            => info.AddValue(nameof(Degrees), Degrees, typeof(N));

        public bool Equals(Angle<N> other) => Degrees.Equals(other.Degrees);
        public override bool Equals(object? obj) => obj is Angle<N> angle && Equals(angle);
        public override int GetHashCode() => Degrees.GetHashCode();
        public override string ToString() => StringRepresentation.Combine(GetType(), Degrees);
        public string ToString(string format, IFormatProvider formatProvider) => throw new NotImplementedException();

        public static Angle<N> FromDegrees(N degrees) => new Angle<N>(degrees);
        public static Angle<N> FromDegrees(byte degrees) => new Angle<N>(Convert<N>.ToNumeric(degrees));
        public static Angle<N> FromRadians(N radians) => new Angle<N>(Math<N>.RadiansToDegrees(radians));
        public static Angle<N> FromRadians(byte radians) => new Angle<N>(Math<N>.RadiansToDegrees(Convert<N>.ToNumeric(radians)));

        public static bool TryParse(string value, out Angle<N> result)
        {
            try
            {
                result = Parse(value);
                return true;
            }
            catch (Exception)
            {
                result = default;
                return false;
            }
        }

        public static Angle<N> Parse(string value)
        {
            var trimmed = value.Trim();
            if (trimmed.EndsWith("Degrees", StringComparison.InvariantCultureIgnoreCase)) return Angle<N>.FromDegrees(StringParser<N>.Parse(trimmed[0..^7]));
            else if (trimmed.EndsWith("Degree", StringComparison.InvariantCultureIgnoreCase)) return Angle<N>.FromDegrees(StringParser<N>.Parse(trimmed[0..^6]));
            else if (trimmed.EndsWith("Radians", StringComparison.InvariantCultureIgnoreCase)) return Angle<N>.FromRadians(StringParser<N>.Parse(trimmed[0..^7]));
            else if (trimmed.EndsWith("Radian", StringComparison.InvariantCultureIgnoreCase)) return Angle<N>.FromRadians(StringParser<N>.Parse(trimmed[0..^6]));
            else if (trimmed.EndsWith("Deg", StringComparison.InvariantCultureIgnoreCase)) return Angle<N>.FromDegrees(StringParser<N>.Parse(trimmed[0..^3]));
            else if (trimmed.EndsWith("Rad", StringComparison.InvariantCultureIgnoreCase)) return Angle<N>.FromRadians(StringParser<N>.Parse(trimmed[0..^3]));
            else if (trimmed.EndsWith("°", StringComparison.InvariantCultureIgnoreCase)) return Angle<N>.FromDegrees(StringParser<N>.Parse(trimmed[0..^1]));
            else if (trimmed.EndsWith("C", StringComparison.InvariantCultureIgnoreCase)) return Angle<N>.FromRadians(StringParser<N>.Parse(trimmed[0..^1]));
            else if (trimmed.EndsWith("R", StringComparison.InvariantCultureIgnoreCase)) return Angle<N>.FromRadians(StringParser<N>.Parse(trimmed[0..^1]));
            else return Angle<N>.FromDegrees(StringParser<N>.Parse(trimmed));
        }

        public static Angle<N> operator -(Angle<N> value) => FromDegrees(-value.Degrees);
        public static Angle<N> operator -(Angle<N> value1, Angle<N> value2) => FromDegrees(value1.Degrees - value2.Degrees);
        public static Angle<N> operator +(Angle<N> value) => value;
        public static Angle<N> operator +(Angle<N> value1, Angle<N> value2) => FromDegrees(value1.Degrees + value2.Degrees);
        public static bool operator !=(Angle<N> left, Angle<N> right) => !(left == right);
        public static bool operator ==(Angle<N> left, Angle<N> right) => left.Equals(right);
    }
}
