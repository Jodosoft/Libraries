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
    public readonly struct xdouble : INumeric<xdouble>
    {
        public static readonly xdouble Epsilon = double.Epsilon;
        public static readonly xdouble MaxValue = double.MaxValue;
        public static readonly xdouble MinValue = double.MinValue;

        private readonly double _value;

        private xdouble(double value)
        {
            _value = value;
        }

        private xdouble(SerializationInfo info, StreamingContext context) : this(info.GetDouble(nameof(xdouble))) { }
        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context) => info.AddValue(nameof(xdouble), _value);

        public int CompareTo(xdouble other) => _value.CompareTo(other._value);
        public int CompareTo(object? obj) => obj is xdouble other ? CompareTo(other) : 1;
        public bool Equals(xdouble other) => _value == other._value;
        public override bool Equals(object? obj) => obj is xdouble other && Equals(other);
        public override int GetHashCode() => _value.GetHashCode();
        public override string ToString() => _value.ToString();
        public string ToString(IFormatProvider formatProvider) => _value.ToString(formatProvider);
        public string ToString(string format, IFormatProvider formatProvider) => _value.ToString(format, formatProvider);

        public static bool IsFinite(xdouble d) => double.IsFinite(d);
        public static bool IsInfinity(xdouble d) => double.IsInfinity(d);
        public static bool IsNaN(xdouble d) => double.IsNaN(d);
        public static bool IsNegative(xdouble d) => double.IsNegative(d);
        public static bool IsNegativeInfinity(xdouble d) => double.IsNegativeInfinity(d);
        public static bool IsNormal(xdouble d) => double.IsNormal(d);
        public static bool IsPositiveInfinity(xdouble d) => double.IsPositiveInfinity(d);
        public static bool IsSubnormal(xdouble d) => double.IsSubnormal(d);

        public static bool TryParse(string s, IFormatProvider provider, out xdouble result) => Try.Run(() => Parse(s, provider), out result);
        public static bool TryParse(string s, NumberStyles style, IFormatProvider provider, out xdouble result) => Try.Run(() => Parse(s, style, provider), out result);
        public static bool TryParse(string s, NumberStyles style, out xdouble result) => Try.Run(() => Parse(s, style), out result);
        public static bool TryParse(string s, out xdouble result) => Try.Run(() => Parse(s), out result);
        public static xdouble Parse(string s) => double.Parse(s);
        public static xdouble Parse(string s, IFormatProvider provider) => double.Parse(s, provider);
        public static xdouble Parse(string s, NumberStyles style) => double.Parse(s, style);
        public static xdouble Parse(string s, NumberStyles style, IFormatProvider provider) => double.Parse(s, style, provider);

        public static explicit operator xdouble(decimal value) => new xdouble((double)value);
        public static implicit operator xdouble(byte value) => new xdouble(value);
        public static implicit operator xdouble(char value) => new xdouble(value);
        public static implicit operator xdouble(double value) => new xdouble(value);
        public static implicit operator xdouble(float value) => new xdouble(value);
        public static implicit operator xdouble(int value) => new xdouble(value);
        public static implicit operator xdouble(long value) => new xdouble(value);
        public static implicit operator xdouble(sbyte value) => new xdouble(value);
        public static implicit operator xdouble(short value) => new xdouble(value);
        public static implicit operator xdouble(uint value) => new xdouble(value);
        public static implicit operator xdouble(ulong value) => new xdouble(value);
        public static implicit operator xdouble(ushort value) => new xdouble(value);

        public static explicit operator byte(xdouble value) => (byte)value._value;
        public static explicit operator char(xdouble value) => (char)value._value;
        public static explicit operator decimal(xdouble value) => (decimal)value._value;
        public static explicit operator float(xdouble value) => (float)value._value;
        public static explicit operator int(xdouble value) => (int)value._value;
        public static explicit operator long(xdouble value) => (long)value._value;
        public static explicit operator sbyte(xdouble value) => (sbyte)value._value;
        public static explicit operator short(xdouble value) => (short)value._value;
        public static explicit operator uint(xdouble value) => (uint)value._value;
        public static explicit operator ulong(xdouble value) => (ulong)value._value;
        public static explicit operator ushort(xdouble value) => (ushort)value._value;
        public static implicit operator double(xdouble value) => value._value;

        public static bool operator !=(xdouble left, xdouble right) => left._value != right._value;
        public static bool operator <(xdouble left, xdouble right) => left._value < right._value;
        public static bool operator <=(xdouble left, xdouble right) => left._value <= right._value;
        public static bool operator ==(xdouble left, xdouble right) => left._value == right._value;
        public static bool operator >(xdouble left, xdouble right) => left._value > right._value;
        public static bool operator >=(xdouble left, xdouble right) => left._value >= right._value;
        public static xdouble operator %(xdouble left, xdouble right) => left._value % right._value;
        public static xdouble operator -(xdouble left, xdouble right) => left._value - right._value;
        public static xdouble operator --(xdouble value) => value._value - 1;
        public static xdouble operator -(xdouble value) => -value._value;
        public static xdouble operator *(xdouble left, xdouble right) => left._value * right._value;
        public static xdouble operator /(xdouble left, xdouble right) => left._value / right._value;
        public static xdouble operator +(xdouble left, xdouble right) => left._value + right._value;
        public static xdouble operator +(xdouble value) => value;
        public static xdouble operator ++(xdouble value) => value._value + 1;

        bool INumeric<xdouble>.IsGreaterThan(xdouble value) => this > value;
        bool INumeric<xdouble>.IsGreaterThanOrEqualTo(xdouble value) => this >= value;
        bool INumeric<xdouble>.IsLessThan(xdouble value) => this < value;
        bool INumeric<xdouble>.IsLessThanOrEqualTo(xdouble value) => this <= value;
        xdouble INumeric<xdouble>.Add(xdouble value) => this + value;
        xdouble INumeric<xdouble>.Divide(xdouble value) => this / value;
        xdouble INumeric<xdouble>.Multiply(xdouble value) => this * value;
        xdouble INumeric<xdouble>.Negative() => -this;
        xdouble INumeric<xdouble>.Positive() => +this;
        xdouble INumeric<xdouble>.Remainder(xdouble value) => this % value;
        xdouble INumeric<xdouble>.Subtract(xdouble value) => this - value;

        IBitConverter<xdouble> IBitConvertible<xdouble>.BitConverter => Utilities.Instance;
        IConvert<xdouble> IConvertible<xdouble>.Convert => Utilities.Instance;
        IMath<xdouble> INumeric<xdouble>.Math => Utilities.Instance;
        IRandom<xdouble> IRandomisable<xdouble>.Random => Utilities.Instance;
        IStringParser<xdouble> IStringParsable<xdouble>.StringParser => Utilities.Instance;

        private sealed class Utilities :
            IBitConverter<xdouble>,
            IConvert<xdouble>,
            IMath<xdouble>,
            IRandom<xdouble>,
            IStringParser<xdouble>
        {
            public readonly static Utilities Instance = new Utilities();

            bool IMath<xdouble>.IsReal { get; } = true;
            bool IMath<xdouble>.IsSigned { get; } = true;
            xdouble IMath<xdouble>.Epsilon => Epsilon;
            xdouble IMath<xdouble>.MaxUnit { get; } = 1d;
            xdouble IMath<xdouble>.MaxValue => MaxValue;
            xdouble IMath<xdouble>.MinUnit { get; } = -1d;
            xdouble IMath<xdouble>.MinValue => MinValue;
            xdouble IMath<xdouble>.One { get; } = 1d;
            xdouble IMath<xdouble>.Zero { get; } = 0d;
            xdouble IMath<xdouble>.E { get; } = Math.E;
            xdouble IMath<xdouble>.PI { get; } = Math.PI;
            xdouble IMath<xdouble>.Tau { get; } = Math.PI * 2d;

            xdouble IMath<xdouble>.Abs(xdouble x) => Math.Abs(x._value);
            xdouble IMath<xdouble>.Acos(xdouble x) => Math.Acos(x._value);
            xdouble IMath<xdouble>.Acosh(xdouble x) => Math.Acosh(x._value);
            xdouble IMath<xdouble>.Asin(xdouble x) => Math.Asin(x._value);
            xdouble IMath<xdouble>.Asinh(xdouble x) => Math.Asinh(x._value);
            xdouble IMath<xdouble>.Atan(xdouble x) => Math.Atan(x._value);
            xdouble IMath<xdouble>.Atan2(xdouble x, xdouble y) => Math.Atan2(x._value, y._value);
            xdouble IMath<xdouble>.Atanh(xdouble x) => Math.Atanh(x._value);
            xdouble IMath<xdouble>.Cbrt(xdouble x) => Math.Cbrt(x._value);
            xdouble IMath<xdouble>.Ceiling(xdouble x) => Math.Ceiling(x._value);
            xdouble IMath<xdouble>.Clamp(xdouble x, xdouble bound1, xdouble bound2) => bound1 > bound2 ? Math.Min(bound1._value, Math.Max(bound2._value, x._value)) : Math.Min(bound2._value, Math.Max(bound1._value, x._value));
            xdouble IMath<xdouble>.Cos(xdouble x) => Math.Cos(x._value);
            xdouble IMath<xdouble>.Cosh(xdouble x) => Math.Cosh(x._value);
            xdouble IMath<xdouble>.DegreesToRadians(xdouble x) => x * Trig.RadiansPerDegree;
            xdouble IMath<xdouble>.Exp(xdouble x) => Math.Exp(x._value);
            xdouble IMath<xdouble>.Floor(xdouble x) => Math.Floor(x._value);
            xdouble IMath<xdouble>.IEEERemainder(xdouble x, xdouble y) => Math.IEEERemainder(x._value, y._value);
            xdouble IMath<xdouble>.Log(xdouble x) => Math.Log(x._value);
            xdouble IMath<xdouble>.Log(xdouble x, xdouble y) => Math.Log(x._value, y._value);
            xdouble IMath<xdouble>.Log10(xdouble x) => Math.Log10(x._value);
            xdouble IMath<xdouble>.Max(xdouble x, xdouble y) => Math.Max(x._value, y._value);
            xdouble IMath<xdouble>.Min(xdouble x, xdouble y) => Math.Min(x._value, y._value);
            xdouble IMath<xdouble>.Pow(xdouble x, byte y) => Math.Pow(x._value, y);
            xdouble IMath<xdouble>.Pow(xdouble x, xdouble y) => Math.Pow(x._value, y._value);
            xdouble IMath<xdouble>.RadiansToDegrees(xdouble x) => x * Trig.DegreesPerRadian;
            xdouble IMath<xdouble>.Round(xdouble x) => Math.Round(x._value);
            xdouble IMath<xdouble>.Round(xdouble x, int digits) => Math.Round(x._value, digits);
            xdouble IMath<xdouble>.Round(xdouble x, int digits, MidpointRounding mode) => Math.Round(x._value, digits, mode);
            xdouble IMath<xdouble>.Round(xdouble x, MidpointRounding mode) => Math.Round(x._value, mode);
            xdouble IMath<xdouble>.Sin(xdouble x) => Math.Sin(x._value);
            xdouble IMath<xdouble>.Sinh(xdouble x) => Math.Sinh(x._value);
            xdouble IMath<xdouble>.Sqrt(xdouble x) => Math.Sqrt(x._value);
            xdouble IMath<xdouble>.Tan(xdouble x) => Math.Tan(x._value);
            xdouble IMath<xdouble>.Tanh(xdouble x) => Math.Tanh(x._value);
            xdouble IMath<xdouble>.Truncate(xdouble x) => Math.Truncate(x._value);
            int IMath<xdouble>.Sign(xdouble x) => Math.Sign(x._value);

            xdouble IBitConverter<xdouble>.Read(IReadOnlyStream<byte> stream) => BitConverter.ToDouble(stream.Read(sizeof(double)));
            void IBitConverter<xdouble>.Write(xdouble value, IWriteOnlyStream<byte> stream) => stream.Write(BitConverter.GetBytes(value._value));

            xdouble IRandom<xdouble>.Next(Random random) => random.NextDouble(double.MinValue, double.MaxValue);
            xdouble IRandom<xdouble>.Next(Random random, xdouble bound1, xdouble bound2) => random.NextDouble(bound1._value, bound2._value);

            xdouble IStringParser<xdouble>.Parse(string s) => Parse(s);
            xdouble IStringParser<xdouble>.Parse(string s, NumberStyles numberStyles, IFormatProvider formatProvider) => Parse(s, numberStyles, formatProvider);

            bool IConvert<xdouble>.ToBoolean(xdouble value) => Convert.ToBoolean(value._value);
            byte IConvert<xdouble>.ToByte(xdouble value) => Convert.ToByte(value._value);
            char IConvert<xdouble>.ToChar(xdouble value) => Convert.ToChar(value._value);
            decimal IConvert<xdouble>.ToDecimal(xdouble value) => Convert.ToDecimal(value._value);
            double IConvert<xdouble>.ToDouble(xdouble value) => Convert.ToDouble(value._value);
            float IConvert<xdouble>.ToSingle(xdouble value) => Convert.ToSingle(value._value);
            int IConvert<xdouble>.ToInt32(xdouble value) => Convert.ToInt32(value._value);
            long IConvert<xdouble>.ToInt64(xdouble value) => Convert.ToInt64(value._value);
            sbyte IConvert<xdouble>.ToSByte(xdouble value) => Convert.ToSByte(value._value);
            short IConvert<xdouble>.ToInt16(xdouble value) => Convert.ToInt16(value._value);
            string IConvert<xdouble>.ToString(xdouble value) => Convert.ToString(value._value);
            string IConvert<xdouble>.ToString(xdouble value, IFormatProvider provider) => Convert.ToString(value._value, provider);
            uint IConvert<xdouble>.ToUInt32(xdouble value) => Convert.ToUInt32(value._value);
            ulong IConvert<xdouble>.ToUInt64(xdouble value) => Convert.ToUInt64(value._value);
            ushort IConvert<xdouble>.ToUInt16(xdouble value) => Convert.ToUInt16(value._value);

            xdouble IConvert<xdouble>.ToValue(bool value) => Convert.ToDouble(value);
            xdouble IConvert<xdouble>.ToValue(byte value) => Convert.ToDouble(value);
            xdouble IConvert<xdouble>.ToValue(char value) => Convert.ToDouble(value);
            xdouble IConvert<xdouble>.ToValue(decimal value) => Convert.ToDouble(value);
            xdouble IConvert<xdouble>.ToValue(double value) => Convert.ToDouble(value);
            xdouble IConvert<xdouble>.ToValue(float value) => Convert.ToDouble(value);
            xdouble IConvert<xdouble>.ToValue(int value) => Convert.ToDouble(value);
            xdouble IConvert<xdouble>.ToValue(long value) => Convert.ToDouble(value);
            xdouble IConvert<xdouble>.ToValue(sbyte value) => Convert.ToDouble(value);
            xdouble IConvert<xdouble>.ToValue(short value) => Convert.ToDouble(value);
            xdouble IConvert<xdouble>.ToValue(string value) => Convert.ToDouble(value);
            xdouble IConvert<xdouble>.ToValue(string value, IFormatProvider provider) => Convert.ToDouble(value, provider);
            xdouble IConvert<xdouble>.ToValue(uint value) => Convert.ToDouble(value);
            xdouble IConvert<xdouble>.ToValue(ulong value) => Convert.ToDouble(value);
            xdouble IConvert<xdouble>.ToValue(ushort value) => Convert.ToDouble(value);
        }
    }
}
