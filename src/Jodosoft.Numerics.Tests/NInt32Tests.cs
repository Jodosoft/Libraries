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
    public sealed class NInt32Tests : GlobalFixtureBase
    {
        public sealed class BinaryIOTests : BinaryIOTestBase<NInt32> { }
        public sealed class FormattableTests : FormattableTestBase<NInt32> { }
        public sealed class JsonConvertTests : JsonConvertTestBase<NInt32> { }
        public sealed class NumericBitConverterTests : NumericBitConverterTestBase<NInt32> { }
        public sealed class NumericCastTests : NumericCastTestBase<NInt32> { }
        public sealed class NumericConversionConsistencyTests : NumericConversionConsistencyTestBase<NInt32> { }
        public sealed class NumericConvertTests : NumericConvertTestBase<NInt32> { }
        public sealed class NumericIntegralTests : NumericIntegralTestBase<NInt32> { }
        public sealed class NumericMathTests : NumericMathTestBase<NInt32> { }
        public sealed class NumericNonFloatingPointTests : NumericNonFloatingPointTestBase<NInt32> { }
        public sealed class NumericNonInfinityTests : NumericNonInfinityTestBase<NInt32> { }
        public sealed class NumericNonNaNTests : NumericNonNaNTestBase<NInt32> { }
        public sealed class NumericRandomTestBase : NumericRandomTestBase<NInt32> { }
        public sealed class NumericSignedTests : NumericSignedTestBase<NInt32> { }
        public sealed class NumericStringConvertTests : NumericStringConvertTestBase<NInt32> { }
        public sealed class NumericTests : NumericTestBase<NInt32> { }
        public sealed class NumericWrapperIntegralTests : NumericWrapperIntegralTestBase<NInt32, int> { }
        public sealed class NumericWrapperTests : NumericWrapperTestBase<NInt32, int> { }
        public sealed class ObjectTests : ObjectTestBase<NInt32> { }
        public sealed class SerializableTests : SerializableTestBase<NInt32> { }

        [Test, Repeat(RandomVariations)]
        public void IncrementOperator_RandomInputs_SameAsPlusOne()
        {
            //arrange
            NInt32 input = Random.NextVariant<NInt32>();
            NInt32 expected = input + 1;

            //act
            input++;

            //assert
            input.Should().Be(expected);
        }

        [Test, Repeat(RandomVariations)]
        public void DecrementOperator_RandomInputs_SameAsMinusOne()
        {
            //arrange
            NInt32 input = Random.NextVariant<NInt32>();
            NInt32 expected = input - 1;

            //act
            input--;

            //assert
            input.Should().Be(expected);
        }
    }
}
