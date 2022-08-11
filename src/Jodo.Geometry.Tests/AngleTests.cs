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
using Jodo.Numerics;
using Jodo.Testing;
using NUnit.Framework;

namespace Jodo.Geometry.Tests
{
    public static class AngleTests
    {
        public sealed class FixedPointBitConverter : Primitives.Tests.BitConvertTestsBase<Angle<Fix64>> { }
        public sealed class FixedPointGeneralTests : GeneralTests<Fix64> { }
        public sealed class FixedPointObjectTests : Primitives.Tests.ObjectTestsBase<Angle<Fix64>> { }
        public sealed class FixedPointSerializableTests : Primitives.Tests.SerializableTestsBase<Angle<Fix64>> { }

        public sealed class FloatingPointBitConverter : Primitives.Tests.BitConvertTestsBase<Angle<SingleN>> { }
        public sealed class FloatingPointGeneralTests : GeneralTests<SingleN> { }
        public sealed class FloatingPointObjectTests : Primitives.Tests.ObjectTestsBase<Angle<SingleN>> { }
        public sealed class FloatingPointSerializableTests : Primitives.Tests.SerializableTestsBase<Angle<SingleN>> { }

        public sealed class UnsignedIntegralBitConverter : Primitives.Tests.BitConvertTestsBase<Angle<ByteN>> { }
        public sealed class UnsignedIntegralGeneralTests : GeneralTests<ByteN> { }
        public sealed class UnsignedIntegralObjectTests : Primitives.Tests.ObjectTestsBase<Angle<ByteN>> { }
        public sealed class UnsignedIntegralSerializableTests : Primitives.Tests.SerializableTestsBase<Angle<ByteN>> { }
        public sealed class UnsignedIntegralStringParser : Primitives.Tests.StringParserTestsBase<Angle<ByteN>> { }

        public abstract class GeneralTests<TNumeric> : GlobalFixtureBase where TNumeric : struct, INumeric<TNumeric>
        {
            [Test]
            public void Degrees_FromDegrees_SameAsOriginal()
            {
                //arrange
                TNumeric input = Random.NextNumeric<TNumeric>();

                //act
                TNumeric result = Angle.FromDegrees(input).Degrees;

                //assert
                result.Should().Be(input);
            }
        }
    }
}
