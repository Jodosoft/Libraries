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

using Jodosoft.Primitives.Tests;
using Jodosoft.Testing;

namespace Jodosoft.Numerics.Tests
{
    public static class UnitNTest
    {
        public sealed class FixedPointBinaryIOTests : BinaryIOTestBase<UnitN<Fix64>> { }
        public sealed class FixedPointFormattableTests : FormattableTestBase<UnitN<Fix64>> { }
        public sealed class FixedPointObjectTests : ObjectTestBase<UnitN<Fix64>> { }
        public sealed class FixedPointSerializableTests : SerializableTestBase<UnitN<Fix64>> { }
        public sealed class FixedPointUnitTests : UnitNTestBase<Fix64> { }
        public sealed class FloatingPointBinaryIOTests : BinaryIOTestBase<UnitN<SingleN>> { }
        public sealed class FloatingPointFormattableTests : FormattableTestBase<UnitN<SingleN>> { }
        public sealed class FloatingPointObjectTests : ObjectTestBase<UnitN<SingleN>> { }
        public sealed class FloatingPointSerializableTests : SerializableTestBase<UnitN<SingleN>> { }
        public sealed class FloatingPointUnitTests : UnitNTestBase<SingleN> { }
        public sealed class UnsignedIntegralBinaryIOTests : BinaryIOTestBase<UnitN<ByteN>> { }
        public sealed class UnsignedIntegralFormattableTests : FormattableTestBase<UnitN<ByteN>> { }
        public sealed class UnsignedIntegralObjectTests : ObjectTestBase<UnitN<ByteN>> { }
        public sealed class UnsignedIntegralSerializableTests : SerializableTestBase<UnitN<ByteN>> { }
        public sealed class UnsignedIntegralUnitTests : UnitNTestBase<ByteN> { }
    }
}
