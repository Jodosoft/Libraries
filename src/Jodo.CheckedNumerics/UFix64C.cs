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
using Jodo.Numerics;
using Jodo.Primitives;
using Jodo.Primitives.Compatibility;

namespace Jodo.CheckedNumerics
{
    /// <summary>
    /// Represents a decimal fixed-point unsigned number that cannot overflow.
    /// </summary>
    [Serializable]
    [DebuggerDisplay("{ToString(),nq}")]
    public readonly struct UFix64C : INumericNonCLS<UFix64C>
    {
        public static readonly UFix64C Epsilon = new UFix64C(1);
        public static readonly UFix64C MaxValue = new UFix64C(ulong.MaxValue);
        public static readonly UFix64C MinValue = new UFix64C(ulong.MinValue);

        private const ulong ScalingFactor = 1_000_000;

        private readonly ulong _scaledValue;

        private UFix64C(ulong scaledValue)
        {
            _scaledValue = scaledValue;
        }

        private UFix64C(SerializationInfo info, StreamingContext context) : this(info.GetUInt64(nameof(UFix64C))) { }
        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context) => info.AddValue(nameof(UFix64C), _scaledValue);

        public int CompareTo(object? obj) => obj is UFix64C other ? CompareTo(other) : 1;
        public int CompareTo(UFix64C other) => _scaledValue.CompareTo(other._scaledValue);
        public bool Equals(UFix64C other) => _scaledValue == other._scaledValue;
        public override bool Equals(object? obj) => obj is UFix64C other && Equals(other);
        public override int GetHashCode() => _scaledValue.GetHashCode();
        public override string ToString() => ScaledArithmetic.ToString(_scaledValue, ScalingFactor);
        public string ToString(IFormatProvider formatProvider) => ((double)this).ToString(formatProvider);
        public string ToString(string format) => ((double)this).ToString(format);
        public string ToString(string? format, IFormatProvider? formatProvider) => ((double)this).ToString(format, formatProvider);

        public static bool TryParse(string s, IFormatProvider? provider, out UFix64C result) => Try.Run(() => Parse(s, provider), out result);
        public static bool TryParse(string s, NumberStyles style, IFormatProvider? provider, out UFix64C result) => Try.Run(() => Parse(s, style, provider), out result);
        public static bool TryParse(string s, NumberStyles style, out UFix64C result) => Try.Run(() => Parse(s, style), out result);
        public static bool TryParse(string s, out UFix64C result) => Try.Run(() => Parse(s), out result);
        public static UFix64C Parse(string s) => new UFix64C(ScaledArithmetic.Parse(s, ScalingFactor));
        public static UFix64C Parse(string s, IFormatProvider? provider) => (UFix64C)double.Parse(s, provider);
        public static UFix64C Parse(string s, NumberStyles style) => (UFix64C)double.Parse(s, style);
        public static UFix64C Parse(string s, NumberStyles style, IFormatProvider? provider) => (UFix64C)double.Parse(s, style, provider);

        private static UFix64C Round(UFix64C value, int digits, MidpointRounding mode)
        {
            if (digits < 0) throw new ArgumentOutOfRangeException(nameof(digits), digits, "Must be positive.");
            if (digits > 5) return value;
            return new UFix64C(ScaledArithmetic.Round(value._scaledValue, 6 - digits, mode));
        }

        private static UFix64C FromDouble(double value)
        {
            string str = string
                .Format(CultureInfo.InvariantCulture, "{0:0.0000000}", value)
                .Replace(".", string.Empty);
            str = str.Substring(0, str.Length - 1);
            if (ulong.TryParse(str, out ulong lng))
            {
                return new UFix64C(lng);
            }
            else
            {
                if (value > 0) return MaxValue;
                return MinValue;
            }
        }

        private static double ToDouble(UFix64C value)
        {
            ulong integral = value._scaledValue / ScalingFactor;
            ulong mantissa = value._scaledValue % ScalingFactor;

            double result = (double)mantissa / ScalingFactor;
            result += integral;
            return result;
        }

        [CLSCompliant(false)] public static explicit operator UFix64C(sbyte value) => new UFix64C(NumericConvert.ToUInt64(value, Conversion.CastClamp) * ScalingFactor);
        [CLSCompliant(false)] public static explicit operator UFix64C(ulong value) => new UFix64C(value * ScalingFactor);
        [CLSCompliant(false)] public static implicit operator UFix64C(uint value) => new UFix64C(NumericConvert.ToUInt64(value, Conversion.CastClamp) * ScalingFactor);
        [CLSCompliant(false)] public static implicit operator UFix64C(ushort value) => new UFix64C(NumericConvert.ToUInt64(value, Conversion.CastClamp) * ScalingFactor);
        public static explicit operator UFix64C(decimal value) => value < 0 ? new UFix64C(0) : new UFix64C(NumericConvert.ToUInt64(value * ScalingFactor, Conversion.CastClamp));
        public static explicit operator UFix64C(double value) => value < 0 ? new UFix64C(0) : FromDouble(value);
        public static explicit operator UFix64C(float value) => value < 0 ? new UFix64C(0) : new UFix64C(NumericConvert.ToUInt64(value * ScalingFactor, Conversion.CastClamp));
        public static explicit operator UFix64C(int value) => new UFix64C(NumericConvert.ToUInt64(value, Conversion.CastClamp) * ScalingFactor);
        public static explicit operator UFix64C(long value) => new UFix64C(NumericConvert.ToUInt64(value, Conversion.CastClamp) * ScalingFactor);
        public static explicit operator UFix64C(short value) => new UFix64C(NumericConvert.ToUInt64(value, Conversion.CastClamp) * ScalingFactor);
        public static implicit operator UFix64C(byte value) => new UFix64C(value * ScalingFactor);

        [CLSCompliant(false)] public static explicit operator sbyte(UFix64C value) => NumericConvert.ToSByte(value._scaledValue / ScalingFactor, Conversion.CastClamp);
        [CLSCompliant(false)] public static explicit operator uint(UFix64C value) => NumericConvert.ToUInt32(value._scaledValue / ScalingFactor, Conversion.CastClamp);
        [CLSCompliant(false)] public static explicit operator ulong(UFix64C value) => value._scaledValue / ScalingFactor;
        [CLSCompliant(false)] public static explicit operator ushort(UFix64C value) => NumericConvert.ToUInt16(value._scaledValue / ScalingFactor, Conversion.CastClamp);
        public static explicit operator byte(UFix64C value) => NumericConvert.ToByte(value._scaledValue / ScalingFactor, Conversion.CastClamp);
        public static explicit operator decimal(UFix64C value) => (decimal)value._scaledValue / ScalingFactor;
        public static explicit operator double(UFix64C value) => ToDouble(value);
        public static explicit operator float(UFix64C value) => (float)value._scaledValue / ScalingFactor;
        public static explicit operator int(UFix64C value) => NumericConvert.ToInt32(value._scaledValue / ScalingFactor, Conversion.CastClamp);
        public static explicit operator long(UFix64C value) => NumericConvert.ToInt64(value._scaledValue / ScalingFactor, Conversion.CastClamp);
        public static explicit operator short(UFix64C value) => NumericConvert.ToInt16(value._scaledValue / ScalingFactor, Conversion.CastClamp);

        public static bool operator !=(UFix64C left, UFix64C right) => left._scaledValue != right._scaledValue;
        public static bool operator <(UFix64C left, UFix64C right) => left._scaledValue < right._scaledValue;
        public static bool operator <=(UFix64C left, UFix64C right) => left._scaledValue <= right._scaledValue;
        public static bool operator ==(UFix64C left, UFix64C right) => left._scaledValue == right._scaledValue;
        public static bool operator >(UFix64C left, UFix64C right) => left._scaledValue > right._scaledValue;
        public static bool operator >=(UFix64C left, UFix64C right) => left._scaledValue >= right._scaledValue;
        public static UFix64C operator %(UFix64C left, UFix64C right) => new UFix64C(CheckedArithmetic.Remainder(left._scaledValue, right._scaledValue));
        public static UFix64C operator &(UFix64C left, UFix64C right) => new UFix64C(left._scaledValue & right._scaledValue);
        public static UFix64C operator -(UFix64C _) => 0;
        public static UFix64C operator -(UFix64C left, UFix64C right) => new UFix64C(CheckedArithmetic.Subtract(left._scaledValue, right._scaledValue));
        public static UFix64C operator --(UFix64C value) => new UFix64C(value._scaledValue - ScalingFactor);
        public static UFix64C operator *(UFix64C left, UFix64C right) => new UFix64C(CheckedArithmetic.ScaledMultiply(left._scaledValue, right._scaledValue, ScalingFactor));
        public static UFix64C operator /(UFix64C left, UFix64C right) => new UFix64C(CheckedArithmetic.ScaledDivide(left._scaledValue, right._scaledValue, ScalingFactor));
        public static UFix64C operator ^(UFix64C left, UFix64C right) => new UFix64C(left._scaledValue ^ right._scaledValue);
        public static UFix64C operator |(UFix64C left, UFix64C right) => new UFix64C(left._scaledValue | right._scaledValue);
        public static UFix64C operator ~(UFix64C value) => new UFix64C(~value._scaledValue);
        public static UFix64C operator +(UFix64C left, UFix64C right) => new UFix64C(CheckedArithmetic.Add(left._scaledValue, right._scaledValue));
        public static UFix64C operator +(UFix64C value) => value;
        public static UFix64C operator ++(UFix64C value) => new UFix64C(value._scaledValue + ScalingFactor);
        public static UFix64C operator <<(UFix64C left, int right) => new UFix64C(left._scaledValue << right);
        public static UFix64C operator >>(UFix64C left, int right) => new UFix64C(left._scaledValue >> right);

        TypeCode IConvertible.GetTypeCode() => TypeCode.Object;
        bool IConvertible.ToBoolean(IFormatProvider provider) => ((IConvert<UFix64C>)Utilities.Instance).ToBoolean(this);
        char IConvertible.ToChar(IFormatProvider provider) => ((IConvertible)((IConvert<UFix64C>)Utilities.Instance).ToDouble(this, Conversion.Clamp)).ToChar(provider);
        sbyte IConvertible.ToSByte(IFormatProvider provider) => ((IConvertNonCLS<UFix64C>)Utilities.Instance).ToSByte(this, Conversion.Clamp);
        byte IConvertible.ToByte(IFormatProvider provider) => ((IConvert<UFix64C>)Utilities.Instance).ToByte(this, Conversion.Clamp);
        short IConvertible.ToInt16(IFormatProvider provider) => ((IConvert<UFix64C>)Utilities.Instance).ToInt16(this, Conversion.Clamp);
        ushort IConvertible.ToUInt16(IFormatProvider provider) => ((IConvertNonCLS<UFix64C>)Utilities.Instance).ToUInt16(this, Conversion.Clamp);
        int IConvertible.ToInt32(IFormatProvider provider) => ((IConvert<UFix64C>)Utilities.Instance).ToInt32(this, Conversion.Clamp);
        uint IConvertible.ToUInt32(IFormatProvider provider) => ((IConvertNonCLS<UFix64C>)Utilities.Instance).ToUInt32(this, Conversion.Clamp);
        long IConvertible.ToInt64(IFormatProvider provider) => ((IConvert<UFix64C>)Utilities.Instance).ToInt64(this, Conversion.Clamp);
        ulong IConvertible.ToUInt64(IFormatProvider provider) => ((IConvertNonCLS<UFix64C>)Utilities.Instance).ToUInt64(this, Conversion.Clamp);
        float IConvertible.ToSingle(IFormatProvider provider) => ((IConvert<UFix64C>)Utilities.Instance).ToSingle(this, Conversion.Clamp);
        double IConvertible.ToDouble(IFormatProvider provider) => ((IConvert<UFix64C>)Utilities.Instance).ToDouble(this, Conversion.Clamp);
        decimal IConvertible.ToDecimal(IFormatProvider provider) => ((IConvert<UFix64C>)Utilities.Instance).ToDecimal(this, Conversion.Clamp);
        DateTime IConvertible.ToDateTime(IFormatProvider provider) => ((IConvertible)((IConvert<UFix64C>)Utilities.Instance).ToDouble(this, Conversion.Clamp)).ToDateTime(provider);
        object IConvertible.ToType(Type conversionType, IFormatProvider provider) => ((IConvertible)((IConvert<UFix64C>)Utilities.Instance).ToDouble(this, Conversion.Clamp)).ToType(conversionType, provider);

        bool INumeric<UFix64C>.IsGreaterThan(UFix64C value) => this > value;
        bool INumeric<UFix64C>.IsGreaterThanOrEqualTo(UFix64C value) => this >= value;
        bool INumeric<UFix64C>.IsLessThan(UFix64C value) => this < value;
        bool INumeric<UFix64C>.IsLessThanOrEqualTo(UFix64C value) => this <= value;
        UFix64C INumeric<UFix64C>.Add(UFix64C value) => this + value;
        UFix64C INumeric<UFix64C>.BitwiseComplement() => ~this;
        UFix64C INumeric<UFix64C>.Divide(UFix64C value) => this / value;
        UFix64C INumeric<UFix64C>.LeftShift(int count) => this << count;
        UFix64C INumeric<UFix64C>.LogicalAnd(UFix64C value) => this & value;
        UFix64C INumeric<UFix64C>.LogicalExclusiveOr(UFix64C value) => this ^ value;
        UFix64C INumeric<UFix64C>.LogicalOr(UFix64C value) => this | value;
        UFix64C INumeric<UFix64C>.Multiply(UFix64C value) => this * value;
        UFix64C INumeric<UFix64C>.Negative() => -this;
        UFix64C INumeric<UFix64C>.Positive() => +this;
        UFix64C INumeric<UFix64C>.Remainder(UFix64C value) => this % value;
        UFix64C INumeric<UFix64C>.RightShift(int count) => this >> count;
        UFix64C INumeric<UFix64C>.Subtract(UFix64C value) => this - value;

        IBitConverter<UFix64C> IProvider<IBitConverter<UFix64C>>.GetInstance() => Utilities.Instance;
        IConvert<UFix64C> IProvider<IConvert<UFix64C>>.GetInstance() => Utilities.Instance;
        IConvertNonCLS<UFix64C> IProvider<IConvertNonCLS<UFix64C>>.GetInstance() => Utilities.Instance;
        IMath<UFix64C> IProvider<IMath<UFix64C>>.GetInstance() => Utilities.Instance;
        INumericStatic<UFix64C> IProvider<INumericStatic<UFix64C>>.GetInstance() => Utilities.Instance;
        IRandom<UFix64C> IProvider<IRandom<UFix64C>>.GetInstance() => Utilities.Instance;
        IParser<UFix64C> IProvider<IParser<UFix64C>>.GetInstance() => Utilities.Instance;

        private sealed class Utilities :
            IBitConverter<UFix64C>,
            IConvert<UFix64C>,
            IConvertNonCLS<UFix64C>,
            IMath<UFix64C>,
            INumericStatic<UFix64C>,
            IRandom<UFix64C>,
            IParser<UFix64C>
        {
            public static readonly Utilities Instance = new Utilities();

            bool INumericStatic<UFix64C>.HasFloatingPoint { get; } = false;
            bool INumericStatic<UFix64C>.HasInfinity { get; } = false;
            bool INumericStatic<UFix64C>.HasNaN { get; } = false;
            bool INumericStatic<UFix64C>.IsFinite(UFix64C x) => true;
            bool INumericStatic<UFix64C>.IsInfinity(UFix64C x) => false;
            bool INumericStatic<UFix64C>.IsNaN(UFix64C x) => false;
            bool INumericStatic<UFix64C>.IsNegative(UFix64C x) => false;
            bool INumericStatic<UFix64C>.IsNegativeInfinity(UFix64C x) => false;
            bool INumericStatic<UFix64C>.IsNormal(UFix64C x) => false;
            bool INumericStatic<UFix64C>.IsPositiveInfinity(UFix64C x) => false;
            bool INumericStatic<UFix64C>.IsReal { get; } = true;
            bool INumericStatic<UFix64C>.IsSigned { get; } = false;
            bool INumericStatic<UFix64C>.IsSubnormal(UFix64C x) => false;
            UFix64C INumericStatic<UFix64C>.Epsilon { get; } = new UFix64C(1);
            UFix64C INumericStatic<UFix64C>.MaxUnit { get; } = new UFix64C(ScalingFactor);
            UFix64C INumericStatic<UFix64C>.MaxValue => MaxValue;
            UFix64C INumericStatic<UFix64C>.MinUnit { get; } = 0;
            UFix64C INumericStatic<UFix64C>.MinValue => MinValue;
            UFix64C INumericStatic<UFix64C>.One { get; } = new UFix64C(ScalingFactor);
            UFix64C INumericStatic<UFix64C>.Ten { get; } = new UFix64C(10 * ScalingFactor);
            UFix64C INumericStatic<UFix64C>.Two { get; } = new UFix64C(2 * ScalingFactor);
            UFix64C INumericStatic<UFix64C>.Zero { get; } = 0;

            int IMath<UFix64C>.Sign(UFix64C x) => x._scaledValue == 0 ? 0 : 1;
            UFix64C IMath<UFix64C>.Abs(UFix64C value) => value;
            UFix64C IMath<UFix64C>.Acos(UFix64C x) => (UFix64C)Math.Acos((double)x);
            UFix64C IMath<UFix64C>.Acosh(UFix64C x) => (UFix64C)MathCompat.Acosh((double)x);
            UFix64C IMath<UFix64C>.Asin(UFix64C x) => (UFix64C)Math.Asin((double)x);
            UFix64C IMath<UFix64C>.Asinh(UFix64C x) => (UFix64C)MathCompat.Asinh((double)x);
            UFix64C IMath<UFix64C>.Atan(UFix64C x) => (UFix64C)Math.Atan((double)x);
            UFix64C IMath<UFix64C>.Atan2(UFix64C x, UFix64C y) => (UFix64C)Math.Atan2((double)x, (double)y);
            UFix64C IMath<UFix64C>.Atanh(UFix64C x) => (UFix64C)MathCompat.Atanh((double)x);
            UFix64C IMath<UFix64C>.Cbrt(UFix64C x) => (UFix64C)MathCompat.Cbrt((double)x);
            UFix64C IMath<UFix64C>.Ceiling(UFix64C x) => new UFix64C(ScaledArithmetic.Ceiling(x._scaledValue, ScalingFactor));
            UFix64C IMath<UFix64C>.Clamp(UFix64C x, UFix64C bound1, UFix64C bound2) => new UFix64C(bound1 > bound2 ? Math.Min(bound1._scaledValue, Math.Max(bound2._scaledValue, x._scaledValue)) : Math.Min(bound2._scaledValue, Math.Max(bound1._scaledValue, x._scaledValue)));
            UFix64C IMath<UFix64C>.Cos(UFix64C x) => (UFix64C)Math.Cos((double)x);
            UFix64C IMath<UFix64C>.Cosh(UFix64C x) => (UFix64C)Math.Cosh((double)x);
            UFix64C IMath<UFix64C>.DegreesToRadians(UFix64C x) => (UFix64C)CheckedArithmetic.Multiply((double)x, NumericUtilities.RadiansPerDegree);
            UFix64C IMath<UFix64C>.E { get; } = (UFix64C)Math.E;
            UFix64C IMath<UFix64C>.Exp(UFix64C x) => (UFix64C)Math.Exp((double)x);
            UFix64C IMath<UFix64C>.Floor(UFix64C x) => new UFix64C(ScaledArithmetic.Floor(x._scaledValue, ScalingFactor));
            UFix64C IMath<UFix64C>.IEEERemainder(UFix64C x, UFix64C y) => (UFix64C)Math.IEEERemainder((double)x, (double)y);
            UFix64C IMath<UFix64C>.Log(UFix64C x) => (UFix64C)Math.Log((double)x);
            UFix64C IMath<UFix64C>.Log(UFix64C x, UFix64C y) => (UFix64C)Math.Log((double)x, (double)y);
            UFix64C IMath<UFix64C>.Log10(UFix64C x) => (UFix64C)Math.Log10((double)x);
            UFix64C IMath<UFix64C>.Max(UFix64C x, UFix64C y) => new UFix64C(Math.Max(x._scaledValue, y._scaledValue));
            UFix64C IMath<UFix64C>.Min(UFix64C x, UFix64C y) => new UFix64C(Math.Min(x._scaledValue, y._scaledValue));
            UFix64C IMath<UFix64C>.PI { get; } = (UFix64C)Math.PI;
            UFix64C IMath<UFix64C>.Pow(UFix64C x, UFix64C y) => y == 1 ? x : (UFix64C)Math.Pow((double)x, (double)y);
            UFix64C IMath<UFix64C>.RadiansToDegrees(UFix64C x) => (UFix64C)CheckedArithmetic.Multiply((double)x, NumericUtilities.DegreesPerRadian);
            UFix64C IMath<UFix64C>.Round(UFix64C x) => Round(x, 0, MidpointRounding.ToEven);
            UFix64C IMath<UFix64C>.Round(UFix64C x, int digits) => Round(x, digits, MidpointRounding.ToEven);
            UFix64C IMath<UFix64C>.Round(UFix64C x, int digits, MidpointRounding mode) => Round(x, digits, mode);
            UFix64C IMath<UFix64C>.Round(UFix64C x, MidpointRounding mode) => Round(x, 0, mode);
            UFix64C IMath<UFix64C>.Sin(UFix64C x) => (UFix64C)Math.Sin((double)x);
            UFix64C IMath<UFix64C>.Sinh(UFix64C x) => (UFix64C)Math.Sinh((double)x);
            UFix64C IMath<UFix64C>.Sqrt(UFix64C x) => (UFix64C)Math.Sqrt((double)x);
            UFix64C IMath<UFix64C>.Tan(UFix64C x) => (UFix64C)Math.Tan((double)x);
            UFix64C IMath<UFix64C>.Tanh(UFix64C x) => (UFix64C)Math.Tanh((double)x);
            UFix64C IMath<UFix64C>.Tau { get; } = (UFix64C)(Math.PI * 2d);
            UFix64C IMath<UFix64C>.Truncate(UFix64C x) => new UFix64C(x._scaledValue / ScalingFactor * ScalingFactor);

            UFix64C IBitConverter<UFix64C>.Read(IReadOnlyStream<byte> stream) => new UFix64C(BitConverter.ToUInt64(stream.Read(sizeof(ulong)), 0));
            void IBitConverter<UFix64C>.Write(UFix64C value, IWriteOnlyStream<byte> stream) => stream.Write(BitConverter.GetBytes(value._scaledValue));

            UFix64C IRandom<UFix64C>.Next(Random random) => new UFix64C(random.NextUInt64());
            UFix64C IRandom<UFix64C>.Next(Random random, UFix64C bound1, UFix64C bound2) => new UFix64C(random.NextUInt64(bound1._scaledValue, bound2._scaledValue));

            bool IConvert<UFix64C>.ToBoolean(UFix64C value) => value._scaledValue != 0;
            byte IConvert<UFix64C>.ToByte(UFix64C value, Conversion mode) => NumericConvert.ToByte(value._scaledValue / ScalingFactor, mode.Clamped());
            decimal IConvert<UFix64C>.ToDecimal(UFix64C value, Conversion mode) => (decimal)value._scaledValue / ScalingFactor;
            double IConvert<UFix64C>.ToDouble(UFix64C value, Conversion mode) => (double)value._scaledValue / ScalingFactor;
            float IConvert<UFix64C>.ToSingle(UFix64C value, Conversion mode) => (float)value._scaledValue / ScalingFactor;
            int IConvert<UFix64C>.ToInt32(UFix64C value, Conversion mode) => NumericConvert.ToInt32(value._scaledValue / ScalingFactor, mode.Clamped());
            long IConvert<UFix64C>.ToInt64(UFix64C value, Conversion mode) => NumericConvert.ToInt64(value._scaledValue / ScalingFactor, mode.Clamped());
            sbyte IConvertNonCLS<UFix64C>.ToSByte(UFix64C value, Conversion mode) => NumericConvert.ToSByte(value._scaledValue / ScalingFactor, mode.Clamped());
            short IConvert<UFix64C>.ToInt16(UFix64C value, Conversion mode) => NumericConvert.ToInt16(value._scaledValue / ScalingFactor, mode.Clamped());
            string IConvert<UFix64C>.ToString(UFix64C value) => value.ToString();
            uint IConvertNonCLS<UFix64C>.ToUInt32(UFix64C value, Conversion mode) => NumericConvert.ToUInt32(value._scaledValue / ScalingFactor, mode.Clamped());
            ulong IConvertNonCLS<UFix64C>.ToUInt64(UFix64C value, Conversion mode) => value._scaledValue / ScalingFactor;
            ushort IConvertNonCLS<UFix64C>.ToUInt16(UFix64C value, Conversion mode) => NumericConvert.ToUInt16(value._scaledValue / ScalingFactor, mode.Clamped());

            UFix64C IConvert<UFix64C>.ToNumeric(bool value) => value ? new UFix64C(ScalingFactor) : new UFix64C(0);
            UFix64C IConvert<UFix64C>.ToNumeric(byte value, Conversion mode) => (UFix64C)NumericConvert.ToUInt64(value, mode.Clamped());
            UFix64C IConvert<UFix64C>.ToNumeric(decimal value, Conversion mode) => (UFix64C)value;
            UFix64C IConvert<UFix64C>.ToNumeric(double value, Conversion mode) => (UFix64C)value;
            UFix64C IConvert<UFix64C>.ToNumeric(float value, Conversion mode) => (UFix64C)value;
            UFix64C IConvert<UFix64C>.ToNumeric(int value, Conversion mode) => (UFix64C)NumericConvert.ToUInt64(value, mode.Clamped());
            UFix64C IConvert<UFix64C>.ToNumeric(long value, Conversion mode) => (UFix64C)value;
            UFix64C IConvertNonCLS<UFix64C>.ToValue(sbyte value, Conversion mode) => (UFix64C)NumericConvert.ToUInt64(value, mode.Clamped());
            UFix64C IConvert<UFix64C>.ToNumeric(short value, Conversion mode) => (UFix64C)NumericConvert.ToUInt64(value, mode.Clamped());
            UFix64C IConvert<UFix64C>.ToNumeric(string value) => (UFix64C)Convert.ToUInt64(value);
            UFix64C IConvertNonCLS<UFix64C>.ToNumeric(uint value, Conversion mode) => (UFix64C)NumericConvert.ToUInt64(value, mode.Clamped());
            UFix64C IConvertNonCLS<UFix64C>.ToNumeric(ulong value, Conversion mode) => (UFix64C)value;
            UFix64C IConvertNonCLS<UFix64C>.ToNumeric(ushort value, Conversion mode) => (UFix64C)NumericConvert.ToUInt64(value, mode.Clamped());

            UFix64C IParser<UFix64C>.Parse(string s) => Parse(s);
            UFix64C IParser<UFix64C>.Parse(string s, NumberStyles style, IFormatProvider? provider) => Parse(s, style, provider);
        }
    }
}
