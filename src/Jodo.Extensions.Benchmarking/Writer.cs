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

using Jodo.Extensions.Benchmarking.Internals;
using System;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Reflection;

namespace Jodo.Extensions.Benchmarking
{
    [ExcludeFromCodeCoverage]
    public static class Writer
    {
        private static readonly string FileName = $"{nameof(Benchmark)}Results.md";

        public static void WriteHeader()
        {
#pragma warning disable CS8602
            string? assemblyName = Assembly.GetEntryAssembly().GetName().Name;
#pragma warning restore CS8602
            var lines = new[] {
                    string.Empty,
                    "<details>",
                    $"<summary><em>{assemblyName} - Results from {DateTime.UtcNow:O}</em></summary>",
                    string.Empty,
                    "> * **Processor:** *tbc*",
                    "> * **Architecture:** *tbc*",
                    "> * **RAM:** *tbc*",
                    "> * **OS:** *tbc*",
                    $"> * **Seconds per Benchmark:** {Benchmark.DurationInSeconds:N1}",
                    string.Empty,
                    "| Name | Ops Per Second | Time | Baseline Ops Per Second | Baseline Time | Observation |",
                    "| --- | --- | --- | --- | --- | --- |" };
            foreach (var line in lines)
            {
                Console.WriteLine(line);
            }
            File.AppendAllLines(FileName, lines);
        }

        public static void WriteFooter()
        {
            var lines = new[] { string.Empty, "</details>" };
            foreach (var line in lines)
            {
                Console.WriteLine(line);
            }
            File.AppendAllLines(FileName, lines);
        }

        public static void Write(string name, Measurement subject, Measurement baseline)
        {
            var em = GetEmphasis(subject, baseline);
            string row =
                $"| {em}{name}{em} " +
                $"| {em}{subject.PerSecond:G4}{em} " +
                $"| {em}{GetTimeWithUnits(subject.AverageTime)}{em} " +
                $"| {em}{baseline.PerSecond:G4}{em} " +
                $"| {em}{GetTimeWithUnits(baseline.AverageTime)}{em} " +
                $"| {em}{GetObservation(subject, baseline)}{em} " +
                $"|";

            Console.WriteLine(row);
            File.AppendAllLines(FileName, new[] { row });
        }

        private static string GetEmphasis(Measurement subject, Measurement baseline)
        {
            var timesSlower = baseline.PerSecond / subject.PerSecond;

            var em = subject.AverageTime.Ticks > 9 && timesSlower > 1.01 ? "**" : string.Empty;
            return em;
        }

        private static string GetObservation(Measurement subject, Measurement baseline)
        {
            var timesSlower = baseline.PerSecond / subject.PerSecond;
            var timesFaster = subject.PerSecond / baseline.PerSecond;

            if (timesSlower >= 100) return $"{timesSlower:G4}x slower";
            if (timesFaster >= 100) return $"{timesFaster:G4}x faster";
            if (timesSlower >= 1.1) return $"{timesSlower:N1}x slower";
            if (timesFaster >= 1.1) return $"{timesFaster:N1}x faster";
            return "*Marginal difference*";
        }

        private static string GetTimeWithUnits(TimeSpan timeSpan)
        {
            var log10 = Math.Log10(timeSpan.Ticks);

            if (!double.IsFinite(log10) || log10 < 1) return "*<1μs*";
            if (log10 < 4) return $"{timeSpan.Ticks / 10.0:N1}μs";
            if (log10 < 7) return $"{timeSpan.Ticks / 10_000.0:N1}ms";
            return $"{timeSpan.Ticks / 10_000_000.0:N1}s";
        }
    }
}
