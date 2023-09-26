namespace Leonardo;

public class Fibonacci
{
    public static int Run(int i) { 
        if(i<=2) return 1;
        return Run(i-2) + Run(i-1);
    }
    public static async Task<IList<int>> RunAsync(string[] args)
    {
        IList<int> results = new List<int>();
        var tasks = new List<Task<int>>();
        
        //Stopwatch stopwatch = new Stopwatch();
        //stopwatch.Start();
        
        foreach (var arg in args)
        {
            var task = Task.Run(() =>
            {
                var result = Fibonacci.Run(int.Parse(arg));
                //Console.WriteLine(result);
                //Console.WriteLine($"Elapsed time : {stopwatch.ElapsedMilliseconds} ms");
                return result;
            });
            tasks.Add(task);
            //stopwatch.Stop();
            //Console.WriteLine($"Total time : {stopwatch.ElapsedMilliseconds} ms");
    
        }
        foreach (var task in tasks)
        {
            var result = await task;
            
            Console.WriteLine($"Result: {task.Result}");
            results.Add(result);
        }
        return results;
    }
    
}