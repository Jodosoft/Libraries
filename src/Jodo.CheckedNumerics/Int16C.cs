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
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Runtime.Serialization;
using Jodo.Numerics;
using Jodo.Primitives;
using Jodo.Primitives.Compatibility;

namespace Jodo.CheckedNumerics
{
    /// <summary>
    /// Represents a 64-bit signed integer that cannot overflow.
    /// </summary>
    [Serializable]
    [DebuggerDisplay("{ToString(),nq}")]
    public readonly struct Int16C : INumericExtended<Int16C>
    {
        public static readonly Int16C MaxValue = new Int16C(short.MaxValue);
        public static readonly Int16C MinValue = new Int16C(short.MinValue);

        private readonly short _value;

        private Int16C(short value)
        {
            _value = value;
        }

        private Int16C(SerializationInfo info, StreamingContext context) : this(info.GetInt16(nameof(Int16C))) { }
        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context) => info.AddValue(nameof(Int16C), _value);

        public int CompareTo(Int16C other) => _value.CompareTo(other._value);
        public int CompareTo(object? obj) => obj is Int16C other ? CompareTo(other) : 1;
        public bool Equals(Int16C other) => _value == other._value;
        public override bool Equals(object? obj) => obj is Int16C other && Equals(other);
        public override int GetHashCode() => _value.GetHashCode();
        public override string ToString() => _value.ToString();
        public string ToString(IFormatProvider formatProvider) => _value.ToString(formatProvider);
        public string ToString(string format) => _value.ToString(format);
        public string ToString(string? format, IFormatProvider? formatProvider) => _value.ToString(format, formatProvider);

        public static bool TryParse(string s, IFormatProvider? provider, out Int16C result) => Try.Run(() => Parse(s, provider), out result);
        public static bool TryParse(string s, NumberStyles style, IFormatProvider? provider, out Int16C result) => Try.Run(() => Parse(s, style, provider), out result);
        public static bool TryParse(string s, NumberStyles style, out Int16C result) => Try.Run(() => Parse(s, style), out result);
        public static bool TryParse(string s, out Int16C result) => Try.Run(() => Parse(s), out result);
        public static Int16C Parse(string s) => short.Parse(s);
        public static Int16C Parse(string s, IFormatProvider? provider) => short.Parse(s, provider);
        public static Int16C Parse(string s, NumberStyles style) => short.Parse(s, style);
        public static Int16C Parse(string s, NumberStyles style, IFormatProvider? provider) => short.Parse(s, style, provider);

        [CLSCompliant(false)] public static explicit operator Int16C(uint value) => new Int16C(NumericConvert.ToInt16(value, Conversion.CastClamp));
        [CLSCompliant(false)] public static explicit operator Int16C(ulong value) => new Int16C(NumericConvert.ToInt16(value, Conversion.CastClamp));
        [CLSCompliant(false)] public static explicit operator Int16C(ushort value) => new Int16C(NumericConvert.ToInt16(value, Conversion.CastClamp));
        [CLSCompliant(false)] public static implicit operator Int16C(sbyte value) => new Int16C(value);
        public static explicit operator Int16C(decimal value) => new Int16C(NumericConvert.ToInt16(value, Conversion.CastClamp));
        public static explicit operator Int16C(double value) => new Int16C(NumericConvert.ToInt16(value, Conversion.CastClamp));
        public static explicit operator Int16C(float value) => new Int16C(NumericConvert.ToInt16(value, Conversion.CastClamp));
        public static explicit operator Int16C(int value) => new Int16C(NumericConvert.ToInt16(value, Conversion.CastClamp));
        public static explicit operator Int16C(long value) => new Int16C(NumericConvert.ToInt16(value, Conversion.CastClamp));
        public static implicit operator Int16C(byte value) => new Int16C(value);
        public static implicit operator Int16C(short value) => new Int16C(value);

        [CLSCompliant(false)] public static explicit operator sbyte(Int16C value) => NumericConvert.ToSByte(value._value, Conversion.CastClamp);
        [CLSCompliant(false)] public static explicit operator uint(Int16C value) => NumericConvert.ToUInt16(value._value, Conversion.CastClamp);
        [CLSCompliant(false)] public static explicit operator ulong(Int16C value) => NumericConvert.ToUInt64(value._value, Conversion.CastClamp);
        [CLSCompliant(false)] public static explicit operator ushort(Int16C value) => NumericConvert.ToUInt16(value._value, Conversion.CastClamp);
        public static explicit operator byte(Int16C value) => NumericConvert.ToByte(value._value, Conversion.CastClamp);
        public static implicit operator decimal(Int16C value) => value._value;
        public static implicit operator double(Int16C value) => value._value;
        public static implicit operator float(Int16C value) => value._value;
        public static implicit operator int(Int16C value) => value._value;
        public static implicit operator long(Int16C value) => value._value;
        public static implicit operator short(Int16C value) => value._value;

        public static bool operator !=(Int16C left, Int16C right) => left._value != right._value;
        public static bool operator <(Int16C left, Int16C right) => left._value < right._value;
        public static bool operator <=(Int16C left, Int16C right) => left._value <= right._value;
        public static bool operator ==(Int16C left, Int16C right) => left._value == right._value;
        public static bool operator >(Int16C left, Int16C right) => left._value > right._value;
        public static bool operator >=(Int16C left, Int16C right) => left._value >= right._value;
        public static Int16C operator %(Int16C left, Int16C right) => CheckedArithmetic.Remainder(left._value, right._value);
        public static Int16C operator &(Int16C left, Int16C right) => (short)(left._value & right._value);
        public static Int16C operator -(Int16C left, Int16C right) => CheckedArithmetic.Subtract(left._value, right._value);
        public static Int16C operator --(Int16C value) => CheckedArithmetic.Subtract(value._value, (short)1);
        public static Int16C operator -(Int16C value) => (short)-value._value;
        public static Int16C operator *(Int16C left, Int16C right) => CheckedArithmetic.Multiply(left._value, right._value);
        public static Int16C operator /(Int16C left, Int16C right) => CheckedArithmetic.Divide(left._value, right._value);
        public static Int16C operator ^(Int16C left, Int16C right) => (short)(left._value ^ right._value);
        public static Int16C operator |(Int16C left, Int16C right) => (short)(left._value | right._value);
        public static Int16C operator ~(Int16C value) => (short)~value._value;
        public static Int16C operator +(Int16C left, Int16C right) => CheckedArithmetic.Add(left._value, right._value);
        public static Int16C operator +(Int16C value) => value;
        public static Int16C operator ++(Int16C value) => CheckedArithmetic.Add(value._value, (short)1);
        public static Int16C operator <<(Int16C left, int right) => (short)(left._value << right);
        public static Int16C operator >>(Int16C left, int right) => (short)(left._value >> right);

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

        bool INumeric<Int16C>.IsGreaterThan(Int16C value) => this > value;
        bool INumeric<Int16C>.IsGreaterThanOrEqualTo(Int16C value) => this >= value;
        bool INumeric<Int16C>.IsLessThan(Int16C value) => this < value;
        bool INumeric<Int16C>.IsLessThanOrEqualTo(Int16C value) => this <= value;
        Int16C INumeric<Int16C>.Add(Int16C value) => this + value;
        Int16C INumeric<Int16C>.BitwiseComplement() => ~this;
        Int16C INumeric<Int16C>.Divide(Int16C value) => this / value;
        Int16C INumeric<Int16C>.LeftShift(int count) => this << count;
        Int16C INumeric<Int16C>.LogicalAnd(Int16C value) => this & value;
        Int16C INumeric<Int16C>.LogicalExclusiveOr(Int16C value) => this ^ value;
        Int16C INumeric<Int16C>.LogicalOr(Int16C value) => this | value;
        Int16C INumeric<Int16C>.Multiply(Int16C value) => this * value;
        Int16C INumeric<Int16C>.Negative() => -this;
        Int16C INumeric<Int16C>.Positive() => +this;
        Int16C INumeric<Int16C>.Remainder(Int16C value) => this % value;
        Int16C INumeric<Int16C>.RightShift(int count) => this >> count;
        Int16C INumeric<Int16C>.Subtract(Int16C value) => this - value;

        IBitConverter<Int16C> IProvider<IBitConverter<Int16C>>.GetInstance() => Utilities.Instance;
        IConvert<Int16C> IProvider<IConvert<Int16C>>.GetInstance() => Utilities.Instance;
        IConvertExtended<Int16C> IProvider<IConvertExtended<Int16C>>.GetInstance() => Utilities.Instance;
        IMath<Int16C> IProvider<IMath<Int16C>>.GetInstance() => Utilities.Instance;
        INumericStatic<Int16C> IProvider<INumericStatic<Int16C>>.GetInstance() => Utilities.Instance;
        IRandom<Int16C> IProvider<IRandom<Int16C>>.GetInstance() => Utilities.Instance;
        IParser<Int16C> IProvider<IParser<Int16C>>.GetInstance() => Utilities.Instance;

        private sealed class Utilities :
            IBitConverter<Int16C>,
            IConvert<Int16C>,
            IConvertExtended<Int16C>,
            IMath<Int16C>,
            INumericStatic<Int16C>,
            IRandom<Int16C>,
            IParser<Int16C>
        {
            public static readonly Utilities Instance = new Utilities();

            bool INumericStatic<Int16C>.HasFloatingPoint { get; } = false;
            bool INumericStatic<Int16C>.HasInfinity { get; } = false;
            bool INumericStatic<Int16C>.HasNaN { get; } = false;
            bool INumericStatic<Int16C>.IsFinite(Int16C x) => true;
            bool INumericStatic<Int16C>.IsInfinity(Int16C x) => false;
            bool INumericStatic<Int16C>.IsNaN(Int16C x) => false;
            bool INumericStatic<Int16C>.IsNegative(Int16C x) => x._value < 0;
            bool INumericStatic<Int16C>.IsNegativeInfinity(Int16C x) => false;
            bool INumericStatic<Int16C>.IsNormal(Int16C x) => false;
            bool INumericStatic<Int16C>.IsPositiveInfinity(Int16C x) => false;
            bool INumericStatic<Int16C>.IsReal { get; } = false;
            bool INumericStatic<Int16C>.IsSigned { get; } = true;
            bool INumericStatic<Int16C>.IsSubnormal(Int16C x) => false;
            Int16C INumericStatic<Int16C>.Epsilon { get; } = (short)1;
            Int16C INumericStatic<Int16C>.MaxUnit { get; } = (short)1;
            Int16C INumericStatic<Int16C>.MaxValue => MaxValue;
            Int16C INumericStatic<Int16C>.MinUnit { get; } = (short)-1;
            Int16C INumericStatic<Int16C>.MinValue => MinValue;
            Int16C INumericStatic<Int16C>.One { get; } = (short)1;
            Int16C INumericStatic<Int16C>.Ten { get; } = (short)10;
            Int16C INumericStatic<Int16C>.Two { get; } = (short)2;
            Int16C INumericStatic<Int16C>.Zero { get; } = (short)0;

            Int16C IMath<Int16C>.Abs(Int16C value) => Math.Abs(value._value);
            Int16C IMath<Int16C>.Acos(Int16C x) => (Int16C)Math.Acos(x._value);
            Int16C IMath<Int16C>.Acosh(Int16C x) => (Int16C)MathCompat.Acosh(x._value);
            Int16C IMath<Int16C>.Asin(Int16C x) => (Int16C)Math.Asin(x._value);
            Int16C IMath<Int16C>.Asinh(Int16C x) => (Int16C)MathCompat.Asinh(x._value);
            Int16C IMath<Int16C>.Atan(Int16C x) => (Int16C)Math.Atan(x._value);
            Int16C IMath<Int16C>.Atan2(Int16C x, Int16C y) => (Int16C)Math.Atan2(x._value, y._value);
            Int16C IMath<Int16C>.Atanh(Int16C x) => (Int16C)MathCompat.Atanh(x._value);
            Int16C IMath<Int16C>.Cbrt(Int16C x) => (Int16C)MathCompat.Cbrt(x._value);
            Int16C IMath<Int16C>.Ceiling(Int16C x) => x;
            Int16C IMath<Int16C>.Clamp(Int16C x, Int16C bound1, Int16C bound2) => bound1 > bound2 ? Math.Min(bound1._value, Math.Max(bound2._value, x._value)) : Math.Min(bound2._value, Math.Max(bound1._value, x._value));
            Int16C IMath<Int16C>.Cos(Int16C x) => (Int16C)Math.Cos(x._value);
            Int16C IMath<Int16C>.Cosh(Int16C x) => (Int16C)Math.Cosh(x._value);
            Int16C IMath<Int16C>.DegreesToRadians(Int16C x) => (Int16C)CheckedArithmetic.Multiply(x, NumericUtilities.RadiansPerDegree);
            Int16C IMath<Int16C>.E { get; } = (short)2;
            Int16C IMath<Int16C>.Exp(Int16C x) => (Int16C)Math.Exp(x._value);
            Int16C IMath<Int16C>.Floor(Int16C x) => x;
            Int16C IMath<Int16C>.IEEERemainder(Int16C x, Int16C y) => (Int16C)Math.IEEERemainder(x._value, y._value);
            Int16C IMath<Int16C>.Log(Int16C x) => (Int16C)Math.Log(x._value);
            Int16C IMath<Int16C>.Log(Int16C x, Int16C y) => (Int16C)Math.Log(x._value, y._value);
            Int16C IMath<Int16C>.Log10(Int16C x) => (Int16C)Math.Log10(x._value);
            Int16C IMath<Int16C>.Max(Int16C x, Int16C y) => Math.Max(x._value, y._value);
            Int16C IMath<Int16C>.Min(Int16C x, Int16C y) => Math.Min(x._value, y._value);
            Int16C IMath<Int16C>.PI { get; } = (short)3;
            Int16C IMath<Int16C>.Pow(Int16C x, Int16C y) => CheckedArithmetic.Pow(x._value, y._value);
            Int16C IMath<Int16C>.RadiansToDegrees(Int16C x) => (Int16C)CheckedArithmetic.Multiply(x, NumericUtilities.DegreesPerRadian);
            Int16C IMath<Int16C>.Round(Int16C x) => x;
            Int16C IMath<Int16C>.Round(Int16C x, int digits) => x;
            Int16C IMath<Int16C>.Round(Int16C x, int digits, MidpointRounding mode) => x;
            Int16C IMath<Int16C>.Round(Int16C x, MidpointRounding mode) => x;
            Int16C IMath<Int16C>.Sin(Int16C x) => (Int16C)Math.Sin(x._value);
            Int16C IMath<Int16C>.Sinh(Int16C x) => (Int16C)Math.Sinh(x._value);
            Int16C IMath<Int16C>.Sqrt(Int16C x) => (Int16C)Math.Sqrt(x._value);
            Int16C IMath<Int16C>.Tan(Int16C x) => (Int16C)Math.Tan(x._value);
            Int16C IMath<Int16C>.Tanh(Int16C x) => (Int16C)Math.Tanh(x._value);
            Int16C IMath<Int16C>.Tau { get; } = (short)6;
            Int16C IMath<Int16C>.Truncate(Int16C x) => x;
            int IMath<Int16C>.Sign(Int16C x) => Math.Sign(x._value);

            Int16C IBitConverter<Int16C>.Read(IReadOnlyStream<byte> stream) => BitConverter.ToInt16(stream.Read(sizeof(short)), 0);
            void IBitConverter<Int16C>.Write(Int16C value, IWriteOnlyStream<byte> stream) => stream.Write(BitConverter.GetBytes(value._value));

            Int16C IRandom<Int16C>.Next(Random random) => random.NextInt16();
            Int16C IRandom<Int16C>.Next(Random random, Int16C bound1, Int16C bound2) => random.NextInt16(bound1._value, bound2._value);

            bool IConvert<Int16C>.ToBoolean(Int16C value) => value._value != 0;
            byte IConvert<Int16C>.ToByte(Int16C value, Conversion mode) => NumericConvert.ToByte(value._value, mode.Clamped());
            decimal IConvert<Int16C>.ToDecimal(Int16C value, Conversion mode) => NumericConvert.ToDecimal(value._value, mode.Clamped());
            double IConvert<Int16C>.ToDouble(Int16C value, Conversion mode) => NumericConvert.ToDouble(value._value, mode.Clamped());
            float IConvert<Int16C>.ToSingle(Int16C value, Conversion mode) => NumericConvert.ToSingle(value._value, mode.Clamped());
            int IConvert<Int16C>.ToInt32(Int16C value, Conversion mode) => NumericConvert.ToInt32(value._value, mode.Clamped());
            long IConvert<Int16C>.ToInt64(Int16C value, Conversion mode) => NumericConvert.ToInt64(value._value, mode.Clamped());
            sbyte IConvertExtended<Int16C>.ToSByte(Int16C value, Conversion mode) => NumericConvert.ToSByte(value._value, mode.Clamped());
            short IConvert<Int16C>.ToInt16(Int16C value, Conversion mode) => value._value;
            string IConvert<Int16C>.ToString(Int16C value) => Convert.ToString(value._value);
            uint IConvertExtended<Int16C>.ToUInt32(Int16C value, Conversion mode) => NumericConvert.ToUInt32(value._value, mode.Clamped());
            ulong IConvertExtended<Int16C>.ToUInt64(Int16C value, Conversion mode) => NumericConvert.ToUInt64(value._value, mode.Clamped());
            ushort IConvertExtended<Int16C>.ToUInt16(Int16C value, Conversion mode) => NumericConvert.ToUInt16(value._value, mode.Clamped());

            Int16C IConvert<Int16C>.ToNumeric(bool value) => value ? (short)1 : (short)0;
            Int16C IConvert<Int16C>.ToNumeric(byte value, Conversion mode) => NumericConvert.ToInt16(value, mode.Clamped());
            Int16C IConvert<Int16C>.ToNumeric(decimal value, Conversion mode) => NumericConvert.ToInt16(value, mode.Clamped());
            Int16C IConvert<Int16C>.ToNumeric(double value, Conversion mode) => NumericConvert.ToInt16(value, mode.Clamped());
            Int16C IConvert<Int16C>.ToNumeric(float value, Conversion mode) => NumericConvert.ToInt16(value, mode.Clamped());
            Int16C IConvert<Int16C>.ToNumeric(int value, Conversion mode) => NumericConvert.ToInt16(value, mode.Clamped());
            Int16C IConvert<Int16C>.ToNumeric(long value, Conversion mode) => NumericConvert.ToInt16(value, mode.Clamped());
            Int16C IConvertExtended<Int16C>.ToValue(sbyte value, Conversion mode) => NumericConvert.ToInt16(value, mode.Clamped());
            Int16C IConvert<Int16C>.ToNumeric(short value, Conversion mode) => value;
            Int16C IConvert<Int16C>.ToNumeric(string value) => Convert.ToInt16(value);
            Int16C IConvertExtended<Int16C>.ToNumeric(uint value, Conversion mode) => NumericConvert.ToInt16(value, mode.Clamped());
            Int16C IConvertExtended<Int16C>.ToNumeric(ulong value, Conversion mode) => NumericConvert.ToInt16(value, mode.Clamped());
            Int16C IConvertExtended<Int16C>.ToNumeric(ushort value, Conversion mode) => NumericConvert.ToInt16(value, mode.Clamped());

            Int16C IParser<Int16C>.Parse(string s) => Parse(s);
            Int16C IParser<Int16C>.Parse(string s, NumberStyles style, IFormatProvider? provider) => Parse(s, style, provider);
        }
    }
}
