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
    public static class Fix64Tests
    {
        public sealed class BitConverter : BitConverterTests<Fix64> { }
        public sealed class Cast : CastTests<Fix64> { }
        public sealed class ConvertTests : ConvertTests<Fix64> { }
        public sealed class MathGeneral : MathTests.General<Fix64> { }
        public sealed class MathReal : MathTests.Real<Fix64> { }
        public sealed class MathSigned : MathTests.Signed<Fix64> { }
        public sealed class NumericGeneral : NumericTests.General<Fix64> { }
        public sealed class NumericNoFloatingPoint : NumericTests.NoFloatingPoint<Fix64> { }
        public sealed class NumericNoInfinity : NumericTests.NoInfinity<Fix64> { }
        public sealed class NumericNoNaN : NumericTests.NoNaN<Fix64> { }
        public sealed class NumericReal : NumericTests.Real<Fix64> { }
        public sealed class NumericSigned : NumericTests.Signed<Fix64> { }
        public sealed class ParserGeneral : ParserTests.General<Fix64> { }
    }
}
