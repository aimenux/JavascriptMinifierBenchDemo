![.NET 5](https://github.com/aimenux/JavascriptMinifierBenchDemo/workflows/.NET%205/badge.svg)

# JavascriptMinifierBenchDemo
```
Benchmarking various ways of javascript minification
```

In this demo, i m using [BenchmarkDotNet](https://github.com/dotnet/BenchmarkDotNet) library in order to benchmark various ways of javascript minification :
>
> Adhoc way :
>> :one: Using `replace`
>>
>> :two: Using `split join`
>>
>> :three: Using `compiled regex`
>
> Industrial way :
>> :four: Using [`nuglify library`](https://github.com/trullock/NUglify)
>

In order to run benchmarks, type this command in your favorite terminal :
>
> :writing_hand: `.\App.exe`
>

```
|         Method |      Mean |     Error |    StdDev |       Min |       Max | Rank |   Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------- |----------:|----------:|----------:|----------:|----------:|-----:|--------:|------:|------:|----------:|
| UsingSplitJoin |  3.274 μs | 0.0438 μs | 0.0410 μs |  3.228 μs |  3.360 μs |    1 |  1.4572 |     - |     - |   4.47 KB |
|     UsingRegex |  4.306 μs | 0.0239 μs | 0.0212 μs |  4.253 μs |  4.332 μs |    2 |  0.3586 |     - |     - |   1.12 KB |
|   UsingReplace |  8.240 μs | 0.0457 μs | 0.0405 μs |  8.141 μs |  8.309 μs |    3 |  2.3193 |     - |     - |   7.13 KB |
|    UsingUglify | 78.319 μs | 0.1563 μs | 0.1386 μs | 77.918 μs | 78.478 μs |    4 | 17.2119 |     - |     - |  52.91 KB |
```

**`Tools`** : vs19, net 5.0