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

using Jodo.Extensions.Numerics;
using Jodo.Extensions.Primitives;
using System;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Runtime.Serialization;

namespace Jodo.Extensions.CheckedNumerics
{
    [Serializable]
    [DebuggerDisplay("{ToString(),nq}")]
    [SuppressMessage("Style", "IDE1006:Naming Styles")]
    [SuppressMessage("csharpsquid", "S101")]
    public readonly struct uclong : INumeric<uclong>
    {
        public static readonly uclong MaxValue = new uclong(ulong.MaxValue);
        public static readonly uclong MinValue = new uclong(ulong.MinValue);

        private readonly ulong _value;

        private uclong(ulong value)
        {
            _value = value;
        }

        private uclong(SerializationInfo info, StreamingContext context) : this(info.GetUInt64(nameof(uclong))) { }
        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context) => info.AddValue(nameof(uclong), _value);

        public int CompareTo(object? obj) => obj is uclong other ? CompareTo(other) : 1;
        public int CompareTo(uclong other) => _value.CompareTo(other._value);
        public bool Equals(uclong other) => _value == other._value;
        public override bool Equals(object? obj) => obj is uclong other && Equals(other);
        public override int GetHashCode() => _value.GetHashCode();
        public override string ToString() => _value.ToString();
        public string ToString(IFormatProvider formatProvider) => _value.ToString(formatProvider);
        public string ToString(string format) => _value.ToString(format);
        public string ToString(string format, IFormatProvider formatProvider) => _value.ToString(format, formatProvider);

        public static bool TryParse(string s, IFormatProvider provider, out uclong result) => Try.Run(() => Parse(s, provider), out result);
        public static bool TryParse(string s, NumberStyles style, IFormatProvider provider, out uclong result) => Try.Run(() => Parse(s, style, provider), out result);
        public static bool TryParse(string s, NumberStyles style, out uclong result) => Try.Run(() => Parse(s, style), out result);
        public static bool TryParse(string s, out uclong result) => Try.Run(() => Parse(s), out result);
        public static uclong Parse(string s) => ulong.Parse(s);
        public static uclong Parse(string s, IFormatProvider provider) => ulong.Parse(s, provider);
        public static uclong Parse(string s, NumberStyles style) => ulong.Parse(s, style);
        public static uclong Parse(string s, NumberStyles style, IFormatProvider provider) => ulong.Parse(s, style, provider);

        public static explicit operator uclong(decimal value) => new uclong(CheckedTruncate.ToUInt64(value));
        public static explicit operator uclong(double value) => new uclong(CheckedTruncate.ToUInt64(value));
        public static explicit operator uclong(float value) => new uclong(CheckedTruncate.ToUInt64(value));
        public static explicit operator uclong(int value) => new uclong(CheckedConvert.ToUInt64(value));
        public static explicit operator uclong(long value) => new uclong(CheckedConvert.ToUInt64(value));
        public static explicit operator uclong(sbyte value) => new uclong(CheckedConvert.ToUInt64(value));
        public static explicit operator uclong(short value) => new uclong(CheckedConvert.ToUInt64(value));
        public static implicit operator uclong(byte value) => new uclong(value);
        public static implicit operator uclong(uint value) => new uclong(value);
        public static implicit operator uclong(ulong value) => new uclong(value);
        public static implicit operator uclong(ushort value) => new uclong(value);

        public static explicit operator byte(uclong value) => CheckedConvert.ToByte(value._value);
        public static explicit operator int(uclong value) => CheckedConvert.ToInt32(value._value);
        public static explicit operator long(uclong value) => CheckedConvert.ToInt64(value._value);
        public static explicit operator sbyte(uclong value) => CheckedConvert.ToSByte(value._value);
        public static explicit operator short(uclong value) => CheckedConvert.ToInt16(value._value);
        public static explicit operator uint(uclong value) => CheckedConvert.ToUInt32(value._value);
        public static explicit operator ushort(uclong value) => CheckedConvert.ToUInt16(value._value);
        public static implicit operator decimal(uclong value) => value._value;
        public static implicit operator double(uclong value) => value._value;
        public static implicit operator float(uclong value) => value._value;
        public static implicit operator ulong(uclong value) => value._value;

        public static bool operator !=(uclong left, uclong right) => left._value != right._value;
        public static bool operator <(uclong left, uclong right) => left._value < right._value;
        public static bool operator <=(uclong left, uclong right) => left._value <= right._value;
        public static bool operator ==(uclong left, uclong right) => left._value == right._value;
        public static bool operator >(uclong left, uclong right) => left._value > right._value;
        public static bool operator >=(uclong left, uclong right) => left._value >= right._value;
        public static uclong operator %(uclong left, uclong right) => CheckedArithmetic.Remainder(left._value, right._value);
        public static uclong operator &(uclong left, uclong right) => left._value & right._value;
        public static uclong operator -(uclong _) => MinValue;
        public static uclong operator -(uclong left, uclong right) => CheckedArithmetic.Subtract(left._value, right._value);
        public static uclong operator --(uclong value) => value - 1;
        public static uclong operator *(uclong left, uclong right) => CheckedArithmetic.Multiply(left._value, right._value);
        public static uclong operator /(uclong left, uclong right) => CheckedArithmetic.Divide(left._value, right._value);
        public static uclong operator ^(uclong left, uclong right) => left._value ^ right._value;
        public static uclong operator |(uclong left, uclong right) => left._value | right._value;
        public static uclong operator ~(uclong value) => ~value._value;
        public static uclong operator +(uclong left, uclong right) => CheckedArithmetic.Add(left._value, right._value);
        public static uclong operator +(uclong value) => value;
        public static uclong operator ++(uclong value) => value + 1;
        public static uclong operator <<(uclong left, int right) => left._value << right;
        public static uclong operator >>(uclong left, int right) => left._value >> right;

        bool INumeric<uclong>.IsGreaterThan(uclong value) => this > value;
        bool INumeric<uclong>.IsGreaterThanOrEqualTo(uclong value) => this >= value;
        bool INumeric<uclong>.IsLessThan(uclong value) => this < value;
        bool INumeric<uclong>.IsLessThanOrEqualTo(uclong value) => this <= value;
        uclong INumeric<uclong>.Add(uclong value) => this + value;
        uclong INumeric<uclong>.BitwiseComplement() => ~this;
        uclong INumeric<uclong>.Divide(uclong value) => this / value;
        uclong INumeric<uclong>.LeftShift(int count) => this << count;
        uclong INumeric<uclong>.LogicalAnd(uclong value) => this & value;
        uclong INumeric<uclong>.LogicalExclusiveOr(uclong value) => this ^ value;
        uclong INumeric<uclong>.LogicalOr(uclong value) => this | value;
        uclong INumeric<uclong>.Multiply(uclong value) => this * value;
        uclong INumeric<uclong>.Negative() => -this;
        uclong INumeric<uclong>.Positive() => +this;
        uclong INumeric<uclong>.Remainder(uclong value) => this % value;
        uclong INumeric<uclong>.RightShift(int count) => this >> count;
        uclong INumeric<uclong>.Subtract(uclong value) => this - value;

        IBitConverter<uclong> IBitConvertible<uclong>.BitConverter => Utilities.Instance;
        ICast<uclong> INumeric<uclong>.Cast => Utilities.Instance;
        IConvert<uclong> IConvertible<uclong>.Convert => Utilities.Instance;
        IMath<uclong> INumeric<uclong>.Math => Utilities.Instance;
        INumericFunctions<uclong> INumeric<uclong>.NumericFunctions => Utilities.Instance;
        IRandom<uclong> IRandomisable<uclong>.Random => Utilities.Instance;
        IStringParser<uclong> IStringParsable<uclong>.StringParser => Utilities.Instance;

        private sealed class Utilities :
            IBitConverter<uclong>,
            ICast<uclong>,
            IConvert<uclong>,
            IMath<uclong>,
            INumericFunctions<uclong>,
            IRandom<uclong>,
            IStringParser<uclong>
        {
            public readonly static Utilities Instance = new Utilities();

            bool INumericFunctions<uclong>.HasFloatingPoint { get; } = false;
            bool INumericFunctions<uclong>.IsFinite(uclong x) => true;
            bool INumericFunctions<uclong>.IsInfinity(uclong x) => false;
            bool INumericFunctions<uclong>.IsNaN(uclong x) => false;
            bool INumericFunctions<uclong>.IsNegative(uclong x) => false;
            bool INumericFunctions<uclong>.IsNegativeInfinity(uclong x) => false;
            bool INumericFunctions<uclong>.IsNormal(uclong x) => false;
            bool INumericFunctions<uclong>.IsPositiveInfinity(uclong x) => false;
            bool INumericFunctions<uclong>.IsReal { get; } = false;
            bool INumericFunctions<uclong>.IsSigned { get; } = false;
            bool INumericFunctions<uclong>.IsSubnormal(uclong x) => false;
            uclong INumericFunctions<uclong>.Epsilon { get; } = 1;
            uclong INumericFunctions<uclong>.MaxUnit { get; } = 1;
            uclong INumericFunctions<uclong>.MaxValue => MaxValue;
            uclong INumericFunctions<uclong>.MinUnit { get; } = 0;
            uclong INumericFunctions<uclong>.MinValue => MinValue;
            uclong INumericFunctions<uclong>.One { get; } = 1;
            uclong INumericFunctions<uclong>.Ten { get; } = 10;
            uclong INumericFunctions<uclong>.Two { get; } = 2;
            uclong INumericFunctions<uclong>.Zero { get; } = 0;

            int IMath<uclong>.Sign(uclong x) => x._value == 0 ? 0 : 1;
            uclong IMath<uclong>.Abs(uclong x) => x;
            uclong IMath<uclong>.Acos(uclong x) => (uclong)Math.Acos(x._value);
            uclong IMath<uclong>.Acosh(uclong x) => (uclong)Math.Acosh(x._value);
            uclong IMath<uclong>.Asin(uclong x) => (uclong)Math.Asin(x._value);
            uclong IMath<uclong>.Asinh(uclong x) => (uclong)Math.Asinh(x._value);
            uclong IMath<uclong>.Atan(uclong x) => (uclong)Math.Atan(x._value);
            uclong IMath<uclong>.Atan2(uclong x, uclong y) => (uclong)Math.Atan2(x._value, y._value);
            uclong IMath<uclong>.Atanh(uclong x) => (uclong)Math.Atanh(x._value);
            uclong IMath<uclong>.Cbrt(uclong x) => (uclong)Math.Cbrt(x._value);
            uclong IMath<uclong>.Ceiling(uclong x) => x;
            uclong IMath<uclong>.Clamp(uclong x, uclong bound1, uclong bound2) => bound1 > bound2 ? Math.Min(bound1._value, Math.Max(bound2._value, x._value)) : Math.Min(bound2._value, Math.Max(bound1._value, x._value));
            uclong IMath<uclong>.Cos(uclong x) => (uclong)Math.Cos(x._value);
            uclong IMath<uclong>.Cosh(uclong x) => (uclong)Math.Cosh(x._value);
            uclong IMath<uclong>.DegreesToRadians(uclong x) => (uclong)CheckedArithmetic.Multiply(x, Trig.RadiansPerDegree);
            uclong IMath<uclong>.E { get; } = 2;
            uclong IMath<uclong>.Exp(uclong x) => (uclong)Math.Exp(x._value);
            uclong IMath<uclong>.Floor(uclong x) => x;
            uclong IMath<uclong>.IEEERemainder(uclong x, uclong y) => (uclong)Math.IEEERemainder(x._value, y._value);
            uclong IMath<uclong>.Log(uclong x) => (uclong)Math.Log(x._value);
            uclong IMath<uclong>.Log(uclong x, uclong y) => (uclong)Math.Log(x._value, y._value);
            uclong IMath<uclong>.Log10(uclong x) => (uclong)Math.Log10(x._value);
            uclong IMath<uclong>.Max(uclong x, uclong y) => Math.Max(x._value, y._value);
            uclong IMath<uclong>.Min(uclong x, uclong y) => Math.Min(x._value, y._value);
            uclong IMath<uclong>.PI { get; } = 3;
            uclong IMath<uclong>.Pow(uclong x, uclong y) => CheckedArithmetic.Pow(x._value, y._value);
            uclong IMath<uclong>.RadiansToDegrees(uclong x) => (uclong)CheckedArithmetic.Multiply(x, Trig.DegreesPerRadian);
            uclong IMath<uclong>.Round(uclong x) => x;
            uclong IMath<uclong>.Round(uclong x, int digits) => x;
            uclong IMath<uclong>.Round(uclong x, int digits, MidpointRounding mode) => x;
            uclong IMath<uclong>.Round(uclong x, MidpointRounding mode) => x;
            uclong IMath<uclong>.RoundToSignificance(uclong x, int significantDigits, MidpointRounding mode) => Digits.RoundToSignificance(x, significantDigits, mode);
            uclong IMath<uclong>.Sin(uclong x) => (uclong)Math.Sin(x._value);
            uclong IMath<uclong>.Sinh(uclong x) => (uclong)Math.Sinh(x._value);
            uclong IMath<uclong>.Sqrt(uclong x) => (uclong)Math.Sqrt(x._value);
            uclong IMath<uclong>.Tan(uclong x) => (uclong)Math.Tan(x._value);
            uclong IMath<uclong>.Tanh(uclong x) => (uclong)Math.Tanh(x._value);
            uclong IMath<uclong>.Tau { get; } = 6;
            uclong IMath<uclong>.Truncate(uclong x) => x;
            uclong IMath<uclong>.TruncateToSignificance(uclong x, int significantDigits) => Digits.Truncate(x, significantDigits);

            uclong IBitConverter<uclong>.Read(IReadOnlyStream<byte> stream) => BitConverter.ToUInt64(stream.Read(sizeof(ulong)));
            void IBitConverter<uclong>.Write(uclong value, IWriteOnlyStream<byte> stream) => stream.Write(BitConverter.GetBytes(value._value));

            uclong IRandom<uclong>.Next(Random random) => random.NextUInt64();
            uclong IRandom<uclong>.Next(Random random, uclong bound1, uclong bound2) => random.NextUInt64(bound1._value, bound2._value);

            bool IConvert<uclong>.ToBoolean(uclong value) => CheckedConvert.ToBoolean(value._value);
            byte IConvert<uclong>.ToByte(uclong value) => CheckedConvert.ToByte(value._value);
            decimal IConvert<uclong>.ToDecimal(uclong value) => CheckedConvert.ToDecimal(value._value);
            double IConvert<uclong>.ToDouble(uclong value) => CheckedConvert.ToDouble(value._value);
            float IConvert<uclong>.ToSingle(uclong value) => CheckedConvert.ToSingle(value._value);
            int IConvert<uclong>.ToInt32(uclong value) => CheckedConvert.ToInt32(value._value);
            long IConvert<uclong>.ToInt64(uclong value) => CheckedConvert.ToInt64(value._value);
            sbyte IConvert<uclong>.ToSByte(uclong value) => CheckedConvert.ToSByte(value._value);
            short IConvert<uclong>.ToInt16(uclong value) => CheckedConvert.ToInt16(value._value);
            string IConvert<uclong>.ToString(uclong value) => Convert.ToString(value._value);
            string IConvert<uclong>.ToString(uclong value, IFormatProvider provider) => Convert.ToString(value._value, provider);
            uint IConvert<uclong>.ToUInt32(uclong value) => CheckedConvert.ToUInt32(value._value);
            ulong IConvert<uclong>.ToUInt64(uclong value) => value._value;
            ushort IConvert<uclong>.ToUInt16(uclong value) => CheckedConvert.ToUInt16(value._value);

            uclong IConvert<uclong>.ToValue(bool value) => CheckedConvert.ToUInt64(value);
            uclong IConvert<uclong>.ToValue(byte value) => CheckedConvert.ToUInt64(value);
            uclong IConvert<uclong>.ToValue(decimal value) => CheckedConvert.ToUInt64(value);
            uclong IConvert<uclong>.ToValue(double value) => CheckedConvert.ToUInt64(value);
            uclong IConvert<uclong>.ToValue(float value) => CheckedConvert.ToUInt64(value);
            uclong IConvert<uclong>.ToValue(int value) => CheckedConvert.ToUInt64(value);
            uclong IConvert<uclong>.ToValue(long value) => CheckedConvert.ToUInt64(value);
            uclong IConvert<uclong>.ToValue(sbyte value) => CheckedConvert.ToUInt64(value);
            uclong IConvert<uclong>.ToValue(short value) => CheckedConvert.ToUInt64(value);
            uclong IConvert<uclong>.ToValue(string value) => Convert.ToUInt64(value);
            uclong IConvert<uclong>.ToValue(string value, IFormatProvider provider) => Convert.ToUInt16(value, provider);
            uclong IConvert<uclong>.ToValue(uint value) => CheckedConvert.ToUInt64(value);
            uclong IConvert<uclong>.ToValue(ulong value) => value;
            uclong IConvert<uclong>.ToValue(ushort value) => CheckedConvert.ToUInt64(value);

            bool IStringParser<uclong>.TryParse(string s, IFormatProvider provider, out uclong result) => TryParse(s, provider, out result);
            bool IStringParser<uclong>.TryParse(string s, NumberStyles style, IFormatProvider provider, out uclong result) => TryParse(s, style, provider, out result);
            bool IStringParser<uclong>.TryParse(string s, NumberStyles style, out uclong result) => TryParse(s, style, out result);
            bool IStringParser<uclong>.TryParse(string s, out uclong result) => TryParse(s, out result);
            uclong IStringParser<uclong>.Parse(string s) => Parse(s);
            uclong IStringParser<uclong>.Parse(string s, IFormatProvider provider) => Parse(s, provider);
            uclong IStringParser<uclong>.Parse(string s, NumberStyles style) => Parse(s, style);
            uclong IStringParser<uclong>.Parse(string s, NumberStyles style, IFormatProvider provider) => Parse(s, style, provider);

            byte ICast<uclong>.ToByte(uclong value) => (byte)value;
            decimal ICast<uclong>.ToDecimal(uclong value) => (decimal)value;
            double ICast<uclong>.ToDouble(uclong value) => (double)value;
            float ICast<uclong>.ToSingle(uclong value) => (float)value;
            int ICast<uclong>.ToInt32(uclong value) => (int)value;
            long ICast<uclong>.ToInt64(uclong value) => (long)value;
            sbyte ICast<uclong>.ToSByte(uclong value) => (sbyte)value;
            short ICast<uclong>.ToInt16(uclong value) => (short)value;
            uint ICast<uclong>.ToUInt32(uclong value) => (uint)value;
            ulong ICast<uclong>.ToUInt64(uclong value) => (ulong)value;
            ushort ICast<uclong>.ToUInt16(uclong value) => (ushort)value;

            uclong ICast<uclong>.ToValue(byte value) => (uclong)value;
            uclong ICast<uclong>.ToValue(decimal value) => (uclong)value;
            uclong ICast<uclong>.ToValue(double value) => (uclong)value;
            uclong ICast<uclong>.ToValue(float value) => (uclong)value;
            uclong ICast<uclong>.ToValue(int value) => (uclong)value;
            uclong ICast<uclong>.ToValue(long value) => (uclong)value;
            uclong ICast<uclong>.ToValue(sbyte value) => (uclong)value;
            uclong ICast<uclong>.ToValue(short value) => (uclong)value;
            uclong ICast<uclong>.ToValue(uint value) => (uclong)value;
            uclong ICast<uclong>.ToValue(ulong value) => (uclong)value;
            uclong ICast<uclong>.ToValue(ushort value) => (uclong)value;
        }
    }
}
