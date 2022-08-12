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
using System.Globalization;
using FluentAssertions;
using Jodo.Primitives;
using Jodo.Testing;
using NUnit.Framework;

namespace Jodo.Numerics.Tests
{
    public abstract class NumericIntegralTestBase<TNumeric> : GlobalFixtureBase where TNumeric : struct, INumeric<TNumeric>
    {
        [SetUp]
        public void SetUp() => Assert.That(Numeric.IsIntegral<TNumeric>());

        [Test]
        public void Epsilon_IsOne()
        {
            Numeric.Epsilon<TNumeric>().Should().Be(Numeric.One<TNumeric>());
        }

        [Test, Repeat(RandomVariations)]
        public void LogicalAnd_RandomIntegralValues_CorrectResult()
        {
            //arrange
            TNumeric left = ConvertN.ToNumeric<TNumeric>(Random.Next(-10, 10), Conversion.Clamp);
            TNumeric right = ConvertN.ToNumeric<TNumeric>(Random.Next(-10, 10), Conversion.Clamp);

            //act
            TNumeric result = left.LogicalAnd(right);

            //assert
            result.Should().BeApproximately(ConvertN.ToInt32(left, Conversion.Cast) & ConvertN.ToInt32(right, Conversion.Cast));
        }

        [Test, Repeat(RandomVariations)]
        public void LogicalOr_RandomIntegralValues_CorrectResult()
        {
            //arrange
            TNumeric left = ConvertN.ToNumeric<TNumeric>(Random.Next(-10, 10), Conversion.Clamp);
            TNumeric right = ConvertN.ToNumeric<TNumeric>(Random.Next(-10, 10), Conversion.Clamp);

            //act
            TNumeric result = left.LogicalOr(right);

            //assert
            result.Should().BeApproximately(ConvertN.ToInt32(left, Conversion.Cast) | ConvertN.ToInt32(right, Conversion.Cast));
        }

        [Test, Repeat(RandomVariations)]
        public void LogicalExclusiveOr_RandomIntegralValues_CorrectResult()
        {
            //arrange
            TNumeric left = ConvertN.ToNumeric<TNumeric>(Random.Next(-10, 10), Conversion.Clamp);
            TNumeric right = ConvertN.ToNumeric<TNumeric>(Random.Next(-10, 10), Conversion.Clamp);

            //act
            TNumeric result = left.LogicalExclusiveOr(right);

            //assert
            result.Should().BeApproximately(ConvertN.ToInt32(left, Conversion.Cast) ^ ConvertN.ToInt32(right, Conversion.Cast));
        }

        [Test, Repeat(RandomVariations)]
        public void BitwiseComplement_IntegralRoundTrip_SameValue()
        {
            //arrange
            TNumeric left = MathN.Round(ConvertN.ToNumeric<TNumeric>(Random.NextDouble(-10, 10), Conversion.Clamp), 2);

            //act
            TNumeric result = left.BitwiseComplement().BitwiseComplement();

            //assert
            result.Should().Be(left);
        }

        [Test, Repeat(RandomVariations)]
        public void BitwiseComplement_RandomIntegral_DifferentValue()
        {
            //arrange
            TNumeric left = MathN.Round(ConvertN.ToNumeric<TNumeric>(Random.NextDouble(-10, 10), Conversion.Clamp), 2);

            //act
            TNumeric result = left.BitwiseComplement();

            //assert
            result.Should().NotBe(left);
        }

        [Test, Repeat(RandomVariations)]
        public void LeftShift_RandomIntegralValues_CorrectResult()
        {
            //arrange
            TNumeric left = ConvertN.ToNumeric<TNumeric>(Random.Next(-10, 10), Conversion.Clamp);
            int right = Random.NextInt32(0, 2);

            //act
            TNumeric result = left.LeftShift(right);

            //assert
            result.Should().BeApproximately(ConvertN.ToInt32(left, Conversion.Cast) << right);
        }
        [Test, Repeat(RandomVariations)]
        public void Round1_RandomIntegral_SameValue()
        {
            //arrange
            TNumeric input = Random.NextNumeric<TNumeric>();

            //act
            TNumeric result = MathN.Round(input);

            //assert
            result.Should().Be(input);
        }

        [Test, Repeat(RandomVariations)]
        public void Round2_RandomIntegral_SameValue()
        {
            //arrange
            TNumeric input = Random.NextNumeric<TNumeric>();
            int digits = Random.NextInt32(0, 10);

            //act
            TNumeric result = MathN.Round(input, digits);

            //assert
            result.Should().Be(input);
        }

        [Test, Repeat(RandomVariations)]
        public void Round3_RandomIntegral_SameValue()
        {
            //arrange
            TNumeric input = Random.NextNumeric<TNumeric>();
            MidpointRounding mode = Random.NextEnum<MidpointRounding>();

            //act
            TNumeric result = MathN.Round(input, mode);

            //assert
            result.Should().Be(input);
        }

        [Test, Repeat(RandomVariations)]
        public void Round4_RandomIntegral_SameValue()
        {
            //arrange
            TNumeric input = Random.NextNumeric<TNumeric>();
            int digits = Random.NextInt32(0, 10);
            MidpointRounding mode = Random.NextEnum<MidpointRounding>();

            //act
            TNumeric result = MathN.Round(input, digits, mode);

            //assert
            result.Should().Be(input);
        }

        [Test, Repeat(RandomVariations)]
        public void Parse_HexString_CorrectResult()
        {
            //arrange
            int input = Random.Next(0, 128);
            string hexString = input.ToString("X");

            //act
            TNumeric result = StringConvert.Parse<TNumeric>(hexString, NumberStyles.HexNumber, NumberFormatInfo.InvariantInfo);

            //assert
            result.Should().Be(ConvertN.ToNumeric<TNumeric>(input));
        }
    }
}
