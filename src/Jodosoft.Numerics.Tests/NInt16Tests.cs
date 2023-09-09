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
    public sealed class NInt16Tests : GlobalFixtureBase
    {
        public sealed class BinaryIOTests : BinaryIOTestBase<NInt16> { }
        public sealed class FormattableTests : FormattableTestBase<NInt16> { }
        public sealed class JsonConvertTests : JsonConvertTestBase<NInt16> { }
        public sealed class NumericBitConverterTests : NumericBitConverterTestBase<NInt16> { }
        public sealed class NumericCastTests : NumericCastTestBase<NInt16> { }
        public sealed class NumericConversionConsistencyTests : NumericConversionConsistencyTestBase<NInt16> { }
        public sealed class NumericConvertTests : NumericConvertTestBase<NInt16> { }
        public sealed class NumericIntegralTests : NumericIntegralTestBase<NInt16> { }
        public sealed class NumericMathTests : NumericMathTestBase<NInt16> { }
        public sealed class NumericNonFloatingPointTests : NumericNonFloatingPointTestBase<NInt16> { }
        public sealed class NumericNonInfinityTests : NumericNonInfinityTestBase<NInt16> { }
        public sealed class NumericNonNaNTests : NumericNonNaNTestBase<NInt16> { }
        public sealed class NumericRandomTestBase : NumericRandomTestBase<NInt16> { }
        public sealed class NumericSignedTests : NumericSignedTestBase<NInt16> { }
        public sealed class NumericStringConvertTests : NumericStringConvertTestBase<NInt16> { }
        public sealed class NumericTests : NumericTestBase<NInt16> { }
        public sealed class NumericWrapperIntegralTests : NumericWrapperIntegralTestBase<NInt16, short> { }
        public sealed class NumericWrapperTests : NumericWrapperTestBase<NInt16, short> { }
        public sealed class ObjectTests : ObjectTestBase<NInt16> { }
        public sealed class SerializableTests : SerializableTestBase<NInt16> { }

        [Test, Repeat(RandomVariations)]
        public void IncrementOperator_RandomInputs_SameAsPlusOne()
        {
            //arrange
            NInt16 input = Random.NextVariant<NInt16>();
            NInt16 expected = input + (short)1;

            //act
            input++;

            //assert
            input.Should().Be(expected);
        }

        [Test, Repeat(RandomVariations)]
        public void DecrementOperator_RandomInputs_SameAsMinusOne()
        {
            //arrange
            NInt16 input = Random.NextVariant<NInt16>();
            NInt16 expected = input - (short)1;

            //act
            input--;

            //assert
            input.Should().Be(expected);
        }
    }
}
