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
using System.Runtime.Serialization;
using Jodosoft.Primitives;
using Jodosoft.Primitives.Compatibility;

namespace Jodosoft.Numerics.Compatibility
{
    /// <summary>
    /// Represents a 16-bit signed integer.
    /// </summary>
    [Serializable]
    [DebuggerDisplay("{ToString(),nq}")]
    public readonly struct NInt16 : INumericExtended<NInt16>
    {
        public static readonly NInt16 MaxValue = new NInt16(short.MaxValue);
        public static readonly NInt16 MinValue = new NInt16(short.MinValue);

        private readonly short _value;

        private NInt16(short value)
        {
            _value = value;
        }

        private NInt16(SerializationInfo info, StreamingContext context) : this(info.GetInt16(nameof(NInt16))) { }
        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context) => info.AddValue(nameof(NInt16), _value);

        public int CompareTo(NInt16 other) => _value.CompareTo(other._value);
        public int CompareTo(object? obj) => obj is NInt16 other ? CompareTo(other) : 1;
        public bool Equals(NInt16 other) => _value == other._value;
        public override bool Equals(object? obj) => obj is NInt16 other && Equals(other);
        public override int GetHashCode() => _value.GetHashCode();
        public override string ToString() => _value.ToString();
        public string ToString(IFormatProvider formatProvider) => _value.ToString(formatProvider);
        public string ToString(string format) => _value.ToString(format);
        public string ToString(string? format, IFormatProvider? formatProvider) => _value.ToString(format, formatProvider);

        public static bool TryParse(string s, IFormatProvider? provider, out NInt16 result) => FuncExtensions.Try(() => Parse(s, provider), out result);
        public static bool TryParse(string s, NumberStyles style, IFormatProvider? provider, out NInt16 result) => FuncExtensions.Try(() => Parse(s, style, provider), out result);
        public static bool TryParse(string s, NumberStyles style, out NInt16 result) => FuncExtensions.Try(() => Parse(s, style), out result);
        public static bool TryParse(string s, out NInt16 result) => FuncExtensions.Try(() => Parse(s), out result);
        public static NInt16 Parse(string s) => short.Parse(s);
        public static NInt16 Parse(string s, IFormatProvider? provider) => short.Parse(s, provider);
        public static NInt16 Parse(string s, NumberStyles style) => short.Parse(s, style);
        public static NInt16 Parse(string s, NumberStyles style, IFormatProvider? provider) => short.Parse(s, style, provider);

        [CLSCompliant(false)] public static explicit operator NInt16(uint value) => new NInt16((short)value);
        [CLSCompliant(false)] public static explicit operator NInt16(ulong value) => new NInt16((short)value);
        [CLSCompliant(false)] public static explicit operator NInt16(ushort value) => new NInt16((short)value);
        [CLSCompliant(false)] public static implicit operator NInt16(sbyte value) => new NInt16(value);
        public static explicit operator NInt16(decimal value) => new NInt16((short)value);
        public static explicit operator NInt16(double value) => new NInt16((short)value);
        public static explicit operator NInt16(float value) => new NInt16((short)value);
        public static explicit operator NInt16(int value) => new NInt16((short)value);
        public static explicit operator NInt16(long value) => new NInt16((short)value);
        public static implicit operator NInt16(byte value) => new NInt16(value);
        public static implicit operator NInt16(short value) => new NInt16(value);

        [CLSCompliant(false)] public static explicit operator sbyte(NInt16 value) => (sbyte)value._value;
        [CLSCompliant(false)] public static explicit operator uint(NInt16 value) => (uint)value._value;
        [CLSCompliant(false)] public static explicit operator ulong(NInt16 value) => (ulong)value._value;
        [CLSCompliant(false)] public static explicit operator ushort(NInt16 value) => (ushort)value._value;
        public static explicit operator byte(NInt16 value) => (byte)value._value;
        public static implicit operator decimal(NInt16 value) => value._value;
        public static implicit operator double(NInt16 value) => value._value;
        public static implicit operator float(NInt16 value) => value._value;
        public static implicit operator int(NInt16 value) => value._value;
        public static implicit operator long(NInt16 value) => value._value;
        public static implicit operator short(NInt16 value) => value._value;

        public static bool operator !=(NInt16 left, NInt16 right) => left._value != right._value;
        public static bool operator <(NInt16 left, NInt16 right) => left._value < right._value;
        public static bool operator <=(NInt16 left, NInt16 right) => left._value <= right._value;
        public static bool operator ==(NInt16 left, NInt16 right) => left._value == right._value;
        public static bool operator >(NInt16 left, NInt16 right) => left._value > right._value;
        public static bool operator >=(NInt16 left, NInt16 right) => left._value >= right._value;
        public static NInt16 operator %(NInt16 left, NInt16 right) => (short)(left._value % right._value);
        public static NInt16 operator &(NInt16 left, NInt16 right) => (short)(left._value & right._value);
        public static NInt16 operator -(NInt16 left, NInt16 right) => (short)(left._value - right._value);
        public static NInt16 operator --(NInt16 value) => (short)(value._value - 1);
        public static NInt16 operator -(NInt16 value) => (short)-value._value;
        public static NInt16 operator *(NInt16 left, NInt16 right) => (short)(left._value * right._value);
        public static NInt16 operator /(NInt16 left, NInt16 right) => (short)(left._value / right._value);
        public static NInt16 operator ^(NInt16 left, NInt16 right) => (short)(left._value ^ right._value);
        public static NInt16 operator |(NInt16 left, NInt16 right) => (short)(left._value | right._value);
        public static NInt16 operator ~(NInt16 value) => (short)~value._value;
        public static NInt16 operator +(NInt16 left, NInt16 right) => (short)(left._value + right._value);
        public static NInt16 operator +(NInt16 value) => value;
        public static NInt16 operator ++(NInt16 value) => (short)(value._value + 1);
        public static NInt16 operator <<(NInt16 left, int right) => (short)(left._value << right);
        public static NInt16 operator >>(NInt16 left, int right) => (short)(left._value >> right);

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

        bool INumeric<NInt16>.IsGreaterThan(NInt16 value) => this > value;
        bool INumeric<NInt16>.IsGreaterThanOrEqualTo(NInt16 value) => this >= value;
        bool INumeric<NInt16>.IsLessThan(NInt16 value) => this < value;
        bool INumeric<NInt16>.IsLessThanOrEqualTo(NInt16 value) => this <= value;
        NInt16 INumeric<NInt16>.Add(NInt16 value) => this + value;
        NInt16 INumeric<NInt16>.BitwiseComplement() => ~this;
        NInt16 INumeric<NInt16>.Divide(NInt16 value) => this / value;
        NInt16 INumeric<NInt16>.LeftShift(int count) => this << count;
        NInt16 INumeric<NInt16>.LogicalAnd(NInt16 value) => this & value;
        NInt16 INumeric<NInt16>.LogicalExclusiveOr(NInt16 value) => this ^ value;
        NInt16 INumeric<NInt16>.LogicalOr(NInt16 value) => this | value;
        NInt16 INumeric<NInt16>.Multiply(NInt16 value) => this * value;
        NInt16 INumeric<NInt16>.Negative() => -this;
        NInt16 INumeric<NInt16>.Positive() => +this;
        NInt16 INumeric<NInt16>.Remainder(NInt16 value) => this % value;
        NInt16 INumeric<NInt16>.RightShift(int count) => this >> count;
        NInt16 INumeric<NInt16>.Subtract(NInt16 value) => this - value;

        INumericBitConverter<NInt16> IProvider<INumericBitConverter<NInt16>>.GetInstance() => Utilities.Instance;
        IBinaryIO<NInt16> IProvider<IBinaryIO<NInt16>>.GetInstance() => Utilities.Instance;
        IConvert<NInt16> IProvider<IConvert<NInt16>>.GetInstance() => Utilities.Instance;
        IConvertExtended<NInt16> IProvider<IConvertExtended<NInt16>>.GetInstance() => Utilities.Instance;
        IMath<NInt16> IProvider<IMath<NInt16>>.GetInstance() => Utilities.Instance;
        INumericStatic<NInt16> IProvider<INumericStatic<NInt16>>.GetInstance() => Utilities.Instance;
        INumericRandom<NInt16> IProvider<INumericRandom<NInt16>>.GetInstance() => Utilities.Instance;
        IVariantRandom<NInt16> IProvider<IVariantRandom<NInt16>>.GetInstance() => Utilities.Instance;

        private sealed class Utilities :
            IBinaryIO<NInt16>,
            IConvert<NInt16>,
            IConvertExtended<NInt16>,
            IMath<NInt16>,
            INumericBitConverter<NInt16>,
            INumericRandom<NInt16>,
            INumericStatic<NInt16>,
            IVariantRandom<NInt16>
        {
            public static readonly Utilities Instance = new Utilities();

            void IBinaryIO<NInt16>.Write(BinaryWriter writer, NInt16 value) => writer.Write(value);
            NInt16 IBinaryIO<NInt16>.Read(BinaryReader reader) => reader.ReadInt16();

            bool INumericStatic<NInt16>.HasFloatingPoint => false;
            bool INumericStatic<NInt16>.HasInfinity => false;
            bool INumericStatic<NInt16>.HasNaN => false;
            bool INumericStatic<NInt16>.IsFinite(NInt16 x) => true;
            bool INumericStatic<NInt16>.IsInfinity(NInt16 x) => false;
            bool INumericStatic<NInt16>.IsNaN(NInt16 x) => false;
            bool INumericStatic<NInt16>.IsNegative(NInt16 x) => x._value < 0;
            bool INumericStatic<NInt16>.IsNegativeInfinity(NInt16 x) => false;
            bool INumericStatic<NInt16>.IsNormal(NInt16 x) => false;
            bool INumericStatic<NInt16>.IsPositiveInfinity(NInt16 x) => false;
            bool INumericStatic<NInt16>.IsReal => false;
            bool INumericStatic<NInt16>.IsSigned => true;
            bool INumericStatic<NInt16>.IsSubnormal(NInt16 x) => false;
            NInt16 INumericStatic<NInt16>.Epsilon => (short)1;
            NInt16 INumericStatic<NInt16>.MaxUnit => (short)1;
            NInt16 INumericStatic<NInt16>.MaxValue => MaxValue;
            NInt16 INumericStatic<NInt16>.MinUnit => (short)-1;
            NInt16 INumericStatic<NInt16>.MinValue => MinValue;
            NInt16 INumericStatic<NInt16>.One => (short)1;
            NInt16 INumericStatic<NInt16>.Zero => (short)0;

            int IMath<NInt16>.Sign(NInt16 x) => Math.Sign(x._value);
            NInt16 IMath<NInt16>.Abs(NInt16 value) => Math.Abs(value._value);
            NInt16 IMath<NInt16>.Acos(NInt16 x) => (short)Math.Acos(x._value);
            NInt16 IMath<NInt16>.Acosh(NInt16 x) => (short)MathShim.Acosh(x._value);
            NInt16 IMath<NInt16>.Asin(NInt16 x) => (short)Math.Asin(x._value);
            NInt16 IMath<NInt16>.Asinh(NInt16 x) => (short)MathShim.Asinh(x._value);
            NInt16 IMath<NInt16>.Atan(NInt16 x) => (short)Math.Atan(x._value);
            NInt16 IMath<NInt16>.Atan2(NInt16 x, NInt16 y) => (short)Math.Atan2(x._value, y._value);
            NInt16 IMath<NInt16>.Atanh(NInt16 x) => (short)MathShim.Atanh(x._value);
            NInt16 IMath<NInt16>.Cbrt(NInt16 x) => (short)MathShim.Cbrt(x._value);
            NInt16 IMath<NInt16>.Ceiling(NInt16 x) => x;
            NInt16 IMath<NInt16>.Clamp(NInt16 x, NInt16 bound1, NInt16 bound2) => bound1 > bound2 ? Math.Min(bound1._value, Math.Max(bound2._value, x._value)) : Math.Min(bound2._value, Math.Max(bound1._value, x._value));
            NInt16 IMath<NInt16>.Cos(NInt16 x) => (short)Math.Cos(x._value);
            NInt16 IMath<NInt16>.Cosh(NInt16 x) => (short)Math.Cosh(x._value);
            NInt16 IMath<NInt16>.E { get; } = (short)2;
            NInt16 IMath<NInt16>.Exp(NInt16 x) => (short)Math.Exp(x._value);
            NInt16 IMath<NInt16>.Floor(NInt16 x) => x;
            NInt16 IMath<NInt16>.IEEERemainder(NInt16 x, NInt16 y) => (short)Math.IEEERemainder(x._value, y._value);
            NInt16 IMath<NInt16>.Log(NInt16 x) => (short)Math.Log(x._value);
            NInt16 IMath<NInt16>.Log(NInt16 x, NInt16 y) => (short)Math.Log(x._value, y._value);
            NInt16 IMath<NInt16>.Log10(NInt16 x) => (short)Math.Log10(x._value);
            NInt16 IMath<NInt16>.Max(NInt16 x, NInt16 y) => Math.Max(x._value, y._value);
            NInt16 IMath<NInt16>.Min(NInt16 x, NInt16 y) => Math.Min(x._value, y._value);
            NInt16 IMath<NInt16>.PI { get; } = (short)3;
            NInt16 IMath<NInt16>.Pow(NInt16 x, NInt16 y) => (short)Math.Pow(x._value, y._value);
            NInt16 IMath<NInt16>.Round(NInt16 x) => x;
            NInt16 IMath<NInt16>.Round(NInt16 x, int digits) => x;
            NInt16 IMath<NInt16>.Round(NInt16 x, int digits, MidpointRounding mode) => x;
            NInt16 IMath<NInt16>.Round(NInt16 x, MidpointRounding mode) => x;
            NInt16 IMath<NInt16>.Sin(NInt16 x) => (short)Math.Sin(x._value);
            NInt16 IMath<NInt16>.Sinh(NInt16 x) => (short)Math.Sinh(x._value);
            NInt16 IMath<NInt16>.Sqrt(NInt16 x) => (short)Math.Sqrt(x._value);
            NInt16 IMath<NInt16>.Tan(NInt16 x) => (short)Math.Tan(x._value);
            NInt16 IMath<NInt16>.Tanh(NInt16 x) => (short)Math.Tanh(x._value);
            NInt16 IMath<NInt16>.Tau { get; } = (short)6;
            NInt16 IMath<NInt16>.Truncate(NInt16 x) => x;

            int INumericBitConverter<NInt16>.ConvertedSize => sizeof(short);
            NInt16 INumericBitConverter<NInt16>.ToNumeric(byte[] value, int startIndex) => BitConverter.ToInt16(value, startIndex);
            byte[] INumericBitConverter<NInt16>.GetBytes(NInt16 value) => BitConverter.GetBytes(value._value);
#if HAS_SPANS
            NInt16 INumericBitConverter<NInt16>.ToNumeric(ReadOnlySpan<byte> value) => BitConverter.ToInt16(value);
            bool INumericBitConverter<NInt16>.TryWriteBytes(Span<byte> destination, NInt16 value) => BitConverter.TryWriteBytes(destination, value);
#endif

            bool IConvert<NInt16>.ToBoolean(NInt16 value) => Convert.ToBoolean(value._value);
            byte IConvert<NInt16>.ToByte(NInt16 value, Conversion mode) => ConvertN.ToByte(value._value, mode);
            decimal IConvert<NInt16>.ToDecimal(NInt16 value, Conversion mode) => ConvertN.ToDecimal(value._value, mode);
            double IConvert<NInt16>.ToDouble(NInt16 value, Conversion mode) => ConvertN.ToDouble(value._value, mode);
            float IConvert<NInt16>.ToSingle(NInt16 value, Conversion mode) => ConvertN.ToSingle(value._value, mode);
            int IConvert<NInt16>.ToInt32(NInt16 value, Conversion mode) => ConvertN.ToInt32(value._value, mode);
            long IConvert<NInt16>.ToInt64(NInt16 value, Conversion mode) => ConvertN.ToInt64(value._value, mode);
            sbyte IConvertExtended<NInt16>.ToSByte(NInt16 value, Conversion mode) => ConvertN.ToSByte(value._value, mode);
            short IConvert<NInt16>.ToInt16(NInt16 value, Conversion mode) => ConvertN.ToInt16(value._value, mode);
            string IConvert<NInt16>.ToString(NInt16 value) => Convert.ToString(value._value);
            uint IConvertExtended<NInt16>.ToUInt32(NInt16 value, Conversion mode) => ConvertN.ToUInt32(value._value, mode);
            ulong IConvertExtended<NInt16>.ToUInt64(NInt16 value, Conversion mode) => ConvertN.ToUInt64(value._value, mode);
            ushort IConvertExtended<NInt16>.ToUInt16(NInt16 value, Conversion mode) => ConvertN.ToUInt16(value._value, mode);

            NInt16 IConvert<NInt16>.ToNumeric(bool value) => Convert.ToInt16(value);
            NInt16 IConvert<NInt16>.ToNumeric(byte value, Conversion mode) => ConvertN.ToInt16(value, mode);
            NInt16 IConvert<NInt16>.ToNumeric(decimal value, Conversion mode) => ConvertN.ToInt16(value, mode);
            NInt16 IConvert<NInt16>.ToNumeric(double value, Conversion mode) => ConvertN.ToInt16(value, mode);
            NInt16 IConvert<NInt16>.ToNumeric(float value, Conversion mode) => ConvertN.ToInt16(value, mode);
            NInt16 IConvert<NInt16>.ToNumeric(int value, Conversion mode) => ConvertN.ToInt16(value, mode);
            NInt16 IConvert<NInt16>.ToNumeric(long value, Conversion mode) => ConvertN.ToInt16(value, mode);
            NInt16 IConvertExtended<NInt16>.ToValue(sbyte value, Conversion mode) => ConvertN.ToInt16(value, mode);
            NInt16 IConvert<NInt16>.ToNumeric(short value, Conversion mode) => ConvertN.ToInt16(value, mode);
            NInt16 IConvert<NInt16>.ToNumeric(string value) => Convert.ToInt16(value);
            NInt16 IConvertExtended<NInt16>.ToNumeric(uint value, Conversion mode) => ConvertN.ToInt16(value, mode);
            NInt16 IConvertExtended<NInt16>.ToNumeric(ulong value, Conversion mode) => ConvertN.ToInt16(value, mode);
            NInt16 IConvertExtended<NInt16>.ToNumeric(ushort value, Conversion mode) => ConvertN.ToInt16(value, mode);

            NInt16 INumericStatic<NInt16>.Parse(string s, NumberStyles? style, IFormatProvider? provider)
                => Parse(s, style ?? NumberStyles.Integer, provider);

            NInt16 INumericRandom<NInt16>.Generate(Random random) => random.NextInt16();
            NInt16 INumericRandom<NInt16>.Generate(Random random, NInt16 maxValue) => random.NextInt16(maxValue);
            NInt16 INumericRandom<NInt16>.Generate(Random random, NInt16 minValue, NInt16 maxValue) => random.NextInt16(minValue, maxValue);
            NInt16 INumericRandom<NInt16>.Generate(Random random, Generation mode) => random.NextInt16(mode);
            NInt16 INumericRandom<NInt16>.Generate(Random random, NInt16 minValue, NInt16 maxValue, Generation mode) => random.NextInt16(minValue, maxValue, mode);

            NInt16 IVariantRandom<NInt16>.Generate(Random random, Variants variants) => random.NextInt16(variants);
        }
    }
}
