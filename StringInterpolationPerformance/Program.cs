using System;
using System.Text;

using BenchmarkDotNet.Attributes.Columns;
using BenchmarkDotNet.Attributes.Exporters;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;
using BenchmarkDotNet.Reports;
using BenchmarkDotNet.Running;

namespace StringInterpolationPerformance
{
    class Program
    {
        static void Main(string[] args)
        {
            Summary summary = BenchmarkRunner.Run<StringBuilding>();
        }
    }

    [MarkdownExporter]
    [OrderProvider(SummaryOrderPolicy.FastestToSlowest)]
    [RankColumn]
    public class StringBuilding
    {
        private string data1;
        private string data2;
        private string data3;

        public StringBuilding()
        {
            data1 = Guid.NewGuid().ToString();
            data2 = Guid.NewGuid().ToString();
            data3 = Guid.NewGuid().ToString();
        }

        [Benchmark]
        public string StringConcatX() => string.Concat("test format", data1, data2, data3);

        [Benchmark]
        public string StringPlusOperatorX() => "test format" + data1 + data2 + data3;

        [Benchmark(Baseline = true)]
        public string StringConcat() => string.Concat("test format", data1, ", ", data2, ", ", data3);

        [Benchmark]
        public string StringPlusOperator() => "test format" + data1 + ", " + data2 + ", " + data3;

        [Benchmark]
        public string StringInterpolation() => ($"test format{data1}, {data2}, {data3}");

        [Benchmark]
        public string StringFormat() => string.Format("test format{0}, {1}, {2}", data1, data2, data3); 

        [Benchmark]
        public string StringBuilder() => (new StringBuilder()).Append("test format").Append(data1).Append(", ").Append(data2).Append(", ").Append(data3).ToString();
    }
}
