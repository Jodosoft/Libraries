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
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace Jodo.Primitives
{
    public static class RandomExtensions
    {
        public static T Choose<T>(this Random random, T item, params T[] items)
        {
            if (items != null && items.Length > 0)
            {
                int index = random.Next(0, items.Length + 1);
                return index == items.Length ? item : items[index];
            }
            return item;
        }

        public static T NextElement<T>(this Random random, IList<T> list)
        {
            if (list == null) throw new ArgumentNullException(nameof(list));
            if (list.Count == 0) throw new ArgumentException("Must not be empty.", nameof(list));
            return list[random.Next(list.Count)];
        }

#if HAS_SPANS
        public static T NextElement<T>(this Random random, Span<T> span)
            => span[random.Next(0, span.Length)];

        public static T NextElement<T>(this Random random, ReadOnlySpan<T> span)
            => span[random.Next(0, span.Length)];
#endif

        public static byte[] NextBytes(this Random random, int count)
        {
            byte[]? bytes = new byte[count];
            random.NextBytes(bytes);
            return bytes;
        }

        public static TEnum NextEnum<TEnum>(this Random random) where TEnum : Enum
        {
            Array? values = Enum.GetValues(typeof(TEnum));
            return (TEnum)values.GetValue(random.Next(0, values.Length));
        }

        public static bool NextBoolean(this Random random)
            => random.Next(0, 2) == 1;

        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T NextVariant<T>(this Random random) where T : struct, IProvider<IVariantRandom<T>>
            => Provider<T, IVariantRandom<T>>.Default.Next(random, Scenarios.All);

        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T NextVariant<T>(this Random random, Scenarios scenarios) where T : struct, IProvider<IVariantRandom<T>>
            => Provider<T, IVariantRandom<T>>.Default.Next(random, scenarios);
    }
}
