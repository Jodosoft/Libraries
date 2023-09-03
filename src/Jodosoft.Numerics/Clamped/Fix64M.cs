// Copyright (c) 2023 Joe Lawry-Short
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
using System.IO;
using System.Runtime.Serialization;
using Jodosoft.Primitives;
using Jodosoft.Primitives.Compatibility;

namespace Jodosoft.Numerics.Clamped
{
    /// <summary>
    /// Represents a decimal fixed-point number that cannot overflow.
    /// </summary>
    [Serializable]
    [DebuggerDisplay("{ToString(),nq}")]
    public readonly struct Fix64M : INumericExtended<Fix64M>
    {
        public static readonly Fix64M Epsilon = new Fix64M(1);
        public static readonly Fix64M MaxValue = new Fix64M(long.MaxValue);
        public static readonly Fix64M MinValue = new Fix64M(long.MinValue);

        private const long ScalingFactor = 1_000_000;

        private readonly long _scaledValue;

        private Fix64M(long scaledValue)
        {
            _scaledValue = scaledValue;
        }

        private Fix64M(SerializationInfo info, StreamingContext context) : this(info.GetInt64(nameof(Fix64M))) { }
        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context) => info.AddValue(nameof(Fix64M), _scaledValue);

        public int CompareTo(Fix64M other) => _scaledValue.CompareTo(other._scaledValue);
        public int CompareTo(object? obj) => obj is Fix64M other ? CompareTo(other) : 1;
        public bool Equals(Fix64M other) => _scaledValue == other._scaledValue;
        public override bool Equals(object? obj) => obj is Fix64M other && Equals(other);
        public override int GetHashCode() => _scaledValue.GetHashCode();
        public override string ToString() => Scaled.ToString(_scaledValue, ScalingFactor, null);
        public string ToString(IFormatProvider formatProvider) => Scaled.ToString(_scaledValue, ScalingFactor, formatProvider);
        public string ToString(string format) => ((double)this).ToString(format);

        public string ToString(string? format, IFormatProvider? formatProvider)
        {
            if (format == null)
            {
                if (formatProvider == null) return ToString();
                return ToString(formatProvider);
            }
            if (formatProvider == null) return ToString(format);

            return ((double)this).ToString(format, formatProvider);
        }

        public static long GetScalingFactor() => ScalingFactor;
        public static long GetScaledValue(Fix64M value) => value._scaledValue;
        public static bool TryParse(string s, IFormatProvider? provider, out Fix64M result) => FuncExtensions.Try(() => Parse(s, provider), out result);
        public static bool TryParse(string s, NumberStyles style, IFormatProvider? provider, out Fix64M result) => FuncExtensions.Try(() => Parse(s, style, provider), out result);
        public static bool TryParse(string s, NumberStyles style, out Fix64M result) => FuncExtensions.Try(() => Parse(s, style), out result);
        public static bool TryParse(string s, out Fix64M result) => FuncExtensions.Try(() => Parse(s), out result);
        public static Fix64M Parse(string s) => new Fix64M(Scaled.Parse(s, ScalingFactor, null, null));
        public static Fix64M Parse(string s, IFormatProvider? provider) => (Fix64M)double.Parse(s, provider);
        public static Fix64M Parse(string s, NumberStyles style) => (Fix64M)double.Parse(s, style);
        public static Fix64M Parse(string s, NumberStyles style, IFormatProvider? provider) => (Fix64M)double.Parse(s, style, provider);

        private static Fix64M Round(Fix64M value, int digits, MidpointRounding mode)
        {
            if (digits < 0) throw new ArgumentOutOfRangeException(nameof(digits), digits, "Must be positive.");
            if (digits > 5) return value;
            return new Fix64M(Scaled.Round(value._scaledValue, 6 - digits, mode));
        }

        [SuppressMessage("Style", "JSON002:Probable JSON string detected", Justification = "False positive")]
        private static Fix64M FromDouble(double value)
        {
            string str = string
                .Format(CultureInfo.InvariantCulture, "{0:0.0000000}", value)
                .Replace(".", string.Empty);
            str = str.Substring(0, str.Length - 1);
            if (long.TryParse(str, out long lng))
            {
                return new Fix64M(lng);
            }
            else
            {
                if (value > 0) return MaxValue;
                return MinValue;
            }
        }

        [CLSCompliant(false)] public static explicit operator Fix64M(ulong value) => new Fix64M(ConvertN.ToInt64(Clamped.Multiply(value, ScalingFactor), Conversion.CastClamp));
        [CLSCompliant(false)] public static implicit operator Fix64M(sbyte value) => new Fix64M(value * ScalingFactor);
        [CLSCompliant(false)] public static implicit operator Fix64M(uint value) => new Fix64M(value * ScalingFactor);
        [CLSCompliant(false)] public static implicit operator Fix64M(ushort value) => new Fix64M(value * ScalingFactor);
        public static explicit operator Fix64M(decimal value) => new Fix64M(ConvertN.ToInt64(Clamped.Multiply(value, ScalingFactor), Conversion.CastClamp));
        public static explicit operator Fix64M(double value) => FromDouble(value);
        public static explicit operator Fix64M(float value) => new Fix64M(ConvertN.ToInt64(value * ScalingFactor, Conversion.CastClamp));
        public static explicit operator Fix64M(long value) => new Fix64M(Clamped.Multiply(value, ScalingFactor));
        public static implicit operator Fix64M(byte value) => new Fix64M(value * ScalingFactor);
        public static implicit operator Fix64M(int value) => new Fix64M(value * ScalingFactor);
        public static implicit operator Fix64M(short value) => new Fix64M(value * ScalingFactor);
        public static explicit operator Fix64M(UFix64M value) => new Fix64M(ConvertN.ToInt64(UFix64M.GetScaledValue(value), Conversion.CastClamp));

        [CLSCompliant(false)] public static explicit operator sbyte(Fix64M value) => ConvertN.ToSByte(value._scaledValue / ScalingFactor, Conversion.CastClamp);
        [CLSCompliant(false)] public static explicit operator uint(Fix64M value) => ConvertN.ToUInt32(value._scaledValue / ScalingFactor, Conversion.CastClamp);
        [CLSCompliant(false)] public static explicit operator ulong(Fix64M value) => ConvertN.ToUInt64(value._scaledValue / ScalingFactor, Conversion.CastClamp);
        [CLSCompliant(false)] public static explicit operator ushort(Fix64M value) => ConvertN.ToUInt16(value._scaledValue / ScalingFactor, Conversion.CastClamp);
        public static explicit operator byte(Fix64M value) => ConvertN.ToByte(value._scaledValue / ScalingFactor, Conversion.CastClamp);
        public static explicit operator decimal(Fix64M value) => (decimal)value._scaledValue / ScalingFactor;
        public static explicit operator double(Fix64M value) => Scaled.ToDouble(value._scaledValue, ScalingFactor);
        public static explicit operator float(Fix64M value) => (float)value._scaledValue / ScalingFactor;
        public static explicit operator int(Fix64M value) => ConvertN.ToInt32(value._scaledValue / ScalingFactor, Conversion.CastClamp);
        public static explicit operator long(Fix64M value) => value._scaledValue / ScalingFactor;
        public static explicit operator short(Fix64M value) => ConvertN.ToInt16(value._scaledValue / ScalingFactor, Conversion.CastClamp);

        public static bool operator !=(Fix64M left, Fix64M right) => left._scaledValue != right._scaledValue;
        public static bool operator <(Fix64M left, Fix64M right) => left._scaledValue < right._scaledValue;
        public static bool operator <=(Fix64M left, Fix64M right) => left._scaledValue <= right._scaledValue;
        public static bool operator ==(Fix64M left, Fix64M right) => left._scaledValue == right._scaledValue;
        public static bool operator >(Fix64M left, Fix64M right) => left._scaledValue > right._scaledValue;
        public static bool operator >=(Fix64M left, Fix64M right) => left._scaledValue >= right._scaledValue;
        public static Fix64M operator %(Fix64M left, Fix64M right) => new Fix64M(Clamped.Remainder(left._scaledValue, right._scaledValue));
        public static Fix64M operator &(Fix64M left, Fix64M right) => new Fix64M(left._scaledValue & right._scaledValue);
        public static Fix64M operator -(Fix64M left, Fix64M right) => new Fix64M(Clamped.Subtract(left._scaledValue, right._scaledValue));
        public static Fix64M operator --(Fix64M value) => new Fix64M(Clamped.Subtract(value._scaledValue, ScalingFactor));
        public static Fix64M operator -(Fix64M value) => new Fix64M(value._scaledValue == long.MinValue ? long.MaxValue : -value._scaledValue);
        public static Fix64M operator *(Fix64M left, Fix64M right) => new Fix64M(Clamped.ScaledMultiply(left._scaledValue, right._scaledValue, ScalingFactor));
        public static Fix64M operator /(Fix64M left, Fix64M right) => new Fix64M(Clamped.ScaledDivide(left._scaledValue, right._scaledValue, ScalingFactor));
        public static Fix64M operator ^(Fix64M left, Fix64M right) => new Fix64M(left._scaledValue ^ right._scaledValue);
        public static Fix64M operator |(Fix64M left, Fix64M right) => new Fix64M(left._scaledValue | right._scaledValue);
        public static Fix64M operator ~(Fix64M value) => new Fix64M(~value._scaledValue);
        public static Fix64M operator +(Fix64M left, Fix64M right) => new Fix64M(Clamped.Add(left._scaledValue, right._scaledValue));
        public static Fix64M operator +(Fix64M value) => value;
        public static Fix64M operator ++(Fix64M value) => new Fix64M(Clamped.Add(value._scaledValue, ScalingFactor));
        public static Fix64M operator <<(Fix64M left, int right) => new Fix64M(left._scaledValue << right);
        public static Fix64M operator >>(Fix64M left, int right) => new Fix64M(left._scaledValue >> right);

        TypeCode IConvertible.GetTypeCode() => TypeCode.Object;
        bool IConvertible.ToBoolean(IFormatProvider provider) => ((IConvert<Fix64M>)Utilities.Instance).ToBoolean(this);
        byte IConvertible.ToByte(IFormatProvider provider) => ((IConvert<Fix64M>)Utilities.Instance).ToByte(this, Conversion.Clamp);
        char IConvertible.ToChar(IFormatProvider provider) => ((IConvertible)((IConvert<Fix64M>)Utilities.Instance).ToDouble(this, Conversion.Clamp)).ToChar(provider);
        DateTime IConvertible.ToDateTime(IFormatProvider provider) => ((IConvertible)((IConvert<Fix64M>)Utilities.Instance).ToDouble(this, Conversion.Clamp)).ToDateTime(provider);
        decimal IConvertible.ToDecimal(IFormatProvider provider) => ((IConvert<Fix64M>)Utilities.Instance).ToDecimal(this, Conversion.Clamp);
        double IConvertible.ToDouble(IFormatProvider provider) => ((IConvert<Fix64M>)Utilities.Instance).ToDouble(this, Conversion.Clamp);
        float IConvertible.ToSingle(IFormatProvider provider) => ((IConvert<Fix64M>)Utilities.Instance).ToSingle(this, Conversion.Clamp);
        int IConvertible.ToInt32(IFormatProvider provider) => ((IConvert<Fix64M>)Utilities.Instance).ToInt32(this, Conversion.Clamp);
        long IConvertible.ToInt64(IFormatProvider provider) => ((IConvert<Fix64M>)Utilities.Instance).ToInt64(this, Conversion.Clamp);
        sbyte IConvertible.ToSByte(IFormatProvider provider) => ((IConvertExtended<Fix64M>)Utilities.Instance).ToSByte(this, Conversion.Clamp);
        short IConvertible.ToInt16(IFormatProvider provider) => ((IConvert<Fix64M>)Utilities.Instance).ToInt16(this, Conversion.Clamp);
        uint IConvertible.ToUInt32(IFormatProvider provider) => ((IConvertExtended<Fix64M>)Utilities.Instance).ToUInt32(this, Conversion.Clamp);
        ulong IConvertible.ToUInt64(IFormatProvider provider) => ((IConvertExtended<Fix64M>)Utilities.Instance).ToUInt64(this, Conversion.Clamp);
        ushort IConvertible.ToUInt16(IFormatProvider provider) => ((IConvertExtended<Fix64M>)Utilities.Instance).ToUInt16(this, Conversion.Clamp);
        object IConvertible.ToType(Type conversionType, IFormatProvider provider) => this.ToTypeDefault(conversionType, provider);

        bool INumeric<Fix64M>.IsGreaterThan(Fix64M value) => this > value;
        bool INumeric<Fix64M>.IsGreaterThanOrEqualTo(Fix64M value) => this >= value;
        bool INumeric<Fix64M>.IsLessThan(Fix64M value) => this < value;
        bool INumeric<Fix64M>.IsLessThanOrEqualTo(Fix64M value) => this <= value;
        Fix64M INumeric<Fix64M>.Add(Fix64M value) => this + value;
        Fix64M INumeric<Fix64M>.BitwiseComplement() => ~this;
        Fix64M INumeric<Fix64M>.Divide(Fix64M value) => this / value;
        Fix64M INumeric<Fix64M>.LeftShift(int count) => this << count;
        Fix64M INumeric<Fix64M>.LogicalAnd(Fix64M value) => this & value;
        Fix64M INumeric<Fix64M>.LogicalExclusiveOr(Fix64M value) => this ^ value;
        Fix64M INumeric<Fix64M>.LogicalOr(Fix64M value) => this | value;
        Fix64M INumeric<Fix64M>.Multiply(Fix64M value) => this * value;
        Fix64M INumeric<Fix64M>.Negative() => -this;
        Fix64M INumeric<Fix64M>.Positive() => +this;
        Fix64M INumeric<Fix64M>.Remainder(Fix64M value) => this % value;
        Fix64M INumeric<Fix64M>.RightShift(int count) => this >> count;
        Fix64M INumeric<Fix64M>.Subtract(Fix64M value) => this - value;

        INumericBitConverter<Fix64M> IProvider<INumericBitConverter<Fix64M>>.GetInstance() => Utilities.Instance;
        IBinaryIO<Fix64M> IProvider<IBinaryIO<Fix64M>>.GetInstance() => Utilities.Instance;
        IConvert<Fix64M> IProvider<IConvert<Fix64M>>.GetInstance() => Utilities.Instance;
        IConvertExtended<Fix64M> IProvider<IConvertExtended<Fix64M>>.GetInstance() => Utilities.Instance;
        IMath<Fix64M> IProvider<IMath<Fix64M>>.GetInstance() => Utilities.Instance;
        INumericRandom<Fix64M> IProvider<INumericRandom<Fix64M>>.GetInstance() => Utilities.Instance;
        INumericStatic<Fix64M> IProvider<INumericStatic<Fix64M>>.GetInstance() => Utilities.Instance;
        IVariantRandom<Fix64M> IProvider<IVariantRandom<Fix64M>>.GetInstance() => Utilities.Instance;

        private sealed class Utilities :
            IBinaryIO<Fix64M>,
            IConvert<Fix64M>,
            IConvertExtended<Fix64M>,
            IMath<Fix64M>,
            INumericBitConverter<Fix64M>,
            INumericRandom<Fix64M>,
            INumericStatic<Fix64M>,
            IVariantRandom<Fix64M>
        {
            public static readonly Utilities Instance = new Utilities();

            void IBinaryIO<Fix64M>.Write(BinaryWriter writer, Fix64M value) => writer.Write(value._scaledValue);
            Fix64M IBinaryIO<Fix64M>.Read(BinaryReader reader) => new Fix64M(reader.ReadInt64());

            bool INumericStatic<Fix64M>.HasFloatingPoint => false;
            bool INumericStatic<Fix64M>.HasInfinity => false;
            bool INumericStatic<Fix64M>.HasNaN => false;
            bool INumericStatic<Fix64M>.IsFinite(Fix64M x) => true;
            bool INumericStatic<Fix64M>.IsInfinity(Fix64M x) => false;
            bool INumericStatic<Fix64M>.IsNaN(Fix64M x) => false;
            bool INumericStatic<Fix64M>.IsNegative(Fix64M x) => x._scaledValue < 0;
            bool INumericStatic<Fix64M>.IsNegativeInfinity(Fix64M x) => false;
            bool INumericStatic<Fix64M>.IsNormal(Fix64M x) => false;
            bool INumericStatic<Fix64M>.IsPositiveInfinity(Fix64M x) => false;
            bool INumericStatic<Fix64M>.IsReal => true;
            bool INumericStatic<Fix64M>.IsSigned => true;
            bool INumericStatic<Fix64M>.IsSubnormal(Fix64M x) => false;
            Fix64M INumericStatic<Fix64M>.Epsilon { get; } = new Fix64M(1);
            Fix64M INumericStatic<Fix64M>.MaxUnit { get; } = new Fix64M(ScalingFactor);
            Fix64M INumericStatic<Fix64M>.MaxValue => MaxValue;
            Fix64M INumericStatic<Fix64M>.MinUnit { get; } = new Fix64M(-ScalingFactor);
            Fix64M INumericStatic<Fix64M>.MinValue => MinValue;
            Fix64M INumericStatic<Fix64M>.One { get; } = new Fix64M(ScalingFactor);
            Fix64M INumericStatic<Fix64M>.Zero => 0;

            Fix64M IMath<Fix64M>.Abs(Fix64M value) => value._scaledValue < 0 ? -value : value;
            Fix64M IMath<Fix64M>.Acos(Fix64M x) => (Fix64M)Math.Acos((double)x);
            Fix64M IMath<Fix64M>.Acosh(Fix64M x) => (Fix64M)MathShim.Acosh((double)x);
            Fix64M IMath<Fix64M>.Asin(Fix64M x) => (Fix64M)Math.Asin((double)x);
            Fix64M IMath<Fix64M>.Asinh(Fix64M x) => (Fix64M)MathShim.Asinh((double)x);
            Fix64M IMath<Fix64M>.Atan(Fix64M x) => (Fix64M)Math.Atan((double)x);
            Fix64M IMath<Fix64M>.Atan2(Fix64M x, Fix64M y) => (Fix64M)Math.Atan2((double)x, (double)y);
            Fix64M IMath<Fix64M>.Atanh(Fix64M x) => (Fix64M)MathShim.Atanh((double)x);
            Fix64M IMath<Fix64M>.Cbrt(Fix64M x) => (Fix64M)MathShim.Cbrt((double)x);
            Fix64M IMath<Fix64M>.Ceiling(Fix64M x) => new Fix64M(Scaled.Ceiling(x._scaledValue, ScalingFactor));
            Fix64M IMath<Fix64M>.Clamp(Fix64M x, Fix64M bound1, Fix64M bound2) => new Fix64M(bound1 > bound2 ? Math.Min(bound1._scaledValue, Math.Max(bound2._scaledValue, x._scaledValue)) : Math.Min(bound2._scaledValue, Math.Max(bound1._scaledValue, x._scaledValue)));
            Fix64M IMath<Fix64M>.Cos(Fix64M x) => (Fix64M)Math.Cos((double)x);
            Fix64M IMath<Fix64M>.Cosh(Fix64M x) => (Fix64M)Math.Cosh((double)x);
            Fix64M IMath<Fix64M>.E { get; } = (Fix64M)Math.E;
            Fix64M IMath<Fix64M>.Exp(Fix64M x) => (Fix64M)Math.Exp((double)x);
            Fix64M IMath<Fix64M>.Floor(Fix64M x) => new Fix64M(Scaled.Floor(x._scaledValue, ScalingFactor));
            Fix64M IMath<Fix64M>.IEEERemainder(Fix64M x, Fix64M y) => (Fix64M)Math.IEEERemainder((double)x, (double)y);
            Fix64M IMath<Fix64M>.Log(Fix64M x) => (Fix64M)Math.Log((double)x);
            Fix64M IMath<Fix64M>.Log(Fix64M x, Fix64M y) => (Fix64M)Math.Log((double)x, (double)y);
            Fix64M IMath<Fix64M>.Log10(Fix64M x) => (Fix64M)Math.Log10((double)x);
            Fix64M IMath<Fix64M>.Max(Fix64M x, Fix64M y) => new Fix64M(Math.Max(x._scaledValue, y._scaledValue));
            Fix64M IMath<Fix64M>.Min(Fix64M x, Fix64M y) => new Fix64M(Math.Min(x._scaledValue, y._scaledValue));
            Fix64M IMath<Fix64M>.PI { get; } = (Fix64M)Math.PI;
            Fix64M IMath<Fix64M>.Pow(Fix64M x, Fix64M y) => y == 1 ? x : (Fix64M)Math.Pow((double)x, (double)y);
            Fix64M IMath<Fix64M>.Round(Fix64M x) => Round(x, 0, MidpointRounding.ToEven);
            Fix64M IMath<Fix64M>.Round(Fix64M x, int digits) => Round(x, digits, MidpointRounding.ToEven);
            Fix64M IMath<Fix64M>.Round(Fix64M x, int digits, MidpointRounding mode) => Round(x, digits, mode);
            Fix64M IMath<Fix64M>.Round(Fix64M x, MidpointRounding mode) => Round(x, 0, mode);
            Fix64M IMath<Fix64M>.Sin(Fix64M x) => (Fix64M)Math.Sin((double)x);
            Fix64M IMath<Fix64M>.Sinh(Fix64M x) => (Fix64M)Math.Sinh((double)x);
            Fix64M IMath<Fix64M>.Sqrt(Fix64M x) => (Fix64M)Math.Sqrt((double)x);
            Fix64M IMath<Fix64M>.Tan(Fix64M x) => (Fix64M)Math.Tan((double)x);
            Fix64M IMath<Fix64M>.Tanh(Fix64M x) => (Fix64M)Math.Tanh((double)x);
            Fix64M IMath<Fix64M>.Tau { get; } = (Fix64M)(Math.PI * 2d);
            Fix64M IMath<Fix64M>.Truncate(Fix64M x) => new Fix64M(x._scaledValue / ScalingFactor * ScalingFactor);
            int IMath<Fix64M>.Sign(Fix64M x) => Math.Sign(x._scaledValue);

            int INumericBitConverter<Fix64M>.ConvertedSize => sizeof(long);
            Fix64M INumericBitConverter<Fix64M>.ToNumeric(byte[] value, int startIndex) => new Fix64M(BitConverter.ToInt64(value, startIndex));
            byte[] INumericBitConverter<Fix64M>.GetBytes(Fix64M value) => BitConverter.GetBytes(value._scaledValue);
#if HAS_SPANS
            Fix64M INumericBitConverter<Fix64M>.ToNumeric(ReadOnlySpan<byte> value) => new Fix64M(BitConverter.ToInt64(value));
            bool INumericBitConverter<Fix64M>.TryWriteBytes(Span<byte> destination, Fix64M value) => BitConverter.TryWriteBytes(destination, value._scaledValue);
#endif

            bool IConvert<Fix64M>.ToBoolean(Fix64M value) => value._scaledValue != 0;
            byte IConvert<Fix64M>.ToByte(Fix64M value, Conversion mode) => ConvertN.ToByte(value._scaledValue / ScalingFactor, mode.Clamped());
            decimal IConvert<Fix64M>.ToDecimal(Fix64M value, Conversion mode) => (decimal)value._scaledValue / ScalingFactor;
            double IConvert<Fix64M>.ToDouble(Fix64M value, Conversion mode) => Scaled.ToDouble(value._scaledValue, ScalingFactor);
            float IConvert<Fix64M>.ToSingle(Fix64M value, Conversion mode) => (float)value._scaledValue / ScalingFactor;
            int IConvert<Fix64M>.ToInt32(Fix64M value, Conversion mode) => ConvertN.ToInt32(value._scaledValue / ScalingFactor, mode.Clamped());
            long IConvert<Fix64M>.ToInt64(Fix64M value, Conversion mode) => value._scaledValue / ScalingFactor;
            sbyte IConvertExtended<Fix64M>.ToSByte(Fix64M value, Conversion mode) => ConvertN.ToSByte(value._scaledValue / ScalingFactor, mode.Clamped());
            short IConvert<Fix64M>.ToInt16(Fix64M value, Conversion mode) => ConvertN.ToInt16(value._scaledValue / ScalingFactor, mode.Clamped());
            string IConvert<Fix64M>.ToString(Fix64M value) => value.ToString();
            uint IConvertExtended<Fix64M>.ToUInt32(Fix64M value, Conversion mode) => ConvertN.ToUInt32(value._scaledValue / ScalingFactor, mode.Clamped());
            ulong IConvertExtended<Fix64M>.ToUInt64(Fix64M value, Conversion mode) => ConvertN.ToUInt64(value._scaledValue / ScalingFactor, mode.Clamped());
            ushort IConvertExtended<Fix64M>.ToUInt16(Fix64M value, Conversion mode) => ConvertN.ToUInt16(value._scaledValue / ScalingFactor, mode.Clamped());

            Fix64M IConvert<Fix64M>.ToNumeric(bool value) => new Fix64M(value ? ScalingFactor : 0);
            Fix64M IConvert<Fix64M>.ToNumeric(byte value, Conversion mode) => (Fix64M)ConvertN.ToInt64(value, mode.Clamped());
            Fix64M IConvert<Fix64M>.ToNumeric(decimal value, Conversion mode) => (Fix64M)value;
            Fix64M IConvert<Fix64M>.ToNumeric(double value, Conversion mode) => (Fix64M)value;
            Fix64M IConvert<Fix64M>.ToNumeric(float value, Conversion mode) => (Fix64M)value;
            Fix64M IConvert<Fix64M>.ToNumeric(int value, Conversion mode) => (Fix64M)ConvertN.ToInt64(value, mode.Clamped());
            Fix64M IConvert<Fix64M>.ToNumeric(long value, Conversion mode) => (Fix64M)value;
            Fix64M IConvertExtended<Fix64M>.ToValue(sbyte value, Conversion mode) => (Fix64M)ConvertN.ToInt64(value, mode.Clamped());
            Fix64M IConvert<Fix64M>.ToNumeric(short value, Conversion mode) => (Fix64M)ConvertN.ToInt64(value, mode.Clamped());
            Fix64M IConvert<Fix64M>.ToNumeric(string value) => (Fix64M)Convert.ToInt64(value);
            Fix64M IConvertExtended<Fix64M>.ToNumeric(uint value, Conversion mode) => (Fix64M)ConvertN.ToInt64(value, mode.Clamped());
            Fix64M IConvertExtended<Fix64M>.ToNumeric(ulong value, Conversion mode) => new Fix64M(Scaled.ToInt64(value, ScalingFactor, mode.Clamped()));
            Fix64M IConvertExtended<Fix64M>.ToNumeric(ushort value, Conversion mode) => (Fix64M)ConvertN.ToInt64(value, mode.Clamped());

            Fix64M INumericStatic<Fix64M>.Parse(string s, NumberStyles? style, IFormatProvider? provider)
                => Parse(s, style ?? NumberStyles.Number, provider);

            Fix64M INumericRandom<Fix64M>.Generate(Random random) => new Fix64M(random.NextInt64(ScalingFactor));
            Fix64M INumericRandom<Fix64M>.Generate(Random random, Fix64M maxValue) => new Fix64M(random.NextInt64(maxValue._scaledValue));
            Fix64M INumericRandom<Fix64M>.Generate(Random random, Fix64M minValue, Fix64M maxValue) => new Fix64M(random.NextInt64(minValue._scaledValue, maxValue._scaledValue));
            Fix64M INumericRandom<Fix64M>.Generate(Random random, Generation mode) => new Fix64M(random.NextInt64(mode == Generation.Extended ? long.MinValue : 0, mode == Generation.Extended ? long.MaxValue : ScalingFactor, mode));
            Fix64M INumericRandom<Fix64M>.Generate(Random random, Fix64M minValue, Fix64M maxValue, Generation mode) => new Fix64M(random.NextInt64(minValue._scaledValue, maxValue._scaledValue, mode));

            Fix64M IVariantRandom<Fix64M>.Generate(Random random, Variants variants) => new Fix64M(random.NextInt64(variants));
        }
    }
}
