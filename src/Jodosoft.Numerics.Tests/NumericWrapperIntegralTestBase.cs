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
using Jodosoft.Primitives;
using Jodosoft.Testing;
using NUnit.Framework;

namespace Jodosoft.Numerics.Tests
{
    public abstract class NumericWrapperIntegralTestBase<TNumeric, TUnderlying> : GlobalFixtureBase where TNumeric : struct, INumeric<TNumeric>
    {
        [SetUp]
        public void SetUp() => Assert.That(Numeric.IsIntegral<TNumeric>());

        [Test, Repeat(RandomVariations)]
        public void BitwiseComplementOperator_RandomValues_SameAsUnderlying()
        {
            //arrange
            TUnderlying left = DynamicInvoke.ConversionOperator<TUnderlying>(Random.NextVariant<TNumeric>());

            //act
            TUnderlying underlying()
                => DynamicInvoke.BitwiseComplementOperator(left);
            TUnderlying numeric()
                => DynamicInvoke.ConversionOperator<TUnderlying>(
                    DynamicInvoke.BitwiseComplementOperator(
                        DynamicInvoke.ConversionOperator<TNumeric>(left)));

            //assert
            AssertSame.Outcome(underlying, numeric);
        }

        [Test, Repeat(RandomVariations)]
        public void LeftShiftOperator_RandomValues_SameAsUnderlying()
        {
            //arrange
            TUnderlying left = DynamicInvoke.ConversionOperator<TUnderlying>(Random.NextVariant<TNumeric>());
            int right = Random.NextInt32(-1, 65);

            //act
            TUnderlying underlying()
                => DynamicInvoke.LeftShiftOperator(left, right);
            TUnderlying numeric()
                => DynamicInvoke.ConversionOperator<TUnderlying>(
                    DynamicInvoke.LeftShiftOperator(
                        DynamicInvoke.ConversionOperator<TNumeric>(left),
                        right));

            //assert
            AssertSame.Outcome(underlying, numeric);
        }

        [Test, Repeat(RandomVariations)]
        public void LogicalAndOperator_RandomValues_SameAsUnderlying()
        {
            //arrange
            TUnderlying left = DynamicInvoke.ConversionOperator<TUnderlying>(Random.NextVariant<TNumeric>());
            TUnderlying right = Random.Choose(left, DynamicInvoke.ConversionOperator<TUnderlying>(Random.NextVariant<TNumeric>()));

            //act
            TUnderlying underlying()
                => DynamicInvoke.LogicalAndOperator(left, right);
            TUnderlying numeric()
                => DynamicInvoke.ConversionOperator<TUnderlying>(
                    DynamicInvoke.LogicalAndOperator(
                        DynamicInvoke.ConversionOperator<TNumeric>(left),
                        DynamicInvoke.ConversionOperator<TNumeric>(right)));

            //assert
            AssertSame.Outcome(underlying, numeric);
        }

        [Test, Repeat(RandomVariations)]
        public void LogicalExclusiveOrOperator_RandomValues_SameAsUnderlying()
        {
            //arrange
            TUnderlying left = DynamicInvoke.ConversionOperator<TUnderlying>(Random.NextVariant<TNumeric>());
            TUnderlying right = Random.Choose(left, DynamicInvoke.ConversionOperator<TUnderlying>(Random.NextVariant<TNumeric>()));

            //act
            TUnderlying underlying()
                => DynamicInvoke.LogicalExclusiveOrOperator(left, right);
            TUnderlying numeric()
                => DynamicInvoke.ConversionOperator<TUnderlying>(
                    DynamicInvoke.LogicalExclusiveOrOperator(
                        DynamicInvoke.ConversionOperator<TNumeric>(left),
                        DynamicInvoke.ConversionOperator<TNumeric>(right)));

            //assert
            AssertSame.Outcome(underlying, numeric);
        }

        [Test, Repeat(RandomVariations)]
        public void LogicalOrOperator_RandomValues_SameAsUnderlying()
        {
            //arrange
            TUnderlying left = DynamicInvoke.ConversionOperator<TUnderlying>(Random.NextVariant<TNumeric>());
            TUnderlying right = Random.Choose(left, DynamicInvoke.ConversionOperator<TUnderlying>(Random.NextVariant<TNumeric>()));

            //act
            TUnderlying underlying()
                => DynamicInvoke.LogicalOrOperator(left, right);
            TUnderlying numeric()
                => DynamicInvoke.ConversionOperator<TUnderlying>(
                    DynamicInvoke.LogicalOrOperator(
                        DynamicInvoke.ConversionOperator<TNumeric>(left),
                        DynamicInvoke.ConversionOperator<TNumeric>(right)));

            //assert
            AssertSame.Outcome(underlying, numeric);
        }

        [Test, Repeat(RandomVariations)]
        public void RightShiftOperator_RandomValues_SameAsUnderlying()
        {
            //arrange
            TUnderlying left = DynamicInvoke.ConversionOperator<TUnderlying>(Random.NextVariant<TNumeric>());
            int right = Random.NextInt32(-1, 65);

            //act
            TUnderlying underlying()
                => DynamicInvoke.RightShiftOperator(left, right);
            TUnderlying numeric()
                => DynamicInvoke.ConversionOperator<TUnderlying>(
                    DynamicInvoke.RightShiftOperator(
                        DynamicInvoke.ConversionOperator<TNumeric>(left),
                        right));

            //assert
            AssertSame.Outcome(underlying, numeric);
        }

        [Test, Repeat(RandomVariations)]
        public void ToString_RandomValues_SameAsUnderlying()
        {
            //arrange
            TUnderlying left = DynamicInvoke.ConversionOperator<TUnderlying>(Random.NextVariant<TNumeric>());

            //act
            string underlying() => left.ToString();
            string numeric() => DynamicInvoke.ConversionOperator<TNumeric>(left).ToString();

            //assert
            AssertSame.Outcome(underlying, numeric);
        }

        [Test, Repeat(RandomVariations)]
        public void GetHashCode_RandomValues_SameAsUnderlying()
        {
            //arrange
            TUnderlying left = DynamicInvoke.ConversionOperator<TUnderlying>(Random.NextVariant<TNumeric>());

            //act
            int underlying() => left.GetHashCode();
            int numeric() => DynamicInvoke.ConversionOperator<TNumeric>(left).GetHashCode();

            //assert
            AssertSame.Outcome(underlying, numeric);
        }
    }
}
