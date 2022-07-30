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
using Jodo.Testing;
using NUnit.Framework;

namespace Jodo.Numerics.Tests
{
    public static class NumericOperatorTests
    {
        public abstract class General<TNumeric> : GlobalFixtureBase where TNumeric : struct, INumeric<TNumeric>
        {
#if NET5_0_OR_GREATER

            [Test, Repeat(RandomVariations)]
            public void Add_RandomValues_SameAsNamedMethod()
            {
                //arrange
                TNumeric left = Random.NextNumeric<TNumeric>();
                TNumeric right = Random.NextNumeric<TNumeric>();

                //act
                //assert
                Same.Outcome(() => left + right, () => left.Add(right));
            }

            [Test, Repeat(RandomVariations)]
            public void BitwiseComplement_RandomValue_SameAsNamedMethod()
            {
                //arrange
                TNumeric left = Random.NextNumeric<TNumeric>();

                //act
                //assert
                Same.Outcome(() => ~left, () => left.BitwiseComplement());
            }

            [Test, Repeat(RandomVariations)]
            public void Divide_RandomValues_SameAsNamedMethod()
            {
                //arrange
                TNumeric left = Random.NextNumeric<TNumeric>();
                TNumeric right = Random.NextNumeric<TNumeric>();

                //act
                //assert
                Same.Outcome(() => left / right, () => left.Divide(right));
            }

            [Test, Repeat(RandomVariations)]
            public void GreaterThan_RandomValues_SameAsNamedMethod()
            {
                //arrange
                TNumeric left = Random.NextNumeric<TNumeric>();
                TNumeric right = Random.NextNumeric<TNumeric>();

                //act
                //assert
                Same.Outcome(() => left > right, () => left.IsGreaterThan(right));
            }

            [Test, Repeat(RandomVariations)]
            public void GreaterThanOrEqualTo_RandomValues_SameAsNamedMethod()
            {
                //arrange
                TNumeric left = Random.NextNumeric<TNumeric>();
                TNumeric right = Random.NextNumeric<TNumeric>();

                //act
                //assert
                Same.Outcome(() => left >= right, () => left.IsGreaterThanOrEqualTo(right));
            }

            [Test, Repeat(RandomVariations)]
            public void IsLessThan_RandomValues_SameAsNamedMethod()
            {
                //arrange
                TNumeric left = Random.NextNumeric<TNumeric>();
                TNumeric right = Random.NextNumeric<TNumeric>();

                //act
                //assert
                Same.Outcome(() => left < right, () => left.IsLessThan(right));
            }

            [Test, Repeat(RandomVariations)]
            public void IsLessThanOrEqualTo_RandomValues_SameAsNamedMethod()
            {
                //arrange
                TNumeric left = Random.NextNumeric<TNumeric>();
                TNumeric right = Random.NextNumeric<TNumeric>();

                //act
                //assert
                Same.Outcome(() => left <= right, () => left.IsLessThanOrEqualTo(right));
            }

            [Test, Repeat(RandomVariations)]
            public void LeftShift_RandomValues_SameAsNamedMethod()
            {
                //arrange
                TNumeric left = Random.NextNumeric<TNumeric>();
                int right = Random.Next(-1, 100);

                //act
                //assert
                Same.Outcome(() => left << right, () => left.LeftShift(right));
            }

            [Test, Repeat(RandomVariations)]
            public void LogicalAnd_RandomValues_SameAsNamedMethod()
            {
                //arrange
                TNumeric left = Random.NextNumeric<TNumeric>();
                TNumeric right = Random.NextNumeric<TNumeric>();

                //act
                //assert
                Same.Outcome(() => left & right, () => left.LogicalAnd(right));
            }

            [Test, Repeat(RandomVariations)]
            public void LogicalExclusiveOr_RandomValues_SameAsNamedMethod()
            {
                //arrange
                TNumeric left = Random.NextNumeric<TNumeric>();
                TNumeric right = Random.NextNumeric<TNumeric>();

                //act
                //assert
                Same.Outcome(() => left ^ right, () => left.LogicalExclusiveOr(right));
            }

            [Test, Repeat(RandomVariations)]
            public void LogicalOr_RandomValues_SameAsNamedMethod()
            {
                //arrange
                TNumeric left = Random.NextNumeric<TNumeric>();
                TNumeric right = Random.NextNumeric<TNumeric>();

                //act
                //assert
                Same.Outcome(() => left | right, () => left.LogicalOr(right));
            }

            [Test, Repeat(RandomVariations)]
            public void Multiply_RandomValues_SameAsNamedMethod()
            {
                //arrange
                TNumeric left = Random.NextNumeric<TNumeric>();
                TNumeric right = Random.NextNumeric<TNumeric>();

                //act
                //assert
                Same.Outcome(() => left * right, () => left.Multiply(right));
            }

            [Test, Repeat(RandomVariations)]
            public void Negative_RandomValue_SameAsNamedMethod()
            {
                //arrange
                TNumeric left = Random.NextNumeric<TNumeric>();

                //act
                //assert
                Same.Outcome(() => -left, () => left.Negative());
            }

            [Test, Repeat(RandomVariations)]
            public void Positive_RandomValue_SameAsNamedMethod()
            {
                //arrange
                TNumeric left = Random.NextNumeric<TNumeric>();

                //act
                //assert
                Same.Outcome(() => +left, () => left.Positive());
            }

            [Test, Repeat(RandomVariations)]
            public void Remainder_RandomValues_SameAsNamedMethod()
            {
                //arrange
                TNumeric left = Random.NextNumeric<TNumeric>();
                TNumeric right = Random.NextNumeric<TNumeric>();

                //act
                //assert
                Same.Outcome(() => left % right, () => left.Remainder(right));
            }

            [Test, Repeat(RandomVariations)]
            public void RightShift_RandomValues_SameAsNamedMethod()
            {
                //arrange
                TNumeric left = Random.NextNumeric<TNumeric>();
                int right = Random.Next(-1, 100);

                //act
                //assert
                Same.Outcome(() => left >> right, () => left.RightShift(right));
            }

            [Test, Repeat(RandomVariations)]
            public void Subtract_RandomValues_SameAsNamedMethod()
            {
                //arrange
                TNumeric left = Random.NextNumeric<TNumeric>();
                TNumeric right = Random.NextNumeric<TNumeric>();

                //act
                //assert
                Same.Outcome(() => left - right, () => left.Subtract(right));
            }
#endif
        }
    }
}
