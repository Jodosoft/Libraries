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
    public static class AngleNTests
    {
        public sealed class FixedPointBinaryIOTests : BinaryIOTestBase<AngleN<Fix64>> { }
        public sealed class FixedPointFormattableTests : FormattableTestBase<AngleN<Fix64>> { }
        public sealed class FixedPointGeneralTests : AngleNTestBase<Fix64> { }
        public sealed class FixedPointObjectTests : ObjectTestBase<AngleN<Fix64>> { }
        public sealed class FixedPointSerializableFixedPointTests : SerializableTestBase<AngleN<Fix64>> { }
        public sealed class FloatingPointBinaryIOTests : BinaryIOTestBase<AngleN<NSingle>> { }
        public sealed class FloatingPointFormattableTests : FormattableTestBase<AngleN<NSingle>> { }
        public sealed class FloatingPointGeneralTests : AngleNTestBase<NSingle> { }
        public sealed class FloatingPointObjectTests : ObjectTestBase<AngleN<NSingle>> { }
        public sealed class FloatingPointSerializableTests : SerializableTestBase<AngleN<NSingle>> { }
        public sealed class UnsignedIntegralBinaryIOTests : BinaryIOTestBase<AngleN<NByte>> { }
        public sealed class UnsignedIntegralFormattableTests : FormattableTestBase<AngleN<NByte>> { }
        public sealed class UnsignedIntegralGeneralTests : AngleNTestBase<NByte> { }
        public sealed class UnsignedIntegralObjectTests : ObjectTestBase<AngleN<NByte>> { }
        public sealed class UnsignedIntegralSerializableTests : SerializableTestBase<AngleN<NByte>> { }
    }
}
