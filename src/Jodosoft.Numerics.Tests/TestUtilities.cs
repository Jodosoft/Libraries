﻿// Copyright (c) 2023 Joe Lawry-Short
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

namespace Jodosoft.Numerics.Tests
{
    public static class TestUtilities
    {
        public static double ReduceSignificance<TNumeric>(TNumeric value) where TNumeric : struct, INumeric<TNumeric>
        {
            double result = Math.Round(ConvertN.ToDouble(value, Conversion.Cast), 6);
            int log10 = (int)Math.Log10(Math.Abs(result / 10));
            if (log10 < -1) result *= 1000;
            else if (log10 > 3) result /= Math.Pow(10, log10 - 3);

            if (!Numeric.IsFinite(ConvertN.ToNumeric<TNumeric>(result, Conversion.Cast)))
            {
                throw new InvalidOperationException();
            }

            return Math.Round(result, 6);
        }
    }
}
