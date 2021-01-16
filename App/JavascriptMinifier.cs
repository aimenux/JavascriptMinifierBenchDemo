using BenchmarkDotNet.Attributes;
using Microsoft.Ajax.Utilities;
using NUglify;
using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using WebMarkupMin.Core;
using WebMarkupMin.MsAjax;
using WebMarkupMin.NUglify;
using WebMarkupMin.Yui;

namespace App
{
    [Config(typeof(BenchConfig))]
    public class JavascriptMinifier
    {
        private Regex regex;
        private string content;
        private string replacement;

        [GlobalSetup]
        public void Setup()
        {
            replacement = " ";
            regex = new Regex(@"\s+", RegexOptions.Compiled);
            content = File.ReadAllText($"Scripts\\AppDynamics.js").Trim();
        }

        [Benchmark]
        [BenchmarkCategory(nameof(BenchCategory.Light))]
        public string UsingConcat()
        {
            return string.Concat(content.Where(c => !char.IsWhiteSpace(c)));
        }

        [Benchmark]
        [BenchmarkCategory(nameof(BenchCategory.Light))]
        public string UsingReplace()
        {
            var whitespaces = "  ";
            var result = content
                .Replace("\r", replacement)
                .Replace("\t", replacement)
                .Replace("\n", replacement)
                .Replace("\r\n", replacement)
                .Replace(whitespaces, replacement)
                .Replace(Environment.NewLine, replacement);

            while (result.Contains(whitespaces))
            {
                result = result.Replace(whitespaces, replacement);
            }

            return result;
        }

        [Benchmark]
        [BenchmarkCategory(nameof(BenchCategory.Light))]
        public string UsingSplitJoin()
        {
            var characters = new char[] { '\r', '\n', '\t', ' ' };
            return string.Join(replacement, content.Split(characters, StringSplitOptions.RemoveEmptyEntries));
        }

        [Benchmark]
        [BenchmarkCategory(nameof(BenchCategory.Light))]
        public string UsingRegex()
        {
            return regex.Replace(content, replacement);
        }

        [Benchmark]
        [BenchmarkCategory(nameof(BenchCategory.Full))]
        public string UsingAjaxmin()
        {
            var settings = new CodeSettings
            {
                MinifyCode = true,
            };
            var minifier = new Minifier();
            return minifier.MinifyJavaScript(content, settings);
        }

        [Benchmark]
        [BenchmarkCategory(nameof(BenchCategory.Full))]
        public string UsingNuglify()
        {
            return Uglify.Js(content).Code;
        }

        [Benchmark]
        [BenchmarkCategory(nameof(BenchCategory.Full))]
        public string UsingWebMarkupMinAjaxmin()
        {
            var settings = new HtmlMinificationSettings
            {
                MinifyEmbeddedCssCode = false,
                MinifyInlineCssCode = false,
                MinifyEmbeddedJsCode = true,
                MinifyInlineJsCode = true
            };

            var minifier = new HtmlMinifier(settings, new NullCssMinifier(), new MsAjaxJsMinifier());
            return minifier.Minify(content).MinifiedContent;
        }

        [Benchmark]
        [BenchmarkCategory(nameof(BenchCategory.Full))]
        public string UsingWebMarkupMinNuglify()
        {
            var settings = new HtmlMinificationSettings
            {
                MinifyEmbeddedCssCode = false,
                MinifyInlineCssCode = false,
                MinifyEmbeddedJsCode = true,
                MinifyInlineJsCode = true
            };

            var minifier = new HtmlMinifier(settings, new NullCssMinifier(), new NUglifyJsMinifier());
            return minifier.Minify(content).MinifiedContent;
        }

        [Benchmark]
        [BenchmarkCategory(nameof(BenchCategory.Full))]
        public string UsingWebMarkupMinCrockford()
        {
            var settings = new HtmlMinificationSettings
            {
                MinifyEmbeddedCssCode = false,
                MinifyInlineCssCode = false,
                MinifyEmbeddedJsCode = true,
                MinifyInlineJsCode = true
            };

            var minifier = new HtmlMinifier(settings, new NullCssMinifier(), new CrockfordJsMinifier());
            return minifier.Minify(content).MinifiedContent;
        }

        [Benchmark]
        [BenchmarkCategory(nameof(BenchCategory.Full))]
        public string UsingWebMarkupMinYuiCompressor()
        {
            var settings = new HtmlMinificationSettings
            {
                MinifyEmbeddedCssCode = false,
                MinifyInlineCssCode = false,
                MinifyEmbeddedJsCode = true,
                MinifyInlineJsCode = true
            };

            var minifier = new HtmlMinifier(settings, new NullCssMinifier(), new YuiJsMinifier());
            return minifier.Minify(content).MinifiedContent;
        }
    }
}
