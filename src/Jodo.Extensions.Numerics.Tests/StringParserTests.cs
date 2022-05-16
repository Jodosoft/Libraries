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

using Jodo.Extensions.Primitives.Tests;

namespace Jodo.Extensions.Numerics.Tests
{
    public static class StringParserTests
    {
        public class XByte : StringParserTestsBase<xbyte> { }
        public class XDecimal : StringParserTestsBase<xdecimal> { }
        public class XDouble : StringParserTestsBase<xdouble> { }
        public class XFloat : StringParserTestsBase<xfloat> { }
        public class XInt : StringParserTestsBase<xint> { }
        public class XLong : StringParserTestsBase<xlong> { }
        public class XSByte : StringParserTestsBase<xsbyte> { }
        public class XShort : StringParserTestsBase<xshort> { }
        public class XUInt : StringParserTestsBase<xuint> { }
        public class XULong : StringParserTestsBase<xushort> { }
        public class XUShort : StringParserTestsBase<xushort> { }
    }
}
