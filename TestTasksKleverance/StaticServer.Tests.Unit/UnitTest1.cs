using StaticServer;

namespace StaticServer.Tests.Unit
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            var IncrementValue = 0;
            Parallel.For(0, 100, _ =>
            {
                Server.AddToCount(1);
            });
            Console.WriteLine("Expected Result: 100000");
            Console.WriteLine($"Actual Result: {Server.GetCount()}");
           // Console.ReadKey();
        }
    }
}
