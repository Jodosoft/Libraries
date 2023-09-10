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

namespace Jodosoft.Numerics
{
    /// <summary>
    /// Represents a 64-bit signed integer that cannot overflow.
    /// </summary>
    [Serializable]
    [DebuggerDisplay("{ToString(),nq}")]
    public readonly struct ClampedInt16 : INumericExtended<ClampedInt16>
    {
        public static readonly ClampedInt16 MaxValue = new ClampedInt16(short.MaxValue);
        public static readonly ClampedInt16 MinValue = new ClampedInt16(short.MinValue);

        private readonly short _value;

        private ClampedInt16(short value)
        {
            _value = value;
        }

        private ClampedInt16(SerializationInfo info, StreamingContext context) : this(info.GetInt16(nameof(ClampedInt16))) { }
        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context) => info.AddValue(nameof(ClampedInt16), _value);

        public int CompareTo(ClampedInt16 other) => _value.CompareTo(other._value);
        public int CompareTo(object? obj) => obj is ClampedInt16 other ? CompareTo(other) : 1;
        public bool Equals(ClampedInt16 other) => _value == other._value;
        public override bool Equals(object? obj) => obj is ClampedInt16 other && Equals(other);
        public override int GetHashCode() => _value.GetHashCode();
        public override string ToString() => _value.ToString();
        public string ToString(IFormatProvider? provider) => _value.ToString(provider);
        public string ToString(string format) => _value.ToString(format);
        public string ToString(string? format, IFormatProvider? formatProvider) => _value.ToString(format, formatProvider);

        public static bool TryParse(string s, IFormatProvider? provider, out ClampedInt16 result) => FuncExtensions.Try(() => Parse(s, provider), out result);
        public static bool TryParse(string s, NumberStyles style, IFormatProvider? provider, out ClampedInt16 result) => FuncExtensions.Try(() => Parse(s, style, provider), out result);
        public static bool TryParse(string s, NumberStyles style, out ClampedInt16 result) => FuncExtensions.Try(() => Parse(s, style), out result);
        public static bool TryParse(string s, out ClampedInt16 result) => FuncExtensions.Try(() => Parse(s), out result);
        public static ClampedInt16 Parse(string s) => short.Parse(s);
        public static ClampedInt16 Parse(string s, IFormatProvider? provider) => short.Parse(s, provider);
        public static ClampedInt16 Parse(string s, NumberStyles style) => short.Parse(s, style);
        public static ClampedInt16 Parse(string s, NumberStyles style, IFormatProvider? provider) => short.Parse(s, style, provider);

        [CLSCompliant(false)] public static explicit operator ClampedInt16(uint value) => new ClampedInt16(ConvertN.ToInt16(value, Conversion.CastClamp));
        [CLSCompliant(false)] public static explicit operator ClampedInt16(ulong value) => new ClampedInt16(ConvertN.ToInt16(value, Conversion.CastClamp));
        [CLSCompliant(false)] public static explicit operator ClampedInt16(ushort value) => new ClampedInt16(ConvertN.ToInt16(value, Conversion.CastClamp));
        [CLSCompliant(false)] public static implicit operator ClampedInt16(sbyte value) => new ClampedInt16(value);
        public static explicit operator ClampedInt16(decimal value) => new ClampedInt16(ConvertN.ToInt16(value, Conversion.CastClamp));
        public static explicit operator ClampedInt16(double value) => new ClampedInt16(ConvertN.ToInt16(value, Conversion.CastClamp));
        public static explicit operator ClampedInt16(float value) => new ClampedInt16(ConvertN.ToInt16(value, Conversion.CastClamp));
        public static explicit operator ClampedInt16(int value) => new ClampedInt16(ConvertN.ToInt16(value, Conversion.CastClamp));
        public static explicit operator ClampedInt16(long value) => new ClampedInt16(ConvertN.ToInt16(value, Conversion.CastClamp));
        public static implicit operator ClampedInt16(byte value) => new ClampedInt16(value);
        public static implicit operator ClampedInt16(short value) => new ClampedInt16(value);

        [CLSCompliant(false)] public static explicit operator sbyte(ClampedInt16 value) => ConvertN.ToSByte(value._value, Conversion.CastClamp);
        [CLSCompliant(false)] public static explicit operator uint(ClampedInt16 value) => ConvertN.ToUInt16(value._value, Conversion.CastClamp);
        [CLSCompliant(false)] public static explicit operator ulong(ClampedInt16 value) => ConvertN.ToUInt64(value._value, Conversion.CastClamp);
        [CLSCompliant(false)] public static explicit operator ushort(ClampedInt16 value) => ConvertN.ToUInt16(value._value, Conversion.CastClamp);
        public static explicit operator byte(ClampedInt16 value) => ConvertN.ToByte(value._value, Conversion.CastClamp);
        public static implicit operator decimal(ClampedInt16 value) => value._value;
        public static implicit operator double(ClampedInt16 value) => value._value;
        public static implicit operator float(ClampedInt16 value) => value._value;
        public static implicit operator int(ClampedInt16 value) => value._value;
        public static implicit operator long(ClampedInt16 value) => value._value;
        public static implicit operator short(ClampedInt16 value) => value._value;

        public static bool operator !=(ClampedInt16 left, ClampedInt16 right) => left._value != right._value;
        public static bool operator <(ClampedInt16 left, ClampedInt16 right) => left._value < right._value;
        public static bool operator <=(ClampedInt16 left, ClampedInt16 right) => left._value <= right._value;
        public static bool operator ==(ClampedInt16 left, ClampedInt16 right) => left._value == right._value;
        public static bool operator >(ClampedInt16 left, ClampedInt16 right) => left._value > right._value;
        public static bool operator >=(ClampedInt16 left, ClampedInt16 right) => left._value >= right._value;
        public static ClampedInt16 operator %(ClampedInt16 left, ClampedInt16 right) => ClampedArithmetic.Remainder(left._value, right._value);
        public static ClampedInt16 operator &(ClampedInt16 left, ClampedInt16 right) => (short)(left._value & right._value);
        public static ClampedInt16 operator -(ClampedInt16 left, ClampedInt16 right) => ClampedArithmetic.Subtract(left._value, right._value);
        public static ClampedInt16 operator --(ClampedInt16 value) => ClampedArithmetic.Subtract(value._value, (short)1);
        public static ClampedInt16 operator -(ClampedInt16 value) => (short)-value._value;
        public static ClampedInt16 operator *(ClampedInt16 left, ClampedInt16 right) => ClampedArithmetic.Multiply(left._value, right._value);
        public static ClampedInt16 operator /(ClampedInt16 left, ClampedInt16 right) => ClampedArithmetic.Divide(left._value, right._value);
        public static ClampedInt16 operator ^(ClampedInt16 left, ClampedInt16 right) => (short)(left._value ^ right._value);
        public static ClampedInt16 operator |(ClampedInt16 left, ClampedInt16 right) => (short)(left._value | right._value);
        public static ClampedInt16 operator ~(ClampedInt16 value) => (short)~value._value;
        public static ClampedInt16 operator +(ClampedInt16 left, ClampedInt16 right) => ClampedArithmetic.Add(left._value, right._value);
        public static ClampedInt16 operator +(ClampedInt16 value) => value;
        public static ClampedInt16 operator ++(ClampedInt16 value) => ClampedArithmetic.Add(value._value, (short)1);
        public static ClampedInt16 operator <<(ClampedInt16 left, int right) => (short)(left._value << right);
        public static ClampedInt16 operator >>(ClampedInt16 left, int right) => (short)(left._value >> right);

        TypeCode IConvertible.GetTypeCode() => _value.GetTypeCode();
        bool IConvertible.ToBoolean(IFormatProvider? provider) => Convert.ToBoolean(_value, provider);
        byte IConvertible.ToByte(IFormatProvider? provider) => ConvertN.ToByte(_value, Conversion.Clamp);
        char IConvertible.ToChar(IFormatProvider? provider) => Convert.ToChar(_value, provider);
        DateTime IConvertible.ToDateTime(IFormatProvider? provider) => Convert.ToDateTime(provider);
        decimal IConvertible.ToDecimal(IFormatProvider? provider) => ConvertN.ToDecimal(_value, Conversion.Clamp);
        double IConvertible.ToDouble(IFormatProvider? provider) => ConvertN.ToDouble(_value, Conversion.Clamp);
        float IConvertible.ToSingle(IFormatProvider? provider) => ConvertN.ToSingle(_value, Conversion.Clamp);
        int IConvertible.ToInt32(IFormatProvider? provider) => ConvertN.ToInt32(_value, Conversion.Clamp);
        long IConvertible.ToInt64(IFormatProvider? provider) => ConvertN.ToInt64(_value, Conversion.Clamp);
        sbyte IConvertible.ToSByte(IFormatProvider? provider) => ConvertN.ToSByte(_value, Conversion.Clamp);
        short IConvertible.ToInt16(IFormatProvider? provider) => _value;
        uint IConvertible.ToUInt32(IFormatProvider? provider) => ConvertN.ToUInt32(_value, Conversion.Clamp);
        ulong IConvertible.ToUInt64(IFormatProvider? provider) => ConvertN.ToUInt64(_value, Conversion.Clamp);
        ushort IConvertible.ToUInt16(IFormatProvider? provider) => ConvertN.ToUInt16(_value, Conversion.Clamp);
        object IConvertible.ToType(Type conversionType, IFormatProvider? provider) => this.ToTypeDefault(conversionType, provider);

        bool INumeric<ClampedInt16>.IsGreaterThan(ClampedInt16 value) => this > value;
        bool INumeric<ClampedInt16>.IsGreaterThanOrEqualTo(ClampedInt16 value) => this >= value;
        bool INumeric<ClampedInt16>.IsLessThan(ClampedInt16 value) => this < value;
        bool INumeric<ClampedInt16>.IsLessThanOrEqualTo(ClampedInt16 value) => this <= value;
        ClampedInt16 INumeric<ClampedInt16>.Add(ClampedInt16 value) => this + value;
        ClampedInt16 INumeric<ClampedInt16>.BitwiseComplement() => ~this;
        ClampedInt16 INumeric<ClampedInt16>.Divide(ClampedInt16 value) => this / value;
        ClampedInt16 INumeric<ClampedInt16>.LeftShift(int count) => this << count;
        ClampedInt16 INumeric<ClampedInt16>.LogicalAnd(ClampedInt16 value) => this & value;
        ClampedInt16 INumeric<ClampedInt16>.LogicalExclusiveOr(ClampedInt16 value) => this ^ value;
        ClampedInt16 INumeric<ClampedInt16>.LogicalOr(ClampedInt16 value) => this | value;
        ClampedInt16 INumeric<ClampedInt16>.Multiply(ClampedInt16 value) => this * value;
        ClampedInt16 INumeric<ClampedInt16>.Negative() => -this;
        ClampedInt16 INumeric<ClampedInt16>.Positive() => +this;
        ClampedInt16 INumeric<ClampedInt16>.Remainder(ClampedInt16 value) => this % value;
        ClampedInt16 INumeric<ClampedInt16>.RightShift(int count) => this >> count;
        ClampedInt16 INumeric<ClampedInt16>.Subtract(ClampedInt16 value) => this - value;

        INumericBitConverter<ClampedInt16> IProvider<INumericBitConverter<ClampedInt16>>.GetInstance() => Utilities.Instance;
        IBinaryIO<ClampedInt16> IProvider<IBinaryIO<ClampedInt16>>.GetInstance() => Utilities.Instance;
        IConvert<ClampedInt16> IProvider<IConvert<ClampedInt16>>.GetInstance() => Utilities.Instance;
        IConvertExtended<ClampedInt16> IProvider<IConvertExtended<ClampedInt16>>.GetInstance() => Utilities.Instance;
        IMath<ClampedInt16> IProvider<IMath<ClampedInt16>>.GetInstance() => Utilities.Instance;
        INumericRandom<ClampedInt16> IProvider<INumericRandom<ClampedInt16>>.GetInstance() => Utilities.Instance;
        INumericStatic<ClampedInt16> IProvider<INumericStatic<ClampedInt16>>.GetInstance() => Utilities.Instance;
        IVariantRandom<ClampedInt16> IProvider<IVariantRandom<ClampedInt16>>.GetInstance() => Utilities.Instance;

        private sealed class Utilities :
            IBinaryIO<ClampedInt16>,
            IConvert<ClampedInt16>,
            IConvertExtended<ClampedInt16>,
            IMath<ClampedInt16>,
            INumericBitConverter<ClampedInt16>,
            INumericRandom<ClampedInt16>,
            INumericStatic<ClampedInt16>,
            IVariantRandom<ClampedInt16>
        {
            public static readonly Utilities Instance = new Utilities();

            void IBinaryIO<ClampedInt16>.Write(BinaryWriter writer, ClampedInt16 value) => writer.Write(value);
            ClampedInt16 IBinaryIO<ClampedInt16>.Read(BinaryReader reader) => reader.ReadInt16();

            bool INumericStatic<ClampedInt16>.HasFloatingPoint => false;
            bool INumericStatic<ClampedInt16>.HasInfinity => false;
            bool INumericStatic<ClampedInt16>.HasNaN => false;
            bool INumericStatic<ClampedInt16>.IsFinite(ClampedInt16 x) => true;
            bool INumericStatic<ClampedInt16>.IsInfinity(ClampedInt16 x) => false;
            bool INumericStatic<ClampedInt16>.IsNaN(ClampedInt16 x) => false;
            bool INumericStatic<ClampedInt16>.IsNegative(ClampedInt16 x) => x._value < 0;
            bool INumericStatic<ClampedInt16>.IsNegativeInfinity(ClampedInt16 x) => false;
            bool INumericStatic<ClampedInt16>.IsNormal(ClampedInt16 x) => false;
            bool INumericStatic<ClampedInt16>.IsPositiveInfinity(ClampedInt16 x) => false;
            bool INumericStatic<ClampedInt16>.IsReal => false;
            bool INumericStatic<ClampedInt16>.IsSigned => true;
            bool INumericStatic<ClampedInt16>.IsSubnormal(ClampedInt16 x) => false;
            ClampedInt16 INumericStatic<ClampedInt16>.Epsilon => (short)1;
            ClampedInt16 INumericStatic<ClampedInt16>.MaxUnit => (short)1;
            ClampedInt16 INumericStatic<ClampedInt16>.MaxValue => MaxValue;
            ClampedInt16 INumericStatic<ClampedInt16>.MinUnit => (short)-1;
            ClampedInt16 INumericStatic<ClampedInt16>.MinValue => MinValue;
            ClampedInt16 INumericStatic<ClampedInt16>.One => (short)1;
            ClampedInt16 INumericStatic<ClampedInt16>.Zero => (short)0;

            ClampedInt16 IMath<ClampedInt16>.Abs(ClampedInt16 value) => Math.Abs(value._value);
            ClampedInt16 IMath<ClampedInt16>.Acos(ClampedInt16 x) => (ClampedInt16)Math.Acos(x._value);
            ClampedInt16 IMath<ClampedInt16>.Acosh(ClampedInt16 x) => (ClampedInt16)MathShim.Acosh(x._value);
            ClampedInt16 IMath<ClampedInt16>.Asin(ClampedInt16 x) => (ClampedInt16)Math.Asin(x._value);
            ClampedInt16 IMath<ClampedInt16>.Asinh(ClampedInt16 x) => (ClampedInt16)MathShim.Asinh(x._value);
            ClampedInt16 IMath<ClampedInt16>.Atan(ClampedInt16 x) => (ClampedInt16)Math.Atan(x._value);
            ClampedInt16 IMath<ClampedInt16>.Atan2(ClampedInt16 x, ClampedInt16 y) => (ClampedInt16)Math.Atan2(x._value, y._value);
            ClampedInt16 IMath<ClampedInt16>.Atanh(ClampedInt16 x) => (ClampedInt16)MathShim.Atanh(x._value);
            ClampedInt16 IMath<ClampedInt16>.Cbrt(ClampedInt16 x) => (ClampedInt16)MathShim.Cbrt(x._value);
            ClampedInt16 IMath<ClampedInt16>.Ceiling(ClampedInt16 x) => x;
            ClampedInt16 IMath<ClampedInt16>.Clamp(ClampedInt16 x, ClampedInt16 bound1, ClampedInt16 bound2) => bound1 > bound2 ? Math.Min(bound1._value, Math.Max(bound2._value, x._value)) : Math.Min(bound2._value, Math.Max(bound1._value, x._value));
            ClampedInt16 IMath<ClampedInt16>.Cos(ClampedInt16 x) => (ClampedInt16)Math.Cos(x._value);
            ClampedInt16 IMath<ClampedInt16>.Cosh(ClampedInt16 x) => (ClampedInt16)Math.Cosh(x._value);
            ClampedInt16 IMath<ClampedInt16>.E { get; } = (short)2;
            ClampedInt16 IMath<ClampedInt16>.Exp(ClampedInt16 x) => (ClampedInt16)Math.Exp(x._value);
            ClampedInt16 IMath<ClampedInt16>.Floor(ClampedInt16 x) => x;
            ClampedInt16 IMath<ClampedInt16>.IEEERemainder(ClampedInt16 x, ClampedInt16 y) => (ClampedInt16)Math.IEEERemainder(x._value, y._value);
            ClampedInt16 IMath<ClampedInt16>.Log(ClampedInt16 x) => (ClampedInt16)Math.Log(x._value);
            ClampedInt16 IMath<ClampedInt16>.Log(ClampedInt16 x, ClampedInt16 y) => (ClampedInt16)Math.Log(x._value, y._value);
            ClampedInt16 IMath<ClampedInt16>.Log10(ClampedInt16 x) => (ClampedInt16)Math.Log10(x._value);
            ClampedInt16 IMath<ClampedInt16>.Max(ClampedInt16 x, ClampedInt16 y) => Math.Max(x._value, y._value);
            ClampedInt16 IMath<ClampedInt16>.Min(ClampedInt16 x, ClampedInt16 y) => Math.Min(x._value, y._value);
            ClampedInt16 IMath<ClampedInt16>.PI { get; } = (short)3;
            ClampedInt16 IMath<ClampedInt16>.Pow(ClampedInt16 x, ClampedInt16 y) => ClampedArithmetic.Pow(x._value, y._value);
            ClampedInt16 IMath<ClampedInt16>.Round(ClampedInt16 x) => x;
            ClampedInt16 IMath<ClampedInt16>.Round(ClampedInt16 x, int digits) => x;
            ClampedInt16 IMath<ClampedInt16>.Round(ClampedInt16 x, int digits, MidpointRounding mode) => x;
            ClampedInt16 IMath<ClampedInt16>.Round(ClampedInt16 x, MidpointRounding mode) => x;
            ClampedInt16 IMath<ClampedInt16>.Sin(ClampedInt16 x) => (ClampedInt16)Math.Sin(x._value);
            ClampedInt16 IMath<ClampedInt16>.Sinh(ClampedInt16 x) => (ClampedInt16)Math.Sinh(x._value);
            ClampedInt16 IMath<ClampedInt16>.Sqrt(ClampedInt16 x) => (ClampedInt16)Math.Sqrt(x._value);
            ClampedInt16 IMath<ClampedInt16>.Tan(ClampedInt16 x) => (ClampedInt16)Math.Tan(x._value);
            ClampedInt16 IMath<ClampedInt16>.Tanh(ClampedInt16 x) => (ClampedInt16)Math.Tanh(x._value);
            ClampedInt16 IMath<ClampedInt16>.Tau { get; } = (short)6;
            ClampedInt16 IMath<ClampedInt16>.Truncate(ClampedInt16 x) => x;
            int IMath<ClampedInt16>.Sign(ClampedInt16 x) => Math.Sign(x._value);

            int INumericBitConverter<ClampedInt16>.ConvertedSize => sizeof(short);
            ClampedInt16 INumericBitConverter<ClampedInt16>.ToNumeric(byte[] value, int startIndex) => BitConverter.ToInt16(value, startIndex);
            byte[] INumericBitConverter<ClampedInt16>.GetBytes(ClampedInt16 value) => BitConverter.GetBytes(value._value);
#if HAS_SPANS
            ClampedInt16 INumericBitConverter<ClampedInt16>.ToNumeric(ReadOnlySpan<byte> value) => BitConverter.ToInt16(value);
            bool INumericBitConverter<ClampedInt16>.TryWriteBytes(Span<byte> destination, ClampedInt16 value) => BitConverter.TryWriteBytes(destination, value);
#endif

            bool IConvert<ClampedInt16>.ToBoolean(ClampedInt16 value) => value._value != 0;
            byte IConvert<ClampedInt16>.ToByte(ClampedInt16 value, Conversion mode) => ConvertN.ToByte(value._value, mode.Clamped());
            decimal IConvert<ClampedInt16>.ToDecimal(ClampedInt16 value, Conversion mode) => ConvertN.ToDecimal(value._value, mode.Clamped());
            double IConvert<ClampedInt16>.ToDouble(ClampedInt16 value, Conversion mode) => ConvertN.ToDouble(value._value, mode.Clamped());
            float IConvert<ClampedInt16>.ToSingle(ClampedInt16 value, Conversion mode) => ConvertN.ToSingle(value._value, mode.Clamped());
            int IConvert<ClampedInt16>.ToInt32(ClampedInt16 value, Conversion mode) => ConvertN.ToInt32(value._value, mode.Clamped());
            long IConvert<ClampedInt16>.ToInt64(ClampedInt16 value, Conversion mode) => ConvertN.ToInt64(value._value, mode.Clamped());
            sbyte IConvertExtended<ClampedInt16>.ToSByte(ClampedInt16 value, Conversion mode) => ConvertN.ToSByte(value._value, mode.Clamped());
            short IConvert<ClampedInt16>.ToInt16(ClampedInt16 value, Conversion mode) => value._value;
            string IConvert<ClampedInt16>.ToString(ClampedInt16 value) => Convert.ToString(value._value);
            uint IConvertExtended<ClampedInt16>.ToUInt32(ClampedInt16 value, Conversion mode) => ConvertN.ToUInt32(value._value, mode.Clamped());
            ulong IConvertExtended<ClampedInt16>.ToUInt64(ClampedInt16 value, Conversion mode) => ConvertN.ToUInt64(value._value, mode.Clamped());
            ushort IConvertExtended<ClampedInt16>.ToUInt16(ClampedInt16 value, Conversion mode) => ConvertN.ToUInt16(value._value, mode.Clamped());

            ClampedInt16 IConvert<ClampedInt16>.ToNumeric(bool value) => value ? (short)1 : (short)0;
            ClampedInt16 IConvert<ClampedInt16>.ToNumeric(byte value, Conversion mode) => ConvertN.ToInt16(value, mode.Clamped());
            ClampedInt16 IConvert<ClampedInt16>.ToNumeric(decimal value, Conversion mode) => ConvertN.ToInt16(value, mode.Clamped());
            ClampedInt16 IConvert<ClampedInt16>.ToNumeric(double value, Conversion mode) => ConvertN.ToInt16(value, mode.Clamped());
            ClampedInt16 IConvert<ClampedInt16>.ToNumeric(float value, Conversion mode) => ConvertN.ToInt16(value, mode.Clamped());
            ClampedInt16 IConvert<ClampedInt16>.ToNumeric(int value, Conversion mode) => ConvertN.ToInt16(value, mode.Clamped());
            ClampedInt16 IConvert<ClampedInt16>.ToNumeric(long value, Conversion mode) => ConvertN.ToInt16(value, mode.Clamped());
            ClampedInt16 IConvertExtended<ClampedInt16>.ToValue(sbyte value, Conversion mode) => ConvertN.ToInt16(value, mode.Clamped());
            ClampedInt16 IConvert<ClampedInt16>.ToNumeric(short value, Conversion mode) => value;
            ClampedInt16 IConvert<ClampedInt16>.ToNumeric(string value) => Convert.ToInt16(value);
            ClampedInt16 IConvertExtended<ClampedInt16>.ToNumeric(uint value, Conversion mode) => ConvertN.ToInt16(value, mode.Clamped());
            ClampedInt16 IConvertExtended<ClampedInt16>.ToNumeric(ulong value, Conversion mode) => ConvertN.ToInt16(value, mode.Clamped());
            ClampedInt16 IConvertExtended<ClampedInt16>.ToNumeric(ushort value, Conversion mode) => ConvertN.ToInt16(value, mode.Clamped());

            ClampedInt16 INumericStatic<ClampedInt16>.Parse(string s, NumberStyles? style, IFormatProvider? provider)
                => Parse(s, style ?? NumberStyles.Integer, provider);

            ClampedInt16 INumericRandom<ClampedInt16>.Generate(Random random) => random.NextInt16();
            ClampedInt16 INumericRandom<ClampedInt16>.Generate(Random random, ClampedInt16 maxValue) => random.NextInt16(maxValue);
            ClampedInt16 INumericRandom<ClampedInt16>.Generate(Random random, ClampedInt16 minValue, ClampedInt16 maxValue) => random.NextInt16(minValue, maxValue);
            ClampedInt16 INumericRandom<ClampedInt16>.Generate(Random random, Generation mode) => random.NextInt16(mode);
            ClampedInt16 INumericRandom<ClampedInt16>.Generate(Random random, ClampedInt16 minValue, ClampedInt16 maxValue, Generation mode) => random.NextInt16(minValue, maxValue, mode);

            ClampedInt16 IVariantRandom<ClampedInt16>.Generate(Random random, Variants variants) => random.NextInt16(variants);
        }
    }
}
