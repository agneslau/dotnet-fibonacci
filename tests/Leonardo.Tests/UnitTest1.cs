using Microsoft.EntityFrameworkCore;

namespace Leonardo.Tests;

public class UnitTest1
{
    [Fact]
    public async Task Test1()
    {
        var builder = new DbContextOptionsBuilder<FibonacciDataContext>();
        var dataBaseName = Guid.NewGuid().ToString();
        builder.UseInMemoryDatabase(dataBaseName);

        var options = builder.Options;
        var fibonacciDataContext = new FibonacciDataContext(options);
        await fibonacciDataContext.Database.EnsureCreatedAsync();
        // test the fibonacci function:
        Assert.Equal(1, Fibonacci.Run(1));
        
        //test fibonacci sequence for 44:
        var results = new Fibonacci(fibonacciDataContext).RunAsync(new string[] {"44"});
        results.Wait();
        Assert.Equal(701408733, results.Result[0]);
        
    }
}