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
using Jodo.Primitives;
using Jodo.Primitives.Compatibility;

namespace Jodo.Numerics
{
    /// <summary>
    /// Represents a decimal fixed-point unsigned number.
    /// </summary>
    [Serializable]
    [DebuggerDisplay("{ToString(),nq}")]
    public readonly struct UFix64 : INumericExtended<UFix64>
    {
        public static readonly UFix64 Epsilon = new UFix64(1);
        public static readonly UFix64 MaxValue = new UFix64(ulong.MaxValue);
        public static readonly UFix64 MinValue = new UFix64(ulong.MinValue);

        private const ulong ScalingFactor = 1_000_000;

        private readonly ulong _scaledValue;

        private UFix64(ulong scaledValue)
        {
            _scaledValue = scaledValue;
        }

        private UFix64(SerializationInfo info, StreamingContext context) : this(info.GetUInt64(nameof(UFix64))) { }
        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context) => info.AddValue(nameof(UFix64), _scaledValue);

        public int CompareTo(object? obj) => obj is UFix64 other ? CompareTo(other) : 1;
        public int CompareTo(UFix64 other) => _scaledValue.CompareTo(other._scaledValue);
        public bool Equals(UFix64 other) => _scaledValue == other._scaledValue;
        public override bool Equals(object? obj) => obj is UFix64 other && Equals(other);
        public override int GetHashCode() => _scaledValue.GetHashCode();
        public override string ToString() => ScaledMath.ToString(_scaledValue, ScalingFactor, null);
        public string ToString(IFormatProvider formatProvider) => ((double)this).ToString(formatProvider);
        public string ToString(string format) => ((double)this).ToString(format);
        public string ToString(string? format, IFormatProvider? formatProvider) => ((double)this).ToString(format, formatProvider);

        public static bool TryParse(string s, IFormatProvider? provider, out UFix64 result) => TryHelper.Run(() => Parse(s, provider), out result);
        public static bool TryParse(string s, NumberStyles style, IFormatProvider? provider, out UFix64 result) => TryHelper.Run(() => Parse(s, style, provider), out result);
        public static bool TryParse(string s, NumberStyles style, out UFix64 result) => TryHelper.Run(() => Parse(s, style), out result);
        public static bool TryParse(string s, out UFix64 result) => TryHelper.Run(() => Parse(s), out result);
        public static UFix64 Parse(string s) => new UFix64(ScaledMath.Parse(s, ScalingFactor, default, null));
        public static UFix64 Parse(string s, IFormatProvider? provider) => new UFix64(ScaledMath.Parse(s, ScalingFactor, default, provider));
        public static UFix64 Parse(string s, NumberStyles style) => new UFix64(ScaledMath.Parse(s, ScalingFactor, style, null));
        public static UFix64 Parse(string s, NumberStyles style, IFormatProvider? provider) => new UFix64(ScaledMath.Parse(s, ScalingFactor, style, provider));

        private static UFix64 Round(UFix64 value, int digits, MidpointRounding mode)
        {
            if (digits < 0) throw new ArgumentOutOfRangeException(nameof(digits), digits, "Must be positive.");
            if (digits > 5) return value;
            return new UFix64(ScaledMath.Round(value._scaledValue, 6 - digits, mode));
        }

        [SuppressMessage("Style", "JSON002:Probable JSON string detected", Justification = "False positive")]
        private static UFix64 FromDouble(double value)
        {
            string str = string
                .Format(CultureInfo.InvariantCulture, "{0:0.0000000}", value)
                .Replace(".", string.Empty);
            str = str.Substring(0, str.Length - 1);
            if (ulong.TryParse(str, out ulong lng))
            {
                return new UFix64(lng);
            }
            else
            {
                if (value > 0) return MaxValue;
                return MinValue;
            }
        }

        private static double ToDouble(UFix64 value)
        {
            ulong integral = value._scaledValue / ScalingFactor;
            ulong mantissa = value._scaledValue % ScalingFactor;

            double result = (double)mantissa / ScalingFactor;
            result += integral;
            return result;
        }

        [CLSCompliant(false)] public static explicit operator UFix64(sbyte value) => new UFix64((ulong)value * ScalingFactor);
        [CLSCompliant(false)] public static explicit operator UFix64(ulong value) => new UFix64(value * ScalingFactor);
        [CLSCompliant(false)] public static implicit operator UFix64(uint value) => new UFix64(value * ScalingFactor);
        [CLSCompliant(false)] public static implicit operator UFix64(ushort value) => new UFix64(value * ScalingFactor);
        public static explicit operator UFix64(decimal value) => value < 0 ? new UFix64(0) : new UFix64((ulong)(value * ScalingFactor));
        public static explicit operator UFix64(double value) => value < 0 ? new UFix64(0) : FromDouble(value);
        public static explicit operator UFix64(float value) => value < 0 ? new UFix64(0) : new UFix64((ulong)(value * ScalingFactor));
        public static explicit operator UFix64(int value) => new UFix64((ulong)value * ScalingFactor);
        public static explicit operator UFix64(long value) => new UFix64((ulong)value * ScalingFactor);
        public static explicit operator UFix64(short value) => new UFix64((ulong)value * ScalingFactor);
        public static implicit operator UFix64(byte value) => new UFix64(value * ScalingFactor);

        [CLSCompliant(false)] public static explicit operator sbyte(UFix64 value) => (sbyte)(value._scaledValue / ScalingFactor);
        [CLSCompliant(false)] public static explicit operator uint(UFix64 value) => (uint)(value._scaledValue / ScalingFactor);
        [CLSCompliant(false)] public static explicit operator ulong(UFix64 value) => value._scaledValue / ScalingFactor;
        [CLSCompliant(false)] public static explicit operator ushort(UFix64 value) => (ushort)(value._scaledValue / ScalingFactor);
        public static explicit operator byte(UFix64 value) => (byte)(value._scaledValue / ScalingFactor);
        public static explicit operator decimal(UFix64 value) => (decimal)value._scaledValue / ScalingFactor;
        public static explicit operator double(UFix64 value) => ToDouble(value);
        public static explicit operator float(UFix64 value) => (float)value._scaledValue / ScalingFactor;
        public static explicit operator int(UFix64 value) => (int)(value._scaledValue / ScalingFactor);
        public static explicit operator long(UFix64 value) => (long)(value._scaledValue / ScalingFactor);
        public static explicit operator short(UFix64 value) => (short)(value._scaledValue / ScalingFactor);

        public static bool operator !=(UFix64 left, UFix64 right) => left._scaledValue != right._scaledValue;
        public static bool operator <(UFix64 left, UFix64 right) => left._scaledValue < right._scaledValue;
        public static bool operator <=(UFix64 left, UFix64 right) => left._scaledValue <= right._scaledValue;
        public static bool operator ==(UFix64 left, UFix64 right) => left._scaledValue == right._scaledValue;
        public static bool operator >(UFix64 left, UFix64 right) => left._scaledValue > right._scaledValue;
        public static bool operator >=(UFix64 left, UFix64 right) => left._scaledValue >= right._scaledValue;
        public static UFix64 operator %(UFix64 left, UFix64 right) => new UFix64(left._scaledValue % right._scaledValue);
        public static UFix64 operator &(UFix64 left, UFix64 right) => new UFix64(left._scaledValue & right._scaledValue);
        public static UFix64 operator -(UFix64 _) => 0;
        public static UFix64 operator -(UFix64 left, UFix64 right) => new UFix64(left._scaledValue - right._scaledValue);
        public static UFix64 operator --(UFix64 value) => new UFix64(value._scaledValue - ScalingFactor);
        public static UFix64 operator *(UFix64 left, UFix64 right) => new UFix64(ScaledMath.Multiply(left._scaledValue, right._scaledValue, ScalingFactor));
        public static UFix64 operator /(UFix64 left, UFix64 right) => new UFix64(ScaledMath.Divide(left._scaledValue, right._scaledValue, ScalingFactor));
        public static UFix64 operator ^(UFix64 left, UFix64 right) => new UFix64(left._scaledValue ^ right._scaledValue);
        public static UFix64 operator |(UFix64 left, UFix64 right) => new UFix64(left._scaledValue | right._scaledValue);
        public static UFix64 operator ~(UFix64 value) => new UFix64(~value._scaledValue);
        public static UFix64 operator +(UFix64 left, UFix64 right) => new UFix64(left._scaledValue + right._scaledValue);
        public static UFix64 operator +(UFix64 value) => value;
        public static UFix64 operator ++(UFix64 value) => new UFix64(value._scaledValue + ScalingFactor);
        public static UFix64 operator <<(UFix64 left, int right) => new UFix64(left._scaledValue << right);
        public static UFix64 operator >>(UFix64 left, int right) => new UFix64(left._scaledValue >> right);

        TypeCode IConvertible.GetTypeCode() => TypeCode.Object;
        bool IConvertible.ToBoolean(IFormatProvider provider) => ((IConvert<UFix64>)Utilities.Instance).ToBoolean(this);
        char IConvertible.ToChar(IFormatProvider provider) => ((IConvertible)((IConvert<UFix64>)Utilities.Instance).ToDouble(this, Conversion.Default)).ToChar(provider);
        sbyte IConvertible.ToSByte(IFormatProvider provider) => ((IConvertExtended<UFix64>)Utilities.Instance).ToSByte(this, Conversion.Default);
        byte IConvertible.ToByte(IFormatProvider provider) => ((IConvert<UFix64>)Utilities.Instance).ToByte(this, Conversion.Default);
        short IConvertible.ToInt16(IFormatProvider provider) => ((IConvert<UFix64>)Utilities.Instance).ToInt16(this, Conversion.Default);
        ushort IConvertible.ToUInt16(IFormatProvider provider) => ((IConvertExtended<UFix64>)Utilities.Instance).ToUInt16(this, Conversion.Default);
        int IConvertible.ToInt32(IFormatProvider provider) => ((IConvert<UFix64>)Utilities.Instance).ToInt32(this, Conversion.Default);
        uint IConvertible.ToUInt32(IFormatProvider provider) => ((IConvertExtended<UFix64>)Utilities.Instance).ToUInt32(this, Conversion.Default);
        long IConvertible.ToInt64(IFormatProvider provider) => ((IConvert<UFix64>)Utilities.Instance).ToInt64(this, Conversion.Default);
        ulong IConvertible.ToUInt64(IFormatProvider provider) => ((IConvertExtended<UFix64>)Utilities.Instance).ToUInt64(this, Conversion.Default);
        float IConvertible.ToSingle(IFormatProvider provider) => ((IConvert<UFix64>)Utilities.Instance).ToSingle(this, Conversion.Default);
        double IConvertible.ToDouble(IFormatProvider provider) => ((IConvert<UFix64>)Utilities.Instance).ToDouble(this, Conversion.Default);
        decimal IConvertible.ToDecimal(IFormatProvider provider) => ((IConvert<UFix64>)Utilities.Instance).ToDecimal(this, Conversion.Default);
        DateTime IConvertible.ToDateTime(IFormatProvider provider) => ((IConvertible)((IConvert<UFix64>)Utilities.Instance).ToDouble(this, Conversion.Default)).ToDateTime(provider);
        object IConvertible.ToType(Type conversionType, IFormatProvider provider) => ((IConvertible)((IConvert<UFix64>)Utilities.Instance).ToDouble(this, Conversion.Default)).ToType(conversionType, provider);

        bool INumeric<UFix64>.IsGreaterThan(UFix64 value) => this > value;
        bool INumeric<UFix64>.IsGreaterThanOrEqualTo(UFix64 value) => this >= value;
        bool INumeric<UFix64>.IsLessThan(UFix64 value) => this < value;
        bool INumeric<UFix64>.IsLessThanOrEqualTo(UFix64 value) => this <= value;
        UFix64 INumeric<UFix64>.Add(UFix64 value) => this + value;
        UFix64 INumeric<UFix64>.BitwiseComplement() => ~this;
        UFix64 INumeric<UFix64>.Divide(UFix64 value) => this / value;
        UFix64 INumeric<UFix64>.LeftShift(int count) => this << count;
        UFix64 INumeric<UFix64>.LogicalAnd(UFix64 value) => this & value;
        UFix64 INumeric<UFix64>.LogicalExclusiveOr(UFix64 value) => this ^ value;
        UFix64 INumeric<UFix64>.LogicalOr(UFix64 value) => this | value;
        UFix64 INumeric<UFix64>.Multiply(UFix64 value) => this * value;
        UFix64 INumeric<UFix64>.Negative() => -this;
        UFix64 INumeric<UFix64>.Positive() => +this;
        UFix64 INumeric<UFix64>.Remainder(UFix64 value) => this % value;
        UFix64 INumeric<UFix64>.RightShift(int count) => this >> count;
        UFix64 INumeric<UFix64>.Subtract(UFix64 value) => this - value;

        INumericBitConverter<UFix64> IProvider<INumericBitConverter<UFix64>>.GetInstance() => Utilities.Instance;
        IConvert<UFix64> IProvider<IConvert<UFix64>>.GetInstance() => Utilities.Instance;
        IConvertExtended<UFix64> IProvider<IConvertExtended<UFix64>>.GetInstance() => Utilities.Instance;
        IMath<UFix64> IProvider<IMath<UFix64>>.GetInstance() => Utilities.Instance;
        INumericStatic<UFix64> IProvider<INumericStatic<UFix64>>.GetInstance() => Utilities.Instance;
        INumericRandom<UFix64> IProvider<INumericRandom<UFix64>>.GetInstance() => Utilities.Instance;
        IVariantRandom<UFix64> IProvider<IVariantRandom<UFix64>>.GetInstance() => Utilities.Instance;

        private sealed class Utilities :
            IConvert<UFix64>,
            IConvertExtended<UFix64>,
            IMath<UFix64>,
            INumericBitConverter<UFix64>,
            INumericRandom<UFix64>,
            INumericStatic<UFix64>,
            IVariantRandom<UFix64>
        {
            public static readonly Utilities Instance = new Utilities();

            bool INumericStatic<UFix64>.HasFloatingPoint => false;
            bool INumericStatic<UFix64>.HasInfinity => false;
            bool INumericStatic<UFix64>.HasNaN => false;
            bool INumericStatic<UFix64>.IsFinite(UFix64 x) => true;
            bool INumericStatic<UFix64>.IsInfinity(UFix64 x) => false;
            bool INumericStatic<UFix64>.IsNaN(UFix64 x) => false;
            bool INumericStatic<UFix64>.IsNegative(UFix64 x) => false;
            bool INumericStatic<UFix64>.IsNegativeInfinity(UFix64 x) => false;
            bool INumericStatic<UFix64>.IsNormal(UFix64 x) => false;
            bool INumericStatic<UFix64>.IsPositiveInfinity(UFix64 x) => false;
            bool INumericStatic<UFix64>.IsReal => true;
            bool INumericStatic<UFix64>.IsSigned => false;
            bool INumericStatic<UFix64>.IsSubnormal(UFix64 x) => false;
            UFix64 INumericStatic<UFix64>.Epsilon { get; } = new UFix64(1);
            UFix64 INumericStatic<UFix64>.MaxUnit { get; } = new UFix64(ScalingFactor);
            UFix64 INumericStatic<UFix64>.MaxValue => MaxValue;
            UFix64 INumericStatic<UFix64>.MinUnit => 0;
            UFix64 INumericStatic<UFix64>.MinValue => MinValue;
            UFix64 INumericStatic<UFix64>.One { get; } = new UFix64(ScalingFactor);
            UFix64 INumericStatic<UFix64>.Ten { get; } = new UFix64(10 * ScalingFactor);
            UFix64 INumericStatic<UFix64>.Two { get; } = new UFix64(2 * ScalingFactor);
            UFix64 INumericStatic<UFix64>.Zero => 0;

            int IMath<UFix64>.Sign(UFix64 x) => x._scaledValue == 0 ? 0 : 1;
            UFix64 IMath<UFix64>.Abs(UFix64 value) => value;
            UFix64 IMath<UFix64>.Acos(UFix64 x) => (UFix64)Math.Acos((double)x);
            UFix64 IMath<UFix64>.Acosh(UFix64 x) => (UFix64)MathCompat.Acosh((double)x);
            UFix64 IMath<UFix64>.Asin(UFix64 x) => (UFix64)Math.Asin((double)x);
            UFix64 IMath<UFix64>.Asinh(UFix64 x) => (UFix64)MathCompat.Asinh((double)x);
            UFix64 IMath<UFix64>.Atan(UFix64 x) => (UFix64)Math.Atan((double)x);
            UFix64 IMath<UFix64>.Atan2(UFix64 x, UFix64 y) => (UFix64)Math.Atan2((double)x, (double)y);
            UFix64 IMath<UFix64>.Atanh(UFix64 x) => (UFix64)MathCompat.Atanh((double)x);
            UFix64 IMath<UFix64>.Cbrt(UFix64 x) => (UFix64)MathCompat.Cbrt((double)x);
            UFix64 IMath<UFix64>.Ceiling(UFix64 x) => new UFix64(ScaledMath.Ceiling(x._scaledValue, ScalingFactor));
            UFix64 IMath<UFix64>.Clamp(UFix64 x, UFix64 bound1, UFix64 bound2) => new UFix64(bound1 > bound2 ? Math.Min(bound1._scaledValue, Math.Max(bound2._scaledValue, x._scaledValue)) : Math.Min(bound2._scaledValue, Math.Max(bound1._scaledValue, x._scaledValue)));
            UFix64 IMath<UFix64>.Cos(UFix64 x) => (UFix64)Math.Cos((double)x);
            UFix64 IMath<UFix64>.Cosh(UFix64 x) => (UFix64)Math.Cosh((double)x);
            UFix64 IMath<UFix64>.DegreesToRadians(UFix64 x) => (UFix64)((double)x * BitOperations.RadiansPerDegree);
            UFix64 IMath<UFix64>.E { get; } = (UFix64)Math.E;
            UFix64 IMath<UFix64>.Exp(UFix64 x) => (UFix64)Math.Exp((double)x);
            UFix64 IMath<UFix64>.Floor(UFix64 x) => new UFix64(ScaledMath.Floor(x._scaledValue, ScalingFactor));
            UFix64 IMath<UFix64>.IEEERemainder(UFix64 x, UFix64 y) => (UFix64)Math.IEEERemainder((double)x, (double)y);
            UFix64 IMath<UFix64>.Log(UFix64 x) => (UFix64)Math.Log((double)x);
            UFix64 IMath<UFix64>.Log(UFix64 x, UFix64 y) => (UFix64)Math.Log((double)x, (double)y);
            UFix64 IMath<UFix64>.Log10(UFix64 x) => (UFix64)Math.Log10((double)x);
            UFix64 IMath<UFix64>.Max(UFix64 x, UFix64 y) => new UFix64(Math.Max(x._scaledValue, y._scaledValue));
            UFix64 IMath<UFix64>.Min(UFix64 x, UFix64 y) => new UFix64(Math.Min(x._scaledValue, y._scaledValue));
            UFix64 IMath<UFix64>.PI { get; } = (UFix64)Math.PI;
            UFix64 IMath<UFix64>.Pow(UFix64 x, UFix64 y) => y == 1 ? x : (UFix64)Math.Pow((double)x, (double)y);
            UFix64 IMath<UFix64>.RadiansToDegrees(UFix64 x) => (UFix64)((double)x * BitOperations.DegreesPerRadian);
            UFix64 IMath<UFix64>.Round(UFix64 x) => Round(x, 0, MidpointRounding.ToEven);
            UFix64 IMath<UFix64>.Round(UFix64 x, int digits) => Round(x, digits, MidpointRounding.ToEven);
            UFix64 IMath<UFix64>.Round(UFix64 x, int digits, MidpointRounding mode) => Round(x, digits, mode);
            UFix64 IMath<UFix64>.Round(UFix64 x, MidpointRounding mode) => Round(x, 0, mode);
            UFix64 IMath<UFix64>.Sin(UFix64 x) => (UFix64)Math.Sin((double)x);
            UFix64 IMath<UFix64>.Sinh(UFix64 x) => (UFix64)Math.Sinh((double)x);
            UFix64 IMath<UFix64>.Sqrt(UFix64 x) => (UFix64)Math.Sqrt((double)x);
            UFix64 IMath<UFix64>.Tan(UFix64 x) => (UFix64)Math.Tan((double)x);
            UFix64 IMath<UFix64>.Tanh(UFix64 x) => (UFix64)Math.Tanh((double)x);
            UFix64 IMath<UFix64>.Tau { get; } = (UFix64)(Math.PI * 2d);
            UFix64 IMath<UFix64>.Truncate(UFix64 x) => new UFix64(x._scaledValue / ScalingFactor * ScalingFactor);

            int INumericBitConverter<UFix64>.ConvertedSize => sizeof(ulong);
            UFix64 INumericBitConverter<UFix64>.ToNumeric(byte[] value, int startIndex) => new UFix64(BitConverter.ToUInt64(value, startIndex));
            byte[] INumericBitConverter<UFix64>.GetBytes(UFix64 value) => BitConverter.GetBytes(value._scaledValue);

            bool IConvert<UFix64>.ToBoolean(UFix64 value) => value._scaledValue != 0;
            byte IConvert<UFix64>.ToByte(UFix64 value, Conversion mode) => ConvertN.ToByte(value._scaledValue / ScalingFactor, mode);
            decimal IConvert<UFix64>.ToDecimal(UFix64 value, Conversion mode) => (decimal)value._scaledValue / ScalingFactor;
            double IConvert<UFix64>.ToDouble(UFix64 value, Conversion mode) => (double)value._scaledValue / ScalingFactor;
            float IConvert<UFix64>.ToSingle(UFix64 value, Conversion mode) => (float)value._scaledValue / ScalingFactor;
            int IConvert<UFix64>.ToInt32(UFix64 value, Conversion mode) => ConvertN.ToInt32(value._scaledValue / ScalingFactor, mode);
            long IConvert<UFix64>.ToInt64(UFix64 value, Conversion mode) => ConvertN.ToInt64(value._scaledValue / ScalingFactor, mode);
            sbyte IConvertExtended<UFix64>.ToSByte(UFix64 value, Conversion mode) => ConvertN.ToSByte(value._scaledValue / ScalingFactor, mode);
            short IConvert<UFix64>.ToInt16(UFix64 value, Conversion mode) => ConvertN.ToInt16(value._scaledValue / ScalingFactor, mode);
            string IConvert<UFix64>.ToString(UFix64 value) => value.ToString();
            uint IConvertExtended<UFix64>.ToUInt32(UFix64 value, Conversion mode) => ConvertN.ToUInt32(value._scaledValue / ScalingFactor, mode);
            ulong IConvertExtended<UFix64>.ToUInt64(UFix64 value, Conversion mode) => value._scaledValue / ScalingFactor;
            ushort IConvertExtended<UFix64>.ToUInt16(UFix64 value, Conversion mode) => ConvertN.ToUInt16(value._scaledValue / ScalingFactor, mode);

            UFix64 IConvert<UFix64>.ToNumeric(bool value) => value ? new UFix64(ScalingFactor) : new UFix64(0);
            UFix64 IConvert<UFix64>.ToNumeric(byte value, Conversion mode) => (UFix64)ConvertN.ToUInt64(value, mode);
            UFix64 IConvert<UFix64>.ToNumeric(decimal value, Conversion mode) => (UFix64)value;
            UFix64 IConvert<UFix64>.ToNumeric(double value, Conversion mode) => (UFix64)value;
            UFix64 IConvert<UFix64>.ToNumeric(float value, Conversion mode) => (UFix64)value;
            UFix64 IConvert<UFix64>.ToNumeric(int value, Conversion mode) => (UFix64)ConvertN.ToUInt64(value, mode);
            UFix64 IConvert<UFix64>.ToNumeric(long value, Conversion mode) => (UFix64)value;
            UFix64 IConvertExtended<UFix64>.ToValue(sbyte value, Conversion mode) => (UFix64)ConvertN.ToUInt64(value, mode);
            UFix64 IConvert<UFix64>.ToNumeric(short value, Conversion mode) => (UFix64)ConvertN.ToUInt64(value, mode);
            UFix64 IConvert<UFix64>.ToNumeric(string value) => (UFix64)Convert.ToUInt64(value);
            UFix64 IConvertExtended<UFix64>.ToNumeric(uint value, Conversion mode) => (UFix64)ConvertN.ToUInt64(value, mode);
            UFix64 IConvertExtended<UFix64>.ToNumeric(ulong value, Conversion mode) => (UFix64)value;
            UFix64 IConvertExtended<UFix64>.ToNumeric(ushort value, Conversion mode) => (UFix64)ConvertN.ToUInt64(value, mode);

            UFix64 INumericStatic<UFix64>.Parse(string s, NumberStyles? style, IFormatProvider? provider)
                => Parse(s, style ?? NumberStyles.Number, provider);

            UFix64 INumericRandom<UFix64>.Next(Random random) => new UFix64(random.NextUInt64());
            UFix64 INumericRandom<UFix64>.Next(Random random, UFix64 maxValue) => new UFix64(random.NextUInt64(maxValue._scaledValue));
            UFix64 INumericRandom<UFix64>.Next(Random random, UFix64 minValue, UFix64 maxValue) => new UFix64(random.NextUInt64(minValue._scaledValue, maxValue._scaledValue));
            UFix64 INumericRandom<UFix64>.Next(Random random, Generation mode) => new UFix64(random.NextUInt64(mode));
            UFix64 INumericRandom<UFix64>.Next(Random random, UFix64 minValue, UFix64 maxValue, Generation mode) => new UFix64(random.NextUInt64(minValue._scaledValue, maxValue._scaledValue, mode));

            UFix64 IVariantRandom<UFix64>.Next(Random random, Scenarios scenarios) => NumericVariant.Generate<UFix64>(random, scenarios);
        }
    }
}
