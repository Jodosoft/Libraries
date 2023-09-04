// Copyright (c) 2023 Joe Lawry-Short
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
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using FluentAssertions;
using Jodosoft.Numerics;
using Jodosoft.Primitives;
using Jodosoft.Testing;
using NUnit.Framework;

namespace Jodosoft.Geometry.Tests
{
    public abstract class AARectangleNTestBase<TNumeric> : GlobalFixtureBase where TNumeric : struct, INumeric<TNumeric>
    {
        [Test, Repeat(RandomVariations)]

        [SuppressMessage("csharpsquid", "S1940:Boolean checks should not be inverted.", Justification = "Intentional for verifying operator consistency.")]
        public void EqualsMethods_RandomValues_SameOutcome()
        {
            //arrange
            AARectangleN<TNumeric> input1 = Random.NextVariant<AARectangleN<TNumeric>>(Variants.LowMagnitude);
            AARectangleN<TNumeric> input2 = Random.Choose(input1, Random.NextVariant<AARectangleN<TNumeric>>(Variants.LowMagnitude));

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
            AARectangleN<TNumeric> subject = Random.NextVariant<AARectangleN<TNumeric>>(Variants.LowMagnitude);
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
            AARectangleN<TNumeric> subject = Random.NextVariant<AARectangleN<TNumeric>>(Variants.LowMagnitude);
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
            AARectangleN<TNumeric> subject = Random.NextVariant<AARectangleN<TNumeric>>(Variants.LowMagnitude);

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
            AARectangleN<TNumeric> subject = Random.NextVariant<AARectangleN<TNumeric>>(Variants.LowMagnitude);
            AngleN<TNumeric> angle = Random.NextVariant<AngleN<TNumeric>>(Variants.LowMagnitude);

            //act
            //assert
            AssertSame.Result(
                () => subject.Rotate(angle),
                () => new RectangleN<TNumeric>(subject.Center, subject.Dimensions, angle));
        }

        [Test, Repeat(RandomVariations)]
        public void GetTop_UnitHeight_DoesNotEqualBottom()
        {
            //arrange
            AARectangleN<TNumeric> subject = new AARectangleN<TNumeric>(
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
            AARectangleN<TNumeric> subject = new AARectangleN<TNumeric>(
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
            AARectangleN<TNumeric> subject = Random.NextVariant<AARectangleN<TNumeric>>(Variants.NonError);

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
            AARectangleN<TNumeric> subject = Random.NextVariant<AARectangleN<TNumeric>>(Variants.NonError);

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
            AARectangleN<TNumeric> subject = Random.NextVariant<AARectangleN<TNumeric>>(Variants.NonError);

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
            AARectangleN<TNumeric> subject = Random.NextVariant<AARectangleN<TNumeric>>(Variants.NonError);

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
                () => new AARectangleN<TNumeric>(center, dimensions).GetBottomLeft(),
                () => new RectangleN<TNumeric>(center, dimensions, AngleN.Zero<TNumeric>()).GetBottomLeft(),
                () => AARectangleN.FromBottomLeft(expected, dimensions).GetBottomLeft(),
                () => RectangleN.FromBottomLeft(expected, dimensions, AngleN.Zero<TNumeric>()).GetBottomLeft(),
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
                () => new AARectangleN<TNumeric>(center, dimensions).GetBottomCenter(),
                () => new RectangleN<TNumeric>(center, dimensions, AngleN.Zero<TNumeric>()).GetBottomCenter(),
                () => AARectangleN.FromBottomCenter(expected, dimensions).GetBottomCenter(),
                () => RectangleN.FromBottomCenter(expected, dimensions, AngleN.Zero<TNumeric>()).GetBottomCenter(),
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
                () => new AARectangleN<TNumeric>(center, dimensions).GetBottomRight(),
                () => new RectangleN<TNumeric>(center, dimensions, AngleN.Zero<TNumeric>()).GetBottomRight(),
                () => AARectangleN.FromBottomRight(expected, dimensions).GetBottomRight(),
                () => RectangleN.FromBottomRight(expected, dimensions, AngleN.Zero<TNumeric>()).GetBottomRight(),
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
                () => new AARectangleN<TNumeric>(center, dimensions).GetRightCenter(),
                () => new RectangleN<TNumeric>(center, dimensions, AngleN.Zero<TNumeric>()).GetRightCenter(),
                () => AARectangleN.FromRightCenter(expected, dimensions).GetRightCenter(),
                () => RectangleN.FromRightCenter(expected, dimensions, AngleN.Zero<TNumeric>()).GetRightCenter(),
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
                () => new AARectangleN<TNumeric>(center, dimensions).GetTopRight(),
                () => new RectangleN<TNumeric>(center, dimensions, AngleN.Zero<TNumeric>()).GetTopRight(),
                () => AARectangleN.FromTopRight(expected, dimensions).GetTopRight(),
                () => RectangleN.FromTopRight(expected, dimensions, AngleN.Zero<TNumeric>()).GetTopRight(),
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
                () => new AARectangleN<TNumeric>(center, dimensions).GetTopCenter(),
                () => new RectangleN<TNumeric>(center, dimensions, AngleN.Zero<TNumeric>()).GetTopCenter(),
                () => AARectangleN.FromTopCenter(expected, dimensions).GetTopCenter(),
                () => RectangleN.FromTopCenter(expected, dimensions, AngleN.Zero<TNumeric>()).GetTopCenter(),
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
                () => new AARectangleN<TNumeric>(center, dimensions).GetTopLeft(),
                () => new RectangleN<TNumeric>(center, dimensions, AngleN.Zero<TNumeric>()).GetTopLeft(),
                () => AARectangleN.FromTopLeft(expected, dimensions).GetTopLeft(),
                () => RectangleN.FromTopLeft(expected, dimensions, AngleN.Zero<TNumeric>()).GetTopLeft(),
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
                () => new AARectangleN<TNumeric>(center, dimensions).GetLeftCenter(),
                () => new RectangleN<TNumeric>(center, dimensions, AngleN.Zero<TNumeric>()).GetLeftCenter(),
                () => AARectangleN.FromLeftCenter(expected, dimensions).GetLeftCenter(),
                () => RectangleN.FromLeftCenter(expected, dimensions, AngleN.Zero<TNumeric>()).GetLeftCenter(),
                () => expected
            }
                .Select(x => new Func<Vector2N<TNumeric>>(() => Vector2N.Round(x(), 3)))
                .ToArray();

            //assert
            AssertSame.Outcome(actions);
        }
    }
}
