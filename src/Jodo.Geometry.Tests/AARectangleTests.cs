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
        public sealed class FixedPointBitConverter : Primitives.Tests.BitConvertTests<AARectangle<Fix64>> { }
        public sealed class FixedPointGeneralTests : GeneralTests<Fix64> { }
        public sealed class FixedPointObjectTests : Primitives.Tests.ObjectTests<AARectangle<Fix64>> { }
        public sealed class FixedPointSerializableTests : Primitives.Tests.SerializableTests<AARectangle<Fix64>> { }

        public sealed class FloatingPointBitConverter : Primitives.Tests.BitConvertTests<AARectangle<SingleN>> { }
        public sealed class FloatingPointGeneralTests : GeneralTests<SingleN> { }
        public sealed class FloatingPointObjectTests : Primitives.Tests.ObjectTests<AARectangle<SingleN>> { }
        public sealed class FloatingPointSerializableTests : Primitives.Tests.SerializableTests<AARectangle<SingleN>> { }

        public sealed class UnsignedIntegralBitConverter : Primitives.Tests.BitConvertTests<AARectangle<ByteN>> { }
        public sealed class UnsignedIntegralGeneralTests : GeneralTests<ByteN> { }
        public sealed class UnsignedIntegralObjectTests : Primitives.Tests.ObjectTests<AARectangle<ByteN>> { }
        public sealed class UnsignedIntegralSerializableTests : Primitives.Tests.SerializableTests<AARectangle<ByteN>> { }
        public sealed class UnsignedIntegralStringParser : Primitives.Tests.StringParserTests<AARectangle<ByteN>> { }

        public abstract class GeneralTests<TNumeric> : AssemblyFixtureBase where TNumeric : struct, INumeric<TNumeric>
        {

            [Test]
            public void GetArea_RandomValues_CorrectResult()
            {
                //arrange
                AARectangle<TNumeric> subject = GenerateAARectangle<TNumeric>();
                TNumeric expected = MathN.Abs(subject.Dimensions.X.Multiply(subject.Dimensions.Y));

                //act
                TNumeric result = subject.GetArea();

                //assert
                result.Should().Be(expected);
            }

            [Test]
            public void GetLeft_RandomValues_CorrectResult()
            {
                //arrange
                AARectangle<TNumeric> subject = Random.NextAARectangle<TNumeric>();
                TNumeric expected = subject.Origin.X;

                //act
                TNumeric result = subject.GetLeft();

                //assert
                result.Should().Be(expected);
            }
        }

        public abstract class Integral<TNumeric> : GlobalFixtureBase where TNumeric : struct, INumeric<TNumeric>
        {
            [SetUp]
            public void SetUp() => Assert.That(Numeric.IsIntegral<TNumeric>());

            [Test, Repeat(RandomVariations)]
            public void GetVertices_UnitSquare_CorrectResult()
            {
                //arrange
                AARectangle<TNumeric> subject = AARectangle.FromCenter(
                    new Vector2<TNumeric>(Numeric.Zero<TNumeric>(), Numeric.Zero<TNumeric>()),
                    new Vector2<TNumeric>(Numeric.One<TNumeric>(), Numeric.One<TNumeric>()));
                Vector2<TNumeric>[] expected = new Vector2<TNumeric>[] {
                     new Vector2<TNumeric>(Numeric.Zero<TNumeric>(), Numeric.Zero<TNumeric>()),
                     new Vector2<TNumeric>(Numeric.One<TNumeric>(), Numeric.Zero<TNumeric>()),
                     new Vector2<TNumeric>(Numeric.One<TNumeric>(), Numeric.One<TNumeric>()),
                     new Vector2<TNumeric>(Numeric.Zero<TNumeric>(), Numeric.One<TNumeric>()) };

                //act
                Vector2<TNumeric>[] results = subject.GetVertices();

                //assert
                results.Should().BeEquivalentTo(expected);
            }
        }
    }
}
