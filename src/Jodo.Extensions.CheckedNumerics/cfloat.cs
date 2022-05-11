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
    public readonly struct cfloat : INumeric<cfloat>
    {
        public static readonly cfloat Epsilon = new cfloat(float.Epsilon);
        public static readonly cfloat MaxValue = new cfloat(float.MaxValue);
        public static readonly cfloat MinValue = new cfloat(float.MinValue);

        private readonly float _value;

        public cfloat(float value)
        {
            if (float.IsFinite(value)) _value = value;
            else if (float.IsPositiveInfinity(value)) _value = float.MaxValue;
            else if (float.IsNegativeInfinity(value)) _value = float.MinValue;
            else _value = 0f;
        }

        private cfloat(SerializationInfo info, StreamingContext context) : this(info.GetSingle(nameof(cfloat))) { }
        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context) => info.AddValue(nameof(cfloat), _value);

        public int CompareTo(cfloat other) => _value.CompareTo(other._value);
        public int CompareTo(object? obj) => obj is cfloat other ? CompareTo(other) : 1;
        public bool Equals(cfloat other) => _value == other._value;
        public override bool Equals(object? obj) => obj is cfloat other && Equals(other);
        public override int GetHashCode() => _value.GetHashCode();
        public override string ToString() => _value.ToString();
        public string ToString(string format, IFormatProvider formatProvider) => _value.ToString(format, formatProvider);

        public static bool IsNormal(cfloat d) => float.IsNormal(d._value);
        public static bool IsSubnormal(cfloat d) => float.IsSubnormal(d._value);
        public static bool TryParse(string s, IFormatProvider provider, out cfloat result) => Try.Run(() => Parse(s, provider), out result);
        public static bool TryParse(string s, NumberStyles style, IFormatProvider provider, out cfloat result) => Try.Run(() => Parse(s, style, provider), out result);
        public static bool TryParse(string s, NumberStyles style, out cfloat result) => Try.Run(() => Parse(s, style), out result);
        public static bool TryParse(string s, out cfloat result) => Try.Run(() => Parse(s), out result);
        public static cfloat Parse(string s) => float.Parse(s);
        public static cfloat Parse(string s, IFormatProvider provider) => float.Parse(s, provider);
        public static cfloat Parse(string s, NumberStyles style) => float.Parse(s, style);
        public static cfloat Parse(string s, NumberStyles style, IFormatProvider provider) => float.Parse(s, style, provider);

        public static explicit operator cfloat(decimal value) => new cfloat(CheckedConvert.ToSingle(value));
        public static explicit operator cfloat(double value) => new cfloat(CheckedConvert.ToSingle(value));
        public static implicit operator cfloat(byte value) => new cfloat(value);
        public static implicit operator cfloat(sbyte value) => new cfloat(value);
        public static implicit operator cfloat(float value) => new cfloat(value);
        public static implicit operator cfloat(int value) => new cfloat(value);
        public static implicit operator cfloat(long value) => new cfloat(value);
        public static implicit operator cfloat(short value) => new cfloat(value);
        public static implicit operator cfloat(uint value) => new cfloat(value);
        public static implicit operator cfloat(ulong value) => new cfloat(value);
        public static implicit operator cfloat(ushort value) => new cfloat(value);

        public static explicit operator byte(cfloat value) => CheckedConvert.ToByte(value._value);
        public static explicit operator decimal(cfloat value) => CheckedConvert.ToDecimal(value._value);
        public static explicit operator int(cfloat value) => CheckedConvert.ToInt32(value._value);
        public static explicit operator long(cfloat value) => CheckedConvert.ToInt64(value._value);
        public static explicit operator sbyte(cfloat value) => CheckedConvert.ToSByte(value._value);
        public static explicit operator short(cfloat value) => CheckedConvert.ToInt16(value._value);
        public static explicit operator uint(cfloat value) => CheckedConvert.ToUInt32(value._value);
        public static explicit operator ulong(cfloat value) => CheckedConvert.ToUInt64(value._value);
        public static explicit operator ushort(cfloat value) => CheckedConvert.ToUInt16(value._value);
        public static implicit operator double(cfloat value) => value._value;
        public static implicit operator float(cfloat value) => value._value;

        public static bool operator !=(cfloat left, cfloat right) => left._value != right._value;
        public static bool operator <(cfloat left, cfloat right) => left._value < right._value;
        public static bool operator <=(cfloat left, cfloat right) => left._value <= right._value;
        public static bool operator ==(cfloat left, cfloat right) => left._value == right._value;
        public static bool operator >(cfloat left, cfloat right) => left._value > right._value;
        public static bool operator >=(cfloat left, cfloat right) => left._value >= right._value;
        public static cfloat operator %(cfloat left, cfloat right) => CheckedArithmetic.Remainder(left._value, right._value);
        public static cfloat operator -(cfloat left, cfloat right) => CheckedArithmetic.Subtract(left._value, right._value);
        public static cfloat operator --(cfloat value) => value - 1;
        public static cfloat operator -(cfloat value) => -value._value;
        public static cfloat operator *(cfloat left, cfloat right) => CheckedArithmetic.Multiply(left._value, right._value);
        public static cfloat operator /(cfloat left, cfloat right) => CheckedArithmetic.Divide(left._value, right._value);
        public static cfloat operator +(cfloat left, cfloat right) => CheckedArithmetic.Add(left._value, right._value);
        public static cfloat operator +(cfloat value) => value;
        public static cfloat operator ++(cfloat value) => value + 1;

        IBitConverter<cfloat> IBitConvertible<cfloat>.BitConverter => Utilities.Instance;
        IMath<cfloat> INumeric<cfloat>.Math => Utilities.Instance;
        IRandom<cfloat> IRandomisable<cfloat>.Random => Utilities.Instance;
        IStringParser<cfloat> IStringRepresentable<cfloat>.StringParser => Utilities.Instance;

        private sealed class Utilities : IMath<cfloat>, IBitConverter<cfloat>, IRandom<cfloat>, IStringParser<cfloat>
        {
            public readonly static Utilities Instance = new Utilities();

            cfloat IMath<cfloat>.E { get; } = MathF.E;
            cfloat IMath<cfloat>.PI { get; } = MathF.PI;
            cfloat IMath<cfloat>.Epsilon => Epsilon;
            cfloat IMath<cfloat>.MaxValue => MaxValue;
            cfloat IMath<cfloat>.MinValue => MinValue;
            cfloat IMath<cfloat>.MaxUnit { get; } = 1;
            cfloat IMath<cfloat>.MinUnit { get; } = -1;
            cfloat IMath<cfloat>.Zero { get; } = 0;
            cfloat IMath<cfloat>.One { get; } = 1;
            bool IMath<cfloat>.IsSigned { get; } = true;
            bool IMath<cfloat>.IsReal { get; } = true;

            bool IMath<cfloat>.IsGreaterThan(in cfloat x, in cfloat y) => x > y;
            bool IMath<cfloat>.IsGreaterThanOrEqualTo(in cfloat x, in cfloat y) => x >= y;
            bool IMath<cfloat>.IsLessThan(in cfloat x, in cfloat y) => x < y;
            bool IMath<cfloat>.IsLessThanOrEqualTo(in cfloat x, in cfloat y) => x <= y;
            cfloat IMath<cfloat>.Abs(in cfloat x) => MathF.Abs(x._value);
            cfloat IMath<cfloat>.Acos(in cfloat x) => MathF.Acos(x._value);
            cfloat IMath<cfloat>.Acosh(in cfloat x) => MathF.Acosh(x._value);
            cfloat IMath<cfloat>.Add(in cfloat x, in cfloat y) => x + y;
            cfloat IMath<cfloat>.Asin(in cfloat x) => MathF.Asin(x._value);
            cfloat IMath<cfloat>.Asinh(in cfloat x) => MathF.Asinh(x._value);
            cfloat IMath<cfloat>.Atan(in cfloat x) => MathF.Atan(x._value);
            cfloat IMath<cfloat>.Atan2(in cfloat x, in cfloat y) => MathF.Atan2(x._value, y._value);
            cfloat IMath<cfloat>.Atanh(in cfloat x) => MathF.Atanh(x._value);
            cfloat IMath<cfloat>.Cbrt(in cfloat x) => MathF.Cbrt(x._value);
            cfloat IMath<cfloat>.Ceiling(in cfloat x) => MathF.Ceiling(x._value);
            cfloat IMath<cfloat>.Clamp(in cfloat x, in cfloat bound1, in cfloat bound2) => bound1 > bound2 ? MathF.Min(bound1._value, MathF.Max(bound2._value, x._value)) : MathF.Min(bound2._value, MathF.Max(bound1._value, x._value));
            cfloat IMath<cfloat>.Convert(in byte value) => value;
            cfloat IMath<cfloat>.Cos(in cfloat x) => MathF.Cos(x._value);
            cfloat IMath<cfloat>.Cosh(in cfloat x) => MathF.Cosh(x._value);
            cfloat IMath<cfloat>.DegreesToRadians(in cfloat x) => x._value * AngleConstantsF.RadiansPerDegree;
            cfloat IMath<cfloat>.DegreesToTurns(in cfloat x) => x._value * AngleConstantsF.TurnsPerDegree;
            cfloat IMath<cfloat>.Divide(in cfloat x, in cfloat y) => x / y;
            cfloat IMath<cfloat>.Exp(in cfloat x) => MathF.Exp(x._value);
            cfloat IMath<cfloat>.Floor(in cfloat x) => MathF.Floor(x._value);
            cfloat IMath<cfloat>.IEEERemainder(in cfloat x, in cfloat y) => MathF.IEEERemainder(x._value, y._value);
            cfloat IMath<cfloat>.Log(in cfloat x) => MathF.Log(x._value);
            cfloat IMath<cfloat>.Log(in cfloat x, in cfloat y) => MathF.Log(x._value, y._value);
            cfloat IMath<cfloat>.Log10(in cfloat x) => MathF.Log10(x._value);
            cfloat IMath<cfloat>.Max(in cfloat x, in cfloat y) => MathF.Max(x._value, y._value);
            cfloat IMath<cfloat>.Min(in cfloat x, in cfloat y) => MathF.Min(x._value, y._value);
            cfloat IMath<cfloat>.Multiply(in cfloat x, in cfloat y) => x * y;
            cfloat IMath<cfloat>.Negative(in cfloat x) => -x;
            cfloat IMath<cfloat>.Positive(in cfloat x) => +x;
            cfloat IMath<cfloat>.Pow(in cfloat x, in byte y) => MathF.Pow(x._value, y);
            cfloat IMath<cfloat>.Pow(in cfloat x, in cfloat y) => MathF.Pow(x._value, y._value);
            cfloat IMath<cfloat>.RadiansToDegrees(in cfloat x) => x._value * AngleConstantsF.DegreesPerRadian;
            cfloat IMath<cfloat>.RadiansToTurns(in cfloat x) => x._value * AngleConstantsF.TurnsPerRadian;
            cfloat IMath<cfloat>.Remainder(in cfloat x, in cfloat y) => x % y;
            cfloat IMath<cfloat>.Round(in cfloat x) => MathF.Round(x._value);
            cfloat IMath<cfloat>.Round(in cfloat x, in int digits) => MathF.Round(x._value, digits);
            cfloat IMath<cfloat>.Round(in cfloat x, in int digits, in MidpointRounding mode) => MathF.Round(x._value, digits, mode);
            cfloat IMath<cfloat>.Round(in cfloat x, in MidpointRounding mode) => MathF.Round(x._value, mode);
            cfloat IMath<cfloat>.Sin(in cfloat x) => MathF.Sin(x._value);
            cfloat IMath<cfloat>.Sinh(in cfloat x) => MathF.Sinh(x._value);
            cfloat IMath<cfloat>.Sqrt(in cfloat x) => MathF.Sqrt(x._value);
            cfloat IMath<cfloat>.Subtract(in cfloat x, in cfloat y) => x - y;
            cfloat IMath<cfloat>.Tan(in cfloat x) => MathF.Tan(x._value);
            cfloat IMath<cfloat>.Tanh(in cfloat x) => MathF.Tanh(x._value);
            cfloat IMath<cfloat>.Truncate(in cfloat x) => MathF.Truncate(x._value);
            cfloat IMath<cfloat>.TurnsToDegrees(in cfloat x) => x._value * AngleConstantsF.DegreesPerTurn;
            cfloat IMath<cfloat>.TurnsToRadians(in cfloat x) => x._value * AngleConstantsF.RadiansPerTurn;
            double IMath<cfloat>.ToDouble(in cfloat x, in double offset) => CheckedArithmetic.Add(x._value, offset);
            float IMath<cfloat>.ToSingle(in cfloat x, in float offset) => CheckedArithmetic.Add(x._value, offset);
            int IMath<cfloat>.Sign(in cfloat x) => MathF.Sign(x._value);

            cfloat IBitConverter<cfloat>.Read(in IReadOnlyStream<byte> stream) => BitConverter.ToSingle(stream.Read(sizeof(float)));
            void IBitConverter<cfloat>.Write(cfloat value, in IWriteOnlyStream<byte> stream) => stream.Write(BitConverter.GetBytes(value._value));

            cfloat IRandom<cfloat>.GetNext(Random random) => random.NextSingle(float.MinValue, float.MaxValue);
            cfloat IRandom<cfloat>.GetNext(Random random, in cfloat bound1, in cfloat bound2) => random.NextSingle(bound1._value, bound2._value);

            cfloat IStringParser<cfloat>.Parse(in string s) => Parse(s);
            cfloat IStringParser<cfloat>.Parse(in string s, in NumberStyles numberStyles, in IFormatProvider formatProvider) => Parse(s, numberStyles, formatProvider);
        }
    }
}
