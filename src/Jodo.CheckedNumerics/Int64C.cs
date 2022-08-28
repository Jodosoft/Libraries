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
    /// Represents a 64-bit signed integer that cannot overflow.
    /// </summary>
    [Serializable]
    [DebuggerDisplay("{ToString(),nq}")]
    public readonly struct Int64C : INumericExtended<Int64C>
    {
        public static readonly Int64C MaxValue = new Int64C(long.MaxValue);
        public static readonly Int64C MinValue = new Int64C(long.MinValue);

        private readonly long _value;

        private Int64C(long value)
        {
            _value = value;
        }

        private Int64C(SerializationInfo info, StreamingContext context) : this(info.GetInt64(nameof(Int64C))) { }
        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context) => info.AddValue(nameof(Int64C), _value);

        public int CompareTo(Int64C other) => _value.CompareTo(other._value);
        public int CompareTo(object? obj) => obj is Int64C other ? CompareTo(other) : 1;
        public bool Equals(Int64C other) => _value == other._value;
        public override bool Equals(object? obj) => obj is Int64C other && Equals(other);
        public override int GetHashCode() => _value.GetHashCode();
        public override string ToString() => _value.ToString();
        public string ToString(IFormatProvider formatProvider) => _value.ToString(formatProvider);
        public string ToString(string format) => _value.ToString(format);
        public string ToString(string? format, IFormatProvider? formatProvider) => _value.ToString(format, formatProvider);

        public static bool TryParse(string s, IFormatProvider? provider, out Int64C result) => TryHelper.Run(() => Parse(s, provider), out result);
        public static bool TryParse(string s, NumberStyles style, IFormatProvider? provider, out Int64C result) => TryHelper.Run(() => Parse(s, style, provider), out result);
        public static bool TryParse(string s, NumberStyles style, out Int64C result) => TryHelper.Run(() => Parse(s, style), out result);
        public static bool TryParse(string s, out Int64C result) => TryHelper.Run(() => Parse(s), out result);
        public static Int64C Parse(string s) => long.Parse(s);
        public static Int64C Parse(string s, IFormatProvider? provider) => long.Parse(s, provider);
        public static Int64C Parse(string s, NumberStyles style) => long.Parse(s, style);
        public static Int64C Parse(string s, NumberStyles style, IFormatProvider? provider) => long.Parse(s, style, provider);

        [CLSCompliant(false)] public static explicit operator Int64C(ulong value) => new Int64C(ConvertN.ToInt64(value, Conversion.CastClamp));
        [CLSCompliant(false)] public static implicit operator Int64C(sbyte value) => new Int64C(value);
        [CLSCompliant(false)] public static implicit operator Int64C(uint value) => new Int64C(value);
        [CLSCompliant(false)] public static implicit operator Int64C(ushort value) => new Int64C(value);
        public static explicit operator Int64C(decimal value) => new Int64C(ConvertN.ToInt64(value, Conversion.CastClamp));
        public static explicit operator Int64C(double value) => new Int64C(ConvertN.ToInt64(value, Conversion.CastClamp));
        public static explicit operator Int64C(float value) => new Int64C(ConvertN.ToInt64(value, Conversion.CastClamp));
        public static implicit operator Int64C(byte value) => new Int64C(value);
        public static implicit operator Int64C(int value) => new Int64C(value);
        public static implicit operator Int64C(long value) => new Int64C(value);
        public static implicit operator Int64C(short value) => new Int64C(value);

        [CLSCompliant(false)] public static explicit operator sbyte(Int64C value) => ConvertN.ToSByte(value._value, Conversion.CastClamp);
        [CLSCompliant(false)] public static explicit operator uint(Int64C value) => ConvertN.ToUInt32(value._value, Conversion.CastClamp);
        [CLSCompliant(false)] public static explicit operator ulong(Int64C value) => ConvertN.ToUInt64(value._value, Conversion.CastClamp);
        [CLSCompliant(false)] public static explicit operator ushort(Int64C value) => ConvertN.ToUInt16(value._value, Conversion.CastClamp);
        public static explicit operator byte(Int64C value) => ConvertN.ToByte(value._value, Conversion.CastClamp);
        public static explicit operator int(Int64C value) => ConvertN.ToInt32(value._value, Conversion.CastClamp);
        public static explicit operator short(Int64C value) => ConvertN.ToInt16(value._value, Conversion.CastClamp);
        public static implicit operator decimal(Int64C value) => value._value;
        public static implicit operator double(Int64C value) => value._value;
        public static implicit operator float(Int64C value) => value._value;
        public static implicit operator long(Int64C value) => value._value;

        public static bool operator !=(Int64C left, Int64C right) => left._value != right._value;
        public static bool operator <(Int64C left, Int64C right) => left._value < right._value;
        public static bool operator <=(Int64C left, Int64C right) => left._value <= right._value;
        public static bool operator ==(Int64C left, Int64C right) => left._value == right._value;
        public static bool operator >(Int64C left, Int64C right) => left._value > right._value;
        public static bool operator >=(Int64C left, Int64C right) => left._value >= right._value;
        public static Int64C operator %(Int64C left, Int64C right) => CheckedMath.Remainder(left._value, right._value);
        public static Int64C operator &(Int64C left, Int64C right) => left._value & right._value;
        public static Int64C operator -(Int64C left, Int64C right) => CheckedMath.Subtract(left._value, right._value);
        public static Int64C operator --(Int64C value) => CheckedMath.Subtract(value._value, 1);
        public static Int64C operator -(Int64C value) => -value._value;
        public static Int64C operator *(Int64C left, Int64C right) => CheckedMath.Multiply(left._value, right._value);
        public static Int64C operator /(Int64C left, Int64C right) => CheckedMath.Divide(left._value, right._value);
        public static Int64C operator ^(Int64C left, Int64C right) => left._value ^ right._value;
        public static Int64C operator |(Int64C left, Int64C right) => left._value | right._value;
        public static Int64C operator ~(Int64C value) => ~value._value;
        public static Int64C operator +(Int64C left, Int64C right) => CheckedMath.Add(left._value, right._value);
        public static Int64C operator +(Int64C value) => value;
        public static Int64C operator ++(Int64C value) => CheckedMath.Add(value._value, 1);
        public static Int64C operator <<(Int64C left, int right) => left._value << right;
        public static Int64C operator >>(Int64C left, int right) => left._value >> right;

        TypeCode IConvertible.GetTypeCode() => _value.GetTypeCode();
        bool IConvertible.ToBoolean(IFormatProvider provider) => Convert.ToBoolean(_value, provider);
        byte IConvertible.ToByte(IFormatProvider provider) => ConvertN.ToByte(_value, Conversion.Clamp);
        char IConvertible.ToChar(IFormatProvider provider) => Convert.ToChar(_value, provider);
        DateTime IConvertible.ToDateTime(IFormatProvider provider) => Convert.ToDateTime(provider);
        decimal IConvertible.ToDecimal(IFormatProvider provider) => ConvertN.ToDecimal(_value, Conversion.Clamp);
        double IConvertible.ToDouble(IFormatProvider provider) => ConvertN.ToDouble(_value, Conversion.Clamp);
        float IConvertible.ToSingle(IFormatProvider provider) => ConvertN.ToSingle(_value, Conversion.Clamp);
        int IConvertible.ToInt32(IFormatProvider provider) => ConvertN.ToInt32(_value, Conversion.Clamp);
        long IConvertible.ToInt64(IFormatProvider provider) => _value;
        sbyte IConvertible.ToSByte(IFormatProvider provider) => ConvertN.ToSByte(_value, Conversion.Clamp);
        short IConvertible.ToInt16(IFormatProvider provider) => ConvertN.ToInt16(_value, Conversion.Clamp);
        uint IConvertible.ToUInt32(IFormatProvider provider) => ConvertN.ToUInt32(_value, Conversion.Clamp);
        ulong IConvertible.ToUInt64(IFormatProvider provider) => ConvertN.ToUInt64(_value, Conversion.Clamp);
        ushort IConvertible.ToUInt16(IFormatProvider provider) => ConvertN.ToUInt16(_value, Conversion.Clamp);
        object IConvertible.ToType(Type conversionType, IFormatProvider provider) => this.ToTypeDefault(conversionType, provider);

        bool INumeric<Int64C>.IsGreaterThan(Int64C value) => this > value;
        bool INumeric<Int64C>.IsGreaterThanOrEqualTo(Int64C value) => this >= value;
        bool INumeric<Int64C>.IsLessThan(Int64C value) => this < value;
        bool INumeric<Int64C>.IsLessThanOrEqualTo(Int64C value) => this <= value;
        Int64C INumeric<Int64C>.Add(Int64C value) => this + value;
        Int64C INumeric<Int64C>.BitwiseComplement() => ~this;
        Int64C INumeric<Int64C>.Divide(Int64C value) => this / value;
        Int64C INumeric<Int64C>.LeftShift(int count) => this << count;
        Int64C INumeric<Int64C>.LogicalAnd(Int64C value) => this & value;
        Int64C INumeric<Int64C>.LogicalExclusiveOr(Int64C value) => this ^ value;
        Int64C INumeric<Int64C>.LogicalOr(Int64C value) => this | value;
        Int64C INumeric<Int64C>.Multiply(Int64C value) => this * value;
        Int64C INumeric<Int64C>.Negative() => -this;
        Int64C INumeric<Int64C>.Positive() => +this;
        Int64C INumeric<Int64C>.Remainder(Int64C value) => this % value;
        Int64C INumeric<Int64C>.RightShift(int count) => this >> count;
        Int64C INumeric<Int64C>.Subtract(Int64C value) => this - value;

        IBitConvert<Int64C> IProvider<IBitConvert<Int64C>>.GetInstance() => Utilities.Instance;
        IConvert<Int64C> IProvider<IConvert<Int64C>>.GetInstance() => Utilities.Instance;
        IConvertExtended<Int64C> IProvider<IConvertExtended<Int64C>>.GetInstance() => Utilities.Instance;
        IMath<Int64C> IProvider<IMath<Int64C>>.GetInstance() => Utilities.Instance;
        INumericRandom<Int64C> IProvider<INumericRandom<Int64C>>.GetInstance() => Utilities.Instance;
        INumericStatic<Int64C> IProvider<INumericStatic<Int64C>>.GetInstance() => Utilities.Instance;
        IVariantRandom<Int64C> IProvider<IVariantRandom<Int64C>>.GetInstance() => Utilities.Instance;

        private sealed class Utilities :
            IBitConvert<Int64C>,
            IConvert<Int64C>,
            IConvertExtended<Int64C>,
            IMath<Int64C>,
            INumericRandom<Int64C>,
            INumericStatic<Int64C>,
            IVariantRandom<Int64C>
        {
            public static readonly Utilities Instance = new Utilities();

            bool INumericStatic<Int64C>.HasFloatingPoint => false;
            bool INumericStatic<Int64C>.HasInfinity => false;
            bool INumericStatic<Int64C>.HasNaN => false;
            bool INumericStatic<Int64C>.IsFinite(Int64C x) => true;
            bool INumericStatic<Int64C>.IsInfinity(Int64C x) => false;
            bool INumericStatic<Int64C>.IsNaN(Int64C x) => false;
            bool INumericStatic<Int64C>.IsNegative(Int64C x) => x._value < 0;
            bool INumericStatic<Int64C>.IsNegativeInfinity(Int64C x) => false;
            bool INumericStatic<Int64C>.IsNormal(Int64C x) => false;
            bool INumericStatic<Int64C>.IsPositiveInfinity(Int64C x) => false;
            bool INumericStatic<Int64C>.IsReal => false;
            bool INumericStatic<Int64C>.IsSigned => true;
            bool INumericStatic<Int64C>.IsSubnormal(Int64C x) => false;
            Int64C INumericStatic<Int64C>.Epsilon => 1L;
            Int64C INumericStatic<Int64C>.MaxUnit => 1L;
            Int64C INumericStatic<Int64C>.MaxValue => MaxValue;
            Int64C INumericStatic<Int64C>.MinUnit => -1L;
            Int64C INumericStatic<Int64C>.MinValue => MinValue;
            Int64C INumericStatic<Int64C>.One => 1L;
            Int64C INumericStatic<Int64C>.Ten => 10L;
            Int64C INumericStatic<Int64C>.Two => 2L;
            Int64C INumericStatic<Int64C>.Zero => 0L;

            Int64C IMath<Int64C>.Abs(Int64C value) => Math.Abs(value);
            Int64C IMath<Int64C>.Acos(Int64C x) => (Int64C)Math.Acos(x);
            Int64C IMath<Int64C>.Acosh(Int64C x) => (Int64C)MathCompat.Acosh(x);
            Int64C IMath<Int64C>.Asin(Int64C x) => (Int64C)Math.Asin(x);
            Int64C IMath<Int64C>.Asinh(Int64C x) => (Int64C)MathCompat.Asinh(x);
            Int64C IMath<Int64C>.Atan(Int64C x) => (Int64C)Math.Atan(x);
            Int64C IMath<Int64C>.Atan2(Int64C y, Int64C x) => (Int64C)Math.Atan2(y, x);
            Int64C IMath<Int64C>.Atanh(Int64C x) => (Int64C)MathCompat.Atanh(x);
            Int64C IMath<Int64C>.Cbrt(Int64C x) => (Int64C)MathCompat.Cbrt(x);
            Int64C IMath<Int64C>.Ceiling(Int64C x) => x;
            Int64C IMath<Int64C>.Clamp(Int64C x, Int64C bound1, Int64C bound2) => bound1 > bound2 ? Math.Min(bound1, Math.Max(bound2, x)) : Math.Min(bound2, Math.Max(bound1, x));
            Int64C IMath<Int64C>.Cos(Int64C x) => (Int64C)Math.Cos(x);
            Int64C IMath<Int64C>.Cosh(Int64C x) => (Int64C)Math.Cosh(x);
            Int64C IMath<Int64C>.DegreesToRadians(Int64C degrees) => (Int64C)CheckedMath.Multiply(degrees, BitOperations.RadiansPerDegree);
            Int64C IMath<Int64C>.E { get; } = 2L;
            Int64C IMath<Int64C>.Exp(Int64C x) => (Int64C)Math.Exp(x);
            Int64C IMath<Int64C>.Floor(Int64C x) => x;
            Int64C IMath<Int64C>.IEEERemainder(Int64C x, Int64C y) => (Int64C)Math.IEEERemainder(x, y);
            Int64C IMath<Int64C>.Log(Int64C x) => (Int64C)Math.Log(x);
            Int64C IMath<Int64C>.Log(Int64C x, Int64C y) => (Int64C)Math.Log(x, y);
            Int64C IMath<Int64C>.Log10(Int64C x) => (Int64C)Math.Log10(x);
            Int64C IMath<Int64C>.Max(Int64C x, Int64C y) => Math.Max(x, y);
            Int64C IMath<Int64C>.Min(Int64C x, Int64C y) => Math.Min(x, y);
            Int64C IMath<Int64C>.PI { get; } = 3L;
            Int64C IMath<Int64C>.Pow(Int64C x, Int64C y) => CheckedMath.Pow(x, y);
            Int64C IMath<Int64C>.RadiansToDegrees(Int64C radians) => (Int64C)CheckedMath.Multiply(radians, BitOperations.DegreesPerRadian);
            Int64C IMath<Int64C>.Round(Int64C x) => x;
            Int64C IMath<Int64C>.Round(Int64C x, int digits) => x;
            Int64C IMath<Int64C>.Round(Int64C x, int digits, MidpointRounding mode) => x;
            Int64C IMath<Int64C>.Round(Int64C x, MidpointRounding mode) => x;
            Int64C IMath<Int64C>.Sin(Int64C x) => (Int64C)Math.Sin(x);
            Int64C IMath<Int64C>.Sinh(Int64C x) => (Int64C)Math.Sinh(x);
            Int64C IMath<Int64C>.Sqrt(Int64C x) => (Int64C)Math.Sqrt(x);
            Int64C IMath<Int64C>.Tan(Int64C x) => (Int64C)Math.Tan(x);
            Int64C IMath<Int64C>.Tanh(Int64C x) => (Int64C)Math.Tanh(x);
            Int64C IMath<Int64C>.Tau { get; } = 6L;
            Int64C IMath<Int64C>.Truncate(Int64C x) => x;
            int IMath<Int64C>.Sign(Int64C x) => Math.Sign(x._value);

            Int64C IBitConvert<Int64C>.Read(IReader<byte> stream) => BitConverter.ToInt64(stream.Read(sizeof(long)), 0);
            void IBitConvert<Int64C>.Write(Int64C value, IWriter<byte> stream) => stream.Write(BitConverter.GetBytes(value._value));

            bool IConvert<Int64C>.ToBoolean(Int64C value) => value._value != 0;
            byte IConvert<Int64C>.ToByte(Int64C value, Conversion mode) => ConvertN.ToByte(value._value, mode.Clamped());
            decimal IConvert<Int64C>.ToDecimal(Int64C value, Conversion mode) => ConvertN.ToDecimal(value._value, mode.Clamped());
            double IConvert<Int64C>.ToDouble(Int64C value, Conversion mode) => ConvertN.ToDouble(value._value, mode.Clamped());
            float IConvert<Int64C>.ToSingle(Int64C value, Conversion mode) => ConvertN.ToSingle(value._value, mode.Clamped());
            int IConvert<Int64C>.ToInt32(Int64C value, Conversion mode) => ConvertN.ToInt32(value._value, mode.Clamped());
            long IConvert<Int64C>.ToInt64(Int64C value, Conversion mode) => value._value;
            sbyte IConvertExtended<Int64C>.ToSByte(Int64C value, Conversion mode) => ConvertN.ToSByte(value._value, mode.Clamped());
            short IConvert<Int64C>.ToInt16(Int64C value, Conversion mode) => ConvertN.ToInt16(value._value, mode.Clamped());
            string IConvert<Int64C>.ToString(Int64C value) => Convert.ToString(value._value);
            uint IConvertExtended<Int64C>.ToUInt32(Int64C value, Conversion mode) => ConvertN.ToUInt32(value._value, mode.Clamped());
            ulong IConvertExtended<Int64C>.ToUInt64(Int64C value, Conversion mode) => ConvertN.ToUInt64(value._value, mode.Clamped());
            ushort IConvertExtended<Int64C>.ToUInt16(Int64C value, Conversion mode) => ConvertN.ToUInt16(value._value, mode.Clamped());

            Int64C IConvert<Int64C>.ToNumeric(bool value) => value ? 1 : 0;
            Int64C IConvert<Int64C>.ToNumeric(byte value, Conversion mode) => ConvertN.ToInt64(value, mode.Clamped());
            Int64C IConvert<Int64C>.ToNumeric(decimal value, Conversion mode) => ConvertN.ToInt64(value, mode.Clamped());
            Int64C IConvert<Int64C>.ToNumeric(double value, Conversion mode) => ConvertN.ToInt64(value, mode.Clamped());
            Int64C IConvert<Int64C>.ToNumeric(float value, Conversion mode) => ConvertN.ToInt64(value, mode.Clamped());
            Int64C IConvert<Int64C>.ToNumeric(int value, Conversion mode) => ConvertN.ToInt64(value, mode.Clamped());
            Int64C IConvert<Int64C>.ToNumeric(long value, Conversion mode) => value;
            Int64C IConvertExtended<Int64C>.ToValue(sbyte value, Conversion mode) => ConvertN.ToInt64(value, mode.Clamped());
            Int64C IConvert<Int64C>.ToNumeric(short value, Conversion mode) => ConvertN.ToInt64(value, mode.Clamped());
            Int64C IConvert<Int64C>.ToNumeric(string value) => Convert.ToInt64(value);
            Int64C IConvertExtended<Int64C>.ToNumeric(uint value, Conversion mode) => ConvertN.ToInt64(value, mode.Clamped());
            Int64C IConvertExtended<Int64C>.ToNumeric(ulong value, Conversion mode) => ConvertN.ToInt64(value, mode.Clamped());
            Int64C IConvertExtended<Int64C>.ToNumeric(ushort value, Conversion mode) => ConvertN.ToInt64(value, mode.Clamped());

            Int64C INumericStatic<Int64C>.Parse(string s, NumberStyles? style, IFormatProvider? provider)
                => Parse(s, style ?? NumberStyles.Integer, provider);

            Int64C INumericRandom<Int64C>.Next(Random random) => random.NextInt64();
            Int64C INumericRandom<Int64C>.Next(Random random, Int64C maxValue) => random.NextInt64(maxValue);
            Int64C INumericRandom<Int64C>.Next(Random random, Int64C minValue, Int64C maxValue) => random.NextInt64(minValue, maxValue);
            Int64C INumericRandom<Int64C>.Next(Random random, Generation mode) => random.NextInt64(mode);
            Int64C INumericRandom<Int64C>.Next(Random random, Int64C minValue, Int64C maxValue, Generation mode) => random.NextInt64(minValue, maxValue, mode);

            Int64C IVariantRandom<Int64C>.Next(Random random, Scenarios scenarios) => NumericVariant.Generate<Int64C>(random, scenarios);
        }
    }
}
