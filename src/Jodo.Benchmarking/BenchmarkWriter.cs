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
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;

namespace Jodo.Benchmarking
{
    [ExcludeFromCodeCoverage]
    public static class BenchmarkWriter
    {
        public static readonly string AssemblyName = Assembly.GetEntryAssembly().GetName().Name;
        public static readonly string FileName = $"{AssemblyName}.Results.md";

        public static void WriteHeader(TimeSpan duration, string processor, string ram)
        {
            string assemblyName = Assembly.GetEntryAssembly().GetName().Name;

            string[] lines = new[] {
                    string.Empty,
                    $"{assemblyName} - Results from {DateTime.UtcNow:u}",
                    "------",
                    string.Empty,
                    $"> * **Processor:** {processor}",
                    $"> * **RAM:** {ram}",
                    $"> * **.NET Version:** {RuntimeInformation.FrameworkDescription}",
                    $"> * **Architecture:** {RuntimeInformation.ProcessArchitecture}",
                    $"> * **OS:** {RuntimeInformation.RuntimeIdentifier}",
                    $"> * **Seconds per Benchmark:** {duration.TotalSeconds:N1}",
                    string.Empty,
                    "| Subjects \"(1)\\_Versus\\_(2)\" | Operations Per Second (1) | Operations Per Second (2) | Average Time (1) | Average Time (2) | Relative Speed (1) | Relative Speed (2) |",
                    "| --- | --- | --- | --- | --- | --- | --- |" };
            foreach (string line in lines)
            {
                Console.WriteLine(line);
            }
            File.AppendAllLines(FileName, lines);
        }

        public static void WriteFooter()
        {
            Console.WriteLine();
            File.AppendAllLines(FileName, new[] { string.Empty });
        }

        public static void WriteError(string name)
        {
            string row = $"| {name} | *Error* | *Error* | *Error* | *Error* | *Error* | *Error* |";

            Console.WriteLine(row);
            File.AppendAllLines(FileName, new[] { row });
        }

        public static void WriteResult(BenchmarkResult result)
        {
            string row =
                $"| {result.Name} " +
                $"| {FormatRate(result.Subject1)} " +
                $"| {FormatRate(result.Subject2)} " +
                $"| {FormatTime(result.Subject1)} " +
                $"| {FormatTime(result.Subject2)} " +
                $"| {FormatRatio(result.Subject1, result.Subject2)} " +
                $"| {FormatRatio(result.Subject2, result.Subject1)} " +
                $"|";

            Console.WriteLine(row);
            File.AppendAllLines(FileName, new[] { row });
        }

        private static string FormatRate(Count count)
        {
            return $"{count.GetExecutionsPerSecond():G4}";
        }

        private static string FormatRatio(Count count, Count other)
        {
            double ratio = count.GetExecutionsPerSecond() / other.GetExecutionsPerSecond();

            return FormatRatio(ratio);
        }

        private static string FormatRatio(double ratio)
        {
            string em = ratio <= 0.9 ? "**" : string.Empty;
            if (ratio >= 100) return $"{em}{ratio:G4}{em}";
            if (ratio > 10) return $"{em}{ratio:N1}{em}";
            return $"{em}{ratio:N2}{em}";
        }

        private static string FormatTime(Count count)
        {
            long ticks = count.GetAverageTime().Ticks;
            double log10 = Math.Log10(ticks);

            if (!double.IsFinite(log10) || log10 < 1) return "*<1μs*";
            if (log10 < 4) return $"{ticks / 10.0:N1}μs";
            if (log10 < 7) return $"{ticks / 10_000.0:N1}ms";
            return $"{ticks / 10_000_000.0:N1}s";
        }
    }
}
