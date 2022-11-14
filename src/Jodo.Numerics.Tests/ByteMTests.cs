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

using Jodo.Numerics.Clamped;
using Jodo.Primitives.Tests;
using Jodo.Testing;
using Jodo.Testing.NewtonsoftJson;

namespace Jodo.Numerics.Tests
{
    public static class ByteMTests
    {
        public sealed class BinaryConvertTests : BinaryConvertTestBase<ByteM> { }
        public sealed class CheckedNumericConversionTests : CheckedNumericConversionTestBase<ByteM> { }
        public sealed class CheckedNumericTests : CheckedNumericTestBase<ByteM> { }
        public sealed class JsonConvertTests : JsonConvertTestBase<ByteM> { }
        public sealed class NumericBitConverterTests : NumericBitConverterTestBase<ByteM> { }
        public sealed class NumericCastTests : NumericCastTestBase<ByteM> { }
        public sealed class NumericConvertTests : NumericConvertTestBase<ByteM> { }
        public sealed class NumericIntegralTests : NumericIntegralTestBase<ByteM> { }
        public sealed class NumericMathTests : NumericMathTestBase<ByteM> { }
        public sealed class NumericNonFloatingPointTests : NumericNonFloatingPointTestBase<ByteM> { }
        public sealed class NumericNonInfinityTests : NumericNonInfinityTestBase<ByteM> { }
        public sealed class NumericNonNaNTests : NumericNonNaNTestBase<ByteM> { }
        public sealed class NumericRandomTestBase : NumericRandomTestBase<ByteM> { }
        public sealed class NumericStringConvertTests : NumericStringConvertTestBase<ByteM> { }
        public sealed class NumericTests : NumericTestBase<ByteM> { }
        public sealed class NumericUnsignedTests : NumericUnsignedTestBase<ByteM> { }
        public sealed class ObjectTests : ObjectTestBase<ByteM> { }
        public sealed class SerializableTests : SerializableTestBase<ByteM> { }
    }
}
