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
    public abstract class CastTests<N> : GlobalFixtureBase where N : struct, INumericExtended<N>
    {
        [Test, Repeat(RandomVariations)]
        public void ToByte_RoundTrip_SameValue()
        {
            //arrange
            N input = Math<N>.Truncate(Random.NextNumeric(
                Convert<N>.ToNumeric(byte.MinValue, Conversion.Clamp), Convert<N>.ToNumeric(byte.MaxValue, Conversion.Clamp)));

            //act
            N result = Convert<N>.ToNumeric(Convert<N>.ToByte(input, Conversion.Cast), Conversion.Cast);

            //assert
            result.Should().Be(input);
        }

        [Test, Repeat(RandomVariations)]
        public void ToDecimal_SmallValueRoundTrip_SameValue()
        {
            //arrange
            N input = Math<N>.Round(Random.NextNumeric(Convert<N>.ToNumeric(-10M, Conversion.Clamp), Convert<N>.ToNumeric(10M, Conversion.Clamp)), 2);

            //act
            N result = Convert<N>.ToNumeric(Convert<N>.ToDecimal(input, Conversion.Cast), Conversion.Cast);

            //assert
            result.Should().BeApproximately(input);
        }

        [Test, Repeat(RandomVariations)]
        public void ToDouble_SmallValueRoundTrip_SameValue()
        {
            //arrange
            N input = Math<N>.Round(Random.NextNumeric(Convert<N>.ToNumeric(-10.0, Conversion.Clamp), Convert<N>.ToNumeric(10.0, Conversion.Clamp)), 2);

            //act
            N result = Convert<N>.ToNumeric(Convert<N>.ToDouble(input, Conversion.Cast), Conversion.Cast);

            //assert
            result.Should().BeApproximately(input);
        }

        [Test, Repeat(RandomVariations)]
        public void ToInt16_RoundTrip_SameValue()
        {
            //arrange
            N input = Math<N>.Truncate(Random.NextNumeric(
                Convert<N>.ToNumeric(short.MinValue, Conversion.Clamp), Convert<N>.ToNumeric(short.MaxValue, Conversion.Clamp)));

            //act
            N result = Convert<N>.ToNumeric(Convert<N>.ToInt16(input, Conversion.Cast), Conversion.Cast);

            //assert
            result.Should().Be(input);
        }

        [Test, Repeat(RandomVariations)]
        public void ToInt32_RoundTrip_SameValue()
        {
            //arrange
            N input = Math<N>.Truncate(Random.NextNumeric(
                Convert<N>.ToNumeric(int.MinValue, Conversion.Clamp), Convert<N>.ToNumeric(int.MaxValue, Conversion.Clamp)));

            //act
            N result = Convert<N>.ToNumeric(Convert<N>.ToInt32(input, Conversion.Cast), Conversion.Cast);

            //assert
            result.Should().Be(input);
        }

        [Test, Repeat(RandomVariations)]
        public void ToInt64_RoundTrip_SameValue()
        {
            //arrange
            N input = Math<N>.Truncate(Random.NextNumeric(
                Convert<N>.ToNumeric(long.MinValue, Conversion.Clamp), Convert<N>.ToNumeric(long.MaxValue, Conversion.Clamp)));

            //act
            N result = Convert<N>.ToNumeric(Convert<N>.ToInt64(input, Conversion.Cast), Conversion.Cast);

            //assert
            result.Should().Be(input);
        }

        [Test, Repeat(RandomVariations)]
        public void ToSByte_RoundTrip_SameValue()
        {
            //arrange
            N input = Math<N>.Truncate(Random.NextNumeric(
                Convert<N>.ToNumeric(sbyte.MinValue, Conversion.Clamp), Convert<N>.ToNumeric(sbyte.MaxValue, Conversion.Clamp)));

            //act
            N result = Convert<N>.ToNumeric(ConvertExtended<N>.ToSByte(input, Conversion.Cast), Conversion.Cast);

            //assert
            result.Should().Be(input);
        }

        [Test, Repeat(RandomVariations)]
        public void ToSingle_SmallValueRoundTrip_SameValue()
        {
            //arrange
            N input = Math<N>.Round(Random.NextNumeric(Convert<N>.ToNumeric(-10f, Conversion.Clamp), Convert<N>.ToNumeric(10f, Conversion.Clamp)), 2);

            //act
            N result = Convert<N>.ToNumeric(Convert<N>.ToSingle(input, Conversion.Cast), Conversion.Cast);

            //assert
            result.Should().BeApproximately(input);
        }

        [Test, Repeat(RandomVariations)]
        public void ToUInt16_RoundTrip_SameValue()
        {
            //arrange
            N input = Math<N>.Truncate(Random.NextNumeric(
                Convert<N>.ToNumeric(ushort.MinValue, Conversion.Clamp), Convert<N>.ToNumeric(ushort.MaxValue, Conversion.Clamp)));

            //act
            N result = Convert<N>.ToNumeric(ConvertExtended<N>.ToUInt16(input, Conversion.Cast), Conversion.Cast);

            //assert
            result.Should().Be(input);
        }

        [Test, Repeat(RandomVariations)]
        public void ToUInt32_RoundTrip_SameValue()
        {
            //arrange
            N input = Math<N>.Truncate(Random.NextNumeric(
                Convert<N>.ToNumeric(uint.MinValue, Conversion.Clamp), Convert<N>.ToNumeric(uint.MaxValue, Conversion.Clamp)));

            //act
            N result = Convert<N>.ToNumeric(ConvertExtended<N>.ToUInt32(input, Conversion.Cast), Conversion.Cast);

            //assert
            result.Should().Be(input);
        }

        [Test, Repeat(RandomVariations)]
        public void ToUInt64_RoundTrip_SameValue()
        {
            //arrange
            N input = Math<N>.Truncate(Random.NextNumeric(
                ConvertExtended<N>.ToNumeric(ulong.MinValue, Conversion.Clamp), ConvertExtended<N>.ToNumeric(ulong.MaxValue, Conversion.Clamp)));

            //act
            N result = ConvertExtended<N>.ToNumeric(ConvertExtended<N>.ToUInt64(input, Conversion.Cast), Conversion.Cast);

            //assert
            result.Should().Be(input);
        }
    }
}
