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
    public static class Int16NTests
    {
        public sealed class BitConverter : BitConverterNTests<Int16N> { }
        public sealed class Cast : CastTests<Int16N> { }
        public sealed class ConvertTests : ConvertTests<Int16N> { }
        public sealed class MathErrorGeneral : MathErrorTests.General<Int16N> { }
        public sealed class MathErrorSignedIntegral : MathErrorTests.SignedIntegral<Int16N> { }
        public sealed class MathGeneral : MathTests.General<Int16N> { }
        public sealed class MathIntegral : MathTests.Integral<Int16N> { }
        public sealed class MathSigned : MathTests.Signed<Int16N> { }
        public sealed class NumericGeneral : NumericTests.General<Int16N> { }
        public sealed class NumericIntegral : NumericTests.Integral<Int16N> { }
        public sealed class NumericNoFloatingPoint : NumericTests.NoFloatingPoint<Int16N> { }
        public sealed class NumericNoInfinity : NumericTests.NoInfinity<Int16N> { }
        public sealed class NumericNoNaN : NumericTests.NoNaN<Int16N> { }
        public sealed class NumericSigned : NumericTests.Signed<Int16N> { }
        public sealed class ParserGeneral : ParserTests.General<Int16N> { }
        public sealed class StringParserIntegral : ParserTests.Integral<Int16N> { }
    }
}
