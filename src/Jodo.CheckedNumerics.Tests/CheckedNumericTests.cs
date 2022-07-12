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
using FluentAssertions;
using Jodo.Numerics;
using Jodo.Testing;
using NUnit.Framework;

namespace Jodo.CheckedNumerics.Tests
{
    public class CheckedNumericTests<N> : GlobalFixtureBase where N : struct, INumeric<N>
    {
        [Test]
        public void Add_MaxValueAndMaxValue_ReturnsMaxValue()
        {
            //arrange
            N left = Numeric<N>.MaxValue;
            N right = Numeric<N>.MaxValue;

            //act
            N result = left.Add(right);

            //assert
            result.Should().Be(Numeric<N>.MaxValue);
        }

        [Test]
        public void Add_MaxValueAndOne_ReturnsMaxValue()
        {
            //arrange
            N left = Numeric<N>.MaxValue;
            N right = Numeric<N>.One;

            //act
            N result = left.Add(right);

            //assert
            result.Should().Be(Numeric<N>.MaxValue);
        }

        [Test]
        public void Subtract_MinValueAndMaxValue_ReturnsMinValue()
        {
            //arrange
            N left = Numeric<N>.MinValue;
            N right = Numeric<N>.MaxValue;

            //act
            N result = left.Subtract(right);

            //assert
            result.Should().Be(Numeric<N>.MinValue);
        }

        [Test]
        public void Subtract_MinValueAndOne_ReturnsMinValue()
        {
            //arrange
            N left = Numeric<N>.MinValue;
            N right = Numeric<N>.One;

            //act
            N result = left.Subtract(right);

            //assert
            result.Should().Be(Numeric<N>.MinValue);
        }

        [Test]
        public void Multiply_MaxValueAndMaxValue_ReturnsMaxValue()
        {
            //arrange
            N left = Numeric<N>.MaxValue;
            N right = Numeric<N>.MaxValue;

            //act
            N result = left.Multiply(right);

            //assert
            result.Should().Be(Numeric<N>.MaxValue);
        }

        [Test]
        public void Multiply_MaxValueAndTwo_ReturnsMaxValue()
        {
            //arrange
            N left = Numeric<N>.MaxValue;
            N right = Convert<N>.ToNumeric(2, Conversion.Cast);

            //act
            N result = left.Multiply(right);

            //assert
            result.Should().Be(Numeric<N>.MaxValue);
        }

        [Test, Repeat(RandomVariations)]
        public void Divide_ByZero_ReturnsMaxValue()
        {
            //arrange
            N left = Random.NextNumeric<N>();
            N right = Numeric<N>.Zero;

            //act
            N result = left.Divide(right);

            //assert
            result.Should().Be(Numeric<N>.MaxValue);
        }

        [Test, Repeat(RandomVariations)]
        public void Remainder_ByZero_ReturnsZero()
        {
            //arrange
            N left = Random.NextNumeric<N>();
            N right = Numeric<N>.Zero;

            //act
            N result = left.Remainder(right);

            //assert
            result.Should().Be(Numeric<N>.Zero);
        }
    }
}
