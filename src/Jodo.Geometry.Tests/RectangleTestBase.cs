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

using Jodo.Numerics;
using Jodo.Primitives;
using Jodo.Testing;
using NUnit.Framework;

namespace Jodo.Geometry.Tests
{
    public abstract class RectangleTestBase<TNumeric> : GlobalFixtureBase where TNumeric : struct, INumeric<TNumeric>
    {
        [Test, Repeat(RandomVariations)]
        public void EqualsMethods_RandomValues_SameOutcome()
        {
            //arrange
            Rectangle<TNumeric> input1 = Random.NextVariant<Rectangle<TNumeric>>();
            Rectangle<TNumeric> input2 = Random.Choose(input1, Random.NextVariant<Rectangle<TNumeric>>());

            //act
            //assert
            AssertSame.Outcome(
                () => input1.Equals(input2),
                () => input1.Equals((object)input2),
                () => input1 == input2,
                () => !(input1 != input2));
        }

        [Test, Repeat(RandomVariations)]
        public void Width_RandomValue_SameAsDimensionsX()
        {
            //arrange
            Rectangle<TNumeric> subject = Random.NextVariant<Rectangle<TNumeric>>(Scenarios.AnyMagnitude);
            TNumeric expected = subject.Dimensions.X;

            //act
            TNumeric result = subject.Width;

            //assert
            AssertSame.Result(() => expected, () => result);
        }

        [Test, Repeat(RandomVariations)]
        public void Height_RandomValue_SameAsDimensionsY()
        {
            //arrange
            Rectangle<TNumeric> subject = Random.NextVariant<Rectangle<TNumeric>>(Scenarios.AnyMagnitude);
            TNumeric expected = subject.Dimensions.Y;

            //act
            TNumeric result = subject.Height;

            //assert
            AssertSame.Result(() => expected, () => result);
        }

        [Test, Repeat(RandomVariations)]
        public void Area_RandomValue_SameAsWidthTimesHeight()
        {
            //arrange
            Rectangle<TNumeric> subject = Random.NextVariant<Rectangle<TNumeric>>(Scenarios.LowMagnitude);
            TNumeric expected = subject.Width.Multiply(subject.Height);

            //act
            TNumeric result = subject.GetArea();

            //assert
            AssertSame.Result(() => expected, () => result);
        }

        [Test, Repeat(RandomVariations)]
        public void Translate_RandomValue_SameAsAddingToOrigin()
        {
            //arrange
            Rectangle<TNumeric> subject = Random.NextVariant<Rectangle<TNumeric>>(Scenarios.LowMagnitude);
            Vector2N<TNumeric> delta = Random.NextVariant<Vector2N<TNumeric>>(Scenarios.LowMagnitude);

            //act
            //assert
            AssertSame.Outcome(
                () => subject.Translate(delta).Origin,
                () => subject.Origin + delta);
        }

        [Test, Repeat(RandomVariations)]
        public void Translate_RandomValue_DimensionsAreUnchanged()
        {
            //arrange
            Rectangle<TNumeric> subject = Random.NextVariant<Rectangle<TNumeric>>(Scenarios.LowMagnitude);

            //act
            //assert
            AssertSame.Outcome(
                () => subject.Translate(Random.NextVariant<Vector2N<TNumeric>>()).Dimensions,
                () => subject.Dimensions);
        }

        [Test, Repeat(RandomVariations)]
        public void Translate_RandomValue_AngleIsUnchanged()
        {
            //arrange
            Rectangle<TNumeric> subject = Random.NextVariant<Rectangle<TNumeric>>(Scenarios.LowMagnitude);

            //act
            //assert
            AssertSame.Outcome(
                () => subject.Translate(Random.NextVariant<Vector2N<TNumeric>>()).Angle,
                () => subject.Angle);
        }
    }
}
