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

        public static explicit operator clong(decimal value) => new clong(CheckedTruncate.ToInt64(value));
        public static explicit operator clong(double value) => new clong(CheckedTruncate.ToInt64(value));
        public static explicit operator clong(float value) => new clong(CheckedTruncate.ToInt64(value));
        public static explicit operator clong(ulong value) => new clong(CheckedConvert.ToInt64(value));
        public static implicit operator clong(byte value) => new clong(value);
        public static implicit operator clong(char value) => new clong(value);
        public static implicit operator clong(int value) => new clong(value);
        public static implicit operator clong(long value) => new clong(value);
        public static implicit operator clong(sbyte value) => new clong(value);
        public static implicit operator clong(short value) => new clong(value);
        public static implicit operator clong(uint value) => new clong(value);
        public static implicit operator clong(ushort value) => new clong(value);

        public static explicit operator byte(clong value) => CheckedConvert.ToByte(value._value);
        public static explicit operator char(clong value) => CheckedConvert.ToChar(value._value);
        public static explicit operator int(clong value) => CheckedConvert.ToInt32(value._value);
        public static explicit operator sbyte(clong value) => CheckedConvert.ToSByte(value._value);
        public static explicit operator short(clong value) => CheckedConvert.ToInt16(value._value);
        public static explicit operator uint(clong value) => CheckedConvert.ToUInt32(value._value);
        public static explicit operator ulong(clong value) => CheckedConvert.ToUInt64(value._value);
        public static explicit operator ushort(clong value) => CheckedConvert.ToUInt16(value._value);
        public static implicit operator decimal(clong value) => value._value;
        public static implicit operator double(clong value) => value._value;
        public static implicit operator float(clong value) => value._value;
        public static implicit operator long(clong value) => value._value;

        public static bool operator !=(clong left, clong right) => left._value != right._value;
        public static bool operator <(clong left, clong right) => left._value < right._value;
        public static bool operator <=(clong left, clong right) => left._value <= right._value;
        public static bool operator ==(clong left, clong right) => left._value == right._value;
        public static bool operator >(clong left, clong right) => left._value > right._value;
        public static bool operator >=(clong left, clong right) => left._value >= right._value;
        public static clong operator %(clong left, clong right) => CheckedArithmetic.Remainder(left._value, right._value);
        public static clong operator &(clong left, clong right) => left._value & right._value;
        public static clong operator -(clong left, clong right) => CheckedArithmetic.Subtract(left._value, right._value);
        public static clong operator --(clong value) => CheckedArithmetic.Subtract(value._value, 1);
        public static clong operator -(clong value) => -value._value;
        public static clong operator *(clong left, clong right) => CheckedArithmetic.Multiply(left._value, right._value);
        public static clong operator /(clong left, clong right) => CheckedArithmetic.Divide(left._value, right._value);
        public static clong operator ^(clong left, clong right) => left._value ^ right._value;
        public static clong operator |(clong left, clong right) => left._value | right._value;
        public static clong operator ~(clong value) => ~value._value;
        public static clong operator +(clong left, clong right) => CheckedArithmetic.Add(left._value, right._value);
        public static clong operator +(clong value) => value;
        public static clong operator ++(clong value) => CheckedArithmetic.Add(value._value, 1);
        public static clong operator <<(clong left, int right) => left._value << right;
        public static clong operator >>(clong left, int right) => left._value >> right;

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

            bool IMath<clong>.IsGreaterThan(clong x, clong y) => x > y;
            bool IMath<clong>.IsGreaterThanOrEqualTo(clong x, clong y) => x >= y;
            bool IMath<clong>.IsLessThan(clong x, clong y) => x < y;
            bool IMath<clong>.IsLessThanOrEqualTo(clong x, clong y) => x <= y;
            clong IMath<clong>.Abs(clong x) => Math.Abs(x._value);
            clong IMath<clong>.Acos(clong x) => (clong)Math.Acos(x._value);
            clong IMath<clong>.Acosh(clong x) => (clong)Math.Acosh(x._value);
            clong IMath<clong>.Add(clong x, clong y) => x + y;
            clong IMath<clong>.Asin(clong x) => (clong)Math.Asin(x._value);
            clong IMath<clong>.Asinh(clong x) => (clong)Math.Asinh(x._value);
            clong IMath<clong>.Atan(clong x) => (clong)Math.Atan(x._value);
            clong IMath<clong>.Atan2(clong x, clong y) => (clong)Math.Atan2(x._value, y._value);
            clong IMath<clong>.Atanh(clong x) => (clong)Math.Atanh(x._value);
            clong IMath<clong>.Cbrt(clong x) => (clong)Math.Cbrt(x._value);
            clong IMath<clong>.Ceiling(clong x) => x;
            clong IMath<clong>.Clamp(clong x, clong bound1, clong bound2) => bound1 > bound2 ? Math.Min(bound1._value, Math.Max(bound2._value, x._value)) : Math.Min(bound2._value, Math.Max(bound1._value, x._value));
            clong IMath<clong>.Cos(clong x) => (clong)Math.Cos(x._value);
            clong IMath<clong>.Cosh(clong x) => (clong)Math.Cosh(x._value);
            clong IMath<clong>.DegreesToRadians(clong x) => (clong)CheckedArithmetic.Multiply(x, AngleConstants.RadiansPerDegree);
            clong IMath<clong>.DegreesToTurns(clong x) => (clong)CheckedArithmetic.Multiply(x, AngleConstants.TurnsPerDegree);
            clong IMath<clong>.Divide(clong x, clong y) => x / y;
            clong IMath<clong>.Exp(clong x) => (clong)Math.Exp(x._value);
            clong IMath<clong>.Floor(clong x) => x;
            clong IMath<clong>.IEEERemainder(clong x, clong y) => (clong)Math.IEEERemainder(x._value, y._value);
            clong IMath<clong>.Log(clong x) => (clong)Math.Log(x._value);
            clong IMath<clong>.Log(clong x, clong y) => (clong)Math.Log(x._value, y._value);
            clong IMath<clong>.Log10(clong x) => (clong)Math.Log10(x._value);
            clong IMath<clong>.Max(clong x, clong y) => Math.Max(x._value, y._value);
            clong IMath<clong>.Min(clong x, clong y) => Math.Min(x._value, y._value);
            clong IMath<clong>.Multiply(clong x, clong y) => x * y;
            clong IMath<clong>.Negative(clong x) => -x;
            clong IMath<clong>.Positive(clong x) => +x;
            clong IMath<clong>.Pow(clong x, byte y) => CheckedArithmetic.Pow(x._value, y);
            clong IMath<clong>.Pow(clong x, clong y) => CheckedArithmetic.Pow(x._value, y._value);
            clong IMath<clong>.RadiansToDegrees(clong x) => (clong)CheckedArithmetic.Multiply(x, AngleConstants.DegreesPerRadian);
            clong IMath<clong>.RadiansToTurns(clong x) => (clong)CheckedArithmetic.Multiply(x, AngleConstants.TurnsPerRadian);
            clong IMath<clong>.Remainder(clong x, clong y) => x % y;
            clong IMath<clong>.Round(clong x) => x;
            clong IMath<clong>.Round(clong x, int digits) => x;
            clong IMath<clong>.Round(clong x, int digits, MidpointRounding mode) => x;
            clong IMath<clong>.Round(clong x, MidpointRounding mode) => x;
            clong IMath<clong>.Sin(clong x) => (clong)Math.Sin(x._value);
            clong IMath<clong>.Sinh(clong x) => (clong)Math.Sinh(x._value);
            clong IMath<clong>.Sqrt(clong x) => (clong)Math.Sqrt(x._value);
            clong IMath<clong>.Subtract(clong x, clong y) => x - y;
            clong IMath<clong>.Tan(clong x) => (clong)Math.Tan(x._value);
            clong IMath<clong>.Tanh(clong x) => (clong)Math.Tanh(x._value);
            clong IMath<clong>.Truncate(clong x) => x;
            clong IMath<clong>.TurnsToDegrees(clong x) => (clong)CheckedArithmetic.Multiply(x, AngleConstants.DegreesPerTurn);
            clong IMath<clong>.TurnsToRadians(clong x) => (clong)CheckedArithmetic.Multiply(x, AngleConstants.DegreesPerRadian);
            double IMath<clong>.ToDouble(clong x, double offset) => CheckedArithmetic.Add(CheckedConvert.ToSingle(x._value), offset);
            float IMath<clong>.ToSingle(clong x, float offset) => CheckedArithmetic.Add(CheckedConvert.ToSingle(x._value), offset);
            int IMath<clong>.Sign(clong x) => Math.Sign(x._value);

            clong IBitConverter<clong>.Read(IReadOnlyStream<byte> stream) => BitConverter.ToInt64(stream.Read(sizeof(long)));
            void IBitConverter<clong>.Write(clong value, IWriteOnlyStream<byte> stream) => stream.Write(BitConverter.GetBytes(value._value));

            clong IRandom<clong>.GetNext(Random random) => random.NextInt64();
            clong IRandom<clong>.GetNext(Random random, clong bound1, clong bound2) => random.NextInt64(bound1._value, bound2._value);

            clong IStringParser<clong>.Parse(string s) => Parse(s);
            clong IStringParser<clong>.Parse(string s, NumberStyles numberStyles, IFormatProvider formatProvider) => Parse(s, numberStyles, formatProvider);
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
