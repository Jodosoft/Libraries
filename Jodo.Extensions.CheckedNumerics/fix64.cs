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
    public readonly struct fix64 : INumeric<fix64>, IComparable<fix64>, IEquatable<fix64>, IFormattable, IComparable, ISerializable
    {
        public static readonly fix64 E = new fix64(Checked.ToInt64(Math.E * ScalingFactor));
        public static readonly fix64 Epsilon = new fix64(1);
        public static readonly fix64 MaxValue = new fix64(long.MaxValue);
        public static readonly fix64 MinValue = new fix64(long.MinValue);
        public static readonly fix64 MaxUnit = new fix64(ScalingFactor);
        public static readonly fix64 MinUnit = new fix64(-ScalingFactor);
        public static readonly fix64 One = new fix64(ScalingFactor);
        public static readonly fix64 Pi = new fix64(Checked.ToInt64(Math.PI * ScalingFactor));
        public static readonly fix64 Zero = new fix64(0);

        private const long ScalingFactor = 1 << 24;
        private const long MantissaMask = ScalingFactor - 1;

        private readonly long _scaledValue;

        private readonly double ConversionValue => (double)_scaledValue / ScalingFactor;

        private fix64(long scaledValue)
        {
            _scaledValue = scaledValue;
        }

        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext _) => info.AddValue(nameof(fix64), _scaledValue);
        private fix64(SerializationInfo info, StreamingContext _) : this(info.GetInt64(nameof(fix64))) { }

        public bool Equals(fix64 other) => _scaledValue == other._scaledValue;
        public bool TryFormat(Span<char> destination, out int charsWritten, ReadOnlySpan<char> format = default, IFormatProvider? provider = null) => ConversionValue.TryFormat(destination, out charsWritten, format, provider);
        public float Approximate(float offset) => (float)((double)(_scaledValue + (offset * ScalingFactor)) / ScalingFactor);
        public int CompareTo(fix64 other) => _scaledValue.CompareTo(other._scaledValue);
        public int CompareTo(object value) => value == null ? 1 : (value is fix64 other) ? CompareTo(other) : throw new ArgumentException($"Object must be of type {nameof(fix64)}.");
        public override bool Equals(object? obj) => obj is fix64 other && _scaledValue == other._scaledValue;
        public override int GetHashCode() => _scaledValue.GetHashCode();
        public override string ToString() => ConversionValue.ToString();
        public string ToString(string format, IFormatProvider formatProvider) => ConversionValue.ToString(format, formatProvider);

        fix64 INumeric<fix64>.E => E;
        fix64 INumeric<fix64>.Epsilon => Epsilon;
        fix64 INumeric<fix64>.MaxValue => MaxValue;
        fix64 INumeric<fix64>.MinValue => MinValue;
        fix64 INumeric<fix64>.MaxUnit => MaxUnit;
        fix64 INumeric<fix64>.MinUnit => MinUnit;
        fix64 INumeric<fix64>.One => One;
        fix64 INumeric<fix64>.Pi => Pi;
        bool INumeric<fix64>.GreaterThan(fix64 value2) => _scaledValue > value2._scaledValue;
        bool INumeric<fix64>.GreaterThanOrEqualTo(fix64 value2) => _scaledValue >= value2._scaledValue;
        bool INumeric<fix64>.LessThan(fix64 value2) => _scaledValue < value2._scaledValue;
        bool INumeric<fix64>.LessThanOrEqualTo(fix64 value2) => _scaledValue <= value2._scaledValue;
        fix64 INumeric<fix64>.Abs() => _scaledValue >= 0 ? this : new fix64(-_scaledValue);
        fix64 INumeric<fix64>.Acos() => new fix64(Checked.ToInt64(Math.Acos(ConversionValue) * ScalingFactor));
        fix64 INumeric<fix64>.Acosh() => new fix64(Checked.ToInt64(Math.Acosh(ConversionValue) * ScalingFactor));
        fix64 INumeric<fix64>.Addition(fix64 value2) => this + value2;
        fix64 INumeric<fix64>.Asin() => new fix64(Checked.ToInt64(Math.Asin(ConversionValue) * ScalingFactor));
        fix64 INumeric<fix64>.Asinh() => new fix64(Checked.ToInt64(Math.Asinh(ConversionValue) * ScalingFactor));
        fix64 INumeric<fix64>.Atan() => new fix64(Checked.ToInt64(Math.Atan(ConversionValue) * ScalingFactor));
        fix64 INumeric<fix64>.Atan2(fix64 x) => new fix64(Checked.ToInt64(Math.Atan2(ConversionValue, x.ConversionValue) * ScalingFactor));
        fix64 INumeric<fix64>.Atanh() => new fix64(Checked.ToInt64(Math.Atanh(ConversionValue) * ScalingFactor));
        fix64 INumeric<fix64>.Cbrt() => new fix64(Checked.ToInt64(Math.Cbrt(ConversionValue) * ScalingFactor));
        fix64 INumeric<fix64>.Ceiling() => new fix64(Checked.ToInt64(Math.Ceiling(ConversionValue) * ScalingFactor));
        fix64 INumeric<fix64>.Cos() => new fix64(Checked.ToInt64(Math.Cos(ConversionValue) * ScalingFactor));
        fix64 INumeric<fix64>.Cosh() => new fix64(Checked.ToInt64(Math.Cosh(ConversionValue) * ScalingFactor));
        fix64 INumeric<fix64>.DegreesToRadians() => new fix64(Checked.ToInt64(Checked.DegreesToRadians(ConversionValue) * ScalingFactor));
        fix64 INumeric<fix64>.DegreesToTurns() => new fix64(Checked.ToInt64(Checked.DegreesToTurns(ConversionValue) * ScalingFactor));
        fix64 INumeric<fix64>.Divide(fix64 value2) => this / value2;
        fix64 INumeric<fix64>.Exp() => new fix64(Checked.ToInt64(Math.Exp(ConversionValue) * ScalingFactor));
        fix64 INumeric<fix64>.Floor() => new fix64(Checked.ToInt64(Math.Floor(ConversionValue) * ScalingFactor));
        fix64 INumeric<fix64>.Log() => new fix64(Checked.ToInt64(Math.Log(ConversionValue) * ScalingFactor));
        fix64 INumeric<fix64>.Log(fix64 y) => new fix64(Checked.ToInt64(Math.Log(ConversionValue, y.ConversionValue) * ScalingFactor));
        fix64 INumeric<fix64>.Log10() => new fix64(Checked.ToInt64(Math.Log10(ConversionValue) * ScalingFactor));
        fix64 INumeric<fix64>.Max(fix64 y) => _scaledValue > y._scaledValue ? this : y;
        fix64 INumeric<fix64>.Min(fix64 y) => _scaledValue < y._scaledValue ? this : y;
        fix64 INumeric<fix64>.Negative() => -this;
        fix64 INumeric<fix64>.Multiply(fix64 value2) => this * value2;
        fix64 INumeric<fix64>.Positive() => this;
        fix64 INumeric<fix64>.Pow(fix64 y) => new fix64(Checked.ToInt64(Math.Pow(ConversionValue, y.ConversionValue) * ScalingFactor));
        fix64 INumeric<fix64>.RadiansToDegrees() => new fix64(Checked.ToInt64(Checked.RadiansToDegrees(ConversionValue) * ScalingFactor));
        fix64 INumeric<fix64>.RadiansToTurns() => new fix64(Checked.ToInt64(Checked.RadiansToTurns(ConversionValue) * ScalingFactor));
        fix64 INumeric<fix64>.Remainder(fix64 value2) => this % value2;
        fix64 INumeric<fix64>.Round() => new fix64(Checked.ToInt64(Math.Round(ConversionValue) * ScalingFactor));
        fix64 INumeric<fix64>.Round(byte digits) => new fix64(Checked.ToInt64(Math.Round(ConversionValue, digits) * ScalingFactor));
        fix64 INumeric<fix64>.Round(byte digits, MidpointRounding mode) => new fix64(Checked.ToInt64(Math.Round(ConversionValue, digits, mode) * ScalingFactor));
        fix64 INumeric<fix64>.Round(MidpointRounding mode) => new fix64(Checked.ToInt64(Math.Round(ConversionValue, mode) * ScalingFactor));
        fix64 INumeric<fix64>.Sin() => new fix64(Checked.ToInt64(Math.Sin(ConversionValue) * ScalingFactor));
        fix64 INumeric<fix64>.Sinh() => new fix64(Checked.ToInt64(Math.Sinh(ConversionValue) * ScalingFactor));
        fix64 INumeric<fix64>.Sqrt() => new fix64(Checked.ToInt64(Math.Sqrt(ConversionValue) * ScalingFactor));
        fix64 INumeric<fix64>.Subtract(fix64 value2) => this - value2;
        fix64 INumeric<fix64>.Tan() => new fix64(Checked.ToInt64(Math.Tan(ConversionValue) * ScalingFactor));
        fix64 INumeric<fix64>.Tanh() => new fix64(Checked.ToInt64(Math.Tanh(ConversionValue) * ScalingFactor));
        fix64 INumeric<fix64>.TurnsToDegrees() => new fix64(Checked.ToInt64(Checked.TurnsToDegrees(ConversionValue) * ScalingFactor));
        fix64 INumeric<fix64>.TurnsToRadians() => new fix64(Checked.ToInt64(Checked.TurnsToRadians(ConversionValue) * ScalingFactor));
        fix64 INumeric<fix64>.Convert(byte value) => new fix64(value * ScalingFactor);
        fix64 INumeric<fix64>.Parse(string s) => Parse(s);
        fix64 INumeric<fix64>.Parse(string s, IFormatProvider provider) => Parse(s, provider);
        fix64 INumeric<fix64>.Parse(string s, NumberStyles style) => Parse(s, style);
        fix64 INumeric<fix64>.Parse(string s, NumberStyles style, IFormatProvider provider) => Parse(s, style, provider);

        fix64 INumeric<fix64>.Next(Random random, fix64 minInclusive, fix64 maxInclusive)
        {
            if (minInclusive > maxInclusive) throw new ArgumentOutOfRangeException(nameof(minInclusive), minInclusive, $"{nameof(minInclusive)}' cannot be greater than {nameof(maxInclusive)}");
            if (minInclusive == maxInclusive) return minInclusive;
            return FromInternalRepresentation(random.NextInt64(
                    GetInternalRepresentation(minInclusive),
                    GetInternalRepresentation(maxInclusive)));
        }

        public static bool TryParse(string s, IFormatProvider provider, out fix64 result) => Try.Function(Parse, s, provider, out result);
        public static bool TryParse(string s, NumberStyles style, IFormatProvider provider, out fix64 result) => Try.Function(Parse, s, style, provider, out result);
        public static bool TryParse(string s, NumberStyles style, out fix64 result) => Try.Function(Parse, s, style, out result);
        public static bool TryParse(string s, out fix64 result) => Try.Function(Parse, s, out result);
        public static byte[] GetBytes(fix64 value) => BitConverter.GetBytes(value._scaledValue);
        public static fix64 FromBytes(byte[] bytes) => new fix64(BitConverter.ToInt64(bytes));
        public static fix64 FromBytes(ReadOnlySpan<byte> bytes) => new fix64(BitConverter.ToInt64(bytes));
        public static fix64 FromInternalRepresentation(long value) => new fix64(value);
        public static fix64 Parse(string s) => new fix64(Checked.ToInt64(double.Parse(s) * ScalingFactor));
        public static fix64 Parse(string s, IFormatProvider provider) => new fix64(Checked.ToInt64(double.Parse(s, provider) * ScalingFactor));
        public static fix64 Parse(string s, NumberStyles style) => new fix64(Checked.ToInt64(double.Parse(s, style) * ScalingFactor));
        public static fix64 Parse(string s, NumberStyles style, IFormatProvider provider) => new fix64(Checked.ToInt64(double.Parse(s, style, provider) * ScalingFactor));
        public static long GetInternalRepresentation(fix64 value) => value._scaledValue;

        public static explicit operator fix64(decimal value) => new fix64(Checked.ToInt64(value * ScalingFactor));
        public static explicit operator fix64(double value) => new fix64(Checked.ToInt64(value * ScalingFactor));
        public static explicit operator fix64(long value) => new fix64(value * ScalingFactor);
        public static explicit operator fix64(ufix64 value) => new fix64((long)ufix64.GetInternalRepresentation(value));
        public static explicit operator fix64(ulong value) => new fix64(Checked.ToInt64(value * ScalingFactor));
        public static implicit operator fix64(byte value) => new fix64(value * ScalingFactor);
        public static implicit operator fix64(cfloat value) => new fix64(Checked.ToInt64(value * ScalingFactor));
        public static implicit operator fix64(cint value) => new fix64((int)value * ScalingFactor);
        public static implicit operator fix64(float value) => new fix64(Checked.ToInt64(value * ScalingFactor));
        public static implicit operator fix64(int value) => new fix64(value * ScalingFactor);
        public static implicit operator fix64(short value) => new fix64(value * ScalingFactor);
        public static implicit operator fix64(ucint value) => new fix64(value * ScalingFactor);
        public static implicit operator fix64(uint value) => new fix64(value * ScalingFactor);
        public static implicit operator fix64(ushort value) => new fix64(value * ScalingFactor);

        public static explicit operator byte(fix64 value) => (byte)value.ConversionValue;
        public static explicit operator decimal(fix64 value) => (decimal)value.ConversionValue;
        public static explicit operator double(fix64 value) => value.ConversionValue;
        public static explicit operator float(fix64 value) => (float)value.ConversionValue;
        public static explicit operator int(fix64 value) => (int)value.ConversionValue;
        public static explicit operator long(fix64 value) => (long)value.ConversionValue;
        public static explicit operator short(fix64 value) => (short)value.ConversionValue;
        public static explicit operator uint(fix64 value) => (uint)value.ConversionValue;
        public static explicit operator ulong(fix64 value) => (ulong)value.ConversionValue;
        public static explicit operator ushort(fix64 value) => (ushort)value.ConversionValue;

        public static bool operator !=(fix64 left, fix64 right) => left._scaledValue != right._scaledValue;
        public static bool operator <(fix64 left, fix64 right) => left._scaledValue < right._scaledValue;
        public static bool operator <=(fix64 left, fix64 right) => left._scaledValue <= right._scaledValue;
        public static bool operator ==(fix64 left, fix64 right) => left._scaledValue == right._scaledValue;
        public static bool operator >(fix64 left, fix64 right) => left._scaledValue > right._scaledValue;
        public static bool operator >=(fix64 left, fix64 right) => left._scaledValue >= right._scaledValue;
        public static fix64 operator %(fix64 left, fix64 right) => new fix64(Checked.ToInt64((left.ConversionValue % right.ConversionValue) * ScalingFactor));
        public static fix64 operator &(fix64 left, fix64 right) => new fix64(left._scaledValue & right._scaledValue);
        public static fix64 operator -(fix64 left, fix64 right) => new fix64(Checked.Subtract(left._scaledValue, right._scaledValue));
        public static fix64 operator --(fix64 value) => new fix64(value._scaledValue - ScalingFactor);
        public static fix64 operator -(fix64 value) => new fix64(-value._scaledValue);
        public static fix64 operator *(fix64 left, fix64 right) => new fix64(Checked.ToInt64(left.ConversionValue * right.ConversionValue * ScalingFactor));
        public static fix64 operator /(fix64 left, fix64 right) => new fix64(Checked.ToInt64(Checked.Divide(left.ConversionValue, right.ConversionValue) * ScalingFactor));
        public static fix64 operator ^(fix64 left, fix64 right) => new fix64(left._scaledValue ^ right._scaledValue);
        public static fix64 operator |(fix64 left, fix64 right) => new fix64(left._scaledValue | right._scaledValue);
        public static fix64 operator ~(fix64 value) => new fix64(~value._scaledValue);
        public static fix64 operator +(fix64 left, fix64 right) => new fix64(Checked.Add(left._scaledValue, right._scaledValue));
        public static fix64 operator +(fix64 value) => value;
        public static fix64 operator ++(fix64 value) => new fix64(value._scaledValue + ScalingFactor);
        public static fix64 operator <<(fix64 left, int right) => new fix64(left._scaledValue << right);
        public static fix64 operator >>(fix64 left, int right) => new fix64(left._scaledValue >> right);
    }
}
