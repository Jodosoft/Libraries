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

using Jodo.Numerics.Tests;
using Jodo.Primitives.Tests;

namespace Jodo.CheckedNumerics.Tests
{
    public static class DoubleCTests
    {
        public sealed class CheckedNumericConversionTests : CheckedNumericConversionTestBase<DoubleC> { }
        public sealed class CheckedNumericTests : CheckedNumericTestBase<DoubleC> { }
        public sealed class NumericBitConverterTests : NumericBitConverterTestBase<DoubleC> { }
        public sealed class NumericCastTests : NumericCastTestBase<DoubleC> { }
        public sealed class NumericConvertTests : NumericConvertTestBase<DoubleC> { }
        public sealed class NumericFloatingPointTests : NumericFloatingPointTestBase<DoubleC> { }
        public sealed class NumericMathTests : NumericMathTestBase<DoubleC> { }
        public sealed class NumericNonInfinityTests : NumericNonInfinityTestBase<DoubleC> { }
        public sealed class NumericNonNaNTests : NumericNonNaNTestBase<DoubleC> { }
        public sealed class NumericRandomTestBase : NumericRandomTestBase<DoubleC> { }
        public sealed class NumericRealTests : NumericRealTestBase<DoubleC> { }
        public sealed class NumericSignedTests : NumericSignedTestBase<DoubleC> { }
        public sealed class NumericStringConvertTests : NumericStringConvertTestBase<DoubleC> { }
        public sealed class NumericTests : NumericTestBase<DoubleC> { }
        public sealed class ObjectTests : ObjectTestBase<DoubleC> { }
        public sealed class SerializableTests : SerializableTestBase<DoubleC> { }
    }
}
