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
    public sealed class UInt32NTests : GlobalFixtureBase
    {
        public sealed class BinaryIOTests : BinaryIOTestBase<UInt32N> { }
        public sealed class FormattableTests : FormattableTestBase<UInt32N> { }
        public sealed class JsonConvertTests : JsonConvertTestBase<UInt32N> { }
        public sealed class NumericBitConverterTests : NumericBitConverterTestBase<UInt32N> { }
        public sealed class NumericCastTests : NumericCastTestBase<UInt32N> { }
        public sealed class NumericConversionConsistencyTests : NumericConversionConsistencyTestBase<UInt32N> { }
        public sealed class NumericConvertTests : NumericConvertTestBase<UInt32N> { }
        public sealed class NumericIntegralTests : NumericIntegralTestBase<UInt32N> { }
        public sealed class NumericMathTests : NumericMathTestBase<UInt32N> { }
        public sealed class NumericNonFloatingPointTests : NumericNonFloatingPointTestBase<UInt32N> { }
        public sealed class NumericNonInfinityTests : NumericNonInfinityTestBase<UInt32N> { }
        public sealed class NumericNonNaNTests : NumericNonNaNTestBase<UInt32N> { }
        public sealed class NumericRandomTestBase : NumericRandomTestBase<UInt32N> { }
        public sealed class NumericStringConvertTests : NumericStringConvertTestBase<UInt32N> { }
        public sealed class NumericTests : NumericTestBase<UInt32N> { }
        public sealed class NumericUnsignedTests : NumericUnsignedTestBase<UInt32N> { }
        public sealed class NumericWrapperIntegralTests : NumericWrapperIntegralTestBase<UInt32N, uint> { }
        public sealed class NumericWrapperTests : NumericWrapperTestBase<UInt32N, uint> { }
        public sealed class ObjectTests : ObjectTestBase<UInt32N> { }
        public sealed class SerializableTests : SerializableTestBase<UInt32N> { }

        [Test, Repeat(RandomVariations)]
        public void IncrementOperator_RandomInputs_SameAsPlusOne()
        {
            //arrange
            UInt32N input = Random.NextVariant<UInt32N>();
            UInt32N expected = input + 1;

            //act
            input++;

            //assert
            input.Should().Be(expected);
        }

        [Test, Repeat(RandomVariations)]
        public void DecrementOperator_RandomInputs_SameAsMinusOne()
        {
            //arrange
            UInt32N input = Random.NextVariant<UInt32N>();
            UInt32N expected = input - 1;

            //act
            input--;

            //assert
            input.Should().Be(expected);
        }
    }
}
