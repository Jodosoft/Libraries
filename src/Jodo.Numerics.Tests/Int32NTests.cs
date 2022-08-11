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

namespace Jodo.Numerics.Tests
{
    public static class Int32NTests
    {
        public sealed class BitConvertTests : BitConvertTestsBase<Int32N> { }
        public sealed class CastTests : CastTests<Int32N> { }
        public sealed class ConvertTests : ConvertTests<Int32N> { }
        public sealed class MathErrorGeneral : MathErrorTests.General<Int32N> { }
        public sealed class MathErrorSignedIntegral : MathErrorTests.SignedIntegral<Int32N> { }
        public sealed class MathGeneral : MathTestsBase.General<Int32N> { }
        public sealed class MathIntegral : MathTestsBase.Integral<Int32N> { }
        public sealed class MathSigned : MathTestsBase.SingedOnly<Int32N> { }
        public sealed class NumericGeneral : NumericTestsBase.General<Int32N> { }
        public sealed class NumericIntegral : NumericTestsBase.Integral<Int32N> { }
        public sealed class NumericNoFloatingPoint : NumericTestsBase.NoFloatingPoint<Int32N> { }
        public sealed class NumericNoInfinity : NumericTestsBase.NoInfinity<Int32N> { }
        public sealed class NumericNoNaN : NumericTestsBase.NoNaN<Int32N> { }
        public sealed class NumericSigned : NumericTestsBase.SignedOnly<Int32N> { }
        public sealed class NumericWrapperIntegralOnlyTests : NumericWrapperTestsBase.IntegralOnly<Int32N, int> { }
        public sealed class NumericWrapperTests : NumericWrapperTestsBase.General<Int32N, int> { }
        public sealed class ObjectTests : Primitives.Tests.ObjectTestsBase<Int32N> { }
        public sealed class ParserGeneral : StringParserTestsBase.General<Int32N> { }
        public sealed class RandomTests : Primitives.Tests.RandomTestsBase<Int32N> { }
        public sealed class SerializableTests : Primitives.Tests.SerializableTestsBase<Int32N> { }
        public sealed class StringParserIntegral : StringParserTestsBase.Integral<Int32N> { }
    }
}
