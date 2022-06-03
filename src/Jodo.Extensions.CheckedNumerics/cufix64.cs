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
    public readonly struct cufix64 : INumeric<cufix64>
    {
        public static readonly cufix64 Epsilon = new cufix64(1);
        public static readonly cufix64 MaxValue = new cufix64(ulong.MaxValue);
        public static readonly cufix64 MinValue = new cufix64(ulong.MinValue);

        private const ulong ScalingFactor = 1_000_000;

        private readonly ulong _scaledValue;

        private cufix64(ulong scaledValue)
        {
            _scaledValue = scaledValue;
        }

        private cufix64(SerializationInfo info, StreamingContext context) : this(info.GetUInt64(nameof(cufix64))) { }
        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context) => info.AddValue(nameof(cufix64), _scaledValue);

        public int CompareTo(object? obj) => obj is cufix64 other ? CompareTo(other) : 1;
        public int CompareTo(cufix64 other) => _scaledValue.CompareTo(other._scaledValue);
        public bool Equals(cufix64 other) => _scaledValue == other._scaledValue;
        public override bool Equals(object? obj) => obj is cufix64 other && Equals(other);
        public override int GetHashCode() => _scaledValue.GetHashCode();
        public override string ToString() => ScaledArithmetic.ToString(_scaledValue, ScalingFactor);
        public string ToString(IFormatProvider formatProvider) => ((double)this).ToString(formatProvider);
        public string ToString(string format) => ((double)this).ToString(format);
        public string ToString(string format, IFormatProvider formatProvider) => ((double)this).ToString(format, formatProvider);

        public static bool TryParse(string s, IFormatProvider? provider, out cufix64 result) => Try.Run(() => Parse(s, provider), out result);
        public static bool TryParse(string s, NumberStyles style, IFormatProvider? provider, out cufix64 result) => Try.Run(() => Parse(s, style, provider), out result);
        public static bool TryParse(string s, NumberStyles style, out cufix64 result) => Try.Run(() => Parse(s, style), out result);
        public static bool TryParse(string s, out cufix64 result) => Try.Run(() => Parse(s), out result);
        public static cufix64 Parse(string s) => new cufix64(ScaledArithmetic.Parse(s, ScalingFactor));
        public static cufix64 Parse(string s, IFormatProvider? provider) => (cufix64)double.Parse(s, provider);
        public static cufix64 Parse(string s, NumberStyles style) => (cufix64)double.Parse(s, style);
        public static cufix64 Parse(string s, NumberStyles style, IFormatProvider? provider) => (cufix64)double.Parse(s, style, provider);

        private static cufix64 Round(cufix64 value, int digits, MidpointRounding mode)
        {
            if (digits < 0) throw new ArgumentOutOfRangeException(nameof(digits), digits, "Must be positive.");
            if (digits > 5) return value;
            return new cufix64(ScaledArithmetic.Round(value._scaledValue, 6 - digits, mode));
        }

        private static cufix64 FromDouble(double value)
        {
            string str = string
                .Format(CultureInfo.InvariantCulture, "{0:0.0000000}", value)
                .Replace(".", string.Empty)
                [..^1];
            if (ulong.TryParse(str, out var lng))
            {
                return new cufix64(lng);
            }
            else
            {
                if (value > 0) return MaxValue;
                return MinValue;
            }
        }

        private static double ToDouble(cufix64 value)
        {
            var integral = value._scaledValue / ScalingFactor;
            var mantissa = value._scaledValue % ScalingFactor;

            var result = (double)mantissa / ScalingFactor;
            result += integral;
            return result;
        }

        public static explicit operator cufix64(decimal value) => value < 0 ? new cufix64(0) : new cufix64(CheckedCast.ToUInt64(value * ScalingFactor));
        public static explicit operator cufix64(double value) => value < 0 ? new cufix64(0) : FromDouble(value);
        public static explicit operator cufix64(float value) => value < 0 ? new cufix64(0) : new cufix64(CheckedCast.ToUInt64(value * ScalingFactor));
        public static explicit operator cufix64(int value) => new cufix64(CheckedCast.ToUInt64(value) * ScalingFactor);
        public static explicit operator cufix64(long value) => new cufix64(CheckedCast.ToUInt64(value) * ScalingFactor);
        public static explicit operator cufix64(sbyte value) => new cufix64(CheckedCast.ToUInt64(value) * ScalingFactor);
        public static explicit operator cufix64(short value) => new cufix64(CheckedCast.ToUInt64(value) * ScalingFactor);
        public static explicit operator cufix64(ulong value) => new cufix64(value * ScalingFactor);
        public static implicit operator cufix64(byte value) => new cufix64(value * ScalingFactor);
        public static implicit operator cufix64(uint value) => new cufix64(CheckedCast.ToUInt64(value) * ScalingFactor);
        public static implicit operator cufix64(ushort value) => new cufix64(CheckedCast.ToUInt64(value) * ScalingFactor);

        public static explicit operator byte(cufix64 value) => CheckedCast.ToByte(value._scaledValue / ScalingFactor);
        public static explicit operator decimal(cufix64 value) => (decimal)value._scaledValue / ScalingFactor;
        public static explicit operator double(cufix64 value) => ToDouble(value);
        public static explicit operator float(cufix64 value) => (float)value._scaledValue / ScalingFactor;
        public static explicit operator int(cufix64 value) => CheckedCast.ToInt32(value._scaledValue / ScalingFactor);
        public static explicit operator long(cufix64 value) => CheckedCast.ToInt64(value._scaledValue / ScalingFactor);
        public static explicit operator sbyte(cufix64 value) => CheckedCast.ToSByte(value._scaledValue / ScalingFactor);
        public static explicit operator short(cufix64 value) => CheckedCast.ToInt16(value._scaledValue / ScalingFactor);
        public static explicit operator uint(cufix64 value) => CheckedCast.ToUInt32(value._scaledValue / ScalingFactor);
        public static explicit operator ulong(cufix64 value) => value._scaledValue / ScalingFactor;
        public static explicit operator ushort(cufix64 value) => CheckedCast.ToUInt16(value._scaledValue / ScalingFactor);

        public static bool operator !=(cufix64 left, cufix64 right) => left._scaledValue != right._scaledValue;
        public static bool operator <(cufix64 left, cufix64 right) => left._scaledValue < right._scaledValue;
        public static bool operator <=(cufix64 left, cufix64 right) => left._scaledValue <= right._scaledValue;
        public static bool operator ==(cufix64 left, cufix64 right) => left._scaledValue == right._scaledValue;
        public static bool operator >(cufix64 left, cufix64 right) => left._scaledValue > right._scaledValue;
        public static bool operator >=(cufix64 left, cufix64 right) => left._scaledValue >= right._scaledValue;
        public static cufix64 operator %(cufix64 left, cufix64 right) => new cufix64(CheckedArithmetic.Remainder(left._scaledValue, right._scaledValue));
        public static cufix64 operator &(cufix64 left, cufix64 right) => new cufix64(left._scaledValue & right._scaledValue);
        public static cufix64 operator -(cufix64 _) => 0;
        public static cufix64 operator -(cufix64 left, cufix64 right) => new cufix64(CheckedArithmetic.Subtract(left._scaledValue, right._scaledValue));
        public static cufix64 operator --(cufix64 value) => new cufix64(value._scaledValue - ScalingFactor);
        public static cufix64 operator *(cufix64 left, cufix64 right) => new cufix64(CheckedArithmetic.ScaledMultiply(left._scaledValue, right._scaledValue, ScalingFactor));
        public static cufix64 operator /(cufix64 left, cufix64 right) => new cufix64(CheckedArithmetic.ScaledDivide(left._scaledValue, right._scaledValue, ScalingFactor));
        public static cufix64 operator ^(cufix64 left, cufix64 right) => new cufix64(left._scaledValue ^ right._scaledValue);
        public static cufix64 operator |(cufix64 left, cufix64 right) => new cufix64(left._scaledValue | right._scaledValue);
        public static cufix64 operator ~(cufix64 value) => new cufix64(~value._scaledValue);
        public static cufix64 operator +(cufix64 left, cufix64 right) => new cufix64(CheckedArithmetic.Add(left._scaledValue, right._scaledValue));
        public static cufix64 operator +(cufix64 value) => value;
        public static cufix64 operator ++(cufix64 value) => new cufix64(value._scaledValue + ScalingFactor);
        public static cufix64 operator <<(cufix64 left, int right) => new cufix64(left._scaledValue << right);
        public static cufix64 operator >>(cufix64 left, int right) => new cufix64(left._scaledValue >> right);

        bool INumeric<cufix64>.IsGreaterThan(cufix64 value) => this > value;
        bool INumeric<cufix64>.IsGreaterThanOrEqualTo(cufix64 value) => this >= value;
        bool INumeric<cufix64>.IsLessThan(cufix64 value) => this < value;
        bool INumeric<cufix64>.IsLessThanOrEqualTo(cufix64 value) => this <= value;
        cufix64 INumeric<cufix64>.Add(cufix64 value) => this + value;
        cufix64 INumeric<cufix64>.BitwiseComplement() => ~this;
        cufix64 INumeric<cufix64>.Divide(cufix64 value) => this / value;
        cufix64 INumeric<cufix64>.LeftShift(int count) => this << count;
        cufix64 INumeric<cufix64>.LogicalAnd(cufix64 value) => this & value;
        cufix64 INumeric<cufix64>.LogicalExclusiveOr(cufix64 value) => this ^ value;
        cufix64 INumeric<cufix64>.LogicalOr(cufix64 value) => this | value;
        cufix64 INumeric<cufix64>.Multiply(cufix64 value) => this * value;
        cufix64 INumeric<cufix64>.Negative() => -this;
        cufix64 INumeric<cufix64>.Positive() => +this;
        cufix64 INumeric<cufix64>.Remainder(cufix64 value) => this % value;
        cufix64 INumeric<cufix64>.RightShift(int count) => this >> count;
        cufix64 INumeric<cufix64>.Subtract(cufix64 value) => this - value;

        IBitConverter<cufix64> IProvider<IBitConverter<cufix64>>.GetInstance() => Utilities.Instance;
        ICast<cufix64> IProvider<ICast<cufix64>>.GetInstance() => Utilities.Instance;
        IConvert<cufix64> IProvider<IConvert<cufix64>>.GetInstance() => Utilities.Instance;
        IMath<cufix64> IProvider<IMath<cufix64>>.GetInstance() => Utilities.Instance;
        INumericStatic<cufix64> IProvider<INumericStatic<cufix64>>.GetInstance() => Utilities.Instance;
        IRandom<cufix64> IProvider<IRandom<cufix64>>.GetInstance() => Utilities.Instance;
        IStringParser<cufix64> IProvider<IStringParser<cufix64>>.GetInstance() => Utilities.Instance;

        private sealed class Utilities :
            IBitConverter<cufix64>,
            ICast<cufix64>,
            IConvert<cufix64>,
            IMath<cufix64>,
            INumericStatic<cufix64>,
            IRandom<cufix64>,
            IStringParser<cufix64>
        {
            public readonly static Utilities Instance = new Utilities();

            bool INumericStatic<cufix64>.HasFloatingPoint { get; } = false;
            bool INumericStatic<cufix64>.HasInfinity { get; } = false;
            bool INumericStatic<cufix64>.HasNaN { get; } = false;
            bool INumericStatic<cufix64>.IsFinite(cufix64 x) => true;
            bool INumericStatic<cufix64>.IsInfinity(cufix64 x) => false;
            bool INumericStatic<cufix64>.IsNaN(cufix64 x) => false;
            bool INumericStatic<cufix64>.IsNegative(cufix64 x) => false;
            bool INumericStatic<cufix64>.IsNegativeInfinity(cufix64 x) => false;
            bool INumericStatic<cufix64>.IsNormal(cufix64 x) => false;
            bool INumericStatic<cufix64>.IsPositiveInfinity(cufix64 x) => false;
            bool INumericStatic<cufix64>.IsReal { get; } = true;
            bool INumericStatic<cufix64>.IsSigned { get; } = false;
            bool INumericStatic<cufix64>.IsSubnormal(cufix64 x) => false;
            cufix64 INumericStatic<cufix64>.Epsilon { get; } = new cufix64(1);
            cufix64 INumericStatic<cufix64>.MaxUnit { get; } = new cufix64(ScalingFactor);
            cufix64 INumericStatic<cufix64>.MaxValue => MaxValue;
            cufix64 INumericStatic<cufix64>.MinUnit { get; } = 0;
            cufix64 INumericStatic<cufix64>.MinValue => MinValue;
            cufix64 INumericStatic<cufix64>.One { get; } = new cufix64(ScalingFactor);
            cufix64 INumericStatic<cufix64>.Ten { get; } = new cufix64(10 * ScalingFactor);
            cufix64 INumericStatic<cufix64>.Two { get; } = new cufix64(2 * ScalingFactor);
            cufix64 INumericStatic<cufix64>.Zero { get; } = 0;

            int IMath<cufix64>.Sign(cufix64 x) => x._scaledValue == 0 ? 0 : 1;
            cufix64 IMath<cufix64>.Abs(cufix64 x) => x;
            cufix64 IMath<cufix64>.Acos(cufix64 x) => (cufix64)Math.Acos((double)x);
            cufix64 IMath<cufix64>.Acosh(cufix64 x) => (cufix64)Math.Acosh((double)x);
            cufix64 IMath<cufix64>.Asin(cufix64 x) => (cufix64)Math.Asin((double)x);
            cufix64 IMath<cufix64>.Asinh(cufix64 x) => (cufix64)Math.Asinh((double)x);
            cufix64 IMath<cufix64>.Atan(cufix64 x) => (cufix64)Math.Atan((double)x);
            cufix64 IMath<cufix64>.Atan2(cufix64 x, cufix64 y) => (cufix64)Math.Atan2((double)x, (double)y);
            cufix64 IMath<cufix64>.Atanh(cufix64 x) => (cufix64)Math.Atanh((double)x);
            cufix64 IMath<cufix64>.Cbrt(cufix64 x) => (cufix64)Math.Cbrt((double)x);
            cufix64 IMath<cufix64>.Ceiling(cufix64 x) => new cufix64(ScaledArithmetic.Ceiling(x._scaledValue, ScalingFactor));
            cufix64 IMath<cufix64>.Clamp(cufix64 x, cufix64 bound1, cufix64 bound2) => new cufix64(bound1 > bound2 ? Math.Min(bound1._scaledValue, Math.Max(bound2._scaledValue, x._scaledValue)) : Math.Min(bound2._scaledValue, Math.Max(bound1._scaledValue, x._scaledValue)));
            cufix64 IMath<cufix64>.Cos(cufix64 x) => (cufix64)Math.Cos((double)x);
            cufix64 IMath<cufix64>.Cosh(cufix64 x) => (cufix64)Math.Cosh((double)x);
            cufix64 IMath<cufix64>.DegreesToRadians(cufix64 x) => (cufix64)CheckedArithmetic.Multiply((double)x, Trig.RadiansPerDegree);
            cufix64 IMath<cufix64>.E { get; } = (cufix64)Math.E;
            cufix64 IMath<cufix64>.Exp(cufix64 x) => (cufix64)Math.Exp((double)x);
            cufix64 IMath<cufix64>.Floor(cufix64 x) => new cufix64(ScaledArithmetic.Floor(x._scaledValue, ScalingFactor));
            cufix64 IMath<cufix64>.IEEERemainder(cufix64 x, cufix64 y) => (cufix64)Math.IEEERemainder((double)x, (double)y);
            cufix64 IMath<cufix64>.Log(cufix64 x) => (cufix64)Math.Log((double)x);
            cufix64 IMath<cufix64>.Log(cufix64 x, cufix64 y) => (cufix64)Math.Log((double)x, (double)y);
            cufix64 IMath<cufix64>.Log10(cufix64 x) => (cufix64)Math.Log10((double)x);
            cufix64 IMath<cufix64>.Max(cufix64 x, cufix64 y) => new cufix64(Math.Max(x._scaledValue, y._scaledValue));
            cufix64 IMath<cufix64>.Min(cufix64 x, cufix64 y) => new cufix64(Math.Min(x._scaledValue, y._scaledValue));
            cufix64 IMath<cufix64>.PI { get; } = (cufix64)Math.PI;
            cufix64 IMath<cufix64>.Pow(cufix64 x, cufix64 y) => y == 1 ? x : (cufix64)Math.Pow((double)x, (double)y);
            cufix64 IMath<cufix64>.RadiansToDegrees(cufix64 x) => (cufix64)CheckedArithmetic.Multiply((double)x, Trig.DegreesPerRadian);
            cufix64 IMath<cufix64>.Round(cufix64 x) => Round(x, 0, MidpointRounding.ToEven);
            cufix64 IMath<cufix64>.Round(cufix64 x, int digits) => Round(x, digits, MidpointRounding.ToEven);
            cufix64 IMath<cufix64>.Round(cufix64 x, int digits, MidpointRounding mode) => Round(x, digits, mode);
            cufix64 IMath<cufix64>.Round(cufix64 x, MidpointRounding mode) => Round(x, 0, mode);
            cufix64 IMath<cufix64>.Sin(cufix64 x) => (cufix64)Math.Sin((double)x);
            cufix64 IMath<cufix64>.Sinh(cufix64 x) => (cufix64)Math.Sinh((double)x);
            cufix64 IMath<cufix64>.Sqrt(cufix64 x) => (cufix64)Math.Sqrt((double)x);
            cufix64 IMath<cufix64>.Tan(cufix64 x) => (cufix64)Math.Tan((double)x);
            cufix64 IMath<cufix64>.Tanh(cufix64 x) => (cufix64)Math.Tanh((double)x);
            cufix64 IMath<cufix64>.Tau { get; } = (cufix64)(Math.PI * 2d);
            cufix64 IMath<cufix64>.Truncate(cufix64 x) => new cufix64(x._scaledValue / ScalingFactor * ScalingFactor);

            cufix64 IBitConverter<cufix64>.Read(IReadOnlyStream<byte> stream) => new cufix64(BitConverter.ToUInt64(stream.Read(sizeof(ulong))));
            void IBitConverter<cufix64>.Write(cufix64 value, IWriteOnlyStream<byte> stream) => stream.Write(BitConverter.GetBytes(value._scaledValue));

            cufix64 IRandom<cufix64>.Next(Random random) => new cufix64(random.NextUInt64());
            cufix64 IRandom<cufix64>.Next(Random random, cufix64 bound1, cufix64 bound2) => new cufix64(random.NextUInt64(bound1._scaledValue, bound2._scaledValue));

            bool IConvert<cufix64>.ToBoolean(cufix64 value) => value._scaledValue != 0;
            byte IConvert<cufix64>.ToByte(cufix64 value) => CheckedConvert.ToByte(value._scaledValue / ScalingFactor);
            decimal IConvert<cufix64>.ToDecimal(cufix64 value) => (decimal)value._scaledValue / ScalingFactor;
            double IConvert<cufix64>.ToDouble(cufix64 value) => (double)value._scaledValue / ScalingFactor;
            float IConvert<cufix64>.ToSingle(cufix64 value) => (float)value._scaledValue / ScalingFactor;
            int IConvert<cufix64>.ToInt32(cufix64 value) => CheckedConvert.ToInt32(value._scaledValue / ScalingFactor);
            long IConvert<cufix64>.ToInt64(cufix64 value) => CheckedConvert.ToInt64(value._scaledValue / ScalingFactor);
            sbyte IConvert<cufix64>.ToSByte(cufix64 value) => CheckedConvert.ToSByte(value._scaledValue / ScalingFactor);
            short IConvert<cufix64>.ToInt16(cufix64 value) => CheckedConvert.ToInt16(value._scaledValue / ScalingFactor);
            string IConvert<cufix64>.ToString(cufix64 value) => value.ToString();
            uint IConvert<cufix64>.ToUInt32(cufix64 value) => CheckedConvert.ToUInt32(value._scaledValue / ScalingFactor);
            ulong IConvert<cufix64>.ToUInt64(cufix64 value) => value._scaledValue / ScalingFactor;
            ushort IConvert<cufix64>.ToUInt16(cufix64 value) => CheckedConvert.ToUInt16(value._scaledValue / ScalingFactor);

            cufix64 IConvert<cufix64>.ToNumeric(bool value) => value ? new cufix64(ScalingFactor) : new cufix64(0);
            cufix64 IConvert<cufix64>.ToNumeric(byte value) => (cufix64)CheckedConvert.ToUInt64(value);
            cufix64 IConvert<cufix64>.ToNumeric(decimal value) => (cufix64)value;
            cufix64 IConvert<cufix64>.ToNumeric(double value) => (cufix64)value;
            cufix64 IConvert<cufix64>.ToNumeric(float value) => (cufix64)value;
            cufix64 IConvert<cufix64>.ToNumeric(int value) => (cufix64)CheckedConvert.ToUInt64(value);
            cufix64 IConvert<cufix64>.ToNumeric(long value) => (cufix64)value;
            cufix64 IConvert<cufix64>.ToNumeric(sbyte value) => (cufix64)CheckedConvert.ToUInt64(value);
            cufix64 IConvert<cufix64>.ToNumeric(short value) => (cufix64)CheckedConvert.ToUInt64(value);
            cufix64 IConvert<cufix64>.ToNumeric(string value) => (cufix64)Convert.ToUInt64(value);
            cufix64 IConvert<cufix64>.ToNumeric(uint value) => (cufix64)CheckedConvert.ToUInt64(value);
            cufix64 IConvert<cufix64>.ToNumeric(ulong value) => (cufix64)value;
            cufix64 IConvert<cufix64>.ToNumeric(ushort value) => (cufix64)CheckedConvert.ToUInt64(value);

            cufix64 IStringParser<cufix64>.Parse(string s) => Parse(s);
            cufix64 IStringParser<cufix64>.Parse(string s, NumberStyles style, IFormatProvider? provider) => Parse(s, style, provider);

            byte ICast<cufix64>.ToByte(cufix64 value) => (byte)value;
            decimal ICast<cufix64>.ToDecimal(cufix64 value) => (decimal)value;
            double ICast<cufix64>.ToDouble(cufix64 value) => (double)value;
            float ICast<cufix64>.ToSingle(cufix64 value) => (float)value;
            int ICast<cufix64>.ToInt32(cufix64 value) => (int)value;
            long ICast<cufix64>.ToInt64(cufix64 value) => (long)value;
            sbyte ICast<cufix64>.ToSByte(cufix64 value) => (sbyte)value;
            short ICast<cufix64>.ToInt16(cufix64 value) => (short)value;
            uint ICast<cufix64>.ToUInt32(cufix64 value) => (uint)value;
            ulong ICast<cufix64>.ToUInt64(cufix64 value) => (ulong)value;
            ushort ICast<cufix64>.ToUInt16(cufix64 value) => (ushort)value;

            cufix64 ICast<cufix64>.ToNumeric(byte value) => (cufix64)value;
            cufix64 ICast<cufix64>.ToNumeric(decimal value) => (cufix64)value;
            cufix64 ICast<cufix64>.ToNumeric(double value) => (cufix64)value;
            cufix64 ICast<cufix64>.ToNumeric(float value) => (cufix64)value;
            cufix64 ICast<cufix64>.ToNumeric(int value) => (cufix64)value;
            cufix64 ICast<cufix64>.ToNumeric(long value) => (cufix64)value;
            cufix64 ICast<cufix64>.ToNumeric(sbyte value) => (cufix64)value;
            cufix64 ICast<cufix64>.ToNumeric(short value) => (cufix64)value;
            cufix64 ICast<cufix64>.ToNumeric(uint value) => (cufix64)value;
            cufix64 ICast<cufix64>.ToNumeric(ulong value) => (cufix64)value;
            cufix64 ICast<cufix64>.ToNumeric(ushort value) => (cufix64)value;
        }
    }
}
