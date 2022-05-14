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

namespace Jodo.Extensions.Primitives
{
    public interface IConvert<T>
    {
        bool ToBoolean(T value);
        byte ToByte(T value);
        char ToChar(T value);
        decimal ToDecimal(T value);
        double ToDouble(T value);
        float ToSingle(T value);
        int ToInt32(T value);
        long ToInt64(T value);
        sbyte ToSByte(T value);
        short ToInt16(T value);
        string ToString(T value);
        string ToString(T value, IFormatProvider provider);
        uint ToUInt32(T value);
        ulong ToUInt64(T value);
        ushort ToUInt16(T value);

        T ToValue(bool value);
        T ToValue(byte value);
        T ToValue(char value);
        T ToValue(decimal value);
        T ToValue(double value);
        T ToValue(float value);
        T ToValue(int value);
        T ToValue(long value);
        T ToValue(sbyte value);
        T ToValue(short value);
        T ToValue(string value);
        T ToValue(string value, IFormatProvider provider);
        T ToValue(uint value);
        T ToValue(ulong value);
        T ToValue(ushort value);
    }
}
