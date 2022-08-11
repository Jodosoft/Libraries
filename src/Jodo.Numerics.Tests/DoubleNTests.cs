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

using System.Diagnostics.CodeAnalysis;
using Jodo.Primitives.Tests;
using Jodo.Testing;

namespace Jodo.Numerics.Tests
{
    [SuppressMessage("Style", "IDE0001:Simplify Names", Justification = "To make easily repeatable test fixture.")]
    public sealed class DoubleNTests : GlobalFixtureBase
    {
        public sealed class BitConvertTests : BitConvertTestsBase<DoubleN> { }
        public sealed class CastTests : CastTests<DoubleN> { }
        public sealed class ConvertTests : ConvertTests<DoubleN> { }
        public sealed class MathErrorGeneral : MathErrorTests.General<DoubleN> { }
        public sealed class MathErrorNaN : MathErrorTests.NaN<DoubleN> { }
        public sealed class MathTestsFloatingPoint : MathTestsBase.FloatingPoint<DoubleN> { }
        public sealed class MathTestsGeneral : MathTestsBase.General<DoubleN> { }
        public sealed class MathTestsReal : MathTestsBase.Real<DoubleN> { }
        public sealed class MathTestsSigned : MathTestsBase.SingedOnly<DoubleN> { }
        public sealed class NumericGeneral : NumericTestsBase.General<DoubleN> { }
        public sealed class NumericNaN : NumericTestsBase.NaN<DoubleN> { }
        public sealed class NumericReal : NumericTestsBase.Real<DoubleN> { }
        public sealed class NumericSigned : NumericTestsBase.SignedOnly<DoubleN> { }
        public sealed class NumericWrapperTests : NumericWrapperTestsBase.General<DoubleN, double> { }
        public sealed class ObjectTests : ObjectTestsBase<DoubleN> { }
        public sealed class RandomTests : RandomTestsBase<DoubleN> { }
        public sealed class SerializableTests : SerializableTestsBase<DoubleN> { }
        public sealed class StringParserTests : StringParserTestsBase.General<DoubleN> { }
    }
}
