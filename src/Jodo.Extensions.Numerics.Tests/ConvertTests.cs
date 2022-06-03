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

namespace Jodo.Extensions.Numerics.Tests
{
    public abstract class ConvertTests<N> : AssemblyFixtureBase where N : struct, INumeric<N>
    {
        [Test, Repeat(RandomVariations)]
        public void ToBoolean_RoundTrip_SameValue()
        {
            //arrange
            var input = Random.NextBoolean();

            //act
            var result = Convert<N>.ToBoolean(Convert<N>.ToNumeric(input));

            //assert
            result.Should().Be(input);
        }
        [Test, Repeat(RandomVariations)]
        public void ToByte_RoundTrip_SameValue()
        {
            //arrange
            var input = Math<N>.Truncate(Random.NextNumeric(
                Clamp<N>.ToNumeric(byte.MinValue), Clamp<N>.ToNumeric(byte.MaxValue)));

            //act
            var result = Convert<N>.ToNumeric(Convert<N>.ToByte(input));

            //assert
            result.Should().Be(input);
        }

        [Test, Repeat(RandomVariations)]
        public void ToDecimal_SmallValueRoundTrip_SameValue()
        {
            //arrange
            var input = Math<N>.Round(Random.NextNumeric(Clamp<N>.ToNumeric(-10M), Clamp<N>.ToNumeric(10M)), 2);

            //act
            var result = Convert<N>.ToNumeric(Convert<N>.ToDecimal(input));

            //assert
            result.Should().BeApproximately(input);
        }

        [Test, Repeat(RandomVariations)]
        public void ToDouble_SmallValueRoundTrip_SameValue()
        {
            //arrange
            var input = Math<N>.Round(Random.NextNumeric(Clamp<N>.ToNumeric(-10.0), Clamp<N>.ToNumeric(10.0)), 2);

            //act
            var result = Convert<N>.ToNumeric(Convert<N>.ToDouble(input));

            //assert
            result.Should().BeApproximately(input);
        }

        [Test, Repeat(RandomVariations)]
        public void ToInt16_RoundTrip_SameValue()
        {
            //arrange
            var input = Math<N>.Truncate(Random.NextNumeric(
                Clamp<N>.ToNumeric(short.MinValue), Clamp<N>.ToNumeric(short.MaxValue)));

            //act
            var result = Convert<N>.ToNumeric(Convert<N>.ToInt16(input));

            //assert
            result.Should().Be(input);
        }

        [Test, Repeat(RandomVariations)]
        public void ToInt32_RoundTrip_SameValue()
        {
            //arrange
            var input = Math<N>.Truncate(Random.NextNumeric(
                Clamp<N>.ToNumeric(int.MinValue), Clamp<N>.ToNumeric(int.MaxValue)));

            //act
            var result = Convert<N>.ToNumeric(Convert<N>.ToInt32(input));

            //assert
            result.Should().Be(input);
        }

        [Test, Repeat(RandomVariations)]
        public void ToInt64_RoundTrip_SameValue()
        {
            //arrange
            var input = Math<N>.Truncate(Random.NextNumeric(
                Clamp<N>.ToNumeric(long.MinValue), Clamp<N>.ToNumeric(long.MaxValue)));

            //act
            var result = Convert<N>.ToNumeric(Convert<N>.ToInt64(input));

            //assert
            result.Should().Be(input);
        }

        [Test, Repeat(RandomVariations)]
        public void ToSByte_RoundTrip_SameValue()
        {
            //arrange
            var input = Math<N>.Truncate(Random.NextNumeric(
                Clamp<N>.ToNumeric(sbyte.MinValue), Clamp<N>.ToNumeric(sbyte.MaxValue)));

            //act
            var result = Convert<N>.ToNumeric(Convert<N>.ToSByte(input));

            //assert
            result.Should().Be(input);
        }

        [Test, Repeat(RandomVariations)]
        public void ToSingle_SmallValueRoundTrip_SameValue()
        {
            //arrange
            var input = Math<N>.Round(Random.NextNumeric(Clamp<N>.ToNumeric(-10f), Clamp<N>.ToNumeric(10f)), 2);

            //act
            var result = Convert<N>.ToNumeric(Convert<N>.ToSingle(input));

            //assert
            result.Should().BeApproximately(input);
        }

        [Test, Repeat(RandomVariations)]
        public void ToUInt16_RoundTrip_SameValue()
        {
            //arrange
            var input = Math<N>.Truncate(Random.NextNumeric(
                Clamp<N>.ToNumeric(ushort.MinValue), Clamp<N>.ToNumeric(ushort.MaxValue)));

            //act
            var result = Convert<N>.ToNumeric(Convert<N>.ToUInt16(input));

            //assert
            result.Should().Be(input);
        }

        [Test, Repeat(RandomVariations)]
        public void ToUInt32_RoundTrip_SameValue()
        {
            //arrange
            var input = Math<N>.Truncate(Random.NextNumeric(
                Clamp<N>.ToNumeric(uint.MinValue), Clamp<N>.ToNumeric(uint.MaxValue)));

            //act
            var result = Convert<N>.ToNumeric(Convert<N>.ToUInt32(input));

            //assert
            result.Should().Be(input);
        }

        [Test, Repeat(RandomVariations)]
        public void ToUInt64_RoundTrip_SameValue()
        {
            //arrange
            var input = Math<N>.Truncate(Random.NextNumeric(
                Clamp<N>.ToNumeric(ulong.MinValue), Clamp<N>.ToNumeric(ulong.MaxValue)));

            //act
            var result = Convert<N>.ToNumeric(Convert<N>.ToUInt64(input));

            //assert
            result.Should().Be(input);
        }

        [Test, Repeat(RandomVariations)]
        public void ToString1_Random_SameAsObjectToString()
        {
            //arrange
            var input = Random.NextNumeric<N>();

            //act
            var result = Convert<N>.ToString(input);

            //assert
            result.Should().Be(input.ToString());
        }
    }
}
