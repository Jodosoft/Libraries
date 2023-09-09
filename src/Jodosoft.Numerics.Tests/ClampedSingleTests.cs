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
    public sealed class ClampedSingleTests : GlobalFixtureBase
    {
        public sealed class BinaryIOTests : BinaryIOTestBase<ClampedSingle> { }
        public sealed class ClampedNumericConversionTests : ClampedNumericConversionTestBase<ClampedSingle> { }
        public sealed class ClampedNumericTests : ClampedNumericTestBase<ClampedSingle> { }
        public sealed class FormattableTests : FormattableTestBase<ClampedSingle> { }
        public sealed class JsonConvertTests : JsonConvertTestBase<ClampedSingle> { }
        public sealed class NumericBitConverterTests : NumericBitConverterTestBase<ClampedSingle> { }
        public sealed class NumericCastTests : NumericCastTestBase<ClampedSingle> { }
        public sealed class NumericConvertTests : NumericConvertTestBase<ClampedSingle> { }
        public sealed class NumericFloatingPointTests : NumericFloatingPointTestBase<ClampedSingle> { }
        public sealed class NumericMathTests : NumericMathTestBase<ClampedSingle> { }
        public sealed class NumericRandomTestBase : NumericRandomTestBase<ClampedSingle> { }
        public sealed class NumericSignedTests : NumericSignedTestBase<ClampedSingle> { }
        public sealed class NumericStringConvertTests : NumericStringConvertTestBase<ClampedSingle> { }
        public sealed class NumericTests : NumericTestBase<ClampedSingle> { }
        public sealed class ObjectTests : ObjectTestBase<ClampedSingle> { }
        public sealed class SerializableTests : SerializableTestBase<ClampedSingle> { }

        [Test, Repeat(RandomVariations)]
        public void IncrementOperator_RandomInputs_SameAsPlusOne()
        {
            //arrange
            ClampedSingle input = Random.NextVariant<ClampedSingle>(Variants.NonError);
            ClampedSingle expected = input + 1;

            //act
            input++;

            //assert
            input.Should().Be(expected);
        }

        [Test, Repeat(RandomVariations)]
        public void DecrementOperator_RandomInputs_SameAsMinusOne()
        {
            //arrange
            ClampedSingle input = Random.NextVariant<ClampedSingle>(Variants.NonError);
            ClampedSingle expected = input - 1;

            //act
            input--;

            //assert
            input.Should().Be(expected);
        }
    }
}
