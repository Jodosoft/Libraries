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
using System.Runtime.CompilerServices;

namespace Jodo.Extensions.Benchmarking
{
    public static class Benchmark
    {
        private static readonly object BaselineObj = new object();
        private static readonly object CheckObj = new object();

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static BenchmarkCompareResult Compare(Func<object> function, Func<object> baseline, byte durationInSeconds)
        {
            var internalBaseline = new Func<object>(() => BaselineObj);
            var internalBaselineStopwatch = new Stopwatch();
            var baselineStopwatch = new Stopwatch();
            var functionStopwatch = new Stopwatch();

            ulong iterations = 0;
            object obj;

            var benchmarkStopwatch = Stopwatch.StartNew();

            do
            {
                internalBaselineStopwatch.Start();
                obj = internalBaseline();
                internalBaselineStopwatch.Stop();
                if (ReferenceEquals(obj, CheckObj)) throw new InvalidOperationException();

                baselineStopwatch.Start();
                obj = baseline();
                baselineStopwatch.Stop();
                if (ReferenceEquals(obj, CheckObj)) throw new InvalidOperationException();

                functionStopwatch.Start();
                obj = function();
                functionStopwatch.Stop();
                if (ReferenceEquals(obj, CheckObj)) throw new InvalidOperationException();

            } while (benchmarkStopwatch.Elapsed.TotalSeconds < 1);

            internalBaselineStopwatch.Reset();
            baselineStopwatch.Reset();
            functionStopwatch.Reset();

            do
            {
                internalBaselineStopwatch.Start();
                obj = internalBaseline();
                internalBaselineStopwatch.Stop();
                if (ReferenceEquals(obj, CheckObj)) throw new InvalidOperationException();

                baselineStopwatch.Start();
                obj = baseline();
                baselineStopwatch.Stop();
                if (ReferenceEquals(obj, CheckObj)) throw new InvalidOperationException();

                functionStopwatch.Start();
                obj = function();
                functionStopwatch.Stop();
                if (ReferenceEquals(obj, CheckObj)) throw new InvalidOperationException();

                iterations++;

            } while (benchmarkStopwatch.Elapsed.TotalSeconds < durationInSeconds);

            var result = new BenchmarkCompareResult(
                iterations,
                baselineStopwatch.Elapsed - internalBaselineStopwatch.Elapsed,
                functionStopwatch.Elapsed - internalBaselineStopwatch.Elapsed);

            ResultsWriter.Write(new StackTrace().GetFrame(1).GetMethod().Name, result);

            return result;
        }
    }
}
