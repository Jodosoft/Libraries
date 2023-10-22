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
    /// Represents an 8-bit signed integer that cannot overflow.
    /// </summary>
    [Serializable]
    [DebuggerDisplay("{ToString(),nq}")]
    public readonly struct ClampedSByte : INumericExtended<ClampedSByte>
    {
        public static readonly ClampedSByte MaxValue = new ClampedSByte(sbyte.MaxValue);
        public static readonly ClampedSByte MinValue = new ClampedSByte(sbyte.MinValue);

        private readonly sbyte _value;

        private ClampedSByte(sbyte value)
        {
            _value = value;
        }

        private ClampedSByte(SerializationInfo info, StreamingContext context) : this(info.GetSByte(nameof(ClampedSByte))) { }
        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context) => info.AddValue(nameof(ClampedSByte), _value);

        public int CompareTo(ClampedSByte other) => _value.CompareTo(other._value);
        public int CompareTo(object? obj) => obj is ClampedSByte other ? CompareTo(other) : 1;
        public bool Equals(ClampedSByte other) => _value == other._value;
        public override bool Equals(object? obj) => obj is ClampedSByte other && Equals(other);
        public override int GetHashCode() => _value.GetHashCode();
        public override string ToString() => _value.ToString();
        public string ToString(IFormatProvider? provider) => _value.ToString(provider);
        public string ToString(string format) => _value.ToString(format);
        public string ToString(string? format, IFormatProvider? formatProvider) => _value.ToString(format, formatProvider);

        public static bool TryParse(string s, IFormatProvider? provider, out ClampedSByte result) => FuncExtensions.Try(() => Parse(s, provider), out result);
        public static bool TryParse(string s, NumberStyles style, IFormatProvider? provider, out ClampedSByte result) => FuncExtensions.Try(() => Parse(s, style, provider), out result);
        public static bool TryParse(string s, NumberStyles style, out ClampedSByte result) => FuncExtensions.Try(() => Parse(s, style), out result);
        public static bool TryParse(string s, out ClampedSByte result) => FuncExtensions.Try(() => Parse(s), out result);
        public static ClampedSByte Parse(string s) => sbyte.Parse(s);
        public static ClampedSByte Parse(string s, IFormatProvider? provider) => sbyte.Parse(s, provider);
        public static ClampedSByte Parse(string s, NumberStyles style) => sbyte.Parse(s, style);
        public static ClampedSByte Parse(string s, NumberStyles style, IFormatProvider? provider) => sbyte.Parse(s, style, provider);

        [CLSCompliant(false)] public static explicit operator ClampedSByte(uint value) => new ClampedSByte(ConvertN.ToSByte(value, Conversion.CastClamp));
        [CLSCompliant(false)] public static explicit operator ClampedSByte(ulong value) => new ClampedSByte(ConvertN.ToSByte(value, Conversion.CastClamp));
        [CLSCompliant(false)] public static explicit operator ClampedSByte(ushort value) => new ClampedSByte(ConvertN.ToSByte(value, Conversion.CastClamp));
        [CLSCompliant(false)] public static implicit operator ClampedSByte(sbyte value) => new ClampedSByte(value);
        public static explicit operator ClampedSByte(byte value) => new ClampedSByte(ConvertN.ToSByte(value, Conversion.CastClamp));
        public static explicit operator ClampedSByte(decimal value) => new ClampedSByte(ConvertN.ToSByte(value, Conversion.CastClamp));
        public static explicit operator ClampedSByte(double value) => new ClampedSByte(ConvertN.ToSByte(value, Conversion.CastClamp));
        public static explicit operator ClampedSByte(float value) => new ClampedSByte(ConvertN.ToSByte(value, Conversion.CastClamp));
        public static explicit operator ClampedSByte(int value) => new ClampedSByte(ConvertN.ToSByte(value, Conversion.CastClamp));
        public static explicit operator ClampedSByte(long value) => new ClampedSByte(ConvertN.ToSByte(value, Conversion.CastClamp));
        public static explicit operator ClampedSByte(short value) => new ClampedSByte(ConvertN.ToSByte(value, Conversion.CastClamp));

        [CLSCompliant(false)] public static explicit operator uint(ClampedSByte value) => ConvertN.ToUInt32(value._value, Conversion.CastClamp);
        [CLSCompliant(false)] public static explicit operator ulong(ClampedSByte value) => ConvertN.ToUInt64(value._value, Conversion.CastClamp);
        [CLSCompliant(false)] public static explicit operator ushort(ClampedSByte value) => ConvertN.ToUInt16(value._value, Conversion.CastClamp);
        [CLSCompliant(false)] public static implicit operator sbyte(ClampedSByte value) => value._value;
        public static explicit operator byte(ClampedSByte value) => ConvertN.ToByte(value._value, Conversion.CastClamp);
        public static implicit operator decimal(ClampedSByte value) => value._value;
        public static implicit operator double(ClampedSByte value) => value._value;
        public static implicit operator float(ClampedSByte value) => value._value;
        public static implicit operator int(ClampedSByte value) => value._value;
        public static implicit operator long(ClampedSByte value) => value._value;
        public static implicit operator short(ClampedSByte value) => value._value;

        public static bool operator !=(ClampedSByte left, ClampedSByte right) => left._value != right._value;
        public static bool operator <(ClampedSByte left, ClampedSByte right) => left._value < right._value;
        public static bool operator <=(ClampedSByte left, ClampedSByte right) => left._value <= right._value;
        public static bool operator ==(ClampedSByte left, ClampedSByte right) => left._value == right._value;
        public static bool operator >(ClampedSByte left, ClampedSByte right) => left._value > right._value;
        public static bool operator >=(ClampedSByte left, ClampedSByte right) => left._value >= right._value;
        public static ClampedSByte operator %(ClampedSByte left, ClampedSByte right) => ClampedArithmetic.Remainder(left._value, right._value);
        public static ClampedSByte operator &(ClampedSByte left, ClampedSByte right) => (sbyte)(left._value & right._value);
        public static ClampedSByte operator -(ClampedSByte left, ClampedSByte right) => ClampedArithmetic.Subtract(left._value, right._value);
        public static ClampedSByte operator --(ClampedSByte value) => ClampedArithmetic.Subtract(value._value, (sbyte)1);
        public static ClampedSByte operator -(ClampedSByte value) => (sbyte)-value._value;
        public static ClampedSByte operator *(ClampedSByte left, ClampedSByte right) => ClampedArithmetic.Multiply(left._value, right._value);
        public static ClampedSByte operator /(ClampedSByte left, ClampedSByte right) => ClampedArithmetic.Divide(left._value, right._value);
        public static ClampedSByte operator ^(ClampedSByte left, ClampedSByte right) => (sbyte)(left._value ^ right._value);
        public static ClampedSByte operator |(ClampedSByte left, ClampedSByte right) => (sbyte)(left._value | right._value);
        public static ClampedSByte operator ~(ClampedSByte value) => (sbyte)~value._value;
        public static ClampedSByte operator +(ClampedSByte left, ClampedSByte right) => ClampedArithmetic.Add(left._value, right._value);
        public static ClampedSByte operator +(ClampedSByte value) => value;
        public static ClampedSByte operator ++(ClampedSByte value) => ClampedArithmetic.Add(value._value, (sbyte)1);
        public static ClampedSByte operator <<(ClampedSByte left, int right) => (sbyte)(left._value << right);
        public static ClampedSByte operator >>(ClampedSByte left, int right) => (sbyte)(left._value >> right);

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
        sbyte IConvertible.ToSByte(IFormatProvider? provider) => _value;
        short IConvertible.ToInt16(IFormatProvider? provider) => ConvertN.ToInt16(_value, Conversion.Clamp);
        uint IConvertible.ToUInt32(IFormatProvider? provider) => ConvertN.ToUInt32(_value, Conversion.Clamp);
        ulong IConvertible.ToUInt64(IFormatProvider? provider) => ConvertN.ToUInt64(_value, Conversion.Clamp);
        ushort IConvertible.ToUInt16(IFormatProvider? provider) => ConvertN.ToUInt16(_value, Conversion.Clamp);
        object IConvertible.ToType(Type conversionType, IFormatProvider? provider) => this.ToTypeDefault(conversionType, provider);

        bool INumeric<ClampedSByte>.IsGreaterThan(ClampedSByte value) => this > value;
        bool INumeric<ClampedSByte>.IsGreaterThanOrEqualTo(ClampedSByte value) => this >= value;
        bool INumeric<ClampedSByte>.IsLessThan(ClampedSByte value) => this < value;
        bool INumeric<ClampedSByte>.IsLessThanOrEqualTo(ClampedSByte value) => this <= value;
        ClampedSByte INumeric<ClampedSByte>.Add(ClampedSByte value) => this + value;
        ClampedSByte INumeric<ClampedSByte>.BitwiseComplement() => ~this;
        ClampedSByte INumeric<ClampedSByte>.Divide(ClampedSByte value) => this / value;
        ClampedSByte INumeric<ClampedSByte>.LeftShift(int count) => this << count;
        ClampedSByte INumeric<ClampedSByte>.LogicalAnd(ClampedSByte value) => this & value;
        ClampedSByte INumeric<ClampedSByte>.LogicalExclusiveOr(ClampedSByte value) => this ^ value;
        ClampedSByte INumeric<ClampedSByte>.LogicalOr(ClampedSByte value) => this | value;
        ClampedSByte INumeric<ClampedSByte>.Multiply(ClampedSByte value) => this * value;
        ClampedSByte INumeric<ClampedSByte>.Negative() => -this;
        ClampedSByte INumeric<ClampedSByte>.Positive() => +this;
        ClampedSByte INumeric<ClampedSByte>.Remainder(ClampedSByte value) => this % value;
        ClampedSByte INumeric<ClampedSByte>.RightShift(int count) => this >> count;
        ClampedSByte INumeric<ClampedSByte>.Subtract(ClampedSByte value) => this - value;

        INumericBitConverter<ClampedSByte> IProvider<INumericBitConverter<ClampedSByte>>.GetInstance() => Utilities.Instance;
        IBinaryIO<ClampedSByte> IProvider<IBinaryIO<ClampedSByte>>.GetInstance() => Utilities.Instance;
        IConvert<ClampedSByte> IProvider<IConvert<ClampedSByte>>.GetInstance() => Utilities.Instance;
        IConvertExtended<ClampedSByte> IProvider<IConvertExtended<ClampedSByte>>.GetInstance() => Utilities.Instance;
        IMath<ClampedSByte> IProvider<IMath<ClampedSByte>>.GetInstance() => Utilities.Instance;
        INumericRandom<ClampedSByte> IProvider<INumericRandom<ClampedSByte>>.GetInstance() => Utilities.Instance;
        INumericStatic<ClampedSByte> IProvider<INumericStatic<ClampedSByte>>.GetInstance() => Utilities.Instance;
        IVariantRandom<ClampedSByte> IProvider<IVariantRandom<ClampedSByte>>.GetInstance() => Utilities.Instance;

        private sealed class Utilities :
            IBinaryIO<ClampedSByte>,
            IConvert<ClampedSByte>,
            IConvertExtended<ClampedSByte>,
            IMath<ClampedSByte>,
            INumericBitConverter<ClampedSByte>,
            INumericRandom<ClampedSByte>,
            INumericStatic<ClampedSByte>,
            IVariantRandom<ClampedSByte>
        {
            public static readonly Utilities Instance = new Utilities();

            void IBinaryIO<ClampedSByte>.Write(BinaryWriter writer, ClampedSByte value) => writer.Write(value);
            ClampedSByte IBinaryIO<ClampedSByte>.Read(BinaryReader reader) => reader.ReadSByte();

            bool INumericStatic<ClampedSByte>.HasFloatingPoint => false;
            bool INumericStatic<ClampedSByte>.HasInfinity => false;
            bool INumericStatic<ClampedSByte>.HasNaN => false;
            bool INumericStatic<ClampedSByte>.IsFinite(ClampedSByte x) => true;
            bool INumericStatic<ClampedSByte>.IsInfinity(ClampedSByte x) => false;
            bool INumericStatic<ClampedSByte>.IsNaN(ClampedSByte x) => false;
            bool INumericStatic<ClampedSByte>.IsNegative(ClampedSByte x) => x._value < 0;
            bool INumericStatic<ClampedSByte>.IsNegativeInfinity(ClampedSByte x) => false;
            bool INumericStatic<ClampedSByte>.IsNormal(ClampedSByte x) => false;
            bool INumericStatic<ClampedSByte>.IsPositiveInfinity(ClampedSByte x) => false;
            bool INumericStatic<ClampedSByte>.IsReal => false;
            bool INumericStatic<ClampedSByte>.IsSigned => true;
            bool INumericStatic<ClampedSByte>.IsSubnormal(ClampedSByte x) => false;
            ClampedSByte INumericStatic<ClampedSByte>.Epsilon => 1;
            ClampedSByte INumericStatic<ClampedSByte>.MaxUnit => 1;
            ClampedSByte INumericStatic<ClampedSByte>.MaxValue => MaxValue;
            ClampedSByte INumericStatic<ClampedSByte>.MinUnit => -1;
            ClampedSByte INumericStatic<ClampedSByte>.MinValue => MinValue;
            ClampedSByte INumericStatic<ClampedSByte>.One => 1;
            ClampedSByte INumericStatic<ClampedSByte>.Zero => 0;

            ClampedSByte IMath<ClampedSByte>.Abs(ClampedSByte value) => Math.Abs(value._value);
            ClampedSByte IMath<ClampedSByte>.Acos(ClampedSByte x) => (ClampedSByte)Math.Acos(x._value);
            ClampedSByte IMath<ClampedSByte>.Acosh(ClampedSByte x) => (ClampedSByte)MathShim.Acosh(x._value);
            ClampedSByte IMath<ClampedSByte>.Asin(ClampedSByte x) => (ClampedSByte)Math.Asin(x._value);
            ClampedSByte IMath<ClampedSByte>.Asinh(ClampedSByte x) => (ClampedSByte)MathShim.Asinh(x._value);
            ClampedSByte IMath<ClampedSByte>.Atan(ClampedSByte x) => (ClampedSByte)Math.Atan(x._value);
            ClampedSByte IMath<ClampedSByte>.Atan2(ClampedSByte x, ClampedSByte y) => (ClampedSByte)Math.Atan2(x._value, y._value);
            ClampedSByte IMath<ClampedSByte>.Atanh(ClampedSByte x) => (ClampedSByte)MathShim.Atanh(x._value);
            ClampedSByte IMath<ClampedSByte>.Cbrt(ClampedSByte x) => (ClampedSByte)MathShim.Cbrt(x._value);
            ClampedSByte IMath<ClampedSByte>.Ceiling(ClampedSByte x) => x;
            ClampedSByte IMath<ClampedSByte>.Clamp(ClampedSByte x, ClampedSByte bound1, ClampedSByte bound2) => bound1 > bound2 ? Math.Min(bound1._value, Math.Max(bound2._value, x._value)) : Math.Min(bound2._value, Math.Max(bound1._value, x._value));
            ClampedSByte IMath<ClampedSByte>.Cos(ClampedSByte x) => (ClampedSByte)Math.Cos(x._value);
            ClampedSByte IMath<ClampedSByte>.Cosh(ClampedSByte x) => (ClampedSByte)Math.Cosh(x._value);
            ClampedSByte IMath<ClampedSByte>.E { get; } = 2;
            ClampedSByte IMath<ClampedSByte>.Exp(ClampedSByte x) => (ClampedSByte)Math.Exp(x._value);
            ClampedSByte IMath<ClampedSByte>.Floor(ClampedSByte x) => x;
            ClampedSByte IMath<ClampedSByte>.IEEERemainder(ClampedSByte x, ClampedSByte y) => (ClampedSByte)Math.IEEERemainder(x._value, y._value);
            ClampedSByte IMath<ClampedSByte>.Log(ClampedSByte x) => (ClampedSByte)Math.Log(x._value);
            ClampedSByte IMath<ClampedSByte>.Log(ClampedSByte x, ClampedSByte y) => (ClampedSByte)Math.Log(x._value, y._value);
            ClampedSByte IMath<ClampedSByte>.Log10(ClampedSByte x) => (ClampedSByte)Math.Log10(x._value);
            ClampedSByte IMath<ClampedSByte>.Max(ClampedSByte x, ClampedSByte y) => Math.Max(x._value, y._value);
            ClampedSByte IMath<ClampedSByte>.Min(ClampedSByte x, ClampedSByte y) => Math.Min(x._value, y._value);
            ClampedSByte IMath<ClampedSByte>.PI { get; } = 3;
            ClampedSByte IMath<ClampedSByte>.Pow(ClampedSByte x, ClampedSByte y) => ClampedArithmetic.Pow(x._value, y._value);
            ClampedSByte IMath<ClampedSByte>.Round(ClampedSByte x) => x;
            ClampedSByte IMath<ClampedSByte>.Round(ClampedSByte x, int digits) => x;
            ClampedSByte IMath<ClampedSByte>.Round(ClampedSByte x, int digits, MidpointRounding mode) => x;
            ClampedSByte IMath<ClampedSByte>.Round(ClampedSByte x, MidpointRounding mode) => x;
            ClampedSByte IMath<ClampedSByte>.Sin(ClampedSByte x) => (ClampedSByte)Math.Sin(x._value);
            ClampedSByte IMath<ClampedSByte>.Sinh(ClampedSByte x) => (ClampedSByte)Math.Sinh(x._value);
            ClampedSByte IMath<ClampedSByte>.Sqrt(ClampedSByte x) => (ClampedSByte)Math.Sqrt(x._value);
            ClampedSByte IMath<ClampedSByte>.Tan(ClampedSByte x) => (ClampedSByte)Math.Tan(x._value);
            ClampedSByte IMath<ClampedSByte>.Tanh(ClampedSByte x) => (ClampedSByte)Math.Tanh(x._value);
            ClampedSByte IMath<ClampedSByte>.Tau { get; } = 6;
            ClampedSByte IMath<ClampedSByte>.Truncate(ClampedSByte x) => x;
            int IMath<ClampedSByte>.Sign(ClampedSByte x) => Math.Sign(x._value);

            int INumericBitConverter<ClampedSByte>.ConvertedSize => sizeof(sbyte);
            ClampedSByte INumericBitConverter<ClampedSByte>.ToNumeric(byte[] value, int startIndex) => BitOperations.ToSByte(value, startIndex);
            byte[] INumericBitConverter<ClampedSByte>.GetBytes(ClampedSByte value) => new byte[] { (byte)value._value };
#if HAS_SPANS
            ClampedSByte INumericBitConverter<ClampedSByte>.ToNumeric(ReadOnlySpan<byte> value) => BitOperations.ToSByte(value);
            bool INumericBitConverter<ClampedSByte>.TryWriteBytes(Span<byte> destination, ClampedSByte value) => BitOperations.TryWriteSByte(destination, value);
#endif

            bool IConvert<ClampedSByte>.ToBoolean(ClampedSByte value) => value._value != 0;
            byte IConvert<ClampedSByte>.ToByte(ClampedSByte value, Conversion mode) => ConvertN.ToByte(value._value, mode.Clamped());
            decimal IConvert<ClampedSByte>.ToDecimal(ClampedSByte value, Conversion mode) => ConvertN.ToDecimal(value._value, mode.Clamped());
            double IConvert<ClampedSByte>.ToDouble(ClampedSByte value, Conversion mode) => ConvertN.ToDouble(value._value, mode.Clamped());
            float IConvert<ClampedSByte>.ToSingle(ClampedSByte value, Conversion mode) => ConvertN.ToSingle(value._value, mode.Clamped());
            int IConvert<ClampedSByte>.ToInt32(ClampedSByte value, Conversion mode) => ConvertN.ToInt32(value._value, mode.Clamped());
            long IConvert<ClampedSByte>.ToInt64(ClampedSByte value, Conversion mode) => ConvertN.ToInt64(value._value, mode.Clamped());
            sbyte IConvertExtended<ClampedSByte>.ToSByte(ClampedSByte value, Conversion mode) => value._value;
            short IConvert<ClampedSByte>.ToInt16(ClampedSByte value, Conversion mode) => ConvertN.ToInt16(value._value, mode.Clamped());
            string IConvert<ClampedSByte>.ToString(ClampedSByte value) => Convert.ToString(value._value);
            uint IConvertExtended<ClampedSByte>.ToUInt32(ClampedSByte value, Conversion mode) => ConvertN.ToUInt32(value._value, mode.Clamped());
            ulong IConvertExtended<ClampedSByte>.ToUInt64(ClampedSByte value, Conversion mode) => ConvertN.ToUInt64(value._value, mode.Clamped());
            ushort IConvertExtended<ClampedSByte>.ToUInt16(ClampedSByte value, Conversion mode) => ConvertN.ToUInt16(value._value, mode.Clamped());

            ClampedSByte IConvert<ClampedSByte>.ToNumeric(bool value) => value ? (sbyte)1 : (sbyte)0;
            ClampedSByte IConvert<ClampedSByte>.ToNumeric(byte value, Conversion mode) => ConvertN.ToSByte(value, mode.Clamped());
            ClampedSByte IConvert<ClampedSByte>.ToNumeric(decimal value, Conversion mode) => ConvertN.ToSByte(value, mode.Clamped());
            ClampedSByte IConvert<ClampedSByte>.ToNumeric(double value, Conversion mode) => ConvertN.ToSByte(value, mode.Clamped());
            ClampedSByte IConvert<ClampedSByte>.ToNumeric(float value, Conversion mode) => ConvertN.ToSByte(value, mode.Clamped());
            ClampedSByte IConvert<ClampedSByte>.ToNumeric(int value, Conversion mode) => ConvertN.ToSByte(value, mode.Clamped());
            ClampedSByte IConvert<ClampedSByte>.ToNumeric(long value, Conversion mode) => ConvertN.ToSByte(value, mode.Clamped());
            ClampedSByte IConvertExtended<ClampedSByte>.ToValue(sbyte value, Conversion mode) => value;
            ClampedSByte IConvert<ClampedSByte>.ToNumeric(short value, Conversion mode) => ConvertN.ToSByte(value, mode.Clamped());
            ClampedSByte IConvert<ClampedSByte>.ToNumeric(string value) => Convert.ToSByte(value);
            ClampedSByte IConvertExtended<ClampedSByte>.ToNumeric(uint value, Conversion mode) => ConvertN.ToSByte(value, mode.Clamped());
            ClampedSByte IConvertExtended<ClampedSByte>.ToNumeric(ulong value, Conversion mode) => ConvertN.ToSByte(value, mode.Clamped());
            ClampedSByte IConvertExtended<ClampedSByte>.ToNumeric(ushort value, Conversion mode) => ConvertN.ToSByte(value, mode.Clamped());

            ClampedSByte INumericStatic<ClampedSByte>.Parse(string s, NumberStyles? style, IFormatProvider? provider)
                => Parse(s, style ?? NumberStyles.Integer, provider);

            ClampedSByte INumericRandom<ClampedSByte>.Generate(Random random) => random.NextSByte();
            ClampedSByte INumericRandom<ClampedSByte>.Generate(Random random, ClampedSByte maxValue) => random.NextSByte(maxValue);
            ClampedSByte INumericRandom<ClampedSByte>.Generate(Random random, ClampedSByte minValue, ClampedSByte maxValue) => random.NextSByte(minValue, maxValue);
            ClampedSByte INumericRandom<ClampedSByte>.Generate(Random random, Generation mode) => random.NextSByte(mode);
            ClampedSByte INumericRandom<ClampedSByte>.Generate(Random random, ClampedSByte minValue, ClampedSByte maxValue, Generation mode) => random.NextSByte(minValue, maxValue, mode);

            ClampedSByte IVariantRandom<ClampedSByte>.Generate(Random random, Variants variants) => random.NextSByte(variants);
        }
    }
}
