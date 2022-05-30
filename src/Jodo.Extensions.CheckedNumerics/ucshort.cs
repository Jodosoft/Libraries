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
    public readonly struct ucshort : INumeric<ucshort>
    {
        public static readonly ucshort MaxValue = new ucshort(ushort.MaxValue);
        public static readonly ucshort MinValue = new ucshort(ushort.MinValue);

        private readonly ushort _value;

        private ucshort(ushort value)
        {
            _value = value;
        }

        private ucshort(SerializationInfo info, StreamingContext context) : this(info.GetUInt16(nameof(ucshort))) { }
        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context) => info.AddValue(nameof(ucshort), _value);

        public int CompareTo(object? obj) => obj is ucshort other ? CompareTo(other) : 1;
        public int CompareTo(ucshort other) => _value.CompareTo(other._value);
        public bool Equals(ucshort other) => _value == other._value;
        public override bool Equals(object? obj) => obj is ucshort other && Equals(other);
        public override int GetHashCode() => _value.GetHashCode();
        public override string ToString() => _value.ToString();
        public string ToString(IFormatProvider formatProvider) => _value.ToString(formatProvider);
        public string ToString(string format) => _value.ToString(format);
        public string ToString(string format, IFormatProvider formatProvider) => _value.ToString(format, formatProvider);

        public static bool TryParse(string s, IFormatProvider provider, out ucshort result) => Try.Run(() => Parse(s, provider), out result);
        public static bool TryParse(string s, NumberStyles style, IFormatProvider provider, out ucshort result) => Try.Run(() => Parse(s, style, provider), out result);
        public static bool TryParse(string s, NumberStyles style, out ucshort result) => Try.Run(() => Parse(s, style), out result);
        public static bool TryParse(string s, out ucshort result) => Try.Run(() => Parse(s), out result);
        public static ucshort Parse(string s) => ushort.Parse(s);
        public static ucshort Parse(string s, IFormatProvider provider) => ushort.Parse(s, provider);
        public static ucshort Parse(string s, NumberStyles style) => ushort.Parse(s, style);
        public static ucshort Parse(string s, NumberStyles style, IFormatProvider provider) => ushort.Parse(s, style, provider);

        public static explicit operator ucshort(decimal value) => new ucshort(CheckedTruncate.ToUInt16(value));
        public static explicit operator ucshort(double value) => new ucshort(CheckedTruncate.ToUInt16(value));
        public static explicit operator ucshort(float value) => new ucshort(CheckedTruncate.ToUInt16(value));
        public static explicit operator ucshort(int value) => new ucshort(CheckedConvert.ToUInt16(value));
        public static explicit operator ucshort(long value) => new ucshort(CheckedConvert.ToUInt16(value));
        public static explicit operator ucshort(sbyte value) => new ucshort(CheckedConvert.ToUInt16(value));
        public static explicit operator ucshort(short value) => new ucshort(CheckedConvert.ToUInt16(value));
        public static explicit operator ucshort(uint value) => new ucshort(CheckedConvert.ToUInt16(value));
        public static explicit operator ucshort(ulong value) => new ucshort(CheckedConvert.ToUInt16(value));
        public static implicit operator ucshort(byte value) => new ucshort(value);
        public static implicit operator ucshort(ushort value) => new ucshort(value);

        public static explicit operator byte(ucshort value) => CheckedConvert.ToByte(value._value);
        public static explicit operator int(ucshort value) => CheckedConvert.ToInt32(value._value);
        public static explicit operator sbyte(ucshort value) => CheckedConvert.ToSByte(value._value);
        public static explicit operator short(ucshort value) => CheckedConvert.ToInt16(value._value);
        public static implicit operator ushort(ucshort value) => value._value;
        public static implicit operator decimal(ucshort value) => value._value;
        public static implicit operator double(ucshort value) => value._value;
        public static implicit operator float(ucshort value) => value._value;
        public static implicit operator long(ucshort value) => value._value;
        public static implicit operator uint(ucshort value) => value._value;
        public static implicit operator ulong(ucshort value) => value._value;

        public static bool operator !=(ucshort left, ucshort right) => left._value != right._value;
        public static bool operator <(ucshort left, ucshort right) => left._value < right._value;
        public static bool operator <=(ucshort left, ucshort right) => left._value <= right._value;
        public static bool operator ==(ucshort left, ucshort right) => left._value == right._value;
        public static bool operator >(ucshort left, ucshort right) => left._value > right._value;
        public static bool operator >=(ucshort left, ucshort right) => left._value >= right._value;
        public static ucshort operator %(ucshort left, ucshort right) => CheckedArithmetic.Remainder(left._value, right._value);
        public static ucshort operator &(ucshort left, ucshort right) => (ushort)(left._value & right._value);
        public static ucshort operator -(ucshort _) => MinValue;
        public static ucshort operator -(ucshort left, ucshort right) => CheckedArithmetic.Subtract(left._value, right._value);
        public static ucshort operator --(ucshort value) => value - 1;
        public static ucshort operator *(ucshort left, ucshort right) => CheckedArithmetic.Multiply(left._value, right._value);
        public static ucshort operator /(ucshort left, ucshort right) => CheckedArithmetic.Divide(left._value, right._value);
        public static ucshort operator ^(ucshort left, ucshort right) => (ushort)(left._value ^ right._value);
        public static ucshort operator |(ucshort left, ucshort right) => (ushort)(left._value | right._value);
        public static ucshort operator ~(ucshort value) => (ushort)~value._value;
        public static ucshort operator +(ucshort left, ucshort right) => CheckedArithmetic.Add(left._value, right._value);
        public static ucshort operator +(ucshort value) => value;
        public static ucshort operator ++(ucshort value) => value + 1;
        public static ucshort operator <<(ucshort left, int right) => (ushort)(left._value << right);
        public static ucshort operator >>(ucshort left, int right) => (ushort)(left._value >> right);

        bool INumeric<ucshort>.IsGreaterThan(ucshort value) => this > value;
        bool INumeric<ucshort>.IsGreaterThanOrEqualTo(ucshort value) => this >= value;
        bool INumeric<ucshort>.IsLessThan(ucshort value) => this < value;
        bool INumeric<ucshort>.IsLessThanOrEqualTo(ucshort value) => this <= value;
        ucshort INumeric<ucshort>.Add(ucshort value) => this + value;
        ucshort INumeric<ucshort>.BitwiseComplement() => ~this;
        ucshort INumeric<ucshort>.Divide(ucshort value) => this / value;
        ucshort INumeric<ucshort>.LeftShift(int count) => this << count;
        ucshort INumeric<ucshort>.LogicalAnd(ucshort value) => this & value;
        ucshort INumeric<ucshort>.LogicalExclusiveOr(ucshort value) => this ^ value;
        ucshort INumeric<ucshort>.LogicalOr(ucshort value) => this | value;
        ucshort INumeric<ucshort>.Multiply(ucshort value) => this * value;
        ucshort INumeric<ucshort>.Negative() => -this;
        ucshort INumeric<ucshort>.Positive() => +this;
        ucshort INumeric<ucshort>.Remainder(ucshort value) => this % value;
        ucshort INumeric<ucshort>.RightShift(int count) => this >> count;
        ucshort INumeric<ucshort>.Subtract(ucshort value) => this - value;

        IBitConverter<ucshort> IBitConvertible<ucshort>.BitConverter => Utilities.Instance;
        ICast<ucshort> INumeric<ucshort>.Cast => Utilities.Instance;
        IConvert<ucshort> IConvertible<ucshort>.Convert => Utilities.Instance;
        IMath<ucshort> INumeric<ucshort>.Math => Utilities.Instance;
        INumericFunctions<ucshort> INumeric<ucshort>.NumericFunctions => Utilities.Instance;
        IRandom<ucshort> IRandomisable<ucshort>.Random => Utilities.Instance;
        IStringParser<ucshort> IStringParsable<ucshort>.StringParser => Utilities.Instance;

        private sealed class Utilities :
            IBitConverter<ucshort>,
            ICast<ucshort>,
            IConvert<ucshort>,
            IMath<ucshort>,
            INumericFunctions<ucshort>,
            IRandom<ucshort>,
            IStringParser<ucshort>
        {
            public readonly static Utilities Instance = new Utilities();

            bool INumericFunctions<ucshort>.HasFloatingPoint { get; } = false;
            bool INumericFunctions<ucshort>.IsFinite(ucshort x) => true;
            bool INumericFunctions<ucshort>.IsInfinity(ucshort x) => false;
            bool INumericFunctions<ucshort>.IsNaN(ucshort x) => false;
            bool INumericFunctions<ucshort>.IsNegative(ucshort x) => false;
            bool INumericFunctions<ucshort>.IsNegativeInfinity(ucshort x) => false;
            bool INumericFunctions<ucshort>.IsNormal(ucshort x) => false;
            bool INumericFunctions<ucshort>.IsPositiveInfinity(ucshort x) => false;
            bool INumericFunctions<ucshort>.IsReal { get; } = false;
            bool INumericFunctions<ucshort>.IsSigned { get; } = false;
            bool INumericFunctions<ucshort>.IsSubnormal(ucshort x) => false;
            ucshort INumericFunctions<ucshort>.Epsilon { get; } = 1;
            ucshort INumericFunctions<ucshort>.MaxUnit { get; } = 1;
            ucshort INumericFunctions<ucshort>.MaxValue => MaxValue;
            ucshort INumericFunctions<ucshort>.MinUnit { get; } = 0;
            ucshort INumericFunctions<ucshort>.MinValue => MinValue;
            ucshort INumericFunctions<ucshort>.One { get; } = 1;
            ucshort INumericFunctions<ucshort>.Ten { get; } = 10;
            ucshort INumericFunctions<ucshort>.Two { get; } = 2;
            ucshort INumericFunctions<ucshort>.Zero { get; } = 0;

            int IMath<ucshort>.Sign(ucshort x) => x._value == 0 ? 0 : 1;
            ucshort IMath<ucshort>.Abs(ucshort x) => x;
            ucshort IMath<ucshort>.Acos(ucshort x) => (ucshort)Math.Acos(x._value);
            ucshort IMath<ucshort>.Acosh(ucshort x) => (ucshort)Math.Acosh(x._value);
            ucshort IMath<ucshort>.Asin(ucshort x) => (ucshort)Math.Asin(x._value);
            ucshort IMath<ucshort>.Asinh(ucshort x) => (ucshort)Math.Asinh(x._value);
            ucshort IMath<ucshort>.Atan(ucshort x) => (ucshort)Math.Atan(x._value);
            ucshort IMath<ucshort>.Atan2(ucshort x, ucshort y) => (ucshort)Math.Atan2(x._value, y._value);
            ucshort IMath<ucshort>.Atanh(ucshort x) => (ucshort)Math.Atanh(x._value);
            ucshort IMath<ucshort>.Cbrt(ucshort x) => (ucshort)Math.Cbrt(x._value);
            ucshort IMath<ucshort>.Ceiling(ucshort x) => x;
            ucshort IMath<ucshort>.Clamp(ucshort x, ucshort bound1, ucshort bound2) => bound1 > bound2 ? Math.Min(bound1._value, Math.Max(bound2._value, x._value)) : Math.Min(bound2._value, Math.Max(bound1._value, x._value));
            ucshort IMath<ucshort>.Cos(ucshort x) => (ucshort)Math.Cos(x._value);
            ucshort IMath<ucshort>.Cosh(ucshort x) => (ucshort)Math.Cosh(x._value);
            ucshort IMath<ucshort>.DegreesToRadians(ucshort x) => (ucshort)CheckedArithmetic.Multiply(x, Trig.RadiansPerDegree);
            ucshort IMath<ucshort>.E { get; } = 2;
            ucshort IMath<ucshort>.Exp(ucshort x) => (ucshort)Math.Exp(x._value);
            ucshort IMath<ucshort>.Floor(ucshort x) => x;
            ucshort IMath<ucshort>.IEEERemainder(ucshort x, ucshort y) => (ucshort)Math.IEEERemainder(x._value, y._value);
            ucshort IMath<ucshort>.Log(ucshort x) => (ucshort)Math.Log(x._value);
            ucshort IMath<ucshort>.Log(ucshort x, ucshort y) => (ucshort)Math.Log(x._value, y._value);
            ucshort IMath<ucshort>.Log10(ucshort x) => (ucshort)Math.Log10(x._value);
            ucshort IMath<ucshort>.Max(ucshort x, ucshort y) => Math.Max(x._value, y._value);
            ucshort IMath<ucshort>.Min(ucshort x, ucshort y) => Math.Min(x._value, y._value);
            ucshort IMath<ucshort>.PI { get; } = 3;
            ucshort IMath<ucshort>.Pow(ucshort x, ucshort y) => CheckedArithmetic.Pow(x._value, y._value);
            ucshort IMath<ucshort>.RadiansToDegrees(ucshort x) => (ucshort)CheckedArithmetic.Multiply(x, Trig.DegreesPerRadian);
            ucshort IMath<ucshort>.Round(ucshort x) => x;
            ucshort IMath<ucshort>.Round(ucshort x, int digits) => x;
            ucshort IMath<ucshort>.Round(ucshort x, int digits, MidpointRounding mode) => x;
            ucshort IMath<ucshort>.Round(ucshort x, MidpointRounding mode) => x;
            ucshort IMath<ucshort>.RoundToSignificance(ucshort x, int significantDigits, MidpointRounding mode) => Digits.RoundToSignificance(x, significantDigits, mode);
            ucshort IMath<ucshort>.Sin(ucshort x) => (ucshort)Math.Sin(x._value);
            ucshort IMath<ucshort>.Sinh(ucshort x) => (ucshort)Math.Sinh(x._value);
            ucshort IMath<ucshort>.Sqrt(ucshort x) => (ucshort)Math.Sqrt(x._value);
            ucshort IMath<ucshort>.Tan(ucshort x) => (ucshort)Math.Tan(x._value);
            ucshort IMath<ucshort>.Tanh(ucshort x) => (ucshort)Math.Tanh(x._value);
            ucshort IMath<ucshort>.Tau { get; } = 6;
            ucshort IMath<ucshort>.Truncate(ucshort x) => x;
            ucshort IMath<ucshort>.TruncateToSignificance(ucshort x, int significantDigits) => Digits.Truncate(x, significantDigits);

            ucshort IBitConverter<ucshort>.Read(IReadOnlyStream<byte> stream) => BitConverter.ToUInt16(stream.Read(sizeof(ushort)));
            void IBitConverter<ucshort>.Write(ucshort value, IWriteOnlyStream<byte> stream) => stream.Write(BitConverter.GetBytes(value._value));

            ucshort IRandom<ucshort>.Next(Random random) => random.NextUInt16();
            ucshort IRandom<ucshort>.Next(Random random, ucshort bound1, ucshort bound2) => random.NextUInt16(bound1._value, bound2._value);

            bool IConvert<ucshort>.ToBoolean(ucshort value) => CheckedConvert.ToBoolean(value._value);
            byte IConvert<ucshort>.ToByte(ucshort value) => CheckedConvert.ToByte(value._value);
            decimal IConvert<ucshort>.ToDecimal(ucshort value) => CheckedConvert.ToDecimal(value._value);
            double IConvert<ucshort>.ToDouble(ucshort value) => CheckedConvert.ToDouble(value._value);
            float IConvert<ucshort>.ToSingle(ucshort value) => CheckedConvert.ToSingle(value._value);
            int IConvert<ucshort>.ToInt32(ucshort value) => CheckedConvert.ToInt32(value._value);
            long IConvert<ucshort>.ToInt64(ucshort value) => CheckedConvert.ToInt64(value._value);
            sbyte IConvert<ucshort>.ToSByte(ucshort value) => CheckedConvert.ToSByte(value._value);
            short IConvert<ucshort>.ToInt16(ucshort value) => CheckedConvert.ToInt16(value._value);
            string IConvert<ucshort>.ToString(ucshort value) => Convert.ToString(value._value);
            string IConvert<ucshort>.ToString(ucshort value, IFormatProvider provider) => Convert.ToString(value._value, provider);
            uint IConvert<ucshort>.ToUInt32(ucshort value) => value._value;
            ulong IConvert<ucshort>.ToUInt64(ucshort value) => CheckedConvert.ToUInt64(value._value);
            ushort IConvert<ucshort>.ToUInt16(ucshort value) => CheckedConvert.ToUInt16(value._value);

            ucshort IConvert<ucshort>.ToValue(bool value) => CheckedConvert.ToUInt16(value);
            ucshort IConvert<ucshort>.ToValue(byte value) => CheckedConvert.ToUInt16(value);
            ucshort IConvert<ucshort>.ToValue(decimal value) => CheckedConvert.ToUInt16(value);
            ucshort IConvert<ucshort>.ToValue(double value) => CheckedConvert.ToUInt16(value);
            ucshort IConvert<ucshort>.ToValue(float value) => CheckedConvert.ToUInt16(value);
            ucshort IConvert<ucshort>.ToValue(int value) => CheckedConvert.ToUInt16(value);
            ucshort IConvert<ucshort>.ToValue(long value) => CheckedConvert.ToUInt16(value);
            ucshort IConvert<ucshort>.ToValue(sbyte value) => CheckedConvert.ToUInt16(value);
            ucshort IConvert<ucshort>.ToValue(short value) => CheckedConvert.ToUInt16(value);
            ucshort IConvert<ucshort>.ToValue(string value) => Convert.ToUInt16(value);
            ucshort IConvert<ucshort>.ToValue(string value, IFormatProvider provider) => Convert.ToUInt16(value, provider);
            ucshort IConvert<ucshort>.ToValue(uint value) => CheckedConvert.ToUInt16(value);
            ucshort IConvert<ucshort>.ToValue(ulong value) => CheckedConvert.ToUInt16(value);
            ucshort IConvert<ucshort>.ToValue(ushort value) => value;

            bool IStringParser<ucshort>.TryParse(string s, IFormatProvider provider, out ucshort result) => TryParse(s, provider, out result);
            bool IStringParser<ucshort>.TryParse(string s, NumberStyles style, IFormatProvider provider, out ucshort result) => TryParse(s, style, provider, out result);
            bool IStringParser<ucshort>.TryParse(string s, NumberStyles style, out ucshort result) => TryParse(s, style, out result);
            bool IStringParser<ucshort>.TryParse(string s, out ucshort result) => TryParse(s, out result);
            ucshort IStringParser<ucshort>.Parse(string s) => Parse(s);
            ucshort IStringParser<ucshort>.Parse(string s, IFormatProvider provider) => Parse(s, provider);
            ucshort IStringParser<ucshort>.Parse(string s, NumberStyles style) => Parse(s, style);
            ucshort IStringParser<ucshort>.Parse(string s, NumberStyles style, IFormatProvider provider) => Parse(s, style, provider);

            byte ICast<ucshort>.ToByte(ucshort value) => (byte)value;
            decimal ICast<ucshort>.ToDecimal(ucshort value) => (decimal)value;
            double ICast<ucshort>.ToDouble(ucshort value) => (double)value;
            float ICast<ucshort>.ToSingle(ucshort value) => (float)value;
            int ICast<ucshort>.ToInt32(ucshort value) => (int)value;
            long ICast<ucshort>.ToInt64(ucshort value) => (long)value;
            sbyte ICast<ucshort>.ToSByte(ucshort value) => (sbyte)value;
            short ICast<ucshort>.ToInt16(ucshort value) => (short)value;
            uint ICast<ucshort>.ToUInt32(ucshort value) => (uint)value;
            ulong ICast<ucshort>.ToUInt64(ucshort value) => (ulong)value;
            ushort ICast<ucshort>.ToUInt16(ucshort value) => (ushort)value;

            ucshort ICast<ucshort>.ToValue(byte value) => (ucshort)value;
            ucshort ICast<ucshort>.ToValue(decimal value) => (ucshort)value;
            ucshort ICast<ucshort>.ToValue(double value) => (ucshort)value;
            ucshort ICast<ucshort>.ToValue(float value) => (ucshort)value;
            ucshort ICast<ucshort>.ToValue(int value) => (ucshort)value;
            ucshort ICast<ucshort>.ToValue(long value) => (ucshort)value;
            ucshort ICast<ucshort>.ToValue(sbyte value) => (ucshort)value;
            ucshort ICast<ucshort>.ToValue(short value) => (ucshort)value;
            ucshort ICast<ucshort>.ToValue(uint value) => (ucshort)value;
            ucshort ICast<ucshort>.ToValue(ulong value) => (ucshort)value;
            ucshort ICast<ucshort>.ToValue(ushort value) => (ucshort)value;
        }
    }
}
