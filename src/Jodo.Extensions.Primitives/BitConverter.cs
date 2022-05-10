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

using System;
using System.Collections.Generic;

namespace Jodo.Extensions.Primitives
{
    public static class BitConverter<T> where T : IBitConvertible<T>, new()
    {
        private static readonly IBitConverter<T> DefaultInstance = new T().BitConverter;

        public static ReadOnlySpan<byte> GetBytes(in T value)
        {
            var list = new List<byte>();
            DefaultInstance.Write(value, list.AsWriteOnlyStream());
            return list.ToArray();
        }

        public static T FromBytes(in ReadOnlySpan<byte> bytes)
        {
            return DefaultInstance.Read(bytes.ToArray().AsReadOnlyStream());
        }

        public static T FromBytes(in IReadOnlyList<byte> bytes)
        {
            return DefaultInstance.Read(bytes.AsReadOnlyStream());
        }

        public static T Read(in IReadOnlyStream<byte> stream)
        {
            return DefaultInstance.Read(stream);
        }

        public static void Write(in IWriteOnlyStream<byte> stream, in T value)
        {
            DefaultInstance.Write(value, stream);
        }
    }
}