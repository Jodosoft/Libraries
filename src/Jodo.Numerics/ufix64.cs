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
    public readonly struct ufix64 : INumeric<ufix64>
    {
        public static readonly ufix64 Epsilon = new ufix64(1);
        public static readonly ufix64 MaxValue = new ufix64(ulong.MaxValue);
        public static readonly ufix64 MinValue = new ufix64(ulong.MinValue);

        private const ulong ScalingFactor = 1_000_000;

        private readonly ulong _scaledValue;

        private ufix64(ulong scaledValue)
        {
            _scaledValue = scaledValue;
        }

        private ufix64(SerializationInfo info, StreamingContext context) : this(info.GetUInt64(nameof(ufix64))) { }
        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context) => info.AddValue(nameof(ufix64), _scaledValue);

        public int CompareTo(object? obj) => obj is ufix64 other ? CompareTo(other) : 1;
        public int CompareTo(ufix64 other) => _scaledValue.CompareTo(other._scaledValue);
        public bool Equals(ufix64 other) => _scaledValue == other._scaledValue;
        public override bool Equals(object? obj) => obj is ufix64 other && Equals(other);
        public override int GetHashCode() => _scaledValue.GetHashCode();
        public override string ToString() => ScaledArithmetic.ToString(_scaledValue, ScalingFactor);
        public string ToString(IFormatProvider formatProvider) => ((double)this).ToString(formatProvider);
        public string ToString(string format) => ((double)this).ToString(format);
        public string ToString(string? format, IFormatProvider? formatProvider) => ((double)this).ToString(format, formatProvider);

        public static bool TryParse(string s, IFormatProvider? provider, out ufix64 result) => Try.Run(() => Parse(s, provider), out result);
        public static bool TryParse(string s, NumberStyles style, IFormatProvider? provider, out ufix64 result) => Try.Run(() => Parse(s, style, provider), out result);
        public static bool TryParse(string s, NumberStyles style, out ufix64 result) => Try.Run(() => Parse(s, style), out result);
        public static bool TryParse(string s, out ufix64 result) => Try.Run(() => Parse(s), out result);
        public static ufix64 Parse(string s) => new ufix64(ScaledArithmetic.Parse(s, ScalingFactor));
        public static ufix64 Parse(string s, IFormatProvider? provider) => (ufix64)double.Parse(s, provider);
        public static ufix64 Parse(string s, NumberStyles style) => (ufix64)double.Parse(s, style);
        public static ufix64 Parse(string s, NumberStyles style, IFormatProvider? provider) => (ufix64)double.Parse(s, style, provider);

        private static ufix64 Round(ufix64 value, int digits, MidpointRounding mode)
        {
            if (digits < 0) throw new ArgumentOutOfRangeException(nameof(digits), digits, "Must be positive.");
            if (digits > 5) return value;
            return new ufix64(ScaledArithmetic.Round(value._scaledValue, 6 - digits, mode));
        }

        private static ufix64 FromDouble(double value)
        {
            string str = string
                .Format(CultureInfo.InvariantCulture, "{0:0.0000000}", value)
                .Replace(".", string.Empty);
            str = str.Substring(0, str.Length - 1);
            if (ulong.TryParse(str, out ulong lng))
            {
                return new ufix64(lng);
            }
            else
            {
                if (value > 0) return MaxValue;
                return MinValue;
            }
        }

        private static double ToDouble(ufix64 value)
        {
            ulong integral = value._scaledValue / ScalingFactor;
            ulong mantissa = value._scaledValue % ScalingFactor;

            double result = (double)mantissa / ScalingFactor;
            result += integral;
            return result;
        }

        [CLSCompliant(false)] public static explicit operator ufix64(sbyte value) => new ufix64((ulong)value * ScalingFactor);
        [CLSCompliant(false)] public static explicit operator ufix64(ulong value) => new ufix64(value * ScalingFactor);
        [CLSCompliant(false)] public static implicit operator ufix64(uint value) => new ufix64(value * ScalingFactor);
        [CLSCompliant(false)] public static implicit operator ufix64(ushort value) => new ufix64(value * ScalingFactor);
        public static explicit operator ufix64(decimal value) => value < 0 ? new ufix64(0) : new ufix64((ulong)(value * ScalingFactor));
        public static explicit operator ufix64(double value) => value < 0 ? new ufix64(0) : FromDouble(value);
        public static explicit operator ufix64(float value) => value < 0 ? new ufix64(0) : new ufix64((ulong)(value * ScalingFactor));
        public static explicit operator ufix64(int value) => new ufix64((ulong)value * ScalingFactor);
        public static explicit operator ufix64(long value) => new ufix64((ulong)value * ScalingFactor);
        public static explicit operator ufix64(short value) => new ufix64((ulong)value * ScalingFactor);
        public static implicit operator ufix64(byte value) => new ufix64(value * ScalingFactor);

        [CLSCompliant(false)] public static explicit operator sbyte(ufix64 value) => (sbyte)(value._scaledValue / ScalingFactor);
        [CLSCompliant(false)] public static explicit operator uint(ufix64 value) => (uint)(value._scaledValue / ScalingFactor);
        [CLSCompliant(false)] public static explicit operator ulong(ufix64 value) => value._scaledValue / ScalingFactor;
        [CLSCompliant(false)] public static explicit operator ushort(ufix64 value) => (ushort)(value._scaledValue / ScalingFactor);
        public static explicit operator byte(ufix64 value) => (byte)(value._scaledValue / ScalingFactor);
        public static explicit operator decimal(ufix64 value) => (decimal)value._scaledValue / ScalingFactor;
        public static explicit operator double(ufix64 value) => ToDouble(value);
        public static explicit operator float(ufix64 value) => (float)value._scaledValue / ScalingFactor;
        public static explicit operator int(ufix64 value) => (int)(value._scaledValue / ScalingFactor);
        public static explicit operator long(ufix64 value) => (long)(value._scaledValue / ScalingFactor);
        public static explicit operator short(ufix64 value) => (short)(value._scaledValue / ScalingFactor);

        public static bool operator !=(ufix64 left, ufix64 right) => left._scaledValue != right._scaledValue;
        public static bool operator <(ufix64 left, ufix64 right) => left._scaledValue < right._scaledValue;
        public static bool operator <=(ufix64 left, ufix64 right) => left._scaledValue <= right._scaledValue;
        public static bool operator ==(ufix64 left, ufix64 right) => left._scaledValue == right._scaledValue;
        public static bool operator >(ufix64 left, ufix64 right) => left._scaledValue > right._scaledValue;
        public static bool operator >=(ufix64 left, ufix64 right) => left._scaledValue >= right._scaledValue;
        public static ufix64 operator %(ufix64 left, ufix64 right) => new ufix64(left._scaledValue % right._scaledValue);
        public static ufix64 operator &(ufix64 left, ufix64 right) => new ufix64(left._scaledValue & right._scaledValue);
        public static ufix64 operator -(ufix64 _) => 0;
        public static ufix64 operator -(ufix64 left, ufix64 right) => new ufix64(left._scaledValue - right._scaledValue);
        public static ufix64 operator --(ufix64 value) => new ufix64(value._scaledValue - ScalingFactor);
        public static ufix64 operator *(ufix64 left, ufix64 right) => new ufix64(ScaledArithmetic.Multiply(left._scaledValue, right._scaledValue, ScalingFactor));
        public static ufix64 operator /(ufix64 left, ufix64 right) => new ufix64(ScaledArithmetic.Divide(left._scaledValue, right._scaledValue, ScalingFactor));
        public static ufix64 operator ^(ufix64 left, ufix64 right) => new ufix64(left._scaledValue ^ right._scaledValue);
        public static ufix64 operator |(ufix64 left, ufix64 right) => new ufix64(left._scaledValue | right._scaledValue);
        public static ufix64 operator ~(ufix64 value) => new ufix64(~value._scaledValue);
        public static ufix64 operator +(ufix64 left, ufix64 right) => new ufix64(left._scaledValue + right._scaledValue);
        public static ufix64 operator +(ufix64 value) => value;
        public static ufix64 operator ++(ufix64 value) => new ufix64(value._scaledValue + ScalingFactor);
        public static ufix64 operator <<(ufix64 left, int right) => new ufix64(left._scaledValue << right);
        public static ufix64 operator >>(ufix64 left, int right) => new ufix64(left._scaledValue >> right);

        bool INumeric<ufix64>.IsGreaterThan(ufix64 value) => this > value;
        bool INumeric<ufix64>.IsGreaterThanOrEqualTo(ufix64 value) => this >= value;
        bool INumeric<ufix64>.IsLessThan(ufix64 value) => this < value;
        bool INumeric<ufix64>.IsLessThanOrEqualTo(ufix64 value) => this <= value;
        ufix64 INumeric<ufix64>.Add(ufix64 value) => this + value;
        ufix64 INumeric<ufix64>.BitwiseComplement() => ~this;
        ufix64 INumeric<ufix64>.Divide(ufix64 value) => this / value;
        ufix64 INumeric<ufix64>.LeftShift(int count) => this << count;
        ufix64 INumeric<ufix64>.LogicalAnd(ufix64 value) => this & value;
        ufix64 INumeric<ufix64>.LogicalExclusiveOr(ufix64 value) => this ^ value;
        ufix64 INumeric<ufix64>.LogicalOr(ufix64 value) => this | value;
        ufix64 INumeric<ufix64>.Multiply(ufix64 value) => this * value;
        ufix64 INumeric<ufix64>.Negative() => -this;
        ufix64 INumeric<ufix64>.Positive() => +this;
        ufix64 INumeric<ufix64>.Remainder(ufix64 value) => this % value;
        ufix64 INumeric<ufix64>.RightShift(int count) => this >> count;
        ufix64 INumeric<ufix64>.Subtract(ufix64 value) => this - value;

        IBitConverter<ufix64> IProvider<IBitConverter<ufix64>>.GetInstance() => Utilities.Instance;
        ICast<ufix64> IProvider<ICast<ufix64>>.GetInstance() => Utilities.Instance;
        IConvert<ufix64> IProvider<IConvert<ufix64>>.GetInstance() => Utilities.Instance;
        IMath<ufix64> IProvider<IMath<ufix64>>.GetInstance() => Utilities.Instance;
        INumericStatic<ufix64> IProvider<INumericStatic<ufix64>>.GetInstance() => Utilities.Instance;
        IRandom<ufix64> IProvider<IRandom<ufix64>>.GetInstance() => Utilities.Instance;
        IParser<ufix64> IProvider<IParser<ufix64>>.GetInstance() => Utilities.Instance;

        private sealed class Utilities :
            IBitConverter<ufix64>,
            ICast<ufix64>,
            IConvert<ufix64>,
            IMath<ufix64>,
            INumericStatic<ufix64>,
            IRandom<ufix64>,
            IParser<ufix64>
        {
            public static readonly Utilities Instance = new Utilities();

            bool INumericStatic<ufix64>.HasFloatingPoint { get; } = false;
            bool INumericStatic<ufix64>.HasInfinity { get; } = false;
            bool INumericStatic<ufix64>.HasNaN { get; } = false;
            bool INumericStatic<ufix64>.IsFinite(ufix64 x) => true;
            bool INumericStatic<ufix64>.IsInfinity(ufix64 x) => false;
            bool INumericStatic<ufix64>.IsNaN(ufix64 x) => false;
            bool INumericStatic<ufix64>.IsNegative(ufix64 x) => false;
            bool INumericStatic<ufix64>.IsNegativeInfinity(ufix64 x) => false;
            bool INumericStatic<ufix64>.IsNormal(ufix64 x) => false;
            bool INumericStatic<ufix64>.IsPositiveInfinity(ufix64 x) => false;
            bool INumericStatic<ufix64>.IsReal { get; } = true;
            bool INumericStatic<ufix64>.IsSigned { get; } = false;
            bool INumericStatic<ufix64>.IsSubnormal(ufix64 x) => false;
            ufix64 INumericStatic<ufix64>.Epsilon { get; } = new ufix64(1);
            ufix64 INumericStatic<ufix64>.MaxUnit { get; } = new ufix64(ScalingFactor);
            ufix64 INumericStatic<ufix64>.MaxValue => MaxValue;
            ufix64 INumericStatic<ufix64>.MinUnit { get; } = 0;
            ufix64 INumericStatic<ufix64>.MinValue => MinValue;
            ufix64 INumericStatic<ufix64>.One { get; } = new ufix64(ScalingFactor);
            ufix64 INumericStatic<ufix64>.Ten { get; } = new ufix64(10 * ScalingFactor);
            ufix64 INumericStatic<ufix64>.Two { get; } = new ufix64(2 * ScalingFactor);
            ufix64 INumericStatic<ufix64>.Zero { get; } = 0;

            int IMath<ufix64>.Sign(ufix64 x) => x._scaledValue == 0 ? 0 : 1;
            ufix64 IMath<ufix64>.Abs(ufix64 value) => value;
            ufix64 IMath<ufix64>.Acos(ufix64 x) => (ufix64)Math.Acos((double)x);
            ufix64 IMath<ufix64>.Acosh(ufix64 x) => (ufix64)MathCompat.Acosh((double)x);
            ufix64 IMath<ufix64>.Asin(ufix64 x) => (ufix64)Math.Asin((double)x);
            ufix64 IMath<ufix64>.Asinh(ufix64 x) => (ufix64)MathCompat.Asinh((double)x);
            ufix64 IMath<ufix64>.Atan(ufix64 x) => (ufix64)Math.Atan((double)x);
            ufix64 IMath<ufix64>.Atan2(ufix64 x, ufix64 y) => (ufix64)Math.Atan2((double)x, (double)y);
            ufix64 IMath<ufix64>.Atanh(ufix64 x) => (ufix64)MathCompat.Atanh((double)x);
            ufix64 IMath<ufix64>.Cbrt(ufix64 x) => (ufix64)MathCompat.Cbrt((double)x);
            ufix64 IMath<ufix64>.Ceiling(ufix64 x) => new ufix64(ScaledArithmetic.Ceiling(x._scaledValue, ScalingFactor));
            ufix64 IMath<ufix64>.Clamp(ufix64 x, ufix64 bound1, ufix64 bound2) => new ufix64(bound1 > bound2 ? Math.Min(bound1._scaledValue, Math.Max(bound2._scaledValue, x._scaledValue)) : Math.Min(bound2._scaledValue, Math.Max(bound1._scaledValue, x._scaledValue)));
            ufix64 IMath<ufix64>.Cos(ufix64 x) => (ufix64)Math.Cos((double)x);
            ufix64 IMath<ufix64>.Cosh(ufix64 x) => (ufix64)Math.Cosh((double)x);
            ufix64 IMath<ufix64>.DegreesToRadians(ufix64 x) => (ufix64)((double)x * NumericUtilities.RadiansPerDegree);
            ufix64 IMath<ufix64>.E { get; } = (ufix64)Math.E;
            ufix64 IMath<ufix64>.Exp(ufix64 x) => (ufix64)Math.Exp((double)x);
            ufix64 IMath<ufix64>.Floor(ufix64 x) => new ufix64(ScaledArithmetic.Floor(x._scaledValue, ScalingFactor));
            ufix64 IMath<ufix64>.IEEERemainder(ufix64 x, ufix64 y) => (ufix64)Math.IEEERemainder((double)x, (double)y);
            ufix64 IMath<ufix64>.Log(ufix64 x) => (ufix64)Math.Log((double)x);
            ufix64 IMath<ufix64>.Log(ufix64 x, ufix64 y) => (ufix64)Math.Log((double)x, (double)y);
            ufix64 IMath<ufix64>.Log10(ufix64 x) => (ufix64)Math.Log10((double)x);
            ufix64 IMath<ufix64>.Max(ufix64 x, ufix64 y) => new ufix64(Math.Max(x._scaledValue, y._scaledValue));
            ufix64 IMath<ufix64>.Min(ufix64 x, ufix64 y) => new ufix64(Math.Min(x._scaledValue, y._scaledValue));
            ufix64 IMath<ufix64>.PI { get; } = (ufix64)Math.PI;
            ufix64 IMath<ufix64>.Pow(ufix64 x, ufix64 y) => y == 1 ? x : (ufix64)Math.Pow((double)x, (double)y);
            ufix64 IMath<ufix64>.RadiansToDegrees(ufix64 x) => (ufix64)((double)x * NumericUtilities.DegreesPerRadian);
            ufix64 IMath<ufix64>.Round(ufix64 x) => Round(x, 0, MidpointRounding.ToEven);
            ufix64 IMath<ufix64>.Round(ufix64 x, int digits) => Round(x, digits, MidpointRounding.ToEven);
            ufix64 IMath<ufix64>.Round(ufix64 x, int digits, MidpointRounding mode) => Round(x, digits, mode);
            ufix64 IMath<ufix64>.Round(ufix64 x, MidpointRounding mode) => Round(x, 0, mode);
            ufix64 IMath<ufix64>.Sin(ufix64 x) => (ufix64)Math.Sin((double)x);
            ufix64 IMath<ufix64>.Sinh(ufix64 x) => (ufix64)Math.Sinh((double)x);
            ufix64 IMath<ufix64>.Sqrt(ufix64 x) => (ufix64)Math.Sqrt((double)x);
            ufix64 IMath<ufix64>.Tan(ufix64 x) => (ufix64)Math.Tan((double)x);
            ufix64 IMath<ufix64>.Tanh(ufix64 x) => (ufix64)Math.Tanh((double)x);
            ufix64 IMath<ufix64>.Tau { get; } = (ufix64)(Math.PI * 2d);
            ufix64 IMath<ufix64>.Truncate(ufix64 x) => new ufix64(x._scaledValue / ScalingFactor * ScalingFactor);

            ufix64 IBitConverter<ufix64>.Read(IReadOnlyStream<byte> stream) => new ufix64(BitConverter.ToUInt64(stream.Read(sizeof(ulong)), 0));
            void IBitConverter<ufix64>.Write(ufix64 value, IWriteOnlyStream<byte> stream) => stream.Write(BitConverter.GetBytes(value._scaledValue));

            ufix64 IRandom<ufix64>.Next(Random random) => new ufix64(random.NextUInt64());
            ufix64 IRandom<ufix64>.Next(Random random, ufix64 bound1, ufix64 bound2) => new ufix64(random.NextUInt64(bound1._scaledValue, bound2._scaledValue));

            bool IConvert<ufix64>.ToBoolean(ufix64 value) => value._scaledValue != 0;
            byte IConvert<ufix64>.ToByte(ufix64 value) => Convert.ToByte(value._scaledValue / ScalingFactor);
            decimal IConvert<ufix64>.ToDecimal(ufix64 value) => (decimal)value._scaledValue / ScalingFactor;
            double IConvert<ufix64>.ToDouble(ufix64 value) => (double)value._scaledValue / ScalingFactor;
            float IConvert<ufix64>.ToSingle(ufix64 value) => (float)value._scaledValue / ScalingFactor;
            int IConvert<ufix64>.ToInt32(ufix64 value) => Convert.ToInt32(value._scaledValue / ScalingFactor);
            long IConvert<ufix64>.ToInt64(ufix64 value) => Convert.ToInt64(value._scaledValue / ScalingFactor);
            sbyte IConvert<ufix64>.ToSByte(ufix64 value) => Convert.ToSByte(value._scaledValue / ScalingFactor);
            short IConvert<ufix64>.ToInt16(ufix64 value) => Convert.ToInt16(value._scaledValue / ScalingFactor);
            string IConvert<ufix64>.ToString(ufix64 value) => value.ToString();
            uint IConvert<ufix64>.ToUInt32(ufix64 value) => Convert.ToUInt32(value._scaledValue / ScalingFactor);
            ulong IConvert<ufix64>.ToUInt64(ufix64 value) => value._scaledValue / ScalingFactor;
            ushort IConvert<ufix64>.ToUInt16(ufix64 value) => Convert.ToUInt16(value._scaledValue / ScalingFactor);

            ufix64 IConvert<ufix64>.ToNumeric(bool value) => value ? new ufix64(ScalingFactor) : new ufix64(0);
            ufix64 IConvert<ufix64>.ToNumeric(byte value) => (ufix64)Convert.ToUInt64(value);
            ufix64 IConvert<ufix64>.ToNumeric(decimal value) => (ufix64)value;
            ufix64 IConvert<ufix64>.ToNumeric(double value) => (ufix64)value;
            ufix64 IConvert<ufix64>.ToNumeric(float value) => (ufix64)value;
            ufix64 IConvert<ufix64>.ToNumeric(int value) => (ufix64)Convert.ToUInt64(value);
            ufix64 IConvert<ufix64>.ToNumeric(long value) => (ufix64)value;
            ufix64 IConvert<ufix64>.ToNumeric(sbyte value) => (ufix64)Convert.ToUInt64(value);
            ufix64 IConvert<ufix64>.ToNumeric(short value) => (ufix64)Convert.ToUInt64(value);
            ufix64 IConvert<ufix64>.ToNumeric(string value) => (ufix64)Convert.ToUInt64(value);
            ufix64 IConvert<ufix64>.ToNumeric(uint value) => (ufix64)Convert.ToUInt64(value);
            ufix64 IConvert<ufix64>.ToNumeric(ulong value) => (ufix64)value;
            ufix64 IConvert<ufix64>.ToNumeric(ushort value) => (ufix64)Convert.ToUInt64(value);

            ufix64 IParser<ufix64>.Parse(string s) => Parse(s);
            ufix64 IParser<ufix64>.Parse(string s, NumberStyles style, IFormatProvider? provider) => Parse(s, style, provider);

            byte ICast<ufix64>.ToByte(ufix64 value) => (byte)value;
            decimal ICast<ufix64>.ToDecimal(ufix64 value) => (decimal)value;
            double ICast<ufix64>.ToDouble(ufix64 value) => (double)value;
            float ICast<ufix64>.ToSingle(ufix64 value) => (float)value;
            int ICast<ufix64>.ToInt32(ufix64 value) => (int)value;
            long ICast<ufix64>.ToInt64(ufix64 value) => (long)value;
            sbyte ICast<ufix64>.ToSByte(ufix64 value) => (sbyte)value;
            short ICast<ufix64>.ToInt16(ufix64 value) => (short)value;
            uint ICast<ufix64>.ToUInt32(ufix64 value) => (uint)value;
            ulong ICast<ufix64>.ToUInt64(ufix64 value) => (ulong)value;
            ushort ICast<ufix64>.ToUInt16(ufix64 value) => (ushort)value;

            ufix64 ICast<ufix64>.ToNumeric(byte value) => (ufix64)value;
            ufix64 ICast<ufix64>.ToNumeric(decimal value) => (ufix64)value;
            ufix64 ICast<ufix64>.ToNumeric(double value) => (ufix64)value;
            ufix64 ICast<ufix64>.ToNumeric(float value) => (ufix64)value;
            ufix64 ICast<ufix64>.ToNumeric(int value) => (ufix64)value;
            ufix64 ICast<ufix64>.ToNumeric(long value) => (ufix64)value;
            ufix64 ICast<ufix64>.ToNumeric(sbyte value) => (ufix64)value;
            ufix64 ICast<ufix64>.ToNumeric(short value) => (ufix64)value;
            ufix64 ICast<ufix64>.ToNumeric(uint value) => (ufix64)value;
            ufix64 ICast<ufix64>.ToNumeric(ulong value) => (ufix64)value;
            ufix64 ICast<ufix64>.ToNumeric(ushort value) => (ufix64)value;
        }
    }
}
