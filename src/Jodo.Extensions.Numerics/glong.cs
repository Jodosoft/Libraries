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

using Jodo.Extensions.Primitives;
using System;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Runtime.Serialization;

namespace Jodo.Extensions.Numerics
{
    [Serializable]
    [DebuggerDisplay("{ToString(),nq}")]
    [SuppressMessage("Style", "IDE1006:Naming Styles")]
    [SuppressMessage("CodeQuality", "IDE0079:Remove unnecessary suppression")]
    [SuppressMessage("csharpsquid", "S101")]
    public readonly struct glong : INumeric<glong>
    {
        public static readonly glong MaxValue = new glong(long.MaxValue);
        public static readonly glong MinValue = new glong(long.MinValue);

        private readonly long _value;

        private glong(long value)
        {
            _value = value;
        }

        private glong(SerializationInfo info, StreamingContext context) : this(info.GetInt64(nameof(glong))) { }
        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context) => info.AddValue(nameof(glong), _value);

        public int CompareTo(glong other) => _value.CompareTo(other._value);
        public int CompareTo(object? obj) => obj is glong other ? CompareTo(other) : 1;
        public bool Equals(glong other) => _value == other._value;
        public override bool Equals(object? obj) => obj is glong other && Equals(other);
        public override int GetHashCode() => _value.GetHashCode();
        public override string ToString() => _value.ToString();
        public string ToString(IFormatProvider formatProvider) => _value.ToString(formatProvider);
        public string ToString(string format, IFormatProvider formatProvider) => _value.ToString(format, formatProvider);

        public static bool TryParse(string s, IFormatProvider provider, out glong result) => Try.Run(() => Parse(s, provider), out result);
        public static bool TryParse(string s, NumberStyles style, IFormatProvider provider, out glong result) => Try.Run(() => Parse(s, style, provider), out result);
        public static bool TryParse(string s, NumberStyles style, out glong result) => Try.Run(() => Parse(s, style), out result);
        public static bool TryParse(string s, out glong result) => Try.Run(() => Parse(s), out result);
        public static glong Parse(string s) => long.Parse(s);
        public static glong Parse(string s, IFormatProvider provider) => long.Parse(s, provider);
        public static glong Parse(string s, NumberStyles style) => long.Parse(s, style);
        public static glong Parse(string s, NumberStyles style, IFormatProvider provider) => long.Parse(s, style, provider);

        public static explicit operator glong(decimal value) => new glong((long)value);
        public static explicit operator glong(double value) => new glong((long)value);
        public static explicit operator glong(float value) => new glong((long)value);
        public static explicit operator glong(ulong value) => new glong((long)value);
        public static implicit operator glong(byte value) => new glong(value);
        public static implicit operator glong(char value) => new glong(value);
        public static implicit operator glong(int value) => new glong(value);
        public static implicit operator glong(long value) => new glong(value);
        public static implicit operator glong(sbyte value) => new glong(value);
        public static implicit operator glong(short value) => new glong(value);
        public static implicit operator glong(uint value) => new glong(value);
        public static implicit operator glong(ushort value) => new glong(value);

        public static explicit operator byte(glong value) => (byte)value._value;
        public static explicit operator char(glong value) => (char)value._value;
        public static explicit operator int(glong value) => (int)value._value;
        public static explicit operator sbyte(glong value) => (sbyte)value._value;
        public static explicit operator short(glong value) => (short)value._value;
        public static explicit operator uint(glong value) => (uint)value._value;
        public static explicit operator ulong(glong value) => (ulong)value._value;
        public static explicit operator ushort(glong value) => (ushort)value._value;
        public static implicit operator decimal(glong value) => value._value;
        public static implicit operator double(glong value) => value._value;
        public static implicit operator float(glong value) => value._value;
        public static implicit operator long(glong value) => value._value;

        public static bool operator !=(glong left, glong right) => left._value != right._value;
        public static bool operator <(glong left, glong right) => left._value < right._value;
        public static bool operator <=(glong left, glong right) => left._value <= right._value;
        public static bool operator ==(glong left, glong right) => left._value == right._value;
        public static bool operator >(glong left, glong right) => left._value > right._value;
        public static bool operator >=(glong left, glong right) => left._value >= right._value;
        public static glong operator %(glong left, glong right) => left._value % right._value;
        public static glong operator &(glong left, glong right) => left._value & right._value;
        public static glong operator -(glong left, glong right) => left._value - right._value;
        public static glong operator --(glong value) => value._value - 1;
        public static glong operator -(glong value) => -value._value;
        public static glong operator *(glong left, glong right) => left._value * right._value;
        public static glong operator /(glong left, glong right) => left._value / right._value;
        public static glong operator ^(glong left, glong right) => left._value ^ right._value;
        public static glong operator |(glong left, glong right) => left._value | right._value;
        public static glong operator ~(glong value) => ~value._value;
        public static glong operator +(glong left, glong right) => left._value + right._value;
        public static glong operator +(glong value) => value;
        public static glong operator ++(glong value) => value._value + 1;
        public static glong operator <<(glong left, int right) => left._value << right;
        public static glong operator >>(glong left, int right) => left._value >> right;

        IBitConverter<glong> IBitConvertible<glong>.BitConverter => Utilities.Instance;
        IMath<glong> INumeric<glong>.Math => Utilities.Instance;
        IRandom<glong> IRandomisable<glong>.Random => Utilities.Instance;
        IStringParser<glong> IStringRepresentable<glong>.StringParser => Utilities.Instance;

        private sealed class Utilities : IMath<glong>, IBitConverter<glong>, IRandom<glong>, IStringParser<glong>
        {
            public readonly static Utilities Instance = new Utilities();

            glong IMath<glong>.E { get; } = (long)2;
            glong IMath<glong>.PI { get; } = (long)3;
            glong IMath<glong>.Epsilon { get; } = (long)1;
            glong IMath<glong>.MaxValue => MaxValue;
            glong IMath<glong>.MinValue => MinValue;
            glong IMath<glong>.MaxUnit { get; } = (long)1;
            glong IMath<glong>.MinUnit { get; } = (long)-1;
            glong IMath<glong>.Zero { get; } = (long)0;
            glong IMath<glong>.One { get; } = (long)1;
            bool IMath<glong>.IsSigned { get; } = true;
            bool IMath<glong>.IsReal { get; } = false;

            bool IMath<glong>.IsGreaterThan(glong x, glong y) => x > y;
            bool IMath<glong>.IsGreaterThanOrEqualTo(glong x, glong y) => x >= y;
            bool IMath<glong>.IsLessThan(glong x, glong y) => x < y;
            bool IMath<glong>.IsLessThanOrEqualTo(glong x, glong y) => x <= y;
            glong IMath<glong>.Abs(glong x) => Math.Abs(x._value);
            glong IMath<glong>.Acos(glong x) => (long)Math.Acos(x._value);
            glong IMath<glong>.Acosh(glong x) => (long)Math.Acosh(x._value);
            glong IMath<glong>.Add(glong x, glong y) => x + y;
            glong IMath<glong>.Asin(glong x) => (long)Math.Asin(x._value);
            glong IMath<glong>.Asinh(glong x) => (long)Math.Asinh(x._value);
            glong IMath<glong>.Atan(glong x) => (long)Math.Atan(x._value);
            glong IMath<glong>.Atan2(glong x, glong y) => (long)Math.Atan2(x._value, y._value);
            glong IMath<glong>.Atanh(glong x) => (long)Math.Atanh(x._value);
            glong IMath<glong>.Cbrt(glong x) => (long)Math.Cbrt(x._value);
            glong IMath<glong>.Ceiling(glong x) => x;
            glong IMath<glong>.Clamp(glong x, glong bound1, glong bound2) => bound1 > bound2 ? Math.Min(bound1._value, Math.Max(bound2._value, x._value)) : Math.Min(bound2._value, Math.Max(bound1._value, x._value));
            glong IMath<glong>.Cos(glong x) => (long)Math.Cos(x._value);
            glong IMath<glong>.Cosh(glong x) => (long)Math.Cosh(x._value);
            glong IMath<glong>.DegreesToRadians(glong x) => (long)(x * Trig.RadiansPerDegree);
            glong IMath<glong>.DegreesToTurns(glong x) => (long)(x * Trig.TurnsPerDegree);
            glong IMath<glong>.Divide(glong x, glong y) => x / y;
            glong IMath<glong>.Exp(glong x) => (long)Math.Exp(x._value);
            glong IMath<glong>.Floor(glong x) => x;
            glong IMath<glong>.IEEERemainder(glong x, glong y) => (long)Math.IEEERemainder(x._value, y._value);
            glong IMath<glong>.Log(glong x) => (long)Math.Log(x._value);
            glong IMath<glong>.Log(glong x, glong y) => (long)Math.Log(x._value, y._value);
            glong IMath<glong>.Log10(glong x) => (long)Math.Log10(x._value);
            glong IMath<glong>.Max(glong x, glong y) => Math.Max(x._value, y._value);
            glong IMath<glong>.Min(glong x, glong y) => Math.Min(x._value, y._value);
            glong IMath<glong>.Multiply(glong x, glong y) => x * y;
            glong IMath<glong>.Negative(glong x) => -x;
            glong IMath<glong>.Positive(glong x) => +x;
            glong IMath<glong>.Pow(glong x, byte y) => (long)Math.Pow(x._value, y);
            glong IMath<glong>.Pow(glong x, glong y) => (long)Math.Pow(x._value, y._value);
            glong IMath<glong>.RadiansToDegrees(glong x) => (long)(x * Trig.DegreesPerRadian);
            glong IMath<glong>.RadiansToTurns(glong x) => (long)(x * Trig.TurnsPerRadian);
            glong IMath<glong>.Remainder(glong x, glong y) => x % y;
            glong IMath<glong>.Round(glong x) => x;
            glong IMath<glong>.Round(glong x, int digits) => x;
            glong IMath<glong>.Round(glong x, int digits, MidpointRounding mode) => x;
            glong IMath<glong>.Round(glong x, MidpointRounding mode) => x;
            glong IMath<glong>.Sin(glong x) => (long)Math.Sin(x._value);
            glong IMath<glong>.Sinh(glong x) => (long)Math.Sinh(x._value);
            glong IMath<glong>.Sqrt(glong x) => (long)Math.Sqrt(x._value);
            glong IMath<glong>.Subtract(glong x, glong y) => x - y;
            glong IMath<glong>.Tan(glong x) => (long)Math.Tan(x._value);
            glong IMath<glong>.Tanh(glong x) => (long)Math.Tanh(x._value);
            glong IMath<glong>.Truncate(glong x) => x;
            glong IMath<glong>.TurnsToDegrees(glong x) => (long)(x * Trig.DegreesPerTurn);
            glong IMath<glong>.TurnsToRadians(glong x) => (long)(x * Trig.DegreesPerRadian);
            double IMath<glong>.ToDouble(glong x, double offset) => x._value + offset;
            float IMath<glong>.ToSingle(glong x, float offset) => x._value + offset;
            int IMath<glong>.Sign(glong x) => Math.Sign(x._value);

            glong IBitConverter<glong>.Read(IReadOnlyStream<byte> stream) => BitConverter.ToInt64(stream.Read(sizeof(int)));
            void IBitConverter<glong>.Write(glong value, IWriteOnlyStream<byte> stream) => stream.Write(BitConverter.GetBytes(value._value));

            glong IRandom<glong>.GetNext(Random random) => random.NextInt64();
            glong IRandom<glong>.GetNext(Random random, glong bound1, glong bound2) => random.NextInt64(bound1._value, bound2._value);

            glong IStringParser<glong>.Parse(string s) => Parse(s);
            glong IStringParser<glong>.Parse(string s, NumberStyles numberStyles, IFormatProvider formatProvider) => Parse(s, numberStyles, formatProvider);
        }

        IConvert<glong> IConvertible<glong>.Convert => _Convert.Instance;
        private sealed class _Convert : IConvert<glong>
        {
            public readonly static _Convert Instance = new _Convert();

            bool IConvert<glong>.ToBoolean(glong value) => Convert.ToBoolean(value._value);
            byte IConvert<glong>.ToByte(glong value) => Convert.ToByte(value._value);
            char IConvert<glong>.ToChar(glong value) => Convert.ToChar(value._value);
            decimal IConvert<glong>.ToDecimal(glong value) => Convert.ToDecimal(value._value);
            double IConvert<glong>.ToDouble(glong value) => Convert.ToDouble(value._value);
            float IConvert<glong>.ToSingle(glong value) => Convert.ToSingle(value._value);
            int IConvert<glong>.ToInt32(glong value) => Convert.ToInt32(value._value);
            long IConvert<glong>.ToInt64(glong value) => Convert.ToInt64(value._value);
            sbyte IConvert<glong>.ToSByte(glong value) => Convert.ToSByte(value._value);
            short IConvert<glong>.ToInt16(glong value) => Convert.ToInt16(value._value);
            string IConvert<glong>.ToString(glong value) => Convert.ToString(value._value);
            string IConvert<glong>.ToString(glong value, IFormatProvider provider) => Convert.ToString(value._value, provider);
            uint IConvert<glong>.ToUInt32(glong value) => Convert.ToUInt32(value._value);
            ulong IConvert<glong>.ToUInt64(glong value) => Convert.ToUInt64(value._value);
            ushort IConvert<glong>.ToUInt16(glong value) => Convert.ToUInt16(value._value);

            glong IConvert<glong>.ToValue(bool value) => Convert.ToInt64(value);
            glong IConvert<glong>.ToValue(byte value) => Convert.ToInt64(value);
            glong IConvert<glong>.ToValue(char value) => Convert.ToInt64(value);
            glong IConvert<glong>.ToValue(decimal value) => Convert.ToInt64(value);
            glong IConvert<glong>.ToValue(double value) => Convert.ToInt64(value);
            glong IConvert<glong>.ToValue(float value) => Convert.ToInt64(value);
            glong IConvert<glong>.ToValue(int value) => Convert.ToInt64(value);
            glong IConvert<glong>.ToValue(long value) => Convert.ToInt64(value);
            glong IConvert<glong>.ToValue(sbyte value) => Convert.ToInt64(value);
            glong IConvert<glong>.ToValue(short value) => Convert.ToInt64(value);
            glong IConvert<glong>.ToValue(string value) => Convert.ToInt64(value);
            glong IConvert<glong>.ToValue(string value, IFormatProvider provider) => Convert.ToInt64(value, provider);
            glong IConvert<glong>.ToValue(uint value) => Convert.ToInt64(value);
            glong IConvert<glong>.ToValue(ulong value) => Convert.ToInt64(value);
            glong IConvert<glong>.ToValue(ushort value) => Convert.ToInt64(value);
        }
    }
}
