using eShop.models;
using static eShop.models.Storage;

namespace eShop.app;

class Program
{
    static void Main()
    {
        var path = string.Concat(Environment.CurrentDirectory, "/data/orders.json");
        var orders = ReadFromFile(path);

        foreach (var order in orders)
        {
            Console.WriteLine(order);
        }
    }
}
