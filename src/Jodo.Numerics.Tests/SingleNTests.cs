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
    public static class SingleNTests
    {
        public sealed class BitConvertTests : BitConvertTests<SingleN> { }
        public sealed class CastTests : CastTests<SingleN> { }
        public sealed class ConvertTests : ConvertTests<SingleN> { }
        public sealed class MathErrorGeneral : MathErrorTests.General<SingleN> { }
        public sealed class MathErrorNaN : MathErrorTests.NaN<SingleN> { }
        public sealed class MathFloatingPoint : MathTests.FloatingPoint<SingleN> { }
        public sealed class MathGeneral : MathTests.General<SingleN> { }
        public sealed class MathReal : MathTests.Real<SingleN> { }
        public sealed class MathSigned : MathTests.SingedOnly<SingleN> { }
        public sealed class NumericGeneral : NumericTests.General<SingleN> { }
        public sealed class NumericInfinity : NumericTests.Infinity<SingleN> { }
        public sealed class NumericNaN : NumericTests.NaN<SingleN> { }
        public sealed class NumericReal : NumericTests.Real<SingleN> { }
        public sealed class NumericSigned : NumericTests.SignedOnly<SingleN> { }
        public sealed class ObjectTests : Primitives.Tests.ObjectTests<SingleN> { }
        public sealed class ParserGeneral : StringParserTests.General<SingleN> { }
        public sealed class RandomTests : Primitives.Tests.RandomTests<SingleN> { }
        public sealed class SerializableTests : Primitives.Tests.SerializableTests<SingleN> { }
    }
}
