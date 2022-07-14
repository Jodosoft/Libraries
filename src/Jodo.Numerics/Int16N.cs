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
    /// Represents a 16-bit signed integer.
    /// </summary>
    [Serializable]
    [DebuggerDisplay("{ToString(),nq}")]
    public readonly struct Int16N : INumericNonCLS<Int16N>
    {
        public static readonly Int16N MaxValue = new Int16N(short.MaxValue);
        public static readonly Int16N MinValue = new Int16N(short.MinValue);

        private readonly short _value;

        private Int16N(short value)
        {
            _value = value;
        }

        private Int16N(SerializationInfo info, StreamingContext context) : this(info.GetInt16(nameof(Int16N))) { }
        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context) => info.AddValue(nameof(Int16N), _value);

        public int CompareTo(Int16N other) => _value.CompareTo(other._value);
        public int CompareTo(object? obj) => obj is Int16N other ? CompareTo(other) : 1;
        public bool Equals(Int16N other) => _value == other._value;
        public override bool Equals(object? obj) => obj is Int16N other && Equals(other);
        public override int GetHashCode() => _value.GetHashCode();
        public override string ToString() => _value.ToString();
        public string ToString(IFormatProvider formatProvider) => _value.ToString(formatProvider);
        public string ToString(string format) => _value.ToString(format);
        public string ToString(string? format, IFormatProvider? formatProvider) => _value.ToString(format, formatProvider);

        public static bool TryParse(string s, IFormatProvider? provider, out Int16N result) => Try.Run(() => Parse(s, provider), out result);
        public static bool TryParse(string s, NumberStyles style, IFormatProvider? provider, out Int16N result) => Try.Run(() => Parse(s, style, provider), out result);
        public static bool TryParse(string s, NumberStyles style, out Int16N result) => Try.Run(() => Parse(s, style), out result);
        public static bool TryParse(string s, out Int16N result) => Try.Run(() => Parse(s), out result);
        public static Int16N Parse(string s) => short.Parse(s);
        public static Int16N Parse(string s, IFormatProvider? provider) => short.Parse(s, provider);
        public static Int16N Parse(string s, NumberStyles style) => short.Parse(s, style);
        public static Int16N Parse(string s, NumberStyles style, IFormatProvider? provider) => short.Parse(s, style, provider);

        [CLSCompliant(false)] public static explicit operator Int16N(uint value) => new Int16N((short)value);
        [CLSCompliant(false)] public static explicit operator Int16N(ulong value) => new Int16N((short)value);
        [CLSCompliant(false)] public static explicit operator Int16N(ushort value) => new Int16N((short)value);
        [CLSCompliant(false)] public static implicit operator Int16N(sbyte value) => new Int16N(value);
        public static explicit operator Int16N(decimal value) => new Int16N((short)value);
        public static explicit operator Int16N(double value) => new Int16N((short)value);
        public static explicit operator Int16N(float value) => new Int16N((short)value);
        public static explicit operator Int16N(int value) => new Int16N((short)value);
        public static explicit operator Int16N(long value) => new Int16N((short)value);
        public static implicit operator Int16N(byte value) => new Int16N(value);
        public static implicit operator Int16N(short value) => new Int16N(value);

        [CLSCompliant(false)] public static explicit operator sbyte(Int16N value) => (sbyte)value._value;
        [CLSCompliant(false)] public static explicit operator uint(Int16N value) => (uint)value._value;
        [CLSCompliant(false)] public static explicit operator ulong(Int16N value) => (ulong)value._value;
        [CLSCompliant(false)] public static explicit operator ushort(Int16N value) => (ushort)value._value;
        public static explicit operator byte(Int16N value) => (byte)value._value;
        public static implicit operator decimal(Int16N value) => value._value;
        public static implicit operator double(Int16N value) => value._value;
        public static implicit operator float(Int16N value) => value._value;
        public static implicit operator int(Int16N value) => value._value;
        public static implicit operator long(Int16N value) => value._value;
        public static implicit operator short(Int16N value) => value._value;

        public static bool operator !=(Int16N left, Int16N right) => left._value != right._value;
        public static bool operator <(Int16N left, Int16N right) => left._value < right._value;
        public static bool operator <=(Int16N left, Int16N right) => left._value <= right._value;
        public static bool operator ==(Int16N left, Int16N right) => left._value == right._value;
        public static bool operator >(Int16N left, Int16N right) => left._value > right._value;
        public static bool operator >=(Int16N left, Int16N right) => left._value >= right._value;
        public static Int16N operator %(Int16N left, Int16N right) => (short)(left._value % right._value);
        public static Int16N operator &(Int16N left, Int16N right) => (short)(left._value & right._value);
        public static Int16N operator -(Int16N left, Int16N right) => (short)(left._value - right._value);
        public static Int16N operator --(Int16N value) => (short)(value._value - 1);
        public static Int16N operator -(Int16N value) => (short)-value._value;
        public static Int16N operator *(Int16N left, Int16N right) => (short)(left._value * right._value);
        public static Int16N operator /(Int16N left, Int16N right) => (short)(left._value / right._value);
        public static Int16N operator ^(Int16N left, Int16N right) => (short)(left._value ^ right._value);
        public static Int16N operator |(Int16N left, Int16N right) => (short)(left._value | right._value);
        public static Int16N operator ~(Int16N value) => (short)~value._value;
        public static Int16N operator +(Int16N left, Int16N right) => (short)(left._value + right._value);
        public static Int16N operator +(Int16N value) => value;
        public static Int16N operator ++(Int16N value) => (short)(value._value + 1);
        public static Int16N operator <<(Int16N left, int right) => (short)(left._value << right);
        public static Int16N operator >>(Int16N left, int right) => (short)(left._value >> right);

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

        bool INumeric<Int16N>.IsGreaterThan(Int16N value) => this > value;
        bool INumeric<Int16N>.IsGreaterThanOrEqualTo(Int16N value) => this >= value;
        bool INumeric<Int16N>.IsLessThan(Int16N value) => this < value;
        bool INumeric<Int16N>.IsLessThanOrEqualTo(Int16N value) => this <= value;
        Int16N INumeric<Int16N>.Add(Int16N value) => this + value;
        Int16N INumeric<Int16N>.BitwiseComplement() => ~this;
        Int16N INumeric<Int16N>.Divide(Int16N value) => this / value;
        Int16N INumeric<Int16N>.LeftShift(int count) => this << count;
        Int16N INumeric<Int16N>.LogicalAnd(Int16N value) => this & value;
        Int16N INumeric<Int16N>.LogicalExclusiveOr(Int16N value) => this ^ value;
        Int16N INumeric<Int16N>.LogicalOr(Int16N value) => this | value;
        Int16N INumeric<Int16N>.Multiply(Int16N value) => this * value;
        Int16N INumeric<Int16N>.Negative() => -this;
        Int16N INumeric<Int16N>.Positive() => +this;
        Int16N INumeric<Int16N>.Remainder(Int16N value) => this % value;
        Int16N INumeric<Int16N>.RightShift(int count) => this >> count;
        Int16N INumeric<Int16N>.Subtract(Int16N value) => this - value;

        IBitConverter<Int16N> IProvider<IBitConverter<Int16N>>.GetInstance() => Utilities.Instance;
        IConvert<Int16N> IProvider<IConvert<Int16N>>.GetInstance() => Utilities.Instance;
        IConvertNonCLS<Int16N> IProvider<IConvertNonCLS<Int16N>>.GetInstance() => Utilities.Instance;
        IMath<Int16N> IProvider<IMath<Int16N>>.GetInstance() => Utilities.Instance;
        INumericStatic<Int16N> IProvider<INumericStatic<Int16N>>.GetInstance() => Utilities.Instance;
        IRandom<Int16N> IProvider<IRandom<Int16N>>.GetInstance() => Utilities.Instance;
        IParser<Int16N> IProvider<IParser<Int16N>>.GetInstance() => Utilities.Instance;

        private sealed class Utilities :
            IBitConverter<Int16N>,
            IConvert<Int16N>,
            IConvertNonCLS<Int16N>,
            IMath<Int16N>,
            INumericStatic<Int16N>,
            IRandom<Int16N>,
            IParser<Int16N>
        {
            public static readonly Utilities Instance = new Utilities();

            bool INumericStatic<Int16N>.HasFloatingPoint { get; } = false;
            bool INumericStatic<Int16N>.HasInfinity { get; } = false;
            bool INumericStatic<Int16N>.HasNaN { get; } = false;
            bool INumericStatic<Int16N>.IsFinite(Int16N x) => true;
            bool INumericStatic<Int16N>.IsInfinity(Int16N x) => false;
            bool INumericStatic<Int16N>.IsNaN(Int16N x) => false;
            bool INumericStatic<Int16N>.IsNegative(Int16N x) => x._value < 0;
            bool INumericStatic<Int16N>.IsNegativeInfinity(Int16N x) => false;
            bool INumericStatic<Int16N>.IsNormal(Int16N x) => false;
            bool INumericStatic<Int16N>.IsPositiveInfinity(Int16N x) => false;
            bool INumericStatic<Int16N>.IsReal { get; } = false;
            bool INumericStatic<Int16N>.IsSigned { get; } = true;
            bool INumericStatic<Int16N>.IsSubnormal(Int16N x) => false;
            Int16N INumericStatic<Int16N>.Epsilon { get; } = (short)1;
            Int16N INumericStatic<Int16N>.MaxUnit { get; } = (short)1;
            Int16N INumericStatic<Int16N>.MaxValue => MaxValue;
            Int16N INumericStatic<Int16N>.MinUnit { get; } = (short)-1;
            Int16N INumericStatic<Int16N>.MinValue => MinValue;
            Int16N INumericStatic<Int16N>.One { get; } = (short)1;
            Int16N INumericStatic<Int16N>.Ten { get; } = (short)10;
            Int16N INumericStatic<Int16N>.Two { get; } = (short)2;
            Int16N INumericStatic<Int16N>.Zero { get; } = (short)0;

            int IMath<Int16N>.Sign(Int16N x) => Math.Sign(x._value);
            Int16N IMath<Int16N>.Abs(Int16N value) => Math.Abs(value._value);
            Int16N IMath<Int16N>.Acos(Int16N x) => (short)Math.Acos(x._value);
            Int16N IMath<Int16N>.Acosh(Int16N x) => (short)MathCompat.Acosh(x._value);
            Int16N IMath<Int16N>.Asin(Int16N x) => (short)Math.Asin(x._value);
            Int16N IMath<Int16N>.Asinh(Int16N x) => (short)MathCompat.Asinh(x._value);
            Int16N IMath<Int16N>.Atan(Int16N x) => (short)Math.Atan(x._value);
            Int16N IMath<Int16N>.Atan2(Int16N x, Int16N y) => (short)Math.Atan2(x._value, y._value);
            Int16N IMath<Int16N>.Atanh(Int16N x) => (short)MathCompat.Atanh(x._value);
            Int16N IMath<Int16N>.Cbrt(Int16N x) => (short)MathCompat.Cbrt(x._value);
            Int16N IMath<Int16N>.Ceiling(Int16N x) => x;
            Int16N IMath<Int16N>.Clamp(Int16N x, Int16N bound1, Int16N bound2) => bound1 > bound2 ? Math.Min(bound1._value, Math.Max(bound2._value, x._value)) : Math.Min(bound2._value, Math.Max(bound1._value, x._value));
            Int16N IMath<Int16N>.Cos(Int16N x) => (short)Math.Cos(x._value);
            Int16N IMath<Int16N>.Cosh(Int16N x) => (short)Math.Cosh(x._value);
            Int16N IMath<Int16N>.DegreesToRadians(Int16N x) => (short)(x * NumericUtilities.RadiansPerDegree);
            Int16N IMath<Int16N>.E { get; } = (short)2;
            Int16N IMath<Int16N>.Exp(Int16N x) => (short)Math.Exp(x._value);
            Int16N IMath<Int16N>.Floor(Int16N x) => x;
            Int16N IMath<Int16N>.IEEERemainder(Int16N x, Int16N y) => (short)Math.IEEERemainder(x._value, y._value);
            Int16N IMath<Int16N>.Log(Int16N x) => (short)Math.Log(x._value);
            Int16N IMath<Int16N>.Log(Int16N x, Int16N y) => (short)Math.Log(x._value, y._value);
            Int16N IMath<Int16N>.Log10(Int16N x) => (short)Math.Log10(x._value);
            Int16N IMath<Int16N>.Max(Int16N x, Int16N y) => Math.Max(x._value, y._value);
            Int16N IMath<Int16N>.Min(Int16N x, Int16N y) => Math.Min(x._value, y._value);
            Int16N IMath<Int16N>.PI { get; } = (short)3;
            Int16N IMath<Int16N>.Pow(Int16N x, Int16N y) => (short)Math.Pow(x._value, y._value);
            Int16N IMath<Int16N>.RadiansToDegrees(Int16N x) => (short)(x * NumericUtilities.DegreesPerRadian);
            Int16N IMath<Int16N>.Round(Int16N x) => x;
            Int16N IMath<Int16N>.Round(Int16N x, int digits) => x;
            Int16N IMath<Int16N>.Round(Int16N x, int digits, MidpointRounding mode) => x;
            Int16N IMath<Int16N>.Round(Int16N x, MidpointRounding mode) => x;
            Int16N IMath<Int16N>.Sin(Int16N x) => (short)Math.Sin(x._value);
            Int16N IMath<Int16N>.Sinh(Int16N x) => (short)Math.Sinh(x._value);
            Int16N IMath<Int16N>.Sqrt(Int16N x) => (short)Math.Sqrt(x._value);
            Int16N IMath<Int16N>.Tan(Int16N x) => (short)Math.Tan(x._value);
            Int16N IMath<Int16N>.Tanh(Int16N x) => (short)Math.Tanh(x._value);
            Int16N IMath<Int16N>.Tau { get; } = (short)6;
            Int16N IMath<Int16N>.Truncate(Int16N x) => x;

            Int16N IBitConverter<Int16N>.Read(IReadOnlyStream<byte> stream) => BitConverter.ToInt16(stream.Read(sizeof(short)), 0);
            void IBitConverter<Int16N>.Write(Int16N value, IWriteOnlyStream<byte> stream) => stream.Write(BitConverter.GetBytes(value._value));

            Int16N IRandom<Int16N>.Next(Random random) => random.NextInt16();
            Int16N IRandom<Int16N>.Next(Random random, Int16N bound1, Int16N bound2) => random.NextInt16(bound1._value, bound2._value);

            bool IConvert<Int16N>.ToBoolean(Int16N value) => Convert.ToBoolean(value._value);
            byte IConvert<Int16N>.ToByte(Int16N value, Conversion mode) => NumericConvert.ToByte(value._value, mode);
            decimal IConvert<Int16N>.ToDecimal(Int16N value, Conversion mode) => NumericConvert.ToDecimal(value._value, mode);
            double IConvert<Int16N>.ToDouble(Int16N value, Conversion mode) => NumericConvert.ToDouble(value._value, mode);
            float IConvert<Int16N>.ToSingle(Int16N value, Conversion mode) => NumericConvert.ToSingle(value._value, mode);
            int IConvert<Int16N>.ToInt32(Int16N value, Conversion mode) => NumericConvert.ToInt32(value._value, mode);
            long IConvert<Int16N>.ToInt64(Int16N value, Conversion mode) => NumericConvert.ToInt64(value._value, mode);
            sbyte IConvertNonCLS<Int16N>.ToSByte(Int16N value, Conversion mode) => NumericConvert.ToSByte(value._value, mode);
            short IConvert<Int16N>.ToInt16(Int16N value, Conversion mode) => NumericConvert.ToInt16(value._value, mode);
            string IConvert<Int16N>.ToString(Int16N value) => Convert.ToString(value._value);
            uint IConvertNonCLS<Int16N>.ToUInt32(Int16N value, Conversion mode) => NumericConvert.ToUInt32(value._value, mode);
            ulong IConvertNonCLS<Int16N>.ToUInt64(Int16N value, Conversion mode) => NumericConvert.ToUInt64(value._value, mode);
            ushort IConvertNonCLS<Int16N>.ToUInt16(Int16N value, Conversion mode) => NumericConvert.ToUInt16(value._value, mode);

            Int16N IConvert<Int16N>.ToNumeric(bool value) => Convert.ToInt16(value);
            Int16N IConvert<Int16N>.ToNumeric(byte value, Conversion mode) => NumericConvert.ToInt16(value, mode);
            Int16N IConvert<Int16N>.ToNumeric(decimal value, Conversion mode) => NumericConvert.ToInt16(value, mode);
            Int16N IConvert<Int16N>.ToNumeric(double value, Conversion mode) => NumericConvert.ToInt16(value, mode);
            Int16N IConvert<Int16N>.ToNumeric(float value, Conversion mode) => NumericConvert.ToInt16(value, mode);
            Int16N IConvert<Int16N>.ToNumeric(int value, Conversion mode) => NumericConvert.ToInt16(value, mode);
            Int16N IConvert<Int16N>.ToNumeric(long value, Conversion mode) => NumericConvert.ToInt16(value, mode);
            Int16N IConvertNonCLS<Int16N>.ToValue(sbyte value, Conversion mode) => NumericConvert.ToInt16(value, mode);
            Int16N IConvert<Int16N>.ToNumeric(short value, Conversion mode) => NumericConvert.ToInt16(value, mode);
            Int16N IConvert<Int16N>.ToNumeric(string value) => Convert.ToInt16(value);
            Int16N IConvertNonCLS<Int16N>.ToNumeric(uint value, Conversion mode) => NumericConvert.ToInt16(value, mode);
            Int16N IConvertNonCLS<Int16N>.ToNumeric(ulong value, Conversion mode) => NumericConvert.ToInt16(value, mode);
            Int16N IConvertNonCLS<Int16N>.ToNumeric(ushort value, Conversion mode) => NumericConvert.ToInt16(value, mode);

            Int16N IParser<Int16N>.Parse(string s) => Parse(s);
            Int16N IParser<Int16N>.Parse(string s, NumberStyles style, IFormatProvider? provider) => Parse(s, style, provider);
        }
    }
}
