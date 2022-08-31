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
    /// Represents a single-precision floating-point number that cannot overflow.
    /// </summary>
    [Serializable]
    [DebuggerDisplay("{ToString(),nq}")]
    public readonly struct SingleC : INumericExtended<SingleC>
    {
        public static readonly SingleC Epsilon = new SingleC(float.Epsilon);
        public static readonly SingleC MaxValue = new SingleC(float.MaxValue);
        public static readonly SingleC MinValue = new SingleC(float.MinValue);

        private readonly float _value;

        public SingleC(float value)
        {
            _value = Check(value);
        }

        private SingleC(SerializationInfo info, StreamingContext context)
        {
            _value = Check(info.GetSingle(nameof(SingleC)));
        }

        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue(nameof(SingleC), _value);
        }

        public int CompareTo(SingleC other) => _value.CompareTo(other._value);
        public int CompareTo(object? obj) => obj is SingleC other ? CompareTo(other) : 1;
        public bool Equals(SingleC other) => _value == other._value;
        public override bool Equals(object? obj) => obj is SingleC other && Equals(other);
        public override int GetHashCode() => _value.GetHashCode();
        public override string ToString() => _value.ToString();
        public string ToString(IFormatProvider formatProvider) => _value.ToString(formatProvider);
        public string ToString(string format) => _value.ToString(format);
        public string ToString(string? format, IFormatProvider? formatProvider) => _value.ToString(format, formatProvider);

        public static bool IsNormal(SingleC d) => SingleCompat.IsNormal(d._value);
        public static bool IsSubnormal(SingleC d) => SingleCompat.IsSubnormal(d._value);
        public static bool TryParse(string s, IFormatProvider? provider, out SingleC result) => TryHelper.Run(() => Parse(s, provider), out result);
        public static bool TryParse(string s, NumberStyles style, IFormatProvider? provider, out SingleC result) => TryHelper.Run(() => Parse(s, style, provider), out result);
        public static bool TryParse(string s, NumberStyles style, out SingleC result) => TryHelper.Run(() => Parse(s, style), out result);
        public static bool TryParse(string s, out SingleC result) => TryHelper.Run(() => Parse(s), out result);
        public static SingleC Parse(string s) => float.Parse(s);
        public static SingleC Parse(string s, IFormatProvider? provider) => float.Parse(s, provider);
        public static SingleC Parse(string s, NumberStyles style) => float.Parse(s, style);
        public static SingleC Parse(string s, NumberStyles style, IFormatProvider? provider) => float.Parse(s, style, provider);

        [CLSCompliant(false)] public static implicit operator SingleC(sbyte value) => new SingleC(value);
        [CLSCompliant(false)] public static implicit operator SingleC(uint value) => new SingleC(value);
        [CLSCompliant(false)] public static implicit operator SingleC(ulong value) => new SingleC(value);
        [CLSCompliant(false)] public static implicit operator SingleC(ushort value) => new SingleC(value);
        public static explicit operator SingleC(decimal value) => new SingleC(ConvertN.ToSingle(value, Conversion.CastClamp));
        public static explicit operator SingleC(double value) => new SingleC(ConvertN.ToSingle(value, Conversion.CastClamp));
        public static implicit operator SingleC(byte value) => new SingleC(value);
        public static implicit operator SingleC(float value) => new SingleC(value);
        public static implicit operator SingleC(int value) => new SingleC(value);
        public static implicit operator SingleC(long value) => new SingleC(value);
        public static implicit operator SingleC(short value) => new SingleC(value);

        [CLSCompliant(false)] public static explicit operator sbyte(SingleC value) => ConvertN.ToSByte(value._value, Conversion.CastClamp);
        [CLSCompliant(false)] public static explicit operator uint(SingleC value) => ConvertN.ToUInt32(value._value, Conversion.CastClamp);
        [CLSCompliant(false)] public static explicit operator ulong(SingleC value) => ConvertN.ToUInt64(value._value, Conversion.CastClamp);
        [CLSCompliant(false)] public static explicit operator ushort(SingleC value) => ConvertN.ToUInt16(value._value, Conversion.CastClamp);
        public static explicit operator byte(SingleC value) => ConvertN.ToByte(value._value, Conversion.CastClamp);
        public static explicit operator decimal(SingleC value) => ConvertN.ToDecimal(value._value, Conversion.CastClamp);
        public static explicit operator int(SingleC value) => ConvertN.ToInt32(value._value, Conversion.CastClamp);
        public static explicit operator long(SingleC value) => ConvertN.ToInt64(value._value, Conversion.CastClamp);
        public static explicit operator short(SingleC value) => ConvertN.ToInt16(value._value, Conversion.CastClamp);
        public static implicit operator double(SingleC value) => value._value;
        public static implicit operator float(SingleC value) => value._value;

        public static bool operator !=(SingleC left, SingleC right) => left._value != right._value;
        public static bool operator <(SingleC left, SingleC right) => left._value < right._value;
        public static bool operator <=(SingleC left, SingleC right) => left._value <= right._value;
        public static bool operator ==(SingleC left, SingleC right) => left._value == right._value;
        public static bool operator >(SingleC left, SingleC right) => left._value > right._value;
        public static bool operator >=(SingleC left, SingleC right) => left._value >= right._value;
        public static SingleC operator %(SingleC left, SingleC right) => CheckedMath.Remainder(left._value, right._value);
        public static SingleC operator &(SingleC left, SingleC right) => BitOperations.LogicalAnd(left._value, right._value);
        public static SingleC operator -(SingleC left, SingleC right) => CheckedMath.Subtract(left._value, right._value);
        public static SingleC operator --(SingleC value) => value - 1;
        public static SingleC operator -(SingleC value) => -value._value;
        public static SingleC operator *(SingleC left, SingleC right) => CheckedMath.Multiply(left._value, right._value);
        public static SingleC operator /(SingleC left, SingleC right) => CheckedMath.Divide(left._value, right._value);
        public static SingleC operator ^(SingleC left, SingleC right) => BitOperations.LogicalExclusiveOr(left._value, right._value);
        public static SingleC operator |(SingleC left, SingleC right) => BitOperations.LogicalOr(left._value, right._value);
        public static SingleC operator ~(SingleC left) => BitOperations.BitwiseComplement(left._value);
        public static SingleC operator +(SingleC left, SingleC right) => CheckedMath.Add(left._value, right._value);
        public static SingleC operator +(SingleC value) => value;
        public static SingleC operator ++(SingleC value) => value + 1;
        public static SingleC operator <<(SingleC left, int right) => BitOperations.LeftShift(left._value, right);
        public static SingleC operator >>(SingleC left, int right) => BitOperations.RightShift(left._value, right);

        TypeCode IConvertible.GetTypeCode() => _value.GetTypeCode();
        bool IConvertible.ToBoolean(IFormatProvider provider) => Convert.ToBoolean(_value, provider);
        byte IConvertible.ToByte(IFormatProvider provider) => ConvertN.ToByte(_value, Conversion.Clamp);
        char IConvertible.ToChar(IFormatProvider provider) => Convert.ToChar(_value, provider);
        DateTime IConvertible.ToDateTime(IFormatProvider provider) => Convert.ToDateTime(provider);
        decimal IConvertible.ToDecimal(IFormatProvider provider) => ConvertN.ToDecimal(_value, Conversion.Clamp);
        double IConvertible.ToDouble(IFormatProvider provider) => ConvertN.ToDouble(_value, Conversion.Clamp);
        float IConvertible.ToSingle(IFormatProvider provider) => _value;
        int IConvertible.ToInt32(IFormatProvider provider) => ConvertN.ToInt32(_value, Conversion.Clamp);
        long IConvertible.ToInt64(IFormatProvider provider) => ConvertN.ToInt64(_value, Conversion.Clamp);
        sbyte IConvertible.ToSByte(IFormatProvider provider) => ConvertN.ToSByte(_value, Conversion.Clamp);
        short IConvertible.ToInt16(IFormatProvider provider) => ConvertN.ToInt16(_value, Conversion.Clamp);
        uint IConvertible.ToUInt32(IFormatProvider provider) => ConvertN.ToUInt32(_value, Conversion.Clamp);
        ulong IConvertible.ToUInt64(IFormatProvider provider) => ConvertN.ToUInt64(_value, Conversion.Clamp);
        ushort IConvertible.ToUInt16(IFormatProvider provider) => ConvertN.ToUInt16(_value, Conversion.Clamp);
        object IConvertible.ToType(Type conversionType, IFormatProvider provider) => this.ToTypeDefault(conversionType, provider);

        private static float Check(float value)
        {
            if (SingleCompat.IsFinite(value)) return value;
            else if (float.IsPositiveInfinity(value)) return float.MaxValue;
            else if (float.IsNegativeInfinity(value)) return float.MinValue;
            else return 0f;
        }

        bool INumeric<SingleC>.IsGreaterThan(SingleC value) => this > value;
        bool INumeric<SingleC>.IsGreaterThanOrEqualTo(SingleC value) => this >= value;
        bool INumeric<SingleC>.IsLessThan(SingleC value) => this < value;
        bool INumeric<SingleC>.IsLessThanOrEqualTo(SingleC value) => this <= value;
        SingleC INumeric<SingleC>.Add(SingleC value) => this + value;
        SingleC INumeric<SingleC>.BitwiseComplement() => ~this;
        SingleC INumeric<SingleC>.Divide(SingleC value) => this / value;
        SingleC INumeric<SingleC>.LeftShift(int count) => this << count;
        SingleC INumeric<SingleC>.LogicalAnd(SingleC value) => this & value;
        SingleC INumeric<SingleC>.LogicalExclusiveOr(SingleC value) => this ^ value;
        SingleC INumeric<SingleC>.LogicalOr(SingleC value) => this | value;
        SingleC INumeric<SingleC>.Multiply(SingleC value) => this * value;
        SingleC INumeric<SingleC>.Negative() => -this;
        SingleC INumeric<SingleC>.Positive() => +this;
        SingleC INumeric<SingleC>.Remainder(SingleC value) => this % value;
        SingleC INumeric<SingleC>.RightShift(int count) => this >> count;
        SingleC INumeric<SingleC>.Subtract(SingleC value) => this - value;

        INumericBitConverter<SingleC> IProvider<INumericBitConverter<SingleC>>.GetInstance() => Utilities.Instance;
        IConvert<SingleC> IProvider<IConvert<SingleC>>.GetInstance() => Utilities.Instance;
        IConvertExtended<SingleC> IProvider<IConvertExtended<SingleC>>.GetInstance() => Utilities.Instance;
        IMath<SingleC> IProvider<IMath<SingleC>>.GetInstance() => Utilities.Instance;
        INumericRandom<SingleC> IProvider<INumericRandom<SingleC>>.GetInstance() => Utilities.Instance;
        INumericStatic<SingleC> IProvider<INumericStatic<SingleC>>.GetInstance() => Utilities.Instance;
        IVariantRandom<SingleC> IProvider<IVariantRandom<SingleC>>.GetInstance() => Utilities.Instance;

        private sealed class Utilities :
            IConvert<SingleC>,
            IConvertExtended<SingleC>,
            IMath<SingleC>,
            INumericBitConverter<SingleC>,
            INumericRandom<SingleC>,
            INumericStatic<SingleC>,
            IVariantRandom<SingleC>
        {
            public static readonly Utilities Instance = new Utilities();

            bool INumericStatic<SingleC>.HasFloatingPoint => true;
            bool INumericStatic<SingleC>.HasInfinity => false;
            bool INumericStatic<SingleC>.HasNaN => false;
            bool INumericStatic<SingleC>.IsFinite(SingleC x) => true;
            bool INumericStatic<SingleC>.IsInfinity(SingleC x) => false;
            bool INumericStatic<SingleC>.IsNaN(SingleC x) => false;
            bool INumericStatic<SingleC>.IsNegative(SingleC x) => x._value < 0;
            bool INumericStatic<SingleC>.IsNegativeInfinity(SingleC x) => false;
            bool INumericStatic<SingleC>.IsNormal(SingleC x) => IsNormal(x);
            bool INumericStatic<SingleC>.IsPositiveInfinity(SingleC x) => false;
            bool INumericStatic<SingleC>.IsReal => true;
            bool INumericStatic<SingleC>.IsSigned => true;
            bool INumericStatic<SingleC>.IsSubnormal(SingleC x) => IsSubnormal(x);
            SingleC INumericStatic<SingleC>.Epsilon => Epsilon;
            SingleC INumericStatic<SingleC>.MaxUnit => 1;
            SingleC INumericStatic<SingleC>.MaxValue => MaxValue;
            SingleC INumericStatic<SingleC>.MinUnit => -1;
            SingleC INumericStatic<SingleC>.MinValue => MinValue;
            SingleC INumericStatic<SingleC>.One => 1;
            SingleC INumericStatic<SingleC>.Ten => 10;
            SingleC INumericStatic<SingleC>.Two => 2;
            SingleC INumericStatic<SingleC>.Zero => 0;

            SingleC IMath<SingleC>.Abs(SingleC value) => MathF.Abs(value._value);
            SingleC IMath<SingleC>.Acos(SingleC x) => MathF.Acos(x._value);
            SingleC IMath<SingleC>.Acosh(SingleC x) => MathF.Acosh(x._value);
            SingleC IMath<SingleC>.Asin(SingleC x) => MathF.Asin(x._value);
            SingleC IMath<SingleC>.Asinh(SingleC x) => MathF.Asinh(x._value);
            SingleC IMath<SingleC>.Atan(SingleC x) => MathF.Atan(x._value);
            SingleC IMath<SingleC>.Atan2(SingleC x, SingleC y) => MathF.Atan2(x._value, y._value);
            SingleC IMath<SingleC>.Atanh(SingleC x) => MathF.Atanh(x._value);
            SingleC IMath<SingleC>.Cbrt(SingleC x) => MathF.Cbrt(x._value);
            SingleC IMath<SingleC>.Ceiling(SingleC x) => MathF.Ceiling(x._value);
            SingleC IMath<SingleC>.Clamp(SingleC x, SingleC bound1, SingleC bound2) => bound1 > bound2 ? MathF.Min(bound1._value, MathF.Max(bound2._value, x._value)) : MathF.Min(bound2._value, MathF.Max(bound1._value, x._value));
            SingleC IMath<SingleC>.Cos(SingleC x) => MathF.Cos(x._value);
            SingleC IMath<SingleC>.Cosh(SingleC x) => MathF.Cosh(x._value);
            SingleC IMath<SingleC>.DegreesToRadians(SingleC x) => x._value * BitOperations.RadiansPerDegreeF;
            SingleC IMath<SingleC>.E { get; } = MathF.E;
            SingleC IMath<SingleC>.Exp(SingleC x) => MathF.Exp(x._value);
            SingleC IMath<SingleC>.Floor(SingleC x) => MathF.Floor(x._value);
            SingleC IMath<SingleC>.IEEERemainder(SingleC x, SingleC y) => MathF.IEEERemainder(x._value, y._value);
            SingleC IMath<SingleC>.Log(SingleC x) => MathF.Log(x._value);
            SingleC IMath<SingleC>.Log(SingleC x, SingleC y) => MathF.Log(x._value, y._value);
            SingleC IMath<SingleC>.Log10(SingleC x) => MathF.Log10(x._value);
            SingleC IMath<SingleC>.Max(SingleC x, SingleC y) => MathF.Max(x._value, y._value);
            SingleC IMath<SingleC>.Min(SingleC x, SingleC y) => MathF.Min(x._value, y._value);
            SingleC IMath<SingleC>.PI { get; } = MathF.PI;
            SingleC IMath<SingleC>.Pow(SingleC x, SingleC y) => MathF.Pow(x._value, y._value);
            SingleC IMath<SingleC>.RadiansToDegrees(SingleC x) => x._value * BitOperations.DegreesPerRadianF;
            SingleC IMath<SingleC>.Round(SingleC x) => MathF.Round(x._value);
            SingleC IMath<SingleC>.Round(SingleC x, int digits) => MathF.Round(x._value, digits);
            SingleC IMath<SingleC>.Round(SingleC x, int digits, MidpointRounding mode) => MathF.Round(x._value, digits, mode);
            SingleC IMath<SingleC>.Round(SingleC x, MidpointRounding mode) => MathF.Round(x._value, mode);
            SingleC IMath<SingleC>.Sin(SingleC x) => MathF.Sin(x._value);
            SingleC IMath<SingleC>.Sinh(SingleC x) => MathF.Sinh(x._value);
            SingleC IMath<SingleC>.Sqrt(SingleC x) => MathF.Sqrt(x._value);
            SingleC IMath<SingleC>.Tan(SingleC x) => MathF.Tan(x._value);
            SingleC IMath<SingleC>.Tanh(SingleC x) => MathF.Tanh(x._value);
            SingleC IMath<SingleC>.Tau { get; } = MathF.PI * 2f;
            SingleC IMath<SingleC>.Truncate(SingleC x) => MathF.Truncate(x._value);
            int IMath<SingleC>.Sign(SingleC x) => Math.Sign(x._value);

            int INumericBitConverter<SingleC>.ConvertedSize => sizeof(float);
            SingleC INumericBitConverter<SingleC>.ToNumeric(byte[] value, int startIndex) => BitConverter.ToSingle(value, startIndex);
            byte[] INumericBitConverter<SingleC>.GetBytes(SingleC value) => BitConverter.GetBytes(value._value);

            bool IConvert<SingleC>.ToBoolean(SingleC value) => value._value != 0;
            byte IConvert<SingleC>.ToByte(SingleC value, Conversion mode) => ConvertN.ToByte(value._value, mode.Clamped());
            decimal IConvert<SingleC>.ToDecimal(SingleC value, Conversion mode) => ConvertN.ToDecimal(value._value, mode.Clamped());
            double IConvert<SingleC>.ToDouble(SingleC value, Conversion mode) => ConvertN.ToDouble(value._value, mode.Clamped());
            float IConvert<SingleC>.ToSingle(SingleC value, Conversion mode) => value._value;
            int IConvert<SingleC>.ToInt32(SingleC value, Conversion mode) => ConvertN.ToInt32(value._value, mode.Clamped());
            long IConvert<SingleC>.ToInt64(SingleC value, Conversion mode) => ConvertN.ToInt64(value._value, mode.Clamped());
            sbyte IConvertExtended<SingleC>.ToSByte(SingleC value, Conversion mode) => ConvertN.ToSByte(value._value, mode.Clamped());
            short IConvert<SingleC>.ToInt16(SingleC value, Conversion mode) => ConvertN.ToInt16(value._value, mode.Clamped());
            string IConvert<SingleC>.ToString(SingleC value) => Convert.ToString(value._value);
            uint IConvertExtended<SingleC>.ToUInt32(SingleC value, Conversion mode) => ConvertN.ToUInt32(value._value, mode.Clamped());
            ulong IConvertExtended<SingleC>.ToUInt64(SingleC value, Conversion mode) => ConvertN.ToUInt64(value._value, mode.Clamped());
            ushort IConvertExtended<SingleC>.ToUInt16(SingleC value, Conversion mode) => ConvertN.ToUInt16(value._value, mode.Clamped());

            SingleC IConvert<SingleC>.ToNumeric(bool value) => value ? 1f : 0f;
            SingleC IConvert<SingleC>.ToNumeric(byte value, Conversion mode) => ConvertN.ToSingle(value, mode.Clamped());
            SingleC IConvert<SingleC>.ToNumeric(decimal value, Conversion mode) => ConvertN.ToSingle(value, mode.Clamped());
            SingleC IConvert<SingleC>.ToNumeric(double value, Conversion mode) => ConvertN.ToSingle(value, mode.Clamped());
            SingleC IConvert<SingleC>.ToNumeric(float value, Conversion mode) => value;
            SingleC IConvert<SingleC>.ToNumeric(int value, Conversion mode) => ConvertN.ToSingle(value, mode.Clamped());
            SingleC IConvert<SingleC>.ToNumeric(long value, Conversion mode) => ConvertN.ToSingle(value, mode.Clamped());
            SingleC IConvertExtended<SingleC>.ToValue(sbyte value, Conversion mode) => ConvertN.ToSingle(value, mode.Clamped());
            SingleC IConvert<SingleC>.ToNumeric(short value, Conversion mode) => ConvertN.ToSingle(value, mode.Clamped());
            SingleC IConvert<SingleC>.ToNumeric(string value) => Convert.ToSingle(value);
            SingleC IConvertExtended<SingleC>.ToNumeric(uint value, Conversion mode) => ConvertN.ToSingle(value, mode.Clamped());
            SingleC IConvertExtended<SingleC>.ToNumeric(ulong value, Conversion mode) => ConvertN.ToSingle(value, mode.Clamped());
            SingleC IConvertExtended<SingleC>.ToNumeric(ushort value, Conversion mode) => ConvertN.ToSingle(value, mode.Clamped());

            SingleC INumericStatic<SingleC>.Parse(string s, NumberStyles? style, IFormatProvider? provider)
                => Parse(s, style ?? NumberStyles.Float | NumberStyles.AllowThousands, provider);

            SingleC INumericRandom<SingleC>.Next(Random random) => random.NextSingle();
            SingleC INumericRandom<SingleC>.Next(Random random, SingleC maxValue) => random.NextSingle(maxValue);
            SingleC INumericRandom<SingleC>.Next(Random random, SingleC minValue, SingleC maxValue) => random.NextSingle(minValue, maxValue);
            SingleC INumericRandom<SingleC>.Next(Random random, Generation mode) => random.NextSingle(mode);
            SingleC INumericRandom<SingleC>.Next(Random random, SingleC minValue, SingleC maxValue, Generation mode) => random.NextSingle(minValue, maxValue, mode);

            SingleC IVariantRandom<SingleC>.Next(Random random, Scenarios scenarios) => NumericVariant.Generate<SingleC>(random, scenarios);
        }
    }
}
