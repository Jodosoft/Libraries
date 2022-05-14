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
    public readonly struct gsbyte : INumeric<gsbyte>
    {
        public static readonly gsbyte MaxValue = new gsbyte(sbyte.MaxValue);
        public static readonly gsbyte MinValue = new gsbyte(sbyte.MinValue);

        private readonly sbyte _value;

        private gsbyte(sbyte value)
        {
            _value = value;
        }

        private gsbyte(SerializationInfo info, StreamingContext context) : this(info.GetSByte(nameof(gsbyte))) { }
        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context) => info.AddValue(nameof(gsbyte), _value);

        public int CompareTo(gsbyte other) => _value.CompareTo(other._value);
        public int CompareTo(object? obj) => obj is gsbyte other ? CompareTo(other) : 1;
        public bool Equals(gsbyte other) => _value == other._value;
        public override bool Equals(object? obj) => obj is gsbyte other && Equals(other);
        public override int GetHashCode() => _value.GetHashCode();
        public override string ToString() => _value.ToString();
        public string ToString(IFormatProvider formatProvider) => _value.ToString(formatProvider);
        public string ToString(string format, IFormatProvider formatProvider) => _value.ToString(format, formatProvider);

        public static bool TryParse(string s, IFormatProvider provider, out gsbyte result) => Try.Run(() => Parse(s, provider), out result);
        public static bool TryParse(string s, NumberStyles style, IFormatProvider provider, out gsbyte result) => Try.Run(() => Parse(s, style, provider), out result);
        public static bool TryParse(string s, NumberStyles style, out gsbyte result) => Try.Run(() => Parse(s, style), out result);
        public static bool TryParse(string s, out gsbyte result) => Try.Run(() => Parse(s), out result);
        public static gsbyte Parse(string s) => sbyte.Parse(s);
        public static gsbyte Parse(string s, IFormatProvider provider) => sbyte.Parse(s, provider);
        public static gsbyte Parse(string s, NumberStyles style) => sbyte.Parse(s, style);
        public static gsbyte Parse(string s, NumberStyles style, IFormatProvider provider) => sbyte.Parse(s, style, provider);

        public static explicit operator gsbyte(byte value) => new gsbyte((sbyte)value);
        public static explicit operator gsbyte(char value) => new gsbyte((sbyte)value);
        public static explicit operator gsbyte(decimal value) => new gsbyte((sbyte)value);
        public static explicit operator gsbyte(double value) => new gsbyte((sbyte)value);
        public static explicit operator gsbyte(float value) => new gsbyte((sbyte)value);
        public static explicit operator gsbyte(int value) => new gsbyte((sbyte)value);
        public static explicit operator gsbyte(long value) => new gsbyte((sbyte)value);
        public static explicit operator gsbyte(short value) => new gsbyte((sbyte)value);
        public static explicit operator gsbyte(uint value) => new gsbyte((sbyte)value);
        public static explicit operator gsbyte(ulong value) => new gsbyte((sbyte)value);
        public static explicit operator gsbyte(ushort value) => new gsbyte((sbyte)value);
        public static implicit operator gsbyte(sbyte value) => new gsbyte(value);

        public static explicit operator byte(gsbyte value) => (byte)value._value;
        public static explicit operator char(gsbyte value) => (char)value._value;
        public static explicit operator uint(gsbyte value) => (uint)value._value;
        public static explicit operator ulong(gsbyte value) => (ulong)value._value;
        public static explicit operator ushort(gsbyte value) => (ushort)value._value;
        public static implicit operator decimal(gsbyte value) => value._value;
        public static implicit operator double(gsbyte value) => value._value;
        public static implicit operator float(gsbyte value) => value._value;
        public static implicit operator int(gsbyte value) => value._value;
        public static implicit operator long(gsbyte value) => value._value;
        public static implicit operator sbyte(gsbyte value) => value._value;
        public static implicit operator short(gsbyte value) => value._value;

        public static bool operator !=(gsbyte left, gsbyte right) => left._value != right._value;
        public static bool operator <(gsbyte left, gsbyte right) => left._value < right._value;
        public static bool operator <=(gsbyte left, gsbyte right) => left._value <= right._value;
        public static bool operator ==(gsbyte left, gsbyte right) => left._value == right._value;
        public static bool operator >(gsbyte left, gsbyte right) => left._value > right._value;
        public static bool operator >=(gsbyte left, gsbyte right) => left._value >= right._value;
        public static gsbyte operator %(gsbyte left, gsbyte right) => (sbyte)(left._value % right._value);
        public static gsbyte operator &(gsbyte left, gsbyte right) => (sbyte)(left._value & right._value);
        public static gsbyte operator -(gsbyte left, gsbyte right) => (sbyte)(left._value - right._value);
        public static gsbyte operator --(gsbyte value) => (sbyte)(value._value - 1);
        public static gsbyte operator -(gsbyte value) => (sbyte)-value._value;
        public static gsbyte operator *(gsbyte left, gsbyte right) => (sbyte)(left._value * right._value);
        public static gsbyte operator /(gsbyte left, gsbyte right) => (sbyte)(left._value / right._value);
        public static gsbyte operator ^(gsbyte left, gsbyte right) => (sbyte)(left._value ^ right._value);
        public static gsbyte operator |(gsbyte left, gsbyte right) => (sbyte)(left._value | right._value);
        public static gsbyte operator ~(gsbyte value) => (sbyte)~value._value;
        public static gsbyte operator +(gsbyte left, gsbyte right) => (sbyte)(left._value + right._value);
        public static gsbyte operator +(gsbyte value) => value;
        public static gsbyte operator ++(gsbyte value) => (sbyte)(value._value + 1);
        public static gsbyte operator <<(gsbyte left, int right) => (sbyte)(left._value << right);
        public static gsbyte operator >>(gsbyte left, int right) => (sbyte)(left._value >> right);

        IBitConverter<gsbyte> IBitConvertible<gsbyte>.BitConverter => Utilities.Instance;
        IMath<gsbyte> INumeric<gsbyte>.Math => Utilities.Instance;
        IRandom<gsbyte> IRandomisable<gsbyte>.Random => Utilities.Instance;
        IStringParser<gsbyte> IStringRepresentable<gsbyte>.StringParser => Utilities.Instance;

        private sealed class Utilities : IMath<gsbyte>, IBitConverter<gsbyte>, IRandom<gsbyte>, IStringParser<gsbyte>
        {
            public readonly static Utilities Instance = new Utilities();

            gsbyte IMath<gsbyte>.E { get; } = (sbyte)2;
            gsbyte IMath<gsbyte>.PI { get; } = (sbyte)3;
            gsbyte IMath<gsbyte>.Epsilon { get; } = (sbyte)1;
            gsbyte IMath<gsbyte>.MaxValue => MaxValue;
            gsbyte IMath<gsbyte>.MinValue => MinValue;
            gsbyte IMath<gsbyte>.MaxUnit { get; } = (sbyte)1;
            gsbyte IMath<gsbyte>.MinUnit { get; } = (sbyte)-1;
            gsbyte IMath<gsbyte>.Zero { get; } = (sbyte)0;
            gsbyte IMath<gsbyte>.One { get; } = (sbyte)1;
            bool IMath<gsbyte>.IsSigned { get; } = true;
            bool IMath<gsbyte>.IsReal { get; } = false;

            bool IMath<gsbyte>.IsGreaterThan(gsbyte x, gsbyte y) => x > y;
            bool IMath<gsbyte>.IsGreaterThanOrEqualTo(gsbyte x, gsbyte y) => x >= y;
            bool IMath<gsbyte>.IsLessThan(gsbyte x, gsbyte y) => x < y;
            bool IMath<gsbyte>.IsLessThanOrEqualTo(gsbyte x, gsbyte y) => x <= y;
            gsbyte IMath<gsbyte>.Abs(gsbyte x) => Math.Abs(x._value);
            gsbyte IMath<gsbyte>.Acos(gsbyte x) => (sbyte)Math.Acos(x._value);
            gsbyte IMath<gsbyte>.Acosh(gsbyte x) => (sbyte)Math.Acosh(x._value);
            gsbyte IMath<gsbyte>.Add(gsbyte x, gsbyte y) => x + y;
            gsbyte IMath<gsbyte>.Asin(gsbyte x) => (sbyte)Math.Asin(x._value);
            gsbyte IMath<gsbyte>.Asinh(gsbyte x) => (sbyte)Math.Asinh(x._value);
            gsbyte IMath<gsbyte>.Atan(gsbyte x) => (sbyte)Math.Atan(x._value);
            gsbyte IMath<gsbyte>.Atan2(gsbyte x, gsbyte y) => (sbyte)Math.Atan2(x._value, y._value);
            gsbyte IMath<gsbyte>.Atanh(gsbyte x) => (sbyte)Math.Atanh(x._value);
            gsbyte IMath<gsbyte>.Cbrt(gsbyte x) => (sbyte)Math.Cbrt(x._value);
            gsbyte IMath<gsbyte>.Ceiling(gsbyte x) => x;
            gsbyte IMath<gsbyte>.Clamp(gsbyte x, gsbyte bound1, gsbyte bound2) => bound1 > bound2 ? Math.Min(bound1._value, Math.Max(bound2._value, x._value)) : Math.Min(bound2._value, Math.Max(bound1._value, x._value));
            gsbyte IMath<gsbyte>.Cos(gsbyte x) => (sbyte)Math.Cos(x._value);
            gsbyte IMath<gsbyte>.Cosh(gsbyte x) => (sbyte)Math.Cosh(x._value);
            gsbyte IMath<gsbyte>.DegreesToRadians(gsbyte x) => (sbyte)(x * Trig.RadiansPerDegree);
            gsbyte IMath<gsbyte>.DegreesToTurns(gsbyte x) => (sbyte)(x * Trig.TurnsPerDegree);
            gsbyte IMath<gsbyte>.Divide(gsbyte x, gsbyte y) => x / y;
            gsbyte IMath<gsbyte>.Exp(gsbyte x) => (sbyte)Math.Exp(x._value);
            gsbyte IMath<gsbyte>.Floor(gsbyte x) => x;
            gsbyte IMath<gsbyte>.IEEERemainder(gsbyte x, gsbyte y) => (sbyte)Math.IEEERemainder(x._value, y._value);
            gsbyte IMath<gsbyte>.Log(gsbyte x) => (sbyte)Math.Log(x._value);
            gsbyte IMath<gsbyte>.Log(gsbyte x, gsbyte y) => (sbyte)Math.Log(x._value, y._value);
            gsbyte IMath<gsbyte>.Log10(gsbyte x) => (sbyte)Math.Log10(x._value);
            gsbyte IMath<gsbyte>.Max(gsbyte x, gsbyte y) => Math.Max(x._value, y._value);
            gsbyte IMath<gsbyte>.Min(gsbyte x, gsbyte y) => Math.Min(x._value, y._value);
            gsbyte IMath<gsbyte>.Multiply(gsbyte x, gsbyte y) => x * y;
            gsbyte IMath<gsbyte>.Negative(gsbyte x) => -x;
            gsbyte IMath<gsbyte>.Positive(gsbyte x) => +x;
            gsbyte IMath<gsbyte>.Pow(gsbyte x, byte y) => (sbyte)Math.Pow(x._value, y);
            gsbyte IMath<gsbyte>.Pow(gsbyte x, gsbyte y) => (sbyte)Math.Pow(x._value, y._value);
            gsbyte IMath<gsbyte>.RadiansToDegrees(gsbyte x) => (sbyte)(x * Trig.DegreesPerRadian);
            gsbyte IMath<gsbyte>.RadiansToTurns(gsbyte x) => (sbyte)(x * Trig.TurnsPerRadian);
            gsbyte IMath<gsbyte>.Remainder(gsbyte x, gsbyte y) => x % y;
            gsbyte IMath<gsbyte>.Round(gsbyte x) => x;
            gsbyte IMath<gsbyte>.Round(gsbyte x, int digits) => x;
            gsbyte IMath<gsbyte>.Round(gsbyte x, int digits, MidpointRounding mode) => x;
            gsbyte IMath<gsbyte>.Round(gsbyte x, MidpointRounding mode) => x;
            gsbyte IMath<gsbyte>.Sin(gsbyte x) => (sbyte)Math.Sin(x._value);
            gsbyte IMath<gsbyte>.Sinh(gsbyte x) => (sbyte)Math.Sinh(x._value);
            gsbyte IMath<gsbyte>.Sqrt(gsbyte x) => (sbyte)Math.Sqrt(x._value);
            gsbyte IMath<gsbyte>.Subtract(gsbyte x, gsbyte y) => x - y;
            gsbyte IMath<gsbyte>.Tan(gsbyte x) => (sbyte)Math.Tan(x._value);
            gsbyte IMath<gsbyte>.Tanh(gsbyte x) => (sbyte)Math.Tanh(x._value);
            gsbyte IMath<gsbyte>.Truncate(gsbyte x) => x;
            gsbyte IMath<gsbyte>.TurnsToDegrees(gsbyte x) => (sbyte)(x * Trig.DegreesPerTurn);
            gsbyte IMath<gsbyte>.TurnsToRadians(gsbyte x) => (sbyte)(x * Trig.DegreesPerRadian);
            double IMath<gsbyte>.ToDouble(gsbyte x, double offset) => x._value + offset;
            float IMath<gsbyte>.ToSingle(gsbyte x, float offset) => x._value + offset;
            int IMath<gsbyte>.Sign(gsbyte x) => Math.Sign(x._value);

            gsbyte IBitConverter<gsbyte>.Read(IReadOnlyStream<byte> stream) => unchecked((sbyte)stream.Read(1)[0]);
            void IBitConverter<gsbyte>.Write(gsbyte value, IWriteOnlyStream<byte> stream) => stream.Write(BitConverter.GetBytes(value._value));

            gsbyte IRandom<gsbyte>.GetNext(Random random) => random.NextSByte();
            gsbyte IRandom<gsbyte>.GetNext(Random random, gsbyte bound1, gsbyte bound2) => random.NextSByte(bound1._value, bound2._value);

            gsbyte IStringParser<gsbyte>.Parse(string s) => Parse(s);
            gsbyte IStringParser<gsbyte>.Parse(string s, NumberStyles numberStyles, IFormatProvider formatProvider) => Parse(s, numberStyles, formatProvider);
        }

        IConvert<gsbyte> IConvertible<gsbyte>.Convert => _Convert.Instance;
        private sealed class _Convert : IConvert<gsbyte>
        {
            public readonly static _Convert Instance = new _Convert();

            bool IConvert<gsbyte>.ToBoolean(gsbyte value) => Convert.ToBoolean(value._value);
            byte IConvert<gsbyte>.ToByte(gsbyte value) => Convert.ToByte(value._value);
            char IConvert<gsbyte>.ToChar(gsbyte value) => Convert.ToChar(value._value);
            decimal IConvert<gsbyte>.ToDecimal(gsbyte value) => Convert.ToDecimal(value._value);
            double IConvert<gsbyte>.ToDouble(gsbyte value) => Convert.ToDouble(value._value);
            float IConvert<gsbyte>.ToSingle(gsbyte value) => Convert.ToSingle(value._value);
            int IConvert<gsbyte>.ToInt32(gsbyte value) => Convert.ToInt32(value._value);
            long IConvert<gsbyte>.ToInt64(gsbyte value) => Convert.ToInt64(value._value);
            sbyte IConvert<gsbyte>.ToSByte(gsbyte value) => Convert.ToSByte(value._value);
            short IConvert<gsbyte>.ToInt16(gsbyte value) => Convert.ToInt16(value._value);
            string IConvert<gsbyte>.ToString(gsbyte value) => Convert.ToString(value._value);
            string IConvert<gsbyte>.ToString(gsbyte value, IFormatProvider provider) => Convert.ToString(value._value, provider);
            uint IConvert<gsbyte>.ToUInt32(gsbyte value) => Convert.ToUInt32(value._value);
            ulong IConvert<gsbyte>.ToUInt64(gsbyte value) => Convert.ToUInt64(value._value);
            ushort IConvert<gsbyte>.ToUInt16(gsbyte value) => Convert.ToUInt16(value._value);

            gsbyte IConvert<gsbyte>.ToValue(bool value) => Convert.ToSByte(value);
            gsbyte IConvert<gsbyte>.ToValue(byte value) => Convert.ToSByte(value);
            gsbyte IConvert<gsbyte>.ToValue(char value) => Convert.ToSByte(value);
            gsbyte IConvert<gsbyte>.ToValue(decimal value) => Convert.ToSByte(value);
            gsbyte IConvert<gsbyte>.ToValue(double value) => Convert.ToSByte(value);
            gsbyte IConvert<gsbyte>.ToValue(float value) => Convert.ToSByte(value);
            gsbyte IConvert<gsbyte>.ToValue(int value) => Convert.ToSByte(value);
            gsbyte IConvert<gsbyte>.ToValue(long value) => Convert.ToSByte(value);
            gsbyte IConvert<gsbyte>.ToValue(sbyte value) => Convert.ToSByte(value);
            gsbyte IConvert<gsbyte>.ToValue(short value) => Convert.ToSByte(value);
            gsbyte IConvert<gsbyte>.ToValue(string value) => Convert.ToSByte(value);
            gsbyte IConvert<gsbyte>.ToValue(string value, IFormatProvider provider) => Convert.ToSByte(value, provider);
            gsbyte IConvert<gsbyte>.ToValue(uint value) => Convert.ToSByte(value);
            gsbyte IConvert<gsbyte>.ToValue(ulong value) => Convert.ToSByte(value);
            gsbyte IConvert<gsbyte>.ToValue(ushort value) => Convert.ToSByte(value);
        }
    }
}
