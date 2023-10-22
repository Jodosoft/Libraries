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
    public readonly struct ClampedInt64 : INumericExtended<ClampedInt64>
    {
        public static readonly ClampedInt64 MaxValue = new ClampedInt64(long.MaxValue);
        public static readonly ClampedInt64 MinValue = new ClampedInt64(long.MinValue);

        private readonly long _value;

        private ClampedInt64(long value)
        {
            _value = value;
        }

        private ClampedInt64(SerializationInfo info, StreamingContext context) : this(info.GetInt64(nameof(ClampedInt64))) { }
        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context) => info.AddValue(nameof(ClampedInt64), _value);

        public int CompareTo(ClampedInt64 other) => _value.CompareTo(other._value);
        public int CompareTo(object? obj) => obj is ClampedInt64 other ? CompareTo(other) : 1;
        public bool Equals(ClampedInt64 other) => _value == other._value;
        public override bool Equals(object? obj) => obj is ClampedInt64 other && Equals(other);
        public override int GetHashCode() => _value.GetHashCode();
        public override string ToString() => _value.ToString();
        public string ToString(IFormatProvider? provider) => _value.ToString(provider);
        public string ToString(string format) => _value.ToString(format);
        public string ToString(string? format, IFormatProvider? formatProvider) => _value.ToString(format, formatProvider);

        public static bool TryParse(string s, IFormatProvider? provider, out ClampedInt64 result) => FuncExtensions.Try(() => Parse(s, provider), out result);
        public static bool TryParse(string s, NumberStyles style, IFormatProvider? provider, out ClampedInt64 result) => FuncExtensions.Try(() => Parse(s, style, provider), out result);
        public static bool TryParse(string s, NumberStyles style, out ClampedInt64 result) => FuncExtensions.Try(() => Parse(s, style), out result);
        public static bool TryParse(string s, out ClampedInt64 result) => FuncExtensions.Try(() => Parse(s), out result);
        public static ClampedInt64 Parse(string s) => long.Parse(s);
        public static ClampedInt64 Parse(string s, IFormatProvider? provider) => long.Parse(s, provider);
        public static ClampedInt64 Parse(string s, NumberStyles style) => long.Parse(s, style);
        public static ClampedInt64 Parse(string s, NumberStyles style, IFormatProvider? provider) => long.Parse(s, style, provider);

        [CLSCompliant(false)] public static explicit operator ClampedInt64(ulong value) => new ClampedInt64(ConvertN.ToInt64(value, Conversion.CastClamp));
        [CLSCompliant(false)] public static implicit operator ClampedInt64(sbyte value) => new ClampedInt64(value);
        [CLSCompliant(false)] public static implicit operator ClampedInt64(uint value) => new ClampedInt64(value);
        [CLSCompliant(false)] public static implicit operator ClampedInt64(ushort value) => new ClampedInt64(value);
        public static explicit operator ClampedInt64(decimal value) => new ClampedInt64(ConvertN.ToInt64(value, Conversion.CastClamp));
        public static explicit operator ClampedInt64(double value) => new ClampedInt64(ConvertN.ToInt64(value, Conversion.CastClamp));
        public static explicit operator ClampedInt64(float value) => new ClampedInt64(ConvertN.ToInt64(value, Conversion.CastClamp));
        public static implicit operator ClampedInt64(byte value) => new ClampedInt64(value);
        public static implicit operator ClampedInt64(int value) => new ClampedInt64(value);
        public static implicit operator ClampedInt64(long value) => new ClampedInt64(value);
        public static implicit operator ClampedInt64(short value) => new ClampedInt64(value);

        [CLSCompliant(false)] public static explicit operator sbyte(ClampedInt64 value) => ConvertN.ToSByte(value._value, Conversion.CastClamp);
        [CLSCompliant(false)] public static explicit operator uint(ClampedInt64 value) => ConvertN.ToUInt32(value._value, Conversion.CastClamp);
        [CLSCompliant(false)] public static explicit operator ulong(ClampedInt64 value) => ConvertN.ToUInt64(value._value, Conversion.CastClamp);
        [CLSCompliant(false)] public static explicit operator ushort(ClampedInt64 value) => ConvertN.ToUInt16(value._value, Conversion.CastClamp);
        public static explicit operator byte(ClampedInt64 value) => ConvertN.ToByte(value._value, Conversion.CastClamp);
        public static explicit operator int(ClampedInt64 value) => ConvertN.ToInt32(value._value, Conversion.CastClamp);
        public static explicit operator short(ClampedInt64 value) => ConvertN.ToInt16(value._value, Conversion.CastClamp);
        public static implicit operator decimal(ClampedInt64 value) => value._value;
        public static implicit operator double(ClampedInt64 value) => value._value;
        public static implicit operator float(ClampedInt64 value) => value._value;
        public static implicit operator long(ClampedInt64 value) => value._value;

        public static bool operator !=(ClampedInt64 left, ClampedInt64 right) => left._value != right._value;
        public static bool operator <(ClampedInt64 left, ClampedInt64 right) => left._value < right._value;
        public static bool operator <=(ClampedInt64 left, ClampedInt64 right) => left._value <= right._value;
        public static bool operator ==(ClampedInt64 left, ClampedInt64 right) => left._value == right._value;
        public static bool operator >(ClampedInt64 left, ClampedInt64 right) => left._value > right._value;
        public static bool operator >=(ClampedInt64 left, ClampedInt64 right) => left._value >= right._value;
        public static ClampedInt64 operator %(ClampedInt64 left, ClampedInt64 right) => ClampedArithmetic.Remainder(left._value, right._value);
        public static ClampedInt64 operator &(ClampedInt64 left, ClampedInt64 right) => left._value & right._value;
        public static ClampedInt64 operator -(ClampedInt64 left, ClampedInt64 right) => ClampedArithmetic.Subtract(left._value, right._value);
        public static ClampedInt64 operator --(ClampedInt64 value) => ClampedArithmetic.Subtract(value._value, 1);
        public static ClampedInt64 operator -(ClampedInt64 value) => -value._value;
        public static ClampedInt64 operator *(ClampedInt64 left, ClampedInt64 right) => ClampedArithmetic.Multiply(left._value, right._value);
        public static ClampedInt64 operator /(ClampedInt64 left, ClampedInt64 right) => ClampedArithmetic.Divide(left._value, right._value);
        public static ClampedInt64 operator ^(ClampedInt64 left, ClampedInt64 right) => left._value ^ right._value;
        public static ClampedInt64 operator |(ClampedInt64 left, ClampedInt64 right) => left._value | right._value;
        public static ClampedInt64 operator ~(ClampedInt64 value) => ~value._value;
        public static ClampedInt64 operator +(ClampedInt64 left, ClampedInt64 right) => ClampedArithmetic.Add(left._value, right._value);
        public static ClampedInt64 operator +(ClampedInt64 value) => value;
        public static ClampedInt64 operator ++(ClampedInt64 value) => ClampedArithmetic.Add(value._value, 1);
        public static ClampedInt64 operator <<(ClampedInt64 left, int right) => left._value << right;
        public static ClampedInt64 operator >>(ClampedInt64 left, int right) => left._value >> right;

        TypeCode IConvertible.GetTypeCode() => _value.GetTypeCode();
        bool IConvertible.ToBoolean(IFormatProvider? provider) => Convert.ToBoolean(_value, provider);
        byte IConvertible.ToByte(IFormatProvider? provider) => ConvertN.ToByte(_value, Conversion.Clamp);
        char IConvertible.ToChar(IFormatProvider? provider) => Convert.ToChar(_value, provider);
        DateTime IConvertible.ToDateTime(IFormatProvider? provider) => Convert.ToDateTime(provider);
        decimal IConvertible.ToDecimal(IFormatProvider? provider) => ConvertN.ToDecimal(_value, Conversion.Clamp);
        double IConvertible.ToDouble(IFormatProvider? provider) => ConvertN.ToDouble(_value, Conversion.Clamp);
        float IConvertible.ToSingle(IFormatProvider? provider) => ConvertN.ToSingle(_value, Conversion.Clamp);
        int IConvertible.ToInt32(IFormatProvider? provider) => ConvertN.ToInt32(_value, Conversion.Clamp);
        long IConvertible.ToInt64(IFormatProvider? provider) => _value;
        sbyte IConvertible.ToSByte(IFormatProvider? provider) => ConvertN.ToSByte(_value, Conversion.Clamp);
        short IConvertible.ToInt16(IFormatProvider? provider) => ConvertN.ToInt16(_value, Conversion.Clamp);
        uint IConvertible.ToUInt32(IFormatProvider? provider) => ConvertN.ToUInt32(_value, Conversion.Clamp);
        ulong IConvertible.ToUInt64(IFormatProvider? provider) => ConvertN.ToUInt64(_value, Conversion.Clamp);
        ushort IConvertible.ToUInt16(IFormatProvider? provider) => ConvertN.ToUInt16(_value, Conversion.Clamp);
        object IConvertible.ToType(Type conversionType, IFormatProvider? provider) => this.ToTypeDefault(conversionType, provider);

        bool INumeric<ClampedInt64>.IsGreaterThan(ClampedInt64 value) => this > value;
        bool INumeric<ClampedInt64>.IsGreaterThanOrEqualTo(ClampedInt64 value) => this >= value;
        bool INumeric<ClampedInt64>.IsLessThan(ClampedInt64 value) => this < value;
        bool INumeric<ClampedInt64>.IsLessThanOrEqualTo(ClampedInt64 value) => this <= value;
        ClampedInt64 INumeric<ClampedInt64>.Add(ClampedInt64 value) => this + value;
        ClampedInt64 INumeric<ClampedInt64>.BitwiseComplement() => ~this;
        ClampedInt64 INumeric<ClampedInt64>.Divide(ClampedInt64 value) => this / value;
        ClampedInt64 INumeric<ClampedInt64>.LeftShift(int count) => this << count;
        ClampedInt64 INumeric<ClampedInt64>.LogicalAnd(ClampedInt64 value) => this & value;
        ClampedInt64 INumeric<ClampedInt64>.LogicalExclusiveOr(ClampedInt64 value) => this ^ value;
        ClampedInt64 INumeric<ClampedInt64>.LogicalOr(ClampedInt64 value) => this | value;
        ClampedInt64 INumeric<ClampedInt64>.Multiply(ClampedInt64 value) => this * value;
        ClampedInt64 INumeric<ClampedInt64>.Negative() => -this;
        ClampedInt64 INumeric<ClampedInt64>.Positive() => +this;
        ClampedInt64 INumeric<ClampedInt64>.Remainder(ClampedInt64 value) => this % value;
        ClampedInt64 INumeric<ClampedInt64>.RightShift(int count) => this >> count;
        ClampedInt64 INumeric<ClampedInt64>.Subtract(ClampedInt64 value) => this - value;

        INumericBitConverter<ClampedInt64> IProvider<INumericBitConverter<ClampedInt64>>.GetInstance() => Utilities.Instance;
        IBinaryIO<ClampedInt64> IProvider<IBinaryIO<ClampedInt64>>.GetInstance() => Utilities.Instance;
        IConvert<ClampedInt64> IProvider<IConvert<ClampedInt64>>.GetInstance() => Utilities.Instance;
        IConvertExtended<ClampedInt64> IProvider<IConvertExtended<ClampedInt64>>.GetInstance() => Utilities.Instance;
        IMath<ClampedInt64> IProvider<IMath<ClampedInt64>>.GetInstance() => Utilities.Instance;
        INumericRandom<ClampedInt64> IProvider<INumericRandom<ClampedInt64>>.GetInstance() => Utilities.Instance;
        INumericStatic<ClampedInt64> IProvider<INumericStatic<ClampedInt64>>.GetInstance() => Utilities.Instance;
        IVariantRandom<ClampedInt64> IProvider<IVariantRandom<ClampedInt64>>.GetInstance() => Utilities.Instance;

        private sealed class Utilities :
            IBinaryIO<ClampedInt64>,
            IConvert<ClampedInt64>,
            IConvertExtended<ClampedInt64>,
            IMath<ClampedInt64>,
            INumericBitConverter<ClampedInt64>,
            INumericRandom<ClampedInt64>,
            INumericStatic<ClampedInt64>,
            IVariantRandom<ClampedInt64>
        {
            public static readonly Utilities Instance = new Utilities();

            void IBinaryIO<ClampedInt64>.Write(BinaryWriter writer, ClampedInt64 value) => writer.Write(value);
            ClampedInt64 IBinaryIO<ClampedInt64>.Read(BinaryReader reader) => reader.ReadInt64();

            bool INumericStatic<ClampedInt64>.HasFloatingPoint => false;
            bool INumericStatic<ClampedInt64>.HasInfinity => false;
            bool INumericStatic<ClampedInt64>.HasNaN => false;
            bool INumericStatic<ClampedInt64>.IsFinite(ClampedInt64 x) => true;
            bool INumericStatic<ClampedInt64>.IsInfinity(ClampedInt64 x) => false;
            bool INumericStatic<ClampedInt64>.IsNaN(ClampedInt64 x) => false;
            bool INumericStatic<ClampedInt64>.IsNegative(ClampedInt64 x) => x._value < 0;
            bool INumericStatic<ClampedInt64>.IsNegativeInfinity(ClampedInt64 x) => false;
            bool INumericStatic<ClampedInt64>.IsNormal(ClampedInt64 x) => false;
            bool INumericStatic<ClampedInt64>.IsPositiveInfinity(ClampedInt64 x) => false;
            bool INumericStatic<ClampedInt64>.IsReal => false;
            bool INumericStatic<ClampedInt64>.IsSigned => true;
            bool INumericStatic<ClampedInt64>.IsSubnormal(ClampedInt64 x) => false;
            ClampedInt64 INumericStatic<ClampedInt64>.Epsilon => 1L;
            ClampedInt64 INumericStatic<ClampedInt64>.MaxUnit => 1L;
            ClampedInt64 INumericStatic<ClampedInt64>.MaxValue => MaxValue;
            ClampedInt64 INumericStatic<ClampedInt64>.MinUnit => -1L;
            ClampedInt64 INumericStatic<ClampedInt64>.MinValue => MinValue;
            ClampedInt64 INumericStatic<ClampedInt64>.One => 1L;
            ClampedInt64 INumericStatic<ClampedInt64>.Zero => 0L;

            ClampedInt64 IMath<ClampedInt64>.Abs(ClampedInt64 value) => Math.Abs(value);
            ClampedInt64 IMath<ClampedInt64>.Acos(ClampedInt64 x) => (ClampedInt64)Math.Acos(x);
            ClampedInt64 IMath<ClampedInt64>.Acosh(ClampedInt64 x) => (ClampedInt64)MathShim.Acosh(x);
            ClampedInt64 IMath<ClampedInt64>.Asin(ClampedInt64 x) => (ClampedInt64)Math.Asin(x);
            ClampedInt64 IMath<ClampedInt64>.Asinh(ClampedInt64 x) => (ClampedInt64)MathShim.Asinh(x);
            ClampedInt64 IMath<ClampedInt64>.Atan(ClampedInt64 x) => (ClampedInt64)Math.Atan(x);
            ClampedInt64 IMath<ClampedInt64>.Atan2(ClampedInt64 y, ClampedInt64 x) => (ClampedInt64)Math.Atan2(y, x);
            ClampedInt64 IMath<ClampedInt64>.Atanh(ClampedInt64 x) => (ClampedInt64)MathShim.Atanh(x);
            ClampedInt64 IMath<ClampedInt64>.Cbrt(ClampedInt64 x) => (ClampedInt64)MathShim.Cbrt(x);
            ClampedInt64 IMath<ClampedInt64>.Ceiling(ClampedInt64 x) => x;
            ClampedInt64 IMath<ClampedInt64>.Clamp(ClampedInt64 x, ClampedInt64 bound1, ClampedInt64 bound2) => bound1 > bound2 ? Math.Min(bound1, Math.Max(bound2, x)) : Math.Min(bound2, Math.Max(bound1, x));
            ClampedInt64 IMath<ClampedInt64>.Cos(ClampedInt64 x) => (ClampedInt64)Math.Cos(x);
            ClampedInt64 IMath<ClampedInt64>.Cosh(ClampedInt64 x) => (ClampedInt64)Math.Cosh(x);
            ClampedInt64 IMath<ClampedInt64>.E { get; } = 2L;
            ClampedInt64 IMath<ClampedInt64>.Exp(ClampedInt64 x) => (ClampedInt64)Math.Exp(x);
            ClampedInt64 IMath<ClampedInt64>.Floor(ClampedInt64 x) => x;
            ClampedInt64 IMath<ClampedInt64>.IEEERemainder(ClampedInt64 x, ClampedInt64 y) => (ClampedInt64)Math.IEEERemainder(x, y);
            ClampedInt64 IMath<ClampedInt64>.Log(ClampedInt64 x) => (ClampedInt64)Math.Log(x);
            ClampedInt64 IMath<ClampedInt64>.Log(ClampedInt64 x, ClampedInt64 y) => (ClampedInt64)Math.Log(x, y);
            ClampedInt64 IMath<ClampedInt64>.Log10(ClampedInt64 x) => (ClampedInt64)Math.Log10(x);
            ClampedInt64 IMath<ClampedInt64>.Max(ClampedInt64 x, ClampedInt64 y) => Math.Max(x, y);
            ClampedInt64 IMath<ClampedInt64>.Min(ClampedInt64 x, ClampedInt64 y) => Math.Min(x, y);
            ClampedInt64 IMath<ClampedInt64>.PI { get; } = 3L;
            ClampedInt64 IMath<ClampedInt64>.Pow(ClampedInt64 x, ClampedInt64 y) => ClampedArithmetic.Pow(x, y);
            ClampedInt64 IMath<ClampedInt64>.Round(ClampedInt64 x) => x;
            ClampedInt64 IMath<ClampedInt64>.Round(ClampedInt64 x, int digits) => x;
            ClampedInt64 IMath<ClampedInt64>.Round(ClampedInt64 x, int digits, MidpointRounding mode) => x;
            ClampedInt64 IMath<ClampedInt64>.Round(ClampedInt64 x, MidpointRounding mode) => x;
            ClampedInt64 IMath<ClampedInt64>.Sin(ClampedInt64 x) => (ClampedInt64)Math.Sin(x);
            ClampedInt64 IMath<ClampedInt64>.Sinh(ClampedInt64 x) => (ClampedInt64)Math.Sinh(x);
            ClampedInt64 IMath<ClampedInt64>.Sqrt(ClampedInt64 x) => (ClampedInt64)Math.Sqrt(x);
            ClampedInt64 IMath<ClampedInt64>.Tan(ClampedInt64 x) => (ClampedInt64)Math.Tan(x);
            ClampedInt64 IMath<ClampedInt64>.Tanh(ClampedInt64 x) => (ClampedInt64)Math.Tanh(x);
            ClampedInt64 IMath<ClampedInt64>.Tau { get; } = 6L;
            ClampedInt64 IMath<ClampedInt64>.Truncate(ClampedInt64 x) => x;
            int IMath<ClampedInt64>.Sign(ClampedInt64 x) => Math.Sign(x._value);

            int INumericBitConverter<ClampedInt64>.ConvertedSize => sizeof(long);
            ClampedInt64 INumericBitConverter<ClampedInt64>.ToNumeric(byte[] value, int startIndex) => BitConverter.ToInt64(value, startIndex);
            byte[] INumericBitConverter<ClampedInt64>.GetBytes(ClampedInt64 value) => BitConverter.GetBytes(value._value);
#if HAS_SPANS
            ClampedInt64 INumericBitConverter<ClampedInt64>.ToNumeric(ReadOnlySpan<byte> value) => BitConverter.ToInt64(value);
            bool INumericBitConverter<ClampedInt64>.TryWriteBytes(Span<byte> destination, ClampedInt64 value) => BitConverter.TryWriteBytes(destination, value);
#endif

            bool IConvert<ClampedInt64>.ToBoolean(ClampedInt64 value) => value._value != 0;
            byte IConvert<ClampedInt64>.ToByte(ClampedInt64 value, Conversion mode) => ConvertN.ToByte(value._value, mode.Clamped());
            decimal IConvert<ClampedInt64>.ToDecimal(ClampedInt64 value, Conversion mode) => ConvertN.ToDecimal(value._value, mode.Clamped());
            double IConvert<ClampedInt64>.ToDouble(ClampedInt64 value, Conversion mode) => ConvertN.ToDouble(value._value, mode.Clamped());
            float IConvert<ClampedInt64>.ToSingle(ClampedInt64 value, Conversion mode) => ConvertN.ToSingle(value._value, mode.Clamped());
            int IConvert<ClampedInt64>.ToInt32(ClampedInt64 value, Conversion mode) => ConvertN.ToInt32(value._value, mode.Clamped());
            long IConvert<ClampedInt64>.ToInt64(ClampedInt64 value, Conversion mode) => value._value;
            sbyte IConvertExtended<ClampedInt64>.ToSByte(ClampedInt64 value, Conversion mode) => ConvertN.ToSByte(value._value, mode.Clamped());
            short IConvert<ClampedInt64>.ToInt16(ClampedInt64 value, Conversion mode) => ConvertN.ToInt16(value._value, mode.Clamped());
            string IConvert<ClampedInt64>.ToString(ClampedInt64 value) => Convert.ToString(value._value);
            uint IConvertExtended<ClampedInt64>.ToUInt32(ClampedInt64 value, Conversion mode) => ConvertN.ToUInt32(value._value, mode.Clamped());
            ulong IConvertExtended<ClampedInt64>.ToUInt64(ClampedInt64 value, Conversion mode) => ConvertN.ToUInt64(value._value, mode.Clamped());
            ushort IConvertExtended<ClampedInt64>.ToUInt16(ClampedInt64 value, Conversion mode) => ConvertN.ToUInt16(value._value, mode.Clamped());

            ClampedInt64 IConvert<ClampedInt64>.ToNumeric(bool value) => value ? 1 : 0;
            ClampedInt64 IConvert<ClampedInt64>.ToNumeric(byte value, Conversion mode) => ConvertN.ToInt64(value, mode.Clamped());
            ClampedInt64 IConvert<ClampedInt64>.ToNumeric(decimal value, Conversion mode) => ConvertN.ToInt64(value, mode.Clamped());
            ClampedInt64 IConvert<ClampedInt64>.ToNumeric(double value, Conversion mode) => ConvertN.ToInt64(value, mode.Clamped());
            ClampedInt64 IConvert<ClampedInt64>.ToNumeric(float value, Conversion mode) => ConvertN.ToInt64(value, mode.Clamped());
            ClampedInt64 IConvert<ClampedInt64>.ToNumeric(int value, Conversion mode) => ConvertN.ToInt64(value, mode.Clamped());
            ClampedInt64 IConvert<ClampedInt64>.ToNumeric(long value, Conversion mode) => value;
            ClampedInt64 IConvertExtended<ClampedInt64>.ToValue(sbyte value, Conversion mode) => ConvertN.ToInt64(value, mode.Clamped());
            ClampedInt64 IConvert<ClampedInt64>.ToNumeric(short value, Conversion mode) => ConvertN.ToInt64(value, mode.Clamped());
            ClampedInt64 IConvert<ClampedInt64>.ToNumeric(string value) => Convert.ToInt64(value);
            ClampedInt64 IConvertExtended<ClampedInt64>.ToNumeric(uint value, Conversion mode) => ConvertN.ToInt64(value, mode.Clamped());
            ClampedInt64 IConvertExtended<ClampedInt64>.ToNumeric(ulong value, Conversion mode) => ConvertN.ToInt64(value, mode.Clamped());
            ClampedInt64 IConvertExtended<ClampedInt64>.ToNumeric(ushort value, Conversion mode) => ConvertN.ToInt64(value, mode.Clamped());

            ClampedInt64 INumericStatic<ClampedInt64>.Parse(string s, NumberStyles? style, IFormatProvider? provider)
                => Parse(s, style ?? NumberStyles.Integer, provider);

            ClampedInt64 INumericRandom<ClampedInt64>.Generate(Random random) => random.NextInt64();
            ClampedInt64 INumericRandom<ClampedInt64>.Generate(Random random, ClampedInt64 maxValue) => random.NextInt64(maxValue);
            ClampedInt64 INumericRandom<ClampedInt64>.Generate(Random random, ClampedInt64 minValue, ClampedInt64 maxValue) => random.NextInt64(minValue, maxValue);
            ClampedInt64 INumericRandom<ClampedInt64>.Generate(Random random, Generation mode) => random.NextInt64(mode);
            ClampedInt64 INumericRandom<ClampedInt64>.Generate(Random random, ClampedInt64 minValue, ClampedInt64 maxValue, Generation mode) => random.NextInt64(minValue, maxValue, mode);

            ClampedInt64 IVariantRandom<ClampedInt64>.Generate(Random random, Variants variants) => random.NextInt64(variants);
        }
    }
}
