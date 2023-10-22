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
    /// Represents an 8-bit unsigned integer that cannot overflow.
    /// </summary>
    [Serializable]
    [DebuggerDisplay("{ToString(),nq}")]
    public readonly struct ClampedByte : INumericExtended<ClampedByte>
    {
        public static readonly ClampedByte MaxValue = new ClampedByte(byte.MaxValue);
        public static readonly ClampedByte MinValue = new ClampedByte(byte.MinValue);

        private readonly byte _value;

        private ClampedByte(byte value)
        {
            _value = value;
        }

        private ClampedByte(SerializationInfo info, StreamingContext context) : this(info.GetByte(nameof(ClampedByte))) { }
        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context) => info.AddValue(nameof(ClampedByte), _value);

        public int CompareTo(object? obj) => obj is ClampedByte other ? CompareTo(other) : 1;
        public int CompareTo(ClampedByte other) => _value.CompareTo(other._value);
        public bool Equals(ClampedByte other) => _value == other._value;
        public override bool Equals(object? obj) => obj is ClampedByte other && Equals(other);
        public override int GetHashCode() => _value.GetHashCode();
        public override string ToString() => _value.ToString();
        public string ToString(IFormatProvider? provider) => _value.ToString(provider);
        public string ToString(string format) => _value.ToString(format);
        public string ToString(string? format, IFormatProvider? formatProvider) => _value.ToString(format, formatProvider);

        public static bool TryParse(string s, IFormatProvider? provider, out ClampedByte result) => FuncExtensions.Try(() => Parse(s, provider), out result);
        public static bool TryParse(string s, NumberStyles style, IFormatProvider? provider, out ClampedByte result) => FuncExtensions.Try(() => Parse(s, style, provider), out result);
        public static bool TryParse(string s, NumberStyles style, out ClampedByte result) => FuncExtensions.Try(() => Parse(s, style), out result);
        public static bool TryParse(string s, out ClampedByte result) => FuncExtensions.Try(() => Parse(s), out result);
        public static ClampedByte Parse(string s) => byte.Parse(s);
        public static ClampedByte Parse(string s, IFormatProvider? provider) => byte.Parse(s, provider);
        public static ClampedByte Parse(string s, NumberStyles style) => byte.Parse(s, style);
        public static ClampedByte Parse(string s, NumberStyles style, IFormatProvider? provider) => byte.Parse(s, style, provider);

        [CLSCompliant(false)] public static explicit operator ClampedByte(sbyte value) => new ClampedByte(ConvertN.ToByte(value, Conversion.CastClamp));
        [CLSCompliant(false)] public static explicit operator ClampedByte(uint value) => new ClampedByte(ConvertN.ToByte(value, Conversion.CastClamp));
        [CLSCompliant(false)] public static explicit operator ClampedByte(ulong value) => new ClampedByte(ConvertN.ToByte(value, Conversion.CastClamp));
        [CLSCompliant(false)] public static implicit operator ClampedByte(ushort value) => new ClampedByte(ConvertN.ToByte(value, Conversion.CastClamp));
        public static explicit operator ClampedByte(decimal value) => new ClampedByte(ConvertN.ToByte(value, Conversion.CastClamp));
        public static explicit operator ClampedByte(double value) => new ClampedByte(ConvertN.ToByte(value, Conversion.CastClamp));
        public static explicit operator ClampedByte(float value) => new ClampedByte(ConvertN.ToByte(value, Conversion.CastClamp));
        public static explicit operator ClampedByte(int value) => new ClampedByte(ConvertN.ToByte(value, Conversion.CastClamp));
        public static explicit operator ClampedByte(long value) => new ClampedByte(ConvertN.ToByte(value, Conversion.CastClamp));
        public static explicit operator ClampedByte(short value) => new ClampedByte(ConvertN.ToByte(value, Conversion.CastClamp));
        public static implicit operator ClampedByte(byte value) => new ClampedByte(value);

        [CLSCompliant(false)] public static explicit operator sbyte(ClampedByte value) => ConvertN.ToSByte(value._value, Conversion.CastClamp);
        [CLSCompliant(false)] public static implicit operator uint(ClampedByte value) => value._value;
        [CLSCompliant(false)] public static implicit operator ulong(ClampedByte value) => value._value;
        [CLSCompliant(false)] public static implicit operator ushort(ClampedByte value) => value._value;
        public static implicit operator byte(ClampedByte value) => value._value;
        public static implicit operator decimal(ClampedByte value) => value._value;
        public static implicit operator double(ClampedByte value) => value._value;
        public static implicit operator float(ClampedByte value) => value._value;
        public static implicit operator int(ClampedByte value) => value._value;
        public static implicit operator long(ClampedByte value) => value._value;
        public static implicit operator short(ClampedByte value) => value._value;

        public static bool operator !=(ClampedByte left, ClampedByte right) => left._value != right._value;
        public static bool operator <(ClampedByte left, ClampedByte right) => left._value < right._value;
        public static bool operator <=(ClampedByte left, ClampedByte right) => left._value <= right._value;
        public static bool operator ==(ClampedByte left, ClampedByte right) => left._value == right._value;
        public static bool operator >(ClampedByte left, ClampedByte right) => left._value > right._value;
        public static bool operator >=(ClampedByte left, ClampedByte right) => left._value >= right._value;
        public static ClampedByte operator %(ClampedByte left, ClampedByte right) => ClampedArithmetic.Remainder(left._value, right._value);
        public static ClampedByte operator &(ClampedByte left, ClampedByte right) => (byte)(left._value & right._value);
        public static ClampedByte operator -(ClampedByte _) => MinValue;
        public static ClampedByte operator -(ClampedByte left, ClampedByte right) => ClampedArithmetic.Subtract(left._value, right._value);
        public static ClampedByte operator --(ClampedByte value) => value - 1;
        public static ClampedByte operator *(ClampedByte left, ClampedByte right) => ClampedArithmetic.Multiply(left._value, right._value);
        public static ClampedByte operator /(ClampedByte left, ClampedByte right) => ClampedArithmetic.Divide(left._value, right._value);
        public static ClampedByte operator ^(ClampedByte left, ClampedByte right) => (byte)(left._value ^ right._value);
        public static ClampedByte operator |(ClampedByte left, ClampedByte right) => (byte)(left._value | right._value);
        public static ClampedByte operator ~(ClampedByte value) => (byte)~value._value;
        public static ClampedByte operator +(ClampedByte left, ClampedByte right) => ClampedArithmetic.Add(left._value, right._value);
        public static ClampedByte operator +(ClampedByte value) => value;
        public static ClampedByte operator ++(ClampedByte value) => value + 1;
        public static ClampedByte operator <<(ClampedByte left, int right) => (byte)(left._value << right);
        public static ClampedByte operator >>(ClampedByte left, int right) => (byte)(left._value >> right);

        TypeCode IConvertible.GetTypeCode() => _value.GetTypeCode();
        bool IConvertible.ToBoolean(IFormatProvider? provider) => Convert.ToBoolean(_value, provider);
        byte IConvertible.ToByte(IFormatProvider? provider) => _value;
        char IConvertible.ToChar(IFormatProvider? provider) => Convert.ToChar(_value, provider);
        DateTime IConvertible.ToDateTime(IFormatProvider? provider) => Convert.ToDateTime(provider);
        decimal IConvertible.ToDecimal(IFormatProvider? provider) => ConvertN.ToDecimal(_value, Conversion.Clamp);
        double IConvertible.ToDouble(IFormatProvider? provider) => ConvertN.ToDouble(_value, Conversion.Clamp);
        float IConvertible.ToSingle(IFormatProvider? provider) => ConvertN.ToSingle(_value, Conversion.Clamp);
        int IConvertible.ToInt32(IFormatProvider? provider) => ConvertN.ToInt32(_value, Conversion.Clamp);
        long IConvertible.ToInt64(IFormatProvider? provider) => ConvertN.ToInt64(_value, Conversion.Clamp);
        sbyte IConvertible.ToSByte(IFormatProvider? provider) => ConvertN.ToSByte(_value, Conversion.Clamp);
        short IConvertible.ToInt16(IFormatProvider? provider) => ConvertN.ToInt16(_value, Conversion.Clamp);
        uint IConvertible.ToUInt32(IFormatProvider? provider) => ConvertN.ToUInt32(_value, Conversion.Clamp);
        ulong IConvertible.ToUInt64(IFormatProvider? provider) => ConvertN.ToUInt64(_value, Conversion.Clamp);
        ushort IConvertible.ToUInt16(IFormatProvider? provider) => ConvertN.ToUInt16(_value, Conversion.Clamp);
        object IConvertible.ToType(Type conversionType, IFormatProvider? provider) => this.ToTypeDefault(conversionType, provider);

        bool INumeric<ClampedByte>.IsGreaterThan(ClampedByte value) => this > value;
        bool INumeric<ClampedByte>.IsGreaterThanOrEqualTo(ClampedByte value) => this >= value;
        bool INumeric<ClampedByte>.IsLessThan(ClampedByte value) => this < value;
        bool INumeric<ClampedByte>.IsLessThanOrEqualTo(ClampedByte value) => this <= value;
        ClampedByte INumeric<ClampedByte>.Add(ClampedByte value) => this + value;
        ClampedByte INumeric<ClampedByte>.BitwiseComplement() => ~this;
        ClampedByte INumeric<ClampedByte>.Divide(ClampedByte value) => this / value;
        ClampedByte INumeric<ClampedByte>.LeftShift(int count) => this << count;
        ClampedByte INumeric<ClampedByte>.LogicalAnd(ClampedByte value) => this & value;
        ClampedByte INumeric<ClampedByte>.LogicalExclusiveOr(ClampedByte value) => this ^ value;
        ClampedByte INumeric<ClampedByte>.LogicalOr(ClampedByte value) => this | value;
        ClampedByte INumeric<ClampedByte>.Multiply(ClampedByte value) => this * value;
        ClampedByte INumeric<ClampedByte>.Negative() => -this;
        ClampedByte INumeric<ClampedByte>.Positive() => +this;
        ClampedByte INumeric<ClampedByte>.Remainder(ClampedByte value) => this % value;
        ClampedByte INumeric<ClampedByte>.RightShift(int count) => this >> count;
        ClampedByte INumeric<ClampedByte>.Subtract(ClampedByte value) => this - value;

        INumericBitConverter<ClampedByte> IProvider<INumericBitConverter<ClampedByte>>.GetInstance() => Utilities.Instance;
        IBinaryIO<ClampedByte> IProvider<IBinaryIO<ClampedByte>>.GetInstance() => Utilities.Instance;
        IConvert<ClampedByte> IProvider<IConvert<ClampedByte>>.GetInstance() => Utilities.Instance;
        IConvertExtended<ClampedByte> IProvider<IConvertExtended<ClampedByte>>.GetInstance() => Utilities.Instance;
        IMath<ClampedByte> IProvider<IMath<ClampedByte>>.GetInstance() => Utilities.Instance;
        INumericRandom<ClampedByte> IProvider<INumericRandom<ClampedByte>>.GetInstance() => Utilities.Instance;
        INumericStatic<ClampedByte> IProvider<INumericStatic<ClampedByte>>.GetInstance() => Utilities.Instance;
        IVariantRandom<ClampedByte> IProvider<IVariantRandom<ClampedByte>>.GetInstance() => Utilities.Instance;

        private sealed class Utilities :
            IBinaryIO<ClampedByte>,
            IConvert<ClampedByte>,
            IConvertExtended<ClampedByte>,
            IMath<ClampedByte>,
            INumericBitConverter<ClampedByte>,
            INumericRandom<ClampedByte>,
            INumericStatic<ClampedByte>,
            IVariantRandom<ClampedByte>
        {
            public static readonly Utilities Instance = new Utilities();

            void IBinaryIO<ClampedByte>.Write(BinaryWriter writer, ClampedByte value) => writer.Write(value);
            ClampedByte IBinaryIO<ClampedByte>.Read(BinaryReader reader) => reader.ReadByte();

            bool INumericStatic<ClampedByte>.HasFloatingPoint => false;
            bool INumericStatic<ClampedByte>.HasInfinity => false;
            bool INumericStatic<ClampedByte>.HasNaN => false;
            bool INumericStatic<ClampedByte>.IsFinite(ClampedByte x) => true;
            bool INumericStatic<ClampedByte>.IsInfinity(ClampedByte x) => false;
            bool INumericStatic<ClampedByte>.IsNaN(ClampedByte x) => false;
            bool INumericStatic<ClampedByte>.IsNegative(ClampedByte x) => false;
            bool INumericStatic<ClampedByte>.IsNegativeInfinity(ClampedByte x) => false;
            bool INumericStatic<ClampedByte>.IsNormal(ClampedByte x) => false;
            bool INumericStatic<ClampedByte>.IsPositiveInfinity(ClampedByte x) => false;
            bool INumericStatic<ClampedByte>.IsReal => false;
            bool INumericStatic<ClampedByte>.IsSigned => false;
            bool INumericStatic<ClampedByte>.IsSubnormal(ClampedByte x) => false;
            ClampedByte INumericStatic<ClampedByte>.Epsilon => 1;
            ClampedByte INumericStatic<ClampedByte>.MaxUnit => 1;
            ClampedByte INumericStatic<ClampedByte>.MaxValue => MaxValue;
            ClampedByte INumericStatic<ClampedByte>.MinUnit => 0;
            ClampedByte INumericStatic<ClampedByte>.MinValue => MinValue;
            ClampedByte INumericStatic<ClampedByte>.One => 1;
            ClampedByte INumericStatic<ClampedByte>.Zero => 0;

            ClampedByte IMath<ClampedByte>.Abs(ClampedByte value) => value;
            ClampedByte IMath<ClampedByte>.Acos(ClampedByte x) => ConvertN.ToByte(Math.Acos(x._value), Conversion.CastClamp);
            ClampedByte IMath<ClampedByte>.Acosh(ClampedByte x) => ConvertN.ToByte(MathShim.Acosh(x._value), Conversion.CastClamp);
            ClampedByte IMath<ClampedByte>.Asin(ClampedByte x) => ConvertN.ToByte(Math.Asin(x._value), Conversion.CastClamp);
            ClampedByte IMath<ClampedByte>.Asinh(ClampedByte x) => ConvertN.ToByte(MathShim.Asinh(x._value), Conversion.CastClamp);
            ClampedByte IMath<ClampedByte>.Atan(ClampedByte x) => ConvertN.ToByte(Math.Atan(x._value), Conversion.CastClamp);
            ClampedByte IMath<ClampedByte>.Atan2(ClampedByte x, ClampedByte y) => ConvertN.ToByte(Math.Atan2(x._value, y._value), Conversion.CastClamp);
            ClampedByte IMath<ClampedByte>.Atanh(ClampedByte x) => ConvertN.ToByte(MathShim.Atanh(x._value), Conversion.CastClamp);
            ClampedByte IMath<ClampedByte>.Cbrt(ClampedByte x) => ConvertN.ToByte(MathShim.Cbrt(x._value), Conversion.CastClamp);
            ClampedByte IMath<ClampedByte>.Ceiling(ClampedByte x) => x;
            ClampedByte IMath<ClampedByte>.Clamp(ClampedByte x, ClampedByte bound1, ClampedByte bound2) => bound1 > bound2 ? Math.Min(bound1._value, Math.Max(bound2._value, x._value)) : Math.Min(bound2._value, Math.Max(bound1._value, x._value));
            ClampedByte IMath<ClampedByte>.Cos(ClampedByte x) => ConvertN.ToByte(Math.Cos(x._value), Conversion.CastClamp);
            ClampedByte IMath<ClampedByte>.Cosh(ClampedByte x) => ConvertN.ToByte(Math.Cosh(x._value), Conversion.CastClamp);
            ClampedByte IMath<ClampedByte>.E { get; } = 2;
            ClampedByte IMath<ClampedByte>.Exp(ClampedByte x) => ConvertN.ToByte(Math.Exp(x._value), Conversion.CastClamp);
            ClampedByte IMath<ClampedByte>.Floor(ClampedByte x) => x;
            ClampedByte IMath<ClampedByte>.IEEERemainder(ClampedByte x, ClampedByte y) => ConvertN.ToByte(Math.IEEERemainder(x._value, y._value), Conversion.CastClamp);
            ClampedByte IMath<ClampedByte>.Log(ClampedByte x) => ConvertN.ToByte(Math.Log(x._value), Conversion.CastClamp);
            ClampedByte IMath<ClampedByte>.Log(ClampedByte x, ClampedByte y) => ConvertN.ToByte(Math.Log(x._value, y._value), Conversion.CastClamp);
            ClampedByte IMath<ClampedByte>.Log10(ClampedByte x) => ConvertN.ToByte(Math.Log10(x._value), Conversion.CastClamp);
            ClampedByte IMath<ClampedByte>.Max(ClampedByte x, ClampedByte y) => Math.Max(x._value, y._value);
            ClampedByte IMath<ClampedByte>.Min(ClampedByte x, ClampedByte y) => Math.Min(x._value, y._value);
            ClampedByte IMath<ClampedByte>.PI { get; } = 3;
            ClampedByte IMath<ClampedByte>.Pow(ClampedByte x, ClampedByte y) => ClampedArithmetic.Pow(x._value, y._value);
            ClampedByte IMath<ClampedByte>.Round(ClampedByte x) => x;
            ClampedByte IMath<ClampedByte>.Round(ClampedByte x, int digits) => x;
            ClampedByte IMath<ClampedByte>.Round(ClampedByte x, int digits, MidpointRounding mode) => x;
            ClampedByte IMath<ClampedByte>.Round(ClampedByte x, MidpointRounding mode) => x;
            ClampedByte IMath<ClampedByte>.Sin(ClampedByte x) => ConvertN.ToByte(Math.Sin(x._value), Conversion.CastClamp);
            ClampedByte IMath<ClampedByte>.Sinh(ClampedByte x) => ConvertN.ToByte(Math.Sinh(x._value), Conversion.CastClamp);
            ClampedByte IMath<ClampedByte>.Sqrt(ClampedByte x) => ConvertN.ToByte(Math.Sqrt(x._value), Conversion.CastClamp);
            ClampedByte IMath<ClampedByte>.Tan(ClampedByte x) => ConvertN.ToByte(Math.Tan(x._value), Conversion.CastClamp);
            ClampedByte IMath<ClampedByte>.Tanh(ClampedByte x) => ConvertN.ToByte(Math.Tanh(x._value), Conversion.CastClamp);
            ClampedByte IMath<ClampedByte>.Tau { get; } = 6;
            ClampedByte IMath<ClampedByte>.Truncate(ClampedByte x) => x;
            int IMath<ClampedByte>.Sign(ClampedByte x) => x._value == 0 ? 0 : 1;

            int INumericBitConverter<ClampedByte>.ConvertedSize => sizeof(byte);
            ClampedByte INumericBitConverter<ClampedByte>.ToNumeric(byte[] value, int startIndex) => BitOperations.ToByte(value, startIndex);
            byte[] INumericBitConverter<ClampedByte>.GetBytes(ClampedByte value) => new byte[] { value._value };
#if HAS_SPANS
            ClampedByte INumericBitConverter<ClampedByte>.ToNumeric(ReadOnlySpan<byte> value) => BitOperations.ToByte(value);
            bool INumericBitConverter<ClampedByte>.TryWriteBytes(Span<byte> destination, ClampedByte value) => BitOperations.TryWriteByte(destination, value);
#endif

            bool IConvert<ClampedByte>.ToBoolean(ClampedByte value) => value._value != 0;
            byte IConvert<ClampedByte>.ToByte(ClampedByte value, Conversion mode) => value._value;
            decimal IConvert<ClampedByte>.ToDecimal(ClampedByte value, Conversion mode) => ConvertN.ToDecimal(value._value, mode.Clamped());
            double IConvert<ClampedByte>.ToDouble(ClampedByte value, Conversion mode) => ConvertN.ToDouble(value._value, mode.Clamped());
            float IConvert<ClampedByte>.ToSingle(ClampedByte value, Conversion mode) => ConvertN.ToSingle(value._value, mode.Clamped());
            int IConvert<ClampedByte>.ToInt32(ClampedByte value, Conversion mode) => ConvertN.ToInt32(value._value, mode.Clamped());
            long IConvert<ClampedByte>.ToInt64(ClampedByte value, Conversion mode) => ConvertN.ToInt64(value._value, mode.Clamped());
            sbyte IConvertExtended<ClampedByte>.ToSByte(ClampedByte value, Conversion mode) => ConvertN.ToSByte(value._value, mode.Clamped());
            short IConvert<ClampedByte>.ToInt16(ClampedByte value, Conversion mode) => ConvertN.ToInt16(value._value, mode.Clamped());
            string IConvert<ClampedByte>.ToString(ClampedByte value) => Convert.ToString(value._value);
            uint IConvertExtended<ClampedByte>.ToUInt32(ClampedByte value, Conversion mode) => ConvertN.ToUInt16(value._value, mode.Clamped());
            ulong IConvertExtended<ClampedByte>.ToUInt64(ClampedByte value, Conversion mode) => ConvertN.ToUInt64(value._value, mode.Clamped());
            ushort IConvertExtended<ClampedByte>.ToUInt16(ClampedByte value, Conversion mode) => ConvertN.ToByte(value._value, mode.Clamped());

            ClampedByte IConvert<ClampedByte>.ToNumeric(bool value) => value ? (byte)1 : (byte)0;
            ClampedByte IConvert<ClampedByte>.ToNumeric(byte value, Conversion mode) => ConvertN.ToByte(value, mode.Clamped());
            ClampedByte IConvert<ClampedByte>.ToNumeric(decimal value, Conversion mode) => ConvertN.ToByte(value, mode.Clamped());
            ClampedByte IConvert<ClampedByte>.ToNumeric(double value, Conversion mode) => ConvertN.ToByte(value, mode.Clamped());
            ClampedByte IConvert<ClampedByte>.ToNumeric(float value, Conversion mode) => ConvertN.ToByte(value, mode.Clamped());
            ClampedByte IConvert<ClampedByte>.ToNumeric(int value, Conversion mode) => ConvertN.ToByte(value, mode.Clamped());
            ClampedByte IConvert<ClampedByte>.ToNumeric(long value, Conversion mode) => ConvertN.ToByte(value, mode.Clamped());
            ClampedByte IConvertExtended<ClampedByte>.ToValue(sbyte value, Conversion mode) => ConvertN.ToByte(value, mode.Clamped());
            ClampedByte IConvert<ClampedByte>.ToNumeric(short value, Conversion mode) => ConvertN.ToByte(value, mode.Clamped());
            ClampedByte IConvert<ClampedByte>.ToNumeric(string value) => Convert.ToByte(value);
            ClampedByte IConvertExtended<ClampedByte>.ToNumeric(uint value, Conversion mode) => ConvertN.ToByte(value, mode.Clamped());
            ClampedByte IConvertExtended<ClampedByte>.ToNumeric(ulong value, Conversion mode) => ConvertN.ToByte(value, mode.Clamped());
            ClampedByte IConvertExtended<ClampedByte>.ToNumeric(ushort value, Conversion mode) => value;

            ClampedByte INumericStatic<ClampedByte>.Parse(string s, NumberStyles? style, IFormatProvider? provider)
                => Parse(s, style ?? NumberStyles.Integer, provider);

            ClampedByte INumericRandom<ClampedByte>.Generate(Random random) => random.NextByte();
            ClampedByte INumericRandom<ClampedByte>.Generate(Random random, ClampedByte maxValue) => random.NextByte(maxValue);
            ClampedByte INumericRandom<ClampedByte>.Generate(Random random, ClampedByte minValue, ClampedByte maxValue) => random.NextByte(minValue, maxValue);
            ClampedByte INumericRandom<ClampedByte>.Generate(Random random, Generation mode) => random.NextByte(mode);
            ClampedByte INumericRandom<ClampedByte>.Generate(Random random, ClampedByte minValue, ClampedByte maxValue, Generation mode) => random.NextByte(minValue, maxValue, mode);

            ClampedByte IVariantRandom<ClampedByte>.Generate(Random random, Variants variants) => random.NextByte(variants);
        }
    }
}
