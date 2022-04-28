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
    public readonly struct cfloat : INumeric<cfloat>, IComparable<cfloat>, IEquatable<cfloat>, IFormattable, IComparable, ISerializable
    {
        public static readonly cfloat E = new cfloat(MathF.E);
        public static readonly cfloat Epsilon = new cfloat(float.Epsilon);
        public static readonly cfloat MaxValue = new cfloat(float.MaxValue);
        public static readonly cfloat MinValue = new cfloat(float.MinValue);
        public static readonly cfloat MaxUnit = new cfloat(1);
        public static readonly cfloat MinUnit = new cfloat(-1);
        public static readonly cfloat One = new cfloat(1);
        public static readonly cfloat Pi = new cfloat(MathF.PI);
        public static readonly cfloat Zero = new cfloat(0);

        private readonly float _value;

        public cfloat(float value)
        {
            _value =
                value == float.NaN ? 0 :
                value < float.MinValue ? float.MinValue :
                value > float.MaxValue ? float.MaxValue :
                value;
        }

        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext _) => info.AddValue(nameof(cfloat), _value);
        private cfloat(SerializationInfo info, StreamingContext _) : this(info.GetSingle(nameof(cfloat))) { }

        public bool Equals(cfloat other) => _value == other._value;
        public bool TryFormat(Span<char> destination, out int charsWritten, ReadOnlySpan<char> format = default, IFormatProvider? provider = null) => _value.TryFormat(destination, out charsWritten, format, provider);
        public float Approximate(float offset) => _value + offset;
        public int CompareTo(cfloat other) => _value.CompareTo(other._value);
        public int CompareTo(object value) => value == null ? 1 : (value is cfloat other) ? CompareTo(other) : throw new ArgumentException($"Object must be of type {nameof(cfloat)}.");
        public override bool Equals(object? obj) => obj is cfloat other && _value == other._value;
        public override int GetHashCode() => _value.GetHashCode();
        public override string ToString() => _value.ToString();
        public string ToString(string format, IFormatProvider formatProvider) => _value.ToString(format, formatProvider);

        cfloat INumeric<cfloat>.E => E;
        cfloat INumeric<cfloat>.Epsilon => Epsilon;
        cfloat INumeric<cfloat>.MaxUnit => MaxUnit;
        cfloat INumeric<cfloat>.MaxValue => MaxValue;
        cfloat INumeric<cfloat>.MinUnit => MinUnit;
        cfloat INumeric<cfloat>.MinValue => MinValue;
        cfloat INumeric<cfloat>.One => One;
        cfloat INumeric<cfloat>.Pi => Pi;

        bool INumeric<cfloat>.GreaterThan(cfloat value2) => this > value2;
        bool INumeric<cfloat>.GreaterThanOrEqualTo(cfloat value2) => this >= value2;
        bool INumeric<cfloat>.SmallerThan(cfloat value2) => this < value2;
        bool INumeric<cfloat>.SmallerThanOrEqualTo(cfloat value2) => this <= value2;
        cfloat INumeric<cfloat>.Abs() => new cfloat(MathF.Abs(_value));
        cfloat INumeric<cfloat>.Acos() => new cfloat(MathF.Acos(_value));
        cfloat INumeric<cfloat>.Acosh() => new cfloat(MathF.Acosh(_value));
        cfloat INumeric<cfloat>.Addition(cfloat value2) => this + value2;
        cfloat INumeric<cfloat>.Asin() => new cfloat(MathF.Asin(_value));
        cfloat INumeric<cfloat>.Asinh() => new cfloat(MathF.Asinh(_value));
        cfloat INumeric<cfloat>.Atan() => new cfloat(MathF.Atan(_value));
        cfloat INumeric<cfloat>.Atan2(cfloat x) => new cfloat(MathF.Atan2(_value, x._value));
        cfloat INumeric<cfloat>.Atanh() => new cfloat(MathF.Atanh(_value));
        cfloat INumeric<cfloat>.Cbrt() => new cfloat(MathF.Cbrt(_value));
        cfloat INumeric<cfloat>.Ceiling() => new cfloat(MathF.Ceiling(_value));
        cfloat INumeric<cfloat>.Convert(byte value) => new cfloat(value);
        cfloat INumeric<cfloat>.Cos() => new cfloat(MathF.Cos(_value));
        cfloat INumeric<cfloat>.Cosh() => new cfloat(MathF.Cosh(_value));
        cfloat INumeric<cfloat>.DegreesToRadians() => new cfloat(Checked.DegreesToRadians(_value));
        cfloat INumeric<cfloat>.DegreesToTurns() => new cfloat(Checked.DegreesToTurns(_value));
        cfloat INumeric<cfloat>.Divide(cfloat value2) => this / value2;
        cfloat INumeric<cfloat>.Exp() => new cfloat(MathF.Exp(_value));
        cfloat INumeric<cfloat>.Floor() => new cfloat(MathF.Floor(_value));
        cfloat INumeric<cfloat>.Log() => new cfloat(MathF.Log(_value));
        cfloat INumeric<cfloat>.Log(cfloat newBase) => new cfloat(MathF.Log(_value, newBase._value));
        cfloat INumeric<cfloat>.Log10() => new cfloat(MathF.Log10(_value));
        cfloat INumeric<cfloat>.Max(cfloat y) => new cfloat(MathF.Max(_value, y._value));
        cfloat INumeric<cfloat>.Min(cfloat y) => new cfloat(MathF.Min(_value, y._value));
        cfloat INumeric<cfloat>.Multiply(cfloat value2) => this * value2;
        cfloat INumeric<cfloat>.Negative() => -this;
        cfloat INumeric<cfloat>.Next(Random random, cfloat minInclusive, cfloat maxInclusive) => new cfloat(random.NextSingle(minInclusive._value, maxInclusive._value));
        cfloat INumeric<cfloat>.Parse(string s) => new cfloat(float.Parse(s));
        cfloat INumeric<cfloat>.Parse(string s, IFormatProvider provider) => new cfloat(float.Parse(s, provider));
        cfloat INumeric<cfloat>.Parse(string s, NumberStyles style) => new cfloat(float.Parse(s, style));
        cfloat INumeric<cfloat>.Parse(string s, NumberStyles style, IFormatProvider provider) => new cfloat(float.Parse(s, style, provider));
        cfloat INumeric<cfloat>.Positive() => this;
        cfloat INumeric<cfloat>.Pow(cfloat value2) => new cfloat(MathF.Pow(_value, value2._value));
        cfloat INumeric<cfloat>.RadiansToDegrees() => new cfloat(Checked.RadiansToDegrees(_value));
        cfloat INumeric<cfloat>.RadiansToTurns() => new cfloat(Checked.RadiansToTurns(_value));
        cfloat INumeric<cfloat>.Remainder(cfloat value2) => this % value2;
        cfloat INumeric<cfloat>.Round() => new cfloat(MathF.Round(_value));
        cfloat INumeric<cfloat>.Round(byte digits) => new cfloat(MathF.Round(_value, digits));
        cfloat INumeric<cfloat>.Round(byte digits, MidpointRounding mode) => new cfloat(MathF.Round(_value, digits, mode));
        cfloat INumeric<cfloat>.Round(MidpointRounding mode) => new cfloat(MathF.Round(_value, mode));
        cfloat INumeric<cfloat>.Sin() => new cfloat(MathF.Sin(_value));
        cfloat INumeric<cfloat>.Sinh() => new cfloat(MathF.Sinh(_value));
        cfloat INumeric<cfloat>.Sqrt() => new cfloat(MathF.Sqrt(_value));
        cfloat INumeric<cfloat>.Subtract(cfloat value2) => this - value2;
        cfloat INumeric<cfloat>.Tan() => new cfloat(MathF.Tan(_value));
        cfloat INumeric<cfloat>.Tanh() => new cfloat(MathF.Tanh(_value));
        cfloat INumeric<cfloat>.TurnsToDegrees() => new cfloat(Checked.TurnsToDegrees(_value));
        cfloat INumeric<cfloat>.TurnsToRadians() => new cfloat(Checked.TurnsToRadians(_value));

        public static explicit operator cfloat(decimal value) => new cfloat((float)value);
        public static explicit operator cfloat(double value) => new cfloat((float)value);
        public static explicit operator cfloat(fix64 value) => new cfloat((float)value);
        public static explicit operator cfloat(ufix64 value) => new cfloat((float)value);
        public static implicit operator cfloat(byte value) => new cfloat(value);
        public static implicit operator cfloat(cint value) => new cfloat(value);
        public static implicit operator cfloat(float value) => new cfloat(value);
        public static implicit operator cfloat(int value) => new cfloat(value);
        public static implicit operator cfloat(long value) => new cfloat(value);
        public static implicit operator cfloat(short value) => new cfloat(value);
        public static implicit operator cfloat(uint value) => new cfloat(value);
        public static implicit operator cfloat(ucint value) => new cfloat(value);
        public static implicit operator cfloat(ulong value) => new cfloat(value);
        public static implicit operator cfloat(ushort value) => new cfloat(value);

        public static explicit operator byte(cfloat value) => (byte)value._value;
        public static explicit operator decimal(cfloat value) => (decimal)value._value;
        public static explicit operator int(cfloat value) => (int)value._value;
        public static explicit operator long(cfloat value) => (long)value._value;
        public static explicit operator short(cfloat value) => (short)value._value;
        public static explicit operator uint(cfloat value) => (uint)value._value;
        public static explicit operator ulong(cfloat value) => (ulong)value._value;
        public static explicit operator ushort(cfloat value) => (ushort)value._value;
        public static implicit operator double(cfloat value) => value._value;
        public static explicit operator float(cfloat value) => value._value;

        public static bool operator !=(cfloat left, cfloat right) => left._value != right._value;
        public static bool operator <(cfloat left, cfloat right) => left._value < right._value;
        public static bool operator <=(cfloat left, cfloat right) => left._value <= right._value;
        public static bool operator ==(cfloat left, cfloat right) => left._value == right._value;
        public static bool operator >(cfloat left, cfloat right) => left._value > right._value;
        public static bool operator >=(cfloat left, cfloat right) => left._value >= right._value;
        public static cfloat operator %(cfloat left, cfloat right) => new cfloat(left._value % right._value);
        public static cfloat operator -(cfloat left, cfloat right) => new cfloat(Checked.Subtract(left._value, right._value));
        public static cfloat operator --(cfloat value) => new cfloat(Checked.Subtract(value._value, 1));
        public static cfloat operator -(cfloat value) => new cfloat(-value._value);
        public static cfloat operator *(cfloat left, cfloat right) => new cfloat(Checked.Multiply(left._value, right._value));
        public static cfloat operator /(cfloat left, cfloat right) => new cfloat(Checked.Divide(left._value, right._value));
        public static cfloat operator +(cfloat left, cfloat right) => new cfloat(Checked.Add(left._value, right._value));
        public static cfloat operator +(cfloat value) => value;
        public static cfloat operator ++(cfloat value) => new cfloat(Checked.Add(value._value, 1));
    }
}
