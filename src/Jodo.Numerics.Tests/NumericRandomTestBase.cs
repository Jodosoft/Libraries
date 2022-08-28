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

using System;
using FluentAssertions;
using Jodo.Testing;
using NUnit.Framework;

namespace Jodo.Numerics.Tests
{
    public abstract class NumericRandomTestBase<TNumeric> : GlobalFixtureBase where TNumeric : struct, INumeric<TNumeric>
    {
        public const int SampleSize = 1000;

        [Test]
        public void NextNumeric_SameSeedNoBoundsDefault_OverloadsGiveSameResult()
        {
            //arrange
            int seed = Random.Next();
            Random random1 = new Random(seed);
            Random random2 = new Random(seed);
            Random random3 = new Random(seed);
            Random random4 = new Random(seed);
            Random random5 = new Random(seed);

            //act
            //assert
            for (int i = 0; i < 100; i++)
            {
                AssertSame.Result(
                   () => random1.NextNumeric<TNumeric>(),
                   () => random2.NextNumeric<TNumeric>(Generation.Default),
                   () => random3.NextNumeric(Numeric.MaxValue<TNumeric>()),
                   () => random4.NextNumeric(Numeric.Zero<TNumeric>(), Numeric.MaxValue<TNumeric>()),
                   () => random5.NextNumeric(Numeric.Zero<TNumeric>(), Numeric.MaxValue<TNumeric>(), Generation.Default));
            }
            AssertSame.Result(random1.Next, random2.Next, random3.Next, random4.Next, random5.Next); // same sample count
        }

        [Test]
        public void NextNumeric_SameSeedAndHighBoundDefault_OverloadsGiveSameResult()
        {
            //arrange
            int seed = Random.Next();
            TNumeric maxValue = Random.NextNumeric<TNumeric>(Generation.Extended);
            Random random1 = new Random(seed);
            Random random2 = new Random(seed);
            Random random3 = new Random(seed);

            //act
            //assert
            for (int i = 0; i < 100; i++)
            {
                AssertSame.Outcome(
                   () => random1.NextNumeric(maxValue),
                   () => random2.NextNumeric(Numeric.Zero<TNumeric>(), maxValue),
                   () => random3.NextNumeric(Numeric.Zero<TNumeric>(), maxValue, Generation.Default));
            }
            AssertSame.Result(random1.Next, random2.Next, random3.Next); // same sample count
        }

        [Test]
        public void NextNumeric_SameSeedAndBoundsDefault_OverloadsGiveSameResult()
        {
            //arrange
            int seed = Random.Next();
            TNumeric minValue = Random.NextNumeric<TNumeric>(Generation.Extended);
            TNumeric maxValue = Random.NextNumeric<TNumeric>(Generation.Extended);
            Random random1 = new Random(seed);
            Random random2 = new Random(seed);

            //act
            //assert
            for (int i = 0; i < SampleSize; i++)
            {
                AssertSame.Outcome(
                   () => random1.NextNumeric(minValue, maxValue),
                   () => random2.NextNumeric(minValue, maxValue, Generation.Default));
            }
            AssertSame.Result(random1.Next, random2.Next); // same sample count
        }

        [Test]
        public void NextNumeric_ReversedBoundsDefault_Throws()
        {
            //arrange
            TNumeric minValue;
            TNumeric maxValue;
            do
            {
                minValue = Random.NextNumeric<TNumeric>(Generation.Extended);
                maxValue = Random.NextNumeric<TNumeric>(Generation.Extended);
            } while (minValue.IsLessThanOrEqualTo(maxValue));

            //act
            Func<TNumeric> action1 = () => Random.NextNumeric(minValue, maxValue);
            Func<TNumeric> action2 = () => Random.NextNumeric(minValue, maxValue, Generation.Default);

            //assert
            action1.Should().Throw<ArgumentOutOfRangeException>();
            action2.Should().Throw<ArgumentOutOfRangeException>();
        }

        [Test]
        public void NextNumeric_SameSeedNoBoundsExtended_OverloadsGiveSameResult()
        {
            //arrange
            int seed = Random.Next();
            Random random1 = new Random(seed);
            Random random2 = new Random(seed);

            //act
            //assert
            for (int i = 0; i < SampleSize; i++)
            {
                AssertSame.Result(
                   () => random1.NextNumeric<TNumeric>(Generation.Extended),
                   () => random2.NextNumeric(Numeric.MinValue<TNumeric>(), Numeric.MaxValue<TNumeric>(), Generation.Extended));
            }
            AssertSame.Result(random1.Next, random2.Next); // same sample count
        }

        [Test]
        public void NextNumeric_SameSeedReversedBoundsExtended_GiveSameResult()
        {
            //arrange
            int seed = Random.Next();
            TNumeric minValue = Random.NextNumeric<TNumeric>(Generation.Extended);
            TNumeric maxValue = Random.NextNumeric<TNumeric>(Generation.Extended);
            Random random1 = new Random(seed);
            Random random2 = new Random(seed);

            //act
            //assert
            for (int i = 0; i < SampleSize; i++)
            {
                AssertSame.Result(
                   () => random1.NextNumeric(minValue, maxValue, Generation.Extended),
                   () => random2.NextNumeric(maxValue, minValue, Generation.Extended));
            }
            AssertSame.Result(random1.Next, random2.Next); // same sample count
        }
    }
}
