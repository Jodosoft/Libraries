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
using Jodo.Primitives;
using Jodo.Primitives.Tests;
using Jodo.Testing;
using Jodo.Testing.NewtonsoftJson;
using NUnit.Framework;

namespace Jodo.Numerics.Tests
{
    public sealed class UFix64Tests : GlobalFixtureBase
    {
        public sealed class BinaryIOTests : BinaryIOTestBase<UFix64> { }
        public sealed class FormattableTests : FormattableTestBase<UFix64> { }
        public sealed class JsonConvertTests : JsonConvertTestBase<UFix64> { }
        public sealed class NumericBitConverterTests : NumericBitConverterTestBase<UFix64> { }
        public sealed class NumericCastTests : NumericCastTestBase<UFix64> { }
        public sealed class NumericConversionConsistencyTests : NumericConversionConsistencyTestBase<UFix64> { }
        public sealed class NumericConvertTests : NumericConvertTestBase<UFix64> { }
        public sealed class NumericFixedPointTests : NumericFixedPointTestBase<UFix64> { }
        public sealed class NumericMathTests : NumericMathTestBase<UFix64> { }
        public sealed class NumericNonFloatingPointTests : NumericNonFloatingPointTestBase<UFix64> { }
        public sealed class NumericNonInfinityTests : NumericNonInfinityTestBase<UFix64> { }
        public sealed class NumericNonNaNTests : NumericNonNaNTestBase<UFix64> { }
        public sealed class NumericRandomTestBase : NumericRandomTestBase<UFix64> { }
        public sealed class NumericRealTests : NumericRealTestBase<UFix64> { }
        public sealed class NumericStringConvertTests : NumericStringConvertTestBase<UFix64> { }
        public sealed class NumericTests : NumericTestBase<UFix64> { }
        public sealed class NumericUnsignedTests : NumericUnsignedTestBase<UFix64> { }
        public sealed class ObjectTests : ObjectTestBase<UFix64> { }
        public sealed class SerializableTests : SerializableTestBase<UFix64> { }

        [Test, Repeat(RandomVariations)]
        public void IncrementOperator_RandomInputs_SameAsPlusOne()
        {
            //arrange
            UFix64 input = Random.NextVariant<UFix64>();
            UFix64 expected = input + 1;

            //act
            input++;

            //assert
            input.Should().Be(expected);
        }

        [Test, Repeat(RandomVariations)]
        public void DecrementOperator_RandomInputs_SameAsMinusOne()
        {
            //arrange
            UFix64 input = Random.NextVariant<UFix64>();
            UFix64 expected = input - 1;

            //act
            input--;

            //assert
            input.Should().Be(expected);
        }
    }
}
