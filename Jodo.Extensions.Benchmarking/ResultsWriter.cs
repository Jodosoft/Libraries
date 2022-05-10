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
using System.IO;

namespace Jodo.Extensions.Benchmarking
{
    public static class ResultsWriter
    {
        public static bool WrittenHeader = false;

        public static void Write(string name, BenchmarkCompareResult result)
        {
            const string FileName = "BenchmarkCompareResults.md";
            const string Header1 = "| Name | Iterations | Function time /seconds | Baseline time /seconds | Observation |";
            const string Header2 = "| --- | --- | --- | --- | --- |";

            var baselineSeconds = result.BaselineTotalDuration.TotalSeconds;
            var functionSeconds = result.FunctionTotalDuration.TotalSeconds;

            var timesSlower = functionSeconds / baselineSeconds;
            var timesFaster = baselineSeconds / functionSeconds;

            var observation =
                    timesSlower >= 10 ? $"{timesSlower:N0}x slower" :
                    timesSlower > 1.01 ? $"{timesSlower:N1}x slower" :
                    timesSlower < 0.99 ? $"{timesFaster:N1}x faster" :
                    "*Marginal difference*";

            var emphasis = timesSlower > 1.01 ? "**" : string.Empty; ;

            string row =
                $"| {name} " +
                $"| {result.Iterations:N0} " +
                $"| {functionSeconds:N4} " +
                $"| {baselineSeconds:N4} " +
                $"| {emphasis}{observation}{emphasis} " +
                $"|";

            Console.WriteLine(Header1);
            Console.WriteLine(Header2);
            Console.WriteLine(row);

            if (!WrittenHeader)
            {
                File.AppendAllLines(FileName, new[] {
                    "",
                    $"### Benchmark results {DateTime.UtcNow}",
                    "",
                    Header1,
                    Header2 });
                WrittenHeader = true;
            }

            File.AppendAllLines(FileName, new[] { row });
        }
    }
}
