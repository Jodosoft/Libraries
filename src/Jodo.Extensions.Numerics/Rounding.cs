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
        public static long RoundDigits(long value, int times, MidpointRounding mode)
        {
            for (int i = 0; i < times; i++) value = RoundLastDigit(value / 10, mode);
            for (int i = 0; i < times; i++) value *= 10;
            return value;
        }

        public static ulong RoundDigits(ulong value, int times, MidpointRounding mode)
        {
            for (int i = 0; i < times; i++) value = RoundLastDigit(value / 10, mode);
            for (int i = 0; i < times; i++) value *= 10;
            return value;
        }

        public static long RoundLastDigit(long scaledValue, MidpointRounding mode)
        {
            var remainder = scaledValue % 10;
            if (remainder == 0) return scaledValue;

            switch (mode)
            {
                case MidpointRounding.ToEven:
                    if (remainder < 5) return scaledValue - remainder;
                    else if (remainder > 5) return scaledValue + (10 - remainder);
                    else if (scaledValue / 10 % 2 == 0) return scaledValue - 5;
                    else return scaledValue + 5;

                case MidpointRounding.AwayFromZero:
                    if (remainder < 5) return scaledValue - remainder;
                    else if (remainder > 5) return scaledValue + (10 - remainder);
                    if (scaledValue > 0) return scaledValue + 5;
                    else return scaledValue - 5;

                case (MidpointRounding)2: // ToZero
                    if (scaledValue > 0) return scaledValue - remainder;
                    else return scaledValue + remainder;

                case (MidpointRounding)3: // ToNegativeInfinity
                    return scaledValue - remainder;

                case (MidpointRounding)4: // ToPositiveInfinity
                    return scaledValue + (10 - remainder);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mode), mode, $"Unknown value of {nameof(MidpointRounding)}");
            }
        }

        public static ulong RoundLastDigit(ulong scaledValue, MidpointRounding mode)
        {
            var remainder = scaledValue % 10;
            if (remainder == 0) return scaledValue;

            switch (mode)
            {
                case MidpointRounding.ToEven:
                    if (remainder < 5) return scaledValue - remainder;
                    else if (remainder > 5) return scaledValue + (10 - remainder);
                    else if (scaledValue / 10 % 2 == 0) return scaledValue - 5;
                    else return scaledValue + 5;

                case MidpointRounding.AwayFromZero:
                    if (remainder < 5) return scaledValue - remainder;
                    else if (remainder > 5) return scaledValue + (10 - remainder);
                    return scaledValue + 5;

                case (MidpointRounding)2: // ToZero
                case (MidpointRounding)3: // ToNegativeInfinity
                    return scaledValue - remainder;

                case (MidpointRounding)4: // ToPositiveInfinity
                    return scaledValue + (10 - remainder);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mode), mode, $"Unknown value of {nameof(MidpointRounding)}");
            }
        }
    }
}
