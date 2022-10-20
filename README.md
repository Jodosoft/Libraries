<br id="top" />
<p align="center"><img src="Banner.png" alt="Logo" height="96"/></p>
<h1 align="center">The Jodo Libraries</h1>

<p align="center">
  <a href="https://github.com/JosephJShort/Jodo/blob/main/LICENSE.md"><img alt="GitHub" src="https://img.shields.io/github/license/JosephJShort/Jodo?style=flat-square&color=005784&logo=github&no-cache"></a>
  <a href="https://www.nuget.org/packages?q=Jodo."><img alt="Nuget (with prereleases)" src="https://img.shields.io/nuget/vpre/Jodo.Primitives?label=version&style=flat-square&color=005784&logo=nuget&no-cache"></a>
</p>

## Contents

1\. [Introduction](#1-introduction)

2\. [About the project](#2-about-the-project)<br />
&nbsp;&nbsp;&nbsp;&nbsp;2.1. [Design goals](#21-design-goals)<br />
&nbsp;&nbsp;&nbsp;&nbsp;2.2. [Roadmap](#22-roadmap)<br />
&nbsp;&nbsp;&nbsp;&nbsp;2.3. [Contributing](#23-contributing)<br />
&nbsp;&nbsp;&nbsp;&nbsp;2.4. [Releases](#24-releases)<br />
&nbsp;&nbsp;&nbsp;&nbsp;2.5. [Documentation](#25-documentation)

3\. [Jodo.Numerics](#3-jodonumerics)<br />
&nbsp;&nbsp;&nbsp;&nbsp;3.1. [Random extensions](#31-random-extensions)<br />
&nbsp;&nbsp;&nbsp;&nbsp;3.2. [Fixed-point numbers](#32-fixed-point-numbers)<br />
&nbsp;&nbsp;&nbsp;&nbsp;3.3. [Clamped numbers](#33-clamped-numbers)<br />
&nbsp;&nbsp;&nbsp;&nbsp;3.4. [Structures](#34-structures)<br />
&nbsp;&nbsp;&nbsp;&nbsp;3.5. [Generic numbers](#35-generic-numbers)<br />
&nbsp;&nbsp;&nbsp;&nbsp;3.6. [Performance considerations](37-performance-considerations)

4\. [Jodo.Geometry](#4-jodogeometry)

5\. [Jodo.Collections](#5-jodocollections)

<br />
<p align="center">* * *</p>
<br />

## 1. Introduction

Welcome to Jodo, a project to make simple, reliable .NET libraries covering numerics, geometry and data structures.

This document describes the goals and principals of the project and the features of each library.

[\[Back to top\]](#top)

<br />
<p align="center">* * *</p>
<br />

## 2. About the project

The Jodo libraries started as a collection of reusable types from the personal projects of [@JosephJShort](https://github.com/JosephJShort). The types were revamped to make them fit for public consumption.

This section describes the design goals, roadmap, and other details of the project.

[\[Back to top\]](#top)

## 2.1. Design Goals

The table below summarises the design goals of the project.

<table>
  <tr>
    <th>Item</th>
    <th>Description</th>
  </tr>
  <tr>
    <td>Simplicity</td>
    <td> 
      <p>
        The Jodo libraries are designed to provide simple data structures and algorithms to use as the building blocks for more comlpex applications.
      </p>
      <p>
        As a rule of thumb, nothing within the libraries requires configuration or dependency injection to use. A competent developer should be able to use the libraries intuitively, without needing to refer to documentation.
      </p>
      <p>
        The libraries adhere to the <a href="https://docs.microsoft.com/en-us/dotnet/standard/design-guidelines/">.NET Framework Design Guidelines</a> to ensure ease-of-use and consistency with the .NET API.
      </p>
    </td>
  </tr>
  <tr>
    <td>Reliability</td>
    <td>
      <p>
        Foremost, the Jodo libraries are designed to be dependable. Unit tests, benchmarks,
        and continuous integration tools are used to ensure they remain fit for purpose.</p>
      <p>
        Tests are designed to cover boundary conditions, edge-cases, and error scenarios as well as happy paths.
        Code coverage is used, but is not considered a definitive metric of adequate testing.
        The code coverage target is 90%.</p>
      <p>
        During pull request validation, tests are compiled against multiple .NET targets and run on multiple operating systems.
        This helps to ensure that the libraries continue to behave as intended and are unaffected by .NET implementation details.
        Currently, the list includes
        .NET Framework 4.8 (<code>net48</code>), .NET Core 2.1 (<code>netcoreapp2.1</code>),
        .NET 5 (<code>net5.0</code>), .NET 6 (<code>net6.0</code>), Windows, Ubuntu, macOS.
      </p>
      <p>Click on the shields below to see the latest test results and coverage.</p>
      <p>
        <a href="https://dev.azure.com/JosephJShort/Jodo/_build?definitionId=1"><img alt="Azure DevOps tests" src="https://img.shields.io/azure-devops/tests/JosephJShort/Jodo/1/main?logo=azuredevops&style=flat-square&no-cache"></a>
        <a href="https://sonarcloud.io/summary/overall?id=JosephJShort_Jodo"><img alt="Sonar Coverage" src="https://img.shields.io/sonar/coverage/JosephJShort_Jodo/main?logo=sonarcloud&server=https%3A%2F%2Fsonarcloud.io&style=flat-square&no-cache"></a>
      </p>
    </td>
  </tr>
  <tr>
    <td>Compatibility</td>
    <td>     
      <p>
        The libraries are designed to maximise compatibility. The .NET Standard 2.0 (<code>netstandard2.0</code>) and .NET Framework 4.6 (<code>net461</code>) targets are used in order to <a href="https://docs.microsoft.com/en-us/dotnet/standard/library-guidance/cross-platform-targeting">maximize cross-platform support</a>.
        Additional targets such as .NET Standard 2.1 (<code>netstandard2.1</code>) are used to incorporate newer language features like <a href="https://docs.microsoft.com/en-gb/dotnet/csharp/whats-new/csharp-8#default-interface-methods">default interface methods</a>.
      </p>
      <p>
        Publicly exposed types are marked as <a href="https://docs.microsoft.com/en-us/dotnet/standard/language-independence">CLS compliant</a>
        wherever possible, and language-agnostic naming conventions are used. This ensures that
        the libraries can be used just as easily in F# and Visual Basic as they can in C#.
      </p>
      <p>
        Care is taken to avoid name clashes with commonly-used types, either from the .NET API or from popular NuGet packages.
      </p>
    </td>
  </tr>
  <tr>
    <td>Maintainability</td>
    <td>
      <p>
        The source code of the Jodo libraries is designed to be easy to understand and change.
      </p>
      <p>
        Two static analysis tools, <a href="https://sonarcloud.io/summary/overall?id=JosephJShort_Jodo">SonarCloud</a>
        and <a href="https://www.codefactor.io/repository/github/josephjshort/jodo/overview/main">CodeFactor</a>, are used
        to detect code smells, such as unused variables or overly complex functions.
      </p>
      <p>
      <a href="https://docs.microsoft.com/en-us/visualstudio/code-quality/roslyn-analyzers-overview?view=vs-2022">Rosyln analysers</a> are used with maximum rule-severity. Rules are only suppressed in exceptional circumstances, and suppression tags are always accompanied by a justification message.
      </p>
        <a href="https://sonarcloud.io/summary/overall?id=JosephJShort_Jodo"><img alt="Sonar Violations (long format)" src="https://img.shields.io/sonar/violations/JosephJShort_Jodo/main?label=smells&logo=sonarcloud&server=https%3A%2F%2Fsonarcloud.io&style=flat-square&no-cache" /></a>
        <a href="https://www.codefactor.io/repository/github/josephjshort/jodo/overview/main"><img alt="CodeFactor Grade" src="https://img.shields.io/codefactor/grade/github/JosephJShort/Jodo/main?label=quality&logo=codefactor&style=flat-square&no-cache"></a></p>
    </td>
  </tr>
</table>

[\[Back to top\]](#top)

## 2.2. Roadmap

The Jodo libraries are under active development, and are kept up to date with advancements in the .NET SDK. A list of upcoming changes can be seen at https://github.com/JosephJShort/Jodo/issues. The following table summarises the overall goals for each version.

<table>
  <tr>
    <th>Version</th>
    <th>Goals</th>
  </tr>
  <tr>
    <td><code>1.0.0</code></td>
    <td>
      <ul>
        <li>Create the initial release of Jodo.Numerics</li>
        <li>Add cross-platform support</li>
        <li>Reach a very high level of test coverage</li>
        <li>Establish code quality rules</li>
        <li>Create benchmarks</li>
      </ul>
      <a href="https://github.com/JosephJShort/Jodo/milestone/3"><img alt="GitHub milestone" src="https://img.shields.io/github/milestones/progress/JosephJShort/Jodo/3?label=closed%20issues&style=flat-square&logo=github&no-cache"></a>
      <a href="https://www.nuget.org/packages?q=Jodo."><img src="https://img.shields.io/badge/package-available-green?logo=nuget&no-cache"></a>
    </td>
  </tr>
  <tr>
    <td><code>1.1.0</code></td>
    <td>
      <ul>
        <li>Create the initial release of Jodo.Geometry</li>
      </ul>
      <a href="https://github.com/JosephJShort/Jodo/milestone/4"><img alt="GitHub milestone" src="https://img.shields.io/github/milestones/progress/JosephJShort/Jodo/4?label=closed%20issues&style=flat-square&logo=github&no-cache"></a>
      <a href="https://www.nuget.org/packages?q=Jodo."><img src="https://img.shields.io/badge/package-unavailable-red?logo=nuget&no-cache"></a>
    </td>
  </tr>
</table>

[\[Back to top\]](#top)

## 2.3. Contributing

Community contributions are welcome at https://github.com/JosephJShort/Jodo (the home of this repository). Contributors are requested to adhere to the <a href="CODE-OF-CONDUCT.md">code of conduct</a>.

This work is licensed under the <a href="LICENSE.md">MIT License</a>.

<p>
  <a href="https://github.com/JosephJShort/Jodo/blob/main/LICENSE.md"><img alt="GitHub" src="https://img.shields.io/github/license/JosephJShort/Jodo?style=flat-square&color=005784&logo=github"></a>
  <a href="https://github.com/JosephJShort/Jodo/stargazers"><img alt="GitHub issues" src="https://img.shields.io/github/stars/JosephJShort/Jodo?logo=github&style=flat-square&color=005784&no-cache"></a>
</p>

[\[Back to top\]](#top)

## 2.4. Releases

<p>Builds of this project are available as NuGet packages on <a href="https://www.nuget.org/packages?q=Jodo.">NuGet.org</a> (for help, see: <a href="https://docs.microsoft.com/en-us/nuget/quickstart/install-and-use-a-package-in-visual-studio">"Quickstart: Install and use a package"</a>).</p>
<p>Binaries are available on GitHub.com at <a href="https://github.com/JosephJShort/Jodo/releases">https://github.com/JosephJShort/Jodo/releases</a>.</p>
<p><a href="https://semver.org/">Semantic Versioning</a> is used to ensure that version numbers convey the presence of breaking changes.</p>
<p>The libraries can also be built from the source code in this repository using the appropriate <a href="https://dotnet.microsoft.com/en-us/download/visual-studio-sdks">.NET SDKs</a> and any IDE that supports .NET, such as <a href="https://visualstudio.microsoft.com/vs/community/">Visual Studio Community Edition</a>.</p>
<p>
  <a href="https://www.nuget.org/packages?q=Jodo."><img alt="Nuget (with prereleases)" src="https://img.shields.io/nuget/vpre/Jodo.Primitives?label=version&style=flat-square&color=005784&logo=nuget&no-cache"></a>
  <a href="[https://www.nuget.org/packages?q=Jodo.](https://github.com/JosephJShort/Jodo/releases)"><img alt="GitHub release (latest SemVer including pre-releases)" src="https://img.shields.io/github/v/release/JosephJShort/Jodo?include_prereleases&logo=github&style=flat-square&color=005784&no-cache"></a>
</p>

[\[Back to top\]](#top)

## 2.5. Documentation

<p>Work-in-progress API documentation is available at https://jodo.dev.</p>
<p>
  <a href="https://jodo.dev"><img alt="Documentation" src="https://img.shields.io/badge/documentation-passing-005784?style=flat-square&color=005784"></a>
</p>

[\[Back to top\]](#top)

<br />
<p align="center">* * *</p>
<br />

## 3. Jodo.Numerics

Provides numeric utilities, custom number types, and a generic interface for defining numbers. This section describes the features of the library.

<a href="https://www.nuget.org/packages/Jodo.Numerics/"><img alt="Nuget (with prereleases)" src="https://img.shields.io/nuget/vpre/Jodo.Numerics?label=version&style=flat-square&color=005784&logo=nuget&no-cache"></a>
  
[\[Back to top\]](#top)

## 3.1. Random extensions

Extension methods for <a href="https://docs.microsoft.com/en-us/dotnet/api/system.random">System.Random</a> provide random number generation for every built-in number type, as well as types that implement <a href="#inumericn">INumeric&lt;TSelf&gt;</a>. Overloads allow for increased flexibility with bounds, such as inclusive upper bounds and bounds specified in any order, as in the following example:

```csharp
using Jodo.Numerics;
using System;

var value1 = new Random().NextDouble(double.MinValue, double.MaxValue); // Returns any finite double.
var value2 = new Random().NextUInt64(200, 100, Generation.Extended); // Returns a ulong between 100 and 200 (inclusive).
```

[\[Back to top\]](#top)

## 3.2. Fixed-point numbers

Compared to floating-point, <a href="https://en.wikipedia.org/wiki/Fixed-point_arithmetic">fixed-point</a> numbers maintain a constant degree of precision regardless of magnitude. This can be useful in situations where <a href="https://en.wikipedia.org/wiki/MIM-104_Patriot#Failure_at_Dhahran">precision remains important whilst numbers grow</a>. As a trade-off, fixed-point numbers have a much lower maximum magnitude than floating-point numbers of the same bit size.

<a href="#fix64">Fix64</a> and <a href="#ufix64">UFix64</a> are custom number types that implement fixed-point arithmetic.

<pre lang="csharp"><code>using Jodo.Numerics;
using System;

Fix64 fixedPoint = (Fix64)8000000000000 + MathN.PI&lt;Fix64&gt;();
double floatingPoint = 8000000000000 + Math.PI;

Console.WriteLine(fixedPoint); // output: 8000000000003.141592
Console.WriteLine(floatingPoint); // output: 8000000000003.142

Console.WriteLine(Fix64.MaxValue); // output: 9223372036854.775807
Console.WriteLine(double.MaxValue); // output: 1.7976931348623157E+308</code></pre>

The table belows summarises the capabilities of these types.

<table>
  <tr>
    <th>Type</th>
    <th>Description</th>
  </tr>
  <tr />
  <tr>
    <td id="fix64"><sub><em>readonly struct</em></sub><br />Fix64</td>
    <td>
      <p>Signed fixed-point number type with 6 decimal digits of precision, represented internally by a 64-bit integer.</p>
      <p>Supports a range of values from ±1.0 x 10<sup>−6</sup> to ±9.2 x 10<sup>12</sup>.</p>
      <p>Supports a full range of operators, mathematical functions, and coversions via its implmentation of <a href="#35-generic-numbers">INumeric&lt;TSelf&gt;</a>.</p>
    </td>
  </tr>
  <tr />
  <tr>
    <td id="ufix64"><sub><em>readonly struct</em></sub><br />UFix64</td>
    <td>
      <p>Unsigned fixed-point number type with 6 decimal digits of precision, represented internally by a 64-bit integer.</p>
      <p>Supports a range of values from 1.0 x 10<sup>−6</sup> to 1.8 x 10<sup>13</sup>.</p>
      <p>Supports a full range of operators, mathematical functions, and coversions via its implmentation of <a href="#35-generic-numbers">INumeric&lt;TSelf&gt;</a>.</p>
    </td>
  </tr>
  <tr />
  <tr>
    <td id="fix64"><sub><em>static class</em></sub><br />Scaled</td>
    <td>
      <p>Provides static methods for performing arithmetic and string conversion on integers with an imaginary decimal point. Used to implement <code>Fix64</code> and <code>UFix64</code>.</p>
    </td>
  </tr>
</table>

[\[Back to top\]](#top)

## 3.3 Clamped numbers
  
Clamped numbers have built-in protection from overflow. Operations that would overflow instead revert to `MinValue` or `MaxValue` for the given number type. This is useful for preventing unexpected negative/positive, infinite or `NaN` values from entering a system.
        
Usage is the same as with built-in numeric types but yields different results in cases of overflow.

```csharp
var i = Int32M.MaxValue + 1;
Console.WriteLine(i);  // output: 2147483647

var f = (SingleM)4 / 0;
Console.WriteLine(f);  // output: 3.402823E+38
```

The table below summarises the clamped number types and utilities provided.

<table>
	<tr>
		<th>Type</th>
		<th>Description</th>
	</tr>
	<tr />
	<tr>
		<td>
			<sub><em>readonly struct</em></sub><br />
			ByteM, SByteM,<br />Int16M, UInt16M,<br />
			Int32M, UInt32M,<br />Int64M, UInt64M,<br />
			DecimalM
		</td>
		<td>
			Operations that would overflow instead return
			<code>MinValue</code> or <code>MaxValue</code>
			depending on the direction of the overflow.
			Division by zero does NOT throw a
			<a href="https://docs.microsoft.com/en-us/dotnet/api/system.dividebyzeroexception">DivideByZeroException</a>
			but returns <code>MaxValue</code>.
		</td>
	</tr>
	<tr />
	<tr>
		<td>
			<sub><em>readonly struct</em></sub><br />
			SingleM,<br />DoubleM
		</td>
		<td>
			Operations that would overflow do NOT return
			<code>NegativeInfinity</code> or <code>PositiveInfinity</code>
			but return <code>MinValue</code> or <code>MaxValue</code>
			respectively. Division by zero does NOT return
			<code>NegativeInfinity</code>, <code>PositiveInfinity</code>
			or <code>NaN</code> but returns <code>MaxValue</code>.
			Operations that would return <code>NaN</code> instead return 0.
			(It is not possible for values to be <code>NegativeInfinity</code>,
			<code>PositiveInfinity</code> or <code>NaN</code>).
		</td>
	</tr>
	<tr />
	<tr>
		<td>
			<sub><em>readonly struct</em></sub><br />
			Fix64M,<br />UFix64M
		</td>
		<td>
			Variants of <a href="#32-fixed-point-numbers">Fix64</a>
			and <a href="#32-fixed-point-numbers">UFix64</a>.
			Operations that would overflow instead return <code>MinValue</code>
			or <code>MaxValue</code> depending on the direction of the
			overflow. Division by zero does NOT throw a
			<a href="https://docs.microsoft.com/en-us/dotnet/api/system.dividebyzeroexception">DivideByZeroException</a>
			but returns <code>MaxValue</code>.
		</td>
	</tr>
	<tr />
	<tr>
		<td>
			<sub><em>static class</em></sub><br />
			ClampedArithmetic
		</td>
		<td>
			Provides clamped arithmetic methods for the
			built-in numeric types.
		</td>
	</tr>
	<tr />
	<tr>
		<td>
			<sub><em>static class</em></sub><br />
			ClampedConvert
		</td>
		<td>
			Provides clamped conversion methods equivalent to
			<a href="https://docs.microsoft.com/en-us/dotnet/api/system.convert">Convert</a>.
		</td>
	</tr>
</table>

[\[Back to top\]](#top)

## 3.4. Structures

Numeric structures, such as vectors, are provided for use in mathematical applications. These structures are generic on number type, supporting any implementation of <a href="#35-generic-numbers">INumeric&lt;TSelf&gt;</a>. The table below sumarises the types available.

<table>
  <tr>
    <th>Type</th>
    <th>Description</th>
  </tr>
  <tr />
  <tr>
    <td id="vector2n"><sub><em>readonly struct</em></sub><br />Vector2&lt;TNumeric&gt;</td>
    <td>A collection of two numeric values, <code>X</code> and <code>Y</code>, with extensive interface and operator support.</td>
  </tr>
  <tr />
  <tr>
    <td id="vector3n"><sub><em>readonly struct</em></sub><br />Vector3&lt;TNumeric&gt;</td>
    <td>A collection of three numeric values, <code>X</code>, <code>Y</code> and <code>Z</code>, with extensive interface and operator support.</td>
  </tr>
  <tr />
  <tr>
    <td id="unitn"><sub><em>readonly struct</em></sub><br />Unit&lt;TNumeric&gt;</td>
    <td>A wrapper for numeric types that clamps values between -1 and 1 (or 0 and 1 when unsigned).</td>
  </tr>
</table>

[\[Back to top\]](#top)

## 3.5. Generic numbers

The INumeric&lt;TSelf&gt; interface defines a contract for number types, allowing them to be used in a generic context.

Overloaded operators, and utility class such as `MathN` and `ConvertN` allow for these types to be used seemlessly in place of the built-in number types.

<pre lang="csharp"><code>using Jodo.Numerics;
using System;

var number = (MyNumberType)100;
var result = number * 2 + 1;</code></pre>

The table below gives a full list of features supported by number types that implement INumeric&lt;N&gt;.

<table>
  <tr>
    <th>Feature</th>
    <th>Description</th>
  </tr>
  <tr />
  <tr>
    <td id="mathn"><sub><em>static class</em></sub><br />MathN</td>
    <td>
      <p>Provides equivalent methods to <a href="https://docs.microsoft.com/en-us/dotnet/api/system.math">System.Math</a> for types that implement <a href="#inumericn">INumeric&lt;N&gt;</a>, e.g. <code>Log(N)</code>, <code>Acosh(N)</code> and <code>Round(N, int)</code>.</p>
      <p>This is demonstrated by the following code sample:</p>
    <pre lang="csharp"><code>var result = MathN.Log10(1000 * MathN.PI&lt;Fix64&gt;());
Console.WriteLine(result); // output: 3.497149</code></pre>
    </td>
  </tr>
  <tr />
  <tr>
    <td id="bitconvertern"><sub><em>static class</em></sub><br />BitConverterN</td>
    <td>
      <p>Provides equivalent methods to <a href="https://docs.microsoft.com/en-us/dotnet/api/system.bitconverter">System.BitConverter</a> for types that implement <a href="#inumericn">INumeric&lt;N&gt;</a>, allowing conversion to and from byte arrays.
      </p>
<pre lang="csharp"><code>byte[] result = BitConverterN.GetBytes((UFix64)256.512);
Console.WriteLine(BitConverter.ToString(result)); // output: 00-10-4A-0F-00-00-00-00</code></pre>
    </td>
  </tr>
  <tr />
  <tr>
    <td id="convertn"><sub><em>static class</em></sub><br />ConvertN</td>
    <td>
      <p>
        Provides equivalent methods to
        <a href="https://docs.microsoft.com/en-us/dotnet/api/system.convert">System.Convert</a>
        for types that implement <a href="#inumericn">INumeric&lt;N&gt;</a>
        (e.g. <code>ToBoolean(N)</code> and <code>ToDecimal(N)</code>).
        Overloads are provided to support alternative modes of conversion,
        e.g. <code>Default</code>, <code>Cast</code> and <code>Clamp</code>.
      </p>
      <pre lang="csharp"><code>var defaultResult = ConvertN.ToNumeric&lt;ByteN&gt;(199.956, Conversion.Default);
var castResult = ConvertN.ToNumeric&lt;ByteN&gt;(199.956, Conversion.Cast);

Console.WriteLine(defaultResult); // output: 200
Console.WriteLine(castResult); // output: 199</code></pre>
    </td>
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
  <tr />
  <tr>
    <td id="wrappers"><sub><em>readonly struct</em></sub><br />
      ByteN, SByteN,<br />
      Int16N, UInt16N,<br />
      Int32N, UInt32N,<br />
      Int64N, UInt64N,<br />
      SingleN, DoubleN,<br />
      DecimalN
    </td>
    <td>Wrappers for the <a href="https://docs.microsoft.com/en-us/dotnet/standard/numerics">built-in numeric types</a> that implement <a href="#inumericn">INumeric&lt;N&gt;</a>, allowing the built-in numeric types to be used in a generic context.</td>
  </tr>
</table>

[\[Back to top\]](#top)

## 3.6 Performance considerations

The number types provided by this library are structs that wrap built-in types and operators. Therefore they consume additional memory and CPU time compared to using the built-in types alone.

Additionally, the number types in the *Jodo.Numerics.Clamped* namespace make use of the [checked](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/checked) keyword for conversion and arithmetic. Therefore increases CPU time compared to using unchecked, especially in cases of overflow.

If developing a performance-sensitive application, use a profiler to assess the impact of introducing these types. Generally speaking, the impact is likely to be acceptable unless CPU-bound arithmetic is already on the hot path for the given application (e.g. in machine learning or 3D physics simulation).

Benchmarks are provided to facilitate comparison with the built-in types. To run the benchmarks, clone this repository then build and run *Jodo.Numerics.Benchmarks.exe* in RELEASE mode.

Sample output can be seen below:

<details>
<summary><em>Jodo.Numerics.Benchmarks - Results from 2022-09-28 07:58:50Z</em></summary>

 <br />
  
> * **Processor:** 11th Gen Intel(R) Core(TM) i7-11800H @ 2.30GHz
> * **Architecture:** x64-based processor
> * **.NET Version:** .NET 5.0.17
> * **Architecture:** X64
> * **OS:** win10-x64
> * **Seconds per Benchmark:** 60.0

| Subjects "(1)\_Versus\_(2)" | Operations Per Second (1) | Operations Per Second (2) | Average Time (1) | Average Time (2) | Relative Speed (1) | Relative Speed (2) |
| --- | --- | --- | --- | --- | --- | --- |
| Fix64Logarithm_Versus_DoubleLogarithm | 7.789E+06 | 5.183E+07 | *<1μs* | *<1μs* | **0.15** | 6.65 |
| Fix64Rounding_Versus_DoubleRounding | 3.846E+07 | 3.637E+07 | *<1μs* | *<1μs* | 1.06 | 0.95 |
| Fix64StringParsing_Versus_DoubleStringParsing | 1.842E+07 | 1.973E+07 | *<1μs* | *<1μs* | 0.93 | 1.07 |
| Fix64Random_Versus_DoubleRandom | 2.4E+07 | 3.995E+07 | *<1μs* | *<1μs* | **0.60** | 1.66 |
| Fix64ToByteArray_Versus_DoubleToByteArray | 4.831E+07 | 4.876E+07 | *<1μs* | *<1μs* | 0.99 | 1.01 |
| Fix64FromByteArray_Versus_DoubleFromByteArray | 5.29E+07 | 5.225E+07 | *<1μs* | *<1μs* | 1.01 | 0.99 |
| Int32NArithmetic_Versus_Int32Arithmetic | 5.03E+07 | 5.282E+07 | *<1μs* | *<1μs* | 0.95 | 1.05 |
| Int32MArithmetic_Versus_Int32Arithmetic | 4.425E+07 | 5.215E+07 | *<1μs* | *<1μs* | **0.85** | 1.18 |
| SingleNArithmetic_Versus_SingleArithmetic | 4.122E+07 | 5.623E+07 | *<1μs* | *<1μs* | **0.73** | 1.36 |
| SingleMArithmetic_Versus_SingleArithmetic | 3.418E+07 | 5.634E+07 | *<1μs* | *<1μs* | **0.61** | 1.65 |
| DoubleNArithmetic_Versus_DoubleArithmetic | 4.129E+07 | 5.565E+07 | *<1μs* | *<1μs* | **0.74** | 1.35 |
| DoubleMArithmetic_Versus_DoubleArithmetic | 3.402E+07 | 5.527E+07 | *<1μs* | *<1μs* | **0.62** | 1.62 |
| DoubleNDivision_Versus_DoubleDivision | 4.833E+07 | 5.392E+07 | *<1μs* | *<1μs* | **0.90** | 1.12 |
| DoubleNLogarithm_Versus_DoubleLogarithm | 4.913E+07 | 5.244E+07 | *<1μs* | *<1μs* | 0.94 | 1.07 |
| DoubleNRounding_Versus_DoubleRounding | 3.396E+07 | 3.597E+07 | *<1μs* | *<1μs* | 0.94 | 1.06 |

</details>

[\[Back to top\]](#top)

<br />
<p align="center">* * *</p>
<br />

## 4. Jodo.Geometry

> Coming soon (see section 2.2. "[Roadmap](#22-roadmap)")

[\[Back to top\]](#top)

<br />
<p align="center">* * *</p>
<br />

## 5. Jodo.Collections

> Coming soon (see section 2.2. "[Roadmap](#22-roadmap)")

[\[Back to top\]](#top)

