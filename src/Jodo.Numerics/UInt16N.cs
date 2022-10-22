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

namespace Jodo.Numerics
{
    /// <summary>
    /// Represents a 16-bit unsigned integer.
    /// </summary>
    [Serializable]
    [DebuggerDisplay("{ToString(),nq}")]
    public readonly struct UInt16N : INumericExtended<UInt16N>
    {
        public static readonly UInt16N MaxValue = new UInt16N(ushort.MaxValue);
        public static readonly UInt16N MinValue = new UInt16N(ushort.MinValue);

        private readonly ushort _value;

        private UInt16N(ushort value)
        {
            _value = value;
        }

        private UInt16N(SerializationInfo info, StreamingContext context) : this(info.GetUInt16(nameof(UInt16N))) { }
        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context) => info.AddValue(nameof(UInt16N), _value);

        public int CompareTo(UInt16N other) => _value.CompareTo(other._value);
        public int CompareTo(object? obj) => obj is UInt16N other ? CompareTo(other) : 1;
        public bool Equals(UInt16N other) => _value == other._value;
        public override bool Equals(object? obj) => obj is UInt16N other && Equals(other);
        public override int GetHashCode() => _value.GetHashCode();
        public override string ToString() => _value.ToString();
        public string ToString(IFormatProvider formatProvider) => _value.ToString(formatProvider);
        public string ToString(string format) => _value.ToString(format);
        public string ToString(string? format, IFormatProvider? formatProvider) => _value.ToString(format, formatProvider);

        public static bool TryParse(string s, IFormatProvider? provider, out UInt16N result) => FuncExtensions.Try(() => Parse(s, provider), out result);
        public static bool TryParse(string s, NumberStyles style, IFormatProvider? provider, out UInt16N result) => FuncExtensions.Try(() => Parse(s, style, provider), out result);
        public static bool TryParse(string s, NumberStyles style, out UInt16N result) => FuncExtensions.Try(() => Parse(s, style), out result);
        public static bool TryParse(string s, out UInt16N result) => FuncExtensions.Try(() => Parse(s), out result);
        public static UInt16N Parse(string s) => ushort.Parse(s);
        public static UInt16N Parse(string s, IFormatProvider? provider) => ushort.Parse(s, provider);
        public static UInt16N Parse(string s, NumberStyles style) => ushort.Parse(s, style);
        public static UInt16N Parse(string s, NumberStyles style, IFormatProvider? provider) => ushort.Parse(s, style, provider);

        [CLSCompliant(false)] public static explicit operator UInt16N(sbyte value) => new UInt16N((ushort)value);
        [CLSCompliant(false)] public static explicit operator UInt16N(uint value) => new UInt16N((ushort)value);
        [CLSCompliant(false)] public static explicit operator UInt16N(ulong value) => new UInt16N((ushort)value);
        [CLSCompliant(false)] public static implicit operator UInt16N(ushort value) => new UInt16N(value);
        public static explicit operator UInt16N(decimal value) => new UInt16N((ushort)value);
        public static explicit operator UInt16N(double value) => new UInt16N((ushort)value);
        public static explicit operator UInt16N(float value) => new UInt16N((ushort)value);
        public static explicit operator UInt16N(int value) => new UInt16N((ushort)value);
        public static explicit operator UInt16N(long value) => new UInt16N((ushort)value);
        public static explicit operator UInt16N(short value) => new UInt16N((ushort)value);
        public static implicit operator UInt16N(byte value) => new UInt16N(value);

        [CLSCompliant(false)] public static explicit operator sbyte(UInt16N value) => (sbyte)value._value;
        [CLSCompliant(false)] public static implicit operator uint(UInt16N value) => value._value;
        [CLSCompliant(false)] public static implicit operator ulong(UInt16N value) => value._value;
        [CLSCompliant(false)] public static implicit operator ushort(UInt16N value) => value._value;
        public static explicit operator byte(UInt16N value) => (byte)value._value;
        public static explicit operator short(UInt16N value) => (short)value._value;
        public static implicit operator decimal(UInt16N value) => value._value;
        public static implicit operator double(UInt16N value) => value._value;
        public static implicit operator float(UInt16N value) => value._value;
        public static implicit operator int(UInt16N value) => value._value;
        public static implicit operator long(UInt16N value) => value._value;

        public static bool operator !=(UInt16N left, UInt16N right) => left._value != right._value;
        public static bool operator <(UInt16N left, UInt16N right) => left._value < right._value;
        public static bool operator <=(UInt16N left, UInt16N right) => left._value <= right._value;
        public static bool operator ==(UInt16N left, UInt16N right) => left._value == right._value;
        public static bool operator >(UInt16N left, UInt16N right) => left._value > right._value;
        public static bool operator >=(UInt16N left, UInt16N right) => left._value >= right._value;
        public static UInt16N operator %(UInt16N left, UInt16N right) => (ushort)(left._value % right._value);
        public static UInt16N operator &(UInt16N left, UInt16N right) => (ushort)(left._value & right._value);
        public static UInt16N operator -(UInt16N left, UInt16N right) => (ushort)(left._value - right._value);
        public static UInt16N operator --(UInt16N value) => (ushort)(value._value - 1);
        public static UInt16N operator *(UInt16N left, UInt16N right) => (ushort)(left._value * right._value);
        public static UInt16N operator /(UInt16N left, UInt16N right) => (ushort)(left._value / right._value);
        public static UInt16N operator ^(UInt16N left, UInt16N right) => (ushort)(left._value ^ right._value);
        public static UInt16N operator |(UInt16N left, UInt16N right) => (ushort)(left._value | right._value);
        public static UInt16N operator ~(UInt16N value) => (ushort)~value._value;
        public static UInt16N operator +(UInt16N left, UInt16N right) => (ushort)(left._value + right._value);
        public static UInt16N operator +(UInt16N value) => value;
        public static UInt16N operator ++(UInt16N value) => (ushort)(value._value + 1);
        public static UInt16N operator <<(UInt16N left, int right) => (ushort)(left._value << right);
        public static UInt16N operator >>(UInt16N left, int right) => (ushort)(left._value >> right);

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

        bool INumeric<UInt16N>.IsGreaterThan(UInt16N value) => this > value;
        bool INumeric<UInt16N>.IsGreaterThanOrEqualTo(UInt16N value) => this >= value;
        bool INumeric<UInt16N>.IsLessThan(UInt16N value) => this < value;
        bool INumeric<UInt16N>.IsLessThanOrEqualTo(UInt16N value) => this <= value;
        UInt16N INumeric<UInt16N>.Add(UInt16N value) => this + value;
        UInt16N INumeric<UInt16N>.BitwiseComplement() => ~this;
        UInt16N INumeric<UInt16N>.Divide(UInt16N value) => this / value;
        UInt16N INumeric<UInt16N>.LeftShift(int count) => this << count;
        UInt16N INumeric<UInt16N>.LogicalAnd(UInt16N value) => this & value;
        UInt16N INumeric<UInt16N>.LogicalExclusiveOr(UInt16N value) => this ^ value;
        UInt16N INumeric<UInt16N>.LogicalOr(UInt16N value) => this | value;
        UInt16N INumeric<UInt16N>.Multiply(UInt16N value) => this * value;
        UInt16N INumeric<UInt16N>.Negative() => (UInt16N)(0 - _value);
        UInt16N INumeric<UInt16N>.Positive() => +this;
        UInt16N INumeric<UInt16N>.Remainder(UInt16N value) => this % value;
        UInt16N INumeric<UInt16N>.RightShift(int count) => this >> count;
        UInt16N INumeric<UInt16N>.Subtract(UInt16N value) => this - value;

        INumericBitConverter<UInt16N> IProvider<INumericBitConverter<UInt16N>>.GetInstance() => Utilities.Instance;
        IBitBuffer<UInt16N> IProvider<IBitBuffer<UInt16N>>.GetInstance() => Utilities.Instance;
        IConvert<UInt16N> IProvider<IConvert<UInt16N>>.GetInstance() => Utilities.Instance;
        IConvertExtended<UInt16N> IProvider<IConvertExtended<UInt16N>>.GetInstance() => Utilities.Instance;
        IMath<UInt16N> IProvider<IMath<UInt16N>>.GetInstance() => Utilities.Instance;
        INumericStatic<UInt16N> IProvider<INumericStatic<UInt16N>>.GetInstance() => Utilities.Instance;
        INumericRandom<UInt16N> IProvider<INumericRandom<UInt16N>>.GetInstance() => Utilities.Instance;
        IVariantRandom<UInt16N> IProvider<IVariantRandom<UInt16N>>.GetInstance() => Utilities.Instance;

        private sealed class Utilities :
            IBitBuffer<UInt16N>,
            IConvert<UInt16N>,
            IConvertExtended<UInt16N>,
            IMath<UInt16N>,
            INumericBitConverter<UInt16N>,
            INumericRandom<UInt16N>,
            INumericStatic<UInt16N>,
            IVariantRandom<UInt16N>
        {
            public static readonly Utilities Instance = new Utilities();

            void IBitBuffer<UInt16N>.Write(UInt16N value, Stream stream) => stream.Write(value._value);
            async Task IBitBuffer<UInt16N>.WriteAsync(UInt16N value, Stream stream) => await stream.WriteAsync(value._value);
            UInt16N IBitBuffer<UInt16N>.Read(Stream stream) => stream.ReadUInt16();
            async Task<UInt16N> IBitBuffer<UInt16N>.ReadAsync(Stream stream) => await stream.ReadUInt16Async();

            bool INumericStatic<UInt16N>.HasFloatingPoint => false;
            bool INumericStatic<UInt16N>.HasInfinity => false;
            bool INumericStatic<UInt16N>.HasNaN => false;
            bool INumericStatic<UInt16N>.IsFinite(UInt16N x) => true;
            bool INumericStatic<UInt16N>.IsInfinity(UInt16N x) => false;
            bool INumericStatic<UInt16N>.IsNaN(UInt16N x) => false;
            bool INumericStatic<UInt16N>.IsNegative(UInt16N x) => false;
            bool INumericStatic<UInt16N>.IsNegativeInfinity(UInt16N x) => false;
            bool INumericStatic<UInt16N>.IsNormal(UInt16N x) => false;
            bool INumericStatic<UInt16N>.IsPositiveInfinity(UInt16N x) => false;
            bool INumericStatic<UInt16N>.IsReal => false;
            bool INumericStatic<UInt16N>.IsSigned => false;
            bool INumericStatic<UInt16N>.IsSubnormal(UInt16N x) => false;
            UInt16N INumericStatic<UInt16N>.Epsilon => (ushort)1;
            UInt16N INumericStatic<UInt16N>.MaxUnit => (ushort)1;
            UInt16N INumericStatic<UInt16N>.MaxValue => MaxValue;
            UInt16N INumericStatic<UInt16N>.MinUnit => (ushort)0;
            UInt16N INumericStatic<UInt16N>.MinValue => MinValue;
            UInt16N INumericStatic<UInt16N>.One => (ushort)1;
            UInt16N INumericStatic<UInt16N>.Zero => (ushort)0;

            int IMath<UInt16N>.Sign(UInt16N x) => x._value == 0 ? 0 : 1;
            UInt16N IMath<UInt16N>.Abs(UInt16N value) => value._value;
            UInt16N IMath<UInt16N>.Acos(UInt16N x) => (ushort)Math.Acos(x._value);
            UInt16N IMath<UInt16N>.Acosh(UInt16N x) => (ushort)MathShim.Acosh(x._value);
            UInt16N IMath<UInt16N>.Asin(UInt16N x) => (ushort)Math.Asin(x._value);
            UInt16N IMath<UInt16N>.Asinh(UInt16N x) => (ushort)MathShim.Asinh(x._value);
            UInt16N IMath<UInt16N>.Atan(UInt16N x) => (ushort)Math.Atan(x._value);
            UInt16N IMath<UInt16N>.Atan2(UInt16N x, UInt16N y) => (ushort)Math.Atan2(x._value, y._value);
            UInt16N IMath<UInt16N>.Atanh(UInt16N x) => (ushort)MathShim.Atanh(x._value);
            UInt16N IMath<UInt16N>.Cbrt(UInt16N x) => (ushort)MathShim.Cbrt(x._value);
            UInt16N IMath<UInt16N>.Ceiling(UInt16N x) => x;
            UInt16N IMath<UInt16N>.Clamp(UInt16N x, UInt16N bound1, UInt16N bound2) => bound1 > bound2 ? Math.Min(bound1._value, Math.Max(bound2._value, x._value)) : Math.Min(bound2._value, Math.Max(bound1._value, x._value));
            UInt16N IMath<UInt16N>.Cos(UInt16N x) => (ushort)Math.Cos(x._value);
            UInt16N IMath<UInt16N>.Cosh(UInt16N x) => (ushort)Math.Cosh(x._value);
            UInt16N IMath<UInt16N>.E { get; } = (ushort)2;
            UInt16N IMath<UInt16N>.Exp(UInt16N x) => (ushort)Math.Exp(x._value);
            UInt16N IMath<UInt16N>.Floor(UInt16N x) => x;
            UInt16N IMath<UInt16N>.IEEERemainder(UInt16N x, UInt16N y) => (ushort)Math.IEEERemainder(x._value, y._value);
            UInt16N IMath<UInt16N>.Log(UInt16N x) => (ushort)Math.Log(x._value);
            UInt16N IMath<UInt16N>.Log(UInt16N x, UInt16N y) => (ushort)Math.Log(x._value, y._value);
            UInt16N IMath<UInt16N>.Log10(UInt16N x) => (ushort)Math.Log10(x._value);
            UInt16N IMath<UInt16N>.Max(UInt16N x, UInt16N y) => Math.Max(x._value, y._value);
            UInt16N IMath<UInt16N>.Min(UInt16N x, UInt16N y) => Math.Min(x._value, y._value);
            UInt16N IMath<UInt16N>.PI { get; } = (ushort)3;
            UInt16N IMath<UInt16N>.Pow(UInt16N x, UInt16N y) => (ushort)Math.Pow(x._value, y._value);
            UInt16N IMath<UInt16N>.Round(UInt16N x) => x;
            UInt16N IMath<UInt16N>.Round(UInt16N x, int digits) => x;
            UInt16N IMath<UInt16N>.Round(UInt16N x, int digits, MidpointRounding mode) => x;
            UInt16N IMath<UInt16N>.Round(UInt16N x, MidpointRounding mode) => x;
            UInt16N IMath<UInt16N>.Sin(UInt16N x) => (ushort)Math.Sin(x._value);
            UInt16N IMath<UInt16N>.Sinh(UInt16N x) => (ushort)Math.Sinh(x._value);
            UInt16N IMath<UInt16N>.Sqrt(UInt16N x) => (ushort)Math.Sqrt(x._value);
            UInt16N IMath<UInt16N>.Tan(UInt16N x) => (ushort)Math.Tan(x._value);
            UInt16N IMath<UInt16N>.Tanh(UInt16N x) => (ushort)Math.Tanh(x._value);
            UInt16N IMath<UInt16N>.Tau { get; } = (ushort)6;
            UInt16N IMath<UInt16N>.Truncate(UInt16N x) => x;

            int INumericBitConverter<UInt16N>.ConvertedSize => sizeof(ushort);
            UInt16N INumericBitConverter<UInt16N>.ToNumeric(byte[] value, int startIndex) => BitConverter.ToUInt16(value, startIndex);
            byte[] INumericBitConverter<UInt16N>.GetBytes(UInt16N value) => BitConverter.GetBytes(value._value);

            bool IConvert<UInt16N>.ToBoolean(UInt16N value) => Convert.ToBoolean(value._value);
            byte IConvert<UInt16N>.ToByte(UInt16N value, Conversion mode) => ConvertN.ToByte(value._value, mode);
            decimal IConvert<UInt16N>.ToDecimal(UInt16N value, Conversion mode) => ConvertN.ToDecimal(value._value, mode);
            double IConvert<UInt16N>.ToDouble(UInt16N value, Conversion mode) => ConvertN.ToDouble(value._value, mode);
            float IConvert<UInt16N>.ToSingle(UInt16N value, Conversion mode) => ConvertN.ToSingle(value._value, mode);
            int IConvert<UInt16N>.ToInt32(UInt16N value, Conversion mode) => ConvertN.ToInt32(value._value, mode);
            long IConvert<UInt16N>.ToInt64(UInt16N value, Conversion mode) => ConvertN.ToInt64(value._value, mode);
            sbyte IConvertExtended<UInt16N>.ToSByte(UInt16N value, Conversion mode) => ConvertN.ToSByte(value._value, mode);
            short IConvert<UInt16N>.ToInt16(UInt16N value, Conversion mode) => ConvertN.ToInt16(value._value, mode);
            string IConvert<UInt16N>.ToString(UInt16N value) => Convert.ToString(value._value);
            uint IConvertExtended<UInt16N>.ToUInt32(UInt16N value, Conversion mode) => ConvertN.ToUInt32(value._value, mode);
            ulong IConvertExtended<UInt16N>.ToUInt64(UInt16N value, Conversion mode) => ConvertN.ToUInt64(value._value, mode);
            ushort IConvertExtended<UInt16N>.ToUInt16(UInt16N value, Conversion mode) => value._value;

            UInt16N IConvert<UInt16N>.ToNumeric(bool value) => Convert.ToUInt16(value);
            UInt16N IConvert<UInt16N>.ToNumeric(byte value, Conversion mode) => ConvertN.ToUInt16(value, mode);
            UInt16N IConvert<UInt16N>.ToNumeric(decimal value, Conversion mode) => ConvertN.ToUInt16(value, mode);
            UInt16N IConvert<UInt16N>.ToNumeric(double value, Conversion mode) => ConvertN.ToUInt16(value, mode);
            UInt16N IConvert<UInt16N>.ToNumeric(float value, Conversion mode) => ConvertN.ToUInt16(value, mode);
            UInt16N IConvert<UInt16N>.ToNumeric(int value, Conversion mode) => ConvertN.ToUInt16(value, mode);
            UInt16N IConvert<UInt16N>.ToNumeric(long value, Conversion mode) => ConvertN.ToUInt16(value, mode);
            UInt16N IConvertExtended<UInt16N>.ToValue(sbyte value, Conversion mode) => ConvertN.ToUInt16(value, mode);
            UInt16N IConvert<UInt16N>.ToNumeric(short value, Conversion mode) => ConvertN.ToUInt16(value, mode);
            UInt16N IConvert<UInt16N>.ToNumeric(string value) => Convert.ToUInt16(value);
            UInt16N IConvertExtended<UInt16N>.ToNumeric(uint value, Conversion mode) => ConvertN.ToUInt16(value, mode);
            UInt16N IConvertExtended<UInt16N>.ToNumeric(ulong value, Conversion mode) => ConvertN.ToUInt16(value, mode);
            UInt16N IConvertExtended<UInt16N>.ToNumeric(ushort value, Conversion mode) => value;

            UInt16N INumericStatic<UInt16N>.Parse(string s, NumberStyles? style, IFormatProvider? provider)
                => Parse(s, style ?? NumberStyles.Integer, provider);

            UInt16N INumericRandom<UInt16N>.Generate(Random random) => random.NextUInt16();
            UInt16N INumericRandom<UInt16N>.Generate(Random random, UInt16N maxValue) => random.NextUInt16(maxValue);
            UInt16N INumericRandom<UInt16N>.Generate(Random random, UInt16N minValue, UInt16N maxValue) => random.NextUInt16(minValue, maxValue);
            UInt16N INumericRandom<UInt16N>.Generate(Random random, Generation mode) => random.NextUInt16(mode);
            UInt16N INumericRandom<UInt16N>.Generate(Random random, UInt16N minValue, UInt16N maxValue, Generation mode) => random.NextUInt16(minValue, maxValue, mode);

            UInt16N IVariantRandom<UInt16N>.Generate(Random random, Variants variants) => random.NextUInt16(variants);
        }
    }
}
