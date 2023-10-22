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
    public sealed class NUInt16Tests : GlobalFixtureBase
    {
        public sealed class BinaryIOTests : BinaryIOTestBase<NUInt16> { }
        public sealed class FormattableTests : FormattableTestBase<NUInt16> { }
        public sealed class JsonConvertTests : JsonConvertTestBase<NUInt16> { }
        public sealed class NumericBitConverterTests : NumericBitConverterTestBase<NUInt16> { }
        public sealed class NumericCastTests : NumericCastTestBase<NUInt16> { }
        public sealed class NumericConversionConsistencyTests : NumericConversionConsistencyTestBase<NUInt16> { }
        public sealed class NumericConvertTests : NumericConvertTestBase<NUInt16> { }
        public sealed class NumericIntegralTests : NumericIntegralTestBase<NUInt16> { }
        public sealed class NumericMathTests : NumericMathTestBase<NUInt16> { }
        public sealed class NumericNonFloatingPointTests : NumericNonFloatingPointTestBase<NUInt16> { }
        public sealed class NumericNonInfinityTests : NumericNonInfinityTestBase<NUInt16> { }
        public sealed class NumericNonNaNTests : NumericNonNaNTestBase<NUInt16> { }
        public sealed class NumericRandomTestBase : NumericRandomTestBase<NUInt16> { }
        public sealed class NumericStringConvertTests : NumericStringConvertTestBase<NUInt16> { }
        public sealed class NumericTests : NumericTestBase<NUInt16> { }
        public sealed class NumericUnsignedTests : NumericUnsignedTestBase<NUInt16> { }
        public sealed class NumericWrapperIntegralTests : NumericWrapperIntegralTestBase<NUInt16, ushort> { }
        public sealed class NumericWrapperTests : NumericWrapperTestBase<NUInt16, ushort> { }
        public sealed class ObjectTests : ObjectTestBase<NUInt16> { }
        public sealed class SerializableTests : SerializableTestBase<NUInt16> { }

        [Test, Repeat(RandomVariations)]
        public void IncrementOperator_RandomInputs_SameAsPlusOne()
        {
            //arrange
            NUInt16 input = Random.NextVariant<NUInt16>();
            NUInt16 expected = input + 1;

            //act
            input++;

            //assert
            input.Should().Be(expected);
        }

        [Test, Repeat(RandomVariations)]
        public void DecrementOperator_RandomInputs_SameAsMinusOne()
        {
            //arrange
            NUInt16 input = Random.NextVariant<NUInt16>();
            NUInt16 expected = input - 1;

            //act
            input--;

            //assert
            input.Should().Be(expected);
        }
    }
}
