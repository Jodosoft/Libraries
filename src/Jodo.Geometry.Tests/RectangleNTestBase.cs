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
    public abstract class RectangleNTestBase<TNumeric> : GlobalFixtureBase where TNumeric : struct, INumeric<TNumeric>
    {
        [Test, Repeat(RandomVariations)]
        public void EqualsMethods_RandomValues_SameOutcome()
        {
            //arrange
            RectangleN<TNumeric> input1 = Random.NextVariant<RectangleN<TNumeric>>();
            RectangleN<TNumeric> input2 = Random.Choose(input1, Random.NextVariant<RectangleN<TNumeric>>());

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
            RectangleN<TNumeric> subject = Random.NextVariant<RectangleN<TNumeric>>(Variants.AnyMagnitude);
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
            RectangleN<TNumeric> subject = Random.NextVariant<RectangleN<TNumeric>>(Variants.AnyMagnitude);
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
            RectangleN<TNumeric> subject = Random.NextVariant<RectangleN<TNumeric>>(Variants.LowMagnitude);
            TNumeric expected = MathN.Abs(subject.Width.Multiply(subject.Height));

            //act
            TNumeric result = subject.GetArea();

            //assert
            AssertSame.Result(() => expected, () => result);
        }

        [Test, Repeat(RandomVariations)]
        public void Translate_RandomValue_SameAsAddingToOrigin()
        {
            //arrange
            RectangleN<TNumeric> subject = Random.NextVariant<RectangleN<TNumeric>>(Variants.LowMagnitude);
            Vector2N<TNumeric> delta = Random.NextVariant<Vector2N<TNumeric>>(Variants.LowMagnitude);

            //act
            //assert
            AssertSame.Outcome(
                () => subject.Translate(delta).Center,
                () => subject.Center + delta);
        }

        [Test, Repeat(RandomVariations)]
        public void Translate_RandomValue_DimensionsAreUnchanged()
        {
            //arrange
            RectangleN<TNumeric> subject = Random.NextVariant<RectangleN<TNumeric>>(Variants.LowMagnitude);

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
            RectangleN<TNumeric> subject = Random.NextVariant<RectangleN<TNumeric>>(Variants.LowMagnitude);

            //act
            //assert
            AssertSame.Outcome(
                () => subject.Translate(Random.NextVariant<Vector2N<TNumeric>>()).AngleN,
                () => subject.AngleN);
        }
    }
}
