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
    public static class Int32CTests
    {
        public sealed class BitConvertTests : BitConvertTests<Int32C> { }
        public sealed class CastTests : CastTests<Int32C> { }
        public sealed class CheckedNumeric : CheckedNumericTests<Int32C> { }
        public sealed class ConvertTests : ConvertTests<Int32C> { }
        public sealed class MathGeneral : MathTests.General<Int32C> { }
        public sealed class MathIntegral : MathTests.Integral<Int32C> { }
        public sealed class MathSigned : MathTests.SingedOnly<Int32C> { }
        public sealed class NumericGeneral : NumericTests.General<Int32C> { }
        public sealed class NumericIntegral : NumericTests.Integral<Int32C> { }
        public sealed class NumericNoFloatingPoint : NumericTests.NoFloatingPoint<Int32C> { }
        public sealed class NumericNoInfinity : NumericTests.NoInfinity<Int32C> { }
        public sealed class NumericNoNaN : NumericTests.NoNaN<Int32C> { }
        public sealed class NumericSigned : NumericTests.SignedOnly<Int32C> { }
        public sealed class ObjectTests : Primitives.Tests.ObjectTests<Int32C> { }
        public sealed class ParserGeneral : StringParserTests.General<Int32C> { }
        public sealed class RandomTests : Primitives.Tests.RandomTests<Int32C> { }
        public sealed class SerializableTests : Primitives.Tests.SerializableTests<Int32C> { }
        public sealed class StringParserIntegral : StringParserTests.Integral<Int32C> { }
    }
}
