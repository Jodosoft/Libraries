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

using FluentAssertions;
using Jodo.Primitives.Tests;
using Jodo.Testing;
using NUnit.Framework;

namespace Jodo.Numerics.Tests
{
    public class Vector2NTests : GlobalFixtureBase
    {
        public sealed class FixedPointBinaryIOTests : BinaryIOTestBase<Vector2N<Fix64>> { }
        public sealed class FixedPointFormattableTests : FormattableTestBase<Vector2N<Fix64>> { }
        public sealed class FixedPointObjectTests : ObjectTestBase<Vector2N<Fix64>> { }
        public sealed class FixedPointSerializableTests : SerializableTestBase<Vector2N<Fix64>> { }
        public sealed class FixedPointVector2Tests : Vector2NTestBase<Fix64> { }
        public sealed class FloatingPointBinaryIOTests : BinaryIOTestBase<Vector2N<SingleN>> { }
        public sealed class FloatingPointFormattableTests : FormattableTestBase<Vector2N<SingleN>> { }
        public sealed class FloatingPointObjectTests : ObjectTestBase<Vector2N<SingleN>> { }
        public sealed class FloatingPointSerializableTests : SerializableTestBase<Vector2N<SingleN>> { }
        public sealed class FloatingPointVector2Tests : Vector2NTestBase<SingleN> { }
        public sealed class UnsignedIntegralBinaryIOTests : BinaryIOTestBase<Vector2N<ByteN>> { }
        public sealed class UnsignedIntegralFormattableTests : FormattableTestBase<Vector2N<ByteN>> { }
        public sealed class UnsignedIntegralObjectTests : ObjectTestBase<Vector2N<ByteN>> { }
        public sealed class UnsignedIntegralSerializableTests : SerializableTestBase<Vector2N<ByteN>> { }
        public sealed class UnsignedIntegralVector2Tests : Vector2NTestBase<ByteN> { }

        [Test]
        public void Dot_WorkedExample_CorrectResult()
        {
            //arrange
            //act
            SingleN result = Vector2N.Dot(
                new Vector2N<SingleN>(2, -4), new Vector2N<SingleN>(-8, 104));

            //assert
            result.Should().Be(-432);
        }
    }
}
