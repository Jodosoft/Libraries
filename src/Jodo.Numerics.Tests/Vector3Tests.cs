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

using Jodo.Primitives.Tests;

namespace Jodo.Numerics.Tests
{
    public static class Vector3Tests
    {
        public sealed class FixedPointBitConvertTests : BitConvertTestBase<Vector3<Fix64>> { }
        public sealed class FixedPointObjectTests : ObjectTestBase<Vector3<Fix64>> { }
        public sealed class FixedPointSerializableTests : SerializableTestBase<Vector3<Fix64>> { }
        public sealed class FixedPointVector3Tests : Vector3TestBase<Fix64> { }
        public sealed class FloatingPointBitConvertTests : BitConvertTestBase<Vector3<SingleN>> { }
        public sealed class FloatingPointObjectTests : ObjectTestBase<Vector3<SingleN>> { }
        public sealed class FloatingPointSerializableTests : SerializableTestBase<Vector3<SingleN>> { }
        public sealed class FloatingPointVector3Tests : Vector3TestBase<SingleN> { }
        public sealed class UnsignedIntegralBitConvertTests : BitConvertTestBase<Vector3<ByteN>> { }
        public sealed class UnsignedIntegralObjectTests : ObjectTestBase<Vector3<ByteN>> { }
        public sealed class UnsignedIntegralSerializableTests : SerializableTestBase<Vector3<ByteN>> { }
        public sealed class UnsignedIntegralVector3Tests : Vector3TestBase<ByteN> { }
    }
}
