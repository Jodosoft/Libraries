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
    public static class CByteTests
    {
        public sealed class BitConverter : BitConverterTests<cbyte> { }
        public sealed class Cast : CastTests<cbyte> { }
        public sealed class CheckedNumeric : CheckedNumericTests<cbyte> { }
        public sealed class ConvertTests : ConvertTests<cbyte> { }
        public sealed class MathGeneral : MathTests.General<cbyte> { }
        public sealed class MathIntegral : MathTests.Integral<cbyte> { }
        public sealed class MathUnsigned : NumericTests.Unsigned<cbyte> { }
        public sealed class NumericGeneral : NumericTests.General<cbyte> { }
        public sealed class NumericIntegral : NumericTests.Integral<cbyte> { }
        public sealed class NumericNoFloatingPoint : NumericTests.NoFloatingPoint<cbyte> { }
        public sealed class NumericNoInfinity : NumericTests.NoInfinity<cbyte> { }
        public sealed class NumericNoNaN : NumericTests.NoNaN<cbyte> { }
        public sealed class NumericUnsigned : NumericTests.Unsigned<cbyte> { }
        public sealed class StringParserGeneral : StringParserTests.General<cbyte> { }
        public sealed class StringParserIntegral : StringParserTests.Integral<cbyte> { }
    }
}
