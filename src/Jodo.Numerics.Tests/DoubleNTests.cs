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

namespace Jodo.Numerics.Tests
{
    public sealed class DoubleNTests : GlobalFixtureBase
    {
        public sealed class BitConvertTests : BitConvertTestBase<DoubleN> { }
        public sealed class NumericBitConvertTests : NumericBitConvertTestBase<DoubleN> { }
        public sealed class NumericCastTests : NumericCastTestBase<DoubleN> { }
        public sealed class NumericConversionConsistencyTests : NumericConversionConsistencyTestBase<DoubleN> { }
        public sealed class NumericConvertTests : NumericConvertTestBase<DoubleN> { }
        public sealed class NumericFloatingPointTests : NumericFloatingPointTestBase<DoubleN> { }
        public sealed class NumericInfinityTests : NumericInfinityTestBase<DoubleN> { }
        public sealed class NumericMathErrorNaNTests : NumericMathErrorNaNTestBase<DoubleN> { }
        public sealed class NumericMathTests : NumericMathTestBase<DoubleN> { }
        public sealed class NumericNaNTests : NumericNaNTestBase<DoubleN> { }
        public sealed class NumericRealTests : NumericRealTestBase<DoubleN> { }
        public sealed class NumericSignedTests : NumericSignedTestBase<DoubleN> { }
        public sealed class NumericStringConvertTests : NumericStringConvertTestBase<DoubleN> { }
        public sealed class NumericTests : NumericTestBase<DoubleN> { }
        public sealed class NumericWrapperTests : NumericWrapperTestBase<DoubleN, double> { }
        public sealed class ObjectTests : ObjectTestBase<DoubleN> { }
        public sealed class RandomTests : RandomTestBase<DoubleN> { }
        public sealed class SerializableTests : SerializableTestBase<DoubleN> { }
    }
}
