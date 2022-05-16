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

using FluentAssertions;
using Jodo.Extensions.Testing;
using NUnit.Framework;
using System;

namespace Jodo.Extensions.Numerics.Tests
{
    public abstract class ConstantsTestsBase<T> : GlobalTestBase where T : struct, INumeric<T>
    {
        private T NextInput()
        {
            T result = Random.NextNumeric<T>(0, 20);

            if (Constants<T>.IsSigned && Random.NextBoolean())
            {
                result = -result;
            }

            if (Constants<T>.IsReal)
            {
                result /= 10;
            }
            return result;
        }

        [Test]
        public void Zero_ReturnsZero()
        {
            //arrange

            //act
            var result = Constants<T>.Zero;

            //assert
            result.ToDouble().Should().Be(0);
        }

        [Test]
        public void Epsilon_IntegralValue_ReturnsOne()
        {
            //arrange
            if (Constants<T>.IsReal) return;

            //act
            var result = Constants<T>.Epsilon;

            //assert
            result.ToDouble().Should().Be(1);
        }

        [Test]
        public void Epsilon_RealValue_GreaterThanZero()
        {
            //arrange
            if (Constants<T>.IsReal) return;

            //act
            var result = Constants<T>.Epsilon;

            //assert
            result.ToDouble().Should().BeGreaterThan(0);
        }

        [Test]
        public void Epsilon_RealValue_ApproximatelyZero()
        {
            //arrange
            if (Constants<T>.IsReal) return;

            //act
            var result = Constants<T>.Epsilon - Constants<T>.Epsilon;

            //assert
            result.ToDouble().Should().BeApproximately(0, 0.0001);
        }
    }
}
