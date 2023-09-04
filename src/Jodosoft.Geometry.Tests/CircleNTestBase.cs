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

using System.Diagnostics.CodeAnalysis;
using FluentAssertions;
using Jodosoft.Numerics;
using Jodosoft.Primitives;
using Jodosoft.Testing;
using NUnit.Framework;

namespace Jodosoft.Geometry.Tests
{
    public abstract class CircleNTestBase
        <TNumeric> : GlobalFixtureBase where TNumeric : struct, INumeric<TNumeric>
    {
        [Test, Repeat(RandomVariations)]

        [SuppressMessage("csharpsquid", "S1940:Boolean checks should not be inverted.", Justification = "Intentional for verifying operator consistency.")]
        public void EqualsMethods_RandomValues_SameOutcome()
        {
            //arrange
            CircleN<TNumeric> input1 = Random.NextVariant<CircleN<TNumeric>>();
            CircleN<TNumeric> input2 = Random.Choose(input1, Random.NextVariant<CircleN<TNumeric>>());

            //act
            //assert
            AssertSame.Outcome(
                () => input1.Equals(input2),
                () => input1.Equals((object)input2),
                () => input1 == input2,
                () => !(input1 != input2));
        }

        [Test, Repeat(RandomVariations)]
        public void GetDiameter_RandomValues_SameAsDoubleRadius()
        {
            //arrange
            CircleN<TNumeric> input1 = Random.NextVariant<CircleN<TNumeric>>(Variants.NonError);

            //act
            TNumeric result = input1.GetDiameter();

            //assert
            result.Should().Be(input1.Radius.Double());
        }

        [Test, Repeat(RandomVariations)]
        public void Ctor1_RandomInputs_SetsCenterAndRadiusCorrectly()
        {
            //arrange
            Vector2N<TNumeric> center = Random.NextVariant<Vector2N<TNumeric>>(Variants.NonError);
            TNumeric radius = Random.NextVariant<TNumeric>(Variants.NonError);

            //act
            CircleN<TNumeric> result = new CircleN<TNumeric>(center, radius);

            //assert
            result.Center.Should().Be(center);
            result.Radius.Should().Be(radius);
        }

        [Test, Repeat(RandomVariations)]
        public void Ctor2_RandomInputs_SetsCenterAndRadiusCorrectly()
        {
            //arrange
            Vector2N<TNumeric> center = Random.NextVariant<Vector2N<TNumeric>>(Variants.NonError);
            TNumeric radius = Random.NextVariant<TNumeric>(Variants.NonError);

            //act
            CircleN<TNumeric> result = new CircleN<TNumeric>(center.X, center.Y, radius);

            //assert
            result.Center.Should().Be(center);
            result.Radius.Should().Be(radius);
        }

        [Test, Repeat(RandomVariations)]
        public void GetArea_RandomValues_SameAsPiRSquared()
        {
            //arrange
            CircleN<TNumeric> input = Random.NextVariant<CircleN<TNumeric>>(Variants.LowMagnitude);

            //act
            TNumeric result = input.GetArea();

            //assert
            result.Should().Be(MathN.PI<TNumeric>().Multiply(input.Radius).Multiply(input.Radius));
        }
    }
}
