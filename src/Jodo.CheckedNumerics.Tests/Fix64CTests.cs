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
    public static class Fix64CTests
    {
        public sealed class CheckedNumericConversionTests : CheckedNumericConversionTestBase<Fix64C> { }
        public sealed class CheckedNumericTests : CheckedNumericTestBase<Fix64C> { }
        public sealed class NumericBitConverterTests : NumericBitConverterTestBase<Fix64C> { }
        public sealed class NumericCastTests : NumericCastTestBase<Fix64C> { }
        public sealed class NumericConvertTests : NumericConvertTestBase<Fix64C> { }
        public sealed class NumericMathTests : NumericMathTestBase<Fix64C> { }
        public sealed class NumericNonFloatingPointTests : NumericNonFloatingPointTestBase<Fix64C> { }
        public sealed class NumericNonInfinityTests : NumericNonInfinityTestBase<Fix64C> { }
        public sealed class NumericNonNaNTests : NumericNonNaNTestBase<Fix64C> { }
        public sealed class NumericRandomTestBase : NumericRandomTestBase<Fix64C> { }
        public sealed class NumericRealTests : NumericRealTestBase<Fix64C> { }
        public sealed class NumericSignedTests : NumericSignedTestBase<Fix64C> { }
        public sealed class NumericStringConvertTests : NumericStringConvertTestBase<Fix64C> { }
        public sealed class NumericTests : NumericTestBase<Fix64C> { }
        public sealed class ObjectTests : ObjectTestBase<Fix64C> { }
        public sealed class SerializableTests : SerializableTestBase<Fix64C> { }
    }
}
