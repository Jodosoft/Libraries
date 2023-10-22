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
    /// Represents an 8-bit signed integer.
    /// </summary>
    [Serializable]
    [DebuggerDisplay("{ToString(),nq}")]
    public readonly struct NSByte : INumericExtended<NSByte>
    {
        public static readonly NSByte MaxValue = new NSByte(sbyte.MaxValue);
        public static readonly NSByte MinValue = new NSByte(sbyte.MinValue);

        private readonly sbyte _value;

        private NSByte(sbyte value)
        {
            _value = value;
        }

        private NSByte(SerializationInfo info, StreamingContext context) : this(info.GetSByte(nameof(NSByte))) { }
        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context) => info.AddValue(nameof(NSByte), _value);

        public int CompareTo(NSByte other) => _value.CompareTo(other._value);
        public int CompareTo(object? obj) => obj is NSByte other ? CompareTo(other) : 1;
        public bool Equals(NSByte other) => _value == other._value;
        public override bool Equals(object? obj) => obj is NSByte other && Equals(other);
        public override int GetHashCode() => _value.GetHashCode();
        public override string ToString() => _value.ToString();
        public string ToString(IFormatProvider? provider) => _value.ToString(provider);
        public string ToString(string format) => _value.ToString(format);
        public string ToString(string? format, IFormatProvider? formatProvider) => _value.ToString(format, formatProvider);

        public static bool TryParse(string s, IFormatProvider? provider, out NSByte result) => FuncExtensions.Try(() => Parse(s, provider), out result);
        public static bool TryParse(string s, NumberStyles style, IFormatProvider? provider, out NSByte result) => FuncExtensions.Try(() => Parse(s, style, provider), out result);
        public static bool TryParse(string s, NumberStyles style, out NSByte result) => FuncExtensions.Try(() => Parse(s, style), out result);
        public static bool TryParse(string s, out NSByte result) => FuncExtensions.Try(() => Parse(s), out result);
        public static NSByte Parse(string s) => sbyte.Parse(s);
        public static NSByte Parse(string s, IFormatProvider? provider) => sbyte.Parse(s, provider);
        public static NSByte Parse(string s, NumberStyles style) => sbyte.Parse(s, style);
        public static NSByte Parse(string s, NumberStyles style, IFormatProvider? provider) => sbyte.Parse(s, style, provider);

        [CLSCompliant(false)] public static explicit operator NSByte(uint value) => new NSByte((sbyte)value);
        [CLSCompliant(false)] public static explicit operator NSByte(ulong value) => new NSByte((sbyte)value);
        [CLSCompliant(false)] public static explicit operator NSByte(ushort value) => new NSByte((sbyte)value);
        [CLSCompliant(false)] public static implicit operator NSByte(sbyte value) => new NSByte(value);
        public static explicit operator NSByte(byte value) => new NSByte((sbyte)value);
        public static explicit operator NSByte(decimal value) => new NSByte((sbyte)value);
        public static explicit operator NSByte(double value) => new NSByte((sbyte)value);
        public static explicit operator NSByte(float value) => new NSByte((sbyte)value);
        public static explicit operator NSByte(int value) => new NSByte((sbyte)value);
        public static explicit operator NSByte(long value) => new NSByte((sbyte)value);
        public static explicit operator NSByte(short value) => new NSByte((sbyte)value);

        [CLSCompliant(false)] public static explicit operator uint(NSByte value) => (uint)value._value;
        [CLSCompliant(false)] public static explicit operator ulong(NSByte value) => (ulong)value._value;
        [CLSCompliant(false)] public static explicit operator ushort(NSByte value) => (ushort)value._value;
        [CLSCompliant(false)] public static implicit operator sbyte(NSByte value) => value._value;
        public static explicit operator byte(NSByte value) => (byte)value._value;
        public static implicit operator decimal(NSByte value) => value._value;
        public static implicit operator double(NSByte value) => value._value;
        public static implicit operator float(NSByte value) => value._value;
        public static implicit operator int(NSByte value) => value._value;
        public static implicit operator long(NSByte value) => value._value;
        public static implicit operator short(NSByte value) => value._value;

        public static bool operator !=(NSByte left, NSByte right) => left._value != right._value;
        public static bool operator <(NSByte left, NSByte right) => left._value < right._value;
        public static bool operator <=(NSByte left, NSByte right) => left._value <= right._value;
        public static bool operator ==(NSByte left, NSByte right) => left._value == right._value;
        public static bool operator >(NSByte left, NSByte right) => left._value > right._value;
        public static bool operator >=(NSByte left, NSByte right) => left._value >= right._value;
        public static NSByte operator %(NSByte left, NSByte right) => (sbyte)(left._value % right._value);
        public static NSByte operator &(NSByte left, NSByte right) => (sbyte)(left._value & right._value);
        public static NSByte operator -(NSByte left, NSByte right) => (sbyte)(left._value - right._value);
        public static NSByte operator --(NSByte value) => (sbyte)(value._value - 1);
        public static NSByte operator -(NSByte value) => (sbyte)-value._value;
        public static NSByte operator *(NSByte left, NSByte right) => (sbyte)(left._value * right._value);
        public static NSByte operator /(NSByte left, NSByte right) => (sbyte)(left._value / right._value);
        public static NSByte operator ^(NSByte left, NSByte right) => (sbyte)(left._value ^ right._value);
        public static NSByte operator |(NSByte left, NSByte right) => (sbyte)(left._value | right._value);
        public static NSByte operator ~(NSByte value) => (sbyte)~value._value;
        public static NSByte operator +(NSByte left, NSByte right) => (sbyte)(left._value + right._value);
        public static NSByte operator +(NSByte value) => value;
        public static NSByte operator ++(NSByte value) => (sbyte)(value._value + 1);
        public static NSByte operator <<(NSByte left, int right) => (sbyte)(left._value << right);
        public static NSByte operator >>(NSByte left, int right) => (sbyte)(left._value >> right);

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

        bool INumeric<NSByte>.IsGreaterThan(NSByte value) => this > value;
        bool INumeric<NSByte>.IsGreaterThanOrEqualTo(NSByte value) => this >= value;
        bool INumeric<NSByte>.IsLessThan(NSByte value) => this < value;
        bool INumeric<NSByte>.IsLessThanOrEqualTo(NSByte value) => this <= value;
        NSByte INumeric<NSByte>.Add(NSByte value) => this + value;
        NSByte INumeric<NSByte>.BitwiseComplement() => ~this;
        NSByte INumeric<NSByte>.Divide(NSByte value) => this / value;
        NSByte INumeric<NSByte>.LeftShift(int count) => this << count;
        NSByte INumeric<NSByte>.LogicalAnd(NSByte value) => this & value;
        NSByte INumeric<NSByte>.LogicalExclusiveOr(NSByte value) => this ^ value;
        NSByte INumeric<NSByte>.LogicalOr(NSByte value) => this | value;
        NSByte INumeric<NSByte>.Multiply(NSByte value) => this * value;
        NSByte INumeric<NSByte>.Negative() => -this;
        NSByte INumeric<NSByte>.Positive() => +this;
        NSByte INumeric<NSByte>.Remainder(NSByte value) => this % value;
        NSByte INumeric<NSByte>.RightShift(int count) => this >> count;
        NSByte INumeric<NSByte>.Subtract(NSByte value) => this - value;

        INumericBitConverter<NSByte> IProvider<INumericBitConverter<NSByte>>.GetInstance() => Utilities.Instance;
        IBinaryIO<NSByte> IProvider<IBinaryIO<NSByte>>.GetInstance() => Utilities.Instance;
        IConvert<NSByte> IProvider<IConvert<NSByte>>.GetInstance() => Utilities.Instance;
        IConvertExtended<NSByte> IProvider<IConvertExtended<NSByte>>.GetInstance() => Utilities.Instance;
        IMath<NSByte> IProvider<IMath<NSByte>>.GetInstance() => Utilities.Instance;
        INumericRandom<NSByte> IProvider<INumericRandom<NSByte>>.GetInstance() => Utilities.Instance;
        INumericStatic<NSByte> IProvider<INumericStatic<NSByte>>.GetInstance() => Utilities.Instance;
        IVariantRandom<NSByte> IProvider<IVariantRandom<NSByte>>.GetInstance() => Utilities.Instance;

        private sealed class Utilities :
            IBinaryIO<NSByte>,
            IConvert<NSByte>,
            IConvertExtended<NSByte>,
            IMath<NSByte>,
            INumericBitConverter<NSByte>,
            INumericRandom<NSByte>,
            INumericStatic<NSByte>,
            IVariantRandom<NSByte>
        {
            public static readonly Utilities Instance = new Utilities();

            void IBinaryIO<NSByte>.Write(BinaryWriter writer, NSByte value) => writer.Write(value);
            NSByte IBinaryIO<NSByte>.Read(BinaryReader reader) => reader.ReadSByte();

            bool INumericStatic<NSByte>.HasFloatingPoint => false;
            bool INumericStatic<NSByte>.HasInfinity => false;
            bool INumericStatic<NSByte>.HasNaN => false;
            bool INumericStatic<NSByte>.IsFinite(NSByte x) => true;
            bool INumericStatic<NSByte>.IsInfinity(NSByte x) => false;
            bool INumericStatic<NSByte>.IsNaN(NSByte x) => false;
            bool INumericStatic<NSByte>.IsNegative(NSByte x) => x._value < 0;
            bool INumericStatic<NSByte>.IsNegativeInfinity(NSByte x) => false;
            bool INumericStatic<NSByte>.IsNormal(NSByte x) => false;
            bool INumericStatic<NSByte>.IsPositiveInfinity(NSByte x) => false;
            bool INumericStatic<NSByte>.IsReal => false;
            bool INumericStatic<NSByte>.IsSigned => true;
            bool INumericStatic<NSByte>.IsSubnormal(NSByte x) => false;
            NSByte INumericStatic<NSByte>.Epsilon => 1;
            NSByte INumericStatic<NSByte>.MaxUnit => 1;
            NSByte INumericStatic<NSByte>.MaxValue => MaxValue;
            NSByte INumericStatic<NSByte>.MinUnit => -1;
            NSByte INumericStatic<NSByte>.MinValue => MinValue;
            NSByte INumericStatic<NSByte>.One => 1;
            NSByte INumericStatic<NSByte>.Zero => 0;

            int IMath<NSByte>.Sign(NSByte x) => Math.Sign(x._value);
            NSByte IMath<NSByte>.Abs(NSByte value) => Math.Abs(value._value);
            NSByte IMath<NSByte>.Acos(NSByte x) => (sbyte)Math.Acos(x._value);
            NSByte IMath<NSByte>.Acosh(NSByte x) => (sbyte)MathShim.Acosh(x._value);
            NSByte IMath<NSByte>.Asin(NSByte x) => (sbyte)Math.Asin(x._value);
            NSByte IMath<NSByte>.Asinh(NSByte x) => (sbyte)MathShim.Asinh(x._value);
            NSByte IMath<NSByte>.Atan(NSByte x) => (sbyte)Math.Atan(x._value);
            NSByte IMath<NSByte>.Atan2(NSByte x, NSByte y) => (sbyte)Math.Atan2(x._value, y._value);
            NSByte IMath<NSByte>.Atanh(NSByte x) => (sbyte)MathShim.Atanh(x._value);
            NSByte IMath<NSByte>.Cbrt(NSByte x) => (sbyte)MathShim.Cbrt(x._value);
            NSByte IMath<NSByte>.Ceiling(NSByte x) => x;
            NSByte IMath<NSByte>.Clamp(NSByte x, NSByte bound1, NSByte bound2) => bound1 > bound2 ? Math.Min(bound1._value, Math.Max(bound2._value, x._value)) : Math.Min(bound2._value, Math.Max(bound1._value, x._value));
            NSByte IMath<NSByte>.Cos(NSByte x) => (sbyte)Math.Cos(x._value);
            NSByte IMath<NSByte>.Cosh(NSByte x) => (sbyte)Math.Cosh(x._value);
            NSByte IMath<NSByte>.E { get; } = 2;
            NSByte IMath<NSByte>.Exp(NSByte x) => (sbyte)Math.Exp(x._value);
            NSByte IMath<NSByte>.Floor(NSByte x) => x;
            NSByte IMath<NSByte>.IEEERemainder(NSByte x, NSByte y) => (sbyte)Math.IEEERemainder(x._value, y._value);
            NSByte IMath<NSByte>.Log(NSByte x) => (sbyte)Math.Log(x._value);
            NSByte IMath<NSByte>.Log(NSByte x, NSByte y) => (sbyte)Math.Log(x._value, y._value);
            NSByte IMath<NSByte>.Log10(NSByte x) => (sbyte)Math.Log10(x._value);
            NSByte IMath<NSByte>.Max(NSByte x, NSByte y) => Math.Max(x._value, y._value);
            NSByte IMath<NSByte>.Min(NSByte x, NSByte y) => Math.Min(x._value, y._value);
            NSByte IMath<NSByte>.PI { get; } = 3;
            NSByte IMath<NSByte>.Pow(NSByte x, NSByte y) => (sbyte)Math.Pow(x._value, y._value);
            NSByte IMath<NSByte>.Round(NSByte x) => x;
            NSByte IMath<NSByte>.Round(NSByte x, int digits) => x;
            NSByte IMath<NSByte>.Round(NSByte x, int digits, MidpointRounding mode) => x;
            NSByte IMath<NSByte>.Round(NSByte x, MidpointRounding mode) => x;
            NSByte IMath<NSByte>.Sin(NSByte x) => (sbyte)Math.Sin(x._value);
            NSByte IMath<NSByte>.Sinh(NSByte x) => (sbyte)Math.Sinh(x._value);
            NSByte IMath<NSByte>.Sqrt(NSByte x) => (sbyte)Math.Sqrt(x._value);
            NSByte IMath<NSByte>.Tan(NSByte x) => (sbyte)Math.Tan(x._value);
            NSByte IMath<NSByte>.Tanh(NSByte x) => (sbyte)Math.Tanh(x._value);
            NSByte IMath<NSByte>.Tau { get; } = 6;
            NSByte IMath<NSByte>.Truncate(NSByte x) => x;

            int INumericBitConverter<NSByte>.ConvertedSize => sizeof(sbyte);
            NSByte INumericBitConverter<NSByte>.ToNumeric(byte[] value, int startIndex) => BitOperations.ToSByte(value, startIndex);
            byte[] INumericBitConverter<NSByte>.GetBytes(NSByte value) => new byte[] { (byte)value._value };
#if HAS_SPANS
            NSByte INumericBitConverter<NSByte>.ToNumeric(ReadOnlySpan<byte> value) => BitOperations.ToSByte(value);
            bool INumericBitConverter<NSByte>.TryWriteBytes(Span<byte> destination, NSByte value) => BitOperations.TryWriteSByte(destination, value);
#endif

            bool IConvert<NSByte>.ToBoolean(NSByte value) => Convert.ToBoolean(value._value);
            byte IConvert<NSByte>.ToByte(NSByte value, Conversion mode) => ConvertN.ToByte(value._value, mode);
            decimal IConvert<NSByte>.ToDecimal(NSByte value, Conversion mode) => ConvertN.ToDecimal(value._value, mode);
            double IConvert<NSByte>.ToDouble(NSByte value, Conversion mode) => ConvertN.ToDouble(value._value, mode);
            float IConvert<NSByte>.ToSingle(NSByte value, Conversion mode) => ConvertN.ToSingle(value._value, mode);
            int IConvert<NSByte>.ToInt32(NSByte value, Conversion mode) => ConvertN.ToInt32(value._value, mode);
            long IConvert<NSByte>.ToInt64(NSByte value, Conversion mode) => ConvertN.ToInt64(value._value, mode);
            sbyte IConvertExtended<NSByte>.ToSByte(NSByte value, Conversion mode) => ConvertN.ToSByte(value._value, mode);
            short IConvert<NSByte>.ToInt16(NSByte value, Conversion mode) => ConvertN.ToInt16(value._value, mode);
            string IConvert<NSByte>.ToString(NSByte value) => Convert.ToString(value._value);
            uint IConvertExtended<NSByte>.ToUInt32(NSByte value, Conversion mode) => ConvertN.ToUInt32(value._value, mode);
            ulong IConvertExtended<NSByte>.ToUInt64(NSByte value, Conversion mode) => ConvertN.ToUInt64(value._value, mode);
            ushort IConvertExtended<NSByte>.ToUInt16(NSByte value, Conversion mode) => ConvertN.ToUInt16(value._value, mode);

            NSByte IConvert<NSByte>.ToNumeric(bool value) => Convert.ToSByte(value);
            NSByte IConvert<NSByte>.ToNumeric(byte value, Conversion mode) => ConvertN.ToSByte(value, mode);
            NSByte IConvert<NSByte>.ToNumeric(decimal value, Conversion mode) => ConvertN.ToSByte(value, mode);
            NSByte IConvert<NSByte>.ToNumeric(double value, Conversion mode) => ConvertN.ToSByte(value, mode);
            NSByte IConvert<NSByte>.ToNumeric(float value, Conversion mode) => ConvertN.ToSByte(value, mode);
            NSByte IConvert<NSByte>.ToNumeric(int value, Conversion mode) => ConvertN.ToSByte(value, mode);
            NSByte IConvert<NSByte>.ToNumeric(long value, Conversion mode) => ConvertN.ToSByte(value, mode);
            NSByte IConvertExtended<NSByte>.ToValue(sbyte value, Conversion mode) => ConvertN.ToSByte(value, mode);
            NSByte IConvert<NSByte>.ToNumeric(short value, Conversion mode) => ConvertN.ToSByte(value, mode);
            NSByte IConvert<NSByte>.ToNumeric(string value) => Convert.ToSByte(value);
            NSByte IConvertExtended<NSByte>.ToNumeric(uint value, Conversion mode) => ConvertN.ToSByte(value, mode);
            NSByte IConvertExtended<NSByte>.ToNumeric(ulong value, Conversion mode) => ConvertN.ToSByte(value, mode);
            NSByte IConvertExtended<NSByte>.ToNumeric(ushort value, Conversion mode) => ConvertN.ToSByte(value, mode);

            NSByte INumericStatic<NSByte>.Parse(string s, NumberStyles? style, IFormatProvider? provider)
                => Parse(s, style ?? NumberStyles.Integer, provider);

            NSByte INumericRandom<NSByte>.Generate(Random random) => random.NextSByte();
            NSByte INumericRandom<NSByte>.Generate(Random random, NSByte maxValue) => random.NextSByte(maxValue);
            NSByte INumericRandom<NSByte>.Generate(Random random, NSByte minValue, NSByte maxValue) => random.NextSByte(minValue, maxValue);
            NSByte INumericRandom<NSByte>.Generate(Random random, Generation mode) => random.NextSByte(mode);
            NSByte INumericRandom<NSByte>.Generate(Random random, NSByte minValue, NSByte maxValue, Generation mode) => random.NextSByte(minValue, maxValue, mode);

            NSByte IVariantRandom<NSByte>.Generate(Random random, Variants variants) => random.NextSByte(variants);
        }
    }
}
