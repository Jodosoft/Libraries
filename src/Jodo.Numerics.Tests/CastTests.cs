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
            N input = MathN.Truncate(Random.NextNumeric(
                ConvertN.ToNumeric<N>(byte.MinValue, Conversion.Clamp), ConvertN.ToNumeric<N>(byte.MaxValue, Conversion.Clamp)));

            //act
            N result = ConvertN.ToNumeric<N>(ConvertN.ToByte(input, Conversion.Cast), Conversion.Cast);

            //assert
            result.Should().Be(input);
        }

        [Test, Repeat(RandomVariations)]
        public void ToDecimal_SmallValueRoundTrip_SameValue()
        {
            //arrange
            N input = MathN.Round(Random.NextNumeric(ConvertN.ToNumeric<N>(-10M, Conversion.Clamp), ConvertN.ToNumeric<N>(10M, Conversion.Clamp)), 2);

            //act
            N result = ConvertN.ToNumeric<N>(ConvertN.ToDecimal(input, Conversion.Cast), Conversion.Cast);

            //assert
            result.Should().BeApproximately(input);
        }

        [Test, Repeat(RandomVariations)]
        public void ToDouble_SmallValueRoundTrip_SameValue()
        {
            //arrange
            N input = MathN.Round(Random.NextNumeric(ConvertN.ToNumeric<N>(-10.0, Conversion.Clamp), ConvertN.ToNumeric<N>(10.0, Conversion.Clamp)), 2);

            //act
            N result = ConvertN.ToNumeric<N>(ConvertN.ToDouble(input, Conversion.Cast), Conversion.Cast);

            //assert
            result.Should().BeApproximately(input);
        }

        [Test, Repeat(RandomVariations)]
        public void ToInt16_RoundTrip_SameValue()
        {
            //arrange
            N input = MathN.Truncate(Random.NextNumeric(
                ConvertN.ToNumeric<N>(short.MinValue, Conversion.Clamp), ConvertN.ToNumeric<N>(short.MaxValue, Conversion.Clamp)));

            //act
            N result = ConvertN.ToNumeric<N>(ConvertN.ToInt16(input, Conversion.Cast), Conversion.Cast);

            //assert
            result.Should().Be(input);
        }

        [Test, Repeat(RandomVariations)]
        public void ToInt32_RoundTrip_SameValue()
        {
            //arrange
            N input = MathN.Truncate(Random.NextNumeric(
                ConvertN.ToNumeric<N>(int.MinValue, Conversion.Clamp), ConvertN.ToNumeric<N>(int.MaxValue, Conversion.Clamp)));

            //act
            N result = ConvertN.ToNumeric<N>(ConvertN.ToInt32(input, Conversion.Cast), Conversion.Cast);

            //assert
            result.Should().Be(input);
        }

        [Test, Repeat(RandomVariations)]
        public void ToInt64_RoundTrip_SameValue()
        {
            //arrange
            N input = MathN.Truncate(Random.NextNumeric(
                ConvertN.ToNumeric<N>(long.MinValue, Conversion.Clamp), ConvertN.ToNumeric<N>(long.MaxValue, Conversion.Clamp)));

            //act
            N result = ConvertN.ToNumeric<N>(ConvertN.ToInt64(input, Conversion.Cast), Conversion.Cast);

            //assert
            result.Should().Be(input);
        }

        [Test, Repeat(RandomVariations)]
        public void ToSByte_RoundTrip_SameValue()
        {
            //arrange
            N input = MathN.Truncate(Random.NextNumeric(
                ConvertN.ToNumeric<N>(sbyte.MinValue, Conversion.Clamp), ConvertN.ToNumeric<N>(sbyte.MaxValue, Conversion.Clamp)));

            //act
            N result = ConvertN.ToNumeric<N>(ConvertN.ToSByte(input, Conversion.Cast), Conversion.Cast);

            //assert
            result.Should().Be(input);
        }

        [Test, Repeat(RandomVariations)]
        public void ToSingle_SmallValueRoundTrip_SameValue()
        {
            //arrange
            N input = MathN.Round(Random.NextNumeric(ConvertN.ToNumeric<N>(-10f, Conversion.Clamp), ConvertN.ToNumeric<N>(10f, Conversion.Clamp)), 2);

            //act
            N result = ConvertN.ToNumeric<N>(ConvertN.ToSingle(input, Conversion.Cast), Conversion.Cast);

            //assert
            result.Should().BeApproximately(input);
        }

        [Test, Repeat(RandomVariations)]
        public void ToUInt16_RoundTrip_SameValue()
        {
            //arrange
            N input = MathN.Truncate(Random.NextNumeric(
                ConvertN.ToNumeric<N>(ushort.MinValue, Conversion.Clamp), ConvertN.ToNumeric<N>(ushort.MaxValue, Conversion.Clamp)));

            //act
            N result = ConvertN.ToNumeric<N>(ConvertN.ToUInt16(input, Conversion.Cast), Conversion.Cast);

            //assert
            result.Should().Be(input);
        }

        [Test, Repeat(RandomVariations)]
        public void ToUInt32_RoundTrip_SameValue()
        {
            //arrange
            N input = MathN.Truncate(Random.NextNumeric(
                ConvertN.ToNumeric<N>(uint.MinValue, Conversion.Clamp), ConvertN.ToNumeric<N>(uint.MaxValue, Conversion.Clamp)));

            //act
            N result = ConvertN.ToNumeric<N>(ConvertN.ToUInt32(input, Conversion.Cast), Conversion.Cast);

            //assert
            result.Should().Be(input);
        }

        [Test, Repeat(RandomVariations)]
        public void ToUInt64_RoundTrip_SameValue()
        {
            //arrange
            N input = MathN.Truncate(Random.NextNumeric(
                ConvertN.ToNumeric<N>(ulong.MinValue, Conversion.Clamp), ConvertN.ToNumeric<N>(ulong.MaxValue, Conversion.Clamp)));

            //act
            N result = ConvertN.ToNumeric<N>(ConvertN.ToUInt64(input, Conversion.Cast), Conversion.Cast);

            //assert
            result.Should().Be(input);
        }
    }
}
