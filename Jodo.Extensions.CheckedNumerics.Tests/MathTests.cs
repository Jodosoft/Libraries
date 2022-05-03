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
using NUnit.Framework;
using System;

namespace Jodo.Extensions.CheckedNumerics.Tests
{
    public class MathTests : AssemblyTestBase
    {
        [TestCaseSource(nameof(TestCases_IntegralTypes))]
        public void Pi_IntegralTypes_ReturnsThree<T>(T _) where T : struct, INumeric<T>
        {
            //arrange

            //act
            var result = Math<T>.Pi;

            //assert
            result.Should().Be(Math<T>.Convert(3));
        }

        [TestCaseSource(nameof(TestCases_RealTypes))]
        public void Pi_RealTypes_ReturnsPi<T>(T _) where T : struct, INumeric<T>
        {
            //arrange

            //act
            var result = Math<T>.Pi.Approximate(0);

            //assert
            result.Should().BeApproximately(MathF.PI, 0.000000000000000000f);
        }

        [TestCaseSource(nameof(TestCases_IntegralTypes))]
        public void E_IntegralTypes_ReturnsTwo<T>(T _) where T : struct, INumeric<T>
        {
            //arrange

            //act
            var result = Math<T>.E;

            //assert
            result.Should().Be(Math<T>.Convert(2));
        }

        [TestCaseSource(nameof(TestCases_RealTypes))]
        public void E_RealTypes_ReturnsE<T>(T _) where T : struct, INumeric<T>
        {
            //arrange

            //act
            var result = Math<T>.Pi.Approximate(0);

            //assert
            result.Should().BeApproximately(MathF.PI, 0.000000000000000000f);
        }

        [TestCaseSource(nameof(TestCases_AllNumericTypes))]
        public void Zero_IntegralTypes_ReturnsZero<T>(T _) where T : struct, INumeric<T>
        {
            //arrange

            //act
            var result = Math<T>.Zero;

            //assert
            result.Should().Be(Math<T>.Convert(0));
        }

        [TestCaseSource(nameof(TestCases_AllNumericTypes))]
        public void Epsilon__AllTypes_GreaterThanZero<T>(T _) where T : struct, INumeric<T>
        {
            //arrange

            //act
            var result = Math<T>.Epsilon;

            //assert
            result.Should().BeGreaterThan(Math<T>.Convert(0));
        }

        [TestCaseSource(nameof(TestCases_AllNumericTypes))]
        public void Sqrt_RandomValue_CorrectResult<T>(T _) where T : struct, INumeric<T>
        {
            //arrange
            var input = Random.NextByte(2, 15);
            var inputSquared = (byte)(input * input);

            //act
            var result = Math<T>.Sqrt(Math<T>.Convert(inputSquared));

            //assert
            result.Should().Be(Math<T>.Convert(input));
        }

        [TestCaseSource(nameof(TestCases_AllNumericTypes))]
        public void Pow_ByTwo_CorrectResult<T>(T _) where T : struct, INumeric<T>
        {
            //arrange
            var input = Random.NextByte(2, 15);
            var inputSquared = (byte)(input * input);

            //act
            var result = Math<T>.Pow(Math<T>.Convert(input), 2);

            //assert
            result.Should().Be(Math<T>.Convert(inputSquared));
        }

        [TestCaseSource(nameof(TestCases_SignedNumericTypes))]
        public void Pow_NegativeByTwo_CorrectResult<T>(T _) where T : struct, INumeric<T>
        {
            //arrange
            var input = Random.NextByte(2, 15);
            var inputSquared = (byte)(input * input);

            //act
            var result = Math<T>.Pow(-Math<T>.Convert(input), 2);

            //assert
            result.Should().Be(Math<T>.Convert(inputSquared));
        }

        [TestCaseSource(nameof(TestCases_SignedNumericTypes))]
        public void Abs_RandomNegativeValue_SameAsPositive<T>(T _) where T : struct, INumeric<T>
        {
            //arrange
            var input = Random.NextNumeric(Math<T>.Zero - 1, Math<T>.MinValue);

            //act
            var result = Math<T>.Abs(input);

            //assert
            result.Should().Be(-input);
        }

        [TestCaseSource(nameof(TestCases_AllNumericTypes))]
        public void Abs_RandomNonNegativeValue_SameAsInput<T>(T _) where T : struct, INumeric<T>
        {
            //arrange
            var input = Random.NextNumeric<T>(Math<T>.Zero, Math<T>.MaxValue);

            //act
            var result = Math<T>.Abs(input);

            //assert
            result.Should().Be(input);
        }
    }
}
