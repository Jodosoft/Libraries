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
    public readonly struct cshort : INumeric<cshort>
    {
        public static readonly cshort MaxValue = new cshort(short.MaxValue);
        public static readonly cshort MinValue = new cshort(short.MinValue);

        private readonly short _value;

        private cshort(short value)
        {
            _value = value;
        }

        private cshort(SerializationInfo info, StreamingContext _) : this(info.GetInt16(nameof(cshort))) { }
        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext _) => info.AddValue(nameof(cshort), _value);

        public bool Equals(cshort other) => _value == other._value;
        public int CompareTo(cshort other) => _value.CompareTo(other._value);
        public int CompareTo(object? obj) => obj is cshort other ? CompareTo(other) : 1;
        public override bool Equals(object? obj) => obj is cshort other && Equals(other);
        public override int GetHashCode() => _value.GetHashCode();
        public override string ToString() => _value.ToString();
        public string ToString(string format, IFormatProvider formatProvider) => _value.ToString(format, formatProvider);

        public static bool TryParse(string s, IFormatProvider provider, out cshort result) => Try.Run(Parse, s, provider, out result);
        public static bool TryParse(string s, NumberStyles style, IFormatProvider provider, out cshort result) => Try.Run(Parse, s, style, provider, out result);
        public static bool TryParse(string s, NumberStyles style, out cshort result) => Try.Run(Parse, s, style, out result);
        public static bool TryParse(string s, out cshort result) => Try.Function(Parse, s, out result);
        public static cshort Parse(string s) => short.Parse(s);
        public static cshort Parse(string s, IFormatProvider provider) => short.Parse(s, provider);
        public static cshort Parse(string s, NumberStyles style) => short.Parse(s, style);
        public static cshort Parse(string s, NumberStyles style, IFormatProvider provider) => short.Parse(s, style, provider);

        public static explicit operator cshort(in decimal value) => new cshort(CheckedConvert.ToInt16(value));
        public static explicit operator cshort(in double value) => new cshort(CheckedConvert.ToInt16(value));
        public static explicit operator cshort(in float value) => new cshort(CheckedConvert.ToInt16(value));
        public static explicit operator cshort(in int value) => new cshort(CheckedConvert.ToInt16(value));
        public static explicit operator cshort(in long value) => new cshort(CheckedConvert.ToInt16(value));
        public static explicit operator cshort(in uint value) => new cshort(CheckedConvert.ToInt16(value));
        public static explicit operator cshort(in ulong value) => new cshort(CheckedConvert.ToInt16(value));
        public static explicit operator cshort(in ushort value) => new cshort(CheckedConvert.ToInt16(value));
        public static implicit operator cshort(in byte value) => new cshort(value);
        public static implicit operator cshort(in sbyte value) => new cshort(value);
        public static implicit operator cshort(in short value) => new cshort(value);

        public static explicit operator byte(in cshort value) => CheckedConvert.ToByte(value._value);
        public static explicit operator sbyte(in cshort value) => CheckedConvert.ToSByte(value._value);
        public static explicit operator short(in cshort value) => CheckedConvert.ToInt16(value._value);
        public static explicit operator uint(in cshort value) => CheckedConvert.ToUInt16(value._value);
        public static explicit operator ulong(in cshort value) => CheckedConvert.ToUInt64(value._value);
        public static explicit operator ushort(in cshort value) => CheckedConvert.ToUInt16(value._value);
        public static implicit operator decimal(in cshort value) => value._value;
        public static implicit operator double(in cshort value) => value._value;
        public static implicit operator float(in cshort value) => value._value;
        public static implicit operator int(in cshort value) => value._value;
        public static implicit operator long(in cshort value) => value._value;

        public static bool operator !=(in cshort left, in cshort right) => left._value != right._value;
        public static bool operator <(in cshort left, in cshort right) => left._value < right._value;
        public static bool operator <=(in cshort left, in cshort right) => left._value <= right._value;
        public static bool operator ==(in cshort left, in cshort right) => left._value == right._value;
        public static bool operator >(in cshort left, in cshort right) => left._value > right._value;
        public static bool operator >=(in cshort left, in cshort right) => left._value >= right._value;
        public static cshort operator %(in cshort left, in cshort right) => CheckedArithmetic.Remainder(left._value, right._value);
        public static cshort operator &(in cshort left, in cshort right) => (short)(left._value & right._value);
        public static cshort operator -(in cshort left, in cshort right) => CheckedArithmetic.Subtract(left._value, right._value);
        public static cshort operator --(in cshort value) => CheckedArithmetic.Subtract(value._value, (short)1);
        public static cshort operator -(in cshort value) => (short)-value._value;
        public static cshort operator *(in cshort left, in cshort right) => CheckedArithmetic.Multiply(left._value, right._value);
        public static cshort operator /(in cshort left, in cshort right) => CheckedArithmetic.Divide(left._value, right._value);
        public static cshort operator ^(in cshort left, in cshort right) => (short)(left._value ^ right._value);
        public static cshort operator |(in cshort left, in cshort right) => (short)(left._value | right._value);
        public static cshort operator ~(in cshort value) => (short)~value._value;
        public static cshort operator +(in cshort left, in cshort right) => CheckedArithmetic.Add(left._value, right._value);
        public static cshort operator +(in cshort value) => value;
        public static cshort operator ++(in cshort value) => CheckedArithmetic.Add(value._value, (short)1);
        public static cshort operator <<(in cshort left, in int right) => (short)(left._value << right);
        public static cshort operator >>(in cshort left, in int right) => (short)(left._value >> right);

        IBitConverter<cshort> IBitConvertible<cshort>.BitConverter => Utilities.Instance;
        IMath<cshort> INumeric<cshort>.Math => Utilities.Instance;
        IRandom<cshort> IRandomisable<cshort>.Random => Utilities.Instance;
        IStringParser<cshort> IStringRepresentable<cshort>.StringParser => Utilities.Instance;

        private sealed class Utilities : IMath<cshort>, IBitConverter<cshort>, IRandom<cshort>, IStringParser<cshort>
        {
            public readonly static Utilities Instance = new Utilities();

            cshort IMath<cshort>.E { get; } = (short)3;
            cshort IMath<cshort>.PI { get; } = (short)3;
            cshort IMath<cshort>.Epsilon { get; } = (short)1;
            cshort IMath<cshort>.MaxValue => MaxValue;
            cshort IMath<cshort>.MinValue => MinValue;
            cshort IMath<cshort>.MaxUnit { get; } = (short)1;
            cshort IMath<cshort>.MinUnit { get; } = (short)-1;
            cshort IMath<cshort>.Zero { get; } = (short)0;
            cshort IMath<cshort>.One { get; } = (short)1;
            bool IMath<cshort>.IsSigned { get; } = true;
            bool IMath<cshort>.IsReal { get; } = false;

            bool IMath<cshort>.IsGreaterThan(in cshort x, in cshort y) => x > y;
            bool IMath<cshort>.IsGreaterThanOrEqualTo(in cshort x, in cshort y) => x >= y;
            bool IMath<cshort>.IsLessThan(in cshort x, in cshort y) => x < y;
            bool IMath<cshort>.IsLessThanOrEqualTo(in cshort x, in cshort y) => x <= y;
            cshort IMath<cshort>.Abs(in cshort x) => Math.Abs(x._value);
            cshort IMath<cshort>.Acos(in cshort x) => (cshort)Math.Acos(x._value);
            cshort IMath<cshort>.Acosh(in cshort x) => (cshort)Math.Acosh(x._value);
            cshort IMath<cshort>.Add(in cshort x, in cshort y) => x + y;
            cshort IMath<cshort>.Asin(in cshort x) => (cshort)Math.Asin(x._value);
            cshort IMath<cshort>.Asinh(in cshort x) => (cshort)Math.Asinh(x._value);
            cshort IMath<cshort>.Atan(in cshort x) => (cshort)Math.Atan(x._value);
            cshort IMath<cshort>.Atan2(in cshort x, in cshort y) => (cshort)Math.Atan2(x._value, y._value);
            cshort IMath<cshort>.Atanh(in cshort x) => (cshort)Math.Atanh(x._value);
            cshort IMath<cshort>.Cbrt(in cshort x) => (cshort)Math.Cbrt(x._value);
            cshort IMath<cshort>.Ceiling(in cshort x) => x;
            cshort IMath<cshort>.Clamp(in cshort x, in cshort bound1, in cshort bound2) => bound1 > bound2 ? Math.Min(bound1._value, Math.Max(bound2._value, x._value)) : Math.Min(bound2._value, Math.Max(bound1._value, x._value));
            cshort IMath<cshort>.Convert(in byte value) => value;
            cshort IMath<cshort>.Cos(in cshort x) => (cshort)Math.Cos(x._value);
            cshort IMath<cshort>.Cosh(in cshort x) => (cshort)Math.Cosh(x._value);
            cshort IMath<cshort>.DegreesToRadians(in cshort x) => (cshort)CheckedArithmetic.Multiply(x, AngleConstants.RadiansPerDegree);
            cshort IMath<cshort>.DegreesToTurns(in cshort x) => (cshort)CheckedArithmetic.Multiply(x, AngleConstants.TurnsPerDegree);
            cshort IMath<cshort>.Divide(in cshort x, in cshort y) => x / y;
            cshort IMath<cshort>.Exp(in cshort x) => (cshort)Math.Exp(x._value);
            cshort IMath<cshort>.Floor(in cshort x) => x;
            cshort IMath<cshort>.IEEERemainder(in cshort x, in cshort y) => (cshort)Math.IEEERemainder(x._value, y._value);
            cshort IMath<cshort>.Log(in cshort x) => (cshort)Math.Log(x._value);
            cshort IMath<cshort>.Log(in cshort x, in cshort y) => (cshort)Math.Log(x._value, y._value);
            cshort IMath<cshort>.Log10(in cshort x) => (cshort)Math.Log10(x._value);
            cshort IMath<cshort>.Max(in cshort x, in cshort y) => Math.Max(x._value, y._value);
            cshort IMath<cshort>.Min(in cshort x, in cshort y) => Math.Min(x._value, y._value);
            cshort IMath<cshort>.Multiply(in cshort x, in cshort y) => x * y;
            cshort IMath<cshort>.Negative(in cshort x) => -x;
            cshort IMath<cshort>.Positive(in cshort x) => +x;
            cshort IMath<cshort>.Pow(in cshort x, in byte y) => CheckedArithmetic.Pow(x._value, y);
            cshort IMath<cshort>.Pow(in cshort x, in cshort y) => CheckedArithmetic.Pow(x._value, y._value);
            cshort IMath<cshort>.RadiansToDegrees(in cshort x) => (cshort)CheckedArithmetic.Multiply(x, AngleConstants.DegreesPerRadian);
            cshort IMath<cshort>.RadiansToTurns(in cshort x) => (cshort)CheckedArithmetic.Multiply(x, AngleConstants.TurnsPerRadian);
            cshort IMath<cshort>.Remainder(in cshort x, in cshort y) => x % y;
            cshort IMath<cshort>.Round(in cshort x) => x;
            cshort IMath<cshort>.Round(in cshort x, in int digits) => x;
            cshort IMath<cshort>.Round(in cshort x, in int digits, in MidpointRounding mode) => x;
            cshort IMath<cshort>.Round(in cshort x, in MidpointRounding mode) => x;
            cshort IMath<cshort>.Sin(in cshort x) => (cshort)Math.Sin(x._value);
            cshort IMath<cshort>.Sinh(in cshort x) => (cshort)Math.Sinh(x._value);
            cshort IMath<cshort>.Sqrt(in cshort x) => (cshort)Math.Sqrt(x._value);
            cshort IMath<cshort>.Subtract(in cshort x, in cshort y) => x - y;
            cshort IMath<cshort>.Tan(in cshort x) => (cshort)Math.Tan(x._value);
            cshort IMath<cshort>.Tanh(in cshort x) => (cshort)Math.Tanh(x._value);
            cshort IMath<cshort>.Truncate(in cshort x) => x;
            cshort IMath<cshort>.TurnsToDegrees(in cshort x) => (cshort)CheckedArithmetic.Multiply(x, AngleConstants.DegreesPerTurn);
            cshort IMath<cshort>.TurnsToRadians(in cshort x) => (cshort)CheckedArithmetic.Multiply(x, AngleConstants.DegreesPerRadian);
            double IMath<cshort>.ToDouble(in cshort x, in double offset) => CheckedArithmetic.Add(CheckedConvert.ToSingle(x._value), offset);
            float IMath<cshort>.ToSingle(in cshort x, in float offset) => CheckedArithmetic.Add(CheckedConvert.ToSingle(x._value), offset);
            int IMath<cshort>.Sign(in cshort x) => Math.Sign(x._value);

            cshort IBitConverter<cshort>.Read(in IReadOnlyStream<byte> stream) => BitConverter.ToInt16(stream.Read(sizeof(int)));
            void IBitConverter<cshort>.Write(cshort value, in IWriteOnlyStream<byte> stream) => stream.Write(BitConverter.GetBytes(value._value));

            cshort IRandom<cshort>.GetNext(Random random) => random.NextInt16();
            cshort IRandom<cshort>.GetNext(Random random, in cshort bound1, in cshort bound2) => random.NextInt16(bound1._value, bound2._value);

            cshort IStringParser<cshort>.Parse(in string s) => Parse(s);
            cshort IStringParser<cshort>.Parse(in string s, in NumberStyles numberStyles, in IFormatProvider formatProvider) => Parse(s, numberStyles, formatProvider);
        }
    }
}
