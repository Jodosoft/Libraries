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

namespace Jodo.CheckedNumerics.Tests
{
    public static class SByteCTests
    {
        public sealed class BitConvertTests : BitConvertTestsBase<SByteC> { }
        public sealed class CastTests : CastTests<SByteC> { }
        public sealed class CheckedNumeric : CheckedNumericTests<SByteC> { }
        public sealed class ConvertTests : ConvertTests<SByteC> { }
        public sealed class MathGeneral : MathTestsBase.General<SByteC> { }
        public sealed class MathIntegral : MathTestsBase.Integral<SByteC> { }
        public sealed class MathSigned : MathTestsBase.SingedOnly<SByteC> { }
        public sealed class NumericGeneral : NumericTestsBase.General<SByteC> { }
        public sealed class NumericIntegral : NumericTestsBase.Integral<SByteC> { }
        public sealed class NumericNoFloatingPoint : NumericTestsBase.NoFloatingPoint<SByteC> { }
        public sealed class NumericNoInfinity : NumericTestsBase.NoInfinity<SByteC> { }
        public sealed class NumericNoNaN : NumericTestsBase.NoNaN<SByteC> { }
        public sealed class NumericSigned : NumericTestsBase.SignedOnly<SByteC> { }
        public sealed class ObjectTests : Primitives.Tests.ObjectTestsBase<SByteC> { }
        public sealed class ParserGeneral : StringParserTestsBase.General<SByteC> { }
        public sealed class RandomTests : Primitives.Tests.RandomTestsBase<SByteC> { }
        public sealed class SerializableTests : Primitives.Tests.SerializableTestsBase<SByteC> { }
        public sealed class StringParserIntegral : StringParserTestsBase.Integral<SByteC> { }
    }
}
