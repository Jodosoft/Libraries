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
using Jodo.Primitives;
using Jodo.Primitives.Compatibility;

namespace Jodo.Numerics
{
    [Serializable]
    [DebuggerDisplay("{ToString(),nq}")]
    [SuppressMessage("Style", "IDE1006:Naming Styles")]
    [SuppressMessage("csharpsquid", "S101")]
    public readonly struct xuint : INumericExtended<xuint>
    {
        public static readonly xuint MaxValue = new xuint(uint.MaxValue);
        public static readonly xuint MinValue = new xuint(uint.MinValue);

        private readonly uint _value;

        private xuint(uint value)
        {
            _value = value;
        }

        private xuint(SerializationInfo info, StreamingContext context) : this(info.GetUInt32(nameof(xuint))) { }
        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context) => info.AddValue(nameof(xuint), _value);

        public int CompareTo(xuint other) => _value.CompareTo(other._value);
        public int CompareTo(object? obj) => obj is xuint other ? CompareTo(other) : 1;
        public bool Equals(xuint other) => _value == other._value;
        public override bool Equals(object? obj) => obj is xuint other && Equals(other);
        public override int GetHashCode() => _value.GetHashCode();
        public override string ToString() => _value.ToString();
        public string ToString(IFormatProvider formatProvider) => _value.ToString(formatProvider);
        public string ToString(string format) => _value.ToString(format);
        public string ToString(string? format, IFormatProvider? formatProvider) => _value.ToString(format, formatProvider);

        public static bool TryParse(string s, IFormatProvider? provider, out xuint result) => Try.Run(() => Parse(s, provider), out result);
        public static bool TryParse(string s, NumberStyles style, IFormatProvider? provider, out xuint result) => Try.Run(() => Parse(s, style, provider), out result);
        public static bool TryParse(string s, NumberStyles style, out xuint result) => Try.Run(() => Parse(s, style), out result);
        public static bool TryParse(string s, out xuint result) => Try.Run(() => Parse(s), out result);
        public static xuint Parse(string s) => uint.Parse(s);
        public static xuint Parse(string s, IFormatProvider? provider) => uint.Parse(s, provider);
        public static xuint Parse(string s, NumberStyles style) => uint.Parse(s, style);
        public static xuint Parse(string s, NumberStyles style, IFormatProvider? provider) => uint.Parse(s, style, provider);

        [CLSCompliant(false)] public static explicit operator xuint(sbyte value) => new xuint((uint)value);
        [CLSCompliant(false)] public static explicit operator xuint(ulong value) => new xuint((uint)value);
        [CLSCompliant(false)] public static implicit operator xuint(uint value) => new xuint(value);
        [CLSCompliant(false)] public static implicit operator xuint(ushort value) => new xuint(value);
        public static explicit operator xuint(decimal value) => new xuint((uint)value);
        public static explicit operator xuint(double value) => new xuint((uint)value);
        public static explicit operator xuint(float value) => new xuint((uint)value);
        public static explicit operator xuint(int value) => new xuint((uint)value);
        public static explicit operator xuint(long value) => new xuint((uint)value);
        public static explicit operator xuint(short value) => new xuint((uint)value);
        public static implicit operator xuint(byte value) => new xuint(value);

        [CLSCompliant(false)] public static explicit operator sbyte(xuint value) => (sbyte)value._value;
        [CLSCompliant(false)] public static explicit operator ushort(xuint value) => (ushort)value._value;
        [CLSCompliant(false)] public static implicit operator uint(xuint value) => value._value;
        [CLSCompliant(false)] public static implicit operator ulong(xuint value) => value._value;
        public static explicit operator byte(xuint value) => (byte)value._value;
        public static explicit operator int(xuint value) => (int)value._value;
        public static explicit operator short(xuint value) => (short)value._value;
        public static implicit operator decimal(xuint value) => value._value;
        public static implicit operator double(xuint value) => value._value;
        public static implicit operator float(xuint value) => value._value;
        public static implicit operator long(xuint value) => value._value;

        public static bool operator !=(xuint left, xuint right) => left._value != right._value;
        public static bool operator <(xuint left, xuint right) => left._value < right._value;
        public static bool operator <=(xuint left, xuint right) => left._value <= right._value;
        public static bool operator ==(xuint left, xuint right) => left._value == right._value;
        public static bool operator >(xuint left, xuint right) => left._value > right._value;
        public static bool operator >=(xuint left, xuint right) => left._value >= right._value;
        public static xuint operator %(xuint left, xuint right) => left._value % right._value;
        public static xuint operator &(xuint left, xuint right) => left._value & right._value;
        public static xuint operator -(xuint left, xuint right) => left._value - right._value;
        public static xuint operator --(xuint value) => value._value - 1;
        public static xuint operator -(xuint value) => (uint)-value._value;
        public static xuint operator *(xuint left, xuint right) => left._value * right._value;
        public static xuint operator /(xuint left, xuint right) => left._value / right._value;
        public static xuint operator ^(xuint left, xuint right) => left._value ^ right._value;
        public static xuint operator |(xuint left, xuint right) => left._value | right._value;
        public static xuint operator ~(xuint value) => ~value._value;
        public static xuint operator +(xuint left, xuint right) => left._value + right._value;
        public static xuint operator +(xuint value) => value;
        public static xuint operator ++(xuint value) => value._value + 1;
        public static xuint operator <<(xuint left, int right) => left._value << right;
        public static xuint operator >>(xuint left, int right) => left._value >> right;

        bool INumeric<xuint>.IsGreaterThan(xuint value) => this > value;
        bool INumeric<xuint>.IsGreaterThanOrEqualTo(xuint value) => this >= value;
        bool INumeric<xuint>.IsLessThan(xuint value) => this < value;
        bool INumeric<xuint>.IsLessThanOrEqualTo(xuint value) => this <= value;
        xuint INumeric<xuint>.Add(xuint value) => this + value;
        xuint INumeric<xuint>.BitwiseComplement() => ~this;
        xuint INumeric<xuint>.Divide(xuint value) => this / value;
        xuint INumeric<xuint>.LeftShift(int count) => this << count;
        xuint INumeric<xuint>.LogicalAnd(xuint value) => this & value;
        xuint INumeric<xuint>.LogicalExclusiveOr(xuint value) => this ^ value;
        xuint INumeric<xuint>.LogicalOr(xuint value) => this | value;
        xuint INumeric<xuint>.Multiply(xuint value) => this * value;
        xuint INumeric<xuint>.Negative() => -this;
        xuint INumeric<xuint>.Positive() => +this;
        xuint INumeric<xuint>.Remainder(xuint value) => this % value;
        xuint INumeric<xuint>.RightShift(int count) => this >> count;
        xuint INumeric<xuint>.Subtract(xuint value) => this - value;

        IBitConverter<xuint> IProvider<IBitConverter<xuint>>.GetInstance() => Utilities.Instance;
        IConvert<xuint> IProvider<IConvert<xuint>>.GetInstance() => Utilities.Instance;
        IConvertUnsigned<xuint> IProvider<IConvertUnsigned<xuint>>.GetInstance() => Utilities.Instance;
        IMath<xuint> IProvider<IMath<xuint>>.GetInstance() => Utilities.Instance;
        INumericStatic<xuint> IProvider<INumericStatic<xuint>>.GetInstance() => Utilities.Instance;
        IRandom<xuint> IProvider<IRandom<xuint>>.GetInstance() => Utilities.Instance;
        IParser<xuint> IProvider<IParser<xuint>>.GetInstance() => Utilities.Instance;

        private sealed class Utilities :
            IBitConverter<xuint>,
            IConvert<xuint>,
            IConvertUnsigned<xuint>,
            IMath<xuint>,
            INumericStatic<xuint>,
            IRandom<xuint>,
            IParser<xuint>
        {
            public static readonly Utilities Instance = new Utilities();

            bool INumericStatic<xuint>.HasFloatingPoint { get; } = false;
            bool INumericStatic<xuint>.HasInfinity { get; } = false;
            bool INumericStatic<xuint>.HasNaN { get; } = false;
            bool INumericStatic<xuint>.IsFinite(xuint x) => true;
            bool INumericStatic<xuint>.IsInfinity(xuint x) => false;
            bool INumericStatic<xuint>.IsNaN(xuint x) => false;
            bool INumericStatic<xuint>.IsNegative(xuint x) => false;
            bool INumericStatic<xuint>.IsNegativeInfinity(xuint x) => false;
            bool INumericStatic<xuint>.IsNormal(xuint x) => false;
            bool INumericStatic<xuint>.IsPositiveInfinity(xuint x) => false;
            bool INumericStatic<xuint>.IsReal { get; } = false;
            bool INumericStatic<xuint>.IsSigned { get; } = false;
            bool INumericStatic<xuint>.IsSubnormal(xuint x) => false;
            xuint INumericStatic<xuint>.Epsilon { get; } = (uint)1;
            xuint INumericStatic<xuint>.MaxUnit { get; } = (uint)1;
            xuint INumericStatic<xuint>.MaxValue => MaxValue;
            xuint INumericStatic<xuint>.MinUnit { get; } = (uint)0;
            xuint INumericStatic<xuint>.MinValue => MinValue;
            xuint INumericStatic<xuint>.One { get; } = (uint)1;
            xuint INumericStatic<xuint>.Ten { get; } = (uint)10;
            xuint INumericStatic<xuint>.Two { get; } = (uint)2;
            xuint INumericStatic<xuint>.Zero { get; } = (uint)0;

            int IMath<xuint>.Sign(xuint x) => x._value == 0 ? 0 : 1;
            xuint IMath<xuint>.Abs(xuint value) => value._value;
            xuint IMath<xuint>.Acos(xuint x) => (uint)Math.Acos(x._value);
            xuint IMath<xuint>.Acosh(xuint x) => (uint)MathCompat.Acosh(x._value);
            xuint IMath<xuint>.Asin(xuint x) => (uint)Math.Asin(x._value);
            xuint IMath<xuint>.Asinh(xuint x) => (uint)MathCompat.Asinh(x._value);
            xuint IMath<xuint>.Atan(xuint x) => (uint)Math.Atan(x._value);
            xuint IMath<xuint>.Atan2(xuint x, xuint y) => (uint)Math.Atan2(x._value, y._value);
            xuint IMath<xuint>.Atanh(xuint x) => (uint)MathCompat.Atanh(x._value);
            xuint IMath<xuint>.Cbrt(xuint x) => (uint)MathCompat.Cbrt(x._value);
            xuint IMath<xuint>.Ceiling(xuint x) => x;
            xuint IMath<xuint>.Clamp(xuint x, xuint bound1, xuint bound2) => bound1 > bound2 ? Math.Min(bound1._value, Math.Max(bound2._value, x._value)) : Math.Min(bound2._value, Math.Max(bound1._value, x._value));
            xuint IMath<xuint>.Cos(xuint x) => (uint)Math.Cos(x._value);
            xuint IMath<xuint>.Cosh(xuint x) => (uint)Math.Cosh(x._value);
            xuint IMath<xuint>.DegreesToRadians(xuint x) => (uint)(x * NumericUtilities.RadiansPerDegree);
            xuint IMath<xuint>.E { get; } = (uint)2;
            xuint IMath<xuint>.Exp(xuint x) => (uint)Math.Exp(x._value);
            xuint IMath<xuint>.Floor(xuint x) => x;
            xuint IMath<xuint>.IEEERemainder(xuint x, xuint y) => (uint)Math.IEEERemainder(x._value, y._value);
            xuint IMath<xuint>.Log(xuint x) => (uint)Math.Log(x._value);
            xuint IMath<xuint>.Log(xuint x, xuint y) => (uint)Math.Log(x._value, y._value);
            xuint IMath<xuint>.Log10(xuint x) => (uint)Math.Log10(x._value);
            xuint IMath<xuint>.Max(xuint x, xuint y) => Math.Max(x._value, y._value);
            xuint IMath<xuint>.Min(xuint x, xuint y) => Math.Min(x._value, y._value);
            xuint IMath<xuint>.PI { get; } = (uint)3;
            xuint IMath<xuint>.Pow(xuint x, xuint y) => (uint)Math.Pow(x._value, y._value);
            xuint IMath<xuint>.RadiansToDegrees(xuint x) => (uint)(x * NumericUtilities.DegreesPerRadian);
            xuint IMath<xuint>.Round(xuint x) => x;
            xuint IMath<xuint>.Round(xuint x, int digits) => x;
            xuint IMath<xuint>.Round(xuint x, int digits, MidpointRounding mode) => x;
            xuint IMath<xuint>.Round(xuint x, MidpointRounding mode) => x;
            xuint IMath<xuint>.Sin(xuint x) => (uint)Math.Sin(x._value);
            xuint IMath<xuint>.Sinh(xuint x) => (uint)Math.Sinh(x._value);
            xuint IMath<xuint>.Sqrt(xuint x) => (uint)Math.Sqrt(x._value);
            xuint IMath<xuint>.Tan(xuint x) => (uint)Math.Tan(x._value);
            xuint IMath<xuint>.Tanh(xuint x) => (uint)Math.Tanh(x._value);
            xuint IMath<xuint>.Tau { get; } = (uint)6;
            xuint IMath<xuint>.Truncate(xuint x) => x;

            xuint IBitConverter<xuint>.Read(IReadOnlyStream<byte> stream) => BitConverter.ToUInt32(stream.Read(sizeof(uint)), 0);
            void IBitConverter<xuint>.Write(xuint value, IWriteOnlyStream<byte> stream) => stream.Write(BitConverter.GetBytes(value._value));

            xuint IRandom<xuint>.Next(Random random) => random.NextUInt32();
            xuint IRandom<xuint>.Next(Random random, xuint bound1, xuint bound2) => random.NextUInt32(bound1._value, bound2._value);

            bool IConvert<xuint>.ToBoolean(xuint value) => Convert.ToBoolean(value._value);
            byte IConvert<xuint>.ToByte(xuint value, Conversion mode) => NumericConvert.ToByte(value._value, mode);
            decimal IConvert<xuint>.ToDecimal(xuint value, Conversion mode) => NumericConvert.ToDecimal(value._value, mode);
            double IConvert<xuint>.ToDouble(xuint value, Conversion mode) => NumericConvert.ToDouble(value._value, mode);
            float IConvert<xuint>.ToSingle(xuint value, Conversion mode) => NumericConvert.ToSingle(value._value, mode);
            int IConvert<xuint>.ToInt32(xuint value, Conversion mode) => NumericConvert.ToInt32(value._value, mode);
            long IConvert<xuint>.ToInt64(xuint value, Conversion mode) => NumericConvert.ToInt64(value._value, mode);
            sbyte IConvertUnsigned<xuint>.ToSByte(xuint value, Conversion mode) => NumericConvert.ToSByte(value._value, mode);
            short IConvert<xuint>.ToInt16(xuint value, Conversion mode) => NumericConvert.ToInt16(value._value, mode);
            string IConvert<xuint>.ToString(xuint value) => Convert.ToString(value._value);
            uint IConvertUnsigned<xuint>.ToUInt32(xuint value, Conversion mode) => NumericConvert.ToUInt32(value._value, mode);
            ulong IConvertUnsigned<xuint>.ToUInt64(xuint value, Conversion mode) => NumericConvert.ToUInt64(value._value, mode);
            ushort IConvertUnsigned<xuint>.ToUInt16(xuint value, Conversion mode) => NumericConvert.ToUInt16(value._value, mode);

            xuint IConvert<xuint>.ToValue(bool value) => Convert.ToUInt32(value);
            xuint IConvert<xuint>.ToValue(byte value, Conversion mode) => NumericConvert.ToUInt32(value, mode);
            xuint IConvert<xuint>.ToValue(decimal value, Conversion mode) => NumericConvert.ToUInt32(value, mode);
            xuint IConvert<xuint>.ToValue(double value, Conversion mode) => NumericConvert.ToUInt32(value, mode);
            xuint IConvert<xuint>.ToValue(float value, Conversion mode) => NumericConvert.ToUInt32(value, mode);
            xuint IConvert<xuint>.ToValue(int value, Conversion mode) => NumericConvert.ToUInt32(value, mode);
            xuint IConvert<xuint>.ToValue(long value, Conversion mode) => NumericConvert.ToUInt32(value, mode);
            xuint IConvertUnsigned<xuint>.ToValue(sbyte value, Conversion mode) => NumericConvert.ToUInt32(value, mode);
            xuint IConvert<xuint>.ToValue(short value, Conversion mode) => NumericConvert.ToUInt32(value, mode);
            xuint IConvert<xuint>.ToValue(string value) => Convert.ToUInt32(value);
            xuint IConvertUnsigned<xuint>.ToNumeric(uint value, Conversion mode) => NumericConvert.ToUInt32(value, mode);
            xuint IConvertUnsigned<xuint>.ToNumeric(ulong value, Conversion mode) => NumericConvert.ToUInt32(value, mode);
            xuint IConvertUnsigned<xuint>.ToNumeric(ushort value, Conversion mode) => NumericConvert.ToUInt32(value, mode);

            xuint IParser<xuint>.Parse(string s) => Parse(s);
            xuint IParser<xuint>.Parse(string s, NumberStyles style, IFormatProvider? provider) => Parse(s, style, provider);
        }
    }
}
