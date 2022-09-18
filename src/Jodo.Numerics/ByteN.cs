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
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using Jodo.Numerics.Internals;
using Jodo.Primitives;
using Jodo.Primitives.Compatibility;

namespace Jodo.Numerics
{
    /// <summary>
    /// Represents an 8-bit unsigned integer.
    /// </summary>
    [Serializable]
    [DebuggerDisplay("{ToString(),nq}")]
    [StructLayout(LayoutKind.Sequential)]
    public readonly struct ByteN : INumericExtended<ByteN>
    {
        public static readonly ByteN MaxValue = new ByteN(byte.MaxValue);
        public static readonly ByteN MinValue = new ByteN(byte.MinValue);

        private readonly byte _value;

        private ByteN(byte value)
        {
            _value = value;
        }

        private ByteN(SerializationInfo info, StreamingContext context) : this(info.GetByte(nameof(ByteN))) { }
        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context) => info.AddValue(nameof(ByteN), _value);

        public int CompareTo(ByteN other) => _value.CompareTo(other._value);
        public int CompareTo(object? obj) => obj is ByteN other ? CompareTo(other) : 1;
        public bool Equals(ByteN other) => _value == other._value;
        public override bool Equals(object? obj) => obj is ByteN other && Equals(other);
        public override int GetHashCode() => _value.GetHashCode();
        public override string ToString() => _value.ToString();
        public string ToString(IFormatProvider formatProvider) => _value.ToString(formatProvider);
        public string ToString(string format) => _value.ToString(format);
        public string ToString(string? format, IFormatProvider? formatProvider) => _value.ToString(format, formatProvider);

        public static bool TryParse(string s, IFormatProvider? provider, out ByteN result) => FuncExtensions.Try(() => Parse(s, provider), out result);
        public static bool TryParse(string s, NumberStyles style, IFormatProvider? provider, out ByteN result) => FuncExtensions.Try(() => Parse(s, style, provider), out result);
        public static bool TryParse(string s, NumberStyles style, out ByteN result) => FuncExtensions.Try(() => Parse(s, style), out result);
        public static bool TryParse(string s, out ByteN result) => FuncExtensions.Try(() => Parse(s), out result);
        public static ByteN Parse(string s) => byte.Parse(s);
        public static ByteN Parse(string s, IFormatProvider? provider) => byte.Parse(s, provider);
        public static ByteN Parse(string s, NumberStyles style) => byte.Parse(s, style);
        public static ByteN Parse(string s, NumberStyles style, IFormatProvider? provider) => byte.Parse(s, style, provider);

        [CLSCompliant(false)] public static explicit operator ByteN(sbyte value) => new ByteN((byte)value);
        [CLSCompliant(false)] public static explicit operator ByteN(uint value) => new ByteN((byte)value);
        [CLSCompliant(false)] public static explicit operator ByteN(ulong value) => new ByteN((byte)value);
        [CLSCompliant(false)] public static explicit operator ByteN(ushort value) => new ByteN((byte)value);
        public static explicit operator ByteN(decimal value) => new ByteN((byte)value);
        public static explicit operator ByteN(double value) => new ByteN((byte)value);
        public static explicit operator ByteN(float value) => new ByteN((byte)value);
        public static explicit operator ByteN(int value) => new ByteN((byte)value);
        public static explicit operator ByteN(long value) => new ByteN((byte)value);
        public static explicit operator ByteN(short value) => new ByteN((byte)value);
        public static implicit operator ByteN(byte value) => new ByteN(value);

        [CLSCompliant(false)] public static explicit operator sbyte(ByteN value) => (sbyte)value._value;
        [CLSCompliant(false)] public static implicit operator uint(ByteN value) => value._value;
        [CLSCompliant(false)] public static implicit operator ulong(ByteN value) => value._value;
        [CLSCompliant(false)] public static implicit operator ushort(ByteN value) => value._value;
        public static implicit operator byte(ByteN value) => value._value;
        public static implicit operator decimal(ByteN value) => value._value;
        public static implicit operator double(ByteN value) => value._value;
        public static implicit operator float(ByteN value) => value._value;
        public static implicit operator int(ByteN value) => value._value;
        public static implicit operator long(ByteN value) => value._value;
        public static implicit operator short(ByteN value) => value._value;

        public static bool operator !=(ByteN left, ByteN right) => left._value != right._value;
        public static bool operator <(ByteN left, ByteN right) => left._value < right._value;
        public static bool operator <=(ByteN left, ByteN right) => left._value <= right._value;
        public static bool operator ==(ByteN left, ByteN right) => left._value == right._value;
        public static bool operator >(ByteN left, ByteN right) => left._value > right._value;
        public static bool operator >=(ByteN left, ByteN right) => left._value >= right._value;
        public static ByteN operator %(ByteN left, ByteN right) => (byte)(left._value % right._value);
        public static ByteN operator &(ByteN left, ByteN right) => (byte)(left._value & right._value);
        public static ByteN operator -(ByteN left, ByteN right) => (byte)(left._value - right._value);
        public static ByteN operator --(ByteN value) => (byte)(value._value - 1);
        public static ByteN operator *(ByteN left, ByteN right) => (byte)(left._value * right._value);
        public static ByteN operator /(ByteN left, ByteN right) => (byte)(left._value / right._value);
        public static ByteN operator ^(ByteN left, ByteN right) => (byte)(left._value ^ right._value);
        public static ByteN operator |(ByteN left, ByteN right) => (byte)(left._value | right._value);
        public static ByteN operator ~(ByteN value) => (byte)~value._value;
        public static ByteN operator +(ByteN left, ByteN right) => (byte)(left._value + right._value);
        public static ByteN operator +(ByteN value) => value;
        public static ByteN operator ++(ByteN value) => (byte)(value._value + 1);
        public static ByteN operator <<(ByteN left, int right) => (byte)(left._value << right);
        public static ByteN operator >>(ByteN left, int right) => (byte)(left._value >> right);

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

        bool INumeric<ByteN>.IsGreaterThan(ByteN value) => this > value;
        bool INumeric<ByteN>.IsGreaterThanOrEqualTo(ByteN value) => this >= value;
        bool INumeric<ByteN>.IsLessThan(ByteN value) => this < value;
        bool INumeric<ByteN>.IsLessThanOrEqualTo(ByteN value) => this <= value;
        ByteN INumeric<ByteN>.Add(ByteN value) => this + value;
        ByteN INumeric<ByteN>.BitwiseComplement() => ~this;
        ByteN INumeric<ByteN>.Divide(ByteN value) => this / value;
        ByteN INumeric<ByteN>.LeftShift(int count) => this << count;
        ByteN INumeric<ByteN>.LogicalAnd(ByteN value) => this & value;
        ByteN INumeric<ByteN>.LogicalExclusiveOr(ByteN value) => this ^ value;
        ByteN INumeric<ByteN>.LogicalOr(ByteN value) => this | value;
        ByteN INumeric<ByteN>.Multiply(ByteN value) => this * value;
        ByteN INumeric<ByteN>.Negative() => (ByteN)(0 - _value);
        ByteN INumeric<ByteN>.Positive() => +this;
        ByteN INumeric<ByteN>.Remainder(ByteN value) => this % value;
        ByteN INumeric<ByteN>.RightShift(int count) => this >> count;
        ByteN INumeric<ByteN>.Subtract(ByteN value) => this - value;

        INumericBitConverter<ByteN> IProvider<INumericBitConverter<ByteN>>.GetInstance() => Utilities.Instance;
        IConvert<ByteN> IProvider<IConvert<ByteN>>.GetInstance() => Utilities.Instance;
        IConvertExtended<ByteN> IProvider<IConvertExtended<ByteN>>.GetInstance() => Utilities.Instance;
        IMath<ByteN> IProvider<IMath<ByteN>>.GetInstance() => Utilities.Instance;
        INumericRandom<ByteN> IProvider<INumericRandom<ByteN>>.GetInstance() => Utilities.Instance;
        INumericStatic<ByteN> IProvider<INumericStatic<ByteN>>.GetInstance() => Utilities.Instance;
        IVariantRandom<ByteN> IProvider<IVariantRandom<ByteN>>.GetInstance() => Utilities.Instance;

        private sealed class Utilities :
            IConvert<ByteN>,
            IConvertExtended<ByteN>,
            IMath<ByteN>,
            INumericBitConverter<ByteN>,
            INumericRandom<ByteN>,
            INumericStatic<ByteN>,
            IVariantRandom<ByteN>
        {
            public static readonly Utilities Instance = new Utilities();

            bool INumericStatic<ByteN>.HasFloatingPoint => false;
            bool INumericStatic<ByteN>.HasInfinity => false;
            bool INumericStatic<ByteN>.HasNaN => false;
            bool INumericStatic<ByteN>.IsFinite(ByteN x) => true;
            bool INumericStatic<ByteN>.IsInfinity(ByteN x) => false;
            bool INumericStatic<ByteN>.IsNaN(ByteN x) => false;
            bool INumericStatic<ByteN>.IsNegative(ByteN x) => false;
            bool INumericStatic<ByteN>.IsNegativeInfinity(ByteN x) => false;
            bool INumericStatic<ByteN>.IsNormal(ByteN x) => false;
            bool INumericStatic<ByteN>.IsPositiveInfinity(ByteN x) => false;
            bool INumericStatic<ByteN>.IsReal => false;
            bool INumericStatic<ByteN>.IsSigned => false;
            bool INumericStatic<ByteN>.IsSubnormal(ByteN x) => false;
            ByteN INumericStatic<ByteN>.Epsilon => 1;
            ByteN INumericStatic<ByteN>.MaxUnit => 1;
            ByteN INumericStatic<ByteN>.MaxValue => MaxValue;
            ByteN INumericStatic<ByteN>.MinUnit => 0;
            ByteN INumericStatic<ByteN>.MinValue => MinValue;
            ByteN INumericStatic<ByteN>.One => 1;
            ByteN INumericStatic<ByteN>.Ten => 10;
            ByteN INumericStatic<ByteN>.Two => 2;
            ByteN INumericStatic<ByteN>.Zero => 0;

            int IMath<ByteN>.Sign(ByteN x) => x._value == 0 ? 0 : 1;
            ByteN IMath<ByteN>.Abs(ByteN value) => value._value;
            ByteN IMath<ByteN>.Acos(ByteN x) => (byte)Math.Acos(x._value);
            ByteN IMath<ByteN>.Acosh(ByteN x) => (byte)MathShim.Acosh(x._value);
            ByteN IMath<ByteN>.Asin(ByteN x) => (byte)Math.Asin(x._value);
            ByteN IMath<ByteN>.Asinh(ByteN x) => (byte)MathShim.Asinh(x._value);
            ByteN IMath<ByteN>.Atan(ByteN x) => (byte)Math.Atan(x._value);
            ByteN IMath<ByteN>.Atan2(ByteN x, ByteN y) => (byte)Math.Atan2(x._value, y._value);
            ByteN IMath<ByteN>.Atanh(ByteN x) => (byte)MathShim.Atanh(x._value);
            ByteN IMath<ByteN>.Cbrt(ByteN x) => (byte)MathShim.Cbrt(x._value);
            ByteN IMath<ByteN>.Ceiling(ByteN x) => x;
            ByteN IMath<ByteN>.Clamp(ByteN x, ByteN bound1, ByteN bound2) => bound1 > bound2 ? Math.Min(bound1._value, Math.Max(bound2._value, x._value)) : Math.Min(bound2._value, Math.Max(bound1._value, x._value));
            ByteN IMath<ByteN>.Cos(ByteN x) => (byte)Math.Cos(x._value);
            ByteN IMath<ByteN>.Cosh(ByteN x) => (byte)Math.Cosh(x._value);
            ByteN IMath<ByteN>.E { get; } = 2;
            ByteN IMath<ByteN>.Exp(ByteN x) => (byte)Math.Exp(x._value);
            ByteN IMath<ByteN>.Floor(ByteN x) => x;
            ByteN IMath<ByteN>.IEEERemainder(ByteN x, ByteN y) => (byte)Math.IEEERemainder(x._value, y._value);
            ByteN IMath<ByteN>.Log(ByteN x) => (byte)Math.Log(x._value);
            ByteN IMath<ByteN>.Log(ByteN x, ByteN y) => (byte)Math.Log(x._value, y._value);
            ByteN IMath<ByteN>.Log10(ByteN x) => (byte)Math.Log10(x._value);
            ByteN IMath<ByteN>.Max(ByteN x, ByteN y) => Math.Max(x._value, y._value);
            ByteN IMath<ByteN>.Min(ByteN x, ByteN y) => Math.Min(x._value, y._value);
            ByteN IMath<ByteN>.PI { get; } = 3;
            ByteN IMath<ByteN>.Pow(ByteN x, ByteN y) => (byte)Math.Pow(x._value, y._value);
            ByteN IMath<ByteN>.Round(ByteN x) => x;
            ByteN IMath<ByteN>.Round(ByteN x, int digits) => x;
            ByteN IMath<ByteN>.Round(ByteN x, int digits, MidpointRounding mode) => x;
            ByteN IMath<ByteN>.Round(ByteN x, MidpointRounding mode) => x;
            ByteN IMath<ByteN>.Sin(ByteN x) => (byte)Math.Sin(x._value);
            ByteN IMath<ByteN>.Sinh(ByteN x) => (byte)Math.Sinh(x._value);
            ByteN IMath<ByteN>.Sqrt(ByteN x) => (byte)Math.Sqrt(x._value);
            ByteN IMath<ByteN>.Tan(ByteN x) => (byte)Math.Tan(x._value);
            ByteN IMath<ByteN>.Tanh(ByteN x) => (byte)Math.Tanh(x._value);
            ByteN IMath<ByteN>.Tau { get; } = 6;
            ByteN IMath<ByteN>.Truncate(ByteN x) => x;

            int INumericBitConverter<ByteN>.ConvertedSize => sizeof(byte);
            ByteN INumericBitConverter<ByteN>.ToNumeric(byte[] value, int startIndex) => BitOperations.ToByte(value, startIndex);
            byte[] INumericBitConverter<ByteN>.GetBytes(ByteN value) => new byte[] { value._value };

            bool IConvert<ByteN>.ToBoolean(ByteN value) => Convert.ToBoolean(value._value);
            byte IConvert<ByteN>.ToByte(ByteN value, Conversion mode) => ConvertN.ToByte(value._value, mode);
            decimal IConvert<ByteN>.ToDecimal(ByteN value, Conversion mode) => ConvertN.ToDecimal(value._value, mode);
            double IConvert<ByteN>.ToDouble(ByteN value, Conversion mode) => ConvertN.ToDouble(value._value, mode);
            float IConvert<ByteN>.ToSingle(ByteN value, Conversion mode) => ConvertN.ToSingle(value._value, mode);
            int IConvert<ByteN>.ToInt32(ByteN value, Conversion mode) => ConvertN.ToInt32(value._value, mode);
            long IConvert<ByteN>.ToInt64(ByteN value, Conversion mode) => ConvertN.ToInt64(value._value, mode);
            sbyte IConvertExtended<ByteN>.ToSByte(ByteN value, Conversion mode) => ConvertN.ToSByte(value._value, mode);
            short IConvert<ByteN>.ToInt16(ByteN value, Conversion mode) => ConvertN.ToInt16(value._value, mode);
            string IConvert<ByteN>.ToString(ByteN value) => Convert.ToString(value._value);
            uint IConvertExtended<ByteN>.ToUInt32(ByteN value, Conversion mode) => ConvertN.ToUInt32(value._value, mode);
            ulong IConvertExtended<ByteN>.ToUInt64(ByteN value, Conversion mode) => ConvertN.ToUInt64(value._value, mode);
            ushort IConvertExtended<ByteN>.ToUInt16(ByteN value, Conversion mode) => ConvertN.ToUInt16(value._value, mode);

            ByteN IConvert<ByteN>.ToNumeric(bool value) => Convert.ToByte(value);
            ByteN IConvert<ByteN>.ToNumeric(byte value, Conversion mode) => ConvertN.ToByte(value, mode);
            ByteN IConvert<ByteN>.ToNumeric(decimal value, Conversion mode) => ConvertN.ToByte(value, mode);
            ByteN IConvert<ByteN>.ToNumeric(double value, Conversion mode) => ConvertN.ToByte(value, mode);
            ByteN IConvert<ByteN>.ToNumeric(float value, Conversion mode) => ConvertN.ToByte(value, mode);
            ByteN IConvert<ByteN>.ToNumeric(int value, Conversion mode) => ConvertN.ToByte(value, mode);
            ByteN IConvert<ByteN>.ToNumeric(long value, Conversion mode) => ConvertN.ToByte(value, mode);
            ByteN IConvertExtended<ByteN>.ToValue(sbyte value, Conversion mode) => ConvertN.ToByte(value, mode);
            ByteN IConvert<ByteN>.ToNumeric(short value, Conversion mode) => ConvertN.ToByte(value, mode);
            ByteN IConvert<ByteN>.ToNumeric(string value) => Convert.ToByte(value);
            ByteN IConvertExtended<ByteN>.ToNumeric(uint value, Conversion mode) => ConvertN.ToByte(value, mode);
            ByteN IConvertExtended<ByteN>.ToNumeric(ulong value, Conversion mode) => ConvertN.ToByte(value, mode);
            ByteN IConvertExtended<ByteN>.ToNumeric(ushort value, Conversion mode) => ConvertN.ToByte(value, mode);

            ByteN INumericStatic<ByteN>.Parse(string s, NumberStyles? style, IFormatProvider? provider)
                => Parse(s, style ?? NumberStyles.Integer, provider);

            ByteN INumericRandom<ByteN>.Generate(Random random) => random.NextByte();
            ByteN INumericRandom<ByteN>.Generate(Random random, ByteN maxValue) => random.NextByte(maxValue);
            ByteN INumericRandom<ByteN>.Generate(Random random, ByteN minValue, ByteN maxValue) => random.NextByte(minValue, maxValue);
            ByteN INumericRandom<ByteN>.Generate(Random random, Generation mode) => random.NextByte(mode);
            ByteN INumericRandom<ByteN>.Generate(Random random, ByteN minValue, ByteN maxValue, Generation mode) => random.NextByte(minValue, maxValue, mode);

            ByteN IVariantRandom<ByteN>.Generate(Random random, Variants scenarios) => NumericVariant.Generate<ByteN>(random, scenarios);
        }
    }
}
