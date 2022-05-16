﻿// Copyright (c) 2022 Joseph J. Short
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
    public readonly struct xuint : INumeric<xuint>
    {
        public static readonly xuint MaxValue = new xuint(uint.MaxValue);
        public static readonly xuint MinValue = new xuint(uint.MinValue);

        private readonly uint _value;

        private xuint(uint value)
        {
            _value = value;
        }

        private xuint(SerializationInfo info, StreamingContext context) : this(info.GetUInt16(nameof(xuint))) { }
        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context) => info.AddValue(nameof(xuint), _value);

        public int CompareTo(xuint other) => _value.CompareTo(other._value);
        public int CompareTo(object? obj) => obj is xuint other ? CompareTo(other) : 1;
        public bool Equals(xuint other) => _value == other._value;
        public override bool Equals(object? obj) => obj is xuint other && Equals(other);
        public override int GetHashCode() => _value.GetHashCode();
        public override string ToString() => _value.ToString();
        public string ToString(IFormatProvider formatProvider) => _value.ToString(formatProvider);
        public string ToString(string format, IFormatProvider formatProvider) => _value.ToString(format, formatProvider);

        public static bool TryParse(string s, IFormatProvider provider, out xuint result) => Try.Run(() => Parse(s, provider), out result);
        public static bool TryParse(string s, NumberStyles style, IFormatProvider provider, out xuint result) => Try.Run(() => Parse(s, style, provider), out result);
        public static bool TryParse(string s, NumberStyles style, out xuint result) => Try.Run(() => Parse(s, style), out result);
        public static bool TryParse(string s, out xuint result) => Try.Run(() => Parse(s), out result);
        public static xuint Parse(string s) => uint.Parse(s);
        public static xuint Parse(string s, IFormatProvider provider) => uint.Parse(s, provider);
        public static xuint Parse(string s, NumberStyles style) => uint.Parse(s, style);
        public static xuint Parse(string s, NumberStyles style, IFormatProvider provider) => uint.Parse(s, style, provider);

        public static explicit operator xuint(decimal value) => new xuint((uint)value);
        public static explicit operator xuint(double value) => new xuint((uint)value);
        public static explicit operator xuint(float value) => new xuint((uint)value);
        public static explicit operator xuint(int value) => new xuint((uint)value);
        public static explicit operator xuint(long value) => new xuint((uint)value);
        public static explicit operator xuint(sbyte value) => new xuint((uint)value);
        public static explicit operator xuint(short value) => new xuint((uint)value);
        public static explicit operator xuint(ulong value) => new xuint((uint)value);
        public static implicit operator xuint(byte value) => new xuint(value);
        public static implicit operator xuint(char value) => new xuint(value);
        public static implicit operator xuint(uint value) => new xuint(value);
        public static implicit operator xuint(ushort value) => new xuint(value);

        public static explicit operator byte(xuint value) => (byte)value._value;
        public static explicit operator char(xuint value) => (char)value._value;
        public static explicit operator int(xuint value) => (int)value._value;
        public static explicit operator sbyte(xuint value) => (sbyte)value._value;
        public static explicit operator short(xuint value) => (short)value._value;
        public static explicit operator ushort(xuint value) => (ushort)value._value;
        public static implicit operator decimal(xuint value) => value._value;
        public static implicit operator double(xuint value) => value._value;
        public static implicit operator float(xuint value) => value._value;
        public static implicit operator long(xuint value) => value._value;
        public static implicit operator uint(xuint value) => value._value;
        public static implicit operator ulong(xuint value) => value._value;

        public static bool operator !=(xuint left, xuint right) => left._value != right._value;
        public static bool operator <(xuint left, xuint right) => left._value < right._value;
        public static bool operator <=(xuint left, xuint right) => left._value <= right._value;
        public static bool operator ==(xuint left, xuint right) => left._value == right._value;
        public static bool operator >(xuint left, xuint right) => left._value > right._value;
        public static bool operator >=(xuint left, xuint right) => left._value >= right._value;
        public static xuint operator %(xuint left, xuint right) => left._value % right._value;
        public static xuint operator &(xuint left, xuint right) => left._value & right._value;
        public static xuint operator -(xuint left, xuint right) => left._value - right._value;
        public static xuint operator --(xuint value) => value._value - 1;
        public static xuint operator -(xuint value) => (uint)-value._value;
        public static xuint operator *(xuint left, xuint right) => left._value * right._value;
        public static xuint operator /(xuint left, xuint right) => left._value / right._value;
        public static xuint operator ^(xuint left, xuint right) => left._value ^ right._value;
        public static xuint operator |(xuint left, xuint right) => left._value | right._value;
        public static xuint operator ~(xuint value) => ~value._value;
        public static xuint operator +(xuint left, xuint right) => left._value + right._value;
        public static xuint operator +(xuint value) => value;
        public static xuint operator ++(xuint value) => value._value + 1;
        public static xuint operator <<(xuint left, int right) => left._value << right;
        public static xuint operator >>(xuint left, int right) => left._value >> right;

        bool INumeric<xuint>.IsGreaterThan(xuint value) => this > value;
        bool INumeric<xuint>.IsGreaterThanOrEqualTo(xuint value) => this >= value;
        bool INumeric<xuint>.IsLessThan(xuint value) => this < value;
        bool INumeric<xuint>.IsLessThanOrEqualTo(xuint value) => this <= value;
        xuint INumeric<xuint>.Add(xuint value) => this + value;
        xuint INumeric<xuint>.Divide(xuint value) => this / value;
        xuint INumeric<xuint>.Multiply(xuint value) => this * value;
        xuint INumeric<xuint>.Negative() => -this;
        xuint INumeric<xuint>.Positive() => +this;
        xuint INumeric<xuint>.Remainder(xuint value) => this % value;
        xuint INumeric<xuint>.Subtract(xuint value) => this - value;

        IBitConverter<xuint> IBitConvertible<xuint>.BitConverter => Utilities.Instance;
        IConstants<xuint> INumeric<xuint>.Constants => Utilities.Instance;
        IConvert<xuint> IConvertible<xuint>.Convert => Utilities.Instance;
        IMath<xuint> INumeric<xuint>.Math => Utilities.Instance;
        IRandom<xuint> IRandomisable<xuint>.Random => Utilities.Instance;
        IStringParser<xuint> IStringParsable<xuint>.StringParser => Utilities.Instance;

        private sealed class Utilities :
            IBitConverter<xuint>,
            IConstants<xuint>,
            IConvert<xuint>,
            IMath<xuint>,
            IRandom<xuint>,
            IStringParser<xuint>
        {
            public readonly static Utilities Instance = new Utilities();

            bool IConstants<xuint>.IsReal { get; } = false;
            bool IConstants<xuint>.IsSigned { get; } = false;
            xuint IConstants<xuint>.Epsilon { get; } = (uint)1;
            xuint IConstants<xuint>.MaxUnit { get; } = (uint)1;
            xuint IConstants<xuint>.MaxValue => MaxValue;
            xuint IConstants<xuint>.MinUnit { get; } = (uint)0;
            xuint IConstants<xuint>.MinValue => MinValue;
            xuint IConstants<xuint>.One { get; } = (uint)1;
            xuint IConstants<xuint>.Zero { get; } = (uint)0;
            xuint IMath<xuint>.E { get; } = (uint)2;
            xuint IMath<xuint>.PI { get; } = (uint)3;
            xuint IMath<xuint>.Tau { get; } = (uint)6;

            int IMath<xuint>.Sign(xuint x) => Math.Sign(x._value);
            xuint IMath<xuint>.Abs(xuint x) => x._value;
            xuint IMath<xuint>.Acos(xuint x) => (uint)Math.Acos(x._value);
            xuint IMath<xuint>.Acosh(xuint x) => (uint)Math.Acosh(x._value);
            xuint IMath<xuint>.Asin(xuint x) => (uint)Math.Asin(x._value);
            xuint IMath<xuint>.Asinh(xuint x) => (uint)Math.Asinh(x._value);
            xuint IMath<xuint>.Atan(xuint x) => (uint)Math.Atan(x._value);
            xuint IMath<xuint>.Atan2(xuint x, xuint y) => (uint)Math.Atan2(x._value, y._value);
            xuint IMath<xuint>.Atanh(xuint x) => (uint)Math.Atanh(x._value);
            xuint IMath<xuint>.Cbrt(xuint x) => (uint)Math.Cbrt(x._value);
            xuint IMath<xuint>.Ceiling(xuint x) => x;
            xuint IMath<xuint>.Clamp(xuint x, xuint bound1, xuint bound2) => bound1 > bound2 ? Math.Min(bound1._value, Math.Max(bound2._value, x._value)) : Math.Min(bound2._value, Math.Max(bound1._value, x._value));
            xuint IMath<xuint>.Cos(xuint x) => (uint)Math.Cos(x._value);
            xuint IMath<xuint>.Cosh(xuint x) => (uint)Math.Cosh(x._value);
            xuint IMath<xuint>.DegreesToRadians(xuint x) => (uint)(x * Trig.RadiansPerDegree);
            xuint IMath<xuint>.Exp(xuint x) => (uint)Math.Exp(x._value);
            xuint IMath<xuint>.Floor(xuint x) => x;
            xuint IMath<xuint>.IEEERemainder(xuint x, xuint y) => (uint)Math.IEEERemainder(x._value, y._value);
            xuint IMath<xuint>.Log(xuint x) => (uint)Math.Log(x._value);
            xuint IMath<xuint>.Log(xuint x, xuint y) => (uint)Math.Log(x._value, y._value);
            xuint IMath<xuint>.Log10(xuint x) => (uint)Math.Log10(x._value);
            xuint IMath<xuint>.Max(xuint x, xuint y) => Math.Max(x._value, y._value);
            xuint IMath<xuint>.Min(xuint x, xuint y) => Math.Min(x._value, y._value);
            xuint IMath<xuint>.Pow(xuint x, byte y) => (uint)Math.Pow(x._value, y);
            xuint IMath<xuint>.Pow(xuint x, xuint y) => (uint)Math.Pow(x._value, y._value);
            xuint IMath<xuint>.RadiansToDegrees(xuint x) => (uint)(x * Trig.DegreesPerRadian);
            xuint IMath<xuint>.Round(xuint x) => x;
            xuint IMath<xuint>.Round(xuint x, int digits) => x;
            xuint IMath<xuint>.Round(xuint x, int digits, MidpointRounding mode) => x;
            xuint IMath<xuint>.Round(xuint x, MidpointRounding mode) => x;
            xuint IMath<xuint>.Sin(xuint x) => (uint)Math.Sin(x._value);
            xuint IMath<xuint>.Sinh(xuint x) => (uint)Math.Sinh(x._value);
            xuint IMath<xuint>.Sqrt(xuint x) => (uint)Math.Sqrt(x._value);
            xuint IMath<xuint>.Tan(xuint x) => (uint)Math.Tan(x._value);
            xuint IMath<xuint>.Tanh(xuint x) => (uint)Math.Tanh(x._value);
            xuint IMath<xuint>.Truncate(xuint x) => x;

            xuint IBitConverter<xuint>.Read(IReadOnlyStream<byte> stream) => BitConverter.ToUInt32(stream.Read(sizeof(uint)));
            void IBitConverter<xuint>.Write(xuint value, IWriteOnlyStream<byte> stream) => stream.Write(BitConverter.GetBytes(value._value));

            xuint IRandom<xuint>.Next(Random random) => random.NextUInt32();
            xuint IRandom<xuint>.Next(Random random, xuint bound1, xuint bound2) => random.NextUInt32(bound1._value, bound2._value);

            xuint IStringParser<xuint>.Parse(string s) => Parse(s);
            xuint IStringParser<xuint>.Parse(string s, NumberStyles numberStyles, IFormatProvider formatProvider) => Parse(s, numberStyles, formatProvider);

            bool IConvert<xuint>.ToBoolean(xuint value) => Convert.ToBoolean(value._value);
            byte IConvert<xuint>.ToByte(xuint value) => Convert.ToByte(value._value);
            char IConvert<xuint>.ToChar(xuint value) => Convert.ToChar(value._value);
            decimal IConvert<xuint>.ToDecimal(xuint value) => Convert.ToDecimal(value._value);
            double IConvert<xuint>.ToDouble(xuint value) => Convert.ToDouble(value._value);
            float IConvert<xuint>.ToSingle(xuint value) => Convert.ToSingle(value._value);
            int IConvert<xuint>.ToInt32(xuint value) => Convert.ToInt32(value._value);
            long IConvert<xuint>.ToInt64(xuint value) => Convert.ToInt64(value._value);
            sbyte IConvert<xuint>.ToSByte(xuint value) => Convert.ToSByte(value._value);
            short IConvert<xuint>.ToInt16(xuint value) => Convert.ToInt16(value._value);
            string IConvert<xuint>.ToString(xuint value) => Convert.ToString(value._value);
            string IConvert<xuint>.ToString(xuint value, IFormatProvider provider) => Convert.ToString(value._value, provider);
            uint IConvert<xuint>.ToUInt32(xuint value) => Convert.ToUInt32(value._value);
            ulong IConvert<xuint>.ToUInt64(xuint value) => Convert.ToUInt64(value._value);
            ushort IConvert<xuint>.ToUInt16(xuint value) => Convert.ToUInt16(value._value);

            xuint IConvert<xuint>.ToValue(bool value) => Convert.ToUInt32(value);
            xuint IConvert<xuint>.ToValue(byte value) => Convert.ToUInt32(value);
            xuint IConvert<xuint>.ToValue(char value) => Convert.ToUInt32(value);
            xuint IConvert<xuint>.ToValue(decimal value) => Convert.ToUInt32(value);
            xuint IConvert<xuint>.ToValue(double value) => Convert.ToUInt32(value);
            xuint IConvert<xuint>.ToValue(float value) => Convert.ToUInt32(value);
            xuint IConvert<xuint>.ToValue(int value) => Convert.ToUInt32(value);
            xuint IConvert<xuint>.ToValue(long value) => Convert.ToUInt32(value);
            xuint IConvert<xuint>.ToValue(sbyte value) => Convert.ToUInt32(value);
            xuint IConvert<xuint>.ToValue(short value) => Convert.ToUInt32(value);
            xuint IConvert<xuint>.ToValue(string value) => Convert.ToUInt32(value);
            xuint IConvert<xuint>.ToValue(string value, IFormatProvider provider) => Convert.ToUInt32(value, provider);
            xuint IConvert<xuint>.ToValue(uint value) => Convert.ToUInt32(value);
            xuint IConvert<xuint>.ToValue(ulong value) => Convert.ToUInt32(value);
            xuint IConvert<xuint>.ToValue(ushort value) => Convert.ToUInt32(value);
        }
    }
}