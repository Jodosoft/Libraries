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
    public static class NumericOperatorTests
    {
        public class XByte : NumericOperatorTestsBase<xbyte> { }
        public class XDecimal : NumericOperatorTestsBase<xdecimal> { }
        public class XDouble : NumericOperatorTestsBase<xdouble> { }
        public class XFloat : NumericOperatorTestsBase<xfloat> { }
        public class XInt : NumericOperatorTestsBase<xint> { }
        public class XLong : NumericOperatorTestsBase<xlong> { }
        public class XSByte : NumericOperatorTestsBase<xsbyte> { }
        public class XShort : NumericOperatorTestsBase<xshort> { }
        public class XUInt : NumericOperatorTestsBase<xuint> { }
        public class XULong : NumericOperatorTestsBase<xushort> { }
        public class XUShort : NumericOperatorTestsBase<xushort> { }
    }
}
