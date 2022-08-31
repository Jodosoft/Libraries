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
    public static class SByteCTests
    {
        public sealed class CheckedNumericConversionTests : CheckedNumericConversionTestBase<SByteC> { }
        public sealed class CheckedNumericTests : CheckedNumericTestBase<SByteC> { }
        public sealed class NumericBitConverterTests : NumericBitConverterTestBase<SByteC> { }
        public sealed class NumericCastTests : NumericCastTestBase<SByteC> { }
        public sealed class NumericConvertTests : NumericConvertTestBase<SByteC> { }
        public sealed class NumericIntegralTests : NumericIntegralTestBase<SByteC> { }
        public sealed class NumericMathTests : NumericMathTestBase<SByteC> { }
        public sealed class NumericNonFloatingPointTests : NumericNonFloatingPointTestBase<SByteC> { }
        public sealed class NumericNonInfinityTests : NumericNonInfinityTestBase<SByteC> { }
        public sealed class NumericNonNaNTests : NumericNonNaNTestBase<SByteC> { }
        public sealed class NumericRandomTestBase : NumericRandomTestBase<SByteC> { }
        public sealed class NumericSignedTests : NumericSignedTestBase<SByteC> { }
        public sealed class NumericStringConvertTests : NumericStringConvertTestBase<SByteC> { }
        public sealed class NumericTests : NumericTestBase<SByteC> { }
        public sealed class ObjectTests : ObjectTestBase<SByteC> { }
        public sealed class SerializableTests : SerializableTestBase<SByteC> { }
    }
}
