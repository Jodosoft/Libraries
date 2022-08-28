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
using Jodo.Primitives;
using Jodo.Primitives.Compatibility;

namespace Jodo.Numerics
{
    /// <summary>
    /// Represents an 8-bit signed integer.
    /// </summary>
    [Serializable]
    [DebuggerDisplay("{ToString(),nq}")]
    public readonly struct SByteN : INumericExtended<SByteN>
    {
        public static readonly SByteN MaxValue = new SByteN(sbyte.MaxValue);
        public static readonly SByteN MinValue = new SByteN(sbyte.MinValue);

        private readonly sbyte _value;

        private SByteN(sbyte value)
        {
            _value = value;
        }

        private SByteN(SerializationInfo info, StreamingContext context) : this(info.GetSByte(nameof(SByteN))) { }
        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context) => info.AddValue(nameof(SByteN), _value);

        public int CompareTo(SByteN other) => _value.CompareTo(other._value);
        public int CompareTo(object? obj) => obj is SByteN other ? CompareTo(other) : 1;
        public bool Equals(SByteN other) => _value == other._value;
        public override bool Equals(object? obj) => obj is SByteN other && Equals(other);
        public override int GetHashCode() => _value.GetHashCode();
        public override string ToString() => _value.ToString();
        public string ToString(IFormatProvider formatProvider) => _value.ToString(formatProvider);
        public string ToString(string format) => _value.ToString(format);
        public string ToString(string? format, IFormatProvider? formatProvider) => _value.ToString(format, formatProvider);

        public static bool TryParse(string s, IFormatProvider? provider, out SByteN result) => TryHelper.Run(() => Parse(s, provider), out result);
        public static bool TryParse(string s, NumberStyles style, IFormatProvider? provider, out SByteN result) => TryHelper.Run(() => Parse(s, style, provider), out result);
        public static bool TryParse(string s, NumberStyles style, out SByteN result) => TryHelper.Run(() => Parse(s, style), out result);
        public static bool TryParse(string s, out SByteN result) => TryHelper.Run(() => Parse(s), out result);
        public static SByteN Parse(string s) => sbyte.Parse(s);
        public static SByteN Parse(string s, IFormatProvider? provider) => sbyte.Parse(s, provider);
        public static SByteN Parse(string s, NumberStyles style) => sbyte.Parse(s, style);
        public static SByteN Parse(string s, NumberStyles style, IFormatProvider? provider) => sbyte.Parse(s, style, provider);

        [CLSCompliant(false)] public static explicit operator SByteN(uint value) => new SByteN((sbyte)value);
        [CLSCompliant(false)] public static explicit operator SByteN(ulong value) => new SByteN((sbyte)value);
        [CLSCompliant(false)] public static explicit operator SByteN(ushort value) => new SByteN((sbyte)value);
        [CLSCompliant(false)] public static implicit operator SByteN(sbyte value) => new SByteN(value);
        public static explicit operator SByteN(byte value) => new SByteN((sbyte)value);
        public static explicit operator SByteN(decimal value) => new SByteN((sbyte)value);
        public static explicit operator SByteN(double value) => new SByteN((sbyte)value);
        public static explicit operator SByteN(float value) => new SByteN((sbyte)value);
        public static explicit operator SByteN(int value) => new SByteN((sbyte)value);
        public static explicit operator SByteN(long value) => new SByteN((sbyte)value);
        public static explicit operator SByteN(short value) => new SByteN((sbyte)value);

        [CLSCompliant(false)] public static explicit operator uint(SByteN value) => (uint)value._value;
        [CLSCompliant(false)] public static explicit operator ulong(SByteN value) => (ulong)value._value;
        [CLSCompliant(false)] public static explicit operator ushort(SByteN value) => (ushort)value._value;
        [CLSCompliant(false)] public static implicit operator sbyte(SByteN value) => value._value;
        public static explicit operator byte(SByteN value) => (byte)value._value;
        public static implicit operator decimal(SByteN value) => value._value;
        public static implicit operator double(SByteN value) => value._value;
        public static implicit operator float(SByteN value) => value._value;
        public static implicit operator int(SByteN value) => value._value;
        public static implicit operator long(SByteN value) => value._value;
        public static implicit operator short(SByteN value) => value._value;

        public static bool operator !=(SByteN left, SByteN right) => left._value != right._value;
        public static bool operator <(SByteN left, SByteN right) => left._value < right._value;
        public static bool operator <=(SByteN left, SByteN right) => left._value <= right._value;
        public static bool operator ==(SByteN left, SByteN right) => left._value == right._value;
        public static bool operator >(SByteN left, SByteN right) => left._value > right._value;
        public static bool operator >=(SByteN left, SByteN right) => left._value >= right._value;
        public static SByteN operator %(SByteN left, SByteN right) => (sbyte)(left._value % right._value);
        public static SByteN operator &(SByteN left, SByteN right) => (sbyte)(left._value & right._value);
        public static SByteN operator -(SByteN left, SByteN right) => (sbyte)(left._value - right._value);
        public static SByteN operator --(SByteN value) => (sbyte)(value._value - 1);
        public static SByteN operator -(SByteN value) => (sbyte)-value._value;
        public static SByteN operator *(SByteN left, SByteN right) => (sbyte)(left._value * right._value);
        public static SByteN operator /(SByteN left, SByteN right) => (sbyte)(left._value / right._value);
        public static SByteN operator ^(SByteN left, SByteN right) => (sbyte)(left._value ^ right._value);
        public static SByteN operator |(SByteN left, SByteN right) => (sbyte)(left._value | right._value);
        public static SByteN operator ~(SByteN value) => (sbyte)~value._value;
        public static SByteN operator +(SByteN left, SByteN right) => (sbyte)(left._value + right._value);
        public static SByteN operator +(SByteN value) => value;
        public static SByteN operator ++(SByteN value) => (sbyte)(value._value + 1);
        public static SByteN operator <<(SByteN left, int right) => (sbyte)(left._value << right);
        public static SByteN operator >>(SByteN left, int right) => (sbyte)(left._value >> right);

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
        object IConvertible.ToType(Type conversionType, IFormatProvider provider) => ((IConvertible)_value).ToType(conversionType, provider);

        bool INumeric<SByteN>.IsGreaterThan(SByteN value) => this > value;
        bool INumeric<SByteN>.IsGreaterThanOrEqualTo(SByteN value) => this >= value;
        bool INumeric<SByteN>.IsLessThan(SByteN value) => this < value;
        bool INumeric<SByteN>.IsLessThanOrEqualTo(SByteN value) => this <= value;
        SByteN INumeric<SByteN>.Add(SByteN value) => this + value;
        SByteN INumeric<SByteN>.BitwiseComplement() => ~this;
        SByteN INumeric<SByteN>.Divide(SByteN value) => this / value;
        SByteN INumeric<SByteN>.LeftShift(int count) => this << count;
        SByteN INumeric<SByteN>.LogicalAnd(SByteN value) => this & value;
        SByteN INumeric<SByteN>.LogicalExclusiveOr(SByteN value) => this ^ value;
        SByteN INumeric<SByteN>.LogicalOr(SByteN value) => this | value;
        SByteN INumeric<SByteN>.Multiply(SByteN value) => this * value;
        SByteN INumeric<SByteN>.Negative() => -this;
        SByteN INumeric<SByteN>.Positive() => +this;
        SByteN INumeric<SByteN>.Remainder(SByteN value) => this % value;
        SByteN INumeric<SByteN>.RightShift(int count) => this >> count;
        SByteN INumeric<SByteN>.Subtract(SByteN value) => this - value;

        INumericBitConverter<SByteN> IProvider<INumericBitConverter<SByteN>>.GetInstance() => Utilities.Instance;
        IConvert<SByteN> IProvider<IConvert<SByteN>>.GetInstance() => Utilities.Instance;
        IConvertExtended<SByteN> IProvider<IConvertExtended<SByteN>>.GetInstance() => Utilities.Instance;
        IMath<SByteN> IProvider<IMath<SByteN>>.GetInstance() => Utilities.Instance;
        INumericRandom<SByteN> IProvider<INumericRandom<SByteN>>.GetInstance() => Utilities.Instance;
        INumericStatic<SByteN> IProvider<INumericStatic<SByteN>>.GetInstance() => Utilities.Instance;
        IVariantRandom<SByteN> IProvider<IVariantRandom<SByteN>>.GetInstance() => Utilities.Instance;

        private sealed class Utilities :
            INumericBitConverter<SByteN>,
            IConvert<SByteN>,
            IConvertExtended<SByteN>,
            IMath<SByteN>,
            INumericRandom<SByteN>,
            INumericStatic<SByteN>,
            IVariantRandom<SByteN>
        {
            public static readonly Utilities Instance = new Utilities();

            bool INumericStatic<SByteN>.HasFloatingPoint => false;
            bool INumericStatic<SByteN>.HasInfinity => false;
            bool INumericStatic<SByteN>.HasNaN => false;
            bool INumericStatic<SByteN>.IsFinite(SByteN x) => true;
            bool INumericStatic<SByteN>.IsInfinity(SByteN x) => false;
            bool INumericStatic<SByteN>.IsNaN(SByteN x) => false;
            bool INumericStatic<SByteN>.IsNegative(SByteN x) => x._value < 0;
            bool INumericStatic<SByteN>.IsNegativeInfinity(SByteN x) => false;
            bool INumericStatic<SByteN>.IsNormal(SByteN x) => false;
            bool INumericStatic<SByteN>.IsPositiveInfinity(SByteN x) => false;
            bool INumericStatic<SByteN>.IsReal => false;
            bool INumericStatic<SByteN>.IsSigned => true;
            bool INumericStatic<SByteN>.IsSubnormal(SByteN x) => false;
            SByteN INumericStatic<SByteN>.Epsilon => 1;
            SByteN INumericStatic<SByteN>.MaxUnit => 1;
            SByteN INumericStatic<SByteN>.MaxValue => MaxValue;
            SByteN INumericStatic<SByteN>.MinUnit => -1;
            SByteN INumericStatic<SByteN>.MinValue => MinValue;
            SByteN INumericStatic<SByteN>.One => 1;
            SByteN INumericStatic<SByteN>.Ten => 10;
            SByteN INumericStatic<SByteN>.Two => 2;
            SByteN INumericStatic<SByteN>.Zero => 0;

            int IMath<SByteN>.Sign(SByteN x) => Math.Sign(x._value);
            SByteN IMath<SByteN>.Abs(SByteN value) => Math.Abs(value._value);
            SByteN IMath<SByteN>.Acos(SByteN x) => (sbyte)Math.Acos(x._value);
            SByteN IMath<SByteN>.Acosh(SByteN x) => (sbyte)MathCompat.Acosh(x._value);
            SByteN IMath<SByteN>.Asin(SByteN x) => (sbyte)Math.Asin(x._value);
            SByteN IMath<SByteN>.Asinh(SByteN x) => (sbyte)MathCompat.Asinh(x._value);
            SByteN IMath<SByteN>.Atan(SByteN x) => (sbyte)Math.Atan(x._value);
            SByteN IMath<SByteN>.Atan2(SByteN x, SByteN y) => (sbyte)Math.Atan2(x._value, y._value);
            SByteN IMath<SByteN>.Atanh(SByteN x) => (sbyte)MathCompat.Atanh(x._value);
            SByteN IMath<SByteN>.Cbrt(SByteN x) => (sbyte)MathCompat.Cbrt(x._value);
            SByteN IMath<SByteN>.Ceiling(SByteN x) => x;
            SByteN IMath<SByteN>.Clamp(SByteN x, SByteN bound1, SByteN bound2) => bound1 > bound2 ? Math.Min(bound1._value, Math.Max(bound2._value, x._value)) : Math.Min(bound2._value, Math.Max(bound1._value, x._value));
            SByteN IMath<SByteN>.Cos(SByteN x) => (sbyte)Math.Cos(x._value);
            SByteN IMath<SByteN>.Cosh(SByteN x) => (sbyte)Math.Cosh(x._value);
            SByteN IMath<SByteN>.DegreesToRadians(SByteN x) => (sbyte)(x * BitOperations.RadiansPerDegree);
            SByteN IMath<SByteN>.E { get; } = 2;
            SByteN IMath<SByteN>.Exp(SByteN x) => (sbyte)Math.Exp(x._value);
            SByteN IMath<SByteN>.Floor(SByteN x) => x;
            SByteN IMath<SByteN>.IEEERemainder(SByteN x, SByteN y) => (sbyte)Math.IEEERemainder(x._value, y._value);
            SByteN IMath<SByteN>.Log(SByteN x) => (sbyte)Math.Log(x._value);
            SByteN IMath<SByteN>.Log(SByteN x, SByteN y) => (sbyte)Math.Log(x._value, y._value);
            SByteN IMath<SByteN>.Log10(SByteN x) => (sbyte)Math.Log10(x._value);
            SByteN IMath<SByteN>.Max(SByteN x, SByteN y) => Math.Max(x._value, y._value);
            SByteN IMath<SByteN>.Min(SByteN x, SByteN y) => Math.Min(x._value, y._value);
            SByteN IMath<SByteN>.PI { get; } = 3;
            SByteN IMath<SByteN>.Pow(SByteN x, SByteN y) => (sbyte)Math.Pow(x._value, y._value);
            SByteN IMath<SByteN>.RadiansToDegrees(SByteN x) => (sbyte)(x * BitOperations.DegreesPerRadian);
            SByteN IMath<SByteN>.Round(SByteN x) => x;
            SByteN IMath<SByteN>.Round(SByteN x, int digits) => x;
            SByteN IMath<SByteN>.Round(SByteN x, int digits, MidpointRounding mode) => x;
            SByteN IMath<SByteN>.Round(SByteN x, MidpointRounding mode) => x;
            SByteN IMath<SByteN>.Sin(SByteN x) => (sbyte)Math.Sin(x._value);
            SByteN IMath<SByteN>.Sinh(SByteN x) => (sbyte)Math.Sinh(x._value);
            SByteN IMath<SByteN>.Sqrt(SByteN x) => (sbyte)Math.Sqrt(x._value);
            SByteN IMath<SByteN>.Tan(SByteN x) => (sbyte)Math.Tan(x._value);
            SByteN IMath<SByteN>.Tanh(SByteN x) => (sbyte)Math.Tanh(x._value);
            SByteN IMath<SByteN>.Tau { get; } = 6;
            SByteN IMath<SByteN>.Truncate(SByteN x) => x;

            SByteN INumericBitConverter<SByteN>.Read(IReader<byte> stream) => unchecked((sbyte)stream.Read(1)[0]);
            void INumericBitConverter<SByteN>.Write(SByteN value, IWriter<byte> stream) => stream.Write((byte)value._value);

            bool IConvert<SByteN>.ToBoolean(SByteN value) => Convert.ToBoolean(value._value);
            byte IConvert<SByteN>.ToByte(SByteN value, Conversion mode) => ConvertN.ToByte(value._value, mode);
            decimal IConvert<SByteN>.ToDecimal(SByteN value, Conversion mode) => ConvertN.ToDecimal(value._value, mode);
            double IConvert<SByteN>.ToDouble(SByteN value, Conversion mode) => ConvertN.ToDouble(value._value, mode);
            float IConvert<SByteN>.ToSingle(SByteN value, Conversion mode) => ConvertN.ToSingle(value._value, mode);
            int IConvert<SByteN>.ToInt32(SByteN value, Conversion mode) => ConvertN.ToInt32(value._value, mode);
            long IConvert<SByteN>.ToInt64(SByteN value, Conversion mode) => ConvertN.ToInt64(value._value, mode);
            sbyte IConvertExtended<SByteN>.ToSByte(SByteN value, Conversion mode) => ConvertN.ToSByte(value._value, mode);
            short IConvert<SByteN>.ToInt16(SByteN value, Conversion mode) => ConvertN.ToInt16(value._value, mode);
            string IConvert<SByteN>.ToString(SByteN value) => Convert.ToString(value._value);
            uint IConvertExtended<SByteN>.ToUInt32(SByteN value, Conversion mode) => ConvertN.ToUInt32(value._value, mode);
            ulong IConvertExtended<SByteN>.ToUInt64(SByteN value, Conversion mode) => ConvertN.ToUInt64(value._value, mode);
            ushort IConvertExtended<SByteN>.ToUInt16(SByteN value, Conversion mode) => ConvertN.ToUInt16(value._value, mode);

            SByteN IConvert<SByteN>.ToNumeric(bool value) => Convert.ToSByte(value);
            SByteN IConvert<SByteN>.ToNumeric(byte value, Conversion mode) => ConvertN.ToSByte(value, mode);
            SByteN IConvert<SByteN>.ToNumeric(decimal value, Conversion mode) => ConvertN.ToSByte(value, mode);
            SByteN IConvert<SByteN>.ToNumeric(double value, Conversion mode) => ConvertN.ToSByte(value, mode);
            SByteN IConvert<SByteN>.ToNumeric(float value, Conversion mode) => ConvertN.ToSByte(value, mode);
            SByteN IConvert<SByteN>.ToNumeric(int value, Conversion mode) => ConvertN.ToSByte(value, mode);
            SByteN IConvert<SByteN>.ToNumeric(long value, Conversion mode) => ConvertN.ToSByte(value, mode);
            SByteN IConvertExtended<SByteN>.ToValue(sbyte value, Conversion mode) => ConvertN.ToSByte(value, mode);
            SByteN IConvert<SByteN>.ToNumeric(short value, Conversion mode) => ConvertN.ToSByte(value, mode);
            SByteN IConvert<SByteN>.ToNumeric(string value) => Convert.ToSByte(value);
            SByteN IConvertExtended<SByteN>.ToNumeric(uint value, Conversion mode) => ConvertN.ToSByte(value, mode);
            SByteN IConvertExtended<SByteN>.ToNumeric(ulong value, Conversion mode) => ConvertN.ToSByte(value, mode);
            SByteN IConvertExtended<SByteN>.ToNumeric(ushort value, Conversion mode) => ConvertN.ToSByte(value, mode);

            SByteN INumericStatic<SByteN>.Parse(string s, NumberStyles? style, IFormatProvider? provider)
                => Parse(s, style ?? NumberStyles.Integer, provider);

            SByteN INumericRandom<SByteN>.Next(Random random) => random.NextSByte();
            SByteN INumericRandom<SByteN>.Next(Random random, SByteN maxValue) => random.NextSByte(maxValue);
            SByteN INumericRandom<SByteN>.Next(Random random, SByteN minValue, SByteN maxValue) => random.NextSByte(minValue, maxValue);
            SByteN INumericRandom<SByteN>.Next(Random random, Generation mode) => random.NextSByte(mode);
            SByteN INumericRandom<SByteN>.Next(Random random, SByteN minValue, SByteN maxValue, Generation mode) => random.NextSByte(minValue, maxValue, mode);

            SByteN IVariantRandom<SByteN>.Next(Random random, Scenarios scenarios) => NumericVariant.Generate<SByteN>(random, scenarios);
        }
    }
}
