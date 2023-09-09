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

namespace Jodosoft.Numerics
{
    /// <summary>
    /// Represents a decimal fixed-point number that cannot overflow.
    /// </summary>
    [Serializable]
    [DebuggerDisplay("{ToString(),nq}")]
    public readonly struct ClampedFix64 : INumericExtended<ClampedFix64>
    {
        public static readonly ClampedFix64 Epsilon = new ClampedFix64(1);
        public static readonly ClampedFix64 MaxValue = new ClampedFix64(long.MaxValue);
        public static readonly ClampedFix64 MinValue = new ClampedFix64(long.MinValue);

        private const long ScalingFactor = 1_000_000;

        private readonly long _scaledValue;

        private ClampedFix64(long scaledValue)
        {
            _scaledValue = scaledValue;
        }

        private ClampedFix64(SerializationInfo info, StreamingContext context) : this(info.GetInt64(nameof(ClampedFix64))) { }
        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context) => info.AddValue(nameof(ClampedFix64), _scaledValue);

        public int CompareTo(ClampedFix64 other) => _scaledValue.CompareTo(other._scaledValue);
        public int CompareTo(object? obj) => obj is ClampedFix64 other ? CompareTo(other) : 1;
        public bool Equals(ClampedFix64 other) => _scaledValue == other._scaledValue;
        public override bool Equals(object? obj) => obj is ClampedFix64 other && Equals(other);
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
        public static long GetScaledValue(ClampedFix64 value) => value._scaledValue;
        public static bool TryParse(string s, IFormatProvider? provider, out ClampedFix64 result) => FuncExtensions.Try(() => Parse(s, provider), out result);
        public static bool TryParse(string s, NumberStyles style, IFormatProvider? provider, out ClampedFix64 result) => FuncExtensions.Try(() => Parse(s, style, provider), out result);
        public static bool TryParse(string s, NumberStyles style, out ClampedFix64 result) => FuncExtensions.Try(() => Parse(s, style), out result);
        public static bool TryParse(string s, out ClampedFix64 result) => FuncExtensions.Try(() => Parse(s), out result);
        public static ClampedFix64 Parse(string s) => new ClampedFix64(Scaled.Parse(s, ScalingFactor, null, null));
        public static ClampedFix64 Parse(string s, IFormatProvider? provider) => (ClampedFix64)double.Parse(s, provider);
        public static ClampedFix64 Parse(string s, NumberStyles style) => (ClampedFix64)double.Parse(s, style);
        public static ClampedFix64 Parse(string s, NumberStyles style, IFormatProvider? provider) => (ClampedFix64)double.Parse(s, style, provider);

        [SuppressMessage("Style", "JSON002:Probable JSON string detected", Justification = "False positive")]
        private static ClampedFix64 FromDouble(double value)
        {
            string str = string
                .Format(CultureInfo.InvariantCulture, "{0:0.0000000}", value)
                .Replace(".", string.Empty);
            str = str.Substring(0, str.Length - 1);
            if (long.TryParse(str, out long lng))
                return new ClampedFix64(lng);
            else
            {
                if (value > 0) return MaxValue;
                return MinValue;
            }
        }

        [CLSCompliant(false)] public static explicit operator ClampedFix64(ulong value) => new ClampedFix64(ConvertN.ToInt64(ClampedArithmetic.Multiply(value, ScalingFactor), Conversion.CastClamp));
        [CLSCompliant(false)] public static implicit operator ClampedFix64(sbyte value) => new ClampedFix64(value * ScalingFactor);
        [CLSCompliant(false)] public static implicit operator ClampedFix64(uint value) => new ClampedFix64(value * ScalingFactor);
        [CLSCompliant(false)] public static implicit operator ClampedFix64(ushort value) => new ClampedFix64(value * ScalingFactor);
        public static explicit operator ClampedFix64(decimal value) => new ClampedFix64(ConvertN.ToInt64(ClampedArithmetic.Multiply(value, ScalingFactor), Conversion.CastClamp));
        public static explicit operator ClampedFix64(double value) => FromDouble(value);
        public static explicit operator ClampedFix64(float value) => new ClampedFix64(ConvertN.ToInt64(value * ScalingFactor, Conversion.CastClamp));
        public static explicit operator ClampedFix64(long value) => new ClampedFix64(ClampedArithmetic.Multiply(value, ScalingFactor));
        public static implicit operator ClampedFix64(byte value) => new ClampedFix64(value * ScalingFactor);
        public static implicit operator ClampedFix64(int value) => new ClampedFix64(value * ScalingFactor);
        public static implicit operator ClampedFix64(short value) => new ClampedFix64(value * ScalingFactor);
        public static explicit operator ClampedFix64(ClampedUFix64 value) => new ClampedFix64(ConvertN.ToInt64(ClampedUFix64.GetScaledValue(value), Conversion.CastClamp));

        [CLSCompliant(false)] public static explicit operator sbyte(ClampedFix64 value) => ConvertN.ToSByte(value._scaledValue / ScalingFactor, Conversion.CastClamp);
        [CLSCompliant(false)] public static explicit operator uint(ClampedFix64 value) => ConvertN.ToUInt32(value._scaledValue / ScalingFactor, Conversion.CastClamp);
        [CLSCompliant(false)] public static explicit operator ulong(ClampedFix64 value) => ConvertN.ToUInt64(value._scaledValue / ScalingFactor, Conversion.CastClamp);
        [CLSCompliant(false)] public static explicit operator ushort(ClampedFix64 value) => ConvertN.ToUInt16(value._scaledValue / ScalingFactor, Conversion.CastClamp);
        public static explicit operator byte(ClampedFix64 value) => ConvertN.ToByte(value._scaledValue / ScalingFactor, Conversion.CastClamp);
        public static explicit operator decimal(ClampedFix64 value) => (decimal)value._scaledValue / ScalingFactor;
        public static explicit operator double(ClampedFix64 value) => Scaled.ToDouble(value._scaledValue, ScalingFactor);
        public static explicit operator float(ClampedFix64 value) => (float)value._scaledValue / ScalingFactor;
        public static explicit operator int(ClampedFix64 value) => ConvertN.ToInt32(value._scaledValue / ScalingFactor, Conversion.CastClamp);
        public static explicit operator long(ClampedFix64 value) => value._scaledValue / ScalingFactor;
        public static explicit operator short(ClampedFix64 value) => ConvertN.ToInt16(value._scaledValue / ScalingFactor, Conversion.CastClamp);

        public static bool operator !=(ClampedFix64 left, ClampedFix64 right) => left._scaledValue != right._scaledValue;
        public static bool operator <(ClampedFix64 left, ClampedFix64 right) => left._scaledValue < right._scaledValue;
        public static bool operator <=(ClampedFix64 left, ClampedFix64 right) => left._scaledValue <= right._scaledValue;
        public static bool operator ==(ClampedFix64 left, ClampedFix64 right) => left._scaledValue == right._scaledValue;
        public static bool operator >(ClampedFix64 left, ClampedFix64 right) => left._scaledValue > right._scaledValue;
        public static bool operator >=(ClampedFix64 left, ClampedFix64 right) => left._scaledValue >= right._scaledValue;
        public static ClampedFix64 operator %(ClampedFix64 left, ClampedFix64 right) => new ClampedFix64(ClampedArithmetic.Remainder(left._scaledValue, right._scaledValue));
        public static ClampedFix64 operator &(ClampedFix64 left, ClampedFix64 right) => new ClampedFix64(left._scaledValue & right._scaledValue);
        public static ClampedFix64 operator -(ClampedFix64 left, ClampedFix64 right) => new ClampedFix64(ClampedArithmetic.Subtract(left._scaledValue, right._scaledValue));
        public static ClampedFix64 operator --(ClampedFix64 value) => new ClampedFix64(ClampedArithmetic.Subtract(value._scaledValue, ScalingFactor));
        public static ClampedFix64 operator -(ClampedFix64 value) => new ClampedFix64(value._scaledValue == long.MinValue ? long.MaxValue : -value._scaledValue);
        public static ClampedFix64 operator *(ClampedFix64 left, ClampedFix64 right) => new ClampedFix64(ClampedArithmetic.ScaledMultiply(left._scaledValue, right._scaledValue, ScalingFactor));
        public static ClampedFix64 operator /(ClampedFix64 left, ClampedFix64 right) => new ClampedFix64(ClampedArithmetic.ScaledDivide(left._scaledValue, right._scaledValue, ScalingFactor));
        public static ClampedFix64 operator ^(ClampedFix64 left, ClampedFix64 right) => new ClampedFix64(left._scaledValue ^ right._scaledValue);
        public static ClampedFix64 operator |(ClampedFix64 left, ClampedFix64 right) => new ClampedFix64(left._scaledValue | right._scaledValue);
        public static ClampedFix64 operator ~(ClampedFix64 value) => new ClampedFix64(~value._scaledValue);
        public static ClampedFix64 operator +(ClampedFix64 left, ClampedFix64 right) => new ClampedFix64(ClampedArithmetic.Add(left._scaledValue, right._scaledValue));
        public static ClampedFix64 operator +(ClampedFix64 value) => value;
        public static ClampedFix64 operator ++(ClampedFix64 value) => new ClampedFix64(ClampedArithmetic.Add(value._scaledValue, ScalingFactor));
        public static ClampedFix64 operator <<(ClampedFix64 left, int right) => new ClampedFix64(left._scaledValue << right);
        public static ClampedFix64 operator >>(ClampedFix64 left, int right) => new ClampedFix64(left._scaledValue >> right);

        TypeCode IConvertible.GetTypeCode() => TypeCode.Object;
        bool IConvertible.ToBoolean(IFormatProvider provider) => ((IConvert<ClampedFix64>)Utilities.Instance).ToBoolean(this);
        byte IConvertible.ToByte(IFormatProvider provider) => ((IConvert<ClampedFix64>)Utilities.Instance).ToByte(this, Conversion.Clamp);
        char IConvertible.ToChar(IFormatProvider provider) => ((IConvertible)((IConvert<ClampedFix64>)Utilities.Instance).ToDouble(this, Conversion.Clamp)).ToChar(provider);
        DateTime IConvertible.ToDateTime(IFormatProvider provider) => ((IConvertible)((IConvert<ClampedFix64>)Utilities.Instance).ToDouble(this, Conversion.Clamp)).ToDateTime(provider);
        decimal IConvertible.ToDecimal(IFormatProvider provider) => ((IConvert<ClampedFix64>)Utilities.Instance).ToDecimal(this, Conversion.Clamp);
        double IConvertible.ToDouble(IFormatProvider provider) => ((IConvert<ClampedFix64>)Utilities.Instance).ToDouble(this, Conversion.Clamp);
        float IConvertible.ToSingle(IFormatProvider provider) => ((IConvert<ClampedFix64>)Utilities.Instance).ToSingle(this, Conversion.Clamp);
        int IConvertible.ToInt32(IFormatProvider provider) => ((IConvert<ClampedFix64>)Utilities.Instance).ToInt32(this, Conversion.Clamp);
        long IConvertible.ToInt64(IFormatProvider provider) => ((IConvert<ClampedFix64>)Utilities.Instance).ToInt64(this, Conversion.Clamp);
        sbyte IConvertible.ToSByte(IFormatProvider provider) => ((IConvertExtended<ClampedFix64>)Utilities.Instance).ToSByte(this, Conversion.Clamp);
        short IConvertible.ToInt16(IFormatProvider provider) => ((IConvert<ClampedFix64>)Utilities.Instance).ToInt16(this, Conversion.Clamp);
        uint IConvertible.ToUInt32(IFormatProvider provider) => ((IConvertExtended<ClampedFix64>)Utilities.Instance).ToUInt32(this, Conversion.Clamp);
        ulong IConvertible.ToUInt64(IFormatProvider provider) => ((IConvertExtended<ClampedFix64>)Utilities.Instance).ToUInt64(this, Conversion.Clamp);
        ushort IConvertible.ToUInt16(IFormatProvider provider) => ((IConvertExtended<ClampedFix64>)Utilities.Instance).ToUInt16(this, Conversion.Clamp);
        object IConvertible.ToType(Type conversionType, IFormatProvider provider) => this.ToTypeDefault(conversionType, provider);

        bool INumeric<ClampedFix64>.IsGreaterThan(ClampedFix64 value) => this > value;
        bool INumeric<ClampedFix64>.IsGreaterThanOrEqualTo(ClampedFix64 value) => this >= value;
        bool INumeric<ClampedFix64>.IsLessThan(ClampedFix64 value) => this < value;
        bool INumeric<ClampedFix64>.IsLessThanOrEqualTo(ClampedFix64 value) => this <= value;
        ClampedFix64 INumeric<ClampedFix64>.Add(ClampedFix64 value) => this + value;
        ClampedFix64 INumeric<ClampedFix64>.BitwiseComplement() => ~this;
        ClampedFix64 INumeric<ClampedFix64>.Divide(ClampedFix64 value) => this / value;
        ClampedFix64 INumeric<ClampedFix64>.LeftShift(int count) => this << count;
        ClampedFix64 INumeric<ClampedFix64>.LogicalAnd(ClampedFix64 value) => this & value;
        ClampedFix64 INumeric<ClampedFix64>.LogicalExclusiveOr(ClampedFix64 value) => this ^ value;
        ClampedFix64 INumeric<ClampedFix64>.LogicalOr(ClampedFix64 value) => this | value;
        ClampedFix64 INumeric<ClampedFix64>.Multiply(ClampedFix64 value) => this * value;
        ClampedFix64 INumeric<ClampedFix64>.Negative() => -this;
        ClampedFix64 INumeric<ClampedFix64>.Positive() => +this;
        ClampedFix64 INumeric<ClampedFix64>.Remainder(ClampedFix64 value) => this % value;
        ClampedFix64 INumeric<ClampedFix64>.RightShift(int count) => this >> count;
        ClampedFix64 INumeric<ClampedFix64>.Subtract(ClampedFix64 value) => this - value;

        INumericBitConverter<ClampedFix64> IProvider<INumericBitConverter<ClampedFix64>>.GetInstance() => Utilities.Instance;
        IBinaryIO<ClampedFix64> IProvider<IBinaryIO<ClampedFix64>>.GetInstance() => Utilities.Instance;
        IConvert<ClampedFix64> IProvider<IConvert<ClampedFix64>>.GetInstance() => Utilities.Instance;
        IConvertExtended<ClampedFix64> IProvider<IConvertExtended<ClampedFix64>>.GetInstance() => Utilities.Instance;
        IMath<ClampedFix64> IProvider<IMath<ClampedFix64>>.GetInstance() => Utilities.Instance;
        INumericRandom<ClampedFix64> IProvider<INumericRandom<ClampedFix64>>.GetInstance() => Utilities.Instance;
        INumericStatic<ClampedFix64> IProvider<INumericStatic<ClampedFix64>>.GetInstance() => Utilities.Instance;
        IVariantRandom<ClampedFix64> IProvider<IVariantRandom<ClampedFix64>>.GetInstance() => Utilities.Instance;

        private sealed class Utilities :
            IBinaryIO<ClampedFix64>,
            IConvert<ClampedFix64>,
            IConvertExtended<ClampedFix64>,
            IMath<ClampedFix64>,
            INumericBitConverter<ClampedFix64>,
            INumericRandom<ClampedFix64>,
            INumericStatic<ClampedFix64>,
            IVariantRandom<ClampedFix64>
        {
            public static readonly Utilities Instance = new Utilities();

            void IBinaryIO<ClampedFix64>.Write(BinaryWriter writer, ClampedFix64 value) => writer.Write(value._scaledValue);
            ClampedFix64 IBinaryIO<ClampedFix64>.Read(BinaryReader reader) => new ClampedFix64(reader.ReadInt64());

            bool INumericStatic<ClampedFix64>.HasFloatingPoint => false;
            bool INumericStatic<ClampedFix64>.HasInfinity => false;
            bool INumericStatic<ClampedFix64>.HasNaN => false;
            bool INumericStatic<ClampedFix64>.IsFinite(ClampedFix64 x) => true;
            bool INumericStatic<ClampedFix64>.IsInfinity(ClampedFix64 x) => false;
            bool INumericStatic<ClampedFix64>.IsNaN(ClampedFix64 x) => false;
            bool INumericStatic<ClampedFix64>.IsNegative(ClampedFix64 x) => x._scaledValue < 0;
            bool INumericStatic<ClampedFix64>.IsNegativeInfinity(ClampedFix64 x) => false;
            bool INumericStatic<ClampedFix64>.IsNormal(ClampedFix64 x) => false;
            bool INumericStatic<ClampedFix64>.IsPositiveInfinity(ClampedFix64 x) => false;
            bool INumericStatic<ClampedFix64>.IsReal => true;
            bool INumericStatic<ClampedFix64>.IsSigned => true;
            bool INumericStatic<ClampedFix64>.IsSubnormal(ClampedFix64 x) => false;
            ClampedFix64 INumericStatic<ClampedFix64>.Epsilon { get; } = new ClampedFix64(1);
            ClampedFix64 INumericStatic<ClampedFix64>.MaxUnit { get; } = new ClampedFix64(ScalingFactor);
            ClampedFix64 INumericStatic<ClampedFix64>.MaxValue => MaxValue;
            ClampedFix64 INumericStatic<ClampedFix64>.MinUnit { get; } = new ClampedFix64(-ScalingFactor);
            ClampedFix64 INumericStatic<ClampedFix64>.MinValue => MinValue;
            ClampedFix64 INumericStatic<ClampedFix64>.One { get; } = new ClampedFix64(ScalingFactor);
            ClampedFix64 INumericStatic<ClampedFix64>.Zero => 0;

            ClampedFix64 IMath<ClampedFix64>.Abs(ClampedFix64 value) => value._scaledValue < 0 ? -value : value;
            ClampedFix64 IMath<ClampedFix64>.Acos(ClampedFix64 x) => (ClampedFix64)Math.Acos((double)x);
            ClampedFix64 IMath<ClampedFix64>.Acosh(ClampedFix64 x) => (ClampedFix64)MathShim.Acosh((double)x);
            ClampedFix64 IMath<ClampedFix64>.Asin(ClampedFix64 x) => (ClampedFix64)Math.Asin((double)x);
            ClampedFix64 IMath<ClampedFix64>.Asinh(ClampedFix64 x) => (ClampedFix64)MathShim.Asinh((double)x);
            ClampedFix64 IMath<ClampedFix64>.Atan(ClampedFix64 x) => (ClampedFix64)Math.Atan((double)x);
            ClampedFix64 IMath<ClampedFix64>.Atan2(ClampedFix64 x, ClampedFix64 y) => (ClampedFix64)Math.Atan2((double)x, (double)y);
            ClampedFix64 IMath<ClampedFix64>.Atanh(ClampedFix64 x) => (ClampedFix64)MathShim.Atanh((double)x);
            ClampedFix64 IMath<ClampedFix64>.Cbrt(ClampedFix64 x) => (ClampedFix64)MathShim.Cbrt((double)x);
            ClampedFix64 IMath<ClampedFix64>.Ceiling(ClampedFix64 x) => new ClampedFix64(Scaled.Ceiling(x._scaledValue, ScalingFactor));
            ClampedFix64 IMath<ClampedFix64>.Clamp(ClampedFix64 x, ClampedFix64 bound1, ClampedFix64 bound2) => new ClampedFix64(bound1 > bound2 ? Math.Min(bound1._scaledValue, Math.Max(bound2._scaledValue, x._scaledValue)) : Math.Min(bound2._scaledValue, Math.Max(bound1._scaledValue, x._scaledValue)));
            ClampedFix64 IMath<ClampedFix64>.Cos(ClampedFix64 x) => (ClampedFix64)Math.Cos((double)x);
            ClampedFix64 IMath<ClampedFix64>.Cosh(ClampedFix64 x) => (ClampedFix64)Math.Cosh((double)x);
            ClampedFix64 IMath<ClampedFix64>.E { get; } = (ClampedFix64)Math.E;
            ClampedFix64 IMath<ClampedFix64>.Exp(ClampedFix64 x) => (ClampedFix64)Math.Exp((double)x);
            ClampedFix64 IMath<ClampedFix64>.Floor(ClampedFix64 x) => new ClampedFix64(Scaled.Floor(x._scaledValue, ScalingFactor));
            ClampedFix64 IMath<ClampedFix64>.IEEERemainder(ClampedFix64 x, ClampedFix64 y) => (ClampedFix64)Math.IEEERemainder((double)x, (double)y);
            ClampedFix64 IMath<ClampedFix64>.Log(ClampedFix64 x) => (ClampedFix64)Math.Log((double)x);
            ClampedFix64 IMath<ClampedFix64>.Log(ClampedFix64 x, ClampedFix64 y) => (ClampedFix64)Math.Log((double)x, (double)y);
            ClampedFix64 IMath<ClampedFix64>.Log10(ClampedFix64 x) => (ClampedFix64)Math.Log10((double)x);
            ClampedFix64 IMath<ClampedFix64>.Max(ClampedFix64 x, ClampedFix64 y) => new ClampedFix64(Math.Max(x._scaledValue, y._scaledValue));
            ClampedFix64 IMath<ClampedFix64>.Min(ClampedFix64 x, ClampedFix64 y) => new ClampedFix64(Math.Min(x._scaledValue, y._scaledValue));
            ClampedFix64 IMath<ClampedFix64>.PI { get; } = (ClampedFix64)Math.PI;
            ClampedFix64 IMath<ClampedFix64>.Pow(ClampedFix64 x, ClampedFix64 y) => y == 1 ? x : (ClampedFix64)Math.Pow((double)x, (double)y);
            ClampedFix64 IMath<ClampedFix64>.Round(ClampedFix64 x) => Round(x, 0, MidpointRounding.ToEven);
            ClampedFix64 IMath<ClampedFix64>.Round(ClampedFix64 x, int digits) => Round(x, digits, MidpointRounding.ToEven);
            ClampedFix64 IMath<ClampedFix64>.Round(ClampedFix64 x, int digits, MidpointRounding mode) => Round(x, digits, mode);
            ClampedFix64 IMath<ClampedFix64>.Round(ClampedFix64 x, MidpointRounding mode) => Round(x, 0, mode);
            ClampedFix64 IMath<ClampedFix64>.Sin(ClampedFix64 x) => (ClampedFix64)Math.Sin((double)x);
            ClampedFix64 IMath<ClampedFix64>.Sinh(ClampedFix64 x) => (ClampedFix64)Math.Sinh((double)x);
            ClampedFix64 IMath<ClampedFix64>.Sqrt(ClampedFix64 x) => (ClampedFix64)Math.Sqrt((double)x);
            ClampedFix64 IMath<ClampedFix64>.Tan(ClampedFix64 x) => (ClampedFix64)Math.Tan((double)x);
            ClampedFix64 IMath<ClampedFix64>.Tanh(ClampedFix64 x) => (ClampedFix64)Math.Tanh((double)x);
            ClampedFix64 IMath<ClampedFix64>.Tau { get; } = (ClampedFix64)(Math.PI * 2d);
            ClampedFix64 IMath<ClampedFix64>.Truncate(ClampedFix64 x) => new ClampedFix64(x._scaledValue / ScalingFactor * ScalingFactor);
            int IMath<ClampedFix64>.Sign(ClampedFix64 x) => Math.Sign(x._scaledValue);

            int INumericBitConverter<ClampedFix64>.ConvertedSize => sizeof(long);
            ClampedFix64 INumericBitConverter<ClampedFix64>.ToNumeric(byte[] value, int startIndex) => new ClampedFix64(BitConverter.ToInt64(value, startIndex));
            byte[] INumericBitConverter<ClampedFix64>.GetBytes(ClampedFix64 value) => BitConverter.GetBytes(value._scaledValue);
#if HAS_SPANS
            ClampedFix64 INumericBitConverter<ClampedFix64>.ToNumeric(ReadOnlySpan<byte> value) => new ClampedFix64(BitConverter.ToInt64(value));
            bool INumericBitConverter<ClampedFix64>.TryWriteBytes(Span<byte> destination, ClampedFix64 value) => BitConverter.TryWriteBytes(destination, value._scaledValue);
#endif

            bool IConvert<ClampedFix64>.ToBoolean(ClampedFix64 value) => value._scaledValue != 0;
            byte IConvert<ClampedFix64>.ToByte(ClampedFix64 value, Conversion mode) => ConvertN.ToByte(value._scaledValue / ScalingFactor, mode.Clamped());
            decimal IConvert<ClampedFix64>.ToDecimal(ClampedFix64 value, Conversion mode) => (decimal)value._scaledValue / ScalingFactor;
            double IConvert<ClampedFix64>.ToDouble(ClampedFix64 value, Conversion mode) => Scaled.ToDouble(value._scaledValue, ScalingFactor);
            float IConvert<ClampedFix64>.ToSingle(ClampedFix64 value, Conversion mode) => (float)value._scaledValue / ScalingFactor;
            int IConvert<ClampedFix64>.ToInt32(ClampedFix64 value, Conversion mode) => ConvertN.ToInt32(value._scaledValue / ScalingFactor, mode.Clamped());
            long IConvert<ClampedFix64>.ToInt64(ClampedFix64 value, Conversion mode) => value._scaledValue / ScalingFactor;
            sbyte IConvertExtended<ClampedFix64>.ToSByte(ClampedFix64 value, Conversion mode) => ConvertN.ToSByte(value._scaledValue / ScalingFactor, mode.Clamped());
            short IConvert<ClampedFix64>.ToInt16(ClampedFix64 value, Conversion mode) => ConvertN.ToInt16(value._scaledValue / ScalingFactor, mode.Clamped());
            string IConvert<ClampedFix64>.ToString(ClampedFix64 value) => value.ToString();
            uint IConvertExtended<ClampedFix64>.ToUInt32(ClampedFix64 value, Conversion mode) => ConvertN.ToUInt32(value._scaledValue / ScalingFactor, mode.Clamped());
            ulong IConvertExtended<ClampedFix64>.ToUInt64(ClampedFix64 value, Conversion mode) => ConvertN.ToUInt64(value._scaledValue / ScalingFactor, mode.Clamped());
            ushort IConvertExtended<ClampedFix64>.ToUInt16(ClampedFix64 value, Conversion mode) => ConvertN.ToUInt16(value._scaledValue / ScalingFactor, mode.Clamped());

            ClampedFix64 IConvert<ClampedFix64>.ToNumeric(bool value) => new ClampedFix64(value ? ScalingFactor : 0);
            ClampedFix64 IConvert<ClampedFix64>.ToNumeric(byte value, Conversion mode) => (ClampedFix64)ConvertN.ToInt64(value, mode.Clamped());
            ClampedFix64 IConvert<ClampedFix64>.ToNumeric(decimal value, Conversion mode) => (ClampedFix64)value;
            ClampedFix64 IConvert<ClampedFix64>.ToNumeric(double value, Conversion mode) => (ClampedFix64)value;
            ClampedFix64 IConvert<ClampedFix64>.ToNumeric(float value, Conversion mode) => (ClampedFix64)value;
            ClampedFix64 IConvert<ClampedFix64>.ToNumeric(int value, Conversion mode) => (ClampedFix64)ConvertN.ToInt64(value, mode.Clamped());
            ClampedFix64 IConvert<ClampedFix64>.ToNumeric(long value, Conversion mode) => (ClampedFix64)value;
            ClampedFix64 IConvertExtended<ClampedFix64>.ToValue(sbyte value, Conversion mode) => (ClampedFix64)ConvertN.ToInt64(value, mode.Clamped());
            ClampedFix64 IConvert<ClampedFix64>.ToNumeric(short value, Conversion mode) => (ClampedFix64)ConvertN.ToInt64(value, mode.Clamped());
            ClampedFix64 IConvert<ClampedFix64>.ToNumeric(string value) => (ClampedFix64)Convert.ToInt64(value);
            ClampedFix64 IConvertExtended<ClampedFix64>.ToNumeric(uint value, Conversion mode) => (ClampedFix64)ConvertN.ToInt64(value, mode.Clamped());
            ClampedFix64 IConvertExtended<ClampedFix64>.ToNumeric(ulong value, Conversion mode) => new ClampedFix64(Scaled.ToInt64(value, ScalingFactor, mode.Clamped()));
            ClampedFix64 IConvertExtended<ClampedFix64>.ToNumeric(ushort value, Conversion mode) => (ClampedFix64)ConvertN.ToInt64(value, mode.Clamped());

            ClampedFix64 INumericStatic<ClampedFix64>.Parse(string s, NumberStyles? style, IFormatProvider? provider)
                => Parse(s, style ?? NumberStyles.Number, provider);

            ClampedFix64 INumericRandom<ClampedFix64>.Generate(Random random) => new ClampedFix64(random.NextInt64(ScalingFactor));
            ClampedFix64 INumericRandom<ClampedFix64>.Generate(Random random, ClampedFix64 maxValue) => new ClampedFix64(random.NextInt64(maxValue._scaledValue));
            ClampedFix64 INumericRandom<ClampedFix64>.Generate(Random random, ClampedFix64 minValue, ClampedFix64 maxValue) => new ClampedFix64(random.NextInt64(minValue._scaledValue, maxValue._scaledValue));
            ClampedFix64 INumericRandom<ClampedFix64>.Generate(Random random, Generation mode) => new ClampedFix64(random.NextInt64(mode == Generation.Extended ? long.MinValue : 0, mode == Generation.Extended ? long.MaxValue : ScalingFactor, mode));
            ClampedFix64 INumericRandom<ClampedFix64>.Generate(Random random, ClampedFix64 minValue, ClampedFix64 maxValue, Generation mode) => new ClampedFix64(random.NextInt64(minValue._scaledValue, maxValue._scaledValue, mode));

            ClampedFix64 IVariantRandom<ClampedFix64>.Generate(Random random, Variants variants) => new ClampedFix64(random.NextInt64(variants));

            private static ClampedFix64 Round(ClampedFix64 value, int digits, MidpointRounding mode)
            {
                if (digits < 0) throw new ArgumentOutOfRangeException(nameof(digits), digits, "Must be positive.");
                if (digits > 5) return value;
                return new ClampedFix64(Scaled.Round(value._scaledValue, 6 - digits, mode));
            }
        }
    }
}
