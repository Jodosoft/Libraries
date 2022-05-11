<p align="center"><img src="RepositoryBanner.png" alt="Logo" height="128"/></p>

<h1 align="center">Jodo.Extensions</h1>

<p align="center">
  <a href="https://github.com/JosephJShort/Jodo.Extensions/actions/workflows/tests.yml"><img src="https://github.com/JosephJShort/Jodo.Extensions/actions/workflows/tests.yml/badge.svg" alt="Test"/></a>
  <a href="https://github.com/JosephJShort/Jodo.Extensions/actions/workflows/codeql-analysis.yml"><img src="https://github.com/JosephJShort/Jodo.Extensions/actions/workflows/codeql-analysis.yml/badge.svg" alt="CodeQL"/></a>
</p>

<p align="center">C# extension libraries written in the style of the .NET SDK.</p>

> **Note:** This repository is a work in progress

<details>
  <summary><h2>Jodo.Extensions.Numerics</h2></summary>

Provides the interface `INumeric<N>` and accompanying utilities classes, allowing for the creation of numeric types that can used interchangeably with generics.

### Types

| Jodo Type | Description |
| - | - |
| `INumeric<N>` | <ul><li>To be implemented by user-defined numeric value types.</li><li>Allows for the creation numeric types that can used interchangeably with generics.</li></ul> |
| `Math<N>` | <ul><li>A static class that provides equivalent methods to [Math](https://docs.microsoft.com/en-us/dotnet/api/system.math), e.g. `T Log(T)`, `T Pow(T)` and `T Sqrt(T)`.</li><li>Available for all types that implement `INumeric<N>`.</ul> |
| `BitConverter<N>` | <ul><li>A static class that provides equivalent methods to [BitConverter](https://docs.microsoft.com/en-us/dotnet/api/system.bitconverter).</li><li>Allows conversion to and from `ReadOnlySpan<byte>`.</li><li>Available for all types that implement `INumeric<N>`.</li></ul> |
| `StringFormatter<N>` | <ul><li>A static class that provides string parsing and formatting methods.</li><li>Available for all types that implement `INumeric<N>` including user-defined types.</li></ul> |

### Other features

| Feature | Notes |
| - | - |
| Overloaded operators | <ul><li>`==`, `!=`, `>`, `>=`, `<`, `<=`, `+`, `++`, `-`, `*`, `/` and `%` are overloaded, allowing for use in expressions.</li><li>`&`, `\|`, `^`, `~`, `<<` and `>>` are overloaded for types based on integral primitives.</li><li>Implicit conversions from built-in numeric types are provided, allowing use in expressions with numeric literals.</li><li>The `INumeric<N>` interface defines overloads the `>`, `>=`, `<`, `<=`, `+`, `++`, `-`, `*`, `/` and `%` operators, allowing for limited expressions in a generic context (note: equality and conversion operators are not supported on interfaces).</li></ul> |
| Float conversion | <ul><li>A method on `INumeric<N>`, `float Approximate(float offset)`, provides easy conversion to floats for use in graphical applications.</li></ul> |
| Formattable | <ul><li>All the [numeric value types](#jodo-extensions-numerics) implement [IFormattable](https://docs.microsoft.com/en-us/dotnet/api/system.iformattable) and can be used with [standard numeric format strings](https://docs.microsoft.com/en-us/dotnet/standard/base-types/standard-numeric-format-strings).</li></ul> |
| Random generation | <ul><li>An extension method for [Random](https://docs.microsoft.com/en-us/dotnet/api/system.random), `NextNumeric<N>`, provides randomly generated values.</li><li>Values can be generated between two bounds or without bounds.</li><li>Available for all types that implement `INumeric<N>` including user-defined types.</li></ul> |
| Serialization | <ul><li>All the [numeric value types](#numeric-value-types) implement [ISerializable](https://docs.microsoft.com/en-us/dotnet/api/system.runtime.serialization.iserializable), have the [Serializable](https://docs.microsoft.com/en-us/dotnet/api/system.serializableattribute) attribute and a deserialization constructor.</li></ul> |
| _Miscellaneous_ | <ul><li>All numeric value types implement [IEquatable\<T\>](https://docs.microsoft.com/en-us/dotnet/api/system.iequatable-1), [IComparable\<T\>](https://docs.microsoft.com/en-us/dotnet/api/system.icomparable-1) and [IComparable](https://docs.microsoft.com/en-us/dotnet/api/system.icomparable), override `EqualTo(object)`, `GetHashCode()` and `ToString()` and have a [DebuggerDisplay](https://docs.microsoft.com/en-us/dotnet/api/system.diagnostics.debuggerdisplayattribute) attribute.</li></ul>

### Performance considerations

The numeric value types provided by this package are [readonly structs](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/struct#readonly-struct) that wrap built-in numeric types. Therefore they may consume more memory at runtime compared to using built-in numeric types alone.

If developing a performance-sensitive application, use a profiler to assess the impact on performance.

Benchmarks are provided with this repository to facilitate comparison the built-in numeric types. To run the benchmarks, clone the repository then build and run `Jodo.Extensions.Numerics.Benchmarks` in RELEASE mode.

Sample output can be seen below:
  
*tbc*
</details>

<details>
  <summary><h2>Jodo.Extensions.CheckedNumerics</summary>

Provides numeric value types that [INumeric\<N\>](#numeric-value-types) with built-in protection from overflow. Useful for preventing unexpected negative/positive, infinite or `NaN` values from entering a system.

### Numeric value types

> **Note:** These types increase CPU and memory usage compared to using built-in numeric types. See the [Performance considerations](#performance-considerations) section for more details.

The following table summarizes the types and their behaviour:

| Jodo Type | Corresponding CLR type | Difference in behaviour |
| - | - | - |
| `cint`<br />`ucint` | `int`<br />`uint` | <ul><li>Operations that would overflow instead return `MinValue` or `MaxValue` depending on the direction of the overflow.</li><li>Division by zero does NOT throw a [DivideByZeroException](https://docs.microsoft.com/en-us/dotnet/api/system.dividebyzeroexception) but returns `MaxValue`.</li></ul> |
| `cfloat`<br />`cdouble` | `float`<br />`double` | <ul><li>Operations that would overflow do NOT return `NegativeInfinity` or `PositiveInfinity` but return `MinValue` or `MaxValue` respectively.</li><li>Division by zero does NOT return `NegativeInfinity`, `PositiveInfinity` or `NaN` but returns `MaxValue`.</li><li>It is not possible for values to be `NegativeInfinity`, `PositiveInfinity` or `NaN`.</li></ul> |
| `fix64`<br />`ufix64` | _N/A_ | <ul><li>A fixed-precision number with a 40-bit integral part and a 24-bit mantissa.</li><li>Has a range of values from -549,755,813,888 to 549,755,813,888 for `fix64` and 0 to 1,099,511,693,312.004 for `ufix64`.</li><li>Useful in systems where high precision is required regardless of magnitude.</li></ul> |

Usage is the same as with built-in numeric types but yields different results as demonstrated by the following code example:
```csharp
var x1 = cint.MaxValue + 1;
Console.WriteLine(x1);  // output: 2147483647

var x2 = (cfloat)4 / 0;
Console.WriteLine(x2);  // output: 3.402823E+38
```

### Other types

| Jodo Type | Description |
| - | - |
| `CheckedArithmetic` | <ul><li>A static class that provides checked arithmetic methods for the built-in numeric types.</li></ul> |
| `CheckedConvert` | <ul><li>A static class, similar to [Convert](https://docs.microsoft.com/en-us/dotnet/api/system.convert), that provides checked conversion between the built-in numeric types.</li></ul> |

### Performance considerations

The numeric value types provided by this package are [readonly structs](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/struct#readonly-struct) that wrap built-in numeric types. Therefore they may consume more memory at runtime compared to using built-in numeric types alone.
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

  | Name | Baseline Ops Per Second | Baseline Time | Subject Ops Per Second | Subject Time | Observation |
  | --- | --- | --- | --- | --- | --- |
  | CInt_Negation_Vs_Int | 2.172E+08 | *<1μs* | 1.131E+08 | *<1μs* | 1.92x slower |
  | CInt_Division_Vs_Int | 3.417E+08 | *<1μs* | 1.112E+08 | *<1μs* | 3.074x slower |
  | CInt_ConversionToFloat_Vs_Int | 3.815E+08 | *<1μs* | 2.487E+08 | *<1μs* | 1.534x slower |
  | CInt_StringParsing_Vs_Int | 7.443E+07 | *<1μs* | 5.885E+07 | *<1μs* | 1.265x slower |
  | **CInt_MultiplicationOverflow_Vs_Int** | **3.725E+08** | ***<1μs*** | **1.453E+05** | **6.8μs** | **2563x slower** |

  </details>
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
