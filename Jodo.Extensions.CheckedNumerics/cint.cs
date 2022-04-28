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

using Jodo.Extensions.CheckedNumerics.Internals;
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
    public readonly struct cint : INumeric<cint>, IComparable<cint>, IEquatable<cint>, IFormattable, IComparable, ISerializable
    {
        public static readonly cint E = new cint((int)Math.E);
        public static readonly cint Epsilon = new cint(1);
        public static readonly cint MaxUnit = new cint(1);
        public static readonly cint MaxValue = new cint(int.MaxValue);
        public static readonly cint MinUnit = new cint(-1);
        public static readonly cint MinValue = new cint(int.MinValue);
        public static readonly cint One = new cint(1);
        public static readonly cint Pi = new cint((int)Math.PI);
        public static readonly cint Zero = new cint(0);

        private readonly int _value;

        private cint(int value)
        {
            _value = value;
        }

        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext _) => info.AddValue(nameof(cint), _value);
        private cint(SerializationInfo info, StreamingContext _) : this(info.GetInt32(nameof(cint))) { }

        public bool Equals(cint other) => _value == other._value;
        public bool TryFormat(Span<char> destination, out int charsWritten, ReadOnlySpan<char> format = default, IFormatProvider? provider = null) => _value.TryFormat(destination, out charsWritten, format, provider);
        public float Approximate(float offset) => _value + offset;
        public int CompareTo(cint other) => _value.CompareTo(other._value);
        public int CompareTo(object value) => value == null ? 1 : (value is cint other) ? CompareTo(other) : throw new ArgumentException($"Object must be of type {nameof(cint)}.");
        public override bool Equals(object? obj) => obj is cint other && _value == other._value;
        public override int GetHashCode() => _value.GetHashCode();
        public override string ToString() => _value.ToString();
        public string ToString(string format, IFormatProvider formatProvider) => _value.ToString(format, formatProvider);

        cint INumeric<cint>.E => E;
        cint INumeric<cint>.Epsilon => Epsilon;
        cint INumeric<cint>.MaxUnit => MaxUnit;
        cint INumeric<cint>.MaxValue => MaxValue;
        cint INumeric<cint>.MinUnit => MinUnit;
        cint INumeric<cint>.MinValue => MinValue;
        cint INumeric<cint>.One => One;
        cint INumeric<cint>.Pi => Pi;
        bool INumeric<cint>.GreaterThan(cint value2) => this > value2;
        bool INumeric<cint>.GreaterThanOrEqualTo(cint value2) => this >= value2;
        bool INumeric<cint>.SmallerThan(cint value2) => this < value2;
        bool INumeric<cint>.SmallerThanOrEqualTo(cint value2) => this <= value2;
        cint INumeric<cint>.Abs() => new cint(Math.Abs(_value));
        cint INumeric<cint>.Acos() => new cint((int)Math.Acos(_value));
        cint INumeric<cint>.Acosh() => new cint((int)Math.Acosh(_value));
        cint INumeric<cint>.Addition(cint value2) => this + value2;
        cint INumeric<cint>.Asin() => new cint((int)Math.Asin(_value));
        cint INumeric<cint>.Asinh() => new cint((int)Math.Asinh(_value));
        cint INumeric<cint>.Atan() => new cint((int)Math.Atan(_value));
        cint INumeric<cint>.Atan2(cint x) => new cint((int)Math.Atan2(_value, x));
        cint INumeric<cint>.Atanh() => new cint((int)Math.Atanh(_value));
        cint INumeric<cint>.Cbrt() => new cint((int)Math.Cbrt(_value));
        cint INumeric<cint>.Ceiling() => this;
        cint INumeric<cint>.Convert(byte value) => new cint(value);
        cint INumeric<cint>.Cos() => new cint((int)Math.Cos(_value));
        cint INumeric<cint>.Cosh() => new cint((int)Math.Cosh(_value));
        cint INumeric<cint>.DegreesToRadians() => new cint((int)Checked.DegreesToRadians(this));
        cint INumeric<cint>.DegreesToTurns() => new cint((int)Checked.DegreesToTurns(this));
        cint INumeric<cint>.Divide(cint value2) => this / value2;
        cint INumeric<cint>.Exp() => new cint((int)Math.Exp(_value));
        cint INumeric<cint>.Floor() => this;
        cint INumeric<cint>.Log() => new cint((int)Math.Log(_value));
        cint INumeric<cint>.Log(cint newBase) => new cint((int)Math.Log(_value, newBase));
        cint INumeric<cint>.Log10() => new cint((int)Math.Log10(_value));
        cint INumeric<cint>.Max(cint y) => new cint(Math.Max(_value, y));
        cint INumeric<cint>.Min(cint y) => new cint(Math.Min(_value, y));
        cint INumeric<cint>.Multiply(cint value2) => this * value2;
        cint INumeric<cint>.Negative() => -this;
        cint INumeric<cint>.Parse(string s) => new cint(int.Parse(s));
        cint INumeric<cint>.Parse(string s, IFormatProvider provider) => new cint(int.Parse(s, provider));
        cint INumeric<cint>.Parse(string s, NumberStyles style) => new cint(int.Parse(s, style));
        cint INumeric<cint>.Parse(string s, NumberStyles style, IFormatProvider provider) => new cint(int.Parse(s, style, provider));
        cint INumeric<cint>.Positive() => this;
        cint INumeric<cint>.Pow(cint value2) => new cint(Checked.Pow(_value, value2._value));
        cint INumeric<cint>.RadiansToDegrees() => new cint((int)Checked.RadiansToDegrees(this));
        cint INumeric<cint>.RadiansToTurns() => new cint((int)Checked.RadiansToTurns(this));
        cint INumeric<cint>.Remainder(cint value2) => this % value2;
        cint INumeric<cint>.Round() => this;
        cint INumeric<cint>.Round(byte digits) => this;
        cint INumeric<cint>.Round(byte digits, MidpointRounding mode) => this;
        cint INumeric<cint>.Round(MidpointRounding mode) => this;
        cint INumeric<cint>.Sin() => new cint((int)Math.Sin(_value));
        cint INumeric<cint>.Sinh() => new cint((int)Math.Sinh(_value));
        cint INumeric<cint>.Sqrt() => new cint((int)Math.Sqrt(_value));
        cint INumeric<cint>.Subtract(cint value2) => this - value2;
        cint INumeric<cint>.Tan() => new cint((int)Math.Tan(_value));
        cint INumeric<cint>.Tanh() => new cint((int)Math.Tanh(_value));
        cint INumeric<cint>.TurnsToDegrees() => new cint((int)Checked.TurnsToDegrees(this));
        cint INumeric<cint>.TurnsToRadians() => new cint((int)Checked.TurnsToRadians(this));
        cint INumeric<cint>.Next(Random random, cint minInclusive, cint maxInclusive) => new cint(random.NextInt32(minInclusive, maxInclusive));

        public static explicit operator cint(cfloat value) => new cint((int)value);
        public static explicit operator cint(decimal value) => new cint((int)value);
        public static explicit operator cint(double value) => new cint((int)value);
        public static explicit operator cint(fix64 value) => new cint((int)value);
        public static explicit operator cint(float value) => new cint((int)value);
        public static explicit operator cint(long value) => new cint((int)value);
        public static explicit operator cint(ufix64 value) => new cint((int)value);
        public static explicit operator cint(uint value) => new cint((int)value);
        public static explicit operator cint(ulong value) => new cint((int)value);
        public static implicit operator cint(byte value) => new cint(value);
        public static implicit operator cint(int value) => new cint(value);
        public static implicit operator cint(short value) => new cint(value);
        public static implicit operator cint(ushort value) => new cint(value);

        public static explicit operator byte(cint value) => (byte)value._value;
        public static explicit operator short(cint value) => (short)value._value;
        public static explicit operator uint(cint value) => (uint)value._value;
        public static explicit operator ulong(cint value) => (ulong)value._value;
        public static explicit operator ushort(cint value) => (ushort)value._value;
        public static implicit operator decimal(cint value) => value._value;
        public static implicit operator double(cint value) => value._value;
        public static implicit operator float(cint value) => value._value;
        public static implicit operator int(cint value) => value._value;
        public static implicit operator long(cint value) => value._value;

        public static bool operator !=(cint left, cint right) => left._value != right._value;
        public static bool operator <(cint left, cint right) => left._value < right._value;
        public static bool operator <=(cint left, cint right) => left._value <= right._value;
        public static bool operator ==(cint left, cint right) => left._value == right._value;
        public static bool operator >(cint left, cint right) => left._value > right._value;
        public static bool operator >=(cint left, cint right) => left._value >= right._value;
        public static cint operator %(cint left, cint right) => new cint(left._value % right._value);
        public static cint operator &(cint left, cint right) => new cint(left._value & right._value);
        public static cint operator -(cint left, cint right) => new cint(Checked.Subtract(left._value, right._value));
        public static cint operator --(cint value) => new cint(Checked.Subtract(value._value, 1));
        public static cint operator -(cint value) => new cint(-value._value);
        public static cint operator *(cint left, cint right) => new cint(Checked.Multiply(left._value, right._value));
        public static cint operator /(cint left, cint right) => new cint(Checked.Divide(left._value, right._value));
        public static cint operator ^(cint left, cint right) => new cint(left._value ^ right._value);
        public static cint operator |(cint left, cint right) => new cint(left._value | right._value);
        public static cint operator ~(cint value) => new cint(~value._value);
        public static cint operator +(cint left, cint right) => new cint(Checked.Add(left._value, right._value));
        public static cint operator +(cint value) => value;
        public static cint operator ++(cint value) => new cint(Checked.Add(value._value, 1));
        public static cint operator <<(cint left, int right) => new cint(left._value << right);
        public static cint operator >>(cint left, int right) => new cint(left._value >> right);
    }
}
