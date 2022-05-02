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

namespace Jodo.Extensions.CheckedNumerics
{
    [Serializable]
    [SuppressMessage("Style", "IDE1006:Naming Styles")]
    [DebuggerDisplay("{ToString(),nq}")]
    public readonly struct cdouble : INumeric<cdouble>
    {
        public static readonly cdouble E = new cdouble(Math.E);
        public static readonly cdouble Epsilon = new cdouble(double.Epsilon);
        public static readonly cdouble MaxValue = new cdouble(double.MaxValue);
        public static readonly cdouble MinValue = new cdouble(double.MinValue);
        public static readonly cdouble MaxUnit = new cdouble(1);
        public static readonly cdouble MinUnit = new cdouble(-1);
        public static readonly cdouble One = new cdouble(1);
        public static readonly cdouble Pi = new cdouble(Math.PI);
        public static readonly cdouble Zero = new cdouble(0);

        private readonly double _value;

        public cdouble(double value)
        {
            _value =
                value == double.NaN ? 0 :
                value < double.MinValue ? double.MinValue :
                value > double.MaxValue ? double.MaxValue :
                value;
        }

        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext _) => info.AddValue(nameof(cdouble), _value);
        private cdouble(SerializationInfo info, StreamingContext _) : this(info.GetDouble(nameof(cdouble))) { }

        public bool Equals(cdouble other) => _value == other._value;
        public bool TryFormat(Span<char> destination, out int charsWritten, ReadOnlySpan<char> format = default, IFormatProvider? provider = null) => _value.TryFormat(destination, out charsWritten, format, provider);
        public float Approximate(float offset) => (float)_value + offset;
        public int CompareTo(cdouble other) => _value.CompareTo(other._value);
        public int CompareTo(object value) => value == null ? 1 : (value is cdouble other) ? CompareTo(other) : throw new ArgumentException($"Object must be of type {nameof(cdouble)}.");
        public override int GetHashCode() => _value.GetHashCode();
        public override string ToString() => _value.ToString();
        public string ToString(string format, IFormatProvider formatProvider) => _value.ToString(format, formatProvider);

        public override bool Equals(object? obj)
        {
            if (obj == null) return false;
            try
            {
                var other = (cdouble)obj;
                return Equals(other);
            }
            catch (InvalidCastException)
            {
                return false;
            }
        }

        cdouble INumeric<cdouble>.Value => this;
        cdouble INumeric<cdouble>.E => E;
        cdouble INumeric<cdouble>.Epsilon => Epsilon;
        cdouble INumeric<cdouble>.MaxUnit => MaxUnit;
        cdouble INumeric<cdouble>.MaxValue => MaxValue;
        cdouble INumeric<cdouble>.MinUnit => MinUnit;
        cdouble INumeric<cdouble>.MinValue => MinValue;
        cdouble INumeric<cdouble>.Zero => Zero;
        cdouble INumeric<cdouble>.One => One;
        cdouble INumeric<cdouble>.Pi => Pi;
        bool INumeric<cdouble>.HasMantissa => true;
        bool INumeric<cdouble>.IsSigned => true;
        bool INumeric<cdouble>.GreaterThan(cdouble value2) => this > value2;
        bool INumeric<cdouble>.GreaterThanOrEqualTo(cdouble value2) => this >= value2;
        bool INumeric<cdouble>.LessThan(cdouble value2) => this < value2;
        bool INumeric<cdouble>.LessThanOrEqualTo(cdouble value2) => this <= value2;
        cdouble INumeric<cdouble>.Abs() => new cdouble(Math.Abs(_value));
        cdouble INumeric<cdouble>.Acos() => new cdouble(Math.Acos(_value));
        cdouble INumeric<cdouble>.Acosh() => new cdouble(Math.Acosh(_value));
        cdouble INumeric<cdouble>.Addition(cdouble value2) => this + value2;
        cdouble INumeric<cdouble>.Asin() => new cdouble(Math.Asin(_value));
        cdouble INumeric<cdouble>.Asinh() => new cdouble(Math.Asinh(_value));
        cdouble INumeric<cdouble>.Atan() => new cdouble(Math.Atan(_value));
        cdouble INumeric<cdouble>.Atan2(cdouble x) => new cdouble(Math.Atan2(_value, x._value));
        cdouble INumeric<cdouble>.Atanh() => new cdouble(Math.Atanh(_value));
        cdouble INumeric<cdouble>.Cbrt() => new cdouble(Math.Cbrt(_value));
        cdouble INumeric<cdouble>.Ceiling() => new cdouble(Math.Ceiling(_value));
        cdouble INumeric<cdouble>.Convert(byte value) => new cdouble(value);
        cdouble INumeric<cdouble>.Cos() => new cdouble(Math.Cos(_value));
        cdouble INumeric<cdouble>.Cosh() => new cdouble(Math.Cosh(_value));
        cdouble INumeric<cdouble>.DegreesToRadians() => new cdouble(CheckedMath.DegreesToRadians(_value));
        cdouble INumeric<cdouble>.DegreesToTurns() => new cdouble(CheckedMath.DegreesToTurns(_value));
        cdouble INumeric<cdouble>.Divide(cdouble value2) => this / value2;
        cdouble INumeric<cdouble>.Exp() => new cdouble(Math.Exp(_value));
        cdouble INumeric<cdouble>.Floor() => new cdouble(Math.Floor(_value));
        cdouble INumeric<cdouble>.Log() => new cdouble(Math.Log(_value));
        cdouble INumeric<cdouble>.Log(cdouble newBase) => new cdouble(Math.Log(_value, newBase._value));
        cdouble INumeric<cdouble>.Log10() => new cdouble(Math.Log10(_value));
        cdouble INumeric<cdouble>.Max(cdouble y) => new cdouble(Math.Max(_value, y._value));
        cdouble INumeric<cdouble>.Min(cdouble y) => new cdouble(Math.Min(_value, y._value));
        cdouble INumeric<cdouble>.Multiply(cdouble value2) => this * value2;
        cdouble INumeric<cdouble>.Negative() => -this;
        cdouble INumeric<cdouble>.Positive() => this;
        cdouble INumeric<cdouble>.Pow(cdouble value2) => new cdouble(Math.Pow(_value, value2._value));
        cdouble INumeric<cdouble>.RadiansToDegrees() => new cdouble(CheckedMath.RadiansToDegrees(_value));
        cdouble INumeric<cdouble>.RadiansToTurns() => new cdouble(CheckedMath.RadiansToTurns(_value));
        cdouble INumeric<cdouble>.Remainder(cdouble value2) => this % value2;
        cdouble INumeric<cdouble>.Round() => new cdouble(Math.Round(_value));
        cdouble INumeric<cdouble>.Round(byte digits) => new cdouble(Math.Round(_value, digits));
        cdouble INumeric<cdouble>.Round(byte digits, MidpointRounding mode) => new cdouble(Math.Round(_value, digits, mode));
        cdouble INumeric<cdouble>.Round(MidpointRounding mode) => new cdouble(Math.Round(_value, mode));
        cdouble INumeric<cdouble>.Sin() => new cdouble(Math.Sin(_value));
        cdouble INumeric<cdouble>.Sinh() => new cdouble(Math.Sinh(_value));
        cdouble INumeric<cdouble>.Sqrt() => new cdouble(Math.Sqrt(_value));
        cdouble INumeric<cdouble>.Subtract(cdouble value2) => this - value2;
        cdouble INumeric<cdouble>.Tan() => new cdouble(Math.Tan(_value));
        cdouble INumeric<cdouble>.Tanh() => new cdouble(Math.Tanh(_value));
        cdouble INumeric<cdouble>.TurnsToDegrees() => new cdouble(CheckedMath.TurnsToDegrees(_value));
        cdouble INumeric<cdouble>.TurnsToRadians() => new cdouble(CheckedMath.TurnsToRadians(_value));

        int IBitConverter<cdouble>.SizeOfValue => sizeof(double);
        cdouble IBitConverter<cdouble>.FromBytes(in ReadOnlySpan<byte> bytes) => new cdouble(BitConverter.ToDouble(bytes));
        ReadOnlySpan<byte> IBitConverter<cdouble>.GetBytes() => BitConverter.GetBytes(_value);

        cdouble IRandomGenerator<cdouble>.GetNext(Random random) => new cdouble(random.NextDouble(double.MinValue, double.MaxValue));
        cdouble IRandomGenerator<cdouble>.GetNext(Random random, in cdouble bound1, in cdouble bound2) => new cdouble(random.NextDouble(bound1._value, bound2._value));

        cdouble IStringFormatter<cdouble>.Parse(in string s) => new cdouble(double.Parse(s));
        cdouble IStringFormatter<cdouble>.Parse(in string s, in NumberStyles numberStyles, in IFormatProvider formatProvider) => new cdouble(double.Parse(s, numberStyles, formatProvider));

        public static explicit operator cdouble(decimal value) => new cdouble((double)value);
        public static implicit operator cdouble(double value) => new cdouble((double)value);
        public static explicit operator cdouble(fix64 value) => new cdouble((double)value);
        public static explicit operator cdouble(ufix64 value) => new cdouble((double)value);
        public static implicit operator cdouble(byte value) => new cdouble(value);
        public static implicit operator cdouble(cint value) => new cdouble(value);
        public static implicit operator cdouble(float value) => new cdouble(value);
        public static implicit operator cdouble(int value) => new cdouble(value);
        public static implicit operator cdouble(long value) => new cdouble(value);
        public static implicit operator cdouble(short value) => new cdouble(value);
        public static implicit operator cdouble(uint value) => new cdouble(value);
        public static implicit operator cdouble(ucint value) => new cdouble(value);
        public static implicit operator cdouble(ulong value) => new cdouble(value);
        public static implicit operator cdouble(ushort value) => new cdouble(value);

        public static explicit operator byte(cdouble value) => (byte)value._value;
        public static explicit operator decimal(cdouble value) => (decimal)value._value;
        public static explicit operator int(cdouble value) => (int)value._value;
        public static explicit operator long(cdouble value) => (long)value._value;
        public static explicit operator short(cdouble value) => (short)value._value;
        public static explicit operator uint(cdouble value) => (uint)value._value;
        public static explicit operator ulong(cdouble value) => (ulong)value._value;
        public static explicit operator ushort(cdouble value) => (ushort)value._value;
        public static implicit operator double(cdouble value) => value._value;
        public static explicit operator float(cdouble value) => (float)value._value;

        public static bool operator !=(cdouble left, cdouble right) => left._value != right._value;
        public static bool operator <(cdouble left, cdouble right) => left._value < right._value;
        public static bool operator <=(cdouble left, cdouble right) => left._value <= right._value;
        public static bool operator ==(cdouble left, cdouble right) => left._value == right._value;
        public static bool operator >(cdouble left, cdouble right) => left._value > right._value;
        public static bool operator >=(cdouble left, cdouble right) => left._value >= right._value;
        public static cdouble operator %(cdouble left, cdouble right) => new cdouble(left._value % right._value);
        public static cdouble operator -(cdouble left, cdouble right) => new cdouble(CheckedMath.Subtract(left._value, right._value));
        public static cdouble operator --(cdouble value) => new cdouble(CheckedMath.Subtract(value._value, 1));
        public static cdouble operator -(cdouble value) => new cdouble(-value._value);
        public static cdouble operator *(cdouble left, cdouble right) => new cdouble(CheckedMath.Multiply(left._value, right._value));
        public static cdouble operator /(cdouble left, cdouble right) => new cdouble(CheckedMath.Divide(left._value, right._value));
        public static cdouble operator +(cdouble left, cdouble right) => new cdouble(CheckedMath.Add(left._value, right._value));
        public static cdouble operator +(cdouble value) => value;
        public static cdouble operator ++(cdouble value) => new cdouble(CheckedMath.Add(value._value, 1));
    }
}
