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
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Jodo.Primitives;

namespace Jodo.Numerics
{
    /// <summary>
    /// Converts numeric values to arrays of bytes, and an array of bytes to numeric values.
    /// </summary>
    /// <seealso cref="INumeric{TSelf}"/>
    /// <seealso cref="BitConverter"/>
    public static class BitConverterN
    {
        /// <inheritdoc cref="INumericBitConverter{TNumeric}.ToNumeric(byte[], int)"/>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TNumeric ToNumeric<TNumeric>(byte[] value, int startIndex) where TNumeric : struct, INumeric<TNumeric>
        {
            return Provider<TNumeric, INumericBitConverter<TNumeric>>.Default.ToNumeric(value, startIndex);
        }

        /// <inheritdoc cref="INumericBitConverter{TNumeric}.GetBytes(TNumeric)"/>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte[] GetBytes<TNumeric>(TNumeric value) where TNumeric : struct, INumeric<TNumeric>
        {
            return Provider<TNumeric, INumericBitConverter<TNumeric>>.Default.GetBytes(value);
        }

        /// <inheritdoc cref="INumericBitConverter{TNumeric}.ConvertedSize"/>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int ConvertedSize<TNumeric>() where TNumeric : struct, INumeric<TNumeric>
        {
            return Provider<TNumeric, INumericBitConverter<TNumeric>>.Default.ConvertedSize;
        }
    }
}