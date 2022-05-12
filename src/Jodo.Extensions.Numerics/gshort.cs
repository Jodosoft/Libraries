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
    public readonly struct gshort : INumeric<gshort>
    {
        public static readonly gshort MaxValue = new gshort(short.MaxValue);
        public static readonly gshort MinValue = new gshort(short.MinValue);

        private readonly short _value;

        private gshort(short value)
        {
            _value = value;
        }

        private gshort(SerializationInfo info, StreamingContext context) : this(info.GetInt16(nameof(gshort))) { }
        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context) => info.AddValue(nameof(gshort), _value);

        public int CompareTo(gshort other) => _value.CompareTo(other._value);
        public int CompareTo(object? obj) => obj is gshort other ? CompareTo(other) : 1;
        public bool Equals(gshort other) => _value == other._value;
        public override bool Equals(object? obj) => obj is gshort other && Equals(other);
        public override int GetHashCode() => _value.GetHashCode();
        public override string ToString() => _value.ToString();
        public string ToString(string format, IFormatProvider formatProvider) => _value.ToString(format, formatProvider);

        public static bool TryParse(string s, IFormatProvider provider, out gshort result) => Try.Run(() => Parse(s, provider), out result);
        public static bool TryParse(string s, NumberStyles style, IFormatProvider provider, out gshort result) => Try.Run(() => Parse(s, style, provider), out result);
        public static bool TryParse(string s, NumberStyles style, out gshort result) => Try.Run(() => Parse(s, style), out result);
        public static bool TryParse(string s, out gshort result) => Try.Run(() => Parse(s), out result);
        public static gshort Parse(string s) => short.Parse(s);
        public static gshort Parse(string s, IFormatProvider provider) => short.Parse(s, provider);
        public static gshort Parse(string s, NumberStyles style) => short.Parse(s, style);
        public static gshort Parse(string s, NumberStyles style, IFormatProvider provider) => short.Parse(s, style, provider);

        public static explicit operator gshort(in decimal value) => new gshort((short)value);
        public static explicit operator gshort(in double value) => new gshort((short)value);
        public static explicit operator gshort(in float value) => new gshort((short)value);
        public static explicit operator gshort(in int value) => new gshort((short)value);
        public static explicit operator gshort(in long value) => new gshort((short)value);
        public static explicit operator gshort(in uint value) => new gshort((short)value);
        public static explicit operator gshort(in ulong value) => new gshort((short)value);
        public static explicit operator gshort(in ushort value) => new gshort((short)value);
        public static implicit operator gshort(in byte value) => new gshort(value);
        public static implicit operator gshort(in sbyte value) => new gshort(value);
        public static implicit operator gshort(in short value) => new gshort(value);

        public static explicit operator byte(in gshort value) => (byte)value._value;
        public static explicit operator sbyte(in gshort value) => (sbyte)value._value;
        public static explicit operator uint(in gshort value) => (uint)value._value;
        public static explicit operator ulong(in gshort value) => (ulong)value._value;
        public static explicit operator ushort(in gshort value) => (ushort)value._value;
        public static implicit operator decimal(in gshort value) => value._value;
        public static implicit operator double(in gshort value) => value._value;
        public static implicit operator float(in gshort value) => value._value;
        public static implicit operator int(in gshort value) => value._value;
        public static implicit operator long(in gshort value) => value._value;
        public static implicit operator short(in gshort value) => value._value;

        public static bool operator !=(in gshort left, in gshort right) => left._value != right._value;
        public static bool operator <(in gshort left, in gshort right) => left._value < right._value;
        public static bool operator <=(in gshort left, in gshort right) => left._value <= right._value;
        public static bool operator ==(in gshort left, in gshort right) => left._value == right._value;
        public static bool operator >(in gshort left, in gshort right) => left._value > right._value;
        public static bool operator >=(in gshort left, in gshort right) => left._value >= right._value;
        public static gshort operator %(in gshort left, in gshort right) => (short)(left._value % right._value);
        public static gshort operator &(in gshort left, in gshort right) => (short)(left._value & right._value);
        public static gshort operator -(in gshort left, in gshort right) => (short)(left._value - right._value);
        public static gshort operator --(in gshort value) => (short)(value._value - 1);
        public static gshort operator -(in gshort value) => (short)-value._value;
        public static gshort operator *(in gshort left, in gshort right) => (short)(left._value * right._value);
        public static gshort operator /(in gshort left, in gshort right) => (short)(left._value / right._value);
        public static gshort operator ^(in gshort left, in gshort right) => (short)(left._value ^ right._value);
        public static gshort operator |(in gshort left, in gshort right) => (short)(left._value | right._value);
        public static gshort operator ~(in gshort value) => (short)~value._value;
        public static gshort operator +(in gshort left, in gshort right) => (short)(left._value + right._value);
        public static gshort operator +(in gshort value) => value;
        public static gshort operator ++(in gshort value) => (short)(value._value + 1);
        public static gshort operator <<(in gshort left, in int right) => (short)(left._value << right);
        public static gshort operator >>(in gshort left, in int right) => (short)(left._value >> right);

        IBitConverter<gshort> IBitConvertible<gshort>.BitConverter => Utilities.Instance;
        IMath<gshort> INumeric<gshort>.Math => Utilities.Instance;
        IRandom<gshort> IRandomisable<gshort>.Random => Utilities.Instance;
        IStringParser<gshort> IStringRepresentable<gshort>.StringParser => Utilities.Instance;

        private sealed class Utilities : IMath<gshort>, IBitConverter<gshort>, IRandom<gshort>, IStringParser<gshort>
        {
            public readonly static Utilities Instance = new Utilities();

            gshort IMath<gshort>.E { get; } = (short)3;
            gshort IMath<gshort>.PI { get; } = (short)3;
            gshort IMath<gshort>.Epsilon { get; } = (short)1;
            gshort IMath<gshort>.MaxValue => MaxValue;
            gshort IMath<gshort>.MinValue => MinValue;
            gshort IMath<gshort>.MaxUnit { get; } = (short)1;
            gshort IMath<gshort>.MinUnit { get; } = (short)-1;
            gshort IMath<gshort>.Zero { get; } = (short)0;
            gshort IMath<gshort>.One { get; } = (short)1;
            bool IMath<gshort>.IsSigned { get; } = true;
            bool IMath<gshort>.IsReal { get; } = false;

            bool IMath<gshort>.IsGreaterThan(in gshort x, in gshort y) => x > y;
            bool IMath<gshort>.IsGreaterThanOrEqualTo(in gshort x, in gshort y) => x >= y;
            bool IMath<gshort>.IsLessThan(in gshort x, in gshort y) => x < y;
            bool IMath<gshort>.IsLessThanOrEqualTo(in gshort x, in gshort y) => x <= y;
            gshort IMath<gshort>.Abs(in gshort x) => Math.Abs(x._value);
            gshort IMath<gshort>.Acos(in gshort x) => Convert.ToInt16(Math.Acos(x._value));
            gshort IMath<gshort>.Acosh(in gshort x) => Convert.ToInt16(Math.Acosh(x._value));
            gshort IMath<gshort>.Add(in gshort x, in gshort y) => x + y;
            gshort IMath<gshort>.Asin(in gshort x) => Convert.ToInt16(Math.Asin(x._value));
            gshort IMath<gshort>.Asinh(in gshort x) => Convert.ToInt16(Math.Asinh(x._value));
            gshort IMath<gshort>.Atan(in gshort x) => Convert.ToInt16(Math.Atan(x._value));
            gshort IMath<gshort>.Atan2(in gshort x, in gshort y) => Convert.ToInt16(Math.Atan2(x._value, y._value));
            gshort IMath<gshort>.Atanh(in gshort x) => Convert.ToInt16(Math.Atanh(x._value));
            gshort IMath<gshort>.Cbrt(in gshort x) => Convert.ToInt16(Math.Cbrt(x._value));
            gshort IMath<gshort>.Ceiling(in gshort x) => x;
            gshort IMath<gshort>.Clamp(in gshort x, in gshort bound1, in gshort bound2) => bound1 > bound2 ? Math.Min(bound1._value, Math.Max(bound2._value, x._value)) : Math.Min(bound2._value, Math.Max(bound1._value, x._value));
            gshort IMath<gshort>.Convert(in byte value) => value;
            gshort IMath<gshort>.Cos(in gshort x) => Convert.ToInt16(Math.Cos(x._value));
            gshort IMath<gshort>.Cosh(in gshort x) => Convert.ToInt16(Math.Cosh(x._value));
            gshort IMath<gshort>.DegreesToRadians(in gshort x) => Convert.ToInt16(x * AngleConstants.RadiansPerDegree);
            gshort IMath<gshort>.DegreesToTurns(in gshort x) => Convert.ToInt16(x * AngleConstants.TurnsPerDegree);
            gshort IMath<gshort>.Divide(in gshort x, in gshort y) => x / y;
            gshort IMath<gshort>.Exp(in gshort x) => Convert.ToInt16(Math.Exp(x._value));
            gshort IMath<gshort>.Floor(in gshort x) => x;
            gshort IMath<gshort>.IEEERemainder(in gshort x, in gshort y) => Convert.ToInt16(Math.IEEERemainder(x._value, y._value));
            gshort IMath<gshort>.Log(in gshort x) => Convert.ToInt16(Math.Log(x._value));
            gshort IMath<gshort>.Log(in gshort x, in gshort y) => Convert.ToInt16(Math.Log(x._value, y._value));
            gshort IMath<gshort>.Log10(in gshort x) => Convert.ToInt16(Math.Log10(x._value));
            gshort IMath<gshort>.Max(in gshort x, in gshort y) => Math.Max(x._value, y._value);
            gshort IMath<gshort>.Min(in gshort x, in gshort y) => Math.Min(x._value, y._value);
            gshort IMath<gshort>.Multiply(in gshort x, in gshort y) => x * y;
            gshort IMath<gshort>.Negative(in gshort x) => -x;
            gshort IMath<gshort>.Positive(in gshort x) => +x;
            gshort IMath<gshort>.Pow(in gshort x, in byte y) => (short)Math.Pow(x._value, y);
            gshort IMath<gshort>.Pow(in gshort x, in gshort y) => (short)Math.Pow(x._value, y._value);
            gshort IMath<gshort>.RadiansToDegrees(in gshort x) => Convert.ToInt16(x * AngleConstants.DegreesPerRadian);
            gshort IMath<gshort>.RadiansToTurns(in gshort x) => Convert.ToInt16(x * AngleConstants.TurnsPerRadian);
            gshort IMath<gshort>.Remainder(in gshort x, in gshort y) => x % y;
            gshort IMath<gshort>.Round(in gshort x) => x;
            gshort IMath<gshort>.Round(in gshort x, in int digits) => x;
            gshort IMath<gshort>.Round(in gshort x, in int digits, in MidpointRounding mode) => x;
            gshort IMath<gshort>.Round(in gshort x, in MidpointRounding mode) => x;
            gshort IMath<gshort>.Sin(in gshort x) => Convert.ToInt16(Math.Sin(x._value));
            gshort IMath<gshort>.Sinh(in gshort x) => Convert.ToInt16(Math.Sinh(x._value));
            gshort IMath<gshort>.Sqrt(in gshort x) => Convert.ToInt16(Math.Sqrt(x._value));
            gshort IMath<gshort>.Subtract(in gshort x, in gshort y) => x - y;
            gshort IMath<gshort>.Tan(in gshort x) => Convert.ToInt16(Math.Tan(x._value));
            gshort IMath<gshort>.Tanh(in gshort x) => Convert.ToInt16(Math.Tanh(x._value));
            gshort IMath<gshort>.Truncate(in gshort x) => x;
            gshort IMath<gshort>.TurnsToDegrees(in gshort x) => Convert.ToInt16(x * AngleConstants.DegreesPerTurn);
            gshort IMath<gshort>.TurnsToRadians(in gshort x) => Convert.ToInt16(x * AngleConstants.DegreesPerRadian);
            double IMath<gshort>.ToDouble(in gshort x, in double offset) => x._value + offset;
            float IMath<gshort>.ToSingle(in gshort x, in float offset) => x._value + offset;
            int IMath<gshort>.Sign(in gshort x) => Math.Sign(x._value);

            gshort IBitConverter<gshort>.Read(in IReadOnlyStream<byte> stream) => BitConverter.ToInt16(stream.Read(sizeof(int)));
            void IBitConverter<gshort>.Write(gshort value, in IWriteOnlyStream<byte> stream) => stream.Write(BitConverter.GetBytes(value._value));

            gshort IRandom<gshort>.GetNext(Random random) => random.NextInt16();
            gshort IRandom<gshort>.GetNext(Random random, in gshort bound1, in gshort bound2) => random.NextInt16(bound1._value, bound2._value);

            gshort IStringParser<gshort>.Parse(in string s) => Parse(s);
            gshort IStringParser<gshort>.Parse(in string s, in NumberStyles numberStyles, in IFormatProvider formatProvider) => Parse(s, numberStyles, formatProvider);
        }
    }
}
