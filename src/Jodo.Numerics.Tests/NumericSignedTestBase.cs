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
using Jodo.Testing;
using NUnit.Framework;

namespace Jodo.Numerics.Tests
{
    public abstract class NumericSignedTestBase<TNumeric> : GlobalFixtureBase where TNumeric : struct, INumeric<TNumeric>
    {
        [SetUp]
        public void SetUp() => Assert.That(Numeric.IsSigned<TNumeric>());

        [Test]
        public void MinUnit_IsMinusOne()
        {
            ConvertN.ToDouble(Numeric.MinUnit<TNumeric>()).Should().Be(-1);
        }

        [Test]
        public void MinValue_IsLessThanMinUnit()
        {
            Numeric.MinValue<TNumeric>().IsLessThan(Numeric.MinUnit<TNumeric>()).Should().BeTrue();
        }

        [Test, Repeat(RandomVariations)]
        public void Negative_RandomNegativeValue_ReturnsPositive()
        {
            //arrange
            sbyte input = Random.NextSByte(-127, -1);
            TNumeric inputN = ConvertN.ToNumeric<TNumeric>(input, Conversion.Cast);

            //act
            TNumeric result = inputN.Negative();

            //assert
            result.Should().Be(ConvertN.ToNumeric<TNumeric>(input * -1, Conversion.Cast));
        }

        [Test, Repeat(RandomVariations)]
        public void IsNegative_RandomValue_ReturnsCorrectResult()
        {
            //arrange
            TNumeric input = Random.NextNumeric<TNumeric>(Generation.Extended);
            bool expected = input.IsLessThan(Numeric.Zero<TNumeric>());

            //act
            bool result = Numeric.IsNegative(input);

            //assert
            result.Should().Be(expected);
        }

        [Test, Repeat(RandomVariations)]
        public void Abs_Negative_PositiveEquivalent()
        {
            //arrange
            TNumeric input = Random.NextNumeric(Numeric.MinValue<TNumeric>().Add(Numeric.MaxUnit<TNumeric>()), Numeric.MinUnit<TNumeric>(), Generation.Extended);
            TNumeric expected = Numeric.MinUnit<TNumeric>().Multiply(input);

            //act
            TNumeric result = MathN.Abs(input);

            //assert
            result.Should().Be(expected);
        }

        [Test, Repeat(RandomVariations)]
        public void Sign_RandomNegativeValue_ReturnsNegativeOne()
        {
            //arrange
            TNumeric input = Random.NextNumeric(Numeric.MinValue<TNumeric>(), Numeric.Zero<TNumeric>(), Generation.Extended);

            //act
            int result = MathN.Sign(input);

            //assert
            result.Should().Be(-1);
        }
    }
}
