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
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Runtime.Serialization;
using Jodo.Primitives;
using Jodo.Primitives.Compatibility;

namespace Jodo.Numerics
{
    [Serializable]
    [DebuggerDisplay("{ToString(),nq}")]
    [SuppressMessage("Style", "IDE1006:Naming Styles")]
    [SuppressMessage("csharpsquid", "S101")]
    public readonly struct xlong : INumericExtended<xlong>
    {
        public static readonly xlong MaxValue = new xlong(long.MaxValue);
        public static readonly xlong MinValue = new xlong(long.MinValue);

        private readonly long _value;

        private xlong(long value)
        {
            _value = value;
        }

        private xlong(SerializationInfo info, StreamingContext context) : this(info.GetInt64(nameof(xlong))) { }
        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context) => info.AddValue(nameof(xlong), _value);

        public int CompareTo(xlong other) => _value.CompareTo(other._value);
        public int CompareTo(object? obj) => obj is xlong other ? CompareTo(other) : 1;
        public bool Equals(xlong other) => _value == other._value;
        public override bool Equals(object? obj) => obj is xlong other && Equals(other);
        public override int GetHashCode() => _value.GetHashCode();
        public override string ToString() => _value.ToString();
        public string ToString(IFormatProvider formatProvider) => _value.ToString(formatProvider);
        public string ToString(string format) => _value.ToString(format);
        public string ToString(string? format, IFormatProvider? formatProvider) => _value.ToString(format, formatProvider);

        public static bool TryParse(string s, IFormatProvider? provider, out xlong result) => Try.Run(() => Parse(s, provider), out result);
        public static bool TryParse(string s, NumberStyles style, IFormatProvider? provider, out xlong result) => Try.Run(() => Parse(s, style, provider), out result);
        public static bool TryParse(string s, NumberStyles style, out xlong result) => Try.Run(() => Parse(s, style), out result);
        public static bool TryParse(string s, out xlong result) => Try.Run(() => Parse(s), out result);
        public static xlong Parse(string s) => long.Parse(s);
        public static xlong Parse(string s, IFormatProvider? provider) => long.Parse(s, provider);
        public static xlong Parse(string s, NumberStyles style) => long.Parse(s, style);
        public static xlong Parse(string s, NumberStyles style, IFormatProvider? provider) => long.Parse(s, style, provider);

        [CLSCompliant(false)] public static explicit operator xlong(ulong value) => new xlong((long)value);
        [CLSCompliant(false)] public static implicit operator xlong(sbyte value) => new xlong(value);
        [CLSCompliant(false)] public static implicit operator xlong(uint value) => new xlong(value);
        [CLSCompliant(false)] public static implicit operator xlong(ushort value) => new xlong(value);
        public static explicit operator xlong(decimal value) => new xlong((long)value);
        public static explicit operator xlong(double value) => new xlong((long)value);
        public static explicit operator xlong(float value) => new xlong((long)value);
        public static implicit operator xlong(byte value) => new xlong(value);
        public static implicit operator xlong(int value) => new xlong(value);
        public static implicit operator xlong(long value) => new xlong(value);
        public static implicit operator xlong(short value) => new xlong(value);

        [CLSCompliant(false)] public static explicit operator sbyte(xlong value) => (sbyte)value._value;
        [CLSCompliant(false)] public static explicit operator uint(xlong value) => (uint)value._value;
        [CLSCompliant(false)] public static explicit operator ulong(xlong value) => (ulong)value._value;
        [CLSCompliant(false)] public static explicit operator ushort(xlong value) => (ushort)value._value;
        public static explicit operator byte(xlong value) => (byte)value._value;
        public static explicit operator int(xlong value) => (int)value._value;
        public static explicit operator short(xlong value) => (short)value._value;
        public static implicit operator decimal(xlong value) => value._value;
        public static implicit operator double(xlong value) => value._value;
        public static implicit operator float(xlong value) => value._value;
        public static implicit operator long(xlong value) => value._value;

        public static bool operator !=(xlong left, xlong right) => left._value != right._value;
        public static bool operator <(xlong left, xlong right) => left._value < right._value;
        public static bool operator <=(xlong left, xlong right) => left._value <= right._value;
        public static bool operator ==(xlong left, xlong right) => left._value == right._value;
        public static bool operator >(xlong left, xlong right) => left._value > right._value;
        public static bool operator >=(xlong left, xlong right) => left._value >= right._value;
        public static xlong operator %(xlong left, xlong right) => left._value % right._value;
        public static xlong operator &(xlong left, xlong right) => left._value & right._value;
        public static xlong operator -(xlong left, xlong right) => left._value - right._value;
        public static xlong operator --(xlong value) => value._value - 1;
        public static xlong operator -(xlong value) => -value._value;
        public static xlong operator *(xlong left, xlong right) => left._value * right._value;
        public static xlong operator /(xlong left, xlong right) => left._value / right._value;
        public static xlong operator ^(xlong left, xlong right) => left._value ^ right._value;
        public static xlong operator |(xlong left, xlong right) => left._value | right._value;
        public static xlong operator ~(xlong value) => ~value._value;
        public static xlong operator +(xlong left, xlong right) => left._value + right._value;
        public static xlong operator +(xlong value) => value;
        public static xlong operator ++(xlong value) => value._value + 1;
        public static xlong operator <<(xlong left, int right) => left._value << right;
        public static xlong operator >>(xlong left, int right) => left._value >> right;

        bool INumeric<xlong>.IsGreaterThan(xlong value) => this > value;
        bool INumeric<xlong>.IsGreaterThanOrEqualTo(xlong value) => this >= value;
        bool INumeric<xlong>.IsLessThan(xlong value) => this < value;
        bool INumeric<xlong>.IsLessThanOrEqualTo(xlong value) => this <= value;
        xlong INumeric<xlong>.Add(xlong value) => this + value;
        xlong INumeric<xlong>.BitwiseComplement() => ~this;
        xlong INumeric<xlong>.Divide(xlong value) => this / value;
        xlong INumeric<xlong>.LeftShift(int count) => this << count;
        xlong INumeric<xlong>.LogicalAnd(xlong value) => this & value;
        xlong INumeric<xlong>.LogicalExclusiveOr(xlong value) => this ^ value;
        xlong INumeric<xlong>.LogicalOr(xlong value) => this | value;
        xlong INumeric<xlong>.Multiply(xlong value) => this * value;
        xlong INumeric<xlong>.Negative() => -this;
        xlong INumeric<xlong>.Positive() => +this;
        xlong INumeric<xlong>.Remainder(xlong value) => this % value;
        xlong INumeric<xlong>.RightShift(int count) => this >> count;
        xlong INumeric<xlong>.Subtract(xlong value) => this - value;

        IBitConverter<xlong> IProvider<IBitConverter<xlong>>.GetInstance() => Utilities.Instance;
        IConvert<xlong> IProvider<IConvert<xlong>>.GetInstance() => Utilities.Instance;
        IConvertUnsigned<xlong> IProvider<IConvertUnsigned<xlong>>.GetInstance() => Utilities.Instance;
        IMath<xlong> IProvider<IMath<xlong>>.GetInstance() => Utilities.Instance;
        INumericStatic<xlong> IProvider<INumericStatic<xlong>>.GetInstance() => Utilities.Instance;
        IRandom<xlong> IProvider<IRandom<xlong>>.GetInstance() => Utilities.Instance;
        IParser<xlong> IProvider<IParser<xlong>>.GetInstance() => Utilities.Instance;

        private sealed class Utilities :
            IBitConverter<xlong>,
            IConvert<xlong>,
            IConvertUnsigned<xlong>,
            IMath<xlong>,
            INumericStatic<xlong>,
            IRandom<xlong>,
            IParser<xlong>
        {
            public static readonly Utilities Instance = new Utilities();

            bool INumericStatic<xlong>.HasFloatingPoint { get; } = false;
            bool INumericStatic<xlong>.HasInfinity { get; } = false;
            bool INumericStatic<xlong>.HasNaN { get; } = false;
            bool INumericStatic<xlong>.IsFinite(xlong x) => true;
            bool INumericStatic<xlong>.IsInfinity(xlong x) => false;
            bool INumericStatic<xlong>.IsNaN(xlong x) => false;
            bool INumericStatic<xlong>.IsNegative(xlong x) => x._value < 0;
            bool INumericStatic<xlong>.IsNegativeInfinity(xlong x) => false;
            bool INumericStatic<xlong>.IsNormal(xlong x) => false;
            bool INumericStatic<xlong>.IsPositiveInfinity(xlong x) => false;
            bool INumericStatic<xlong>.IsReal { get; } = false;
            bool INumericStatic<xlong>.IsSigned { get; } = true;
            bool INumericStatic<xlong>.IsSubnormal(xlong x) => false;
            xlong INumericStatic<xlong>.Epsilon { get; } = 1L;
            xlong INumericStatic<xlong>.MaxUnit { get; } = 1L;
            xlong INumericStatic<xlong>.MaxValue => MaxValue;
            xlong INumericStatic<xlong>.MinUnit { get; } = -1L;
            xlong INumericStatic<xlong>.MinValue => MinValue;
            xlong INumericStatic<xlong>.One { get; } = 1L;
            xlong INumericStatic<xlong>.Ten { get; } = 10L;
            xlong INumericStatic<xlong>.Two { get; } = 2L;
            xlong INumericStatic<xlong>.Zero { get; } = 0;

            int IMath<xlong>.Sign(xlong x) => Math.Sign(x._value);
            xlong IMath<xlong>.Abs(xlong value) => Math.Abs(value);
            xlong IMath<xlong>.Acos(xlong x) => (xlong)Math.Acos(x);
            xlong IMath<xlong>.Acosh(xlong x) => (xlong)MathCompat.Acosh(x);
            xlong IMath<xlong>.Asin(xlong x) => (xlong)Math.Asin(x);
            xlong IMath<xlong>.Asinh(xlong x) => (xlong)MathCompat.Asinh(x);
            xlong IMath<xlong>.Atan(xlong x) => (xlong)Math.Atan(x);
            xlong IMath<xlong>.Atan2(xlong y, xlong x) => (xlong)Math.Atan2(y, x);
            xlong IMath<xlong>.Atanh(xlong x) => (xlong)MathCompat.Atanh(x);
            xlong IMath<xlong>.Cbrt(xlong x) => (xlong)MathCompat.Cbrt(x);
            xlong IMath<xlong>.Ceiling(xlong x) => x;
            xlong IMath<xlong>.Clamp(xlong x, xlong bound1, xlong bound2) => bound1 > bound2 ? Math.Min(bound1, Math.Max(bound2, x)) : Math.Min(bound2, Math.Max(bound1, x));
            xlong IMath<xlong>.Cos(xlong x) => (xlong)Math.Cos(x);
            xlong IMath<xlong>.Cosh(xlong x) => (xlong)Math.Cosh(x);
            xlong IMath<xlong>.DegreesToRadians(xlong x) => (xlong)(x * NumericUtilities.RadiansPerDegree);
            xlong IMath<xlong>.E { get; } = 2L;
            xlong IMath<xlong>.Exp(xlong x) => (xlong)Math.Exp(x);
            xlong IMath<xlong>.Floor(xlong x) => x;
            xlong IMath<xlong>.IEEERemainder(xlong x, xlong y) => (xlong)Math.IEEERemainder(x, y);
            xlong IMath<xlong>.Log(xlong x) => (xlong)Math.Log(x);
            xlong IMath<xlong>.Log(xlong x, xlong y) => (xlong)Math.Log(x, y);
            xlong IMath<xlong>.Log10(xlong x) => (xlong)Math.Log10(x);
            xlong IMath<xlong>.Max(xlong x, xlong y) => Math.Max(x, y);
            xlong IMath<xlong>.Min(xlong x, xlong y) => Math.Min(x, y);
            xlong IMath<xlong>.PI { get; } = 3L;
            xlong IMath<xlong>.Pow(xlong x, xlong y) => y == 1 ? x : (xlong)Math.Pow(x, y);
            xlong IMath<xlong>.RadiansToDegrees(xlong x) => (xlong)(x * NumericUtilities.DegreesPerRadian);
            xlong IMath<xlong>.Round(xlong x) => x;
            xlong IMath<xlong>.Round(xlong x, int digits) => x;
            xlong IMath<xlong>.Round(xlong x, int digits, MidpointRounding mode) => x;
            xlong IMath<xlong>.Round(xlong x, MidpointRounding mode) => x;
            xlong IMath<xlong>.Sin(xlong x) => (xlong)Math.Sin(x);
            xlong IMath<xlong>.Sinh(xlong x) => (xlong)Math.Sinh(x);
            xlong IMath<xlong>.Sqrt(xlong x) => (xlong)Math.Sqrt(x);
            xlong IMath<xlong>.Tan(xlong x) => (xlong)Math.Tan(x);
            xlong IMath<xlong>.Tanh(xlong x) => (xlong)Math.Tanh(x);
            xlong IMath<xlong>.Tau { get; } = 6L;
            xlong IMath<xlong>.Truncate(xlong x) => x;

            xlong IBitConverter<xlong>.Read(IReadOnlyStream<byte> stream) => BitConverter.ToInt64(stream.Read(sizeof(long)), 0);
            void IBitConverter<xlong>.Write(xlong value, IWriteOnlyStream<byte> stream) => stream.Write(BitConverter.GetBytes(value._value));

            xlong IRandom<xlong>.Next(Random random) => random.NextInt64();
            xlong IRandom<xlong>.Next(Random random, xlong bound1, xlong bound2) => random.NextInt64(bound1._value, bound2._value);

            bool IConvert<xlong>.ToBoolean(xlong value) => Convert.ToBoolean(value._value);
            byte IConvert<xlong>.ToByte(xlong value, Conversion mode) => NumericConvert.ToByte(value._value, mode);
            decimal IConvert<xlong>.ToDecimal(xlong value, Conversion mode) => NumericConvert.ToDecimal(value._value, mode);
            double IConvert<xlong>.ToDouble(xlong value, Conversion mode) => NumericConvert.ToDouble(value._value, mode);
            float IConvert<xlong>.ToSingle(xlong value, Conversion mode) => NumericConvert.ToSingle(value._value, mode);
            int IConvert<xlong>.ToInt32(xlong value, Conversion mode) => NumericConvert.ToInt32(value._value, mode);
            long IConvert<xlong>.ToInt64(xlong value, Conversion mode) => value._value;
            sbyte IConvertUnsigned<xlong>.ToSByte(xlong value, Conversion mode) => NumericConvert.ToSByte(value._value, mode);
            short IConvert<xlong>.ToInt16(xlong value, Conversion mode) => NumericConvert.ToInt16(value._value, mode);
            string IConvert<xlong>.ToString(xlong value) => Convert.ToString(value._value);
            uint IConvertUnsigned<xlong>.ToUInt32(xlong value, Conversion mode) => NumericConvert.ToUInt32(value._value, mode);
            ulong IConvertUnsigned<xlong>.ToUInt64(xlong value, Conversion mode) => NumericConvert.ToUInt64(value._value, mode);
            ushort IConvertUnsigned<xlong>.ToUInt16(xlong value, Conversion mode) => NumericConvert.ToUInt16(value._value, mode);

            xlong IConvert<xlong>.ToValue(bool value) => Convert.ToInt64(value);
            xlong IConvert<xlong>.ToValue(byte value, Conversion mode) => NumericConvert.ToInt64(value, mode);
            xlong IConvert<xlong>.ToValue(decimal value, Conversion mode) => NumericConvert.ToInt64(value, mode);
            xlong IConvert<xlong>.ToValue(double value, Conversion mode) => NumericConvert.ToInt64(value, mode);
            xlong IConvert<xlong>.ToValue(float value, Conversion mode) => NumericConvert.ToInt64(value, mode);
            xlong IConvert<xlong>.ToValue(int value, Conversion mode) => NumericConvert.ToInt64(value, mode);
            xlong IConvert<xlong>.ToValue(long value, Conversion mode) => value;
            xlong IConvertUnsigned<xlong>.ToValue(sbyte value, Conversion mode) => NumericConvert.ToInt64(value, mode);
            xlong IConvert<xlong>.ToValue(short value, Conversion mode) => NumericConvert.ToInt64(value, mode);
            xlong IConvert<xlong>.ToValue(string value) => Convert.ToInt64(value);
            xlong IConvertUnsigned<xlong>.ToNumeric(uint value, Conversion mode) => NumericConvert.ToInt64(value, mode);
            xlong IConvertUnsigned<xlong>.ToNumeric(ulong value, Conversion mode) => NumericConvert.ToInt64(value, mode);
            xlong IConvertUnsigned<xlong>.ToNumeric(ushort value, Conversion mode) => NumericConvert.ToInt64(value, mode);

            xlong IParser<xlong>.Parse(string s) => Parse(s);
            xlong IParser<xlong>.Parse(string s, NumberStyles style, IFormatProvider? provider) => Parse(s, style, provider);
        }
    }
}
