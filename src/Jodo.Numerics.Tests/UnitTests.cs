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
using Jodo.Testing;
using NUnit.Framework;

namespace Jodo.Numerics.Tests
{
    public static class UnitTests
    {
        public sealed class FixedPoint : General<Fix64> { }
        public sealed class FloatingPoint : General<SingleN> { }
        public sealed class UnsignedIntegral : General<ByteN> { }

        public abstract class General<N> : GlobalFixtureBase where N : struct, INumeric<N>
        {
            public sealed class BitConverter : Primitives.Tests.BitConverterTests<Unit<N>> { }
            public sealed class StringParser : Primitives.Tests.StringParserTests<Unit<N>> { }

            [Test]
            public void Clamp_ValueGreaterThanMaxUnit_ReturnsMaxUnit()
            {
                //arrange
                N input = Random.NextNumeric(Numeric<N>.MaxUnit, Numeric<N>.MaxValue);

                //act
                Unit<N> result = Unit<N>.Clamp(input);

                //assert
                result.Value.Should().Be(Numeric<N>.MaxUnit);
            }

            [Test]
            public void Clamp_ValueGreaterThanMaxUnit_ReturnsMinUnit()
            {
                //arrange
                N input = Random.NextNumeric(Numeric<N>.MinValue, Numeric<N>.MinUnit);

                //act
                Unit<N> result = Unit<N>.Clamp(input);

                //assert
                result.Value.Should().Be(Numeric<N>.MinUnit);
            }

            [Test]
            public void Add_Numeric_CorrectResult()
            {
                //arrange
                Unit<N> left = Random.NextUnit<N>();
                Unit<N> right = Random.NextUnit<N>();
                N expected = left.Value.Add(right.Value);

                //act
                N result = left + right;

                //assert
                result.Should().Be(expected);
            }
        }
    }
}
