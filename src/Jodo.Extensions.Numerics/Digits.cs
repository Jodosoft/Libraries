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

namespace Jodo.Extensions.Numerics
{
    public static class Digits
    {
        public static byte Count(byte value)
        {
            if (value < 10) return 1;
            if (value < 100) return 2;
            return 3;
        }

        public static byte Count(ushort value)
        {
            if (value < 10) return 1;
            if (value < 100) return 2;
            if (value < 1000) return 3;
            if (value < 10000) return 4;
            return 5;
        }

        public static byte Count(uint value)
        {
            if (value < 10) return 1;
            if (value < 100) return 2;
            if (value < 1000) return 3;
            if (value < 10000) return 4;
            if (value < 100000) return 5;
            if (value < 1000000) return 6;
            if (value < 10000000) return 7;
            if (value < 100000000) return 8;
            if (value < 1000000000) return 9;
            return 10;
        }

        public static byte Count(ulong value)
        {
            if (value < 10) return 1;
            if (value < 100) return 2;
            if (value < 1000) return 3;
            if (value < 10000) return 4;
            if (value < 100000) return 5;
            if (value < 1000000) return 6;
            if (value < 10000000) return 7;
            if (value < 100000000) return 8;
            if (value < 1000000000) return 9;
            if (value < 10000000000) return 10;
            if (value < 100000000000) return 11;
            if (value < 1000000000000) return 12;
            if (value < 10000000000000) return 13;
            if (value < 100000000000000) return 14;
            if (value < 1000000000000000) return 15;
            if (value < 10000000000000000) return 16;
            if (value < 100000000000000000) return 17;
            if (value < 1000000000000000000) return 18;
            if (value < 10000000000000000000) return 19;
            return 20;
        }

        public static byte Count(sbyte value)
        {
            if (value < 10 && value >= -10) return 1;
            if (value < 100 && value >= -100) return 2;
            return 3;
        }

        public static byte Count(short value)
        {
            if (value > 0)
            {
                if (value < 10) return 1;
                if (value < 100) return 2;
                if (value < 1000) return 3;
                if (value < 10000) return 4;
                return 5;
            }
            else
            {
                if (value > -10) return 1;
                if (value > -100) return 2;
                if (value > -1000) return 3;
                if (value > -10000) return 4;
                return 5;
            }
        }

        public static byte Count(int value)
        {
            if (value > 0)
            {
                if (value < 10) return 1;
                if (value < 100) return 2;
                if (value < 1000) return 3;
                if (value < 10000) return 4;
                if (value < 100000) return 5;
                if (value < 1000000) return 6;
                if (value < 10000000) return 7;
                if (value < 100000000) return 8;
                if (value < 1000000000) return 9;
                return 10;
            }
            else
            {
                if (value > -10) return 1;
                if (value > -100) return 2;
                if (value > -1000) return 3;
                if (value > -10000) return 4;
                if (value > -100000) return 5;
                if (value > -1000000) return 6;
                if (value > -10000000) return 7;
                if (value > -100000000) return 8;
                if (value > -1000000000) return 9;
                return 10;
            }
        }

        public static byte Count(long value)
        {
            if (value > 0)
            {
                if (value < 10) return 1;
                if (value < 100) return 2;
                if (value < 1000) return 3;
                if (value < 10000) return 4;
                if (value < 100000) return 5;
                if (value < 1000000) return 6;
                if (value < 10000000) return 7;
                if (value < 100000000) return 8;
                if (value < 1000000000) return 9;
                if (value < 10000000000) return 10;
                if (value < 100000000000) return 11;
                if (value < 1000000000000) return 12;
                if (value < 10000000000000) return 13;
                if (value < 100000000000000) return 14;
                if (value < 1000000000000000) return 15;
                if (value < 10000000000000000) return 16;
                if (value < 100000000000000000) return 17;
                if (value < 1000000000000000000) return 18;
                return 19;
            }
            else
            {
                if (value > -10) return 1;
                if (value > -100) return 2;
                if (value > -1000) return 3;
                if (value > -10000) return 4;
                if (value > -100000) return 5;
                if (value > -1000000) return 6;
                if (value > -10000000) return 7;
                if (value > -100000000) return 8;
                if (value > -1000000000) return 9;
                if (value > -10000000000) return 10;
                if (value > -100000000000) return 11;
                if (value > -1000000000000) return 12;
                if (value > -10000000000000) return 13;
                if (value > -100000000000000) return 14;
                if (value > -1000000000000000) return 15;
                if (value > -10000000000000000) return 16;
                if (value > -100000000000000000) return 17;
                if (value > -1000000000000000000) return 18;
                return 19;
            }
        }
    }
}
