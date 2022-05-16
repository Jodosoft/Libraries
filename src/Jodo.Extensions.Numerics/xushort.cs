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
    public readonly struct xushort : INumeric<xushort>
    {
        public static readonly xushort MaxValue = new xushort(ushort.MaxValue);
        public static readonly xushort MinValue = new xushort(ushort.MinValue);

        private readonly ushort _value;

        private xushort(ushort value)
        {
            _value = value;
        }

        private xushort(SerializationInfo info, StreamingContext context) : this(info.GetUInt16(nameof(xushort))) { }
        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context) => info.AddValue(nameof(xushort), _value);

        public int CompareTo(xushort other) => _value.CompareTo(other._value);
        public int CompareTo(object? obj) => obj is xushort other ? CompareTo(other) : 1;
        public bool Equals(xushort other) => _value == other._value;
        public override bool Equals(object? obj) => obj is xushort other && Equals(other);
        public override int GetHashCode() => _value.GetHashCode();
        public override string ToString() => _value.ToString();
        public string ToString(IFormatProvider formatProvider) => _value.ToString(formatProvider);
        public string ToString(string format, IFormatProvider formatProvider) => _value.ToString(format, formatProvider);

        public static bool TryParse(string s, IFormatProvider provider, out xushort result) => Try.Run(() => Parse(s, provider), out result);
        public static bool TryParse(string s, NumberStyles style, IFormatProvider provider, out xushort result) => Try.Run(() => Parse(s, style, provider), out result);
        public static bool TryParse(string s, NumberStyles style, out xushort result) => Try.Run(() => Parse(s, style), out result);
        public static bool TryParse(string s, out xushort result) => Try.Run(() => Parse(s), out result);
        public static xushort Parse(string s) => ushort.Parse(s);
        public static xushort Parse(string s, IFormatProvider provider) => ushort.Parse(s, provider);
        public static xushort Parse(string s, NumberStyles style) => ushort.Parse(s, style);
        public static xushort Parse(string s, NumberStyles style, IFormatProvider provider) => ushort.Parse(s, style, provider);

        public static explicit operator xushort(decimal value) => new xushort((ushort)value);
        public static explicit operator xushort(double value) => new xushort((ushort)value);
        public static explicit operator xushort(float value) => new xushort((ushort)value);
        public static explicit operator xushort(int value) => new xushort((ushort)value);
        public static explicit operator xushort(long value) => new xushort((ushort)value);
        public static explicit operator xushort(sbyte value) => new xushort((ushort)value);
        public static explicit operator xushort(short value) => new xushort((ushort)value);
        public static explicit operator xushort(uint value) => new xushort((ushort)value);
        public static explicit operator xushort(ulong value) => new xushort((ushort)value);
        public static implicit operator xushort(byte value) => new xushort(value);
        public static implicit operator xushort(char value) => new xushort(value);
        public static implicit operator xushort(ushort value) => new xushort(value);

        public static explicit operator byte(xushort value) => (byte)value._value;
        public static explicit operator char(xushort value) => (char)value._value;
        public static explicit operator sbyte(xushort value) => (sbyte)value._value;
        public static explicit operator short(xushort value) => (short)value._value;
        public static implicit operator decimal(xushort value) => value._value;
        public static implicit operator double(xushort value) => value._value;
        public static implicit operator float(xushort value) => value._value;
        public static implicit operator int(xushort value) => value._value;
        public static implicit operator long(xushort value) => value._value;
        public static implicit operator uint(xushort value) => value._value;
        public static implicit operator ulong(xushort value) => value._value;
        public static implicit operator ushort(xushort value) => value._value;

        public static bool operator !=(xushort left, xushort right) => left._value != right._value;
        public static bool operator <(xushort left, xushort right) => left._value < right._value;
        public static bool operator <=(xushort left, xushort right) => left._value <= right._value;
        public static bool operator ==(xushort left, xushort right) => left._value == right._value;
        public static bool operator >(xushort left, xushort right) => left._value > right._value;
        public static bool operator >=(xushort left, xushort right) => left._value >= right._value;
        public static xushort operator %(xushort left, xushort right) => (ushort)(left._value % right._value);
        public static xushort operator &(xushort left, xushort right) => (ushort)(left._value & right._value);
        public static xushort operator -(xushort left, xushort right) => (ushort)(left._value - right._value);
        public static xushort operator --(xushort value) => (ushort)(value._value - 1);
        public static xushort operator -(xushort value) => (ushort)-value._value;
        public static xushort operator *(xushort left, xushort right) => (ushort)(left._value * right._value);
        public static xushort operator /(xushort left, xushort right) => (ushort)(left._value / right._value);
        public static xushort operator ^(xushort left, xushort right) => (ushort)(left._value ^ right._value);
        public static xushort operator |(xushort left, xushort right) => (ushort)(left._value | right._value);
        public static xushort operator ~(xushort value) => (ushort)~value._value;
        public static xushort operator +(xushort left, xushort right) => (ushort)(left._value + right._value);
        public static xushort operator +(xushort value) => value;
        public static xushort operator ++(xushort value) => (ushort)(value._value + 1);
        public static xushort operator <<(xushort left, int right) => (ushort)(left._value << right);
        public static xushort operator >>(xushort left, int right) => (ushort)(left._value >> right);

        bool INumeric<xushort>.IsGreaterThan(xushort value) => this > value;
        bool INumeric<xushort>.IsGreaterThanOrEqualTo(xushort value) => this >= value;
        bool INumeric<xushort>.IsLessThan(xushort value) => this < value;
        bool INumeric<xushort>.IsLessThanOrEqualTo(xushort value) => this <= value;
        xushort INumeric<xushort>.Add(xushort value) => this + value;
        xushort INumeric<xushort>.Divide(xushort value) => this / value;
        xushort INumeric<xushort>.Multiply(xushort value) => this * value;
        xushort INumeric<xushort>.Negative() => -this;
        xushort INumeric<xushort>.Positive() => +this;
        xushort INumeric<xushort>.Remainder(xushort value) => this % value;
        xushort INumeric<xushort>.Subtract(xushort value) => this - value;

        IBitConverter<xushort> IBitConvertible<xushort>.BitConverter => Utilities.Instance;
        IConstants<xushort> INumeric<xushort>.Constants => Utilities.Instance;
        IConvert<xushort> IConvertible<xushort>.Convert => Utilities.Instance;
        IMath<xushort> INumeric<xushort>.Math => Utilities.Instance;
        IRandom<xushort> IRandomisable<xushort>.Random => Utilities.Instance;
        IStringParser<xushort> IStringParsable<xushort>.StringParser => Utilities.Instance;

        private sealed class Utilities :
            IBitConverter<xushort>,
            IConstants<xushort>,
            IConvert<xushort>,
            IMath<xushort>,
            IRandom<xushort>,
            IStringParser<xushort>
        {
            public readonly static Utilities Instance = new Utilities();

            bool IConstants<xushort>.IsReal { get; } = false;
            bool IConstants<xushort>.IsSigned { get; } = false;
            xushort IConstants<xushort>.Epsilon { get; } = (ushort)1;
            xushort IConstants<xushort>.MaxUnit { get; } = (ushort)1;
            xushort IConstants<xushort>.MaxValue => MaxValue;
            xushort IConstants<xushort>.MinUnit { get; } = (ushort)0;
            xushort IConstants<xushort>.MinValue => MinValue;
            xushort IConstants<xushort>.One { get; } = (ushort)1;
            xushort IConstants<xushort>.Zero { get; } = (ushort)0;
            xushort IMath<xushort>.E { get; } = (ushort)2;
            xushort IMath<xushort>.PI { get; } = (ushort)3;
            xushort IMath<xushort>.Tau { get; } = (ushort)6;

            int IMath<xushort>.Sign(xushort x) => Math.Sign(x._value);
            xushort IMath<xushort>.Abs(xushort x) => x._value;
            xushort IMath<xushort>.Acos(xushort x) => (ushort)Math.Acos(x._value);
            xushort IMath<xushort>.Acosh(xushort x) => (ushort)Math.Acosh(x._value);
            xushort IMath<xushort>.Asin(xushort x) => (ushort)Math.Asin(x._value);
            xushort IMath<xushort>.Asinh(xushort x) => (ushort)Math.Asinh(x._value);
            xushort IMath<xushort>.Atan(xushort x) => (ushort)Math.Atan(x._value);
            xushort IMath<xushort>.Atan2(xushort x, xushort y) => (ushort)Math.Atan2(x._value, y._value);
            xushort IMath<xushort>.Atanh(xushort x) => (ushort)Math.Atanh(x._value);
            xushort IMath<xushort>.Cbrt(xushort x) => (ushort)Math.Cbrt(x._value);
            xushort IMath<xushort>.Ceiling(xushort x) => x;
            xushort IMath<xushort>.Clamp(xushort x, xushort bound1, xushort bound2) => bound1 > bound2 ? Math.Min(bound1._value, Math.Max(bound2._value, x._value)) : Math.Min(bound2._value, Math.Max(bound1._value, x._value));
            xushort IMath<xushort>.Cos(xushort x) => (ushort)Math.Cos(x._value);
            xushort IMath<xushort>.Cosh(xushort x) => (ushort)Math.Cosh(x._value);
            xushort IMath<xushort>.DegreesToRadians(xushort degrees) => (ushort)(degrees * Trig.RadiansPerDegree);
            xushort IMath<xushort>.Exp(xushort x) => (ushort)Math.Exp(x._value);
            xushort IMath<xushort>.Floor(xushort x) => x;
            xushort IMath<xushort>.IEEERemainder(xushort x, xushort y) => (ushort)Math.IEEERemainder(x._value, y._value);
            xushort IMath<xushort>.Log(xushort x) => (ushort)Math.Log(x._value);
            xushort IMath<xushort>.Log(xushort x, xushort y) => (ushort)Math.Log(x._value, y._value);
            xushort IMath<xushort>.Log10(xushort x) => (ushort)Math.Log10(x._value);
            xushort IMath<xushort>.Max(xushort x, xushort y) => Math.Max(x._value, y._value);
            xushort IMath<xushort>.Min(xushort x, xushort y) => Math.Min(x._value, y._value);
            xushort IMath<xushort>.Pow(xushort x, byte y) => (ushort)Math.Pow(x._value, y);
            xushort IMath<xushort>.Pow(xushort x, xushort y) => (ushort)Math.Pow(x._value, y._value);
            xushort IMath<xushort>.RadiansToDegrees(xushort radians) => (ushort)(radians * Trig.DegreesPerRadian);
            xushort IMath<xushort>.Round(xushort x) => x;
            xushort IMath<xushort>.Round(xushort x, int digits) => x;
            xushort IMath<xushort>.Round(xushort x, int digits, MidpointRounding mode) => x;
            xushort IMath<xushort>.Round(xushort x, MidpointRounding mode) => x;
            xushort IMath<xushort>.Sin(xushort x) => (ushort)Math.Sin(x._value);
            xushort IMath<xushort>.Sinh(xushort x) => (ushort)Math.Sinh(x._value);
            xushort IMath<xushort>.Sqrt(xushort x) => (ushort)Math.Sqrt(x._value);
            xushort IMath<xushort>.Tan(xushort x) => (ushort)Math.Tan(x._value);
            xushort IMath<xushort>.Tanh(xushort x) => (ushort)Math.Tanh(x._value);
            xushort IMath<xushort>.Truncate(xushort x) => x;

            xushort IBitConverter<xushort>.Read(IReadOnlyStream<byte> stream) => BitConverter.ToUInt16(stream.Read(sizeof(ushort)));
            void IBitConverter<xushort>.Write(xushort value, IWriteOnlyStream<byte> stream) => stream.Write(BitConverter.GetBytes(value._value));

            xushort IRandom<xushort>.Next(Random random) => random.NextUInt16();
            xushort IRandom<xushort>.Next(Random random, xushort bound1, xushort bound2) => random.NextUInt16(bound1._value, bound2._value);

            xushort IStringParser<xushort>.Parse(string s) => Parse(s);
            xushort IStringParser<xushort>.Parse(string s, NumberStyles numberStyles, IFormatProvider formatProvider) => Parse(s, numberStyles, formatProvider);

            bool IConvert<xushort>.ToBoolean(xushort value) => Convert.ToBoolean(value._value);
            byte IConvert<xushort>.ToByte(xushort value) => Convert.ToByte(value._value);
            char IConvert<xushort>.ToChar(xushort value) => Convert.ToChar(value._value);
            decimal IConvert<xushort>.ToDecimal(xushort value) => Convert.ToDecimal(value._value);
            double IConvert<xushort>.ToDouble(xushort value) => Convert.ToDouble(value._value);
            float IConvert<xushort>.ToSingle(xushort value) => Convert.ToSingle(value._value);
            int IConvert<xushort>.ToInt32(xushort value) => Convert.ToInt32(value._value);
            long IConvert<xushort>.ToInt64(xushort value) => Convert.ToInt64(value._value);
            sbyte IConvert<xushort>.ToSByte(xushort value) => Convert.ToSByte(value._value);
            short IConvert<xushort>.ToInt16(xushort value) => Convert.ToInt16(value._value);
            string IConvert<xushort>.ToString(xushort value) => Convert.ToString(value._value);
            string IConvert<xushort>.ToString(xushort value, IFormatProvider provider) => Convert.ToString(value._value, provider);
            uint IConvert<xushort>.ToUInt32(xushort value) => Convert.ToUInt32(value._value);
            ulong IConvert<xushort>.ToUInt64(xushort value) => Convert.ToUInt64(value._value);
            ushort IConvert<xushort>.ToUInt16(xushort value) => Convert.ToUInt16(value._value);

            xushort IConvert<xushort>.ToValue(bool value) => Convert.ToUInt16(value);
            xushort IConvert<xushort>.ToValue(byte value) => Convert.ToUInt16(value);
            xushort IConvert<xushort>.ToValue(char value) => Convert.ToUInt16(value);
            xushort IConvert<xushort>.ToValue(decimal value) => Convert.ToUInt16(value);
            xushort IConvert<xushort>.ToValue(double value) => Convert.ToUInt16(value);
            xushort IConvert<xushort>.ToValue(float value) => Convert.ToUInt16(value);
            xushort IConvert<xushort>.ToValue(int value) => Convert.ToUInt16(value);
            xushort IConvert<xushort>.ToValue(long value) => Convert.ToUInt16(value);
            xushort IConvert<xushort>.ToValue(sbyte value) => Convert.ToUInt16(value);
            xushort IConvert<xushort>.ToValue(short value) => Convert.ToUInt16(value);
            xushort IConvert<xushort>.ToValue(string value) => Convert.ToUInt16(value);
            xushort IConvert<xushort>.ToValue(string value, IFormatProvider provider) => Convert.ToUInt16(value, provider);
            xushort IConvert<xushort>.ToValue(uint value) => Convert.ToUInt16(value);
            xushort IConvert<xushort>.ToValue(ulong value) => Convert.ToUInt16(value);
            xushort IConvert<xushort>.ToValue(ushort value) => Convert.ToUInt16(value);
        }
    }
}
