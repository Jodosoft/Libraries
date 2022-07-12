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
    public readonly struct xdouble : INumericExtended<xdouble>
    {
        public static readonly xdouble Epsilon = double.Epsilon;
        public static readonly xdouble MaxValue = double.MaxValue;
        public static readonly xdouble MinValue = double.MinValue;

        private readonly double _value;

        private xdouble(double value)
        {
            _value = value;
        }

        private xdouble(SerializationInfo info, StreamingContext context) : this(info.GetDouble(nameof(xdouble))) { }
        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context) => info.AddValue(nameof(xdouble), _value);

        public int CompareTo(xdouble other) => _value.CompareTo(other._value);
        public int CompareTo(object? obj) => obj is xdouble other ? CompareTo(other) : 1;
        public bool Equals(xdouble other) => _value == other._value;
        public override bool Equals(object? obj) => obj is xdouble other && Equals(other);
        public override int GetHashCode() => _value.GetHashCode();
        public override string ToString() => _value.ToString();
        public string ToString(IFormatProvider formatProvider) => _value.ToString(formatProvider);
        public string ToString(string format) => _value.ToString(format);
        public string ToString(string? format, IFormatProvider? formatProvider) => _value.ToString(format, formatProvider);

        public static bool IsFinite(xdouble d) => DoubleCompat.IsFinite(d);
        public static bool IsInfinity(xdouble d) => double.IsInfinity(d);
        public static bool IsNaN(xdouble d) => double.IsNaN(d);
        public static bool IsNegative(xdouble d) => DoubleCompat.IsNegative(d);
        public static bool IsNegativeInfinity(xdouble d) => double.IsNegativeInfinity(d);
        public static bool IsNormal(xdouble d) => DoubleCompat.IsNormal(d);
        public static bool IsPositiveInfinity(xdouble d) => double.IsPositiveInfinity(d);
        public static bool IsSubnormal(xdouble d) => DoubleCompat.IsSubnormal(d);

        public static bool TryParse(string s, IFormatProvider? provider, out xdouble result) => Try.Run(() => Parse(s, provider), out result);
        public static bool TryParse(string s, NumberStyles style, IFormatProvider? provider, out xdouble result) => Try.Run(() => Parse(s, style, provider), out result);
        public static bool TryParse(string s, NumberStyles style, out xdouble result) => Try.Run(() => Parse(s, style), out result);
        public static bool TryParse(string s, out xdouble result) => Try.Run(() => Parse(s), out result);
        public static xdouble Parse(string s) => double.Parse(s);
        public static xdouble Parse(string s, IFormatProvider? provider) => double.Parse(s, provider);
        public static xdouble Parse(string s, NumberStyles style) => double.Parse(s, style);
        public static xdouble Parse(string s, NumberStyles style, IFormatProvider? provider) => double.Parse(s, style, provider);

        [CLSCompliant(false)] public static implicit operator xdouble(sbyte value) => new xdouble(value);
        [CLSCompliant(false)] public static implicit operator xdouble(uint value) => new xdouble(value);
        [CLSCompliant(false)] public static implicit operator xdouble(ulong value) => new xdouble(value);
        [CLSCompliant(false)] public static implicit operator xdouble(ushort value) => new xdouble(value);
        public static explicit operator xdouble(decimal value) => new xdouble((double)value);
        public static implicit operator xdouble(byte value) => new xdouble(value);
        public static implicit operator xdouble(double value) => new xdouble(value);
        public static implicit operator xdouble(float value) => new xdouble(value);
        public static implicit operator xdouble(int value) => new xdouble(value);
        public static implicit operator xdouble(long value) => new xdouble(value);
        public static implicit operator xdouble(short value) => new xdouble(value);

        [CLSCompliant(false)] public static explicit operator sbyte(xdouble value) => (sbyte)value._value;
        [CLSCompliant(false)] public static explicit operator uint(xdouble value) => (uint)value._value;
        [CLSCompliant(false)] public static explicit operator ulong(xdouble value) => (ulong)value._value;
        [CLSCompliant(false)] public static explicit operator ushort(xdouble value) => (ushort)value._value;
        public static explicit operator byte(xdouble value) => (byte)value._value;
        public static explicit operator decimal(xdouble value) => (decimal)value._value;
        public static explicit operator float(xdouble value) => (float)value._value;
        public static explicit operator int(xdouble value) => (int)value._value;
        public static explicit operator long(xdouble value) => (long)value._value;
        public static explicit operator short(xdouble value) => (short)value._value;
        public static implicit operator double(xdouble value) => value._value;

        public static bool operator !=(xdouble left, xdouble right) => left._value != right._value;
        public static bool operator <(xdouble left, xdouble right) => left._value < right._value;
        public static bool operator <=(xdouble left, xdouble right) => left._value <= right._value;
        public static bool operator ==(xdouble left, xdouble right) => left._value == right._value;
        public static bool operator >(xdouble left, xdouble right) => left._value > right._value;
        public static bool operator >=(xdouble left, xdouble right) => left._value >= right._value;
        public static xdouble operator %(xdouble left, xdouble right) => left._value % right._value;
        public static xdouble operator &(xdouble left, xdouble right) => NumericUtilities.LogicalAnd(left._value, right._value);
        public static xdouble operator -(xdouble left, xdouble right) => left._value - right._value;
        public static xdouble operator --(xdouble value) => value._value - 1;
        public static xdouble operator -(xdouble value) => -value._value;
        public static xdouble operator *(xdouble left, xdouble right) => left._value * right._value;
        public static xdouble operator /(xdouble left, xdouble right) => left._value / right._value;
        public static xdouble operator ^(xdouble left, xdouble right) => NumericUtilities.LogicalExclusiveOr(left._value, right._value);
        public static xdouble operator |(xdouble left, xdouble right) => NumericUtilities.LogicalOr(left._value, right._value);
        public static xdouble operator ~(xdouble left) => NumericUtilities.BitwiseComplement(left._value);
        public static xdouble operator +(xdouble left, xdouble right) => left._value + right._value;
        public static xdouble operator +(xdouble value) => value;
        public static xdouble operator ++(xdouble value) => value._value + 1;
        public static xdouble operator <<(xdouble left, int right) => NumericUtilities.LeftShift(left._value, right);
        public static xdouble operator >>(xdouble left, int right) => NumericUtilities.RightShift(left._value, right);

        bool INumeric<xdouble>.IsGreaterThan(xdouble value) => this > value;
        bool INumeric<xdouble>.IsGreaterThanOrEqualTo(xdouble value) => this >= value;
        bool INumeric<xdouble>.IsLessThan(xdouble value) => this < value;
        bool INumeric<xdouble>.IsLessThanOrEqualTo(xdouble value) => this <= value;
        xdouble INumeric<xdouble>.Add(xdouble value) => this + value;
        xdouble INumeric<xdouble>.BitwiseComplement() => ~this;
        xdouble INumeric<xdouble>.Divide(xdouble value) => this / value;
        xdouble INumeric<xdouble>.LeftShift(int count) => this << count;
        xdouble INumeric<xdouble>.LogicalAnd(xdouble value) => this & value;
        xdouble INumeric<xdouble>.LogicalExclusiveOr(xdouble value) => this ^ value;
        xdouble INumeric<xdouble>.LogicalOr(xdouble value) => this | value;
        xdouble INumeric<xdouble>.Multiply(xdouble value) => this * value;
        xdouble INumeric<xdouble>.Negative() => -this;
        xdouble INumeric<xdouble>.Positive() => +this;
        xdouble INumeric<xdouble>.Remainder(xdouble value) => this % value;
        xdouble INumeric<xdouble>.RightShift(int count) => this >> count;
        xdouble INumeric<xdouble>.Subtract(xdouble value) => this - value;

        IBitConverter<xdouble> IProvider<IBitConverter<xdouble>>.GetInstance() => Utilities.Instance;
        IConvert<xdouble> IProvider<IConvert<xdouble>>.GetInstance() => Utilities.Instance;
        IConvertUnsigned<xdouble> IProvider<IConvertUnsigned<xdouble>>.GetInstance() => Utilities.Instance;
        IMath<xdouble> IProvider<IMath<xdouble>>.GetInstance() => Utilities.Instance;
        INumericStatic<xdouble> IProvider<INumericStatic<xdouble>>.GetInstance() => Utilities.Instance;
        IRandom<xdouble> IProvider<IRandom<xdouble>>.GetInstance() => Utilities.Instance;
        IParser<xdouble> IProvider<IParser<xdouble>>.GetInstance() => Utilities.Instance;

        private sealed class Utilities :
            IBitConverter<xdouble>,
            IConvert<xdouble>,
            IConvertUnsigned<xdouble>,
            IMath<xdouble>,
            INumericStatic<xdouble>,
            IRandom<xdouble>,
            IParser<xdouble>
        {
            public static readonly Utilities Instance = new Utilities();

            bool INumericStatic<xdouble>.HasFloatingPoint { get; } = true;
            bool INumericStatic<xdouble>.HasInfinity { get; } = true;
            bool INumericStatic<xdouble>.HasNaN { get; } = true;
            bool INumericStatic<xdouble>.IsFinite(xdouble x) => IsFinite(x);
            bool INumericStatic<xdouble>.IsInfinity(xdouble x) => IsInfinity(x);
            bool INumericStatic<xdouble>.IsNaN(xdouble x) => IsNaN(x);
            bool INumericStatic<xdouble>.IsNegative(xdouble x) => IsNegative(x);
            bool INumericStatic<xdouble>.IsNegativeInfinity(xdouble x) => IsNegativeInfinity(x);
            bool INumericStatic<xdouble>.IsNormal(xdouble x) => IsNormal(x);
            bool INumericStatic<xdouble>.IsPositiveInfinity(xdouble x) => IsPositiveInfinity(x);
            bool INumericStatic<xdouble>.IsReal { get; } = true;
            bool INumericStatic<xdouble>.IsSigned { get; } = true;
            bool INumericStatic<xdouble>.IsSubnormal(xdouble x) => IsSubnormal(x);
            xdouble INumericStatic<xdouble>.Epsilon => Epsilon;
            xdouble INumericStatic<xdouble>.MaxUnit { get; } = 1d;
            xdouble INumericStatic<xdouble>.MaxValue => MaxValue;
            xdouble INumericStatic<xdouble>.MinUnit { get; } = -1d;
            xdouble INumericStatic<xdouble>.MinValue => MinValue;
            xdouble INumericStatic<xdouble>.One { get; } = 1d;
            xdouble INumericStatic<xdouble>.Ten { get; } = 10d;
            xdouble INumericStatic<xdouble>.Two { get; } = 2d;
            xdouble INumericStatic<xdouble>.Zero { get; } = 0d;

            int IMath<xdouble>.Sign(xdouble x) => Math.Sign(x._value);
            xdouble IMath<xdouble>.Abs(xdouble value) => Math.Abs(value._value);
            xdouble IMath<xdouble>.Acos(xdouble x) => Math.Acos(x._value);
            xdouble IMath<xdouble>.Acosh(xdouble x) => MathCompat.Acosh(x._value);
            xdouble IMath<xdouble>.Asin(xdouble x) => Math.Asin(x._value);
            xdouble IMath<xdouble>.Asinh(xdouble x) => MathCompat.Asinh(x._value);
            xdouble IMath<xdouble>.Atan(xdouble x) => Math.Atan(x._value);
            xdouble IMath<xdouble>.Atan2(xdouble x, xdouble y) => Math.Atan2(x._value, y._value);
            xdouble IMath<xdouble>.Atanh(xdouble x) => MathCompat.Atanh(x._value);
            xdouble IMath<xdouble>.Cbrt(xdouble x) => MathCompat.Cbrt(x._value);
            xdouble IMath<xdouble>.Ceiling(xdouble x) => Math.Ceiling(x._value);
            xdouble IMath<xdouble>.Clamp(xdouble x, xdouble bound1, xdouble bound2) => bound1 > bound2 ? Math.Min(bound1._value, Math.Max(bound2._value, x._value)) : Math.Min(bound2._value, Math.Max(bound1._value, x._value));
            xdouble IMath<xdouble>.Cos(xdouble x) => Math.Cos(x._value);
            xdouble IMath<xdouble>.Cosh(xdouble x) => Math.Cosh(x._value);
            xdouble IMath<xdouble>.DegreesToRadians(xdouble x) => x * NumericUtilities.RadiansPerDegree;
            xdouble IMath<xdouble>.E { get; } = Math.E;
            xdouble IMath<xdouble>.Exp(xdouble x) => Math.Exp(x._value);
            xdouble IMath<xdouble>.Floor(xdouble x) => Math.Floor(x._value);
            xdouble IMath<xdouble>.IEEERemainder(xdouble x, xdouble y) => Math.IEEERemainder(x._value, y._value);
            xdouble IMath<xdouble>.Log(xdouble x) => Math.Log(x._value);
            xdouble IMath<xdouble>.Log(xdouble x, xdouble y) => Math.Log(x._value, y._value);
            xdouble IMath<xdouble>.Log10(xdouble x) => Math.Log10(x._value);
            xdouble IMath<xdouble>.Max(xdouble x, xdouble y) => Math.Max(x._value, y._value);
            xdouble IMath<xdouble>.Min(xdouble x, xdouble y) => Math.Min(x._value, y._value);
            xdouble IMath<xdouble>.PI { get; } = Math.PI;
            xdouble IMath<xdouble>.Pow(xdouble x, xdouble y) => Math.Pow(x._value, y._value);
            xdouble IMath<xdouble>.RadiansToDegrees(xdouble x) => x * NumericUtilities.DegreesPerRadian;
            xdouble IMath<xdouble>.Round(xdouble x) => Math.Round(x._value);
            xdouble IMath<xdouble>.Round(xdouble x, int digits) => Math.Round(x._value, digits);
            xdouble IMath<xdouble>.Round(xdouble x, int digits, MidpointRounding mode) => Math.Round(x._value, digits, mode);
            xdouble IMath<xdouble>.Round(xdouble x, MidpointRounding mode) => Math.Round(x._value, mode);
            xdouble IMath<xdouble>.Sin(xdouble x) => Math.Sin(x._value);
            xdouble IMath<xdouble>.Sinh(xdouble x) => Math.Sinh(x._value);
            xdouble IMath<xdouble>.Sqrt(xdouble x) => Math.Sqrt(x._value);
            xdouble IMath<xdouble>.Tan(xdouble x) => Math.Tan(x._value);
            xdouble IMath<xdouble>.Tanh(xdouble x) => Math.Tanh(x._value);
            xdouble IMath<xdouble>.Tau { get; } = Math.PI * 2d;
            xdouble IMath<xdouble>.Truncate(xdouble x) => Math.Truncate(x._value);

            xdouble IBitConverter<xdouble>.Read(IReadOnlyStream<byte> stream) => BitConverter.ToDouble(stream.Read(sizeof(double)), 0);
            void IBitConverter<xdouble>.Write(xdouble value, IWriteOnlyStream<byte> stream) => stream.Write(BitConverter.GetBytes(value._value));

            xdouble IRandom<xdouble>.Next(Random random) => random.NextDouble(double.MinValue, double.MaxValue);
            xdouble IRandom<xdouble>.Next(Random random, xdouble bound1, xdouble bound2) => random.NextDouble(bound1._value, bound2._value);

            bool IConvert<xdouble>.ToBoolean(xdouble value) => Convert.ToBoolean(value._value);
            byte IConvert<xdouble>.ToByte(xdouble value, Conversion mode) => NumericConvert.ToByte(value._value, mode);
            decimal IConvert<xdouble>.ToDecimal(xdouble value, Conversion mode) => NumericConvert.ToDecimal(value._value, mode);
            double IConvert<xdouble>.ToDouble(xdouble value, Conversion mode) => value._value;
            float IConvert<xdouble>.ToSingle(xdouble value, Conversion mode) => NumericConvert.ToSingle(value._value, mode);
            int IConvert<xdouble>.ToInt32(xdouble value, Conversion mode) => NumericConvert.ToInt32(value._value, mode);
            long IConvert<xdouble>.ToInt64(xdouble value, Conversion mode) => NumericConvert.ToInt64(value._value, mode);
            sbyte IConvertUnsigned<xdouble>.ToSByte(xdouble value, Conversion mode) => NumericConvert.ToSByte(value._value, mode);
            short IConvert<xdouble>.ToInt16(xdouble value, Conversion mode) => NumericConvert.ToInt16(value._value, mode);
            string IConvert<xdouble>.ToString(xdouble value) => Convert.ToString(value._value);
            uint IConvertUnsigned<xdouble>.ToUInt32(xdouble value, Conversion mode) => NumericConvert.ToUInt32(value._value, mode);
            ulong IConvertUnsigned<xdouble>.ToUInt64(xdouble value, Conversion mode) => NumericConvert.ToUInt64(value._value, mode);
            ushort IConvertUnsigned<xdouble>.ToUInt16(xdouble value, Conversion mode) => NumericConvert.ToUInt16(value._value, mode);

            xdouble IConvert<xdouble>.ToValue(bool value) => Convert.ToDouble(value);
            xdouble IConvert<xdouble>.ToValue(byte value, Conversion mode) => NumericConvert.ToDouble(value, mode);
            xdouble IConvert<xdouble>.ToValue(decimal value, Conversion mode) => NumericConvert.ToDouble(value, mode);
            xdouble IConvert<xdouble>.ToValue(double value, Conversion mode) => value;
            xdouble IConvert<xdouble>.ToValue(float value, Conversion mode) => NumericConvert.ToDouble(value, mode);
            xdouble IConvert<xdouble>.ToValue(int value, Conversion mode) => NumericConvert.ToDouble(value, mode);
            xdouble IConvert<xdouble>.ToValue(long value, Conversion mode) => NumericConvert.ToDouble(value, mode);
            xdouble IConvertUnsigned<xdouble>.ToValue(sbyte value, Conversion mode) => NumericConvert.ToDouble(value, mode);
            xdouble IConvert<xdouble>.ToValue(short value, Conversion mode) => NumericConvert.ToDouble(value, mode);
            xdouble IConvert<xdouble>.ToValue(string value) => Convert.ToDouble(value);
            xdouble IConvertUnsigned<xdouble>.ToNumeric(uint value, Conversion mode) => NumericConvert.ToDouble(value, mode);
            xdouble IConvertUnsigned<xdouble>.ToNumeric(ulong value, Conversion mode) => NumericConvert.ToDouble(value, mode);
            xdouble IConvertUnsigned<xdouble>.ToNumeric(ushort value, Conversion mode) => NumericConvert.ToDouble(value, mode);

            xdouble IParser<xdouble>.Parse(string s) => Parse(s);
            xdouble IParser<xdouble>.Parse(string s, NumberStyles style, IFormatProvider? provider) => Parse(s, style, provider);
        }
    }
}
