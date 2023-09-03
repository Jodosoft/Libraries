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

using Jodosoft.Numerics;
using Jodosoft.Primitives.Tests;
using Jodosoft.Testing;

namespace Jodosoft.Geometry.Tests
{
    public static class CircleNTests
    {
        public sealed class FixedPointBinaryIOTests : BinaryIOTestBase<CircleN<Fix64>> { }
        public sealed class FixedPointFormattableTests : FormattableTestBase<CircleN<Fix64>> { }
        public sealed class FixedPointGeneralTests : CircleNTestBase<Fix64> { }
        public sealed class FixedPointObjectTests : ObjectTestBase<CircleN<Fix64>> { }
        public sealed class FixedPointSerializableTests : SerializableTestBase<CircleN<Fix64>> { }
        public sealed class FloatingPointBinaryIOTests : BinaryIOTestBase<CircleN<SingleN>> { }
        public sealed class FloatingPointFormattableTests : FormattableTestBase<CircleN<SingleN>> { }
        public sealed class FloatingPointGeneralTests : CircleNTestBase<SingleN> { }
        public sealed class FloatingPointObjectTests : ObjectTestBase<CircleN<SingleN>> { }
        public sealed class FloatingPointSerializableTests : SerializableTestBase<CircleN<SingleN>> { }
        public sealed class UnsignedIntegralBinaryIOTests : BinaryIOTestBase<CircleN<ByteN>> { }
        public sealed class UnsignedIntegralFormattableTests : FormattableTestBase<CircleN<ByteN>> { }
        public sealed class UnsignedIntegralGeneralTests : CircleNTestBase<ByteN> { }
        public sealed class UnsignedIntegralObjectTests : ObjectTestBase<CircleN<ByteN>> { }
        public sealed class UnsignedIntegralSerializableTests : SerializableTestBase<CircleN<ByteN>> { }
    }
}
