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

using Jodosoft.Numerics.Compatibility;
using Jodosoft.Primitives.Tests;
using Jodosoft.Testing;

namespace Jodosoft.Numerics.Tests
{
    public static class Vector3NTests
    {
        public sealed class FixedPointBinaryIOTests : BinaryIOTestBase<Vector3N<Fix64>> { }
        public sealed class FixedPointFormattableTests : FormattableTestBase<Vector3N<Fix64>> { }
        public sealed class FixedPointObjectTests : ObjectTestBase<Vector3N<Fix64>> { }
        public sealed class FixedPointSerializableTests : SerializableTestBase<Vector3N<Fix64>> { }
        public sealed class FixedPointVector3Tests : Vector3NTestBase<Fix64> { }
        public sealed class FloatingPointBinaryIOTests : BinaryIOTestBase<Vector3N<NSingle>> { }
        public sealed class FloatingPointFormattableTests : FormattableTestBase<Vector3N<NSingle>> { }
        public sealed class FloatingPointObjectTests : ObjectTestBase<Vector3N<NSingle>> { }
        public sealed class FloatingPointSerializableTests : SerializableTestBase<Vector3N<NSingle>> { }
        public sealed class FloatingPointVector3Tests : Vector3NTestBase<NSingle> { }
        public sealed class UnsignedIntegralBinaryIOTests : BinaryIOTestBase<Vector3N<NByte>> { }
        public sealed class UnsignedIntegralFormattableTests : FormattableTestBase<Vector3N<NByte>> { }
        public sealed class UnsignedIntegralObjectTests : ObjectTestBase<Vector3N<NByte>> { }
        public sealed class UnsignedIntegralSerializableTests : SerializableTestBase<Vector3N<NByte>> { }
        public sealed class UnsignedIntegralVector3Tests : Vector3NTestBase<NByte> { }
    }
}
