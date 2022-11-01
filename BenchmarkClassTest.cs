using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Columns;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Loggers;
using BenchmarkDotNet.Running;
using BenchmarkDotNet.Validators;
using NUnit.Framework;
using Recognizer;

namespace Recognizer
{
    public class BenchmarkClassTest
    {
        [Benchmark(Description = "1")]
        public void Test1()
        {
            BenchmarkClass.SomeMethodVer1(new double[100,100]);
        }
        
        [Benchmark(Description = "2")]
        public void Test2()
        {
            BenchmarkClass.SomeMethodVer2(new double[100,100]);
        }
        
        [Benchmark(Description = "3")]
        public void Test3()
        {
            BenchmarkClass.SomeMethodVer3(new double[100,100]);
        }
    }

    [TestFixture]
    class UnitTest
    {
        [Test]
        public void TestMethod()
        {
            var config = new ManualConfig()
                .WithOptions(ConfigOptions.DisableOptimizationsValidator)
                .AddValidator(JitOptimizationsValidator.DontFailOnError)
                .AddLogger(ConsoleLogger.Default)
                .AddColumnProvider(DefaultColumnProviders.Instance);

            BenchmarkRunner.Run<BenchmarkClassTest>(config);
        }
    }
}