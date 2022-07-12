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
using System.Diagnostics;
using Jodo.Primitives;

namespace Jodo.Numerics
{
    [CLSCompliant(false)]
    public static class ConvertExtended<N> where N : struct, IProvider<IConvertUnsigned<N>>
    {
        private static readonly IConvertUnsigned<N> Default = default(N).GetInstance();

        [DebuggerStepThrough]
        public static sbyte ToSByte(N value) => Default.ToSByte(value, Conversion.Default);

        [DebuggerStepThrough]
        public static sbyte ToSByte(N value, Conversion mode) => Default.ToSByte(value, mode);

        [DebuggerStepThrough]
        public static uint ToUInt32(N value) => Default.ToUInt32(value, Conversion.Default);

        [DebuggerStepThrough]
        public static uint ToUInt32(N value, Conversion mode) => Default.ToUInt32(value, mode);

        [DebuggerStepThrough]
        public static ulong ToUInt64(N value) => Default.ToUInt64(value, Conversion.Default);

        [DebuggerStepThrough]
        public static ulong ToUInt64(N value, Conversion mode) => Default.ToUInt64(value, mode);

        [DebuggerStepThrough]
        public static ushort ToUInt16(N value) => Default.ToUInt16(value, Conversion.Default);

        [DebuggerStepThrough]
        public static ushort ToUInt16(N value, Conversion mode) => Default.ToUInt16(value, mode);

        [DebuggerStepThrough]
        public static N ToNumeric(sbyte value) => Default.ToValue(value, Conversion.Default);

        [DebuggerStepThrough]
        public static N ToNumeric(sbyte value, Conversion mode) => Default.ToValue(value, mode);

        [DebuggerStepThrough]
        public static N ToNumeric(uint value) => Default.ToNumeric(value, Conversion.Default);

        [DebuggerStepThrough]
        public static N ToNumeric(uint value, Conversion mode) => Default.ToNumeric(value, mode);

        [DebuggerStepThrough]
        public static N ToNumeric(ulong value) => Default.ToNumeric(value, Conversion.Default);

        [DebuggerStepThrough]
        public static N ToNumeric(ulong value, Conversion mode) => Default.ToNumeric(value, mode);

        [DebuggerStepThrough]
        public static N ToNumeric(ushort value) => Default.ToNumeric(value, Conversion.Default);

        [DebuggerStepThrough]
        public static N ToNumeric(ushort value, Conversion mode) => Default.ToNumeric(value, mode);
    }
}
