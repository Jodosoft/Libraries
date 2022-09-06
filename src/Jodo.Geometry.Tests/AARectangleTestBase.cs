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
        public void GetLeft_RandomValues_CorrectResult()
        {
            //arrange
            AARectangle<TNumeric> subject = Random.NextVariant<AARectangle<TNumeric>>(Scenarios.LowMagnitude);
            TNumeric expected = subject.Center.X;

            //act
            TNumeric result = subject.GetLeft();

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
                () => subject.Translate(Random.NextVariant<Vector2N<TNumeric>>()).Dimensions,
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
                () => origin.Y.Add(dimensions.Y));
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
                () => origin.Y);
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
                () => origin.X);
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
                () => origin.X.Add(dimensions.X));
        }

        [Test, Repeat(RandomVariations)]
        public void BottomLeftMethods_RandomValue_SameResult()
        {
            //arrange
            Vector2N<TNumeric> origin = Random.NextVariant<Vector2N<TNumeric>>(Scenarios.LowMagnitude);
            Vector2N<TNumeric> dimensions = Random.NextVariant<Vector2N<TNumeric>>(Scenarios.LowMagnitude);

            //act
            //assert
            AssertSame.Result(
                () => new AARectangle<TNumeric>(origin, dimensions).Center,
                () => new Rectangle<TNumeric>(origin, dimensions, default).Origin,
                () => new AARectangle<TNumeric>(origin, dimensions).GetBottomLeft(),
                () => new Rectangle<TNumeric>(origin, dimensions, default).GetBottomLeft(),
                () => AARectangle.FromBottomLeft(origin, dimensions).Center,
                () => Rectangle.FromBottomLeft(origin, dimensions, default).Origin,
                () => AARectangle.FromBottomLeft(origin, dimensions).GetBottomLeft(),
                () => Rectangle.FromBottomLeft(origin, dimensions, default).GetBottomLeft(),
                () => origin);
        }

        [Test, Repeat(RandomVariations)]
        public void BottomCenterMethods_RandomValue_SameResult()
        {
            //arrange
            Vector2N<TNumeric> origin = Random.NextVariant<Vector2N<TNumeric>>(Scenarios.LowMagnitude);
            Vector2N<TNumeric> dimensions = Random.NextVariant<Vector2N<TNumeric>>(Scenarios.LowMagnitude);

            //act
            //assert
            AssertSame.Result(
                () => new AARectangle<TNumeric>(origin, dimensions).GetBottomCenter(),
                () => new Rectangle<TNumeric>(origin, dimensions, default).GetBottomCenter(),
                () => AARectangle.FromBottomCenter(origin, dimensions).Center.AddX(dimensions.X.Half()),
                () => Rectangle.FromBottomCenter(origin, dimensions, default).Origin.AddX(dimensions.X.Half()),
                () => origin.AddX(dimensions.X.Half()));
        }

        [Test, Repeat(RandomVariations)]
        public void BottomRightMethods_RandomValue_SameResult()
        {
            //arrange
            Vector2N<TNumeric> origin = Random.NextVariant<Vector2N<TNumeric>>(Scenarios.LowMagnitude);
            Vector2N<TNumeric> dimensions = Random.NextVariant<Vector2N<TNumeric>>(Scenarios.LowMagnitude);

            //act
            //assert
            AssertSame.Result(
                () => new AARectangle<TNumeric>(origin, dimensions).GetBottomRight(),
                () => new Rectangle<TNumeric>(origin, dimensions, default).GetBottomRight(),
                () => AARectangle.FromBottomRight(origin, dimensions).Center.AddX(dimensions.X),
                () => Rectangle.FromBottomRight(origin, dimensions, default).Origin.AddX(dimensions.X),
                () => origin.AddX(dimensions.X));
        }

        [Test, Repeat(RandomVariations)]
        public void RightCenterMethods_RandomValue_SameResult()
        {
            //arrange
            Vector2N<TNumeric> origin = Random.NextVariant<Vector2N<TNumeric>>(Scenarios.LowMagnitude);
            Vector2N<TNumeric> dimensions = Random.NextVariant<Vector2N<TNumeric>>(Scenarios.LowMagnitude);

            //act
            //assert
            AssertSame.Result(
                () => new AARectangle<TNumeric>(origin, dimensions).GetRightCenter(),
                () => new Rectangle<TNumeric>(origin, dimensions, default).GetRightCenter(),
                () => AARectangle.FromRightCenter(origin, dimensions).Center + new Vector2N<TNumeric>(dimensions.X, dimensions.Y.Half()),
                () => Rectangle.FromRightCenter(origin, dimensions, default).Origin + new Vector2N<TNumeric>(dimensions.X, dimensions.Y.Half()),
                () => origin + new Vector2N<TNumeric>(dimensions.X, dimensions.Y.Half()));
        }

        [Test, Repeat(RandomVariations)]
        public void TopRightMethods_RandomValue_SameResult()
        {
            //arrange
            Vector2N<TNumeric> origin = Random.NextVariant<Vector2N<TNumeric>>(Scenarios.LowMagnitude);
            Vector2N<TNumeric> dimensions = Random.NextVariant<Vector2N<TNumeric>>(Scenarios.LowMagnitude);

            //act
            //assert
            AssertSame.Result(
                () => new AARectangle<TNumeric>(origin, dimensions).GetTopRight(),
                () => new Rectangle<TNumeric>(origin, dimensions, default).GetTopRight(),
                () => AARectangle.FromTopRight(origin, dimensions).Center + dimensions,
                () => Rectangle.FromTopRight(origin, dimensions, default).Origin + dimensions,
                () => origin + dimensions);
        }

        [Test, Repeat(RandomVariations)]
        public void TopCenterMethods_RandomValue_SameResult()
        {
            //arrange
            Vector2N<TNumeric> origin = Random.NextVariant<Vector2N<TNumeric>>(Scenarios.LowMagnitude);
            Vector2N<TNumeric> dimensions = Random.NextVariant<Vector2N<TNumeric>>(Scenarios.LowMagnitude);

            //act
            //assert
            AssertSame.Result(
                () => new AARectangle<TNumeric>(origin, dimensions).GetTopCenter(),
                () => new Rectangle<TNumeric>(origin, dimensions, default).GetTopCenter(),
                () => AARectangle.FromTopCenter(origin, dimensions).Center + new Vector2N<TNumeric>(dimensions.X.Half(), dimensions.Y),
                () => Rectangle.FromTopCenter(origin, dimensions, default).Origin + new Vector2N<TNumeric>(dimensions.X.Half(), dimensions.Y),
                () => origin + new Vector2N<TNumeric>(dimensions.X.Half(), dimensions.Y));
        }

        [Test, Repeat(RandomVariations)]
        public void TopLeftMethods_RandomValue_SameResult()
        {
            //arrange
            Vector2N<TNumeric> origin = Random.NextVariant<Vector2N<TNumeric>>(Scenarios.LowMagnitude);
            Vector2N<TNumeric> dimensions = Random.NextVariant<Vector2N<TNumeric>>(Scenarios.LowMagnitude);

            //act
            //assert
            AssertSame.Result(
                () => new AARectangle<TNumeric>(origin, dimensions).GetTopLeft(),
                () => new Rectangle<TNumeric>(origin, dimensions, default).GetTopLeft(),
                () => AARectangle.FromTopLeft(origin, dimensions).Center.AddY(dimensions.Y),
                () => Rectangle.FromTopLeft(origin, dimensions, default).Origin.AddY(dimensions.Y),
                () => origin.AddY(dimensions.Y));
        }

        [Test, Repeat(RandomVariations)]
        public void LeftCenterMethods_RandomValue_SameResult()
        {
            //arrange
            Vector2N<TNumeric> origin = Random.NextVariant<Vector2N<TNumeric>>(Scenarios.LowMagnitude);
            Vector2N<TNumeric> dimensions = Random.NextVariant<Vector2N<TNumeric>>(Scenarios.LowMagnitude);

            //act
            //assert
            AssertSame.Result(
                () => new AARectangle<TNumeric>(origin, dimensions).GetLeftCenter(),
                () => new Rectangle<TNumeric>(origin, dimensions, default).GetLeftCenter(),
                () => AARectangle.FromLeftCenter(origin, dimensions).Center.AddY(dimensions.Y.Half()),
                () => Rectangle.FromLeftCenter(origin, dimensions, default).Origin.AddY(dimensions.Y.Half()),
                () => origin.AddY(dimensions.Y.Half()));
        }
    }
}
