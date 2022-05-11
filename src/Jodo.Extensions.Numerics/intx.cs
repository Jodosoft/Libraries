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
    public readonly struct intx : INumeric<intx>
    {
        public static readonly intx MaxValue = new intx(int.MaxValue);
        public static readonly intx MinValue = new intx(int.MinValue);

        private readonly int _value;

        private intx(int value)
        {
            _value = value;
        }

        private intx(SerializationInfo info, StreamingContext context) : this(info.GetInt32(nameof(intx))) { }
        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context) => info.AddValue(nameof(intx), _value);

        public int CompareTo(intx other) => _value.CompareTo(other._value);
        public int CompareTo(object? obj) => obj is intx other ? CompareTo(other) : 1;
        public bool Equals(intx other) => _value == other._value;
        public override bool Equals(object? obj) => obj is intx other && Equals(other);
        public override int GetHashCode() => _value.GetHashCode();
        public override string ToString() => _value.ToString();
        public string ToString(string format, IFormatProvider formatProvider) => _value.ToString(format, formatProvider);

        public static bool TryParse(string s, IFormatProvider provider, out intx result) => Try.Run(() => Parse(s, provider), out result);
        public static bool TryParse(string s, NumberStyles style, IFormatProvider provider, out intx result) => Try.Run(() => Parse(s, style, provider), out result);
        public static bool TryParse(string s, NumberStyles style, out intx result) => Try.Run(() => Parse(s, style), out result);
        public static bool TryParse(string s, out intx result) => Try.Run(() => Parse(s), out result);
        public static intx Parse(string s) => int.Parse(s);
        public static intx Parse(string s, IFormatProvider provider) => int.Parse(s, provider);
        public static intx Parse(string s, NumberStyles style) => int.Parse(s, style);
        public static intx Parse(string s, NumberStyles style, IFormatProvider provider) => int.Parse(s, style, provider);

        public static explicit operator intx(in decimal value) => new intx((int)value);
        public static explicit operator intx(in double value) => new intx((int)value);
        public static explicit operator intx(in float value) => new intx((int)value);
        public static explicit operator intx(in long value) => new intx((int)value);
        public static explicit operator intx(in uint value) => new intx((int)value);
        public static explicit operator intx(in ulong value) => new intx((int)value);
        public static implicit operator intx(in byte value) => new intx(value);
        public static implicit operator intx(in int value) => new intx(value);
        public static implicit operator intx(in sbyte value) => new intx(value);
        public static implicit operator intx(in short value) => new intx(value);
        public static implicit operator intx(in ushort value) => new intx(value);

        public static explicit operator byte(in intx value) => (byte)value._value;
        public static explicit operator sbyte(in intx value) => (sbyte)value._value;
        public static explicit operator short(in intx value) => (short)value._value;
        public static explicit operator uint(in intx value) => (uint)value._value;
        public static explicit operator ulong(in intx value) => (ulong)value._value;
        public static explicit operator ushort(in intx value) => (ushort)value._value;
        public static implicit operator decimal(in intx value) => value._value;
        public static implicit operator double(in intx value) => value._value;
        public static implicit operator float(in intx value) => value._value;
        public static implicit operator int(in intx value) => value._value;
        public static implicit operator long(in intx value) => value._value;

        public static bool operator !=(in intx left, in intx right) => left._value != right._value;
        public static bool operator <(in intx left, in intx right) => left._value < right._value;
        public static bool operator <=(in intx left, in intx right) => left._value <= right._value;
        public static bool operator ==(in intx left, in intx right) => left._value == right._value;
        public static bool operator >(in intx left, in intx right) => left._value > right._value;
        public static bool operator >=(in intx left, in intx right) => left._value >= right._value;
        public static intx operator %(in intx left, in intx right) => left._value % right._value;
        public static intx operator &(in intx left, in intx right) => left._value & right._value;
        public static intx operator -(in intx left, in intx right) => left._value - right._value;
        public static intx operator --(in intx value) => value._value - 1;
        public static intx operator -(in intx value) => -value._value;
        public static intx operator *(in intx left, in intx right) => left._value * right._value;
        public static intx operator /(in intx left, in intx right) => left._value / right._value;
        public static intx operator ^(in intx left, in intx right) => left._value ^ right._value;
        public static intx operator |(in intx left, in intx right) => left._value | right._value;
        public static intx operator ~(in intx value) => ~value._value;
        public static intx operator +(in intx left, in intx right) => left._value + right._value;
        public static intx operator +(in intx value) => value;
        public static intx operator ++(in intx value) => value._value + 1;
        public static intx operator <<(in intx left, in int right) => left._value << right;
        public static intx operator >>(in intx left, in int right) => left._value >> right;

        IBitConverter<intx> IBitConvertible<intx>.BitConverter => Utilities.Instance;
        IMath<intx> INumeric<intx>.Math => Utilities.Instance;
        IRandom<intx> IRandomisable<intx>.Random => Utilities.Instance;
        IStringParser<intx> IStringRepresentable<intx>.StringParser => Utilities.Instance;

        private sealed class Utilities : IMath<intx>, IBitConverter<intx>, IRandom<intx>, IStringParser<intx>
        {
            public readonly static Utilities Instance = new Utilities();

            intx IMath<intx>.E { get; } = 3;
            intx IMath<intx>.PI { get; } = 3;
            intx IMath<intx>.Epsilon { get; } = 1;
            intx IMath<intx>.MaxValue => MaxValue;
            intx IMath<intx>.MinValue => MinValue;
            intx IMath<intx>.MaxUnit { get; } = 1;
            intx IMath<intx>.MinUnit { get; } = -1;
            intx IMath<intx>.Zero { get; } = 0;
            intx IMath<intx>.One { get; } = 1;
            bool IMath<intx>.IsSigned { get; } = true;
            bool IMath<intx>.IsReal { get; } = false;

            bool IMath<intx>.IsGreaterThan(in intx x, in intx y) => x > y;
            bool IMath<intx>.IsGreaterThanOrEqualTo(in intx x, in intx y) => x >= y;
            bool IMath<intx>.IsLessThan(in intx x, in intx y) => x < y;
            bool IMath<intx>.IsLessThanOrEqualTo(in intx x, in intx y) => x <= y;
            intx IMath<intx>.Abs(in intx x) => Math.Abs(x._value);
            intx IMath<intx>.Acos(in intx x) => (intx)Math.Acos(x._value);
            intx IMath<intx>.Acosh(in intx x) => (intx)Math.Acosh(x._value);
            intx IMath<intx>.Add(in intx x, in intx y) => x + y;
            intx IMath<intx>.Asin(in intx x) => (intx)Math.Asin(x._value);
            intx IMath<intx>.Asinh(in intx x) => (intx)Math.Asinh(x._value);
            intx IMath<intx>.Atan(in intx x) => (intx)Math.Atan(x._value);
            intx IMath<intx>.Atan2(in intx x, in intx y) => (intx)Math.Atan2(x._value, y._value);
            intx IMath<intx>.Atanh(in intx x) => (intx)Math.Atanh(x._value);
            intx IMath<intx>.Cbrt(in intx x) => (intx)Math.Cbrt(x._value);
            intx IMath<intx>.Ceiling(in intx x) => x;
            intx IMath<intx>.Clamp(in intx x, in intx bound1, in intx bound2) => bound1 > bound2 ? Math.Min(bound1._value, Math.Max(bound2._value, x._value)) : Math.Min(bound2._value, Math.Max(bound1._value, x._value));
            intx IMath<intx>.Convert(in byte value) => value;
            intx IMath<intx>.Cos(in intx x) => (intx)Math.Cos(x._value);
            intx IMath<intx>.Cosh(in intx x) => (intx)Math.Cosh(x._value);
            intx IMath<intx>.DegreesToRadians(in intx x) => (intx)(x * AngleConstants.RadiansPerDegree);
            intx IMath<intx>.DegreesToTurns(in intx x) => (intx)(x * AngleConstants.TurnsPerDegree);
            intx IMath<intx>.Divide(in intx x, in intx y) => x / y;
            intx IMath<intx>.Exp(in intx x) => (intx)Math.Exp(x._value);
            intx IMath<intx>.Floor(in intx x) => x;
            intx IMath<intx>.IEEERemainder(in intx x, in intx y) => (intx)Math.IEEERemainder(x._value, y._value);
            intx IMath<intx>.Log(in intx x) => (intx)Math.Log(x._value);
            intx IMath<intx>.Log(in intx x, in intx y) => (intx)Math.Log(x._value, y._value);
            intx IMath<intx>.Log10(in intx x) => (intx)Math.Log10(x._value);
            intx IMath<intx>.Max(in intx x, in intx y) => Math.Max(x._value, y._value);
            intx IMath<intx>.Min(in intx x, in intx y) => Math.Min(x._value, y._value);
            intx IMath<intx>.Multiply(in intx x, in intx y) => x * y;
            intx IMath<intx>.Negative(in intx x) => -x;
            intx IMath<intx>.Positive(in intx x) => +x;
            intx IMath<intx>.Pow(in intx x, in byte y) => (int)Math.Pow(x._value, y);
            intx IMath<intx>.Pow(in intx x, in intx y) => (int)Math.Pow(x._value, y._value);
            intx IMath<intx>.RadiansToDegrees(in intx x) => (intx)(x * AngleConstants.DegreesPerRadian);
            intx IMath<intx>.RadiansToTurns(in intx x) => (intx)(x * AngleConstants.TurnsPerRadian);
            intx IMath<intx>.Remainder(in intx x, in intx y) => x % y;
            intx IMath<intx>.Round(in intx x) => x;
            intx IMath<intx>.Round(in intx x, in int digits) => x;
            intx IMath<intx>.Round(in intx x, in int digits, in MidpointRounding mode) => x;
            intx IMath<intx>.Round(in intx x, in MidpointRounding mode) => x;
            intx IMath<intx>.Sin(in intx x) => (intx)Math.Sin(x._value);
            intx IMath<intx>.Sinh(in intx x) => (intx)Math.Sinh(x._value);
            intx IMath<intx>.Sqrt(in intx x) => (intx)Math.Sqrt(x._value);
            intx IMath<intx>.Subtract(in intx x, in intx y) => x - y;
            intx IMath<intx>.Tan(in intx x) => (intx)Math.Tan(x._value);
            intx IMath<intx>.Tanh(in intx x) => (intx)Math.Tanh(x._value);
            intx IMath<intx>.Truncate(in intx x) => x;
            intx IMath<intx>.TurnsToDegrees(in intx x) => (intx)(x * AngleConstants.DegreesPerTurn);
            intx IMath<intx>.TurnsToRadians(in intx x) => (intx)(x * AngleConstants.DegreesPerRadian);
            double IMath<intx>.ToDouble(in intx x, in double offset) => x._value + offset;
            float IMath<intx>.ToSingle(in intx x, in float offset) => x._value + offset;
            int IMath<intx>.Sign(in intx x) => Math.Sign(x._value);

            intx IBitConverter<intx>.Read(in IReadOnlyStream<byte> stream) => BitConverter.ToInt32(stream.Read(sizeof(int)));
            void IBitConverter<intx>.Write(intx value, in IWriteOnlyStream<byte> stream) => stream.Write(BitConverter.GetBytes(value._value));

            intx IRandom<intx>.GetNext(Random random) => random.NextInt32();
            intx IRandom<intx>.GetNext(Random random, in intx bound1, in intx bound2) => random.NextInt32(bound1._value, bound2._value);

            intx IStringParser<intx>.Parse(in string s) => Parse(s);
            intx IStringParser<intx>.Parse(in string s, in NumberStyles numberStyles, in IFormatProvider formatProvider) => Parse(s, numberStyles, formatProvider);
        }
    }
}
