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
    [SuppressMessage("csharpsquid", "S101")]
    public readonly struct cdecimal : INumeric<cdecimal>
    {
        public static readonly cdecimal MaxValue = new cdecimal(decimal.MaxValue);
        public static readonly cdecimal MinValue = new cdecimal(decimal.MinValue);

        private readonly decimal _value;

        public cdecimal(decimal value)
        {
            _value = value;
        }

        private cdecimal(SerializationInfo info, StreamingContext context) : this(info.GetDecimal(nameof(cdecimal))) { }
        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context) => info.AddValue(nameof(cdecimal), _value);

        public int CompareTo(cdecimal other) => _value.CompareTo(other._value);
        public int CompareTo(object? obj) => obj is cdecimal other ? CompareTo(other) : 1;
        public bool Equals(cdecimal other) => _value == other._value;
        public override bool Equals(object? obj) => obj is cdecimal other && Equals(other);
        public override int GetHashCode() => _value.GetHashCode();
        public override string ToString() => _value.ToString();
        public string ToString(IFormatProvider formatProvider) => _value.ToString(formatProvider);
        public string ToString(string format) => _value.ToString(format);
        public string ToString(string? format, IFormatProvider? formatProvider) => _value.ToString(format, formatProvider);

        public static bool TryParse(string s, IFormatProvider? provider, out cdecimal result) => Try.Run(() => Parse(s, provider), out result);
        public static bool TryParse(string s, NumberStyles style, IFormatProvider? provider, out cdecimal result) => Try.Run(() => Parse(s, style, provider), out result);
        public static bool TryParse(string s, NumberStyles style, out cdecimal result) => Try.Run(() => Parse(s, style), out result);
        public static bool TryParse(string s, out cdecimal result) => Try.Run(() => Parse(s), out result);
        public static cdecimal Parse(string s) => decimal.Parse(s);
        public static cdecimal Parse(string s, IFormatProvider? provider) => decimal.Parse(s, provider);
        public static cdecimal Parse(string s, NumberStyles style) => decimal.Parse(s, style);
        public static cdecimal Parse(string s, NumberStyles style, IFormatProvider? provider) => decimal.Parse(s, style, provider);

        public static explicit operator cdecimal(double value) => new cdecimal(CheckedConvert.ToDecimal(value));
        public static explicit operator cdecimal(float value) => new cdecimal(CheckedConvert.ToDecimal(value));
        public static implicit operator cdecimal(byte value) => new cdecimal(value);
        public static implicit operator cdecimal(decimal value) => new cdecimal(value);
        public static implicit operator cdecimal(int value) => new cdecimal(value);
        public static implicit operator cdecimal(long value) => new cdecimal(value);
        public static implicit operator cdecimal(sbyte value) => new cdecimal(value);
        public static implicit operator cdecimal(short value) => new cdecimal(value);
        public static implicit operator cdecimal(uint value) => new cdecimal(value);
        public static implicit operator cdecimal(ulong value) => new cdecimal(value);
        public static implicit operator cdecimal(ushort value) => new cdecimal(value);

        public static explicit operator byte(cdecimal value) => CheckedConvert.ToByte(value._value);
        public static explicit operator double(cdecimal value) => CheckedConvert.ToDouble(value._value);
        public static explicit operator float(cdecimal value) => CheckedConvert.ToSingle(value._value);
        public static explicit operator int(cdecimal value) => CheckedConvert.ToInt32(value._value);
        public static explicit operator long(cdecimal value) => CheckedConvert.ToInt64(value._value);
        public static explicit operator sbyte(cdecimal value) => CheckedConvert.ToSByte(value._value);
        public static explicit operator short(cdecimal value) => CheckedConvert.ToInt16(value._value);
        public static explicit operator uint(cdecimal value) => CheckedConvert.ToUInt32(value._value);
        public static explicit operator ulong(cdecimal value) => CheckedConvert.ToUInt64(value._value);
        public static explicit operator ushort(cdecimal value) => CheckedConvert.ToUInt16(value._value);
        public static implicit operator decimal(cdecimal value) => value._value;

        public static bool operator !=(cdecimal left, cdecimal right) => left._value != right._value;
        public static bool operator <(cdecimal left, cdecimal right) => left._value < right._value;
        public static bool operator <=(cdecimal left, cdecimal right) => left._value <= right._value;
        public static bool operator ==(cdecimal left, cdecimal right) => left._value == right._value;
        public static bool operator >(cdecimal left, cdecimal right) => left._value > right._value;
        public static bool operator >=(cdecimal left, cdecimal right) => left._value >= right._value;
        public static cdecimal operator %(cdecimal left, cdecimal right) => CheckedArithmetic.Remainder(left._value, right._value);
        public static cdecimal operator &(cdecimal left, cdecimal right) => BitwiseAndShiftUtilities.LogicalAnd(left._value, right._value);
        public static cdecimal operator -(cdecimal left, cdecimal right) => CheckedArithmetic.Subtract(left._value, right._value);
        public static cdecimal operator --(cdecimal value) => value - 1;
        public static cdecimal operator -(cdecimal value) => -value._value;
        public static cdecimal operator *(cdecimal left, cdecimal right) => CheckedArithmetic.Multiply(left._value, right._value);
        public static cdecimal operator /(cdecimal left, cdecimal right) => CheckedArithmetic.Divide(left._value, right._value);
        public static cdecimal operator ^(cdecimal left, cdecimal right) => BitwiseAndShiftUtilities.LogicalExclusiveOr(left._value, right._value);
        public static cdecimal operator |(cdecimal left, cdecimal right) => BitwiseAndShiftUtilities.LogicalOr(left._value, right._value);
        public static cdecimal operator ~(cdecimal left) => BitwiseAndShiftUtilities.BitwiseComplement(left._value);
        public static cdecimal operator +(cdecimal left, cdecimal right) => CheckedArithmetic.Add(left._value, right._value);
        public static cdecimal operator +(cdecimal value) => value;
        public static cdecimal operator ++(cdecimal value) => value + 1;
        public static cdecimal operator <<(cdecimal left, int right) => BitwiseAndShiftUtilities.LeftShift(left._value, right);
        public static cdecimal operator >>(cdecimal left, int right) => BitwiseAndShiftUtilities.RightShift(left._value, right);

        bool INumeric<cdecimal>.IsGreaterThan(cdecimal value) => this > value;
        bool INumeric<cdecimal>.IsGreaterThanOrEqualTo(cdecimal value) => this >= value;
        bool INumeric<cdecimal>.IsLessThan(cdecimal value) => this < value;
        bool INumeric<cdecimal>.IsLessThanOrEqualTo(cdecimal value) => this <= value;
        cdecimal INumeric<cdecimal>.Add(cdecimal value) => this + value;
        cdecimal INumeric<cdecimal>.BitwiseComplement() => ~this;
        cdecimal INumeric<cdecimal>.Divide(cdecimal value) => this / value;
        cdecimal INumeric<cdecimal>.LeftShift(int count) => this << count;
        cdecimal INumeric<cdecimal>.LogicalAnd(cdecimal value) => this & value;
        cdecimal INumeric<cdecimal>.LogicalExclusiveOr(cdecimal value) => this ^ value;
        cdecimal INumeric<cdecimal>.LogicalOr(cdecimal value) => this | value;
        cdecimal INumeric<cdecimal>.Multiply(cdecimal value) => this * value;
        cdecimal INumeric<cdecimal>.Negative() => -this;
        cdecimal INumeric<cdecimal>.Positive() => +this;
        cdecimal INumeric<cdecimal>.Remainder(cdecimal value) => this % value;
        cdecimal INumeric<cdecimal>.RightShift(int count) => this >> count;
        cdecimal INumeric<cdecimal>.Subtract(cdecimal value) => this - value;

        IBitConverter<cdecimal> IProvider<IBitConverter<cdecimal>>.GetInstance() => Utilities.Instance;
        ICast<cdecimal> IProvider<ICast<cdecimal>>.GetInstance() => Utilities.Instance;
        IConvert<cdecimal> IProvider<IConvert<cdecimal>>.GetInstance() => Utilities.Instance;
        IMath<cdecimal> IProvider<IMath<cdecimal>>.GetInstance() => Utilities.Instance;
        INumericStatic<cdecimal> IProvider<INumericStatic<cdecimal>>.GetInstance() => Utilities.Instance;
        IRandom<cdecimal> IProvider<IRandom<cdecimal>>.GetInstance() => Utilities.Instance;
        IStringParser<cdecimal> IProvider<IStringParser<cdecimal>>.GetInstance() => Utilities.Instance;

        private sealed class Utilities :
            IBitConverter<cdecimal>,
            ICast<cdecimal>,
            IConvert<cdecimal>,
            IMath<cdecimal>,
            INumericStatic<cdecimal>,
            IRandom<cdecimal>,
            IStringParser<cdecimal>
        {
            public readonly static Utilities Instance = new Utilities();

            bool INumericStatic<cdecimal>.HasFloatingPoint { get; } = true;
            bool INumericStatic<cdecimal>.HasInfinity { get; } = false;
            bool INumericStatic<cdecimal>.HasNaN { get; } = false;
            bool INumericStatic<cdecimal>.IsFinite(cdecimal x) => true;
            bool INumericStatic<cdecimal>.IsInfinity(cdecimal x) => false;
            bool INumericStatic<cdecimal>.IsNaN(cdecimal x) => false;
            bool INumericStatic<cdecimal>.IsNegative(cdecimal x) => x._value < 0;
            bool INumericStatic<cdecimal>.IsNegativeInfinity(cdecimal x) => false;
            bool INumericStatic<cdecimal>.IsNormal(cdecimal x) => false;
            bool INumericStatic<cdecimal>.IsPositiveInfinity(cdecimal x) => false;
            bool INumericStatic<cdecimal>.IsReal { get; } = true;
            bool INumericStatic<cdecimal>.IsSigned { get; } = true;
            bool INumericStatic<cdecimal>.IsSubnormal(cdecimal x) => false;
            cdecimal INumericStatic<cdecimal>.Epsilon { get; } = new decimal(1, 0, 0, false, 28);
            cdecimal INumericStatic<cdecimal>.MaxUnit { get; } = 1m;
            cdecimal INumericStatic<cdecimal>.MaxValue => MaxValue;
            cdecimal INumericStatic<cdecimal>.MinUnit { get; } = -1m;
            cdecimal INumericStatic<cdecimal>.MinValue => MinValue;
            cdecimal INumericStatic<cdecimal>.One { get; } = 1m;
            cdecimal INumericStatic<cdecimal>.Ten { get; } = 10m;
            cdecimal INumericStatic<cdecimal>.Two { get; } = 2m;
            cdecimal INumericStatic<cdecimal>.Zero { get; } = 0m;

            cdecimal IMath<cdecimal>.Abs(cdecimal x) => Math.Abs(x._value);
            cdecimal IMath<cdecimal>.Acos(cdecimal x) => CheckedCast.ToDecimal(Math.Acos(CheckedCast.ToDouble(x._value)));
            cdecimal IMath<cdecimal>.Acosh(cdecimal x) => CheckedCast.ToDecimal(Math.Acosh(CheckedCast.ToDouble(x._value)));
            cdecimal IMath<cdecimal>.Asin(cdecimal x) => CheckedCast.ToDecimal(Math.Asin(CheckedCast.ToDouble(x._value)));
            cdecimal IMath<cdecimal>.Asinh(cdecimal x) => CheckedCast.ToDecimal(Math.Asinh(CheckedCast.ToDouble(x._value)));
            cdecimal IMath<cdecimal>.Atan(cdecimal x) => CheckedCast.ToDecimal(Math.Atan(CheckedCast.ToDouble(x._value)));
            cdecimal IMath<cdecimal>.Atan2(cdecimal x, cdecimal y) => CheckedCast.ToDecimal(Math.Atan2(CheckedCast.ToDouble(x._value), CheckedCast.ToDouble(y._value)));
            cdecimal IMath<cdecimal>.Atanh(cdecimal x) => CheckedCast.ToDecimal(Math.Atanh(CheckedCast.ToDouble(x._value)));
            cdecimal IMath<cdecimal>.Cbrt(cdecimal x) => CheckedCast.ToDecimal(Math.Cbrt(CheckedCast.ToDouble(x._value)));
            cdecimal IMath<cdecimal>.Ceiling(cdecimal x) => decimal.Ceiling(x._value);
            cdecimal IMath<cdecimal>.Clamp(cdecimal x, cdecimal bound1, cdecimal bound2) => bound1 > bound2 ? Math.Min(bound1._value, Math.Max(bound2._value, x._value)) : Math.Min(bound2._value, Math.Max(bound1._value, x._value));
            cdecimal IMath<cdecimal>.Cos(cdecimal x) => CheckedCast.ToDecimal(Math.Cos(CheckedCast.ToDouble(x._value)));
            cdecimal IMath<cdecimal>.Cosh(cdecimal x) => CheckedCast.ToDecimal(Math.Cosh(CheckedCast.ToDouble(x._value)));
            cdecimal IMath<cdecimal>.DegreesToRadians(cdecimal degrees) => degrees * Trig.RadiansPerDegreeM;
            cdecimal IMath<cdecimal>.E { get; } = (decimal)Math.E;
            cdecimal IMath<cdecimal>.Exp(cdecimal x) => CheckedCast.ToDecimal(Math.Exp(CheckedCast.ToDouble(x._value)));
            cdecimal IMath<cdecimal>.Floor(cdecimal x) => decimal.Floor(x._value);
            cdecimal IMath<cdecimal>.IEEERemainder(cdecimal x, cdecimal y) => CheckedCast.ToDecimal(Math.IEEERemainder(CheckedCast.ToDouble(x._value), CheckedCast.ToDouble(y._value)));
            cdecimal IMath<cdecimal>.Log(cdecimal x) => CheckedCast.ToDecimal(Math.Log(CheckedCast.ToDouble(x._value)));
            cdecimal IMath<cdecimal>.Log(cdecimal x, cdecimal y) => CheckedCast.ToDecimal(Math.Log(CheckedCast.ToDouble(x._value), CheckedCast.ToDouble(y._value)));
            cdecimal IMath<cdecimal>.Log10(cdecimal x) => CheckedCast.ToDecimal(Math.Log10(CheckedCast.ToDouble(x._value)));
            cdecimal IMath<cdecimal>.Max(cdecimal x, cdecimal y) => Math.Max(x._value, y._value);
            cdecimal IMath<cdecimal>.Min(cdecimal x, cdecimal y) => Math.Min(x._value, y._value);
            cdecimal IMath<cdecimal>.PI { get; } = (decimal)Math.PI;
            cdecimal IMath<cdecimal>.Pow(cdecimal x, cdecimal y) => y == 1 ? x : (cdecimal)CheckedCast.ToDecimal(Math.Pow(CheckedCast.ToDouble(x._value), CheckedCast.ToDouble(y._value)));
            cdecimal IMath<cdecimal>.RadiansToDegrees(cdecimal radians) => radians * Trig.DegreesPerRadianM;
            cdecimal IMath<cdecimal>.Round(cdecimal x) => decimal.Round(x);
            cdecimal IMath<cdecimal>.Round(cdecimal x, int digits) => decimal.Round(x, digits);
            cdecimal IMath<cdecimal>.Round(cdecimal x, int digits, MidpointRounding mode) => decimal.Round(x, digits, mode);
            cdecimal IMath<cdecimal>.Round(cdecimal x, MidpointRounding mode) => decimal.Round(x, mode);
            cdecimal IMath<cdecimal>.Sin(cdecimal x) => CheckedCast.ToDecimal(Math.Sin(CheckedCast.ToDouble(x._value)));
            cdecimal IMath<cdecimal>.Sinh(cdecimal x) => CheckedCast.ToDecimal(Math.Sinh(CheckedCast.ToDouble(x._value)));
            cdecimal IMath<cdecimal>.Sqrt(cdecimal x) => CheckedCast.ToDecimal(Math.Sqrt(CheckedCast.ToDouble(x._value)));
            cdecimal IMath<cdecimal>.Tan(cdecimal x) => CheckedCast.ToDecimal(Math.Tan(CheckedCast.ToDouble(x._value)));
            cdecimal IMath<cdecimal>.Tanh(cdecimal x) => CheckedCast.ToDecimal(Math.Tanh(CheckedCast.ToDouble(x._value)));
            cdecimal IMath<cdecimal>.Tau { get; } = (decimal)Math.PI * 2m;
            cdecimal IMath<cdecimal>.Truncate(cdecimal x) => decimal.Truncate(x._value);
            int IMath<cdecimal>.Sign(cdecimal x) => Math.Sign(x._value);

            cdecimal IBitConverter<cdecimal>.Read(IReadOnlyStream<byte> stream)
            {
                var part0 = BitConverter.ToInt32(stream.Read(sizeof(int)));
                var part1 = BitConverter.ToInt32(stream.Read(sizeof(int)));
                var part2 = BitConverter.ToInt32(stream.Read(sizeof(int)));
                var part3 = BitConverter.ToInt32(stream.Read(sizeof(int)));

                var sign = (part3 & 0x80000000) != 0;
                var scale = (byte)((part3 >> 16) & 0x7F);

                return new decimal(part0, part1, part2, sign, scale);
            }

            void IBitConverter<cdecimal>.Write(cdecimal value, IWriteOnlyStream<byte> stream)
            {
                var parts = decimal.GetBits(value);
                stream.Write(BitConverter.GetBytes(parts[0]));
                stream.Write(BitConverter.GetBytes(parts[1]));
                stream.Write(BitConverter.GetBytes(parts[2]));
                stream.Write(BitConverter.GetBytes(parts[3]));
            }

            cdecimal IRandom<cdecimal>.Next(Random random) => random.NextDecimal(decimal.MinValue, decimal.MaxValue);
            cdecimal IRandom<cdecimal>.Next(Random random, cdecimal bound1, cdecimal bound2) => random.NextDecimal(bound1._value, bound2._value);

            bool IConvert<cdecimal>.ToBoolean(cdecimal value) => CheckedConvert.ToBoolean(value._value);
            byte IConvert<cdecimal>.ToByte(cdecimal value) => CheckedConvert.ToByte(value._value);
            decimal IConvert<cdecimal>.ToDecimal(cdecimal value) => value._value;
            double IConvert<cdecimal>.ToDouble(cdecimal value) => CheckedConvert.ToDouble(value._value);
            float IConvert<cdecimal>.ToSingle(cdecimal value) => CheckedConvert.ToSingle(value._value);
            int IConvert<cdecimal>.ToInt32(cdecimal value) => CheckedConvert.ToInt32(value._value);
            long IConvert<cdecimal>.ToInt64(cdecimal value) => CheckedConvert.ToInt64(value._value);
            sbyte IConvert<cdecimal>.ToSByte(cdecimal value) => CheckedConvert.ToSByte(value._value);
            short IConvert<cdecimal>.ToInt16(cdecimal value) => CheckedConvert.ToInt16(value._value);
            string IConvert<cdecimal>.ToString(cdecimal value) => Convert.ToString(value._value);
            uint IConvert<cdecimal>.ToUInt32(cdecimal value) => CheckedConvert.ToUInt32(value._value);
            ulong IConvert<cdecimal>.ToUInt64(cdecimal value) => CheckedConvert.ToUInt64(value._value);
            ushort IConvert<cdecimal>.ToUInt16(cdecimal value) => CheckedConvert.ToUInt16(value._value);

            cdecimal IConvert<cdecimal>.ToNumeric(bool value) => CheckedConvert.ToDecimal(value);
            cdecimal IConvert<cdecimal>.ToNumeric(byte value) => CheckedConvert.ToDecimal(value);
            cdecimal IConvert<cdecimal>.ToNumeric(decimal value) => value;
            cdecimal IConvert<cdecimal>.ToNumeric(double value) => CheckedConvert.ToDecimal(value);
            cdecimal IConvert<cdecimal>.ToNumeric(float value) => CheckedConvert.ToDecimal(value);
            cdecimal IConvert<cdecimal>.ToNumeric(int value) => CheckedConvert.ToDecimal(value);
            cdecimal IConvert<cdecimal>.ToNumeric(long value) => CheckedConvert.ToDecimal(value);
            cdecimal IConvert<cdecimal>.ToNumeric(sbyte value) => CheckedConvert.ToDecimal(value);
            cdecimal IConvert<cdecimal>.ToNumeric(short value) => CheckedConvert.ToDecimal(value);
            cdecimal IConvert<cdecimal>.ToNumeric(string value) => Convert.ToDecimal(value);
            cdecimal IConvert<cdecimal>.ToNumeric(uint value) => CheckedConvert.ToDecimal(value);
            cdecimal IConvert<cdecimal>.ToNumeric(ulong value) => CheckedConvert.ToDecimal(value);
            cdecimal IConvert<cdecimal>.ToNumeric(ushort value) => CheckedConvert.ToDecimal(value);

            cdecimal IStringParser<cdecimal>.Parse(string s) => Parse(s);
            cdecimal IStringParser<cdecimal>.Parse(string s, NumberStyles style, IFormatProvider? provider) => Parse(s, style, provider);

            byte ICast<cdecimal>.ToByte(cdecimal value) => (byte)value;
            decimal ICast<cdecimal>.ToDecimal(cdecimal value) => (decimal)value;
            double ICast<cdecimal>.ToDouble(cdecimal value) => (double)value;
            float ICast<cdecimal>.ToSingle(cdecimal value) => (float)value;
            int ICast<cdecimal>.ToInt32(cdecimal value) => (int)value;
            long ICast<cdecimal>.ToInt64(cdecimal value) => (long)value;
            sbyte ICast<cdecimal>.ToSByte(cdecimal value) => (sbyte)value;
            short ICast<cdecimal>.ToInt16(cdecimal value) => (short)value;
            uint ICast<cdecimal>.ToUInt32(cdecimal value) => (uint)value;
            ulong ICast<cdecimal>.ToUInt64(cdecimal value) => (ulong)value;
            ushort ICast<cdecimal>.ToUInt16(cdecimal value) => (ushort)value;

            cdecimal ICast<cdecimal>.ToNumeric(byte value) => (cdecimal)value;
            cdecimal ICast<cdecimal>.ToNumeric(decimal value) => (cdecimal)value;
            cdecimal ICast<cdecimal>.ToNumeric(double value) => (cdecimal)value;
            cdecimal ICast<cdecimal>.ToNumeric(float value) => (cdecimal)value;
            cdecimal ICast<cdecimal>.ToNumeric(int value) => (cdecimal)value;
            cdecimal ICast<cdecimal>.ToNumeric(long value) => (cdecimal)value;
            cdecimal ICast<cdecimal>.ToNumeric(sbyte value) => (cdecimal)value;
            cdecimal ICast<cdecimal>.ToNumeric(short value) => (cdecimal)value;
            cdecimal ICast<cdecimal>.ToNumeric(uint value) => (cdecimal)value;
            cdecimal ICast<cdecimal>.ToNumeric(ulong value) => (cdecimal)value;
            cdecimal ICast<cdecimal>.ToNumeric(ushort value) => (cdecimal)value;
        }
    }
}
