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

using System;
using System.IO;

namespace Jodosoft.Primitives
{
    /// <summary>
    /// Provides support for reading and writing types in binary using <see cref="BinaryReader"/> and <see cref="BinaryWriter"/>.
    /// </summary>
    /// <typeparam name="T">The type of object to read and write in binary.</typeparam>
    public interface IBinaryIO<T>
    {
        /// <summary>
        /// Reads a value of <typeparamref name="T"/> from binary using <paramref name="reader"/>.
        /// </summary>
        /// <param name="reader">The reader to use to read.</param>
        /// <returns>A value of <typeparamref name="T"/>.</returns>
        /// <exception cref="EndOfStreamException">The end of the stream is reached.</exception>
        /// <exception cref="ObjectDisposedException">The stream is closed.</exception>
        /// <exception cref="IOException">An I/O error occurred.</exception>
        T Read(BinaryReader reader);

        /// <summary>
        /// Writes a value of <typeparamref name="T"/> in binary using <paramref name="writer"/>.
        /// </summary>
        /// <param name="writer">The writer to use.</param>
        /// <param name="value">The value to write in binary.</param>
        /// <seealso cref="BinaryWriter.Write(byte[])"/>
        /// <exception cref="ObjectDisposedException">The stream is closed.</exception>
        /// <exception cref="IOException">An I/O error occurred.</exception>
        void Write(BinaryWriter writer, T value);
    }
}
