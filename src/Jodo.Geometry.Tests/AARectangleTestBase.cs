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
                () => origin.Y.Subtract(dimensions.Y.Half()).Add(dimensions.Y));
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
                () => origin.X.Subtract(dimensions.X.Half()).Add(dimensions.X));
        }

        [Test, Repeat(RandomVariations)]
        public void BottomLeftMethods_RandomValue_SameResult()
        {
            //arrange
            Vector2N<TNumeric> center = Random.NextVariant<Vector2N<TNumeric>>(Scenarios.LowMagnitude);
            Vector2N<TNumeric> dimensions = Random.NextVariant<Vector2N<TNumeric>>(Scenarios.LowMagnitude);
            Vector2N<TNumeric> expected = center.Subtract(dimensions.Half());

            //act
            Func<Vector2N<TNumeric>>[] actions = new[] {
                () => new AARectangle<TNumeric>(center, dimensions).GetBottomLeft(),
                () => new Rectangle<TNumeric>(center, dimensions, Angle.Zero<TNumeric>()).GetBottomLeft(),
                () => AARectangle.FromBottomLeft(expected, dimensions).GetBottomLeft(),
                () => Rectangle.FromBottomLeft(expected, dimensions, Angle.Zero<TNumeric>()).GetBottomLeft(),
                () => expected
            };

            //assert
            AssertSame.Outcome(actions);
        }

        [Test, Repeat(RandomVariations)]
        public void BottomCenterMethods_RandomValue_SameResult()
        {
            //arrange
            Vector2N<TNumeric> center = Random.NextVariant<Vector2N<TNumeric>>(Scenarios.LowMagnitude);
            Vector2N<TNumeric> dimensions = Random.NextVariant<Vector2N<TNumeric>>(Scenarios.LowMagnitude);
            Vector2N<TNumeric> expected = center.SubtractY(dimensions.Y.Half());
            //act
            Func<Vector2N<TNumeric>>[] actions = new[] {
                () => new AARectangle<TNumeric>(center, dimensions).GetBottomCenter(),
                () => new Rectangle<TNumeric>(center, dimensions, Angle.Zero<TNumeric>()).GetBottomCenter(),
                () => AARectangle.FromBottomCenter(expected, dimensions).GetBottomCenter(),
                () => Rectangle.FromBottomCenter(expected, dimensions, Angle.Zero<TNumeric>()).GetBottomCenter(),
                () => expected
            };

            //assert
            AssertSame.Outcome(actions);
        }

        [Test, Repeat(RandomVariations)]
        public void BottomRightMethods_RandomValue_SameResult()
        {
            //arrange
            Vector2N<TNumeric> center = Random.NextVariant<Vector2N<TNumeric>>(Scenarios.LowMagnitude);
            Vector2N<TNumeric> dimensions = Random.NextVariant<Vector2N<TNumeric>>(Scenarios.LowMagnitude);
            Vector2N<TNumeric> expected = new Vector2N<TNumeric>(
                center.X.Subtract(dimensions.X.Half()).Add(dimensions.X),
                center.Y.Subtract(dimensions.Y.Half()));

            //act
            Func<Vector2N<TNumeric>>[] actions = new[] {
                () => new AARectangle<TNumeric>(center, dimensions).GetBottomRight(),
                () => new Rectangle<TNumeric>(center, dimensions, Angle.Zero<TNumeric>()).GetBottomRight(),
                () => AARectangle.FromBottomRight(expected, dimensions).GetBottomRight(),
                () => Rectangle.FromBottomRight(expected, dimensions, Angle.Zero<TNumeric>()).GetBottomRight(),
                () => expected
            };

            //assert
            AssertSame.Outcome(actions);
        }

        [Test, Repeat(RandomVariations)]
        public void RightCenterMethods_RandomValue_SameResult()
        {
            //arrange
            Vector2N<TNumeric> center = Random.NextVariant<Vector2N<TNumeric>>(Scenarios.LowMagnitude);
            Vector2N<TNumeric> dimensions = Random.NextVariant<Vector2N<TNumeric>>(Scenarios.LowMagnitude);
            Vector2N<TNumeric> expected = new Vector2N<TNumeric>(
                center.X.Subtract(dimensions.X.Half()).Add(dimensions.X),
                center.Y);

            //act
            Func<Vector2N<TNumeric>>[] actions = new[] {
                () => new AARectangle<TNumeric>(center, dimensions).GetRightCenter(),
                () => new Rectangle<TNumeric>(center, dimensions, Angle.Zero<TNumeric>()).GetRightCenter(),
                () => AARectangle.FromRightCenter(expected, dimensions).GetRightCenter(),
                () => Rectangle.FromRightCenter(expected, dimensions, Angle.Zero<TNumeric>()).GetRightCenter(),
                () => expected
            };

            //assert
            AssertSame.Outcome(actions);
        }

        [Test, Repeat(RandomVariations)]
        public void TopRightMethods_RandomValue_SameResult()
        {
            //arrange
            Vector2N<TNumeric> center = Random.NextVariant<Vector2N<TNumeric>>(Scenarios.LowMagnitude);
            Vector2N<TNumeric> dimensions = Random.NextVariant<Vector2N<TNumeric>>(Scenarios.LowMagnitude);
            Vector2N<TNumeric> expected = new Vector2N<TNumeric>(
                center.X.Subtract(dimensions.X.Half()).Add(dimensions.X),
                center.Y.Subtract(dimensions.Y.Half()).Add(dimensions.Y));

            //act
            Func<Vector2N<TNumeric>>[] actions = new[] {
                () => new AARectangle<TNumeric>(center, dimensions).GetTopRight(),
                () => new Rectangle<TNumeric>(center, dimensions, Angle.Zero<TNumeric>()).GetTopRight(),
                () => AARectangle.FromTopRight(expected, dimensions).GetTopRight(),
                () => Rectangle.FromTopRight(expected, dimensions, Angle.Zero<TNumeric>()).GetTopRight(),
                () => expected
            };

            //assert
            AssertSame.Outcome(actions);
        }

        [Test, Repeat(RandomVariations)]
        public void TopCenterMethods_RandomValue_SameResult()
        {
            //arrange
            Vector2N<TNumeric> center = Random.NextVariant<Vector2N<TNumeric>>(Scenarios.LowMagnitude);
            Vector2N<TNumeric> dimensions = Random.NextVariant<Vector2N<TNumeric>>(Scenarios.LowMagnitude);
            Vector2N<TNumeric> expected = new Vector2N<TNumeric>(
                center.X,
                center.Y.Subtract(dimensions.Y.Half()).Add(dimensions.Y));

            //act
            Func<Vector2N<TNumeric>>[] actions = new[] {
                () => new AARectangle<TNumeric>(center, dimensions).GetTopCenter(),
                () => new Rectangle<TNumeric>(center, dimensions, Angle.Zero<TNumeric>()).GetTopCenter(),
                () => AARectangle.FromTopCenter(expected, dimensions).GetTopCenter(),
                () => Rectangle.FromTopCenter(expected, dimensions, Angle.Zero<TNumeric>()).GetTopCenter(),
                () => expected
            };

            //assert
            AssertSame.Outcome(actions);
        }

        [Test, Repeat(RandomVariations)]
        public void TopLeftMethods_RandomValue_SameResult()
        {
            //arrange
            Vector2N<TNumeric> center = Random.NextVariant<Vector2N<TNumeric>>(Scenarios.LowMagnitude);
            Vector2N<TNumeric> dimensions = Random.NextVariant<Vector2N<TNumeric>>(Scenarios.LowMagnitude);
            Vector2N<TNumeric> expected = new Vector2N<TNumeric>(
                center.X.Subtract(dimensions.X.Half()),
                center.Y.Subtract(dimensions.Y.Half()).Add(dimensions.Y));

            //act
            Func<Vector2N<TNumeric>>[] actions = new[] {
                () => new AARectangle<TNumeric>(center, dimensions).GetTopLeft(),
                () => new Rectangle<TNumeric>(center, dimensions, Angle.Zero<TNumeric>()).GetTopLeft(),
                () => AARectangle.FromTopLeft(expected, dimensions).GetTopLeft(),
                () => Rectangle.FromTopLeft(expected, dimensions, Angle.Zero<TNumeric>()).GetTopLeft(),
                () => expected
            };

            //assert
            AssertSame.Outcome(actions);
        }

        [Test, Repeat(RandomVariations)]
        public void LeftCenterMethods_RandomValue_SameResult()
        {
            //arrange
            Vector2N<TNumeric> center = Random.NextVariant<Vector2N<TNumeric>>(Scenarios.LowMagnitude);
            Vector2N<TNumeric> dimensions = Random.NextVariant<Vector2N<TNumeric>>(Scenarios.LowMagnitude);
            Vector2N<TNumeric> expected = new Vector2N<TNumeric>(
                center.X.Subtract(dimensions.X.Half()),
                center.Y);

            //act
            Func<Vector2N<TNumeric>>[] actions = new[] {
                () => new AARectangle<TNumeric>(center, dimensions).GetLeftCenter(),
                () => new Rectangle<TNumeric>(center, dimensions, Angle.Zero<TNumeric>()).GetLeftCenter(),
                () => AARectangle.FromLeftCenter(expected, dimensions).GetLeftCenter(),
                () => Rectangle.FromLeftCenter(expected, dimensions, Angle.Zero<TNumeric>()).GetLeftCenter(),
                () => expected
            };

            //assert
            AssertSame.Outcome(actions);
        }
    }
}
