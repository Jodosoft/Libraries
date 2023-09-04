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

namespace Jodosoft.Numerics.Clamped
{
    /// <summary>
    /// Represents a 64-bit signed integer that cannot overflow.
    /// </summary>
    [Serializable]
    [DebuggerDisplay("{ToString(),nq}")]
    public readonly struct Int64M : INumericExtended<Int64M>
    {
        public static readonly Int64M MaxValue = new Int64M(long.MaxValue);
        public static readonly Int64M MinValue = new Int64M(long.MinValue);

        private readonly long _value;

        private Int64M(long value)
        {
            _value = value;
        }

        private Int64M(SerializationInfo info, StreamingContext context) : this(info.GetInt64(nameof(Int64M))) { }
        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context) => info.AddValue(nameof(Int64M), _value);

        public int CompareTo(Int64M other) => _value.CompareTo(other._value);
        public int CompareTo(object? obj) => obj is Int64M other ? CompareTo(other) : 1;
        public bool Equals(Int64M other) => _value == other._value;
        public override bool Equals(object? obj) => obj is Int64M other && Equals(other);
        public override int GetHashCode() => _value.GetHashCode();
        public override string ToString() => _value.ToString();
        public string ToString(IFormatProvider formatProvider) => _value.ToString(formatProvider);
        public string ToString(string format) => _value.ToString(format);
        public string ToString(string? format, IFormatProvider? formatProvider) => _value.ToString(format, formatProvider);

        public static bool TryParse(string s, IFormatProvider? provider, out Int64M result) => FuncExtensions.Try(() => Parse(s, provider), out result);
        public static bool TryParse(string s, NumberStyles style, IFormatProvider? provider, out Int64M result) => FuncExtensions.Try(() => Parse(s, style, provider), out result);
        public static bool TryParse(string s, NumberStyles style, out Int64M result) => FuncExtensions.Try(() => Parse(s, style), out result);
        public static bool TryParse(string s, out Int64M result) => FuncExtensions.Try(() => Parse(s), out result);
        public static Int64M Parse(string s) => long.Parse(s);
        public static Int64M Parse(string s, IFormatProvider? provider) => long.Parse(s, provider);
        public static Int64M Parse(string s, NumberStyles style) => long.Parse(s, style);
        public static Int64M Parse(string s, NumberStyles style, IFormatProvider? provider) => long.Parse(s, style, provider);

        [CLSCompliant(false)] public static explicit operator Int64M(ulong value) => new Int64M(ConvertN.ToInt64(value, Conversion.CastClamp));
        [CLSCompliant(false)] public static implicit operator Int64M(sbyte value) => new Int64M(value);
        [CLSCompliant(false)] public static implicit operator Int64M(uint value) => new Int64M(value);
        [CLSCompliant(false)] public static implicit operator Int64M(ushort value) => new Int64M(value);
        public static explicit operator Int64M(decimal value) => new Int64M(ConvertN.ToInt64(value, Conversion.CastClamp));
        public static explicit operator Int64M(double value) => new Int64M(ConvertN.ToInt64(value, Conversion.CastClamp));
        public static explicit operator Int64M(float value) => new Int64M(ConvertN.ToInt64(value, Conversion.CastClamp));
        public static implicit operator Int64M(byte value) => new Int64M(value);
        public static implicit operator Int64M(int value) => new Int64M(value);
        public static implicit operator Int64M(long value) => new Int64M(value);
        public static implicit operator Int64M(short value) => new Int64M(value);

        [CLSCompliant(false)] public static explicit operator sbyte(Int64M value) => ConvertN.ToSByte(value._value, Conversion.CastClamp);
        [CLSCompliant(false)] public static explicit operator uint(Int64M value) => ConvertN.ToUInt32(value._value, Conversion.CastClamp);
        [CLSCompliant(false)] public static explicit operator ulong(Int64M value) => ConvertN.ToUInt64(value._value, Conversion.CastClamp);
        [CLSCompliant(false)] public static explicit operator ushort(Int64M value) => ConvertN.ToUInt16(value._value, Conversion.CastClamp);
        public static explicit operator byte(Int64M value) => ConvertN.ToByte(value._value, Conversion.CastClamp);
        public static explicit operator int(Int64M value) => ConvertN.ToInt32(value._value, Conversion.CastClamp);
        public static explicit operator short(Int64M value) => ConvertN.ToInt16(value._value, Conversion.CastClamp);
        public static implicit operator decimal(Int64M value) => value._value;
        public static implicit operator double(Int64M value) => value._value;
        public static implicit operator float(Int64M value) => value._value;
        public static implicit operator long(Int64M value) => value._value;

        public static bool operator !=(Int64M left, Int64M right) => left._value != right._value;
        public static bool operator <(Int64M left, Int64M right) => left._value < right._value;
        public static bool operator <=(Int64M left, Int64M right) => left._value <= right._value;
        public static bool operator ==(Int64M left, Int64M right) => left._value == right._value;
        public static bool operator >(Int64M left, Int64M right) => left._value > right._value;
        public static bool operator >=(Int64M left, Int64M right) => left._value >= right._value;
        public static Int64M operator %(Int64M left, Int64M right) => Clamped.Remainder(left._value, right._value);
        public static Int64M operator &(Int64M left, Int64M right) => left._value & right._value;
        public static Int64M operator -(Int64M left, Int64M right) => Clamped.Subtract(left._value, right._value);
        public static Int64M operator --(Int64M value) => Clamped.Subtract(value._value, 1);
        public static Int64M operator -(Int64M value) => -value._value;
        public static Int64M operator *(Int64M left, Int64M right) => Clamped.Multiply(left._value, right._value);
        public static Int64M operator /(Int64M left, Int64M right) => Clamped.Divide(left._value, right._value);
        public static Int64M operator ^(Int64M left, Int64M right) => left._value ^ right._value;
        public static Int64M operator |(Int64M left, Int64M right) => left._value | right._value;
        public static Int64M operator ~(Int64M value) => ~value._value;
        public static Int64M operator +(Int64M left, Int64M right) => Clamped.Add(left._value, right._value);
        public static Int64M operator +(Int64M value) => value;
        public static Int64M operator ++(Int64M value) => Clamped.Add(value._value, 1);
        public static Int64M operator <<(Int64M left, int right) => left._value << right;
        public static Int64M operator >>(Int64M left, int right) => left._value >> right;

        TypeCode IConvertible.GetTypeCode() => _value.GetTypeCode();
        bool IConvertible.ToBoolean(IFormatProvider provider) => Convert.ToBoolean(_value, provider);
        byte IConvertible.ToByte(IFormatProvider provider) => ConvertN.ToByte(_value, Conversion.Clamp);
        char IConvertible.ToChar(IFormatProvider provider) => Convert.ToChar(_value, provider);
        DateTime IConvertible.ToDateTime(IFormatProvider provider) => Convert.ToDateTime(provider);
        decimal IConvertible.ToDecimal(IFormatProvider provider) => ConvertN.ToDecimal(_value, Conversion.Clamp);
        double IConvertible.ToDouble(IFormatProvider provider) => ConvertN.ToDouble(_value, Conversion.Clamp);
        float IConvertible.ToSingle(IFormatProvider provider) => ConvertN.ToSingle(_value, Conversion.Clamp);
        int IConvertible.ToInt32(IFormatProvider provider) => ConvertN.ToInt32(_value, Conversion.Clamp);
        long IConvertible.ToInt64(IFormatProvider provider) => _value;
        sbyte IConvertible.ToSByte(IFormatProvider provider) => ConvertN.ToSByte(_value, Conversion.Clamp);
        short IConvertible.ToInt16(IFormatProvider provider) => ConvertN.ToInt16(_value, Conversion.Clamp);
        uint IConvertible.ToUInt32(IFormatProvider provider) => ConvertN.ToUInt32(_value, Conversion.Clamp);
        ulong IConvertible.ToUInt64(IFormatProvider provider) => ConvertN.ToUInt64(_value, Conversion.Clamp);
        ushort IConvertible.ToUInt16(IFormatProvider provider) => ConvertN.ToUInt16(_value, Conversion.Clamp);
        object IConvertible.ToType(Type conversionType, IFormatProvider provider) => this.ToTypeDefault(conversionType, provider);

        bool INumeric<Int64M>.IsGreaterThan(Int64M value) => this > value;
        bool INumeric<Int64M>.IsGreaterThanOrEqualTo(Int64M value) => this >= value;
        bool INumeric<Int64M>.IsLessThan(Int64M value) => this < value;
        bool INumeric<Int64M>.IsLessThanOrEqualTo(Int64M value) => this <= value;
        Int64M INumeric<Int64M>.Add(Int64M value) => this + value;
        Int64M INumeric<Int64M>.BitwiseComplement() => ~this;
        Int64M INumeric<Int64M>.Divide(Int64M value) => this / value;
        Int64M INumeric<Int64M>.LeftShift(int count) => this << count;
        Int64M INumeric<Int64M>.LogicalAnd(Int64M value) => this & value;
        Int64M INumeric<Int64M>.LogicalExclusiveOr(Int64M value) => this ^ value;
        Int64M INumeric<Int64M>.LogicalOr(Int64M value) => this | value;
        Int64M INumeric<Int64M>.Multiply(Int64M value) => this * value;
        Int64M INumeric<Int64M>.Negative() => -this;
        Int64M INumeric<Int64M>.Positive() => +this;
        Int64M INumeric<Int64M>.Remainder(Int64M value) => this % value;
        Int64M INumeric<Int64M>.RightShift(int count) => this >> count;
        Int64M INumeric<Int64M>.Subtract(Int64M value) => this - value;

        INumericBitConverter<Int64M> IProvider<INumericBitConverter<Int64M>>.GetInstance() => Utilities.Instance;
        IBinaryIO<Int64M> IProvider<IBinaryIO<Int64M>>.GetInstance() => Utilities.Instance;
        IConvert<Int64M> IProvider<IConvert<Int64M>>.GetInstance() => Utilities.Instance;
        IConvertExtended<Int64M> IProvider<IConvertExtended<Int64M>>.GetInstance() => Utilities.Instance;
        IMath<Int64M> IProvider<IMath<Int64M>>.GetInstance() => Utilities.Instance;
        INumericRandom<Int64M> IProvider<INumericRandom<Int64M>>.GetInstance() => Utilities.Instance;
        INumericStatic<Int64M> IProvider<INumericStatic<Int64M>>.GetInstance() => Utilities.Instance;
        IVariantRandom<Int64M> IProvider<IVariantRandom<Int64M>>.GetInstance() => Utilities.Instance;

        private sealed class Utilities :
            IBinaryIO<Int64M>,
            IConvert<Int64M>,
            IConvertExtended<Int64M>,
            IMath<Int64M>,
            INumericBitConverter<Int64M>,
            INumericRandom<Int64M>,
            INumericStatic<Int64M>,
            IVariantRandom<Int64M>
        {
            public static readonly Utilities Instance = new Utilities();

            void IBinaryIO<Int64M>.Write(BinaryWriter writer, Int64M value) => writer.Write(value);
            Int64M IBinaryIO<Int64M>.Read(BinaryReader reader) => reader.ReadInt64();

            bool INumericStatic<Int64M>.HasFloatingPoint => false;
            bool INumericStatic<Int64M>.HasInfinity => false;
            bool INumericStatic<Int64M>.HasNaN => false;
            bool INumericStatic<Int64M>.IsFinite(Int64M x) => true;
            bool INumericStatic<Int64M>.IsInfinity(Int64M x) => false;
            bool INumericStatic<Int64M>.IsNaN(Int64M x) => false;
            bool INumericStatic<Int64M>.IsNegative(Int64M x) => x._value < 0;
            bool INumericStatic<Int64M>.IsNegativeInfinity(Int64M x) => false;
            bool INumericStatic<Int64M>.IsNormal(Int64M x) => false;
            bool INumericStatic<Int64M>.IsPositiveInfinity(Int64M x) => false;
            bool INumericStatic<Int64M>.IsReal => false;
            bool INumericStatic<Int64M>.IsSigned => true;
            bool INumericStatic<Int64M>.IsSubnormal(Int64M x) => false;
            Int64M INumericStatic<Int64M>.Epsilon => 1L;
            Int64M INumericStatic<Int64M>.MaxUnit => 1L;
            Int64M INumericStatic<Int64M>.MaxValue => MaxValue;
            Int64M INumericStatic<Int64M>.MinUnit => -1L;
            Int64M INumericStatic<Int64M>.MinValue => MinValue;
            Int64M INumericStatic<Int64M>.One => 1L;
            Int64M INumericStatic<Int64M>.Zero => 0L;

            Int64M IMath<Int64M>.Abs(Int64M value) => Math.Abs(value);
            Int64M IMath<Int64M>.Acos(Int64M x) => (Int64M)Math.Acos(x);
            Int64M IMath<Int64M>.Acosh(Int64M x) => (Int64M)MathShim.Acosh(x);
            Int64M IMath<Int64M>.Asin(Int64M x) => (Int64M)Math.Asin(x);
            Int64M IMath<Int64M>.Asinh(Int64M x) => (Int64M)MathShim.Asinh(x);
            Int64M IMath<Int64M>.Atan(Int64M x) => (Int64M)Math.Atan(x);
            Int64M IMath<Int64M>.Atan2(Int64M y, Int64M x) => (Int64M)Math.Atan2(y, x);
            Int64M IMath<Int64M>.Atanh(Int64M x) => (Int64M)MathShim.Atanh(x);
            Int64M IMath<Int64M>.Cbrt(Int64M x) => (Int64M)MathShim.Cbrt(x);
            Int64M IMath<Int64M>.Ceiling(Int64M x) => x;
            Int64M IMath<Int64M>.Clamp(Int64M x, Int64M bound1, Int64M bound2) => bound1 > bound2 ? Math.Min(bound1, Math.Max(bound2, x)) : Math.Min(bound2, Math.Max(bound1, x));
            Int64M IMath<Int64M>.Cos(Int64M x) => (Int64M)Math.Cos(x);
            Int64M IMath<Int64M>.Cosh(Int64M x) => (Int64M)Math.Cosh(x);
            Int64M IMath<Int64M>.E { get; } = 2L;
            Int64M IMath<Int64M>.Exp(Int64M x) => (Int64M)Math.Exp(x);
            Int64M IMath<Int64M>.Floor(Int64M x) => x;
            Int64M IMath<Int64M>.IEEERemainder(Int64M x, Int64M y) => (Int64M)Math.IEEERemainder(x, y);
            Int64M IMath<Int64M>.Log(Int64M x) => (Int64M)Math.Log(x);
            Int64M IMath<Int64M>.Log(Int64M x, Int64M y) => (Int64M)Math.Log(x, y);
            Int64M IMath<Int64M>.Log10(Int64M x) => (Int64M)Math.Log10(x);
            Int64M IMath<Int64M>.Max(Int64M x, Int64M y) => Math.Max(x, y);
            Int64M IMath<Int64M>.Min(Int64M x, Int64M y) => Math.Min(x, y);
            Int64M IMath<Int64M>.PI { get; } = 3L;
            Int64M IMath<Int64M>.Pow(Int64M x, Int64M y) => Clamped.Pow(x, y);
            Int64M IMath<Int64M>.Round(Int64M x) => x;
            Int64M IMath<Int64M>.Round(Int64M x, int digits) => x;
            Int64M IMath<Int64M>.Round(Int64M x, int digits, MidpointRounding mode) => x;
            Int64M IMath<Int64M>.Round(Int64M x, MidpointRounding mode) => x;
            Int64M IMath<Int64M>.Sin(Int64M x) => (Int64M)Math.Sin(x);
            Int64M IMath<Int64M>.Sinh(Int64M x) => (Int64M)Math.Sinh(x);
            Int64M IMath<Int64M>.Sqrt(Int64M x) => (Int64M)Math.Sqrt(x);
            Int64M IMath<Int64M>.Tan(Int64M x) => (Int64M)Math.Tan(x);
            Int64M IMath<Int64M>.Tanh(Int64M x) => (Int64M)Math.Tanh(x);
            Int64M IMath<Int64M>.Tau { get; } = 6L;
            Int64M IMath<Int64M>.Truncate(Int64M x) => x;
            int IMath<Int64M>.Sign(Int64M x) => Math.Sign(x._value);

            int INumericBitConverter<Int64M>.ConvertedSize => sizeof(long);
            Int64M INumericBitConverter<Int64M>.ToNumeric(byte[] value, int startIndex) => BitConverter.ToInt64(value, startIndex);
            byte[] INumericBitConverter<Int64M>.GetBytes(Int64M value) => BitConverter.GetBytes(value._value);
#if HAS_SPANS
            Int64M INumericBitConverter<Int64M>.ToNumeric(ReadOnlySpan<byte> value) => BitConverter.ToInt64(value);
            bool INumericBitConverter<Int64M>.TryWriteBytes(Span<byte> destination, Int64M value) => BitConverter.TryWriteBytes(destination, value);
#endif

            bool IConvert<Int64M>.ToBoolean(Int64M value) => value._value != 0;
            byte IConvert<Int64M>.ToByte(Int64M value, Conversion mode) => ConvertN.ToByte(value._value, mode.Clamped());
            decimal IConvert<Int64M>.ToDecimal(Int64M value, Conversion mode) => ConvertN.ToDecimal(value._value, mode.Clamped());
            double IConvert<Int64M>.ToDouble(Int64M value, Conversion mode) => ConvertN.ToDouble(value._value, mode.Clamped());
            float IConvert<Int64M>.ToSingle(Int64M value, Conversion mode) => ConvertN.ToSingle(value._value, mode.Clamped());
            int IConvert<Int64M>.ToInt32(Int64M value, Conversion mode) => ConvertN.ToInt32(value._value, mode.Clamped());
            long IConvert<Int64M>.ToInt64(Int64M value, Conversion mode) => value._value;
            sbyte IConvertExtended<Int64M>.ToSByte(Int64M value, Conversion mode) => ConvertN.ToSByte(value._value, mode.Clamped());
            short IConvert<Int64M>.ToInt16(Int64M value, Conversion mode) => ConvertN.ToInt16(value._value, mode.Clamped());
            string IConvert<Int64M>.ToString(Int64M value) => Convert.ToString(value._value);
            uint IConvertExtended<Int64M>.ToUInt32(Int64M value, Conversion mode) => ConvertN.ToUInt32(value._value, mode.Clamped());
            ulong IConvertExtended<Int64M>.ToUInt64(Int64M value, Conversion mode) => ConvertN.ToUInt64(value._value, mode.Clamped());
            ushort IConvertExtended<Int64M>.ToUInt16(Int64M value, Conversion mode) => ConvertN.ToUInt16(value._value, mode.Clamped());

            Int64M IConvert<Int64M>.ToNumeric(bool value) => value ? 1 : 0;
            Int64M IConvert<Int64M>.ToNumeric(byte value, Conversion mode) => ConvertN.ToInt64(value, mode.Clamped());
            Int64M IConvert<Int64M>.ToNumeric(decimal value, Conversion mode) => ConvertN.ToInt64(value, mode.Clamped());
            Int64M IConvert<Int64M>.ToNumeric(double value, Conversion mode) => ConvertN.ToInt64(value, mode.Clamped());
            Int64M IConvert<Int64M>.ToNumeric(float value, Conversion mode) => ConvertN.ToInt64(value, mode.Clamped());
            Int64M IConvert<Int64M>.ToNumeric(int value, Conversion mode) => ConvertN.ToInt64(value, mode.Clamped());
            Int64M IConvert<Int64M>.ToNumeric(long value, Conversion mode) => value;
            Int64M IConvertExtended<Int64M>.ToValue(sbyte value, Conversion mode) => ConvertN.ToInt64(value, mode.Clamped());
            Int64M IConvert<Int64M>.ToNumeric(short value, Conversion mode) => ConvertN.ToInt64(value, mode.Clamped());
            Int64M IConvert<Int64M>.ToNumeric(string value) => Convert.ToInt64(value);
            Int64M IConvertExtended<Int64M>.ToNumeric(uint value, Conversion mode) => ConvertN.ToInt64(value, mode.Clamped());
            Int64M IConvertExtended<Int64M>.ToNumeric(ulong value, Conversion mode) => ConvertN.ToInt64(value, mode.Clamped());
            Int64M IConvertExtended<Int64M>.ToNumeric(ushort value, Conversion mode) => ConvertN.ToInt64(value, mode.Clamped());

            Int64M INumericStatic<Int64M>.Parse(string s, NumberStyles? style, IFormatProvider? provider)
                => Parse(s, style ?? NumberStyles.Integer, provider);

            Int64M INumericRandom<Int64M>.Generate(Random random) => random.NextInt64();
            Int64M INumericRandom<Int64M>.Generate(Random random, Int64M maxValue) => random.NextInt64(maxValue);
            Int64M INumericRandom<Int64M>.Generate(Random random, Int64M minValue, Int64M maxValue) => random.NextInt64(minValue, maxValue);
            Int64M INumericRandom<Int64M>.Generate(Random random, Generation mode) => random.NextInt64(mode);
            Int64M INumericRandom<Int64M>.Generate(Random random, Int64M minValue, Int64M maxValue, Generation mode) => random.NextInt64(minValue, maxValue, mode);

            Int64M IVariantRandom<Int64M>.Generate(Random random, Variants variants) => random.NextInt64(variants);
        }
    }
}
