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
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Runtime.Serialization;

namespace Jodo.Extensions.CheckedNumerics
{
    [Serializable]
    [DebuggerDisplay("{ToString(),nq}")]
    [SuppressMessage("Style", "IDE1006:Naming Styles")]
    [SuppressMessage("CodeQuality", "IDE0079:Remove unnecessary suppression")]
    [SuppressMessage("csharpsquid", "S101")]
    public readonly struct cdouble : INumeric<cdouble>
    {
        public static readonly cdouble Epsilon = double.Epsilon;
        public static readonly cdouble MaxValue = double.MaxValue;
        public static readonly cdouble MinValue = double.MinValue;

        private readonly double _value;

        public cdouble(double value)
        {
            if (double.IsFinite(value)) _value = value;
            else if (double.IsPositiveInfinity(value)) _value = double.MaxValue;
            else if (double.IsNegativeInfinity(value)) _value = double.MinValue;
            else _value = 0d;
        }

        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context) => info.AddValue(nameof(cdouble), _value);
        private cdouble(SerializationInfo info, StreamingContext context) : this(info.GetDouble(nameof(cdouble))) { }

        public int CompareTo(cdouble other) => _value.CompareTo(other._value);
        public int CompareTo(object? obj) => obj is cdouble other ? CompareTo(other) : 1;
        public bool Equals(cdouble other) => _value == other._value;
        public override bool Equals(object? obj) => obj is cdouble other && Equals(other);
        public override int GetHashCode() => _value.GetHashCode();
        public override string ToString() => _value.ToString();
        public string ToString(IFormatProvider formatProvider) => _value.ToString(formatProvider);
        public string ToString(string format, IFormatProvider formatProvider) => _value.ToString(format, formatProvider);

        public static bool IsNormal(cdouble d) => double.IsNormal(d._value);
        public static bool IsSubnormal(cdouble d) => double.IsSubnormal(d._value);
        public static bool TryParse(string s, IFormatProvider provider, out cdouble result) => Try.Run(() => Parse(s, provider), out result);
        public static bool TryParse(string s, NumberStyles style, IFormatProvider provider, out cdouble result) => Try.Run(() => Parse(s, style, provider), out result);
        public static bool TryParse(string s, NumberStyles style, out cdouble result) => Try.Run(() => Parse(s, style), out result);
        public static bool TryParse(string s, out cdouble result) => Try.Run(() => Parse(s), out result);
        public static cdouble Parse(string s) => double.Parse(s);
        public static cdouble Parse(string s, IFormatProvider provider) => double.Parse(s, provider);
        public static cdouble Parse(string s, NumberStyles style) => double.Parse(s, style);
        public static cdouble Parse(string s, NumberStyles style, IFormatProvider provider) => double.Parse(s, style, provider);

        public static explicit operator cdouble(decimal value) => new cdouble(CheckedConvert.ToDouble(value));
        public static implicit operator cdouble(bool value) => new cdouble(value ? 1 : 0);
        public static implicit operator cdouble(byte value) => new cdouble(value);
        public static implicit operator cdouble(char value) => new cdouble(value);
        public static implicit operator cdouble(double value) => new cdouble(value);
        public static implicit operator cdouble(float value) => new cdouble(value);
        public static implicit operator cdouble(int value) => new cdouble(value);
        public static implicit operator cdouble(long value) => new cdouble(value);
        public static implicit operator cdouble(sbyte value) => new cdouble(value);
        public static implicit operator cdouble(short value) => new cdouble(value);
        public static implicit operator cdouble(uint value) => new cdouble(value);
        public static implicit operator cdouble(ulong value) => new cdouble(value);
        public static implicit operator cdouble(ushort value) => new cdouble(value);

        public static explicit operator bool(cdouble value) => CheckedConvert.ToBoolean(value._value);
        public static explicit operator char(cdouble value) => CheckedConvert.ToChar(value._value);
        public static explicit operator byte(cdouble value) => CheckedConvert.ToByte(value._value);
        public static explicit operator decimal(cdouble value) => CheckedConvert.ToDecimal(value._value);
        public static explicit operator float(cdouble value) => CheckedConvert.ToSingle(value._value);
        public static explicit operator int(cdouble value) => CheckedConvert.ToInt32(value._value);
        public static explicit operator long(cdouble value) => CheckedConvert.ToInt64(value._value);
        public static explicit operator sbyte(cdouble value) => CheckedConvert.ToSByte(value._value);
        public static explicit operator short(cdouble value) => CheckedConvert.ToInt16(value._value);
        public static explicit operator uint(cdouble value) => CheckedConvert.ToUInt32(value._value);
        public static explicit operator ulong(cdouble value) => CheckedConvert.ToUInt64(value._value);
        public static explicit operator ushort(cdouble value) => CheckedConvert.ToUInt16(value._value);
        public static implicit operator double(cdouble value) => value._value;

        public static bool operator !=(cdouble left, cdouble right) => left._value != right._value;
        public static bool operator <(cdouble left, cdouble right) => left._value < right._value;
        public static bool operator <=(cdouble left, cdouble right) => left._value <= right._value;
        public static bool operator ==(cdouble left, cdouble right) => left._value == right._value;
        public static bool operator >(cdouble left, cdouble right) => left._value > right._value;
        public static bool operator >=(cdouble left, cdouble right) => left._value >= right._value;
        public static cdouble operator %(cdouble left, cdouble right) => CheckedArithmetic.Remainder(left._value, right._value);
        public static cdouble operator -(cdouble left, cdouble right) => CheckedArithmetic.Subtract(left._value, right._value);
        public static cdouble operator --(cdouble value) => value - 1;
        public static cdouble operator -(cdouble value) => -value._value;
        public static cdouble operator *(cdouble left, cdouble right) => CheckedArithmetic.Multiply(left._value, right._value);
        public static cdouble operator /(cdouble left, cdouble right) => CheckedArithmetic.Divide(left._value, right._value);
        public static cdouble operator +(cdouble left, cdouble right) => CheckedArithmetic.Add(left._value, right._value);
        public static cdouble operator +(cdouble value) => value;
        public static cdouble operator ++(cdouble value) => value + 1;

        bool INumeric<cdouble>.IsGreaterThan(cdouble value) => this > value;
        bool INumeric<cdouble>.IsGreaterThanOrEqualTo(cdouble value) => this >= value;
        bool INumeric<cdouble>.IsLessThan(cdouble value) => this < value;
        bool INumeric<cdouble>.IsLessThanOrEqualTo(cdouble value) => this <= value;
        cdouble INumeric<cdouble>.Add(cdouble value) => this + value;
        cdouble INumeric<cdouble>.Divide(cdouble value) => this / value;
        cdouble INumeric<cdouble>.Multiply(cdouble value) => this * value;
        cdouble INumeric<cdouble>.Negative() => -this;
        cdouble INumeric<cdouble>.Positive() => +this;
        cdouble INumeric<cdouble>.Remainder(cdouble value) => this % value;
        cdouble INumeric<cdouble>.Subtract(cdouble value) => this - value;

        IBitConverter<cdouble> IBitConvertible<cdouble>.BitConverter => Utilities.Instance;
        IConvert<cdouble> IConvertible<cdouble>.Convert => Utilities.Instance;
        IMath<cdouble> INumeric<cdouble>.Math => Utilities.Instance;
        IRandom<cdouble> IRandomisable<cdouble>.Random => Utilities.Instance;
        IStringParser<cdouble> IStringParsable<cdouble>.StringParser => Utilities.Instance;

        private sealed class Utilities :
            IBitConverter<cdouble>,
            IMath<cdouble>,
            IConvert<cdouble>,
            IRandom<cdouble>,
            IStringParser<cdouble>
        {
            public readonly static Utilities Instance = new Utilities();

            bool IMath<cdouble>.IsReal { get; } = true;
            bool IMath<cdouble>.IsSigned { get; } = true;
            cdouble IMath<cdouble>.Epsilon => Epsilon;
            cdouble IMath<cdouble>.MaxUnit { get; } = 1d;
            cdouble IMath<cdouble>.MaxValue => MaxValue;
            cdouble IMath<cdouble>.MinUnit { get; } = -1d;
            cdouble IMath<cdouble>.MinValue => MinValue;
            cdouble IMath<cdouble>.One { get; } = 1d;
            cdouble IMath<cdouble>.Zero { get; } = 0d;
            cdouble IMath<cdouble>.E { get; } = Math.E;
            cdouble IMath<cdouble>.PI { get; } = Math.PI;
            cdouble IMath<cdouble>.Tau { get; } = Math.PI * 2d;

            cdouble IMath<cdouble>.Abs(cdouble x) => Math.Abs(x._value);
            cdouble IMath<cdouble>.Acos(cdouble x) => Math.Acos(x._value);
            cdouble IMath<cdouble>.Acosh(cdouble x) => Math.Acosh(x._value);
            cdouble IMath<cdouble>.Asin(cdouble x) => Math.Asin(x._value);
            cdouble IMath<cdouble>.Asinh(cdouble x) => Math.Asinh(x._value);
            cdouble IMath<cdouble>.Atan(cdouble x) => Math.Atan(x._value);
            cdouble IMath<cdouble>.Atan2(cdouble x, cdouble y) => Math.Atan2(x._value, y._value);
            cdouble IMath<cdouble>.Atanh(cdouble x) => Math.Atanh(x._value);
            cdouble IMath<cdouble>.Cbrt(cdouble x) => Math.Cbrt(x._value);
            cdouble IMath<cdouble>.Ceiling(cdouble x) => Math.Ceiling(x._value);
            cdouble IMath<cdouble>.Clamp(cdouble x, cdouble bound1, cdouble bound2) => bound1 > bound2 ? Math.Min(bound1._value, Math.Max(bound2._value, x._value)) : Math.Min(bound2._value, Math.Max(bound1._value, x._value));
            cdouble IMath<cdouble>.Cos(cdouble x) => Math.Cos(x._value);
            cdouble IMath<cdouble>.Cosh(cdouble x) => Math.Cosh(x._value);
            cdouble IMath<cdouble>.DegreesToRadians(cdouble degrees) => degrees * Trig.RadiansPerDegree;
            cdouble IMath<cdouble>.Exp(cdouble x) => Math.Exp(x._value);
            cdouble IMath<cdouble>.Floor(cdouble x) => Math.Floor(x._value);
            cdouble IMath<cdouble>.IEEERemainder(cdouble x, cdouble y) => Math.IEEERemainder(x._value, y._value);
            cdouble IMath<cdouble>.Log(cdouble x) => Math.Log(x._value);
            cdouble IMath<cdouble>.Log(cdouble x, cdouble y) => Math.Log(x._value, y._value);
            cdouble IMath<cdouble>.Log10(cdouble x) => Math.Log10(x._value);
            cdouble IMath<cdouble>.Max(cdouble x, cdouble y) => Math.Max(x._value, y._value);
            cdouble IMath<cdouble>.Min(cdouble x, cdouble y) => Math.Min(x._value, y._value);
            cdouble IMath<cdouble>.Pow(cdouble x, byte y) => Math.Pow(x._value, y);
            cdouble IMath<cdouble>.Pow(cdouble x, cdouble y) => Math.Pow(x._value, y._value);
            cdouble IMath<cdouble>.RadiansToDegrees(cdouble radians) => radians * Trig.DegreesPerRadian;
            cdouble IMath<cdouble>.Round(cdouble x) => Math.Round(x._value);
            cdouble IMath<cdouble>.Round(cdouble x, int digits) => Math.Round(x._value, digits);
            cdouble IMath<cdouble>.Round(cdouble x, int digits, MidpointRounding mode) => Math.Round(x._value, digits, mode);
            cdouble IMath<cdouble>.Round(cdouble x, MidpointRounding mode) => Math.Round(x._value, mode);
            cdouble IMath<cdouble>.Sin(cdouble x) => Math.Sin(x._value);
            cdouble IMath<cdouble>.Sinh(cdouble x) => Math.Sinh(x._value);
            cdouble IMath<cdouble>.Sqrt(cdouble x) => Math.Sqrt(x._value);
            cdouble IMath<cdouble>.Tan(cdouble x) => Math.Tan(x._value);
            cdouble IMath<cdouble>.Tanh(cdouble x) => Math.Tanh(x._value);
            cdouble IMath<cdouble>.Truncate(cdouble x) => Math.Truncate(x._value);
            int IMath<cdouble>.Sign(cdouble x) => Math.Sign(x._value);

            cdouble IBitConverter<cdouble>.Read(IReadOnlyStream<byte> stream) => BitConverter.ToDouble(stream.Read(sizeof(double)));
            void IBitConverter<cdouble>.Write(cdouble value, IWriteOnlyStream<byte> stream) => stream.Write(BitConverter.GetBytes(value._value));

            cdouble IRandom<cdouble>.Next(Random random) => random.NextDouble(double.MinValue, double.MaxValue);
            cdouble IRandom<cdouble>.Next(Random random, cdouble bound1, cdouble bound2) => random.NextDouble(bound1._value, bound2._value);

            cdouble IStringParser<cdouble>.Parse(string s) => Parse(s);
            cdouble IStringParser<cdouble>.Parse(string s, NumberStyles numberStyles, IFormatProvider formatProvider) => Parse(s, numberStyles, formatProvider);

            bool IConvert<cdouble>.ToBoolean(cdouble value) => CheckedConvert.ToBoolean(value._value);
            byte IConvert<cdouble>.ToByte(cdouble value) => CheckedConvert.ToByte(value._value);
            char IConvert<cdouble>.ToChar(cdouble value) => CheckedConvert.ToChar(value._value);
            decimal IConvert<cdouble>.ToDecimal(cdouble value) => CheckedConvert.ToDecimal(value._value);
            double IConvert<cdouble>.ToDouble(cdouble value) => value._value;
            float IConvert<cdouble>.ToSingle(cdouble value) => CheckedConvert.ToSingle(value._value);
            int IConvert<cdouble>.ToInt32(cdouble value) => CheckedConvert.ToInt32(value._value);
            long IConvert<cdouble>.ToInt64(cdouble value) => CheckedConvert.ToInt64(value._value);
            sbyte IConvert<cdouble>.ToSByte(cdouble value) => CheckedConvert.ToSByte(value._value);
            short IConvert<cdouble>.ToInt16(cdouble value) => CheckedConvert.ToInt16(value._value);
            string IConvert<cdouble>.ToString(cdouble value) => Convert.ToString(value._value);
            string IConvert<cdouble>.ToString(cdouble value, IFormatProvider provider) => Convert.ToString(value._value, provider);
            uint IConvert<cdouble>.ToUInt32(cdouble value) => CheckedConvert.ToUInt32(value._value);
            ulong IConvert<cdouble>.ToUInt64(cdouble value) => CheckedConvert.ToUInt64(value._value);
            ushort IConvert<cdouble>.ToUInt16(cdouble value) => CheckedConvert.ToUInt16(value._value);

            cdouble IConvert<cdouble>.ToValue(bool value) => CheckedConvert.ToDouble(value);
            cdouble IConvert<cdouble>.ToValue(byte value) => CheckedConvert.ToDouble(value);
            cdouble IConvert<cdouble>.ToValue(char value) => CheckedConvert.ToDouble(value);
            cdouble IConvert<cdouble>.ToValue(decimal value) => CheckedConvert.ToDouble(value);
            cdouble IConvert<cdouble>.ToValue(double value) => value;
            cdouble IConvert<cdouble>.ToValue(float value) => CheckedConvert.ToDouble(value);
            cdouble IConvert<cdouble>.ToValue(int value) => CheckedConvert.ToDouble(value);
            cdouble IConvert<cdouble>.ToValue(long value) => CheckedConvert.ToDouble(value);
            cdouble IConvert<cdouble>.ToValue(sbyte value) => CheckedConvert.ToDouble(value);
            cdouble IConvert<cdouble>.ToValue(short value) => CheckedConvert.ToDouble(value);
            cdouble IConvert<cdouble>.ToValue(string value) => Convert.ToDouble(value);
            cdouble IConvert<cdouble>.ToValue(string value, IFormatProvider provider) => Convert.ToDouble(value, provider);
            cdouble IConvert<cdouble>.ToValue(uint value) => CheckedConvert.ToDouble(value);
            cdouble IConvert<cdouble>.ToValue(ulong value) => CheckedConvert.ToDouble(value);
            cdouble IConvert<cdouble>.ToValue(ushort value) => CheckedConvert.ToDouble(value);
        }
    }
}
