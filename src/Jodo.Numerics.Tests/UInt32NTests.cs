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
    public static class UInt32NTests
    {
        public sealed class BitConvertTests : BitConvertTests<UInt32N> { }
        public sealed class CastTests : CastTests<UInt32N> { }
        public sealed class ConvertTests : ConvertTests<UInt32N> { }
        public sealed class MathErrorGeneral : MathErrorTests.General<UInt32N> { }
        public sealed class MathGeneral : MathTests.General<UInt32N> { }
        public sealed class MathIntegral : MathTests.Integral<UInt32N> { }
        public sealed class MathUnsigned : NumericTests.UnsignedOnly<UInt32N> { }
        public sealed class NumericGeneral : NumericTests.General<UInt32N> { }
        public sealed class NumericIntegral : NumericTests.Integral<UInt32N> { }
        public sealed class NumericNoFloatingPoint : NumericTests.NoFloatingPoint<UInt32N> { }
        public sealed class NumericNoInfinity : NumericTests.NoInfinity<UInt32N> { }
        public sealed class NumericNoNaN : NumericTests.NoNaN<UInt32N> { }
        public sealed class NumericUnsigned : NumericTests.UnsignedOnly<UInt32N> { }
        public sealed class ObjectTests : Primitives.Tests.ObjectTests<UInt32N> { }
        public sealed class ParserGeneral : StringParserTests.General<UInt32N> { }
        public sealed class RandomTests : Primitives.Tests.RandomTests<UInt32N> { }
        public sealed class SerializableTests : Primitives.Tests.SerializableTests<UInt32N> { }
        public sealed class StringParserIntegral : StringParserTests.Integral<UInt32N> { }
    }
}
