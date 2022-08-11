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
    public static class ByteCTests
    {
        public sealed class BitConvertTests : BitConvertTestsBase<ByteC> { }
        public sealed class CastTests : CastTests<ByteC> { }
        public sealed class CheckedNumeric : CheckedNumericTests<ByteC> { }
        public sealed class ConvertTests : ConvertTests<ByteC> { }
        public sealed class MathGeneral : MathTestsBase.General<ByteC> { }
        public sealed class MathIntegral : MathTestsBase.Integral<ByteC> { }
        public sealed class MathUnsigned : NumericTestsBase.UnsignedOnly<ByteC> { }
        public sealed class NumericGeneral : NumericTestsBase.General<ByteC> { }
        public sealed class NumericIntegral : NumericTestsBase.Integral<ByteC> { }
        public sealed class NumericNoFloatingPoint : NumericTestsBase.NoFloatingPoint<ByteC> { }
        public sealed class NumericNoInfinity : NumericTestsBase.NoInfinity<ByteC> { }
        public sealed class NumericNoNaN : NumericTestsBase.NoNaN<ByteC> { }
        public sealed class NumericUnsigned : NumericTestsBase.UnsignedOnly<ByteC> { }
        public sealed class ObjectTests : Primitives.Tests.ObjectTestsBase<ByteC> { }
        public sealed class ParserGeneral : StringParserTestsBase.General<ByteC> { }
        public sealed class RandomTests : Primitives.Tests.RandomTestsBase<ByteC> { }
        public sealed class SerializableTests : Primitives.Tests.SerializableTestsBase<ByteC> { }
        public sealed class StringParserIntegral : StringParserTestsBase.Integral<ByteC> { }
    }
}
