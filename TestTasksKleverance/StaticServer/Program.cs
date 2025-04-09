using StaticServer;

Parallel.For(0, 10000, _ =>
{
    Server.AddToCount(1);
});

Console.WriteLine("Expected Result: 10000");
Console.WriteLine($"Actual Result: {Server.GetCount()}");
Console.ReadLine();
