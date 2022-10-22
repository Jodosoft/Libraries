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

using Jodo.Numerics;
using Jodo.Primitives.Tests;
using Jodo.Testing;

namespace Jodo.Geometry.Tests
{
    public static class CircleTests
    {
        public sealed class FixedPointBitBufferTests : BitBufferTestBase<Circle<Fix64>> { }
        public sealed class FixedPointGeneralTests : CircleTestBase<Fix64> { }
        public sealed class FixedPointObjectTests : ObjectTestBase<Circle<Fix64>> { }
        public sealed class FixedPointSerializableTests : SerializableTestBase<Circle<Fix64>> { }
        public sealed class FloatingPointBitBufferTests : BitBufferTestBase<Circle<SingleN>> { }
        public sealed class FloatingPointGeneralTests : CircleTestBase<SingleN> { }
        public sealed class FloatingPointObjectTests : ObjectTestBase<Circle<SingleN>> { }
        public sealed class FloatingPointSerializableTests : SerializableTestBase<Circle<SingleN>> { }
        public sealed class UnsignedIntegralBitBufferTests : BitBufferTestBase<Circle<ByteN>> { }
        public sealed class UnsignedIntegralGeneralTests : CircleTestBase<ByteN> { }
        public sealed class UnsignedIntegralObjectTests : ObjectTestBase<Circle<ByteN>> { }
        public sealed class UnsignedIntegralSerializableTests : SerializableTestBase<Circle<ByteN>> { }
    }
}
