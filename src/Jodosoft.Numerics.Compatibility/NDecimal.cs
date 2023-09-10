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

namespace Jodosoft.Numerics.Compatibility
{
    /// <summary>
    /// Represents a decimal floating-point number.
    /// </summary>
    [Serializable]
    [DebuggerDisplay("{ToString(),nq}")]
    public readonly struct NDecimal : INumericExtended<NDecimal>
    {
        public static readonly NDecimal MaxValue = new NDecimal(decimal.MaxValue);
        public static readonly NDecimal MinValue = new NDecimal(decimal.MinValue);

        private readonly decimal _value;

        private NDecimal(decimal value)
        {
            _value = value;
        }

        private NDecimal(SerializationInfo info, StreamingContext context) : this(info.GetDecimal(nameof(NDecimal))) { }
        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context) => info.AddValue(nameof(NDecimal), _value);

        public int CompareTo(NDecimal other) => _value.CompareTo(other._value);
        public int CompareTo(object? obj) => obj is NDecimal other ? CompareTo(other) : 1;
        public bool Equals(NDecimal other) => _value == other._value;
        public override bool Equals(object? obj) => obj is NDecimal other && Equals(other);
        public override int GetHashCode() => _value.GetHashCode();
        public override string ToString() => _value.ToString();
        public string ToString(IFormatProvider? provider) => _value.ToString(provider);
        public string ToString(string format) => _value.ToString(format);
        public string ToString(string? format, IFormatProvider? formatProvider) => _value.ToString(format, formatProvider);

        public static bool TryParse(string s, IFormatProvider? provider, out NDecimal result) => FuncExtensions.Try(() => Parse(s, provider), out result);
        public static bool TryParse(string s, NumberStyles style, IFormatProvider? provider, out NDecimal result) => FuncExtensions.Try(() => Parse(s, style, provider), out result);
        public static bool TryParse(string s, NumberStyles style, out NDecimal result) => FuncExtensions.Try(() => Parse(s, style), out result);
        public static bool TryParse(string s, out NDecimal result) => FuncExtensions.Try(() => Parse(s), out result);
        public static NDecimal Parse(string s) => decimal.Parse(s);
        public static NDecimal Parse(string s, IFormatProvider? provider) => decimal.Parse(s, provider);
        public static NDecimal Parse(string s, NumberStyles style) => decimal.Parse(s, style);
        public static NDecimal Parse(string s, NumberStyles style, IFormatProvider? provider) => decimal.Parse(s, style, provider);

        [CLSCompliant(false)] public static implicit operator NDecimal(sbyte value) => new NDecimal(value);
        [CLSCompliant(false)] public static implicit operator NDecimal(uint value) => new NDecimal(value);
        [CLSCompliant(false)] public static implicit operator NDecimal(ulong value) => new NDecimal(value);
        [CLSCompliant(false)] public static implicit operator NDecimal(ushort value) => new NDecimal(value);
        public static explicit operator NDecimal(double value) => new NDecimal((decimal)value);
        public static explicit operator NDecimal(float value) => new NDecimal((decimal)value);
        public static implicit operator NDecimal(byte value) => new NDecimal(value);
        public static implicit operator NDecimal(decimal value) => new NDecimal(value);
        public static implicit operator NDecimal(int value) => new NDecimal(value);
        public static implicit operator NDecimal(long value) => new NDecimal(value);
        public static implicit operator NDecimal(short value) => new NDecimal(value);

        [CLSCompliant(false)] public static explicit operator sbyte(NDecimal value) => (sbyte)value._value;
        [CLSCompliant(false)] public static explicit operator uint(NDecimal value) => (uint)value._value;
        [CLSCompliant(false)] public static explicit operator ulong(NDecimal value) => (ulong)value._value;
        [CLSCompliant(false)] public static explicit operator ushort(NDecimal value) => (ushort)value._value;
        public static explicit operator byte(NDecimal value) => (byte)value._value;
        public static explicit operator double(NDecimal value) => (double)value._value;
        public static explicit operator float(NDecimal value) => (float)value._value;
        public static explicit operator int(NDecimal value) => (int)value._value;
        public static explicit operator long(NDecimal value) => (long)value._value;
        public static explicit operator short(NDecimal value) => (short)value._value;
        public static implicit operator decimal(NDecimal value) => value._value;

        public static bool operator !=(NDecimal left, NDecimal right) => left._value != right._value;
        public static bool operator <(NDecimal left, NDecimal right) => left._value < right._value;
        public static bool operator <=(NDecimal left, NDecimal right) => left._value <= right._value;
        public static bool operator ==(NDecimal left, NDecimal right) => left._value == right._value;
        public static bool operator >(NDecimal left, NDecimal right) => left._value > right._value;
        public static bool operator >=(NDecimal left, NDecimal right) => left._value >= right._value;
        public static NDecimal operator %(NDecimal left, NDecimal right) => left._value % right._value;
        public static NDecimal operator &(NDecimal left, NDecimal right) => BitOperations.LogicalAnd(left._value, right._value);
        public static NDecimal operator -(NDecimal left, NDecimal right) => left._value - right._value;
        public static NDecimal operator --(NDecimal value) => value._value - 1;
        public static NDecimal operator -(NDecimal value) => -value._value;
        public static NDecimal operator *(NDecimal left, NDecimal right) => left._value * right._value;
        public static NDecimal operator /(NDecimal left, NDecimal right) => left._value / right._value;
        public static NDecimal operator ^(NDecimal left, NDecimal right) => BitOperations.LogicalExclusiveOr(left._value, right._value);
        public static NDecimal operator |(NDecimal left, NDecimal right) => BitOperations.LogicalOr(left._value, right._value);
        public static NDecimal operator ~(NDecimal left) => BitOperations.BitwiseComplement(left._value);
        public static NDecimal operator +(NDecimal left, NDecimal right) => left._value + right._value;
        public static NDecimal operator +(NDecimal value) => value;
        public static NDecimal operator ++(NDecimal value) => value._value + 1;
        public static NDecimal operator <<(NDecimal left, int right) => BitOperations.LeftShift(left._value, right);
        public static NDecimal operator >>(NDecimal left, int right) => BitOperations.RightShift(left._value, right);

        TypeCode IConvertible.GetTypeCode() => _value.GetTypeCode();
        bool IConvertible.ToBoolean(IFormatProvider? provider) => ((IConvertible)_value).ToBoolean(provider);
        char IConvertible.ToChar(IFormatProvider? provider) => ((IConvertible)_value).ToChar(provider);
        sbyte IConvertible.ToSByte(IFormatProvider? provider) => ((IConvertible)_value).ToSByte(provider);
        byte IConvertible.ToByte(IFormatProvider? provider) => ((IConvertible)_value).ToByte(provider);
        short IConvertible.ToInt16(IFormatProvider? provider) => ((IConvertible)_value).ToInt16(provider);
        ushort IConvertible.ToUInt16(IFormatProvider? provider) => ((IConvertible)_value).ToUInt16(provider);
        int IConvertible.ToInt32(IFormatProvider? provider) => ((IConvertible)_value).ToInt32(provider);
        uint IConvertible.ToUInt32(IFormatProvider? provider) => ((IConvertible)_value).ToUInt32(provider);
        long IConvertible.ToInt64(IFormatProvider? provider) => ((IConvertible)_value).ToInt64(provider);
        ulong IConvertible.ToUInt64(IFormatProvider? provider) => ((IConvertible)_value).ToUInt64(provider);
        float IConvertible.ToSingle(IFormatProvider? provider) => ((IConvertible)_value).ToSingle(provider);
        double IConvertible.ToDouble(IFormatProvider? provider) => ((IConvertible)_value).ToDouble(provider);
        decimal IConvertible.ToDecimal(IFormatProvider? provider) => ((IConvertible)_value).ToDecimal(provider);
        DateTime IConvertible.ToDateTime(IFormatProvider? provider) => ((IConvertible)_value).ToDateTime(provider);
        object IConvertible.ToType(Type conversionType, IFormatProvider? provider) => this.ToTypeDefault(conversionType, provider);

        bool INumeric<NDecimal>.IsGreaterThan(NDecimal value) => this > value;
        bool INumeric<NDecimal>.IsGreaterThanOrEqualTo(NDecimal value) => this >= value;
        bool INumeric<NDecimal>.IsLessThan(NDecimal value) => this < value;
        bool INumeric<NDecimal>.IsLessThanOrEqualTo(NDecimal value) => this <= value;
        NDecimal INumeric<NDecimal>.Add(NDecimal value) => this + value;
        NDecimal INumeric<NDecimal>.BitwiseComplement() => ~this;
        NDecimal INumeric<NDecimal>.Divide(NDecimal value) => this / value;
        NDecimal INumeric<NDecimal>.LeftShift(int count) => this << count;
        NDecimal INumeric<NDecimal>.LogicalAnd(NDecimal value) => this & value;
        NDecimal INumeric<NDecimal>.LogicalExclusiveOr(NDecimal value) => this ^ value;
        NDecimal INumeric<NDecimal>.LogicalOr(NDecimal value) => this | value;
        NDecimal INumeric<NDecimal>.Multiply(NDecimal value) => this * value;
        NDecimal INumeric<NDecimal>.Negative() => -this;
        NDecimal INumeric<NDecimal>.Positive() => +this;
        NDecimal INumeric<NDecimal>.Remainder(NDecimal value) => this % value;
        NDecimal INumeric<NDecimal>.RightShift(int count) => this >> count;
        NDecimal INumeric<NDecimal>.Subtract(NDecimal value) => this - value;

        INumericBitConverter<NDecimal> IProvider<INumericBitConverter<NDecimal>>.GetInstance() => Utilities.Instance;
        IBinaryIO<NDecimal> IProvider<IBinaryIO<NDecimal>>.GetInstance() => Utilities.Instance;
        IConvert<NDecimal> IProvider<IConvert<NDecimal>>.GetInstance() => Utilities.Instance;
        IConvertExtended<NDecimal> IProvider<IConvertExtended<NDecimal>>.GetInstance() => Utilities.Instance;
        IMath<NDecimal> IProvider<IMath<NDecimal>>.GetInstance() => Utilities.Instance;
        INumericRandom<NDecimal> IProvider<INumericRandom<NDecimal>>.GetInstance() => Utilities.Instance;
        INumericStatic<NDecimal> IProvider<INumericStatic<NDecimal>>.GetInstance() => Utilities.Instance;
        IVariantRandom<NDecimal> IProvider<IVariantRandom<NDecimal>>.GetInstance() => Utilities.Instance;

        private sealed class Utilities :
            IBinaryIO<NDecimal>,
            IConvert<NDecimal>,
            IConvertExtended<NDecimal>,
            IMath<NDecimal>,
            INumericBitConverter<NDecimal>,
            INumericRandom<NDecimal>,
            INumericStatic<NDecimal>,
            IVariantRandom<NDecimal>
        {
            public static readonly Utilities Instance = new Utilities();

            void IBinaryIO<NDecimal>.Write(BinaryWriter writer, NDecimal value) => writer.Write(value);
            NDecimal IBinaryIO<NDecimal>.Read(BinaryReader reader) => reader.ReadDecimal();

            bool INumericStatic<NDecimal>.HasFloatingPoint => true;
            bool INumericStatic<NDecimal>.HasInfinity => false;
            bool INumericStatic<NDecimal>.HasNaN => false;
            bool INumericStatic<NDecimal>.IsFinite(NDecimal x) => true;
            bool INumericStatic<NDecimal>.IsInfinity(NDecimal x) => false;
            bool INumericStatic<NDecimal>.IsNaN(NDecimal x) => false;
            bool INumericStatic<NDecimal>.IsNegative(NDecimal x) => x._value < 0;
            bool INumericStatic<NDecimal>.IsNegativeInfinity(NDecimal x) => false;
            bool INumericStatic<NDecimal>.IsNormal(NDecimal x) => false;
            bool INumericStatic<NDecimal>.IsPositiveInfinity(NDecimal x) => false;
            bool INumericStatic<NDecimal>.IsReal => true;
            bool INumericStatic<NDecimal>.IsSigned => true;
            bool INumericStatic<NDecimal>.IsSubnormal(NDecimal x) => false;
            NDecimal INumericStatic<NDecimal>.Epsilon { get; } = new decimal(1, 0, 0, false, 28);
            NDecimal INumericStatic<NDecimal>.MaxUnit => 1m;
            NDecimal INumericStatic<NDecimal>.MaxValue => MaxValue;
            NDecimal INumericStatic<NDecimal>.MinUnit => -1m;
            NDecimal INumericStatic<NDecimal>.MinValue => MinValue;
            NDecimal INumericStatic<NDecimal>.One => 1m;
            NDecimal INumericStatic<NDecimal>.Zero => 0m;

            int IMath<NDecimal>.Sign(NDecimal x) => Math.Sign(x);
            NDecimal IMath<NDecimal>.Abs(NDecimal value) => Math.Abs(value);
            NDecimal IMath<NDecimal>.Acos(NDecimal x) => (NDecimal)Math.Acos((double)x);
            NDecimal IMath<NDecimal>.Acosh(NDecimal x) => (NDecimal)MathShim.Acosh((double)x);
            NDecimal IMath<NDecimal>.Asin(NDecimal x) => (NDecimal)Math.Asin((double)x);
            NDecimal IMath<NDecimal>.Asinh(NDecimal x) => (NDecimal)MathShim.Asinh((double)x);
            NDecimal IMath<NDecimal>.Atan(NDecimal x) => (NDecimal)Math.Atan((double)x);
            NDecimal IMath<NDecimal>.Atan2(NDecimal x, NDecimal y) => (NDecimal)Math.Atan2((double)x, (double)y);
            NDecimal IMath<NDecimal>.Atanh(NDecimal x) => (NDecimal)MathShim.Atanh((double)x);
            NDecimal IMath<NDecimal>.Cbrt(NDecimal x) => (NDecimal)MathShim.Cbrt((double)x);
            NDecimal IMath<NDecimal>.Ceiling(NDecimal x) => decimal.Ceiling(x);
            NDecimal IMath<NDecimal>.Clamp(NDecimal x, NDecimal bound1, NDecimal bound2) => bound1 > bound2 ? Math.Min(bound1, Math.Max(bound2, x)) : Math.Min(bound2, Math.Max(bound1, x));
            NDecimal IMath<NDecimal>.Cos(NDecimal x) => (NDecimal)Math.Cos((double)x);
            NDecimal IMath<NDecimal>.Cosh(NDecimal x) => (NDecimal)Math.Cosh((double)x);
            NDecimal IMath<NDecimal>.E { get; } = (NDecimal)Math.E;
            NDecimal IMath<NDecimal>.Exp(NDecimal x) => (NDecimal)Math.Exp((double)x);
            NDecimal IMath<NDecimal>.Floor(NDecimal x) => decimal.Floor(x);
            NDecimal IMath<NDecimal>.IEEERemainder(NDecimal x, NDecimal y) => (NDecimal)Math.IEEERemainder((double)x, (double)y);
            NDecimal IMath<NDecimal>.Log(NDecimal x) => (NDecimal)Math.Log((double)x);
            NDecimal IMath<NDecimal>.Log(NDecimal x, NDecimal y) => (NDecimal)Math.Log((double)x, (double)y);
            NDecimal IMath<NDecimal>.Log10(NDecimal x) => (NDecimal)Math.Log10((double)x);
            NDecimal IMath<NDecimal>.Max(NDecimal x, NDecimal y) => Math.Max(x, y);
            NDecimal IMath<NDecimal>.Min(NDecimal x, NDecimal y) => Math.Min(x, y);
            NDecimal IMath<NDecimal>.PI { get; } = (NDecimal)Math.PI;
            NDecimal IMath<NDecimal>.Pow(NDecimal x, NDecimal y) => y == 1 ? x : (NDecimal)Math.Pow((double)x, (double)y);
            NDecimal IMath<NDecimal>.Round(NDecimal x) => decimal.Round(x);
            NDecimal IMath<NDecimal>.Round(NDecimal x, int digits) => decimal.Round(x, digits);
            NDecimal IMath<NDecimal>.Round(NDecimal x, int digits, MidpointRounding mode) => decimal.Round(x, digits, mode);
            NDecimal IMath<NDecimal>.Round(NDecimal x, MidpointRounding mode) => decimal.Round(x, mode);
            NDecimal IMath<NDecimal>.Sin(NDecimal x) => (NDecimal)Math.Sin((double)x);
            NDecimal IMath<NDecimal>.Sinh(NDecimal x) => (NDecimal)Math.Sinh((double)x);
            NDecimal IMath<NDecimal>.Sqrt(NDecimal x) => (NDecimal)Math.Sqrt((double)x);
            NDecimal IMath<NDecimal>.Tan(NDecimal x) => (NDecimal)Math.Tan((double)x);
            NDecimal IMath<NDecimal>.Tanh(NDecimal x) => (NDecimal)Math.Tanh((double)x);
            NDecimal IMath<NDecimal>.Tau { get; } = (NDecimal)Math.PI * 2m;
            NDecimal IMath<NDecimal>.Truncate(NDecimal x) => decimal.Truncate(x);

            int INumericBitConverter<NDecimal>.ConvertedSize => sizeof(decimal);
            NDecimal INumericBitConverter<NDecimal>.ToNumeric(byte[] value, int startIndex) => BitOperations.ToDecimal(value, startIndex);
            byte[] INumericBitConverter<NDecimal>.GetBytes(NDecimal value) => BitOperations.GetBytes(value._value);
#if HAS_SPANS
            NDecimal INumericBitConverter<NDecimal>.ToNumeric(ReadOnlySpan<byte> value) => BitOperations.ToDecimal(value);
            bool INumericBitConverter<NDecimal>.TryWriteBytes(Span<byte> destination, NDecimal value) => BitOperations.TryWriteBytes(destination, value);
#endif

            bool IConvert<NDecimal>.ToBoolean(NDecimal value) => Convert.ToBoolean(value._value);
            byte IConvert<NDecimal>.ToByte(NDecimal value, Conversion mode) => ConvertN.ToByte(value._value, mode);
            decimal IConvert<NDecimal>.ToDecimal(NDecimal value, Conversion mode) => value;
            double IConvert<NDecimal>.ToDouble(NDecimal value, Conversion mode) => ConvertN.ToDouble(value._value, mode);
            float IConvert<NDecimal>.ToSingle(NDecimal value, Conversion mode) => ConvertN.ToSingle(value._value, mode);
            int IConvert<NDecimal>.ToInt32(NDecimal value, Conversion mode) => ConvertN.ToInt32(value._value, mode);
            long IConvert<NDecimal>.ToInt64(NDecimal value, Conversion mode) => ConvertN.ToInt64(value._value, mode);
            sbyte IConvertExtended<NDecimal>.ToSByte(NDecimal value, Conversion mode) => ConvertN.ToSByte(value._value, mode);
            short IConvert<NDecimal>.ToInt16(NDecimal value, Conversion mode) => ConvertN.ToInt16(value._value, mode);
            string IConvert<NDecimal>.ToString(NDecimal value) => Convert.ToString(value._value);
            uint IConvertExtended<NDecimal>.ToUInt32(NDecimal value, Conversion mode) => ConvertN.ToUInt32(value._value, mode);
            ulong IConvertExtended<NDecimal>.ToUInt64(NDecimal value, Conversion mode) => ConvertN.ToUInt64(value._value, mode);
            ushort IConvertExtended<NDecimal>.ToUInt16(NDecimal value, Conversion mode) => ConvertN.ToUInt16(value._value, mode);

            NDecimal IConvert<NDecimal>.ToNumeric(bool value) => Convert.ToDecimal(value);
            NDecimal IConvert<NDecimal>.ToNumeric(byte value, Conversion mode) => ConvertN.ToDecimal(value, mode);
            NDecimal IConvert<NDecimal>.ToNumeric(decimal value, Conversion mode) => value;
            NDecimal IConvert<NDecimal>.ToNumeric(double value, Conversion mode) => ConvertN.ToDecimal(value, mode);
            NDecimal IConvert<NDecimal>.ToNumeric(float value, Conversion mode) => ConvertN.ToDecimal(value, mode);
            NDecimal IConvert<NDecimal>.ToNumeric(int value, Conversion mode) => ConvertN.ToDecimal(value, mode);
            NDecimal IConvert<NDecimal>.ToNumeric(long value, Conversion mode) => ConvertN.ToDecimal(value, mode);
            NDecimal IConvertExtended<NDecimal>.ToValue(sbyte value, Conversion mode) => ConvertN.ToDecimal(value, mode);
            NDecimal IConvert<NDecimal>.ToNumeric(short value, Conversion mode) => ConvertN.ToDecimal(value, mode);
            NDecimal IConvert<NDecimal>.ToNumeric(string value) => Convert.ToDecimal(value);
            NDecimal IConvertExtended<NDecimal>.ToNumeric(uint value, Conversion mode) => ConvertN.ToDecimal(value, mode);
            NDecimal IConvertExtended<NDecimal>.ToNumeric(ulong value, Conversion mode) => ConvertN.ToDecimal(value, mode);
            NDecimal IConvertExtended<NDecimal>.ToNumeric(ushort value, Conversion mode) => ConvertN.ToDecimal(value, mode);

            NDecimal INumericStatic<NDecimal>.Parse(string s, NumberStyles? style, IFormatProvider? provider)
                => Parse(s, style ?? NumberStyles.Number, provider);

            NDecimal INumericRandom<NDecimal>.Generate(Random random) => random.NextDecimal(1);
            NDecimal INumericRandom<NDecimal>.Generate(Random random, NDecimal maxValue) => random.NextDecimal(maxValue);
            NDecimal INumericRandom<NDecimal>.Generate(Random random, NDecimal minValue, NDecimal maxValue) => random.NextDecimal(minValue, maxValue);
            NDecimal INumericRandom<NDecimal>.Generate(Random random, Generation mode) => random.NextDecimal(mode == Generation.Extended ? decimal.MinValue : 0, mode == Generation.Extended ? decimal.MaxValue : 1, mode);
            NDecimal INumericRandom<NDecimal>.Generate(Random random, NDecimal minValue, NDecimal maxValue, Generation mode) => random.NextDecimal(minValue, maxValue, mode);

            NDecimal IVariantRandom<NDecimal>.Generate(Random random, Variants variants) => random.NextDecimal(variants);
        }
    }
}
