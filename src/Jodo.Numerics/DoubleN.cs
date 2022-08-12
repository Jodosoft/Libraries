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
    /// Represents a double-precision floating-point number.
    /// </summary>
    [Serializable]
    [DebuggerDisplay("{ToString(),nq}")]
    public readonly struct DoubleN : INumericExtended<DoubleN>
    {
        public static readonly DoubleN Epsilon = double.Epsilon;
        public static readonly DoubleN MaxValue = double.MaxValue;
        public static readonly DoubleN MinValue = double.MinValue;

        private readonly double _value;

        private DoubleN(double value)
        {
            _value = value;
        }

        private DoubleN(SerializationInfo info, StreamingContext context) : this(info.GetDouble(nameof(DoubleN))) { }
        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context) => info.AddValue(nameof(DoubleN), _value);

        public int CompareTo(DoubleN other) => _value.CompareTo(other._value);
        public int CompareTo(object? obj) => obj is DoubleN other ? CompareTo(other) : 1;
        public bool Equals(DoubleN other) => _value == other._value;
        public override bool Equals(object? obj) => obj is DoubleN other && Equals(other);
        public override int GetHashCode() => _value.GetHashCode();
        public override string ToString() => _value.ToString();
        public string ToString(IFormatProvider formatProvider) => _value.ToString(formatProvider);
        public string ToString(string format) => _value.ToString(format);
        public string ToString(string? format, IFormatProvider? formatProvider) => _value.ToString(format, formatProvider);

        public static bool IsFinite(DoubleN d) => DoubleCompat.IsFinite(d);
        public static bool IsInfinity(DoubleN d) => double.IsInfinity(d);
        public static bool IsNaN(DoubleN d) => double.IsNaN(d);
        public static bool IsNegative(DoubleN d) => DoubleCompat.IsNegative(d);
        public static bool IsNegativeInfinity(DoubleN d) => double.IsNegativeInfinity(d);
        public static bool IsNormal(DoubleN d) => DoubleCompat.IsNormal(d);
        public static bool IsPositiveInfinity(DoubleN d) => double.IsPositiveInfinity(d);
        public static bool IsSubnormal(DoubleN d) => DoubleCompat.IsSubnormal(d);

        public static bool TryParse(string s, IFormatProvider? provider, out DoubleN result) => TryHelper.Run(() => Parse(s, provider), out result);
        public static bool TryParse(string s, NumberStyles style, IFormatProvider? provider, out DoubleN result) => TryHelper.Run(() => Parse(s, style, provider), out result);
        public static bool TryParse(string s, NumberStyles style, out DoubleN result) => TryHelper.Run(() => Parse(s, style), out result);
        public static bool TryParse(string s, out DoubleN result) => TryHelper.Run(() => Parse(s), out result);
        public static DoubleN Parse(string s) => double.Parse(s);
        public static DoubleN Parse(string s, IFormatProvider? provider) => double.Parse(s, provider);
        public static DoubleN Parse(string s, NumberStyles style) => double.Parse(s, style);
        public static DoubleN Parse(string s, NumberStyles style, IFormatProvider? provider) => double.Parse(s, style, provider);

        [CLSCompliant(false)] public static implicit operator DoubleN(sbyte value) => new DoubleN(value);
        [CLSCompliant(false)] public static implicit operator DoubleN(uint value) => new DoubleN(value);
        [CLSCompliant(false)] public static implicit operator DoubleN(ulong value) => new DoubleN(value);
        [CLSCompliant(false)] public static implicit operator DoubleN(ushort value) => new DoubleN(value);
        public static explicit operator DoubleN(decimal value) => new DoubleN((double)value);
        public static implicit operator DoubleN(byte value) => new DoubleN(value);
        public static implicit operator DoubleN(double value) => new DoubleN(value);
        public static implicit operator DoubleN(float value) => new DoubleN(value);
        public static implicit operator DoubleN(int value) => new DoubleN(value);
        public static implicit operator DoubleN(long value) => new DoubleN(value);
        public static implicit operator DoubleN(short value) => new DoubleN(value);

        [CLSCompliant(false)] public static explicit operator sbyte(DoubleN value) => (sbyte)value._value;
        [CLSCompliant(false)] public static explicit operator uint(DoubleN value) => (uint)value._value;
        [CLSCompliant(false)] public static explicit operator ulong(DoubleN value) => (ulong)value._value;
        [CLSCompliant(false)] public static explicit operator ushort(DoubleN value) => (ushort)value._value;
        public static explicit operator byte(DoubleN value) => (byte)value._value;
        public static explicit operator decimal(DoubleN value) => (decimal)value._value;
        public static explicit operator float(DoubleN value) => (float)value._value;
        public static explicit operator int(DoubleN value) => (int)value._value;
        public static explicit operator long(DoubleN value) => (long)value._value;
        public static explicit operator short(DoubleN value) => (short)value._value;
        public static implicit operator double(DoubleN value) => value._value;

        public static bool operator !=(DoubleN left, DoubleN right) => left._value != right._value;
        public static bool operator <(DoubleN left, DoubleN right) => left._value < right._value;
        public static bool operator <=(DoubleN left, DoubleN right) => left._value <= right._value;
        public static bool operator ==(DoubleN left, DoubleN right) => left._value == right._value;
        public static bool operator >(DoubleN left, DoubleN right) => left._value > right._value;
        public static bool operator >=(DoubleN left, DoubleN right) => left._value >= right._value;
        public static DoubleN operator %(DoubleN left, DoubleN right) => left._value % right._value;
        public static DoubleN operator &(DoubleN left, DoubleN right) => NumericUtilities.LogicalAnd(left._value, right._value);
        public static DoubleN operator -(DoubleN left, DoubleN right) => left._value - right._value;
        public static DoubleN operator --(DoubleN value) => value._value - 1;
        public static DoubleN operator -(DoubleN value) => -value._value;
        public static DoubleN operator *(DoubleN left, DoubleN right) => left._value * right._value;
        public static DoubleN operator /(DoubleN left, DoubleN right) => left._value / right._value;
        public static DoubleN operator ^(DoubleN left, DoubleN right) => NumericUtilities.LogicalExclusiveOr(left._value, right._value);
        public static DoubleN operator |(DoubleN left, DoubleN right) => NumericUtilities.LogicalOr(left._value, right._value);
        public static DoubleN operator ~(DoubleN left) => NumericUtilities.BitwiseComplement(left._value);
        public static DoubleN operator +(DoubleN left, DoubleN right) => left._value + right._value;
        public static DoubleN operator +(DoubleN value) => value;
        public static DoubleN operator ++(DoubleN value) => value._value + 1;
        public static DoubleN operator <<(DoubleN left, int right) => NumericUtilities.LeftShift(left._value, right);
        public static DoubleN operator >>(DoubleN left, int right) => NumericUtilities.RightShift(left._value, right);

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

        bool INumeric<DoubleN>.IsGreaterThan(DoubleN value) => this > value;
        bool INumeric<DoubleN>.IsGreaterThanOrEqualTo(DoubleN value) => this >= value;
        bool INumeric<DoubleN>.IsLessThan(DoubleN value) => this < value;
        bool INumeric<DoubleN>.IsLessThanOrEqualTo(DoubleN value) => this <= value;
        DoubleN INumeric<DoubleN>.Add(DoubleN value) => this + value;
        DoubleN INumeric<DoubleN>.BitwiseComplement() => ~this;
        DoubleN INumeric<DoubleN>.Divide(DoubleN value) => this / value;
        DoubleN INumeric<DoubleN>.LeftShift(int count) => this << count;
        DoubleN INumeric<DoubleN>.LogicalAnd(DoubleN value) => this & value;
        DoubleN INumeric<DoubleN>.LogicalExclusiveOr(DoubleN value) => this ^ value;
        DoubleN INumeric<DoubleN>.LogicalOr(DoubleN value) => this | value;
        DoubleN INumeric<DoubleN>.Multiply(DoubleN value) => this * value;
        DoubleN INumeric<DoubleN>.Negative() => -this;
        DoubleN INumeric<DoubleN>.Positive() => +this;
        DoubleN INumeric<DoubleN>.Remainder(DoubleN value) => this % value;
        DoubleN INumeric<DoubleN>.RightShift(int count) => this >> count;
        DoubleN INumeric<DoubleN>.Subtract(DoubleN value) => this - value;

        IBitConvert<DoubleN> IProvider<IBitConvert<DoubleN>>.GetInstance() => Utilities.Instance;
        IConvert<DoubleN> IProvider<IConvert<DoubleN>>.GetInstance() => Utilities.Instance;
        IConvertExtended<DoubleN> IProvider<IConvertExtended<DoubleN>>.GetInstance() => Utilities.Instance;
        IMath<DoubleN> IProvider<IMath<DoubleN>>.GetInstance() => Utilities.Instance;
        INumericStatic<DoubleN> IProvider<INumericStatic<DoubleN>>.GetInstance() => Utilities.Instance;
        IRandom<DoubleN> IProvider<IRandom<DoubleN>>.GetInstance() => Utilities.Instance;
        IStringConvert<DoubleN> IProvider<IStringConvert<DoubleN>>.GetInstance() => Utilities.Instance;

        private sealed class Utilities :
            IBitConvert<DoubleN>,
            IConvert<DoubleN>,
            IConvertExtended<DoubleN>,
            IMath<DoubleN>,
            INumericStatic<DoubleN>,
            IRandom<DoubleN>,
            IStringConvert<DoubleN>
        {
            public static readonly Utilities Instance = new Utilities();

            bool INumericStatic<DoubleN>.HasFloatingPoint => true;
            bool INumericStatic<DoubleN>.HasInfinity => true;
            bool INumericStatic<DoubleN>.HasNaN => true;
            bool INumericStatic<DoubleN>.IsFinite(DoubleN x) => IsFinite(x);
            bool INumericStatic<DoubleN>.IsInfinity(DoubleN x) => IsInfinity(x);
            bool INumericStatic<DoubleN>.IsNaN(DoubleN x) => IsNaN(x);
            bool INumericStatic<DoubleN>.IsNegative(DoubleN x) => IsNegative(x);
            bool INumericStatic<DoubleN>.IsNegativeInfinity(DoubleN x) => IsNegativeInfinity(x);
            bool INumericStatic<DoubleN>.IsNormal(DoubleN x) => IsNormal(x);
            bool INumericStatic<DoubleN>.IsPositiveInfinity(DoubleN x) => IsPositiveInfinity(x);
            bool INumericStatic<DoubleN>.IsReal => true;
            bool INumericStatic<DoubleN>.IsSigned => true;
            bool INumericStatic<DoubleN>.IsSubnormal(DoubleN x) => IsSubnormal(x);
            DoubleN INumericStatic<DoubleN>.Epsilon => Epsilon;
            DoubleN INumericStatic<DoubleN>.MaxUnit => 1d;
            DoubleN INumericStatic<DoubleN>.MaxValue => MaxValue;
            DoubleN INumericStatic<DoubleN>.MinUnit => -1d;
            DoubleN INumericStatic<DoubleN>.MinValue => MinValue;
            DoubleN INumericStatic<DoubleN>.One => 1d;
            DoubleN INumericStatic<DoubleN>.Ten => 10d;
            DoubleN INumericStatic<DoubleN>.Two => 2d;
            DoubleN INumericStatic<DoubleN>.Zero => 0d;

            int IMath<DoubleN>.Sign(DoubleN x) => Math.Sign(x._value);
            DoubleN IMath<DoubleN>.Abs(DoubleN value) => Math.Abs(value._value);
            DoubleN IMath<DoubleN>.Acos(DoubleN x) => Math.Acos(x._value);
            DoubleN IMath<DoubleN>.Acosh(DoubleN x) => MathCompat.Acosh(x._value);
            DoubleN IMath<DoubleN>.Asin(DoubleN x) => Math.Asin(x._value);
            DoubleN IMath<DoubleN>.Asinh(DoubleN x) => MathCompat.Asinh(x._value);
            DoubleN IMath<DoubleN>.Atan(DoubleN x) => Math.Atan(x._value);
            DoubleN IMath<DoubleN>.Atan2(DoubleN x, DoubleN y) => Math.Atan2(x._value, y._value);
            DoubleN IMath<DoubleN>.Atanh(DoubleN x) => MathCompat.Atanh(x._value);
            DoubleN IMath<DoubleN>.Cbrt(DoubleN x) => MathCompat.Cbrt(x._value);
            DoubleN IMath<DoubleN>.Ceiling(DoubleN x) => Math.Ceiling(x._value);
            DoubleN IMath<DoubleN>.Clamp(DoubleN x, DoubleN bound1, DoubleN bound2) => bound1 > bound2 ? Math.Min(bound1._value, Math.Max(bound2._value, x._value)) : Math.Min(bound2._value, Math.Max(bound1._value, x._value));
            DoubleN IMath<DoubleN>.Cos(DoubleN x) => Math.Cos(x._value);
            DoubleN IMath<DoubleN>.Cosh(DoubleN x) => Math.Cosh(x._value);
            DoubleN IMath<DoubleN>.DegreesToRadians(DoubleN x) => x * NumericUtilities.RadiansPerDegree;
            DoubleN IMath<DoubleN>.E { get; } = Math.E;
            DoubleN IMath<DoubleN>.Exp(DoubleN x) => Math.Exp(x._value);
            DoubleN IMath<DoubleN>.Floor(DoubleN x) => Math.Floor(x._value);
            DoubleN IMath<DoubleN>.IEEERemainder(DoubleN x, DoubleN y) => Math.IEEERemainder(x._value, y._value);
            DoubleN IMath<DoubleN>.Log(DoubleN x) => Math.Log(x._value);
            DoubleN IMath<DoubleN>.Log(DoubleN x, DoubleN y) => Math.Log(x._value, y._value);
            DoubleN IMath<DoubleN>.Log10(DoubleN x) => Math.Log10(x._value);
            DoubleN IMath<DoubleN>.Max(DoubleN x, DoubleN y) => Math.Max(x._value, y._value);
            DoubleN IMath<DoubleN>.Min(DoubleN x, DoubleN y) => Math.Min(x._value, y._value);
            DoubleN IMath<DoubleN>.PI { get; } = Math.PI;
            DoubleN IMath<DoubleN>.Pow(DoubleN x, DoubleN y) => Math.Pow(x._value, y._value);
            DoubleN IMath<DoubleN>.RadiansToDegrees(DoubleN x) => x * NumericUtilities.DegreesPerRadian;
            DoubleN IMath<DoubleN>.Round(DoubleN x) => Math.Round(x._value);
            DoubleN IMath<DoubleN>.Round(DoubleN x, int digits) => Math.Round(x._value, digits);
            DoubleN IMath<DoubleN>.Round(DoubleN x, int digits, MidpointRounding mode) => Math.Round(x._value, digits, mode);
            DoubleN IMath<DoubleN>.Round(DoubleN x, MidpointRounding mode) => Math.Round(x._value, mode);
            DoubleN IMath<DoubleN>.Sin(DoubleN x) => Math.Sin(x._value);
            DoubleN IMath<DoubleN>.Sinh(DoubleN x) => Math.Sinh(x._value);
            DoubleN IMath<DoubleN>.Sqrt(DoubleN x) => Math.Sqrt(x._value);
            DoubleN IMath<DoubleN>.Tan(DoubleN x) => Math.Tan(x._value);
            DoubleN IMath<DoubleN>.Tanh(DoubleN x) => Math.Tanh(x._value);
            DoubleN IMath<DoubleN>.Tau { get; } = Math.PI * 2d;
            DoubleN IMath<DoubleN>.Truncate(DoubleN x) => Math.Truncate(x._value);

            DoubleN IBitConvert<DoubleN>.Read(IReader<byte> stream) => BitConverter.ToDouble(stream.Read(sizeof(double)), 0);
            void IBitConvert<DoubleN>.Write(DoubleN value, IWriter<byte> stream) => stream.Write(BitConverter.GetBytes(value._value));

            DoubleN IRandom<DoubleN>.Next(Random random) => random.NextDouble(double.MinValue, double.MaxValue);
            DoubleN IRandom<DoubleN>.Next(Random random, DoubleN bound1, DoubleN bound2) => random.NextDouble(bound1._value, bound2._value);

            bool IConvert<DoubleN>.ToBoolean(DoubleN value) => Convert.ToBoolean(value._value);
            byte IConvert<DoubleN>.ToByte(DoubleN value, Conversion mode) => ConvertN.ToByte(value._value, mode);
            decimal IConvert<DoubleN>.ToDecimal(DoubleN value, Conversion mode) => ConvertN.ToDecimal(value._value, mode);
            double IConvert<DoubleN>.ToDouble(DoubleN value, Conversion mode) => value._value;
            float IConvert<DoubleN>.ToSingle(DoubleN value, Conversion mode) => ConvertN.ToSingle(value._value, mode);
            int IConvert<DoubleN>.ToInt32(DoubleN value, Conversion mode) => ConvertN.ToInt32(value._value, mode);
            long IConvert<DoubleN>.ToInt64(DoubleN value, Conversion mode) => ConvertN.ToInt64(value._value, mode);
            sbyte IConvertExtended<DoubleN>.ToSByte(DoubleN value, Conversion mode) => ConvertN.ToSByte(value._value, mode);
            short IConvert<DoubleN>.ToInt16(DoubleN value, Conversion mode) => ConvertN.ToInt16(value._value, mode);
            string IConvert<DoubleN>.ToString(DoubleN value) => Convert.ToString(value._value);
            uint IConvertExtended<DoubleN>.ToUInt32(DoubleN value, Conversion mode) => ConvertN.ToUInt32(value._value, mode);
            ulong IConvertExtended<DoubleN>.ToUInt64(DoubleN value, Conversion mode) => ConvertN.ToUInt64(value._value, mode);
            ushort IConvertExtended<DoubleN>.ToUInt16(DoubleN value, Conversion mode) => ConvertN.ToUInt16(value._value, mode);

            DoubleN IConvert<DoubleN>.ToNumeric(bool value) => Convert.ToDouble(value);
            DoubleN IConvert<DoubleN>.ToNumeric(byte value, Conversion mode) => ConvertN.ToDouble(value, mode);
            DoubleN IConvert<DoubleN>.ToNumeric(decimal value, Conversion mode) => ConvertN.ToDouble(value, mode);
            DoubleN IConvert<DoubleN>.ToNumeric(double value, Conversion mode) => value;
            DoubleN IConvert<DoubleN>.ToNumeric(float value, Conversion mode) => ConvertN.ToDouble(value, mode);
            DoubleN IConvert<DoubleN>.ToNumeric(int value, Conversion mode) => ConvertN.ToDouble(value, mode);
            DoubleN IConvert<DoubleN>.ToNumeric(long value, Conversion mode) => ConvertN.ToDouble(value, mode);
            DoubleN IConvertExtended<DoubleN>.ToValue(sbyte value, Conversion mode) => ConvertN.ToDouble(value, mode);
            DoubleN IConvert<DoubleN>.ToNumeric(short value, Conversion mode) => ConvertN.ToDouble(value, mode);
            DoubleN IConvert<DoubleN>.ToNumeric(string value) => Convert.ToDouble(value);
            DoubleN IConvertExtended<DoubleN>.ToNumeric(uint value, Conversion mode) => ConvertN.ToDouble(value, mode);
            DoubleN IConvertExtended<DoubleN>.ToNumeric(ulong value, Conversion mode) => ConvertN.ToDouble(value, mode);
            DoubleN IConvertExtended<DoubleN>.ToNumeric(ushort value, Conversion mode) => ConvertN.ToDouble(value, mode);

            DoubleN IStringConvert<DoubleN>.Parse(string s, NumberStyles? style, IFormatProvider? provider)
                => Parse(s, style ?? NumberStyles.Float | NumberStyles.AllowThousands, provider);
        }
    }
}
