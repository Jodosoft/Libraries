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
    /// Represents a 32-bit unsigned integer that cannot overflow.
    /// </summary>
    [Serializable]
    [DebuggerDisplay("{ToString(),nq}")]
    public readonly struct UInt32M : INumericExtended<UInt32M>
    {
        public static readonly UInt32M MaxValue = new UInt32M(uint.MaxValue);
        public static readonly UInt32M MinValue = new UInt32M(uint.MinValue);

        private readonly uint _value;

        private UInt32M(uint value)
        {
            _value = value;
        }

        private UInt32M(SerializationInfo info, StreamingContext context) : this(info.GetUInt32(nameof(UInt32M))) { }
        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context) => info.AddValue(nameof(UInt32M), _value);

        public int CompareTo(object? obj) => obj is UInt32M other ? CompareTo(other) : 1;
        public int CompareTo(UInt32M other) => _value.CompareTo(other._value);
        public bool Equals(UInt32M other) => _value == other._value;
        public override bool Equals(object? obj) => obj is UInt32M other && Equals(other);
        public override int GetHashCode() => _value.GetHashCode();
        public override string ToString() => _value.ToString();
        public string ToString(IFormatProvider formatProvider) => _value.ToString(formatProvider);
        public string ToString(string format) => _value.ToString(format);
        public string ToString(string? format, IFormatProvider? formatProvider) => _value.ToString(format, formatProvider);

        public static bool TryParse(string s, IFormatProvider? provider, out UInt32M result) => FuncExtensions.Try(() => Parse(s, provider), out result);
        public static bool TryParse(string s, NumberStyles style, IFormatProvider? provider, out UInt32M result) => FuncExtensions.Try(() => Parse(s, style, provider), out result);
        public static bool TryParse(string s, NumberStyles style, out UInt32M result) => FuncExtensions.Try(() => Parse(s, style), out result);
        public static bool TryParse(string s, out UInt32M result) => FuncExtensions.Try(() => Parse(s), out result);
        public static UInt32M Parse(string s) => uint.Parse(s);
        public static UInt32M Parse(string s, IFormatProvider? provider) => uint.Parse(s, provider);
        public static UInt32M Parse(string s, NumberStyles style) => uint.Parse(s, style);
        public static UInt32M Parse(string s, NumberStyles style, IFormatProvider? provider) => uint.Parse(s, style, provider);

        [CLSCompliant(false)] public static explicit operator UInt32M(sbyte value) => new UInt32M(ConvertN.ToUInt32(value, Conversion.CastClamp));
        [CLSCompliant(false)] public static explicit operator UInt32M(ulong value) => new UInt32M(ConvertN.ToUInt32(value, Conversion.CastClamp));
        [CLSCompliant(false)] public static implicit operator UInt32M(uint value) => new UInt32M(value);
        [CLSCompliant(false)] public static implicit operator UInt32M(ushort value) => new UInt32M(value);
        public static explicit operator UInt32M(decimal value) => new UInt32M(ConvertN.ToUInt32(value, Conversion.CastClamp));
        public static explicit operator UInt32M(double value) => new UInt32M(ConvertN.ToUInt32(value, Conversion.CastClamp));
        public static explicit operator UInt32M(float value) => new UInt32M(ConvertN.ToUInt32(value, Conversion.CastClamp));
        public static explicit operator UInt32M(int value) => new UInt32M(ConvertN.ToUInt32(value, Conversion.CastClamp));
        public static explicit operator UInt32M(long value) => new UInt32M(ConvertN.ToUInt32(value, Conversion.CastClamp));
        public static explicit operator UInt32M(short value) => new UInt32M(ConvertN.ToUInt32(value, Conversion.CastClamp));
        public static implicit operator UInt32M(byte value) => new UInt32M(value);

        [CLSCompliant(false)] public static explicit operator sbyte(UInt32M value) => ConvertN.ToSByte(value._value, Conversion.CastClamp);
        [CLSCompliant(false)] public static explicit operator ushort(UInt32M value) => ConvertN.ToUInt16(value._value, Conversion.CastClamp);
        [CLSCompliant(false)] public static implicit operator uint(UInt32M value) => value._value;
        [CLSCompliant(false)] public static implicit operator ulong(UInt32M value) => value._value;
        public static explicit operator byte(UInt32M value) => ConvertN.ToByte(value._value, Conversion.CastClamp);
        public static explicit operator int(UInt32M value) => ConvertN.ToInt32(value._value, Conversion.CastClamp);
        public static explicit operator short(UInt32M value) => ConvertN.ToInt16(value._value, Conversion.CastClamp);
        public static implicit operator decimal(UInt32M value) => value._value;
        public static implicit operator double(UInt32M value) => value._value;
        public static implicit operator float(UInt32M value) => value._value;
        public static implicit operator long(UInt32M value) => value._value;

        public static bool operator !=(UInt32M left, UInt32M right) => left._value != right._value;
        public static bool operator <(UInt32M left, UInt32M right) => left._value < right._value;
        public static bool operator <=(UInt32M left, UInt32M right) => left._value <= right._value;
        public static bool operator ==(UInt32M left, UInt32M right) => left._value == right._value;
        public static bool operator >(UInt32M left, UInt32M right) => left._value > right._value;
        public static bool operator >=(UInt32M left, UInt32M right) => left._value >= right._value;
        public static UInt32M operator %(UInt32M left, UInt32M right) => Clamped.Remainder(left._value, right._value);
        public static UInt32M operator &(UInt32M left, UInt32M right) => left._value & right._value;
        public static UInt32M operator -(UInt32M _) => MinValue;
        public static UInt32M operator -(UInt32M left, UInt32M right) => Clamped.Subtract(left._value, right._value);
        public static UInt32M operator --(UInt32M value) => value - 1;
        public static UInt32M operator *(UInt32M left, UInt32M right) => Clamped.Multiply(left._value, right._value);
        public static UInt32M operator /(UInt32M left, UInt32M right) => Clamped.Divide(left._value, right._value);
        public static UInt32M operator ^(UInt32M left, UInt32M right) => left._value ^ right._value;
        public static UInt32M operator |(UInt32M left, UInt32M right) => left._value | right._value;
        public static UInt32M operator ~(UInt32M value) => ~value._value;
        public static UInt32M operator +(UInt32M left, UInt32M right) => Clamped.Add(left._value, right._value);
        public static UInt32M operator +(UInt32M value) => value;
        public static UInt32M operator ++(UInt32M value) => value + 1;
        public static UInt32M operator <<(UInt32M left, int right) => left._value << right;
        public static UInt32M operator >>(UInt32M left, int right) => left._value >> right;

        TypeCode IConvertible.GetTypeCode() => _value.GetTypeCode();
        bool IConvertible.ToBoolean(IFormatProvider provider) => Convert.ToBoolean(_value, provider);
        byte IConvertible.ToByte(IFormatProvider provider) => ConvertN.ToByte(_value, Conversion.Clamp);
        char IConvertible.ToChar(IFormatProvider provider) => Convert.ToChar(_value, provider);
        DateTime IConvertible.ToDateTime(IFormatProvider provider) => Convert.ToDateTime(provider);
        decimal IConvertible.ToDecimal(IFormatProvider provider) => ConvertN.ToDecimal(_value, Conversion.Clamp);
        double IConvertible.ToDouble(IFormatProvider provider) => ConvertN.ToDouble(_value, Conversion.Clamp);
        float IConvertible.ToSingle(IFormatProvider provider) => ConvertN.ToSingle(_value, Conversion.Clamp);
        int IConvertible.ToInt32(IFormatProvider provider) => ConvertN.ToInt32(_value, Conversion.Clamp);
        long IConvertible.ToInt64(IFormatProvider provider) => ConvertN.ToInt64(_value, Conversion.Clamp);
        sbyte IConvertible.ToSByte(IFormatProvider provider) => ConvertN.ToSByte(_value, Conversion.Clamp);
        short IConvertible.ToInt16(IFormatProvider provider) => ConvertN.ToInt16(_value, Conversion.Clamp);
        uint IConvertible.ToUInt32(IFormatProvider provider) => _value;
        ulong IConvertible.ToUInt64(IFormatProvider provider) => ConvertN.ToUInt64(_value, Conversion.Clamp);
        ushort IConvertible.ToUInt16(IFormatProvider provider) => ConvertN.ToUInt16(_value, Conversion.Clamp);
        object IConvertible.ToType(Type conversionType, IFormatProvider provider) => this.ToTypeDefault(conversionType, provider);

        bool INumeric<UInt32M>.IsGreaterThan(UInt32M value) => this > value;
        bool INumeric<UInt32M>.IsGreaterThanOrEqualTo(UInt32M value) => this >= value;
        bool INumeric<UInt32M>.IsLessThan(UInt32M value) => this < value;
        bool INumeric<UInt32M>.IsLessThanOrEqualTo(UInt32M value) => this <= value;
        UInt32M INumeric<UInt32M>.Add(UInt32M value) => this + value;
        UInt32M INumeric<UInt32M>.BitwiseComplement() => ~this;
        UInt32M INumeric<UInt32M>.Divide(UInt32M value) => this / value;
        UInt32M INumeric<UInt32M>.LeftShift(int count) => this << count;
        UInt32M INumeric<UInt32M>.LogicalAnd(UInt32M value) => this & value;
        UInt32M INumeric<UInt32M>.LogicalExclusiveOr(UInt32M value) => this ^ value;
        UInt32M INumeric<UInt32M>.LogicalOr(UInt32M value) => this | value;
        UInt32M INumeric<UInt32M>.Multiply(UInt32M value) => this * value;
        UInt32M INumeric<UInt32M>.Negative() => -this;
        UInt32M INumeric<UInt32M>.Positive() => +this;
        UInt32M INumeric<UInt32M>.Remainder(UInt32M value) => this % value;
        UInt32M INumeric<UInt32M>.RightShift(int count) => this >> count;
        UInt32M INumeric<UInt32M>.Subtract(UInt32M value) => this - value;

        INumericBitConverter<UInt32M> IProvider<INumericBitConverter<UInt32M>>.GetInstance() => Utilities.Instance;
        IBitBuffer<UInt32M> IProvider<IBitBuffer<UInt32M>>.GetInstance() => Utilities.Instance;
        IConvert<UInt32M> IProvider<IConvert<UInt32M>>.GetInstance() => Utilities.Instance;
        IConvertExtended<UInt32M> IProvider<IConvertExtended<UInt32M>>.GetInstance() => Utilities.Instance;
        IMath<UInt32M> IProvider<IMath<UInt32M>>.GetInstance() => Utilities.Instance;
        INumericRandom<UInt32M> IProvider<INumericRandom<UInt32M>>.GetInstance() => Utilities.Instance;
        INumericStatic<UInt32M> IProvider<INumericStatic<UInt32M>>.GetInstance() => Utilities.Instance;
        IVariantRandom<UInt32M> IProvider<IVariantRandom<UInt32M>>.GetInstance() => Utilities.Instance;

        private sealed class Utilities :
            IBitBuffer<UInt32M>,
            IConvert<UInt32M>,
            IConvertExtended<UInt32M>,
            IMath<UInt32M>,
            INumericBitConverter<UInt32M>,
            INumericRandom<UInt32M>,
            INumericStatic<UInt32M>,
            IVariantRandom<UInt32M>
        {
            public static readonly Utilities Instance = new Utilities();

            void IBitBuffer<UInt32M>.Write(UInt32M value, Stream stream) => stream.Write(value._value);
            async Task IBitBuffer<UInt32M>.WriteAsync(UInt32M value, Stream stream) => await stream.WriteAsync(value._value);
            UInt32M IBitBuffer<UInt32M>.Read(Stream stream) => stream.ReadUInt32();
            async Task<UInt32M> IBitBuffer<UInt32M>.ReadAsync(Stream stream) => await stream.ReadUInt32Async();

            bool INumericStatic<UInt32M>.HasFloatingPoint => false;
            bool INumericStatic<UInt32M>.HasInfinity => false;
            bool INumericStatic<UInt32M>.HasNaN => false;
            bool INumericStatic<UInt32M>.IsFinite(UInt32M x) => true;
            bool INumericStatic<UInt32M>.IsInfinity(UInt32M x) => false;
            bool INumericStatic<UInt32M>.IsNaN(UInt32M x) => false;
            bool INumericStatic<UInt32M>.IsNegative(UInt32M x) => false;
            bool INumericStatic<UInt32M>.IsNegativeInfinity(UInt32M x) => false;
            bool INumericStatic<UInt32M>.IsNormal(UInt32M x) => false;
            bool INumericStatic<UInt32M>.IsPositiveInfinity(UInt32M x) => false;
            bool INumericStatic<UInt32M>.IsReal => false;
            bool INumericStatic<UInt32M>.IsSigned => false;
            bool INumericStatic<UInt32M>.IsSubnormal(UInt32M x) => false;
            UInt32M INumericStatic<UInt32M>.Epsilon => 1;
            UInt32M INumericStatic<UInt32M>.MaxUnit => 1;
            UInt32M INumericStatic<UInt32M>.MaxValue => MaxValue;
            UInt32M INumericStatic<UInt32M>.MinUnit => 0;
            UInt32M INumericStatic<UInt32M>.MinValue => MinValue;
            UInt32M INumericStatic<UInt32M>.One => 1;
            UInt32M INumericStatic<UInt32M>.Zero => 0;

            int IMath<UInt32M>.Sign(UInt32M x) => x._value == 0 ? 0 : 1;
            UInt32M IMath<UInt32M>.Abs(UInt32M value) => value;
            UInt32M IMath<UInt32M>.Acos(UInt32M x) => (UInt32M)Math.Acos(x._value);
            UInt32M IMath<UInt32M>.Acosh(UInt32M x) => (UInt32M)MathShim.Acosh(x._value);
            UInt32M IMath<UInt32M>.Asin(UInt32M x) => (UInt32M)Math.Asin(x._value);
            UInt32M IMath<UInt32M>.Asinh(UInt32M x) => (UInt32M)MathShim.Asinh(x._value);
            UInt32M IMath<UInt32M>.Atan(UInt32M x) => (UInt32M)Math.Atan(x._value);
            UInt32M IMath<UInt32M>.Atan2(UInt32M x, UInt32M y) => (UInt32M)Math.Atan2(x._value, y._value);
            UInt32M IMath<UInt32M>.Atanh(UInt32M x) => (UInt32M)MathShim.Atanh(x._value);
            UInt32M IMath<UInt32M>.Cbrt(UInt32M x) => (UInt32M)MathShim.Cbrt(x._value);
            UInt32M IMath<UInt32M>.Ceiling(UInt32M x) => x;
            UInt32M IMath<UInt32M>.Clamp(UInt32M x, UInt32M bound1, UInt32M bound2) => bound1 > bound2 ? Math.Min(bound1._value, Math.Max(bound2._value, x._value)) : Math.Min(bound2._value, Math.Max(bound1._value, x._value));
            UInt32M IMath<UInt32M>.Cos(UInt32M x) => (UInt32M)Math.Cos(x._value);
            UInt32M IMath<UInt32M>.Cosh(UInt32M x) => (UInt32M)Math.Cosh(x._value);
            UInt32M IMath<UInt32M>.E { get; } = 2;
            UInt32M IMath<UInt32M>.Exp(UInt32M x) => (UInt32M)Math.Exp(x._value);
            UInt32M IMath<UInt32M>.Floor(UInt32M x) => x;
            UInt32M IMath<UInt32M>.IEEERemainder(UInt32M x, UInt32M y) => (UInt32M)Math.IEEERemainder(x._value, y._value);
            UInt32M IMath<UInt32M>.Log(UInt32M x) => (UInt32M)Math.Log(x._value);
            UInt32M IMath<UInt32M>.Log(UInt32M x, UInt32M y) => (UInt32M)Math.Log(x._value, y._value);
            UInt32M IMath<UInt32M>.Log10(UInt32M x) => (UInt32M)Math.Log10(x._value);
            UInt32M IMath<UInt32M>.Max(UInt32M x, UInt32M y) => Math.Max(x._value, y._value);
            UInt32M IMath<UInt32M>.Min(UInt32M x, UInt32M y) => Math.Min(x._value, y._value);
            UInt32M IMath<UInt32M>.PI { get; } = 3;
            UInt32M IMath<UInt32M>.Pow(UInt32M x, UInt32M y) => Clamped.Pow(x._value, y._value);
            UInt32M IMath<UInt32M>.Round(UInt32M x) => x;
            UInt32M IMath<UInt32M>.Round(UInt32M x, int digits) => x;
            UInt32M IMath<UInt32M>.Round(UInt32M x, int digits, MidpointRounding mode) => x;
            UInt32M IMath<UInt32M>.Round(UInt32M x, MidpointRounding mode) => x;
            UInt32M IMath<UInt32M>.Sin(UInt32M x) => (UInt32M)Math.Sin(x._value);
            UInt32M IMath<UInt32M>.Sinh(UInt32M x) => (UInt32M)Math.Sinh(x._value);
            UInt32M IMath<UInt32M>.Sqrt(UInt32M x) => (UInt32M)Math.Sqrt(x._value);
            UInt32M IMath<UInt32M>.Tan(UInt32M x) => (UInt32M)Math.Tan(x._value);
            UInt32M IMath<UInt32M>.Tanh(UInt32M x) => (UInt32M)Math.Tanh(x._value);
            UInt32M IMath<UInt32M>.Tau { get; } = 6;
            UInt32M IMath<UInt32M>.Truncate(UInt32M x) => x;

            int INumericBitConverter<UInt32M>.ConvertedSize => sizeof(uint);
            UInt32M INumericBitConverter<UInt32M>.ToNumeric(byte[] value, int startIndex) => BitConverter.ToUInt32(value, startIndex);
            byte[] INumericBitConverter<UInt32M>.GetBytes(UInt32M value) => BitConverter.GetBytes(value._value);

            bool IConvert<UInt32M>.ToBoolean(UInt32M value) => value._value != 0;
            byte IConvert<UInt32M>.ToByte(UInt32M value, Conversion mode) => ConvertN.ToByte(value._value, mode.Clamped());
            decimal IConvert<UInt32M>.ToDecimal(UInt32M value, Conversion mode) => ConvertN.ToDecimal(value._value, mode.Clamped());
            double IConvert<UInt32M>.ToDouble(UInt32M value, Conversion mode) => ConvertN.ToDouble(value._value, mode.Clamped());
            float IConvert<UInt32M>.ToSingle(UInt32M value, Conversion mode) => ConvertN.ToSingle(value._value, mode.Clamped());
            int IConvert<UInt32M>.ToInt32(UInt32M value, Conversion mode) => ConvertN.ToInt32(value._value, mode.Clamped());
            long IConvert<UInt32M>.ToInt64(UInt32M value, Conversion mode) => ConvertN.ToInt64(value._value, mode.Clamped());
            sbyte IConvertExtended<UInt32M>.ToSByte(UInt32M value, Conversion mode) => ConvertN.ToSByte(value._value, mode.Clamped());
            short IConvert<UInt32M>.ToInt16(UInt32M value, Conversion mode) => ConvertN.ToInt16(value._value, mode.Clamped());
            string IConvert<UInt32M>.ToString(UInt32M value) => Convert.ToString(value._value);
            uint IConvertExtended<UInt32M>.ToUInt32(UInt32M value, Conversion mode) => value._value;
            ulong IConvertExtended<UInt32M>.ToUInt64(UInt32M value, Conversion mode) => ConvertN.ToUInt64(value._value, mode.Clamped());
            ushort IConvertExtended<UInt32M>.ToUInt16(UInt32M value, Conversion mode) => ConvertN.ToUInt16(value._value, mode.Clamped());

            UInt32M IConvert<UInt32M>.ToNumeric(bool value) => value ? 1 : (uint)0;
            UInt32M IConvert<UInt32M>.ToNumeric(byte value, Conversion mode) => ConvertN.ToUInt32(value, mode.Clamped());
            UInt32M IConvert<UInt32M>.ToNumeric(decimal value, Conversion mode) => ConvertN.ToUInt32(value, mode.Clamped());
            UInt32M IConvert<UInt32M>.ToNumeric(double value, Conversion mode) => ConvertN.ToUInt32(value, mode.Clamped());
            UInt32M IConvert<UInt32M>.ToNumeric(float value, Conversion mode) => ConvertN.ToUInt32(value, mode.Clamped());
            UInt32M IConvert<UInt32M>.ToNumeric(int value, Conversion mode) => ConvertN.ToUInt32(value, mode.Clamped());
            UInt32M IConvert<UInt32M>.ToNumeric(long value, Conversion mode) => ConvertN.ToUInt32(value, mode.Clamped());
            UInt32M IConvertExtended<UInt32M>.ToValue(sbyte value, Conversion mode) => ConvertN.ToUInt32(value, mode.Clamped());
            UInt32M IConvert<UInt32M>.ToNumeric(short value, Conversion mode) => ConvertN.ToUInt32(value, mode.Clamped());
            UInt32M IConvert<UInt32M>.ToNumeric(string value) => Convert.ToUInt32(value);
            UInt32M IConvertExtended<UInt32M>.ToNumeric(uint value, Conversion mode) => value;
            UInt32M IConvertExtended<UInt32M>.ToNumeric(ulong value, Conversion mode) => ConvertN.ToUInt32(value, mode.Clamped());
            UInt32M IConvertExtended<UInt32M>.ToNumeric(ushort value, Conversion mode) => ConvertN.ToUInt32(value, mode.Clamped());

            UInt32M INumericStatic<UInt32M>.Parse(string s, NumberStyles? style, IFormatProvider? provider)
                => Parse(s, style ?? NumberStyles.Integer, provider);

            UInt32M INumericRandom<UInt32M>.Generate(Random random) => random.NextUInt32();
            UInt32M INumericRandom<UInt32M>.Generate(Random random, UInt32M maxValue) => random.NextUInt32(maxValue);
            UInt32M INumericRandom<UInt32M>.Generate(Random random, UInt32M minValue, UInt32M maxValue) => random.NextUInt32(minValue, maxValue);
            UInt32M INumericRandom<UInt32M>.Generate(Random random, Generation mode) => random.NextUInt32(mode);
            UInt32M INumericRandom<UInt32M>.Generate(Random random, UInt32M minValue, UInt32M maxValue, Generation mode) => random.NextUInt32(minValue, maxValue, mode);

            UInt32M IVariantRandom<UInt32M>.Generate(Random random, Variants variants) => random.NextUInt32(variants);
        }
    }
}
