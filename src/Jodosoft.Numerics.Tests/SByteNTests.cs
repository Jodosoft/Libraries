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
    public sealed class SByteNTests : GlobalFixtureBase
    {
        public sealed class BinaryIOTests : BinaryIOTestBase<SByteN> { }
        public sealed class FormattableTests : FormattableTestBase<SByteN> { }
        public sealed class JsonConvertTests : JsonConvertTestBase<SByteN> { }
        public sealed class NumericBitConverterTests : NumericBitConverterTestBase<SByteN> { }
        public sealed class NumericCastTests : NumericCastTestBase<SByteN> { }
        public sealed class NumericConversionConsistencyTests : NumericConversionConsistencyTestBase<SByteN> { }
        public sealed class NumericConvertTests : NumericConvertTestBase<SByteN> { }
        public sealed class NumericIntegralTests : NumericIntegralTestBase<SByteN> { }
        public sealed class NumericMathTests : NumericMathTestBase<SByteN> { }
        public sealed class NumericNonFloatingPointTests : NumericNonFloatingPointTestBase<SByteN> { }
        public sealed class NumericNonInfinityTests : NumericNonInfinityTestBase<SByteN> { }
        public sealed class NumericNonNaNTests : NumericNonNaNTestBase<SByteN> { }
        public sealed class NumericRandomTestBase : NumericRandomTestBase<SByteN> { }
        public sealed class NumericSignedTests : NumericSignedTestBase<SByteN> { }
        public sealed class NumericStringConvertTests : NumericStringConvertTestBase<SByteN> { }
        public sealed class NumericTests : NumericTestBase<SByteN> { }
        public sealed class ObjectTests : ObjectTestBase<SByteN> { }
        public sealed class SerializableTests : SerializableTestBase<SByteN> { }

        [Test, Repeat(RandomVariations)]
        public void IncrementOperator_RandomInputs_SameAsPlusOne()
        {
            //arrange
            SByteN input = Random.NextVariant<SByteN>();
            SByteN expected = input + 1;

            //act
            input++;

            //assert
            input.Should().Be(expected);
        }

        [Test, Repeat(RandomVariations)]
        public void DecrementOperator_RandomInputs_SameAsMinusOne()
        {
            //arrange
            SByteN input = Random.NextVariant<SByteN>();
            SByteN expected = input - 1;

            //act
            input--;

            //assert
            input.Should().Be(expected);
        }
    }
}
