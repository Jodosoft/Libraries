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
    public readonly struct xlong : INumeric<xlong>
    {
        public static readonly xlong MaxValue = new xlong(long.MaxValue);
        public static readonly xlong MinValue = new xlong(long.MinValue);

        private readonly long _value;

        private xlong(long value)
        {
            _value = value;
        }

        private xlong(SerializationInfo info, StreamingContext context) : this(info.GetInt64(nameof(xlong))) { }
        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context) => info.AddValue(nameof(xlong), _value);

        public int CompareTo(xlong other) => _value.CompareTo(other._value);
        public int CompareTo(object? obj) => obj is xlong other ? CompareTo(other) : 1;
        public bool Equals(xlong other) => _value == other._value;
        public override bool Equals(object? obj) => obj is xlong other && Equals(other);
        public override int GetHashCode() => _value.GetHashCode();
        public override string ToString() => _value.ToString();
        public string ToString(IFormatProvider formatProvider) => _value.ToString(formatProvider);
        public string ToString(string format) => _value.ToString(format);
        public string ToString(string format, IFormatProvider formatProvider) => _value.ToString(format, formatProvider);

        public static bool TryParse(string s, IFormatProvider provider, out xlong result) => Try.Run(() => Parse(s, provider), out result);
        public static bool TryParse(string s, NumberStyles style, IFormatProvider provider, out xlong result) => Try.Run(() => Parse(s, style, provider), out result);
        public static bool TryParse(string s, NumberStyles style, out xlong result) => Try.Run(() => Parse(s, style), out result);
        public static bool TryParse(string s, out xlong result) => Try.Run(() => Parse(s), out result);
        public static xlong Parse(string s) => long.Parse(s);
        public static xlong Parse(string s, IFormatProvider provider) => long.Parse(s, provider);
        public static xlong Parse(string s, NumberStyles style) => long.Parse(s, style);
        public static xlong Parse(string s, NumberStyles style, IFormatProvider provider) => long.Parse(s, style, provider);

        public static explicit operator xlong(decimal value) => new xlong((long)value);
        public static explicit operator xlong(double value) => new xlong((long)value);
        public static explicit operator xlong(float value) => new xlong((long)value);
        public static explicit operator xlong(ulong value) => new xlong((long)value);
        public static implicit operator xlong(byte value) => new xlong(value);
        public static implicit operator xlong(int value) => new xlong(value);
        public static implicit operator xlong(long value) => new xlong(value);
        public static implicit operator xlong(sbyte value) => new xlong(value);
        public static implicit operator xlong(short value) => new xlong(value);
        public static implicit operator xlong(uint value) => new xlong(value);
        public static implicit operator xlong(ushort value) => new xlong(value);

        public static explicit operator byte(xlong value) => (byte)value._value;
        public static explicit operator int(xlong value) => (int)value._value;
        public static explicit operator sbyte(xlong value) => (sbyte)value._value;
        public static explicit operator short(xlong value) => (short)value._value;
        public static explicit operator uint(xlong value) => (uint)value._value;
        public static explicit operator ulong(xlong value) => (ulong)value._value;
        public static explicit operator ushort(xlong value) => (ushort)value._value;
        public static implicit operator decimal(xlong value) => value._value;
        public static implicit operator double(xlong value) => value._value;
        public static implicit operator float(xlong value) => value._value;
        public static implicit operator long(xlong value) => value._value;

        public static bool operator !=(xlong left, xlong right) => left._value != right._value;
        public static bool operator <(xlong left, xlong right) => left._value < right._value;
        public static bool operator <=(xlong left, xlong right) => left._value <= right._value;
        public static bool operator ==(xlong left, xlong right) => left._value == right._value;
        public static bool operator >(xlong left, xlong right) => left._value > right._value;
        public static bool operator >=(xlong left, xlong right) => left._value >= right._value;
        public static xlong operator %(xlong left, xlong right) => left._value % right._value;
        public static xlong operator &(xlong left, xlong right) => left._value & right._value;
        public static xlong operator -(xlong left, xlong right) => left._value - right._value;
        public static xlong operator --(xlong value) => value._value - 1;
        public static xlong operator -(xlong value) => -value._value;
        public static xlong operator *(xlong left, xlong right) => left._value * right._value;
        public static xlong operator /(xlong left, xlong right) => left._value / right._value;
        public static xlong operator ^(xlong left, xlong right) => left._value ^ right._value;
        public static xlong operator |(xlong left, xlong right) => left._value | right._value;
        public static xlong operator ~(xlong value) => ~value._value;
        public static xlong operator +(xlong left, xlong right) => left._value + right._value;
        public static xlong operator +(xlong value) => value;
        public static xlong operator ++(xlong value) => value._value + 1;
        public static xlong operator <<(xlong left, int right) => left._value << right;
        public static xlong operator >>(xlong left, int right) => left._value >> right;

        bool INumeric<xlong>.IsGreaterThan(xlong value) => this > value;
        bool INumeric<xlong>.IsGreaterThanOrEqualTo(xlong value) => this >= value;
        bool INumeric<xlong>.IsLessThan(xlong value) => this < value;
        bool INumeric<xlong>.IsLessThanOrEqualTo(xlong value) => this <= value;
        xlong INumeric<xlong>.Add(xlong value) => this + value;
        xlong INumeric<xlong>.BitwiseComplement() => ~this;
        xlong INumeric<xlong>.Divide(xlong value) => this / value;
        xlong INumeric<xlong>.LeftShift(int count) => this << count;
        xlong INumeric<xlong>.LogicalAnd(xlong value) => this & value;
        xlong INumeric<xlong>.LogicalExclusiveOr(xlong value) => this ^ value;
        xlong INumeric<xlong>.LogicalOr(xlong value) => this | value;
        xlong INumeric<xlong>.Multiply(xlong value) => this * value;
        xlong INumeric<xlong>.Negative() => -this;
        xlong INumeric<xlong>.Positive() => +this;
        xlong INumeric<xlong>.Remainder(xlong value) => this % value;
        xlong INumeric<xlong>.RightShift(int count) => this >> count;
        xlong INumeric<xlong>.Subtract(xlong value) => this - value;

        IBitConverter<xlong> IProvider<IBitConverter<xlong>>.GetInstance() => Utilities.Instance;
        ICast<xlong> IProvider<ICast<xlong>>.GetInstance() => Utilities.Instance;
        IConvert<xlong> IProvider<IConvert<xlong>>.GetInstance() => Utilities.Instance;
        IMath<xlong> IProvider<IMath<xlong>>.GetInstance() => Utilities.Instance;
        INumericFunctions<xlong> IProvider<INumericFunctions<xlong>>.GetInstance() => Utilities.Instance;
        IRandom<xlong> IProvider<IRandom<xlong>>.GetInstance() => Utilities.Instance;
        IStringParser<xlong> IProvider<IStringParser<xlong>>.GetInstance() => Utilities.Instance;

        private sealed class Utilities :
            IBitConverter<xlong>,
            ICast<xlong>,
            IConvert<xlong>,
            IMath<xlong>,
            INumericFunctions<xlong>,
            IRandom<xlong>,
            IStringParser<xlong>
        {
            public readonly static Utilities Instance = new Utilities();

            bool INumericFunctions<xlong>.HasFloatingPoint { get; } = false;
            bool INumericFunctions<xlong>.IsFinite(xlong x) => true;
            bool INumericFunctions<xlong>.IsInfinity(xlong x) => false;
            bool INumericFunctions<xlong>.IsNaN(xlong x) => false;
            bool INumericFunctions<xlong>.IsNegative(xlong x) => x._value < 0;
            bool INumericFunctions<xlong>.IsNegativeInfinity(xlong x) => false;
            bool INumericFunctions<xlong>.IsNormal(xlong x) => false;
            bool INumericFunctions<xlong>.IsPositiveInfinity(xlong x) => false;
            bool INumericFunctions<xlong>.IsReal { get; } = false;
            bool INumericFunctions<xlong>.IsSigned { get; } = true;
            bool INumericFunctions<xlong>.IsSubnormal(xlong x) => false;
            xlong INumericFunctions<xlong>.Epsilon { get; } = 1L;
            xlong INumericFunctions<xlong>.MaxUnit { get; } = 1L;
            xlong INumericFunctions<xlong>.MaxValue => MaxValue;
            xlong INumericFunctions<xlong>.MinUnit { get; } = -1L;
            xlong INumericFunctions<xlong>.MinValue => MinValue;
            xlong INumericFunctions<xlong>.One { get; } = 1L;
            xlong INumericFunctions<xlong>.Ten { get; } = 10L;
            xlong INumericFunctions<xlong>.Two { get; } = 2L;
            xlong INumericFunctions<xlong>.Zero { get; } = 0;

            int IMath<xlong>.Sign(xlong x) => Math.Sign(x._value);
            xlong IMath<xlong>.Abs(xlong x) => Math.Abs(x);
            xlong IMath<xlong>.Acos(xlong x) => (xlong)Math.Acos(x);
            xlong IMath<xlong>.Acosh(xlong x) => (xlong)Math.Acosh(x);
            xlong IMath<xlong>.Asin(xlong x) => (xlong)Math.Asin(x);
            xlong IMath<xlong>.Asinh(xlong x) => (xlong)Math.Asinh(x);
            xlong IMath<xlong>.Atan(xlong x) => (xlong)Math.Atan(x);
            xlong IMath<xlong>.Atan2(xlong y, xlong x) => (xlong)Math.Atan2(y, x);
            xlong IMath<xlong>.Atanh(xlong x) => (xlong)Math.Atanh(x);
            xlong IMath<xlong>.Cbrt(xlong x) => (xlong)Math.Cbrt(x);
            xlong IMath<xlong>.Ceiling(xlong x) => x;
            xlong IMath<xlong>.Clamp(xlong x, xlong bound1, xlong bound2) => bound1 > bound2 ? Math.Min(bound1, Math.Max(bound2, x)) : Math.Min(bound2, Math.Max(bound1, x));
            xlong IMath<xlong>.Cos(xlong x) => (xlong)Math.Cos(x);
            xlong IMath<xlong>.Cosh(xlong x) => (xlong)Math.Cosh(x);
            xlong IMath<xlong>.DegreesToRadians(xlong x) => (xlong)(x * Trig.RadiansPerDegree);
            xlong IMath<xlong>.E { get; } = 2L;
            xlong IMath<xlong>.Exp(xlong x) => (xlong)Math.Exp(x);
            xlong IMath<xlong>.Floor(xlong x) => x;
            xlong IMath<xlong>.IEEERemainder(xlong x, xlong y) => (xlong)Math.IEEERemainder(x, y);
            xlong IMath<xlong>.Log(xlong x) => (xlong)Math.Log(x);
            xlong IMath<xlong>.Log(xlong x, xlong y) => (xlong)Math.Log(x, y);
            xlong IMath<xlong>.Log10(xlong x) => (xlong)Math.Log10(x);
            xlong IMath<xlong>.Max(xlong x, xlong y) => Math.Max(x, y);
            xlong IMath<xlong>.Min(xlong x, xlong y) => Math.Min(x, y);
            xlong IMath<xlong>.PI { get; } = 3L;
            xlong IMath<xlong>.Pow(xlong x, xlong y) => y == 1 ? x : (xlong)Math.Pow(x, y);
            xlong IMath<xlong>.RadiansToDegrees(xlong x) => (xlong)(x * Trig.DegreesPerRadian);
            xlong IMath<xlong>.Round(xlong x) => x;
            xlong IMath<xlong>.Round(xlong x, int digits) => x;
            xlong IMath<xlong>.Round(xlong x, int digits, MidpointRounding mode) => x;
            xlong IMath<xlong>.Round(xlong x, MidpointRounding mode) => x;
            xlong IMath<xlong>.Sin(xlong x) => (xlong)Math.Sin(x);
            xlong IMath<xlong>.Sinh(xlong x) => (xlong)Math.Sinh(x);
            xlong IMath<xlong>.Sqrt(xlong x) => (xlong)Math.Sqrt(x);
            xlong IMath<xlong>.Tan(xlong x) => (xlong)Math.Tan(x);
            xlong IMath<xlong>.Tanh(xlong x) => (xlong)Math.Tanh(x);
            xlong IMath<xlong>.Tau { get; } = 6L;
            xlong IMath<xlong>.Truncate(xlong x) => x;

            xlong IBitConverter<xlong>.Read(IReadOnlyStream<byte> stream) => BitConverter.ToInt64(stream.Read(sizeof(long)));
            void IBitConverter<xlong>.Write(xlong value, IWriteOnlyStream<byte> stream) => stream.Write(BitConverter.GetBytes(value._value));

            xlong IRandom<xlong>.Next(Random random) => random.NextInt64();
            xlong IRandom<xlong>.Next(Random random, xlong bound1, xlong bound2) => random.NextInt64(bound1._value, bound2._value);

            bool IConvert<xlong>.ToBoolean(xlong value) => Convert.ToBoolean(value._value);
            byte IConvert<xlong>.ToByte(xlong value) => Convert.ToByte(value._value);
            decimal IConvert<xlong>.ToDecimal(xlong value) => Convert.ToDecimal(value._value);
            double IConvert<xlong>.ToDouble(xlong value) => Convert.ToDouble(value._value);
            float IConvert<xlong>.ToSingle(xlong value) => Convert.ToSingle(value._value);
            int IConvert<xlong>.ToInt32(xlong value) => Convert.ToInt32(value._value);
            long IConvert<xlong>.ToInt64(xlong value) => Convert.ToInt64(value._value);
            sbyte IConvert<xlong>.ToSByte(xlong value) => Convert.ToSByte(value._value);
            short IConvert<xlong>.ToInt16(xlong value) => Convert.ToInt16(value._value);
            string IConvert<xlong>.ToString(xlong value) => Convert.ToString(value._value);
            string IConvert<xlong>.ToString(xlong value, IFormatProvider provider) => Convert.ToString(value._value, provider);
            uint IConvert<xlong>.ToUInt32(xlong value) => Convert.ToUInt32(value._value);
            ulong IConvert<xlong>.ToUInt64(xlong value) => Convert.ToUInt64(value._value);
            ushort IConvert<xlong>.ToUInt16(xlong value) => Convert.ToUInt16(value._value);

            xlong IConvert<xlong>.ToValue(bool value) => Convert.ToInt64(value);
            xlong IConvert<xlong>.ToValue(byte value) => Convert.ToInt64(value);
            xlong IConvert<xlong>.ToValue(decimal value) => Convert.ToInt64(value);
            xlong IConvert<xlong>.ToValue(double value) => Convert.ToInt64(value);
            xlong IConvert<xlong>.ToValue(float value) => Convert.ToInt64(value);
            xlong IConvert<xlong>.ToValue(int value) => Convert.ToInt64(value);
            xlong IConvert<xlong>.ToValue(long value) => Convert.ToInt64(value);
            xlong IConvert<xlong>.ToValue(sbyte value) => Convert.ToInt64(value);
            xlong IConvert<xlong>.ToValue(short value) => Convert.ToInt64(value);
            xlong IConvert<xlong>.ToValue(string value) => Convert.ToInt64(value);
            xlong IConvert<xlong>.ToValue(string value, IFormatProvider provider) => Convert.ToInt64(value, provider);
            xlong IConvert<xlong>.ToValue(uint value) => Convert.ToInt64(value);
            xlong IConvert<xlong>.ToValue(ulong value) => Convert.ToInt64(value);
            xlong IConvert<xlong>.ToValue(ushort value) => Convert.ToInt64(value);

            bool IStringParser<xlong>.TryParse(string s, IFormatProvider provider, out xlong result) => TryParse(s, provider, out result);
            bool IStringParser<xlong>.TryParse(string s, NumberStyles style, IFormatProvider provider, out xlong result) => TryParse(s, style, provider, out result);
            bool IStringParser<xlong>.TryParse(string s, NumberStyles style, out xlong result) => TryParse(s, style, out result);
            bool IStringParser<xlong>.TryParse(string s, out xlong result) => TryParse(s, out result);
            xlong IStringParser<xlong>.Parse(string s) => Parse(s);
            xlong IStringParser<xlong>.Parse(string s, IFormatProvider provider) => Parse(s, provider);
            xlong IStringParser<xlong>.Parse(string s, NumberStyles style) => Parse(s, style);
            xlong IStringParser<xlong>.Parse(string s, NumberStyles style, IFormatProvider provider) => Parse(s, style, provider);

            byte ICast<xlong>.ToByte(xlong value) => (byte)value;
            decimal ICast<xlong>.ToDecimal(xlong value) => (decimal)value;
            double ICast<xlong>.ToDouble(xlong value) => (double)value;
            float ICast<xlong>.ToSingle(xlong value) => (float)value;
            int ICast<xlong>.ToInt32(xlong value) => (int)value;
            long ICast<xlong>.ToInt64(xlong value) => (long)value;
            sbyte ICast<xlong>.ToSByte(xlong value) => (sbyte)value;
            short ICast<xlong>.ToInt16(xlong value) => (short)value;
            uint ICast<xlong>.ToUInt32(xlong value) => (uint)value;
            ulong ICast<xlong>.ToUInt64(xlong value) => (ulong)value;
            ushort ICast<xlong>.ToUInt16(xlong value) => (ushort)value;

            xlong ICast<xlong>.ToValue(byte value) => (xlong)value;
            xlong ICast<xlong>.ToValue(decimal value) => (xlong)value;
            xlong ICast<xlong>.ToValue(double value) => (xlong)value;
            xlong ICast<xlong>.ToValue(float value) => (xlong)value;
            xlong ICast<xlong>.ToValue(int value) => (xlong)value;
            xlong ICast<xlong>.ToValue(long value) => (xlong)value;
            xlong ICast<xlong>.ToValue(sbyte value) => (xlong)value;
            xlong ICast<xlong>.ToValue(short value) => (xlong)value;
            xlong ICast<xlong>.ToValue(uint value) => (xlong)value;
            xlong ICast<xlong>.ToValue(ulong value) => (xlong)value;
            xlong ICast<xlong>.ToValue(ushort value) => (xlong)value;
        }
    }
}
