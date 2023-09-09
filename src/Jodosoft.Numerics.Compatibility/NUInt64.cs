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
    /// Represents a 64-bit unsigned integer.
    /// </summary>
    [Serializable]
    [DebuggerDisplay("{ToString(),nq}")]
    public readonly struct NUInt64 : INumericExtended<NUInt64>
    {
        public static readonly NUInt64 MaxValue = new NUInt64(ulong.MaxValue);
        public static readonly NUInt64 MinValue = new NUInt64(ulong.MinValue);

        private readonly ulong _value;

        private NUInt64(ulong value)
        {
            _value = value;
        }

        private NUInt64(SerializationInfo info, StreamingContext context) : this(info.GetUInt64(nameof(NUInt64))) { }
        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context) => info.AddValue(nameof(NUInt64), _value);

        public int CompareTo(NUInt64 other) => _value.CompareTo(other._value);
        public int CompareTo(object? obj) => obj is NUInt64 other ? CompareTo(other) : 1;
        public bool Equals(NUInt64 other) => _value == other._value;
        public override bool Equals(object? obj) => obj is NUInt64 other && Equals(other);
        public override int GetHashCode() => _value.GetHashCode();
        public override string ToString() => _value.ToString();
        public string ToString(IFormatProvider formatProvider) => _value.ToString(formatProvider);
        public string ToString(string format) => _value.ToString(format);
        public string ToString(string? format, IFormatProvider? formatProvider) => _value.ToString(format, formatProvider);

        public static bool TryParse(string s, IFormatProvider? provider, out NUInt64 result) => FuncExtensions.Try(() => Parse(s, provider), out result);
        public static bool TryParse(string s, NumberStyles style, IFormatProvider? provider, out NUInt64 result) => FuncExtensions.Try(() => Parse(s, style, provider), out result);
        public static bool TryParse(string s, NumberStyles style, out NUInt64 result) => FuncExtensions.Try(() => Parse(s, style), out result);
        public static bool TryParse(string s, out NUInt64 result) => FuncExtensions.Try(() => Parse(s), out result);
        public static NUInt64 Parse(string s) => ulong.Parse(s);
        public static NUInt64 Parse(string s, IFormatProvider? provider) => ulong.Parse(s, provider);
        public static NUInt64 Parse(string s, NumberStyles style) => ulong.Parse(s, style);
        public static NUInt64 Parse(string s, NumberStyles style, IFormatProvider? provider) => ulong.Parse(s, style, provider);

        [CLSCompliant(false)] public static explicit operator NUInt64(sbyte value) => new NUInt64((ulong)value);
        [CLSCompliant(false)] public static implicit operator NUInt64(uint value) => new NUInt64(value);
        [CLSCompliant(false)] public static implicit operator NUInt64(ulong value) => new NUInt64(value);
        [CLSCompliant(false)] public static implicit operator NUInt64(ushort value) => new NUInt64(value);
        public static explicit operator NUInt64(decimal value) => new NUInt64((ulong)value);
        public static explicit operator NUInt64(double value) => new NUInt64((ulong)value);
        public static explicit operator NUInt64(float value) => new NUInt64((ulong)value);
        public static explicit operator NUInt64(int value) => new NUInt64((ulong)value);
        public static explicit operator NUInt64(long value) => new NUInt64((ulong)value);
        public static explicit operator NUInt64(short value) => new NUInt64((ulong)value);
        public static implicit operator NUInt64(byte value) => new NUInt64(value);

        [CLSCompliant(false)] public static explicit operator sbyte(NUInt64 value) => (sbyte)value._value;
        [CLSCompliant(false)] public static explicit operator uint(NUInt64 value) => (uint)value._value;
        [CLSCompliant(false)] public static explicit operator ushort(NUInt64 value) => (ushort)value._value;
        [CLSCompliant(false)] public static implicit operator ulong(NUInt64 value) => value._value;
        public static explicit operator byte(NUInt64 value) => (byte)value._value;
        public static explicit operator int(NUInt64 value) => (int)value._value;
        public static explicit operator long(NUInt64 value) => (long)value._value;
        public static explicit operator short(NUInt64 value) => (short)value._value;
        public static implicit operator decimal(NUInt64 value) => value._value;
        public static implicit operator double(NUInt64 value) => value._value;
        public static implicit operator float(NUInt64 value) => value._value;

        public static bool operator !=(NUInt64 left, NUInt64 right) => left._value != right._value;
        public static bool operator <(NUInt64 left, NUInt64 right) => left._value < right._value;
        public static bool operator <=(NUInt64 left, NUInt64 right) => left._value <= right._value;
        public static bool operator ==(NUInt64 left, NUInt64 right) => left._value == right._value;
        public static bool operator >(NUInt64 left, NUInt64 right) => left._value > right._value;
        public static bool operator >=(NUInt64 left, NUInt64 right) => left._value >= right._value;
        public static NUInt64 operator %(NUInt64 left, NUInt64 right) => left._value % right._value;
        public static NUInt64 operator &(NUInt64 left, NUInt64 right) => left._value & right._value;
        public static NUInt64 operator -(NUInt64 left, NUInt64 right) => left._value - right._value;
        public static NUInt64 operator --(NUInt64 value) => value._value - 1;
        public static NUInt64 operator *(NUInt64 left, NUInt64 right) => left._value * right._value;
        public static NUInt64 operator /(NUInt64 left, NUInt64 right) => left._value / right._value;
        public static NUInt64 operator ^(NUInt64 left, NUInt64 right) => left._value ^ right._value;
        public static NUInt64 operator |(NUInt64 left, NUInt64 right) => left._value | right._value;
        public static NUInt64 operator ~(NUInt64 value) => ~value._value;
        public static NUInt64 operator +(NUInt64 left, NUInt64 right) => left._value + right._value;
        public static NUInt64 operator +(NUInt64 value) => value;
        public static NUInt64 operator ++(NUInt64 value) => value._value + 1;
        public static NUInt64 operator <<(NUInt64 left, int right) => left._value << right;
        public static NUInt64 operator >>(NUInt64 left, int right) => left._value >> right;

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

        bool INumeric<NUInt64>.IsGreaterThan(NUInt64 value) => this > value;
        bool INumeric<NUInt64>.IsGreaterThanOrEqualTo(NUInt64 value) => this >= value;
        bool INumeric<NUInt64>.IsLessThan(NUInt64 value) => this < value;
        bool INumeric<NUInt64>.IsLessThanOrEqualTo(NUInt64 value) => this <= value;
        NUInt64 INumeric<NUInt64>.Add(NUInt64 value) => this + value;
        NUInt64 INumeric<NUInt64>.BitwiseComplement() => ~this;
        NUInt64 INumeric<NUInt64>.Divide(NUInt64 value) => this / value;
        NUInt64 INumeric<NUInt64>.LeftShift(int count) => this << count;
        NUInt64 INumeric<NUInt64>.LogicalAnd(NUInt64 value) => this & value;
        NUInt64 INumeric<NUInt64>.LogicalExclusiveOr(NUInt64 value) => this ^ value;
        NUInt64 INumeric<NUInt64>.LogicalOr(NUInt64 value) => this | value;
        NUInt64 INumeric<NUInt64>.Multiply(NUInt64 value) => this * value;
        NUInt64 INumeric<NUInt64>.Negative() => 0 - _value;
        NUInt64 INumeric<NUInt64>.Positive() => +this;
        NUInt64 INumeric<NUInt64>.Remainder(NUInt64 value) => this % value;
        NUInt64 INumeric<NUInt64>.RightShift(int count) => this >> count;
        NUInt64 INumeric<NUInt64>.Subtract(NUInt64 value) => this - value;

        INumericBitConverter<NUInt64> IProvider<INumericBitConverter<NUInt64>>.GetInstance() => Utilities.Instance;
        IBinaryIO<NUInt64> IProvider<IBinaryIO<NUInt64>>.GetInstance() => Utilities.Instance;
        IConvert<NUInt64> IProvider<IConvert<NUInt64>>.GetInstance() => Utilities.Instance;
        IConvertExtended<NUInt64> IProvider<IConvertExtended<NUInt64>>.GetInstance() => Utilities.Instance;
        IMath<NUInt64> IProvider<IMath<NUInt64>>.GetInstance() => Utilities.Instance;
        INumericRandom<NUInt64> IProvider<INumericRandom<NUInt64>>.GetInstance() => Utilities.Instance;
        INumericStatic<NUInt64> IProvider<INumericStatic<NUInt64>>.GetInstance() => Utilities.Instance;
        IVariantRandom<NUInt64> IProvider<IVariantRandom<NUInt64>>.GetInstance() => Utilities.Instance;

        private sealed class Utilities :
            IBinaryIO<NUInt64>,
            IConvert<NUInt64>,
            IConvertExtended<NUInt64>,
            IMath<NUInt64>,
            INumericBitConverter<NUInt64>,
            INumericRandom<NUInt64>,
            INumericStatic<NUInt64>,
            IVariantRandom<NUInt64>
        {
            public static readonly Utilities Instance = new Utilities();

            void IBinaryIO<NUInt64>.Write(BinaryWriter writer, NUInt64 value) => writer.Write(value);
            NUInt64 IBinaryIO<NUInt64>.Read(BinaryReader reader) => reader.ReadUInt64();

            bool INumericStatic<NUInt64>.HasFloatingPoint => false;
            bool INumericStatic<NUInt64>.HasInfinity => false;
            bool INumericStatic<NUInt64>.HasNaN => false;
            bool INumericStatic<NUInt64>.IsFinite(NUInt64 x) => true;
            bool INumericStatic<NUInt64>.IsInfinity(NUInt64 x) => false;
            bool INumericStatic<NUInt64>.IsNaN(NUInt64 x) => false;
            bool INumericStatic<NUInt64>.IsNegative(NUInt64 x) => false;
            bool INumericStatic<NUInt64>.IsNegativeInfinity(NUInt64 x) => false;
            bool INumericStatic<NUInt64>.IsNormal(NUInt64 x) => false;
            bool INumericStatic<NUInt64>.IsPositiveInfinity(NUInt64 x) => false;
            bool INumericStatic<NUInt64>.IsReal => false;
            bool INumericStatic<NUInt64>.IsSigned => false;
            bool INumericStatic<NUInt64>.IsSubnormal(NUInt64 x) => false;
            NUInt64 INumericStatic<NUInt64>.Epsilon => (NUInt64)1;
            NUInt64 INumericStatic<NUInt64>.MaxUnit => (NUInt64)1;
            NUInt64 INumericStatic<NUInt64>.MaxValue => MaxValue;
            NUInt64 INumericStatic<NUInt64>.MinUnit => (NUInt64)0;
            NUInt64 INumericStatic<NUInt64>.MinValue => MinValue;
            NUInt64 INumericStatic<NUInt64>.One => (NUInt64)1;
            NUInt64 INumericStatic<NUInt64>.Zero => (NUInt64)0;

            int IMath<NUInt64>.Sign(NUInt64 x) => x._value == 0 ? 0 : 1;
            NUInt64 IMath<NUInt64>.Abs(NUInt64 value) => value;
            NUInt64 IMath<NUInt64>.Acos(NUInt64 x) => (NUInt64)Math.Acos(x);
            NUInt64 IMath<NUInt64>.Acosh(NUInt64 x) => (NUInt64)MathShim.Acosh(x);
            NUInt64 IMath<NUInt64>.Asin(NUInt64 x) => (NUInt64)Math.Asin(x);
            NUInt64 IMath<NUInt64>.Asinh(NUInt64 x) => (NUInt64)MathShim.Asinh(x);
            NUInt64 IMath<NUInt64>.Atan(NUInt64 x) => (NUInt64)Math.Atan(x);
            NUInt64 IMath<NUInt64>.Atan2(NUInt64 y, NUInt64 x) => (NUInt64)Math.Atan2(y, x);
            NUInt64 IMath<NUInt64>.Atanh(NUInt64 x) => (NUInt64)MathShim.Atanh(x);
            NUInt64 IMath<NUInt64>.Cbrt(NUInt64 x) => (NUInt64)MathShim.Cbrt(x);
            NUInt64 IMath<NUInt64>.Ceiling(NUInt64 x) => x;
            NUInt64 IMath<NUInt64>.Clamp(NUInt64 x, NUInt64 bound1, NUInt64 bound2) => bound1 > bound2 ? Math.Min(bound1, Math.Max(bound2, x)) : Math.Min(bound2, Math.Max(bound1, x));
            NUInt64 IMath<NUInt64>.Cos(NUInt64 x) => (NUInt64)Math.Cos(x);
            NUInt64 IMath<NUInt64>.Cosh(NUInt64 x) => (NUInt64)Math.Cosh(x);
            NUInt64 IMath<NUInt64>.E { get; } = (NUInt64)2;
            NUInt64 IMath<NUInt64>.Exp(NUInt64 x) => (NUInt64)Math.Exp(x);
            NUInt64 IMath<NUInt64>.Floor(NUInt64 x) => x;
            NUInt64 IMath<NUInt64>.IEEERemainder(NUInt64 x, NUInt64 y) => (NUInt64)Math.IEEERemainder(x, y);
            NUInt64 IMath<NUInt64>.Log(NUInt64 x) => (NUInt64)Math.Log(x);
            NUInt64 IMath<NUInt64>.Log(NUInt64 x, NUInt64 y) => (NUInt64)Math.Log(x, y);
            NUInt64 IMath<NUInt64>.Log10(NUInt64 x) => (NUInt64)Math.Log10(x);
            NUInt64 IMath<NUInt64>.Max(NUInt64 x, NUInt64 y) => Math.Max(x, y);
            NUInt64 IMath<NUInt64>.Min(NUInt64 x, NUInt64 y) => Math.Min(x, y);
            NUInt64 IMath<NUInt64>.PI { get; } = (NUInt64)3;
            NUInt64 IMath<NUInt64>.Pow(NUInt64 x, NUInt64 y) => y == 1 ? x : (NUInt64)Math.Pow(x, y);
            NUInt64 IMath<NUInt64>.Round(NUInt64 x) => x;
            NUInt64 IMath<NUInt64>.Round(NUInt64 x, int digits) => x;
            NUInt64 IMath<NUInt64>.Round(NUInt64 x, int digits, MidpointRounding mode) => x;
            NUInt64 IMath<NUInt64>.Round(NUInt64 x, MidpointRounding mode) => x;
            NUInt64 IMath<NUInt64>.Sin(NUInt64 x) => (NUInt64)Math.Sin(x);
            NUInt64 IMath<NUInt64>.Sinh(NUInt64 x) => (NUInt64)Math.Sinh(x);
            NUInt64 IMath<NUInt64>.Sqrt(NUInt64 x) => (NUInt64)Math.Sqrt(x);
            NUInt64 IMath<NUInt64>.Tan(NUInt64 x) => (NUInt64)Math.Tan(x);
            NUInt64 IMath<NUInt64>.Tanh(NUInt64 x) => (NUInt64)Math.Tanh(x);
            NUInt64 IMath<NUInt64>.Tau { get; } = (NUInt64)6;
            NUInt64 IMath<NUInt64>.Truncate(NUInt64 x) => x;

            int INumericBitConverter<NUInt64>.ConvertedSize => sizeof(ulong);
            NUInt64 INumericBitConverter<NUInt64>.ToNumeric(byte[] value, int startIndex) => BitConverter.ToUInt64(value, startIndex);
            byte[] INumericBitConverter<NUInt64>.GetBytes(NUInt64 value) => BitConverter.GetBytes(value._value);
#if HAS_SPANS
            NUInt64 INumericBitConverter<NUInt64>.ToNumeric(ReadOnlySpan<byte> value) => BitConverter.ToUInt64(value);
            bool INumericBitConverter<NUInt64>.TryWriteBytes(Span<byte> destination, NUInt64 value) => BitConverter.TryWriteBytes(destination, value);
#endif

            bool IConvert<NUInt64>.ToBoolean(NUInt64 value) => Convert.ToBoolean(value._value);
            byte IConvert<NUInt64>.ToByte(NUInt64 value, Conversion mode) => ConvertN.ToByte(value._value, mode);
            decimal IConvert<NUInt64>.ToDecimal(NUInt64 value, Conversion mode) => ConvertN.ToDecimal(value._value, mode);
            double IConvert<NUInt64>.ToDouble(NUInt64 value, Conversion mode) => ConvertN.ToDouble(value._value, mode);
            float IConvert<NUInt64>.ToSingle(NUInt64 value, Conversion mode) => ConvertN.ToSingle(value._value, mode);
            int IConvert<NUInt64>.ToInt32(NUInt64 value, Conversion mode) => ConvertN.ToInt32(value._value, mode);
            long IConvert<NUInt64>.ToInt64(NUInt64 value, Conversion mode) => ConvertN.ToInt64(value._value, mode);
            sbyte IConvertExtended<NUInt64>.ToSByte(NUInt64 value, Conversion mode) => ConvertN.ToSByte(value._value, mode);
            short IConvert<NUInt64>.ToInt16(NUInt64 value, Conversion mode) => ConvertN.ToInt16(value._value, mode);
            string IConvert<NUInt64>.ToString(NUInt64 value) => Convert.ToString(value._value);
            uint IConvertExtended<NUInt64>.ToUInt32(NUInt64 value, Conversion mode) => ConvertN.ToUInt32(value._value, mode);
            ulong IConvertExtended<NUInt64>.ToUInt64(NUInt64 value, Conversion mode) => value._value;
            ushort IConvertExtended<NUInt64>.ToUInt16(NUInt64 value, Conversion mode) => ConvertN.ToUInt16(value._value, mode);

            NUInt64 IConvert<NUInt64>.ToNumeric(bool value) => Convert.ToUInt64(value);
            NUInt64 IConvert<NUInt64>.ToNumeric(byte value, Conversion mode) => ConvertN.ToUInt64(value, mode);
            NUInt64 IConvert<NUInt64>.ToNumeric(decimal value, Conversion mode) => ConvertN.ToUInt64(value, mode);
            NUInt64 IConvert<NUInt64>.ToNumeric(double value, Conversion mode) => ConvertN.ToUInt64(value, mode);
            NUInt64 IConvert<NUInt64>.ToNumeric(float value, Conversion mode) => ConvertN.ToUInt64(value, mode);
            NUInt64 IConvert<NUInt64>.ToNumeric(int value, Conversion mode) => ConvertN.ToUInt64(value, mode);
            NUInt64 IConvert<NUInt64>.ToNumeric(long value, Conversion mode) => ConvertN.ToUInt64(value, mode);
            NUInt64 IConvertExtended<NUInt64>.ToValue(sbyte value, Conversion mode) => ConvertN.ToUInt64(value, mode);
            NUInt64 IConvert<NUInt64>.ToNumeric(short value, Conversion mode) => ConvertN.ToUInt64(value, mode);
            NUInt64 IConvert<NUInt64>.ToNumeric(string value) => Convert.ToUInt64(value);
            NUInt64 IConvertExtended<NUInt64>.ToNumeric(uint value, Conversion mode) => ConvertN.ToUInt64(value, mode);
            NUInt64 IConvertExtended<NUInt64>.ToNumeric(ulong value, Conversion mode) => value;
            NUInt64 IConvertExtended<NUInt64>.ToNumeric(ushort value, Conversion mode) => ConvertN.ToUInt64(value, mode);

            NUInt64 INumericStatic<NUInt64>.Parse(string s, NumberStyles? style, IFormatProvider? provider)
                => Parse(s, style ?? NumberStyles.Integer, provider);

            NUInt64 INumericRandom<NUInt64>.Generate(Random random) => random.NextUInt64();
            NUInt64 INumericRandom<NUInt64>.Generate(Random random, NUInt64 maxValue) => random.NextUInt64(maxValue);
            NUInt64 INumericRandom<NUInt64>.Generate(Random random, NUInt64 minValue, NUInt64 maxValue) => random.NextUInt64(minValue, maxValue);
            NUInt64 INumericRandom<NUInt64>.Generate(Random random, Generation mode) => random.NextUInt64(mode);
            NUInt64 INumericRandom<NUInt64>.Generate(Random random, NUInt64 minValue, NUInt64 maxValue, Generation mode) => random.NextUInt64(minValue, maxValue, mode);

            NUInt64 IVariantRandom<NUInt64>.Generate(Random random, Variants variants) => random.NextUInt64(variants);
        }
    }
}
