﻿// Copyright (c) 2022 Joseph J. Short
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
        public const double MaxTestableReal = 1_000_000d;

        protected void IntegralOnly()
        {
            if (Math<N>.IsReal) Assert.Pass($"This test is N/A because {typeof(N).Name} is not an integral type.");
        }

        protected void RealOnly()
        {
            if (!Math<N>.IsReal) Assert.Pass($"This test is N/A because {typeof(N).Name} is not real type.");
        }

        protected void SignedOnly()
        {
            if (!Math<N>.IsSigned) Assert.Pass($"This test is N/A because {typeof(N).Name} is not signed type.");
        }

        protected void UnsignedOnly()
        {
            if (Math<N>.IsSigned) Assert.Pass($"This test is N/A because {typeof(N).Name} is not unsigned type.");
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
                result /= 10;
            }
            return result;
        }

        protected N NextSmallPositiveNumeric()
        {
            N result = Random.NextNumeric<N>(0, 20);
            if (Math<N>.IsReal)
            {
                result /= 10;
            }
            return result;
        }
    }
}