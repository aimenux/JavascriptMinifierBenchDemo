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
| UsingSplitJoin |  3.232 μs | 0.0280 μs | 0.0234 μs |  3.167 μs |  3.271 μs |    1 |  1.4572 |     - |     - |   4.47 KB |
|     UsingRegex |  4.365 μs | 0.0298 μs | 0.0278 μs |  4.338 μs |  4.415 μs |    2 |  0.3586 |     - |     - |   1.12 KB |
|   UsingReplace |  8.171 μs | 0.0435 μs | 0.0386 μs |  8.094 μs |  8.237 μs |    3 |  2.3193 |     - |     - |   7.13 KB |
|   UsingNuglify | 75.613 μs | 0.1511 μs | 0.1180 μs | 75.366 μs | 75.789 μs |    4 | 17.2119 |     - |     - |  52.91 KB |
```

**`Tools`** : vs19, net 5.0