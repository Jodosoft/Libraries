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
using Jodo.Extensions.Testing;
using NUnit.Framework;
using System.Numerics;

namespace Jodo.Extensions.Numerics.Tests
{
    public sealed class TruncateTests : GlobalTestBase
    {
        [Test]
        public void ToDigits_ByteExample_CorrectResult()
        {
            //arrange

            //act
            var result = Truncate.ToDigits(122, 1);

            //assert
            result.Should().Be(100);
        }

        [Test]
        public void ToDigits_Int32Example1_CorrectResult()
        {
            //arrange

            //act
            var result = Truncate.ToDigits(233_254, 4);

            //assert
            result.Should().Be(233_200);
        }


        [Test]
        public void ToDigits_Int32Example2_CorrectResult()
        {
            //arrange

            //act
            var result = Truncate.ToDigits(-233_254, 2);

            //assert
            result.Should().Be(-230_000);
        }

        [Test]
        public void ToDigits_BigIntegerExample_CorrectResult()
        {
            //arrange

            //act
            var result = Truncate.ToDigits(new BigInteger(987654321L), 1);

            //assert
            result.Should().Be(new BigInteger(900000000));
        }

        [TestCase(233_254f, 4, 233_200f)]
        [TestCase(-233_254f, 2, -230_000f)]
        [TestCase(0f, 2, 0f)]
        [TestCase(1f, 2, 1f)]
        [TestCase(0.1f, 2, 0.1f)]
        [TestCase(0.01f, 2, 0.01f)]
        [TestCase(0.001f, 2, 0f)]
        [TestCase(0.9f, 2, 0.9f)]
        [TestCase(0.99f, 2, 0.99f)]
        [TestCase(0.999f, 2, 0.99f)]
        [TestCase(1.1f, 2, 1.1f)]
        [TestCase(1.01f, 2, 1f)]
        [TestCase(1.9f, 2, 1.9f)]
        [TestCase(1.99f, 2, 1.9f)]
        [TestCase(0.48681998f, 5, 0.48681f)]
        [TestCase(-0.48681998f, 5, -0.48681f)]
        [TestCase(0.00014015718f, 5, 0.00014015f)]
        [TestCase(-0.00014015718f, 5, -0.00014015f)]
        public void ToDigits_SingleExamples_CorrectResult(float value, int digits, float expected)
        {
            //arrange

            //act
            var result = Truncate.ToDigits(value, digits);

            //assert
            result.Should().Be(expected);
        }
    }
}
