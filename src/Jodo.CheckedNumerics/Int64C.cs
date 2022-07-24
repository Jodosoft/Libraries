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

        [CLSCompliant(false)] public static explicit operator Int64C(ulong value) => new Int64C(NumericConvert.ToInt64(value, Conversion.CastClamp));
        [CLSCompliant(false)] public static implicit operator Int64C(sbyte value) => new Int64C(value);
        [CLSCompliant(false)] public static implicit operator Int64C(uint value) => new Int64C(value);
        [CLSCompliant(false)] public static implicit operator Int64C(ushort value) => new Int64C(value);
        public static explicit operator Int64C(decimal value) => new Int64C(NumericConvert.ToInt64(value, Conversion.CastClamp));
        public static explicit operator Int64C(double value) => new Int64C(NumericConvert.ToInt64(value, Conversion.CastClamp));
        public static explicit operator Int64C(float value) => new Int64C(NumericConvert.ToInt64(value, Conversion.CastClamp));
        public static implicit operator Int64C(byte value) => new Int64C(value);
        public static implicit operator Int64C(int value) => new Int64C(value);
        public static implicit operator Int64C(long value) => new Int64C(value);
        public static implicit operator Int64C(short value) => new Int64C(value);

        [CLSCompliant(false)] public static explicit operator sbyte(Int64C value) => NumericConvert.ToSByte(value._value, Conversion.CastClamp);
        [CLSCompliant(false)] public static explicit operator uint(Int64C value) => NumericConvert.ToUInt32(value._value, Conversion.CastClamp);
        [CLSCompliant(false)] public static explicit operator ulong(Int64C value) => NumericConvert.ToUInt64(value._value, Conversion.CastClamp);
        [CLSCompliant(false)] public static explicit operator ushort(Int64C value) => NumericConvert.ToUInt16(value._value, Conversion.CastClamp);
        public static explicit operator byte(Int64C value) => NumericConvert.ToByte(value._value, Conversion.CastClamp);
        public static explicit operator int(Int64C value) => NumericConvert.ToInt32(value._value, Conversion.CastClamp);
        public static explicit operator short(Int64C value) => NumericConvert.ToInt16(value._value, Conversion.CastClamp);
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
        public static Int64C operator %(Int64C left, Int64C right) => CheckedArithmetic.Remainder(left._value, right._value);
        public static Int64C operator &(Int64C left, Int64C right) => left._value & right._value;
        public static Int64C operator -(Int64C left, Int64C right) => CheckedArithmetic.Subtract(left._value, right._value);
        public static Int64C operator --(Int64C value) => CheckedArithmetic.Subtract(value._value, 1);
        public static Int64C operator -(Int64C value) => -value._value;
        public static Int64C operator *(Int64C left, Int64C right) => CheckedArithmetic.Multiply(left._value, right._value);
        public static Int64C operator /(Int64C left, Int64C right) => CheckedArithmetic.Divide(left._value, right._value);
        public static Int64C operator ^(Int64C left, Int64C right) => left._value ^ right._value;
        public static Int64C operator |(Int64C left, Int64C right) => left._value | right._value;
        public static Int64C operator ~(Int64C value) => ~value._value;
        public static Int64C operator +(Int64C left, Int64C right) => CheckedArithmetic.Add(left._value, right._value);
        public static Int64C operator +(Int64C value) => value;
        public static Int64C operator ++(Int64C value) => CheckedArithmetic.Add(value._value, 1);
        public static Int64C operator <<(Int64C left, int right) => left._value << right;
        public static Int64C operator >>(Int64C left, int right) => left._value >> right;

        TypeCode IConvertible.GetTypeCode() => _value.GetTypeCode();
        bool IConvertible.ToBoolean(IFormatProvider provider) => ((IConvertible)_value).ToBoolean(provider);
        char IConvertible.ToChar(IFormatProvider provider) => ((IConvertible)_value).ToChar(provider);
        sbyte IConvertible.ToSByte(IFormatProvider provider) => ((IConvertible)_value).ToSByte(provider);
        byte IConvertible.ToByte(IFormatProvider provider) => ((IConvertible)_value).ToByte(provider);
        short IConvertible.ToInt16(IFormatProvider provider) => ((IConvertible)_value).ToInt16(provider);
        ushort IConvertible.ToUInt16(IFormatProvider provider) => ((IConvertible)_value).ToUInt16(provider);
        int IConvertible.ToInt32(IFormatProvider provider) => ((IConvertible)_value).ToInt32(provider);
        uint IConvertible.ToUInt32(IFormatProvider provider) => ((IConvertible)_value).ToUInt32(provider);
        long IConvertible.ToInt64(IFormatProvider provider) => ((IConvertible)_value).ToInt64(provider);
        ulong IConvertible.ToUInt64(IFormatProvider provider) => ((IConvertible)_value).ToUInt64(provider);
        float IConvertible.ToSingle(IFormatProvider provider) => ((IConvertible)_value).ToSingle(provider);
        double IConvertible.ToDouble(IFormatProvider provider) => ((IConvertible)_value).ToDouble(provider);
        decimal IConvertible.ToDecimal(IFormatProvider provider) => ((IConvertible)_value).ToDecimal(provider);
        DateTime IConvertible.ToDateTime(IFormatProvider provider) => ((IConvertible)_value).ToDateTime(provider);
        object IConvertible.ToType(Type conversionType, IFormatProvider provider) => ((IConvertible)_value).ToType(conversionType, provider);

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

        IBitConverter<Int64C> IProvider<IBitConverter<Int64C>>.GetInstance() => Utilities.Instance;
        IConvert<Int64C> IProvider<IConvert<Int64C>>.GetInstance() => Utilities.Instance;
        IConvertExtended<Int64C> IProvider<IConvertExtended<Int64C>>.GetInstance() => Utilities.Instance;
        IMath<Int64C> IProvider<IMath<Int64C>>.GetInstance() => Utilities.Instance;
        INumericStatic<Int64C> IProvider<INumericStatic<Int64C>>.GetInstance() => Utilities.Instance;
        IRandom<Int64C> IProvider<IRandom<Int64C>>.GetInstance() => Utilities.Instance;
        IStringParser<Int64C> IProvider<IStringParser<Int64C>>.GetInstance() => Utilities.Instance;

        private sealed class Utilities :
            IBitConverter<Int64C>,
            IConvert<Int64C>,
            IConvertExtended<Int64C>,
            IMath<Int64C>,
            INumericStatic<Int64C>,
            IRandom<Int64C>,
            IStringParser<Int64C>
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
            Int64C IMath<Int64C>.DegreesToRadians(Int64C degrees) => (Int64C)CheckedArithmetic.Multiply(degrees, NumericUtilities.RadiansPerDegree);
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
            Int64C IMath<Int64C>.Pow(Int64C x, Int64C y) => CheckedArithmetic.Pow(x, y);
            Int64C IMath<Int64C>.RadiansToDegrees(Int64C radians) => (Int64C)CheckedArithmetic.Multiply(radians, NumericUtilities.DegreesPerRadian);
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

            Int64C IBitConverter<Int64C>.Read(IReader<byte> stream) => BitConverter.ToInt64(stream.Read(sizeof(long)), 0);
            void IBitConverter<Int64C>.Write(Int64C value, IWriter<byte> stream) => stream.Write(BitConverter.GetBytes(value._value));

            Int64C IRandom<Int64C>.Next(Random random) => random.NextInt64();
            Int64C IRandom<Int64C>.Next(Random random, Int64C bound1, Int64C bound2) => random.NextInt64(bound1._value, bound2._value);

            bool IConvert<Int64C>.ToBoolean(Int64C value) => value._value != 0;
            byte IConvert<Int64C>.ToByte(Int64C value, Conversion mode) => NumericConvert.ToByte(value._value, mode.Clamped());
            decimal IConvert<Int64C>.ToDecimal(Int64C value, Conversion mode) => NumericConvert.ToDecimal(value._value, mode.Clamped());
            double IConvert<Int64C>.ToDouble(Int64C value, Conversion mode) => NumericConvert.ToDouble(value._value, mode.Clamped());
            float IConvert<Int64C>.ToSingle(Int64C value, Conversion mode) => NumericConvert.ToSingle(value._value, mode.Clamped());
            int IConvert<Int64C>.ToInt32(Int64C value, Conversion mode) => NumericConvert.ToInt32(value._value, mode.Clamped());
            long IConvert<Int64C>.ToInt64(Int64C value, Conversion mode) => value._value;
            sbyte IConvertExtended<Int64C>.ToSByte(Int64C value, Conversion mode) => NumericConvert.ToSByte(value._value, mode.Clamped());
            short IConvert<Int64C>.ToInt16(Int64C value, Conversion mode) => NumericConvert.ToInt16(value._value, mode.Clamped());
            string IConvert<Int64C>.ToString(Int64C value) => Convert.ToString(value._value);
            uint IConvertExtended<Int64C>.ToUInt32(Int64C value, Conversion mode) => NumericConvert.ToUInt32(value._value, mode.Clamped());
            ulong IConvertExtended<Int64C>.ToUInt64(Int64C value, Conversion mode) => NumericConvert.ToUInt64(value._value, mode.Clamped());
            ushort IConvertExtended<Int64C>.ToUInt16(Int64C value, Conversion mode) => NumericConvert.ToUInt16(value._value, mode.Clamped());

            Int64C IConvert<Int64C>.ToNumeric(bool value) => value ? 1 : 0;
            Int64C IConvert<Int64C>.ToNumeric(byte value, Conversion mode) => NumericConvert.ToInt64(value, mode.Clamped());
            Int64C IConvert<Int64C>.ToNumeric(decimal value, Conversion mode) => NumericConvert.ToInt64(value, mode.Clamped());
            Int64C IConvert<Int64C>.ToNumeric(double value, Conversion mode) => NumericConvert.ToInt64(value, mode.Clamped());
            Int64C IConvert<Int64C>.ToNumeric(float value, Conversion mode) => NumericConvert.ToInt64(value, mode.Clamped());
            Int64C IConvert<Int64C>.ToNumeric(int value, Conversion mode) => NumericConvert.ToInt64(value, mode.Clamped());
            Int64C IConvert<Int64C>.ToNumeric(long value, Conversion mode) => value;
            Int64C IConvertExtended<Int64C>.ToValue(sbyte value, Conversion mode) => NumericConvert.ToInt64(value, mode.Clamped());
            Int64C IConvert<Int64C>.ToNumeric(short value, Conversion mode) => NumericConvert.ToInt64(value, mode.Clamped());
            Int64C IConvert<Int64C>.ToNumeric(string value) => Convert.ToInt64(value);
            Int64C IConvertExtended<Int64C>.ToNumeric(uint value, Conversion mode) => NumericConvert.ToInt64(value, mode.Clamped());
            Int64C IConvertExtended<Int64C>.ToNumeric(ulong value, Conversion mode) => NumericConvert.ToInt64(value, mode.Clamped());
            Int64C IConvertExtended<Int64C>.ToNumeric(ushort value, Conversion mode) => NumericConvert.ToInt64(value, mode.Clamped());

            Int64C IStringParser<Int64C>.Parse(string s, NumberStyles? style, IFormatProvider? provider)
                => Parse(s, style ?? NumberStyles.Integer, provider);
        }
    }
}
