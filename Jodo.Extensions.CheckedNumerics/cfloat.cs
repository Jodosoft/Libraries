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
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;

namespace Jodo.Extensions.CheckedNumerics
{
    [Serializable]
    [DebuggerDisplay("{ToString(),nq}")]
    [SuppressMessage("Style", "IDE1006:Naming Styles")]
    public readonly struct cfloat : INumeric<cfloat>
    {
        public static readonly cfloat Epsilon = new cfloat(float.Epsilon);
        public static readonly cfloat MaxValue = new cfloat(float.MaxValue);
        public static readonly cfloat MinValue = new cfloat(float.MinValue);

        private readonly float _value;

        public cfloat(float value)
        {
            _value =
                float.IsFinite(value) ? value :
                float.IsPositiveInfinity(value) ? float.MaxValue :
                float.IsNegativeInfinity(value) ? float.MinValue :
                0f;
        }

        private cfloat(SerializationInfo info, StreamingContext _) : this(info.GetSingle(nameof(cfloat))) { }
        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext _) => info.AddValue(nameof(cfloat), _value);

        public bool Equals(cfloat other) => _value == other._value;
        public bool TryFormat(Span<char> destination, out int charsWritten, ReadOnlySpan<char> format = default, IFormatProvider? provider = null) => _value.TryFormat(destination, out charsWritten, format, provider);
        public float Approximate(in float offset) => _value + offset;
        public int CompareTo(cfloat other) => _value.CompareTo(other._value);
        public override int GetHashCode() => _value.GetHashCode();
        public override string ToString() => _value.ToString();
        public string ToString(string format, IFormatProvider formatProvider) => _value.ToString(format, formatProvider);

        public int CompareTo(object? obj)
        {
            if (obj == null) return 1;
            try { return CompareTo((cfloat)obj); }
            catch (InvalidCastException) { return 1; }
        }

        public override bool Equals(object? obj)
        {
            if (obj == null) return false;
            try { return Equals((cfloat)obj); }
            catch (InvalidCastException) { return false; }
        }

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
        public static cfloat operator %(cfloat left, cfloat right) => CheckedMath.Remainder(left._value, right._value);
        public static cfloat operator -(cfloat left, cfloat right) => CheckedMath.Subtract(left._value, right._value);
        public static cfloat operator --(cfloat value) => value - 1;
        public static cfloat operator -(cfloat value) => -value._value;
        public static cfloat operator *(cfloat left, cfloat right) => CheckedMath.Multiply(left._value, right._value);
        public static cfloat operator /(cfloat left, cfloat right) => CheckedMath.Divide(left._value, right._value);
        public static cfloat operator +(cfloat left, cfloat right) => CheckedMath.Add(left._value, right._value);
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

            [MethodImpl(MethodImplOptions.AggressiveInlining)] bool IMath<cfloat>.IsGreaterThan(in cfloat x, in cfloat y) => x > y;
            [MethodImpl(MethodImplOptions.AggressiveInlining)] bool IMath<cfloat>.IsGreaterThanOrEqualTo(in cfloat x, in cfloat y) => x >= y;
            [MethodImpl(MethodImplOptions.AggressiveInlining)] bool IMath<cfloat>.IsLessThan(in cfloat x, in cfloat y) => x < y;
            [MethodImpl(MethodImplOptions.AggressiveInlining)] bool IMath<cfloat>.IsLessThanOrEqualTo(in cfloat x, in cfloat y) => x <= y;
            [MethodImpl(MethodImplOptions.AggressiveInlining)] cfloat IMath<cfloat>.Abs(in cfloat x) => MathF.Abs(x._value);
            [MethodImpl(MethodImplOptions.AggressiveInlining)] cfloat IMath<cfloat>.Acos(in cfloat x) => MathF.Acos(x._value);
            [MethodImpl(MethodImplOptions.AggressiveInlining)] cfloat IMath<cfloat>.Acosh(in cfloat x) => MathF.Acosh(x._value);
            [MethodImpl(MethodImplOptions.AggressiveInlining)] cfloat IMath<cfloat>.Add(in cfloat x, in cfloat y) => x + y;
            [MethodImpl(MethodImplOptions.AggressiveInlining)] cfloat IMath<cfloat>.Asin(in cfloat x) => MathF.Asin(x._value);
            [MethodImpl(MethodImplOptions.AggressiveInlining)] cfloat IMath<cfloat>.Asinh(in cfloat x) => MathF.Asinh(x._value);
            [MethodImpl(MethodImplOptions.AggressiveInlining)] cfloat IMath<cfloat>.Atan(in cfloat x) => MathF.Atan(x._value);
            [MethodImpl(MethodImplOptions.AggressiveInlining)] cfloat IMath<cfloat>.Atan2(in cfloat x, in cfloat y) => MathF.Atan2(x._value, y._value);
            [MethodImpl(MethodImplOptions.AggressiveInlining)] cfloat IMath<cfloat>.Atanh(in cfloat x) => MathF.Atanh(x._value);
            [MethodImpl(MethodImplOptions.AggressiveInlining)] cfloat IMath<cfloat>.Cbrt(in cfloat x) => MathF.Cbrt(x._value);
            [MethodImpl(MethodImplOptions.AggressiveInlining)] cfloat IMath<cfloat>.Ceiling(in cfloat x) => MathF.Ceiling(x._value);
            [MethodImpl(MethodImplOptions.AggressiveInlining)] cfloat IMath<cfloat>.Clamp(in cfloat x, in cfloat bound1, in cfloat bound2) => bound1 > bound2 ? MathF.Min(bound1._value, MathF.Max(bound2._value, x._value)) : MathF.Min(bound2._value, MathF.Max(bound1._value, x._value));
            [MethodImpl(MethodImplOptions.AggressiveInlining)] cfloat IMath<cfloat>.Convert(in byte value) => value;
            [MethodImpl(MethodImplOptions.AggressiveInlining)] cfloat IMath<cfloat>.Cos(in cfloat x) => MathF.Cos(x._value);
            [MethodImpl(MethodImplOptions.AggressiveInlining)] cfloat IMath<cfloat>.Cosh(in cfloat x) => MathF.Cosh(x._value);
            [MethodImpl(MethodImplOptions.AggressiveInlining)] cfloat IMath<cfloat>.DegreesToRadians(in cfloat x) => x._value * Constants.RadiansPerDegreeF;
            [MethodImpl(MethodImplOptions.AggressiveInlining)] cfloat IMath<cfloat>.DegreesToTurns(in cfloat x) => x._value * Constants.TurnsPerDegreeF;
            [MethodImpl(MethodImplOptions.AggressiveInlining)] cfloat IMath<cfloat>.Divide(in cfloat x, in cfloat y) => x / y;
            [MethodImpl(MethodImplOptions.AggressiveInlining)] cfloat IMath<cfloat>.Exp(in cfloat x) => MathF.Exp(x._value);
            [MethodImpl(MethodImplOptions.AggressiveInlining)] cfloat IMath<cfloat>.Floor(in cfloat x) => MathF.Floor(x._value);
            [MethodImpl(MethodImplOptions.AggressiveInlining)] cfloat IMath<cfloat>.IEEERemainder(in cfloat x, in cfloat y) => MathF.IEEERemainder(x._value, y._value);
            [MethodImpl(MethodImplOptions.AggressiveInlining)] cfloat IMath<cfloat>.Log(in cfloat x) => MathF.Log(x._value);
            [MethodImpl(MethodImplOptions.AggressiveInlining)] cfloat IMath<cfloat>.Log(in cfloat x, in cfloat y) => MathF.Log(x._value, y._value);
            [MethodImpl(MethodImplOptions.AggressiveInlining)] cfloat IMath<cfloat>.Log10(in cfloat x) => MathF.Log10(x._value);
            [MethodImpl(MethodImplOptions.AggressiveInlining)] cfloat IMath<cfloat>.Max(in cfloat x, in cfloat y) => MathF.Max(x._value, y._value);
            [MethodImpl(MethodImplOptions.AggressiveInlining)] cfloat IMath<cfloat>.Min(in cfloat x, in cfloat y) => MathF.Min(x._value, y._value);
            [MethodImpl(MethodImplOptions.AggressiveInlining)] cfloat IMath<cfloat>.Multiply(in cfloat x, in cfloat y) => x * y;
            [MethodImpl(MethodImplOptions.AggressiveInlining)] cfloat IMath<cfloat>.Negative(in cfloat x) => -x;
            [MethodImpl(MethodImplOptions.AggressiveInlining)] cfloat IMath<cfloat>.Positive(in cfloat x) => +x;
            [MethodImpl(MethodImplOptions.AggressiveInlining)] cfloat IMath<cfloat>.Pow(in cfloat x, in byte y) => MathF.Pow(x._value, y);
            [MethodImpl(MethodImplOptions.AggressiveInlining)] cfloat IMath<cfloat>.Pow(in cfloat x, in cfloat y) => MathF.Pow(x._value, y._value);
            [MethodImpl(MethodImplOptions.AggressiveInlining)] cfloat IMath<cfloat>.RadiansToDegrees(in cfloat x) => x._value * Constants.DegreesPerRadianF;
            [MethodImpl(MethodImplOptions.AggressiveInlining)] cfloat IMath<cfloat>.RadiansToTurns(in cfloat x) => x._value * Constants.TurnsPerRadianF;
            [MethodImpl(MethodImplOptions.AggressiveInlining)] cfloat IMath<cfloat>.Remainder(in cfloat x, in cfloat y) => x % y;
            [MethodImpl(MethodImplOptions.AggressiveInlining)] cfloat IMath<cfloat>.Round(in cfloat x) => MathF.Round(x._value);
            [MethodImpl(MethodImplOptions.AggressiveInlining)] cfloat IMath<cfloat>.Round(in cfloat x, in int digits) => MathF.Round(x._value, digits);
            [MethodImpl(MethodImplOptions.AggressiveInlining)] cfloat IMath<cfloat>.Round(in cfloat x, in int digits, in MidpointRounding mode) => MathF.Round(x._value, digits, mode);
            [MethodImpl(MethodImplOptions.AggressiveInlining)] cfloat IMath<cfloat>.Round(in cfloat x, in MidpointRounding mode) => MathF.Round(x._value, mode);
            [MethodImpl(MethodImplOptions.AggressiveInlining)] cfloat IMath<cfloat>.Sin(in cfloat x) => MathF.Sin(x._value);
            [MethodImpl(MethodImplOptions.AggressiveInlining)] cfloat IMath<cfloat>.Sinh(in cfloat x) => MathF.Sinh(x._value);
            [MethodImpl(MethodImplOptions.AggressiveInlining)] cfloat IMath<cfloat>.Sqrt(in cfloat x) => MathF.Sqrt(x._value);
            [MethodImpl(MethodImplOptions.AggressiveInlining)] cfloat IMath<cfloat>.Subtract(in cfloat x, in cfloat y) => x - y;
            [MethodImpl(MethodImplOptions.AggressiveInlining)] cfloat IMath<cfloat>.Tan(in cfloat x) => MathF.Tan(x._value);
            [MethodImpl(MethodImplOptions.AggressiveInlining)] cfloat IMath<cfloat>.Tanh(in cfloat x) => MathF.Tanh(x._value);
            [MethodImpl(MethodImplOptions.AggressiveInlining)] cfloat IMath<cfloat>.Truncate(in cfloat x) => MathF.Truncate(x._value);
            [MethodImpl(MethodImplOptions.AggressiveInlining)] cfloat IMath<cfloat>.TurnsToDegrees(in cfloat x) => x._value * Constants.DegreesPerTurnF;
            [MethodImpl(MethodImplOptions.AggressiveInlining)] cfloat IMath<cfloat>.TurnsToRadians(in cfloat x) => x._value * Constants.RadiansPerTurnF;
            [MethodImpl(MethodImplOptions.AggressiveInlining)] double IMath<cfloat>.ToDouble(in cfloat x, in double offset) => CheckedMath.Add(x._value, offset);
            [MethodImpl(MethodImplOptions.AggressiveInlining)] float IMath<cfloat>.ToSingle(in cfloat x, in float offset) => CheckedMath.Add(x._value, offset);
            [MethodImpl(MethodImplOptions.AggressiveInlining)] int IMath<cfloat>.Sign(in cfloat x) => MathF.Sign(x._value);

            cfloat IBitConverter<cfloat>.Read(in IReadOnlyStream<byte> stream) => BitConverter.ToSingle(stream.Read(sizeof(float)));
            void IBitConverter<cfloat>.Write(cfloat value, in IWriteOnlyStream<byte> stream) => stream.Write(BitConverter.GetBytes(value._value));

            cfloat IRandom<cfloat>.GetNext(Random random) => random.NextSingle(float.MinValue, float.MaxValue);
            cfloat IRandom<cfloat>.GetNext(Random random, in cfloat bound1, in cfloat bound2) => random.NextSingle(bound1._value, bound2._value);

            cfloat IStringParser<cfloat>.Parse(in string s) => float.Parse(s);
            cfloat IStringParser<cfloat>.Parse(in string s, in NumberStyles numberStyles, in IFormatProvider formatProvider) => float.Parse(s, numberStyles, formatProvider);
        }
    }
}
