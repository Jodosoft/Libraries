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
using Jodo.Testing;

namespace Jodo.Geometry.Tests
{
    public static class AARectangleTests
    {
        public sealed class AARectangleIntegralFixedPointTests : AARectangleTestBase<Fix64Temp> { }
        public sealed class AARectangleIntegralFloatingPointTests : AARectangleTestBase<SingleN> { }
        public sealed class AARectangleIntegralUnsignedIntegralTests : AARectangleIntegralTestBase<ByteN> { }
        public sealed class ObjectFixedPointTests : ObjectTestBase<AARectangle<Fix64Temp>> { }
        public sealed class ObjectFloatingPointTests : ObjectTestBase<AARectangle<SingleN>> { }
        public sealed class ObjectUnsignedIntegralTests : ObjectTestBase<AARectangle<ByteN>> { }
        public sealed class SerializableFixedPointTests : SerializableTestBase<AARectangle<Fix64Temp>> { }
        public sealed class SerializableFloatingPointTests : SerializableTestBase<AARectangle<SingleN>> { }
        public sealed class SerializableUnsignedIntegralTests : SerializableTestBase<AARectangle<ByteN>> { }
    }
}
