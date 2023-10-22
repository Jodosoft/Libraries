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
using Jodosoft.Numerics.Compatibility;
using Jodosoft.Primitives.Tests;
using Jodosoft.Testing;

namespace Jodosoft.Geometry.Tests
{
    public static class AARectangleNTests
    {
        public sealed class AARectangleIntegralFixedPointTests : AARectangleNTestBase<Fix64> { }
        public sealed class AARectangleIntegralFloatingPointTests : AARectangleNTestBase<NSingle> { }
        public sealed class AARectangleIntegralUnsignedIntegralTests : AARectangleNIntegralTestBase<NByte> { }
        public sealed class FixedPointBinaryIOTests : BinaryIOTestBase<AARectangleN<Fix64>> { }
        public sealed class FixedPointFormattableTests : FormattableTestBase<AARectangleN<Fix64>> { }
        public sealed class FixedPointObjectTests : ObjectTestBase<AARectangleN<Fix64>> { }
        public sealed class FixedPointSerializableTests : SerializableTestBase<AARectangleN<Fix64>> { }
        public sealed class FloatingPointBinaryIOTests : BinaryIOTestBase<AARectangleN<NSingle>> { }
        public sealed class FloatingPointFormattableTests : FormattableTestBase<AARectangleN<NSingle>> { }
        public sealed class FloatingPointObjectTests : ObjectTestBase<AARectangleN<NSingle>> { }
        public sealed class FloatingPointSerializableTests : SerializableTestBase<AARectangleN<NSingle>> { }
        public sealed class UnsignedIntegralBinaryIOTests : BinaryIOTestBase<AARectangleN<NByte>> { }
        public sealed class UnsignedIntegralFormattableTests : FormattableTestBase<AARectangleN<NByte>> { }
        public sealed class UnsignedIntegralObjectTests : ObjectTestBase<AARectangleN<NByte>> { }
        public sealed class UnsignedIntegralSerializableTests : SerializableTestBase<AARectangleN<NByte>> { }
    }
}
