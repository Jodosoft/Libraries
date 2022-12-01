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
using System.IO;
using System.Runtime.Serialization;
using Jodo.Primitives;
using Jodo.Primitives.Compatibility;

namespace Jodo.Numerics
{
    /// <summary>
    /// Represents a decimal fixed-point number.
    /// </summary>
    [Serializable]
    [DebuggerDisplay("{ToString(),nq}")]
    public readonly struct Fix64 : INumericExtended<Fix64>
    {
        public static readonly Fix64 Epsilon = new Fix64(1);
        public static readonly Fix64 MaxValue = new Fix64(long.MaxValue);
        public static readonly Fix64 MinValue = new Fix64(long.MinValue);

        private const long ScalingFactor = 1_000_000;

        private readonly long _scaledValue;

        private Fix64(long scaledValue)
        {
            _scaledValue = scaledValue;
        }

        private Fix64(SerializationInfo info, StreamingContext context) : this(info.GetInt64(nameof(Fix64))) { }
        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context) => info.AddValue(nameof(Fix64), _scaledValue);

        public int CompareTo(Fix64 other) => _scaledValue.CompareTo(other._scaledValue);
        public int CompareTo(object? obj) => obj is Fix64 other ? CompareTo(other) : 1;
        public bool Equals(Fix64 other) => _scaledValue == other._scaledValue;
        public override bool Equals(object? obj) => obj is Fix64 other && Equals(other);
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

        public static bool TryParse(string s, IFormatProvider? provider, out Fix64 result) => FuncExtensions.Try(() => Parse(s, provider), out result);
        public static bool TryParse(string s, NumberStyles style, IFormatProvider? provider, out Fix64 result) => FuncExtensions.Try(() => Parse(s, style, provider), out result);
        public static bool TryParse(string s, NumberStyles style, out Fix64 result) => FuncExtensions.Try(() => Parse(s, style), out result);
        public static bool TryParse(string s, out Fix64 result) => FuncExtensions.Try(() => Parse(s), out result);
        public static Fix64 Parse(string s) => new Fix64(Scaled.Parse(s, ScalingFactor, null, null));
        public static Fix64 Parse(string s, IFormatProvider? provider) => new Fix64(Scaled.Parse(s, ScalingFactor, null, provider));
        public static Fix64 Parse(string s, NumberStyles style) => (Fix64)double.Parse(s, style);
        public static Fix64 Parse(string s, NumberStyles style, IFormatProvider? provider) => (Fix64)double.Parse(s, style, provider);

        private static Fix64 Round(Fix64 value, int digits, MidpointRounding mode)
        {
            if (digits < 0) throw new ArgumentOutOfRangeException(nameof(digits), digits, "Must be positive.");
            if (digits > 5) return value;
            return new Fix64(Scaled.Round(value._scaledValue, 6 - digits, mode));
        }

        [SuppressMessage("Style", "JSON002:Probable JSON string detected", Justification = "False positive")]
        private static Fix64 FromDouble(double value)
        {
            string str = string
                .Format(CultureInfo.InvariantCulture, "{0:0.0000000}", value)
                .Replace(".", string.Empty);
            str = str.Substring(0, str.Length - 1);
            if (long.TryParse(str, out long lng))
            {
                return new Fix64(lng);
            }
            else
            {
                if (value > 0) return MaxValue;
                return MinValue;
            }
        }

        [CLSCompliant(false)] public static explicit operator Fix64(ulong value) => new Fix64((long)(value * ScalingFactor));
        [CLSCompliant(false)] public static implicit operator Fix64(sbyte value) => new Fix64(value * ScalingFactor);
        [CLSCompliant(false)] public static implicit operator Fix64(uint value) => new Fix64(value * ScalingFactor);
        [CLSCompliant(false)] public static implicit operator Fix64(ushort value) => new Fix64(value * ScalingFactor);
        public static explicit operator Fix64(decimal value) => new Fix64((long)(value * ScalingFactor));
        public static explicit operator Fix64(double value) => FromDouble(value);
        public static explicit operator Fix64(float value) => new Fix64((long)(value * ScalingFactor));
        public static explicit operator Fix64(long value) => new Fix64(value * ScalingFactor);
        public static implicit operator Fix64(byte value) => new Fix64(value * ScalingFactor);
        public static implicit operator Fix64(int value) => new Fix64(value * ScalingFactor);
        public static implicit operator Fix64(short value) => new Fix64(value * ScalingFactor);

        [CLSCompliant(false)] public static explicit operator sbyte(Fix64 value) => (sbyte)(value._scaledValue / ScalingFactor);
        [CLSCompliant(false)] public static explicit operator uint(Fix64 value) => (uint)(value._scaledValue / ScalingFactor);
        [CLSCompliant(false)] public static explicit operator ulong(Fix64 value) => (ulong)(value._scaledValue / ScalingFactor);
        [CLSCompliant(false)] public static explicit operator ushort(Fix64 value) => (ushort)(value._scaledValue / ScalingFactor);
        public static explicit operator byte(Fix64 value) => (byte)(value._scaledValue / ScalingFactor);
        public static explicit operator decimal(Fix64 value) => (decimal)value._scaledValue / ScalingFactor;
        public static explicit operator double(Fix64 value) => Scaled.ToDouble(value._scaledValue, ScalingFactor);
        public static explicit operator float(Fix64 value) => (float)value._scaledValue / ScalingFactor;
        public static explicit operator int(Fix64 value) => (int)(value._scaledValue / ScalingFactor);
        public static explicit operator long(Fix64 value) => value._scaledValue / ScalingFactor;
        public static explicit operator short(Fix64 value) => (short)(value._scaledValue / ScalingFactor);

        public static bool operator !=(Fix64 left, Fix64 right) => left._scaledValue != right._scaledValue;
        public static bool operator <(Fix64 left, Fix64 right) => left._scaledValue < right._scaledValue;
        public static bool operator <=(Fix64 left, Fix64 right) => left._scaledValue <= right._scaledValue;
        public static bool operator ==(Fix64 left, Fix64 right) => left._scaledValue == right._scaledValue;
        public static bool operator >(Fix64 left, Fix64 right) => left._scaledValue > right._scaledValue;
        public static bool operator >=(Fix64 left, Fix64 right) => left._scaledValue >= right._scaledValue;
        public static Fix64 operator %(Fix64 left, Fix64 right) => new Fix64(left._scaledValue % right._scaledValue);
        public static Fix64 operator &(Fix64 left, Fix64 right) => new Fix64(left._scaledValue & right._scaledValue);
        public static Fix64 operator -(Fix64 left, Fix64 right) => new Fix64(left._scaledValue - right._scaledValue);
        public static Fix64 operator --(Fix64 value) => new Fix64(value._scaledValue - ScalingFactor);
        public static Fix64 operator -(Fix64 value) => new Fix64(-value._scaledValue);
        public static Fix64 operator *(Fix64 left, Fix64 right) => new Fix64(Scaled.Multiply(left._scaledValue, right._scaledValue, ScalingFactor));
        public static Fix64 operator /(Fix64 left, Fix64 right) => new Fix64(Scaled.Divide(left._scaledValue, right._scaledValue, ScalingFactor));
        public static Fix64 operator ^(Fix64 left, Fix64 right) => new Fix64(left._scaledValue ^ right._scaledValue);
        public static Fix64 operator |(Fix64 left, Fix64 right) => new Fix64(left._scaledValue | right._scaledValue);
        public static Fix64 operator ~(Fix64 value) => new Fix64(~value._scaledValue);
        public static Fix64 operator +(Fix64 left, Fix64 right) => new Fix64(left._scaledValue + right._scaledValue);
        public static Fix64 operator +(Fix64 value) => value;
        public static Fix64 operator ++(Fix64 value) => new Fix64(value._scaledValue + ScalingFactor);
        public static Fix64 operator <<(Fix64 left, int right) => new Fix64(left._scaledValue << right);
        public static Fix64 operator >>(Fix64 left, int right) => new Fix64(left._scaledValue >> right);

        TypeCode IConvertible.GetTypeCode() => TypeCode.Object;
        bool IConvertible.ToBoolean(IFormatProvider provider) => ((IConvert<Fix64>)Utilities.Instance).ToBoolean(this);
        char IConvertible.ToChar(IFormatProvider provider) => ((IConvertible)((IConvert<Fix64>)Utilities.Instance).ToDouble(this, Conversion.Default)).ToChar(provider);
        sbyte IConvertible.ToSByte(IFormatProvider provider) => ((IConvertExtended<Fix64>)Utilities.Instance).ToSByte(this, Conversion.Default);
        byte IConvertible.ToByte(IFormatProvider provider) => ((IConvert<Fix64>)Utilities.Instance).ToByte(this, Conversion.Default);
        short IConvertible.ToInt16(IFormatProvider provider) => ((IConvert<Fix64>)Utilities.Instance).ToInt16(this, Conversion.Default);
        ushort IConvertible.ToUInt16(IFormatProvider provider) => ((IConvertExtended<Fix64>)Utilities.Instance).ToUInt16(this, Conversion.Default);
        int IConvertible.ToInt32(IFormatProvider provider) => ((IConvert<Fix64>)Utilities.Instance).ToInt32(this, Conversion.Default);
        uint IConvertible.ToUInt32(IFormatProvider provider) => ((IConvertExtended<Fix64>)Utilities.Instance).ToUInt32(this, Conversion.Default);
        long IConvertible.ToInt64(IFormatProvider provider) => ((IConvert<Fix64>)Utilities.Instance).ToInt64(this, Conversion.Default);
        ulong IConvertible.ToUInt64(IFormatProvider provider) => ((IConvertExtended<Fix64>)Utilities.Instance).ToUInt64(this, Conversion.Default);
        float IConvertible.ToSingle(IFormatProvider provider) => ((IConvert<Fix64>)Utilities.Instance).ToSingle(this, Conversion.Default);
        double IConvertible.ToDouble(IFormatProvider provider) => ((IConvert<Fix64>)Utilities.Instance).ToDouble(this, Conversion.Default);
        decimal IConvertible.ToDecimal(IFormatProvider provider) => ((IConvert<Fix64>)Utilities.Instance).ToDecimal(this, Conversion.Default);
        DateTime IConvertible.ToDateTime(IFormatProvider provider) => ((IConvertible)((IConvert<Fix64>)Utilities.Instance).ToDouble(this, Conversion.Default)).ToDateTime(provider);
        object IConvertible.ToType(Type conversionType, IFormatProvider provider) => this.ToTypeDefault(conversionType, provider);

        bool INumeric<Fix64>.IsGreaterThan(Fix64 value) => this > value;
        bool INumeric<Fix64>.IsGreaterThanOrEqualTo(Fix64 value) => this >= value;
        bool INumeric<Fix64>.IsLessThan(Fix64 value) => this < value;
        bool INumeric<Fix64>.IsLessThanOrEqualTo(Fix64 value) => this <= value;
        Fix64 INumeric<Fix64>.Add(Fix64 value) => this + value;
        Fix64 INumeric<Fix64>.BitwiseComplement() => ~this;
        Fix64 INumeric<Fix64>.Divide(Fix64 value) => this / value;
        Fix64 INumeric<Fix64>.LeftShift(int count) => this << count;
        Fix64 INumeric<Fix64>.LogicalAnd(Fix64 value) => this & value;
        Fix64 INumeric<Fix64>.LogicalExclusiveOr(Fix64 value) => this ^ value;
        Fix64 INumeric<Fix64>.LogicalOr(Fix64 value) => this | value;
        Fix64 INumeric<Fix64>.Multiply(Fix64 value) => this * value;
        Fix64 INumeric<Fix64>.Negative() => -this;
        Fix64 INumeric<Fix64>.Positive() => +this;
        Fix64 INumeric<Fix64>.Remainder(Fix64 value) => this % value;
        Fix64 INumeric<Fix64>.RightShift(int count) => this >> count;
        Fix64 INumeric<Fix64>.Subtract(Fix64 value) => this - value;

        INumericBitConverter<Fix64> IProvider<INumericBitConverter<Fix64>>.GetInstance() => Utilities.Instance;
        IBinaryIO<Fix64> IProvider<IBinaryIO<Fix64>>.GetInstance() => Utilities.Instance;
        IConvert<Fix64> IProvider<IConvert<Fix64>>.GetInstance() => Utilities.Instance;
        IConvertExtended<Fix64> IProvider<IConvertExtended<Fix64>>.GetInstance() => Utilities.Instance;
        IMath<Fix64> IProvider<IMath<Fix64>>.GetInstance() => Utilities.Instance;
        INumericStatic<Fix64> IProvider<INumericStatic<Fix64>>.GetInstance() => Utilities.Instance;
        INumericRandom<Fix64> IProvider<INumericRandom<Fix64>>.GetInstance() => Utilities.Instance;
        IVariantRandom<Fix64> IProvider<IVariantRandom<Fix64>>.GetInstance() => Utilities.Instance;

        private sealed class Utilities :
            IBinaryIO<Fix64>,
            IConvert<Fix64>,
            IConvertExtended<Fix64>,
            IMath<Fix64>,
            INumericBitConverter<Fix64>,
            INumericRandom<Fix64>,
            INumericStatic<Fix64>,
            IVariantRandom<Fix64>
        {
            public static readonly Utilities Instance = new Utilities();

            void IBinaryIO<Fix64>.Write(BinaryWriter writer, Fix64 value) => writer.Write(value._scaledValue);
            Fix64 IBinaryIO<Fix64>.Read(BinaryReader reader) => new Fix64(reader.ReadInt64());

            bool INumericStatic<Fix64>.HasFloatingPoint => false;
            bool INumericStatic<Fix64>.HasInfinity => false;
            bool INumericStatic<Fix64>.HasNaN => false;
            bool INumericStatic<Fix64>.IsFinite(Fix64 x) => true;
            bool INumericStatic<Fix64>.IsInfinity(Fix64 x) => false;
            bool INumericStatic<Fix64>.IsNaN(Fix64 x) => false;
            bool INumericStatic<Fix64>.IsNegative(Fix64 x) => x._scaledValue < 0;
            bool INumericStatic<Fix64>.IsNegativeInfinity(Fix64 x) => false;
            bool INumericStatic<Fix64>.IsNormal(Fix64 x) => false;
            bool INumericStatic<Fix64>.IsPositiveInfinity(Fix64 x) => false;
            bool INumericStatic<Fix64>.IsReal => true;
            bool INumericStatic<Fix64>.IsSigned => true;
            bool INumericStatic<Fix64>.IsSubnormal(Fix64 x) => false;
            Fix64 INumericStatic<Fix64>.Epsilon { get; } = new Fix64(1);
            Fix64 INumericStatic<Fix64>.MaxUnit { get; } = new Fix64(ScalingFactor);
            Fix64 INumericStatic<Fix64>.MaxValue => MaxValue;
            Fix64 INumericStatic<Fix64>.MinUnit { get; } = new Fix64(-ScalingFactor);
            Fix64 INumericStatic<Fix64>.MinValue => MinValue;
            Fix64 INumericStatic<Fix64>.One { get; } = new Fix64(ScalingFactor);
            Fix64 INumericStatic<Fix64>.Zero => 0;

            Fix64 IMath<Fix64>.Abs(Fix64 value) => value._scaledValue < 0 ? -value : value;
            Fix64 IMath<Fix64>.Acos(Fix64 x) => (Fix64)Math.Acos((double)x);
            Fix64 IMath<Fix64>.Acosh(Fix64 x) => (Fix64)MathShim.Acosh((double)x);
            Fix64 IMath<Fix64>.Asin(Fix64 x) => (Fix64)Math.Asin((double)x);
            Fix64 IMath<Fix64>.Asinh(Fix64 x) => (Fix64)MathShim.Asinh((double)x);
            Fix64 IMath<Fix64>.Atan(Fix64 x) => (Fix64)Math.Atan((double)x);
            Fix64 IMath<Fix64>.Atan2(Fix64 x, Fix64 y) => (Fix64)Math.Atan2((double)x, (double)y);
            Fix64 IMath<Fix64>.Atanh(Fix64 x) => (Fix64)MathShim.Atanh((double)x);
            Fix64 IMath<Fix64>.Cbrt(Fix64 x) => (Fix64)MathShim.Cbrt((double)x);
            Fix64 IMath<Fix64>.Ceiling(Fix64 x) => new Fix64(Scaled.Ceiling(x._scaledValue, ScalingFactor));
            Fix64 IMath<Fix64>.Clamp(Fix64 x, Fix64 bound1, Fix64 bound2) => new Fix64(bound1 > bound2 ? Math.Min(bound1._scaledValue, Math.Max(bound2._scaledValue, x._scaledValue)) : Math.Min(bound2._scaledValue, Math.Max(bound1._scaledValue, x._scaledValue)));
            Fix64 IMath<Fix64>.Cos(Fix64 x) => (Fix64)Math.Cos((double)x);
            Fix64 IMath<Fix64>.Cosh(Fix64 x) => (Fix64)Math.Cosh((double)x);
            Fix64 IMath<Fix64>.E { get; } = (Fix64)Math.E;
            Fix64 IMath<Fix64>.Exp(Fix64 x) => (Fix64)Math.Exp((double)x);
            Fix64 IMath<Fix64>.Floor(Fix64 x) => new Fix64(Scaled.Floor(x._scaledValue, ScalingFactor));
            Fix64 IMath<Fix64>.IEEERemainder(Fix64 x, Fix64 y) => (Fix64)Math.IEEERemainder((double)x, (double)y);
            Fix64 IMath<Fix64>.Log(Fix64 x) => (Fix64)Math.Log((double)x);
            Fix64 IMath<Fix64>.Log(Fix64 x, Fix64 y) => (Fix64)Math.Log((double)x, (double)y);
            Fix64 IMath<Fix64>.Log10(Fix64 x) => (Fix64)Math.Log10((double)x);
            Fix64 IMath<Fix64>.Max(Fix64 x, Fix64 y) => new Fix64(Math.Max(x._scaledValue, y._scaledValue));
            Fix64 IMath<Fix64>.Min(Fix64 x, Fix64 y) => new Fix64(Math.Min(x._scaledValue, y._scaledValue));
            Fix64 IMath<Fix64>.PI { get; } = (Fix64)Math.PI;
            Fix64 IMath<Fix64>.Pow(Fix64 x, Fix64 y) => y == 1 ? x : (Fix64)Math.Pow((double)x, (double)y);
            Fix64 IMath<Fix64>.Round(Fix64 x) => Round(x, 0, MidpointRounding.ToEven);
            Fix64 IMath<Fix64>.Round(Fix64 x, int digits) => Round(x, digits, MidpointRounding.ToEven);
            Fix64 IMath<Fix64>.Round(Fix64 x, int digits, MidpointRounding mode) => Round(x, digits, mode);
            Fix64 IMath<Fix64>.Round(Fix64 x, MidpointRounding mode) => Round(x, 0, mode);
            Fix64 IMath<Fix64>.Sin(Fix64 x) => (Fix64)Math.Sin((double)x);
            Fix64 IMath<Fix64>.Sinh(Fix64 x) => (Fix64)Math.Sinh((double)x);
            Fix64 IMath<Fix64>.Sqrt(Fix64 x) => (Fix64)Math.Sqrt((double)x);
            Fix64 IMath<Fix64>.Tan(Fix64 x) => (Fix64)Math.Tan((double)x);
            Fix64 IMath<Fix64>.Tanh(Fix64 x) => (Fix64)Math.Tanh((double)x);
            Fix64 IMath<Fix64>.Tau { get; } = (Fix64)(Math.PI * 2d);
            Fix64 IMath<Fix64>.Truncate(Fix64 x) => new Fix64(x._scaledValue / ScalingFactor * ScalingFactor);
            int IMath<Fix64>.Sign(Fix64 x) => Math.Sign(x._scaledValue);

            int INumericBitConverter<Fix64>.ConvertedSize => sizeof(long);
            Fix64 INumericBitConverter<Fix64>.ToNumeric(byte[] value, int startIndex) => new Fix64(BitConverter.ToInt64(value, startIndex));
            byte[] INumericBitConverter<Fix64>.GetBytes(Fix64 value) => BitConverter.GetBytes(value._scaledValue);
#if HAS_SPANS
            Fix64 INumericBitConverter<Fix64>.ToNumeric(ReadOnlySpan<byte> value) => new Fix64(BitConverter.ToInt64(value));
            bool INumericBitConverter<Fix64>.TryWriteBytes(Span<byte> destination, Fix64 value) => BitConverter.TryWriteBytes(destination, value._scaledValue);
#endif

            bool IConvert<Fix64>.ToBoolean(Fix64 value) => value._scaledValue != 0;
            byte IConvert<Fix64>.ToByte(Fix64 value, Conversion mode) => ConvertN.ToByte(value._scaledValue / ScalingFactor, mode);
            decimal IConvert<Fix64>.ToDecimal(Fix64 value, Conversion mode) => (decimal)value._scaledValue / ScalingFactor;
            double IConvert<Fix64>.ToDouble(Fix64 value, Conversion mode) => Scaled.ToDouble(value._scaledValue, ScalingFactor);
            float IConvert<Fix64>.ToSingle(Fix64 value, Conversion mode) => (float)value._scaledValue / ScalingFactor;
            int IConvert<Fix64>.ToInt32(Fix64 value, Conversion mode) => ConvertN.ToInt32(value._scaledValue / ScalingFactor, mode);
            long IConvert<Fix64>.ToInt64(Fix64 value, Conversion mode) => value._scaledValue / ScalingFactor;
            sbyte IConvertExtended<Fix64>.ToSByte(Fix64 value, Conversion mode) => ConvertN.ToSByte(value._scaledValue / ScalingFactor, mode);
            short IConvert<Fix64>.ToInt16(Fix64 value, Conversion mode) => ConvertN.ToInt16(value._scaledValue / ScalingFactor, mode);
            string IConvert<Fix64>.ToString(Fix64 value) => value.ToString();
            uint IConvertExtended<Fix64>.ToUInt32(Fix64 value, Conversion mode) => ConvertN.ToUInt32(value._scaledValue / ScalingFactor, mode);
            ulong IConvertExtended<Fix64>.ToUInt64(Fix64 value, Conversion mode) => ConvertN.ToUInt64(value._scaledValue / ScalingFactor, mode);
            ushort IConvertExtended<Fix64>.ToUInt16(Fix64 value, Conversion mode) => ConvertN.ToUInt16(value._scaledValue / ScalingFactor, mode);

            Fix64 IConvert<Fix64>.ToNumeric(bool value) => new Fix64(value ? ScalingFactor : 0);
            Fix64 IConvert<Fix64>.ToNumeric(byte value, Conversion mode) => (Fix64)ConvertN.ToInt64(value, mode);
            Fix64 IConvert<Fix64>.ToNumeric(decimal value, Conversion mode) => (Fix64)value;
            Fix64 IConvert<Fix64>.ToNumeric(double value, Conversion mode) => (Fix64)value;
            Fix64 IConvert<Fix64>.ToNumeric(float value, Conversion mode) => (Fix64)value;
            Fix64 IConvert<Fix64>.ToNumeric(int value, Conversion mode) => (Fix64)ConvertN.ToInt64(value, mode);
            Fix64 IConvert<Fix64>.ToNumeric(long value, Conversion mode) => (Fix64)value;
            Fix64 IConvertExtended<Fix64>.ToValue(sbyte value, Conversion mode) => (Fix64)ConvertN.ToInt64(value, mode);
            Fix64 IConvert<Fix64>.ToNumeric(short value, Conversion mode) => (Fix64)ConvertN.ToInt64(value, mode);
            Fix64 IConvert<Fix64>.ToNumeric(string value) => (Fix64)Convert.ToInt64(value);
            Fix64 IConvertExtended<Fix64>.ToNumeric(uint value, Conversion mode) => (Fix64)ConvertN.ToInt64(value, mode);
            Fix64 IConvertExtended<Fix64>.ToNumeric(ulong value, Conversion mode) => new Fix64(Scaled.ToInt64(value, ScalingFactor, mode));
            Fix64 IConvertExtended<Fix64>.ToNumeric(ushort value, Conversion mode) => (Fix64)ConvertN.ToInt64(value, mode);

            Fix64 INumericStatic<Fix64>.Parse(string s, NumberStyles? style, IFormatProvider? provider)
                => Parse(s, style ?? NumberStyles.Number, provider);

            Fix64 INumericRandom<Fix64>.Generate(Random random) => new Fix64(random.NextInt64(ScalingFactor));
            Fix64 INumericRandom<Fix64>.Generate(Random random, Fix64 maxValue) => new Fix64(random.NextInt64(maxValue._scaledValue));
            Fix64 INumericRandom<Fix64>.Generate(Random random, Fix64 minValue, Fix64 maxValue) => new Fix64(random.NextInt64(minValue._scaledValue, maxValue._scaledValue));
            Fix64 INumericRandom<Fix64>.Generate(Random random, Generation mode) => new Fix64(random.NextInt64(mode == Generation.Extended ? long.MinValue : 0, mode == Generation.Extended ? long.MaxValue : ScalingFactor, mode));
            Fix64 INumericRandom<Fix64>.Generate(Random random, Fix64 minValue, Fix64 maxValue, Generation mode) => new Fix64(random.NextInt64(minValue._scaledValue, maxValue._scaledValue, mode));

            Fix64 IVariantRandom<Fix64>.Generate(Random random, Variants variants) => new Fix64(random.NextInt64(variants));
        }
    }
}
