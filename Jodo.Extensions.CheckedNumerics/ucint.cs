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
    public readonly struct ucint : INumeric<ucint>, IComparable<ucint>, IEquatable<ucint>, IFormattable, IComparable, ISerializable
    {
        public static readonly ucint E = new ucint((int)Math.E);
        public static readonly ucint Epsilon = new ucint(1);
        public static readonly ucint MaxUnit = new ucint(1);
        public static readonly ucint MaxValue = new ucint(uint.MaxValue);
        public static readonly ucint MinUnit = new ucint(0);
        public static readonly ucint MinValue = new ucint(uint.MinValue);
        public static readonly ucint One = new ucint(1);
        public static readonly ucint Pi = new ucint((int)Math.PI);
        public static readonly ucint Zero = new ucint(0);

        private readonly uint _value;

        private ucint(uint value)
        {
            _value = value;
        }

        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext _) => info.AddValue(nameof(ucint), _value);
        private ucint(SerializationInfo info, StreamingContext _) : this(info.GetUInt32(nameof(ucint))) { }

        public bool Equals(ucint other) => _value == other._value;
        public bool TryFormat(Span<char> destination, out int charsWritten, ReadOnlySpan<char> format = default, IFormatProvider? provider = null) => _value.TryFormat(destination, out charsWritten, format, provider);
        public float Approximate(float offset) => _value + offset;
        public int CompareTo(ucint other) => _value.CompareTo(other._value);
        public int CompareTo(object value) => value == null ? 1 : (value is ucint other) ? CompareTo(other) : throw new ArgumentException($"Object must be of type {nameof(ucint)}.");
        public override bool Equals(object? obj) => obj is ucint other && _value == other._value;
        public override int GetHashCode() => _value.GetHashCode();
        public override string ToString() => _value.ToString();
        public string ToString(string format, IFormatProvider formatProvider) => _value.ToString(format, formatProvider);

        ucint INumeric<ucint>.E => E;
        ucint INumeric<ucint>.Epsilon => Epsilon;
        ucint INumeric<ucint>.MaxUnit => MaxUnit;
        ucint INumeric<ucint>.MaxValue => MaxValue;
        ucint INumeric<ucint>.MinUnit => MinUnit;
        ucint INumeric<ucint>.MinValue => MinValue;
        ucint INumeric<ucint>.One => One;
        ucint INumeric<ucint>.Pi => Pi;
        bool INumeric<ucint>.GreaterThan(ucint value2) => this > value2;
        bool INumeric<ucint>.GreaterThanOrEqualTo(ucint value2) => this >= value2;
        bool INumeric<ucint>.LessThan(ucint value2) => this < value2;
        bool INumeric<ucint>.LessThanOrEqualTo(ucint value2) => this <= value2;
        ucint INumeric<ucint>.Abs() => this;
        ucint INumeric<ucint>.Acos() => new ucint((uint)Math.Acos(_value));
        ucint INumeric<ucint>.Acosh() => new ucint((uint)Math.Acosh(_value));
        ucint INumeric<ucint>.Addition(ucint value2) => this + value2;
        ucint INumeric<ucint>.Asin() => new ucint((uint)Math.Asin(_value));
        ucint INumeric<ucint>.Asinh() => new ucint((uint)Math.Asinh(_value));
        ucint INumeric<ucint>.Atan() => new ucint((uint)Math.Atan(_value));
        ucint INumeric<ucint>.Atan2(ucint x) => new ucint((uint)Math.Atan2(_value, x));
        ucint INumeric<ucint>.Atanh() => new ucint((uint)Math.Atanh(_value));
        ucint INumeric<ucint>.Cbrt() => new ucint((uint)Math.Cbrt(_value));
        ucint INumeric<ucint>.Ceiling() => this;
        ucint INumeric<ucint>.Convert(byte value) => new ucint(value);
        ucint INumeric<ucint>.Cos() => new ucint((uint)Math.Cos(_value));
        ucint INumeric<ucint>.Cosh() => new ucint((uint)Math.Cosh(_value));
        ucint INumeric<ucint>.DegreesToRadians() => new ucint((uint)Checked.DegreesToRadians(this));
        ucint INumeric<ucint>.DegreesToTurns() => new ucint((uint)Checked.DegreesToTurns(this));
        ucint INumeric<ucint>.Divide(ucint value2) => this / value2;
        ucint INumeric<ucint>.Exp() => new ucint((uint)Math.Exp(_value));
        ucint INumeric<ucint>.Floor() => this;
        ucint INumeric<ucint>.Log() => new ucint((uint)Math.Log(_value));
        ucint INumeric<ucint>.Log(ucint newBase) => new ucint((uint)Math.Log(_value, newBase));
        ucint INumeric<ucint>.Log10() => new ucint((uint)Math.Log10(_value));
        ucint INumeric<ucint>.Max(ucint y) => new ucint(Math.Max(_value, y));
        ucint INumeric<ucint>.Min(ucint y) => new ucint(Math.Min(_value, y));
        ucint INumeric<ucint>.Multiply(ucint value2) => this * value2;
        ucint INumeric<ucint>.Negative() => -this;
        ucint INumeric<ucint>.Parse(string s) => new ucint(uint.Parse(s));
        ucint INumeric<ucint>.Parse(string s, IFormatProvider provider) => new ucint(uint.Parse(s, provider));
        ucint INumeric<ucint>.Parse(string s, NumberStyles style) => new ucint(uint.Parse(s, style));
        ucint INumeric<ucint>.Parse(string s, NumberStyles style, IFormatProvider provider) => new ucint(uint.Parse(s, style, provider));
        ucint INumeric<ucint>.Positive() => this;
        ucint INumeric<ucint>.Pow(ucint value2) => new ucint(Checked.Pow(_value, value2._value));
        ucint INumeric<ucint>.RadiansToDegrees() => new ucint((uint)Checked.RadiansToDegrees(this));
        ucint INumeric<ucint>.RadiansToTurns() => new ucint((uint)Checked.RadiansToTurns(this));
        ucint INumeric<ucint>.Remainder(ucint value2) => this % value2;
        ucint INumeric<ucint>.Round() => this;
        ucint INumeric<ucint>.Round(byte digits) => this;
        ucint INumeric<ucint>.Round(byte digits, MidpointRounding mode) => this;
        ucint INumeric<ucint>.Round(MidpointRounding mode) => this;
        ucint INumeric<ucint>.Sin() => new ucint((uint)Math.Sin(_value));
        ucint INumeric<ucint>.Sinh() => new ucint((uint)Math.Sinh(_value));
        ucint INumeric<ucint>.Sqrt() => new ucint((uint)Math.Sqrt(_value));
        ucint INumeric<ucint>.Subtract(ucint value2) => this - value2;
        ucint INumeric<ucint>.Tan() => new ucint((uint)Math.Tan(_value));
        ucint INumeric<ucint>.Tanh() => new ucint((uint)Math.Tanh(_value));
        ucint INumeric<ucint>.TurnsToDegrees() => new ucint((uint)Checked.TurnsToDegrees(this));
        ucint INumeric<ucint>.TurnsToRadians() => new ucint((uint)Checked.TurnsToRadians(this));
        ucint INumeric<ucint>.Next(Random random, ucint minInclusive, ucint maxInclusive) => new ucint(random.NextUInt32(minInclusive, maxInclusive));

        int IBitConverter<ucint>.Size => sizeof(uint);
        ucint IBitConverter<ucint>.FromBytes(ReadOnlySpan<byte> bytes) => new ucint(BitConverter.ToUInt32(bytes));
        ReadOnlySpan<byte> IBitConverter<ucint>.GetBytes() => BitConverter.GetBytes(_value);

        public static explicit operator ucint(cfloat value) => new ucint((uint)value);
        public static explicit operator ucint(decimal value) => new ucint((uint)value);
        public static explicit operator ucint(double value) => new ucint((uint)value);
        public static explicit operator ucint(fix64 value) => new ucint((uint)value);
        public static explicit operator ucint(float value) => new ucint((uint)value);
        public static explicit operator ucint(int value) => new ucint((uint)value);
        public static explicit operator ucint(cint value) => new ucint((uint)value);
        public static explicit operator ucint(long value) => new ucint((uint)value);
        public static explicit operator ucint(short value) => new ucint((uint)value);
        public static explicit operator ucint(ufix64 value) => new ucint((uint)value);
        public static explicit operator ucint(ulong value) => new ucint((uint)value);
        public static implicit operator ucint(byte value) => new ucint(value);
        public static implicit operator ucint(uint value) => new ucint(value);
        public static implicit operator ucint(ushort value) => new ucint(value);

        public static explicit operator byte(ucint value) => (byte)value._value;
        public static explicit operator int(ucint value) => (int)value._value;
        public static explicit operator short(ucint value) => (short)value._value;
        public static explicit operator ushort(ucint value) => (ushort)value._value;
        public static implicit operator decimal(ucint value) => value._value;
        public static implicit operator double(ucint value) => value._value;
        public static implicit operator float(ucint value) => value._value;
        public static implicit operator long(ucint value) => value._value;
        public static implicit operator uint(ucint value) => value._value;
        public static implicit operator ulong(ucint value) => value._value;

        public static bool operator !=(ucint left, ucint right) => left._value != right._value;
        public static bool operator <(ucint left, ucint right) => left._value < right._value;
        public static bool operator <=(ucint left, ucint right) => left._value <= right._value;
        public static bool operator ==(ucint left, ucint right) => left._value == right._value;
        public static bool operator >(ucint left, ucint right) => left._value > right._value;
        public static bool operator >=(ucint left, ucint right) => left._value >= right._value;
        public static ucint operator %(ucint left, ucint right) => new ucint(left._value % right._value);
        public static ucint operator &(ucint left, ucint right) => new ucint(left._value & right._value);
        public static ucint operator -(ucint left, ucint right) => new ucint(Checked.Subtract(left._value, right._value));
        public static ucint operator --(ucint value) => new ucint(Checked.Subtract(value._value, 1));
        public static ucint operator -(ucint _) => MinValue;
        public static ucint operator *(ucint left, ucint right) => new ucint(Checked.Multiply(left._value, right._value));
        public static ucint operator /(ucint left, ucint right) => new ucint(Checked.Divide(left._value, right._value));
        public static ucint operator ^(ucint left, ucint right) => new ucint(left._value ^ right._value);
        public static ucint operator |(ucint left, ucint right) => new ucint(left._value | right._value);
        public static ucint operator ~(ucint value) => new ucint(~value._value);
        public static ucint operator +(ucint left, ucint right) => new ucint(Checked.Add(left._value, right._value));
        public static ucint operator +(ucint value) => value;
        public static ucint operator ++(ucint value) => new ucint(Checked.Add(value._value, 1));
        public static ucint operator <<(ucint left, int right) => new ucint(left._value << right);
        public static ucint operator >>(ucint left, int right) => new ucint(left._value >> right);
    }
}
