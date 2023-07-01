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
    public sealed class Int16NTests : GlobalFixtureBase
    {
        public sealed class BinaryIOTests : BinaryIOTestBase<Int16N> { }
        public sealed class FormattableTests : FormattableTestBase<Int16N> { }
        public sealed class JsonConvertTests : JsonConvertTestBase<Int16N> { }
        public sealed class NumericBitConverterTests : NumericBitConverterTestBase<Int16N> { }
        public sealed class NumericCastTests : NumericCastTestBase<Int16N> { }
        public sealed class NumericConversionConsistencyTests : NumericConversionConsistencyTestBase<Int16N> { }
        public sealed class NumericConvertTests : NumericConvertTestBase<Int16N> { }
        public sealed class NumericIntegralTests : NumericIntegralTestBase<Int16N> { }
        public sealed class NumericMathTests : NumericMathTestBase<Int16N> { }
        public sealed class NumericNonFloatingPointTests : NumericNonFloatingPointTestBase<Int16N> { }
        public sealed class NumericNonInfinityTests : NumericNonInfinityTestBase<Int16N> { }
        public sealed class NumericNonNaNTests : NumericNonNaNTestBase<Int16N> { }
        public sealed class NumericRandomTestBase : NumericRandomTestBase<Int16N> { }
        public sealed class NumericSignedTests : NumericSignedTestBase<Int16N> { }
        public sealed class NumericStringConvertTests : NumericStringConvertTestBase<Int16N> { }
        public sealed class NumericTests : NumericTestBase<Int16N> { }
        public sealed class NumericWrapperIntegralTests : NumericWrapperIntegralTestBase<Int16N, short> { }
        public sealed class NumericWrapperTests : NumericWrapperTestBase<Int16N, short> { }
        public sealed class ObjectTests : ObjectTestBase<Int16N> { }
        public sealed class SerializableTests : SerializableTestBase<Int16N> { }

        [Test, Repeat(RandomVariations)]
        public void IncrementOperator_RandomInputs_SameAsPlusOne()
        {
            //arrange
            Int16N input = Random.NextVariant<Int16N>();
            Int16N expected = input + (short)1;

            //act
            input++;

            //assert
            input.Should().Be(expected);
        }

        [Test, Repeat(RandomVariations)]
        public void DecrementOperator_RandomInputs_SameAsMinusOne()
        {
            //arrange
            Int16N input = Random.NextVariant<Int16N>();
            Int16N expected = input - (short)1;

            //act
            input--;

            //assert
            input.Should().Be(expected);
        }
    }
}
