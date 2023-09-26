// See https://aka.ms/new-console-template for more information

using Leonardo;

var results = Fibonacci.RunAsync(args);
Console.WriteLine("here");

results.Wait();
Console.WriteLine("there");