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
    public static class RectangleNTests
    {
        public sealed class FixedPointBinaryIOTests : BinaryIOTestBase<RectangleN<Fix64>> { }
        public sealed class FixedPointFormattableTests : FormattableTestBase<RectangleN<Fix64>> { }
        public sealed class FixedPointObjectTests : ObjectTestBase<RectangleN<Fix64>> { }
        public sealed class FixedPointRectangleTests : RectangleNTestBase<Fix64> { }
        public sealed class FixedPointSerializableTests : SerializableTestBase<RectangleN<Fix64>> { }
        public sealed class FloatingPointBinaryIOTests : BinaryIOTestBase<RectangleN<SingleN>> { }
        public sealed class FloatingPointFormattableTests : FormattableTestBase<RectangleN<SingleN>> { }
        public sealed class FloatingPointObjectTests : ObjectTestBase<RectangleN<SingleN>> { }
        public sealed class FloatingPointRectangleTests : RectangleNTestBase<SingleN> { }
        public sealed class FloatingPointSerializableTests : SerializableTestBase<RectangleN<SingleN>> { }
        public sealed class UnsignedIntegralBinaryIOTests : BinaryIOTestBase<RectangleN<ByteN>> { }
        public sealed class UnsignedIntegralFormattableTests : FormattableTestBase<RectangleN<ByteN>> { }
        public sealed class UnsignedIntegralObjectTests : ObjectTestBase<RectangleN<ByteN>> { }
        public sealed class UnsignedIntegralRectangleTests : RectangleNTestBase<ByteN> { }
        public sealed class UnsignedIntegralSerializableTests : SerializableTestBase<RectangleN<ByteN>> { }
    }
}
