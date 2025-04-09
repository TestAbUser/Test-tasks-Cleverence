using StaticServer;
var IncrementValue = 0;
Parallel.For(0, 1000, _ =>
{
   // IncrementValue+=1;
    Server.AddToCount(1);
   // Server.AddToCount(2);
    IncrementValue = Server.GetCount();
});

Console.WriteLine("Expected Result: 10000");
Console.WriteLine($"Actual Result: {Server.GetCount()}");
Console.ReadLine();
