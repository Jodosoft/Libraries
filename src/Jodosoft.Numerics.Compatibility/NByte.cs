// Copyright (c) 2023 Joe Lawry-Short
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
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using Jodosoft.Primitives;
using Jodosoft.Primitives.Compatibility;

namespace Jodosoft.Numerics.Compatibility
{
    /// <summary>
    /// Represents an 8-bit unsigned integer.
    /// </summary>
    [Serializable]
    [DebuggerDisplay("{ToString(),nq}")]
    [StructLayout(LayoutKind.Sequential)]
    public readonly struct NByte : INumericExtended<NByte>
    {
        public static readonly NByte MaxValue = new NByte(byte.MaxValue);
        public static readonly NByte MinValue = new NByte(byte.MinValue);

        private readonly byte _value;

        private NByte(byte value)
        {
            _value = value;
        }

        private NByte(SerializationInfo info, StreamingContext context) : this(info.GetByte(nameof(NByte))) { }
        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context) => info.AddValue(nameof(NByte), _value);

        public int CompareTo(NByte other) => _value.CompareTo(other._value);
        public int CompareTo(object? obj) => obj is NByte other ? CompareTo(other) : 1;
        public bool Equals(NByte other) => _value == other._value;
        public override bool Equals(object? obj) => obj is NByte other && Equals(other);
        public override int GetHashCode() => _value.GetHashCode();
        public override string ToString() => _value.ToString();
        public string ToString(IFormatProvider formatProvider) => _value.ToString(formatProvider);
        public string ToString(string format) => _value.ToString(format);
        public string ToString(string? format, IFormatProvider? formatProvider) => _value.ToString(format, formatProvider);

        public static bool TryParse(string s, IFormatProvider? provider, out NByte result) => FuncExtensions.Try(() => Parse(s, provider), out result);
        public static bool TryParse(string s, NumberStyles style, IFormatProvider? provider, out NByte result) => FuncExtensions.Try(() => Parse(s, style, provider), out result);
        public static bool TryParse(string s, NumberStyles style, out NByte result) => FuncExtensions.Try(() => Parse(s, style), out result);
        public static bool TryParse(string s, out NByte result) => FuncExtensions.Try(() => Parse(s), out result);
        public static NByte Parse(string s) => byte.Parse(s);
        public static NByte Parse(string s, IFormatProvider? provider) => byte.Parse(s, provider);
        public static NByte Parse(string s, NumberStyles style) => byte.Parse(s, style);
        public static NByte Parse(string s, NumberStyles style, IFormatProvider? provider) => byte.Parse(s, style, provider);

        [CLSCompliant(false)] public static explicit operator NByte(sbyte value) => new NByte((byte)value);
        [CLSCompliant(false)] public static explicit operator NByte(uint value) => new NByte((byte)value);
        [CLSCompliant(false)] public static explicit operator NByte(ulong value) => new NByte((byte)value);
        [CLSCompliant(false)] public static explicit operator NByte(ushort value) => new NByte((byte)value);
        public static explicit operator NByte(decimal value) => new NByte((byte)value);
        public static explicit operator NByte(double value) => new NByte((byte)value);
        public static explicit operator NByte(float value) => new NByte((byte)value);
        public static explicit operator NByte(int value) => new NByte((byte)value);
        public static explicit operator NByte(long value) => new NByte((byte)value);
        public static explicit operator NByte(short value) => new NByte((byte)value);
        public static implicit operator NByte(byte value) => new NByte(value);

        [CLSCompliant(false)] public static explicit operator sbyte(NByte value) => (sbyte)value._value;
        [CLSCompliant(false)] public static implicit operator uint(NByte value) => value._value;
        [CLSCompliant(false)] public static implicit operator ulong(NByte value) => value._value;
        [CLSCompliant(false)] public static implicit operator ushort(NByte value) => value._value;
        public static implicit operator byte(NByte value) => value._value;
        public static implicit operator decimal(NByte value) => value._value;
        public static implicit operator double(NByte value) => value._value;
        public static implicit operator float(NByte value) => value._value;
        public static implicit operator int(NByte value) => value._value;
        public static implicit operator long(NByte value) => value._value;
        public static implicit operator short(NByte value) => value._value;

        public static bool operator !=(NByte left, NByte right) => left._value != right._value;
        public static bool operator <(NByte left, NByte right) => left._value < right._value;
        public static bool operator <=(NByte left, NByte right) => left._value <= right._value;
        public static bool operator ==(NByte left, NByte right) => left._value == right._value;
        public static bool operator >(NByte left, NByte right) => left._value > right._value;
        public static bool operator >=(NByte left, NByte right) => left._value >= right._value;
        public static NByte operator %(NByte left, NByte right) => (byte)(left._value % right._value);
        public static NByte operator &(NByte left, NByte right) => (byte)(left._value & right._value);
        public static NByte operator -(NByte left, NByte right) => (byte)(left._value - right._value);
        public static NByte operator --(NByte value) => (byte)(value._value - 1);
        public static NByte operator *(NByte left, NByte right) => (byte)(left._value * right._value);
        public static NByte operator /(NByte left, NByte right) => (byte)(left._value / right._value);
        public static NByte operator ^(NByte left, NByte right) => (byte)(left._value ^ right._value);
        public static NByte operator |(NByte left, NByte right) => (byte)(left._value | right._value);
        public static NByte operator ~(NByte value) => (byte)~value._value;
        public static NByte operator +(NByte left, NByte right) => (byte)(left._value + right._value);
        public static NByte operator +(NByte value) => value;
        public static NByte operator ++(NByte value) => (byte)(value._value + 1);
        public static NByte operator <<(NByte left, int right) => (byte)(left._value << right);
        public static NByte operator >>(NByte left, int right) => (byte)(left._value >> right);

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

        bool INumeric<NByte>.IsGreaterThan(NByte value) => this > value;
        bool INumeric<NByte>.IsGreaterThanOrEqualTo(NByte value) => this >= value;
        bool INumeric<NByte>.IsLessThan(NByte value) => this < value;
        bool INumeric<NByte>.IsLessThanOrEqualTo(NByte value) => this <= value;
        NByte INumeric<NByte>.Add(NByte value) => this + value;
        NByte INumeric<NByte>.BitwiseComplement() => ~this;
        NByte INumeric<NByte>.Divide(NByte value) => this / value;
        NByte INumeric<NByte>.LeftShift(int count) => this << count;
        NByte INumeric<NByte>.LogicalAnd(NByte value) => this & value;
        NByte INumeric<NByte>.LogicalExclusiveOr(NByte value) => this ^ value;
        NByte INumeric<NByte>.LogicalOr(NByte value) => this | value;
        NByte INumeric<NByte>.Multiply(NByte value) => this * value;
        NByte INumeric<NByte>.Negative() => (NByte)(0 - _value);
        NByte INumeric<NByte>.Positive() => +this;
        NByte INumeric<NByte>.Remainder(NByte value) => this % value;
        NByte INumeric<NByte>.RightShift(int count) => this >> count;
        NByte INumeric<NByte>.Subtract(NByte value) => this - value;

        INumericBitConverter<NByte> IProvider<INumericBitConverter<NByte>>.GetInstance() => Utilities.Instance;
        IBinaryIO<NByte> IProvider<IBinaryIO<NByte>>.GetInstance() => Utilities.Instance;
        IConvert<NByte> IProvider<IConvert<NByte>>.GetInstance() => Utilities.Instance;
        IConvertExtended<NByte> IProvider<IConvertExtended<NByte>>.GetInstance() => Utilities.Instance;
        IMath<NByte> IProvider<IMath<NByte>>.GetInstance() => Utilities.Instance;
        INumericRandom<NByte> IProvider<INumericRandom<NByte>>.GetInstance() => Utilities.Instance;
        INumericStatic<NByte> IProvider<INumericStatic<NByte>>.GetInstance() => Utilities.Instance;
        IVariantRandom<NByte> IProvider<IVariantRandom<NByte>>.GetInstance() => Utilities.Instance;

        private sealed class Utilities :
            IBinaryIO<NByte>,
            IConvert<NByte>,
            IConvertExtended<NByte>,
            IMath<NByte>,
            INumericBitConverter<NByte>,
            INumericRandom<NByte>,
            INumericStatic<NByte>,
            IVariantRandom<NByte>
        {
            public static readonly Utilities Instance = new Utilities();

            void IBinaryIO<NByte>.Write(BinaryWriter writer, NByte value) => writer.Write(value);
            NByte IBinaryIO<NByte>.Read(BinaryReader reader) => reader.ReadByte();

            bool INumericStatic<NByte>.HasFloatingPoint => false;
            bool INumericStatic<NByte>.HasInfinity => false;
            bool INumericStatic<NByte>.HasNaN => false;
            bool INumericStatic<NByte>.IsFinite(NByte x) => true;
            bool INumericStatic<NByte>.IsInfinity(NByte x) => false;
            bool INumericStatic<NByte>.IsNaN(NByte x) => false;
            bool INumericStatic<NByte>.IsNegative(NByte x) => false;
            bool INumericStatic<NByte>.IsNegativeInfinity(NByte x) => false;
            bool INumericStatic<NByte>.IsNormal(NByte x) => false;
            bool INumericStatic<NByte>.IsPositiveInfinity(NByte x) => false;
            bool INumericStatic<NByte>.IsReal => false;
            bool INumericStatic<NByte>.IsSigned => false;
            bool INumericStatic<NByte>.IsSubnormal(NByte x) => false;
            NByte INumericStatic<NByte>.Epsilon => 1;
            NByte INumericStatic<NByte>.MaxUnit => 1;
            NByte INumericStatic<NByte>.MaxValue => MaxValue;
            NByte INumericStatic<NByte>.MinUnit => 0;
            NByte INumericStatic<NByte>.MinValue => MinValue;
            NByte INumericStatic<NByte>.One => 1;
            NByte INumericStatic<NByte>.Zero => 0;

            int IMath<NByte>.Sign(NByte x) => x._value == 0 ? 0 : 1;
            NByte IMath<NByte>.Abs(NByte value) => value._value;
            NByte IMath<NByte>.Acos(NByte x) => (byte)Math.Acos(x._value);
            NByte IMath<NByte>.Acosh(NByte x) => (byte)MathShim.Acosh(x._value);
            NByte IMath<NByte>.Asin(NByte x) => (byte)Math.Asin(x._value);
            NByte IMath<NByte>.Asinh(NByte x) => (byte)MathShim.Asinh(x._value);
            NByte IMath<NByte>.Atan(NByte x) => (byte)Math.Atan(x._value);
            NByte IMath<NByte>.Atan2(NByte x, NByte y) => (byte)Math.Atan2(x._value, y._value);
            NByte IMath<NByte>.Atanh(NByte x) => (byte)MathShim.Atanh(x._value);
            NByte IMath<NByte>.Cbrt(NByte x) => (byte)MathShim.Cbrt(x._value);
            NByte IMath<NByte>.Ceiling(NByte x) => x;
            NByte IMath<NByte>.Clamp(NByte x, NByte bound1, NByte bound2) => bound1 > bound2 ? Math.Min(bound1._value, Math.Max(bound2._value, x._value)) : Math.Min(bound2._value, Math.Max(bound1._value, x._value));
            NByte IMath<NByte>.Cos(NByte x) => (byte)Math.Cos(x._value);
            NByte IMath<NByte>.Cosh(NByte x) => (byte)Math.Cosh(x._value);
            NByte IMath<NByte>.E { get; } = 2;
            NByte IMath<NByte>.Exp(NByte x) => (byte)Math.Exp(x._value);
            NByte IMath<NByte>.Floor(NByte x) => x;
            NByte IMath<NByte>.IEEERemainder(NByte x, NByte y) => (byte)Math.IEEERemainder(x._value, y._value);
            NByte IMath<NByte>.Log(NByte x) => (byte)Math.Log(x._value);
            NByte IMath<NByte>.Log(NByte x, NByte y) => (byte)Math.Log(x._value, y._value);
            NByte IMath<NByte>.Log10(NByte x) => (byte)Math.Log10(x._value);
            NByte IMath<NByte>.Max(NByte x, NByte y) => Math.Max(x._value, y._value);
            NByte IMath<NByte>.Min(NByte x, NByte y) => Math.Min(x._value, y._value);
            NByte IMath<NByte>.PI { get; } = 3;
            NByte IMath<NByte>.Pow(NByte x, NByte y) => (byte)Math.Pow(x._value, y._value);
            NByte IMath<NByte>.Round(NByte x) => x;
            NByte IMath<NByte>.Round(NByte x, int digits) => x;
            NByte IMath<NByte>.Round(NByte x, int digits, MidpointRounding mode) => x;
            NByte IMath<NByte>.Round(NByte x, MidpointRounding mode) => x;
            NByte IMath<NByte>.Sin(NByte x) => (byte)Math.Sin(x._value);
            NByte IMath<NByte>.Sinh(NByte x) => (byte)Math.Sinh(x._value);
            NByte IMath<NByte>.Sqrt(NByte x) => (byte)Math.Sqrt(x._value);
            NByte IMath<NByte>.Tan(NByte x) => (byte)Math.Tan(x._value);
            NByte IMath<NByte>.Tanh(NByte x) => (byte)Math.Tanh(x._value);
            NByte IMath<NByte>.Tau { get; } = 6;
            NByte IMath<NByte>.Truncate(NByte x) => x;

            int INumericBitConverter<NByte>.ConvertedSize => sizeof(byte);
            NByte INumericBitConverter<NByte>.ToNumeric(byte[] value, int startIndex) => BitOperations.ToByte(value, startIndex);
            byte[] INumericBitConverter<NByte>.GetBytes(NByte value) => new byte[] { value._value };
#if HAS_SPANS
            NByte INumericBitConverter<NByte>.ToNumeric(ReadOnlySpan<byte> value) => BitOperations.ToByte(value);
            bool INumericBitConverter<NByte>.TryWriteBytes(Span<byte> destination, NByte value) => BitOperations.TryWriteByte(destination, value);
#endif

            bool IConvert<NByte>.ToBoolean(NByte value) => Convert.ToBoolean(value._value);
            byte IConvert<NByte>.ToByte(NByte value, Conversion mode) => ConvertN.ToByte(value._value, mode);
            decimal IConvert<NByte>.ToDecimal(NByte value, Conversion mode) => ConvertN.ToDecimal(value._value, mode);
            double IConvert<NByte>.ToDouble(NByte value, Conversion mode) => ConvertN.ToDouble(value._value, mode);
            float IConvert<NByte>.ToSingle(NByte value, Conversion mode) => ConvertN.ToSingle(value._value, mode);
            int IConvert<NByte>.ToInt32(NByte value, Conversion mode) => ConvertN.ToInt32(value._value, mode);
            long IConvert<NByte>.ToInt64(NByte value, Conversion mode) => ConvertN.ToInt64(value._value, mode);
            sbyte IConvertExtended<NByte>.ToSByte(NByte value, Conversion mode) => ConvertN.ToSByte(value._value, mode);
            short IConvert<NByte>.ToInt16(NByte value, Conversion mode) => ConvertN.ToInt16(value._value, mode);
            string IConvert<NByte>.ToString(NByte value) => Convert.ToString(value._value);
            uint IConvertExtended<NByte>.ToUInt32(NByte value, Conversion mode) => ConvertN.ToUInt32(value._value, mode);
            ulong IConvertExtended<NByte>.ToUInt64(NByte value, Conversion mode) => ConvertN.ToUInt64(value._value, mode);
            ushort IConvertExtended<NByte>.ToUInt16(NByte value, Conversion mode) => ConvertN.ToUInt16(value._value, mode);

            NByte IConvert<NByte>.ToNumeric(bool value) => Convert.ToByte(value);
            NByte IConvert<NByte>.ToNumeric(byte value, Conversion mode) => ConvertN.ToByte(value, mode);
            NByte IConvert<NByte>.ToNumeric(decimal value, Conversion mode) => ConvertN.ToByte(value, mode);
            NByte IConvert<NByte>.ToNumeric(double value, Conversion mode) => ConvertN.ToByte(value, mode);
            NByte IConvert<NByte>.ToNumeric(float value, Conversion mode) => ConvertN.ToByte(value, mode);
            NByte IConvert<NByte>.ToNumeric(int value, Conversion mode) => ConvertN.ToByte(value, mode);
            NByte IConvert<NByte>.ToNumeric(long value, Conversion mode) => ConvertN.ToByte(value, mode);
            NByte IConvertExtended<NByte>.ToValue(sbyte value, Conversion mode) => ConvertN.ToByte(value, mode);
            NByte IConvert<NByte>.ToNumeric(short value, Conversion mode) => ConvertN.ToByte(value, mode);
            NByte IConvert<NByte>.ToNumeric(string value) => Convert.ToByte(value);
            NByte IConvertExtended<NByte>.ToNumeric(uint value, Conversion mode) => ConvertN.ToByte(value, mode);
            NByte IConvertExtended<NByte>.ToNumeric(ulong value, Conversion mode) => ConvertN.ToByte(value, mode);
            NByte IConvertExtended<NByte>.ToNumeric(ushort value, Conversion mode) => ConvertN.ToByte(value, mode);

            NByte INumericStatic<NByte>.Parse(string s, NumberStyles? style, IFormatProvider? provider)
                => Parse(s, style ?? NumberStyles.Integer, provider);

            NByte INumericRandom<NByte>.Generate(Random random) => random.NextByte();
            NByte INumericRandom<NByte>.Generate(Random random, NByte maxValue) => random.NextByte(maxValue);
            NByte INumericRandom<NByte>.Generate(Random random, NByte minValue, NByte maxValue) => random.NextByte(minValue, maxValue);
            NByte INumericRandom<NByte>.Generate(Random random, Generation mode) => random.NextByte(mode);
            NByte INumericRandom<NByte>.Generate(Random random, NByte minValue, NByte maxValue, Generation mode) => random.NextByte(minValue, maxValue, mode);

            NByte IVariantRandom<NByte>.Generate(Random random, Variants variants) => random.NextByte(variants);
        }
    }
}
