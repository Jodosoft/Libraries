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
    public static class CShortTests
    {
        public sealed class BitConverter : BitConverterTests<cshort> { }
        public sealed class Cast : CastTests<cshort> { }
        public sealed class CheckedNumeric : CheckedNumericTests<cshort> { }
        public sealed class ConvertTests : ConvertTests<cshort> { }
        public sealed class MathGeneral : MathTests.General<cshort> { }
        public sealed class MathIntegral : MathTests.Integral<cshort> { }
        public sealed class MathSigned : MathTests.Signed<cshort> { }
        public sealed class NumericGeneral : NumericTests.General<cshort> { }
        public sealed class NumericIntegral : NumericTests.Integral<cshort> { }
        public sealed class NumericNoFloatingPoint : NumericTests.NoFloatingPoint<cshort> { }
        public sealed class NumericNoInfinity : NumericTests.NoInfinity<cshort> { }
        public sealed class NumericNoNaN : NumericTests.NoNaN<cshort> { }
        public sealed class NumericSigned : NumericTests.Signed<cshort> { }
        public sealed class ParserGeneral : ParserTests.General<cshort> { }
        public sealed class StringParserIntegral : ParserTests.Integral<cshort> { }
    }
}
