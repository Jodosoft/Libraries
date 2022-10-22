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
using Jodo.Testing;
using Jodo.Testing.NewtonsoftJson;

namespace Jodo.Numerics.Tests
{
    public static class UInt32NTests
    {
        public sealed class BitBufferTests : BitBufferTestBase<UInt32N> { }
        public sealed class JsonConvertTests : JsonConvertTestBase<UInt32N> { }
        public sealed class NumericBitConverterTests : NumericBitConverterTestBase<UInt32N> { }
        public sealed class NumericCastTests : NumericCastTestBase<UInt32N> { }
        public sealed class NumericConversionConsistencyTests : NumericConversionConsistencyTestBase<UInt32N> { }
        public sealed class NumericConvertTests : NumericConvertTestBase<UInt32N> { }
        public sealed class NumericIntegralTests : NumericIntegralTestBase<UInt32N> { }
        public sealed class NumericMathTests : NumericMathTestBase<UInt32N> { }
        public sealed class NumericNonFloatingPointTests : NumericNonFloatingPointTestBase<UInt32N> { }
        public sealed class NumericNonInfinityTests : NumericNonInfinityTestBase<UInt32N> { }
        public sealed class NumericNonNaNTests : NumericNonNaNTestBase<UInt32N> { }
        public sealed class NumericRandomTestBase : NumericRandomTestBase<UInt32N> { }
        public sealed class NumericStringConvertTests : NumericStringConvertTestBase<UInt32N> { }
        public sealed class NumericTests : NumericTestBase<UInt32N> { }
        public sealed class NumericUnsignedTests : NumericUnsignedTestBase<UInt32N> { }
        public sealed class NumericWrapperIntegralTests : NumericWrapperIntegralTestBase<UInt32N, uint> { }
        public sealed class NumericWrapperTests : NumericWrapperTestBase<UInt32N, uint> { }
        public sealed class ObjectTests : ObjectTestBase<UInt32N> { }
        public sealed class SerializableTests : SerializableTestBase<UInt32N> { }
    }
}
