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
using Jodo.Numerics.Internals;
using Jodo.Primitives;
using Jodo.Primitives.Compatibility;

namespace Jodo.Numerics.Clamped
{
    /// <summary>
    /// Represents a 64-bit signed integer that cannot overflow.
    /// </summary>
    [Serializable]
    [DebuggerDisplay("{ToString(),nq}")]
    public readonly struct Int16M : INumericExtended<Int16M>
    {
        public static readonly Int16M MaxValue = new Int16M(short.MaxValue);
        public static readonly Int16M MinValue = new Int16M(short.MinValue);

        private readonly short _value;

        private Int16M(short value)
        {
            _value = value;
        }

        private Int16M(SerializationInfo info, StreamingContext context) : this(info.GetInt16(nameof(Int16M))) { }
        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context) => info.AddValue(nameof(Int16M), _value);

        public int CompareTo(Int16M other) => _value.CompareTo(other._value);
        public int CompareTo(object? obj) => obj is Int16M other ? CompareTo(other) : 1;
        public bool Equals(Int16M other) => _value == other._value;
        public override bool Equals(object? obj) => obj is Int16M other && Equals(other);
        public override int GetHashCode() => _value.GetHashCode();
        public override string ToString() => _value.ToString();
        public string ToString(IFormatProvider formatProvider) => _value.ToString(formatProvider);
        public string ToString(string format) => _value.ToString(format);
        public string ToString(string? format, IFormatProvider? formatProvider) => _value.ToString(format, formatProvider);

        public static bool TryParse(string s, IFormatProvider? provider, out Int16M result) => FuncExtensions.Try(() => Parse(s, provider), out result);
        public static bool TryParse(string s, NumberStyles style, IFormatProvider? provider, out Int16M result) => FuncExtensions.Try(() => Parse(s, style, provider), out result);
        public static bool TryParse(string s, NumberStyles style, out Int16M result) => FuncExtensions.Try(() => Parse(s, style), out result);
        public static bool TryParse(string s, out Int16M result) => FuncExtensions.Try(() => Parse(s), out result);
        public static Int16M Parse(string s) => short.Parse(s);
        public static Int16M Parse(string s, IFormatProvider? provider) => short.Parse(s, provider);
        public static Int16M Parse(string s, NumberStyles style) => short.Parse(s, style);
        public static Int16M Parse(string s, NumberStyles style, IFormatProvider? provider) => short.Parse(s, style, provider);

        [CLSCompliant(false)] public static explicit operator Int16M(uint value) => new Int16M(ConvertN.ToInt16(value, Conversion.CastClamp));
        [CLSCompliant(false)] public static explicit operator Int16M(ulong value) => new Int16M(ConvertN.ToInt16(value, Conversion.CastClamp));
        [CLSCompliant(false)] public static explicit operator Int16M(ushort value) => new Int16M(ConvertN.ToInt16(value, Conversion.CastClamp));
        [CLSCompliant(false)] public static implicit operator Int16M(sbyte value) => new Int16M(value);
        public static explicit operator Int16M(decimal value) => new Int16M(ConvertN.ToInt16(value, Conversion.CastClamp));
        public static explicit operator Int16M(double value) => new Int16M(ConvertN.ToInt16(value, Conversion.CastClamp));
        public static explicit operator Int16M(float value) => new Int16M(ConvertN.ToInt16(value, Conversion.CastClamp));
        public static explicit operator Int16M(int value) => new Int16M(ConvertN.ToInt16(value, Conversion.CastClamp));
        public static explicit operator Int16M(long value) => new Int16M(ConvertN.ToInt16(value, Conversion.CastClamp));
        public static implicit operator Int16M(byte value) => new Int16M(value);
        public static implicit operator Int16M(short value) => new Int16M(value);

        [CLSCompliant(false)] public static explicit operator sbyte(Int16M value) => ConvertN.ToSByte(value._value, Conversion.CastClamp);
        [CLSCompliant(false)] public static explicit operator uint(Int16M value) => ConvertN.ToUInt16(value._value, Conversion.CastClamp);
        [CLSCompliant(false)] public static explicit operator ulong(Int16M value) => ConvertN.ToUInt64(value._value, Conversion.CastClamp);
        [CLSCompliant(false)] public static explicit operator ushort(Int16M value) => ConvertN.ToUInt16(value._value, Conversion.CastClamp);
        public static explicit operator byte(Int16M value) => ConvertN.ToByte(value._value, Conversion.CastClamp);
        public static implicit operator decimal(Int16M value) => value._value;
        public static implicit operator double(Int16M value) => value._value;
        public static implicit operator float(Int16M value) => value._value;
        public static implicit operator int(Int16M value) => value._value;
        public static implicit operator long(Int16M value) => value._value;
        public static implicit operator short(Int16M value) => value._value;

        public static bool operator !=(Int16M left, Int16M right) => left._value != right._value;
        public static bool operator <(Int16M left, Int16M right) => left._value < right._value;
        public static bool operator <=(Int16M left, Int16M right) => left._value <= right._value;
        public static bool operator ==(Int16M left, Int16M right) => left._value == right._value;
        public static bool operator >(Int16M left, Int16M right) => left._value > right._value;
        public static bool operator >=(Int16M left, Int16M right) => left._value >= right._value;
        public static Int16M operator %(Int16M left, Int16M right) => Clamped.Remainder(left._value, right._value);
        public static Int16M operator &(Int16M left, Int16M right) => (short)(left._value & right._value);
        public static Int16M operator -(Int16M left, Int16M right) => Clamped.Subtract(left._value, right._value);
        public static Int16M operator --(Int16M value) => Clamped.Subtract(value._value, (short)1);
        public static Int16M operator -(Int16M value) => (short)-value._value;
        public static Int16M operator *(Int16M left, Int16M right) => Clamped.Multiply(left._value, right._value);
        public static Int16M operator /(Int16M left, Int16M right) => Clamped.Divide(left._value, right._value);
        public static Int16M operator ^(Int16M left, Int16M right) => (short)(left._value ^ right._value);
        public static Int16M operator |(Int16M left, Int16M right) => (short)(left._value | right._value);
        public static Int16M operator ~(Int16M value) => (short)~value._value;
        public static Int16M operator +(Int16M left, Int16M right) => Clamped.Add(left._value, right._value);
        public static Int16M operator +(Int16M value) => value;
        public static Int16M operator ++(Int16M value) => Clamped.Add(value._value, (short)1);
        public static Int16M operator <<(Int16M left, int right) => (short)(left._value << right);
        public static Int16M operator >>(Int16M left, int right) => (short)(left._value >> right);

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
        short IConvertible.ToInt16(IFormatProvider provider) => _value;
        uint IConvertible.ToUInt32(IFormatProvider provider) => ConvertN.ToUInt32(_value, Conversion.Clamp);
        ulong IConvertible.ToUInt64(IFormatProvider provider) => ConvertN.ToUInt64(_value, Conversion.Clamp);
        ushort IConvertible.ToUInt16(IFormatProvider provider) => ConvertN.ToUInt16(_value, Conversion.Clamp);
        object IConvertible.ToType(Type conversionType, IFormatProvider provider) => this.ToTypeDefault(conversionType, provider);

        bool INumeric<Int16M>.IsGreaterThan(Int16M value) => this > value;
        bool INumeric<Int16M>.IsGreaterThanOrEqualTo(Int16M value) => this >= value;
        bool INumeric<Int16M>.IsLessThan(Int16M value) => this < value;
        bool INumeric<Int16M>.IsLessThanOrEqualTo(Int16M value) => this <= value;
        Int16M INumeric<Int16M>.Add(Int16M value) => this + value;
        Int16M INumeric<Int16M>.BitwiseComplement() => ~this;
        Int16M INumeric<Int16M>.Divide(Int16M value) => this / value;
        Int16M INumeric<Int16M>.LeftShift(int count) => this << count;
        Int16M INumeric<Int16M>.LogicalAnd(Int16M value) => this & value;
        Int16M INumeric<Int16M>.LogicalExclusiveOr(Int16M value) => this ^ value;
        Int16M INumeric<Int16M>.LogicalOr(Int16M value) => this | value;
        Int16M INumeric<Int16M>.Multiply(Int16M value) => this * value;
        Int16M INumeric<Int16M>.Negative() => -this;
        Int16M INumeric<Int16M>.Positive() => +this;
        Int16M INumeric<Int16M>.Remainder(Int16M value) => this % value;
        Int16M INumeric<Int16M>.RightShift(int count) => this >> count;
        Int16M INumeric<Int16M>.Subtract(Int16M value) => this - value;

        INumericBitConverter<Int16M> IProvider<INumericBitConverter<Int16M>>.GetInstance() => Utilities.Instance;
        IConvert<Int16M> IProvider<IConvert<Int16M>>.GetInstance() => Utilities.Instance;
        IConvertExtended<Int16M> IProvider<IConvertExtended<Int16M>>.GetInstance() => Utilities.Instance;
        IMath<Int16M> IProvider<IMath<Int16M>>.GetInstance() => Utilities.Instance;
        INumericRandom<Int16M> IProvider<INumericRandom<Int16M>>.GetInstance() => Utilities.Instance;
        INumericStatic<Int16M> IProvider<INumericStatic<Int16M>>.GetInstance() => Utilities.Instance;
        IVariantRandom<Int16M> IProvider<IVariantRandom<Int16M>>.GetInstance() => Utilities.Instance;

        private sealed class Utilities :
            IConvert<Int16M>,
            IConvertExtended<Int16M>,
            IMath<Int16M>,
            INumericBitConverter<Int16M>,
            INumericRandom<Int16M>,
            INumericStatic<Int16M>,
            IVariantRandom<Int16M>
        {
            public static readonly Utilities Instance = new Utilities();

            bool INumericStatic<Int16M>.HasFloatingPoint => false;
            bool INumericStatic<Int16M>.HasInfinity => false;
            bool INumericStatic<Int16M>.HasNaN => false;
            bool INumericStatic<Int16M>.IsFinite(Int16M x) => true;
            bool INumericStatic<Int16M>.IsInfinity(Int16M x) => false;
            bool INumericStatic<Int16M>.IsNaN(Int16M x) => false;
            bool INumericStatic<Int16M>.IsNegative(Int16M x) => x._value < 0;
            bool INumericStatic<Int16M>.IsNegativeInfinity(Int16M x) => false;
            bool INumericStatic<Int16M>.IsNormal(Int16M x) => false;
            bool INumericStatic<Int16M>.IsPositiveInfinity(Int16M x) => false;
            bool INumericStatic<Int16M>.IsReal => false;
            bool INumericStatic<Int16M>.IsSigned => true;
            bool INumericStatic<Int16M>.IsSubnormal(Int16M x) => false;
            Int16M INumericStatic<Int16M>.Epsilon => (short)1;
            Int16M INumericStatic<Int16M>.MaxUnit => (short)1;
            Int16M INumericStatic<Int16M>.MaxValue => MaxValue;
            Int16M INumericStatic<Int16M>.MinUnit => (short)-1;
            Int16M INumericStatic<Int16M>.MinValue => MinValue;
            Int16M INumericStatic<Int16M>.One => (short)1;
            Int16M INumericStatic<Int16M>.Ten => (short)10;
            Int16M INumericStatic<Int16M>.Two => (short)2;
            Int16M INumericStatic<Int16M>.Zero => (short)0;

            Int16M IMath<Int16M>.Abs(Int16M value) => Math.Abs(value._value);
            Int16M IMath<Int16M>.Acos(Int16M x) => (Int16M)Math.Acos(x._value);
            Int16M IMath<Int16M>.Acosh(Int16M x) => (Int16M)MathShim.Acosh(x._value);
            Int16M IMath<Int16M>.Asin(Int16M x) => (Int16M)Math.Asin(x._value);
            Int16M IMath<Int16M>.Asinh(Int16M x) => (Int16M)MathShim.Asinh(x._value);
            Int16M IMath<Int16M>.Atan(Int16M x) => (Int16M)Math.Atan(x._value);
            Int16M IMath<Int16M>.Atan2(Int16M x, Int16M y) => (Int16M)Math.Atan2(x._value, y._value);
            Int16M IMath<Int16M>.Atanh(Int16M x) => (Int16M)MathShim.Atanh(x._value);
            Int16M IMath<Int16M>.Cbrt(Int16M x) => (Int16M)MathShim.Cbrt(x._value);
            Int16M IMath<Int16M>.Ceiling(Int16M x) => x;
            Int16M IMath<Int16M>.Clamp(Int16M x, Int16M bound1, Int16M bound2) => bound1 > bound2 ? Math.Min(bound1._value, Math.Max(bound2._value, x._value)) : Math.Min(bound2._value, Math.Max(bound1._value, x._value));
            Int16M IMath<Int16M>.Cos(Int16M x) => (Int16M)Math.Cos(x._value);
            Int16M IMath<Int16M>.Cosh(Int16M x) => (Int16M)Math.Cosh(x._value);
            Int16M IMath<Int16M>.E { get; } = (short)2;
            Int16M IMath<Int16M>.Exp(Int16M x) => (Int16M)Math.Exp(x._value);
            Int16M IMath<Int16M>.Floor(Int16M x) => x;
            Int16M IMath<Int16M>.IEEERemainder(Int16M x, Int16M y) => (Int16M)Math.IEEERemainder(x._value, y._value);
            Int16M IMath<Int16M>.Log(Int16M x) => (Int16M)Math.Log(x._value);
            Int16M IMath<Int16M>.Log(Int16M x, Int16M y) => (Int16M)Math.Log(x._value, y._value);
            Int16M IMath<Int16M>.Log10(Int16M x) => (Int16M)Math.Log10(x._value);
            Int16M IMath<Int16M>.Max(Int16M x, Int16M y) => Math.Max(x._value, y._value);
            Int16M IMath<Int16M>.Min(Int16M x, Int16M y) => Math.Min(x._value, y._value);
            Int16M IMath<Int16M>.PI { get; } = (short)3;
            Int16M IMath<Int16M>.Pow(Int16M x, Int16M y) => Clamped.Pow(x._value, y._value);
            Int16M IMath<Int16M>.Round(Int16M x) => x;
            Int16M IMath<Int16M>.Round(Int16M x, int digits) => x;
            Int16M IMath<Int16M>.Round(Int16M x, int digits, MidpointRounding mode) => x;
            Int16M IMath<Int16M>.Round(Int16M x, MidpointRounding mode) => x;
            Int16M IMath<Int16M>.Sin(Int16M x) => (Int16M)Math.Sin(x._value);
            Int16M IMath<Int16M>.Sinh(Int16M x) => (Int16M)Math.Sinh(x._value);
            Int16M IMath<Int16M>.Sqrt(Int16M x) => (Int16M)Math.Sqrt(x._value);
            Int16M IMath<Int16M>.Tan(Int16M x) => (Int16M)Math.Tan(x._value);
            Int16M IMath<Int16M>.Tanh(Int16M x) => (Int16M)Math.Tanh(x._value);
            Int16M IMath<Int16M>.Tau { get; } = (short)6;
            Int16M IMath<Int16M>.Truncate(Int16M x) => x;
            int IMath<Int16M>.Sign(Int16M x) => Math.Sign(x._value);

            int INumericBitConverter<Int16M>.ConvertedSize => sizeof(short);
            Int16M INumericBitConverter<Int16M>.ToNumeric(byte[] value, int startIndex) => BitConverter.ToInt16(value, startIndex);
            byte[] INumericBitConverter<Int16M>.GetBytes(Int16M value) => BitConverter.GetBytes(value._value);

            bool IConvert<Int16M>.ToBoolean(Int16M value) => value._value != 0;
            byte IConvert<Int16M>.ToByte(Int16M value, Conversion mode) => ConvertN.ToByte(value._value, mode.Clamped());
            decimal IConvert<Int16M>.ToDecimal(Int16M value, Conversion mode) => ConvertN.ToDecimal(value._value, mode.Clamped());
            double IConvert<Int16M>.ToDouble(Int16M value, Conversion mode) => ConvertN.ToDouble(value._value, mode.Clamped());
            float IConvert<Int16M>.ToSingle(Int16M value, Conversion mode) => ConvertN.ToSingle(value._value, mode.Clamped());
            int IConvert<Int16M>.ToInt32(Int16M value, Conversion mode) => ConvertN.ToInt32(value._value, mode.Clamped());
            long IConvert<Int16M>.ToInt64(Int16M value, Conversion mode) => ConvertN.ToInt64(value._value, mode.Clamped());
            sbyte IConvertExtended<Int16M>.ToSByte(Int16M value, Conversion mode) => ConvertN.ToSByte(value._value, mode.Clamped());
            short IConvert<Int16M>.ToInt16(Int16M value, Conversion mode) => value._value;
            string IConvert<Int16M>.ToString(Int16M value) => Convert.ToString(value._value);
            uint IConvertExtended<Int16M>.ToUInt32(Int16M value, Conversion mode) => ConvertN.ToUInt32(value._value, mode.Clamped());
            ulong IConvertExtended<Int16M>.ToUInt64(Int16M value, Conversion mode) => ConvertN.ToUInt64(value._value, mode.Clamped());
            ushort IConvertExtended<Int16M>.ToUInt16(Int16M value, Conversion mode) => ConvertN.ToUInt16(value._value, mode.Clamped());

            Int16M IConvert<Int16M>.ToNumeric(bool value) => value ? (short)1 : (short)0;
            Int16M IConvert<Int16M>.ToNumeric(byte value, Conversion mode) => ConvertN.ToInt16(value, mode.Clamped());
            Int16M IConvert<Int16M>.ToNumeric(decimal value, Conversion mode) => ConvertN.ToInt16(value, mode.Clamped());
            Int16M IConvert<Int16M>.ToNumeric(double value, Conversion mode) => ConvertN.ToInt16(value, mode.Clamped());
            Int16M IConvert<Int16M>.ToNumeric(float value, Conversion mode) => ConvertN.ToInt16(value, mode.Clamped());
            Int16M IConvert<Int16M>.ToNumeric(int value, Conversion mode) => ConvertN.ToInt16(value, mode.Clamped());
            Int16M IConvert<Int16M>.ToNumeric(long value, Conversion mode) => ConvertN.ToInt16(value, mode.Clamped());
            Int16M IConvertExtended<Int16M>.ToValue(sbyte value, Conversion mode) => ConvertN.ToInt16(value, mode.Clamped());
            Int16M IConvert<Int16M>.ToNumeric(short value, Conversion mode) => value;
            Int16M IConvert<Int16M>.ToNumeric(string value) => Convert.ToInt16(value);
            Int16M IConvertExtended<Int16M>.ToNumeric(uint value, Conversion mode) => ConvertN.ToInt16(value, mode.Clamped());
            Int16M IConvertExtended<Int16M>.ToNumeric(ulong value, Conversion mode) => ConvertN.ToInt16(value, mode.Clamped());
            Int16M IConvertExtended<Int16M>.ToNumeric(ushort value, Conversion mode) => ConvertN.ToInt16(value, mode.Clamped());

            Int16M INumericStatic<Int16M>.Parse(string s, NumberStyles? style, IFormatProvider? provider)
                => Parse(s, style ?? NumberStyles.Integer, provider);

            Int16M INumericRandom<Int16M>.Generate(Random random) => random.NextInt16();
            Int16M INumericRandom<Int16M>.Generate(Random random, Int16M maxValue) => random.NextInt16(maxValue);
            Int16M INumericRandom<Int16M>.Generate(Random random, Int16M minValue, Int16M maxValue) => random.NextInt16(minValue, maxValue);
            Int16M INumericRandom<Int16M>.Generate(Random random, Generation mode) => random.NextInt16(mode);
            Int16M INumericRandom<Int16M>.Generate(Random random, Int16M minValue, Int16M maxValue, Generation mode) => random.NextInt16(minValue, maxValue, mode);

            Int16M IVariantRandom<Int16M>.Generate(Random random, Variants scenarios) => NumericVariant.Generate<Int16M>(random, scenarios);
        }
    }
}
