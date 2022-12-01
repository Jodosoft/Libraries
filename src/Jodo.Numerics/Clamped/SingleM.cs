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
using System.IO;
using System.Runtime.Serialization;
using Jodo.Primitives;
using Jodo.Primitives.Compatibility;

namespace Jodo.Numerics.Clamped
{
    /// <summary>
    /// Represents a single-precision floating-point number that cannot overflow.
    /// </summary>
    [Serializable]
    [DebuggerDisplay("{ToString(),nq}")]
    public readonly struct SingleM : INumericExtended<SingleM>
    {
        public static readonly SingleM Epsilon = new SingleM(float.Epsilon);
        public static readonly SingleM MaxValue = new SingleM(float.MaxValue);
        public static readonly SingleM MinValue = new SingleM(float.MinValue);

        private readonly float _value;

        public SingleM(float value)
        {
            _value = Check(value);
        }

        private SingleM(SerializationInfo info, StreamingContext context)
        {
            _value = Check(info.GetSingle(nameof(SingleM)));
        }

        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue(nameof(SingleM), _value);
        }

        public int CompareTo(SingleM other) => _value.CompareTo(other._value);
        public int CompareTo(object? obj) => obj is SingleM other ? CompareTo(other) : 1;
        public bool Equals(SingleM other) => _value == other._value;
        public override bool Equals(object? obj) => obj is SingleM other && Equals(other);
        public override int GetHashCode() => _value.GetHashCode();
        public override string ToString() => _value.ToString();
        public string ToString(IFormatProvider formatProvider) => _value.ToString(formatProvider);
        public string ToString(string format) => _value.ToString(format);
        public string ToString(string? format, IFormatProvider? formatProvider) => _value.ToString(format, formatProvider);

        public static bool IsNormal(SingleM d) => SingleShim.IsNormal(d._value);
        public static bool IsSubnormal(SingleM d) => SingleShim.IsSubnormal(d._value);
        public static bool TryParse(string s, IFormatProvider? provider, out SingleM result) => FuncExtensions.Try(() => Parse(s, provider), out result);
        public static bool TryParse(string s, NumberStyles style, IFormatProvider? provider, out SingleM result) => FuncExtensions.Try(() => Parse(s, style, provider), out result);
        public static bool TryParse(string s, NumberStyles style, out SingleM result) => FuncExtensions.Try(() => Parse(s, style), out result);
        public static bool TryParse(string s, out SingleM result) => FuncExtensions.Try(() => Parse(s), out result);
        public static SingleM Parse(string s) => float.Parse(s);
        public static SingleM Parse(string s, IFormatProvider? provider) => float.Parse(s, provider);
        public static SingleM Parse(string s, NumberStyles style) => float.Parse(s, style);
        public static SingleM Parse(string s, NumberStyles style, IFormatProvider? provider) => float.Parse(s, style, provider);

        [CLSCompliant(false)] public static implicit operator SingleM(sbyte value) => new SingleM(value);
        [CLSCompliant(false)] public static implicit operator SingleM(uint value) => new SingleM(value);
        [CLSCompliant(false)] public static implicit operator SingleM(ulong value) => new SingleM(value);
        [CLSCompliant(false)] public static implicit operator SingleM(ushort value) => new SingleM(value);
        public static explicit operator SingleM(decimal value) => new SingleM(ConvertN.ToSingle(value, Conversion.CastClamp));
        public static explicit operator SingleM(double value) => new SingleM(ConvertN.ToSingle(value, Conversion.CastClamp));
        public static implicit operator SingleM(byte value) => new SingleM(value);
        public static implicit operator SingleM(float value) => new SingleM(value);
        public static implicit operator SingleM(int value) => new SingleM(value);
        public static implicit operator SingleM(long value) => new SingleM(value);
        public static implicit operator SingleM(short value) => new SingleM(value);

        [CLSCompliant(false)] public static explicit operator sbyte(SingleM value) => ConvertN.ToSByte(value._value, Conversion.CastClamp);
        [CLSCompliant(false)] public static explicit operator uint(SingleM value) => ConvertN.ToUInt32(value._value, Conversion.CastClamp);
        [CLSCompliant(false)] public static explicit operator ulong(SingleM value) => ConvertN.ToUInt64(value._value, Conversion.CastClamp);
        [CLSCompliant(false)] public static explicit operator ushort(SingleM value) => ConvertN.ToUInt16(value._value, Conversion.CastClamp);
        public static explicit operator byte(SingleM value) => ConvertN.ToByte(value._value, Conversion.CastClamp);
        public static explicit operator decimal(SingleM value) => ConvertN.ToDecimal(value._value, Conversion.CastClamp);
        public static explicit operator int(SingleM value) => ConvertN.ToInt32(value._value, Conversion.CastClamp);
        public static explicit operator long(SingleM value) => ConvertN.ToInt64(value._value, Conversion.CastClamp);
        public static explicit operator short(SingleM value) => ConvertN.ToInt16(value._value, Conversion.CastClamp);
        public static implicit operator double(SingleM value) => value._value;
        public static implicit operator float(SingleM value) => value._value;

        public static bool operator !=(SingleM left, SingleM right) => left._value != right._value;
        public static bool operator <(SingleM left, SingleM right) => left._value < right._value;
        public static bool operator <=(SingleM left, SingleM right) => left._value <= right._value;
        public static bool operator ==(SingleM left, SingleM right) => left._value == right._value;
        public static bool operator >(SingleM left, SingleM right) => left._value > right._value;
        public static bool operator >=(SingleM left, SingleM right) => left._value >= right._value;
        public static SingleM operator %(SingleM left, SingleM right) => Clamped.Remainder(left._value, right._value);
        public static SingleM operator &(SingleM left, SingleM right) => BitOperations.LogicalAnd(left._value, right._value);
        public static SingleM operator -(SingleM left, SingleM right) => Clamped.Subtract(left._value, right._value);
        public static SingleM operator --(SingleM value) => value - 1;
        public static SingleM operator -(SingleM value) => -value._value;
        public static SingleM operator *(SingleM left, SingleM right) => Clamped.Multiply(left._value, right._value);
        public static SingleM operator /(SingleM left, SingleM right) => Clamped.Divide(left._value, right._value);
        public static SingleM operator ^(SingleM left, SingleM right) => BitOperations.LogicalExclusiveOr(left._value, right._value);
        public static SingleM operator |(SingleM left, SingleM right) => BitOperations.LogicalOr(left._value, right._value);
        public static SingleM operator ~(SingleM left) => BitOperations.BitwiseComplement(left._value);
        public static SingleM operator +(SingleM left, SingleM right) => Clamped.Add(left._value, right._value);
        public static SingleM operator +(SingleM value) => value;
        public static SingleM operator ++(SingleM value) => value + 1;
        public static SingleM operator <<(SingleM left, int right) => BitOperations.LeftShift(left._value, right);
        public static SingleM operator >>(SingleM left, int right) => BitOperations.RightShift(left._value, right);

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
            if (SingleShim.IsFinite(value)) return value;
            else if (float.IsPositiveInfinity(value)) return float.MaxValue;
            else if (float.IsNegativeInfinity(value)) return float.MinValue;
            else return 0f;
        }

        bool INumeric<SingleM>.IsGreaterThan(SingleM value) => this > value;
        bool INumeric<SingleM>.IsGreaterThanOrEqualTo(SingleM value) => this >= value;
        bool INumeric<SingleM>.IsLessThan(SingleM value) => this < value;
        bool INumeric<SingleM>.IsLessThanOrEqualTo(SingleM value) => this <= value;
        SingleM INumeric<SingleM>.Add(SingleM value) => this + value;
        SingleM INumeric<SingleM>.BitwiseComplement() => ~this;
        SingleM INumeric<SingleM>.Divide(SingleM value) => this / value;
        SingleM INumeric<SingleM>.LeftShift(int count) => this << count;
        SingleM INumeric<SingleM>.LogicalAnd(SingleM value) => this & value;
        SingleM INumeric<SingleM>.LogicalExclusiveOr(SingleM value) => this ^ value;
        SingleM INumeric<SingleM>.LogicalOr(SingleM value) => this | value;
        SingleM INumeric<SingleM>.Multiply(SingleM value) => this * value;
        SingleM INumeric<SingleM>.Negative() => -this;
        SingleM INumeric<SingleM>.Positive() => +this;
        SingleM INumeric<SingleM>.Remainder(SingleM value) => this % value;
        SingleM INumeric<SingleM>.RightShift(int count) => this >> count;
        SingleM INumeric<SingleM>.Subtract(SingleM value) => this - value;

        INumericBitConverter<SingleM> IProvider<INumericBitConverter<SingleM>>.GetInstance() => Utilities.Instance;
        IBinaryIO<SingleM> IProvider<IBinaryIO<SingleM>>.GetInstance() => Utilities.Instance;
        IConvert<SingleM> IProvider<IConvert<SingleM>>.GetInstance() => Utilities.Instance;
        IConvertExtended<SingleM> IProvider<IConvertExtended<SingleM>>.GetInstance() => Utilities.Instance;
        IMath<SingleM> IProvider<IMath<SingleM>>.GetInstance() => Utilities.Instance;
        INumericRandom<SingleM> IProvider<INumericRandom<SingleM>>.GetInstance() => Utilities.Instance;
        INumericStatic<SingleM> IProvider<INumericStatic<SingleM>>.GetInstance() => Utilities.Instance;
        IVariantRandom<SingleM> IProvider<IVariantRandom<SingleM>>.GetInstance() => Utilities.Instance;

        private sealed class Utilities :
            IBinaryIO<SingleM>,
            IConvert<SingleM>,
            IConvertExtended<SingleM>,
            IMath<SingleM>,
            INumericBitConverter<SingleM>,
            INumericRandom<SingleM>,
            INumericStatic<SingleM>,
            IVariantRandom<SingleM>
        {
            public static readonly Utilities Instance = new Utilities();

            void IBinaryIO<SingleM>.Write(BinaryWriter writer, SingleM value) => writer.Write(value);
            SingleM IBinaryIO<SingleM>.Read(BinaryReader reader) => reader.ReadSingle();

            bool INumericStatic<SingleM>.HasFloatingPoint => true;
            bool INumericStatic<SingleM>.HasInfinity => false;
            bool INumericStatic<SingleM>.HasNaN => false;
            bool INumericStatic<SingleM>.IsFinite(SingleM x) => true;
            bool INumericStatic<SingleM>.IsInfinity(SingleM x) => false;
            bool INumericStatic<SingleM>.IsNaN(SingleM x) => false;
            bool INumericStatic<SingleM>.IsNegative(SingleM x) => x._value < 0;
            bool INumericStatic<SingleM>.IsNegativeInfinity(SingleM x) => false;
            bool INumericStatic<SingleM>.IsNormal(SingleM x) => IsNormal(x);
            bool INumericStatic<SingleM>.IsPositiveInfinity(SingleM x) => false;
            bool INumericStatic<SingleM>.IsReal => true;
            bool INumericStatic<SingleM>.IsSigned => true;
            bool INumericStatic<SingleM>.IsSubnormal(SingleM x) => IsSubnormal(x);
            SingleM INumericStatic<SingleM>.Epsilon => Epsilon;
            SingleM INumericStatic<SingleM>.MaxUnit => 1;
            SingleM INumericStatic<SingleM>.MaxValue => MaxValue;
            SingleM INumericStatic<SingleM>.MinUnit => -1;
            SingleM INumericStatic<SingleM>.MinValue => MinValue;
            SingleM INumericStatic<SingleM>.One => 1;
            SingleM INumericStatic<SingleM>.Zero => 0;

            SingleM IMath<SingleM>.Abs(SingleM value) => MathFShim.Abs(value._value);
            SingleM IMath<SingleM>.Acos(SingleM x) => MathFShim.Acos(x._value);
            SingleM IMath<SingleM>.Acosh(SingleM x) => MathFShim.Acosh(x._value);
            SingleM IMath<SingleM>.Asin(SingleM x) => MathFShim.Asin(x._value);
            SingleM IMath<SingleM>.Asinh(SingleM x) => MathFShim.Asinh(x._value);
            SingleM IMath<SingleM>.Atan(SingleM x) => MathFShim.Atan(x._value);
            SingleM IMath<SingleM>.Atan2(SingleM x, SingleM y) => MathFShim.Atan2(x._value, y._value);
            SingleM IMath<SingleM>.Atanh(SingleM x) => MathFShim.Atanh(x._value);
            SingleM IMath<SingleM>.Cbrt(SingleM x) => MathFShim.Cbrt(x._value);
            SingleM IMath<SingleM>.Ceiling(SingleM x) => MathFShim.Ceiling(x._value);
            SingleM IMath<SingleM>.Clamp(SingleM x, SingleM bound1, SingleM bound2) => bound1 > bound2 ? MathFShim.Min(bound1._value, MathFShim.Max(bound2._value, x._value)) : MathFShim.Min(bound2._value, MathFShim.Max(bound1._value, x._value));
            SingleM IMath<SingleM>.Cos(SingleM x) => MathFShim.Cos(x._value);
            SingleM IMath<SingleM>.Cosh(SingleM x) => MathFShim.Cosh(x._value);
            SingleM IMath<SingleM>.E { get; } = MathFShim.E;
            SingleM IMath<SingleM>.Exp(SingleM x) => MathFShim.Exp(x._value);
            SingleM IMath<SingleM>.Floor(SingleM x) => MathFShim.Floor(x._value);
            SingleM IMath<SingleM>.IEEERemainder(SingleM x, SingleM y) => MathFShim.IEEERemainder(x._value, y._value);
            SingleM IMath<SingleM>.Log(SingleM x) => MathFShim.Log(x._value);
            SingleM IMath<SingleM>.Log(SingleM x, SingleM y) => MathFShim.Log(x._value, y._value);
            SingleM IMath<SingleM>.Log10(SingleM x) => MathFShim.Log10(x._value);
            SingleM IMath<SingleM>.Max(SingleM x, SingleM y) => MathFShim.Max(x._value, y._value);
            SingleM IMath<SingleM>.Min(SingleM x, SingleM y) => MathFShim.Min(x._value, y._value);
            SingleM IMath<SingleM>.PI { get; } = MathFShim.PI;
            SingleM IMath<SingleM>.Pow(SingleM x, SingleM y) => MathFShim.Pow(x._value, y._value);
            SingleM IMath<SingleM>.Round(SingleM x) => MathFShim.Round(x._value);
            SingleM IMath<SingleM>.Round(SingleM x, int digits) => MathFShim.Round(x._value, digits);
            SingleM IMath<SingleM>.Round(SingleM x, int digits, MidpointRounding mode) => MathFShim.Round(x._value, digits, mode);
            SingleM IMath<SingleM>.Round(SingleM x, MidpointRounding mode) => MathFShim.Round(x._value, mode);
            SingleM IMath<SingleM>.Sin(SingleM x) => MathFShim.Sin(x._value);
            SingleM IMath<SingleM>.Sinh(SingleM x) => MathFShim.Sinh(x._value);
            SingleM IMath<SingleM>.Sqrt(SingleM x) => MathFShim.Sqrt(x._value);
            SingleM IMath<SingleM>.Tan(SingleM x) => MathFShim.Tan(x._value);
            SingleM IMath<SingleM>.Tanh(SingleM x) => MathFShim.Tanh(x._value);
            SingleM IMath<SingleM>.Tau { get; } = MathFShim.PI * 2f;
            SingleM IMath<SingleM>.Truncate(SingleM x) => MathFShim.Truncate(x._value);
            int IMath<SingleM>.Sign(SingleM x) => Math.Sign(x._value);

            int INumericBitConverter<SingleM>.ConvertedSize => sizeof(float);
            SingleM INumericBitConverter<SingleM>.ToNumeric(byte[] value, int startIndex) => BitConverter.ToSingle(value, startIndex);
            byte[] INumericBitConverter<SingleM>.GetBytes(SingleM value) => BitConverter.GetBytes(value._value);
#if HAS_SPANS
            SingleM INumericBitConverter<SingleM>.ToNumeric(ReadOnlySpan<byte> value) => BitConverter.ToSingle(value);
            bool INumericBitConverter<SingleM>.TryWriteBytes(Span<byte> destination, SingleM value) => BitConverter.TryWriteBytes(destination, value);
#endif

            bool IConvert<SingleM>.ToBoolean(SingleM value) => value._value != 0;
            byte IConvert<SingleM>.ToByte(SingleM value, Conversion mode) => ConvertN.ToByte(value._value, mode.Clamped());
            decimal IConvert<SingleM>.ToDecimal(SingleM value, Conversion mode) => ConvertN.ToDecimal(value._value, mode.Clamped());
            double IConvert<SingleM>.ToDouble(SingleM value, Conversion mode) => ConvertN.ToDouble(value._value, mode.Clamped());
            float IConvert<SingleM>.ToSingle(SingleM value, Conversion mode) => value._value;
            int IConvert<SingleM>.ToInt32(SingleM value, Conversion mode) => ConvertN.ToInt32(value._value, mode.Clamped());
            long IConvert<SingleM>.ToInt64(SingleM value, Conversion mode) => ConvertN.ToInt64(value._value, mode.Clamped());
            sbyte IConvertExtended<SingleM>.ToSByte(SingleM value, Conversion mode) => ConvertN.ToSByte(value._value, mode.Clamped());
            short IConvert<SingleM>.ToInt16(SingleM value, Conversion mode) => ConvertN.ToInt16(value._value, mode.Clamped());
            string IConvert<SingleM>.ToString(SingleM value) => Convert.ToString(value._value);
            uint IConvertExtended<SingleM>.ToUInt32(SingleM value, Conversion mode) => ConvertN.ToUInt32(value._value, mode.Clamped());
            ulong IConvertExtended<SingleM>.ToUInt64(SingleM value, Conversion mode) => ConvertN.ToUInt64(value._value, mode.Clamped());
            ushort IConvertExtended<SingleM>.ToUInt16(SingleM value, Conversion mode) => ConvertN.ToUInt16(value._value, mode.Clamped());

            SingleM IConvert<SingleM>.ToNumeric(bool value) => value ? 1f : 0f;
            SingleM IConvert<SingleM>.ToNumeric(byte value, Conversion mode) => ConvertN.ToSingle(value, mode.Clamped());
            SingleM IConvert<SingleM>.ToNumeric(decimal value, Conversion mode) => ConvertN.ToSingle(value, mode.Clamped());
            SingleM IConvert<SingleM>.ToNumeric(double value, Conversion mode) => ConvertN.ToSingle(value, mode.Clamped());
            SingleM IConvert<SingleM>.ToNumeric(float value, Conversion mode) => value;
            SingleM IConvert<SingleM>.ToNumeric(int value, Conversion mode) => ConvertN.ToSingle(value, mode.Clamped());
            SingleM IConvert<SingleM>.ToNumeric(long value, Conversion mode) => ConvertN.ToSingle(value, mode.Clamped());
            SingleM IConvertExtended<SingleM>.ToValue(sbyte value, Conversion mode) => ConvertN.ToSingle(value, mode.Clamped());
            SingleM IConvert<SingleM>.ToNumeric(short value, Conversion mode) => ConvertN.ToSingle(value, mode.Clamped());
            SingleM IConvert<SingleM>.ToNumeric(string value) => Convert.ToSingle(value);
            SingleM IConvertExtended<SingleM>.ToNumeric(uint value, Conversion mode) => ConvertN.ToSingle(value, mode.Clamped());
            SingleM IConvertExtended<SingleM>.ToNumeric(ulong value, Conversion mode) => ConvertN.ToSingle(value, mode.Clamped());
            SingleM IConvertExtended<SingleM>.ToNumeric(ushort value, Conversion mode) => ConvertN.ToSingle(value, mode.Clamped());

            SingleM INumericStatic<SingleM>.Parse(string s, NumberStyles? style, IFormatProvider? provider)
                => Parse(s, style ?? NumberStyles.Float | NumberStyles.AllowThousands, provider);

            SingleM INumericRandom<SingleM>.Generate(Random random) => random.NextSingle();
            SingleM INumericRandom<SingleM>.Generate(Random random, SingleM maxValue) => random.NextSingle(maxValue);
            SingleM INumericRandom<SingleM>.Generate(Random random, SingleM minValue, SingleM maxValue) => random.NextSingle(minValue, maxValue);
            SingleM INumericRandom<SingleM>.Generate(Random random, Generation mode) => random.NextSingle(mode);
            SingleM INumericRandom<SingleM>.Generate(Random random, SingleM minValue, SingleM maxValue, Generation mode) => random.NextSingle(minValue, maxValue, mode);

            SingleM IVariantRandom<SingleM>.Generate(Random random, Variants variants) => random.NextSingle(variants);
        }
    }
}
