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

using System;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Runtime.Serialization;
using Jodo.Extensions.Numerics;
using Jodo.Extensions.Primitives;
using Jodo.Extensions.Primitives.Compatibility;

namespace Jodo.Extensions.CheckedNumerics
{
    [Serializable]
    [DebuggerDisplay("{ToString(),nq}")]
    [SuppressMessage("Style", "IDE1006:Naming Styles")]
    [SuppressMessage("csharpsquid", "S101")]
    public readonly struct culong : INumeric<culong>
    {
        public static readonly culong MaxValue = new culong(ulong.MaxValue);
        public static readonly culong MinValue = new culong(ulong.MinValue);

        private readonly ulong _value;

        private culong(ulong value)
        {
            _value = value;
        }

        private culong(SerializationInfo info, StreamingContext context) : this(info.GetUInt64(nameof(culong))) { }
        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context) => info.AddValue(nameof(culong), _value);

        public int CompareTo(object? obj) => obj is culong other ? CompareTo(other) : 1;
        public int CompareTo(culong other) => _value.CompareTo(other._value);
        public bool Equals(culong other) => _value == other._value;
        public override bool Equals(object? obj) => obj is culong other && Equals(other);
        public override int GetHashCode() => _value.GetHashCode();
        public override string ToString() => _value.ToString();
        public string ToString(IFormatProvider formatProvider) => _value.ToString(formatProvider);
        public string ToString(string format) => _value.ToString(format);
        public string ToString(string? format, IFormatProvider? formatProvider) => _value.ToString(format, formatProvider);

        public static bool TryParse(string s, IFormatProvider? provider, out culong result) => Try.Run(() => Parse(s, provider), out result);
        public static bool TryParse(string s, NumberStyles style, IFormatProvider? provider, out culong result) => Try.Run(() => Parse(s, style, provider), out result);
        public static bool TryParse(string s, NumberStyles style, out culong result) => Try.Run(() => Parse(s, style), out result);
        public static bool TryParse(string s, out culong result) => Try.Run(() => Parse(s), out result);
        public static culong Parse(string s) => ulong.Parse(s);
        public static culong Parse(string s, IFormatProvider? provider) => ulong.Parse(s, provider);
        public static culong Parse(string s, NumberStyles style) => ulong.Parse(s, style);
        public static culong Parse(string s, NumberStyles style, IFormatProvider? provider) => ulong.Parse(s, style, provider);

        [CLSCompliant(false)] public static explicit operator culong(sbyte value) => new culong(CheckedConvert.ToUInt64(value));
        [CLSCompliant(false)] public static implicit operator culong(uint value) => new culong(value);
        [CLSCompliant(false)] public static implicit operator culong(ulong value) => new culong(value);
        [CLSCompliant(false)] public static implicit operator culong(ushort value) => new culong(value);
        public static explicit operator culong(decimal value) => new culong(CheckedTruncate.ToUInt64(value));
        public static explicit operator culong(double value) => new culong(CheckedTruncate.ToUInt64(value));
        public static explicit operator culong(float value) => new culong(CheckedTruncate.ToUInt64(value));
        public static explicit operator culong(int value) => new culong(CheckedConvert.ToUInt64(value));
        public static explicit operator culong(long value) => new culong(CheckedConvert.ToUInt64(value));
        public static explicit operator culong(short value) => new culong(CheckedConvert.ToUInt64(value));
        public static implicit operator culong(byte value) => new culong(value);

        [CLSCompliant(false)] public static explicit operator sbyte(culong value) => CheckedConvert.ToSByte(value._value);
        [CLSCompliant(false)] public static explicit operator uint(culong value) => CheckedConvert.ToUInt32(value._value);
        [CLSCompliant(false)] public static explicit operator ushort(culong value) => CheckedConvert.ToUInt16(value._value);
        [CLSCompliant(false)] public static implicit operator ulong(culong value) => value._value;
        public static explicit operator byte(culong value) => CheckedConvert.ToByte(value._value);
        public static explicit operator int(culong value) => CheckedConvert.ToInt32(value._value);
        public static explicit operator long(culong value) => CheckedConvert.ToInt64(value._value);
        public static explicit operator short(culong value) => CheckedConvert.ToInt16(value._value);
        public static implicit operator decimal(culong value) => value._value;
        public static implicit operator double(culong value) => value._value;
        public static implicit operator float(culong value) => value._value;

        public static bool operator !=(culong left, culong right) => left._value != right._value;
        public static bool operator <(culong left, culong right) => left._value < right._value;
        public static bool operator <=(culong left, culong right) => left._value <= right._value;
        public static bool operator ==(culong left, culong right) => left._value == right._value;
        public static bool operator >(culong left, culong right) => left._value > right._value;
        public static bool operator >=(culong left, culong right) => left._value >= right._value;
        public static culong operator %(culong left, culong right) => CheckedArithmetic.Remainder(left._value, right._value);
        public static culong operator &(culong left, culong right) => left._value & right._value;
        public static culong operator -(culong _) => MinValue;
        public static culong operator -(culong left, culong right) => CheckedArithmetic.Subtract(left._value, right._value);
        public static culong operator --(culong value) => value - 1;
        public static culong operator *(culong left, culong right) => CheckedArithmetic.Multiply(left._value, right._value);
        public static culong operator /(culong left, culong right) => CheckedArithmetic.Divide(left._value, right._value);
        public static culong operator ^(culong left, culong right) => left._value ^ right._value;
        public static culong operator |(culong left, culong right) => left._value | right._value;
        public static culong operator ~(culong value) => ~value._value;
        public static culong operator +(culong left, culong right) => CheckedArithmetic.Add(left._value, right._value);
        public static culong operator +(culong value) => value;
        public static culong operator ++(culong value) => value + 1;
        public static culong operator <<(culong left, int right) => left._value << right;
        public static culong operator >>(culong left, int right) => left._value >> right;

        bool INumeric<culong>.IsGreaterThan(culong value) => this > value;
        bool INumeric<culong>.IsGreaterThanOrEqualTo(culong value) => this >= value;
        bool INumeric<culong>.IsLessThan(culong value) => this < value;
        bool INumeric<culong>.IsLessThanOrEqualTo(culong value) => this <= value;
        culong INumeric<culong>.Add(culong value) => this + value;
        culong INumeric<culong>.BitwiseComplement() => ~this;
        culong INumeric<culong>.Divide(culong value) => this / value;
        culong INumeric<culong>.LeftShift(int count) => this << count;
        culong INumeric<culong>.LogicalAnd(culong value) => this & value;
        culong INumeric<culong>.LogicalExclusiveOr(culong value) => this ^ value;
        culong INumeric<culong>.LogicalOr(culong value) => this | value;
        culong INumeric<culong>.Multiply(culong value) => this * value;
        culong INumeric<culong>.Negative() => -this;
        culong INumeric<culong>.Positive() => +this;
        culong INumeric<culong>.Remainder(culong value) => this % value;
        culong INumeric<culong>.RightShift(int count) => this >> count;
        culong INumeric<culong>.Subtract(culong value) => this - value;

        IBitConverter<culong> IProvider<IBitConverter<culong>>.GetInstance() => Utilities.Instance;
        ICast<culong> IProvider<ICast<culong>>.GetInstance() => Utilities.Instance;
        IConvert<culong> IProvider<IConvert<culong>>.GetInstance() => Utilities.Instance;
        IMath<culong> IProvider<IMath<culong>>.GetInstance() => Utilities.Instance;
        INumericStatic<culong> IProvider<INumericStatic<culong>>.GetInstance() => Utilities.Instance;
        IRandom<culong> IProvider<IRandom<culong>>.GetInstance() => Utilities.Instance;
        IStringParser<culong> IProvider<IStringParser<culong>>.GetInstance() => Utilities.Instance;

        private sealed class Utilities :
            IBitConverter<culong>,
            ICast<culong>,
            IConvert<culong>,
            IMath<culong>,
            INumericStatic<culong>,
            IRandom<culong>,
            IStringParser<culong>
        {
            public static readonly Utilities Instance = new Utilities();

            bool INumericStatic<culong>.HasFloatingPoint { get; } = false;
            bool INumericStatic<culong>.HasInfinity { get; } = false;
            bool INumericStatic<culong>.HasNaN { get; } = false;
            bool INumericStatic<culong>.IsFinite(culong x) => true;
            bool INumericStatic<culong>.IsInfinity(culong x) => false;
            bool INumericStatic<culong>.IsNaN(culong x) => false;
            bool INumericStatic<culong>.IsNegative(culong x) => false;
            bool INumericStatic<culong>.IsNegativeInfinity(culong x) => false;
            bool INumericStatic<culong>.IsNormal(culong x) => false;
            bool INumericStatic<culong>.IsPositiveInfinity(culong x) => false;
            bool INumericStatic<culong>.IsReal { get; } = false;
            bool INumericStatic<culong>.IsSigned { get; } = false;
            bool INumericStatic<culong>.IsSubnormal(culong x) => false;
            culong INumericStatic<culong>.Epsilon { get; } = 1;
            culong INumericStatic<culong>.MaxUnit { get; } = 1;
            culong INumericStatic<culong>.MaxValue => MaxValue;
            culong INumericStatic<culong>.MinUnit { get; } = 0;
            culong INumericStatic<culong>.MinValue => MinValue;
            culong INumericStatic<culong>.One { get; } = 1;
            culong INumericStatic<culong>.Ten { get; } = 10;
            culong INumericStatic<culong>.Two { get; } = 2;
            culong INumericStatic<culong>.Zero { get; } = 0;

            int IMath<culong>.Sign(culong x) => x._value == 0 ? 0 : 1;
            culong IMath<culong>.Abs(culong value) => value;
            culong IMath<culong>.Acos(culong x) => (culong)Math.Acos(x._value);
            culong IMath<culong>.Acosh(culong x) => (culong)MathCompat.Acosh(x._value);
            culong IMath<culong>.Asin(culong x) => (culong)Math.Asin(x._value);
            culong IMath<culong>.Asinh(culong x) => (culong)MathCompat.Asinh(x._value);
            culong IMath<culong>.Atan(culong x) => (culong)Math.Atan(x._value);
            culong IMath<culong>.Atan2(culong x, culong y) => (culong)Math.Atan2(x._value, y._value);
            culong IMath<culong>.Atanh(culong x) => (culong)MathCompat.Atanh(x._value);
            culong IMath<culong>.Cbrt(culong x) => (culong)MathCompat.Cbrt(x._value);
            culong IMath<culong>.Ceiling(culong x) => x;
            culong IMath<culong>.Clamp(culong x, culong bound1, culong bound2) => bound1 > bound2 ? Math.Min(bound1._value, Math.Max(bound2._value, x._value)) : Math.Min(bound2._value, Math.Max(bound1._value, x._value));
            culong IMath<culong>.Cos(culong x) => (culong)Math.Cos(x._value);
            culong IMath<culong>.Cosh(culong x) => (culong)Math.Cosh(x._value);
            culong IMath<culong>.DegreesToRadians(culong x) => (culong)CheckedArithmetic.Multiply(x, NumericUtilities.RadiansPerDegree);
            culong IMath<culong>.E { get; } = 2;
            culong IMath<culong>.Exp(culong x) => (culong)Math.Exp(x._value);
            culong IMath<culong>.Floor(culong x) => x;
            culong IMath<culong>.IEEERemainder(culong x, culong y) => (culong)Math.IEEERemainder(x._value, y._value);
            culong IMath<culong>.Log(culong x) => (culong)Math.Log(x._value);
            culong IMath<culong>.Log(culong x, culong y) => (culong)Math.Log(x._value, y._value);
            culong IMath<culong>.Log10(culong x) => (culong)Math.Log10(x._value);
            culong IMath<culong>.Max(culong x, culong y) => Math.Max(x._value, y._value);
            culong IMath<culong>.Min(culong x, culong y) => Math.Min(x._value, y._value);
            culong IMath<culong>.PI { get; } = 3;
            culong IMath<culong>.Pow(culong x, culong y) => CheckedArithmetic.Pow(x._value, y._value);
            culong IMath<culong>.RadiansToDegrees(culong x) => (culong)CheckedArithmetic.Multiply(x, NumericUtilities.DegreesPerRadian);
            culong IMath<culong>.Round(culong x) => x;
            culong IMath<culong>.Round(culong x, int digits) => x;
            culong IMath<culong>.Round(culong x, int digits, MidpointRounding mode) => x;
            culong IMath<culong>.Round(culong x, MidpointRounding mode) => x;
            culong IMath<culong>.Sin(culong x) => (culong)Math.Sin(x._value);
            culong IMath<culong>.Sinh(culong x) => (culong)Math.Sinh(x._value);
            culong IMath<culong>.Sqrt(culong x) => (culong)Math.Sqrt(x._value);
            culong IMath<culong>.Tan(culong x) => (culong)Math.Tan(x._value);
            culong IMath<culong>.Tanh(culong x) => (culong)Math.Tanh(x._value);
            culong IMath<culong>.Tau { get; } = 6;
            culong IMath<culong>.Truncate(culong x) => x;

            culong IBitConverter<culong>.Read(IReadOnlyStream<byte> stream) => BitConverter.ToUInt64(stream.Read(sizeof(ulong)), 0);
            void IBitConverter<culong>.Write(culong value, IWriteOnlyStream<byte> stream) => stream.Write(BitConverter.GetBytes(value._value));

            culong IRandom<culong>.Next(Random random) => random.NextUInt64();
            culong IRandom<culong>.Next(Random random, culong bound1, culong bound2) => random.NextUInt64(bound1._value, bound2._value);

            bool IConvert<culong>.ToBoolean(culong value) => CheckedConvert.ToBoolean(value._value);
            byte IConvert<culong>.ToByte(culong value) => CheckedConvert.ToByte(value._value);
            decimal IConvert<culong>.ToDecimal(culong value) => CheckedConvert.ToDecimal(value._value);
            double IConvert<culong>.ToDouble(culong value) => CheckedConvert.ToDouble(value._value);
            float IConvert<culong>.ToSingle(culong value) => CheckedConvert.ToSingle(value._value);
            int IConvert<culong>.ToInt32(culong value) => CheckedConvert.ToInt32(value._value);
            long IConvert<culong>.ToInt64(culong value) => CheckedConvert.ToInt64(value._value);
            sbyte IConvert<culong>.ToSByte(culong value) => CheckedConvert.ToSByte(value._value);
            short IConvert<culong>.ToInt16(culong value) => CheckedConvert.ToInt16(value._value);
            string IConvert<culong>.ToString(culong value) => Convert.ToString(value._value);
            uint IConvert<culong>.ToUInt32(culong value) => CheckedConvert.ToUInt32(value._value);
            ulong IConvert<culong>.ToUInt64(culong value) => value._value;
            ushort IConvert<culong>.ToUInt16(culong value) => CheckedConvert.ToUInt16(value._value);

            culong IConvert<culong>.ToNumeric(bool value) => CheckedConvert.ToUInt64(value);
            culong IConvert<culong>.ToNumeric(byte value) => CheckedConvert.ToUInt64(value);
            culong IConvert<culong>.ToNumeric(decimal value) => CheckedConvert.ToUInt64(value);
            culong IConvert<culong>.ToNumeric(double value) => CheckedConvert.ToUInt64(value);
            culong IConvert<culong>.ToNumeric(float value) => CheckedConvert.ToUInt64(value);
            culong IConvert<culong>.ToNumeric(int value) => CheckedConvert.ToUInt64(value);
            culong IConvert<culong>.ToNumeric(long value) => CheckedConvert.ToUInt64(value);
            culong IConvert<culong>.ToNumeric(sbyte value) => CheckedConvert.ToUInt64(value);
            culong IConvert<culong>.ToNumeric(short value) => CheckedConvert.ToUInt64(value);
            culong IConvert<culong>.ToNumeric(string value) => Convert.ToUInt64(value);
            culong IConvert<culong>.ToNumeric(uint value) => CheckedConvert.ToUInt64(value);
            culong IConvert<culong>.ToNumeric(ulong value) => value;
            culong IConvert<culong>.ToNumeric(ushort value) => CheckedConvert.ToUInt64(value);

            culong IStringParser<culong>.Parse(string s) => Parse(s);
            culong IStringParser<culong>.Parse(string s, NumberStyles style, IFormatProvider? provider) => Parse(s, style, provider);

            byte ICast<culong>.ToByte(culong value) => (byte)value;
            decimal ICast<culong>.ToDecimal(culong value) => (decimal)value;
            double ICast<culong>.ToDouble(culong value) => (double)value;
            float ICast<culong>.ToSingle(culong value) => (float)value;
            int ICast<culong>.ToInt32(culong value) => (int)value;
            long ICast<culong>.ToInt64(culong value) => (long)value;
            sbyte ICast<culong>.ToSByte(culong value) => (sbyte)value;
            short ICast<culong>.ToInt16(culong value) => (short)value;
            uint ICast<culong>.ToUInt32(culong value) => (uint)value;
            ulong ICast<culong>.ToUInt64(culong value) => (ulong)value;
            ushort ICast<culong>.ToUInt16(culong value) => (ushort)value;

            culong ICast<culong>.ToNumeric(byte value) => (culong)value;
            culong ICast<culong>.ToNumeric(decimal value) => (culong)value;
            culong ICast<culong>.ToNumeric(double value) => (culong)value;
            culong ICast<culong>.ToNumeric(float value) => (culong)value;
            culong ICast<culong>.ToNumeric(int value) => (culong)value;
            culong ICast<culong>.ToNumeric(long value) => (culong)value;
            culong ICast<culong>.ToNumeric(sbyte value) => (culong)value;
            culong ICast<culong>.ToNumeric(short value) => (culong)value;
            culong ICast<culong>.ToNumeric(uint value) => (culong)value;
            culong ICast<culong>.ToNumeric(ulong value) => (culong)value;
            culong ICast<culong>.ToNumeric(ushort value) => (culong)value;
        }
    }
}
