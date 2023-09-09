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
    /// Represents a 16-bit unsigned integer.
    /// </summary>
    [Serializable]
    [DebuggerDisplay("{ToString(),nq}")]
    public readonly struct NUInt16 : INumericExtended<NUInt16>
    {
        public static readonly NUInt16 MaxValue = new NUInt16(ushort.MaxValue);
        public static readonly NUInt16 MinValue = new NUInt16(ushort.MinValue);

        private readonly ushort _value;

        private NUInt16(ushort value)
        {
            _value = value;
        }

        private NUInt16(SerializationInfo info, StreamingContext context) : this(info.GetUInt16(nameof(NUInt16))) { }
        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context) => info.AddValue(nameof(NUInt16), _value);

        public int CompareTo(NUInt16 other) => _value.CompareTo(other._value);
        public int CompareTo(object? obj) => obj is NUInt16 other ? CompareTo(other) : 1;
        public bool Equals(NUInt16 other) => _value == other._value;
        public override bool Equals(object? obj) => obj is NUInt16 other && Equals(other);
        public override int GetHashCode() => _value.GetHashCode();
        public override string ToString() => _value.ToString();
        public string ToString(IFormatProvider formatProvider) => _value.ToString(formatProvider);
        public string ToString(string format) => _value.ToString(format);
        public string ToString(string? format, IFormatProvider? formatProvider) => _value.ToString(format, formatProvider);

        public static bool TryParse(string s, IFormatProvider? provider, out NUInt16 result) => FuncExtensions.Try(() => Parse(s, provider), out result);
        public static bool TryParse(string s, NumberStyles style, IFormatProvider? provider, out NUInt16 result) => FuncExtensions.Try(() => Parse(s, style, provider), out result);
        public static bool TryParse(string s, NumberStyles style, out NUInt16 result) => FuncExtensions.Try(() => Parse(s, style), out result);
        public static bool TryParse(string s, out NUInt16 result) => FuncExtensions.Try(() => Parse(s), out result);
        public static NUInt16 Parse(string s) => ushort.Parse(s);
        public static NUInt16 Parse(string s, IFormatProvider? provider) => ushort.Parse(s, provider);
        public static NUInt16 Parse(string s, NumberStyles style) => ushort.Parse(s, style);
        public static NUInt16 Parse(string s, NumberStyles style, IFormatProvider? provider) => ushort.Parse(s, style, provider);

        [CLSCompliant(false)] public static explicit operator NUInt16(sbyte value) => new NUInt16((ushort)value);
        [CLSCompliant(false)] public static explicit operator NUInt16(uint value) => new NUInt16((ushort)value);
        [CLSCompliant(false)] public static explicit operator NUInt16(ulong value) => new NUInt16((ushort)value);
        [CLSCompliant(false)] public static implicit operator NUInt16(ushort value) => new NUInt16(value);
        public static explicit operator NUInt16(decimal value) => new NUInt16((ushort)value);
        public static explicit operator NUInt16(double value) => new NUInt16((ushort)value);
        public static explicit operator NUInt16(float value) => new NUInt16((ushort)value);
        public static explicit operator NUInt16(int value) => new NUInt16((ushort)value);
        public static explicit operator NUInt16(long value) => new NUInt16((ushort)value);
        public static explicit operator NUInt16(short value) => new NUInt16((ushort)value);
        public static implicit operator NUInt16(byte value) => new NUInt16(value);

        [CLSCompliant(false)] public static explicit operator sbyte(NUInt16 value) => (sbyte)value._value;
        [CLSCompliant(false)] public static implicit operator uint(NUInt16 value) => value._value;
        [CLSCompliant(false)] public static implicit operator ulong(NUInt16 value) => value._value;
        [CLSCompliant(false)] public static implicit operator ushort(NUInt16 value) => value._value;
        public static explicit operator byte(NUInt16 value) => (byte)value._value;
        public static explicit operator short(NUInt16 value) => (short)value._value;
        public static implicit operator decimal(NUInt16 value) => value._value;
        public static implicit operator double(NUInt16 value) => value._value;
        public static implicit operator float(NUInt16 value) => value._value;
        public static implicit operator int(NUInt16 value) => value._value;
        public static implicit operator long(NUInt16 value) => value._value;

        public static bool operator !=(NUInt16 left, NUInt16 right) => left._value != right._value;
        public static bool operator <(NUInt16 left, NUInt16 right) => left._value < right._value;
        public static bool operator <=(NUInt16 left, NUInt16 right) => left._value <= right._value;
        public static bool operator ==(NUInt16 left, NUInt16 right) => left._value == right._value;
        public static bool operator >(NUInt16 left, NUInt16 right) => left._value > right._value;
        public static bool operator >=(NUInt16 left, NUInt16 right) => left._value >= right._value;
        public static NUInt16 operator %(NUInt16 left, NUInt16 right) => (ushort)(left._value % right._value);
        public static NUInt16 operator &(NUInt16 left, NUInt16 right) => (ushort)(left._value & right._value);
        public static NUInt16 operator -(NUInt16 left, NUInt16 right) => (ushort)(left._value - right._value);
        public static NUInt16 operator --(NUInt16 value) => (ushort)(value._value - 1);
        public static NUInt16 operator *(NUInt16 left, NUInt16 right) => (ushort)(left._value * right._value);
        public static NUInt16 operator /(NUInt16 left, NUInt16 right) => (ushort)(left._value / right._value);
        public static NUInt16 operator ^(NUInt16 left, NUInt16 right) => (ushort)(left._value ^ right._value);
        public static NUInt16 operator |(NUInt16 left, NUInt16 right) => (ushort)(left._value | right._value);
        public static NUInt16 operator ~(NUInt16 value) => (ushort)~value._value;
        public static NUInt16 operator +(NUInt16 left, NUInt16 right) => (ushort)(left._value + right._value);
        public static NUInt16 operator +(NUInt16 value) => value;
        public static NUInt16 operator ++(NUInt16 value) => (ushort)(value._value + 1);
        public static NUInt16 operator <<(NUInt16 left, int right) => (ushort)(left._value << right);
        public static NUInt16 operator >>(NUInt16 left, int right) => (ushort)(left._value >> right);

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

        bool INumeric<NUInt16>.IsGreaterThan(NUInt16 value) => this > value;
        bool INumeric<NUInt16>.IsGreaterThanOrEqualTo(NUInt16 value) => this >= value;
        bool INumeric<NUInt16>.IsLessThan(NUInt16 value) => this < value;
        bool INumeric<NUInt16>.IsLessThanOrEqualTo(NUInt16 value) => this <= value;
        NUInt16 INumeric<NUInt16>.Add(NUInt16 value) => this + value;
        NUInt16 INumeric<NUInt16>.BitwiseComplement() => ~this;
        NUInt16 INumeric<NUInt16>.Divide(NUInt16 value) => this / value;
        NUInt16 INumeric<NUInt16>.LeftShift(int count) => this << count;
        NUInt16 INumeric<NUInt16>.LogicalAnd(NUInt16 value) => this & value;
        NUInt16 INumeric<NUInt16>.LogicalExclusiveOr(NUInt16 value) => this ^ value;
        NUInt16 INumeric<NUInt16>.LogicalOr(NUInt16 value) => this | value;
        NUInt16 INumeric<NUInt16>.Multiply(NUInt16 value) => this * value;
        NUInt16 INumeric<NUInt16>.Negative() => (NUInt16)(0 - _value);
        NUInt16 INumeric<NUInt16>.Positive() => +this;
        NUInt16 INumeric<NUInt16>.Remainder(NUInt16 value) => this % value;
        NUInt16 INumeric<NUInt16>.RightShift(int count) => this >> count;
        NUInt16 INumeric<NUInt16>.Subtract(NUInt16 value) => this - value;

        INumericBitConverter<NUInt16> IProvider<INumericBitConverter<NUInt16>>.GetInstance() => Utilities.Instance;
        IBinaryIO<NUInt16> IProvider<IBinaryIO<NUInt16>>.GetInstance() => Utilities.Instance;
        IConvert<NUInt16> IProvider<IConvert<NUInt16>>.GetInstance() => Utilities.Instance;
        IConvertExtended<NUInt16> IProvider<IConvertExtended<NUInt16>>.GetInstance() => Utilities.Instance;
        IMath<NUInt16> IProvider<IMath<NUInt16>>.GetInstance() => Utilities.Instance;
        INumericStatic<NUInt16> IProvider<INumericStatic<NUInt16>>.GetInstance() => Utilities.Instance;
        INumericRandom<NUInt16> IProvider<INumericRandom<NUInt16>>.GetInstance() => Utilities.Instance;
        IVariantRandom<NUInt16> IProvider<IVariantRandom<NUInt16>>.GetInstance() => Utilities.Instance;

        private sealed class Utilities :
            IBinaryIO<NUInt16>,
            IConvert<NUInt16>,
            IConvertExtended<NUInt16>,
            IMath<NUInt16>,
            INumericBitConverter<NUInt16>,
            INumericRandom<NUInt16>,
            INumericStatic<NUInt16>,
            IVariantRandom<NUInt16>
        {
            public static readonly Utilities Instance = new Utilities();

            void IBinaryIO<NUInt16>.Write(BinaryWriter writer, NUInt16 value) => writer.Write(value);
            NUInt16 IBinaryIO<NUInt16>.Read(BinaryReader reader) => reader.ReadUInt16();

            bool INumericStatic<NUInt16>.HasFloatingPoint => false;
            bool INumericStatic<NUInt16>.HasInfinity => false;
            bool INumericStatic<NUInt16>.HasNaN => false;
            bool INumericStatic<NUInt16>.IsFinite(NUInt16 x) => true;
            bool INumericStatic<NUInt16>.IsInfinity(NUInt16 x) => false;
            bool INumericStatic<NUInt16>.IsNaN(NUInt16 x) => false;
            bool INumericStatic<NUInt16>.IsNegative(NUInt16 x) => false;
            bool INumericStatic<NUInt16>.IsNegativeInfinity(NUInt16 x) => false;
            bool INumericStatic<NUInt16>.IsNormal(NUInt16 x) => false;
            bool INumericStatic<NUInt16>.IsPositiveInfinity(NUInt16 x) => false;
            bool INumericStatic<NUInt16>.IsReal => false;
            bool INumericStatic<NUInt16>.IsSigned => false;
            bool INumericStatic<NUInt16>.IsSubnormal(NUInt16 x) => false;
            NUInt16 INumericStatic<NUInt16>.Epsilon => (ushort)1;
            NUInt16 INumericStatic<NUInt16>.MaxUnit => (ushort)1;
            NUInt16 INumericStatic<NUInt16>.MaxValue => MaxValue;
            NUInt16 INumericStatic<NUInt16>.MinUnit => (ushort)0;
            NUInt16 INumericStatic<NUInt16>.MinValue => MinValue;
            NUInt16 INumericStatic<NUInt16>.One => (ushort)1;
            NUInt16 INumericStatic<NUInt16>.Zero => (ushort)0;

            int IMath<NUInt16>.Sign(NUInt16 x) => x._value == 0 ? 0 : 1;
            NUInt16 IMath<NUInt16>.Abs(NUInt16 value) => value._value;
            NUInt16 IMath<NUInt16>.Acos(NUInt16 x) => (ushort)Math.Acos(x._value);
            NUInt16 IMath<NUInt16>.Acosh(NUInt16 x) => (ushort)MathShim.Acosh(x._value);
            NUInt16 IMath<NUInt16>.Asin(NUInt16 x) => (ushort)Math.Asin(x._value);
            NUInt16 IMath<NUInt16>.Asinh(NUInt16 x) => (ushort)MathShim.Asinh(x._value);
            NUInt16 IMath<NUInt16>.Atan(NUInt16 x) => (ushort)Math.Atan(x._value);
            NUInt16 IMath<NUInt16>.Atan2(NUInt16 x, NUInt16 y) => (ushort)Math.Atan2(x._value, y._value);
            NUInt16 IMath<NUInt16>.Atanh(NUInt16 x) => (ushort)MathShim.Atanh(x._value);
            NUInt16 IMath<NUInt16>.Cbrt(NUInt16 x) => (ushort)MathShim.Cbrt(x._value);
            NUInt16 IMath<NUInt16>.Ceiling(NUInt16 x) => x;
            NUInt16 IMath<NUInt16>.Clamp(NUInt16 x, NUInt16 bound1, NUInt16 bound2) => bound1 > bound2 ? Math.Min(bound1._value, Math.Max(bound2._value, x._value)) : Math.Min(bound2._value, Math.Max(bound1._value, x._value));
            NUInt16 IMath<NUInt16>.Cos(NUInt16 x) => (ushort)Math.Cos(x._value);
            NUInt16 IMath<NUInt16>.Cosh(NUInt16 x) => (ushort)Math.Cosh(x._value);
            NUInt16 IMath<NUInt16>.E { get; } = (ushort)2;
            NUInt16 IMath<NUInt16>.Exp(NUInt16 x) => (ushort)Math.Exp(x._value);
            NUInt16 IMath<NUInt16>.Floor(NUInt16 x) => x;
            NUInt16 IMath<NUInt16>.IEEERemainder(NUInt16 x, NUInt16 y) => (ushort)Math.IEEERemainder(x._value, y._value);
            NUInt16 IMath<NUInt16>.Log(NUInt16 x) => (ushort)Math.Log(x._value);
            NUInt16 IMath<NUInt16>.Log(NUInt16 x, NUInt16 y) => (ushort)Math.Log(x._value, y._value);
            NUInt16 IMath<NUInt16>.Log10(NUInt16 x) => (ushort)Math.Log10(x._value);
            NUInt16 IMath<NUInt16>.Max(NUInt16 x, NUInt16 y) => Math.Max(x._value, y._value);
            NUInt16 IMath<NUInt16>.Min(NUInt16 x, NUInt16 y) => Math.Min(x._value, y._value);
            NUInt16 IMath<NUInt16>.PI { get; } = (ushort)3;
            NUInt16 IMath<NUInt16>.Pow(NUInt16 x, NUInt16 y) => (ushort)Math.Pow(x._value, y._value);
            NUInt16 IMath<NUInt16>.Round(NUInt16 x) => x;
            NUInt16 IMath<NUInt16>.Round(NUInt16 x, int digits) => x;
            NUInt16 IMath<NUInt16>.Round(NUInt16 x, int digits, MidpointRounding mode) => x;
            NUInt16 IMath<NUInt16>.Round(NUInt16 x, MidpointRounding mode) => x;
            NUInt16 IMath<NUInt16>.Sin(NUInt16 x) => (ushort)Math.Sin(x._value);
            NUInt16 IMath<NUInt16>.Sinh(NUInt16 x) => (ushort)Math.Sinh(x._value);
            NUInt16 IMath<NUInt16>.Sqrt(NUInt16 x) => (ushort)Math.Sqrt(x._value);
            NUInt16 IMath<NUInt16>.Tan(NUInt16 x) => (ushort)Math.Tan(x._value);
            NUInt16 IMath<NUInt16>.Tanh(NUInt16 x) => (ushort)Math.Tanh(x._value);
            NUInt16 IMath<NUInt16>.Tau { get; } = (ushort)6;
            NUInt16 IMath<NUInt16>.Truncate(NUInt16 x) => x;

            int INumericBitConverter<NUInt16>.ConvertedSize => sizeof(ushort);
            NUInt16 INumericBitConverter<NUInt16>.ToNumeric(byte[] value, int startIndex) => BitConverter.ToUInt16(value, startIndex);
            byte[] INumericBitConverter<NUInt16>.GetBytes(NUInt16 value) => BitConverter.GetBytes(value._value);
#if HAS_SPANS
            NUInt16 INumericBitConverter<NUInt16>.ToNumeric(ReadOnlySpan<byte> value) => BitConverter.ToUInt16(value);
            bool INumericBitConverter<NUInt16>.TryWriteBytes(Span<byte> destination, NUInt16 value) => BitConverter.TryWriteBytes(destination, value);
#endif

            bool IConvert<NUInt16>.ToBoolean(NUInt16 value) => Convert.ToBoolean(value._value);
            byte IConvert<NUInt16>.ToByte(NUInt16 value, Conversion mode) => ConvertN.ToByte(value._value, mode);
            decimal IConvert<NUInt16>.ToDecimal(NUInt16 value, Conversion mode) => ConvertN.ToDecimal(value._value, mode);
            double IConvert<NUInt16>.ToDouble(NUInt16 value, Conversion mode) => ConvertN.ToDouble(value._value, mode);
            float IConvert<NUInt16>.ToSingle(NUInt16 value, Conversion mode) => ConvertN.ToSingle(value._value, mode);
            int IConvert<NUInt16>.ToInt32(NUInt16 value, Conversion mode) => ConvertN.ToInt32(value._value, mode);
            long IConvert<NUInt16>.ToInt64(NUInt16 value, Conversion mode) => ConvertN.ToInt64(value._value, mode);
            sbyte IConvertExtended<NUInt16>.ToSByte(NUInt16 value, Conversion mode) => ConvertN.ToSByte(value._value, mode);
            short IConvert<NUInt16>.ToInt16(NUInt16 value, Conversion mode) => ConvertN.ToInt16(value._value, mode);
            string IConvert<NUInt16>.ToString(NUInt16 value) => Convert.ToString(value._value);
            uint IConvertExtended<NUInt16>.ToUInt32(NUInt16 value, Conversion mode) => ConvertN.ToUInt32(value._value, mode);
            ulong IConvertExtended<NUInt16>.ToUInt64(NUInt16 value, Conversion mode) => ConvertN.ToUInt64(value._value, mode);
            ushort IConvertExtended<NUInt16>.ToUInt16(NUInt16 value, Conversion mode) => value._value;

            NUInt16 IConvert<NUInt16>.ToNumeric(bool value) => Convert.ToUInt16(value);
            NUInt16 IConvert<NUInt16>.ToNumeric(byte value, Conversion mode) => ConvertN.ToUInt16(value, mode);
            NUInt16 IConvert<NUInt16>.ToNumeric(decimal value, Conversion mode) => ConvertN.ToUInt16(value, mode);
            NUInt16 IConvert<NUInt16>.ToNumeric(double value, Conversion mode) => ConvertN.ToUInt16(value, mode);
            NUInt16 IConvert<NUInt16>.ToNumeric(float value, Conversion mode) => ConvertN.ToUInt16(value, mode);
            NUInt16 IConvert<NUInt16>.ToNumeric(int value, Conversion mode) => ConvertN.ToUInt16(value, mode);
            NUInt16 IConvert<NUInt16>.ToNumeric(long value, Conversion mode) => ConvertN.ToUInt16(value, mode);
            NUInt16 IConvertExtended<NUInt16>.ToValue(sbyte value, Conversion mode) => ConvertN.ToUInt16(value, mode);
            NUInt16 IConvert<NUInt16>.ToNumeric(short value, Conversion mode) => ConvertN.ToUInt16(value, mode);
            NUInt16 IConvert<NUInt16>.ToNumeric(string value) => Convert.ToUInt16(value);
            NUInt16 IConvertExtended<NUInt16>.ToNumeric(uint value, Conversion mode) => ConvertN.ToUInt16(value, mode);
            NUInt16 IConvertExtended<NUInt16>.ToNumeric(ulong value, Conversion mode) => ConvertN.ToUInt16(value, mode);
            NUInt16 IConvertExtended<NUInt16>.ToNumeric(ushort value, Conversion mode) => value;

            NUInt16 INumericStatic<NUInt16>.Parse(string s, NumberStyles? style, IFormatProvider? provider)
                => Parse(s, style ?? NumberStyles.Integer, provider);

            NUInt16 INumericRandom<NUInt16>.Generate(Random random) => random.NextUInt16();
            NUInt16 INumericRandom<NUInt16>.Generate(Random random, NUInt16 maxValue) => random.NextUInt16(maxValue);
            NUInt16 INumericRandom<NUInt16>.Generate(Random random, NUInt16 minValue, NUInt16 maxValue) => random.NextUInt16(minValue, maxValue);
            NUInt16 INumericRandom<NUInt16>.Generate(Random random, Generation mode) => random.NextUInt16(mode);
            NUInt16 INumericRandom<NUInt16>.Generate(Random random, NUInt16 minValue, NUInt16 maxValue, Generation mode) => random.NextUInt16(minValue, maxValue, mode);

            NUInt16 IVariantRandom<NUInt16>.Generate(Random random, Variants variants) => random.NextUInt16(variants);
        }
    }
}
