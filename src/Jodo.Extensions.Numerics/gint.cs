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

using Jodo.Extensions.Primitives;
using System;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Runtime.Serialization;

namespace Jodo.Extensions.Numerics
{
    [Serializable]
    [DebuggerDisplay("{ToString(),nq}")]
    [SuppressMessage("Style", "IDE1006:Naming Styles")]
    [SuppressMessage("CodeQuality", "IDE0079:Remove unnecessary suppression")]
    [SuppressMessage("csharpsquid", "S101")]
    public readonly struct gint : INumeric<gint>
    {
        public static readonly gint MaxValue = new gint(int.MaxValue);
        public static readonly gint MinValue = new gint(int.MinValue);

        private readonly int _value;

        private gint(int value)
        {
            _value = value;
        }

        private gint(SerializationInfo info, StreamingContext context) : this(info.GetInt32(nameof(gint))) { }
        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context) => info.AddValue(nameof(gint), _value);

        public int CompareTo(gint other) => _value.CompareTo(other._value);
        public int CompareTo(object? obj) => obj is gint other ? CompareTo(other) : 1;
        public bool Equals(gint other) => _value == other._value;
        public override bool Equals(object? obj) => obj is gint other && Equals(other);
        public override int GetHashCode() => _value.GetHashCode();
        public override string ToString() => _value.ToString();
        public string ToString(string format, IFormatProvider formatProvider) => _value.ToString(format, formatProvider);

        public static bool TryParse(string s, IFormatProvider provider, out gint result) => Try.Run(() => Parse(s, provider), out result);
        public static bool TryParse(string s, NumberStyles style, IFormatProvider provider, out gint result) => Try.Run(() => Parse(s, style, provider), out result);
        public static bool TryParse(string s, NumberStyles style, out gint result) => Try.Run(() => Parse(s, style), out result);
        public static bool TryParse(string s, out gint result) => Try.Run(() => Parse(s), out result);
        public static gint Parse(string s) => int.Parse(s);
        public static gint Parse(string s, IFormatProvider provider) => int.Parse(s, provider);
        public static gint Parse(string s, NumberStyles style) => int.Parse(s, style);
        public static gint Parse(string s, NumberStyles style, IFormatProvider provider) => int.Parse(s, style, provider);

        public static explicit operator gint(in decimal value) => new gint((int)value);
        public static explicit operator gint(in double value) => new gint((int)value);
        public static explicit operator gint(in float value) => new gint((int)value);
        public static explicit operator gint(in long value) => new gint((int)value);
        public static explicit operator gint(in uint value) => new gint((int)value);
        public static explicit operator gint(in ulong value) => new gint((int)value);
        public static implicit operator gint(in byte value) => new gint(value);
        public static implicit operator gint(in int value) => new gint(value);
        public static implicit operator gint(in sbyte value) => new gint(value);
        public static implicit operator gint(in short value) => new gint(value);
        public static implicit operator gint(in ushort value) => new gint(value);

        public static explicit operator byte(in gint value) => (byte)value._value;
        public static explicit operator sbyte(in gint value) => (sbyte)value._value;
        public static explicit operator short(in gint value) => (short)value._value;
        public static explicit operator uint(in gint value) => (uint)value._value;
        public static explicit operator ulong(in gint value) => (ulong)value._value;
        public static explicit operator ushort(in gint value) => (ushort)value._value;
        public static implicit operator decimal(in gint value) => value._value;
        public static implicit operator double(in gint value) => value._value;
        public static implicit operator float(in gint value) => value._value;
        public static implicit operator int(in gint value) => value._value;
        public static implicit operator long(in gint value) => value._value;

        public static bool operator !=(in gint left, in gint right) => left._value != right._value;
        public static bool operator <(in gint left, in gint right) => left._value < right._value;
        public static bool operator <=(in gint left, in gint right) => left._value <= right._value;
        public static bool operator ==(in gint left, in gint right) => left._value == right._value;
        public static bool operator >(in gint left, in gint right) => left._value > right._value;
        public static bool operator >=(in gint left, in gint right) => left._value >= right._value;
        public static gint operator %(in gint left, in gint right) => left._value % right._value;
        public static gint operator &(in gint left, in gint right) => left._value & right._value;
        public static gint operator -(in gint left, in gint right) => left._value - right._value;
        public static gint operator --(in gint value) => value._value - 1;
        public static gint operator -(in gint value) => -value._value;
        public static gint operator *(in gint left, in gint right) => left._value * right._value;
        public static gint operator /(in gint left, in gint right) => left._value / right._value;
        public static gint operator ^(in gint left, in gint right) => left._value ^ right._value;
        public static gint operator |(in gint left, in gint right) => left._value | right._value;
        public static gint operator ~(in gint value) => ~value._value;
        public static gint operator +(in gint left, in gint right) => left._value + right._value;
        public static gint operator +(in gint value) => value;
        public static gint operator ++(in gint value) => value._value + 1;
        public static gint operator <<(in gint left, in int right) => left._value << right;
        public static gint operator >>(in gint left, in int right) => left._value >> right;

        IBitConverter<gint> IBitConvertible<gint>.BitConverter => Utilities.Instance;
        IMath<gint> INumeric<gint>.Math => Utilities.Instance;
        IRandom<gint> IRandomisable<gint>.Random => Utilities.Instance;
        IStringParser<gint> IStringRepresentable<gint>.StringParser => Utilities.Instance;

        private sealed class Utilities : IMath<gint>, IBitConverter<gint>, IRandom<gint>, IStringParser<gint>
        {
            public readonly static Utilities Instance = new Utilities();

            gint IMath<gint>.E { get; } = 3;
            gint IMath<gint>.PI { get; } = 3;
            gint IMath<gint>.Epsilon { get; } = 1;
            gint IMath<gint>.MaxValue => MaxValue;
            gint IMath<gint>.MinValue => MinValue;
            gint IMath<gint>.MaxUnit { get; } = 1;
            gint IMath<gint>.MinUnit { get; } = -1;
            gint IMath<gint>.Zero { get; } = 0;
            gint IMath<gint>.One { get; } = 1;
            bool IMath<gint>.IsSigned { get; } = true;
            bool IMath<gint>.IsReal { get; } = false;

            bool IMath<gint>.IsGreaterThan(in gint x, in gint y) => x > y;
            bool IMath<gint>.IsGreaterThanOrEqualTo(in gint x, in gint y) => x >= y;
            bool IMath<gint>.IsLessThan(in gint x, in gint y) => x < y;
            bool IMath<gint>.IsLessThanOrEqualTo(in gint x, in gint y) => x <= y;
            gint IMath<gint>.Abs(in gint x) => Math.Abs(x._value);
            gint IMath<gint>.Acos(in gint x) => Convert.ToInt32(Math.Acos(x._value));
            gint IMath<gint>.Acosh(in gint x) => Convert.ToInt32(Math.Acosh(x._value));
            gint IMath<gint>.Add(in gint x, in gint y) => x + y;
            gint IMath<gint>.Asin(in gint x) => Convert.ToInt32(Math.Asin(x._value));
            gint IMath<gint>.Asinh(in gint x) => Convert.ToInt32(Math.Asinh(x._value));
            gint IMath<gint>.Atan(in gint x) => Convert.ToInt32(Math.Atan(x._value));
            gint IMath<gint>.Atan2(in gint x, in gint y) => Convert.ToInt32(Math.Atan2(x._value, y._value));
            gint IMath<gint>.Atanh(in gint x) => Convert.ToInt32(Math.Atanh(x._value));
            gint IMath<gint>.Cbrt(in gint x) => Convert.ToInt32(Math.Cbrt(x._value));
            gint IMath<gint>.Ceiling(in gint x) => x;
            gint IMath<gint>.Clamp(in gint x, in gint bound1, in gint bound2) => bound1 > bound2 ? Math.Min(bound1._value, Math.Max(bound2._value, x._value)) : Math.Min(bound2._value, Math.Max(bound1._value, x._value));
            gint IMath<gint>.Convert(in byte value) => value;
            gint IMath<gint>.Cos(in gint x) => Convert.ToInt32(Math.Cos(x._value));
            gint IMath<gint>.Cosh(in gint x) => Convert.ToInt32(Math.Cosh(x._value));
            gint IMath<gint>.DegreesToRadians(in gint x) => Convert.ToInt32(x * AngleConstants.RadiansPerDegree);
            gint IMath<gint>.DegreesToTurns(in gint x) => Convert.ToInt32(x * AngleConstants.TurnsPerDegree);
            gint IMath<gint>.Divide(in gint x, in gint y) => x / y;
            gint IMath<gint>.Exp(in gint x) => Convert.ToInt32(Math.Exp(x._value));
            gint IMath<gint>.Floor(in gint x) => x;
            gint IMath<gint>.IEEERemainder(in gint x, in gint y) => Convert.ToInt32(Math.IEEERemainder(x._value, y._value));
            gint IMath<gint>.Log(in gint x) => Convert.ToInt32(Math.Log(x._value));
            gint IMath<gint>.Log(in gint x, in gint y) => Convert.ToInt32(Math.Log(x._value, y._value));
            gint IMath<gint>.Log10(in gint x) => Convert.ToInt32(Math.Log10(x._value));
            gint IMath<gint>.Max(in gint x, in gint y) => Math.Max(x._value, y._value);
            gint IMath<gint>.Min(in gint x, in gint y) => Math.Min(x._value, y._value);
            gint IMath<gint>.Multiply(in gint x, in gint y) => x * y;
            gint IMath<gint>.Negative(in gint x) => -x;
            gint IMath<gint>.Positive(in gint x) => +x;
            gint IMath<gint>.Pow(in gint x, in byte y) => (int)Math.Pow(x._value, y);
            gint IMath<gint>.Pow(in gint x, in gint y) => (int)Math.Pow(x._value, y._value);
            gint IMath<gint>.RadiansToDegrees(in gint x) => Convert.ToInt32(x * AngleConstants.DegreesPerRadian);
            gint IMath<gint>.RadiansToTurns(in gint x) => Convert.ToInt32(x * AngleConstants.TurnsPerRadian);
            gint IMath<gint>.Remainder(in gint x, in gint y) => x % y;
            gint IMath<gint>.Round(in gint x) => x;
            gint IMath<gint>.Round(in gint x, in int digits) => x;
            gint IMath<gint>.Round(in gint x, in int digits, in MidpointRounding mode) => x;
            gint IMath<gint>.Round(in gint x, in MidpointRounding mode) => x;
            gint IMath<gint>.Sin(in gint x) => Convert.ToInt32(Math.Sin(x._value));
            gint IMath<gint>.Sinh(in gint x) => Convert.ToInt32(Math.Sinh(x._value));
            gint IMath<gint>.Sqrt(in gint x) => Convert.ToInt32(Math.Sqrt(x._value));
            gint IMath<gint>.Subtract(in gint x, in gint y) => x - y;
            gint IMath<gint>.Tan(in gint x) => Convert.ToInt32(Math.Tan(x._value));
            gint IMath<gint>.Tanh(in gint x) => Convert.ToInt32(Math.Tanh(x._value));
            gint IMath<gint>.Truncate(in gint x) => x;
            gint IMath<gint>.TurnsToDegrees(in gint x) => Convert.ToInt32(x * AngleConstants.DegreesPerTurn);
            gint IMath<gint>.TurnsToRadians(in gint x) => Convert.ToInt32(x * AngleConstants.DegreesPerRadian);
            double IMath<gint>.ToDouble(in gint x, in double offset) => x._value + offset;
            float IMath<gint>.ToSingle(in gint x, in float offset) => x._value + offset;
            int IMath<gint>.Sign(in gint x) => Math.Sign(x._value);

            gint IBitConverter<gint>.Read(in IReadOnlyStream<byte> stream) => BitConverter.ToInt32(stream.Read(sizeof(int)));
            void IBitConverter<gint>.Write(gint value, in IWriteOnlyStream<byte> stream) => stream.Write(BitConverter.GetBytes(value._value));

            gint IRandom<gint>.GetNext(Random random) => random.NextInt32();
            gint IRandom<gint>.GetNext(Random random, in gint bound1, in gint bound2) => random.NextInt32(bound1._value, bound2._value);

            gint IStringParser<gint>.Parse(in string s) => Parse(s);
            gint IStringParser<gint>.Parse(in string s, in NumberStyles numberStyles, in IFormatProvider formatProvider) => Parse(s, numberStyles, formatProvider);
        }
    }
}
