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
    /// Represents a 32-bit signed integer.
    /// </summary>
    [Serializable]
    [DebuggerDisplay("{ToString(),nq}")]
    public readonly struct Int32N : INumericExtended<Int32N>
    {
        public static readonly Int32N MaxValue = new Int32N(int.MaxValue);
        public static readonly Int32N MinValue = new Int32N(int.MinValue);

        private readonly int _value;

        private Int32N(int value)
        {
            _value = value;
        }

        private Int32N(SerializationInfo info, StreamingContext context) : this(info.GetInt32(nameof(Int32N))) { }
        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context) => info.AddValue(nameof(Int32N), _value);

        public int CompareTo(Int32N other) => _value.CompareTo(other._value);
        public int CompareTo(object? obj) => obj is Int32N other ? CompareTo(other) : 1;
        public bool Equals(Int32N other) => _value == other._value;
        public override bool Equals(object? obj) => obj is Int32N other && Equals(other);
        public override int GetHashCode() => _value.GetHashCode();
        public override string ToString() => _value.ToString();
        public string ToString(IFormatProvider formatProvider) => _value.ToString(formatProvider);
        public string ToString(string format) => _value.ToString(format);
        public string ToString(string? format, IFormatProvider? formatProvider) => _value.ToString(format, formatProvider);

        public static bool TryParse(string s, IFormatProvider? provider, out Int32N result) => Try.Run(() => Parse(s, provider), out result);
        public static bool TryParse(string s, NumberStyles style, IFormatProvider? provider, out Int32N result) => Try.Run(() => Parse(s, style, provider), out result);
        public static bool TryParse(string s, NumberStyles style, out Int32N result) => Try.Run(() => Parse(s, style), out result);
        public static bool TryParse(string s, out Int32N result) => Try.Run(() => Parse(s), out result);
        public static Int32N Parse(string s) => int.Parse(s);
        public static Int32N Parse(string s, IFormatProvider? provider) => int.Parse(s, provider);
        public static Int32N Parse(string s, NumberStyles style) => int.Parse(s, style);
        public static Int32N Parse(string s, NumberStyles style, IFormatProvider? provider) => int.Parse(s, style, provider);

        [CLSCompliant(false)] public static explicit operator Int32N(uint value) => new Int32N((int)value);
        [CLSCompliant(false)] public static explicit operator Int32N(ulong value) => new Int32N((int)value);
        [CLSCompliant(false)] public static implicit operator Int32N(sbyte value) => new Int32N(value);
        [CLSCompliant(false)] public static implicit operator Int32N(ushort value) => new Int32N(value);
        public static explicit operator Int32N(decimal value) => new Int32N((int)value);
        public static explicit operator Int32N(double value) => new Int32N((int)value);
        public static explicit operator Int32N(float value) => new Int32N((int)value);
        public static explicit operator Int32N(long value) => new Int32N((int)value);
        public static implicit operator Int32N(byte value) => new Int32N(value);
        public static implicit operator Int32N(int value) => new Int32N(value);
        public static implicit operator Int32N(short value) => new Int32N(value);

        [CLSCompliant(false)] public static explicit operator sbyte(Int32N value) => (sbyte)value._value;
        [CLSCompliant(false)] public static explicit operator uint(Int32N value) => (uint)value._value;
        [CLSCompliant(false)] public static explicit operator ulong(Int32N value) => (ulong)value._value;
        [CLSCompliant(false)] public static explicit operator ushort(Int32N value) => (ushort)value._value;
        public static explicit operator byte(Int32N value) => (byte)value._value;
        public static explicit operator short(Int32N value) => (short)value._value;
        public static implicit operator decimal(Int32N value) => value._value;
        public static implicit operator double(Int32N value) => value._value;
        public static implicit operator float(Int32N value) => value._value;
        public static implicit operator int(Int32N value) => value._value;
        public static implicit operator long(Int32N value) => value._value;

        public static bool operator !=(Int32N left, Int32N right) => left._value != right._value;
        public static bool operator <(Int32N left, Int32N right) => left._value < right._value;
        public static bool operator <=(Int32N left, Int32N right) => left._value <= right._value;
        public static bool operator ==(Int32N left, Int32N right) => left._value == right._value;
        public static bool operator >(Int32N left, Int32N right) => left._value > right._value;
        public static bool operator >=(Int32N left, Int32N right) => left._value >= right._value;
        public static Int32N operator %(Int32N left, Int32N right) => left._value % right._value;
        public static Int32N operator &(Int32N left, Int32N right) => left._value & right._value;
        public static Int32N operator -(Int32N left, Int32N right) => left._value - right._value;
        public static Int32N operator --(Int32N value) => value._value - 1;
        public static Int32N operator -(Int32N value) => -value._value;
        public static Int32N operator *(Int32N left, Int32N right) => left._value * right._value;
        public static Int32N operator /(Int32N left, Int32N right) => left._value / right._value;
        public static Int32N operator ^(Int32N left, Int32N right) => left._value ^ right._value;
        public static Int32N operator |(Int32N left, Int32N right) => left._value | right._value;
        public static Int32N operator ~(Int32N value) => ~value._value;
        public static Int32N operator +(Int32N left, Int32N right) => left._value + right._value;
        public static Int32N operator +(Int32N value) => value;
        public static Int32N operator ++(Int32N value) => value._value + 1;
        public static Int32N operator <<(Int32N left, int right) => left._value << right;
        public static Int32N operator >>(Int32N left, int right) => left._value >> right;

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

        bool INumeric<Int32N>.IsGreaterThan(Int32N value) => this > value;
        bool INumeric<Int32N>.IsGreaterThanOrEqualTo(Int32N value) => this >= value;
        bool INumeric<Int32N>.IsLessThan(Int32N value) => this < value;
        bool INumeric<Int32N>.IsLessThanOrEqualTo(Int32N value) => this <= value;
        Int32N INumeric<Int32N>.Add(Int32N value) => this + value;
        Int32N INumeric<Int32N>.BitwiseComplement() => ~this;
        Int32N INumeric<Int32N>.Divide(Int32N value) => this / value;
        Int32N INumeric<Int32N>.LeftShift(int count) => this << count;
        Int32N INumeric<Int32N>.LogicalAnd(Int32N value) => this & value;
        Int32N INumeric<Int32N>.LogicalExclusiveOr(Int32N value) => this ^ value;
        Int32N INumeric<Int32N>.LogicalOr(Int32N value) => this | value;
        Int32N INumeric<Int32N>.Multiply(Int32N value) => this * value;
        Int32N INumeric<Int32N>.Negative() => -this;
        Int32N INumeric<Int32N>.Positive() => +this;
        Int32N INumeric<Int32N>.Remainder(Int32N value) => this % value;
        Int32N INumeric<Int32N>.RightShift(int count) => this >> count;
        Int32N INumeric<Int32N>.Subtract(Int32N value) => this - value;

        IBitConverter<Int32N> IProvider<IBitConverter<Int32N>>.GetInstance() => Utilities.Instance;
        IConvert<Int32N> IProvider<IConvert<Int32N>>.GetInstance() => Utilities.Instance;
        IConvertExtended<Int32N> IProvider<IConvertExtended<Int32N>>.GetInstance() => Utilities.Instance;
        IMath<Int32N> IProvider<IMath<Int32N>>.GetInstance() => Utilities.Instance;
        INumericStatic<Int32N> IProvider<INumericStatic<Int32N>>.GetInstance() => Utilities.Instance;
        IRandom<Int32N> IProvider<IRandom<Int32N>>.GetInstance() => Utilities.Instance;
        IParser<Int32N> IProvider<IParser<Int32N>>.GetInstance() => Utilities.Instance;

        private sealed class Utilities :
            IBitConverter<Int32N>,
            IConvert<Int32N>,
            IConvertExtended<Int32N>,
            IMath<Int32N>,
            INumericStatic<Int32N>,
            IRandom<Int32N>,
            IParser<Int32N>
        {
            public static readonly Utilities Instance = new Utilities();

            bool INumericStatic<Int32N>.HasFloatingPoint { get; } = false;
            bool INumericStatic<Int32N>.HasInfinity { get; } = false;
            bool INumericStatic<Int32N>.HasNaN { get; } = false;
            bool INumericStatic<Int32N>.IsFinite(Int32N x) => true;
            bool INumericStatic<Int32N>.IsInfinity(Int32N x) => false;
            bool INumericStatic<Int32N>.IsNaN(Int32N x) => false;
            bool INumericStatic<Int32N>.IsNegative(Int32N x) => x._value < 0;
            bool INumericStatic<Int32N>.IsNegativeInfinity(Int32N x) => false;
            bool INumericStatic<Int32N>.IsNormal(Int32N x) => false;
            bool INumericStatic<Int32N>.IsPositiveInfinity(Int32N x) => false;
            bool INumericStatic<Int32N>.IsReal { get; } = false;
            bool INumericStatic<Int32N>.IsSigned { get; } = true;
            bool INumericStatic<Int32N>.IsSubnormal(Int32N x) => false;
            Int32N INumericStatic<Int32N>.Epsilon { get; } = 1;
            Int32N INumericStatic<Int32N>.MaxUnit { get; } = 1;
            Int32N INumericStatic<Int32N>.MaxValue => MaxValue;
            Int32N INumericStatic<Int32N>.MinUnit { get; } = -1;
            Int32N INumericStatic<Int32N>.MinValue => MinValue;
            Int32N INumericStatic<Int32N>.One { get; } = 1;
            Int32N INumericStatic<Int32N>.Ten { get; } = 10;
            Int32N INumericStatic<Int32N>.Two { get; } = 2;
            Int32N INumericStatic<Int32N>.Zero { get; } = 0;

            int IMath<Int32N>.Sign(Int32N x) => Math.Sign(x._value);
            Int32N IMath<Int32N>.Abs(Int32N value) => Math.Abs(value._value);
            Int32N IMath<Int32N>.Acos(Int32N x) => (int)Math.Acos(x._value);
            Int32N IMath<Int32N>.Acosh(Int32N x) => (int)MathCompat.Acosh(x._value);
            Int32N IMath<Int32N>.Asin(Int32N x) => (int)Math.Asin(x._value);
            Int32N IMath<Int32N>.Asinh(Int32N x) => (int)MathCompat.Asinh(x._value);
            Int32N IMath<Int32N>.Atan(Int32N x) => (int)Math.Atan(x._value);
            Int32N IMath<Int32N>.Atan2(Int32N x, Int32N y) => (int)Math.Atan2(x._value, y._value);
            Int32N IMath<Int32N>.Atanh(Int32N x) => (int)MathCompat.Atanh(x._value);
            Int32N IMath<Int32N>.Cbrt(Int32N x) => (int)MathCompat.Cbrt(x._value);
            Int32N IMath<Int32N>.Ceiling(Int32N x) => x;
            Int32N IMath<Int32N>.Clamp(Int32N x, Int32N bound1, Int32N bound2) => bound1 > bound2 ? Math.Min(bound1._value, Math.Max(bound2._value, x._value)) : Math.Min(bound2._value, Math.Max(bound1._value, x._value));
            Int32N IMath<Int32N>.Cos(Int32N x) => (int)Math.Cos(x._value);
            Int32N IMath<Int32N>.Cosh(Int32N x) => (int)Math.Cosh(x._value);
            Int32N IMath<Int32N>.DegreesToRadians(Int32N x) => (int)(x * NumericUtilities.RadiansPerDegree);
            Int32N IMath<Int32N>.E { get; } = 2;
            Int32N IMath<Int32N>.Exp(Int32N x) => (int)Math.Exp(x._value);
            Int32N IMath<Int32N>.Floor(Int32N x) => x;
            Int32N IMath<Int32N>.IEEERemainder(Int32N x, Int32N y) => (int)Math.IEEERemainder(x._value, y._value);
            Int32N IMath<Int32N>.Log(Int32N x) => (int)Math.Log(x._value);
            Int32N IMath<Int32N>.Log(Int32N x, Int32N y) => (int)Math.Log(x._value, y._value);
            Int32N IMath<Int32N>.Log10(Int32N x) => (int)Math.Log10(x._value);
            Int32N IMath<Int32N>.Max(Int32N x, Int32N y) => Math.Max(x._value, y._value);
            Int32N IMath<Int32N>.Min(Int32N x, Int32N y) => Math.Min(x._value, y._value);
            Int32N IMath<Int32N>.PI { get; } = 3;
            Int32N IMath<Int32N>.Pow(Int32N x, Int32N y) => (int)Math.Pow(x._value, y._value);
            Int32N IMath<Int32N>.RadiansToDegrees(Int32N x) => (int)(x * NumericUtilities.DegreesPerRadian);
            Int32N IMath<Int32N>.Round(Int32N x) => x;
            Int32N IMath<Int32N>.Round(Int32N x, int digits) => x;
            Int32N IMath<Int32N>.Round(Int32N x, int digits, MidpointRounding mode) => x;
            Int32N IMath<Int32N>.Round(Int32N x, MidpointRounding mode) => x;
            Int32N IMath<Int32N>.Sin(Int32N x) => (int)Math.Sin(x._value);
            Int32N IMath<Int32N>.Sinh(Int32N x) => (int)Math.Sinh(x._value);
            Int32N IMath<Int32N>.Sqrt(Int32N x) => (int)Math.Sqrt(x._value);
            Int32N IMath<Int32N>.Tan(Int32N x) => (int)Math.Tan(x._value);
            Int32N IMath<Int32N>.Tanh(Int32N x) => (int)Math.Tanh(x._value);
            Int32N IMath<Int32N>.Tau { get; } = 6;
            Int32N IMath<Int32N>.Truncate(Int32N x) => x;

            Int32N IBitConverter<Int32N>.Read(IReadOnlyStream<byte> stream) => BitConverter.ToInt32(stream.Read(sizeof(int)), 0);
            void IBitConverter<Int32N>.Write(Int32N value, IWriteOnlyStream<byte> stream) => stream.Write(BitConverter.GetBytes(value._value));

            Int32N IRandom<Int32N>.Next(Random random) => random.NextInt32();
            Int32N IRandom<Int32N>.Next(Random random, Int32N bound1, Int32N bound2) => random.NextInt32(bound1._value, bound2._value);

            bool IConvert<Int32N>.ToBoolean(Int32N value) => Convert.ToBoolean(value._value);
            byte IConvert<Int32N>.ToByte(Int32N value, Conversion mode) => NumericConvert.ToByte(value._value, mode);
            decimal IConvert<Int32N>.ToDecimal(Int32N value, Conversion mode) => NumericConvert.ToDecimal(value._value, mode);
            double IConvert<Int32N>.ToDouble(Int32N value, Conversion mode) => NumericConvert.ToDouble(value._value, mode);
            float IConvert<Int32N>.ToSingle(Int32N value, Conversion mode) => NumericConvert.ToSingle(value._value, mode);
            int IConvert<Int32N>.ToInt32(Int32N value, Conversion mode) => NumericConvert.ToInt32(value._value, mode);
            long IConvert<Int32N>.ToInt64(Int32N value, Conversion mode) => NumericConvert.ToInt64(value._value, mode);
            sbyte IConvertExtended<Int32N>.ToSByte(Int32N value, Conversion mode) => NumericConvert.ToSByte(value._value, mode);
            short IConvert<Int32N>.ToInt16(Int32N value, Conversion mode) => NumericConvert.ToInt16(value._value, mode);
            string IConvert<Int32N>.ToString(Int32N value) => Convert.ToString(value._value);
            uint IConvertExtended<Int32N>.ToUInt32(Int32N value, Conversion mode) => NumericConvert.ToUInt32(value._value, mode);
            ulong IConvertExtended<Int32N>.ToUInt64(Int32N value, Conversion mode) => NumericConvert.ToUInt64(value._value, mode);
            ushort IConvertExtended<Int32N>.ToUInt16(Int32N value, Conversion mode) => NumericConvert.ToUInt16(value._value, mode);

            Int32N IConvert<Int32N>.ToNumeric(bool value) => Convert.ToInt32(value);
            Int32N IConvert<Int32N>.ToNumeric(byte value, Conversion mode) => NumericConvert.ToInt32(value, mode);
            Int32N IConvert<Int32N>.ToNumeric(decimal value, Conversion mode) => NumericConvert.ToInt32(value, mode);
            Int32N IConvert<Int32N>.ToNumeric(double value, Conversion mode) => NumericConvert.ToInt32(value, mode);
            Int32N IConvert<Int32N>.ToNumeric(float value, Conversion mode) => NumericConvert.ToInt32(value, mode);
            Int32N IConvert<Int32N>.ToNumeric(int value, Conversion mode) => NumericConvert.ToInt32(value, mode);
            Int32N IConvert<Int32N>.ToNumeric(long value, Conversion mode) => NumericConvert.ToInt32(value, mode);
            Int32N IConvertExtended<Int32N>.ToValue(sbyte value, Conversion mode) => NumericConvert.ToInt32(value, mode);
            Int32N IConvert<Int32N>.ToNumeric(short value, Conversion mode) => NumericConvert.ToInt32(value, mode);
            Int32N IConvert<Int32N>.ToNumeric(string value) => Convert.ToInt32(value);
            Int32N IConvertExtended<Int32N>.ToNumeric(uint value, Conversion mode) => NumericConvert.ToInt32(value, mode);
            Int32N IConvertExtended<Int32N>.ToNumeric(ulong value, Conversion mode) => NumericConvert.ToInt32(value, mode);
            Int32N IConvertExtended<Int32N>.ToNumeric(ushort value, Conversion mode) => NumericConvert.ToInt32(value, mode);

            Int32N IParser<Int32N>.Parse(string s) => Parse(s);
            Int32N IParser<Int32N>.Parse(string s, NumberStyles style, IFormatProvider? provider) => Parse(s, style, provider);
        }
    }
}
