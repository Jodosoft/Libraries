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
    public readonly struct ucint : INumeric<ucint>
    {
        public static readonly ucint MaxValue = new ucint(uint.MaxValue);
        public static readonly ucint MinValue = new ucint(uint.MinValue);

        private readonly uint _value;

        private ucint(uint value)
        {
            _value = value;
        }

        private ucint(SerializationInfo info, StreamingContext _) : this(info.GetUInt32(nameof(ucint))) { }
        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext _) => info.AddValue(nameof(ucint), _value);

        public bool Equals(ucint other) => _value == other._value;
        public bool TryFormat(Span<char> destination, out int charsWritten, ReadOnlySpan<char> format = default, IFormatProvider? provider = null) => _value.TryFormat(destination, out charsWritten, format, provider);
        public float Approximate(in float offset) => _value + offset;

        public int CompareTo(ucint other) => _value.CompareTo(other._value);
        public override int GetHashCode() => _value.GetHashCode();
        public override string ToString() => _value.ToString();
        public string ToString(string format, IFormatProvider formatProvider) => _value.ToString(format, formatProvider);

        public int CompareTo(object? obj)
        {
            if (obj == null) return 1;
            try { return CompareTo((ucint)obj); }
            catch (InvalidCastException) { return 1; }
        }

        public override bool Equals(object? obj)
        {
            if (obj == null) return false;
            try { return Equals((ucint)obj); }
            catch (InvalidCastException) { return false; }
        }

        public static explicit operator ucint(decimal value) => new ucint(CheckedConvert.ToUInt32(value));
        public static explicit operator ucint(double value) => new ucint(CheckedConvert.ToUInt32(value));
        public static explicit operator ucint(float value) => new ucint(CheckedConvert.ToUInt32(value));
        public static explicit operator ucint(int value) => new ucint(CheckedConvert.ToUInt32(value));
        public static explicit operator ucint(long value) => new ucint(CheckedConvert.ToUInt32(value));
        public static explicit operator ucint(sbyte value) => new ucint(CheckedConvert.ToUInt32(value));
        public static explicit operator ucint(short value) => new ucint(CheckedConvert.ToUInt32(value));
        public static explicit operator ucint(ulong value) => new ucint(CheckedConvert.ToUInt32(value));
        public static implicit operator ucint(byte value) => new ucint(value);
        public static implicit operator ucint(uint value) => new ucint(value);
        public static implicit operator ucint(ushort value) => new ucint(value);

        public static explicit operator byte(ucint value) => CheckedConvert.ToByte(value._value);
        public static explicit operator cint(ucint value) => CheckedConvert.ToInt32(value._value);
        public static explicit operator int(ucint value) => CheckedConvert.ToInt32(value._value);
        public static explicit operator short(ucint value) => CheckedConvert.ToInt16(value._value);
        public static explicit operator ushort(ucint value) => CheckedConvert.ToUInt16(value._value);
        public static explicit operator sbyte(ucint value) => CheckedConvert.ToSByte(value._value);
        public static implicit operator cdouble(ucint value) => value._value;
        public static implicit operator cfloat(ucint value) => value._value;
        public static implicit operator decimal(ucint value) => value._value;
        public static implicit operator double(ucint value) => value._value;
        public static implicit operator fix64(ucint value) => value._value;
        public static implicit operator float(ucint value) => value._value;
        public static implicit operator long(ucint value) => value._value;
        public static implicit operator ufix64(ucint value) => value._value;
        public static implicit operator uint(ucint value) => value._value;
        public static implicit operator ulong(ucint value) => value._value;

        public static bool operator !=(ucint left, ucint right) => left._value != right._value;
        public static bool operator <(ucint left, ucint right) => left._value < right._value;
        public static bool operator <=(ucint left, ucint right) => left._value <= right._value;
        public static bool operator ==(ucint left, ucint right) => left._value == right._value;
        public static bool operator >(ucint left, ucint right) => left._value > right._value;
        public static bool operator >=(ucint left, ucint right) => left._value >= right._value;
        public static ucint operator %(ucint left, ucint right) => CheckedArithmetic.Remainder(left._value, right._value);
        public static ucint operator &(ucint left, ucint right) => left._value & right._value;
        public static ucint operator -(ucint _) => MinValue;
        public static ucint operator -(ucint left, ucint right) => CheckedArithmetic.Subtract(left._value, right._value);
        public static ucint operator --(ucint value) => value - 1;
        public static ucint operator *(ucint left, ucint right) => CheckedArithmetic.Multiply(left._value, right._value);
        public static ucint operator /(ucint left, ucint right) => CheckedArithmetic.Divide(left._value, right._value);
        public static ucint operator ^(ucint left, ucint right) => left._value ^ right._value;
        public static ucint operator |(ucint left, ucint right) => left._value | right._value;
        public static ucint operator ~(ucint value) => ~value._value;
        public static ucint operator +(ucint left, ucint right) => CheckedArithmetic.Add(left._value, right._value);
        public static ucint operator +(ucint value) => value;
        public static ucint operator ++(ucint value) => value + 1;
        public static ucint operator <<(ucint left, int right) => left._value << right;
        public static ucint operator >>(ucint left, int right) => left._value >> right;

        IBitConverter<ucint> IBitConvertible<ucint>.BitConverter => Utilities.Instance;
        IMath<ucint> INumeric<ucint>.Math => Utilities.Instance;
        IRandom<ucint> IRandomisable<ucint>.Random => Utilities.Instance;
        IStringParser<ucint> IStringRepresentable<ucint>.StringParser => Utilities.Instance;

        private sealed class Utilities : IMath<ucint>, IBitConverter<ucint>, IRandom<ucint>, IStringParser<ucint>
        {
            public readonly static Utilities Instance = new Utilities();

            ucint IMath<ucint>.E { get; } = 3;
            ucint IMath<ucint>.PI { get; } = 3;
            ucint IMath<ucint>.Epsilon { get; } = 1;
            ucint IMath<ucint>.MaxValue => MaxValue;
            ucint IMath<ucint>.MinValue => MinValue;
            ucint IMath<ucint>.MaxUnit { get; } = 1;
            ucint IMath<ucint>.MinUnit { get; } = 0;
            ucint IMath<ucint>.Zero { get; } = 0;
            ucint IMath<ucint>.One { get; } = 1;
            bool IMath<ucint>.IsSigned { get; } = false;
            bool IMath<ucint>.IsReal { get; } = false;

            [MethodImpl(MethodImplOptions.AggressiveInlining)] bool IMath<ucint>.IsGreaterThan(in ucint x, in ucint y) => x > y;
            [MethodImpl(MethodImplOptions.AggressiveInlining)] bool IMath<ucint>.IsGreaterThanOrEqualTo(in ucint x, in ucint y) => x >= y;
            [MethodImpl(MethodImplOptions.AggressiveInlining)] bool IMath<ucint>.IsLessThan(in ucint x, in ucint y) => x < y;
            [MethodImpl(MethodImplOptions.AggressiveInlining)] bool IMath<ucint>.IsLessThanOrEqualTo(in ucint x, in ucint y) => x <= y;
            [MethodImpl(MethodImplOptions.AggressiveInlining)] double IMath<ucint>.ToDouble(in ucint x, in double offset) => CheckedArithmetic.Add(x._value, offset);
            [MethodImpl(MethodImplOptions.AggressiveInlining)] float IMath<ucint>.ToSingle(in ucint x, in float offset) => CheckedArithmetic.Add(x._value, offset);
            [MethodImpl(MethodImplOptions.AggressiveInlining)] int IMath<ucint>.Sign(in ucint x) => 1;
            [MethodImpl(MethodImplOptions.AggressiveInlining)] ucint IMath<ucint>.Abs(in ucint x) => x;
            [MethodImpl(MethodImplOptions.AggressiveInlining)] ucint IMath<ucint>.Acos(in ucint x) => (ucint)Math.Acos(x._value);
            [MethodImpl(MethodImplOptions.AggressiveInlining)] ucint IMath<ucint>.Acosh(in ucint x) => (ucint)Math.Acosh(x._value);
            [MethodImpl(MethodImplOptions.AggressiveInlining)] ucint IMath<ucint>.Add(in ucint x, in ucint y) => x + y;
            [MethodImpl(MethodImplOptions.AggressiveInlining)] ucint IMath<ucint>.Asin(in ucint x) => (ucint)Math.Asin(x._value);
            [MethodImpl(MethodImplOptions.AggressiveInlining)] ucint IMath<ucint>.Asinh(in ucint x) => (ucint)Math.Asinh(x._value);
            [MethodImpl(MethodImplOptions.AggressiveInlining)] ucint IMath<ucint>.Atan(in ucint x) => (ucint)Math.Atan(x._value);
            [MethodImpl(MethodImplOptions.AggressiveInlining)] ucint IMath<ucint>.Atan2(in ucint x, in ucint y) => (ucint)Math.Atan2(x._value, y._value);
            [MethodImpl(MethodImplOptions.AggressiveInlining)] ucint IMath<ucint>.Atanh(in ucint x) => (ucint)Math.Atanh(x._value);
            [MethodImpl(MethodImplOptions.AggressiveInlining)] ucint IMath<ucint>.Cbrt(in ucint x) => (ucint)Math.Cbrt(x._value);
            [MethodImpl(MethodImplOptions.AggressiveInlining)] ucint IMath<ucint>.Ceiling(in ucint x) => x;
            [MethodImpl(MethodImplOptions.AggressiveInlining)] ucint IMath<ucint>.Clamp(in ucint x, in ucint bound1, in ucint bound2) => bound1 > bound2 ? Math.Min(bound1._value, Math.Max(bound2._value, x._value)) : Math.Min(bound2._value, Math.Max(bound1._value, x._value));
            [MethodImpl(MethodImplOptions.AggressiveInlining)] ucint IMath<ucint>.Convert(in byte value) => value;
            [MethodImpl(MethodImplOptions.AggressiveInlining)] ucint IMath<ucint>.Cos(in ucint x) => (ucint)Math.Cos(x._value);
            [MethodImpl(MethodImplOptions.AggressiveInlining)] ucint IMath<ucint>.Cosh(in ucint x) => (ucint)Math.Cosh(x._value);
            [MethodImpl(MethodImplOptions.AggressiveInlining)] ucint IMath<ucint>.DegreesToRadians(in ucint x) => (ucint)CheckedArithmetic.Multiply(x, Constants.RadiansPerDegree);
            [MethodImpl(MethodImplOptions.AggressiveInlining)] ucint IMath<ucint>.DegreesToTurns(in ucint x) => (ucint)CheckedArithmetic.Multiply(x, Constants.TurnsPerDegree);
            [MethodImpl(MethodImplOptions.AggressiveInlining)] ucint IMath<ucint>.Divide(in ucint x, in ucint y) => x / y;
            [MethodImpl(MethodImplOptions.AggressiveInlining)] ucint IMath<ucint>.Exp(in ucint x) => (ucint)Math.Exp(x._value);
            [MethodImpl(MethodImplOptions.AggressiveInlining)] ucint IMath<ucint>.Floor(in ucint x) => x;
            [MethodImpl(MethodImplOptions.AggressiveInlining)] ucint IMath<ucint>.IEEERemainder(in ucint x, in ucint y) => (ucint)Math.IEEERemainder(x._value, y._value);
            [MethodImpl(MethodImplOptions.AggressiveInlining)] ucint IMath<ucint>.Log(in ucint x) => (ucint)Math.Log(x._value);
            [MethodImpl(MethodImplOptions.AggressiveInlining)] ucint IMath<ucint>.Log(in ucint x, in ucint y) => (ucint)Math.Log(x._value, y._value);
            [MethodImpl(MethodImplOptions.AggressiveInlining)] ucint IMath<ucint>.Log10(in ucint x) => (ucint)Math.Log10(x._value);
            [MethodImpl(MethodImplOptions.AggressiveInlining)] ucint IMath<ucint>.Max(in ucint x, in ucint y) => Math.Max(x._value, y._value);
            [MethodImpl(MethodImplOptions.AggressiveInlining)] ucint IMath<ucint>.Min(in ucint x, in ucint y) => Math.Min(x._value, y._value);
            [MethodImpl(MethodImplOptions.AggressiveInlining)] ucint IMath<ucint>.Multiply(in ucint x, in ucint y) => x * y;
            [MethodImpl(MethodImplOptions.AggressiveInlining)] ucint IMath<ucint>.Negative(in ucint x) => -x;
            [MethodImpl(MethodImplOptions.AggressiveInlining)] ucint IMath<ucint>.Positive(in ucint x) => +x;
            [MethodImpl(MethodImplOptions.AggressiveInlining)] ucint IMath<ucint>.Pow(in ucint x, in byte y) => CheckedArithmetic.Pow(x._value, y);
            [MethodImpl(MethodImplOptions.AggressiveInlining)] ucint IMath<ucint>.Pow(in ucint x, in ucint y) => CheckedArithmetic.Pow(x._value, y._value);
            [MethodImpl(MethodImplOptions.AggressiveInlining)] ucint IMath<ucint>.RadiansToDegrees(in ucint x) => (ucint)CheckedArithmetic.Multiply(x, Constants.DegreesPerRadian);
            [MethodImpl(MethodImplOptions.AggressiveInlining)] ucint IMath<ucint>.RadiansToTurns(in ucint x) => (ucint)CheckedArithmetic.Multiply(x, Constants.TurnsPerRadian);
            [MethodImpl(MethodImplOptions.AggressiveInlining)] ucint IMath<ucint>.Remainder(in ucint x, in ucint y) => x % y;
            [MethodImpl(MethodImplOptions.AggressiveInlining)] ucint IMath<ucint>.Round(in ucint x) => x;
            [MethodImpl(MethodImplOptions.AggressiveInlining)] ucint IMath<ucint>.Round(in ucint x, in int digits) => x;
            [MethodImpl(MethodImplOptions.AggressiveInlining)] ucint IMath<ucint>.Round(in ucint x, in int digits, in MidpointRounding mode) => x;
            [MethodImpl(MethodImplOptions.AggressiveInlining)] ucint IMath<ucint>.Round(in ucint x, in MidpointRounding mode) => x;
            [MethodImpl(MethodImplOptions.AggressiveInlining)] ucint IMath<ucint>.Sin(in ucint x) => (ucint)Math.Sin(x._value);
            [MethodImpl(MethodImplOptions.AggressiveInlining)] ucint IMath<ucint>.Sinh(in ucint x) => (ucint)Math.Sinh(x._value);
            [MethodImpl(MethodImplOptions.AggressiveInlining)] ucint IMath<ucint>.Sqrt(in ucint x) => (ucint)Math.Sqrt(x._value);
            [MethodImpl(MethodImplOptions.AggressiveInlining)] ucint IMath<ucint>.Subtract(in ucint x, in ucint y) => x - y;
            [MethodImpl(MethodImplOptions.AggressiveInlining)] ucint IMath<ucint>.Tan(in ucint x) => (ucint)Math.Tan(x._value);
            [MethodImpl(MethodImplOptions.AggressiveInlining)] ucint IMath<ucint>.Tanh(in ucint x) => (ucint)Math.Tanh(x._value);
            [MethodImpl(MethodImplOptions.AggressiveInlining)] ucint IMath<ucint>.Truncate(in ucint x) => x;
            [MethodImpl(MethodImplOptions.AggressiveInlining)] ucint IMath<ucint>.TurnsToDegrees(in ucint x) => (ucint)CheckedArithmetic.Multiply(x, Constants.DegreesPerTurn);
            [MethodImpl(MethodImplOptions.AggressiveInlining)] ucint IMath<ucint>.TurnsToRadians(in ucint x) => (ucint)CheckedArithmetic.Multiply(x, Constants.DegreesPerRadian);

            ucint IBitConverter<ucint>.Read(in IReadOnlyStream<byte> stream) => BitConverter.ToUInt32(stream.Read(sizeof(uint)));
            void IBitConverter<ucint>.Write(ucint value, in IWriteOnlyStream<byte> stream) => stream.Write(BitConverter.GetBytes(value._value));

            ucint IRandom<ucint>.GetNext(Random random) => random.NextUInt32();
            ucint IRandom<ucint>.GetNext(Random random, in ucint bound1, in ucint bound2) => random.NextUInt32(bound1._value, bound2._value);

            ucint IStringParser<ucint>.Parse(in string s) => uint.Parse(s);
            ucint IStringParser<ucint>.Parse(in string s, in NumberStyles numberStyles, in IFormatProvider formatProvider) => uint.Parse(s, numberStyles, formatProvider);
        }
    }
}
