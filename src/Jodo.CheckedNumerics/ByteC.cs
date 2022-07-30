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
    /// Represents an 8-bit unsigned integer that cannot overflow.
    /// </summary>
    [Serializable]
    [DebuggerDisplay("{ToString(),nq}")]
    public readonly struct ByteC : INumericExtended<ByteC>
    {
        public static readonly ByteC MaxValue = new ByteC(byte.MaxValue);
        public static readonly ByteC MinValue = new ByteC(byte.MinValue);

        private readonly byte _value;

        private ByteC(byte value)
        {
            _value = value;
        }

        private ByteC(SerializationInfo info, StreamingContext context) : this(info.GetByte(nameof(ByteC))) { }
        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context) => info.AddValue(nameof(ByteC), _value);

        public int CompareTo(object? obj) => obj is ByteC other ? CompareTo(other) : 1;
        public int CompareTo(ByteC other) => _value.CompareTo(other._value);
        public bool Equals(ByteC other) => _value == other._value;
        public override bool Equals(object? obj) => obj is ByteC other && Equals(other);
        public override int GetHashCode() => _value.GetHashCode();
        public override string ToString() => _value.ToString();
        public string ToString(IFormatProvider formatProvider) => _value.ToString(formatProvider);
        public string ToString(string format) => _value.ToString(format);
        public string ToString(string? format, IFormatProvider? formatProvider) => _value.ToString(format, formatProvider);

        public static bool TryParse(string s, IFormatProvider? provider, out ByteC result) => TryHelper.Run(() => Parse(s, provider), out result);
        public static bool TryParse(string s, NumberStyles style, IFormatProvider? provider, out ByteC result) => TryHelper.Run(() => Parse(s, style, provider), out result);
        public static bool TryParse(string s, NumberStyles style, out ByteC result) => TryHelper.Run(() => Parse(s, style), out result);
        public static bool TryParse(string s, out ByteC result) => TryHelper.Run(() => Parse(s), out result);
        public static ByteC Parse(string s) => byte.Parse(s);
        public static ByteC Parse(string s, IFormatProvider? provider) => byte.Parse(s, provider);
        public static ByteC Parse(string s, NumberStyles style) => byte.Parse(s, style);
        public static ByteC Parse(string s, NumberStyles style, IFormatProvider? provider) => byte.Parse(s, style, provider);

        [CLSCompliant(false)] public static explicit operator ByteC(sbyte value) => new ByteC(NumericConvert.ToByte(value, Conversion.CastClamp));
        [CLSCompliant(false)] public static explicit operator ByteC(uint value) => new ByteC(NumericConvert.ToByte(value, Conversion.CastClamp));
        [CLSCompliant(false)] public static explicit operator ByteC(ulong value) => new ByteC(NumericConvert.ToByte(value, Conversion.CastClamp));
        [CLSCompliant(false)] public static implicit operator ByteC(ushort value) => new ByteC(NumericConvert.ToByte(value, Conversion.CastClamp));
        public static explicit operator ByteC(decimal value) => new ByteC(NumericConvert.ToByte(value, Conversion.CastClamp));
        public static explicit operator ByteC(double value) => new ByteC(NumericConvert.ToByte(value, Conversion.CastClamp));
        public static explicit operator ByteC(float value) => new ByteC(NumericConvert.ToByte(value, Conversion.CastClamp));
        public static explicit operator ByteC(int value) => new ByteC(NumericConvert.ToByte(value, Conversion.CastClamp));
        public static explicit operator ByteC(long value) => new ByteC(NumericConvert.ToByte(value, Conversion.CastClamp));
        public static explicit operator ByteC(short value) => new ByteC(NumericConvert.ToByte(value, Conversion.CastClamp));
        public static implicit operator ByteC(byte value) => new ByteC(value);

        [CLSCompliant(false)] public static explicit operator sbyte(ByteC value) => NumericConvert.ToSByte(value._value, Conversion.CastClamp);
        [CLSCompliant(false)] public static implicit operator uint(ByteC value) => value._value;
        [CLSCompliant(false)] public static implicit operator ulong(ByteC value) => value._value;
        [CLSCompliant(false)] public static implicit operator ushort(ByteC value) => value._value;
        public static explicit operator byte(ByteC value) => NumericConvert.ToByte(value._value, Conversion.CastClamp);
        public static explicit operator int(ByteC value) => NumericConvert.ToInt32(value._value, Conversion.CastClamp);
        public static explicit operator short(ByteC value) => NumericConvert.ToInt16(value._value, Conversion.CastClamp);
        public static implicit operator decimal(ByteC value) => value._value;
        public static implicit operator double(ByteC value) => value._value;
        public static implicit operator float(ByteC value) => value._value;
        public static implicit operator long(ByteC value) => value._value;

        public static bool operator !=(ByteC left, ByteC right) => left._value != right._value;
        public static bool operator <(ByteC left, ByteC right) => left._value < right._value;
        public static bool operator <=(ByteC left, ByteC right) => left._value <= right._value;
        public static bool operator ==(ByteC left, ByteC right) => left._value == right._value;
        public static bool operator >(ByteC left, ByteC right) => left._value > right._value;
        public static bool operator >=(ByteC left, ByteC right) => left._value >= right._value;
        public static ByteC operator %(ByteC left, ByteC right) => CheckedArithmetic.Remainder(left._value, right._value);
        public static ByteC operator &(ByteC left, ByteC right) => (byte)(left._value & right._value);
        public static ByteC operator -(ByteC _) => MinValue;
        public static ByteC operator -(ByteC left, ByteC right) => CheckedArithmetic.Subtract(left._value, right._value);
        public static ByteC operator --(ByteC value) => value - 1;
        public static ByteC operator *(ByteC left, ByteC right) => CheckedArithmetic.Multiply(left._value, right._value);
        public static ByteC operator /(ByteC left, ByteC right) => CheckedArithmetic.Divide(left._value, right._value);
        public static ByteC operator ^(ByteC left, ByteC right) => (byte)(left._value ^ right._value);
        public static ByteC operator |(ByteC left, ByteC right) => (byte)(left._value | right._value);
        public static ByteC operator ~(ByteC value) => (byte)~value._value;
        public static ByteC operator +(ByteC left, ByteC right) => CheckedArithmetic.Add(left._value, right._value);
        public static ByteC operator +(ByteC value) => value;
        public static ByteC operator ++(ByteC value) => value + 1;
        public static ByteC operator <<(ByteC left, int right) => (byte)(left._value << right);
        public static ByteC operator >>(ByteC left, int right) => (byte)(left._value >> right);

        TypeCode IConvertible.GetTypeCode() => _value.GetTypeCode();
        bool IConvertible.ToBoolean(IFormatProvider provider) => ((IConvertible)_value).ToBoolean(provider);
        char IConvertible.ToChar(IFormatProvider provider) => ((IConvertible)_value).ToChar(provider);
        sbyte IConvertible.ToSByte(IFormatProvider provider) => ((IConvertible)_value).ToSByte(provider);
        byte IConvertible.ToByte(IFormatProvider provider) => ((IConvertible)_value).ToByte(provider);
        short IConvertible.ToInt16(IFormatProvider provider) => ((IConvertible)_value).ToInt16(provider);
        ushort IConvertible.ToUInt16(IFormatProvider provider) => ((IConvertible)_value).ToUInt16(provider);
        int IConvertible.ToInt32(IFormatProvider provider) => ((IConvertible)_value).ToInt32(provider);
        uint IConvertible.ToUInt32(IFormatProvider provider) => ((IConvertible)_value).ToUInt32(provider);
        long IConvertible.ToInt64(IFormatProvider provider) => ((IConvertible)_value).ToInt64(provider);
        ulong IConvertible.ToUInt64(IFormatProvider provider) => ((IConvertible)_value).ToUInt64(provider);
        float IConvertible.ToSingle(IFormatProvider provider) => ((IConvertible)_value).ToSingle(provider);
        double IConvertible.ToDouble(IFormatProvider provider) => ((IConvertible)_value).ToDouble(provider);
        decimal IConvertible.ToDecimal(IFormatProvider provider) => ((IConvertible)_value).ToDecimal(provider);
        DateTime IConvertible.ToDateTime(IFormatProvider provider) => ((IConvertible)_value).ToDateTime(provider);
        object IConvertible.ToType(Type conversionType, IFormatProvider provider) => ((IConvertible)_value).ToType(conversionType, provider);

        bool INumeric<ByteC>.IsGreaterThan(ByteC value) => this > value;
        bool INumeric<ByteC>.IsGreaterThanOrEqualTo(ByteC value) => this >= value;
        bool INumeric<ByteC>.IsLessThan(ByteC value) => this < value;
        bool INumeric<ByteC>.IsLessThanOrEqualTo(ByteC value) => this <= value;
        ByteC INumeric<ByteC>.Add(ByteC value) => this + value;
        ByteC INumeric<ByteC>.BitwiseComplement() => ~this;
        ByteC INumeric<ByteC>.Divide(ByteC value) => this / value;
        ByteC INumeric<ByteC>.LeftShift(int count) => this << count;
        ByteC INumeric<ByteC>.LogicalAnd(ByteC value) => this & value;
        ByteC INumeric<ByteC>.LogicalExclusiveOr(ByteC value) => this ^ value;
        ByteC INumeric<ByteC>.LogicalOr(ByteC value) => this | value;
        ByteC INumeric<ByteC>.Multiply(ByteC value) => this * value;
        ByteC INumeric<ByteC>.Negative() => -this;
        ByteC INumeric<ByteC>.Positive() => +this;
        ByteC INumeric<ByteC>.Remainder(ByteC value) => this % value;
        ByteC INumeric<ByteC>.RightShift(int count) => this >> count;
        ByteC INumeric<ByteC>.Subtract(ByteC value) => this - value;

        IBitConverter<ByteC> IProvider<IBitConverter<ByteC>>.GetInstance() => Utilities.Instance;
        IConvert<ByteC> IProvider<IConvert<ByteC>>.GetInstance() => Utilities.Instance;
        IConvertExtended<ByteC> IProvider<IConvertExtended<ByteC>>.GetInstance() => Utilities.Instance;
        IMath<ByteC> IProvider<IMath<ByteC>>.GetInstance() => Utilities.Instance;
        INumericStatic<ByteC> IProvider<INumericStatic<ByteC>>.GetInstance() => Utilities.Instance;
        IRandom<ByteC> IProvider<IRandom<ByteC>>.GetInstance() => Utilities.Instance;
        IStringParser<ByteC> IProvider<IStringParser<ByteC>>.GetInstance() => Utilities.Instance;

        private sealed class Utilities :
            IBitConverter<ByteC>,
            IConvert<ByteC>,
            IConvertExtended<ByteC>,
            IMath<ByteC>,
            INumericStatic<ByteC>,
            IRandom<ByteC>,
            IStringParser<ByteC>
        {
            public static readonly Utilities Instance = new Utilities();

            bool INumericStatic<ByteC>.HasFloatingPoint => false;
            bool INumericStatic<ByteC>.HasInfinity => false;
            bool INumericStatic<ByteC>.HasNaN => false;
            bool INumericStatic<ByteC>.IsFinite(ByteC x) => true;
            bool INumericStatic<ByteC>.IsInfinity(ByteC x) => false;
            bool INumericStatic<ByteC>.IsNaN(ByteC x) => false;
            bool INumericStatic<ByteC>.IsNegative(ByteC x) => false;
            bool INumericStatic<ByteC>.IsNegativeInfinity(ByteC x) => false;
            bool INumericStatic<ByteC>.IsNormal(ByteC x) => false;
            bool INumericStatic<ByteC>.IsPositiveInfinity(ByteC x) => false;
            bool INumericStatic<ByteC>.IsReal => false;
            bool INumericStatic<ByteC>.IsSigned => false;
            bool INumericStatic<ByteC>.IsSubnormal(ByteC x) => false;
            ByteC INumericStatic<ByteC>.Epsilon => 1;
            ByteC INumericStatic<ByteC>.MaxUnit => 1;
            ByteC INumericStatic<ByteC>.MaxValue => MaxValue;
            ByteC INumericStatic<ByteC>.MinUnit => 0;
            ByteC INumericStatic<ByteC>.MinValue => MinValue;
            ByteC INumericStatic<ByteC>.One => 1;
            ByteC INumericStatic<ByteC>.Ten => 10;
            ByteC INumericStatic<ByteC>.Two => 2;
            ByteC INumericStatic<ByteC>.Zero => 0;

            ByteC IMath<ByteC>.Abs(ByteC value) => value;
            ByteC IMath<ByteC>.Acos(ByteC x) => NumericConvert.ToByte(Math.Acos(x._value), Conversion.CastClamp);
            ByteC IMath<ByteC>.Acosh(ByteC x) => NumericConvert.ToByte(MathCompat.Acosh(x._value), Conversion.CastClamp);
            ByteC IMath<ByteC>.Asin(ByteC x) => NumericConvert.ToByte(Math.Asin(x._value), Conversion.CastClamp);
            ByteC IMath<ByteC>.Asinh(ByteC x) => NumericConvert.ToByte(MathCompat.Asinh(x._value), Conversion.CastClamp);
            ByteC IMath<ByteC>.Atan(ByteC x) => NumericConvert.ToByte(Math.Atan(x._value), Conversion.CastClamp);
            ByteC IMath<ByteC>.Atan2(ByteC x, ByteC y) => NumericConvert.ToByte(Math.Atan2(x._value, y._value), Conversion.CastClamp);
            ByteC IMath<ByteC>.Atanh(ByteC x) => NumericConvert.ToByte(MathCompat.Atanh(x._value), Conversion.CastClamp);
            ByteC IMath<ByteC>.Cbrt(ByteC x) => NumericConvert.ToByte(MathCompat.Cbrt(x._value), Conversion.CastClamp);
            ByteC IMath<ByteC>.Ceiling(ByteC x) => x;
            ByteC IMath<ByteC>.Clamp(ByteC x, ByteC bound1, ByteC bound2) => bound1 > bound2 ? Math.Min(bound1._value, Math.Max(bound2._value, x._value)) : Math.Min(bound2._value, Math.Max(bound1._value, x._value));
            ByteC IMath<ByteC>.Cos(ByteC x) => NumericConvert.ToByte(Math.Cos(x._value), Conversion.CastClamp);
            ByteC IMath<ByteC>.Cosh(ByteC x) => NumericConvert.ToByte(Math.Cosh(x._value), Conversion.CastClamp);
            ByteC IMath<ByteC>.DegreesToRadians(ByteC x) => NumericConvert.ToByte(CheckedArithmetic.Multiply(x, NumericUtilities.RadiansPerDegree), Conversion.CastClamp);
            ByteC IMath<ByteC>.E { get; } = 2;
            ByteC IMath<ByteC>.Exp(ByteC x) => NumericConvert.ToByte(Math.Exp(x._value), Conversion.CastClamp);
            ByteC IMath<ByteC>.Floor(ByteC x) => x;
            ByteC IMath<ByteC>.IEEERemainder(ByteC x, ByteC y) => NumericConvert.ToByte(Math.IEEERemainder(x._value, y._value), Conversion.CastClamp);
            ByteC IMath<ByteC>.Log(ByteC x) => NumericConvert.ToByte(Math.Log(x._value), Conversion.CastClamp);
            ByteC IMath<ByteC>.Log(ByteC x, ByteC y) => NumericConvert.ToByte(Math.Log(x._value, y._value), Conversion.CastClamp);
            ByteC IMath<ByteC>.Log10(ByteC x) => NumericConvert.ToByte(Math.Log10(x._value), Conversion.CastClamp);
            ByteC IMath<ByteC>.Max(ByteC x, ByteC y) => Math.Max(x._value, y._value);
            ByteC IMath<ByteC>.Min(ByteC x, ByteC y) => Math.Min(x._value, y._value);
            ByteC IMath<ByteC>.PI { get; } = 3;
            ByteC IMath<ByteC>.Pow(ByteC x, ByteC y) => CheckedArithmetic.Pow(x._value, y._value);
            ByteC IMath<ByteC>.RadiansToDegrees(ByteC x) => NumericConvert.ToByte(CheckedArithmetic.Multiply(x, NumericUtilities.DegreesPerRadian), Conversion.CastClamp);
            ByteC IMath<ByteC>.Round(ByteC x) => x;
            ByteC IMath<ByteC>.Round(ByteC x, int digits) => x;
            ByteC IMath<ByteC>.Round(ByteC x, int digits, MidpointRounding mode) => x;
            ByteC IMath<ByteC>.Round(ByteC x, MidpointRounding mode) => x;
            ByteC IMath<ByteC>.Sin(ByteC x) => NumericConvert.ToByte(Math.Sin(x._value), Conversion.CastClamp);
            ByteC IMath<ByteC>.Sinh(ByteC x) => NumericConvert.ToByte(Math.Sinh(x._value), Conversion.CastClamp);
            ByteC IMath<ByteC>.Sqrt(ByteC x) => NumericConvert.ToByte(Math.Sqrt(x._value), Conversion.CastClamp);
            ByteC IMath<ByteC>.Tan(ByteC x) => NumericConvert.ToByte(Math.Tan(x._value), Conversion.CastClamp);
            ByteC IMath<ByteC>.Tanh(ByteC x) => NumericConvert.ToByte(Math.Tanh(x._value), Conversion.CastClamp);
            ByteC IMath<ByteC>.Tau { get; } = 6;
            ByteC IMath<ByteC>.Truncate(ByteC x) => x;
            int IMath<ByteC>.Sign(ByteC x) => x._value == 0 ? 0 : 1;

            ByteC IBitConverter<ByteC>.Read(IReader<byte> stream) => stream.Read(1)[0];
            void IBitConverter<ByteC>.Write(ByteC value, IWriter<byte> stream) => stream.Write(value._value);

            ByteC IRandom<ByteC>.Next(Random random) => random.NextByte();
            ByteC IRandom<ByteC>.Next(Random random, ByteC bound1, ByteC bound2) => random.NextByte(bound1._value, bound2._value);

            bool IConvert<ByteC>.ToBoolean(ByteC value) => value._value != 0;
            byte IConvert<ByteC>.ToByte(ByteC value, Conversion mode) => value._value;
            decimal IConvert<ByteC>.ToDecimal(ByteC value, Conversion mode) => NumericConvert.ToDecimal(value._value, mode.Clamped());
            double IConvert<ByteC>.ToDouble(ByteC value, Conversion mode) => NumericConvert.ToDouble(value._value, mode.Clamped());
            float IConvert<ByteC>.ToSingle(ByteC value, Conversion mode) => NumericConvert.ToSingle(value._value, mode.Clamped());
            int IConvert<ByteC>.ToInt32(ByteC value, Conversion mode) => NumericConvert.ToInt32(value._value, mode.Clamped());
            long IConvert<ByteC>.ToInt64(ByteC value, Conversion mode) => NumericConvert.ToInt64(value._value, mode.Clamped());
            sbyte IConvertExtended<ByteC>.ToSByte(ByteC value, Conversion mode) => NumericConvert.ToSByte(value._value, mode.Clamped());
            short IConvert<ByteC>.ToInt16(ByteC value, Conversion mode) => NumericConvert.ToInt16(value._value, mode.Clamped());
            string IConvert<ByteC>.ToString(ByteC value) => Convert.ToString(value._value);
            uint IConvertExtended<ByteC>.ToUInt32(ByteC value, Conversion mode) => NumericConvert.ToUInt16(value._value, mode.Clamped());
            ulong IConvertExtended<ByteC>.ToUInt64(ByteC value, Conversion mode) => NumericConvert.ToUInt64(value._value, mode.Clamped());
            ushort IConvertExtended<ByteC>.ToUInt16(ByteC value, Conversion mode) => NumericConvert.ToByte(value._value, mode.Clamped());

            ByteC IConvert<ByteC>.ToNumeric(bool value) => value ? (byte)1 : (byte)0;
            ByteC IConvert<ByteC>.ToNumeric(byte value, Conversion mode) => NumericConvert.ToByte(value, mode.Clamped());
            ByteC IConvert<ByteC>.ToNumeric(decimal value, Conversion mode) => NumericConvert.ToByte(value, mode.Clamped());
            ByteC IConvert<ByteC>.ToNumeric(double value, Conversion mode) => NumericConvert.ToByte(value, mode.Clamped());
            ByteC IConvert<ByteC>.ToNumeric(float value, Conversion mode) => NumericConvert.ToByte(value, mode.Clamped());
            ByteC IConvert<ByteC>.ToNumeric(int value, Conversion mode) => NumericConvert.ToByte(value, mode.Clamped());
            ByteC IConvert<ByteC>.ToNumeric(long value, Conversion mode) => NumericConvert.ToByte(value, mode.Clamped());
            ByteC IConvertExtended<ByteC>.ToValue(sbyte value, Conversion mode) => NumericConvert.ToByte(value, mode.Clamped());
            ByteC IConvert<ByteC>.ToNumeric(short value, Conversion mode) => NumericConvert.ToByte(value, mode.Clamped());
            ByteC IConvert<ByteC>.ToNumeric(string value) => Convert.ToByte(value);
            ByteC IConvertExtended<ByteC>.ToNumeric(uint value, Conversion mode) => NumericConvert.ToByte(value, mode.Clamped());
            ByteC IConvertExtended<ByteC>.ToNumeric(ulong value, Conversion mode) => NumericConvert.ToByte(value, mode.Clamped());
            ByteC IConvertExtended<ByteC>.ToNumeric(ushort value, Conversion mode) => value;

            ByteC IStringParser<ByteC>.Parse(string s, NumberStyles? style, IFormatProvider? provider)
                => Parse(s, style ?? NumberStyles.Integer, provider);
        }
    }
}
