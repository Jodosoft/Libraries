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
    /// Represents a 32-bit signed integer.
    /// </summary>
    [Serializable]
    [DebuggerDisplay("{ToString(),nq}")]
    public readonly struct Int32N : INumericExtended<Int32N>
    {
        /// <inheritdoc cref="int.MaxValue" />
        public static readonly Int32N MaxValue = new Int32N(int.MaxValue);

        /// <inheritdoc cref="int.MinValue" />
        public static readonly Int32N MinValue = new Int32N(int.MinValue);

        private readonly int _value;

        private Int32N(int value)
        {
            _value = value;
        }

        private Int32N(SerializationInfo info, StreamingContext context) : this(info.GetInt32(nameof(Int32N))) { }
        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context) => info.AddValue(nameof(Int32N), _value);

        public int CompareTo(Int32N other) => _value.CompareTo(other._value);
        public int CompareTo(object? obj) => obj is Int32N other ? CompareTo(other) : 1;
        public bool Equals(Int32N other) => _value == other._value;
        public override bool Equals(object? obj) => obj is Int32N other && Equals(other);
        public override int GetHashCode() => _value.GetHashCode();
        public override string ToString() => _value.ToString();
        public string ToString(IFormatProvider formatProvider) => _value.ToString(formatProvider);
        public string ToString(string format) => _value.ToString(format);
        public string ToString(string? format, IFormatProvider? formatProvider) => _value.ToString(format, formatProvider);

        public static bool TryParse(string s, IFormatProvider? provider, out Int32N result) => FuncExtensions.Try(() => Parse(s, provider), out result);
        public static bool TryParse(string s, NumberStyles style, IFormatProvider? provider, out Int32N result) => FuncExtensions.Try(() => Parse(s, style, provider), out result);
        public static bool TryParse(string s, NumberStyles style, out Int32N result) => FuncExtensions.Try(() => Parse(s, style), out result);
        public static bool TryParse(string s, out Int32N result) => FuncExtensions.Try(() => Parse(s), out result);
        public static Int32N Parse(string s) => int.Parse(s);
        public static Int32N Parse(string s, IFormatProvider? provider) => int.Parse(s, provider);
        public static Int32N Parse(string s, NumberStyles style) => int.Parse(s, style);
        public static Int32N Parse(string s, NumberStyles style, IFormatProvider? provider) => int.Parse(s, style, provider);

        [CLSCompliant(false)] public static explicit operator Int32N(uint value) => new Int32N((int)value);
        [CLSCompliant(false)] public static explicit operator Int32N(ulong value) => new Int32N((int)value);
        [CLSCompliant(false)] public static implicit operator Int32N(sbyte value) => new Int32N(value);
        [CLSCompliant(false)] public static implicit operator Int32N(ushort value) => new Int32N(value);
        public static explicit operator Int32N(decimal value) => new Int32N((int)value);
        public static explicit operator Int32N(double value) => new Int32N((int)value);
        public static explicit operator Int32N(float value) => new Int32N((int)value);
        public static explicit operator Int32N(long value) => new Int32N((int)value);
        public static implicit operator Int32N(byte value) => new Int32N(value);
        public static implicit operator Int32N(int value) => new Int32N(value);
        public static implicit operator Int32N(short value) => new Int32N(value);

        [CLSCompliant(false)] public static explicit operator sbyte(Int32N value) => (sbyte)value._value;
        [CLSCompliant(false)] public static explicit operator uint(Int32N value) => (uint)value._value;
        [CLSCompliant(false)] public static explicit operator ulong(Int32N value) => (ulong)value._value;
        [CLSCompliant(false)] public static explicit operator ushort(Int32N value) => (ushort)value._value;
        public static explicit operator byte(Int32N value) => (byte)value._value;
        public static explicit operator short(Int32N value) => (short)value._value;
        public static implicit operator decimal(Int32N value) => value._value;
        public static implicit operator double(Int32N value) => value._value;
        public static implicit operator float(Int32N value) => value._value;
        public static implicit operator int(Int32N value) => value._value;
        public static implicit operator long(Int32N value) => value._value;

        public static bool operator !=(Int32N left, Int32N right) => left._value != right._value;
        public static bool operator <(Int32N left, Int32N right) => left._value < right._value;
        public static bool operator <=(Int32N left, Int32N right) => left._value <= right._value;
        public static bool operator ==(Int32N left, Int32N right) => left._value == right._value;
        public static bool operator >(Int32N left, Int32N right) => left._value > right._value;
        public static bool operator >=(Int32N left, Int32N right) => left._value >= right._value;
        public static Int32N operator %(Int32N left, Int32N right) => left._value % right._value;
        public static Int32N operator &(Int32N left, Int32N right) => left._value & right._value;
        public static Int32N operator -(Int32N left, Int32N right) => left._value - right._value;
        public static Int32N operator --(Int32N value) => value._value - 1;
        public static Int32N operator -(Int32N value) => -value._value;
        public static Int32N operator *(Int32N left, Int32N right) => left._value * right._value;
        public static Int32N operator /(Int32N left, Int32N right) => left._value / right._value;
        public static Int32N operator ^(Int32N left, Int32N right) => left._value ^ right._value;
        public static Int32N operator |(Int32N left, Int32N right) => left._value | right._value;
        public static Int32N operator ~(Int32N value) => ~value._value;
        public static Int32N operator +(Int32N left, Int32N right) => left._value + right._value;
        public static Int32N operator +(Int32N value) => value;
        public static Int32N operator ++(Int32N value) => value._value + 1;
        public static Int32N operator <<(Int32N left, int right) => left._value << right;
        public static Int32N operator >>(Int32N left, int right) => left._value >> right;

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

        bool INumeric<Int32N>.IsGreaterThan(Int32N value) => this > value;
        bool INumeric<Int32N>.IsGreaterThanOrEqualTo(Int32N value) => this >= value;
        bool INumeric<Int32N>.IsLessThan(Int32N value) => this < value;
        bool INumeric<Int32N>.IsLessThanOrEqualTo(Int32N value) => this <= value;
        Int32N INumeric<Int32N>.Add(Int32N value) => this + value;
        Int32N INumeric<Int32N>.BitwiseComplement() => ~this;
        Int32N INumeric<Int32N>.Divide(Int32N value) => this / value;
        Int32N INumeric<Int32N>.LeftShift(int count) => this << count;
        Int32N INumeric<Int32N>.LogicalAnd(Int32N value) => this & value;
        Int32N INumeric<Int32N>.LogicalExclusiveOr(Int32N value) => this ^ value;
        Int32N INumeric<Int32N>.LogicalOr(Int32N value) => this | value;
        Int32N INumeric<Int32N>.Multiply(Int32N value) => this * value;
        Int32N INumeric<Int32N>.Negative() => -this;
        Int32N INumeric<Int32N>.Positive() => +this;
        Int32N INumeric<Int32N>.Remainder(Int32N value) => this % value;
        Int32N INumeric<Int32N>.RightShift(int count) => this >> count;
        Int32N INumeric<Int32N>.Subtract(Int32N value) => this - value;

        INumericBitConverter<Int32N> IProvider<INumericBitConverter<Int32N>>.GetInstance() => Utilities.Instance;
        IBitBuffer<Int32N> IProvider<IBitBuffer<Int32N>>.GetInstance() => Utilities.Instance;
        IConvert<Int32N> IProvider<IConvert<Int32N>>.GetInstance() => Utilities.Instance;
        IConvertExtended<Int32N> IProvider<IConvertExtended<Int32N>>.GetInstance() => Utilities.Instance;
        IMath<Int32N> IProvider<IMath<Int32N>>.GetInstance() => Utilities.Instance;
        INumericRandom<Int32N> IProvider<INumericRandom<Int32N>>.GetInstance() => Utilities.Instance;
        INumericStatic<Int32N> IProvider<INumericStatic<Int32N>>.GetInstance() => Utilities.Instance;
        IVariantRandom<Int32N> IProvider<IVariantRandom<Int32N>>.GetInstance() => Utilities.Instance;

        private sealed class Utilities :
            IBitBuffer<Int32N>,
            IConvert<Int32N>,
            IConvertExtended<Int32N>,
            IMath<Int32N>,
            INumericBitConverter<Int32N>,
            INumericRandom<Int32N>,
            INumericStatic<Int32N>,
            IVariantRandom<Int32N>
        {
            public static readonly Utilities Instance = new Utilities();

            void IBitBuffer<Int32N>.Write(Int32N value, Stream stream) => stream.Write(value._value);
            async Task IBitBuffer<Int32N>.WriteAsync(Int32N value, Stream stream) => await stream.WriteAsync(value._value);
            Int32N IBitBuffer<Int32N>.Read(Stream stream) => stream.ReadInt32();
            async Task<Int32N> IBitBuffer<Int32N>.ReadAsync(Stream stream) => await stream.ReadInt32Async();

            bool INumericStatic<Int32N>.HasFloatingPoint => false;
            bool INumericStatic<Int32N>.HasInfinity => false;
            bool INumericStatic<Int32N>.HasNaN => false;
            bool INumericStatic<Int32N>.IsFinite(Int32N x) => true;
            bool INumericStatic<Int32N>.IsInfinity(Int32N x) => false;
            bool INumericStatic<Int32N>.IsNaN(Int32N x) => false;
            bool INumericStatic<Int32N>.IsNegative(Int32N x) => x._value < 0;
            bool INumericStatic<Int32N>.IsNegativeInfinity(Int32N x) => false;
            bool INumericStatic<Int32N>.IsNormal(Int32N x) => false;
            bool INumericStatic<Int32N>.IsPositiveInfinity(Int32N x) => false;
            bool INumericStatic<Int32N>.IsReal => false;
            bool INumericStatic<Int32N>.IsSigned => true;
            bool INumericStatic<Int32N>.IsSubnormal(Int32N x) => false;
            Int32N INumericStatic<Int32N>.Epsilon => 1;
            Int32N INumericStatic<Int32N>.MaxUnit => 1;
            Int32N INumericStatic<Int32N>.MaxValue => MaxValue;
            Int32N INumericStatic<Int32N>.MinUnit => -1;
            Int32N INumericStatic<Int32N>.MinValue => MinValue;
            Int32N INumericStatic<Int32N>.One => 1;
            Int32N INumericStatic<Int32N>.Zero => 0;

            int IMath<Int32N>.Sign(Int32N x) => Math.Sign(x._value);
            Int32N IMath<Int32N>.Abs(Int32N value) => Math.Abs(value._value);
            Int32N IMath<Int32N>.Acos(Int32N x) => (int)Math.Acos(x._value);
            Int32N IMath<Int32N>.Acosh(Int32N x) => (int)MathShim.Acosh(x._value);
            Int32N IMath<Int32N>.Asin(Int32N x) => (int)Math.Asin(x._value);
            Int32N IMath<Int32N>.Asinh(Int32N x) => (int)MathShim.Asinh(x._value);
            Int32N IMath<Int32N>.Atan(Int32N x) => (int)Math.Atan(x._value);
            Int32N IMath<Int32N>.Atan2(Int32N x, Int32N y) => (int)Math.Atan2(x._value, y._value);
            Int32N IMath<Int32N>.Atanh(Int32N x) => (int)MathShim.Atanh(x._value);
            Int32N IMath<Int32N>.Cbrt(Int32N x) => (int)MathShim.Cbrt(x._value);
            Int32N IMath<Int32N>.Ceiling(Int32N x) => x;
            Int32N IMath<Int32N>.Clamp(Int32N x, Int32N bound1, Int32N bound2) => bound1 > bound2 ? Math.Min(bound1._value, Math.Max(bound2._value, x._value)) : Math.Min(bound2._value, Math.Max(bound1._value, x._value));
            Int32N IMath<Int32N>.Cos(Int32N x) => (int)Math.Cos(x._value);
            Int32N IMath<Int32N>.Cosh(Int32N x) => (int)Math.Cosh(x._value);
            Int32N IMath<Int32N>.E { get; } = 2;
            Int32N IMath<Int32N>.Exp(Int32N x) => (int)Math.Exp(x._value);
            Int32N IMath<Int32N>.Floor(Int32N x) => x;
            Int32N IMath<Int32N>.IEEERemainder(Int32N x, Int32N y) => (int)Math.IEEERemainder(x._value, y._value);
            Int32N IMath<Int32N>.Log(Int32N x) => (int)Math.Log(x._value);
            Int32N IMath<Int32N>.Log(Int32N x, Int32N y) => (int)Math.Log(x._value, y._value);
            Int32N IMath<Int32N>.Log10(Int32N x) => (int)Math.Log10(x._value);
            Int32N IMath<Int32N>.Max(Int32N x, Int32N y) => Math.Max(x._value, y._value);
            Int32N IMath<Int32N>.Min(Int32N x, Int32N y) => Math.Min(x._value, y._value);
            Int32N IMath<Int32N>.PI { get; } = 3;
            Int32N IMath<Int32N>.Pow(Int32N x, Int32N y) => (int)Math.Pow(x._value, y._value);
            Int32N IMath<Int32N>.Round(Int32N x) => x;
            Int32N IMath<Int32N>.Round(Int32N x, int digits) => x;
            Int32N IMath<Int32N>.Round(Int32N x, int digits, MidpointRounding mode) => x;
            Int32N IMath<Int32N>.Round(Int32N x, MidpointRounding mode) => x;
            Int32N IMath<Int32N>.Sin(Int32N x) => (int)Math.Sin(x._value);
            Int32N IMath<Int32N>.Sinh(Int32N x) => (int)Math.Sinh(x._value);
            Int32N IMath<Int32N>.Sqrt(Int32N x) => (int)Math.Sqrt(x._value);
            Int32N IMath<Int32N>.Tan(Int32N x) => (int)Math.Tan(x._value);
            Int32N IMath<Int32N>.Tanh(Int32N x) => (int)Math.Tanh(x._value);
            Int32N IMath<Int32N>.Tau { get; } = 6;
            Int32N IMath<Int32N>.Truncate(Int32N x) => x;

            int INumericBitConverter<Int32N>.ConvertedSize => sizeof(int);
            Int32N INumericBitConverter<Int32N>.ToNumeric(byte[] value, int startIndex) => BitConverter.ToInt32(value, startIndex);
            byte[] INumericBitConverter<Int32N>.GetBytes(Int32N value) => BitConverter.GetBytes(value._value);

            bool IConvert<Int32N>.ToBoolean(Int32N value) => Convert.ToBoolean(value._value);
            byte IConvert<Int32N>.ToByte(Int32N value, Conversion mode) => ConvertN.ToByte(value._value, mode);
            decimal IConvert<Int32N>.ToDecimal(Int32N value, Conversion mode) => ConvertN.ToDecimal(value._value, mode);
            double IConvert<Int32N>.ToDouble(Int32N value, Conversion mode) => ConvertN.ToDouble(value._value, mode);
            float IConvert<Int32N>.ToSingle(Int32N value, Conversion mode) => ConvertN.ToSingle(value._value, mode);
            int IConvert<Int32N>.ToInt32(Int32N value, Conversion mode) => ConvertN.ToInt32(value._value, mode);
            long IConvert<Int32N>.ToInt64(Int32N value, Conversion mode) => ConvertN.ToInt64(value._value, mode);
            sbyte IConvertExtended<Int32N>.ToSByte(Int32N value, Conversion mode) => ConvertN.ToSByte(value._value, mode);
            short IConvert<Int32N>.ToInt16(Int32N value, Conversion mode) => ConvertN.ToInt16(value._value, mode);
            string IConvert<Int32N>.ToString(Int32N value) => Convert.ToString(value._value);
            uint IConvertExtended<Int32N>.ToUInt32(Int32N value, Conversion mode) => ConvertN.ToUInt32(value._value, mode);
            ulong IConvertExtended<Int32N>.ToUInt64(Int32N value, Conversion mode) => ConvertN.ToUInt64(value._value, mode);
            ushort IConvertExtended<Int32N>.ToUInt16(Int32N value, Conversion mode) => ConvertN.ToUInt16(value._value, mode);

            Int32N IConvert<Int32N>.ToNumeric(bool value) => Convert.ToInt32(value);
            Int32N IConvert<Int32N>.ToNumeric(byte value, Conversion mode) => ConvertN.ToInt32(value, mode);
            Int32N IConvert<Int32N>.ToNumeric(decimal value, Conversion mode) => ConvertN.ToInt32(value, mode);
            Int32N IConvert<Int32N>.ToNumeric(double value, Conversion mode) => ConvertN.ToInt32(value, mode);
            Int32N IConvert<Int32N>.ToNumeric(float value, Conversion mode) => ConvertN.ToInt32(value, mode);
            Int32N IConvert<Int32N>.ToNumeric(int value, Conversion mode) => ConvertN.ToInt32(value, mode);
            Int32N IConvert<Int32N>.ToNumeric(long value, Conversion mode) => ConvertN.ToInt32(value, mode);
            Int32N IConvertExtended<Int32N>.ToValue(sbyte value, Conversion mode) => ConvertN.ToInt32(value, mode);
            Int32N IConvert<Int32N>.ToNumeric(short value, Conversion mode) => ConvertN.ToInt32(value, mode);
            Int32N IConvert<Int32N>.ToNumeric(string value) => Convert.ToInt32(value);
            Int32N IConvertExtended<Int32N>.ToNumeric(uint value, Conversion mode) => ConvertN.ToInt32(value, mode);
            Int32N IConvertExtended<Int32N>.ToNumeric(ulong value, Conversion mode) => ConvertN.ToInt32(value, mode);
            Int32N IConvertExtended<Int32N>.ToNumeric(ushort value, Conversion mode) => ConvertN.ToInt32(value, mode);

            Int32N INumericStatic<Int32N>.Parse(string s, NumberStyles? style, IFormatProvider? provider)
                => Parse(s, style ?? NumberStyles.Integer, provider);

            Int32N INumericRandom<Int32N>.Generate(Random random) => random.NextInt32();
            Int32N INumericRandom<Int32N>.Generate(Random random, Int32N maxValue) => random.NextInt32(maxValue);
            Int32N INumericRandom<Int32N>.Generate(Random random, Int32N minValue, Int32N maxValue) => random.NextInt32(minValue, maxValue);
            Int32N INumericRandom<Int32N>.Generate(Random random, Generation mode) => random.NextInt32(mode);
            Int32N INumericRandom<Int32N>.Generate(Random random, Int32N minValue, Int32N maxValue, Generation mode) => random.NextInt32(minValue, maxValue, mode);

            Int32N IVariantRandom<Int32N>.Generate(Random random, Variants variants) => random.NextInt32(variants);
        }
    }
}
