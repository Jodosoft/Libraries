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
using System;

namespace Jodo.Extensions.Primitives.Tests
{
    public abstract class ConvertTestsBase<T> : GlobalTestBase where T : IConvertible<T>, IRandomisable<T>, new()
    {
        [Test]
        public void Boolean_RoundTrip_SameValue()
        {
            //arrange
            var input = Random.NextBoolean();

            //act
            var result = Convert<T>.ToBoolean(Convert<T>.ToValue(input));

            //assert
            result.Should().Be(input);
        }

        [Test]
        public void Byte_RoundTrip_SameValue()
        {
            //arrange
            var input = Random.NextByte(0, 100);

            //act
            var result = Convert<T>.ToByte(Convert<T>.ToValue(input));

            //assert
            result.Should().Be(input);
        }

        [Test, Ignore("todo")]
        public void Char_RoundTrip_SameValue()
        {
            //arrange
            var input = (char)Random.NextByte(0, 100);

            //act
            var result = Convert<T>.ToChar(Convert<T>.ToValue(input));

            //assert
            result.Should().Be(input);
        }

        [Test, Ignore("todo")]
        public void Decimal_RoundTrip_SameValue()
        {
            //arrange
            var input = Random.NextDecimal(0, 100);

            //act
            var result = Convert<T>.ToDecimal(Convert<T>.ToValue(input));

            //assert
            result.Should().Be(input);
        }

        [Test, Ignore("todo")]
        public void Double_RoundTrip_SameValue()
        {
            //arrange
            var input = Random.NextDouble(0, 100);

            //act
            var result = Convert<T>.ToDouble(Convert<T>.ToValue(input));

            //assert
            result.Should().Be(input);
        }

        [Test]
        public void Int16_RoundTrip_SameValue()
        {
            //arrange
            var input = Random.NextInt16(0, 100);

            //act
            var result = Convert<T>.ToInt16(Convert<T>.ToValue(input));

            //assert
            result.Should().Be(input);
        }

        [Test]
        public void Int32_RoundTrip_SameValue()
        {
            //arrange
            var input = Random.NextInt32(0, 100);

            //act
            var result = Convert<T>.ToInt32(Convert<T>.ToValue(input));

            //assert
            result.Should().Be(input);
        }

        [Test]
        public void Int64_RoundTrip_SameValue()
        {
            //arrange
            var input = Random.NextInt64(0, 100);

            //act
            var result = Convert<T>.ToInt64(Convert<T>.ToValue(input));

            //assert
            result.Should().Be(input);
        }

        [Test]
        public void SByte_RoundTrip_SameValue()
        {
            //arrange
            var input = Random.NextSByte(0, 100);

            //act
            var result = Convert<T>.ToSByte(Convert<T>.ToValue(input));

            //assert
            result.Should().Be(input);
        }

        [Test, Ignore("todo")]
        public void Single_RoundTrip_SameValue()
        {
            //arrange
            var input = Random.NextSingle(0, 100);

            //act
            var result = Convert<T>.ToSingle(Convert<T>.ToValue(input));

            //assert
            result.Should().Be(input);
        }

        [Test]
        public void UInt16_RoundTrip_SameValue()
        {
            //arrange
            var input = Random.NextUInt16(0, 100);

            //act
            var result = Convert<T>.ToUInt16(Convert<T>.ToValue(input));

            //assert
            result.Should().Be(input);
        }

        [Test]
        public void UInt32_RoundTrip_SameValue()
        {
            //arrange
            var input = Random.NextUInt32(0, 100);

            //act
            var result = Convert<T>.ToUInt32(Convert<T>.ToValue(input));

            //assert
            result.Should().Be(input);
        }

        [Test]
        public void UInt64_RoundTrip_SameValue()
        {
            //arrange
            var input = Random.NextUInt64(0, 100);

            //act
            var result = Convert<T>.ToUInt64(Convert<T>.ToValue(input));

            //assert
            result.Should().Be(input);
        }
    }
}
