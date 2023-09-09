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
    /// Represents a single-precision floating-point number.
    /// </summary>
    [Serializable]
    [DebuggerDisplay("{ToString(),nq}")]
    public readonly struct NSingle : INumericExtended<NSingle>
    {
        public static readonly NSingle Epsilon = float.Epsilon;
        public static readonly NSingle MaxValue = float.MaxValue;
        public static readonly NSingle MinValue = float.MinValue;

        private readonly float _value;

        private NSingle(float value)
        {
            _value = value;
        }

        private NSingle(SerializationInfo info, StreamingContext context) : this(info.GetSingle(nameof(NSingle))) { }
        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context) => info.AddValue(nameof(NSingle), _value);

        public int CompareTo(NSingle other) => _value.CompareTo(other._value);
        public int CompareTo(object? obj) => obj is NSingle other ? CompareTo(other) : 1;
        public bool Equals(NSingle other) => _value == other._value;
        public override bool Equals(object? obj) => obj is NSingle other && Equals(other);
        public override int GetHashCode() => _value.GetHashCode();
        public override string ToString() => _value.ToString();
        public string ToString(IFormatProvider formatProvider) => _value.ToString(formatProvider);
        public string ToString(string format) => _value.ToString(format);
        public string ToString(string? format, IFormatProvider? formatProvider) => _value.ToString(format, formatProvider);

        public static bool IsFinite(NSingle f) => SingleShim.IsFinite(f);
        public static bool IsInfinity(NSingle f) => float.IsInfinity(f);
        public static bool IsNaN(NSingle f) => float.IsNaN(f);
        public static bool IsNegative(NSingle f) => SingleShim.IsNegative(f);
        public static bool IsNegativeInfinity(NSingle f) => float.IsNegativeInfinity(f);
        public static bool IsNormal(NSingle f) => SingleShim.IsNormal(f);
        public static bool IsPositiveInfinity(NSingle f) => float.IsPositiveInfinity(f);
        public static bool IsSubnormal(NSingle f) => SingleShim.IsSubnormal(f);

        public static bool TryParse(string s, IFormatProvider? provider, out NSingle result) => FuncExtensions.Try(() => Parse(s, provider), out result);
        public static bool TryParse(string s, NumberStyles style, IFormatProvider? provider, out NSingle result) => FuncExtensions.Try(() => Parse(s, style, provider), out result);
        public static bool TryParse(string s, NumberStyles style, out NSingle result) => FuncExtensions.Try(() => Parse(s, style), out result);
        public static bool TryParse(string s, out NSingle result) => FuncExtensions.Try(() => Parse(s), out result);
        public static NSingle Parse(string s) => float.Parse(s);
        public static NSingle Parse(string s, IFormatProvider? provider) => float.Parse(s, provider);
        public static NSingle Parse(string s, NumberStyles style) => float.Parse(s, style);
        public static NSingle Parse(string s, NumberStyles style, IFormatProvider? provider) => float.Parse(s, style, provider);

        [CLSCompliant(false)] public static implicit operator NSingle(sbyte value) => new NSingle(value);
        [CLSCompliant(false)] public static implicit operator NSingle(uint value) => new NSingle(value);
        [CLSCompliant(false)] public static implicit operator NSingle(ulong value) => new NSingle(value);
        [CLSCompliant(false)] public static implicit operator NSingle(ushort value) => new NSingle(value);
        public static explicit operator NSingle(decimal value) => new NSingle((float)value);
        public static explicit operator NSingle(double value) => new NSingle((float)value);
        public static implicit operator NSingle(byte value) => new NSingle(value);
        public static implicit operator NSingle(float value) => new NSingle(value);
        public static implicit operator NSingle(int value) => new NSingle(value);
        public static implicit operator NSingle(long value) => new NSingle(value);
        public static implicit operator NSingle(short value) => new NSingle(value);

        [CLSCompliant(false)] public static explicit operator sbyte(NSingle value) => (sbyte)value._value;
        [CLSCompliant(false)] public static explicit operator uint(NSingle value) => (uint)value._value;
        [CLSCompliant(false)] public static explicit operator ulong(NSingle value) => (ulong)value._value;
        [CLSCompliant(false)] public static explicit operator ushort(NSingle value) => (ushort)value._value;
        public static explicit operator byte(NSingle value) => (byte)value._value;
        public static explicit operator decimal(NSingle value) => (decimal)value._value;
        public static explicit operator int(NSingle value) => (int)value._value;
        public static explicit operator long(NSingle value) => (long)value._value;
        public static explicit operator short(NSingle value) => (short)value._value;
        public static implicit operator double(NSingle value) => value._value;
        public static implicit operator float(NSingle value) => value._value;

        public static bool operator !=(NSingle left, NSingle right) => left._value != right._value;
        public static bool operator <(NSingle left, NSingle right) => left._value < right._value;
        public static bool operator <=(NSingle left, NSingle right) => left._value <= right._value;
        public static bool operator ==(NSingle left, NSingle right) => left._value == right._value;
        public static bool operator >(NSingle left, NSingle right) => left._value > right._value;
        public static bool operator >=(NSingle left, NSingle right) => left._value >= right._value;
        public static NSingle operator %(NSingle left, NSingle right) => left._value % right._value;
        public static NSingle operator &(NSingle left, NSingle right) => BitOperations.LogicalAnd(left._value, right._value);
        public static NSingle operator -(NSingle left, NSingle right) => left._value - right._value;
        public static NSingle operator --(NSingle value) => value._value - 1;
        public static NSingle operator -(NSingle value) => -value._value;
        public static NSingle operator *(NSingle left, NSingle right) => left._value * right._value;
        public static NSingle operator /(NSingle left, NSingle right) => left._value / right._value;
        public static NSingle operator ^(NSingle left, NSingle right) => BitOperations.LogicalExclusiveOr(left._value, right._value);
        public static NSingle operator |(NSingle left, NSingle right) => BitOperations.LogicalOr(left._value, right._value);
        public static NSingle operator ~(NSingle left) => BitOperations.BitwiseComplement(left._value);
        public static NSingle operator +(NSingle left, NSingle right) => left._value + right._value;
        public static NSingle operator +(NSingle value) => value;
        public static NSingle operator ++(NSingle value) => value._value + 1;
        public static NSingle operator <<(NSingle left, int right) => BitOperations.LeftShift(left._value, right);
        public static NSingle operator >>(NSingle left, int right) => BitOperations.RightShift(left._value, right);

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

        bool INumeric<NSingle>.IsGreaterThan(NSingle value) => this > value;
        bool INumeric<NSingle>.IsGreaterThanOrEqualTo(NSingle value) => this >= value;
        bool INumeric<NSingle>.IsLessThan(NSingle value) => this < value;
        bool INumeric<NSingle>.IsLessThanOrEqualTo(NSingle value) => this <= value;
        NSingle INumeric<NSingle>.Add(NSingle value) => this + value;
        NSingle INumeric<NSingle>.BitwiseComplement() => ~this;
        NSingle INumeric<NSingle>.Divide(NSingle value) => this / value;
        NSingle INumeric<NSingle>.LeftShift(int count) => this << count;
        NSingle INumeric<NSingle>.LogicalAnd(NSingle value) => this & value;
        NSingle INumeric<NSingle>.LogicalExclusiveOr(NSingle value) => this ^ value;
        NSingle INumeric<NSingle>.LogicalOr(NSingle value) => this | value;
        NSingle INumeric<NSingle>.Multiply(NSingle value) => this * value;
        NSingle INumeric<NSingle>.Negative() => -this;
        NSingle INumeric<NSingle>.Positive() => +this;
        NSingle INumeric<NSingle>.Remainder(NSingle value) => this % value;
        NSingle INumeric<NSingle>.RightShift(int count) => this >> count;
        NSingle INumeric<NSingle>.Subtract(NSingle value) => this - value;

        INumericBitConverter<NSingle> IProvider<INumericBitConverter<NSingle>>.GetInstance() => Utilities.Instance;
        IBinaryIO<NSingle> IProvider<IBinaryIO<NSingle>>.GetInstance() => Utilities.Instance;
        IConvert<NSingle> IProvider<IConvert<NSingle>>.GetInstance() => Utilities.Instance;
        IConvertExtended<NSingle> IProvider<IConvertExtended<NSingle>>.GetInstance() => Utilities.Instance;
        IMath<NSingle> IProvider<IMath<NSingle>>.GetInstance() => Utilities.Instance;
        INumericStatic<NSingle> IProvider<INumericStatic<NSingle>>.GetInstance() => Utilities.Instance;
        INumericRandom<NSingle> IProvider<INumericRandom<NSingle>>.GetInstance() => Utilities.Instance;
        IVariantRandom<NSingle> IProvider<IVariantRandom<NSingle>>.GetInstance() => Utilities.Instance;

        private sealed class Utilities :
            IBinaryIO<NSingle>,
            IConvert<NSingle>,
            IConvertExtended<NSingle>,
            IMath<NSingle>,
            INumericBitConverter<NSingle>,
            INumericRandom<NSingle>,
            INumericStatic<NSingle>,
            IVariantRandom<NSingle>
        {
            public static readonly Utilities Instance = new Utilities();

            void IBinaryIO<NSingle>.Write(BinaryWriter writer, NSingle value) => writer.Write(value);
            NSingle IBinaryIO<NSingle>.Read(BinaryReader reader) => reader.ReadSingle();

            bool INumericStatic<NSingle>.HasFloatingPoint => true;
            bool INumericStatic<NSingle>.HasInfinity => true;
            bool INumericStatic<NSingle>.HasNaN => true;
            bool INumericStatic<NSingle>.IsFinite(NSingle x) => IsFinite(x);
            bool INumericStatic<NSingle>.IsInfinity(NSingle x) => IsInfinity(x);
            bool INumericStatic<NSingle>.IsNaN(NSingle x) => IsNaN(x);
            bool INumericStatic<NSingle>.IsNegative(NSingle x) => IsNegative(x);
            bool INumericStatic<NSingle>.IsNegativeInfinity(NSingle x) => IsNegativeInfinity(x);
            bool INumericStatic<NSingle>.IsNormal(NSingle x) => IsNormal(x);
            bool INumericStatic<NSingle>.IsPositiveInfinity(NSingle x) => IsPositiveInfinity(x);
            bool INumericStatic<NSingle>.IsReal => true;
            bool INumericStatic<NSingle>.IsSigned => true;
            bool INumericStatic<NSingle>.IsSubnormal(NSingle x) => IsSubnormal(x);
            NSingle INumericStatic<NSingle>.Epsilon => Epsilon;
            NSingle INumericStatic<NSingle>.MaxUnit => 1f;
            NSingle INumericStatic<NSingle>.MaxValue => MaxValue;
            NSingle INumericStatic<NSingle>.MinUnit => -1f;
            NSingle INumericStatic<NSingle>.MinValue => MinValue;
            NSingle INumericStatic<NSingle>.One => 1f;
            NSingle INumericStatic<NSingle>.Zero => 0f;

            int IMath<NSingle>.Sign(NSingle x) => Math.Sign(x._value);
            NSingle IMath<NSingle>.Abs(NSingle value) => MathFShim.Abs(value._value);
            NSingle IMath<NSingle>.Acos(NSingle x) => MathFShim.Acos(x._value);
            NSingle IMath<NSingle>.Acosh(NSingle x) => MathFShim.Acosh(x._value);
            NSingle IMath<NSingle>.Asin(NSingle x) => MathFShim.Asin(x._value);
            NSingle IMath<NSingle>.Asinh(NSingle x) => MathFShim.Asinh(x._value);
            NSingle IMath<NSingle>.Atan(NSingle x) => MathFShim.Atan(x._value);
            NSingle IMath<NSingle>.Atan2(NSingle x, NSingle y) => MathFShim.Atan2(x._value, y._value);
            NSingle IMath<NSingle>.Atanh(NSingle x) => MathFShim.Atanh(x._value);
            NSingle IMath<NSingle>.Cbrt(NSingle x) => MathFShim.Cbrt(x._value);
            NSingle IMath<NSingle>.Ceiling(NSingle x) => MathFShim.Ceiling(x._value);
            NSingle IMath<NSingle>.Clamp(NSingle x, NSingle bound1, NSingle bound2) => bound1 > bound2 ? MathFShim.Min(bound1._value, MathFShim.Max(bound2._value, x._value)) : MathFShim.Min(bound2._value, MathFShim.Max(bound1._value, x._value));
            NSingle IMath<NSingle>.Cos(NSingle x) => MathFShim.Cos(x._value);
            NSingle IMath<NSingle>.Cosh(NSingle x) => MathFShim.Cosh(x._value);
            NSingle IMath<NSingle>.E { get; } = MathFShim.E;
            NSingle IMath<NSingle>.Exp(NSingle x) => MathFShim.Exp(x._value);
            NSingle IMath<NSingle>.Floor(NSingle x) => MathFShim.Floor(x._value);
            NSingle IMath<NSingle>.IEEERemainder(NSingle x, NSingle y) => MathFShim.IEEERemainder(x._value, y._value);
            NSingle IMath<NSingle>.Log(NSingle x) => MathFShim.Log(x._value);
            NSingle IMath<NSingle>.Log(NSingle x, NSingle y) => MathFShim.Log(x._value, y._value);
            NSingle IMath<NSingle>.Log10(NSingle x) => MathFShim.Log10(x._value);
            NSingle IMath<NSingle>.Max(NSingle x, NSingle y) => MathFShim.Max(x._value, y._value);
            NSingle IMath<NSingle>.Min(NSingle x, NSingle y) => MathFShim.Min(x._value, y._value);
            NSingle IMath<NSingle>.PI { get; } = MathFShim.PI;
            NSingle IMath<NSingle>.Pow(NSingle x, NSingle y) => MathFShim.Pow(x._value, y._value);
            NSingle IMath<NSingle>.Round(NSingle x) => MathFShim.Round(x);
            NSingle IMath<NSingle>.Round(NSingle x, int digits) => MathFShim.Round(x, digits);
            NSingle IMath<NSingle>.Round(NSingle x, int digits, MidpointRounding mode) => MathFShim.Round(x, digits, mode);
            NSingle IMath<NSingle>.Round(NSingle x, MidpointRounding mode) => MathFShim.Round(x, mode);
            NSingle IMath<NSingle>.Sin(NSingle x) => MathFShim.Sin(x._value);
            NSingle IMath<NSingle>.Sinh(NSingle x) => MathFShim.Sinh(x._value);
            NSingle IMath<NSingle>.Sqrt(NSingle x) => MathFShim.Sqrt(x._value);
            NSingle IMath<NSingle>.Tan(NSingle x) => MathFShim.Tan(x._value);
            NSingle IMath<NSingle>.Tanh(NSingle x) => MathFShim.Tanh(x._value);
            NSingle IMath<NSingle>.Tau { get; } = MathFShim.PI * 2;
            NSingle IMath<NSingle>.Truncate(NSingle x) => MathFShim.Truncate(x._value);

            int INumericBitConverter<NSingle>.ConvertedSize => sizeof(float);
            NSingle INumericBitConverter<NSingle>.ToNumeric(byte[] value, int startIndex) => BitConverter.ToSingle(value, startIndex);
            byte[] INumericBitConverter<NSingle>.GetBytes(NSingle value) => BitConverter.GetBytes(value._value);
#if HAS_SPANS
            NSingle INumericBitConverter<NSingle>.ToNumeric(ReadOnlySpan<byte> value) => BitConverter.ToSingle(value);
            bool INumericBitConverter<NSingle>.TryWriteBytes(Span<byte> destination, NSingle value) => BitConverter.TryWriteBytes(destination, value);
#endif

            bool IConvert<NSingle>.ToBoolean(NSingle value) => Convert.ToBoolean(value._value);
            byte IConvert<NSingle>.ToByte(NSingle value, Conversion mode) => ConvertN.ToByte(value._value, mode);
            decimal IConvert<NSingle>.ToDecimal(NSingle value, Conversion mode) => ConvertN.ToDecimal(value._value, mode);
            double IConvert<NSingle>.ToDouble(NSingle value, Conversion mode) => ConvertN.ToDouble(value._value, mode);
            float IConvert<NSingle>.ToSingle(NSingle value, Conversion mode) => ConvertN.ToSingle(value._value, mode);
            int IConvert<NSingle>.ToInt32(NSingle value, Conversion mode) => ConvertN.ToInt32(value._value, mode);
            long IConvert<NSingle>.ToInt64(NSingle value, Conversion mode) => ConvertN.ToInt64(value._value, mode);
            sbyte IConvertExtended<NSingle>.ToSByte(NSingle value, Conversion mode) => ConvertN.ToSByte(value._value, mode);
            short IConvert<NSingle>.ToInt16(NSingle value, Conversion mode) => ConvertN.ToInt16(value._value, mode);
            string IConvert<NSingle>.ToString(NSingle value) => Convert.ToString(value._value);
            uint IConvertExtended<NSingle>.ToUInt32(NSingle value, Conversion mode) => ConvertN.ToUInt32(value._value, mode);
            ulong IConvertExtended<NSingle>.ToUInt64(NSingle value, Conversion mode) => ConvertN.ToUInt64(value._value, mode);
            ushort IConvertExtended<NSingle>.ToUInt16(NSingle value, Conversion mode) => ConvertN.ToUInt16(value._value, mode);

            NSingle IConvert<NSingle>.ToNumeric(bool value) => Convert.ToSingle(value);
            NSingle IConvert<NSingle>.ToNumeric(byte value, Conversion mode) => ConvertN.ToSingle(value, mode);
            NSingle IConvert<NSingle>.ToNumeric(float value, Conversion mode) => ConvertN.ToSingle(value, mode);
            NSingle IConvert<NSingle>.ToNumeric(double value, Conversion mode) => ConvertN.ToSingle(value, mode);
            NSingle IConvert<NSingle>.ToNumeric(decimal value, Conversion mode) => ConvertN.ToSingle(value, mode);
            NSingle IConvert<NSingle>.ToNumeric(int value, Conversion mode) => ConvertN.ToSingle(value, mode);
            NSingle IConvert<NSingle>.ToNumeric(long value, Conversion mode) => ConvertN.ToSingle(value, mode);
            NSingle IConvertExtended<NSingle>.ToValue(sbyte value, Conversion mode) => ConvertN.ToSingle(value, mode);
            NSingle IConvert<NSingle>.ToNumeric(short value, Conversion mode) => ConvertN.ToSingle(value, mode);
            NSingle IConvert<NSingle>.ToNumeric(string value) => Convert.ToSingle(value);
            NSingle IConvertExtended<NSingle>.ToNumeric(uint value, Conversion mode) => ConvertN.ToSingle(value, mode);
            NSingle IConvertExtended<NSingle>.ToNumeric(ulong value, Conversion mode) => ConvertN.ToSingle(value, mode);
            NSingle IConvertExtended<NSingle>.ToNumeric(ushort value, Conversion mode) => ConvertN.ToSingle(value, mode);

            NSingle INumericStatic<NSingle>.Parse(string s, NumberStyles? style, IFormatProvider? provider)
                => Parse(s, style ?? NumberStyles.Float | NumberStyles.AllowThousands, provider);

            NSingle INumericRandom<NSingle>.Generate(Random random) => random.NextSingle();
            NSingle INumericRandom<NSingle>.Generate(Random random, NSingle maxValue) => random.NextSingle(maxValue);
            NSingle INumericRandom<NSingle>.Generate(Random random, NSingle minValue, NSingle maxValue) => random.NextSingle(minValue, maxValue);
            NSingle INumericRandom<NSingle>.Generate(Random random, Generation mode) => random.NextSingle(mode);
            NSingle INumericRandom<NSingle>.Generate(Random random, NSingle minValue, NSingle maxValue, Generation mode) => random.NextSingle(minValue, maxValue, mode);

            NSingle IVariantRandom<NSingle>.Generate(Random random, Variants variants) => random.NextSingle(variants);
        }
    }
}
