// Copyright (c) 2023 Joe Lawry-Short
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

namespace Jodosoft.Numerics
{
    /// <summary>
    /// Converts objects to or from base data types.
    /// </summary>
    /// <typeparam name="TNumeric">The type of object that can be converted.</typeparam>
    public interface IConvert<TNumeric>
    {
        bool ToBoolean(TNumeric value);
        byte ToByte(TNumeric value, Conversion mode);
        decimal ToDecimal(TNumeric value, Conversion mode);
        double ToDouble(TNumeric value, Conversion mode);
        float ToSingle(TNumeric value, Conversion mode);
        int ToInt32(TNumeric value, Conversion mode);
        long ToInt64(TNumeric value, Conversion mode);
        short ToInt16(TNumeric value, Conversion mode);
        string ToString(TNumeric value);

        TNumeric ToNumeric(bool value);
        TNumeric ToNumeric(byte value, Conversion mode);
        TNumeric ToNumeric(decimal value, Conversion mode);
        TNumeric ToNumeric(double value, Conversion mode);
        TNumeric ToNumeric(float value, Conversion mode);
        TNumeric ToNumeric(int value, Conversion mode);
        TNumeric ToNumeric(long value, Conversion mode);
        TNumeric ToNumeric(short value, Conversion mode);
        TNumeric ToNumeric(string value);
    }
}
