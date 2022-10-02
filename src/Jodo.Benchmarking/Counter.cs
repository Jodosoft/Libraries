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
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace Jodo.Benchmarking
{
    [ExcludeFromCodeCoverage]
    public static class Counter
    {
        private static readonly TimeSpan TrialDuration = TimeSpan.FromSeconds(1);

        public static (Count Subject1, Count Subject2) Measure<T>(
           Func<T> inputFactory,
           Func<T, object> subject1,
           Func<T, object> subject2,
           TimeSpan overallDuration)
        {
            Stopwatch overallStopwatch = Stopwatch.StartNew();

            T input = inputFactory();
            Count count1 = Measure(subject1, input, TrialDuration);
            Count count2 = Measure(subject2, input, TrialDuration);

            while (overallStopwatch.Elapsed < overallDuration)
            {
                input = inputFactory();
                count1 = Add(count1, Measure(subject1, input, TrialDuration));
                count2 = Add(count2, Measure(subject2, input, TrialDuration));
            }

            return (count1, count2);
        }

        [MethodImpl(MethodImplOptions.NoOptimization)]
        public static Count Measure<T>(Func<T, object> subject, T input, TimeSpan duration)
        {
            object checkObj = new object();
            Stopwatch stopwatch = new Stopwatch();
            double maxTicks = duration.TotalSeconds * Stopwatch.Frequency;
            long iterations = 0;
            object obj;
            stopwatch.Start();
            do
            {
                obj = subject(input);
                iterations++;
            } while (stopwatch.ElapsedTicks < maxTicks);
            stopwatch.Stop();
            if (ReferenceEquals(obj, checkObj)) throw new InvalidOperationException();
            return new Count(iterations, stopwatch.Elapsed);
        }

        private static Count Add(Count measurement1, Count measurement2)
        {
            return new Count(measurement1.Executions + measurement2.Executions, measurement1.TotalTime + measurement2.TotalTime);
        }
    }
}
