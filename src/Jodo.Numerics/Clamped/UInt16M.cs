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
    /// Represents a 16-bit unsigned integer that cannot overflow.
    /// </summary>
    [Serializable]
    [DebuggerDisplay("{ToString(),nq}")]
    public readonly struct UInt16M : INumericExtended<UInt16M>
    {
        public static readonly UInt16M MaxValue = new UInt16M(ushort.MaxValue);
        public static readonly UInt16M MinValue = new UInt16M(ushort.MinValue);

        private readonly ushort _value;

        private UInt16M(ushort value)
        {
            _value = value;
        }

        private UInt16M(SerializationInfo info, StreamingContext context) : this(info.GetUInt16(nameof(UInt16M))) { }
        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context) => info.AddValue(nameof(UInt16M), _value);

        public int CompareTo(object? obj) => obj is UInt16M other ? CompareTo(other) : 1;
        public int CompareTo(UInt16M other) => _value.CompareTo(other._value);
        public bool Equals(UInt16M other) => _value == other._value;
        public override bool Equals(object? obj) => obj is UInt16M other && Equals(other);
        public override int GetHashCode() => _value.GetHashCode();
        public override string ToString() => _value.ToString();
        public string ToString(IFormatProvider formatProvider) => _value.ToString(formatProvider);
        public string ToString(string format) => _value.ToString(format);
        public string ToString(string? format, IFormatProvider? formatProvider) => _value.ToString(format, formatProvider);

        public static bool TryParse(string s, IFormatProvider? provider, out UInt16M result) => FuncExtensions.Try(() => Parse(s, provider), out result);
        public static bool TryParse(string s, NumberStyles style, IFormatProvider? provider, out UInt16M result) => FuncExtensions.Try(() => Parse(s, style, provider), out result);
        public static bool TryParse(string s, NumberStyles style, out UInt16M result) => FuncExtensions.Try(() => Parse(s, style), out result);
        public static bool TryParse(string s, out UInt16M result) => FuncExtensions.Try(() => Parse(s), out result);
        public static UInt16M Parse(string s) => ushort.Parse(s);
        public static UInt16M Parse(string s, IFormatProvider? provider) => ushort.Parse(s, provider);
        public static UInt16M Parse(string s, NumberStyles style) => ushort.Parse(s, style);
        public static UInt16M Parse(string s, NumberStyles style, IFormatProvider? provider) => ushort.Parse(s, style, provider);

        [CLSCompliant(false)] public static explicit operator UInt16M(sbyte value) => new UInt16M(ConvertN.ToUInt16(value, Conversion.CastClamp));
        [CLSCompliant(false)] public static explicit operator UInt16M(uint value) => new UInt16M(ConvertN.ToUInt16(value, Conversion.CastClamp));
        [CLSCompliant(false)] public static explicit operator UInt16M(ulong value) => new UInt16M(ConvertN.ToUInt16(value, Conversion.CastClamp));
        [CLSCompliant(false)] public static implicit operator UInt16M(ushort value) => new UInt16M(value);
        public static explicit operator UInt16M(decimal value) => new UInt16M(ConvertN.ToUInt16(value, Conversion.CastClamp));
        public static explicit operator UInt16M(double value) => new UInt16M(ConvertN.ToUInt16(value, Conversion.CastClamp));
        public static explicit operator UInt16M(float value) => new UInt16M(ConvertN.ToUInt16(value, Conversion.CastClamp));
        public static explicit operator UInt16M(int value) => new UInt16M(ConvertN.ToUInt16(value, Conversion.CastClamp));
        public static explicit operator UInt16M(long value) => new UInt16M(ConvertN.ToUInt16(value, Conversion.CastClamp));
        public static explicit operator UInt16M(short value) => new UInt16M(ConvertN.ToUInt16(value, Conversion.CastClamp));
        public static implicit operator UInt16M(byte value) => new UInt16M(value);

        [CLSCompliant(false)] public static explicit operator sbyte(UInt16M value) => ConvertN.ToSByte(value._value, Conversion.CastClamp);
        [CLSCompliant(false)] public static implicit operator uint(UInt16M value) => value._value;
        [CLSCompliant(false)] public static implicit operator ulong(UInt16M value) => value._value;
        [CLSCompliant(false)] public static implicit operator ushort(UInt16M value) => value._value;
        public static explicit operator byte(UInt16M value) => ConvertN.ToByte(value._value, Conversion.CastClamp);
        public static explicit operator int(UInt16M value) => ConvertN.ToInt32(value._value, Conversion.CastClamp);
        public static explicit operator short(UInt16M value) => ConvertN.ToInt16(value._value, Conversion.CastClamp);
        public static implicit operator decimal(UInt16M value) => value._value;
        public static implicit operator double(UInt16M value) => value._value;
        public static implicit operator float(UInt16M value) => value._value;
        public static implicit operator long(UInt16M value) => value._value;

        public static bool operator !=(UInt16M left, UInt16M right) => left._value != right._value;
        public static bool operator <(UInt16M left, UInt16M right) => left._value < right._value;
        public static bool operator <=(UInt16M left, UInt16M right) => left._value <= right._value;
        public static bool operator ==(UInt16M left, UInt16M right) => left._value == right._value;
        public static bool operator >(UInt16M left, UInt16M right) => left._value > right._value;
        public static bool operator >=(UInt16M left, UInt16M right) => left._value >= right._value;
        public static UInt16M operator %(UInt16M left, UInt16M right) => ClampedMath.Remainder(left._value, right._value);
        public static UInt16M operator &(UInt16M left, UInt16M right) => (ushort)(left._value & right._value);
        public static UInt16M operator -(UInt16M _) => MinValue;
        public static UInt16M operator -(UInt16M left, UInt16M right) => ClampedMath.Subtract(left._value, right._value);
        public static UInt16M operator --(UInt16M value) => value - 1;
        public static UInt16M operator *(UInt16M left, UInt16M right) => ClampedMath.Multiply(left._value, right._value);
        public static UInt16M operator /(UInt16M left, UInt16M right) => ClampedMath.Divide(left._value, right._value);
        public static UInt16M operator ^(UInt16M left, UInt16M right) => (ushort)(left._value ^ right._value);
        public static UInt16M operator |(UInt16M left, UInt16M right) => (ushort)(left._value | right._value);
        public static UInt16M operator ~(UInt16M value) => (ushort)~value._value;
        public static UInt16M operator +(UInt16M left, UInt16M right) => ClampedMath.Add(left._value, right._value);
        public static UInt16M operator +(UInt16M value) => value;
        public static UInt16M operator ++(UInt16M value) => value + 1;
        public static UInt16M operator <<(UInt16M left, int right) => (ushort)(left._value << right);
        public static UInt16M operator >>(UInt16M left, int right) => (ushort)(left._value >> right);

        TypeCode IConvertible.GetTypeCode() => _value.GetTypeCode();
        bool IConvertible.ToBoolean(IFormatProvider provider) => Convert.ToBoolean(_value, provider);
        byte IConvertible.ToByte(IFormatProvider provider) => ConvertN.ToByte(_value, Conversion.Clamp);
        char IConvertible.ToChar(IFormatProvider provider) => Convert.ToChar(_value, provider);
        DateTime IConvertible.ToDateTime(IFormatProvider provider) => Convert.ToDateTime(provider);
        decimal IConvertible.ToDecimal(IFormatProvider provider) => ConvertN.ToDecimal(_value, Conversion.Clamp);
        double IConvertible.ToDouble(IFormatProvider provider) => ConvertN.ToDouble(_value, Conversion.Clamp);
        float IConvertible.ToSingle(IFormatProvider provider) => ConvertN.ToSingle(_value, Conversion.Clamp);
        int IConvertible.ToInt32(IFormatProvider provider) => ConvertN.ToInt32(_value, Conversion.Clamp);
        long IConvertible.ToInt64(IFormatProvider provider) => ConvertN.ToInt64(_value, Conversion.Clamp);
        sbyte IConvertible.ToSByte(IFormatProvider provider) => ConvertN.ToSByte(_value, Conversion.Clamp);
        short IConvertible.ToInt16(IFormatProvider provider) => ConvertN.ToInt16(_value, Conversion.Clamp);
        uint IConvertible.ToUInt32(IFormatProvider provider) => ConvertN.ToUInt32(_value, Conversion.Clamp);
        ulong IConvertible.ToUInt64(IFormatProvider provider) => ConvertN.ToUInt64(_value, Conversion.Clamp);
        ushort IConvertible.ToUInt16(IFormatProvider provider) => _value;
        object IConvertible.ToType(Type conversionType, IFormatProvider provider) => this.ToTypeDefault(conversionType, provider);

        bool INumeric<UInt16M>.IsGreaterThan(UInt16M value) => this > value;
        bool INumeric<UInt16M>.IsGreaterThanOrEqualTo(UInt16M value) => this >= value;
        bool INumeric<UInt16M>.IsLessThan(UInt16M value) => this < value;
        bool INumeric<UInt16M>.IsLessThanOrEqualTo(UInt16M value) => this <= value;
        UInt16M INumeric<UInt16M>.Add(UInt16M value) => this + value;
        UInt16M INumeric<UInt16M>.BitwiseComplement() => ~this;
        UInt16M INumeric<UInt16M>.Divide(UInt16M value) => this / value;
        UInt16M INumeric<UInt16M>.LeftShift(int count) => this << count;
        UInt16M INumeric<UInt16M>.LogicalAnd(UInt16M value) => this & value;
        UInt16M INumeric<UInt16M>.LogicalExclusiveOr(UInt16M value) => this ^ value;
        UInt16M INumeric<UInt16M>.LogicalOr(UInt16M value) => this | value;
        UInt16M INumeric<UInt16M>.Multiply(UInt16M value) => this * value;
        UInt16M INumeric<UInt16M>.Negative() => -this;
        UInt16M INumeric<UInt16M>.Positive() => +this;
        UInt16M INumeric<UInt16M>.Remainder(UInt16M value) => this % value;
        UInt16M INumeric<UInt16M>.RightShift(int count) => this >> count;
        UInt16M INumeric<UInt16M>.Subtract(UInt16M value) => this - value;

        INumericBitConverter<UInt16M> IProvider<INumericBitConverter<UInt16M>>.GetInstance() => Utilities.Instance;
        IConvert<UInt16M> IProvider<IConvert<UInt16M>>.GetInstance() => Utilities.Instance;
        IConvertExtended<UInt16M> IProvider<IConvertExtended<UInt16M>>.GetInstance() => Utilities.Instance;
        IMath<UInt16M> IProvider<IMath<UInt16M>>.GetInstance() => Utilities.Instance;
        INumericRandom<UInt16M> IProvider<INumericRandom<UInt16M>>.GetInstance() => Utilities.Instance;
        INumericStatic<UInt16M> IProvider<INumericStatic<UInt16M>>.GetInstance() => Utilities.Instance;
        IVariantRandom<UInt16M> IProvider<IVariantRandom<UInt16M>>.GetInstance() => Utilities.Instance;

        private sealed class Utilities :
            IConvert<UInt16M>,
            IConvertExtended<UInt16M>,
            IMath<UInt16M>,
            INumericBitConverter<UInt16M>,
            INumericRandom<UInt16M>,
            INumericStatic<UInt16M>,
            IVariantRandom<UInt16M>
        {
            public static readonly Utilities Instance = new Utilities();

            bool INumericStatic<UInt16M>.HasFloatingPoint => false;
            bool INumericStatic<UInt16M>.HasInfinity => false;
            bool INumericStatic<UInt16M>.HasNaN => false;
            bool INumericStatic<UInt16M>.IsFinite(UInt16M x) => true;
            bool INumericStatic<UInt16M>.IsInfinity(UInt16M x) => false;
            bool INumericStatic<UInt16M>.IsNaN(UInt16M x) => false;
            bool INumericStatic<UInt16M>.IsNegative(UInt16M x) => false;
            bool INumericStatic<UInt16M>.IsNegativeInfinity(UInt16M x) => false;
            bool INumericStatic<UInt16M>.IsNormal(UInt16M x) => false;
            bool INumericStatic<UInt16M>.IsPositiveInfinity(UInt16M x) => false;
            bool INumericStatic<UInt16M>.IsReal => false;
            bool INumericStatic<UInt16M>.IsSigned => false;
            bool INumericStatic<UInt16M>.IsSubnormal(UInt16M x) => false;
            UInt16M INumericStatic<UInt16M>.Epsilon => 1;
            UInt16M INumericStatic<UInt16M>.MaxUnit => 1;
            UInt16M INumericStatic<UInt16M>.MaxValue => MaxValue;
            UInt16M INumericStatic<UInt16M>.MinUnit => 0;
            UInt16M INumericStatic<UInt16M>.MinValue => MinValue;
            UInt16M INumericStatic<UInt16M>.One => 1;
            UInt16M INumericStatic<UInt16M>.Ten => 10;
            UInt16M INumericStatic<UInt16M>.Two => 2;
            UInt16M INumericStatic<UInt16M>.Zero => 0;

            int IMath<UInt16M>.Sign(UInt16M x) => x._value == 0 ? 0 : 1;
            UInt16M IMath<UInt16M>.Abs(UInt16M value) => value;
            UInt16M IMath<UInt16M>.Acos(UInt16M x) => (UInt16M)Math.Acos(x._value);
            UInt16M IMath<UInt16M>.Acosh(UInt16M x) => (UInt16M)MathShim.Acosh(x._value);
            UInt16M IMath<UInt16M>.Asin(UInt16M x) => (UInt16M)Math.Asin(x._value);
            UInt16M IMath<UInt16M>.Asinh(UInt16M x) => (UInt16M)MathShim.Asinh(x._value);
            UInt16M IMath<UInt16M>.Atan(UInt16M x) => (UInt16M)Math.Atan(x._value);
            UInt16M IMath<UInt16M>.Atan2(UInt16M x, UInt16M y) => (UInt16M)Math.Atan2(x._value, y._value);
            UInt16M IMath<UInt16M>.Atanh(UInt16M x) => (UInt16M)MathShim.Atanh(x._value);
            UInt16M IMath<UInt16M>.Cbrt(UInt16M x) => (UInt16M)MathShim.Cbrt(x._value);
            UInt16M IMath<UInt16M>.Ceiling(UInt16M x) => x;
            UInt16M IMath<UInt16M>.Clamp(UInt16M x, UInt16M bound1, UInt16M bound2) => bound1 > bound2 ? Math.Min(bound1._value, Math.Max(bound2._value, x._value)) : Math.Min(bound2._value, Math.Max(bound1._value, x._value));
            UInt16M IMath<UInt16M>.Cos(UInt16M x) => (UInt16M)Math.Cos(x._value);
            UInt16M IMath<UInt16M>.Cosh(UInt16M x) => (UInt16M)Math.Cosh(x._value);
            UInt16M IMath<UInt16M>.E { get; } = 2;
            UInt16M IMath<UInt16M>.Exp(UInt16M x) => (UInt16M)Math.Exp(x._value);
            UInt16M IMath<UInt16M>.Floor(UInt16M x) => x;
            UInt16M IMath<UInt16M>.IEEERemainder(UInt16M x, UInt16M y) => (UInt16M)Math.IEEERemainder(x._value, y._value);
            UInt16M IMath<UInt16M>.Log(UInt16M x) => (UInt16M)Math.Log(x._value);
            UInt16M IMath<UInt16M>.Log(UInt16M x, UInt16M y) => (UInt16M)Math.Log(x._value, y._value);
            UInt16M IMath<UInt16M>.Log10(UInt16M x) => (UInt16M)Math.Log10(x._value);
            UInt16M IMath<UInt16M>.Max(UInt16M x, UInt16M y) => Math.Max(x._value, y._value);
            UInt16M IMath<UInt16M>.Min(UInt16M x, UInt16M y) => Math.Min(x._value, y._value);
            UInt16M IMath<UInt16M>.PI { get; } = 3;
            UInt16M IMath<UInt16M>.Pow(UInt16M x, UInt16M y) => ClampedMath.Pow(x._value, y._value);
            UInt16M IMath<UInt16M>.Round(UInt16M x) => x;
            UInt16M IMath<UInt16M>.Round(UInt16M x, int digits) => x;
            UInt16M IMath<UInt16M>.Round(UInt16M x, int digits, MidpointRounding mode) => x;
            UInt16M IMath<UInt16M>.Round(UInt16M x, MidpointRounding mode) => x;
            UInt16M IMath<UInt16M>.Sin(UInt16M x) => (UInt16M)Math.Sin(x._value);
            UInt16M IMath<UInt16M>.Sinh(UInt16M x) => (UInt16M)Math.Sinh(x._value);
            UInt16M IMath<UInt16M>.Sqrt(UInt16M x) => (UInt16M)Math.Sqrt(x._value);
            UInt16M IMath<UInt16M>.Tan(UInt16M x) => (UInt16M)Math.Tan(x._value);
            UInt16M IMath<UInt16M>.Tanh(UInt16M x) => (UInt16M)Math.Tanh(x._value);
            UInt16M IMath<UInt16M>.Tau { get; } = 6;
            UInt16M IMath<UInt16M>.Truncate(UInt16M x) => x;

            int INumericBitConverter<UInt16M>.ConvertedSize => sizeof(ushort);
            UInt16M INumericBitConverter<UInt16M>.ToNumeric(byte[] value, int startIndex) => BitConverter.ToUInt16(value, startIndex);
            byte[] INumericBitConverter<UInt16M>.GetBytes(UInt16M value) => BitConverter.GetBytes(value._value);

            bool IConvert<UInt16M>.ToBoolean(UInt16M value) => value._value != 0;
            byte IConvert<UInt16M>.ToByte(UInt16M value, Conversion mode) => ConvertN.ToByte(value._value, mode.Clamped());
            decimal IConvert<UInt16M>.ToDecimal(UInt16M value, Conversion mode) => ConvertN.ToDecimal(value._value, mode.Clamped());
            double IConvert<UInt16M>.ToDouble(UInt16M value, Conversion mode) => ConvertN.ToDouble(value._value, mode.Clamped());
            float IConvert<UInt16M>.ToSingle(UInt16M value, Conversion mode) => ConvertN.ToSingle(value._value, mode.Clamped());
            int IConvert<UInt16M>.ToInt32(UInt16M value, Conversion mode) => ConvertN.ToInt32(value._value, mode.Clamped());
            long IConvert<UInt16M>.ToInt64(UInt16M value, Conversion mode) => ConvertN.ToInt64(value._value, mode.Clamped());
            sbyte IConvertExtended<UInt16M>.ToSByte(UInt16M value, Conversion mode) => ConvertN.ToSByte(value._value, mode.Clamped());
            short IConvert<UInt16M>.ToInt16(UInt16M value, Conversion mode) => ConvertN.ToInt16(value._value, mode.Clamped());
            string IConvert<UInt16M>.ToString(UInt16M value) => Convert.ToString(value._value);
            uint IConvertExtended<UInt16M>.ToUInt32(UInt16M value, Conversion mode) => value._value;
            ulong IConvertExtended<UInt16M>.ToUInt64(UInt16M value, Conversion mode) => ConvertN.ToUInt64(value._value, mode.Clamped());
            ushort IConvertExtended<UInt16M>.ToUInt16(UInt16M value, Conversion mode) => ConvertN.ToUInt16(value._value, mode.Clamped());

            UInt16M IConvert<UInt16M>.ToNumeric(bool value) => value ? (ushort)1 : (ushort)0;
            UInt16M IConvert<UInt16M>.ToNumeric(byte value, Conversion mode) => ConvertN.ToUInt16(value, mode.Clamped());
            UInt16M IConvert<UInt16M>.ToNumeric(decimal value, Conversion mode) => ConvertN.ToUInt16(value, mode.Clamped());
            UInt16M IConvert<UInt16M>.ToNumeric(double value, Conversion mode) => ConvertN.ToUInt16(value, mode.Clamped());
            UInt16M IConvert<UInt16M>.ToNumeric(float value, Conversion mode) => ConvertN.ToUInt16(value, mode.Clamped());
            UInt16M IConvert<UInt16M>.ToNumeric(int value, Conversion mode) => ConvertN.ToUInt16(value, mode.Clamped());
            UInt16M IConvert<UInt16M>.ToNumeric(long value, Conversion mode) => ConvertN.ToUInt16(value, mode.Clamped());
            UInt16M IConvertExtended<UInt16M>.ToValue(sbyte value, Conversion mode) => ConvertN.ToUInt16(value, mode.Clamped());
            UInt16M IConvert<UInt16M>.ToNumeric(short value, Conversion mode) => ConvertN.ToUInt16(value, mode.Clamped());
            UInt16M IConvert<UInt16M>.ToNumeric(string value) => Convert.ToUInt16(value);
            UInt16M IConvertExtended<UInt16M>.ToNumeric(uint value, Conversion mode) => ConvertN.ToUInt16(value, mode.Clamped());
            UInt16M IConvertExtended<UInt16M>.ToNumeric(ulong value, Conversion mode) => ConvertN.ToUInt16(value, mode.Clamped());
            UInt16M IConvertExtended<UInt16M>.ToNumeric(ushort value, Conversion mode) => value;

            UInt16M INumericStatic<UInt16M>.Parse(string s, NumberStyles? style, IFormatProvider? provider)
                => Parse(s, style ?? NumberStyles.Integer, provider);

            UInt16M INumericRandom<UInt16M>.Generate(Random random) => random.NextUInt16();
            UInt16M INumericRandom<UInt16M>.Generate(Random random, UInt16M maxValue) => random.NextUInt16(maxValue);
            UInt16M INumericRandom<UInt16M>.Generate(Random random, UInt16M minValue, UInt16M maxValue) => random.NextUInt16(minValue, maxValue);
            UInt16M INumericRandom<UInt16M>.Generate(Random random, Generation mode) => random.NextUInt16(mode);
            UInt16M INumericRandom<UInt16M>.Generate(Random random, UInt16M minValue, UInt16M maxValue, Generation mode) => random.NextUInt16(minValue, maxValue, mode);

            UInt16M IVariantRandom<UInt16M>.Generate(Random random, Variants scenarios) => NumericVariant.Generate<UInt16M>(random, scenarios);
        }
    }
}
