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
    /// Represents a 32-bit signed integer that cannot overflow.
    /// </summary>
    [Serializable]
    [DebuggerDisplay("{ToString(),nq}")]
    public readonly struct Int32M : INumericExtended<Int32M>
    {
        public static readonly Int32M MaxValue = new Int32M(int.MaxValue);
        public static readonly Int32M MinValue = new Int32M(int.MinValue);

        private readonly int _value;

        private Int32M(int value)
        {
            _value = value;
        }

        private Int32M(SerializationInfo info, StreamingContext context) : this(info.GetInt32(nameof(Int32M))) { }
        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context) => info.AddValue(nameof(Int32M), _value);

        public int CompareTo(Int32M other) => _value.CompareTo(other._value);
        public int CompareTo(object? obj) => obj is Int32M other ? CompareTo(other) : 1;
        public bool Equals(Int32M other) => _value == other._value;
        public override bool Equals(object? obj) => obj is Int32M other && Equals(other);
        public override int GetHashCode() => _value.GetHashCode();
        public override string ToString() => _value.ToString();
        public string ToString(IFormatProvider formatProvider) => _value.ToString(formatProvider);
        public string ToString(string format) => _value.ToString(format);
        public string ToString(string? format, IFormatProvider? formatProvider) => _value.ToString(format, formatProvider);

        public static bool TryParse(string s, IFormatProvider? provider, out Int32M result) => FuncExtensions.Try(() => Parse(s, provider), out result);
        public static bool TryParse(string s, NumberStyles style, IFormatProvider? provider, out Int32M result) => FuncExtensions.Try(() => Parse(s, style, provider), out result);
        public static bool TryParse(string s, NumberStyles style, out Int32M result) => FuncExtensions.Try(() => Parse(s, style), out result);
        public static bool TryParse(string s, out Int32M result) => FuncExtensions.Try(() => Parse(s), out result);
        public static Int32M Parse(string s) => int.Parse(s);
        public static Int32M Parse(string s, IFormatProvider? provider) => int.Parse(s, provider);
        public static Int32M Parse(string s, NumberStyles style) => int.Parse(s, style);
        public static Int32M Parse(string s, NumberStyles style, IFormatProvider? provider) => int.Parse(s, style, provider);

        [CLSCompliant(false)] public static explicit operator Int32M(uint value) => new Int32M(ConvertN.ToInt32(value, Conversion.CastClamp));
        [CLSCompliant(false)] public static explicit operator Int32M(ulong value) => new Int32M(ConvertN.ToInt32(value, Conversion.CastClamp));
        [CLSCompliant(false)] public static implicit operator Int32M(sbyte value) => new Int32M(value);
        [CLSCompliant(false)] public static implicit operator Int32M(ushort value) => new Int32M(value);
        public static explicit operator Int32M(decimal value) => new Int32M(ConvertN.ToInt32(value, Conversion.CastClamp));
        public static explicit operator Int32M(double value) => new Int32M(ConvertN.ToInt32(value, Conversion.CastClamp));
        public static explicit operator Int32M(float value) => new Int32M(ConvertN.ToInt32(value, Conversion.CastClamp));
        public static explicit operator Int32M(long value) => new Int32M(ConvertN.ToInt32(value, Conversion.CastClamp));
        public static implicit operator Int32M(byte value) => new Int32M(value);
        public static implicit operator Int32M(int value) => new Int32M(value);
        public static implicit operator Int32M(short value) => new Int32M(value);

        [CLSCompliant(false)] public static explicit operator sbyte(Int32M value) => ConvertN.ToSByte(value._value, Conversion.CastClamp);
        [CLSCompliant(false)] public static explicit operator uint(Int32M value) => ConvertN.ToUInt32(value._value, Conversion.CastClamp);
        [CLSCompliant(false)] public static explicit operator ulong(Int32M value) => ConvertN.ToUInt64(value._value, Conversion.CastClamp);
        [CLSCompliant(false)] public static explicit operator ushort(Int32M value) => ConvertN.ToUInt16(value._value, Conversion.CastClamp);
        public static explicit operator byte(Int32M value) => ConvertN.ToByte(value._value, Conversion.CastClamp);
        public static explicit operator short(Int32M value) => ConvertN.ToInt16(value._value, Conversion.CastClamp);
        public static implicit operator decimal(Int32M value) => value._value;
        public static implicit operator double(Int32M value) => value._value;
        public static implicit operator float(Int32M value) => value._value;
        public static implicit operator int(Int32M value) => value._value;
        public static implicit operator long(Int32M value) => value._value;

        public static bool operator !=(Int32M left, Int32M right) => left._value != right._value;
        public static bool operator <(Int32M left, Int32M right) => left._value < right._value;
        public static bool operator <=(Int32M left, Int32M right) => left._value <= right._value;
        public static bool operator ==(Int32M left, Int32M right) => left._value == right._value;
        public static bool operator >(Int32M left, Int32M right) => left._value > right._value;
        public static bool operator >=(Int32M left, Int32M right) => left._value >= right._value;
        public static Int32M operator %(Int32M left, Int32M right) => Clamped.Remainder(left._value, right._value);
        public static Int32M operator &(Int32M left, Int32M right) => left._value & right._value;
        public static Int32M operator -(Int32M left, Int32M right) => Clamped.Subtract(left._value, right._value);
        public static Int32M operator --(Int32M value) => value - 1;
        public static Int32M operator -(Int32M value) => -value._value;
        public static Int32M operator *(Int32M left, Int32M right) => Clamped.Multiply(left._value, right._value);
        public static Int32M operator /(Int32M left, Int32M right) => Clamped.Divide(left._value, right._value);
        public static Int32M operator ^(Int32M left, Int32M right) => left._value ^ right._value;
        public static Int32M operator |(Int32M left, Int32M right) => left._value | right._value;
        public static Int32M operator ~(Int32M value) => ~value._value;
        public static Int32M operator +(Int32M left, Int32M right) => Clamped.Add(left._value, right._value);
        public static Int32M operator +(Int32M value) => value;
        public static Int32M operator ++(Int32M value) => value + 1;
        public static Int32M operator <<(Int32M left, int right) => left._value << right;
        public static Int32M operator >>(Int32M left, int right) => left._value >> right;

        TypeCode IConvertible.GetTypeCode() => _value.GetTypeCode();
        bool IConvertible.ToBoolean(IFormatProvider provider) => Convert.ToBoolean(_value, provider);
        byte IConvertible.ToByte(IFormatProvider provider) => ConvertN.ToByte(_value, Conversion.Clamp);
        char IConvertible.ToChar(IFormatProvider provider) => Convert.ToChar(_value, provider);
        DateTime IConvertible.ToDateTime(IFormatProvider provider) => Convert.ToDateTime(provider);
        decimal IConvertible.ToDecimal(IFormatProvider provider) => ConvertN.ToDecimal(_value, Conversion.Clamp);
        double IConvertible.ToDouble(IFormatProvider provider) => ConvertN.ToDouble(_value, Conversion.Clamp);
        float IConvertible.ToSingle(IFormatProvider provider) => ConvertN.ToSingle(_value, Conversion.Clamp);
        int IConvertible.ToInt32(IFormatProvider provider) => _value;
        long IConvertible.ToInt64(IFormatProvider provider) => ConvertN.ToInt64(_value, Conversion.Clamp);
        sbyte IConvertible.ToSByte(IFormatProvider provider) => ConvertN.ToSByte(_value, Conversion.Clamp);
        short IConvertible.ToInt16(IFormatProvider provider) => ConvertN.ToInt16(_value, Conversion.Clamp);
        uint IConvertible.ToUInt32(IFormatProvider provider) => ConvertN.ToUInt32(_value, Conversion.Clamp);
        ulong IConvertible.ToUInt64(IFormatProvider provider) => ConvertN.ToUInt64(_value, Conversion.Clamp);
        ushort IConvertible.ToUInt16(IFormatProvider provider) => ConvertN.ToUInt16(_value, Conversion.Clamp);
        object IConvertible.ToType(Type conversionType, IFormatProvider provider) => this.ToTypeDefault(conversionType, provider);

        bool INumeric<Int32M>.IsGreaterThan(Int32M value) => this > value;
        bool INumeric<Int32M>.IsGreaterThanOrEqualTo(Int32M value) => this >= value;
        bool INumeric<Int32M>.IsLessThan(Int32M value) => this < value;
        bool INumeric<Int32M>.IsLessThanOrEqualTo(Int32M value) => this <= value;
        Int32M INumeric<Int32M>.Add(Int32M value) => this + value;
        Int32M INumeric<Int32M>.BitwiseComplement() => ~this;
        Int32M INumeric<Int32M>.Divide(Int32M value) => this / value;
        Int32M INumeric<Int32M>.LeftShift(int count) => this << count;
        Int32M INumeric<Int32M>.LogicalAnd(Int32M value) => this & value;
        Int32M INumeric<Int32M>.LogicalExclusiveOr(Int32M value) => this ^ value;
        Int32M INumeric<Int32M>.LogicalOr(Int32M value) => this | value;
        Int32M INumeric<Int32M>.Multiply(Int32M value) => this * value;
        Int32M INumeric<Int32M>.Negative() => -this;
        Int32M INumeric<Int32M>.Positive() => +this;
        Int32M INumeric<Int32M>.Remainder(Int32M value) => this % value;
        Int32M INumeric<Int32M>.RightShift(int count) => this >> count;
        Int32M INumeric<Int32M>.Subtract(Int32M value) => this - value;

        INumericBitConverter<Int32M> IProvider<INumericBitConverter<Int32M>>.GetInstance() => Utilities.Instance;
        IConvert<Int32M> IProvider<IConvert<Int32M>>.GetInstance() => Utilities.Instance;
        IConvertExtended<Int32M> IProvider<IConvertExtended<Int32M>>.GetInstance() => Utilities.Instance;
        IMath<Int32M> IProvider<IMath<Int32M>>.GetInstance() => Utilities.Instance;
        INumericRandom<Int32M> IProvider<INumericRandom<Int32M>>.GetInstance() => Utilities.Instance;
        INumericStatic<Int32M> IProvider<INumericStatic<Int32M>>.GetInstance() => Utilities.Instance;
        IVariantRandom<Int32M> IProvider<IVariantRandom<Int32M>>.GetInstance() => Utilities.Instance;

        private sealed class Utilities :
            IConvert<Int32M>,
            IConvertExtended<Int32M>,
            IMath<Int32M>,
            INumericBitConverter<Int32M>,
            INumericRandom<Int32M>,
            INumericStatic<Int32M>,
            IVariantRandom<Int32M>
        {
            public static readonly Utilities Instance = new Utilities();

            bool INumericStatic<Int32M>.HasFloatingPoint => false;
            bool INumericStatic<Int32M>.HasInfinity => false;
            bool INumericStatic<Int32M>.HasNaN => false;
            bool INumericStatic<Int32M>.IsFinite(Int32M x) => true;
            bool INumericStatic<Int32M>.IsInfinity(Int32M x) => false;
            bool INumericStatic<Int32M>.IsNaN(Int32M x) => false;
            bool INumericStatic<Int32M>.IsNegative(Int32M x) => x._value < 0;
            bool INumericStatic<Int32M>.IsNegativeInfinity(Int32M x) => false;
            bool INumericStatic<Int32M>.IsNormal(Int32M x) => false;
            bool INumericStatic<Int32M>.IsPositiveInfinity(Int32M x) => false;
            bool INumericStatic<Int32M>.IsReal => false;
            bool INumericStatic<Int32M>.IsSigned => true;
            bool INumericStatic<Int32M>.IsSubnormal(Int32M x) => false;
            Int32M INumericStatic<Int32M>.Epsilon => 1;
            Int32M INumericStatic<Int32M>.MaxUnit => 1;
            Int32M INumericStatic<Int32M>.MaxValue => MaxValue;
            Int32M INumericStatic<Int32M>.MinUnit => -1;
            Int32M INumericStatic<Int32M>.MinValue => MinValue;
            Int32M INumericStatic<Int32M>.One => 1;
            Int32M INumericStatic<Int32M>.Zero => 0;

            Int32M IMath<Int32M>.Abs(Int32M value) => Math.Abs(value._value);
            Int32M IMath<Int32M>.Acos(Int32M x) => (Int32M)Math.Acos(x._value);
            Int32M IMath<Int32M>.Acosh(Int32M x) => (Int32M)MathShim.Acosh(x._value);
            Int32M IMath<Int32M>.Asin(Int32M x) => (Int32M)Math.Asin(x._value);
            Int32M IMath<Int32M>.Asinh(Int32M x) => (Int32M)MathShim.Asinh(x._value);
            Int32M IMath<Int32M>.Atan(Int32M x) => (Int32M)Math.Atan(x._value);
            Int32M IMath<Int32M>.Atan2(Int32M x, Int32M y) => (Int32M)Math.Atan2(x._value, y._value);
            Int32M IMath<Int32M>.Atanh(Int32M x) => (Int32M)MathShim.Atanh(x._value);
            Int32M IMath<Int32M>.Cbrt(Int32M x) => (Int32M)MathShim.Cbrt(x._value);
            Int32M IMath<Int32M>.Ceiling(Int32M x) => x;
            Int32M IMath<Int32M>.Clamp(Int32M x, Int32M bound1, Int32M bound2) => bound1 > bound2 ? Math.Min(bound1._value, Math.Max(bound2._value, x._value)) : Math.Min(bound2._value, Math.Max(bound1._value, x._value));
            Int32M IMath<Int32M>.Cos(Int32M x) => (Int32M)Math.Cos(x._value);
            Int32M IMath<Int32M>.Cosh(Int32M x) => (Int32M)Math.Cosh(x._value);
            Int32M IMath<Int32M>.E { get; } = 2;
            Int32M IMath<Int32M>.Exp(Int32M x) => (Int32M)Math.Exp(x._value);
            Int32M IMath<Int32M>.Floor(Int32M x) => x;
            Int32M IMath<Int32M>.IEEERemainder(Int32M x, Int32M y) => (Int32M)Math.IEEERemainder(x._value, y._value);
            Int32M IMath<Int32M>.Log(Int32M x) => (Int32M)Math.Log(x._value);
            Int32M IMath<Int32M>.Log(Int32M x, Int32M y) => (Int32M)Math.Log(x._value, y._value);
            Int32M IMath<Int32M>.Log10(Int32M x) => (Int32M)Math.Log10(x._value);
            Int32M IMath<Int32M>.Max(Int32M x, Int32M y) => Math.Max(x._value, y._value);
            Int32M IMath<Int32M>.Min(Int32M x, Int32M y) => Math.Min(x._value, y._value);
            Int32M IMath<Int32M>.PI { get; } = 3;
            Int32M IMath<Int32M>.Pow(Int32M x, Int32M y) => Clamped.Pow(x._value, y._value);
            Int32M IMath<Int32M>.Round(Int32M x) => x;
            Int32M IMath<Int32M>.Round(Int32M x, int digits) => x;
            Int32M IMath<Int32M>.Round(Int32M x, int digits, MidpointRounding mode) => x;
            Int32M IMath<Int32M>.Round(Int32M x, MidpointRounding mode) => x;
            Int32M IMath<Int32M>.Sin(Int32M x) => (Int32M)Math.Sin(x._value);
            Int32M IMath<Int32M>.Sinh(Int32M x) => (Int32M)Math.Sinh(x._value);
            Int32M IMath<Int32M>.Sqrt(Int32M x) => (Int32M)Math.Sqrt(x._value);
            Int32M IMath<Int32M>.Tan(Int32M x) => (Int32M)Math.Tan(x._value);
            Int32M IMath<Int32M>.Tanh(Int32M x) => (Int32M)Math.Tanh(x._value);
            Int32M IMath<Int32M>.Tau { get; } = 6;
            Int32M IMath<Int32M>.Truncate(Int32M x) => x;
            int IMath<Int32M>.Sign(Int32M x) => Math.Sign(x._value);

            int INumericBitConverter<Int32M>.ConvertedSize => sizeof(int);
            Int32M INumericBitConverter<Int32M>.ToNumeric(byte[] value, int startIndex) => BitConverter.ToInt32(value, startIndex);
            byte[] INumericBitConverter<Int32M>.GetBytes(Int32M value) => BitConverter.GetBytes(value._value);

            bool IConvert<Int32M>.ToBoolean(Int32M value) => value._value != 0;
            byte IConvert<Int32M>.ToByte(Int32M value, Conversion mode) => ConvertN.ToByte(value._value, mode.Clamped());
            decimal IConvert<Int32M>.ToDecimal(Int32M value, Conversion mode) => ConvertN.ToDecimal(value._value, mode.Clamped());
            double IConvert<Int32M>.ToDouble(Int32M value, Conversion mode) => ConvertN.ToDouble(value._value, mode.Clamped());
            float IConvert<Int32M>.ToSingle(Int32M value, Conversion mode) => ConvertN.ToSingle(value._value, mode.Clamped());
            int IConvert<Int32M>.ToInt32(Int32M value, Conversion mode) => value._value;
            long IConvert<Int32M>.ToInt64(Int32M value, Conversion mode) => ConvertN.ToInt64(value._value, mode.Clamped());
            sbyte IConvertExtended<Int32M>.ToSByte(Int32M value, Conversion mode) => ConvertN.ToSByte(value._value, mode.Clamped());
            short IConvert<Int32M>.ToInt16(Int32M value, Conversion mode) => ConvertN.ToInt16(value._value, mode.Clamped());
            string IConvert<Int32M>.ToString(Int32M value) => Convert.ToString(value._value);
            uint IConvertExtended<Int32M>.ToUInt32(Int32M value, Conversion mode) => ConvertN.ToUInt32(value._value, mode.Clamped());
            ulong IConvertExtended<Int32M>.ToUInt64(Int32M value, Conversion mode) => ConvertN.ToUInt64(value._value, mode.Clamped());
            ushort IConvertExtended<Int32M>.ToUInt16(Int32M value, Conversion mode) => ConvertN.ToUInt16(value._value, mode.Clamped());

            Int32M IConvert<Int32M>.ToNumeric(bool value) => value ? 1 : 0;
            Int32M IConvert<Int32M>.ToNumeric(byte value, Conversion mode) => ConvertN.ToInt32(value, mode.Clamped());
            Int32M IConvert<Int32M>.ToNumeric(decimal value, Conversion mode) => ConvertN.ToInt32(value, mode.Clamped());
            Int32M IConvert<Int32M>.ToNumeric(double value, Conversion mode) => ConvertN.ToInt32(value, mode.Clamped());
            Int32M IConvert<Int32M>.ToNumeric(float value, Conversion mode) => ConvertN.ToInt32(value, mode.Clamped());
            Int32M IConvert<Int32M>.ToNumeric(int value, Conversion mode) => value;
            Int32M IConvert<Int32M>.ToNumeric(long value, Conversion mode) => ConvertN.ToInt32(value, mode.Clamped());
            Int32M IConvertExtended<Int32M>.ToValue(sbyte value, Conversion mode) => ConvertN.ToInt32(value, mode.Clamped());
            Int32M IConvert<Int32M>.ToNumeric(short value, Conversion mode) => ConvertN.ToInt32(value, mode.Clamped());
            Int32M IConvert<Int32M>.ToNumeric(string value) => Convert.ToInt32(value);
            Int32M IConvertExtended<Int32M>.ToNumeric(uint value, Conversion mode) => ConvertN.ToInt32(value, mode.Clamped());
            Int32M IConvertExtended<Int32M>.ToNumeric(ulong value, Conversion mode) => ConvertN.ToInt32(value, mode.Clamped());
            Int32M IConvertExtended<Int32M>.ToNumeric(ushort value, Conversion mode) => ConvertN.ToInt32(value, mode.Clamped());

            Int32M INumericStatic<Int32M>.Parse(string s, NumberStyles? style, IFormatProvider? provider)
                => Parse(s, style ?? NumberStyles.Integer, provider);

            Int32M INumericRandom<Int32M>.Generate(Random random) => random.NextInt32();
            Int32M INumericRandom<Int32M>.Generate(Random random, Int32M maxValue) => random.NextInt32(maxValue);
            Int32M INumericRandom<Int32M>.Generate(Random random, Int32M minValue, Int32M maxValue) => random.NextInt32(minValue, maxValue);
            Int32M INumericRandom<Int32M>.Generate(Random random, Generation mode) => random.NextInt32(mode);
            Int32M INumericRandom<Int32M>.Generate(Random random, Int32M minValue, Int32M maxValue, Generation mode) => random.NextInt32(minValue, maxValue, mode);

            Int32M IVariantRandom<Int32M>.Generate(Random random, Variants variants) => random.NextInt32(variants);
        }
    }
}
