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
    /// Represents a 32-bit unsigned integer that cannot overflow.
    /// </summary>
    [Serializable]
    [DebuggerDisplay("{ToString(),nq}")]
    public readonly struct ClampedUInt32 : INumericExtended<ClampedUInt32>
    {
        public static readonly ClampedUInt32 MaxValue = new ClampedUInt32(uint.MaxValue);
        public static readonly ClampedUInt32 MinValue = new ClampedUInt32(uint.MinValue);

        private readonly uint _value;

        private ClampedUInt32(uint value)
        {
            _value = value;
        }

        private ClampedUInt32(SerializationInfo info, StreamingContext context) : this(info.GetUInt32(nameof(ClampedUInt32))) { }
        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context) => info.AddValue(nameof(ClampedUInt32), _value);

        public int CompareTo(object? obj) => obj is ClampedUInt32 other ? CompareTo(other) : 1;
        public int CompareTo(ClampedUInt32 other) => _value.CompareTo(other._value);
        public bool Equals(ClampedUInt32 other) => _value == other._value;
        public override bool Equals(object? obj) => obj is ClampedUInt32 other && Equals(other);
        public override int GetHashCode() => _value.GetHashCode();
        public override string ToString() => _value.ToString();
        public string ToString(IFormatProvider? provider) => _value.ToString(provider);
        public string ToString(string format) => _value.ToString(format);
        public string ToString(string? format, IFormatProvider? formatProvider) => _value.ToString(format, formatProvider);

        public static bool TryParse(string s, IFormatProvider? provider, out ClampedUInt32 result) => FuncExtensions.Try(() => Parse(s, provider), out result);
        public static bool TryParse(string s, NumberStyles style, IFormatProvider? provider, out ClampedUInt32 result) => FuncExtensions.Try(() => Parse(s, style, provider), out result);
        public static bool TryParse(string s, NumberStyles style, out ClampedUInt32 result) => FuncExtensions.Try(() => Parse(s, style), out result);
        public static bool TryParse(string s, out ClampedUInt32 result) => FuncExtensions.Try(() => Parse(s), out result);
        public static ClampedUInt32 Parse(string s) => uint.Parse(s);
        public static ClampedUInt32 Parse(string s, IFormatProvider? provider) => uint.Parse(s, provider);
        public static ClampedUInt32 Parse(string s, NumberStyles style) => uint.Parse(s, style);
        public static ClampedUInt32 Parse(string s, NumberStyles style, IFormatProvider? provider) => uint.Parse(s, style, provider);

        [CLSCompliant(false)] public static explicit operator ClampedUInt32(sbyte value) => new ClampedUInt32(ConvertN.ToUInt32(value, Conversion.CastClamp));
        [CLSCompliant(false)] public static explicit operator ClampedUInt32(ulong value) => new ClampedUInt32(ConvertN.ToUInt32(value, Conversion.CastClamp));
        [CLSCompliant(false)] public static implicit operator ClampedUInt32(uint value) => new ClampedUInt32(value);
        [CLSCompliant(false)] public static implicit operator ClampedUInt32(ushort value) => new ClampedUInt32(value);
        public static explicit operator ClampedUInt32(decimal value) => new ClampedUInt32(ConvertN.ToUInt32(value, Conversion.CastClamp));
        public static explicit operator ClampedUInt32(double value) => new ClampedUInt32(ConvertN.ToUInt32(value, Conversion.CastClamp));
        public static explicit operator ClampedUInt32(float value) => new ClampedUInt32(ConvertN.ToUInt32(value, Conversion.CastClamp));
        public static explicit operator ClampedUInt32(int value) => new ClampedUInt32(ConvertN.ToUInt32(value, Conversion.CastClamp));
        public static explicit operator ClampedUInt32(long value) => new ClampedUInt32(ConvertN.ToUInt32(value, Conversion.CastClamp));
        public static explicit operator ClampedUInt32(short value) => new ClampedUInt32(ConvertN.ToUInt32(value, Conversion.CastClamp));
        public static implicit operator ClampedUInt32(byte value) => new ClampedUInt32(value);

        [CLSCompliant(false)] public static explicit operator sbyte(ClampedUInt32 value) => ConvertN.ToSByte(value._value, Conversion.CastClamp);
        [CLSCompliant(false)] public static explicit operator ushort(ClampedUInt32 value) => ConvertN.ToUInt16(value._value, Conversion.CastClamp);
        [CLSCompliant(false)] public static implicit operator uint(ClampedUInt32 value) => value._value;
        [CLSCompliant(false)] public static implicit operator ulong(ClampedUInt32 value) => value._value;
        public static explicit operator byte(ClampedUInt32 value) => ConvertN.ToByte(value._value, Conversion.CastClamp);
        public static explicit operator int(ClampedUInt32 value) => ConvertN.ToInt32(value._value, Conversion.CastClamp);
        public static explicit operator short(ClampedUInt32 value) => ConvertN.ToInt16(value._value, Conversion.CastClamp);
        public static implicit operator decimal(ClampedUInt32 value) => value._value;
        public static implicit operator double(ClampedUInt32 value) => value._value;
        public static implicit operator float(ClampedUInt32 value) => value._value;
        public static implicit operator long(ClampedUInt32 value) => value._value;

        public static bool operator !=(ClampedUInt32 left, ClampedUInt32 right) => left._value != right._value;
        public static bool operator <(ClampedUInt32 left, ClampedUInt32 right) => left._value < right._value;
        public static bool operator <=(ClampedUInt32 left, ClampedUInt32 right) => left._value <= right._value;
        public static bool operator ==(ClampedUInt32 left, ClampedUInt32 right) => left._value == right._value;
        public static bool operator >(ClampedUInt32 left, ClampedUInt32 right) => left._value > right._value;
        public static bool operator >=(ClampedUInt32 left, ClampedUInt32 right) => left._value >= right._value;
        public static ClampedUInt32 operator %(ClampedUInt32 left, ClampedUInt32 right) => ClampedArithmetic.Remainder(left._value, right._value);
        public static ClampedUInt32 operator &(ClampedUInt32 left, ClampedUInt32 right) => left._value & right._value;
        public static ClampedUInt32 operator -(ClampedUInt32 _) => MinValue;
        public static ClampedUInt32 operator -(ClampedUInt32 left, ClampedUInt32 right) => ClampedArithmetic.Subtract(left._value, right._value);
        public static ClampedUInt32 operator --(ClampedUInt32 value) => value - 1;
        public static ClampedUInt32 operator *(ClampedUInt32 left, ClampedUInt32 right) => ClampedArithmetic.Multiply(left._value, right._value);
        public static ClampedUInt32 operator /(ClampedUInt32 left, ClampedUInt32 right) => ClampedArithmetic.Divide(left._value, right._value);
        public static ClampedUInt32 operator ^(ClampedUInt32 left, ClampedUInt32 right) => left._value ^ right._value;
        public static ClampedUInt32 operator |(ClampedUInt32 left, ClampedUInt32 right) => left._value | right._value;
        public static ClampedUInt32 operator ~(ClampedUInt32 value) => ~value._value;
        public static ClampedUInt32 operator +(ClampedUInt32 left, ClampedUInt32 right) => ClampedArithmetic.Add(left._value, right._value);
        public static ClampedUInt32 operator +(ClampedUInt32 value) => value;
        public static ClampedUInt32 operator ++(ClampedUInt32 value) => value + 1;
        public static ClampedUInt32 operator <<(ClampedUInt32 left, int right) => left._value << right;
        public static ClampedUInt32 operator >>(ClampedUInt32 left, int right) => left._value >> right;

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
        short IConvertible.ToInt16(IFormatProvider? provider) => ConvertN.ToInt16(_value, Conversion.Clamp);
        uint IConvertible.ToUInt32(IFormatProvider? provider) => _value;
        ulong IConvertible.ToUInt64(IFormatProvider? provider) => ConvertN.ToUInt64(_value, Conversion.Clamp);
        ushort IConvertible.ToUInt16(IFormatProvider? provider) => ConvertN.ToUInt16(_value, Conversion.Clamp);
        object IConvertible.ToType(Type conversionType, IFormatProvider? provider) => this.ToTypeDefault(conversionType, provider);

        bool INumeric<ClampedUInt32>.IsGreaterThan(ClampedUInt32 value) => this > value;
        bool INumeric<ClampedUInt32>.IsGreaterThanOrEqualTo(ClampedUInt32 value) => this >= value;
        bool INumeric<ClampedUInt32>.IsLessThan(ClampedUInt32 value) => this < value;
        bool INumeric<ClampedUInt32>.IsLessThanOrEqualTo(ClampedUInt32 value) => this <= value;
        ClampedUInt32 INumeric<ClampedUInt32>.Add(ClampedUInt32 value) => this + value;
        ClampedUInt32 INumeric<ClampedUInt32>.BitwiseComplement() => ~this;
        ClampedUInt32 INumeric<ClampedUInt32>.Divide(ClampedUInt32 value) => this / value;
        ClampedUInt32 INumeric<ClampedUInt32>.LeftShift(int count) => this << count;
        ClampedUInt32 INumeric<ClampedUInt32>.LogicalAnd(ClampedUInt32 value) => this & value;
        ClampedUInt32 INumeric<ClampedUInt32>.LogicalExclusiveOr(ClampedUInt32 value) => this ^ value;
        ClampedUInt32 INumeric<ClampedUInt32>.LogicalOr(ClampedUInt32 value) => this | value;
        ClampedUInt32 INumeric<ClampedUInt32>.Multiply(ClampedUInt32 value) => this * value;
        ClampedUInt32 INumeric<ClampedUInt32>.Negative() => -this;
        ClampedUInt32 INumeric<ClampedUInt32>.Positive() => +this;
        ClampedUInt32 INumeric<ClampedUInt32>.Remainder(ClampedUInt32 value) => this % value;
        ClampedUInt32 INumeric<ClampedUInt32>.RightShift(int count) => this >> count;
        ClampedUInt32 INumeric<ClampedUInt32>.Subtract(ClampedUInt32 value) => this - value;

        INumericBitConverter<ClampedUInt32> IProvider<INumericBitConverter<ClampedUInt32>>.GetInstance() => Utilities.Instance;
        IBinaryIO<ClampedUInt32> IProvider<IBinaryIO<ClampedUInt32>>.GetInstance() => Utilities.Instance;
        IConvert<ClampedUInt32> IProvider<IConvert<ClampedUInt32>>.GetInstance() => Utilities.Instance;
        IConvertExtended<ClampedUInt32> IProvider<IConvertExtended<ClampedUInt32>>.GetInstance() => Utilities.Instance;
        IMath<ClampedUInt32> IProvider<IMath<ClampedUInt32>>.GetInstance() => Utilities.Instance;
        INumericRandom<ClampedUInt32> IProvider<INumericRandom<ClampedUInt32>>.GetInstance() => Utilities.Instance;
        INumericStatic<ClampedUInt32> IProvider<INumericStatic<ClampedUInt32>>.GetInstance() => Utilities.Instance;
        IVariantRandom<ClampedUInt32> IProvider<IVariantRandom<ClampedUInt32>>.GetInstance() => Utilities.Instance;

        private sealed class Utilities :
            IBinaryIO<ClampedUInt32>,
            IConvert<ClampedUInt32>,
            IConvertExtended<ClampedUInt32>,
            IMath<ClampedUInt32>,
            INumericBitConverter<ClampedUInt32>,
            INumericRandom<ClampedUInt32>,
            INumericStatic<ClampedUInt32>,
            IVariantRandom<ClampedUInt32>
        {
            public static readonly Utilities Instance = new Utilities();

            void IBinaryIO<ClampedUInt32>.Write(BinaryWriter writer, ClampedUInt32 value) => writer.Write(value);
            ClampedUInt32 IBinaryIO<ClampedUInt32>.Read(BinaryReader reader) => reader.ReadUInt32();

            bool INumericStatic<ClampedUInt32>.HasFloatingPoint => false;
            bool INumericStatic<ClampedUInt32>.HasInfinity => false;
            bool INumericStatic<ClampedUInt32>.HasNaN => false;
            bool INumericStatic<ClampedUInt32>.IsFinite(ClampedUInt32 x) => true;
            bool INumericStatic<ClampedUInt32>.IsInfinity(ClampedUInt32 x) => false;
            bool INumericStatic<ClampedUInt32>.IsNaN(ClampedUInt32 x) => false;
            bool INumericStatic<ClampedUInt32>.IsNegative(ClampedUInt32 x) => false;
            bool INumericStatic<ClampedUInt32>.IsNegativeInfinity(ClampedUInt32 x) => false;
            bool INumericStatic<ClampedUInt32>.IsNormal(ClampedUInt32 x) => false;
            bool INumericStatic<ClampedUInt32>.IsPositiveInfinity(ClampedUInt32 x) => false;
            bool INumericStatic<ClampedUInt32>.IsReal => false;
            bool INumericStatic<ClampedUInt32>.IsSigned => false;
            bool INumericStatic<ClampedUInt32>.IsSubnormal(ClampedUInt32 x) => false;
            ClampedUInt32 INumericStatic<ClampedUInt32>.Epsilon => 1;
            ClampedUInt32 INumericStatic<ClampedUInt32>.MaxUnit => 1;
            ClampedUInt32 INumericStatic<ClampedUInt32>.MaxValue => MaxValue;
            ClampedUInt32 INumericStatic<ClampedUInt32>.MinUnit => 0;
            ClampedUInt32 INumericStatic<ClampedUInt32>.MinValue => MinValue;
            ClampedUInt32 INumericStatic<ClampedUInt32>.One => 1;
            ClampedUInt32 INumericStatic<ClampedUInt32>.Zero => 0;

            int IMath<ClampedUInt32>.Sign(ClampedUInt32 x) => x._value == 0 ? 0 : 1;
            ClampedUInt32 IMath<ClampedUInt32>.Abs(ClampedUInt32 value) => value;
            ClampedUInt32 IMath<ClampedUInt32>.Acos(ClampedUInt32 x) => (ClampedUInt32)Math.Acos(x._value);
            ClampedUInt32 IMath<ClampedUInt32>.Acosh(ClampedUInt32 x) => (ClampedUInt32)MathShim.Acosh(x._value);
            ClampedUInt32 IMath<ClampedUInt32>.Asin(ClampedUInt32 x) => (ClampedUInt32)Math.Asin(x._value);
            ClampedUInt32 IMath<ClampedUInt32>.Asinh(ClampedUInt32 x) => (ClampedUInt32)MathShim.Asinh(x._value);
            ClampedUInt32 IMath<ClampedUInt32>.Atan(ClampedUInt32 x) => (ClampedUInt32)Math.Atan(x._value);
            ClampedUInt32 IMath<ClampedUInt32>.Atan2(ClampedUInt32 x, ClampedUInt32 y) => (ClampedUInt32)Math.Atan2(x._value, y._value);
            ClampedUInt32 IMath<ClampedUInt32>.Atanh(ClampedUInt32 x) => (ClampedUInt32)MathShim.Atanh(x._value);
            ClampedUInt32 IMath<ClampedUInt32>.Cbrt(ClampedUInt32 x) => (ClampedUInt32)MathShim.Cbrt(x._value);
            ClampedUInt32 IMath<ClampedUInt32>.Ceiling(ClampedUInt32 x) => x;
            ClampedUInt32 IMath<ClampedUInt32>.Clamp(ClampedUInt32 x, ClampedUInt32 bound1, ClampedUInt32 bound2) => bound1 > bound2 ? Math.Min(bound1._value, Math.Max(bound2._value, x._value)) : Math.Min(bound2._value, Math.Max(bound1._value, x._value));
            ClampedUInt32 IMath<ClampedUInt32>.Cos(ClampedUInt32 x) => (ClampedUInt32)Math.Cos(x._value);
            ClampedUInt32 IMath<ClampedUInt32>.Cosh(ClampedUInt32 x) => (ClampedUInt32)Math.Cosh(x._value);
            ClampedUInt32 IMath<ClampedUInt32>.E { get; } = 2;
            ClampedUInt32 IMath<ClampedUInt32>.Exp(ClampedUInt32 x) => (ClampedUInt32)Math.Exp(x._value);
            ClampedUInt32 IMath<ClampedUInt32>.Floor(ClampedUInt32 x) => x;
            ClampedUInt32 IMath<ClampedUInt32>.IEEERemainder(ClampedUInt32 x, ClampedUInt32 y) => (ClampedUInt32)Math.IEEERemainder(x._value, y._value);
            ClampedUInt32 IMath<ClampedUInt32>.Log(ClampedUInt32 x) => (ClampedUInt32)Math.Log(x._value);
            ClampedUInt32 IMath<ClampedUInt32>.Log(ClampedUInt32 x, ClampedUInt32 y) => (ClampedUInt32)Math.Log(x._value, y._value);
            ClampedUInt32 IMath<ClampedUInt32>.Log10(ClampedUInt32 x) => (ClampedUInt32)Math.Log10(x._value);
            ClampedUInt32 IMath<ClampedUInt32>.Max(ClampedUInt32 x, ClampedUInt32 y) => Math.Max(x._value, y._value);
            ClampedUInt32 IMath<ClampedUInt32>.Min(ClampedUInt32 x, ClampedUInt32 y) => Math.Min(x._value, y._value);
            ClampedUInt32 IMath<ClampedUInt32>.PI { get; } = 3;
            ClampedUInt32 IMath<ClampedUInt32>.Pow(ClampedUInt32 x, ClampedUInt32 y) => ClampedArithmetic.Pow(x._value, y._value);
            ClampedUInt32 IMath<ClampedUInt32>.Round(ClampedUInt32 x) => x;
            ClampedUInt32 IMath<ClampedUInt32>.Round(ClampedUInt32 x, int digits) => x;
            ClampedUInt32 IMath<ClampedUInt32>.Round(ClampedUInt32 x, int digits, MidpointRounding mode) => x;
            ClampedUInt32 IMath<ClampedUInt32>.Round(ClampedUInt32 x, MidpointRounding mode) => x;
            ClampedUInt32 IMath<ClampedUInt32>.Sin(ClampedUInt32 x) => (ClampedUInt32)Math.Sin(x._value);
            ClampedUInt32 IMath<ClampedUInt32>.Sinh(ClampedUInt32 x) => (ClampedUInt32)Math.Sinh(x._value);
            ClampedUInt32 IMath<ClampedUInt32>.Sqrt(ClampedUInt32 x) => (ClampedUInt32)Math.Sqrt(x._value);
            ClampedUInt32 IMath<ClampedUInt32>.Tan(ClampedUInt32 x) => (ClampedUInt32)Math.Tan(x._value);
            ClampedUInt32 IMath<ClampedUInt32>.Tanh(ClampedUInt32 x) => (ClampedUInt32)Math.Tanh(x._value);
            ClampedUInt32 IMath<ClampedUInt32>.Tau { get; } = 6;
            ClampedUInt32 IMath<ClampedUInt32>.Truncate(ClampedUInt32 x) => x;

            int INumericBitConverter<ClampedUInt32>.ConvertedSize => sizeof(uint);
            ClampedUInt32 INumericBitConverter<ClampedUInt32>.ToNumeric(byte[] value, int startIndex) => BitConverter.ToUInt32(value, startIndex);
            byte[] INumericBitConverter<ClampedUInt32>.GetBytes(ClampedUInt32 value) => BitConverter.GetBytes(value._value);
#if HAS_SPANS
            ClampedUInt32 INumericBitConverter<ClampedUInt32>.ToNumeric(ReadOnlySpan<byte> value) => BitConverter.ToUInt32(value);
            bool INumericBitConverter<ClampedUInt32>.TryWriteBytes(Span<byte> destination, ClampedUInt32 value) => BitConverter.TryWriteBytes(destination, value);
#endif

            bool IConvert<ClampedUInt32>.ToBoolean(ClampedUInt32 value) => value._value != 0;
            byte IConvert<ClampedUInt32>.ToByte(ClampedUInt32 value, Conversion mode) => ConvertN.ToByte(value._value, mode.Clamped());
            decimal IConvert<ClampedUInt32>.ToDecimal(ClampedUInt32 value, Conversion mode) => ConvertN.ToDecimal(value._value, mode.Clamped());
            double IConvert<ClampedUInt32>.ToDouble(ClampedUInt32 value, Conversion mode) => ConvertN.ToDouble(value._value, mode.Clamped());
            float IConvert<ClampedUInt32>.ToSingle(ClampedUInt32 value, Conversion mode) => ConvertN.ToSingle(value._value, mode.Clamped());
            int IConvert<ClampedUInt32>.ToInt32(ClampedUInt32 value, Conversion mode) => ConvertN.ToInt32(value._value, mode.Clamped());
            long IConvert<ClampedUInt32>.ToInt64(ClampedUInt32 value, Conversion mode) => ConvertN.ToInt64(value._value, mode.Clamped());
            sbyte IConvertExtended<ClampedUInt32>.ToSByte(ClampedUInt32 value, Conversion mode) => ConvertN.ToSByte(value._value, mode.Clamped());
            short IConvert<ClampedUInt32>.ToInt16(ClampedUInt32 value, Conversion mode) => ConvertN.ToInt16(value._value, mode.Clamped());
            string IConvert<ClampedUInt32>.ToString(ClampedUInt32 value) => Convert.ToString(value._value);
            uint IConvertExtended<ClampedUInt32>.ToUInt32(ClampedUInt32 value, Conversion mode) => value._value;
            ulong IConvertExtended<ClampedUInt32>.ToUInt64(ClampedUInt32 value, Conversion mode) => ConvertN.ToUInt64(value._value, mode.Clamped());
            ushort IConvertExtended<ClampedUInt32>.ToUInt16(ClampedUInt32 value, Conversion mode) => ConvertN.ToUInt16(value._value, mode.Clamped());

            ClampedUInt32 IConvert<ClampedUInt32>.ToNumeric(bool value) => value ? 1 : (uint)0;
            ClampedUInt32 IConvert<ClampedUInt32>.ToNumeric(byte value, Conversion mode) => ConvertN.ToUInt32(value, mode.Clamped());
            ClampedUInt32 IConvert<ClampedUInt32>.ToNumeric(decimal value, Conversion mode) => ConvertN.ToUInt32(value, mode.Clamped());
            ClampedUInt32 IConvert<ClampedUInt32>.ToNumeric(double value, Conversion mode) => ConvertN.ToUInt32(value, mode.Clamped());
            ClampedUInt32 IConvert<ClampedUInt32>.ToNumeric(float value, Conversion mode) => ConvertN.ToUInt32(value, mode.Clamped());
            ClampedUInt32 IConvert<ClampedUInt32>.ToNumeric(int value, Conversion mode) => ConvertN.ToUInt32(value, mode.Clamped());
            ClampedUInt32 IConvert<ClampedUInt32>.ToNumeric(long value, Conversion mode) => ConvertN.ToUInt32(value, mode.Clamped());
            ClampedUInt32 IConvertExtended<ClampedUInt32>.ToValue(sbyte value, Conversion mode) => ConvertN.ToUInt32(value, mode.Clamped());
            ClampedUInt32 IConvert<ClampedUInt32>.ToNumeric(short value, Conversion mode) => ConvertN.ToUInt32(value, mode.Clamped());
            ClampedUInt32 IConvert<ClampedUInt32>.ToNumeric(string value) => Convert.ToUInt32(value);
            ClampedUInt32 IConvertExtended<ClampedUInt32>.ToNumeric(uint value, Conversion mode) => value;
            ClampedUInt32 IConvertExtended<ClampedUInt32>.ToNumeric(ulong value, Conversion mode) => ConvertN.ToUInt32(value, mode.Clamped());
            ClampedUInt32 IConvertExtended<ClampedUInt32>.ToNumeric(ushort value, Conversion mode) => ConvertN.ToUInt32(value, mode.Clamped());

            ClampedUInt32 INumericStatic<ClampedUInt32>.Parse(string s, NumberStyles? style, IFormatProvider? provider)
                => Parse(s, style ?? NumberStyles.Integer, provider);

            ClampedUInt32 INumericRandom<ClampedUInt32>.Generate(Random random) => random.NextUInt32();
            ClampedUInt32 INumericRandom<ClampedUInt32>.Generate(Random random, ClampedUInt32 maxValue) => random.NextUInt32(maxValue);
            ClampedUInt32 INumericRandom<ClampedUInt32>.Generate(Random random, ClampedUInt32 minValue, ClampedUInt32 maxValue) => random.NextUInt32(minValue, maxValue);
            ClampedUInt32 INumericRandom<ClampedUInt32>.Generate(Random random, Generation mode) => random.NextUInt32(mode);
            ClampedUInt32 INumericRandom<ClampedUInt32>.Generate(Random random, ClampedUInt32 minValue, ClampedUInt32 maxValue, Generation mode) => random.NextUInt32(minValue, maxValue, mode);

            ClampedUInt32 IVariantRandom<ClampedUInt32>.Generate(Random random, Variants variants) => random.NextUInt32(variants);
        }
    }
}
