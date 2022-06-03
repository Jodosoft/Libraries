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
    public readonly struct xbyte : INumeric<xbyte>
    {
        public static readonly xbyte MaxValue = new xbyte(byte.MaxValue);
        public static readonly xbyte MinValue = new xbyte(byte.MinValue);

        private readonly byte _value;

        private xbyte(byte value)
        {
            _value = value;
        }

        private xbyte(SerializationInfo info, StreamingContext context) : this(info.GetByte(nameof(xbyte))) { }
        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context) => info.AddValue(nameof(xbyte), _value);

        public int CompareTo(xbyte other) => _value.CompareTo(other._value);
        public int CompareTo(object? obj) => obj is xbyte other ? CompareTo(other) : 1;
        public bool Equals(xbyte other) => _value == other._value;
        public override bool Equals(object? obj) => obj is xbyte other && Equals(other);
        public override int GetHashCode() => _value.GetHashCode();
        public override string ToString() => _value.ToString();
        public string ToString(IFormatProvider formatProvider) => _value.ToString(formatProvider);
        public string ToString(string format) => _value.ToString(format);
        public string ToString(string format, IFormatProvider formatProvider) => _value.ToString(format, formatProvider);

        public static bool TryParse(string s, IFormatProvider provider, out xbyte result) => Try.Run(() => Parse(s, provider), out result);
        public static bool TryParse(string s, NumberStyles style, IFormatProvider provider, out xbyte result) => Try.Run(() => Parse(s, style, provider), out result);
        public static bool TryParse(string s, NumberStyles style, out xbyte result) => Try.Run(() => Parse(s, style), out result);
        public static bool TryParse(string s, out xbyte result) => Try.Run(() => Parse(s), out result);
        public static xbyte Parse(string s) => byte.Parse(s);
        public static xbyte Parse(string s, IFormatProvider provider) => byte.Parse(s, provider);
        public static xbyte Parse(string s, NumberStyles style) => byte.Parse(s, style);
        public static xbyte Parse(string s, NumberStyles style, IFormatProvider provider) => byte.Parse(s, style, provider);

        public static explicit operator xbyte(decimal value) => new xbyte((byte)value);
        public static explicit operator xbyte(double value) => new xbyte((byte)value);
        public static explicit operator xbyte(float value) => new xbyte((byte)value);
        public static explicit operator xbyte(int value) => new xbyte((byte)value);
        public static explicit operator xbyte(long value) => new xbyte((byte)value);
        public static explicit operator xbyte(sbyte value) => new xbyte((byte)value);
        public static explicit operator xbyte(short value) => new xbyte((byte)value);
        public static explicit operator xbyte(uint value) => new xbyte((byte)value);
        public static explicit operator xbyte(ulong value) => new xbyte((byte)value);
        public static explicit operator xbyte(ushort value) => new xbyte((byte)value);
        public static implicit operator xbyte(byte value) => new xbyte(value);

        public static explicit operator sbyte(xbyte value) => (sbyte)value._value;
        public static implicit operator byte(xbyte value) => value._value;
        public static implicit operator decimal(xbyte value) => value._value;
        public static implicit operator double(xbyte value) => value._value;
        public static implicit operator float(xbyte value) => value._value;
        public static implicit operator int(xbyte value) => value._value;
        public static implicit operator long(xbyte value) => value._value;
        public static implicit operator short(xbyte value) => value._value;
        public static implicit operator uint(xbyte value) => value._value;
        public static implicit operator ulong(xbyte value) => value._value;
        public static implicit operator ushort(xbyte value) => value._value;

        public static bool operator !=(xbyte left, xbyte right) => left._value != right._value;
        public static bool operator <(xbyte left, xbyte right) => left._value < right._value;
        public static bool operator <=(xbyte left, xbyte right) => left._value <= right._value;
        public static bool operator ==(xbyte left, xbyte right) => left._value == right._value;
        public static bool operator >(xbyte left, xbyte right) => left._value > right._value;
        public static bool operator >=(xbyte left, xbyte right) => left._value >= right._value;
        public static xbyte operator %(xbyte left, xbyte right) => (byte)(left._value % right._value);
        public static xbyte operator &(xbyte left, xbyte right) => (byte)(left._value & right._value);
        public static xbyte operator -(xbyte left, xbyte right) => (byte)(left._value - right._value);
        public static xbyte operator --(xbyte value) => (byte)(value._value - 1);
        public static xbyte operator -(xbyte value) => (byte)-value._value;
        public static xbyte operator *(xbyte left, xbyte right) => (byte)(left._value * right._value);
        public static xbyte operator /(xbyte left, xbyte right) => (byte)(left._value / right._value);
        public static xbyte operator ^(xbyte left, xbyte right) => (byte)(left._value ^ right._value);
        public static xbyte operator |(xbyte left, xbyte right) => (byte)(left._value | right._value);
        public static xbyte operator ~(xbyte value) => (byte)~value._value;
        public static xbyte operator +(xbyte left, xbyte right) => (byte)(left._value + right._value);
        public static xbyte operator +(xbyte value) => value;
        public static xbyte operator ++(xbyte value) => (byte)(value._value + 1);
        public static xbyte operator <<(xbyte left, int right) => (byte)(left._value << right);
        public static xbyte operator >>(xbyte left, int right) => (byte)(left._value >> right);

        bool INumeric<xbyte>.IsGreaterThan(xbyte value) => this > value;
        bool INumeric<xbyte>.IsGreaterThanOrEqualTo(xbyte value) => this >= value;
        bool INumeric<xbyte>.IsLessThan(xbyte value) => this < value;
        bool INumeric<xbyte>.IsLessThanOrEqualTo(xbyte value) => this <= value;
        xbyte INumeric<xbyte>.Add(xbyte value) => this + value;
        xbyte INumeric<xbyte>.BitwiseComplement() => ~this;
        xbyte INumeric<xbyte>.Divide(xbyte value) => this / value;
        xbyte INumeric<xbyte>.LeftShift(int count) => this << count;
        xbyte INumeric<xbyte>.LogicalAnd(xbyte value) => this & value;
        xbyte INumeric<xbyte>.LogicalExclusiveOr(xbyte value) => this ^ value;
        xbyte INumeric<xbyte>.LogicalOr(xbyte value) => this | value;
        xbyte INumeric<xbyte>.Multiply(xbyte value) => this * value;
        xbyte INumeric<xbyte>.Negative() => -this;
        xbyte INumeric<xbyte>.Positive() => +this;
        xbyte INumeric<xbyte>.Remainder(xbyte value) => this % value;
        xbyte INumeric<xbyte>.RightShift(int count) => this >> count;
        xbyte INumeric<xbyte>.Subtract(xbyte value) => this - value;

        IBitConverter<xbyte> IProvider<IBitConverter<xbyte>>.GetInstance() => Utilities.Instance;
        ICast<xbyte> IProvider<ICast<xbyte>>.GetInstance() => Utilities.Instance;
        IConvert<xbyte> IProvider<IConvert<xbyte>>.GetInstance() => Utilities.Instance;
        IMath<xbyte> IProvider<IMath<xbyte>>.GetInstance() => Utilities.Instance;
        INumericStatic<xbyte> IProvider<INumericStatic<xbyte>>.GetInstance() => Utilities.Instance;
        IRandom<xbyte> IProvider<IRandom<xbyte>>.GetInstance() => Utilities.Instance;
        IStringParser<xbyte> IProvider<IStringParser<xbyte>>.GetInstance() => Utilities.Instance;

        private sealed class Utilities :
            IBitConverter<xbyte>,
            ICast<xbyte>,
            IConvert<xbyte>,
            IMath<xbyte>,
            INumericStatic<xbyte>,
            IRandom<xbyte>,
            IStringParser<xbyte>
        {
            public readonly static Utilities Instance = new Utilities();

            bool INumericStatic<xbyte>.HasFloatingPoint { get; } = false;
            bool INumericStatic<xbyte>.HasInfinity { get; } = false;
            bool INumericStatic<xbyte>.HasNaN { get; } = false;
            bool INumericStatic<xbyte>.IsFinite(xbyte x) => true;
            bool INumericStatic<xbyte>.IsInfinity(xbyte x) => false;
            bool INumericStatic<xbyte>.IsNaN(xbyte x) => false;
            bool INumericStatic<xbyte>.IsNegative(xbyte x) => false;
            bool INumericStatic<xbyte>.IsNegativeInfinity(xbyte x) => false;
            bool INumericStatic<xbyte>.IsNormal(xbyte x) => false;
            bool INumericStatic<xbyte>.IsPositiveInfinity(xbyte x) => false;
            bool INumericStatic<xbyte>.IsReal { get; } = false;
            bool INumericStatic<xbyte>.IsSigned { get; } = false;
            bool INumericStatic<xbyte>.IsSubnormal(xbyte x) => false;
            xbyte INumericStatic<xbyte>.Epsilon { get; } = 1;
            xbyte INumericStatic<xbyte>.MaxUnit { get; } = 1;
            xbyte INumericStatic<xbyte>.MaxValue => MaxValue;
            xbyte INumericStatic<xbyte>.MinUnit { get; } = 0;
            xbyte INumericStatic<xbyte>.MinValue => MinValue;
            xbyte INumericStatic<xbyte>.One { get; } = 1;
            xbyte INumericStatic<xbyte>.Ten { get; } = 10;
            xbyte INumericStatic<xbyte>.Two { get; } = 2;
            xbyte INumericStatic<xbyte>.Zero { get; } = 0;

            int IMath<xbyte>.Sign(xbyte x) => x._value == 0 ? 0 : 1;
            xbyte IMath<xbyte>.Abs(xbyte x) => x._value;
            xbyte IMath<xbyte>.Acos(xbyte x) => (byte)Math.Acos(x._value);
            xbyte IMath<xbyte>.Acosh(xbyte x) => (byte)Math.Acosh(x._value);
            xbyte IMath<xbyte>.Asin(xbyte x) => (byte)Math.Asin(x._value);
            xbyte IMath<xbyte>.Asinh(xbyte x) => (byte)Math.Asinh(x._value);
            xbyte IMath<xbyte>.Atan(xbyte x) => (byte)Math.Atan(x._value);
            xbyte IMath<xbyte>.Atan2(xbyte x, xbyte y) => (byte)Math.Atan2(x._value, y._value);
            xbyte IMath<xbyte>.Atanh(xbyte x) => (byte)Math.Atanh(x._value);
            xbyte IMath<xbyte>.Cbrt(xbyte x) => (byte)Math.Cbrt(x._value);
            xbyte IMath<xbyte>.Ceiling(xbyte x) => x;
            xbyte IMath<xbyte>.Clamp(xbyte x, xbyte bound1, xbyte bound2) => bound1 > bound2 ? Math.Min(bound1._value, Math.Max(bound2._value, x._value)) : Math.Min(bound2._value, Math.Max(bound1._value, x._value));
            xbyte IMath<xbyte>.Cos(xbyte x) => (byte)Math.Cos(x._value);
            xbyte IMath<xbyte>.Cosh(xbyte x) => (byte)Math.Cosh(x._value);
            xbyte IMath<xbyte>.DegreesToRadians(xbyte x) => (byte)(x * Trig.RadiansPerDegree);
            xbyte IMath<xbyte>.E { get; } = 2;
            xbyte IMath<xbyte>.Exp(xbyte x) => (byte)Math.Exp(x._value);
            xbyte IMath<xbyte>.Floor(xbyte x) => x;
            xbyte IMath<xbyte>.IEEERemainder(xbyte x, xbyte y) => (byte)Math.IEEERemainder(x._value, y._value);
            xbyte IMath<xbyte>.Log(xbyte x) => (byte)Math.Log(x._value);
            xbyte IMath<xbyte>.Log(xbyte x, xbyte y) => (byte)Math.Log(x._value, y._value);
            xbyte IMath<xbyte>.Log10(xbyte x) => (byte)Math.Log10(x._value);
            xbyte IMath<xbyte>.Max(xbyte x, xbyte y) => Math.Max(x._value, y._value);
            xbyte IMath<xbyte>.Min(xbyte x, xbyte y) => Math.Min(x._value, y._value);
            xbyte IMath<xbyte>.PI { get; } = 3;
            xbyte IMath<xbyte>.Pow(xbyte x, xbyte y) => (byte)Math.Pow(x._value, y._value);
            xbyte IMath<xbyte>.RadiansToDegrees(xbyte x) => (byte)(x * Trig.DegreesPerRadian);
            xbyte IMath<xbyte>.Round(xbyte x) => x;
            xbyte IMath<xbyte>.Round(xbyte x, int digits) => x;
            xbyte IMath<xbyte>.Round(xbyte x, int digits, MidpointRounding mode) => x;
            xbyte IMath<xbyte>.Round(xbyte x, MidpointRounding mode) => x;
            xbyte IMath<xbyte>.Sin(xbyte x) => (byte)Math.Sin(x._value);
            xbyte IMath<xbyte>.Sinh(xbyte x) => (byte)Math.Sinh(x._value);
            xbyte IMath<xbyte>.Sqrt(xbyte x) => (byte)Math.Sqrt(x._value);
            xbyte IMath<xbyte>.Tan(xbyte x) => (byte)Math.Tan(x._value);
            xbyte IMath<xbyte>.Tanh(xbyte x) => (byte)Math.Tanh(x._value);
            xbyte IMath<xbyte>.Tau { get; } = 6;
            xbyte IMath<xbyte>.Truncate(xbyte x) => x;

            xbyte IBitConverter<xbyte>.Read(IReadOnlyStream<byte> stream) => stream.Read(1)[0];
            void IBitConverter<xbyte>.Write(xbyte value, IWriteOnlyStream<byte> stream) => stream.Write(BitConverter.GetBytes(value._value));

            xbyte IRandom<xbyte>.Next(Random random) => random.NextByte();
            xbyte IRandom<xbyte>.Next(Random random, xbyte bound1, xbyte bound2) => random.NextByte(bound1._value, bound2._value);

            bool IConvert<xbyte>.ToBoolean(xbyte value) => Convert.ToBoolean(value._value);
            byte IConvert<xbyte>.ToByte(xbyte value) => Convert.ToByte(value._value);
            decimal IConvert<xbyte>.ToDecimal(xbyte value) => Convert.ToDecimal(value._value);
            double IConvert<xbyte>.ToDouble(xbyte value) => Convert.ToDouble(value._value);
            float IConvert<xbyte>.ToSingle(xbyte value) => Convert.ToSingle(value._value);
            int IConvert<xbyte>.ToInt32(xbyte value) => Convert.ToInt32(value._value);
            long IConvert<xbyte>.ToInt64(xbyte value) => Convert.ToInt64(value._value);
            sbyte IConvert<xbyte>.ToSByte(xbyte value) => Convert.ToSByte(value._value);
            short IConvert<xbyte>.ToInt16(xbyte value) => Convert.ToInt16(value._value);
            string IConvert<xbyte>.ToString(xbyte value) => Convert.ToString(value._value);
            string IConvert<xbyte>.ToString(xbyte value, IFormatProvider provider) => Convert.ToString(value._value, provider);
            uint IConvert<xbyte>.ToUInt32(xbyte value) => Convert.ToUInt32(value._value);
            ulong IConvert<xbyte>.ToUInt64(xbyte value) => Convert.ToUInt64(value._value);
            ushort IConvert<xbyte>.ToUInt16(xbyte value) => Convert.ToUInt16(value._value);

            xbyte IConvert<xbyte>.ToNumeric(bool value) => Convert.ToByte(value);
            xbyte IConvert<xbyte>.ToNumeric(byte value) => Convert.ToByte(value);
            xbyte IConvert<xbyte>.ToNumeric(decimal value) => Convert.ToByte(value);
            xbyte IConvert<xbyte>.ToNumeric(double value) => Convert.ToByte(value);
            xbyte IConvert<xbyte>.ToNumeric(float value) => Convert.ToByte(value);
            xbyte IConvert<xbyte>.ToNumeric(int value) => Convert.ToByte(value);
            xbyte IConvert<xbyte>.ToNumeric(long value) => Convert.ToByte(value);
            xbyte IConvert<xbyte>.ToNumeric(sbyte value) => Convert.ToByte(value);
            xbyte IConvert<xbyte>.ToNumeric(short value) => Convert.ToByte(value);
            xbyte IConvert<xbyte>.ToNumeric(string value) => Convert.ToByte(value);
            xbyte IConvert<xbyte>.ToNumeric(string value, IFormatProvider provider) => Convert.ToByte(value, provider);
            xbyte IConvert<xbyte>.ToNumeric(uint value) => Convert.ToByte(value);
            xbyte IConvert<xbyte>.ToNumeric(ulong value) => Convert.ToByte(value);
            xbyte IConvert<xbyte>.ToNumeric(ushort value) => Convert.ToByte(value);

            bool IStringParser<xbyte>.TryParse(string s, IFormatProvider provider, out xbyte result) => TryParse(s, provider, out result);
            bool IStringParser<xbyte>.TryParse(string s, NumberStyles style, IFormatProvider provider, out xbyte result) => TryParse(s, style, provider, out result);
            bool IStringParser<xbyte>.TryParse(string s, NumberStyles style, out xbyte result) => TryParse(s, style, out result);
            bool IStringParser<xbyte>.TryParse(string s, out xbyte result) => TryParse(s, out result);
            xbyte IStringParser<xbyte>.Parse(string s) => Parse(s);
            xbyte IStringParser<xbyte>.Parse(string s, IFormatProvider provider) => Parse(s, provider);
            xbyte IStringParser<xbyte>.Parse(string s, NumberStyles style) => Parse(s, style);
            xbyte IStringParser<xbyte>.Parse(string s, NumberStyles style, IFormatProvider provider) => Parse(s, style, provider);

            byte ICast<xbyte>.ToByte(xbyte value) => (byte)value;
            decimal ICast<xbyte>.ToDecimal(xbyte value) => (decimal)value;
            double ICast<xbyte>.ToDouble(xbyte value) => (double)value;
            float ICast<xbyte>.ToSingle(xbyte value) => (float)value;
            int ICast<xbyte>.ToInt32(xbyte value) => (int)value;
            long ICast<xbyte>.ToInt64(xbyte value) => (long)value;
            sbyte ICast<xbyte>.ToSByte(xbyte value) => (sbyte)value;
            short ICast<xbyte>.ToInt16(xbyte value) => (short)value;
            uint ICast<xbyte>.ToUInt32(xbyte value) => (uint)value;
            ulong ICast<xbyte>.ToUInt64(xbyte value) => (ulong)value;
            ushort ICast<xbyte>.ToUInt16(xbyte value) => (ushort)value;

            xbyte ICast<xbyte>.ToNumeric(byte value) => (xbyte)value;
            xbyte ICast<xbyte>.ToNumeric(decimal value) => (xbyte)value;
            xbyte ICast<xbyte>.ToNumeric(double value) => (xbyte)value;
            xbyte ICast<xbyte>.ToNumeric(float value) => (xbyte)value;
            xbyte ICast<xbyte>.ToNumeric(int value) => (xbyte)value;
            xbyte ICast<xbyte>.ToNumeric(long value) => (xbyte)value;
            xbyte ICast<xbyte>.ToNumeric(sbyte value) => (xbyte)value;
            xbyte ICast<xbyte>.ToNumeric(short value) => (xbyte)value;
            xbyte ICast<xbyte>.ToNumeric(uint value) => (xbyte)value;
            xbyte ICast<xbyte>.ToNumeric(ulong value) => (xbyte)value;
            xbyte ICast<xbyte>.ToNumeric(ushort value) => (xbyte)value;
        }
    }
}
