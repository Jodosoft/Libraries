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
    public sealed class ScaledArithmeticTests : GlobalFixtureBase
    {
#if NETCOREAPP3_0_OR_GREATER
        [TestCase((long)4, MidpointRounding.ToEven, (long)0)]
        [TestCase((long)4, MidpointRounding.AwayFromZero, (long)0)]
        [TestCase((long)5, MidpointRounding.ToEven, (long)0)]
        [TestCase((long)5, MidpointRounding.AwayFromZero, (long)10)]
        [TestCase((long)6, MidpointRounding.ToEven, (long)10)]
        [TestCase((long)6, MidpointRounding.AwayFromZero, (long)10)]
        [TestCase((long)4, MidpointRounding.ToZero, (long)0)]
        [TestCase((long)4, MidpointRounding.ToNegativeInfinity, (long)0)]
        [TestCase((long)4, MidpointRounding.ToPositiveInfinity, (long)10)]
        [TestCase((long)5, MidpointRounding.ToZero, (long)0)]
        [TestCase((long)5, MidpointRounding.ToNegativeInfinity, (long)0)]
        [TestCase((long)5, MidpointRounding.ToPositiveInfinity, (long)10)]
        [TestCase((long)6, MidpointRounding.ToZero, (long)0)]
        [TestCase((long)6, MidpointRounding.ToNegativeInfinity, (long)0)]
        [TestCase((long)6, MidpointRounding.ToPositiveInfinity, (long)10)]
        [TestCase((long)-4, MidpointRounding.ToZero, (long)0)]
        [TestCase((long)-4, MidpointRounding.ToNegativeInfinity, (long)-10)]
        [TestCase((long)-4, MidpointRounding.ToPositiveInfinity, (long)0)]
        [TestCase((long)-5, MidpointRounding.ToZero, (long)0)]
        [TestCase((long)-5, MidpointRounding.ToNegativeInfinity, (long)-10)]
        [TestCase((long)-5, MidpointRounding.ToPositiveInfinity, (long)0)]
        [TestCase((long)-6, MidpointRounding.ToZero, (long)0)]
        [TestCase((long)-6, MidpointRounding.ToNegativeInfinity, (long)-10)]
        [TestCase((long)-6, MidpointRounding.ToPositiveInfinity, (long)0)]
        [TestCase((long)15, MidpointRounding.ToZero, (long)10)]
        [TestCase((long)15, MidpointRounding.ToNegativeInfinity, (long)10)]
        [TestCase((long)15, MidpointRounding.ToPositiveInfinity, (long)20)]
        [TestCase((long)-15, MidpointRounding.ToZero, (long)-10)]
        [TestCase((long)-15, MidpointRounding.ToNegativeInfinity, (long)-20)]
        [TestCase((long)-15, MidpointRounding.ToPositiveInfinity, (long)-10)]
#endif
        [TestCase((long)-4, MidpointRounding.ToEven, (long)0)]
        [TestCase((long)-4, MidpointRounding.AwayFromZero, (long)0)]
        [TestCase((long)-5, MidpointRounding.ToEven, (long)0)]
        [TestCase((long)-5, MidpointRounding.AwayFromZero, (long)-10)]
        [TestCase((long)-6, MidpointRounding.ToEven, (long)-10)]
        [TestCase((long)-6, MidpointRounding.AwayFromZero, (long)-10)]
        [TestCase((long)15, MidpointRounding.ToEven, (long)20)]
        [TestCase((long)15, MidpointRounding.AwayFromZero, (long)20)]
        [TestCase((long)-15, MidpointRounding.ToEven, (long)-20)]
        [TestCase((long)-15, MidpointRounding.AwayFromZero, (long)-20)]
        public void Round_ExampleInt64_ExpectedResult(long input, MidpointRounding mode, long expected)
        {
            //arrange
            //act
            long result = ScaledArithmetic.Round(input, mode);

            //assert
            result.Should().Be(expected);
        }

        [Test, Repeat(RandomVariations)]
        public void Round_RandomInt64_CorrectResult()
        {
            //arrange
            long input = (long)Math.Round(Random.NextDouble(-4, 4) * 10);
            MidpointRounding mode = Random.NextEnum<MidpointRounding>();
            long expected = (long)Math.Round(input / 10.0, mode) * 10;

            //act
            long result = ScaledArithmetic.Round(input, mode);

            //assert
            result.Should().Be(expected);
        }

        [Test, Repeat(RandomVariations)]
        public void Round_MultipleOf10Int64_SameResult()
        {
            //arrange
            long input = Random.NextInt64() / 10 * 10;
            MidpointRounding mode = Random.NextEnum<MidpointRounding>();

            //act
            long result = ScaledArithmetic.Round(input, mode);

            //assert
            result.Should().Be(input);
        }

        [TestCase((long)249, 2, MidpointRounding.ToEven, (long)200)]
        [TestCase((long)250, 2, MidpointRounding.ToEven, (long)200)]
        [TestCase((long)251, 2, MidpointRounding.ToEven, (long)200)]
        public void Round1_ExampleInt64_ExpectedResult(long input, int digits, MidpointRounding mode, long expected)
        {
            //arrange
            //act
            long result = ScaledArithmetic.Round(input, digits, mode);

            //assert
            result.Should().Be(expected);
        }

        [Test, Repeat(RandomVariations)]
        public void Round_RandomInt64MorePlacesThanDigits_ReturnsZero()
        {
            //arrange
            byte places = Random.NextByte(2, 18);
            double scalingFactor = Math.Pow(10, places);
            ulong input = (ulong)Math.Round(Random.NextDouble(0, 4) * scalingFactor);
            MidpointRounding mode = Random.NextEnum<MidpointRounding>();

            //act
            ulong result = ScaledArithmetic.Round(input, places + 2, mode);

            //assert
            result.Should().Be(0);
        }

#if NETCOREAPP3_0_OR_GREATER
        [TestCase((ulong)4, MidpointRounding.ToZero, (ulong)0)]
        [TestCase((ulong)4, MidpointRounding.ToNegativeInfinity, (ulong)0)]
        [TestCase((ulong)4, MidpointRounding.ToPositiveInfinity, (ulong)10)]
        [TestCase((ulong)5, MidpointRounding.ToZero, (ulong)0)]
        [TestCase((ulong)5, MidpointRounding.ToNegativeInfinity, (ulong)0)]
        [TestCase((ulong)5, MidpointRounding.ToPositiveInfinity, (ulong)10)]
        [TestCase((ulong)6, MidpointRounding.ToZero, (ulong)0)]
        [TestCase((ulong)6, MidpointRounding.ToNegativeInfinity, (ulong)0)]
        [TestCase((ulong)6, MidpointRounding.ToPositiveInfinity, (ulong)10)]
        [TestCase((ulong)15, MidpointRounding.ToZero, (ulong)10)]
        [TestCase((ulong)15, MidpointRounding.ToNegativeInfinity, (ulong)10)]
        [TestCase((ulong)15, MidpointRounding.ToPositiveInfinity, (ulong)20)]
#endif
        [TestCase((ulong)4, MidpointRounding.ToEven, (ulong)0)]
        [TestCase((ulong)4, MidpointRounding.AwayFromZero, (ulong)0)]
        [TestCase((ulong)5, MidpointRounding.ToEven, (ulong)0)]
        [TestCase((ulong)5, MidpointRounding.AwayFromZero, (ulong)10)]
        [TestCase((ulong)6, MidpointRounding.ToEven, (ulong)10)]
        [TestCase((ulong)6, MidpointRounding.AwayFromZero, (ulong)10)]
        [TestCase((ulong)15, MidpointRounding.ToEven, (ulong)20)]
        [TestCase((ulong)15, MidpointRounding.AwayFromZero, (ulong)20)]
        public void Round_ExampleUInt64_ExpectedResult(ulong input, MidpointRounding mode, ulong expected)
        {
            //arrange
            //act
            ulong result = ScaledArithmetic.Round(input, mode);

            //assert
            result.Should().Be(expected);
        }

        [Test, Repeat(RandomVariations)]
        public void Round_RandomUInt64_CorrectResult()
        {
            //arrange
            ulong input = (ulong)Math.Round(Random.NextDouble(0, 4) * 10);
            MidpointRounding mode = Random.NextEnum<MidpointRounding>();
            ulong expected = (ulong)Math.Round(input / 10.0, mode) * 10;

            //act
            ulong result = ScaledArithmetic.Round(input, mode);

            //assert
            result.Should().Be(expected);
        }

        [Test, Repeat(RandomVariations)]
        public void Round_MultipleOf10UInt64_SameResult()
        {
            //arrange
            ulong input = Random.NextUInt64() / 10 * 10;
            MidpointRounding mode = Random.NextEnum<MidpointRounding>();

            //act
            ulong result = ScaledArithmetic.Round(input, mode);

            //assert
            result.Should().Be(input);
        }

        [Test, Repeat(RandomVariations)]
        public void Round_RandomUInt64MorePlacesThanDigits_ReturnsZero()
        {
            //arrange
            byte places = Random.NextByte(2, 18);
            double scalingFactor = Math.Pow(10, places);
            long input = (long)Math.Round(Random.NextDouble(0, 4) * scalingFactor);
            MidpointRounding mode = Random.NextEnum<MidpointRounding>();

            //act
            long result = ScaledArithmetic.Round(input, places + 2, mode);

            //assert
            result.Should().Be(0);
        }

        [TestCase("123.999", 10, null, "en-US", 1240)]
        [TestCase("123.456", 1000, null, "en-GB", 123456)]
        [TestCase("1,234.56", 100, NumberStyles.AllowThousands, "en-US", 123456)]
        [TestCase("-1,234.56", 100, NumberStyles.AllowThousands | NumberStyles.AllowLeadingSign, "en-US", -123456)]
        [TestCase("1.234,56", 100, NumberStyles.AllowThousands, "da-DK", 123456)]
        [TestCase("-1.234,56", 100, NumberStyles.AllowThousands | NumberStyles.AllowLeadingSign, "da-DK", -123456)]
        [TestCase("-1234.56", 100, null, "ja-JP", -123456)]
        public void Parse1_VariousScenarios_CorrectResultAsDouble(string input, long scalingFactor, NumberStyles? style, string culture, long expected)
        {

            //arrange
            //act
            long result = ScaledArithmetic.Parse(input, scalingFactor, style, CultureInfo.GetCultureInfo(culture));

            //assert
            result.Should().Be(expected);
        }

        [TestCase("123.999", (ulong)10, null, "en-US", (ulong)1240)]
        [TestCase("123.456", (ulong)1000, null, "en-GB", (ulong)123456)]
        [TestCase("1,234.56", (ulong)100, NumberStyles.AllowThousands, "en-US", (ulong)123456)]
        [TestCase("1.234,56", (ulong)100, NumberStyles.AllowThousands, "da-DK", (ulong)123456)]
        public void Parse2_VariousScenarios_CorrectResultAsDouble(string input, ulong scalingFactor, NumberStyles? style, string culture, ulong expected)
        {
            //arrange
            //act
            ulong result = ScaledArithmetic.Parse(input, scalingFactor, style, CultureInfo.GetCultureInfo(culture));

            //assert
            result.Should().Be(expected);
        }
    }
}
