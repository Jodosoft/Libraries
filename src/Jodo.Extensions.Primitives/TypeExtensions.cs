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
using System.Collections.Concurrent;
using System.Linq;

namespace Jodo.Extensions.Primitives
{
    public static class TypeExtensions
    {
        private static readonly ConcurrentDictionary<Type, string> DisplayNamesByType
            = new ConcurrentDictionary<Type, string>();

        public static string GetDisplayName(this Type type)
        {
            return DisplayNamesByType.GetOrAdd(type, CreateDisplayName);
        }

        private static string CreateDisplayName(Type type)
        {
            if (type.IsGenericType)
            {
                string? parameterNames = type
                    .GetGenericArguments()
                    .Select(x => CreateDisplayName(x))
                    .Aggregate((x, y) => $"{x}, {y}");

                string? name = type.Name.Substring(0, type.Name.IndexOf('`'));
                return $"{name}<{parameterNames}>";
            }
            return type.Name;
        }
    }
}
