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
    public static class UFix64Tests
    {
        public sealed class NumericBitConverterTests : NumericBitConverterTestBase<UFix64> { }
        public sealed class NumericCastTests : NumericCastTestBase<UFix64> { }
        public sealed class NumericConversionConsistencyTests : NumericConversionConsistencyTestBase<UFix64> { }
        public sealed class NumericConvertTests : NumericConvertTestBase<UFix64> { }
        public sealed class NumericMathTests : NumericMathTestBase<UFix64> { }
        public sealed class NumericNonFloatingPointTests : NumericNonFloatingPointTestBase<UFix64> { }
        public sealed class NumericNonInfinityTests : NumericNonInfinityTestBase<UFix64> { }
        public sealed class NumericNonNaNTests : NumericNonNaNTestBase<UFix64> { }
        public sealed class NumericRandomTestBase : NumericRandomTestBase<UFix64> { }
        public sealed class NumericRealTests : NumericRealTestBase<UFix64> { }
        public sealed class NumericStringConvertTests : NumericStringConvertTestBase<UFix64> { }
        public sealed class NumericTests : NumericTestBase<UFix64> { }
        public sealed class NumericUnsignedTests : NumericUnsignedTestBase<UFix64> { }
        public sealed class ObjectTests : ObjectTestBase<UFix64> { }
        public sealed class SerializableTests : SerializableTestBase<UFix64> { }
    }
}
