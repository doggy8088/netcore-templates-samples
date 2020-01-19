using System;
using System.Threading.Tasks;

namespace MyProject.Con
{
    class Program
    {
        static async Task Main(string[] args)
        {
            await Task.Delay(500);

            Console.WriteLine("Hello World!");
        }
    }
}
