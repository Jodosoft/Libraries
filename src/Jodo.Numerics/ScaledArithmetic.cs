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
using System.Globalization;
using System.Numerics;

namespace Jodo.Numerics
{
    public static class ScaledArithmetic
    {
        private static readonly BigInteger MaxInt64 = new BigInteger(long.MaxValue);
        private static readonly BigInteger MinInt64 = new BigInteger(long.MinValue);
        private static readonly BigInteger MaxUInt64 = new BigInteger(ulong.MaxValue);

        public static long Multiply(long scaledLeft, long scaledRight, long scalingFactor)
        {
            BigInteger result = new BigInteger(scaledLeft) * new BigInteger(scaledRight) / new BigInteger(scalingFactor);
            if (result > MaxInt64 || result < MinInt64)
            {
                return BitConverter.ToInt64(result.ToByteArray(), 0);
            }
            return (long)result;
        }

        [CLSCompliant(false)]
        public static ulong Multiply(ulong scaledLeft, ulong scaledRight, ulong scalingFactor)
        {
            BigInteger result = new BigInteger(scaledLeft) * new BigInteger(scaledRight) / new BigInteger(scalingFactor);
            if (result > MaxUInt64)
            {
                return BitConverter.ToUInt64(result.ToByteArray(), 0);
            }
            return (ulong)result;
        }

        public static long Divide(long scaledLeft, long scaledRight, long scalingFactor)
        {
            return (long)(new BigInteger(scaledLeft) * new BigInteger(scalingFactor) / new BigInteger(scaledRight));
        }

        [CLSCompliant(false)]
        public static ulong Divide(ulong scaledLeft, ulong scaledRight, ulong scalingFactor)
        {
            return (ulong)(new BigInteger(scaledLeft) * new BigInteger(scalingFactor) / new BigInteger(scaledRight));
        }

        public static long Ceiling(long scaledValue, long scalingFactor)
        {
            if (scaledValue % scalingFactor == 0) return scaledValue;
            if (scaledValue < 0) return scaledValue / scalingFactor * scalingFactor;
            return (scaledValue / scalingFactor * scalingFactor) + scalingFactor;
        }

        [CLSCompliant(false)]
        public static ulong Ceiling(ulong scaledValue, ulong scalingFactor)
        {
            if (scaledValue % scalingFactor == 0) return scaledValue;
            return (scaledValue / scalingFactor * scalingFactor) + scalingFactor;
        }

        public static long Floor(long scaledValue, long scalingFactor)
        {
            if (scaledValue % scalingFactor == 0) return scaledValue;
            if (scaledValue < 0) return (scaledValue / scalingFactor * scalingFactor) - scalingFactor;
            return scaledValue / scalingFactor * scalingFactor;
        }

        [CLSCompliant(false)]
        public static ulong Floor(ulong scaledValue, ulong scalingFactor)
        {
            if (scaledValue % scalingFactor == 0) return scaledValue;
            return scaledValue / scalingFactor * scalingFactor;
        }

        public static string ToString(long scaledValue, long scalingFactor, IFormatProvider? formatProvider)
        {
            NumberFormatInfo numberFormatInfo = NumberFormatInfo.GetInstance(formatProvider);

            long integral = Math.Abs(scaledValue / scalingFactor);
            long mantissa = Math.Abs(scaledValue % scalingFactor) + scalingFactor;
            string? sign = scaledValue < 0 ? numberFormatInfo.NegativeSign : string.Empty;
            if (mantissa != scalingFactor)
            {
                string mantissaString = mantissa.ToString();
                return $"{sign}{integral.ToString(formatProvider)}{numberFormatInfo.NumberDecimalSeparator}{mantissaString.Substring(1, mantissaString.Length - 1)}";
            }
            return $"{sign}{integral.ToString(formatProvider)}";
        }

        [CLSCompliant(false)]
        public static string ToString(ulong scaledValue, ulong scalingFactor, IFormatProvider? formatProvider)
        {
            NumberFormatInfo numberFormatInfo = NumberFormatInfo.GetInstance(formatProvider);

            ulong integral = scaledValue / scalingFactor;
            ulong mantissa = (scaledValue % scalingFactor) + scalingFactor;
            if (mantissa != scalingFactor)
            {
                string mantissaString = mantissa.ToString();
                return $"{integral}{numberFormatInfo.NumberDecimalSeparator}{mantissaString.Substring(1, mantissaString.Length - 1)}";
            }
            return integral.ToString(formatProvider);
        }

        public static long Parse(string value, long scalingFactor, NumberStyles? style, IFormatProvider? formatProvider)
        {
            NumberStyles numberStyles = style ?? NumberStyles.Integer;
            NumberFormatInfo numberFormatInfo = NumberFormatInfo.GetInstance(formatProvider);

            int pointIndex = value.IndexOf(numberFormatInfo.NumberDecimalSeparator, StringComparison.Ordinal);
            long integral = ParseIntegral(value, pointIndex, scalingFactor, numberStyles, formatProvider);

            long mantissa = (long)ParseMantissa(value, pointIndex, (ulong)scalingFactor);
            checked
            {
                long result = integral < 0 ? integral - mantissa : integral + mantissa;
                if (value.StartsWith(numberFormatInfo.NegativeSign, StringComparison.Ordinal) && integral == 0)
                {
                    result = -result;
                }
                return result;
            }
        }

        [CLSCompliant(false)]
        public static ulong Parse(string value, ulong scalingFactor, NumberStyles? style, IFormatProvider? formatProvider)
        {
            NumberStyles numberStyles = style ?? NumberStyles.Number;
            NumberFormatInfo numberFormatInfo = NumberFormatInfo.GetInstance(formatProvider);

            int pointIndex = value.IndexOf(numberFormatInfo.NumberDecimalSeparator, StringComparison.Ordinal);
            ulong integral = ParseIntegral(value, pointIndex, scalingFactor, numberStyles, formatProvider);
            ulong mantissa = ParseMantissa(value, pointIndex, scalingFactor);
            return checked(integral + mantissa);
        }

        private static long ParseIntegral(string value, int index, long scalingFactor)
        {
            if (index == 0) return 0;
            if (index < 0) return checked(long.Parse(value) * scalingFactor);
            return checked(long.Parse(value.Substring(0, index)) * scalingFactor);
        }

        private static long ParseIntegral(string value, int index, long scalingFactor, NumberStyles style, IFormatProvider? provider)
        {
            if (index == 0) return 0;
            if (index < 0) return checked(long.Parse(value, style, provider) * scalingFactor);
            return checked(long.Parse(value.Substring(0, index), style, provider) * scalingFactor);
        }

        private static ulong ParseIntegral(string value, int index, ulong scalingFactor, NumberStyles style, IFormatProvider? provider)
        {
            if (index == 0) return 0;
            if (index < 0) return checked(ulong.Parse(value, style, provider) * scalingFactor);
            return checked(ulong.Parse(value.Substring(0, index), style, provider) * scalingFactor);
        }

        private static ulong ParseMantissa(string value, int index, ulong scalingFactor)
        {
            if (index < 0) return 0;

            ulong mantissa;
            int target = (int)Math.Ceiling(Math.Log10(scalingFactor)) + 1;
            mantissa = ulong.Parse("1" + value.Substring(index + 1));
            if (mantissa == scalingFactor)
            {
                return 0;
            }
            bool keepGoing = true;
            do
            {
                int digits = (int)Math.Ceiling(Math.Log10(mantissa));
                if (digits < target)
                {
                    mantissa *= 10;
                }
                else if (digits > target)
                {
                    mantissa = RoundAwayFromZero(mantissa) / 10;
                }
                else
                {
                    keepGoing = false;
                }
            } while (keepGoing);
            return mantissa - scalingFactor;
        }

        public static long Round(long value, int times, MidpointRounding mode)
        {
            if (times > 0)
            {
                for (int i = 1; i < times; i++) value /= 10;
                value = Round(value, mode) / 10;
                for (int i = 0; i < times; i++) value *= 10;
            }
            return value;
        }

        [CLSCompliant(false)]
        public static ulong Round(ulong value, int times, MidpointRounding mode)
        {
            for (int i = 1; i < times; i++) value /= 10;
            value = Round(value, mode) / 10;
            for (int i = 0; i < times; i++) value *= 10;
            return value;
        }

        public static long Round(long value, MidpointRounding mode) => mode switch
        {
            MidpointRounding.ToEven => RoundToEven(value),
            MidpointRounding.AwayFromZero => RoundAwayFromZero(value),
            (MidpointRounding)2 => RoundToZero(value),
            (MidpointRounding)3 => RoundToNegativeInfinity(value),
            (MidpointRounding)4 => RoundToPositiveInfinity(value),
            _ => throw new ArgumentOutOfRangeException(nameof(mode), mode, $"Unknown value of {nameof(MidpointRounding)}"),
        };

        [CLSCompliant(false)]
        public static ulong Round(ulong value, MidpointRounding mode) => mode switch
        {
            MidpointRounding.ToEven => RoundToEven(value),
            MidpointRounding.AwayFromZero => RoundAwayFromZero(value),
            (MidpointRounding)2 => RoundToZero(value),
            (MidpointRounding)3 => RoundToZero(value),
            (MidpointRounding)4 => RoundToPositiveInfinity(value),
            _ => throw new ArgumentOutOfRangeException(nameof(mode), mode, $"Unknown value of {nameof(MidpointRounding)}"),
        };

        private static long RoundToEven(long value)
        {
            long remainder = value % 10;
            if (remainder == 0) return value;
            if (value > 0)
            {
                if (remainder < 5) return value - remainder;
                else if (remainder > 5) return value + (10 - remainder);
                else if (value / 10 % 2 == 0) return value - 5;
                else return value + 5;
            }
            else
            {
                if (remainder < -5) return value - (10 + remainder);
                else if (remainder > -5) return value - remainder;
                else if (value / 10 % 2 == 0) return value + 5;
                else return value - 5;
            }
        }

        private static ulong RoundToEven(ulong value)
        {
            ulong remainder = value % 10;
            if (remainder == 0) return value;
            if (remainder < 5) return value - remainder;
            else if (remainder > 5) return value + (10 - remainder);
            else if (value / 10 % 2 == 0) return value - 5;
            else return value + 5;
        }

        private static long RoundAwayFromZero(long value)
        {
            long remainder = value % 10;
            if (remainder == 0) return value;
            if (value > 0)
            {
                if (remainder < 5) return value - remainder;
                else if (remainder > 5) return value + (10 - remainder);
                else return value + 5;
            }
            else
            {
                if (remainder < -5) return value - (10 + remainder);
                else if (remainder > -5) return value - remainder;
                else return value - 5;
            }
        }

        private static ulong RoundAwayFromZero(ulong value)
        {
            ulong remainder = value % 10;
            if (remainder == 0) return value;
            if (remainder < 5) return value - remainder;
            else if (remainder > 5) return value + (10 - remainder);
            return value + 5;
        }

        private static long RoundToZero(long value)
        {
            long remainder = value % 10;
            if (remainder == 0) return value;
            return value - remainder;
        }

        private static ulong RoundToZero(ulong value)
        {
            ulong remainder = value % 10;
            if (remainder == 0) return value;
            return value - remainder;
        }

        private static long RoundToPositiveInfinity(long value)
        {
            long remainder = value % 10;
            if (remainder == 0) return value;
            if (value > 0) return value + (10 - remainder);
            return value - remainder;
        }

        private static ulong RoundToPositiveInfinity(ulong value)
        {
            ulong remainder = value % 10;
            if (remainder == 0) return value;
            return value + (10 - remainder);
        }

        private static long RoundToNegativeInfinity(long value)
        {
            long remainder = value % 10;
            if (remainder == 0) return value;
            if (value > 0) return value - remainder;
            return value - (10 + remainder);
        }
    }
}
