using System;
using System.Collections.Generic;
using NameGeneration;

namespace NameGeneration.Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            var command = args.Length > 0 ? args[0].ToLower() : "help";

            var nameGenerator = new NameGenerator();
            Console.Title = "NameGeneration Demo";

            while (true)
            {
                if (command == "exit")
                {
                    Environment.Exit(0);
                }
                else if (command == "help")
                {
                    ShowHelp();
                }
                else if (command == "rand")
                {
                    var nameList = new List<FullName>();

                    for (var i = 0; i < 10; i++)
                    {
                        nameList.Add(nameGenerator.New());
                    }

                    Write("---");
                    nameList.ForEach(n => Write(n.Full));
                    Write("---");
                }
                else if (command == "boys")
                {
                    var nameList = new List<string>();

                    for (var i = 0; i < 10; i++)
                    {
                        nameList.Add(nameGenerator.NewFirst(NameGender.Male));
                    }

                    Write("---");
                    nameList.ForEach(n => Write(n));
                    Write("---");
                }
                else if (command == "last")
                {
                    var nameList = new List<string>();
                    
                    for (var i = 0; i < 10; i++)
                    {
                        nameList.Add(nameGenerator.NewLast());
                    }

                    Write("---");
                    nameList.ForEach(n => Write(n));
                    Write("---");
                }
                else
                {
                    Write(String.Format("'{0}' is not a valid command", command));
                }

                command = Read().ToLower();
            }
        }

        static void ShowHelp()
        {
            var lines = new List<string>()
            {
                "Available Commands:",
                "    help - Show this legend",
                "    rand - Generate 10 random names (male and female)",
                "    boys - Generate 10 random first names (male)",
                "    last - Generate 10 random last names",
                "    exit - Exit the demo",
            };
            
            lines.ForEach(l => Write(l));
        }

        private const string LinePrefix = "NameGeneration> ";

        static void Write(string line)
        {
            if(line.Length > (Console.WindowWidth - LinePrefix.Length)) {
                Console.Write(LinePrefix);
                var linePart = String.Format("{0}-", line.Substring(0, Console.WindowWidth - LinePrefix.Length - 1));
                Console.Write(linePart);
                Write(line.Substring(Console.WindowWidth - LinePrefix.Length - 1));
                return;
            }

            Console.Write(LinePrefix);
            Console.WriteLine(line);
        }

        static string Read()
        {
            Console.Write(LinePrefix);
            return Console.ReadLine();
        }
    }
}
