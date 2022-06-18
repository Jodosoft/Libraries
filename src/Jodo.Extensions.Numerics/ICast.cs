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

namespace Jodo.Extensions.Numerics
{
    [CLSCompliant(false)]
    public interface ICast<N> where N : struct, INumeric<N>
    {
        byte ToByte(N value);
        decimal ToDecimal(N value);
        double ToDouble(N value);
        float ToSingle(N value);
        int ToInt32(N value);
        long ToInt64(N value);
        sbyte ToSByte(N value);
        short ToInt16(N value);
        uint ToUInt32(N value);
        ulong ToUInt64(N value);
        ushort ToUInt16(N value);

        N ToNumeric(byte value);
        N ToNumeric(decimal value);
        N ToNumeric(double value);
        N ToNumeric(float value);
        N ToNumeric(int value);
        N ToNumeric(long value);
        N ToNumeric(sbyte value);
        N ToNumeric(short value);
        N ToNumeric(uint value);
        N ToNumeric(ulong value);
        N ToNumeric(ushort value);
    }
}
