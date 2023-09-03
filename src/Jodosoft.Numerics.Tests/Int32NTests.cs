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
    public sealed class Int32NTests : GlobalFixtureBase
    {
        public sealed class BinaryIOTests : BinaryIOTestBase<Int32N> { }
        public sealed class FormattableTests : FormattableTestBase<Int32N> { }
        public sealed class JsonConvertTests : JsonConvertTestBase<Int32N> { }
        public sealed class NumericBitConverterTests : NumericBitConverterTestBase<Int32N> { }
        public sealed class NumericCastTests : NumericCastTestBase<Int32N> { }
        public sealed class NumericConversionConsistencyTests : NumericConversionConsistencyTestBase<Int32N> { }
        public sealed class NumericConvertTests : NumericConvertTestBase<Int32N> { }
        public sealed class NumericIntegralTests : NumericIntegralTestBase<Int32N> { }
        public sealed class NumericMathTests : NumericMathTestBase<Int32N> { }
        public sealed class NumericNonFloatingPointTests : NumericNonFloatingPointTestBase<Int32N> { }
        public sealed class NumericNonInfinityTests : NumericNonInfinityTestBase<Int32N> { }
        public sealed class NumericNonNaNTests : NumericNonNaNTestBase<Int32N> { }
        public sealed class NumericRandomTestBase : NumericRandomTestBase<Int32N> { }
        public sealed class NumericSignedTests : NumericSignedTestBase<Int32N> { }
        public sealed class NumericStringConvertTests : NumericStringConvertTestBase<Int32N> { }
        public sealed class NumericTests : NumericTestBase<Int32N> { }
        public sealed class NumericWrapperIntegralTests : NumericWrapperIntegralTestBase<Int32N, int> { }
        public sealed class NumericWrapperTests : NumericWrapperTestBase<Int32N, int> { }
        public sealed class ObjectTests : ObjectTestBase<Int32N> { }
        public sealed class SerializableTests : SerializableTestBase<Int32N> { }

        [Test, Repeat(RandomVariations)]
        public void IncrementOperator_RandomInputs_SameAsPlusOne()
        {
            //arrange
            Int32N input = Random.NextVariant<Int32N>();
            Int32N expected = input + 1;

            //act
            input++;

            //assert
            input.Should().Be(expected);
        }

        [Test, Repeat(RandomVariations)]
        public void DecrementOperator_RandomInputs_SameAsMinusOne()
        {
            //arrange
            Int32N input = Random.NextVariant<Int32N>();
            Int32N expected = input - 1;

            //act
            input--;

            //assert
            input.Should().Be(expected);
        }
    }
}
