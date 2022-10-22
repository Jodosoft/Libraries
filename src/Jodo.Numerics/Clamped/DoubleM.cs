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
using System.Threading.Tasks;
using Jodo.Primitives;
using Jodo.Primitives.Compatibility;

namespace Jodo.Numerics.Clamped
{
    /// <summary>
    /// Represents a double-precision floating-point number that cannot overflow.
    /// </summary>
    [Serializable]
    [DebuggerDisplay("{ToString(),nq}")]
    public readonly struct DoubleM : INumericExtended<DoubleM>
    {
        public static readonly DoubleM Epsilon = double.Epsilon;
        public static readonly DoubleM MaxValue = double.MaxValue;
        public static readonly DoubleM MinValue = double.MinValue;

        private readonly double _value;

        public DoubleM(double value)
        {
            _value = Check(value);
        }

        private DoubleM(SerializationInfo info, StreamingContext context)
        {
            _value = Check(info.GetDouble(nameof(DoubleM)));
        }

        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue(nameof(DoubleM), _value);
        }

        public int CompareTo(DoubleM other) => _value.CompareTo(other._value);
        public int CompareTo(object? obj) => obj is DoubleM other ? CompareTo(other) : 1;
        public bool Equals(DoubleM other) => _value == other._value;
        public override bool Equals(object? obj) => obj is DoubleM other && Equals(other);
        public override int GetHashCode() => _value.GetHashCode();
        public override string ToString() => _value.ToString();
        public string ToString(IFormatProvider formatProvider) => _value.ToString(formatProvider);
        public string ToString(string format) => _value.ToString(format);
        public string ToString(string? format, IFormatProvider? formatProvider) => _value.ToString(format, formatProvider);

        public static bool IsNormal(DoubleM d) => DoubleShim.IsNormal(d._value);
        public static bool IsSubnormal(DoubleM d) => DoubleShim.IsSubnormal(d._value);
        public static bool TryParse(string s, IFormatProvider? provider, out DoubleM result) => FuncExtensions.Try(() => Parse(s, provider), out result);
        public static bool TryParse(string s, NumberStyles style, IFormatProvider? provider, out DoubleM result) => FuncExtensions.Try(() => Parse(s, style, provider), out result);
        public static bool TryParse(string s, NumberStyles style, out DoubleM result) => FuncExtensions.Try(() => Parse(s, style), out result);
        public static bool TryParse(string s, out DoubleM result) => FuncExtensions.Try(() => Parse(s), out result);
        public static DoubleM Parse(string s) => double.Parse(s);
        public static DoubleM Parse(string s, IFormatProvider? provider) => double.Parse(s, provider);
        public static DoubleM Parse(string s, NumberStyles style) => double.Parse(s, style);
        public static DoubleM Parse(string s, NumberStyles style, IFormatProvider? provider) => double.Parse(s, style, provider);

        [CLSCompliant(false)] public static implicit operator DoubleM(sbyte value) => new DoubleM(value);
        [CLSCompliant(false)] public static implicit operator DoubleM(uint value) => new DoubleM(value);
        [CLSCompliant(false)] public static implicit operator DoubleM(ulong value) => new DoubleM(value);
        [CLSCompliant(false)] public static implicit operator DoubleM(ushort value) => new DoubleM(value);
        public static explicit operator DoubleM(decimal value) => new DoubleM(ConvertN.ToDouble(value, Conversion.CastClamp));
        public static implicit operator DoubleM(byte value) => new DoubleM(value);
        public static implicit operator DoubleM(double value) => new DoubleM(value);
        public static implicit operator DoubleM(float value) => new DoubleM(value);
        public static implicit operator DoubleM(int value) => new DoubleM(value);
        public static implicit operator DoubleM(long value) => new DoubleM(value);
        public static implicit operator DoubleM(short value) => new DoubleM(value);

        [CLSCompliant(false)] public static explicit operator sbyte(DoubleM value) => ConvertN.ToSByte(value._value, Conversion.CastClamp);
        [CLSCompliant(false)] public static explicit operator uint(DoubleM value) => ConvertN.ToUInt32(value._value, Conversion.CastClamp);
        [CLSCompliant(false)] public static explicit operator ulong(DoubleM value) => ConvertN.ToUInt64(value._value, Conversion.CastClamp);
        [CLSCompliant(false)] public static explicit operator ushort(DoubleM value) => ConvertN.ToUInt16(value._value, Conversion.CastClamp);
        public static explicit operator byte(DoubleM value) => ConvertN.ToByte(value._value, Conversion.CastClamp);
        public static explicit operator decimal(DoubleM value) => ConvertN.ToDecimal(value._value, Conversion.CastClamp);
        public static explicit operator float(DoubleM value) => ConvertN.ToSingle(value._value, Conversion.CastClamp);
        public static explicit operator int(DoubleM value) => ConvertN.ToInt32(value._value, Conversion.CastClamp);
        public static explicit operator long(DoubleM value) => ConvertN.ToInt64(value._value, Conversion.CastClamp);
        public static explicit operator short(DoubleM value) => ConvertN.ToInt16(value._value, Conversion.CastClamp);
        public static implicit operator double(DoubleM value) => value._value;

        public static bool operator !=(DoubleM left, DoubleM right) => left._value != right._value;
        public static bool operator <(DoubleM left, DoubleM right) => left._value < right._value;
        public static bool operator <=(DoubleM left, DoubleM right) => left._value <= right._value;
        public static bool operator ==(DoubleM left, DoubleM right) => left._value == right._value;
        public static bool operator >(DoubleM left, DoubleM right) => left._value > right._value;
        public static bool operator >=(DoubleM left, DoubleM right) => left._value >= right._value;
        public static DoubleM operator %(DoubleM left, DoubleM right) => Clamped.Remainder(left._value, right._value);
        public static DoubleM operator -(DoubleM left, DoubleM right) => Clamped.Subtract(left._value, right._value);
        public static DoubleM operator --(DoubleM value) => value - 1;
        public static DoubleM operator -(DoubleM value) => -value._value;
        public static DoubleM operator *(DoubleM left, DoubleM right) => Clamped.Multiply(left._value, right._value);
        public static DoubleM operator /(DoubleM left, DoubleM right) => Clamped.Divide(left._value, right._value);
        public static DoubleM operator +(DoubleM left, DoubleM right) => Clamped.Add(left._value, right._value);
        public static DoubleM operator +(DoubleM value) => value;
        public static DoubleM operator ++(DoubleM value) => value + 1;
        public static DoubleM operator &(DoubleM left, DoubleM right) => BitOperations.LogicalAnd(left._value, right._value);
        public static DoubleM operator |(DoubleM left, DoubleM right) => BitOperations.LogicalOr(left._value, right._value);
        public static DoubleM operator ^(DoubleM left, DoubleM right) => BitOperations.LogicalExclusiveOr(left._value, right._value);
        public static DoubleM operator ~(DoubleM left) => BitOperations.BitwiseComplement(left._value);
        public static DoubleM operator >>(DoubleM left, int right) => BitOperations.RightShift(left._value, right);
        public static DoubleM operator <<(DoubleM left, int right) => BitOperations.LeftShift(left._value, right);

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
            if (DoubleShim.IsFinite(value)) return value;
            else if (double.IsPositiveInfinity(value)) return double.MaxValue;
            else if (double.IsNegativeInfinity(value)) return double.MinValue;
            else return 0d;
        }

        bool INumeric<DoubleM>.IsGreaterThan(DoubleM value) => this > value;
        bool INumeric<DoubleM>.IsGreaterThanOrEqualTo(DoubleM value) => this >= value;
        bool INumeric<DoubleM>.IsLessThan(DoubleM value) => this < value;
        bool INumeric<DoubleM>.IsLessThanOrEqualTo(DoubleM value) => this <= value;
        DoubleM INumeric<DoubleM>.Add(DoubleM value) => this + value;
        DoubleM INumeric<DoubleM>.BitwiseComplement() => ~this;
        DoubleM INumeric<DoubleM>.Divide(DoubleM value) => this / value;
        DoubleM INumeric<DoubleM>.LeftShift(int count) => this << count;
        DoubleM INumeric<DoubleM>.LogicalAnd(DoubleM value) => this & value;
        DoubleM INumeric<DoubleM>.LogicalExclusiveOr(DoubleM value) => this ^ value;
        DoubleM INumeric<DoubleM>.LogicalOr(DoubleM value) => this | value;
        DoubleM INumeric<DoubleM>.Multiply(DoubleM value) => this * value;
        DoubleM INumeric<DoubleM>.Negative() => -this;
        DoubleM INumeric<DoubleM>.Positive() => +this;
        DoubleM INumeric<DoubleM>.Remainder(DoubleM value) => this % value;
        DoubleM INumeric<DoubleM>.RightShift(int count) => this >> count;
        DoubleM INumeric<DoubleM>.Subtract(DoubleM value) => this - value;

        INumericBitConverter<DoubleM> IProvider<INumericBitConverter<DoubleM>>.GetInstance() => Utilities.Instance;
        IBitBuffer<DoubleM> IProvider<IBitBuffer<DoubleM>>.GetInstance() => Utilities.Instance;
        IConvert<DoubleM> IProvider<IConvert<DoubleM>>.GetInstance() => Utilities.Instance;
        IConvertExtended<DoubleM> IProvider<IConvertExtended<DoubleM>>.GetInstance() => Utilities.Instance;
        IMath<DoubleM> IProvider<IMath<DoubleM>>.GetInstance() => Utilities.Instance;
        INumericRandom<DoubleM> IProvider<INumericRandom<DoubleM>>.GetInstance() => Utilities.Instance;
        INumericStatic<DoubleM> IProvider<INumericStatic<DoubleM>>.GetInstance() => Utilities.Instance;
        IVariantRandom<DoubleM> IProvider<IVariantRandom<DoubleM>>.GetInstance() => Utilities.Instance;

        private sealed class Utilities :
            IBitBuffer<DoubleM>,
            IConvert<DoubleM>,
            IConvertExtended<DoubleM>,
            IMath<DoubleM>,
            INumericBitConverter<DoubleM>,
            INumericRandom<DoubleM>,
            INumericStatic<DoubleM>,
            IVariantRandom<DoubleM>
        {
            public static readonly Utilities Instance = new Utilities();

            void IBitBuffer<DoubleM>.Write(DoubleM value, Stream stream) => stream.Write(value._value);
            async Task IBitBuffer<DoubleM>.WriteAsync(DoubleM value, Stream stream) => await stream.WriteAsync(value._value);
            DoubleM IBitBuffer<DoubleM>.Read(Stream stream) => stream.ReadDouble();
            async Task<DoubleM> IBitBuffer<DoubleM>.ReadAsync(Stream stream) => await stream.ReadDoubleAsync();

            bool INumericStatic<DoubleM>.HasFloatingPoint => true;
            bool INumericStatic<DoubleM>.HasInfinity => false;
            bool INumericStatic<DoubleM>.HasNaN => false;
            bool INumericStatic<DoubleM>.IsFinite(DoubleM x) => true;
            bool INumericStatic<DoubleM>.IsInfinity(DoubleM x) => false;
            bool INumericStatic<DoubleM>.IsNaN(DoubleM x) => false;
            bool INumericStatic<DoubleM>.IsNegative(DoubleM x) => x._value < 0;
            bool INumericStatic<DoubleM>.IsNegativeInfinity(DoubleM x) => false;
            bool INumericStatic<DoubleM>.IsNormal(DoubleM x) => IsNormal(x);
            bool INumericStatic<DoubleM>.IsPositiveInfinity(DoubleM x) => false;
            bool INumericStatic<DoubleM>.IsReal => true;
            bool INumericStatic<DoubleM>.IsSigned => true;
            bool INumericStatic<DoubleM>.IsSubnormal(DoubleM x) => IsSubnormal(x);
            DoubleM INumericStatic<DoubleM>.Epsilon => Epsilon;
            DoubleM INumericStatic<DoubleM>.MaxUnit => 1d;
            DoubleM INumericStatic<DoubleM>.MaxValue => MaxValue;
            DoubleM INumericStatic<DoubleM>.MinUnit => -1d;
            DoubleM INumericStatic<DoubleM>.MinValue => MinValue;
            DoubleM INumericStatic<DoubleM>.One => 1d;
            DoubleM INumericStatic<DoubleM>.Zero => 0d;

            DoubleM IMath<DoubleM>.Abs(DoubleM value) => Math.Abs(value._value);
            DoubleM IMath<DoubleM>.Acos(DoubleM x) => Math.Acos(x._value);
            DoubleM IMath<DoubleM>.Acosh(DoubleM x) => MathShim.Acosh(x._value);
            DoubleM IMath<DoubleM>.Asin(DoubleM x) => Math.Asin(x._value);
            DoubleM IMath<DoubleM>.Asinh(DoubleM x) => MathShim.Asinh(x._value);
            DoubleM IMath<DoubleM>.Atan(DoubleM x) => Math.Atan(x._value);
            DoubleM IMath<DoubleM>.Atan2(DoubleM x, DoubleM y) => Math.Atan2(x._value, y._value);
            DoubleM IMath<DoubleM>.Atanh(DoubleM x) => MathShim.Atanh(x._value);
            DoubleM IMath<DoubleM>.Cbrt(DoubleM x) => MathShim.Cbrt(x._value);
            DoubleM IMath<DoubleM>.Ceiling(DoubleM x) => Math.Ceiling(x._value);
            DoubleM IMath<DoubleM>.Clamp(DoubleM x, DoubleM bound1, DoubleM bound2) => bound1 > bound2 ? Math.Min(bound1._value, Math.Max(bound2._value, x._value)) : Math.Min(bound2._value, Math.Max(bound1._value, x._value));
            DoubleM IMath<DoubleM>.Cos(DoubleM x) => Math.Cos(x._value);
            DoubleM IMath<DoubleM>.Cosh(DoubleM x) => Math.Cosh(x._value);
            DoubleM IMath<DoubleM>.E { get; } = Math.E;
            DoubleM IMath<DoubleM>.Exp(DoubleM x) => Math.Exp(x._value);
            DoubleM IMath<DoubleM>.Floor(DoubleM x) => Math.Floor(x._value);
            DoubleM IMath<DoubleM>.IEEERemainder(DoubleM x, DoubleM y) => Math.IEEERemainder(x._value, y._value);
            DoubleM IMath<DoubleM>.Log(DoubleM x) => Math.Log(x._value);
            DoubleM IMath<DoubleM>.Log(DoubleM x, DoubleM y) => Math.Log(x._value, y._value);
            DoubleM IMath<DoubleM>.Log10(DoubleM x) => Math.Log10(x._value);
            DoubleM IMath<DoubleM>.Max(DoubleM x, DoubleM y) => Math.Max(x._value, y._value);
            DoubleM IMath<DoubleM>.Min(DoubleM x, DoubleM y) => Math.Min(x._value, y._value);
            DoubleM IMath<DoubleM>.PI { get; } = Math.PI;
            DoubleM IMath<DoubleM>.Pow(DoubleM x, DoubleM y) => Math.Pow(x._value, y._value);
            DoubleM IMath<DoubleM>.Round(DoubleM x) => Math.Round(x._value);
            DoubleM IMath<DoubleM>.Round(DoubleM x, int digits) => Math.Round(x._value, digits);
            DoubleM IMath<DoubleM>.Round(DoubleM x, int digits, MidpointRounding mode) => Math.Round(x._value, digits, mode);
            DoubleM IMath<DoubleM>.Round(DoubleM x, MidpointRounding mode) => Math.Round(x._value, mode);
            DoubleM IMath<DoubleM>.Sin(DoubleM x) => Math.Sin(x._value);
            DoubleM IMath<DoubleM>.Sinh(DoubleM x) => Math.Sinh(x._value);
            DoubleM IMath<DoubleM>.Sqrt(DoubleM x) => Math.Sqrt(x._value);
            DoubleM IMath<DoubleM>.Tan(DoubleM x) => Math.Tan(x._value);
            DoubleM IMath<DoubleM>.Tanh(DoubleM x) => Math.Tanh(x._value);
            DoubleM IMath<DoubleM>.Tau { get; } = Math.PI * 2d;
            DoubleM IMath<DoubleM>.Truncate(DoubleM x) => Math.Truncate(x._value);
            int IMath<DoubleM>.Sign(DoubleM x) => Math.Sign(x._value);

            int INumericBitConverter<DoubleM>.ConvertedSize => sizeof(double);
            DoubleM INumericBitConverter<DoubleM>.ToNumeric(byte[] value, int startIndex) => BitConverter.ToDouble(value, startIndex);
            byte[] INumericBitConverter<DoubleM>.GetBytes(DoubleM value) => BitConverter.GetBytes(value._value);

            bool IConvert<DoubleM>.ToBoolean(DoubleM value) => value._value != 0;
            byte IConvert<DoubleM>.ToByte(DoubleM value, Conversion mode) => ConvertN.ToByte(value._value, mode.Clamped());
            decimal IConvert<DoubleM>.ToDecimal(DoubleM value, Conversion mode) => ConvertN.ToDecimal(value._value, mode.Clamped());
            double IConvert<DoubleM>.ToDouble(DoubleM value, Conversion mode) => value._value;
            float IConvert<DoubleM>.ToSingle(DoubleM value, Conversion mode) => ConvertN.ToSingle(value._value, mode.Clamped());
            int IConvert<DoubleM>.ToInt32(DoubleM value, Conversion mode) => ConvertN.ToInt32(value._value, mode.Clamped());
            long IConvert<DoubleM>.ToInt64(DoubleM value, Conversion mode) => ConvertN.ToInt64(value._value, mode.Clamped());
            sbyte IConvertExtended<DoubleM>.ToSByte(DoubleM value, Conversion mode) => ConvertN.ToSByte(value._value, mode.Clamped());
            short IConvert<DoubleM>.ToInt16(DoubleM value, Conversion mode) => ConvertN.ToInt16(value._value, mode.Clamped());
            string IConvert<DoubleM>.ToString(DoubleM value) => Convert.ToString(value._value);
            uint IConvertExtended<DoubleM>.ToUInt32(DoubleM value, Conversion mode) => ConvertN.ToUInt32(value._value, mode.Clamped());
            ulong IConvertExtended<DoubleM>.ToUInt64(DoubleM value, Conversion mode) => ConvertN.ToUInt64(value._value, mode.Clamped());
            ushort IConvertExtended<DoubleM>.ToUInt16(DoubleM value, Conversion mode) => ConvertN.ToUInt16(value._value, mode.Clamped());

            DoubleM IConvert<DoubleM>.ToNumeric(bool value) => value ? 1d : 0d;
            DoubleM IConvert<DoubleM>.ToNumeric(byte value, Conversion mode) => ConvertN.ToDouble(value, mode.Clamped());
            DoubleM IConvert<DoubleM>.ToNumeric(decimal value, Conversion mode) => ConvertN.ToDouble(value, mode.Clamped());
            DoubleM IConvert<DoubleM>.ToNumeric(double value, Conversion mode) => value;
            DoubleM IConvert<DoubleM>.ToNumeric(float value, Conversion mode) => ConvertN.ToDouble(value, mode.Clamped());
            DoubleM IConvert<DoubleM>.ToNumeric(int value, Conversion mode) => ConvertN.ToDouble(value, mode.Clamped());
            DoubleM IConvert<DoubleM>.ToNumeric(long value, Conversion mode) => ConvertN.ToDouble(value, mode.Clamped());
            DoubleM IConvertExtended<DoubleM>.ToValue(sbyte value, Conversion mode) => ConvertN.ToDouble(value, mode.Clamped());
            DoubleM IConvert<DoubleM>.ToNumeric(short value, Conversion mode) => ConvertN.ToDouble(value, mode.Clamped());
            DoubleM IConvert<DoubleM>.ToNumeric(string value) => Convert.ToDouble(value);
            DoubleM IConvertExtended<DoubleM>.ToNumeric(uint value, Conversion mode) => ConvertN.ToDouble(value, mode.Clamped());
            DoubleM IConvertExtended<DoubleM>.ToNumeric(ulong value, Conversion mode) => ConvertN.ToDouble(value, mode.Clamped());
            DoubleM IConvertExtended<DoubleM>.ToNumeric(ushort value, Conversion mode) => ConvertN.ToDouble(value, mode.Clamped());

            DoubleM INumericStatic<DoubleM>.Parse(string s, NumberStyles? style, IFormatProvider? provider)
                => Parse(s, style ?? NumberStyles.Float | NumberStyles.AllowThousands, provider);

            DoubleM INumericRandom<DoubleM>.Generate(Random random) => random.NextDouble();
            DoubleM INumericRandom<DoubleM>.Generate(Random random, DoubleM maxValue) => random.NextDouble(maxValue);
            DoubleM INumericRandom<DoubleM>.Generate(Random random, DoubleM minValue, DoubleM maxValue) => random.NextDouble(minValue, maxValue);
            DoubleM INumericRandom<DoubleM>.Generate(Random random, Generation mode) => random.NextDouble(mode);
            DoubleM INumericRandom<DoubleM>.Generate(Random random, DoubleM minValue, DoubleM maxValue, Generation mode) => random.NextDouble(minValue, maxValue, mode);

            DoubleM IVariantRandom<DoubleM>.Generate(Random random, Variants variants) => random.NextDouble(variants);
        }
    }
}
