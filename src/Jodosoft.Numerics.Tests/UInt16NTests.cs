﻿// Copyright (c) 2023 Joe Lawry-Short
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
    public sealed class UInt16NTests : GlobalFixtureBase
    {
        public sealed class BinaryIOTests : BinaryIOTestBase<UInt16N> { }
        public sealed class FormattableTests : FormattableTestBase<UInt16N> { }
        public sealed class JsonConvertTests : JsonConvertTestBase<UInt16N> { }
        public sealed class NumericBitConverterTests : NumericBitConverterTestBase<UInt16N> { }
        public sealed class NumericCastTests : NumericCastTestBase<UInt16N> { }
        public sealed class NumericConversionConsistencyTests : NumericConversionConsistencyTestBase<UInt16N> { }
        public sealed class NumericConvertTests : NumericConvertTestBase<UInt16N> { }
        public sealed class NumericIntegralTests : NumericIntegralTestBase<UInt16N> { }
        public sealed class NumericMathTests : NumericMathTestBase<UInt16N> { }
        public sealed class NumericNonFloatingPointTests : NumericNonFloatingPointTestBase<UInt16N> { }
        public sealed class NumericNonInfinityTests : NumericNonInfinityTestBase<UInt16N> { }
        public sealed class NumericNonNaNTests : NumericNonNaNTestBase<UInt16N> { }
        public sealed class NumericRandomTestBase : NumericRandomTestBase<UInt16N> { }
        public sealed class NumericStringConvertTests : NumericStringConvertTestBase<UInt16N> { }
        public sealed class NumericTests : NumericTestBase<UInt16N> { }
        public sealed class NumericUnsignedTests : NumericUnsignedTestBase<UInt16N> { }
        public sealed class NumericWrapperIntegralTests : NumericWrapperIntegralTestBase<UInt16N, ushort> { }
        public sealed class NumericWrapperTests : NumericWrapperTestBase<UInt16N, ushort> { }
        public sealed class ObjectTests : ObjectTestBase<UInt16N> { }
        public sealed class SerializableTests : SerializableTestBase<UInt16N> { }

        [Test, Repeat(RandomVariations)]
        public void IncrementOperator_RandomInputs_SameAsPlusOne()
        {
            //arrange
            UInt16N input = Random.NextVariant<UInt16N>();
            UInt16N expected = input + 1;

            //act
            input++;

            //assert
            input.Should().Be(expected);
        }

        [Test, Repeat(RandomVariations)]
        public void DecrementOperator_RandomInputs_SameAsMinusOne()
        {
            //arrange
            UInt16N input = Random.NextVariant<UInt16N>();
            UInt16N expected = input - 1;

            //act
            input--;

            //assert
            input.Should().Be(expected);
        }
    }
}
