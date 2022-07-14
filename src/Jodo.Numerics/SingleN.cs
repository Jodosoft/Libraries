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
    /// Represents a single-precision floating-point number.
    /// </summary>
    [Serializable]
    [DebuggerDisplay("{ToString(),nq}")]
    public readonly struct SingleN : INumericExtended<SingleN>
    {
        public static readonly SingleN Epsilon = float.Epsilon;
        public static readonly SingleN MaxValue = float.MaxValue;
        public static readonly SingleN MinValue = float.MinValue;

        private readonly float _value;

        private SingleN(float value)
        {
            _value = value;
        }

        private SingleN(SerializationInfo info, StreamingContext context) : this(info.GetSingle(nameof(SingleN))) { }
        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context) => info.AddValue(nameof(SingleN), _value);

        public int CompareTo(SingleN other) => _value.CompareTo(other._value);
        public int CompareTo(object? obj) => obj is SingleN other ? CompareTo(other) : 1;
        public bool Equals(SingleN other) => _value == other._value;
        public override bool Equals(object? obj) => obj is SingleN other && Equals(other);
        public override int GetHashCode() => _value.GetHashCode();
        public override string ToString() => _value.ToString();
        public string ToString(IFormatProvider formatProvider) => _value.ToString(formatProvider);
        public string ToString(string format) => _value.ToString(format);
        public string ToString(string? format, IFormatProvider? formatProvider) => _value.ToString(format, formatProvider);

        public static bool IsFinite(SingleN f) => SingleCompat.IsFinite(f);
        public static bool IsInfinity(SingleN f) => float.IsInfinity(f);
        public static bool IsNaN(SingleN f) => float.IsNaN(f);
        public static bool IsNegative(SingleN f) => SingleCompat.IsNegative(f);
        public static bool IsNegativeInfinity(SingleN f) => float.IsNegativeInfinity(f);
        public static bool IsNormal(SingleN f) => SingleCompat.IsNormal(f);
        public static bool IsPositiveInfinity(SingleN f) => float.IsPositiveInfinity(f);
        public static bool IsSubnormal(SingleN f) => SingleCompat.IsSubnormal(f);

        public static bool TryParse(string s, IFormatProvider? provider, out SingleN result) => Try.Run(() => Parse(s, provider), out result);
        public static bool TryParse(string s, NumberStyles style, IFormatProvider? provider, out SingleN result) => Try.Run(() => Parse(s, style, provider), out result);
        public static bool TryParse(string s, NumberStyles style, out SingleN result) => Try.Run(() => Parse(s, style), out result);
        public static bool TryParse(string s, out SingleN result) => Try.Run(() => Parse(s), out result);
        public static SingleN Parse(string s) => float.Parse(s);
        public static SingleN Parse(string s, IFormatProvider? provider) => float.Parse(s, provider);
        public static SingleN Parse(string s, NumberStyles style) => float.Parse(s, style);
        public static SingleN Parse(string s, NumberStyles style, IFormatProvider? provider) => float.Parse(s, style, provider);

        [CLSCompliant(false)] public static implicit operator SingleN(sbyte value) => new SingleN(value);
        [CLSCompliant(false)] public static implicit operator SingleN(uint value) => new SingleN(value);
        [CLSCompliant(false)] public static implicit operator SingleN(ulong value) => new SingleN(value);
        [CLSCompliant(false)] public static implicit operator SingleN(ushort value) => new SingleN(value);
        public static explicit operator SingleN(decimal value) => new SingleN((float)value);
        public static explicit operator SingleN(double value) => new SingleN((float)value);
        public static implicit operator SingleN(byte value) => new SingleN(value);
        public static implicit operator SingleN(float value) => new SingleN(value);
        public static implicit operator SingleN(int value) => new SingleN(value);
        public static implicit operator SingleN(long value) => new SingleN(value);
        public static implicit operator SingleN(short value) => new SingleN(value);

        [CLSCompliant(false)] public static explicit operator sbyte(SingleN value) => (sbyte)value._value;
        [CLSCompliant(false)] public static explicit operator uint(SingleN value) => (uint)value._value;
        [CLSCompliant(false)] public static explicit operator ulong(SingleN value) => (ulong)value._value;
        [CLSCompliant(false)] public static explicit operator ushort(SingleN value) => (ushort)value._value;
        public static explicit operator byte(SingleN value) => (byte)value._value;
        public static explicit operator decimal(SingleN value) => (decimal)value._value;
        public static explicit operator int(SingleN value) => (int)value._value;
        public static explicit operator long(SingleN value) => (long)value._value;
        public static explicit operator short(SingleN value) => (short)value._value;
        public static implicit operator double(SingleN value) => value._value;
        public static implicit operator float(SingleN value) => value._value;

        public static bool operator !=(SingleN left, SingleN right) => left._value != right._value;
        public static bool operator <(SingleN left, SingleN right) => left._value < right._value;
        public static bool operator <=(SingleN left, SingleN right) => left._value <= right._value;
        public static bool operator ==(SingleN left, SingleN right) => left._value == right._value;
        public static bool operator >(SingleN left, SingleN right) => left._value > right._value;
        public static bool operator >=(SingleN left, SingleN right) => left._value >= right._value;
        public static SingleN operator %(SingleN left, SingleN right) => left._value % right._value;
        public static SingleN operator &(SingleN left, SingleN right) => NumericUtilities.LogicalAnd(left._value, right._value);
        public static SingleN operator -(SingleN left, SingleN right) => left._value - right._value;
        public static SingleN operator --(SingleN value) => value._value - 1;
        public static SingleN operator -(SingleN value) => -value._value;
        public static SingleN operator *(SingleN left, SingleN right) => left._value * right._value;
        public static SingleN operator /(SingleN left, SingleN right) => left._value / right._value;
        public static SingleN operator ^(SingleN left, SingleN right) => NumericUtilities.LogicalExclusiveOr(left._value, right._value);
        public static SingleN operator |(SingleN left, SingleN right) => NumericUtilities.LogicalOr(left._value, right._value);
        public static SingleN operator ~(SingleN left) => NumericUtilities.BitwiseComplement(left._value);
        public static SingleN operator +(SingleN left, SingleN right) => left._value + right._value;
        public static SingleN operator +(SingleN value) => value;
        public static SingleN operator ++(SingleN value) => value._value + 1;
        public static SingleN operator <<(SingleN left, int right) => NumericUtilities.LeftShift(left._value, right);
        public static SingleN operator >>(SingleN left, int right) => NumericUtilities.RightShift(left._value, right);

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

        bool INumeric<SingleN>.IsGreaterThan(SingleN value) => this > value;
        bool INumeric<SingleN>.IsGreaterThanOrEqualTo(SingleN value) => this >= value;
        bool INumeric<SingleN>.IsLessThan(SingleN value) => this < value;
        bool INumeric<SingleN>.IsLessThanOrEqualTo(SingleN value) => this <= value;
        SingleN INumeric<SingleN>.Add(SingleN value) => this + value;
        SingleN INumeric<SingleN>.BitwiseComplement() => ~this;
        SingleN INumeric<SingleN>.Divide(SingleN value) => this / value;
        SingleN INumeric<SingleN>.LeftShift(int count) => this << count;
        SingleN INumeric<SingleN>.LogicalAnd(SingleN value) => this & value;
        SingleN INumeric<SingleN>.LogicalExclusiveOr(SingleN value) => this ^ value;
        SingleN INumeric<SingleN>.LogicalOr(SingleN value) => this | value;
        SingleN INumeric<SingleN>.Multiply(SingleN value) => this * value;
        SingleN INumeric<SingleN>.Negative() => -this;
        SingleN INumeric<SingleN>.Positive() => +this;
        SingleN INumeric<SingleN>.Remainder(SingleN value) => this % value;
        SingleN INumeric<SingleN>.RightShift(int count) => this >> count;
        SingleN INumeric<SingleN>.Subtract(SingleN value) => this - value;

        IBitConverter<SingleN> IProvider<IBitConverter<SingleN>>.GetInstance() => Utilities.Instance;
        IConvert<SingleN> IProvider<IConvert<SingleN>>.GetInstance() => Utilities.Instance;
        IConvertExtended<SingleN> IProvider<IConvertExtended<SingleN>>.GetInstance() => Utilities.Instance;
        IMath<SingleN> IProvider<IMath<SingleN>>.GetInstance() => Utilities.Instance;
        INumericStatic<SingleN> IProvider<INumericStatic<SingleN>>.GetInstance() => Utilities.Instance;
        IRandom<SingleN> IProvider<IRandom<SingleN>>.GetInstance() => Utilities.Instance;
        IParser<SingleN> IProvider<IParser<SingleN>>.GetInstance() => Utilities.Instance;

        private sealed class Utilities :
            IBitConverter<SingleN>,
            IConvert<SingleN>,
            IConvertExtended<SingleN>,
            IMath<SingleN>,
            INumericStatic<SingleN>,
            IRandom<SingleN>,
            IParser<SingleN>
        {
            public static readonly Utilities Instance = new Utilities();

            bool INumericStatic<SingleN>.HasFloatingPoint { get; } = true;
            bool INumericStatic<SingleN>.HasInfinity { get; } = true;
            bool INumericStatic<SingleN>.HasNaN { get; } = true;
            bool INumericStatic<SingleN>.IsFinite(SingleN x) => IsFinite(x);
            bool INumericStatic<SingleN>.IsInfinity(SingleN x) => IsInfinity(x);
            bool INumericStatic<SingleN>.IsNaN(SingleN x) => IsNaN(x);
            bool INumericStatic<SingleN>.IsNegative(SingleN x) => IsNegative(x);
            bool INumericStatic<SingleN>.IsNegativeInfinity(SingleN x) => IsNegativeInfinity(x);
            bool INumericStatic<SingleN>.IsNormal(SingleN x) => IsNormal(x);
            bool INumericStatic<SingleN>.IsPositiveInfinity(SingleN x) => IsPositiveInfinity(x);
            bool INumericStatic<SingleN>.IsReal { get; } = true;
            bool INumericStatic<SingleN>.IsSigned { get; } = true;
            bool INumericStatic<SingleN>.IsSubnormal(SingleN x) => IsSubnormal(x);
            SingleN INumericStatic<SingleN>.Epsilon => Epsilon;
            SingleN INumericStatic<SingleN>.MaxUnit { get; } = 1f;
            SingleN INumericStatic<SingleN>.MaxValue => MaxValue;
            SingleN INumericStatic<SingleN>.MinUnit { get; } = -1f;
            SingleN INumericStatic<SingleN>.MinValue => MinValue;
            SingleN INumericStatic<SingleN>.One { get; } = 1f;
            SingleN INumericStatic<SingleN>.Ten { get; } = 10f;
            SingleN INumericStatic<SingleN>.Two { get; } = 2f;
            SingleN INumericStatic<SingleN>.Zero { get; } = 0f;

            int IMath<SingleN>.Sign(SingleN x) => Math.Sign(x._value);
            SingleN IMath<SingleN>.Abs(SingleN value) => MathF.Abs(value._value);
            SingleN IMath<SingleN>.Acos(SingleN x) => MathF.Acos(x._value);
            SingleN IMath<SingleN>.Acosh(SingleN x) => MathF.Acosh(x._value);
            SingleN IMath<SingleN>.Asin(SingleN x) => MathF.Asin(x._value);
            SingleN IMath<SingleN>.Asinh(SingleN x) => MathF.Asinh(x._value);
            SingleN IMath<SingleN>.Atan(SingleN x) => MathF.Atan(x._value);
            SingleN IMath<SingleN>.Atan2(SingleN x, SingleN y) => MathF.Atan2(x._value, y._value);
            SingleN IMath<SingleN>.Atanh(SingleN x) => MathF.Atanh(x._value);
            SingleN IMath<SingleN>.Cbrt(SingleN x) => MathF.Cbrt(x._value);
            SingleN IMath<SingleN>.Ceiling(SingleN x) => MathF.Ceiling(x._value);
            SingleN IMath<SingleN>.Clamp(SingleN x, SingleN bound1, SingleN bound2) => bound1 > bound2 ? MathF.Min(bound1._value, MathF.Max(bound2._value, x._value)) : MathF.Min(bound2._value, MathF.Max(bound1._value, x._value));
            SingleN IMath<SingleN>.Cos(SingleN x) => MathF.Cos(x._value);
            SingleN IMath<SingleN>.Cosh(SingleN x) => MathF.Cosh(x._value);
            SingleN IMath<SingleN>.DegreesToRadians(SingleN x) => x * NumericUtilities.RadiansPerDegreeF;
            SingleN IMath<SingleN>.E { get; } = MathF.E;
            SingleN IMath<SingleN>.Exp(SingleN x) => MathF.Exp(x._value);
            SingleN IMath<SingleN>.Floor(SingleN x) => MathF.Floor(x._value);
            SingleN IMath<SingleN>.IEEERemainder(SingleN x, SingleN y) => MathF.IEEERemainder(x._value, y._value);
            SingleN IMath<SingleN>.Log(SingleN x) => MathF.Log(x._value);
            SingleN IMath<SingleN>.Log(SingleN x, SingleN y) => MathF.Log(x._value, y._value);
            SingleN IMath<SingleN>.Log10(SingleN x) => MathF.Log10(x._value);
            SingleN IMath<SingleN>.Max(SingleN x, SingleN y) => MathF.Max(x._value, y._value);
            SingleN IMath<SingleN>.Min(SingleN x, SingleN y) => MathF.Min(x._value, y._value);
            SingleN IMath<SingleN>.PI { get; } = MathF.PI;
            SingleN IMath<SingleN>.Pow(SingleN x, SingleN y) => MathF.Pow(x._value, y._value);
            SingleN IMath<SingleN>.RadiansToDegrees(SingleN x) => x * NumericUtilities.DegreesPerRadianF;
            SingleN IMath<SingleN>.Round(SingleN x) => MathF.Round(x);
            SingleN IMath<SingleN>.Round(SingleN x, int digits) => MathF.Round(x, digits);
            SingleN IMath<SingleN>.Round(SingleN x, int digits, MidpointRounding mode) => MathF.Round(x, digits, mode);
            SingleN IMath<SingleN>.Round(SingleN x, MidpointRounding mode) => MathF.Round(x, mode);
            SingleN IMath<SingleN>.Sin(SingleN x) => MathF.Sin(x._value);
            SingleN IMath<SingleN>.Sinh(SingleN x) => MathF.Sinh(x._value);
            SingleN IMath<SingleN>.Sqrt(SingleN x) => MathF.Sqrt(x._value);
            SingleN IMath<SingleN>.Tan(SingleN x) => MathF.Tan(x._value);
            SingleN IMath<SingleN>.Tanh(SingleN x) => MathF.Tanh(x._value);
            SingleN IMath<SingleN>.Tau { get; } = MathF.PI * 2;
            SingleN IMath<SingleN>.Truncate(SingleN x) => MathF.Truncate(x._value);

            SingleN IBitConverter<SingleN>.Read(IReadOnlyStream<byte> stream) => BitConverter.ToSingle(stream.Read(sizeof(float)), 0);
            void IBitConverter<SingleN>.Write(SingleN value, IWriteOnlyStream<byte> stream) => stream.Write(BitConverter.GetBytes(value._value));

            SingleN IRandom<SingleN>.Next(Random random) => random.NextSingle(float.MinValue, float.MaxValue);
            SingleN IRandom<SingleN>.Next(Random random, SingleN bound1, SingleN bound2) => random.NextSingle(bound1._value, bound2._value);

            bool IConvert<SingleN>.ToBoolean(SingleN value) => Convert.ToBoolean(value._value);
            byte IConvert<SingleN>.ToByte(SingleN value, Conversion mode) => NumericConvert.ToByte(value._value, mode);
            decimal IConvert<SingleN>.ToDecimal(SingleN value, Conversion mode) => NumericConvert.ToDecimal(value._value, mode);
            double IConvert<SingleN>.ToDouble(SingleN value, Conversion mode) => NumericConvert.ToDouble(value._value, mode);
            float IConvert<SingleN>.ToSingle(SingleN value, Conversion mode) => NumericConvert.ToSingle(value._value, mode);
            int IConvert<SingleN>.ToInt32(SingleN value, Conversion mode) => NumericConvert.ToInt32(value._value, mode);
            long IConvert<SingleN>.ToInt64(SingleN value, Conversion mode) => NumericConvert.ToInt64(value._value, mode);
            sbyte IConvertExtended<SingleN>.ToSByte(SingleN value, Conversion mode) => NumericConvert.ToSByte(value._value, mode);
            short IConvert<SingleN>.ToInt16(SingleN value, Conversion mode) => NumericConvert.ToInt16(value._value, mode);
            string IConvert<SingleN>.ToString(SingleN value) => Convert.ToString(value._value);
            uint IConvertExtended<SingleN>.ToUInt32(SingleN value, Conversion mode) => NumericConvert.ToUInt32(value._value, mode);
            ulong IConvertExtended<SingleN>.ToUInt64(SingleN value, Conversion mode) => NumericConvert.ToUInt64(value._value, mode);
            ushort IConvertExtended<SingleN>.ToUInt16(SingleN value, Conversion mode) => NumericConvert.ToUInt16(value._value, mode);

            SingleN IConvert<SingleN>.ToNumeric(bool value) => Convert.ToSingle(value);
            SingleN IConvert<SingleN>.ToNumeric(byte value, Conversion mode) => NumericConvert.ToSingle(value, mode);
            SingleN IConvert<SingleN>.ToNumeric(float value, Conversion mode) => NumericConvert.ToSingle(value, mode);
            SingleN IConvert<SingleN>.ToNumeric(double value, Conversion mode) => NumericConvert.ToSingle(value, mode);
            SingleN IConvert<SingleN>.ToNumeric(decimal value, Conversion mode) => NumericConvert.ToSingle(value, mode);
            SingleN IConvert<SingleN>.ToNumeric(int value, Conversion mode) => NumericConvert.ToSingle(value, mode);
            SingleN IConvert<SingleN>.ToNumeric(long value, Conversion mode) => NumericConvert.ToSingle(value, mode);
            SingleN IConvertExtended<SingleN>.ToValue(sbyte value, Conversion mode) => NumericConvert.ToSingle(value, mode);
            SingleN IConvert<SingleN>.ToNumeric(short value, Conversion mode) => NumericConvert.ToSingle(value, mode);
            SingleN IConvert<SingleN>.ToNumeric(string value) => Convert.ToSingle(value);
            SingleN IConvertExtended<SingleN>.ToNumeric(uint value, Conversion mode) => NumericConvert.ToSingle(value, mode);
            SingleN IConvertExtended<SingleN>.ToNumeric(ulong value, Conversion mode) => NumericConvert.ToSingle(value, mode);
            SingleN IConvertExtended<SingleN>.ToNumeric(ushort value, Conversion mode) => NumericConvert.ToSingle(value, mode);

            SingleN IParser<SingleN>.Parse(string s) => Parse(s);
            SingleN IParser<SingleN>.Parse(string s, NumberStyles style, IFormatProvider? provider) => Parse(s, style, provider);
        }
    }
}
