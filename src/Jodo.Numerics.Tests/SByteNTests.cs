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
    public static class SByteNTests
    {
        public sealed class BitConverter : BitConverterNTests<SByteN> { }
        public sealed class Cast : CastTests<SByteN> { }
        public sealed class ConvertTests : ConvertTests<SByteN> { }
        public sealed class MathErrorGeneral : MathErrorTests.General<SByteN> { }
        public sealed class MathErrorSignedIntegral : MathErrorTests.SignedIntegral<SByteN> { }
        public sealed class MathGeneral : MathTests.General<SByteN> { }
        public sealed class MathIntegral : MathTests.Integral<SByteN> { }
        public sealed class MathSigned : MathTests.Signed<SByteN> { }
        public sealed class NumericGeneral : NumericTests.General<SByteN> { }
        public sealed class NumericIntegral : NumericTests.Integral<SByteN> { }
        public sealed class NumericNoFloatingPoint : NumericTests.NoFloatingPoint<SByteN> { }
        public sealed class NumericNoInfinity : NumericTests.NoInfinity<SByteN> { }
        public sealed class NumericNoNaN : NumericTests.NoNaN<SByteN> { }
        public sealed class NumericSigned : NumericTests.Signed<SByteN> { }
        public sealed class ParserGeneral : ParserTests.General<SByteN> { }
        public sealed class StringParserIntegral : ParserTests.Integral<SByteN> { }
    }
}
