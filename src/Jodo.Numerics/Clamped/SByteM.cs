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
    /// Represents an 8-bit signed integer that cannot overflow.
    /// </summary>
    [Serializable]
    [DebuggerDisplay("{ToString(),nq}")]
    public readonly struct SByteM : INumericExtended<SByteM>
    {
        public static readonly SByteM MaxValue = new SByteM(sbyte.MaxValue);
        public static readonly SByteM MinValue = new SByteM(sbyte.MinValue);

        private readonly sbyte _value;

        private SByteM(sbyte value)
        {
            _value = value;
        }

        private SByteM(SerializationInfo info, StreamingContext context) : this(info.GetSByte(nameof(SByteM))) { }
        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context) => info.AddValue(nameof(SByteM), _value);

        public int CompareTo(SByteM other) => _value.CompareTo(other._value);
        public int CompareTo(object? obj) => obj is SByteM other ? CompareTo(other) : 1;
        public bool Equals(SByteM other) => _value == other._value;
        public override bool Equals(object? obj) => obj is SByteM other && Equals(other);
        public override int GetHashCode() => _value.GetHashCode();
        public override string ToString() => _value.ToString();
        public string ToString(IFormatProvider formatProvider) => _value.ToString(formatProvider);
        public string ToString(string format) => _value.ToString(format);
        public string ToString(string? format, IFormatProvider? formatProvider) => _value.ToString(format, formatProvider);

        public static bool TryParse(string s, IFormatProvider? provider, out SByteM result) => FuncExtensions.Try(() => Parse(s, provider), out result);
        public static bool TryParse(string s, NumberStyles style, IFormatProvider? provider, out SByteM result) => FuncExtensions.Try(() => Parse(s, style, provider), out result);
        public static bool TryParse(string s, NumberStyles style, out SByteM result) => FuncExtensions.Try(() => Parse(s, style), out result);
        public static bool TryParse(string s, out SByteM result) => FuncExtensions.Try(() => Parse(s), out result);
        public static SByteM Parse(string s) => sbyte.Parse(s);
        public static SByteM Parse(string s, IFormatProvider? provider) => sbyte.Parse(s, provider);
        public static SByteM Parse(string s, NumberStyles style) => sbyte.Parse(s, style);
        public static SByteM Parse(string s, NumberStyles style, IFormatProvider? provider) => sbyte.Parse(s, style, provider);

        [CLSCompliant(false)] public static explicit operator SByteM(uint value) => new SByteM(ConvertN.ToSByte(value, Conversion.CastClamp));
        [CLSCompliant(false)] public static explicit operator SByteM(ulong value) => new SByteM(ConvertN.ToSByte(value, Conversion.CastClamp));
        [CLSCompliant(false)] public static explicit operator SByteM(ushort value) => new SByteM(ConvertN.ToSByte(value, Conversion.CastClamp));
        [CLSCompliant(false)] public static implicit operator SByteM(sbyte value) => new SByteM(value);
        public static explicit operator SByteM(byte value) => new SByteM(ConvertN.ToSByte(value, Conversion.CastClamp));
        public static explicit operator SByteM(decimal value) => new SByteM(ConvertN.ToSByte(value, Conversion.CastClamp));
        public static explicit operator SByteM(double value) => new SByteM(ConvertN.ToSByte(value, Conversion.CastClamp));
        public static explicit operator SByteM(float value) => new SByteM(ConvertN.ToSByte(value, Conversion.CastClamp));
        public static explicit operator SByteM(int value) => new SByteM(ConvertN.ToSByte(value, Conversion.CastClamp));
        public static explicit operator SByteM(long value) => new SByteM(ConvertN.ToSByte(value, Conversion.CastClamp));
        public static explicit operator SByteM(short value) => new SByteM(ConvertN.ToSByte(value, Conversion.CastClamp));

        [CLSCompliant(false)] public static explicit operator uint(SByteM value) => ConvertN.ToUInt32(value._value, Conversion.CastClamp);
        [CLSCompliant(false)] public static explicit operator ulong(SByteM value) => ConvertN.ToUInt64(value._value, Conversion.CastClamp);
        [CLSCompliant(false)] public static explicit operator ushort(SByteM value) => ConvertN.ToUInt16(value._value, Conversion.CastClamp);
        [CLSCompliant(false)] public static implicit operator sbyte(SByteM value) => value._value;
        public static explicit operator byte(SByteM value) => ConvertN.ToByte(value._value, Conversion.CastClamp);
        public static implicit operator decimal(SByteM value) => value._value;
        public static implicit operator double(SByteM value) => value._value;
        public static implicit operator float(SByteM value) => value._value;
        public static implicit operator int(SByteM value) => value._value;
        public static implicit operator long(SByteM value) => value._value;
        public static implicit operator short(SByteM value) => value._value;

        public static bool operator !=(SByteM left, SByteM right) => left._value != right._value;
        public static bool operator <(SByteM left, SByteM right) => left._value < right._value;
        public static bool operator <=(SByteM left, SByteM right) => left._value <= right._value;
        public static bool operator ==(SByteM left, SByteM right) => left._value == right._value;
        public static bool operator >(SByteM left, SByteM right) => left._value > right._value;
        public static bool operator >=(SByteM left, SByteM right) => left._value >= right._value;
        public static SByteM operator %(SByteM left, SByteM right) => Clamped.Remainder(left._value, right._value);
        public static SByteM operator &(SByteM left, SByteM right) => (sbyte)(left._value & right._value);
        public static SByteM operator -(SByteM left, SByteM right) => Clamped.Subtract(left._value, right._value);
        public static SByteM operator --(SByteM value) => Clamped.Subtract(value._value, (sbyte)1);
        public static SByteM operator -(SByteM value) => (sbyte)-value._value;
        public static SByteM operator *(SByteM left, SByteM right) => Clamped.Multiply(left._value, right._value);
        public static SByteM operator /(SByteM left, SByteM right) => Clamped.Divide(left._value, right._value);
        public static SByteM operator ^(SByteM left, SByteM right) => (sbyte)(left._value ^ right._value);
        public static SByteM operator |(SByteM left, SByteM right) => (sbyte)(left._value | right._value);
        public static SByteM operator ~(SByteM value) => (sbyte)~value._value;
        public static SByteM operator +(SByteM left, SByteM right) => Clamped.Add(left._value, right._value);
        public static SByteM operator +(SByteM value) => value;
        public static SByteM operator ++(SByteM value) => Clamped.Add(value._value, (sbyte)1);
        public static SByteM operator <<(SByteM left, int right) => (sbyte)(left._value << right);
        public static SByteM operator >>(SByteM left, int right) => (sbyte)(left._value >> right);

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
        sbyte IConvertible.ToSByte(IFormatProvider provider) => _value;
        short IConvertible.ToInt16(IFormatProvider provider) => ConvertN.ToInt16(_value, Conversion.Clamp);
        uint IConvertible.ToUInt32(IFormatProvider provider) => ConvertN.ToUInt32(_value, Conversion.Clamp);
        ulong IConvertible.ToUInt64(IFormatProvider provider) => ConvertN.ToUInt64(_value, Conversion.Clamp);
        ushort IConvertible.ToUInt16(IFormatProvider provider) => ConvertN.ToUInt16(_value, Conversion.Clamp);
        object IConvertible.ToType(Type conversionType, IFormatProvider provider) => this.ToTypeDefault(conversionType, provider);

        bool INumeric<SByteM>.IsGreaterThan(SByteM value) => this > value;
        bool INumeric<SByteM>.IsGreaterThanOrEqualTo(SByteM value) => this >= value;
        bool INumeric<SByteM>.IsLessThan(SByteM value) => this < value;
        bool INumeric<SByteM>.IsLessThanOrEqualTo(SByteM value) => this <= value;
        SByteM INumeric<SByteM>.Add(SByteM value) => this + value;
        SByteM INumeric<SByteM>.BitwiseComplement() => ~this;
        SByteM INumeric<SByteM>.Divide(SByteM value) => this / value;
        SByteM INumeric<SByteM>.LeftShift(int count) => this << count;
        SByteM INumeric<SByteM>.LogicalAnd(SByteM value) => this & value;
        SByteM INumeric<SByteM>.LogicalExclusiveOr(SByteM value) => this ^ value;
        SByteM INumeric<SByteM>.LogicalOr(SByteM value) => this | value;
        SByteM INumeric<SByteM>.Multiply(SByteM value) => this * value;
        SByteM INumeric<SByteM>.Negative() => -this;
        SByteM INumeric<SByteM>.Positive() => +this;
        SByteM INumeric<SByteM>.Remainder(SByteM value) => this % value;
        SByteM INumeric<SByteM>.RightShift(int count) => this >> count;
        SByteM INumeric<SByteM>.Subtract(SByteM value) => this - value;

        INumericBitConverter<SByteM> IProvider<INumericBitConverter<SByteM>>.GetInstance() => Utilities.Instance;
        IBinaryIO<SByteM> IProvider<IBinaryIO<SByteM>>.GetInstance() => Utilities.Instance;
        IConvert<SByteM> IProvider<IConvert<SByteM>>.GetInstance() => Utilities.Instance;
        IConvertExtended<SByteM> IProvider<IConvertExtended<SByteM>>.GetInstance() => Utilities.Instance;
        IMath<SByteM> IProvider<IMath<SByteM>>.GetInstance() => Utilities.Instance;
        INumericRandom<SByteM> IProvider<INumericRandom<SByteM>>.GetInstance() => Utilities.Instance;
        INumericStatic<SByteM> IProvider<INumericStatic<SByteM>>.GetInstance() => Utilities.Instance;
        IVariantRandom<SByteM> IProvider<IVariantRandom<SByteM>>.GetInstance() => Utilities.Instance;

        private sealed class Utilities :
            IBinaryIO<SByteM>,
            IConvert<SByteM>,
            IConvertExtended<SByteM>,
            IMath<SByteM>,
            INumericBitConverter<SByteM>,
            INumericRandom<SByteM>,
            INumericStatic<SByteM>,
            IVariantRandom<SByteM>
        {
            public static readonly Utilities Instance = new Utilities();

            void IBinaryIO<SByteM>.Write(BinaryWriter writer, SByteM value) => writer.Write(value);
            SByteM IBinaryIO<SByteM>.Read(BinaryReader reader) => reader.ReadSByte();

            bool INumericStatic<SByteM>.HasFloatingPoint => false;
            bool INumericStatic<SByteM>.HasInfinity => false;
            bool INumericStatic<SByteM>.HasNaN => false;
            bool INumericStatic<SByteM>.IsFinite(SByteM x) => true;
            bool INumericStatic<SByteM>.IsInfinity(SByteM x) => false;
            bool INumericStatic<SByteM>.IsNaN(SByteM x) => false;
            bool INumericStatic<SByteM>.IsNegative(SByteM x) => x._value < 0;
            bool INumericStatic<SByteM>.IsNegativeInfinity(SByteM x) => false;
            bool INumericStatic<SByteM>.IsNormal(SByteM x) => false;
            bool INumericStatic<SByteM>.IsPositiveInfinity(SByteM x) => false;
            bool INumericStatic<SByteM>.IsReal => false;
            bool INumericStatic<SByteM>.IsSigned => true;
            bool INumericStatic<SByteM>.IsSubnormal(SByteM x) => false;
            SByteM INumericStatic<SByteM>.Epsilon => 1;
            SByteM INumericStatic<SByteM>.MaxUnit => 1;
            SByteM INumericStatic<SByteM>.MaxValue => MaxValue;
            SByteM INumericStatic<SByteM>.MinUnit => -1;
            SByteM INumericStatic<SByteM>.MinValue => MinValue;
            SByteM INumericStatic<SByteM>.One => 1;
            SByteM INumericStatic<SByteM>.Zero => 0;

            SByteM IMath<SByteM>.Abs(SByteM value) => Math.Abs(value._value);
            SByteM IMath<SByteM>.Acos(SByteM x) => (SByteM)Math.Acos(x._value);
            SByteM IMath<SByteM>.Acosh(SByteM x) => (SByteM)MathShim.Acosh(x._value);
            SByteM IMath<SByteM>.Asin(SByteM x) => (SByteM)Math.Asin(x._value);
            SByteM IMath<SByteM>.Asinh(SByteM x) => (SByteM)MathShim.Asinh(x._value);
            SByteM IMath<SByteM>.Atan(SByteM x) => (SByteM)Math.Atan(x._value);
            SByteM IMath<SByteM>.Atan2(SByteM x, SByteM y) => (SByteM)Math.Atan2(x._value, y._value);
            SByteM IMath<SByteM>.Atanh(SByteM x) => (SByteM)MathShim.Atanh(x._value);
            SByteM IMath<SByteM>.Cbrt(SByteM x) => (SByteM)MathShim.Cbrt(x._value);
            SByteM IMath<SByteM>.Ceiling(SByteM x) => x;
            SByteM IMath<SByteM>.Clamp(SByteM x, SByteM bound1, SByteM bound2) => bound1 > bound2 ? Math.Min(bound1._value, Math.Max(bound2._value, x._value)) : Math.Min(bound2._value, Math.Max(bound1._value, x._value));
            SByteM IMath<SByteM>.Cos(SByteM x) => (SByteM)Math.Cos(x._value);
            SByteM IMath<SByteM>.Cosh(SByteM x) => (SByteM)Math.Cosh(x._value);
            SByteM IMath<SByteM>.E { get; } = 2;
            SByteM IMath<SByteM>.Exp(SByteM x) => (SByteM)Math.Exp(x._value);
            SByteM IMath<SByteM>.Floor(SByteM x) => x;
            SByteM IMath<SByteM>.IEEERemainder(SByteM x, SByteM y) => (SByteM)Math.IEEERemainder(x._value, y._value);
            SByteM IMath<SByteM>.Log(SByteM x) => (SByteM)Math.Log(x._value);
            SByteM IMath<SByteM>.Log(SByteM x, SByteM y) => (SByteM)Math.Log(x._value, y._value);
            SByteM IMath<SByteM>.Log10(SByteM x) => (SByteM)Math.Log10(x._value);
            SByteM IMath<SByteM>.Max(SByteM x, SByteM y) => Math.Max(x._value, y._value);
            SByteM IMath<SByteM>.Min(SByteM x, SByteM y) => Math.Min(x._value, y._value);
            SByteM IMath<SByteM>.PI { get; } = 3;
            SByteM IMath<SByteM>.Pow(SByteM x, SByteM y) => Clamped.Pow(x._value, y._value);
            SByteM IMath<SByteM>.Round(SByteM x) => x;
            SByteM IMath<SByteM>.Round(SByteM x, int digits) => x;
            SByteM IMath<SByteM>.Round(SByteM x, int digits, MidpointRounding mode) => x;
            SByteM IMath<SByteM>.Round(SByteM x, MidpointRounding mode) => x;
            SByteM IMath<SByteM>.Sin(SByteM x) => (SByteM)Math.Sin(x._value);
            SByteM IMath<SByteM>.Sinh(SByteM x) => (SByteM)Math.Sinh(x._value);
            SByteM IMath<SByteM>.Sqrt(SByteM x) => (SByteM)Math.Sqrt(x._value);
            SByteM IMath<SByteM>.Tan(SByteM x) => (SByteM)Math.Tan(x._value);
            SByteM IMath<SByteM>.Tanh(SByteM x) => (SByteM)Math.Tanh(x._value);
            SByteM IMath<SByteM>.Tau { get; } = 6;
            SByteM IMath<SByteM>.Truncate(SByteM x) => x;
            int IMath<SByteM>.Sign(SByteM x) => Math.Sign(x._value);

            int INumericBitConverter<SByteM>.ConvertedSize => sizeof(sbyte);
            SByteM INumericBitConverter<SByteM>.ToNumeric(byte[] value, int startIndex) => BitOperations.ToSByte(value, startIndex);
            byte[] INumericBitConverter<SByteM>.GetBytes(SByteM value) => new byte[] { (byte)value._value };
#if HAS_SPANS
            SByteM INumericBitConverter<SByteM>.ToNumeric(ReadOnlySpan<byte> value) => BitOperations.ToSByte(value);
            bool INumericBitConverter<SByteM>.TryWriteBytes(Span<byte> destination, SByteM value) => BitOperations.TryWriteSByte(destination, value);
#endif

            bool IConvert<SByteM>.ToBoolean(SByteM value) => value._value != 0;
            byte IConvert<SByteM>.ToByte(SByteM value, Conversion mode) => ConvertN.ToByte(value._value, mode.Clamped());
            decimal IConvert<SByteM>.ToDecimal(SByteM value, Conversion mode) => ConvertN.ToDecimal(value._value, mode.Clamped());
            double IConvert<SByteM>.ToDouble(SByteM value, Conversion mode) => ConvertN.ToDouble(value._value, mode.Clamped());
            float IConvert<SByteM>.ToSingle(SByteM value, Conversion mode) => ConvertN.ToSingle(value._value, mode.Clamped());
            int IConvert<SByteM>.ToInt32(SByteM value, Conversion mode) => ConvertN.ToInt32(value._value, mode.Clamped());
            long IConvert<SByteM>.ToInt64(SByteM value, Conversion mode) => ConvertN.ToInt64(value._value, mode.Clamped());
            sbyte IConvertExtended<SByteM>.ToSByte(SByteM value, Conversion mode) => value._value;
            short IConvert<SByteM>.ToInt16(SByteM value, Conversion mode) => ConvertN.ToInt16(value._value, mode.Clamped());
            string IConvert<SByteM>.ToString(SByteM value) => Convert.ToString(value._value);
            uint IConvertExtended<SByteM>.ToUInt32(SByteM value, Conversion mode) => ConvertN.ToUInt32(value._value, mode.Clamped());
            ulong IConvertExtended<SByteM>.ToUInt64(SByteM value, Conversion mode) => ConvertN.ToUInt64(value._value, mode.Clamped());
            ushort IConvertExtended<SByteM>.ToUInt16(SByteM value, Conversion mode) => ConvertN.ToUInt16(value._value, mode.Clamped());

            SByteM IConvert<SByteM>.ToNumeric(bool value) => value ? (sbyte)1 : (sbyte)0;
            SByteM IConvert<SByteM>.ToNumeric(byte value, Conversion mode) => ConvertN.ToSByte(value, mode.Clamped());
            SByteM IConvert<SByteM>.ToNumeric(decimal value, Conversion mode) => ConvertN.ToSByte(value, mode.Clamped());
            SByteM IConvert<SByteM>.ToNumeric(double value, Conversion mode) => ConvertN.ToSByte(value, mode.Clamped());
            SByteM IConvert<SByteM>.ToNumeric(float value, Conversion mode) => ConvertN.ToSByte(value, mode.Clamped());
            SByteM IConvert<SByteM>.ToNumeric(int value, Conversion mode) => ConvertN.ToSByte(value, mode.Clamped());
            SByteM IConvert<SByteM>.ToNumeric(long value, Conversion mode) => ConvertN.ToSByte(value, mode.Clamped());
            SByteM IConvertExtended<SByteM>.ToValue(sbyte value, Conversion mode) => value;
            SByteM IConvert<SByteM>.ToNumeric(short value, Conversion mode) => ConvertN.ToSByte(value, mode.Clamped());
            SByteM IConvert<SByteM>.ToNumeric(string value) => Convert.ToSByte(value);
            SByteM IConvertExtended<SByteM>.ToNumeric(uint value, Conversion mode) => ConvertN.ToSByte(value, mode.Clamped());
            SByteM IConvertExtended<SByteM>.ToNumeric(ulong value, Conversion mode) => ConvertN.ToSByte(value, mode.Clamped());
            SByteM IConvertExtended<SByteM>.ToNumeric(ushort value, Conversion mode) => ConvertN.ToSByte(value, mode.Clamped());

            SByteM INumericStatic<SByteM>.Parse(string s, NumberStyles? style, IFormatProvider? provider)
                => Parse(s, style ?? NumberStyles.Integer, provider);

            SByteM INumericRandom<SByteM>.Generate(Random random) => random.NextSByte();
            SByteM INumericRandom<SByteM>.Generate(Random random, SByteM maxValue) => random.NextSByte(maxValue);
            SByteM INumericRandom<SByteM>.Generate(Random random, SByteM minValue, SByteM maxValue) => random.NextSByte(minValue, maxValue);
            SByteM INumericRandom<SByteM>.Generate(Random random, Generation mode) => random.NextSByte(mode);
            SByteM INumericRandom<SByteM>.Generate(Random random, SByteM minValue, SByteM maxValue, Generation mode) => random.NextSByte(minValue, maxValue, mode);

            SByteM IVariantRandom<SByteM>.Generate(Random random, Variants variants) => random.NextSByte(variants);
        }
    }
}
