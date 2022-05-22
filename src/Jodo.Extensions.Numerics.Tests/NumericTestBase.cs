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

using Jodo.Extensions.Primitives;
using Jodo.Extensions.Testing;
using NUnit.Framework;
using System;

namespace Jodo.Extensions.Numerics.Tests
{
    public abstract class NumericTestBase<N> : GlobalTestBase where N : struct, INumeric<N>
    {
#if DEBUG
        public const int RandomVariations = 8;
#else
        public const int RandomVariations = 64;
#endif

        public const double MaxTestableReal = 100_000d;

        protected void IntegralOnly()
        {
            if (Math<N>.IsReal) Assert.Pass($"This test is N/A because {typeof(N).Name} is not an integral type.");
        }

        protected void RealOnly()
        {
            if (!Math<N>.IsReal) Assert.Pass($"This test is N/A because {typeof(N).Name} is not a real type.");
        }

        protected void SignedOnly()
        {
            if (!Math<N>.IsSigned) Assert.Pass($"This test is N/A because {typeof(N).Name} is not a signed type.");
        }

        protected void UnsignedOnly()
        {
            if (Math<N>.IsSigned) Assert.Pass($"This test is N/A because {typeof(N).Name} is not an unsigned type.");
        }

        protected N NextLowPrecision()
        {
            return Math<N>.Round(Random.NextNumeric<N>(-MaxTestableReal, MaxTestableReal), 1);
        }

        protected N NextLowPrecisionNonNegative()
        {
            return Math<N>.Round(Random.NextNumeric<N>(0, MaxTestableReal), 1);
        }

        protected N NextSmallNumeric()
        {
            N result = Random.NextNumeric<N>(0, 20);

            if (Math<N>.IsSigned && Random.NextBoolean())
            {
                result = -result;
            }

            if (Math<N>.IsReal)
            {
                result /= Convert<N>.ToNumeric(10);
            }
            return result;
        }

        protected N NextSmallPositiveNumeric()
        {
            N result = Random.NextNumeric<N>(0, 20);
            if (Math<N>.IsReal)
            {
                result /= Convert<N>.ToNumeric(10);
            }
            return result;
        }
    }
}
