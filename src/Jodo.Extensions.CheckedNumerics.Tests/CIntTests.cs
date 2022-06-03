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

using Jodo.Extensions.Numerics.Tests;

namespace Jodo.Extensions.CheckedNumerics.Tests
{
    public static class CIntTests
    {
        public sealed class BitConverter : BitConverterTests<cint> { }
        public sealed class Cast : CastTests<cint> { }
        public sealed class CheckedNumeric : CheckedNumericTests<cint> { }
        public sealed class ConvertTests : ConvertTests<cint> { }
        public sealed class MathGeneral : MathTests.General<cint> { }
        public sealed class MathIntegral : MathTests.Integral<cint> { }
        public sealed class MathSigned : MathTests.Signed<cint> { }
        public sealed class NumericGeneral : NumericTests.General<cint> { }
        public sealed class NumericIntegral : NumericTests.Integral<cint> { }
        public sealed class NumericNoFloatingPoint : NumericTests.NoFloatingPoint<cint> { }
        public sealed class NumericNoInfinity : NumericTests.NoInfinity<cint> { }
        public sealed class NumericNoNaN : NumericTests.NoNaN<cint> { }
        public sealed class NumericSigned : NumericTests.Signed<cint> { }
        public sealed class StringParserGeneral : StringParserTests.General<cint> { }
        public sealed class StringParserIntegral : StringParserTests.Integral<cint> { }
    }
}
