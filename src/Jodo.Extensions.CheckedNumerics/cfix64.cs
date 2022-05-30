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
    public readonly struct cfix64 : INumeric<cfix64>
    {
        public static readonly cfix64 Epsilon = new cfix64(1);
        public static readonly cfix64 MaxValue = new cfix64(long.MaxValue);
        public static readonly cfix64 MinValue = new cfix64(long.MinValue);

        private const long ScalingFactor = 1_000_000;

        private readonly long _scaledValue;

        private cfix64(long scaledValue)
        {
            _scaledValue = scaledValue;
        }

        private cfix64(SerializationInfo info, StreamingContext context) : this(info.GetInt64(nameof(cfix64))) { }
        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context) => info.AddValue(nameof(cfix64), _scaledValue);

        public int CompareTo(cfix64 other) => _scaledValue.CompareTo(other._scaledValue);
        public int CompareTo(object? obj) => obj is cfix64 other ? CompareTo(other) : 1;
        public bool Equals(cfix64 other) => _scaledValue == other._scaledValue;
        public override bool Equals(object? obj) => obj is cfix64 other && Equals(other);
        public override int GetHashCode() => _scaledValue.GetHashCode();
        public override string ToString() => $"{_scaledValue}/{ScalingFactor}";
        public string ToString(IFormatProvider formatProvider) => $"{_scaledValue.ToString(formatProvider)}/{ScalingFactor.ToString(formatProvider)}";
        public string ToString(string format) => $"{_scaledValue.ToString(format)}/{ScalingFactor.ToString(format)}";
        public string ToString(string format, IFormatProvider formatProvider) => $"{_scaledValue.ToString(format, formatProvider)}/{ScalingFactor.ToString(format, formatProvider)}";

        public static bool TryParse(string s, IFormatProvider provider, out cfix64 result) => Try.Run(() => Parse(s, provider), out result);
        public static bool TryParse(string s, NumberStyles style, IFormatProvider provider, out cfix64 result) => Try.Run(() => Parse(s, style, provider), out result);
        public static bool TryParse(string s, NumberStyles style, out cfix64 result) => Try.Run(() => Parse(s, style), out result);
        public static bool TryParse(string s, out cfix64 result) => Try.Run(() => Parse(s), out result);
        public static cfix64 Parse(string s) => new cfix64(long.Parse(s.Substring(0, s.IndexOf("/"))));
        public static cfix64 Parse(string s, IFormatProvider provider) => new cfix64(long.Parse(s.Substring(0, s.IndexOf("/")), provider));
        public static cfix64 Parse(string s, NumberStyles style) => new cfix64(long.Parse(s.Substring(0, s.IndexOf("/")), style));
        public static cfix64 Parse(string s, NumberStyles style, IFormatProvider provider) => new cfix64(long.Parse(s.Substring(0, s.IndexOf("/")), style, provider));

        private static cfix64 Round(cfix64 value, int digits, MidpointRounding mode)
        {
            if (digits < 0) throw new ArgumentOutOfRangeException(nameof(digits), digits, "Must be positive.");
            if (digits > 5) return value;
            return new cfix64(Digits.Round(value._scaledValue, 6 - digits, mode));
        }

        private static cfix64 ParseDouble(double value)
        {
            string str = string.Format(CultureInfo.InvariantCulture, "{0:0.0000000}", value)
                            .Replace(".", string.Empty)[..^1];
            if (long.TryParse(str, out var lng))
            {
                return new cfix64(lng);
            }
            else
            {
                if (value > 0) return MaxValue;
                return MinValue;
            }
        }

        public static explicit operator cfix64(decimal value) => new cfix64(CheckedCast.ToInt64(value * ScalingFactor));
        public static explicit operator cfix64(double value) => ParseDouble(value);
        public static explicit operator cfix64(long value) => new cfix64(value * ScalingFactor);
        public static explicit operator cfix64(ulong value) => new cfix64(CheckedCast.ToInt64(value * ScalingFactor));
        public static implicit operator cfix64(byte value) => new cfix64(value * ScalingFactor);
        public static implicit operator cfix64(char value) => new cfix64(value * ScalingFactor);
        public static implicit operator cfix64(float value) => new cfix64(CheckedCast.ToInt64(value * ScalingFactor));
        public static implicit operator cfix64(int value) => new cfix64(value * ScalingFactor);
        public static implicit operator cfix64(sbyte value) => new cfix64(value * ScalingFactor);
        public static implicit operator cfix64(short value) => new cfix64(value * ScalingFactor);
        public static implicit operator cfix64(uint value) => new cfix64(value * ScalingFactor);
        public static implicit operator cfix64(ushort value) => new cfix64(value * ScalingFactor);

        public static explicit operator byte(cfix64 value) => CheckedCast.ToByte(value._scaledValue / ScalingFactor);
        public static explicit operator char(cfix64 value) => CheckedCast.ToChar(value._scaledValue / ScalingFactor);
        public static explicit operator decimal(cfix64 value) => (decimal)value._scaledValue / ScalingFactor;
        public static explicit operator double(cfix64 value) => (double)value._scaledValue / ScalingFactor;
        public static explicit operator float(cfix64 value) => (float)value._scaledValue / ScalingFactor;
        public static explicit operator int(cfix64 value) => CheckedCast.ToInt32(value._scaledValue / ScalingFactor);
        public static explicit operator long(cfix64 value) => value._scaledValue / ScalingFactor;
        public static explicit operator sbyte(cfix64 value) => CheckedCast.ToSByte(value._scaledValue / ScalingFactor);
        public static explicit operator short(cfix64 value) => CheckedCast.ToInt16(value._scaledValue / ScalingFactor);
        public static explicit operator uint(cfix64 value) => CheckedCast.ToUInt32(value._scaledValue / ScalingFactor);
        public static explicit operator ulong(cfix64 value) => CheckedCast.ToUInt64(value._scaledValue / ScalingFactor);
        public static explicit operator ushort(cfix64 value) => CheckedCast.ToUInt16(value._scaledValue / ScalingFactor);

        public static bool operator !=(cfix64 left, cfix64 right) => left._scaledValue != right._scaledValue;
        public static bool operator <(cfix64 left, cfix64 right) => left._scaledValue < right._scaledValue;
        public static bool operator <=(cfix64 left, cfix64 right) => left._scaledValue <= right._scaledValue;
        public static bool operator ==(cfix64 left, cfix64 right) => left._scaledValue == right._scaledValue;
        public static bool operator >(cfix64 left, cfix64 right) => left._scaledValue > right._scaledValue;
        public static bool operator >=(cfix64 left, cfix64 right) => left._scaledValue >= right._scaledValue;
        public static cfix64 operator %(cfix64 left, cfix64 right) => new cfix64(CheckedArithmetic.Remainder(left._scaledValue, right._scaledValue));
        public static cfix64 operator &(cfix64 left, cfix64 right) => new cfix64(left._scaledValue & right._scaledValue);
        public static cfix64 operator -(cfix64 left, cfix64 right) => new cfix64(CheckedArithmetic.Subtract(left._scaledValue, right._scaledValue));
        public static cfix64 operator --(cfix64 value) => new cfix64(value._scaledValue - ScalingFactor);
        public static cfix64 operator -(cfix64 value) => new cfix64(-value._scaledValue);
        public static cfix64 operator *(cfix64 left, cfix64 right) => new cfix64(CheckedArithmetic.ScaledMultiply(left._scaledValue, right._scaledValue, ScalingFactor));
        public static cfix64 operator /(cfix64 left, cfix64 right) => new cfix64(CheckedArithmetic.ScaledDivide(left._scaledValue, right._scaledValue, ScalingFactor));
        public static cfix64 operator ^(cfix64 left, cfix64 right) => new cfix64(left._scaledValue ^ right._scaledValue);
        public static cfix64 operator |(cfix64 left, cfix64 right) => new cfix64(left._scaledValue | right._scaledValue);
        public static cfix64 operator ~(cfix64 value) => new cfix64(~value._scaledValue);
        public static cfix64 operator +(cfix64 left, cfix64 right) => new cfix64(CheckedArithmetic.Add(left._scaledValue, right._scaledValue));
        public static cfix64 operator +(cfix64 value) => value;
        public static cfix64 operator ++(cfix64 value) => new cfix64(value._scaledValue + ScalingFactor);
        public static cfix64 operator <<(cfix64 left, int right) => new cfix64(left._scaledValue << right);
        public static cfix64 operator >>(cfix64 left, int right) => new cfix64(left._scaledValue >> right);

        bool INumeric<cfix64>.IsGreaterThan(cfix64 value) => this > value;
        bool INumeric<cfix64>.IsGreaterThanOrEqualTo(cfix64 value) => this >= value;
        bool INumeric<cfix64>.IsLessThan(cfix64 value) => this < value;
        bool INumeric<cfix64>.IsLessThanOrEqualTo(cfix64 value) => this <= value;
        cfix64 INumeric<cfix64>.Add(cfix64 value) => this + value;
        cfix64 INumeric<cfix64>.BitwiseComplement() => ~this;
        cfix64 INumeric<cfix64>.Divide(cfix64 value) => this / value;
        cfix64 INumeric<cfix64>.LeftShift(int count) => this << count;
        cfix64 INumeric<cfix64>.LogicalAnd(cfix64 value) => this & value;
        cfix64 INumeric<cfix64>.LogicalExclusiveOr(cfix64 value) => this ^ value;
        cfix64 INumeric<cfix64>.LogicalOr(cfix64 value) => this | value;
        cfix64 INumeric<cfix64>.Multiply(cfix64 value) => this * value;
        cfix64 INumeric<cfix64>.Negative() => -this;
        cfix64 INumeric<cfix64>.Positive() => +this;
        cfix64 INumeric<cfix64>.Remainder(cfix64 value) => this % value;
        cfix64 INumeric<cfix64>.RightShift(int count) => this >> count;
        cfix64 INumeric<cfix64>.Subtract(cfix64 value) => this - value;

        IBitConverter<cfix64> IBitConvertible<cfix64>.BitConverter => Utilities.Instance;
        ICast<cfix64> INumeric<cfix64>.Cast => Utilities.Instance;
        IConvert<cfix64> IConvertible<cfix64>.Convert => Utilities.Instance;
        IMath<cfix64> INumeric<cfix64>.Math => Utilities.Instance;
        INumericFunctions<cfix64> INumeric<cfix64>.NumericFunctions => Utilities.Instance;
        IRandom<cfix64> IRandomisable<cfix64>.Random => Utilities.Instance;
        IStringParser<cfix64> IStringParsable<cfix64>.StringParser => Utilities.Instance;

        private sealed class Utilities :
            IBitConverter<cfix64>,
            ICast<cfix64>,
            IConvert<cfix64>,
            IMath<cfix64>,
            INumericFunctions<cfix64>,
            IRandom<cfix64>,
            IStringParser<cfix64>
        {
            public readonly static Utilities Instance = new Utilities();

            bool INumericFunctions<cfix64>.HasFloatingPoint { get; } = false;
            bool INumericFunctions<cfix64>.IsReal { get; } = true;
            bool INumericFunctions<cfix64>.IsSigned { get; } = true;
            cfix64 IMath<cfix64>.E { get; } = (cfix64)Math.E;
            cfix64 INumericFunctions<cfix64>.Epsilon { get; } = new cfix64(1);
            cfix64 INumericFunctions<cfix64>.MaxUnit { get; } = new cfix64(ScalingFactor);
            cfix64 INumericFunctions<cfix64>.MaxValue => MaxValue;
            cfix64 INumericFunctions<cfix64>.MinUnit { get; } = new cfix64(-ScalingFactor);
            cfix64 INumericFunctions<cfix64>.MinValue => MinValue;
            cfix64 INumericFunctions<cfix64>.One { get; } = new cfix64(ScalingFactor);
            cfix64 IMath<cfix64>.PI { get; } = (cfix64)Math.PI;
            cfix64 IMath<cfix64>.Tau { get; } = (cfix64)(Math.PI * 2d);
            cfix64 INumericFunctions<cfix64>.Ten { get; } = new cfix64(10 * ScalingFactor);
            cfix64 INumericFunctions<cfix64>.Two { get; } = new cfix64(2 * ScalingFactor);
            cfix64 INumericFunctions<cfix64>.Zero { get; } = 0;

            int IMath<cfix64>.Sign(cfix64 x) => x._scaledValue == 0 ? 0 : 1;
            bool INumericFunctions<cfix64>.IsFinite(cfix64 x) => true;
            bool INumericFunctions<cfix64>.IsInfinity(cfix64 x) => false;
            bool INumericFunctions<cfix64>.IsNaN(cfix64 x) => false;
            bool INumericFunctions<cfix64>.IsNegative(cfix64 x) => x._scaledValue < 0;
            bool INumericFunctions<cfix64>.IsNegativeInfinity(cfix64 x) => false;
            bool INumericFunctions<cfix64>.IsNormal(cfix64 x) => false;
            bool INumericFunctions<cfix64>.IsPositiveInfinity(cfix64 x) => false;
            bool INumericFunctions<cfix64>.IsSubnormal(cfix64 x) => false;

            cfix64 IMath<cfix64>.Abs(cfix64 x) => x._scaledValue < 0 ? -x : x;
            cfix64 IMath<cfix64>.Acos(cfix64 x) => (cfix64)Math.Acos((double)x);
            cfix64 IMath<cfix64>.Acosh(cfix64 x) => (cfix64)Math.Acosh((double)x);
            cfix64 IMath<cfix64>.Asin(cfix64 x) => (cfix64)Math.Asin((double)x);
            cfix64 IMath<cfix64>.Asinh(cfix64 x) => (cfix64)Math.Asinh((double)x);
            cfix64 IMath<cfix64>.Atan(cfix64 x) => (cfix64)Math.Atan((double)x);
            cfix64 IMath<cfix64>.Atan2(cfix64 x, cfix64 y) => (cfix64)Math.Atan2((double)x, (double)y);
            cfix64 IMath<cfix64>.Atanh(cfix64 x) => (cfix64)Math.Atanh((double)x);
            cfix64 IMath<cfix64>.Cbrt(cfix64 x) => (cfix64)Math.Cbrt((double)x);
            cfix64 IMath<cfix64>.Ceiling(cfix64 x) => new cfix64(CheckedArithmetic.ScaledCeiling(x._scaledValue, ScalingFactor));
            cfix64 IMath<cfix64>.Clamp(cfix64 x, cfix64 bound1, cfix64 bound2) => bound1 > bound2 ? Math.Min(bound1._scaledValue, Math.Max(bound2._scaledValue, x._scaledValue)) : Math.Min(bound2._scaledValue, Math.Max(bound1._scaledValue, x._scaledValue));
            cfix64 IMath<cfix64>.Cos(cfix64 x) => (cfix64)Math.Cos((double)x);
            cfix64 IMath<cfix64>.Cosh(cfix64 x) => (cfix64)Math.Cosh((double)x);
            cfix64 IMath<cfix64>.DecimalTruncate(cfix64 x, int significantDigits) => new cfix64(Digits.Truncate(x._scaledValue, significantDigits));
            cfix64 IMath<cfix64>.DegreesToRadians(cfix64 x) => (cfix64)CheckedArithmetic.Multiply((double)x, Trig.RadiansPerDegree);
            cfix64 IMath<cfix64>.Exp(cfix64 x) => (cfix64)Math.Exp((double)x);
            cfix64 IMath<cfix64>.Floor(cfix64 x) => new cfix64(CheckedArithmetic.ScaledFloor(x._scaledValue, ScalingFactor));
            cfix64 IMath<cfix64>.IEEERemainder(cfix64 x, cfix64 y) => (cfix64)Math.IEEERemainder((double)x, (double)y);
            cfix64 IMath<cfix64>.Log(cfix64 x) => (cfix64)Math.Log((double)x);
            cfix64 IMath<cfix64>.Log(cfix64 x, cfix64 y) => (cfix64)Math.Log((double)x, (double)y);
            cfix64 IMath<cfix64>.Log10(cfix64 x) => (cfix64)Math.Log10((double)x);
            cfix64 IMath<cfix64>.Max(cfix64 x, cfix64 y) => new cfix64(Math.Max(x._scaledValue, y._scaledValue));
            cfix64 IMath<cfix64>.Min(cfix64 x, cfix64 y) => new cfix64(Math.Min(x._scaledValue, y._scaledValue));
            cfix64 IMath<cfix64>.Pow(cfix64 x, cfix64 y) => y == 1 ? x : (cfix64)Math.Pow((double)x, (double)y);
            cfix64 IMath<cfix64>.RadiansToDegrees(cfix64 x) => (cfix64)CheckedArithmetic.Multiply((double)x, Trig.DegreesPerRadian);
            cfix64 IMath<cfix64>.Round(cfix64 x) => Round(x, 0, MidpointRounding.ToEven);
            cfix64 IMath<cfix64>.Round(cfix64 x, int digits) => Round(x, digits, MidpointRounding.ToEven);
            cfix64 IMath<cfix64>.Round(cfix64 x, int digits, MidpointRounding mode) => Round(x, digits, mode);
            cfix64 IMath<cfix64>.Round(cfix64 x, MidpointRounding mode) => Round(x, 0, mode);
            cfix64 IMath<cfix64>.Sin(cfix64 x) => (cfix64)Math.Sin((double)x);
            cfix64 IMath<cfix64>.Sinh(cfix64 x) => (cfix64)Math.Sinh((double)x);
            cfix64 IMath<cfix64>.Sqrt(cfix64 x) => (cfix64)Math.Sqrt((double)x);
            cfix64 IMath<cfix64>.Tan(cfix64 x) => (cfix64)Math.Tan((double)x);
            cfix64 IMath<cfix64>.Tanh(cfix64 x) => (cfix64)Math.Tanh((double)x);
            cfix64 IMath<cfix64>.Truncate(cfix64 x) => new cfix64(x._scaledValue / ScalingFactor * ScalingFactor);

            cfix64 IBitConverter<cfix64>.Read(IReadOnlyStream<byte> stream) => new cfix64(BitConverter.ToInt64(stream.Read(sizeof(long))));
            void IBitConverter<cfix64>.Write(cfix64 value, IWriteOnlyStream<byte> stream) => stream.Write(BitConverter.GetBytes(value._scaledValue));

            cfix64 IRandom<cfix64>.Next(Random random) => new cfix64(random.NextInt64());
            cfix64 IRandom<cfix64>.Next(Random random, cfix64 bound1, cfix64 bound2) => new cfix64(random.NextInt64(bound1._scaledValue, bound2._scaledValue));

            bool IConvert<cfix64>.ToBoolean(cfix64 value) => value._scaledValue != 0;
            byte IConvert<cfix64>.ToByte(cfix64 value) => CheckedConvert.ToByte(value._scaledValue / ScalingFactor);
            decimal IConvert<cfix64>.ToDecimal(cfix64 value) => (decimal)value._scaledValue / ScalingFactor;
            double IConvert<cfix64>.ToDouble(cfix64 value) => (double)value._scaledValue / ScalingFactor;
            float IConvert<cfix64>.ToSingle(cfix64 value) => (float)value._scaledValue / ScalingFactor;
            int IConvert<cfix64>.ToInt32(cfix64 value) => CheckedConvert.ToInt32(value._scaledValue / ScalingFactor);
            long IConvert<cfix64>.ToInt64(cfix64 value) => value._scaledValue / ScalingFactor;
            sbyte IConvert<cfix64>.ToSByte(cfix64 value) => CheckedConvert.ToSByte(value._scaledValue / ScalingFactor);
            short IConvert<cfix64>.ToInt16(cfix64 value) => CheckedConvert.ToInt16(value._scaledValue / ScalingFactor);
            string IConvert<cfix64>.ToString(cfix64 value) => value.ToString();
            string IConvert<cfix64>.ToString(cfix64 value, IFormatProvider provider) => value.ToString(provider);
            uint IConvert<cfix64>.ToUInt32(cfix64 value) => CheckedConvert.ToUInt32(value._scaledValue / ScalingFactor);
            ulong IConvert<cfix64>.ToUInt64(cfix64 value) => CheckedConvert.ToUInt64(value._scaledValue / ScalingFactor);
            ushort IConvert<cfix64>.ToUInt16(cfix64 value) => CheckedConvert.ToUInt16(value._scaledValue / ScalingFactor);

            cfix64 IConvert<cfix64>.ToValue(bool value) => value ? ScalingFactor : 0;
            cfix64 IConvert<cfix64>.ToValue(byte value) => (cfix64)CheckedConvert.ToInt64(value);
            cfix64 IConvert<cfix64>.ToValue(decimal value) => (cfix64)value;
            cfix64 IConvert<cfix64>.ToValue(double value) => (cfix64)value;
            cfix64 IConvert<cfix64>.ToValue(float value) => value;
            cfix64 IConvert<cfix64>.ToValue(int value) => (cfix64)CheckedConvert.ToInt64(value);
            cfix64 IConvert<cfix64>.ToValue(long value) => (cfix64)value;
            cfix64 IConvert<cfix64>.ToValue(sbyte value) => (cfix64)CheckedConvert.ToInt64(value);
            cfix64 IConvert<cfix64>.ToValue(short value) => (cfix64)CheckedConvert.ToInt64(value);
            cfix64 IConvert<cfix64>.ToValue(string value) => (cfix64)Convert.ToInt64(value);
            cfix64 IConvert<cfix64>.ToValue(string value, IFormatProvider provider) => Convert.ToInt64(value, provider);
            cfix64 IConvert<cfix64>.ToValue(uint value) => (cfix64)CheckedConvert.ToInt64(value);
            cfix64 IConvert<cfix64>.ToValue(ulong value) => (cfix64)CheckedConvert.ToInt64(value);
            cfix64 IConvert<cfix64>.ToValue(ushort value) => (cfix64)CheckedConvert.ToInt64(value);

            bool IStringParser<cfix64>.TryParse(string s, IFormatProvider provider, out cfix64 result) => TryParse(s, provider, out result);
            bool IStringParser<cfix64>.TryParse(string s, NumberStyles style, IFormatProvider provider, out cfix64 result) => TryParse(s, style, provider, out result);
            bool IStringParser<cfix64>.TryParse(string s, NumberStyles style, out cfix64 result) => TryParse(s, style, out result);
            bool IStringParser<cfix64>.TryParse(string s, out cfix64 result) => TryParse(s, out result);
            cfix64 IStringParser<cfix64>.Parse(string s) => Parse(s);
            cfix64 IStringParser<cfix64>.Parse(string s, IFormatProvider provider) => Parse(s, provider);
            cfix64 IStringParser<cfix64>.Parse(string s, NumberStyles style) => Parse(s, style);
            cfix64 IStringParser<cfix64>.Parse(string s, NumberStyles style, IFormatProvider provider) => Parse(s, style, provider);

            byte ICast<cfix64>.ToByte(cfix64 value) => (byte)value;
            decimal ICast<cfix64>.ToDecimal(cfix64 value) => (decimal)value;
            double ICast<cfix64>.ToDouble(cfix64 value) => (double)value;
            float ICast<cfix64>.ToSingle(cfix64 value) => (float)value;
            int ICast<cfix64>.ToInt32(cfix64 value) => (int)value;
            long ICast<cfix64>.ToInt64(cfix64 value) => (long)value;
            sbyte ICast<cfix64>.ToSByte(cfix64 value) => (sbyte)value;
            short ICast<cfix64>.ToInt16(cfix64 value) => (short)value;
            uint ICast<cfix64>.ToUInt32(cfix64 value) => (uint)value;
            ulong ICast<cfix64>.ToUInt64(cfix64 value) => (ulong)value;
            ushort ICast<cfix64>.ToUInt16(cfix64 value) => (ushort)value;

            cfix64 ICast<cfix64>.ToValue(byte value) => (cfix64)value;
            cfix64 ICast<cfix64>.ToValue(decimal value) => (cfix64)value;
            cfix64 ICast<cfix64>.ToValue(double value) => (cfix64)value;
            cfix64 ICast<cfix64>.ToValue(float value) => (cfix64)value;
            cfix64 ICast<cfix64>.ToValue(int value) => (cfix64)value;
            cfix64 ICast<cfix64>.ToValue(long value) => (cfix64)value;
            cfix64 ICast<cfix64>.ToValue(sbyte value) => (cfix64)value;
            cfix64 ICast<cfix64>.ToValue(short value) => (cfix64)value;
            cfix64 ICast<cfix64>.ToValue(uint value) => (cfix64)value;
            cfix64 ICast<cfix64>.ToValue(ulong value) => (cfix64)value;
            cfix64 ICast<cfix64>.ToValue(ushort value) => (cfix64)value;
        }
    }
}
