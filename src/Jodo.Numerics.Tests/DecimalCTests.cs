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
using Jodo.Numerics.Clamped;
using Jodo.Testing;
using Jodo.Testing.NewtonsoftJson;
using NUnit.Framework;

namespace Jodo.Numerics.Tests
{
    public sealed class DecimalCTests : GlobalFixtureBase
    {
        public sealed class CheckedNumericConversionTests : CheckedNumericConversionTestBase<DecimalC> { }
        public sealed class CheckedNumericTests : CheckedNumericTestBase<DecimalC> { }
        public sealed class JsonConvertTests : JsonConvertTestBase<DecimalC> { }
        public sealed class NumericBitConverterTests : NumericBitConverterTestBase<DecimalC> { }
        public sealed class NumericCastTests : NumericCastTestBase<DecimalC> { }
        public sealed class NumericConvertTests : NumericConvertTestBase<DecimalC> { }
        public sealed class NumericMathTests : NumericMathTestBase<DecimalC> { }
        public sealed class NumericRandomTestBase : NumericRandomTestBase<DecimalC> { }
        public sealed class NumericRealTests : NumericRealTestBase<DecimalC> { }
        public sealed class NumericSignedTests : NumericSignedTestBase<DecimalC> { }
        public sealed class NumericStringConvertTests : NumericStringConvertTestBase<DecimalC> { }
        public sealed class NumericTests : NumericTestBase<DecimalC> { }
        public sealed class ObjectTests : ObjectTestBase<DecimalC> { }
        public sealed class SerializableTests : SerializableTestBase<DecimalC> { }

        [Test, Repeat(RandomVariations)]
        public void IsFinite_RandomValue_AlwaysTrue()
        {
            //arrange
            byte[] bytes = BitConverterN.GetBytes<DecimalC>(default);
            for (int i = 0; i < 12; i++)
                bytes[i] = Random.NextByte();
            DecimalC input = BitConverterN.ToNumeric<DecimalC>(bytes, 0);

            //act
            bool result = Numeric.IsFinite(input);

            //assert
            result.Should().BeTrue();
        }

        [Test, Repeat(RandomVariations)]
        public void IsInfinity_RandomValue_AlwaysFalse()
        {
            //arrange
            byte[] bytes = BitConverterN.GetBytes<DecimalC>(default);
            for (int i = 0; i < 12; i++)
                bytes[i] = Random.NextByte();
            DecimalC input = BitConverterN.ToNumeric<DecimalC>(bytes, 0);

            //act
            bool result = Numeric.IsInfinity(input);

            //assert
            result.Should().BeFalse();
        }

        [Test, Repeat(RandomVariations)]
        public void IsPositiveInfinity_RandomValue_AlwaysFalse()
        {
            //arrange
            byte[] bytes = BitConverterN.GetBytes<DecimalC>(default);
            for (int i = 0; i < 12; i++)
                bytes[i] = Random.NextByte();
            DecimalC input = BitConverterN.ToNumeric<DecimalC>(bytes, 0);

            //act
            bool result = Numeric.IsPositiveInfinity(input);

            //assert
            result.Should().BeFalse();
        }

        [Test, Repeat(RandomVariations)]
        public void IsNegativeInfinity_RandomValue_AlwaysFalse()
        {
            //arrange
            byte[] bytes = BitConverterN.GetBytes<DecimalC>(default);
            for (int i = 0; i < 12; i++)
                bytes[i] = Random.NextByte();
            DecimalC input = BitConverterN.ToNumeric<DecimalC>(bytes, 0);

            //act
            bool result = Numeric.IsNegativeInfinity(input);

            //assert
            result.Should().BeFalse();
        }

        [Test, Repeat(RandomVariations)]
        public void IsNaN_RandomValue_AlwaysFalse()
        {
            //arrange
            byte[] bytes = BitConverterN.GetBytes<DecimalC>(default);
            for (int i = 0; i < 12; i++)
                bytes[i] = Random.NextByte();
            DecimalC input = Random.NextNumeric<DecimalC>(Generation.Extended);

            //act
            bool result = Numeric.IsNaN(input);

            //assert
            result.Should().BeFalse();
        }
    }
}
