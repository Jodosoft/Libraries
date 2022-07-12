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
    public readonly struct clong : INumericExtended<clong>
    {
        public static readonly clong MaxValue = new clong(long.MaxValue);
        public static readonly clong MinValue = new clong(long.MinValue);

        private readonly long _value;

        private clong(long value)
        {
            _value = value;
        }

        private clong(SerializationInfo info, StreamingContext context) : this(info.GetInt64(nameof(clong))) { }
        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context) => info.AddValue(nameof(clong), _value);

        public int CompareTo(clong other) => _value.CompareTo(other._value);
        public int CompareTo(object? obj) => obj is clong other ? CompareTo(other) : 1;
        public bool Equals(clong other) => _value == other._value;
        public override bool Equals(object? obj) => obj is clong other && Equals(other);
        public override int GetHashCode() => _value.GetHashCode();
        public override string ToString() => _value.ToString();
        public string ToString(IFormatProvider formatProvider) => _value.ToString(formatProvider);
        public string ToString(string format) => _value.ToString(format);
        public string ToString(string? format, IFormatProvider? formatProvider) => _value.ToString(format, formatProvider);

        public static bool TryParse(string s, IFormatProvider? provider, out clong result) => Try.Run(() => Parse(s, provider), out result);
        public static bool TryParse(string s, NumberStyles style, IFormatProvider? provider, out clong result) => Try.Run(() => Parse(s, style, provider), out result);
        public static bool TryParse(string s, NumberStyles style, out clong result) => Try.Run(() => Parse(s, style), out result);
        public static bool TryParse(string s, out clong result) => Try.Run(() => Parse(s), out result);
        public static clong Parse(string s) => long.Parse(s);
        public static clong Parse(string s, IFormatProvider? provider) => long.Parse(s, provider);
        public static clong Parse(string s, NumberStyles style) => long.Parse(s, style);
        public static clong Parse(string s, NumberStyles style, IFormatProvider? provider) => long.Parse(s, style, provider);

        [CLSCompliant(false)] public static explicit operator clong(ulong value) => new clong(NumericConvert.ToInt64(value, Conversion.CastClamp));
        [CLSCompliant(false)] public static implicit operator clong(sbyte value) => new clong(value);
        [CLSCompliant(false)] public static implicit operator clong(uint value) => new clong(value);
        [CLSCompliant(false)] public static implicit operator clong(ushort value) => new clong(value);
        public static explicit operator clong(decimal value) => new clong(NumericConvert.ToInt64(value, Conversion.CastClamp));
        public static explicit operator clong(double value) => new clong(NumericConvert.ToInt64(value, Conversion.CastClamp));
        public static explicit operator clong(float value) => new clong(NumericConvert.ToInt64(value, Conversion.CastClamp));
        public static implicit operator clong(byte value) => new clong(value);
        public static implicit operator clong(int value) => new clong(value);
        public static implicit operator clong(long value) => new clong(value);
        public static implicit operator clong(short value) => new clong(value);

        [CLSCompliant(false)] public static explicit operator sbyte(clong value) => NumericConvert.ToSByte(value._value, Conversion.CastClamp);
        [CLSCompliant(false)] public static explicit operator uint(clong value) => NumericConvert.ToUInt32(value._value, Conversion.CastClamp);
        [CLSCompliant(false)] public static explicit operator ulong(clong value) => NumericConvert.ToUInt64(value._value, Conversion.CastClamp);
        [CLSCompliant(false)] public static explicit operator ushort(clong value) => NumericConvert.ToUInt16(value._value, Conversion.CastClamp);
        public static explicit operator byte(clong value) => NumericConvert.ToByte(value._value, Conversion.CastClamp);
        public static explicit operator int(clong value) => NumericConvert.ToInt32(value._value, Conversion.CastClamp);
        public static explicit operator short(clong value) => NumericConvert.ToInt16(value._value, Conversion.CastClamp);
        public static implicit operator decimal(clong value) => value._value;
        public static implicit operator double(clong value) => value._value;
        public static implicit operator float(clong value) => value._value;
        public static implicit operator long(clong value) => value._value;

        public static bool operator !=(clong left, clong right) => left._value != right._value;
        public static bool operator <(clong left, clong right) => left._value < right._value;
        public static bool operator <=(clong left, clong right) => left._value <= right._value;
        public static bool operator ==(clong left, clong right) => left._value == right._value;
        public static bool operator >(clong left, clong right) => left._value > right._value;
        public static bool operator >=(clong left, clong right) => left._value >= right._value;
        public static clong operator %(clong left, clong right) => CheckedArithmetic.Remainder(left._value, right._value);
        public static clong operator &(clong left, clong right) => left._value & right._value;
        public static clong operator -(clong left, clong right) => CheckedArithmetic.Subtract(left._value, right._value);
        public static clong operator --(clong value) => CheckedArithmetic.Subtract(value._value, 1);
        public static clong operator -(clong value) => -value._value;
        public static clong operator *(clong left, clong right) => CheckedArithmetic.Multiply(left._value, right._value);
        public static clong operator /(clong left, clong right) => CheckedArithmetic.Divide(left._value, right._value);
        public static clong operator ^(clong left, clong right) => left._value ^ right._value;
        public static clong operator |(clong left, clong right) => left._value | right._value;
        public static clong operator ~(clong value) => ~value._value;
        public static clong operator +(clong left, clong right) => CheckedArithmetic.Add(left._value, right._value);
        public static clong operator +(clong value) => value;
        public static clong operator ++(clong value) => CheckedArithmetic.Add(value._value, 1);
        public static clong operator <<(clong left, int right) => left._value << right;
        public static clong operator >>(clong left, int right) => left._value >> right;

        bool INumeric<clong>.IsGreaterThan(clong value) => this > value;
        bool INumeric<clong>.IsGreaterThanOrEqualTo(clong value) => this >= value;
        bool INumeric<clong>.IsLessThan(clong value) => this < value;
        bool INumeric<clong>.IsLessThanOrEqualTo(clong value) => this <= value;
        clong INumeric<clong>.Add(clong value) => this + value;
        clong INumeric<clong>.BitwiseComplement() => ~this;
        clong INumeric<clong>.Divide(clong value) => this / value;
        clong INumeric<clong>.LeftShift(int count) => this << count;
        clong INumeric<clong>.LogicalAnd(clong value) => this & value;
        clong INumeric<clong>.LogicalExclusiveOr(clong value) => this ^ value;
        clong INumeric<clong>.LogicalOr(clong value) => this | value;
        clong INumeric<clong>.Multiply(clong value) => this * value;
        clong INumeric<clong>.Negative() => -this;
        clong INumeric<clong>.Positive() => +this;
        clong INumeric<clong>.Remainder(clong value) => this % value;
        clong INumeric<clong>.RightShift(int count) => this >> count;
        clong INumeric<clong>.Subtract(clong value) => this - value;

        IBitConverter<clong> IProvider<IBitConverter<clong>>.GetInstance() => Utilities.Instance;
        IConvert<clong> IProvider<IConvert<clong>>.GetInstance() => Utilities.Instance;
        IConvertUnsigned<clong> IProvider<IConvertUnsigned<clong>>.GetInstance() => Utilities.Instance;
        IMath<clong> IProvider<IMath<clong>>.GetInstance() => Utilities.Instance;
        INumericStatic<clong> IProvider<INumericStatic<clong>>.GetInstance() => Utilities.Instance;
        IRandom<clong> IProvider<IRandom<clong>>.GetInstance() => Utilities.Instance;
        IParser<clong> IProvider<IParser<clong>>.GetInstance() => Utilities.Instance;

        private sealed class Utilities :
            IBitConverter<clong>,
            IConvert<clong>,
            IConvertUnsigned<clong>,
            IMath<clong>,
            INumericStatic<clong>,
            IRandom<clong>,
            IParser<clong>
        {
            public static readonly Utilities Instance = new Utilities();

            bool INumericStatic<clong>.HasFloatingPoint { get; } = false;
            bool INumericStatic<clong>.HasInfinity { get; } = false;
            bool INumericStatic<clong>.HasNaN { get; } = false;
            bool INumericStatic<clong>.IsFinite(clong x) => true;
            bool INumericStatic<clong>.IsInfinity(clong x) => false;
            bool INumericStatic<clong>.IsNaN(clong x) => false;
            bool INumericStatic<clong>.IsNegative(clong x) => x._value < 0;
            bool INumericStatic<clong>.IsNegativeInfinity(clong x) => false;
            bool INumericStatic<clong>.IsNormal(clong x) => false;
            bool INumericStatic<clong>.IsPositiveInfinity(clong x) => false;
            bool INumericStatic<clong>.IsReal { get; } = false;
            bool INumericStatic<clong>.IsSigned { get; } = true;
            bool INumericStatic<clong>.IsSubnormal(clong x) => false;
            clong INumericStatic<clong>.Epsilon { get; } = 1L;
            clong INumericStatic<clong>.MaxUnit { get; } = 1L;
            clong INumericStatic<clong>.MaxValue => MaxValue;
            clong INumericStatic<clong>.MinUnit { get; } = -1L;
            clong INumericStatic<clong>.MinValue => MinValue;
            clong INumericStatic<clong>.One { get; } = 1L;
            clong INumericStatic<clong>.Ten { get; } = 10L;
            clong INumericStatic<clong>.Two { get; } = 2L;
            clong INumericStatic<clong>.Zero { get; } = 0L;

            clong IMath<clong>.Abs(clong value) => Math.Abs(value);
            clong IMath<clong>.Acos(clong x) => (clong)Math.Acos(x);
            clong IMath<clong>.Acosh(clong x) => (clong)MathCompat.Acosh(x);
            clong IMath<clong>.Asin(clong x) => (clong)Math.Asin(x);
            clong IMath<clong>.Asinh(clong x) => (clong)MathCompat.Asinh(x);
            clong IMath<clong>.Atan(clong x) => (clong)Math.Atan(x);
            clong IMath<clong>.Atan2(clong y, clong x) => (clong)Math.Atan2(y, x);
            clong IMath<clong>.Atanh(clong x) => (clong)MathCompat.Atanh(x);
            clong IMath<clong>.Cbrt(clong x) => (clong)MathCompat.Cbrt(x);
            clong IMath<clong>.Ceiling(clong x) => x;
            clong IMath<clong>.Clamp(clong x, clong bound1, clong bound2) => bound1 > bound2 ? Math.Min(bound1, Math.Max(bound2, x)) : Math.Min(bound2, Math.Max(bound1, x));
            clong IMath<clong>.Cos(clong x) => (clong)Math.Cos(x);
            clong IMath<clong>.Cosh(clong x) => (clong)Math.Cosh(x);
            clong IMath<clong>.DegreesToRadians(clong degrees) => (clong)CheckedArithmetic.Multiply(degrees, NumericUtilities.RadiansPerDegree);
            clong IMath<clong>.E { get; } = 2L;
            clong IMath<clong>.Exp(clong x) => (clong)Math.Exp(x);
            clong IMath<clong>.Floor(clong x) => x;
            clong IMath<clong>.IEEERemainder(clong x, clong y) => (clong)Math.IEEERemainder(x, y);
            clong IMath<clong>.Log(clong x) => (clong)Math.Log(x);
            clong IMath<clong>.Log(clong x, clong y) => (clong)Math.Log(x, y);
            clong IMath<clong>.Log10(clong x) => (clong)Math.Log10(x);
            clong IMath<clong>.Max(clong x, clong y) => Math.Max(x, y);
            clong IMath<clong>.Min(clong x, clong y) => Math.Min(x, y);
            clong IMath<clong>.PI { get; } = 3L;
            clong IMath<clong>.Pow(clong x, clong y) => CheckedArithmetic.Pow(x, y);
            clong IMath<clong>.RadiansToDegrees(clong radians) => (clong)CheckedArithmetic.Multiply(radians, NumericUtilities.DegreesPerRadian);
            clong IMath<clong>.Round(clong x) => x;
            clong IMath<clong>.Round(clong x, int digits) => x;
            clong IMath<clong>.Round(clong x, int digits, MidpointRounding mode) => x;
            clong IMath<clong>.Round(clong x, MidpointRounding mode) => x;
            clong IMath<clong>.Sin(clong x) => (clong)Math.Sin(x);
            clong IMath<clong>.Sinh(clong x) => (clong)Math.Sinh(x);
            clong IMath<clong>.Sqrt(clong x) => (clong)Math.Sqrt(x);
            clong IMath<clong>.Tan(clong x) => (clong)Math.Tan(x);
            clong IMath<clong>.Tanh(clong x) => (clong)Math.Tanh(x);
            clong IMath<clong>.Tau { get; } = 6L;
            clong IMath<clong>.Truncate(clong x) => x;
            int IMath<clong>.Sign(clong x) => Math.Sign(x._value);

            clong IBitConverter<clong>.Read(IReadOnlyStream<byte> stream) => BitConverter.ToInt64(stream.Read(sizeof(long)), 0);
            void IBitConverter<clong>.Write(clong value, IWriteOnlyStream<byte> stream) => stream.Write(BitConverter.GetBytes(value._value));

            clong IRandom<clong>.Next(Random random) => random.NextInt64();
            clong IRandom<clong>.Next(Random random, clong bound1, clong bound2) => random.NextInt64(bound1._value, bound2._value);

            bool IConvert<clong>.ToBoolean(clong value) => value._value != 0;
            byte IConvert<clong>.ToByte(clong value, Conversion mode) => NumericConvert.ToByte(value._value, mode.Clamped());
            decimal IConvert<clong>.ToDecimal(clong value, Conversion mode) => NumericConvert.ToDecimal(value._value, mode.Clamped());
            double IConvert<clong>.ToDouble(clong value, Conversion mode) => NumericConvert.ToDouble(value._value, mode.Clamped());
            float IConvert<clong>.ToSingle(clong value, Conversion mode) => NumericConvert.ToSingle(value._value, mode.Clamped());
            int IConvert<clong>.ToInt32(clong value, Conversion mode) => NumericConvert.ToInt32(value._value, mode.Clamped());
            long IConvert<clong>.ToInt64(clong value, Conversion mode) => value._value;
            sbyte IConvertUnsigned<clong>.ToSByte(clong value, Conversion mode) => NumericConvert.ToSByte(value._value, mode.Clamped());
            short IConvert<clong>.ToInt16(clong value, Conversion mode) => NumericConvert.ToInt16(value._value, mode.Clamped());
            string IConvert<clong>.ToString(clong value) => Convert.ToString(value._value);
            uint IConvertUnsigned<clong>.ToUInt32(clong value, Conversion mode) => NumericConvert.ToUInt32(value._value, mode.Clamped());
            ulong IConvertUnsigned<clong>.ToUInt64(clong value, Conversion mode) => NumericConvert.ToUInt64(value._value, mode.Clamped());
            ushort IConvertUnsigned<clong>.ToUInt16(clong value, Conversion mode) => NumericConvert.ToUInt16(value._value, mode.Clamped());

            clong IConvert<clong>.ToValue(bool value) => value ? 1 : 0;
            clong IConvert<clong>.ToValue(byte value, Conversion mode) => NumericConvert.ToInt64(value, mode.Clamped());
            clong IConvert<clong>.ToValue(decimal value, Conversion mode) => NumericConvert.ToInt64(value, mode.Clamped());
            clong IConvert<clong>.ToValue(double value, Conversion mode) => NumericConvert.ToInt64(value, mode.Clamped());
            clong IConvert<clong>.ToValue(float value, Conversion mode) => NumericConvert.ToInt64(value, mode.Clamped());
            clong IConvert<clong>.ToValue(int value, Conversion mode) => NumericConvert.ToInt64(value, mode.Clamped());
            clong IConvert<clong>.ToValue(long value, Conversion mode) => value;
            clong IConvertUnsigned<clong>.ToValue(sbyte value, Conversion mode) => NumericConvert.ToInt64(value, mode.Clamped());
            clong IConvert<clong>.ToValue(short value, Conversion mode) => NumericConvert.ToInt64(value, mode.Clamped());
            clong IConvert<clong>.ToValue(string value) => Convert.ToInt64(value);
            clong IConvertUnsigned<clong>.ToNumeric(uint value, Conversion mode) => NumericConvert.ToInt64(value, mode.Clamped());
            clong IConvertUnsigned<clong>.ToNumeric(ulong value, Conversion mode) => NumericConvert.ToInt64(value, mode.Clamped());
            clong IConvertUnsigned<clong>.ToNumeric(ushort value, Conversion mode) => NumericConvert.ToInt64(value, mode.Clamped());

            clong IParser<clong>.Parse(string s) => Parse(s);
            clong IParser<clong>.Parse(string s, NumberStyles style, IFormatProvider? provider) => Parse(s, style, provider);
        }
    }
}
