using DbUp;
using Microsoft.Azure;
using System;
using System.Linq;
using System.Reflection;

namespace ProjectX.Master
{
    static class Program
    {
        static void Main(string[] args)
        {
            var connectionString =
                args.FirstOrDefault()
                ?? CloudConfigurationManager.GetSetting("MasterDbTemplate");

            EnsureDatabase.For.SqlDatabase(connectionString);

            var upgrader =
                DeployChanges.To
                    .SqlDatabase(connectionString)
                    .WithScriptsEmbeddedInAssembly(Assembly.GetExecutingAssembly())
                    .LogToConsole()
                    .Build();

            var result = upgrader.PerformUpgrade();

            if (!result.Successful)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(result.Error);
                Console.ResetColor();
#if DEBUG
                Console.ReadLine();
#endif
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Success!");
            Console.ResetColor();
        }
    }
}
