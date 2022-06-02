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
    public readonly struct ucint : INumeric<ucint>
    {
        public static readonly ucint MaxValue = new ucint(uint.MaxValue);
        public static readonly ucint MinValue = new ucint(uint.MinValue);

        private readonly uint _value;

        private ucint(uint value)
        {
            _value = value;
        }

        private ucint(SerializationInfo info, StreamingContext context) : this(info.GetUInt32(nameof(ucint))) { }
        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context) => info.AddValue(nameof(ucint), _value);

        public int CompareTo(object? obj) => obj is ucint other ? CompareTo(other) : 1;
        public int CompareTo(ucint other) => _value.CompareTo(other._value);
        public bool Equals(ucint other) => _value == other._value;
        public override bool Equals(object? obj) => obj is ucint other && Equals(other);
        public override int GetHashCode() => _value.GetHashCode();
        public override string ToString() => _value.ToString();
        public string ToString(IFormatProvider formatProvider) => _value.ToString(formatProvider);
        public string ToString(string format) => _value.ToString(format);
        public string ToString(string format, IFormatProvider formatProvider) => _value.ToString(format, formatProvider);

        public static bool TryParse(string s, IFormatProvider provider, out ucint result) => Try.Run(() => Parse(s, provider), out result);
        public static bool TryParse(string s, NumberStyles style, IFormatProvider provider, out ucint result) => Try.Run(() => Parse(s, style, provider), out result);
        public static bool TryParse(string s, NumberStyles style, out ucint result) => Try.Run(() => Parse(s, style), out result);
        public static bool TryParse(string s, out ucint result) => Try.Run(() => Parse(s), out result);
        public static ucint Parse(string s) => uint.Parse(s);
        public static ucint Parse(string s, IFormatProvider provider) => uint.Parse(s, provider);
        public static ucint Parse(string s, NumberStyles style) => uint.Parse(s, style);
        public static ucint Parse(string s, NumberStyles style, IFormatProvider provider) => uint.Parse(s, style, provider);

        public static explicit operator ucint(decimal value) => new ucint(CheckedTruncate.ToUInt32(value));
        public static explicit operator ucint(double value) => new ucint(CheckedTruncate.ToUInt32(value));
        public static explicit operator ucint(float value) => new ucint(CheckedTruncate.ToUInt32(value));
        public static explicit operator ucint(int value) => new ucint(CheckedConvert.ToUInt32(value));
        public static explicit operator ucint(long value) => new ucint(CheckedConvert.ToUInt32(value));
        public static explicit operator ucint(sbyte value) => new ucint(CheckedConvert.ToUInt32(value));
        public static explicit operator ucint(short value) => new ucint(CheckedConvert.ToUInt32(value));
        public static explicit operator ucint(ulong value) => new ucint(CheckedConvert.ToUInt32(value));
        public static implicit operator ucint(byte value) => new ucint(value);
        public static implicit operator ucint(uint value) => new ucint(value);
        public static implicit operator ucint(ushort value) => new ucint(value);

        public static explicit operator byte(ucint value) => CheckedConvert.ToByte(value._value);
        public static explicit operator int(ucint value) => CheckedConvert.ToInt32(value._value);
        public static explicit operator sbyte(ucint value) => CheckedConvert.ToSByte(value._value);
        public static explicit operator short(ucint value) => CheckedConvert.ToInt16(value._value);
        public static explicit operator ushort(ucint value) => CheckedConvert.ToUInt16(value._value);
        public static implicit operator decimal(ucint value) => value._value;
        public static implicit operator double(ucint value) => value._value;
        public static implicit operator float(ucint value) => value._value;
        public static implicit operator long(ucint value) => value._value;
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

        bool INumeric<ucint>.IsGreaterThan(ucint value) => this > value;
        bool INumeric<ucint>.IsGreaterThanOrEqualTo(ucint value) => this >= value;
        bool INumeric<ucint>.IsLessThan(ucint value) => this < value;
        bool INumeric<ucint>.IsLessThanOrEqualTo(ucint value) => this <= value;
        ucint INumeric<ucint>.Add(ucint value) => this + value;
        ucint INumeric<ucint>.BitwiseComplement() => ~this;
        ucint INumeric<ucint>.Divide(ucint value) => this / value;
        ucint INumeric<ucint>.LeftShift(int count) => this << count;
        ucint INumeric<ucint>.LogicalAnd(ucint value) => this & value;
        ucint INumeric<ucint>.LogicalExclusiveOr(ucint value) => this ^ value;
        ucint INumeric<ucint>.LogicalOr(ucint value) => this | value;
        ucint INumeric<ucint>.Multiply(ucint value) => this * value;
        ucint INumeric<ucint>.Negative() => -this;
        ucint INumeric<ucint>.Positive() => +this;
        ucint INumeric<ucint>.Remainder(ucint value) => this % value;
        ucint INumeric<ucint>.RightShift(int count) => this >> count;
        ucint INumeric<ucint>.Subtract(ucint value) => this - value;

        IBitConverter<ucint> IProvider<IBitConverter<ucint>>.GetInstance() => Utilities.Instance;
        ICast<ucint> IProvider<ICast<ucint>>.GetInstance() => Utilities.Instance;
        IConvert<ucint> IProvider<IConvert<ucint>>.GetInstance() => Utilities.Instance;
        IMath<ucint> IProvider<IMath<ucint>>.GetInstance() => Utilities.Instance;
        INumericFunctions<ucint> IProvider<INumericFunctions<ucint>>.GetInstance() => Utilities.Instance;
        IRandom<ucint> IProvider<IRandom<ucint>>.GetInstance() => Utilities.Instance;
        IStringParser<ucint> IProvider<IStringParser<ucint>>.GetInstance() => Utilities.Instance;

        private sealed class Utilities :
            IBitConverter<ucint>,
            ICast<ucint>,
            IConvert<ucint>,
            IMath<ucint>,
            INumericFunctions<ucint>,
            IRandom<ucint>,
            IStringParser<ucint>
        {
            public readonly static Utilities Instance = new Utilities();

            bool INumericFunctions<ucint>.HasFloatingPoint { get; } = false;
            bool INumericFunctions<ucint>.IsFinite(ucint x) => true;
            bool INumericFunctions<ucint>.IsInfinity(ucint x) => false;
            bool INumericFunctions<ucint>.IsNaN(ucint x) => false;
            bool INumericFunctions<ucint>.IsNegative(ucint x) => false;
            bool INumericFunctions<ucint>.IsNegativeInfinity(ucint x) => false;
            bool INumericFunctions<ucint>.IsNormal(ucint x) => false;
            bool INumericFunctions<ucint>.IsPositiveInfinity(ucint x) => false;
            bool INumericFunctions<ucint>.IsReal { get; } = false;
            bool INumericFunctions<ucint>.IsSigned { get; } = false;
            bool INumericFunctions<ucint>.IsSubnormal(ucint x) => false;
            ucint INumericFunctions<ucint>.Epsilon { get; } = 1;
            ucint INumericFunctions<ucint>.MaxUnit { get; } = 1;
            ucint INumericFunctions<ucint>.MaxValue => MaxValue;
            ucint INumericFunctions<ucint>.MinUnit { get; } = 0;
            ucint INumericFunctions<ucint>.MinValue => MinValue;
            ucint INumericFunctions<ucint>.One { get; } = 1;
            ucint INumericFunctions<ucint>.Ten { get; } = 10;
            ucint INumericFunctions<ucint>.Two { get; } = 2;
            ucint INumericFunctions<ucint>.Zero { get; } = 0;

            int IMath<ucint>.Sign(ucint x) => x._value == 0 ? 0 : 1;
            ucint IMath<ucint>.Abs(ucint x) => x;
            ucint IMath<ucint>.Acos(ucint x) => (ucint)Math.Acos(x._value);
            ucint IMath<ucint>.Acosh(ucint x) => (ucint)Math.Acosh(x._value);
            ucint IMath<ucint>.Asin(ucint x) => (ucint)Math.Asin(x._value);
            ucint IMath<ucint>.Asinh(ucint x) => (ucint)Math.Asinh(x._value);
            ucint IMath<ucint>.Atan(ucint x) => (ucint)Math.Atan(x._value);
            ucint IMath<ucint>.Atan2(ucint x, ucint y) => (ucint)Math.Atan2(x._value, y._value);
            ucint IMath<ucint>.Atanh(ucint x) => (ucint)Math.Atanh(x._value);
            ucint IMath<ucint>.Cbrt(ucint x) => (ucint)Math.Cbrt(x._value);
            ucint IMath<ucint>.Ceiling(ucint x) => x;
            ucint IMath<ucint>.Clamp(ucint x, ucint bound1, ucint bound2) => bound1 > bound2 ? Math.Min(bound1._value, Math.Max(bound2._value, x._value)) : Math.Min(bound2._value, Math.Max(bound1._value, x._value));
            ucint IMath<ucint>.Cos(ucint x) => (ucint)Math.Cos(x._value);
            ucint IMath<ucint>.Cosh(ucint x) => (ucint)Math.Cosh(x._value);
            ucint IMath<ucint>.DegreesToRadians(ucint x) => (ucint)CheckedArithmetic.Multiply(x, Trig.RadiansPerDegree);
            ucint IMath<ucint>.E { get; } = 2;
            ucint IMath<ucint>.Exp(ucint x) => (ucint)Math.Exp(x._value);
            ucint IMath<ucint>.Floor(ucint x) => x;
            ucint IMath<ucint>.IEEERemainder(ucint x, ucint y) => (ucint)Math.IEEERemainder(x._value, y._value);
            ucint IMath<ucint>.Log(ucint x) => (ucint)Math.Log(x._value);
            ucint IMath<ucint>.Log(ucint x, ucint y) => (ucint)Math.Log(x._value, y._value);
            ucint IMath<ucint>.Log10(ucint x) => (ucint)Math.Log10(x._value);
            ucint IMath<ucint>.Max(ucint x, ucint y) => Math.Max(x._value, y._value);
            ucint IMath<ucint>.Min(ucint x, ucint y) => Math.Min(x._value, y._value);
            ucint IMath<ucint>.PI { get; } = 3;
            ucint IMath<ucint>.Pow(ucint x, ucint y) => CheckedArithmetic.Pow(x._value, y._value);
            ucint IMath<ucint>.RadiansToDegrees(ucint x) => (ucint)CheckedArithmetic.Multiply(x, Trig.DegreesPerRadian);
            ucint IMath<ucint>.Round(ucint x) => x;
            ucint IMath<ucint>.Round(ucint x, int digits) => x;
            ucint IMath<ucint>.Round(ucint x, int digits, MidpointRounding mode) => x;
            ucint IMath<ucint>.Round(ucint x, MidpointRounding mode) => x;
            ucint IMath<ucint>.Sin(ucint x) => (ucint)Math.Sin(x._value);
            ucint IMath<ucint>.Sinh(ucint x) => (ucint)Math.Sinh(x._value);
            ucint IMath<ucint>.Sqrt(ucint x) => (ucint)Math.Sqrt(x._value);
            ucint IMath<ucint>.Tan(ucint x) => (ucint)Math.Tan(x._value);
            ucint IMath<ucint>.Tanh(ucint x) => (ucint)Math.Tanh(x._value);
            ucint IMath<ucint>.Tau { get; } = 6;
            ucint IMath<ucint>.Truncate(ucint x) => x;

            ucint IBitConverter<ucint>.Read(IReadOnlyStream<byte> stream) => BitConverter.ToUInt32(stream.Read(sizeof(uint)));
            void IBitConverter<ucint>.Write(ucint value, IWriteOnlyStream<byte> stream) => stream.Write(BitConverter.GetBytes(value._value));

            ucint IRandom<ucint>.Next(Random random) => random.NextUInt32();
            ucint IRandom<ucint>.Next(Random random, ucint bound1, ucint bound2) => random.NextUInt32(bound1._value, bound2._value);

            bool IConvert<ucint>.ToBoolean(ucint value) => CheckedConvert.ToBoolean(value._value);
            byte IConvert<ucint>.ToByte(ucint value) => CheckedConvert.ToByte(value._value);
            decimal IConvert<ucint>.ToDecimal(ucint value) => CheckedConvert.ToDecimal(value._value);
            double IConvert<ucint>.ToDouble(ucint value) => CheckedConvert.ToDouble(value._value);
            float IConvert<ucint>.ToSingle(ucint value) => CheckedConvert.ToSingle(value._value);
            int IConvert<ucint>.ToInt32(ucint value) => CheckedConvert.ToInt32(value._value);
            long IConvert<ucint>.ToInt64(ucint value) => CheckedConvert.ToInt64(value._value);
            sbyte IConvert<ucint>.ToSByte(ucint value) => CheckedConvert.ToSByte(value._value);
            short IConvert<ucint>.ToInt16(ucint value) => CheckedConvert.ToInt16(value._value);
            string IConvert<ucint>.ToString(ucint value) => Convert.ToString(value._value);
            string IConvert<ucint>.ToString(ucint value, IFormatProvider provider) => Convert.ToString(value._value, provider);
            uint IConvert<ucint>.ToUInt32(ucint value) => value._value;
            ulong IConvert<ucint>.ToUInt64(ucint value) => CheckedConvert.ToUInt64(value._value);
            ushort IConvert<ucint>.ToUInt16(ucint value) => CheckedConvert.ToUInt16(value._value);

            ucint IConvert<ucint>.ToValue(bool value) => CheckedConvert.ToUInt32(value);
            ucint IConvert<ucint>.ToValue(byte value) => CheckedConvert.ToUInt32(value);
            ucint IConvert<ucint>.ToValue(decimal value) => CheckedConvert.ToUInt32(value);
            ucint IConvert<ucint>.ToValue(double value) => CheckedConvert.ToUInt32(value);
            ucint IConvert<ucint>.ToValue(float value) => CheckedConvert.ToUInt32(value);
            ucint IConvert<ucint>.ToValue(int value) => CheckedConvert.ToUInt32(value);
            ucint IConvert<ucint>.ToValue(long value) => CheckedConvert.ToUInt32(value);
            ucint IConvert<ucint>.ToValue(sbyte value) => CheckedConvert.ToUInt32(value);
            ucint IConvert<ucint>.ToValue(short value) => CheckedConvert.ToUInt32(value);
            ucint IConvert<ucint>.ToValue(string value) => Convert.ToUInt32(value);
            ucint IConvert<ucint>.ToValue(string value, IFormatProvider provider) => Convert.ToUInt32(value, provider);
            ucint IConvert<ucint>.ToValue(uint value) => value;
            ucint IConvert<ucint>.ToValue(ulong value) => CheckedConvert.ToUInt32(value);
            ucint IConvert<ucint>.ToValue(ushort value) => CheckedConvert.ToUInt32(value);

            bool IStringParser<ucint>.TryParse(string s, IFormatProvider provider, out ucint result) => TryParse(s, provider, out result);
            bool IStringParser<ucint>.TryParse(string s, NumberStyles style, IFormatProvider provider, out ucint result) => TryParse(s, style, provider, out result);
            bool IStringParser<ucint>.TryParse(string s, NumberStyles style, out ucint result) => TryParse(s, style, out result);
            bool IStringParser<ucint>.TryParse(string s, out ucint result) => TryParse(s, out result);
            ucint IStringParser<ucint>.Parse(string s) => Parse(s);
            ucint IStringParser<ucint>.Parse(string s, IFormatProvider provider) => Parse(s, provider);
            ucint IStringParser<ucint>.Parse(string s, NumberStyles style) => Parse(s, style);
            ucint IStringParser<ucint>.Parse(string s, NumberStyles style, IFormatProvider provider) => Parse(s, style, provider);

            byte ICast<ucint>.ToByte(ucint value) => (byte)value;
            decimal ICast<ucint>.ToDecimal(ucint value) => (decimal)value;
            double ICast<ucint>.ToDouble(ucint value) => (double)value;
            float ICast<ucint>.ToSingle(ucint value) => (float)value;
            int ICast<ucint>.ToInt32(ucint value) => (int)value;
            long ICast<ucint>.ToInt64(ucint value) => (long)value;
            sbyte ICast<ucint>.ToSByte(ucint value) => (sbyte)value;
            short ICast<ucint>.ToInt16(ucint value) => (short)value;
            uint ICast<ucint>.ToUInt32(ucint value) => (uint)value;
            ulong ICast<ucint>.ToUInt64(ucint value) => (ulong)value;
            ushort ICast<ucint>.ToUInt16(ucint value) => (ushort)value;

            ucint ICast<ucint>.ToValue(byte value) => (ucint)value;
            ucint ICast<ucint>.ToValue(decimal value) => (ucint)value;
            ucint ICast<ucint>.ToValue(double value) => (ucint)value;
            ucint ICast<ucint>.ToValue(float value) => (ucint)value;
            ucint ICast<ucint>.ToValue(int value) => (ucint)value;
            ucint ICast<ucint>.ToValue(long value) => (ucint)value;
            ucint ICast<ucint>.ToValue(sbyte value) => (ucint)value;
            ucint ICast<ucint>.ToValue(short value) => (ucint)value;
            ucint ICast<ucint>.ToValue(uint value) => (ucint)value;
            ucint ICast<ucint>.ToValue(ulong value) => (ucint)value;
            ucint ICast<ucint>.ToValue(ushort value) => (ucint)value;
        }
    }
}
