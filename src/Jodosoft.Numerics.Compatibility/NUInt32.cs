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
    /// Represents a 32-bit unsigned integer.
    /// </summary>
    [Serializable]
    [DebuggerDisplay("{ToString(),nq}")]
    public readonly struct NUInt32 : INumericExtended<NUInt32>
    {
        public static readonly NUInt32 MaxValue = new NUInt32(uint.MaxValue);
        public static readonly NUInt32 MinValue = new NUInt32(uint.MinValue);

        private readonly uint _value;

        private NUInt32(uint value)
        {
            _value = value;
        }

        private NUInt32(SerializationInfo info, StreamingContext context) : this(info.GetUInt32(nameof(NUInt32))) { }
        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context) => info.AddValue(nameof(NUInt32), _value);

        public int CompareTo(NUInt32 other) => _value.CompareTo(other._value);
        public int CompareTo(object? obj) => obj is NUInt32 other ? CompareTo(other) : 1;
        public bool Equals(NUInt32 other) => _value == other._value;
        public override bool Equals(object? obj) => obj is NUInt32 other && Equals(other);
        public override int GetHashCode() => _value.GetHashCode();
        public override string ToString() => _value.ToString();
        public string ToString(IFormatProvider formatProvider) => _value.ToString(formatProvider);
        public string ToString(string format) => _value.ToString(format);
        public string ToString(string? format, IFormatProvider? formatProvider) => _value.ToString(format, formatProvider);

        public static bool TryParse(string s, IFormatProvider? provider, out NUInt32 result) => FuncExtensions.Try(() => Parse(s, provider), out result);
        public static bool TryParse(string s, NumberStyles style, IFormatProvider? provider, out NUInt32 result) => FuncExtensions.Try(() => Parse(s, style, provider), out result);
        public static bool TryParse(string s, NumberStyles style, out NUInt32 result) => FuncExtensions.Try(() => Parse(s, style), out result);
        public static bool TryParse(string s, out NUInt32 result) => FuncExtensions.Try(() => Parse(s), out result);
        public static NUInt32 Parse(string s) => uint.Parse(s);
        public static NUInt32 Parse(string s, IFormatProvider? provider) => uint.Parse(s, provider);
        public static NUInt32 Parse(string s, NumberStyles style) => uint.Parse(s, style);
        public static NUInt32 Parse(string s, NumberStyles style, IFormatProvider? provider) => uint.Parse(s, style, provider);

        [CLSCompliant(false)] public static explicit operator NUInt32(sbyte value) => new NUInt32((uint)value);
        [CLSCompliant(false)] public static explicit operator NUInt32(ulong value) => new NUInt32((uint)value);
        [CLSCompliant(false)] public static implicit operator NUInt32(uint value) => new NUInt32(value);
        [CLSCompliant(false)] public static implicit operator NUInt32(ushort value) => new NUInt32(value);
        public static explicit operator NUInt32(decimal value) => new NUInt32((uint)value);
        public static explicit operator NUInt32(double value) => new NUInt32((uint)value);
        public static explicit operator NUInt32(float value) => new NUInt32((uint)value);
        public static explicit operator NUInt32(int value) => new NUInt32((uint)value);
        public static explicit operator NUInt32(long value) => new NUInt32((uint)value);
        public static explicit operator NUInt32(short value) => new NUInt32((uint)value);
        public static implicit operator NUInt32(byte value) => new NUInt32(value);

        [CLSCompliant(false)] public static explicit operator sbyte(NUInt32 value) => (sbyte)value._value;
        [CLSCompliant(false)] public static explicit operator ushort(NUInt32 value) => (ushort)value._value;
        [CLSCompliant(false)] public static implicit operator uint(NUInt32 value) => value._value;
        [CLSCompliant(false)] public static implicit operator ulong(NUInt32 value) => value._value;
        public static explicit operator byte(NUInt32 value) => (byte)value._value;
        public static explicit operator int(NUInt32 value) => (int)value._value;
        public static explicit operator short(NUInt32 value) => (short)value._value;
        public static implicit operator decimal(NUInt32 value) => value._value;
        public static implicit operator double(NUInt32 value) => value._value;
        public static implicit operator float(NUInt32 value) => value._value;
        public static implicit operator long(NUInt32 value) => value._value;

        public static bool operator !=(NUInt32 left, NUInt32 right) => left._value != right._value;
        public static bool operator <(NUInt32 left, NUInt32 right) => left._value < right._value;
        public static bool operator <=(NUInt32 left, NUInt32 right) => left._value <= right._value;
        public static bool operator ==(NUInt32 left, NUInt32 right) => left._value == right._value;
        public static bool operator >(NUInt32 left, NUInt32 right) => left._value > right._value;
        public static bool operator >=(NUInt32 left, NUInt32 right) => left._value >= right._value;
        public static NUInt32 operator %(NUInt32 left, NUInt32 right) => left._value % right._value;
        public static NUInt32 operator &(NUInt32 left, NUInt32 right) => left._value & right._value;
        public static NUInt32 operator -(NUInt32 left, NUInt32 right) => left._value - right._value;
        public static NUInt32 operator --(NUInt32 value) => value._value - 1;
        public static NUInt32 operator *(NUInt32 left, NUInt32 right) => left._value * right._value;
        public static NUInt32 operator /(NUInt32 left, NUInt32 right) => left._value / right._value;
        public static NUInt32 operator ^(NUInt32 left, NUInt32 right) => left._value ^ right._value;
        public static NUInt32 operator |(NUInt32 left, NUInt32 right) => left._value | right._value;
        public static NUInt32 operator ~(NUInt32 value) => ~value._value;
        public static NUInt32 operator +(NUInt32 left, NUInt32 right) => left._value + right._value;
        public static NUInt32 operator +(NUInt32 value) => value;
        public static NUInt32 operator ++(NUInt32 value) => value._value + 1;
        public static NUInt32 operator <<(NUInt32 left, int right) => left._value << right;
        public static NUInt32 operator >>(NUInt32 left, int right) => left._value >> right;

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

        bool INumeric<NUInt32>.IsGreaterThan(NUInt32 value) => this > value;
        bool INumeric<NUInt32>.IsGreaterThanOrEqualTo(NUInt32 value) => this >= value;
        bool INumeric<NUInt32>.IsLessThan(NUInt32 value) => this < value;
        bool INumeric<NUInt32>.IsLessThanOrEqualTo(NUInt32 value) => this <= value;
        NUInt32 INumeric<NUInt32>.Add(NUInt32 value) => this + value;
        NUInt32 INumeric<NUInt32>.BitwiseComplement() => ~this;
        NUInt32 INumeric<NUInt32>.Divide(NUInt32 value) => this / value;
        NUInt32 INumeric<NUInt32>.LeftShift(int count) => this << count;
        NUInt32 INumeric<NUInt32>.LogicalAnd(NUInt32 value) => this & value;
        NUInt32 INumeric<NUInt32>.LogicalExclusiveOr(NUInt32 value) => this ^ value;
        NUInt32 INumeric<NUInt32>.LogicalOr(NUInt32 value) => this | value;
        NUInt32 INumeric<NUInt32>.Multiply(NUInt32 value) => this * value;
        NUInt32 INumeric<NUInt32>.Negative() => 0 - _value;
        NUInt32 INumeric<NUInt32>.Positive() => +this;
        NUInt32 INumeric<NUInt32>.Remainder(NUInt32 value) => this % value;
        NUInt32 INumeric<NUInt32>.RightShift(int count) => this >> count;
        NUInt32 INumeric<NUInt32>.Subtract(NUInt32 value) => this - value;

        INumericBitConverter<NUInt32> IProvider<INumericBitConverter<NUInt32>>.GetInstance() => Utilities.Instance;
        IBinaryIO<NUInt32> IProvider<IBinaryIO<NUInt32>>.GetInstance() => Utilities.Instance;
        IConvert<NUInt32> IProvider<IConvert<NUInt32>>.GetInstance() => Utilities.Instance;
        IConvertExtended<NUInt32> IProvider<IConvertExtended<NUInt32>>.GetInstance() => Utilities.Instance;
        IMath<NUInt32> IProvider<IMath<NUInt32>>.GetInstance() => Utilities.Instance;
        INumericStatic<NUInt32> IProvider<INumericStatic<NUInt32>>.GetInstance() => Utilities.Instance;
        INumericRandom<NUInt32> IProvider<INumericRandom<NUInt32>>.GetInstance() => Utilities.Instance;
        IVariantRandom<NUInt32> IProvider<IVariantRandom<NUInt32>>.GetInstance() => Utilities.Instance;

        private sealed class Utilities :
            IBinaryIO<NUInt32>,
            IConvert<NUInt32>,
            IConvertExtended<NUInt32>,
            IMath<NUInt32>,
            INumericBitConverter<NUInt32>,
            INumericRandom<NUInt32>,
            INumericStatic<NUInt32>,
            IVariantRandom<NUInt32>
        {
            public static readonly Utilities Instance = new Utilities();

            void IBinaryIO<NUInt32>.Write(BinaryWriter writer, NUInt32 value) => writer.Write(value);
            NUInt32 IBinaryIO<NUInt32>.Read(BinaryReader reader) => reader.ReadUInt32();

            bool INumericStatic<NUInt32>.HasFloatingPoint => false;
            bool INumericStatic<NUInt32>.HasInfinity => false;
            bool INumericStatic<NUInt32>.HasNaN => false;
            bool INumericStatic<NUInt32>.IsFinite(NUInt32 x) => true;
            bool INumericStatic<NUInt32>.IsInfinity(NUInt32 x) => false;
            bool INumericStatic<NUInt32>.IsNaN(NUInt32 x) => false;
            bool INumericStatic<NUInt32>.IsNegative(NUInt32 x) => false;
            bool INumericStatic<NUInt32>.IsNegativeInfinity(NUInt32 x) => false;
            bool INumericStatic<NUInt32>.IsNormal(NUInt32 x) => false;
            bool INumericStatic<NUInt32>.IsPositiveInfinity(NUInt32 x) => false;
            bool INumericStatic<NUInt32>.IsReal => false;
            bool INumericStatic<NUInt32>.IsSigned => false;
            bool INumericStatic<NUInt32>.IsSubnormal(NUInt32 x) => false;
            NUInt32 INumericStatic<NUInt32>.Epsilon => (uint)1;
            NUInt32 INumericStatic<NUInt32>.MaxUnit => (uint)1;
            NUInt32 INumericStatic<NUInt32>.MaxValue => MaxValue;
            NUInt32 INumericStatic<NUInt32>.MinUnit => (uint)0;
            NUInt32 INumericStatic<NUInt32>.MinValue => MinValue;
            NUInt32 INumericStatic<NUInt32>.One => (uint)1;
            NUInt32 INumericStatic<NUInt32>.Zero => (uint)0;

            int IMath<NUInt32>.Sign(NUInt32 x) => x._value == 0 ? 0 : 1;
            NUInt32 IMath<NUInt32>.Abs(NUInt32 value) => value._value;
            NUInt32 IMath<NUInt32>.Acos(NUInt32 x) => (uint)Math.Acos(x._value);
            NUInt32 IMath<NUInt32>.Acosh(NUInt32 x) => (uint)MathShim.Acosh(x._value);
            NUInt32 IMath<NUInt32>.Asin(NUInt32 x) => (uint)Math.Asin(x._value);
            NUInt32 IMath<NUInt32>.Asinh(NUInt32 x) => (uint)MathShim.Asinh(x._value);
            NUInt32 IMath<NUInt32>.Atan(NUInt32 x) => (uint)Math.Atan(x._value);
            NUInt32 IMath<NUInt32>.Atan2(NUInt32 x, NUInt32 y) => (uint)Math.Atan2(x._value, y._value);
            NUInt32 IMath<NUInt32>.Atanh(NUInt32 x) => (uint)MathShim.Atanh(x._value);
            NUInt32 IMath<NUInt32>.Cbrt(NUInt32 x) => (uint)MathShim.Cbrt(x._value);
            NUInt32 IMath<NUInt32>.Ceiling(NUInt32 x) => x;
            NUInt32 IMath<NUInt32>.Clamp(NUInt32 x, NUInt32 bound1, NUInt32 bound2) => bound1 > bound2 ? Math.Min(bound1._value, Math.Max(bound2._value, x._value)) : Math.Min(bound2._value, Math.Max(bound1._value, x._value));
            NUInt32 IMath<NUInt32>.Cos(NUInt32 x) => (uint)Math.Cos(x._value);
            NUInt32 IMath<NUInt32>.Cosh(NUInt32 x) => (uint)Math.Cosh(x._value);
            NUInt32 IMath<NUInt32>.E { get; } = (uint)2;
            NUInt32 IMath<NUInt32>.Exp(NUInt32 x) => (uint)Math.Exp(x._value);
            NUInt32 IMath<NUInt32>.Floor(NUInt32 x) => x;
            NUInt32 IMath<NUInt32>.IEEERemainder(NUInt32 x, NUInt32 y) => (uint)Math.IEEERemainder(x._value, y._value);
            NUInt32 IMath<NUInt32>.Log(NUInt32 x) => (uint)Math.Log(x._value);
            NUInt32 IMath<NUInt32>.Log(NUInt32 x, NUInt32 y) => (uint)Math.Log(x._value, y._value);
            NUInt32 IMath<NUInt32>.Log10(NUInt32 x) => (uint)Math.Log10(x._value);
            NUInt32 IMath<NUInt32>.Max(NUInt32 x, NUInt32 y) => Math.Max(x._value, y._value);
            NUInt32 IMath<NUInt32>.Min(NUInt32 x, NUInt32 y) => Math.Min(x._value, y._value);
            NUInt32 IMath<NUInt32>.PI { get; } = (uint)3;
            NUInt32 IMath<NUInt32>.Pow(NUInt32 x, NUInt32 y) => (uint)Math.Pow(x._value, y._value);
            NUInt32 IMath<NUInt32>.Round(NUInt32 x) => x;
            NUInt32 IMath<NUInt32>.Round(NUInt32 x, int digits) => x;
            NUInt32 IMath<NUInt32>.Round(NUInt32 x, int digits, MidpointRounding mode) => x;
            NUInt32 IMath<NUInt32>.Round(NUInt32 x, MidpointRounding mode) => x;
            NUInt32 IMath<NUInt32>.Sin(NUInt32 x) => (uint)Math.Sin(x._value);
            NUInt32 IMath<NUInt32>.Sinh(NUInt32 x) => (uint)Math.Sinh(x._value);
            NUInt32 IMath<NUInt32>.Sqrt(NUInt32 x) => (uint)Math.Sqrt(x._value);
            NUInt32 IMath<NUInt32>.Tan(NUInt32 x) => (uint)Math.Tan(x._value);
            NUInt32 IMath<NUInt32>.Tanh(NUInt32 x) => (uint)Math.Tanh(x._value);
            NUInt32 IMath<NUInt32>.Tau { get; } = (uint)6;
            NUInt32 IMath<NUInt32>.Truncate(NUInt32 x) => x;

            int INumericBitConverter<NUInt32>.ConvertedSize => sizeof(uint);
            NUInt32 INumericBitConverter<NUInt32>.ToNumeric(byte[] value, int startIndex) => BitConverter.ToUInt32(value, startIndex);
            byte[] INumericBitConverter<NUInt32>.GetBytes(NUInt32 value) => BitConverter.GetBytes(value._value);
#if HAS_SPANS
            NUInt32 INumericBitConverter<NUInt32>.ToNumeric(ReadOnlySpan<byte> value) => BitConverter.ToUInt32(value);
            bool INumericBitConverter<NUInt32>.TryWriteBytes(Span<byte> destination, NUInt32 value) => BitConverter.TryWriteBytes(destination, value);
#endif

            bool IConvert<NUInt32>.ToBoolean(NUInt32 value) => Convert.ToBoolean(value._value);
            byte IConvert<NUInt32>.ToByte(NUInt32 value, Conversion mode) => ConvertN.ToByte(value._value, mode);
            decimal IConvert<NUInt32>.ToDecimal(NUInt32 value, Conversion mode) => ConvertN.ToDecimal(value._value, mode);
            double IConvert<NUInt32>.ToDouble(NUInt32 value, Conversion mode) => ConvertN.ToDouble(value._value, mode);
            float IConvert<NUInt32>.ToSingle(NUInt32 value, Conversion mode) => ConvertN.ToSingle(value._value, mode);
            int IConvert<NUInt32>.ToInt32(NUInt32 value, Conversion mode) => ConvertN.ToInt32(value._value, mode);
            long IConvert<NUInt32>.ToInt64(NUInt32 value, Conversion mode) => ConvertN.ToInt64(value._value, mode);
            sbyte IConvertExtended<NUInt32>.ToSByte(NUInt32 value, Conversion mode) => ConvertN.ToSByte(value._value, mode);
            short IConvert<NUInt32>.ToInt16(NUInt32 value, Conversion mode) => ConvertN.ToInt16(value._value, mode);
            string IConvert<NUInt32>.ToString(NUInt32 value) => Convert.ToString(value._value);
            uint IConvertExtended<NUInt32>.ToUInt32(NUInt32 value, Conversion mode) => ConvertN.ToUInt32(value._value, mode);
            ulong IConvertExtended<NUInt32>.ToUInt64(NUInt32 value, Conversion mode) => ConvertN.ToUInt64(value._value, mode);
            ushort IConvertExtended<NUInt32>.ToUInt16(NUInt32 value, Conversion mode) => ConvertN.ToUInt16(value._value, mode);

            NUInt32 IConvert<NUInt32>.ToNumeric(bool value) => Convert.ToUInt32(value);
            NUInt32 IConvert<NUInt32>.ToNumeric(byte value, Conversion mode) => ConvertN.ToUInt32(value, mode);
            NUInt32 IConvert<NUInt32>.ToNumeric(decimal value, Conversion mode) => ConvertN.ToUInt32(value, mode);
            NUInt32 IConvert<NUInt32>.ToNumeric(double value, Conversion mode) => ConvertN.ToUInt32(value, mode);
            NUInt32 IConvert<NUInt32>.ToNumeric(float value, Conversion mode) => ConvertN.ToUInt32(value, mode);
            NUInt32 IConvert<NUInt32>.ToNumeric(int value, Conversion mode) => ConvertN.ToUInt32(value, mode);
            NUInt32 IConvert<NUInt32>.ToNumeric(long value, Conversion mode) => ConvertN.ToUInt32(value, mode);
            NUInt32 IConvertExtended<NUInt32>.ToValue(sbyte value, Conversion mode) => ConvertN.ToUInt32(value, mode);
            NUInt32 IConvert<NUInt32>.ToNumeric(short value, Conversion mode) => ConvertN.ToUInt32(value, mode);
            NUInt32 IConvert<NUInt32>.ToNumeric(string value) => Convert.ToUInt32(value);
            NUInt32 IConvertExtended<NUInt32>.ToNumeric(uint value, Conversion mode) => ConvertN.ToUInt32(value, mode);
            NUInt32 IConvertExtended<NUInt32>.ToNumeric(ulong value, Conversion mode) => ConvertN.ToUInt32(value, mode);
            NUInt32 IConvertExtended<NUInt32>.ToNumeric(ushort value, Conversion mode) => ConvertN.ToUInt32(value, mode);

            NUInt32 INumericStatic<NUInt32>.Parse(string s, NumberStyles? style, IFormatProvider? provider)
                => Parse(s, style ?? NumberStyles.Integer, provider);

            NUInt32 INumericRandom<NUInt32>.Generate(Random random) => random.NextUInt32();
            NUInt32 INumericRandom<NUInt32>.Generate(Random random, NUInt32 maxValue) => random.NextUInt32(maxValue);
            NUInt32 INumericRandom<NUInt32>.Generate(Random random, NUInt32 minValue, NUInt32 maxValue) => random.NextUInt32(minValue, maxValue);
            NUInt32 INumericRandom<NUInt32>.Generate(Random random, Generation mode) => random.NextUInt32(mode);
            NUInt32 INumericRandom<NUInt32>.Generate(Random random, NUInt32 minValue, NUInt32 maxValue, Generation mode) => random.NextUInt32(minValue, maxValue, mode);

            NUInt32 IVariantRandom<NUInt32>.Generate(Random random, Variants variants) => random.NextUInt32(variants);
        }
    }
}
