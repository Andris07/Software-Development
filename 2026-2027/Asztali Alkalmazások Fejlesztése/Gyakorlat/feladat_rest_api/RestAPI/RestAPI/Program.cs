using RestAPI;
using static RestAPI.API;

API api = new API("https://sv443.net/jokeapi/v2/");
CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
bool running = true;

while (running)
{
    var jokeTask = api.GetJokeAsync("joke/Dark", cancellationTokenSource.Token);

    //cancellationTokenSource.Cancel();

    var joke = jokeTask.Result;

    if (joke is null)
    {
        Console.WriteLine($"No joke found.");
    }
    else
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"ID:\t{joke.id}\n");
        Console.ResetColor();

        Console.WriteLine($"Joke:\t{joke.setup}\n\t{joke.delivery}\n");

        Console.ForegroundColor = ConsoleColor.Yellow;
        var flags = typeof(JokeFlags).GetProperties().Select(x => $"{x.Name}: {x.GetValue(joke.flags)}");
        Console.WriteLine($"Flags:\n\t{string.Join("\n\t", flags)}\n");

        Console.ForegroundColor = ConsoleColor.Blue;
        Console.Write($"Want to hear another joke? (y/n): ");
        var input = Console.ReadLine();
        if (input?.ToLower() != "y")
        {
            running = false;
        }
        else
        {
            Console.ResetColor();
            Console.Clear();
        }
    }
}
