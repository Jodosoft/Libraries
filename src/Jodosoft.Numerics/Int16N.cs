﻿// Copyright (c) 2023 Joe Lawry-Short
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
using System.IO;
using System.Runtime.Serialization;
using Jodosoft.Primitives;
using Jodosoft.Primitives.Compatibility;

namespace Jodosoft.Numerics
{
    /// <summary>
    /// Represents a 16-bit signed integer.
    /// </summary>
    [Serializable]
    [DebuggerDisplay("{ToString(),nq}")]
    public readonly struct Int16N : INumericExtended<Int16N>
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

        public static bool TryParse(string s, IFormatProvider? provider, out Int16N result) => FuncExtensions.Try(() => Parse(s, provider), out result);
        public static bool TryParse(string s, NumberStyles style, IFormatProvider? provider, out Int16N result) => FuncExtensions.Try(() => Parse(s, style, provider), out result);
        public static bool TryParse(string s, NumberStyles style, out Int16N result) => FuncExtensions.Try(() => Parse(s, style), out result);
        public static bool TryParse(string s, out Int16N result) => FuncExtensions.Try(() => Parse(s), out result);
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
        object IConvertible.ToType(Type conversionType, IFormatProvider provider) => this.ToTypeDefault(conversionType, provider);

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

        INumericBitConverter<Int16N> IProvider<INumericBitConverter<Int16N>>.GetInstance() => Utilities.Instance;
        IBinaryIO<Int16N> IProvider<IBinaryIO<Int16N>>.GetInstance() => Utilities.Instance;
        IConvert<Int16N> IProvider<IConvert<Int16N>>.GetInstance() => Utilities.Instance;
        IConvertExtended<Int16N> IProvider<IConvertExtended<Int16N>>.GetInstance() => Utilities.Instance;
        IMath<Int16N> IProvider<IMath<Int16N>>.GetInstance() => Utilities.Instance;
        INumericStatic<Int16N> IProvider<INumericStatic<Int16N>>.GetInstance() => Utilities.Instance;
        INumericRandom<Int16N> IProvider<INumericRandom<Int16N>>.GetInstance() => Utilities.Instance;
        IVariantRandom<Int16N> IProvider<IVariantRandom<Int16N>>.GetInstance() => Utilities.Instance;

        private sealed class Utilities :
            IBinaryIO<Int16N>,
            IConvert<Int16N>,
            IConvertExtended<Int16N>,
            IMath<Int16N>,
            INumericBitConverter<Int16N>,
            INumericRandom<Int16N>,
            INumericStatic<Int16N>,
            IVariantRandom<Int16N>
        {
            public static readonly Utilities Instance = new Utilities();

            void IBinaryIO<Int16N>.Write(BinaryWriter writer, Int16N value) => writer.Write(value);
            Int16N IBinaryIO<Int16N>.Read(BinaryReader reader) => reader.ReadInt16();

            bool INumericStatic<Int16N>.HasFloatingPoint => false;
            bool INumericStatic<Int16N>.HasInfinity => false;
            bool INumericStatic<Int16N>.HasNaN => false;
            bool INumericStatic<Int16N>.IsFinite(Int16N x) => true;
            bool INumericStatic<Int16N>.IsInfinity(Int16N x) => false;
            bool INumericStatic<Int16N>.IsNaN(Int16N x) => false;
            bool INumericStatic<Int16N>.IsNegative(Int16N x) => x._value < 0;
            bool INumericStatic<Int16N>.IsNegativeInfinity(Int16N x) => false;
            bool INumericStatic<Int16N>.IsNormal(Int16N x) => false;
            bool INumericStatic<Int16N>.IsPositiveInfinity(Int16N x) => false;
            bool INumericStatic<Int16N>.IsReal => false;
            bool INumericStatic<Int16N>.IsSigned => true;
            bool INumericStatic<Int16N>.IsSubnormal(Int16N x) => false;
            Int16N INumericStatic<Int16N>.Epsilon => (short)1;
            Int16N INumericStatic<Int16N>.MaxUnit => (short)1;
            Int16N INumericStatic<Int16N>.MaxValue => MaxValue;
            Int16N INumericStatic<Int16N>.MinUnit => (short)-1;
            Int16N INumericStatic<Int16N>.MinValue => MinValue;
            Int16N INumericStatic<Int16N>.One => (short)1;
            Int16N INumericStatic<Int16N>.Zero => (short)0;

            int IMath<Int16N>.Sign(Int16N x) => Math.Sign(x._value);
            Int16N IMath<Int16N>.Abs(Int16N value) => Math.Abs(value._value);
            Int16N IMath<Int16N>.Acos(Int16N x) => (short)Math.Acos(x._value);
            Int16N IMath<Int16N>.Acosh(Int16N x) => (short)MathShim.Acosh(x._value);
            Int16N IMath<Int16N>.Asin(Int16N x) => (short)Math.Asin(x._value);
            Int16N IMath<Int16N>.Asinh(Int16N x) => (short)MathShim.Asinh(x._value);
            Int16N IMath<Int16N>.Atan(Int16N x) => (short)Math.Atan(x._value);
            Int16N IMath<Int16N>.Atan2(Int16N x, Int16N y) => (short)Math.Atan2(x._value, y._value);
            Int16N IMath<Int16N>.Atanh(Int16N x) => (short)MathShim.Atanh(x._value);
            Int16N IMath<Int16N>.Cbrt(Int16N x) => (short)MathShim.Cbrt(x._value);
            Int16N IMath<Int16N>.Ceiling(Int16N x) => x;
            Int16N IMath<Int16N>.Clamp(Int16N x, Int16N bound1, Int16N bound2) => bound1 > bound2 ? Math.Min(bound1._value, Math.Max(bound2._value, x._value)) : Math.Min(bound2._value, Math.Max(bound1._value, x._value));
            Int16N IMath<Int16N>.Cos(Int16N x) => (short)Math.Cos(x._value);
            Int16N IMath<Int16N>.Cosh(Int16N x) => (short)Math.Cosh(x._value);
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

            int INumericBitConverter<Int16N>.ConvertedSize => sizeof(short);
            Int16N INumericBitConverter<Int16N>.ToNumeric(byte[] value, int startIndex) => BitConverter.ToInt16(value, startIndex);
            byte[] INumericBitConverter<Int16N>.GetBytes(Int16N value) => BitConverter.GetBytes(value._value);
#if HAS_SPANS
            Int16N INumericBitConverter<Int16N>.ToNumeric(ReadOnlySpan<byte> value) => BitConverter.ToInt16(value);
            bool INumericBitConverter<Int16N>.TryWriteBytes(Span<byte> destination, Int16N value) => BitConverter.TryWriteBytes(destination, value);
#endif

            bool IConvert<Int16N>.ToBoolean(Int16N value) => Convert.ToBoolean(value._value);
            byte IConvert<Int16N>.ToByte(Int16N value, Conversion mode) => ConvertN.ToByte(value._value, mode);
            decimal IConvert<Int16N>.ToDecimal(Int16N value, Conversion mode) => ConvertN.ToDecimal(value._value, mode);
            double IConvert<Int16N>.ToDouble(Int16N value, Conversion mode) => ConvertN.ToDouble(value._value, mode);
            float IConvert<Int16N>.ToSingle(Int16N value, Conversion mode) => ConvertN.ToSingle(value._value, mode);
            int IConvert<Int16N>.ToInt32(Int16N value, Conversion mode) => ConvertN.ToInt32(value._value, mode);
            long IConvert<Int16N>.ToInt64(Int16N value, Conversion mode) => ConvertN.ToInt64(value._value, mode);
            sbyte IConvertExtended<Int16N>.ToSByte(Int16N value, Conversion mode) => ConvertN.ToSByte(value._value, mode);
            short IConvert<Int16N>.ToInt16(Int16N value, Conversion mode) => ConvertN.ToInt16(value._value, mode);
            string IConvert<Int16N>.ToString(Int16N value) => Convert.ToString(value._value);
            uint IConvertExtended<Int16N>.ToUInt32(Int16N value, Conversion mode) => ConvertN.ToUInt32(value._value, mode);
            ulong IConvertExtended<Int16N>.ToUInt64(Int16N value, Conversion mode) => ConvertN.ToUInt64(value._value, mode);
            ushort IConvertExtended<Int16N>.ToUInt16(Int16N value, Conversion mode) => ConvertN.ToUInt16(value._value, mode);

            Int16N IConvert<Int16N>.ToNumeric(bool value) => Convert.ToInt16(value);
            Int16N IConvert<Int16N>.ToNumeric(byte value, Conversion mode) => ConvertN.ToInt16(value, mode);
            Int16N IConvert<Int16N>.ToNumeric(decimal value, Conversion mode) => ConvertN.ToInt16(value, mode);
            Int16N IConvert<Int16N>.ToNumeric(double value, Conversion mode) => ConvertN.ToInt16(value, mode);
            Int16N IConvert<Int16N>.ToNumeric(float value, Conversion mode) => ConvertN.ToInt16(value, mode);
            Int16N IConvert<Int16N>.ToNumeric(int value, Conversion mode) => ConvertN.ToInt16(value, mode);
            Int16N IConvert<Int16N>.ToNumeric(long value, Conversion mode) => ConvertN.ToInt16(value, mode);
            Int16N IConvertExtended<Int16N>.ToValue(sbyte value, Conversion mode) => ConvertN.ToInt16(value, mode);
            Int16N IConvert<Int16N>.ToNumeric(short value, Conversion mode) => ConvertN.ToInt16(value, mode);
            Int16N IConvert<Int16N>.ToNumeric(string value) => Convert.ToInt16(value);
            Int16N IConvertExtended<Int16N>.ToNumeric(uint value, Conversion mode) => ConvertN.ToInt16(value, mode);
            Int16N IConvertExtended<Int16N>.ToNumeric(ulong value, Conversion mode) => ConvertN.ToInt16(value, mode);
            Int16N IConvertExtended<Int16N>.ToNumeric(ushort value, Conversion mode) => ConvertN.ToInt16(value, mode);

            Int16N INumericStatic<Int16N>.Parse(string s, NumberStyles? style, IFormatProvider? provider)
                => Parse(s, style ?? NumberStyles.Integer, provider);

            Int16N INumericRandom<Int16N>.Generate(Random random) => random.NextInt16();
            Int16N INumericRandom<Int16N>.Generate(Random random, Int16N maxValue) => random.NextInt16(maxValue);
            Int16N INumericRandom<Int16N>.Generate(Random random, Int16N minValue, Int16N maxValue) => random.NextInt16(minValue, maxValue);
            Int16N INumericRandom<Int16N>.Generate(Random random, Generation mode) => random.NextInt16(mode);
            Int16N INumericRandom<Int16N>.Generate(Random random, Int16N minValue, Int16N maxValue, Generation mode) => random.NextInt16(minValue, maxValue, mode);

            Int16N IVariantRandom<Int16N>.Generate(Random random, Variants variants) => random.NextInt16(variants);
        }
    }
}
