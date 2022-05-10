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
    [DebuggerDisplay("{ToString(),nq}")]
    [SuppressMessage("Style", "IDE1006:Naming Styles")]
    public readonly struct fix64 : INumeric<fix64>
    {
        public static readonly fix64 Epsilon = new fix64(1);
        public static readonly fix64 MaxValue = new fix64(long.MaxValue);
        public static readonly fix64 MinValue = new fix64(long.MinValue);

        private const long ScalingFactor = 0b1111_1111_1111_1111_1111_1111;

        private readonly long _scaledValue;

        private fix64(long scaledValue)
        {
            _scaledValue = scaledValue;
        }

        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext _) => info.AddValue(nameof(fix64), _scaledValue);
        private fix64(SerializationInfo info, StreamingContext _) : this(info.GetInt64(nameof(fix64))) { }

        public bool Equals(fix64 other) => _scaledValue == other._scaledValue;
        public int CompareTo(fix64 other) => _scaledValue.CompareTo(other._scaledValue);
        public int CompareTo(object? obj) => obj is fix64 other ? CompareTo(other) : 1;
        public override bool Equals(object? obj) => obj is fix64 other && Equals(other);
        public override int GetHashCode() => _scaledValue.GetHashCode();
        public override string ToString() => ((double)this).ToString();
        public string ToString(string format, IFormatProvider formatProvider) => ((double)this).ToString(format, formatProvider);

        public static bool TryParse(string s, IFormatProvider provider, out fix64 result) => Try.Run(Parse, s, provider, out result);
        public static bool TryParse(string s, NumberStyles style, IFormatProvider provider, out fix64 result) => Try.Run(Parse, s, style, provider, out result);
        public static bool TryParse(string s, NumberStyles style, out fix64 result) => Try.Run(Parse, s, style, out result);
        public static bool TryParse(string s, out fix64 result) => Try.Function(Parse, s, out result);
        public static fix64 Parse(string s) => (fix64)double.Parse(s);
        public static fix64 Parse(string s, IFormatProvider provider) => (fix64)double.Parse(s, provider);
        public static fix64 Parse(string s, NumberStyles style) => (fix64)double.Parse(s, style);
        public static fix64 Parse(string s, NumberStyles style, IFormatProvider provider) => (fix64)double.Parse(s, style, provider);

        public static explicit operator fix64(in decimal value) => new fix64(CheckedConvert.ToInt64(value * ScalingFactor));
        public static explicit operator fix64(in double value) => new fix64(CheckedConvert.ToInt64(CheckedArithmetic.Multiply(value, ScalingFactor)));
        public static explicit operator fix64(in long value) => new fix64(value * ScalingFactor);
        public static explicit operator fix64(in ulong value) => new fix64(CheckedConvert.ToInt64(value * ScalingFactor));
        public static implicit operator fix64(in byte value) => new fix64(value * ScalingFactor);
        public static implicit operator fix64(in float value) => new fix64(CheckedConvert.ToInt64(value * ScalingFactor));
        public static implicit operator fix64(in int value) => new fix64(value * ScalingFactor);
        public static implicit operator fix64(in sbyte value) => new fix64(value * ScalingFactor);
        public static implicit operator fix64(in short value) => new fix64(value * ScalingFactor);
        public static implicit operator fix64(in uint value) => new fix64(value * ScalingFactor);
        public static implicit operator fix64(in ushort value) => new fix64(value * ScalingFactor);

        public static explicit operator byte(in fix64 value) => CheckedConvert.ToByte(value._scaledValue / ScalingFactor);
        public static explicit operator decimal(in fix64 value) => (decimal)value._scaledValue / ScalingFactor;
        public static explicit operator double(in fix64 value) => (double)value._scaledValue / ScalingFactor;
        public static explicit operator float(in fix64 value) => (float)value._scaledValue / ScalingFactor;
        public static explicit operator int(in fix64 value) => CheckedConvert.ToInt32(value._scaledValue / ScalingFactor);
        public static explicit operator long(in fix64 value) => value._scaledValue / ScalingFactor;
        public static explicit operator sbyte(in fix64 value) => CheckedConvert.ToSByte(value._scaledValue / ScalingFactor);
        public static explicit operator short(in fix64 value) => CheckedConvert.ToInt16(value._scaledValue / ScalingFactor);
        public static explicit operator uint(in fix64 value) => CheckedConvert.ToUInt32(value._scaledValue / ScalingFactor);
        public static explicit operator ulong(in fix64 value) => CheckedConvert.ToUInt64(value._scaledValue / ScalingFactor);
        public static explicit operator ushort(in fix64 value) => CheckedConvert.ToUInt16(value._scaledValue / ScalingFactor);

        public static bool operator !=(in fix64 left, in fix64 right) => left._scaledValue != right._scaledValue;
        public static bool operator <(in fix64 left, in fix64 right) => left._scaledValue < right._scaledValue;
        public static bool operator <=(in fix64 left, in fix64 right) => left._scaledValue <= right._scaledValue;
        public static bool operator ==(in fix64 left, in fix64 right) => left._scaledValue == right._scaledValue;
        public static bool operator >(in fix64 left, in fix64 right) => left._scaledValue > right._scaledValue;
        public static bool operator >=(in fix64 left, in fix64 right) => left._scaledValue >= right._scaledValue;
        public static fix64 operator %(in fix64 left, in fix64 right) => new fix64(CheckedArithmetic.ScaledRemainder(left._scaledValue, right._scaledValue, ScalingFactor));
        public static fix64 operator &(in fix64 left, in fix64 right) => new fix64(left._scaledValue & right._scaledValue);
        public static fix64 operator -(in fix64 left, in fix64 right) => new fix64(CheckedArithmetic.Subtract(left._scaledValue, right._scaledValue));
        public static fix64 operator --(in fix64 value) => new fix64(value._scaledValue - ScalingFactor);
        public static fix64 operator -(in fix64 value) => new fix64(-value._scaledValue);
        public static fix64 operator *(in fix64 left, in fix64 right) => new fix64(CheckedArithmetic.ScaledMultiply(left._scaledValue, right._scaledValue, ScalingFactor));
        public static fix64 operator /(in fix64 left, in fix64 right) => new fix64(CheckedArithmetic.ScaledDivide(left._scaledValue, right._scaledValue, ScalingFactor));
        public static fix64 operator ^(in fix64 left, in fix64 right) => new fix64(left._scaledValue ^ right._scaledValue);
        public static fix64 operator |(in fix64 left, in fix64 right) => new fix64(left._scaledValue | right._scaledValue);
        public static fix64 operator ~(in fix64 value) => new fix64(~value._scaledValue);
        public static fix64 operator +(in fix64 left, in fix64 right) => new fix64(CheckedArithmetic.Add(left._scaledValue, right._scaledValue));
        public static fix64 operator +(in fix64 value) => value;
        public static fix64 operator ++(in fix64 value) => new fix64(value._scaledValue + ScalingFactor);
        public static fix64 operator <<(in fix64 left, int right) => new fix64(left._scaledValue << right);
        public static fix64 operator >>(in fix64 left, int right) => new fix64(left._scaledValue >> right);

        IBitConverter<fix64> IBitConvertible<fix64>.BitConverter => Utilities.Instance;
        IMath<fix64> INumeric<fix64>.Math => Utilities.Instance;
        IRandom<fix64> IRandomisable<fix64>.Random => Utilities.Instance;
        IStringParser<fix64> IStringRepresentable<fix64>.StringParser => Utilities.Instance;

        private sealed class Utilities : IMath<fix64>, IBitConverter<fix64>, IRandom<fix64>, IStringParser<fix64>
        {
            public readonly static Utilities Instance = new Utilities();

            fix64 IMath<fix64>.E { get; } = (fix64)Math.E;
            fix64 IMath<fix64>.PI { get; } = (fix64)Math.PI;
            fix64 IMath<fix64>.Epsilon { get; } = 1;
            fix64 IMath<fix64>.MaxValue => MaxValue;
            fix64 IMath<fix64>.MinValue => MinValue;
            fix64 IMath<fix64>.MaxUnit { get; } = ScalingFactor;
            fix64 IMath<fix64>.MinUnit { get; } = -ScalingFactor;
            fix64 IMath<fix64>.Zero { get; } = 0;
            fix64 IMath<fix64>.One { get; } = ScalingFactor;
            bool IMath<fix64>.IsSigned { get; } = true;
            bool IMath<fix64>.IsReal { get; } = true;

            bool IMath<fix64>.IsGreaterThan(in fix64 x, in fix64 y) => x > y;
            bool IMath<fix64>.IsGreaterThanOrEqualTo(in fix64 x, in fix64 y) => x >= y;
            bool IMath<fix64>.IsLessThan(in fix64 x, in fix64 y) => x < y;
            bool IMath<fix64>.IsLessThanOrEqualTo(in fix64 x, in fix64 y) => x <= y;
            double IMath<fix64>.ToDouble(in fix64 x, in double offset) => CheckedArithmetic.Add((double)x, offset);
            fix64 IMath<fix64>.Abs(in fix64 x) => x._scaledValue < 0 ? -x : x;
            fix64 IMath<fix64>.Acos(in fix64 x) => (fix64)Math.Acos((double)x);
            fix64 IMath<fix64>.Acosh(in fix64 x) => (fix64)Math.Acosh((double)x);
            fix64 IMath<fix64>.Add(in fix64 x, in fix64 y) => x + y;
            fix64 IMath<fix64>.Asin(in fix64 x) => (fix64)Math.Asin((double)x);
            fix64 IMath<fix64>.Asinh(in fix64 x) => (fix64)Math.Asinh((double)x);
            fix64 IMath<fix64>.Atan(in fix64 x) => (fix64)Math.Atan((double)x);
            fix64 IMath<fix64>.Atan2(in fix64 x, in fix64 y) => (fix64)Math.Atan2((double)x, (double)y);
            fix64 IMath<fix64>.Atanh(in fix64 x) => (fix64)Math.Atanh((double)x);
            fix64 IMath<fix64>.Cbrt(in fix64 x) => (fix64)Math.Cbrt((double)x);
            fix64 IMath<fix64>.Ceiling(in fix64 x) => x._scaledValue > 0 && x._scaledValue % ScalingFactor != 0 ? new fix64((x._scaledValue / ScalingFactor * ScalingFactor) + ScalingFactor) : new fix64(x._scaledValue / ScalingFactor * ScalingFactor);
            fix64 IMath<fix64>.Clamp(in fix64 x, in fix64 bound1, in fix64 bound2) => bound1 > bound2 ? Math.Min(bound1._scaledValue, Math.Max(bound2._scaledValue, x._scaledValue)) : Math.Min(bound2._scaledValue, Math.Max(bound1._scaledValue, x._scaledValue));
            fix64 IMath<fix64>.Convert(in byte value) => value;
            fix64 IMath<fix64>.Cos(in fix64 x) => (fix64)Math.Cos((double)x);
            fix64 IMath<fix64>.Cosh(in fix64 x) => (fix64)Math.Cosh((double)x);
            fix64 IMath<fix64>.DegreesToRadians(in fix64 x) => (fix64)CheckedArithmetic.Multiply((double)x, Constants.RadiansPerDegree);
            fix64 IMath<fix64>.DegreesToTurns(in fix64 x) => (fix64)CheckedArithmetic.Multiply((double)x, Constants.TurnsPerDegree);
            fix64 IMath<fix64>.Divide(in fix64 x, in fix64 y) => x / y;
            fix64 IMath<fix64>.Exp(in fix64 x) => (fix64)Math.Exp((double)x);
            fix64 IMath<fix64>.Floor(in fix64 x) => x._scaledValue < 0 && x._scaledValue % ScalingFactor != 0 ? new fix64((x._scaledValue / ScalingFactor * ScalingFactor) - ScalingFactor) : new fix64(x._scaledValue / ScalingFactor * ScalingFactor);
            fix64 IMath<fix64>.IEEERemainder(in fix64 x, in fix64 y) => (fix64)Math.IEEERemainder((double)x, (double)y);
            fix64 IMath<fix64>.Log(in fix64 x) => (fix64)Math.Log((double)x);
            fix64 IMath<fix64>.Log(in fix64 x, in fix64 y) => (fix64)Math.Log((double)x, (double)y);
            fix64 IMath<fix64>.Log10(in fix64 x) => (fix64)Math.Log10((double)x);
            fix64 IMath<fix64>.Max(in fix64 x, in fix64 y) => new fix64(Math.Max(x._scaledValue, y._scaledValue));
            fix64 IMath<fix64>.Min(in fix64 x, in fix64 y) => new fix64(Math.Min(x._scaledValue, y._scaledValue));
            fix64 IMath<fix64>.Multiply(in fix64 x, in fix64 y) => x * y;
            fix64 IMath<fix64>.Negative(in fix64 x) => -x;
            fix64 IMath<fix64>.Positive(in fix64 x) => +x;
            fix64 IMath<fix64>.Pow(in fix64 x, in byte y) => (fix64)Math.Pow((double)x, y);
            fix64 IMath<fix64>.Pow(in fix64 x, in fix64 y) => (fix64)Math.Pow((double)x, (double)y);
            fix64 IMath<fix64>.RadiansToDegrees(in fix64 x) => (fix64)CheckedArithmetic.Multiply((double)x, Constants.DegreesPerRadian);
            fix64 IMath<fix64>.RadiansToTurns(in fix64 x) => (fix64)CheckedArithmetic.Multiply((double)x, Constants.TurnsPerRadian);
            fix64 IMath<fix64>.Remainder(in fix64 x, in fix64 y) => x % y;
            fix64 IMath<fix64>.Round(in fix64 x) => (fix64)Math.Round((double)x);
            fix64 IMath<fix64>.Round(in fix64 x, in int digits) => (fix64)Math.Round((double)x, digits);
            fix64 IMath<fix64>.Round(in fix64 x, in int digits, in MidpointRounding mode) => (fix64)Math.Round((double)x, digits, mode);
            fix64 IMath<fix64>.Round(in fix64 x, in MidpointRounding mode) => (fix64)Math.Round((double)x, mode);
            fix64 IMath<fix64>.Sin(in fix64 x) => (fix64)Math.Sin((double)x);
            fix64 IMath<fix64>.Sinh(in fix64 x) => (fix64)Math.Sinh((double)x);
            fix64 IMath<fix64>.Sqrt(in fix64 x) => (fix64)Math.Sqrt((double)x);
            fix64 IMath<fix64>.Subtract(in fix64 x, in fix64 y) => x - y;
            fix64 IMath<fix64>.Tan(in fix64 x) => (fix64)Math.Tan((double)x);
            fix64 IMath<fix64>.Tanh(in fix64 x) => (fix64)Math.Tanh((double)x);
            fix64 IMath<fix64>.Truncate(in fix64 x) => new fix64(x._scaledValue / ScalingFactor * ScalingFactor);
            fix64 IMath<fix64>.TurnsToDegrees(in fix64 x) => (fix64)CheckedArithmetic.Multiply((double)x, Constants.DegreesPerTurn);
            fix64 IMath<fix64>.TurnsToRadians(in fix64 x) => (fix64)CheckedArithmetic.Multiply((double)x, Constants.DegreesPerRadian);
            float IMath<fix64>.ToSingle(in fix64 x, in float offset) => CheckedArithmetic.Add((float)x, offset);
            int IMath<fix64>.Sign(in fix64 x) => Math.Sign(x._scaledValue);

            fix64 IBitConverter<fix64>.Read(in IReadOnlyStream<byte> stream) => new fix64(BitConverter.ToInt64(stream.Read(sizeof(long))));
            void IBitConverter<fix64>.Write(fix64 value, in IWriteOnlyStream<byte> stream) => stream.Write(BitConverter.GetBytes(value._scaledValue));

            fix64 IRandom<fix64>.GetNext(Random random) => new fix64(random.NextInt64());
            fix64 IRandom<fix64>.GetNext(Random random, in fix64 bound1, in fix64 bound2) => new fix64(random.NextInt64(bound1._scaledValue, bound2._scaledValue));

            fix64 IStringParser<fix64>.Parse(in string s) => Parse(s);
            fix64 IStringParser<fix64>.Parse(in string s, in NumberStyles numberStyles, in IFormatProvider formatProvider) => Parse(s, numberStyles, formatProvider);
        }
    }
}
