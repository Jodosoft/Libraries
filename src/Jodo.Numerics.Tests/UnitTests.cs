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

        public abstract class General<TNumeric> : GlobalFixtureBase where TNumeric : struct, INumeric<TNumeric>
        {
            public sealed class BitConverter : Primitives.Tests.BitConvertTests<Unit<TNumeric>> { }
            public sealed class StringParser : Primitives.Tests.StringParserTests<Unit<TNumeric>> { }

            [Test]
            public void Ctor_ValueGreaterThanMaxUnit_ReturnsMaxUnit()
            {
                //arrange
                TNumeric input = Random.NextNumeric(Numeric.MaxUnit<TNumeric>(), Numeric.MaxValue<TNumeric>());

                //act
                Unit<TNumeric> result = new Unit<TNumeric>(input);

                //assert
                result.Value.Should().Be(Numeric.MaxUnit<TNumeric>());
            }

            [Test]
            public void Ctor_ValueGreaterThanMaxUnit_ReturnsMinUnit()
            {
                //arrange
                TNumeric input = Random.NextNumeric(Numeric.MinValue<TNumeric>(), Numeric.MinUnit<TNumeric>());

                //act
                Unit<TNumeric> result = new Unit<TNumeric>(input);

                //assert
                result.Value.Should().Be(Numeric.MinUnit<TNumeric>());
            }

            [Test]
            public void Add_Numeric_CorrectResult()
            {
                //arrange
                Unit<TNumeric> left = Random.NextUnit<TNumeric>();
                Unit<TNumeric> right = Random.NextUnit<TNumeric>();
                TNumeric expected = left.Value.Add(right.Value);

                //act
                TNumeric result = left + right;

                //assert
                result.Should().Be(expected);
            }
        }
    }
}
