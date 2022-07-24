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
        public sealed class BitConvert : BitConvertTests<SByteC> { }
        public sealed class Cast : CastTests<SByteC> { }
        public sealed class CheckedNumeric : CheckedNumericTests<SByteC> { }
        public sealed class ConvertTests : ConvertTests<SByteC> { }
        public sealed class MathGeneral : MathTests.General<SByteC> { }
        public sealed class MathIntegral : MathTests.Integral<SByteC> { }
        public sealed class MathSigned : MathTests.SingedOnly<SByteC> { }
        public sealed class NumericGeneral : NumericTests.General<SByteC> { }
        public sealed class NumericIntegral : NumericTests.Integral<SByteC> { }
        public sealed class NumericNoFloatingPoint : NumericTests.NoFloatingPoint<SByteC> { }
        public sealed class NumericNoInfinity : NumericTests.NoInfinity<SByteC> { }
        public sealed class NumericNoNaN : NumericTests.NoNaN<SByteC> { }
        public sealed class NumericSigned : NumericTests.SignedOnly<SByteC> { }
        public sealed class ParserGeneral : StringParserTests.General<SByteC> { }
        public sealed class StringParserIntegral : StringParserTests.Integral<SByteC> { }
    }
}
