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
    /// <summary>
    /// Represents a decimal fixed-point number that cannot overflow.
    /// </summary>
    [Serializable]
    [DebuggerDisplay("{ToString(),nq}")]
    public readonly struct Fix64C : INumericExtended<Fix64C>
    {
        public static readonly Fix64C Epsilon = new Fix64C(1);
        public static readonly Fix64C MaxValue = new Fix64C(long.MaxValue);
        public static readonly Fix64C MinValue = new Fix64C(long.MinValue);

        private const long ScalingFactor = 1_000_000;

        private readonly long _scaledValue;

        private Fix64C(long scaledValue)
        {
            _scaledValue = scaledValue;
        }

        private Fix64C(SerializationInfo info, StreamingContext context) : this(info.GetInt64(nameof(Fix64C))) { }
        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context) => info.AddValue(nameof(Fix64C), _scaledValue);

        public int CompareTo(Fix64C other) => _scaledValue.CompareTo(other._scaledValue);
        public int CompareTo(object? obj) => obj is Fix64C other ? CompareTo(other) : 1;
        public bool Equals(Fix64C other) => _scaledValue == other._scaledValue;
        public override bool Equals(object? obj) => obj is Fix64C other && Equals(other);
        public override int GetHashCode() => _scaledValue.GetHashCode();
        public override string ToString() => ScaledMath.ToString(_scaledValue, ScalingFactor, null);
        public string ToString(IFormatProvider formatProvider) => ((double)this).ToString(formatProvider);
        public string ToString(string format) => ((double)this).ToString(format);
        public string ToString(string? format, IFormatProvider? formatProvider) => ((double)this).ToString(format, formatProvider);

        public static bool TryParse(string s, IFormatProvider? provider, out Fix64C result) => TryHelper.Run(() => Parse(s, provider), out result);
        public static bool TryParse(string s, NumberStyles style, IFormatProvider? provider, out Fix64C result) => TryHelper.Run(() => Parse(s, style, provider), out result);
        public static bool TryParse(string s, NumberStyles style, out Fix64C result) => TryHelper.Run(() => Parse(s, style), out result);
        public static bool TryParse(string s, out Fix64C result) => TryHelper.Run(() => Parse(s), out result);
        public static Fix64C Parse(string s) => new Fix64C(ScaledMath.Parse(s, ScalingFactor, null, null));
        public static Fix64C Parse(string s, IFormatProvider? provider) => (Fix64C)double.Parse(s, provider);
        public static Fix64C Parse(string s, NumberStyles style) => (Fix64C)double.Parse(s, style);
        public static Fix64C Parse(string s, NumberStyles style, IFormatProvider? provider) => (Fix64C)double.Parse(s, style, provider);

        private static Fix64C Round(Fix64C value, int digits, MidpointRounding mode)
        {
            if (digits < 0) throw new ArgumentOutOfRangeException(nameof(digits), digits, "Must be positive.");
            if (digits > 5) return value;
            return new Fix64C(ScaledMath.Round(value._scaledValue, 6 - digits, mode));
        }

        [SuppressMessage("Style", "JSON002:Probable JSON string detected", Justification = "False positive")]
        private static Fix64C FromDouble(double value)
        {
            string str = string
                .Format(CultureInfo.InvariantCulture, "{0:0.0000000}", value)
                .Replace(".", string.Empty);
            str = str.Substring(0, str.Length - 1);
            if (long.TryParse(str, out long lng))
            {
                return new Fix64C(lng);
            }
            else
            {
                if (value > 0) return MaxValue;
                return MinValue;
            }
        }

        private static double ToDouble(Fix64C value)
        {
            long integral = value._scaledValue / ScalingFactor;
            long mantissa = value._scaledValue % ScalingFactor;

            double result = (double)mantissa / ScalingFactor;
            result += integral;
            return result;
        }

        [CLSCompliant(false)] public static explicit operator Fix64C(ulong value) => new Fix64C(ConvertN.ToInt64(value * ScalingFactor, Conversion.CastClamp));
        [CLSCompliant(false)] public static implicit operator Fix64C(sbyte value) => new Fix64C(value * ScalingFactor);
        [CLSCompliant(false)] public static implicit operator Fix64C(uint value) => new Fix64C(value * ScalingFactor);
        [CLSCompliant(false)] public static implicit operator Fix64C(ushort value) => new Fix64C(value * ScalingFactor);
        public static explicit operator Fix64C(decimal value) => new Fix64C(ConvertN.ToInt64(CheckedMath.Multiply(value, ScalingFactor), Conversion.CastClamp));
        public static explicit operator Fix64C(double value) => FromDouble(value);
        public static explicit operator Fix64C(long value) => new Fix64C(value * ScalingFactor);
        public static implicit operator Fix64C(byte value) => new Fix64C(value * ScalingFactor);
        public static implicit operator Fix64C(float value) => new Fix64C(ConvertN.ToInt64(value * ScalingFactor, Conversion.CastClamp));
        public static implicit operator Fix64C(int value) => new Fix64C(value * ScalingFactor);
        public static implicit operator Fix64C(short value) => new Fix64C(value * ScalingFactor);

        [CLSCompliant(false)] public static explicit operator sbyte(Fix64C value) => ConvertN.ToSByte(value._scaledValue / ScalingFactor, Conversion.CastClamp);
        [CLSCompliant(false)] public static explicit operator uint(Fix64C value) => ConvertN.ToUInt32(value._scaledValue / ScalingFactor, Conversion.CastClamp);
        [CLSCompliant(false)] public static explicit operator ulong(Fix64C value) => ConvertN.ToUInt64(value._scaledValue / ScalingFactor, Conversion.CastClamp);
        [CLSCompliant(false)] public static explicit operator ushort(Fix64C value) => ConvertN.ToUInt16(value._scaledValue / ScalingFactor, Conversion.CastClamp);
        public static explicit operator byte(Fix64C value) => ConvertN.ToByte(value._scaledValue / ScalingFactor, Conversion.CastClamp);
        public static explicit operator decimal(Fix64C value) => (decimal)value._scaledValue / ScalingFactor;
        public static explicit operator double(Fix64C value) => ToDouble(value);
        public static explicit operator float(Fix64C value) => (float)value._scaledValue / ScalingFactor;
        public static explicit operator int(Fix64C value) => ConvertN.ToInt32(value._scaledValue / ScalingFactor, Conversion.CastClamp);
        public static explicit operator long(Fix64C value) => value._scaledValue / ScalingFactor;
        public static explicit operator short(Fix64C value) => ConvertN.ToInt16(value._scaledValue / ScalingFactor, Conversion.CastClamp);

        public static bool operator !=(Fix64C left, Fix64C right) => left._scaledValue != right._scaledValue;
        public static bool operator <(Fix64C left, Fix64C right) => left._scaledValue < right._scaledValue;
        public static bool operator <=(Fix64C left, Fix64C right) => left._scaledValue <= right._scaledValue;
        public static bool operator ==(Fix64C left, Fix64C right) => left._scaledValue == right._scaledValue;
        public static bool operator >(Fix64C left, Fix64C right) => left._scaledValue > right._scaledValue;
        public static bool operator >=(Fix64C left, Fix64C right) => left._scaledValue >= right._scaledValue;
        public static Fix64C operator %(Fix64C left, Fix64C right) => new Fix64C(CheckedMath.Remainder(left._scaledValue, right._scaledValue));
        public static Fix64C operator &(Fix64C left, Fix64C right) => new Fix64C(left._scaledValue & right._scaledValue);
        public static Fix64C operator -(Fix64C left, Fix64C right) => new Fix64C(CheckedMath.Subtract(left._scaledValue, right._scaledValue));
        public static Fix64C operator --(Fix64C value) => new Fix64C(value._scaledValue - ScalingFactor);
        public static Fix64C operator -(Fix64C value) => new Fix64C(-value._scaledValue);
        public static Fix64C operator *(Fix64C left, Fix64C right) => new Fix64C(CheckedMath.ScaledMultiply(left._scaledValue, right._scaledValue, ScalingFactor));
        public static Fix64C operator /(Fix64C left, Fix64C right) => new Fix64C(CheckedMath.ScaledDivide(left._scaledValue, right._scaledValue, ScalingFactor));
        public static Fix64C operator ^(Fix64C left, Fix64C right) => new Fix64C(left._scaledValue ^ right._scaledValue);
        public static Fix64C operator |(Fix64C left, Fix64C right) => new Fix64C(left._scaledValue | right._scaledValue);
        public static Fix64C operator ~(Fix64C value) => new Fix64C(~value._scaledValue);
        public static Fix64C operator +(Fix64C left, Fix64C right) => new Fix64C(CheckedMath.Add(left._scaledValue, right._scaledValue));
        public static Fix64C operator +(Fix64C value) => value;
        public static Fix64C operator ++(Fix64C value) => new Fix64C(value._scaledValue + ScalingFactor);
        public static Fix64C operator <<(Fix64C left, int right) => new Fix64C(left._scaledValue << right);
        public static Fix64C operator >>(Fix64C left, int right) => new Fix64C(left._scaledValue >> right);

        TypeCode IConvertible.GetTypeCode() => TypeCode.Object;
        bool IConvertible.ToBoolean(IFormatProvider provider) => ((IConvert<Fix64C>)Utilities.Instance).ToBoolean(this);
        byte IConvertible.ToByte(IFormatProvider provider) => ((IConvert<Fix64C>)Utilities.Instance).ToByte(this, Conversion.Clamp);
        char IConvertible.ToChar(IFormatProvider provider) => ((IConvertible)((IConvert<Fix64C>)Utilities.Instance).ToDouble(this, Conversion.Clamp)).ToChar(provider);
        DateTime IConvertible.ToDateTime(IFormatProvider provider) => ((IConvertible)((IConvert<Fix64C>)Utilities.Instance).ToDouble(this, Conversion.Clamp)).ToDateTime(provider);
        decimal IConvertible.ToDecimal(IFormatProvider provider) => ((IConvert<Fix64C>)Utilities.Instance).ToDecimal(this, Conversion.Clamp);
        double IConvertible.ToDouble(IFormatProvider provider) => ((IConvert<Fix64C>)Utilities.Instance).ToDouble(this, Conversion.Clamp);
        float IConvertible.ToSingle(IFormatProvider provider) => ((IConvert<Fix64C>)Utilities.Instance).ToSingle(this, Conversion.Clamp);
        int IConvertible.ToInt32(IFormatProvider provider) => ((IConvert<Fix64C>)Utilities.Instance).ToInt32(this, Conversion.Clamp);
        long IConvertible.ToInt64(IFormatProvider provider) => ((IConvert<Fix64C>)Utilities.Instance).ToInt64(this, Conversion.Clamp);
        sbyte IConvertible.ToSByte(IFormatProvider provider) => ((IConvertExtended<Fix64C>)Utilities.Instance).ToSByte(this, Conversion.Clamp);
        short IConvertible.ToInt16(IFormatProvider provider) => ((IConvert<Fix64C>)Utilities.Instance).ToInt16(this, Conversion.Clamp);
        uint IConvertible.ToUInt32(IFormatProvider provider) => ((IConvertExtended<Fix64C>)Utilities.Instance).ToUInt32(this, Conversion.Clamp);
        ulong IConvertible.ToUInt64(IFormatProvider provider) => ((IConvertExtended<Fix64C>)Utilities.Instance).ToUInt64(this, Conversion.Clamp);
        ushort IConvertible.ToUInt16(IFormatProvider provider) => ((IConvertExtended<Fix64C>)Utilities.Instance).ToUInt16(this, Conversion.Clamp);
        object IConvertible.ToType(Type conversionType, IFormatProvider provider) => this.ToTypeDefault(conversionType, provider);

        bool INumeric<Fix64C>.IsGreaterThan(Fix64C value) => this > value;
        bool INumeric<Fix64C>.IsGreaterThanOrEqualTo(Fix64C value) => this >= value;
        bool INumeric<Fix64C>.IsLessThan(Fix64C value) => this < value;
        bool INumeric<Fix64C>.IsLessThanOrEqualTo(Fix64C value) => this <= value;
        Fix64C INumeric<Fix64C>.Add(Fix64C value) => this + value;
        Fix64C INumeric<Fix64C>.BitwiseComplement() => ~this;
        Fix64C INumeric<Fix64C>.Divide(Fix64C value) => this / value;
        Fix64C INumeric<Fix64C>.LeftShift(int count) => this << count;
        Fix64C INumeric<Fix64C>.LogicalAnd(Fix64C value) => this & value;
        Fix64C INumeric<Fix64C>.LogicalExclusiveOr(Fix64C value) => this ^ value;
        Fix64C INumeric<Fix64C>.LogicalOr(Fix64C value) => this | value;
        Fix64C INumeric<Fix64C>.Multiply(Fix64C value) => this * value;
        Fix64C INumeric<Fix64C>.Negative() => -this;
        Fix64C INumeric<Fix64C>.Positive() => +this;
        Fix64C INumeric<Fix64C>.Remainder(Fix64C value) => this % value;
        Fix64C INumeric<Fix64C>.RightShift(int count) => this >> count;
        Fix64C INumeric<Fix64C>.Subtract(Fix64C value) => this - value;

        INumericBitConverter<Fix64C> IProvider<INumericBitConverter<Fix64C>>.GetInstance() => Utilities.Instance;
        IConvert<Fix64C> IProvider<IConvert<Fix64C>>.GetInstance() => Utilities.Instance;
        IConvertExtended<Fix64C> IProvider<IConvertExtended<Fix64C>>.GetInstance() => Utilities.Instance;
        IMath<Fix64C> IProvider<IMath<Fix64C>>.GetInstance() => Utilities.Instance;
        INumericRandom<Fix64C> IProvider<INumericRandom<Fix64C>>.GetInstance() => Utilities.Instance;
        INumericStatic<Fix64C> IProvider<INumericStatic<Fix64C>>.GetInstance() => Utilities.Instance;
        IVariantRandom<Fix64C> IProvider<IVariantRandom<Fix64C>>.GetInstance() => Utilities.Instance;

        private sealed class Utilities :
            INumericBitConverter<Fix64C>,
            IConvert<Fix64C>,
            IConvertExtended<Fix64C>,
            IMath<Fix64C>,
            INumericRandom<Fix64C>,
            INumericStatic<Fix64C>,
            IVariantRandom<Fix64C>
        {
            public static readonly Utilities Instance = new Utilities();

            bool INumericStatic<Fix64C>.HasFloatingPoint => false;
            bool INumericStatic<Fix64C>.HasInfinity => false;
            bool INumericStatic<Fix64C>.HasNaN => false;
            bool INumericStatic<Fix64C>.IsFinite(Fix64C x) => true;
            bool INumericStatic<Fix64C>.IsInfinity(Fix64C x) => false;
            bool INumericStatic<Fix64C>.IsNaN(Fix64C x) => false;
            bool INumericStatic<Fix64C>.IsNegative(Fix64C x) => x._scaledValue < 0;
            bool INumericStatic<Fix64C>.IsNegativeInfinity(Fix64C x) => false;
            bool INumericStatic<Fix64C>.IsNormal(Fix64C x) => false;
            bool INumericStatic<Fix64C>.IsPositiveInfinity(Fix64C x) => false;
            bool INumericStatic<Fix64C>.IsReal => true;
            bool INumericStatic<Fix64C>.IsSigned => true;
            bool INumericStatic<Fix64C>.IsSubnormal(Fix64C x) => false;
            Fix64C INumericStatic<Fix64C>.Epsilon { get; } = new Fix64C(1);
            Fix64C INumericStatic<Fix64C>.MaxUnit { get; } = new Fix64C(ScalingFactor);
            Fix64C INumericStatic<Fix64C>.MaxValue => MaxValue;
            Fix64C INumericStatic<Fix64C>.MinUnit { get; } = new Fix64C(-ScalingFactor);
            Fix64C INumericStatic<Fix64C>.MinValue => MinValue;
            Fix64C INumericStatic<Fix64C>.One { get; } = new Fix64C(ScalingFactor);
            Fix64C INumericStatic<Fix64C>.Ten { get; } = new Fix64C(10 * ScalingFactor);
            Fix64C INumericStatic<Fix64C>.Two { get; } = new Fix64C(2 * ScalingFactor);
            Fix64C INumericStatic<Fix64C>.Zero => 0;

            Fix64C IMath<Fix64C>.Abs(Fix64C value) => value._scaledValue < 0 ? -value : value;
            Fix64C IMath<Fix64C>.Acos(Fix64C x) => (Fix64C)Math.Acos((double)x);
            Fix64C IMath<Fix64C>.Acosh(Fix64C x) => (Fix64C)MathCompat.Acosh((double)x);
            Fix64C IMath<Fix64C>.Asin(Fix64C x) => (Fix64C)Math.Asin((double)x);
            Fix64C IMath<Fix64C>.Asinh(Fix64C x) => (Fix64C)MathCompat.Asinh((double)x);
            Fix64C IMath<Fix64C>.Atan(Fix64C x) => (Fix64C)Math.Atan((double)x);
            Fix64C IMath<Fix64C>.Atan2(Fix64C x, Fix64C y) => (Fix64C)Math.Atan2((double)x, (double)y);
            Fix64C IMath<Fix64C>.Atanh(Fix64C x) => (Fix64C)MathCompat.Atanh((double)x);
            Fix64C IMath<Fix64C>.Cbrt(Fix64C x) => (Fix64C)MathCompat.Cbrt((double)x);
            Fix64C IMath<Fix64C>.Ceiling(Fix64C x) => new Fix64C(ScaledMath.Ceiling(x._scaledValue, ScalingFactor));
            Fix64C IMath<Fix64C>.Clamp(Fix64C x, Fix64C bound1, Fix64C bound2) => new Fix64C(bound1 > bound2 ? Math.Min(bound1._scaledValue, Math.Max(bound2._scaledValue, x._scaledValue)) : Math.Min(bound2._scaledValue, Math.Max(bound1._scaledValue, x._scaledValue)));
            Fix64C IMath<Fix64C>.Cos(Fix64C x) => (Fix64C)Math.Cos((double)x);
            Fix64C IMath<Fix64C>.Cosh(Fix64C x) => (Fix64C)Math.Cosh((double)x);
            Fix64C IMath<Fix64C>.DegreesToRadians(Fix64C x) => (Fix64C)CheckedMath.Multiply((double)x, BitOperations.RadiansPerDegree);
            Fix64C IMath<Fix64C>.E { get; } = (Fix64C)Math.E;
            Fix64C IMath<Fix64C>.Exp(Fix64C x) => (Fix64C)Math.Exp((double)x);
            Fix64C IMath<Fix64C>.Floor(Fix64C x) => new Fix64C(ScaledMath.Floor(x._scaledValue, ScalingFactor));
            Fix64C IMath<Fix64C>.IEEERemainder(Fix64C x, Fix64C y) => (Fix64C)Math.IEEERemainder((double)x, (double)y);
            Fix64C IMath<Fix64C>.Log(Fix64C x) => (Fix64C)Math.Log((double)x);
            Fix64C IMath<Fix64C>.Log(Fix64C x, Fix64C y) => (Fix64C)Math.Log((double)x, (double)y);
            Fix64C IMath<Fix64C>.Log10(Fix64C x) => (Fix64C)Math.Log10((double)x);
            Fix64C IMath<Fix64C>.Max(Fix64C x, Fix64C y) => new Fix64C(Math.Max(x._scaledValue, y._scaledValue));
            Fix64C IMath<Fix64C>.Min(Fix64C x, Fix64C y) => new Fix64C(Math.Min(x._scaledValue, y._scaledValue));
            Fix64C IMath<Fix64C>.PI { get; } = (Fix64C)Math.PI;
            Fix64C IMath<Fix64C>.Pow(Fix64C x, Fix64C y) => y == 1 ? x : (Fix64C)Math.Pow((double)x, (double)y);
            Fix64C IMath<Fix64C>.RadiansToDegrees(Fix64C x) => (Fix64C)CheckedMath.Multiply((double)x, BitOperations.DegreesPerRadian);
            Fix64C IMath<Fix64C>.Round(Fix64C x) => Round(x, 0, MidpointRounding.ToEven);
            Fix64C IMath<Fix64C>.Round(Fix64C x, int digits) => Round(x, digits, MidpointRounding.ToEven);
            Fix64C IMath<Fix64C>.Round(Fix64C x, int digits, MidpointRounding mode) => Round(x, digits, mode);
            Fix64C IMath<Fix64C>.Round(Fix64C x, MidpointRounding mode) => Round(x, 0, mode);
            Fix64C IMath<Fix64C>.Sin(Fix64C x) => (Fix64C)Math.Sin((double)x);
            Fix64C IMath<Fix64C>.Sinh(Fix64C x) => (Fix64C)Math.Sinh((double)x);
            Fix64C IMath<Fix64C>.Sqrt(Fix64C x) => (Fix64C)Math.Sqrt((double)x);
            Fix64C IMath<Fix64C>.Tan(Fix64C x) => (Fix64C)Math.Tan((double)x);
            Fix64C IMath<Fix64C>.Tanh(Fix64C x) => (Fix64C)Math.Tanh((double)x);
            Fix64C IMath<Fix64C>.Tau { get; } = (Fix64C)(Math.PI * 2d);
            Fix64C IMath<Fix64C>.Truncate(Fix64C x) => new Fix64C(x._scaledValue / ScalingFactor * ScalingFactor);
            int IMath<Fix64C>.Sign(Fix64C x) => Math.Sign(x._scaledValue);

            Fix64C INumericBitConverter<Fix64C>.Read(IReader<byte> stream) => new Fix64C(BitConverter.ToInt64(stream.Read(sizeof(long)), 0));
            void INumericBitConverter<Fix64C>.Write(Fix64C value, IWriter<byte> stream) => stream.Write(BitConverter.GetBytes(value._scaledValue));

            bool IConvert<Fix64C>.ToBoolean(Fix64C value) => value._scaledValue != 0;
            byte IConvert<Fix64C>.ToByte(Fix64C value, Conversion mode) => ConvertN.ToByte(value._scaledValue / ScalingFactor, mode.Clamped());
            decimal IConvert<Fix64C>.ToDecimal(Fix64C value, Conversion mode) => (decimal)value._scaledValue / ScalingFactor;
            double IConvert<Fix64C>.ToDouble(Fix64C value, Conversion mode) => (double)value._scaledValue / ScalingFactor;
            float IConvert<Fix64C>.ToSingle(Fix64C value, Conversion mode) => (float)value._scaledValue / ScalingFactor;
            int IConvert<Fix64C>.ToInt32(Fix64C value, Conversion mode) => ConvertN.ToInt32(value._scaledValue / ScalingFactor, mode.Clamped());
            long IConvert<Fix64C>.ToInt64(Fix64C value, Conversion mode) => value._scaledValue / ScalingFactor;
            sbyte IConvertExtended<Fix64C>.ToSByte(Fix64C value, Conversion mode) => ConvertN.ToSByte(value._scaledValue / ScalingFactor, mode.Clamped());
            short IConvert<Fix64C>.ToInt16(Fix64C value, Conversion mode) => ConvertN.ToInt16(value._scaledValue / ScalingFactor, mode.Clamped());
            string IConvert<Fix64C>.ToString(Fix64C value) => value.ToString();
            uint IConvertExtended<Fix64C>.ToUInt32(Fix64C value, Conversion mode) => ConvertN.ToUInt32(value._scaledValue / ScalingFactor, mode.Clamped());
            ulong IConvertExtended<Fix64C>.ToUInt64(Fix64C value, Conversion mode) => ConvertN.ToUInt64(value._scaledValue / ScalingFactor, mode.Clamped());
            ushort IConvertExtended<Fix64C>.ToUInt16(Fix64C value, Conversion mode) => ConvertN.ToUInt16(value._scaledValue / ScalingFactor, mode.Clamped());

            Fix64C IConvert<Fix64C>.ToNumeric(bool value) => value ? ScalingFactor : 0;
            Fix64C IConvert<Fix64C>.ToNumeric(byte value, Conversion mode) => (Fix64C)ConvertN.ToInt64(value, mode.Clamped());
            Fix64C IConvert<Fix64C>.ToNumeric(decimal value, Conversion mode) => (Fix64C)value;
            Fix64C IConvert<Fix64C>.ToNumeric(double value, Conversion mode) => (Fix64C)value;
            Fix64C IConvert<Fix64C>.ToNumeric(float value, Conversion mode) => value;
            Fix64C IConvert<Fix64C>.ToNumeric(int value, Conversion mode) => (Fix64C)ConvertN.ToInt64(value, mode.Clamped());
            Fix64C IConvert<Fix64C>.ToNumeric(long value, Conversion mode) => (Fix64C)value;
            Fix64C IConvertExtended<Fix64C>.ToValue(sbyte value, Conversion mode) => (Fix64C)ConvertN.ToInt64(value, mode.Clamped());
            Fix64C IConvert<Fix64C>.ToNumeric(short value, Conversion mode) => (Fix64C)ConvertN.ToInt64(value, mode.Clamped());
            Fix64C IConvert<Fix64C>.ToNumeric(string value) => (Fix64C)Convert.ToInt64(value);
            Fix64C IConvertExtended<Fix64C>.ToNumeric(uint value, Conversion mode) => (Fix64C)ConvertN.ToInt64(value, mode.Clamped());
            Fix64C IConvertExtended<Fix64C>.ToNumeric(ulong value, Conversion mode) => (Fix64C)ConvertN.ToInt64(value, mode.Clamped());
            Fix64C IConvertExtended<Fix64C>.ToNumeric(ushort value, Conversion mode) => (Fix64C)ConvertN.ToInt64(value, mode.Clamped());

            Fix64C INumericStatic<Fix64C>.Parse(string s, NumberStyles? style, IFormatProvider? provider)
                => Parse(s, style ?? NumberStyles.Number, provider);

            Fix64C INumericRandom<Fix64C>.Next(Random random) => new Fix64C(random.NextInt64());
            Fix64C INumericRandom<Fix64C>.Next(Random random, Fix64C maxValue) => new Fix64C(random.NextInt64(maxValue._scaledValue));
            Fix64C INumericRandom<Fix64C>.Next(Random random, Fix64C minValue, Fix64C maxValue) => new Fix64C(random.NextInt64(minValue._scaledValue, maxValue._scaledValue));
            Fix64C INumericRandom<Fix64C>.Next(Random random, Generation mode) => new Fix64C(random.NextInt64(mode));
            Fix64C INumericRandom<Fix64C>.Next(Random random, Fix64C minValue, Fix64C maxValue, Generation mode) => new Fix64C(random.NextInt64(minValue._scaledValue, maxValue._scaledValue, mode));

            Fix64C IVariantRandom<Fix64C>.Next(Random random, Scenarios scenarios) => NumericVariant.Generate<Fix64C>(random, scenarios);
        }
    }
}
