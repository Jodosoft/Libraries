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
using FluentAssertions;
using Jodosoft.Primitives;
using Jodosoft.Testing;
using NUnit.Framework;

namespace Jodosoft.Numerics.Tests
{
    public abstract class Vector3NTestBase<TNumeric> : GlobalFixtureBase where TNumeric : struct, INumeric<TNumeric>
    {
        [Test, Repeat(RandomVariations)]
        public void Ctor_RandomValues_CorrectResult()
        {
            //arrange
            TNumeric x = Random.NextNumeric<TNumeric>(Generation.Extended);
            TNumeric y = Random.NextNumeric<TNumeric>(Generation.Extended);
            TNumeric z = Random.NextNumeric<TNumeric>(Generation.Extended);

            //act
            Vector3N<TNumeric> result = new Vector3N<TNumeric>(x, y, z);

            //assert
            result.X.Should().Be(x);
            result.Y.Should().Be(y);
            result.Z.Should().Be(z);
        }

        [Test, Repeat(RandomVariations)]
        public void Round1_RandomValues_SameResultAsRoundingComponents()
        {
            //arrange
            Vector3N<TNumeric> input = Random.NextVariant<Vector3N<TNumeric>>(Variants.LowMagnitude);
            Vector3N<TNumeric> expected = new Vector3N<TNumeric>(
                MathN.Round(input.X),
                MathN.Round(input.Y),
                MathN.Round(input.Z));

            //act
            Vector3N<TNumeric> result = Vector3N.Round(input);

            //assert
            result.Should().Be(expected);
        }

        [Test, Repeat(RandomVariations)]
        public void Round2_RandomValues_SameResultAsRoundingComponents()
        {
            //arrange
            Vector3N<TNumeric> input = Random.NextVariant<Vector3N<TNumeric>>(Variants.LowMagnitude);
            int digits = Random.Next(0, 5);
            Vector3N<TNumeric> expected = new Vector3N<TNumeric>(
                MathN.Round(input.X, digits),
                MathN.Round(input.Y, digits),
                MathN.Round(input.Z, digits));

            //act
            Vector3N<TNumeric> result = Vector3N.Round(input, digits);

            //assert
            result.Should().Be(expected);
        }

        [Test, Repeat(RandomVariations)]
        public void Round3_RandomValues_SameResultAsRoundingComponents()
        {
            //arrange
            Vector3N<TNumeric> input = Random.NextVariant<Vector3N<TNumeric>>(Variants.LowMagnitude);
            int digits = Random.Next(0, 5);
            MidpointRounding mode = Random.NextEnum<MidpointRounding>();
            Vector3N<TNumeric> expected = new Vector3N<TNumeric>(
                MathN.Round(input.X, digits, mode),
                MathN.Round(input.Y, digits, mode),
                MathN.Round(input.Z, digits, mode));

            //act
            Vector3N<TNumeric> result = Vector3N.Round(input, digits, mode);

            //assert
            result.Should().Be(expected);
        }

        [Test, Repeat(RandomVariations)]
        public void Round4_RandomValues_SameResultAsRoundingComponents()
        {
            //arrange
            Vector3N<TNumeric> input = Random.NextVariant<Vector3N<TNumeric>>(Variants.LowMagnitude);
            MidpointRounding mode = Random.NextEnum<MidpointRounding>();
            Vector3N<TNumeric> expected = new Vector3N<TNumeric>(
                MathN.Round(input.X, mode),
                MathN.Round(input.Y, mode),
                MathN.Round(input.Z, mode));

            //act
            Vector3N<TNumeric> result = Vector3N.Round(input, mode);

            //assert
            result.Should().Be(expected);
        }
    }
}
