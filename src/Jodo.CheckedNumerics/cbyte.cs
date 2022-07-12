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
    public readonly struct cbyte : INumericExtended<cbyte>
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

        [CLSCompliant(false)] public static explicit operator cbyte(sbyte value) => new cbyte(NumericConvert.ToByte(value, Conversion.CastClamp));
        [CLSCompliant(false)] public static explicit operator cbyte(uint value) => new cbyte(NumericConvert.ToByte(value, Conversion.CastClamp));
        [CLSCompliant(false)] public static explicit operator cbyte(ulong value) => new cbyte(NumericConvert.ToByte(value, Conversion.CastClamp));
        [CLSCompliant(false)] public static implicit operator cbyte(ushort value) => new cbyte(NumericConvert.ToByte(value, Conversion.CastClamp));
        public static explicit operator cbyte(decimal value) => new cbyte(NumericConvert.ToByte(value, Conversion.CastClamp));
        public static explicit operator cbyte(double value) => new cbyte(NumericConvert.ToByte(value, Conversion.CastClamp));
        public static explicit operator cbyte(float value) => new cbyte(NumericConvert.ToByte(value, Conversion.CastClamp));
        public static explicit operator cbyte(int value) => new cbyte(NumericConvert.ToByte(value, Conversion.CastClamp));
        public static explicit operator cbyte(long value) => new cbyte(NumericConvert.ToByte(value, Conversion.CastClamp));
        public static explicit operator cbyte(short value) => new cbyte(NumericConvert.ToByte(value, Conversion.CastClamp));
        public static implicit operator cbyte(byte value) => new cbyte(value);

        [CLSCompliant(false)] public static explicit operator sbyte(cbyte value) => NumericConvert.ToSByte(value._value, Conversion.CastClamp);
        [CLSCompliant(false)] public static implicit operator uint(cbyte value) => value._value;
        [CLSCompliant(false)] public static implicit operator ulong(cbyte value) => value._value;
        [CLSCompliant(false)] public static implicit operator ushort(cbyte value) => value._value;
        public static explicit operator byte(cbyte value) => NumericConvert.ToByte(value._value, Conversion.CastClamp);
        public static explicit operator int(cbyte value) => NumericConvert.ToInt32(value._value, Conversion.CastClamp);
        public static explicit operator short(cbyte value) => NumericConvert.ToInt16(value._value, Conversion.CastClamp);
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
        IConvert<cbyte> IProvider<IConvert<cbyte>>.GetInstance() => Utilities.Instance;
        IConvertUnsigned<cbyte> IProvider<IConvertUnsigned<cbyte>>.GetInstance() => Utilities.Instance;
        IMath<cbyte> IProvider<IMath<cbyte>>.GetInstance() => Utilities.Instance;
        INumericStatic<cbyte> IProvider<INumericStatic<cbyte>>.GetInstance() => Utilities.Instance;
        IRandom<cbyte> IProvider<IRandom<cbyte>>.GetInstance() => Utilities.Instance;
        IParser<cbyte> IProvider<IParser<cbyte>>.GetInstance() => Utilities.Instance;

        private sealed class Utilities :
            IBitConverter<cbyte>,
            IConvert<cbyte>,
            IConvertUnsigned<cbyte>,
            IMath<cbyte>,
            INumericStatic<cbyte>,
            IRandom<cbyte>,
            IParser<cbyte>
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
            cbyte IMath<cbyte>.Acos(cbyte x) => NumericConvert.ToByte(Math.Acos(x._value), Conversion.CastClamp);
            cbyte IMath<cbyte>.Acosh(cbyte x) => NumericConvert.ToByte(MathCompat.Acosh(x._value), Conversion.CastClamp);
            cbyte IMath<cbyte>.Asin(cbyte x) => NumericConvert.ToByte(Math.Asin(x._value), Conversion.CastClamp);
            cbyte IMath<cbyte>.Asinh(cbyte x) => NumericConvert.ToByte(MathCompat.Asinh(x._value), Conversion.CastClamp);
            cbyte IMath<cbyte>.Atan(cbyte x) => NumericConvert.ToByte(Math.Atan(x._value), Conversion.CastClamp);
            cbyte IMath<cbyte>.Atan2(cbyte x, cbyte y) => NumericConvert.ToByte(Math.Atan2(x._value, y._value), Conversion.CastClamp);
            cbyte IMath<cbyte>.Atanh(cbyte x) => NumericConvert.ToByte(MathCompat.Atanh(x._value), Conversion.CastClamp);
            cbyte IMath<cbyte>.Cbrt(cbyte x) => NumericConvert.ToByte(MathCompat.Cbrt(x._value), Conversion.CastClamp);
            cbyte IMath<cbyte>.Ceiling(cbyte x) => x;
            cbyte IMath<cbyte>.Clamp(cbyte x, cbyte bound1, cbyte bound2) => bound1 > bound2 ? Math.Min(bound1._value, Math.Max(bound2._value, x._value)) : Math.Min(bound2._value, Math.Max(bound1._value, x._value));
            cbyte IMath<cbyte>.Cos(cbyte x) => NumericConvert.ToByte(Math.Cos(x._value), Conversion.CastClamp);
            cbyte IMath<cbyte>.Cosh(cbyte x) => NumericConvert.ToByte(Math.Cosh(x._value), Conversion.CastClamp);
            cbyte IMath<cbyte>.DegreesToRadians(cbyte x) => NumericConvert.ToByte(CheckedArithmetic.Multiply(x, NumericUtilities.RadiansPerDegree), Conversion.CastClamp);
            cbyte IMath<cbyte>.E { get; } = 2;
            cbyte IMath<cbyte>.Exp(cbyte x) => NumericConvert.ToByte(Math.Exp(x._value), Conversion.CastClamp);
            cbyte IMath<cbyte>.Floor(cbyte x) => x;
            cbyte IMath<cbyte>.IEEERemainder(cbyte x, cbyte y) => NumericConvert.ToByte(Math.IEEERemainder(x._value, y._value), Conversion.CastClamp);
            cbyte IMath<cbyte>.Log(cbyte x) => NumericConvert.ToByte(Math.Log(x._value), Conversion.CastClamp);
            cbyte IMath<cbyte>.Log(cbyte x, cbyte y) => NumericConvert.ToByte(Math.Log(x._value, y._value), Conversion.CastClamp);
            cbyte IMath<cbyte>.Log10(cbyte x) => NumericConvert.ToByte(Math.Log10(x._value), Conversion.CastClamp);
            cbyte IMath<cbyte>.Max(cbyte x, cbyte y) => Math.Max(x._value, y._value);
            cbyte IMath<cbyte>.Min(cbyte x, cbyte y) => Math.Min(x._value, y._value);
            cbyte IMath<cbyte>.PI { get; } = 3;
            cbyte IMath<cbyte>.Pow(cbyte x, cbyte y) => CheckedArithmetic.Pow(x._value, y._value);
            cbyte IMath<cbyte>.RadiansToDegrees(cbyte x) => NumericConvert.ToByte(CheckedArithmetic.Multiply(x, NumericUtilities.DegreesPerRadian), Conversion.CastClamp);
            cbyte IMath<cbyte>.Round(cbyte x) => x;
            cbyte IMath<cbyte>.Round(cbyte x, int digits) => x;
            cbyte IMath<cbyte>.Round(cbyte x, int digits, MidpointRounding mode) => x;
            cbyte IMath<cbyte>.Round(cbyte x, MidpointRounding mode) => x;
            cbyte IMath<cbyte>.Sin(cbyte x) => NumericConvert.ToByte(Math.Sin(x._value), Conversion.CastClamp);
            cbyte IMath<cbyte>.Sinh(cbyte x) => NumericConvert.ToByte(Math.Sinh(x._value), Conversion.CastClamp);
            cbyte IMath<cbyte>.Sqrt(cbyte x) => NumericConvert.ToByte(Math.Sqrt(x._value), Conversion.CastClamp);
            cbyte IMath<cbyte>.Tan(cbyte x) => NumericConvert.ToByte(Math.Tan(x._value), Conversion.CastClamp);
            cbyte IMath<cbyte>.Tanh(cbyte x) => NumericConvert.ToByte(Math.Tanh(x._value), Conversion.CastClamp);
            cbyte IMath<cbyte>.Tau { get; } = 6;
            cbyte IMath<cbyte>.Truncate(cbyte x) => x;
            int IMath<cbyte>.Sign(cbyte x) => x._value == 0 ? 0 : 1;

            cbyte IBitConverter<cbyte>.Read(IReadOnlyStream<byte> stream) => stream.Read(1)[0];
            void IBitConverter<cbyte>.Write(cbyte value, IWriteOnlyStream<byte> stream) => stream.Write(new[] { value._value });

            cbyte IRandom<cbyte>.Next(Random random) => random.NextByte();
            cbyte IRandom<cbyte>.Next(Random random, cbyte bound1, cbyte bound2) => random.NextByte(bound1._value, bound2._value);

            bool IConvert<cbyte>.ToBoolean(cbyte value) => value._value != 0;
            byte IConvert<cbyte>.ToByte(cbyte value, Conversion mode) => value._value;
            decimal IConvert<cbyte>.ToDecimal(cbyte value, Conversion mode) => NumericConvert.ToDecimal(value._value, mode.Clamped());
            double IConvert<cbyte>.ToDouble(cbyte value, Conversion mode) => NumericConvert.ToDouble(value._value, mode.Clamped());
            float IConvert<cbyte>.ToSingle(cbyte value, Conversion mode) => NumericConvert.ToSingle(value._value, mode.Clamped());
            int IConvert<cbyte>.ToInt32(cbyte value, Conversion mode) => NumericConvert.ToInt32(value._value, mode.Clamped());
            long IConvert<cbyte>.ToInt64(cbyte value, Conversion mode) => NumericConvert.ToInt64(value._value, mode.Clamped());
            sbyte IConvertUnsigned<cbyte>.ToSByte(cbyte value, Conversion mode) => NumericConvert.ToSByte(value._value, mode.Clamped());
            short IConvert<cbyte>.ToInt16(cbyte value, Conversion mode) => NumericConvert.ToInt16(value._value, mode.Clamped());
            string IConvert<cbyte>.ToString(cbyte value) => Convert.ToString(value._value);
            uint IConvertUnsigned<cbyte>.ToUInt32(cbyte value, Conversion mode) => NumericConvert.ToUInt16(value._value, mode.Clamped());
            ulong IConvertUnsigned<cbyte>.ToUInt64(cbyte value, Conversion mode) => NumericConvert.ToUInt64(value._value, mode.Clamped());
            ushort IConvertUnsigned<cbyte>.ToUInt16(cbyte value, Conversion mode) => NumericConvert.ToByte(value._value, mode.Clamped());

            cbyte IConvert<cbyte>.ToValue(bool value) => value ? (byte)1 : (byte)0;
            cbyte IConvert<cbyte>.ToValue(byte value, Conversion mode) => NumericConvert.ToByte(value, mode.Clamped());
            cbyte IConvert<cbyte>.ToValue(decimal value, Conversion mode) => NumericConvert.ToByte(value, mode.Clamped());
            cbyte IConvert<cbyte>.ToValue(double value, Conversion mode) => NumericConvert.ToByte(value, mode.Clamped());
            cbyte IConvert<cbyte>.ToValue(float value, Conversion mode) => NumericConvert.ToByte(value, mode.Clamped());
            cbyte IConvert<cbyte>.ToValue(int value, Conversion mode) => NumericConvert.ToByte(value, mode.Clamped());
            cbyte IConvert<cbyte>.ToValue(long value, Conversion mode) => NumericConvert.ToByte(value, mode.Clamped());
            cbyte IConvertUnsigned<cbyte>.ToValue(sbyte value, Conversion mode) => NumericConvert.ToByte(value, mode.Clamped());
            cbyte IConvert<cbyte>.ToValue(short value, Conversion mode) => NumericConvert.ToByte(value, mode.Clamped());
            cbyte IConvert<cbyte>.ToValue(string value) => Convert.ToByte(value);
            cbyte IConvertUnsigned<cbyte>.ToNumeric(uint value, Conversion mode) => NumericConvert.ToByte(value, mode.Clamped());
            cbyte IConvertUnsigned<cbyte>.ToNumeric(ulong value, Conversion mode) => NumericConvert.ToByte(value, mode.Clamped());
            cbyte IConvertUnsigned<cbyte>.ToNumeric(ushort value, Conversion mode) => value;

            cbyte IParser<cbyte>.Parse(string s) => Parse(s);
            cbyte IParser<cbyte>.Parse(string s, NumberStyles style, IFormatProvider? provider) => Parse(s, style, provider);
        }
    }
}
