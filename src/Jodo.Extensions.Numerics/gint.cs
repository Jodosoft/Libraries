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
    public readonly struct gint : INumeric<gint>
    {
        public static readonly gint MaxValue = new gint(int.MaxValue);
        public static readonly gint MinValue = new gint(int.MinValue);

        private readonly int _value;

        private gint(int value)
        {
            _value = value;
        }

        private gint(SerializationInfo info, StreamingContext context) : this(info.GetInt32(nameof(gint))) { }
        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context) => info.AddValue(nameof(gint), _value);

        public int CompareTo(gint other) => _value.CompareTo(other._value);
        public int CompareTo(object? obj) => obj is gint other ? CompareTo(other) : 1;
        public bool Equals(gint other) => _value == other._value;
        public override bool Equals(object? obj) => obj is gint other && Equals(other);
        public override int GetHashCode() => _value.GetHashCode();
        public override string ToString() => _value.ToString();
        public string ToString(IFormatProvider formatProvider) => _value.ToString(formatProvider);
        public string ToString(string format, IFormatProvider formatProvider) => _value.ToString(format, formatProvider);

        public static bool TryParse(string s, IFormatProvider provider, out gint result) => Try.Run(() => Parse(s, provider), out result);
        public static bool TryParse(string s, NumberStyles style, IFormatProvider provider, out gint result) => Try.Run(() => Parse(s, style, provider), out result);
        public static bool TryParse(string s, NumberStyles style, out gint result) => Try.Run(() => Parse(s, style), out result);
        public static bool TryParse(string s, out gint result) => Try.Run(() => Parse(s), out result);
        public static gint Parse(string s) => int.Parse(s);
        public static gint Parse(string s, IFormatProvider provider) => int.Parse(s, provider);
        public static gint Parse(string s, NumberStyles style) => int.Parse(s, style);
        public static gint Parse(string s, NumberStyles style, IFormatProvider provider) => int.Parse(s, style, provider);

        public static explicit operator gint(decimal value) => new gint((int)value);
        public static explicit operator gint(double value) => new gint((int)value);
        public static explicit operator gint(float value) => new gint((int)value);
        public static explicit operator gint(long value) => new gint((int)value);
        public static explicit operator gint(uint value) => new gint((int)value);
        public static explicit operator gint(ulong value) => new gint((int)value);
        public static implicit operator gint(byte value) => new gint(value);
        public static implicit operator gint(char value) => new gint(value);
        public static implicit operator gint(int value) => new gint(value);
        public static implicit operator gint(sbyte value) => new gint(value);
        public static implicit operator gint(short value) => new gint(value);
        public static implicit operator gint(ushort value) => new gint(value);

        public static explicit operator byte(gint value) => (byte)value._value;
        public static explicit operator char(gint value) => (char)value._value;
        public static explicit operator sbyte(gint value) => (sbyte)value._value;
        public static explicit operator short(gint value) => (short)value._value;
        public static explicit operator uint(gint value) => (uint)value._value;
        public static explicit operator ulong(gint value) => (ulong)value._value;
        public static explicit operator ushort(gint value) => (ushort)value._value;
        public static implicit operator decimal(gint value) => value._value;
        public static implicit operator double(gint value) => value._value;
        public static implicit operator float(gint value) => value._value;
        public static implicit operator int(gint value) => value._value;
        public static implicit operator long(gint value) => value._value;

        public static bool operator !=(gint left, gint right) => left._value != right._value;
        public static bool operator <(gint left, gint right) => left._value < right._value;
        public static bool operator <=(gint left, gint right) => left._value <= right._value;
        public static bool operator ==(gint left, gint right) => left._value == right._value;
        public static bool operator >(gint left, gint right) => left._value > right._value;
        public static bool operator >=(gint left, gint right) => left._value >= right._value;
        public static gint operator %(gint left, gint right) => left._value % right._value;
        public static gint operator &(gint left, gint right) => left._value & right._value;
        public static gint operator -(gint left, gint right) => left._value - right._value;
        public static gint operator --(gint value) => value._value - 1;
        public static gint operator -(gint value) => -value._value;
        public static gint operator *(gint left, gint right) => left._value * right._value;
        public static gint operator /(gint left, gint right) => left._value / right._value;
        public static gint operator ^(gint left, gint right) => left._value ^ right._value;
        public static gint operator |(gint left, gint right) => left._value | right._value;
        public static gint operator ~(gint value) => ~value._value;
        public static gint operator +(gint left, gint right) => left._value + right._value;
        public static gint operator +(gint value) => value;
        public static gint operator ++(gint value) => value._value + 1;
        public static gint operator <<(gint left, int right) => left._value << right;
        public static gint operator >>(gint left, int right) => left._value >> right;

        IBitConverter<gint> IBitConvertible<gint>.BitConverter => Utilities.Instance;
        IMath<gint> INumeric<gint>.Math => Utilities.Instance;
        IRandom<gint> IRandomisable<gint>.Random => Utilities.Instance;
        IStringParser<gint> IStringRepresentable<gint>.StringParser => Utilities.Instance;

        private sealed class Utilities : IMath<gint>, IBitConverter<gint>, IRandom<gint>, IStringParser<gint>
        {
            public readonly static Utilities Instance = new Utilities();

            gint IMath<gint>.E { get; } = 2;
            gint IMath<gint>.PI { get; } = 3;
            gint IMath<gint>.Epsilon { get; } = 1;
            gint IMath<gint>.MaxValue => MaxValue;
            gint IMath<gint>.MinValue => MinValue;
            gint IMath<gint>.MaxUnit { get; } = 1;
            gint IMath<gint>.MinUnit { get; } = -1;
            gint IMath<gint>.Zero { get; } = 0;
            gint IMath<gint>.One { get; } = 1;
            bool IMath<gint>.IsSigned { get; } = true;
            bool IMath<gint>.IsReal { get; } = false;

            bool IMath<gint>.IsGreaterThan(gint x, gint y) => x > y;
            bool IMath<gint>.IsGreaterThanOrEqualTo(gint x, gint y) => x >= y;
            bool IMath<gint>.IsLessThan(gint x, gint y) => x < y;
            bool IMath<gint>.IsLessThanOrEqualTo(gint x, gint y) => x <= y;
            gint IMath<gint>.Abs(gint x) => Math.Abs(x._value);
            gint IMath<gint>.Acos(gint x) => (int)Math.Acos(x._value);
            gint IMath<gint>.Acosh(gint x) => (int)Math.Acosh(x._value);
            gint IMath<gint>.Add(gint x, gint y) => x + y;
            gint IMath<gint>.Asin(gint x) => (int)Math.Asin(x._value);
            gint IMath<gint>.Asinh(gint x) => (int)Math.Asinh(x._value);
            gint IMath<gint>.Atan(gint x) => (int)Math.Atan(x._value);
            gint IMath<gint>.Atan2(gint x, gint y) => (int)Math.Atan2(x._value, y._value);
            gint IMath<gint>.Atanh(gint x) => (int)Math.Atanh(x._value);
            gint IMath<gint>.Cbrt(gint x) => (int)Math.Cbrt(x._value);
            gint IMath<gint>.Ceiling(gint x) => x;
            gint IMath<gint>.Clamp(gint x, gint bound1, gint bound2) => bound1 > bound2 ? Math.Min(bound1._value, Math.Max(bound2._value, x._value)) : Math.Min(bound2._value, Math.Max(bound1._value, x._value));
            gint IMath<gint>.Cos(gint x) => (int)Math.Cos(x._value);
            gint IMath<gint>.Cosh(gint x) => (int)Math.Cosh(x._value);
            gint IMath<gint>.DegreesToRadians(gint x) => (int)(x * AngleConstants.RadiansPerDegree);
            gint IMath<gint>.DegreesToTurns(gint x) => (int)(x * AngleConstants.TurnsPerDegree);
            gint IMath<gint>.Divide(gint x, gint y) => x / y;
            gint IMath<gint>.Exp(gint x) => (int)Math.Exp(x._value);
            gint IMath<gint>.Floor(gint x) => x;
            gint IMath<gint>.IEEERemainder(gint x, gint y) => (int)Math.IEEERemainder(x._value, y._value);
            gint IMath<gint>.Log(gint x) => (int)Math.Log(x._value);
            gint IMath<gint>.Log(gint x, gint y) => (int)Math.Log(x._value, y._value);
            gint IMath<gint>.Log10(gint x) => (int)Math.Log10(x._value);
            gint IMath<gint>.Max(gint x, gint y) => Math.Max(x._value, y._value);
            gint IMath<gint>.Min(gint x, gint y) => Math.Min(x._value, y._value);
            gint IMath<gint>.Multiply(gint x, gint y) => x * y;
            gint IMath<gint>.Negative(gint x) => -x;
            gint IMath<gint>.Positive(gint x) => +x;
            gint IMath<gint>.Pow(gint x, byte y) => (int)Math.Pow(x._value, y);
            gint IMath<gint>.Pow(gint x, gint y) => (int)Math.Pow(x._value, y._value);
            gint IMath<gint>.RadiansToDegrees(gint x) => (int)(x * AngleConstants.DegreesPerRadian);
            gint IMath<gint>.RadiansToTurns(gint x) => (int)(x * AngleConstants.TurnsPerRadian);
            gint IMath<gint>.Remainder(gint x, gint y) => x % y;
            gint IMath<gint>.Round(gint x) => x;
            gint IMath<gint>.Round(gint x, int digits) => x;
            gint IMath<gint>.Round(gint x, int digits, MidpointRounding mode) => x;
            gint IMath<gint>.Round(gint x, MidpointRounding mode) => x;
            gint IMath<gint>.Sin(gint x) => (int)Math.Sin(x._value);
            gint IMath<gint>.Sinh(gint x) => (int)Math.Sinh(x._value);
            gint IMath<gint>.Sqrt(gint x) => (int)Math.Sqrt(x._value);
            gint IMath<gint>.Subtract(gint x, gint y) => x - y;
            gint IMath<gint>.Tan(gint x) => (int)Math.Tan(x._value);
            gint IMath<gint>.Tanh(gint x) => (int)Math.Tanh(x._value);
            gint IMath<gint>.Truncate(gint x) => x;
            gint IMath<gint>.TurnsToDegrees(gint x) => (int)(x * AngleConstants.DegreesPerTurn);
            gint IMath<gint>.TurnsToRadians(gint x) => (int)(x * AngleConstants.DegreesPerRadian);
            double IMath<gint>.ToDouble(gint x, double offset) => x._value + offset;
            float IMath<gint>.ToSingle(gint x, float offset) => x._value + offset;
            int IMath<gint>.Sign(gint x) => Math.Sign(x._value);

            gint IBitConverter<gint>.Read(IReadOnlyStream<byte> stream) => BitConverter.ToInt32(stream.Read(sizeof(int)));
            void IBitConverter<gint>.Write(gint value, IWriteOnlyStream<byte> stream) => stream.Write(BitConverter.GetBytes(value._value));

            gint IRandom<gint>.GetNext(Random random) => random.NextInt32();
            gint IRandom<gint>.GetNext(Random random, gint bound1, gint bound2) => random.NextInt32(bound1._value, bound2._value);

            gint IStringParser<gint>.Parse(string s) => Parse(s);
            gint IStringParser<gint>.Parse(string s, NumberStyles numberStyles, IFormatProvider formatProvider) => Parse(s, numberStyles, formatProvider);
        }

        IConvert<gint> IConvertible<gint>.Convert => _Convert.Instance;
        private sealed class _Convert : IConvert<gint>
        {
            public readonly static _Convert Instance = new _Convert();

            bool IConvert<gint>.ToBoolean(gint value) => Convert.ToBoolean(value._value);
            byte IConvert<gint>.ToByte(gint value) => Convert.ToByte(value._value);
            char IConvert<gint>.ToChar(gint value) => Convert.ToChar(value._value);
            decimal IConvert<gint>.ToDecimal(gint value) => Convert.ToDecimal(value._value);
            double IConvert<gint>.ToDouble(gint value) => Convert.ToDouble(value._value);
            float IConvert<gint>.ToSingle(gint value) => Convert.ToSingle(value._value);
            int IConvert<gint>.ToInt32(gint value) => Convert.ToInt32(value._value);
            long IConvert<gint>.ToInt64(gint value) => Convert.ToInt64(value._value);
            sbyte IConvert<gint>.ToSByte(gint value) => Convert.ToSByte(value._value);
            short IConvert<gint>.ToInt16(gint value) => Convert.ToInt16(value._value);
            string IConvert<gint>.ToString(gint value) => Convert.ToString(value._value);
            string IConvert<gint>.ToString(gint value, IFormatProvider provider) => Convert.ToString(value._value, provider);
            uint IConvert<gint>.ToUInt32(gint value) => Convert.ToUInt32(value._value);
            ulong IConvert<gint>.ToUInt64(gint value) => Convert.ToUInt64(value._value);
            ushort IConvert<gint>.ToUInt16(gint value) => Convert.ToUInt16(value._value);

            gint IConvert<gint>.ToValue(bool value) => Convert.ToInt32(value);
            gint IConvert<gint>.ToValue(byte value) => Convert.ToInt32(value);
            gint IConvert<gint>.ToValue(char value) => Convert.ToInt32(value);
            gint IConvert<gint>.ToValue(decimal value) => Convert.ToInt32(value);
            gint IConvert<gint>.ToValue(double value) => Convert.ToInt32(value);
            gint IConvert<gint>.ToValue(float value) => Convert.ToInt32(value);
            gint IConvert<gint>.ToValue(int value) => Convert.ToInt32(value);
            gint IConvert<gint>.ToValue(long value) => Convert.ToInt32(value);
            gint IConvert<gint>.ToValue(sbyte value) => Convert.ToInt32(value);
            gint IConvert<gint>.ToValue(short value) => Convert.ToInt32(value);
            gint IConvert<gint>.ToValue(string value) => Convert.ToInt32(value);
            gint IConvert<gint>.ToValue(string value, IFormatProvider provider) => Convert.ToInt32(value, provider);
            gint IConvert<gint>.ToValue(uint value) => Convert.ToInt32(value);
            gint IConvert<gint>.ToValue(ulong value) => Convert.ToInt32(value);
            gint IConvert<gint>.ToValue(ushort value) => Convert.ToInt32(value);
        }
    }
}
