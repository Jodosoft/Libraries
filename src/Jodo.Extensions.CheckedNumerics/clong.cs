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
    [SuppressMessage("CodeQuality", "IDE0079:Remove unnecessary suppression")]
    [SuppressMessage("csharpsquid", "S101")]
    public readonly struct clong : INumeric<clong>
    {
        public static readonly clong MaxValue = new clong(long.MaxValue);
        public static readonly clong MinValue = new clong(long.MinValue);

        private readonly long _value;

        private clong(long value)
        {
            _value = value;
        }

        private clong(SerializationInfo info, StreamingContext context) : this(info.GetInt64(nameof(clong))) { }
        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context) => info.AddValue(nameof(clong), _value);

        public int CompareTo(clong other) => _value.CompareTo(other._value);
        public int CompareTo(object? obj) => obj is clong other ? CompareTo(other) : 1;
        public bool Equals(clong other) => _value == other._value;
        public override bool Equals(object? obj) => obj is clong other && Equals(other);
        public override int GetHashCode() => _value.GetHashCode();
        public override string ToString() => _value.ToString();
        public string ToString(IFormatProvider formatProvider) => _value.ToString(formatProvider);
        public string ToString(string format, IFormatProvider formatProvider) => _value.ToString(format, formatProvider);

        public static bool TryParse(string s, IFormatProvider provider, out clong result) => Try.Run(() => Parse(s, provider), out result);
        public static bool TryParse(string s, NumberStyles style, IFormatProvider provider, out clong result) => Try.Run(() => Parse(s, style, provider), out result);
        public static bool TryParse(string s, NumberStyles style, out clong result) => Try.Run(() => Parse(s, style), out result);
        public static bool TryParse(string s, out clong result) => Try.Run(() => Parse(s), out result);
        public static clong Parse(string s) => long.Parse(s);
        public static clong Parse(string s, IFormatProvider provider) => long.Parse(s, provider);
        public static clong Parse(string s, NumberStyles style) => long.Parse(s, style);
        public static clong Parse(string s, NumberStyles style, IFormatProvider provider) => long.Parse(s, style, provider);

        public static explicit operator clong(in decimal value) => new clong(CheckedTruncate.ToInt64(value));
        public static explicit operator clong(in double value) => new clong(CheckedTruncate.ToInt64(value));
        public static explicit operator clong(in float value) => new clong(CheckedTruncate.ToInt64(value));
        public static explicit operator clong(in ulong value) => new clong(CheckedConvert.ToInt64(value));
        public static implicit operator clong(in byte value) => new clong(value);
        public static implicit operator clong(in char value) => new clong(value);
        public static implicit operator clong(in int value) => new clong(value);
        public static implicit operator clong(in long value) => new clong(value);
        public static implicit operator clong(in sbyte value) => new clong(value);
        public static implicit operator clong(in short value) => new clong(value);
        public static implicit operator clong(in uint value) => new clong(value);
        public static implicit operator clong(in ushort value) => new clong(value);

        public static explicit operator byte(in clong value) => CheckedConvert.ToByte(value._value);
        public static explicit operator char(in clong value) => CheckedConvert.ToChar(value._value);
        public static explicit operator int(in clong value) => CheckedConvert.ToInt32(value._value);
        public static explicit operator sbyte(in clong value) => CheckedConvert.ToSByte(value._value);
        public static explicit operator short(in clong value) => CheckedConvert.ToInt16(value._value);
        public static explicit operator uint(in clong value) => CheckedConvert.ToUInt32(value._value);
        public static explicit operator ulong(in clong value) => CheckedConvert.ToUInt64(value._value);
        public static explicit operator ushort(in clong value) => CheckedConvert.ToUInt16(value._value);
        public static implicit operator decimal(in clong value) => value._value;
        public static implicit operator double(in clong value) => value._value;
        public static implicit operator float(in clong value) => value._value;
        public static implicit operator long(in clong value) => value._value;

        public static bool operator !=(in clong left, in clong right) => left._value != right._value;
        public static bool operator <(in clong left, in clong right) => left._value < right._value;
        public static bool operator <=(in clong left, in clong right) => left._value <= right._value;
        public static bool operator ==(in clong left, in clong right) => left._value == right._value;
        public static bool operator >(in clong left, in clong right) => left._value > right._value;
        public static bool operator >=(in clong left, in clong right) => left._value >= right._value;
        public static clong operator %(in clong left, in clong right) => CheckedArithmetic.Remainder(left._value, right._value);
        public static clong operator &(in clong left, in clong right) => left._value & right._value;
        public static clong operator -(in clong left, in clong right) => CheckedArithmetic.Subtract(left._value, right._value);
        public static clong operator --(in clong value) => CheckedArithmetic.Subtract(value._value, 1);
        public static clong operator -(in clong value) => -value._value;
        public static clong operator *(in clong left, in clong right) => CheckedArithmetic.Multiply(left._value, right._value);
        public static clong operator /(in clong left, in clong right) => CheckedArithmetic.Divide(left._value, right._value);
        public static clong operator ^(in clong left, in clong right) => left._value ^ right._value;
        public static clong operator |(in clong left, in clong right) => left._value | right._value;
        public static clong operator ~(in clong value) => ~value._value;
        public static clong operator +(in clong left, in clong right) => CheckedArithmetic.Add(left._value, right._value);
        public static clong operator +(in clong value) => value;
        public static clong operator ++(in clong value) => CheckedArithmetic.Add(value._value, 1);
        public static clong operator <<(in clong left, in int right) => left._value << right;
        public static clong operator >>(in clong left, in int right) => left._value >> right;

        IBitConverter<clong> IBitConvertible<clong>.BitConverter => Utilities.Instance;
        IMath<clong> INumeric<clong>.Math => Utilities.Instance;
        IRandom<clong> IRandomisable<clong>.Random => Utilities.Instance;
        IStringParser<clong> IStringRepresentable<clong>.StringParser => Utilities.Instance;

        private sealed class Utilities : IMath<clong>, IBitConverter<clong>, IRandom<clong>, IStringParser<clong>
        {
            public readonly static Utilities Instance = new Utilities();

            clong IMath<clong>.E { get; } = 2L;
            clong IMath<clong>.PI { get; } = 3L;
            clong IMath<clong>.Epsilon { get; } = 1L;
            clong IMath<clong>.MaxValue => MaxValue;
            clong IMath<clong>.MinValue => MinValue;
            clong IMath<clong>.MaxUnit { get; } = 1L;
            clong IMath<clong>.MinUnit { get; } = -1L;
            clong IMath<clong>.Zero { get; } = 0L;
            clong IMath<clong>.One { get; } = 1L;
            bool IMath<clong>.IsSigned { get; } = true;
            bool IMath<clong>.IsReal { get; } = false;

            bool IMath<clong>.IsGreaterThan(in clong x, in clong y) => x > y;
            bool IMath<clong>.IsGreaterThanOrEqualTo(in clong x, in clong y) => x >= y;
            bool IMath<clong>.IsLessThan(in clong x, in clong y) => x < y;
            bool IMath<clong>.IsLessThanOrEqualTo(in clong x, in clong y) => x <= y;
            clong IMath<clong>.Abs(in clong x) => Math.Abs(x._value);
            clong IMath<clong>.Acos(in clong x) => (clong)Math.Acos(x._value);
            clong IMath<clong>.Acosh(in clong x) => (clong)Math.Acosh(x._value);
            clong IMath<clong>.Add(in clong x, in clong y) => x + y;
            clong IMath<clong>.Asin(in clong x) => (clong)Math.Asin(x._value);
            clong IMath<clong>.Asinh(in clong x) => (clong)Math.Asinh(x._value);
            clong IMath<clong>.Atan(in clong x) => (clong)Math.Atan(x._value);
            clong IMath<clong>.Atan2(in clong x, in clong y) => (clong)Math.Atan2(x._value, y._value);
            clong IMath<clong>.Atanh(in clong x) => (clong)Math.Atanh(x._value);
            clong IMath<clong>.Cbrt(in clong x) => (clong)Math.Cbrt(x._value);
            clong IMath<clong>.Ceiling(in clong x) => x;
            clong IMath<clong>.Clamp(in clong x, in clong bound1, in clong bound2) => bound1 > bound2 ? Math.Min(bound1._value, Math.Max(bound2._value, x._value)) : Math.Min(bound2._value, Math.Max(bound1._value, x._value));
            clong IMath<clong>.Cos(in clong x) => (clong)Math.Cos(x._value);
            clong IMath<clong>.Cosh(in clong x) => (clong)Math.Cosh(x._value);
            clong IMath<clong>.DegreesToRadians(in clong x) => (clong)CheckedArithmetic.Multiply(x, AngleConstants.RadiansPerDegree);
            clong IMath<clong>.DegreesToTurns(in clong x) => (clong)CheckedArithmetic.Multiply(x, AngleConstants.TurnsPerDegree);
            clong IMath<clong>.Divide(in clong x, in clong y) => x / y;
            clong IMath<clong>.Exp(in clong x) => (clong)Math.Exp(x._value);
            clong IMath<clong>.Floor(in clong x) => x;
            clong IMath<clong>.IEEERemainder(in clong x, in clong y) => (clong)Math.IEEERemainder(x._value, y._value);
            clong IMath<clong>.Log(in clong x) => (clong)Math.Log(x._value);
            clong IMath<clong>.Log(in clong x, in clong y) => (clong)Math.Log(x._value, y._value);
            clong IMath<clong>.Log10(in clong x) => (clong)Math.Log10(x._value);
            clong IMath<clong>.Max(in clong x, in clong y) => Math.Max(x._value, y._value);
            clong IMath<clong>.Min(in clong x, in clong y) => Math.Min(x._value, y._value);
            clong IMath<clong>.Multiply(in clong x, in clong y) => x * y;
            clong IMath<clong>.Negative(in clong x) => -x;
            clong IMath<clong>.Positive(in clong x) => +x;
            clong IMath<clong>.Pow(in clong x, in byte y) => CheckedArithmetic.Pow(x._value, y);
            clong IMath<clong>.Pow(in clong x, in clong y) => CheckedArithmetic.Pow(x._value, y._value);
            clong IMath<clong>.RadiansToDegrees(in clong x) => (clong)CheckedArithmetic.Multiply(x, AngleConstants.DegreesPerRadian);
            clong IMath<clong>.RadiansToTurns(in clong x) => (clong)CheckedArithmetic.Multiply(x, AngleConstants.TurnsPerRadian);
            clong IMath<clong>.Remainder(in clong x, in clong y) => x % y;
            clong IMath<clong>.Round(in clong x) => x;
            clong IMath<clong>.Round(in clong x, in int digits) => x;
            clong IMath<clong>.Round(in clong x, in int digits, in MidpointRounding mode) => x;
            clong IMath<clong>.Round(in clong x, in MidpointRounding mode) => x;
            clong IMath<clong>.Sin(in clong x) => (clong)Math.Sin(x._value);
            clong IMath<clong>.Sinh(in clong x) => (clong)Math.Sinh(x._value);
            clong IMath<clong>.Sqrt(in clong x) => (clong)Math.Sqrt(x._value);
            clong IMath<clong>.Subtract(in clong x, in clong y) => x - y;
            clong IMath<clong>.Tan(in clong x) => (clong)Math.Tan(x._value);
            clong IMath<clong>.Tanh(in clong x) => (clong)Math.Tanh(x._value);
            clong IMath<clong>.Truncate(in clong x) => x;
            clong IMath<clong>.TurnsToDegrees(in clong x) => (clong)CheckedArithmetic.Multiply(x, AngleConstants.DegreesPerTurn);
            clong IMath<clong>.TurnsToRadians(in clong x) => (clong)CheckedArithmetic.Multiply(x, AngleConstants.DegreesPerRadian);
            double IMath<clong>.ToDouble(in clong x, in double offset) => CheckedArithmetic.Add(CheckedConvert.ToSingle(x._value), offset);
            float IMath<clong>.ToSingle(in clong x, in float offset) => CheckedArithmetic.Add(CheckedConvert.ToSingle(x._value), offset);
            int IMath<clong>.Sign(in clong x) => Math.Sign(x._value);

            clong IBitConverter<clong>.Read(in IReadOnlyStream<byte> stream) => BitConverter.ToInt64(stream.Read(sizeof(long)));
            void IBitConverter<clong>.Write(clong value, in IWriteOnlyStream<byte> stream) => stream.Write(BitConverter.GetBytes(value._value));

            clong IRandom<clong>.GetNext(Random random) => random.NextInt64();
            clong IRandom<clong>.GetNext(Random random, in clong bound1, in clong bound2) => random.NextInt64(bound1._value, bound2._value);

            clong IStringParser<clong>.Parse(in string s) => Parse(s);
            clong IStringParser<clong>.Parse(in string s, in NumberStyles numberStyles, in IFormatProvider formatProvider) => Parse(s, numberStyles, formatProvider);
        }

        IConvert<clong> IConvertible<clong>.Convert => _Convert.Instance;
        private sealed class _Convert : IConvert<clong>
        {
            public readonly static _Convert Instance = new _Convert();

            bool IConvert<clong>.ToBoolean(clong value) => CheckedConvert.ToBoolean(value._value);
            byte IConvert<clong>.ToByte(clong value) => CheckedConvert.ToByte(value._value);
            char IConvert<clong>.ToChar(clong value) => CheckedConvert.ToChar(value._value);
            decimal IConvert<clong>.ToDecimal(clong value) => CheckedConvert.ToDecimal(value._value);
            double IConvert<clong>.ToDouble(clong value) => CheckedConvert.ToDouble(value._value);
            float IConvert<clong>.ToSingle(clong value) => CheckedConvert.ToSingle(value._value);
            int IConvert<clong>.ToInt32(clong value) => CheckedConvert.ToInt32(value._value);
            long IConvert<clong>.ToInt64(clong value) => value._value;
            sbyte IConvert<clong>.ToSByte(clong value) => CheckedConvert.ToSByte(value._value);
            short IConvert<clong>.ToInt16(clong value) => CheckedConvert.ToInt16(value._value);
            string IConvert<clong>.ToString(clong value) => Convert.ToString(value._value);
            string IConvert<clong>.ToString(clong value, IFormatProvider provider) => Convert.ToString(value._value, provider);
            uint IConvert<clong>.ToUInt32(clong value) => CheckedConvert.ToUInt32(value._value);
            ulong IConvert<clong>.ToUInt64(clong value) => CheckedConvert.ToUInt64(value._value);
            ushort IConvert<clong>.ToUInt16(clong value) => CheckedConvert.ToUInt16(value._value);

            clong IConvert<clong>.ToValue(bool value) => CheckedConvert.ToInt64(value);
            clong IConvert<clong>.ToValue(byte value) => CheckedConvert.ToInt64(value);
            clong IConvert<clong>.ToValue(char value) => CheckedConvert.ToInt64(value);
            clong IConvert<clong>.ToValue(decimal value) => CheckedConvert.ToInt64(value);
            clong IConvert<clong>.ToValue(double value) => CheckedConvert.ToInt64(value);
            clong IConvert<clong>.ToValue(float value) => CheckedConvert.ToInt64(value);
            clong IConvert<clong>.ToValue(int value) => CheckedConvert.ToInt64(value);
            clong IConvert<clong>.ToValue(long value) => value;
            clong IConvert<clong>.ToValue(sbyte value) => CheckedConvert.ToInt64(value);
            clong IConvert<clong>.ToValue(short value) => CheckedConvert.ToInt64(value);
            clong IConvert<clong>.ToValue(string value) => Convert.ToInt64(value);
            clong IConvert<clong>.ToValue(string value, IFormatProvider provider) => Convert.ToInt64(value, provider);
            clong IConvert<clong>.ToValue(uint value) => CheckedConvert.ToInt64(value);
            clong IConvert<clong>.ToValue(ulong value) => CheckedConvert.ToInt64(value);
            clong IConvert<clong>.ToValue(ushort value) => CheckedConvert.ToInt64(value);
        }
    }
}
