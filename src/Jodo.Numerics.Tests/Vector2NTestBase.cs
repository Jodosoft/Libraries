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
    public abstract class Vector2NTestBase<TNumeric> : GlobalFixtureBase where TNumeric : struct, INumeric<TNumeric>
    {
        [Test, Repeat(RandomVariations)]
        public void Ctor_RandomValues_CorrectResult()
        {
            //arrange
            TNumeric x = Random.NextNumeric<TNumeric>(Generation.Extended);
            TNumeric y = Random.NextNumeric<TNumeric>(Generation.Extended);

            //act
            Vector2N<TNumeric> result = new Vector2N<TNumeric>(x, y);

            //assert
            result.X.Should().Be(x);
            result.Y.Should().Be(y);
        }

        [Test, Repeat(RandomVariations)]
        public void Dot_RandomValues_CorrectResult()
        {
            //arrange
            Vector2N<TNumeric> input1 = Random.NextVector2<TNumeric>(TestBounds.HighMagnitude | TestBounds.LowSignificance);
            Vector2N<TNumeric> input2 = Random.NextVector2<TNumeric>(TestBounds.HighMagnitude | TestBounds.LowSignificance);

            //act
            //assert
            AssertSame.Outcome(
                () => input1.X.Multiply(input2.X).Add(input1.Y.Multiply(input2.Y)),
                () => Vector2N.Dot(input1, input2));
        }

        [Test, Repeat(RandomVariations)]
        public void Multiply1_RandomValues_CorrectResult()
        {
            //arrange
            Vector2N<TNumeric> input1 = Random.NextVector2<TNumeric>(TestBounds.Positive | TestBounds.HighMagnitude);
            Vector2N<TNumeric> input2 = Random.NextVector2<TNumeric>();

            //act
            //assert
            AssertSame.Outcome(
                () => new Vector2N<TNumeric>(input1.X.Multiply(input2.X), input1.Y.Multiply(input2.Y)),
                () => Vector2N.Multiply(input1, input2));
        }

        [Test, Repeat(RandomVariations)]
        public void Multiply2_RandomValues_CorrectResult()
        {
            //arrange
            Vector2N<TNumeric> input1 = Random.NextVector2<TNumeric>();
            TNumeric input2 = Random.NextNumeric<TNumeric>(Generation.Extended);

            //act
            //assert
            AssertSame.Outcome(
                () => new Vector2N<TNumeric>(input1.X.Multiply(input2), input1.Y.Multiply(input2)),
                () => Vector2N.Multiply(input1, input2));
        }

        [Test, Repeat(RandomVariations)]
        public void Multiply3_RandomValues_CorrectResult()
        {
            //arrange
            TNumeric input1 = Random.NextNumeric<TNumeric>(Generation.Extended);
            Vector2N<TNumeric> input2 = Random.NextVector2<TNumeric>();

            //act
            //assert
            AssertSame.Outcome(
                () => new Vector2N<TNumeric>(input1.Multiply(input2.X), input1.Multiply(input2.Y)),
                () => Vector2N.Multiply(input1, input2));
        }

        [Test, Repeat(RandomVariations)]
        public void Add_RandomValues_CorrectResult()
        {
            //arrange
            Vector2N<TNumeric> input1 = Random.NextVector2<TNumeric>();
            Vector2N<TNumeric> input2 = Random.NextVector2<TNumeric>();

            //act
            //assert
            AssertSame.Outcome(
                () => new Vector2N<TNumeric>(input1.X.Add(input2.X), input1.Y.Add(input2.Y)),
                () => Vector2N.Add(input1, input2));
        }

        [Test, Repeat(RandomVariations)]
        public void Subtract_RandomValues_CorrectResult()
        {
            //arrange
            Vector2N<TNumeric> input1 = Random.NextVector2<TNumeric>();
            Vector2N<TNumeric> input2 = Random.NextVector2<TNumeric>();

            //act
            //assert
            AssertSame.Outcome(
                () => new Vector2N<TNumeric>(input1.X.Subtract(input2.X), input1.Y.Subtract(input2.Y)),
                () => Vector2N.Subtract(input1, input2));
        }

        [Test, Repeat(RandomVariations)]
        public void Divide1_RandomValues_CorrectResult()
        {
            //arrange
            Vector2N<TNumeric> input1 = Random.NextVector2<TNumeric>();
            Vector2N<TNumeric> input2 = Random.NextVector2<TNumeric>(TestBounds.HighMagnitude);

            //act
            //assert
            AssertSame.Outcome(
                () => new Vector2N<TNumeric>(input1.X.Divide(input2.X), input1.Y.Divide(input2.Y)),
                () => Vector2N.Divide(input1, input2));
        }

        [Test, Repeat(RandomVariations)]
        public void Divide2_RandomValues_CorrectResult()
        {
            //arrange
            Vector2N<TNumeric> input1 = Random.NextVector2<TNumeric>();
            TNumeric input2 = Random.NextNumeric<TNumeric>(TestBounds.HighMagnitude);

            //act
            //assert
            AssertSame.Outcome(
                () => new Vector2N<TNumeric>(input1.X.Divide(input2), input1.Y.Divide(input2)),
                () => Vector2N.Divide(input1, input2));
        }

        [Test, Repeat(RandomVariations)]
        public void SquareRoot_RandomValues_CorrectResult()
        {
            //arrange
            Vector2N<TNumeric> input = Random.NextVector2<TNumeric>(TestBounds.Positive | TestBounds.HighMagnitude);

            //act
            //assert
            AssertSame.Outcome(
                () => new Vector2N<TNumeric>(MathN.Sqrt(input.X), MathN.Sqrt(input.Y)),
                () => Vector2N.SquareRoot(input));
        }

        [Test, Repeat(RandomVariations)]
        public void Negate_RandomValues_CorrectResult()
        {
            //arrange
            Vector2N<TNumeric> input = Random.NextVector2<TNumeric>();

            //act
            //assert
            AssertSame.Outcome(
                () => new Vector2N<TNumeric>(input.X.Negative(), input.Y.Negative()),
                () => Vector2N.Negate(input));
        }

        [Test, Repeat(RandomVariations)]
        public void Max_RandomValues_CorrectResult()
        {
            //arrange
            Vector2N<TNumeric> input1 = Random.NextVector2<TNumeric>();
            Vector2N<TNumeric> input2 = Random.NextVector2<TNumeric>();

            //act
            //assert
            AssertSame.Outcome(
                () => new Vector2N<TNumeric>(MathN.Max(input1.X, input2.X), MathN.Max(input1.Y, input2.Y)),
                () => Vector2N.Max(input1, input2));
        }

        [Test, Repeat(RandomVariations)]
        public void Min_RandomValues_CorrectResult()
        {
            //arrange
            Vector2N<TNumeric> input1 = Random.NextVector2<TNumeric>();
            Vector2N<TNumeric> input2 = Random.NextVector2<TNumeric>();

            //act
            //assert
            AssertSame.Outcome(
                () => new Vector2N<TNumeric>(MathN.Min(input1.X, input2.X), MathN.Min(input1.Y, input2.Y)),
                () => Vector2N.Min(input1, input2));
        }

        [Test, Repeat(RandomVariations)]
        public void Round1_RandomValues_SameResultAsRoundingComponents()
        {
            //arrange
            Vector2N<TNumeric> input = Random.NextVariant<Vector2N<TNumeric>>(Variants.LowMagnitude);
            Vector2N<TNumeric> expected = new Vector2N<TNumeric>(
                MathN.Round(input.X),
                MathN.Round(input.Y));

            //act
            Vector2N<TNumeric> result = Vector2N.Round(input);

            //assert
            result.Should().Be(expected);
        }

        [Test, Repeat(RandomVariations)]
        public void Round2_RandomValues_SameResultAsRoundingComponents()
        {
            //arrange
            Vector2N<TNumeric> input = Random.NextVariant<Vector2N<TNumeric>>(Variants.LowMagnitude);
            int digits = Random.Next(0, 5);
            Vector2N<TNumeric> expected = new Vector2N<TNumeric>(
                MathN.Round(input.X, digits),
                MathN.Round(input.Y, digits));

            //act
            Vector2N<TNumeric> result = Vector2N.Round(input, digits);

            //assert
            result.Should().Be(expected);
        }

        [Test, Repeat(RandomVariations)]
        public void Round3_RandomValues_SameResultAsRoundingComponents()
        {
            //arrange
            Vector2N<TNumeric> input = Random.NextVariant<Vector2N<TNumeric>>(Variants.LowMagnitude);
            int digits = Random.Next(0, 5);
            MidpointRounding mode = Random.NextEnum<MidpointRounding>();
            Vector2N<TNumeric> expected = new Vector2N<TNumeric>(
                MathN.Round(input.X, digits, mode),
                MathN.Round(input.Y, digits, mode));

            //act
            Vector2N<TNumeric> result = Vector2N.Round(input, digits, mode);

            //assert
            result.Should().Be(expected);
        }

        [Test, Repeat(RandomVariations)]
        public void Round4_RandomValues_SameResultAsRoundingComponents()
        {
            //arrange
            Vector2N<TNumeric> input = Random.NextVariant<Vector2N<TNumeric>>(Variants.LowMagnitude);
            MidpointRounding mode = Random.NextEnum<MidpointRounding>();
            Vector2N<TNumeric> expected = new Vector2N<TNumeric>(
                MathN.Round(input.X, mode),
                MathN.Round(input.Y, mode));

            //act
            Vector2N<TNumeric> result = Vector2N.Round(input, mode);

            //assert
            result.Should().Be(expected);
        }
    }
}
