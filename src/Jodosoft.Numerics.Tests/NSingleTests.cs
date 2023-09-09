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
    public sealed class NSingleTests : GlobalFixtureBase
    {
        public sealed class BinaryIOTests : BinaryIOTestBase<NSingle> { }
        public sealed class FormattableTests : FormattableTestBase<NSingle> { }
        public sealed class JsonConvertTests : JsonConvertTestBase<NSingle> { }
        public sealed class NumericBitConverterTests : NumericBitConverterTestBase<NSingle> { }
        public sealed class NumericCastTests : NumericCastTestBase<NSingle> { }
        public sealed class NumericConversionConsistencyTests : NumericConversionConsistencyTestBase<NSingle> { }
        public sealed class NumericConvertTests : NumericConvertTestBase<NSingle> { }
        public sealed class NumericFloatingPointTests : NumericFloatingPointTestBase<NSingle> { }
        public sealed class NumericInfinityTests : NumericInfinityTestBase<NSingle> { }
        public sealed class NumericMathErrorNaNTests : NumericMathErrorNaNTestBase<NSingle> { }
        public sealed class NumericMathTests : NumericMathTestBase<NSingle> { }
        public sealed class NumericNaNTests : NumericNaNTestBase<NSingle> { }
        public sealed class NumericRandomTestBase : NumericRandomTestBase<NSingle> { }
        public sealed class NumericRealTests : NumericRealTestBase<NSingle> { }
        public sealed class NumericSignedTests : NumericSignedTestBase<NSingle> { }
        public sealed class NumericStringConvertTests : NumericStringConvertTestBase<NSingle> { }
        public sealed class NumericTests : NumericTestBase<NSingle> { }
        public sealed class NumericWrapperTests : NumericWrapperTestBase<NSingle, float> { }
        public sealed class ObjectTests : ObjectTestBase<NSingle> { }
        public sealed class SerializableTests : SerializableTestBase<NSingle> { }

        [Test, Repeat(RandomVariations)]
        public void IncrementOperator_RandomInputs_SameAsPlusOne()
        {
            //arrange
            NSingle input = Random.NextVariant<NSingle>(Variants.NonError);
            NSingle expected = input + 1;

            //act
            input++;

            //assert
            input.Should().Be(expected);
        }

        [Test, Repeat(RandomVariations)]
        public void DecrementOperator_RandomInputs_SameAsMinusOne()
        {
            //arrange
            NSingle input = Random.NextVariant<NSingle>(Variants.NonError);
            NSingle expected = input - 1;

            //act
            input--;

            //assert
            input.Should().Be(expected);
        }
    }
}
