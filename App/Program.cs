using BenchmarkDotNet.Running;

namespace App
{
    public static class Program
    {
        public static void Main()
        {
            BenchmarkRunner.Run<JavascriptMinifier>();
        }
    }
}
