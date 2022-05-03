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
    public class OperatorTests : AssemblyTestBase
    {
        [TestCaseSource(nameof(TestCases_AllNumericTypes))]
        public void Add_Random_CorrectResult<T>(T _) where T : struct, INumeric<T>
        {
            //arrange
            var left = Random.NextByte(0, 127);
            var right = Random.NextByte(0, 127);

            //act
            var result = Math<T>.Convert(left) + Math<T>.Convert(right);

            //assert
            result.Should().Be(Math<T>.Convert((byte)(left + right)));
        }

        [TestCaseSource(nameof(TestCases_AllNumericTypes))]
        public void Add_AtMaxValue_ResultIsMaxValue<T>(T _) where T : struct, INumeric<T>
        {
            //arrange
            var left = Math<T>.MaxValue;
            var right = Random.NextNumeric(Math<T>.One, Math<T>.MaxValue);

            //act
            var result = left + right;

            //assert
            result.Should().Be(Math<T>.MaxValue);
        }

        [TestCaseSource(nameof(TestCases_AllNumericTypes))]
        public void Subtract_AtMinValue_ResultIsMinValue<T>(T _) where T : struct, INumeric<T>
        {
            //arrange
            var left = Math<T>.MinValue;
            var right = Random.NextNumeric(Math<T>.One, Math<T>.MaxValue);

            //act
            var result = left - right;

            //assert
            result.Should().Be(Math<T>.MinValue);
        }

        [TestCaseSource(nameof(TestCases_AllNumericTypes))]
        public void Subtract_Random_CorrectResult<T>(T _) where T : struct, INumeric<T>
        {
            //arrange
            var left = Random.NextByte(0, 127);
            var right = Random.NextByte(0, left);

            //act
            var result = Math<T>.Convert(left) - Math<T>.Convert(right);

            //assert
            result.Should().Be(Math<T>.Convert((byte)(left - right)));
        }

        [TestCaseSource(nameof(TestCases_AllNumericTypes))]
        public void Multiply_RandomValues_CorrectResult<T>(T _) where T : struct, INumeric<T>
        {
            //arrange
            var left = Random.NextByte(0, 16);
            var right = Random.NextByte(0, 15);

            //act
            var result = Math<T>.Convert(left) * Math<T>.Convert(right);

            //assert
            result.Should().Be(Math<T>.Convert((byte)(left * right)));
        }

        [TestCaseSource(nameof(TestCases_SignedNumericTypes))]
        public void Negative_Twice_SameAsOriginal<T>(T _) where T : struct, INumeric<T>
        {
            //arrange
            var input = Random.NextNumeric<T>();

            //act
            var result = -(-input);

            //assert
            result.Should().Be(input);
        }

        [TestCaseSource(nameof(TestCases_AllNumericTypes))]
        public void Positive_SameAsOriginal<T>(T _) where T : struct, INumeric<T>
        {
            //arrange
            var input = Random.NextNumeric<T>();

            //act
            var result = +input;

            //assert
            result.Should().Be(input);
        }

        [TestCaseSource(nameof(TestCases_AllNumericTypes))]
        public void Multiply_ByZero_ReturnsZero<T>(T _) where T : struct, INumeric<T>
        {
            //arrange
            var input = Random.NextNumeric<T>();

            //act
            var result = input * 0;

            //assert
            result.Should().Be(Math<T>.Zero);
        }

        [TestCaseSource(nameof(TestCases_AllNumericTypes))]
        public void Multiply_By1_SameAsOriginal<T>(T _) where T : struct, INumeric<T>
        {
            //arrange
            var input = Random.NextNumeric<T>();

            //act
            var result = input * 1;

            //assert
            result.Should().Be(input);
        }

        [TestCaseSource(nameof(TestCases_AllNumericTypes))]
        public void Divide_ByOne_SameAsOriginal<T>(T _) where T : struct, INumeric<T>
        {
            //arrange
            var input = Random.NextNumeric<T>();

            //act
            var result = input / 1;

            //assert
            result.Should().Be(input);
        }

        [TestCaseSource(nameof(TestCases_AllNumericTypes))]
        public void Divide_ByZero_ReturnsMaxValue<T>(T _) where T : struct, INumeric<T>
        {
            //arrange
            var input = Random.NextNumeric<T>();

            //act
            var result = input / 0;

            //assert
            result.Should().Be(Math<T>.MaxValue);
        }

        [TestCaseSource(nameof(TestCases_AllNumericTypes))]
        public void Divide_RandomValues_CorrectResult<T>(T _) where T : struct, INumeric<T>
        {
            //arrange
            var left = (byte)128;
            var right = (byte)(2 << Random.Next(0, 7));

            //act
            var result = Math<T>.Convert(left) / Math<T>.Convert(right);

            //assert
            result.Should().Be(Math<T>.Convert((byte)(left / right)));
        }

        [TestCaseSource(nameof(TestCases_AllNumericTypes))]
        public void Remainder_RandomValues_CorrectResult<T>(T _) where T : struct, INumeric<T>
        {
            //arrange
            var left = (byte)128;
            var right = (byte)(2 << Random.Next(0, 7));

            //act
            var result = Math<T>.Convert(left) % Math<T>.Convert(right);

            //assert
            result.Should().Be(Math<T>.Convert((byte)(left % right)));
        }

        [TestCaseSource(nameof(TestCases_AllNumericTypes))]
        public void Remainder_ByZero_ReturnsMaxValue<T>(T _) where T : struct, INumeric<T>
        {
            //arrange
            var input = Random.NextNumeric<T>();

            //act
            var result = input % 0;

            //assert
            result.Should().Be(Math<T>.MaxValue);
        }
    }
}
