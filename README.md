<p align="center"><img src="Banner.png" alt="Logo" height="96"/></p>
<h1 align="center">Jodo.Extensions</h1>

<p align="center">C# extension libraries written in the style of the .NET SDK.</p>

<p align="center">
  <a href="https://github.com/JosephJShort/Jodo.Extensions/blob/main/LICENSE.md"><img alt="GitHub" src="https://img.shields.io/github/license/JosephJShort/Jodo.Extensions?style=flat-square&color=%23004880"></a>
  <a href="https://www.nuget.org/packages?q=Jodo.Extensions"><img alt="Nuget (with prereleases)" src="https://img.shields.io/nuget/vpre/Jodo.Extensions.Primitives?label=version&logo=nuget&style=flat-square&color=%23004880"></a>
  <br />
  <a href="https://github.com/JosephJShort/Jodo.Extensions/issues"><img alt="GitHub issues" src="https://img.shields.io/github/issues/JosephJShort/Jodo.Extensions?logo=github&style=flat-square"></a>
  <a href="https://github.com/JosephJShort/Jodo.Extensions/commits/main"><img alt="GitHub last commit" src="https://img.shields.io/github/last-commit/JosephJShort/Jodo.Extensions?logo=github&style=flat-square"></a>
  <br />
  <a href="https://dev.azure.com/JosephJShort/Jodo.Extensions/_build?definitionId=1"><img alt="Azure DevOps builds" src="https://img.shields.io/azure-devops/build/JosephJShort/Jodo.Extensions/1?logo=azuredevops&style=flat-square"></a>
  <a href="https://dev.azure.com/JosephJShort/Jodo.Extensions/_build?definitionId=1"><img alt="Azure DevOps tests" src="https://img.shields.io/azure-devops/tests/JosephJShort/Jodo.Extensions/1/main?logo=azuredevops&style=flat-square"></a>
<br />
  <a href="https://sonarcloud.io/summary/overall?id=JosephJShort_Jodo.Extensions"><img alt="Sonar Violations (long format)" src="https://img.shields.io/sonar/violations/JosephJShort_Jodo.Extensions/main?label=smells&logo=sonarcloud&server=https%3A%2F%2Fsonarcloud.io&style=flat-square" /></a>
  <a href="https://sonarcloud.io/summary/overall?id=JosephJShort_Jodo.Extensions"><img alt="Sonar Coverage" src="https://img.shields.io/sonar/coverage/JosephJShort_Jodo.Extensions/main?logo=sonarcloud&server=https%3A%2F%2Fsonarcloud.io&style=flat-square"></a>
</p>

<h2>Jodo.Extensions.Numerics</h2>

Provides the <a href="#inumericn">INumeric&lt;N&gt;</a> interface and utilities for creating custom numeric types.

<a href="#inumericn">Fixed-point types</a> and <a href="#wrappers">wrappers for the built-in types</a> are provided.

Usage is easy, with fully supported operators, commonly-used interfaces and familiar static methods–as demonstrated by the following code sample:

```csharp
var xint1 = (xint)1234;
var xint2 = xint1 >> 0b11;

Console.WriteLine(xint1); // outputs: 1234
Console.WriteLine($"{xint2:X}"); // outputs: 9A

var fixed1 = 2 * Math<fix64>.PI;
var fixed2 = fixed1 / 1000;

Console.WriteLine(fixed1); // outputs: 6.283184
Console.WriteLine(fixed2); // outputs: 0.006283
```

### Types

<table>
  <tr>
    <th>Type</th>
    <th>Description</th>
  </tr>
  <tr>
    <td id="inumericn"><sub><em>interface</em></sub><br />INumeric&lt;N&gt;</td>
    <td>Provides a definition for custom numeric types and allows them to be used interchangeably with generics.</td>
  </tr>
  <tr>
    <td id="mathn"><sub><em>static class</em></sub><br />Math&lt;N&gt;</td>
    <td>Provides equivalent methods to <a href="https://docs.microsoft.com/en-us/dotnet/api/system.math">Math</a>, e.g. <code>Log(N)</code>, <code>Acosh(N)</code> and <code>Round(N, int)</code>.</td>
  </tr>
  <tr>
    <td id="bitconvertern"><sub><em>static class</em></sub><br />BitConverter&lt;N&gt;</td>
    <td>Provides equivalent methods to <a href="https://docs.microsoft.com/en-us/dotnet/api/system.bitconverter">BitConverter</a>, supporting conversion to and from byte arrays.</td>
  </tr>
  <tr>
    <td id="convertn"><sub><em>static class</em></sub><br />Convert&lt;N&gt;</td>
    <td>Provides equivalent methods to <a href="https://docs.microsoft.com/en-us/dotnet/api/system.convert">Convert</a>, supporting conversion to and from built-in numeric types.</td>
  </tr>
  <tr>
    <td id="castn"><sub><em>static class</em></sub><br />Cast&lt;N&gt;</td>
    <td>Provides access to numeric conversion operators (casts) from within a generic context.</td>
  </tr>
  <tr>
    <td id="castn"><sub><em>static class</em></sub><br />Clamp&lt;N&gt;</td>
    <td>Allows conversion to and from the built-in numeric types whilst preventing overflow by clamping to the <code>MinValue</code> and <code>MaxValue</code> of the target type.</td>
  </tr>
  <tr>
    <td id="stringformattern"><sub><em>static class</em></sub><br />StringParser&lt;N&gt;</td>
    <td>Provides string parsing methods with support for <a href="https://docs.microsoft.com/en-us/dotnet/api/system.globalization.numberstyles">NumberStyles</a> and <a href="https://docs.microsoft.com/en-us/dotnet/api/system.iformatprovider">IFormatProvider</a>.</td>
  </tr>
  <tr>
    <td id="castn"><sub><em>readonly struct</em></sub><br />Unit&lt;N&gt;</td>
    <td>A wrapper for numeric types the clamps values between -1 and 1 (or 0 and 1 when unsigned) with extensive interface and operator support.</td>
  </tr>
  <tr>
    <td id="castn"><sub><em>readonly struct</em></sub><br />Vector2&lt;N&gt;</td>
    <td>A collection of two numeric values, <code>X</code> and <code>Y</code> with extensive interface and operator support.</td>
  </tr>
  <tr>
    <td id="castn"><sub><em>readonly struct</em></sub><br />Vector3&lt;N&gt;</td>
    <td>A collection of three numeric values, <code>X</code>, <code>Y</code> and <code>Z</code> with extensive interface and operator support.</td>
  </tr>
  <tr>
    <td id="fix64"><sub><em>readonly struct</em></sub><br /><code>fix64</code>,<br /><code>ufix64</code></td>
    <td><a href="https://en.wikipedia.org/wiki/Fixed-point_arithmetic">Fixed-point</a> numeric types with 6 digits of precision. Supporting a range of values from ±1.0 x 10<sup>−6</sup> to ±9.2 x 10<sup>12</sup> (or 1.0 x 10<sup>−6</sup> to 1.8 x 10<sup>13</sup> when unsigned). Represented internally by 64-bit integers.</td>
  </tr>
  <tr>
    <td id="wrappers"><sub><em>readonly struct</em></sub><br />
      <code>xbyte</code>, <code>xsbyte</code>,<br />
      <code>xshort</code>, <code>xushort</code>,<br />
      <code>xint</code>, <code>xuint</code>,<br />
      <code>xlong</code>, <code>xulong</code>,<br />
      <code>xfloat</code>, <code>xdouble</code>,<br />
      <code>xdecimal</code>
    </td>
    <td>Wrappers for the <a href="https://docs.microsoft.com/en-us/dotnet/standard/numerics">built-in numeric types</a> with identical behaviour, allowing them to be used interchangeably with generics.</td>
  </tr>
</table>

### Other features

<table>
  <tr>
    <th>Feature</th>
    <th>Description</th>
  </tr>
  <tr>
    <td>Overloaded operators</td>
    <td>
      <p>All the provided numeric types have a full suite of overloaded operators, including:
      <ul>
        <li><a href="https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/operators/equality-operators">Equality operators</a> <code>==</code> and  <code>!=</code></li>
        <li><a href="https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/operators/equality-operators">Comparison operators</a> <code>&lt;</code>, <code>&gt;</code>, <code>&lt;=</code> and <code>&gt;=</code></li>
        <li><a href="https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/operators/arithmetic-operators">Arithmetic operators</a> <code>++</code>, <code>--</code>, <code>+</code> (plus), <code>-</code> (minus), <code>*</code>, <code>/</code>, <code>%</code>, <code>+</code> and <code>-</code></li>
        <li><a href="https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/operators/bitwise-and-shift-operators">Bitwise and shift operators</a> <code>~</code>, <code>&lt;&lt;</code>, <code>&gt;&gt;</code>, <code>&</code>, <code>|</code> and <code>^</code></li>
        <li><a href="https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/operators/user-defined-conversion-operators">Conversion operators</a> for all the built-in numeric types</li>
      </ul>
  </p>
   <p>
<a href="#inumericn">INumeric&lt;N&gt;</a> defines overloads for <code>&lt;</code>, <code>&gt;</code>, <code>&lt;=</code>, <code>&gt;=</code>, <code>++</code>, <code>--</code>, <code>+</code> (plus), <code>-</code> (minus), <code>*</code>, <code>/</code>, <code>%</code>, <code>+</code>, <code>-</code>, <code>~</code>, <code>&lt;&lt;</code>, <code>&gt;&gt;</code>, <code>&</code>, <code>|</code> and <code>^</code>, allowing for limited expressions in a generic context (note that equality and conversion operators are not supported on interfaces).
  </p>
  <p> <em>Note: The bitwise and shift operators are overloaded for non-integral types. These operators perform the correct bitwise operations, but are unlikely to produce useful results.</em></p>
      </td>
    </tr>
   <tr>
<td> String formatting </td>
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
<tr>
<td>Random generation</td>
  <td>Extension methods on <a href="https://docs.microsoft.com/en-us/dotnet/api/system.random">Random</a> provide randomly generated values. Values can be generated between two bounds or without bounds, as in the following code sample:</p>
  <pre lang="csharp"><code>var var1 = Random.NextNumeric&lt;xdouble&gt;();
var var2 = Random.NextNumeric&lt;xdouble&gt;(100, 120);

Console.WriteLine(var1); // outputs: -7.405808417991177E+115 (example)
Console.WriteLine(var2); // outputs: 102.85086051826445 (example)</code></pre>
  
  </td>
</tr>
<tr>
<td>Commonly-used abstractions</td> <td>All the provided numeric types implement <a href="">IComparable</a>, <a href="">IComparable&lt;T&gt;</a>. <a href="">IEquatable&lt;T&gt;</a>, <a href="https://docs.microsoft.com/en-us/dotnet/api/system.iformattable">IFormattable</a> and <a href="https://docs.microsoft.com/en-us/dotnet/api/system.runtime.serialization.iserializable">ISerializable</a>, override <code>Equals(object)</code>, <code>GetHashCode()</code> and <code>ToString()</code>, and have the <a href="https://docs.microsoft.com/en-us/dotnet/framework/debug-trace-profile/enhancing-debugging-with-the-debugger-display-attributes">DebuggerDisplay</a> attribute. </td>
</tr>
</table>

### Performance considerations

The numeric types provided by this package are structs that wrap built-in types and operators. Therefore they consume more memory and CPU time compared to using the built-in types alone.

If developing a performance-sensitive application, use a profiler to assess the impact.

Benchmarks are provided to facilitate comparison with the built-in types. To run the benchmarks, clone this repository then build and run *Jodo.Extensions.Numerics.Benchmarks.exe* in RELEASE mode.

Sample output can be seen below:
  

<details>
<summary><em>Jodo.Extensions.Numerics.Benchmarks - Results from 2022-06-03T21:30:27.6877090Z</em></summary>

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


<h2>Jodo.Extensions.CheckedNumerics</h2>
  
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

Benchmarks are provided to facilitate comparison with the built-in types. To run the benchmarks, clone this repository then build and run *Jodo.Extensions.CheckedNumerics.Benchmarks.exe* in RELEASE mode.

Sample output can be seen below:
<details>
  <summary><em>Jodo.Extensions.CheckedNumerics.Benchmarks - Results from 2022-05-11T18:11:17.8665440Z</em></summary>

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

<h2>Jodo.Extensions.Geometry</h2>

<mark>This package is a work in progress.</mark>

Provides geometric value types.

| CheckedGeometry type | Notes |
| - | - |
| AARectangle\<T\> | Axis-aligned rectangle |
| Rectangle\<T\> |  |
| Circle\<T\> |  |
| Angle\<T\> |  |

<h2>Jodo.Extensions.Collections</h2>

> <mark>This package is a work in progress.</mark>
