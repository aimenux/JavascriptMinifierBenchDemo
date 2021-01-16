using BenchmarkDotNet.Attributes;
using NUglify;
using System;
using System.IO;
using System.Text.RegularExpressions;

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
        public string UsingReplace()
        {
            var result = content
                .Replace("\r", replacement)
                .Replace("\t", replacement)
                .Replace("\n", replacement)
                .Replace("\r\n", replacement);

            var whitespaces = "  ";
            while (result.Contains(whitespaces))
            {
                result = result.Replace(whitespaces, replacement);
            }

            return result;
        }

        [Benchmark]
        public string UsingSplitJoin()
        {
            var characters = new char[] {'\r', '\n', '\t', ' '};
            return string.Join(replacement, content.Split(characters, StringSplitOptions.RemoveEmptyEntries));
        }

        [Benchmark]
        public string UsingRegex()
        {
            return regex.Replace(content, replacement);
        }

        [Benchmark]
        public string UsingNuglify()
        {
            return Uglify.Js(content).Code;
        }
    }
}
