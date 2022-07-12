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

using System;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Runtime.Serialization;
using Jodo.Numerics;
using Jodo.Primitives;
using Jodo.Primitives.Compatibility;

namespace Jodo.CheckedNumerics
{
    [Serializable]
    [DebuggerDisplay("{ToString(),nq}")]
    [SuppressMessage("Style", "IDE1006:Naming Styles")]
    [SuppressMessage("csharpsquid", "S101")]
    public readonly struct cdecimal : INumericExtended<cdecimal>
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

        [CLSCompliant(false)] public static implicit operator cdecimal(sbyte value) => new cdecimal(value);
        [CLSCompliant(false)] public static implicit operator cdecimal(uint value) => new cdecimal(value);
        [CLSCompliant(false)] public static implicit operator cdecimal(ulong value) => new cdecimal(value);
        [CLSCompliant(false)] public static implicit operator cdecimal(ushort value) => new cdecimal(value);
        public static explicit operator cdecimal(double value) => new cdecimal(NumericConvert.ToDecimal(value, Conversion.CastClamp));
        public static explicit operator cdecimal(float value) => new cdecimal(NumericConvert.ToDecimal(value, Conversion.CastClamp));
        public static implicit operator cdecimal(byte value) => new cdecimal(value);
        public static implicit operator cdecimal(decimal value) => new cdecimal(value);
        public static implicit operator cdecimal(int value) => new cdecimal(value);
        public static implicit operator cdecimal(long value) => new cdecimal(value);
        public static implicit operator cdecimal(short value) => new cdecimal(value);

        [CLSCompliant(false)] public static explicit operator sbyte(cdecimal value) => NumericConvert.ToSByte(value._value, Conversion.CastClamp);
        [CLSCompliant(false)] public static explicit operator uint(cdecimal value) => NumericConvert.ToUInt32(value._value, Conversion.CastClamp);
        [CLSCompliant(false)] public static explicit operator ulong(cdecimal value) => NumericConvert.ToUInt64(value._value, Conversion.CastClamp);
        [CLSCompliant(false)] public static explicit operator ushort(cdecimal value) => NumericConvert.ToUInt16(value._value, Conversion.CastClamp);
        public static explicit operator byte(cdecimal value) => NumericConvert.ToByte(value._value, Conversion.CastClamp);
        public static explicit operator double(cdecimal value) => NumericConvert.ToDouble(value._value, Conversion.CastClamp);
        public static explicit operator float(cdecimal value) => NumericConvert.ToSingle(value._value, Conversion.CastClamp);
        public static explicit operator int(cdecimal value) => NumericConvert.ToInt32(value._value, Conversion.CastClamp);
        public static explicit operator long(cdecimal value) => NumericConvert.ToInt64(value._value, Conversion.CastClamp);
        public static explicit operator short(cdecimal value) => NumericConvert.ToInt16(value._value, Conversion.CastClamp);
        public static implicit operator decimal(cdecimal value) => value._value;

        public static bool operator !=(cdecimal left, cdecimal right) => left._value != right._value;
        public static bool operator <(cdecimal left, cdecimal right) => left._value < right._value;
        public static bool operator <=(cdecimal left, cdecimal right) => left._value <= right._value;
        public static bool operator ==(cdecimal left, cdecimal right) => left._value == right._value;
        public static bool operator >(cdecimal left, cdecimal right) => left._value > right._value;
        public static bool operator >=(cdecimal left, cdecimal right) => left._value >= right._value;
        public static cdecimal operator %(cdecimal left, cdecimal right) => CheckedArithmetic.Remainder(left._value, right._value);
        public static cdecimal operator &(cdecimal left, cdecimal right) => NumericUtilities.LogicalAnd(left._value, right._value);
        public static cdecimal operator -(cdecimal left, cdecimal right) => CheckedArithmetic.Subtract(left._value, right._value);
        public static cdecimal operator --(cdecimal value) => value - 1;
        public static cdecimal operator -(cdecimal value) => -value._value;
        public static cdecimal operator *(cdecimal left, cdecimal right) => CheckedArithmetic.Multiply(left._value, right._value);
        public static cdecimal operator /(cdecimal left, cdecimal right) => CheckedArithmetic.Divide(left._value, right._value);
        public static cdecimal operator ^(cdecimal left, cdecimal right) => NumericUtilities.LogicalExclusiveOr(left._value, right._value);
        public static cdecimal operator |(cdecimal left, cdecimal right) => NumericUtilities.LogicalOr(left._value, right._value);
        public static cdecimal operator ~(cdecimal left) => NumericUtilities.BitwiseComplement(left._value);
        public static cdecimal operator +(cdecimal left, cdecimal right) => CheckedArithmetic.Add(left._value, right._value);
        public static cdecimal operator +(cdecimal value) => value;
        public static cdecimal operator ++(cdecimal value) => value + 1;
        public static cdecimal operator <<(cdecimal left, int right) => NumericUtilities.LeftShift(left._value, right);
        public static cdecimal operator >>(cdecimal left, int right) => NumericUtilities.RightShift(left._value, right);

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
        IConvert<cdecimal> IProvider<IConvert<cdecimal>>.GetInstance() => Utilities.Instance;
        IConvertUnsigned<cdecimal> IProvider<IConvertUnsigned<cdecimal>>.GetInstance() => Utilities.Instance;
        IMath<cdecimal> IProvider<IMath<cdecimal>>.GetInstance() => Utilities.Instance;
        INumericStatic<cdecimal> IProvider<INumericStatic<cdecimal>>.GetInstance() => Utilities.Instance;
        IRandom<cdecimal> IProvider<IRandom<cdecimal>>.GetInstance() => Utilities.Instance;
        IParser<cdecimal> IProvider<IParser<cdecimal>>.GetInstance() => Utilities.Instance;

        private sealed class Utilities :
            IBitConverter<cdecimal>,
            IConvert<cdecimal>,
            IConvertUnsigned<cdecimal>,
            IMath<cdecimal>,
            INumericStatic<cdecimal>,
            IRandom<cdecimal>,
            IParser<cdecimal>
        {
            public static readonly Utilities Instance = new Utilities();

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

            cdecimal IMath<cdecimal>.Abs(cdecimal value) => Math.Abs(value._value);
            cdecimal IMath<cdecimal>.Acos(cdecimal x) => NumericConvert.ToDecimal(Math.Acos(NumericConvert.ToDouble(x._value, Conversion.CastClamp)), Conversion.CastClamp);
            cdecimal IMath<cdecimal>.Acosh(cdecimal x) => NumericConvert.ToDecimal(MathCompat.Acosh(NumericConvert.ToDouble(x._value, Conversion.CastClamp)), Conversion.CastClamp);
            cdecimal IMath<cdecimal>.Asin(cdecimal x) => NumericConvert.ToDecimal(Math.Asin(NumericConvert.ToDouble(x._value, Conversion.CastClamp)), Conversion.CastClamp);
            cdecimal IMath<cdecimal>.Asinh(cdecimal x) => NumericConvert.ToDecimal(MathCompat.Asinh(NumericConvert.ToDouble(x._value, Conversion.CastClamp)), Conversion.CastClamp);
            cdecimal IMath<cdecimal>.Atan(cdecimal x) => NumericConvert.ToDecimal(Math.Atan(NumericConvert.ToDouble(x._value, Conversion.CastClamp)), Conversion.CastClamp);
            cdecimal IMath<cdecimal>.Atan2(cdecimal x, cdecimal y) => NumericConvert.ToDecimal(Math.Atan2(NumericConvert.ToDouble(x._value, Conversion.CastClamp), NumericConvert.ToDouble(y._value, Conversion.CastClamp)), Conversion.CastClamp);
            cdecimal IMath<cdecimal>.Atanh(cdecimal x) => NumericConvert.ToDecimal(MathCompat.Atanh(NumericConvert.ToDouble(x._value, Conversion.CastClamp)), Conversion.CastClamp);
            cdecimal IMath<cdecimal>.Cbrt(cdecimal x) => NumericConvert.ToDecimal(MathCompat.Cbrt(NumericConvert.ToDouble(x._value, Conversion.CastClamp)), Conversion.CastClamp);
            cdecimal IMath<cdecimal>.Ceiling(cdecimal x) => decimal.Ceiling(x._value);
            cdecimal IMath<cdecimal>.Clamp(cdecimal x, cdecimal bound1, cdecimal bound2) => bound1 > bound2 ? Math.Min(bound1._value, Math.Max(bound2._value, x._value)) : Math.Min(bound2._value, Math.Max(bound1._value, x._value));
            cdecimal IMath<cdecimal>.Cos(cdecimal x) => NumericConvert.ToDecimal(Math.Cos(NumericConvert.ToDouble(x._value, Conversion.CastClamp)), Conversion.CastClamp);
            cdecimal IMath<cdecimal>.Cosh(cdecimal x) => NumericConvert.ToDecimal(Math.Cosh(NumericConvert.ToDouble(x._value, Conversion.CastClamp)), Conversion.CastClamp);
            cdecimal IMath<cdecimal>.DegreesToRadians(cdecimal degrees) => degrees * NumericUtilities.RadiansPerDegreeM;
            cdecimal IMath<cdecimal>.E { get; } = (decimal)Math.E;
            cdecimal IMath<cdecimal>.Exp(cdecimal x) => NumericConvert.ToDecimal(Math.Exp(NumericConvert.ToDouble(x._value, Conversion.CastClamp)), Conversion.CastClamp);
            cdecimal IMath<cdecimal>.Floor(cdecimal x) => decimal.Floor(x._value);
            cdecimal IMath<cdecimal>.IEEERemainder(cdecimal x, cdecimal y) => NumericConvert.ToDecimal(Math.IEEERemainder(NumericConvert.ToDouble(x._value, Conversion.CastClamp), NumericConvert.ToDouble(y._value, Conversion.CastClamp)), Conversion.CastClamp);
            cdecimal IMath<cdecimal>.Log(cdecimal x) => NumericConvert.ToDecimal(Math.Log(NumericConvert.ToDouble(x._value, Conversion.CastClamp)), Conversion.CastClamp);
            cdecimal IMath<cdecimal>.Log(cdecimal x, cdecimal y) => NumericConvert.ToDecimal(Math.Log(NumericConvert.ToDouble(x._value, Conversion.CastClamp), NumericConvert.ToDouble(y._value, Conversion.CastClamp)), Conversion.CastClamp);
            cdecimal IMath<cdecimal>.Log10(cdecimal x) => NumericConvert.ToDecimal(Math.Log10(NumericConvert.ToDouble(x._value, Conversion.CastClamp)), Conversion.CastClamp);
            cdecimal IMath<cdecimal>.Max(cdecimal x, cdecimal y) => Math.Max(x._value, y._value);
            cdecimal IMath<cdecimal>.Min(cdecimal x, cdecimal y) => Math.Min(x._value, y._value);
            cdecimal IMath<cdecimal>.PI { get; } = (decimal)Math.PI;
            cdecimal IMath<cdecimal>.Pow(cdecimal x, cdecimal y) => y == 1 ? x : (cdecimal)NumericConvert.ToDecimal(Math.Pow(NumericConvert.ToDouble(x._value, Conversion.CastClamp), NumericConvert.ToDouble(y._value, Conversion.CastClamp)), Conversion.CastClamp);
            cdecimal IMath<cdecimal>.RadiansToDegrees(cdecimal radians) => radians * NumericUtilities.DegreesPerRadianM;
            cdecimal IMath<cdecimal>.Round(cdecimal x) => decimal.Round(x);
            cdecimal IMath<cdecimal>.Round(cdecimal x, int digits) => decimal.Round(x, digits);
            cdecimal IMath<cdecimal>.Round(cdecimal x, int digits, MidpointRounding mode) => decimal.Round(x, digits, mode);
            cdecimal IMath<cdecimal>.Round(cdecimal x, MidpointRounding mode) => decimal.Round(x, mode);
            cdecimal IMath<cdecimal>.Sin(cdecimal x) => NumericConvert.ToDecimal(Math.Sin(NumericConvert.ToDouble(x._value, Conversion.CastClamp)), Conversion.CastClamp);
            cdecimal IMath<cdecimal>.Sinh(cdecimal x) => NumericConvert.ToDecimal(Math.Sinh(NumericConvert.ToDouble(x._value, Conversion.CastClamp)), Conversion.CastClamp);
            cdecimal IMath<cdecimal>.Sqrt(cdecimal x) => NumericConvert.ToDecimal(Math.Sqrt(NumericConvert.ToDouble(x._value, Conversion.CastClamp)), Conversion.CastClamp);
            cdecimal IMath<cdecimal>.Tan(cdecimal x) => NumericConvert.ToDecimal(Math.Tan(NumericConvert.ToDouble(x._value, Conversion.CastClamp)), Conversion.CastClamp);
            cdecimal IMath<cdecimal>.Tanh(cdecimal x) => NumericConvert.ToDecimal(Math.Tanh(NumericConvert.ToDouble(x._value, Conversion.CastClamp)), Conversion.CastClamp);
            cdecimal IMath<cdecimal>.Tau { get; } = (decimal)Math.PI * 2m;
            cdecimal IMath<cdecimal>.Truncate(cdecimal x) => decimal.Truncate(x._value);
            int IMath<cdecimal>.Sign(cdecimal x) => Math.Sign(x._value);

            cdecimal IBitConverter<cdecimal>.Read(IReadOnlyStream<byte> stream)
            {
                int part0 = BitConverter.ToInt32(stream.Read(sizeof(int)), 0);
                int part1 = BitConverter.ToInt32(stream.Read(sizeof(int)), 0);
                int part2 = BitConverter.ToInt32(stream.Read(sizeof(int)), 0);
                int part3 = BitConverter.ToInt32(stream.Read(sizeof(int)), 0);

                bool sign = (part3 & 0x80000000) != 0;
                byte scale = (byte)((part3 >> 16) & 0x7F);

                return new decimal(part0, part1, part2, sign, scale);
            }

            void IBitConverter<cdecimal>.Write(cdecimal value, IWriteOnlyStream<byte> stream)
            {
                int[]? parts = decimal.GetBits(value);
                stream.Write(BitConverter.GetBytes(parts[0]));
                stream.Write(BitConverter.GetBytes(parts[1]));
                stream.Write(BitConverter.GetBytes(parts[2]));
                stream.Write(BitConverter.GetBytes(parts[3]));
            }

            cdecimal IRandom<cdecimal>.Next(Random random) => random.NextDecimal(decimal.MinValue, decimal.MaxValue);
            cdecimal IRandom<cdecimal>.Next(Random random, cdecimal bound1, cdecimal bound2) => random.NextDecimal(bound1._value, bound2._value);

            bool IConvert<cdecimal>.ToBoolean(cdecimal value) => value._value != 0m;
            byte IConvert<cdecimal>.ToByte(cdecimal value, Conversion mode) => NumericConvert.ToByte(value._value, mode.Clamped());
            decimal IConvert<cdecimal>.ToDecimal(cdecimal value, Conversion mode) => value._value;
            double IConvert<cdecimal>.ToDouble(cdecimal value, Conversion mode) => NumericConvert.ToDouble(value._value, mode.Clamped());
            float IConvert<cdecimal>.ToSingle(cdecimal value, Conversion mode) => NumericConvert.ToSingle(value._value, mode.Clamped());
            int IConvert<cdecimal>.ToInt32(cdecimal value, Conversion mode) => NumericConvert.ToInt32(value._value, mode.Clamped());
            long IConvert<cdecimal>.ToInt64(cdecimal value, Conversion mode) => NumericConvert.ToInt64(value._value, mode.Clamped());
            sbyte IConvertUnsigned<cdecimal>.ToSByte(cdecimal value, Conversion mode) => NumericConvert.ToSByte(value._value, mode.Clamped());
            short IConvert<cdecimal>.ToInt16(cdecimal value, Conversion mode) => NumericConvert.ToInt16(value._value, mode.Clamped());
            string IConvert<cdecimal>.ToString(cdecimal value) => Convert.ToString(value._value);
            uint IConvertUnsigned<cdecimal>.ToUInt32(cdecimal value, Conversion mode) => NumericConvert.ToUInt32(value._value, mode.Clamped());
            ulong IConvertUnsigned<cdecimal>.ToUInt64(cdecimal value, Conversion mode) => NumericConvert.ToUInt64(value._value, mode.Clamped());
            ushort IConvertUnsigned<cdecimal>.ToUInt16(cdecimal value, Conversion mode) => NumericConvert.ToUInt16(value._value, mode.Clamped());

            cdecimal IConvert<cdecimal>.ToValue(bool value) => new cdecimal(value ? 1m : 0m);
            cdecimal IConvert<cdecimal>.ToValue(byte value, Conversion mode) => NumericConvert.ToDecimal(value, mode.Clamped());
            cdecimal IConvert<cdecimal>.ToValue(decimal value, Conversion mode) => value;
            cdecimal IConvert<cdecimal>.ToValue(double value, Conversion mode) => NumericConvert.ToDecimal(value, mode.Clamped());
            cdecimal IConvert<cdecimal>.ToValue(float value, Conversion mode) => NumericConvert.ToDecimal(value, mode.Clamped());
            cdecimal IConvert<cdecimal>.ToValue(int value, Conversion mode) => NumericConvert.ToDecimal(value, mode.Clamped());
            cdecimal IConvert<cdecimal>.ToValue(long value, Conversion mode) => NumericConvert.ToDecimal(value, mode.Clamped());
            cdecimal IConvertUnsigned<cdecimal>.ToValue(sbyte value, Conversion mode) => NumericConvert.ToDecimal(value, mode.Clamped());
            cdecimal IConvert<cdecimal>.ToValue(short value, Conversion mode) => NumericConvert.ToDecimal(value, mode.Clamped());
            cdecimal IConvert<cdecimal>.ToValue(string value) => Convert.ToDecimal(value);
            cdecimal IConvertUnsigned<cdecimal>.ToNumeric(uint value, Conversion mode) => NumericConvert.ToDecimal(value, mode.Clamped());
            cdecimal IConvertUnsigned<cdecimal>.ToNumeric(ulong value, Conversion mode) => NumericConvert.ToDecimal(value, mode.Clamped());
            cdecimal IConvertUnsigned<cdecimal>.ToNumeric(ushort value, Conversion mode) => NumericConvert.ToDecimal(value, mode.Clamped());

            cdecimal IParser<cdecimal>.Parse(string s) => Parse(s);
            cdecimal IParser<cdecimal>.Parse(string s, NumberStyles style, IFormatProvider? provider) => Parse(s, style, provider);
        }
    }
}
