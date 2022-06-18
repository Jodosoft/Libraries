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
    public static class CLongTests
    {
        public sealed class BitConverter : BitConverterTests<clong> { }
        public sealed class Cast : CastTests<clong> { }
        public sealed class CheckedNumeric : CheckedNumericTests<clong> { }
        public sealed class ConvertTests : ConvertTests<clong> { }
        public sealed class MathGeneral : MathTests.General<clong> { }
        public sealed class MathIntegral : MathTests.Integral<clong> { }
        public sealed class MathSigned : MathTests.Signed<clong> { }
        public sealed class NumericGeneral : NumericTests.General<clong> { }
        public sealed class NumericIntegral : NumericTests.Integral<clong> { }
        public sealed class NumericNoFloatingPoint : NumericTests.NoFloatingPoint<clong> { }
        public sealed class NumericNoInfinity : NumericTests.NoInfinity<clong> { }
        public sealed class NumericNoNaN : NumericTests.NoNaN<clong> { }
        public sealed class NumericSigned : NumericTests.Signed<clong> { }
        public sealed class StringParserGeneral : StringParserTests.General<clong> { }
        public sealed class StringParserIntegral : StringParserTests.Integral<clong> { }
    }
}
