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

namespace Jodo.Primitives
{
    public static class BitConvert
    {
        public static byte[] GetBytes<T>(T value) where T : struct, IProvider<IBitConvert<T>>
        {
            List<byte>? list = new List<byte>();
            Provider<T, IBitConvert<T>>.Default.Write(value, list.AsWriteOnlyStream());
            return list.ToArray();
        }

        public static T FromBytes<T>(byte[] bytes) where T : struct, IProvider<IBitConvert<T>>
        {
            return Provider<T, IBitConvert<T>>.Default.Read(bytes.AsReadOnlyStream());
        }

        public static T FromBytes<T>(IReadOnlyList<byte> bytes) where T : struct, IProvider<IBitConvert<T>>
        {
            return Provider<T, IBitConvert<T>>.Default.Read(bytes.AsReadOnlyStream());
        }

        public static T Read<T>(IReader<byte> stream) where T : struct, IProvider<IBitConvert<T>>
        {
            return Provider<T, IBitConvert<T>>.Default.Read(stream);
        }

        public static void Write<T>(IWriter<byte> stream, T value) where T : struct, IProvider<IBitConvert<T>>
        {
            Provider<T, IBitConvert<T>>.Default.Write(value, stream);
        }
    }
}
