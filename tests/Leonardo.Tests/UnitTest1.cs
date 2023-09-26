namespace Leonardo.Tests;

public class UnitTest1
{
    [Fact]
    public void Test1()
    {
        // test the fibonacci function:
        Assert.Equal(1, Fibonacci.Run(1));
        
        //test fibonacci sequence for 44:
        var results = Fibonacci.RunAsync(new string[] {"44"});
        results.Wait();
        Assert.Equal(701408733, results.Result[0]);
        
    }
}