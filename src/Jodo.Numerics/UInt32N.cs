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
using System.IO;
using System.Runtime.Serialization;
using Jodo.Primitives;
using Jodo.Primitives.Compatibility;

namespace Jodo.Numerics
{
    /// <summary>
    /// Represents a 32-bit unsigned integer.
    /// </summary>
    [Serializable]
    [DebuggerDisplay("{ToString(),nq}")]
    public readonly struct UInt32N : INumericExtended<UInt32N>
    {
        public static readonly UInt32N MaxValue = new UInt32N(uint.MaxValue);
        public static readonly UInt32N MinValue = new UInt32N(uint.MinValue);

        private readonly uint _value;

        private UInt32N(uint value)
        {
            _value = value;
        }

        private UInt32N(SerializationInfo info, StreamingContext context) : this(info.GetUInt32(nameof(UInt32N))) { }
        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context) => info.AddValue(nameof(UInt32N), _value);

        public int CompareTo(UInt32N other) => _value.CompareTo(other._value);
        public int CompareTo(object? obj) => obj is UInt32N other ? CompareTo(other) : 1;
        public bool Equals(UInt32N other) => _value == other._value;
        public override bool Equals(object? obj) => obj is UInt32N other && Equals(other);
        public override int GetHashCode() => _value.GetHashCode();
        public override string ToString() => _value.ToString();
        public string ToString(IFormatProvider formatProvider) => _value.ToString(formatProvider);
        public string ToString(string format) => _value.ToString(format);
        public string ToString(string? format, IFormatProvider? formatProvider) => _value.ToString(format, formatProvider);

        public static bool TryParse(string s, IFormatProvider? provider, out UInt32N result) => FuncExtensions.Try(() => Parse(s, provider), out result);
        public static bool TryParse(string s, NumberStyles style, IFormatProvider? provider, out UInt32N result) => FuncExtensions.Try(() => Parse(s, style, provider), out result);
        public static bool TryParse(string s, NumberStyles style, out UInt32N result) => FuncExtensions.Try(() => Parse(s, style), out result);
        public static bool TryParse(string s, out UInt32N result) => FuncExtensions.Try(() => Parse(s), out result);
        public static UInt32N Parse(string s) => uint.Parse(s);
        public static UInt32N Parse(string s, IFormatProvider? provider) => uint.Parse(s, provider);
        public static UInt32N Parse(string s, NumberStyles style) => uint.Parse(s, style);
        public static UInt32N Parse(string s, NumberStyles style, IFormatProvider? provider) => uint.Parse(s, style, provider);

        [CLSCompliant(false)] public static explicit operator UInt32N(sbyte value) => new UInt32N((uint)value);
        [CLSCompliant(false)] public static explicit operator UInt32N(ulong value) => new UInt32N((uint)value);
        [CLSCompliant(false)] public static implicit operator UInt32N(uint value) => new UInt32N(value);
        [CLSCompliant(false)] public static implicit operator UInt32N(ushort value) => new UInt32N(value);
        public static explicit operator UInt32N(decimal value) => new UInt32N((uint)value);
        public static explicit operator UInt32N(double value) => new UInt32N((uint)value);
        public static explicit operator UInt32N(float value) => new UInt32N((uint)value);
        public static explicit operator UInt32N(int value) => new UInt32N((uint)value);
        public static explicit operator UInt32N(long value) => new UInt32N((uint)value);
        public static explicit operator UInt32N(short value) => new UInt32N((uint)value);
        public static implicit operator UInt32N(byte value) => new UInt32N(value);

        [CLSCompliant(false)] public static explicit operator sbyte(UInt32N value) => (sbyte)value._value;
        [CLSCompliant(false)] public static explicit operator ushort(UInt32N value) => (ushort)value._value;
        [CLSCompliant(false)] public static implicit operator uint(UInt32N value) => value._value;
        [CLSCompliant(false)] public static implicit operator ulong(UInt32N value) => value._value;
        public static explicit operator byte(UInt32N value) => (byte)value._value;
        public static explicit operator int(UInt32N value) => (int)value._value;
        public static explicit operator short(UInt32N value) => (short)value._value;
        public static implicit operator decimal(UInt32N value) => value._value;
        public static implicit operator double(UInt32N value) => value._value;
        public static implicit operator float(UInt32N value) => value._value;
        public static implicit operator long(UInt32N value) => value._value;

        public static bool operator !=(UInt32N left, UInt32N right) => left._value != right._value;
        public static bool operator <(UInt32N left, UInt32N right) => left._value < right._value;
        public static bool operator <=(UInt32N left, UInt32N right) => left._value <= right._value;
        public static bool operator ==(UInt32N left, UInt32N right) => left._value == right._value;
        public static bool operator >(UInt32N left, UInt32N right) => left._value > right._value;
        public static bool operator >=(UInt32N left, UInt32N right) => left._value >= right._value;
        public static UInt32N operator %(UInt32N left, UInt32N right) => left._value % right._value;
        public static UInt32N operator &(UInt32N left, UInt32N right) => left._value & right._value;
        public static UInt32N operator -(UInt32N left, UInt32N right) => left._value - right._value;
        public static UInt32N operator --(UInt32N value) => value._value - 1;
        public static UInt32N operator *(UInt32N left, UInt32N right) => left._value * right._value;
        public static UInt32N operator /(UInt32N left, UInt32N right) => left._value / right._value;
        public static UInt32N operator ^(UInt32N left, UInt32N right) => left._value ^ right._value;
        public static UInt32N operator |(UInt32N left, UInt32N right) => left._value | right._value;
        public static UInt32N operator ~(UInt32N value) => ~value._value;
        public static UInt32N operator +(UInt32N left, UInt32N right) => left._value + right._value;
        public static UInt32N operator +(UInt32N value) => value;
        public static UInt32N operator ++(UInt32N value) => value._value + 1;
        public static UInt32N operator <<(UInt32N left, int right) => left._value << right;
        public static UInt32N operator >>(UInt32N left, int right) => left._value >> right;

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

        bool INumeric<UInt32N>.IsGreaterThan(UInt32N value) => this > value;
        bool INumeric<UInt32N>.IsGreaterThanOrEqualTo(UInt32N value) => this >= value;
        bool INumeric<UInt32N>.IsLessThan(UInt32N value) => this < value;
        bool INumeric<UInt32N>.IsLessThanOrEqualTo(UInt32N value) => this <= value;
        UInt32N INumeric<UInt32N>.Add(UInt32N value) => this + value;
        UInt32N INumeric<UInt32N>.BitwiseComplement() => ~this;
        UInt32N INumeric<UInt32N>.Divide(UInt32N value) => this / value;
        UInt32N INumeric<UInt32N>.LeftShift(int count) => this << count;
        UInt32N INumeric<UInt32N>.LogicalAnd(UInt32N value) => this & value;
        UInt32N INumeric<UInt32N>.LogicalExclusiveOr(UInt32N value) => this ^ value;
        UInt32N INumeric<UInt32N>.LogicalOr(UInt32N value) => this | value;
        UInt32N INumeric<UInt32N>.Multiply(UInt32N value) => this * value;
        UInt32N INumeric<UInt32N>.Negative() => 0 - _value;
        UInt32N INumeric<UInt32N>.Positive() => +this;
        UInt32N INumeric<UInt32N>.Remainder(UInt32N value) => this % value;
        UInt32N INumeric<UInt32N>.RightShift(int count) => this >> count;
        UInt32N INumeric<UInt32N>.Subtract(UInt32N value) => this - value;

        INumericBitConverter<UInt32N> IProvider<INumericBitConverter<UInt32N>>.GetInstance() => Utilities.Instance;
        IBinaryConvert<UInt32N> IProvider<IBinaryConvert<UInt32N>>.GetInstance() => Utilities.Instance;
        IConvert<UInt32N> IProvider<IConvert<UInt32N>>.GetInstance() => Utilities.Instance;
        IConvertExtended<UInt32N> IProvider<IConvertExtended<UInt32N>>.GetInstance() => Utilities.Instance;
        IMath<UInt32N> IProvider<IMath<UInt32N>>.GetInstance() => Utilities.Instance;
        INumericStatic<UInt32N> IProvider<INumericStatic<UInt32N>>.GetInstance() => Utilities.Instance;
        INumericRandom<UInt32N> IProvider<INumericRandom<UInt32N>>.GetInstance() => Utilities.Instance;
        IVariantRandom<UInt32N> IProvider<IVariantRandom<UInt32N>>.GetInstance() => Utilities.Instance;

        private sealed class Utilities :
            IBinaryConvert<UInt32N>,
            IConvert<UInt32N>,
            IConvertExtended<UInt32N>,
            IMath<UInt32N>,
            INumericBitConverter<UInt32N>,
            INumericRandom<UInt32N>,
            INumericStatic<UInt32N>,
            IVariantRandom<UInt32N>
        {
            public static readonly Utilities Instance = new Utilities();

            void IBinaryConvert<UInt32N>.Write(BinaryWriter writer, UInt32N value) => writer.Write(value);
            UInt32N IBinaryConvert<UInt32N>.Read(BinaryReader reader) => reader.ReadUInt32();

            bool INumericStatic<UInt32N>.HasFloatingPoint => false;
            bool INumericStatic<UInt32N>.HasInfinity => false;
            bool INumericStatic<UInt32N>.HasNaN => false;
            bool INumericStatic<UInt32N>.IsFinite(UInt32N x) => true;
            bool INumericStatic<UInt32N>.IsInfinity(UInt32N x) => false;
            bool INumericStatic<UInt32N>.IsNaN(UInt32N x) => false;
            bool INumericStatic<UInt32N>.IsNegative(UInt32N x) => false;
            bool INumericStatic<UInt32N>.IsNegativeInfinity(UInt32N x) => false;
            bool INumericStatic<UInt32N>.IsNormal(UInt32N x) => false;
            bool INumericStatic<UInt32N>.IsPositiveInfinity(UInt32N x) => false;
            bool INumericStatic<UInt32N>.IsReal => false;
            bool INumericStatic<UInt32N>.IsSigned => false;
            bool INumericStatic<UInt32N>.IsSubnormal(UInt32N x) => false;
            UInt32N INumericStatic<UInt32N>.Epsilon => (uint)1;
            UInt32N INumericStatic<UInt32N>.MaxUnit => (uint)1;
            UInt32N INumericStatic<UInt32N>.MaxValue => MaxValue;
            UInt32N INumericStatic<UInt32N>.MinUnit => (uint)0;
            UInt32N INumericStatic<UInt32N>.MinValue => MinValue;
            UInt32N INumericStatic<UInt32N>.One => (uint)1;
            UInt32N INumericStatic<UInt32N>.Zero => (uint)0;

            int IMath<UInt32N>.Sign(UInt32N x) => x._value == 0 ? 0 : 1;
            UInt32N IMath<UInt32N>.Abs(UInt32N value) => value._value;
            UInt32N IMath<UInt32N>.Acos(UInt32N x) => (uint)Math.Acos(x._value);
            UInt32N IMath<UInt32N>.Acosh(UInt32N x) => (uint)MathShim.Acosh(x._value);
            UInt32N IMath<UInt32N>.Asin(UInt32N x) => (uint)Math.Asin(x._value);
            UInt32N IMath<UInt32N>.Asinh(UInt32N x) => (uint)MathShim.Asinh(x._value);
            UInt32N IMath<UInt32N>.Atan(UInt32N x) => (uint)Math.Atan(x._value);
            UInt32N IMath<UInt32N>.Atan2(UInt32N x, UInt32N y) => (uint)Math.Atan2(x._value, y._value);
            UInt32N IMath<UInt32N>.Atanh(UInt32N x) => (uint)MathShim.Atanh(x._value);
            UInt32N IMath<UInt32N>.Cbrt(UInt32N x) => (uint)MathShim.Cbrt(x._value);
            UInt32N IMath<UInt32N>.Ceiling(UInt32N x) => x;
            UInt32N IMath<UInt32N>.Clamp(UInt32N x, UInt32N bound1, UInt32N bound2) => bound1 > bound2 ? Math.Min(bound1._value, Math.Max(bound2._value, x._value)) : Math.Min(bound2._value, Math.Max(bound1._value, x._value));
            UInt32N IMath<UInt32N>.Cos(UInt32N x) => (uint)Math.Cos(x._value);
            UInt32N IMath<UInt32N>.Cosh(UInt32N x) => (uint)Math.Cosh(x._value);
            UInt32N IMath<UInt32N>.E { get; } = (uint)2;
            UInt32N IMath<UInt32N>.Exp(UInt32N x) => (uint)Math.Exp(x._value);
            UInt32N IMath<UInt32N>.Floor(UInt32N x) => x;
            UInt32N IMath<UInt32N>.IEEERemainder(UInt32N x, UInt32N y) => (uint)Math.IEEERemainder(x._value, y._value);
            UInt32N IMath<UInt32N>.Log(UInt32N x) => (uint)Math.Log(x._value);
            UInt32N IMath<UInt32N>.Log(UInt32N x, UInt32N y) => (uint)Math.Log(x._value, y._value);
            UInt32N IMath<UInt32N>.Log10(UInt32N x) => (uint)Math.Log10(x._value);
            UInt32N IMath<UInt32N>.Max(UInt32N x, UInt32N y) => Math.Max(x._value, y._value);
            UInt32N IMath<UInt32N>.Min(UInt32N x, UInt32N y) => Math.Min(x._value, y._value);
            UInt32N IMath<UInt32N>.PI { get; } = (uint)3;
            UInt32N IMath<UInt32N>.Pow(UInt32N x, UInt32N y) => (uint)Math.Pow(x._value, y._value);
            UInt32N IMath<UInt32N>.Round(UInt32N x) => x;
            UInt32N IMath<UInt32N>.Round(UInt32N x, int digits) => x;
            UInt32N IMath<UInt32N>.Round(UInt32N x, int digits, MidpointRounding mode) => x;
            UInt32N IMath<UInt32N>.Round(UInt32N x, MidpointRounding mode) => x;
            UInt32N IMath<UInt32N>.Sin(UInt32N x) => (uint)Math.Sin(x._value);
            UInt32N IMath<UInt32N>.Sinh(UInt32N x) => (uint)Math.Sinh(x._value);
            UInt32N IMath<UInt32N>.Sqrt(UInt32N x) => (uint)Math.Sqrt(x._value);
            UInt32N IMath<UInt32N>.Tan(UInt32N x) => (uint)Math.Tan(x._value);
            UInt32N IMath<UInt32N>.Tanh(UInt32N x) => (uint)Math.Tanh(x._value);
            UInt32N IMath<UInt32N>.Tau { get; } = (uint)6;
            UInt32N IMath<UInt32N>.Truncate(UInt32N x) => x;

            int INumericBitConverter<UInt32N>.ConvertedSize => sizeof(uint);
            UInt32N INumericBitConverter<UInt32N>.ToNumeric(byte[] value, int startIndex) => BitConverter.ToUInt32(value, startIndex);
            byte[] INumericBitConverter<UInt32N>.GetBytes(UInt32N value) => BitConverter.GetBytes(value._value);
#if HAS_SPANS
            UInt32N INumericBitConverter<UInt32N>.ToNumeric(ReadOnlySpan<byte> value) => BitConverter.ToUInt32(value);
            bool INumericBitConverter<UInt32N>.TryWriteBytes(Span<byte> destination, UInt32N value) => BitConverter.TryWriteBytes(destination, value);
#endif

            bool IConvert<UInt32N>.ToBoolean(UInt32N value) => Convert.ToBoolean(value._value);
            byte IConvert<UInt32N>.ToByte(UInt32N value, Conversion mode) => ConvertN.ToByte(value._value, mode);
            decimal IConvert<UInt32N>.ToDecimal(UInt32N value, Conversion mode) => ConvertN.ToDecimal(value._value, mode);
            double IConvert<UInt32N>.ToDouble(UInt32N value, Conversion mode) => ConvertN.ToDouble(value._value, mode);
            float IConvert<UInt32N>.ToSingle(UInt32N value, Conversion mode) => ConvertN.ToSingle(value._value, mode);
            int IConvert<UInt32N>.ToInt32(UInt32N value, Conversion mode) => ConvertN.ToInt32(value._value, mode);
            long IConvert<UInt32N>.ToInt64(UInt32N value, Conversion mode) => ConvertN.ToInt64(value._value, mode);
            sbyte IConvertExtended<UInt32N>.ToSByte(UInt32N value, Conversion mode) => ConvertN.ToSByte(value._value, mode);
            short IConvert<UInt32N>.ToInt16(UInt32N value, Conversion mode) => ConvertN.ToInt16(value._value, mode);
            string IConvert<UInt32N>.ToString(UInt32N value) => Convert.ToString(value._value);
            uint IConvertExtended<UInt32N>.ToUInt32(UInt32N value, Conversion mode) => ConvertN.ToUInt32(value._value, mode);
            ulong IConvertExtended<UInt32N>.ToUInt64(UInt32N value, Conversion mode) => ConvertN.ToUInt64(value._value, mode);
            ushort IConvertExtended<UInt32N>.ToUInt16(UInt32N value, Conversion mode) => ConvertN.ToUInt16(value._value, mode);

            UInt32N IConvert<UInt32N>.ToNumeric(bool value) => Convert.ToUInt32(value);
            UInt32N IConvert<UInt32N>.ToNumeric(byte value, Conversion mode) => ConvertN.ToUInt32(value, mode);
            UInt32N IConvert<UInt32N>.ToNumeric(decimal value, Conversion mode) => ConvertN.ToUInt32(value, mode);
            UInt32N IConvert<UInt32N>.ToNumeric(double value, Conversion mode) => ConvertN.ToUInt32(value, mode);
            UInt32N IConvert<UInt32N>.ToNumeric(float value, Conversion mode) => ConvertN.ToUInt32(value, mode);
            UInt32N IConvert<UInt32N>.ToNumeric(int value, Conversion mode) => ConvertN.ToUInt32(value, mode);
            UInt32N IConvert<UInt32N>.ToNumeric(long value, Conversion mode) => ConvertN.ToUInt32(value, mode);
            UInt32N IConvertExtended<UInt32N>.ToValue(sbyte value, Conversion mode) => ConvertN.ToUInt32(value, mode);
            UInt32N IConvert<UInt32N>.ToNumeric(short value, Conversion mode) => ConvertN.ToUInt32(value, mode);
            UInt32N IConvert<UInt32N>.ToNumeric(string value) => Convert.ToUInt32(value);
            UInt32N IConvertExtended<UInt32N>.ToNumeric(uint value, Conversion mode) => ConvertN.ToUInt32(value, mode);
            UInt32N IConvertExtended<UInt32N>.ToNumeric(ulong value, Conversion mode) => ConvertN.ToUInt32(value, mode);
            UInt32N IConvertExtended<UInt32N>.ToNumeric(ushort value, Conversion mode) => ConvertN.ToUInt32(value, mode);

            UInt32N INumericStatic<UInt32N>.Parse(string s, NumberStyles? style, IFormatProvider? provider)
                => Parse(s, style ?? NumberStyles.Integer, provider);

            UInt32N INumericRandom<UInt32N>.Generate(Random random) => random.NextUInt32();
            UInt32N INumericRandom<UInt32N>.Generate(Random random, UInt32N maxValue) => random.NextUInt32(maxValue);
            UInt32N INumericRandom<UInt32N>.Generate(Random random, UInt32N minValue, UInt32N maxValue) => random.NextUInt32(minValue, maxValue);
            UInt32N INumericRandom<UInt32N>.Generate(Random random, Generation mode) => random.NextUInt32(mode);
            UInt32N INumericRandom<UInt32N>.Generate(Random random, UInt32N minValue, UInt32N maxValue, Generation mode) => random.NextUInt32(minValue, maxValue, mode);

            UInt32N IVariantRandom<UInt32N>.Generate(Random random, Variants variants) => random.NextUInt32(variants);
        }
    }
}
