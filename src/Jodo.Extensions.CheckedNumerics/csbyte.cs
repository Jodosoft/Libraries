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
    public readonly struct csbyte : INumeric<csbyte>
    {
        public static readonly csbyte MaxValue = new csbyte(sbyte.MaxValue);
        public static readonly csbyte MinValue = new csbyte(sbyte.MinValue);

        private readonly sbyte _value;

        private csbyte(sbyte value)
        {
            _value = value;
        }

        private csbyte(SerializationInfo info, StreamingContext context) : this(info.GetSByte(nameof(csbyte))) { }
        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context) => info.AddValue(nameof(csbyte), _value);

        public int CompareTo(csbyte other) => _value.CompareTo(other._value);
        public int CompareTo(object? obj) => obj is csbyte other ? CompareTo(other) : 1;
        public bool Equals(csbyte other) => _value == other._value;
        public override bool Equals(object? obj) => obj is csbyte other && Equals(other);
        public override int GetHashCode() => _value.GetHashCode();
        public override string ToString() => _value.ToString();
        public string ToString(IFormatProvider formatProvider) => _value.ToString(formatProvider);
        public string ToString(string format, IFormatProvider formatProvider) => _value.ToString(format, formatProvider);

        public static bool TryParse(string s, IFormatProvider provider, out csbyte result) => Try.Run(() => Parse(s, provider), out result);
        public static bool TryParse(string s, NumberStyles style, IFormatProvider provider, out csbyte result) => Try.Run(() => Parse(s, style, provider), out result);
        public static bool TryParse(string s, NumberStyles style, out csbyte result) => Try.Run(() => Parse(s, style), out result);
        public static bool TryParse(string s, out csbyte result) => Try.Run(() => Parse(s), out result);
        public static csbyte Parse(string s) => sbyte.Parse(s);
        public static csbyte Parse(string s, IFormatProvider provider) => sbyte.Parse(s, provider);
        public static csbyte Parse(string s, NumberStyles style) => sbyte.Parse(s, style);
        public static csbyte Parse(string s, NumberStyles style, IFormatProvider provider) => sbyte.Parse(s, style, provider);

        public static explicit operator csbyte(byte value) => new csbyte(CheckedConvert.ToSByte(value));
        public static explicit operator csbyte(char value) => new csbyte(CheckedConvert.ToSByte(value));
        public static explicit operator csbyte(decimal value) => new csbyte(CheckedTruncate.ToSByte(value));
        public static explicit operator csbyte(double value) => new csbyte(CheckedTruncate.ToSByte(value));
        public static explicit operator csbyte(float value) => new csbyte(CheckedTruncate.ToSByte(value));
        public static explicit operator csbyte(int value) => new csbyte(CheckedConvert.ToSByte(value));
        public static explicit operator csbyte(long value) => new csbyte(CheckedConvert.ToSByte(value));
        public static explicit operator csbyte(short value) => new csbyte(CheckedConvert.ToSByte(value));
        public static explicit operator csbyte(uint value) => new csbyte(CheckedConvert.ToSByte(value));
        public static explicit operator csbyte(ulong value) => new csbyte(CheckedConvert.ToSByte(value));
        public static explicit operator csbyte(ushort value) => new csbyte(CheckedConvert.ToSByte(value));
        public static implicit operator csbyte(sbyte value) => new csbyte(value);

        public static explicit operator byte(csbyte value) => CheckedConvert.ToByte(value._value);
        public static explicit operator char(csbyte value) => CheckedConvert.ToChar(value._value);
        public static explicit operator uint(csbyte value) => CheckedConvert.ToUInt32(value._value);
        public static explicit operator ulong(csbyte value) => CheckedConvert.ToUInt64(value._value);
        public static explicit operator ushort(csbyte value) => CheckedConvert.ToUInt16(value._value);
        public static implicit operator decimal(csbyte value) => value._value;
        public static implicit operator double(csbyte value) => value._value;
        public static implicit operator float(csbyte value) => value._value;
        public static implicit operator int(csbyte value) => value._value;
        public static implicit operator long(csbyte value) => value._value;
        public static implicit operator sbyte(csbyte value) => value._value;
        public static implicit operator short(csbyte value) => value._value;

        public static bool operator !=(csbyte left, csbyte right) => left._value != right._value;
        public static bool operator <(csbyte left, csbyte right) => left._value < right._value;
        public static bool operator <=(csbyte left, csbyte right) => left._value <= right._value;
        public static bool operator ==(csbyte left, csbyte right) => left._value == right._value;
        public static bool operator >(csbyte left, csbyte right) => left._value > right._value;
        public static bool operator >=(csbyte left, csbyte right) => left._value >= right._value;
        public static csbyte operator %(csbyte left, csbyte right) => CheckedArithmetic.Remainder(left._value, right._value);
        public static csbyte operator &(csbyte left, csbyte right) => (sbyte)(left._value & right._value);
        public static csbyte operator -(csbyte left, csbyte right) => CheckedArithmetic.Subtract(left._value, right._value);
        public static csbyte operator --(csbyte value) => CheckedArithmetic.Subtract(value._value, (sbyte)1);
        public static csbyte operator -(csbyte value) => (sbyte)-value._value;
        public static csbyte operator *(csbyte left, csbyte right) => CheckedArithmetic.Multiply(left._value, right._value);
        public static csbyte operator /(csbyte left, csbyte right) => CheckedArithmetic.Divide(left._value, right._value);
        public static csbyte operator ^(csbyte left, csbyte right) => (sbyte)(left._value ^ right._value);
        public static csbyte operator |(csbyte left, csbyte right) => (sbyte)(left._value | right._value);
        public static csbyte operator ~(csbyte value) => (sbyte)~value._value;
        public static csbyte operator +(csbyte left, csbyte right) => CheckedArithmetic.Add(left._value, right._value);
        public static csbyte operator +(csbyte value) => value;
        public static csbyte operator ++(csbyte value) => CheckedArithmetic.Add(value._value, (sbyte)1);
        public static csbyte operator <<(csbyte left, int right) => (sbyte)(left._value << right);
        public static csbyte operator >>(csbyte left, int right) => (sbyte)(left._value >> right);

        IBitConverter<csbyte> IBitConvertible<csbyte>.BitConverter => Utilities.Instance;
        IMath<csbyte> INumeric<csbyte>.Math => Utilities.Instance;
        IRandom<csbyte> IRandomisable<csbyte>.Random => Utilities.Instance;
        IStringParser<csbyte> IStringRepresentable<csbyte>.StringParser => Utilities.Instance;

        private sealed class Utilities : IMath<csbyte>, IBitConverter<csbyte>, IRandom<csbyte>, IStringParser<csbyte>
        {
            public readonly static Utilities Instance = new Utilities();

            csbyte IMath<csbyte>.E { get; } = 2;
            csbyte IMath<csbyte>.PI { get; } = 3;
            csbyte IMath<csbyte>.Epsilon { get; } = 1;
            csbyte IMath<csbyte>.MaxValue => MaxValue;
            csbyte IMath<csbyte>.MinValue => MinValue;
            csbyte IMath<csbyte>.MaxUnit { get; } = 1;
            csbyte IMath<csbyte>.MinUnit { get; } = -1;
            csbyte IMath<csbyte>.Zero { get; } = 0;
            csbyte IMath<csbyte>.One { get; } = 1;
            bool IMath<csbyte>.IsSigned { get; } = true;
            bool IMath<csbyte>.IsReal { get; } = false;

            bool IMath<csbyte>.IsGreaterThan(csbyte x, csbyte y) => x > y;
            bool IMath<csbyte>.IsGreaterThanOrEqualTo(csbyte x, csbyte y) => x >= y;
            bool IMath<csbyte>.IsLessThan(csbyte x, csbyte y) => x < y;
            bool IMath<csbyte>.IsLessThanOrEqualTo(csbyte x, csbyte y) => x <= y;
            csbyte IMath<csbyte>.Abs(csbyte x) => Math.Abs(x._value);
            csbyte IMath<csbyte>.Acos(csbyte x) => (csbyte)Math.Acos(x._value);
            csbyte IMath<csbyte>.Acosh(csbyte x) => (csbyte)Math.Acosh(x._value);
            csbyte IMath<csbyte>.Add(csbyte x, csbyte y) => x + y;
            csbyte IMath<csbyte>.Asin(csbyte x) => (csbyte)Math.Asin(x._value);
            csbyte IMath<csbyte>.Asinh(csbyte x) => (csbyte)Math.Asinh(x._value);
            csbyte IMath<csbyte>.Atan(csbyte x) => (csbyte)Math.Atan(x._value);
            csbyte IMath<csbyte>.Atan2(csbyte x, csbyte y) => (csbyte)Math.Atan2(x._value, y._value);
            csbyte IMath<csbyte>.Atanh(csbyte x) => (csbyte)Math.Atanh(x._value);
            csbyte IMath<csbyte>.Cbrt(csbyte x) => (csbyte)Math.Cbrt(x._value);
            csbyte IMath<csbyte>.Ceiling(csbyte x) => x;
            csbyte IMath<csbyte>.Clamp(csbyte x, csbyte bound1, csbyte bound2) => bound1 > bound2 ? Math.Min(bound1._value, Math.Max(bound2._value, x._value)) : Math.Min(bound2._value, Math.Max(bound1._value, x._value));
            csbyte IMath<csbyte>.Cos(csbyte x) => (csbyte)Math.Cos(x._value);
            csbyte IMath<csbyte>.Cosh(csbyte x) => (csbyte)Math.Cosh(x._value);
            csbyte IMath<csbyte>.DegreesToRadians(csbyte x) => (csbyte)CheckedArithmetic.Multiply(x, AngleConstants.RadiansPerDegree);
            csbyte IMath<csbyte>.DegreesToTurns(csbyte x) => (csbyte)CheckedArithmetic.Multiply(x, AngleConstants.TurnsPerDegree);
            csbyte IMath<csbyte>.Divide(csbyte x, csbyte y) => x / y;
            csbyte IMath<csbyte>.Exp(csbyte x) => (csbyte)Math.Exp(x._value);
            csbyte IMath<csbyte>.Floor(csbyte x) => x;
            csbyte IMath<csbyte>.IEEERemainder(csbyte x, csbyte y) => (csbyte)Math.IEEERemainder(x._value, y._value);
            csbyte IMath<csbyte>.Log(csbyte x) => (csbyte)Math.Log(x._value);
            csbyte IMath<csbyte>.Log(csbyte x, csbyte y) => (csbyte)Math.Log(x._value, y._value);
            csbyte IMath<csbyte>.Log10(csbyte x) => (csbyte)Math.Log10(x._value);
            csbyte IMath<csbyte>.Max(csbyte x, csbyte y) => Math.Max(x._value, y._value);
            csbyte IMath<csbyte>.Min(csbyte x, csbyte y) => Math.Min(x._value, y._value);
            csbyte IMath<csbyte>.Multiply(csbyte x, csbyte y) => x * y;
            csbyte IMath<csbyte>.Negative(csbyte x) => -x;
            csbyte IMath<csbyte>.Positive(csbyte x) => +x;
            csbyte IMath<csbyte>.Pow(csbyte x, byte y) => CheckedArithmetic.Pow(x._value, (sbyte)y);
            csbyte IMath<csbyte>.Pow(csbyte x, csbyte y) => CheckedArithmetic.Pow(x._value, y._value);
            csbyte IMath<csbyte>.RadiansToDegrees(csbyte x) => (csbyte)CheckedArithmetic.Multiply(x, AngleConstants.DegreesPerRadian);
            csbyte IMath<csbyte>.RadiansToTurns(csbyte x) => (csbyte)CheckedArithmetic.Multiply(x, AngleConstants.TurnsPerRadian);
            csbyte IMath<csbyte>.Remainder(csbyte x, csbyte y) => x % y;
            csbyte IMath<csbyte>.Round(csbyte x) => x;
            csbyte IMath<csbyte>.Round(csbyte x, int digits) => x;
            csbyte IMath<csbyte>.Round(csbyte x, int digits, MidpointRounding mode) => x;
            csbyte IMath<csbyte>.Round(csbyte x, MidpointRounding mode) => x;
            csbyte IMath<csbyte>.Sin(csbyte x) => (csbyte)Math.Sin(x._value);
            csbyte IMath<csbyte>.Sinh(csbyte x) => (csbyte)Math.Sinh(x._value);
            csbyte IMath<csbyte>.Sqrt(csbyte x) => (csbyte)Math.Sqrt(x._value);
            csbyte IMath<csbyte>.Subtract(csbyte x, csbyte y) => x - y;
            csbyte IMath<csbyte>.Tan(csbyte x) => (csbyte)Math.Tan(x._value);
            csbyte IMath<csbyte>.Tanh(csbyte x) => (csbyte)Math.Tanh(x._value);
            csbyte IMath<csbyte>.Truncate(csbyte x) => x;
            csbyte IMath<csbyte>.TurnsToDegrees(csbyte x) => (csbyte)CheckedArithmetic.Multiply(x, AngleConstants.DegreesPerTurn);
            csbyte IMath<csbyte>.TurnsToRadians(csbyte x) => (csbyte)CheckedArithmetic.Multiply(x, AngleConstants.DegreesPerRadian);
            double IMath<csbyte>.ToDouble(csbyte x, double offset) => CheckedArithmetic.Add(CheckedConvert.ToSingle(x._value), offset);
            float IMath<csbyte>.ToSingle(csbyte x, float offset) => CheckedArithmetic.Add(CheckedConvert.ToSingle(x._value), offset);
            int IMath<csbyte>.Sign(csbyte x) => Math.Sign(x._value);

            csbyte IBitConverter<csbyte>.Read(IReadOnlyStream<byte> stream) => unchecked((sbyte)stream.Read(1)[0]);
            void IBitConverter<csbyte>.Write(csbyte value, IWriteOnlyStream<byte> stream) => stream.Write(BitConverter.GetBytes(value._value));

            csbyte IRandom<csbyte>.GetNext(Random random) => random.NextSByte();
            csbyte IRandom<csbyte>.GetNext(Random random, csbyte bound1, csbyte bound2) => random.NextSByte(bound1._value, bound2._value);

            csbyte IStringParser<csbyte>.Parse(string s) => Parse(s);
            csbyte IStringParser<csbyte>.Parse(string s, NumberStyles numberStyles, IFormatProvider formatProvider) => Parse(s, numberStyles, formatProvider);
        }

        IConvert<csbyte> IConvertible<csbyte>.Convert => _Convert.Instance;
        private sealed class _Convert : IConvert<csbyte>
        {
            public readonly static _Convert Instance = new _Convert();

            bool IConvert<csbyte>.ToBoolean(csbyte value) => CheckedConvert.ToBoolean(value._value);
            byte IConvert<csbyte>.ToByte(csbyte value) => CheckedConvert.ToByte(value._value);
            char IConvert<csbyte>.ToChar(csbyte value) => CheckedConvert.ToChar(value._value);
            decimal IConvert<csbyte>.ToDecimal(csbyte value) => CheckedConvert.ToDecimal(value._value);
            double IConvert<csbyte>.ToDouble(csbyte value) => CheckedConvert.ToDouble(value._value);
            float IConvert<csbyte>.ToSingle(csbyte value) => CheckedConvert.ToSingle(value._value);
            int IConvert<csbyte>.ToInt32(csbyte value) => CheckedConvert.ToInt32(value._value);
            long IConvert<csbyte>.ToInt64(csbyte value) => CheckedConvert.ToInt64(value._value);
            sbyte IConvert<csbyte>.ToSByte(csbyte value) => value._value;
            short IConvert<csbyte>.ToInt16(csbyte value) => CheckedConvert.ToInt16(value._value);
            string IConvert<csbyte>.ToString(csbyte value) => Convert.ToString(value._value);
            string IConvert<csbyte>.ToString(csbyte value, IFormatProvider provider) => Convert.ToString(value._value, provider);
            uint IConvert<csbyte>.ToUInt32(csbyte value) => CheckedConvert.ToUInt32(value._value);
            ulong IConvert<csbyte>.ToUInt64(csbyte value) => CheckedConvert.ToUInt64(value._value);
            ushort IConvert<csbyte>.ToUInt16(csbyte value) => CheckedConvert.ToUInt16(value._value);

            csbyte IConvert<csbyte>.ToValue(bool value) => CheckedConvert.ToSByte(value);
            csbyte IConvert<csbyte>.ToValue(byte value) => CheckedConvert.ToSByte(value);
            csbyte IConvert<csbyte>.ToValue(char value) => CheckedConvert.ToSByte(value);
            csbyte IConvert<csbyte>.ToValue(decimal value) => CheckedConvert.ToSByte(value);
            csbyte IConvert<csbyte>.ToValue(double value) => CheckedConvert.ToSByte(value);
            csbyte IConvert<csbyte>.ToValue(float value) => CheckedConvert.ToSByte(value);
            csbyte IConvert<csbyte>.ToValue(int value) => CheckedConvert.ToSByte(value);
            csbyte IConvert<csbyte>.ToValue(long value) => CheckedConvert.ToSByte(value);
            csbyte IConvert<csbyte>.ToValue(sbyte value) => value;
            csbyte IConvert<csbyte>.ToValue(short value) => CheckedConvert.ToSByte(value);
            csbyte IConvert<csbyte>.ToValue(string value) => Convert.ToSByte(value);
            csbyte IConvert<csbyte>.ToValue(string value, IFormatProvider provider) => Convert.ToSByte(value, provider);
            csbyte IConvert<csbyte>.ToValue(uint value) => CheckedConvert.ToSByte(value);
            csbyte IConvert<csbyte>.ToValue(ulong value) => CheckedConvert.ToSByte(value);
            csbyte IConvert<csbyte>.ToValue(ushort value) => CheckedConvert.ToSByte(value);
        }
    }
}
