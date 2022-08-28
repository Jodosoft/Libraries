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
using Jodo.Numerics;
using Jodo.Primitives;
using Jodo.Primitives.Compatibility;

namespace Jodo.CheckedNumerics
{
    /// <summary>
    /// Represents a 32-bit unsigned integer that cannot overflow.
    /// </summary>
    [Serializable]
    [DebuggerDisplay("{ToString(),nq}")]
    public readonly struct UInt32C : INumericExtended<UInt32C>
    {
        public static readonly UInt32C MaxValue = new UInt32C(uint.MaxValue);
        public static readonly UInt32C MinValue = new UInt32C(uint.MinValue);

        private readonly uint _value;

        private UInt32C(uint value)
        {
            _value = value;
        }

        private UInt32C(SerializationInfo info, StreamingContext context) : this(info.GetUInt32(nameof(UInt32C))) { }
        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context) => info.AddValue(nameof(UInt32C), _value);

        public int CompareTo(object? obj) => obj is UInt32C other ? CompareTo(other) : 1;
        public int CompareTo(UInt32C other) => _value.CompareTo(other._value);
        public bool Equals(UInt32C other) => _value == other._value;
        public override bool Equals(object? obj) => obj is UInt32C other && Equals(other);
        public override int GetHashCode() => _value.GetHashCode();
        public override string ToString() => _value.ToString();
        public string ToString(IFormatProvider formatProvider) => _value.ToString(formatProvider);
        public string ToString(string format) => _value.ToString(format);
        public string ToString(string? format, IFormatProvider? formatProvider) => _value.ToString(format, formatProvider);

        public static bool TryParse(string s, IFormatProvider? provider, out UInt32C result) => TryHelper.Run(() => Parse(s, provider), out result);
        public static bool TryParse(string s, NumberStyles style, IFormatProvider? provider, out UInt32C result) => TryHelper.Run(() => Parse(s, style, provider), out result);
        public static bool TryParse(string s, NumberStyles style, out UInt32C result) => TryHelper.Run(() => Parse(s, style), out result);
        public static bool TryParse(string s, out UInt32C result) => TryHelper.Run(() => Parse(s), out result);
        public static UInt32C Parse(string s) => uint.Parse(s);
        public static UInt32C Parse(string s, IFormatProvider? provider) => uint.Parse(s, provider);
        public static UInt32C Parse(string s, NumberStyles style) => uint.Parse(s, style);
        public static UInt32C Parse(string s, NumberStyles style, IFormatProvider? provider) => uint.Parse(s, style, provider);

        [CLSCompliant(false)] public static explicit operator UInt32C(sbyte value) => new UInt32C(ConvertN.ToUInt32(value, Conversion.CastClamp));
        [CLSCompliant(false)] public static explicit operator UInt32C(ulong value) => new UInt32C(ConvertN.ToUInt32(value, Conversion.CastClamp));
        [CLSCompliant(false)] public static implicit operator UInt32C(uint value) => new UInt32C(value);
        [CLSCompliant(false)] public static implicit operator UInt32C(ushort value) => new UInt32C(value);
        public static explicit operator UInt32C(decimal value) => new UInt32C(ConvertN.ToUInt32(value, Conversion.CastClamp));
        public static explicit operator UInt32C(double value) => new UInt32C(ConvertN.ToUInt32(value, Conversion.CastClamp));
        public static explicit operator UInt32C(float value) => new UInt32C(ConvertN.ToUInt32(value, Conversion.CastClamp));
        public static explicit operator UInt32C(int value) => new UInt32C(ConvertN.ToUInt32(value, Conversion.CastClamp));
        public static explicit operator UInt32C(long value) => new UInt32C(ConvertN.ToUInt32(value, Conversion.CastClamp));
        public static explicit operator UInt32C(short value) => new UInt32C(ConvertN.ToUInt32(value, Conversion.CastClamp));
        public static implicit operator UInt32C(byte value) => new UInt32C(value);

        [CLSCompliant(false)] public static explicit operator sbyte(UInt32C value) => ConvertN.ToSByte(value._value, Conversion.CastClamp);
        [CLSCompliant(false)] public static explicit operator ushort(UInt32C value) => ConvertN.ToUInt16(value._value, Conversion.CastClamp);
        [CLSCompliant(false)] public static implicit operator uint(UInt32C value) => value._value;
        [CLSCompliant(false)] public static implicit operator ulong(UInt32C value) => value._value;
        public static explicit operator byte(UInt32C value) => ConvertN.ToByte(value._value, Conversion.CastClamp);
        public static explicit operator int(UInt32C value) => ConvertN.ToInt32(value._value, Conversion.CastClamp);
        public static explicit operator short(UInt32C value) => ConvertN.ToInt16(value._value, Conversion.CastClamp);
        public static implicit operator decimal(UInt32C value) => value._value;
        public static implicit operator double(UInt32C value) => value._value;
        public static implicit operator float(UInt32C value) => value._value;
        public static implicit operator long(UInt32C value) => value._value;

        public static bool operator !=(UInt32C left, UInt32C right) => left._value != right._value;
        public static bool operator <(UInt32C left, UInt32C right) => left._value < right._value;
        public static bool operator <=(UInt32C left, UInt32C right) => left._value <= right._value;
        public static bool operator ==(UInt32C left, UInt32C right) => left._value == right._value;
        public static bool operator >(UInt32C left, UInt32C right) => left._value > right._value;
        public static bool operator >=(UInt32C left, UInt32C right) => left._value >= right._value;
        public static UInt32C operator %(UInt32C left, UInt32C right) => CheckedMath.Remainder(left._value, right._value);
        public static UInt32C operator &(UInt32C left, UInt32C right) => left._value & right._value;
        public static UInt32C operator -(UInt32C _) => MinValue;
        public static UInt32C operator -(UInt32C left, UInt32C right) => CheckedMath.Subtract(left._value, right._value);
        public static UInt32C operator --(UInt32C value) => value - 1;
        public static UInt32C operator *(UInt32C left, UInt32C right) => CheckedMath.Multiply(left._value, right._value);
        public static UInt32C operator /(UInt32C left, UInt32C right) => CheckedMath.Divide(left._value, right._value);
        public static UInt32C operator ^(UInt32C left, UInt32C right) => left._value ^ right._value;
        public static UInt32C operator |(UInt32C left, UInt32C right) => left._value | right._value;
        public static UInt32C operator ~(UInt32C value) => ~value._value;
        public static UInt32C operator +(UInt32C left, UInt32C right) => CheckedMath.Add(left._value, right._value);
        public static UInt32C operator +(UInt32C value) => value;
        public static UInt32C operator ++(UInt32C value) => value + 1;
        public static UInt32C operator <<(UInt32C left, int right) => left._value << right;
        public static UInt32C operator >>(UInt32C left, int right) => left._value >> right;

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
        uint IConvertible.ToUInt32(IFormatProvider provider) => _value;
        ulong IConvertible.ToUInt64(IFormatProvider provider) => ConvertN.ToUInt64(_value, Conversion.Clamp);
        ushort IConvertible.ToUInt16(IFormatProvider provider) => ConvertN.ToUInt16(_value, Conversion.Clamp);
        object IConvertible.ToType(Type conversionType, IFormatProvider provider) => this.ToTypeDefault(conversionType, provider);

        bool INumeric<UInt32C>.IsGreaterThan(UInt32C value) => this > value;
        bool INumeric<UInt32C>.IsGreaterThanOrEqualTo(UInt32C value) => this >= value;
        bool INumeric<UInt32C>.IsLessThan(UInt32C value) => this < value;
        bool INumeric<UInt32C>.IsLessThanOrEqualTo(UInt32C value) => this <= value;
        UInt32C INumeric<UInt32C>.Add(UInt32C value) => this + value;
        UInt32C INumeric<UInt32C>.BitwiseComplement() => ~this;
        UInt32C INumeric<UInt32C>.Divide(UInt32C value) => this / value;
        UInt32C INumeric<UInt32C>.LeftShift(int count) => this << count;
        UInt32C INumeric<UInt32C>.LogicalAnd(UInt32C value) => this & value;
        UInt32C INumeric<UInt32C>.LogicalExclusiveOr(UInt32C value) => this ^ value;
        UInt32C INumeric<UInt32C>.LogicalOr(UInt32C value) => this | value;
        UInt32C INumeric<UInt32C>.Multiply(UInt32C value) => this * value;
        UInt32C INumeric<UInt32C>.Negative() => -this;
        UInt32C INumeric<UInt32C>.Positive() => +this;
        UInt32C INumeric<UInt32C>.Remainder(UInt32C value) => this % value;
        UInt32C INumeric<UInt32C>.RightShift(int count) => this >> count;
        UInt32C INumeric<UInt32C>.Subtract(UInt32C value) => this - value;

        INumericBitConverter<UInt32C> IProvider<INumericBitConverter<UInt32C>>.GetInstance() => Utilities.Instance;
        IConvert<UInt32C> IProvider<IConvert<UInt32C>>.GetInstance() => Utilities.Instance;
        IConvertExtended<UInt32C> IProvider<IConvertExtended<UInt32C>>.GetInstance() => Utilities.Instance;
        IMath<UInt32C> IProvider<IMath<UInt32C>>.GetInstance() => Utilities.Instance;
        INumericRandom<UInt32C> IProvider<INumericRandom<UInt32C>>.GetInstance() => Utilities.Instance;
        INumericStatic<UInt32C> IProvider<INumericStatic<UInt32C>>.GetInstance() => Utilities.Instance;
        IVariantRandom<UInt32C> IProvider<IVariantRandom<UInt32C>>.GetInstance() => Utilities.Instance;

        private sealed class Utilities :
            INumericBitConverter<UInt32C>,
            IConvert<UInt32C>,
            IConvertExtended<UInt32C>,
            IMath<UInt32C>,
            INumericRandom<UInt32C>,
            INumericStatic<UInt32C>,
            IVariantRandom<UInt32C>
        {
            public static readonly Utilities Instance = new Utilities();

            bool INumericStatic<UInt32C>.HasFloatingPoint => false;
            bool INumericStatic<UInt32C>.HasInfinity => false;
            bool INumericStatic<UInt32C>.HasNaN => false;
            bool INumericStatic<UInt32C>.IsFinite(UInt32C x) => true;
            bool INumericStatic<UInt32C>.IsInfinity(UInt32C x) => false;
            bool INumericStatic<UInt32C>.IsNaN(UInt32C x) => false;
            bool INumericStatic<UInt32C>.IsNegative(UInt32C x) => false;
            bool INumericStatic<UInt32C>.IsNegativeInfinity(UInt32C x) => false;
            bool INumericStatic<UInt32C>.IsNormal(UInt32C x) => false;
            bool INumericStatic<UInt32C>.IsPositiveInfinity(UInt32C x) => false;
            bool INumericStatic<UInt32C>.IsReal => false;
            bool INumericStatic<UInt32C>.IsSigned => false;
            bool INumericStatic<UInt32C>.IsSubnormal(UInt32C x) => false;
            UInt32C INumericStatic<UInt32C>.Epsilon => 1;
            UInt32C INumericStatic<UInt32C>.MaxUnit => 1;
            UInt32C INumericStatic<UInt32C>.MaxValue => MaxValue;
            UInt32C INumericStatic<UInt32C>.MinUnit => 0;
            UInt32C INumericStatic<UInt32C>.MinValue => MinValue;
            UInt32C INumericStatic<UInt32C>.One => 1;
            UInt32C INumericStatic<UInt32C>.Ten => 10;
            UInt32C INumericStatic<UInt32C>.Two => 2;
            UInt32C INumericStatic<UInt32C>.Zero => 0;

            int IMath<UInt32C>.Sign(UInt32C x) => x._value == 0 ? 0 : 1;
            UInt32C IMath<UInt32C>.Abs(UInt32C value) => value;
            UInt32C IMath<UInt32C>.Acos(UInt32C x) => (UInt32C)Math.Acos(x._value);
            UInt32C IMath<UInt32C>.Acosh(UInt32C x) => (UInt32C)MathCompat.Acosh(x._value);
            UInt32C IMath<UInt32C>.Asin(UInt32C x) => (UInt32C)Math.Asin(x._value);
            UInt32C IMath<UInt32C>.Asinh(UInt32C x) => (UInt32C)MathCompat.Asinh(x._value);
            UInt32C IMath<UInt32C>.Atan(UInt32C x) => (UInt32C)Math.Atan(x._value);
            UInt32C IMath<UInt32C>.Atan2(UInt32C x, UInt32C y) => (UInt32C)Math.Atan2(x._value, y._value);
            UInt32C IMath<UInt32C>.Atanh(UInt32C x) => (UInt32C)MathCompat.Atanh(x._value);
            UInt32C IMath<UInt32C>.Cbrt(UInt32C x) => (UInt32C)MathCompat.Cbrt(x._value);
            UInt32C IMath<UInt32C>.Ceiling(UInt32C x) => x;
            UInt32C IMath<UInt32C>.Clamp(UInt32C x, UInt32C bound1, UInt32C bound2) => bound1 > bound2 ? Math.Min(bound1._value, Math.Max(bound2._value, x._value)) : Math.Min(bound2._value, Math.Max(bound1._value, x._value));
            UInt32C IMath<UInt32C>.Cos(UInt32C x) => (UInt32C)Math.Cos(x._value);
            UInt32C IMath<UInt32C>.Cosh(UInt32C x) => (UInt32C)Math.Cosh(x._value);
            UInt32C IMath<UInt32C>.DegreesToRadians(UInt32C x) => (UInt32C)CheckedMath.Multiply(x, BitOperations.RadiansPerDegree);
            UInt32C IMath<UInt32C>.E { get; } = 2;
            UInt32C IMath<UInt32C>.Exp(UInt32C x) => (UInt32C)Math.Exp(x._value);
            UInt32C IMath<UInt32C>.Floor(UInt32C x) => x;
            UInt32C IMath<UInt32C>.IEEERemainder(UInt32C x, UInt32C y) => (UInt32C)Math.IEEERemainder(x._value, y._value);
            UInt32C IMath<UInt32C>.Log(UInt32C x) => (UInt32C)Math.Log(x._value);
            UInt32C IMath<UInt32C>.Log(UInt32C x, UInt32C y) => (UInt32C)Math.Log(x._value, y._value);
            UInt32C IMath<UInt32C>.Log10(UInt32C x) => (UInt32C)Math.Log10(x._value);
            UInt32C IMath<UInt32C>.Max(UInt32C x, UInt32C y) => Math.Max(x._value, y._value);
            UInt32C IMath<UInt32C>.Min(UInt32C x, UInt32C y) => Math.Min(x._value, y._value);
            UInt32C IMath<UInt32C>.PI { get; } = 3;
            UInt32C IMath<UInt32C>.Pow(UInt32C x, UInt32C y) => CheckedMath.Pow(x._value, y._value);
            UInt32C IMath<UInt32C>.RadiansToDegrees(UInt32C x) => (UInt32C)CheckedMath.Multiply(x, BitOperations.DegreesPerRadian);
            UInt32C IMath<UInt32C>.Round(UInt32C x) => x;
            UInt32C IMath<UInt32C>.Round(UInt32C x, int digits) => x;
            UInt32C IMath<UInt32C>.Round(UInt32C x, int digits, MidpointRounding mode) => x;
            UInt32C IMath<UInt32C>.Round(UInt32C x, MidpointRounding mode) => x;
            UInt32C IMath<UInt32C>.Sin(UInt32C x) => (UInt32C)Math.Sin(x._value);
            UInt32C IMath<UInt32C>.Sinh(UInt32C x) => (UInt32C)Math.Sinh(x._value);
            UInt32C IMath<UInt32C>.Sqrt(UInt32C x) => (UInt32C)Math.Sqrt(x._value);
            UInt32C IMath<UInt32C>.Tan(UInt32C x) => (UInt32C)Math.Tan(x._value);
            UInt32C IMath<UInt32C>.Tanh(UInt32C x) => (UInt32C)Math.Tanh(x._value);
            UInt32C IMath<UInt32C>.Tau { get; } = 6;
            UInt32C IMath<UInt32C>.Truncate(UInt32C x) => x;

            UInt32C INumericBitConverter<UInt32C>.Read(IReader<byte> stream) => BitConverter.ToUInt32(stream.Read(sizeof(uint)), 0);
            void INumericBitConverter<UInt32C>.Write(UInt32C value, IWriter<byte> stream) => stream.Write(BitConverter.GetBytes(value._value));

            bool IConvert<UInt32C>.ToBoolean(UInt32C value) => value._value != 0;
            byte IConvert<UInt32C>.ToByte(UInt32C value, Conversion mode) => ConvertN.ToByte(value._value, mode.Clamped());
            decimal IConvert<UInt32C>.ToDecimal(UInt32C value, Conversion mode) => ConvertN.ToDecimal(value._value, mode.Clamped());
            double IConvert<UInt32C>.ToDouble(UInt32C value, Conversion mode) => ConvertN.ToDouble(value._value, mode.Clamped());
            float IConvert<UInt32C>.ToSingle(UInt32C value, Conversion mode) => ConvertN.ToSingle(value._value, mode.Clamped());
            int IConvert<UInt32C>.ToInt32(UInt32C value, Conversion mode) => ConvertN.ToInt32(value._value, mode.Clamped());
            long IConvert<UInt32C>.ToInt64(UInt32C value, Conversion mode) => ConvertN.ToInt64(value._value, mode.Clamped());
            sbyte IConvertExtended<UInt32C>.ToSByte(UInt32C value, Conversion mode) => ConvertN.ToSByte(value._value, mode.Clamped());
            short IConvert<UInt32C>.ToInt16(UInt32C value, Conversion mode) => ConvertN.ToInt16(value._value, mode.Clamped());
            string IConvert<UInt32C>.ToString(UInt32C value) => Convert.ToString(value._value);
            uint IConvertExtended<UInt32C>.ToUInt32(UInt32C value, Conversion mode) => value._value;
            ulong IConvertExtended<UInt32C>.ToUInt64(UInt32C value, Conversion mode) => ConvertN.ToUInt64(value._value, mode.Clamped());
            ushort IConvertExtended<UInt32C>.ToUInt16(UInt32C value, Conversion mode) => ConvertN.ToUInt16(value._value, mode.Clamped());

            UInt32C IConvert<UInt32C>.ToNumeric(bool value) => value ? 1 : (uint)0;
            UInt32C IConvert<UInt32C>.ToNumeric(byte value, Conversion mode) => ConvertN.ToUInt32(value, mode.Clamped());
            UInt32C IConvert<UInt32C>.ToNumeric(decimal value, Conversion mode) => ConvertN.ToUInt32(value, mode.Clamped());
            UInt32C IConvert<UInt32C>.ToNumeric(double value, Conversion mode) => ConvertN.ToUInt32(value, mode.Clamped());
            UInt32C IConvert<UInt32C>.ToNumeric(float value, Conversion mode) => ConvertN.ToUInt32(value, mode.Clamped());
            UInt32C IConvert<UInt32C>.ToNumeric(int value, Conversion mode) => ConvertN.ToUInt32(value, mode.Clamped());
            UInt32C IConvert<UInt32C>.ToNumeric(long value, Conversion mode) => ConvertN.ToUInt32(value, mode.Clamped());
            UInt32C IConvertExtended<UInt32C>.ToValue(sbyte value, Conversion mode) => ConvertN.ToUInt32(value, mode.Clamped());
            UInt32C IConvert<UInt32C>.ToNumeric(short value, Conversion mode) => ConvertN.ToUInt32(value, mode.Clamped());
            UInt32C IConvert<UInt32C>.ToNumeric(string value) => Convert.ToUInt32(value);
            UInt32C IConvertExtended<UInt32C>.ToNumeric(uint value, Conversion mode) => value;
            UInt32C IConvertExtended<UInt32C>.ToNumeric(ulong value, Conversion mode) => ConvertN.ToUInt32(value, mode.Clamped());
            UInt32C IConvertExtended<UInt32C>.ToNumeric(ushort value, Conversion mode) => ConvertN.ToUInt32(value, mode.Clamped());

            UInt32C INumericStatic<UInt32C>.Parse(string s, NumberStyles? style, IFormatProvider? provider)
                => Parse(s, style ?? NumberStyles.Integer, provider);

            UInt32C INumericRandom<UInt32C>.Next(Random random) => random.NextUInt32();
            UInt32C INumericRandom<UInt32C>.Next(Random random, UInt32C maxValue) => random.NextUInt32(maxValue);
            UInt32C INumericRandom<UInt32C>.Next(Random random, UInt32C minValue, UInt32C maxValue) => random.NextUInt32(minValue, maxValue);
            UInt32C INumericRandom<UInt32C>.Next(Random random, Generation mode) => random.NextUInt32(mode);
            UInt32C INumericRandom<UInt32C>.Next(Random random, UInt32C minValue, UInt32C maxValue, Generation mode) => random.NextUInt32(minValue, maxValue, mode);

            UInt32C IVariantRandom<UInt32C>.Next(Random random, Scenarios scenarios) => NumericVariant.Generate<UInt32C>(random, scenarios);
        }
    }
}
