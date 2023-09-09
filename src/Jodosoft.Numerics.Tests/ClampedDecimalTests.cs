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
using Jodosoft.Primitives;
using Jodosoft.Primitives.Tests;
using Jodosoft.Testing;
using Jodosoft.Testing.NewtonsoftJson;
using NUnit.Framework;

namespace Jodosoft.Numerics.Tests
{
    public sealed class ClampedDecimalTests : GlobalFixtureBase
    {
        public sealed class BinaryIOTests : BinaryIOTestBase<ClampedDecimal> { }
        public sealed class ClampedNumericConversionTests : ClampedNumericConversionTestBase<ClampedDecimal> { }
        public sealed class ClampedNumericTests : ClampedNumericTestBase<ClampedDecimal> { }
        public sealed class FormattableTests : FormattableTestBase<ClampedDecimal> { }
        public sealed class JsonConvertTests : JsonConvertTestBase<ClampedDecimal> { }
        public sealed class NumericBitConverterTests : NumericBitConverterTestBase<ClampedDecimal> { }
        public sealed class NumericCastTests : NumericCastTestBase<ClampedDecimal> { }
        public sealed class NumericConvertTests : NumericConvertTestBase<ClampedDecimal> { }
        public sealed class NumericMathTests : NumericMathTestBase<ClampedDecimal> { }
        public sealed class NumericRandomTestBase : NumericRandomTestBase<ClampedDecimal> { }
        public sealed class NumericRealTests : NumericRealTestBase<ClampedDecimal> { }
        public sealed class NumericSignedTests : NumericSignedTestBase<ClampedDecimal> { }
        public sealed class NumericStringConvertTests : NumericStringConvertTestBase<ClampedDecimal> { }
        public sealed class NumericTests : NumericTestBase<ClampedDecimal> { }
        public sealed class ObjectTests : ObjectTestBase<ClampedDecimal> { }
        public sealed class SerializableTests : SerializableTestBase<ClampedDecimal> { }

        [Test, Repeat(RandomVariations)]
        public void IsFinite_RandomValue_AlwaysTrue()
        {
            //arrange
            byte[] bytes = BitConverterN.GetBytes<ClampedDecimal>(default);
            for (int i = 0; i < 12; i++)
                bytes[i] = Random.NextByte();
            ClampedDecimal input = BitConverterN.ToNumeric<ClampedDecimal>(bytes, 0);

            //act
            bool result = Numeric.IsFinite(input);

            //assert
            result.Should().BeTrue();
        }

        [Test, Repeat(RandomVariations)]
        public void IsInfinity_RandomValue_AlwaysFalse()
        {
            //arrange
            byte[] bytes = BitConverterN.GetBytes<ClampedDecimal>(default);
            for (int i = 0; i < 12; i++)
                bytes[i] = Random.NextByte();
            ClampedDecimal input = BitConverterN.ToNumeric<ClampedDecimal>(bytes, 0);

            //act
            bool result = Numeric.IsInfinity(input);

            //assert
            result.Should().BeFalse();
        }

        [Test, Repeat(RandomVariations)]
        public void IsPositiveInfinity_RandomValue_AlwaysFalse()
        {
            //arrange
            byte[] bytes = BitConverterN.GetBytes<ClampedDecimal>(default);
            for (int i = 0; i < 12; i++)
                bytes[i] = Random.NextByte();
            ClampedDecimal input = BitConverterN.ToNumeric<ClampedDecimal>(bytes, 0);

            //act
            bool result = Numeric.IsPositiveInfinity(input);

            //assert
            result.Should().BeFalse();
        }

        [Test, Repeat(RandomVariations)]
        public void IsNegativeInfinity_RandomValue_AlwaysFalse()
        {
            //arrange
            byte[] bytes = BitConverterN.GetBytes<ClampedDecimal>(default);
            for (int i = 0; i < 12; i++)
                bytes[i] = Random.NextByte();
            ClampedDecimal input = BitConverterN.ToNumeric<ClampedDecimal>(bytes, 0);

            //act
            bool result = Numeric.IsNegativeInfinity(input);

            //assert
            result.Should().BeFalse();
        }

        [Test, Repeat(RandomVariations)]
        public void IsNaN_RandomValue_AlwaysFalse()
        {
            //arrange
            byte[] bytes = BitConverterN.GetBytes<ClampedDecimal>(default);
            for (int i = 0; i < 12; i++)
                bytes[i] = Random.NextByte();
            ClampedDecimal input = Random.NextNumeric<ClampedDecimal>(Generation.Extended);

            //act
            bool result = Numeric.IsNaN(input);

            //assert
            result.Should().BeFalse();
        }

        [Test, Repeat(RandomVariations)]
        public void IncrementOperator_RandomInputs_SameAsPlusOne()
        {
            //arrange
            ClampedDecimal input = Random.NextVariant<ClampedDecimal>(Variants.LowMagnitude);
            ClampedDecimal expected = input + 1;

            //act
            input++;

            //assert
            input.Should().Be(expected);
        }

        [Test, Repeat(RandomVariations)]
        public void DecrementOperator_RandomInputs_SameAsMinusOne()
        {
            //arrange
            ClampedDecimal input = Random.NextVariant<ClampedDecimal>(Variants.LowMagnitude);
            ClampedDecimal expected = input - 1;

            //act
            input--;

            //assert
            input.Should().Be(expected);
        }
    }
}
