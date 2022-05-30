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
    public readonly struct cbyte : INumeric<cbyte>
    {
        public static readonly cbyte MaxValue = new cbyte(byte.MaxValue);
        public static readonly cbyte MinValue = new cbyte(byte.MinValue);

        private readonly byte _value;

        private cbyte(byte value)
        {
            _value = value;
        }

        private cbyte(SerializationInfo info, StreamingContext context) : this(info.GetByte(nameof(cbyte))) { }
        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context) => info.AddValue(nameof(cbyte), _value);

        public int CompareTo(object? obj) => obj is cbyte other ? CompareTo(other) : 1;
        public int CompareTo(cbyte other) => _value.CompareTo(other._value);
        public bool Equals(cbyte other) => _value == other._value;
        public override bool Equals(object? obj) => obj is cbyte other && Equals(other);
        public override int GetHashCode() => _value.GetHashCode();
        public override string ToString() => _value.ToString();
        public string ToString(IFormatProvider formatProvider) => _value.ToString(formatProvider);
        public string ToString(string format) => _value.ToString(format);
        public string ToString(string format, IFormatProvider formatProvider) => _value.ToString(format, formatProvider);

        public static bool TryParse(string s, IFormatProvider provider, out cbyte result) => Try.Run(() => Parse(s, provider), out result);
        public static bool TryParse(string s, NumberStyles style, IFormatProvider provider, out cbyte result) => Try.Run(() => Parse(s, style, provider), out result);
        public static bool TryParse(string s, NumberStyles style, out cbyte result) => Try.Run(() => Parse(s, style), out result);
        public static bool TryParse(string s, out cbyte result) => Try.Run(() => Parse(s), out result);
        public static cbyte Parse(string s) => byte.Parse(s);
        public static cbyte Parse(string s, IFormatProvider provider) => byte.Parse(s, provider);
        public static cbyte Parse(string s, NumberStyles style) => byte.Parse(s, style);
        public static cbyte Parse(string s, NumberStyles style, IFormatProvider provider) => byte.Parse(s, style, provider);

        public static explicit operator cbyte(decimal value) => new cbyte(CheckedTruncate.ToByte(value));
        public static explicit operator cbyte(double value) => new cbyte(CheckedTruncate.ToByte(value));
        public static explicit operator cbyte(float value) => new cbyte(CheckedTruncate.ToByte(value));
        public static explicit operator cbyte(int value) => new cbyte(CheckedConvert.ToByte(value));
        public static explicit operator cbyte(long value) => new cbyte(CheckedConvert.ToByte(value));
        public static explicit operator cbyte(sbyte value) => new cbyte(CheckedConvert.ToByte(value));
        public static explicit operator cbyte(short value) => new cbyte(CheckedConvert.ToByte(value));
        public static explicit operator cbyte(uint value) => new cbyte(CheckedConvert.ToByte(value));
        public static explicit operator cbyte(ulong value) => new cbyte(CheckedConvert.ToByte(value));
        public static implicit operator cbyte(ushort value) => new cbyte(CheckedConvert.ToByte(value));
        public static implicit operator cbyte(byte value) => new cbyte(value);

        public static explicit operator byte(cbyte value) => CheckedConvert.ToByte(value._value);
        public static explicit operator int(cbyte value) => CheckedConvert.ToInt32(value._value);
        public static explicit operator sbyte(cbyte value) => CheckedConvert.ToSByte(value._value);
        public static explicit operator short(cbyte value) => CheckedConvert.ToInt16(value._value);
        public static implicit operator ushort(cbyte value) => value._value;
        public static implicit operator decimal(cbyte value) => value._value;
        public static implicit operator double(cbyte value) => value._value;
        public static implicit operator float(cbyte value) => value._value;
        public static implicit operator long(cbyte value) => value._value;
        public static implicit operator uint(cbyte value) => value._value;
        public static implicit operator ulong(cbyte value) => value._value;

        public static bool operator !=(cbyte left, cbyte right) => left._value != right._value;
        public static bool operator <(cbyte left, cbyte right) => left._value < right._value;
        public static bool operator <=(cbyte left, cbyte right) => left._value <= right._value;
        public static bool operator ==(cbyte left, cbyte right) => left._value == right._value;
        public static bool operator >(cbyte left, cbyte right) => left._value > right._value;
        public static bool operator >=(cbyte left, cbyte right) => left._value >= right._value;
        public static cbyte operator %(cbyte left, cbyte right) => CheckedArithmetic.Remainder(left._value, right._value);
        public static cbyte operator &(cbyte left, cbyte right) => (byte)(left._value & right._value);
        public static cbyte operator -(cbyte _) => MinValue;
        public static cbyte operator -(cbyte left, cbyte right) => CheckedArithmetic.Subtract(left._value, right._value);
        public static cbyte operator --(cbyte value) => value - 1;
        public static cbyte operator *(cbyte left, cbyte right) => CheckedArithmetic.Multiply(left._value, right._value);
        public static cbyte operator /(cbyte left, cbyte right) => CheckedArithmetic.Divide(left._value, right._value);
        public static cbyte operator ^(cbyte left, cbyte right) => (byte)(left._value ^ right._value);
        public static cbyte operator |(cbyte left, cbyte right) => (byte)(left._value | right._value);
        public static cbyte operator ~(cbyte value) => (byte)~value._value;
        public static cbyte operator +(cbyte left, cbyte right) => CheckedArithmetic.Add(left._value, right._value);
        public static cbyte operator +(cbyte value) => value;
        public static cbyte operator ++(cbyte value) => value + 1;
        public static cbyte operator <<(cbyte left, int right) => (byte)(left._value << right);
        public static cbyte operator >>(cbyte left, int right) => (byte)(left._value >> right);

        bool INumeric<cbyte>.IsGreaterThan(cbyte value) => this > value;
        bool INumeric<cbyte>.IsGreaterThanOrEqualTo(cbyte value) => this >= value;
        bool INumeric<cbyte>.IsLessThan(cbyte value) => this < value;
        bool INumeric<cbyte>.IsLessThanOrEqualTo(cbyte value) => this <= value;
        cbyte INumeric<cbyte>.Add(cbyte value) => this + value;
        cbyte INumeric<cbyte>.BitwiseComplement() => ~this;
        cbyte INumeric<cbyte>.Divide(cbyte value) => this / value;
        cbyte INumeric<cbyte>.LeftShift(int count) => this << count;
        cbyte INumeric<cbyte>.LogicalAnd(cbyte value) => this & value;
        cbyte INumeric<cbyte>.LogicalExclusiveOr(cbyte value) => this ^ value;
        cbyte INumeric<cbyte>.LogicalOr(cbyte value) => this | value;
        cbyte INumeric<cbyte>.Multiply(cbyte value) => this * value;
        cbyte INumeric<cbyte>.Negative() => -this;
        cbyte INumeric<cbyte>.Positive() => +this;
        cbyte INumeric<cbyte>.Remainder(cbyte value) => this % value;
        cbyte INumeric<cbyte>.RightShift(int count) => this >> count;
        cbyte INumeric<cbyte>.Subtract(cbyte value) => this - value;

        IBitConverter<cbyte> IBitConvertible<cbyte>.BitConverter => Utilities.Instance;
        ICast<cbyte> INumeric<cbyte>.Cast => Utilities.Instance;
        IConvert<cbyte> IConvertible<cbyte>.Convert => Utilities.Instance;
        IMath<cbyte> INumeric<cbyte>.Math => Utilities.Instance;
        INumericFunctions<cbyte> INumeric<cbyte>.NumericFunctions => Utilities.Instance;
        IRandom<cbyte> IRandomisable<cbyte>.Random => Utilities.Instance;
        IStringParser<cbyte> IStringParsable<cbyte>.StringParser => Utilities.Instance;

        private sealed class Utilities :
            IBitConverter<cbyte>,
            ICast<cbyte>,
            IConvert<cbyte>,
            IMath<cbyte>,
            INumericFunctions<cbyte>,
            IRandom<cbyte>,
            IStringParser<cbyte>
        {
            public readonly static Utilities Instance = new Utilities();

            bool INumericFunctions<cbyte>.HasFloatingPoint { get; } = false;
            bool INumericFunctions<cbyte>.IsFinite(cbyte x) => true;
            bool INumericFunctions<cbyte>.IsInfinity(cbyte x) => false;
            bool INumericFunctions<cbyte>.IsNaN(cbyte x) => false;
            bool INumericFunctions<cbyte>.IsNegative(cbyte x) => false;
            bool INumericFunctions<cbyte>.IsNegativeInfinity(cbyte x) => false;
            bool INumericFunctions<cbyte>.IsNormal(cbyte x) => false;
            bool INumericFunctions<cbyte>.IsPositiveInfinity(cbyte x) => false;
            bool INumericFunctions<cbyte>.IsReal { get; } = false;
            bool INumericFunctions<cbyte>.IsSigned { get; } = false;
            bool INumericFunctions<cbyte>.IsSubnormal(cbyte x) => false;
            cbyte INumericFunctions<cbyte>.Epsilon { get; } = 1;
            cbyte INumericFunctions<cbyte>.MaxUnit { get; } = 1;
            cbyte INumericFunctions<cbyte>.MaxValue => MaxValue;
            cbyte INumericFunctions<cbyte>.MinUnit { get; } = 0;
            cbyte INumericFunctions<cbyte>.MinValue => MinValue;
            cbyte INumericFunctions<cbyte>.One { get; } = 1;
            cbyte INumericFunctions<cbyte>.Ten { get; } = 10;
            cbyte INumericFunctions<cbyte>.Two { get; } = 2;
            cbyte INumericFunctions<cbyte>.Zero { get; } = 0;

            cbyte IMath<cbyte>.Abs(cbyte x) => x;
            cbyte IMath<cbyte>.Acos(cbyte x) => CheckedCast.ToByte(Math.Acos(x._value));
            cbyte IMath<cbyte>.Acosh(cbyte x) => CheckedCast.ToByte(Math.Acosh(x._value));
            cbyte IMath<cbyte>.Asin(cbyte x) => CheckedCast.ToByte(Math.Asin(x._value));
            cbyte IMath<cbyte>.Asinh(cbyte x) => CheckedCast.ToByte(Math.Asinh(x._value));
            cbyte IMath<cbyte>.Atan(cbyte x) => CheckedCast.ToByte(Math.Atan(x._value));
            cbyte IMath<cbyte>.Atan2(cbyte x, cbyte y) => CheckedCast.ToByte(Math.Atan2(x._value, y._value));
            cbyte IMath<cbyte>.Atanh(cbyte x) => CheckedCast.ToByte(Math.Atanh(x._value));
            cbyte IMath<cbyte>.Cbrt(cbyte x) => CheckedCast.ToByte(Math.Cbrt(x._value));
            cbyte IMath<cbyte>.Ceiling(cbyte x) => x;
            cbyte IMath<cbyte>.Clamp(cbyte x, cbyte bound1, cbyte bound2) => bound1 > bound2 ? Math.Min(bound1._value, Math.Max(bound2._value, x._value)) : Math.Min(bound2._value, Math.Max(bound1._value, x._value));
            cbyte IMath<cbyte>.Cos(cbyte x) => CheckedCast.ToByte(Math.Cos(x._value));
            cbyte IMath<cbyte>.Cosh(cbyte x) => CheckedCast.ToByte(Math.Cosh(x._value));
            cbyte IMath<cbyte>.DegreesToRadians(cbyte x) => CheckedCast.ToByte(CheckedArithmetic.Multiply(x, Trig.RadiansPerDegree));
            cbyte IMath<cbyte>.E { get; } = 2;
            cbyte IMath<cbyte>.Exp(cbyte x) => CheckedCast.ToByte(Math.Exp(x._value));
            cbyte IMath<cbyte>.Floor(cbyte x) => x;
            cbyte IMath<cbyte>.IEEERemainder(cbyte x, cbyte y) => CheckedCast.ToByte(Math.IEEERemainder(x._value, y._value));
            cbyte IMath<cbyte>.Log(cbyte x) => CheckedCast.ToByte(Math.Log(x._value));
            cbyte IMath<cbyte>.Log(cbyte x, cbyte y) => CheckedCast.ToByte(Math.Log(x._value, y._value));
            cbyte IMath<cbyte>.Log10(cbyte x) => CheckedCast.ToByte(Math.Log10(x._value));
            cbyte IMath<cbyte>.Max(cbyte x, cbyte y) => Math.Max(x._value, y._value);
            cbyte IMath<cbyte>.Min(cbyte x, cbyte y) => Math.Min(x._value, y._value);
            cbyte IMath<cbyte>.PI { get; } = 3;
            cbyte IMath<cbyte>.Pow(cbyte x, cbyte y) => CheckedArithmetic.Pow(x._value, y._value);
            cbyte IMath<cbyte>.RadiansToDegrees(cbyte x) => CheckedCast.ToByte(CheckedArithmetic.Multiply(x, Trig.DegreesPerRadian));
            cbyte IMath<cbyte>.Round(cbyte x) => x;
            cbyte IMath<cbyte>.Round(cbyte x, int digits) => x;
            cbyte IMath<cbyte>.Round(cbyte x, int digits, MidpointRounding mode) => x;
            cbyte IMath<cbyte>.Round(cbyte x, MidpointRounding mode) => x;
            cbyte IMath<cbyte>.RoundToSignificance(cbyte x, int significantDigits, MidpointRounding mode) => Digits.RoundToSignificance(x, significantDigits, mode);
            cbyte IMath<cbyte>.Sin(cbyte x) => CheckedCast.ToByte(Math.Sin(x._value));
            cbyte IMath<cbyte>.Sinh(cbyte x) => CheckedCast.ToByte(Math.Sinh(x._value));
            cbyte IMath<cbyte>.Sqrt(cbyte x) => CheckedCast.ToByte(Math.Sqrt(x._value));
            cbyte IMath<cbyte>.Tan(cbyte x) => CheckedCast.ToByte(Math.Tan(x._value));
            cbyte IMath<cbyte>.Tanh(cbyte x) => CheckedCast.ToByte(Math.Tanh(x._value));
            cbyte IMath<cbyte>.Tau { get; } = 6;
            cbyte IMath<cbyte>.Truncate(cbyte x) => x;
            cbyte IMath<cbyte>.TruncateToSignificance(cbyte x, int significantDigits) => Digits.Truncate(x, significantDigits);
            int IMath<cbyte>.Sign(cbyte x) => x._value == 0 ? 0 : 1;

            cbyte IBitConverter<cbyte>.Read(IReadOnlyStream<byte> stream) => stream.Read(1)[0];
            void IBitConverter<cbyte>.Write(cbyte value, IWriteOnlyStream<byte> stream) => stream.Write(new[] { value._value });

            cbyte IRandom<cbyte>.Next(Random random) => random.NextByte();
            cbyte IRandom<cbyte>.Next(Random random, cbyte bound1, cbyte bound2) => random.NextByte(bound1._value, bound2._value);

            bool IConvert<cbyte>.ToBoolean(cbyte value) => CheckedConvert.ToBoolean(value._value);
            byte IConvert<cbyte>.ToByte(cbyte value) => value._value;
            decimal IConvert<cbyte>.ToDecimal(cbyte value) => CheckedConvert.ToDecimal(value._value);
            double IConvert<cbyte>.ToDouble(cbyte value) => CheckedConvert.ToDouble(value._value);
            float IConvert<cbyte>.ToSingle(cbyte value) => CheckedConvert.ToSingle(value._value);
            int IConvert<cbyte>.ToInt32(cbyte value) => CheckedConvert.ToInt32(value._value);
            long IConvert<cbyte>.ToInt64(cbyte value) => CheckedConvert.ToInt64(value._value);
            sbyte IConvert<cbyte>.ToSByte(cbyte value) => CheckedConvert.ToSByte(value._value);
            short IConvert<cbyte>.ToInt16(cbyte value) => CheckedConvert.ToInt16(value._value);
            string IConvert<cbyte>.ToString(cbyte value) => Convert.ToString(value._value);
            string IConvert<cbyte>.ToString(cbyte value, IFormatProvider provider) => Convert.ToString(value._value, provider);
            uint IConvert<cbyte>.ToUInt32(cbyte value) => CheckedConvert.ToUInt16(value._value);
            ulong IConvert<cbyte>.ToUInt64(cbyte value) => CheckedConvert.ToUInt64(value._value);
            ushort IConvert<cbyte>.ToUInt16(cbyte value) => CheckedConvert.ToByte(value._value);

            cbyte IConvert<cbyte>.ToValue(bool value) => CheckedConvert.ToByte(value);
            cbyte IConvert<cbyte>.ToValue(byte value) => CheckedConvert.ToByte(value);
            cbyte IConvert<cbyte>.ToValue(decimal value) => CheckedConvert.ToByte(value);
            cbyte IConvert<cbyte>.ToValue(double value) => CheckedConvert.ToByte(value);
            cbyte IConvert<cbyte>.ToValue(float value) => CheckedConvert.ToByte(value);
            cbyte IConvert<cbyte>.ToValue(int value) => CheckedConvert.ToByte(value);
            cbyte IConvert<cbyte>.ToValue(long value) => CheckedConvert.ToByte(value);
            cbyte IConvert<cbyte>.ToValue(sbyte value) => CheckedConvert.ToByte(value);
            cbyte IConvert<cbyte>.ToValue(short value) => CheckedConvert.ToByte(value);
            cbyte IConvert<cbyte>.ToValue(string value) => Convert.ToByte(value);
            cbyte IConvert<cbyte>.ToValue(string value, IFormatProvider provider) => Convert.ToByte(value, provider);
            cbyte IConvert<cbyte>.ToValue(uint value) => CheckedConvert.ToByte(value);
            cbyte IConvert<cbyte>.ToValue(ulong value) => CheckedConvert.ToByte(value);
            cbyte IConvert<cbyte>.ToValue(ushort value) => value;

            bool IStringParser<cbyte>.TryParse(string s, IFormatProvider provider, out cbyte result) => TryParse(s, provider, out result);
            bool IStringParser<cbyte>.TryParse(string s, NumberStyles style, IFormatProvider provider, out cbyte result) => TryParse(s, style, provider, out result);
            bool IStringParser<cbyte>.TryParse(string s, NumberStyles style, out cbyte result) => TryParse(s, style, out result);
            bool IStringParser<cbyte>.TryParse(string s, out cbyte result) => TryParse(s, out result);
            cbyte IStringParser<cbyte>.Parse(string s) => Parse(s);
            cbyte IStringParser<cbyte>.Parse(string s, IFormatProvider provider) => Parse(s, provider);
            cbyte IStringParser<cbyte>.Parse(string s, NumberStyles style) => Parse(s, style);
            cbyte IStringParser<cbyte>.Parse(string s, NumberStyles style, IFormatProvider provider) => Parse(s, style, provider);

            byte ICast<cbyte>.ToByte(cbyte value) => (byte)value;
            decimal ICast<cbyte>.ToDecimal(cbyte value) => (decimal)value;
            double ICast<cbyte>.ToDouble(cbyte value) => (double)value;
            float ICast<cbyte>.ToSingle(cbyte value) => (float)value;
            int ICast<cbyte>.ToInt32(cbyte value) => (int)value;
            long ICast<cbyte>.ToInt64(cbyte value) => (long)value;
            sbyte ICast<cbyte>.ToSByte(cbyte value) => (sbyte)value;
            short ICast<cbyte>.ToInt16(cbyte value) => (short)value;
            uint ICast<cbyte>.ToUInt32(cbyte value) => (uint)value;
            ulong ICast<cbyte>.ToUInt64(cbyte value) => (ulong)value;
            ushort ICast<cbyte>.ToUInt16(cbyte value) => (ushort)value;

            cbyte ICast<cbyte>.ToValue(byte value) => (cbyte)value;
            cbyte ICast<cbyte>.ToValue(decimal value) => (cbyte)value;
            cbyte ICast<cbyte>.ToValue(double value) => (cbyte)value;
            cbyte ICast<cbyte>.ToValue(float value) => (cbyte)value;
            cbyte ICast<cbyte>.ToValue(int value) => (cbyte)value;
            cbyte ICast<cbyte>.ToValue(long value) => (cbyte)value;
            cbyte ICast<cbyte>.ToValue(sbyte value) => (cbyte)value;
            cbyte ICast<cbyte>.ToValue(short value) => (cbyte)value;
            cbyte ICast<cbyte>.ToValue(uint value) => (cbyte)value;
            cbyte ICast<cbyte>.ToValue(ulong value) => (cbyte)value;
            cbyte ICast<cbyte>.ToValue(ushort value) => (cbyte)value;
        }
    }
}
