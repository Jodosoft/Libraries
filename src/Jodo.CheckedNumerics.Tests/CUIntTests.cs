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
    public static class CUIntTests
    {
        public sealed class BitConverter : BitConverterTests<cuint> { }
        public sealed class Cast : CastTests<cuint> { }
        public sealed class CheckedNumeric : CheckedNumericTests<cuint> { }
        public sealed class ConvertTests : ConvertTests<cuint> { }
        public sealed class MathGeneral : MathTests.General<cuint> { }
        public sealed class MathIntegral : MathTests.Integral<cuint> { }
        public sealed class MathUnsigned : NumericTests.Unsigned<cuint> { }
        public sealed class NumericGeneral : NumericTests.General<cuint> { }
        public sealed class NumericIntegral : NumericTests.Integral<cuint> { }
        public sealed class NumericNoFloatingPoint : NumericTests.NoFloatingPoint<cuint> { }
        public sealed class NumericNoInfinity : NumericTests.NoInfinity<cuint> { }
        public sealed class NumericNoNaN : NumericTests.NoNaN<cuint> { }
        public sealed class NumericUnsigned : NumericTests.Unsigned<cuint> { }
        public sealed class ParserGeneral : ParserTests.General<cuint> { }
        public sealed class StringParserIntegral : ParserTests.Integral<cuint> { }
    }
}
