using System;
using System.Collections.Generic;
using NameGeneration;

namespace NameGeneration.Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "NameGeneration Demo";

            var command = args.Length > 0 ? args[0].ToLower() : "help";

            var nameGenerator = new NameGenerator();

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
                else if (command == "prob")
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
                else if (command == "rand")
                {
                    var nameList = new List<FullName>();

                    for (var i = 0; i < 10; i++)
                    {
                        nameList.Add(nameGenerator.New(false));
                    }

                    Write("---");
                    nameList.ForEach(n => Write(n.Full));
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
                "    prob - Generate 10 random names by probability",
                "    rand - Generate 10 random names without probability",
                "    boys - Generate 10 random male first names",
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
