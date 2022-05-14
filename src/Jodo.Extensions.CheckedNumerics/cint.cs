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
    public readonly struct cint : INumeric<cint>
    {
        public static readonly cint MaxValue = new cint(int.MaxValue);
        public static readonly cint MinValue = new cint(int.MinValue);

        private readonly int _value;

        private cint(int value)
        {
            _value = value;
        }

        private cint(SerializationInfo info, StreamingContext context) : this(info.GetInt32(nameof(cint))) { }
        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context) => info.AddValue(nameof(cint), _value);

        public int CompareTo(cint other) => _value.CompareTo(other._value);
        public int CompareTo(object? obj) => obj is cint other ? CompareTo(other) : 1;
        public bool Equals(cint other) => _value == other._value;
        public override bool Equals(object? obj) => obj is cint other && Equals(other);
        public override int GetHashCode() => _value.GetHashCode();
        public override string ToString() => _value.ToString();
        public string ToString(IFormatProvider formatProvider) => _value.ToString(formatProvider);
        public string ToString(string format, IFormatProvider formatProvider) => _value.ToString(format, formatProvider);

        public static bool TryParse(string s, IFormatProvider provider, out cint result) => Try.Run(() => Parse(s, provider), out result);
        public static bool TryParse(string s, NumberStyles style, IFormatProvider provider, out cint result) => Try.Run(() => Parse(s, style, provider), out result);
        public static bool TryParse(string s, NumberStyles style, out cint result) => Try.Run(() => Parse(s, style), out result);
        public static bool TryParse(string s, out cint result) => Try.Run(() => Parse(s), out result);
        public static cint Parse(string s) => int.Parse(s);
        public static cint Parse(string s, IFormatProvider provider) => int.Parse(s, provider);
        public static cint Parse(string s, NumberStyles style) => int.Parse(s, style);
        public static cint Parse(string s, NumberStyles style, IFormatProvider provider) => int.Parse(s, style, provider);

        public static explicit operator cint(in decimal value) => new cint(CheckedTruncate.ToInt32(value));
        public static explicit operator cint(in double value) => new cint(CheckedTruncate.ToInt32(value));
        public static explicit operator cint(in float value) => new cint(CheckedTruncate.ToInt32(value));
        public static explicit operator cint(in long value) => new cint(CheckedConvert.ToInt32(value));
        public static explicit operator cint(in uint value) => new cint(CheckedConvert.ToInt32(value));
        public static explicit operator cint(in ulong value) => new cint(CheckedConvert.ToInt32(value));
        public static implicit operator cint(in byte value) => new cint(value);
        public static implicit operator cint(in char value) => new cint(value);
        public static implicit operator cint(in int value) => new cint(value);
        public static implicit operator cint(in sbyte value) => new cint(value);
        public static implicit operator cint(in short value) => new cint(value);
        public static implicit operator cint(in ushort value) => new cint(value);

        public static explicit operator byte(in cint value) => CheckedConvert.ToByte(value._value);
        public static explicit operator char(in cint value) => CheckedConvert.ToChar(value._value);
        public static explicit operator sbyte(in cint value) => CheckedConvert.ToSByte(value._value);
        public static explicit operator short(in cint value) => CheckedConvert.ToInt16(value._value);
        public static explicit operator uint(in cint value) => CheckedConvert.ToUInt32(value._value);
        public static explicit operator ulong(in cint value) => CheckedConvert.ToUInt64(value._value);
        public static explicit operator ushort(in cint value) => CheckedConvert.ToUInt16(value._value);
        public static implicit operator decimal(in cint value) => value._value;
        public static implicit operator double(in cint value) => value._value;
        public static implicit operator float(in cint value) => value._value;
        public static implicit operator int(in cint value) => value._value;
        public static implicit operator long(in cint value) => value._value;

        public static bool operator !=(in cint left, in cint right) => left._value != right._value;
        public static bool operator <(in cint left, in cint right) => left._value < right._value;
        public static bool operator <=(in cint left, in cint right) => left._value <= right._value;
        public static bool operator ==(in cint left, in cint right) => left._value == right._value;
        public static bool operator >(in cint left, in cint right) => left._value > right._value;
        public static bool operator >=(in cint left, in cint right) => left._value >= right._value;
        public static cint operator %(in cint left, in cint right) => CheckedArithmetic.Remainder(left._value, right._value);
        public static cint operator &(in cint left, in cint right) => left._value & right._value;
        public static cint operator -(in cint left, in cint right) => CheckedArithmetic.Subtract(left._value, right._value);
        public static cint operator --(in cint value) => value - 1;
        public static cint operator -(in cint value) => -value._value;
        public static cint operator *(in cint left, in cint right) => CheckedArithmetic.Multiply(left._value, right._value);
        public static cint operator /(in cint left, in cint right) => CheckedArithmetic.Divide(left._value, right._value);
        public static cint operator ^(in cint left, in cint right) => left._value ^ right._value;
        public static cint operator |(in cint left, in cint right) => left._value | right._value;
        public static cint operator ~(in cint value) => ~value._value;
        public static cint operator +(in cint left, in cint right) => CheckedArithmetic.Add(left._value, right._value);
        public static cint operator +(in cint value) => value;
        public static cint operator ++(in cint value) => value + 1;
        public static cint operator <<(in cint left, in int right) => left._value << right;
        public static cint operator >>(in cint left, in int right) => left._value >> right;

        IBitConverter<cint> IBitConvertible<cint>.BitConverter => Utilities.Instance;
        IMath<cint> INumeric<cint>.Math => Utilities.Instance;
        IRandom<cint> IRandomisable<cint>.Random => Utilities.Instance;
        IStringParser<cint> IStringRepresentable<cint>.StringParser => Utilities.Instance;

        private sealed class Utilities : IMath<cint>, IBitConverter<cint>, IRandom<cint>, IStringParser<cint>
        {
            public readonly static Utilities Instance = new Utilities();

            cint IMath<cint>.E { get; } = 2;
            cint IMath<cint>.PI { get; } = 3;
            cint IMath<cint>.Epsilon { get; } = 1;
            cint IMath<cint>.MaxValue => MaxValue;
            cint IMath<cint>.MinValue => MinValue;
            cint IMath<cint>.MaxUnit { get; } = 1;
            cint IMath<cint>.MinUnit { get; } = -1;
            cint IMath<cint>.Zero { get; } = 0;
            cint IMath<cint>.One { get; } = 1;
            bool IMath<cint>.IsSigned { get; } = true;
            bool IMath<cint>.IsReal { get; } = false;

            bool IMath<cint>.IsGreaterThan(in cint x, in cint y) => x > y;
            bool IMath<cint>.IsGreaterThanOrEqualTo(in cint x, in cint y) => x >= y;
            bool IMath<cint>.IsLessThan(in cint x, in cint y) => x < y;
            bool IMath<cint>.IsLessThanOrEqualTo(in cint x, in cint y) => x <= y;
            cint IMath<cint>.Abs(in cint x) => Math.Abs(x._value);
            cint IMath<cint>.Acos(in cint x) => (cint)Math.Acos(x._value);
            cint IMath<cint>.Acosh(in cint x) => (cint)Math.Acosh(x._value);
            cint IMath<cint>.Add(in cint x, in cint y) => x + y;
            cint IMath<cint>.Asin(in cint x) => (cint)Math.Asin(x._value);
            cint IMath<cint>.Asinh(in cint x) => (cint)Math.Asinh(x._value);
            cint IMath<cint>.Atan(in cint x) => (cint)Math.Atan(x._value);
            cint IMath<cint>.Atan2(in cint x, in cint y) => (cint)Math.Atan2(x._value, y._value);
            cint IMath<cint>.Atanh(in cint x) => (cint)Math.Atanh(x._value);
            cint IMath<cint>.Cbrt(in cint x) => (cint)Math.Cbrt(x._value);
            cint IMath<cint>.Ceiling(in cint x) => x;
            cint IMath<cint>.Clamp(in cint x, in cint bound1, in cint bound2) => bound1 > bound2 ? Math.Min(bound1._value, Math.Max(bound2._value, x._value)) : Math.Min(bound2._value, Math.Max(bound1._value, x._value));
            cint IMath<cint>.Cos(in cint x) => (cint)Math.Cos(x._value);
            cint IMath<cint>.Cosh(in cint x) => (cint)Math.Cosh(x._value);
            cint IMath<cint>.DegreesToRadians(in cint x) => (cint)CheckedArithmetic.Multiply(x, AngleConstants.RadiansPerDegree);
            cint IMath<cint>.DegreesToTurns(in cint x) => (cint)CheckedArithmetic.Multiply(x, AngleConstants.TurnsPerDegree);
            cint IMath<cint>.Divide(in cint x, in cint y) => x / y;
            cint IMath<cint>.Exp(in cint x) => (cint)Math.Exp(x._value);
            cint IMath<cint>.Floor(in cint x) => x;
            cint IMath<cint>.IEEERemainder(in cint x, in cint y) => (cint)Math.IEEERemainder(x._value, y._value);
            cint IMath<cint>.Log(in cint x) => (cint)Math.Log(x._value);
            cint IMath<cint>.Log(in cint x, in cint y) => (cint)Math.Log(x._value, y._value);
            cint IMath<cint>.Log10(in cint x) => (cint)Math.Log10(x._value);
            cint IMath<cint>.Max(in cint x, in cint y) => Math.Max(x._value, y._value);
            cint IMath<cint>.Min(in cint x, in cint y) => Math.Min(x._value, y._value);
            cint IMath<cint>.Multiply(in cint x, in cint y) => x * y;
            cint IMath<cint>.Negative(in cint x) => -x;
            cint IMath<cint>.Positive(in cint x) => +x;
            cint IMath<cint>.Pow(in cint x, in byte y) => CheckedArithmetic.Pow(x._value, y);
            cint IMath<cint>.Pow(in cint x, in cint y) => CheckedArithmetic.Pow(x._value, y._value);
            cint IMath<cint>.RadiansToDegrees(in cint x) => (cint)CheckedArithmetic.Multiply(x, AngleConstants.DegreesPerRadian);
            cint IMath<cint>.RadiansToTurns(in cint x) => (cint)CheckedArithmetic.Multiply(x, AngleConstants.TurnsPerRadian);
            cint IMath<cint>.Remainder(in cint x, in cint y) => x % y;
            cint IMath<cint>.Round(in cint x) => x;
            cint IMath<cint>.Round(in cint x, in int digits) => x;
            cint IMath<cint>.Round(in cint x, in int digits, in MidpointRounding mode) => x;
            cint IMath<cint>.Round(in cint x, in MidpointRounding mode) => x;
            cint IMath<cint>.Sin(in cint x) => (cint)Math.Sin(x._value);
            cint IMath<cint>.Sinh(in cint x) => (cint)Math.Sinh(x._value);
            cint IMath<cint>.Sqrt(in cint x) => (cint)Math.Sqrt(x._value);
            cint IMath<cint>.Subtract(in cint x, in cint y) => x - y;
            cint IMath<cint>.Tan(in cint x) => (cint)Math.Tan(x._value);
            cint IMath<cint>.Tanh(in cint x) => (cint)Math.Tanh(x._value);
            cint IMath<cint>.Truncate(in cint x) => x;
            cint IMath<cint>.TurnsToDegrees(in cint x) => (cint)CheckedArithmetic.Multiply(x, AngleConstants.DegreesPerTurn);
            cint IMath<cint>.TurnsToRadians(in cint x) => (cint)CheckedArithmetic.Multiply(x, AngleConstants.DegreesPerRadian);
            double IMath<cint>.ToDouble(in cint x, in double offset) => CheckedArithmetic.Add(CheckedConvert.ToSingle(x._value), offset);
            float IMath<cint>.ToSingle(in cint x, in float offset) => CheckedArithmetic.Add(CheckedConvert.ToSingle(x._value), offset);
            int IMath<cint>.Sign(in cint x) => Math.Sign(x._value);

            cint IBitConverter<cint>.Read(in IReadOnlyStream<byte> stream) => BitConverter.ToInt32(stream.Read(sizeof(int)));
            void IBitConverter<cint>.Write(cint value, in IWriteOnlyStream<byte> stream) => stream.Write(BitConverter.GetBytes(value._value));

            cint IRandom<cint>.GetNext(Random random) => random.NextInt32();
            cint IRandom<cint>.GetNext(Random random, in cint bound1, in cint bound2) => random.NextInt32(bound1._value, bound2._value);

            cint IStringParser<cint>.Parse(in string s) => Parse(s);
            cint IStringParser<cint>.Parse(in string s, in NumberStyles numberStyles, in IFormatProvider formatProvider) => Parse(s, numberStyles, formatProvider);
        }

        IConvert<cint> IConvertible<cint>.Convert => _Convert.Instance;
        private sealed class _Convert : IConvert<cint>
        {
            public readonly static _Convert Instance = new _Convert();

            bool IConvert<cint>.ToBoolean(cint value) => CheckedConvert.ToBoolean(value._value);
            byte IConvert<cint>.ToByte(cint value) => CheckedConvert.ToByte(value._value);
            char IConvert<cint>.ToChar(cint value) => CheckedConvert.ToChar(value._value);
            decimal IConvert<cint>.ToDecimal(cint value) => CheckedConvert.ToDecimal(value._value);
            double IConvert<cint>.ToDouble(cint value) => CheckedConvert.ToDouble(value._value);
            float IConvert<cint>.ToSingle(cint value) => CheckedConvert.ToSingle(value._value);
            int IConvert<cint>.ToInt32(cint value) => value._value;
            long IConvert<cint>.ToInt64(cint value) => CheckedConvert.ToInt64(value._value);
            sbyte IConvert<cint>.ToSByte(cint value) => CheckedConvert.ToSByte(value._value);
            short IConvert<cint>.ToInt16(cint value) => CheckedConvert.ToInt16(value._value);
            string IConvert<cint>.ToString(cint value) => Convert.ToString(value._value);
            string IConvert<cint>.ToString(cint value, IFormatProvider provider) => Convert.ToString(value._value, provider);
            uint IConvert<cint>.ToUInt32(cint value) => CheckedConvert.ToUInt32(value._value);
            ulong IConvert<cint>.ToUInt64(cint value) => CheckedConvert.ToUInt64(value._value);
            ushort IConvert<cint>.ToUInt16(cint value) => CheckedConvert.ToUInt16(value._value);

            cint IConvert<cint>.ToValue(bool value) => CheckedConvert.ToInt32(value);
            cint IConvert<cint>.ToValue(byte value) => CheckedConvert.ToInt32(value);
            cint IConvert<cint>.ToValue(char value) => CheckedConvert.ToInt32(value);
            cint IConvert<cint>.ToValue(decimal value) => CheckedConvert.ToInt32(value);
            cint IConvert<cint>.ToValue(double value) => CheckedConvert.ToInt32(value);
            cint IConvert<cint>.ToValue(float value) => CheckedConvert.ToInt32(value);
            cint IConvert<cint>.ToValue(int value) => value;
            cint IConvert<cint>.ToValue(long value) => CheckedConvert.ToInt32(value);
            cint IConvert<cint>.ToValue(sbyte value) => CheckedConvert.ToInt32(value);
            cint IConvert<cint>.ToValue(short value) => CheckedConvert.ToInt32(value);
            cint IConvert<cint>.ToValue(string value) => Convert.ToInt32(value);
            cint IConvert<cint>.ToValue(string value, IFormatProvider provider) => Convert.ToInt32(value, provider);
            cint IConvert<cint>.ToValue(uint value) => CheckedConvert.ToInt32(value);
            cint IConvert<cint>.ToValue(ulong value) => CheckedConvert.ToInt32(value);
            cint IConvert<cint>.ToValue(ushort value) => CheckedConvert.ToInt32(value);
        }
    }
}
