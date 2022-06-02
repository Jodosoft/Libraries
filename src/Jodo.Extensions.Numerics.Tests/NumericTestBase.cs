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

using Jodo.Extensions.Testing;
using NUnit.Framework;
using System;

namespace Jodo.Extensions.Numerics.Tests
{
    public abstract class NumericTestBase<N> : GlobalTestBase where N : struct, INumeric<N>
    {
        public const double MaxTestableReal = 100_000d;

        protected double FindTestableDouble(N value)
        {
            var result = Math.Round(Cast<N>.ToDouble(value), 6);
            var log10 = (int)Math.Log10(Math.Abs(result / 10));
            if (log10 < -1) result *= 1000;
            else if (log10 > 3) result /= Math.Pow(10, log10 - 3);

            if (!Numeric<N>.IsFinite(Cast<N>.ToValue(result)))
            {
                throw new InvalidOperationException();
            }
            return Math.Round(result, 6);
        }

        public static class OnlyApplicableTo
        {

            public static void Integral()
            {
                if (Numeric<N>.IsReal) Assert.Pass($"This test is N/A because {typeof(N).Name} is not an integral numeric type.");
            }

            public static void Real()
            {
                if (!Numeric<N>.IsReal) Assert.Pass($"This test is N/A because {typeof(N).Name} is not a real numeric type.");
            }

            public static void Signed()
            {
                if (!Numeric<N>.IsSigned) Assert.Pass($"This test is N/A because {typeof(N).Name} is not a signed numeric type.");
            }

            public static void Unsigned()
            {
                if (Numeric<N>.IsSigned) Assert.Pass($"This test is N/A because {typeof(N).Name} is not an unsigned numeric type.");
            }

            public static void FloatingPoint()
            {
                if (!Numeric<N>.HasFloatingPoint) Assert.Pass($"This test is N/A because {typeof(N).Name} is not a floating-point numeric type.");
            }

            public static void NonFloatingPoint()
            {
                if (Numeric<N>.HasFloatingPoint) Assert.Pass($"This test is N/A because {typeof(N).Name} is a floating-point numeric type.");
            }
        }
    }
}
