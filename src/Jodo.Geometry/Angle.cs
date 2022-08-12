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
using System.Runtime.Serialization;
using Jodo.Numerics;
using Jodo.Primitives;

namespace Jodo.Geometry
{
    public static class Angle
    {
        public static Angle<TNumeric> FromDegrees<TNumeric>(TNumeric degrees) where TNumeric : struct, INumeric<TNumeric>
            => new Angle<TNumeric>(degrees);

        public static Angle<TNumeric> FromDegrees<TNumeric>(byte degrees) where TNumeric : struct, INumeric<TNumeric>
            => new Angle<TNumeric>(ConvertN.ToNumeric<TNumeric>(degrees));

        public static Angle<TNumeric> FromRadians<TNumeric>(TNumeric radians) where TNumeric : struct, INumeric<TNumeric>
            => new Angle<TNumeric>(MathN.RadiansToDegrees(radians));

        public static Angle<TNumeric> FromRadians<TNumeric>(byte radians) where TNumeric : struct, INumeric<TNumeric>
            => new Angle<TNumeric>(MathN.RadiansToDegrees(ConvertN.ToNumeric<TNumeric>(radians)));
    }

    [Serializable]
    [DebuggerDisplay("{ToString(),nq}")]
    public readonly struct Angle<TNumeric> :
            IComparable,
            IComparable<Angle<TNumeric>>,
            IEquatable<Angle<TNumeric>>,
            IFormattable,
            IProvider<IBitConvert<Angle<TNumeric>>>,
            IProvider<IRandom<Angle<TNumeric>>>,
            IProvider<IStringConvert<Angle<TNumeric>>>,
            ISerializable
        where TNumeric : struct, INumeric<TNumeric>
    {
        public readonly TNumeric Degrees;

        public TNumeric GetRadians() => MathN.DegreesToRadians(Degrees);
        public TNumeric Cos() => MathN.Cos(GetRadians());
        public TNumeric Cosh() => MathN.Cosh(GetRadians());
        public TNumeric Sinh() => MathN.Sinh(GetRadians());
        public TNumeric Tanh() => MathN.Tanh(GetRadians());
        public TNumeric Sin() => MathN.Sin(GetRadians());
        public TNumeric Tan() => MathN.Tan(GetRadians());

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

        public static implicit operator TNumeric(Angle<TNumeric> unit) => unit.Degrees;
        public static explicit operator Angle<TNumeric>(TNumeric value) => new Angle<TNumeric>(value);

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

        public static bool operator !=(Angle<TNumeric> left, TNumeric right) => !left.Degrees.Equals(right);
        public static bool operator <(Angle<TNumeric> left, TNumeric right) => left.Degrees.IsLessThan(right);
        public static bool operator <=(Angle<TNumeric> left, TNumeric right) => left.Degrees.IsLessThanOrEqualTo(right);
        public static bool operator ==(Angle<TNumeric> left, TNumeric right) => left.Degrees.Equals(right);
        public static bool operator >(Angle<TNumeric> left, TNumeric right) => left.Degrees.IsGreaterThan(right);
        public static bool operator >=(Angle<TNumeric> left, TNumeric right) => left.Degrees.IsGreaterThanOrEqualTo(right);
        public static Angle<TNumeric> operator %(Angle<TNumeric> left, TNumeric right) => new Angle<TNumeric>(left.Degrees.Remainder(right));
        public static Angle<TNumeric> operator -(Angle<TNumeric> left, TNumeric right) => new Angle<TNumeric>(left.Degrees.Subtract(right));
        public static Angle<TNumeric> operator *(Angle<TNumeric> left, TNumeric right) => new Angle<TNumeric>(left.Degrees.Multiply(right));
        public static Angle<TNumeric> operator /(Angle<TNumeric> left, TNumeric right) => new Angle<TNumeric>(left.Degrees.Divide(right));
        public static Angle<TNumeric> operator +(Angle<TNumeric> left, TNumeric right) => new Angle<TNumeric>(left.Degrees.Add(right));

        public static bool operator !=(TNumeric left, Angle<TNumeric> right) => !left.Equals(right.Degrees);
        public static bool operator <(TNumeric left, Angle<TNumeric> right) => left.IsLessThan(right.Degrees);
        public static bool operator <=(TNumeric left, Angle<TNumeric> right) => left.IsLessThanOrEqualTo(right.Degrees);
        public static bool operator ==(TNumeric left, Angle<TNumeric> right) => left.Equals(right.Degrees);
        public static bool operator >(TNumeric left, Angle<TNumeric> right) => left.IsGreaterThan(right.Degrees);
        public static bool operator >=(TNumeric left, Angle<TNumeric> right) => left.IsGreaterThanOrEqualTo(right.Degrees);
        public static Angle<TNumeric> operator %(TNumeric left, Angle<TNumeric> right) => new Angle<TNumeric>(left.Remainder(right.Degrees));
        public static Angle<TNumeric> operator -(TNumeric left, Angle<TNumeric> right) => new Angle<TNumeric>(left.Subtract(right.Degrees));
        public static Angle<TNumeric> operator *(TNumeric left, Angle<TNumeric> right) => new Angle<TNumeric>(left.Multiply(right.Degrees));
        public static Angle<TNumeric> operator /(TNumeric left, Angle<TNumeric> right) => new Angle<TNumeric>(left.Divide(right.Degrees));
        public static Angle<TNumeric> operator +(TNumeric left, Angle<TNumeric> right) => new Angle<TNumeric>(left.Add(right.Degrees));

        IBitConvert<Angle<TNumeric>> IProvider<IBitConvert<Angle<TNumeric>>>.GetInstance() => Utilities.Instance;
        IRandom<Angle<TNumeric>> IProvider<IRandom<Angle<TNumeric>>>.GetInstance() => Utilities.Instance;
        IStringConvert<Angle<TNumeric>> IProvider<IStringConvert<Angle<TNumeric>>>.GetInstance() => Utilities.Instance;

        private sealed class Utilities :
            IBitConvert<Angle<TNumeric>>,
            IRandom<Angle<TNumeric>>,
            IStringConvert<Angle<TNumeric>>
        {
            public static readonly Utilities Instance = new Utilities();

            Angle<TNumeric> IRandom<Angle<TNumeric>>.Next(Random random) => new Angle<TNumeric>(random.NextNumeric<TNumeric>());
            Angle<TNumeric> IRandom<Angle<TNumeric>>.Next(Random random, Angle<TNumeric> bound1, Angle<TNumeric> bound2) => new Angle<TNumeric>(random.NextNumeric(bound1.Degrees, bound2.Degrees));

            Angle<TNumeric> IStringConvert<Angle<TNumeric>>.Parse(string s, NumberStyles? style, IFormatProvider? provider)
            {
                string trimmed = s.Trim();

                if (TryParse(trimmed, "°", style, provider, out TNumeric number)) return Angle.FromDegrees(number);
                if (TryParse(trimmed, "Degrees", style, provider, out number)) return Angle.FromDegrees(number);
                if (TryParse(trimmed, "Degree", style, provider, out number)) return Angle.FromDegrees(number);
                if (TryParse(trimmed, "Deg", style, provider, out number)) return Angle.FromDegrees(number);
                if (TryParse(trimmed, "Radians", style, provider, out number)) return Angle.FromRadians(number);
                if (TryParse(trimmed, "Radian", style, provider, out number)) return Angle.FromRadians(number);
                if (TryParse(trimmed, "Rad", style, provider, out number)) return Angle.FromRadians(number);
                if (TryParse(trimmed, "C", style, provider, out number)) return Angle.FromRadians(number);
                if (TryParse(trimmed, "R", style, provider, out number)) return Angle.FromRadians(number);

                return Angle.FromDegrees(StringConvert.Parse<TNumeric>(trimmed));
            }

            Angle<TNumeric> IBitConvert<Angle<TNumeric>>.Read(IReader<byte> stream)
                => new Angle<TNumeric>(BitConvert.Read<TNumeric>(stream));

            void IBitConvert<Angle<TNumeric>>.Write(Angle<TNumeric> value, IWriter<byte> stream)
                => BitConvert.Write(stream, value.Degrees);

            private static bool TryParse(string value, string unit, NumberStyles? style, IFormatProvider? provider, out TNumeric number)
            {
                if (value.EndsWith(unit, StringComparison.InvariantCultureIgnoreCase))
                {
                    number = StringConvert.Parse<TNumeric>(value.Substring(0, value.Length - unit.Length), style, provider);
                    return true;
                }
                number = default;
                return false;
            }
        }
    }
}
