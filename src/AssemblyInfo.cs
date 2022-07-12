﻿// Copyright (c) 2022 Joseph J. Short
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
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Jodo.Benchmarking.Tests")]
[assembly: InternalsVisibleTo("Jodo.CheckedGeometry.Benchmarks")]
[assembly: InternalsVisibleTo("Jodo.CheckedGeometry.Tests")]
[assembly: InternalsVisibleTo("Jodo.CheckedNumerics.Benchmarks")]
[assembly: InternalsVisibleTo("Jodo.CheckedNumerics.Tests")]
[assembly: InternalsVisibleTo("Jodo.Collections.Benchmarks")]
[assembly: InternalsVisibleTo("Jodo.Collections.Tests")]
[assembly: InternalsVisibleTo("Jodo.Numerics.Benchmarks")]
[assembly: InternalsVisibleTo("Jodo.Numerics.Tests")]
[assembly: InternalsVisibleTo("Jodo.Testing.Tests")]

[assembly: SuppressMessage("CodeQuality", "IDE0079:Remove unnecessary suppression")]

[assembly: CLSCompliant(true)]
