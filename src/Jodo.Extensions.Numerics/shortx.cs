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
    public readonly struct shortx : INumeric<shortx>
    {
        public static readonly shortx MaxValue = new shortx(short.MaxValue);
        public static readonly shortx MinValue = new shortx(short.MinValue);

        private readonly short _value;

        private shortx(short value)
        {
            _value = value;
        }

        private shortx(SerializationInfo info, StreamingContext _) : this(info.GetInt16(nameof(shortx))) { }
        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext _) => info.AddValue(nameof(shortx), _value);

        public bool Equals(shortx other) => _value == other._value;
        public int CompareTo(shortx other) => _value.CompareTo(other._value);
        public int CompareTo(object? obj) => obj is shortx other ? CompareTo(other) : 1;
        public override bool Equals(object? obj) => obj is shortx other && Equals(other);
        public override int GetHashCode() => _value.GetHashCode();
        public override string ToString() => _value.ToString();
        public string ToString(string format, IFormatProvider formatProvider) => _value.ToString(format, formatProvider);

        public static bool TryParse(string s, IFormatProvider provider, out shortx result) => Try.Run(Parse, s, provider, out result);
        public static bool TryParse(string s, NumberStyles style, IFormatProvider provider, out shortx result) => Try.Run(Parse, s, style, provider, out result);
        public static bool TryParse(string s, NumberStyles style, out shortx result) => Try.Run(Parse, s, style, out result);
        public static bool TryParse(string s, out shortx result) => Try.Function(Parse, s, out result);
        public static shortx Parse(string s) => short.Parse(s);
        public static shortx Parse(string s, IFormatProvider provider) => short.Parse(s, provider);
        public static shortx Parse(string s, NumberStyles style) => short.Parse(s, style);
        public static shortx Parse(string s, NumberStyles style, IFormatProvider provider) => short.Parse(s, style, provider);

        public static explicit operator shortx(in decimal value) => new shortx((short)value);
        public static explicit operator shortx(in double value) => new shortx((short)value);
        public static explicit operator shortx(in float value) => new shortx((short)value);
        public static explicit operator shortx(in int value) => new shortx((short)value);
        public static explicit operator shortx(in long value) => new shortx((short)value);
        public static explicit operator shortx(in uint value) => new shortx((short)value);
        public static explicit operator shortx(in ulong value) => new shortx((short)value);
        public static explicit operator shortx(in ushort value) => new shortx((short)value);
        public static implicit operator shortx(in byte value) => new shortx(value);
        public static implicit operator shortx(in sbyte value) => new shortx(value);
        public static implicit operator shortx(in short value) => new shortx(value);

        public static explicit operator byte(in shortx value) => (byte)value._value;
        public static explicit operator sbyte(in shortx value) => (sbyte)value._value;
        public static explicit operator uint(in shortx value) => (uint)value._value;
        public static explicit operator ulong(in shortx value) => (ulong)value._value;
        public static explicit operator ushort(in shortx value) => (ushort)value._value;
        public static implicit operator decimal(in shortx value) => value._value;
        public static implicit operator double(in shortx value) => value._value;
        public static implicit operator float(in shortx value) => value._value;
        public static implicit operator int(in shortx value) => value._value;
        public static implicit operator long(in shortx value) => value._value;
        public static implicit operator short(in shortx value) => value._value;

        public static bool operator !=(in shortx left, in shortx right) => left._value != right._value;
        public static bool operator <(in shortx left, in shortx right) => left._value < right._value;
        public static bool operator <=(in shortx left, in shortx right) => left._value <= right._value;
        public static bool operator ==(in shortx left, in shortx right) => left._value == right._value;
        public static bool operator >(in shortx left, in shortx right) => left._value > right._value;
        public static bool operator >=(in shortx left, in shortx right) => left._value >= right._value;
        public static shortx operator %(in shortx left, in shortx right) => (short)(left._value % right._value);
        public static shortx operator &(in shortx left, in shortx right) => (short)(left._value & right._value);
        public static shortx operator -(in shortx left, in shortx right) => (short)(left._value - right._value);
        public static shortx operator --(in shortx value) => (short)(value._value - 1);
        public static shortx operator -(in shortx value) => (short)-value._value;
        public static shortx operator *(in shortx left, in shortx right) => (short)(left._value * right._value);
        public static shortx operator /(in shortx left, in shortx right) => (short)(left._value / right._value);
        public static shortx operator ^(in shortx left, in shortx right) => (short)(left._value ^ right._value);
        public static shortx operator |(in shortx left, in shortx right) => (short)(left._value | right._value);
        public static shortx operator ~(in shortx value) => (short)~value._value;
        public static shortx operator +(in shortx left, in shortx right) => (short)(left._value + right._value);
        public static shortx operator +(in shortx value) => value;
        public static shortx operator ++(in shortx value) => (short)(value._value + 1);
        public static shortx operator <<(in shortx left, in int right) => (short)(left._value << right);
        public static shortx operator >>(in shortx left, in int right) => (short)(left._value >> right);

        IBitConverter<shortx> IBitConvertible<shortx>.BitConverter => Utilities.Instance;
        IMath<shortx> INumeric<shortx>.Math => Utilities.Instance;
        IRandom<shortx> IRandomisable<shortx>.Random => Utilities.Instance;
        IStringParser<shortx> IStringRepresentable<shortx>.StringParser => Utilities.Instance;

        private sealed class Utilities : IMath<shortx>, IBitConverter<shortx>, IRandom<shortx>, IStringParser<shortx>
        {
            public readonly static Utilities Instance = new Utilities();

            shortx IMath<shortx>.E { get; } = (short)3;
            shortx IMath<shortx>.PI { get; } = (short)3;
            shortx IMath<shortx>.Epsilon { get; } = (short)1;
            shortx IMath<shortx>.MaxValue => MaxValue;
            shortx IMath<shortx>.MinValue => MinValue;
            shortx IMath<shortx>.MaxUnit { get; } = (short)1;
            shortx IMath<shortx>.MinUnit { get; } = (short)-1;
            shortx IMath<shortx>.Zero { get; } = (short)0;
            shortx IMath<shortx>.One { get; } = (short)1;
            bool IMath<shortx>.IsSigned { get; } = true;
            bool IMath<shortx>.IsReal { get; } = false;

            bool IMath<shortx>.IsGreaterThan(in shortx x, in shortx y) => x > y;
            bool IMath<shortx>.IsGreaterThanOrEqualTo(in shortx x, in shortx y) => x >= y;
            bool IMath<shortx>.IsLessThan(in shortx x, in shortx y) => x < y;
            bool IMath<shortx>.IsLessThanOrEqualTo(in shortx x, in shortx y) => x <= y;
            shortx IMath<shortx>.Abs(in shortx x) => Math.Abs(x._value);
            shortx IMath<shortx>.Acos(in shortx x) => (shortx)Math.Acos(x._value);
            shortx IMath<shortx>.Acosh(in shortx x) => (shortx)Math.Acosh(x._value);
            shortx IMath<shortx>.Add(in shortx x, in shortx y) => x + y;
            shortx IMath<shortx>.Asin(in shortx x) => (shortx)Math.Asin(x._value);
            shortx IMath<shortx>.Asinh(in shortx x) => (shortx)Math.Asinh(x._value);
            shortx IMath<shortx>.Atan(in shortx x) => (shortx)Math.Atan(x._value);
            shortx IMath<shortx>.Atan2(in shortx x, in shortx y) => (shortx)Math.Atan2(x._value, y._value);
            shortx IMath<shortx>.Atanh(in shortx x) => (shortx)Math.Atanh(x._value);
            shortx IMath<shortx>.Cbrt(in shortx x) => (shortx)Math.Cbrt(x._value);
            shortx IMath<shortx>.Ceiling(in shortx x) => x;
            shortx IMath<shortx>.Clamp(in shortx x, in shortx bound1, in shortx bound2) => bound1 > bound2 ? Math.Min(bound1._value, Math.Max(bound2._value, x._value)) : Math.Min(bound2._value, Math.Max(bound1._value, x._value));
            shortx IMath<shortx>.Convert(in byte value) => value;
            shortx IMath<shortx>.Cos(in shortx x) => (shortx)Math.Cos(x._value);
            shortx IMath<shortx>.Cosh(in shortx x) => (shortx)Math.Cosh(x._value);
            shortx IMath<shortx>.DegreesToRadians(in shortx x) => (shortx)(x * AngleConstants.RadiansPerDegree);
            shortx IMath<shortx>.DegreesToTurns(in shortx x) => (shortx)(x * AngleConstants.TurnsPerDegree);
            shortx IMath<shortx>.Divide(in shortx x, in shortx y) => x / y;
            shortx IMath<shortx>.Exp(in shortx x) => (shortx)Math.Exp(x._value);
            shortx IMath<shortx>.Floor(in shortx x) => x;
            shortx IMath<shortx>.IEEERemainder(in shortx x, in shortx y) => (shortx)Math.IEEERemainder(x._value, y._value);
            shortx IMath<shortx>.Log(in shortx x) => (shortx)Math.Log(x._value);
            shortx IMath<shortx>.Log(in shortx x, in shortx y) => (shortx)Math.Log(x._value, y._value);
            shortx IMath<shortx>.Log10(in shortx x) => (shortx)Math.Log10(x._value);
            shortx IMath<shortx>.Max(in shortx x, in shortx y) => Math.Max(x._value, y._value);
            shortx IMath<shortx>.Min(in shortx x, in shortx y) => Math.Min(x._value, y._value);
            shortx IMath<shortx>.Multiply(in shortx x, in shortx y) => x * y;
            shortx IMath<shortx>.Negative(in shortx x) => -x;
            shortx IMath<shortx>.Positive(in shortx x) => +x;
            shortx IMath<shortx>.Pow(in shortx x, in byte y) => (short)Math.Pow(x._value, y);
            shortx IMath<shortx>.Pow(in shortx x, in shortx y) => (short)Math.Pow(x._value, y._value);
            shortx IMath<shortx>.RadiansToDegrees(in shortx x) => (shortx)(x * AngleConstants.DegreesPerRadian);
            shortx IMath<shortx>.RadiansToTurns(in shortx x) => (shortx)(x * AngleConstants.TurnsPerRadian);
            shortx IMath<shortx>.Remainder(in shortx x, in shortx y) => x % y;
            shortx IMath<shortx>.Round(in shortx x) => x;
            shortx IMath<shortx>.Round(in shortx x, in int digits) => x;
            shortx IMath<shortx>.Round(in shortx x, in int digits, in MidpointRounding mode) => x;
            shortx IMath<shortx>.Round(in shortx x, in MidpointRounding mode) => x;
            shortx IMath<shortx>.Sin(in shortx x) => (shortx)Math.Sin(x._value);
            shortx IMath<shortx>.Sinh(in shortx x) => (shortx)Math.Sinh(x._value);
            shortx IMath<shortx>.Sqrt(in shortx x) => (shortx)Math.Sqrt(x._value);
            shortx IMath<shortx>.Subtract(in shortx x, in shortx y) => x - y;
            shortx IMath<shortx>.Tan(in shortx x) => (shortx)Math.Tan(x._value);
            shortx IMath<shortx>.Tanh(in shortx x) => (shortx)Math.Tanh(x._value);
            shortx IMath<shortx>.Truncate(in shortx x) => x;
            shortx IMath<shortx>.TurnsToDegrees(in shortx x) => (shortx)(x * AngleConstants.DegreesPerTurn);
            shortx IMath<shortx>.TurnsToRadians(in shortx x) => (shortx)(x * AngleConstants.DegreesPerRadian);
            double IMath<shortx>.ToDouble(in shortx x, in double offset) => x._value + offset;
            float IMath<shortx>.ToSingle(in shortx x, in float offset) => x._value + offset;
            int IMath<shortx>.Sign(in shortx x) => Math.Sign(x._value);

            shortx IBitConverter<shortx>.Read(in IReadOnlyStream<byte> stream) => BitConverter.ToInt16(stream.Read(sizeof(int)));
            void IBitConverter<shortx>.Write(shortx value, in IWriteOnlyStream<byte> stream) => stream.Write(BitConverter.GetBytes(value._value));

            shortx IRandom<shortx>.GetNext(Random random) => random.NextInt16();
            shortx IRandom<shortx>.GetNext(Random random, in shortx bound1, in shortx bound2) => random.NextInt16(bound1._value, bound2._value);

            shortx IStringParser<shortx>.Parse(in string s) => Parse(s);
            shortx IStringParser<shortx>.Parse(in string s, in NumberStyles numberStyles, in IFormatProvider formatProvider) => Parse(s, numberStyles, formatProvider);
        }
    }
}
