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
    public sealed class NSByteTests : GlobalFixtureBase
    {
        public sealed class BinaryIOTests : BinaryIOTestBase<NSByte> { }
        public sealed class FormattableTests : FormattableTestBase<NSByte> { }
        public sealed class JsonConvertTests : JsonConvertTestBase<NSByte> { }
        public sealed class NumericBitConverterTests : NumericBitConverterTestBase<NSByte> { }
        public sealed class NumericCastTests : NumericCastTestBase<NSByte> { }
        public sealed class NumericConversionConsistencyTests : NumericConversionConsistencyTestBase<NSByte> { }
        public sealed class NumericConvertTests : NumericConvertTestBase<NSByte> { }
        public sealed class NumericIntegralTests : NumericIntegralTestBase<NSByte> { }
        public sealed class NumericMathTests : NumericMathTestBase<NSByte> { }
        public sealed class NumericNonFloatingPointTests : NumericNonFloatingPointTestBase<NSByte> { }
        public sealed class NumericNonInfinityTests : NumericNonInfinityTestBase<NSByte> { }
        public sealed class NumericNonNaNTests : NumericNonNaNTestBase<NSByte> { }
        public sealed class NumericRandomTestBase : NumericRandomTestBase<NSByte> { }
        public sealed class NumericSignedTests : NumericSignedTestBase<NSByte> { }
        public sealed class NumericStringConvertTests : NumericStringConvertTestBase<NSByte> { }
        public sealed class NumericTests : NumericTestBase<NSByte> { }
        public sealed class ObjectTests : ObjectTestBase<NSByte> { }
        public sealed class SerializableTests : SerializableTestBase<NSByte> { }

        [Test, Repeat(RandomVariations)]
        public void IncrementOperator_RandomInputs_SameAsPlusOne()
        {
            //arrange
            NSByte input = Random.NextVariant<NSByte>();
            NSByte expected = input + 1;

            //act
            input++;

            //assert
            input.Should().Be(expected);
        }

        [Test, Repeat(RandomVariations)]
        public void DecrementOperator_RandomInputs_SameAsMinusOne()
        {
            //arrange
            NSByte input = Random.NextVariant<NSByte>();
            NSByte expected = input - 1;

            //act
            input--;

            //assert
            input.Should().Be(expected);
        }
    }
}
