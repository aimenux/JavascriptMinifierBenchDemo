![.NET 5](https://github.com/aimenux/JavascriptMinifierBenchDemo/workflows/.NET%205/badge.svg)

# JavascriptMinifierBenchDemo
```
Benchmarking various ways of javascript minification
```

In this demo, i m using [BenchmarkDotNet](https://github.com/dotnet/BenchmarkDotNet) library in order to benchmark various ways of javascript minification.

> :beginner: `Minification` means removing all unnecessary characters, such as spaces, new lines, comments, without changing the functionality of the source code.
>
>
> **Light** adhoc ways (not for production) :
>> :one: Using `concat`
>>
>> :two: Using `replace`
>>
>> :three: Using `split join`
>>
>> :four: Using `compiled regex`
>
> **Full** robust ways (ready for production) :
>> :five: Using [`Ajaxmin library`](https://github.com/microsoft/ajaxmin)
>>
>> :six: Using [`nuglify library`](https://github.com/trullock/NUglify)
>>
>> :seven: Using [`WebMarkupMin library`](https://github.com/Taritsyn/WebMarkupMin)
>

In order to run benchmarks, type this command in your favorite terminal :
>
> :writing_hand: `.\App.exe`
>

```
|                         Method | Categories |      Mean |     Error |    StdDev |       Min |       Max | Rank |   Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------------- |----------- |----------:|----------:|----------:|----------:|----------:|-----:|--------:|------:|------:|----------:|
|                 UsingSplitJoin |      Light |  3.283 μs | 0.0634 μs | 0.0623 μs |  3.177 μs |  3.385 μs |    1 |  1.4572 |     - |     - |   4.47 KB |
|                     UsingRegex |      Light |  4.340 μs | 0.0398 μs | 0.0353 μs |  4.274 μs |  4.385 μs |    2 |  0.3586 |     - |     - |   1.12 KB |
|                   UsingReplace |      Light |  8.641 μs | 0.0744 μs | 0.0696 μs |  8.518 μs |  8.747 μs |    3 |  2.3193 |     - |     - |   7.13 KB |
|                    UsingConcat |      Light |  9.394 μs | 0.0448 μs | 0.0374 μs |  9.281 μs |  9.441 μs |    4 |  0.3662 |     - |     - |   1.13 KB |
|                                |            |           |           |           |           |           |      |         |       |       |           |
|     UsingWebMarkupMinCrockford |       Full | 19.559 μs | 0.0715 μs | 0.0597 μs | 19.467 μs | 19.678 μs |    1 |  3.2349 |     - |     - |   9.95 KB |
|                   UsingAjaxmin |       Full | 73.875 μs | 0.2715 μs | 0.2267 μs | 73.511 μs | 74.297 μs |    2 | 17.2119 |     - |     - |  52.85 KB |
|                   UsingNuglify |       Full | 76.681 μs | 0.7011 μs | 0.6558 μs | 76.023 μs | 77.751 μs |    3 | 17.2119 |     - |     - |  52.91 KB |
|       UsingWebMarkupMinAjaxmin |       Full | 86.780 μs | 1.4255 μs | 1.9031 μs | 84.921 μs | 91.620 μs |    4 | 17.7002 |     - |     - |  54.59 KB |
|       UsingWebMarkupMinNuglify |       Full | 87.387 μs | 0.7255 μs | 0.6786 μs | 85.853 μs | 88.299 μs |    4 | 17.8223 |     - |     - |  54.69 KB |
| UsingWebMarkupMinYuiCompressor |       Full | 95.688 μs | 0.6320 μs | 0.5602 μs | 95.122 μs | 96.937 μs |    5 | 18.9209 |     - |     - |  57.96 KB |
```

**`Tools`** : vs19, net 5.0