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
    [SuppressMessage("CodeQuality", "IDE0079:Remove unnecessary suppression")]
    [SuppressMessage("csharpsquid", "S101")]
    public readonly struct ufix64 : INumeric<ufix64>
    {
        public static readonly ufix64 E = new ufix64(CheckedConvert.ToUInt64(Math.E * ScalingFactor));
        public static readonly ufix64 Epsilon = new ufix64(1);
        public static readonly ufix64 MaxValue = new ufix64(ulong.MaxValue);
        public static readonly ufix64 MinValue = new ufix64(ulong.MinValue);
        public static readonly ufix64 MaxUnit = new ufix64(ScalingFactor);
        public static readonly ufix64 MinUnit = new ufix64(0);
        public static readonly ufix64 One = new ufix64(ScalingFactor);
        public static readonly ufix64 Pi = new ufix64((long)(Math.PI * ScalingFactor));
        public static readonly ufix64 Zero = new ufix64(0);

        private const ulong ScalingFactor = 0b1111_1111_1111_1111_1111_1111;

        private readonly ulong _scaledValue;

        private ufix64(ulong scaledValue)
        {
            _scaledValue = scaledValue;
        }

        private ufix64(SerializationInfo info, StreamingContext context) : this(info.GetUInt64(nameof(ufix64))) { }
        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context) => info.AddValue(nameof(ufix64), _scaledValue);

        public int CompareTo(object? obj) => obj is ufix64 other ? CompareTo(other) : 1;
        public int CompareTo(ufix64 other) => _scaledValue.CompareTo(other._scaledValue);
        public bool Equals(ufix64 other) => _scaledValue == other._scaledValue;
        public override bool Equals(object? obj) => obj is ufix64 other && Equals(other);
        public override int GetHashCode() => _scaledValue.GetHashCode();
        public override string ToString() => ((double)this).ToString();
        public string ToString(string format, IFormatProvider formatProvider) => ((double)this).ToString(format, formatProvider);

        public static bool TryParse(string s, IFormatProvider provider, out ufix64 result) => Try.Run(() => Parse(s, provider), out result);
        public static bool TryParse(string s, NumberStyles style, IFormatProvider provider, out ufix64 result) => Try.Run(() => Parse(s, style, provider), out result);
        public static bool TryParse(string s, NumberStyles style, out ufix64 result) => Try.Run(() => Parse(s, style), out result);
        public static bool TryParse(string s, out ufix64 result) => Try.Run(() => Parse(s), out result);
        public static ufix64 Parse(string s) => (ufix64)double.Parse(s);
        public static ufix64 Parse(string s, IFormatProvider provider) => (ufix64)double.Parse(s, provider);
        public static ufix64 Parse(string s, NumberStyles style) => (ufix64)double.Parse(s, style);
        public static ufix64 Parse(string s, NumberStyles style, IFormatProvider provider) => (ufix64)double.Parse(s, style, provider);

        public static explicit operator ufix64(in decimal value) => new ufix64(CheckedConvert.ToUInt64(value * ScalingFactor));
        public static explicit operator ufix64(in double value) => new ufix64(CheckedConvert.ToUInt64(value * ScalingFactor));
        public static explicit operator ufix64(in int value) => new ufix64(CheckedConvert.ToUInt64(value) * ScalingFactor);
        public static explicit operator ufix64(in long value) => new ufix64(CheckedConvert.ToUInt64(value) * ScalingFactor);
        public static explicit operator ufix64(in sbyte value) => new ufix64(Convert.ToUInt64(value) * ScalingFactor);
        public static explicit operator ufix64(in short value) => new ufix64(CheckedConvert.ToUInt64(value) * ScalingFactor);
        public static explicit operator ufix64(in ulong value) => new ufix64(value * ScalingFactor);
        public static implicit operator ufix64(in byte value) => new ufix64(value * ScalingFactor);
        public static implicit operator ufix64(in float value) => new ufix64(CheckedConvert.ToUInt64(value * ScalingFactor));
        public static implicit operator ufix64(in uint value) => new ufix64(CheckedConvert.ToUInt64(value) * ScalingFactor);
        public static implicit operator ufix64(in ushort value) => new ufix64(CheckedConvert.ToUInt64(value) * ScalingFactor);

        public static explicit operator byte(in ufix64 value) => CheckedConvert.ToByte(value._scaledValue / ScalingFactor);
        public static explicit operator sbyte(in ufix64 value) => CheckedConvert.ToSByte(value._scaledValue / ScalingFactor);
        public static explicit operator decimal(in ufix64 value) => (decimal)value._scaledValue / ScalingFactor;
        public static explicit operator double(in ufix64 value) => (double)value._scaledValue / ScalingFactor;
        public static explicit operator float(in ufix64 value) => (float)value._scaledValue / ScalingFactor;
        public static explicit operator int(in ufix64 value) => CheckedConvert.ToInt32(value._scaledValue / ScalingFactor);
        public static explicit operator long(in ufix64 value) => CheckedConvert.ToInt64(value._scaledValue / ScalingFactor);
        public static explicit operator short(in ufix64 value) => CheckedConvert.ToInt16(value._scaledValue / ScalingFactor);
        public static explicit operator uint(in ufix64 value) => CheckedConvert.ToUInt32(value._scaledValue / ScalingFactor);
        public static explicit operator ulong(in ufix64 value) => value._scaledValue / ScalingFactor;
        public static explicit operator ushort(in ufix64 value) => CheckedConvert.ToUInt16(value._scaledValue / ScalingFactor);

        public static bool operator !=(in ufix64 left, in ufix64 right) => left._scaledValue != right._scaledValue;
        public static bool operator <(in ufix64 left, in ufix64 right) => left._scaledValue < right._scaledValue;
        public static bool operator <=(in ufix64 left, in ufix64 right) => left._scaledValue <= right._scaledValue;
        public static bool operator ==(in ufix64 left, in ufix64 right) => left._scaledValue == right._scaledValue;
        public static bool operator >(in ufix64 left, in ufix64 right) => left._scaledValue > right._scaledValue;
        public static bool operator >=(in ufix64 left, in ufix64 right) => left._scaledValue >= right._scaledValue;
        public static ufix64 operator %(in ufix64 left, in ufix64 right) => new ufix64(CheckedArithmetic.ScaledRemainder(left._scaledValue, right._scaledValue, ScalingFactor));
        public static ufix64 operator &(in ufix64 left, in ufix64 right) => new ufix64(left._scaledValue & right._scaledValue);
        public static ufix64 operator -(in ufix64 _) => Zero;
        public static ufix64 operator -(in ufix64 left, in ufix64 right) => new ufix64(CheckedArithmetic.Subtract(left._scaledValue, right._scaledValue));
        public static ufix64 operator --(in ufix64 value) => new ufix64(value._scaledValue - ScalingFactor);
        public static ufix64 operator *(in ufix64 left, in ufix64 right) => new ufix64(CheckedArithmetic.ScaledMultiply(left._scaledValue, right._scaledValue, ScalingFactor));
        public static ufix64 operator /(in ufix64 left, in ufix64 right) => new ufix64(CheckedArithmetic.ScaledDivide(left._scaledValue, right._scaledValue, ScalingFactor));
        public static ufix64 operator ^(in ufix64 left, in ufix64 right) => new ufix64(left._scaledValue ^ right._scaledValue);
        public static ufix64 operator |(in ufix64 left, in ufix64 right) => new ufix64(left._scaledValue | right._scaledValue);
        public static ufix64 operator ~(in ufix64 value) => new ufix64(~value._scaledValue);
        public static ufix64 operator +(in ufix64 left, in ufix64 right) => new ufix64(CheckedArithmetic.Add(left._scaledValue, right._scaledValue));
        public static ufix64 operator +(in ufix64 value) => value;
        public static ufix64 operator ++(in ufix64 value) => new ufix64(value._scaledValue + ScalingFactor);
        public static ufix64 operator <<(in ufix64 left, in int right) => new ufix64(left._scaledValue << right);
        public static ufix64 operator >>(in ufix64 left, in int right) => new ufix64(left._scaledValue >> right);

        IBitConverter<ufix64> IBitConvertible<ufix64>.BitConverter => Utilities.Instance;
        IMath<ufix64> INumeric<ufix64>.Math => Utilities.Instance;
        IRandom<ufix64> IRandomisable<ufix64>.Random => Utilities.Instance;
        IStringParser<ufix64> IStringRepresentable<ufix64>.StringParser => Utilities.Instance;

        private sealed class Utilities : IMath<ufix64>, IBitConverter<ufix64>, IRandom<ufix64>, IStringParser<ufix64>
        {
            public readonly static Utilities Instance = new Utilities();

            ufix64 IMath<ufix64>.E { get; } = (ufix64)Math.E;
            ufix64 IMath<ufix64>.PI { get; } = (ufix64)Math.PI;
            ufix64 IMath<ufix64>.Epsilon { get; } = 1;
            ufix64 IMath<ufix64>.MaxValue => MaxValue;
            ufix64 IMath<ufix64>.MinValue => MinValue;
            ufix64 IMath<ufix64>.MaxUnit { get; } = ScalingFactor;
            ufix64 IMath<ufix64>.MinUnit { get; } = 0;
            ufix64 IMath<ufix64>.Zero { get; } = 0;
            ufix64 IMath<ufix64>.One { get; } = ScalingFactor;
            bool IMath<ufix64>.IsSigned { get; } = false;
            bool IMath<ufix64>.IsReal { get; } = true;

            bool IMath<ufix64>.IsGreaterThan(in ufix64 x, in ufix64 y) => x > y;
            bool IMath<ufix64>.IsGreaterThanOrEqualTo(in ufix64 x, in ufix64 y) => x >= y;
            bool IMath<ufix64>.IsLessThan(in ufix64 x, in ufix64 y) => x < y;
            bool IMath<ufix64>.IsLessThanOrEqualTo(in ufix64 x, in ufix64 y) => x <= y;
            double IMath<ufix64>.ToDouble(in ufix64 x, in double offset) => CheckedArithmetic.Add((double)x, offset);
            float IMath<ufix64>.ToSingle(in ufix64 x, in float offset) => CheckedArithmetic.Add((float)x, offset);
            int IMath<ufix64>.Sign(in ufix64 x) => x._scaledValue == 0 ? 0 : 1;
            ufix64 IMath<ufix64>.Abs(in ufix64 x) => x;
            ufix64 IMath<ufix64>.Acos(in ufix64 x) => (ufix64)Math.Acos((double)x);
            ufix64 IMath<ufix64>.Acosh(in ufix64 x) => (ufix64)Math.Acosh((double)x);
            ufix64 IMath<ufix64>.Add(in ufix64 x, in ufix64 y) => x + y;
            ufix64 IMath<ufix64>.Asin(in ufix64 x) => (ufix64)Math.Asin((double)x);
            ufix64 IMath<ufix64>.Asinh(in ufix64 x) => (ufix64)Math.Asinh((double)x);
            ufix64 IMath<ufix64>.Atan(in ufix64 x) => (ufix64)Math.Atan((double)x);
            ufix64 IMath<ufix64>.Atan2(in ufix64 x, in ufix64 y) => (ufix64)Math.Atan2((double)x, (double)y);
            ufix64 IMath<ufix64>.Atanh(in ufix64 x) => (ufix64)Math.Atanh((double)x);
            ufix64 IMath<ufix64>.Cbrt(in ufix64 x) => (ufix64)Math.Cbrt((double)x);
            ufix64 IMath<ufix64>.Ceiling(in ufix64 x) => x._scaledValue % ScalingFactor != 0 ? new ufix64((x._scaledValue / ScalingFactor * ScalingFactor) + ScalingFactor) : new ufix64(x._scaledValue / ScalingFactor * ScalingFactor);
            ufix64 IMath<ufix64>.Clamp(in ufix64 x, in ufix64 bound1, in ufix64 bound2) => bound1 > bound2 ? Math.Min(bound1._scaledValue, Math.Max(bound2._scaledValue, x._scaledValue)) : Math.Min(bound2._scaledValue, Math.Max(bound1._scaledValue, x._scaledValue));
            ufix64 IMath<ufix64>.Convert(in byte value) => value;
            ufix64 IMath<ufix64>.Cos(in ufix64 x) => (ufix64)Math.Cos((double)x);
            ufix64 IMath<ufix64>.Cosh(in ufix64 x) => (ufix64)Math.Cosh((double)x);
            ufix64 IMath<ufix64>.DegreesToRadians(in ufix64 x) => (ufix64)CheckedArithmetic.Multiply((double)x, AngleConstants.RadiansPerDegree);
            ufix64 IMath<ufix64>.DegreesToTurns(in ufix64 x) => (ufix64)CheckedArithmetic.Multiply((double)x, AngleConstants.TurnsPerDegree);
            ufix64 IMath<ufix64>.Divide(in ufix64 x, in ufix64 y) => x / y;
            ufix64 IMath<ufix64>.Exp(in ufix64 x) => (ufix64)Math.Exp((double)x);
            ufix64 IMath<ufix64>.Floor(in ufix64 x) => new ufix64(x._scaledValue / ScalingFactor * ScalingFactor);
            ufix64 IMath<ufix64>.IEEERemainder(in ufix64 x, in ufix64 y) => (ufix64)Math.IEEERemainder((double)x, (double)y);
            ufix64 IMath<ufix64>.Log(in ufix64 x) => (ufix64)Math.Log((double)x);
            ufix64 IMath<ufix64>.Log(in ufix64 x, in ufix64 y) => (ufix64)Math.Log((double)x, (double)y);
            ufix64 IMath<ufix64>.Log10(in ufix64 x) => (ufix64)Math.Log10((double)x);
            ufix64 IMath<ufix64>.Max(in ufix64 x, in ufix64 y) => new ufix64(Math.Max(x._scaledValue, y._scaledValue));
            ufix64 IMath<ufix64>.Min(in ufix64 x, in ufix64 y) => new ufix64(Math.Min(x._scaledValue, y._scaledValue));
            ufix64 IMath<ufix64>.Multiply(in ufix64 x, in ufix64 y) => x * y;
            ufix64 IMath<ufix64>.Negative(in ufix64 x) => -x;
            ufix64 IMath<ufix64>.Positive(in ufix64 x) => +x;
            ufix64 IMath<ufix64>.Pow(in ufix64 x, in byte y) => (ufix64)Math.Pow((double)x, y);
            ufix64 IMath<ufix64>.Pow(in ufix64 x, in ufix64 y) => (ufix64)Math.Pow((double)x, (double)y);
            ufix64 IMath<ufix64>.RadiansToDegrees(in ufix64 x) => (ufix64)CheckedArithmetic.Multiply((double)x, AngleConstants.DegreesPerRadian);
            ufix64 IMath<ufix64>.RadiansToTurns(in ufix64 x) => (ufix64)CheckedArithmetic.Multiply((double)x, AngleConstants.TurnsPerRadian);
            ufix64 IMath<ufix64>.Remainder(in ufix64 x, in ufix64 y) => x % y;
            ufix64 IMath<ufix64>.Round(in ufix64 x) => (ufix64)Math.Round((double)x);
            ufix64 IMath<ufix64>.Round(in ufix64 x, in int digits) => (ufix64)Math.Round((double)x, digits);
            ufix64 IMath<ufix64>.Round(in ufix64 x, in int digits, in MidpointRounding mode) => (ufix64)Math.Round((double)x, digits, mode);
            ufix64 IMath<ufix64>.Round(in ufix64 x, in MidpointRounding mode) => (ufix64)Math.Round((double)x, mode);
            ufix64 IMath<ufix64>.Sin(in ufix64 x) => (ufix64)Math.Sin((double)x);
            ufix64 IMath<ufix64>.Sinh(in ufix64 x) => (ufix64)Math.Sinh((double)x);
            ufix64 IMath<ufix64>.Sqrt(in ufix64 x) => (ufix64)Math.Sqrt((double)x);
            ufix64 IMath<ufix64>.Subtract(in ufix64 x, in ufix64 y) => x - y;
            ufix64 IMath<ufix64>.Tan(in ufix64 x) => (ufix64)Math.Tan((double)x);
            ufix64 IMath<ufix64>.Tanh(in ufix64 x) => (ufix64)Math.Tanh((double)x);
            ufix64 IMath<ufix64>.Truncate(in ufix64 x) => new ufix64(x._scaledValue / ScalingFactor * ScalingFactor);
            ufix64 IMath<ufix64>.TurnsToDegrees(in ufix64 x) => (ufix64)CheckedArithmetic.Multiply((double)x, AngleConstants.DegreesPerTurn);
            ufix64 IMath<ufix64>.TurnsToRadians(in ufix64 x) => (ufix64)CheckedArithmetic.Multiply((double)x, AngleConstants.DegreesPerRadian);

            ufix64 IBitConverter<ufix64>.Read(in IReadOnlyStream<byte> stream) => new ufix64(BitConverter.ToUInt64(stream.Read(sizeof(ulong))));
            void IBitConverter<ufix64>.Write(ufix64 value, in IWriteOnlyStream<byte> stream) => stream.Write(BitConverter.GetBytes(value._scaledValue));

            ufix64 IRandom<ufix64>.GetNext(Random random) => new ufix64(random.NextUInt64());
            ufix64 IRandom<ufix64>.GetNext(Random random, in ufix64 bound1, in ufix64 bound2) => new ufix64(random.NextUInt64(bound1._scaledValue, bound2._scaledValue));

            ufix64 IStringParser<ufix64>.Parse(in string s) => Parse(s);
            ufix64 IStringParser<ufix64>.Parse(in string s, in NumberStyles numberStyles, in IFormatProvider formatProvider) => Parse(s, numberStyles, formatProvider);
        }
    }
}
