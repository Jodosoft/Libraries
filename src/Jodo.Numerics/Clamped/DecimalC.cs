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
using Jodo.Primitives;
using Jodo.Primitives.Compatibility;

namespace Jodo.Numerics.Clamped
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

        public static bool TryParse(string s, IFormatProvider? provider, out DecimalC result) => TryHelper.Run(() => Parse(s, provider), out result);
        public static bool TryParse(string s, NumberStyles style, IFormatProvider? provider, out DecimalC result) => TryHelper.Run(() => Parse(s, style, provider), out result);
        public static bool TryParse(string s, NumberStyles style, out DecimalC result) => TryHelper.Run(() => Parse(s, style), out result);
        public static bool TryParse(string s, out DecimalC result) => TryHelper.Run(() => Parse(s), out result);
        public static DecimalC Parse(string s) => decimal.Parse(s);
        public static DecimalC Parse(string s, IFormatProvider? provider) => decimal.Parse(s, provider);
        public static DecimalC Parse(string s, NumberStyles style) => decimal.Parse(s, style);
        public static DecimalC Parse(string s, NumberStyles style, IFormatProvider? provider) => decimal.Parse(s, style, provider);

        [CLSCompliant(false)] public static implicit operator DecimalC(sbyte value) => new DecimalC(value);
        [CLSCompliant(false)] public static implicit operator DecimalC(uint value) => new DecimalC(value);
        [CLSCompliant(false)] public static implicit operator DecimalC(ulong value) => new DecimalC(value);
        [CLSCompliant(false)] public static implicit operator DecimalC(ushort value) => new DecimalC(value);
        public static explicit operator DecimalC(double value) => new DecimalC(ConvertN.ToDecimal(value, Conversion.CastClamp));
        public static explicit operator DecimalC(float value) => new DecimalC(ConvertN.ToDecimal(value, Conversion.CastClamp));
        public static implicit operator DecimalC(byte value) => new DecimalC(value);
        public static implicit operator DecimalC(decimal value) => new DecimalC(value);
        public static implicit operator DecimalC(int value) => new DecimalC(value);
        public static implicit operator DecimalC(long value) => new DecimalC(value);
        public static implicit operator DecimalC(short value) => new DecimalC(value);

        [CLSCompliant(false)] public static explicit operator sbyte(DecimalC value) => ConvertN.ToSByte(value._value, Conversion.CastClamp);
        [CLSCompliant(false)] public static explicit operator uint(DecimalC value) => ConvertN.ToUInt32(value._value, Conversion.CastClamp);
        [CLSCompliant(false)] public static explicit operator ulong(DecimalC value) => ConvertN.ToUInt64(value._value, Conversion.CastClamp);
        [CLSCompliant(false)] public static explicit operator ushort(DecimalC value) => ConvertN.ToUInt16(value._value, Conversion.CastClamp);
        public static explicit operator byte(DecimalC value) => ConvertN.ToByte(value._value, Conversion.CastClamp);
        public static explicit operator double(DecimalC value) => ConvertN.ToDouble(value._value, Conversion.CastClamp);
        public static explicit operator float(DecimalC value) => ConvertN.ToSingle(value._value, Conversion.CastClamp);
        public static explicit operator int(DecimalC value) => ConvertN.ToInt32(value._value, Conversion.CastClamp);
        public static explicit operator long(DecimalC value) => ConvertN.ToInt64(value._value, Conversion.CastClamp);
        public static explicit operator short(DecimalC value) => ConvertN.ToInt16(value._value, Conversion.CastClamp);
        public static implicit operator decimal(DecimalC value) => value._value;

        public static bool operator !=(DecimalC left, DecimalC right) => left._value != right._value;
        public static bool operator <(DecimalC left, DecimalC right) => left._value < right._value;
        public static bool operator <=(DecimalC left, DecimalC right) => left._value <= right._value;
        public static bool operator ==(DecimalC left, DecimalC right) => left._value == right._value;
        public static bool operator >(DecimalC left, DecimalC right) => left._value > right._value;
        public static bool operator >=(DecimalC left, DecimalC right) => left._value >= right._value;
        public static DecimalC operator %(DecimalC left, DecimalC right) => ClampedMath.Remainder(left._value, right._value);
        public static DecimalC operator &(DecimalC left, DecimalC right) => BitOperations.LogicalAnd(left._value, right._value);
        public static DecimalC operator -(DecimalC left, DecimalC right) => ClampedMath.Subtract(left._value, right._value);
        public static DecimalC operator --(DecimalC value) => value - 1;
        public static DecimalC operator -(DecimalC value) => -value._value;
        public static DecimalC operator *(DecimalC left, DecimalC right) => ClampedMath.Multiply(left._value, right._value);
        public static DecimalC operator /(DecimalC left, DecimalC right) => ClampedMath.Divide(left._value, right._value);
        public static DecimalC operator ^(DecimalC left, DecimalC right) => BitOperations.LogicalExclusiveOr(left._value, right._value);
        public static DecimalC operator |(DecimalC left, DecimalC right) => BitOperations.LogicalOr(left._value, right._value);
        public static DecimalC operator ~(DecimalC left) => BitOperations.BitwiseComplement(left._value);
        public static DecimalC operator +(DecimalC left, DecimalC right) => ClampedMath.Add(left._value, right._value);
        public static DecimalC operator +(DecimalC value) => value;
        public static DecimalC operator ++(DecimalC value) => value + 1;
        public static DecimalC operator <<(DecimalC left, int right) => BitOperations.LeftShift(left._value, right);
        public static DecimalC operator >>(DecimalC left, int right) => BitOperations.RightShift(left._value, right);

        TypeCode IConvertible.GetTypeCode() => _value.GetTypeCode();
        bool IConvertible.ToBoolean(IFormatProvider provider) => Convert.ToBoolean(_value, provider);
        byte IConvertible.ToByte(IFormatProvider provider) => ConvertN.ToByte(_value, Conversion.Clamp);
        char IConvertible.ToChar(IFormatProvider provider) => Convert.ToChar(_value, provider);
        DateTime IConvertible.ToDateTime(IFormatProvider provider) => Convert.ToDateTime(provider);
        decimal IConvertible.ToDecimal(IFormatProvider provider) => _value;
        double IConvertible.ToDouble(IFormatProvider provider) => ConvertN.ToDouble(_value, Conversion.Clamp);
        float IConvertible.ToSingle(IFormatProvider provider) => ConvertN.ToSingle(_value, Conversion.Clamp);
        int IConvertible.ToInt32(IFormatProvider provider) => ConvertN.ToInt32(_value, Conversion.Clamp);
        long IConvertible.ToInt64(IFormatProvider provider) => ConvertN.ToInt64(_value, Conversion.Clamp);
        sbyte IConvertible.ToSByte(IFormatProvider provider) => ConvertN.ToSByte(_value, Conversion.Clamp);
        short IConvertible.ToInt16(IFormatProvider provider) => ConvertN.ToInt16(_value, Conversion.Clamp);
        uint IConvertible.ToUInt32(IFormatProvider provider) => ConvertN.ToUInt32(_value, Conversion.Clamp);
        ulong IConvertible.ToUInt64(IFormatProvider provider) => ConvertN.ToUInt64(_value, Conversion.Clamp);
        ushort IConvertible.ToUInt16(IFormatProvider provider) => ConvertN.ToUInt16(_value, Conversion.Clamp);
        object IConvertible.ToType(Type conversionType, IFormatProvider provider) => this.ToTypeDefault(conversionType, provider);

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

        INumericBitConverter<DecimalC> IProvider<INumericBitConverter<DecimalC>>.GetInstance() => Utilities.Instance;
        IConvert<DecimalC> IProvider<IConvert<DecimalC>>.GetInstance() => Utilities.Instance;
        IConvertExtended<DecimalC> IProvider<IConvertExtended<DecimalC>>.GetInstance() => Utilities.Instance;
        IMath<DecimalC> IProvider<IMath<DecimalC>>.GetInstance() => Utilities.Instance;
        INumericRandom<DecimalC> IProvider<INumericRandom<DecimalC>>.GetInstance() => Utilities.Instance;
        INumericStatic<DecimalC> IProvider<INumericStatic<DecimalC>>.GetInstance() => Utilities.Instance;
        IVariantRandom<DecimalC> IProvider<IVariantRandom<DecimalC>>.GetInstance() => Utilities.Instance;

        private sealed class Utilities :
            IConvert<DecimalC>,
            IConvertExtended<DecimalC>,
            IMath<DecimalC>,
            INumericBitConverter<DecimalC>,
            INumericRandom<DecimalC>,
            INumericStatic<DecimalC>,
            IVariantRandom<DecimalC>
        {
            public static readonly Utilities Instance = new Utilities();

            bool INumericStatic<DecimalC>.HasFloatingPoint => true;
            bool INumericStatic<DecimalC>.HasInfinity => false;
            bool INumericStatic<DecimalC>.HasNaN => false;
            bool INumericStatic<DecimalC>.IsFinite(DecimalC x) => true;
            bool INumericStatic<DecimalC>.IsInfinity(DecimalC x) => false;
            bool INumericStatic<DecimalC>.IsNaN(DecimalC x) => false;
            bool INumericStatic<DecimalC>.IsNegative(DecimalC x) => x._value < 0;
            bool INumericStatic<DecimalC>.IsNegativeInfinity(DecimalC x) => false;
            bool INumericStatic<DecimalC>.IsNormal(DecimalC x) => false;
            bool INumericStatic<DecimalC>.IsPositiveInfinity(DecimalC x) => false;
            bool INumericStatic<DecimalC>.IsReal => true;
            bool INumericStatic<DecimalC>.IsSigned => true;
            bool INumericStatic<DecimalC>.IsSubnormal(DecimalC x) => false;
            DecimalC INumericStatic<DecimalC>.Epsilon { get; } = new decimal(1, 0, 0, false, 28);
            DecimalC INumericStatic<DecimalC>.MaxUnit => 1m;
            DecimalC INumericStatic<DecimalC>.MaxValue => MaxValue;
            DecimalC INumericStatic<DecimalC>.MinUnit => -1m;
            DecimalC INumericStatic<DecimalC>.MinValue => MinValue;
            DecimalC INumericStatic<DecimalC>.One => 1m;
            DecimalC INumericStatic<DecimalC>.Ten => 10m;
            DecimalC INumericStatic<DecimalC>.Two => 2m;
            DecimalC INumericStatic<DecimalC>.Zero => 0m;

            DecimalC IMath<DecimalC>.Abs(DecimalC value) => Math.Abs(value._value);
            DecimalC IMath<DecimalC>.Acos(DecimalC x) => ConvertN.ToDecimal(Math.Acos(ConvertN.ToDouble(x._value, Conversion.CastClamp)), Conversion.CastClamp);
            DecimalC IMath<DecimalC>.Acosh(DecimalC x) => ConvertN.ToDecimal(MathCompat.Acosh(ConvertN.ToDouble(x._value, Conversion.CastClamp)), Conversion.CastClamp);
            DecimalC IMath<DecimalC>.Asin(DecimalC x) => ConvertN.ToDecimal(Math.Asin(ConvertN.ToDouble(x._value, Conversion.CastClamp)), Conversion.CastClamp);
            DecimalC IMath<DecimalC>.Asinh(DecimalC x) => ConvertN.ToDecimal(MathCompat.Asinh(ConvertN.ToDouble(x._value, Conversion.CastClamp)), Conversion.CastClamp);
            DecimalC IMath<DecimalC>.Atan(DecimalC x) => ConvertN.ToDecimal(Math.Atan(ConvertN.ToDouble(x._value, Conversion.CastClamp)), Conversion.CastClamp);
            DecimalC IMath<DecimalC>.Atan2(DecimalC x, DecimalC y) => ConvertN.ToDecimal(Math.Atan2(ConvertN.ToDouble(x._value, Conversion.CastClamp), ConvertN.ToDouble(y._value, Conversion.CastClamp)), Conversion.CastClamp);
            DecimalC IMath<DecimalC>.Atanh(DecimalC x) => ConvertN.ToDecimal(MathCompat.Atanh(ConvertN.ToDouble(x._value, Conversion.CastClamp)), Conversion.CastClamp);
            DecimalC IMath<DecimalC>.Cbrt(DecimalC x) => ConvertN.ToDecimal(MathCompat.Cbrt(ConvertN.ToDouble(x._value, Conversion.CastClamp)), Conversion.CastClamp);
            DecimalC IMath<DecimalC>.Ceiling(DecimalC x) => decimal.Ceiling(x._value);
            DecimalC IMath<DecimalC>.Clamp(DecimalC x, DecimalC bound1, DecimalC bound2) => bound1 > bound2 ? Math.Min(bound1._value, Math.Max(bound2._value, x._value)) : Math.Min(bound2._value, Math.Max(bound1._value, x._value));
            DecimalC IMath<DecimalC>.Cos(DecimalC x) => ConvertN.ToDecimal(Math.Cos(ConvertN.ToDouble(x._value, Conversion.CastClamp)), Conversion.CastClamp);
            DecimalC IMath<DecimalC>.Cosh(DecimalC x) => ConvertN.ToDecimal(Math.Cosh(ConvertN.ToDouble(x._value, Conversion.CastClamp)), Conversion.CastClamp);
            DecimalC IMath<DecimalC>.E { get; } = (decimal)Math.E;
            DecimalC IMath<DecimalC>.Exp(DecimalC x) => ConvertN.ToDecimal(Math.Exp(ConvertN.ToDouble(x._value, Conversion.CastClamp)), Conversion.CastClamp);
            DecimalC IMath<DecimalC>.Floor(DecimalC x) => decimal.Floor(x._value);
            DecimalC IMath<DecimalC>.IEEERemainder(DecimalC x, DecimalC y) => ConvertN.ToDecimal(Math.IEEERemainder(ConvertN.ToDouble(x._value, Conversion.CastClamp), ConvertN.ToDouble(y._value, Conversion.CastClamp)), Conversion.CastClamp);
            DecimalC IMath<DecimalC>.Log(DecimalC x) => ConvertN.ToDecimal(Math.Log(ConvertN.ToDouble(x._value, Conversion.CastClamp)), Conversion.CastClamp);
            DecimalC IMath<DecimalC>.Log(DecimalC x, DecimalC y) => ConvertN.ToDecimal(Math.Log(ConvertN.ToDouble(x._value, Conversion.CastClamp), ConvertN.ToDouble(y._value, Conversion.CastClamp)), Conversion.CastClamp);
            DecimalC IMath<DecimalC>.Log10(DecimalC x) => ConvertN.ToDecimal(Math.Log10(ConvertN.ToDouble(x._value, Conversion.CastClamp)), Conversion.CastClamp);
            DecimalC IMath<DecimalC>.Max(DecimalC x, DecimalC y) => Math.Max(x._value, y._value);
            DecimalC IMath<DecimalC>.Min(DecimalC x, DecimalC y) => Math.Min(x._value, y._value);
            DecimalC IMath<DecimalC>.PI { get; } = (decimal)Math.PI;
            DecimalC IMath<DecimalC>.Pow(DecimalC x, DecimalC y) => y == 1 ? x : (DecimalC)ConvertN.ToDecimal(Math.Pow(ConvertN.ToDouble(x._value, Conversion.CastClamp), ConvertN.ToDouble(y._value, Conversion.CastClamp)), Conversion.CastClamp);
            DecimalC IMath<DecimalC>.Round(DecimalC x) => decimal.Round(x);
            DecimalC IMath<DecimalC>.Round(DecimalC x, int digits) => decimal.Round(x, digits);
            DecimalC IMath<DecimalC>.Round(DecimalC x, int digits, MidpointRounding mode) => decimal.Round(x, digits, mode);
            DecimalC IMath<DecimalC>.Round(DecimalC x, MidpointRounding mode) => decimal.Round(x, mode);
            DecimalC IMath<DecimalC>.Sin(DecimalC x) => ConvertN.ToDecimal(Math.Sin(ConvertN.ToDouble(x._value, Conversion.CastClamp)), Conversion.CastClamp);
            DecimalC IMath<DecimalC>.Sinh(DecimalC x) => ConvertN.ToDecimal(Math.Sinh(ConvertN.ToDouble(x._value, Conversion.CastClamp)), Conversion.CastClamp);
            DecimalC IMath<DecimalC>.Sqrt(DecimalC x) => ConvertN.ToDecimal(Math.Sqrt(ConvertN.ToDouble(x._value, Conversion.CastClamp)), Conversion.CastClamp);
            DecimalC IMath<DecimalC>.Tan(DecimalC x) => ConvertN.ToDecimal(Math.Tan(ConvertN.ToDouble(x._value, Conversion.CastClamp)), Conversion.CastClamp);
            DecimalC IMath<DecimalC>.Tanh(DecimalC x) => ConvertN.ToDecimal(Math.Tanh(ConvertN.ToDouble(x._value, Conversion.CastClamp)), Conversion.CastClamp);
            DecimalC IMath<DecimalC>.Tau { get; } = (decimal)Math.PI * 2m;
            DecimalC IMath<DecimalC>.Truncate(DecimalC x) => decimal.Truncate(x._value);
            int IMath<DecimalC>.Sign(DecimalC x) => Math.Sign(x._value);

            int INumericBitConverter<DecimalC>.ConvertedSize => sizeof(decimal);
            DecimalC INumericBitConverter<DecimalC>.ToNumeric(byte[] value, int startIndex) => BitOperations.ToDecimal(value, startIndex);
            byte[] INumericBitConverter<DecimalC>.GetBytes(DecimalC value) => BitOperations.GetBytes(value._value);

            bool IConvert<DecimalC>.ToBoolean(DecimalC value) => value._value != 0m;
            byte IConvert<DecimalC>.ToByte(DecimalC value, Conversion mode) => ConvertN.ToByte(value._value, mode.Clamped());
            decimal IConvert<DecimalC>.ToDecimal(DecimalC value, Conversion mode) => value._value;
            double IConvert<DecimalC>.ToDouble(DecimalC value, Conversion mode) => ConvertN.ToDouble(value._value, mode.Clamped());
            float IConvert<DecimalC>.ToSingle(DecimalC value, Conversion mode) => ConvertN.ToSingle(value._value, mode.Clamped());
            int IConvert<DecimalC>.ToInt32(DecimalC value, Conversion mode) => ConvertN.ToInt32(value._value, mode.Clamped());
            long IConvert<DecimalC>.ToInt64(DecimalC value, Conversion mode) => ConvertN.ToInt64(value._value, mode.Clamped());
            sbyte IConvertExtended<DecimalC>.ToSByte(DecimalC value, Conversion mode) => ConvertN.ToSByte(value._value, mode.Clamped());
            short IConvert<DecimalC>.ToInt16(DecimalC value, Conversion mode) => ConvertN.ToInt16(value._value, mode.Clamped());
            string IConvert<DecimalC>.ToString(DecimalC value) => Convert.ToString(value._value);
            uint IConvertExtended<DecimalC>.ToUInt32(DecimalC value, Conversion mode) => ConvertN.ToUInt32(value._value, mode.Clamped());
            ulong IConvertExtended<DecimalC>.ToUInt64(DecimalC value, Conversion mode) => ConvertN.ToUInt64(value._value, mode.Clamped());
            ushort IConvertExtended<DecimalC>.ToUInt16(DecimalC value, Conversion mode) => ConvertN.ToUInt16(value._value, mode.Clamped());

            DecimalC IConvert<DecimalC>.ToNumeric(bool value) => new DecimalC(value ? 1m : 0m);
            DecimalC IConvert<DecimalC>.ToNumeric(byte value, Conversion mode) => ConvertN.ToDecimal(value, mode.Clamped());
            DecimalC IConvert<DecimalC>.ToNumeric(decimal value, Conversion mode) => value;
            DecimalC IConvert<DecimalC>.ToNumeric(double value, Conversion mode) => ConvertN.ToDecimal(value, mode.Clamped());
            DecimalC IConvert<DecimalC>.ToNumeric(float value, Conversion mode) => ConvertN.ToDecimal(value, mode.Clamped());
            DecimalC IConvert<DecimalC>.ToNumeric(int value, Conversion mode) => ConvertN.ToDecimal(value, mode.Clamped());
            DecimalC IConvert<DecimalC>.ToNumeric(long value, Conversion mode) => ConvertN.ToDecimal(value, mode.Clamped());
            DecimalC IConvertExtended<DecimalC>.ToValue(sbyte value, Conversion mode) => ConvertN.ToDecimal(value, mode.Clamped());
            DecimalC IConvert<DecimalC>.ToNumeric(short value, Conversion mode) => ConvertN.ToDecimal(value, mode.Clamped());
            DecimalC IConvert<DecimalC>.ToNumeric(string value) => Convert.ToDecimal(value);
            DecimalC IConvertExtended<DecimalC>.ToNumeric(uint value, Conversion mode) => ConvertN.ToDecimal(value, mode.Clamped());
            DecimalC IConvertExtended<DecimalC>.ToNumeric(ulong value, Conversion mode) => ConvertN.ToDecimal(value, mode.Clamped());
            DecimalC IConvertExtended<DecimalC>.ToNumeric(ushort value, Conversion mode) => ConvertN.ToDecimal(value, mode.Clamped());

            DecimalC INumericStatic<DecimalC>.Parse(string s, NumberStyles? style, IFormatProvider? provider)
                => Parse(s, style ?? NumberStyles.Number, provider);

            DecimalC INumericRandom<DecimalC>.Next(Random random) => random.NextDecimal(1);
            DecimalC INumericRandom<DecimalC>.Next(Random random, DecimalC maxValue) => random.NextDecimal(maxValue);
            DecimalC INumericRandom<DecimalC>.Next(Random random, DecimalC minValue, DecimalC maxValue) => random.NextDecimal(minValue, maxValue);
            DecimalC INumericRandom<DecimalC>.Next(Random random, Generation mode) => random.NextDecimal(0, mode == Generation.Extended ? decimal.MaxValue : 1, mode);
            DecimalC INumericRandom<DecimalC>.Next(Random random, DecimalC minValue, DecimalC maxValue, Generation mode) => random.NextDecimal(minValue, maxValue, mode);

            DecimalC IVariantRandom<DecimalC>.Next(Random random, Scenarios scenarios) => NumericVariant.Generate<DecimalC>(random, scenarios);
        }
    }
}
