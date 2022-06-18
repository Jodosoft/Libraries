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
    public readonly struct cbyte : INumeric<cbyte>
    {
        public static readonly cbyte MaxValue = new cbyte(byte.MaxValue);
        public static readonly cbyte MinValue = new cbyte(byte.MinValue);

        private readonly byte _value;

        private cbyte(byte value)
        {
            _value = value;
        }

        private cbyte(SerializationInfo info, StreamingContext context) : this(info.GetByte(nameof(cbyte))) { }
        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context) => info.AddValue(nameof(cbyte), _value);

        public int CompareTo(object? obj) => obj is cbyte other ? CompareTo(other) : 1;
        public int CompareTo(cbyte other) => _value.CompareTo(other._value);
        public bool Equals(cbyte other) => _value == other._value;
        public override bool Equals(object? obj) => obj is cbyte other && Equals(other);
        public override int GetHashCode() => _value.GetHashCode();
        public override string ToString() => _value.ToString();
        public string ToString(IFormatProvider formatProvider) => _value.ToString(formatProvider);
        public string ToString(string format) => _value.ToString(format);
        public string ToString(string? format, IFormatProvider? formatProvider) => _value.ToString(format, formatProvider);

        public static bool TryParse(string s, IFormatProvider? provider, out cbyte result) => Try.Run(() => Parse(s, provider), out result);
        public static bool TryParse(string s, NumberStyles style, IFormatProvider? provider, out cbyte result) => Try.Run(() => Parse(s, style, provider), out result);
        public static bool TryParse(string s, NumberStyles style, out cbyte result) => Try.Run(() => Parse(s, style), out result);
        public static bool TryParse(string s, out cbyte result) => Try.Run(() => Parse(s), out result);
        public static cbyte Parse(string s) => byte.Parse(s);
        public static cbyte Parse(string s, IFormatProvider? provider) => byte.Parse(s, provider);
        public static cbyte Parse(string s, NumberStyles style) => byte.Parse(s, style);
        public static cbyte Parse(string s, NumberStyles style, IFormatProvider? provider) => byte.Parse(s, style, provider);

        [CLSCompliant(false)] public static explicit operator cbyte(sbyte value) => new cbyte(CheckedConvert.ToByte(value));
        [CLSCompliant(false)] public static explicit operator cbyte(uint value) => new cbyte(CheckedConvert.ToByte(value));
        [CLSCompliant(false)] public static explicit operator cbyte(ulong value) => new cbyte(CheckedConvert.ToByte(value));
        [CLSCompliant(false)] public static implicit operator cbyte(ushort value) => new cbyte(CheckedConvert.ToByte(value));
        public static explicit operator cbyte(decimal value) => new cbyte(CheckedTruncate.ToByte(value));
        public static explicit operator cbyte(double value) => new cbyte(CheckedTruncate.ToByte(value));
        public static explicit operator cbyte(float value) => new cbyte(CheckedTruncate.ToByte(value));
        public static explicit operator cbyte(int value) => new cbyte(CheckedConvert.ToByte(value));
        public static explicit operator cbyte(long value) => new cbyte(CheckedConvert.ToByte(value));
        public static explicit operator cbyte(short value) => new cbyte(CheckedConvert.ToByte(value));
        public static implicit operator cbyte(byte value) => new cbyte(value);

        [CLSCompliant(false)] public static explicit operator sbyte(cbyte value) => CheckedConvert.ToSByte(value._value);
        [CLSCompliant(false)] public static implicit operator uint(cbyte value) => value._value;
        [CLSCompliant(false)] public static implicit operator ulong(cbyte value) => value._value;
        [CLSCompliant(false)] public static implicit operator ushort(cbyte value) => value._value;
        public static explicit operator byte(cbyte value) => CheckedConvert.ToByte(value._value);
        public static explicit operator int(cbyte value) => CheckedConvert.ToInt32(value._value);
        public static explicit operator short(cbyte value) => CheckedConvert.ToInt16(value._value);
        public static implicit operator decimal(cbyte value) => value._value;
        public static implicit operator double(cbyte value) => value._value;
        public static implicit operator float(cbyte value) => value._value;
        public static implicit operator long(cbyte value) => value._value;

        public static bool operator !=(cbyte left, cbyte right) => left._value != right._value;
        public static bool operator <(cbyte left, cbyte right) => left._value < right._value;
        public static bool operator <=(cbyte left, cbyte right) => left._value <= right._value;
        public static bool operator ==(cbyte left, cbyte right) => left._value == right._value;
        public static bool operator >(cbyte left, cbyte right) => left._value > right._value;
        public static bool operator >=(cbyte left, cbyte right) => left._value >= right._value;
        public static cbyte operator %(cbyte left, cbyte right) => CheckedArithmetic.Remainder(left._value, right._value);
        public static cbyte operator &(cbyte left, cbyte right) => (byte)(left._value & right._value);
        public static cbyte operator -(cbyte _) => MinValue;
        public static cbyte operator -(cbyte left, cbyte right) => CheckedArithmetic.Subtract(left._value, right._value);
        public static cbyte operator --(cbyte value) => value - 1;
        public static cbyte operator *(cbyte left, cbyte right) => CheckedArithmetic.Multiply(left._value, right._value);
        public static cbyte operator /(cbyte left, cbyte right) => CheckedArithmetic.Divide(left._value, right._value);
        public static cbyte operator ^(cbyte left, cbyte right) => (byte)(left._value ^ right._value);
        public static cbyte operator |(cbyte left, cbyte right) => (byte)(left._value | right._value);
        public static cbyte operator ~(cbyte value) => (byte)~value._value;
        public static cbyte operator +(cbyte left, cbyte right) => CheckedArithmetic.Add(left._value, right._value);
        public static cbyte operator +(cbyte value) => value;
        public static cbyte operator ++(cbyte value) => value + 1;
        public static cbyte operator <<(cbyte left, int right) => (byte)(left._value << right);
        public static cbyte operator >>(cbyte left, int right) => (byte)(left._value >> right);

        bool INumeric<cbyte>.IsGreaterThan(cbyte value) => this > value;
        bool INumeric<cbyte>.IsGreaterThanOrEqualTo(cbyte value) => this >= value;
        bool INumeric<cbyte>.IsLessThan(cbyte value) => this < value;
        bool INumeric<cbyte>.IsLessThanOrEqualTo(cbyte value) => this <= value;
        cbyte INumeric<cbyte>.Add(cbyte value) => this + value;
        cbyte INumeric<cbyte>.BitwiseComplement() => ~this;
        cbyte INumeric<cbyte>.Divide(cbyte value) => this / value;
        cbyte INumeric<cbyte>.LeftShift(int count) => this << count;
        cbyte INumeric<cbyte>.LogicalAnd(cbyte value) => this & value;
        cbyte INumeric<cbyte>.LogicalExclusiveOr(cbyte value) => this ^ value;
        cbyte INumeric<cbyte>.LogicalOr(cbyte value) => this | value;
        cbyte INumeric<cbyte>.Multiply(cbyte value) => this * value;
        cbyte INumeric<cbyte>.Negative() => -this;
        cbyte INumeric<cbyte>.Positive() => +this;
        cbyte INumeric<cbyte>.Remainder(cbyte value) => this % value;
        cbyte INumeric<cbyte>.RightShift(int count) => this >> count;
        cbyte INumeric<cbyte>.Subtract(cbyte value) => this - value;

        IBitConverter<cbyte> IProvider<IBitConverter<cbyte>>.GetInstance() => Utilities.Instance;
        ICast<cbyte> IProvider<ICast<cbyte>>.GetInstance() => Utilities.Instance;
        IConvert<cbyte> IProvider<IConvert<cbyte>>.GetInstance() => Utilities.Instance;
        IMath<cbyte> IProvider<IMath<cbyte>>.GetInstance() => Utilities.Instance;
        INumericStatic<cbyte> IProvider<INumericStatic<cbyte>>.GetInstance() => Utilities.Instance;
        IRandom<cbyte> IProvider<IRandom<cbyte>>.GetInstance() => Utilities.Instance;
        IStringParser<cbyte> IProvider<IStringParser<cbyte>>.GetInstance() => Utilities.Instance;

        private sealed class Utilities :
            IBitConverter<cbyte>,
            ICast<cbyte>,
            IConvert<cbyte>,
            IMath<cbyte>,
            INumericStatic<cbyte>,
            IRandom<cbyte>,
            IStringParser<cbyte>
        {
            public static readonly Utilities Instance = new Utilities();

            bool INumericStatic<cbyte>.HasFloatingPoint { get; } = false;
            bool INumericStatic<cbyte>.HasInfinity { get; } = false;
            bool INumericStatic<cbyte>.HasNaN { get; } = false;
            bool INumericStatic<cbyte>.IsFinite(cbyte x) => true;
            bool INumericStatic<cbyte>.IsInfinity(cbyte x) => false;
            bool INumericStatic<cbyte>.IsNaN(cbyte x) => false;
            bool INumericStatic<cbyte>.IsNegative(cbyte x) => false;
            bool INumericStatic<cbyte>.IsNegativeInfinity(cbyte x) => false;
            bool INumericStatic<cbyte>.IsNormal(cbyte x) => false;
            bool INumericStatic<cbyte>.IsPositiveInfinity(cbyte x) => false;
            bool INumericStatic<cbyte>.IsReal { get; } = false;
            bool INumericStatic<cbyte>.IsSigned { get; } = false;
            bool INumericStatic<cbyte>.IsSubnormal(cbyte x) => false;
            cbyte INumericStatic<cbyte>.Epsilon { get; } = 1;
            cbyte INumericStatic<cbyte>.MaxUnit { get; } = 1;
            cbyte INumericStatic<cbyte>.MaxValue => MaxValue;
            cbyte INumericStatic<cbyte>.MinUnit { get; } = 0;
            cbyte INumericStatic<cbyte>.MinValue => MinValue;
            cbyte INumericStatic<cbyte>.One { get; } = 1;
            cbyte INumericStatic<cbyte>.Ten { get; } = 10;
            cbyte INumericStatic<cbyte>.Two { get; } = 2;
            cbyte INumericStatic<cbyte>.Zero { get; } = 0;

            cbyte IMath<cbyte>.Abs(cbyte value) => value;
            cbyte IMath<cbyte>.Acos(cbyte x) => CheckedCast.ToByte(Math.Acos(x._value));
            cbyte IMath<cbyte>.Acosh(cbyte x) => CheckedCast.ToByte(MathCompat.Acosh(x._value));
            cbyte IMath<cbyte>.Asin(cbyte x) => CheckedCast.ToByte(Math.Asin(x._value));
            cbyte IMath<cbyte>.Asinh(cbyte x) => CheckedCast.ToByte(MathCompat.Asinh(x._value));
            cbyte IMath<cbyte>.Atan(cbyte x) => CheckedCast.ToByte(Math.Atan(x._value));
            cbyte IMath<cbyte>.Atan2(cbyte x, cbyte y) => CheckedCast.ToByte(Math.Atan2(x._value, y._value));
            cbyte IMath<cbyte>.Atanh(cbyte x) => CheckedCast.ToByte(MathCompat.Atanh(x._value));
            cbyte IMath<cbyte>.Cbrt(cbyte x) => CheckedCast.ToByte(MathCompat.Cbrt(x._value));
            cbyte IMath<cbyte>.Ceiling(cbyte x) => x;
            cbyte IMath<cbyte>.Clamp(cbyte x, cbyte bound1, cbyte bound2) => bound1 > bound2 ? Math.Min(bound1._value, Math.Max(bound2._value, x._value)) : Math.Min(bound2._value, Math.Max(bound1._value, x._value));
            cbyte IMath<cbyte>.Cos(cbyte x) => CheckedCast.ToByte(Math.Cos(x._value));
            cbyte IMath<cbyte>.Cosh(cbyte x) => CheckedCast.ToByte(Math.Cosh(x._value));
            cbyte IMath<cbyte>.DegreesToRadians(cbyte x) => CheckedCast.ToByte(CheckedArithmetic.Multiply(x, NumericUtilities.RadiansPerDegree));
            cbyte IMath<cbyte>.E { get; } = 2;
            cbyte IMath<cbyte>.Exp(cbyte x) => CheckedCast.ToByte(Math.Exp(x._value));
            cbyte IMath<cbyte>.Floor(cbyte x) => x;
            cbyte IMath<cbyte>.IEEERemainder(cbyte x, cbyte y) => CheckedCast.ToByte(Math.IEEERemainder(x._value, y._value));
            cbyte IMath<cbyte>.Log(cbyte x) => CheckedCast.ToByte(Math.Log(x._value));
            cbyte IMath<cbyte>.Log(cbyte x, cbyte y) => CheckedCast.ToByte(Math.Log(x._value, y._value));
            cbyte IMath<cbyte>.Log10(cbyte x) => CheckedCast.ToByte(Math.Log10(x._value));
            cbyte IMath<cbyte>.Max(cbyte x, cbyte y) => Math.Max(x._value, y._value);
            cbyte IMath<cbyte>.Min(cbyte x, cbyte y) => Math.Min(x._value, y._value);
            cbyte IMath<cbyte>.PI { get; } = 3;
            cbyte IMath<cbyte>.Pow(cbyte x, cbyte y) => CheckedArithmetic.Pow(x._value, y._value);
            cbyte IMath<cbyte>.RadiansToDegrees(cbyte x) => CheckedCast.ToByte(CheckedArithmetic.Multiply(x, NumericUtilities.DegreesPerRadian));
            cbyte IMath<cbyte>.Round(cbyte x) => x;
            cbyte IMath<cbyte>.Round(cbyte x, int digits) => x;
            cbyte IMath<cbyte>.Round(cbyte x, int digits, MidpointRounding mode) => x;
            cbyte IMath<cbyte>.Round(cbyte x, MidpointRounding mode) => x;
            cbyte IMath<cbyte>.Sin(cbyte x) => CheckedCast.ToByte(Math.Sin(x._value));
            cbyte IMath<cbyte>.Sinh(cbyte x) => CheckedCast.ToByte(Math.Sinh(x._value));
            cbyte IMath<cbyte>.Sqrt(cbyte x) => CheckedCast.ToByte(Math.Sqrt(x._value));
            cbyte IMath<cbyte>.Tan(cbyte x) => CheckedCast.ToByte(Math.Tan(x._value));
            cbyte IMath<cbyte>.Tanh(cbyte x) => CheckedCast.ToByte(Math.Tanh(x._value));
            cbyte IMath<cbyte>.Tau { get; } = 6;
            cbyte IMath<cbyte>.Truncate(cbyte x) => x;
            int IMath<cbyte>.Sign(cbyte x) => x._value == 0 ? 0 : 1;

            cbyte IBitConverter<cbyte>.Read(IReadOnlyStream<byte> stream) => stream.Read(1)[0];
            void IBitConverter<cbyte>.Write(cbyte value, IWriteOnlyStream<byte> stream) => stream.Write(new[] { value._value });

            cbyte IRandom<cbyte>.Next(Random random) => random.NextByte();
            cbyte IRandom<cbyte>.Next(Random random, cbyte bound1, cbyte bound2) => random.NextByte(bound1._value, bound2._value);

            bool IConvert<cbyte>.ToBoolean(cbyte value) => CheckedConvert.ToBoolean(value._value);
            byte IConvert<cbyte>.ToByte(cbyte value) => value._value;
            decimal IConvert<cbyte>.ToDecimal(cbyte value) => CheckedConvert.ToDecimal(value._value);
            double IConvert<cbyte>.ToDouble(cbyte value) => CheckedConvert.ToDouble(value._value);
            float IConvert<cbyte>.ToSingle(cbyte value) => CheckedConvert.ToSingle(value._value);
            int IConvert<cbyte>.ToInt32(cbyte value) => CheckedConvert.ToInt32(value._value);
            long IConvert<cbyte>.ToInt64(cbyte value) => CheckedConvert.ToInt64(value._value);
            sbyte IConvert<cbyte>.ToSByte(cbyte value) => CheckedConvert.ToSByte(value._value);
            short IConvert<cbyte>.ToInt16(cbyte value) => CheckedConvert.ToInt16(value._value);
            string IConvert<cbyte>.ToString(cbyte value) => Convert.ToString(value._value);
            uint IConvert<cbyte>.ToUInt32(cbyte value) => CheckedConvert.ToUInt16(value._value);
            ulong IConvert<cbyte>.ToUInt64(cbyte value) => CheckedConvert.ToUInt64(value._value);
            ushort IConvert<cbyte>.ToUInt16(cbyte value) => CheckedConvert.ToByte(value._value);

            cbyte IConvert<cbyte>.ToNumeric(bool value) => CheckedConvert.ToByte(value);
            cbyte IConvert<cbyte>.ToNumeric(byte value) => CheckedConvert.ToByte(value);
            cbyte IConvert<cbyte>.ToNumeric(decimal value) => CheckedConvert.ToByte(value);
            cbyte IConvert<cbyte>.ToNumeric(double value) => CheckedConvert.ToByte(value);
            cbyte IConvert<cbyte>.ToNumeric(float value) => CheckedConvert.ToByte(value);
            cbyte IConvert<cbyte>.ToNumeric(int value) => CheckedConvert.ToByte(value);
            cbyte IConvert<cbyte>.ToNumeric(long value) => CheckedConvert.ToByte(value);
            cbyte IConvert<cbyte>.ToNumeric(sbyte value) => CheckedConvert.ToByte(value);
            cbyte IConvert<cbyte>.ToNumeric(short value) => CheckedConvert.ToByte(value);
            cbyte IConvert<cbyte>.ToNumeric(string value) => Convert.ToByte(value);
            cbyte IConvert<cbyte>.ToNumeric(uint value) => CheckedConvert.ToByte(value);
            cbyte IConvert<cbyte>.ToNumeric(ulong value) => CheckedConvert.ToByte(value);
            cbyte IConvert<cbyte>.ToNumeric(ushort value) => value;

            cbyte IStringParser<cbyte>.Parse(string s) => Parse(s);
            cbyte IStringParser<cbyte>.Parse(string s, NumberStyles style, IFormatProvider? provider) => Parse(s, style, provider);

            byte ICast<cbyte>.ToByte(cbyte value) => (byte)value;
            decimal ICast<cbyte>.ToDecimal(cbyte value) => (decimal)value;
            double ICast<cbyte>.ToDouble(cbyte value) => (double)value;
            float ICast<cbyte>.ToSingle(cbyte value) => (float)value;
            int ICast<cbyte>.ToInt32(cbyte value) => (int)value;
            long ICast<cbyte>.ToInt64(cbyte value) => (long)value;
            sbyte ICast<cbyte>.ToSByte(cbyte value) => (sbyte)value;
            short ICast<cbyte>.ToInt16(cbyte value) => (short)value;
            uint ICast<cbyte>.ToUInt32(cbyte value) => (uint)value;
            ulong ICast<cbyte>.ToUInt64(cbyte value) => (ulong)value;
            ushort ICast<cbyte>.ToUInt16(cbyte value) => (ushort)value;

            cbyte ICast<cbyte>.ToNumeric(byte value) => (cbyte)value;
            cbyte ICast<cbyte>.ToNumeric(decimal value) => (cbyte)value;
            cbyte ICast<cbyte>.ToNumeric(double value) => (cbyte)value;
            cbyte ICast<cbyte>.ToNumeric(float value) => (cbyte)value;
            cbyte ICast<cbyte>.ToNumeric(int value) => (cbyte)value;
            cbyte ICast<cbyte>.ToNumeric(long value) => (cbyte)value;
            cbyte ICast<cbyte>.ToNumeric(sbyte value) => (cbyte)value;
            cbyte ICast<cbyte>.ToNumeric(short value) => (cbyte)value;
            cbyte ICast<cbyte>.ToNumeric(uint value) => (cbyte)value;
            cbyte ICast<cbyte>.ToNumeric(ulong value) => (cbyte)value;
            cbyte ICast<cbyte>.ToNumeric(ushort value) => (cbyte)value;
        }
    }
}
