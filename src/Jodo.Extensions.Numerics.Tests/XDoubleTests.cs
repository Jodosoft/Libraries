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

namespace Jodo.Extensions.Numerics.Tests
{
    public static class XDoubleTests
    {
        public sealed class BitConverter : BitConverterTests<xdouble> { }
        public sealed class Cast : CastTests<xdouble> { }
        public sealed class ConvertTests : ConvertTests<xdouble> { }
        public sealed class MathErrorGeneral : MathErrorTests.General<xdouble> { }
        public sealed class MathErrorNaN : MathErrorTests.NaN<xdouble> { }
        public sealed class MathFloatingPoint : MathTests.FloatingPoint<xdouble> { }
        public sealed class MathGeneral : MathTests.General<xdouble> { }
        public sealed class MathReal : MathTests.Real<xdouble> { }
        public sealed class MathSigned : MathTests.Signed<xdouble> { }
        public sealed class NumericGeneral : NumericTests.General<xdouble> { }
        public sealed class NumericNaN : NumericTests.NaN<xdouble> { }
        public sealed class NumericReal : NumericTests.Real<xdouble> { }
        public sealed class NumericSigned : NumericTests.Signed<xdouble> { }
        public sealed class StringParserGeneral : StringParserTests.General<xdouble> { }
    }
}
