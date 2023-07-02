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
using Jodo.Numerics.Clamped;
using Jodo.Primitives;
using Jodo.Primitives.Tests;
using Jodo.Testing;
using Jodo.Testing.NewtonsoftJson;
using NUnit.Framework;

namespace Jodo.Numerics.Tests
{
    public sealed class DoubleMTests : GlobalFixtureBase
    {
        public sealed class BinaryIOTests : BinaryIOTestBase<DoubleM> { }
        public sealed class CheckedNumericConversionTests : CheckedNumericConversionTestBase<DoubleM> { }
        public sealed class CheckedNumericTests : CheckedNumericTestBase<DoubleM> { }
        public sealed class FormattableTests : FormattableTestBase<DoubleM> { }
        public sealed class JsonConvertTests : JsonConvertTestBase<DoubleM> { }
        public sealed class NumericBitConverterTests : NumericBitConverterTestBase<DoubleM> { }
        public sealed class NumericCastTests : NumericCastTestBase<DoubleM> { }
        public sealed class NumericConvertTests : NumericConvertTestBase<DoubleM> { }
        public sealed class NumericFloatingPointTests : NumericFloatingPointTestBase<DoubleM> { }
        public sealed class NumericMathTests : NumericMathTestBase<DoubleM> { }
        public sealed class NumericNonInfinityTests : NumericNonInfinityTestBase<DoubleM> { }
        public sealed class NumericNonNaNTests : NumericNonNaNTestBase<DoubleM> { }
        public sealed class NumericRandomTestBase : NumericRandomTestBase<DoubleM> { }
        public sealed class NumericRealTests : NumericRealTestBase<DoubleM> { }
        public sealed class NumericSignedTests : NumericSignedTestBase<DoubleM> { }
        public sealed class NumericStringConvertTests : NumericStringConvertTestBase<DoubleM> { }
        public sealed class NumericTests : NumericTestBase<DoubleM> { }
        public sealed class ObjectTests : ObjectTestBase<DoubleM> { }
        public sealed class SerializableTests : SerializableTestBase<DoubleM> { }

        [Test, Repeat(RandomVariations)]
        public void IncrementOperator_RandomInputs_SameAsPlusOne()
        {
            //arrange
            DoubleM input = Random.NextVariant<DoubleM>(Variants.NonError);
            DoubleM expected = input + 1;

            //act
            input++;

            //assert
            input.Should().Be(expected);
        }

        [Test, Repeat(RandomVariations)]
        public void DecrementOperator_RandomInputs_SameAsMinusOne()
        {
            //arrange
            DoubleM input = Random.NextVariant<DoubleM>(Variants.NonError);
            DoubleM expected = input - 1;

            //act
            input--;

            //assert
            input.Should().Be(expected);
        }
    }
}
