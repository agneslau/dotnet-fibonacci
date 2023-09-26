using Leonardo;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World! 3");

app.MapGet("/Fibonacci/{number}", (int number) => Fibonacci.Run(number).ToString());


app.MapGet("/Fibonacci", () => Fibonacci.RunAsync(new []{"44", "44", "44"}));

app.Run();
