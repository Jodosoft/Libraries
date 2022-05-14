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
    public readonly struct gshort : INumeric<gshort>
    {
        public static readonly gshort MaxValue = new gshort(short.MaxValue);
        public static readonly gshort MinValue = new gshort(short.MinValue);

        private readonly short _value;

        private gshort(short value)
        {
            _value = value;
        }

        private gshort(SerializationInfo info, StreamingContext context) : this(info.GetInt16(nameof(gshort))) { }
        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context) => info.AddValue(nameof(gshort), _value);

        public int CompareTo(gshort other) => _value.CompareTo(other._value);
        public int CompareTo(object? obj) => obj is gshort other ? CompareTo(other) : 1;
        public bool Equals(gshort other) => _value == other._value;
        public override bool Equals(object? obj) => obj is gshort other && Equals(other);
        public override int GetHashCode() => _value.GetHashCode();
        public override string ToString() => _value.ToString();
        public string ToString(IFormatProvider formatProvider) => _value.ToString(formatProvider);
        public string ToString(string format, IFormatProvider formatProvider) => _value.ToString(format, formatProvider);

        public static bool TryParse(string s, IFormatProvider provider, out gshort result) => Try.Run(() => Parse(s, provider), out result);
        public static bool TryParse(string s, NumberStyles style, IFormatProvider provider, out gshort result) => Try.Run(() => Parse(s, style, provider), out result);
        public static bool TryParse(string s, NumberStyles style, out gshort result) => Try.Run(() => Parse(s, style), out result);
        public static bool TryParse(string s, out gshort result) => Try.Run(() => Parse(s), out result);
        public static gshort Parse(string s) => short.Parse(s);
        public static gshort Parse(string s, IFormatProvider provider) => short.Parse(s, provider);
        public static gshort Parse(string s, NumberStyles style) => short.Parse(s, style);
        public static gshort Parse(string s, NumberStyles style, IFormatProvider provider) => short.Parse(s, style, provider);

        public static explicit operator gshort(char value) => new gshort((short)value);
        public static explicit operator gshort(decimal value) => new gshort((short)value);
        public static explicit operator gshort(double value) => new gshort((short)value);
        public static explicit operator gshort(float value) => new gshort((short)value);
        public static explicit operator gshort(int value) => new gshort((short)value);
        public static explicit operator gshort(long value) => new gshort((short)value);
        public static explicit operator gshort(uint value) => new gshort((short)value);
        public static explicit operator gshort(ulong value) => new gshort((short)value);
        public static explicit operator gshort(ushort value) => new gshort((short)value);
        public static implicit operator gshort(byte value) => new gshort(value);
        public static implicit operator gshort(sbyte value) => new gshort(value);
        public static implicit operator gshort(short value) => new gshort(value);

        public static explicit operator byte(gshort value) => (byte)value._value;
        public static explicit operator char(gshort value) => (char)value._value;
        public static explicit operator sbyte(gshort value) => (sbyte)value._value;
        public static explicit operator uint(gshort value) => (uint)value._value;
        public static explicit operator ulong(gshort value) => (ulong)value._value;
        public static explicit operator ushort(gshort value) => (ushort)value._value;
        public static implicit operator decimal(gshort value) => value._value;
        public static implicit operator double(gshort value) => value._value;
        public static implicit operator float(gshort value) => value._value;
        public static implicit operator int(gshort value) => value._value;
        public static implicit operator long(gshort value) => value._value;
        public static implicit operator short(gshort value) => value._value;

        public static bool operator !=(gshort left, gshort right) => left._value != right._value;
        public static bool operator <(gshort left, gshort right) => left._value < right._value;
        public static bool operator <=(gshort left, gshort right) => left._value <= right._value;
        public static bool operator ==(gshort left, gshort right) => left._value == right._value;
        public static bool operator >(gshort left, gshort right) => left._value > right._value;
        public static bool operator >=(gshort left, gshort right) => left._value >= right._value;
        public static gshort operator %(gshort left, gshort right) => (short)(left._value % right._value);
        public static gshort operator &(gshort left, gshort right) => (short)(left._value & right._value);
        public static gshort operator -(gshort left, gshort right) => (short)(left._value - right._value);
        public static gshort operator --(gshort value) => (short)(value._value - 1);
        public static gshort operator -(gshort value) => (short)-value._value;
        public static gshort operator *(gshort left, gshort right) => (short)(left._value * right._value);
        public static gshort operator /(gshort left, gshort right) => (short)(left._value / right._value);
        public static gshort operator ^(gshort left, gshort right) => (short)(left._value ^ right._value);
        public static gshort operator |(gshort left, gshort right) => (short)(left._value | right._value);
        public static gshort operator ~(gshort value) => (short)~value._value;
        public static gshort operator +(gshort left, gshort right) => (short)(left._value + right._value);
        public static gshort operator +(gshort value) => value;
        public static gshort operator ++(gshort value) => (short)(value._value + 1);
        public static gshort operator <<(gshort left, int right) => (short)(left._value << right);
        public static gshort operator >>(gshort left, int right) => (short)(left._value >> right);

        IBitConverter<gshort> IBitConvertible<gshort>.BitConverter => Utilities.Instance;
        IMath<gshort> INumeric<gshort>.Math => Utilities.Instance;
        IRandom<gshort> IRandomisable<gshort>.Random => Utilities.Instance;
        IStringParser<gshort> IStringRepresentable<gshort>.StringParser => Utilities.Instance;

        private sealed class Utilities : IMath<gshort>, IBitConverter<gshort>, IRandom<gshort>, IStringParser<gshort>
        {
            public readonly static Utilities Instance = new Utilities();

            gshort IMath<gshort>.E { get; } = (short)2;
            gshort IMath<gshort>.PI { get; } = (short)3;
            gshort IMath<gshort>.Epsilon { get; } = (short)1;
            gshort IMath<gshort>.MaxValue => MaxValue;
            gshort IMath<gshort>.MinValue => MinValue;
            gshort IMath<gshort>.MaxUnit { get; } = (short)1;
            gshort IMath<gshort>.MinUnit { get; } = (short)-1;
            gshort IMath<gshort>.Zero { get; } = (short)0;
            gshort IMath<gshort>.One { get; } = (short)1;
            bool IMath<gshort>.IsSigned { get; } = true;
            bool IMath<gshort>.IsReal { get; } = false;

            bool IMath<gshort>.IsGreaterThan(gshort x, gshort y) => x > y;
            bool IMath<gshort>.IsGreaterThanOrEqualTo(gshort x, gshort y) => x >= y;
            bool IMath<gshort>.IsLessThan(gshort x, gshort y) => x < y;
            bool IMath<gshort>.IsLessThanOrEqualTo(gshort x, gshort y) => x <= y;
            gshort IMath<gshort>.Abs(gshort x) => Math.Abs(x._value);
            gshort IMath<gshort>.Acos(gshort x) => (short)Math.Acos(x._value);
            gshort IMath<gshort>.Acosh(gshort x) => (short)Math.Acosh(x._value);
            gshort IMath<gshort>.Add(gshort x, gshort y) => x + y;
            gshort IMath<gshort>.Asin(gshort x) => (short)Math.Asin(x._value);
            gshort IMath<gshort>.Asinh(gshort x) => (short)Math.Asinh(x._value);
            gshort IMath<gshort>.Atan(gshort x) => (short)Math.Atan(x._value);
            gshort IMath<gshort>.Atan2(gshort x, gshort y) => (short)Math.Atan2(x._value, y._value);
            gshort IMath<gshort>.Atanh(gshort x) => (short)Math.Atanh(x._value);
            gshort IMath<gshort>.Cbrt(gshort x) => (short)Math.Cbrt(x._value);
            gshort IMath<gshort>.Ceiling(gshort x) => x;
            gshort IMath<gshort>.Clamp(gshort x, gshort bound1, gshort bound2) => bound1 > bound2 ? Math.Min(bound1._value, Math.Max(bound2._value, x._value)) : Math.Min(bound2._value, Math.Max(bound1._value, x._value));
            gshort IMath<gshort>.Cos(gshort x) => (short)Math.Cos(x._value);
            gshort IMath<gshort>.Cosh(gshort x) => (short)Math.Cosh(x._value);
            gshort IMath<gshort>.DegreesToRadians(gshort x) => (short)(x * AngleConstants.RadiansPerDegree);
            gshort IMath<gshort>.DegreesToTurns(gshort x) => (short)(x * AngleConstants.TurnsPerDegree);
            gshort IMath<gshort>.Divide(gshort x, gshort y) => x / y;
            gshort IMath<gshort>.Exp(gshort x) => (short)Math.Exp(x._value);
            gshort IMath<gshort>.Floor(gshort x) => x;
            gshort IMath<gshort>.IEEERemainder(gshort x, gshort y) => (short)Math.IEEERemainder(x._value, y._value);
            gshort IMath<gshort>.Log(gshort x) => (short)Math.Log(x._value);
            gshort IMath<gshort>.Log(gshort x, gshort y) => (short)Math.Log(x._value, y._value);
            gshort IMath<gshort>.Log10(gshort x) => (short)Math.Log10(x._value);
            gshort IMath<gshort>.Max(gshort x, gshort y) => Math.Max(x._value, y._value);
            gshort IMath<gshort>.Min(gshort x, gshort y) => Math.Min(x._value, y._value);
            gshort IMath<gshort>.Multiply(gshort x, gshort y) => x * y;
            gshort IMath<gshort>.Negative(gshort x) => -x;
            gshort IMath<gshort>.Positive(gshort x) => +x;
            gshort IMath<gshort>.Pow(gshort x, byte y) => (short)Math.Pow(x._value, y);
            gshort IMath<gshort>.Pow(gshort x, gshort y) => (short)Math.Pow(x._value, y._value);
            gshort IMath<gshort>.RadiansToDegrees(gshort x) => (short)(x * AngleConstants.DegreesPerRadian);
            gshort IMath<gshort>.RadiansToTurns(gshort x) => (short)(x * AngleConstants.TurnsPerRadian);
            gshort IMath<gshort>.Remainder(gshort x, gshort y) => x % y;
            gshort IMath<gshort>.Round(gshort x) => x;
            gshort IMath<gshort>.Round(gshort x, int digits) => x;
            gshort IMath<gshort>.Round(gshort x, int digits, MidpointRounding mode) => x;
            gshort IMath<gshort>.Round(gshort x, MidpointRounding mode) => x;
            gshort IMath<gshort>.Sin(gshort x) => (short)Math.Sin(x._value);
            gshort IMath<gshort>.Sinh(gshort x) => (short)Math.Sinh(x._value);
            gshort IMath<gshort>.Sqrt(gshort x) => (short)Math.Sqrt(x._value);
            gshort IMath<gshort>.Subtract(gshort x, gshort y) => x - y;
            gshort IMath<gshort>.Tan(gshort x) => (short)Math.Tan(x._value);
            gshort IMath<gshort>.Tanh(gshort x) => (short)Math.Tanh(x._value);
            gshort IMath<gshort>.Truncate(gshort x) => x;
            gshort IMath<gshort>.TurnsToDegrees(gshort x) => (short)(x * AngleConstants.DegreesPerTurn);
            gshort IMath<gshort>.TurnsToRadians(gshort x) => (short)(x * AngleConstants.DegreesPerRadian);
            double IMath<gshort>.ToDouble(gshort x, double offset) => x._value + offset;
            float IMath<gshort>.ToSingle(gshort x, float offset) => x._value + offset;
            int IMath<gshort>.Sign(gshort x) => Math.Sign(x._value);

            gshort IBitConverter<gshort>.Read(IReadOnlyStream<byte> stream) => BitConverter.ToInt16(stream.Read(sizeof(int)));
            void IBitConverter<gshort>.Write(gshort value, IWriteOnlyStream<byte> stream) => stream.Write(BitConverter.GetBytes(value._value));

            gshort IRandom<gshort>.GetNext(Random random) => random.NextInt16();
            gshort IRandom<gshort>.GetNext(Random random, gshort bound1, gshort bound2) => random.NextInt16(bound1._value, bound2._value);

            gshort IStringParser<gshort>.Parse(string s) => Parse(s);
            gshort IStringParser<gshort>.Parse(string s, NumberStyles numberStyles, IFormatProvider formatProvider) => Parse(s, numberStyles, formatProvider);
        }

        IConvert<gshort> IConvertible<gshort>.Convert => _Convert.Instance;
        private sealed class _Convert : IConvert<gshort>
        {
            public readonly static _Convert Instance = new _Convert();

            bool IConvert<gshort>.ToBoolean(gshort value) => Convert.ToBoolean(value._value);
            byte IConvert<gshort>.ToByte(gshort value) => Convert.ToByte(value._value);
            char IConvert<gshort>.ToChar(gshort value) => Convert.ToChar(value._value);
            decimal IConvert<gshort>.ToDecimal(gshort value) => Convert.ToDecimal(value._value);
            double IConvert<gshort>.ToDouble(gshort value) => Convert.ToDouble(value._value);
            float IConvert<gshort>.ToSingle(gshort value) => Convert.ToSingle(value._value);
            int IConvert<gshort>.ToInt32(gshort value) => Convert.ToInt32(value._value);
            long IConvert<gshort>.ToInt64(gshort value) => Convert.ToInt64(value._value);
            sbyte IConvert<gshort>.ToSByte(gshort value) => Convert.ToSByte(value._value);
            short IConvert<gshort>.ToInt16(gshort value) => Convert.ToInt16(value._value);
            string IConvert<gshort>.ToString(gshort value) => Convert.ToString(value._value);
            string IConvert<gshort>.ToString(gshort value, IFormatProvider provider) => Convert.ToString(value._value, provider);
            uint IConvert<gshort>.ToUInt32(gshort value) => Convert.ToUInt32(value._value);
            ulong IConvert<gshort>.ToUInt64(gshort value) => Convert.ToUInt64(value._value);
            ushort IConvert<gshort>.ToUInt16(gshort value) => Convert.ToUInt16(value._value);

            gshort IConvert<gshort>.ToValue(bool value) => Convert.ToInt16(value);
            gshort IConvert<gshort>.ToValue(byte value) => Convert.ToInt16(value);
            gshort IConvert<gshort>.ToValue(char value) => Convert.ToInt16(value);
            gshort IConvert<gshort>.ToValue(decimal value) => Convert.ToInt16(value);
            gshort IConvert<gshort>.ToValue(double value) => Convert.ToInt16(value);
            gshort IConvert<gshort>.ToValue(float value) => Convert.ToInt16(value);
            gshort IConvert<gshort>.ToValue(int value) => Convert.ToInt16(value);
            gshort IConvert<gshort>.ToValue(long value) => Convert.ToInt16(value);
            gshort IConvert<gshort>.ToValue(sbyte value) => Convert.ToInt16(value);
            gshort IConvert<gshort>.ToValue(short value) => Convert.ToInt16(value);
            gshort IConvert<gshort>.ToValue(string value) => Convert.ToInt16(value);
            gshort IConvert<gshort>.ToValue(string value, IFormatProvider provider) => Convert.ToInt16(value, provider);
            gshort IConvert<gshort>.ToValue(uint value) => Convert.ToInt16(value);
            gshort IConvert<gshort>.ToValue(ulong value) => Convert.ToInt16(value);
            gshort IConvert<gshort>.ToValue(ushort value) => Convert.ToInt16(value);
        }
    }
}
