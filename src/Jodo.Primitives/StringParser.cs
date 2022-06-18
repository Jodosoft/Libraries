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

using System;
using System.Diagnostics;
using System.Globalization;

namespace Jodo.Primitives
{
    public static class StringParser<T> where T : struct, IProvider<IStringParser<T>>
    {
        private static readonly IStringParser<T> Default = default(T).GetInstance();

        [DebuggerStepThrough]
        public static T Parse(string s) => Default.Parse(s);

        [DebuggerStepThrough]
        public static T Parse(string s, IFormatProvider? formatProvider) => Default.Parse(s, default, formatProvider);

        [DebuggerStepThrough]
        public static T Parse(string s, NumberStyles numberStyles) => Default.Parse(s, numberStyles, null);

        [DebuggerStepThrough]
        public static T Parse(string s, NumberStyles numberStyles, IFormatProvider? formatProvider) => Default.Parse(s, numberStyles, formatProvider);

        public static bool TryParse(string s, out T result)
        {
            try
            {
                result = Parse(s);
                return true;
            }
            catch (Exception)
            {
                result = default;
                return false;
            }
        }

        public static bool TryParse(string s, IFormatProvider? provider, out T result)
        {
            try
            {
                result = Parse(s, provider);
                return true;
            }
            catch (Exception)
            {
                result = default;
                return false;
            }
        }

        public static bool TryParse(string s, NumberStyles style, out T result)
        {
            try
            {
                result = Parse(s, style);
                return true;
            }
            catch (Exception)
            {
                result = default;
                return false;
            }
        }

        public static bool TryParse(string s, NumberStyles style, IFormatProvider? provider, out T result)
        {
            try
            {
                result = Parse(s, style, provider);
                return true;
            }
            catch (Exception)
            {
                result = default;
                return false;
            }
        }
    }
}
