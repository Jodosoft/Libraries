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
    public readonly struct ucfix64 : INumeric<ucfix64>
    {
        public static readonly ucfix64 Epsilon = new ucfix64(1);
        public static readonly ucfix64 MaxValue = new ucfix64(ulong.MaxValue);
        public static readonly ucfix64 MinValue = new ucfix64(ulong.MinValue);

        private const ulong ScalingFactor = 1_000_000;

        private readonly ulong _scaledValue;

        private ucfix64(ulong scaledValue)
        {
            _scaledValue = scaledValue;
        }

        private ucfix64(SerializationInfo info, StreamingContext context) : this(info.GetUInt64(nameof(ucfix64))) { }
        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context) => info.AddValue(nameof(ucfix64), _scaledValue);

        public int CompareTo(object? obj) => obj is ucfix64 other ? CompareTo(other) : 1;
        public int CompareTo(ucfix64 other) => _scaledValue.CompareTo(other._scaledValue);
        public bool Equals(ucfix64 other) => _scaledValue == other._scaledValue;
        public override bool Equals(object? obj) => obj is ucfix64 other && Equals(other);
        public override int GetHashCode() => _scaledValue.GetHashCode();
        public override string ToString() => $"{_scaledValue}/{ScalingFactor}";
        public string ToString(IFormatProvider formatProvider) => $"{_scaledValue.ToString(formatProvider)}/{ScalingFactor.ToString(formatProvider)}";
        public string ToString(string format) => $"{_scaledValue.ToString(format)}/{ScalingFactor.ToString(format)}";
        public string ToString(string format, IFormatProvider formatProvider) => $"{_scaledValue.ToString(format, formatProvider)}/{ScalingFactor.ToString(format, formatProvider)}";

        public static bool TryParse(string s, IFormatProvider provider, out ucfix64 result) => Try.Run(() => Parse(s, provider), out result);
        public static bool TryParse(string s, NumberStyles style, IFormatProvider provider, out ucfix64 result) => Try.Run(() => Parse(s, style, provider), out result);
        public static bool TryParse(string s, NumberStyles style, out ucfix64 result) => Try.Run(() => Parse(s, style), out result);
        public static bool TryParse(string s, out ucfix64 result) => Try.Run(() => Parse(s), out result);
        public static ucfix64 Parse(string s) => new ucfix64(ulong.Parse(s.Substring(0, s.IndexOf("/"))));
        public static ucfix64 Parse(string s, IFormatProvider provider) => new ucfix64(ulong.Parse(s.Substring(0, s.IndexOf("/")), provider));
        public static ucfix64 Parse(string s, NumberStyles style) => new ucfix64(ulong.Parse(s.Substring(0, s.IndexOf("/")), style));
        public static ucfix64 Parse(string s, NumberStyles style, IFormatProvider provider) => new ucfix64(ulong.Parse(s.Substring(0, s.IndexOf("/")), style, provider));

        private static ucfix64 Round(ucfix64 value, int digits, MidpointRounding mode)
        {
            if (digits < 0 || digits > 5) throw new ArgumentOutOfRangeException(nameof(digits), digits, "Must be between 0 and 5 (inclusive).");
            return new ucfix64(Numerics.Round.Digits(value._scaledValue, 5 - digits, mode));
        }

        private static ucfix64 ParseDouble(double value)
        {
            string str = string.Format(CultureInfo.InvariantCulture, "{0:0.0000000}", value)
                            .Replace(".", string.Empty)[..^1];
            if (ulong.TryParse(str, out var lng))
            {
                return new ucfix64(lng);
            }
            else
            {
                if (value > 0) return MaxValue;
                return MinValue;
            }
        }

        public static explicit operator ucfix64(decimal value) => new ucfix64(CheckedCast.ToUInt64(value * ScalingFactor));
        public static explicit operator ucfix64(double value) => ParseDouble(value);
        public static explicit operator ucfix64(float value) => new ucfix64(CheckedCast.ToUInt64(value * ScalingFactor));
        public static explicit operator ucfix64(int value) => new ucfix64(CheckedCast.ToUInt64(value) * ScalingFactor);
        public static explicit operator ucfix64(long value) => new ucfix64(CheckedCast.ToUInt64(value) * ScalingFactor);
        public static explicit operator ucfix64(sbyte value) => new ucfix64(CheckedCast.ToUInt64(value) * ScalingFactor);
        public static explicit operator ucfix64(short value) => new ucfix64(CheckedCast.ToUInt64(value) * ScalingFactor);
        public static explicit operator ucfix64(ulong value) => new ucfix64(value * ScalingFactor);
        public static implicit operator ucfix64(byte value) => new ucfix64(value * ScalingFactor);
        public static implicit operator ucfix64(char value) => new ucfix64(value * ScalingFactor);
        public static implicit operator ucfix64(uint value) => new ucfix64(CheckedCast.ToUInt64(value) * ScalingFactor);
        public static implicit operator ucfix64(ushort value) => new ucfix64(CheckedCast.ToUInt64(value) * ScalingFactor);

        public static explicit operator byte(ucfix64 value) => CheckedCast.ToByte(value._scaledValue / ScalingFactor);
        public static explicit operator char(ucfix64 value) => CheckedCast.ToChar(value._scaledValue / ScalingFactor);
        public static explicit operator decimal(ucfix64 value) => (decimal)value._scaledValue / ScalingFactor;
        public static explicit operator double(ucfix64 value) => (double)value._scaledValue / ScalingFactor;
        public static explicit operator float(ucfix64 value) => (float)value._scaledValue / ScalingFactor;
        public static explicit operator int(ucfix64 value) => CheckedCast.ToInt32(value._scaledValue / ScalingFactor);
        public static explicit operator long(ucfix64 value) => CheckedCast.ToInt64(value._scaledValue / ScalingFactor);
        public static explicit operator sbyte(ucfix64 value) => CheckedCast.ToSByte(value._scaledValue / ScalingFactor);
        public static explicit operator short(ucfix64 value) => CheckedCast.ToInt16(value._scaledValue / ScalingFactor);
        public static explicit operator uint(ucfix64 value) => CheckedCast.ToUInt32(value._scaledValue / ScalingFactor);
        public static explicit operator ulong(ucfix64 value) => value._scaledValue / ScalingFactor;
        public static explicit operator ushort(ucfix64 value) => CheckedCast.ToUInt16(value._scaledValue / ScalingFactor);

        public static bool operator !=(ucfix64 left, ucfix64 right) => left._scaledValue != right._scaledValue;
        public static bool operator <(ucfix64 left, ucfix64 right) => left._scaledValue < right._scaledValue;
        public static bool operator <=(ucfix64 left, ucfix64 right) => left._scaledValue <= right._scaledValue;
        public static bool operator ==(ucfix64 left, ucfix64 right) => left._scaledValue == right._scaledValue;
        public static bool operator >(ucfix64 left, ucfix64 right) => left._scaledValue > right._scaledValue;
        public static bool operator >=(ucfix64 left, ucfix64 right) => left._scaledValue >= right._scaledValue;
        public static ucfix64 operator %(ucfix64 left, ucfix64 right) => new ucfix64(CheckedArithmetic.Remainder(left._scaledValue, right._scaledValue));
        public static ucfix64 operator &(ucfix64 left, ucfix64 right) => new ucfix64(left._scaledValue & right._scaledValue);
        public static ucfix64 operator -(ucfix64 _) => 0;
        public static ucfix64 operator -(ucfix64 left, ucfix64 right) => new ucfix64(CheckedArithmetic.Subtract(left._scaledValue, right._scaledValue));
        public static ucfix64 operator --(ucfix64 value) => new ucfix64(value._scaledValue - ScalingFactor);
        public static ucfix64 operator *(ucfix64 left, ucfix64 right) => new ucfix64(CheckedArithmetic.ScaledMultiply(left._scaledValue, right._scaledValue, ScalingFactor));
        public static ucfix64 operator /(ucfix64 left, ucfix64 right) => new ucfix64(CheckedArithmetic.ScaledDivide(left._scaledValue, right._scaledValue, ScalingFactor));
        public static ucfix64 operator ^(ucfix64 left, ucfix64 right) => new ucfix64(left._scaledValue ^ right._scaledValue);
        public static ucfix64 operator |(ucfix64 left, ucfix64 right) => new ucfix64(left._scaledValue | right._scaledValue);
        public static ucfix64 operator ~(ucfix64 value) => new ucfix64(~value._scaledValue);
        public static ucfix64 operator +(ucfix64 left, ucfix64 right) => new ucfix64(CheckedArithmetic.Add(left._scaledValue, right._scaledValue));
        public static ucfix64 operator +(ucfix64 value) => value;
        public static ucfix64 operator ++(ucfix64 value) => new ucfix64(value._scaledValue + ScalingFactor);
        public static ucfix64 operator <<(ucfix64 left, int right) => new ucfix64(left._scaledValue << right);
        public static ucfix64 operator >>(ucfix64 left, int right) => new ucfix64(left._scaledValue >> right);

        bool INumeric<ucfix64>.IsGreaterThan(ucfix64 value) => this > value;
        bool INumeric<ucfix64>.IsGreaterThanOrEqualTo(ucfix64 value) => this >= value;
        bool INumeric<ucfix64>.IsLessThan(ucfix64 value) => this < value;
        bool INumeric<ucfix64>.IsLessThanOrEqualTo(ucfix64 value) => this <= value;
        ucfix64 INumeric<ucfix64>.Add(ucfix64 value) => this + value;
        ucfix64 INumeric<ucfix64>.BitwiseComplement() => ~this;
        ucfix64 INumeric<ucfix64>.Divide(ucfix64 value) => this / value;
        ucfix64 INumeric<ucfix64>.LeftShift(int count) => this << count;
        ucfix64 INumeric<ucfix64>.LogicalAnd(ucfix64 value) => this & value;
        ucfix64 INumeric<ucfix64>.LogicalExclusiveOr(ucfix64 value) => this ^ value;
        ucfix64 INumeric<ucfix64>.LogicalOr(ucfix64 value) => this | value;
        ucfix64 INumeric<ucfix64>.Multiply(ucfix64 value) => this * value;
        ucfix64 INumeric<ucfix64>.Negative() => -this;
        ucfix64 INumeric<ucfix64>.Positive() => +this;
        ucfix64 INumeric<ucfix64>.Remainder(ucfix64 value) => this % value;
        ucfix64 INumeric<ucfix64>.RightShift(int count) => this >> count;
        ucfix64 INumeric<ucfix64>.Subtract(ucfix64 value) => this - value;

        IBitConverter<ucfix64> IBitConvertible<ucfix64>.BitConverter => Utilities.Instance;
        ICast<ucfix64> INumeric<ucfix64>.Cast => Utilities.Instance;
        IConvert<ucfix64> IConvertible<ucfix64>.Convert => Utilities.Instance;
        IMath<ucfix64> INumeric<ucfix64>.Math => Utilities.Instance;
        INumericFunctions<ucfix64> INumeric<ucfix64>.NumericFunctions => Utilities.Instance;
        IRandom<ucfix64> IRandomisable<ucfix64>.Random => Utilities.Instance;
        IStringParser<ucfix64> IStringParsable<ucfix64>.StringParser => Utilities.Instance;

        private sealed class Utilities :
            IBitConverter<ucfix64>,
            ICast<ucfix64>,
            IConvert<ucfix64>,
            IMath<ucfix64>,
            INumericFunctions<ucfix64>,
            IRandom<ucfix64>,
            IStringParser<ucfix64>
        {
            public readonly static Utilities Instance = new Utilities();

            bool INumericFunctions<ucfix64>.HasFloatingPoint { get; } = false;
            bool INumericFunctions<ucfix64>.IsReal { get; } = true;
            bool INumericFunctions<ucfix64>.IsSigned { get; } = false;
            ucfix64 IMath<ucfix64>.E { get; } = (ucfix64)Math.E;
            ucfix64 INumericFunctions<ucfix64>.Epsilon { get; } = new ucfix64(1);
            ucfix64 INumericFunctions<ucfix64>.MaxUnit { get; } = new ucfix64(ScalingFactor);
            ucfix64 INumericFunctions<ucfix64>.MaxValue => MaxValue;
            ucfix64 INumericFunctions<ucfix64>.MinUnit { get; } = 0;
            ucfix64 INumericFunctions<ucfix64>.MinValue => MinValue;
            ucfix64 INumericFunctions<ucfix64>.One { get; } = new ucfix64(ScalingFactor);
            ucfix64 IMath<ucfix64>.PI { get; } = (ucfix64)Math.PI;
            ucfix64 IMath<ucfix64>.Tau { get; } = (ucfix64)(Math.PI * 2d);
            ucfix64 INumericFunctions<ucfix64>.Ten { get; } = new ucfix64(10 * ScalingFactor);
            ucfix64 INumericFunctions<ucfix64>.Two { get; } = new ucfix64(2 * ScalingFactor);
            ucfix64 INumericFunctions<ucfix64>.Zero { get; } = 0;

            int IMath<ucfix64>.Sign(ucfix64 x) => x._scaledValue == 0 ? 0 : 1;
            bool INumericFunctions<ucfix64>.IsFinite(ucfix64 x) => true;
            bool INumericFunctions<ucfix64>.IsInfinity(ucfix64 x) => false;
            bool INumericFunctions<ucfix64>.IsNaN(ucfix64 x) => false;
            bool INumericFunctions<ucfix64>.IsNegative(ucfix64 x) => false;
            bool INumericFunctions<ucfix64>.IsNegativeInfinity(ucfix64 x) => false;
            bool INumericFunctions<ucfix64>.IsNormal(ucfix64 x) => false;
            bool INumericFunctions<ucfix64>.IsPositiveInfinity(ucfix64 x) => false;
            bool INumericFunctions<ucfix64>.IsSubnormal(ucfix64 x) => false;

            ucfix64 IMath<ucfix64>.Abs(ucfix64 x) => x;
            ucfix64 IMath<ucfix64>.Acos(ucfix64 x) => (ucfix64)Math.Acos((double)x);
            ucfix64 IMath<ucfix64>.Acosh(ucfix64 x) => (ucfix64)Math.Acosh((double)x);
            ucfix64 IMath<ucfix64>.Asin(ucfix64 x) => (ucfix64)Math.Asin((double)x);
            ucfix64 IMath<ucfix64>.Asinh(ucfix64 x) => (ucfix64)Math.Asinh((double)x);
            ucfix64 IMath<ucfix64>.Atan(ucfix64 x) => (ucfix64)Math.Atan((double)x);
            ucfix64 IMath<ucfix64>.Atan2(ucfix64 x, ucfix64 y) => (ucfix64)Math.Atan2((double)x, (double)y);
            ucfix64 IMath<ucfix64>.Atanh(ucfix64 x) => (ucfix64)Math.Atanh((double)x);
            ucfix64 IMath<ucfix64>.Cbrt(ucfix64 x) => (ucfix64)Math.Cbrt((double)x);
            ucfix64 IMath<ucfix64>.Ceiling(ucfix64 x) => new ucfix64(CheckedArithmetic.ScaledCeiling(x._scaledValue, ScalingFactor));
            ucfix64 IMath<ucfix64>.Clamp(ucfix64 x, ucfix64 bound1, ucfix64 bound2) => bound1 > bound2 ? (ucfix64)Math.Min(bound1._scaledValue, Math.Max(bound2._scaledValue, x._scaledValue)) : (ucfix64)Math.Min(bound2._scaledValue, Math.Max(bound1._scaledValue, x._scaledValue));
            ucfix64 IMath<ucfix64>.Cos(ucfix64 x) => (ucfix64)Math.Cos((double)x);
            ucfix64 IMath<ucfix64>.Cosh(ucfix64 x) => (ucfix64)Math.Cosh((double)x);
            ucfix64 IMath<ucfix64>.DecimalTruncate(ucfix64 x, int significantDigits) => new ucfix64(Truncate.ToDigits(x._scaledValue, significantDigits));
            ucfix64 IMath<ucfix64>.DegreesToRadians(ucfix64 x) => (ucfix64)CheckedArithmetic.Multiply((double)x, Trig.RadiansPerDegree);
            ucfix64 IMath<ucfix64>.Exp(ucfix64 x) => (ucfix64)Math.Exp((double)x);
            ucfix64 IMath<ucfix64>.Floor(ucfix64 x) => new ucfix64(CheckedArithmetic.ScaledFloor(x._scaledValue, ScalingFactor));
            ucfix64 IMath<ucfix64>.IEEERemainder(ucfix64 x, ucfix64 y) => (ucfix64)Math.IEEERemainder((double)x, (double)y);
            ucfix64 IMath<ucfix64>.Log(ucfix64 x) => (ucfix64)Math.Log((double)x);
            ucfix64 IMath<ucfix64>.Log(ucfix64 x, ucfix64 y) => (ucfix64)Math.Log((double)x, (double)y);
            ucfix64 IMath<ucfix64>.Log10(ucfix64 x) => (ucfix64)Math.Log10((double)x);
            ucfix64 IMath<ucfix64>.Max(ucfix64 x, ucfix64 y) => new ucfix64(Math.Max(x._scaledValue, y._scaledValue));
            ucfix64 IMath<ucfix64>.Min(ucfix64 x, ucfix64 y) => new ucfix64(Math.Min(x._scaledValue, y._scaledValue));
            ucfix64 IMath<ucfix64>.Pow(ucfix64 x, ucfix64 y) => y == 1 ? x : (ucfix64)Math.Pow((double)x, (double)y);
            ucfix64 IMath<ucfix64>.RadiansToDegrees(ucfix64 x) => (ucfix64)CheckedArithmetic.Multiply((double)x, Trig.DegreesPerRadian);
            ucfix64 IMath<ucfix64>.Round(ucfix64 x) => Round(x, 0, MidpointRounding.ToEven);
            ucfix64 IMath<ucfix64>.Round(ucfix64 x, int digits) => Round(x, digits, MidpointRounding.ToEven);
            ucfix64 IMath<ucfix64>.Round(ucfix64 x, int digits, MidpointRounding mode) => Round(x, digits, mode);
            ucfix64 IMath<ucfix64>.Round(ucfix64 x, MidpointRounding mode) => Round(x, 0, mode);
            ucfix64 IMath<ucfix64>.Sin(ucfix64 x) => (ucfix64)Math.Sin((double)x);
            ucfix64 IMath<ucfix64>.Sinh(ucfix64 x) => (ucfix64)Math.Sinh((double)x);
            ucfix64 IMath<ucfix64>.Sqrt(ucfix64 x) => (ucfix64)Math.Sqrt((double)x);
            ucfix64 IMath<ucfix64>.Tan(ucfix64 x) => (ucfix64)Math.Tan((double)x);
            ucfix64 IMath<ucfix64>.Tanh(ucfix64 x) => (ucfix64)Math.Tanh((double)x);
            ucfix64 IMath<ucfix64>.Truncate(ucfix64 x) => new ucfix64(x._scaledValue / ScalingFactor * ScalingFactor);

            ucfix64 IBitConverter<ucfix64>.Read(IReadOnlyStream<byte> stream) => new ucfix64(BitConverter.ToUInt64(stream.Read(sizeof(ulong))));
            void IBitConverter<ucfix64>.Write(ucfix64 value, IWriteOnlyStream<byte> stream) => stream.Write(BitConverter.GetBytes(value._scaledValue));

            ucfix64 IRandom<ucfix64>.Next(Random random) => new ucfix64(random.NextUInt64());
            ucfix64 IRandom<ucfix64>.Next(Random random, ucfix64 bound1, ucfix64 bound2) => new ucfix64(random.NextUInt64(bound1._scaledValue, bound2._scaledValue));

            bool IConvert<ucfix64>.ToBoolean(ucfix64 value) => value._scaledValue != 0;
            byte IConvert<ucfix64>.ToByte(ucfix64 value) => CheckedConvert.ToByte(value._scaledValue / ScalingFactor);
            decimal IConvert<ucfix64>.ToDecimal(ucfix64 value) => (decimal)value._scaledValue / ScalingFactor;
            double IConvert<ucfix64>.ToDouble(ucfix64 value) => (double)value._scaledValue / ScalingFactor;
            float IConvert<ucfix64>.ToSingle(ucfix64 value) => (float)value._scaledValue / ScalingFactor;
            int IConvert<ucfix64>.ToInt32(ucfix64 value) => CheckedConvert.ToInt32(value._scaledValue / ScalingFactor);
            long IConvert<ucfix64>.ToInt64(ucfix64 value) => CheckedConvert.ToInt64(value._scaledValue / ScalingFactor);
            sbyte IConvert<ucfix64>.ToSByte(ucfix64 value) => CheckedConvert.ToSByte(value._scaledValue / ScalingFactor);
            short IConvert<ucfix64>.ToInt16(ucfix64 value) => CheckedConvert.ToInt16(value._scaledValue / ScalingFactor);
            string IConvert<ucfix64>.ToString(ucfix64 value) => value.ToString();
            string IConvert<ucfix64>.ToString(ucfix64 value, IFormatProvider provider) => value.ToString(provider);
            uint IConvert<ucfix64>.ToUInt32(ucfix64 value) => CheckedConvert.ToUInt32(value._scaledValue / ScalingFactor);
            ulong IConvert<ucfix64>.ToUInt64(ucfix64 value) => value._scaledValue / ScalingFactor;
            ushort IConvert<ucfix64>.ToUInt16(ucfix64 value) => CheckedConvert.ToUInt16(value._scaledValue / ScalingFactor);

            ucfix64 IConvert<ucfix64>.ToValue(bool value) => value ? new ucfix64(ScalingFactor) : new ucfix64(0);
            ucfix64 IConvert<ucfix64>.ToValue(byte value) => (ucfix64)CheckedConvert.ToUInt64(value);
            ucfix64 IConvert<ucfix64>.ToValue(decimal value) => (ucfix64)value;
            ucfix64 IConvert<ucfix64>.ToValue(double value) => (ucfix64)value;
            ucfix64 IConvert<ucfix64>.ToValue(float value) => (ucfix64)value;
            ucfix64 IConvert<ucfix64>.ToValue(int value) => (ucfix64)CheckedConvert.ToUInt64(value);
            ucfix64 IConvert<ucfix64>.ToValue(long value) => (ucfix64)value;
            ucfix64 IConvert<ucfix64>.ToValue(sbyte value) => (ucfix64)CheckedConvert.ToUInt64(value);
            ucfix64 IConvert<ucfix64>.ToValue(short value) => (ucfix64)CheckedConvert.ToUInt64(value);
            ucfix64 IConvert<ucfix64>.ToValue(string value) => (ucfix64)Convert.ToUInt64(value);
            ucfix64 IConvert<ucfix64>.ToValue(string value, IFormatProvider provider) => (ucfix64)Convert.ToUInt64(value, provider);
            ucfix64 IConvert<ucfix64>.ToValue(uint value) => (ucfix64)CheckedConvert.ToUInt64(value);
            ucfix64 IConvert<ucfix64>.ToValue(ulong value) => (ucfix64)value;
            ucfix64 IConvert<ucfix64>.ToValue(ushort value) => (ucfix64)CheckedConvert.ToUInt64(value);

            bool IStringParser<ucfix64>.TryParse(string s, IFormatProvider provider, out ucfix64 result) => TryParse(s, provider, out result);
            bool IStringParser<ucfix64>.TryParse(string s, NumberStyles style, IFormatProvider provider, out ucfix64 result) => TryParse(s, style, provider, out result);
            bool IStringParser<ucfix64>.TryParse(string s, NumberStyles style, out ucfix64 result) => TryParse(s, style, out result);
            bool IStringParser<ucfix64>.TryParse(string s, out ucfix64 result) => TryParse(s, out result);
            ucfix64 IStringParser<ucfix64>.Parse(string s) => Parse(s);
            ucfix64 IStringParser<ucfix64>.Parse(string s, IFormatProvider provider) => Parse(s, provider);
            ucfix64 IStringParser<ucfix64>.Parse(string s, NumberStyles style) => Parse(s, style);
            ucfix64 IStringParser<ucfix64>.Parse(string s, NumberStyles style, IFormatProvider provider) => Parse(s, style, provider);

            byte ICast<ucfix64>.ToByte(ucfix64 value) => (byte)value;
            decimal ICast<ucfix64>.ToDecimal(ucfix64 value) => (decimal)value;
            double ICast<ucfix64>.ToDouble(ucfix64 value) => (double)value;
            float ICast<ucfix64>.ToSingle(ucfix64 value) => (float)value;
            int ICast<ucfix64>.ToInt32(ucfix64 value) => (int)value;
            long ICast<ucfix64>.ToInt64(ucfix64 value) => (long)value;
            sbyte ICast<ucfix64>.ToSByte(ucfix64 value) => (sbyte)value;
            short ICast<ucfix64>.ToInt16(ucfix64 value) => (short)value;
            uint ICast<ucfix64>.ToUInt32(ucfix64 value) => (uint)value;
            ulong ICast<ucfix64>.ToUInt64(ucfix64 value) => (ulong)value;
            ushort ICast<ucfix64>.ToUInt16(ucfix64 value) => (ushort)value;

            ucfix64 ICast<ucfix64>.ToValue(byte value) => (ucfix64)value;
            ucfix64 ICast<ucfix64>.ToValue(decimal value) => (ucfix64)value;
            ucfix64 ICast<ucfix64>.ToValue(double value) => (ucfix64)value;
            ucfix64 ICast<ucfix64>.ToValue(float value) => (ucfix64)value;
            ucfix64 ICast<ucfix64>.ToValue(int value) => (ucfix64)value;
            ucfix64 ICast<ucfix64>.ToValue(long value) => (ucfix64)value;
            ucfix64 ICast<ucfix64>.ToValue(sbyte value) => (ucfix64)value;
            ucfix64 ICast<ucfix64>.ToValue(short value) => (ucfix64)value;
            ucfix64 ICast<ucfix64>.ToValue(uint value) => (ucfix64)value;
            ucfix64 ICast<ucfix64>.ToValue(ulong value) => (ucfix64)value;
            ucfix64 ICast<ucfix64>.ToValue(ushort value) => (ucfix64)value;
        }
    }
}
