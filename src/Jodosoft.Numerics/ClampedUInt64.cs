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
    /// Represents a 64-bit unsigned integer that cannot overflow.
    /// </summary>
    [Serializable]
    [DebuggerDisplay("{ToString(),nq}")]
    public readonly struct ClampedUInt64 : INumericExtended<ClampedUInt64>
    {
        public static readonly ClampedUInt64 MaxValue = new ClampedUInt64(ulong.MaxValue);
        public static readonly ClampedUInt64 MinValue = new ClampedUInt64(ulong.MinValue);

        private readonly ulong _value;

        private ClampedUInt64(ulong value)
        {
            _value = value;
        }

        private ClampedUInt64(SerializationInfo info, StreamingContext context) : this(info.GetUInt64(nameof(ClampedUInt64))) { }
        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context) => info.AddValue(nameof(ClampedUInt64), _value);

        public int CompareTo(object? obj) => obj is ClampedUInt64 other ? CompareTo(other) : 1;
        public int CompareTo(ClampedUInt64 other) => _value.CompareTo(other._value);
        public bool Equals(ClampedUInt64 other) => _value == other._value;
        public override bool Equals(object? obj) => obj is ClampedUInt64 other && Equals(other);
        public override int GetHashCode() => _value.GetHashCode();
        public override string ToString() => _value.ToString();
        public string ToString(IFormatProvider formatProvider) => _value.ToString(formatProvider);
        public string ToString(string format) => _value.ToString(format);
        public string ToString(string? format, IFormatProvider? formatProvider) => _value.ToString(format, formatProvider);

        public static bool TryParse(string s, IFormatProvider? provider, out ClampedUInt64 result) => FuncExtensions.Try(() => Parse(s, provider), out result);
        public static bool TryParse(string s, NumberStyles style, IFormatProvider? provider, out ClampedUInt64 result) => FuncExtensions.Try(() => Parse(s, style, provider), out result);
        public static bool TryParse(string s, NumberStyles style, out ClampedUInt64 result) => FuncExtensions.Try(() => Parse(s, style), out result);
        public static bool TryParse(string s, out ClampedUInt64 result) => FuncExtensions.Try(() => Parse(s), out result);
        public static ClampedUInt64 Parse(string s) => ulong.Parse(s);
        public static ClampedUInt64 Parse(string s, IFormatProvider? provider) => ulong.Parse(s, provider);
        public static ClampedUInt64 Parse(string s, NumberStyles style) => ulong.Parse(s, style);
        public static ClampedUInt64 Parse(string s, NumberStyles style, IFormatProvider? provider) => ulong.Parse(s, style, provider);

        [CLSCompliant(false)] public static explicit operator ClampedUInt64(sbyte value) => new ClampedUInt64(ConvertN.ToUInt64(value, Conversion.CastClamp));
        [CLSCompliant(false)] public static implicit operator ClampedUInt64(uint value) => new ClampedUInt64(value);
        [CLSCompliant(false)] public static implicit operator ClampedUInt64(ulong value) => new ClampedUInt64(value);
        [CLSCompliant(false)] public static implicit operator ClampedUInt64(ushort value) => new ClampedUInt64(value);
        public static explicit operator ClampedUInt64(decimal value) => new ClampedUInt64(ConvertN.ToUInt64(value, Conversion.CastClamp));
        public static explicit operator ClampedUInt64(double value) => new ClampedUInt64(ConvertN.ToUInt64(value, Conversion.CastClamp));
        public static explicit operator ClampedUInt64(float value) => new ClampedUInt64(ConvertN.ToUInt64(value, Conversion.CastClamp));
        public static explicit operator ClampedUInt64(int value) => new ClampedUInt64(ConvertN.ToUInt64(value, Conversion.CastClamp));
        public static explicit operator ClampedUInt64(long value) => new ClampedUInt64(ConvertN.ToUInt64(value, Conversion.CastClamp));
        public static explicit operator ClampedUInt64(short value) => new ClampedUInt64(ConvertN.ToUInt64(value, Conversion.CastClamp));
        public static implicit operator ClampedUInt64(byte value) => new ClampedUInt64(value);

        [CLSCompliant(false)] public static explicit operator sbyte(ClampedUInt64 value) => ConvertN.ToSByte(value._value, Conversion.CastClamp);
        [CLSCompliant(false)] public static explicit operator uint(ClampedUInt64 value) => ConvertN.ToUInt32(value._value, Conversion.CastClamp);
        [CLSCompliant(false)] public static explicit operator ushort(ClampedUInt64 value) => ConvertN.ToUInt16(value._value, Conversion.CastClamp);
        [CLSCompliant(false)] public static implicit operator ulong(ClampedUInt64 value) => value._value;
        public static explicit operator byte(ClampedUInt64 value) => ConvertN.ToByte(value._value, Conversion.CastClamp);
        public static explicit operator int(ClampedUInt64 value) => ConvertN.ToInt32(value._value, Conversion.CastClamp);
        public static explicit operator long(ClampedUInt64 value) => ConvertN.ToInt64(value._value, Conversion.CastClamp);
        public static explicit operator short(ClampedUInt64 value) => ConvertN.ToInt16(value._value, Conversion.CastClamp);
        public static implicit operator decimal(ClampedUInt64 value) => value._value;
        public static implicit operator double(ClampedUInt64 value) => value._value;
        public static implicit operator float(ClampedUInt64 value) => value._value;

        public static bool operator !=(ClampedUInt64 left, ClampedUInt64 right) => left._value != right._value;
        public static bool operator <(ClampedUInt64 left, ClampedUInt64 right) => left._value < right._value;
        public static bool operator <=(ClampedUInt64 left, ClampedUInt64 right) => left._value <= right._value;
        public static bool operator ==(ClampedUInt64 left, ClampedUInt64 right) => left._value == right._value;
        public static bool operator >(ClampedUInt64 left, ClampedUInt64 right) => left._value > right._value;
        public static bool operator >=(ClampedUInt64 left, ClampedUInt64 right) => left._value >= right._value;
        public static ClampedUInt64 operator %(ClampedUInt64 left, ClampedUInt64 right) => ClampedArithmetic.Remainder(left._value, right._value);
        public static ClampedUInt64 operator &(ClampedUInt64 left, ClampedUInt64 right) => left._value & right._value;
        public static ClampedUInt64 operator -(ClampedUInt64 _) => MinValue;
        public static ClampedUInt64 operator -(ClampedUInt64 left, ClampedUInt64 right) => ClampedArithmetic.Subtract(left._value, right._value);
        public static ClampedUInt64 operator --(ClampedUInt64 value) => value - 1;
        public static ClampedUInt64 operator *(ClampedUInt64 left, ClampedUInt64 right) => ClampedArithmetic.Multiply(left._value, right._value);
        public static ClampedUInt64 operator /(ClampedUInt64 left, ClampedUInt64 right) => ClampedArithmetic.Divide(left._value, right._value);
        public static ClampedUInt64 operator ^(ClampedUInt64 left, ClampedUInt64 right) => left._value ^ right._value;
        public static ClampedUInt64 operator |(ClampedUInt64 left, ClampedUInt64 right) => left._value | right._value;
        public static ClampedUInt64 operator ~(ClampedUInt64 value) => ~value._value;
        public static ClampedUInt64 operator +(ClampedUInt64 left, ClampedUInt64 right) => ClampedArithmetic.Add(left._value, right._value);
        public static ClampedUInt64 operator +(ClampedUInt64 value) => value;
        public static ClampedUInt64 operator ++(ClampedUInt64 value) => value + 1;
        public static ClampedUInt64 operator <<(ClampedUInt64 left, int right) => left._value << right;
        public static ClampedUInt64 operator >>(ClampedUInt64 left, int right) => left._value >> right;

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

        bool INumeric<ClampedUInt64>.IsGreaterThan(ClampedUInt64 value) => this > value;
        bool INumeric<ClampedUInt64>.IsGreaterThanOrEqualTo(ClampedUInt64 value) => this >= value;
        bool INumeric<ClampedUInt64>.IsLessThan(ClampedUInt64 value) => this < value;
        bool INumeric<ClampedUInt64>.IsLessThanOrEqualTo(ClampedUInt64 value) => this <= value;
        ClampedUInt64 INumeric<ClampedUInt64>.Add(ClampedUInt64 value) => this + value;
        ClampedUInt64 INumeric<ClampedUInt64>.BitwiseComplement() => ~this;
        ClampedUInt64 INumeric<ClampedUInt64>.Divide(ClampedUInt64 value) => this / value;
        ClampedUInt64 INumeric<ClampedUInt64>.LeftShift(int count) => this << count;
        ClampedUInt64 INumeric<ClampedUInt64>.LogicalAnd(ClampedUInt64 value) => this & value;
        ClampedUInt64 INumeric<ClampedUInt64>.LogicalExclusiveOr(ClampedUInt64 value) => this ^ value;
        ClampedUInt64 INumeric<ClampedUInt64>.LogicalOr(ClampedUInt64 value) => this | value;
        ClampedUInt64 INumeric<ClampedUInt64>.Multiply(ClampedUInt64 value) => this * value;
        ClampedUInt64 INumeric<ClampedUInt64>.Negative() => -this;
        ClampedUInt64 INumeric<ClampedUInt64>.Positive() => +this;
        ClampedUInt64 INumeric<ClampedUInt64>.Remainder(ClampedUInt64 value) => this % value;
        ClampedUInt64 INumeric<ClampedUInt64>.RightShift(int count) => this >> count;
        ClampedUInt64 INumeric<ClampedUInt64>.Subtract(ClampedUInt64 value) => this - value;

        INumericBitConverter<ClampedUInt64> IProvider<INumericBitConverter<ClampedUInt64>>.GetInstance() => Utilities.Instance;
        IBinaryIO<ClampedUInt64> IProvider<IBinaryIO<ClampedUInt64>>.GetInstance() => Utilities.Instance;
        IConvert<ClampedUInt64> IProvider<IConvert<ClampedUInt64>>.GetInstance() => Utilities.Instance;
        IConvertExtended<ClampedUInt64> IProvider<IConvertExtended<ClampedUInt64>>.GetInstance() => Utilities.Instance;
        IMath<ClampedUInt64> IProvider<IMath<ClampedUInt64>>.GetInstance() => Utilities.Instance;
        INumericRandom<ClampedUInt64> IProvider<INumericRandom<ClampedUInt64>>.GetInstance() => Utilities.Instance;
        INumericStatic<ClampedUInt64> IProvider<INumericStatic<ClampedUInt64>>.GetInstance() => Utilities.Instance;
        IVariantRandom<ClampedUInt64> IProvider<IVariantRandom<ClampedUInt64>>.GetInstance() => Utilities.Instance;

        private sealed class Utilities :
            IBinaryIO<ClampedUInt64>,
            IConvert<ClampedUInt64>,
            IConvertExtended<ClampedUInt64>,
            IMath<ClampedUInt64>,
            INumericBitConverter<ClampedUInt64>,
            INumericRandom<ClampedUInt64>,
            INumericStatic<ClampedUInt64>,
            IVariantRandom<ClampedUInt64>
        {
            public static readonly Utilities Instance = new Utilities();

            void IBinaryIO<ClampedUInt64>.Write(BinaryWriter writer, ClampedUInt64 value) => writer.Write(value);
            ClampedUInt64 IBinaryIO<ClampedUInt64>.Read(BinaryReader reader) => reader.ReadUInt64();

            bool INumericStatic<ClampedUInt64>.HasFloatingPoint => false;
            bool INumericStatic<ClampedUInt64>.HasInfinity => false;
            bool INumericStatic<ClampedUInt64>.HasNaN => false;
            bool INumericStatic<ClampedUInt64>.IsFinite(ClampedUInt64 x) => true;
            bool INumericStatic<ClampedUInt64>.IsInfinity(ClampedUInt64 x) => false;
            bool INumericStatic<ClampedUInt64>.IsNaN(ClampedUInt64 x) => false;
            bool INumericStatic<ClampedUInt64>.IsNegative(ClampedUInt64 x) => false;
            bool INumericStatic<ClampedUInt64>.IsNegativeInfinity(ClampedUInt64 x) => false;
            bool INumericStatic<ClampedUInt64>.IsNormal(ClampedUInt64 x) => false;
            bool INumericStatic<ClampedUInt64>.IsPositiveInfinity(ClampedUInt64 x) => false;
            bool INumericStatic<ClampedUInt64>.IsReal => false;
            bool INumericStatic<ClampedUInt64>.IsSigned => false;
            bool INumericStatic<ClampedUInt64>.IsSubnormal(ClampedUInt64 x) => false;
            ClampedUInt64 INumericStatic<ClampedUInt64>.Epsilon => 1;
            ClampedUInt64 INumericStatic<ClampedUInt64>.MaxUnit => 1;
            ClampedUInt64 INumericStatic<ClampedUInt64>.MaxValue => MaxValue;
            ClampedUInt64 INumericStatic<ClampedUInt64>.MinUnit => 0;
            ClampedUInt64 INumericStatic<ClampedUInt64>.MinValue => MinValue;
            ClampedUInt64 INumericStatic<ClampedUInt64>.One => 1;
            ClampedUInt64 INumericStatic<ClampedUInt64>.Zero => 0;

            int IMath<ClampedUInt64>.Sign(ClampedUInt64 x) => x._value == 0 ? 0 : 1;
            ClampedUInt64 IMath<ClampedUInt64>.Abs(ClampedUInt64 value) => value;
            ClampedUInt64 IMath<ClampedUInt64>.Acos(ClampedUInt64 x) => (ClampedUInt64)Math.Acos(x._value);
            ClampedUInt64 IMath<ClampedUInt64>.Acosh(ClampedUInt64 x) => (ClampedUInt64)MathShim.Acosh(x._value);
            ClampedUInt64 IMath<ClampedUInt64>.Asin(ClampedUInt64 x) => (ClampedUInt64)Math.Asin(x._value);
            ClampedUInt64 IMath<ClampedUInt64>.Asinh(ClampedUInt64 x) => (ClampedUInt64)MathShim.Asinh(x._value);
            ClampedUInt64 IMath<ClampedUInt64>.Atan(ClampedUInt64 x) => (ClampedUInt64)Math.Atan(x._value);
            ClampedUInt64 IMath<ClampedUInt64>.Atan2(ClampedUInt64 x, ClampedUInt64 y) => (ClampedUInt64)Math.Atan2(x._value, y._value);
            ClampedUInt64 IMath<ClampedUInt64>.Atanh(ClampedUInt64 x) => (ClampedUInt64)MathShim.Atanh(x._value);
            ClampedUInt64 IMath<ClampedUInt64>.Cbrt(ClampedUInt64 x) => (ClampedUInt64)MathShim.Cbrt(x._value);
            ClampedUInt64 IMath<ClampedUInt64>.Ceiling(ClampedUInt64 x) => x;
            ClampedUInt64 IMath<ClampedUInt64>.Clamp(ClampedUInt64 x, ClampedUInt64 bound1, ClampedUInt64 bound2) => bound1 > bound2 ? Math.Min(bound1._value, Math.Max(bound2._value, x._value)) : Math.Min(bound2._value, Math.Max(bound1._value, x._value));
            ClampedUInt64 IMath<ClampedUInt64>.Cos(ClampedUInt64 x) => (ClampedUInt64)Math.Cos(x._value);
            ClampedUInt64 IMath<ClampedUInt64>.Cosh(ClampedUInt64 x) => (ClampedUInt64)Math.Cosh(x._value);
            ClampedUInt64 IMath<ClampedUInt64>.E { get; } = 2;
            ClampedUInt64 IMath<ClampedUInt64>.Exp(ClampedUInt64 x) => (ClampedUInt64)Math.Exp(x._value);
            ClampedUInt64 IMath<ClampedUInt64>.Floor(ClampedUInt64 x) => x;
            ClampedUInt64 IMath<ClampedUInt64>.IEEERemainder(ClampedUInt64 x, ClampedUInt64 y) => (ClampedUInt64)Math.IEEERemainder(x._value, y._value);
            ClampedUInt64 IMath<ClampedUInt64>.Log(ClampedUInt64 x) => (ClampedUInt64)Math.Log(x._value);
            ClampedUInt64 IMath<ClampedUInt64>.Log(ClampedUInt64 x, ClampedUInt64 y) => (ClampedUInt64)Math.Log(x._value, y._value);
            ClampedUInt64 IMath<ClampedUInt64>.Log10(ClampedUInt64 x) => (ClampedUInt64)Math.Log10(x._value);
            ClampedUInt64 IMath<ClampedUInt64>.Max(ClampedUInt64 x, ClampedUInt64 y) => Math.Max(x._value, y._value);
            ClampedUInt64 IMath<ClampedUInt64>.Min(ClampedUInt64 x, ClampedUInt64 y) => Math.Min(x._value, y._value);
            ClampedUInt64 IMath<ClampedUInt64>.PI { get; } = 3;
            ClampedUInt64 IMath<ClampedUInt64>.Pow(ClampedUInt64 x, ClampedUInt64 y) => ClampedArithmetic.Pow(x._value, y._value);
            ClampedUInt64 IMath<ClampedUInt64>.Round(ClampedUInt64 x) => x;
            ClampedUInt64 IMath<ClampedUInt64>.Round(ClampedUInt64 x, int digits) => x;
            ClampedUInt64 IMath<ClampedUInt64>.Round(ClampedUInt64 x, int digits, MidpointRounding mode) => x;
            ClampedUInt64 IMath<ClampedUInt64>.Round(ClampedUInt64 x, MidpointRounding mode) => x;
            ClampedUInt64 IMath<ClampedUInt64>.Sin(ClampedUInt64 x) => (ClampedUInt64)Math.Sin(x._value);
            ClampedUInt64 IMath<ClampedUInt64>.Sinh(ClampedUInt64 x) => (ClampedUInt64)Math.Sinh(x._value);
            ClampedUInt64 IMath<ClampedUInt64>.Sqrt(ClampedUInt64 x) => (ClampedUInt64)Math.Sqrt(x._value);
            ClampedUInt64 IMath<ClampedUInt64>.Tan(ClampedUInt64 x) => (ClampedUInt64)Math.Tan(x._value);
            ClampedUInt64 IMath<ClampedUInt64>.Tanh(ClampedUInt64 x) => (ClampedUInt64)Math.Tanh(x._value);
            ClampedUInt64 IMath<ClampedUInt64>.Tau { get; } = 6;
            ClampedUInt64 IMath<ClampedUInt64>.Truncate(ClampedUInt64 x) => x;

            int INumericBitConverter<ClampedUInt64>.ConvertedSize => sizeof(ulong);
            ClampedUInt64 INumericBitConverter<ClampedUInt64>.ToNumeric(byte[] value, int startIndex) => BitConverter.ToUInt64(value, startIndex);
            byte[] INumericBitConverter<ClampedUInt64>.GetBytes(ClampedUInt64 value) => BitConverter.GetBytes(value._value);
#if HAS_SPANS
            ClampedUInt64 INumericBitConverter<ClampedUInt64>.ToNumeric(ReadOnlySpan<byte> value) => BitConverter.ToUInt64(value);
            bool INumericBitConverter<ClampedUInt64>.TryWriteBytes(Span<byte> destination, ClampedUInt64 value) => BitConverter.TryWriteBytes(destination, value);
#endif

            bool IConvert<ClampedUInt64>.ToBoolean(ClampedUInt64 value) => value._value != 0;
            byte IConvert<ClampedUInt64>.ToByte(ClampedUInt64 value, Conversion mode) => ConvertN.ToByte(value._value, mode.Clamped());
            decimal IConvert<ClampedUInt64>.ToDecimal(ClampedUInt64 value, Conversion mode) => ConvertN.ToDecimal(value._value, mode.Clamped());
            double IConvert<ClampedUInt64>.ToDouble(ClampedUInt64 value, Conversion mode) => ConvertN.ToDouble(value._value, mode.Clamped());
            float IConvert<ClampedUInt64>.ToSingle(ClampedUInt64 value, Conversion mode) => ConvertN.ToSingle(value._value, mode.Clamped());
            int IConvert<ClampedUInt64>.ToInt32(ClampedUInt64 value, Conversion mode) => ConvertN.ToInt32(value._value, mode.Clamped());
            long IConvert<ClampedUInt64>.ToInt64(ClampedUInt64 value, Conversion mode) => ConvertN.ToInt64(value._value, mode.Clamped());
            sbyte IConvertExtended<ClampedUInt64>.ToSByte(ClampedUInt64 value, Conversion mode) => ConvertN.ToSByte(value._value, mode.Clamped());
            short IConvert<ClampedUInt64>.ToInt16(ClampedUInt64 value, Conversion mode) => ConvertN.ToInt16(value._value, mode.Clamped());
            string IConvert<ClampedUInt64>.ToString(ClampedUInt64 value) => Convert.ToString(value._value);
            uint IConvertExtended<ClampedUInt64>.ToUInt32(ClampedUInt64 value, Conversion mode) => ConvertN.ToUInt32(value._value, mode.Clamped());
            ulong IConvertExtended<ClampedUInt64>.ToUInt64(ClampedUInt64 value, Conversion mode) => value._value;
            ushort IConvertExtended<ClampedUInt64>.ToUInt16(ClampedUInt64 value, Conversion mode) => ConvertN.ToUInt16(value._value, mode.Clamped());

            ClampedUInt64 IConvert<ClampedUInt64>.ToNumeric(bool value) => value ? 1 : (ulong)0;
            ClampedUInt64 IConvert<ClampedUInt64>.ToNumeric(byte value, Conversion mode) => ConvertN.ToUInt64(value, mode.Clamped());
            ClampedUInt64 IConvert<ClampedUInt64>.ToNumeric(decimal value, Conversion mode) => ConvertN.ToUInt64(value, mode.Clamped());
            ClampedUInt64 IConvert<ClampedUInt64>.ToNumeric(double value, Conversion mode) => ConvertN.ToUInt64(value, mode.Clamped());
            ClampedUInt64 IConvert<ClampedUInt64>.ToNumeric(float value, Conversion mode) => ConvertN.ToUInt64(value, mode.Clamped());
            ClampedUInt64 IConvert<ClampedUInt64>.ToNumeric(int value, Conversion mode) => ConvertN.ToUInt64(value, mode.Clamped());
            ClampedUInt64 IConvert<ClampedUInt64>.ToNumeric(long value, Conversion mode) => ConvertN.ToUInt64(value, mode.Clamped());
            ClampedUInt64 IConvertExtended<ClampedUInt64>.ToValue(sbyte value, Conversion mode) => ConvertN.ToUInt64(value, mode.Clamped());
            ClampedUInt64 IConvert<ClampedUInt64>.ToNumeric(short value, Conversion mode) => ConvertN.ToUInt64(value, mode.Clamped());
            ClampedUInt64 IConvert<ClampedUInt64>.ToNumeric(string value) => Convert.ToUInt64(value);
            ClampedUInt64 IConvertExtended<ClampedUInt64>.ToNumeric(uint value, Conversion mode) => ConvertN.ToUInt64(value, mode.Clamped());
            ClampedUInt64 IConvertExtended<ClampedUInt64>.ToNumeric(ulong value, Conversion mode) => value;
            ClampedUInt64 IConvertExtended<ClampedUInt64>.ToNumeric(ushort value, Conversion mode) => ConvertN.ToUInt64(value, mode.Clamped());

            ClampedUInt64 INumericStatic<ClampedUInt64>.Parse(string s, NumberStyles? style, IFormatProvider? provider)
                => Parse(s, style ?? NumberStyles.Integer, provider);

            ClampedUInt64 INumericRandom<ClampedUInt64>.Generate(Random random) => random.NextUInt64();
            ClampedUInt64 INumericRandom<ClampedUInt64>.Generate(Random random, ClampedUInt64 maxValue) => random.NextUInt64(maxValue);
            ClampedUInt64 INumericRandom<ClampedUInt64>.Generate(Random random, ClampedUInt64 minValue, ClampedUInt64 maxValue) => random.NextUInt64(minValue, maxValue);
            ClampedUInt64 INumericRandom<ClampedUInt64>.Generate(Random random, Generation mode) => random.NextUInt64(mode);
            ClampedUInt64 INumericRandom<ClampedUInt64>.Generate(Random random, ClampedUInt64 minValue, ClampedUInt64 maxValue, Generation mode) => random.NextUInt64(minValue, maxValue, mode);

            ClampedUInt64 IVariantRandom<ClampedUInt64>.Generate(Random random, Variants variants) => random.NextUInt64(variants);
        }
    }
}
