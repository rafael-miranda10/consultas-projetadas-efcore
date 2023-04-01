``` ini

BenchmarkDotNet=v0.13.4, OS=Windows 11 (10.0.22621.1105)
Intel Core i5-8300H CPU 2.30GHz (Coffee Lake), 1 CPU, 8 logical and 4 physical cores
.NET SDK=7.0.102
  [Host]     : .NET 6.0.13 (6.0.1322.58009), X64 RyuJIT AVX2 [AttachedDebugger]
  DefaultJob : .NET 6.0.13 (6.0.1322.58009), X64 RyuJIT AVX2


```
|                                        Method |     Mean |     Error |    StdDev |   Median |    Gen0 | Allocated |
|---------------------------------------------- |---------:|----------:|----------:|---------:|--------:|----------:|
|                              ConsultarAutores | 2.048 ms | 0.0403 ms | 0.0868 ms | 2.006 ms | 19.5313 |  85.73 KB |
|                          ConsultarAutoresLinq | 2.190 ms | 0.0370 ms | 0.0542 ms | 2.175 ms | 19.5313 |  90.26 KB |
|                     ConsultarAutoresProjetada | 2.011 ms | 0.0385 ms | 0.1049 ms | 1.976 ms | 19.5313 |  90.31 KB |
|                 ConsultarAutoresProjetadaLinq | 1.976 ms | 0.0353 ms | 0.0363 ms | 1.976 ms | 19.5313 |  87.44 KB |
|           ConsultarAutoresProjetadaAutoMapper | 2.056 ms | 0.0410 ms | 0.0799 ms | 2.032 ms | 19.5313 |  88.34 KB |
| ConsultarAutoresProjetadaAutoMapperEspecifico | 2.011 ms | 0.0393 ms | 0.0437 ms | 2.003 ms | 19.5313 |  86.51 KB |
