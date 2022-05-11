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
    public readonly struct cdouble : INumeric<cdouble>
    {
        public static readonly cdouble Epsilon = new cdouble(double.Epsilon);
        public static readonly cdouble MaxValue = new cdouble(double.MaxValue);
        public static readonly cdouble MinValue = new cdouble(double.MinValue);

        private readonly double _value;

        public cdouble(double value)
        {
            _value =
             double.IsFinite(value) ? value :
             double.IsPositiveInfinity(value) ? double.MaxValue :
             double.IsNegativeInfinity(value) ? double.MinValue :
             0d;
        }

        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext _) => info.AddValue(nameof(cdouble), _value);
        private cdouble(SerializationInfo info, StreamingContext _) : this(info.GetDouble(nameof(cdouble))) { }

        public bool Equals(cdouble other) => _value == other._value;
        public int CompareTo(cdouble other) => _value.CompareTo(other._value);
        public int CompareTo(object? obj) => obj is cdouble other ? CompareTo(other) : 1;
        public override bool Equals(object? obj) => obj is cdouble other && Equals(other);
        public override int GetHashCode() => _value.GetHashCode();
        public override string ToString() => _value.ToString();
        public string ToString(string format, IFormatProvider formatProvider) => _value.ToString(format, formatProvider);

        public static bool IsNormal(cdouble d) => double.IsNormal(d._value);
        public static bool IsSubnormal(cdouble d) => double.IsSubnormal(d._value);
        public static bool TryParse(string s, IFormatProvider provider, out cdouble result) => Try.Run(Parse, s, provider, out result);
        public static bool TryParse(string s, NumberStyles style, IFormatProvider provider, out cdouble result) => Try.Run(Parse, s, style, provider, out result);
        public static bool TryParse(string s, NumberStyles style, out cdouble result) => Try.Run(Parse, s, style, out result);
        public static bool TryParse(string s, out cdouble result) => Try.Function(Parse, s, out result);
        public static cdouble Parse(string s) => double.Parse(s);
        public static cdouble Parse(string s, IFormatProvider provider) => double.Parse(s, provider);
        public static cdouble Parse(string s, NumberStyles style) => double.Parse(s, style);
        public static cdouble Parse(string s, NumberStyles style, IFormatProvider provider) => double.Parse(s, style, provider);

        public static explicit operator cdouble(in decimal value) => new cdouble(CheckedConvert.ToDouble(value));
        public static implicit operator cdouble(in byte value) => new cdouble(value);
        public static implicit operator cdouble(in double value) => new cdouble(value);
        public static implicit operator cdouble(in float value) => new cdouble(value);
        public static implicit operator cdouble(in int value) => new cdouble(value);
        public static implicit operator cdouble(in long value) => new cdouble(value);
        public static implicit operator cdouble(in sbyte value) => new cdouble(value);
        public static implicit operator cdouble(in short value) => new cdouble(value);
        public static implicit operator cdouble(in uint value) => new cdouble(value);
        public static implicit operator cdouble(in ulong value) => new cdouble(value);
        public static implicit operator cdouble(in ushort value) => new cdouble(value);

        public static explicit operator byte(in cdouble value) => CheckedConvert.ToByte(value._value);
        public static explicit operator decimal(in cdouble value) => CheckedConvert.ToDecimal(value._value);
        public static explicit operator float(in cdouble value) => CheckedConvert.ToSingle(value._value);
        public static explicit operator int(in cdouble value) => CheckedConvert.ToInt32(value._value);
        public static explicit operator long(in cdouble value) => CheckedConvert.ToInt64(value._value);
        public static explicit operator sbyte(in cdouble value) => CheckedConvert.ToSByte(value._value);
        public static explicit operator short(in cdouble value) => CheckedConvert.ToInt16(value._value);
        public static explicit operator uint(in cdouble value) => CheckedConvert.ToUInt32(value._value);
        public static explicit operator ulong(in cdouble value) => CheckedConvert.ToUInt64(value._value);
        public static explicit operator ushort(in cdouble value) => CheckedConvert.ToUInt16(value._value);
        public static implicit operator double(in cdouble value) => value._value;

        public static bool operator !=(cdouble left, cdouble right) => left._value != right._value;
        public static bool operator <(cdouble left, cdouble right) => left._value < right._value;
        public static bool operator <=(cdouble left, cdouble right) => left._value <= right._value;
        public static bool operator ==(cdouble left, cdouble right) => left._value == right._value;
        public static bool operator >(cdouble left, cdouble right) => left._value > right._value;
        public static bool operator >=(cdouble left, cdouble right) => left._value >= right._value;
        public static cdouble operator %(cdouble left, cdouble right) => CheckedArithmetic.Remainder(left._value, right._value);
        public static cdouble operator -(cdouble left, cdouble right) => CheckedArithmetic.Subtract(left._value, right._value);
        public static cdouble operator --(cdouble value) => value - 1;
        public static cdouble operator -(cdouble value) => -value._value;
        public static cdouble operator *(cdouble left, cdouble right) => CheckedArithmetic.Multiply(left._value, right._value);
        public static cdouble operator /(cdouble left, cdouble right) => CheckedArithmetic.Divide(left._value, right._value);
        public static cdouble operator +(cdouble left, cdouble right) => CheckedArithmetic.Add(left._value, right._value);
        public static cdouble operator +(cdouble value) => value;
        public static cdouble operator ++(cdouble value) => value + 1;

        IBitConverter<cdouble> IBitConvertible<cdouble>.BitConverter => Utilities.Instance;
        IMath<cdouble> INumeric<cdouble>.Math => Utilities.Instance;
        IRandom<cdouble> IRandomisable<cdouble>.Random => Utilities.Instance;
        IStringParser<cdouble> IStringRepresentable<cdouble>.StringParser => Utilities.Instance;

        private sealed class Utilities : IMath<cdouble>, IBitConverter<cdouble>, IRandom<cdouble>, IStringParser<cdouble>
        {
            public readonly static Utilities Instance = new Utilities();

            cdouble IMath<cdouble>.E { get; } = Math.E;
            cdouble IMath<cdouble>.PI { get; } = Math.PI;
            cdouble IMath<cdouble>.Epsilon => Epsilon;
            cdouble IMath<cdouble>.MaxValue => MaxValue;
            cdouble IMath<cdouble>.MinValue => MinValue;
            cdouble IMath<cdouble>.MaxUnit { get; } = 1;
            cdouble IMath<cdouble>.MinUnit { get; } = -1;
            cdouble IMath<cdouble>.Zero { get; } = 0;
            cdouble IMath<cdouble>.One { get; } = 1;
            bool IMath<cdouble>.IsSigned { get; } = true;
            bool IMath<cdouble>.IsReal { get; } = true;

            bool IMath<cdouble>.IsGreaterThan(in cdouble x, in cdouble y) => x > y;
            bool IMath<cdouble>.IsGreaterThanOrEqualTo(in cdouble x, in cdouble y) => x >= y;
            bool IMath<cdouble>.IsLessThan(in cdouble x, in cdouble y) => x < y;
            bool IMath<cdouble>.IsLessThanOrEqualTo(in cdouble x, in cdouble y) => x <= y;
            cdouble IMath<cdouble>.Abs(in cdouble x) => Math.Abs(x._value);
            cdouble IMath<cdouble>.Acos(in cdouble x) => Math.Acos(x._value);
            cdouble IMath<cdouble>.Acosh(in cdouble x) => Math.Acosh(x._value);
            cdouble IMath<cdouble>.Add(in cdouble x, in cdouble y) => x + y;
            cdouble IMath<cdouble>.Asin(in cdouble x) => Math.Asin(x._value);
            cdouble IMath<cdouble>.Asinh(in cdouble x) => Math.Asinh(x._value);
            cdouble IMath<cdouble>.Atan(in cdouble x) => Math.Atan(x._value);
            cdouble IMath<cdouble>.Atan2(in cdouble x, in cdouble y) => Math.Atan2(x._value, y._value);
            cdouble IMath<cdouble>.Atanh(in cdouble x) => Math.Atanh(x._value);
            cdouble IMath<cdouble>.Cbrt(in cdouble x) => Math.Cbrt(x._value);
            cdouble IMath<cdouble>.Ceiling(in cdouble x) => Math.Ceiling(x._value);
            cdouble IMath<cdouble>.Clamp(in cdouble x, in cdouble bound1, in cdouble bound2) => bound1 > bound2 ? Math.Min(bound1._value, Math.Max(bound2._value, x._value)) : Math.Min(bound2._value, Math.Max(bound1._value, x._value));
            cdouble IMath<cdouble>.Convert(in byte value) => value;
            cdouble IMath<cdouble>.Cos(in cdouble x) => Math.Cos(x._value);
            cdouble IMath<cdouble>.Cosh(in cdouble x) => Math.Cosh(x._value);
            cdouble IMath<cdouble>.DegreesToRadians(in cdouble x) => x._value * AngleConstants.RadiansPerDegree;
            cdouble IMath<cdouble>.DegreesToTurns(in cdouble x) => x._value * AngleConstants.TurnsPerDegree;
            cdouble IMath<cdouble>.Divide(in cdouble x, in cdouble y) => x / y;
            cdouble IMath<cdouble>.Exp(in cdouble x) => Math.Exp(x._value);
            cdouble IMath<cdouble>.Floor(in cdouble x) => Math.Floor(x._value);
            cdouble IMath<cdouble>.IEEERemainder(in cdouble x, in cdouble y) => Math.IEEERemainder(x._value, y._value);
            cdouble IMath<cdouble>.Log(in cdouble x) => Math.Log(x._value);
            cdouble IMath<cdouble>.Log(in cdouble x, in cdouble y) => Math.Log(x._value, y._value);
            cdouble IMath<cdouble>.Log10(in cdouble x) => Math.Log10(x._value);
            cdouble IMath<cdouble>.Max(in cdouble x, in cdouble y) => Math.Max(x._value, y._value);
            cdouble IMath<cdouble>.Min(in cdouble x, in cdouble y) => Math.Min(x._value, y._value);
            cdouble IMath<cdouble>.Multiply(in cdouble x, in cdouble y) => x * y;
            cdouble IMath<cdouble>.Negative(in cdouble x) => -x;
            cdouble IMath<cdouble>.Positive(in cdouble x) => +x;
            cdouble IMath<cdouble>.Pow(in cdouble x, in byte y) => Math.Pow(x._value, y);
            cdouble IMath<cdouble>.Pow(in cdouble x, in cdouble y) => Math.Pow(x._value, y._value);
            cdouble IMath<cdouble>.RadiansToDegrees(in cdouble x) => x._value * AngleConstants.DegreesPerRadian;
            cdouble IMath<cdouble>.RadiansToTurns(in cdouble x) => x._value * AngleConstants.TurnsPerRadian;
            cdouble IMath<cdouble>.Remainder(in cdouble x, in cdouble y) => x % y;
            cdouble IMath<cdouble>.Round(in cdouble x) => Math.Round(x._value);
            cdouble IMath<cdouble>.Round(in cdouble x, in int digits) => Math.Round(x._value, digits);
            cdouble IMath<cdouble>.Round(in cdouble x, in int digits, in MidpointRounding mode) => Math.Round(x._value, digits, mode);
            cdouble IMath<cdouble>.Round(in cdouble x, in MidpointRounding mode) => Math.Round(x._value, mode);
            cdouble IMath<cdouble>.Sin(in cdouble x) => Math.Sin(x._value);
            cdouble IMath<cdouble>.Sinh(in cdouble x) => Math.Sinh(x._value);
            cdouble IMath<cdouble>.Sqrt(in cdouble x) => Math.Sqrt(x._value);
            cdouble IMath<cdouble>.Subtract(in cdouble x, in cdouble y) => x - y;
            cdouble IMath<cdouble>.Tan(in cdouble x) => Math.Tan(x._value);
            cdouble IMath<cdouble>.Tanh(in cdouble x) => Math.Tanh(x._value);
            cdouble IMath<cdouble>.Truncate(in cdouble x) => Math.Truncate(x._value);
            cdouble IMath<cdouble>.TurnsToDegrees(in cdouble x) => x._value * AngleConstants.DegreesPerTurn;
            cdouble IMath<cdouble>.TurnsToRadians(in cdouble x) => x._value * AngleConstants.RadiansPerTurn;
            double IMath<cdouble>.ToDouble(in cdouble x, in double offset) => CheckedArithmetic.Add(x._value, offset);
            float IMath<cdouble>.ToSingle(in cdouble x, in float offset) => CheckedArithmetic.Add((float)x, offset);
            int IMath<cdouble>.Sign(in cdouble x) => Math.Sign(x._value);

            cdouble IBitConverter<cdouble>.Read(in IReadOnlyStream<byte> stream) => BitConverter.ToDouble(stream.Read(sizeof(double)));
            void IBitConverter<cdouble>.Write(cdouble value, in IWriteOnlyStream<byte> stream) => stream.Write(BitConverter.GetBytes(value._value));

            cdouble IRandom<cdouble>.GetNext(Random random) => random.NextDouble(double.MinValue, double.MaxValue);
            cdouble IRandom<cdouble>.GetNext(Random random, in cdouble bound1, in cdouble bound2) => random.NextDouble(bound1._value, bound2._value);

            cdouble IStringParser<cdouble>.Parse(in string s) => Parse(s);
            cdouble IStringParser<cdouble>.Parse(in string s, in NumberStyles numberStyles, in IFormatProvider formatProvider) => Parse(s, numberStyles, formatProvider);
        }
    }
}
