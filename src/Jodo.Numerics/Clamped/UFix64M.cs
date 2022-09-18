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

namespace Jodo.Numerics.Clamped
{
    /// <summary>
    /// Represents a decimal fixed-point unsigned number that cannot overflow.
    /// </summary>
    [Serializable]
    [DebuggerDisplay("{ToString(),nq}")]
    public readonly struct UFix64M : INumericExtended<UFix64M>
    {
        public static readonly UFix64M Epsilon = new UFix64M(1);
        public static readonly UFix64M MaxValue = new UFix64M(ulong.MaxValue);
        public static readonly UFix64M MinValue = new UFix64M(ulong.MinValue);

        private const ulong ScalingFactor = 1_000_000;

        private readonly ulong _scaledValue;

        private UFix64M(ulong scaledValue)
        {
            _scaledValue = scaledValue;
        }

        private UFix64M(SerializationInfo info, StreamingContext context) : this(info.GetUInt64(nameof(UFix64M))) { }
        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context) => info.AddValue(nameof(UFix64M), _scaledValue);

        public int CompareTo(object? obj) => obj is UFix64M other ? CompareTo(other) : 1;
        public int CompareTo(UFix64M other) => _scaledValue.CompareTo(other._scaledValue);
        public bool Equals(UFix64M other) => _scaledValue == other._scaledValue;
        public override bool Equals(object? obj) => obj is UFix64M other && Equals(other);
        public override int GetHashCode() => _scaledValue.GetHashCode();
        public override string ToString() => Scaled.ToString(_scaledValue, ScalingFactor, null);
        public string ToString(IFormatProvider formatProvider) => ((double)this).ToString(formatProvider);
        public string ToString(string format) => ((double)this).ToString(format);
        public string ToString(string? format, IFormatProvider? formatProvider) => ((double)this).ToString(format, formatProvider);

        public static bool TryParse(string s, IFormatProvider? provider, out UFix64M result) => FuncExtensions.Try(() => Parse(s, provider), out result);
        public static bool TryParse(string s, NumberStyles style, IFormatProvider? provider, out UFix64M result) => FuncExtensions.Try(() => Parse(s, style, provider), out result);
        public static bool TryParse(string s, NumberStyles style, out UFix64M result) => FuncExtensions.Try(() => Parse(s, style), out result);
        public static bool TryParse(string s, out UFix64M result) => FuncExtensions.Try(() => Parse(s), out result);
        public static UFix64M Parse(string s) => new UFix64M(Scaled.Parse(s, ScalingFactor, null, null));
        public static UFix64M Parse(string s, IFormatProvider? provider) => (UFix64M)double.Parse(s, provider);
        public static UFix64M Parse(string s, NumberStyles style) => (UFix64M)double.Parse(s, style);
        public static UFix64M Parse(string s, NumberStyles style, IFormatProvider? provider) => (UFix64M)double.Parse(s, style, provider);

        private static UFix64M Round(UFix64M value, int digits, MidpointRounding mode)
        {
            if (digits < 0) throw new ArgumentOutOfRangeException(nameof(digits), digits, "Must be positive.");
            if (digits > 5) return value;
            return new UFix64M(Scaled.Round(value._scaledValue, 6 - digits, mode));
        }

        [SuppressMessage("Style", "JSON002:Probable JSON string detected", Justification = "False positive")]
        private static UFix64M FromDouble(double value)
        {
            string str = string
                .Format(CultureInfo.InvariantCulture, "{0:0.0000000}", value)
                .Replace(".", string.Empty);
            str = str.Substring(0, str.Length - 1);
            if (ulong.TryParse(str, out ulong lng))
            {
                return new UFix64M(lng);
            }
            else
            {
                if (value > 0) return MaxValue;
                return MinValue;
            }
        }

        [CLSCompliant(false)] public static explicit operator UFix64M(sbyte value) => new UFix64M(ConvertN.ToUInt64(value, Conversion.CastClamp) * ScalingFactor);
        [CLSCompliant(false)] public static explicit operator UFix64M(ulong value) => new UFix64M(value * ScalingFactor);
        [CLSCompliant(false)] public static implicit operator UFix64M(uint value) => new UFix64M(ConvertN.ToUInt64(value, Conversion.CastClamp) * ScalingFactor);
        [CLSCompliant(false)] public static implicit operator UFix64M(ushort value) => new UFix64M(ConvertN.ToUInt64(value, Conversion.CastClamp) * ScalingFactor);
        public static explicit operator UFix64M(decimal value) => value < 0 ? new UFix64M(0) : new UFix64M(ConvertN.ToUInt64(Clamped.Multiply(value, ScalingFactor), Conversion.CastClamp));
        public static explicit operator UFix64M(double value) => value < 0 ? new UFix64M(0) : FromDouble(value);
        public static explicit operator UFix64M(float value) => value < 0 ? new UFix64M(0) : new UFix64M(ConvertN.ToUInt64(value * ScalingFactor, Conversion.CastClamp));
        public static explicit operator UFix64M(int value) => new UFix64M(ConvertN.ToUInt64(value, Conversion.CastClamp) * ScalingFactor);
        public static explicit operator UFix64M(long value) => new UFix64M(ConvertN.ToUInt64(value, Conversion.CastClamp) * ScalingFactor);
        public static explicit operator UFix64M(short value) => new UFix64M(ConvertN.ToUInt64(value, Conversion.CastClamp) * ScalingFactor);
        public static implicit operator UFix64M(byte value) => new UFix64M(value * ScalingFactor);

        [CLSCompliant(false)] public static explicit operator sbyte(UFix64M value) => ConvertN.ToSByte(value._scaledValue / ScalingFactor, Conversion.CastClamp);
        [CLSCompliant(false)] public static explicit operator uint(UFix64M value) => ConvertN.ToUInt32(value._scaledValue / ScalingFactor, Conversion.CastClamp);
        [CLSCompliant(false)] public static explicit operator ulong(UFix64M value) => value._scaledValue / ScalingFactor;
        [CLSCompliant(false)] public static explicit operator ushort(UFix64M value) => ConvertN.ToUInt16(value._scaledValue / ScalingFactor, Conversion.CastClamp);
        public static explicit operator byte(UFix64M value) => ConvertN.ToByte(value._scaledValue / ScalingFactor, Conversion.CastClamp);
        public static explicit operator decimal(UFix64M value) => (decimal)value._scaledValue / ScalingFactor;
        public static explicit operator double(UFix64M value) => Scaled.ToDouble(value._scaledValue, ScalingFactor);
        public static explicit operator float(UFix64M value) => (float)value._scaledValue / ScalingFactor;
        public static explicit operator int(UFix64M value) => ConvertN.ToInt32(value._scaledValue / ScalingFactor, Conversion.CastClamp);
        public static explicit operator long(UFix64M value) => ConvertN.ToInt64(value._scaledValue / ScalingFactor, Conversion.CastClamp);
        public static explicit operator short(UFix64M value) => ConvertN.ToInt16(value._scaledValue / ScalingFactor, Conversion.CastClamp);

        public static bool operator !=(UFix64M left, UFix64M right) => left._scaledValue != right._scaledValue;
        public static bool operator <(UFix64M left, UFix64M right) => left._scaledValue < right._scaledValue;
        public static bool operator <=(UFix64M left, UFix64M right) => left._scaledValue <= right._scaledValue;
        public static bool operator ==(UFix64M left, UFix64M right) => left._scaledValue == right._scaledValue;
        public static bool operator >(UFix64M left, UFix64M right) => left._scaledValue > right._scaledValue;
        public static bool operator >=(UFix64M left, UFix64M right) => left._scaledValue >= right._scaledValue;
        public static UFix64M operator %(UFix64M left, UFix64M right) => new UFix64M(Clamped.Remainder(left._scaledValue, right._scaledValue));
        public static UFix64M operator &(UFix64M left, UFix64M right) => new UFix64M(left._scaledValue & right._scaledValue);
        public static UFix64M operator -(UFix64M _) => 0;
        public static UFix64M operator -(UFix64M left, UFix64M right) => new UFix64M(Clamped.Subtract(left._scaledValue, right._scaledValue));
        public static UFix64M operator --(UFix64M value) => new UFix64M(value._scaledValue - ScalingFactor);
        public static UFix64M operator *(UFix64M left, UFix64M right) => new UFix64M(Clamped.ScaledMultiply(left._scaledValue, right._scaledValue, ScalingFactor));
        public static UFix64M operator /(UFix64M left, UFix64M right) => new UFix64M(Clamped.ScaledDivide(left._scaledValue, right._scaledValue, ScalingFactor));
        public static UFix64M operator ^(UFix64M left, UFix64M right) => new UFix64M(left._scaledValue ^ right._scaledValue);
        public static UFix64M operator |(UFix64M left, UFix64M right) => new UFix64M(left._scaledValue | right._scaledValue);
        public static UFix64M operator ~(UFix64M value) => new UFix64M(~value._scaledValue);
        public static UFix64M operator +(UFix64M left, UFix64M right) => new UFix64M(Clamped.Add(left._scaledValue, right._scaledValue));
        public static UFix64M operator +(UFix64M value) => value;
        public static UFix64M operator ++(UFix64M value) => new UFix64M(value._scaledValue + ScalingFactor);
        public static UFix64M operator <<(UFix64M left, int right) => new UFix64M(left._scaledValue << right);
        public static UFix64M operator >>(UFix64M left, int right) => new UFix64M(left._scaledValue >> right);

        TypeCode IConvertible.GetTypeCode() => TypeCode.Object;
        bool IConvertible.ToBoolean(IFormatProvider provider) => ((IConvert<UFix64M>)Utilities.Instance).ToBoolean(this);
        char IConvertible.ToChar(IFormatProvider provider) => ((IConvertible)((IConvert<UFix64M>)Utilities.Instance).ToDouble(this, Conversion.Clamp)).ToChar(provider);
        sbyte IConvertible.ToSByte(IFormatProvider provider) => ((IConvertExtended<UFix64M>)Utilities.Instance).ToSByte(this, Conversion.Clamp);
        byte IConvertible.ToByte(IFormatProvider provider) => ((IConvert<UFix64M>)Utilities.Instance).ToByte(this, Conversion.Clamp);
        short IConvertible.ToInt16(IFormatProvider provider) => ((IConvert<UFix64M>)Utilities.Instance).ToInt16(this, Conversion.Clamp);
        ushort IConvertible.ToUInt16(IFormatProvider provider) => ((IConvertExtended<UFix64M>)Utilities.Instance).ToUInt16(this, Conversion.Clamp);
        int IConvertible.ToInt32(IFormatProvider provider) => ((IConvert<UFix64M>)Utilities.Instance).ToInt32(this, Conversion.Clamp);
        uint IConvertible.ToUInt32(IFormatProvider provider) => ((IConvertExtended<UFix64M>)Utilities.Instance).ToUInt32(this, Conversion.Clamp);
        long IConvertible.ToInt64(IFormatProvider provider) => ((IConvert<UFix64M>)Utilities.Instance).ToInt64(this, Conversion.Clamp);
        ulong IConvertible.ToUInt64(IFormatProvider provider) => ((IConvertExtended<UFix64M>)Utilities.Instance).ToUInt64(this, Conversion.Clamp);
        float IConvertible.ToSingle(IFormatProvider provider) => ((IConvert<UFix64M>)Utilities.Instance).ToSingle(this, Conversion.Clamp);
        double IConvertible.ToDouble(IFormatProvider provider) => ((IConvert<UFix64M>)Utilities.Instance).ToDouble(this, Conversion.Clamp);
        decimal IConvertible.ToDecimal(IFormatProvider provider) => ((IConvert<UFix64M>)Utilities.Instance).ToDecimal(this, Conversion.Clamp);
        DateTime IConvertible.ToDateTime(IFormatProvider provider) => ((IConvertible)((IConvert<UFix64M>)Utilities.Instance).ToDouble(this, Conversion.Clamp)).ToDateTime(provider);
        object IConvertible.ToType(Type conversionType, IFormatProvider provider) => this.ToTypeDefault(conversionType, provider);

        bool INumeric<UFix64M>.IsGreaterThan(UFix64M value) => this > value;
        bool INumeric<UFix64M>.IsGreaterThanOrEqualTo(UFix64M value) => this >= value;
        bool INumeric<UFix64M>.IsLessThan(UFix64M value) => this < value;
        bool INumeric<UFix64M>.IsLessThanOrEqualTo(UFix64M value) => this <= value;
        UFix64M INumeric<UFix64M>.Add(UFix64M value) => this + value;
        UFix64M INumeric<UFix64M>.BitwiseComplement() => ~this;
        UFix64M INumeric<UFix64M>.Divide(UFix64M value) => this / value;
        UFix64M INumeric<UFix64M>.LeftShift(int count) => this << count;
        UFix64M INumeric<UFix64M>.LogicalAnd(UFix64M value) => this & value;
        UFix64M INumeric<UFix64M>.LogicalExclusiveOr(UFix64M value) => this ^ value;
        UFix64M INumeric<UFix64M>.LogicalOr(UFix64M value) => this | value;
        UFix64M INumeric<UFix64M>.Multiply(UFix64M value) => this * value;
        UFix64M INumeric<UFix64M>.Negative() => -this;
        UFix64M INumeric<UFix64M>.Positive() => +this;
        UFix64M INumeric<UFix64M>.Remainder(UFix64M value) => this % value;
        UFix64M INumeric<UFix64M>.RightShift(int count) => this >> count;
        UFix64M INumeric<UFix64M>.Subtract(UFix64M value) => this - value;

        INumericBitConverter<UFix64M> IProvider<INumericBitConverter<UFix64M>>.GetInstance() => Utilities.Instance;
        IConvert<UFix64M> IProvider<IConvert<UFix64M>>.GetInstance() => Utilities.Instance;
        IConvertExtended<UFix64M> IProvider<IConvertExtended<UFix64M>>.GetInstance() => Utilities.Instance;
        IMath<UFix64M> IProvider<IMath<UFix64M>>.GetInstance() => Utilities.Instance;
        INumericRandom<UFix64M> IProvider<INumericRandom<UFix64M>>.GetInstance() => Utilities.Instance;
        INumericStatic<UFix64M> IProvider<INumericStatic<UFix64M>>.GetInstance() => Utilities.Instance;
        IVariantRandom<UFix64M> IProvider<IVariantRandom<UFix64M>>.GetInstance() => Utilities.Instance;

        private sealed class Utilities :
            IConvert<UFix64M>,
            IConvertExtended<UFix64M>,
            IMath<UFix64M>,
            INumericBitConverter<UFix64M>,
            INumericRandom<UFix64M>,
            INumericStatic<UFix64M>,
            IVariantRandom<UFix64M>
        {
            public static readonly Utilities Instance = new Utilities();

            bool INumericStatic<UFix64M>.HasFloatingPoint => false;
            bool INumericStatic<UFix64M>.HasInfinity => false;
            bool INumericStatic<UFix64M>.HasNaN => false;
            bool INumericStatic<UFix64M>.IsFinite(UFix64M x) => true;
            bool INumericStatic<UFix64M>.IsInfinity(UFix64M x) => false;
            bool INumericStatic<UFix64M>.IsNaN(UFix64M x) => false;
            bool INumericStatic<UFix64M>.IsNegative(UFix64M x) => false;
            bool INumericStatic<UFix64M>.IsNegativeInfinity(UFix64M x) => false;
            bool INumericStatic<UFix64M>.IsNormal(UFix64M x) => false;
            bool INumericStatic<UFix64M>.IsPositiveInfinity(UFix64M x) => false;
            bool INumericStatic<UFix64M>.IsReal => true;
            bool INumericStatic<UFix64M>.IsSigned => false;
            bool INumericStatic<UFix64M>.IsSubnormal(UFix64M x) => false;
            UFix64M INumericStatic<UFix64M>.Epsilon { get; } = new UFix64M(1);
            UFix64M INumericStatic<UFix64M>.MaxUnit { get; } = new UFix64M(ScalingFactor);
            UFix64M INumericStatic<UFix64M>.MaxValue => MaxValue;
            UFix64M INumericStatic<UFix64M>.MinUnit => 0;
            UFix64M INumericStatic<UFix64M>.MinValue => MinValue;
            UFix64M INumericStatic<UFix64M>.One { get; } = new UFix64M(ScalingFactor);
            UFix64M INumericStatic<UFix64M>.Ten { get; } = new UFix64M(10 * ScalingFactor);
            UFix64M INumericStatic<UFix64M>.Two { get; } = new UFix64M(2 * ScalingFactor);
            UFix64M INumericStatic<UFix64M>.Zero => 0;

            int IMath<UFix64M>.Sign(UFix64M x) => x._scaledValue == 0 ? 0 : 1;
            UFix64M IMath<UFix64M>.Abs(UFix64M value) => value;
            UFix64M IMath<UFix64M>.Acos(UFix64M x) => (UFix64M)Math.Acos((double)x);
            UFix64M IMath<UFix64M>.Acosh(UFix64M x) => (UFix64M)MathShim.Acosh((double)x);
            UFix64M IMath<UFix64M>.Asin(UFix64M x) => (UFix64M)Math.Asin((double)x);
            UFix64M IMath<UFix64M>.Asinh(UFix64M x) => (UFix64M)MathShim.Asinh((double)x);
            UFix64M IMath<UFix64M>.Atan(UFix64M x) => (UFix64M)Math.Atan((double)x);
            UFix64M IMath<UFix64M>.Atan2(UFix64M x, UFix64M y) => (UFix64M)Math.Atan2((double)x, (double)y);
            UFix64M IMath<UFix64M>.Atanh(UFix64M x) => (UFix64M)MathShim.Atanh((double)x);
            UFix64M IMath<UFix64M>.Cbrt(UFix64M x) => (UFix64M)MathShim.Cbrt((double)x);
            UFix64M IMath<UFix64M>.Ceiling(UFix64M x) => new UFix64M(Scaled.Ceiling(x._scaledValue, ScalingFactor));
            UFix64M IMath<UFix64M>.Clamp(UFix64M x, UFix64M bound1, UFix64M bound2) => new UFix64M(bound1 > bound2 ? Math.Min(bound1._scaledValue, Math.Max(bound2._scaledValue, x._scaledValue)) : Math.Min(bound2._scaledValue, Math.Max(bound1._scaledValue, x._scaledValue)));
            UFix64M IMath<UFix64M>.Cos(UFix64M x) => (UFix64M)Math.Cos((double)x);
            UFix64M IMath<UFix64M>.Cosh(UFix64M x) => (UFix64M)Math.Cosh((double)x);
            UFix64M IMath<UFix64M>.E { get; } = (UFix64M)Math.E;
            UFix64M IMath<UFix64M>.Exp(UFix64M x) => (UFix64M)Math.Exp((double)x);
            UFix64M IMath<UFix64M>.Floor(UFix64M x) => new UFix64M(Scaled.Floor(x._scaledValue, ScalingFactor));
            UFix64M IMath<UFix64M>.IEEERemainder(UFix64M x, UFix64M y) => (UFix64M)Math.IEEERemainder((double)x, (double)y);
            UFix64M IMath<UFix64M>.Log(UFix64M x) => (UFix64M)Math.Log((double)x);
            UFix64M IMath<UFix64M>.Log(UFix64M x, UFix64M y) => (UFix64M)Math.Log((double)x, (double)y);
            UFix64M IMath<UFix64M>.Log10(UFix64M x) => (UFix64M)Math.Log10((double)x);
            UFix64M IMath<UFix64M>.Max(UFix64M x, UFix64M y) => new UFix64M(Math.Max(x._scaledValue, y._scaledValue));
            UFix64M IMath<UFix64M>.Min(UFix64M x, UFix64M y) => new UFix64M(Math.Min(x._scaledValue, y._scaledValue));
            UFix64M IMath<UFix64M>.PI { get; } = (UFix64M)Math.PI;
            UFix64M IMath<UFix64M>.Pow(UFix64M x, UFix64M y) => y == 1 ? x : (UFix64M)Math.Pow((double)x, (double)y);
            UFix64M IMath<UFix64M>.Round(UFix64M x) => Round(x, 0, MidpointRounding.ToEven);
            UFix64M IMath<UFix64M>.Round(UFix64M x, int digits) => Round(x, digits, MidpointRounding.ToEven);
            UFix64M IMath<UFix64M>.Round(UFix64M x, int digits, MidpointRounding mode) => Round(x, digits, mode);
            UFix64M IMath<UFix64M>.Round(UFix64M x, MidpointRounding mode) => Round(x, 0, mode);
            UFix64M IMath<UFix64M>.Sin(UFix64M x) => (UFix64M)Math.Sin((double)x);
            UFix64M IMath<UFix64M>.Sinh(UFix64M x) => (UFix64M)Math.Sinh((double)x);
            UFix64M IMath<UFix64M>.Sqrt(UFix64M x) => (UFix64M)Math.Sqrt((double)x);
            UFix64M IMath<UFix64M>.Tan(UFix64M x) => (UFix64M)Math.Tan((double)x);
            UFix64M IMath<UFix64M>.Tanh(UFix64M x) => (UFix64M)Math.Tanh((double)x);
            UFix64M IMath<UFix64M>.Tau { get; } = (UFix64M)(Math.PI * 2d);
            UFix64M IMath<UFix64M>.Truncate(UFix64M x) => new UFix64M(x._scaledValue / ScalingFactor * ScalingFactor);

            int INumericBitConverter<UFix64M>.ConvertedSize => sizeof(ulong);
            UFix64M INumericBitConverter<UFix64M>.ToNumeric(byte[] value, int startIndex) => new UFix64M(BitConverter.ToUInt64(value, startIndex));
            byte[] INumericBitConverter<UFix64M>.GetBytes(UFix64M value) => BitConverter.GetBytes(value._scaledValue);

            bool IConvert<UFix64M>.ToBoolean(UFix64M value) => value._scaledValue != 0;
            byte IConvert<UFix64M>.ToByte(UFix64M value, Conversion mode) => ConvertN.ToByte(value._scaledValue / ScalingFactor, mode.Clamped());
            decimal IConvert<UFix64M>.ToDecimal(UFix64M value, Conversion mode) => (decimal)value._scaledValue / ScalingFactor;
            double IConvert<UFix64M>.ToDouble(UFix64M value, Conversion mode) => Scaled.ToDouble(value._scaledValue, ScalingFactor);
            float IConvert<UFix64M>.ToSingle(UFix64M value, Conversion mode) => (float)value._scaledValue / ScalingFactor;
            int IConvert<UFix64M>.ToInt32(UFix64M value, Conversion mode) => ConvertN.ToInt32(value._scaledValue / ScalingFactor, mode.Clamped());
            long IConvert<UFix64M>.ToInt64(UFix64M value, Conversion mode) => ConvertN.ToInt64(value._scaledValue / ScalingFactor, mode.Clamped());
            sbyte IConvertExtended<UFix64M>.ToSByte(UFix64M value, Conversion mode) => ConvertN.ToSByte(value._scaledValue / ScalingFactor, mode.Clamped());
            short IConvert<UFix64M>.ToInt16(UFix64M value, Conversion mode) => ConvertN.ToInt16(value._scaledValue / ScalingFactor, mode.Clamped());
            string IConvert<UFix64M>.ToString(UFix64M value) => value.ToString();
            uint IConvertExtended<UFix64M>.ToUInt32(UFix64M value, Conversion mode) => ConvertN.ToUInt32(value._scaledValue / ScalingFactor, mode.Clamped());
            ulong IConvertExtended<UFix64M>.ToUInt64(UFix64M value, Conversion mode) => value._scaledValue / ScalingFactor;
            ushort IConvertExtended<UFix64M>.ToUInt16(UFix64M value, Conversion mode) => ConvertN.ToUInt16(value._scaledValue / ScalingFactor, mode.Clamped());

            UFix64M IConvert<UFix64M>.ToNumeric(bool value) => value ? new UFix64M(ScalingFactor) : new UFix64M(0);
            UFix64M IConvert<UFix64M>.ToNumeric(byte value, Conversion mode) => (UFix64M)ConvertN.ToUInt64(value, mode.Clamped());
            UFix64M IConvert<UFix64M>.ToNumeric(decimal value, Conversion mode) => (UFix64M)value;
            UFix64M IConvert<UFix64M>.ToNumeric(double value, Conversion mode) => (UFix64M)value;
            UFix64M IConvert<UFix64M>.ToNumeric(float value, Conversion mode) => (UFix64M)value;
            UFix64M IConvert<UFix64M>.ToNumeric(int value, Conversion mode) => (UFix64M)ConvertN.ToUInt64(value, mode.Clamped());
            UFix64M IConvert<UFix64M>.ToNumeric(long value, Conversion mode) => (UFix64M)value;
            UFix64M IConvertExtended<UFix64M>.ToValue(sbyte value, Conversion mode) => (UFix64M)ConvertN.ToUInt64(value, mode.Clamped());
            UFix64M IConvert<UFix64M>.ToNumeric(short value, Conversion mode) => (UFix64M)ConvertN.ToUInt64(value, mode.Clamped());
            UFix64M IConvert<UFix64M>.ToNumeric(string value) => (UFix64M)Convert.ToUInt64(value);
            UFix64M IConvertExtended<UFix64M>.ToNumeric(uint value, Conversion mode) => (UFix64M)ConvertN.ToUInt64(value, mode.Clamped());
            UFix64M IConvertExtended<UFix64M>.ToNumeric(ulong value, Conversion mode) => (UFix64M)value;
            UFix64M IConvertExtended<UFix64M>.ToNumeric(ushort value, Conversion mode) => (UFix64M)ConvertN.ToUInt64(value, mode.Clamped());

            UFix64M INumericStatic<UFix64M>.Parse(string s, NumberStyles? style, IFormatProvider? provider)
                => Parse(s, style ?? NumberStyles.Number, provider);

            UFix64M INumericRandom<UFix64M>.Generate(Random random) => new UFix64M(random.NextUInt64(ScalingFactor));
            UFix64M INumericRandom<UFix64M>.Generate(Random random, UFix64M maxValue) => new UFix64M(random.NextUInt64(maxValue._scaledValue));
            UFix64M INumericRandom<UFix64M>.Generate(Random random, UFix64M minValue, UFix64M maxValue) => new UFix64M(random.NextUInt64(minValue._scaledValue, maxValue._scaledValue));
            UFix64M INumericRandom<UFix64M>.Generate(Random random, Generation mode) => new UFix64M(random.NextUInt64(0, mode == Generation.Extended ? ulong.MaxValue : ScalingFactor, mode));
            UFix64M INumericRandom<UFix64M>.Generate(Random random, UFix64M minValue, UFix64M maxValue, Generation mode) => new UFix64M(random.NextUInt64(minValue._scaledValue, maxValue._scaledValue, mode));

            UFix64M IVariantRandom<UFix64M>.Generate(Random random, Variants scenarios) => NumericVariant.Generate<UFix64M>(random, scenarios);
        }
    }
}
