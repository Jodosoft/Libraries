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

namespace Jodo.Numerics
{
    /// <summary>
    /// Represents a 64-bit signed integer.
    /// </summary>
    [Serializable]
    [DebuggerDisplay("{ToString(),nq}")]
    public readonly struct Int64N : INumericExtended<Int64N>
    {
        public static readonly Int64N MaxValue = new Int64N(long.MaxValue);
        public static readonly Int64N MinValue = new Int64N(long.MinValue);

        private readonly long _value;

        private Int64N(long value)
        {
            _value = value;
        }

        private Int64N(SerializationInfo info, StreamingContext context) : this(info.GetInt64(nameof(Int64N))) { }
        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context) => info.AddValue(nameof(Int64N), _value);

        public int CompareTo(Int64N other) => _value.CompareTo(other._value);
        public int CompareTo(object? obj) => obj is Int64N other ? CompareTo(other) : 1;
        public bool Equals(Int64N other) => _value == other._value;
        public override bool Equals(object? obj) => obj is Int64N other && Equals(other);
        public override int GetHashCode() => _value.GetHashCode();
        public override string ToString() => _value.ToString();
        public string ToString(IFormatProvider formatProvider) => _value.ToString(formatProvider);
        public string ToString(string format) => _value.ToString(format);
        public string ToString(string? format, IFormatProvider? formatProvider) => _value.ToString(format, formatProvider);

        public static bool TryParse(string s, IFormatProvider? provider, out Int64N result) => TryHelper.Run(() => Parse(s, provider), out result);
        public static bool TryParse(string s, NumberStyles style, IFormatProvider? provider, out Int64N result) => TryHelper.Run(() => Parse(s, style, provider), out result);
        public static bool TryParse(string s, NumberStyles style, out Int64N result) => TryHelper.Run(() => Parse(s, style), out result);
        public static bool TryParse(string s, out Int64N result) => TryHelper.Run(() => Parse(s), out result);
        public static Int64N Parse(string s) => long.Parse(s);
        public static Int64N Parse(string s, IFormatProvider? provider) => long.Parse(s, provider);
        public static Int64N Parse(string s, NumberStyles style) => long.Parse(s, style);
        public static Int64N Parse(string s, NumberStyles style, IFormatProvider? provider) => long.Parse(s, style, provider);

        [CLSCompliant(false)] public static explicit operator Int64N(ulong value) => new Int64N((long)value);
        [CLSCompliant(false)] public static implicit operator Int64N(sbyte value) => new Int64N(value);
        [CLSCompliant(false)] public static implicit operator Int64N(uint value) => new Int64N(value);
        [CLSCompliant(false)] public static implicit operator Int64N(ushort value) => new Int64N(value);
        public static explicit operator Int64N(decimal value) => new Int64N((long)value);
        public static explicit operator Int64N(double value) => new Int64N((long)value);
        public static explicit operator Int64N(float value) => new Int64N((long)value);
        public static implicit operator Int64N(byte value) => new Int64N(value);
        public static implicit operator Int64N(int value) => new Int64N(value);
        public static implicit operator Int64N(long value) => new Int64N(value);
        public static implicit operator Int64N(short value) => new Int64N(value);

        [CLSCompliant(false)] public static explicit operator sbyte(Int64N value) => (sbyte)value._value;
        [CLSCompliant(false)] public static explicit operator uint(Int64N value) => (uint)value._value;
        [CLSCompliant(false)] public static explicit operator ulong(Int64N value) => (ulong)value._value;
        [CLSCompliant(false)] public static explicit operator ushort(Int64N value) => (ushort)value._value;
        public static explicit operator byte(Int64N value) => (byte)value._value;
        public static explicit operator int(Int64N value) => (int)value._value;
        public static explicit operator short(Int64N value) => (short)value._value;
        public static implicit operator decimal(Int64N value) => value._value;
        public static implicit operator double(Int64N value) => value._value;
        public static implicit operator float(Int64N value) => value._value;
        public static implicit operator long(Int64N value) => value._value;

        public static bool operator !=(Int64N left, Int64N right) => left._value != right._value;
        public static bool operator <(Int64N left, Int64N right) => left._value < right._value;
        public static bool operator <=(Int64N left, Int64N right) => left._value <= right._value;
        public static bool operator ==(Int64N left, Int64N right) => left._value == right._value;
        public static bool operator >(Int64N left, Int64N right) => left._value > right._value;
        public static bool operator >=(Int64N left, Int64N right) => left._value >= right._value;
        public static Int64N operator %(Int64N left, Int64N right) => left._value % right._value;
        public static Int64N operator &(Int64N left, Int64N right) => left._value & right._value;
        public static Int64N operator -(Int64N left, Int64N right) => left._value - right._value;
        public static Int64N operator --(Int64N value) => value._value - 1;
        public static Int64N operator -(Int64N value) => -value._value;
        public static Int64N operator *(Int64N left, Int64N right) => left._value * right._value;
        public static Int64N operator /(Int64N left, Int64N right) => left._value / right._value;
        public static Int64N operator ^(Int64N left, Int64N right) => left._value ^ right._value;
        public static Int64N operator |(Int64N left, Int64N right) => left._value | right._value;
        public static Int64N operator ~(Int64N value) => ~value._value;
        public static Int64N operator +(Int64N left, Int64N right) => left._value + right._value;
        public static Int64N operator +(Int64N value) => value;
        public static Int64N operator ++(Int64N value) => value._value + 1;
        public static Int64N operator <<(Int64N left, int right) => left._value << right;
        public static Int64N operator >>(Int64N left, int right) => left._value >> right;

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

        bool INumeric<Int64N>.IsGreaterThan(Int64N value) => this > value;
        bool INumeric<Int64N>.IsGreaterThanOrEqualTo(Int64N value) => this >= value;
        bool INumeric<Int64N>.IsLessThan(Int64N value) => this < value;
        bool INumeric<Int64N>.IsLessThanOrEqualTo(Int64N value) => this <= value;
        Int64N INumeric<Int64N>.Add(Int64N value) => this + value;
        Int64N INumeric<Int64N>.BitwiseComplement() => ~this;
        Int64N INumeric<Int64N>.Divide(Int64N value) => this / value;
        Int64N INumeric<Int64N>.LeftShift(int count) => this << count;
        Int64N INumeric<Int64N>.LogicalAnd(Int64N value) => this & value;
        Int64N INumeric<Int64N>.LogicalExclusiveOr(Int64N value) => this ^ value;
        Int64N INumeric<Int64N>.LogicalOr(Int64N value) => this | value;
        Int64N INumeric<Int64N>.Multiply(Int64N value) => this * value;
        Int64N INumeric<Int64N>.Negative() => -this;
        Int64N INumeric<Int64N>.Positive() => +this;
        Int64N INumeric<Int64N>.Remainder(Int64N value) => this % value;
        Int64N INumeric<Int64N>.RightShift(int count) => this >> count;
        Int64N INumeric<Int64N>.Subtract(Int64N value) => this - value;

        INumericBitConverter<Int64N> IProvider<INumericBitConverter<Int64N>>.GetInstance() => Utilities.Instance;
        IConvert<Int64N> IProvider<IConvert<Int64N>>.GetInstance() => Utilities.Instance;
        IConvertExtended<Int64N> IProvider<IConvertExtended<Int64N>>.GetInstance() => Utilities.Instance;
        IMath<Int64N> IProvider<IMath<Int64N>>.GetInstance() => Utilities.Instance;
        INumericStatic<Int64N> IProvider<INumericStatic<Int64N>>.GetInstance() => Utilities.Instance;
        INumericRandom<Int64N> IProvider<INumericRandom<Int64N>>.GetInstance() => Utilities.Instance;
        IVariantRandom<Int64N> IProvider<IVariantRandom<Int64N>>.GetInstance() => Utilities.Instance;

        private sealed class Utilities :
            IConvert<Int64N>,
            IConvertExtended<Int64N>,
            IMath<Int64N>,
            INumericBitConverter<Int64N>,
            INumericRandom<Int64N>,
            INumericStatic<Int64N>,
            IVariantRandom<Int64N>
        {
            public static readonly Utilities Instance = new Utilities();

            bool INumericStatic<Int64N>.HasFloatingPoint => false;
            bool INumericStatic<Int64N>.HasInfinity => false;
            bool INumericStatic<Int64N>.HasNaN => false;
            bool INumericStatic<Int64N>.IsFinite(Int64N x) => true;
            bool INumericStatic<Int64N>.IsInfinity(Int64N x) => false;
            bool INumericStatic<Int64N>.IsNaN(Int64N x) => false;
            bool INumericStatic<Int64N>.IsNegative(Int64N x) => x._value < 0;
            bool INumericStatic<Int64N>.IsNegativeInfinity(Int64N x) => false;
            bool INumericStatic<Int64N>.IsNormal(Int64N x) => false;
            bool INumericStatic<Int64N>.IsPositiveInfinity(Int64N x) => false;
            bool INumericStatic<Int64N>.IsReal => false;
            bool INumericStatic<Int64N>.IsSigned => true;
            bool INumericStatic<Int64N>.IsSubnormal(Int64N x) => false;
            Int64N INumericStatic<Int64N>.Epsilon => 1L;
            Int64N INumericStatic<Int64N>.MaxUnit => 1L;
            Int64N INumericStatic<Int64N>.MaxValue => MaxValue;
            Int64N INumericStatic<Int64N>.MinUnit => -1L;
            Int64N INumericStatic<Int64N>.MinValue => MinValue;
            Int64N INumericStatic<Int64N>.One => 1L;
            Int64N INumericStatic<Int64N>.Ten => 10L;
            Int64N INumericStatic<Int64N>.Two => 2L;
            Int64N INumericStatic<Int64N>.Zero => 0;

            int IMath<Int64N>.Sign(Int64N x) => Math.Sign(x._value);
            Int64N IMath<Int64N>.Abs(Int64N value) => Math.Abs(value);
            Int64N IMath<Int64N>.Acos(Int64N x) => (Int64N)Math.Acos(x);
            Int64N IMath<Int64N>.Acosh(Int64N x) => (Int64N)MathCompat.Acosh(x);
            Int64N IMath<Int64N>.Asin(Int64N x) => (Int64N)Math.Asin(x);
            Int64N IMath<Int64N>.Asinh(Int64N x) => (Int64N)MathCompat.Asinh(x);
            Int64N IMath<Int64N>.Atan(Int64N x) => (Int64N)Math.Atan(x);
            Int64N IMath<Int64N>.Atan2(Int64N y, Int64N x) => (Int64N)Math.Atan2(y, x);
            Int64N IMath<Int64N>.Atanh(Int64N x) => (Int64N)MathCompat.Atanh(x);
            Int64N IMath<Int64N>.Cbrt(Int64N x) => (Int64N)MathCompat.Cbrt(x);
            Int64N IMath<Int64N>.Ceiling(Int64N x) => x;
            Int64N IMath<Int64N>.Clamp(Int64N x, Int64N bound1, Int64N bound2) => bound1 > bound2 ? Math.Min(bound1, Math.Max(bound2, x)) : Math.Min(bound2, Math.Max(bound1, x));
            Int64N IMath<Int64N>.Cos(Int64N x) => (Int64N)Math.Cos(x);
            Int64N IMath<Int64N>.Cosh(Int64N x) => (Int64N)Math.Cosh(x);
            Int64N IMath<Int64N>.DegreesToRadians(Int64N x) => (Int64N)(x * BitOperations.RadiansPerDegree);
            Int64N IMath<Int64N>.E { get; } = 2L;
            Int64N IMath<Int64N>.Exp(Int64N x) => (Int64N)Math.Exp(x);
            Int64N IMath<Int64N>.Floor(Int64N x) => x;
            Int64N IMath<Int64N>.IEEERemainder(Int64N x, Int64N y) => (Int64N)Math.IEEERemainder(x, y);
            Int64N IMath<Int64N>.Log(Int64N x) => (Int64N)Math.Log(x);
            Int64N IMath<Int64N>.Log(Int64N x, Int64N y) => (Int64N)Math.Log(x, y);
            Int64N IMath<Int64N>.Log10(Int64N x) => (Int64N)Math.Log10(x);
            Int64N IMath<Int64N>.Max(Int64N x, Int64N y) => Math.Max(x, y);
            Int64N IMath<Int64N>.Min(Int64N x, Int64N y) => Math.Min(x, y);
            Int64N IMath<Int64N>.PI { get; } = 3L;
            Int64N IMath<Int64N>.Pow(Int64N x, Int64N y) => y == 1 ? x : (Int64N)Math.Pow(x, y);
            Int64N IMath<Int64N>.RadiansToDegrees(Int64N x) => (Int64N)(x * BitOperations.DegreesPerRadian);
            Int64N IMath<Int64N>.Round(Int64N x) => x;
            Int64N IMath<Int64N>.Round(Int64N x, int digits) => x;
            Int64N IMath<Int64N>.Round(Int64N x, int digits, MidpointRounding mode) => x;
            Int64N IMath<Int64N>.Round(Int64N x, MidpointRounding mode) => x;
            Int64N IMath<Int64N>.Sin(Int64N x) => (Int64N)Math.Sin(x);
            Int64N IMath<Int64N>.Sinh(Int64N x) => (Int64N)Math.Sinh(x);
            Int64N IMath<Int64N>.Sqrt(Int64N x) => (Int64N)Math.Sqrt(x);
            Int64N IMath<Int64N>.Tan(Int64N x) => (Int64N)Math.Tan(x);
            Int64N IMath<Int64N>.Tanh(Int64N x) => (Int64N)Math.Tanh(x);
            Int64N IMath<Int64N>.Tau { get; } = 6L;
            Int64N IMath<Int64N>.Truncate(Int64N x) => x;

            int INumericBitConverter<Int64N>.ConvertedSize => sizeof(long);
            Int64N INumericBitConverter<Int64N>.ToNumeric(byte[] value, int startIndex) => BitConverter.ToInt64(value, startIndex);
            byte[] INumericBitConverter<Int64N>.GetBytes(Int64N value) => BitConverter.GetBytes(value._value);

            bool IConvert<Int64N>.ToBoolean(Int64N value) => Convert.ToBoolean(value._value);
            byte IConvert<Int64N>.ToByte(Int64N value, Conversion mode) => ConvertN.ToByte(value._value, mode);
            decimal IConvert<Int64N>.ToDecimal(Int64N value, Conversion mode) => ConvertN.ToDecimal(value._value, mode);
            double IConvert<Int64N>.ToDouble(Int64N value, Conversion mode) => ConvertN.ToDouble(value._value, mode);
            float IConvert<Int64N>.ToSingle(Int64N value, Conversion mode) => ConvertN.ToSingle(value._value, mode);
            int IConvert<Int64N>.ToInt32(Int64N value, Conversion mode) => ConvertN.ToInt32(value._value, mode);
            long IConvert<Int64N>.ToInt64(Int64N value, Conversion mode) => value._value;
            sbyte IConvertExtended<Int64N>.ToSByte(Int64N value, Conversion mode) => ConvertN.ToSByte(value._value, mode);
            short IConvert<Int64N>.ToInt16(Int64N value, Conversion mode) => ConvertN.ToInt16(value._value, mode);
            string IConvert<Int64N>.ToString(Int64N value) => Convert.ToString(value._value);
            uint IConvertExtended<Int64N>.ToUInt32(Int64N value, Conversion mode) => ConvertN.ToUInt32(value._value, mode);
            ulong IConvertExtended<Int64N>.ToUInt64(Int64N value, Conversion mode) => ConvertN.ToUInt64(value._value, mode);
            ushort IConvertExtended<Int64N>.ToUInt16(Int64N value, Conversion mode) => ConvertN.ToUInt16(value._value, mode);

            Int64N IConvert<Int64N>.ToNumeric(bool value) => Convert.ToInt64(value);
            Int64N IConvert<Int64N>.ToNumeric(byte value, Conversion mode) => ConvertN.ToInt64(value, mode);
            Int64N IConvert<Int64N>.ToNumeric(decimal value, Conversion mode) => ConvertN.ToInt64(value, mode);
            Int64N IConvert<Int64N>.ToNumeric(double value, Conversion mode) => ConvertN.ToInt64(value, mode);
            Int64N IConvert<Int64N>.ToNumeric(float value, Conversion mode) => ConvertN.ToInt64(value, mode);
            Int64N IConvert<Int64N>.ToNumeric(int value, Conversion mode) => ConvertN.ToInt64(value, mode);
            Int64N IConvert<Int64N>.ToNumeric(long value, Conversion mode) => value;
            Int64N IConvertExtended<Int64N>.ToValue(sbyte value, Conversion mode) => ConvertN.ToInt64(value, mode);
            Int64N IConvert<Int64N>.ToNumeric(short value, Conversion mode) => ConvertN.ToInt64(value, mode);
            Int64N IConvert<Int64N>.ToNumeric(string value) => Convert.ToInt64(value);
            Int64N IConvertExtended<Int64N>.ToNumeric(uint value, Conversion mode) => ConvertN.ToInt64(value, mode);
            Int64N IConvertExtended<Int64N>.ToNumeric(ulong value, Conversion mode) => ConvertN.ToInt64(value, mode);
            Int64N IConvertExtended<Int64N>.ToNumeric(ushort value, Conversion mode) => ConvertN.ToInt64(value, mode);

            Int64N INumericStatic<Int64N>.Parse(string s, NumberStyles? style, IFormatProvider? provider)
                => Parse(s, style ?? NumberStyles.Integer, provider);

            Int64N INumericRandom<Int64N>.Next(Random random) => random.NextInt64();
            Int64N INumericRandom<Int64N>.Next(Random random, Int64N maxValue) => random.NextInt64(maxValue);
            Int64N INumericRandom<Int64N>.Next(Random random, Int64N minValue, Int64N maxValue) => random.NextInt64(minValue, maxValue);
            Int64N INumericRandom<Int64N>.Next(Random random, Generation mode) => random.NextInt64(mode);
            Int64N INumericRandom<Int64N>.Next(Random random, Int64N minValue, Int64N maxValue, Generation mode) => random.NextInt64(minValue, maxValue, mode);

            Int64N IVariantRandom<Int64N>.Next(Random random, Scenarios scenarios) => NumericVariant.Generate<Int64N>(random, scenarios);
        }
    }
}
