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
    /// Represents a 16-bit unsigned integer that cannot overflow.
    /// </summary>
    [Serializable]
    [DebuggerDisplay("{ToString(),nq}")]
    public readonly struct UInt16C : INumericExtended<UInt16C>
    {
        public static readonly UInt16C MaxValue = new UInt16C(ushort.MaxValue);
        public static readonly UInt16C MinValue = new UInt16C(ushort.MinValue);

        private readonly ushort _value;

        private UInt16C(ushort value)
        {
            _value = value;
        }

        private UInt16C(SerializationInfo info, StreamingContext context) : this(info.GetUInt16(nameof(UInt16C))) { }
        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context) => info.AddValue(nameof(UInt16C), _value);

        public int CompareTo(object? obj) => obj is UInt16C other ? CompareTo(other) : 1;
        public int CompareTo(UInt16C other) => _value.CompareTo(other._value);
        public bool Equals(UInt16C other) => _value == other._value;
        public override bool Equals(object? obj) => obj is UInt16C other && Equals(other);
        public override int GetHashCode() => _value.GetHashCode();
        public override string ToString() => _value.ToString();
        public string ToString(IFormatProvider formatProvider) => _value.ToString(formatProvider);
        public string ToString(string format) => _value.ToString(format);
        public string ToString(string? format, IFormatProvider? formatProvider) => _value.ToString(format, formatProvider);

        public static bool TryParse(string s, IFormatProvider? provider, out UInt16C result) => Try.Run(() => Parse(s, provider), out result);
        public static bool TryParse(string s, NumberStyles style, IFormatProvider? provider, out UInt16C result) => Try.Run(() => Parse(s, style, provider), out result);
        public static bool TryParse(string s, NumberStyles style, out UInt16C result) => Try.Run(() => Parse(s, style), out result);
        public static bool TryParse(string s, out UInt16C result) => Try.Run(() => Parse(s), out result);
        public static UInt16C Parse(string s) => ushort.Parse(s);
        public static UInt16C Parse(string s, IFormatProvider? provider) => ushort.Parse(s, provider);
        public static UInt16C Parse(string s, NumberStyles style) => ushort.Parse(s, style);
        public static UInt16C Parse(string s, NumberStyles style, IFormatProvider? provider) => ushort.Parse(s, style, provider);

        [CLSCompliant(false)] public static explicit operator UInt16C(sbyte value) => new UInt16C(NumericConvert.ToUInt16(value, Conversion.CastClamp));
        [CLSCompliant(false)] public static explicit operator UInt16C(uint value) => new UInt16C(NumericConvert.ToUInt16(value, Conversion.CastClamp));
        [CLSCompliant(false)] public static explicit operator UInt16C(ulong value) => new UInt16C(NumericConvert.ToUInt16(value, Conversion.CastClamp));
        [CLSCompliant(false)] public static implicit operator UInt16C(ushort value) => new UInt16C(value);
        public static explicit operator UInt16C(decimal value) => new UInt16C(NumericConvert.ToUInt16(value, Conversion.CastClamp));
        public static explicit operator UInt16C(double value) => new UInt16C(NumericConvert.ToUInt16(value, Conversion.CastClamp));
        public static explicit operator UInt16C(float value) => new UInt16C(NumericConvert.ToUInt16(value, Conversion.CastClamp));
        public static explicit operator UInt16C(int value) => new UInt16C(NumericConvert.ToUInt16(value, Conversion.CastClamp));
        public static explicit operator UInt16C(long value) => new UInt16C(NumericConvert.ToUInt16(value, Conversion.CastClamp));
        public static explicit operator UInt16C(short value) => new UInt16C(NumericConvert.ToUInt16(value, Conversion.CastClamp));
        public static implicit operator UInt16C(byte value) => new UInt16C(value);

        [CLSCompliant(false)] public static explicit operator sbyte(UInt16C value) => NumericConvert.ToSByte(value._value, Conversion.CastClamp);
        [CLSCompliant(false)] public static implicit operator uint(UInt16C value) => value._value;
        [CLSCompliant(false)] public static implicit operator ulong(UInt16C value) => value._value;
        [CLSCompliant(false)] public static implicit operator ushort(UInt16C value) => value._value;
        public static explicit operator byte(UInt16C value) => NumericConvert.ToByte(value._value, Conversion.CastClamp);
        public static explicit operator int(UInt16C value) => NumericConvert.ToInt32(value._value, Conversion.CastClamp);
        public static explicit operator short(UInt16C value) => NumericConvert.ToInt16(value._value, Conversion.CastClamp);
        public static implicit operator decimal(UInt16C value) => value._value;
        public static implicit operator double(UInt16C value) => value._value;
        public static implicit operator float(UInt16C value) => value._value;
        public static implicit operator long(UInt16C value) => value._value;

        public static bool operator !=(UInt16C left, UInt16C right) => left._value != right._value;
        public static bool operator <(UInt16C left, UInt16C right) => left._value < right._value;
        public static bool operator <=(UInt16C left, UInt16C right) => left._value <= right._value;
        public static bool operator ==(UInt16C left, UInt16C right) => left._value == right._value;
        public static bool operator >(UInt16C left, UInt16C right) => left._value > right._value;
        public static bool operator >=(UInt16C left, UInt16C right) => left._value >= right._value;
        public static UInt16C operator %(UInt16C left, UInt16C right) => CheckedArithmetic.Remainder(left._value, right._value);
        public static UInt16C operator &(UInt16C left, UInt16C right) => (ushort)(left._value & right._value);
        public static UInt16C operator -(UInt16C _) => MinValue;
        public static UInt16C operator -(UInt16C left, UInt16C right) => CheckedArithmetic.Subtract(left._value, right._value);
        public static UInt16C operator --(UInt16C value) => value - 1;
        public static UInt16C operator *(UInt16C left, UInt16C right) => CheckedArithmetic.Multiply(left._value, right._value);
        public static UInt16C operator /(UInt16C left, UInt16C right) => CheckedArithmetic.Divide(left._value, right._value);
        public static UInt16C operator ^(UInt16C left, UInt16C right) => (ushort)(left._value ^ right._value);
        public static UInt16C operator |(UInt16C left, UInt16C right) => (ushort)(left._value | right._value);
        public static UInt16C operator ~(UInt16C value) => (ushort)~value._value;
        public static UInt16C operator +(UInt16C left, UInt16C right) => CheckedArithmetic.Add(left._value, right._value);
        public static UInt16C operator +(UInt16C value) => value;
        public static UInt16C operator ++(UInt16C value) => value + 1;
        public static UInt16C operator <<(UInt16C left, int right) => (ushort)(left._value << right);
        public static UInt16C operator >>(UInt16C left, int right) => (ushort)(left._value >> right);

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

        bool INumeric<UInt16C>.IsGreaterThan(UInt16C value) => this > value;
        bool INumeric<UInt16C>.IsGreaterThanOrEqualTo(UInt16C value) => this >= value;
        bool INumeric<UInt16C>.IsLessThan(UInt16C value) => this < value;
        bool INumeric<UInt16C>.IsLessThanOrEqualTo(UInt16C value) => this <= value;
        UInt16C INumeric<UInt16C>.Add(UInt16C value) => this + value;
        UInt16C INumeric<UInt16C>.BitwiseComplement() => ~this;
        UInt16C INumeric<UInt16C>.Divide(UInt16C value) => this / value;
        UInt16C INumeric<UInt16C>.LeftShift(int count) => this << count;
        UInt16C INumeric<UInt16C>.LogicalAnd(UInt16C value) => this & value;
        UInt16C INumeric<UInt16C>.LogicalExclusiveOr(UInt16C value) => this ^ value;
        UInt16C INumeric<UInt16C>.LogicalOr(UInt16C value) => this | value;
        UInt16C INumeric<UInt16C>.Multiply(UInt16C value) => this * value;
        UInt16C INumeric<UInt16C>.Negative() => -this;
        UInt16C INumeric<UInt16C>.Positive() => +this;
        UInt16C INumeric<UInt16C>.Remainder(UInt16C value) => this % value;
        UInt16C INumeric<UInt16C>.RightShift(int count) => this >> count;
        UInt16C INumeric<UInt16C>.Subtract(UInt16C value) => this - value;

        IBitConverter<UInt16C> IProvider<IBitConverter<UInt16C>>.GetInstance() => Utilities.Instance;
        IConvert<UInt16C> IProvider<IConvert<UInt16C>>.GetInstance() => Utilities.Instance;
        IConvertExtended<UInt16C> IProvider<IConvertExtended<UInt16C>>.GetInstance() => Utilities.Instance;
        IMath<UInt16C> IProvider<IMath<UInt16C>>.GetInstance() => Utilities.Instance;
        INumericStatic<UInt16C> IProvider<INumericStatic<UInt16C>>.GetInstance() => Utilities.Instance;
        IRandom<UInt16C> IProvider<IRandom<UInt16C>>.GetInstance() => Utilities.Instance;
        IParser<UInt16C> IProvider<IParser<UInt16C>>.GetInstance() => Utilities.Instance;

        private sealed class Utilities :
            IBitConverter<UInt16C>,
            IConvert<UInt16C>,
            IConvertExtended<UInt16C>,
            IMath<UInt16C>,
            INumericStatic<UInt16C>,
            IRandom<UInt16C>,
            IParser<UInt16C>
        {
            public static readonly Utilities Instance = new Utilities();

            bool INumericStatic<UInt16C>.HasFloatingPoint { get; } = false;
            bool INumericStatic<UInt16C>.HasInfinity { get; } = false;
            bool INumericStatic<UInt16C>.HasNaN { get; } = false;
            bool INumericStatic<UInt16C>.IsFinite(UInt16C x) => true;
            bool INumericStatic<UInt16C>.IsInfinity(UInt16C x) => false;
            bool INumericStatic<UInt16C>.IsNaN(UInt16C x) => false;
            bool INumericStatic<UInt16C>.IsNegative(UInt16C x) => false;
            bool INumericStatic<UInt16C>.IsNegativeInfinity(UInt16C x) => false;
            bool INumericStatic<UInt16C>.IsNormal(UInt16C x) => false;
            bool INumericStatic<UInt16C>.IsPositiveInfinity(UInt16C x) => false;
            bool INumericStatic<UInt16C>.IsReal { get; } = false;
            bool INumericStatic<UInt16C>.IsSigned { get; } = false;
            bool INumericStatic<UInt16C>.IsSubnormal(UInt16C x) => false;
            UInt16C INumericStatic<UInt16C>.Epsilon { get; } = 1;
            UInt16C INumericStatic<UInt16C>.MaxUnit { get; } = 1;
            UInt16C INumericStatic<UInt16C>.MaxValue => MaxValue;
            UInt16C INumericStatic<UInt16C>.MinUnit { get; } = 0;
            UInt16C INumericStatic<UInt16C>.MinValue => MinValue;
            UInt16C INumericStatic<UInt16C>.One { get; } = 1;
            UInt16C INumericStatic<UInt16C>.Ten { get; } = 10;
            UInt16C INumericStatic<UInt16C>.Two { get; } = 2;
            UInt16C INumericStatic<UInt16C>.Zero { get; } = 0;

            int IMath<UInt16C>.Sign(UInt16C x) => x._value == 0 ? 0 : 1;
            UInt16C IMath<UInt16C>.Abs(UInt16C value) => value;
            UInt16C IMath<UInt16C>.Acos(UInt16C x) => (UInt16C)Math.Acos(x._value);
            UInt16C IMath<UInt16C>.Acosh(UInt16C x) => (UInt16C)MathCompat.Acosh(x._value);
            UInt16C IMath<UInt16C>.Asin(UInt16C x) => (UInt16C)Math.Asin(x._value);
            UInt16C IMath<UInt16C>.Asinh(UInt16C x) => (UInt16C)MathCompat.Asinh(x._value);
            UInt16C IMath<UInt16C>.Atan(UInt16C x) => (UInt16C)Math.Atan(x._value);
            UInt16C IMath<UInt16C>.Atan2(UInt16C x, UInt16C y) => (UInt16C)Math.Atan2(x._value, y._value);
            UInt16C IMath<UInt16C>.Atanh(UInt16C x) => (UInt16C)MathCompat.Atanh(x._value);
            UInt16C IMath<UInt16C>.Cbrt(UInt16C x) => (UInt16C)MathCompat.Cbrt(x._value);
            UInt16C IMath<UInt16C>.Ceiling(UInt16C x) => x;
            UInt16C IMath<UInt16C>.Clamp(UInt16C x, UInt16C bound1, UInt16C bound2) => bound1 > bound2 ? Math.Min(bound1._value, Math.Max(bound2._value, x._value)) : Math.Min(bound2._value, Math.Max(bound1._value, x._value));
            UInt16C IMath<UInt16C>.Cos(UInt16C x) => (UInt16C)Math.Cos(x._value);
            UInt16C IMath<UInt16C>.Cosh(UInt16C x) => (UInt16C)Math.Cosh(x._value);
            UInt16C IMath<UInt16C>.DegreesToRadians(UInt16C x) => (UInt16C)CheckedArithmetic.Multiply(x, NumericUtilities.RadiansPerDegree);
            UInt16C IMath<UInt16C>.E { get; } = 2;
            UInt16C IMath<UInt16C>.Exp(UInt16C x) => (UInt16C)Math.Exp(x._value);
            UInt16C IMath<UInt16C>.Floor(UInt16C x) => x;
            UInt16C IMath<UInt16C>.IEEERemainder(UInt16C x, UInt16C y) => (UInt16C)Math.IEEERemainder(x._value, y._value);
            UInt16C IMath<UInt16C>.Log(UInt16C x) => (UInt16C)Math.Log(x._value);
            UInt16C IMath<UInt16C>.Log(UInt16C x, UInt16C y) => (UInt16C)Math.Log(x._value, y._value);
            UInt16C IMath<UInt16C>.Log10(UInt16C x) => (UInt16C)Math.Log10(x._value);
            UInt16C IMath<UInt16C>.Max(UInt16C x, UInt16C y) => Math.Max(x._value, y._value);
            UInt16C IMath<UInt16C>.Min(UInt16C x, UInt16C y) => Math.Min(x._value, y._value);
            UInt16C IMath<UInt16C>.PI { get; } = 3;
            UInt16C IMath<UInt16C>.Pow(UInt16C x, UInt16C y) => CheckedArithmetic.Pow(x._value, y._value);
            UInt16C IMath<UInt16C>.RadiansToDegrees(UInt16C x) => (UInt16C)CheckedArithmetic.Multiply(x, NumericUtilities.DegreesPerRadian);
            UInt16C IMath<UInt16C>.Round(UInt16C x) => x;
            UInt16C IMath<UInt16C>.Round(UInt16C x, int digits) => x;
            UInt16C IMath<UInt16C>.Round(UInt16C x, int digits, MidpointRounding mode) => x;
            UInt16C IMath<UInt16C>.Round(UInt16C x, MidpointRounding mode) => x;
            UInt16C IMath<UInt16C>.Sin(UInt16C x) => (UInt16C)Math.Sin(x._value);
            UInt16C IMath<UInt16C>.Sinh(UInt16C x) => (UInt16C)Math.Sinh(x._value);
            UInt16C IMath<UInt16C>.Sqrt(UInt16C x) => (UInt16C)Math.Sqrt(x._value);
            UInt16C IMath<UInt16C>.Tan(UInt16C x) => (UInt16C)Math.Tan(x._value);
            UInt16C IMath<UInt16C>.Tanh(UInt16C x) => (UInt16C)Math.Tanh(x._value);
            UInt16C IMath<UInt16C>.Tau { get; } = 6;
            UInt16C IMath<UInt16C>.Truncate(UInt16C x) => x;

            UInt16C IBitConverter<UInt16C>.Read(IReadOnlyStream<byte> stream) => BitConverter.ToUInt16(stream.Read(sizeof(ushort)), 0);
            void IBitConverter<UInt16C>.Write(UInt16C value, IWriteOnlyStream<byte> stream) => stream.Write(BitConverter.GetBytes(value._value));

            UInt16C IRandom<UInt16C>.Next(Random random) => random.NextUInt16();
            UInt16C IRandom<UInt16C>.Next(Random random, UInt16C bound1, UInt16C bound2) => random.NextUInt16(bound1._value, bound2._value);

            bool IConvert<UInt16C>.ToBoolean(UInt16C value) => value._value != 0;
            byte IConvert<UInt16C>.ToByte(UInt16C value, Conversion mode) => NumericConvert.ToByte(value._value, mode.Clamped());
            decimal IConvert<UInt16C>.ToDecimal(UInt16C value, Conversion mode) => NumericConvert.ToDecimal(value._value, mode.Clamped());
            double IConvert<UInt16C>.ToDouble(UInt16C value, Conversion mode) => NumericConvert.ToDouble(value._value, mode.Clamped());
            float IConvert<UInt16C>.ToSingle(UInt16C value, Conversion mode) => NumericConvert.ToSingle(value._value, mode.Clamped());
            int IConvert<UInt16C>.ToInt32(UInt16C value, Conversion mode) => NumericConvert.ToInt32(value._value, mode.Clamped());
            long IConvert<UInt16C>.ToInt64(UInt16C value, Conversion mode) => NumericConvert.ToInt64(value._value, mode.Clamped());
            sbyte IConvertExtended<UInt16C>.ToSByte(UInt16C value, Conversion mode) => NumericConvert.ToSByte(value._value, mode.Clamped());
            short IConvert<UInt16C>.ToInt16(UInt16C value, Conversion mode) => NumericConvert.ToInt16(value._value, mode.Clamped());
            string IConvert<UInt16C>.ToString(UInt16C value) => Convert.ToString(value._value);
            uint IConvertExtended<UInt16C>.ToUInt32(UInt16C value, Conversion mode) => value._value;
            ulong IConvertExtended<UInt16C>.ToUInt64(UInt16C value, Conversion mode) => NumericConvert.ToUInt64(value._value, mode.Clamped());
            ushort IConvertExtended<UInt16C>.ToUInt16(UInt16C value, Conversion mode) => NumericConvert.ToUInt16(value._value, mode.Clamped());

            UInt16C IConvert<UInt16C>.ToNumeric(bool value) => value ? (ushort)1 : (ushort)0;
            UInt16C IConvert<UInt16C>.ToNumeric(byte value, Conversion mode) => NumericConvert.ToUInt16(value, mode.Clamped());
            UInt16C IConvert<UInt16C>.ToNumeric(decimal value, Conversion mode) => NumericConvert.ToUInt16(value, mode.Clamped());
            UInt16C IConvert<UInt16C>.ToNumeric(double value, Conversion mode) => NumericConvert.ToUInt16(value, mode.Clamped());
            UInt16C IConvert<UInt16C>.ToNumeric(float value, Conversion mode) => NumericConvert.ToUInt16(value, mode.Clamped());
            UInt16C IConvert<UInt16C>.ToNumeric(int value, Conversion mode) => NumericConvert.ToUInt16(value, mode.Clamped());
            UInt16C IConvert<UInt16C>.ToNumeric(long value, Conversion mode) => NumericConvert.ToUInt16(value, mode.Clamped());
            UInt16C IConvertExtended<UInt16C>.ToValue(sbyte value, Conversion mode) => NumericConvert.ToUInt16(value, mode.Clamped());
            UInt16C IConvert<UInt16C>.ToNumeric(short value, Conversion mode) => NumericConvert.ToUInt16(value, mode.Clamped());
            UInt16C IConvert<UInt16C>.ToNumeric(string value) => Convert.ToUInt16(value);
            UInt16C IConvertExtended<UInt16C>.ToNumeric(uint value, Conversion mode) => NumericConvert.ToUInt16(value, mode.Clamped());
            UInt16C IConvertExtended<UInt16C>.ToNumeric(ulong value, Conversion mode) => NumericConvert.ToUInt16(value, mode.Clamped());
            UInt16C IConvertExtended<UInt16C>.ToNumeric(ushort value, Conversion mode) => value;

            UInt16C IParser<UInt16C>.Parse(string s) => Parse(s);
            UInt16C IParser<UInt16C>.Parse(string s, NumberStyles style, IFormatProvider? provider) => Parse(s, style, provider);
        }
    }
}
