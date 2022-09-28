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
    public readonly struct DecimalM : INumericExtended<DecimalM>
    {
        public static readonly DecimalM MaxValue = new DecimalM(decimal.MaxValue);
        public static readonly DecimalM MinValue = new DecimalM(decimal.MinValue);

        private readonly decimal _value;

        public DecimalM(decimal value)
        {
            _value = value;
        }

        private DecimalM(SerializationInfo info, StreamingContext context) : this(info.GetDecimal(nameof(DecimalM))) { }
        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context) => info.AddValue(nameof(DecimalM), _value);

        public int CompareTo(DecimalM other) => _value.CompareTo(other._value);
        public int CompareTo(object? obj) => obj is DecimalM other ? CompareTo(other) : 1;
        public bool Equals(DecimalM other) => _value == other._value;
        public override bool Equals(object? obj) => obj is DecimalM other && Equals(other);
        public override int GetHashCode() => _value.GetHashCode();
        public override string ToString() => _value.ToString();
        public string ToString(IFormatProvider formatProvider) => _value.ToString(formatProvider);
        public string ToString(string format) => _value.ToString(format);
        public string ToString(string? format, IFormatProvider? formatProvider) => _value.ToString(format, formatProvider);

        public static bool TryParse(string s, IFormatProvider? provider, out DecimalM result) => FuncExtensions.Try(() => Parse(s, provider), out result);
        public static bool TryParse(string s, NumberStyles style, IFormatProvider? provider, out DecimalM result) => FuncExtensions.Try(() => Parse(s, style, provider), out result);
        public static bool TryParse(string s, NumberStyles style, out DecimalM result) => FuncExtensions.Try(() => Parse(s, style), out result);
        public static bool TryParse(string s, out DecimalM result) => FuncExtensions.Try(() => Parse(s), out result);
        public static DecimalM Parse(string s) => decimal.Parse(s);
        public static DecimalM Parse(string s, IFormatProvider? provider) => decimal.Parse(s, provider);
        public static DecimalM Parse(string s, NumberStyles style) => decimal.Parse(s, style);
        public static DecimalM Parse(string s, NumberStyles style, IFormatProvider? provider) => decimal.Parse(s, style, provider);

        [CLSCompliant(false)] public static implicit operator DecimalM(sbyte value) => new DecimalM(value);
        [CLSCompliant(false)] public static implicit operator DecimalM(uint value) => new DecimalM(value);
        [CLSCompliant(false)] public static implicit operator DecimalM(ulong value) => new DecimalM(value);
        [CLSCompliant(false)] public static implicit operator DecimalM(ushort value) => new DecimalM(value);
        public static explicit operator DecimalM(double value) => new DecimalM(ConvertN.ToDecimal(value, Conversion.CastClamp));
        public static explicit operator DecimalM(float value) => new DecimalM(ConvertN.ToDecimal(value, Conversion.CastClamp));
        public static implicit operator DecimalM(byte value) => new DecimalM(value);
        public static implicit operator DecimalM(decimal value) => new DecimalM(value);
        public static implicit operator DecimalM(int value) => new DecimalM(value);
        public static implicit operator DecimalM(long value) => new DecimalM(value);
        public static implicit operator DecimalM(short value) => new DecimalM(value);

        [CLSCompliant(false)] public static explicit operator sbyte(DecimalM value) => ConvertN.ToSByte(value._value, Conversion.CastClamp);
        [CLSCompliant(false)] public static explicit operator uint(DecimalM value) => ConvertN.ToUInt32(value._value, Conversion.CastClamp);
        [CLSCompliant(false)] public static explicit operator ulong(DecimalM value) => ConvertN.ToUInt64(value._value, Conversion.CastClamp);
        [CLSCompliant(false)] public static explicit operator ushort(DecimalM value) => ConvertN.ToUInt16(value._value, Conversion.CastClamp);
        public static explicit operator byte(DecimalM value) => ConvertN.ToByte(value._value, Conversion.CastClamp);
        public static explicit operator double(DecimalM value) => ConvertN.ToDouble(value._value, Conversion.CastClamp);
        public static explicit operator float(DecimalM value) => ConvertN.ToSingle(value._value, Conversion.CastClamp);
        public static explicit operator int(DecimalM value) => ConvertN.ToInt32(value._value, Conversion.CastClamp);
        public static explicit operator long(DecimalM value) => ConvertN.ToInt64(value._value, Conversion.CastClamp);
        public static explicit operator short(DecimalM value) => ConvertN.ToInt16(value._value, Conversion.CastClamp);
        public static implicit operator decimal(DecimalM value) => value._value;

        public static bool operator !=(DecimalM left, DecimalM right) => left._value != right._value;
        public static bool operator <(DecimalM left, DecimalM right) => left._value < right._value;
        public static bool operator <=(DecimalM left, DecimalM right) => left._value <= right._value;
        public static bool operator ==(DecimalM left, DecimalM right) => left._value == right._value;
        public static bool operator >(DecimalM left, DecimalM right) => left._value > right._value;
        public static bool operator >=(DecimalM left, DecimalM right) => left._value >= right._value;
        public static DecimalM operator %(DecimalM left, DecimalM right) => Clamped.Remainder(left._value, right._value);
        public static DecimalM operator &(DecimalM left, DecimalM right) => BitOperations.LogicalAnd(left._value, right._value);
        public static DecimalM operator -(DecimalM left, DecimalM right) => Clamped.Subtract(left._value, right._value);
        public static DecimalM operator --(DecimalM value) => value - 1;
        public static DecimalM operator -(DecimalM value) => -value._value;
        public static DecimalM operator *(DecimalM left, DecimalM right) => Clamped.Multiply(left._value, right._value);
        public static DecimalM operator /(DecimalM left, DecimalM right) => Clamped.Divide(left._value, right._value);
        public static DecimalM operator ^(DecimalM left, DecimalM right) => BitOperations.LogicalExclusiveOr(left._value, right._value);
        public static DecimalM operator |(DecimalM left, DecimalM right) => BitOperations.LogicalOr(left._value, right._value);
        public static DecimalM operator ~(DecimalM left) => BitOperations.BitwiseComplement(left._value);
        public static DecimalM operator +(DecimalM left, DecimalM right) => Clamped.Add(left._value, right._value);
        public static DecimalM operator +(DecimalM value) => value;
        public static DecimalM operator ++(DecimalM value) => value + 1;
        public static DecimalM operator <<(DecimalM left, int right) => BitOperations.LeftShift(left._value, right);
        public static DecimalM operator >>(DecimalM left, int right) => BitOperations.RightShift(left._value, right);

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

        bool INumeric<DecimalM>.IsGreaterThan(DecimalM value) => this > value;
        bool INumeric<DecimalM>.IsGreaterThanOrEqualTo(DecimalM value) => this >= value;
        bool INumeric<DecimalM>.IsLessThan(DecimalM value) => this < value;
        bool INumeric<DecimalM>.IsLessThanOrEqualTo(DecimalM value) => this <= value;
        DecimalM INumeric<DecimalM>.Add(DecimalM value) => this + value;
        DecimalM INumeric<DecimalM>.BitwiseComplement() => ~this;
        DecimalM INumeric<DecimalM>.Divide(DecimalM value) => this / value;
        DecimalM INumeric<DecimalM>.LeftShift(int count) => this << count;
        DecimalM INumeric<DecimalM>.LogicalAnd(DecimalM value) => this & value;
        DecimalM INumeric<DecimalM>.LogicalExclusiveOr(DecimalM value) => this ^ value;
        DecimalM INumeric<DecimalM>.LogicalOr(DecimalM value) => this | value;
        DecimalM INumeric<DecimalM>.Multiply(DecimalM value) => this * value;
        DecimalM INumeric<DecimalM>.Negative() => -this;
        DecimalM INumeric<DecimalM>.Positive() => +this;
        DecimalM INumeric<DecimalM>.Remainder(DecimalM value) => this % value;
        DecimalM INumeric<DecimalM>.RightShift(int count) => this >> count;
        DecimalM INumeric<DecimalM>.Subtract(DecimalM value) => this - value;

        INumericBitConverter<DecimalM> IProvider<INumericBitConverter<DecimalM>>.GetInstance() => Utilities.Instance;
        IConvert<DecimalM> IProvider<IConvert<DecimalM>>.GetInstance() => Utilities.Instance;
        IConvertExtended<DecimalM> IProvider<IConvertExtended<DecimalM>>.GetInstance() => Utilities.Instance;
        IMath<DecimalM> IProvider<IMath<DecimalM>>.GetInstance() => Utilities.Instance;
        INumericRandom<DecimalM> IProvider<INumericRandom<DecimalM>>.GetInstance() => Utilities.Instance;
        INumericStatic<DecimalM> IProvider<INumericStatic<DecimalM>>.GetInstance() => Utilities.Instance;
        IVariantRandom<DecimalM> IProvider<IVariantRandom<DecimalM>>.GetInstance() => Utilities.Instance;

        private sealed class Utilities :
            IConvert<DecimalM>,
            IConvertExtended<DecimalM>,
            IMath<DecimalM>,
            INumericBitConverter<DecimalM>,
            INumericRandom<DecimalM>,
            INumericStatic<DecimalM>,
            IVariantRandom<DecimalM>
        {
            public static readonly Utilities Instance = new Utilities();

            bool INumericStatic<DecimalM>.HasFloatingPoint => true;
            bool INumericStatic<DecimalM>.HasInfinity => false;
            bool INumericStatic<DecimalM>.HasNaN => false;
            bool INumericStatic<DecimalM>.IsFinite(DecimalM x) => true;
            bool INumericStatic<DecimalM>.IsInfinity(DecimalM x) => false;
            bool INumericStatic<DecimalM>.IsNaN(DecimalM x) => false;
            bool INumericStatic<DecimalM>.IsNegative(DecimalM x) => x._value < 0;
            bool INumericStatic<DecimalM>.IsNegativeInfinity(DecimalM x) => false;
            bool INumericStatic<DecimalM>.IsNormal(DecimalM x) => false;
            bool INumericStatic<DecimalM>.IsPositiveInfinity(DecimalM x) => false;
            bool INumericStatic<DecimalM>.IsReal => true;
            bool INumericStatic<DecimalM>.IsSigned => true;
            bool INumericStatic<DecimalM>.IsSubnormal(DecimalM x) => false;
            DecimalM INumericStatic<DecimalM>.Epsilon { get; } = new decimal(1, 0, 0, false, 28);
            DecimalM INumericStatic<DecimalM>.MaxUnit => 1m;
            DecimalM INumericStatic<DecimalM>.MaxValue => MaxValue;
            DecimalM INumericStatic<DecimalM>.MinUnit => -1m;
            DecimalM INumericStatic<DecimalM>.MinValue => MinValue;
            DecimalM INumericStatic<DecimalM>.One => 1m;
            DecimalM INumericStatic<DecimalM>.Ten => 10m;
            DecimalM INumericStatic<DecimalM>.Two => 2m;
            DecimalM INumericStatic<DecimalM>.Zero => 0m;

            DecimalM IMath<DecimalM>.Abs(DecimalM value) => Math.Abs(value._value);
            DecimalM IMath<DecimalM>.Acos(DecimalM x) => ConvertN.ToDecimal(Math.Acos(ConvertN.ToDouble(x._value, Conversion.CastClamp)), Conversion.CastClamp);
            DecimalM IMath<DecimalM>.Acosh(DecimalM x) => ConvertN.ToDecimal(MathShim.Acosh(ConvertN.ToDouble(x._value, Conversion.CastClamp)), Conversion.CastClamp);
            DecimalM IMath<DecimalM>.Asin(DecimalM x) => ConvertN.ToDecimal(Math.Asin(ConvertN.ToDouble(x._value, Conversion.CastClamp)), Conversion.CastClamp);
            DecimalM IMath<DecimalM>.Asinh(DecimalM x) => ConvertN.ToDecimal(MathShim.Asinh(ConvertN.ToDouble(x._value, Conversion.CastClamp)), Conversion.CastClamp);
            DecimalM IMath<DecimalM>.Atan(DecimalM x) => ConvertN.ToDecimal(Math.Atan(ConvertN.ToDouble(x._value, Conversion.CastClamp)), Conversion.CastClamp);
            DecimalM IMath<DecimalM>.Atan2(DecimalM x, DecimalM y) => ConvertN.ToDecimal(Math.Atan2(ConvertN.ToDouble(x._value, Conversion.CastClamp), ConvertN.ToDouble(y._value, Conversion.CastClamp)), Conversion.CastClamp);
            DecimalM IMath<DecimalM>.Atanh(DecimalM x) => ConvertN.ToDecimal(MathShim.Atanh(ConvertN.ToDouble(x._value, Conversion.CastClamp)), Conversion.CastClamp);
            DecimalM IMath<DecimalM>.Cbrt(DecimalM x) => ConvertN.ToDecimal(MathShim.Cbrt(ConvertN.ToDouble(x._value, Conversion.CastClamp)), Conversion.CastClamp);
            DecimalM IMath<DecimalM>.Ceiling(DecimalM x) => decimal.Ceiling(x._value);
            DecimalM IMath<DecimalM>.Clamp(DecimalM x, DecimalM bound1, DecimalM bound2) => bound1 > bound2 ? Math.Min(bound1._value, Math.Max(bound2._value, x._value)) : Math.Min(bound2._value, Math.Max(bound1._value, x._value));
            DecimalM IMath<DecimalM>.Cos(DecimalM x) => ConvertN.ToDecimal(Math.Cos(ConvertN.ToDouble(x._value, Conversion.CastClamp)), Conversion.CastClamp);
            DecimalM IMath<DecimalM>.Cosh(DecimalM x) => ConvertN.ToDecimal(Math.Cosh(ConvertN.ToDouble(x._value, Conversion.CastClamp)), Conversion.CastClamp);
            DecimalM IMath<DecimalM>.E { get; } = (decimal)Math.E;
            DecimalM IMath<DecimalM>.Exp(DecimalM x) => ConvertN.ToDecimal(Math.Exp(ConvertN.ToDouble(x._value, Conversion.CastClamp)), Conversion.CastClamp);
            DecimalM IMath<DecimalM>.Floor(DecimalM x) => decimal.Floor(x._value);
            DecimalM IMath<DecimalM>.IEEERemainder(DecimalM x, DecimalM y) => ConvertN.ToDecimal(Math.IEEERemainder(ConvertN.ToDouble(x._value, Conversion.CastClamp), ConvertN.ToDouble(y._value, Conversion.CastClamp)), Conversion.CastClamp);
            DecimalM IMath<DecimalM>.Log(DecimalM x) => ConvertN.ToDecimal(Math.Log(ConvertN.ToDouble(x._value, Conversion.CastClamp)), Conversion.CastClamp);
            DecimalM IMath<DecimalM>.Log(DecimalM x, DecimalM y) => ConvertN.ToDecimal(Math.Log(ConvertN.ToDouble(x._value, Conversion.CastClamp), ConvertN.ToDouble(y._value, Conversion.CastClamp)), Conversion.CastClamp);
            DecimalM IMath<DecimalM>.Log10(DecimalM x) => ConvertN.ToDecimal(Math.Log10(ConvertN.ToDouble(x._value, Conversion.CastClamp)), Conversion.CastClamp);
            DecimalM IMath<DecimalM>.Max(DecimalM x, DecimalM y) => Math.Max(x._value, y._value);
            DecimalM IMath<DecimalM>.Min(DecimalM x, DecimalM y) => Math.Min(x._value, y._value);
            DecimalM IMath<DecimalM>.PI { get; } = (decimal)Math.PI;
            DecimalM IMath<DecimalM>.Pow(DecimalM x, DecimalM y) => y == 1 ? x : (DecimalM)ConvertN.ToDecimal(Math.Pow(ConvertN.ToDouble(x._value, Conversion.CastClamp), ConvertN.ToDouble(y._value, Conversion.CastClamp)), Conversion.CastClamp);
            DecimalM IMath<DecimalM>.Round(DecimalM x) => decimal.Round(x);
            DecimalM IMath<DecimalM>.Round(DecimalM x, int digits) => decimal.Round(x, digits);
            DecimalM IMath<DecimalM>.Round(DecimalM x, int digits, MidpointRounding mode) => decimal.Round(x, digits, mode);
            DecimalM IMath<DecimalM>.Round(DecimalM x, MidpointRounding mode) => decimal.Round(x, mode);
            DecimalM IMath<DecimalM>.Sin(DecimalM x) => ConvertN.ToDecimal(Math.Sin(ConvertN.ToDouble(x._value, Conversion.CastClamp)), Conversion.CastClamp);
            DecimalM IMath<DecimalM>.Sinh(DecimalM x) => ConvertN.ToDecimal(Math.Sinh(ConvertN.ToDouble(x._value, Conversion.CastClamp)), Conversion.CastClamp);
            DecimalM IMath<DecimalM>.Sqrt(DecimalM x) => ConvertN.ToDecimal(Math.Sqrt(ConvertN.ToDouble(x._value, Conversion.CastClamp)), Conversion.CastClamp);
            DecimalM IMath<DecimalM>.Tan(DecimalM x) => ConvertN.ToDecimal(Math.Tan(ConvertN.ToDouble(x._value, Conversion.CastClamp)), Conversion.CastClamp);
            DecimalM IMath<DecimalM>.Tanh(DecimalM x) => ConvertN.ToDecimal(Math.Tanh(ConvertN.ToDouble(x._value, Conversion.CastClamp)), Conversion.CastClamp);
            DecimalM IMath<DecimalM>.Tau { get; } = (decimal)Math.PI * 2m;
            DecimalM IMath<DecimalM>.Truncate(DecimalM x) => decimal.Truncate(x._value);
            int IMath<DecimalM>.Sign(DecimalM x) => Math.Sign(x._value);

            int INumericBitConverter<DecimalM>.ConvertedSize => sizeof(decimal);
            DecimalM INumericBitConverter<DecimalM>.ToNumeric(byte[] value, int startIndex) => BitOperations.ToDecimal(value, startIndex);
            byte[] INumericBitConverter<DecimalM>.GetBytes(DecimalM value) => BitOperations.GetBytes(value._value);

            bool IConvert<DecimalM>.ToBoolean(DecimalM value) => value._value != 0m;
            byte IConvert<DecimalM>.ToByte(DecimalM value, Conversion mode) => ConvertN.ToByte(value._value, mode.Clamped());
            decimal IConvert<DecimalM>.ToDecimal(DecimalM value, Conversion mode) => value._value;
            double IConvert<DecimalM>.ToDouble(DecimalM value, Conversion mode) => ConvertN.ToDouble(value._value, mode.Clamped());
            float IConvert<DecimalM>.ToSingle(DecimalM value, Conversion mode) => ConvertN.ToSingle(value._value, mode.Clamped());
            int IConvert<DecimalM>.ToInt32(DecimalM value, Conversion mode) => ConvertN.ToInt32(value._value, mode.Clamped());
            long IConvert<DecimalM>.ToInt64(DecimalM value, Conversion mode) => ConvertN.ToInt64(value._value, mode.Clamped());
            sbyte IConvertExtended<DecimalM>.ToSByte(DecimalM value, Conversion mode) => ConvertN.ToSByte(value._value, mode.Clamped());
            short IConvert<DecimalM>.ToInt16(DecimalM value, Conversion mode) => ConvertN.ToInt16(value._value, mode.Clamped());
            string IConvert<DecimalM>.ToString(DecimalM value) => Convert.ToString(value._value);
            uint IConvertExtended<DecimalM>.ToUInt32(DecimalM value, Conversion mode) => ConvertN.ToUInt32(value._value, mode.Clamped());
            ulong IConvertExtended<DecimalM>.ToUInt64(DecimalM value, Conversion mode) => ConvertN.ToUInt64(value._value, mode.Clamped());
            ushort IConvertExtended<DecimalM>.ToUInt16(DecimalM value, Conversion mode) => ConvertN.ToUInt16(value._value, mode.Clamped());

            DecimalM IConvert<DecimalM>.ToNumeric(bool value) => new DecimalM(value ? 1m : 0m);
            DecimalM IConvert<DecimalM>.ToNumeric(byte value, Conversion mode) => ConvertN.ToDecimal(value, mode.Clamped());
            DecimalM IConvert<DecimalM>.ToNumeric(decimal value, Conversion mode) => value;
            DecimalM IConvert<DecimalM>.ToNumeric(double value, Conversion mode) => ConvertN.ToDecimal(value, mode.Clamped());
            DecimalM IConvert<DecimalM>.ToNumeric(float value, Conversion mode) => ConvertN.ToDecimal(value, mode.Clamped());
            DecimalM IConvert<DecimalM>.ToNumeric(int value, Conversion mode) => ConvertN.ToDecimal(value, mode.Clamped());
            DecimalM IConvert<DecimalM>.ToNumeric(long value, Conversion mode) => ConvertN.ToDecimal(value, mode.Clamped());
            DecimalM IConvertExtended<DecimalM>.ToValue(sbyte value, Conversion mode) => ConvertN.ToDecimal(value, mode.Clamped());
            DecimalM IConvert<DecimalM>.ToNumeric(short value, Conversion mode) => ConvertN.ToDecimal(value, mode.Clamped());
            DecimalM IConvert<DecimalM>.ToNumeric(string value) => Convert.ToDecimal(value);
            DecimalM IConvertExtended<DecimalM>.ToNumeric(uint value, Conversion mode) => ConvertN.ToDecimal(value, mode.Clamped());
            DecimalM IConvertExtended<DecimalM>.ToNumeric(ulong value, Conversion mode) => ConvertN.ToDecimal(value, mode.Clamped());
            DecimalM IConvertExtended<DecimalM>.ToNumeric(ushort value, Conversion mode) => ConvertN.ToDecimal(value, mode.Clamped());

            DecimalM INumericStatic<DecimalM>.Parse(string s, NumberStyles? style, IFormatProvider? provider)
                => Parse(s, style ?? NumberStyles.Number, provider);

            DecimalM INumericRandom<DecimalM>.Generate(Random random) => random.NextDecimal(1);
            DecimalM INumericRandom<DecimalM>.Generate(Random random, DecimalM maxValue) => random.NextDecimal(maxValue);
            DecimalM INumericRandom<DecimalM>.Generate(Random random, DecimalM minValue, DecimalM maxValue) => random.NextDecimal(minValue, maxValue);
            DecimalM INumericRandom<DecimalM>.Generate(Random random, Generation mode) => random.NextDecimal(mode == Generation.Extended ? decimal.MinValue : 0, mode == Generation.Extended ? decimal.MaxValue : 1, mode);
            DecimalM INumericRandom<DecimalM>.Generate(Random random, DecimalM minValue, DecimalM maxValue, Generation mode) => random.NextDecimal(minValue, maxValue, mode);

            DecimalM IVariantRandom<DecimalM>.Generate(Random random, Variants variants) => random.NextDecimal(variants);
        }
    }
}
