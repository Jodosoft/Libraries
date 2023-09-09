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
    /// Represents a double-precision floating-point number.
    /// </summary>
    [Serializable]
    [DebuggerDisplay("{ToString(),nq}")]
    public readonly struct NDouble : INumericExtended<NDouble>
    {
        public static readonly NDouble Epsilon = double.Epsilon;
        public static readonly NDouble MaxValue = double.MaxValue;
        public static readonly NDouble MinValue = double.MinValue;

        private readonly double _value;

        private NDouble(double value)
        {
            _value = value;
        }

        private NDouble(SerializationInfo info, StreamingContext context) : this(info.GetDouble(nameof(NDouble))) { }
        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context) => info.AddValue(nameof(NDouble), _value);

        public int CompareTo(NDouble other) => _value.CompareTo(other._value);
        public int CompareTo(object? obj) => obj is NDouble other ? CompareTo(other) : 1;
        public bool Equals(NDouble other) => _value == other._value;
        public override bool Equals(object? obj) => obj is NDouble other && Equals(other);
        public override int GetHashCode() => _value.GetHashCode();
        public override string ToString() => _value.ToString();
        public string ToString(IFormatProvider formatProvider) => _value.ToString(formatProvider);
        public string ToString(string format) => _value.ToString(format);
        public string ToString(string? format, IFormatProvider? formatProvider) => _value.ToString(format, formatProvider);

        public static bool IsFinite(NDouble d) => DoubleShim.IsFinite(d);
        public static bool IsInfinity(NDouble d) => double.IsInfinity(d);
        public static bool IsNaN(NDouble d) => double.IsNaN(d);
        public static bool IsNegative(NDouble d) => DoubleShim.IsNegative(d);
        public static bool IsNegativeInfinity(NDouble d) => double.IsNegativeInfinity(d);
        public static bool IsNormal(NDouble d) => DoubleShim.IsNormal(d);
        public static bool IsPositiveInfinity(NDouble d) => double.IsPositiveInfinity(d);
        public static bool IsSubnormal(NDouble d) => DoubleShim.IsSubnormal(d);

        public static bool TryParse(string s, IFormatProvider? provider, out NDouble result) => FuncExtensions.Try(() => Parse(s, provider), out result);
        public static bool TryParse(string s, NumberStyles style, IFormatProvider? provider, out NDouble result) => FuncExtensions.Try(() => Parse(s, style, provider), out result);
        public static bool TryParse(string s, NumberStyles style, out NDouble result) => FuncExtensions.Try(() => Parse(s, style), out result);
        public static bool TryParse(string s, out NDouble result) => FuncExtensions.Try(() => Parse(s), out result);
        public static NDouble Parse(string s) => double.Parse(s);
        public static NDouble Parse(string s, IFormatProvider? provider) => double.Parse(s, provider);
        public static NDouble Parse(string s, NumberStyles style) => double.Parse(s, style);
        public static NDouble Parse(string s, NumberStyles style, IFormatProvider? provider) => double.Parse(s, style, provider);

        [CLSCompliant(false)] public static implicit operator NDouble(sbyte value) => new NDouble(value);
        [CLSCompliant(false)] public static implicit operator NDouble(uint value) => new NDouble(value);
        [CLSCompliant(false)] public static implicit operator NDouble(ulong value) => new NDouble(value);
        [CLSCompliant(false)] public static implicit operator NDouble(ushort value) => new NDouble(value);
        public static explicit operator NDouble(decimal value) => new NDouble((double)value);
        public static implicit operator NDouble(byte value) => new NDouble(value);
        public static implicit operator NDouble(double value) => new NDouble(value);
        public static implicit operator NDouble(float value) => new NDouble(value);
        public static implicit operator NDouble(int value) => new NDouble(value);
        public static implicit operator NDouble(long value) => new NDouble(value);
        public static implicit operator NDouble(short value) => new NDouble(value);

        [CLSCompliant(false)] public static explicit operator sbyte(NDouble value) => (sbyte)value._value;
        [CLSCompliant(false)] public static explicit operator uint(NDouble value) => (uint)value._value;
        [CLSCompliant(false)] public static explicit operator ulong(NDouble value) => (ulong)value._value;
        [CLSCompliant(false)] public static explicit operator ushort(NDouble value) => (ushort)value._value;
        public static explicit operator byte(NDouble value) => (byte)value._value;
        public static explicit operator decimal(NDouble value) => (decimal)value._value;
        public static explicit operator float(NDouble value) => (float)value._value;
        public static explicit operator int(NDouble value) => (int)value._value;
        public static explicit operator long(NDouble value) => (long)value._value;
        public static explicit operator short(NDouble value) => (short)value._value;
        public static implicit operator double(NDouble value) => value._value;

        public static bool operator !=(NDouble left, NDouble right) => left._value != right._value;
        public static bool operator <(NDouble left, NDouble right) => left._value < right._value;
        public static bool operator <=(NDouble left, NDouble right) => left._value <= right._value;
        public static bool operator ==(NDouble left, NDouble right) => left._value == right._value;
        public static bool operator >(NDouble left, NDouble right) => left._value > right._value;
        public static bool operator >=(NDouble left, NDouble right) => left._value >= right._value;
        public static NDouble operator %(NDouble left, NDouble right) => left._value % right._value;
        public static NDouble operator &(NDouble left, NDouble right) => BitOperations.LogicalAnd(left._value, right._value);
        public static NDouble operator -(NDouble left, NDouble right) => left._value - right._value;
        public static NDouble operator --(NDouble value) => value._value - 1;
        public static NDouble operator -(NDouble value) => -value._value;
        public static NDouble operator *(NDouble left, NDouble right) => left._value * right._value;
        public static NDouble operator /(NDouble left, NDouble right) => left._value / right._value;
        public static NDouble operator ^(NDouble left, NDouble right) => BitOperations.LogicalExclusiveOr(left._value, right._value);
        public static NDouble operator |(NDouble left, NDouble right) => BitOperations.LogicalOr(left._value, right._value);
        public static NDouble operator ~(NDouble left) => BitOperations.BitwiseComplement(left._value);
        public static NDouble operator +(NDouble left, NDouble right) => left._value + right._value;
        public static NDouble operator +(NDouble value) => value;
        public static NDouble operator ++(NDouble value) => value._value + 1;
        public static NDouble operator <<(NDouble left, int right) => BitOperations.LeftShift(left._value, right);
        public static NDouble operator >>(NDouble left, int right) => BitOperations.RightShift(left._value, right);

        TypeCode IConvertible.GetTypeCode() => _value.GetTypeCode();
        bool IConvertible.ToBoolean(IFormatProvider provider) => ((IConvertible)_value).ToBoolean(provider);
        char IConvertible.ToChar(IFormatProvider provider) => ((IConvertible)_value).ToChar(provider);
        sbyte IConvertible.ToSByte(IFormatProvider provider) => ((IConvertible)_value).ToSByte(provider);
        byte IConvertible.ToByte(IFormatProvider provider) => ((IConvertible)_value).ToByte(provider);
        short IConvertible.ToInt16(IFormatProvider provider) => ((IConvertible)_value).ToInt16(provider);
        ushort IConvertible.ToUInt16(IFormatProvider provider) => ((IConvertible)_value).ToUInt16(provider);
        int IConvertible.ToInt32(IFormatProvider provider) => ((IConvertible)_value).ToInt32(provider);
        uint IConvertible.ToUInt32(IFormatProvider provider) => ((IConvertible)_value).ToUInt32(provider);
        long IConvertible.ToInt64(IFormatProvider provider) => ((IConvertible)_value).ToInt64(provider);
        ulong IConvertible.ToUInt64(IFormatProvider provider) => ((IConvertible)_value).ToUInt64(provider);
        float IConvertible.ToSingle(IFormatProvider provider) => ((IConvertible)_value).ToSingle(provider);
        double IConvertible.ToDouble(IFormatProvider provider) => ((IConvertible)_value).ToDouble(provider);
        decimal IConvertible.ToDecimal(IFormatProvider provider) => ((IConvertible)_value).ToDecimal(provider);
        DateTime IConvertible.ToDateTime(IFormatProvider provider) => ((IConvertible)_value).ToDateTime(provider);
        object IConvertible.ToType(Type conversionType, IFormatProvider provider) => this.ToTypeDefault(conversionType, provider);

        bool INumeric<NDouble>.IsGreaterThan(NDouble value) => this > value;
        bool INumeric<NDouble>.IsGreaterThanOrEqualTo(NDouble value) => this >= value;
        bool INumeric<NDouble>.IsLessThan(NDouble value) => this < value;
        bool INumeric<NDouble>.IsLessThanOrEqualTo(NDouble value) => this <= value;
        NDouble INumeric<NDouble>.Add(NDouble value) => this + value;
        NDouble INumeric<NDouble>.BitwiseComplement() => ~this;
        NDouble INumeric<NDouble>.Divide(NDouble value) => this / value;
        NDouble INumeric<NDouble>.LeftShift(int count) => this << count;
        NDouble INumeric<NDouble>.LogicalAnd(NDouble value) => this & value;
        NDouble INumeric<NDouble>.LogicalExclusiveOr(NDouble value) => this ^ value;
        NDouble INumeric<NDouble>.LogicalOr(NDouble value) => this | value;
        NDouble INumeric<NDouble>.Multiply(NDouble value) => this * value;
        NDouble INumeric<NDouble>.Negative() => -this;
        NDouble INumeric<NDouble>.Positive() => +this;
        NDouble INumeric<NDouble>.Remainder(NDouble value) => this % value;
        NDouble INumeric<NDouble>.RightShift(int count) => this >> count;
        NDouble INumeric<NDouble>.Subtract(NDouble value) => this - value;

        INumericBitConverter<NDouble> IProvider<INumericBitConverter<NDouble>>.GetInstance() => Utilities.Instance;
        IBinaryIO<NDouble> IProvider<IBinaryIO<NDouble>>.GetInstance() => Utilities.Instance;
        IConvert<NDouble> IProvider<IConvert<NDouble>>.GetInstance() => Utilities.Instance;
        IConvertExtended<NDouble> IProvider<IConvertExtended<NDouble>>.GetInstance() => Utilities.Instance;
        IMath<NDouble> IProvider<IMath<NDouble>>.GetInstance() => Utilities.Instance;
        INumericRandom<NDouble> IProvider<INumericRandom<NDouble>>.GetInstance() => Utilities.Instance;
        INumericStatic<NDouble> IProvider<INumericStatic<NDouble>>.GetInstance() => Utilities.Instance;
        IVariantRandom<NDouble> IProvider<IVariantRandom<NDouble>>.GetInstance() => Utilities.Instance;

        private sealed class Utilities :
            IBinaryIO<NDouble>,
            IConvert<NDouble>,
            IConvertExtended<NDouble>,
            IMath<NDouble>,
            INumericBitConverter<NDouble>,
            INumericRandom<NDouble>,
            INumericStatic<NDouble>,
            IVariantRandom<NDouble>
        {
            public static readonly Utilities Instance = new Utilities();

            void IBinaryIO<NDouble>.Write(BinaryWriter writer, NDouble value) => writer.Write(value);
            NDouble IBinaryIO<NDouble>.Read(BinaryReader reader) => reader.ReadDouble();

            bool INumericStatic<NDouble>.HasFloatingPoint => true;
            bool INumericStatic<NDouble>.HasInfinity => true;
            bool INumericStatic<NDouble>.HasNaN => true;
            bool INumericStatic<NDouble>.IsFinite(NDouble x) => IsFinite(x);
            bool INumericStatic<NDouble>.IsInfinity(NDouble x) => IsInfinity(x);
            bool INumericStatic<NDouble>.IsNaN(NDouble x) => IsNaN(x);
            bool INumericStatic<NDouble>.IsNegative(NDouble x) => IsNegative(x);
            bool INumericStatic<NDouble>.IsNegativeInfinity(NDouble x) => IsNegativeInfinity(x);
            bool INumericStatic<NDouble>.IsNormal(NDouble x) => IsNormal(x);
            bool INumericStatic<NDouble>.IsPositiveInfinity(NDouble x) => IsPositiveInfinity(x);
            bool INumericStatic<NDouble>.IsReal => true;
            bool INumericStatic<NDouble>.IsSigned => true;
            bool INumericStatic<NDouble>.IsSubnormal(NDouble x) => IsSubnormal(x);
            NDouble INumericStatic<NDouble>.Epsilon => Epsilon;
            NDouble INumericStatic<NDouble>.MaxUnit => 1d;
            NDouble INumericStatic<NDouble>.MaxValue => MaxValue;
            NDouble INumericStatic<NDouble>.MinUnit => -1d;
            NDouble INumericStatic<NDouble>.MinValue => MinValue;
            NDouble INumericStatic<NDouble>.One => 1d;
            NDouble INumericStatic<NDouble>.Zero => 0d;

            int IMath<NDouble>.Sign(NDouble x) => Math.Sign(x._value);
            NDouble IMath<NDouble>.Abs(NDouble value) => Math.Abs(value._value);
            NDouble IMath<NDouble>.Acos(NDouble x) => Math.Acos(x._value);
            NDouble IMath<NDouble>.Acosh(NDouble x) => MathShim.Acosh(x._value);
            NDouble IMath<NDouble>.Asin(NDouble x) => Math.Asin(x._value);
            NDouble IMath<NDouble>.Asinh(NDouble x) => MathShim.Asinh(x._value);
            NDouble IMath<NDouble>.Atan(NDouble x) => Math.Atan(x._value);
            NDouble IMath<NDouble>.Atan2(NDouble x, NDouble y) => Math.Atan2(x._value, y._value);
            NDouble IMath<NDouble>.Atanh(NDouble x) => MathShim.Atanh(x._value);
            NDouble IMath<NDouble>.Cbrt(NDouble x) => MathShim.Cbrt(x._value);
            NDouble IMath<NDouble>.Ceiling(NDouble x) => Math.Ceiling(x._value);
            NDouble IMath<NDouble>.Clamp(NDouble x, NDouble bound1, NDouble bound2) => bound1 > bound2 ? Math.Min(bound1._value, Math.Max(bound2._value, x._value)) : Math.Min(bound2._value, Math.Max(bound1._value, x._value));
            NDouble IMath<NDouble>.Cos(NDouble x) => Math.Cos(x._value);
            NDouble IMath<NDouble>.Cosh(NDouble x) => Math.Cosh(x._value);
            NDouble IMath<NDouble>.E { get; } = Math.E;
            NDouble IMath<NDouble>.Exp(NDouble x) => Math.Exp(x._value);
            NDouble IMath<NDouble>.Floor(NDouble x) => Math.Floor(x._value);
            NDouble IMath<NDouble>.IEEERemainder(NDouble x, NDouble y) => Math.IEEERemainder(x._value, y._value);
            NDouble IMath<NDouble>.Log(NDouble x) => Math.Log(x._value);
            NDouble IMath<NDouble>.Log(NDouble x, NDouble y) => Math.Log(x._value, y._value);
            NDouble IMath<NDouble>.Log10(NDouble x) => Math.Log10(x._value);
            NDouble IMath<NDouble>.Max(NDouble x, NDouble y) => Math.Max(x._value, y._value);
            NDouble IMath<NDouble>.Min(NDouble x, NDouble y) => Math.Min(x._value, y._value);
            NDouble IMath<NDouble>.PI { get; } = Math.PI;
            NDouble IMath<NDouble>.Pow(NDouble x, NDouble y) => Math.Pow(x._value, y._value);
            NDouble IMath<NDouble>.Round(NDouble x) => Math.Round(x._value);
            NDouble IMath<NDouble>.Round(NDouble x, int digits) => Math.Round(x._value, digits);
            NDouble IMath<NDouble>.Round(NDouble x, int digits, MidpointRounding mode) => Math.Round(x._value, digits, mode);
            NDouble IMath<NDouble>.Round(NDouble x, MidpointRounding mode) => Math.Round(x._value, mode);
            NDouble IMath<NDouble>.Sin(NDouble x) => Math.Sin(x._value);
            NDouble IMath<NDouble>.Sinh(NDouble x) => Math.Sinh(x._value);
            NDouble IMath<NDouble>.Sqrt(NDouble x) => Math.Sqrt(x._value);
            NDouble IMath<NDouble>.Tan(NDouble x) => Math.Tan(x._value);
            NDouble IMath<NDouble>.Tanh(NDouble x) => Math.Tanh(x._value);
            NDouble IMath<NDouble>.Tau { get; } = Math.PI * 2d;
            NDouble IMath<NDouble>.Truncate(NDouble x) => Math.Truncate(x._value);

            int INumericBitConverter<NDouble>.ConvertedSize => sizeof(double);
            NDouble INumericBitConverter<NDouble>.ToNumeric(byte[] value, int startIndex) => BitConverter.ToDouble(value, startIndex);
            byte[] INumericBitConverter<NDouble>.GetBytes(NDouble value) => BitConverter.GetBytes(value._value);
#if HAS_SPANS
            NDouble INumericBitConverter<NDouble>.ToNumeric(ReadOnlySpan<byte> value) => BitConverter.ToDouble(value);
            bool INumericBitConverter<NDouble>.TryWriteBytes(Span<byte> destination, NDouble value) => BitConverter.TryWriteBytes(destination, value);
#endif

            bool IConvert<NDouble>.ToBoolean(NDouble value) => Convert.ToBoolean(value._value);
            byte IConvert<NDouble>.ToByte(NDouble value, Conversion mode) => ConvertN.ToByte(value._value, mode);
            decimal IConvert<NDouble>.ToDecimal(NDouble value, Conversion mode) => ConvertN.ToDecimal(value._value, mode);
            double IConvert<NDouble>.ToDouble(NDouble value, Conversion mode) => value._value;
            float IConvert<NDouble>.ToSingle(NDouble value, Conversion mode) => ConvertN.ToSingle(value._value, mode);
            int IConvert<NDouble>.ToInt32(NDouble value, Conversion mode) => ConvertN.ToInt32(value._value, mode);
            long IConvert<NDouble>.ToInt64(NDouble value, Conversion mode) => ConvertN.ToInt64(value._value, mode);
            sbyte IConvertExtended<NDouble>.ToSByte(NDouble value, Conversion mode) => ConvertN.ToSByte(value._value, mode);
            short IConvert<NDouble>.ToInt16(NDouble value, Conversion mode) => ConvertN.ToInt16(value._value, mode);
            string IConvert<NDouble>.ToString(NDouble value) => Convert.ToString(value._value);
            uint IConvertExtended<NDouble>.ToUInt32(NDouble value, Conversion mode) => ConvertN.ToUInt32(value._value, mode);
            ulong IConvertExtended<NDouble>.ToUInt64(NDouble value, Conversion mode) => ConvertN.ToUInt64(value._value, mode);
            ushort IConvertExtended<NDouble>.ToUInt16(NDouble value, Conversion mode) => ConvertN.ToUInt16(value._value, mode);

            NDouble IConvert<NDouble>.ToNumeric(bool value) => Convert.ToDouble(value);
            NDouble IConvert<NDouble>.ToNumeric(byte value, Conversion mode) => ConvertN.ToDouble(value, mode);
            NDouble IConvert<NDouble>.ToNumeric(decimal value, Conversion mode) => ConvertN.ToDouble(value, mode);
            NDouble IConvert<NDouble>.ToNumeric(double value, Conversion mode) => value;
            NDouble IConvert<NDouble>.ToNumeric(float value, Conversion mode) => ConvertN.ToDouble(value, mode);
            NDouble IConvert<NDouble>.ToNumeric(int value, Conversion mode) => ConvertN.ToDouble(value, mode);
            NDouble IConvert<NDouble>.ToNumeric(long value, Conversion mode) => ConvertN.ToDouble(value, mode);
            NDouble IConvertExtended<NDouble>.ToValue(sbyte value, Conversion mode) => ConvertN.ToDouble(value, mode);
            NDouble IConvert<NDouble>.ToNumeric(short value, Conversion mode) => ConvertN.ToDouble(value, mode);
            NDouble IConvert<NDouble>.ToNumeric(string value) => Convert.ToDouble(value);
            NDouble IConvertExtended<NDouble>.ToNumeric(uint value, Conversion mode) => ConvertN.ToDouble(value, mode);
            NDouble IConvertExtended<NDouble>.ToNumeric(ulong value, Conversion mode) => ConvertN.ToDouble(value, mode);
            NDouble IConvertExtended<NDouble>.ToNumeric(ushort value, Conversion mode) => ConvertN.ToDouble(value, mode);

            NDouble INumericStatic<NDouble>.Parse(string s, NumberStyles? style, IFormatProvider? provider)
                => Parse(s, style ?? NumberStyles.Float | NumberStyles.AllowThousands, provider);

            NDouble INumericRandom<NDouble>.Generate(Random random) => random.NextDouble();
            NDouble INumericRandom<NDouble>.Generate(Random random, NDouble maxValue) => random.NextDouble(maxValue);
            NDouble INumericRandom<NDouble>.Generate(Random random, NDouble minValue, NDouble maxValue) => random.NextDouble(minValue, maxValue);
            NDouble INumericRandom<NDouble>.Generate(Random random, Generation mode) => random.NextDouble(mode);
            NDouble INumericRandom<NDouble>.Generate(Random random, NDouble minValue, NDouble maxValue, Generation mode) => random.NextDouble(minValue, maxValue, mode);

            NDouble IVariantRandom<NDouble>.Generate(Random random, Variants variants) => random.NextDouble(variants);
        }
    }
}
