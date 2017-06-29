using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using System;
using System.Text;
using BenchmarkDotNet.Reports;

namespace StringInterpolationPerformance
{
    class Program
    {
        static void Main(string[] args)
        {
            Summary summary;

            summary = BenchmarkRunner.Run<StringFormatVsStringInterpolation>();

            summary = BenchmarkRunner.Run<StringPlusOperatorVsStringInterpolation>();

            summary = BenchmarkRunner.Run<StringConcatVsStringInterpolation>();

            summary = BenchmarkRunner.Run<StringBuilderVsStringInterpolation>();

            summary = BenchmarkRunner.Run<StringPlusOperatorVsStringConcat>();
        }
    }

    public class StringFormatVsStringInterpolation
    {
        private string data1;
        private string data2;
        private string data3;

        public StringFormatVsStringInterpolation()
        {
            data1 = Guid.NewGuid().ToString();
            data2 = Guid.NewGuid().ToString();
            data3 = Guid.NewGuid().ToString();
        }

        [Benchmark]
        public string StringFormat() => string.Format("test format{0}, {1}, {2}", data1, data2, data3); 

        [Benchmark]
        public string StringInterpolation() => ($"test format{data1}, {data2}, {data3}");

    }

    public class StringPlusOperatorVsStringInterpolation
    {
        private string data1;
        private string data2;
        private string data3;
        
        public StringPlusOperatorVsStringInterpolation()
        {
            data1 = Guid.NewGuid().ToString();
            data2 = Guid.NewGuid().ToString();
            data3 = Guid.NewGuid().ToString();
        }

        [Benchmark]
        public string StringPlusOperator() => "test format" + data1 + data2 + data3;

        [Benchmark]
        public string StringInterpolation() => ($"test format{data1}, {data2}, {data3}");

    }

    public class StringConcatVsStringInterpolation
    {
        private string data1;
        private string data2;
        private string data3;

        public StringConcatVsStringInterpolation()
        {
            data1 = Guid.NewGuid().ToString();
            data2 = Guid.NewGuid().ToString();
            data3 = Guid.NewGuid().ToString();
        }

        [Benchmark]
        public string StringConcat() => string.Concat("test format", data1, data2, data3);

        [Benchmark]
        public string StringInterpolation() => ($"test format{data1}, {data2}, {data3}");

    }

    public class StringBuilderVsStringInterpolation
    {
        private string data1;
        private string data2;
        private string data3;

        public StringBuilderVsStringInterpolation()
        {
            data1 = Guid.NewGuid().ToString();
            data2 = Guid.NewGuid().ToString();
            data3 = Guid.NewGuid().ToString();
        }

        [Benchmark]
        public string StringBuilder() => (new StringBuilder()).Append("test format").Append(data1).Append(data2).Append(data3).ToString();

        [Benchmark]
        public string StringInterpolation() => ($"test format{data1}, {data2}, {data3}");

    }

    public class StringPlusOperatorVsStringConcat
    {
        private string data1;
        private string data2;
        private string data3;
        private string data4;

        public StringPlusOperatorVsStringConcat()
        {
            data1 = Guid.NewGuid().ToString();
            data2 = Guid.NewGuid().ToString();
            data3 = Guid.NewGuid().ToString();
            data4 = Guid.NewGuid().ToString();
        }

        [Benchmark]
        public string StringPlusOperator() => "test format" + data1 + data2 + data3 + data4;

        [Benchmark]
        public string StringConcat() => string.Concat("test format", data1, data2, data3, data4);
    }
}
