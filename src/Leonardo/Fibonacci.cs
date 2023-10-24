using Microsoft.EntityFrameworkCore;

namespace Leonardo;

public class Fibonacci
{
    private readonly FibonacciDataContext _context;

    public Fibonacci(FibonacciDataContext context)
    {
        _context = context;
    }
    public static int Run(int i) { 
        if(i<=2) return 1;
        return Run(i-2) + Run(i-1);
    }
    public async Task<IList<int>> RunAsync(string[] args)
    {

        if (args.Length >= 100)
        {
            throw new ArgumentException("Too many arguments");
        }
        
        
        
        IList<int> results = new List<int>();
        var tasks = new List<Task<int>>();
        
        //Stopwatch stopwatch = new Stopwatch();
        //stopwatch.Start();
        
        foreach (var arg in args)
        {
                var tFibonnacci = await _context.TFibonaccis
                    .Where(t => t.FibInput == int.Parse(arg))
                    .FirstOrDefaultAsync();

                if (tFibonnacci == null)
                {
                    var task = Task.Run(() =>
                    {
                        var result = Fibonacci.Run(int.Parse(arg));
                        //Console.WriteLine(result);
                        //Console.WriteLine($"Elapsed time : {stopwatch.ElapsedMilliseconds} ms");

                        return result;
                        
                        
                    });
                    
                    tasks.Add(task);
                }
                else
                {
                    tasks.Add(Task.FromResult((int)tFibonnacci.FibOutput));
                }

        }
        foreach (var task in tasks)
        {
            var result = await task;
            _context.TFibonaccis.Add(new TFibonacci()
            {
                FibOutput = result,
                FibInput = int.Parse(args[tasks.IndexOf(task)]),
            });
            
            Console.WriteLine($"Result: {task.Result}");
            results.Add(result);
        }

        await _context.SaveChangesAsync();
        return results;
    }
    
}