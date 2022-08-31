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
using System.Globalization;
using System.Runtime.Serialization;
using Jodo.Numerics;
using Jodo.Primitives;
using Jodo.Primitives.Compatibility;

namespace Jodo.CheckedNumerics
{
    /// <summary>
    /// Represents a double-precision floating-point number that cannot overflow.
    /// </summary>
    [Serializable]
    [DebuggerDisplay("{ToString(),nq}")]
    public readonly struct DoubleC : INumericExtended<DoubleC>
    {
        public static readonly DoubleC Epsilon = double.Epsilon;
        public static readonly DoubleC MaxValue = double.MaxValue;
        public static readonly DoubleC MinValue = double.MinValue;

        private readonly double _value;

        public DoubleC(double value)
        {
            _value = Check(value);
        }

        private DoubleC(SerializationInfo info, StreamingContext context)
        {
            _value = Check(info.GetDouble(nameof(DoubleC)));
        }

        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue(nameof(DoubleC), _value);
        }

        public int CompareTo(DoubleC other) => _value.CompareTo(other._value);
        public int CompareTo(object? obj) => obj is DoubleC other ? CompareTo(other) : 1;
        public bool Equals(DoubleC other) => _value == other._value;
        public override bool Equals(object? obj) => obj is DoubleC other && Equals(other);
        public override int GetHashCode() => _value.GetHashCode();
        public override string ToString() => _value.ToString();
        public string ToString(IFormatProvider formatProvider) => _value.ToString(formatProvider);
        public string ToString(string format) => _value.ToString(format);
        public string ToString(string? format, IFormatProvider? formatProvider) => _value.ToString(format, formatProvider);

        public static bool IsNormal(DoubleC d) => DoubleCompat.IsNormal(d._value);
        public static bool IsSubnormal(DoubleC d) => DoubleCompat.IsSubnormal(d._value);
        public static bool TryParse(string s, IFormatProvider? provider, out DoubleC result) => TryHelper.Run(() => Parse(s, provider), out result);
        public static bool TryParse(string s, NumberStyles style, IFormatProvider? provider, out DoubleC result) => TryHelper.Run(() => Parse(s, style, provider), out result);
        public static bool TryParse(string s, NumberStyles style, out DoubleC result) => TryHelper.Run(() => Parse(s, style), out result);
        public static bool TryParse(string s, out DoubleC result) => TryHelper.Run(() => Parse(s), out result);
        public static DoubleC Parse(string s) => double.Parse(s);
        public static DoubleC Parse(string s, IFormatProvider? provider) => double.Parse(s, provider);
        public static DoubleC Parse(string s, NumberStyles style) => double.Parse(s, style);
        public static DoubleC Parse(string s, NumberStyles style, IFormatProvider? provider) => double.Parse(s, style, provider);

        [CLSCompliant(false)] public static implicit operator DoubleC(sbyte value) => new DoubleC(value);
        [CLSCompliant(false)] public static implicit operator DoubleC(uint value) => new DoubleC(value);
        [CLSCompliant(false)] public static implicit operator DoubleC(ulong value) => new DoubleC(value);
        [CLSCompliant(false)] public static implicit operator DoubleC(ushort value) => new DoubleC(value);
        public static explicit operator DoubleC(decimal value) => new DoubleC(ConvertN.ToDouble(value, Conversion.CastClamp));
        public static implicit operator DoubleC(byte value) => new DoubleC(value);
        public static implicit operator DoubleC(double value) => new DoubleC(value);
        public static implicit operator DoubleC(float value) => new DoubleC(value);
        public static implicit operator DoubleC(int value) => new DoubleC(value);
        public static implicit operator DoubleC(long value) => new DoubleC(value);
        public static implicit operator DoubleC(short value) => new DoubleC(value);

        [CLSCompliant(false)] public static explicit operator sbyte(DoubleC value) => ConvertN.ToSByte(value._value, Conversion.CastClamp);
        [CLSCompliant(false)] public static explicit operator uint(DoubleC value) => ConvertN.ToUInt32(value._value, Conversion.CastClamp);
        [CLSCompliant(false)] public static explicit operator ulong(DoubleC value) => ConvertN.ToUInt64(value._value, Conversion.CastClamp);
        [CLSCompliant(false)] public static explicit operator ushort(DoubleC value) => ConvertN.ToUInt16(value._value, Conversion.CastClamp);
        public static explicit operator byte(DoubleC value) => ConvertN.ToByte(value._value, Conversion.CastClamp);
        public static explicit operator decimal(DoubleC value) => ConvertN.ToDecimal(value._value, Conversion.CastClamp);
        public static explicit operator float(DoubleC value) => ConvertN.ToSingle(value._value, Conversion.CastClamp);
        public static explicit operator int(DoubleC value) => ConvertN.ToInt32(value._value, Conversion.CastClamp);
        public static explicit operator long(DoubleC value) => ConvertN.ToInt64(value._value, Conversion.CastClamp);
        public static explicit operator short(DoubleC value) => ConvertN.ToInt16(value._value, Conversion.CastClamp);
        public static implicit operator double(DoubleC value) => value._value;

        public static bool operator !=(DoubleC left, DoubleC right) => left._value != right._value;
        public static bool operator <(DoubleC left, DoubleC right) => left._value < right._value;
        public static bool operator <=(DoubleC left, DoubleC right) => left._value <= right._value;
        public static bool operator ==(DoubleC left, DoubleC right) => left._value == right._value;
        public static bool operator >(DoubleC left, DoubleC right) => left._value > right._value;
        public static bool operator >=(DoubleC left, DoubleC right) => left._value >= right._value;
        public static DoubleC operator %(DoubleC left, DoubleC right) => CheckedMath.Remainder(left._value, right._value);
        public static DoubleC operator -(DoubleC left, DoubleC right) => CheckedMath.Subtract(left._value, right._value);
        public static DoubleC operator --(DoubleC value) => value - 1;
        public static DoubleC operator -(DoubleC value) => -value._value;
        public static DoubleC operator *(DoubleC left, DoubleC right) => CheckedMath.Multiply(left._value, right._value);
        public static DoubleC operator /(DoubleC left, DoubleC right) => CheckedMath.Divide(left._value, right._value);
        public static DoubleC operator +(DoubleC left, DoubleC right) => CheckedMath.Add(left._value, right._value);
        public static DoubleC operator +(DoubleC value) => value;
        public static DoubleC operator ++(DoubleC value) => value + 1;
        public static DoubleC operator &(DoubleC left, DoubleC right) => BitOperations.LogicalAnd(left._value, right._value);
        public static DoubleC operator |(DoubleC left, DoubleC right) => BitOperations.LogicalOr(left._value, right._value);
        public static DoubleC operator ^(DoubleC left, DoubleC right) => BitOperations.LogicalExclusiveOr(left._value, right._value);
        public static DoubleC operator ~(DoubleC left) => BitOperations.BitwiseComplement(left._value);
        public static DoubleC operator >>(DoubleC left, int right) => BitOperations.RightShift(left._value, right);
        public static DoubleC operator <<(DoubleC left, int right) => BitOperations.LeftShift(left._value, right);

        TypeCode IConvertible.GetTypeCode() => _value.GetTypeCode();
        bool IConvertible.ToBoolean(IFormatProvider provider) => Convert.ToBoolean(_value, provider);
        byte IConvertible.ToByte(IFormatProvider provider) => ConvertN.ToByte(_value, Conversion.Clamp);
        char IConvertible.ToChar(IFormatProvider provider) => Convert.ToChar(_value, provider);
        DateTime IConvertible.ToDateTime(IFormatProvider provider) => Convert.ToDateTime(provider);
        decimal IConvertible.ToDecimal(IFormatProvider provider) => ConvertN.ToDecimal(_value, Conversion.Clamp);
        double IConvertible.ToDouble(IFormatProvider provider) => _value;
        float IConvertible.ToSingle(IFormatProvider provider) => ConvertN.ToSingle(_value, Conversion.Clamp);
        int IConvertible.ToInt32(IFormatProvider provider) => ConvertN.ToInt32(_value, Conversion.Clamp);
        long IConvertible.ToInt64(IFormatProvider provider) => ConvertN.ToInt64(_value, Conversion.Clamp);
        sbyte IConvertible.ToSByte(IFormatProvider provider) => ConvertN.ToSByte(_value, Conversion.Clamp);
        short IConvertible.ToInt16(IFormatProvider provider) => ConvertN.ToInt16(_value, Conversion.Clamp);
        uint IConvertible.ToUInt32(IFormatProvider provider) => ConvertN.ToUInt32(_value, Conversion.Clamp);
        ulong IConvertible.ToUInt64(IFormatProvider provider) => ConvertN.ToUInt64(_value, Conversion.Clamp);
        ushort IConvertible.ToUInt16(IFormatProvider provider) => ConvertN.ToUInt16(_value, Conversion.Clamp);
        object IConvertible.ToType(Type conversionType, IFormatProvider provider) => this.ToTypeDefault(conversionType, provider);

        private static double Check(double value)
        {
            if (DoubleCompat.IsFinite(value)) return value;
            else if (double.IsPositiveInfinity(value)) return double.MaxValue;
            else if (double.IsNegativeInfinity(value)) return double.MinValue;
            else return 0d;
        }

        bool INumeric<DoubleC>.IsGreaterThan(DoubleC value) => this > value;
        bool INumeric<DoubleC>.IsGreaterThanOrEqualTo(DoubleC value) => this >= value;
        bool INumeric<DoubleC>.IsLessThan(DoubleC value) => this < value;
        bool INumeric<DoubleC>.IsLessThanOrEqualTo(DoubleC value) => this <= value;
        DoubleC INumeric<DoubleC>.Add(DoubleC value) => this + value;
        DoubleC INumeric<DoubleC>.BitwiseComplement() => ~this;
        DoubleC INumeric<DoubleC>.Divide(DoubleC value) => this / value;
        DoubleC INumeric<DoubleC>.LeftShift(int count) => this << count;
        DoubleC INumeric<DoubleC>.LogicalAnd(DoubleC value) => this & value;
        DoubleC INumeric<DoubleC>.LogicalExclusiveOr(DoubleC value) => this ^ value;
        DoubleC INumeric<DoubleC>.LogicalOr(DoubleC value) => this | value;
        DoubleC INumeric<DoubleC>.Multiply(DoubleC value) => this * value;
        DoubleC INumeric<DoubleC>.Negative() => -this;
        DoubleC INumeric<DoubleC>.Positive() => +this;
        DoubleC INumeric<DoubleC>.Remainder(DoubleC value) => this % value;
        DoubleC INumeric<DoubleC>.RightShift(int count) => this >> count;
        DoubleC INumeric<DoubleC>.Subtract(DoubleC value) => this - value;

        INumericBitConverter<DoubleC> IProvider<INumericBitConverter<DoubleC>>.GetInstance() => Utilities.Instance;
        IConvert<DoubleC> IProvider<IConvert<DoubleC>>.GetInstance() => Utilities.Instance;
        IConvertExtended<DoubleC> IProvider<IConvertExtended<DoubleC>>.GetInstance() => Utilities.Instance;
        IMath<DoubleC> IProvider<IMath<DoubleC>>.GetInstance() => Utilities.Instance;
        INumericRandom<DoubleC> IProvider<INumericRandom<DoubleC>>.GetInstance() => Utilities.Instance;
        INumericStatic<DoubleC> IProvider<INumericStatic<DoubleC>>.GetInstance() => Utilities.Instance;
        IVariantRandom<DoubleC> IProvider<IVariantRandom<DoubleC>>.GetInstance() => Utilities.Instance;

        private sealed class Utilities :
            IConvert<DoubleC>,
            IConvertExtended<DoubleC>,
            IMath<DoubleC>,
            INumericBitConverter<DoubleC>,
            INumericRandom<DoubleC>,
            INumericStatic<DoubleC>,
            IVariantRandom<DoubleC>
        {
            public static readonly Utilities Instance = new Utilities();

            bool INumericStatic<DoubleC>.HasFloatingPoint => true;
            bool INumericStatic<DoubleC>.HasInfinity => false;
            bool INumericStatic<DoubleC>.HasNaN => false;
            bool INumericStatic<DoubleC>.IsFinite(DoubleC x) => true;
            bool INumericStatic<DoubleC>.IsInfinity(DoubleC x) => false;
            bool INumericStatic<DoubleC>.IsNaN(DoubleC x) => false;
            bool INumericStatic<DoubleC>.IsNegative(DoubleC x) => x._value < 0;
            bool INumericStatic<DoubleC>.IsNegativeInfinity(DoubleC x) => false;
            bool INumericStatic<DoubleC>.IsNormal(DoubleC x) => IsNormal(x);
            bool INumericStatic<DoubleC>.IsPositiveInfinity(DoubleC x) => false;
            bool INumericStatic<DoubleC>.IsReal => true;
            bool INumericStatic<DoubleC>.IsSigned => true;
            bool INumericStatic<DoubleC>.IsSubnormal(DoubleC x) => IsSubnormal(x);
            DoubleC INumericStatic<DoubleC>.Epsilon => Epsilon;
            DoubleC INumericStatic<DoubleC>.MaxUnit => 1d;
            DoubleC INumericStatic<DoubleC>.MaxValue => MaxValue;
            DoubleC INumericStatic<DoubleC>.MinUnit => -1d;
            DoubleC INumericStatic<DoubleC>.MinValue => MinValue;
            DoubleC INumericStatic<DoubleC>.One => 1d;
            DoubleC INumericStatic<DoubleC>.Ten => 10d;
            DoubleC INumericStatic<DoubleC>.Two => 2d;
            DoubleC INumericStatic<DoubleC>.Zero => 0d;

            DoubleC IMath<DoubleC>.Abs(DoubleC value) => Math.Abs(value._value);
            DoubleC IMath<DoubleC>.Acos(DoubleC x) => Math.Acos(x._value);
            DoubleC IMath<DoubleC>.Acosh(DoubleC x) => MathCompat.Acosh(x._value);
            DoubleC IMath<DoubleC>.Asin(DoubleC x) => Math.Asin(x._value);
            DoubleC IMath<DoubleC>.Asinh(DoubleC x) => MathCompat.Asinh(x._value);
            DoubleC IMath<DoubleC>.Atan(DoubleC x) => Math.Atan(x._value);
            DoubleC IMath<DoubleC>.Atan2(DoubleC x, DoubleC y) => Math.Atan2(x._value, y._value);
            DoubleC IMath<DoubleC>.Atanh(DoubleC x) => MathCompat.Atanh(x._value);
            DoubleC IMath<DoubleC>.Cbrt(DoubleC x) => MathCompat.Cbrt(x._value);
            DoubleC IMath<DoubleC>.Ceiling(DoubleC x) => Math.Ceiling(x._value);
            DoubleC IMath<DoubleC>.Clamp(DoubleC x, DoubleC bound1, DoubleC bound2) => bound1 > bound2 ? Math.Min(bound1._value, Math.Max(bound2._value, x._value)) : Math.Min(bound2._value, Math.Max(bound1._value, x._value));
            DoubleC IMath<DoubleC>.Cos(DoubleC x) => Math.Cos(x._value);
            DoubleC IMath<DoubleC>.Cosh(DoubleC x) => Math.Cosh(x._value);
            DoubleC IMath<DoubleC>.DegreesToRadians(DoubleC degrees) => degrees * BitOperations.RadiansPerDegree;
            DoubleC IMath<DoubleC>.E { get; } = Math.E;
            DoubleC IMath<DoubleC>.Exp(DoubleC x) => Math.Exp(x._value);
            DoubleC IMath<DoubleC>.Floor(DoubleC x) => Math.Floor(x._value);
            DoubleC IMath<DoubleC>.IEEERemainder(DoubleC x, DoubleC y) => Math.IEEERemainder(x._value, y._value);
            DoubleC IMath<DoubleC>.Log(DoubleC x) => Math.Log(x._value);
            DoubleC IMath<DoubleC>.Log(DoubleC x, DoubleC y) => Math.Log(x._value, y._value);
            DoubleC IMath<DoubleC>.Log10(DoubleC x) => Math.Log10(x._value);
            DoubleC IMath<DoubleC>.Max(DoubleC x, DoubleC y) => Math.Max(x._value, y._value);
            DoubleC IMath<DoubleC>.Min(DoubleC x, DoubleC y) => Math.Min(x._value, y._value);
            DoubleC IMath<DoubleC>.PI { get; } = Math.PI;
            DoubleC IMath<DoubleC>.Pow(DoubleC x, DoubleC y) => Math.Pow(x._value, y._value);
            DoubleC IMath<DoubleC>.RadiansToDegrees(DoubleC radians) => radians * BitOperations.DegreesPerRadian;
            DoubleC IMath<DoubleC>.Round(DoubleC x) => Math.Round(x._value);
            DoubleC IMath<DoubleC>.Round(DoubleC x, int digits) => Math.Round(x._value, digits);
            DoubleC IMath<DoubleC>.Round(DoubleC x, int digits, MidpointRounding mode) => Math.Round(x._value, digits, mode);
            DoubleC IMath<DoubleC>.Round(DoubleC x, MidpointRounding mode) => Math.Round(x._value, mode);
            DoubleC IMath<DoubleC>.Sin(DoubleC x) => Math.Sin(x._value);
            DoubleC IMath<DoubleC>.Sinh(DoubleC x) => Math.Sinh(x._value);
            DoubleC IMath<DoubleC>.Sqrt(DoubleC x) => Math.Sqrt(x._value);
            DoubleC IMath<DoubleC>.Tan(DoubleC x) => Math.Tan(x._value);
            DoubleC IMath<DoubleC>.Tanh(DoubleC x) => Math.Tanh(x._value);
            DoubleC IMath<DoubleC>.Tau { get; } = Math.PI * 2d;
            DoubleC IMath<DoubleC>.Truncate(DoubleC x) => Math.Truncate(x._value);
            int IMath<DoubleC>.Sign(DoubleC x) => Math.Sign(x._value);

            int INumericBitConverter<DoubleC>.ConvertedSize => sizeof(double);
            DoubleC INumericBitConverter<DoubleC>.ToNumeric(byte[] value, int startIndex) => BitConverter.ToDouble(value, startIndex);
            byte[] INumericBitConverter<DoubleC>.GetBytes(DoubleC value) => BitConverter.GetBytes(value._value);

            bool IConvert<DoubleC>.ToBoolean(DoubleC value) => value._value != 0;
            byte IConvert<DoubleC>.ToByte(DoubleC value, Conversion mode) => ConvertN.ToByte(value._value, mode.Clamped());
            decimal IConvert<DoubleC>.ToDecimal(DoubleC value, Conversion mode) => ConvertN.ToDecimal(value._value, mode.Clamped());
            double IConvert<DoubleC>.ToDouble(DoubleC value, Conversion mode) => value._value;
            float IConvert<DoubleC>.ToSingle(DoubleC value, Conversion mode) => ConvertN.ToSingle(value._value, mode.Clamped());
            int IConvert<DoubleC>.ToInt32(DoubleC value, Conversion mode) => ConvertN.ToInt32(value._value, mode.Clamped());
            long IConvert<DoubleC>.ToInt64(DoubleC value, Conversion mode) => ConvertN.ToInt64(value._value, mode.Clamped());
            sbyte IConvertExtended<DoubleC>.ToSByte(DoubleC value, Conversion mode) => ConvertN.ToSByte(value._value, mode.Clamped());
            short IConvert<DoubleC>.ToInt16(DoubleC value, Conversion mode) => ConvertN.ToInt16(value._value, mode.Clamped());
            string IConvert<DoubleC>.ToString(DoubleC value) => Convert.ToString(value._value);
            uint IConvertExtended<DoubleC>.ToUInt32(DoubleC value, Conversion mode) => ConvertN.ToUInt32(value._value, mode.Clamped());
            ulong IConvertExtended<DoubleC>.ToUInt64(DoubleC value, Conversion mode) => ConvertN.ToUInt64(value._value, mode.Clamped());
            ushort IConvertExtended<DoubleC>.ToUInt16(DoubleC value, Conversion mode) => ConvertN.ToUInt16(value._value, mode.Clamped());

            DoubleC IConvert<DoubleC>.ToNumeric(bool value) => value ? 1d : 0d;
            DoubleC IConvert<DoubleC>.ToNumeric(byte value, Conversion mode) => ConvertN.ToDouble(value, mode.Clamped());
            DoubleC IConvert<DoubleC>.ToNumeric(decimal value, Conversion mode) => ConvertN.ToDouble(value, mode.Clamped());
            DoubleC IConvert<DoubleC>.ToNumeric(double value, Conversion mode) => value;
            DoubleC IConvert<DoubleC>.ToNumeric(float value, Conversion mode) => ConvertN.ToDouble(value, mode.Clamped());
            DoubleC IConvert<DoubleC>.ToNumeric(int value, Conversion mode) => ConvertN.ToDouble(value, mode.Clamped());
            DoubleC IConvert<DoubleC>.ToNumeric(long value, Conversion mode) => ConvertN.ToDouble(value, mode.Clamped());
            DoubleC IConvertExtended<DoubleC>.ToValue(sbyte value, Conversion mode) => ConvertN.ToDouble(value, mode.Clamped());
            DoubleC IConvert<DoubleC>.ToNumeric(short value, Conversion mode) => ConvertN.ToDouble(value, mode.Clamped());
            DoubleC IConvert<DoubleC>.ToNumeric(string value) => Convert.ToDouble(value);
            DoubleC IConvertExtended<DoubleC>.ToNumeric(uint value, Conversion mode) => ConvertN.ToDouble(value, mode.Clamped());
            DoubleC IConvertExtended<DoubleC>.ToNumeric(ulong value, Conversion mode) => ConvertN.ToDouble(value, mode.Clamped());
            DoubleC IConvertExtended<DoubleC>.ToNumeric(ushort value, Conversion mode) => ConvertN.ToDouble(value, mode.Clamped());

            DoubleC INumericStatic<DoubleC>.Parse(string s, NumberStyles? style, IFormatProvider? provider)
                => Parse(s, style ?? NumberStyles.Float | NumberStyles.AllowThousands, provider);

            DoubleC INumericRandom<DoubleC>.Next(Random random) => random.NextDouble();
            DoubleC INumericRandom<DoubleC>.Next(Random random, DoubleC maxValue) => random.NextDouble(maxValue);
            DoubleC INumericRandom<DoubleC>.Next(Random random, DoubleC minValue, DoubleC maxValue) => random.NextDouble(minValue, maxValue);
            DoubleC INumericRandom<DoubleC>.Next(Random random, Generation mode) => random.NextDouble(mode);
            DoubleC INumericRandom<DoubleC>.Next(Random random, DoubleC minValue, DoubleC maxValue, Generation mode) => random.NextDouble(minValue, maxValue, mode);

            DoubleC IVariantRandom<DoubleC>.Next(Random random, Scenarios scenarios) => NumericVariant.Generate<DoubleC>(random, scenarios);
        }
    }
}
