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
    public readonly struct Angle<T> : IGeometric<Angle<T>> where T : struct, INumeric<T>
    {
        public static readonly Angle<T> Zero = default;
        public static readonly Angle<T> C90Degrees = FromDegrees(90);
        public static readonly Angle<T> C180Degrees = C90Degrees + C90Degrees;
        public static readonly Angle<T> C270Degrees = C90Degrees + C90Degrees + C90Degrees;

        public readonly T Degrees;

        public T Cosine => Math<T>.Cos(Radians);
        public T Turns => Math<T>.DegreesToTurns(Degrees);
        public T HyperbolicCosine => Math<T>.Cosh(Radians);
        public T HyperbolicSine => Math<T>.Sinh(Radians);
        public T HyperbolicTangent => Math<T>.Tanh(Radians);
        public T Radians => Math<T>.DegreesToRadians(Degrees);
        public T Sine => Math<T>.Sin(Radians);
        public T Tangent => Math<T>.Tan(Radians);

        IBitConverter<Angle<T>> IBitConvertible<Angle<T>>.BitConverter => throw new NotImplementedException();

        IRandom<Angle<T>> IRandomisable<Angle<T>>.Random => throw new NotImplementedException();

        IStringParser<Angle<T>> IStringRepresentable<Angle<T>>.StringParser => throw new NotImplementedException();

        public Angle(T degrees)
        {
            Degrees = degrees;
        }

        private Angle(SerializationInfo info, StreamingContext context) : this(
            (T)info.GetValue(nameof(Degrees), typeof(T)))
        { }

        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
            => info.AddValue(nameof(Degrees), Degrees, typeof(T));

        public bool Equals(Angle<T> other) => Degrees.Equals(other.Degrees);
        public override bool Equals(object? obj) => obj is Angle<T> angle && Equals(angle);
        public override int GetHashCode() => Degrees.GetHashCode();
        public override string ToString() => StringRepresentation.Combine(GetType(), Degrees);
        public string ToString(string format, IFormatProvider formatProvider) => throw new NotImplementedException();

        public static Angle<T> FromDegrees(T degrees) => new Angle<T>(degrees);
        public static Angle<T> FromDegrees(byte degrees) => new Angle<T>(Convert<T>.ToValue(degrees));
        public static Angle<T> FromRadians(T radians) => new Angle<T>(Math<T>.RadiansToTurns(radians));
        public static Angle<T> FromRadians(byte radians) => new Angle<T>(Math<T>.RadiansToTurns(Convert<T>.ToValue(radians)));
        public static Angle<T> FromTurns(T turns) => new Angle<T>(Math<T>.TurnsToDegrees(turns));
        public static Angle<T> FromTurns(byte turns) => new Angle<T>(Math<T>.TurnsToDegrees(Convert<T>.ToValue(turns)));

        public static bool TryParse(string value, out Angle<T> result)
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

        public static Angle<T> Parse(string value)
        {
            var trimmed = value.Trim();
            if (trimmed.EndsWith("Degrees", StringComparison.InvariantCultureIgnoreCase)) return Angle<T>.FromDegrees(StringParser<T>.Parse(trimmed[0..^7]));
            else if (trimmed.EndsWith("Degree", StringComparison.InvariantCultureIgnoreCase)) return Angle<T>.FromDegrees(StringParser<T>.Parse(trimmed[0..^6]));
            else if (trimmed.EndsWith("Radians", StringComparison.InvariantCultureIgnoreCase)) return Angle<T>.FromRadians(StringParser<T>.Parse(trimmed[0..^7]));
            else if (trimmed.EndsWith("Radian", StringComparison.InvariantCultureIgnoreCase)) return Angle<T>.FromRadians(StringParser<T>.Parse(trimmed[0..^6]));
            else if (trimmed.EndsWith("Turns", StringComparison.InvariantCultureIgnoreCase)) return Angle<T>.FromTurns(StringParser<T>.Parse(trimmed[0..^5]));
            else if (trimmed.EndsWith("Turn", StringComparison.InvariantCultureIgnoreCase)) return Angle<T>.FromTurns(StringParser<T>.Parse(trimmed[0..^4]));
            else if (trimmed.EndsWith("Deg", StringComparison.InvariantCultureIgnoreCase)) return Angle<T>.FromDegrees(StringParser<T>.Parse(trimmed[0..^3]));
            else if (trimmed.EndsWith("Rad", StringComparison.InvariantCultureIgnoreCase)) return Angle<T>.FromRadians(StringParser<T>.Parse(trimmed[0..^3]));
            else if (trimmed.EndsWith("PLA", StringComparison.InvariantCultureIgnoreCase)) return Angle<T>.FromTurns(StringParser<T>.Parse(trimmed[0..^3]));
            else if (trimmed.EndsWith("TR", StringComparison.InvariantCultureIgnoreCase)) return Angle<T>.FromTurns(StringParser<T>.Parse(trimmed[0..^2]));
            else if (trimmed.EndsWith("°", StringComparison.InvariantCultureIgnoreCase)) return Angle<T>.FromDegrees(StringParser<T>.Parse(trimmed[0..^1]));
            else if (trimmed.EndsWith("C", StringComparison.InvariantCultureIgnoreCase)) return Angle<T>.FromRadians(StringParser<T>.Parse(trimmed[0..^1]));
            else if (trimmed.EndsWith("R", StringComparison.InvariantCultureIgnoreCase)) return Angle<T>.FromRadians(StringParser<T>.Parse(trimmed[0..^1]));
            else return Angle<T>.FromDegrees(StringParser<T>.Parse(trimmed));
        }

        public static Angle<T> operator -(Angle<T> value) => FromDegrees(-value.Degrees);
        public static Angle<T> operator -(Angle<T> value1, Angle<T> value2) => FromDegrees(value1.Degrees - value2.Degrees);
        public static Angle<T> operator +(Angle<T> value) => value;
        public static Angle<T> operator +(Angle<T> value1, Angle<T> value2) => FromDegrees(value1.Degrees + value2.Degrees);
        public static bool operator !=(Angle<T> left, Angle<T> right) => !(left == right);
        public static bool operator ==(Angle<T> left, Angle<T> right) => left.Equals(right);
    }
}
