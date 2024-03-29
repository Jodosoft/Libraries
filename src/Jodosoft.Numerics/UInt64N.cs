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
    /// Represents a 64-bit unsigned integer.
    /// </summary>
    [Serializable]
    [DebuggerDisplay("{ToString(),nq}")]
    public readonly struct UInt64N : INumericExtended<UInt64N>
    {
        public static readonly UInt64N MaxValue = new UInt64N(ulong.MaxValue);
        public static readonly UInt64N MinValue = new UInt64N(ulong.MinValue);

        private readonly ulong _value;

        private UInt64N(ulong value)
        {
            _value = value;
        }

        private UInt64N(SerializationInfo info, StreamingContext context) : this(info.GetUInt64(nameof(UInt64N))) { }
        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context) => info.AddValue(nameof(UInt64N), _value);

        public int CompareTo(UInt64N other) => _value.CompareTo(other._value);
        public int CompareTo(object? obj) => obj is UInt64N other ? CompareTo(other) : 1;
        public bool Equals(UInt64N other) => _value == other._value;
        public override bool Equals(object? obj) => obj is UInt64N other && Equals(other);
        public override int GetHashCode() => _value.GetHashCode();
        public override string ToString() => _value.ToString();
        public string ToString(IFormatProvider formatProvider) => _value.ToString(formatProvider);
        public string ToString(string format) => _value.ToString(format);
        public string ToString(string? format, IFormatProvider? formatProvider) => _value.ToString(format, formatProvider);

        public static bool TryParse(string s, IFormatProvider? provider, out UInt64N result) => FuncExtensions.Try(() => Parse(s, provider), out result);
        public static bool TryParse(string s, NumberStyles style, IFormatProvider? provider, out UInt64N result) => FuncExtensions.Try(() => Parse(s, style, provider), out result);
        public static bool TryParse(string s, NumberStyles style, out UInt64N result) => FuncExtensions.Try(() => Parse(s, style), out result);
        public static bool TryParse(string s, out UInt64N result) => FuncExtensions.Try(() => Parse(s), out result);
        public static UInt64N Parse(string s) => ulong.Parse(s);
        public static UInt64N Parse(string s, IFormatProvider? provider) => ulong.Parse(s, provider);
        public static UInt64N Parse(string s, NumberStyles style) => ulong.Parse(s, style);
        public static UInt64N Parse(string s, NumberStyles style, IFormatProvider? provider) => ulong.Parse(s, style, provider);

        [CLSCompliant(false)] public static explicit operator UInt64N(sbyte value) => new UInt64N((ulong)value);
        [CLSCompliant(false)] public static implicit operator UInt64N(uint value) => new UInt64N(value);
        [CLSCompliant(false)] public static implicit operator UInt64N(ulong value) => new UInt64N(value);
        [CLSCompliant(false)] public static implicit operator UInt64N(ushort value) => new UInt64N(value);
        public static explicit operator UInt64N(decimal value) => new UInt64N((ulong)value);
        public static explicit operator UInt64N(double value) => new UInt64N((ulong)value);
        public static explicit operator UInt64N(float value) => new UInt64N((ulong)value);
        public static explicit operator UInt64N(int value) => new UInt64N((ulong)value);
        public static explicit operator UInt64N(long value) => new UInt64N((ulong)value);
        public static explicit operator UInt64N(short value) => new UInt64N((ulong)value);
        public static implicit operator UInt64N(byte value) => new UInt64N(value);

        [CLSCompliant(false)] public static explicit operator sbyte(UInt64N value) => (sbyte)value._value;
        [CLSCompliant(false)] public static explicit operator uint(UInt64N value) => (uint)value._value;
        [CLSCompliant(false)] public static explicit operator ushort(UInt64N value) => (ushort)value._value;
        [CLSCompliant(false)] public static implicit operator ulong(UInt64N value) => value._value;
        public static explicit operator byte(UInt64N value) => (byte)value._value;
        public static explicit operator int(UInt64N value) => (int)value._value;
        public static explicit operator long(UInt64N value) => (long)value._value;
        public static explicit operator short(UInt64N value) => (short)value._value;
        public static implicit operator decimal(UInt64N value) => value._value;
        public static implicit operator double(UInt64N value) => value._value;
        public static implicit operator float(UInt64N value) => value._value;

        public static bool operator !=(UInt64N left, UInt64N right) => left._value != right._value;
        public static bool operator <(UInt64N left, UInt64N right) => left._value < right._value;
        public static bool operator <=(UInt64N left, UInt64N right) => left._value <= right._value;
        public static bool operator ==(UInt64N left, UInt64N right) => left._value == right._value;
        public static bool operator >(UInt64N left, UInt64N right) => left._value > right._value;
        public static bool operator >=(UInt64N left, UInt64N right) => left._value >= right._value;
        public static UInt64N operator %(UInt64N left, UInt64N right) => left._value % right._value;
        public static UInt64N operator &(UInt64N left, UInt64N right) => left._value & right._value;
        public static UInt64N operator -(UInt64N left, UInt64N right) => left._value - right._value;
        public static UInt64N operator --(UInt64N value) => value._value - 1;
        public static UInt64N operator *(UInt64N left, UInt64N right) => left._value * right._value;
        public static UInt64N operator /(UInt64N left, UInt64N right) => left._value / right._value;
        public static UInt64N operator ^(UInt64N left, UInt64N right) => left._value ^ right._value;
        public static UInt64N operator |(UInt64N left, UInt64N right) => left._value | right._value;
        public static UInt64N operator ~(UInt64N value) => ~value._value;
        public static UInt64N operator +(UInt64N left, UInt64N right) => left._value + right._value;
        public static UInt64N operator +(UInt64N value) => value;
        public static UInt64N operator ++(UInt64N value) => value._value + 1;
        public static UInt64N operator <<(UInt64N left, int right) => left._value << right;
        public static UInt64N operator >>(UInt64N left, int right) => left._value >> right;

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

        bool INumeric<UInt64N>.IsGreaterThan(UInt64N value) => this > value;
        bool INumeric<UInt64N>.IsGreaterThanOrEqualTo(UInt64N value) => this >= value;
        bool INumeric<UInt64N>.IsLessThan(UInt64N value) => this < value;
        bool INumeric<UInt64N>.IsLessThanOrEqualTo(UInt64N value) => this <= value;
        UInt64N INumeric<UInt64N>.Add(UInt64N value) => this + value;
        UInt64N INumeric<UInt64N>.BitwiseComplement() => ~this;
        UInt64N INumeric<UInt64N>.Divide(UInt64N value) => this / value;
        UInt64N INumeric<UInt64N>.LeftShift(int count) => this << count;
        UInt64N INumeric<UInt64N>.LogicalAnd(UInt64N value) => this & value;
        UInt64N INumeric<UInt64N>.LogicalExclusiveOr(UInt64N value) => this ^ value;
        UInt64N INumeric<UInt64N>.LogicalOr(UInt64N value) => this | value;
        UInt64N INumeric<UInt64N>.Multiply(UInt64N value) => this * value;
        UInt64N INumeric<UInt64N>.Negative() => 0 - _value;
        UInt64N INumeric<UInt64N>.Positive() => +this;
        UInt64N INumeric<UInt64N>.Remainder(UInt64N value) => this % value;
        UInt64N INumeric<UInt64N>.RightShift(int count) => this >> count;
        UInt64N INumeric<UInt64N>.Subtract(UInt64N value) => this - value;

        INumericBitConverter<UInt64N> IProvider<INumericBitConverter<UInt64N>>.GetInstance() => Utilities.Instance;
        IBinaryIO<UInt64N> IProvider<IBinaryIO<UInt64N>>.GetInstance() => Utilities.Instance;
        IConvert<UInt64N> IProvider<IConvert<UInt64N>>.GetInstance() => Utilities.Instance;
        IConvertExtended<UInt64N> IProvider<IConvertExtended<UInt64N>>.GetInstance() => Utilities.Instance;
        IMath<UInt64N> IProvider<IMath<UInt64N>>.GetInstance() => Utilities.Instance;
        INumericRandom<UInt64N> IProvider<INumericRandom<UInt64N>>.GetInstance() => Utilities.Instance;
        INumericStatic<UInt64N> IProvider<INumericStatic<UInt64N>>.GetInstance() => Utilities.Instance;
        IVariantRandom<UInt64N> IProvider<IVariantRandom<UInt64N>>.GetInstance() => Utilities.Instance;

        private sealed class Utilities :
            IBinaryIO<UInt64N>,
            IConvert<UInt64N>,
            IConvertExtended<UInt64N>,
            IMath<UInt64N>,
            INumericBitConverter<UInt64N>,
            INumericRandom<UInt64N>,
            INumericStatic<UInt64N>,
            IVariantRandom<UInt64N>
        {
            public static readonly Utilities Instance = new Utilities();

            void IBinaryIO<UInt64N>.Write(BinaryWriter writer, UInt64N value) => writer.Write(value);
            UInt64N IBinaryIO<UInt64N>.Read(BinaryReader reader) => reader.ReadUInt64();

            bool INumericStatic<UInt64N>.HasFloatingPoint => false;
            bool INumericStatic<UInt64N>.HasInfinity => false;
            bool INumericStatic<UInt64N>.HasNaN => false;
            bool INumericStatic<UInt64N>.IsFinite(UInt64N x) => true;
            bool INumericStatic<UInt64N>.IsInfinity(UInt64N x) => false;
            bool INumericStatic<UInt64N>.IsNaN(UInt64N x) => false;
            bool INumericStatic<UInt64N>.IsNegative(UInt64N x) => false;
            bool INumericStatic<UInt64N>.IsNegativeInfinity(UInt64N x) => false;
            bool INumericStatic<UInt64N>.IsNormal(UInt64N x) => false;
            bool INumericStatic<UInt64N>.IsPositiveInfinity(UInt64N x) => false;
            bool INumericStatic<UInt64N>.IsReal => false;
            bool INumericStatic<UInt64N>.IsSigned => false;
            bool INumericStatic<UInt64N>.IsSubnormal(UInt64N x) => false;
            UInt64N INumericStatic<UInt64N>.Epsilon => (UInt64N)1;
            UInt64N INumericStatic<UInt64N>.MaxUnit => (UInt64N)1;
            UInt64N INumericStatic<UInt64N>.MaxValue => MaxValue;
            UInt64N INumericStatic<UInt64N>.MinUnit => (UInt64N)0;
            UInt64N INumericStatic<UInt64N>.MinValue => MinValue;
            UInt64N INumericStatic<UInt64N>.One => (UInt64N)1;
            UInt64N INumericStatic<UInt64N>.Zero => (UInt64N)0;

            int IMath<UInt64N>.Sign(UInt64N x) => x._value == 0 ? 0 : 1;
            UInt64N IMath<UInt64N>.Abs(UInt64N value) => value;
            UInt64N IMath<UInt64N>.Acos(UInt64N x) => (UInt64N)Math.Acos(x);
            UInt64N IMath<UInt64N>.Acosh(UInt64N x) => (UInt64N)MathShim.Acosh(x);
            UInt64N IMath<UInt64N>.Asin(UInt64N x) => (UInt64N)Math.Asin(x);
            UInt64N IMath<UInt64N>.Asinh(UInt64N x) => (UInt64N)MathShim.Asinh(x);
            UInt64N IMath<UInt64N>.Atan(UInt64N x) => (UInt64N)Math.Atan(x);
            UInt64N IMath<UInt64N>.Atan2(UInt64N y, UInt64N x) => (UInt64N)Math.Atan2(y, x);
            UInt64N IMath<UInt64N>.Atanh(UInt64N x) => (UInt64N)MathShim.Atanh(x);
            UInt64N IMath<UInt64N>.Cbrt(UInt64N x) => (UInt64N)MathShim.Cbrt(x);
            UInt64N IMath<UInt64N>.Ceiling(UInt64N x) => x;
            UInt64N IMath<UInt64N>.Clamp(UInt64N x, UInt64N bound1, UInt64N bound2) => bound1 > bound2 ? Math.Min(bound1, Math.Max(bound2, x)) : Math.Min(bound2, Math.Max(bound1, x));
            UInt64N IMath<UInt64N>.Cos(UInt64N x) => (UInt64N)Math.Cos(x);
            UInt64N IMath<UInt64N>.Cosh(UInt64N x) => (UInt64N)Math.Cosh(x);
            UInt64N IMath<UInt64N>.E { get; } = (UInt64N)2;
            UInt64N IMath<UInt64N>.Exp(UInt64N x) => (UInt64N)Math.Exp(x);
            UInt64N IMath<UInt64N>.Floor(UInt64N x) => x;
            UInt64N IMath<UInt64N>.IEEERemainder(UInt64N x, UInt64N y) => (UInt64N)Math.IEEERemainder(x, y);
            UInt64N IMath<UInt64N>.Log(UInt64N x) => (UInt64N)Math.Log(x);
            UInt64N IMath<UInt64N>.Log(UInt64N x, UInt64N y) => (UInt64N)Math.Log(x, y);
            UInt64N IMath<UInt64N>.Log10(UInt64N x) => (UInt64N)Math.Log10(x);
            UInt64N IMath<UInt64N>.Max(UInt64N x, UInt64N y) => Math.Max(x, y);
            UInt64N IMath<UInt64N>.Min(UInt64N x, UInt64N y) => Math.Min(x, y);
            UInt64N IMath<UInt64N>.PI { get; } = (UInt64N)3;
            UInt64N IMath<UInt64N>.Pow(UInt64N x, UInt64N y) => y == 1 ? x : (UInt64N)Math.Pow(x, y);
            UInt64N IMath<UInt64N>.Round(UInt64N x) => x;
            UInt64N IMath<UInt64N>.Round(UInt64N x, int digits) => x;
            UInt64N IMath<UInt64N>.Round(UInt64N x, int digits, MidpointRounding mode) => x;
            UInt64N IMath<UInt64N>.Round(UInt64N x, MidpointRounding mode) => x;
            UInt64N IMath<UInt64N>.Sin(UInt64N x) => (UInt64N)Math.Sin(x);
            UInt64N IMath<UInt64N>.Sinh(UInt64N x) => (UInt64N)Math.Sinh(x);
            UInt64N IMath<UInt64N>.Sqrt(UInt64N x) => (UInt64N)Math.Sqrt(x);
            UInt64N IMath<UInt64N>.Tan(UInt64N x) => (UInt64N)Math.Tan(x);
            UInt64N IMath<UInt64N>.Tanh(UInt64N x) => (UInt64N)Math.Tanh(x);
            UInt64N IMath<UInt64N>.Tau { get; } = (UInt64N)6;
            UInt64N IMath<UInt64N>.Truncate(UInt64N x) => x;

            int INumericBitConverter<UInt64N>.ConvertedSize => sizeof(ulong);
            UInt64N INumericBitConverter<UInt64N>.ToNumeric(byte[] value, int startIndex) => BitConverter.ToUInt64(value, startIndex);
            byte[] INumericBitConverter<UInt64N>.GetBytes(UInt64N value) => BitConverter.GetBytes(value._value);
#if HAS_SPANS
            UInt64N INumericBitConverter<UInt64N>.ToNumeric(ReadOnlySpan<byte> value) => BitConverter.ToUInt64(value);
            bool INumericBitConverter<UInt64N>.TryWriteBytes(Span<byte> destination, UInt64N value) => BitConverter.TryWriteBytes(destination, value);
#endif

            bool IConvert<UInt64N>.ToBoolean(UInt64N value) => Convert.ToBoolean(value._value);
            byte IConvert<UInt64N>.ToByte(UInt64N value, Conversion mode) => ConvertN.ToByte(value._value, mode);
            decimal IConvert<UInt64N>.ToDecimal(UInt64N value, Conversion mode) => ConvertN.ToDecimal(value._value, mode);
            double IConvert<UInt64N>.ToDouble(UInt64N value, Conversion mode) => ConvertN.ToDouble(value._value, mode);
            float IConvert<UInt64N>.ToSingle(UInt64N value, Conversion mode) => ConvertN.ToSingle(value._value, mode);
            int IConvert<UInt64N>.ToInt32(UInt64N value, Conversion mode) => ConvertN.ToInt32(value._value, mode);
            long IConvert<UInt64N>.ToInt64(UInt64N value, Conversion mode) => ConvertN.ToInt64(value._value, mode);
            sbyte IConvertExtended<UInt64N>.ToSByte(UInt64N value, Conversion mode) => ConvertN.ToSByte(value._value, mode);
            short IConvert<UInt64N>.ToInt16(UInt64N value, Conversion mode) => ConvertN.ToInt16(value._value, mode);
            string IConvert<UInt64N>.ToString(UInt64N value) => Convert.ToString(value._value);
            uint IConvertExtended<UInt64N>.ToUInt32(UInt64N value, Conversion mode) => ConvertN.ToUInt32(value._value, mode);
            ulong IConvertExtended<UInt64N>.ToUInt64(UInt64N value, Conversion mode) => value._value;
            ushort IConvertExtended<UInt64N>.ToUInt16(UInt64N value, Conversion mode) => ConvertN.ToUInt16(value._value, mode);

            UInt64N IConvert<UInt64N>.ToNumeric(bool value) => Convert.ToUInt64(value);
            UInt64N IConvert<UInt64N>.ToNumeric(byte value, Conversion mode) => ConvertN.ToUInt64(value, mode);
            UInt64N IConvert<UInt64N>.ToNumeric(decimal value, Conversion mode) => ConvertN.ToUInt64(value, mode);
            UInt64N IConvert<UInt64N>.ToNumeric(double value, Conversion mode) => ConvertN.ToUInt64(value, mode);
            UInt64N IConvert<UInt64N>.ToNumeric(float value, Conversion mode) => ConvertN.ToUInt64(value, mode);
            UInt64N IConvert<UInt64N>.ToNumeric(int value, Conversion mode) => ConvertN.ToUInt64(value, mode);
            UInt64N IConvert<UInt64N>.ToNumeric(long value, Conversion mode) => ConvertN.ToUInt64(value, mode);
            UInt64N IConvertExtended<UInt64N>.ToValue(sbyte value, Conversion mode) => ConvertN.ToUInt64(value, mode);
            UInt64N IConvert<UInt64N>.ToNumeric(short value, Conversion mode) => ConvertN.ToUInt64(value, mode);
            UInt64N IConvert<UInt64N>.ToNumeric(string value) => Convert.ToUInt64(value);
            UInt64N IConvertExtended<UInt64N>.ToNumeric(uint value, Conversion mode) => ConvertN.ToUInt64(value, mode);
            UInt64N IConvertExtended<UInt64N>.ToNumeric(ulong value, Conversion mode) => value;
            UInt64N IConvertExtended<UInt64N>.ToNumeric(ushort value, Conversion mode) => ConvertN.ToUInt64(value, mode);

            UInt64N INumericStatic<UInt64N>.Parse(string s, NumberStyles? style, IFormatProvider? provider)
                => Parse(s, style ?? NumberStyles.Integer, provider);

            UInt64N INumericRandom<UInt64N>.Generate(Random random) => random.NextUInt64();
            UInt64N INumericRandom<UInt64N>.Generate(Random random, UInt64N maxValue) => random.NextUInt64(maxValue);
            UInt64N INumericRandom<UInt64N>.Generate(Random random, UInt64N minValue, UInt64N maxValue) => random.NextUInt64(minValue, maxValue);
            UInt64N INumericRandom<UInt64N>.Generate(Random random, Generation mode) => random.NextUInt64(mode);
            UInt64N INumericRandom<UInt64N>.Generate(Random random, UInt64N minValue, UInt64N maxValue, Generation mode) => random.NextUInt64(minValue, maxValue, mode);

            UInt64N IVariantRandom<UInt64N>.Generate(Random random, Variants variants) => random.NextUInt64(variants);
        }
    }
}
