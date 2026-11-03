Console.WriteLine("Program started.");

static long Fibonacci(int n)
{
    if (n < 0) throw new ArgumentException("Negative arguments are not allowed!");
    if (n <= 1) return n;
    return Fibonacci(n - 1) + Fibonacci(n - 2);
}

#pragma warning disable CS4014
var task = Task.Run(() =>
{
    var result = Fibonacci(45);
    Console.WriteLine($"Fibonacci of 45 (task) calculated: {result}");
});
//await task;
// Uncommenting this line will make the program wait for the task to complete before proceeding.

static Task<long> FibonacciTask(int n) => Task<long>.Run(() => Fibonacci(n));

//async Task Kiszamol(int n)
//{
//    Console.WriteLine($"Fibonacci of {n} calculated: {await FibonacciTask(n)}");
//    Console.WriteLine($"Fibonacci of {n} calculated: {await FibonacciTask(n)}");
//    Console.WriteLine($"Fibonacci of {n} calculated: {await FibonacciTask(n)}");
//}
//Kiszamol(45);
// This will start the FibonacciTask for 45 and await its result asynchronously.

// The Kiszamol method calculates the sum of Fibonacci numbers for n, n-1, and n-2 asynchronously.
//static async Task<long> Kiszamol(int n)
//{
//    return await FibonacciTask(n) + await FibonacciTask(n-1) + await FibonacciTask(n-2);
//}
//var taskAsync = Kiszamol(45);
// This will start the FibonacciTask for 45, 44, and 43 and await their results asynchronously.

static Task<long> Kiszamol(int n) => Task<long>.Run(() =>
{
    {
        var tasks = new Task<long>[3] { FibonacciTask(n), FibonacciTask(n - 1), FibonacciTask(n - 2) };
        Task.WaitAll(tasks);
        return tasks.Sum(x => x.Result);
        // return await Task.WhenAll(tasks).ContinueWith(t => t.Result.Sum());
        // static async Task<long> Kiszamol(int n)
        // This will start the FibonacciTask for 45, 46, and 47 and await their results asynchronously.
    }
});
var taskAsync = Kiszamol(45);

while (true)
{
    var input = Console.ReadLine();
    if (string.IsNullOrEmpty(input)) break;
    Console.WriteLine($"input: {input}");
    Console.WriteLine($"task status: {task.Status}");
}

// after the user has finished inputting, we can await the FibonacciTask to get the result
Console.WriteLine($"Fibonacci of 45 (FibonacciTask) calculated: {await FibonacciTask(45)}");
//long result = await FibonacciTask(45);
// Console.WriteLine($"Fibonacci of 45 (FibonacciTask) calculated: {result}");

Console.WriteLine($"Fibonacci of 45 (Kiszamol) calculated: {await taskAsync}");