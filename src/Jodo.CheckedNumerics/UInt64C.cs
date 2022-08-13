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
    /// Represents a 64-bit unsigned integer that cannot overflow.
    /// </summary>
    [Serializable]
    [DebuggerDisplay("{ToString(),nq}")]
    public readonly struct UInt64C : INumericExtended<UInt64C>
    {
        public static readonly UInt64C MaxValue = new UInt64C(ulong.MaxValue);
        public static readonly UInt64C MinValue = new UInt64C(ulong.MinValue);

        private readonly ulong _value;

        private UInt64C(ulong value)
        {
            _value = value;
        }

        private UInt64C(SerializationInfo info, StreamingContext context) : this(info.GetUInt64(nameof(UInt64C))) { }
        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context) => info.AddValue(nameof(UInt64C), _value);

        public int CompareTo(object? obj) => obj is UInt64C other ? CompareTo(other) : 1;
        public int CompareTo(UInt64C other) => _value.CompareTo(other._value);
        public bool Equals(UInt64C other) => _value == other._value;
        public override bool Equals(object? obj) => obj is UInt64C other && Equals(other);
        public override int GetHashCode() => _value.GetHashCode();
        public override string ToString() => _value.ToString();
        public string ToString(IFormatProvider formatProvider) => _value.ToString(formatProvider);
        public string ToString(string format) => _value.ToString(format);
        public string ToString(string? format, IFormatProvider? formatProvider) => _value.ToString(format, formatProvider);

        public static bool TryParse(string s, IFormatProvider? provider, out UInt64C result) => TryHelper.Run(() => Parse(s, provider), out result);
        public static bool TryParse(string s, NumberStyles style, IFormatProvider? provider, out UInt64C result) => TryHelper.Run(() => Parse(s, style, provider), out result);
        public static bool TryParse(string s, NumberStyles style, out UInt64C result) => TryHelper.Run(() => Parse(s, style), out result);
        public static bool TryParse(string s, out UInt64C result) => TryHelper.Run(() => Parse(s), out result);
        public static UInt64C Parse(string s) => ulong.Parse(s);
        public static UInt64C Parse(string s, IFormatProvider? provider) => ulong.Parse(s, provider);
        public static UInt64C Parse(string s, NumberStyles style) => ulong.Parse(s, style);
        public static UInt64C Parse(string s, NumberStyles style, IFormatProvider? provider) => ulong.Parse(s, style, provider);

        [CLSCompliant(false)] public static explicit operator UInt64C(sbyte value) => new UInt64C(ConvertN.ToUInt64(value, Conversion.CastClamp));
        [CLSCompliant(false)] public static implicit operator UInt64C(uint value) => new UInt64C(value);
        [CLSCompliant(false)] public static implicit operator UInt64C(ulong value) => new UInt64C(value);
        [CLSCompliant(false)] public static implicit operator UInt64C(ushort value) => new UInt64C(value);
        public static explicit operator UInt64C(decimal value) => new UInt64C(ConvertN.ToUInt64(value, Conversion.CastClamp));
        public static explicit operator UInt64C(double value) => new UInt64C(ConvertN.ToUInt64(value, Conversion.CastClamp));
        public static explicit operator UInt64C(float value) => new UInt64C(ConvertN.ToUInt64(value, Conversion.CastClamp));
        public static explicit operator UInt64C(int value) => new UInt64C(ConvertN.ToUInt64(value, Conversion.CastClamp));
        public static explicit operator UInt64C(long value) => new UInt64C(ConvertN.ToUInt64(value, Conversion.CastClamp));
        public static explicit operator UInt64C(short value) => new UInt64C(ConvertN.ToUInt64(value, Conversion.CastClamp));
        public static implicit operator UInt64C(byte value) => new UInt64C(value);

        [CLSCompliant(false)] public static explicit operator sbyte(UInt64C value) => ConvertN.ToSByte(value._value, Conversion.CastClamp);
        [CLSCompliant(false)] public static explicit operator uint(UInt64C value) => ConvertN.ToUInt32(value._value, Conversion.CastClamp);
        [CLSCompliant(false)] public static explicit operator ushort(UInt64C value) => ConvertN.ToUInt16(value._value, Conversion.CastClamp);
        [CLSCompliant(false)] public static implicit operator ulong(UInt64C value) => value._value;
        public static explicit operator byte(UInt64C value) => ConvertN.ToByte(value._value, Conversion.CastClamp);
        public static explicit operator int(UInt64C value) => ConvertN.ToInt32(value._value, Conversion.CastClamp);
        public static explicit operator long(UInt64C value) => ConvertN.ToInt64(value._value, Conversion.CastClamp);
        public static explicit operator short(UInt64C value) => ConvertN.ToInt16(value._value, Conversion.CastClamp);
        public static implicit operator decimal(UInt64C value) => value._value;
        public static implicit operator double(UInt64C value) => value._value;
        public static implicit operator float(UInt64C value) => value._value;

        public static bool operator !=(UInt64C left, UInt64C right) => left._value != right._value;
        public static bool operator <(UInt64C left, UInt64C right) => left._value < right._value;
        public static bool operator <=(UInt64C left, UInt64C right) => left._value <= right._value;
        public static bool operator ==(UInt64C left, UInt64C right) => left._value == right._value;
        public static bool operator >(UInt64C left, UInt64C right) => left._value > right._value;
        public static bool operator >=(UInt64C left, UInt64C right) => left._value >= right._value;
        public static UInt64C operator %(UInt64C left, UInt64C right) => CheckedMath.Remainder(left._value, right._value);
        public static UInt64C operator &(UInt64C left, UInt64C right) => left._value & right._value;
        public static UInt64C operator -(UInt64C _) => MinValue;
        public static UInt64C operator -(UInt64C left, UInt64C right) => CheckedMath.Subtract(left._value, right._value);
        public static UInt64C operator --(UInt64C value) => value - 1;
        public static UInt64C operator *(UInt64C left, UInt64C right) => CheckedMath.Multiply(left._value, right._value);
        public static UInt64C operator /(UInt64C left, UInt64C right) => CheckedMath.Divide(left._value, right._value);
        public static UInt64C operator ^(UInt64C left, UInt64C right) => left._value ^ right._value;
        public static UInt64C operator |(UInt64C left, UInt64C right) => left._value | right._value;
        public static UInt64C operator ~(UInt64C value) => ~value._value;
        public static UInt64C operator +(UInt64C left, UInt64C right) => CheckedMath.Add(left._value, right._value);
        public static UInt64C operator +(UInt64C value) => value;
        public static UInt64C operator ++(UInt64C value) => value + 1;
        public static UInt64C operator <<(UInt64C left, int right) => left._value << right;
        public static UInt64C operator >>(UInt64C left, int right) => left._value >> right;

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

        bool INumeric<UInt64C>.IsGreaterThan(UInt64C value) => this > value;
        bool INumeric<UInt64C>.IsGreaterThanOrEqualTo(UInt64C value) => this >= value;
        bool INumeric<UInt64C>.IsLessThan(UInt64C value) => this < value;
        bool INumeric<UInt64C>.IsLessThanOrEqualTo(UInt64C value) => this <= value;
        UInt64C INumeric<UInt64C>.Add(UInt64C value) => this + value;
        UInt64C INumeric<UInt64C>.BitwiseComplement() => ~this;
        UInt64C INumeric<UInt64C>.Divide(UInt64C value) => this / value;
        UInt64C INumeric<UInt64C>.LeftShift(int count) => this << count;
        UInt64C INumeric<UInt64C>.LogicalAnd(UInt64C value) => this & value;
        UInt64C INumeric<UInt64C>.LogicalExclusiveOr(UInt64C value) => this ^ value;
        UInt64C INumeric<UInt64C>.LogicalOr(UInt64C value) => this | value;
        UInt64C INumeric<UInt64C>.Multiply(UInt64C value) => this * value;
        UInt64C INumeric<UInt64C>.Negative() => -this;
        UInt64C INumeric<UInt64C>.Positive() => +this;
        UInt64C INumeric<UInt64C>.Remainder(UInt64C value) => this % value;
        UInt64C INumeric<UInt64C>.RightShift(int count) => this >> count;
        UInt64C INumeric<UInt64C>.Subtract(UInt64C value) => this - value;

        IBitConvert<UInt64C> IProvider<IBitConvert<UInt64C>>.GetInstance() => Utilities.Instance;
        IConvert<UInt64C> IProvider<IConvert<UInt64C>>.GetInstance() => Utilities.Instance;
        IConvertExtended<UInt64C> IProvider<IConvertExtended<UInt64C>>.GetInstance() => Utilities.Instance;
        IMath<UInt64C> IProvider<IMath<UInt64C>>.GetInstance() => Utilities.Instance;
        INumericStatic<UInt64C> IProvider<INumericStatic<UInt64C>>.GetInstance() => Utilities.Instance;
        IRandom<UInt64C> IProvider<IRandom<UInt64C>>.GetInstance() => Utilities.Instance;
        IStringConvert<UInt64C> IProvider<IStringConvert<UInt64C>>.GetInstance() => Utilities.Instance;

        private sealed class Utilities :
            IBitConvert<UInt64C>,
            IConvert<UInt64C>,
            IConvertExtended<UInt64C>,
            IMath<UInt64C>,
            INumericStatic<UInt64C>,
            IRandom<UInt64C>,
            IStringConvert<UInt64C>
        {
            public static readonly Utilities Instance = new Utilities();

            bool INumericStatic<UInt64C>.HasFloatingPoint => false;
            bool INumericStatic<UInt64C>.HasInfinity => false;
            bool INumericStatic<UInt64C>.HasNaN => false;
            bool INumericStatic<UInt64C>.IsFinite(UInt64C x) => true;
            bool INumericStatic<UInt64C>.IsInfinity(UInt64C x) => false;
            bool INumericStatic<UInt64C>.IsNaN(UInt64C x) => false;
            bool INumericStatic<UInt64C>.IsNegative(UInt64C x) => false;
            bool INumericStatic<UInt64C>.IsNegativeInfinity(UInt64C x) => false;
            bool INumericStatic<UInt64C>.IsNormal(UInt64C x) => false;
            bool INumericStatic<UInt64C>.IsPositiveInfinity(UInt64C x) => false;
            bool INumericStatic<UInt64C>.IsReal => false;
            bool INumericStatic<UInt64C>.IsSigned => false;
            bool INumericStatic<UInt64C>.IsSubnormal(UInt64C x) => false;
            UInt64C INumericStatic<UInt64C>.Epsilon => 1;
            UInt64C INumericStatic<UInt64C>.MaxUnit => 1;
            UInt64C INumericStatic<UInt64C>.MaxValue => MaxValue;
            UInt64C INumericStatic<UInt64C>.MinUnit => 0;
            UInt64C INumericStatic<UInt64C>.MinValue => MinValue;
            UInt64C INumericStatic<UInt64C>.One => 1;
            UInt64C INumericStatic<UInt64C>.Ten => 10;
            UInt64C INumericStatic<UInt64C>.Two => 2;
            UInt64C INumericStatic<UInt64C>.Zero => 0;

            int IMath<UInt64C>.Sign(UInt64C x) => x._value == 0 ? 0 : 1;
            UInt64C IMath<UInt64C>.Abs(UInt64C value) => value;
            UInt64C IMath<UInt64C>.Acos(UInt64C x) => (UInt64C)Math.Acos(x._value);
            UInt64C IMath<UInt64C>.Acosh(UInt64C x) => (UInt64C)MathCompat.Acosh(x._value);
            UInt64C IMath<UInt64C>.Asin(UInt64C x) => (UInt64C)Math.Asin(x._value);
            UInt64C IMath<UInt64C>.Asinh(UInt64C x) => (UInt64C)MathCompat.Asinh(x._value);
            UInt64C IMath<UInt64C>.Atan(UInt64C x) => (UInt64C)Math.Atan(x._value);
            UInt64C IMath<UInt64C>.Atan2(UInt64C x, UInt64C y) => (UInt64C)Math.Atan2(x._value, y._value);
            UInt64C IMath<UInt64C>.Atanh(UInt64C x) => (UInt64C)MathCompat.Atanh(x._value);
            UInt64C IMath<UInt64C>.Cbrt(UInt64C x) => (UInt64C)MathCompat.Cbrt(x._value);
            UInt64C IMath<UInt64C>.Ceiling(UInt64C x) => x;
            UInt64C IMath<UInt64C>.Clamp(UInt64C x, UInt64C bound1, UInt64C bound2) => bound1 > bound2 ? Math.Min(bound1._value, Math.Max(bound2._value, x._value)) : Math.Min(bound2._value, Math.Max(bound1._value, x._value));
            UInt64C IMath<UInt64C>.Cos(UInt64C x) => (UInt64C)Math.Cos(x._value);
            UInt64C IMath<UInt64C>.Cosh(UInt64C x) => (UInt64C)Math.Cosh(x._value);
            UInt64C IMath<UInt64C>.DegreesToRadians(UInt64C x) => (UInt64C)CheckedMath.Multiply(x, NumericUtilities.RadiansPerDegree);
            UInt64C IMath<UInt64C>.E { get; } = 2;
            UInt64C IMath<UInt64C>.Exp(UInt64C x) => (UInt64C)Math.Exp(x._value);
            UInt64C IMath<UInt64C>.Floor(UInt64C x) => x;
            UInt64C IMath<UInt64C>.IEEERemainder(UInt64C x, UInt64C y) => (UInt64C)Math.IEEERemainder(x._value, y._value);
            UInt64C IMath<UInt64C>.Log(UInt64C x) => (UInt64C)Math.Log(x._value);
            UInt64C IMath<UInt64C>.Log(UInt64C x, UInt64C y) => (UInt64C)Math.Log(x._value, y._value);
            UInt64C IMath<UInt64C>.Log10(UInt64C x) => (UInt64C)Math.Log10(x._value);
            UInt64C IMath<UInt64C>.Max(UInt64C x, UInt64C y) => Math.Max(x._value, y._value);
            UInt64C IMath<UInt64C>.Min(UInt64C x, UInt64C y) => Math.Min(x._value, y._value);
            UInt64C IMath<UInt64C>.PI { get; } = 3;
            UInt64C IMath<UInt64C>.Pow(UInt64C x, UInt64C y) => CheckedMath.Pow(x._value, y._value);
            UInt64C IMath<UInt64C>.RadiansToDegrees(UInt64C x) => (UInt64C)CheckedMath.Multiply(x, NumericUtilities.DegreesPerRadian);
            UInt64C IMath<UInt64C>.Round(UInt64C x) => x;
            UInt64C IMath<UInt64C>.Round(UInt64C x, int digits) => x;
            UInt64C IMath<UInt64C>.Round(UInt64C x, int digits, MidpointRounding mode) => x;
            UInt64C IMath<UInt64C>.Round(UInt64C x, MidpointRounding mode) => x;
            UInt64C IMath<UInt64C>.Sin(UInt64C x) => (UInt64C)Math.Sin(x._value);
            UInt64C IMath<UInt64C>.Sinh(UInt64C x) => (UInt64C)Math.Sinh(x._value);
            UInt64C IMath<UInt64C>.Sqrt(UInt64C x) => (UInt64C)Math.Sqrt(x._value);
            UInt64C IMath<UInt64C>.Tan(UInt64C x) => (UInt64C)Math.Tan(x._value);
            UInt64C IMath<UInt64C>.Tanh(UInt64C x) => (UInt64C)Math.Tanh(x._value);
            UInt64C IMath<UInt64C>.Tau { get; } = 6;
            UInt64C IMath<UInt64C>.Truncate(UInt64C x) => x;

            UInt64C IBitConvert<UInt64C>.Read(IReader<byte> stream) => BitConverter.ToUInt64(stream.Read(sizeof(ulong)), 0);
            void IBitConvert<UInt64C>.Write(UInt64C value, IWriter<byte> stream) => stream.Write(BitConverter.GetBytes(value._value));

            UInt64C IRandom<UInt64C>.Next(Random random) => random.NextUInt64();
            UInt64C IRandom<UInt64C>.Next(Random random, UInt64C bound1, UInt64C bound2) => random.NextUInt64(bound1._value, bound2._value);

            bool IConvert<UInt64C>.ToBoolean(UInt64C value) => value._value != 0;
            byte IConvert<UInt64C>.ToByte(UInt64C value, Conversion mode) => ConvertN.ToByte(value._value, mode.Clamped());
            decimal IConvert<UInt64C>.ToDecimal(UInt64C value, Conversion mode) => ConvertN.ToDecimal(value._value, mode.Clamped());
            double IConvert<UInt64C>.ToDouble(UInt64C value, Conversion mode) => ConvertN.ToDouble(value._value, mode.Clamped());
            float IConvert<UInt64C>.ToSingle(UInt64C value, Conversion mode) => ConvertN.ToSingle(value._value, mode.Clamped());
            int IConvert<UInt64C>.ToInt32(UInt64C value, Conversion mode) => ConvertN.ToInt32(value._value, mode.Clamped());
            long IConvert<UInt64C>.ToInt64(UInt64C value, Conversion mode) => ConvertN.ToInt64(value._value, mode.Clamped());
            sbyte IConvertExtended<UInt64C>.ToSByte(UInt64C value, Conversion mode) => ConvertN.ToSByte(value._value, mode.Clamped());
            short IConvert<UInt64C>.ToInt16(UInt64C value, Conversion mode) => ConvertN.ToInt16(value._value, mode.Clamped());
            string IConvert<UInt64C>.ToString(UInt64C value) => Convert.ToString(value._value);
            uint IConvertExtended<UInt64C>.ToUInt32(UInt64C value, Conversion mode) => ConvertN.ToUInt32(value._value, mode.Clamped());
            ulong IConvertExtended<UInt64C>.ToUInt64(UInt64C value, Conversion mode) => value._value;
            ushort IConvertExtended<UInt64C>.ToUInt16(UInt64C value, Conversion mode) => ConvertN.ToUInt16(value._value, mode.Clamped());

            UInt64C IConvert<UInt64C>.ToNumeric(bool value) => value ? 1 : (ulong)0;
            UInt64C IConvert<UInt64C>.ToNumeric(byte value, Conversion mode) => ConvertN.ToUInt64(value, mode.Clamped());
            UInt64C IConvert<UInt64C>.ToNumeric(decimal value, Conversion mode) => ConvertN.ToUInt64(value, mode.Clamped());
            UInt64C IConvert<UInt64C>.ToNumeric(double value, Conversion mode) => ConvertN.ToUInt64(value, mode.Clamped());
            UInt64C IConvert<UInt64C>.ToNumeric(float value, Conversion mode) => ConvertN.ToUInt64(value, mode.Clamped());
            UInt64C IConvert<UInt64C>.ToNumeric(int value, Conversion mode) => ConvertN.ToUInt64(value, mode.Clamped());
            UInt64C IConvert<UInt64C>.ToNumeric(long value, Conversion mode) => ConvertN.ToUInt64(value, mode.Clamped());
            UInt64C IConvertExtended<UInt64C>.ToValue(sbyte value, Conversion mode) => ConvertN.ToUInt64(value, mode.Clamped());
            UInt64C IConvert<UInt64C>.ToNumeric(short value, Conversion mode) => ConvertN.ToUInt64(value, mode.Clamped());
            UInt64C IConvert<UInt64C>.ToNumeric(string value) => Convert.ToUInt64(value);
            UInt64C IConvertExtended<UInt64C>.ToNumeric(uint value, Conversion mode) => ConvertN.ToUInt64(value, mode.Clamped());
            UInt64C IConvertExtended<UInt64C>.ToNumeric(ulong value, Conversion mode) => value;
            UInt64C IConvertExtended<UInt64C>.ToNumeric(ushort value, Conversion mode) => ConvertN.ToUInt64(value, mode.Clamped());

            UInt64C IStringConvert<UInt64C>.Parse(string s, NumberStyles? style, IFormatProvider? provider)
                => Parse(s, style ?? NumberStyles.Integer, provider);
        }
    }
}
