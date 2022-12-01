// Copyright (c) 2022 Joseph J. Short
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
using Jodo.Primitives;
using Jodo.Primitives.Compatibility;

namespace Jodo.Numerics.Clamped
{
    /// <summary>
    /// Represents an 8-bit unsigned integer that cannot overflow.
    /// </summary>
    [Serializable]
    [DebuggerDisplay("{ToString(),nq}")]
    public readonly struct ByteM : INumericExtended<ByteM>
    {
        public static readonly ByteM MaxValue = new ByteM(byte.MaxValue);
        public static readonly ByteM MinValue = new ByteM(byte.MinValue);

        private readonly byte _value;

        private ByteM(byte value)
        {
            _value = value;
        }

        private ByteM(SerializationInfo info, StreamingContext context) : this(info.GetByte(nameof(ByteM))) { }
        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context) => info.AddValue(nameof(ByteM), _value);

        public int CompareTo(object? obj) => obj is ByteM other ? CompareTo(other) : 1;
        public int CompareTo(ByteM other) => _value.CompareTo(other._value);
        public bool Equals(ByteM other) => _value == other._value;
        public override bool Equals(object? obj) => obj is ByteM other && Equals(other);
        public override int GetHashCode() => _value.GetHashCode();
        public override string ToString() => _value.ToString();
        public string ToString(IFormatProvider formatProvider) => _value.ToString(formatProvider);
        public string ToString(string format) => _value.ToString(format);
        public string ToString(string? format, IFormatProvider? formatProvider) => _value.ToString(format, formatProvider);

        public static bool TryParse(string s, IFormatProvider? provider, out ByteM result) => FuncExtensions.Try(() => Parse(s, provider), out result);
        public static bool TryParse(string s, NumberStyles style, IFormatProvider? provider, out ByteM result) => FuncExtensions.Try(() => Parse(s, style, provider), out result);
        public static bool TryParse(string s, NumberStyles style, out ByteM result) => FuncExtensions.Try(() => Parse(s, style), out result);
        public static bool TryParse(string s, out ByteM result) => FuncExtensions.Try(() => Parse(s), out result);
        public static ByteM Parse(string s) => byte.Parse(s);
        public static ByteM Parse(string s, IFormatProvider? provider) => byte.Parse(s, provider);
        public static ByteM Parse(string s, NumberStyles style) => byte.Parse(s, style);
        public static ByteM Parse(string s, NumberStyles style, IFormatProvider? provider) => byte.Parse(s, style, provider);

        [CLSCompliant(false)] public static explicit operator ByteM(sbyte value) => new ByteM(ConvertN.ToByte(value, Conversion.CastClamp));
        [CLSCompliant(false)] public static explicit operator ByteM(uint value) => new ByteM(ConvertN.ToByte(value, Conversion.CastClamp));
        [CLSCompliant(false)] public static explicit operator ByteM(ulong value) => new ByteM(ConvertN.ToByte(value, Conversion.CastClamp));
        [CLSCompliant(false)] public static implicit operator ByteM(ushort value) => new ByteM(ConvertN.ToByte(value, Conversion.CastClamp));
        public static explicit operator ByteM(decimal value) => new ByteM(ConvertN.ToByte(value, Conversion.CastClamp));
        public static explicit operator ByteM(double value) => new ByteM(ConvertN.ToByte(value, Conversion.CastClamp));
        public static explicit operator ByteM(float value) => new ByteM(ConvertN.ToByte(value, Conversion.CastClamp));
        public static explicit operator ByteM(int value) => new ByteM(ConvertN.ToByte(value, Conversion.CastClamp));
        public static explicit operator ByteM(long value) => new ByteM(ConvertN.ToByte(value, Conversion.CastClamp));
        public static explicit operator ByteM(short value) => new ByteM(ConvertN.ToByte(value, Conversion.CastClamp));
        public static implicit operator ByteM(byte value) => new ByteM(value);

        [CLSCompliant(false)] public static explicit operator sbyte(ByteM value) => ConvertN.ToSByte(value._value, Conversion.CastClamp);
        [CLSCompliant(false)] public static implicit operator uint(ByteM value) => value._value;
        [CLSCompliant(false)] public static implicit operator ulong(ByteM value) => value._value;
        [CLSCompliant(false)] public static implicit operator ushort(ByteM value) => value._value;
        public static implicit operator byte(ByteM value) => value._value;
        public static implicit operator decimal(ByteM value) => value._value;
        public static implicit operator double(ByteM value) => value._value;
        public static implicit operator float(ByteM value) => value._value;
        public static implicit operator int(ByteM value) => value._value;
        public static implicit operator long(ByteM value) => value._value;
        public static implicit operator short(ByteM value) => value._value;

        public static bool operator !=(ByteM left, ByteM right) => left._value != right._value;
        public static bool operator <(ByteM left, ByteM right) => left._value < right._value;
        public static bool operator <=(ByteM left, ByteM right) => left._value <= right._value;
        public static bool operator ==(ByteM left, ByteM right) => left._value == right._value;
        public static bool operator >(ByteM left, ByteM right) => left._value > right._value;
        public static bool operator >=(ByteM left, ByteM right) => left._value >= right._value;
        public static ByteM operator %(ByteM left, ByteM right) => Clamped.Remainder(left._value, right._value);
        public static ByteM operator &(ByteM left, ByteM right) => (byte)(left._value & right._value);
        public static ByteM operator -(ByteM _) => MinValue;
        public static ByteM operator -(ByteM left, ByteM right) => Clamped.Subtract(left._value, right._value);
        public static ByteM operator --(ByteM value) => value - 1;
        public static ByteM operator *(ByteM left, ByteM right) => Clamped.Multiply(left._value, right._value);
        public static ByteM operator /(ByteM left, ByteM right) => Clamped.Divide(left._value, right._value);
        public static ByteM operator ^(ByteM left, ByteM right) => (byte)(left._value ^ right._value);
        public static ByteM operator |(ByteM left, ByteM right) => (byte)(left._value | right._value);
        public static ByteM operator ~(ByteM value) => (byte)~value._value;
        public static ByteM operator +(ByteM left, ByteM right) => Clamped.Add(left._value, right._value);
        public static ByteM operator +(ByteM value) => value;
        public static ByteM operator ++(ByteM value) => value + 1;
        public static ByteM operator <<(ByteM left, int right) => (byte)(left._value << right);
        public static ByteM operator >>(ByteM left, int right) => (byte)(left._value >> right);

        TypeCode IConvertible.GetTypeCode() => _value.GetTypeCode();
        bool IConvertible.ToBoolean(IFormatProvider provider) => Convert.ToBoolean(_value, provider);
        byte IConvertible.ToByte(IFormatProvider provider) => _value;
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
        ushort IConvertible.ToUInt16(IFormatProvider provider) => ConvertN.ToUInt16(_value, Conversion.Clamp);
        object IConvertible.ToType(Type conversionType, IFormatProvider provider) => this.ToTypeDefault(conversionType, provider);

        bool INumeric<ByteM>.IsGreaterThan(ByteM value) => this > value;
        bool INumeric<ByteM>.IsGreaterThanOrEqualTo(ByteM value) => this >= value;
        bool INumeric<ByteM>.IsLessThan(ByteM value) => this < value;
        bool INumeric<ByteM>.IsLessThanOrEqualTo(ByteM value) => this <= value;
        ByteM INumeric<ByteM>.Add(ByteM value) => this + value;
        ByteM INumeric<ByteM>.BitwiseComplement() => ~this;
        ByteM INumeric<ByteM>.Divide(ByteM value) => this / value;
        ByteM INumeric<ByteM>.LeftShift(int count) => this << count;
        ByteM INumeric<ByteM>.LogicalAnd(ByteM value) => this & value;
        ByteM INumeric<ByteM>.LogicalExclusiveOr(ByteM value) => this ^ value;
        ByteM INumeric<ByteM>.LogicalOr(ByteM value) => this | value;
        ByteM INumeric<ByteM>.Multiply(ByteM value) => this * value;
        ByteM INumeric<ByteM>.Negative() => -this;
        ByteM INumeric<ByteM>.Positive() => +this;
        ByteM INumeric<ByteM>.Remainder(ByteM value) => this % value;
        ByteM INumeric<ByteM>.RightShift(int count) => this >> count;
        ByteM INumeric<ByteM>.Subtract(ByteM value) => this - value;

        INumericBitConverter<ByteM> IProvider<INumericBitConverter<ByteM>>.GetInstance() => Utilities.Instance;
        IBinaryIO<ByteM> IProvider<IBinaryIO<ByteM>>.GetInstance() => Utilities.Instance;
        IConvert<ByteM> IProvider<IConvert<ByteM>>.GetInstance() => Utilities.Instance;
        IConvertExtended<ByteM> IProvider<IConvertExtended<ByteM>>.GetInstance() => Utilities.Instance;
        IMath<ByteM> IProvider<IMath<ByteM>>.GetInstance() => Utilities.Instance;
        INumericRandom<ByteM> IProvider<INumericRandom<ByteM>>.GetInstance() => Utilities.Instance;
        INumericStatic<ByteM> IProvider<INumericStatic<ByteM>>.GetInstance() => Utilities.Instance;
        IVariantRandom<ByteM> IProvider<IVariantRandom<ByteM>>.GetInstance() => Utilities.Instance;

        private sealed class Utilities :
            IBinaryIO<ByteM>,
            IConvert<ByteM>,
            IConvertExtended<ByteM>,
            IMath<ByteM>,
            INumericBitConverter<ByteM>,
            INumericRandom<ByteM>,
            INumericStatic<ByteM>,
            IVariantRandom<ByteM>
        {
            public static readonly Utilities Instance = new Utilities();

            void IBinaryIO<ByteM>.Write(BinaryWriter writer, ByteM value) => writer.Write(value);
            ByteM IBinaryIO<ByteM>.Read(BinaryReader reader) => reader.ReadByte();

            bool INumericStatic<ByteM>.HasFloatingPoint => false;
            bool INumericStatic<ByteM>.HasInfinity => false;
            bool INumericStatic<ByteM>.HasNaN => false;
            bool INumericStatic<ByteM>.IsFinite(ByteM x) => true;
            bool INumericStatic<ByteM>.IsInfinity(ByteM x) => false;
            bool INumericStatic<ByteM>.IsNaN(ByteM x) => false;
            bool INumericStatic<ByteM>.IsNegative(ByteM x) => false;
            bool INumericStatic<ByteM>.IsNegativeInfinity(ByteM x) => false;
            bool INumericStatic<ByteM>.IsNormal(ByteM x) => false;
            bool INumericStatic<ByteM>.IsPositiveInfinity(ByteM x) => false;
            bool INumericStatic<ByteM>.IsReal => false;
            bool INumericStatic<ByteM>.IsSigned => false;
            bool INumericStatic<ByteM>.IsSubnormal(ByteM x) => false;
            ByteM INumericStatic<ByteM>.Epsilon => 1;
            ByteM INumericStatic<ByteM>.MaxUnit => 1;
            ByteM INumericStatic<ByteM>.MaxValue => MaxValue;
            ByteM INumericStatic<ByteM>.MinUnit => 0;
            ByteM INumericStatic<ByteM>.MinValue => MinValue;
            ByteM INumericStatic<ByteM>.One => 1;
            ByteM INumericStatic<ByteM>.Zero => 0;

            ByteM IMath<ByteM>.Abs(ByteM value) => value;
            ByteM IMath<ByteM>.Acos(ByteM x) => ConvertN.ToByte(Math.Acos(x._value), Conversion.CastClamp);
            ByteM IMath<ByteM>.Acosh(ByteM x) => ConvertN.ToByte(MathShim.Acosh(x._value), Conversion.CastClamp);
            ByteM IMath<ByteM>.Asin(ByteM x) => ConvertN.ToByte(Math.Asin(x._value), Conversion.CastClamp);
            ByteM IMath<ByteM>.Asinh(ByteM x) => ConvertN.ToByte(MathShim.Asinh(x._value), Conversion.CastClamp);
            ByteM IMath<ByteM>.Atan(ByteM x) => ConvertN.ToByte(Math.Atan(x._value), Conversion.CastClamp);
            ByteM IMath<ByteM>.Atan2(ByteM x, ByteM y) => ConvertN.ToByte(Math.Atan2(x._value, y._value), Conversion.CastClamp);
            ByteM IMath<ByteM>.Atanh(ByteM x) => ConvertN.ToByte(MathShim.Atanh(x._value), Conversion.CastClamp);
            ByteM IMath<ByteM>.Cbrt(ByteM x) => ConvertN.ToByte(MathShim.Cbrt(x._value), Conversion.CastClamp);
            ByteM IMath<ByteM>.Ceiling(ByteM x) => x;
            ByteM IMath<ByteM>.Clamp(ByteM x, ByteM bound1, ByteM bound2) => bound1 > bound2 ? Math.Min(bound1._value, Math.Max(bound2._value, x._value)) : Math.Min(bound2._value, Math.Max(bound1._value, x._value));
            ByteM IMath<ByteM>.Cos(ByteM x) => ConvertN.ToByte(Math.Cos(x._value), Conversion.CastClamp);
            ByteM IMath<ByteM>.Cosh(ByteM x) => ConvertN.ToByte(Math.Cosh(x._value), Conversion.CastClamp);
            ByteM IMath<ByteM>.E { get; } = 2;
            ByteM IMath<ByteM>.Exp(ByteM x) => ConvertN.ToByte(Math.Exp(x._value), Conversion.CastClamp);
            ByteM IMath<ByteM>.Floor(ByteM x) => x;
            ByteM IMath<ByteM>.IEEERemainder(ByteM x, ByteM y) => ConvertN.ToByte(Math.IEEERemainder(x._value, y._value), Conversion.CastClamp);
            ByteM IMath<ByteM>.Log(ByteM x) => ConvertN.ToByte(Math.Log(x._value), Conversion.CastClamp);
            ByteM IMath<ByteM>.Log(ByteM x, ByteM y) => ConvertN.ToByte(Math.Log(x._value, y._value), Conversion.CastClamp);
            ByteM IMath<ByteM>.Log10(ByteM x) => ConvertN.ToByte(Math.Log10(x._value), Conversion.CastClamp);
            ByteM IMath<ByteM>.Max(ByteM x, ByteM y) => Math.Max(x._value, y._value);
            ByteM IMath<ByteM>.Min(ByteM x, ByteM y) => Math.Min(x._value, y._value);
            ByteM IMath<ByteM>.PI { get; } = 3;
            ByteM IMath<ByteM>.Pow(ByteM x, ByteM y) => Clamped.Pow(x._value, y._value);
            ByteM IMath<ByteM>.Round(ByteM x) => x;
            ByteM IMath<ByteM>.Round(ByteM x, int digits) => x;
            ByteM IMath<ByteM>.Round(ByteM x, int digits, MidpointRounding mode) => x;
            ByteM IMath<ByteM>.Round(ByteM x, MidpointRounding mode) => x;
            ByteM IMath<ByteM>.Sin(ByteM x) => ConvertN.ToByte(Math.Sin(x._value), Conversion.CastClamp);
            ByteM IMath<ByteM>.Sinh(ByteM x) => ConvertN.ToByte(Math.Sinh(x._value), Conversion.CastClamp);
            ByteM IMath<ByteM>.Sqrt(ByteM x) => ConvertN.ToByte(Math.Sqrt(x._value), Conversion.CastClamp);
            ByteM IMath<ByteM>.Tan(ByteM x) => ConvertN.ToByte(Math.Tan(x._value), Conversion.CastClamp);
            ByteM IMath<ByteM>.Tanh(ByteM x) => ConvertN.ToByte(Math.Tanh(x._value), Conversion.CastClamp);
            ByteM IMath<ByteM>.Tau { get; } = 6;
            ByteM IMath<ByteM>.Truncate(ByteM x) => x;
            int IMath<ByteM>.Sign(ByteM x) => x._value == 0 ? 0 : 1;

            int INumericBitConverter<ByteM>.ConvertedSize => sizeof(byte);
            ByteM INumericBitConverter<ByteM>.ToNumeric(byte[] value, int startIndex) => BitOperations.ToByte(value, startIndex);
            byte[] INumericBitConverter<ByteM>.GetBytes(ByteM value) => new byte[] { value._value };
#if HAS_SPANS
            ByteM INumericBitConverter<ByteM>.ToNumeric(ReadOnlySpan<byte> value) => BitOperations.ToByte(value);
            bool INumericBitConverter<ByteM>.TryWriteBytes(Span<byte> destination, ByteM value) => BitOperations.TryWriteByte(destination, value);
#endif

            bool IConvert<ByteM>.ToBoolean(ByteM value) => value._value != 0;
            byte IConvert<ByteM>.ToByte(ByteM value, Conversion mode) => value._value;
            decimal IConvert<ByteM>.ToDecimal(ByteM value, Conversion mode) => ConvertN.ToDecimal(value._value, mode.Clamped());
            double IConvert<ByteM>.ToDouble(ByteM value, Conversion mode) => ConvertN.ToDouble(value._value, mode.Clamped());
            float IConvert<ByteM>.ToSingle(ByteM value, Conversion mode) => ConvertN.ToSingle(value._value, mode.Clamped());
            int IConvert<ByteM>.ToInt32(ByteM value, Conversion mode) => ConvertN.ToInt32(value._value, mode.Clamped());
            long IConvert<ByteM>.ToInt64(ByteM value, Conversion mode) => ConvertN.ToInt64(value._value, mode.Clamped());
            sbyte IConvertExtended<ByteM>.ToSByte(ByteM value, Conversion mode) => ConvertN.ToSByte(value._value, mode.Clamped());
            short IConvert<ByteM>.ToInt16(ByteM value, Conversion mode) => ConvertN.ToInt16(value._value, mode.Clamped());
            string IConvert<ByteM>.ToString(ByteM value) => Convert.ToString(value._value);
            uint IConvertExtended<ByteM>.ToUInt32(ByteM value, Conversion mode) => ConvertN.ToUInt16(value._value, mode.Clamped());
            ulong IConvertExtended<ByteM>.ToUInt64(ByteM value, Conversion mode) => ConvertN.ToUInt64(value._value, mode.Clamped());
            ushort IConvertExtended<ByteM>.ToUInt16(ByteM value, Conversion mode) => ConvertN.ToByte(value._value, mode.Clamped());

            ByteM IConvert<ByteM>.ToNumeric(bool value) => value ? (byte)1 : (byte)0;
            ByteM IConvert<ByteM>.ToNumeric(byte value, Conversion mode) => ConvertN.ToByte(value, mode.Clamped());
            ByteM IConvert<ByteM>.ToNumeric(decimal value, Conversion mode) => ConvertN.ToByte(value, mode.Clamped());
            ByteM IConvert<ByteM>.ToNumeric(double value, Conversion mode) => ConvertN.ToByte(value, mode.Clamped());
            ByteM IConvert<ByteM>.ToNumeric(float value, Conversion mode) => ConvertN.ToByte(value, mode.Clamped());
            ByteM IConvert<ByteM>.ToNumeric(int value, Conversion mode) => ConvertN.ToByte(value, mode.Clamped());
            ByteM IConvert<ByteM>.ToNumeric(long value, Conversion mode) => ConvertN.ToByte(value, mode.Clamped());
            ByteM IConvertExtended<ByteM>.ToValue(sbyte value, Conversion mode) => ConvertN.ToByte(value, mode.Clamped());
            ByteM IConvert<ByteM>.ToNumeric(short value, Conversion mode) => ConvertN.ToByte(value, mode.Clamped());
            ByteM IConvert<ByteM>.ToNumeric(string value) => Convert.ToByte(value);
            ByteM IConvertExtended<ByteM>.ToNumeric(uint value, Conversion mode) => ConvertN.ToByte(value, mode.Clamped());
            ByteM IConvertExtended<ByteM>.ToNumeric(ulong value, Conversion mode) => ConvertN.ToByte(value, mode.Clamped());
            ByteM IConvertExtended<ByteM>.ToNumeric(ushort value, Conversion mode) => value;

            ByteM INumericStatic<ByteM>.Parse(string s, NumberStyles? style, IFormatProvider? provider)
                => Parse(s, style ?? NumberStyles.Integer, provider);

            ByteM INumericRandom<ByteM>.Generate(Random random) => random.NextByte();
            ByteM INumericRandom<ByteM>.Generate(Random random, ByteM maxValue) => random.NextByte(maxValue);
            ByteM INumericRandom<ByteM>.Generate(Random random, ByteM minValue, ByteM maxValue) => random.NextByte(minValue, maxValue);
            ByteM INumericRandom<ByteM>.Generate(Random random, Generation mode) => random.NextByte(mode);
            ByteM INumericRandom<ByteM>.Generate(Random random, ByteM minValue, ByteM maxValue, Generation mode) => random.NextByte(minValue, maxValue, mode);

            ByteM IVariantRandom<ByteM>.Generate(Random random, Variants variants) => random.NextByte(variants);
        }
    }
}
