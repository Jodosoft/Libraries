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
    /// Represents a 32-bit signed integer that cannot overflow.
    /// </summary>
    [Serializable]
    [DebuggerDisplay("{ToString(),nq}")]
    public readonly struct ClampedInt32 : INumericExtended<ClampedInt32>
    {
        public static readonly ClampedInt32 MaxValue = new ClampedInt32(int.MaxValue);
        public static readonly ClampedInt32 MinValue = new ClampedInt32(int.MinValue);

        private readonly int _value;

        private ClampedInt32(int value)
        {
            _value = value;
        }

        private ClampedInt32(SerializationInfo info, StreamingContext context) : this(info.GetInt32(nameof(ClampedInt32))) { }
        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context) => info.AddValue(nameof(ClampedInt32), _value);

        public int CompareTo(ClampedInt32 other) => _value.CompareTo(other._value);
        public int CompareTo(object? obj) => obj is ClampedInt32 other ? CompareTo(other) : 1;
        public bool Equals(ClampedInt32 other) => _value == other._value;
        public override bool Equals(object? obj) => obj is ClampedInt32 other && Equals(other);
        public override int GetHashCode() => _value.GetHashCode();
        public override string ToString() => _value.ToString();
        public string ToString(IFormatProvider? provider) => _value.ToString(provider);
        public string ToString(string format) => _value.ToString(format);
        public string ToString(string? format, IFormatProvider? formatProvider) => _value.ToString(format, formatProvider);

        public static bool TryParse(string s, IFormatProvider? provider, out ClampedInt32 result) => FuncExtensions.Try(() => Parse(s, provider), out result);
        public static bool TryParse(string s, NumberStyles style, IFormatProvider? provider, out ClampedInt32 result) => FuncExtensions.Try(() => Parse(s, style, provider), out result);
        public static bool TryParse(string s, NumberStyles style, out ClampedInt32 result) => FuncExtensions.Try(() => Parse(s, style), out result);
        public static bool TryParse(string s, out ClampedInt32 result) => FuncExtensions.Try(() => Parse(s), out result);
        public static ClampedInt32 Parse(string s) => int.Parse(s);
        public static ClampedInt32 Parse(string s, IFormatProvider? provider) => int.Parse(s, provider);
        public static ClampedInt32 Parse(string s, NumberStyles style) => int.Parse(s, style);
        public static ClampedInt32 Parse(string s, NumberStyles style, IFormatProvider? provider) => int.Parse(s, style, provider);

        [CLSCompliant(false)] public static explicit operator ClampedInt32(uint value) => new ClampedInt32(ConvertN.ToInt32(value, Conversion.CastClamp));
        [CLSCompliant(false)] public static explicit operator ClampedInt32(ulong value) => new ClampedInt32(ConvertN.ToInt32(value, Conversion.CastClamp));
        [CLSCompliant(false)] public static implicit operator ClampedInt32(sbyte value) => new ClampedInt32(value);
        [CLSCompliant(false)] public static implicit operator ClampedInt32(ushort value) => new ClampedInt32(value);
        public static explicit operator ClampedInt32(decimal value) => new ClampedInt32(ConvertN.ToInt32(value, Conversion.CastClamp));
        public static explicit operator ClampedInt32(double value) => new ClampedInt32(ConvertN.ToInt32(value, Conversion.CastClamp));
        public static explicit operator ClampedInt32(float value) => new ClampedInt32(ConvertN.ToInt32(value, Conversion.CastClamp));
        public static explicit operator ClampedInt32(long value) => new ClampedInt32(ConvertN.ToInt32(value, Conversion.CastClamp));
        public static implicit operator ClampedInt32(byte value) => new ClampedInt32(value);
        public static implicit operator ClampedInt32(int value) => new ClampedInt32(value);
        public static implicit operator ClampedInt32(short value) => new ClampedInt32(value);

        [CLSCompliant(false)] public static explicit operator sbyte(ClampedInt32 value) => ConvertN.ToSByte(value._value, Conversion.CastClamp);
        [CLSCompliant(false)] public static explicit operator uint(ClampedInt32 value) => ConvertN.ToUInt32(value._value, Conversion.CastClamp);
        [CLSCompliant(false)] public static explicit operator ulong(ClampedInt32 value) => ConvertN.ToUInt64(value._value, Conversion.CastClamp);
        [CLSCompliant(false)] public static explicit operator ushort(ClampedInt32 value) => ConvertN.ToUInt16(value._value, Conversion.CastClamp);
        public static explicit operator byte(ClampedInt32 value) => ConvertN.ToByte(value._value, Conversion.CastClamp);
        public static explicit operator short(ClampedInt32 value) => ConvertN.ToInt16(value._value, Conversion.CastClamp);
        public static implicit operator decimal(ClampedInt32 value) => value._value;
        public static implicit operator double(ClampedInt32 value) => value._value;
        public static implicit operator float(ClampedInt32 value) => value._value;
        public static implicit operator int(ClampedInt32 value) => value._value;
        public static implicit operator long(ClampedInt32 value) => value._value;

        public static bool operator !=(ClampedInt32 left, ClampedInt32 right) => left._value != right._value;
        public static bool operator <(ClampedInt32 left, ClampedInt32 right) => left._value < right._value;
        public static bool operator <=(ClampedInt32 left, ClampedInt32 right) => left._value <= right._value;
        public static bool operator ==(ClampedInt32 left, ClampedInt32 right) => left._value == right._value;
        public static bool operator >(ClampedInt32 left, ClampedInt32 right) => left._value > right._value;
        public static bool operator >=(ClampedInt32 left, ClampedInt32 right) => left._value >= right._value;
        public static ClampedInt32 operator %(ClampedInt32 left, ClampedInt32 right) => ClampedArithmetic.Remainder(left._value, right._value);
        public static ClampedInt32 operator &(ClampedInt32 left, ClampedInt32 right) => left._value & right._value;
        public static ClampedInt32 operator -(ClampedInt32 left, ClampedInt32 right) => ClampedArithmetic.Subtract(left._value, right._value);
        public static ClampedInt32 operator --(ClampedInt32 value) => value - 1;
        public static ClampedInt32 operator -(ClampedInt32 value) => -value._value;
        public static ClampedInt32 operator *(ClampedInt32 left, ClampedInt32 right) => ClampedArithmetic.Multiply(left._value, right._value);
        public static ClampedInt32 operator /(ClampedInt32 left, ClampedInt32 right) => ClampedArithmetic.Divide(left._value, right._value);
        public static ClampedInt32 operator ^(ClampedInt32 left, ClampedInt32 right) => left._value ^ right._value;
        public static ClampedInt32 operator |(ClampedInt32 left, ClampedInt32 right) => left._value | right._value;
        public static ClampedInt32 operator ~(ClampedInt32 value) => ~value._value;
        public static ClampedInt32 operator +(ClampedInt32 left, ClampedInt32 right) => ClampedArithmetic.Add(left._value, right._value);
        public static ClampedInt32 operator +(ClampedInt32 value) => value;
        public static ClampedInt32 operator ++(ClampedInt32 value) => value + 1;
        public static ClampedInt32 operator <<(ClampedInt32 left, int right) => left._value << right;
        public static ClampedInt32 operator >>(ClampedInt32 left, int right) => left._value >> right;

        TypeCode IConvertible.GetTypeCode() => _value.GetTypeCode();
        bool IConvertible.ToBoolean(IFormatProvider? provider) => Convert.ToBoolean(_value, provider);
        byte IConvertible.ToByte(IFormatProvider? provider) => ConvertN.ToByte(_value, Conversion.Clamp);
        char IConvertible.ToChar(IFormatProvider? provider) => Convert.ToChar(_value, provider);
        DateTime IConvertible.ToDateTime(IFormatProvider? provider) => Convert.ToDateTime(provider);
        decimal IConvertible.ToDecimal(IFormatProvider? provider) => ConvertN.ToDecimal(_value, Conversion.Clamp);
        double IConvertible.ToDouble(IFormatProvider? provider) => ConvertN.ToDouble(_value, Conversion.Clamp);
        float IConvertible.ToSingle(IFormatProvider? provider) => ConvertN.ToSingle(_value, Conversion.Clamp);
        int IConvertible.ToInt32(IFormatProvider? provider) => _value;
        long IConvertible.ToInt64(IFormatProvider? provider) => ConvertN.ToInt64(_value, Conversion.Clamp);
        sbyte IConvertible.ToSByte(IFormatProvider? provider) => ConvertN.ToSByte(_value, Conversion.Clamp);
        short IConvertible.ToInt16(IFormatProvider? provider) => ConvertN.ToInt16(_value, Conversion.Clamp);
        uint IConvertible.ToUInt32(IFormatProvider? provider) => ConvertN.ToUInt32(_value, Conversion.Clamp);
        ulong IConvertible.ToUInt64(IFormatProvider? provider) => ConvertN.ToUInt64(_value, Conversion.Clamp);
        ushort IConvertible.ToUInt16(IFormatProvider? provider) => ConvertN.ToUInt16(_value, Conversion.Clamp);
        object IConvertible.ToType(Type conversionType, IFormatProvider? provider) => this.ToTypeDefault(conversionType, provider);

        bool INumeric<ClampedInt32>.IsGreaterThan(ClampedInt32 value) => this > value;
        bool INumeric<ClampedInt32>.IsGreaterThanOrEqualTo(ClampedInt32 value) => this >= value;
        bool INumeric<ClampedInt32>.IsLessThan(ClampedInt32 value) => this < value;
        bool INumeric<ClampedInt32>.IsLessThanOrEqualTo(ClampedInt32 value) => this <= value;
        ClampedInt32 INumeric<ClampedInt32>.Add(ClampedInt32 value) => this + value;
        ClampedInt32 INumeric<ClampedInt32>.BitwiseComplement() => ~this;
        ClampedInt32 INumeric<ClampedInt32>.Divide(ClampedInt32 value) => this / value;
        ClampedInt32 INumeric<ClampedInt32>.LeftShift(int count) => this << count;
        ClampedInt32 INumeric<ClampedInt32>.LogicalAnd(ClampedInt32 value) => this & value;
        ClampedInt32 INumeric<ClampedInt32>.LogicalExclusiveOr(ClampedInt32 value) => this ^ value;
        ClampedInt32 INumeric<ClampedInt32>.LogicalOr(ClampedInt32 value) => this | value;
        ClampedInt32 INumeric<ClampedInt32>.Multiply(ClampedInt32 value) => this * value;
        ClampedInt32 INumeric<ClampedInt32>.Negative() => -this;
        ClampedInt32 INumeric<ClampedInt32>.Positive() => +this;
        ClampedInt32 INumeric<ClampedInt32>.Remainder(ClampedInt32 value) => this % value;
        ClampedInt32 INumeric<ClampedInt32>.RightShift(int count) => this >> count;
        ClampedInt32 INumeric<ClampedInt32>.Subtract(ClampedInt32 value) => this - value;

        INumericBitConverter<ClampedInt32> IProvider<INumericBitConverter<ClampedInt32>>.GetInstance() => Utilities.Instance;
        IBinaryIO<ClampedInt32> IProvider<IBinaryIO<ClampedInt32>>.GetInstance() => Utilities.Instance;
        IConvert<ClampedInt32> IProvider<IConvert<ClampedInt32>>.GetInstance() => Utilities.Instance;
        IConvertExtended<ClampedInt32> IProvider<IConvertExtended<ClampedInt32>>.GetInstance() => Utilities.Instance;
        IMath<ClampedInt32> IProvider<IMath<ClampedInt32>>.GetInstance() => Utilities.Instance;
        INumericRandom<ClampedInt32> IProvider<INumericRandom<ClampedInt32>>.GetInstance() => Utilities.Instance;
        INumericStatic<ClampedInt32> IProvider<INumericStatic<ClampedInt32>>.GetInstance() => Utilities.Instance;
        IVariantRandom<ClampedInt32> IProvider<IVariantRandom<ClampedInt32>>.GetInstance() => Utilities.Instance;

        private sealed class Utilities :
            IBinaryIO<ClampedInt32>,
            IConvert<ClampedInt32>,
            IConvertExtended<ClampedInt32>,
            IMath<ClampedInt32>,
            INumericBitConverter<ClampedInt32>,
            INumericRandom<ClampedInt32>,
            INumericStatic<ClampedInt32>,
            IVariantRandom<ClampedInt32>
        {
            public static readonly Utilities Instance = new Utilities();

            void IBinaryIO<ClampedInt32>.Write(BinaryWriter writer, ClampedInt32 value) => writer.Write(value);
            ClampedInt32 IBinaryIO<ClampedInt32>.Read(BinaryReader reader) => reader.ReadInt32();

            bool INumericStatic<ClampedInt32>.HasFloatingPoint => false;
            bool INumericStatic<ClampedInt32>.HasInfinity => false;
            bool INumericStatic<ClampedInt32>.HasNaN => false;
            bool INumericStatic<ClampedInt32>.IsFinite(ClampedInt32 x) => true;
            bool INumericStatic<ClampedInt32>.IsInfinity(ClampedInt32 x) => false;
            bool INumericStatic<ClampedInt32>.IsNaN(ClampedInt32 x) => false;
            bool INumericStatic<ClampedInt32>.IsNegative(ClampedInt32 x) => x._value < 0;
            bool INumericStatic<ClampedInt32>.IsNegativeInfinity(ClampedInt32 x) => false;
            bool INumericStatic<ClampedInt32>.IsNormal(ClampedInt32 x) => false;
            bool INumericStatic<ClampedInt32>.IsPositiveInfinity(ClampedInt32 x) => false;
            bool INumericStatic<ClampedInt32>.IsReal => false;
            bool INumericStatic<ClampedInt32>.IsSigned => true;
            bool INumericStatic<ClampedInt32>.IsSubnormal(ClampedInt32 x) => false;
            ClampedInt32 INumericStatic<ClampedInt32>.Epsilon => 1;
            ClampedInt32 INumericStatic<ClampedInt32>.MaxUnit => 1;
            ClampedInt32 INumericStatic<ClampedInt32>.MaxValue => MaxValue;
            ClampedInt32 INumericStatic<ClampedInt32>.MinUnit => -1;
            ClampedInt32 INumericStatic<ClampedInt32>.MinValue => MinValue;
            ClampedInt32 INumericStatic<ClampedInt32>.One => 1;
            ClampedInt32 INumericStatic<ClampedInt32>.Zero => 0;

            ClampedInt32 IMath<ClampedInt32>.Abs(ClampedInt32 value) => Math.Abs(value._value);
            ClampedInt32 IMath<ClampedInt32>.Acos(ClampedInt32 x) => (ClampedInt32)Math.Acos(x._value);
            ClampedInt32 IMath<ClampedInt32>.Acosh(ClampedInt32 x) => (ClampedInt32)MathShim.Acosh(x._value);
            ClampedInt32 IMath<ClampedInt32>.Asin(ClampedInt32 x) => (ClampedInt32)Math.Asin(x._value);
            ClampedInt32 IMath<ClampedInt32>.Asinh(ClampedInt32 x) => (ClampedInt32)MathShim.Asinh(x._value);
            ClampedInt32 IMath<ClampedInt32>.Atan(ClampedInt32 x) => (ClampedInt32)Math.Atan(x._value);
            ClampedInt32 IMath<ClampedInt32>.Atan2(ClampedInt32 x, ClampedInt32 y) => (ClampedInt32)Math.Atan2(x._value, y._value);
            ClampedInt32 IMath<ClampedInt32>.Atanh(ClampedInt32 x) => (ClampedInt32)MathShim.Atanh(x._value);
            ClampedInt32 IMath<ClampedInt32>.Cbrt(ClampedInt32 x) => (ClampedInt32)MathShim.Cbrt(x._value);
            ClampedInt32 IMath<ClampedInt32>.Ceiling(ClampedInt32 x) => x;
            ClampedInt32 IMath<ClampedInt32>.Clamp(ClampedInt32 x, ClampedInt32 bound1, ClampedInt32 bound2) => bound1 > bound2 ? Math.Min(bound1._value, Math.Max(bound2._value, x._value)) : Math.Min(bound2._value, Math.Max(bound1._value, x._value));
            ClampedInt32 IMath<ClampedInt32>.Cos(ClampedInt32 x) => (ClampedInt32)Math.Cos(x._value);
            ClampedInt32 IMath<ClampedInt32>.Cosh(ClampedInt32 x) => (ClampedInt32)Math.Cosh(x._value);
            ClampedInt32 IMath<ClampedInt32>.E { get; } = 2;
            ClampedInt32 IMath<ClampedInt32>.Exp(ClampedInt32 x) => (ClampedInt32)Math.Exp(x._value);
            ClampedInt32 IMath<ClampedInt32>.Floor(ClampedInt32 x) => x;
            ClampedInt32 IMath<ClampedInt32>.IEEERemainder(ClampedInt32 x, ClampedInt32 y) => (ClampedInt32)Math.IEEERemainder(x._value, y._value);
            ClampedInt32 IMath<ClampedInt32>.Log(ClampedInt32 x) => (ClampedInt32)Math.Log(x._value);
            ClampedInt32 IMath<ClampedInt32>.Log(ClampedInt32 x, ClampedInt32 y) => (ClampedInt32)Math.Log(x._value, y._value);
            ClampedInt32 IMath<ClampedInt32>.Log10(ClampedInt32 x) => (ClampedInt32)Math.Log10(x._value);
            ClampedInt32 IMath<ClampedInt32>.Max(ClampedInt32 x, ClampedInt32 y) => Math.Max(x._value, y._value);
            ClampedInt32 IMath<ClampedInt32>.Min(ClampedInt32 x, ClampedInt32 y) => Math.Min(x._value, y._value);
            ClampedInt32 IMath<ClampedInt32>.PI { get; } = 3;
            ClampedInt32 IMath<ClampedInt32>.Pow(ClampedInt32 x, ClampedInt32 y) => ClampedArithmetic.Pow(x._value, y._value);
            ClampedInt32 IMath<ClampedInt32>.Round(ClampedInt32 x) => x;
            ClampedInt32 IMath<ClampedInt32>.Round(ClampedInt32 x, int digits) => x;
            ClampedInt32 IMath<ClampedInt32>.Round(ClampedInt32 x, int digits, MidpointRounding mode) => x;
            ClampedInt32 IMath<ClampedInt32>.Round(ClampedInt32 x, MidpointRounding mode) => x;
            ClampedInt32 IMath<ClampedInt32>.Sin(ClampedInt32 x) => (ClampedInt32)Math.Sin(x._value);
            ClampedInt32 IMath<ClampedInt32>.Sinh(ClampedInt32 x) => (ClampedInt32)Math.Sinh(x._value);
            ClampedInt32 IMath<ClampedInt32>.Sqrt(ClampedInt32 x) => (ClampedInt32)Math.Sqrt(x._value);
            ClampedInt32 IMath<ClampedInt32>.Tan(ClampedInt32 x) => (ClampedInt32)Math.Tan(x._value);
            ClampedInt32 IMath<ClampedInt32>.Tanh(ClampedInt32 x) => (ClampedInt32)Math.Tanh(x._value);
            ClampedInt32 IMath<ClampedInt32>.Tau { get; } = 6;
            ClampedInt32 IMath<ClampedInt32>.Truncate(ClampedInt32 x) => x;
            int IMath<ClampedInt32>.Sign(ClampedInt32 x) => Math.Sign(x._value);

            int INumericBitConverter<ClampedInt32>.ConvertedSize => sizeof(int);
            ClampedInt32 INumericBitConverter<ClampedInt32>.ToNumeric(byte[] value, int startIndex) => BitConverter.ToInt32(value, startIndex);
            byte[] INumericBitConverter<ClampedInt32>.GetBytes(ClampedInt32 value) => BitConverter.GetBytes(value._value);
#if HAS_SPANS
            ClampedInt32 INumericBitConverter<ClampedInt32>.ToNumeric(ReadOnlySpan<byte> value) => BitConverter.ToInt32(value);
            bool INumericBitConverter<ClampedInt32>.TryWriteBytes(Span<byte> destination, ClampedInt32 value) => BitConverter.TryWriteBytes(destination, value);
#endif

            bool IConvert<ClampedInt32>.ToBoolean(ClampedInt32 value) => value._value != 0;
            byte IConvert<ClampedInt32>.ToByte(ClampedInt32 value, Conversion mode) => ConvertN.ToByte(value._value, mode.Clamped());
            decimal IConvert<ClampedInt32>.ToDecimal(ClampedInt32 value, Conversion mode) => ConvertN.ToDecimal(value._value, mode.Clamped());
            double IConvert<ClampedInt32>.ToDouble(ClampedInt32 value, Conversion mode) => ConvertN.ToDouble(value._value, mode.Clamped());
            float IConvert<ClampedInt32>.ToSingle(ClampedInt32 value, Conversion mode) => ConvertN.ToSingle(value._value, mode.Clamped());
            int IConvert<ClampedInt32>.ToInt32(ClampedInt32 value, Conversion mode) => value._value;
            long IConvert<ClampedInt32>.ToInt64(ClampedInt32 value, Conversion mode) => ConvertN.ToInt64(value._value, mode.Clamped());
            sbyte IConvertExtended<ClampedInt32>.ToSByte(ClampedInt32 value, Conversion mode) => ConvertN.ToSByte(value._value, mode.Clamped());
            short IConvert<ClampedInt32>.ToInt16(ClampedInt32 value, Conversion mode) => ConvertN.ToInt16(value._value, mode.Clamped());
            string IConvert<ClampedInt32>.ToString(ClampedInt32 value) => Convert.ToString(value._value);
            uint IConvertExtended<ClampedInt32>.ToUInt32(ClampedInt32 value, Conversion mode) => ConvertN.ToUInt32(value._value, mode.Clamped());
            ulong IConvertExtended<ClampedInt32>.ToUInt64(ClampedInt32 value, Conversion mode) => ConvertN.ToUInt64(value._value, mode.Clamped());
            ushort IConvertExtended<ClampedInt32>.ToUInt16(ClampedInt32 value, Conversion mode) => ConvertN.ToUInt16(value._value, mode.Clamped());

            ClampedInt32 IConvert<ClampedInt32>.ToNumeric(bool value) => value ? 1 : 0;
            ClampedInt32 IConvert<ClampedInt32>.ToNumeric(byte value, Conversion mode) => ConvertN.ToInt32(value, mode.Clamped());
            ClampedInt32 IConvert<ClampedInt32>.ToNumeric(decimal value, Conversion mode) => ConvertN.ToInt32(value, mode.Clamped());
            ClampedInt32 IConvert<ClampedInt32>.ToNumeric(double value, Conversion mode) => ConvertN.ToInt32(value, mode.Clamped());
            ClampedInt32 IConvert<ClampedInt32>.ToNumeric(float value, Conversion mode) => ConvertN.ToInt32(value, mode.Clamped());
            ClampedInt32 IConvert<ClampedInt32>.ToNumeric(int value, Conversion mode) => value;
            ClampedInt32 IConvert<ClampedInt32>.ToNumeric(long value, Conversion mode) => ConvertN.ToInt32(value, mode.Clamped());
            ClampedInt32 IConvertExtended<ClampedInt32>.ToValue(sbyte value, Conversion mode) => ConvertN.ToInt32(value, mode.Clamped());
            ClampedInt32 IConvert<ClampedInt32>.ToNumeric(short value, Conversion mode) => ConvertN.ToInt32(value, mode.Clamped());
            ClampedInt32 IConvert<ClampedInt32>.ToNumeric(string value) => Convert.ToInt32(value);
            ClampedInt32 IConvertExtended<ClampedInt32>.ToNumeric(uint value, Conversion mode) => ConvertN.ToInt32(value, mode.Clamped());
            ClampedInt32 IConvertExtended<ClampedInt32>.ToNumeric(ulong value, Conversion mode) => ConvertN.ToInt32(value, mode.Clamped());
            ClampedInt32 IConvertExtended<ClampedInt32>.ToNumeric(ushort value, Conversion mode) => ConvertN.ToInt32(value, mode.Clamped());

            ClampedInt32 INumericStatic<ClampedInt32>.Parse(string s, NumberStyles? style, IFormatProvider? provider)
                => Parse(s, style ?? NumberStyles.Integer, provider);

            ClampedInt32 INumericRandom<ClampedInt32>.Generate(Random random) => random.NextInt32();
            ClampedInt32 INumericRandom<ClampedInt32>.Generate(Random random, ClampedInt32 maxValue) => random.NextInt32(maxValue);
            ClampedInt32 INumericRandom<ClampedInt32>.Generate(Random random, ClampedInt32 minValue, ClampedInt32 maxValue) => random.NextInt32(minValue, maxValue);
            ClampedInt32 INumericRandom<ClampedInt32>.Generate(Random random, Generation mode) => random.NextInt32(mode);
            ClampedInt32 INumericRandom<ClampedInt32>.Generate(Random random, ClampedInt32 minValue, ClampedInt32 maxValue, Generation mode) => random.NextInt32(minValue, maxValue, mode);

            ClampedInt32 IVariantRandom<ClampedInt32>.Generate(Random random, Variants variants) => random.NextInt32(variants);
        }
    }
}
