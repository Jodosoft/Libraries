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
    public sealed class ClampedSByteTests : GlobalFixtureBase
    {
        public sealed class BinaryIOTests : BinaryIOTestBase<ClampedSByte> { }
        public sealed class ClampedNumericConversionTests : ClampedNumericConversionTestBase<ClampedSByte> { }
        public sealed class ClampedNumericTests : ClampedNumericTestBase<ClampedSByte> { }
        public sealed class FormattableTests : FormattableTestBase<ClampedSByte> { }
        public sealed class JsonConvertTests : JsonConvertTestBase<ClampedSByte> { }
        public sealed class NumericBitConverterTests : NumericBitConverterTestBase<ClampedSByte> { }
        public sealed class NumericCastTests : NumericCastTestBase<ClampedSByte> { }
        public sealed class NumericConvertTests : NumericConvertTestBase<ClampedSByte> { }
        public sealed class NumericIntegralTests : NumericIntegralTestBase<ClampedSByte> { }
        public sealed class NumericMathTests : NumericMathTestBase<ClampedSByte> { }
        public sealed class NumericNonFloatingPointTests : NumericNonFloatingPointTestBase<ClampedSByte> { }
        public sealed class NumericNonInfinityTests : NumericNonInfinityTestBase<ClampedSByte> { }
        public sealed class NumericNonNaNTests : NumericNonNaNTestBase<ClampedSByte> { }
        public sealed class NumericRandomTestBase : NumericRandomTestBase<ClampedSByte> { }
        public sealed class NumericSignedTests : NumericSignedTestBase<ClampedSByte> { }
        public sealed class NumericStringConvertTests : NumericStringConvertTestBase<ClampedSByte> { }
        public sealed class NumericTests : NumericTestBase<ClampedSByte> { }
        public sealed class ObjectTests : ObjectTestBase<ClampedSByte> { }
        public sealed class SerializableTests : SerializableTestBase<ClampedSByte> { }

        [Test, Repeat(RandomVariations)]
        public void IncrementOperator_RandomInputs_SameAsPlusOne()
        {
            //arrange
            ClampedSByte input = Random.NextVariant<ClampedSByte>();
            ClampedSByte expected = input + 1;

            //act
            input++;

            //assert
            input.Should().Be(expected);
        }

        [Test, Repeat(RandomVariations)]
        public void DecrementOperator_RandomInputs_SameAsMinusOne()
        {
            //arrange
            ClampedSByte input = Random.NextVariant<ClampedSByte>();
            ClampedSByte expected = input - 1;

            //act
            input--;

            //assert
            input.Should().Be(expected);
        }
    }
}
