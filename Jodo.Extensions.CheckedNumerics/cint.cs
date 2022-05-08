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
    public readonly struct cint : INumeric<cint>
    {
        public static readonly cint MaxValue = new cint(int.MaxValue);
        public static readonly cint MinValue = new cint(int.MinValue);

        private readonly int _value;

        private cint(int value)
        {
            _value = value;
        }

        private cint(SerializationInfo info, StreamingContext _) : this(info.GetInt32(nameof(cint))) { }
        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext _) => info.AddValue(nameof(cint), _value);

        public bool Equals(cint other) => _value == other._value;
        public bool TryFormat(Span<char> destination, out int charsWritten, ReadOnlySpan<char> format = default, IFormatProvider? provider = null) => _value.TryFormat(destination, out charsWritten, format, provider);
        public float Approximate(in float offset) => _value + offset;
        public int CompareTo(cint other) => _value.CompareTo(other._value);
        public override int GetHashCode() => _value.GetHashCode();
        public override string ToString() => _value.ToString();
        public string ToString(string format, IFormatProvider formatProvider) => _value.ToString(format, formatProvider);

        public int CompareTo(object? obj)
        {
            if (obj == null) return 1;
            try { return CompareTo((cint)obj); }
            catch (InvalidCastException) { return 1; }
        }

        public override bool Equals(object? obj)
        {
            if (obj == null) return false;
            try { return Equals((cint)obj); }
            catch (InvalidCastException) { return false; }
        }

        public static explicit operator cint(in decimal value) => new cint(CheckedConvert.ToInt32(value));
        public static explicit operator cint(in double value) => new cint(CheckedConvert.ToInt32(value));
        public static explicit operator cint(in float value) => new cint(CheckedConvert.ToInt32(value));
        public static explicit operator cint(in long value) => new cint(CheckedConvert.ToInt32(value));
        public static explicit operator cint(in uint value) => new cint(CheckedConvert.ToInt32(value));
        public static explicit operator cint(in ulong value) => new cint(CheckedConvert.ToInt32(value));
        public static implicit operator cint(in byte value) => new cint(value);
        public static implicit operator cint(in int value) => new cint(value);
        public static implicit operator cint(in sbyte value) => new cint(value);
        public static implicit operator cint(in short value) => new cint(value);
        public static implicit operator cint(in ushort value) => new cint(value);

        public static explicit operator byte(in cint value) => CheckedConvert.ToByte(value._value);
        public static explicit operator sbyte(in cint value) => CheckedConvert.ToSByte(value._value);
        public static explicit operator short(in cint value) => CheckedConvert.ToInt16(value._value);
        public static explicit operator uint(in cint value) => CheckedConvert.ToUInt32(value._value);
        public static explicit operator ulong(in cint value) => CheckedConvert.ToUInt64(value._value);
        public static explicit operator ushort(in cint value) => CheckedConvert.ToUInt16(value._value);
        public static implicit operator decimal(in cint value) => value._value;
        public static implicit operator double(in cint value) => value._value;
        public static implicit operator float(in cint value) => value._value;
        public static implicit operator int(in cint value) => value._value;
        public static implicit operator long(in cint value) => value._value;

        public static bool operator !=(in cint left, in cint right) => left._value != right._value;
        public static bool operator <(in cint left, in cint right) => left._value < right._value;
        public static bool operator <=(in cint left, in cint right) => left._value <= right._value;
        public static bool operator ==(in cint left, in cint right) => left._value == right._value;
        public static bool operator >(in cint left, in cint right) => left._value > right._value;
        public static bool operator >=(in cint left, in cint right) => left._value >= right._value;
        public static cint operator %(in cint left, in cint right) => CheckedArithmetic.Remainder(left._value, right._value);
        public static cint operator &(in cint left, in cint right) => left._value & right._value;
        public static cint operator -(in cint left, in cint right) => CheckedArithmetic.Subtract(left._value, right._value);
        public static cint operator --(in cint value) => value - 1;
        public static cint operator -(in cint value) => -value._value;
        public static cint operator *(in cint left, in cint right) => CheckedArithmetic.Multiply(left._value, right._value);
        public static cint operator /(in cint left, in cint right) => CheckedArithmetic.Divide(left._value, right._value);
        public static cint operator ^(in cint left, in cint right) => left._value ^ right._value;
        public static cint operator |(in cint left, in cint right) => left._value | right._value;
        public static cint operator ~(in cint value) => ~value._value;
        public static cint operator +(in cint left, in cint right) => CheckedArithmetic.Add(left._value, right._value);
        public static cint operator +(in cint value) => value;
        public static cint operator ++(in cint value) => value + 1;
        public static cint operator <<(in cint left, in int right) => left._value << right;
        public static cint operator >>(in cint left, in int right) => left._value >> right;

        IBitConverter<cint> IBitConvertible<cint>.BitConverter => Utilities.Instance;
        IMath<cint> INumeric<cint>.Math => Utilities.Instance;
        IRandom<cint> IRandomisable<cint>.Random => Utilities.Instance;
        IStringParser<cint> IStringRepresentable<cint>.StringParser => Utilities.Instance;

        private sealed class Utilities : IMath<cint>, IBitConverter<cint>, IRandom<cint>, IStringParser<cint>
        {
            public readonly static Utilities Instance = new Utilities();

            cint IMath<cint>.E { get; } = 3;
            cint IMath<cint>.PI { get; } = 3;
            cint IMath<cint>.Epsilon { get; } = 1;
            cint IMath<cint>.MaxValue => MaxValue;
            cint IMath<cint>.MinValue => MinValue;
            cint IMath<cint>.MaxUnit { get; } = 1;
            cint IMath<cint>.MinUnit { get; } = -1;
            cint IMath<cint>.Zero { get; } = 0;
            cint IMath<cint>.One { get; } = 1;
            bool IMath<cint>.IsSigned { get; } = true;
            bool IMath<cint>.IsReal { get; } = false;

            [MethodImpl(MethodImplOptions.AggressiveInlining)] bool IMath<cint>.IsGreaterThan(in cint x, in cint y) => x > y;
            [MethodImpl(MethodImplOptions.AggressiveInlining)] bool IMath<cint>.IsGreaterThanOrEqualTo(in cint x, in cint y) => x >= y;
            [MethodImpl(MethodImplOptions.AggressiveInlining)] bool IMath<cint>.IsLessThan(in cint x, in cint y) => x < y;
            [MethodImpl(MethodImplOptions.AggressiveInlining)] bool IMath<cint>.IsLessThanOrEqualTo(in cint x, in cint y) => x <= y;
            [MethodImpl(MethodImplOptions.AggressiveInlining)] cint IMath<cint>.Abs(in cint x) => Math.Abs(x._value);
            [MethodImpl(MethodImplOptions.AggressiveInlining)] cint IMath<cint>.Acos(in cint x) => (cint)Math.Acos(x._value);
            [MethodImpl(MethodImplOptions.AggressiveInlining)] cint IMath<cint>.Acosh(in cint x) => (cint)Math.Acosh(x._value);
            [MethodImpl(MethodImplOptions.AggressiveInlining)] cint IMath<cint>.Add(in cint x, in cint y) => x + y;
            [MethodImpl(MethodImplOptions.AggressiveInlining)] cint IMath<cint>.Asin(in cint x) => (cint)Math.Asin(x._value);
            [MethodImpl(MethodImplOptions.AggressiveInlining)] cint IMath<cint>.Asinh(in cint x) => (cint)Math.Asinh(x._value);
            [MethodImpl(MethodImplOptions.AggressiveInlining)] cint IMath<cint>.Atan(in cint x) => (cint)Math.Atan(x._value);
            [MethodImpl(MethodImplOptions.AggressiveInlining)] cint IMath<cint>.Atan2(in cint x, in cint y) => (cint)Math.Atan2(x._value, y._value);
            [MethodImpl(MethodImplOptions.AggressiveInlining)] cint IMath<cint>.Atanh(in cint x) => (cint)Math.Atanh(x._value);
            [MethodImpl(MethodImplOptions.AggressiveInlining)] cint IMath<cint>.Cbrt(in cint x) => (cint)Math.Cbrt(x._value);
            [MethodImpl(MethodImplOptions.AggressiveInlining)] cint IMath<cint>.Ceiling(in cint x) => x;
            [MethodImpl(MethodImplOptions.AggressiveInlining)] cint IMath<cint>.Clamp(in cint x, in cint bound1, in cint bound2) => bound1 > bound2 ? Math.Min(bound1._value, Math.Max(bound2._value, x._value)) : Math.Min(bound2._value, Math.Max(bound1._value, x._value));
            [MethodImpl(MethodImplOptions.AggressiveInlining)] cint IMath<cint>.Convert(in byte value) => value;
            [MethodImpl(MethodImplOptions.AggressiveInlining)] cint IMath<cint>.Cos(in cint x) => (cint)Math.Cos(x._value);
            [MethodImpl(MethodImplOptions.AggressiveInlining)] cint IMath<cint>.Cosh(in cint x) => (cint)Math.Cosh(x._value);
            [MethodImpl(MethodImplOptions.AggressiveInlining)] cint IMath<cint>.DegreesToRadians(in cint x) => (cint)CheckedArithmetic.Multiply(x, Constants.RadiansPerDegree);
            [MethodImpl(MethodImplOptions.AggressiveInlining)] cint IMath<cint>.DegreesToTurns(in cint x) => (cint)CheckedArithmetic.Multiply(x, Constants.TurnsPerDegree);
            [MethodImpl(MethodImplOptions.AggressiveInlining)] cint IMath<cint>.Divide(in cint x, in cint y) => x / y;
            [MethodImpl(MethodImplOptions.AggressiveInlining)] cint IMath<cint>.Exp(in cint x) => (cint)Math.Exp(x._value);
            [MethodImpl(MethodImplOptions.AggressiveInlining)] cint IMath<cint>.Floor(in cint x) => x;
            [MethodImpl(MethodImplOptions.AggressiveInlining)] cint IMath<cint>.IEEERemainder(in cint x, in cint y) => (cint)Math.IEEERemainder(x._value, y._value);
            [MethodImpl(MethodImplOptions.AggressiveInlining)] cint IMath<cint>.Log(in cint x) => (cint)Math.Log(x._value);
            [MethodImpl(MethodImplOptions.AggressiveInlining)] cint IMath<cint>.Log(in cint x, in cint y) => (cint)Math.Log(x._value, y._value);
            [MethodImpl(MethodImplOptions.AggressiveInlining)] cint IMath<cint>.Log10(in cint x) => (cint)Math.Log10(x._value);
            [MethodImpl(MethodImplOptions.AggressiveInlining)] cint IMath<cint>.Max(in cint x, in cint y) => Math.Max(x._value, y._value);
            [MethodImpl(MethodImplOptions.AggressiveInlining)] cint IMath<cint>.Min(in cint x, in cint y) => Math.Min(x._value, y._value);
            [MethodImpl(MethodImplOptions.AggressiveInlining)] cint IMath<cint>.Multiply(in cint x, in cint y) => x * y;
            [MethodImpl(MethodImplOptions.AggressiveInlining)] cint IMath<cint>.Negative(in cint x) => -x;
            [MethodImpl(MethodImplOptions.AggressiveInlining)] cint IMath<cint>.Positive(in cint x) => +x;
            [MethodImpl(MethodImplOptions.AggressiveInlining)] cint IMath<cint>.Pow(in cint x, in byte y) => CheckedArithmetic.Pow(x._value, y);
            [MethodImpl(MethodImplOptions.AggressiveInlining)] cint IMath<cint>.Pow(in cint x, in cint y) => CheckedArithmetic.Pow(x._value, y._value);
            [MethodImpl(MethodImplOptions.AggressiveInlining)] cint IMath<cint>.RadiansToDegrees(in cint x) => (cint)CheckedArithmetic.Multiply(x, Constants.DegreesPerRadian);
            [MethodImpl(MethodImplOptions.AggressiveInlining)] cint IMath<cint>.RadiansToTurns(in cint x) => (cint)CheckedArithmetic.Multiply(x, Constants.TurnsPerRadian);
            [MethodImpl(MethodImplOptions.AggressiveInlining)] cint IMath<cint>.Remainder(in cint x, in cint y) => x % y;
            [MethodImpl(MethodImplOptions.AggressiveInlining)] cint IMath<cint>.Round(in cint x) => x;
            [MethodImpl(MethodImplOptions.AggressiveInlining)] cint IMath<cint>.Round(in cint x, in int digits) => x;
            [MethodImpl(MethodImplOptions.AggressiveInlining)] cint IMath<cint>.Round(in cint x, in int digits, in MidpointRounding mode) => x;
            [MethodImpl(MethodImplOptions.AggressiveInlining)] cint IMath<cint>.Round(in cint x, in MidpointRounding mode) => x;
            [MethodImpl(MethodImplOptions.AggressiveInlining)] cint IMath<cint>.Sin(in cint x) => (cint)Math.Sin(x._value);
            [MethodImpl(MethodImplOptions.AggressiveInlining)] cint IMath<cint>.Sinh(in cint x) => (cint)Math.Sinh(x._value);
            [MethodImpl(MethodImplOptions.AggressiveInlining)] cint IMath<cint>.Sqrt(in cint x) => (cint)Math.Sqrt(x._value);
            [MethodImpl(MethodImplOptions.AggressiveInlining)] cint IMath<cint>.Subtract(in cint x, in cint y) => x - y;
            [MethodImpl(MethodImplOptions.AggressiveInlining)] cint IMath<cint>.Tan(in cint x) => (cint)Math.Tan(x._value);
            [MethodImpl(MethodImplOptions.AggressiveInlining)] cint IMath<cint>.Tanh(in cint x) => (cint)Math.Tanh(x._value);
            [MethodImpl(MethodImplOptions.AggressiveInlining)] cint IMath<cint>.Truncate(in cint x) => x;
            [MethodImpl(MethodImplOptions.AggressiveInlining)] cint IMath<cint>.TurnsToDegrees(in cint x) => (cint)CheckedArithmetic.Multiply(x, Constants.DegreesPerTurn);
            [MethodImpl(MethodImplOptions.AggressiveInlining)] cint IMath<cint>.TurnsToRadians(in cint x) => (cint)CheckedArithmetic.Multiply(x, Constants.DegreesPerRadian);
            [MethodImpl(MethodImplOptions.AggressiveInlining)] double IMath<cint>.ToDouble(in cint x, in double offset) => CheckedArithmetic.Add(CheckedConvert.ToSingle(x._value), offset);
            [MethodImpl(MethodImplOptions.AggressiveInlining)] float IMath<cint>.ToSingle(in cint x, in float offset) => CheckedArithmetic.Add(CheckedConvert.ToSingle(x._value), offset);
            [MethodImpl(MethodImplOptions.AggressiveInlining)] int IMath<cint>.Sign(in cint x) => Math.Sign(x._value);

            cint IBitConverter<cint>.Read(in IReadOnlyStream<byte> stream) => BitConverter.ToInt32(stream.Read(sizeof(int)));
            void IBitConverter<cint>.Write(cint value, in IWriteOnlyStream<byte> stream) => stream.Write(BitConverter.GetBytes(value._value));

            cint IRandom<cint>.GetNext(Random random) => random.NextInt32();
            cint IRandom<cint>.GetNext(Random random, in cint bound1, in cint bound2) => random.NextInt32(bound1._value, bound2._value);

            cint IStringParser<cint>.Parse(in string s) => int.Parse(s);
            cint IStringParser<cint>.Parse(in string s, in NumberStyles numberStyles, in IFormatProvider formatProvider) => int.Parse(s, numberStyles, formatProvider);
        }
    }
}
