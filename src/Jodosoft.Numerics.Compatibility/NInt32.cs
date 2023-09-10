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
    /// Represents a 32-bit signed integer.
    /// </summary>
    [Serializable]
    [DebuggerDisplay("{ToString(),nq}")]
    public readonly struct NInt32 : INumericExtended<NInt32>
    {
        /// <inheritdoc cref="int.MaxValue" />
        public static readonly NInt32 MaxValue = new NInt32(int.MaxValue);

        /// <inheritdoc cref="int.MinValue" />
        public static readonly NInt32 MinValue = new NInt32(int.MinValue);

        private readonly int _value;

        private NInt32(int value)
        {
            _value = value;
        }

        private NInt32(SerializationInfo info, StreamingContext context) : this(info.GetInt32(nameof(NInt32))) { }
        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context) => info.AddValue(nameof(NInt32), _value);

        public int CompareTo(NInt32 other) => _value.CompareTo(other._value);
        public int CompareTo(object? obj) => obj is NInt32 other ? CompareTo(other) : 1;
        public bool Equals(NInt32 other) => _value == other._value;
        public override bool Equals(object? obj) => obj is NInt32 other && Equals(other);
        public override int GetHashCode() => _value.GetHashCode();
        public override string ToString() => _value.ToString();
        public string ToString(IFormatProvider? provider) => _value.ToString(provider);
        public string ToString(string format) => _value.ToString(format);
        public string ToString(string? format, IFormatProvider? formatProvider) => _value.ToString(format, formatProvider);

        public static bool TryParse(string s, IFormatProvider? provider, out NInt32 result) => FuncExtensions.Try(() => Parse(s, provider), out result);
        public static bool TryParse(string s, NumberStyles style, IFormatProvider? provider, out NInt32 result) => FuncExtensions.Try(() => Parse(s, style, provider), out result);
        public static bool TryParse(string s, NumberStyles style, out NInt32 result) => FuncExtensions.Try(() => Parse(s, style), out result);
        public static bool TryParse(string s, out NInt32 result) => FuncExtensions.Try(() => Parse(s), out result);
        public static NInt32 Parse(string s) => int.Parse(s);
        public static NInt32 Parse(string s, IFormatProvider? provider) => int.Parse(s, provider);
        public static NInt32 Parse(string s, NumberStyles style) => int.Parse(s, style);
        public static NInt32 Parse(string s, NumberStyles style, IFormatProvider? provider) => int.Parse(s, style, provider);

        [CLSCompliant(false)] public static explicit operator NInt32(uint value) => new NInt32((int)value);
        [CLSCompliant(false)] public static explicit operator NInt32(ulong value) => new NInt32((int)value);
        [CLSCompliant(false)] public static implicit operator NInt32(sbyte value) => new NInt32(value);
        [CLSCompliant(false)] public static implicit operator NInt32(ushort value) => new NInt32(value);
        public static explicit operator NInt32(decimal value) => new NInt32((int)value);
        public static explicit operator NInt32(double value) => new NInt32((int)value);
        public static explicit operator NInt32(float value) => new NInt32((int)value);
        public static explicit operator NInt32(long value) => new NInt32((int)value);
        public static implicit operator NInt32(byte value) => new NInt32(value);
        public static implicit operator NInt32(int value) => new NInt32(value);
        public static implicit operator NInt32(short value) => new NInt32(value);

        [CLSCompliant(false)] public static explicit operator sbyte(NInt32 value) => (sbyte)value._value;
        [CLSCompliant(false)] public static explicit operator uint(NInt32 value) => (uint)value._value;
        [CLSCompliant(false)] public static explicit operator ulong(NInt32 value) => (ulong)value._value;
        [CLSCompliant(false)] public static explicit operator ushort(NInt32 value) => (ushort)value._value;
        public static explicit operator byte(NInt32 value) => (byte)value._value;
        public static explicit operator short(NInt32 value) => (short)value._value;
        public static implicit operator decimal(NInt32 value) => value._value;
        public static implicit operator double(NInt32 value) => value._value;
        public static implicit operator float(NInt32 value) => value._value;
        public static implicit operator int(NInt32 value) => value._value;
        public static implicit operator long(NInt32 value) => value._value;

        public static bool operator !=(NInt32 left, NInt32 right) => left._value != right._value;
        public static bool operator <(NInt32 left, NInt32 right) => left._value < right._value;
        public static bool operator <=(NInt32 left, NInt32 right) => left._value <= right._value;
        public static bool operator ==(NInt32 left, NInt32 right) => left._value == right._value;
        public static bool operator >(NInt32 left, NInt32 right) => left._value > right._value;
        public static bool operator >=(NInt32 left, NInt32 right) => left._value >= right._value;
        public static NInt32 operator %(NInt32 left, NInt32 right) => left._value % right._value;
        public static NInt32 operator &(NInt32 left, NInt32 right) => left._value & right._value;
        public static NInt32 operator -(NInt32 left, NInt32 right) => left._value - right._value;
        public static NInt32 operator --(NInt32 value) => value._value - 1;
        public static NInt32 operator -(NInt32 value) => -value._value;
        public static NInt32 operator *(NInt32 left, NInt32 right) => left._value * right._value;
        public static NInt32 operator /(NInt32 left, NInt32 right) => left._value / right._value;
        public static NInt32 operator ^(NInt32 left, NInt32 right) => left._value ^ right._value;
        public static NInt32 operator |(NInt32 left, NInt32 right) => left._value | right._value;
        public static NInt32 operator ~(NInt32 value) => ~value._value;
        public static NInt32 operator +(NInt32 left, NInt32 right) => left._value + right._value;
        public static NInt32 operator +(NInt32 value) => value;
        public static NInt32 operator ++(NInt32 value) => value._value + 1;
        public static NInt32 operator <<(NInt32 left, int right) => left._value << right;
        public static NInt32 operator >>(NInt32 left, int right) => left._value >> right;

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

        bool INumeric<NInt32>.IsGreaterThan(NInt32 value) => this > value;
        bool INumeric<NInt32>.IsGreaterThanOrEqualTo(NInt32 value) => this >= value;
        bool INumeric<NInt32>.IsLessThan(NInt32 value) => this < value;
        bool INumeric<NInt32>.IsLessThanOrEqualTo(NInt32 value) => this <= value;
        NInt32 INumeric<NInt32>.Add(NInt32 value) => this + value;
        NInt32 INumeric<NInt32>.BitwiseComplement() => ~this;
        NInt32 INumeric<NInt32>.Divide(NInt32 value) => this / value;
        NInt32 INumeric<NInt32>.LeftShift(int count) => this << count;
        NInt32 INumeric<NInt32>.LogicalAnd(NInt32 value) => this & value;
        NInt32 INumeric<NInt32>.LogicalExclusiveOr(NInt32 value) => this ^ value;
        NInt32 INumeric<NInt32>.LogicalOr(NInt32 value) => this | value;
        NInt32 INumeric<NInt32>.Multiply(NInt32 value) => this * value;
        NInt32 INumeric<NInt32>.Negative() => -this;
        NInt32 INumeric<NInt32>.Positive() => +this;
        NInt32 INumeric<NInt32>.Remainder(NInt32 value) => this % value;
        NInt32 INumeric<NInt32>.RightShift(int count) => this >> count;
        NInt32 INumeric<NInt32>.Subtract(NInt32 value) => this - value;

        INumericBitConverter<NInt32> IProvider<INumericBitConverter<NInt32>>.GetInstance() => Utilities.Instance;
        IBinaryIO<NInt32> IProvider<IBinaryIO<NInt32>>.GetInstance() => Utilities.Instance;
        IConvert<NInt32> IProvider<IConvert<NInt32>>.GetInstance() => Utilities.Instance;
        IConvertExtended<NInt32> IProvider<IConvertExtended<NInt32>>.GetInstance() => Utilities.Instance;
        IMath<NInt32> IProvider<IMath<NInt32>>.GetInstance() => Utilities.Instance;
        INumericRandom<NInt32> IProvider<INumericRandom<NInt32>>.GetInstance() => Utilities.Instance;
        INumericStatic<NInt32> IProvider<INumericStatic<NInt32>>.GetInstance() => Utilities.Instance;
        IVariantRandom<NInt32> IProvider<IVariantRandom<NInt32>>.GetInstance() => Utilities.Instance;

        private sealed class Utilities :
            IBinaryIO<NInt32>,
            IConvert<NInt32>,
            IConvertExtended<NInt32>,
            IMath<NInt32>,
            INumericBitConverter<NInt32>,
            INumericRandom<NInt32>,
            INumericStatic<NInt32>,
            IVariantRandom<NInt32>
        {
            public static readonly Utilities Instance = new Utilities();

            void IBinaryIO<NInt32>.Write(BinaryWriter writer, NInt32 value) => writer.Write(value);
            NInt32 IBinaryIO<NInt32>.Read(BinaryReader reader) => reader.ReadInt32();

            bool INumericStatic<NInt32>.HasFloatingPoint => false;
            bool INumericStatic<NInt32>.HasInfinity => false;
            bool INumericStatic<NInt32>.HasNaN => false;
            bool INumericStatic<NInt32>.IsFinite(NInt32 x) => true;
            bool INumericStatic<NInt32>.IsInfinity(NInt32 x) => false;
            bool INumericStatic<NInt32>.IsNaN(NInt32 x) => false;
            bool INumericStatic<NInt32>.IsNegative(NInt32 x) => x._value < 0;
            bool INumericStatic<NInt32>.IsNegativeInfinity(NInt32 x) => false;
            bool INumericStatic<NInt32>.IsNormal(NInt32 x) => false;
            bool INumericStatic<NInt32>.IsPositiveInfinity(NInt32 x) => false;
            bool INumericStatic<NInt32>.IsReal => false;
            bool INumericStatic<NInt32>.IsSigned => true;
            bool INumericStatic<NInt32>.IsSubnormal(NInt32 x) => false;
            NInt32 INumericStatic<NInt32>.Epsilon => 1;
            NInt32 INumericStatic<NInt32>.MaxUnit => 1;
            NInt32 INumericStatic<NInt32>.MaxValue => MaxValue;
            NInt32 INumericStatic<NInt32>.MinUnit => -1;
            NInt32 INumericStatic<NInt32>.MinValue => MinValue;
            NInt32 INumericStatic<NInt32>.One => 1;
            NInt32 INumericStatic<NInt32>.Zero => 0;

            int IMath<NInt32>.Sign(NInt32 x) => Math.Sign(x._value);
            NInt32 IMath<NInt32>.Abs(NInt32 value) => Math.Abs(value._value);
            NInt32 IMath<NInt32>.Acos(NInt32 x) => (int)Math.Acos(x._value);
            NInt32 IMath<NInt32>.Acosh(NInt32 x) => (int)MathShim.Acosh(x._value);
            NInt32 IMath<NInt32>.Asin(NInt32 x) => (int)Math.Asin(x._value);
            NInt32 IMath<NInt32>.Asinh(NInt32 x) => (int)MathShim.Asinh(x._value);
            NInt32 IMath<NInt32>.Atan(NInt32 x) => (int)Math.Atan(x._value);
            NInt32 IMath<NInt32>.Atan2(NInt32 x, NInt32 y) => (int)Math.Atan2(x._value, y._value);
            NInt32 IMath<NInt32>.Atanh(NInt32 x) => (int)MathShim.Atanh(x._value);
            NInt32 IMath<NInt32>.Cbrt(NInt32 x) => (int)MathShim.Cbrt(x._value);
            NInt32 IMath<NInt32>.Ceiling(NInt32 x) => x;
            NInt32 IMath<NInt32>.Clamp(NInt32 x, NInt32 bound1, NInt32 bound2) => bound1 > bound2 ? Math.Min(bound1._value, Math.Max(bound2._value, x._value)) : Math.Min(bound2._value, Math.Max(bound1._value, x._value));
            NInt32 IMath<NInt32>.Cos(NInt32 x) => (int)Math.Cos(x._value);
            NInt32 IMath<NInt32>.Cosh(NInt32 x) => (int)Math.Cosh(x._value);
            NInt32 IMath<NInt32>.E { get; } = 2;
            NInt32 IMath<NInt32>.Exp(NInt32 x) => (int)Math.Exp(x._value);
            NInt32 IMath<NInt32>.Floor(NInt32 x) => x;
            NInt32 IMath<NInt32>.IEEERemainder(NInt32 x, NInt32 y) => (int)Math.IEEERemainder(x._value, y._value);
            NInt32 IMath<NInt32>.Log(NInt32 x) => (int)Math.Log(x._value);
            NInt32 IMath<NInt32>.Log(NInt32 x, NInt32 y) => (int)Math.Log(x._value, y._value);
            NInt32 IMath<NInt32>.Log10(NInt32 x) => (int)Math.Log10(x._value);
            NInt32 IMath<NInt32>.Max(NInt32 x, NInt32 y) => Math.Max(x._value, y._value);
            NInt32 IMath<NInt32>.Min(NInt32 x, NInt32 y) => Math.Min(x._value, y._value);
            NInt32 IMath<NInt32>.PI { get; } = 3;
            NInt32 IMath<NInt32>.Pow(NInt32 x, NInt32 y) => (int)Math.Pow(x._value, y._value);
            NInt32 IMath<NInt32>.Round(NInt32 x) => x;
            NInt32 IMath<NInt32>.Round(NInt32 x, int digits) => x;
            NInt32 IMath<NInt32>.Round(NInt32 x, int digits, MidpointRounding mode) => x;
            NInt32 IMath<NInt32>.Round(NInt32 x, MidpointRounding mode) => x;
            NInt32 IMath<NInt32>.Sin(NInt32 x) => (int)Math.Sin(x._value);
            NInt32 IMath<NInt32>.Sinh(NInt32 x) => (int)Math.Sinh(x._value);
            NInt32 IMath<NInt32>.Sqrt(NInt32 x) => (int)Math.Sqrt(x._value);
            NInt32 IMath<NInt32>.Tan(NInt32 x) => (int)Math.Tan(x._value);
            NInt32 IMath<NInt32>.Tanh(NInt32 x) => (int)Math.Tanh(x._value);
            NInt32 IMath<NInt32>.Tau { get; } = 6;
            NInt32 IMath<NInt32>.Truncate(NInt32 x) => x;

            int INumericBitConverter<NInt32>.ConvertedSize => sizeof(int);
            NInt32 INumericBitConverter<NInt32>.ToNumeric(byte[] value, int startIndex) => BitConverter.ToInt32(value, startIndex);
            byte[] INumericBitConverter<NInt32>.GetBytes(NInt32 value) => BitConverter.GetBytes(value._value);
#if HAS_SPANS
            NInt32 INumericBitConverter<NInt32>.ToNumeric(ReadOnlySpan<byte> value) => BitConverter.ToInt32(value);
            bool INumericBitConverter<NInt32>.TryWriteBytes(Span<byte> destination, NInt32 value) => BitConverter.TryWriteBytes(destination, value);
#endif

            bool IConvert<NInt32>.ToBoolean(NInt32 value) => Convert.ToBoolean(value._value);
            byte IConvert<NInt32>.ToByte(NInt32 value, Conversion mode) => ConvertN.ToByte(value._value, mode);
            decimal IConvert<NInt32>.ToDecimal(NInt32 value, Conversion mode) => ConvertN.ToDecimal(value._value, mode);
            double IConvert<NInt32>.ToDouble(NInt32 value, Conversion mode) => ConvertN.ToDouble(value._value, mode);
            float IConvert<NInt32>.ToSingle(NInt32 value, Conversion mode) => ConvertN.ToSingle(value._value, mode);
            int IConvert<NInt32>.ToInt32(NInt32 value, Conversion mode) => ConvertN.ToInt32(value._value, mode);
            long IConvert<NInt32>.ToInt64(NInt32 value, Conversion mode) => ConvertN.ToInt64(value._value, mode);
            sbyte IConvertExtended<NInt32>.ToSByte(NInt32 value, Conversion mode) => ConvertN.ToSByte(value._value, mode);
            short IConvert<NInt32>.ToInt16(NInt32 value, Conversion mode) => ConvertN.ToInt16(value._value, mode);
            string IConvert<NInt32>.ToString(NInt32 value) => Convert.ToString(value._value);
            uint IConvertExtended<NInt32>.ToUInt32(NInt32 value, Conversion mode) => ConvertN.ToUInt32(value._value, mode);
            ulong IConvertExtended<NInt32>.ToUInt64(NInt32 value, Conversion mode) => ConvertN.ToUInt64(value._value, mode);
            ushort IConvertExtended<NInt32>.ToUInt16(NInt32 value, Conversion mode) => ConvertN.ToUInt16(value._value, mode);

            NInt32 IConvert<NInt32>.ToNumeric(bool value) => Convert.ToInt32(value);
            NInt32 IConvert<NInt32>.ToNumeric(byte value, Conversion mode) => ConvertN.ToInt32(value, mode);
            NInt32 IConvert<NInt32>.ToNumeric(decimal value, Conversion mode) => ConvertN.ToInt32(value, mode);
            NInt32 IConvert<NInt32>.ToNumeric(double value, Conversion mode) => ConvertN.ToInt32(value, mode);
            NInt32 IConvert<NInt32>.ToNumeric(float value, Conversion mode) => ConvertN.ToInt32(value, mode);
            NInt32 IConvert<NInt32>.ToNumeric(int value, Conversion mode) => ConvertN.ToInt32(value, mode);
            NInt32 IConvert<NInt32>.ToNumeric(long value, Conversion mode) => ConvertN.ToInt32(value, mode);
            NInt32 IConvertExtended<NInt32>.ToValue(sbyte value, Conversion mode) => ConvertN.ToInt32(value, mode);
            NInt32 IConvert<NInt32>.ToNumeric(short value, Conversion mode) => ConvertN.ToInt32(value, mode);
            NInt32 IConvert<NInt32>.ToNumeric(string value) => Convert.ToInt32(value);
            NInt32 IConvertExtended<NInt32>.ToNumeric(uint value, Conversion mode) => ConvertN.ToInt32(value, mode);
            NInt32 IConvertExtended<NInt32>.ToNumeric(ulong value, Conversion mode) => ConvertN.ToInt32(value, mode);
            NInt32 IConvertExtended<NInt32>.ToNumeric(ushort value, Conversion mode) => ConvertN.ToInt32(value, mode);

            NInt32 INumericStatic<NInt32>.Parse(string s, NumberStyles? style, IFormatProvider? provider)
                => Parse(s, style ?? NumberStyles.Integer, provider);

            NInt32 INumericRandom<NInt32>.Generate(Random random) => random.NextInt32();
            NInt32 INumericRandom<NInt32>.Generate(Random random, NInt32 maxValue) => random.NextInt32(maxValue);
            NInt32 INumericRandom<NInt32>.Generate(Random random, NInt32 minValue, NInt32 maxValue) => random.NextInt32(minValue, maxValue);
            NInt32 INumericRandom<NInt32>.Generate(Random random, Generation mode) => random.NextInt32(mode);
            NInt32 INumericRandom<NInt32>.Generate(Random random, NInt32 minValue, NInt32 maxValue, Generation mode) => random.NextInt32(minValue, maxValue, mode);

            NInt32 IVariantRandom<NInt32>.Generate(Random random, Variants variants) => random.NextInt32(variants);
        }
    }
}
