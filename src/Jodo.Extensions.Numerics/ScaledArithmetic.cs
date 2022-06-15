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
using System.Numerics;

namespace Jodo.Extensions.Numerics
{
    public static class ScaledArithmetic
    {
        public static long Multiply(long scaledLeft, long scaledRight, long scalingFactor)
        {
            return (long)(new BigInteger(scaledLeft) * new BigInteger(scaledRight) / new BigInteger(scalingFactor));
        }

        public static ulong Multiply(ulong scaledLeft, ulong scaledRight, ulong scalingFactor)
        {
            return (ulong)(new BigInteger(scaledLeft) * new BigInteger(scaledRight) / new BigInteger(scalingFactor));
        }

        public static long Divide(long scaledLeft, long scaledRight, long scalingFactor)
        {
            return (long)(new BigInteger(scaledLeft) * new BigInteger(scalingFactor) / new BigInteger(scaledRight));
        }

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

        public static ulong Floor(ulong scaledValue, ulong scalingFactor)
        {
            if (scaledValue % scalingFactor == 0) return scaledValue;
            return scaledValue / scalingFactor * scalingFactor;
        }

        public static string ToString(long scaledValue, long scalingFactor)
        {
            var integral = Math.Abs(scaledValue / scalingFactor);
            var mantissa = Math.Abs(scaledValue % scalingFactor) + scalingFactor;
            var sign = scaledValue < 0 ? "-" : string.Empty;
            if (mantissa != scalingFactor)
            {
                return $"{sign}{integral}.{mantissa.ToString()[1..]}";
            }
            return $"{sign}{integral}";
        }

        public static string ToString(ulong scaledValue, ulong scalingFactor)
        {
            var integral = scaledValue / scalingFactor;
            var mantissa = (scaledValue % scalingFactor) + scalingFactor;
            if (mantissa != scalingFactor)
            {
                return $"{integral}.{mantissa.ToString()[1..]}";
            }
            return integral.ToString();
        }

        public static long Parse(string value, long scalingFactor)
        {
            var pointIndex = value.IndexOf(".");
            long integral = ParseIntegral(value, pointIndex, scalingFactor);

            long mantissa = (long)ParseMantissa(value, pointIndex, (ulong)scalingFactor);
            checked
            {
                var result = integral < 0 ? integral - mantissa : integral + mantissa;
                if (value.StartsWith("-") && integral == 0)
                {
                    result = -result;
                }
                return result;
            }
        }

        public static ulong Parse(string value, ulong scalingFactor)
        {
            var pointIndex = value.IndexOf(".");
            var integral = ParseIntegral(value, pointIndex, scalingFactor);
            var mantissa = ParseMantissa(value, pointIndex, scalingFactor);
            return checked(integral + mantissa);
        }

        private static long ParseIntegral(string value, int index, long scalingFactor)
        {
            if (index == 0) return 0;
            if (index < 0) return checked(long.Parse(value) * scalingFactor);
            return checked(long.Parse(value[..index]) * scalingFactor);
        }

        private static ulong ParseIntegral(string value, int index, ulong scalingFactor)
        {
            if (index == 0) return 0;
            if (index < 0) return checked(ulong.Parse(value) * scalingFactor);
            return checked(ulong.Parse(value[..index]) * scalingFactor);
        }

        private static ulong ParseMantissa(string value, int index, ulong scalingFactor)
        {
            if (index < 0) return 0;

            ulong mantissa;
            var target = (int)Math.Ceiling(Math.Log10(scalingFactor)) + 1;
            mantissa = ulong.Parse("1" + value[(index + 1)..]);
            if (mantissa == scalingFactor)
            {
                return 0;
            }
            bool keepGoing = true;
            do
            {
                var digits = (int)Math.Ceiling(Math.Log10(mantissa));
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
            var remainder = value % 10;
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
            var remainder = value % 10;
            if (remainder == 0) return value;
            if (remainder < 5) return value - remainder;
            else if (remainder > 5) return value + (10 - remainder);
            else if (value / 10 % 2 == 0) return value - 5;
            else return value + 5;
        }

        private static long RoundAwayFromZero(long value)
        {
            var remainder = value % 10;
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
            var remainder = value % 10;
            if (remainder == 0) return value;
            if (remainder < 5) return value - remainder;
            else if (remainder > 5) return value + (10 - remainder);
            return value + 5;
        }

        private static long RoundToZero(long value)
        {
            var remainder = value % 10;
            if (remainder == 0) return value;
            return value - remainder;
        }

        private static ulong RoundToZero(ulong value)
        {
            var remainder = value % 10;
            if (remainder == 0) return value;
            return value - remainder;
        }

        private static long RoundToPositiveInfinity(long value)
        {
            var remainder = value % 10;
            if (remainder == 0) return value;
            if (value > 0) return value + (10 - remainder);
            return value - remainder;
        }

        private static ulong RoundToPositiveInfinity(ulong value)
        {
            var remainder = value % 10;
            if (remainder == 0) return value;
            return value + (10 - remainder);
        }

        private static long RoundToNegativeInfinity(long value)
        {
            var remainder = value % 10;
            if (remainder == 0) return value;
            if (value > 0) return value - remainder;
            return value - (10 + remainder);
        }
    }
}
