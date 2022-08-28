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
    public static class SingleNTests
    {
        public sealed class BitConvertTests : BitConvertTestBase<SingleN> { }
        public sealed class NumericBitConvertTests : NumericBitConvertTestBase<SingleN> { }
        public sealed class NumericCastTests : NumericCastTestBase<SingleN> { }
        public sealed class NumericConversionConsistencyTests : NumericConversionConsistencyTestBase<SingleN> { }
        public sealed class NumericConvertTests : NumericConvertTestBase<SingleN> { }
        public sealed class NumericFloatingPointTests : NumericFloatingPointTestBase<SingleN> { }
        public sealed class NumericInfinityTests : NumericInfinityTestBase<SingleN> { }
        public sealed class NumericMathErrorNaNTests : NumericMathErrorNaNTestBase<SingleN> { }
        public sealed class NumericMathTests : NumericMathTestBase<SingleN> { }
        public sealed class NumericNaNTests : NumericNaNTestBase<SingleN> { }
        public sealed class NumericRandomTestBase : NumericRandomTestBase<SingleN> { }
        public sealed class NumericRealTests : NumericRealTestBase<SingleN> { }
        public sealed class NumericSignedTests : NumericSignedTestBase<SingleN> { }
        public sealed class NumericStringConvertTests : NumericStringConvertTestBase<SingleN> { }
        public sealed class NumericTests : NumericTestBase<SingleN> { }
        public sealed class NumericWrapperTests : NumericWrapperTestBase<SingleN, float> { }
        public sealed class ObjectTests : ObjectTestBase<SingleN> { }
        public sealed class SerializableTests : SerializableTestBase<SingleN> { }
    }
}
