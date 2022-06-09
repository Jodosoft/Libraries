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
    public readonly struct xdecimal : INumeric<xdecimal>
    {
        public static readonly xdecimal MaxValue = new xdecimal(decimal.MaxValue);
        public static readonly xdecimal MinValue = new xdecimal(decimal.MinValue);

        private readonly decimal _value;

        private xdecimal(decimal value)
        {
            _value = value;
        }

        private xdecimal(SerializationInfo info, StreamingContext context) : this(info.GetDecimal(nameof(xdecimal))) { }
        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context) => info.AddValue(nameof(xdecimal), _value);

        public int CompareTo(xdecimal other) => _value.CompareTo(other._value);
        public int CompareTo(object? obj) => obj is xdecimal other ? CompareTo(other) : 1;
        public bool Equals(xdecimal other) => _value == other._value;
        public override bool Equals(object? obj) => obj is xdecimal other && Equals(other);
        public override int GetHashCode() => _value.GetHashCode();
        public override string ToString() => _value.ToString();
        public string ToString(IFormatProvider formatProvider) => _value.ToString(formatProvider);
        public string ToString(string format) => _value.ToString(format);
        public string ToString(string? format, IFormatProvider? formatProvider) => _value.ToString(format, formatProvider);

        public static bool TryParse(string s, IFormatProvider? provider, out xdecimal result) => Try.Run(() => Parse(s, provider), out result);
        public static bool TryParse(string s, NumberStyles style, IFormatProvider? provider, out xdecimal result) => Try.Run(() => Parse(s, style, provider), out result);
        public static bool TryParse(string s, NumberStyles style, out xdecimal result) => Try.Run(() => Parse(s, style), out result);
        public static bool TryParse(string s, out xdecimal result) => Try.Run(() => Parse(s), out result);
        public static xdecimal Parse(string s) => decimal.Parse(s);
        public static xdecimal Parse(string s, IFormatProvider? provider) => decimal.Parse(s, provider);
        public static xdecimal Parse(string s, NumberStyles style) => decimal.Parse(s, style);
        public static xdecimal Parse(string s, NumberStyles style, IFormatProvider? provider) => decimal.Parse(s, style, provider);

        public static explicit operator xdecimal(double value) => new xdecimal((decimal)value);
        public static explicit operator xdecimal(float value) => new xdecimal((decimal)value);
        public static implicit operator xdecimal(byte value) => new xdecimal(value);
        public static implicit operator xdecimal(decimal value) => new xdecimal(value);
        public static implicit operator xdecimal(int value) => new xdecimal(value);
        public static implicit operator xdecimal(long value) => new xdecimal(value);
        public static implicit operator xdecimal(sbyte value) => new xdecimal(value);
        public static implicit operator xdecimal(short value) => new xdecimal(value);
        public static implicit operator xdecimal(uint value) => new xdecimal(value);
        public static implicit operator xdecimal(ulong value) => new xdecimal(value);
        public static implicit operator xdecimal(ushort value) => new xdecimal(value);

        public static explicit operator byte(xdecimal value) => (byte)value._value;
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
        public static xdecimal operator &(xdecimal left, xdecimal right) => NumericUtilities.LogicalAnd(left._value, right._value);
        public static xdecimal operator -(xdecimal left, xdecimal right) => left._value - right._value;
        public static xdecimal operator --(xdecimal value) => value._value - 1;
        public static xdecimal operator -(xdecimal value) => -value._value;
        public static xdecimal operator *(xdecimal left, xdecimal right) => left._value * right._value;
        public static xdecimal operator /(xdecimal left, xdecimal right) => left._value / right._value;
        public static xdecimal operator ^(xdecimal left, xdecimal right) => NumericUtilities.LogicalExclusiveOr(left._value, right._value);
        public static xdecimal operator |(xdecimal left, xdecimal right) => NumericUtilities.LogicalOr(left._value, right._value);
        public static xdecimal operator ~(xdecimal left) => NumericUtilities.BitwiseComplement(left._value);
        public static xdecimal operator +(xdecimal left, xdecimal right) => left._value + right._value;
        public static xdecimal operator +(xdecimal value) => value;
        public static xdecimal operator ++(xdecimal value) => value._value + 1;
        public static xdecimal operator <<(xdecimal left, int right) => NumericUtilities.LeftShift(left._value, right);
        public static xdecimal operator >>(xdecimal left, int right) => NumericUtilities.RightShift(left._value, right);

        bool INumeric<xdecimal>.IsGreaterThan(xdecimal value) => this > value;
        bool INumeric<xdecimal>.IsGreaterThanOrEqualTo(xdecimal value) => this >= value;
        bool INumeric<xdecimal>.IsLessThan(xdecimal value) => this < value;
        bool INumeric<xdecimal>.IsLessThanOrEqualTo(xdecimal value) => this <= value;
        xdecimal INumeric<xdecimal>.Add(xdecimal value) => this + value;
        xdecimal INumeric<xdecimal>.BitwiseComplement() => ~this;
        xdecimal INumeric<xdecimal>.Divide(xdecimal value) => this / value;
        xdecimal INumeric<xdecimal>.LeftShift(int count) => this << count;
        xdecimal INumeric<xdecimal>.LogicalAnd(xdecimal value) => this & value;
        xdecimal INumeric<xdecimal>.LogicalExclusiveOr(xdecimal value) => this ^ value;
        xdecimal INumeric<xdecimal>.LogicalOr(xdecimal value) => this | value;
        xdecimal INumeric<xdecimal>.Multiply(xdecimal value) => this * value;
        xdecimal INumeric<xdecimal>.Negative() => -this;
        xdecimal INumeric<xdecimal>.Positive() => +this;
        xdecimal INumeric<xdecimal>.Remainder(xdecimal value) => this % value;
        xdecimal INumeric<xdecimal>.RightShift(int count) => this >> count;
        xdecimal INumeric<xdecimal>.Subtract(xdecimal value) => this - value;

        IBitConverter<xdecimal> IProvider<IBitConverter<xdecimal>>.GetInstance() => Utilities.Instance;
        ICast<xdecimal> IProvider<ICast<xdecimal>>.GetInstance() => Utilities.Instance;
        IConvert<xdecimal> IProvider<IConvert<xdecimal>>.GetInstance() => Utilities.Instance;
        IMath<xdecimal> IProvider<IMath<xdecimal>>.GetInstance() => Utilities.Instance;
        INumericStatic<xdecimal> IProvider<INumericStatic<xdecimal>>.GetInstance() => Utilities.Instance;
        IRandom<xdecimal> IProvider<IRandom<xdecimal>>.GetInstance() => Utilities.Instance;
        IStringParser<xdecimal> IProvider<IStringParser<xdecimal>>.GetInstance() => Utilities.Instance;

        private sealed class Utilities :
            IBitConverter<xdecimal>,
            ICast<xdecimal>,
            IConvert<xdecimal>,
            IMath<xdecimal>,
            INumericStatic<xdecimal>,
            IRandom<xdecimal>,
            IStringParser<xdecimal>
        {
            public readonly static Utilities Instance = new Utilities();

            bool INumericStatic<xdecimal>.HasFloatingPoint { get; } = true;
            bool INumericStatic<xdecimal>.HasInfinity { get; } = false;
            bool INumericStatic<xdecimal>.HasNaN { get; } = false;
            bool INumericStatic<xdecimal>.IsFinite(xdecimal x) => true;
            bool INumericStatic<xdecimal>.IsInfinity(xdecimal x) => false;
            bool INumericStatic<xdecimal>.IsNaN(xdecimal x) => false;
            bool INumericStatic<xdecimal>.IsNegative(xdecimal x) => x._value < 0;
            bool INumericStatic<xdecimal>.IsNegativeInfinity(xdecimal x) => false;
            bool INumericStatic<xdecimal>.IsNormal(xdecimal x) => false;
            bool INumericStatic<xdecimal>.IsPositiveInfinity(xdecimal x) => false;
            bool INumericStatic<xdecimal>.IsReal { get; } = true;
            bool INumericStatic<xdecimal>.IsSigned { get; } = true;
            bool INumericStatic<xdecimal>.IsSubnormal(xdecimal x) => false;
            xdecimal INumericStatic<xdecimal>.Epsilon { get; } = new decimal(1, 0, 0, false, 28);
            xdecimal INumericStatic<xdecimal>.MaxUnit { get; } = 1m;
            xdecimal INumericStatic<xdecimal>.MaxValue => MaxValue;
            xdecimal INumericStatic<xdecimal>.MinUnit { get; } = -1m;
            xdecimal INumericStatic<xdecimal>.MinValue => MinValue;
            xdecimal INumericStatic<xdecimal>.One { get; } = 1m;
            xdecimal INumericStatic<xdecimal>.Ten { get; } = 10m;
            xdecimal INumericStatic<xdecimal>.Two { get; } = 2m;
            xdecimal INumericStatic<xdecimal>.Zero { get; } = 0m;

            int IMath<xdecimal>.Sign(xdecimal x) => Math.Sign(x);
            xdecimal IMath<xdecimal>.Abs(xdecimal x) => Math.Abs(x);
            xdecimal IMath<xdecimal>.Acos(xdecimal x) => (xdecimal)Math.Acos((double)x);
            xdecimal IMath<xdecimal>.Acosh(xdecimal x) => (xdecimal)Math.Acosh((double)x);
            xdecimal IMath<xdecimal>.Asin(xdecimal x) => (xdecimal)Math.Asin((double)x);
            xdecimal IMath<xdecimal>.Asinh(xdecimal x) => (xdecimal)Math.Asinh((double)x);
            xdecimal IMath<xdecimal>.Atan(xdecimal x) => (xdecimal)Math.Atan((double)x);
            xdecimal IMath<xdecimal>.Atan2(xdecimal x, xdecimal y) => (xdecimal)Math.Atan2((double)x, (double)y);
            xdecimal IMath<xdecimal>.Atanh(xdecimal x) => (xdecimal)Math.Atanh((double)x);
            xdecimal IMath<xdecimal>.Cbrt(xdecimal x) => (xdecimal)Math.Cbrt((double)x);
            xdecimal IMath<xdecimal>.Ceiling(xdecimal x) => decimal.Ceiling(x);
            xdecimal IMath<xdecimal>.Clamp(xdecimal x, xdecimal bound1, xdecimal bound2) => bound1 > bound2 ? Math.Min(bound1, Math.Max(bound2, x)) : Math.Min(bound2, Math.Max(bound1, x));
            xdecimal IMath<xdecimal>.Cos(xdecimal x) => (xdecimal)Math.Cos((double)x);
            xdecimal IMath<xdecimal>.Cosh(xdecimal x) => (xdecimal)Math.Cosh((double)x);
            xdecimal IMath<xdecimal>.DegreesToRadians(xdecimal degrees) => degrees * NumericUtilities.RadiansPerDegreeM;
            xdecimal IMath<xdecimal>.E { get; } = (xdecimal)Math.E;
            xdecimal IMath<xdecimal>.Exp(xdecimal x) => (xdecimal)Math.Exp((double)x);
            xdecimal IMath<xdecimal>.Floor(xdecimal x) => decimal.Floor(x);
            xdecimal IMath<xdecimal>.IEEERemainder(xdecimal x, xdecimal y) => (xdecimal)Math.IEEERemainder((double)x, (double)y);
            xdecimal IMath<xdecimal>.Log(xdecimal x) => (xdecimal)Math.Log((double)x);
            xdecimal IMath<xdecimal>.Log(xdecimal x, xdecimal y) => (xdecimal)Math.Log((double)x, (double)y);
            xdecimal IMath<xdecimal>.Log10(xdecimal x) => (xdecimal)Math.Log10((double)x);
            xdecimal IMath<xdecimal>.Max(xdecimal x, xdecimal y) => Math.Max(x, y);
            xdecimal IMath<xdecimal>.Min(xdecimal x, xdecimal y) => Math.Min(x, y);
            xdecimal IMath<xdecimal>.PI { get; } = (xdecimal)Math.PI;
            xdecimal IMath<xdecimal>.Pow(xdecimal x, xdecimal y) => y == 1 ? x : (xdecimal)Math.Pow((double)x, (double)y);
            xdecimal IMath<xdecimal>.RadiansToDegrees(xdecimal radians) => radians * NumericUtilities.DegreesPerRadianM;
            xdecimal IMath<xdecimal>.Round(xdecimal x) => decimal.Round(x);
            xdecimal IMath<xdecimal>.Round(xdecimal x, int digits) => decimal.Round(x, digits);
            xdecimal IMath<xdecimal>.Round(xdecimal x, int digits, MidpointRounding mode) => decimal.Round(x, digits, mode);
            xdecimal IMath<xdecimal>.Round(xdecimal x, MidpointRounding mode) => decimal.Round(x, mode);
            xdecimal IMath<xdecimal>.Sin(xdecimal x) => (xdecimal)Math.Sin((double)x);
            xdecimal IMath<xdecimal>.Sinh(xdecimal x) => (xdecimal)Math.Sinh((double)x);
            xdecimal IMath<xdecimal>.Sqrt(xdecimal x) => (xdecimal)Math.Sqrt((double)x);
            xdecimal IMath<xdecimal>.Tan(xdecimal x) => (xdecimal)Math.Tan((double)x);
            xdecimal IMath<xdecimal>.Tanh(xdecimal x) => (xdecimal)Math.Tanh((double)x);
            xdecimal IMath<xdecimal>.Tau { get; } = (xdecimal)Math.PI * 2m;
            xdecimal IMath<xdecimal>.Truncate(xdecimal x) => decimal.Truncate(x);

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

            bool IConvert<xdecimal>.ToBoolean(xdecimal value) => Convert.ToBoolean(value._value);
            byte IConvert<xdecimal>.ToByte(xdecimal value) => Convert.ToByte(value._value);
            decimal IConvert<xdecimal>.ToDecimal(xdecimal value) => value;
            double IConvert<xdecimal>.ToDouble(xdecimal value) => Convert.ToDouble(value._value);
            float IConvert<xdecimal>.ToSingle(xdecimal value) => Convert.ToSingle(value._value);
            int IConvert<xdecimal>.ToInt32(xdecimal value) => Convert.ToInt32(value._value);
            long IConvert<xdecimal>.ToInt64(xdecimal value) => Convert.ToInt64(value._value);
            sbyte IConvert<xdecimal>.ToSByte(xdecimal value) => Convert.ToSByte(value._value);
            short IConvert<xdecimal>.ToInt16(xdecimal value) => Convert.ToInt16(value._value);
            string IConvert<xdecimal>.ToString(xdecimal value) => Convert.ToString(value._value);
            uint IConvert<xdecimal>.ToUInt32(xdecimal value) => Convert.ToUInt32(value._value);
            ulong IConvert<xdecimal>.ToUInt64(xdecimal value) => Convert.ToUInt64(value._value);
            ushort IConvert<xdecimal>.ToUInt16(xdecimal value) => Convert.ToUInt16(value._value);

            xdecimal IConvert<xdecimal>.ToNumeric(bool value) => Convert.ToDecimal(value);
            xdecimal IConvert<xdecimal>.ToNumeric(byte value) => Convert.ToDecimal(value);
            xdecimal IConvert<xdecimal>.ToNumeric(decimal value) => value;
            xdecimal IConvert<xdecimal>.ToNumeric(double value) => Convert.ToDecimal(value);
            xdecimal IConvert<xdecimal>.ToNumeric(float value) => Convert.ToDecimal(value);
            xdecimal IConvert<xdecimal>.ToNumeric(int value) => Convert.ToDecimal(value);
            xdecimal IConvert<xdecimal>.ToNumeric(long value) => Convert.ToDecimal(value);
            xdecimal IConvert<xdecimal>.ToNumeric(sbyte value) => Convert.ToDecimal(value);
            xdecimal IConvert<xdecimal>.ToNumeric(short value) => Convert.ToDecimal(value);
            xdecimal IConvert<xdecimal>.ToNumeric(string value) => Convert.ToDecimal(value);
            xdecimal IConvert<xdecimal>.ToNumeric(uint value) => Convert.ToDecimal(value);
            xdecimal IConvert<xdecimal>.ToNumeric(ulong value) => Convert.ToDecimal(value);
            xdecimal IConvert<xdecimal>.ToNumeric(ushort value) => Convert.ToDecimal(value);

            xdecimal IStringParser<xdecimal>.Parse(string s) => Parse(s);
            xdecimal IStringParser<xdecimal>.Parse(string s, NumberStyles style, IFormatProvider? provider) => Parse(s, style, provider);

            byte ICast<xdecimal>.ToByte(xdecimal value) => (byte)value;
            decimal ICast<xdecimal>.ToDecimal(xdecimal value) => (decimal)value;
            double ICast<xdecimal>.ToDouble(xdecimal value) => (double)value;
            float ICast<xdecimal>.ToSingle(xdecimal value) => (float)value;
            int ICast<xdecimal>.ToInt32(xdecimal value) => (int)value;
            long ICast<xdecimal>.ToInt64(xdecimal value) => (long)value;
            sbyte ICast<xdecimal>.ToSByte(xdecimal value) => (sbyte)value;
            short ICast<xdecimal>.ToInt16(xdecimal value) => (short)value;
            uint ICast<xdecimal>.ToUInt32(xdecimal value) => (uint)value;
            ulong ICast<xdecimal>.ToUInt64(xdecimal value) => (ulong)value;
            ushort ICast<xdecimal>.ToUInt16(xdecimal value) => (ushort)value;

            xdecimal ICast<xdecimal>.ToNumeric(byte value) => (xdecimal)value;
            xdecimal ICast<xdecimal>.ToNumeric(decimal value) => (xdecimal)value;
            xdecimal ICast<xdecimal>.ToNumeric(double value) => (xdecimal)value;
            xdecimal ICast<xdecimal>.ToNumeric(float value) => (xdecimal)value;
            xdecimal ICast<xdecimal>.ToNumeric(int value) => (xdecimal)value;
            xdecimal ICast<xdecimal>.ToNumeric(long value) => (xdecimal)value;
            xdecimal ICast<xdecimal>.ToNumeric(sbyte value) => (xdecimal)value;
            xdecimal ICast<xdecimal>.ToNumeric(short value) => (xdecimal)value;
            xdecimal ICast<xdecimal>.ToNumeric(uint value) => (xdecimal)value;
            xdecimal ICast<xdecimal>.ToNumeric(ulong value) => (xdecimal)value;
            xdecimal ICast<xdecimal>.ToNumeric(ushort value) => (xdecimal)value;
        }
    }
}
