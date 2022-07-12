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
using Jodo.Numerics;
using Jodo.Primitives;
using Jodo.Primitives.Compatibility;

namespace Jodo.CheckedNumerics
{
    [Serializable]
    [DebuggerDisplay("{ToString(),nq}")]
    [SuppressMessage("Style", "IDE1006:Naming Styles")]
    [SuppressMessage("csharpsquid", "S101")]
    public readonly struct cdouble : INumericExtended<cdouble>
    {
        public static readonly cdouble Epsilon = double.Epsilon;
        public static readonly cdouble MaxValue = double.MaxValue;
        public static readonly cdouble MinValue = double.MinValue;

        private readonly double _value;

        public cdouble(double value)
        {
            _value = Check(value);
        }

        private cdouble(SerializationInfo info, StreamingContext context)
        {
            _value = Check(info.GetDouble(nameof(cdouble)));
        }

        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue(nameof(cdouble), _value);
        }

        public int CompareTo(cdouble other) => _value.CompareTo(other._value);
        public int CompareTo(object? obj) => obj is cdouble other ? CompareTo(other) : 1;
        public bool Equals(cdouble other) => _value == other._value;
        public override bool Equals(object? obj) => obj is cdouble other && Equals(other);
        public override int GetHashCode() => _value.GetHashCode();
        public override string ToString() => _value.ToString();
        public string ToString(IFormatProvider formatProvider) => _value.ToString(formatProvider);
        public string ToString(string format) => _value.ToString(format);
        public string ToString(string? format, IFormatProvider? formatProvider) => _value.ToString(format, formatProvider);

        public static bool IsNormal(cdouble d) => DoubleCompat.IsNormal(d._value);
        public static bool IsSubnormal(cdouble d) => DoubleCompat.IsSubnormal(d._value);
        public static bool TryParse(string s, IFormatProvider? provider, out cdouble result) => Try.Run(() => Parse(s, provider), out result);
        public static bool TryParse(string s, NumberStyles style, IFormatProvider? provider, out cdouble result) => Try.Run(() => Parse(s, style, provider), out result);
        public static bool TryParse(string s, NumberStyles style, out cdouble result) => Try.Run(() => Parse(s, style), out result);
        public static bool TryParse(string s, out cdouble result) => Try.Run(() => Parse(s), out result);
        public static cdouble Parse(string s) => double.Parse(s);
        public static cdouble Parse(string s, IFormatProvider? provider) => double.Parse(s, provider);
        public static cdouble Parse(string s, NumberStyles style) => double.Parse(s, style);
        public static cdouble Parse(string s, NumberStyles style, IFormatProvider? provider) => double.Parse(s, style, provider);

        [CLSCompliant(false)] public static implicit operator cdouble(sbyte value) => new cdouble(value);
        [CLSCompliant(false)] public static implicit operator cdouble(uint value) => new cdouble(value);
        [CLSCompliant(false)] public static implicit operator cdouble(ulong value) => new cdouble(value);
        [CLSCompliant(false)] public static implicit operator cdouble(ushort value) => new cdouble(value);
        public static explicit operator cdouble(decimal value) => new cdouble(NumericConvert.ToDouble(value, Conversion.CastClamp));
        public static implicit operator cdouble(byte value) => new cdouble(value);
        public static implicit operator cdouble(double value) => new cdouble(value);
        public static implicit operator cdouble(float value) => new cdouble(value);
        public static implicit operator cdouble(int value) => new cdouble(value);
        public static implicit operator cdouble(long value) => new cdouble(value);
        public static implicit operator cdouble(short value) => new cdouble(value);

        [CLSCompliant(false)] public static explicit operator sbyte(cdouble value) => NumericConvert.ToSByte(value._value, Conversion.CastClamp);
        [CLSCompliant(false)] public static explicit operator uint(cdouble value) => NumericConvert.ToUInt32(value._value, Conversion.CastClamp);
        [CLSCompliant(false)] public static explicit operator ulong(cdouble value) => NumericConvert.ToUInt64(value._value, Conversion.CastClamp);
        [CLSCompliant(false)] public static explicit operator ushort(cdouble value) => NumericConvert.ToUInt16(value._value, Conversion.CastClamp);
        public static explicit operator byte(cdouble value) => NumericConvert.ToByte(value._value, Conversion.CastClamp);
        public static explicit operator decimal(cdouble value) => NumericConvert.ToDecimal(value._value, Conversion.CastClamp);
        public static explicit operator float(cdouble value) => NumericConvert.ToSingle(value._value, Conversion.CastClamp);
        public static explicit operator int(cdouble value) => NumericConvert.ToInt32(value._value, Conversion.CastClamp);
        public static explicit operator long(cdouble value) => NumericConvert.ToInt64(value._value, Conversion.CastClamp);
        public static explicit operator short(cdouble value) => NumericConvert.ToInt16(value._value, Conversion.CastClamp);
        public static implicit operator double(cdouble value) => value._value;

        public static bool operator !=(cdouble left, cdouble right) => left._value != right._value;
        public static bool operator <(cdouble left, cdouble right) => left._value < right._value;
        public static bool operator <=(cdouble left, cdouble right) => left._value <= right._value;
        public static bool operator ==(cdouble left, cdouble right) => left._value == right._value;
        public static bool operator >(cdouble left, cdouble right) => left._value > right._value;
        public static bool operator >=(cdouble left, cdouble right) => left._value >= right._value;
        public static cdouble operator %(cdouble left, cdouble right) => CheckedArithmetic.Remainder(left._value, right._value);
        public static cdouble operator -(cdouble left, cdouble right) => CheckedArithmetic.Subtract(left._value, right._value);
        public static cdouble operator --(cdouble value) => value - 1;
        public static cdouble operator -(cdouble value) => -value._value;
        public static cdouble operator *(cdouble left, cdouble right) => CheckedArithmetic.Multiply(left._value, right._value);
        public static cdouble operator /(cdouble left, cdouble right) => CheckedArithmetic.Divide(left._value, right._value);
        public static cdouble operator +(cdouble left, cdouble right) => CheckedArithmetic.Add(left._value, right._value);
        public static cdouble operator +(cdouble value) => value;
        public static cdouble operator ++(cdouble value) => value + 1;
        public static cdouble operator &(cdouble left, cdouble right) => NumericUtilities.LogicalAnd(left._value, right._value);
        public static cdouble operator |(cdouble left, cdouble right) => NumericUtilities.LogicalOr(left._value, right._value);
        public static cdouble operator ^(cdouble left, cdouble right) => NumericUtilities.LogicalExclusiveOr(left._value, right._value);
        public static cdouble operator ~(cdouble left) => NumericUtilities.BitwiseComplement(left._value);
        public static cdouble operator >>(cdouble left, int right) => NumericUtilities.RightShift(left._value, right);
        public static cdouble operator <<(cdouble left, int right) => NumericUtilities.LeftShift(left._value, right);

        private static double Check(double value)
        {
            if (DoubleCompat.IsFinite(value)) return value;
            else if (double.IsPositiveInfinity(value)) return double.MaxValue;
            else if (double.IsNegativeInfinity(value)) return double.MinValue;
            else return 0d;
        }

        bool INumeric<cdouble>.IsGreaterThan(cdouble value) => this > value;
        bool INumeric<cdouble>.IsGreaterThanOrEqualTo(cdouble value) => this >= value;
        bool INumeric<cdouble>.IsLessThan(cdouble value) => this < value;
        bool INumeric<cdouble>.IsLessThanOrEqualTo(cdouble value) => this <= value;
        cdouble INumeric<cdouble>.Add(cdouble value) => this + value;
        cdouble INumeric<cdouble>.BitwiseComplement() => ~this;
        cdouble INumeric<cdouble>.Divide(cdouble value) => this / value;
        cdouble INumeric<cdouble>.LeftShift(int count) => this << count;
        cdouble INumeric<cdouble>.LogicalAnd(cdouble value) => this & value;
        cdouble INumeric<cdouble>.LogicalExclusiveOr(cdouble value) => this ^ value;
        cdouble INumeric<cdouble>.LogicalOr(cdouble value) => this | value;
        cdouble INumeric<cdouble>.Multiply(cdouble value) => this * value;
        cdouble INumeric<cdouble>.Negative() => -this;
        cdouble INumeric<cdouble>.Positive() => +this;
        cdouble INumeric<cdouble>.Remainder(cdouble value) => this % value;
        cdouble INumeric<cdouble>.RightShift(int count) => this >> count;
        cdouble INumeric<cdouble>.Subtract(cdouble value) => this - value;

        IBitConverter<cdouble> IProvider<IBitConverter<cdouble>>.GetInstance() => Utilities.Instance;
        IConvert<cdouble> IProvider<IConvert<cdouble>>.GetInstance() => Utilities.Instance;
        IConvertUnsigned<cdouble> IProvider<IConvertUnsigned<cdouble>>.GetInstance() => Utilities.Instance;
        IMath<cdouble> IProvider<IMath<cdouble>>.GetInstance() => Utilities.Instance;
        INumericStatic<cdouble> IProvider<INumericStatic<cdouble>>.GetInstance() => Utilities.Instance;
        IRandom<cdouble> IProvider<IRandom<cdouble>>.GetInstance() => Utilities.Instance;
        IParser<cdouble> IProvider<IParser<cdouble>>.GetInstance() => Utilities.Instance;

        private sealed class Utilities :
            IBitConverter<cdouble>,
            IConvert<cdouble>,
            IConvertUnsigned<cdouble>,
            IMath<cdouble>,
            INumericStatic<cdouble>,
            IRandom<cdouble>,
            IParser<cdouble>
        {
            public static readonly Utilities Instance = new Utilities();

            bool INumericStatic<cdouble>.HasFloatingPoint { get; } = true;
            bool INumericStatic<cdouble>.HasInfinity { get; } = false;
            bool INumericStatic<cdouble>.HasNaN { get; } = false;
            bool INumericStatic<cdouble>.IsFinite(cdouble x) => true;
            bool INumericStatic<cdouble>.IsInfinity(cdouble x) => false;
            bool INumericStatic<cdouble>.IsNaN(cdouble x) => false;
            bool INumericStatic<cdouble>.IsNegative(cdouble x) => x._value < 0;
            bool INumericStatic<cdouble>.IsNegativeInfinity(cdouble x) => false;
            bool INumericStatic<cdouble>.IsNormal(cdouble x) => IsNormal(x);
            bool INumericStatic<cdouble>.IsPositiveInfinity(cdouble x) => false;
            bool INumericStatic<cdouble>.IsReal { get; } = true;
            bool INumericStatic<cdouble>.IsSigned { get; } = true;
            bool INumericStatic<cdouble>.IsSubnormal(cdouble x) => IsSubnormal(x);
            cdouble INumericStatic<cdouble>.Epsilon => Epsilon;
            cdouble INumericStatic<cdouble>.MaxUnit { get; } = 1d;
            cdouble INumericStatic<cdouble>.MaxValue => MaxValue;
            cdouble INumericStatic<cdouble>.MinUnit { get; } = -1d;
            cdouble INumericStatic<cdouble>.MinValue => MinValue;
            cdouble INumericStatic<cdouble>.One { get; } = 1d;
            cdouble INumericStatic<cdouble>.Ten { get; } = 10d;
            cdouble INumericStatic<cdouble>.Two { get; } = 2d;
            cdouble INumericStatic<cdouble>.Zero { get; } = 0d;

            cdouble IMath<cdouble>.Abs(cdouble value) => Math.Abs(value._value);
            cdouble IMath<cdouble>.Acos(cdouble x) => Math.Acos(x._value);
            cdouble IMath<cdouble>.Acosh(cdouble x) => MathCompat.Acosh(x._value);
            cdouble IMath<cdouble>.Asin(cdouble x) => Math.Asin(x._value);
            cdouble IMath<cdouble>.Asinh(cdouble x) => MathCompat.Asinh(x._value);
            cdouble IMath<cdouble>.Atan(cdouble x) => Math.Atan(x._value);
            cdouble IMath<cdouble>.Atan2(cdouble x, cdouble y) => Math.Atan2(x._value, y._value);
            cdouble IMath<cdouble>.Atanh(cdouble x) => MathCompat.Atanh(x._value);
            cdouble IMath<cdouble>.Cbrt(cdouble x) => MathCompat.Cbrt(x._value);
            cdouble IMath<cdouble>.Ceiling(cdouble x) => Math.Ceiling(x._value);
            cdouble IMath<cdouble>.Clamp(cdouble x, cdouble bound1, cdouble bound2) => bound1 > bound2 ? Math.Min(bound1._value, Math.Max(bound2._value, x._value)) : Math.Min(bound2._value, Math.Max(bound1._value, x._value));
            cdouble IMath<cdouble>.Cos(cdouble x) => Math.Cos(x._value);
            cdouble IMath<cdouble>.Cosh(cdouble x) => Math.Cosh(x._value);
            cdouble IMath<cdouble>.DegreesToRadians(cdouble degrees) => degrees * NumericUtilities.RadiansPerDegree;
            cdouble IMath<cdouble>.E { get; } = Math.E;
            cdouble IMath<cdouble>.Exp(cdouble x) => Math.Exp(x._value);
            cdouble IMath<cdouble>.Floor(cdouble x) => Math.Floor(x._value);
            cdouble IMath<cdouble>.IEEERemainder(cdouble x, cdouble y) => Math.IEEERemainder(x._value, y._value);
            cdouble IMath<cdouble>.Log(cdouble x) => Math.Log(x._value);
            cdouble IMath<cdouble>.Log(cdouble x, cdouble y) => Math.Log(x._value, y._value);
            cdouble IMath<cdouble>.Log10(cdouble x) => Math.Log10(x._value);
            cdouble IMath<cdouble>.Max(cdouble x, cdouble y) => Math.Max(x._value, y._value);
            cdouble IMath<cdouble>.Min(cdouble x, cdouble y) => Math.Min(x._value, y._value);
            cdouble IMath<cdouble>.PI { get; } = Math.PI;
            cdouble IMath<cdouble>.Pow(cdouble x, cdouble y) => Math.Pow(x._value, y._value);
            cdouble IMath<cdouble>.RadiansToDegrees(cdouble radians) => radians * NumericUtilities.DegreesPerRadian;
            cdouble IMath<cdouble>.Round(cdouble x) => Math.Round(x._value);
            cdouble IMath<cdouble>.Round(cdouble x, int digits) => Math.Round(x._value, digits);
            cdouble IMath<cdouble>.Round(cdouble x, int digits, MidpointRounding mode) => Math.Round(x._value, digits, mode);
            cdouble IMath<cdouble>.Round(cdouble x, MidpointRounding mode) => Math.Round(x._value, mode);
            cdouble IMath<cdouble>.Sin(cdouble x) => Math.Sin(x._value);
            cdouble IMath<cdouble>.Sinh(cdouble x) => Math.Sinh(x._value);
            cdouble IMath<cdouble>.Sqrt(cdouble x) => Math.Sqrt(x._value);
            cdouble IMath<cdouble>.Tan(cdouble x) => Math.Tan(x._value);
            cdouble IMath<cdouble>.Tanh(cdouble x) => Math.Tanh(x._value);
            cdouble IMath<cdouble>.Tau { get; } = Math.PI * 2d;
            cdouble IMath<cdouble>.Truncate(cdouble x) => Math.Truncate(x._value);
            int IMath<cdouble>.Sign(cdouble x) => Math.Sign(x._value);

            cdouble IBitConverter<cdouble>.Read(IReadOnlyStream<byte> stream) => BitConverter.ToDouble(stream.Read(sizeof(double)), 0);
            void IBitConverter<cdouble>.Write(cdouble value, IWriteOnlyStream<byte> stream) => stream.Write(BitConverter.GetBytes(value._value));

            cdouble IRandom<cdouble>.Next(Random random) => random.NextDouble(double.MinValue, double.MaxValue);
            cdouble IRandom<cdouble>.Next(Random random, cdouble bound1, cdouble bound2) => random.NextDouble(bound1._value, bound2._value);

            bool IConvert<cdouble>.ToBoolean(cdouble value) => value._value != 0;
            byte IConvert<cdouble>.ToByte(cdouble value, Conversion mode) => NumericConvert.ToByte(value._value, mode.Clamped());
            decimal IConvert<cdouble>.ToDecimal(cdouble value, Conversion mode) => NumericConvert.ToDecimal(value._value, mode.Clamped());
            double IConvert<cdouble>.ToDouble(cdouble value, Conversion mode) => value._value;
            float IConvert<cdouble>.ToSingle(cdouble value, Conversion mode) => NumericConvert.ToSingle(value._value, mode.Clamped());
            int IConvert<cdouble>.ToInt32(cdouble value, Conversion mode) => NumericConvert.ToInt32(value._value, mode.Clamped());
            long IConvert<cdouble>.ToInt64(cdouble value, Conversion mode) => NumericConvert.ToInt64(value._value, mode.Clamped());
            sbyte IConvertUnsigned<cdouble>.ToSByte(cdouble value, Conversion mode) => NumericConvert.ToSByte(value._value, mode.Clamped());
            short IConvert<cdouble>.ToInt16(cdouble value, Conversion mode) => NumericConvert.ToInt16(value._value, mode.Clamped());
            string IConvert<cdouble>.ToString(cdouble value) => Convert.ToString(value._value);
            uint IConvertUnsigned<cdouble>.ToUInt32(cdouble value, Conversion mode) => NumericConvert.ToUInt32(value._value, mode.Clamped());
            ulong IConvertUnsigned<cdouble>.ToUInt64(cdouble value, Conversion mode) => NumericConvert.ToUInt64(value._value, mode.Clamped());
            ushort IConvertUnsigned<cdouble>.ToUInt16(cdouble value, Conversion mode) => NumericConvert.ToUInt16(value._value, mode.Clamped());

            cdouble IConvert<cdouble>.ToValue(bool value) => value ? 1d : 0d;
            cdouble IConvert<cdouble>.ToValue(byte value, Conversion mode) => NumericConvert.ToDouble(value, mode.Clamped());
            cdouble IConvert<cdouble>.ToValue(decimal value, Conversion mode) => NumericConvert.ToDouble(value, mode.Clamped());
            cdouble IConvert<cdouble>.ToValue(double value, Conversion mode) => value;
            cdouble IConvert<cdouble>.ToValue(float value, Conversion mode) => NumericConvert.ToDouble(value, mode.Clamped());
            cdouble IConvert<cdouble>.ToValue(int value, Conversion mode) => NumericConvert.ToDouble(value, mode.Clamped());
            cdouble IConvert<cdouble>.ToValue(long value, Conversion mode) => NumericConvert.ToDouble(value, mode.Clamped());
            cdouble IConvertUnsigned<cdouble>.ToValue(sbyte value, Conversion mode) => NumericConvert.ToDouble(value, mode.Clamped());
            cdouble IConvert<cdouble>.ToValue(short value, Conversion mode) => NumericConvert.ToDouble(value, mode.Clamped());
            cdouble IConvert<cdouble>.ToValue(string value) => Convert.ToDouble(value);
            cdouble IConvertUnsigned<cdouble>.ToNumeric(uint value, Conversion mode) => NumericConvert.ToDouble(value, mode.Clamped());
            cdouble IConvertUnsigned<cdouble>.ToNumeric(ulong value, Conversion mode) => NumericConvert.ToDouble(value, mode.Clamped());
            cdouble IConvertUnsigned<cdouble>.ToNumeric(ushort value, Conversion mode) => NumericConvert.ToDouble(value, mode.Clamped());

            cdouble IParser<cdouble>.Parse(string s) => Parse(s);
            cdouble IParser<cdouble>.Parse(string s, NumberStyles style, IFormatProvider? provider) => Parse(s, style, provider);
        }
    }
}
