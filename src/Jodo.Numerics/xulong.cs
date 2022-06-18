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
using Jodo.Primitives;
using Jodo.Primitives.Compatibility;

namespace Jodo.Numerics
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
        public string ToString(string? format, IFormatProvider? formatProvider) => _value.ToString(format, formatProvider);

        public static bool TryParse(string s, IFormatProvider? provider, out xulong result) => Try.Run(() => Parse(s, provider), out result);
        public static bool TryParse(string s, NumberStyles style, IFormatProvider? provider, out xulong result) => Try.Run(() => Parse(s, style, provider), out result);
        public static bool TryParse(string s, NumberStyles style, out xulong result) => Try.Run(() => Parse(s, style), out result);
        public static bool TryParse(string s, out xulong result) => Try.Run(() => Parse(s), out result);
        public static xulong Parse(string s) => ulong.Parse(s);
        public static xulong Parse(string s, IFormatProvider? provider) => ulong.Parse(s, provider);
        public static xulong Parse(string s, NumberStyles style) => ulong.Parse(s, style);
        public static xulong Parse(string s, NumberStyles style, IFormatProvider? provider) => ulong.Parse(s, style, provider);

        [CLSCompliant(false)] public static explicit operator xulong(sbyte value) => new xulong((ulong)value);
        [CLSCompliant(false)] public static implicit operator xulong(uint value) => new xulong(value);
        [CLSCompliant(false)] public static implicit operator xulong(ulong value) => new xulong(value);
        [CLSCompliant(false)] public static implicit operator xulong(ushort value) => new xulong(value);
        public static explicit operator xulong(decimal value) => new xulong((ulong)value);
        public static explicit operator xulong(double value) => new xulong((ulong)value);
        public static explicit operator xulong(float value) => new xulong((ulong)value);
        public static explicit operator xulong(int value) => new xulong((ulong)value);
        public static explicit operator xulong(long value) => new xulong((ulong)value);
        public static explicit operator xulong(short value) => new xulong((ulong)value);
        public static implicit operator xulong(byte value) => new xulong(value);

        [CLSCompliant(false)] public static explicit operator sbyte(xulong value) => (sbyte)value._value;
        [CLSCompliant(false)] public static explicit operator uint(xulong value) => (uint)value._value;
        [CLSCompliant(false)] public static explicit operator ushort(xulong value) => (ushort)value._value;
        [CLSCompliant(false)] public static implicit operator ulong(xulong value) => value._value;
        public static explicit operator byte(xulong value) => (byte)value._value;
        public static explicit operator int(xulong value) => (int)value._value;
        public static explicit operator long(xulong value) => (long)value._value;
        public static explicit operator short(xulong value) => (short)value._value;
        public static implicit operator decimal(xulong value) => value._value;
        public static implicit operator double(xulong value) => value._value;
        public static implicit operator float(xulong value) => value._value;

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

        IBitConverter<xulong> IProvider<IBitConverter<xulong>>.GetInstance() => Utilities.Instance;
        ICast<xulong> IProvider<ICast<xulong>>.GetInstance() => Utilities.Instance;
        IConvert<xulong> IProvider<IConvert<xulong>>.GetInstance() => Utilities.Instance;
        IMath<xulong> IProvider<IMath<xulong>>.GetInstance() => Utilities.Instance;
        INumericStatic<xulong> IProvider<INumericStatic<xulong>>.GetInstance() => Utilities.Instance;
        IRandom<xulong> IProvider<IRandom<xulong>>.GetInstance() => Utilities.Instance;
        IStringParser<xulong> IProvider<IStringParser<xulong>>.GetInstance() => Utilities.Instance;

        private sealed class Utilities :
            IBitConverter<xulong>,
            ICast<xulong>,
            IConvert<xulong>,
            IMath<xulong>,
            INumericStatic<xulong>,
            IRandom<xulong>,
            IStringParser<xulong>
        {
            public static readonly Utilities Instance = new Utilities();

            bool INumericStatic<xulong>.HasFloatingPoint { get; } = false;
            bool INumericStatic<xulong>.HasInfinity { get; } = false;
            bool INumericStatic<xulong>.HasNaN { get; } = false;
            bool INumericStatic<xulong>.IsFinite(xulong x) => true;
            bool INumericStatic<xulong>.IsInfinity(xulong x) => false;
            bool INumericStatic<xulong>.IsNaN(xulong x) => false;
            bool INumericStatic<xulong>.IsNegative(xulong x) => false;
            bool INumericStatic<xulong>.IsNegativeInfinity(xulong x) => false;
            bool INumericStatic<xulong>.IsNormal(xulong x) => false;
            bool INumericStatic<xulong>.IsPositiveInfinity(xulong x) => false;
            bool INumericStatic<xulong>.IsReal { get; } = false;
            bool INumericStatic<xulong>.IsSigned { get; } = false;
            bool INumericStatic<xulong>.IsSubnormal(xulong x) => false;
            xulong INumericStatic<xulong>.Epsilon { get; } = (xulong)1;
            xulong INumericStatic<xulong>.MaxUnit { get; } = (xulong)1;
            xulong INumericStatic<xulong>.MaxValue => MaxValue;
            xulong INumericStatic<xulong>.MinUnit { get; } = (xulong)0;
            xulong INumericStatic<xulong>.MinValue => MinValue;
            xulong INumericStatic<xulong>.One { get; } = (xulong)1;
            xulong INumericStatic<xulong>.Ten { get; } = (xulong)10;
            xulong INumericStatic<xulong>.Two { get; } = (xulong)2;
            xulong INumericStatic<xulong>.Zero { get; } = (xulong)0;

            int IMath<xulong>.Sign(xulong x) => x._value == 0 ? 0 : 1;
            xulong IMath<xulong>.Abs(xulong value) => value;
            xulong IMath<xulong>.Acos(xulong x) => (xulong)Math.Acos(x);
            xulong IMath<xulong>.Acosh(xulong x) => (xulong)MathCompat.Acosh(x);
            xulong IMath<xulong>.Asin(xulong x) => (xulong)Math.Asin(x);
            xulong IMath<xulong>.Asinh(xulong x) => (xulong)MathCompat.Asinh(x);
            xulong IMath<xulong>.Atan(xulong x) => (xulong)Math.Atan(x);
            xulong IMath<xulong>.Atan2(xulong y, xulong x) => (xulong)Math.Atan2(y, x);
            xulong IMath<xulong>.Atanh(xulong x) => (xulong)MathCompat.Atanh(x);
            xulong IMath<xulong>.Cbrt(xulong x) => (xulong)MathCompat.Cbrt(x);
            xulong IMath<xulong>.Ceiling(xulong x) => x;
            xulong IMath<xulong>.Clamp(xulong x, xulong bound1, xulong bound2) => bound1 > bound2 ? Math.Min(bound1, Math.Max(bound2, x)) : Math.Min(bound2, Math.Max(bound1, x));
            xulong IMath<xulong>.Cos(xulong x) => (xulong)Math.Cos(x);
            xulong IMath<xulong>.Cosh(xulong x) => (xulong)Math.Cosh(x);
            xulong IMath<xulong>.DegreesToRadians(xulong x) => (xulong)(x * NumericUtilities.RadiansPerDegree);
            xulong IMath<xulong>.E { get; } = (xulong)2;
            xulong IMath<xulong>.Exp(xulong x) => (xulong)Math.Exp(x);
            xulong IMath<xulong>.Floor(xulong x) => x;
            xulong IMath<xulong>.IEEERemainder(xulong x, xulong y) => (xulong)Math.IEEERemainder(x, y);
            xulong IMath<xulong>.Log(xulong x) => (xulong)Math.Log(x);
            xulong IMath<xulong>.Log(xulong x, xulong y) => (xulong)Math.Log(x, y);
            xulong IMath<xulong>.Log10(xulong x) => (xulong)Math.Log10(x);
            xulong IMath<xulong>.Max(xulong x, xulong y) => Math.Max(x, y);
            xulong IMath<xulong>.Min(xulong x, xulong y) => Math.Min(x, y);
            xulong IMath<xulong>.PI { get; } = (xulong)3;
            xulong IMath<xulong>.Pow(xulong x, xulong y) => y == 1 ? x : (xulong)Math.Pow(x, y);
            xulong IMath<xulong>.RadiansToDegrees(xulong x) => (xulong)(x * NumericUtilities.DegreesPerRadian);
            xulong IMath<xulong>.Round(xulong x) => x;
            xulong IMath<xulong>.Round(xulong x, int digits) => x;
            xulong IMath<xulong>.Round(xulong x, int digits, MidpointRounding mode) => x;
            xulong IMath<xulong>.Round(xulong x, MidpointRounding mode) => x;
            xulong IMath<xulong>.Sin(xulong x) => (xulong)Math.Sin(x);
            xulong IMath<xulong>.Sinh(xulong x) => (xulong)Math.Sinh(x);
            xulong IMath<xulong>.Sqrt(xulong x) => (xulong)Math.Sqrt(x);
            xulong IMath<xulong>.Tan(xulong x) => (xulong)Math.Tan(x);
            xulong IMath<xulong>.Tanh(xulong x) => (xulong)Math.Tanh(x);
            xulong IMath<xulong>.Tau { get; } = (xulong)6;
            xulong IMath<xulong>.Truncate(xulong x) => x;

            xulong IBitConverter<xulong>.Read(IReadOnlyStream<byte> stream) => BitConverter.ToUInt64(stream.Read(sizeof(ulong)), 0);
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
            uint IConvert<xulong>.ToUInt32(xulong value) => Convert.ToUInt32(value._value);
            ulong IConvert<xulong>.ToUInt64(xulong value) => Convert.ToUInt64(value._value);
            ushort IConvert<xulong>.ToUInt16(xulong value) => Convert.ToUInt16(value._value);

            xulong IConvert<xulong>.ToNumeric(bool value) => Convert.ToUInt64(value);
            xulong IConvert<xulong>.ToNumeric(byte value) => Convert.ToUInt64(value);
            xulong IConvert<xulong>.ToNumeric(decimal value) => Convert.ToUInt64(value);
            xulong IConvert<xulong>.ToNumeric(double value) => Convert.ToUInt64(value);
            xulong IConvert<xulong>.ToNumeric(float value) => Convert.ToUInt64(value);
            xulong IConvert<xulong>.ToNumeric(int value) => Convert.ToUInt64(value);
            xulong IConvert<xulong>.ToNumeric(long value) => Convert.ToUInt64(value);
            xulong IConvert<xulong>.ToNumeric(sbyte value) => Convert.ToUInt64(value);
            xulong IConvert<xulong>.ToNumeric(short value) => Convert.ToUInt64(value);
            xulong IConvert<xulong>.ToNumeric(string value) => Convert.ToUInt64(value);
            xulong IConvert<xulong>.ToNumeric(uint value) => Convert.ToUInt64(value);
            xulong IConvert<xulong>.ToNumeric(ulong value) => Convert.ToUInt64(value);
            xulong IConvert<xulong>.ToNumeric(ushort value) => Convert.ToUInt64(value);

            xulong IStringParser<xulong>.Parse(string s) => Parse(s);
            xulong IStringParser<xulong>.Parse(string s, NumberStyles style, IFormatProvider? provider) => Parse(s, style, provider);

            byte ICast<xulong>.ToByte(xulong value) => (byte)value;
            decimal ICast<xulong>.ToDecimal(xulong value) => (decimal)value;
            double ICast<xulong>.ToDouble(xulong value) => (double)value;
            float ICast<xulong>.ToSingle(xulong value) => (float)value;
            int ICast<xulong>.ToInt32(xulong value) => (int)value;
            long ICast<xulong>.ToInt64(xulong value) => (long)value;
            sbyte ICast<xulong>.ToSByte(xulong value) => (sbyte)value;
            short ICast<xulong>.ToInt16(xulong value) => (short)value;
            uint ICast<xulong>.ToUInt32(xulong value) => (uint)value;
            ulong ICast<xulong>.ToUInt64(xulong value) => (ulong)value;
            ushort ICast<xulong>.ToUInt16(xulong value) => (ushort)value;

            xulong ICast<xulong>.ToNumeric(byte value) => (xulong)value;
            xulong ICast<xulong>.ToNumeric(decimal value) => (xulong)value;
            xulong ICast<xulong>.ToNumeric(double value) => (xulong)value;
            xulong ICast<xulong>.ToNumeric(float value) => (xulong)value;
            xulong ICast<xulong>.ToNumeric(int value) => (xulong)value;
            xulong ICast<xulong>.ToNumeric(long value) => (xulong)value;
            xulong ICast<xulong>.ToNumeric(sbyte value) => (xulong)value;
            xulong ICast<xulong>.ToNumeric(short value) => (xulong)value;
            xulong ICast<xulong>.ToNumeric(uint value) => (xulong)value;
            xulong ICast<xulong>.ToNumeric(ulong value) => (xulong)value;
            xulong ICast<xulong>.ToNumeric(ushort value) => (xulong)value;
        }
    }
}
