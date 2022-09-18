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
using Jodo.Numerics.Internals;
using Jodo.Primitives;
using Jodo.Primitives.Compatibility;

namespace Jodo.Numerics
{
    /// <summary>
    /// Represents a decimal fixed-point number.
    /// </summary>
    [Serializable]
    [DebuggerDisplay("{ToString(),nq}")]
    public readonly struct Fix64Temp : INumericExtended<Fix64Temp>
    {
        public static readonly Fix64Temp Epsilon = new Fix64Temp(1);
        public static readonly Fix64Temp MaxValue = new Fix64Temp(long.MaxValue);
        public static readonly Fix64Temp MinValue = new Fix64Temp(long.MinValue);

        private const long ScalingFactor = 1_000_000;

        private readonly long _scaledValue;

        private Fix64Temp(long scaledValue)
        {
            _scaledValue = scaledValue;
        }

        private Fix64Temp(SerializationInfo info, StreamingContext context) : this(info.GetInt64(nameof(Fix64Temp))) { }
        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context) => info.AddValue(nameof(Fix64Temp), _scaledValue);

        public int CompareTo(Fix64Temp other) => _scaledValue.CompareTo(other._scaledValue);
        public int CompareTo(object? obj) => obj is Fix64Temp other ? CompareTo(other) : 1;
        public bool Equals(Fix64Temp other) => _scaledValue == other._scaledValue;
        public override bool Equals(object? obj) => obj is Fix64Temp other && Equals(other);
        public override int GetHashCode() => _scaledValue.GetHashCode();
        public override string ToString() => Scaled.ToString(_scaledValue, ScalingFactor, null);
        public string ToString(IFormatProvider formatProvider) => ((double)this).ToString(formatProvider);
        public string ToString(string format) => ((double)this).ToString(format);
        public string ToString(string? format, IFormatProvider? formatProvider) => ((double)this).ToString(format, formatProvider);

        public static bool TryParse(string s, IFormatProvider? provider, out Fix64Temp result) => FuncExtensions.Try(() => Parse(s, provider), out result);
        public static bool TryParse(string s, NumberStyles style, IFormatProvider? provider, out Fix64Temp result) => FuncExtensions.Try(() => Parse(s, style, provider), out result);
        public static bool TryParse(string s, NumberStyles style, out Fix64Temp result) => FuncExtensions.Try(() => Parse(s, style), out result);
        public static bool TryParse(string s, out Fix64Temp result) => FuncExtensions.Try(() => Parse(s), out result);
        public static Fix64Temp Parse(string s) => new Fix64Temp(Scaled.Parse(s, ScalingFactor, null, null));
        public static Fix64Temp Parse(string s, IFormatProvider? provider) => new Fix64Temp(Scaled.Parse(s, ScalingFactor, null, provider));
        public static Fix64Temp Parse(string s, NumberStyles style) => (Fix64Temp)double.Parse(s, style);
        public static Fix64Temp Parse(string s, NumberStyles style, IFormatProvider? provider) => (Fix64Temp)double.Parse(s, style, provider);

        private static Fix64Temp Round(Fix64Temp value, int digits, MidpointRounding mode)
        {
            if (digits < 0) throw new ArgumentOutOfRangeException(nameof(digits), digits, "Must be positive.");
            if (digits > 5) return value;
            return new Fix64Temp(Scaled.Round(value._scaledValue, 6 - digits, mode));
        }

        [SuppressMessage("Style", "JSON002:Probable JSON string detected", Justification = "False positive")]
        private static Fix64Temp FromDouble(double value)
        {
            string str = string
                .Format(CultureInfo.InvariantCulture, "{0:0.0000000}", value)
                .Replace(".", string.Empty);
            str = str.Substring(0, str.Length - 1);
            if (long.TryParse(str, out long lng))
            {
                return new Fix64Temp(lng);
            }
            else
            {
                if (value > 0) return MaxValue;
                return MinValue;
            }
        }

        [CLSCompliant(false)] public static explicit operator Fix64Temp(ulong value) => new Fix64Temp((long)(value * ScalingFactor));
        [CLSCompliant(false)] public static implicit operator Fix64Temp(sbyte value) => new Fix64Temp(value * ScalingFactor);
        [CLSCompliant(false)] public static implicit operator Fix64Temp(uint value) => new Fix64Temp(value * ScalingFactor);
        [CLSCompliant(false)] public static implicit operator Fix64Temp(ushort value) => new Fix64Temp(value * ScalingFactor);
        public static explicit operator Fix64Temp(decimal value) => new Fix64Temp((long)(value * ScalingFactor));
        public static explicit operator Fix64Temp(double value) => FromDouble(value);
        public static explicit operator Fix64Temp(long value) => new Fix64Temp(value * ScalingFactor);
        public static implicit operator Fix64Temp(byte value) => new Fix64Temp(value * ScalingFactor);
        public static implicit operator Fix64Temp(float value) => new Fix64Temp((long)(value * ScalingFactor));
        public static implicit operator Fix64Temp(int value) => new Fix64Temp(value * ScalingFactor);
        public static implicit operator Fix64Temp(short value) => new Fix64Temp(value * ScalingFactor);

        [CLSCompliant(false)] public static explicit operator sbyte(Fix64Temp value) => (sbyte)(value._scaledValue / ScalingFactor);
        [CLSCompliant(false)] public static explicit operator uint(Fix64Temp value) => (uint)(value._scaledValue / ScalingFactor);
        [CLSCompliant(false)] public static explicit operator ulong(Fix64Temp value) => (ulong)(value._scaledValue / ScalingFactor);
        [CLSCompliant(false)] public static explicit operator ushort(Fix64Temp value) => (ushort)(value._scaledValue / ScalingFactor);
        public static explicit operator byte(Fix64Temp value) => (byte)(value._scaledValue / ScalingFactor);
        public static explicit operator decimal(Fix64Temp value) => (decimal)value._scaledValue / ScalingFactor;
        public static explicit operator double(Fix64Temp value) => Scaled.ToDouble(value._scaledValue, ScalingFactor);
        public static explicit operator float(Fix64Temp value) => (float)value._scaledValue / ScalingFactor;
        public static explicit operator int(Fix64Temp value) => (int)(value._scaledValue / ScalingFactor);
        public static explicit operator long(Fix64Temp value) => value._scaledValue / ScalingFactor;
        public static explicit operator short(Fix64Temp value) => (short)(value._scaledValue / ScalingFactor);

        public static bool operator !=(Fix64Temp left, Fix64Temp right) => left._scaledValue != right._scaledValue;
        public static bool operator <(Fix64Temp left, Fix64Temp right) => left._scaledValue < right._scaledValue;
        public static bool operator <=(Fix64Temp left, Fix64Temp right) => left._scaledValue <= right._scaledValue;
        public static bool operator ==(Fix64Temp left, Fix64Temp right) => left._scaledValue == right._scaledValue;
        public static bool operator >(Fix64Temp left, Fix64Temp right) => left._scaledValue > right._scaledValue;
        public static bool operator >=(Fix64Temp left, Fix64Temp right) => left._scaledValue >= right._scaledValue;
        public static Fix64Temp operator %(Fix64Temp left, Fix64Temp right) => new Fix64Temp(left._scaledValue % right._scaledValue);
        public static Fix64Temp operator &(Fix64Temp left, Fix64Temp right) => new Fix64Temp(left._scaledValue & right._scaledValue);
        public static Fix64Temp operator -(Fix64Temp left, Fix64Temp right) => new Fix64Temp(left._scaledValue - right._scaledValue);
        public static Fix64Temp operator --(Fix64Temp value) => new Fix64Temp(value._scaledValue - ScalingFactor);
        public static Fix64Temp operator -(Fix64Temp value) => new Fix64Temp(-value._scaledValue);
        public static Fix64Temp operator *(Fix64Temp left, Fix64Temp right) => new Fix64Temp(Scaled.Multiply(left._scaledValue, right._scaledValue, ScalingFactor));
        public static Fix64Temp operator /(Fix64Temp left, Fix64Temp right) => new Fix64Temp(Scaled.Divide(left._scaledValue, right._scaledValue, ScalingFactor));
        public static Fix64Temp operator ^(Fix64Temp left, Fix64Temp right) => new Fix64Temp(left._scaledValue ^ right._scaledValue);
        public static Fix64Temp operator |(Fix64Temp left, Fix64Temp right) => new Fix64Temp(left._scaledValue | right._scaledValue);
        public static Fix64Temp operator ~(Fix64Temp value) => new Fix64Temp(~value._scaledValue);
        public static Fix64Temp operator +(Fix64Temp left, Fix64Temp right) => new Fix64Temp(left._scaledValue + right._scaledValue);
        public static Fix64Temp operator +(Fix64Temp value) => value;
        public static Fix64Temp operator ++(Fix64Temp value) => new Fix64Temp(value._scaledValue + ScalingFactor);
        public static Fix64Temp operator <<(Fix64Temp left, int right) => new Fix64Temp(left._scaledValue << right);
        public static Fix64Temp operator >>(Fix64Temp left, int right) => new Fix64Temp(left._scaledValue >> right);

        TypeCode IConvertible.GetTypeCode() => TypeCode.Object;
        bool IConvertible.ToBoolean(IFormatProvider provider) => ((IConvert<Fix64Temp>)Utilities.Instance).ToBoolean(this);
        char IConvertible.ToChar(IFormatProvider provider) => ((IConvertible)((IConvert<Fix64Temp>)Utilities.Instance).ToDouble(this, Conversion.Default)).ToChar(provider);
        sbyte IConvertible.ToSByte(IFormatProvider provider) => ((IConvertExtended<Fix64Temp>)Utilities.Instance).ToSByte(this, Conversion.Default);
        byte IConvertible.ToByte(IFormatProvider provider) => ((IConvert<Fix64Temp>)Utilities.Instance).ToByte(this, Conversion.Default);
        short IConvertible.ToInt16(IFormatProvider provider) => ((IConvert<Fix64Temp>)Utilities.Instance).ToInt16(this, Conversion.Default);
        ushort IConvertible.ToUInt16(IFormatProvider provider) => ((IConvertExtended<Fix64Temp>)Utilities.Instance).ToUInt16(this, Conversion.Default);
        int IConvertible.ToInt32(IFormatProvider provider) => ((IConvert<Fix64Temp>)Utilities.Instance).ToInt32(this, Conversion.Default);
        uint IConvertible.ToUInt32(IFormatProvider provider) => ((IConvertExtended<Fix64Temp>)Utilities.Instance).ToUInt32(this, Conversion.Default);
        long IConvertible.ToInt64(IFormatProvider provider) => ((IConvert<Fix64Temp>)Utilities.Instance).ToInt64(this, Conversion.Default);
        ulong IConvertible.ToUInt64(IFormatProvider provider) => ((IConvertExtended<Fix64Temp>)Utilities.Instance).ToUInt64(this, Conversion.Default);
        float IConvertible.ToSingle(IFormatProvider provider) => ((IConvert<Fix64Temp>)Utilities.Instance).ToSingle(this, Conversion.Default);
        double IConvertible.ToDouble(IFormatProvider provider) => ((IConvert<Fix64Temp>)Utilities.Instance).ToDouble(this, Conversion.Default);
        decimal IConvertible.ToDecimal(IFormatProvider provider) => ((IConvert<Fix64Temp>)Utilities.Instance).ToDecimal(this, Conversion.Default);
        DateTime IConvertible.ToDateTime(IFormatProvider provider) => ((IConvertible)((IConvert<Fix64Temp>)Utilities.Instance).ToDouble(this, Conversion.Default)).ToDateTime(provider);
        object IConvertible.ToType(Type conversionType, IFormatProvider provider) => this.ToTypeDefault(conversionType, provider);

        bool INumeric<Fix64Temp>.IsGreaterThan(Fix64Temp value) => this > value;
        bool INumeric<Fix64Temp>.IsGreaterThanOrEqualTo(Fix64Temp value) => this >= value;
        bool INumeric<Fix64Temp>.IsLessThan(Fix64Temp value) => this < value;
        bool INumeric<Fix64Temp>.IsLessThanOrEqualTo(Fix64Temp value) => this <= value;
        Fix64Temp INumeric<Fix64Temp>.Add(Fix64Temp value) => this + value;
        Fix64Temp INumeric<Fix64Temp>.BitwiseComplement() => ~this;
        Fix64Temp INumeric<Fix64Temp>.Divide(Fix64Temp value) => this / value;
        Fix64Temp INumeric<Fix64Temp>.LeftShift(int count) => this << count;
        Fix64Temp INumeric<Fix64Temp>.LogicalAnd(Fix64Temp value) => this & value;
        Fix64Temp INumeric<Fix64Temp>.LogicalExclusiveOr(Fix64Temp value) => this ^ value;
        Fix64Temp INumeric<Fix64Temp>.LogicalOr(Fix64Temp value) => this | value;
        Fix64Temp INumeric<Fix64Temp>.Multiply(Fix64Temp value) => this * value;
        Fix64Temp INumeric<Fix64Temp>.Negative() => -this;
        Fix64Temp INumeric<Fix64Temp>.Positive() => +this;
        Fix64Temp INumeric<Fix64Temp>.Remainder(Fix64Temp value) => this % value;
        Fix64Temp INumeric<Fix64Temp>.RightShift(int count) => this >> count;
        Fix64Temp INumeric<Fix64Temp>.Subtract(Fix64Temp value) => this - value;

        INumericBitConverter<Fix64Temp> IProvider<INumericBitConverter<Fix64Temp>>.GetInstance() => Utilities.Instance;
        IConvert<Fix64Temp> IProvider<IConvert<Fix64Temp>>.GetInstance() => Utilities.Instance;
        IConvertExtended<Fix64Temp> IProvider<IConvertExtended<Fix64Temp>>.GetInstance() => Utilities.Instance;
        IMath<Fix64Temp> IProvider<IMath<Fix64Temp>>.GetInstance() => Utilities.Instance;
        INumericStatic<Fix64Temp> IProvider<INumericStatic<Fix64Temp>>.GetInstance() => Utilities.Instance;
        INumericRandom<Fix64Temp> IProvider<INumericRandom<Fix64Temp>>.GetInstance() => Utilities.Instance;
        IVariantRandom<Fix64Temp> IProvider<IVariantRandom<Fix64Temp>>.GetInstance() => Utilities.Instance;

        private sealed class Utilities :
            IConvert<Fix64Temp>,
            IConvertExtended<Fix64Temp>,
            IMath<Fix64Temp>,
            INumericBitConverter<Fix64Temp>,
            INumericRandom<Fix64Temp>,
            INumericStatic<Fix64Temp>,
            IVariantRandom<Fix64Temp>
        {
            public static readonly Utilities Instance = new Utilities();

            bool INumericStatic<Fix64Temp>.HasFloatingPoint => false;
            bool INumericStatic<Fix64Temp>.HasInfinity => false;
            bool INumericStatic<Fix64Temp>.HasNaN => false;
            bool INumericStatic<Fix64Temp>.IsFinite(Fix64Temp x) => true;
            bool INumericStatic<Fix64Temp>.IsInfinity(Fix64Temp x) => false;
            bool INumericStatic<Fix64Temp>.IsNaN(Fix64Temp x) => false;
            bool INumericStatic<Fix64Temp>.IsNegative(Fix64Temp x) => x._scaledValue < 0;
            bool INumericStatic<Fix64Temp>.IsNegativeInfinity(Fix64Temp x) => false;
            bool INumericStatic<Fix64Temp>.IsNormal(Fix64Temp x) => false;
            bool INumericStatic<Fix64Temp>.IsPositiveInfinity(Fix64Temp x) => false;
            bool INumericStatic<Fix64Temp>.IsReal => true;
            bool INumericStatic<Fix64Temp>.IsSigned => true;
            bool INumericStatic<Fix64Temp>.IsSubnormal(Fix64Temp x) => false;
            Fix64Temp INumericStatic<Fix64Temp>.Epsilon { get; } = new Fix64Temp(1);
            Fix64Temp INumericStatic<Fix64Temp>.MaxUnit { get; } = new Fix64Temp(ScalingFactor);
            Fix64Temp INumericStatic<Fix64Temp>.MaxValue => MaxValue;
            Fix64Temp INumericStatic<Fix64Temp>.MinUnit { get; } = new Fix64Temp(-ScalingFactor);
            Fix64Temp INumericStatic<Fix64Temp>.MinValue => MinValue;
            Fix64Temp INumericStatic<Fix64Temp>.One { get; } = new Fix64Temp(ScalingFactor);
            Fix64Temp INumericStatic<Fix64Temp>.Ten { get; } = new Fix64Temp(10 * ScalingFactor);
            Fix64Temp INumericStatic<Fix64Temp>.Two { get; } = new Fix64Temp(2 * ScalingFactor);
            Fix64Temp INumericStatic<Fix64Temp>.Zero => 0;

            Fix64Temp IMath<Fix64Temp>.Abs(Fix64Temp value) => value._scaledValue < 0 ? -value : value;
            Fix64Temp IMath<Fix64Temp>.Acos(Fix64Temp x) => (Fix64Temp)Math.Acos((double)x);
            Fix64Temp IMath<Fix64Temp>.Acosh(Fix64Temp x) => (Fix64Temp)MathShim.Acosh((double)x);
            Fix64Temp IMath<Fix64Temp>.Asin(Fix64Temp x) => (Fix64Temp)Math.Asin((double)x);
            Fix64Temp IMath<Fix64Temp>.Asinh(Fix64Temp x) => (Fix64Temp)MathShim.Asinh((double)x);
            Fix64Temp IMath<Fix64Temp>.Atan(Fix64Temp x) => (Fix64Temp)Math.Atan((double)x);
            Fix64Temp IMath<Fix64Temp>.Atan2(Fix64Temp x, Fix64Temp y) => (Fix64Temp)Math.Atan2((double)x, (double)y);
            Fix64Temp IMath<Fix64Temp>.Atanh(Fix64Temp x) => (Fix64Temp)MathShim.Atanh((double)x);
            Fix64Temp IMath<Fix64Temp>.Cbrt(Fix64Temp x) => (Fix64Temp)MathShim.Cbrt((double)x);
            Fix64Temp IMath<Fix64Temp>.Ceiling(Fix64Temp x) => new Fix64Temp(Scaled.Ceiling(x._scaledValue, ScalingFactor));
            Fix64Temp IMath<Fix64Temp>.Clamp(Fix64Temp x, Fix64Temp bound1, Fix64Temp bound2) => new Fix64Temp(bound1 > bound2 ? Math.Min(bound1._scaledValue, Math.Max(bound2._scaledValue, x._scaledValue)) : Math.Min(bound2._scaledValue, Math.Max(bound1._scaledValue, x._scaledValue)));
            Fix64Temp IMath<Fix64Temp>.Cos(Fix64Temp x) => (Fix64Temp)Math.Cos((double)x);
            Fix64Temp IMath<Fix64Temp>.Cosh(Fix64Temp x) => (Fix64Temp)Math.Cosh((double)x);
            Fix64Temp IMath<Fix64Temp>.E { get; } = (Fix64Temp)Math.E;
            Fix64Temp IMath<Fix64Temp>.Exp(Fix64Temp x) => (Fix64Temp)Math.Exp((double)x);
            Fix64Temp IMath<Fix64Temp>.Floor(Fix64Temp x) => new Fix64Temp(Scaled.Floor(x._scaledValue, ScalingFactor));
            Fix64Temp IMath<Fix64Temp>.IEEERemainder(Fix64Temp x, Fix64Temp y) => (Fix64Temp)Math.IEEERemainder((double)x, (double)y);
            Fix64Temp IMath<Fix64Temp>.Log(Fix64Temp x) => (Fix64Temp)Math.Log((double)x);
            Fix64Temp IMath<Fix64Temp>.Log(Fix64Temp x, Fix64Temp y) => (Fix64Temp)Math.Log((double)x, (double)y);
            Fix64Temp IMath<Fix64Temp>.Log10(Fix64Temp x) => (Fix64Temp)Math.Log10((double)x);
            Fix64Temp IMath<Fix64Temp>.Max(Fix64Temp x, Fix64Temp y) => new Fix64Temp(Math.Max(x._scaledValue, y._scaledValue));
            Fix64Temp IMath<Fix64Temp>.Min(Fix64Temp x, Fix64Temp y) => new Fix64Temp(Math.Min(x._scaledValue, y._scaledValue));
            Fix64Temp IMath<Fix64Temp>.PI { get; } = (Fix64Temp)Math.PI;
            Fix64Temp IMath<Fix64Temp>.Pow(Fix64Temp x, Fix64Temp y) => y == 1 ? x : (Fix64Temp)Math.Pow((double)x, (double)y);
            Fix64Temp IMath<Fix64Temp>.Round(Fix64Temp x) => Round(x, 0, MidpointRounding.ToEven);
            Fix64Temp IMath<Fix64Temp>.Round(Fix64Temp x, int digits) => Round(x, digits, MidpointRounding.ToEven);
            Fix64Temp IMath<Fix64Temp>.Round(Fix64Temp x, int digits, MidpointRounding mode) => Round(x, digits, mode);
            Fix64Temp IMath<Fix64Temp>.Round(Fix64Temp x, MidpointRounding mode) => Round(x, 0, mode);
            Fix64Temp IMath<Fix64Temp>.Sin(Fix64Temp x) => (Fix64Temp)Math.Sin((double)x);
            Fix64Temp IMath<Fix64Temp>.Sinh(Fix64Temp x) => (Fix64Temp)Math.Sinh((double)x);
            Fix64Temp IMath<Fix64Temp>.Sqrt(Fix64Temp x) => (Fix64Temp)Math.Sqrt((double)x);
            Fix64Temp IMath<Fix64Temp>.Tan(Fix64Temp x) => (Fix64Temp)Math.Tan((double)x);
            Fix64Temp IMath<Fix64Temp>.Tanh(Fix64Temp x) => (Fix64Temp)Math.Tanh((double)x);
            Fix64Temp IMath<Fix64Temp>.Tau { get; } = (Fix64Temp)(Math.PI * 2d);
            Fix64Temp IMath<Fix64Temp>.Truncate(Fix64Temp x) => new Fix64Temp(x._scaledValue / ScalingFactor * ScalingFactor);
            int IMath<Fix64Temp>.Sign(Fix64Temp x) => Math.Sign(x._scaledValue);

            int INumericBitConverter<Fix64Temp>.ConvertedSize => sizeof(long);
            Fix64Temp INumericBitConverter<Fix64Temp>.ToNumeric(byte[] value, int startIndex) => new Fix64Temp(BitConverter.ToInt64(value, startIndex));
            byte[] INumericBitConverter<Fix64Temp>.GetBytes(Fix64Temp value) => BitConverter.GetBytes(value._scaledValue);

            bool IConvert<Fix64Temp>.ToBoolean(Fix64Temp value) => value._scaledValue != 0;
            byte IConvert<Fix64Temp>.ToByte(Fix64Temp value, Conversion mode) => ConvertN.ToByte(value._scaledValue / ScalingFactor, mode);
            decimal IConvert<Fix64Temp>.ToDecimal(Fix64Temp value, Conversion mode) => (decimal)value._scaledValue / ScalingFactor;
            double IConvert<Fix64Temp>.ToDouble(Fix64Temp value, Conversion mode) => Scaled.ToDouble(value._scaledValue, ScalingFactor);
            float IConvert<Fix64Temp>.ToSingle(Fix64Temp value, Conversion mode) => (float)value._scaledValue / ScalingFactor;
            int IConvert<Fix64Temp>.ToInt32(Fix64Temp value, Conversion mode) => ConvertN.ToInt32(value._scaledValue / ScalingFactor, mode);
            long IConvert<Fix64Temp>.ToInt64(Fix64Temp value, Conversion mode) => value._scaledValue / ScalingFactor;
            sbyte IConvertExtended<Fix64Temp>.ToSByte(Fix64Temp value, Conversion mode) => ConvertN.ToSByte(value._scaledValue / ScalingFactor, mode);
            short IConvert<Fix64Temp>.ToInt16(Fix64Temp value, Conversion mode) => ConvertN.ToInt16(value._scaledValue / ScalingFactor, mode);
            string IConvert<Fix64Temp>.ToString(Fix64Temp value) => value.ToString();
            uint IConvertExtended<Fix64Temp>.ToUInt32(Fix64Temp value, Conversion mode) => ConvertN.ToUInt32(value._scaledValue / ScalingFactor, mode);
            ulong IConvertExtended<Fix64Temp>.ToUInt64(Fix64Temp value, Conversion mode) => ConvertN.ToUInt64(value._scaledValue / ScalingFactor, mode);
            ushort IConvertExtended<Fix64Temp>.ToUInt16(Fix64Temp value, Conversion mode) => ConvertN.ToUInt16(value._scaledValue / ScalingFactor, mode);

            Fix64Temp IConvert<Fix64Temp>.ToNumeric(bool value) => value ? ScalingFactor : 0;
            Fix64Temp IConvert<Fix64Temp>.ToNumeric(byte value, Conversion mode) => (Fix64Temp)ConvertN.ToInt64(value, mode);
            Fix64Temp IConvert<Fix64Temp>.ToNumeric(decimal value, Conversion mode) => (Fix64Temp)value;
            Fix64Temp IConvert<Fix64Temp>.ToNumeric(double value, Conversion mode) => (Fix64Temp)value;
            Fix64Temp IConvert<Fix64Temp>.ToNumeric(float value, Conversion mode) => value;
            Fix64Temp IConvert<Fix64Temp>.ToNumeric(int value, Conversion mode) => (Fix64Temp)ConvertN.ToInt64(value, mode);
            Fix64Temp IConvert<Fix64Temp>.ToNumeric(long value, Conversion mode) => (Fix64Temp)value;
            Fix64Temp IConvertExtended<Fix64Temp>.ToValue(sbyte value, Conversion mode) => (Fix64Temp)ConvertN.ToInt64(value, mode);
            Fix64Temp IConvert<Fix64Temp>.ToNumeric(short value, Conversion mode) => (Fix64Temp)ConvertN.ToInt64(value, mode);
            Fix64Temp IConvert<Fix64Temp>.ToNumeric(string value) => (Fix64Temp)Convert.ToInt64(value);
            Fix64Temp IConvertExtended<Fix64Temp>.ToNumeric(uint value, Conversion mode) => (Fix64Temp)ConvertN.ToInt64(value, mode);
            Fix64Temp IConvertExtended<Fix64Temp>.ToNumeric(ulong value, Conversion mode) => (Fix64Temp)ConvertN.ToInt64(value, mode);
            Fix64Temp IConvertExtended<Fix64Temp>.ToNumeric(ushort value, Conversion mode) => (Fix64Temp)ConvertN.ToInt64(value, mode);

            Fix64Temp INumericStatic<Fix64Temp>.Parse(string s, NumberStyles? style, IFormatProvider? provider)
                => Parse(s, style ?? NumberStyles.Number, provider);

            Fix64Temp INumericRandom<Fix64Temp>.Generate(Random random) => new Fix64Temp(random.NextInt64(ScalingFactor));
            Fix64Temp INumericRandom<Fix64Temp>.Generate(Random random, Fix64Temp maxValue) => new Fix64Temp(random.NextInt64(maxValue._scaledValue));
            Fix64Temp INumericRandom<Fix64Temp>.Generate(Random random, Fix64Temp minValue, Fix64Temp maxValue) => new Fix64Temp(random.NextInt64(minValue._scaledValue, maxValue._scaledValue));
            Fix64Temp INumericRandom<Fix64Temp>.Generate(Random random, Generation mode) => new Fix64Temp(random.NextInt64(mode == Generation.Extended ? long.MinValue : 0, mode == Generation.Extended ? long.MaxValue : ScalingFactor, mode));
            Fix64Temp INumericRandom<Fix64Temp>.Generate(Random random, Fix64Temp minValue, Fix64Temp maxValue, Generation mode) => new Fix64Temp(random.NextInt64(minValue._scaledValue, maxValue._scaledValue, mode));

            Fix64Temp IVariantRandom<Fix64Temp>.Generate(Random random, Variants scenarios) => NumericVariant.Generate<Fix64Temp>(random, scenarios);
        }
    }
}
