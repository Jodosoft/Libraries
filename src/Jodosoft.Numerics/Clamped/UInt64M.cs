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
    /// Represents a 64-bit unsigned integer that cannot overflow.
    /// </summary>
    [Serializable]
    [DebuggerDisplay("{ToString(),nq}")]
    public readonly struct UInt64M : INumericExtended<UInt64M>
    {
        public static readonly UInt64M MaxValue = new UInt64M(ulong.MaxValue);
        public static readonly UInt64M MinValue = new UInt64M(ulong.MinValue);

        private readonly ulong _value;

        private UInt64M(ulong value)
        {
            _value = value;
        }

        private UInt64M(SerializationInfo info, StreamingContext context) : this(info.GetUInt64(nameof(UInt64M))) { }
        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context) => info.AddValue(nameof(UInt64M), _value);

        public int CompareTo(object? obj) => obj is UInt64M other ? CompareTo(other) : 1;
        public int CompareTo(UInt64M other) => _value.CompareTo(other._value);
        public bool Equals(UInt64M other) => _value == other._value;
        public override bool Equals(object? obj) => obj is UInt64M other && Equals(other);
        public override int GetHashCode() => _value.GetHashCode();
        public override string ToString() => _value.ToString();
        public string ToString(IFormatProvider formatProvider) => _value.ToString(formatProvider);
        public string ToString(string format) => _value.ToString(format);
        public string ToString(string? format, IFormatProvider? formatProvider) => _value.ToString(format, formatProvider);

        public static bool TryParse(string s, IFormatProvider? provider, out UInt64M result) => FuncExtensions.Try(() => Parse(s, provider), out result);
        public static bool TryParse(string s, NumberStyles style, IFormatProvider? provider, out UInt64M result) => FuncExtensions.Try(() => Parse(s, style, provider), out result);
        public static bool TryParse(string s, NumberStyles style, out UInt64M result) => FuncExtensions.Try(() => Parse(s, style), out result);
        public static bool TryParse(string s, out UInt64M result) => FuncExtensions.Try(() => Parse(s), out result);
        public static UInt64M Parse(string s) => ulong.Parse(s);
        public static UInt64M Parse(string s, IFormatProvider? provider) => ulong.Parse(s, provider);
        public static UInt64M Parse(string s, NumberStyles style) => ulong.Parse(s, style);
        public static UInt64M Parse(string s, NumberStyles style, IFormatProvider? provider) => ulong.Parse(s, style, provider);

        [CLSCompliant(false)] public static explicit operator UInt64M(sbyte value) => new UInt64M(ConvertN.ToUInt64(value, Conversion.CastClamp));
        [CLSCompliant(false)] public static implicit operator UInt64M(uint value) => new UInt64M(value);
        [CLSCompliant(false)] public static implicit operator UInt64M(ulong value) => new UInt64M(value);
        [CLSCompliant(false)] public static implicit operator UInt64M(ushort value) => new UInt64M(value);
        public static explicit operator UInt64M(decimal value) => new UInt64M(ConvertN.ToUInt64(value, Conversion.CastClamp));
        public static explicit operator UInt64M(double value) => new UInt64M(ConvertN.ToUInt64(value, Conversion.CastClamp));
        public static explicit operator UInt64M(float value) => new UInt64M(ConvertN.ToUInt64(value, Conversion.CastClamp));
        public static explicit operator UInt64M(int value) => new UInt64M(ConvertN.ToUInt64(value, Conversion.CastClamp));
        public static explicit operator UInt64M(long value) => new UInt64M(ConvertN.ToUInt64(value, Conversion.CastClamp));
        public static explicit operator UInt64M(short value) => new UInt64M(ConvertN.ToUInt64(value, Conversion.CastClamp));
        public static implicit operator UInt64M(byte value) => new UInt64M(value);

        [CLSCompliant(false)] public static explicit operator sbyte(UInt64M value) => ConvertN.ToSByte(value._value, Conversion.CastClamp);
        [CLSCompliant(false)] public static explicit operator uint(UInt64M value) => ConvertN.ToUInt32(value._value, Conversion.CastClamp);
        [CLSCompliant(false)] public static explicit operator ushort(UInt64M value) => ConvertN.ToUInt16(value._value, Conversion.CastClamp);
        [CLSCompliant(false)] public static implicit operator ulong(UInt64M value) => value._value;
        public static explicit operator byte(UInt64M value) => ConvertN.ToByte(value._value, Conversion.CastClamp);
        public static explicit operator int(UInt64M value) => ConvertN.ToInt32(value._value, Conversion.CastClamp);
        public static explicit operator long(UInt64M value) => ConvertN.ToInt64(value._value, Conversion.CastClamp);
        public static explicit operator short(UInt64M value) => ConvertN.ToInt16(value._value, Conversion.CastClamp);
        public static implicit operator decimal(UInt64M value) => value._value;
        public static implicit operator double(UInt64M value) => value._value;
        public static implicit operator float(UInt64M value) => value._value;

        public static bool operator !=(UInt64M left, UInt64M right) => left._value != right._value;
        public static bool operator <(UInt64M left, UInt64M right) => left._value < right._value;
        public static bool operator <=(UInt64M left, UInt64M right) => left._value <= right._value;
        public static bool operator ==(UInt64M left, UInt64M right) => left._value == right._value;
        public static bool operator >(UInt64M left, UInt64M right) => left._value > right._value;
        public static bool operator >=(UInt64M left, UInt64M right) => left._value >= right._value;
        public static UInt64M operator %(UInt64M left, UInt64M right) => Clamped.Remainder(left._value, right._value);
        public static UInt64M operator &(UInt64M left, UInt64M right) => left._value & right._value;
        public static UInt64M operator -(UInt64M _) => MinValue;
        public static UInt64M operator -(UInt64M left, UInt64M right) => Clamped.Subtract(left._value, right._value);
        public static UInt64M operator --(UInt64M value) => value - 1;
        public static UInt64M operator *(UInt64M left, UInt64M right) => Clamped.Multiply(left._value, right._value);
        public static UInt64M operator /(UInt64M left, UInt64M right) => Clamped.Divide(left._value, right._value);
        public static UInt64M operator ^(UInt64M left, UInt64M right) => left._value ^ right._value;
        public static UInt64M operator |(UInt64M left, UInt64M right) => left._value | right._value;
        public static UInt64M operator ~(UInt64M value) => ~value._value;
        public static UInt64M operator +(UInt64M left, UInt64M right) => Clamped.Add(left._value, right._value);
        public static UInt64M operator +(UInt64M value) => value;
        public static UInt64M operator ++(UInt64M value) => value + 1;
        public static UInt64M operator <<(UInt64M left, int right) => left._value << right;
        public static UInt64M operator >>(UInt64M left, int right) => left._value >> right;

        TypeCode IConvertible.GetTypeCode() => _value.GetTypeCode();
        bool IConvertible.ToBoolean(IFormatProvider provider) => Convert.ToBoolean(_value, provider);
        byte IConvertible.ToByte(IFormatProvider provider) => ConvertN.ToByte(_value, Conversion.Clamp);
        char IConvertible.ToChar(IFormatProvider provider) => Convert.ToChar(_value, provider);
        DateTime IConvertible.ToDateTime(IFormatProvider provider) => Convert.ToDateTime(provider);
        decimal IConvertible.ToDecimal(IFormatProvider provider) => ConvertN.ToDecimal(_value, Conversion.Clamp);
        double IConvertible.ToDouble(IFormatProvider provider) => ConvertN.ToDouble(_value, Conversion.Clamp);
        float IConvertible.ToSingle(IFormatProvider provider) => ConvertN.ToSingle(_value, Conversion.Clamp);
        int IConvertible.ToInt32(IFormatProvider provider) => ConvertN.ToInt32(_value, Conversion.Clamp);
        long IConvertible.ToInt64(IFormatProvider provider) => ConvertN.ToInt64(_value, Conversion.Clamp);
        sbyte IConvertible.ToSByte(IFormatProvider provider) => ConvertN.ToSByte(_value, Conversion.Clamp);
        short IConvertible.ToInt16(IFormatProvider provider) => ConvertN.ToInt16(_value, Conversion.Clamp);
        uint IConvertible.ToUInt32(IFormatProvider provider) => ConvertN.ToUInt32(_value, Conversion.Clamp);
        ulong IConvertible.ToUInt64(IFormatProvider provider) => _value;
        ushort IConvertible.ToUInt16(IFormatProvider provider) => ConvertN.ToUInt16(_value, Conversion.Clamp);
        object IConvertible.ToType(Type conversionType, IFormatProvider provider) => this.ToTypeDefault(conversionType, provider);

        bool INumeric<UInt64M>.IsGreaterThan(UInt64M value) => this > value;
        bool INumeric<UInt64M>.IsGreaterThanOrEqualTo(UInt64M value) => this >= value;
        bool INumeric<UInt64M>.IsLessThan(UInt64M value) => this < value;
        bool INumeric<UInt64M>.IsLessThanOrEqualTo(UInt64M value) => this <= value;
        UInt64M INumeric<UInt64M>.Add(UInt64M value) => this + value;
        UInt64M INumeric<UInt64M>.BitwiseComplement() => ~this;
        UInt64M INumeric<UInt64M>.Divide(UInt64M value) => this / value;
        UInt64M INumeric<UInt64M>.LeftShift(int count) => this << count;
        UInt64M INumeric<UInt64M>.LogicalAnd(UInt64M value) => this & value;
        UInt64M INumeric<UInt64M>.LogicalExclusiveOr(UInt64M value) => this ^ value;
        UInt64M INumeric<UInt64M>.LogicalOr(UInt64M value) => this | value;
        UInt64M INumeric<UInt64M>.Multiply(UInt64M value) => this * value;
        UInt64M INumeric<UInt64M>.Negative() => -this;
        UInt64M INumeric<UInt64M>.Positive() => +this;
        UInt64M INumeric<UInt64M>.Remainder(UInt64M value) => this % value;
        UInt64M INumeric<UInt64M>.RightShift(int count) => this >> count;
        UInt64M INumeric<UInt64M>.Subtract(UInt64M value) => this - value;

        INumericBitConverter<UInt64M> IProvider<INumericBitConverter<UInt64M>>.GetInstance() => Utilities.Instance;
        IBinaryIO<UInt64M> IProvider<IBinaryIO<UInt64M>>.GetInstance() => Utilities.Instance;
        IConvert<UInt64M> IProvider<IConvert<UInt64M>>.GetInstance() => Utilities.Instance;
        IConvertExtended<UInt64M> IProvider<IConvertExtended<UInt64M>>.GetInstance() => Utilities.Instance;
        IMath<UInt64M> IProvider<IMath<UInt64M>>.GetInstance() => Utilities.Instance;
        INumericRandom<UInt64M> IProvider<INumericRandom<UInt64M>>.GetInstance() => Utilities.Instance;
        INumericStatic<UInt64M> IProvider<INumericStatic<UInt64M>>.GetInstance() => Utilities.Instance;
        IVariantRandom<UInt64M> IProvider<IVariantRandom<UInt64M>>.GetInstance() => Utilities.Instance;

        private sealed class Utilities :
            IBinaryIO<UInt64M>,
            IConvert<UInt64M>,
            IConvertExtended<UInt64M>,
            IMath<UInt64M>,
            INumericBitConverter<UInt64M>,
            INumericRandom<UInt64M>,
            INumericStatic<UInt64M>,
            IVariantRandom<UInt64M>
        {
            public static readonly Utilities Instance = new Utilities();

            void IBinaryIO<UInt64M>.Write(BinaryWriter writer, UInt64M value) => writer.Write(value);
            UInt64M IBinaryIO<UInt64M>.Read(BinaryReader reader) => reader.ReadUInt64();

            bool INumericStatic<UInt64M>.HasFloatingPoint => false;
            bool INumericStatic<UInt64M>.HasInfinity => false;
            bool INumericStatic<UInt64M>.HasNaN => false;
            bool INumericStatic<UInt64M>.IsFinite(UInt64M x) => true;
            bool INumericStatic<UInt64M>.IsInfinity(UInt64M x) => false;
            bool INumericStatic<UInt64M>.IsNaN(UInt64M x) => false;
            bool INumericStatic<UInt64M>.IsNegative(UInt64M x) => false;
            bool INumericStatic<UInt64M>.IsNegativeInfinity(UInt64M x) => false;
            bool INumericStatic<UInt64M>.IsNormal(UInt64M x) => false;
            bool INumericStatic<UInt64M>.IsPositiveInfinity(UInt64M x) => false;
            bool INumericStatic<UInt64M>.IsReal => false;
            bool INumericStatic<UInt64M>.IsSigned => false;
            bool INumericStatic<UInt64M>.IsSubnormal(UInt64M x) => false;
            UInt64M INumericStatic<UInt64M>.Epsilon => 1;
            UInt64M INumericStatic<UInt64M>.MaxUnit => 1;
            UInt64M INumericStatic<UInt64M>.MaxValue => MaxValue;
            UInt64M INumericStatic<UInt64M>.MinUnit => 0;
            UInt64M INumericStatic<UInt64M>.MinValue => MinValue;
            UInt64M INumericStatic<UInt64M>.One => 1;
            UInt64M INumericStatic<UInt64M>.Zero => 0;

            int IMath<UInt64M>.Sign(UInt64M x) => x._value == 0 ? 0 : 1;
            UInt64M IMath<UInt64M>.Abs(UInt64M value) => value;
            UInt64M IMath<UInt64M>.Acos(UInt64M x) => (UInt64M)Math.Acos(x._value);
            UInt64M IMath<UInt64M>.Acosh(UInt64M x) => (UInt64M)MathShim.Acosh(x._value);
            UInt64M IMath<UInt64M>.Asin(UInt64M x) => (UInt64M)Math.Asin(x._value);
            UInt64M IMath<UInt64M>.Asinh(UInt64M x) => (UInt64M)MathShim.Asinh(x._value);
            UInt64M IMath<UInt64M>.Atan(UInt64M x) => (UInt64M)Math.Atan(x._value);
            UInt64M IMath<UInt64M>.Atan2(UInt64M x, UInt64M y) => (UInt64M)Math.Atan2(x._value, y._value);
            UInt64M IMath<UInt64M>.Atanh(UInt64M x) => (UInt64M)MathShim.Atanh(x._value);
            UInt64M IMath<UInt64M>.Cbrt(UInt64M x) => (UInt64M)MathShim.Cbrt(x._value);
            UInt64M IMath<UInt64M>.Ceiling(UInt64M x) => x;
            UInt64M IMath<UInt64M>.Clamp(UInt64M x, UInt64M bound1, UInt64M bound2) => bound1 > bound2 ? Math.Min(bound1._value, Math.Max(bound2._value, x._value)) : Math.Min(bound2._value, Math.Max(bound1._value, x._value));
            UInt64M IMath<UInt64M>.Cos(UInt64M x) => (UInt64M)Math.Cos(x._value);
            UInt64M IMath<UInt64M>.Cosh(UInt64M x) => (UInt64M)Math.Cosh(x._value);
            UInt64M IMath<UInt64M>.E { get; } = 2;
            UInt64M IMath<UInt64M>.Exp(UInt64M x) => (UInt64M)Math.Exp(x._value);
            UInt64M IMath<UInt64M>.Floor(UInt64M x) => x;
            UInt64M IMath<UInt64M>.IEEERemainder(UInt64M x, UInt64M y) => (UInt64M)Math.IEEERemainder(x._value, y._value);
            UInt64M IMath<UInt64M>.Log(UInt64M x) => (UInt64M)Math.Log(x._value);
            UInt64M IMath<UInt64M>.Log(UInt64M x, UInt64M y) => (UInt64M)Math.Log(x._value, y._value);
            UInt64M IMath<UInt64M>.Log10(UInt64M x) => (UInt64M)Math.Log10(x._value);
            UInt64M IMath<UInt64M>.Max(UInt64M x, UInt64M y) => Math.Max(x._value, y._value);
            UInt64M IMath<UInt64M>.Min(UInt64M x, UInt64M y) => Math.Min(x._value, y._value);
            UInt64M IMath<UInt64M>.PI { get; } = 3;
            UInt64M IMath<UInt64M>.Pow(UInt64M x, UInt64M y) => Clamped.Pow(x._value, y._value);
            UInt64M IMath<UInt64M>.Round(UInt64M x) => x;
            UInt64M IMath<UInt64M>.Round(UInt64M x, int digits) => x;
            UInt64M IMath<UInt64M>.Round(UInt64M x, int digits, MidpointRounding mode) => x;
            UInt64M IMath<UInt64M>.Round(UInt64M x, MidpointRounding mode) => x;
            UInt64M IMath<UInt64M>.Sin(UInt64M x) => (UInt64M)Math.Sin(x._value);
            UInt64M IMath<UInt64M>.Sinh(UInt64M x) => (UInt64M)Math.Sinh(x._value);
            UInt64M IMath<UInt64M>.Sqrt(UInt64M x) => (UInt64M)Math.Sqrt(x._value);
            UInt64M IMath<UInt64M>.Tan(UInt64M x) => (UInt64M)Math.Tan(x._value);
            UInt64M IMath<UInt64M>.Tanh(UInt64M x) => (UInt64M)Math.Tanh(x._value);
            UInt64M IMath<UInt64M>.Tau { get; } = 6;
            UInt64M IMath<UInt64M>.Truncate(UInt64M x) => x;

            int INumericBitConverter<UInt64M>.ConvertedSize => sizeof(ulong);
            UInt64M INumericBitConverter<UInt64M>.ToNumeric(byte[] value, int startIndex) => BitConverter.ToUInt64(value, startIndex);
            byte[] INumericBitConverter<UInt64M>.GetBytes(UInt64M value) => BitConverter.GetBytes(value._value);
#if HAS_SPANS
            UInt64M INumericBitConverter<UInt64M>.ToNumeric(ReadOnlySpan<byte> value) => BitConverter.ToUInt64(value);
            bool INumericBitConverter<UInt64M>.TryWriteBytes(Span<byte> destination, UInt64M value) => BitConverter.TryWriteBytes(destination, value);
#endif

            bool IConvert<UInt64M>.ToBoolean(UInt64M value) => value._value != 0;
            byte IConvert<UInt64M>.ToByte(UInt64M value, Conversion mode) => ConvertN.ToByte(value._value, mode.Clamped());
            decimal IConvert<UInt64M>.ToDecimal(UInt64M value, Conversion mode) => ConvertN.ToDecimal(value._value, mode.Clamped());
            double IConvert<UInt64M>.ToDouble(UInt64M value, Conversion mode) => ConvertN.ToDouble(value._value, mode.Clamped());
            float IConvert<UInt64M>.ToSingle(UInt64M value, Conversion mode) => ConvertN.ToSingle(value._value, mode.Clamped());
            int IConvert<UInt64M>.ToInt32(UInt64M value, Conversion mode) => ConvertN.ToInt32(value._value, mode.Clamped());
            long IConvert<UInt64M>.ToInt64(UInt64M value, Conversion mode) => ConvertN.ToInt64(value._value, mode.Clamped());
            sbyte IConvertExtended<UInt64M>.ToSByte(UInt64M value, Conversion mode) => ConvertN.ToSByte(value._value, mode.Clamped());
            short IConvert<UInt64M>.ToInt16(UInt64M value, Conversion mode) => ConvertN.ToInt16(value._value, mode.Clamped());
            string IConvert<UInt64M>.ToString(UInt64M value) => Convert.ToString(value._value);
            uint IConvertExtended<UInt64M>.ToUInt32(UInt64M value, Conversion mode) => ConvertN.ToUInt32(value._value, mode.Clamped());
            ulong IConvertExtended<UInt64M>.ToUInt64(UInt64M value, Conversion mode) => value._value;
            ushort IConvertExtended<UInt64M>.ToUInt16(UInt64M value, Conversion mode) => ConvertN.ToUInt16(value._value, mode.Clamped());

            UInt64M IConvert<UInt64M>.ToNumeric(bool value) => value ? 1 : (ulong)0;
            UInt64M IConvert<UInt64M>.ToNumeric(byte value, Conversion mode) => ConvertN.ToUInt64(value, mode.Clamped());
            UInt64M IConvert<UInt64M>.ToNumeric(decimal value, Conversion mode) => ConvertN.ToUInt64(value, mode.Clamped());
            UInt64M IConvert<UInt64M>.ToNumeric(double value, Conversion mode) => ConvertN.ToUInt64(value, mode.Clamped());
            UInt64M IConvert<UInt64M>.ToNumeric(float value, Conversion mode) => ConvertN.ToUInt64(value, mode.Clamped());
            UInt64M IConvert<UInt64M>.ToNumeric(int value, Conversion mode) => ConvertN.ToUInt64(value, mode.Clamped());
            UInt64M IConvert<UInt64M>.ToNumeric(long value, Conversion mode) => ConvertN.ToUInt64(value, mode.Clamped());
            UInt64M IConvertExtended<UInt64M>.ToValue(sbyte value, Conversion mode) => ConvertN.ToUInt64(value, mode.Clamped());
            UInt64M IConvert<UInt64M>.ToNumeric(short value, Conversion mode) => ConvertN.ToUInt64(value, mode.Clamped());
            UInt64M IConvert<UInt64M>.ToNumeric(string value) => Convert.ToUInt64(value);
            UInt64M IConvertExtended<UInt64M>.ToNumeric(uint value, Conversion mode) => ConvertN.ToUInt64(value, mode.Clamped());
            UInt64M IConvertExtended<UInt64M>.ToNumeric(ulong value, Conversion mode) => value;
            UInt64M IConvertExtended<UInt64M>.ToNumeric(ushort value, Conversion mode) => ConvertN.ToUInt64(value, mode.Clamped());

            UInt64M INumericStatic<UInt64M>.Parse(string s, NumberStyles? style, IFormatProvider? provider)
                => Parse(s, style ?? NumberStyles.Integer, provider);

            UInt64M INumericRandom<UInt64M>.Generate(Random random) => random.NextUInt64();
            UInt64M INumericRandom<UInt64M>.Generate(Random random, UInt64M maxValue) => random.NextUInt64(maxValue);
            UInt64M INumericRandom<UInt64M>.Generate(Random random, UInt64M minValue, UInt64M maxValue) => random.NextUInt64(minValue, maxValue);
            UInt64M INumericRandom<UInt64M>.Generate(Random random, Generation mode) => random.NextUInt64(mode);
            UInt64M INumericRandom<UInt64M>.Generate(Random random, UInt64M minValue, UInt64M maxValue, Generation mode) => random.NextUInt64(minValue, maxValue, mode);

            UInt64M IVariantRandom<UInt64M>.Generate(Random random, Variants variants) => random.NextUInt64(variants);
        }
    }
}
