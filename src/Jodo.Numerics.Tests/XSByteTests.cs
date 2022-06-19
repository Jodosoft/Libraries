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
    public static class XSByteTests
    {
        public sealed class BitConverter : BitConverterTests<xsbyte> { }
        public sealed class Cast : CastTests<xsbyte> { }
        public sealed class ConvertTests : ConvertTests<xsbyte> { }
        public sealed class MathErrorGeneral : MathErrorTests.General<xsbyte> { }
        public sealed class MathErrorSignedIntegral : MathErrorTests.SignedIntegral<xsbyte> { }
        public sealed class MathGeneral : MathTests.General<xsbyte> { }
        public sealed class MathIntegral : MathTests.Integral<xsbyte> { }
        public sealed class MathSigned : MathTests.Signed<xsbyte> { }
        public sealed class NumericGeneral : NumericTests.General<xsbyte> { }
        public sealed class NumericIntegral : NumericTests.Integral<xsbyte> { }
        public sealed class NumericNoFloatingPoint : NumericTests.NoFloatingPoint<xsbyte> { }
        public sealed class NumericNoInfinity : NumericTests.NoInfinity<xsbyte> { }
        public sealed class NumericNoNaN : NumericTests.NoNaN<xsbyte> { }
        public sealed class NumericSigned : NumericTests.Signed<xsbyte> { }
        public sealed class ParserGeneral : ParserTests.General<xsbyte> { }
        public sealed class StringParserIntegral : ParserTests.Integral<xsbyte> { }
    }
}
