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
    public readonly struct fix64 : INumeric<fix64>
    {
        public static readonly fix64 Epsilon = new fix64(1);
        public static readonly fix64 MaxValue = new fix64(long.MaxValue);
        public static readonly fix64 MinValue = new fix64(long.MinValue);

        private const long ScalingFactor = 1_000_000;

        private readonly long _scaledValue;

        private fix64(long scaledValue)
        {
            _scaledValue = scaledValue;
        }

        private fix64(SerializationInfo info, StreamingContext context) : this(info.GetInt64(nameof(fix64))) { }
        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context) => info.AddValue(nameof(fix64), _scaledValue);

        public int CompareTo(fix64 other) => _scaledValue.CompareTo(other._scaledValue);
        public int CompareTo(object? obj) => obj is fix64 other ? CompareTo(other) : 1;
        public bool Equals(fix64 other) => _scaledValue == other._scaledValue;
        public override bool Equals(object? obj) => obj is fix64 other && Equals(other);
        public override int GetHashCode() => _scaledValue.GetHashCode();
        public override string ToString() => ScaledArithmetic.ToString(_scaledValue, ScalingFactor);
        public string ToString(IFormatProvider formatProvider) => ((double)this).ToString(formatProvider);
        public string ToString(string format) => ((double)this).ToString(format);
        public string ToString(string format, IFormatProvider formatProvider) => ((double)this).ToString(format, formatProvider);

        public static bool TryParse(string s, IFormatProvider? provider, out fix64 result) => Try.Run(() => Parse(s, provider), out result);
        public static bool TryParse(string s, NumberStyles style, IFormatProvider? provider, out fix64 result) => Try.Run(() => Parse(s, style, provider), out result);
        public static bool TryParse(string s, NumberStyles style, out fix64 result) => Try.Run(() => Parse(s, style), out result);
        public static bool TryParse(string s, out fix64 result) => Try.Run(() => Parse(s), out result);
        public static fix64 Parse(string s) => new fix64(ScaledArithmetic.Parse(s, ScalingFactor));
        public static fix64 Parse(string s, IFormatProvider? provider) => (fix64)double.Parse(s, provider);
        public static fix64 Parse(string s, NumberStyles style) => (fix64)double.Parse(s, style);
        public static fix64 Parse(string s, NumberStyles style, IFormatProvider? provider) => (fix64)double.Parse(s, style, provider);

        private static fix64 Round(fix64 value, int digits, MidpointRounding mode)
        {
            if (digits < 0) throw new ArgumentOutOfRangeException(nameof(digits), digits, "Must be positive.");
            if (digits > 5) return value;
            return new fix64(ScaledArithmetic.Round(value._scaledValue, 6 - digits, mode));
        }

        private static fix64 FromDouble(double value)
        {
            string str = string
                .Format(CultureInfo.InvariantCulture, "{0:0.0000000}", value)
                .Replace(".", string.Empty)
                [..^1];
            if (long.TryParse(str, out var lng))
            {
                return new fix64(lng);
            }
            else
            {
                if (value > 0) return MaxValue;
                return MinValue;
            }
        }

        private static double ToDouble(fix64 value)
        {
            var integral = value._scaledValue / ScalingFactor;
            var mantissa = value._scaledValue % ScalingFactor;

            var result = (double)mantissa / ScalingFactor;
            result += integral;
            return result;
        }

        public static explicit operator fix64(decimal value) => new fix64((long)(value * ScalingFactor));
        public static explicit operator fix64(double value) => FromDouble(value);
        public static explicit operator fix64(long value) => new fix64(value * ScalingFactor);
        public static explicit operator fix64(ulong value) => new fix64((long)(value * ScalingFactor));
        public static implicit operator fix64(byte value) => new fix64(value * ScalingFactor);
        public static implicit operator fix64(float value) => new fix64((long)(value * ScalingFactor));
        public static implicit operator fix64(int value) => new fix64(value * ScalingFactor);
        public static implicit operator fix64(sbyte value) => new fix64(value * ScalingFactor);
        public static implicit operator fix64(short value) => new fix64(value * ScalingFactor);
        public static implicit operator fix64(uint value) => new fix64(value * ScalingFactor);
        public static implicit operator fix64(ushort value) => new fix64(value * ScalingFactor);

        public static explicit operator byte(fix64 value) => (byte)(value._scaledValue / ScalingFactor);
        public static explicit operator decimal(fix64 value) => (decimal)value._scaledValue / ScalingFactor;
        public static explicit operator double(fix64 value) => ToDouble(value);
        public static explicit operator float(fix64 value) => (float)value._scaledValue / ScalingFactor;
        public static explicit operator int(fix64 value) => (int)(value._scaledValue / ScalingFactor);
        public static explicit operator long(fix64 value) => value._scaledValue / ScalingFactor;
        public static explicit operator sbyte(fix64 value) => (sbyte)(value._scaledValue / ScalingFactor);
        public static explicit operator short(fix64 value) => (short)(value._scaledValue / ScalingFactor);
        public static explicit operator uint(fix64 value) => (uint)(value._scaledValue / ScalingFactor);
        public static explicit operator ulong(fix64 value) => (ulong)(value._scaledValue / ScalingFactor);
        public static explicit operator ushort(fix64 value) => (ushort)(value._scaledValue / ScalingFactor);

        public static bool operator !=(fix64 left, fix64 right) => left._scaledValue != right._scaledValue;
        public static bool operator <(fix64 left, fix64 right) => left._scaledValue < right._scaledValue;
        public static bool operator <=(fix64 left, fix64 right) => left._scaledValue <= right._scaledValue;
        public static bool operator ==(fix64 left, fix64 right) => left._scaledValue == right._scaledValue;
        public static bool operator >(fix64 left, fix64 right) => left._scaledValue > right._scaledValue;
        public static bool operator >=(fix64 left, fix64 right) => left._scaledValue >= right._scaledValue;
        public static fix64 operator %(fix64 left, fix64 right) => new fix64(left._scaledValue % right._scaledValue);
        public static fix64 operator &(fix64 left, fix64 right) => new fix64(left._scaledValue & right._scaledValue);
        public static fix64 operator -(fix64 left, fix64 right) => new fix64(left._scaledValue - right._scaledValue);
        public static fix64 operator --(fix64 value) => new fix64(value._scaledValue - ScalingFactor);
        public static fix64 operator -(fix64 value) => new fix64(-value._scaledValue);
        public static fix64 operator *(fix64 left, fix64 right) => new fix64(ScaledArithmetic.Multiply(left._scaledValue, right._scaledValue, ScalingFactor));
        public static fix64 operator /(fix64 left, fix64 right) => new fix64(ScaledArithmetic.Divide(left._scaledValue, right._scaledValue, ScalingFactor));
        public static fix64 operator ^(fix64 left, fix64 right) => new fix64(left._scaledValue ^ right._scaledValue);
        public static fix64 operator |(fix64 left, fix64 right) => new fix64(left._scaledValue | right._scaledValue);
        public static fix64 operator ~(fix64 value) => new fix64(~value._scaledValue);
        public static fix64 operator +(fix64 left, fix64 right) => new fix64(left._scaledValue + right._scaledValue);
        public static fix64 operator +(fix64 value) => value;
        public static fix64 operator ++(fix64 value) => new fix64(value._scaledValue + ScalingFactor);
        public static fix64 operator <<(fix64 left, int right) => new fix64(left._scaledValue << right);
        public static fix64 operator >>(fix64 left, int right) => new fix64(left._scaledValue >> right);

        bool INumeric<fix64>.IsGreaterThan(fix64 value) => this > value;
        bool INumeric<fix64>.IsGreaterThanOrEqualTo(fix64 value) => this >= value;
        bool INumeric<fix64>.IsLessThan(fix64 value) => this < value;
        bool INumeric<fix64>.IsLessThanOrEqualTo(fix64 value) => this <= value;
        fix64 INumeric<fix64>.Add(fix64 value) => this + value;
        fix64 INumeric<fix64>.BitwiseComplement() => ~this;
        fix64 INumeric<fix64>.Divide(fix64 value) => this / value;
        fix64 INumeric<fix64>.LeftShift(int count) => this << count;
        fix64 INumeric<fix64>.LogicalAnd(fix64 value) => this & value;
        fix64 INumeric<fix64>.LogicalExclusiveOr(fix64 value) => this ^ value;
        fix64 INumeric<fix64>.LogicalOr(fix64 value) => this | value;
        fix64 INumeric<fix64>.Multiply(fix64 value) => this * value;
        fix64 INumeric<fix64>.Negative() => -this;
        fix64 INumeric<fix64>.Positive() => +this;
        fix64 INumeric<fix64>.Remainder(fix64 value) => this % value;
        fix64 INumeric<fix64>.RightShift(int count) => this >> count;
        fix64 INumeric<fix64>.Subtract(fix64 value) => this - value;

        IBitConverter<fix64> IProvider<IBitConverter<fix64>>.GetInstance() => Utilities.Instance;
        ICast<fix64> IProvider<ICast<fix64>>.GetInstance() => Utilities.Instance;
        IConvert<fix64> IProvider<IConvert<fix64>>.GetInstance() => Utilities.Instance;
        IMath<fix64> IProvider<IMath<fix64>>.GetInstance() => Utilities.Instance;
        INumericStatic<fix64> IProvider<INumericStatic<fix64>>.GetInstance() => Utilities.Instance;
        IRandom<fix64> IProvider<IRandom<fix64>>.GetInstance() => Utilities.Instance;
        IStringParser<fix64> IProvider<IStringParser<fix64>>.GetInstance() => Utilities.Instance;

        private sealed class Utilities :
            IBitConverter<fix64>,
            ICast<fix64>,
            IConvert<fix64>,
            IMath<fix64>,
            INumericStatic<fix64>,
            IRandom<fix64>,
            IStringParser<fix64>
        {
            public readonly static Utilities Instance = new Utilities();

            bool INumericStatic<fix64>.HasFloatingPoint { get; } = false;
            bool INumericStatic<fix64>.HasInfinity { get; } = false;
            bool INumericStatic<fix64>.HasNaN { get; } = false;
            bool INumericStatic<fix64>.IsFinite(fix64 x) => true;
            bool INumericStatic<fix64>.IsInfinity(fix64 x) => false;
            bool INumericStatic<fix64>.IsNaN(fix64 x) => false;
            bool INumericStatic<fix64>.IsNegative(fix64 x) => x._scaledValue < 0;
            bool INumericStatic<fix64>.IsNegativeInfinity(fix64 x) => false;
            bool INumericStatic<fix64>.IsNormal(fix64 x) => false;
            bool INumericStatic<fix64>.IsPositiveInfinity(fix64 x) => false;
            bool INumericStatic<fix64>.IsReal { get; } = true;
            bool INumericStatic<fix64>.IsSigned { get; } = true;
            bool INumericStatic<fix64>.IsSubnormal(fix64 x) => false;
            fix64 INumericStatic<fix64>.Epsilon { get; } = new fix64(1);
            fix64 INumericStatic<fix64>.MaxUnit { get; } = new fix64(ScalingFactor);
            fix64 INumericStatic<fix64>.MaxValue => MaxValue;
            fix64 INumericStatic<fix64>.MinUnit { get; } = new fix64(-ScalingFactor);
            fix64 INumericStatic<fix64>.MinValue => MinValue;
            fix64 INumericStatic<fix64>.One { get; } = new fix64(ScalingFactor);
            fix64 INumericStatic<fix64>.Ten { get; } = new fix64(10 * ScalingFactor);
            fix64 INumericStatic<fix64>.Two { get; } = new fix64(2 * ScalingFactor);
            fix64 INumericStatic<fix64>.Zero { get; } = 0;

            fix64 IMath<fix64>.Abs(fix64 x) => x._scaledValue < 0 ? -x : x;
            fix64 IMath<fix64>.Acos(fix64 x) => (fix64)Math.Acos((double)x);
            fix64 IMath<fix64>.Acosh(fix64 x) => (fix64)Math.Acosh((double)x);
            fix64 IMath<fix64>.Asin(fix64 x) => (fix64)Math.Asin((double)x);
            fix64 IMath<fix64>.Asinh(fix64 x) => (fix64)Math.Asinh((double)x);
            fix64 IMath<fix64>.Atan(fix64 x) => (fix64)Math.Atan((double)x);
            fix64 IMath<fix64>.Atan2(fix64 x, fix64 y) => (fix64)Math.Atan2((double)x, (double)y);
            fix64 IMath<fix64>.Atanh(fix64 x) => (fix64)Math.Atanh((double)x);
            fix64 IMath<fix64>.Cbrt(fix64 x) => (fix64)Math.Cbrt((double)x);
            fix64 IMath<fix64>.Ceiling(fix64 x) => new fix64(ScaledArithmetic.Ceiling(x._scaledValue, ScalingFactor));
            fix64 IMath<fix64>.Clamp(fix64 x, fix64 bound1, fix64 bound2) => new fix64(bound1 > bound2 ? Math.Min(bound1._scaledValue, Math.Max(bound2._scaledValue, x._scaledValue)) : Math.Min(bound2._scaledValue, Math.Max(bound1._scaledValue, x._scaledValue)));
            fix64 IMath<fix64>.Cos(fix64 x) => (fix64)Math.Cos((double)x);
            fix64 IMath<fix64>.Cosh(fix64 x) => (fix64)Math.Cosh((double)x);
            fix64 IMath<fix64>.DegreesToRadians(fix64 x) => (fix64)((double)x * Trig.RadiansPerDegree);
            fix64 IMath<fix64>.E { get; } = (fix64)Math.E;
            fix64 IMath<fix64>.Exp(fix64 x) => (fix64)Math.Exp((double)x);
            fix64 IMath<fix64>.Floor(fix64 x) => new fix64(ScaledArithmetic.Floor(x._scaledValue, ScalingFactor));
            fix64 IMath<fix64>.IEEERemainder(fix64 x, fix64 y) => (fix64)Math.IEEERemainder((double)x, (double)y);
            fix64 IMath<fix64>.Log(fix64 x) => (fix64)Math.Log((double)x);
            fix64 IMath<fix64>.Log(fix64 x, fix64 y) => (fix64)Math.Log((double)x, (double)y);
            fix64 IMath<fix64>.Log10(fix64 x) => (fix64)Math.Log10((double)x);
            fix64 IMath<fix64>.Max(fix64 x, fix64 y) => new fix64(Math.Max(x._scaledValue, y._scaledValue));
            fix64 IMath<fix64>.Min(fix64 x, fix64 y) => new fix64(Math.Min(x._scaledValue, y._scaledValue));
            fix64 IMath<fix64>.PI { get; } = (fix64)Math.PI;
            fix64 IMath<fix64>.Pow(fix64 x, fix64 y) => y == 1 ? x : (fix64)Math.Pow((double)x, (double)y);
            fix64 IMath<fix64>.RadiansToDegrees(fix64 x) => (fix64)((double)x * Trig.DegreesPerRadian);
            fix64 IMath<fix64>.Round(fix64 x) => Round(x, 0, MidpointRounding.ToEven);
            fix64 IMath<fix64>.Round(fix64 x, int digits) => Round(x, digits, MidpointRounding.ToEven);
            fix64 IMath<fix64>.Round(fix64 x, int digits, MidpointRounding mode) => Round(x, digits, mode);
            fix64 IMath<fix64>.Round(fix64 x, MidpointRounding mode) => Round(x, 0, mode);
            fix64 IMath<fix64>.Sin(fix64 x) => (fix64)Math.Sin((double)x);
            fix64 IMath<fix64>.Sinh(fix64 x) => (fix64)Math.Sinh((double)x);
            fix64 IMath<fix64>.Sqrt(fix64 x) => (fix64)Math.Sqrt((double)x);
            fix64 IMath<fix64>.Tan(fix64 x) => (fix64)Math.Tan((double)x);
            fix64 IMath<fix64>.Tanh(fix64 x) => (fix64)Math.Tanh((double)x);
            fix64 IMath<fix64>.Tau { get; } = (fix64)(Math.PI * 2d);
            fix64 IMath<fix64>.Truncate(fix64 x) => new fix64(x._scaledValue / ScalingFactor * ScalingFactor);
            int IMath<fix64>.Sign(fix64 x) => x._scaledValue == 0 ? 0 : 1;

            fix64 IBitConverter<fix64>.Read(IReadOnlyStream<byte> stream) => new fix64(BitConverter.ToInt64(stream.Read(sizeof(long))));
            void IBitConverter<fix64>.Write(fix64 value, IWriteOnlyStream<byte> stream) => stream.Write(BitConverter.GetBytes(value._scaledValue));

            fix64 IRandom<fix64>.Next(Random random) => new fix64(random.NextInt64());
            fix64 IRandom<fix64>.Next(Random random, fix64 bound1, fix64 bound2) => new fix64(random.NextInt64(bound1._scaledValue, bound2._scaledValue));

            bool IConvert<fix64>.ToBoolean(fix64 value) => value._scaledValue != 0;
            byte IConvert<fix64>.ToByte(fix64 value) => Convert.ToByte(value._scaledValue / ScalingFactor);
            decimal IConvert<fix64>.ToDecimal(fix64 value) => (decimal)value._scaledValue / ScalingFactor;
            double IConvert<fix64>.ToDouble(fix64 value) => (double)value._scaledValue / ScalingFactor;
            float IConvert<fix64>.ToSingle(fix64 value) => (float)value._scaledValue / ScalingFactor;
            int IConvert<fix64>.ToInt32(fix64 value) => Convert.ToInt32(value._scaledValue / ScalingFactor);
            long IConvert<fix64>.ToInt64(fix64 value) => value._scaledValue / ScalingFactor;
            sbyte IConvert<fix64>.ToSByte(fix64 value) => Convert.ToSByte(value._scaledValue / ScalingFactor);
            short IConvert<fix64>.ToInt16(fix64 value) => Convert.ToInt16(value._scaledValue / ScalingFactor);
            string IConvert<fix64>.ToString(fix64 value) => value.ToString();
            uint IConvert<fix64>.ToUInt32(fix64 value) => Convert.ToUInt32(value._scaledValue / ScalingFactor);
            ulong IConvert<fix64>.ToUInt64(fix64 value) => Convert.ToUInt64(value._scaledValue / ScalingFactor);
            ushort IConvert<fix64>.ToUInt16(fix64 value) => Convert.ToUInt16(value._scaledValue / ScalingFactor);

            fix64 IConvert<fix64>.ToNumeric(bool value) => value ? ScalingFactor : 0;
            fix64 IConvert<fix64>.ToNumeric(byte value) => (fix64)Convert.ToInt64(value);
            fix64 IConvert<fix64>.ToNumeric(decimal value) => (fix64)value;
            fix64 IConvert<fix64>.ToNumeric(double value) => (fix64)value;
            fix64 IConvert<fix64>.ToNumeric(float value) => value;
            fix64 IConvert<fix64>.ToNumeric(int value) => (fix64)Convert.ToInt64(value);
            fix64 IConvert<fix64>.ToNumeric(long value) => (fix64)value;
            fix64 IConvert<fix64>.ToNumeric(sbyte value) => (fix64)Convert.ToInt64(value);
            fix64 IConvert<fix64>.ToNumeric(short value) => (fix64)Convert.ToInt64(value);
            fix64 IConvert<fix64>.ToNumeric(string value) => (fix64)Convert.ToInt64(value);
            fix64 IConvert<fix64>.ToNumeric(uint value) => (fix64)Convert.ToInt64(value);
            fix64 IConvert<fix64>.ToNumeric(ulong value) => (fix64)Convert.ToInt64(value);
            fix64 IConvert<fix64>.ToNumeric(ushort value) => (fix64)Convert.ToInt64(value);

            fix64 IStringParser<fix64>.Parse(string s) => Parse(s);
            fix64 IStringParser<fix64>.Parse(string s, NumberStyles style, IFormatProvider? provider) => Parse(s, style, provider);

            byte ICast<fix64>.ToByte(fix64 value) => (byte)value;
            decimal ICast<fix64>.ToDecimal(fix64 value) => (decimal)value;
            double ICast<fix64>.ToDouble(fix64 value) => (double)value;
            float ICast<fix64>.ToSingle(fix64 value) => (float)value;
            int ICast<fix64>.ToInt32(fix64 value) => (int)value;
            long ICast<fix64>.ToInt64(fix64 value) => (long)value;
            sbyte ICast<fix64>.ToSByte(fix64 value) => (sbyte)value;
            short ICast<fix64>.ToInt16(fix64 value) => (short)value;
            uint ICast<fix64>.ToUInt32(fix64 value) => (uint)value;
            ulong ICast<fix64>.ToUInt64(fix64 value) => (ulong)value;
            ushort ICast<fix64>.ToUInt16(fix64 value) => (ushort)value;

            fix64 ICast<fix64>.ToNumeric(byte value) => (fix64)value;
            fix64 ICast<fix64>.ToNumeric(decimal value) => (fix64)value;
            fix64 ICast<fix64>.ToNumeric(double value) => (fix64)value;
            fix64 ICast<fix64>.ToNumeric(float value) => (fix64)value;
            fix64 ICast<fix64>.ToNumeric(int value) => (fix64)value;
            fix64 ICast<fix64>.ToNumeric(long value) => (fix64)value;
            fix64 ICast<fix64>.ToNumeric(sbyte value) => (fix64)value;
            fix64 ICast<fix64>.ToNumeric(short value) => (fix64)value;
            fix64 ICast<fix64>.ToNumeric(uint value) => (fix64)value;
            fix64 ICast<fix64>.ToNumeric(ulong value) => (fix64)value;
            fix64 ICast<fix64>.ToNumeric(ushort value) => (fix64)value;
        }
    }
}
