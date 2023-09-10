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
    /// Represents a single-precision floating-point number that cannot overflow.
    /// </summary>
    [Serializable]
    [DebuggerDisplay("{ToString(),nq}")]
    public readonly struct ClampedSingle : INumericExtended<ClampedSingle>
    {
        public static readonly ClampedSingle Epsilon = new ClampedSingle(float.Epsilon);
        public static readonly ClampedSingle MaxValue = new ClampedSingle(float.MaxValue);
        public static readonly ClampedSingle MinValue = new ClampedSingle(float.MinValue);

        private readonly float _value;

        public ClampedSingle(float value)
        {
            _value = Check(value);
        }

        private ClampedSingle(SerializationInfo info, StreamingContext context)
        {
            _value = Check(info.GetSingle(nameof(ClampedSingle)));
        }

        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue(nameof(ClampedSingle), _value);
        }

        public int CompareTo(ClampedSingle other) => _value.CompareTo(other._value);
        public int CompareTo(object? obj) => obj is ClampedSingle other ? CompareTo(other) : 1;
        public bool Equals(ClampedSingle other) => _value == other._value;
        public override bool Equals(object? obj) => obj is ClampedSingle other && Equals(other);
        public override int GetHashCode() => _value.GetHashCode();
        public override string ToString() => _value.ToString();
        public string ToString(IFormatProvider? provider) => _value.ToString(provider);
        public string ToString(string format) => _value.ToString(format);
        public string ToString(string? format, IFormatProvider? formatProvider) => _value.ToString(format, formatProvider);

        public static bool IsNormal(ClampedSingle d) => SingleShim.IsNormal(d._value);
        public static bool IsSubnormal(ClampedSingle d) => SingleShim.IsSubnormal(d._value);
        public static bool TryParse(string s, IFormatProvider? provider, out ClampedSingle result) => FuncExtensions.Try(() => Parse(s, provider), out result);
        public static bool TryParse(string s, NumberStyles style, IFormatProvider? provider, out ClampedSingle result) => FuncExtensions.Try(() => Parse(s, style, provider), out result);
        public static bool TryParse(string s, NumberStyles style, out ClampedSingle result) => FuncExtensions.Try(() => Parse(s, style), out result);
        public static bool TryParse(string s, out ClampedSingle result) => FuncExtensions.Try(() => Parse(s), out result);
        public static ClampedSingle Parse(string s) => float.Parse(s);
        public static ClampedSingle Parse(string s, IFormatProvider? provider) => float.Parse(s, provider);
        public static ClampedSingle Parse(string s, NumberStyles style) => float.Parse(s, style);
        public static ClampedSingle Parse(string s, NumberStyles style, IFormatProvider? provider) => float.Parse(s, style, provider);

        [CLSCompliant(false)] public static implicit operator ClampedSingle(sbyte value) => new ClampedSingle(value);
        [CLSCompliant(false)] public static implicit operator ClampedSingle(uint value) => new ClampedSingle(value);
        [CLSCompliant(false)] public static implicit operator ClampedSingle(ulong value) => new ClampedSingle(value);
        [CLSCompliant(false)] public static implicit operator ClampedSingle(ushort value) => new ClampedSingle(value);
        public static explicit operator ClampedSingle(decimal value) => new ClampedSingle(ConvertN.ToSingle(value, Conversion.CastClamp));
        public static explicit operator ClampedSingle(double value) => new ClampedSingle(ConvertN.ToSingle(value, Conversion.CastClamp));
        public static implicit operator ClampedSingle(byte value) => new ClampedSingle(value);
        public static implicit operator ClampedSingle(float value) => new ClampedSingle(value);
        public static implicit operator ClampedSingle(int value) => new ClampedSingle(value);
        public static implicit operator ClampedSingle(long value) => new ClampedSingle(value);
        public static implicit operator ClampedSingle(short value) => new ClampedSingle(value);

        [CLSCompliant(false)] public static explicit operator sbyte(ClampedSingle value) => ConvertN.ToSByte(value._value, Conversion.CastClamp);
        [CLSCompliant(false)] public static explicit operator uint(ClampedSingle value) => ConvertN.ToUInt32(value._value, Conversion.CastClamp);
        [CLSCompliant(false)] public static explicit operator ulong(ClampedSingle value) => ConvertN.ToUInt64(value._value, Conversion.CastClamp);
        [CLSCompliant(false)] public static explicit operator ushort(ClampedSingle value) => ConvertN.ToUInt16(value._value, Conversion.CastClamp);
        public static explicit operator byte(ClampedSingle value) => ConvertN.ToByte(value._value, Conversion.CastClamp);
        public static explicit operator decimal(ClampedSingle value) => ConvertN.ToDecimal(value._value, Conversion.CastClamp);
        public static explicit operator int(ClampedSingle value) => ConvertN.ToInt32(value._value, Conversion.CastClamp);
        public static explicit operator long(ClampedSingle value) => ConvertN.ToInt64(value._value, Conversion.CastClamp);
        public static explicit operator short(ClampedSingle value) => ConvertN.ToInt16(value._value, Conversion.CastClamp);
        public static implicit operator double(ClampedSingle value) => value._value;
        public static implicit operator float(ClampedSingle value) => value._value;

        public static bool operator !=(ClampedSingle left, ClampedSingle right) => left._value != right._value;
        public static bool operator <(ClampedSingle left, ClampedSingle right) => left._value < right._value;
        public static bool operator <=(ClampedSingle left, ClampedSingle right) => left._value <= right._value;
        public static bool operator ==(ClampedSingle left, ClampedSingle right) => left._value == right._value;
        public static bool operator >(ClampedSingle left, ClampedSingle right) => left._value > right._value;
        public static bool operator >=(ClampedSingle left, ClampedSingle right) => left._value >= right._value;
        public static ClampedSingle operator %(ClampedSingle left, ClampedSingle right) => ClampedArithmetic.Remainder(left._value, right._value);
        public static ClampedSingle operator &(ClampedSingle left, ClampedSingle right) => BitOperations.LogicalAnd(left._value, right._value);
        public static ClampedSingle operator -(ClampedSingle left, ClampedSingle right) => ClampedArithmetic.Subtract(left._value, right._value);
        public static ClampedSingle operator --(ClampedSingle value) => value - 1;
        public static ClampedSingle operator -(ClampedSingle value) => -value._value;
        public static ClampedSingle operator *(ClampedSingle left, ClampedSingle right) => ClampedArithmetic.Multiply(left._value, right._value);
        public static ClampedSingle operator /(ClampedSingle left, ClampedSingle right) => ClampedArithmetic.Divide(left._value, right._value);
        public static ClampedSingle operator ^(ClampedSingle left, ClampedSingle right) => BitOperations.LogicalExclusiveOr(left._value, right._value);
        public static ClampedSingle operator |(ClampedSingle left, ClampedSingle right) => BitOperations.LogicalOr(left._value, right._value);
        public static ClampedSingle operator ~(ClampedSingle left) => BitOperations.BitwiseComplement(left._value);
        public static ClampedSingle operator +(ClampedSingle left, ClampedSingle right) => ClampedArithmetic.Add(left._value, right._value);
        public static ClampedSingle operator +(ClampedSingle value) => value;
        public static ClampedSingle operator ++(ClampedSingle value) => value + 1;
        public static ClampedSingle operator <<(ClampedSingle left, int right) => BitOperations.LeftShift(left._value, right);
        public static ClampedSingle operator >>(ClampedSingle left, int right) => BitOperations.RightShift(left._value, right);

        TypeCode IConvertible.GetTypeCode() => _value.GetTypeCode();
        bool IConvertible.ToBoolean(IFormatProvider? provider) => Convert.ToBoolean(_value, provider);
        byte IConvertible.ToByte(IFormatProvider? provider) => ConvertN.ToByte(_value, Conversion.Clamp);
        char IConvertible.ToChar(IFormatProvider? provider) => Convert.ToChar(_value, provider);
        DateTime IConvertible.ToDateTime(IFormatProvider? provider) => Convert.ToDateTime(provider);
        decimal IConvertible.ToDecimal(IFormatProvider? provider) => ConvertN.ToDecimal(_value, Conversion.Clamp);
        double IConvertible.ToDouble(IFormatProvider? provider) => ConvertN.ToDouble(_value, Conversion.Clamp);
        float IConvertible.ToSingle(IFormatProvider? provider) => _value;
        int IConvertible.ToInt32(IFormatProvider? provider) => ConvertN.ToInt32(_value, Conversion.Clamp);
        long IConvertible.ToInt64(IFormatProvider? provider) => ConvertN.ToInt64(_value, Conversion.Clamp);
        sbyte IConvertible.ToSByte(IFormatProvider? provider) => ConvertN.ToSByte(_value, Conversion.Clamp);
        short IConvertible.ToInt16(IFormatProvider? provider) => ConvertN.ToInt16(_value, Conversion.Clamp);
        uint IConvertible.ToUInt32(IFormatProvider? provider) => ConvertN.ToUInt32(_value, Conversion.Clamp);
        ulong IConvertible.ToUInt64(IFormatProvider? provider) => ConvertN.ToUInt64(_value, Conversion.Clamp);
        ushort IConvertible.ToUInt16(IFormatProvider? provider) => ConvertN.ToUInt16(_value, Conversion.Clamp);
        object IConvertible.ToType(Type conversionType, IFormatProvider? provider) => this.ToTypeDefault(conversionType, provider);

        private static float Check(float value)
        {
            if (SingleShim.IsFinite(value)) return value;
            else if (float.IsPositiveInfinity(value)) return float.MaxValue;
            else if (float.IsNegativeInfinity(value)) return float.MinValue;
            else return 0f;
        }

        bool INumeric<ClampedSingle>.IsGreaterThan(ClampedSingle value) => this > value;
        bool INumeric<ClampedSingle>.IsGreaterThanOrEqualTo(ClampedSingle value) => this >= value;
        bool INumeric<ClampedSingle>.IsLessThan(ClampedSingle value) => this < value;
        bool INumeric<ClampedSingle>.IsLessThanOrEqualTo(ClampedSingle value) => this <= value;
        ClampedSingle INumeric<ClampedSingle>.Add(ClampedSingle value) => this + value;
        ClampedSingle INumeric<ClampedSingle>.BitwiseComplement() => ~this;
        ClampedSingle INumeric<ClampedSingle>.Divide(ClampedSingle value) => this / value;
        ClampedSingle INumeric<ClampedSingle>.LeftShift(int count) => this << count;
        ClampedSingle INumeric<ClampedSingle>.LogicalAnd(ClampedSingle value) => this & value;
        ClampedSingle INumeric<ClampedSingle>.LogicalExclusiveOr(ClampedSingle value) => this ^ value;
        ClampedSingle INumeric<ClampedSingle>.LogicalOr(ClampedSingle value) => this | value;
        ClampedSingle INumeric<ClampedSingle>.Multiply(ClampedSingle value) => this * value;
        ClampedSingle INumeric<ClampedSingle>.Negative() => -this;
        ClampedSingle INumeric<ClampedSingle>.Positive() => +this;
        ClampedSingle INumeric<ClampedSingle>.Remainder(ClampedSingle value) => this % value;
        ClampedSingle INumeric<ClampedSingle>.RightShift(int count) => this >> count;
        ClampedSingle INumeric<ClampedSingle>.Subtract(ClampedSingle value) => this - value;

        INumericBitConverter<ClampedSingle> IProvider<INumericBitConverter<ClampedSingle>>.GetInstance() => Utilities.Instance;
        IBinaryIO<ClampedSingle> IProvider<IBinaryIO<ClampedSingle>>.GetInstance() => Utilities.Instance;
        IConvert<ClampedSingle> IProvider<IConvert<ClampedSingle>>.GetInstance() => Utilities.Instance;
        IConvertExtended<ClampedSingle> IProvider<IConvertExtended<ClampedSingle>>.GetInstance() => Utilities.Instance;
        IMath<ClampedSingle> IProvider<IMath<ClampedSingle>>.GetInstance() => Utilities.Instance;
        INumericRandom<ClampedSingle> IProvider<INumericRandom<ClampedSingle>>.GetInstance() => Utilities.Instance;
        INumericStatic<ClampedSingle> IProvider<INumericStatic<ClampedSingle>>.GetInstance() => Utilities.Instance;
        IVariantRandom<ClampedSingle> IProvider<IVariantRandom<ClampedSingle>>.GetInstance() => Utilities.Instance;

        private sealed class Utilities :
            IBinaryIO<ClampedSingle>,
            IConvert<ClampedSingle>,
            IConvertExtended<ClampedSingle>,
            IMath<ClampedSingle>,
            INumericBitConverter<ClampedSingle>,
            INumericRandom<ClampedSingle>,
            INumericStatic<ClampedSingle>,
            IVariantRandom<ClampedSingle>
        {
            public static readonly Utilities Instance = new Utilities();

            void IBinaryIO<ClampedSingle>.Write(BinaryWriter writer, ClampedSingle value) => writer.Write(value);
            ClampedSingle IBinaryIO<ClampedSingle>.Read(BinaryReader reader) => reader.ReadSingle();

            bool INumericStatic<ClampedSingle>.HasFloatingPoint => true;
            bool INumericStatic<ClampedSingle>.HasInfinity => false;
            bool INumericStatic<ClampedSingle>.HasNaN => false;
            bool INumericStatic<ClampedSingle>.IsFinite(ClampedSingle x) => true;
            bool INumericStatic<ClampedSingle>.IsInfinity(ClampedSingle x) => false;
            bool INumericStatic<ClampedSingle>.IsNaN(ClampedSingle x) => false;
            bool INumericStatic<ClampedSingle>.IsNegative(ClampedSingle x) => x._value < 0;
            bool INumericStatic<ClampedSingle>.IsNegativeInfinity(ClampedSingle x) => false;
            bool INumericStatic<ClampedSingle>.IsNormal(ClampedSingle x) => IsNormal(x);
            bool INumericStatic<ClampedSingle>.IsPositiveInfinity(ClampedSingle x) => false;
            bool INumericStatic<ClampedSingle>.IsReal => true;
            bool INumericStatic<ClampedSingle>.IsSigned => true;
            bool INumericStatic<ClampedSingle>.IsSubnormal(ClampedSingle x) => IsSubnormal(x);
            ClampedSingle INumericStatic<ClampedSingle>.Epsilon => Epsilon;
            ClampedSingle INumericStatic<ClampedSingle>.MaxUnit => 1;
            ClampedSingle INumericStatic<ClampedSingle>.MaxValue => MaxValue;
            ClampedSingle INumericStatic<ClampedSingle>.MinUnit => -1;
            ClampedSingle INumericStatic<ClampedSingle>.MinValue => MinValue;
            ClampedSingle INumericStatic<ClampedSingle>.One => 1;
            ClampedSingle INumericStatic<ClampedSingle>.Zero => 0;

            ClampedSingle IMath<ClampedSingle>.Abs(ClampedSingle value) => MathFShim.Abs(value._value);
            ClampedSingle IMath<ClampedSingle>.Acos(ClampedSingle x) => MathFShim.Acos(x._value);
            ClampedSingle IMath<ClampedSingle>.Acosh(ClampedSingle x) => MathFShim.Acosh(x._value);
            ClampedSingle IMath<ClampedSingle>.Asin(ClampedSingle x) => MathFShim.Asin(x._value);
            ClampedSingle IMath<ClampedSingle>.Asinh(ClampedSingle x) => MathFShim.Asinh(x._value);
            ClampedSingle IMath<ClampedSingle>.Atan(ClampedSingle x) => MathFShim.Atan(x._value);
            ClampedSingle IMath<ClampedSingle>.Atan2(ClampedSingle x, ClampedSingle y) => MathFShim.Atan2(x._value, y._value);
            ClampedSingle IMath<ClampedSingle>.Atanh(ClampedSingle x) => MathFShim.Atanh(x._value);
            ClampedSingle IMath<ClampedSingle>.Cbrt(ClampedSingle x) => MathFShim.Cbrt(x._value);
            ClampedSingle IMath<ClampedSingle>.Ceiling(ClampedSingle x) => MathFShim.Ceiling(x._value);
            ClampedSingle IMath<ClampedSingle>.Clamp(ClampedSingle x, ClampedSingle bound1, ClampedSingle bound2) => bound1 > bound2 ? MathFShim.Min(bound1._value, MathFShim.Max(bound2._value, x._value)) : MathFShim.Min(bound2._value, MathFShim.Max(bound1._value, x._value));
            ClampedSingle IMath<ClampedSingle>.Cos(ClampedSingle x) => MathFShim.Cos(x._value);
            ClampedSingle IMath<ClampedSingle>.Cosh(ClampedSingle x) => MathFShim.Cosh(x._value);
            ClampedSingle IMath<ClampedSingle>.E { get; } = MathFShim.E;
            ClampedSingle IMath<ClampedSingle>.Exp(ClampedSingle x) => MathFShim.Exp(x._value);
            ClampedSingle IMath<ClampedSingle>.Floor(ClampedSingle x) => MathFShim.Floor(x._value);
            ClampedSingle IMath<ClampedSingle>.IEEERemainder(ClampedSingle x, ClampedSingle y) => MathFShim.IEEERemainder(x._value, y._value);
            ClampedSingle IMath<ClampedSingle>.Log(ClampedSingle x) => MathFShim.Log(x._value);
            ClampedSingle IMath<ClampedSingle>.Log(ClampedSingle x, ClampedSingle y) => MathFShim.Log(x._value, y._value);
            ClampedSingle IMath<ClampedSingle>.Log10(ClampedSingle x) => MathFShim.Log10(x._value);
            ClampedSingle IMath<ClampedSingle>.Max(ClampedSingle x, ClampedSingle y) => MathFShim.Max(x._value, y._value);
            ClampedSingle IMath<ClampedSingle>.Min(ClampedSingle x, ClampedSingle y) => MathFShim.Min(x._value, y._value);
            ClampedSingle IMath<ClampedSingle>.PI { get; } = MathFShim.PI;
            ClampedSingle IMath<ClampedSingle>.Pow(ClampedSingle x, ClampedSingle y) => MathFShim.Pow(x._value, y._value);
            ClampedSingle IMath<ClampedSingle>.Round(ClampedSingle x) => MathFShim.Round(x._value);
            ClampedSingle IMath<ClampedSingle>.Round(ClampedSingle x, int digits) => MathFShim.Round(x._value, digits);
            ClampedSingle IMath<ClampedSingle>.Round(ClampedSingle x, int digits, MidpointRounding mode) => MathFShim.Round(x._value, digits, mode);
            ClampedSingle IMath<ClampedSingle>.Round(ClampedSingle x, MidpointRounding mode) => MathFShim.Round(x._value, mode);
            ClampedSingle IMath<ClampedSingle>.Sin(ClampedSingle x) => MathFShim.Sin(x._value);
            ClampedSingle IMath<ClampedSingle>.Sinh(ClampedSingle x) => MathFShim.Sinh(x._value);
            ClampedSingle IMath<ClampedSingle>.Sqrt(ClampedSingle x) => MathFShim.Sqrt(x._value);
            ClampedSingle IMath<ClampedSingle>.Tan(ClampedSingle x) => MathFShim.Tan(x._value);
            ClampedSingle IMath<ClampedSingle>.Tanh(ClampedSingle x) => MathFShim.Tanh(x._value);
            ClampedSingle IMath<ClampedSingle>.Tau { get; } = MathFShim.PI * 2f;
            ClampedSingle IMath<ClampedSingle>.Truncate(ClampedSingle x) => MathFShim.Truncate(x._value);
            int IMath<ClampedSingle>.Sign(ClampedSingle x) => Math.Sign(x._value);

            int INumericBitConverter<ClampedSingle>.ConvertedSize => sizeof(float);
            ClampedSingle INumericBitConverter<ClampedSingle>.ToNumeric(byte[] value, int startIndex) => BitConverter.ToSingle(value, startIndex);
            byte[] INumericBitConverter<ClampedSingle>.GetBytes(ClampedSingle value) => BitConverter.GetBytes(value._value);
#if HAS_SPANS
            ClampedSingle INumericBitConverter<ClampedSingle>.ToNumeric(ReadOnlySpan<byte> value) => BitConverter.ToSingle(value);
            bool INumericBitConverter<ClampedSingle>.TryWriteBytes(Span<byte> destination, ClampedSingle value) => BitConverter.TryWriteBytes(destination, value);
#endif

            bool IConvert<ClampedSingle>.ToBoolean(ClampedSingle value) => value._value != 0;
            byte IConvert<ClampedSingle>.ToByte(ClampedSingle value, Conversion mode) => ConvertN.ToByte(value._value, mode.Clamped());
            decimal IConvert<ClampedSingle>.ToDecimal(ClampedSingle value, Conversion mode) => ConvertN.ToDecimal(value._value, mode.Clamped());
            double IConvert<ClampedSingle>.ToDouble(ClampedSingle value, Conversion mode) => ConvertN.ToDouble(value._value, mode.Clamped());
            float IConvert<ClampedSingle>.ToSingle(ClampedSingle value, Conversion mode) => value._value;
            int IConvert<ClampedSingle>.ToInt32(ClampedSingle value, Conversion mode) => ConvertN.ToInt32(value._value, mode.Clamped());
            long IConvert<ClampedSingle>.ToInt64(ClampedSingle value, Conversion mode) => ConvertN.ToInt64(value._value, mode.Clamped());
            sbyte IConvertExtended<ClampedSingle>.ToSByte(ClampedSingle value, Conversion mode) => ConvertN.ToSByte(value._value, mode.Clamped());
            short IConvert<ClampedSingle>.ToInt16(ClampedSingle value, Conversion mode) => ConvertN.ToInt16(value._value, mode.Clamped());
            string IConvert<ClampedSingle>.ToString(ClampedSingle value) => Convert.ToString(value._value);
            uint IConvertExtended<ClampedSingle>.ToUInt32(ClampedSingle value, Conversion mode) => ConvertN.ToUInt32(value._value, mode.Clamped());
            ulong IConvertExtended<ClampedSingle>.ToUInt64(ClampedSingle value, Conversion mode) => ConvertN.ToUInt64(value._value, mode.Clamped());
            ushort IConvertExtended<ClampedSingle>.ToUInt16(ClampedSingle value, Conversion mode) => ConvertN.ToUInt16(value._value, mode.Clamped());

            ClampedSingle IConvert<ClampedSingle>.ToNumeric(bool value) => value ? 1f : 0f;
            ClampedSingle IConvert<ClampedSingle>.ToNumeric(byte value, Conversion mode) => ConvertN.ToSingle(value, mode.Clamped());
            ClampedSingle IConvert<ClampedSingle>.ToNumeric(decimal value, Conversion mode) => ConvertN.ToSingle(value, mode.Clamped());
            ClampedSingle IConvert<ClampedSingle>.ToNumeric(double value, Conversion mode) => ConvertN.ToSingle(value, mode.Clamped());
            ClampedSingle IConvert<ClampedSingle>.ToNumeric(float value, Conversion mode) => value;
            ClampedSingle IConvert<ClampedSingle>.ToNumeric(int value, Conversion mode) => ConvertN.ToSingle(value, mode.Clamped());
            ClampedSingle IConvert<ClampedSingle>.ToNumeric(long value, Conversion mode) => ConvertN.ToSingle(value, mode.Clamped());
            ClampedSingle IConvertExtended<ClampedSingle>.ToValue(sbyte value, Conversion mode) => ConvertN.ToSingle(value, mode.Clamped());
            ClampedSingle IConvert<ClampedSingle>.ToNumeric(short value, Conversion mode) => ConvertN.ToSingle(value, mode.Clamped());
            ClampedSingle IConvert<ClampedSingle>.ToNumeric(string value) => Convert.ToSingle(value);
            ClampedSingle IConvertExtended<ClampedSingle>.ToNumeric(uint value, Conversion mode) => ConvertN.ToSingle(value, mode.Clamped());
            ClampedSingle IConvertExtended<ClampedSingle>.ToNumeric(ulong value, Conversion mode) => ConvertN.ToSingle(value, mode.Clamped());
            ClampedSingle IConvertExtended<ClampedSingle>.ToNumeric(ushort value, Conversion mode) => ConvertN.ToSingle(value, mode.Clamped());

            ClampedSingle INumericStatic<ClampedSingle>.Parse(string s, NumberStyles? style, IFormatProvider? provider)
                => Parse(s, style ?? NumberStyles.Float | NumberStyles.AllowThousands, provider);

            ClampedSingle INumericRandom<ClampedSingle>.Generate(Random random) => random.NextSingle();
            ClampedSingle INumericRandom<ClampedSingle>.Generate(Random random, ClampedSingle maxValue) => random.NextSingle(maxValue);
            ClampedSingle INumericRandom<ClampedSingle>.Generate(Random random, ClampedSingle minValue, ClampedSingle maxValue) => random.NextSingle(minValue, maxValue);
            ClampedSingle INumericRandom<ClampedSingle>.Generate(Random random, Generation mode) => random.NextSingle(mode);
            ClampedSingle INumericRandom<ClampedSingle>.Generate(Random random, ClampedSingle minValue, ClampedSingle maxValue, Generation mode) => random.NextSingle(minValue, maxValue, mode);

            ClampedSingle IVariantRandom<ClampedSingle>.Generate(Random random, Variants variants) => random.NextSingle(variants);
        }
    }
}
