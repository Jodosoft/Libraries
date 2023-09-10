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
    /// Represents a double-precision floating-point number that cannot overflow.
    /// </summary>
    [Serializable]
    [DebuggerDisplay("{ToString(),nq}")]
    public readonly struct ClampedDouble : INumericExtended<ClampedDouble>
    {
        public static readonly ClampedDouble Epsilon = double.Epsilon;
        public static readonly ClampedDouble MaxValue = double.MaxValue;
        public static readonly ClampedDouble MinValue = double.MinValue;

        private readonly double _value;

        public ClampedDouble(double value)
        {
            _value = Check(value);
        }

        private ClampedDouble(SerializationInfo info, StreamingContext context)
        {
            _value = Check(info.GetDouble(nameof(ClampedDouble)));
        }

        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue(nameof(ClampedDouble), _value);
        }

        public int CompareTo(ClampedDouble other) => _value.CompareTo(other._value);
        public int CompareTo(object? obj) => obj is ClampedDouble other ? CompareTo(other) : 1;
        public bool Equals(ClampedDouble other) => _value == other._value;
        public override bool Equals(object? obj) => obj is ClampedDouble other && Equals(other);
        public override int GetHashCode() => _value.GetHashCode();
        public override string ToString() => _value.ToString();
        public string ToString(IFormatProvider? provider) => _value.ToString(provider);
        public string ToString(string format) => _value.ToString(format);
        public string ToString(string? format, IFormatProvider? formatProvider) => _value.ToString(format, formatProvider);

        public static bool IsNormal(ClampedDouble d) => DoubleShim.IsNormal(d._value);
        public static bool IsSubnormal(ClampedDouble d) => DoubleShim.IsSubnormal(d._value);
        public static bool TryParse(string s, IFormatProvider? provider, out ClampedDouble result) => FuncExtensions.Try(() => Parse(s, provider), out result);
        public static bool TryParse(string s, NumberStyles style, IFormatProvider? provider, out ClampedDouble result) => FuncExtensions.Try(() => Parse(s, style, provider), out result);
        public static bool TryParse(string s, NumberStyles style, out ClampedDouble result) => FuncExtensions.Try(() => Parse(s, style), out result);
        public static bool TryParse(string s, out ClampedDouble result) => FuncExtensions.Try(() => Parse(s), out result);
        public static ClampedDouble Parse(string s) => double.Parse(s);
        public static ClampedDouble Parse(string s, IFormatProvider? provider) => double.Parse(s, provider);
        public static ClampedDouble Parse(string s, NumberStyles style) => double.Parse(s, style);
        public static ClampedDouble Parse(string s, NumberStyles style, IFormatProvider? provider) => double.Parse(s, style, provider);

        [CLSCompliant(false)] public static implicit operator ClampedDouble(sbyte value) => new ClampedDouble(value);
        [CLSCompliant(false)] public static implicit operator ClampedDouble(uint value) => new ClampedDouble(value);
        [CLSCompliant(false)] public static implicit operator ClampedDouble(ulong value) => new ClampedDouble(value);
        [CLSCompliant(false)] public static implicit operator ClampedDouble(ushort value) => new ClampedDouble(value);
        public static explicit operator ClampedDouble(decimal value) => new ClampedDouble(ConvertN.ToDouble(value, Conversion.CastClamp));
        public static implicit operator ClampedDouble(byte value) => new ClampedDouble(value);
        public static implicit operator ClampedDouble(double value) => new ClampedDouble(value);
        public static implicit operator ClampedDouble(float value) => new ClampedDouble(value);
        public static implicit operator ClampedDouble(int value) => new ClampedDouble(value);
        public static implicit operator ClampedDouble(long value) => new ClampedDouble(value);
        public static implicit operator ClampedDouble(short value) => new ClampedDouble(value);

        [CLSCompliant(false)] public static explicit operator sbyte(ClampedDouble value) => ConvertN.ToSByte(value._value, Conversion.CastClamp);
        [CLSCompliant(false)] public static explicit operator uint(ClampedDouble value) => ConvertN.ToUInt32(value._value, Conversion.CastClamp);
        [CLSCompliant(false)] public static explicit operator ulong(ClampedDouble value) => ConvertN.ToUInt64(value._value, Conversion.CastClamp);
        [CLSCompliant(false)] public static explicit operator ushort(ClampedDouble value) => ConvertN.ToUInt16(value._value, Conversion.CastClamp);
        public static explicit operator byte(ClampedDouble value) => ConvertN.ToByte(value._value, Conversion.CastClamp);
        public static explicit operator decimal(ClampedDouble value) => ConvertN.ToDecimal(value._value, Conversion.CastClamp);
        public static explicit operator float(ClampedDouble value) => ConvertN.ToSingle(value._value, Conversion.CastClamp);
        public static explicit operator int(ClampedDouble value) => ConvertN.ToInt32(value._value, Conversion.CastClamp);
        public static explicit operator long(ClampedDouble value) => ConvertN.ToInt64(value._value, Conversion.CastClamp);
        public static explicit operator short(ClampedDouble value) => ConvertN.ToInt16(value._value, Conversion.CastClamp);
        public static implicit operator double(ClampedDouble value) => value._value;

        public static bool operator !=(ClampedDouble left, ClampedDouble right) => left._value != right._value;
        public static bool operator <(ClampedDouble left, ClampedDouble right) => left._value < right._value;
        public static bool operator <=(ClampedDouble left, ClampedDouble right) => left._value <= right._value;
        public static bool operator ==(ClampedDouble left, ClampedDouble right) => left._value == right._value;
        public static bool operator >(ClampedDouble left, ClampedDouble right) => left._value > right._value;
        public static bool operator >=(ClampedDouble left, ClampedDouble right) => left._value >= right._value;
        public static ClampedDouble operator %(ClampedDouble left, ClampedDouble right) => ClampedArithmetic.Remainder(left._value, right._value);
        public static ClampedDouble operator -(ClampedDouble left, ClampedDouble right) => ClampedArithmetic.Subtract(left._value, right._value);
        public static ClampedDouble operator --(ClampedDouble value) => value - 1;
        public static ClampedDouble operator -(ClampedDouble value) => -value._value;
        public static ClampedDouble operator *(ClampedDouble left, ClampedDouble right) => ClampedArithmetic.Multiply(left._value, right._value);
        public static ClampedDouble operator /(ClampedDouble left, ClampedDouble right) => ClampedArithmetic.Divide(left._value, right._value);
        public static ClampedDouble operator +(ClampedDouble left, ClampedDouble right) => ClampedArithmetic.Add(left._value, right._value);
        public static ClampedDouble operator +(ClampedDouble value) => value;
        public static ClampedDouble operator ++(ClampedDouble value) => value + 1;
        public static ClampedDouble operator &(ClampedDouble left, ClampedDouble right) => BitOperations.LogicalAnd(left._value, right._value);
        public static ClampedDouble operator |(ClampedDouble left, ClampedDouble right) => BitOperations.LogicalOr(left._value, right._value);
        public static ClampedDouble operator ^(ClampedDouble left, ClampedDouble right) => BitOperations.LogicalExclusiveOr(left._value, right._value);
        public static ClampedDouble operator ~(ClampedDouble left) => BitOperations.BitwiseComplement(left._value);
        public static ClampedDouble operator >>(ClampedDouble left, int right) => BitOperations.RightShift(left._value, right);
        public static ClampedDouble operator <<(ClampedDouble left, int right) => BitOperations.LeftShift(left._value, right);

        TypeCode IConvertible.GetTypeCode() => _value.GetTypeCode();
        bool IConvertible.ToBoolean(IFormatProvider? provider) => Convert.ToBoolean(_value, provider);
        byte IConvertible.ToByte(IFormatProvider? provider) => ConvertN.ToByte(_value, Conversion.Clamp);
        char IConvertible.ToChar(IFormatProvider? provider) => Convert.ToChar(_value, provider);
        DateTime IConvertible.ToDateTime(IFormatProvider? provider) => Convert.ToDateTime(provider);
        decimal IConvertible.ToDecimal(IFormatProvider? provider) => ConvertN.ToDecimal(_value, Conversion.Clamp);
        double IConvertible.ToDouble(IFormatProvider? provider) => _value;
        float IConvertible.ToSingle(IFormatProvider? provider) => ConvertN.ToSingle(_value, Conversion.Clamp);
        int IConvertible.ToInt32(IFormatProvider? provider) => ConvertN.ToInt32(_value, Conversion.Clamp);
        long IConvertible.ToInt64(IFormatProvider? provider) => ConvertN.ToInt64(_value, Conversion.Clamp);
        sbyte IConvertible.ToSByte(IFormatProvider? provider) => ConvertN.ToSByte(_value, Conversion.Clamp);
        short IConvertible.ToInt16(IFormatProvider? provider) => ConvertN.ToInt16(_value, Conversion.Clamp);
        uint IConvertible.ToUInt32(IFormatProvider? provider) => ConvertN.ToUInt32(_value, Conversion.Clamp);
        ulong IConvertible.ToUInt64(IFormatProvider? provider) => ConvertN.ToUInt64(_value, Conversion.Clamp);
        ushort IConvertible.ToUInt16(IFormatProvider? provider) => ConvertN.ToUInt16(_value, Conversion.Clamp);
        object IConvertible.ToType(Type conversionType, IFormatProvider? provider) => this.ToTypeDefault(conversionType, provider);

        private static double Check(double value)
        {
            if (DoubleShim.IsFinite(value)) return value;
            else if (double.IsPositiveInfinity(value)) return double.MaxValue;
            else if (double.IsNegativeInfinity(value)) return double.MinValue;
            else return 0d;
        }

        bool INumeric<ClampedDouble>.IsGreaterThan(ClampedDouble value) => this > value;
        bool INumeric<ClampedDouble>.IsGreaterThanOrEqualTo(ClampedDouble value) => this >= value;
        bool INumeric<ClampedDouble>.IsLessThan(ClampedDouble value) => this < value;
        bool INumeric<ClampedDouble>.IsLessThanOrEqualTo(ClampedDouble value) => this <= value;
        ClampedDouble INumeric<ClampedDouble>.Add(ClampedDouble value) => this + value;
        ClampedDouble INumeric<ClampedDouble>.BitwiseComplement() => ~this;
        ClampedDouble INumeric<ClampedDouble>.Divide(ClampedDouble value) => this / value;
        ClampedDouble INumeric<ClampedDouble>.LeftShift(int count) => this << count;
        ClampedDouble INumeric<ClampedDouble>.LogicalAnd(ClampedDouble value) => this & value;
        ClampedDouble INumeric<ClampedDouble>.LogicalExclusiveOr(ClampedDouble value) => this ^ value;
        ClampedDouble INumeric<ClampedDouble>.LogicalOr(ClampedDouble value) => this | value;
        ClampedDouble INumeric<ClampedDouble>.Multiply(ClampedDouble value) => this * value;
        ClampedDouble INumeric<ClampedDouble>.Negative() => -this;
        ClampedDouble INumeric<ClampedDouble>.Positive() => +this;
        ClampedDouble INumeric<ClampedDouble>.Remainder(ClampedDouble value) => this % value;
        ClampedDouble INumeric<ClampedDouble>.RightShift(int count) => this >> count;
        ClampedDouble INumeric<ClampedDouble>.Subtract(ClampedDouble value) => this - value;

        INumericBitConverter<ClampedDouble> IProvider<INumericBitConverter<ClampedDouble>>.GetInstance() => Utilities.Instance;
        IBinaryIO<ClampedDouble> IProvider<IBinaryIO<ClampedDouble>>.GetInstance() => Utilities.Instance;
        IConvert<ClampedDouble> IProvider<IConvert<ClampedDouble>>.GetInstance() => Utilities.Instance;
        IConvertExtended<ClampedDouble> IProvider<IConvertExtended<ClampedDouble>>.GetInstance() => Utilities.Instance;
        IMath<ClampedDouble> IProvider<IMath<ClampedDouble>>.GetInstance() => Utilities.Instance;
        INumericRandom<ClampedDouble> IProvider<INumericRandom<ClampedDouble>>.GetInstance() => Utilities.Instance;
        INumericStatic<ClampedDouble> IProvider<INumericStatic<ClampedDouble>>.GetInstance() => Utilities.Instance;
        IVariantRandom<ClampedDouble> IProvider<IVariantRandom<ClampedDouble>>.GetInstance() => Utilities.Instance;

        private sealed class Utilities :
            IBinaryIO<ClampedDouble>,
            IConvert<ClampedDouble>,
            IConvertExtended<ClampedDouble>,
            IMath<ClampedDouble>,
            INumericBitConverter<ClampedDouble>,
            INumericRandom<ClampedDouble>,
            INumericStatic<ClampedDouble>,
            IVariantRandom<ClampedDouble>
        {
            public static readonly Utilities Instance = new Utilities();

            void IBinaryIO<ClampedDouble>.Write(BinaryWriter writer, ClampedDouble value) => writer.Write(value);
            ClampedDouble IBinaryIO<ClampedDouble>.Read(BinaryReader reader) => reader.ReadDouble();

            bool INumericStatic<ClampedDouble>.HasFloatingPoint => true;
            bool INumericStatic<ClampedDouble>.HasInfinity => false;
            bool INumericStatic<ClampedDouble>.HasNaN => false;
            bool INumericStatic<ClampedDouble>.IsFinite(ClampedDouble x) => true;
            bool INumericStatic<ClampedDouble>.IsInfinity(ClampedDouble x) => false;
            bool INumericStatic<ClampedDouble>.IsNaN(ClampedDouble x) => false;
            bool INumericStatic<ClampedDouble>.IsNegative(ClampedDouble x) => x._value < 0;
            bool INumericStatic<ClampedDouble>.IsNegativeInfinity(ClampedDouble x) => false;
            bool INumericStatic<ClampedDouble>.IsNormal(ClampedDouble x) => IsNormal(x);
            bool INumericStatic<ClampedDouble>.IsPositiveInfinity(ClampedDouble x) => false;
            bool INumericStatic<ClampedDouble>.IsReal => true;
            bool INumericStatic<ClampedDouble>.IsSigned => true;
            bool INumericStatic<ClampedDouble>.IsSubnormal(ClampedDouble x) => IsSubnormal(x);
            ClampedDouble INumericStatic<ClampedDouble>.Epsilon => Epsilon;
            ClampedDouble INumericStatic<ClampedDouble>.MaxUnit => 1d;
            ClampedDouble INumericStatic<ClampedDouble>.MaxValue => MaxValue;
            ClampedDouble INumericStatic<ClampedDouble>.MinUnit => -1d;
            ClampedDouble INumericStatic<ClampedDouble>.MinValue => MinValue;
            ClampedDouble INumericStatic<ClampedDouble>.One => 1d;
            ClampedDouble INumericStatic<ClampedDouble>.Zero => 0d;

            ClampedDouble IMath<ClampedDouble>.Abs(ClampedDouble value) => Math.Abs(value._value);
            ClampedDouble IMath<ClampedDouble>.Acos(ClampedDouble x) => Math.Acos(x._value);
            ClampedDouble IMath<ClampedDouble>.Acosh(ClampedDouble x) => MathShim.Acosh(x._value);
            ClampedDouble IMath<ClampedDouble>.Asin(ClampedDouble x) => Math.Asin(x._value);
            ClampedDouble IMath<ClampedDouble>.Asinh(ClampedDouble x) => MathShim.Asinh(x._value);
            ClampedDouble IMath<ClampedDouble>.Atan(ClampedDouble x) => Math.Atan(x._value);
            ClampedDouble IMath<ClampedDouble>.Atan2(ClampedDouble x, ClampedDouble y) => Math.Atan2(x._value, y._value);
            ClampedDouble IMath<ClampedDouble>.Atanh(ClampedDouble x) => MathShim.Atanh(x._value);
            ClampedDouble IMath<ClampedDouble>.Cbrt(ClampedDouble x) => MathShim.Cbrt(x._value);
            ClampedDouble IMath<ClampedDouble>.Ceiling(ClampedDouble x) => Math.Ceiling(x._value);
            ClampedDouble IMath<ClampedDouble>.Clamp(ClampedDouble x, ClampedDouble bound1, ClampedDouble bound2) => bound1 > bound2 ? Math.Min(bound1._value, Math.Max(bound2._value, x._value)) : Math.Min(bound2._value, Math.Max(bound1._value, x._value));
            ClampedDouble IMath<ClampedDouble>.Cos(ClampedDouble x) => Math.Cos(x._value);
            ClampedDouble IMath<ClampedDouble>.Cosh(ClampedDouble x) => Math.Cosh(x._value);
            ClampedDouble IMath<ClampedDouble>.E { get; } = Math.E;
            ClampedDouble IMath<ClampedDouble>.Exp(ClampedDouble x) => Math.Exp(x._value);
            ClampedDouble IMath<ClampedDouble>.Floor(ClampedDouble x) => Math.Floor(x._value);
            ClampedDouble IMath<ClampedDouble>.IEEERemainder(ClampedDouble x, ClampedDouble y) => Math.IEEERemainder(x._value, y._value);
            ClampedDouble IMath<ClampedDouble>.Log(ClampedDouble x) => Math.Log(x._value);
            ClampedDouble IMath<ClampedDouble>.Log(ClampedDouble x, ClampedDouble y) => Math.Log(x._value, y._value);
            ClampedDouble IMath<ClampedDouble>.Log10(ClampedDouble x) => Math.Log10(x._value);
            ClampedDouble IMath<ClampedDouble>.Max(ClampedDouble x, ClampedDouble y) => Math.Max(x._value, y._value);
            ClampedDouble IMath<ClampedDouble>.Min(ClampedDouble x, ClampedDouble y) => Math.Min(x._value, y._value);
            ClampedDouble IMath<ClampedDouble>.PI { get; } = Math.PI;
            ClampedDouble IMath<ClampedDouble>.Pow(ClampedDouble x, ClampedDouble y) => Math.Pow(x._value, y._value);
            ClampedDouble IMath<ClampedDouble>.Round(ClampedDouble x) => Math.Round(x._value);
            ClampedDouble IMath<ClampedDouble>.Round(ClampedDouble x, int digits) => Math.Round(x._value, digits);
            ClampedDouble IMath<ClampedDouble>.Round(ClampedDouble x, int digits, MidpointRounding mode) => Math.Round(x._value, digits, mode);
            ClampedDouble IMath<ClampedDouble>.Round(ClampedDouble x, MidpointRounding mode) => Math.Round(x._value, mode);
            ClampedDouble IMath<ClampedDouble>.Sin(ClampedDouble x) => Math.Sin(x._value);
            ClampedDouble IMath<ClampedDouble>.Sinh(ClampedDouble x) => Math.Sinh(x._value);
            ClampedDouble IMath<ClampedDouble>.Sqrt(ClampedDouble x) => Math.Sqrt(x._value);
            ClampedDouble IMath<ClampedDouble>.Tan(ClampedDouble x) => Math.Tan(x._value);
            ClampedDouble IMath<ClampedDouble>.Tanh(ClampedDouble x) => Math.Tanh(x._value);
            ClampedDouble IMath<ClampedDouble>.Tau { get; } = Math.PI * 2d;
            ClampedDouble IMath<ClampedDouble>.Truncate(ClampedDouble x) => Math.Truncate(x._value);
            int IMath<ClampedDouble>.Sign(ClampedDouble x) => Math.Sign(x._value);

            int INumericBitConverter<ClampedDouble>.ConvertedSize => sizeof(double);
            ClampedDouble INumericBitConverter<ClampedDouble>.ToNumeric(byte[] value, int startIndex) => BitConverter.ToDouble(value, startIndex);
            byte[] INumericBitConverter<ClampedDouble>.GetBytes(ClampedDouble value) => BitConverter.GetBytes(value._value);
#if HAS_SPANS
            ClampedDouble INumericBitConverter<ClampedDouble>.ToNumeric(ReadOnlySpan<byte> value) => BitConverter.ToDouble(value);
            bool INumericBitConverter<ClampedDouble>.TryWriteBytes(Span<byte> destination, ClampedDouble value) => BitConverter.TryWriteBytes(destination, value);
#endif

            bool IConvert<ClampedDouble>.ToBoolean(ClampedDouble value) => value._value != 0;
            byte IConvert<ClampedDouble>.ToByte(ClampedDouble value, Conversion mode) => ConvertN.ToByte(value._value, mode.Clamped());
            decimal IConvert<ClampedDouble>.ToDecimal(ClampedDouble value, Conversion mode) => ConvertN.ToDecimal(value._value, mode.Clamped());
            double IConvert<ClampedDouble>.ToDouble(ClampedDouble value, Conversion mode) => value._value;
            float IConvert<ClampedDouble>.ToSingle(ClampedDouble value, Conversion mode) => ConvertN.ToSingle(value._value, mode.Clamped());
            int IConvert<ClampedDouble>.ToInt32(ClampedDouble value, Conversion mode) => ConvertN.ToInt32(value._value, mode.Clamped());
            long IConvert<ClampedDouble>.ToInt64(ClampedDouble value, Conversion mode) => ConvertN.ToInt64(value._value, mode.Clamped());
            sbyte IConvertExtended<ClampedDouble>.ToSByte(ClampedDouble value, Conversion mode) => ConvertN.ToSByte(value._value, mode.Clamped());
            short IConvert<ClampedDouble>.ToInt16(ClampedDouble value, Conversion mode) => ConvertN.ToInt16(value._value, mode.Clamped());
            string IConvert<ClampedDouble>.ToString(ClampedDouble value) => Convert.ToString(value._value);
            uint IConvertExtended<ClampedDouble>.ToUInt32(ClampedDouble value, Conversion mode) => ConvertN.ToUInt32(value._value, mode.Clamped());
            ulong IConvertExtended<ClampedDouble>.ToUInt64(ClampedDouble value, Conversion mode) => ConvertN.ToUInt64(value._value, mode.Clamped());
            ushort IConvertExtended<ClampedDouble>.ToUInt16(ClampedDouble value, Conversion mode) => ConvertN.ToUInt16(value._value, mode.Clamped());

            ClampedDouble IConvert<ClampedDouble>.ToNumeric(bool value) => value ? 1d : 0d;
            ClampedDouble IConvert<ClampedDouble>.ToNumeric(byte value, Conversion mode) => ConvertN.ToDouble(value, mode.Clamped());
            ClampedDouble IConvert<ClampedDouble>.ToNumeric(decimal value, Conversion mode) => ConvertN.ToDouble(value, mode.Clamped());
            ClampedDouble IConvert<ClampedDouble>.ToNumeric(double value, Conversion mode) => value;
            ClampedDouble IConvert<ClampedDouble>.ToNumeric(float value, Conversion mode) => ConvertN.ToDouble(value, mode.Clamped());
            ClampedDouble IConvert<ClampedDouble>.ToNumeric(int value, Conversion mode) => ConvertN.ToDouble(value, mode.Clamped());
            ClampedDouble IConvert<ClampedDouble>.ToNumeric(long value, Conversion mode) => ConvertN.ToDouble(value, mode.Clamped());
            ClampedDouble IConvertExtended<ClampedDouble>.ToValue(sbyte value, Conversion mode) => ConvertN.ToDouble(value, mode.Clamped());
            ClampedDouble IConvert<ClampedDouble>.ToNumeric(short value, Conversion mode) => ConvertN.ToDouble(value, mode.Clamped());
            ClampedDouble IConvert<ClampedDouble>.ToNumeric(string value) => Convert.ToDouble(value);
            ClampedDouble IConvertExtended<ClampedDouble>.ToNumeric(uint value, Conversion mode) => ConvertN.ToDouble(value, mode.Clamped());
            ClampedDouble IConvertExtended<ClampedDouble>.ToNumeric(ulong value, Conversion mode) => ConvertN.ToDouble(value, mode.Clamped());
            ClampedDouble IConvertExtended<ClampedDouble>.ToNumeric(ushort value, Conversion mode) => ConvertN.ToDouble(value, mode.Clamped());

            ClampedDouble INumericStatic<ClampedDouble>.Parse(string s, NumberStyles? style, IFormatProvider? provider)
                => Parse(s, style ?? NumberStyles.Float | NumberStyles.AllowThousands, provider);

            ClampedDouble INumericRandom<ClampedDouble>.Generate(Random random) => random.NextDouble();
            ClampedDouble INumericRandom<ClampedDouble>.Generate(Random random, ClampedDouble maxValue) => random.NextDouble(maxValue);
            ClampedDouble INumericRandom<ClampedDouble>.Generate(Random random, ClampedDouble minValue, ClampedDouble maxValue) => random.NextDouble(minValue, maxValue);
            ClampedDouble INumericRandom<ClampedDouble>.Generate(Random random, Generation mode) => random.NextDouble(mode);
            ClampedDouble INumericRandom<ClampedDouble>.Generate(Random random, ClampedDouble minValue, ClampedDouble maxValue, Generation mode) => random.NextDouble(minValue, maxValue, mode);

            ClampedDouble IVariantRandom<ClampedDouble>.Generate(Random random, Variants variants) => random.NextDouble(variants);
        }
    }
}
