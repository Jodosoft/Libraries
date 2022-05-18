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
    [SuppressMessage("csharpsquid", "S101")]
    public readonly struct xsbyte : INumeric<xsbyte>
    {
        public static readonly xsbyte MaxValue = new xsbyte(sbyte.MaxValue);
        public static readonly xsbyte MinValue = new xsbyte(sbyte.MinValue);

        private readonly sbyte _value;

        private xsbyte(sbyte value)
        {
            _value = value;
        }

        private xsbyte(SerializationInfo info, StreamingContext context) : this(info.GetSByte(nameof(xsbyte))) { }
        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context) => info.AddValue(nameof(xsbyte), _value);

        public int CompareTo(xsbyte other) => _value.CompareTo(other._value);
        public int CompareTo(object? obj) => obj is xsbyte other ? CompareTo(other) : 1;
        public bool Equals(xsbyte other) => _value == other._value;
        public override bool Equals(object? obj) => obj is xsbyte other && Equals(other);
        public override int GetHashCode() => _value.GetHashCode();
        public override string ToString() => _value.ToString();
        public string ToString(IFormatProvider formatProvider) => _value.ToString(formatProvider);
        public string ToString(string format, IFormatProvider formatProvider) => _value.ToString(format, formatProvider);

        public static bool TryParse(string s, IFormatProvider provider, out xsbyte result) => Try.Run(() => Parse(s, provider), out result);
        public static bool TryParse(string s, NumberStyles style, IFormatProvider provider, out xsbyte result) => Try.Run(() => Parse(s, style, provider), out result);
        public static bool TryParse(string s, NumberStyles style, out xsbyte result) => Try.Run(() => Parse(s, style), out result);
        public static bool TryParse(string s, out xsbyte result) => Try.Run(() => Parse(s), out result);
        public static xsbyte Parse(string s) => sbyte.Parse(s);
        public static xsbyte Parse(string s, IFormatProvider provider) => sbyte.Parse(s, provider);
        public static xsbyte Parse(string s, NumberStyles style) => sbyte.Parse(s, style);
        public static xsbyte Parse(string s, NumberStyles style, IFormatProvider provider) => sbyte.Parse(s, style, provider);

        public static explicit operator xsbyte(byte value) => new xsbyte((sbyte)value);
        public static explicit operator xsbyte(char value) => new xsbyte((sbyte)value);
        public static explicit operator xsbyte(decimal value) => new xsbyte((sbyte)value);
        public static explicit operator xsbyte(double value) => new xsbyte((sbyte)value);
        public static explicit operator xsbyte(float value) => new xsbyte((sbyte)value);
        public static explicit operator xsbyte(int value) => new xsbyte((sbyte)value);
        public static explicit operator xsbyte(long value) => new xsbyte((sbyte)value);
        public static explicit operator xsbyte(short value) => new xsbyte((sbyte)value);
        public static explicit operator xsbyte(uint value) => new xsbyte((sbyte)value);
        public static explicit operator xsbyte(ulong value) => new xsbyte((sbyte)value);
        public static explicit operator xsbyte(ushort value) => new xsbyte((sbyte)value);
        public static implicit operator xsbyte(sbyte value) => new xsbyte(value);

        public static explicit operator byte(xsbyte value) => (byte)value._value;
        public static explicit operator char(xsbyte value) => (char)value._value;
        public static explicit operator uint(xsbyte value) => (uint)value._value;
        public static explicit operator ulong(xsbyte value) => (ulong)value._value;
        public static explicit operator ushort(xsbyte value) => (ushort)value._value;
        public static implicit operator decimal(xsbyte value) => value._value;
        public static implicit operator double(xsbyte value) => value._value;
        public static implicit operator float(xsbyte value) => value._value;
        public static implicit operator int(xsbyte value) => value._value;
        public static implicit operator long(xsbyte value) => value._value;
        public static implicit operator sbyte(xsbyte value) => value._value;
        public static implicit operator short(xsbyte value) => value._value;

        public static bool operator !=(xsbyte left, xsbyte right) => left._value != right._value;
        public static bool operator <(xsbyte left, xsbyte right) => left._value < right._value;
        public static bool operator <=(xsbyte left, xsbyte right) => left._value <= right._value;
        public static bool operator ==(xsbyte left, xsbyte right) => left._value == right._value;
        public static bool operator >(xsbyte left, xsbyte right) => left._value > right._value;
        public static bool operator >=(xsbyte left, xsbyte right) => left._value >= right._value;
        public static xsbyte operator %(xsbyte left, xsbyte right) => (sbyte)(left._value % right._value);
        public static xsbyte operator &(xsbyte left, xsbyte right) => (sbyte)(left._value & right._value);
        public static xsbyte operator -(xsbyte left, xsbyte right) => (sbyte)(left._value - right._value);
        public static xsbyte operator --(xsbyte value) => (sbyte)(value._value - 1);
        public static xsbyte operator -(xsbyte value) => (sbyte)-value._value;
        public static xsbyte operator *(xsbyte left, xsbyte right) => (sbyte)(left._value * right._value);
        public static xsbyte operator /(xsbyte left, xsbyte right) => (sbyte)(left._value / right._value);
        public static xsbyte operator ^(xsbyte left, xsbyte right) => (sbyte)(left._value ^ right._value);
        public static xsbyte operator |(xsbyte left, xsbyte right) => (sbyte)(left._value | right._value);
        public static xsbyte operator ~(xsbyte value) => (sbyte)~value._value;
        public static xsbyte operator +(xsbyte left, xsbyte right) => (sbyte)(left._value + right._value);
        public static xsbyte operator +(xsbyte value) => value;
        public static xsbyte operator ++(xsbyte value) => (sbyte)(value._value + 1);
        public static xsbyte operator <<(xsbyte left, int right) => (sbyte)(left._value << right);
        public static xsbyte operator >>(xsbyte left, int right) => (sbyte)(left._value >> right);

        bool INumeric<xsbyte>.IsGreaterThan(xsbyte value) => this > value;
        bool INumeric<xsbyte>.IsGreaterThanOrEqualTo(xsbyte value) => this >= value;
        bool INumeric<xsbyte>.IsLessThan(xsbyte value) => this < value;
        bool INumeric<xsbyte>.IsLessThanOrEqualTo(xsbyte value) => this <= value;
        xsbyte INumeric<xsbyte>.Add(xsbyte value) => this + value;
        xsbyte INumeric<xsbyte>.Divide(xsbyte value) => this / value;
        xsbyte INumeric<xsbyte>.Multiply(xsbyte value) => this * value;
        xsbyte INumeric<xsbyte>.Negative() => -this;
        xsbyte INumeric<xsbyte>.Positive() => +this;
        xsbyte INumeric<xsbyte>.Remainder(xsbyte value) => this % value;
        xsbyte INumeric<xsbyte>.Subtract(xsbyte value) => this - value;

        IBitConverter<xsbyte> IBitConvertible<xsbyte>.BitConverter => Utilities.Instance;
        IConvert<xsbyte> IConvertible<xsbyte>.Convert => Utilities.Instance;
        IMath<xsbyte> INumeric<xsbyte>.Math => Utilities.Instance;
        IRandom<xsbyte> IRandomisable<xsbyte>.Random => Utilities.Instance;
        IStringParser<xsbyte> IStringParsable<xsbyte>.StringParser => Utilities.Instance;

        private sealed class Utilities :
            IBitConverter<xsbyte>,
            IConvert<xsbyte>,
            IMath<xsbyte>,
            IRandom<xsbyte>,
            IStringParser<xsbyte>
        {
            public readonly static Utilities Instance = new Utilities();

            bool IMath<xsbyte>.IsReal { get; } = false;
            bool IMath<xsbyte>.IsSigned { get; } = true;
            xsbyte IMath<xsbyte>.Epsilon { get; } = 1;
            xsbyte IMath<xsbyte>.MaxUnit { get; } = 1;
            xsbyte IMath<xsbyte>.MaxValue => MaxValue;
            xsbyte IMath<xsbyte>.MinUnit { get; } = -1;
            xsbyte IMath<xsbyte>.MinValue => MinValue;
            xsbyte IMath<xsbyte>.One { get; } = 1;
            xsbyte IMath<xsbyte>.Zero { get; } = 0;
            xsbyte IMath<xsbyte>.E { get; } = 2;
            xsbyte IMath<xsbyte>.PI { get; } = 3;
            xsbyte IMath<xsbyte>.Tau { get; } = 6;

            int IMath<xsbyte>.Sign(xsbyte x) => Math.Sign(x._value);
            xsbyte IMath<xsbyte>.Abs(xsbyte x) => Math.Abs(x._value);
            xsbyte IMath<xsbyte>.Acos(xsbyte x) => (sbyte)Math.Acos(x._value);
            xsbyte IMath<xsbyte>.Acosh(xsbyte x) => (sbyte)Math.Acosh(x._value);
            xsbyte IMath<xsbyte>.Asin(xsbyte x) => (sbyte)Math.Asin(x._value);
            xsbyte IMath<xsbyte>.Asinh(xsbyte x) => (sbyte)Math.Asinh(x._value);
            xsbyte IMath<xsbyte>.Atan(xsbyte x) => (sbyte)Math.Atan(x._value);
            xsbyte IMath<xsbyte>.Atan2(xsbyte x, xsbyte y) => (sbyte)Math.Atan2(x._value, y._value);
            xsbyte IMath<xsbyte>.Atanh(xsbyte x) => (sbyte)Math.Atanh(x._value);
            xsbyte IMath<xsbyte>.Cbrt(xsbyte x) => (sbyte)Math.Cbrt(x._value);
            xsbyte IMath<xsbyte>.Ceiling(xsbyte x) => x;
            xsbyte IMath<xsbyte>.Clamp(xsbyte x, xsbyte bound1, xsbyte bound2) => bound1 > bound2 ? Math.Min(bound1._value, Math.Max(bound2._value, x._value)) : Math.Min(bound2._value, Math.Max(bound1._value, x._value));
            xsbyte IMath<xsbyte>.Cos(xsbyte x) => (sbyte)Math.Cos(x._value);
            xsbyte IMath<xsbyte>.Cosh(xsbyte x) => (sbyte)Math.Cosh(x._value);
            xsbyte IMath<xsbyte>.DegreesToRadians(xsbyte x) => (sbyte)(x * Trig.RadiansPerDegree);
            xsbyte IMath<xsbyte>.Exp(xsbyte x) => (sbyte)Math.Exp(x._value);
            xsbyte IMath<xsbyte>.Floor(xsbyte x) => x;
            xsbyte IMath<xsbyte>.IEEERemainder(xsbyte x, xsbyte y) => (sbyte)Math.IEEERemainder(x._value, y._value);
            xsbyte IMath<xsbyte>.Log(xsbyte x) => (sbyte)Math.Log(x._value);
            xsbyte IMath<xsbyte>.Log(xsbyte x, xsbyte y) => (sbyte)Math.Log(x._value, y._value);
            xsbyte IMath<xsbyte>.Log10(xsbyte x) => (sbyte)Math.Log10(x._value);
            xsbyte IMath<xsbyte>.Max(xsbyte x, xsbyte y) => Math.Max(x._value, y._value);
            xsbyte IMath<xsbyte>.Min(xsbyte x, xsbyte y) => Math.Min(x._value, y._value);
            xsbyte IMath<xsbyte>.Pow(xsbyte x, byte y) => (sbyte)Math.Pow(x._value, y);
            xsbyte IMath<xsbyte>.Pow(xsbyte x, xsbyte y) => (sbyte)Math.Pow(x._value, y._value);
            xsbyte IMath<xsbyte>.RadiansToDegrees(xsbyte x) => (sbyte)(x * Trig.DegreesPerRadian);
            xsbyte IMath<xsbyte>.Round(xsbyte x) => x;
            xsbyte IMath<xsbyte>.Round(xsbyte x, int digits) => x;
            xsbyte IMath<xsbyte>.Round(xsbyte x, int digits, MidpointRounding mode) => x;
            xsbyte IMath<xsbyte>.Round(xsbyte x, MidpointRounding mode) => x;
            xsbyte IMath<xsbyte>.Sin(xsbyte x) => (sbyte)Math.Sin(x._value);
            xsbyte IMath<xsbyte>.Sinh(xsbyte x) => (sbyte)Math.Sinh(x._value);
            xsbyte IMath<xsbyte>.Sqrt(xsbyte x) => (sbyte)Math.Sqrt(x._value);
            xsbyte IMath<xsbyte>.Tan(xsbyte x) => (sbyte)Math.Tan(x._value);
            xsbyte IMath<xsbyte>.Tanh(xsbyte x) => (sbyte)Math.Tanh(x._value);
            xsbyte IMath<xsbyte>.Truncate(xsbyte x) => x;

            xsbyte IBitConverter<xsbyte>.Read(IReadOnlyStream<byte> stream) => unchecked((sbyte)stream.Read(1)[0]);
            void IBitConverter<xsbyte>.Write(xsbyte value, IWriteOnlyStream<byte> stream) => stream.Write(BitConverter.GetBytes(value._value));

            xsbyte IRandom<xsbyte>.Next(Random random) => random.NextSByte();
            xsbyte IRandom<xsbyte>.Next(Random random, xsbyte bound1, xsbyte bound2) => random.NextSByte(bound1._value, bound2._value);

            xsbyte IStringParser<xsbyte>.Parse(string s) => Parse(s);
            xsbyte IStringParser<xsbyte>.Parse(string s, NumberStyles numberStyles, IFormatProvider formatProvider) => Parse(s, numberStyles, formatProvider);

            bool IConvert<xsbyte>.ToBoolean(xsbyte value) => Convert.ToBoolean(value._value);
            byte IConvert<xsbyte>.ToByte(xsbyte value) => Convert.ToByte(value._value);
            char IConvert<xsbyte>.ToChar(xsbyte value) => Convert.ToChar(value._value);
            decimal IConvert<xsbyte>.ToDecimal(xsbyte value) => Convert.ToDecimal(value._value);
            double IConvert<xsbyte>.ToDouble(xsbyte value) => Convert.ToDouble(value._value);
            float IConvert<xsbyte>.ToSingle(xsbyte value) => Convert.ToSingle(value._value);
            int IConvert<xsbyte>.ToInt32(xsbyte value) => Convert.ToInt32(value._value);
            long IConvert<xsbyte>.ToInt64(xsbyte value) => Convert.ToInt64(value._value);
            sbyte IConvert<xsbyte>.ToSByte(xsbyte value) => Convert.ToSByte(value._value);
            short IConvert<xsbyte>.ToInt16(xsbyte value) => Convert.ToInt16(value._value);
            string IConvert<xsbyte>.ToString(xsbyte value) => Convert.ToString(value._value);
            string IConvert<xsbyte>.ToString(xsbyte value, IFormatProvider provider) => Convert.ToString(value._value, provider);
            uint IConvert<xsbyte>.ToUInt32(xsbyte value) => Convert.ToUInt32(value._value);
            ulong IConvert<xsbyte>.ToUInt64(xsbyte value) => Convert.ToUInt64(value._value);
            ushort IConvert<xsbyte>.ToUInt16(xsbyte value) => Convert.ToUInt16(value._value);

            xsbyte IConvert<xsbyte>.ToValue(bool value) => Convert.ToSByte(value);
            xsbyte IConvert<xsbyte>.ToValue(byte value) => Convert.ToSByte(value);
            xsbyte IConvert<xsbyte>.ToValue(char value) => Convert.ToSByte(value);
            xsbyte IConvert<xsbyte>.ToValue(decimal value) => Convert.ToSByte(value);
            xsbyte IConvert<xsbyte>.ToValue(double value) => Convert.ToSByte(value);
            xsbyte IConvert<xsbyte>.ToValue(float value) => Convert.ToSByte(value);
            xsbyte IConvert<xsbyte>.ToValue(int value) => Convert.ToSByte(value);
            xsbyte IConvert<xsbyte>.ToValue(long value) => Convert.ToSByte(value);
            xsbyte IConvert<xsbyte>.ToValue(sbyte value) => Convert.ToSByte(value);
            xsbyte IConvert<xsbyte>.ToValue(short value) => Convert.ToSByte(value);
            xsbyte IConvert<xsbyte>.ToValue(string value) => Convert.ToSByte(value);
            xsbyte IConvert<xsbyte>.ToValue(string value, IFormatProvider provider) => Convert.ToSByte(value, provider);
            xsbyte IConvert<xsbyte>.ToValue(uint value) => Convert.ToSByte(value);
            xsbyte IConvert<xsbyte>.ToValue(ulong value) => Convert.ToSByte(value);
            xsbyte IConvert<xsbyte>.ToValue(ushort value) => Convert.ToSByte(value);
        }
    }
}
