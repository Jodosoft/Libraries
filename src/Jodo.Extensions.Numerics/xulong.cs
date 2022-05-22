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

using Jodo.Extensions.Primitives;
using System;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Runtime.Serialization;

namespace Jodo.Extensions.Numerics
{
    [Serializable]
    [DebuggerDisplay("{ToString(),nq}")]
    [SuppressMessage("Style", "IDE1006:Naming Styles")]
    [SuppressMessage("csharpsquid", "S101")]
    public readonly struct xulong : INumeric<xulong>
    {
        public static readonly xulong MaxValue = new xulong(ulong.MaxValue);
        public static readonly xulong MinValue = new xulong(ulong.MinValue);

        private readonly ulong _value;

        private xulong(ulong value)
        {
            _value = value;
        }

        private xulong(SerializationInfo info, StreamingContext context) : this(info.GetUInt64(nameof(xulong))) { }
        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context) => info.AddValue(nameof(xulong), _value);

        public int CompareTo(xulong other) => _value.CompareTo(other._value);
        public int CompareTo(object? obj) => obj is xulong other ? CompareTo(other) : 1;
        public bool Equals(xulong other) => _value == other._value;
        public override bool Equals(object? obj) => obj is xulong other && Equals(other);
        public override int GetHashCode() => _value.GetHashCode();
        public override string ToString() => _value.ToString();
        public string ToString(IFormatProvider formatProvider) => _value.ToString(formatProvider);
        public string ToString(string format) => _value.ToString(format);
        public string ToString(string format, IFormatProvider formatProvider) => _value.ToString(format, formatProvider);

        public static bool TryParse(string s, IFormatProvider provider, out xulong result) => Try.Run(() => Parse(s, provider), out result);
        public static bool TryParse(string s, NumberStyles style, IFormatProvider provider, out xulong result) => Try.Run(() => Parse(s, style, provider), out result);
        public static bool TryParse(string s, NumberStyles style, out xulong result) => Try.Run(() => Parse(s, style), out result);
        public static bool TryParse(string s, out xulong result) => Try.Run(() => Parse(s), out result);
        public static xulong Parse(string s) => ulong.Parse(s);
        public static xulong Parse(string s, IFormatProvider provider) => ulong.Parse(s, provider);
        public static xulong Parse(string s, NumberStyles style) => ulong.Parse(s, style);
        public static xulong Parse(string s, NumberStyles style, IFormatProvider provider) => ulong.Parse(s, style, provider);

        public static explicit operator xulong(decimal value) => new xulong((ulong)value);
        public static explicit operator xulong(double value) => new xulong((ulong)value);
        public static explicit operator xulong(float value) => new xulong((ulong)value);
        public static explicit operator xulong(int value) => new xulong((ulong)value);
        public static explicit operator xulong(long value) => new xulong((ulong)value);
        public static explicit operator xulong(sbyte value) => new xulong((ulong)value);
        public static explicit operator xulong(short value) => new xulong((ulong)value);
        public static implicit operator xulong(byte value) => new xulong(value);
        public static implicit operator xulong(char value) => new xulong(value);
        public static implicit operator xulong(uint value) => new xulong(value);
        public static implicit operator xulong(ulong value) => new xulong(value);
        public static implicit operator xulong(ushort value) => new xulong(value);

        public static explicit operator byte(xulong value) => (byte)value._value;
        public static explicit operator char(xulong value) => (char)value._value;
        public static explicit operator int(xulong value) => (int)value._value;
        public static explicit operator long(xulong value) => (long)value._value;
        public static explicit operator sbyte(xulong value) => (sbyte)value._value;
        public static explicit operator short(xulong value) => (short)value._value;
        public static explicit operator uint(xulong value) => (uint)value._value;
        public static explicit operator ushort(xulong value) => (ushort)value._value;
        public static implicit operator decimal(xulong value) => value._value;
        public static implicit operator double(xulong value) => value._value;
        public static implicit operator float(xulong value) => value._value;
        public static implicit operator ulong(xulong value) => value._value;

        public static bool operator !=(xulong left, xulong right) => left._value != right._value;
        public static bool operator <(xulong left, xulong right) => left._value < right._value;
        public static bool operator <=(xulong left, xulong right) => left._value <= right._value;
        public static bool operator ==(xulong left, xulong right) => left._value == right._value;
        public static bool operator >(xulong left, xulong right) => left._value > right._value;
        public static bool operator >=(xulong left, xulong right) => left._value >= right._value;
        public static xulong operator %(xulong left, xulong right) => left._value % right._value;
        public static xulong operator &(xulong left, xulong right) => left._value & right._value;
        public static xulong operator -(xulong left, xulong right) => left._value - right._value;
        public static xulong operator --(xulong value) => value._value - 1;
        public static xulong operator -(xulong value) => 0 - value._value;
        public static xulong operator *(xulong left, xulong right) => left._value * right._value;
        public static xulong operator /(xulong left, xulong right) => left._value / right._value;
        public static xulong operator ^(xulong left, xulong right) => left._value ^ right._value;
        public static xulong operator |(xulong left, xulong right) => left._value | right._value;
        public static xulong operator ~(xulong value) => ~value._value;
        public static xulong operator +(xulong left, xulong right) => left._value + right._value;
        public static xulong operator +(xulong value) => value;
        public static xulong operator ++(xulong value) => value._value + 1;
        public static xulong operator <<(xulong left, int right) => left._value << right;
        public static xulong operator >>(xulong left, int right) => left._value >> right;

        bool INumeric<xulong>.IsGreaterThan(xulong value) => this > value;
        bool INumeric<xulong>.IsGreaterThanOrEqualTo(xulong value) => this >= value;
        bool INumeric<xulong>.IsLessThan(xulong value) => this < value;
        bool INumeric<xulong>.IsLessThanOrEqualTo(xulong value) => this <= value;
        xulong INumeric<xulong>.Add(xulong value) => this + value;
        xulong INumeric<xulong>.BitwiseComplement() => ~this;
        xulong INumeric<xulong>.Divide(xulong value) => this / value;
        xulong INumeric<xulong>.LeftShift(int count) => this << count;
        xulong INumeric<xulong>.LogicalAnd(xulong value) => this & value;
        xulong INumeric<xulong>.LogicalExclusiveOr(xulong value) => this ^ value;
        xulong INumeric<xulong>.LogicalOr(xulong value) => this | value;
        xulong INumeric<xulong>.Multiply(xulong value) => this * value;
        xulong INumeric<xulong>.Negative() => -this;
        xulong INumeric<xulong>.Positive() => +this;
        xulong INumeric<xulong>.Remainder(xulong value) => this % value;
        xulong INumeric<xulong>.RightShift(int count) => this >> count;
        xulong INumeric<xulong>.Subtract(xulong value) => this - value;

        IBitConverter<xulong> IBitConvertible<xulong>.BitConverter => Utilities.Instance;
        IConvert<xulong> IConvertible<xulong>.Convert => Utilities.Instance;
        IMath<xulong> INumeric<xulong>.Math => Utilities.Instance;
        INumericFunctions<xulong> INumeric<xulong>.NumericFunctions => Utilities.Instance;
        IRandom<xulong> IRandomisable<xulong>.Random => Utilities.Instance;
        IStringParser<xulong> IStringParsable<xulong>.StringParser => Utilities.Instance;

        private sealed class Utilities :
            IBitConverter<xulong>,
            IConvert<xulong>,
            IMath<xulong>,
            INumericFunctions<xulong>,
            IRandom<xulong>,
            IStringParser<xulong>
        {
            public readonly static Utilities Instance = new Utilities();

            bool INumericFunctions<xulong>.HasFloatingPoint { get; } = false;
            bool INumericFunctions<xulong>.IsReal { get; } = false;
            bool INumericFunctions<xulong>.IsSigned { get; } = false;
            xulong IMath<xulong>.E { get; } = (xulong)2;
            xulong INumericFunctions<xulong>.Epsilon { get; } = (xulong)1;
            xulong INumericFunctions<xulong>.MaxUnit { get; } = (xulong)1;
            xulong INumericFunctions<xulong>.MaxValue => MaxValue;
            xulong INumericFunctions<xulong>.MinUnit { get; } = (xulong)0;
            xulong INumericFunctions<xulong>.MinValue => MinValue;
            xulong INumericFunctions<xulong>.One { get; } = (xulong)1;
            xulong IMath<xulong>.PI { get; } = (xulong)3;
            xulong IMath<xulong>.Tau { get; } = (xulong)6;
            xulong INumericFunctions<xulong>.Ten { get; } = (xulong)10;
            xulong INumericFunctions<xulong>.Two { get; } = (xulong)2;
            xulong INumericFunctions<xulong>.Zero { get; } = (xulong)0;

            int IMath<xulong>.Sign(xulong x) => x._value == 0 ? 0 : 1;
            bool INumericFunctions<xulong>.IsFinite(xulong x) => true;
            bool INumericFunctions<xulong>.IsInfinity(xulong x) => false;
            bool INumericFunctions<xulong>.IsNaN(xulong x) => false;
            bool INumericFunctions<xulong>.IsNegative(xulong x) => false;
            bool INumericFunctions<xulong>.IsNegativeInfinity(xulong x) => false;
            bool INumericFunctions<xulong>.IsNormal(xulong x) => false;
            bool INumericFunctions<xulong>.IsPositiveInfinity(xulong x) => false;
            bool INumericFunctions<xulong>.IsSubnormal(xulong x) => false;

            xulong IMath<xulong>.Abs(xulong x) => x;
            xulong IMath<xulong>.Acos(xulong x) => (xulong)Math.Acos(x);
            xulong IMath<xulong>.Acosh(xulong x) => (xulong)Math.Acosh(x);
            xulong IMath<xulong>.Asin(xulong x) => (xulong)Math.Asin(x);
            xulong IMath<xulong>.Asinh(xulong x) => (xulong)Math.Asinh(x);
            xulong IMath<xulong>.Atan(xulong x) => (xulong)Math.Atan(x);
            xulong IMath<xulong>.Atan2(xulong y, xulong x) => (xulong)Math.Atan2(y, x);
            xulong IMath<xulong>.Atanh(xulong x) => (xulong)Math.Atanh(x);
            xulong IMath<xulong>.Cbrt(xulong x) => (xulong)Math.Cbrt(x);
            xulong IMath<xulong>.Ceiling(xulong x) => x;
            xulong IMath<xulong>.Clamp(xulong x, xulong bound1, xulong bound2) => bound1 > bound2 ? Math.Min(bound1, Math.Max(bound2, x)) : Math.Min(bound2, Math.Max(bound1, x));
            xulong IMath<xulong>.Cos(xulong x) => (xulong)Math.Cos(x);
            xulong IMath<xulong>.Cosh(xulong x) => (xulong)Math.Cosh(x);
            xulong IMath<xulong>.DegreesToRadians(xulong x) => (xulong)(x * Trig.RadiansPerDegree);
            xulong IMath<xulong>.Exp(xulong x) => (xulong)Math.Exp(x);
            xulong IMath<xulong>.Floor(xulong x) => x;
            xulong IMath<xulong>.IEEERemainder(xulong x, xulong y) => (xulong)Math.IEEERemainder(x, y);
            xulong IMath<xulong>.Log(xulong x) => (xulong)Math.Log(x);
            xulong IMath<xulong>.Log(xulong x, xulong y) => (xulong)Math.Log(x, y);
            xulong IMath<xulong>.Log10(xulong x) => (xulong)Math.Log10(x);
            xulong IMath<xulong>.Max(xulong x, xulong y) => Math.Max(x, y);
            xulong IMath<xulong>.Min(xulong x, xulong y) => Math.Min(x, y);
            xulong IMath<xulong>.Pow(xulong x, xulong y) => y == 1 ? x : (xulong)Math.Pow(x, y);
            xulong IMath<xulong>.RadiansToDegrees(xulong x) => (xulong)(x * Trig.DegreesPerRadian);
            xulong IMath<xulong>.Round(xulong x) => x;
            xulong IMath<xulong>.Round(xulong x, int digits) => x;
            xulong IMath<xulong>.Round(xulong x, int digits, MidpointRounding mode) => x;
            xulong IMath<xulong>.Round(xulong x, MidpointRounding mode) => x;
            xulong IMath<xulong>.Sin(xulong x) => (xulong)Math.Sin(x);
            xulong IMath<xulong>.Sinh(xulong x) => (xulong)Math.Sinh(x);
            xulong IMath<xulong>.Sqrt(xulong x) => (xulong)Math.Sqrt(x);
            xulong IMath<xulong>.Tan(xulong x) => (xulong)Math.Tan(x);
            xulong IMath<xulong>.Tanh(xulong x) => (xulong)Math.Tanh(x);
            xulong IMath<xulong>.Truncate(xulong x) => x;

            xulong IBitConverter<xulong>.Read(IReadOnlyStream<byte> stream) => BitConverter.ToUInt64(stream.Read(sizeof(ulong)));
            void IBitConverter<xulong>.Write(xulong value, IWriteOnlyStream<byte> stream) => stream.Write(BitConverter.GetBytes(value._value));

            xulong IRandom<xulong>.Next(Random random) => random.NextUInt64();
            xulong IRandom<xulong>.Next(Random random, xulong bound1, xulong bound2) => random.NextUInt64(bound1._value, bound2._value);

            bool IConvert<xulong>.ToBoolean(xulong value) => Convert.ToBoolean(value._value);
            byte IConvert<xulong>.ToByte(xulong value) => Convert.ToByte(value._value);
            decimal IConvert<xulong>.ToDecimal(xulong value) => Convert.ToDecimal(value._value);
            double IConvert<xulong>.ToDouble(xulong value) => Convert.ToDouble(value._value);
            float IConvert<xulong>.ToSingle(xulong value) => Convert.ToSingle(value._value);
            int IConvert<xulong>.ToInt32(xulong value) => Convert.ToInt32(value._value);
            long IConvert<xulong>.ToInt64(xulong value) => Convert.ToInt64(value._value);
            sbyte IConvert<xulong>.ToSByte(xulong value) => Convert.ToSByte(value._value);
            short IConvert<xulong>.ToInt16(xulong value) => Convert.ToInt16(value._value);
            string IConvert<xulong>.ToString(xulong value) => Convert.ToString(value._value);
            string IConvert<xulong>.ToString(xulong value, IFormatProvider provider) => Convert.ToString(value._value, provider);
            uint IConvert<xulong>.ToUInt32(xulong value) => Convert.ToUInt32(value._value);
            ulong IConvert<xulong>.ToUInt64(xulong value) => Convert.ToUInt64(value._value);
            ushort IConvert<xulong>.ToUInt16(xulong value) => Convert.ToUInt16(value._value);

            xulong IConvert<xulong>.ToValue(bool value) => Convert.ToUInt64(value);
            xulong IConvert<xulong>.ToValue(byte value) => Convert.ToUInt64(value);
            xulong IConvert<xulong>.ToValue(decimal value) => Convert.ToUInt64(value);
            xulong IConvert<xulong>.ToValue(double value) => Convert.ToUInt64(value);
            xulong IConvert<xulong>.ToValue(float value) => Convert.ToUInt64(value);
            xulong IConvert<xulong>.ToValue(int value) => Convert.ToUInt64(value);
            xulong IConvert<xulong>.ToValue(long value) => Convert.ToUInt64(value);
            xulong IConvert<xulong>.ToValue(sbyte value) => Convert.ToUInt64(value);
            xulong IConvert<xulong>.ToValue(short value) => Convert.ToUInt64(value);
            xulong IConvert<xulong>.ToValue(string value) => Convert.ToUInt64(value);
            xulong IConvert<xulong>.ToValue(string value, IFormatProvider provider) => Convert.ToUInt64(value, provider);
            xulong IConvert<xulong>.ToValue(uint value) => Convert.ToUInt64(value);
            xulong IConvert<xulong>.ToValue(ulong value) => Convert.ToUInt64(value);
            xulong IConvert<xulong>.ToValue(ushort value) => Convert.ToUInt64(value);

            bool IStringParser<xulong>.TryParse(string s, IFormatProvider provider, out xulong result) => TryParse(s, provider, out result);
            bool IStringParser<xulong>.TryParse(string s, NumberStyles style, IFormatProvider provider, out xulong result) => TryParse(s, style, provider, out result);
            bool IStringParser<xulong>.TryParse(string s, NumberStyles style, out xulong result) => TryParse(s, style, out result);
            bool IStringParser<xulong>.TryParse(string s, out xulong result) => TryParse(s, out result);
            xulong IStringParser<xulong>.Parse(string s) => Parse(s);
            xulong IStringParser<xulong>.Parse(string s, IFormatProvider provider) => Parse(s, provider);
            xulong IStringParser<xulong>.Parse(string s, NumberStyles style) => Parse(s, style);
            xulong IStringParser<xulong>.Parse(string s, NumberStyles style, IFormatProvider provider) => Parse(s, style, provider);
        }
    }
}
