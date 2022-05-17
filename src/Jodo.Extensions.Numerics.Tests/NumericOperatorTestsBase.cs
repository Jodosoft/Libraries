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
using Jodo.Extensions.Primitives;
using Jodo.Extensions.Testing;
using NUnit.Framework;
using System;

namespace Jodo.Extensions.Numerics.Tests
{
    public abstract class NumericOperatorTestsBase<T> : GlobalTestBase where T : struct, INumeric<T>
    {
        public T NextSmall()
        {
            var result = Random.NextNumeric<T>(0, 10);

            if (Math<T>.IsReal) result = Math<T>.Round(result / 2, 1);
            if (Math<T>.IsSigned) result -= 5;
            return result;
        }

        public T NextSmallPositive()
        {
            var result = Random.NextNumeric<T>(0, 10);
            if (Math<T>.IsReal) result = Math<T>.Round(result / 2, 1);
            return result + 1;
        }

        [Test]
        public void Add_RandomValues_CorrectResult()
        {
            //arrange
            var left = NextSmall();
            var right = NextSmall();

            //act
            var result = left + right;

            //assert
            result.Should().BeApproximately(Convert<T>.ToDouble(left) + Convert<T>.ToDouble(right));
        }

        [Test]
        public void AddSubtract_Random_CorrectResult()
        {
            //arrange
            var left = NextSmall();
            var right = NextSmall();

            //act
            var result = (left + right - right);

            //assert
            result.Should().BeApproximately(Convert<T>.ToDouble(left));
        }

        [Test]
        public void Multiply_RandomValues_CorrectResult()
        {
            //arrange
            var left = NextSmall();
            var right = NextSmall();

            //act
            var result = left * right;

            //assert
            result.Should().BeApproximately(Convert<T>.ToDouble(left) * Convert<T>.ToDouble(right));
        }

        [Test]
        public void Positive_RandomValue_ReturnsSameValue()
        {
            //arrange
            var input = Random.NextNumeric<T>();

            //act
            var result = +input;

            //assert
            result.Should().Be(input);
        }

        [Test]
        public void Multiply_RandomValueByZero_ReturnsZero()
        {
            //arrange
            var input = Random.NextNumeric<T>();

            //act
            var result = input * 0;

            //assert
            result.Should().Be(Math<T>.Zero);
        }

        [Test]
        public void Multiply_RandomValueByOne_ReturnSameValue()
        {
            //arrange
            var input = Random.NextNumeric<T>();

            //act
            var result = input * 1;

            //assert
            result.Should().Be(input);
        }

        [Test]
        public void Divide_RandomValueByOne_ReturnsSameValue()
        {
            //arrange
            var input = Random.NextNumeric<T>();

            //act
            var result = input / 1;

            //assert
            result.Should().Be(input);
        }

        [Test]
        public void Divide_RandomValueByItself_ReturnsOne()
        {
            //arrange
            var input = Random.NextNumeric<T>();

            //act
            var result = input / 1;

            //assert
            result.Should().Be(input);
        }

        [Test]
        public void Divide_RandomValues_CorrectResult()
        {
            //arrange
            var left = NextSmall();
            var right = NextSmallPositive();

            //act
            var result = left / right;

            //assert
            result.Should().BeApproximately(Convert<T>.ToDouble(left) / Convert<T>.ToDouble(right));
        }
    }
}
