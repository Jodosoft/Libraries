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
    public readonly struct cint : INumeric<cint>
    {
        public static readonly cint MaxValue = new cint(int.MaxValue);
        public static readonly cint MinValue = new cint(int.MinValue);

        private readonly int _value;

        private cint(int value)
        {
            _value = value;
        }

        private cint(SerializationInfo info, StreamingContext context) : this(info.GetInt32(nameof(cint))) { }
        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context) => info.AddValue(nameof(cint), _value);

        public int CompareTo(cint other) => _value.CompareTo(other._value);
        public int CompareTo(object? obj) => obj is cint other ? CompareTo(other) : 1;
        public bool Equals(cint other) => _value == other._value;
        public override bool Equals(object? obj) => obj is cint other && Equals(other);
        public override int GetHashCode() => _value.GetHashCode();
        public override string ToString() => _value.ToString();
        public string ToString(IFormatProvider formatProvider) => _value.ToString(formatProvider);
        public string ToString(string format) => _value.ToString(format);
        public string ToString(string? format, IFormatProvider? formatProvider) => _value.ToString(format, formatProvider);

        public static bool TryParse(string s, IFormatProvider? provider, out cint result) => Try.Run(() => Parse(s, provider), out result);
        public static bool TryParse(string s, NumberStyles style, IFormatProvider? provider, out cint result) => Try.Run(() => Parse(s, style, provider), out result);
        public static bool TryParse(string s, NumberStyles style, out cint result) => Try.Run(() => Parse(s, style), out result);
        public static bool TryParse(string s, out cint result) => Try.Run(() => Parse(s), out result);
        public static cint Parse(string s) => int.Parse(s);
        public static cint Parse(string s, IFormatProvider? provider) => int.Parse(s, provider);
        public static cint Parse(string s, NumberStyles style) => int.Parse(s, style);
        public static cint Parse(string s, NumberStyles style, IFormatProvider? provider) => int.Parse(s, style, provider);

        public static explicit operator cint(decimal value) => new cint(CheckedTruncate.ToInt32(value));
        public static explicit operator cint(double value) => new cint(CheckedTruncate.ToInt32(value));
        public static explicit operator cint(float value) => new cint(CheckedTruncate.ToInt32(value));
        public static explicit operator cint(long value) => new cint(CheckedConvert.ToInt32(value));
        public static explicit operator cint(uint value) => new cint(CheckedConvert.ToInt32(value));
        public static explicit operator cint(ulong value) => new cint(CheckedConvert.ToInt32(value));
        public static implicit operator cint(byte value) => new cint(value);
        public static implicit operator cint(int value) => new cint(value);
        public static implicit operator cint(sbyte value) => new cint(value);
        public static implicit operator cint(short value) => new cint(value);
        public static implicit operator cint(ushort value) => new cint(value);

        public static explicit operator byte(cint value) => CheckedConvert.ToByte(value._value);
        public static explicit operator sbyte(cint value) => CheckedConvert.ToSByte(value._value);
        public static explicit operator short(cint value) => CheckedConvert.ToInt16(value._value);
        public static explicit operator uint(cint value) => CheckedConvert.ToUInt32(value._value);
        public static explicit operator ulong(cint value) => CheckedConvert.ToUInt64(value._value);
        public static explicit operator ushort(cint value) => CheckedConvert.ToUInt16(value._value);
        public static implicit operator decimal(cint value) => value._value;
        public static implicit operator double(cint value) => value._value;
        public static implicit operator float(cint value) => value._value;
        public static implicit operator int(cint value) => value._value;
        public static implicit operator long(cint value) => value._value;

        public static bool operator !=(cint left, cint right) => left._value != right._value;
        public static bool operator <(cint left, cint right) => left._value < right._value;
        public static bool operator <=(cint left, cint right) => left._value <= right._value;
        public static bool operator ==(cint left, cint right) => left._value == right._value;
        public static bool operator >(cint left, cint right) => left._value > right._value;
        public static bool operator >=(cint left, cint right) => left._value >= right._value;
        public static cint operator %(cint left, cint right) => CheckedArithmetic.Remainder(left._value, right._value);
        public static cint operator &(cint left, cint right) => left._value & right._value;
        public static cint operator -(cint left, cint right) => CheckedArithmetic.Subtract(left._value, right._value);
        public static cint operator --(cint value) => value - 1;
        public static cint operator -(cint value) => -value._value;
        public static cint operator *(cint left, cint right) => CheckedArithmetic.Multiply(left._value, right._value);
        public static cint operator /(cint left, cint right) => CheckedArithmetic.Divide(left._value, right._value);
        public static cint operator ^(cint left, cint right) => left._value ^ right._value;
        public static cint operator |(cint left, cint right) => left._value | right._value;
        public static cint operator ~(cint value) => ~value._value;
        public static cint operator +(cint left, cint right) => CheckedArithmetic.Add(left._value, right._value);
        public static cint operator +(cint value) => value;
        public static cint operator ++(cint value) => value + 1;
        public static cint operator <<(cint left, int right) => left._value << right;
        public static cint operator >>(cint left, int right) => left._value >> right;

        bool INumeric<cint>.IsGreaterThan(cint value) => this > value;
        bool INumeric<cint>.IsGreaterThanOrEqualTo(cint value) => this >= value;
        bool INumeric<cint>.IsLessThan(cint value) => this < value;
        bool INumeric<cint>.IsLessThanOrEqualTo(cint value) => this <= value;
        cint INumeric<cint>.Add(cint value) => this + value;
        cint INumeric<cint>.BitwiseComplement() => ~this;
        cint INumeric<cint>.Divide(cint value) => this / value;
        cint INumeric<cint>.LeftShift(int count) => this << count;
        cint INumeric<cint>.LogicalAnd(cint value) => this & value;
        cint INumeric<cint>.LogicalExclusiveOr(cint value) => this ^ value;
        cint INumeric<cint>.LogicalOr(cint value) => this | value;
        cint INumeric<cint>.Multiply(cint value) => this * value;
        cint INumeric<cint>.Negative() => -this;
        cint INumeric<cint>.Positive() => +this;
        cint INumeric<cint>.Remainder(cint value) => this % value;
        cint INumeric<cint>.RightShift(int count) => this >> count;
        cint INumeric<cint>.Subtract(cint value) => this - value;

        IBitConverter<cint> IProvider<IBitConverter<cint>>.GetInstance() => Utilities.Instance;
        ICast<cint> IProvider<ICast<cint>>.GetInstance() => Utilities.Instance;
        IConvert<cint> IProvider<IConvert<cint>>.GetInstance() => Utilities.Instance;
        IMath<cint> IProvider<IMath<cint>>.GetInstance() => Utilities.Instance;
        INumericStatic<cint> IProvider<INumericStatic<cint>>.GetInstance() => Utilities.Instance;
        IRandom<cint> IProvider<IRandom<cint>>.GetInstance() => Utilities.Instance;
        IStringParser<cint> IProvider<IStringParser<cint>>.GetInstance() => Utilities.Instance;

        private sealed class Utilities :
            IBitConverter<cint>,
            ICast<cint>,
            IConvert<cint>,
            IMath<cint>,
            INumericStatic<cint>,
            IRandom<cint>,
            IStringParser<cint>
        {
            public readonly static Utilities Instance = new Utilities();

            bool INumericStatic<cint>.HasFloatingPoint { get; } = false;
            bool INumericStatic<cint>.HasInfinity { get; } = false;
            bool INumericStatic<cint>.HasNaN { get; } = false;
            bool INumericStatic<cint>.IsFinite(cint x) => true;
            bool INumericStatic<cint>.IsInfinity(cint x) => false;
            bool INumericStatic<cint>.IsNaN(cint x) => false;
            bool INumericStatic<cint>.IsNegative(cint x) => x._value < 0;
            bool INumericStatic<cint>.IsNegativeInfinity(cint x) => false;
            bool INumericStatic<cint>.IsNormal(cint x) => false;
            bool INumericStatic<cint>.IsPositiveInfinity(cint x) => false;
            bool INumericStatic<cint>.IsReal { get; } = false;
            bool INumericStatic<cint>.IsSigned { get; } = true;
            bool INumericStatic<cint>.IsSubnormal(cint x) => false;
            cint INumericStatic<cint>.Epsilon { get; } = 1;
            cint INumericStatic<cint>.MaxUnit { get; } = 1;
            cint INumericStatic<cint>.MaxValue => MaxValue;
            cint INumericStatic<cint>.MinUnit { get; } = -1;
            cint INumericStatic<cint>.MinValue => MinValue;
            cint INumericStatic<cint>.One { get; } = 1;
            cint INumericStatic<cint>.Ten { get; } = 10;
            cint INumericStatic<cint>.Two { get; } = 2;
            cint INumericStatic<cint>.Zero { get; } = 0;

            cint IMath<cint>.Abs(cint x) => Math.Abs(x._value);
            cint IMath<cint>.Acos(cint x) => (cint)Math.Acos(x._value);
            cint IMath<cint>.Acosh(cint x) => (cint)Math.Acosh(x._value);
            cint IMath<cint>.Asin(cint x) => (cint)Math.Asin(x._value);
            cint IMath<cint>.Asinh(cint x) => (cint)Math.Asinh(x._value);
            cint IMath<cint>.Atan(cint x) => (cint)Math.Atan(x._value);
            cint IMath<cint>.Atan2(cint x, cint y) => (cint)Math.Atan2(x._value, y._value);
            cint IMath<cint>.Atanh(cint x) => (cint)Math.Atanh(x._value);
            cint IMath<cint>.Cbrt(cint x) => (cint)Math.Cbrt(x._value);
            cint IMath<cint>.Ceiling(cint x) => x;
            cint IMath<cint>.Clamp(cint x, cint bound1, cint bound2) => bound1 > bound2 ? Math.Min(bound1._value, Math.Max(bound2._value, x._value)) : Math.Min(bound2._value, Math.Max(bound1._value, x._value));
            cint IMath<cint>.Cos(cint x) => (cint)Math.Cos(x._value);
            cint IMath<cint>.Cosh(cint x) => (cint)Math.Cosh(x._value);
            cint IMath<cint>.DegreesToRadians(cint x) => (cint)CheckedArithmetic.Multiply(x, NumericUtilities.RadiansPerDegree);
            cint IMath<cint>.E { get; } = 2;
            cint IMath<cint>.Exp(cint x) => (cint)Math.Exp(x._value);
            cint IMath<cint>.Floor(cint x) => x;
            cint IMath<cint>.IEEERemainder(cint x, cint y) => (cint)Math.IEEERemainder(x._value, y._value);
            cint IMath<cint>.Log(cint x) => (cint)Math.Log(x._value);
            cint IMath<cint>.Log(cint x, cint y) => (cint)Math.Log(x._value, y._value);
            cint IMath<cint>.Log10(cint x) => (cint)Math.Log10(x._value);
            cint IMath<cint>.Max(cint x, cint y) => Math.Max(x._value, y._value);
            cint IMath<cint>.Min(cint x, cint y) => Math.Min(x._value, y._value);
            cint IMath<cint>.PI { get; } = 3;
            cint IMath<cint>.Pow(cint x, cint y) => CheckedArithmetic.Pow(x._value, y._value);
            cint IMath<cint>.RadiansToDegrees(cint x) => (cint)CheckedArithmetic.Multiply(x, NumericUtilities.DegreesPerRadian);
            cint IMath<cint>.Round(cint x) => x;
            cint IMath<cint>.Round(cint x, int digits) => x;
            cint IMath<cint>.Round(cint x, int digits, MidpointRounding mode) => x;
            cint IMath<cint>.Round(cint x, MidpointRounding mode) => x;
            cint IMath<cint>.Sin(cint x) => (cint)Math.Sin(x._value);
            cint IMath<cint>.Sinh(cint x) => (cint)Math.Sinh(x._value);
            cint IMath<cint>.Sqrt(cint x) => (cint)Math.Sqrt(x._value);
            cint IMath<cint>.Tan(cint x) => (cint)Math.Tan(x._value);
            cint IMath<cint>.Tanh(cint x) => (cint)Math.Tanh(x._value);
            cint IMath<cint>.Tau { get; } = 6;
            cint IMath<cint>.Truncate(cint x) => x;
            int IMath<cint>.Sign(cint x) => Math.Sign(x._value);

            cint IBitConverter<cint>.Read(IReadOnlyStream<byte> stream) => BitConverter.ToInt32(stream.Read(sizeof(int)));
            void IBitConverter<cint>.Write(cint value, IWriteOnlyStream<byte> stream) => stream.Write(BitConverter.GetBytes(value._value));

            cint IRandom<cint>.Next(Random random) => random.NextInt32();
            cint IRandom<cint>.Next(Random random, cint bound1, cint bound2) => random.NextInt32(bound1._value, bound2._value);

            bool IConvert<cint>.ToBoolean(cint value) => CheckedConvert.ToBoolean(value._value);
            byte IConvert<cint>.ToByte(cint value) => CheckedConvert.ToByte(value._value);
            decimal IConvert<cint>.ToDecimal(cint value) => CheckedConvert.ToDecimal(value._value);
            double IConvert<cint>.ToDouble(cint value) => CheckedConvert.ToDouble(value._value);
            float IConvert<cint>.ToSingle(cint value) => CheckedConvert.ToSingle(value._value);
            int IConvert<cint>.ToInt32(cint value) => value._value;
            long IConvert<cint>.ToInt64(cint value) => CheckedConvert.ToInt64(value._value);
            sbyte IConvert<cint>.ToSByte(cint value) => CheckedConvert.ToSByte(value._value);
            short IConvert<cint>.ToInt16(cint value) => CheckedConvert.ToInt16(value._value);
            string IConvert<cint>.ToString(cint value) => Convert.ToString(value._value);
            uint IConvert<cint>.ToUInt32(cint value) => CheckedConvert.ToUInt32(value._value);
            ulong IConvert<cint>.ToUInt64(cint value) => CheckedConvert.ToUInt64(value._value);
            ushort IConvert<cint>.ToUInt16(cint value) => CheckedConvert.ToUInt16(value._value);

            cint IConvert<cint>.ToNumeric(bool value) => CheckedConvert.ToInt32(value);
            cint IConvert<cint>.ToNumeric(byte value) => CheckedConvert.ToInt32(value);
            cint IConvert<cint>.ToNumeric(decimal value) => CheckedConvert.ToInt32(value);
            cint IConvert<cint>.ToNumeric(double value) => CheckedConvert.ToInt32(value);
            cint IConvert<cint>.ToNumeric(float value) => CheckedConvert.ToInt32(value);
            cint IConvert<cint>.ToNumeric(int value) => value;
            cint IConvert<cint>.ToNumeric(long value) => CheckedConvert.ToInt32(value);
            cint IConvert<cint>.ToNumeric(sbyte value) => CheckedConvert.ToInt32(value);
            cint IConvert<cint>.ToNumeric(short value) => CheckedConvert.ToInt32(value);
            cint IConvert<cint>.ToNumeric(string value) => Convert.ToInt32(value);
            cint IConvert<cint>.ToNumeric(uint value) => CheckedConvert.ToInt32(value);
            cint IConvert<cint>.ToNumeric(ulong value) => CheckedConvert.ToInt32(value);
            cint IConvert<cint>.ToNumeric(ushort value) => CheckedConvert.ToInt32(value);

            cint IStringParser<cint>.Parse(string s) => Parse(s);
            cint IStringParser<cint>.Parse(string s, NumberStyles style, IFormatProvider? provider) => Parse(s, style, provider);

            byte ICast<cint>.ToByte(cint value) => (byte)value;
            decimal ICast<cint>.ToDecimal(cint value) => (decimal)value;
            double ICast<cint>.ToDouble(cint value) => (double)value;
            float ICast<cint>.ToSingle(cint value) => (float)value;
            int ICast<cint>.ToInt32(cint value) => (int)value;
            long ICast<cint>.ToInt64(cint value) => (long)value;
            sbyte ICast<cint>.ToSByte(cint value) => (sbyte)value;
            short ICast<cint>.ToInt16(cint value) => (short)value;
            uint ICast<cint>.ToUInt32(cint value) => (uint)value;
            ulong ICast<cint>.ToUInt64(cint value) => (ulong)value;
            ushort ICast<cint>.ToUInt16(cint value) => (ushort)value;

            cint ICast<cint>.ToNumeric(byte value) => (cint)value;
            cint ICast<cint>.ToNumeric(decimal value) => (cint)value;
            cint ICast<cint>.ToNumeric(double value) => (cint)value;
            cint ICast<cint>.ToNumeric(float value) => (cint)value;
            cint ICast<cint>.ToNumeric(int value) => (cint)value;
            cint ICast<cint>.ToNumeric(long value) => (cint)value;
            cint ICast<cint>.ToNumeric(sbyte value) => (cint)value;
            cint ICast<cint>.ToNumeric(short value) => (cint)value;
            cint ICast<cint>.ToNumeric(uint value) => (cint)value;
            cint ICast<cint>.ToNumeric(ulong value) => (cint)value;
            cint ICast<cint>.ToNumeric(ushort value) => (cint)value;
        }
    }
}
