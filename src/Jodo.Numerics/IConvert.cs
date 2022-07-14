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

namespace Jodo.Numerics
{
    public interface IConvert<N>
    {
        bool ToBoolean(N value);
        byte ToByte(N value, Conversion mode);
        decimal ToDecimal(N value, Conversion mode);
        double ToDouble(N value, Conversion mode);
        float ToSingle(N value, Conversion mode);
        int ToInt32(N value, Conversion mode);
        long ToInt64(N value, Conversion mode);
        short ToInt16(N value, Conversion mode);
        string ToString(N value);

        N ToNumeric(bool value);
        N ToNumeric(byte value, Conversion mode);
        N ToNumeric(decimal value, Conversion mode);
        N ToNumeric(double value, Conversion mode);
        N ToNumeric(float value, Conversion mode);
        N ToNumeric(int value, Conversion mode);
        N ToNumeric(long value, Conversion mode);
        N ToNumeric(short value, Conversion mode);
        N ToNumeric(string value);
    }
}
