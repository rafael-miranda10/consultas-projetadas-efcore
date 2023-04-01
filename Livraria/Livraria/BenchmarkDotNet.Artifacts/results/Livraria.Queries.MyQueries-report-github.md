``` ini

BenchmarkDotNet=v0.13.4, OS=Windows 11 (10.0.22621.1265)
Intel Core i5-8300H CPU 2.30GHz (Coffee Lake), 1 CPU, 8 logical and 4 physical cores
.NET SDK=7.0.102
  [Host]     : .NET 6.0.13 (6.0.1322.58009), X64 RyuJIT AVX2
  DefaultJob : .NET 6.0.13 (6.0.1322.58009), X64 RyuJIT AVX2


```
|                                                Method |      Mean |    Error |   StdDev |    Median | Rank |      Gen0 |      Gen1 |     Gen2 | Allocated |
|------------------------------------------------------ |----------:|---------:|---------:|----------:|-----:|----------:|----------:|---------:|----------:|
|                                ConsultarAutoresEFCore | 119.34 ms | 2.326 ms | 6.087 ms | 118.07 ms |    5 | 4000.0000 | 1600.0000 | 600.0000 |  21.91 MB |
|                                  ConsultarAutoresLINQ | 109.86 ms | 2.172 ms | 2.414 ms | 109.59 ms |    4 | 3800.0000 | 1400.0000 | 400.0000 |  22.54 MB |
|                       ConsultaeAutoresEFCoreProjetada |  31.95 ms | 0.633 ms | 1.278 ms |  31.49 ms |    1 | 1093.7500 |  531.2500 |        - |   6.44 MB |
|           ConsultaeAutoresEFCoreProjetadaAsNoTracking |  31.67 ms | 0.395 ms | 0.330 ms |  31.61 ms |    1 | 1062.5000 |  500.0000 |        - |   6.44 MB |
| ConsultaeAutoresEFCoreProjetadaComResolucaoIdentidade |  32.37 ms | 0.646 ms | 1.471 ms |  31.62 ms |    1 | 1066.6667 |  533.3333 |        - |   6.44 MB |
|                         ConsultarAutoresLINQProjetada |  31.18 ms | 0.336 ms | 0.280 ms |  31.20 ms |    1 | 1062.5000 |  500.0000 |        - |   6.44 MB |
|                   ConsultarAutoresAutoMapperProjetada |  52.03 ms | 0.623 ms | 0.520 ms |  52.14 ms |    3 | 1300.0000 |  600.0000 |        - |   8.14 MB |
|         ConsultarAutoresAutoMapperProjetadaEspecifica |  33.77 ms | 0.673 ms | 1.008 ms |  33.25 ms |    2 | 1000.0000 |  500.0000 |        - |   6.11 MB |
