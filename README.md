<p align="center"><img src="Banner.png" alt="Logo" height="96"/></p>
<h1 align="center">The Jodo Libraries</h1>

<p align="center">
  <a href="https://github.com/JosephJShort/Jodo/blob/main/LICENSE.md"><img alt="GitHub" src="https://img.shields.io/github/license/JosephJShort/Jodo?style=flat-square&color=005784&logo=github&no-cache"></a>
  <a href="https://www.nuget.org/packages?q=Jodo."><img alt="Nuget (with prereleases)" src="https://img.shields.io/nuget/vpre/Jodo.Primitives?label=version&style=flat-square&color=005784&logo=nuget&no-cache"></a>
</p>

<h2>Contents</h2>

1. [Introduction](#introduction)
    1. [Principals](#principals)
1. [Jodo.Numerics](#jodonumerics)
    1. [Extended random numbers](#extended-random-numbers)
    1. [Generic number types](#generic-number-types)
    1. [Fixed-point arithmetic](#fixed-point-arithmetic)
    1. [Other features](#other-features)
    1. [Performance considerations](#performance-considerations)
1. [Jodo.CheckedNumerics](#jodocheckednumerics)
1. [Jodo.Geometry](#jodogeometry)
1. [Jodo.Collections](#jodocollections)
1. [Jodo.Primitives](#jodoprimitives)

<h2>Introduction</h2>

Welcome to The Jodo Libraries: a collection of .NET extensions written in C# covering numerics, geometry and data structures. Please see the table below for the general principals of this project, and the following sections for a summary of each package.

<h3>Principals</h3>

<table>
  <tr>
    <th>Item</th>
    <th>Description</th>
  </tr>
  <tr>
    <td>Activity</td>
    <td>
      <p>The Jodo packages are under active development, and are kept up to date with advancements in the .NET SDK. A list of upcoming changes can be seen at https://github.com/JosephJShort/Jodo/issues
      <p>
        <a href="https://dev.azure.com/JosephJShort/Jodo/_build?definitionId=1"><img alt="Azure DevOps builds" src="https://img.shields.io/azure-devops/build/JosephJShort/Jodo/1?logo=azuredevops&style=flat-square&no-cache"></a>
        <a href="https://github.com/JosephJShort/Jodo/commits/main"><img alt="GitHub last commit" src="https://img.shields.io/github/last-commit/JosephJShort/Jodo?logo=github&style=flat-square&no-cache"></a>
      </p>
    </td>
  </tr>
  <tr>
    <td>Reliability</td>
    <td>
      <p>Unit tests, benchmarks, and continuous integration tools are used to ensure the packages are fit for purpose.</p>
      <p>The target code coverage percentage for this project is 90%, though it is considered equally important to re-cover code to assert on boundary conditions, edge-cases, and error scenarios.</p>
      <p>Click on the shields below to see the latest test results and coverage.</p>
      <p>
        <a href="https://dev.azure.com/JosephJShort/Jodo/_build?definitionId=1"><img alt="Azure DevOps tests" src="https://img.shields.io/azure-devops/tests/JosephJShort/Jodo/1/main?logo=azuredevops&style=flat-square&no-cache"></a>
        <a href="https://sonarcloud.io/summary/overall?id=JosephJShort_Jodo"><img alt="Sonar Coverage" src="https://img.shields.io/sonar/coverage/JosephJShort_Jodo/main?logo=sonarcloud&server=https%3A%2F%2Fsonarcloud.io&style=flat-square&no-cache"></a>
      </p>
    </td>
  </tr>
  <tr>
    <td>Maintainability</td>
    <td>
      <p>
        This project adheres to the <a href="https://docs.microsoft.com/en-us/dotnet/standard/design-guidelines/">Framework Design Guidelines</a> to ensure ease-of-use and consistency with the .NET API.</p>
        <p>
        <a href="https://docs.microsoft.com/en-us/visualstudio/code-quality/roslyn-analyzers-overview?view=vs-2022">Rosyln analysers</a> are used with maximum rule-severity to ensure the code base stays conformant. Rules are only suppressed in exceptional circumstances, and suppression tags always include a justification message.
      </p>
      <p>Two static analysis tools, <a href="https://sonarcloud.io/summary/overall?id=JosephJShort_Jodo">SonarCloud</a> and <a href="https://www.codefactor.io/repository/github/josephjshort/jodo/overview/main">CodeFactor</a>, are used to further ensure that the code remains maintainable.
      <p>
        <a href="https://sonarcloud.io/summary/overall?id=JosephJShort_Jodo"><img alt="Sonar Violations (long format)" src="https://img.shields.io/sonar/violations/JosephJShort_Jodo/main?label=smells&logo=sonarcloud&server=https%3A%2F%2Fsonarcloud.io&style=flat-square&no-cache" /></a>
        <a href="https://www.codefactor.io/repository/github/josephjshort/jodo/overview/main"><img alt="CodeFactor Grade" src="https://img.shields.io/codefactor/grade/github/JosephJShort/Jodo/main?label=quality&logo=codefactor&style=flat-square&no-cache"></a></p>
    </td>
  </tr>
  <tr>
    <td>Compatibility</td>
    <td>     
      <p>
        .NET Standard 2.0 (<code>netstandard2.0</code>) and .NET Framework 4.6 (<code>net461</code>) are targeted in order to <a href="https://docs.microsoft.com/en-us/dotnet/standard/library-guidance/cross-platform-targeting">maximize cross-platform support</a>.
        Additional targets such as .NET Standard 2.1 (<code>netstandard2.1</code>) are used to incorporate newer language features like <a href="https://docs.microsoft.com/en-gb/dotnet/csharp/whats-new/csharp-8#default-interface-methods">default interface methods</a>.
      </p>
      <p>Publically exposed types are marked as <a href="https://docs.microsoft.com/en-us/dotnet/standard/language-independence">CLS compliant</a> wherever possible, and language-agnostic naming conventions are used.</p>
      <p>
        <img alt="Target net461" src="https://img.shields.io/badge/target-.NET%20Framework%204.6-005784?logo=dotnet&style=flat-square&color=005784">
        <img alt="Target netstandard2.0" src="https://img.shields.io/badge/target-.NET%20Standard%202.0-005784?logo=dotnet&style=flat-square&color=005784">
      </p>
    </td>
  </tr>
  <tr>
    <td>Community</td>
    <td>
      <p>Community contributions are welcome at https://github.com/JosephJShort/Jodo (the home of this repository). Contributors are requested to adhere to the <a href="CODE-OF-CONDUCT.md">code of conduct</a>.</p>
      <p>This work is licensed under the <a href="LICENSE.md">MIT License</a>.</p>
      <p>
        <a href="https://github.com/JosephJShort/Jodo/blob/main/LICENSE.md"><img alt="GitHub" src="https://img.shields.io/github/license/JosephJShort/Jodo?style=flat-square&color=005784&logo=github"></a>
        <a href="https://github.com/JosephJShort/Jodo/stargazers"><img alt="GitHub issues" src="https://img.shields.io/github/stars/JosephJShort/Jodo?logo=github&style=flat-square&color=005784&no-cache"></a>
      </p>
    </td>
  </tr>
  <tr>
    <td>Availability</td>
    <td>
      <p>Builds of this project are available as NuGet packages on <a href="https://www.nuget.org/packages?q=Jodo.">NuGet.org</a> (for installation instructions see: <a href="https://docs.microsoft.com/en-us/nuget/quickstart/install-and-use-a-package-in-visual-studio">"Quickstart: Install and use a package"</a>).</p>
      <p>Binaries are available on GitHub.com at <a href="https://github.com/JosephJShort/Jodo/releases">https://github.com/JosephJShort/Jodo/releases</a>.</p>
      <p><a href="https://semver.org/">Semantic Versioning</a> is used to ensure that version numbers convey the presence of breaking changes.</p>
      <p>The project can be built from the source code in this repository using <a href="https://visualstudio.microsoft.com/vs/community/">Visual Studio Community Edition</a> with the appropriate <a href="https://dotnet.microsoft.com/en-us/download/visual-studio-sdks">.NET SDKs</a>.</p>
      <p>
        <a href="https://www.nuget.org/packages?q=Jodo."><img alt="Nuget (with prereleases)" src="https://img.shields.io/nuget/vpre/Jodo.Primitives?label=version&style=flat-square&color=005784&logo=nuget&no-cache"></a>
        <a href="[https://www.nuget.org/packages?q=Jodo.](https://github.com/JosephJShort/Jodo/releases)"><img alt="GitHub release (latest SemVer including pre-releases)" src="https://img.shields.io/github/v/release/JosephJShort/Jodo?include_prereleases&logo=github&style=flat-square&color=005784&no-cache"></a>
      </p>
    </td>
  </tr>
  <tr>
    <td>Usability</td>
    <td>
      <p>Work-in-progress API documentation is available at https://jodo.dev. Please see the sections below for more detail on each package.</p>
      <p>
        <a href="https://jodo.dev"><img alt="Documentation" src="https://img.shields.io/badge/documentation-passing-005784?style=flat-square&color=005784"></a>
      </p>
    </td>
  </tr>
</table>

<h2>Jodo.Numerics</h2>

Provides extended number types and operations.

### Extended random numbers

Extension methods on <a href="https://docs.microsoft.com/en-us/dotnet/api/system.random">Random</a> are provided that allow for inclusive upper bounds and bounds specified in any order. A full range of values are supported, even on floating-point types, for example:

```csharp
using Jodo.Numerics;
using System;

var value = new Random().NextDouble(double.MinValue, double.MaxValue);
```
### Generic number types

The <a href="#inumericn">INumeric&lt;N&gt;</a> interface allows for number types to be used in a generic context.

Overloaded operators, commonly-used interfaces, and utility class such as `MathN` and `ConvertN` allow for these types to be used seemlessly in place of the built-in number types.

<table>
  <tr>
    <th>Feature</th>
    <th>Description</th>
  </tr>
  <tr />
  <tr>
    <td id="inumericn"><sub><em>interface</em></sub><br />INumeric&lt;N&gt;</td>
    <td>Provides an abstraction for numeric value types, guaranteeing a common set of features and allowing them to be used in generic contexts.</td>
  </tr>
  <tr />
  <tr>
    <td id="mathn"><sub><em>static class</em></sub><br />MathN</td>
    <td>
      <p>Provides equivalent methods to <a href="https://docs.microsoft.com/en-us/dotnet/api/system.math">System.Math</a> for types that implement <a href="#inumericn">INumeric&lt;N&gt;</a>, e.g. <code>Log(N)</code>, <code>Acosh(N)</code> and <code>Round(N, int)</code>.</p>
      <p>This is demonstrated by the following code sample:</p>
    <pre lang="csharp"><code>var res1 = MathF.Log10(1000 * MathF.PI);
var res2 = MathN.Log10(1000 * MathN.PI&lt;fix64&gt;());

Console.WriteLine(res1); // output: 3.49715
Console.WriteLine(res2); // output: 3.497149</code></pre>
    </td>
  </tr>
  <tr />
  <tr>
    <td id="bitconvertern"><sub><em>static class</em></sub><br />BitConverterN</td>
    <td>
      <p>Provides equivalent methods to <a href="https://docs.microsoft.com/en-us/dotnet/api/system.bitconverter">System.BitConverter</a> for types that implement <a href="#inumericn">INumeric&lt;N&gt;</a>, supporting conversion to and from byte arrays.
      <p>This is demonstrated by the following code sample:</p>
<pre lang="csharp"><code>byte[] res1 = BitConverter.GetBytes((ulong)1234567890);
byte[] res2 = BitConverterN.GetBytes((UFix64)256.512);

Console.WriteLine(BitConverter.ToString(res1)); // output: D2-02-96-49-00-00-00-00
Console.WriteLine(BitConverter.ToString(res2)); // output: 00-10-4A-0F-00-00-00-00</code></pre>
    </td>
  </tr>
  <tr />
  <tr>
    <td id="convertn"><sub><em>static class</em></sub><br />ConvertN</td>
    <td>Provides equivalent methods to <a href="https://docs.microsoft.com/en-us/dotnet/api/system.convert">System.Convert</a> for types that implement <a href="#inumericn">INumeric&lt;N&gt;</a> (e.g. <code>ToBoolean(N)</code> and <code>ToDecimal(N)</code>). Method overloads are provided to support different conversion modes, e.g. <code>Default</code>, <code>Cast</code> and <code>Clamp</code>.</td>
  </tr>
  <tr />
  <tr>
    <td id="wrappers"><sub><em>readonly struct</em></sub><br />
      <code>ByteN</code>, <code>SByteN</code>,<br />
      <code>Int16N</code>, <code>UInt16N</code>,<br />
      <code>Int32N</code>, <code>UInt32N</code>,<br />
      <code>Int64N</code>, <code>UInt64N</code>,<br />
      <code>SingleN</code>, <code>DoubleN</code>,<br />
      <code>DecimalN</code>
    </td>
    <td>Wrappers for the <a href="https://docs.microsoft.com/en-us/dotnet/standard/numerics">built-in numeric types</a> that implement <a href="#inumericn">INumeric&lt;N&gt;</a>, allowing them to be used in a generic context .</td>
  </tr>
  <tr />
  <tr>
    <td id="operators">Overloaded operators</td>
    <td>
      <p>All the provided numeric types have a full suite of overloaded operators, including:
      <ul>
        <li><a href="https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/operators/equality-operators">Equality operators</a> (<code>==</code>, <code>!=</code>)</li>
        <li><a href="https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/operators/equality-operators">Comparison operators</a> (<code>&lt;</code>, <code>&gt;</code>, <code>&lt;=</code>, <code>&gt;=</code>)</li>
        <li><a href="https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/operators/arithmetic-operators">Arithmetic operators</a> (<code>++</code>, <code>--</code>, <code>*</code>, <code>/</code>, <code>%</code>, <code>+</code>, <code>-</code>)</li>
        <li><a href="https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/operators/bitwise-and-shift-operators">Bitwise and shift operators</a> (<code>~</code>, <code>&lt;&lt;</code>, <code>&gt;&gt;</code>, <code>&</code>, <code>|</code>, <code>^</code>)</li>
        <li><a href="https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/operators/user-defined-conversion-operators">Conversion operators</a> to/from the built-in numeric types</li>
      </ul>
  </p>
   <p>
Additionally, <a href="#inumericn">INumeric&lt;N&gt;</a> defines overloads for <code>&lt;</code>, <code>&gt;</code>, <code>&lt;=</code>, <code>&gt;=</code>, <code>++</code>, <code>--</code>, <code>*</code>, <code>/</code>, <code>%</code>, <code>+</code>, <code>-</code>, <code>~</code>, <code>&lt;&lt;</code>, <code>&gt;&gt;</code>, <code>&</code>, <code>|</code> and <code>^</code>, allowing for limited expressions in a generic context (note that equality and conversion operators are not supported on interfaces).
  </p>
  <p> <em>Note: The bitwise and shift operators are overloaded for non-integral types. These operators perform the correct bitwise operations, but are unlikely to produce useful results.</em></p>
      </td>
    </tr>
  <tr />
   <tr>
<td id="stringformatting">String formatting</td>
<td>
<p>All the provided numeric types can be used with <a href="https://docs.microsoft.com/en-us/dotnet/standard/base-types/standard-numeric-format-strings">numeric format strings</a>, as in the following code sample:</p>
  <pre lang="csharp"><code>var var1 = (xint)1024;
var var2 = (fix64)99.54322f;

Console.WriteLine($"{var1:N}"); // outputs: 1,024.00
Console.WriteLine($"{var1:X}"); // outputs: 400
Console.WriteLine($"{var2:E}"); // outputs: 9.954322E+001
Console.WriteLine($"{var2:000.000}"); // outputs: 099.543</code></pre>
</td>
</tr>
  <tr />
<tr>
<td>Random generation</td>
  <td>Extension methods on <a href="https://docs.microsoft.com/en-us/dotnet/api/system.random">Random</a> provide randomly generated values. Values can be generated between two bounds or without bounds, as in the following code sample:</p>
  <pre lang="csharp"><code>var var1 = Random.NextNumeric&lt;xdouble&gt;();
var var2 = Random.NextNumeric&lt;xdouble&gt;(100, 120);

Console.WriteLine(var1); // outputs: -7.405808417991177E+115 (example)
Console.WriteLine(var2); // outputs: 102.85086051826445 (example)</code></pre>
  
  </td>
</tr>
  <tr />
<tr>
<td>Commonly-used abstractions</td> <td>All the provided numeric types implement <a href="https://docs.microsoft.com/en-us/dotnet/api/system.icomparable">System.IComparable</a>, <a href="https://docs.microsoft.com/en-us/dotnet/api/system.icomparable-1">System.IComparable&lt;T&gt;</a>, <a href="https://docs.microsoft.com/en-us/dotnet/api/system.iconvertible">System.IConvertible</a>, <a href="https://docs.microsoft.com/en-us/dotnet/api/system.iequatable-1">System.IEquatable&lt;T&gt;</a>, <a href="https://docs.microsoft.com/en-us/dotnet/api/system.iformattable">System.IFormattable</a> and <a href="https://docs.microsoft.com/en-us/dotnet/api/system.runtime.serialization.iserializable">System.ISerializable</a>. They also override <code>Equals(object)</code>, <code>GetHashCode()</code> and <code>ToString()</code>, and have the <a href="https://docs.microsoft.com/en-us/dotnet/framework/debug-trace-profile/enhancing-debugging-with-the-debugger-display-attributes">DebuggerDisplay</a> attribute. </td>
</tr>
</table>

### Fixed-point arithmetic

Compared to floating-point numbers, <a href="https://en.wikipedia.org/wiki/Fixed-point_arithmetic">fixed-point</a> numbers provide a constant level of precision regardless of magnitude. This can be useful in situations where <a href="https://en.wikipedia.org/wiki/MIM-104_Patriot#Failure_at_Dhahran">precision remains important whilst numbers grow</a>. As a trade-off, fixed-point numbers have lower maximum magnitude than floating-point numbers of the same size.

 <pre lang="csharp"><code>var floatingPoint = 1000000 + MathF.PI;
var fixedPoint = 1000000 + MathN.PI&lt;Fix64&gt;();
Console.WriteLine(floatingPoint); // output: 1000003.1
Console.WriteLine(fixedPoint); // output: 1000003.141592</code></pre>

<table>
  <tr>
    <th>Type</th>
    <th>Description</th>
  </tr>
  <tr />
  <tr>
    <td id="fix64"><sub><em>readonly struct</em></sub><br /><code>Fix64</code>,<br /><code>UFix64</code></td>
    <td><p><a href="https://en.wikipedia.org/wiki/Fixed-point_arithmetic">Fixed-point</a> numeric types with 6 decimal digits of precision, represented internally by 64-bit integers.</p>
      <p>Supports a range of values from ±1.0 x 10<sup>−6</sup> to ±9.2 x 10<sup>12</sup> (or 1.0 x 10<sup>−6</sup> to 1.8 x 10<sup>13</sup> when unsigned).</p>
    </td>
  </tr>
  <tr />
</table>

### Other features

<table>
  <tr>
    <th>Type</th>
    <th>Description</th>
  </tr>
  <tr />
  <tr>
    <td id="unitn"><sub><em>readonly struct</em></sub><br />Unit&lt;N&gt;</td>
    <td>A wrapper for numeric types that clamps values between -1 and 1 (or 0 and 1 when unsigned).</td>
  </tr>
  <tr />
  <tr>
    <td id="vector2n"><sub><em>readonly struct</em></sub><br />Vector2&lt;N&gt;</td>
    <td>A collection of two numeric values, <code>X</code> and <code>Y</code>, with extensive interface and operator support.</td>
  </tr>
  <tr />
  <tr>
    <td id="vector3n"><sub><em>readonly struct</em></sub><br />Vector3&lt;N&gt;</td>
    <td>A collection of three numeric values, <code>X</code>, <code>Y</code> and <code>Z</code>, with extensive interface and operator support.</td>
  </tr>
</table>

### Performance considerations

The numeric types provided by this package are structs that wrap built-in types and operators. Therefore they consume more memory and CPU time compared to using the built-in types alone.

If developing a performance-sensitive application, use a profiler to assess the impact.

Benchmarks are provided to facilitate comparison with the built-in types. To run the benchmarks, clone this repository then build and run *Jodo.Numerics.Benchmarks.exe* in RELEASE mode.

Sample output can be seen below:
  

<details>
<summary><em>Jodo.Numerics.Benchmarks - Results from 2022-06-03T21:30:27.6877090Z</em></summary>

  > * **Processor:** 11th Gen Intel(R) Core(TM) i7-11800H @ 2.30GHz
  > * **Architecture:** x64-based processor
  > * **RAM:** 16.0 GB
  > * **OS:** Windows 10 (64-bit)
  > * **Seconds per Benchmark:** 60.0

| Name | Ops Per Second | Time | Baseline Ops Per Second | Baseline Time | Observation |
| --- | --- | --- | --- | --- | --- |
| XInt_Versus_Int32_Division | 1.798E+08 | *<1μs* | 1.94E+08 | *<1μs* | *Marginal difference* |
| XInt_Versus_Int32_StringParsing | 7.305E+07 | *<1μs* | 6.734E+07 | *<1μs* | *Marginal difference* |
| XDouble_Versus_Double_StringParsing | 1.663E+06 | *<1μs* | 1.624E+06 | *<1μs* | *Marginal difference* |
| Fix64_Versus_Double_Division | 1.455E+07 | *<1μs* | 1.593E+08 | *<1μs* | 10.9x slower |

</details>


<h2>Jodo.CheckedNumerics</h2>
  
Provides numeric types (implementing <a href="#inumericn">INumeric&lt;N&gt;</a>) and utilities with built-in protection from overflow.

Useful for preventing unexpected negative/positive, infinite or `NaN` values from entering a system.
        
Usage is the same as with built-in numeric types but yields different results as demonstrated by the following code example:
```csharp
var x1 = cint.MaxValue + 1;
Console.WriteLine(x1);  // output: 2147483647

var x2 = (cfloat)4 / 0;
Console.WriteLine(x2);  // output: 3.402823E+38
```

### Types

| Type | Description |
| --- | --- |
| <sub><em>static class</em></sub><br />CheckedArithmetic | Provides checked arithmetic methods for the built-in numeric types. |
| <sub><em>static class</em></sub><br />CheckedConvert | Provides checked equivalents to [Convert](https://docs.microsoft.com/en-us/dotnet/api/system.convert). |
| <sub><em>readonly struct</em></sub><br />`cbyte`, `csbyte`,<br />`cshort`, `cushort`,<br />`cint`, `cuint`,<br />`clong`, `culong`,<br />`cdecimal` | Operations that would overflow instead return `MinValue` or `MaxValue` depending on the direction of the overflow. Division by zero does NOT throw a [DivideByZeroException](https://docs.microsoft.com/en-us/dotnet/api/system.dividebyzeroexception) but returns `MaxValue`. |
| <sub><em>readonly struct</em></sub><br />`cfloat`,<br />`cdouble` | Operations that would overflow do NOT return `NegativeInfinity` or `PositiveInfinity` but return `MinValue` or `MaxValue` respectively. Division by zero does NOT return `NegativeInfinity`, `PositiveInfinity` or `NaN` but returns `MaxValue`. It is not possible for values to be `NegativeInfinity`, `PositiveInfinity` or `NaN`. |
| <sub><em>readonly struct</em></sub><br />`cfix64`,<br />`cufix64` | <a href="https://en.wikipedia.org/wiki/Fixed-point_arithmetic">Fixed-point</a> numeric types with 6 digits of precision. Supporting a range of values from ±1.0 x 10<sup>−6</sup> to ±9.2 x 10<sup>12</sup> (or 1.0 x 10<sup>−6</sup> to 1.8 x 10<sup>13</sup> when unsigned). Represented internally by 64-bit integers. |

### Performance considerations

The numeric types provided by this package are structs that wrap built-in types and operators. Therefore they consume more memory and CPU time compared to using the built-in types alone.

Additionally, the [checked](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/checked) keyword is used for conversion and arithmetic with these types. Therefore they use more CPU time compared to built-in numeric types, especially in cases of overflow.

If developing a performance-sensitive application, use a profiler to assess the impact. As a rule of thumb the impact is likely to be acceptable in logical applications, but not in arithmetic-intesive applications, such as 3D graphics or big-data.

Benchmarks are provided to facilitate comparison with the built-in types. To run the benchmarks, clone this repository then build and run *Jodo.CheckedNumerics.Benchmarks.exe* in RELEASE mode.

Sample output can be seen below:
<details>
  <summary><em>Jodo.CheckedNumerics.Benchmarks - Results from 2022-05-11T18:11:17.8665440Z</em></summary>

  > * **Processor:** 11th Gen Intel(R) Core(TM) i7-11800H @ 2.30GHz
  > * **Architecture:** x64-based processor
  > * **RAM:** 16.0 GB
  > * **OS:** Windows 10 (64-bit)
  > * **Seconds per Benchmark:** 10.0

  | Name | Baseline Ops Per Second | Baseline Time | Ops Per Second | Time | Observation |
  | --- | --- | --- | --- | --- | --- |
  | CInt_Negation_Vs_Int | 2.172E+08 | *<1μs* | 1.131E+08 | *<1μs* | 1.9x slower |
  | CInt_Division_Vs_Int | 3.417E+08 | *<1μs* | 1.112E+08 | *<1μs* | 3.0x slower |
  | CInt_ConversionToFloat_Vs_Int | 3.815E+08 | *<1μs* | 2.487E+08 | *<1μs* | 1.5x slower |
  | CInt_StringParsing_Vs_Int | 7.443E+07 | *<1μs* | 5.885E+07 | *<1μs* | 1.3x slower |
  | **CInt_MultiplicationOverflow_Vs_Int** | **3.725E+08** | ***<1μs*** | **1.453E+05** | **6.8μs** | **2563x slower** |

</details>

<h2>Jodo.Geometry</h2>

> This package is a work in progress.

Provides geometric value types.

| CheckedGeometry type | Notes |
| - | - |
| AARectangle\<T\> | Axis-aligned rectangle |
| Rectangle\<T\> |  |
| Circle\<T\> |  |
| Angle\<T\> |  |

<h2>Jodo.Collections</h2>

> This package is a work in progress.
  
<h2>Jodo.Primitives</h2>

Provides miscellaneous interfaces and extension methods used throughout the Jodo packages. 
