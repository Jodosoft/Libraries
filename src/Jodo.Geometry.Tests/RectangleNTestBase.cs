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
    public abstract class RectangleNTestBase<TNumeric> : GlobalFixtureBase where TNumeric : struct, INumeric<TNumeric>
    {
        [Test, Repeat(RandomVariations)]
        public void FromCenter_RandomInputs_CorrectResult()
        {
            //arrange#
            Vector2N<TNumeric> center = Random.NextVariant<Vector2N<TNumeric>>(Variants.NonError);
            Vector2N<TNumeric> dimensions = Random.NextVariant<Vector2N<TNumeric>>(Variants.NonError);
            AngleN<TNumeric> angle = Random.NextVariant<AngleN<TNumeric>>(Variants.NonError);

            //act
            RectangleN<TNumeric> result = RectangleN.FromCenter(center, dimensions, angle);

            //assert
            result.Center.Should().Be(center);
            result.Dimensions.Should().Be(dimensions);
            result.Angle.Should().Be(angle);
        }

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
                () => subject.Translate(Random.NextVariant<Vector2N<TNumeric>>()).Angle,
                () => subject.Angle);
        }

        [Test, Repeat(RandomVariations)]
        public void ImplicitFromAARectangle_RandomValue_CorrectProperties()
        {
            //arrange
            AARectangleN<TNumeric> subject = Random.NextVariant<AARectangleN<TNumeric>>(Variants.LowMagnitude);

            //act
            RectangleN<TNumeric> result = subject;

            //assert
            result.Center.Should().Be(subject.Center);
            result.Dimensions.Should().Be(subject.Dimensions);
            result.Angle.Should().Be(AngleN.Zero<TNumeric>());
        }

        [Test, Repeat(RandomVariations)]
        public void Grow1_RandomValue_CorrectResult()
        {
            //arrange
            RectangleN<TNumeric> subject = Random.NextVariant<RectangleN<TNumeric>>(Variants.LowMagnitude);
            TNumeric input = Random.NextVariant<TNumeric>(Variants.LowMagnitude);

            //act
            RectangleN<TNumeric> result = subject.Grow(input);

            //assert
            result.Center.Should().Be(subject.Center);
            result.Angle.Should().Be(subject.Angle);
            result.Dimensions.Should().Be(subject.Dimensions.AddX(input).AddY(input));
        }

        [Test, Repeat(RandomVariations)]
        public void Grow2_RandomValue_CorrectResult()
        {
            //arrange
            RectangleN<TNumeric> subject = Random.NextVariant<RectangleN<TNumeric>>(Variants.LowMagnitude);
            Vector2N<TNumeric> input = Random.NextVariant<Vector2N<TNumeric>>(Variants.LowMagnitude);

            //act
            RectangleN<TNumeric> result = subject.Grow(input);

            //assert
            result.Center.Should().Be(subject.Center);
            result.Angle.Should().Be(subject.Angle);
            result.Dimensions.Should().Be(subject.Dimensions.Add(input));
        }

        [Test, Repeat(RandomVariations)]
        public void Grow3_RandomValue_CorrectResult()
        {
            //arrange
            RectangleN<TNumeric> subject = Random.NextVariant<RectangleN<TNumeric>>(Variants.LowMagnitude);
            Vector2N<TNumeric> input = Random.NextVariant<Vector2N<TNumeric>>(Variants.LowMagnitude);

            //act
            RectangleN<TNumeric> result = subject.Grow(input.X, input.Y);

            //assert
            result.Center.Should().Be(subject.Center);
            result.Angle.Should().Be(subject.Angle);
            result.Dimensions.Should().Be(subject.Dimensions.Add(input));
        }

        [Test, Repeat(RandomVariations)]
        public void Shrink1_RandomValue_CorrectResult()
        {
            //arrange
            RectangleN<TNumeric> subject = Random.NextVariant<RectangleN<TNumeric>>(Variants.LowMagnitude);
            TNumeric input = Random.NextVariant<TNumeric>(Variants.LowMagnitude);

            //act
            RectangleN<TNumeric> result = subject.Shrink(input);

            //assert
            result.Center.Should().Be(subject.Center);
            result.Angle.Should().Be(subject.Angle);
            result.Dimensions.Should().Be(subject.Dimensions.SubtractX(input).SubtractY(input));
        }

        [Test, Repeat(RandomVariations)]
        public void Shrink2_RandomValue_CorrectResult()
        {
            //arrange
            RectangleN<TNumeric> subject = Random.NextVariant<RectangleN<TNumeric>>(Variants.LowMagnitude);
            Vector2N<TNumeric> input = Random.NextVariant<Vector2N<TNumeric>>(Variants.LowMagnitude);

            //act
            RectangleN<TNumeric> result = subject.Shrink(input);

            //assert
            result.Center.Should().Be(subject.Center);
            result.Angle.Should().Be(subject.Angle);
            result.Dimensions.Should().Be(subject.Dimensions.Subtract(input));
        }

        [Test, Repeat(RandomVariations)]
        public void Shrink3_RandomValue_CorrectResult()
        {
            //arrange
            RectangleN<TNumeric> subject = Random.NextVariant<RectangleN<TNumeric>>(Variants.LowMagnitude);
            Vector2N<TNumeric> input = Random.NextVariant<Vector2N<TNumeric>>(Variants.LowMagnitude);

            //act
            RectangleN<TNumeric> result = subject.Shrink(input.X, input.Y);

            //assert
            result.Center.Should().Be(subject.Center);
            result.Angle.Should().Be(subject.Angle);
            result.Dimensions.Should().Be(subject.Dimensions.Subtract(input));
        }

        [Test, Repeat(RandomVariations)]
        public void Rotate1_RandomValue_CorrectResult()
        {
            //arrange
            RectangleN<TNumeric> subject = Random.NextVariant<RectangleN<TNumeric>>(Variants.LowMagnitude);
            AngleN<TNumeric> input = Random.NextVariant<AngleN<TNumeric>>(Variants.LowMagnitude);

            //act
            RectangleN<TNumeric> result = subject.Rotate(input);

            //assert
            result.Center.Should().Be(subject.Center);
            result.Dimensions.Should().Be(subject.Dimensions);
            result.Angle.Should().Be(AngleN.FromDegrees(subject.Angle.Degrees.Add(input.Degrees)));
        }

        [Test, Repeat(RandomVariations)]
        public void Scale_RandomValue_CorrectResult()
        {
            //arrange
            RectangleN<TNumeric> subject = Random.NextVariant<RectangleN<TNumeric>>(Variants.LowMagnitude);
            TNumeric input = Random.NextVariant<TNumeric>(Variants.LowMagnitude);

            //act
            RectangleN<TNumeric> result = subject.Scale(input);

            //assert
            result.Center.Should().Be(subject.Center);
            result.Angle.Should().Be(subject.Angle);
            result.Dimensions.Should().Be(subject.Dimensions * input);
        }
    }
}
