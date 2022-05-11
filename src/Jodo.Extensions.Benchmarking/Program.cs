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

using Jodo.Extensions.Benchmarking;
using System;
using System.Diagnostics;
using System.Linq;

public static class Program
{

#if DEBUG
        public static This_compile_prevents_benchmarks_being_built_in_debug _;
#endif
    static Program()
    {
        if (Debugger.IsAttached) throw new InvalidOperationException(
            "This exception precents benchmarks from being run with a debugger attached.");
    }

    public static void Main(string[] _)
    {
        Console.WriteLine("Scanning loaded assemblies...");

        var benchmarkMethods = AppDomain.CurrentDomain
            .GetAssemblies()
            .SelectMany(a => a.GetTypes())
            .SelectMany(t => t.GetMethods())
            .Where(m => m.CustomAttributes.Any(c => c.AttributeType == typeof(BenchmarkAttribute)))
            .ToArray();

        Console.WriteLine($"Found {benchmarkMethods.Length} method(s) with the {nameof(BenchmarkAttribute)}.");

        if (benchmarkMethods.Any())
        {
            Console.WriteLine("Executing benchmarks...");
            Console.WriteLine();

            Writer.WriteHeader();

            foreach (var method in benchmarkMethods)
            {
                if (method.IsStatic &&
                    !method.GetParameters().Any() &&
                    !method.ContainsGenericParameters &&
                    !method.ReflectedType.ContainsGenericParameters)
                {
                    method.Invoke(null, Array.Empty<object>());
                }
                else
                {
                    Console.Error.WriteLine($"{method} cannot be run. " +
                        "Benchmark methods must be public, static, parameterless and non-generic");
                }
            }

            Writer.WriteFooter();
        }

        Console.WriteLine();
        Console.WriteLine("Press any key to exit...");
        Console.ReadKey();
    }
}
