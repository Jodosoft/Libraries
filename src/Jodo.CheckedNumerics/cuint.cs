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
    public readonly struct cuint : INumericExtended<cuint>
    {
        public static readonly cuint MaxValue = new cuint(uint.MaxValue);
        public static readonly cuint MinValue = new cuint(uint.MinValue);

        private readonly uint _value;

        private cuint(uint value)
        {
            _value = value;
        }

        private cuint(SerializationInfo info, StreamingContext context) : this(info.GetUInt32(nameof(cuint))) { }
        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context) => info.AddValue(nameof(cuint), _value);

        public int CompareTo(object? obj) => obj is cuint other ? CompareTo(other) : 1;
        public int CompareTo(cuint other) => _value.CompareTo(other._value);
        public bool Equals(cuint other) => _value == other._value;
        public override bool Equals(object? obj) => obj is cuint other && Equals(other);
        public override int GetHashCode() => _value.GetHashCode();
        public override string ToString() => _value.ToString();
        public string ToString(IFormatProvider formatProvider) => _value.ToString(formatProvider);
        public string ToString(string format) => _value.ToString(format);
        public string ToString(string? format, IFormatProvider? formatProvider) => _value.ToString(format, formatProvider);

        public static bool TryParse(string s, IFormatProvider? provider, out cuint result) => Try.Run(() => Parse(s, provider), out result);
        public static bool TryParse(string s, NumberStyles style, IFormatProvider? provider, out cuint result) => Try.Run(() => Parse(s, style, provider), out result);
        public static bool TryParse(string s, NumberStyles style, out cuint result) => Try.Run(() => Parse(s, style), out result);
        public static bool TryParse(string s, out cuint result) => Try.Run(() => Parse(s), out result);
        public static cuint Parse(string s) => uint.Parse(s);
        public static cuint Parse(string s, IFormatProvider? provider) => uint.Parse(s, provider);
        public static cuint Parse(string s, NumberStyles style) => uint.Parse(s, style);
        public static cuint Parse(string s, NumberStyles style, IFormatProvider? provider) => uint.Parse(s, style, provider);

        [CLSCompliant(false)] public static explicit operator cuint(sbyte value) => new cuint(NumericConvert.ToUInt32(value, Conversion.CastClamp));
        [CLSCompliant(false)] public static explicit operator cuint(ulong value) => new cuint(NumericConvert.ToUInt32(value, Conversion.CastClamp));
        [CLSCompliant(false)] public static implicit operator cuint(uint value) => new cuint(value);
        [CLSCompliant(false)] public static implicit operator cuint(ushort value) => new cuint(value);
        public static explicit operator cuint(decimal value) => new cuint(NumericConvert.ToUInt32(value, Conversion.CastClamp));
        public static explicit operator cuint(double value) => new cuint(NumericConvert.ToUInt32(value, Conversion.CastClamp));
        public static explicit operator cuint(float value) => new cuint(NumericConvert.ToUInt32(value, Conversion.CastClamp));
        public static explicit operator cuint(int value) => new cuint(NumericConvert.ToUInt32(value, Conversion.CastClamp));
        public static explicit operator cuint(long value) => new cuint(NumericConvert.ToUInt32(value, Conversion.CastClamp));
        public static explicit operator cuint(short value) => new cuint(NumericConvert.ToUInt32(value, Conversion.CastClamp));
        public static implicit operator cuint(byte value) => new cuint(value);

        [CLSCompliant(false)] public static explicit operator sbyte(cuint value) => NumericConvert.ToSByte(value._value, Conversion.CastClamp);
        [CLSCompliant(false)] public static explicit operator ushort(cuint value) => NumericConvert.ToUInt16(value._value, Conversion.CastClamp);
        [CLSCompliant(false)] public static implicit operator uint(cuint value) => value._value;
        [CLSCompliant(false)] public static implicit operator ulong(cuint value) => value._value;
        public static explicit operator byte(cuint value) => NumericConvert.ToByte(value._value, Conversion.CastClamp);
        public static explicit operator int(cuint value) => NumericConvert.ToInt32(value._value, Conversion.CastClamp);
        public static explicit operator short(cuint value) => NumericConvert.ToInt16(value._value, Conversion.CastClamp);
        public static implicit operator decimal(cuint value) => value._value;
        public static implicit operator double(cuint value) => value._value;
        public static implicit operator float(cuint value) => value._value;
        public static implicit operator long(cuint value) => value._value;

        public static bool operator !=(cuint left, cuint right) => left._value != right._value;
        public static bool operator <(cuint left, cuint right) => left._value < right._value;
        public static bool operator <=(cuint left, cuint right) => left._value <= right._value;
        public static bool operator ==(cuint left, cuint right) => left._value == right._value;
        public static bool operator >(cuint left, cuint right) => left._value > right._value;
        public static bool operator >=(cuint left, cuint right) => left._value >= right._value;
        public static cuint operator %(cuint left, cuint right) => CheckedArithmetic.Remainder(left._value, right._value);
        public static cuint operator &(cuint left, cuint right) => left._value & right._value;
        public static cuint operator -(cuint _) => MinValue;
        public static cuint operator -(cuint left, cuint right) => CheckedArithmetic.Subtract(left._value, right._value);
        public static cuint operator --(cuint value) => value - 1;
        public static cuint operator *(cuint left, cuint right) => CheckedArithmetic.Multiply(left._value, right._value);
        public static cuint operator /(cuint left, cuint right) => CheckedArithmetic.Divide(left._value, right._value);
        public static cuint operator ^(cuint left, cuint right) => left._value ^ right._value;
        public static cuint operator |(cuint left, cuint right) => left._value | right._value;
        public static cuint operator ~(cuint value) => ~value._value;
        public static cuint operator +(cuint left, cuint right) => CheckedArithmetic.Add(left._value, right._value);
        public static cuint operator +(cuint value) => value;
        public static cuint operator ++(cuint value) => value + 1;
        public static cuint operator <<(cuint left, int right) => left._value << right;
        public static cuint operator >>(cuint left, int right) => left._value >> right;

        bool INumeric<cuint>.IsGreaterThan(cuint value) => this > value;
        bool INumeric<cuint>.IsGreaterThanOrEqualTo(cuint value) => this >= value;
        bool INumeric<cuint>.IsLessThan(cuint value) => this < value;
        bool INumeric<cuint>.IsLessThanOrEqualTo(cuint value) => this <= value;
        cuint INumeric<cuint>.Add(cuint value) => this + value;
        cuint INumeric<cuint>.BitwiseComplement() => ~this;
        cuint INumeric<cuint>.Divide(cuint value) => this / value;
        cuint INumeric<cuint>.LeftShift(int count) => this << count;
        cuint INumeric<cuint>.LogicalAnd(cuint value) => this & value;
        cuint INumeric<cuint>.LogicalExclusiveOr(cuint value) => this ^ value;
        cuint INumeric<cuint>.LogicalOr(cuint value) => this | value;
        cuint INumeric<cuint>.Multiply(cuint value) => this * value;
        cuint INumeric<cuint>.Negative() => -this;
        cuint INumeric<cuint>.Positive() => +this;
        cuint INumeric<cuint>.Remainder(cuint value) => this % value;
        cuint INumeric<cuint>.RightShift(int count) => this >> count;
        cuint INumeric<cuint>.Subtract(cuint value) => this - value;

        IBitConverter<cuint> IProvider<IBitConverter<cuint>>.GetInstance() => Utilities.Instance;
        IConvert<cuint> IProvider<IConvert<cuint>>.GetInstance() => Utilities.Instance;
        IConvertUnsigned<cuint> IProvider<IConvertUnsigned<cuint>>.GetInstance() => Utilities.Instance;
        IMath<cuint> IProvider<IMath<cuint>>.GetInstance() => Utilities.Instance;
        INumericStatic<cuint> IProvider<INumericStatic<cuint>>.GetInstance() => Utilities.Instance;
        IRandom<cuint> IProvider<IRandom<cuint>>.GetInstance() => Utilities.Instance;
        IParser<cuint> IProvider<IParser<cuint>>.GetInstance() => Utilities.Instance;

        private sealed class Utilities :
            IBitConverter<cuint>,
            IConvert<cuint>,
            IConvertUnsigned<cuint>,
            IMath<cuint>,
            INumericStatic<cuint>,
            IRandom<cuint>,
            IParser<cuint>
        {
            public static readonly Utilities Instance = new Utilities();

            bool INumericStatic<cuint>.HasFloatingPoint { get; } = false;
            bool INumericStatic<cuint>.HasInfinity { get; } = false;
            bool INumericStatic<cuint>.HasNaN { get; } = false;
            bool INumericStatic<cuint>.IsFinite(cuint x) => true;
            bool INumericStatic<cuint>.IsInfinity(cuint x) => false;
            bool INumericStatic<cuint>.IsNaN(cuint x) => false;
            bool INumericStatic<cuint>.IsNegative(cuint x) => false;
            bool INumericStatic<cuint>.IsNegativeInfinity(cuint x) => false;
            bool INumericStatic<cuint>.IsNormal(cuint x) => false;
            bool INumericStatic<cuint>.IsPositiveInfinity(cuint x) => false;
            bool INumericStatic<cuint>.IsReal { get; } = false;
            bool INumericStatic<cuint>.IsSigned { get; } = false;
            bool INumericStatic<cuint>.IsSubnormal(cuint x) => false;
            cuint INumericStatic<cuint>.Epsilon { get; } = 1;
            cuint INumericStatic<cuint>.MaxUnit { get; } = 1;
            cuint INumericStatic<cuint>.MaxValue => MaxValue;
            cuint INumericStatic<cuint>.MinUnit { get; } = 0;
            cuint INumericStatic<cuint>.MinValue => MinValue;
            cuint INumericStatic<cuint>.One { get; } = 1;
            cuint INumericStatic<cuint>.Ten { get; } = 10;
            cuint INumericStatic<cuint>.Two { get; } = 2;
            cuint INumericStatic<cuint>.Zero { get; } = 0;

            int IMath<cuint>.Sign(cuint x) => x._value == 0 ? 0 : 1;
            cuint IMath<cuint>.Abs(cuint value) => value;
            cuint IMath<cuint>.Acos(cuint x) => (cuint)Math.Acos(x._value);
            cuint IMath<cuint>.Acosh(cuint x) => (cuint)MathCompat.Acosh(x._value);
            cuint IMath<cuint>.Asin(cuint x) => (cuint)Math.Asin(x._value);
            cuint IMath<cuint>.Asinh(cuint x) => (cuint)MathCompat.Asinh(x._value);
            cuint IMath<cuint>.Atan(cuint x) => (cuint)Math.Atan(x._value);
            cuint IMath<cuint>.Atan2(cuint x, cuint y) => (cuint)Math.Atan2(x._value, y._value);
            cuint IMath<cuint>.Atanh(cuint x) => (cuint)MathCompat.Atanh(x._value);
            cuint IMath<cuint>.Cbrt(cuint x) => (cuint)MathCompat.Cbrt(x._value);
            cuint IMath<cuint>.Ceiling(cuint x) => x;
            cuint IMath<cuint>.Clamp(cuint x, cuint bound1, cuint bound2) => bound1 > bound2 ? Math.Min(bound1._value, Math.Max(bound2._value, x._value)) : Math.Min(bound2._value, Math.Max(bound1._value, x._value));
            cuint IMath<cuint>.Cos(cuint x) => (cuint)Math.Cos(x._value);
            cuint IMath<cuint>.Cosh(cuint x) => (cuint)Math.Cosh(x._value);
            cuint IMath<cuint>.DegreesToRadians(cuint x) => (cuint)CheckedArithmetic.Multiply(x, NumericUtilities.RadiansPerDegree);
            cuint IMath<cuint>.E { get; } = 2;
            cuint IMath<cuint>.Exp(cuint x) => (cuint)Math.Exp(x._value);
            cuint IMath<cuint>.Floor(cuint x) => x;
            cuint IMath<cuint>.IEEERemainder(cuint x, cuint y) => (cuint)Math.IEEERemainder(x._value, y._value);
            cuint IMath<cuint>.Log(cuint x) => (cuint)Math.Log(x._value);
            cuint IMath<cuint>.Log(cuint x, cuint y) => (cuint)Math.Log(x._value, y._value);
            cuint IMath<cuint>.Log10(cuint x) => (cuint)Math.Log10(x._value);
            cuint IMath<cuint>.Max(cuint x, cuint y) => Math.Max(x._value, y._value);
            cuint IMath<cuint>.Min(cuint x, cuint y) => Math.Min(x._value, y._value);
            cuint IMath<cuint>.PI { get; } = 3;
            cuint IMath<cuint>.Pow(cuint x, cuint y) => CheckedArithmetic.Pow(x._value, y._value);
            cuint IMath<cuint>.RadiansToDegrees(cuint x) => (cuint)CheckedArithmetic.Multiply(x, NumericUtilities.DegreesPerRadian);
            cuint IMath<cuint>.Round(cuint x) => x;
            cuint IMath<cuint>.Round(cuint x, int digits) => x;
            cuint IMath<cuint>.Round(cuint x, int digits, MidpointRounding mode) => x;
            cuint IMath<cuint>.Round(cuint x, MidpointRounding mode) => x;
            cuint IMath<cuint>.Sin(cuint x) => (cuint)Math.Sin(x._value);
            cuint IMath<cuint>.Sinh(cuint x) => (cuint)Math.Sinh(x._value);
            cuint IMath<cuint>.Sqrt(cuint x) => (cuint)Math.Sqrt(x._value);
            cuint IMath<cuint>.Tan(cuint x) => (cuint)Math.Tan(x._value);
            cuint IMath<cuint>.Tanh(cuint x) => (cuint)Math.Tanh(x._value);
            cuint IMath<cuint>.Tau { get; } = 6;
            cuint IMath<cuint>.Truncate(cuint x) => x;

            cuint IBitConverter<cuint>.Read(IReadOnlyStream<byte> stream) => BitConverter.ToUInt32(stream.Read(sizeof(uint)), 0);
            void IBitConverter<cuint>.Write(cuint value, IWriteOnlyStream<byte> stream) => stream.Write(BitConverter.GetBytes(value._value));

            cuint IRandom<cuint>.Next(Random random) => random.NextUInt32();
            cuint IRandom<cuint>.Next(Random random, cuint bound1, cuint bound2) => random.NextUInt32(bound1._value, bound2._value);

            bool IConvert<cuint>.ToBoolean(cuint value) => value._value != 0;
            byte IConvert<cuint>.ToByte(cuint value, Conversion mode) => NumericConvert.ToByte(value._value, mode.Clamped());
            decimal IConvert<cuint>.ToDecimal(cuint value, Conversion mode) => NumericConvert.ToDecimal(value._value, mode.Clamped());
            double IConvert<cuint>.ToDouble(cuint value, Conversion mode) => NumericConvert.ToDouble(value._value, mode.Clamped());
            float IConvert<cuint>.ToSingle(cuint value, Conversion mode) => NumericConvert.ToSingle(value._value, mode.Clamped());
            int IConvert<cuint>.ToInt32(cuint value, Conversion mode) => NumericConvert.ToInt32(value._value, mode.Clamped());
            long IConvert<cuint>.ToInt64(cuint value, Conversion mode) => NumericConvert.ToInt64(value._value, mode.Clamped());
            sbyte IConvertUnsigned<cuint>.ToSByte(cuint value, Conversion mode) => NumericConvert.ToSByte(value._value, mode.Clamped());
            short IConvert<cuint>.ToInt16(cuint value, Conversion mode) => NumericConvert.ToInt16(value._value, mode.Clamped());
            string IConvert<cuint>.ToString(cuint value) => Convert.ToString(value._value);
            uint IConvertUnsigned<cuint>.ToUInt32(cuint value, Conversion mode) => value._value;
            ulong IConvertUnsigned<cuint>.ToUInt64(cuint value, Conversion mode) => NumericConvert.ToUInt64(value._value, mode.Clamped());
            ushort IConvertUnsigned<cuint>.ToUInt16(cuint value, Conversion mode) => NumericConvert.ToUInt16(value._value, mode.Clamped());

            cuint IConvert<cuint>.ToValue(bool value) => value ? 1 : (uint)0;
            cuint IConvert<cuint>.ToValue(byte value, Conversion mode) => NumericConvert.ToUInt32(value, mode.Clamped());
            cuint IConvert<cuint>.ToValue(decimal value, Conversion mode) => NumericConvert.ToUInt32(value, mode.Clamped());
            cuint IConvert<cuint>.ToValue(double value, Conversion mode) => NumericConvert.ToUInt32(value, mode.Clamped());
            cuint IConvert<cuint>.ToValue(float value, Conversion mode) => NumericConvert.ToUInt32(value, mode.Clamped());
            cuint IConvert<cuint>.ToValue(int value, Conversion mode) => NumericConvert.ToUInt32(value, mode.Clamped());
            cuint IConvert<cuint>.ToValue(long value, Conversion mode) => NumericConvert.ToUInt32(value, mode.Clamped());
            cuint IConvertUnsigned<cuint>.ToValue(sbyte value, Conversion mode) => NumericConvert.ToUInt32(value, mode.Clamped());
            cuint IConvert<cuint>.ToValue(short value, Conversion mode) => NumericConvert.ToUInt32(value, mode.Clamped());
            cuint IConvert<cuint>.ToValue(string value) => Convert.ToUInt32(value);
            cuint IConvertUnsigned<cuint>.ToNumeric(uint value, Conversion mode) => value;
            cuint IConvertUnsigned<cuint>.ToNumeric(ulong value, Conversion mode) => NumericConvert.ToUInt32(value, mode.Clamped());
            cuint IConvertUnsigned<cuint>.ToNumeric(ushort value, Conversion mode) => NumericConvert.ToUInt32(value, mode.Clamped());

            cuint IParser<cuint>.Parse(string s) => Parse(s);
            cuint IParser<cuint>.Parse(string s, NumberStyles style, IFormatProvider? provider) => Parse(s, style, provider);
        }
    }
}
