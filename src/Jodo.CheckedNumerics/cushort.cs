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
using Jodo.Numerics;
using Jodo.Primitives;
using Jodo.Primitives.Compatibility;

namespace Jodo.CheckedNumerics
{
    [Serializable]
    [DebuggerDisplay("{ToString(),nq}")]
    [SuppressMessage("Style", "IDE1006:Naming Styles")]
    [SuppressMessage("csharpsquid", "S101")]
    public readonly struct cushort : INumeric<cushort>
    {
        public static readonly cushort MaxValue = new cushort(ushort.MaxValue);
        public static readonly cushort MinValue = new cushort(ushort.MinValue);

        private readonly ushort _value;

        private cushort(ushort value)
        {
            _value = value;
        }

        private cushort(SerializationInfo info, StreamingContext context) : this(info.GetUInt16(nameof(cushort))) { }
        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context) => info.AddValue(nameof(cushort), _value);

        public int CompareTo(object? obj) => obj is cushort other ? CompareTo(other) : 1;
        public int CompareTo(cushort other) => _value.CompareTo(other._value);
        public bool Equals(cushort other) => _value == other._value;
        public override bool Equals(object? obj) => obj is cushort other && Equals(other);
        public override int GetHashCode() => _value.GetHashCode();
        public override string ToString() => _value.ToString();
        public string ToString(IFormatProvider formatProvider) => _value.ToString(formatProvider);
        public string ToString(string format) => _value.ToString(format);
        public string ToString(string? format, IFormatProvider? formatProvider) => _value.ToString(format, formatProvider);

        public static bool TryParse(string s, IFormatProvider? provider, out cushort result) => Try.Run(() => Parse(s, provider), out result);
        public static bool TryParse(string s, NumberStyles style, IFormatProvider? provider, out cushort result) => Try.Run(() => Parse(s, style, provider), out result);
        public static bool TryParse(string s, NumberStyles style, out cushort result) => Try.Run(() => Parse(s, style), out result);
        public static bool TryParse(string s, out cushort result) => Try.Run(() => Parse(s), out result);
        public static cushort Parse(string s) => ushort.Parse(s);
        public static cushort Parse(string s, IFormatProvider? provider) => ushort.Parse(s, provider);
        public static cushort Parse(string s, NumberStyles style) => ushort.Parse(s, style);
        public static cushort Parse(string s, NumberStyles style, IFormatProvider? provider) => ushort.Parse(s, style, provider);

        [CLSCompliant(false)] public static explicit operator cushort(sbyte value) => new cushort(CheckedConvert.ToUInt16(value));
        [CLSCompliant(false)] public static explicit operator cushort(uint value) => new cushort(CheckedConvert.ToUInt16(value));
        [CLSCompliant(false)] public static explicit operator cushort(ulong value) => new cushort(CheckedConvert.ToUInt16(value));
        [CLSCompliant(false)] public static implicit operator cushort(ushort value) => new cushort(value);
        public static explicit operator cushort(decimal value) => new cushort(CheckedTruncate.ToUInt16(value));
        public static explicit operator cushort(double value) => new cushort(CheckedTruncate.ToUInt16(value));
        public static explicit operator cushort(float value) => new cushort(CheckedTruncate.ToUInt16(value));
        public static explicit operator cushort(int value) => new cushort(CheckedConvert.ToUInt16(value));
        public static explicit operator cushort(long value) => new cushort(CheckedConvert.ToUInt16(value));
        public static explicit operator cushort(short value) => new cushort(CheckedConvert.ToUInt16(value));
        public static implicit operator cushort(byte value) => new cushort(value);

        [CLSCompliant(false)] public static explicit operator sbyte(cushort value) => CheckedConvert.ToSByte(value._value);
        [CLSCompliant(false)] public static implicit operator uint(cushort value) => value._value;
        [CLSCompliant(false)] public static implicit operator ulong(cushort value) => value._value;
        [CLSCompliant(false)] public static implicit operator ushort(cushort value) => value._value;
        public static explicit operator byte(cushort value) => CheckedConvert.ToByte(value._value);
        public static explicit operator int(cushort value) => CheckedConvert.ToInt32(value._value);
        public static explicit operator short(cushort value) => CheckedConvert.ToInt16(value._value);
        public static implicit operator decimal(cushort value) => value._value;
        public static implicit operator double(cushort value) => value._value;
        public static implicit operator float(cushort value) => value._value;
        public static implicit operator long(cushort value) => value._value;

        public static bool operator !=(cushort left, cushort right) => left._value != right._value;
        public static bool operator <(cushort left, cushort right) => left._value < right._value;
        public static bool operator <=(cushort left, cushort right) => left._value <= right._value;
        public static bool operator ==(cushort left, cushort right) => left._value == right._value;
        public static bool operator >(cushort left, cushort right) => left._value > right._value;
        public static bool operator >=(cushort left, cushort right) => left._value >= right._value;
        public static cushort operator %(cushort left, cushort right) => CheckedArithmetic.Remainder(left._value, right._value);
        public static cushort operator &(cushort left, cushort right) => (ushort)(left._value & right._value);
        public static cushort operator -(cushort _) => MinValue;
        public static cushort operator -(cushort left, cushort right) => CheckedArithmetic.Subtract(left._value, right._value);
        public static cushort operator --(cushort value) => value - 1;
        public static cushort operator *(cushort left, cushort right) => CheckedArithmetic.Multiply(left._value, right._value);
        public static cushort operator /(cushort left, cushort right) => CheckedArithmetic.Divide(left._value, right._value);
        public static cushort operator ^(cushort left, cushort right) => (ushort)(left._value ^ right._value);
        public static cushort operator |(cushort left, cushort right) => (ushort)(left._value | right._value);
        public static cushort operator ~(cushort value) => (ushort)~value._value;
        public static cushort operator +(cushort left, cushort right) => CheckedArithmetic.Add(left._value, right._value);
        public static cushort operator +(cushort value) => value;
        public static cushort operator ++(cushort value) => value + 1;
        public static cushort operator <<(cushort left, int right) => (ushort)(left._value << right);
        public static cushort operator >>(cushort left, int right) => (ushort)(left._value >> right);

        bool INumeric<cushort>.IsGreaterThan(cushort value) => this > value;
        bool INumeric<cushort>.IsGreaterThanOrEqualTo(cushort value) => this >= value;
        bool INumeric<cushort>.IsLessThan(cushort value) => this < value;
        bool INumeric<cushort>.IsLessThanOrEqualTo(cushort value) => this <= value;
        cushort INumeric<cushort>.Add(cushort value) => this + value;
        cushort INumeric<cushort>.BitwiseComplement() => ~this;
        cushort INumeric<cushort>.Divide(cushort value) => this / value;
        cushort INumeric<cushort>.LeftShift(int count) => this << count;
        cushort INumeric<cushort>.LogicalAnd(cushort value) => this & value;
        cushort INumeric<cushort>.LogicalExclusiveOr(cushort value) => this ^ value;
        cushort INumeric<cushort>.LogicalOr(cushort value) => this | value;
        cushort INumeric<cushort>.Multiply(cushort value) => this * value;
        cushort INumeric<cushort>.Negative() => -this;
        cushort INumeric<cushort>.Positive() => +this;
        cushort INumeric<cushort>.Remainder(cushort value) => this % value;
        cushort INumeric<cushort>.RightShift(int count) => this >> count;
        cushort INumeric<cushort>.Subtract(cushort value) => this - value;

        IBitConverter<cushort> IProvider<IBitConverter<cushort>>.GetInstance() => Utilities.Instance;
        ICast<cushort> IProvider<ICast<cushort>>.GetInstance() => Utilities.Instance;
        IConvert<cushort> IProvider<IConvert<cushort>>.GetInstance() => Utilities.Instance;
        IMath<cushort> IProvider<IMath<cushort>>.GetInstance() => Utilities.Instance;
        INumericStatic<cushort> IProvider<INumericStatic<cushort>>.GetInstance() => Utilities.Instance;
        IRandom<cushort> IProvider<IRandom<cushort>>.GetInstance() => Utilities.Instance;
        IStringParser<cushort> IProvider<IStringParser<cushort>>.GetInstance() => Utilities.Instance;

        private sealed class Utilities :
            IBitConverter<cushort>,
            ICast<cushort>,
            IConvert<cushort>,
            IMath<cushort>,
            INumericStatic<cushort>,
            IRandom<cushort>,
            IStringParser<cushort>
        {
            public static readonly Utilities Instance = new Utilities();

            bool INumericStatic<cushort>.HasFloatingPoint { get; } = false;
            bool INumericStatic<cushort>.HasInfinity { get; } = false;
            bool INumericStatic<cushort>.HasNaN { get; } = false;
            bool INumericStatic<cushort>.IsFinite(cushort x) => true;
            bool INumericStatic<cushort>.IsInfinity(cushort x) => false;
            bool INumericStatic<cushort>.IsNaN(cushort x) => false;
            bool INumericStatic<cushort>.IsNegative(cushort x) => false;
            bool INumericStatic<cushort>.IsNegativeInfinity(cushort x) => false;
            bool INumericStatic<cushort>.IsNormal(cushort x) => false;
            bool INumericStatic<cushort>.IsPositiveInfinity(cushort x) => false;
            bool INumericStatic<cushort>.IsReal { get; } = false;
            bool INumericStatic<cushort>.IsSigned { get; } = false;
            bool INumericStatic<cushort>.IsSubnormal(cushort x) => false;
            cushort INumericStatic<cushort>.Epsilon { get; } = 1;
            cushort INumericStatic<cushort>.MaxUnit { get; } = 1;
            cushort INumericStatic<cushort>.MaxValue => MaxValue;
            cushort INumericStatic<cushort>.MinUnit { get; } = 0;
            cushort INumericStatic<cushort>.MinValue => MinValue;
            cushort INumericStatic<cushort>.One { get; } = 1;
            cushort INumericStatic<cushort>.Ten { get; } = 10;
            cushort INumericStatic<cushort>.Two { get; } = 2;
            cushort INumericStatic<cushort>.Zero { get; } = 0;

            int IMath<cushort>.Sign(cushort x) => x._value == 0 ? 0 : 1;
            cushort IMath<cushort>.Abs(cushort value) => value;
            cushort IMath<cushort>.Acos(cushort x) => (cushort)Math.Acos(x._value);
            cushort IMath<cushort>.Acosh(cushort x) => (cushort)MathCompat.Acosh(x._value);
            cushort IMath<cushort>.Asin(cushort x) => (cushort)Math.Asin(x._value);
            cushort IMath<cushort>.Asinh(cushort x) => (cushort)MathCompat.Asinh(x._value);
            cushort IMath<cushort>.Atan(cushort x) => (cushort)Math.Atan(x._value);
            cushort IMath<cushort>.Atan2(cushort x, cushort y) => (cushort)Math.Atan2(x._value, y._value);
            cushort IMath<cushort>.Atanh(cushort x) => (cushort)MathCompat.Atanh(x._value);
            cushort IMath<cushort>.Cbrt(cushort x) => (cushort)MathCompat.Cbrt(x._value);
            cushort IMath<cushort>.Ceiling(cushort x) => x;
            cushort IMath<cushort>.Clamp(cushort x, cushort bound1, cushort bound2) => bound1 > bound2 ? Math.Min(bound1._value, Math.Max(bound2._value, x._value)) : Math.Min(bound2._value, Math.Max(bound1._value, x._value));
            cushort IMath<cushort>.Cos(cushort x) => (cushort)Math.Cos(x._value);
            cushort IMath<cushort>.Cosh(cushort x) => (cushort)Math.Cosh(x._value);
            cushort IMath<cushort>.DegreesToRadians(cushort x) => (cushort)CheckedArithmetic.Multiply(x, NumericUtilities.RadiansPerDegree);
            cushort IMath<cushort>.E { get; } = 2;
            cushort IMath<cushort>.Exp(cushort x) => (cushort)Math.Exp(x._value);
            cushort IMath<cushort>.Floor(cushort x) => x;
            cushort IMath<cushort>.IEEERemainder(cushort x, cushort y) => (cushort)Math.IEEERemainder(x._value, y._value);
            cushort IMath<cushort>.Log(cushort x) => (cushort)Math.Log(x._value);
            cushort IMath<cushort>.Log(cushort x, cushort y) => (cushort)Math.Log(x._value, y._value);
            cushort IMath<cushort>.Log10(cushort x) => (cushort)Math.Log10(x._value);
            cushort IMath<cushort>.Max(cushort x, cushort y) => Math.Max(x._value, y._value);
            cushort IMath<cushort>.Min(cushort x, cushort y) => Math.Min(x._value, y._value);
            cushort IMath<cushort>.PI { get; } = 3;
            cushort IMath<cushort>.Pow(cushort x, cushort y) => CheckedArithmetic.Pow(x._value, y._value);
            cushort IMath<cushort>.RadiansToDegrees(cushort x) => (cushort)CheckedArithmetic.Multiply(x, NumericUtilities.DegreesPerRadian);
            cushort IMath<cushort>.Round(cushort x) => x;
            cushort IMath<cushort>.Round(cushort x, int digits) => x;
            cushort IMath<cushort>.Round(cushort x, int digits, MidpointRounding mode) => x;
            cushort IMath<cushort>.Round(cushort x, MidpointRounding mode) => x;
            cushort IMath<cushort>.Sin(cushort x) => (cushort)Math.Sin(x._value);
            cushort IMath<cushort>.Sinh(cushort x) => (cushort)Math.Sinh(x._value);
            cushort IMath<cushort>.Sqrt(cushort x) => (cushort)Math.Sqrt(x._value);
            cushort IMath<cushort>.Tan(cushort x) => (cushort)Math.Tan(x._value);
            cushort IMath<cushort>.Tanh(cushort x) => (cushort)Math.Tanh(x._value);
            cushort IMath<cushort>.Tau { get; } = 6;
            cushort IMath<cushort>.Truncate(cushort x) => x;

            cushort IBitConverter<cushort>.Read(IReadOnlyStream<byte> stream) => BitConverter.ToUInt16(stream.Read(sizeof(ushort)), 0);
            void IBitConverter<cushort>.Write(cushort value, IWriteOnlyStream<byte> stream) => stream.Write(BitConverter.GetBytes(value._value));

            cushort IRandom<cushort>.Next(Random random) => random.NextUInt16();
            cushort IRandom<cushort>.Next(Random random, cushort bound1, cushort bound2) => random.NextUInt16(bound1._value, bound2._value);

            bool IConvert<cushort>.ToBoolean(cushort value) => CheckedConvert.ToBoolean(value._value);
            byte IConvert<cushort>.ToByte(cushort value) => CheckedConvert.ToByte(value._value);
            decimal IConvert<cushort>.ToDecimal(cushort value) => CheckedConvert.ToDecimal(value._value);
            double IConvert<cushort>.ToDouble(cushort value) => CheckedConvert.ToDouble(value._value);
            float IConvert<cushort>.ToSingle(cushort value) => CheckedConvert.ToSingle(value._value);
            int IConvert<cushort>.ToInt32(cushort value) => CheckedConvert.ToInt32(value._value);
            long IConvert<cushort>.ToInt64(cushort value) => CheckedConvert.ToInt64(value._value);
            sbyte IConvert<cushort>.ToSByte(cushort value) => CheckedConvert.ToSByte(value._value);
            short IConvert<cushort>.ToInt16(cushort value) => CheckedConvert.ToInt16(value._value);
            string IConvert<cushort>.ToString(cushort value) => Convert.ToString(value._value);
            uint IConvert<cushort>.ToUInt32(cushort value) => value._value;
            ulong IConvert<cushort>.ToUInt64(cushort value) => CheckedConvert.ToUInt64(value._value);
            ushort IConvert<cushort>.ToUInt16(cushort value) => CheckedConvert.ToUInt16(value._value);

            cushort IConvert<cushort>.ToNumeric(bool value) => CheckedConvert.ToUInt16(value);
            cushort IConvert<cushort>.ToNumeric(byte value) => CheckedConvert.ToUInt16(value);
            cushort IConvert<cushort>.ToNumeric(decimal value) => CheckedConvert.ToUInt16(value);
            cushort IConvert<cushort>.ToNumeric(double value) => CheckedConvert.ToUInt16(value);
            cushort IConvert<cushort>.ToNumeric(float value) => CheckedConvert.ToUInt16(value);
            cushort IConvert<cushort>.ToNumeric(int value) => CheckedConvert.ToUInt16(value);
            cushort IConvert<cushort>.ToNumeric(long value) => CheckedConvert.ToUInt16(value);
            cushort IConvert<cushort>.ToNumeric(sbyte value) => CheckedConvert.ToUInt16(value);
            cushort IConvert<cushort>.ToNumeric(short value) => CheckedConvert.ToUInt16(value);
            cushort IConvert<cushort>.ToNumeric(string value) => Convert.ToUInt16(value);
            cushort IConvert<cushort>.ToNumeric(uint value) => CheckedConvert.ToUInt16(value);
            cushort IConvert<cushort>.ToNumeric(ulong value) => CheckedConvert.ToUInt16(value);
            cushort IConvert<cushort>.ToNumeric(ushort value) => value;

            cushort IStringParser<cushort>.Parse(string s) => Parse(s);
            cushort IStringParser<cushort>.Parse(string s, NumberStyles style, IFormatProvider? provider) => Parse(s, style, provider);

            byte ICast<cushort>.ToByte(cushort value) => (byte)value;
            decimal ICast<cushort>.ToDecimal(cushort value) => (decimal)value;
            double ICast<cushort>.ToDouble(cushort value) => (double)value;
            float ICast<cushort>.ToSingle(cushort value) => (float)value;
            int ICast<cushort>.ToInt32(cushort value) => (int)value;
            long ICast<cushort>.ToInt64(cushort value) => (long)value;
            sbyte ICast<cushort>.ToSByte(cushort value) => (sbyte)value;
            short ICast<cushort>.ToInt16(cushort value) => (short)value;
            uint ICast<cushort>.ToUInt32(cushort value) => (uint)value;
            ulong ICast<cushort>.ToUInt64(cushort value) => (ulong)value;
            ushort ICast<cushort>.ToUInt16(cushort value) => (ushort)value;

            cushort ICast<cushort>.ToNumeric(byte value) => (cushort)value;
            cushort ICast<cushort>.ToNumeric(decimal value) => (cushort)value;
            cushort ICast<cushort>.ToNumeric(double value) => (cushort)value;
            cushort ICast<cushort>.ToNumeric(float value) => (cushort)value;
            cushort ICast<cushort>.ToNumeric(int value) => (cushort)value;
            cushort ICast<cushort>.ToNumeric(long value) => (cushort)value;
            cushort ICast<cushort>.ToNumeric(sbyte value) => (cushort)value;
            cushort ICast<cushort>.ToNumeric(short value) => (cushort)value;
            cushort ICast<cushort>.ToNumeric(uint value) => (cushort)value;
            cushort ICast<cushort>.ToNumeric(ulong value) => (cushort)value;
            cushort ICast<cushort>.ToNumeric(ushort value) => (cushort)value;
        }
    }
}
