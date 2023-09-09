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
    public class ClampedByteTests : GlobalFixtureBase
    {
        public sealed class BinaryIOTests : BinaryIOTestBase<ClampedByte> { }
        public sealed class ClampedNumericConversionTests : ClampedNumericConversionTestBase<ClampedByte> { }
        public sealed class ClampedNumericTests : ClampedNumericTestBase<ClampedByte> { }
        public sealed class FormattableTests : FormattableTestBase<ClampedByte> { }
        public sealed class JsonConvertTests : JsonConvertTestBase<ClampedByte> { }
        public sealed class NumericBitConverterTests : NumericBitConverterTestBase<ClampedByte> { }
        public sealed class NumericCastTests : NumericCastTestBase<ClampedByte> { }
        public sealed class NumericConvertTests : NumericConvertTestBase<ClampedByte> { }
        public sealed class NumericIntegralTests : NumericIntegralTestBase<ClampedByte> { }
        public sealed class NumericMathTests : NumericMathTestBase<ClampedByte> { }
        public sealed class NumericNonFloatingPointTests : NumericNonFloatingPointTestBase<ClampedByte> { }
        public sealed class NumericNonInfinityTests : NumericNonInfinityTestBase<ClampedByte> { }
        public sealed class NumericNonNaNTests : NumericNonNaNTestBase<ClampedByte> { }
        public sealed class NumericRandomTestBase : NumericRandomTestBase<ClampedByte> { }
        public sealed class NumericStringConvertTests : NumericStringConvertTestBase<ClampedByte> { }
        public sealed class NumericTests : NumericTestBase<ClampedByte> { }
        public sealed class NumericUnsignedTests : NumericUnsignedTestBase<ClampedByte> { }
        public sealed class ObjectTests : ObjectTestBase<ClampedByte> { }
        public sealed class SerializableTests : SerializableTestBase<ClampedByte> { }

        [Test, Repeat(RandomVariations)]
        public void IncrementOperator_RandomInputs_SameAsPlusOne()
        {
            //arrange
            ClampedByte input = Random.NextVariant<ClampedByte>();
            ClampedByte expected = input + 1;

            //act
            input++;

            //assert
            input.Should().Be(expected);
        }

        [Test, Repeat(RandomVariations)]
        public void DecrementOperator_RandomInputs_SameAsMinusOne()
        {
            //arrange
            ClampedByte input = Random.NextVariant<ClampedByte>();
            ClampedByte expected = input - 1;

            //act
            input--;

            //assert
            input.Should().Be(expected);
        }
    }
}
