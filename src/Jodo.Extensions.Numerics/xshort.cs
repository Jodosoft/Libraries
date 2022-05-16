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
    public readonly struct xshort : INumeric<xshort>
    {
        public static readonly xshort MaxValue = new xshort(short.MaxValue);
        public static readonly xshort MinValue = new xshort(short.MinValue);

        private readonly short _value;

        private xshort(short value)
        {
            _value = value;
        }

        private xshort(SerializationInfo info, StreamingContext context) : this(info.GetInt16(nameof(xshort))) { }
        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context) => info.AddValue(nameof(xshort), _value);

        public int CompareTo(xshort other) => _value.CompareTo(other._value);
        public int CompareTo(object? obj) => obj is xshort other ? CompareTo(other) : 1;
        public bool Equals(xshort other) => _value == other._value;
        public override bool Equals(object? obj) => obj is xshort other && Equals(other);
        public override int GetHashCode() => _value.GetHashCode();
        public override string ToString() => _value.ToString();
        public string ToString(IFormatProvider formatProvider) => _value.ToString(formatProvider);
        public string ToString(string format, IFormatProvider formatProvider) => _value.ToString(format, formatProvider);

        public static bool TryParse(string s, IFormatProvider provider, out xshort result) => Try.Run(() => Parse(s, provider), out result);
        public static bool TryParse(string s, NumberStyles style, IFormatProvider provider, out xshort result) => Try.Run(() => Parse(s, style, provider), out result);
        public static bool TryParse(string s, NumberStyles style, out xshort result) => Try.Run(() => Parse(s, style), out result);
        public static bool TryParse(string s, out xshort result) => Try.Run(() => Parse(s), out result);
        public static xshort Parse(string s) => short.Parse(s);
        public static xshort Parse(string s, IFormatProvider provider) => short.Parse(s, provider);
        public static xshort Parse(string s, NumberStyles style) => short.Parse(s, style);
        public static xshort Parse(string s, NumberStyles style, IFormatProvider provider) => short.Parse(s, style, provider);

        public static explicit operator xshort(char value) => new xshort((short)value);
        public static explicit operator xshort(decimal value) => new xshort((short)value);
        public static explicit operator xshort(double value) => new xshort((short)value);
        public static explicit operator xshort(float value) => new xshort((short)value);
        public static explicit operator xshort(int value) => new xshort((short)value);
        public static explicit operator xshort(long value) => new xshort((short)value);
        public static explicit operator xshort(uint value) => new xshort((short)value);
        public static explicit operator xshort(ulong value) => new xshort((short)value);
        public static explicit operator xshort(ushort value) => new xshort((short)value);
        public static implicit operator xshort(byte value) => new xshort(value);
        public static implicit operator xshort(sbyte value) => new xshort(value);
        public static implicit operator xshort(short value) => new xshort(value);

        public static explicit operator byte(xshort value) => (byte)value._value;
        public static explicit operator char(xshort value) => (char)value._value;
        public static explicit operator sbyte(xshort value) => (sbyte)value._value;
        public static explicit operator uint(xshort value) => (uint)value._value;
        public static explicit operator ulong(xshort value) => (ulong)value._value;
        public static explicit operator ushort(xshort value) => (ushort)value._value;
        public static implicit operator decimal(xshort value) => value._value;
        public static implicit operator double(xshort value) => value._value;
        public static implicit operator float(xshort value) => value._value;
        public static implicit operator int(xshort value) => value._value;
        public static implicit operator long(xshort value) => value._value;
        public static implicit operator short(xshort value) => value._value;

        public static bool operator !=(xshort left, xshort right) => left._value != right._value;
        public static bool operator <(xshort left, xshort right) => left._value < right._value;
        public static bool operator <=(xshort left, xshort right) => left._value <= right._value;
        public static bool operator ==(xshort left, xshort right) => left._value == right._value;
        public static bool operator >(xshort left, xshort right) => left._value > right._value;
        public static bool operator >=(xshort left, xshort right) => left._value >= right._value;
        public static xshort operator %(xshort left, xshort right) => (short)(left._value % right._value);
        public static xshort operator &(xshort left, xshort right) => (short)(left._value & right._value);
        public static xshort operator -(xshort left, xshort right) => (short)(left._value - right._value);
        public static xshort operator --(xshort value) => (short)(value._value - 1);
        public static xshort operator -(xshort value) => (short)-value._value;
        public static xshort operator *(xshort left, xshort right) => (short)(left._value * right._value);
        public static xshort operator /(xshort left, xshort right) => (short)(left._value / right._value);
        public static xshort operator ^(xshort left, xshort right) => (short)(left._value ^ right._value);
        public static xshort operator |(xshort left, xshort right) => (short)(left._value | right._value);
        public static xshort operator ~(xshort value) => (short)~value._value;
        public static xshort operator +(xshort left, xshort right) => (short)(left._value + right._value);
        public static xshort operator +(xshort value) => value;
        public static xshort operator ++(xshort value) => (short)(value._value + 1);
        public static xshort operator <<(xshort left, int right) => (short)(left._value << right);
        public static xshort operator >>(xshort left, int right) => (short)(left._value >> right);

        bool INumeric<xshort>.IsGreaterThan(xshort value) => this > value;
        bool INumeric<xshort>.IsGreaterThanOrEqualTo(xshort value) => this >= value;
        bool INumeric<xshort>.IsLessThan(xshort value) => this < value;
        bool INumeric<xshort>.IsLessThanOrEqualTo(xshort value) => this <= value;
        xshort INumeric<xshort>.Add(xshort value) => this + value;
        xshort INumeric<xshort>.Divide(xshort value) => this / value;
        xshort INumeric<xshort>.Multiply(xshort value) => this * value;
        xshort INumeric<xshort>.Negative() => -this;
        xshort INumeric<xshort>.Positive() => +this;
        xshort INumeric<xshort>.Remainder(xshort value) => this % value;
        xshort INumeric<xshort>.Subtract(xshort value) => this - value;

        IBitConverter<xshort> IBitConvertible<xshort>.BitConverter => Utilities.Instance;
        IConstants<xshort> INumeric<xshort>.Constants => Utilities.Instance;
        IConvert<xshort> IConvertible<xshort>.Convert => Utilities.Instance;
        IMath<xshort> INumeric<xshort>.Math => Utilities.Instance;
        IRandom<xshort> IRandomisable<xshort>.Random => Utilities.Instance;
        IStringParser<xshort> IStringParsable<xshort>.StringParser => Utilities.Instance;

        private sealed class Utilities :
            IBitConverter<xshort>,
            IConstants<xshort>,
            IConvert<xshort>,
            IMath<xshort>,
            IRandom<xshort>,
            IStringParser<xshort>
        {
            public readonly static Utilities Instance = new Utilities();

            bool IConstants<xshort>.IsReal { get; } = false;
            bool IConstants<xshort>.IsSigned { get; } = true;
            xshort IConstants<xshort>.Epsilon { get; } = (short)1;
            xshort IConstants<xshort>.MaxUnit { get; } = (short)1;
            xshort IConstants<xshort>.MaxValue => MaxValue;
            xshort IConstants<xshort>.MinUnit { get; } = (short)-1;
            xshort IConstants<xshort>.MinValue => MinValue;
            xshort IConstants<xshort>.One { get; } = (short)1;
            xshort IConstants<xshort>.Zero { get; } = (short)0;
            xshort IMath<xshort>.E { get; } = (short)2;
            xshort IMath<xshort>.PI { get; } = (short)3;
            xshort IMath<xshort>.Tau { get; } = (short)6;

            int IMath<xshort>.Sign(xshort x) => Math.Sign(x._value);
            xshort IMath<xshort>.Abs(xshort x) => Math.Abs(x._value);
            xshort IMath<xshort>.Acos(xshort x) => (short)Math.Acos(x._value);
            xshort IMath<xshort>.Acosh(xshort x) => (short)Math.Acosh(x._value);
            xshort IMath<xshort>.Asin(xshort x) => (short)Math.Asin(x._value);
            xshort IMath<xshort>.Asinh(xshort x) => (short)Math.Asinh(x._value);
            xshort IMath<xshort>.Atan(xshort x) => (short)Math.Atan(x._value);
            xshort IMath<xshort>.Atan2(xshort x, xshort y) => (short)Math.Atan2(x._value, y._value);
            xshort IMath<xshort>.Atanh(xshort x) => (short)Math.Atanh(x._value);
            xshort IMath<xshort>.Cbrt(xshort x) => (short)Math.Cbrt(x._value);
            xshort IMath<xshort>.Ceiling(xshort x) => x;
            xshort IMath<xshort>.Clamp(xshort x, xshort bound1, xshort bound2) => bound1 > bound2 ? Math.Min(bound1._value, Math.Max(bound2._value, x._value)) : Math.Min(bound2._value, Math.Max(bound1._value, x._value));
            xshort IMath<xshort>.Cos(xshort x) => (short)Math.Cos(x._value);
            xshort IMath<xshort>.Cosh(xshort x) => (short)Math.Cosh(x._value);
            xshort IMath<xshort>.DegreesToRadians(xshort x) => (short)(x * Trig.RadiansPerDegree);
            xshort IMath<xshort>.Exp(xshort x) => (short)Math.Exp(x._value);
            xshort IMath<xshort>.Floor(xshort x) => x;
            xshort IMath<xshort>.IEEERemainder(xshort x, xshort y) => (short)Math.IEEERemainder(x._value, y._value);
            xshort IMath<xshort>.Log(xshort x) => (short)Math.Log(x._value);
            xshort IMath<xshort>.Log(xshort x, xshort y) => (short)Math.Log(x._value, y._value);
            xshort IMath<xshort>.Log10(xshort x) => (short)Math.Log10(x._value);
            xshort IMath<xshort>.Max(xshort x, xshort y) => Math.Max(x._value, y._value);
            xshort IMath<xshort>.Min(xshort x, xshort y) => Math.Min(x._value, y._value);
            xshort IMath<xshort>.Pow(xshort x, byte y) => (short)Math.Pow(x._value, y);
            xshort IMath<xshort>.Pow(xshort x, xshort y) => (short)Math.Pow(x._value, y._value);
            xshort IMath<xshort>.RadiansToDegrees(xshort x) => (short)(x * Trig.DegreesPerRadian);
            xshort IMath<xshort>.Round(xshort x) => x;
            xshort IMath<xshort>.Round(xshort x, int digits) => x;
            xshort IMath<xshort>.Round(xshort x, int digits, MidpointRounding mode) => x;
            xshort IMath<xshort>.Round(xshort x, MidpointRounding mode) => x;
            xshort IMath<xshort>.Sin(xshort x) => (short)Math.Sin(x._value);
            xshort IMath<xshort>.Sinh(xshort x) => (short)Math.Sinh(x._value);
            xshort IMath<xshort>.Sqrt(xshort x) => (short)Math.Sqrt(x._value);
            xshort IMath<xshort>.Tan(xshort x) => (short)Math.Tan(x._value);
            xshort IMath<xshort>.Tanh(xshort x) => (short)Math.Tanh(x._value);
            xshort IMath<xshort>.Truncate(xshort x) => x;

            xshort IBitConverter<xshort>.Read(IReadOnlyStream<byte> stream) => BitConverter.ToInt16(stream.Read(sizeof(short)));
            void IBitConverter<xshort>.Write(xshort value, IWriteOnlyStream<byte> stream) => stream.Write(BitConverter.GetBytes(value._value));

            xshort IRandom<xshort>.Next(Random random) => random.NextInt16();
            xshort IRandom<xshort>.Next(Random random, xshort bound1, xshort bound2) => random.NextInt16(bound1._value, bound2._value);

            xshort IStringParser<xshort>.Parse(string s) => Parse(s);
            xshort IStringParser<xshort>.Parse(string s, NumberStyles numberStyles, IFormatProvider formatProvider) => Parse(s, numberStyles, formatProvider);

            bool IConvert<xshort>.ToBoolean(xshort value) => Convert.ToBoolean(value._value);
            byte IConvert<xshort>.ToByte(xshort value) => Convert.ToByte(value._value);
            char IConvert<xshort>.ToChar(xshort value) => Convert.ToChar(value._value);
            decimal IConvert<xshort>.ToDecimal(xshort value) => Convert.ToDecimal(value._value);
            double IConvert<xshort>.ToDouble(xshort value) => Convert.ToDouble(value._value);
            float IConvert<xshort>.ToSingle(xshort value) => Convert.ToSingle(value._value);
            int IConvert<xshort>.ToInt32(xshort value) => Convert.ToInt32(value._value);
            long IConvert<xshort>.ToInt64(xshort value) => Convert.ToInt64(value._value);
            sbyte IConvert<xshort>.ToSByte(xshort value) => Convert.ToSByte(value._value);
            short IConvert<xshort>.ToInt16(xshort value) => Convert.ToInt16(value._value);
            string IConvert<xshort>.ToString(xshort value) => Convert.ToString(value._value);
            string IConvert<xshort>.ToString(xshort value, IFormatProvider provider) => Convert.ToString(value._value, provider);
            uint IConvert<xshort>.ToUInt32(xshort value) => Convert.ToUInt32(value._value);
            ulong IConvert<xshort>.ToUInt64(xshort value) => Convert.ToUInt64(value._value);
            ushort IConvert<xshort>.ToUInt16(xshort value) => Convert.ToUInt16(value._value);

            xshort IConvert<xshort>.ToValue(bool value) => Convert.ToInt16(value);
            xshort IConvert<xshort>.ToValue(byte value) => Convert.ToInt16(value);
            xshort IConvert<xshort>.ToValue(char value) => Convert.ToInt16(value);
            xshort IConvert<xshort>.ToValue(decimal value) => Convert.ToInt16(value);
            xshort IConvert<xshort>.ToValue(double value) => Convert.ToInt16(value);
            xshort IConvert<xshort>.ToValue(float value) => Convert.ToInt16(value);
            xshort IConvert<xshort>.ToValue(int value) => Convert.ToInt16(value);
            xshort IConvert<xshort>.ToValue(long value) => Convert.ToInt16(value);
            xshort IConvert<xshort>.ToValue(sbyte value) => Convert.ToInt16(value);
            xshort IConvert<xshort>.ToValue(short value) => Convert.ToInt16(value);
            xshort IConvert<xshort>.ToValue(string value) => Convert.ToInt16(value);
            xshort IConvert<xshort>.ToValue(string value, IFormatProvider provider) => Convert.ToInt16(value, provider);
            xshort IConvert<xshort>.ToValue(uint value) => Convert.ToInt16(value);
            xshort IConvert<xshort>.ToValue(ulong value) => Convert.ToInt16(value);
            xshort IConvert<xshort>.ToValue(ushort value) => Convert.ToInt16(value);
        }
    }
}
