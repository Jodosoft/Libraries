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
using System.Globalization;
using System.IO;
using System.Runtime.Serialization;
using Jodosoft.Primitives;
using Jodosoft.Primitives.Compatibility;

namespace Jodosoft.Numerics
{
    /// <summary>
    /// Represents a decimal floating-point number that cannot overflow.
    /// </summary>
    [Serializable]
    [DebuggerDisplay("{ToString(),nq}")]
    public readonly struct ClampedDecimal : INumericExtended<ClampedDecimal>
    {
        public static readonly ClampedDecimal MaxValue = new ClampedDecimal(decimal.MaxValue);
        public static readonly ClampedDecimal MinValue = new ClampedDecimal(decimal.MinValue);

        private readonly decimal _value;

        public ClampedDecimal(decimal value)
        {
            _value = value;
        }

        private ClampedDecimal(SerializationInfo info, StreamingContext context) : this(info.GetDecimal(nameof(ClampedDecimal))) { }
        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context) => info.AddValue(nameof(ClampedDecimal), _value);

        public int CompareTo(ClampedDecimal other) => _value.CompareTo(other._value);
        public int CompareTo(object? obj) => obj is ClampedDecimal other ? CompareTo(other) : 1;
        public bool Equals(ClampedDecimal other) => _value == other._value;
        public override bool Equals(object? obj) => obj is ClampedDecimal other && Equals(other);
        public override int GetHashCode() => _value.GetHashCode();
        public override string ToString() => _value.ToString();
        public string ToString(IFormatProvider formatProvider) => _value.ToString(formatProvider);
        public string ToString(string format) => _value.ToString(format);
        public string ToString(string? format, IFormatProvider? formatProvider) => _value.ToString(format, formatProvider);

        public static bool TryParse(string s, IFormatProvider? provider, out ClampedDecimal result) => FuncExtensions.Try(() => Parse(s, provider), out result);
        public static bool TryParse(string s, NumberStyles style, IFormatProvider? provider, out ClampedDecimal result) => FuncExtensions.Try(() => Parse(s, style, provider), out result);
        public static bool TryParse(string s, NumberStyles style, out ClampedDecimal result) => FuncExtensions.Try(() => Parse(s, style), out result);
        public static bool TryParse(string s, out ClampedDecimal result) => FuncExtensions.Try(() => Parse(s), out result);
        public static ClampedDecimal Parse(string s) => decimal.Parse(s);
        public static ClampedDecimal Parse(string s, IFormatProvider? provider) => decimal.Parse(s, provider);
        public static ClampedDecimal Parse(string s, NumberStyles style) => decimal.Parse(s, style);
        public static ClampedDecimal Parse(string s, NumberStyles style, IFormatProvider? provider) => decimal.Parse(s, style, provider);

        [CLSCompliant(false)] public static implicit operator ClampedDecimal(sbyte value) => new ClampedDecimal(value);
        [CLSCompliant(false)] public static implicit operator ClampedDecimal(uint value) => new ClampedDecimal(value);
        [CLSCompliant(false)] public static implicit operator ClampedDecimal(ulong value) => new ClampedDecimal(value);
        [CLSCompliant(false)] public static implicit operator ClampedDecimal(ushort value) => new ClampedDecimal(value);
        public static explicit operator ClampedDecimal(double value) => new ClampedDecimal(ConvertN.ToDecimal(value, Conversion.CastClamp));
        public static explicit operator ClampedDecimal(float value) => new ClampedDecimal(ConvertN.ToDecimal(value, Conversion.CastClamp));
        public static implicit operator ClampedDecimal(byte value) => new ClampedDecimal(value);
        public static implicit operator ClampedDecimal(decimal value) => new ClampedDecimal(value);
        public static implicit operator ClampedDecimal(int value) => new ClampedDecimal(value);
        public static implicit operator ClampedDecimal(long value) => new ClampedDecimal(value);
        public static implicit operator ClampedDecimal(short value) => new ClampedDecimal(value);

        [CLSCompliant(false)] public static explicit operator sbyte(ClampedDecimal value) => ConvertN.ToSByte(value._value, Conversion.CastClamp);
        [CLSCompliant(false)] public static explicit operator uint(ClampedDecimal value) => ConvertN.ToUInt32(value._value, Conversion.CastClamp);
        [CLSCompliant(false)] public static explicit operator ulong(ClampedDecimal value) => ConvertN.ToUInt64(value._value, Conversion.CastClamp);
        [CLSCompliant(false)] public static explicit operator ushort(ClampedDecimal value) => ConvertN.ToUInt16(value._value, Conversion.CastClamp);
        public static explicit operator byte(ClampedDecimal value) => ConvertN.ToByte(value._value, Conversion.CastClamp);
        public static explicit operator double(ClampedDecimal value) => ConvertN.ToDouble(value._value, Conversion.CastClamp);
        public static explicit operator float(ClampedDecimal value) => ConvertN.ToSingle(value._value, Conversion.CastClamp);
        public static explicit operator int(ClampedDecimal value) => ConvertN.ToInt32(value._value, Conversion.CastClamp);
        public static explicit operator long(ClampedDecimal value) => ConvertN.ToInt64(value._value, Conversion.CastClamp);
        public static explicit operator short(ClampedDecimal value) => ConvertN.ToInt16(value._value, Conversion.CastClamp);
        public static implicit operator decimal(ClampedDecimal value) => value._value;

        public static bool operator !=(ClampedDecimal left, ClampedDecimal right) => left._value != right._value;
        public static bool operator <(ClampedDecimal left, ClampedDecimal right) => left._value < right._value;
        public static bool operator <=(ClampedDecimal left, ClampedDecimal right) => left._value <= right._value;
        public static bool operator ==(ClampedDecimal left, ClampedDecimal right) => left._value == right._value;
        public static bool operator >(ClampedDecimal left, ClampedDecimal right) => left._value > right._value;
        public static bool operator >=(ClampedDecimal left, ClampedDecimal right) => left._value >= right._value;
        public static ClampedDecimal operator %(ClampedDecimal left, ClampedDecimal right) => ClampedArithmetic.Remainder(left._value, right._value);
        public static ClampedDecimal operator &(ClampedDecimal left, ClampedDecimal right) => BitOperations.LogicalAnd(left._value, right._value);
        public static ClampedDecimal operator -(ClampedDecimal left, ClampedDecimal right) => ClampedArithmetic.Subtract(left._value, right._value);
        public static ClampedDecimal operator --(ClampedDecimal value) => value - 1;
        public static ClampedDecimal operator -(ClampedDecimal value) => -value._value;
        public static ClampedDecimal operator *(ClampedDecimal left, ClampedDecimal right) => ClampedArithmetic.Multiply(left._value, right._value);
        public static ClampedDecimal operator /(ClampedDecimal left, ClampedDecimal right) => ClampedArithmetic.Divide(left._value, right._value);
        public static ClampedDecimal operator ^(ClampedDecimal left, ClampedDecimal right) => BitOperations.LogicalExclusiveOr(left._value, right._value);
        public static ClampedDecimal operator |(ClampedDecimal left, ClampedDecimal right) => BitOperations.LogicalOr(left._value, right._value);
        public static ClampedDecimal operator ~(ClampedDecimal left) => BitOperations.BitwiseComplement(left._value);
        public static ClampedDecimal operator +(ClampedDecimal left, ClampedDecimal right) => ClampedArithmetic.Add(left._value, right._value);
        public static ClampedDecimal operator +(ClampedDecimal value) => value;
        public static ClampedDecimal operator ++(ClampedDecimal value) => value + 1;
        public static ClampedDecimal operator <<(ClampedDecimal left, int right) => BitOperations.LeftShift(left._value, right);
        public static ClampedDecimal operator >>(ClampedDecimal left, int right) => BitOperations.RightShift(left._value, right);

        TypeCode IConvertible.GetTypeCode() => _value.GetTypeCode();
        bool IConvertible.ToBoolean(IFormatProvider provider) => Convert.ToBoolean(_value, provider);
        byte IConvertible.ToByte(IFormatProvider provider) => ConvertN.ToByte(_value, Conversion.Clamp);
        char IConvertible.ToChar(IFormatProvider provider) => Convert.ToChar(_value, provider);
        DateTime IConvertible.ToDateTime(IFormatProvider provider) => Convert.ToDateTime(provider);
        decimal IConvertible.ToDecimal(IFormatProvider provider) => _value;
        double IConvertible.ToDouble(IFormatProvider provider) => ConvertN.ToDouble(_value, Conversion.Clamp);
        float IConvertible.ToSingle(IFormatProvider provider) => ConvertN.ToSingle(_value, Conversion.Clamp);
        int IConvertible.ToInt32(IFormatProvider provider) => ConvertN.ToInt32(_value, Conversion.Clamp);
        long IConvertible.ToInt64(IFormatProvider provider) => ConvertN.ToInt64(_value, Conversion.Clamp);
        sbyte IConvertible.ToSByte(IFormatProvider provider) => ConvertN.ToSByte(_value, Conversion.Clamp);
        short IConvertible.ToInt16(IFormatProvider provider) => ConvertN.ToInt16(_value, Conversion.Clamp);
        uint IConvertible.ToUInt32(IFormatProvider provider) => ConvertN.ToUInt32(_value, Conversion.Clamp);
        ulong IConvertible.ToUInt64(IFormatProvider provider) => ConvertN.ToUInt64(_value, Conversion.Clamp);
        ushort IConvertible.ToUInt16(IFormatProvider provider) => ConvertN.ToUInt16(_value, Conversion.Clamp);
        object IConvertible.ToType(Type conversionType, IFormatProvider provider) => this.ToTypeDefault(conversionType, provider);

        bool INumeric<ClampedDecimal>.IsGreaterThan(ClampedDecimal value) => this > value;
        bool INumeric<ClampedDecimal>.IsGreaterThanOrEqualTo(ClampedDecimal value) => this >= value;
        bool INumeric<ClampedDecimal>.IsLessThan(ClampedDecimal value) => this < value;
        bool INumeric<ClampedDecimal>.IsLessThanOrEqualTo(ClampedDecimal value) => this <= value;
        ClampedDecimal INumeric<ClampedDecimal>.Add(ClampedDecimal value) => this + value;
        ClampedDecimal INumeric<ClampedDecimal>.BitwiseComplement() => ~this;
        ClampedDecimal INumeric<ClampedDecimal>.Divide(ClampedDecimal value) => this / value;
        ClampedDecimal INumeric<ClampedDecimal>.LeftShift(int count) => this << count;
        ClampedDecimal INumeric<ClampedDecimal>.LogicalAnd(ClampedDecimal value) => this & value;
        ClampedDecimal INumeric<ClampedDecimal>.LogicalExclusiveOr(ClampedDecimal value) => this ^ value;
        ClampedDecimal INumeric<ClampedDecimal>.LogicalOr(ClampedDecimal value) => this | value;
        ClampedDecimal INumeric<ClampedDecimal>.Multiply(ClampedDecimal value) => this * value;
        ClampedDecimal INumeric<ClampedDecimal>.Negative() => -this;
        ClampedDecimal INumeric<ClampedDecimal>.Positive() => +this;
        ClampedDecimal INumeric<ClampedDecimal>.Remainder(ClampedDecimal value) => this % value;
        ClampedDecimal INumeric<ClampedDecimal>.RightShift(int count) => this >> count;
        ClampedDecimal INumeric<ClampedDecimal>.Subtract(ClampedDecimal value) => this - value;

        INumericBitConverter<ClampedDecimal> IProvider<INumericBitConverter<ClampedDecimal>>.GetInstance() => Utilities.Instance;
        IBinaryIO<ClampedDecimal> IProvider<IBinaryIO<ClampedDecimal>>.GetInstance() => Utilities.Instance;
        IConvert<ClampedDecimal> IProvider<IConvert<ClampedDecimal>>.GetInstance() => Utilities.Instance;
        IConvertExtended<ClampedDecimal> IProvider<IConvertExtended<ClampedDecimal>>.GetInstance() => Utilities.Instance;
        IMath<ClampedDecimal> IProvider<IMath<ClampedDecimal>>.GetInstance() => Utilities.Instance;
        INumericRandom<ClampedDecimal> IProvider<INumericRandom<ClampedDecimal>>.GetInstance() => Utilities.Instance;
        INumericStatic<ClampedDecimal> IProvider<INumericStatic<ClampedDecimal>>.GetInstance() => Utilities.Instance;
        IVariantRandom<ClampedDecimal> IProvider<IVariantRandom<ClampedDecimal>>.GetInstance() => Utilities.Instance;

        private sealed class Utilities :
            IBinaryIO<ClampedDecimal>,
            IConvert<ClampedDecimal>,
            IConvertExtended<ClampedDecimal>,
            IMath<ClampedDecimal>,
            INumericBitConverter<ClampedDecimal>,
            INumericRandom<ClampedDecimal>,
            INumericStatic<ClampedDecimal>,
            IVariantRandom<ClampedDecimal>
        {
            public static readonly Utilities Instance = new Utilities();

            void IBinaryIO<ClampedDecimal>.Write(BinaryWriter writer, ClampedDecimal value) => writer.Write(value);
            ClampedDecimal IBinaryIO<ClampedDecimal>.Read(BinaryReader reader) => reader.ReadDecimal();

            bool INumericStatic<ClampedDecimal>.HasFloatingPoint => true;
            bool INumericStatic<ClampedDecimal>.HasInfinity => false;
            bool INumericStatic<ClampedDecimal>.HasNaN => false;
            bool INumericStatic<ClampedDecimal>.IsFinite(ClampedDecimal x) => true;
            bool INumericStatic<ClampedDecimal>.IsInfinity(ClampedDecimal x) => false;
            bool INumericStatic<ClampedDecimal>.IsNaN(ClampedDecimal x) => false;
            bool INumericStatic<ClampedDecimal>.IsNegative(ClampedDecimal x) => x._value < 0;
            bool INumericStatic<ClampedDecimal>.IsNegativeInfinity(ClampedDecimal x) => false;
            bool INumericStatic<ClampedDecimal>.IsNormal(ClampedDecimal x) => false;
            bool INumericStatic<ClampedDecimal>.IsPositiveInfinity(ClampedDecimal x) => false;
            bool INumericStatic<ClampedDecimal>.IsReal => true;
            bool INumericStatic<ClampedDecimal>.IsSigned => true;
            bool INumericStatic<ClampedDecimal>.IsSubnormal(ClampedDecimal x) => false;
            ClampedDecimal INumericStatic<ClampedDecimal>.Epsilon { get; } = new decimal(1, 0, 0, false, 28);
            ClampedDecimal INumericStatic<ClampedDecimal>.MaxUnit => 1m;
            ClampedDecimal INumericStatic<ClampedDecimal>.MaxValue => MaxValue;
            ClampedDecimal INumericStatic<ClampedDecimal>.MinUnit => -1m;
            ClampedDecimal INumericStatic<ClampedDecimal>.MinValue => MinValue;
            ClampedDecimal INumericStatic<ClampedDecimal>.One => 1m;
            ClampedDecimal INumericStatic<ClampedDecimal>.Zero => 0m;

            ClampedDecimal IMath<ClampedDecimal>.Abs(ClampedDecimal value) => Math.Abs(value._value);
            ClampedDecimal IMath<ClampedDecimal>.Acos(ClampedDecimal x) => ConvertN.ToDecimal(Math.Acos(ConvertN.ToDouble(x._value, Conversion.CastClamp)), Conversion.CastClamp);
            ClampedDecimal IMath<ClampedDecimal>.Acosh(ClampedDecimal x) => ConvertN.ToDecimal(MathShim.Acosh(ConvertN.ToDouble(x._value, Conversion.CastClamp)), Conversion.CastClamp);
            ClampedDecimal IMath<ClampedDecimal>.Asin(ClampedDecimal x) => ConvertN.ToDecimal(Math.Asin(ConvertN.ToDouble(x._value, Conversion.CastClamp)), Conversion.CastClamp);
            ClampedDecimal IMath<ClampedDecimal>.Asinh(ClampedDecimal x) => ConvertN.ToDecimal(MathShim.Asinh(ConvertN.ToDouble(x._value, Conversion.CastClamp)), Conversion.CastClamp);
            ClampedDecimal IMath<ClampedDecimal>.Atan(ClampedDecimal x) => ConvertN.ToDecimal(Math.Atan(ConvertN.ToDouble(x._value, Conversion.CastClamp)), Conversion.CastClamp);
            ClampedDecimal IMath<ClampedDecimal>.Atan2(ClampedDecimal x, ClampedDecimal y) => ConvertN.ToDecimal(Math.Atan2(ConvertN.ToDouble(x._value, Conversion.CastClamp), ConvertN.ToDouble(y._value, Conversion.CastClamp)), Conversion.CastClamp);
            ClampedDecimal IMath<ClampedDecimal>.Atanh(ClampedDecimal x) => ConvertN.ToDecimal(MathShim.Atanh(ConvertN.ToDouble(x._value, Conversion.CastClamp)), Conversion.CastClamp);
            ClampedDecimal IMath<ClampedDecimal>.Cbrt(ClampedDecimal x) => ConvertN.ToDecimal(MathShim.Cbrt(ConvertN.ToDouble(x._value, Conversion.CastClamp)), Conversion.CastClamp);
            ClampedDecimal IMath<ClampedDecimal>.Ceiling(ClampedDecimal x) => decimal.Ceiling(x._value);
            ClampedDecimal IMath<ClampedDecimal>.Clamp(ClampedDecimal x, ClampedDecimal bound1, ClampedDecimal bound2) => bound1 > bound2 ? Math.Min(bound1._value, Math.Max(bound2._value, x._value)) : Math.Min(bound2._value, Math.Max(bound1._value, x._value));
            ClampedDecimal IMath<ClampedDecimal>.Cos(ClampedDecimal x) => ConvertN.ToDecimal(Math.Cos(ConvertN.ToDouble(x._value, Conversion.CastClamp)), Conversion.CastClamp);
            ClampedDecimal IMath<ClampedDecimal>.Cosh(ClampedDecimal x) => ConvertN.ToDecimal(Math.Cosh(ConvertN.ToDouble(x._value, Conversion.CastClamp)), Conversion.CastClamp);
            ClampedDecimal IMath<ClampedDecimal>.E { get; } = (decimal)Math.E;
            ClampedDecimal IMath<ClampedDecimal>.Exp(ClampedDecimal x) => ConvertN.ToDecimal(Math.Exp(ConvertN.ToDouble(x._value, Conversion.CastClamp)), Conversion.CastClamp);
            ClampedDecimal IMath<ClampedDecimal>.Floor(ClampedDecimal x) => decimal.Floor(x._value);
            ClampedDecimal IMath<ClampedDecimal>.IEEERemainder(ClampedDecimal x, ClampedDecimal y) => ConvertN.ToDecimal(Math.IEEERemainder(ConvertN.ToDouble(x._value, Conversion.CastClamp), ConvertN.ToDouble(y._value, Conversion.CastClamp)), Conversion.CastClamp);
            ClampedDecimal IMath<ClampedDecimal>.Log(ClampedDecimal x) => ConvertN.ToDecimal(Math.Log(ConvertN.ToDouble(x._value, Conversion.CastClamp)), Conversion.CastClamp);
            ClampedDecimal IMath<ClampedDecimal>.Log(ClampedDecimal x, ClampedDecimal y) => ConvertN.ToDecimal(Math.Log(ConvertN.ToDouble(x._value, Conversion.CastClamp), ConvertN.ToDouble(y._value, Conversion.CastClamp)), Conversion.CastClamp);
            ClampedDecimal IMath<ClampedDecimal>.Log10(ClampedDecimal x) => ConvertN.ToDecimal(Math.Log10(ConvertN.ToDouble(x._value, Conversion.CastClamp)), Conversion.CastClamp);
            ClampedDecimal IMath<ClampedDecimal>.Max(ClampedDecimal x, ClampedDecimal y) => Math.Max(x._value, y._value);
            ClampedDecimal IMath<ClampedDecimal>.Min(ClampedDecimal x, ClampedDecimal y) => Math.Min(x._value, y._value);
            ClampedDecimal IMath<ClampedDecimal>.PI { get; } = (decimal)Math.PI;
            ClampedDecimal IMath<ClampedDecimal>.Pow(ClampedDecimal x, ClampedDecimal y) => y == 1 ? x : ConvertN.ToDecimal(Math.Pow(ConvertN.ToDouble(x._value, Conversion.CastClamp), ConvertN.ToDouble(y._value, Conversion.CastClamp)), Conversion.CastClamp);
            ClampedDecimal IMath<ClampedDecimal>.Round(ClampedDecimal x) => decimal.Round(x);
            ClampedDecimal IMath<ClampedDecimal>.Round(ClampedDecimal x, int digits) => decimal.Round(x, digits);
            ClampedDecimal IMath<ClampedDecimal>.Round(ClampedDecimal x, int digits, MidpointRounding mode) => decimal.Round(x, digits, mode);
            ClampedDecimal IMath<ClampedDecimal>.Round(ClampedDecimal x, MidpointRounding mode) => decimal.Round(x, mode);
            ClampedDecimal IMath<ClampedDecimal>.Sin(ClampedDecimal x) => ConvertN.ToDecimal(Math.Sin(ConvertN.ToDouble(x._value, Conversion.CastClamp)), Conversion.CastClamp);
            ClampedDecimal IMath<ClampedDecimal>.Sinh(ClampedDecimal x) => ConvertN.ToDecimal(Math.Sinh(ConvertN.ToDouble(x._value, Conversion.CastClamp)), Conversion.CastClamp);
            ClampedDecimal IMath<ClampedDecimal>.Sqrt(ClampedDecimal x) => ConvertN.ToDecimal(Math.Sqrt(ConvertN.ToDouble(x._value, Conversion.CastClamp)), Conversion.CastClamp);
            ClampedDecimal IMath<ClampedDecimal>.Tan(ClampedDecimal x) => ConvertN.ToDecimal(Math.Tan(ConvertN.ToDouble(x._value, Conversion.CastClamp)), Conversion.CastClamp);
            ClampedDecimal IMath<ClampedDecimal>.Tanh(ClampedDecimal x) => ConvertN.ToDecimal(Math.Tanh(ConvertN.ToDouble(x._value, Conversion.CastClamp)), Conversion.CastClamp);
            ClampedDecimal IMath<ClampedDecimal>.Tau { get; } = (decimal)Math.PI * 2m;
            ClampedDecimal IMath<ClampedDecimal>.Truncate(ClampedDecimal x) => decimal.Truncate(x._value);
            int IMath<ClampedDecimal>.Sign(ClampedDecimal x) => Math.Sign(x._value);

            int INumericBitConverter<ClampedDecimal>.ConvertedSize => sizeof(decimal);
            ClampedDecimal INumericBitConverter<ClampedDecimal>.ToNumeric(byte[] value, int startIndex) => BitOperations.ToDecimal(value, startIndex);
            byte[] INumericBitConverter<ClampedDecimal>.GetBytes(ClampedDecimal value) => BitOperations.GetBytes(value._value);
#if HAS_SPANS
            ClampedDecimal INumericBitConverter<ClampedDecimal>.ToNumeric(ReadOnlySpan<byte> value) => BitOperations.ToDecimal(value);
            bool INumericBitConverter<ClampedDecimal>.TryWriteBytes(Span<byte> destination, ClampedDecimal value) => BitOperations.TryWriteBytes(destination, value);
#endif

            bool IConvert<ClampedDecimal>.ToBoolean(ClampedDecimal value) => value._value != 0m;
            byte IConvert<ClampedDecimal>.ToByte(ClampedDecimal value, Conversion mode) => ConvertN.ToByte(value._value, mode.Clamped());
            decimal IConvert<ClampedDecimal>.ToDecimal(ClampedDecimal value, Conversion mode) => value._value;
            double IConvert<ClampedDecimal>.ToDouble(ClampedDecimal value, Conversion mode) => ConvertN.ToDouble(value._value, mode.Clamped());
            float IConvert<ClampedDecimal>.ToSingle(ClampedDecimal value, Conversion mode) => ConvertN.ToSingle(value._value, mode.Clamped());
            int IConvert<ClampedDecimal>.ToInt32(ClampedDecimal value, Conversion mode) => ConvertN.ToInt32(value._value, mode.Clamped());
            long IConvert<ClampedDecimal>.ToInt64(ClampedDecimal value, Conversion mode) => ConvertN.ToInt64(value._value, mode.Clamped());
            sbyte IConvertExtended<ClampedDecimal>.ToSByte(ClampedDecimal value, Conversion mode) => ConvertN.ToSByte(value._value, mode.Clamped());
            short IConvert<ClampedDecimal>.ToInt16(ClampedDecimal value, Conversion mode) => ConvertN.ToInt16(value._value, mode.Clamped());
            string IConvert<ClampedDecimal>.ToString(ClampedDecimal value) => Convert.ToString(value._value);
            uint IConvertExtended<ClampedDecimal>.ToUInt32(ClampedDecimal value, Conversion mode) => ConvertN.ToUInt32(value._value, mode.Clamped());
            ulong IConvertExtended<ClampedDecimal>.ToUInt64(ClampedDecimal value, Conversion mode) => ConvertN.ToUInt64(value._value, mode.Clamped());
            ushort IConvertExtended<ClampedDecimal>.ToUInt16(ClampedDecimal value, Conversion mode) => ConvertN.ToUInt16(value._value, mode.Clamped());

            ClampedDecimal IConvert<ClampedDecimal>.ToNumeric(bool value) => new ClampedDecimal(value ? 1m : 0m);
            ClampedDecimal IConvert<ClampedDecimal>.ToNumeric(byte value, Conversion mode) => ConvertN.ToDecimal(value, mode.Clamped());
            ClampedDecimal IConvert<ClampedDecimal>.ToNumeric(decimal value, Conversion mode) => value;
            ClampedDecimal IConvert<ClampedDecimal>.ToNumeric(double value, Conversion mode) => ConvertN.ToDecimal(value, mode.Clamped());
            ClampedDecimal IConvert<ClampedDecimal>.ToNumeric(float value, Conversion mode) => ConvertN.ToDecimal(value, mode.Clamped());
            ClampedDecimal IConvert<ClampedDecimal>.ToNumeric(int value, Conversion mode) => ConvertN.ToDecimal(value, mode.Clamped());
            ClampedDecimal IConvert<ClampedDecimal>.ToNumeric(long value, Conversion mode) => ConvertN.ToDecimal(value, mode.Clamped());
            ClampedDecimal IConvertExtended<ClampedDecimal>.ToValue(sbyte value, Conversion mode) => ConvertN.ToDecimal(value, mode.Clamped());
            ClampedDecimal IConvert<ClampedDecimal>.ToNumeric(short value, Conversion mode) => ConvertN.ToDecimal(value, mode.Clamped());
            ClampedDecimal IConvert<ClampedDecimal>.ToNumeric(string value) => Convert.ToDecimal(value);
            ClampedDecimal IConvertExtended<ClampedDecimal>.ToNumeric(uint value, Conversion mode) => ConvertN.ToDecimal(value, mode.Clamped());
            ClampedDecimal IConvertExtended<ClampedDecimal>.ToNumeric(ulong value, Conversion mode) => ConvertN.ToDecimal(value, mode.Clamped());
            ClampedDecimal IConvertExtended<ClampedDecimal>.ToNumeric(ushort value, Conversion mode) => ConvertN.ToDecimal(value, mode.Clamped());

            ClampedDecimal INumericStatic<ClampedDecimal>.Parse(string s, NumberStyles? style, IFormatProvider? provider)
                => Parse(s, style ?? NumberStyles.Number, provider);

            ClampedDecimal INumericRandom<ClampedDecimal>.Generate(Random random) => random.NextDecimal(1);
            ClampedDecimal INumericRandom<ClampedDecimal>.Generate(Random random, ClampedDecimal maxValue) => random.NextDecimal(maxValue);
            ClampedDecimal INumericRandom<ClampedDecimal>.Generate(Random random, ClampedDecimal minValue, ClampedDecimal maxValue) => random.NextDecimal(minValue, maxValue);
            ClampedDecimal INumericRandom<ClampedDecimal>.Generate(Random random, Generation mode) => random.NextDecimal(mode == Generation.Extended ? decimal.MinValue : 0, mode == Generation.Extended ? decimal.MaxValue : 1, mode);
            ClampedDecimal INumericRandom<ClampedDecimal>.Generate(Random random, ClampedDecimal minValue, ClampedDecimal maxValue, Generation mode) => random.NextDecimal(minValue, maxValue, mode);

            ClampedDecimal IVariantRandom<ClampedDecimal>.Generate(Random random, Variants variants) => random.NextDecimal(variants);
        }
    }
}
