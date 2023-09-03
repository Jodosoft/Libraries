// Copyright (c) 2023 Joe Lawry-Short
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
using Jodosoft.Testing;
using NUnit.Framework;

namespace Jodosoft.Numerics.Tests
{
    public class CheckedNumericTestBase<TNumeric> : GlobalFixtureBase where TNumeric : struct, INumeric<TNumeric>
    {
        [Test, Repeat(RandomVariations)]
        public void Abs_AnyValue_ShouldBeNonNegative()
        {
            //arrange
            TNumeric input = Numeric.MaxValue<TNumeric>();

            //act
            TNumeric result = MathN.Abs(input);

            //assert
            result.Should().BeGreaterThanOrEqualTo(Numeric.Zero<TNumeric>());
        }

        [Test]
        public void Add_MaxValueAndMaxValue_ReturnsMaxValue()
        {
            //arrange
            TNumeric left = Numeric.MaxValue<TNumeric>();
            TNumeric right = Numeric.MaxValue<TNumeric>();

            //act
            TNumeric result = left.Add(right);

            //assert
            result.Should().Be(Numeric.MaxValue<TNumeric>());
        }

        [Test]
        public void Add_MaxValueAndOne_ReturnsMaxValue()
        {
            //arrange
            TNumeric left = Numeric.MaxValue<TNumeric>();
            TNumeric right = Numeric.One<TNumeric>();

            //act
            TNumeric result = left.Add(right);

            //assert
            result.Should().Be(Numeric.MaxValue<TNumeric>());
        }

        [Test]
        public void Subtract_MinValueAndMaxValue_ReturnsMinValue()
        {
            //arrange
            TNumeric left = Numeric.MinValue<TNumeric>();
            TNumeric right = Numeric.MaxValue<TNumeric>();

            //act
            TNumeric result = left.Subtract(right);

            //assert
            result.Should().Be(Numeric.MinValue<TNumeric>());
        }

        [Test]
        public void Subtract_MinValueAndOne_ReturnsMinValue()
        {
            //arrange
            TNumeric left = Numeric.MinValue<TNumeric>();
            TNumeric right = Numeric.One<TNumeric>();

            //act
            TNumeric result = left.Subtract(right);

            //assert
            result.Should().Be(Numeric.MinValue<TNumeric>());
        }

        [Test]
        public void Multiply_MaxValueAndMaxValue_ReturnsMaxValue()
        {
            //arrange
            TNumeric left = Numeric.MaxValue<TNumeric>();
            TNumeric right = Numeric.MaxValue<TNumeric>();

            //act
            TNumeric result = left.Multiply(right);

            //assert
            result.Should().Be(Numeric.MaxValue<TNumeric>());
        }

        [Test]
        public void Multiply_MaxValueAndTwo_ReturnsMaxValue()
        {
            //arrange
            TNumeric left = Numeric.MaxValue<TNumeric>();
            TNumeric right = ConvertN.ToNumeric<TNumeric>(2, Conversion.Cast);

            //act
            TNumeric result = left.Multiply(right);

            //assert
            result.Should().Be(Numeric.MaxValue<TNumeric>());
        }

        [Test, Repeat(RandomVariations)]
        public void Divide_ByZero_ReturnsMaxValue()
        {
            //arrange
            TNumeric left = Random.NextNumeric<TNumeric>(Generation.Extended);
            TNumeric right = Numeric.Zero<TNumeric>();

            //act
            TNumeric result = left.Divide(right);

            //assert
            result.Should().Be(Numeric.MaxValue<TNumeric>());
        }

        [Test, Repeat(RandomVariations)]
        public void Remainder_ByZero_ReturnsZero()
        {
            //arrange
            TNumeric left = Random.NextNumeric<TNumeric>(Generation.Extended);
            TNumeric right = Numeric.Zero<TNumeric>();

            //act
            TNumeric result = left.Remainder(right);

            //assert
            result.Should().Be(Numeric.Zero<TNumeric>());
        }
    }
}
