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
    public readonly struct cuint : INumeric<cuint>
    {
        public static readonly cuint MaxValue = new cuint(uint.MaxValue);
        public static readonly cuint MinValue = new cuint(uint.MinValue);

        private readonly uint _value;

        private cuint(uint value)
        {
            _value = value;
        }

        private cuint(SerializationInfo info, StreamingContext context) : this(info.GetUInt32(nameof(cuint))) { }
        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context) => info.AddValue(nameof(cuint), _value);

        public int CompareTo(object? obj) => obj is cuint other ? CompareTo(other) : 1;
        public int CompareTo(cuint other) => _value.CompareTo(other._value);
        public bool Equals(cuint other) => _value == other._value;
        public override bool Equals(object? obj) => obj is cuint other && Equals(other);
        public override int GetHashCode() => _value.GetHashCode();
        public override string ToString() => _value.ToString();
        public string ToString(IFormatProvider formatProvider) => _value.ToString(formatProvider);
        public string ToString(string format, IFormatProvider formatProvider) => _value.ToString(format, formatProvider);

        public static bool TryParse(string s, IFormatProvider provider, out cuint result) => Try.Run(() => Parse(s, provider), out result);
        public static bool TryParse(string s, NumberStyles style, IFormatProvider provider, out cuint result) => Try.Run(() => Parse(s, style, provider), out result);
        public static bool TryParse(string s, NumberStyles style, out cuint result) => Try.Run(() => Parse(s, style), out result);
        public static bool TryParse(string s, out cuint result) => Try.Run(() => Parse(s), out result);
        public static cuint Parse(string s) => uint.Parse(s);
        public static cuint Parse(string s, IFormatProvider provider) => uint.Parse(s, provider);
        public static cuint Parse(string s, NumberStyles style) => uint.Parse(s, style);
        public static cuint Parse(string s, NumberStyles style, IFormatProvider provider) => uint.Parse(s, style, provider);

        public static explicit operator cuint(decimal value) => new cuint(CheckedTruncate.ToUInt32(value));
        public static explicit operator cuint(double value) => new cuint(CheckedTruncate.ToUInt32(value));
        public static explicit operator cuint(float value) => new cuint(CheckedTruncate.ToUInt32(value));
        public static explicit operator cuint(int value) => new cuint(CheckedConvert.ToUInt32(value));
        public static explicit operator cuint(long value) => new cuint(CheckedConvert.ToUInt32(value));
        public static explicit operator cuint(sbyte value) => new cuint(CheckedConvert.ToUInt32(value));
        public static explicit operator cuint(short value) => new cuint(CheckedConvert.ToUInt32(value));
        public static explicit operator cuint(ulong value) => new cuint(CheckedConvert.ToUInt32(value));
        public static implicit operator cuint(byte value) => new cuint(value);
        public static implicit operator cuint(char value) => new cuint(value);
        public static implicit operator cuint(uint value) => new cuint(value);
        public static implicit operator cuint(ushort value) => new cuint(value);

        public static explicit operator byte(cuint value) => CheckedConvert.ToByte(value._value);
        public static explicit operator char(cuint value) => CheckedConvert.ToChar(value._value);
        public static explicit operator int(cuint value) => CheckedConvert.ToInt32(value._value);
        public static explicit operator sbyte(cuint value) => CheckedConvert.ToSByte(value._value);
        public static explicit operator short(cuint value) => CheckedConvert.ToInt16(value._value);
        public static explicit operator ushort(cuint value) => CheckedConvert.ToUInt16(value._value);
        public static implicit operator decimal(cuint value) => value._value;
        public static implicit operator double(cuint value) => value._value;
        public static implicit operator float(cuint value) => value._value;
        public static implicit operator long(cuint value) => value._value;
        public static implicit operator uint(cuint value) => value._value;
        public static implicit operator ulong(cuint value) => value._value;

        public static bool operator !=(cuint left, cuint right) => left._value != right._value;
        public static bool operator <(cuint left, cuint right) => left._value < right._value;
        public static bool operator <=(cuint left, cuint right) => left._value <= right._value;
        public static bool operator ==(cuint left, cuint right) => left._value == right._value;
        public static bool operator >(cuint left, cuint right) => left._value > right._value;
        public static bool operator >=(cuint left, cuint right) => left._value >= right._value;
        public static cuint operator %(cuint left, cuint right) => CheckedArithmetic.Remainder(left._value, right._value);
        public static cuint operator &(cuint left, cuint right) => left._value & right._value;
        public static cuint operator -(cuint _) => MinValue;
        public static cuint operator -(cuint left, cuint right) => CheckedArithmetic.Subtract(left._value, right._value);
        public static cuint operator --(cuint value) => value - 1;
        public static cuint operator *(cuint left, cuint right) => CheckedArithmetic.Multiply(left._value, right._value);
        public static cuint operator /(cuint left, cuint right) => CheckedArithmetic.Divide(left._value, right._value);
        public static cuint operator ^(cuint left, cuint right) => left._value ^ right._value;
        public static cuint operator |(cuint left, cuint right) => left._value | right._value;
        public static cuint operator ~(cuint value) => ~value._value;
        public static cuint operator +(cuint left, cuint right) => CheckedArithmetic.Add(left._value, right._value);
        public static cuint operator +(cuint value) => value;
        public static cuint operator ++(cuint value) => value + 1;
        public static cuint operator <<(cuint left, int right) => left._value << right;
        public static cuint operator >>(cuint left, int right) => left._value >> right;

        bool INumeric<cuint>.IsGreaterThan(cuint value) => this > value;
        bool INumeric<cuint>.IsGreaterThanOrEqualTo(cuint value) => this >= value;
        bool INumeric<cuint>.IsLessThan(cuint value) => this < value;
        bool INumeric<cuint>.IsLessThanOrEqualTo(cuint value) => this <= value;
        cuint INumeric<cuint>.Add(cuint value) => this + value;
        cuint INumeric<cuint>.Divide(cuint value) => this / value;
        cuint INumeric<cuint>.Multiply(cuint value) => this * value;
        cuint INumeric<cuint>.Negative() => -this;
        cuint INumeric<cuint>.Positive() => +this;
        cuint INumeric<cuint>.Remainder(cuint value) => this % value;
        cuint INumeric<cuint>.Subtract(cuint value) => this - value;

        IBitConverter<cuint> IBitConvertible<cuint>.BitConverter => Utilities.Instance;
        IConstants<cuint> INumeric<cuint>.Constants => Utilities.Instance;
        IConvert<cuint> IConvertible<cuint>.Convert => Utilities.Instance;
        IMath<cuint> INumeric<cuint>.Math => Utilities.Instance;
        IRandom<cuint> IRandomisable<cuint>.Random => Utilities.Instance;
        IStringParser<cuint> IStringParsable<cuint>.StringParser => Utilities.Instance;

        private sealed class Utilities :
            IBitConverter<cuint>,
            IConstants<cuint>,
            IConvert<cuint>,
            IMath<cuint>,
            IRandom<cuint>,
            IStringParser<cuint>
        {
            public readonly static Utilities Instance = new Utilities();

            bool IConstants<cuint>.IsReal { get; } = false;
            bool IConstants<cuint>.IsSigned { get; } = false;
            cuint IConstants<cuint>.Epsilon { get; } = 1;
            cuint IConstants<cuint>.MaxUnit { get; } = 1;
            cuint IConstants<cuint>.MaxValue => MaxValue;
            cuint IConstants<cuint>.MinUnit { get; } = 0;
            cuint IConstants<cuint>.MinValue => MinValue;
            cuint IConstants<cuint>.One { get; } = 1;
            cuint IConstants<cuint>.Zero { get; } = 0;
            cuint IMath<cuint>.E { get; } = 2;
            cuint IMath<cuint>.PI { get; } = 3;
            cuint IMath<cuint>.Tau { get; } = 3;

            int IMath<cuint>.Sign(cuint x) => 1;
            cuint IMath<cuint>.Truncate(cuint x) => x;
            cuint IMath<cuint>.Tanh(cuint x) => (cuint)Math.Tanh(x._value);
            cuint IMath<cuint>.Tan(cuint x) => (cuint)Math.Tan(x._value);
            cuint IMath<cuint>.Sqrt(cuint x) => (cuint)Math.Sqrt(x._value);
            cuint IMath<cuint>.Sinh(cuint x) => (cuint)Math.Sinh(x._value);
            cuint IMath<cuint>.Sin(cuint x) => (cuint)Math.Sin(x._value);
            cuint IMath<cuint>.Round(cuint x, MidpointRounding mode) => x;
            cuint IMath<cuint>.Round(cuint x, int digits, MidpointRounding mode) => x;
            cuint IMath<cuint>.Round(cuint x, int digits) => x;
            cuint IMath<cuint>.Round(cuint x) => x;
            cuint IMath<cuint>.RadiansToDegrees(cuint x) => (cuint)CheckedArithmetic.Multiply(x, Trig.DegreesPerRadian);
            cuint IMath<cuint>.Pow(cuint x, cuint y) => CheckedArithmetic.Pow(x._value, y._value);
            cuint IMath<cuint>.Pow(cuint x, byte y) => CheckedArithmetic.Pow(x._value, y);
            cuint IMath<cuint>.Min(cuint x, cuint y) => Math.Min(x._value, y._value);
            cuint IMath<cuint>.Max(cuint x, cuint y) => Math.Max(x._value, y._value);
            cuint IMath<cuint>.Log10(cuint x) => (cuint)Math.Log10(x._value);
            cuint IMath<cuint>.Log(cuint x, cuint y) => (cuint)Math.Log(x._value, y._value);
            cuint IMath<cuint>.Log(cuint x) => (cuint)Math.Log(x._value);
            cuint IMath<cuint>.IEEERemainder(cuint x, cuint y) => (cuint)Math.IEEERemainder(x._value, y._value);
            cuint IMath<cuint>.Floor(cuint x) => x;
            cuint IMath<cuint>.Exp(cuint x) => (cuint)Math.Exp(x._value);
            cuint IMath<cuint>.DegreesToRadians(cuint x) => (cuint)CheckedArithmetic.Multiply(x, Trig.RadiansPerDegree);
            cuint IMath<cuint>.Cosh(cuint x) => (cuint)Math.Cosh(x._value);
            cuint IMath<cuint>.Cos(cuint x) => (cuint)Math.Cos(x._value);
            cuint IMath<cuint>.Clamp(cuint x, cuint bound1, cuint bound2) => bound1 > bound2 ? Math.Min(bound1._value, Math.Max(bound2._value, x._value)) : Math.Min(bound2._value, Math.Max(bound1._value, x._value));
            cuint IMath<cuint>.Ceiling(cuint x) => x;
            cuint IMath<cuint>.Cbrt(cuint x) => (cuint)Math.Cbrt(x._value);
            cuint IMath<cuint>.Atanh(cuint x) => (cuint)Math.Atanh(x._value);
            cuint IMath<cuint>.Atan2(cuint x, cuint y) => (cuint)Math.Atan2(x._value, y._value);
            cuint IMath<cuint>.Atan(cuint x) => (cuint)Math.Atan(x._value);
            cuint IMath<cuint>.Asinh(cuint x) => (cuint)Math.Asinh(x._value);
            cuint IMath<cuint>.Asin(cuint x) => (cuint)Math.Asin(x._value);
            cuint IMath<cuint>.Acosh(cuint x) => (cuint)Math.Acosh(x._value);
            cuint IMath<cuint>.Acos(cuint x) => (cuint)Math.Acos(x._value);
            cuint IMath<cuint>.Abs(cuint x) => x;

            cuint IBitConverter<cuint>.Read(IReadOnlyStream<byte> stream) => BitConverter.ToUInt32(stream.Read(sizeof(uint)));
            void IBitConverter<cuint>.Write(cuint value, IWriteOnlyStream<byte> stream) => stream.Write(BitConverter.GetBytes(value._value));

            cuint IRandom<cuint>.Next(Random random) => random.NextUInt32();
            cuint IRandom<cuint>.Next(Random random, cuint bound1, cuint bound2) => random.NextUInt32(bound1._value, bound2._value);

            cuint IStringParser<cuint>.Parse(string s) => Parse(s);
            cuint IStringParser<cuint>.Parse(string s, NumberStyles numberStyles, IFormatProvider formatProvider) => Parse(s, numberStyles, formatProvider);

            bool IConvert<cuint>.ToBoolean(cuint value) => CheckedConvert.ToBoolean(value._value);
            byte IConvert<cuint>.ToByte(cuint value) => CheckedConvert.ToByte(value._value);
            char IConvert<cuint>.ToChar(cuint value) => CheckedConvert.ToChar(value._value);
            decimal IConvert<cuint>.ToDecimal(cuint value) => CheckedConvert.ToDecimal(value._value);
            double IConvert<cuint>.ToDouble(cuint value) => CheckedConvert.ToDouble(value._value);
            float IConvert<cuint>.ToSingle(cuint value) => CheckedConvert.ToSingle(value._value);
            int IConvert<cuint>.ToInt32(cuint value) => CheckedConvert.ToInt32(value._value);
            long IConvert<cuint>.ToInt64(cuint value) => CheckedConvert.ToInt64(value._value);
            sbyte IConvert<cuint>.ToSByte(cuint value) => CheckedConvert.ToSByte(value._value);
            short IConvert<cuint>.ToInt16(cuint value) => CheckedConvert.ToInt16(value._value);
            string IConvert<cuint>.ToString(cuint value) => Convert.ToString(value._value);
            string IConvert<cuint>.ToString(cuint value, IFormatProvider provider) => Convert.ToString(value._value, provider);
            uint IConvert<cuint>.ToUInt32(cuint value) => value._value;
            ulong IConvert<cuint>.ToUInt64(cuint value) => CheckedConvert.ToUInt64(value._value);
            ushort IConvert<cuint>.ToUInt16(cuint value) => CheckedConvert.ToUInt16(value._value);

            cuint IConvert<cuint>.ToValue(bool value) => CheckedConvert.ToUInt32(value);
            cuint IConvert<cuint>.ToValue(byte value) => CheckedConvert.ToUInt32(value);
            cuint IConvert<cuint>.ToValue(char value) => CheckedConvert.ToUInt32(value);
            cuint IConvert<cuint>.ToValue(decimal value) => CheckedConvert.ToUInt32(value);
            cuint IConvert<cuint>.ToValue(double value) => CheckedConvert.ToUInt32(value);
            cuint IConvert<cuint>.ToValue(float value) => CheckedConvert.ToUInt32(value);
            cuint IConvert<cuint>.ToValue(int value) => CheckedConvert.ToUInt32(value);
            cuint IConvert<cuint>.ToValue(long value) => CheckedConvert.ToUInt32(value);
            cuint IConvert<cuint>.ToValue(sbyte value) => CheckedConvert.ToUInt32(value);
            cuint IConvert<cuint>.ToValue(short value) => CheckedConvert.ToUInt32(value);
            cuint IConvert<cuint>.ToValue(string value) => Convert.ToUInt32(value);
            cuint IConvert<cuint>.ToValue(string value, IFormatProvider provider) => Convert.ToUInt32(value, provider);
            cuint IConvert<cuint>.ToValue(uint value) => value;
            cuint IConvert<cuint>.ToValue(ulong value) => CheckedConvert.ToUInt32(value);
            cuint IConvert<cuint>.ToValue(ushort value) => CheckedConvert.ToUInt32(value);
        }
    }
}
