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
    public static class Fix64Tests
    {
        public sealed class BitConvertTests : BitConvertTestsBase<Fix64> { }
        public sealed class CastTests : CastTests<Fix64> { }
        public sealed class ConvertTests : ConvertTests<Fix64> { }
        public sealed class MathGeneral : MathTestsBase.General<Fix64> { }
        public sealed class MathReal : MathTestsBase.Real<Fix64> { }
        public sealed class MathSigned : MathTestsBase.SingedOnly<Fix64> { }
        public sealed class NumericGeneral : NumericTestsBase.General<Fix64> { }
        public sealed class NumericNoFloatingPoint : NumericTestsBase.NoFloatingPoint<Fix64> { }
        public sealed class NumericNoInfinity : NumericTestsBase.NoInfinity<Fix64> { }
        public sealed class NumericNoNaN : NumericTestsBase.NoNaN<Fix64> { }
        public sealed class NumericReal : NumericTestsBase.Real<Fix64> { }
        public sealed class NumericSigned : NumericTestsBase.SignedOnly<Fix64> { }
        public sealed class ObjectTests : Primitives.Tests.ObjectTestsBase<Fix64> { }
        public sealed class ParserGeneral : StringParserTestsBase.General<Fix64> { }
        public sealed class RandomTests : Primitives.Tests.RandomTestsBase<Fix64> { }
        public sealed class SerializableTests : Primitives.Tests.SerializableTestsBase<Fix64> { }
    }
}
