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
    public static class CULongTests
    {
        public sealed class BitConverter : BitConverterTests<culong> { }
        public sealed class Cast : CastTests<culong> { }
        public sealed class CheckedNumeric : CheckedNumericTests<culong> { }
        public sealed class ConvertTests : ConvertTests<culong> { }
        public sealed class MathGeneral : MathTests.General<culong> { }
        public sealed class MathIntegral : MathTests.Integral<culong> { }
        public sealed class MathUnsigned : NumericTests.Unsigned<culong> { }
        public sealed class NumericGeneral : NumericTests.General<culong> { }
        public sealed class NumericIntegral : NumericTests.Integral<culong> { }
        public sealed class NumericNoFloatingPoint : NumericTests.NoFloatingPoint<culong> { }
        public sealed class NumericNoInfinity : NumericTests.NoInfinity<culong> { }
        public sealed class NumericNoNaN : NumericTests.NoNaN<culong> { }
        public sealed class NumericUnsigned : NumericTests.Unsigned<culong> { }
        public sealed class StringParserGeneral : StringParserTests.General<culong> { }
        public sealed class StringParserIntegral : StringParserTests.Integral<culong> { }
    }
}
