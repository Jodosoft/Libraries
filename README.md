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
  <a href="https://sonarcloud.io/summary/overall?id=JosephJShort_Jodo.Extensions"><img alt="Sonar Violations (long format)" src="https://img.shields.io/sonar/violations/JosephJShort_Jodo.Extensions/main?logo=sonarcloud&server=https%3A%2F%2Fsonarcloud.io&style=flat-square" /></a>
  <a href="https://sonarcloud.io/summary/overall?id=JosephJShort_Jodo.Extensions"><img alt="Sonar Coverage" src="https://img.shields.io/sonar/coverage/JosephJShort_Jodo.Extensions/main?logo=sonarcloud&server=https%3A%2F%2Fsonarcloud.io&style=flat-square"></a>
</p>

<h2>Jodo.Extensions.Numerics</h2>

Provides the <a href="#inumericn">INumeric&lt;N&gt;</a> interface and utilities for creating custom numeric types.

<a href="#inumericn">Fixed-point implementations</a> and <a href="#wrappers">wrappers for built-in types</a> are provided.

Usage is the same as with built-in numeric types. Familiar operations are provided by <a href="#mathn">Math&lt;N&gt;</a>, <a href="#convertn">Convert&lt;N&gt;</a>.

The following code example demonstrates usage:

```csharp
xint intValue = 2048;
xint shifted = intValue >> 3;

xfloat floatValue = 1.23e6f;
xfloat sqrt = Math<xfloat>.Sqrt(floatValue);

Console.WriteLine($"{intValue} -> {shifted}"); // outputs: 2048 -> 256

Console.WriteLine($"{floatValue:N1} -> {sqrt:N1}"); // outputs: "1,230,000.0 -> 1,109.1"
```

### Types

<table>
  <tr>
    <th>Type</th>
    <th>Description</th>
  </tr>
  <tr>
    <td id="inumericn">INumeric&lt;N&gt;</td>
    <td>Implemented by custom numeric types. Allows for numeric types to be used interchangeably in generic systems.</td>
  </tr>
  <tr>
    <td id="mathn">Math&lt;N&gt;<sup><a href="#footnote1">†</a></sup></td>
    <td>Provides equivalent static methods to <a href="https://docs.microsoft.com/en-us/dotnet/api/system.math">Math</a>, e.g. <code>N Log(N)</code>, <code>N Acosh(N)</code> and <code>N Round(N, int)</code>.</td>
  </tr>
  <tr>
    <td id="convertn">Convert&lt;N&gt;<sup><a href="#footnote1">†</a></sup></td>
    <td>Provides equivalent static methods to <a href="https://docs.microsoft.com/en-us/dotnet/api/system.convert">Convert</a>, allowing for conversion to and from built-in numeric types.</td>
  </tr>
  <tr>
    <td id="bitconvertern">BitConverter&lt;N&gt;<sup><a href="#footnote1">†</a></sup></td>
    <td>Provides equivalent static methods to <a href="https://docs.microsoft.com/en-us/dotnet/api/system.bitconverter">BitConverter</a>, allowing conversion to and from ReadOnlySpan&lt;byte&gt;.</td>
  </tr>
  <tr>
    <td id="stringformattern">StringParser&lt;N&gt;<sup><a href="#footnote1">†</a></sup></td>
    <td>Provides static string parsing and formatting methods.</td>
  </tr>
  <tr>
    <td id="fix64"><code>fix64</code>, <code>ufix64</code></td>
    <td><a href="https://en.wikipedia.org/wiki/Fixed-point_arithmetic">Fixed-point</a> numeric types with 6 digits of precision. Stores a range of values from ±1.0 x 10<sup>−6</sup> to ±9.2 x 10<sup>12</sup> (unsigned 1.0 x 10<sup>−6</sup> to 1.8 x 10<sup>13</sup>). Implemented using 8-byte integers.</td>
  </tr>
  <tr>
    <td id="wrappers">
      <code>xbyte</code>, <code>xsbyte</code>,<br />
      <code>xshort</code>, <code>xushort</code>,<br />
      <code>xint</code>, <code>xuint</code>,<br />
      <code>xlong</code>, <code>xulong</code>,<br />
      <code>xfloat</code>, <code>xdouble</code>,<br />
      <code>xdecimal</code>
    </td>
    <td>Wrappers for the <a href="https://docs.microsoft.com/en-us/dotnet/standard/numerics">built-in numeric types</a> with identical usage. Implicit conversions allow for easy transition to and from the built-in numeric types.</td>
  </tr>
</table>
<p id="footnote1"><sup>†</sup> Static class available for all types that implement <a href="#inumericn">INumeric&lt;N&gt;</a>.</p>

### Other features

| Feature | Notes |
| - | - |
| Overloaded operators | <ul><li>`==`, `!=`, `>`, `>=`, `<`, `<=`, `+`, `++`, `-`, `*`, `/` and `%` are overloaded by all the provided numeric types, allowing for use in expressions.</li><li>`&`, `\|`, `^`, `~`, `<<` and `>>` are overloaded by all the provided integral types.</li><li>Implicit conversions from built-in numeric types are provided, allowing use in expressions with numeric literals.</li><li><a href="#inumericn">INumeric&lt;N&gt;</a> defines overloads for `>`, `>=`, `<`, `<=`, `+`, `++`, `-`, `*`, `/`, `%`, `&`, `\|`, `^`, `~`, `<<` and `>>` operators, allowing for limited expressions in a generic context (note: equality and conversion operators are not supported on interfaces).</li></ul> |
| Formatting | <ul><li>All the provided numeric types implement [IFormattable](https://docs.microsoft.com/en-us/dotnet/api/system.iformattable) and can be used with [numeric format strings](https://docs.microsoft.com/en-us/dotnet/standard/base-types/standard-numeric-format-strings).</li></ul> |
| Random generation | <ul><li>An extension method for [Random](https://docs.microsoft.com/en-us/dotnet/api/system.random), `NextNumeric<N>`<sup><a href="#footnote1">†</a></sup>, provides randomly generated values.</li><li>Values can be generated between two bounds or without bounds.</li></ul> |
| Serialization | <ul><li>All the provided numeric types implement [ISerializable](https://docs.microsoft.com/en-us/dotnet/api/system.runtime.serialization.iserializable), have the [Serializable](https://docs.microsoft.com/en-us/dotnet/api/system.serializableattribute) attribute and a deserialization constructor.</li></ul> |

<p id="footnote2"><sup>†</sup> Available for all types that implement <a href="#inumericn">INumeric&lt;N&gt;</a>.</p>

### Performance considerations

The numeric types provided by this package are structs that wrap the built-in numeric types. Therefore they consume more CPU time and memory compared to using built-in numeric types alone.

If developing a performance-sensitive application, use a profiler to assess the impact.

Benchmarks are provided with this repository to facilitate comparison the built-in numeric types. To run the benchmarks, clone the repository then build and run `Jodo.Extensions.Numerics.Benchmarks` in RELEASE mode.

Sample output can be seen below:
  
*tbc*

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

The following table summarizes the types and their behaviour:

| Type | Description |
| --- | --- |
| `cint`<br />`ucint` | <ul><li>Operations that would overflow instead return `MinValue` or `MaxValue` depending on the direction of the overflow.</li><li>Division by zero does NOT throw a [DivideByZeroException](https://docs.microsoft.com/en-us/dotnet/api/system.dividebyzeroexception) but returns `MaxValue`.</li></ul> |
| `cfloat`<br />`cdouble` | <ul><li>Operations that would overflow do NOT return `NegativeInfinity` or `PositiveInfinity` but return `MinValue` or `MaxValue` respectively.</li><li>Division by zero does NOT return `NegativeInfinity`, `PositiveInfinity` or `NaN` but returns `MaxValue`.</li><li>It is not possible for values to be `NegativeInfinity`, `PositiveInfinity` or `NaN`.</li></ul> |
| `fix64`<br />`ufix64` | <ul><li>A fixed-precision number with a 40-bit integral part and a 24-bit mantissa.</li><li>Has a range of values from -549,755,813,888 to 549,755,813,888 for `fix64` and 0 to 1,099,511,693,312.004 for `ufix64`.</li><li>Useful in systems where high precision is required regardless of magnitude.</li></ul> |
| `CheckedArithmetic` | <ul><li>A static class that provides checked arithmetic methods for the built-in numeric types.</li></ul> |
| `CheckedConvert` | <ul><li>A static class, similar to [Convert](https://docs.microsoft.com/en-us/dotnet/api/system.convert), that provides checked conversion between the built-in numeric types.</li></ul> |

### Performance considerations

The numeric types provided by this package are structs that wrap values and operations provided by built-in numeric types. Therefore they may consume more CPU time and runtime memory compared to using built-in numeric types alone.
  
Additionally, the [checked](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/checked) keyword is used for conversion and arithmetic with these types. Therefore they use more CPU time compared to built-in numeric types, especially in cases of overflow.

If developing a performance-sensitive application, use a profiler to assess the impact on performance. As a rule of thumb the impact is likely to be acceptable in logical applications, but not in arithmetic-intesive applications, such as graphics or big-data.

Benchmarks are provided with this repository to facilitate comparison with the built-in numeric types. To run the benchmarks, clone the repository then build and run `Jodo.Extensions.CheckedNumerics.Benchmarks` in RELEASE mode.

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
    
<details>
  <summary><h2>Jodo.Extensions.Geometry</summary>

Provides geometric value types.

| CheckedGeometry type | Notes |
| - | - |
| AARectangle\<T\> | Axis-aligned rectangle |
| Rectangle\<T\> |  |
| Circle\<T\> |  |
| Angle\<T\> |  |
| Unit\<T\> |  |
| Vector2\<T\> |  |
| Vector3\<T\> |  |

</details>

<details>
  <summary><h2>Jodo.Extensions.Collections</summary>

</details>
