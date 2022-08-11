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
    public static class SingleNTests
    {
        public sealed class BitConvertTests : BitConvertTestsBase<SingleN> { }
        public sealed class CastTests : CastTests<SingleN> { }
        public sealed class ConvertTests : ConvertTests<SingleN> { }
        public sealed class MathErrorGeneral : MathErrorTests.General<SingleN> { }
        public sealed class MathErrorNaN : MathErrorTests.NaN<SingleN> { }
        public sealed class MathFloatingPoint : MathTestsBase.FloatingPoint<SingleN> { }
        public sealed class MathGeneral : MathTestsBase.General<SingleN> { }
        public sealed class MathReal : MathTestsBase.Real<SingleN> { }
        public sealed class MathSigned : MathTestsBase.SingedOnly<SingleN> { }
        public sealed class NumericGeneral : NumericTestsBase.General<SingleN> { }
        public sealed class NumericInfinity : NumericTestsBase.Infinity<SingleN> { }
        public sealed class NumericNaN : NumericTestsBase.NaN<SingleN> { }
        public sealed class NumericReal : NumericTestsBase.Real<SingleN> { }
        public sealed class NumericSigned : NumericTestsBase.SignedOnly<SingleN> { }
        public sealed class NumericWrapperTests : NumericWrapperTestsBase.General<SingleN, float> { }
        public sealed class ObjectTests : Primitives.Tests.ObjectTestsBase<SingleN> { }
        public sealed class ParserGeneral : StringParserTestsBase.General<SingleN> { }
        public sealed class RandomTests : Primitives.Tests.RandomTestsBase<SingleN> { }
        public sealed class SerializableTests : Primitives.Tests.SerializableTestsBase<SingleN> { }
    }
}
