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
using System.Globalization;
using System.Runtime.Serialization;
using Jodo.Numerics;
using Jodo.Primitives;
using Jodo.Primitives.Compatibility;

namespace Jodo.CheckedNumerics
{
    /// <summary>
    /// Represents a decimal floating-point number that cannot overflow.
    /// </summary>
    [Serializable]
    [DebuggerDisplay("{ToString(),nq}")]
    public readonly struct DecimalC : INumericExtended<DecimalC>
    {
        public static readonly DecimalC MaxValue = new DecimalC(decimal.MaxValue);
        public static readonly DecimalC MinValue = new DecimalC(decimal.MinValue);

        private readonly decimal _value;

        public DecimalC(decimal value)
        {
            _value = value;
        }

        private DecimalC(SerializationInfo info, StreamingContext context) : this(info.GetDecimal(nameof(DecimalC))) { }
        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context) => info.AddValue(nameof(DecimalC), _value);

        public int CompareTo(DecimalC other) => _value.CompareTo(other._value);
        public int CompareTo(object? obj) => obj is DecimalC other ? CompareTo(other) : 1;
        public bool Equals(DecimalC other) => _value == other._value;
        public override bool Equals(object? obj) => obj is DecimalC other && Equals(other);
        public override int GetHashCode() => _value.GetHashCode();
        public override string ToString() => _value.ToString();
        public string ToString(IFormatProvider formatProvider) => _value.ToString(formatProvider);
        public string ToString(string format) => _value.ToString(format);
        public string ToString(string? format, IFormatProvider? formatProvider) => _value.ToString(format, formatProvider);

        public static bool TryParse(string s, IFormatProvider? provider, out DecimalC result) => Try.Run(() => Parse(s, provider), out result);
        public static bool TryParse(string s, NumberStyles style, IFormatProvider? provider, out DecimalC result) => Try.Run(() => Parse(s, style, provider), out result);
        public static bool TryParse(string s, NumberStyles style, out DecimalC result) => Try.Run(() => Parse(s, style), out result);
        public static bool TryParse(string s, out DecimalC result) => Try.Run(() => Parse(s), out result);
        public static DecimalC Parse(string s) => decimal.Parse(s);
        public static DecimalC Parse(string s, IFormatProvider? provider) => decimal.Parse(s, provider);
        public static DecimalC Parse(string s, NumberStyles style) => decimal.Parse(s, style);
        public static DecimalC Parse(string s, NumberStyles style, IFormatProvider? provider) => decimal.Parse(s, style, provider);

        [CLSCompliant(false)] public static implicit operator DecimalC(sbyte value) => new DecimalC(value);
        [CLSCompliant(false)] public static implicit operator DecimalC(uint value) => new DecimalC(value);
        [CLSCompliant(false)] public static implicit operator DecimalC(ulong value) => new DecimalC(value);
        [CLSCompliant(false)] public static implicit operator DecimalC(ushort value) => new DecimalC(value);
        public static explicit operator DecimalC(double value) => new DecimalC(NumericConvert.ToDecimal(value, Conversion.CastClamp));
        public static explicit operator DecimalC(float value) => new DecimalC(NumericConvert.ToDecimal(value, Conversion.CastClamp));
        public static implicit operator DecimalC(byte value) => new DecimalC(value);
        public static implicit operator DecimalC(decimal value) => new DecimalC(value);
        public static implicit operator DecimalC(int value) => new DecimalC(value);
        public static implicit operator DecimalC(long value) => new DecimalC(value);
        public static implicit operator DecimalC(short value) => new DecimalC(value);

        [CLSCompliant(false)] public static explicit operator sbyte(DecimalC value) => NumericConvert.ToSByte(value._value, Conversion.CastClamp);
        [CLSCompliant(false)] public static explicit operator uint(DecimalC value) => NumericConvert.ToUInt32(value._value, Conversion.CastClamp);
        [CLSCompliant(false)] public static explicit operator ulong(DecimalC value) => NumericConvert.ToUInt64(value._value, Conversion.CastClamp);
        [CLSCompliant(false)] public static explicit operator ushort(DecimalC value) => NumericConvert.ToUInt16(value._value, Conversion.CastClamp);
        public static explicit operator byte(DecimalC value) => NumericConvert.ToByte(value._value, Conversion.CastClamp);
        public static explicit operator double(DecimalC value) => NumericConvert.ToDouble(value._value, Conversion.CastClamp);
        public static explicit operator float(DecimalC value) => NumericConvert.ToSingle(value._value, Conversion.CastClamp);
        public static explicit operator int(DecimalC value) => NumericConvert.ToInt32(value._value, Conversion.CastClamp);
        public static explicit operator long(DecimalC value) => NumericConvert.ToInt64(value._value, Conversion.CastClamp);
        public static explicit operator short(DecimalC value) => NumericConvert.ToInt16(value._value, Conversion.CastClamp);
        public static implicit operator decimal(DecimalC value) => value._value;

        public static bool operator !=(DecimalC left, DecimalC right) => left._value != right._value;
        public static bool operator <(DecimalC left, DecimalC right) => left._value < right._value;
        public static bool operator <=(DecimalC left, DecimalC right) => left._value <= right._value;
        public static bool operator ==(DecimalC left, DecimalC right) => left._value == right._value;
        public static bool operator >(DecimalC left, DecimalC right) => left._value > right._value;
        public static bool operator >=(DecimalC left, DecimalC right) => left._value >= right._value;
        public static DecimalC operator %(DecimalC left, DecimalC right) => CheckedArithmetic.Remainder(left._value, right._value);
        public static DecimalC operator &(DecimalC left, DecimalC right) => NumericUtilities.LogicalAnd(left._value, right._value);
        public static DecimalC operator -(DecimalC left, DecimalC right) => CheckedArithmetic.Subtract(left._value, right._value);
        public static DecimalC operator --(DecimalC value) => value - 1;
        public static DecimalC operator -(DecimalC value) => -value._value;
        public static DecimalC operator *(DecimalC left, DecimalC right) => CheckedArithmetic.Multiply(left._value, right._value);
        public static DecimalC operator /(DecimalC left, DecimalC right) => CheckedArithmetic.Divide(left._value, right._value);
        public static DecimalC operator ^(DecimalC left, DecimalC right) => NumericUtilities.LogicalExclusiveOr(left._value, right._value);
        public static DecimalC operator |(DecimalC left, DecimalC right) => NumericUtilities.LogicalOr(left._value, right._value);
        public static DecimalC operator ~(DecimalC left) => NumericUtilities.BitwiseComplement(left._value);
        public static DecimalC operator +(DecimalC left, DecimalC right) => CheckedArithmetic.Add(left._value, right._value);
        public static DecimalC operator +(DecimalC value) => value;
        public static DecimalC operator ++(DecimalC value) => value + 1;
        public static DecimalC operator <<(DecimalC left, int right) => NumericUtilities.LeftShift(left._value, right);
        public static DecimalC operator >>(DecimalC left, int right) => NumericUtilities.RightShift(left._value, right);

        TypeCode IConvertible.GetTypeCode() => _value.GetTypeCode();
        bool IConvertible.ToBoolean(IFormatProvider provider) => ((IConvertible)_value).ToBoolean(provider);
        char IConvertible.ToChar(IFormatProvider provider) => ((IConvertible)_value).ToChar(provider);
        sbyte IConvertible.ToSByte(IFormatProvider provider) => ((IConvertible)_value).ToSByte(provider);
        byte IConvertible.ToByte(IFormatProvider provider) => ((IConvertible)_value).ToByte(provider);
        short IConvertible.ToInt16(IFormatProvider provider) => ((IConvertible)_value).ToInt16(provider);
        ushort IConvertible.ToUInt16(IFormatProvider provider) => ((IConvertible)_value).ToUInt16(provider);
        int IConvertible.ToInt32(IFormatProvider provider) => ((IConvertible)_value).ToInt32(provider);
        uint IConvertible.ToUInt32(IFormatProvider provider) => ((IConvertible)_value).ToUInt32(provider);
        long IConvertible.ToInt64(IFormatProvider provider) => ((IConvertible)_value).ToInt64(provider);
        ulong IConvertible.ToUInt64(IFormatProvider provider) => ((IConvertible)_value).ToUInt64(provider);
        float IConvertible.ToSingle(IFormatProvider provider) => ((IConvertible)_value).ToSingle(provider);
        double IConvertible.ToDouble(IFormatProvider provider) => ((IConvertible)_value).ToDouble(provider);
        decimal IConvertible.ToDecimal(IFormatProvider provider) => ((IConvertible)_value).ToDecimal(provider);
        DateTime IConvertible.ToDateTime(IFormatProvider provider) => ((IConvertible)_value).ToDateTime(provider);
        object IConvertible.ToType(Type conversionType, IFormatProvider provider) => ((IConvertible)_value).ToType(conversionType, provider);

        bool INumeric<DecimalC>.IsGreaterThan(DecimalC value) => this > value;
        bool INumeric<DecimalC>.IsGreaterThanOrEqualTo(DecimalC value) => this >= value;
        bool INumeric<DecimalC>.IsLessThan(DecimalC value) => this < value;
        bool INumeric<DecimalC>.IsLessThanOrEqualTo(DecimalC value) => this <= value;
        DecimalC INumeric<DecimalC>.Add(DecimalC value) => this + value;
        DecimalC INumeric<DecimalC>.BitwiseComplement() => ~this;
        DecimalC INumeric<DecimalC>.Divide(DecimalC value) => this / value;
        DecimalC INumeric<DecimalC>.LeftShift(int count) => this << count;
        DecimalC INumeric<DecimalC>.LogicalAnd(DecimalC value) => this & value;
        DecimalC INumeric<DecimalC>.LogicalExclusiveOr(DecimalC value) => this ^ value;
        DecimalC INumeric<DecimalC>.LogicalOr(DecimalC value) => this | value;
        DecimalC INumeric<DecimalC>.Multiply(DecimalC value) => this * value;
        DecimalC INumeric<DecimalC>.Negative() => -this;
        DecimalC INumeric<DecimalC>.Positive() => +this;
        DecimalC INumeric<DecimalC>.Remainder(DecimalC value) => this % value;
        DecimalC INumeric<DecimalC>.RightShift(int count) => this >> count;
        DecimalC INumeric<DecimalC>.Subtract(DecimalC value) => this - value;

        IBitConverter<DecimalC> IProvider<IBitConverter<DecimalC>>.GetInstance() => Utilities.Instance;
        IConvert<DecimalC> IProvider<IConvert<DecimalC>>.GetInstance() => Utilities.Instance;
        IConvertExtended<DecimalC> IProvider<IConvertExtended<DecimalC>>.GetInstance() => Utilities.Instance;
        IMath<DecimalC> IProvider<IMath<DecimalC>>.GetInstance() => Utilities.Instance;
        INumericStatic<DecimalC> IProvider<INumericStatic<DecimalC>>.GetInstance() => Utilities.Instance;
        IRandom<DecimalC> IProvider<IRandom<DecimalC>>.GetInstance() => Utilities.Instance;
        IParser<DecimalC> IProvider<IParser<DecimalC>>.GetInstance() => Utilities.Instance;

        private sealed class Utilities :
            IBitConverter<DecimalC>,
            IConvert<DecimalC>,
            IConvertExtended<DecimalC>,
            IMath<DecimalC>,
            INumericStatic<DecimalC>,
            IRandom<DecimalC>,
            IParser<DecimalC>
        {
            public static readonly Utilities Instance = new Utilities();

            bool INumericStatic<DecimalC>.HasFloatingPoint { get; } = true;
            bool INumericStatic<DecimalC>.HasInfinity { get; } = false;
            bool INumericStatic<DecimalC>.HasNaN { get; } = false;
            bool INumericStatic<DecimalC>.IsFinite(DecimalC x) => true;
            bool INumericStatic<DecimalC>.IsInfinity(DecimalC x) => false;
            bool INumericStatic<DecimalC>.IsNaN(DecimalC x) => false;
            bool INumericStatic<DecimalC>.IsNegative(DecimalC x) => x._value < 0;
            bool INumericStatic<DecimalC>.IsNegativeInfinity(DecimalC x) => false;
            bool INumericStatic<DecimalC>.IsNormal(DecimalC x) => false;
            bool INumericStatic<DecimalC>.IsPositiveInfinity(DecimalC x) => false;
            bool INumericStatic<DecimalC>.IsReal { get; } = true;
            bool INumericStatic<DecimalC>.IsSigned { get; } = true;
            bool INumericStatic<DecimalC>.IsSubnormal(DecimalC x) => false;
            DecimalC INumericStatic<DecimalC>.Epsilon { get; } = new decimal(1, 0, 0, false, 28);
            DecimalC INumericStatic<DecimalC>.MaxUnit { get; } = 1m;
            DecimalC INumericStatic<DecimalC>.MaxValue => MaxValue;
            DecimalC INumericStatic<DecimalC>.MinUnit { get; } = -1m;
            DecimalC INumericStatic<DecimalC>.MinValue => MinValue;
            DecimalC INumericStatic<DecimalC>.One { get; } = 1m;
            DecimalC INumericStatic<DecimalC>.Ten { get; } = 10m;
            DecimalC INumericStatic<DecimalC>.Two { get; } = 2m;
            DecimalC INumericStatic<DecimalC>.Zero { get; } = 0m;

            DecimalC IMath<DecimalC>.Abs(DecimalC value) => Math.Abs(value._value);
            DecimalC IMath<DecimalC>.Acos(DecimalC x) => NumericConvert.ToDecimal(Math.Acos(NumericConvert.ToDouble(x._value, Conversion.CastClamp)), Conversion.CastClamp);
            DecimalC IMath<DecimalC>.Acosh(DecimalC x) => NumericConvert.ToDecimal(MathCompat.Acosh(NumericConvert.ToDouble(x._value, Conversion.CastClamp)), Conversion.CastClamp);
            DecimalC IMath<DecimalC>.Asin(DecimalC x) => NumericConvert.ToDecimal(Math.Asin(NumericConvert.ToDouble(x._value, Conversion.CastClamp)), Conversion.CastClamp);
            DecimalC IMath<DecimalC>.Asinh(DecimalC x) => NumericConvert.ToDecimal(MathCompat.Asinh(NumericConvert.ToDouble(x._value, Conversion.CastClamp)), Conversion.CastClamp);
            DecimalC IMath<DecimalC>.Atan(DecimalC x) => NumericConvert.ToDecimal(Math.Atan(NumericConvert.ToDouble(x._value, Conversion.CastClamp)), Conversion.CastClamp);
            DecimalC IMath<DecimalC>.Atan2(DecimalC x, DecimalC y) => NumericConvert.ToDecimal(Math.Atan2(NumericConvert.ToDouble(x._value, Conversion.CastClamp), NumericConvert.ToDouble(y._value, Conversion.CastClamp)), Conversion.CastClamp);
            DecimalC IMath<DecimalC>.Atanh(DecimalC x) => NumericConvert.ToDecimal(MathCompat.Atanh(NumericConvert.ToDouble(x._value, Conversion.CastClamp)), Conversion.CastClamp);
            DecimalC IMath<DecimalC>.Cbrt(DecimalC x) => NumericConvert.ToDecimal(MathCompat.Cbrt(NumericConvert.ToDouble(x._value, Conversion.CastClamp)), Conversion.CastClamp);
            DecimalC IMath<DecimalC>.Ceiling(DecimalC x) => decimal.Ceiling(x._value);
            DecimalC IMath<DecimalC>.Clamp(DecimalC x, DecimalC bound1, DecimalC bound2) => bound1 > bound2 ? Math.Min(bound1._value, Math.Max(bound2._value, x._value)) : Math.Min(bound2._value, Math.Max(bound1._value, x._value));
            DecimalC IMath<DecimalC>.Cos(DecimalC x) => NumericConvert.ToDecimal(Math.Cos(NumericConvert.ToDouble(x._value, Conversion.CastClamp)), Conversion.CastClamp);
            DecimalC IMath<DecimalC>.Cosh(DecimalC x) => NumericConvert.ToDecimal(Math.Cosh(NumericConvert.ToDouble(x._value, Conversion.CastClamp)), Conversion.CastClamp);
            DecimalC IMath<DecimalC>.DegreesToRadians(DecimalC degrees) => degrees * NumericUtilities.RadiansPerDegreeM;
            DecimalC IMath<DecimalC>.E { get; } = (decimal)Math.E;
            DecimalC IMath<DecimalC>.Exp(DecimalC x) => NumericConvert.ToDecimal(Math.Exp(NumericConvert.ToDouble(x._value, Conversion.CastClamp)), Conversion.CastClamp);
            DecimalC IMath<DecimalC>.Floor(DecimalC x) => decimal.Floor(x._value);
            DecimalC IMath<DecimalC>.IEEERemainder(DecimalC x, DecimalC y) => NumericConvert.ToDecimal(Math.IEEERemainder(NumericConvert.ToDouble(x._value, Conversion.CastClamp), NumericConvert.ToDouble(y._value, Conversion.CastClamp)), Conversion.CastClamp);
            DecimalC IMath<DecimalC>.Log(DecimalC x) => NumericConvert.ToDecimal(Math.Log(NumericConvert.ToDouble(x._value, Conversion.CastClamp)), Conversion.CastClamp);
            DecimalC IMath<DecimalC>.Log(DecimalC x, DecimalC y) => NumericConvert.ToDecimal(Math.Log(NumericConvert.ToDouble(x._value, Conversion.CastClamp), NumericConvert.ToDouble(y._value, Conversion.CastClamp)), Conversion.CastClamp);
            DecimalC IMath<DecimalC>.Log10(DecimalC x) => NumericConvert.ToDecimal(Math.Log10(NumericConvert.ToDouble(x._value, Conversion.CastClamp)), Conversion.CastClamp);
            DecimalC IMath<DecimalC>.Max(DecimalC x, DecimalC y) => Math.Max(x._value, y._value);
            DecimalC IMath<DecimalC>.Min(DecimalC x, DecimalC y) => Math.Min(x._value, y._value);
            DecimalC IMath<DecimalC>.PI { get; } = (decimal)Math.PI;
            DecimalC IMath<DecimalC>.Pow(DecimalC x, DecimalC y) => y == 1 ? x : (DecimalC)NumericConvert.ToDecimal(Math.Pow(NumericConvert.ToDouble(x._value, Conversion.CastClamp), NumericConvert.ToDouble(y._value, Conversion.CastClamp)), Conversion.CastClamp);
            DecimalC IMath<DecimalC>.RadiansToDegrees(DecimalC radians) => radians * NumericUtilities.DegreesPerRadianM;
            DecimalC IMath<DecimalC>.Round(DecimalC x) => decimal.Round(x);
            DecimalC IMath<DecimalC>.Round(DecimalC x, int digits) => decimal.Round(x, digits);
            DecimalC IMath<DecimalC>.Round(DecimalC x, int digits, MidpointRounding mode) => decimal.Round(x, digits, mode);
            DecimalC IMath<DecimalC>.Round(DecimalC x, MidpointRounding mode) => decimal.Round(x, mode);
            DecimalC IMath<DecimalC>.Sin(DecimalC x) => NumericConvert.ToDecimal(Math.Sin(NumericConvert.ToDouble(x._value, Conversion.CastClamp)), Conversion.CastClamp);
            DecimalC IMath<DecimalC>.Sinh(DecimalC x) => NumericConvert.ToDecimal(Math.Sinh(NumericConvert.ToDouble(x._value, Conversion.CastClamp)), Conversion.CastClamp);
            DecimalC IMath<DecimalC>.Sqrt(DecimalC x) => NumericConvert.ToDecimal(Math.Sqrt(NumericConvert.ToDouble(x._value, Conversion.CastClamp)), Conversion.CastClamp);
            DecimalC IMath<DecimalC>.Tan(DecimalC x) => NumericConvert.ToDecimal(Math.Tan(NumericConvert.ToDouble(x._value, Conversion.CastClamp)), Conversion.CastClamp);
            DecimalC IMath<DecimalC>.Tanh(DecimalC x) => NumericConvert.ToDecimal(Math.Tanh(NumericConvert.ToDouble(x._value, Conversion.CastClamp)), Conversion.CastClamp);
            DecimalC IMath<DecimalC>.Tau { get; } = (decimal)Math.PI * 2m;
            DecimalC IMath<DecimalC>.Truncate(DecimalC x) => decimal.Truncate(x._value);
            int IMath<DecimalC>.Sign(DecimalC x) => Math.Sign(x._value);

            DecimalC IBitConverter<DecimalC>.Read(IReadOnlyStream<byte> stream)
            {
                int part0 = BitConverter.ToInt32(stream.Read(sizeof(int)), 0);
                int part1 = BitConverter.ToInt32(stream.Read(sizeof(int)), 0);
                int part2 = BitConverter.ToInt32(stream.Read(sizeof(int)), 0);
                int part3 = BitConverter.ToInt32(stream.Read(sizeof(int)), 0);

                bool sign = (part3 & 0x80000000) != 0;
                byte scale = (byte)((part3 >> 16) & 0x7F);

                return new decimal(part0, part1, part2, sign, scale);
            }

            void IBitConverter<DecimalC>.Write(DecimalC value, IWriteOnlyStream<byte> stream)
            {
                int[]? parts = decimal.GetBits(value);
                stream.Write(BitConverter.GetBytes(parts[0]));
                stream.Write(BitConverter.GetBytes(parts[1]));
                stream.Write(BitConverter.GetBytes(parts[2]));
                stream.Write(BitConverter.GetBytes(parts[3]));
            }

            DecimalC IRandom<DecimalC>.Next(Random random) => random.NextDecimal(decimal.MinValue, decimal.MaxValue);
            DecimalC IRandom<DecimalC>.Next(Random random, DecimalC bound1, DecimalC bound2) => random.NextDecimal(bound1._value, bound2._value);

            bool IConvert<DecimalC>.ToBoolean(DecimalC value) => value._value != 0m;
            byte IConvert<DecimalC>.ToByte(DecimalC value, Conversion mode) => NumericConvert.ToByte(value._value, mode.Clamped());
            decimal IConvert<DecimalC>.ToDecimal(DecimalC value, Conversion mode) => value._value;
            double IConvert<DecimalC>.ToDouble(DecimalC value, Conversion mode) => NumericConvert.ToDouble(value._value, mode.Clamped());
            float IConvert<DecimalC>.ToSingle(DecimalC value, Conversion mode) => NumericConvert.ToSingle(value._value, mode.Clamped());
            int IConvert<DecimalC>.ToInt32(DecimalC value, Conversion mode) => NumericConvert.ToInt32(value._value, mode.Clamped());
            long IConvert<DecimalC>.ToInt64(DecimalC value, Conversion mode) => NumericConvert.ToInt64(value._value, mode.Clamped());
            sbyte IConvertExtended<DecimalC>.ToSByte(DecimalC value, Conversion mode) => NumericConvert.ToSByte(value._value, mode.Clamped());
            short IConvert<DecimalC>.ToInt16(DecimalC value, Conversion mode) => NumericConvert.ToInt16(value._value, mode.Clamped());
            string IConvert<DecimalC>.ToString(DecimalC value) => Convert.ToString(value._value);
            uint IConvertExtended<DecimalC>.ToUInt32(DecimalC value, Conversion mode) => NumericConvert.ToUInt32(value._value, mode.Clamped());
            ulong IConvertExtended<DecimalC>.ToUInt64(DecimalC value, Conversion mode) => NumericConvert.ToUInt64(value._value, mode.Clamped());
            ushort IConvertExtended<DecimalC>.ToUInt16(DecimalC value, Conversion mode) => NumericConvert.ToUInt16(value._value, mode.Clamped());

            DecimalC IConvert<DecimalC>.ToNumeric(bool value) => new DecimalC(value ? 1m : 0m);
            DecimalC IConvert<DecimalC>.ToNumeric(byte value, Conversion mode) => NumericConvert.ToDecimal(value, mode.Clamped());
            DecimalC IConvert<DecimalC>.ToNumeric(decimal value, Conversion mode) => value;
            DecimalC IConvert<DecimalC>.ToNumeric(double value, Conversion mode) => NumericConvert.ToDecimal(value, mode.Clamped());
            DecimalC IConvert<DecimalC>.ToNumeric(float value, Conversion mode) => NumericConvert.ToDecimal(value, mode.Clamped());
            DecimalC IConvert<DecimalC>.ToNumeric(int value, Conversion mode) => NumericConvert.ToDecimal(value, mode.Clamped());
            DecimalC IConvert<DecimalC>.ToNumeric(long value, Conversion mode) => NumericConvert.ToDecimal(value, mode.Clamped());
            DecimalC IConvertExtended<DecimalC>.ToValue(sbyte value, Conversion mode) => NumericConvert.ToDecimal(value, mode.Clamped());
            DecimalC IConvert<DecimalC>.ToNumeric(short value, Conversion mode) => NumericConvert.ToDecimal(value, mode.Clamped());
            DecimalC IConvert<DecimalC>.ToNumeric(string value) => Convert.ToDecimal(value);
            DecimalC IConvertExtended<DecimalC>.ToNumeric(uint value, Conversion mode) => NumericConvert.ToDecimal(value, mode.Clamped());
            DecimalC IConvertExtended<DecimalC>.ToNumeric(ulong value, Conversion mode) => NumericConvert.ToDecimal(value, mode.Clamped());
            DecimalC IConvertExtended<DecimalC>.ToNumeric(ushort value, Conversion mode) => NumericConvert.ToDecimal(value, mode.Clamped());

            DecimalC IParser<DecimalC>.Parse(string s) => Parse(s);
            DecimalC IParser<DecimalC>.Parse(string s, NumberStyles style, IFormatProvider? provider) => Parse(s, style, provider);
        }
    }
}
