using System;

namespace FileData
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            if (args?.Length == 2)
            {
                var command = new FileDataCommand(args[0], args[1]);

                var commandResult = command.Execute();
                
                Console.WriteLine($"{commandResult}");
            }

            Console.ReadKey();
        }
    }
}
