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
using System.Globalization;
using System.Runtime.Serialization;
using Jodo.Primitives;
using Jodo.Primitives.Compatibility;

namespace Jodo.Numerics
{
    /// <summary>
    /// Represents a decimal floating-point number.
    /// </summary>
    [Serializable]
    [DebuggerDisplay("{ToString(),nq}")]
    public readonly struct DecimalN : INumericExtended<DecimalN>
    {
        public static readonly DecimalN MaxValue = new DecimalN(decimal.MaxValue);
        public static readonly DecimalN MinValue = new DecimalN(decimal.MinValue);

        private readonly decimal _value;

        private DecimalN(decimal value)
        {
            _value = value;
        }

        private DecimalN(SerializationInfo info, StreamingContext context) : this(info.GetDecimal(nameof(DecimalN))) { }
        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context) => info.AddValue(nameof(DecimalN), _value);

        public int CompareTo(DecimalN other) => _value.CompareTo(other._value);
        public int CompareTo(object? obj) => obj is DecimalN other ? CompareTo(other) : 1;
        public bool Equals(DecimalN other) => _value == other._value;
        public override bool Equals(object? obj) => obj is DecimalN other && Equals(other);
        public override int GetHashCode() => _value.GetHashCode();
        public override string ToString() => _value.ToString();
        public string ToString(IFormatProvider formatProvider) => _value.ToString(formatProvider);
        public string ToString(string format) => _value.ToString(format);
        public string ToString(string? format, IFormatProvider? formatProvider) => _value.ToString(format, formatProvider);

        public static bool TryParse(string s, IFormatProvider? provider, out DecimalN result) => TryHelper.Run(() => Parse(s, provider), out result);
        public static bool TryParse(string s, NumberStyles style, IFormatProvider? provider, out DecimalN result) => TryHelper.Run(() => Parse(s, style, provider), out result);
        public static bool TryParse(string s, NumberStyles style, out DecimalN result) => TryHelper.Run(() => Parse(s, style), out result);
        public static bool TryParse(string s, out DecimalN result) => TryHelper.Run(() => Parse(s), out result);
        public static DecimalN Parse(string s) => decimal.Parse(s);
        public static DecimalN Parse(string s, IFormatProvider? provider) => decimal.Parse(s, provider);
        public static DecimalN Parse(string s, NumberStyles style) => decimal.Parse(s, style);
        public static DecimalN Parse(string s, NumberStyles style, IFormatProvider? provider) => decimal.Parse(s, style, provider);

        [CLSCompliant(false)] public static implicit operator DecimalN(sbyte value) => new DecimalN(value);
        [CLSCompliant(false)] public static implicit operator DecimalN(uint value) => new DecimalN(value);
        [CLSCompliant(false)] public static implicit operator DecimalN(ulong value) => new DecimalN(value);
        [CLSCompliant(false)] public static implicit operator DecimalN(ushort value) => new DecimalN(value);
        public static explicit operator DecimalN(double value) => new DecimalN((decimal)value);
        public static explicit operator DecimalN(float value) => new DecimalN((decimal)value);
        public static implicit operator DecimalN(byte value) => new DecimalN(value);
        public static implicit operator DecimalN(decimal value) => new DecimalN(value);
        public static implicit operator DecimalN(int value) => new DecimalN(value);
        public static implicit operator DecimalN(long value) => new DecimalN(value);
        public static implicit operator DecimalN(short value) => new DecimalN(value);

        [CLSCompliant(false)] public static explicit operator sbyte(DecimalN value) => (sbyte)value._value;
        [CLSCompliant(false)] public static explicit operator uint(DecimalN value) => (uint)value._value;
        [CLSCompliant(false)] public static explicit operator ulong(DecimalN value) => (ulong)value._value;
        [CLSCompliant(false)] public static explicit operator ushort(DecimalN value) => (ushort)value._value;
        public static explicit operator byte(DecimalN value) => (byte)value._value;
        public static explicit operator double(DecimalN value) => (double)value._value;
        public static explicit operator float(DecimalN value) => (float)value._value;
        public static explicit operator int(DecimalN value) => (int)value._value;
        public static explicit operator long(DecimalN value) => (long)value._value;
        public static explicit operator short(DecimalN value) => (short)value._value;
        public static implicit operator decimal(DecimalN value) => value._value;

        public static bool operator !=(DecimalN left, DecimalN right) => left._value != right._value;
        public static bool operator <(DecimalN left, DecimalN right) => left._value < right._value;
        public static bool operator <=(DecimalN left, DecimalN right) => left._value <= right._value;
        public static bool operator ==(DecimalN left, DecimalN right) => left._value == right._value;
        public static bool operator >(DecimalN left, DecimalN right) => left._value > right._value;
        public static bool operator >=(DecimalN left, DecimalN right) => left._value >= right._value;
        public static DecimalN operator %(DecimalN left, DecimalN right) => left._value % right._value;
        public static DecimalN operator &(DecimalN left, DecimalN right) => BitOperations.LogicalAnd(left._value, right._value);
        public static DecimalN operator -(DecimalN left, DecimalN right) => left._value - right._value;
        public static DecimalN operator --(DecimalN value) => value._value - 1;
        public static DecimalN operator -(DecimalN value) => -value._value;
        public static DecimalN operator *(DecimalN left, DecimalN right) => left._value * right._value;
        public static DecimalN operator /(DecimalN left, DecimalN right) => left._value / right._value;
        public static DecimalN operator ^(DecimalN left, DecimalN right) => BitOperations.LogicalExclusiveOr(left._value, right._value);
        public static DecimalN operator |(DecimalN left, DecimalN right) => BitOperations.LogicalOr(left._value, right._value);
        public static DecimalN operator ~(DecimalN left) => BitOperations.BitwiseComplement(left._value);
        public static DecimalN operator +(DecimalN left, DecimalN right) => left._value + right._value;
        public static DecimalN operator +(DecimalN value) => value;
        public static DecimalN operator ++(DecimalN value) => value._value + 1;
        public static DecimalN operator <<(DecimalN left, int right) => BitOperations.LeftShift(left._value, right);
        public static DecimalN operator >>(DecimalN left, int right) => BitOperations.RightShift(left._value, right);

        TypeCode IConvertible.GetTypeCode() => _value.GetTypeCode();
        bool IConvertible.ToBoolean(IFormatProvider provider) => ((IConvertible)_value).ToBoolean(provider);
        char IConvertible.ToChar(IFormatProvider provider) => ((IConvertible)_value).ToChar(provider);
        sbyte IConvertible.ToSByte(IFormatProvider provider) => ((IConvertible)_value).ToSByte(provider);
        byte IConvertible.ToByte(IFormatProvider provider) => ((IConvertible)_value).ToByte(provider);
        short IConvertible.ToInt16(IFormatProvider provider) => ((IConvertible)_value).ToInt16(provider);
        ushort IConvertible.ToUInt16(IFormatProvider provider) => ((IConvertible)_value).ToUInt16(provider);
        int IConvertible.ToInt32(IFormatProvider provider) => ((IConvertible)_value).ToInt32(provider);
        uint IConvertible.ToUInt32(IFormatProvider provider) => ((IConvertible)_value).ToUInt32(provider);
        long IConvertible.ToInt64(IFormatProvider provider) => ((IConvertible)_value).ToInt64(provider);
        ulong IConvertible.ToUInt64(IFormatProvider provider) => ((IConvertible)_value).ToUInt64(provider);
        float IConvertible.ToSingle(IFormatProvider provider) => ((IConvertible)_value).ToSingle(provider);
        double IConvertible.ToDouble(IFormatProvider provider) => ((IConvertible)_value).ToDouble(provider);
        decimal IConvertible.ToDecimal(IFormatProvider provider) => ((IConvertible)_value).ToDecimal(provider);
        DateTime IConvertible.ToDateTime(IFormatProvider provider) => ((IConvertible)_value).ToDateTime(provider);
        object IConvertible.ToType(Type conversionType, IFormatProvider provider) => ((IConvertible)_value).ToType(conversionType, provider);

        bool INumeric<DecimalN>.IsGreaterThan(DecimalN value) => this > value;
        bool INumeric<DecimalN>.IsGreaterThanOrEqualTo(DecimalN value) => this >= value;
        bool INumeric<DecimalN>.IsLessThan(DecimalN value) => this < value;
        bool INumeric<DecimalN>.IsLessThanOrEqualTo(DecimalN value) => this <= value;
        DecimalN INumeric<DecimalN>.Add(DecimalN value) => this + value;
        DecimalN INumeric<DecimalN>.BitwiseComplement() => ~this;
        DecimalN INumeric<DecimalN>.Divide(DecimalN value) => this / value;
        DecimalN INumeric<DecimalN>.LeftShift(int count) => this << count;
        DecimalN INumeric<DecimalN>.LogicalAnd(DecimalN value) => this & value;
        DecimalN INumeric<DecimalN>.LogicalExclusiveOr(DecimalN value) => this ^ value;
        DecimalN INumeric<DecimalN>.LogicalOr(DecimalN value) => this | value;
        DecimalN INumeric<DecimalN>.Multiply(DecimalN value) => this * value;
        DecimalN INumeric<DecimalN>.Negative() => -this;
        DecimalN INumeric<DecimalN>.Positive() => +this;
        DecimalN INumeric<DecimalN>.Remainder(DecimalN value) => this % value;
        DecimalN INumeric<DecimalN>.RightShift(int count) => this >> count;
        DecimalN INumeric<DecimalN>.Subtract(DecimalN value) => this - value;

        INumericBitConverter<DecimalN> IProvider<INumericBitConverter<DecimalN>>.GetInstance() => Utilities.Instance;
        IConvert<DecimalN> IProvider<IConvert<DecimalN>>.GetInstance() => Utilities.Instance;
        IConvertExtended<DecimalN> IProvider<IConvertExtended<DecimalN>>.GetInstance() => Utilities.Instance;
        IMath<DecimalN> IProvider<IMath<DecimalN>>.GetInstance() => Utilities.Instance;
        INumericRandom<DecimalN> IProvider<INumericRandom<DecimalN>>.GetInstance() => Utilities.Instance;
        INumericStatic<DecimalN> IProvider<INumericStatic<DecimalN>>.GetInstance() => Utilities.Instance;
        IVariantRandom<DecimalN> IProvider<IVariantRandom<DecimalN>>.GetInstance() => Utilities.Instance;

        private sealed class Utilities :
            INumericBitConverter<DecimalN>,
            IConvert<DecimalN>,
            IConvertExtended<DecimalN>,
            IMath<DecimalN>,
            INumericRandom<DecimalN>,
            INumericStatic<DecimalN>,
            IVariantRandom<DecimalN>
        {
            public static readonly Utilities Instance = new Utilities();

            bool INumericStatic<DecimalN>.HasFloatingPoint => true;
            bool INumericStatic<DecimalN>.HasInfinity => false;
            bool INumericStatic<DecimalN>.HasNaN => false;
            bool INumericStatic<DecimalN>.IsFinite(DecimalN x) => true;
            bool INumericStatic<DecimalN>.IsInfinity(DecimalN x) => false;
            bool INumericStatic<DecimalN>.IsNaN(DecimalN x) => false;
            bool INumericStatic<DecimalN>.IsNegative(DecimalN x) => x._value < 0;
            bool INumericStatic<DecimalN>.IsNegativeInfinity(DecimalN x) => false;
            bool INumericStatic<DecimalN>.IsNormal(DecimalN x) => false;
            bool INumericStatic<DecimalN>.IsPositiveInfinity(DecimalN x) => false;
            bool INumericStatic<DecimalN>.IsReal => true;
            bool INumericStatic<DecimalN>.IsSigned => true;
            bool INumericStatic<DecimalN>.IsSubnormal(DecimalN x) => false;
            DecimalN INumericStatic<DecimalN>.Epsilon { get; } = new decimal(1, 0, 0, false, 28);
            DecimalN INumericStatic<DecimalN>.MaxUnit => 1m;
            DecimalN INumericStatic<DecimalN>.MaxValue => MaxValue;
            DecimalN INumericStatic<DecimalN>.MinUnit => -1m;
            DecimalN INumericStatic<DecimalN>.MinValue => MinValue;
            DecimalN INumericStatic<DecimalN>.One => 1m;
            DecimalN INumericStatic<DecimalN>.Ten => 10m;
            DecimalN INumericStatic<DecimalN>.Two => 2m;
            DecimalN INumericStatic<DecimalN>.Zero => 0m;

            int IMath<DecimalN>.Sign(DecimalN x) => Math.Sign(x);
            DecimalN IMath<DecimalN>.Abs(DecimalN value) => Math.Abs(value);
            DecimalN IMath<DecimalN>.Acos(DecimalN x) => (DecimalN)Math.Acos((double)x);
            DecimalN IMath<DecimalN>.Acosh(DecimalN x) => (DecimalN)MathCompat.Acosh((double)x);
            DecimalN IMath<DecimalN>.Asin(DecimalN x) => (DecimalN)Math.Asin((double)x);
            DecimalN IMath<DecimalN>.Asinh(DecimalN x) => (DecimalN)MathCompat.Asinh((double)x);
            DecimalN IMath<DecimalN>.Atan(DecimalN x) => (DecimalN)Math.Atan((double)x);
            DecimalN IMath<DecimalN>.Atan2(DecimalN x, DecimalN y) => (DecimalN)Math.Atan2((double)x, (double)y);
            DecimalN IMath<DecimalN>.Atanh(DecimalN x) => (DecimalN)MathCompat.Atanh((double)x);
            DecimalN IMath<DecimalN>.Cbrt(DecimalN x) => (DecimalN)MathCompat.Cbrt((double)x);
            DecimalN IMath<DecimalN>.Ceiling(DecimalN x) => decimal.Ceiling(x);
            DecimalN IMath<DecimalN>.Clamp(DecimalN x, DecimalN bound1, DecimalN bound2) => bound1 > bound2 ? Math.Min(bound1, Math.Max(bound2, x)) : Math.Min(bound2, Math.Max(bound1, x));
            DecimalN IMath<DecimalN>.Cos(DecimalN x) => (DecimalN)Math.Cos((double)x);
            DecimalN IMath<DecimalN>.Cosh(DecimalN x) => (DecimalN)Math.Cosh((double)x);
            DecimalN IMath<DecimalN>.DegreesToRadians(DecimalN degrees) => degrees * BitOperations.RadiansPerDegreeM;
            DecimalN IMath<DecimalN>.E { get; } = (DecimalN)Math.E;
            DecimalN IMath<DecimalN>.Exp(DecimalN x) => (DecimalN)Math.Exp((double)x);
            DecimalN IMath<DecimalN>.Floor(DecimalN x) => decimal.Floor(x);
            DecimalN IMath<DecimalN>.IEEERemainder(DecimalN x, DecimalN y) => (DecimalN)Math.IEEERemainder((double)x, (double)y);
            DecimalN IMath<DecimalN>.Log(DecimalN x) => (DecimalN)Math.Log((double)x);
            DecimalN IMath<DecimalN>.Log(DecimalN x, DecimalN y) => (DecimalN)Math.Log((double)x, (double)y);
            DecimalN IMath<DecimalN>.Log10(DecimalN x) => (DecimalN)Math.Log10((double)x);
            DecimalN IMath<DecimalN>.Max(DecimalN x, DecimalN y) => Math.Max(x, y);
            DecimalN IMath<DecimalN>.Min(DecimalN x, DecimalN y) => Math.Min(x, y);
            DecimalN IMath<DecimalN>.PI { get; } = (DecimalN)Math.PI;
            DecimalN IMath<DecimalN>.Pow(DecimalN x, DecimalN y) => y == 1 ? x : (DecimalN)Math.Pow((double)x, (double)y);
            DecimalN IMath<DecimalN>.RadiansToDegrees(DecimalN radians) => radians * BitOperations.DegreesPerRadianM;
            DecimalN IMath<DecimalN>.Round(DecimalN x) => decimal.Round(x);
            DecimalN IMath<DecimalN>.Round(DecimalN x, int digits) => decimal.Round(x, digits);
            DecimalN IMath<DecimalN>.Round(DecimalN x, int digits, MidpointRounding mode) => decimal.Round(x, digits, mode);
            DecimalN IMath<DecimalN>.Round(DecimalN x, MidpointRounding mode) => decimal.Round(x, mode);
            DecimalN IMath<DecimalN>.Sin(DecimalN x) => (DecimalN)Math.Sin((double)x);
            DecimalN IMath<DecimalN>.Sinh(DecimalN x) => (DecimalN)Math.Sinh((double)x);
            DecimalN IMath<DecimalN>.Sqrt(DecimalN x) => (DecimalN)Math.Sqrt((double)x);
            DecimalN IMath<DecimalN>.Tan(DecimalN x) => (DecimalN)Math.Tan((double)x);
            DecimalN IMath<DecimalN>.Tanh(DecimalN x) => (DecimalN)Math.Tanh((double)x);
            DecimalN IMath<DecimalN>.Tau { get; } = (DecimalN)Math.PI * 2m;
            DecimalN IMath<DecimalN>.Truncate(DecimalN x) => decimal.Truncate(x);

            DecimalN INumericBitConverter<DecimalN>.Read(IReader<byte> stream)
            {
                int part0 = BitConverter.ToInt32(stream.Read(sizeof(int)), 0);
                int part1 = BitConverter.ToInt32(stream.Read(sizeof(int)), 0);
                int part2 = BitConverter.ToInt32(stream.Read(sizeof(int)), 0);
                int part3 = BitConverter.ToInt32(stream.Read(sizeof(int)), 0);

                bool sign = (part3 & 0x80000000) != 0;
                byte scale = (byte)((part3 >> 16) & 0x7F);

                return new decimal(part0, part1, part2, sign, scale);
            }

            void INumericBitConverter<DecimalN>.Write(DecimalN value, IWriter<byte> stream)
            {
                int[]? parts = decimal.GetBits(value);
                stream.Write(BitConverter.GetBytes(parts[0]));
                stream.Write(BitConverter.GetBytes(parts[1]));
                stream.Write(BitConverter.GetBytes(parts[2]));
                stream.Write(BitConverter.GetBytes(parts[3]));
            }

            bool IConvert<DecimalN>.ToBoolean(DecimalN value) => Convert.ToBoolean(value._value);
            byte IConvert<DecimalN>.ToByte(DecimalN value, Conversion mode) => ConvertN.ToByte(value._value, mode);
            decimal IConvert<DecimalN>.ToDecimal(DecimalN value, Conversion mode) => value;
            double IConvert<DecimalN>.ToDouble(DecimalN value, Conversion mode) => ConvertN.ToDouble(value._value, mode);
            float IConvert<DecimalN>.ToSingle(DecimalN value, Conversion mode) => ConvertN.ToSingle(value._value, mode);
            int IConvert<DecimalN>.ToInt32(DecimalN value, Conversion mode) => ConvertN.ToInt32(value._value, mode);
            long IConvert<DecimalN>.ToInt64(DecimalN value, Conversion mode) => ConvertN.ToInt64(value._value, mode);
            sbyte IConvertExtended<DecimalN>.ToSByte(DecimalN value, Conversion mode) => ConvertN.ToSByte(value._value, mode);
            short IConvert<DecimalN>.ToInt16(DecimalN value, Conversion mode) => ConvertN.ToInt16(value._value, mode);
            string IConvert<DecimalN>.ToString(DecimalN value) => Convert.ToString(value._value);
            uint IConvertExtended<DecimalN>.ToUInt32(DecimalN value, Conversion mode) => ConvertN.ToUInt32(value._value, mode);
            ulong IConvertExtended<DecimalN>.ToUInt64(DecimalN value, Conversion mode) => ConvertN.ToUInt64(value._value, mode);
            ushort IConvertExtended<DecimalN>.ToUInt16(DecimalN value, Conversion mode) => ConvertN.ToUInt16(value._value, mode);

            DecimalN IConvert<DecimalN>.ToNumeric(bool value) => Convert.ToDecimal(value);
            DecimalN IConvert<DecimalN>.ToNumeric(byte value, Conversion mode) => ConvertN.ToDecimal(value, mode);
            DecimalN IConvert<DecimalN>.ToNumeric(decimal value, Conversion mode) => value;
            DecimalN IConvert<DecimalN>.ToNumeric(double value, Conversion mode) => ConvertN.ToDecimal(value, mode);
            DecimalN IConvert<DecimalN>.ToNumeric(float value, Conversion mode) => ConvertN.ToDecimal(value, mode);
            DecimalN IConvert<DecimalN>.ToNumeric(int value, Conversion mode) => ConvertN.ToDecimal(value, mode);
            DecimalN IConvert<DecimalN>.ToNumeric(long value, Conversion mode) => ConvertN.ToDecimal(value, mode);
            DecimalN IConvertExtended<DecimalN>.ToValue(sbyte value, Conversion mode) => ConvertN.ToDecimal(value, mode);
            DecimalN IConvert<DecimalN>.ToNumeric(short value, Conversion mode) => ConvertN.ToDecimal(value, mode);
            DecimalN IConvert<DecimalN>.ToNumeric(string value) => Convert.ToDecimal(value);
            DecimalN IConvertExtended<DecimalN>.ToNumeric(uint value, Conversion mode) => ConvertN.ToDecimal(value, mode);
            DecimalN IConvertExtended<DecimalN>.ToNumeric(ulong value, Conversion mode) => ConvertN.ToDecimal(value, mode);
            DecimalN IConvertExtended<DecimalN>.ToNumeric(ushort value, Conversion mode) => ConvertN.ToDecimal(value, mode);

            DecimalN INumericStatic<DecimalN>.Parse(string s, NumberStyles? style, IFormatProvider? provider)
                => Parse(s, style ?? NumberStyles.Number, provider);

            DecimalN INumericRandom<DecimalN>.Next(Random random) => random.NextDecimal();
            DecimalN INumericRandom<DecimalN>.Next(Random random, DecimalN maxValue) => random.NextDecimal(maxValue);
            DecimalN INumericRandom<DecimalN>.Next(Random random, DecimalN minValue, DecimalN maxValue) => random.NextDecimal(minValue, maxValue);
            DecimalN INumericRandom<DecimalN>.Next(Random random, Generation mode) => random.NextDecimal(mode);
            DecimalN INumericRandom<DecimalN>.Next(Random random, DecimalN minValue, DecimalN maxValue, Generation mode) => random.NextDecimal(minValue, maxValue, mode);

            DecimalN IVariantRandom<DecimalN>.Next(Random random, Scenarios scenarios) => NumericVariant.Generate<DecimalN>(random, scenarios);
        }
    }
}
