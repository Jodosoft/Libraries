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
using Jodo.Testing;
using NUnit.Framework;

namespace Jodo.Geometry.Tests
{
    public static class AARectangleTests
    {
        public sealed class Intergral : Integral<xshort> { }
        public sealed class GeneralUnsignedIntegral : General<xbyte> { }
        public sealed class GeneralFloatingPoint : General<xfloat> { }
        public sealed class GeneralFixedPoint : General<fix64> { }

        public abstract class General<N> : AssemblyFixtureBase where N : struct, INumeric<N>
        {
            public sealed class BitConverter : Primitives.Tests.BitConverterTests<AARectangle<N>> { }
            public sealed class StringParser : Primitives.Tests.StringParserTests<AARectangle<N>> { }
            public sealed class TwoDimensional : TwoDimensionalTests<AARectangle<N>, N> { }

            [Test]
            public void GetArea_RandomValues_CorrectResult()
            {
                //arrange
                AARectangle<N> subject = GenerateAARectangle<N>();
                N expected = Math<N>.Abs(subject.Dimensions.X.Multiply(subject.Dimensions.Y));

                //act
                N result = subject.GetArea();

                //assert
                result.Should().Be(expected);
            }

            [Test]
            public void GetLeft_RandomValues_CorrectResult()
            {
                //arrange
                AARectangle<N> subject = Random.NextAARectangle<N>();
                N expected = subject.Origin.X;

                //act
                N result = subject.GetLeft();

                //assert
                result.Should().Be(expected);
            }
        }

        public abstract class Integral<N> : GlobalFixtureBase where N : struct, INumeric<N>
        {
            [SetUp]
            public void SetUp() => Assert.That(Numeric<N>.IsIntegral);

            [Test, Repeat(RandomVariations)]
            public void GetVertices_UnitSquare_CorrectResult()
            {
                //arrange
                AARectangle<N> subject = AARectangle<N>.FromCenter(
                    new Vector2<N>(Numeric<N>.Zero, Numeric<N>.Zero),
                    new Vector2<N>(Numeric<N>.One, Numeric<N>.One));
                Vector2<N>[] expected = new Vector2<N>[] {
                     new Vector2<N>(Numeric<N>.Zero, Numeric<N>.Zero),
                     new Vector2<N>(Numeric<N>.One, Numeric<N>.Zero),
                     new Vector2<N>(Numeric<N>.One, Numeric<N>.One),
                     new Vector2<N>(Numeric<N>.Zero, Numeric<N>.One) };

                //act
                Vector2<N>[] results = subject.GetVertices();

                //assert
                results.Should().BeEquivalentTo(expected);
            }
        }
    }
}
