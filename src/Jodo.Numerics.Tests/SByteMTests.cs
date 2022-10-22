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
    public static class SByteMTests
    {
        public sealed class BitBufferTests : BitBufferTestBase<SByteM> { }
        public sealed class CheckedNumericConversionTests : CheckedNumericConversionTestBase<SByteM> { }
        public sealed class CheckedNumericTests : CheckedNumericTestBase<SByteM> { }
        public sealed class JsonConvertTests : JsonConvertTestBase<SByteM> { }
        public sealed class NumericBitConverterTests : NumericBitConverterTestBase<SByteM> { }
        public sealed class NumericCastTests : NumericCastTestBase<SByteM> { }
        public sealed class NumericConvertTests : NumericConvertTestBase<SByteM> { }
        public sealed class NumericIntegralTests : NumericIntegralTestBase<SByteM> { }
        public sealed class NumericMathTests : NumericMathTestBase<SByteM> { }
        public sealed class NumericNonFloatingPointTests : NumericNonFloatingPointTestBase<SByteM> { }
        public sealed class NumericNonInfinityTests : NumericNonInfinityTestBase<SByteM> { }
        public sealed class NumericNonNaNTests : NumericNonNaNTestBase<SByteM> { }
        public sealed class NumericRandomTestBase : NumericRandomTestBase<SByteM> { }
        public sealed class NumericSignedTests : NumericSignedTestBase<SByteM> { }
        public sealed class NumericStringConvertTests : NumericStringConvertTestBase<SByteM> { }
        public sealed class NumericTests : NumericTestBase<SByteM> { }
        public sealed class ObjectTests : ObjectTestBase<SByteM> { }
        public sealed class SerializableTests : SerializableTestBase<SByteM> { }
    }
}
