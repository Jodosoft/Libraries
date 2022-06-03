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
using Jodo.Extensions.Numerics;
using Jodo.Extensions.Testing;
using NUnit.Framework;
using System;

namespace Jodo.Extensions.CheckedNumerics.Tests
{
    public class CheckedNumericTests<N> : GlobalFixtureBase where N : struct, INumeric<N>
    {
        [Test]
        public void Add_MaxValueAndMaxValue_ReturnsMaxValue()
        {
            //arrange
            var left = Numeric<N>.MaxValue;
            var right = Numeric<N>.MaxValue;

            //act
            var result = left + right;

            //assert
            result.Should().Be(Numeric<N>.MaxValue);
        }

        [Test]
        public void Add_MaxValueAndOne_ReturnsMaxValue()
        {
            //arrange
            var left = Numeric<N>.MaxValue;
            var right = Numeric<N>.One;

            //act
            var result = left + right;

            //assert
            result.Should().Be(Numeric<N>.MaxValue);
        }

        [Test]
        public void Subtract_MinValueAndMaxValue_ReturnsMinValue()
        {
            //arrange
            var left = Numeric<N>.MinValue;
            var right = Numeric<N>.MaxValue;

            //act
            var result = left - right;

            //assert
            result.Should().Be(Numeric<N>.MinValue);
        }

        [Test]
        public void Subtract_MinValueAndOne_ReturnsMinValue()
        {
            //arrange
            var left = Numeric<N>.MinValue;
            var right = Numeric<N>.One;

            //act
            var result = left - right;

            //assert
            result.Should().Be(Numeric<N>.MinValue);
        }

        [Test]
        public void Multiply_MaxValueAndMaxValue_ReturnsMaxValue()
        {
            //arrange
            var left = Numeric<N>.MaxValue;
            var right = Numeric<N>.MaxValue;

            //act
            var result = left * right;

            //assert
            result.Should().Be(Numeric<N>.MaxValue);
        }

        [Test]
        public void Multiply_MaxValueAndTwo_ReturnsMaxValue()
        {
            //arrange
            var left = Numeric<N>.MaxValue;
            var right = Cast<N>.ToNumeric(2);

            //act
            var result = left * right;

            //assert
            result.Should().Be(Numeric<N>.MaxValue);
        }

        [Test, Repeat(RandomVariations)]
        public void Divide_ByZero_ReturnsMaxValue()
        {
            //arrange
            var left = Random.NextNumeric<N>();
            var right = Numeric<N>.Zero;

            //act
            var result = left / right;

            //assert
            result.Should().Be(Numeric<N>.MaxValue);
        }

        [Test, Repeat(RandomVariations)]
        public void Remainder_ByZero_ReturnsZero()
        {
            //arrange
            var left = Random.NextNumeric<N>();
            var right = Numeric<N>.Zero;

            //act
            var result = left % right;

            //assert
            result.Should().Be(Numeric<N>.Zero);
        }
    }
}
