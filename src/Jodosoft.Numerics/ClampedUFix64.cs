// Copyright (c) 2023 Joe Lawry-Short
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
using System.IO;
using System.Runtime.Serialization;
using Jodosoft.Primitives;
using Jodosoft.Primitives.Compatibility;

namespace Jodosoft.Numerics
{
    /// <summary>
    /// Represents a decimal fixed-point unsigned number that cannot overflow.
    /// </summary>
    [Serializable]
    [DebuggerDisplay("{ToString(),nq}")]
    public readonly struct ClampedUFix64 : INumericExtended<ClampedUFix64>
    {
        public static readonly ClampedUFix64 Epsilon = new ClampedUFix64(1);
        public static readonly ClampedUFix64 MaxValue = new ClampedUFix64(ulong.MaxValue);
        public static readonly ClampedUFix64 MinValue = new ClampedUFix64(ulong.MinValue);

        private const ulong ScalingFactor = 1_000_000;

        private readonly ulong _scaledValue;

        private ClampedUFix64(ulong scaledValue)
        {
            _scaledValue = scaledValue;
        }

        private ClampedUFix64(SerializationInfo info, StreamingContext context) : this(info.GetUInt64(nameof(ClampedUFix64))) { }
        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context) => info.AddValue(nameof(ClampedUFix64), _scaledValue);

        public int CompareTo(object? obj) => obj is ClampedUFix64 other ? CompareTo(other) : 1;
        public int CompareTo(ClampedUFix64 other) => _scaledValue.CompareTo(other._scaledValue);
        public bool Equals(ClampedUFix64 other) => _scaledValue == other._scaledValue;
        public override bool Equals(object? obj) => obj is ClampedUFix64 other && Equals(other);
        public override int GetHashCode() => _scaledValue.GetHashCode();
        public override string ToString() => Scaled.ToString(_scaledValue, ScalingFactor, null);
        public string ToString(IFormatProvider? provider) => Scaled.ToString(_scaledValue, ScalingFactor, provider);
        public string ToString(string format) => ((double)this).ToString(format);

        public string ToString(string? format, IFormatProvider? formatProvider)
        {
            if (format == null)
            {
                if (formatProvider == null) return ToString();
                return ToString(formatProvider);
            }
            if (formatProvider == null) return ToString(format);

            return ((double)this).ToString(format, formatProvider);
        }

        [CLSCompliant(false)]
        public static ulong GetScalingFactor() => ScalingFactor;

        [CLSCompliant(false)]
        public static ulong GetScaledValue(ClampedUFix64 value) => value._scaledValue;

        public static bool TryParse(string s, IFormatProvider? provider, out ClampedUFix64 result) => FuncExtensions.Try(() => Parse(s, provider), out result);
        public static bool TryParse(string s, NumberStyles style, IFormatProvider? provider, out ClampedUFix64 result) => FuncExtensions.Try(() => Parse(s, style, provider), out result);
        public static bool TryParse(string s, NumberStyles style, out ClampedUFix64 result) => FuncExtensions.Try(() => Parse(s, style), out result);
        public static bool TryParse(string s, out ClampedUFix64 result) => FuncExtensions.Try(() => Parse(s), out result);
        public static ClampedUFix64 Parse(string s) => new ClampedUFix64(Scaled.Parse(s, ScalingFactor, null, null));
        public static ClampedUFix64 Parse(string s, IFormatProvider? provider) => (ClampedUFix64)double.Parse(s, provider);
        public static ClampedUFix64 Parse(string s, NumberStyles style) => (ClampedUFix64)double.Parse(s, style);
        public static ClampedUFix64 Parse(string s, NumberStyles style, IFormatProvider? provider) => (ClampedUFix64)double.Parse(s, style, provider);

        [SuppressMessage("Style", "JSON002:Probable JSON string detected", Justification = "False positive")]
        private static ClampedUFix64 FromDouble(double value)
        {
            string str = string
                .Format(CultureInfo.InvariantCulture, "{0:0.0000000}", value)
                .Replace(".", string.Empty);
            str = str.Substring(0, str.Length - 1);
            if (ulong.TryParse(str, out ulong lng))
                return new ClampedUFix64(lng);
            else
            {
                if (value > 0) return MaxValue;
                return MinValue;
            }
        }

        [CLSCompliant(false)] public static explicit operator ClampedUFix64(sbyte value) => new ClampedUFix64(ConvertN.ToUInt64(value, Conversion.CastClamp) * ScalingFactor);
        [CLSCompliant(false)] public static explicit operator ClampedUFix64(ulong value) => new ClampedUFix64(value * ScalingFactor);
        [CLSCompliant(false)] public static implicit operator ClampedUFix64(uint value) => new ClampedUFix64(ConvertN.ToUInt64(value, Conversion.CastClamp) * ScalingFactor);
        [CLSCompliant(false)] public static implicit operator ClampedUFix64(ushort value) => new ClampedUFix64(ConvertN.ToUInt64(value, Conversion.CastClamp) * ScalingFactor);
        public static explicit operator ClampedUFix64(decimal value) => value < 0 ? new ClampedUFix64(0) : new ClampedUFix64(ConvertN.ToUInt64(ClampedArithmetic.Multiply(value, ScalingFactor), Conversion.CastClamp));
        public static explicit operator ClampedUFix64(double value) => value < 0 ? new ClampedUFix64(0) : FromDouble(value);
        public static explicit operator ClampedUFix64(ClampedFix64 value) => new ClampedUFix64(ConvertN.ToUInt64(ClampedFix64.GetScaledValue(value), Conversion.CastClamp));
        public static explicit operator ClampedUFix64(float value) => value < 0 ? new ClampedUFix64(0) : new ClampedUFix64(ConvertN.ToUInt64(value * ScalingFactor, Conversion.CastClamp));
        public static explicit operator ClampedUFix64(int value) => new ClampedUFix64(ConvertN.ToUInt64(value, Conversion.CastClamp) * ScalingFactor);
        public static explicit operator ClampedUFix64(long value) => new ClampedUFix64(ConvertN.ToUInt64(value, Conversion.CastClamp) * ScalingFactor);
        public static explicit operator ClampedUFix64(short value) => new ClampedUFix64(ConvertN.ToUInt64(value, Conversion.CastClamp) * ScalingFactor);
        public static implicit operator ClampedUFix64(byte value) => new ClampedUFix64(value * ScalingFactor);

        [CLSCompliant(false)] public static explicit operator sbyte(ClampedUFix64 value) => ConvertN.ToSByte(value._scaledValue / ScalingFactor, Conversion.CastClamp);
        [CLSCompliant(false)] public static explicit operator uint(ClampedUFix64 value) => ConvertN.ToUInt32(value._scaledValue / ScalingFactor, Conversion.CastClamp);
        [CLSCompliant(false)] public static explicit operator ulong(ClampedUFix64 value) => value._scaledValue / ScalingFactor;
        [CLSCompliant(false)] public static explicit operator ushort(ClampedUFix64 value) => ConvertN.ToUInt16(value._scaledValue / ScalingFactor, Conversion.CastClamp);
        public static explicit operator byte(ClampedUFix64 value) => ConvertN.ToByte(value._scaledValue / ScalingFactor, Conversion.CastClamp);
        public static explicit operator decimal(ClampedUFix64 value) => (decimal)value._scaledValue / ScalingFactor;
        public static explicit operator double(ClampedUFix64 value) => Scaled.ToDouble(value._scaledValue, ScalingFactor);
        public static explicit operator float(ClampedUFix64 value) => (float)value._scaledValue / ScalingFactor;
        public static explicit operator int(ClampedUFix64 value) => ConvertN.ToInt32(value._scaledValue / ScalingFactor, Conversion.CastClamp);
        public static explicit operator long(ClampedUFix64 value) => ConvertN.ToInt64(value._scaledValue / ScalingFactor, Conversion.CastClamp);
        public static explicit operator short(ClampedUFix64 value) => ConvertN.ToInt16(value._scaledValue / ScalingFactor, Conversion.CastClamp);

        public static bool operator !=(ClampedUFix64 left, ClampedUFix64 right) => left._scaledValue != right._scaledValue;
        public static bool operator <(ClampedUFix64 left, ClampedUFix64 right) => left._scaledValue < right._scaledValue;
        public static bool operator <=(ClampedUFix64 left, ClampedUFix64 right) => left._scaledValue <= right._scaledValue;
        public static bool operator ==(ClampedUFix64 left, ClampedUFix64 right) => left._scaledValue == right._scaledValue;
        public static bool operator >(ClampedUFix64 left, ClampedUFix64 right) => left._scaledValue > right._scaledValue;
        public static bool operator >=(ClampedUFix64 left, ClampedUFix64 right) => left._scaledValue >= right._scaledValue;
        public static ClampedUFix64 operator %(ClampedUFix64 left, ClampedUFix64 right) => new ClampedUFix64(ClampedArithmetic.Remainder(left._scaledValue, right._scaledValue));
        public static ClampedUFix64 operator &(ClampedUFix64 left, ClampedUFix64 right) => new ClampedUFix64(left._scaledValue & right._scaledValue);
        public static ClampedUFix64 operator -(ClampedUFix64 _) => 0;
        public static ClampedUFix64 operator -(ClampedUFix64 left, ClampedUFix64 right) => new ClampedUFix64(ClampedArithmetic.Subtract(left._scaledValue, right._scaledValue));
        public static ClampedUFix64 operator --(ClampedUFix64 value) => new ClampedUFix64(ClampedArithmetic.Subtract(value._scaledValue, ScalingFactor));
        public static ClampedUFix64 operator *(ClampedUFix64 left, ClampedUFix64 right) => new ClampedUFix64(ClampedArithmetic.ScaledMultiply(left._scaledValue, right._scaledValue, ScalingFactor));
        public static ClampedUFix64 operator /(ClampedUFix64 left, ClampedUFix64 right) => new ClampedUFix64(ClampedArithmetic.ScaledDivide(left._scaledValue, right._scaledValue, ScalingFactor));
        public static ClampedUFix64 operator ^(ClampedUFix64 left, ClampedUFix64 right) => new ClampedUFix64(left._scaledValue ^ right._scaledValue);
        public static ClampedUFix64 operator |(ClampedUFix64 left, ClampedUFix64 right) => new ClampedUFix64(left._scaledValue | right._scaledValue);
        public static ClampedUFix64 operator ~(ClampedUFix64 value) => new ClampedUFix64(~value._scaledValue);
        public static ClampedUFix64 operator +(ClampedUFix64 left, ClampedUFix64 right) => new ClampedUFix64(ClampedArithmetic.Add(left._scaledValue, right._scaledValue));
        public static ClampedUFix64 operator +(ClampedUFix64 value) => value;
        public static ClampedUFix64 operator ++(ClampedUFix64 value) => new ClampedUFix64(ClampedArithmetic.Add(value._scaledValue, ScalingFactor));
        public static ClampedUFix64 operator <<(ClampedUFix64 left, int right) => new ClampedUFix64(left._scaledValue << right);
        public static ClampedUFix64 operator >>(ClampedUFix64 left, int right) => new ClampedUFix64(left._scaledValue >> right);

        TypeCode IConvertible.GetTypeCode() => TypeCode.Object;
        bool IConvertible.ToBoolean(IFormatProvider? provider) => ((IConvert<ClampedUFix64>)Utilities.Instance).ToBoolean(this);
        char IConvertible.ToChar(IFormatProvider? provider) => ((IConvertible)((IConvert<ClampedUFix64>)Utilities.Instance).ToDouble(this, Conversion.Clamp)).ToChar(provider);
        sbyte IConvertible.ToSByte(IFormatProvider? provider) => ((IConvertExtended<ClampedUFix64>)Utilities.Instance).ToSByte(this, Conversion.Clamp);
        byte IConvertible.ToByte(IFormatProvider? provider) => ((IConvert<ClampedUFix64>)Utilities.Instance).ToByte(this, Conversion.Clamp);
        short IConvertible.ToInt16(IFormatProvider? provider) => ((IConvert<ClampedUFix64>)Utilities.Instance).ToInt16(this, Conversion.Clamp);
        ushort IConvertible.ToUInt16(IFormatProvider? provider) => ((IConvertExtended<ClampedUFix64>)Utilities.Instance).ToUInt16(this, Conversion.Clamp);
        int IConvertible.ToInt32(IFormatProvider? provider) => ((IConvert<ClampedUFix64>)Utilities.Instance).ToInt32(this, Conversion.Clamp);
        uint IConvertible.ToUInt32(IFormatProvider? provider) => ((IConvertExtended<ClampedUFix64>)Utilities.Instance).ToUInt32(this, Conversion.Clamp);
        long IConvertible.ToInt64(IFormatProvider? provider) => ((IConvert<ClampedUFix64>)Utilities.Instance).ToInt64(this, Conversion.Clamp);
        ulong IConvertible.ToUInt64(IFormatProvider? provider) => ((IConvertExtended<ClampedUFix64>)Utilities.Instance).ToUInt64(this, Conversion.Clamp);
        float IConvertible.ToSingle(IFormatProvider? provider) => ((IConvert<ClampedUFix64>)Utilities.Instance).ToSingle(this, Conversion.Clamp);
        double IConvertible.ToDouble(IFormatProvider? provider) => ((IConvert<ClampedUFix64>)Utilities.Instance).ToDouble(this, Conversion.Clamp);
        decimal IConvertible.ToDecimal(IFormatProvider? provider) => ((IConvert<ClampedUFix64>)Utilities.Instance).ToDecimal(this, Conversion.Clamp);
        DateTime IConvertible.ToDateTime(IFormatProvider? provider) => ((IConvertible)((IConvert<ClampedUFix64>)Utilities.Instance).ToDouble(this, Conversion.Clamp)).ToDateTime(provider);
        object IConvertible.ToType(Type conversionType, IFormatProvider? provider) => this.ToTypeDefault(conversionType, provider);

        bool INumeric<ClampedUFix64>.IsGreaterThan(ClampedUFix64 value) => this > value;
        bool INumeric<ClampedUFix64>.IsGreaterThanOrEqualTo(ClampedUFix64 value) => this >= value;
        bool INumeric<ClampedUFix64>.IsLessThan(ClampedUFix64 value) => this < value;
        bool INumeric<ClampedUFix64>.IsLessThanOrEqualTo(ClampedUFix64 value) => this <= value;
        ClampedUFix64 INumeric<ClampedUFix64>.Add(ClampedUFix64 value) => this + value;
        ClampedUFix64 INumeric<ClampedUFix64>.BitwiseComplement() => ~this;
        ClampedUFix64 INumeric<ClampedUFix64>.Divide(ClampedUFix64 value) => this / value;
        ClampedUFix64 INumeric<ClampedUFix64>.LeftShift(int count) => this << count;
        ClampedUFix64 INumeric<ClampedUFix64>.LogicalAnd(ClampedUFix64 value) => this & value;
        ClampedUFix64 INumeric<ClampedUFix64>.LogicalExclusiveOr(ClampedUFix64 value) => this ^ value;
        ClampedUFix64 INumeric<ClampedUFix64>.LogicalOr(ClampedUFix64 value) => this | value;
        ClampedUFix64 INumeric<ClampedUFix64>.Multiply(ClampedUFix64 value) => this * value;
        ClampedUFix64 INumeric<ClampedUFix64>.Negative() => -this;
        ClampedUFix64 INumeric<ClampedUFix64>.Positive() => +this;
        ClampedUFix64 INumeric<ClampedUFix64>.Remainder(ClampedUFix64 value) => this % value;
        ClampedUFix64 INumeric<ClampedUFix64>.RightShift(int count) => this >> count;
        ClampedUFix64 INumeric<ClampedUFix64>.Subtract(ClampedUFix64 value) => this - value;

        INumericBitConverter<ClampedUFix64> IProvider<INumericBitConverter<ClampedUFix64>>.GetInstance() => Utilities.Instance;
        IBinaryIO<ClampedUFix64> IProvider<IBinaryIO<ClampedUFix64>>.GetInstance() => Utilities.Instance;
        IConvert<ClampedUFix64> IProvider<IConvert<ClampedUFix64>>.GetInstance() => Utilities.Instance;
        IConvertExtended<ClampedUFix64> IProvider<IConvertExtended<ClampedUFix64>>.GetInstance() => Utilities.Instance;
        IMath<ClampedUFix64> IProvider<IMath<ClampedUFix64>>.GetInstance() => Utilities.Instance;
        INumericRandom<ClampedUFix64> IProvider<INumericRandom<ClampedUFix64>>.GetInstance() => Utilities.Instance;
        INumericStatic<ClampedUFix64> IProvider<INumericStatic<ClampedUFix64>>.GetInstance() => Utilities.Instance;
        IVariantRandom<ClampedUFix64> IProvider<IVariantRandom<ClampedUFix64>>.GetInstance() => Utilities.Instance;

        private sealed class Utilities :
            IBinaryIO<ClampedUFix64>,
            IConvert<ClampedUFix64>,
            IConvertExtended<ClampedUFix64>,
            IMath<ClampedUFix64>,
            INumericBitConverter<ClampedUFix64>,
            INumericRandom<ClampedUFix64>,
            INumericStatic<ClampedUFix64>,
            IVariantRandom<ClampedUFix64>
        {
            public static readonly Utilities Instance = new Utilities();

            void IBinaryIO<ClampedUFix64>.Write(BinaryWriter writer, ClampedUFix64 value) => writer.Write(value._scaledValue);
            ClampedUFix64 IBinaryIO<ClampedUFix64>.Read(BinaryReader reader) => new ClampedUFix64(reader.ReadUInt64());

            bool INumericStatic<ClampedUFix64>.HasFloatingPoint => false;
            bool INumericStatic<ClampedUFix64>.HasInfinity => false;
            bool INumericStatic<ClampedUFix64>.HasNaN => false;
            bool INumericStatic<ClampedUFix64>.IsFinite(ClampedUFix64 x) => true;
            bool INumericStatic<ClampedUFix64>.IsInfinity(ClampedUFix64 x) => false;
            bool INumericStatic<ClampedUFix64>.IsNaN(ClampedUFix64 x) => false;
            bool INumericStatic<ClampedUFix64>.IsNegative(ClampedUFix64 x) => false;
            bool INumericStatic<ClampedUFix64>.IsNegativeInfinity(ClampedUFix64 x) => false;
            bool INumericStatic<ClampedUFix64>.IsNormal(ClampedUFix64 x) => false;
            bool INumericStatic<ClampedUFix64>.IsPositiveInfinity(ClampedUFix64 x) => false;
            bool INumericStatic<ClampedUFix64>.IsReal => true;
            bool INumericStatic<ClampedUFix64>.IsSigned => false;
            bool INumericStatic<ClampedUFix64>.IsSubnormal(ClampedUFix64 x) => false;
            ClampedUFix64 INumericStatic<ClampedUFix64>.Epsilon { get; } = new ClampedUFix64(1);
            ClampedUFix64 INumericStatic<ClampedUFix64>.MaxUnit { get; } = new ClampedUFix64(ScalingFactor);
            ClampedUFix64 INumericStatic<ClampedUFix64>.MaxValue => MaxValue;
            ClampedUFix64 INumericStatic<ClampedUFix64>.MinUnit => 0;
            ClampedUFix64 INumericStatic<ClampedUFix64>.MinValue => MinValue;
            ClampedUFix64 INumericStatic<ClampedUFix64>.One { get; } = new ClampedUFix64(ScalingFactor);
            ClampedUFix64 INumericStatic<ClampedUFix64>.Zero => 0;

            int IMath<ClampedUFix64>.Sign(ClampedUFix64 x) => x._scaledValue == 0 ? 0 : 1;
            ClampedUFix64 IMath<ClampedUFix64>.Abs(ClampedUFix64 value) => value;
            ClampedUFix64 IMath<ClampedUFix64>.Acos(ClampedUFix64 x) => (ClampedUFix64)Math.Acos((double)x);
            ClampedUFix64 IMath<ClampedUFix64>.Acosh(ClampedUFix64 x) => (ClampedUFix64)MathShim.Acosh((double)x);
            ClampedUFix64 IMath<ClampedUFix64>.Asin(ClampedUFix64 x) => (ClampedUFix64)Math.Asin((double)x);
            ClampedUFix64 IMath<ClampedUFix64>.Asinh(ClampedUFix64 x) => (ClampedUFix64)MathShim.Asinh((double)x);
            ClampedUFix64 IMath<ClampedUFix64>.Atan(ClampedUFix64 x) => (ClampedUFix64)Math.Atan((double)x);
            ClampedUFix64 IMath<ClampedUFix64>.Atan2(ClampedUFix64 x, ClampedUFix64 y) => (ClampedUFix64)Math.Atan2((double)x, (double)y);
            ClampedUFix64 IMath<ClampedUFix64>.Atanh(ClampedUFix64 x) => (ClampedUFix64)MathShim.Atanh((double)x);
            ClampedUFix64 IMath<ClampedUFix64>.Cbrt(ClampedUFix64 x) => (ClampedUFix64)MathShim.Cbrt((double)x);
            ClampedUFix64 IMath<ClampedUFix64>.Ceiling(ClampedUFix64 x) => new ClampedUFix64(Scaled.Ceiling(x._scaledValue, ScalingFactor));
            ClampedUFix64 IMath<ClampedUFix64>.Clamp(ClampedUFix64 x, ClampedUFix64 bound1, ClampedUFix64 bound2) => new ClampedUFix64(bound1 > bound2 ? Math.Min(bound1._scaledValue, Math.Max(bound2._scaledValue, x._scaledValue)) : Math.Min(bound2._scaledValue, Math.Max(bound1._scaledValue, x._scaledValue)));
            ClampedUFix64 IMath<ClampedUFix64>.Cos(ClampedUFix64 x) => (ClampedUFix64)Math.Cos((double)x);
            ClampedUFix64 IMath<ClampedUFix64>.Cosh(ClampedUFix64 x) => (ClampedUFix64)Math.Cosh((double)x);
            ClampedUFix64 IMath<ClampedUFix64>.E { get; } = (ClampedUFix64)Math.E;
            ClampedUFix64 IMath<ClampedUFix64>.Exp(ClampedUFix64 x) => (ClampedUFix64)Math.Exp((double)x);
            ClampedUFix64 IMath<ClampedUFix64>.Floor(ClampedUFix64 x) => new ClampedUFix64(Scaled.Floor(x._scaledValue, ScalingFactor));
            ClampedUFix64 IMath<ClampedUFix64>.IEEERemainder(ClampedUFix64 x, ClampedUFix64 y) => (ClampedUFix64)Math.IEEERemainder((double)x, (double)y);
            ClampedUFix64 IMath<ClampedUFix64>.Log(ClampedUFix64 x) => (ClampedUFix64)Math.Log((double)x);
            ClampedUFix64 IMath<ClampedUFix64>.Log(ClampedUFix64 x, ClampedUFix64 y) => (ClampedUFix64)Math.Log((double)x, (double)y);
            ClampedUFix64 IMath<ClampedUFix64>.Log10(ClampedUFix64 x) => (ClampedUFix64)Math.Log10((double)x);
            ClampedUFix64 IMath<ClampedUFix64>.Max(ClampedUFix64 x, ClampedUFix64 y) => new ClampedUFix64(Math.Max(x._scaledValue, y._scaledValue));
            ClampedUFix64 IMath<ClampedUFix64>.Min(ClampedUFix64 x, ClampedUFix64 y) => new ClampedUFix64(Math.Min(x._scaledValue, y._scaledValue));
            ClampedUFix64 IMath<ClampedUFix64>.PI { get; } = (ClampedUFix64)Math.PI;
            ClampedUFix64 IMath<ClampedUFix64>.Pow(ClampedUFix64 x, ClampedUFix64 y) => y == 1 ? x : (ClampedUFix64)Math.Pow((double)x, (double)y);
            ClampedUFix64 IMath<ClampedUFix64>.Round(ClampedUFix64 x) => Round(x, 0, MidpointRounding.ToEven);
            ClampedUFix64 IMath<ClampedUFix64>.Round(ClampedUFix64 x, int digits) => Round(x, digits, MidpointRounding.ToEven);
            ClampedUFix64 IMath<ClampedUFix64>.Round(ClampedUFix64 x, int digits, MidpointRounding mode) => Round(x, digits, mode);
            ClampedUFix64 IMath<ClampedUFix64>.Round(ClampedUFix64 x, MidpointRounding mode) => Round(x, 0, mode);
            ClampedUFix64 IMath<ClampedUFix64>.Sin(ClampedUFix64 x) => (ClampedUFix64)Math.Sin((double)x);
            ClampedUFix64 IMath<ClampedUFix64>.Sinh(ClampedUFix64 x) => (ClampedUFix64)Math.Sinh((double)x);
            ClampedUFix64 IMath<ClampedUFix64>.Sqrt(ClampedUFix64 x) => (ClampedUFix64)Math.Sqrt((double)x);
            ClampedUFix64 IMath<ClampedUFix64>.Tan(ClampedUFix64 x) => (ClampedUFix64)Math.Tan((double)x);
            ClampedUFix64 IMath<ClampedUFix64>.Tanh(ClampedUFix64 x) => (ClampedUFix64)Math.Tanh((double)x);
            ClampedUFix64 IMath<ClampedUFix64>.Tau { get; } = (ClampedUFix64)(Math.PI * 2d);
            ClampedUFix64 IMath<ClampedUFix64>.Truncate(ClampedUFix64 x) => new ClampedUFix64(x._scaledValue / ScalingFactor * ScalingFactor);

            int INumericBitConverter<ClampedUFix64>.ConvertedSize => sizeof(ulong);
            ClampedUFix64 INumericBitConverter<ClampedUFix64>.ToNumeric(byte[] value, int startIndex) => new ClampedUFix64(BitConverter.ToUInt64(value, startIndex));
            byte[] INumericBitConverter<ClampedUFix64>.GetBytes(ClampedUFix64 value) => BitConverter.GetBytes(value._scaledValue);
#if HAS_SPANS
            ClampedUFix64 INumericBitConverter<ClampedUFix64>.ToNumeric(ReadOnlySpan<byte> value) => new ClampedUFix64(BitConverter.ToUInt64(value));
            bool INumericBitConverter<ClampedUFix64>.TryWriteBytes(Span<byte> destination, ClampedUFix64 value) => BitConverter.TryWriteBytes(destination, value._scaledValue);
#endif

            bool IConvert<ClampedUFix64>.ToBoolean(ClampedUFix64 value) => value._scaledValue != 0;
            byte IConvert<ClampedUFix64>.ToByte(ClampedUFix64 value, Conversion mode) => ConvertN.ToByte(value._scaledValue / ScalingFactor, mode.Clamped());
            decimal IConvert<ClampedUFix64>.ToDecimal(ClampedUFix64 value, Conversion mode) => (decimal)value._scaledValue / ScalingFactor;
            double IConvert<ClampedUFix64>.ToDouble(ClampedUFix64 value, Conversion mode) => Scaled.ToDouble(value._scaledValue, ScalingFactor);
            float IConvert<ClampedUFix64>.ToSingle(ClampedUFix64 value, Conversion mode) => (float)value._scaledValue / ScalingFactor;
            int IConvert<ClampedUFix64>.ToInt32(ClampedUFix64 value, Conversion mode) => ConvertN.ToInt32(value._scaledValue / ScalingFactor, mode.Clamped());
            long IConvert<ClampedUFix64>.ToInt64(ClampedUFix64 value, Conversion mode) => ConvertN.ToInt64(value._scaledValue / ScalingFactor, mode.Clamped());
            sbyte IConvertExtended<ClampedUFix64>.ToSByte(ClampedUFix64 value, Conversion mode) => ConvertN.ToSByte(value._scaledValue / ScalingFactor, mode.Clamped());
            short IConvert<ClampedUFix64>.ToInt16(ClampedUFix64 value, Conversion mode) => ConvertN.ToInt16(value._scaledValue / ScalingFactor, mode.Clamped());
            string IConvert<ClampedUFix64>.ToString(ClampedUFix64 value) => value.ToString();
            uint IConvertExtended<ClampedUFix64>.ToUInt32(ClampedUFix64 value, Conversion mode) => ConvertN.ToUInt32(value._scaledValue / ScalingFactor, mode.Clamped());
            ulong IConvertExtended<ClampedUFix64>.ToUInt64(ClampedUFix64 value, Conversion mode) => value._scaledValue / ScalingFactor;
            ushort IConvertExtended<ClampedUFix64>.ToUInt16(ClampedUFix64 value, Conversion mode) => ConvertN.ToUInt16(value._scaledValue / ScalingFactor, mode.Clamped());

            ClampedUFix64 IConvert<ClampedUFix64>.ToNumeric(bool value) => value ? new ClampedUFix64(ScalingFactor) : new ClampedUFix64(0);
            ClampedUFix64 IConvert<ClampedUFix64>.ToNumeric(byte value, Conversion mode) => (ClampedUFix64)ConvertN.ToUInt64(value, mode.Clamped());
            ClampedUFix64 IConvert<ClampedUFix64>.ToNumeric(decimal value, Conversion mode) => (ClampedUFix64)value;
            ClampedUFix64 IConvert<ClampedUFix64>.ToNumeric(double value, Conversion mode) => (ClampedUFix64)value;
            ClampedUFix64 IConvert<ClampedUFix64>.ToNumeric(float value, Conversion mode) => (ClampedUFix64)value;
            ClampedUFix64 IConvert<ClampedUFix64>.ToNumeric(int value, Conversion mode) => (ClampedUFix64)ConvertN.ToUInt64(value, mode.Clamped());
            ClampedUFix64 IConvert<ClampedUFix64>.ToNumeric(long value, Conversion mode) => (ClampedUFix64)value;
            ClampedUFix64 IConvertExtended<ClampedUFix64>.ToValue(sbyte value, Conversion mode) => (ClampedUFix64)ConvertN.ToUInt64(value, mode.Clamped());
            ClampedUFix64 IConvert<ClampedUFix64>.ToNumeric(short value, Conversion mode) => (ClampedUFix64)ConvertN.ToUInt64(value, mode.Clamped());
            ClampedUFix64 IConvert<ClampedUFix64>.ToNumeric(string value) => (ClampedUFix64)Convert.ToUInt64(value);
            ClampedUFix64 IConvertExtended<ClampedUFix64>.ToNumeric(uint value, Conversion mode) => (ClampedUFix64)ConvertN.ToUInt64(value, mode.Clamped());
            ClampedUFix64 IConvertExtended<ClampedUFix64>.ToNumeric(ulong value, Conversion mode) => (ClampedUFix64)value;
            ClampedUFix64 IConvertExtended<ClampedUFix64>.ToNumeric(ushort value, Conversion mode) => (ClampedUFix64)ConvertN.ToUInt64(value, mode.Clamped());

            ClampedUFix64 INumericStatic<ClampedUFix64>.Parse(string s, NumberStyles? style, IFormatProvider? provider)
                => Parse(s, style ?? NumberStyles.Number, provider);

            ClampedUFix64 INumericRandom<ClampedUFix64>.Generate(Random random) => new ClampedUFix64(random.NextUInt64(ScalingFactor));
            ClampedUFix64 INumericRandom<ClampedUFix64>.Generate(Random random, ClampedUFix64 maxValue) => new ClampedUFix64(random.NextUInt64(maxValue._scaledValue));
            ClampedUFix64 INumericRandom<ClampedUFix64>.Generate(Random random, ClampedUFix64 minValue, ClampedUFix64 maxValue) => new ClampedUFix64(random.NextUInt64(minValue._scaledValue, maxValue._scaledValue));
            ClampedUFix64 INumericRandom<ClampedUFix64>.Generate(Random random, Generation mode) => new ClampedUFix64(random.NextUInt64(0, mode == Generation.Extended ? ulong.MaxValue : ScalingFactor, mode));
            ClampedUFix64 INumericRandom<ClampedUFix64>.Generate(Random random, ClampedUFix64 minValue, ClampedUFix64 maxValue, Generation mode) => new ClampedUFix64(random.NextUInt64(minValue._scaledValue, maxValue._scaledValue, mode));

            ClampedUFix64 IVariantRandom<ClampedUFix64>.Generate(Random random, Variants variants) => new ClampedUFix64(random.NextUInt64(variants));

            private static ClampedUFix64 Round(ClampedUFix64 value, int digits, MidpointRounding mode)
            {
                if (digits < 0) throw new ArgumentOutOfRangeException(nameof(digits), digits, "Must be positive.");
                if (digits > 5) return value;
                return new ClampedUFix64(Scaled.Round(value._scaledValue, 6 - digits, mode));
            }
        }
    }
}
