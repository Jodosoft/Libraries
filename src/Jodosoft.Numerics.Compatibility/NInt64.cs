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
    /// Represents a 64-bit signed integer.
    /// </summary>
    [Serializable]
    [DebuggerDisplay("{ToString(),nq}")]
    public readonly struct NInt64 : INumericExtended<NInt64>
    {
        public static readonly NInt64 MaxValue = new NInt64(long.MaxValue);
        public static readonly NInt64 MinValue = new NInt64(long.MinValue);

        private readonly long _value;

        private NInt64(long value)
        {
            _value = value;
        }

        private NInt64(SerializationInfo info, StreamingContext context) : this(info.GetInt64(nameof(NInt64))) { }
        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context) => info.AddValue(nameof(NInt64), _value);

        public int CompareTo(NInt64 other) => _value.CompareTo(other._value);
        public int CompareTo(object? obj) => obj is NInt64 other ? CompareTo(other) : 1;
        public bool Equals(NInt64 other) => _value == other._value;
        public override bool Equals(object? obj) => obj is NInt64 other && Equals(other);
        public override int GetHashCode() => _value.GetHashCode();
        public override string ToString() => _value.ToString();
        public string ToString(IFormatProvider? provider) => _value.ToString(provider);
        public string ToString(string format) => _value.ToString(format);
        public string ToString(string? format, IFormatProvider? formatProvider) => _value.ToString(format, formatProvider);

        public static bool TryParse(string s, IFormatProvider? provider, out NInt64 result) => FuncExtensions.Try(() => Parse(s, provider), out result);
        public static bool TryParse(string s, NumberStyles style, IFormatProvider? provider, out NInt64 result) => FuncExtensions.Try(() => Parse(s, style, provider), out result);
        public static bool TryParse(string s, NumberStyles style, out NInt64 result) => FuncExtensions.Try(() => Parse(s, style), out result);
        public static bool TryParse(string s, out NInt64 result) => FuncExtensions.Try(() => Parse(s), out result);
        public static NInt64 Parse(string s) => long.Parse(s);
        public static NInt64 Parse(string s, IFormatProvider? provider) => long.Parse(s, provider);
        public static NInt64 Parse(string s, NumberStyles style) => long.Parse(s, style);
        public static NInt64 Parse(string s, NumberStyles style, IFormatProvider? provider) => long.Parse(s, style, provider);

        [CLSCompliant(false)] public static explicit operator NInt64(ulong value) => new NInt64((long)value);
        [CLSCompliant(false)] public static implicit operator NInt64(sbyte value) => new NInt64(value);
        [CLSCompliant(false)] public static implicit operator NInt64(uint value) => new NInt64(value);
        [CLSCompliant(false)] public static implicit operator NInt64(ushort value) => new NInt64(value);
        public static explicit operator NInt64(decimal value) => new NInt64((long)value);
        public static explicit operator NInt64(double value) => new NInt64((long)value);
        public static explicit operator NInt64(float value) => new NInt64((long)value);
        public static implicit operator NInt64(byte value) => new NInt64(value);
        public static implicit operator NInt64(int value) => new NInt64(value);
        public static implicit operator NInt64(long value) => new NInt64(value);
        public static implicit operator NInt64(short value) => new NInt64(value);

        [CLSCompliant(false)] public static explicit operator sbyte(NInt64 value) => (sbyte)value._value;
        [CLSCompliant(false)] public static explicit operator uint(NInt64 value) => (uint)value._value;
        [CLSCompliant(false)] public static explicit operator ulong(NInt64 value) => (ulong)value._value;
        [CLSCompliant(false)] public static explicit operator ushort(NInt64 value) => (ushort)value._value;
        public static explicit operator byte(NInt64 value) => (byte)value._value;
        public static explicit operator int(NInt64 value) => (int)value._value;
        public static explicit operator short(NInt64 value) => (short)value._value;
        public static implicit operator decimal(NInt64 value) => value._value;
        public static implicit operator double(NInt64 value) => value._value;
        public static implicit operator float(NInt64 value) => value._value;
        public static implicit operator long(NInt64 value) => value._value;

        public static bool operator !=(NInt64 left, NInt64 right) => left._value != right._value;
        public static bool operator <(NInt64 left, NInt64 right) => left._value < right._value;
        public static bool operator <=(NInt64 left, NInt64 right) => left._value <= right._value;
        public static bool operator ==(NInt64 left, NInt64 right) => left._value == right._value;
        public static bool operator >(NInt64 left, NInt64 right) => left._value > right._value;
        public static bool operator >=(NInt64 left, NInt64 right) => left._value >= right._value;
        public static NInt64 operator %(NInt64 left, NInt64 right) => left._value % right._value;
        public static NInt64 operator &(NInt64 left, NInt64 right) => left._value & right._value;
        public static NInt64 operator -(NInt64 left, NInt64 right) => left._value - right._value;
        public static NInt64 operator --(NInt64 value) => value._value - 1;
        public static NInt64 operator -(NInt64 value) => -value._value;
        public static NInt64 operator *(NInt64 left, NInt64 right) => left._value * right._value;
        public static NInt64 operator /(NInt64 left, NInt64 right) => left._value / right._value;
        public static NInt64 operator ^(NInt64 left, NInt64 right) => left._value ^ right._value;
        public static NInt64 operator |(NInt64 left, NInt64 right) => left._value | right._value;
        public static NInt64 operator ~(NInt64 value) => ~value._value;
        public static NInt64 operator +(NInt64 left, NInt64 right) => left._value + right._value;
        public static NInt64 operator +(NInt64 value) => value;
        public static NInt64 operator ++(NInt64 value) => value._value + 1;
        public static NInt64 operator <<(NInt64 left, int right) => left._value << right;
        public static NInt64 operator >>(NInt64 left, int right) => left._value >> right;

        TypeCode IConvertible.GetTypeCode() => _value.GetTypeCode();
        bool IConvertible.ToBoolean(IFormatProvider? provider) => ((IConvertible)_value).ToBoolean(provider);
        char IConvertible.ToChar(IFormatProvider? provider) => ((IConvertible)_value).ToChar(provider);
        sbyte IConvertible.ToSByte(IFormatProvider? provider) => ((IConvertible)_value).ToSByte(provider);
        byte IConvertible.ToByte(IFormatProvider? provider) => ((IConvertible)_value).ToByte(provider);
        short IConvertible.ToInt16(IFormatProvider? provider) => ((IConvertible)_value).ToInt16(provider);
        ushort IConvertible.ToUInt16(IFormatProvider? provider) => ((IConvertible)_value).ToUInt16(provider);
        int IConvertible.ToInt32(IFormatProvider? provider) => ((IConvertible)_value).ToInt32(provider);
        uint IConvertible.ToUInt32(IFormatProvider? provider) => ((IConvertible)_value).ToUInt32(provider);
        long IConvertible.ToInt64(IFormatProvider? provider) => ((IConvertible)_value).ToInt64(provider);
        ulong IConvertible.ToUInt64(IFormatProvider? provider) => ((IConvertible)_value).ToUInt64(provider);
        float IConvertible.ToSingle(IFormatProvider? provider) => ((IConvertible)_value).ToSingle(provider);
        double IConvertible.ToDouble(IFormatProvider? provider) => ((IConvertible)_value).ToDouble(provider);
        decimal IConvertible.ToDecimal(IFormatProvider? provider) => ((IConvertible)_value).ToDecimal(provider);
        DateTime IConvertible.ToDateTime(IFormatProvider? provider) => ((IConvertible)_value).ToDateTime(provider);
        object IConvertible.ToType(Type conversionType, IFormatProvider? provider) => this.ToTypeDefault(conversionType, provider);

        bool INumeric<NInt64>.IsGreaterThan(NInt64 value) => this > value;
        bool INumeric<NInt64>.IsGreaterThanOrEqualTo(NInt64 value) => this >= value;
        bool INumeric<NInt64>.IsLessThan(NInt64 value) => this < value;
        bool INumeric<NInt64>.IsLessThanOrEqualTo(NInt64 value) => this <= value;
        NInt64 INumeric<NInt64>.Add(NInt64 value) => this + value;
        NInt64 INumeric<NInt64>.BitwiseComplement() => ~this;
        NInt64 INumeric<NInt64>.Divide(NInt64 value) => this / value;
        NInt64 INumeric<NInt64>.LeftShift(int count) => this << count;
        NInt64 INumeric<NInt64>.LogicalAnd(NInt64 value) => this & value;
        NInt64 INumeric<NInt64>.LogicalExclusiveOr(NInt64 value) => this ^ value;
        NInt64 INumeric<NInt64>.LogicalOr(NInt64 value) => this | value;
        NInt64 INumeric<NInt64>.Multiply(NInt64 value) => this * value;
        NInt64 INumeric<NInt64>.Negative() => -this;
        NInt64 INumeric<NInt64>.Positive() => +this;
        NInt64 INumeric<NInt64>.Remainder(NInt64 value) => this % value;
        NInt64 INumeric<NInt64>.RightShift(int count) => this >> count;
        NInt64 INumeric<NInt64>.Subtract(NInt64 value) => this - value;

        INumericBitConverter<NInt64> IProvider<INumericBitConverter<NInt64>>.GetInstance() => Utilities.Instance;
        IBinaryIO<NInt64> IProvider<IBinaryIO<NInt64>>.GetInstance() => Utilities.Instance;
        IConvert<NInt64> IProvider<IConvert<NInt64>>.GetInstance() => Utilities.Instance;
        IConvertExtended<NInt64> IProvider<IConvertExtended<NInt64>>.GetInstance() => Utilities.Instance;
        IMath<NInt64> IProvider<IMath<NInt64>>.GetInstance() => Utilities.Instance;
        INumericStatic<NInt64> IProvider<INumericStatic<NInt64>>.GetInstance() => Utilities.Instance;
        INumericRandom<NInt64> IProvider<INumericRandom<NInt64>>.GetInstance() => Utilities.Instance;
        IVariantRandom<NInt64> IProvider<IVariantRandom<NInt64>>.GetInstance() => Utilities.Instance;

        private sealed class Utilities :
            IBinaryIO<NInt64>,
            IConvert<NInt64>,
            IConvertExtended<NInt64>,
            IMath<NInt64>,
            INumericBitConverter<NInt64>,
            INumericRandom<NInt64>,
            INumericStatic<NInt64>,
            IVariantRandom<NInt64>
        {
            public static readonly Utilities Instance = new Utilities();

            void IBinaryIO<NInt64>.Write(BinaryWriter writer, NInt64 value) => writer.Write(value);
            NInt64 IBinaryIO<NInt64>.Read(BinaryReader reader) => reader.ReadInt64();

            bool INumericStatic<NInt64>.HasFloatingPoint => false;
            bool INumericStatic<NInt64>.HasInfinity => false;
            bool INumericStatic<NInt64>.HasNaN => false;
            bool INumericStatic<NInt64>.IsFinite(NInt64 x) => true;
            bool INumericStatic<NInt64>.IsInfinity(NInt64 x) => false;
            bool INumericStatic<NInt64>.IsNaN(NInt64 x) => false;
            bool INumericStatic<NInt64>.IsNegative(NInt64 x) => x._value < 0;
            bool INumericStatic<NInt64>.IsNegativeInfinity(NInt64 x) => false;
            bool INumericStatic<NInt64>.IsNormal(NInt64 x) => false;
            bool INumericStatic<NInt64>.IsPositiveInfinity(NInt64 x) => false;
            bool INumericStatic<NInt64>.IsReal => false;
            bool INumericStatic<NInt64>.IsSigned => true;
            bool INumericStatic<NInt64>.IsSubnormal(NInt64 x) => false;
            NInt64 INumericStatic<NInt64>.Epsilon => 1L;
            NInt64 INumericStatic<NInt64>.MaxUnit => 1L;
            NInt64 INumericStatic<NInt64>.MaxValue => MaxValue;
            NInt64 INumericStatic<NInt64>.MinUnit => -1L;
            NInt64 INumericStatic<NInt64>.MinValue => MinValue;
            NInt64 INumericStatic<NInt64>.One => 1L;
            NInt64 INumericStatic<NInt64>.Zero => 0;

            int IMath<NInt64>.Sign(NInt64 x) => Math.Sign(x._value);
            NInt64 IMath<NInt64>.Abs(NInt64 value) => Math.Abs(value);
            NInt64 IMath<NInt64>.Acos(NInt64 x) => (NInt64)Math.Acos(x);
            NInt64 IMath<NInt64>.Acosh(NInt64 x) => (NInt64)MathShim.Acosh(x);
            NInt64 IMath<NInt64>.Asin(NInt64 x) => (NInt64)Math.Asin(x);
            NInt64 IMath<NInt64>.Asinh(NInt64 x) => (NInt64)MathShim.Asinh(x);
            NInt64 IMath<NInt64>.Atan(NInt64 x) => (NInt64)Math.Atan(x);
            NInt64 IMath<NInt64>.Atan2(NInt64 y, NInt64 x) => (NInt64)Math.Atan2(y, x);
            NInt64 IMath<NInt64>.Atanh(NInt64 x) => (NInt64)MathShim.Atanh(x);
            NInt64 IMath<NInt64>.Cbrt(NInt64 x) => (NInt64)MathShim.Cbrt(x);
            NInt64 IMath<NInt64>.Ceiling(NInt64 x) => x;
            NInt64 IMath<NInt64>.Clamp(NInt64 x, NInt64 bound1, NInt64 bound2) => bound1 > bound2 ? Math.Min(bound1, Math.Max(bound2, x)) : Math.Min(bound2, Math.Max(bound1, x));
            NInt64 IMath<NInt64>.Cos(NInt64 x) => (NInt64)Math.Cos(x);
            NInt64 IMath<NInt64>.Cosh(NInt64 x) => (NInt64)Math.Cosh(x);
            NInt64 IMath<NInt64>.E { get; } = 2L;
            NInt64 IMath<NInt64>.Exp(NInt64 x) => (NInt64)Math.Exp(x);
            NInt64 IMath<NInt64>.Floor(NInt64 x) => x;
            NInt64 IMath<NInt64>.IEEERemainder(NInt64 x, NInt64 y) => (NInt64)Math.IEEERemainder(x, y);
            NInt64 IMath<NInt64>.Log(NInt64 x) => (NInt64)Math.Log(x);
            NInt64 IMath<NInt64>.Log(NInt64 x, NInt64 y) => (NInt64)Math.Log(x, y);
            NInt64 IMath<NInt64>.Log10(NInt64 x) => (NInt64)Math.Log10(x);
            NInt64 IMath<NInt64>.Max(NInt64 x, NInt64 y) => Math.Max(x, y);
            NInt64 IMath<NInt64>.Min(NInt64 x, NInt64 y) => Math.Min(x, y);
            NInt64 IMath<NInt64>.PI { get; } = 3L;
            NInt64 IMath<NInt64>.Pow(NInt64 x, NInt64 y) => y == 1 ? x : (NInt64)Math.Pow(x, y);
            NInt64 IMath<NInt64>.Round(NInt64 x) => x;
            NInt64 IMath<NInt64>.Round(NInt64 x, int digits) => x;
            NInt64 IMath<NInt64>.Round(NInt64 x, int digits, MidpointRounding mode) => x;
            NInt64 IMath<NInt64>.Round(NInt64 x, MidpointRounding mode) => x;
            NInt64 IMath<NInt64>.Sin(NInt64 x) => (NInt64)Math.Sin(x);
            NInt64 IMath<NInt64>.Sinh(NInt64 x) => (NInt64)Math.Sinh(x);
            NInt64 IMath<NInt64>.Sqrt(NInt64 x) => (NInt64)Math.Sqrt(x);
            NInt64 IMath<NInt64>.Tan(NInt64 x) => (NInt64)Math.Tan(x);
            NInt64 IMath<NInt64>.Tanh(NInt64 x) => (NInt64)Math.Tanh(x);
            NInt64 IMath<NInt64>.Tau { get; } = 6L;
            NInt64 IMath<NInt64>.Truncate(NInt64 x) => x;

            int INumericBitConverter<NInt64>.ConvertedSize => sizeof(long);
            NInt64 INumericBitConverter<NInt64>.ToNumeric(byte[] value, int startIndex) => BitConverter.ToInt64(value, startIndex);
            byte[] INumericBitConverter<NInt64>.GetBytes(NInt64 value) => BitConverter.GetBytes(value._value);
#if HAS_SPANS
            NInt64 INumericBitConverter<NInt64>.ToNumeric(ReadOnlySpan<byte> value) => BitConverter.ToInt64(value);
            bool INumericBitConverter<NInt64>.TryWriteBytes(Span<byte> destination, NInt64 value) => BitConverter.TryWriteBytes(destination, value);
#endif

            bool IConvert<NInt64>.ToBoolean(NInt64 value) => Convert.ToBoolean(value._value);
            byte IConvert<NInt64>.ToByte(NInt64 value, Conversion mode) => ConvertN.ToByte(value._value, mode);
            decimal IConvert<NInt64>.ToDecimal(NInt64 value, Conversion mode) => ConvertN.ToDecimal(value._value, mode);
            double IConvert<NInt64>.ToDouble(NInt64 value, Conversion mode) => ConvertN.ToDouble(value._value, mode);
            float IConvert<NInt64>.ToSingle(NInt64 value, Conversion mode) => ConvertN.ToSingle(value._value, mode);
            int IConvert<NInt64>.ToInt32(NInt64 value, Conversion mode) => ConvertN.ToInt32(value._value, mode);
            long IConvert<NInt64>.ToInt64(NInt64 value, Conversion mode) => value._value;
            sbyte IConvertExtended<NInt64>.ToSByte(NInt64 value, Conversion mode) => ConvertN.ToSByte(value._value, mode);
            short IConvert<NInt64>.ToInt16(NInt64 value, Conversion mode) => ConvertN.ToInt16(value._value, mode);
            string IConvert<NInt64>.ToString(NInt64 value) => Convert.ToString(value._value);
            uint IConvertExtended<NInt64>.ToUInt32(NInt64 value, Conversion mode) => ConvertN.ToUInt32(value._value, mode);
            ulong IConvertExtended<NInt64>.ToUInt64(NInt64 value, Conversion mode) => ConvertN.ToUInt64(value._value, mode);
            ushort IConvertExtended<NInt64>.ToUInt16(NInt64 value, Conversion mode) => ConvertN.ToUInt16(value._value, mode);

            NInt64 IConvert<NInt64>.ToNumeric(bool value) => Convert.ToInt64(value);
            NInt64 IConvert<NInt64>.ToNumeric(byte value, Conversion mode) => ConvertN.ToInt64(value, mode);
            NInt64 IConvert<NInt64>.ToNumeric(decimal value, Conversion mode) => ConvertN.ToInt64(value, mode);
            NInt64 IConvert<NInt64>.ToNumeric(double value, Conversion mode) => ConvertN.ToInt64(value, mode);
            NInt64 IConvert<NInt64>.ToNumeric(float value, Conversion mode) => ConvertN.ToInt64(value, mode);
            NInt64 IConvert<NInt64>.ToNumeric(int value, Conversion mode) => ConvertN.ToInt64(value, mode);
            NInt64 IConvert<NInt64>.ToNumeric(long value, Conversion mode) => value;
            NInt64 IConvertExtended<NInt64>.ToValue(sbyte value, Conversion mode) => ConvertN.ToInt64(value, mode);
            NInt64 IConvert<NInt64>.ToNumeric(short value, Conversion mode) => ConvertN.ToInt64(value, mode);
            NInt64 IConvert<NInt64>.ToNumeric(string value) => Convert.ToInt64(value);
            NInt64 IConvertExtended<NInt64>.ToNumeric(uint value, Conversion mode) => ConvertN.ToInt64(value, mode);
            NInt64 IConvertExtended<NInt64>.ToNumeric(ulong value, Conversion mode) => ConvertN.ToInt64(value, mode);
            NInt64 IConvertExtended<NInt64>.ToNumeric(ushort value, Conversion mode) => ConvertN.ToInt64(value, mode);

            NInt64 INumericStatic<NInt64>.Parse(string s, NumberStyles? style, IFormatProvider? provider)
                => Parse(s, style ?? NumberStyles.Integer, provider);

            NInt64 INumericRandom<NInt64>.Generate(Random random) => random.NextInt64();
            NInt64 INumericRandom<NInt64>.Generate(Random random, NInt64 maxValue) => random.NextInt64(maxValue);
            NInt64 INumericRandom<NInt64>.Generate(Random random, NInt64 minValue, NInt64 maxValue) => random.NextInt64(minValue, maxValue);
            NInt64 INumericRandom<NInt64>.Generate(Random random, Generation mode) => random.NextInt64(mode);
            NInt64 INumericRandom<NInt64>.Generate(Random random, NInt64 minValue, NInt64 maxValue, Generation mode) => random.NextInt64(minValue, maxValue, mode);

            NInt64 IVariantRandom<NInt64>.Generate(Random random, Variants variants) => random.NextInt64(variants);
        }
    }
}
