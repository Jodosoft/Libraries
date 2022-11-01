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
using System.Linq;
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
            AARectangle<TNumeric> input1 = Random.NextVariant<AARectangle<TNumeric>>(Variants.LowMagnitude);
            AARectangle<TNumeric> input2 = Random.Choose(input1, Random.NextVariant<AARectangle<TNumeric>>(Variants.LowMagnitude));

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
            AARectangle<TNumeric> subject = Random.NextVariant<AARectangle<TNumeric>>(Variants.LowMagnitude);
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
            AARectangle<TNumeric> subject = Random.NextVariant<AARectangle<TNumeric>>(Variants.LowMagnitude);
            Vector2N<TNumeric> delta = Random.NextVariant<Vector2N<TNumeric>>(Variants.LowMagnitude);

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
            AARectangle<TNumeric> subject = Random.NextVariant<AARectangle<TNumeric>>(Variants.LowMagnitude);

            //act
            //assert
            AssertSame.Result(
                () => subject.Translate(Random.NextVariant<Vector2N<TNumeric>>(Variants.LowMagnitude)).Dimensions,
                () => subject.Dimensions);
        }

        [Test, Repeat(RandomVariations)]
        public void Rotate_RandomValue_SameAsConstructingRectangle()
        {
            //arrange
            AARectangle<TNumeric> subject = Random.NextVariant<AARectangle<TNumeric>>(Variants.LowMagnitude);
            Angle<TNumeric> angle = Random.NextVariant<Angle<TNumeric>>(Variants.LowMagnitude);

            //act
            //assert
            AssertSame.Result(
                () => subject.Rotate(angle),
                () => new Rectangle<TNumeric>(subject.Center, subject.Dimensions, angle));
        }

        [Test, Repeat(RandomVariations)]
        public void GetTop_UnitHeight_DoesNotEqualBottom()
        {
            //arrange
            AARectangle<TNumeric> subject = new AARectangle<TNumeric>(
                Random.NextVariant<Vector2N<TNumeric>>(Variants.LowMagnitude),
                new Vector2N<TNumeric>(Random.NextVariant<TNumeric>(Variants.LowMagnitude), Numeric.One<TNumeric>()));
            TNumeric bottom = subject.GetBottom();

            //act
            TNumeric result = subject.GetTop();

            //assert
            result.Should().NotBe(bottom);
        }

        [Test, Repeat(RandomVariations)]
        public void GetRight_UnitWidth_DoesNotEqualBottom()
        {
            //arrange
            AARectangle<TNumeric> subject = new AARectangle<TNumeric>(
                Random.NextVariant<Vector2N<TNumeric>>(Variants.LowMagnitude),
                new Vector2N<TNumeric>(Numeric.One<TNumeric>(), Random.NextVariant<TNumeric>(Variants.LowMagnitude)));
            TNumeric left = subject.GetLeft();

            //act
            TNumeric result = subject.GetRight();

            //assert
            result.Should().NotBe(left);
        }

        [Test, Repeat(RandomVariations)]
        public void GetTop_RandomValue_SameAsManualCalculation()
        {
            //arrange
            AARectangle<TNumeric> subject = Random.NextVariant<AARectangle<TNumeric>>(Variants.NonError);

            //act
            TNumeric getTop() => subject.GetTop();
            TNumeric manualCalculation() => subject.Center.Y.Subtract(subject.Height.Half()).Add(subject.Height);

            //assert
            AssertSame.Result(getTop, manualCalculation);
        }

        [Test, Repeat(RandomVariations)]
        public void GetBottom_RandomValue_SameAsManualCalculation()
        {
            //arrange
            AARectangle<TNumeric> subject = Random.NextVariant<AARectangle<TNumeric>>(Variants.NonError);

            //act
            TNumeric getBottom() => subject.GetBottom();
            TNumeric manualCalculation() => subject.Center.Y.Subtract(subject.Height.Half());

            //assert
            AssertSame.Result(getBottom, manualCalculation);
        }

        [Test, Repeat(RandomVariations)]
        public void GetRight_RandomValue_SameAsManualCalculation()
        {
            //arrange
            AARectangle<TNumeric> subject = Random.NextVariant<AARectangle<TNumeric>>(Variants.NonError);

            //act
            TNumeric getRight() => subject.GetRight();
            TNumeric manualCalculation() => subject.Center.X.Subtract(subject.Width.Half()).Add(subject.Width);

            //assert
            AssertSame.Result(getRight, manualCalculation);
        }

        [Test, Repeat(RandomVariations)]
        public void GetLeft_RandomValue_SameAsManualCalculation()
        {
            //arrange
            AARectangle<TNumeric> subject = Random.NextVariant<AARectangle<TNumeric>>(Variants.NonError);

            //act
            TNumeric getLeft() => subject.GetLeft();
            TNumeric manualCalculation() => subject.Center.X.Subtract(subject.Width.Half());

            //assert
            AssertSame.Result(getLeft, manualCalculation);
        }

        [Test, Repeat(RandomVariations)]
        public void BottomLeftMethods_RandomValue_SameResult()
        {
            //arrange
            Vector2N<TNumeric> center = Random.NextVariant<Vector2N<TNumeric>>(Variants.LowMagnitude);
            Vector2N<TNumeric> dimensions = Random.NextVariant<Vector2N<TNumeric>>(Variants.LowMagnitude);
            Vector2N<TNumeric> expected = center.Subtract(dimensions.Half());

            //act
            Func<Vector2N<TNumeric>>[] actions = new[] {
                () => new AARectangle<TNumeric>(center, dimensions).GetBottomLeft(),
                () => new Rectangle<TNumeric>(center, dimensions, Angle.Zero<TNumeric>()).GetBottomLeft(),
                () => AARectangle.FromBottomLeft(expected, dimensions).GetBottomLeft(),
                () => Rectangle.FromBottomLeft(expected, dimensions, Angle.Zero<TNumeric>()).GetBottomLeft(),
                () => expected
            }
                .Select(x => new Func<Vector2N<TNumeric>>(() => Vector2N.Round(x(), 3)))
                .ToArray();

            //assert
            AssertSame.Outcome(actions);
        }

        [Test, Repeat(RandomVariations)]
        public void BottomCenterMethods_RandomValue_SameResult()
        {
            //arrange
            Vector2N<TNumeric> center = Random.NextVariant<Vector2N<TNumeric>>(Variants.LowMagnitude);
            Vector2N<TNumeric> dimensions = Random.NextVariant<Vector2N<TNumeric>>(Variants.LowMagnitude);
            Vector2N<TNumeric> expected = center.SubtractY(dimensions.Y.Half());
            //act
            Func<Vector2N<TNumeric>>[] actions = new[] {
                () => new AARectangle<TNumeric>(center, dimensions).GetBottomCenter(),
                () => new Rectangle<TNumeric>(center, dimensions, Angle.Zero<TNumeric>()).GetBottomCenter(),
                () => AARectangle.FromBottomCenter(expected, dimensions).GetBottomCenter(),
                () => Rectangle.FromBottomCenter(expected, dimensions, Angle.Zero<TNumeric>()).GetBottomCenter(),
                () => expected
            }
                .Select(x => new Func<Vector2N<TNumeric>>(() => Vector2N.Round(x(), 3)))
                .ToArray();

            //assert
            AssertSame.Outcome(actions);
        }

        [Test, Repeat(RandomVariations)]
        public void BottomRightMethods_RandomValue_SameResult()
        {
            //arrange
            Vector2N<TNumeric> center = Random.NextVariant<Vector2N<TNumeric>>(Variants.LowMagnitude);
            Vector2N<TNumeric> dimensions = Random.NextVariant<Vector2N<TNumeric>>(Variants.LowMagnitude);
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
            }
                .Select(x => new Func<Vector2N<TNumeric>>(() => Vector2N.Round(x(), 3)))
                .ToArray();

            //assert
            AssertSame.Outcome(actions);
        }

        [Test, Repeat(RandomVariations)]
        public void RightCenterMethods_RandomValue_SameResult()
        {
            //arrange
            Vector2N<TNumeric> center = Random.NextVariant<Vector2N<TNumeric>>(Variants.LowMagnitude);
            Vector2N<TNumeric> dimensions = Random.NextVariant<Vector2N<TNumeric>>(Variants.LowMagnitude);
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
            }
                .Select(x => new Func<Vector2N<TNumeric>>(() => Vector2N.Round(x(), 3)))
                .ToArray();

            //assert
            AssertSame.Outcome(actions);
        }

        [Test, Repeat(RandomVariations)]
        public void TopRightMethods_RandomValue_SameResult()
        {
            //arrange
            Vector2N<TNumeric> center = Random.NextVariant<Vector2N<TNumeric>>(Variants.LowMagnitude);
            Vector2N<TNumeric> dimensions = Random.NextVariant<Vector2N<TNumeric>>(Variants.LowMagnitude);
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
            }
                .Select(x => new Func<Vector2N<TNumeric>>(() => Vector2N.Round(x(), 3)))
                .ToArray();

            //assert
            AssertSame.Outcome(actions);
        }

        [Test, Repeat(RandomVariations)]
        public void TopCenterMethods_RandomValue_SameResult()
        {
            //arrange
            Vector2N<TNumeric> center = Random.NextVariant<Vector2N<TNumeric>>(Variants.LowMagnitude);
            Vector2N<TNumeric> dimensions = Random.NextVariant<Vector2N<TNumeric>>(Variants.LowMagnitude);
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
            }
                .Select(x => new Func<Vector2N<TNumeric>>(() => Vector2N.Round(x(), 3)))
                .ToArray();

            //assert
            AssertSame.Outcome(actions);
        }

        [Test, Repeat(RandomVariations)]
        public void TopLeftMethods_RandomValue_SameResult()
        {
            //arrange
            Vector2N<TNumeric> center = Random.NextVariant<Vector2N<TNumeric>>(Variants.LowMagnitude);
            Vector2N<TNumeric> dimensions = Random.NextVariant<Vector2N<TNumeric>>(Variants.LowMagnitude);
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
            }
                .Select(x => new Func<Vector2N<TNumeric>>(() => Vector2N.Round(x(), 3)))
                .ToArray();

            //assert
            AssertSame.Outcome(actions);
        }

        [Test, Repeat(RandomVariations)]
        public void LeftCenterMethods_RandomValue_SameResult()
        {
            //arrange
            Vector2N<TNumeric> center = Random.NextVariant<Vector2N<TNumeric>>(Variants.LowMagnitude);
            Vector2N<TNumeric> dimensions = Random.NextVariant<Vector2N<TNumeric>>(Variants.LowMagnitude);
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
            }
                .Select(x => new Func<Vector2N<TNumeric>>(() => Vector2N.Round(x(), 3)))
                .ToArray();

            //assert
            AssertSame.Outcome(actions);
        }
    }
}
