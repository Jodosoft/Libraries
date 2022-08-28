﻿// Copyright (c) 2022 Joseph J. Short
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
    public abstract class NumericCastTestBase<TNumeric> : GlobalFixtureBase where TNumeric : struct, INumericExtended<TNumeric>
    {
        [Test, Repeat(RandomVariations)]
        public void ToByte_RoundTrip_SameValue()
        {
            //arrange
            TNumeric input = MathN.Truncate(Random.NextNumeric(
                ConvertN.ToNumeric<TNumeric>(byte.MinValue, Conversion.Clamp),
                ConvertN.ToNumeric<TNumeric>(byte.MaxValue, Conversion.Clamp),
                Generation.Extended));

            //act
            TNumeric result = ConvertN.ToNumeric<TNumeric>(ConvertN.ToByte(input, Conversion.Cast), Conversion.Cast);

            //assert
            result.Should().Be(input);
        }

        [Test, Repeat(RandomVariations)]
        public void ToDecimal_SmallValueRoundTrip_SameValue()
        {
            //arrange
            TNumeric input = MathN.Round(Random.NextNumeric(
                ConvertN.ToNumeric<TNumeric>(-10M, Conversion.Clamp),
                ConvertN.ToNumeric<TNumeric>(10M, Conversion.Clamp),
                Generation.Extended), 2);

            //act
            TNumeric result = ConvertN.ToNumeric<TNumeric>(ConvertN.ToDecimal(input, Conversion.Cast), Conversion.Cast);

            //assert
            result.Should().BeApproximately(input);
        }

        [Test, Repeat(RandomVariations)]
        public void ToDouble_SmallValueRoundTrip_SameValue()
        {
            //arrange
            TNumeric input = MathN.Round(
                Random.NextNumeric(
                    ConvertN.ToNumeric<TNumeric>(-10.0, Conversion.Clamp),
                    ConvertN.ToNumeric<TNumeric>(10.0, Conversion.Clamp),
                    Generation.Extended), 2);

            //act
            TNumeric result = ConvertN.ToNumeric<TNumeric>(ConvertN.ToDouble(input, Conversion.Cast), Conversion.Cast);

            //assert
            result.Should().BeApproximately(input);
        }

        [Test, Repeat(RandomVariations)]
        public void ToInt16_RoundTrip_SameValue()
        {
            //arrange
            TNumeric input = MathN.Truncate(Random.NextNumeric(
                ConvertN.ToNumeric<TNumeric>(short.MinValue, Conversion.Clamp),
                ConvertN.ToNumeric<TNumeric>(short.MaxValue, Conversion.Clamp),
                Generation.Extended));

            //act
            TNumeric result = ConvertN.ToNumeric<TNumeric>(ConvertN.ToInt16(input, Conversion.Cast), Conversion.Cast);

            //assert
            result.Should().Be(input);
        }

        [Test, Repeat(RandomVariations)]
        public void ToInt32_RoundTrip_SameValue()
        {
            //arrange
            TNumeric input = MathN.Truncate(Random.NextNumeric(
                ConvertN.ToNumeric<TNumeric>(int.MinValue, Conversion.Clamp),
                ConvertN.ToNumeric<TNumeric>(int.MaxValue, Conversion.Clamp),
                Generation.Extended));

            //act
            TNumeric result = ConvertN.ToNumeric<TNumeric>(ConvertN.ToInt32(input, Conversion.Cast), Conversion.Cast);

            //assert
            result.Should().Be(input);
        }

        [Test, Repeat(RandomVariations)]
        public void ToInt64_RoundTrip_SameValue()
        {
            //arrange
            TNumeric input = MathN.Truncate(Random.NextNumeric(
                ConvertN.ToNumeric<TNumeric>(long.MinValue, Conversion.Clamp),
                ConvertN.ToNumeric<TNumeric>(long.MaxValue, Conversion.Clamp),
                Generation.Extended));

            //act
            TNumeric result = ConvertN.ToNumeric<TNumeric>(ConvertN.ToInt64(input, Conversion.Cast), Conversion.Cast);

            //assert
            result.Should().Be(input);
        }

        [Test, Repeat(RandomVariations)]
        public void ToSByte_RoundTrip_SameValue()
        {
            //arrange
            TNumeric input = MathN.Truncate(Random.NextNumeric(
                ConvertN.ToNumeric<TNumeric>(sbyte.MinValue, Conversion.Clamp),
                ConvertN.ToNumeric<TNumeric>(sbyte.MaxValue, Conversion.Clamp),
                Generation.Extended));

            //act
            TNumeric result = ConvertN.ToNumeric<TNumeric>(ConvertN.ToSByte(input, Conversion.Cast), Conversion.Cast);

            //assert
            result.Should().Be(input);
        }

        [Test, Repeat(RandomVariations)]
        public void ToSingle_SmallValueRoundTrip_SameValue()
        {
            //arrange
            TNumeric input = MathN.Round(Random.NextNumeric(
                ConvertN.ToNumeric<TNumeric>(-10f, Conversion.Clamp),
                ConvertN.ToNumeric<TNumeric>(10f, Conversion.Clamp),
                Generation.Extended), 2);

            //act
            TNumeric result = ConvertN.ToNumeric<TNumeric>(ConvertN.ToSingle(input, Conversion.Cast), Conversion.Cast);

            //assert
            result.Should().BeApproximately(input);
        }

        [Test, Repeat(RandomVariations)]
        public void ToUInt16_RoundTrip_SameValue()
        {
            //arrange
            TNumeric input = MathN.Truncate(Random.NextNumeric(
                ConvertN.ToNumeric<TNumeric>(ushort.MinValue, Conversion.Clamp),
                ConvertN.ToNumeric<TNumeric>(ushort.MaxValue, Conversion.Clamp),
                Generation.Extended));

            //act
            TNumeric result = ConvertN.ToNumeric<TNumeric>(ConvertN.ToUInt16(input, Conversion.Cast), Conversion.Cast);

            //assert
            result.Should().Be(input);
        }

        [Test, Repeat(RandomVariations)]
        public void ToUInt32_RoundTrip_SameValue()
        {
            //arrange
            TNumeric input = MathN.Truncate(Random.NextNumeric(
                ConvertN.ToNumeric<TNumeric>(uint.MinValue, Conversion.Clamp),
                ConvertN.ToNumeric<TNumeric>(uint.MaxValue, Conversion.Clamp),
                Generation.Extended));

            //act
            TNumeric result = ConvertN.ToNumeric<TNumeric>(ConvertN.ToUInt32(input, Conversion.Cast), Conversion.Cast);

            //assert
            result.Should().Be(input);
        }

        [Test, Repeat(RandomVariations)]
        public void ToUInt64_RoundTrip_SameValue()
        {
            //arrange
            TNumeric input = MathN.Truncate(Random.NextNumeric(
                ConvertN.ToNumeric<TNumeric>(ulong.MinValue, Conversion.Clamp),
                ConvertN.ToNumeric<TNumeric>(ulong.MaxValue, Conversion.Clamp),
                Generation.Extended));

            //act
            TNumeric result = ConvertN.ToNumeric<TNumeric>(ConvertN.ToUInt64(input, Conversion.Cast), Conversion.Cast);

            //assert
            result.Should().Be(input);
        }
    }
}
