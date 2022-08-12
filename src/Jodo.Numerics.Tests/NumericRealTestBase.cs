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
using Jodo.Primitives;
using Jodo.Testing;
using NUnit.Framework;

namespace Jodo.Numerics.Tests
{
    public abstract class NumericRealTestBase<TNumeric> : GlobalFixtureBase where TNumeric : struct, INumeric<TNumeric>
    {
        [SetUp]
        public void SetUp() => Assert.That(Numeric.IsReal<TNumeric>());

        [Test]
        public void Epsilon_LessThanOne()
        {
            Numeric.Epsilon<TNumeric>().IsLessThan(Numeric.One<TNumeric>()).Should().BeTrue();
        }

        [Test]
        public void Epsilon_ApproximatelyZero()
        {
            ConvertN.ToDouble(Numeric.Epsilon<TNumeric>()).Should().BeApproximately(0, 0.001);
        }

        [Test, Repeat(RandomVariations)]
        public void LogicalAnd_RandomValues_DoesntThrow()
        {
            //arrange
            TNumeric left = Random.NextNumeric<TNumeric>();
            TNumeric right = Random.NextNumeric<TNumeric>();

            //act
            Func<TNumeric> action = new Func<TNumeric>(() => left.LogicalAnd(right));

            //assert
            action.Should().NotThrow();
        }

        [Test, Repeat(RandomVariations)]
        public void LogicalOr_RandomValues_DoesntThrow()
        {
            //arrange
            TNumeric left = Random.NextNumeric<TNumeric>();
            TNumeric right = Random.NextNumeric<TNumeric>();

            //act
            Func<TNumeric> action = new Func<TNumeric>(() => left.LogicalOr(right));

            //assert
            action.Should().NotThrow();
        }

        [Test, Repeat(RandomVariations)]
        public void LogicalExclusiveOr_RandomValues_DoesntThrow()
        {
            //arrange
            TNumeric left = Random.NextNumeric<TNumeric>();
            TNumeric right = Random.NextNumeric<TNumeric>();

            //act
            Func<TNumeric> action = new Func<TNumeric>(() => left.LogicalExclusiveOr(right));

            //assert
            action.Should().NotThrow();
        }

        [Test, Repeat(RandomVariations)]
        public void BitwiseComplement_RandomValue_DoesntThrow()
        {
            //arrange
            TNumeric left = Random.NextNumeric<TNumeric>();

            //act
            Func<TNumeric> action = new Func<TNumeric>(() => left.BitwiseComplement());

            //assert
            action.Should().NotThrow();
        }

        [Test, Repeat(RandomVariations)]
        public void LeftShift_RandomValues_DoesntThrow()
        {
            //arrange
            TNumeric left = Random.NextNumeric<TNumeric>();
            int right = Random.NextInt32(0, 2);

            //act
            Func<TNumeric> action = new Func<TNumeric>(() => left.LeftShift(right));

            //assert
            action.Should().NotThrow();
        }

        [Test, Repeat(RandomVariations)]
        public void RightShift_RandomValue_DoesntThrow()
        {
            //arrange
            TNumeric left = Random.NextNumeric<TNumeric>();
            int right = Random.NextInt32(0, 2);

            //act
            Func<TNumeric> action = new Func<TNumeric>(() => left.RightShift(right));

            //assert
            action.Should().NotThrow();
        }

        [Test, Repeat(RandomVariations)]
        public void Round_RandomReal_EquivalentToSystemMath()
        {
            //arrange
            double randomValue = Math.Round(Random.NextDouble(Numeric.IsSigned<TNumeric>() ? -10 : 0, 10), 1);
            TNumeric input = ConvertN.ToNumeric<TNumeric>(randomValue, Conversion.Cast);
            TNumeric expected = ConvertN.ToNumeric<TNumeric>(Math.Round(randomValue), Conversion.Cast);

            //act
            TNumeric result = MathN.Round(input);

            //assert
            result.Should().Be(expected);
        }
    }
}
