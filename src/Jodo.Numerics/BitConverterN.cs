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

using System.Collections.Generic;
using Jodo.Primitives;

namespace Jodo.Numerics
{
    /// <summary>
    /// Converts numeric types to an array of bytes, and an array of bytes to numeric types.
    /// </summary>
    /// <seealso cref="INumeric{TSelf}"/>
    public static class BitConverterN
    {
        public static byte[] GetBytes<TNumeric>(TNumeric value) where TNumeric : struct, IProvider<INumericBitConverter<TNumeric>>
        {
            List<byte>? list = new List<byte>();
            Provider<TNumeric, INumericBitConverter<TNumeric>>.Default.Write(value, list.AsWriteOnlyStream());
            return list.ToArray();
        }

        public static TNumeric FromBytes<TNumeric>(byte[] bytes) where TNumeric : struct, IProvider<INumericBitConverter<TNumeric>>
        {
            return Provider<TNumeric, INumericBitConverter<TNumeric>>.Default.Read(bytes.AsReadOnlyStream());
        }

        public static TNumeric FromBytes<TNumeric>(IReadOnlyList<byte> bytes) where TNumeric : struct, IProvider<INumericBitConverter<TNumeric>>
        {
            return Provider<TNumeric, INumericBitConverter<TNumeric>>.Default.Read(bytes.AsReadOnlyStream());
        }

        public static TNumeric Read<TNumeric>(IReader<byte> stream) where TNumeric : struct, IProvider<INumericBitConverter<TNumeric>>
        {
            return Provider<TNumeric, INumericBitConverter<TNumeric>>.Default.Read(stream);
        }

        public static void Write<TNumeric>(IWriter<byte> stream, TNumeric value) where TNumeric : struct, IProvider<INumericBitConverter<TNumeric>>
        {
            Provider<TNumeric, INumericBitConverter<TNumeric>>.Default.Write(value, stream);
        }
    }
}
