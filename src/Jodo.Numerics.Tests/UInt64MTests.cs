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
    public static class UInt64MTests
    {
        public sealed class BinaryIOTests : BinaryIOTestBase<UInt64M> { }
        public sealed class CheckedNumericConversionTests : CheckedNumericConversionTestBase<UInt64M> { }
        public sealed class CheckedNumericTests : CheckedNumericTestBase<UInt64M> { }
        public sealed class JsonConvertTests : JsonConvertTestBase<UInt64M> { }
        public sealed class NumericBitConverterTests : NumericBitConverterTestBase<UInt64M> { }
        public sealed class NumericCastTests : NumericCastTestBase<UInt64M> { }
        public sealed class NumericConvertTests : NumericConvertTestBase<UInt64M> { }
        public sealed class NumericIntegralTests : NumericIntegralTestBase<UInt64M> { }
        public sealed class NumericMathTests : NumericMathTestBase<UInt64M> { }
        public sealed class NumericNonFloatingPointTests : NumericNonFloatingPointTestBase<UInt64M> { }
        public sealed class NumericNonInfinityTests : NumericNonInfinityTestBase<UInt64M> { }
        public sealed class NumericNonNaNTests : NumericNonNaNTestBase<UInt64M> { }
        public sealed class NumericRandomTestBase : NumericRandomTestBase<UInt64M> { }
        public sealed class NumericStringConvertTests : NumericStringConvertTestBase<UInt64M> { }
        public sealed class NumericTests : NumericTestBase<UInt64M> { }
        public sealed class NumericUnsignedTests : NumericUnsignedTestBase<UInt64M> { }
        public sealed class ObjectTests : ObjectTestBase<UInt64M> { }
        public sealed class SerializableTests : SerializableTestBase<UInt64M> { }
    }
}
