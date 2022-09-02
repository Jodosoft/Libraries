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
using Jodo.Numerics;
using Jodo.Primitives;
using Jodo.Testing;
using NUnit.Framework;

namespace Jodo.Geometry.Tests
{
    public abstract class AARectangleTestBase<TNumeric> : GlobalFixtureBase where TNumeric : struct, INumeric<TNumeric>
    {
        [Test]
        public void EqualsMethods_RandomValues_SameOutcome()
        {
            //arrange
            AARectangle<TNumeric> input1 = Random.NextVariant<AARectangle<TNumeric>>();
            AARectangle<TNumeric> input2 = Random.Choose(input1, Random.NextVariant<AARectangle<TNumeric>>());

            //act
            //assert
            AssertSame.Outcome(
                () => input1.Equals(input2),
                () => input1.Equals((object)input2),
                () => input1 == input2,
                () => !(input1 != input2));
        }

        [Test]
        public void GetArea_RandomValues_CorrectResult()
        {
            //arrange
            AARectangle<TNumeric> subject = Random.NextVariant<AARectangle<TNumeric>>(Scenarios.LowMagnitude);
            TNumeric expected = MathN.Abs(subject.Dimensions.X.Multiply(subject.Dimensions.Y));

            //act
            TNumeric result = subject.GetArea();

            //assert
            result.Should().Be(expected);
        }

        [Test]
        public void GetLeft_RandomValues_CorrectResult()
        {
            //arrange
            AARectangle<TNumeric> subject = Random.NextVariant<AARectangle<TNumeric>>(Scenarios.LowMagnitude);
            TNumeric expected = subject.Origin.X;

            //act
            TNumeric result = subject.GetLeft();

            //assert
            result.Should().Be(expected);
        }

        [Test]
        public void Translate_RandomValue_SameAsAddingToOrigin()
        {
            //arrange
            AARectangle<TNumeric> subject = Random.NextVariant<AARectangle<TNumeric>>(Scenarios.LowMagnitude);
            Vector2N<TNumeric> delta = Random.NextVariant<Vector2N<TNumeric>>(Scenarios.LowMagnitude);

            //act
            //assert
            AssertSame.Outcome(
                () => subject.Translate(delta).Origin,
                () => subject.Origin + delta);
        }

        [Test]
        public void Translate_RandomValue_DimensionsAreUnchanged()
        {
            //arrange
            AARectangle<TNumeric> subject = Random.NextVariant<AARectangle<TNumeric>>(Scenarios.LowMagnitude);

            //act
            //assert
            AssertSame.Outcome(
                () => subject.Translate(Random.NextVariant<Vector2N<TNumeric>>()).Dimensions,
                () => subject.Dimensions);
        }

        [Test]
        public void Rotate_RandomValue_SameAsConstructingRectangle()
        {
            //arrange
            AARectangle<TNumeric> subject = Random.NextVariant<AARectangle<TNumeric>>(Scenarios.LowMagnitude);
            Angle<TNumeric> angle = Random.NextVariant<Angle<TNumeric>>(Scenarios.LowMagnitude);

            //act
            //assert
            AssertSame.Outcome(
                () => subject.Rotate(angle),
                () => new Rectangle<TNumeric>(subject.Origin, subject.Dimensions, angle));
        }
    }
}
