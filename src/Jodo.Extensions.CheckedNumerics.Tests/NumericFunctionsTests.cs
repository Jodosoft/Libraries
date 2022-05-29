﻿// Copyright (c) 2022 Joseph J. Short
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

using Jodo.Extensions.Numerics;

namespace Jodo.Extensions.CheckedNumerics.Tests
{
    public static class NumericFunctionsTests
    {
        public class CByte : Base<cbyte> { }
        public class CDecimal : Base<cdecimal> { }
        public class CDouble : Base<cdouble> { }
        public class CFix64 : Base<cfix64> { }
        public class CFloat : Base<cfloat> { }
        public class CInt : Base<cint> { }
        public class CLong : Base<clong> { }
        public class CSByte : Base<csbyte> { }
        public class CShort : Base<cshort> { }
        public class UCFix64 : Base<ucfix64> { }
        public class UCInt : Base<ucint> { }
        public class UCLong : Base<uclong> { }
        public class UCShort : Base<ucshort> { }

        public abstract class Base<T> : Numerics.Tests.NumericFunctionsTests.Base<T> where T : struct, INumeric<T>
        {

        }
    }
}