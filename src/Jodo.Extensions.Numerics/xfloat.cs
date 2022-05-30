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
    public readonly struct xfloat : INumeric<xfloat>
    {
        public static readonly xfloat Epsilon = float.Epsilon;
        public static readonly xfloat MaxValue = float.MaxValue;
        public static readonly xfloat MinValue = float.MinValue;

        private readonly float _value;

        private xfloat(float value)
        {
            _value = value;
        }

        private xfloat(SerializationInfo info, StreamingContext context) : this(info.GetSingle(nameof(xfloat))) { }
        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context) => info.AddValue(nameof(xfloat), _value);

        public int CompareTo(xfloat other) => _value.CompareTo(other._value);
        public int CompareTo(object? obj) => obj is xfloat other ? CompareTo(other) : 1;
        public bool Equals(xfloat other) => _value == other._value;
        public override bool Equals(object? obj) => obj is xfloat other && Equals(other);
        public override int GetHashCode() => _value.GetHashCode();
        public override string ToString() => _value.ToString();
        public string ToString(IFormatProvider formatProvider) => _value.ToString(formatProvider);
        public string ToString(string format) => _value.ToString(format);
        public string ToString(string format, IFormatProvider formatProvider) => _value.ToString(format, formatProvider);

        public static bool IsFinite(xfloat f) => float.IsFinite(f);
        public static bool IsInfinity(xfloat f) => float.IsInfinity(f);
        public static bool IsNaN(xfloat f) => float.IsNaN(f);
        public static bool IsNegative(xfloat f) => float.IsNegative(f);
        public static bool IsNegativeInfinity(xfloat f) => float.IsNegativeInfinity(f);
        public static bool IsNormal(xfloat f) => float.IsNormal(f);
        public static bool IsPositiveInfinity(xfloat f) => float.IsPositiveInfinity(f);
        public static bool IsSubnormal(xfloat f) => float.IsSubnormal(f);

        public static bool TryParse(string s, IFormatProvider provider, out xfloat result) => Try.Run(() => Parse(s, provider), out result);
        public static bool TryParse(string s, NumberStyles style, IFormatProvider provider, out xfloat result) => Try.Run(() => Parse(s, style, provider), out result);
        public static bool TryParse(string s, NumberStyles style, out xfloat result) => Try.Run(() => Parse(s, style), out result);
        public static bool TryParse(string s, out xfloat result) => Try.Run(() => Parse(s), out result);
        public static xfloat Parse(string s) => float.Parse(s);
        public static xfloat Parse(string s, IFormatProvider provider) => float.Parse(s, provider);
        public static xfloat Parse(string s, NumberStyles style) => float.Parse(s, style);
        public static xfloat Parse(string s, NumberStyles style, IFormatProvider provider) => float.Parse(s, style, provider);

        public static explicit operator xfloat(decimal value) => new xfloat((float)value);
        public static explicit operator xfloat(double value) => new xfloat((float)value);
        public static implicit operator xfloat(byte value) => new xfloat(value);
        public static implicit operator xfloat(char value) => new xfloat(value);
        public static implicit operator xfloat(float value) => new xfloat(value);
        public static implicit operator xfloat(int value) => new xfloat(value);
        public static implicit operator xfloat(long value) => new xfloat(value);
        public static implicit operator xfloat(sbyte value) => new xfloat(value);
        public static implicit operator xfloat(short value) => new xfloat(value);
        public static implicit operator xfloat(uint value) => new xfloat(value);
        public static implicit operator xfloat(ulong value) => new xfloat(value);
        public static implicit operator xfloat(ushort value) => new xfloat(value);

        public static explicit operator byte(xfloat value) => (byte)value._value;
        public static explicit operator char(xfloat value) => (char)value._value;
        public static explicit operator decimal(xfloat value) => (decimal)value._value;
        public static explicit operator int(xfloat value) => (int)value._value;
        public static explicit operator long(xfloat value) => (long)value._value;
        public static explicit operator sbyte(xfloat value) => (sbyte)value._value;
        public static explicit operator short(xfloat value) => (short)value._value;
        public static explicit operator uint(xfloat value) => (uint)value._value;
        public static explicit operator ulong(xfloat value) => (ulong)value._value;
        public static explicit operator ushort(xfloat value) => (ushort)value._value;
        public static implicit operator double(xfloat value) => value._value;
        public static implicit operator float(xfloat value) => value._value;

        public static bool operator !=(xfloat left, xfloat right) => left._value != right._value;
        public static bool operator <(xfloat left, xfloat right) => left._value < right._value;
        public static bool operator <=(xfloat left, xfloat right) => left._value <= right._value;
        public static bool operator ==(xfloat left, xfloat right) => left._value == right._value;
        public static bool operator >(xfloat left, xfloat right) => left._value > right._value;
        public static bool operator >=(xfloat left, xfloat right) => left._value >= right._value;
        public static xfloat operator %(xfloat left, xfloat right) => left._value % right._value;
        public static xfloat operator &(xfloat left, xfloat right) => BitwiseAndShiftUtilities.LogicalAnd(left._value, right._value);
        public static xfloat operator -(xfloat left, xfloat right) => left._value - right._value;
        public static xfloat operator --(xfloat value) => value._value - 1;
        public static xfloat operator -(xfloat value) => -value._value;
        public static xfloat operator *(xfloat left, xfloat right) => left._value * right._value;
        public static xfloat operator /(xfloat left, xfloat right) => left._value / right._value;
        public static xfloat operator ^(xfloat left, xfloat right) => BitwiseAndShiftUtilities.LogicalExclusiveOr(left._value, right._value);
        public static xfloat operator |(xfloat left, xfloat right) => BitwiseAndShiftUtilities.LogicalOr(left._value, right._value);
        public static xfloat operator ~(xfloat left) => BitwiseAndShiftUtilities.BitwiseComplement(left._value);
        public static xfloat operator +(xfloat left, xfloat right) => left._value + right._value;
        public static xfloat operator +(xfloat value) => value;
        public static xfloat operator ++(xfloat value) => value._value + 1;
        public static xfloat operator <<(xfloat left, int right) => BitwiseAndShiftUtilities.LeftShift(left._value, right);
        public static xfloat operator >>(xfloat left, int right) => BitwiseAndShiftUtilities.RightShift(left._value, right);

        bool INumeric<xfloat>.IsGreaterThan(xfloat value) => this > value;
        bool INumeric<xfloat>.IsGreaterThanOrEqualTo(xfloat value) => this >= value;
        bool INumeric<xfloat>.IsLessThan(xfloat value) => this < value;
        bool INumeric<xfloat>.IsLessThanOrEqualTo(xfloat value) => this <= value;
        xfloat INumeric<xfloat>.Add(xfloat value) => this + value;
        xfloat INumeric<xfloat>.BitwiseComplement() => ~this;
        xfloat INumeric<xfloat>.Divide(xfloat value) => this / value;
        xfloat INumeric<xfloat>.LeftShift(int count) => this << count;
        xfloat INumeric<xfloat>.LogicalAnd(xfloat value) => this & value;
        xfloat INumeric<xfloat>.LogicalExclusiveOr(xfloat value) => this ^ value;
        xfloat INumeric<xfloat>.LogicalOr(xfloat value) => this | value;
        xfloat INumeric<xfloat>.Multiply(xfloat value) => this * value;
        xfloat INumeric<xfloat>.Negative() => -this;
        xfloat INumeric<xfloat>.Positive() => +this;
        xfloat INumeric<xfloat>.Remainder(xfloat value) => this % value;
        xfloat INumeric<xfloat>.RightShift(int count) => this >> count;
        xfloat INumeric<xfloat>.Subtract(xfloat value) => this - value;

        IBitConverter<xfloat> IBitConvertible<xfloat>.BitConverter => Utilities.Instance;
        ICast<xfloat> INumeric<xfloat>.Cast => Utilities.Instance;
        IConvert<xfloat> IConvertible<xfloat>.Convert => Utilities.Instance;
        IMath<xfloat> INumeric<xfloat>.Math => Utilities.Instance;
        INumericFunctions<xfloat> INumeric<xfloat>.NumericFunctions => Utilities.Instance;
        IRandom<xfloat> IRandomisable<xfloat>.Random => Utilities.Instance;
        IStringParser<xfloat> IStringParsable<xfloat>.StringParser => Utilities.Instance;

        private sealed class Utilities :
            IBitConverter<xfloat>,
            ICast<xfloat>,
            IConvert<xfloat>,
            IMath<xfloat>,
            INumericFunctions<xfloat>,
            IRandom<xfloat>,
            IStringParser<xfloat>
        {
            public readonly static Utilities Instance = new Utilities();

            bool INumericFunctions<xfloat>.HasFloatingPoint { get; } = true;
            bool INumericFunctions<xfloat>.IsFinite(xfloat x) => IsFinite(x);
            bool INumericFunctions<xfloat>.IsInfinity(xfloat x) => IsInfinity(x);
            bool INumericFunctions<xfloat>.IsNaN(xfloat x) => IsNaN(x);
            bool INumericFunctions<xfloat>.IsNegative(xfloat x) => IsNegative(x);
            bool INumericFunctions<xfloat>.IsNegativeInfinity(xfloat x) => IsNegativeInfinity(x);
            bool INumericFunctions<xfloat>.IsNormal(xfloat x) => IsNormal(x);
            bool INumericFunctions<xfloat>.IsPositiveInfinity(xfloat x) => IsPositiveInfinity(x);
            bool INumericFunctions<xfloat>.IsReal { get; } = true;
            bool INumericFunctions<xfloat>.IsSigned { get; } = true;
            bool INumericFunctions<xfloat>.IsSubnormal(xfloat x) => IsSubnormal(x);
            xfloat INumericFunctions<xfloat>.Epsilon => Epsilon;
            xfloat INumericFunctions<xfloat>.MaxUnit { get; } = 1f;
            xfloat INumericFunctions<xfloat>.MaxValue => MaxValue;
            xfloat INumericFunctions<xfloat>.MinUnit { get; } = -1f;
            xfloat INumericFunctions<xfloat>.MinValue => MinValue;
            xfloat INumericFunctions<xfloat>.One { get; } = 1f;
            xfloat INumericFunctions<xfloat>.Ten { get; } = 10f;
            xfloat INumericFunctions<xfloat>.Two { get; } = 2f;
            xfloat INumericFunctions<xfloat>.Zero { get; } = 0f;

            int IMath<xfloat>.Sign(xfloat x) => Math.Sign(x._value);
            xfloat IMath<xfloat>.Abs(xfloat x) => MathF.Abs(x._value);
            xfloat IMath<xfloat>.Acos(xfloat x) => MathF.Acos(x._value);
            xfloat IMath<xfloat>.Acosh(xfloat x) => MathF.Acosh(x._value);
            xfloat IMath<xfloat>.Asin(xfloat x) => MathF.Asin(x._value);
            xfloat IMath<xfloat>.Asinh(xfloat x) => MathF.Asinh(x._value);
            xfloat IMath<xfloat>.Atan(xfloat x) => MathF.Atan(x._value);
            xfloat IMath<xfloat>.Atan2(xfloat x, xfloat y) => MathF.Atan2(x._value, y._value);
            xfloat IMath<xfloat>.Atanh(xfloat x) => MathF.Atanh(x._value);
            xfloat IMath<xfloat>.Cbrt(xfloat x) => MathF.Cbrt(x._value);
            xfloat IMath<xfloat>.Ceiling(xfloat x) => MathF.Ceiling(x._value);
            xfloat IMath<xfloat>.Clamp(xfloat x, xfloat bound1, xfloat bound2) => bound1 > bound2 ? MathF.Min(bound1._value, MathF.Max(bound2._value, x._value)) : MathF.Min(bound2._value, MathF.Max(bound1._value, x._value));
            xfloat IMath<xfloat>.Cos(xfloat x) => MathF.Cos(x._value);
            xfloat IMath<xfloat>.Cosh(xfloat x) => MathF.Cosh(x._value);
            xfloat IMath<xfloat>.DegreesToRadians(xfloat x) => x * Trig.RadiansPerDegreeF;
            xfloat IMath<xfloat>.E { get; } = MathF.E;
            xfloat IMath<xfloat>.Exp(xfloat x) => MathF.Exp(x._value);
            xfloat IMath<xfloat>.Floor(xfloat x) => MathF.Floor(x._value);
            xfloat IMath<xfloat>.IEEERemainder(xfloat x, xfloat y) => MathF.IEEERemainder(x._value, y._value);
            xfloat IMath<xfloat>.Log(xfloat x) => MathF.Log(x._value);
            xfloat IMath<xfloat>.Log(xfloat x, xfloat y) => MathF.Log(x._value, y._value);
            xfloat IMath<xfloat>.Log10(xfloat x) => MathF.Log10(x._value);
            xfloat IMath<xfloat>.Max(xfloat x, xfloat y) => MathF.Max(x._value, y._value);
            xfloat IMath<xfloat>.Min(xfloat x, xfloat y) => MathF.Min(x._value, y._value);
            xfloat IMath<xfloat>.PI { get; } = MathF.PI;
            xfloat IMath<xfloat>.Pow(xfloat x, xfloat y) => MathF.Pow(x._value, y._value);
            xfloat IMath<xfloat>.RadiansToDegrees(xfloat x) => x * Trig.DegreesPerRadianF;
            xfloat IMath<xfloat>.Round(xfloat x) => MathF.Round(x);
            xfloat IMath<xfloat>.Round(xfloat x, int digits) => MathF.Round(x, digits);
            xfloat IMath<xfloat>.Round(xfloat x, int digits, MidpointRounding mode) => MathF.Round(x, digits, mode);
            xfloat IMath<xfloat>.Round(xfloat x, MidpointRounding mode) => MathF.Round(x, mode);
            xfloat IMath<xfloat>.RoundToSignificance(xfloat x, int significantDigits, MidpointRounding mode) => Digits.RoundToSignificance(x, significantDigits, mode);
            xfloat IMath<xfloat>.Sin(xfloat x) => MathF.Sin(x._value);
            xfloat IMath<xfloat>.Sinh(xfloat x) => MathF.Sinh(x._value);
            xfloat IMath<xfloat>.Sqrt(xfloat x) => MathF.Sqrt(x._value);
            xfloat IMath<xfloat>.Tan(xfloat x) => MathF.Tan(x._value);
            xfloat IMath<xfloat>.Tanh(xfloat x) => MathF.Tanh(x._value);
            xfloat IMath<xfloat>.Tau { get; } = MathF.PI * 2;
            xfloat IMath<xfloat>.Truncate(xfloat x) => MathF.Truncate(x._value);
            xfloat IMath<xfloat>.TruncateToSignificance(xfloat x, int significantDigits) => Digits.Truncate(x, significantDigits);

            xfloat IBitConverter<xfloat>.Read(IReadOnlyStream<byte> stream) => BitConverter.ToSingle(stream.Read(sizeof(float)));
            void IBitConverter<xfloat>.Write(xfloat value, IWriteOnlyStream<byte> stream) => stream.Write(BitConverter.GetBytes(value._value));

            xfloat IRandom<xfloat>.Next(Random random) => random.NextSingle(float.MinValue, float.MaxValue);
            xfloat IRandom<xfloat>.Next(Random random, xfloat bound1, xfloat bound2) => random.NextSingle(bound1._value, bound2._value);

            bool IConvert<xfloat>.ToBoolean(xfloat value) => Convert.ToBoolean(value._value);
            byte IConvert<xfloat>.ToByte(xfloat value) => Convert.ToByte(value._value);
            decimal IConvert<xfloat>.ToDecimal(xfloat value) => Convert.ToDecimal(value._value);
            double IConvert<xfloat>.ToDouble(xfloat value) => Convert.ToDouble(value._value);
            float IConvert<xfloat>.ToSingle(xfloat value) => Convert.ToSingle(value._value);
            int IConvert<xfloat>.ToInt32(xfloat value) => Convert.ToInt32(value._value);
            long IConvert<xfloat>.ToInt64(xfloat value) => Convert.ToInt64(value._value);
            sbyte IConvert<xfloat>.ToSByte(xfloat value) => Convert.ToSByte(value._value);
            short IConvert<xfloat>.ToInt16(xfloat value) => Convert.ToInt16(value._value);
            string IConvert<xfloat>.ToString(xfloat value) => Convert.ToString(value._value);
            string IConvert<xfloat>.ToString(xfloat value, IFormatProvider provider) => Convert.ToString(value._value, provider);
            uint IConvert<xfloat>.ToUInt32(xfloat value) => Convert.ToUInt32(value._value);
            ulong IConvert<xfloat>.ToUInt64(xfloat value) => Convert.ToUInt64(value._value);
            ushort IConvert<xfloat>.ToUInt16(xfloat value) => Convert.ToUInt16(value._value);

            xfloat IConvert<xfloat>.ToValue(bool value) => Convert.ToSingle(value);
            xfloat IConvert<xfloat>.ToValue(byte value) => Convert.ToSingle(value);
            xfloat IConvert<xfloat>.ToValue(float value) => Convert.ToSingle(value);
            xfloat IConvert<xfloat>.ToValue(double value) => Convert.ToSingle(value);
            xfloat IConvert<xfloat>.ToValue(decimal value) => Convert.ToSingle(value);
            xfloat IConvert<xfloat>.ToValue(int value) => Convert.ToSingle(value);
            xfloat IConvert<xfloat>.ToValue(long value) => Convert.ToSingle(value);
            xfloat IConvert<xfloat>.ToValue(sbyte value) => Convert.ToSingle(value);
            xfloat IConvert<xfloat>.ToValue(short value) => Convert.ToSingle(value);
            xfloat IConvert<xfloat>.ToValue(string value) => Convert.ToSingle(value);
            xfloat IConvert<xfloat>.ToValue(string value, IFormatProvider provider) => Convert.ToSingle(value, provider);
            xfloat IConvert<xfloat>.ToValue(uint value) => Convert.ToSingle(value);
            xfloat IConvert<xfloat>.ToValue(ulong value) => Convert.ToSingle(value);
            xfloat IConvert<xfloat>.ToValue(ushort value) => Convert.ToSingle(value);

            bool IStringParser<xfloat>.TryParse(string s, IFormatProvider provider, out xfloat result) => TryParse(s, provider, out result);
            bool IStringParser<xfloat>.TryParse(string s, NumberStyles style, IFormatProvider provider, out xfloat result) => TryParse(s, style, provider, out result);
            bool IStringParser<xfloat>.TryParse(string s, NumberStyles style, out xfloat result) => TryParse(s, style, out result);
            bool IStringParser<xfloat>.TryParse(string s, out xfloat result) => TryParse(s, out result);
            xfloat IStringParser<xfloat>.Parse(string s) => Parse(s);
            xfloat IStringParser<xfloat>.Parse(string s, IFormatProvider provider) => Parse(s, provider);
            xfloat IStringParser<xfloat>.Parse(string s, NumberStyles style) => Parse(s, style);
            xfloat IStringParser<xfloat>.Parse(string s, NumberStyles style, IFormatProvider provider) => Parse(s, style, provider);

            byte ICast<xfloat>.ToByte(xfloat value) => (byte)value;
            decimal ICast<xfloat>.ToDecimal(xfloat value) => (decimal)value;
            double ICast<xfloat>.ToDouble(xfloat value) => (double)value;
            float ICast<xfloat>.ToSingle(xfloat value) => (float)value;
            int ICast<xfloat>.ToInt32(xfloat value) => (int)value;
            long ICast<xfloat>.ToInt64(xfloat value) => (long)value;
            sbyte ICast<xfloat>.ToSByte(xfloat value) => (sbyte)value;
            short ICast<xfloat>.ToInt16(xfloat value) => (short)value;
            uint ICast<xfloat>.ToUInt32(xfloat value) => (uint)value;
            ulong ICast<xfloat>.ToUInt64(xfloat value) => (ulong)value;
            ushort ICast<xfloat>.ToUInt16(xfloat value) => (ushort)value;

            xfloat ICast<xfloat>.ToValue(byte value) => (xfloat)value;
            xfloat ICast<xfloat>.ToValue(decimal value) => (xfloat)value;
            xfloat ICast<xfloat>.ToValue(double value) => (xfloat)value;
            xfloat ICast<xfloat>.ToValue(float value) => (xfloat)value;
            xfloat ICast<xfloat>.ToValue(int value) => (xfloat)value;
            xfloat ICast<xfloat>.ToValue(long value) => (xfloat)value;
            xfloat ICast<xfloat>.ToValue(sbyte value) => (xfloat)value;
            xfloat ICast<xfloat>.ToValue(short value) => (xfloat)value;
            xfloat ICast<xfloat>.ToValue(uint value) => (xfloat)value;
            xfloat ICast<xfloat>.ToValue(ulong value) => (xfloat)value;
            xfloat ICast<xfloat>.ToValue(ushort value) => (xfloat)value;
        }
    }
}
