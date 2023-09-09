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
    /// Represents a 16-bit unsigned integer that cannot overflow.
    /// </summary>
    [Serializable]
    [DebuggerDisplay("{ToString(),nq}")]
    public readonly struct ClampedUInt16 : INumericExtended<ClampedUInt16>
    {
        public static readonly ClampedUInt16 MaxValue = new ClampedUInt16(ushort.MaxValue);
        public static readonly ClampedUInt16 MinValue = new ClampedUInt16(ushort.MinValue);

        private readonly ushort _value;

        private ClampedUInt16(ushort value)
        {
            _value = value;
        }

        private ClampedUInt16(SerializationInfo info, StreamingContext context) : this(info.GetUInt16(nameof(ClampedUInt16))) { }
        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context) => info.AddValue(nameof(ClampedUInt16), _value);

        public int CompareTo(object? obj) => obj is ClampedUInt16 other ? CompareTo(other) : 1;
        public int CompareTo(ClampedUInt16 other) => _value.CompareTo(other._value);
        public bool Equals(ClampedUInt16 other) => _value == other._value;
        public override bool Equals(object? obj) => obj is ClampedUInt16 other && Equals(other);
        public override int GetHashCode() => _value.GetHashCode();
        public override string ToString() => _value.ToString();
        public string ToString(IFormatProvider formatProvider) => _value.ToString(formatProvider);
        public string ToString(string format) => _value.ToString(format);
        public string ToString(string? format, IFormatProvider? formatProvider) => _value.ToString(format, formatProvider);

        public static bool TryParse(string s, IFormatProvider? provider, out ClampedUInt16 result) => FuncExtensions.Try(() => Parse(s, provider), out result);
        public static bool TryParse(string s, NumberStyles style, IFormatProvider? provider, out ClampedUInt16 result) => FuncExtensions.Try(() => Parse(s, style, provider), out result);
        public static bool TryParse(string s, NumberStyles style, out ClampedUInt16 result) => FuncExtensions.Try(() => Parse(s, style), out result);
        public static bool TryParse(string s, out ClampedUInt16 result) => FuncExtensions.Try(() => Parse(s), out result);
        public static ClampedUInt16 Parse(string s) => ushort.Parse(s);
        public static ClampedUInt16 Parse(string s, IFormatProvider? provider) => ushort.Parse(s, provider);
        public static ClampedUInt16 Parse(string s, NumberStyles style) => ushort.Parse(s, style);
        public static ClampedUInt16 Parse(string s, NumberStyles style, IFormatProvider? provider) => ushort.Parse(s, style, provider);

        [CLSCompliant(false)] public static explicit operator ClampedUInt16(sbyte value) => new ClampedUInt16(ConvertN.ToUInt16(value, Conversion.CastClamp));
        [CLSCompliant(false)] public static explicit operator ClampedUInt16(uint value) => new ClampedUInt16(ConvertN.ToUInt16(value, Conversion.CastClamp));
        [CLSCompliant(false)] public static explicit operator ClampedUInt16(ulong value) => new ClampedUInt16(ConvertN.ToUInt16(value, Conversion.CastClamp));
        [CLSCompliant(false)] public static implicit operator ClampedUInt16(ushort value) => new ClampedUInt16(value);
        public static explicit operator ClampedUInt16(decimal value) => new ClampedUInt16(ConvertN.ToUInt16(value, Conversion.CastClamp));
        public static explicit operator ClampedUInt16(double value) => new ClampedUInt16(ConvertN.ToUInt16(value, Conversion.CastClamp));
        public static explicit operator ClampedUInt16(float value) => new ClampedUInt16(ConvertN.ToUInt16(value, Conversion.CastClamp));
        public static explicit operator ClampedUInt16(int value) => new ClampedUInt16(ConvertN.ToUInt16(value, Conversion.CastClamp));
        public static explicit operator ClampedUInt16(long value) => new ClampedUInt16(ConvertN.ToUInt16(value, Conversion.CastClamp));
        public static explicit operator ClampedUInt16(short value) => new ClampedUInt16(ConvertN.ToUInt16(value, Conversion.CastClamp));
        public static implicit operator ClampedUInt16(byte value) => new ClampedUInt16(value);

        [CLSCompliant(false)] public static explicit operator sbyte(ClampedUInt16 value) => ConvertN.ToSByte(value._value, Conversion.CastClamp);
        [CLSCompliant(false)] public static implicit operator uint(ClampedUInt16 value) => value._value;
        [CLSCompliant(false)] public static implicit operator ulong(ClampedUInt16 value) => value._value;
        [CLSCompliant(false)] public static implicit operator ushort(ClampedUInt16 value) => value._value;
        public static explicit operator byte(ClampedUInt16 value) => ConvertN.ToByte(value._value, Conversion.CastClamp);
        public static explicit operator int(ClampedUInt16 value) => ConvertN.ToInt32(value._value, Conversion.CastClamp);
        public static explicit operator short(ClampedUInt16 value) => ConvertN.ToInt16(value._value, Conversion.CastClamp);
        public static implicit operator decimal(ClampedUInt16 value) => value._value;
        public static implicit operator double(ClampedUInt16 value) => value._value;
        public static implicit operator float(ClampedUInt16 value) => value._value;
        public static implicit operator long(ClampedUInt16 value) => value._value;

        public static bool operator !=(ClampedUInt16 left, ClampedUInt16 right) => left._value != right._value;
        public static bool operator <(ClampedUInt16 left, ClampedUInt16 right) => left._value < right._value;
        public static bool operator <=(ClampedUInt16 left, ClampedUInt16 right) => left._value <= right._value;
        public static bool operator ==(ClampedUInt16 left, ClampedUInt16 right) => left._value == right._value;
        public static bool operator >(ClampedUInt16 left, ClampedUInt16 right) => left._value > right._value;
        public static bool operator >=(ClampedUInt16 left, ClampedUInt16 right) => left._value >= right._value;
        public static ClampedUInt16 operator %(ClampedUInt16 left, ClampedUInt16 right) => ClampedArithmetic.Remainder(left._value, right._value);
        public static ClampedUInt16 operator &(ClampedUInt16 left, ClampedUInt16 right) => (ushort)(left._value & right._value);
        public static ClampedUInt16 operator -(ClampedUInt16 _) => MinValue;
        public static ClampedUInt16 operator -(ClampedUInt16 left, ClampedUInt16 right) => ClampedArithmetic.Subtract(left._value, right._value);
        public static ClampedUInt16 operator --(ClampedUInt16 value) => value - 1;
        public static ClampedUInt16 operator *(ClampedUInt16 left, ClampedUInt16 right) => ClampedArithmetic.Multiply(left._value, right._value);
        public static ClampedUInt16 operator /(ClampedUInt16 left, ClampedUInt16 right) => ClampedArithmetic.Divide(left._value, right._value);
        public static ClampedUInt16 operator ^(ClampedUInt16 left, ClampedUInt16 right) => (ushort)(left._value ^ right._value);
        public static ClampedUInt16 operator |(ClampedUInt16 left, ClampedUInt16 right) => (ushort)(left._value | right._value);
        public static ClampedUInt16 operator ~(ClampedUInt16 value) => (ushort)~value._value;
        public static ClampedUInt16 operator +(ClampedUInt16 left, ClampedUInt16 right) => ClampedArithmetic.Add(left._value, right._value);
        public static ClampedUInt16 operator +(ClampedUInt16 value) => value;
        public static ClampedUInt16 operator ++(ClampedUInt16 value) => value + 1;
        public static ClampedUInt16 operator <<(ClampedUInt16 left, int right) => (ushort)(left._value << right);
        public static ClampedUInt16 operator >>(ClampedUInt16 left, int right) => (ushort)(left._value >> right);

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
        ulong IConvertible.ToUInt64(IFormatProvider provider) => ConvertN.ToUInt64(_value, Conversion.Clamp);
        ushort IConvertible.ToUInt16(IFormatProvider provider) => _value;
        object IConvertible.ToType(Type conversionType, IFormatProvider provider) => this.ToTypeDefault(conversionType, provider);

        bool INumeric<ClampedUInt16>.IsGreaterThan(ClampedUInt16 value) => this > value;
        bool INumeric<ClampedUInt16>.IsGreaterThanOrEqualTo(ClampedUInt16 value) => this >= value;
        bool INumeric<ClampedUInt16>.IsLessThan(ClampedUInt16 value) => this < value;
        bool INumeric<ClampedUInt16>.IsLessThanOrEqualTo(ClampedUInt16 value) => this <= value;
        ClampedUInt16 INumeric<ClampedUInt16>.Add(ClampedUInt16 value) => this + value;
        ClampedUInt16 INumeric<ClampedUInt16>.BitwiseComplement() => ~this;
        ClampedUInt16 INumeric<ClampedUInt16>.Divide(ClampedUInt16 value) => this / value;
        ClampedUInt16 INumeric<ClampedUInt16>.LeftShift(int count) => this << count;
        ClampedUInt16 INumeric<ClampedUInt16>.LogicalAnd(ClampedUInt16 value) => this & value;
        ClampedUInt16 INumeric<ClampedUInt16>.LogicalExclusiveOr(ClampedUInt16 value) => this ^ value;
        ClampedUInt16 INumeric<ClampedUInt16>.LogicalOr(ClampedUInt16 value) => this | value;
        ClampedUInt16 INumeric<ClampedUInt16>.Multiply(ClampedUInt16 value) => this * value;
        ClampedUInt16 INumeric<ClampedUInt16>.Negative() => -this;
        ClampedUInt16 INumeric<ClampedUInt16>.Positive() => +this;
        ClampedUInt16 INumeric<ClampedUInt16>.Remainder(ClampedUInt16 value) => this % value;
        ClampedUInt16 INumeric<ClampedUInt16>.RightShift(int count) => this >> count;
        ClampedUInt16 INumeric<ClampedUInt16>.Subtract(ClampedUInt16 value) => this - value;

        INumericBitConverter<ClampedUInt16> IProvider<INumericBitConverter<ClampedUInt16>>.GetInstance() => Utilities.Instance;
        IBinaryIO<ClampedUInt16> IProvider<IBinaryIO<ClampedUInt16>>.GetInstance() => Utilities.Instance;
        IConvert<ClampedUInt16> IProvider<IConvert<ClampedUInt16>>.GetInstance() => Utilities.Instance;
        IConvertExtended<ClampedUInt16> IProvider<IConvertExtended<ClampedUInt16>>.GetInstance() => Utilities.Instance;
        IMath<ClampedUInt16> IProvider<IMath<ClampedUInt16>>.GetInstance() => Utilities.Instance;
        INumericRandom<ClampedUInt16> IProvider<INumericRandom<ClampedUInt16>>.GetInstance() => Utilities.Instance;
        INumericStatic<ClampedUInt16> IProvider<INumericStatic<ClampedUInt16>>.GetInstance() => Utilities.Instance;
        IVariantRandom<ClampedUInt16> IProvider<IVariantRandom<ClampedUInt16>>.GetInstance() => Utilities.Instance;

        private sealed class Utilities :
            IBinaryIO<ClampedUInt16>,
            IConvert<ClampedUInt16>,
            IConvertExtended<ClampedUInt16>,
            IMath<ClampedUInt16>,
            INumericBitConverter<ClampedUInt16>,
            INumericRandom<ClampedUInt16>,
            INumericStatic<ClampedUInt16>,
            IVariantRandom<ClampedUInt16>
        {
            public static readonly Utilities Instance = new Utilities();

            void IBinaryIO<ClampedUInt16>.Write(BinaryWriter writer, ClampedUInt16 value) => writer.Write(value);
            ClampedUInt16 IBinaryIO<ClampedUInt16>.Read(BinaryReader reader) => reader.ReadUInt16();

            bool INumericStatic<ClampedUInt16>.HasFloatingPoint => false;
            bool INumericStatic<ClampedUInt16>.HasInfinity => false;
            bool INumericStatic<ClampedUInt16>.HasNaN => false;
            bool INumericStatic<ClampedUInt16>.IsFinite(ClampedUInt16 x) => true;
            bool INumericStatic<ClampedUInt16>.IsInfinity(ClampedUInt16 x) => false;
            bool INumericStatic<ClampedUInt16>.IsNaN(ClampedUInt16 x) => false;
            bool INumericStatic<ClampedUInt16>.IsNegative(ClampedUInt16 x) => false;
            bool INumericStatic<ClampedUInt16>.IsNegativeInfinity(ClampedUInt16 x) => false;
            bool INumericStatic<ClampedUInt16>.IsNormal(ClampedUInt16 x) => false;
            bool INumericStatic<ClampedUInt16>.IsPositiveInfinity(ClampedUInt16 x) => false;
            bool INumericStatic<ClampedUInt16>.IsReal => false;
            bool INumericStatic<ClampedUInt16>.IsSigned => false;
            bool INumericStatic<ClampedUInt16>.IsSubnormal(ClampedUInt16 x) => false;
            ClampedUInt16 INumericStatic<ClampedUInt16>.Epsilon => 1;
            ClampedUInt16 INumericStatic<ClampedUInt16>.MaxUnit => 1;
            ClampedUInt16 INumericStatic<ClampedUInt16>.MaxValue => MaxValue;
            ClampedUInt16 INumericStatic<ClampedUInt16>.MinUnit => 0;
            ClampedUInt16 INumericStatic<ClampedUInt16>.MinValue => MinValue;
            ClampedUInt16 INumericStatic<ClampedUInt16>.One => 1;
            ClampedUInt16 INumericStatic<ClampedUInt16>.Zero => 0;

            int IMath<ClampedUInt16>.Sign(ClampedUInt16 x) => x._value == 0 ? 0 : 1;
            ClampedUInt16 IMath<ClampedUInt16>.Abs(ClampedUInt16 value) => value;
            ClampedUInt16 IMath<ClampedUInt16>.Acos(ClampedUInt16 x) => (ClampedUInt16)Math.Acos(x._value);
            ClampedUInt16 IMath<ClampedUInt16>.Acosh(ClampedUInt16 x) => (ClampedUInt16)MathShim.Acosh(x._value);
            ClampedUInt16 IMath<ClampedUInt16>.Asin(ClampedUInt16 x) => (ClampedUInt16)Math.Asin(x._value);
            ClampedUInt16 IMath<ClampedUInt16>.Asinh(ClampedUInt16 x) => (ClampedUInt16)MathShim.Asinh(x._value);
            ClampedUInt16 IMath<ClampedUInt16>.Atan(ClampedUInt16 x) => (ClampedUInt16)Math.Atan(x._value);
            ClampedUInt16 IMath<ClampedUInt16>.Atan2(ClampedUInt16 x, ClampedUInt16 y) => (ClampedUInt16)Math.Atan2(x._value, y._value);
            ClampedUInt16 IMath<ClampedUInt16>.Atanh(ClampedUInt16 x) => (ClampedUInt16)MathShim.Atanh(x._value);
            ClampedUInt16 IMath<ClampedUInt16>.Cbrt(ClampedUInt16 x) => (ClampedUInt16)MathShim.Cbrt(x._value);
            ClampedUInt16 IMath<ClampedUInt16>.Ceiling(ClampedUInt16 x) => x;
            ClampedUInt16 IMath<ClampedUInt16>.Clamp(ClampedUInt16 x, ClampedUInt16 bound1, ClampedUInt16 bound2) => bound1 > bound2 ? Math.Min(bound1._value, Math.Max(bound2._value, x._value)) : Math.Min(bound2._value, Math.Max(bound1._value, x._value));
            ClampedUInt16 IMath<ClampedUInt16>.Cos(ClampedUInt16 x) => (ClampedUInt16)Math.Cos(x._value);
            ClampedUInt16 IMath<ClampedUInt16>.Cosh(ClampedUInt16 x) => (ClampedUInt16)Math.Cosh(x._value);
            ClampedUInt16 IMath<ClampedUInt16>.E { get; } = 2;
            ClampedUInt16 IMath<ClampedUInt16>.Exp(ClampedUInt16 x) => (ClampedUInt16)Math.Exp(x._value);
            ClampedUInt16 IMath<ClampedUInt16>.Floor(ClampedUInt16 x) => x;
            ClampedUInt16 IMath<ClampedUInt16>.IEEERemainder(ClampedUInt16 x, ClampedUInt16 y) => (ClampedUInt16)Math.IEEERemainder(x._value, y._value);
            ClampedUInt16 IMath<ClampedUInt16>.Log(ClampedUInt16 x) => (ClampedUInt16)Math.Log(x._value);
            ClampedUInt16 IMath<ClampedUInt16>.Log(ClampedUInt16 x, ClampedUInt16 y) => (ClampedUInt16)Math.Log(x._value, y._value);
            ClampedUInt16 IMath<ClampedUInt16>.Log10(ClampedUInt16 x) => (ClampedUInt16)Math.Log10(x._value);
            ClampedUInt16 IMath<ClampedUInt16>.Max(ClampedUInt16 x, ClampedUInt16 y) => Math.Max(x._value, y._value);
            ClampedUInt16 IMath<ClampedUInt16>.Min(ClampedUInt16 x, ClampedUInt16 y) => Math.Min(x._value, y._value);
            ClampedUInt16 IMath<ClampedUInt16>.PI { get; } = 3;
            ClampedUInt16 IMath<ClampedUInt16>.Pow(ClampedUInt16 x, ClampedUInt16 y) => ClampedArithmetic.Pow(x._value, y._value);
            ClampedUInt16 IMath<ClampedUInt16>.Round(ClampedUInt16 x) => x;
            ClampedUInt16 IMath<ClampedUInt16>.Round(ClampedUInt16 x, int digits) => x;
            ClampedUInt16 IMath<ClampedUInt16>.Round(ClampedUInt16 x, int digits, MidpointRounding mode) => x;
            ClampedUInt16 IMath<ClampedUInt16>.Round(ClampedUInt16 x, MidpointRounding mode) => x;
            ClampedUInt16 IMath<ClampedUInt16>.Sin(ClampedUInt16 x) => (ClampedUInt16)Math.Sin(x._value);
            ClampedUInt16 IMath<ClampedUInt16>.Sinh(ClampedUInt16 x) => (ClampedUInt16)Math.Sinh(x._value);
            ClampedUInt16 IMath<ClampedUInt16>.Sqrt(ClampedUInt16 x) => (ClampedUInt16)Math.Sqrt(x._value);
            ClampedUInt16 IMath<ClampedUInt16>.Tan(ClampedUInt16 x) => (ClampedUInt16)Math.Tan(x._value);
            ClampedUInt16 IMath<ClampedUInt16>.Tanh(ClampedUInt16 x) => (ClampedUInt16)Math.Tanh(x._value);
            ClampedUInt16 IMath<ClampedUInt16>.Tau { get; } = 6;
            ClampedUInt16 IMath<ClampedUInt16>.Truncate(ClampedUInt16 x) => x;

            int INumericBitConverter<ClampedUInt16>.ConvertedSize => sizeof(ushort);
            ClampedUInt16 INumericBitConverter<ClampedUInt16>.ToNumeric(byte[] value, int startIndex) => BitConverter.ToUInt16(value, startIndex);
            byte[] INumericBitConverter<ClampedUInt16>.GetBytes(ClampedUInt16 value) => BitConverter.GetBytes(value._value);
#if HAS_SPANS
            ClampedUInt16 INumericBitConverter<ClampedUInt16>.ToNumeric(ReadOnlySpan<byte> value) => BitConverter.ToUInt16(value);
            bool INumericBitConverter<ClampedUInt16>.TryWriteBytes(Span<byte> destination, ClampedUInt16 value) => BitConverter.TryWriteBytes(destination, value);
#endif

            bool IConvert<ClampedUInt16>.ToBoolean(ClampedUInt16 value) => value._value != 0;
            byte IConvert<ClampedUInt16>.ToByte(ClampedUInt16 value, Conversion mode) => ConvertN.ToByte(value._value, mode.Clamped());
            decimal IConvert<ClampedUInt16>.ToDecimal(ClampedUInt16 value, Conversion mode) => ConvertN.ToDecimal(value._value, mode.Clamped());
            double IConvert<ClampedUInt16>.ToDouble(ClampedUInt16 value, Conversion mode) => ConvertN.ToDouble(value._value, mode.Clamped());
            float IConvert<ClampedUInt16>.ToSingle(ClampedUInt16 value, Conversion mode) => ConvertN.ToSingle(value._value, mode.Clamped());
            int IConvert<ClampedUInt16>.ToInt32(ClampedUInt16 value, Conversion mode) => ConvertN.ToInt32(value._value, mode.Clamped());
            long IConvert<ClampedUInt16>.ToInt64(ClampedUInt16 value, Conversion mode) => ConvertN.ToInt64(value._value, mode.Clamped());
            sbyte IConvertExtended<ClampedUInt16>.ToSByte(ClampedUInt16 value, Conversion mode) => ConvertN.ToSByte(value._value, mode.Clamped());
            short IConvert<ClampedUInt16>.ToInt16(ClampedUInt16 value, Conversion mode) => ConvertN.ToInt16(value._value, mode.Clamped());
            string IConvert<ClampedUInt16>.ToString(ClampedUInt16 value) => Convert.ToString(value._value);
            uint IConvertExtended<ClampedUInt16>.ToUInt32(ClampedUInt16 value, Conversion mode) => value._value;
            ulong IConvertExtended<ClampedUInt16>.ToUInt64(ClampedUInt16 value, Conversion mode) => ConvertN.ToUInt64(value._value, mode.Clamped());
            ushort IConvertExtended<ClampedUInt16>.ToUInt16(ClampedUInt16 value, Conversion mode) => ConvertN.ToUInt16(value._value, mode.Clamped());

            ClampedUInt16 IConvert<ClampedUInt16>.ToNumeric(bool value) => value ? (ushort)1 : (ushort)0;
            ClampedUInt16 IConvert<ClampedUInt16>.ToNumeric(byte value, Conversion mode) => ConvertN.ToUInt16(value, mode.Clamped());
            ClampedUInt16 IConvert<ClampedUInt16>.ToNumeric(decimal value, Conversion mode) => ConvertN.ToUInt16(value, mode.Clamped());
            ClampedUInt16 IConvert<ClampedUInt16>.ToNumeric(double value, Conversion mode) => ConvertN.ToUInt16(value, mode.Clamped());
            ClampedUInt16 IConvert<ClampedUInt16>.ToNumeric(float value, Conversion mode) => ConvertN.ToUInt16(value, mode.Clamped());
            ClampedUInt16 IConvert<ClampedUInt16>.ToNumeric(int value, Conversion mode) => ConvertN.ToUInt16(value, mode.Clamped());
            ClampedUInt16 IConvert<ClampedUInt16>.ToNumeric(long value, Conversion mode) => ConvertN.ToUInt16(value, mode.Clamped());
            ClampedUInt16 IConvertExtended<ClampedUInt16>.ToValue(sbyte value, Conversion mode) => ConvertN.ToUInt16(value, mode.Clamped());
            ClampedUInt16 IConvert<ClampedUInt16>.ToNumeric(short value, Conversion mode) => ConvertN.ToUInt16(value, mode.Clamped());
            ClampedUInt16 IConvert<ClampedUInt16>.ToNumeric(string value) => Convert.ToUInt16(value);
            ClampedUInt16 IConvertExtended<ClampedUInt16>.ToNumeric(uint value, Conversion mode) => ConvertN.ToUInt16(value, mode.Clamped());
            ClampedUInt16 IConvertExtended<ClampedUInt16>.ToNumeric(ulong value, Conversion mode) => ConvertN.ToUInt16(value, mode.Clamped());
            ClampedUInt16 IConvertExtended<ClampedUInt16>.ToNumeric(ushort value, Conversion mode) => value;

            ClampedUInt16 INumericStatic<ClampedUInt16>.Parse(string s, NumberStyles? style, IFormatProvider? provider)
                => Parse(s, style ?? NumberStyles.Integer, provider);

            ClampedUInt16 INumericRandom<ClampedUInt16>.Generate(Random random) => random.NextUInt16();
            ClampedUInt16 INumericRandom<ClampedUInt16>.Generate(Random random, ClampedUInt16 maxValue) => random.NextUInt16(maxValue);
            ClampedUInt16 INumericRandom<ClampedUInt16>.Generate(Random random, ClampedUInt16 minValue, ClampedUInt16 maxValue) => random.NextUInt16(minValue, maxValue);
            ClampedUInt16 INumericRandom<ClampedUInt16>.Generate(Random random, Generation mode) => random.NextUInt16(mode);
            ClampedUInt16 INumericRandom<ClampedUInt16>.Generate(Random random, ClampedUInt16 minValue, ClampedUInt16 maxValue, Generation mode) => random.NextUInt16(minValue, maxValue, mode);

            ClampedUInt16 IVariantRandom<ClampedUInt16>.Generate(Random random, Variants variants) => random.NextUInt16(variants);
        }
    }
}
