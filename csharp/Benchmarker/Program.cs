// See https://aka.ms/new-console-template for more information
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Running;

//var results = BenchmarkRunner.Run<MarkdownBenchmark>();
//Console.WriteLine("Hello, World!");
var results = BenchmarkRunner.Run<Demo>();

