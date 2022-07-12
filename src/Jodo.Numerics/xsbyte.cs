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
    public readonly struct xsbyte : INumericExtended<xsbyte>
    {
        public static readonly xsbyte MaxValue = new xsbyte(sbyte.MaxValue);
        public static readonly xsbyte MinValue = new xsbyte(sbyte.MinValue);

        private readonly sbyte _value;

        private xsbyte(sbyte value)
        {
            _value = value;
        }

        private xsbyte(SerializationInfo info, StreamingContext context) : this(info.GetSByte(nameof(xsbyte))) { }
        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context) => info.AddValue(nameof(xsbyte), _value);

        public int CompareTo(xsbyte other) => _value.CompareTo(other._value);
        public int CompareTo(object? obj) => obj is xsbyte other ? CompareTo(other) : 1;
        public bool Equals(xsbyte other) => _value == other._value;
        public override bool Equals(object? obj) => obj is xsbyte other && Equals(other);
        public override int GetHashCode() => _value.GetHashCode();
        public override string ToString() => _value.ToString();
        public string ToString(IFormatProvider formatProvider) => _value.ToString(formatProvider);
        public string ToString(string format) => _value.ToString(format);
        public string ToString(string? format, IFormatProvider? formatProvider) => _value.ToString(format, formatProvider);

        public static bool TryParse(string s, IFormatProvider? provider, out xsbyte result) => Try.Run(() => Parse(s, provider), out result);
        public static bool TryParse(string s, NumberStyles style, IFormatProvider? provider, out xsbyte result) => Try.Run(() => Parse(s, style, provider), out result);
        public static bool TryParse(string s, NumberStyles style, out xsbyte result) => Try.Run(() => Parse(s, style), out result);
        public static bool TryParse(string s, out xsbyte result) => Try.Run(() => Parse(s), out result);
        public static xsbyte Parse(string s) => sbyte.Parse(s);
        public static xsbyte Parse(string s, IFormatProvider? provider) => sbyte.Parse(s, provider);
        public static xsbyte Parse(string s, NumberStyles style) => sbyte.Parse(s, style);
        public static xsbyte Parse(string s, NumberStyles style, IFormatProvider? provider) => sbyte.Parse(s, style, provider);

        [CLSCompliant(false)] public static explicit operator xsbyte(uint value) => new xsbyte((sbyte)value);
        [CLSCompliant(false)] public static explicit operator xsbyte(ulong value) => new xsbyte((sbyte)value);
        [CLSCompliant(false)] public static explicit operator xsbyte(ushort value) => new xsbyte((sbyte)value);
        [CLSCompliant(false)] public static implicit operator xsbyte(sbyte value) => new xsbyte(value);
        public static explicit operator xsbyte(byte value) => new xsbyte((sbyte)value);
        public static explicit operator xsbyte(decimal value) => new xsbyte((sbyte)value);
        public static explicit operator xsbyte(double value) => new xsbyte((sbyte)value);
        public static explicit operator xsbyte(float value) => new xsbyte((sbyte)value);
        public static explicit operator xsbyte(int value) => new xsbyte((sbyte)value);
        public static explicit operator xsbyte(long value) => new xsbyte((sbyte)value);
        public static explicit operator xsbyte(short value) => new xsbyte((sbyte)value);

        [CLSCompliant(false)] public static explicit operator uint(xsbyte value) => (uint)value._value;
        [CLSCompliant(false)] public static explicit operator ulong(xsbyte value) => (ulong)value._value;
        [CLSCompliant(false)] public static explicit operator ushort(xsbyte value) => (ushort)value._value;
        [CLSCompliant(false)] public static implicit operator sbyte(xsbyte value) => value._value;
        public static explicit operator byte(xsbyte value) => (byte)value._value;
        public static implicit operator decimal(xsbyte value) => value._value;
        public static implicit operator double(xsbyte value) => value._value;
        public static implicit operator float(xsbyte value) => value._value;
        public static implicit operator int(xsbyte value) => value._value;
        public static implicit operator long(xsbyte value) => value._value;
        public static implicit operator short(xsbyte value) => value._value;

        public static bool operator !=(xsbyte left, xsbyte right) => left._value != right._value;
        public static bool operator <(xsbyte left, xsbyte right) => left._value < right._value;
        public static bool operator <=(xsbyte left, xsbyte right) => left._value <= right._value;
        public static bool operator ==(xsbyte left, xsbyte right) => left._value == right._value;
        public static bool operator >(xsbyte left, xsbyte right) => left._value > right._value;
        public static bool operator >=(xsbyte left, xsbyte right) => left._value >= right._value;
        public static xsbyte operator %(xsbyte left, xsbyte right) => (sbyte)(left._value % right._value);
        public static xsbyte operator &(xsbyte left, xsbyte right) => (sbyte)(left._value & right._value);
        public static xsbyte operator -(xsbyte left, xsbyte right) => (sbyte)(left._value - right._value);
        public static xsbyte operator --(xsbyte value) => (sbyte)(value._value - 1);
        public static xsbyte operator -(xsbyte value) => (sbyte)-value._value;
        public static xsbyte operator *(xsbyte left, xsbyte right) => (sbyte)(left._value * right._value);
        public static xsbyte operator /(xsbyte left, xsbyte right) => (sbyte)(left._value / right._value);
        public static xsbyte operator ^(xsbyte left, xsbyte right) => (sbyte)(left._value ^ right._value);
        public static xsbyte operator |(xsbyte left, xsbyte right) => (sbyte)(left._value | right._value);
        public static xsbyte operator ~(xsbyte value) => (sbyte)~value._value;
        public static xsbyte operator +(xsbyte left, xsbyte right) => (sbyte)(left._value + right._value);
        public static xsbyte operator +(xsbyte value) => value;
        public static xsbyte operator ++(xsbyte value) => (sbyte)(value._value + 1);
        public static xsbyte operator <<(xsbyte left, int right) => (sbyte)(left._value << right);
        public static xsbyte operator >>(xsbyte left, int right) => (sbyte)(left._value >> right);

        bool INumeric<xsbyte>.IsGreaterThan(xsbyte value) => this > value;
        bool INumeric<xsbyte>.IsGreaterThanOrEqualTo(xsbyte value) => this >= value;
        bool INumeric<xsbyte>.IsLessThan(xsbyte value) => this < value;
        bool INumeric<xsbyte>.IsLessThanOrEqualTo(xsbyte value) => this <= value;
        xsbyte INumeric<xsbyte>.Add(xsbyte value) => this + value;
        xsbyte INumeric<xsbyte>.BitwiseComplement() => ~this;
        xsbyte INumeric<xsbyte>.Divide(xsbyte value) => this / value;
        xsbyte INumeric<xsbyte>.LeftShift(int count) => this << count;
        xsbyte INumeric<xsbyte>.LogicalAnd(xsbyte value) => this & value;
        xsbyte INumeric<xsbyte>.LogicalExclusiveOr(xsbyte value) => this ^ value;
        xsbyte INumeric<xsbyte>.LogicalOr(xsbyte value) => this | value;
        xsbyte INumeric<xsbyte>.Multiply(xsbyte value) => this * value;
        xsbyte INumeric<xsbyte>.Negative() => -this;
        xsbyte INumeric<xsbyte>.Positive() => +this;
        xsbyte INumeric<xsbyte>.Remainder(xsbyte value) => this % value;
        xsbyte INumeric<xsbyte>.RightShift(int count) => this >> count;
        xsbyte INumeric<xsbyte>.Subtract(xsbyte value) => this - value;

        IBitConverter<xsbyte> IProvider<IBitConverter<xsbyte>>.GetInstance() => Utilities.Instance;
        IConvert<xsbyte> IProvider<IConvert<xsbyte>>.GetInstance() => Utilities.Instance;
        IConvertUnsigned<xsbyte> IProvider<IConvertUnsigned<xsbyte>>.GetInstance() => Utilities.Instance;
        IMath<xsbyte> IProvider<IMath<xsbyte>>.GetInstance() => Utilities.Instance;
        INumericStatic<xsbyte> IProvider<INumericStatic<xsbyte>>.GetInstance() => Utilities.Instance;
        IRandom<xsbyte> IProvider<IRandom<xsbyte>>.GetInstance() => Utilities.Instance;
        IParser<xsbyte> IProvider<IParser<xsbyte>>.GetInstance() => Utilities.Instance;

        private sealed class Utilities :
            IBitConverter<xsbyte>,
            IConvert<xsbyte>,
            IConvertUnsigned<xsbyte>,
            IMath<xsbyte>,
            INumericStatic<xsbyte>,
            IRandom<xsbyte>,
            IParser<xsbyte>
        {
            public static readonly Utilities Instance = new Utilities();

            bool INumericStatic<xsbyte>.HasFloatingPoint { get; } = false;
            bool INumericStatic<xsbyte>.HasInfinity { get; } = false;
            bool INumericStatic<xsbyte>.HasNaN { get; } = false;
            bool INumericStatic<xsbyte>.IsFinite(xsbyte x) => true;
            bool INumericStatic<xsbyte>.IsInfinity(xsbyte x) => false;
            bool INumericStatic<xsbyte>.IsNaN(xsbyte x) => false;
            bool INumericStatic<xsbyte>.IsNegative(xsbyte x) => x._value < 0;
            bool INumericStatic<xsbyte>.IsNegativeInfinity(xsbyte x) => false;
            bool INumericStatic<xsbyte>.IsNormal(xsbyte x) => false;
            bool INumericStatic<xsbyte>.IsPositiveInfinity(xsbyte x) => false;
            bool INumericStatic<xsbyte>.IsReal { get; } = false;
            bool INumericStatic<xsbyte>.IsSigned { get; } = true;
            bool INumericStatic<xsbyte>.IsSubnormal(xsbyte x) => false;
            xsbyte INumericStatic<xsbyte>.Epsilon { get; } = 1;
            xsbyte INumericStatic<xsbyte>.MaxUnit { get; } = 1;
            xsbyte INumericStatic<xsbyte>.MaxValue => MaxValue;
            xsbyte INumericStatic<xsbyte>.MinUnit { get; } = -1;
            xsbyte INumericStatic<xsbyte>.MinValue => MinValue;
            xsbyte INumericStatic<xsbyte>.One { get; } = 1;
            xsbyte INumericStatic<xsbyte>.Ten { get; } = 10;
            xsbyte INumericStatic<xsbyte>.Two { get; } = 2;
            xsbyte INumericStatic<xsbyte>.Zero { get; } = 0;

            int IMath<xsbyte>.Sign(xsbyte x) => Math.Sign(x._value);
            xsbyte IMath<xsbyte>.Abs(xsbyte value) => Math.Abs(value._value);
            xsbyte IMath<xsbyte>.Acos(xsbyte x) => (sbyte)Math.Acos(x._value);
            xsbyte IMath<xsbyte>.Acosh(xsbyte x) => (sbyte)MathCompat.Acosh(x._value);
            xsbyte IMath<xsbyte>.Asin(xsbyte x) => (sbyte)Math.Asin(x._value);
            xsbyte IMath<xsbyte>.Asinh(xsbyte x) => (sbyte)MathCompat.Asinh(x._value);
            xsbyte IMath<xsbyte>.Atan(xsbyte x) => (sbyte)Math.Atan(x._value);
            xsbyte IMath<xsbyte>.Atan2(xsbyte x, xsbyte y) => (sbyte)Math.Atan2(x._value, y._value);
            xsbyte IMath<xsbyte>.Atanh(xsbyte x) => (sbyte)MathCompat.Atanh(x._value);
            xsbyte IMath<xsbyte>.Cbrt(xsbyte x) => (sbyte)MathCompat.Cbrt(x._value);
            xsbyte IMath<xsbyte>.Ceiling(xsbyte x) => x;
            xsbyte IMath<xsbyte>.Clamp(xsbyte x, xsbyte bound1, xsbyte bound2) => bound1 > bound2 ? Math.Min(bound1._value, Math.Max(bound2._value, x._value)) : Math.Min(bound2._value, Math.Max(bound1._value, x._value));
            xsbyte IMath<xsbyte>.Cos(xsbyte x) => (sbyte)Math.Cos(x._value);
            xsbyte IMath<xsbyte>.Cosh(xsbyte x) => (sbyte)Math.Cosh(x._value);
            xsbyte IMath<xsbyte>.DegreesToRadians(xsbyte x) => (sbyte)(x * NumericUtilities.RadiansPerDegree);
            xsbyte IMath<xsbyte>.E { get; } = 2;
            xsbyte IMath<xsbyte>.Exp(xsbyte x) => (sbyte)Math.Exp(x._value);
            xsbyte IMath<xsbyte>.Floor(xsbyte x) => x;
            xsbyte IMath<xsbyte>.IEEERemainder(xsbyte x, xsbyte y) => (sbyte)Math.IEEERemainder(x._value, y._value);
            xsbyte IMath<xsbyte>.Log(xsbyte x) => (sbyte)Math.Log(x._value);
            xsbyte IMath<xsbyte>.Log(xsbyte x, xsbyte y) => (sbyte)Math.Log(x._value, y._value);
            xsbyte IMath<xsbyte>.Log10(xsbyte x) => (sbyte)Math.Log10(x._value);
            xsbyte IMath<xsbyte>.Max(xsbyte x, xsbyte y) => Math.Max(x._value, y._value);
            xsbyte IMath<xsbyte>.Min(xsbyte x, xsbyte y) => Math.Min(x._value, y._value);
            xsbyte IMath<xsbyte>.PI { get; } = 3;
            xsbyte IMath<xsbyte>.Pow(xsbyte x, xsbyte y) => (sbyte)Math.Pow(x._value, y._value);
            xsbyte IMath<xsbyte>.RadiansToDegrees(xsbyte x) => (sbyte)(x * NumericUtilities.DegreesPerRadian);
            xsbyte IMath<xsbyte>.Round(xsbyte x) => x;
            xsbyte IMath<xsbyte>.Round(xsbyte x, int digits) => x;
            xsbyte IMath<xsbyte>.Round(xsbyte x, int digits, MidpointRounding mode) => x;
            xsbyte IMath<xsbyte>.Round(xsbyte x, MidpointRounding mode) => x;
            xsbyte IMath<xsbyte>.Sin(xsbyte x) => (sbyte)Math.Sin(x._value);
            xsbyte IMath<xsbyte>.Sinh(xsbyte x) => (sbyte)Math.Sinh(x._value);
            xsbyte IMath<xsbyte>.Sqrt(xsbyte x) => (sbyte)Math.Sqrt(x._value);
            xsbyte IMath<xsbyte>.Tan(xsbyte x) => (sbyte)Math.Tan(x._value);
            xsbyte IMath<xsbyte>.Tanh(xsbyte x) => (sbyte)Math.Tanh(x._value);
            xsbyte IMath<xsbyte>.Tau { get; } = 6;
            xsbyte IMath<xsbyte>.Truncate(xsbyte x) => x;

            xsbyte IBitConverter<xsbyte>.Read(IReadOnlyStream<byte> stream) => unchecked((sbyte)stream.Read(1)[0]);
            void IBitConverter<xsbyte>.Write(xsbyte value, IWriteOnlyStream<byte> stream) => stream.Write(BitConverter.GetBytes(value._value));

            xsbyte IRandom<xsbyte>.Next(Random random) => random.NextSByte();
            xsbyte IRandom<xsbyte>.Next(Random random, xsbyte bound1, xsbyte bound2) => random.NextSByte(bound1._value, bound2._value);

            bool IConvert<xsbyte>.ToBoolean(xsbyte value) => Convert.ToBoolean(value._value);
            byte IConvert<xsbyte>.ToByte(xsbyte value, Conversion mode) => NumericConvert.ToByte(value._value, mode);
            decimal IConvert<xsbyte>.ToDecimal(xsbyte value, Conversion mode) => NumericConvert.ToDecimal(value._value, mode);
            double IConvert<xsbyte>.ToDouble(xsbyte value, Conversion mode) => NumericConvert.ToDouble(value._value, mode);
            float IConvert<xsbyte>.ToSingle(xsbyte value, Conversion mode) => NumericConvert.ToSingle(value._value, mode);
            int IConvert<xsbyte>.ToInt32(xsbyte value, Conversion mode) => NumericConvert.ToInt32(value._value, mode);
            long IConvert<xsbyte>.ToInt64(xsbyte value, Conversion mode) => NumericConvert.ToInt64(value._value, mode);
            sbyte IConvertUnsigned<xsbyte>.ToSByte(xsbyte value, Conversion mode) => NumericConvert.ToSByte(value._value, mode);
            short IConvert<xsbyte>.ToInt16(xsbyte value, Conversion mode) => NumericConvert.ToInt16(value._value, mode);
            string IConvert<xsbyte>.ToString(xsbyte value) => Convert.ToString(value._value);
            uint IConvertUnsigned<xsbyte>.ToUInt32(xsbyte value, Conversion mode) => NumericConvert.ToUInt32(value._value, mode);
            ulong IConvertUnsigned<xsbyte>.ToUInt64(xsbyte value, Conversion mode) => NumericConvert.ToUInt64(value._value, mode);
            ushort IConvertUnsigned<xsbyte>.ToUInt16(xsbyte value, Conversion mode) => NumericConvert.ToUInt16(value._value, mode);

            xsbyte IConvert<xsbyte>.ToValue(bool value) => Convert.ToSByte(value);
            xsbyte IConvert<xsbyte>.ToValue(byte value, Conversion mode) => NumericConvert.ToSByte(value, mode);
            xsbyte IConvert<xsbyte>.ToValue(decimal value, Conversion mode) => NumericConvert.ToSByte(value, mode);
            xsbyte IConvert<xsbyte>.ToValue(double value, Conversion mode) => NumericConvert.ToSByte(value, mode);
            xsbyte IConvert<xsbyte>.ToValue(float value, Conversion mode) => NumericConvert.ToSByte(value, mode);
            xsbyte IConvert<xsbyte>.ToValue(int value, Conversion mode) => NumericConvert.ToSByte(value, mode);
            xsbyte IConvert<xsbyte>.ToValue(long value, Conversion mode) => NumericConvert.ToSByte(value, mode);
            xsbyte IConvertUnsigned<xsbyte>.ToValue(sbyte value, Conversion mode) => NumericConvert.ToSByte(value, mode);
            xsbyte IConvert<xsbyte>.ToValue(short value, Conversion mode) => NumericConvert.ToSByte(value, mode);
            xsbyte IConvert<xsbyte>.ToValue(string value) => Convert.ToSByte(value);
            xsbyte IConvertUnsigned<xsbyte>.ToNumeric(uint value, Conversion mode) => NumericConvert.ToSByte(value, mode);
            xsbyte IConvertUnsigned<xsbyte>.ToNumeric(ulong value, Conversion mode) => NumericConvert.ToSByte(value, mode);
            xsbyte IConvertUnsigned<xsbyte>.ToNumeric(ushort value, Conversion mode) => NumericConvert.ToSByte(value, mode);

            xsbyte IParser<xsbyte>.Parse(string s) => Parse(s);
            xsbyte IParser<xsbyte>.Parse(string s, NumberStyles style, IFormatProvider? provider) => Parse(s, style, provider);
        }
    }
}
