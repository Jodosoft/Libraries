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

namespace Jodo.Extensions.Numerics
{
    public static class Round
    {
        public static long Digits(long value, int times, MidpointRounding mode)
        {
            for (int i = 0; i < times; i++) value = LastDigit(value / 10, mode);
            for (int i = 0; i < times; i++) value *= 10;
            return value;
        }

        public static ulong Digits(ulong value, int times, MidpointRounding mode)
        {
            for (int i = 0; i < times; i++) value = LastDigit(value / 10, mode);
            for (int i = 0; i < times; i++) value *= 10;
            return value;
        }

        public static long LastDigit(long scaledValue, MidpointRounding mode) => mode switch
        {
            MidpointRounding.ToEven => RoundLastDigitToEven(scaledValue),
            MidpointRounding.AwayFromZero => RoundLastDigitAwayFromZero(scaledValue),
            (MidpointRounding)2 => RoundLastDigitToZero(scaledValue),
            (MidpointRounding)3 => RoundLastDigitToNegativeInfinity(scaledValue),
            (MidpointRounding)4 => ToPositiveInfinity(scaledValue),
            _ => throw new ArgumentOutOfRangeException(nameof(mode), mode, $"Unknown value of {nameof(MidpointRounding)}"),
        };

        public static ulong LastDigit(ulong scaledValue, MidpointRounding mode) => mode switch
        {
            MidpointRounding.ToEven => RoundLastDigitToEven(scaledValue),
            MidpointRounding.AwayFromZero => RoundLastDigitAwayFromZero(scaledValue),
            (MidpointRounding)2 => RoundLastDigitToZero(scaledValue),
            (MidpointRounding)3 => RoundLastDigitToZero(scaledValue),
            (MidpointRounding)4 => RoundLastDigitToPositiveInfinity(scaledValue),
            _ => throw new ArgumentOutOfRangeException(nameof(mode), mode, $"Unknown value of {nameof(MidpointRounding)}"),
        };

        private static ulong RoundLastDigitToEven(ulong scaledValue)
        {
            var remainder = scaledValue % 10;
            if (remainder == 0) return scaledValue;
            if (remainder < 5) return scaledValue - remainder;
            else if (remainder > 5) return scaledValue + (10 - remainder);
            else if (scaledValue / 10 % 2 == 0) return scaledValue - 5;
            else return scaledValue + 5;
        }

        private static long RoundLastDigitToEven(long scaledValue)
        {
            var remainder = scaledValue % 10;
            if (remainder == 0) return scaledValue;
            if (remainder < 5) return scaledValue - remainder;
            else if (remainder > 5) return scaledValue + (10 - remainder);
            else if (scaledValue / 10 % 2 == 0) return scaledValue - 5;
            else return scaledValue + 5;
        }

        private static ulong RoundLastDigitAwayFromZero(ulong scaledValue)
        {
            var remainder = scaledValue % 10;
            if (remainder == 0) return scaledValue;
            if (remainder < 5) return scaledValue - remainder;
            else if (remainder > 5) return scaledValue + (10 - remainder);
            return scaledValue + 5;
        }

        private static long RoundLastDigitAwayFromZero(long scaledValue)
        {
            var remainder = scaledValue % 10;
            if (remainder == 0) return scaledValue;
            if (remainder < 5) return scaledValue - remainder;
            else if (remainder > 5) return scaledValue + (10 - remainder);
            if (scaledValue > 0) return scaledValue + 5;
            else return scaledValue - 5;
        }

        private static long RoundLastDigitToZero(long scaledValue)
        {
            var remainder = scaledValue % 10;
            if (remainder == 0) return scaledValue;
            if (scaledValue > 0) return scaledValue - remainder;
            else return scaledValue + remainder;
        }

        private static ulong RoundLastDigitToZero(ulong scaledValue)
        {
            var remainder = scaledValue % 10;
            if (remainder == 0) return scaledValue;
            return scaledValue - remainder;
        }

        private static long ToPositiveInfinity(long scaledValue)
        {
            var remainder = scaledValue % 10;
            if (remainder == 0) return scaledValue;
            return scaledValue + (10 - remainder);
        }

        private static ulong RoundLastDigitToPositiveInfinity(ulong scaledValue)
        {
            var remainder = scaledValue % 10;
            if (remainder == 0) return scaledValue;
            return scaledValue + (10 - remainder);
        }

        private static long RoundLastDigitToNegativeInfinity(long scaledValue)
        {
            var remainder = scaledValue % 10;
            if (remainder == 0) return scaledValue;
            return scaledValue - remainder;
        }
    }
}
