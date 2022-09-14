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
        [Test, Repeat(RandomVariations)]
        public void EqualsMethods_RandomValues_SameOutcome()
        {
            //arrange
            AARectangle<TNumeric> input1 = Random.NextVariant<AARectangle<TNumeric>>(Scenarios.LowMagnitude);
            AARectangle<TNumeric> input2 = Random.Choose(input1, Random.NextVariant<AARectangle<TNumeric>>(Scenarios.LowMagnitude));

            //act
            //assert
            AssertSame.Outcome(
                () => input1.Equals(input2),
                () => input1.Equals((object)input2),
                () => input1 == input2,
                () => !(input1 != input2));
        }

        [Test, Repeat(RandomVariations)]
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

        [Test, Repeat(RandomVariations)]
        public void Translate_RandomValue_SameAsAddingToOrigin()
        {
            //arrange
            AARectangle<TNumeric> subject = Random.NextVariant<AARectangle<TNumeric>>(Scenarios.LowMagnitude);
            Vector2N<TNumeric> delta = Random.NextVariant<Vector2N<TNumeric>>(Scenarios.LowMagnitude);

            //act
            //assert
            AssertSame.Result(
                () => subject.Translate(delta).Center,
                () => subject.Center + delta);
        }

        [Test, Repeat(RandomVariations)]
        public void Translate_RandomValue_DimensionsAreUnchanged()
        {
            //arrange
            AARectangle<TNumeric> subject = Random.NextVariant<AARectangle<TNumeric>>(Scenarios.LowMagnitude);

            //act
            //assert
            AssertSame.Result(
                () => subject.Translate(Random.NextVariant<Vector2N<TNumeric>>(Scenarios.LowMagnitude)).Dimensions,
                () => subject.Dimensions);
        }

        [Test, Repeat(RandomVariations)]
        public void Rotate_RandomValue_SameAsConstructingRectangle()
        {
            //arrange
            AARectangle<TNumeric> subject = Random.NextVariant<AARectangle<TNumeric>>(Scenarios.LowMagnitude);
            Angle<TNumeric> angle = Random.NextVariant<Angle<TNumeric>>(Scenarios.LowMagnitude);

            //act
            //assert
            AssertSame.Result(
                () => subject.Rotate(angle),
                () => new Rectangle<TNumeric>(subject.Center, subject.Dimensions, angle));
        }

        [Test, Repeat(RandomVariations)]
        public void TopMethods_RandomValue_SameResult()
        {
            //arrange
            Vector2N<TNumeric> origin = Random.NextVariant<Vector2N<TNumeric>>(Scenarios.LowMagnitude);
            Vector2N<TNumeric> dimensions = Random.NextVariant<Vector2N<TNumeric>>(Scenarios.LowMagnitude);

            //act
            //assert
            AssertSame.Result(
                () => new AARectangle<TNumeric>(origin, dimensions).GetTop(),
                () => origin.Y.Add(dimensions.Y.Half()));
        }

        [Test, Repeat(RandomVariations)]
        public void BottomMethods_RandomValue_SameResult()
        {
            //arrange
            Vector2N<TNumeric> origin = Random.NextVariant<Vector2N<TNumeric>>(Scenarios.LowMagnitude);
            Vector2N<TNumeric> dimensions = Random.NextVariant<Vector2N<TNumeric>>(Scenarios.LowMagnitude);

            //act
            //assert
            AssertSame.Result(
                () => new AARectangle<TNumeric>(origin, dimensions).GetBottom(),
                () => origin.Y.Subtract(dimensions.Y.Half()));
        }

        [Test, Repeat(RandomVariations)]
        public void LeftMethods_RandomValue_SameResult()
        {
            //arrange
            Vector2N<TNumeric> origin = Random.NextVariant<Vector2N<TNumeric>>(Scenarios.LowMagnitude);
            Vector2N<TNumeric> dimensions = Random.NextVariant<Vector2N<TNumeric>>(Scenarios.LowMagnitude);

            //act
            //assert
            AssertSame.Result(
                () => new AARectangle<TNumeric>(origin, dimensions).GetLeft(),
                () => origin.X.Subtract(dimensions.X.Half()));
        }

        [Test, Repeat(RandomVariations)]
        public void RightMethods_RandomValue_SameResult()
        {
            //arrange
            Vector2N<TNumeric> origin = Random.NextVariant<Vector2N<TNumeric>>(Scenarios.LowMagnitude);
            Vector2N<TNumeric> dimensions = Random.NextVariant<Vector2N<TNumeric>>(Scenarios.LowMagnitude);

            //act
            //assert
            AssertSame.Result(
                () => new AARectangle<TNumeric>(origin, dimensions).GetRight(),
                () => origin.X.Add(dimensions.X.Half()));
        }

        [Test, Repeat(RandomVariations)]
        public void BottomLeftMethods_RandomValue_SameResult()
        {
            //arrange
            Vector2N<TNumeric> center = Random.NextVariant<Vector2N<TNumeric>>(Scenarios.LowMagnitude);
            Vector2N<TNumeric> dimensions = Random.NextVariant<Vector2N<TNumeric>>(Scenarios.LowMagnitude);

            //act
            //assert
            AssertSame.Outcome(
                () => new AARectangle<TNumeric>(center, dimensions).GetBottomLeft(),
                () => new Rectangle<TNumeric>(center, dimensions, default).GetBottomLeft(),
                () => AARectangle.FromBottomLeft(center.Subtract(dimensions.Half()), dimensions).GetBottomLeft(),
                () => Rectangle.FromBottomLeft(center.Subtract(dimensions.Half()), dimensions, default).GetBottomLeft(),
                () => center.Subtract(dimensions.Half()));
        }

        [Test, Repeat(RandomVariations)]
        public void BottomCenterMethods_RandomValue_SameResult()
        {
            //arrange
            Vector2N<TNumeric> center = Random.NextVariant<Vector2N<TNumeric>>(Scenarios.LowMagnitude);
            Vector2N<TNumeric> dimensions = Random.NextVariant<Vector2N<TNumeric>>(Scenarios.LowMagnitude);

            //act
            //assert
            AssertSame.Outcome(
                () => new AARectangle<TNumeric>(center, dimensions).GetBottomCenter(),
                () => new Rectangle<TNumeric>(center, dimensions, default).GetBottomCenter(),
                () => AARectangle.FromBottomCenter(center.SubtractY(dimensions.Y.Half()), dimensions).GetBottomCenter(),
                () => Rectangle.FromBottomCenter(center.SubtractY(dimensions.Y.Half()), dimensions, default).GetBottomCenter(),
                () => center.SubtractY(dimensions.Y.Half()));
        }

        [Test, Repeat(RandomVariations)]
        public void BottomRightMethods_RandomValue_SameResult()
        {
            //arrange
            Vector2N<TNumeric> center = Random.NextVariant<Vector2N<TNumeric>>(Scenarios.LowMagnitude);
            Vector2N<TNumeric> dimensions = Random.NextVariant<Vector2N<TNumeric>>(Scenarios.LowMagnitude);

            //act
            //assert
            AssertSame.Outcome(
                () => new AARectangle<TNumeric>(center, dimensions).GetBottomRight(),
                () => new Rectangle<TNumeric>(center, dimensions, default).GetBottomRight(),
                () => AARectangle.FromBottomRight(center.SubtractY(dimensions.Y.Half()).AddX(dimensions.X.Half()), dimensions).GetBottomRight(),
                () => Rectangle.FromBottomRight(center.SubtractY(dimensions.Y.Half()).AddX(dimensions.X.Half()), dimensions, default).GetBottomRight(),
                () => center.SubtractY(dimensions.Y.Half()).AddX(dimensions.X.Half()));
        }

        [Test, Repeat(RandomVariations)]
        public void RightCenterMethods_RandomValue_SameResult()
        {
            //arrange
            Vector2N<TNumeric> center = Random.NextVariant<Vector2N<TNumeric>>(Scenarios.LowMagnitude);
            Vector2N<TNumeric> dimensions = Random.NextVariant<Vector2N<TNumeric>>(Scenarios.LowMagnitude);

            //act
            //assert
            AssertSame.Outcome(
                () => new AARectangle<TNumeric>(center, dimensions).GetRightCenter(),
                () => new Rectangle<TNumeric>(center, dimensions, default).GetRightCenter(),
                () => AARectangle.FromRightCenter(center.AddX(dimensions.X.Half()), dimensions).GetRightCenter(),
                () => Rectangle.FromRightCenter(center.AddX(dimensions.X.Half()), dimensions, default).GetRightCenter(),
                () => center.AddX(dimensions.X.Half()));
        }

        [Test, Repeat(RandomVariations)]
        public void TopRightMethods_RandomValue_SameResult()
        {
            //arrange
            Vector2N<TNumeric> center = Random.NextVariant<Vector2N<TNumeric>>(Scenarios.LowMagnitude);
            Vector2N<TNumeric> dimensions = Random.NextVariant<Vector2N<TNumeric>>(Scenarios.LowMagnitude);

            //act
            //assert
            AssertSame.Outcome(
                () => new AARectangle<TNumeric>(center, dimensions).GetTopRight(),
                () => new Rectangle<TNumeric>(center, dimensions, default).GetTopRight(),
                () => AARectangle.FromTopRight(center.Add(dimensions.Half()), dimensions).GetTopRight(),
                () => Rectangle.FromTopRight(center.Add(dimensions.Half()), dimensions, default).GetTopRight(),
                () => center.Add(dimensions.Half()));
        }

        [Test, Repeat(RandomVariations)]
        public void TopCenterMethods_RandomValue_SameResult()
        {
            //arrange
            Vector2N<TNumeric> center = Random.NextVariant<Vector2N<TNumeric>>(Scenarios.LowMagnitude);
            Vector2N<TNumeric> dimensions = Random.NextVariant<Vector2N<TNumeric>>(Scenarios.LowMagnitude);

            //act
            //assert
            AssertSame.Outcome(
                () => new AARectangle<TNumeric>(center, dimensions).GetTopCenter(),
                () => new Rectangle<TNumeric>(center, dimensions, default).GetTopCenter(),
                () => AARectangle.FromTopCenter(center.AddY(dimensions.Y.Half()), dimensions).GetTopCenter(),
                () => Rectangle.FromTopCenter(center.AddY(dimensions.Y.Half()), dimensions, default).GetTopCenter(),
                () => center.AddY(dimensions.Y.Half()));
        }

        [Test, Repeat(RandomVariations)]
        public void TopLeftMethods_RandomValue_SameResult()
        {
            //arrange
            Vector2N<TNumeric> center = Random.NextVariant<Vector2N<TNumeric>>(Scenarios.LowMagnitude);
            Vector2N<TNumeric> dimensions = Random.NextVariant<Vector2N<TNumeric>>(Scenarios.LowMagnitude);

            //act
            //assert
            AssertSame.Outcome(
                () => new AARectangle<TNumeric>(center, dimensions).GetTopLeft(),
                () => new Rectangle<TNumeric>(center, dimensions, default).GetTopLeft(),
                () => AARectangle.FromTopLeft(center.SubtractX(dimensions.X.Half()).AddY(dimensions.Y.Half()), dimensions).GetTopLeft(),
                () => Rectangle.FromTopLeft(center.SubtractX(dimensions.X.Half()).AddY(dimensions.Y.Half()), dimensions, default).GetTopLeft(),
                () => center.SubtractX(dimensions.X.Half()).AddY(dimensions.Y.Half()));
        }

        [Test, Repeat(RandomVariations)]
        public void LeftCenterMethods_RandomValue_SameResult()
        {
            //arrange
            Vector2N<TNumeric> center = Random.NextVariant<Vector2N<TNumeric>>(Scenarios.LowMagnitude);
            Vector2N<TNumeric> dimensions = Random.NextVariant<Vector2N<TNumeric>>(Scenarios.LowMagnitude);

            //act
            //assert
            AssertSame.Outcome(
                () => new AARectangle<TNumeric>(center, dimensions).GetLeftCenter(),
                () => new Rectangle<TNumeric>(center, dimensions, default).GetLeftCenter(),
                () => AARectangle.FromLeftCenter(center.SubtractX(dimensions.X.Half()), dimensions).GetLeftCenter(),
                () => Rectangle.FromLeftCenter(center.SubtractX(dimensions.X.Half()), dimensions, default).GetLeftCenter(),
                () => center.SubtractX(dimensions.X.Half()));
        }
    }
}
