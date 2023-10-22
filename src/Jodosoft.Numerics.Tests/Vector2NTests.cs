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

using FluentAssertions;
using Jodosoft.Numerics.Compatibility;
using Jodosoft.Primitives.Tests;
using Jodosoft.Testing;
using NUnit.Framework;

namespace Jodosoft.Numerics.Tests
{
    public class Vector2NTests : GlobalFixtureBase
    {
        public sealed class FixedPointBinaryIOTests : BinaryIOTestBase<Vector2N<Fix64>> { }
        public sealed class FixedPointFormattableTests : FormattableTestBase<Vector2N<Fix64>> { }
        public sealed class FixedPointObjectTests : ObjectTestBase<Vector2N<Fix64>> { }
        public sealed class FixedPointSerializableTests : SerializableTestBase<Vector2N<Fix64>> { }
        public sealed class FixedPointVector2Tests : Vector2NTestBase<Fix64> { }
        public sealed class FloatingPointBinaryIOTests : BinaryIOTestBase<Vector2N<NSingle>> { }
        public sealed class FloatingPointFormattableTests : FormattableTestBase<Vector2N<NSingle>> { }
        public sealed class FloatingPointObjectTests : ObjectTestBase<Vector2N<NSingle>> { }
        public sealed class FloatingPointSerializableTests : SerializableTestBase<Vector2N<NSingle>> { }
        public sealed class FloatingPointVector2Tests : Vector2NTestBase<NSingle> { }
        public sealed class UnsignedIntegralBinaryIOTests : BinaryIOTestBase<Vector2N<NByte>> { }
        public sealed class UnsignedIntegralFormattableTests : FormattableTestBase<Vector2N<NByte>> { }
        public sealed class UnsignedIntegralObjectTests : ObjectTestBase<Vector2N<NByte>> { }
        public sealed class UnsignedIntegralSerializableTests : SerializableTestBase<Vector2N<NByte>> { }
        public sealed class UnsignedIntegralVector2Tests : Vector2NTestBase<NByte> { }

        [Test]
        public void Dot_WorkedExample_CorrectResult()
        {
            //arrange
            //act
            NSingle result = Vector2N.Dot(
                new Vector2N<NSingle>(2, -4), new Vector2N<NSingle>(-8, 104));

            //assert
            result.Should().Be(-432);
        }
    }
}
