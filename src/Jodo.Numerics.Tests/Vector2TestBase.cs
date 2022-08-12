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
using Jodo.Primitives;
using Jodo.Testing;
using NUnit.Framework;

namespace Jodo.Numerics.Tests
{
    public abstract class Vector2TestBase<TNumeric> : AssemblyFixtureBase where TNumeric : struct, INumeric<TNumeric>
    {

        [Test, Repeat(RandomVariations)]
        public void Ctor_RandomValues_CorrectResult()
        {
            //arrange
            TNumeric x = Random.NextNumeric<TNumeric>();
            TNumeric y = Random.NextNumeric<TNumeric>();

            //act
            Vector2<TNumeric> result = new Vector2<TNumeric>(x, y);

            //assert
            result.X.Should().Be(x);
            result.Y.Should().Be(y);
        }

        [Test, Repeat(RandomVariations)]
        public void Random_WithinBounds_CorrectResult()
        {
            //arrange
            Vector2<TNumeric> bound1 = Random.NextRandomizable<Vector2<TNumeric>>();
            Vector2<TNumeric> bound2 = Random.NextRandomizable<Vector2<TNumeric>>();

            //act
            Vector2<TNumeric> result = Random.NextRandomizable(bound1, bound2);

            //assert
            result.X.Should().BeInRange(MathN.Min(bound1.X, bound2.X), MathN.Max(bound1.X, bound2.X));
            result.Y.Should().BeInRange(MathN.Min(bound1.Y, bound2.Y), MathN.Max(bound1.Y, bound2.Y));
        }

        [Test, Repeat(RandomVariations)]
        public void Dot_RandomValues_CorrectResult()
        {
            //arrange
            Vector2<TNumeric> input1 = Random.NextVector2<TNumeric>(TestBounds.HighMagnitude | TestBounds.LowSignificance);
            Vector2<TNumeric> input2 = Random.NextVector2<TNumeric>(TestBounds.HighMagnitude | TestBounds.LowSignificance);

            //act
            //assert
            Same.Outcome(
                () => input1.X.Multiply(input2.X).Add(input1.Y.Multiply(input2.Y)),
                () => VectorN.Dot(input1, input2));
        }

        [Test, Repeat(RandomVariations)]
        public void Multiply1_RandomValues_CorrectResult()
        {
            //arrange
            Vector2<TNumeric> input1 = Random.NextVector2<TNumeric>(TestBounds.Positive | TestBounds.HighMagnitude);
            Vector2<TNumeric> input2 = Random.NextVector2<TNumeric>();

            //act
            //assert
            Same.Outcome(
                () => new Vector2<TNumeric>(input1.X.Multiply(input2.X), input1.Y.Multiply(input2.Y)),
                () => VectorN.Multiply(input1, input2));
        }

        [Test, Repeat(RandomVariations)]
        public void Multiply2_RandomValues_CorrectResult()
        {
            //arrange
            Vector2<TNumeric> input1 = Random.NextVector2<TNumeric>();
            TNumeric input2 = Random.NextNumeric<TNumeric>();

            //act
            //assert
            Same.Outcome(
                () => new Vector2<TNumeric>(input1.X.Multiply(input2), input1.Y.Multiply(input2)),
                () => VectorN.Multiply(input1, input2));
        }

        [Test, Repeat(RandomVariations)]
        public void Multiply3_RandomValues_CorrectResult()
        {
            //arrange
            TNumeric input1 = Random.NextNumeric<TNumeric>();
            Vector2<TNumeric> input2 = Random.NextVector2<TNumeric>();

            //act
            //assert
            Same.Outcome(
                () => new Vector2<TNumeric>(input1.Multiply(input2.X), input1.Multiply(input2.Y)),
                () => VectorN.Multiply(input1, input2));
        }

        [Test, Repeat(RandomVariations)]
        public void Add_RandomValues_CorrectResult()
        {
            //arrange
            Vector2<TNumeric> input1 = Random.NextVector2<TNumeric>();
            Vector2<TNumeric> input2 = Random.NextVector2<TNumeric>();

            //act
            //assert
            Same.Outcome(
                () => new Vector2<TNumeric>(input1.X.Add(input2.X), input1.Y.Add(input2.Y)),
                () => VectorN.Add(input1, input2));
        }

        [Test, Repeat(RandomVariations)]
        public void Subtract_RandomValues_CorrectResult()
        {
            //arrange
            Vector2<TNumeric> input1 = Random.NextVector2<TNumeric>();
            Vector2<TNumeric> input2 = Random.NextVector2<TNumeric>();

            //act
            //assert
            Same.Outcome(
                () => new Vector2<TNumeric>(input1.X.Subtract(input2.X), input1.Y.Subtract(input2.Y)),
                () => VectorN.Subtract(input1, input2));
        }

        [Test, Repeat(RandomVariations)]
        public void Divide1_RandomValues_CorrectResult()
        {
            //arrange
            Vector2<TNumeric> input1 = Random.NextVector2<TNumeric>();
            Vector2<TNumeric> input2 = Random.NextVector2<TNumeric>(TestBounds.HighMagnitude);

            //act
            //assert
            Same.Outcome(
                () => new Vector2<TNumeric>(input1.X.Divide(input2.X), input1.Y.Divide(input2.Y)),
                () => VectorN.Divide(input1, input2));
        }

        [Test, Repeat(RandomVariations)]
        public void Divide2_RandomValues_CorrectResult()
        {
            //arrange
            Vector2<TNumeric> input1 = Random.NextVector2<TNumeric>();
            TNumeric input2 = Random.NextNumeric<TNumeric>(TestBounds.HighMagnitude);

            //act
            //assert
            Same.Outcome(
                () => new Vector2<TNumeric>(input1.X.Divide(input2), input1.Y.Divide(input2)),
                () => VectorN.Divide(input1, input2));
        }

        [Test, Repeat(RandomVariations)]
        public void SquareRoot_RandomValues_CorrectResult()
        {
            //arrange
            Vector2<TNumeric> input = Random.NextVector2<TNumeric>(TestBounds.Positive | TestBounds.HighMagnitude);

            //act
            //assert
            Same.Outcome(
                () => new Vector2<TNumeric>(MathN.Sqrt(input.X), MathN.Sqrt(input.Y)),
                () => VectorN.SquareRoot(input));
        }

        [Test, Repeat(RandomVariations)]
        public void Negate_RandomValues_CorrectResult()
        {
            //arrange
            Vector2<TNumeric> input = Random.NextVector2<TNumeric>();

            //act
            //assert
            Same.Outcome(
                () => new Vector2<TNumeric>(input.X.Negative(), input.Y.Negative()),
                () => VectorN.Negate(input));
        }

        [Test, Repeat(RandomVariations)]
        public void Max_RandomValues_CorrectResult()
        {
            //arrange
            Vector2<TNumeric> input1 = Random.NextVector2<TNumeric>();
            Vector2<TNumeric> input2 = Random.NextVector2<TNumeric>();

            //act
            //assert
            Same.Outcome(
                () => new Vector2<TNumeric>(MathN.Max(input1.X, input2.X), MathN.Max(input1.Y, input2.Y)),
                () => VectorN.Max(input1, input2));
        }

        [Test, Repeat(RandomVariations)]
        public void Min_RandomValues_CorrectResult()
        {
            //arrange
            Vector2<TNumeric> input1 = Random.NextVector2<TNumeric>();
            Vector2<TNumeric> input2 = Random.NextVector2<TNumeric>();

            //act
            //assert
            Same.Outcome(
                () => new Vector2<TNumeric>(MathN.Min(input1.X, input2.X), MathN.Min(input1.Y, input2.Y)),
                () => VectorN.Min(input1, input2));
        }
    }
}
