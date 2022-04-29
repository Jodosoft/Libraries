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
using Jodo.Extensions.Primitives;
using NUnit.Framework;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Jodo.Extensions.CheckedNumerics.Tests
{
    public class NumericTests : AssemblyTestBase
    {
        static readonly object[] AllNumericTypes =
        {
            default(cfloat),
            default(cdouble),
            default(cint),
            default(ucint),
            //default(fix64),
            //default(ufix64),
        };

        [TestCaseSource(nameof(AllNumericTypes))]
        public void Serialize_RoundTrip_SameAsOriginal<T>(T _) where T : struct, INumeric<T>
        {
            //arrange
            var input = Random.NextNumeric<T>();
            var formatter = new BinaryFormatter();

            //act
            using var stream = new MemoryStream();
            formatter.Serialize(stream, input);
            stream.Position = 0;
            var result = (T)formatter.Deserialize(stream);

            //assert
            result.Should().Be(input);
        }

        [TestCaseSource(nameof(AllNumericTypes))]
        public void GetBytes_RoundTrip_SameAsOriginal<T>(T _) where T : struct, INumeric<T>
        {
            //arrange
            var input = Random.NextNumeric<T>();

            //act
            var result = BitConverter<T>.FromBytes(BitConverter<T>.GetBytes(input));

            //assert
            result.Should().Be(input);
        }

        [TestCaseSource(nameof(AllNumericTypes))]
        public void GetBytes_Random_CorrectSize<T>(T _) where T : struct, INumeric<T>
        {
            //arrange
            var input = Random.NextNumeric<T>();

            //act
            var result = BitConverter<T>.GetBytes(input);

            //assert
            result.Length.Should().Be(BitConverter<T>.Size);
        }

        [TestCaseSource(nameof(AllNumericTypes))]
        public void GetBytes_Zero_AllZero<T>(T _) where T : struct, INumeric<T>
        {
            //arrange
            var input = Math<T>.Zero;

            //act
            var result = BitConverter<T>.GetBytes(input);

            //assert
            result.ToArray().Should().AllBeEquivalentTo(0);
        }

        [TestCaseSource(nameof(AllNumericTypes))]
        public void GetBytes_NonZero_NotAllZero<T>(T _) where T : struct, INumeric<T>
        {
            //arrange
            T input;
            while ((input = Random.NextNumeric<T>()).Equals(Math<T>.Zero)) { }

            //act
            var result = BitConverter<T>.GetBytes(input);

            //assert
            result.ToArray().Should().Contain(x => x != 0);
        }

        [TestCaseSource(nameof(AllNumericTypes))]
        public void Increment_AtMaxValue_ResultIsMaxValue<T>(T _) where T : struct, INumeric<T>
        {
            //arrange
            var input = Math<T>.MaxValue;

            //act
            var result = input + 1;

            //assert
            result.Should().Be(Math<T>.MaxValue);
        }

        [TestCaseSource(nameof(AllNumericTypes))]
        public void Decrement_AtMinValue_ResultIsMaxValue<T>(T _) where T : struct, INumeric<T>
        {
            //arrange
            var input = Math<T>.MinValue;

            //act
            var result = input - 1;

            //assert
            result.Should().Be(Math<T>.MinValue);
        }

        [TestCaseSource(nameof(AllNumericTypes))]
        public void Divide_ByOne_SameAsOriginal<T>(T _) where T : struct, INumeric<T>
        {
            //arrange
            var input = Random.NextNumeric<T>();

            //act
            var result = input / 1;

            //assert
            result.Should().Be(input);
        }

        [TestCaseSource(nameof(AllNumericTypes))]
        public void Multiply_By1_SameAsOriginal<T>(T _) where T : struct, INumeric<T>
        {
            //arrange
            var input = Random.NextNumeric<T>() * 1;

            //act
            var result = input * 1;

            //assert
            result.Should().Be(input);
        }

        [TestCaseSource(nameof(AllNumericTypes))]
        public void Divide_ByZero_ReturnsMaxValue<T>(T _) where T : struct, INumeric<T>
        {
            //arrange
            var input = Random.NextNumeric<T>();

            //act
            var result = input / 0;

            //assert
            result.Should().Be(Math<T>.MaxValue);
        }

        [TestCaseSource(nameof(AllNumericTypes)), Ignore("WIP")]
        public void Add_Random_CorrectResult<T>(T _) where T : struct, INumeric<T>
        {
            //arrange
            var left = Random.NextByte();
            var right = Random.NextByte();

            //act
            var result = Math<T>.Convert(left) + Math<T>.Convert(right);

            //assert
            result.Should().Be(left + right);
        }

        [TestCaseSource(nameof(AllNumericTypes))]
        public void Multiply_RandomValues_CorrectResult<T>(T _) where T : struct, INumeric<T>
        {
            //arrange
            var left = Random.NextByte();
            var right = Random.NextByte();

            //act
            var result = Math<T>.Convert(left) * Math<T>.Convert(right);

            //assert
            result.Should().Be(left * right);
        }
    }
}
