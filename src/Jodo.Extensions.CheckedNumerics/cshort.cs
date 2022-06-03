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
    [SuppressMessage("csharpsquid", "S101")]
    public readonly struct cshort : INumeric<cshort>
    {
        public static readonly cshort MaxValue = new cshort(short.MaxValue);
        public static readonly cshort MinValue = new cshort(short.MinValue);

        private readonly short _value;

        private cshort(short value)
        {
            _value = value;
        }

        private cshort(SerializationInfo info, StreamingContext context) : this(info.GetInt16(nameof(cshort))) { }
        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context) => info.AddValue(nameof(cshort), _value);

        public int CompareTo(cshort other) => _value.CompareTo(other._value);
        public int CompareTo(object? obj) => obj is cshort other ? CompareTo(other) : 1;
        public bool Equals(cshort other) => _value == other._value;
        public override bool Equals(object? obj) => obj is cshort other && Equals(other);
        public override int GetHashCode() => _value.GetHashCode();
        public override string ToString() => _value.ToString();
        public string ToString(IFormatProvider formatProvider) => _value.ToString(formatProvider);
        public string ToString(string format) => _value.ToString(format);
        public string ToString(string? format, IFormatProvider? formatProvider) => _value.ToString(format, formatProvider);

        public static bool TryParse(string s, IFormatProvider? provider, out cshort result) => Try.Run(() => Parse(s, provider), out result);
        public static bool TryParse(string s, NumberStyles style, IFormatProvider? provider, out cshort result) => Try.Run(() => Parse(s, style, provider), out result);
        public static bool TryParse(string s, NumberStyles style, out cshort result) => Try.Run(() => Parse(s, style), out result);
        public static bool TryParse(string s, out cshort result) => Try.Run(() => Parse(s), out result);
        public static cshort Parse(string s) => short.Parse(s);
        public static cshort Parse(string s, IFormatProvider? provider) => short.Parse(s, provider);
        public static cshort Parse(string s, NumberStyles style) => short.Parse(s, style);
        public static cshort Parse(string s, NumberStyles style, IFormatProvider? provider) => short.Parse(s, style, provider);

        public static explicit operator cshort(decimal value) => new cshort(CheckedTruncate.ToInt16(value));
        public static explicit operator cshort(double value) => new cshort(CheckedTruncate.ToInt16(value));
        public static explicit operator cshort(float value) => new cshort(CheckedTruncate.ToInt16(value));
        public static explicit operator cshort(int value) => new cshort(CheckedConvert.ToInt16(value));
        public static explicit operator cshort(long value) => new cshort(CheckedConvert.ToInt16(value));
        public static explicit operator cshort(uint value) => new cshort(CheckedConvert.ToInt16(value));
        public static explicit operator cshort(ulong value) => new cshort(CheckedConvert.ToInt16(value));
        public static explicit operator cshort(ushort value) => new cshort(CheckedConvert.ToInt16(value));
        public static implicit operator cshort(byte value) => new cshort(value);
        public static implicit operator cshort(sbyte value) => new cshort(value);
        public static implicit operator cshort(short value) => new cshort(value);

        public static explicit operator byte(cshort value) => CheckedConvert.ToByte(value._value);
        public static explicit operator sbyte(cshort value) => CheckedConvert.ToSByte(value._value);
        public static explicit operator uint(cshort value) => CheckedConvert.ToUInt16(value._value);
        public static explicit operator ulong(cshort value) => CheckedConvert.ToUInt64(value._value);
        public static explicit operator ushort(cshort value) => CheckedConvert.ToUInt16(value._value);
        public static implicit operator decimal(cshort value) => value._value;
        public static implicit operator double(cshort value) => value._value;
        public static implicit operator float(cshort value) => value._value;
        public static implicit operator int(cshort value) => value._value;
        public static implicit operator long(cshort value) => value._value;
        public static implicit operator short(cshort value) => value._value;

        public static bool operator !=(cshort left, cshort right) => left._value != right._value;
        public static bool operator <(cshort left, cshort right) => left._value < right._value;
        public static bool operator <=(cshort left, cshort right) => left._value <= right._value;
        public static bool operator ==(cshort left, cshort right) => left._value == right._value;
        public static bool operator >(cshort left, cshort right) => left._value > right._value;
        public static bool operator >=(cshort left, cshort right) => left._value >= right._value;
        public static cshort operator %(cshort left, cshort right) => CheckedArithmetic.Remainder(left._value, right._value);
        public static cshort operator &(cshort left, cshort right) => (short)(left._value & right._value);
        public static cshort operator -(cshort left, cshort right) => CheckedArithmetic.Subtract(left._value, right._value);
        public static cshort operator --(cshort value) => CheckedArithmetic.Subtract(value._value, (short)1);
        public static cshort operator -(cshort value) => (short)-value._value;
        public static cshort operator *(cshort left, cshort right) => CheckedArithmetic.Multiply(left._value, right._value);
        public static cshort operator /(cshort left, cshort right) => CheckedArithmetic.Divide(left._value, right._value);
        public static cshort operator ^(cshort left, cshort right) => (short)(left._value ^ right._value);
        public static cshort operator |(cshort left, cshort right) => (short)(left._value | right._value);
        public static cshort operator ~(cshort value) => (short)~value._value;
        public static cshort operator +(cshort left, cshort right) => CheckedArithmetic.Add(left._value, right._value);
        public static cshort operator +(cshort value) => value;
        public static cshort operator ++(cshort value) => CheckedArithmetic.Add(value._value, (short)1);
        public static cshort operator <<(cshort left, int right) => (short)(left._value << right);
        public static cshort operator >>(cshort left, int right) => (short)(left._value >> right);

        bool INumeric<cshort>.IsGreaterThan(cshort value) => this > value;
        bool INumeric<cshort>.IsGreaterThanOrEqualTo(cshort value) => this >= value;
        bool INumeric<cshort>.IsLessThan(cshort value) => this < value;
        bool INumeric<cshort>.IsLessThanOrEqualTo(cshort value) => this <= value;
        cshort INumeric<cshort>.Add(cshort value) => this + value;
        cshort INumeric<cshort>.BitwiseComplement() => ~this;
        cshort INumeric<cshort>.Divide(cshort value) => this / value;
        cshort INumeric<cshort>.LeftShift(int count) => this << count;
        cshort INumeric<cshort>.LogicalAnd(cshort value) => this & value;
        cshort INumeric<cshort>.LogicalExclusiveOr(cshort value) => this ^ value;
        cshort INumeric<cshort>.LogicalOr(cshort value) => this | value;
        cshort INumeric<cshort>.Multiply(cshort value) => this * value;
        cshort INumeric<cshort>.Negative() => -this;
        cshort INumeric<cshort>.Positive() => +this;
        cshort INumeric<cshort>.Remainder(cshort value) => this % value;
        cshort INumeric<cshort>.RightShift(int count) => this >> count;
        cshort INumeric<cshort>.Subtract(cshort value) => this - value;

        IBitConverter<cshort> IProvider<IBitConverter<cshort>>.GetInstance() => Utilities.Instance;
        ICast<cshort> IProvider<ICast<cshort>>.GetInstance() => Utilities.Instance;
        IConvert<cshort> IProvider<IConvert<cshort>>.GetInstance() => Utilities.Instance;
        IMath<cshort> IProvider<IMath<cshort>>.GetInstance() => Utilities.Instance;
        INumericStatic<cshort> IProvider<INumericStatic<cshort>>.GetInstance() => Utilities.Instance;
        IRandom<cshort> IProvider<IRandom<cshort>>.GetInstance() => Utilities.Instance;
        IStringParser<cshort> IProvider<IStringParser<cshort>>.GetInstance() => Utilities.Instance;

        private sealed class Utilities :
            IBitConverter<cshort>,
            ICast<cshort>,
            IConvert<cshort>,
            IMath<cshort>,
            INumericStatic<cshort>,
            IRandom<cshort>,
            IStringParser<cshort>
        {
            public readonly static Utilities Instance = new Utilities();

            bool INumericStatic<cshort>.HasFloatingPoint { get; } = false;
            bool INumericStatic<cshort>.HasInfinity { get; } = false;
            bool INumericStatic<cshort>.HasNaN { get; } = false;
            bool INumericStatic<cshort>.IsFinite(cshort x) => true;
            bool INumericStatic<cshort>.IsInfinity(cshort x) => false;
            bool INumericStatic<cshort>.IsNaN(cshort x) => false;
            bool INumericStatic<cshort>.IsNegative(cshort x) => x._value < 0;
            bool INumericStatic<cshort>.IsNegativeInfinity(cshort x) => false;
            bool INumericStatic<cshort>.IsNormal(cshort x) => false;
            bool INumericStatic<cshort>.IsPositiveInfinity(cshort x) => false;
            bool INumericStatic<cshort>.IsReal { get; } = false;
            bool INumericStatic<cshort>.IsSigned { get; } = true;
            bool INumericStatic<cshort>.IsSubnormal(cshort x) => false;
            cshort INumericStatic<cshort>.Epsilon { get; } = (short)1;
            cshort INumericStatic<cshort>.MaxUnit { get; } = (short)1;
            cshort INumericStatic<cshort>.MaxValue => MaxValue;
            cshort INumericStatic<cshort>.MinUnit { get; } = (short)-1;
            cshort INumericStatic<cshort>.MinValue => MinValue;
            cshort INumericStatic<cshort>.One { get; } = (short)1;
            cshort INumericStatic<cshort>.Ten { get; } = (short)10;
            cshort INumericStatic<cshort>.Two { get; } = (short)2;
            cshort INumericStatic<cshort>.Zero { get; } = (short)0;

            cshort IMath<cshort>.Abs(cshort x) => Math.Abs(x._value);
            cshort IMath<cshort>.Acos(cshort x) => (cshort)Math.Acos(x._value);
            cshort IMath<cshort>.Acosh(cshort x) => (cshort)Math.Acosh(x._value);
            cshort IMath<cshort>.Asin(cshort x) => (cshort)Math.Asin(x._value);
            cshort IMath<cshort>.Asinh(cshort x) => (cshort)Math.Asinh(x._value);
            cshort IMath<cshort>.Atan(cshort x) => (cshort)Math.Atan(x._value);
            cshort IMath<cshort>.Atan2(cshort x, cshort y) => (cshort)Math.Atan2(x._value, y._value);
            cshort IMath<cshort>.Atanh(cshort x) => (cshort)Math.Atanh(x._value);
            cshort IMath<cshort>.Cbrt(cshort x) => (cshort)Math.Cbrt(x._value);
            cshort IMath<cshort>.Ceiling(cshort x) => x;
            cshort IMath<cshort>.Clamp(cshort x, cshort bound1, cshort bound2) => bound1 > bound2 ? Math.Min(bound1._value, Math.Max(bound2._value, x._value)) : Math.Min(bound2._value, Math.Max(bound1._value, x._value));
            cshort IMath<cshort>.Cos(cshort x) => (cshort)Math.Cos(x._value);
            cshort IMath<cshort>.Cosh(cshort x) => (cshort)Math.Cosh(x._value);
            cshort IMath<cshort>.DegreesToRadians(cshort x) => (cshort)CheckedArithmetic.Multiply(x, Trig.RadiansPerDegree);
            cshort IMath<cshort>.E { get; } = (short)2;
            cshort IMath<cshort>.Exp(cshort x) => (cshort)Math.Exp(x._value);
            cshort IMath<cshort>.Floor(cshort x) => x;
            cshort IMath<cshort>.IEEERemainder(cshort x, cshort y) => (cshort)Math.IEEERemainder(x._value, y._value);
            cshort IMath<cshort>.Log(cshort x) => (cshort)Math.Log(x._value);
            cshort IMath<cshort>.Log(cshort x, cshort y) => (cshort)Math.Log(x._value, y._value);
            cshort IMath<cshort>.Log10(cshort x) => (cshort)Math.Log10(x._value);
            cshort IMath<cshort>.Max(cshort x, cshort y) => Math.Max(x._value, y._value);
            cshort IMath<cshort>.Min(cshort x, cshort y) => Math.Min(x._value, y._value);
            cshort IMath<cshort>.PI { get; } = (short)3;
            cshort IMath<cshort>.Pow(cshort x, cshort y) => CheckedArithmetic.Pow(x._value, y._value);
            cshort IMath<cshort>.RadiansToDegrees(cshort x) => (cshort)CheckedArithmetic.Multiply(x, Trig.DegreesPerRadian);
            cshort IMath<cshort>.Round(cshort x) => x;
            cshort IMath<cshort>.Round(cshort x, int digits) => x;
            cshort IMath<cshort>.Round(cshort x, int digits, MidpointRounding mode) => x;
            cshort IMath<cshort>.Round(cshort x, MidpointRounding mode) => x;
            cshort IMath<cshort>.Sin(cshort x) => (cshort)Math.Sin(x._value);
            cshort IMath<cshort>.Sinh(cshort x) => (cshort)Math.Sinh(x._value);
            cshort IMath<cshort>.Sqrt(cshort x) => (cshort)Math.Sqrt(x._value);
            cshort IMath<cshort>.Tan(cshort x) => (cshort)Math.Tan(x._value);
            cshort IMath<cshort>.Tanh(cshort x) => (cshort)Math.Tanh(x._value);
            cshort IMath<cshort>.Tau { get; } = (short)6;
            cshort IMath<cshort>.Truncate(cshort x) => x;
            int IMath<cshort>.Sign(cshort x) => Math.Sign(x._value);

            cshort IBitConverter<cshort>.Read(IReadOnlyStream<byte> stream) => BitConverter.ToInt16(stream.Read(sizeof(short)));
            void IBitConverter<cshort>.Write(cshort value, IWriteOnlyStream<byte> stream) => stream.Write(BitConverter.GetBytes(value._value));

            cshort IRandom<cshort>.Next(Random random) => random.NextInt16();
            cshort IRandom<cshort>.Next(Random random, cshort bound1, cshort bound2) => random.NextInt16(bound1._value, bound2._value);

            bool IConvert<cshort>.ToBoolean(cshort value) => CheckedConvert.ToBoolean(value._value);
            byte IConvert<cshort>.ToByte(cshort value) => CheckedConvert.ToByte(value._value);
            decimal IConvert<cshort>.ToDecimal(cshort value) => CheckedConvert.ToDecimal(value._value);
            double IConvert<cshort>.ToDouble(cshort value) => CheckedConvert.ToDouble(value._value);
            float IConvert<cshort>.ToSingle(cshort value) => CheckedConvert.ToSingle(value._value);
            int IConvert<cshort>.ToInt32(cshort value) => CheckedConvert.ToInt32(value._value);
            long IConvert<cshort>.ToInt64(cshort value) => CheckedConvert.ToInt64(value._value);
            sbyte IConvert<cshort>.ToSByte(cshort value) => CheckedConvert.ToSByte(value._value);
            short IConvert<cshort>.ToInt16(cshort value) => value._value;
            string IConvert<cshort>.ToString(cshort value) => Convert.ToString(value._value);
            uint IConvert<cshort>.ToUInt32(cshort value) => CheckedConvert.ToUInt32(value._value);
            ulong IConvert<cshort>.ToUInt64(cshort value) => CheckedConvert.ToUInt64(value._value);
            ushort IConvert<cshort>.ToUInt16(cshort value) => CheckedConvert.ToUInt16(value._value);

            cshort IConvert<cshort>.ToNumeric(bool value) => CheckedConvert.ToInt16(value);
            cshort IConvert<cshort>.ToNumeric(byte value) => CheckedConvert.ToInt16(value);
            cshort IConvert<cshort>.ToNumeric(decimal value) => CheckedConvert.ToInt16(value);
            cshort IConvert<cshort>.ToNumeric(double value) => CheckedConvert.ToInt16(value);
            cshort IConvert<cshort>.ToNumeric(float value) => CheckedConvert.ToInt16(value);
            cshort IConvert<cshort>.ToNumeric(int value) => CheckedConvert.ToInt16(value);
            cshort IConvert<cshort>.ToNumeric(long value) => CheckedConvert.ToInt16(value);
            cshort IConvert<cshort>.ToNumeric(sbyte value) => CheckedConvert.ToInt16(value);
            cshort IConvert<cshort>.ToNumeric(short value) => value;
            cshort IConvert<cshort>.ToNumeric(string value) => Convert.ToInt16(value);
            cshort IConvert<cshort>.ToNumeric(uint value) => CheckedConvert.ToInt16(value);
            cshort IConvert<cshort>.ToNumeric(ulong value) => CheckedConvert.ToInt16(value);
            cshort IConvert<cshort>.ToNumeric(ushort value) => CheckedConvert.ToInt16(value);

            cshort IStringParser<cshort>.Parse(string s) => Parse(s);
            cshort IStringParser<cshort>.Parse(string s, NumberStyles style, IFormatProvider? provider) => Parse(s, style, provider);

            byte ICast<cshort>.ToByte(cshort value) => (byte)value;
            decimal ICast<cshort>.ToDecimal(cshort value) => (decimal)value;
            double ICast<cshort>.ToDouble(cshort value) => (double)value;
            float ICast<cshort>.ToSingle(cshort value) => (float)value;
            int ICast<cshort>.ToInt32(cshort value) => (int)value;
            long ICast<cshort>.ToInt64(cshort value) => (long)value;
            sbyte ICast<cshort>.ToSByte(cshort value) => (sbyte)value;
            short ICast<cshort>.ToInt16(cshort value) => (short)value;
            uint ICast<cshort>.ToUInt32(cshort value) => (uint)value;
            ulong ICast<cshort>.ToUInt64(cshort value) => (ulong)value;
            ushort ICast<cshort>.ToUInt16(cshort value) => (ushort)value;

            cshort ICast<cshort>.ToNumeric(byte value) => (cshort)value;
            cshort ICast<cshort>.ToNumeric(decimal value) => (cshort)value;
            cshort ICast<cshort>.ToNumeric(double value) => (cshort)value;
            cshort ICast<cshort>.ToNumeric(float value) => (cshort)value;
            cshort ICast<cshort>.ToNumeric(int value) => (cshort)value;
            cshort ICast<cshort>.ToNumeric(long value) => (cshort)value;
            cshort ICast<cshort>.ToNumeric(sbyte value) => (cshort)value;
            cshort ICast<cshort>.ToNumeric(short value) => (cshort)value;
            cshort ICast<cshort>.ToNumeric(uint value) => (cshort)value;
            cshort ICast<cshort>.ToNumeric(ulong value) => (cshort)value;
            cshort ICast<cshort>.ToNumeric(ushort value) => (cshort)value;
        }
    }
}
