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
using Jodo.Testing;
using NUnit.Framework;

namespace Jodo.Numerics.Tests
{
    public abstract class NumericInfinityTestBase<TNumeric> : GlobalFixtureBase where TNumeric : struct, INumeric<TNumeric>
    {
        [SetUp]
        public void SetUp() => Assert.That(Numeric.HasInfinity<TNumeric>());

        [TestCase(double.PositiveInfinity, false)]
        [TestCase(double.NegativeInfinity, false)]
        [TestCase(double.NaN, false)]
        [TestCase(0, true)]
        public void IsFinite_Examples_ReturnsExpected(double value, bool expected)
        {
            //arrange
            TNumeric input = ConvertN.ToNumeric<TNumeric>(value, Conversion.Cast);

            //act
            bool result = Numeric.IsFinite(input);

            //assert
            result.Should().Be(expected);
        }

        [TestCase(double.PositiveInfinity, true)]
        [TestCase(double.NegativeInfinity, true)]
        [TestCase(double.NaN, false)]
        [TestCase(0, false)]
        public void IsInfinity_Examples_ReturnsExpected(double value, bool expected)
        {
            //arrange
            TNumeric input = ConvertN.ToNumeric<TNumeric>(value, Conversion.Cast);

            //act
            bool result = Numeric.IsInfinity(input);

            //assert
            result.Should().Be(expected);
        }

        [TestCase(double.PositiveInfinity, true)]
        [TestCase(double.NegativeInfinity, false)]
        [TestCase(double.NaN, false)]
        [TestCase(0, false)]
        public void IsPositiveInfinity_Examples_ReturnsExpected(double value, bool expected)
        {
            //arrange
            TNumeric input = ConvertN.ToNumeric<TNumeric>(value, Conversion.Cast);

            //act
            bool result = Numeric.IsPositiveInfinity(input);

            //assert
            result.Should().Be(expected);
        }

        [TestCase(double.PositiveInfinity, false)]
        [TestCase(double.NegativeInfinity, true)]
        [TestCase(double.NaN, false)]
        [TestCase(0, false)]
        public void IsNegativeInfinity_Examples_ReturnsExpected(double value, bool expected)
        {
            //arrange
            TNumeric input = ConvertN.ToNumeric<TNumeric>(value, Conversion.Cast);

            //act
            bool result = Numeric.IsNegativeInfinity(input);

            //assert
            result.Should().Be(expected);
        }
    }
}
