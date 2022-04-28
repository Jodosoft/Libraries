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
    public readonly struct ufix64 : INumeric<ufix64>, IComparable<ufix64>, IEquatable<ufix64>, IFormattable, IComparable, ISerializable
    {
        public static readonly ufix64 E = new ufix64(Checked.ToUInt64(Math.E * ScalingFactor));
        public static readonly ufix64 Epsilon = new ufix64(1);
        public static readonly ufix64 MaxValue = new ufix64(ulong.MaxValue);
        public static readonly ufix64 MinValue = new ufix64(ulong.MinValue);
        public static readonly ufix64 MaxUnit = new ufix64(ScalingFactor);
        public static readonly ufix64 MinUnit = new ufix64(0);
        public static readonly ufix64 One = new ufix64(ScalingFactor);
        public static readonly ufix64 Pi = new ufix64(Checked.ToUInt64(Math.PI * ScalingFactor));
        public static readonly ufix64 Zero = new ufix64(0);

        private const ulong ScalingFactor = 0X_FF_FF_FF;

        private readonly ulong _scaledValue;

        private readonly double ConversionValue => (double)_scaledValue / ScalingFactor;

        private ufix64(ulong scaledValue)
        {
            _scaledValue = scaledValue;
        }

        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext _) => info.AddValue(nameof(ufix64), _scaledValue);
        private ufix64(SerializationInfo info, StreamingContext _) : this(info.GetUInt64(nameof(ufix64))) { }

        public bool Equals(ufix64 other) => _scaledValue == other._scaledValue;
        public bool TryFormat(Span<char> destination, out int charsWritten, ReadOnlySpan<char> format = default, IFormatProvider? provider = null) => ConversionValue.TryFormat(destination, out charsWritten, format, provider);
        public float Approximate(float offset) => (float)(_scaledValue + (offset * ScalingFactor));
        public int CompareTo(ufix64 other) => _scaledValue.CompareTo(other._scaledValue);
        public int CompareTo(object value) => value == null ? 1 : (value is ufix64 other) ? CompareTo(other) : throw new ArgumentException($"Object must be of type {nameof(ufix64)}.");
        public override bool Equals(object? obj) => obj is ufix64 other && _scaledValue == other._scaledValue;
        public override int GetHashCode() => _scaledValue.GetHashCode();
        public override string ToString() => ConversionValue.ToString();
        public string ToString(string format, IFormatProvider formatProvider) => ConversionValue.ToString(format, formatProvider);

        ufix64 INumeric<ufix64>.E => E;
        ufix64 INumeric<ufix64>.Epsilon => Epsilon;
        ufix64 INumeric<ufix64>.MaxValue => MaxValue;
        ufix64 INumeric<ufix64>.MinValue => MinValue;
        ufix64 INumeric<ufix64>.MaxUnit => MaxUnit;
        ufix64 INumeric<ufix64>.MinUnit => MinUnit;
        ufix64 INumeric<ufix64>.One => One;
        ufix64 INumeric<ufix64>.Pi => Pi;
        bool INumeric<ufix64>.GreaterThan(ufix64 value2) => _scaledValue > value2._scaledValue;
        bool INumeric<ufix64>.GreaterThanOrEqualTo(ufix64 value2) => _scaledValue >= value2._scaledValue;
        bool INumeric<ufix64>.LessThan(ufix64 value2) => _scaledValue < value2._scaledValue;
        bool INumeric<ufix64>.LessThanOrEqualTo(ufix64 value2) => _scaledValue <= value2._scaledValue;
        ufix64 INumeric<ufix64>.Abs() => this;
        ufix64 INumeric<ufix64>.Acos() => new ufix64(Checked.ToUInt64(Math.Acos(ConversionValue) * ScalingFactor));
        ufix64 INumeric<ufix64>.Acosh() => new ufix64(Checked.ToUInt64(Math.Acosh(ConversionValue) * ScalingFactor));
        ufix64 INumeric<ufix64>.Addition(ufix64 value2) => this + value2;
        ufix64 INumeric<ufix64>.Asin() => new ufix64(Checked.ToUInt64(Math.Asin(ConversionValue) * ScalingFactor));
        ufix64 INumeric<ufix64>.Asinh() => new ufix64(Checked.ToUInt64(Math.Asinh(ConversionValue) * ScalingFactor));
        ufix64 INumeric<ufix64>.Atan() => new ufix64(Checked.ToUInt64(Math.Atan(ConversionValue) * ScalingFactor));
        ufix64 INumeric<ufix64>.Atan2(ufix64 x) => new ufix64(Checked.ToUInt64(Math.Atan2(ConversionValue, x.ConversionValue) * ScalingFactor));
        ufix64 INumeric<ufix64>.Atanh() => new ufix64(Checked.ToUInt64(Math.Atanh(ConversionValue) * ScalingFactor));
        ufix64 INumeric<ufix64>.Cbrt() => new ufix64(Checked.ToUInt64(Math.Cbrt(ConversionValue) * ScalingFactor));
        ufix64 INumeric<ufix64>.Ceiling() => new ufix64(Checked.ToUInt64(Math.Ceiling(ConversionValue) * ScalingFactor));
        ufix64 INumeric<ufix64>.Cos() => new ufix64(Checked.ToUInt64(Math.Cos(ConversionValue) * ScalingFactor));
        ufix64 INumeric<ufix64>.Cosh() => new ufix64(Checked.ToUInt64(Math.Cosh(ConversionValue) * ScalingFactor));
        ufix64 INumeric<ufix64>.DegreesToRadians() => new ufix64(Checked.ToUInt64(Checked.DegreesToRadians(ConversionValue) * ScalingFactor));
        ufix64 INumeric<ufix64>.DegreesToTurns() => new ufix64(Checked.ToUInt64(Checked.DegreesToTurns(ConversionValue) * ScalingFactor));
        ufix64 INumeric<ufix64>.Divide(ufix64 value2) => this / value2;
        ufix64 INumeric<ufix64>.Exp() => new ufix64(Checked.ToUInt64(Math.Exp(ConversionValue) * ScalingFactor));
        ufix64 INumeric<ufix64>.Floor() => new ufix64(Checked.ToUInt64(Math.Floor(ConversionValue) * ScalingFactor));
        ufix64 INumeric<ufix64>.Log() => new ufix64(Checked.ToUInt64(Math.Log(ConversionValue) * ScalingFactor));
        ufix64 INumeric<ufix64>.Log(ufix64 y) => new ufix64(Checked.ToUInt64(Math.Log(ConversionValue, y.ConversionValue) * ScalingFactor));
        ufix64 INumeric<ufix64>.Log10() => new ufix64(Checked.ToUInt64(Math.Log10(ConversionValue) * ScalingFactor));
        ufix64 INumeric<ufix64>.Max(ufix64 y) => _scaledValue > y._scaledValue ? this : y;
        ufix64 INumeric<ufix64>.Min(ufix64 y) => _scaledValue < y._scaledValue ? this : y;
        ufix64 INumeric<ufix64>.Negative() => MinValue;
        ufix64 INumeric<ufix64>.Multiply(ufix64 value2) => this * value2;
        ufix64 INumeric<ufix64>.Positive() => this;
        ufix64 INumeric<ufix64>.Pow(ufix64 y) => new ufix64(Checked.ToUInt64(Math.Pow(ConversionValue, y.ConversionValue) * ScalingFactor));
        ufix64 INumeric<ufix64>.RadiansToDegrees() => new ufix64(Checked.ToUInt64(Checked.RadiansToDegrees(ConversionValue) * ScalingFactor));
        ufix64 INumeric<ufix64>.RadiansToTurns() => new ufix64(Checked.ToUInt64(Checked.RadiansToTurns(ConversionValue) * ScalingFactor));
        ufix64 INumeric<ufix64>.Remainder(ufix64 value2) => this % value2;
        ufix64 INumeric<ufix64>.Round() => new ufix64(Checked.ToUInt64(Math.Round(ConversionValue) * ScalingFactor));
        ufix64 INumeric<ufix64>.Round(byte digits) => new ufix64(Checked.ToUInt64(Math.Round(ConversionValue, digits) * ScalingFactor));
        ufix64 INumeric<ufix64>.Round(byte digits, MidpointRounding mode) => new ufix64(Checked.ToUInt64(Math.Round(ConversionValue, digits, mode) * ScalingFactor));
        ufix64 INumeric<ufix64>.Round(MidpointRounding mode) => new ufix64(Checked.ToUInt64(Math.Round(ConversionValue, mode) * ScalingFactor));
        ufix64 INumeric<ufix64>.Sin() => new ufix64(Checked.ToUInt64(Math.Sin(ConversionValue) * ScalingFactor));
        ufix64 INumeric<ufix64>.Sinh() => new ufix64(Checked.ToUInt64(Math.Sinh(ConversionValue) * ScalingFactor));
        ufix64 INumeric<ufix64>.Sqrt() => new ufix64(Checked.ToUInt64(Math.Sqrt(ConversionValue) * ScalingFactor));
        ufix64 INumeric<ufix64>.Subtract(ufix64 value2) => this - value2;
        ufix64 INumeric<ufix64>.Tan() => new ufix64(Checked.ToUInt64(Math.Tan(ConversionValue) * ScalingFactor));
        ufix64 INumeric<ufix64>.Tanh() => new ufix64(Checked.ToUInt64(Math.Tanh(ConversionValue) * ScalingFactor));
        ufix64 INumeric<ufix64>.TurnsToDegrees() => new ufix64(Checked.ToUInt64(Checked.TurnsToDegrees(ConversionValue) * ScalingFactor));
        ufix64 INumeric<ufix64>.TurnsToRadians() => new ufix64(Checked.ToUInt64(Checked.TurnsToRadians(ConversionValue) * ScalingFactor));
        ufix64 INumeric<ufix64>.Convert(byte value) => new ufix64(value * ScalingFactor);
        ufix64 INumeric<ufix64>.Parse(string s) => Parse(s);
        ufix64 INumeric<ufix64>.Parse(string s, IFormatProvider provider) => Parse(s, provider);
        ufix64 INumeric<ufix64>.Parse(string s, NumberStyles style) => Parse(s, style);
        ufix64 INumeric<ufix64>.Parse(string s, NumberStyles style, IFormatProvider provider) => Parse(s, style, provider);

        ufix64 INumeric<ufix64>.Next(Random random, ufix64 minInclusive, ufix64 maxInclusive)
        {
            if (minInclusive > maxInclusive) throw new ArgumentOutOfRangeException(nameof(minInclusive), minInclusive, $"{nameof(minInclusive)}' cannot be greater than {nameof(maxInclusive)}");
            if (minInclusive == maxInclusive) return minInclusive;
            return FromInternalRepresentation(random.NextUInt64(
                    GetInternalRepresentation(minInclusive),
                    GetInternalRepresentation(maxInclusive)));
        }

        public static bool TryParse(string s, IFormatProvider provider, out ufix64 result) => Try.Function(Parse, s, provider, out result);
        public static bool TryParse(string s, NumberStyles style, IFormatProvider provider, out ufix64 result) => Try.Function(Parse, s, style, provider, out result);
        public static bool TryParse(string s, NumberStyles style, out ufix64 result) => Try.Function(Parse, s, style, out result);
        public static bool TryParse(string s, out ufix64 result) => Try.Function(Parse, s, out result);
        public static byte[] GetBytes(ufix64 value) => BitConverter.GetBytes(value._scaledValue);
        public static ufix64 FromBytes(byte[] bytes) => new ufix64(BitConverter.ToUInt64(bytes));
        public static ufix64 FromBytes(ReadOnlySpan<byte> bytes) => new ufix64(BitConverter.ToUInt64(bytes));
        public static ufix64 FromInternalRepresentation(ulong value) => new ufix64(value);
        public static ufix64 Parse(string s) => new ufix64(Checked.ToUInt64(double.Parse(s) * ScalingFactor));
        public static ufix64 Parse(string s, IFormatProvider provider) => new ufix64(Checked.ToUInt64(double.Parse(s, provider) * ScalingFactor));
        public static ufix64 Parse(string s, NumberStyles style) => new ufix64(Checked.ToUInt64(double.Parse(s, style) * ScalingFactor));
        public static ufix64 Parse(string s, NumberStyles style, IFormatProvider provider) => new ufix64(Checked.ToUInt64(double.Parse(s, style, provider) * ScalingFactor));
        public static ulong GetInternalRepresentation(ufix64 value) => value._scaledValue;

        public static explicit operator ufix64(cint value) => new ufix64(Checked.ToUInt64(value) * ScalingFactor);
        public static explicit operator ufix64(cfloat value) => new ufix64(Checked.ToUInt64(value * ScalingFactor));
        public static explicit operator ufix64(decimal value) => new ufix64(Checked.ToUInt64(value * ScalingFactor));
        public static explicit operator ufix64(double value) => new ufix64(Checked.ToUInt64(value * ScalingFactor));
        public static explicit operator ufix64(fix64 value) => new ufix64(Checked.ToUInt64(fix64.GetInternalRepresentation(value)));
        public static explicit operator ufix64(int value) => new ufix64(Checked.ToUInt64(value) * ScalingFactor);
        public static explicit operator ufix64(long value) => new ufix64(Checked.ToUInt64(value) * ScalingFactor);
        public static explicit operator ufix64(short value) => new ufix64(Checked.ToUInt64(value) * ScalingFactor);
        public static explicit operator ufix64(ulong value) => new ufix64(value * ScalingFactor);
        public static implicit operator ufix64(byte value) => new ufix64(value * ScalingFactor);
        public static implicit operator ufix64(float value) => new ufix64(Checked.ToUInt64(value * ScalingFactor));
        public static implicit operator ufix64(uint value) => new ufix64(Checked.ToUInt64(value) * ScalingFactor);
        public static implicit operator ufix64(ushort value) => new ufix64(Checked.ToUInt64(value) * ScalingFactor);
        public static implicit operator ufix64(ucint value) => new ufix64(Checked.ToUInt64(value) * ScalingFactor);

        public static explicit operator byte(ufix64 value) => (byte)value.ConversionValue;
        public static explicit operator decimal(ufix64 value) => (decimal)value.ConversionValue;
        public static explicit operator double(ufix64 value) => value.ConversionValue;
        public static explicit operator float(ufix64 value) => (float)value.ConversionValue;
        public static explicit operator int(ufix64 value) => (int)value.ConversionValue;
        public static explicit operator long(ufix64 value) => (long)value.ConversionValue;
        public static explicit operator short(ufix64 value) => (short)value.ConversionValue;
        public static explicit operator uint(ufix64 value) => (uint)value.ConversionValue;
        public static explicit operator ulong(ufix64 value) => (ulong)value.ConversionValue;
        public static explicit operator ushort(ufix64 value) => (ushort)value.ConversionValue;

        public static bool operator !=(ufix64 left, ufix64 right) => left._scaledValue != right._scaledValue;
        public static bool operator <(ufix64 left, ufix64 right) => left._scaledValue < right._scaledValue;
        public static bool operator <=(ufix64 left, ufix64 right) => left._scaledValue <= right._scaledValue;
        public static bool operator ==(ufix64 left, ufix64 right) => left._scaledValue == right._scaledValue;
        public static bool operator >(ufix64 left, ufix64 right) => left._scaledValue > right._scaledValue;
        public static bool operator >=(ufix64 left, ufix64 right) => left._scaledValue >= right._scaledValue;
        public static ufix64 operator %(ufix64 left, ufix64 right) => new ufix64(Checked.ToUInt64((left.ConversionValue % right.ConversionValue) * ScalingFactor));
        public static ufix64 operator &(ufix64 left, ufix64 right) => new ufix64(left._scaledValue & right._scaledValue);
        public static ufix64 operator -(ufix64 left, ufix64 right) => new ufix64(Checked.Subtract(left._scaledValue, right._scaledValue));
        public static ufix64 operator --(ufix64 value) => new ufix64(value._scaledValue - ScalingFactor);
        public static ufix64 operator -(ufix64 _) => Zero;
        public static ufix64 operator *(ufix64 left, ufix64 right) => new ufix64(Checked.ToUInt64(left.ConversionValue * right.ConversionValue * ScalingFactor));
        public static ufix64 operator /(ufix64 left, ufix64 right) => new ufix64(Checked.ToUInt64(Checked.Divide(left.ConversionValue, right.ConversionValue) * ScalingFactor));
        public static ufix64 operator ^(ufix64 left, ufix64 right) => new ufix64(left._scaledValue ^ right._scaledValue);
        public static ufix64 operator |(ufix64 left, ufix64 right) => new ufix64(left._scaledValue | right._scaledValue);
        public static ufix64 operator ~(ufix64 value) => new ufix64(~value._scaledValue);
        public static ufix64 operator +(ufix64 left, ufix64 right) => new ufix64(Checked.Add(left._scaledValue, right._scaledValue));
        public static ufix64 operator +(ufix64 value) => value;
        public static ufix64 operator ++(ufix64 value) => new ufix64(value._scaledValue + ScalingFactor);
        public static ufix64 operator <<(ufix64 left, int right) => new ufix64(left._scaledValue << right);
        public static ufix64 operator >>(ufix64 left, int right) => new ufix64(left._scaledValue >> right);
    }
}
