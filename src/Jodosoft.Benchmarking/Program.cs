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
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reflection;

[assembly: ExcludeFromCodeCoverage]
[assembly: SuppressMessage("csharpsquid", "S2245:Using pseudorandom number generators (PRNGs) is security-sensitive", Justification = "Not a security-sensitive application.")]

namespace Jodosoft.Benchmarking
{
    public static class Program
    {
        private static readonly TimeSpan Duration = TimeSpan.FromSeconds(60);

        public static void Main(string[] args)
        {
            GuardAgainstDebug(args);

            MethodInfo[] benchmarkMethods = GetBenchmarks();

            if (benchmarkMethods.Any())
            {
                Console.WriteLine($"Writing to \"./{BenchmarkWriter.FileName}\".");
                Console.WriteLine("Executing benchmarks...");
                Console.WriteLine();

                BenchmarkWriter.WriteHeader(
                    Duration,
                    GetArgOrDefault(args, "processor") ?? "*tbc*",
                    GetArgOrDefault(args, "ram") ?? "*tbc*");

                foreach (MethodInfo method in benchmarkMethods)
                {
                    TryRunBenchmark(method);
                }

                BenchmarkWriter.WriteFooter();
            }

            Console.WriteLine();
            Console.WriteLine("Press any key to exit...");
            _ = Console.ReadKey();
        }

        private static void TryRunBenchmark(MethodInfo method)
        {
            if (method.IsStatic &&
                                    method.ReturnType == typeof(Benchmark) &&
                                    !method.GetParameters().Any() &&
                                    !method.ContainsGenericParameters &&
                                    !method.ReflectedType.ContainsGenericParameters)
            {
                Benchmark benchmark = (Benchmark)method.Invoke(null, Array.Empty<object>());
                try
                {
                    BenchmarkResult result = benchmark.Execute(Duration);
                    BenchmarkWriter.WriteResult(result);
                }
                catch (Exception)
                {
                    BenchmarkWriter.WriteError(benchmark.Name);
                }
            }
            else
            {
                Console.Error.WriteLine($"{method} cannot be run. " +
                    "Benchmark methods must be public, static, parameterless and non-generic");
            }
        }

        private static MethodInfo[] GetBenchmarks()
        {
            Console.WriteLine($"Scanning loaded assemblies for benchmarks (public, static, parameterless and non-generic methods with the {nameof(BenchmarkAttribute)})...");

            MethodInfo[] benchmarkMethods = AppDomain.CurrentDomain
                .GetAssemblies()
                .SelectMany(a => a.GetTypes())
                .SelectMany(t => t.GetMethods())
                .Where(m => m.CustomAttributes.Any(c => c.AttributeType == typeof(BenchmarkAttribute)))
                .ToArray();

            Console.WriteLine($"Found {benchmarkMethods.Length} benchmark(s).");
            return benchmarkMethods;
        }

        private static void GuardAgainstDebug(string[] args)
        {
#if DEBUG
            if (args?.SingleOrDefault(x => x == "-fd") == null)
            {
                Console.WriteLine(
                "Benchmarks built in Debug configuration are disabled." +
                " Use the -fd flag to override this behavior.");
                Console.WriteLine();
                Console.WriteLine("Press any key to exit...");
                _ = Console.ReadKey();
                Environment.Exit(-1);
            }
#endif
            if (Debugger.IsAttached && args?.SingleOrDefault(x => x == "-fd") == null)
            {
                Console.WriteLine(
                    "Benchmarks are disabled with a debugger attached." +
                    " Use the -fd flag to override this behavior.");
                Console.WriteLine();
                Console.WriteLine("Press any key to exit...");
                _ = Console.ReadKey();
                Environment.Exit(-1);
            }
        }

        private static string GetArgOrDefault(string[] args, string name)
        {
            int index = Array.IndexOf(args, $"--{name}");

            if (index == -1 ||
                index + 1 >= args.Length ||
                args[index + 1] == null ||
                args[index + 1].StartsWith("-", StringComparison.InvariantCultureIgnoreCase))
            {
                return null;
            }
            return args[index + 1];
        }
    }
}
