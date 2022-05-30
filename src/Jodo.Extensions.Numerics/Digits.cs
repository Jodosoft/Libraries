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
using System.Diagnostics.CodeAnalysis;
using System.Numerics;

namespace Jodo.Extensions.Numerics
{
    [SuppressMessage("csharpsquid", "S3776")] // false positives
    public static class Digits
    {
        public static long Round(long value, int times, MidpointRounding mode)
        {
            for (int i = 1; i < times; i++) value /= 10;
            value = Round(value, mode) / 10;
            for (int i = 0; i < times; i++) value *= 10;
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
            (MidpointRounding)3 => RoundToNegativeInfinity(value),
            (MidpointRounding)4 => RoundToPositiveInfinity(value),
            _ => throw new ArgumentOutOfRangeException(nameof(mode), mode, $"Unknown value of {nameof(MidpointRounding)}"),
        };

        public static byte Truncate(byte value, int digits)
        {
            if (digits <= 0) throw new ArgumentOutOfRangeException(nameof(digits), digits, "Must be positive.");
            if (value == 0) return 0;
            var currentDigits = Digits.Count(value);
            if (currentDigits <= digits) return value;
            var factor = (int)Math.Pow(10, currentDigits - digits);
            return (byte)(value / factor * factor);
        }

        public static int Truncate(int value, int digits)
        {
            if (digits <= 0) throw new ArgumentOutOfRangeException(nameof(digits), digits, "Must be positive.");
            if (value == 0) return 0;
            var currentDigits = Digits.Count(value);
            if (currentDigits <= digits) return value;
            var factor = (int)Math.Pow(10, currentDigits - digits);
            return value / factor * factor;
        }

        public static short Truncate(short value, int digits)
        {
            if (digits <= 0) throw new ArgumentOutOfRangeException(nameof(digits), digits, "Must be positive.");
            if (value == 0) return 0;
            var currentDigits = Digits.Count(value);
            if (currentDigits <= digits) return value;
            var factor = (short)Math.Pow(10, currentDigits - digits);
            return (short)(value / factor * factor);
        }

        public static long Truncate(long value, int digits)
        {
            if (digits <= 0) throw new ArgumentOutOfRangeException(nameof(digits), digits, "Must be positive.");
            if (value == 0) return 0;
            var currentDigits = Digits.Count(value);
            if (currentDigits <= digits) return value;
            var factor = (long)Math.Pow(10, currentDigits - digits);
            return value / factor * factor;
        }

        public static sbyte Truncate(sbyte value, int digits)
        {
            if (digits <= 0) throw new ArgumentOutOfRangeException(nameof(digits), digits, "Must be positive.");
            if (value == 0) return 0;
            var currentDigits = Digits.Count(value);
            if (currentDigits <= digits) return value;
            var factor = (sbyte)Math.Pow(10, currentDigits - digits);
            return (sbyte)(value / factor * factor);
        }

        public static ushort Truncate(ushort value, int digits)
        {
            if (digits <= 0) throw new ArgumentOutOfRangeException(nameof(digits), digits, "Must be positive.");
            if (value == 0) return 0;
            var currentDigits = Digits.Count(value);
            if (currentDigits <= digits) return value;
            var factor = (ushort)Math.Pow(10, currentDigits - digits);
            return (ushort)(value / factor * factor);
        }

        public static uint Truncate(uint value, int digits)
        {
            if (digits <= 0) throw new ArgumentOutOfRangeException(nameof(digits), digits, "Must be positive.");
            if (value == 0) return 0;
            var currentDigits = Digits.Count(value);
            if (currentDigits <= digits) return value;
            var factor = (uint)Math.Pow(10, currentDigits - digits);
            return value / factor * factor;
        }

        public static ulong Truncate(ulong value, int digits)
        {
            if (digits <= 0) throw new ArgumentOutOfRangeException(nameof(digits), digits, "Must be positive.");
            if (value == 0) return 0;
            var currentDigits = Digits.Count(value);
            if (currentDigits <= (ulong)digits) return value;
            var factor = (ulong)Math.Pow(10, currentDigits - (ulong)digits);
            return value / factor * factor;
        }

        public static BigInteger Truncate(BigInteger value, int digits)
        {
            if (digits <= 0) throw new ArgumentOutOfRangeException(nameof(digits), digits, "Must be positive.");
            if (value == 0) return 0;
            var currentDigits = (int)BigInteger.Log10(BigInteger.Abs(value)) + 1;
            if (currentDigits <= digits) return value;
            var factor = (int)Math.Pow(10, currentDigits - digits);
            return value / factor * factor;
        }

        public static float Truncate(float value, int digits)
        {
            if (digits <= 0) throw new ArgumentOutOfRangeException(nameof(digits), digits, "Must be positive.");
            if (value == 0) return 0;
            var log10 = (int)MathF.Floor(MathF.Log10(MathF.Abs(value)));
            if (log10 < -1 && log10 < -digits) return 0;
            if (log10 < digits)
            {
                var scalingFactor = (int)Math.Pow(10, digits - log10);
                var scaled = MathF.Truncate(value * scalingFactor);
                scaled -= scaled % 10;
                return scaled / scalingFactor;
            }
            else
            {
                var scalingFactor = (int)Math.Pow(10, log10 - digits + 1);
                return MathF.Truncate(value / scalingFactor) * scalingFactor;
            }
        }

        public static double Truncate(double value, int digits)
        {
            if (digits <= 0) throw new ArgumentOutOfRangeException(nameof(digits), digits, "Must be positive.");
            if (value == 0) return 0;
            var log10 = (int)Math.Floor(Math.Log10(Math.Abs(value)));
            if (log10 < -1 && log10 < -digits) return 0;
            if (log10 < digits)
            {
                var scalingFactor = (int)Math.Pow(10, digits - log10);
                var scaled = Math.Truncate(value * scalingFactor);
                scaled -= scaled % 10;
                return scaled / scalingFactor;
            }
            else
            {
                var scalingFactor = (int)Math.Pow(10, log10 - digits + 1);
                return Math.Truncate(value / scalingFactor) * scalingFactor;
            }
        }

        public static decimal Truncate(decimal value, int digits)
        {
            if (digits <= 0) throw new ArgumentOutOfRangeException(nameof(digits), digits, "Must be positive.");
            if (value == 0) return 0;
            var log10 = (int)Math.Floor(Math.Log10(Math.Abs((double)value)));
            if (log10 < -1 && log10 < -digits) return 0;
            if (log10 < digits)
            {
                var scalingFactor = (int)Math.Pow(10, digits - log10);
                var scaled = Math.Truncate(value * scalingFactor);
                scaled -= scaled % 10;
                return scaled / scalingFactor;
            }
            else
            {
                var scalingFactor = (int)Math.Pow(10, log10 - digits + 1);
                return Math.Truncate(value / scalingFactor) * scalingFactor;
            }
        }

        public static byte Count(byte value)
        {
            if (value < 10) return 1;
            if (value < 100) return 2;
            return 3;
        }

        public static byte Count(ushort value)
        {
            if (value < 10) return 1;
            if (value < 100) return 2;
            if (value < 1000) return 3;
            if (value < 10000) return 4;
            return 5;
        }

        public static byte Count(uint value)
        {
            if (value < 10) return 1;
            if (value < 100) return 2;
            if (value < 1000) return 3;
            if (value < 10000) return 4;
            if (value < 100000) return 5;
            if (value < 1000000) return 6;
            if (value < 10000000) return 7;
            if (value < 100000000) return 8;
            if (value < 1000000000) return 9;
            return 10;
        }

        public static byte Count(ulong value)
        {
            if (value < 10) return 1;
            if (value < 100) return 2;
            if (value < 1000) return 3;
            if (value < 10000) return 4;
            if (value < 100000) return 5;
            if (value < 1000000) return 6;
            if (value < 10000000) return 7;
            if (value < 100000000) return 8;
            if (value < 1000000000) return 9;
            if (value < 10000000000) return 10;
            if (value < 100000000000) return 11;
            if (value < 1000000000000) return 12;
            if (value < 10000000000000) return 13;
            if (value < 100000000000000) return 14;
            if (value < 1000000000000000) return 15;
            if (value < 10000000000000000) return 16;
            if (value < 100000000000000000) return 17;
            if (value < 1000000000000000000) return 18;
            if (value < 10000000000000000000) return 19;
            return 20;
        }

        public static byte Count(sbyte value)
        {
            if (value < 10 && value > -10) return 1;
            if (value < 100 && value > -100) return 2;
            return 3;
        }

        public static byte Count(short value)
        {
            if (value > 0)
            {
                if (value < 10) return 1;
                if (value < 100) return 2;
                if (value < 1000) return 3;
                if (value < 10000) return 4;
                return 5;
            }
            else
            {
                if (value > -10) return 1;
                if (value > -100) return 2;
                if (value > -1000) return 3;
                if (value > -10000) return 4;
                return 5;
            }
        }

        public static byte Count(int value)
        {
            if (value > 0)
            {
                if (value < 10) return 1;
                if (value < 100) return 2;
                if (value < 1000) return 3;
                if (value < 10000) return 4;
                if (value < 100000) return 5;
                if (value < 1000000) return 6;
                if (value < 10000000) return 7;
                if (value < 100000000) return 8;
                if (value < 1000000000) return 9;
                return 10;
            }
            else
            {
                if (value > -10) return 1;
                if (value > -100) return 2;
                if (value > -1000) return 3;
                if (value > -10000) return 4;
                if (value > -100000) return 5;
                if (value > -1000000) return 6;
                if (value > -10000000) return 7;
                if (value > -100000000) return 8;
                if (value > -1000000000) return 9;
                return 10;
            }
        }

        public static byte Count(long value)
        {
            if (value > 0)
            {
                if (value < 10) return 1;
                if (value < 100) return 2;
                if (value < 1000) return 3;
                if (value < 10000) return 4;
                if (value < 100000) return 5;
                if (value < 1000000) return 6;
                if (value < 10000000) return 7;
                if (value < 100000000) return 8;
                if (value < 1000000000) return 9;
                if (value < 10000000000) return 10;
                if (value < 100000000000) return 11;
                if (value < 1000000000000) return 12;
                if (value < 10000000000000) return 13;
                if (value < 100000000000000) return 14;
                if (value < 1000000000000000) return 15;
                if (value < 10000000000000000) return 16;
                if (value < 100000000000000000) return 17;
                if (value < 1000000000000000000) return 18;
                return 19;
            }
            else
            {
                if (value > -10) return 1;
                if (value > -100) return 2;
                if (value > -1000) return 3;
                if (value > -10000) return 4;
                if (value > -100000) return 5;
                if (value > -1000000) return 6;
                if (value > -10000000) return 7;
                if (value > -100000000) return 8;
                if (value > -1000000000) return 9;
                if (value > -10000000000) return 10;
                if (value > -100000000000) return 11;
                if (value > -1000000000000) return 12;
                if (value > -10000000000000) return 13;
                if (value > -100000000000000) return 14;
                if (value > -1000000000000000) return 15;
                if (value > -10000000000000000) return 16;
                if (value > -100000000000000000) return 17;
                if (value > -1000000000000000000) return 18;
                return 19;
            }
        }

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

        private static ulong RoundToNegativeInfinity(ulong value)
        {
            var remainder = value % 10;
            if (remainder == 0) return value;
            return value - remainder;
        }
    }
}
