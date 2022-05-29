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
    public static class Truncate
    {
        public static byte ToDigits(byte value, int digits)
        {
            if (digits <= 0) throw new ArgumentOutOfRangeException(nameof(digits), digits, "Must be positive.");
            if (value == 0) return 0;
            var currentDigits = Digits.Count(value);
            if (currentDigits <= digits) return value;
            var factor = (int)Math.Pow(10, currentDigits - digits);
            return (byte)(value / factor * factor);
        }

        public static int ToDigits(int value, int digits)
        {
            if (digits <= 0) throw new ArgumentOutOfRangeException(nameof(digits), digits, "Must be positive.");
            if (value == 0) return 0;
            var currentDigits = Digits.Count(value);
            if (currentDigits <= digits) return value;
            var factor = (int)Math.Pow(10, currentDigits - digits);
            return value / factor * factor;
        }


        public static short ToDigits(short value, int digits)
        {
            if (digits <= 0) throw new ArgumentOutOfRangeException(nameof(digits), digits, "Must be positive.");
            if (value == 0) return 0;
            var currentDigits = Digits.Count(value);
            if (currentDigits <= digits) return value;
            var factor = (short)Math.Pow(10, currentDigits - digits);
            return (short)(value / factor * factor);
        }

        public static long ToDigits(long value, int digits)
        {
            if (digits <= 0) throw new ArgumentOutOfRangeException(nameof(digits), digits, "Must be positive.");
            if (value == 0) return 0;
            var currentDigits = Digits.Count(value);
            if (currentDigits <= digits) return value;
            var factor = (long)Math.Pow(10, currentDigits - digits);
            return value / factor * factor;
        }

        public static sbyte ToDigits(sbyte value, int digits)
        {
            if (digits <= 0) throw new ArgumentOutOfRangeException(nameof(digits), digits, "Must be positive.");
            if (value == 0) return 0;
            var currentDigits = Digits.Count(value);
            if (currentDigits <= digits) return value;
            var factor = (sbyte)Math.Pow(10, currentDigits - digits);
            return (sbyte)(value / factor * factor);
        }

        public static ushort ToDigits(ushort value, int digits)
        {
            if (digits <= 0) throw new ArgumentOutOfRangeException(nameof(digits), digits, "Must be positive.");
            if (value == 0) return 0;
            var currentDigits = Digits.Count(value);
            if (currentDigits <= digits) return value;
            var factor = (ushort)Math.Pow(10, currentDigits - digits);
            return (ushort)(value / factor * factor);
        }

        public static uint ToDigits(uint value, int digits)
        {
            if (digits <= 0) throw new ArgumentOutOfRangeException(nameof(digits), digits, "Must be positive.");
            if (value == 0) return 0;
            var currentDigits = Digits.Count(value);
            if (currentDigits <= digits) return value;
            var factor = (uint)Math.Pow(10, currentDigits - digits);
            return value / factor * factor;
        }

        public static ulong ToDigits(ulong value, int digits)
        {
            if (digits <= 0) throw new ArgumentOutOfRangeException(nameof(digits), digits, "Must be positive.");
            if (value == 0) return 0;
            var currentDigits = Digits.Count(value);
            if (currentDigits <= (ulong)digits) return value;
            var factor = (ulong)Math.Pow(10, currentDigits - (ulong)digits);
            return value / factor * factor;
        }

        public static BigInteger ToDigits(BigInteger value, int digits)
        {
            if (digits <= 0) throw new ArgumentOutOfRangeException(nameof(digits), digits, "Must be positive.");
            if (value == 0) return 0;
            var currentDigits = (int)BigInteger.Log10(BigInteger.Abs(value)) + 1;
            if (currentDigits <= digits) return value;
            var factor = (int)Math.Pow(10, currentDigits - digits);
            return value / factor * factor;
        }

        public static float ToDigits(float value, int digits)
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

        public static double ToDigits(double value, int digits)
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

        public static decimal ToDigits(decimal value, int digits)
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
    }
}
