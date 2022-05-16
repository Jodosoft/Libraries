﻿// Copyright (c) 2022 Joseph J. Short
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
    public readonly struct xdecimal : INumeric<xdecimal>
    {
        public static readonly xdecimal MaxValue = new xdecimal(decimal.MaxValue);
        public static readonly xdecimal MinValue = new xdecimal(decimal.MinValue);

        private readonly decimal _value;

        private xdecimal(decimal value)
        {
            _value = value;
        }

        private xdecimal(SerializationInfo info, StreamingContext context) : this(info.GetInt64(nameof(xdecimal))) { }
        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context) => info.AddValue(nameof(xdecimal), _value);

        public int CompareTo(xdecimal other) => _value.CompareTo(other._value);
        public int CompareTo(object? obj) => obj is xdecimal other ? CompareTo(other) : 1;
        public bool Equals(xdecimal other) => _value == other._value;
        public override bool Equals(object? obj) => obj is xdecimal other && Equals(other);
        public override int GetHashCode() => _value.GetHashCode();
        public override string ToString() => _value.ToString();
        public string ToString(IFormatProvider formatProvider) => _value.ToString(formatProvider);
        public string ToString(string format, IFormatProvider formatProvider) => _value.ToString(format, formatProvider);

        public static bool TryParse(string s, IFormatProvider provider, out xdecimal result) => Try.Run(() => Parse(s, provider), out result);
        public static bool TryParse(string s, NumberStyles style, IFormatProvider provider, out xdecimal result) => Try.Run(() => Parse(s, style, provider), out result);
        public static bool TryParse(string s, NumberStyles style, out xdecimal result) => Try.Run(() => Parse(s, style), out result);
        public static bool TryParse(string s, out xdecimal result) => Try.Run(() => Parse(s), out result);
        public static xdecimal Parse(string s) => decimal.Parse(s);
        public static xdecimal Parse(string s, IFormatProvider provider) => decimal.Parse(s, provider);
        public static xdecimal Parse(string s, NumberStyles style) => decimal.Parse(s, style);
        public static xdecimal Parse(string s, NumberStyles style, IFormatProvider provider) => decimal.Parse(s, style, provider);

        public static explicit operator xdecimal(double value) => new xdecimal((decimal)value);
        public static explicit operator xdecimal(float value) => new xdecimal((decimal)value);
        public static implicit operator xdecimal(byte value) => new xdecimal(value);
        public static implicit operator xdecimal(char value) => new xdecimal(value);
        public static implicit operator xdecimal(decimal value) => new xdecimal(value);
        public static implicit operator xdecimal(int value) => new xdecimal(value);
        public static implicit operator xdecimal(long value) => new xdecimal(value);
        public static implicit operator xdecimal(sbyte value) => new xdecimal(value);
        public static implicit operator xdecimal(short value) => new xdecimal(value);
        public static implicit operator xdecimal(uint value) => new xdecimal(value);
        public static implicit operator xdecimal(ulong value) => new xdecimal(value);
        public static implicit operator xdecimal(ushort value) => new xdecimal(value);

        public static explicit operator byte(xdecimal value) => (byte)value._value;
        public static explicit operator char(xdecimal value) => (char)value._value;
        public static explicit operator double(xdecimal value) => (double)value._value;
        public static explicit operator float(xdecimal value) => (float)value._value;
        public static explicit operator int(xdecimal value) => (int)value._value;
        public static explicit operator long(xdecimal value) => (long)value._value;
        public static explicit operator sbyte(xdecimal value) => (sbyte)value._value;
        public static explicit operator short(xdecimal value) => (short)value._value;
        public static explicit operator uint(xdecimal value) => (uint)value._value;
        public static explicit operator ulong(xdecimal value) => (ulong)value._value;
        public static explicit operator ushort(xdecimal value) => (ushort)value._value;
        public static implicit operator decimal(xdecimal value) => value._value;

        public static bool operator !=(xdecimal left, xdecimal right) => left._value != right._value;
        public static bool operator <(xdecimal left, xdecimal right) => left._value < right._value;
        public static bool operator <=(xdecimal left, xdecimal right) => left._value <= right._value;
        public static bool operator ==(xdecimal left, xdecimal right) => left._value == right._value;
        public static bool operator >(xdecimal left, xdecimal right) => left._value > right._value;
        public static bool operator >=(xdecimal left, xdecimal right) => left._value >= right._value;
        public static xdecimal operator %(xdecimal left, xdecimal right) => left._value % right._value;
        public static xdecimal operator -(xdecimal left, xdecimal right) => left._value - right._value;
        public static xdecimal operator --(xdecimal value) => value._value - 1;
        public static xdecimal operator -(xdecimal value) => -value._value;
        public static xdecimal operator *(xdecimal left, xdecimal right) => left._value * right._value;
        public static xdecimal operator /(xdecimal left, xdecimal right) => left._value / right._value;
        public static xdecimal operator +(xdecimal left, xdecimal right) => left._value + right._value;
        public static xdecimal operator +(xdecimal value) => value;
        public static xdecimal operator ++(xdecimal value) => value._value + 1;

        bool INumeric<xdecimal>.IsGreaterThan(xdecimal value) => this > value;
        bool INumeric<xdecimal>.IsGreaterThanOrEqualTo(xdecimal value) => this >= value;
        bool INumeric<xdecimal>.IsLessThan(xdecimal value) => this < value;
        bool INumeric<xdecimal>.IsLessThanOrEqualTo(xdecimal value) => this <= value;
        xdecimal INumeric<xdecimal>.Add(xdecimal value) => this + value;
        xdecimal INumeric<xdecimal>.Divide(xdecimal value) => this / value;
        xdecimal INumeric<xdecimal>.Multiply(xdecimal value) => this * value;
        xdecimal INumeric<xdecimal>.Negative() => -this;
        xdecimal INumeric<xdecimal>.Positive() => +this;
        xdecimal INumeric<xdecimal>.Remainder(xdecimal value) => this % value;
        xdecimal INumeric<xdecimal>.Subtract(xdecimal value) => this - value;

        IBitConverter<xdecimal> IBitConvertible<xdecimal>.BitConverter => Utilities.Instance;
        IConstants<xdecimal> INumeric<xdecimal>.Constants => Utilities.Instance;
        IConvert<xdecimal> IConvertible<xdecimal>.Convert => Utilities.Instance;
        IMath<xdecimal> INumeric<xdecimal>.Math => Utilities.Instance;
        IRandom<xdecimal> IRandomisable<xdecimal>.Random => Utilities.Instance;
        IStringParser<xdecimal> IStringParsable<xdecimal>.StringParser => Utilities.Instance;

        private sealed class Utilities :
            IBitConverter<xdecimal>,
            IConstants<xdecimal>,
            IConvert<xdecimal>,
            IMath<xdecimal>,
            IRandom<xdecimal>,
            IStringParser<xdecimal>
        {
            public readonly static Utilities Instance = new Utilities();

            bool IConstants<xdecimal>.IsReal { get; } = true;
            bool IConstants<xdecimal>.IsSigned { get; } = true;
            xdecimal IConstants<xdecimal>.Epsilon { get; } = new decimal(1, 0, 0, false, 28);
            xdecimal IConstants<xdecimal>.MaxUnit { get; } = (decimal)1;
            xdecimal IConstants<xdecimal>.MaxValue => MaxValue;
            xdecimal IConstants<xdecimal>.MinUnit { get; } = (decimal)-1;
            xdecimal IConstants<xdecimal>.MinValue => MinValue;
            xdecimal IConstants<xdecimal>.One { get; } = (decimal)1;
            xdecimal IConstants<xdecimal>.Zero { get; } = (decimal)0;
            xdecimal IMath<xdecimal>.E { get; } = (decimal)Math.E;
            xdecimal IMath<xdecimal>.PI { get; } = (decimal)Math.PI;
            xdecimal IMath<xdecimal>.Tau { get; } = (decimal)Math.PI * 2;

            int IMath<xdecimal>.Sign(xdecimal x) => Math.Sign(x._value);
            xdecimal IMath<xdecimal>.Abs(xdecimal x) => Math.Abs(x._value);
            xdecimal IMath<xdecimal>.Acos(xdecimal x) => (decimal)Math.Acos((double)x._value);
            xdecimal IMath<xdecimal>.Acosh(xdecimal x) => (decimal)Math.Acosh((double)x._value);
            xdecimal IMath<xdecimal>.Asin(xdecimal x) => (decimal)Math.Asin((double)x._value);
            xdecimal IMath<xdecimal>.Asinh(xdecimal x) => (decimal)Math.Asinh((double)x._value);
            xdecimal IMath<xdecimal>.Atan(xdecimal x) => (decimal)Math.Atan((double)x._value);
            xdecimal IMath<xdecimal>.Atan2(xdecimal x, xdecimal y) => (decimal)Math.Atan2((double)x._value, (double)y._value);
            xdecimal IMath<xdecimal>.Atanh(xdecimal x) => (decimal)Math.Atanh((double)x._value);
            xdecimal IMath<xdecimal>.Cbrt(xdecimal x) => (decimal)Math.Cbrt((double)x._value);
            xdecimal IMath<xdecimal>.Ceiling(xdecimal x) => decimal.Ceiling(x._value);
            xdecimal IMath<xdecimal>.Clamp(xdecimal x, xdecimal bound1, xdecimal bound2) => bound1 > bound2 ? Math.Min(bound1._value, Math.Max(bound2._value, x._value)) : Math.Min(bound2._value, Math.Max(bound1._value, x._value));
            xdecimal IMath<xdecimal>.Cos(xdecimal x) => (decimal)Math.Cos((double)x._value);
            xdecimal IMath<xdecimal>.Cosh(xdecimal x) => (decimal)Math.Cosh((double)x._value);
            xdecimal IMath<xdecimal>.DegreesToRadians(xdecimal degrees) => degrees * Trig.RadiansPerDegreeM;
            xdecimal IMath<xdecimal>.Exp(xdecimal x) => (decimal)Math.Exp((double)x._value);
            xdecimal IMath<xdecimal>.Floor(xdecimal x) => decimal.Floor(x._value);
            xdecimal IMath<xdecimal>.IEEERemainder(xdecimal x, xdecimal y) => (decimal)Math.IEEERemainder((double)x._value, (double)y._value);
            xdecimal IMath<xdecimal>.Log(xdecimal x) => (decimal)Math.Log((double)x._value);
            xdecimal IMath<xdecimal>.Log(xdecimal x, xdecimal y) => (decimal)Math.Log((double)x._value, (double)y._value);
            xdecimal IMath<xdecimal>.Log10(xdecimal x) => (decimal)Math.Log10((double)x._value);
            xdecimal IMath<xdecimal>.Max(xdecimal x, xdecimal y) => Math.Max(x._value, y._value);
            xdecimal IMath<xdecimal>.Min(xdecimal x, xdecimal y) => Math.Min(x._value, y._value);
            xdecimal IMath<xdecimal>.Pow(xdecimal x, byte y) => (decimal)Math.Pow((double)x._value, y);
            xdecimal IMath<xdecimal>.Pow(xdecimal x, xdecimal y) => (decimal)Math.Pow((double)x._value, (double)y._value);
            xdecimal IMath<xdecimal>.RadiansToDegrees(xdecimal radians) => radians * Trig.DegreesPerRadianM;
            xdecimal IMath<xdecimal>.Round(xdecimal x) => decimal.Round(x);
            xdecimal IMath<xdecimal>.Round(xdecimal x, int digits) => decimal.Round(x, digits);
            xdecimal IMath<xdecimal>.Round(xdecimal x, int digits, MidpointRounding mode) => decimal.Round(x, digits, mode);
            xdecimal IMath<xdecimal>.Round(xdecimal x, MidpointRounding mode) => decimal.Round(x, mode);
            xdecimal IMath<xdecimal>.Sin(xdecimal x) => (decimal)Math.Sin((double)x._value);
            xdecimal IMath<xdecimal>.Sinh(xdecimal x) => (decimal)Math.Sinh((double)x._value);
            xdecimal IMath<xdecimal>.Sqrt(xdecimal x) => (decimal)Math.Sqrt((double)x._value);
            xdecimal IMath<xdecimal>.Tan(xdecimal x) => (decimal)Math.Tan((double)x._value);
            xdecimal IMath<xdecimal>.Tanh(xdecimal x) => (decimal)Math.Tanh((double)x._value);
            xdecimal IMath<xdecimal>.Truncate(xdecimal x) => decimal.Truncate(x._value);

            xdecimal IBitConverter<xdecimal>.Read(IReadOnlyStream<byte> stream)
            {
                var part0 = BitConverter.ToInt32(stream.Read(sizeof(int)));
                var part1 = BitConverter.ToInt32(stream.Read(sizeof(int)));
                var part2 = BitConverter.ToInt32(stream.Read(sizeof(int)));
                var part3 = BitConverter.ToInt32(stream.Read(sizeof(int)));

                var sign = (part3 & 0x80000000) != 0;
                var scale = (byte)((part3 >> 16) & 0x7F);

                return new decimal(part0, part1, part2, sign, scale);
            }

            void IBitConverter<xdecimal>.Write(xdecimal value, IWriteOnlyStream<byte> stream)
            {
                var parts = decimal.GetBits(value);
                stream.Write(BitConverter.GetBytes(parts[0]));
                stream.Write(BitConverter.GetBytes(parts[1]));
                stream.Write(BitConverter.GetBytes(parts[2]));
                stream.Write(BitConverter.GetBytes(parts[3]));
            }

            xdecimal IRandom<xdecimal>.Next(Random random) => random.NextDecimal();
            xdecimal IRandom<xdecimal>.Next(Random random, xdecimal bound1, xdecimal bound2) => random.NextDecimal(bound1._value, bound2._value);

            xdecimal IStringParser<xdecimal>.Parse(string s) => Parse(s);
            xdecimal IStringParser<xdecimal>.Parse(string s, NumberStyles numberStyles, IFormatProvider formatProvider) => Parse(s, numberStyles, formatProvider);

            bool IConvert<xdecimal>.ToBoolean(xdecimal value) => Convert.ToBoolean(value._value);
            byte IConvert<xdecimal>.ToByte(xdecimal value) => Convert.ToByte(value._value);
            char IConvert<xdecimal>.ToChar(xdecimal value) => Convert.ToChar(value._value);
            decimal IConvert<xdecimal>.ToDecimal(xdecimal value) => value;
            double IConvert<xdecimal>.ToDouble(xdecimal value) => Convert.ToDouble(value._value);
            float IConvert<xdecimal>.ToSingle(xdecimal value) => Convert.ToSingle(value._value);
            int IConvert<xdecimal>.ToInt32(xdecimal value) => Convert.ToInt32(value._value);
            long IConvert<xdecimal>.ToInt64(xdecimal value) => Convert.ToInt64(value._value);
            sbyte IConvert<xdecimal>.ToSByte(xdecimal value) => Convert.ToSByte(value._value);
            short IConvert<xdecimal>.ToInt16(xdecimal value) => Convert.ToInt16(value._value);
            string IConvert<xdecimal>.ToString(xdecimal value) => Convert.ToString(value._value);
            string IConvert<xdecimal>.ToString(xdecimal value, IFormatProvider provider) => Convert.ToString(value._value, provider);
            uint IConvert<xdecimal>.ToUInt32(xdecimal value) => Convert.ToUInt32(value._value);
            ulong IConvert<xdecimal>.ToUInt64(xdecimal value) => Convert.ToUInt64(value._value);
            ushort IConvert<xdecimal>.ToUInt16(xdecimal value) => Convert.ToUInt16(value._value);

            xdecimal IConvert<xdecimal>.ToValue(bool value) => Convert.ToDecimal(value);
            xdecimal IConvert<xdecimal>.ToValue(byte value) => Convert.ToDecimal(value);
            xdecimal IConvert<xdecimal>.ToValue(char value) => Convert.ToDecimal(value);
            xdecimal IConvert<xdecimal>.ToValue(decimal value) => value;
            xdecimal IConvert<xdecimal>.ToValue(double value) => Convert.ToDecimal(value);
            xdecimal IConvert<xdecimal>.ToValue(float value) => Convert.ToDecimal(value);
            xdecimal IConvert<xdecimal>.ToValue(int value) => Convert.ToDecimal(value);
            xdecimal IConvert<xdecimal>.ToValue(long value) => Convert.ToDecimal(value);
            xdecimal IConvert<xdecimal>.ToValue(sbyte value) => Convert.ToDecimal(value);
            xdecimal IConvert<xdecimal>.ToValue(short value) => Convert.ToDecimal(value);
            xdecimal IConvert<xdecimal>.ToValue(string value) => Convert.ToDecimal(value);
            xdecimal IConvert<xdecimal>.ToValue(string value, IFormatProvider provider) => Convert.ToDecimal(value, provider);
            xdecimal IConvert<xdecimal>.ToValue(uint value) => Convert.ToDecimal(value);
            xdecimal IConvert<xdecimal>.ToValue(ulong value) => Convert.ToDecimal(value);
            xdecimal IConvert<xdecimal>.ToValue(ushort value) => Convert.ToDecimal(value);
        }
    }
}