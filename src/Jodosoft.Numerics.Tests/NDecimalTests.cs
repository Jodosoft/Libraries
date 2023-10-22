// Copyright (c) 2023 Joe Lawry-Short
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
using Jodosoft.Numerics.Compatibility;
using Jodosoft.Primitives;
using Jodosoft.Primitives.Tests;
using Jodosoft.Testing;
using Jodosoft.Testing.NewtonsoftJson;
using NUnit.Framework;

namespace Jodosoft.Numerics.Tests
{
    public sealed class NDecimalTests : GlobalFixtureBase
    {
        public sealed class BinaryIOTests : BinaryIOTestBase<NDecimal> { }
        public sealed class FormattableTests : FormattableTestBase<NDecimal> { }
        public sealed class JsonConvertTests : JsonConvertTestBase<NDecimal> { }
        public sealed class NumericBitConverterTests : NumericBitConverterTestBase<NDecimal> { }
        public sealed class NumericCastTests : NumericCastTestBase<NDecimal> { }
        public sealed class NumericConversionConsistencyTests : NumericConversionConsistencyTestBase<NDecimal> { }
        public sealed class NumericConvertTests : NumericConvertTestBase<NDecimal> { }
        public sealed class NumericMathTests : NumericMathTestBase<NDecimal> { }
        public sealed class NumericRandomTestBase : NumericRandomTestBase<NDecimal> { }
        public sealed class NumericRealTests : NumericRealTestBase<NDecimal> { }
        public sealed class NumericSignedTests : NumericSignedTestBase<NDecimal> { }
        public sealed class NumericStringConvertTests : NumericStringConvertTestBase<NDecimal> { }
        public sealed class NumericTests : NumericTestBase<NDecimal> { }
        public sealed class NumericWrapperTests : NumericWrapperTestBase<NDecimal, decimal> { }
        public sealed class ObjectTests : ObjectTestBase<NDecimal> { }
        public sealed class SerializableTests : SerializableTestBase<NDecimal> { }

        [Test, Repeat(RandomVariations)]
        public void IsFinite_RandomValue_AlwaysTrue()
        {
            //arrange
            byte[] bytes = BitConverterN.GetBytes<NDecimal>(default);
            for (int i = 0; i < 12; i++)
            {
                bytes[i] = Random.NextByte();
            }
            NDecimal input = BitConverterN.ToNumeric<NDecimal>(bytes, 0);

            //act
            bool result = Numeric.IsFinite(input);

            //assert
            result.Should().BeTrue();
        }

        [Test, Repeat(RandomVariations)]
        public void IsInfinity_RandomValue_AlwaysFalse()
        {
            //arrange
            byte[] bytes = BitConverterN.GetBytes<NDecimal>(default);
            for (int i = 0; i < 12; i++)
            {
                bytes[i] = Random.NextByte();
            }
            NDecimal input = BitConverterN.ToNumeric<NDecimal>(bytes, 0);

            //act
            bool result = Numeric.IsInfinity(input);

            //assert
            result.Should().BeFalse();
        }

        [Test, Repeat(RandomVariations)]
        public void IsPositiveInfinity_RandomValue_AlwaysFalse()
        {
            //arrange
            byte[] bytes = BitConverterN.GetBytes<NDecimal>(default);
            for (int i = 0; i < 12; i++)
            {
                bytes[i] = Random.NextByte();
            }
            NDecimal input = BitConverterN.ToNumeric<NDecimal>(bytes, 0);

            //act
            bool result = Numeric.IsPositiveInfinity(input);

            //assert
            result.Should().BeFalse();
        }

        [Test, Repeat(RandomVariations)]
        public void IsNegativeInfinity_RandomValue_AlwaysFalse()
        {
            //arrange
            byte[] bytes = BitConverterN.GetBytes<NDecimal>(default);
            for (int i = 0; i < 12; i++)
            {
                bytes[i] = Random.NextByte();
            }
            NDecimal input = BitConverterN.ToNumeric<NDecimal>(bytes, 0);

            //act
            bool result = Numeric.IsNegativeInfinity(input);

            //assert
            result.Should().BeFalse();
        }

        [Test, Repeat(RandomVariations)]
        public void IsNaN_RandomValue_AlwaysFalse()
        {
            //arrange
            byte[] bytes = BitConverterN.GetBytes<NDecimal>(default);
            for (int i = 0; i < 12; i++)
            {
                bytes[i] = Random.NextByte();
            }
            NDecimal input = Random.NextNumeric<NDecimal>(Generation.Extended);

            //act
            bool result = Numeric.IsNaN(input);

            //assert
            result.Should().BeFalse();
        }

        [Test, Repeat(RandomVariations)]
        public void IncrementOperator_RandomInputs_SameAsPlusOne()
        {
            //arrange
            NDecimal input = Random.NextVariant<NDecimal>(Variants.LowMagnitude);
            NDecimal expected = input + 1;

            //act
            input++;

            //assert
            input.Should().Be(expected);
        }

        [Test, Repeat(RandomVariations)]
        public void DecrementOperator_RandomInputs_SameAsMinusOne()
        {
            //arrange
            NDecimal input = Random.NextVariant<NDecimal>(Variants.LowMagnitude);
            NDecimal expected = input - 1;

            //act
            input--;

            //assert
            input.Should().Be(expected);
        }
    }
}
