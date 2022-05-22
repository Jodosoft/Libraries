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

using Jodo.Extensions.Numerics;
using Jodo.Extensions.Primitives;
using System;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Runtime.Serialization;

namespace Jodo.Extensions.CheckedNumerics
{
    [Serializable]
    [DebuggerDisplay("{ToString(),nq}")]
    [SuppressMessage("Style", "IDE1006:Naming Styles")]
    [SuppressMessage("csharpsquid", "S101")]
    public readonly struct cfloat : INumeric<cfloat>
    {
        public static readonly cfloat Epsilon = new cfloat(float.Epsilon);
        public static readonly cfloat MaxValue = new cfloat(float.MaxValue);
        public static readonly cfloat MinValue = new cfloat(float.MinValue);

        private readonly float _value;

        public cfloat(float value)
        {
            if (float.IsFinite(value)) _value = value;
            else if (float.IsPositiveInfinity(value)) _value = float.MaxValue;
            else if (float.IsNegativeInfinity(value)) _value = float.MinValue;
            else _value = 0f;
        }

        private cfloat(SerializationInfo info, StreamingContext context) : this(info.GetSingle(nameof(cfloat))) { }
        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context) => info.AddValue(nameof(cfloat), _value);

        public int CompareTo(cfloat other) => _value.CompareTo(other._value);
        public int CompareTo(object? obj) => obj is cfloat other ? CompareTo(other) : 1;
        public bool Equals(cfloat other) => _value == other._value;
        public override bool Equals(object? obj) => obj is cfloat other && Equals(other);
        public override int GetHashCode() => _value.GetHashCode();
        public override string ToString() => _value.ToString();
        public string ToString(IFormatProvider formatProvider) => _value.ToString(formatProvider);
        public string ToString(string format) => _value.ToString(format);
        public string ToString(string format, IFormatProvider formatProvider) => _value.ToString(format, formatProvider);

        public static bool IsNormal(cfloat d) => float.IsNormal(d._value);
        public static bool IsSubnormal(cfloat d) => float.IsSubnormal(d._value);
        public static bool TryParse(string s, IFormatProvider provider, out cfloat result) => Try.Run(() => Parse(s, provider), out result);
        public static bool TryParse(string s, NumberStyles style, IFormatProvider provider, out cfloat result) => Try.Run(() => Parse(s, style, provider), out result);
        public static bool TryParse(string s, NumberStyles style, out cfloat result) => Try.Run(() => Parse(s, style), out result);
        public static bool TryParse(string s, out cfloat result) => Try.Run(() => Parse(s), out result);
        public static cfloat Parse(string s) => float.Parse(s);
        public static cfloat Parse(string s, IFormatProvider provider) => float.Parse(s, provider);
        public static cfloat Parse(string s, NumberStyles style) => float.Parse(s, style);
        public static cfloat Parse(string s, NumberStyles style, IFormatProvider provider) => float.Parse(s, style, provider);

        public static explicit operator cfloat(decimal value) => new cfloat(CheckedConvert.ToSingle(value));
        public static explicit operator cfloat(double value) => new cfloat(CheckedConvert.ToSingle(value));
        public static implicit operator cfloat(byte value) => new cfloat(value);
        public static implicit operator cfloat(char value) => new cfloat(value);
        public static implicit operator cfloat(float value) => new cfloat(value);
        public static implicit operator cfloat(int value) => new cfloat(value);
        public static implicit operator cfloat(long value) => new cfloat(value);
        public static implicit operator cfloat(sbyte value) => new cfloat(value);
        public static implicit operator cfloat(short value) => new cfloat(value);
        public static implicit operator cfloat(uint value) => new cfloat(value);
        public static implicit operator cfloat(ulong value) => new cfloat(value);
        public static implicit operator cfloat(ushort value) => new cfloat(value);

        public static explicit operator byte(cfloat value) => CheckedConvert.ToByte(value._value);
        public static explicit operator char(cfloat value) => CheckedConvert.ToChar(value._value);
        public static explicit operator decimal(cfloat value) => CheckedConvert.ToDecimal(value._value);
        public static explicit operator int(cfloat value) => CheckedConvert.ToInt32(value._value);
        public static explicit operator long(cfloat value) => CheckedConvert.ToInt64(value._value);
        public static explicit operator sbyte(cfloat value) => CheckedConvert.ToSByte(value._value);
        public static explicit operator short(cfloat value) => CheckedConvert.ToInt16(value._value);
        public static explicit operator uint(cfloat value) => CheckedConvert.ToUInt32(value._value);
        public static explicit operator ulong(cfloat value) => CheckedConvert.ToUInt64(value._value);
        public static explicit operator ushort(cfloat value) => CheckedConvert.ToUInt16(value._value);
        public static implicit operator double(cfloat value) => value._value;
        public static implicit operator float(cfloat value) => value._value;

        public static bool operator !=(cfloat left, cfloat right) => left._value != right._value;
        public static bool operator <(cfloat left, cfloat right) => left._value < right._value;
        public static bool operator <=(cfloat left, cfloat right) => left._value <= right._value;
        public static bool operator ==(cfloat left, cfloat right) => left._value == right._value;
        public static bool operator >(cfloat left, cfloat right) => left._value > right._value;
        public static bool operator >=(cfloat left, cfloat right) => left._value >= right._value;
        public static cfloat operator %(cfloat left, cfloat right) => CheckedArithmetic.Remainder(left._value, right._value);
        public static cfloat operator &(cfloat left, cfloat right) => BitwiseAndShiftUtilities.LogicalAnd(left._value, right._value);
        public static cfloat operator -(cfloat left, cfloat right) => CheckedArithmetic.Subtract(left._value, right._value);
        public static cfloat operator --(cfloat value) => value - 1;
        public static cfloat operator -(cfloat value) => -value._value;
        public static cfloat operator *(cfloat left, cfloat right) => CheckedArithmetic.Multiply(left._value, right._value);
        public static cfloat operator /(cfloat left, cfloat right) => CheckedArithmetic.Divide(left._value, right._value);
        public static cfloat operator ^(cfloat left, cfloat right) => BitwiseAndShiftUtilities.LogicalExclusiveOr(left._value, right._value);
        public static cfloat operator |(cfloat left, cfloat right) => BitwiseAndShiftUtilities.LogicalOr(left._value, right._value);
        public static cfloat operator ~(cfloat left) => BitwiseAndShiftUtilities.BitwiseComplement(left._value);
        public static cfloat operator +(cfloat left, cfloat right) => CheckedArithmetic.Add(left._value, right._value);
        public static cfloat operator +(cfloat value) => value;
        public static cfloat operator ++(cfloat value) => value + 1;
        public static cfloat operator <<(cfloat left, int right) => BitwiseAndShiftUtilities.LeftShift(left._value, right);
        public static cfloat operator >>(cfloat left, int right) => BitwiseAndShiftUtilities.RightShift(left._value, right);

        bool INumeric<cfloat>.IsGreaterThan(cfloat value) => this > value;
        bool INumeric<cfloat>.IsGreaterThanOrEqualTo(cfloat value) => this >= value;
        bool INumeric<cfloat>.IsLessThan(cfloat value) => this < value;
        bool INumeric<cfloat>.IsLessThanOrEqualTo(cfloat value) => this <= value;
        cfloat INumeric<cfloat>.Add(cfloat value) => this + value;
        cfloat INumeric<cfloat>.BitwiseComplement() => ~this;
        cfloat INumeric<cfloat>.Divide(cfloat value) => this / value;
        cfloat INumeric<cfloat>.LeftShift(int count) => this << count;
        cfloat INumeric<cfloat>.LogicalAnd(cfloat value) => this & value;
        cfloat INumeric<cfloat>.LogicalExclusiveOr(cfloat value) => this ^ value;
        cfloat INumeric<cfloat>.LogicalOr(cfloat value) => this | value;
        cfloat INumeric<cfloat>.Multiply(cfloat value) => this * value;
        cfloat INumeric<cfloat>.Negative() => -this;
        cfloat INumeric<cfloat>.Positive() => +this;
        cfloat INumeric<cfloat>.Remainder(cfloat value) => this % value;
        cfloat INumeric<cfloat>.RightShift(int count) => this >> count;
        cfloat INumeric<cfloat>.Subtract(cfloat value) => this - value;

        IBitConverter<cfloat> IBitConvertible<cfloat>.BitConverter => Utilities.Instance;
        IConvert<cfloat> IConvertible<cfloat>.Convert => Utilities.Instance;
        IMath<cfloat> INumeric<cfloat>.Math => Utilities.Instance;
        INumericFunctions<cfloat> INumeric<cfloat>.NumericFunctions => Utilities.Instance;
        IRandom<cfloat> IRandomisable<cfloat>.Random => Utilities.Instance;
        IStringParser<cfloat> IStringParsable<cfloat>.StringParser => Utilities.Instance;

        private sealed class Utilities :
            IBitConverter<cfloat>,
            IConvert<cfloat>,
            IMath<cfloat>,
            INumericFunctions<cfloat>,
            IRandom<cfloat>,
            IStringParser<cfloat>
        {
            public readonly static Utilities Instance = new Utilities();

            bool INumericFunctions<cfloat>.HasFloatingPoint { get; } = true;
            bool INumericFunctions<cfloat>.IsReal { get; } = true;
            bool INumericFunctions<cfloat>.IsSigned { get; } = true;
            cfloat IMath<cfloat>.E { get; } = MathF.E;
            cfloat INumericFunctions<cfloat>.Epsilon => Epsilon;
            cfloat INumericFunctions<cfloat>.MaxUnit { get; } = 1;
            cfloat INumericFunctions<cfloat>.MaxValue => MaxValue;
            cfloat INumericFunctions<cfloat>.MinUnit { get; } = -1;
            cfloat INumericFunctions<cfloat>.MinValue => MinValue;
            cfloat INumericFunctions<cfloat>.One { get; } = 1;
            cfloat IMath<cfloat>.PI { get; } = MathF.PI;
            cfloat IMath<cfloat>.Tau { get; } = MathF.PI * 2f;
            cfloat INumericFunctions<cfloat>.Ten { get; } = 10;
            cfloat INumericFunctions<cfloat>.Two { get; } = 2;
            cfloat INumericFunctions<cfloat>.Zero { get; } = 0;

            int IMath<cfloat>.Sign(cfloat x) => Math.Sign(x._value);
            bool INumericFunctions<cfloat>.IsFinite(cfloat x) => true;
            bool INumericFunctions<cfloat>.IsInfinity(cfloat x) => false;
            bool INumericFunctions<cfloat>.IsNaN(cfloat x) => false;
            bool INumericFunctions<cfloat>.IsNegative(cfloat x) => x._value < 0;
            bool INumericFunctions<cfloat>.IsNegativeInfinity(cfloat x) => false;
            bool INumericFunctions<cfloat>.IsNormal(cfloat x) => IsNormal(x);
            bool INumericFunctions<cfloat>.IsPositiveInfinity(cfloat x) => false;
            bool INumericFunctions<cfloat>.IsSubnormal(cfloat x) => IsSubnormal(x);

            cfloat IMath<cfloat>.Abs(cfloat x) => MathF.Abs(x._value);
            cfloat IMath<cfloat>.Acos(cfloat x) => MathF.Acos(x._value);
            cfloat IMath<cfloat>.Acosh(cfloat x) => MathF.Acosh(x._value);
            cfloat IMath<cfloat>.Asin(cfloat x) => MathF.Asin(x._value);
            cfloat IMath<cfloat>.Asinh(cfloat x) => MathF.Asinh(x._value);
            cfloat IMath<cfloat>.Atan(cfloat x) => MathF.Atan(x._value);
            cfloat IMath<cfloat>.Atan2(cfloat x, cfloat y) => MathF.Atan2(x._value, y._value);
            cfloat IMath<cfloat>.Atanh(cfloat x) => MathF.Atanh(x._value);
            cfloat IMath<cfloat>.Cbrt(cfloat x) => MathF.Cbrt(x._value);
            cfloat IMath<cfloat>.Ceiling(cfloat x) => MathF.Ceiling(x._value);
            cfloat IMath<cfloat>.Clamp(cfloat x, cfloat bound1, cfloat bound2) => bound1 > bound2 ? MathF.Min(bound1._value, MathF.Max(bound2._value, x._value)) : MathF.Min(bound2._value, MathF.Max(bound1._value, x._value));
            cfloat IMath<cfloat>.Cos(cfloat x) => MathF.Cos(x._value);
            cfloat IMath<cfloat>.Cosh(cfloat x) => MathF.Cosh(x._value);
            cfloat IMath<cfloat>.DegreesToRadians(cfloat x) => x._value * Trig.RadiansPerDegreeF;
            cfloat IMath<cfloat>.Exp(cfloat x) => MathF.Exp(x._value);
            cfloat IMath<cfloat>.Floor(cfloat x) => MathF.Floor(x._value);
            cfloat IMath<cfloat>.IEEERemainder(cfloat x, cfloat y) => MathF.IEEERemainder(x._value, y._value);
            cfloat IMath<cfloat>.Log(cfloat x) => MathF.Log(x._value);
            cfloat IMath<cfloat>.Log(cfloat x, cfloat y) => MathF.Log(x._value, y._value);
            cfloat IMath<cfloat>.Log10(cfloat x) => MathF.Log10(x._value);
            cfloat IMath<cfloat>.Max(cfloat x, cfloat y) => MathF.Max(x._value, y._value);
            cfloat IMath<cfloat>.Min(cfloat x, cfloat y) => MathF.Min(x._value, y._value);
            cfloat IMath<cfloat>.Pow(cfloat x, cfloat y) => MathF.Pow(x._value, y._value);
            cfloat IMath<cfloat>.RadiansToDegrees(cfloat x) => x._value * Trig.DegreesPerRadianF;
            cfloat IMath<cfloat>.Round(cfloat x) => MathF.Round(x._value);
            cfloat IMath<cfloat>.Round(cfloat x, int digits) => MathF.Round(x._value, digits);
            cfloat IMath<cfloat>.Round(cfloat x, int digits, MidpointRounding mode) => MathF.Round(x._value, digits, mode);
            cfloat IMath<cfloat>.Round(cfloat x, MidpointRounding mode) => MathF.Round(x._value, mode);
            cfloat IMath<cfloat>.Sin(cfloat x) => MathF.Sin(x._value);
            cfloat IMath<cfloat>.Sinh(cfloat x) => MathF.Sinh(x._value);
            cfloat IMath<cfloat>.Sqrt(cfloat x) => MathF.Sqrt(x._value);
            cfloat IMath<cfloat>.Tan(cfloat x) => MathF.Tan(x._value);
            cfloat IMath<cfloat>.Tanh(cfloat x) => MathF.Tanh(x._value);
            cfloat IMath<cfloat>.Truncate(cfloat x) => MathF.Truncate(x._value);

            cfloat IBitConverter<cfloat>.Read(IReadOnlyStream<byte> stream) => BitConverter.ToSingle(stream.Read(sizeof(float)));
            void IBitConverter<cfloat>.Write(cfloat value, IWriteOnlyStream<byte> stream) => stream.Write(BitConverter.GetBytes(value._value));

            cfloat IRandom<cfloat>.Next(Random random) => random.NextSingle(float.MinValue, float.MaxValue);
            cfloat IRandom<cfloat>.Next(Random random, cfloat bound1, cfloat bound2) => random.NextSingle(bound1._value, bound2._value);

            bool IConvert<cfloat>.ToBoolean(cfloat value) => CheckedConvert.ToBoolean(value._value);
            byte IConvert<cfloat>.ToByte(cfloat value) => CheckedConvert.ToByte(value._value);
            decimal IConvert<cfloat>.ToDecimal(cfloat value) => CheckedConvert.ToDecimal(value._value);
            double IConvert<cfloat>.ToDouble(cfloat value) => CheckedConvert.ToDouble(value._value);
            float IConvert<cfloat>.ToSingle(cfloat value) => value._value;
            int IConvert<cfloat>.ToInt32(cfloat value) => CheckedConvert.ToInt32(value._value);
            long IConvert<cfloat>.ToInt64(cfloat value) => CheckedConvert.ToInt64(value._value);
            sbyte IConvert<cfloat>.ToSByte(cfloat value) => CheckedConvert.ToSByte(value._value);
            short IConvert<cfloat>.ToInt16(cfloat value) => CheckedConvert.ToInt16(value._value);
            string IConvert<cfloat>.ToString(cfloat value) => Convert.ToString(value._value);
            string IConvert<cfloat>.ToString(cfloat value, IFormatProvider provider) => Convert.ToString(value._value, provider);
            uint IConvert<cfloat>.ToUInt32(cfloat value) => CheckedConvert.ToUInt32(value._value);
            ulong IConvert<cfloat>.ToUInt64(cfloat value) => CheckedConvert.ToUInt64(value._value);
            ushort IConvert<cfloat>.ToUInt16(cfloat value) => CheckedConvert.ToUInt16(value._value);

            cfloat IConvert<cfloat>.ToValue(bool value) => CheckedConvert.ToSingle(value);
            cfloat IConvert<cfloat>.ToValue(byte value) => CheckedConvert.ToSingle(value);
            cfloat IConvert<cfloat>.ToValue(decimal value) => CheckedConvert.ToSingle(value);
            cfloat IConvert<cfloat>.ToValue(double value) => CheckedConvert.ToSingle(value);
            cfloat IConvert<cfloat>.ToValue(float value) => value;
            cfloat IConvert<cfloat>.ToValue(int value) => CheckedConvert.ToSingle(value);
            cfloat IConvert<cfloat>.ToValue(long value) => CheckedConvert.ToSingle(value);
            cfloat IConvert<cfloat>.ToValue(sbyte value) => CheckedConvert.ToSingle(value);
            cfloat IConvert<cfloat>.ToValue(short value) => CheckedConvert.ToSingle(value);
            cfloat IConvert<cfloat>.ToValue(string value) => Convert.ToSingle(value);
            cfloat IConvert<cfloat>.ToValue(string value, IFormatProvider provider) => Convert.ToSingle(value, provider);
            cfloat IConvert<cfloat>.ToValue(uint value) => CheckedConvert.ToSingle(value);
            cfloat IConvert<cfloat>.ToValue(ulong value) => CheckedConvert.ToSingle(value);
            cfloat IConvert<cfloat>.ToValue(ushort value) => CheckedConvert.ToSingle(value);

            bool IStringParser<cfloat>.TryParse(string s, IFormatProvider provider, out cfloat result) => TryParse(s, provider, out result);
            bool IStringParser<cfloat>.TryParse(string s, NumberStyles style, IFormatProvider provider, out cfloat result) => TryParse(s, style, provider, out result);
            bool IStringParser<cfloat>.TryParse(string s, NumberStyles style, out cfloat result) => TryParse(s, style, out result);
            bool IStringParser<cfloat>.TryParse(string s, out cfloat result) => TryParse(s, out result);
            cfloat IStringParser<cfloat>.Parse(string s) => Parse(s);
            cfloat IStringParser<cfloat>.Parse(string s, IFormatProvider provider) => Parse(s, provider);
            cfloat IStringParser<cfloat>.Parse(string s, NumberStyles style) => Parse(s, style);
            cfloat IStringParser<cfloat>.Parse(string s, NumberStyles style, IFormatProvider provider) => Parse(s, style, provider);
        }
    }
}
