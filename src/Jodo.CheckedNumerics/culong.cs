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
    public readonly struct culong : INumericExtended<culong>
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

        [CLSCompliant(false)] public static explicit operator culong(sbyte value) => new culong(NumericConvert.ToUInt64(value, Conversion.CastClamp));
        [CLSCompliant(false)] public static implicit operator culong(uint value) => new culong(value);
        [CLSCompliant(false)] public static implicit operator culong(ulong value) => new culong(value);
        [CLSCompliant(false)] public static implicit operator culong(ushort value) => new culong(value);
        public static explicit operator culong(decimal value) => new culong(NumericConvert.ToUInt64(value, Conversion.CastClamp));
        public static explicit operator culong(double value) => new culong(NumericConvert.ToUInt64(value, Conversion.CastClamp));
        public static explicit operator culong(float value) => new culong(NumericConvert.ToUInt64(value, Conversion.CastClamp));
        public static explicit operator culong(int value) => new culong(NumericConvert.ToUInt64(value, Conversion.CastClamp));
        public static explicit operator culong(long value) => new culong(NumericConvert.ToUInt64(value, Conversion.CastClamp));
        public static explicit operator culong(short value) => new culong(NumericConvert.ToUInt64(value, Conversion.CastClamp));
        public static implicit operator culong(byte value) => new culong(value);

        [CLSCompliant(false)] public static explicit operator sbyte(culong value) => NumericConvert.ToSByte(value._value, Conversion.CastClamp);
        [CLSCompliant(false)] public static explicit operator uint(culong value) => NumericConvert.ToUInt32(value._value, Conversion.CastClamp);
        [CLSCompliant(false)] public static explicit operator ushort(culong value) => NumericConvert.ToUInt16(value._value, Conversion.CastClamp);
        [CLSCompliant(false)] public static implicit operator ulong(culong value) => value._value;
        public static explicit operator byte(culong value) => NumericConvert.ToByte(value._value, Conversion.CastClamp);
        public static explicit operator int(culong value) => NumericConvert.ToInt32(value._value, Conversion.CastClamp);
        public static explicit operator long(culong value) => NumericConvert.ToInt64(value._value, Conversion.CastClamp);
        public static explicit operator short(culong value) => NumericConvert.ToInt16(value._value, Conversion.CastClamp);
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
        IConvert<culong> IProvider<IConvert<culong>>.GetInstance() => Utilities.Instance;
        IConvertUnsigned<culong> IProvider<IConvertUnsigned<culong>>.GetInstance() => Utilities.Instance;
        IMath<culong> IProvider<IMath<culong>>.GetInstance() => Utilities.Instance;
        INumericStatic<culong> IProvider<INumericStatic<culong>>.GetInstance() => Utilities.Instance;
        IRandom<culong> IProvider<IRandom<culong>>.GetInstance() => Utilities.Instance;
        IParser<culong> IProvider<IParser<culong>>.GetInstance() => Utilities.Instance;

        private sealed class Utilities :
            IBitConverter<culong>,
            IConvert<culong>,
            IConvertUnsigned<culong>,
            IMath<culong>,
            INumericStatic<culong>,
            IRandom<culong>,
            IParser<culong>
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

            bool IConvert<culong>.ToBoolean(culong value) => value._value != 0;
            byte IConvert<culong>.ToByte(culong value, Conversion mode) => NumericConvert.ToByte(value._value, mode.Clamped());
            decimal IConvert<culong>.ToDecimal(culong value, Conversion mode) => NumericConvert.ToDecimal(value._value, mode.Clamped());
            double IConvert<culong>.ToDouble(culong value, Conversion mode) => NumericConvert.ToDouble(value._value, mode.Clamped());
            float IConvert<culong>.ToSingle(culong value, Conversion mode) => NumericConvert.ToSingle(value._value, mode.Clamped());
            int IConvert<culong>.ToInt32(culong value, Conversion mode) => NumericConvert.ToInt32(value._value, mode.Clamped());
            long IConvert<culong>.ToInt64(culong value, Conversion mode) => NumericConvert.ToInt64(value._value, mode.Clamped());
            sbyte IConvertUnsigned<culong>.ToSByte(culong value, Conversion mode) => NumericConvert.ToSByte(value._value, mode.Clamped());
            short IConvert<culong>.ToInt16(culong value, Conversion mode) => NumericConvert.ToInt16(value._value, mode.Clamped());
            string IConvert<culong>.ToString(culong value) => Convert.ToString(value._value);
            uint IConvertUnsigned<culong>.ToUInt32(culong value, Conversion mode) => NumericConvert.ToUInt32(value._value, mode.Clamped());
            ulong IConvertUnsigned<culong>.ToUInt64(culong value, Conversion mode) => value._value;
            ushort IConvertUnsigned<culong>.ToUInt16(culong value, Conversion mode) => NumericConvert.ToUInt16(value._value, mode.Clamped());

            culong IConvert<culong>.ToValue(bool value) => value ? 1 : (ulong)0;
            culong IConvert<culong>.ToValue(byte value, Conversion mode) => NumericConvert.ToUInt64(value, mode.Clamped());
            culong IConvert<culong>.ToValue(decimal value, Conversion mode) => NumericConvert.ToUInt64(value, mode.Clamped());
            culong IConvert<culong>.ToValue(double value, Conversion mode) => NumericConvert.ToUInt64(value, mode.Clamped());
            culong IConvert<culong>.ToValue(float value, Conversion mode) => NumericConvert.ToUInt64(value, mode.Clamped());
            culong IConvert<culong>.ToValue(int value, Conversion mode) => NumericConvert.ToUInt64(value, mode.Clamped());
            culong IConvert<culong>.ToValue(long value, Conversion mode) => NumericConvert.ToUInt64(value, mode.Clamped());
            culong IConvertUnsigned<culong>.ToValue(sbyte value, Conversion mode) => NumericConvert.ToUInt64(value, mode.Clamped());
            culong IConvert<culong>.ToValue(short value, Conversion mode) => NumericConvert.ToUInt64(value, mode.Clamped());
            culong IConvert<culong>.ToValue(string value) => Convert.ToUInt64(value);
            culong IConvertUnsigned<culong>.ToNumeric(uint value, Conversion mode) => NumericConvert.ToUInt64(value, mode.Clamped());
            culong IConvertUnsigned<culong>.ToNumeric(ulong value, Conversion mode) => value;
            culong IConvertUnsigned<culong>.ToNumeric(ushort value, Conversion mode) => NumericConvert.ToUInt64(value, mode.Clamped());

            culong IParser<culong>.Parse(string s) => Parse(s);
            culong IParser<culong>.Parse(string s, NumberStyles style, IFormatProvider? provider) => Parse(s, style, provider);
        }
    }
}
