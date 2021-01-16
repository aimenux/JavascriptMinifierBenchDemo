![.NET 5](https://github.com/aimenux/JavascriptMinifierBenchDemo/workflows/.NET%205/badge.svg)

# JavascriptMinifierBenchDemo
```
Benchmarking various ways of javascript minification
```

In this demo, i m using [BenchmarkDotNet](https://github.com/dotnet/BenchmarkDotNet) library in order to benchmark various ways of javascript minification.
Minification means removing all unnecessary characters, such as spaces, new lines, comments, without changing the functionality of the source code.

>
> Light adhoc ways (not for production) :
>> :one: Using `concat`
>>
>> :two: Using `replace`
>>
>> :three: Using `split join`
>>
>> :four: Using `compiled regex`
>
> Full robust ways (ready for production) :
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
|                         Method |      Mean |     Error |    StdDev |       Min |       Max | Rank |   Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------------- |----------:|----------:|----------:|----------:|----------:|-----:|--------:|------:|------:|----------:|
|                 UsingSplitJoin |  3.291 μs | 0.0412 μs | 0.0385 μs |  3.254 μs |  3.364 μs |    1 |  1.4572 |     - |     - |   4.47 KB |
|                     UsingRegex |  4.523 μs | 0.0275 μs | 0.0257 μs |  4.477 μs |  4.563 μs |    2 |  0.3586 |     - |     - |   1.12 KB |
|                   UsingReplace |  8.930 μs | 0.0291 μs | 0.0273 μs |  8.885 μs |  8.983 μs |    3 |  2.3193 |     - |     - |   7.13 KB |
|                    UsingConcat |  9.993 μs | 0.0245 μs | 0.0217 μs |  9.943 μs | 10.028 μs |    4 |  0.3662 |     - |     - |   1.13 KB |
|     UsingWebMarkupMinCrockford | 20.630 μs | 0.4107 μs | 0.7509 μs | 19.828 μs | 22.525 μs |    5 |  3.2349 |     - |     - |   9.95 KB |
|                   UsingAjaxmin | 80.742 μs | 1.1554 μs | 0.9648 μs | 79.267 μs | 82.355 μs |    6 | 17.2119 |     - |     - |  52.85 KB |
|                   UsingNuglify | 81.728 μs | 1.4520 μs | 1.2871 μs | 79.929 μs | 84.446 μs |    6 | 17.2119 |     - |     - |  52.91 KB |
|       UsingWebMarkupMinAjaxmin | 91.009 μs | 0.8360 μs | 0.6981 μs | 90.187 μs | 92.754 μs |    7 | 17.8223 |     - |     - |  54.59 KB |
|       UsingWebMarkupMinNuglify | 91.703 μs | 0.8467 μs | 0.7071 μs | 90.456 μs | 92.904 μs |    7 | 17.8223 |     - |     - |  54.69 KB |
| UsingWebMarkupMinYuiCompressor | 98.261 μs | 0.1751 μs | 0.1553 μs | 98.031 μs | 98.537 μs |    8 | 18.9209 |     - |     - |  57.96 KB |
```

**`Tools`** : vs19, net 5.0