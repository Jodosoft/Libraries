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
using System.Runtime.Serialization;
using Jodo.Numerics;
using Jodo.Primitives;
using Jodo.Primitives.Compatibility;

namespace Jodo.CheckedNumerics
{
    /// <summary>
    /// Represents an 8-bit signed integer that cannot overflow.
    /// </summary>
    [Serializable]
    [DebuggerDisplay("{ToString(),nq}")]
    public readonly struct SByteC : INumericExtended<SByteC>
    {
        public static readonly SByteC MaxValue = new SByteC(sbyte.MaxValue);
        public static readonly SByteC MinValue = new SByteC(sbyte.MinValue);

        private readonly sbyte _value;

        private SByteC(sbyte value)
        {
            _value = value;
        }

        private SByteC(SerializationInfo info, StreamingContext context) : this(info.GetSByte(nameof(SByteC))) { }
        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context) => info.AddValue(nameof(SByteC), _value);

        public int CompareTo(SByteC other) => _value.CompareTo(other._value);
        public int CompareTo(object? obj) => obj is SByteC other ? CompareTo(other) : 1;
        public bool Equals(SByteC other) => _value == other._value;
        public override bool Equals(object? obj) => obj is SByteC other && Equals(other);
        public override int GetHashCode() => _value.GetHashCode();
        public override string ToString() => _value.ToString();
        public string ToString(IFormatProvider formatProvider) => _value.ToString(formatProvider);
        public string ToString(string format) => _value.ToString(format);
        public string ToString(string? format, IFormatProvider? formatProvider) => _value.ToString(format, formatProvider);

        public static bool TryParse(string s, IFormatProvider? provider, out SByteC result) => TryHelper.Run(() => Parse(s, provider), out result);
        public static bool TryParse(string s, NumberStyles style, IFormatProvider? provider, out SByteC result) => TryHelper.Run(() => Parse(s, style, provider), out result);
        public static bool TryParse(string s, NumberStyles style, out SByteC result) => TryHelper.Run(() => Parse(s, style), out result);
        public static bool TryParse(string s, out SByteC result) => TryHelper.Run(() => Parse(s), out result);
        public static SByteC Parse(string s) => sbyte.Parse(s);
        public static SByteC Parse(string s, IFormatProvider? provider) => sbyte.Parse(s, provider);
        public static SByteC Parse(string s, NumberStyles style) => sbyte.Parse(s, style);
        public static SByteC Parse(string s, NumberStyles style, IFormatProvider? provider) => sbyte.Parse(s, style, provider);

        [CLSCompliant(false)] public static explicit operator SByteC(uint value) => new SByteC(ConvertN.ToSByte(value, Conversion.CastClamp));
        [CLSCompliant(false)] public static explicit operator SByteC(ulong value) => new SByteC(ConvertN.ToSByte(value, Conversion.CastClamp));
        [CLSCompliant(false)] public static explicit operator SByteC(ushort value) => new SByteC(ConvertN.ToSByte(value, Conversion.CastClamp));
        [CLSCompliant(false)] public static implicit operator SByteC(sbyte value) => new SByteC(value);
        public static explicit operator SByteC(byte value) => new SByteC(ConvertN.ToSByte(value, Conversion.CastClamp));
        public static explicit operator SByteC(decimal value) => new SByteC(ConvertN.ToSByte(value, Conversion.CastClamp));
        public static explicit operator SByteC(double value) => new SByteC(ConvertN.ToSByte(value, Conversion.CastClamp));
        public static explicit operator SByteC(float value) => new SByteC(ConvertN.ToSByte(value, Conversion.CastClamp));
        public static explicit operator SByteC(int value) => new SByteC(ConvertN.ToSByte(value, Conversion.CastClamp));
        public static explicit operator SByteC(long value) => new SByteC(ConvertN.ToSByte(value, Conversion.CastClamp));
        public static explicit operator SByteC(short value) => new SByteC(ConvertN.ToSByte(value, Conversion.CastClamp));

        [CLSCompliant(false)] public static explicit operator uint(SByteC value) => ConvertN.ToUInt32(value._value, Conversion.CastClamp);
        [CLSCompliant(false)] public static explicit operator ulong(SByteC value) => ConvertN.ToUInt64(value._value, Conversion.CastClamp);
        [CLSCompliant(false)] public static explicit operator ushort(SByteC value) => ConvertN.ToUInt16(value._value, Conversion.CastClamp);
        [CLSCompliant(false)] public static implicit operator sbyte(SByteC value) => value._value;
        public static explicit operator byte(SByteC value) => ConvertN.ToByte(value._value, Conversion.CastClamp);
        public static implicit operator decimal(SByteC value) => value._value;
        public static implicit operator double(SByteC value) => value._value;
        public static implicit operator float(SByteC value) => value._value;
        public static implicit operator int(SByteC value) => value._value;
        public static implicit operator long(SByteC value) => value._value;
        public static implicit operator short(SByteC value) => value._value;

        public static bool operator !=(SByteC left, SByteC right) => left._value != right._value;
        public static bool operator <(SByteC left, SByteC right) => left._value < right._value;
        public static bool operator <=(SByteC left, SByteC right) => left._value <= right._value;
        public static bool operator ==(SByteC left, SByteC right) => left._value == right._value;
        public static bool operator >(SByteC left, SByteC right) => left._value > right._value;
        public static bool operator >=(SByteC left, SByteC right) => left._value >= right._value;
        public static SByteC operator %(SByteC left, SByteC right) => CheckedMath.Remainder(left._value, right._value);
        public static SByteC operator &(SByteC left, SByteC right) => (sbyte)(left._value & right._value);
        public static SByteC operator -(SByteC left, SByteC right) => CheckedMath.Subtract(left._value, right._value);
        public static SByteC operator --(SByteC value) => CheckedMath.Subtract(value._value, (sbyte)1);
        public static SByteC operator -(SByteC value) => (sbyte)-value._value;
        public static SByteC operator *(SByteC left, SByteC right) => CheckedMath.Multiply(left._value, right._value);
        public static SByteC operator /(SByteC left, SByteC right) => CheckedMath.Divide(left._value, right._value);
        public static SByteC operator ^(SByteC left, SByteC right) => (sbyte)(left._value ^ right._value);
        public static SByteC operator |(SByteC left, SByteC right) => (sbyte)(left._value | right._value);
        public static SByteC operator ~(SByteC value) => (sbyte)~value._value;
        public static SByteC operator +(SByteC left, SByteC right) => CheckedMath.Add(left._value, right._value);
        public static SByteC operator +(SByteC value) => value;
        public static SByteC operator ++(SByteC value) => CheckedMath.Add(value._value, (sbyte)1);
        public static SByteC operator <<(SByteC left, int right) => (sbyte)(left._value << right);
        public static SByteC operator >>(SByteC left, int right) => (sbyte)(left._value >> right);

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

        bool INumeric<SByteC>.IsGreaterThan(SByteC value) => this > value;
        bool INumeric<SByteC>.IsGreaterThanOrEqualTo(SByteC value) => this >= value;
        bool INumeric<SByteC>.IsLessThan(SByteC value) => this < value;
        bool INumeric<SByteC>.IsLessThanOrEqualTo(SByteC value) => this <= value;
        SByteC INumeric<SByteC>.Add(SByteC value) => this + value;
        SByteC INumeric<SByteC>.BitwiseComplement() => ~this;
        SByteC INumeric<SByteC>.Divide(SByteC value) => this / value;
        SByteC INumeric<SByteC>.LeftShift(int count) => this << count;
        SByteC INumeric<SByteC>.LogicalAnd(SByteC value) => this & value;
        SByteC INumeric<SByteC>.LogicalExclusiveOr(SByteC value) => this ^ value;
        SByteC INumeric<SByteC>.LogicalOr(SByteC value) => this | value;
        SByteC INumeric<SByteC>.Multiply(SByteC value) => this * value;
        SByteC INumeric<SByteC>.Negative() => -this;
        SByteC INumeric<SByteC>.Positive() => +this;
        SByteC INumeric<SByteC>.Remainder(SByteC value) => this % value;
        SByteC INumeric<SByteC>.RightShift(int count) => this >> count;
        SByteC INumeric<SByteC>.Subtract(SByteC value) => this - value;

        IBitConvert<SByteC> IProvider<IBitConvert<SByteC>>.GetInstance() => Utilities.Instance;
        IConvert<SByteC> IProvider<IConvert<SByteC>>.GetInstance() => Utilities.Instance;
        IConvertExtended<SByteC> IProvider<IConvertExtended<SByteC>>.GetInstance() => Utilities.Instance;
        IMath<SByteC> IProvider<IMath<SByteC>>.GetInstance() => Utilities.Instance;
        INumericRandom<SByteC> IProvider<INumericRandom<SByteC>>.GetInstance() => Utilities.Instance;
        INumericStatic<SByteC> IProvider<INumericStatic<SByteC>>.GetInstance() => Utilities.Instance;
        IVariantRandom<SByteC> IProvider<IVariantRandom<SByteC>>.GetInstance() => Utilities.Instance;

        private sealed class Utilities :
            IBitConvert<SByteC>,
            IConvert<SByteC>,
            IConvertExtended<SByteC>,
            IMath<SByteC>,
            INumericRandom<SByteC>,
            INumericStatic<SByteC>,
            IVariantRandom<SByteC>
        {
            public static readonly Utilities Instance = new Utilities();

            bool INumericStatic<SByteC>.HasFloatingPoint => false;
            bool INumericStatic<SByteC>.HasInfinity => false;
            bool INumericStatic<SByteC>.HasNaN => false;
            bool INumericStatic<SByteC>.IsFinite(SByteC x) => true;
            bool INumericStatic<SByteC>.IsInfinity(SByteC x) => false;
            bool INumericStatic<SByteC>.IsNaN(SByteC x) => false;
            bool INumericStatic<SByteC>.IsNegative(SByteC x) => x._value < 0;
            bool INumericStatic<SByteC>.IsNegativeInfinity(SByteC x) => false;
            bool INumericStatic<SByteC>.IsNormal(SByteC x) => false;
            bool INumericStatic<SByteC>.IsPositiveInfinity(SByteC x) => false;
            bool INumericStatic<SByteC>.IsReal => false;
            bool INumericStatic<SByteC>.IsSigned => true;
            bool INumericStatic<SByteC>.IsSubnormal(SByteC x) => false;
            SByteC INumericStatic<SByteC>.Epsilon => 1;
            SByteC INumericStatic<SByteC>.MaxUnit => 1;
            SByteC INumericStatic<SByteC>.MaxValue => MaxValue;
            SByteC INumericStatic<SByteC>.MinUnit => -1;
            SByteC INumericStatic<SByteC>.MinValue => MinValue;
            SByteC INumericStatic<SByteC>.One => 1;
            SByteC INumericStatic<SByteC>.Ten => 10;
            SByteC INumericStatic<SByteC>.Two => 2;
            SByteC INumericStatic<SByteC>.Zero => 0;

            SByteC IMath<SByteC>.Abs(SByteC value) => Math.Abs(value._value);
            SByteC IMath<SByteC>.Acos(SByteC x) => (SByteC)Math.Acos(x._value);
            SByteC IMath<SByteC>.Acosh(SByteC x) => (SByteC)MathCompat.Acosh(x._value);
            SByteC IMath<SByteC>.Asin(SByteC x) => (SByteC)Math.Asin(x._value);
            SByteC IMath<SByteC>.Asinh(SByteC x) => (SByteC)MathCompat.Asinh(x._value);
            SByteC IMath<SByteC>.Atan(SByteC x) => (SByteC)Math.Atan(x._value);
            SByteC IMath<SByteC>.Atan2(SByteC x, SByteC y) => (SByteC)Math.Atan2(x._value, y._value);
            SByteC IMath<SByteC>.Atanh(SByteC x) => (SByteC)MathCompat.Atanh(x._value);
            SByteC IMath<SByteC>.Cbrt(SByteC x) => (SByteC)MathCompat.Cbrt(x._value);
            SByteC IMath<SByteC>.Ceiling(SByteC x) => x;
            SByteC IMath<SByteC>.Clamp(SByteC x, SByteC bound1, SByteC bound2) => bound1 > bound2 ? Math.Min(bound1._value, Math.Max(bound2._value, x._value)) : Math.Min(bound2._value, Math.Max(bound1._value, x._value));
            SByteC IMath<SByteC>.Cos(SByteC x) => (SByteC)Math.Cos(x._value);
            SByteC IMath<SByteC>.Cosh(SByteC x) => (SByteC)Math.Cosh(x._value);
            SByteC IMath<SByteC>.DegreesToRadians(SByteC x) => (SByteC)CheckedMath.Multiply(x, BitOperations.RadiansPerDegree);
            SByteC IMath<SByteC>.E { get; } = 2;
            SByteC IMath<SByteC>.Exp(SByteC x) => (SByteC)Math.Exp(x._value);
            SByteC IMath<SByteC>.Floor(SByteC x) => x;
            SByteC IMath<SByteC>.IEEERemainder(SByteC x, SByteC y) => (SByteC)Math.IEEERemainder(x._value, y._value);
            SByteC IMath<SByteC>.Log(SByteC x) => (SByteC)Math.Log(x._value);
            SByteC IMath<SByteC>.Log(SByteC x, SByteC y) => (SByteC)Math.Log(x._value, y._value);
            SByteC IMath<SByteC>.Log10(SByteC x) => (SByteC)Math.Log10(x._value);
            SByteC IMath<SByteC>.Max(SByteC x, SByteC y) => Math.Max(x._value, y._value);
            SByteC IMath<SByteC>.Min(SByteC x, SByteC y) => Math.Min(x._value, y._value);
            SByteC IMath<SByteC>.PI { get; } = 3;
            SByteC IMath<SByteC>.Pow(SByteC x, SByteC y) => CheckedMath.Pow(x._value, y._value);
            SByteC IMath<SByteC>.RadiansToDegrees(SByteC x) => (SByteC)CheckedMath.Multiply(x, BitOperations.DegreesPerRadian);
            SByteC IMath<SByteC>.Round(SByteC x) => x;
            SByteC IMath<SByteC>.Round(SByteC x, int digits) => x;
            SByteC IMath<SByteC>.Round(SByteC x, int digits, MidpointRounding mode) => x;
            SByteC IMath<SByteC>.Round(SByteC x, MidpointRounding mode) => x;
            SByteC IMath<SByteC>.Sin(SByteC x) => (SByteC)Math.Sin(x._value);
            SByteC IMath<SByteC>.Sinh(SByteC x) => (SByteC)Math.Sinh(x._value);
            SByteC IMath<SByteC>.Sqrt(SByteC x) => (SByteC)Math.Sqrt(x._value);
            SByteC IMath<SByteC>.Tan(SByteC x) => (SByteC)Math.Tan(x._value);
            SByteC IMath<SByteC>.Tanh(SByteC x) => (SByteC)Math.Tanh(x._value);
            SByteC IMath<SByteC>.Tau { get; } = 6;
            SByteC IMath<SByteC>.Truncate(SByteC x) => x;
            int IMath<SByteC>.Sign(SByteC x) => Math.Sign(x._value);

            SByteC IBitConvert<SByteC>.Read(IReader<byte> stream) => unchecked((sbyte)stream.Read(1)[0]);
            void IBitConvert<SByteC>.Write(SByteC value, IWriter<byte> stream) => stream.Write((byte)value._value);

            bool IConvert<SByteC>.ToBoolean(SByteC value) => value._value != 0;
            byte IConvert<SByteC>.ToByte(SByteC value, Conversion mode) => ConvertN.ToByte(value._value, mode.Clamped());
            decimal IConvert<SByteC>.ToDecimal(SByteC value, Conversion mode) => ConvertN.ToDecimal(value._value, mode.Clamped());
            double IConvert<SByteC>.ToDouble(SByteC value, Conversion mode) => ConvertN.ToDouble(value._value, mode.Clamped());
            float IConvert<SByteC>.ToSingle(SByteC value, Conversion mode) => ConvertN.ToSingle(value._value, mode.Clamped());
            int IConvert<SByteC>.ToInt32(SByteC value, Conversion mode) => ConvertN.ToInt32(value._value, mode.Clamped());
            long IConvert<SByteC>.ToInt64(SByteC value, Conversion mode) => ConvertN.ToInt64(value._value, mode.Clamped());
            sbyte IConvertExtended<SByteC>.ToSByte(SByteC value, Conversion mode) => value._value;
            short IConvert<SByteC>.ToInt16(SByteC value, Conversion mode) => ConvertN.ToInt16(value._value, mode.Clamped());
            string IConvert<SByteC>.ToString(SByteC value) => Convert.ToString(value._value);
            uint IConvertExtended<SByteC>.ToUInt32(SByteC value, Conversion mode) => ConvertN.ToUInt32(value._value, mode.Clamped());
            ulong IConvertExtended<SByteC>.ToUInt64(SByteC value, Conversion mode) => ConvertN.ToUInt64(value._value, mode.Clamped());
            ushort IConvertExtended<SByteC>.ToUInt16(SByteC value, Conversion mode) => ConvertN.ToUInt16(value._value, mode.Clamped());

            SByteC IConvert<SByteC>.ToNumeric(bool value) => value ? (sbyte)1 : (sbyte)0;
            SByteC IConvert<SByteC>.ToNumeric(byte value, Conversion mode) => ConvertN.ToSByte(value, mode.Clamped());
            SByteC IConvert<SByteC>.ToNumeric(decimal value, Conversion mode) => ConvertN.ToSByte(value, mode.Clamped());
            SByteC IConvert<SByteC>.ToNumeric(double value, Conversion mode) => ConvertN.ToSByte(value, mode.Clamped());
            SByteC IConvert<SByteC>.ToNumeric(float value, Conversion mode) => ConvertN.ToSByte(value, mode.Clamped());
            SByteC IConvert<SByteC>.ToNumeric(int value, Conversion mode) => ConvertN.ToSByte(value, mode.Clamped());
            SByteC IConvert<SByteC>.ToNumeric(long value, Conversion mode) => ConvertN.ToSByte(value, mode.Clamped());
            SByteC IConvertExtended<SByteC>.ToValue(sbyte value, Conversion mode) => value;
            SByteC IConvert<SByteC>.ToNumeric(short value, Conversion mode) => ConvertN.ToSByte(value, mode.Clamped());
            SByteC IConvert<SByteC>.ToNumeric(string value) => Convert.ToSByte(value);
            SByteC IConvertExtended<SByteC>.ToNumeric(uint value, Conversion mode) => ConvertN.ToSByte(value, mode.Clamped());
            SByteC IConvertExtended<SByteC>.ToNumeric(ulong value, Conversion mode) => ConvertN.ToSByte(value, mode.Clamped());
            SByteC IConvertExtended<SByteC>.ToNumeric(ushort value, Conversion mode) => ConvertN.ToSByte(value, mode.Clamped());

            SByteC INumericStatic<SByteC>.Parse(string s, NumberStyles? style, IFormatProvider? provider)
                => Parse(s, style ?? NumberStyles.Integer, provider);

            SByteC INumericRandom<SByteC>.Next(Random random) => random.NextSByte();
            SByteC INumericRandom<SByteC>.Next(Random random, SByteC maxValue) => random.NextSByte(maxValue);
            SByteC INumericRandom<SByteC>.Next(Random random, SByteC minValue, SByteC maxValue) => random.NextSByte(minValue, maxValue);
            SByteC INumericRandom<SByteC>.Next(Random random, Generation mode) => random.NextSByte(mode);
            SByteC INumericRandom<SByteC>.Next(Random random, SByteC minValue, SByteC maxValue, Generation mode) => random.NextSByte(minValue, maxValue, mode);

            SByteC IVariantRandom<SByteC>.Next(Random random, Scenarios scenarios) => NumericVariant.Generate<SByteC>(random, scenarios);
        }
    }
}
