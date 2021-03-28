using System;
using System.Text;
using WorkItemManagement.Commands.Contracts;
using WorkItemManagement.Core.Contracts;

namespace WorkItemManagement.Core
{
    public class Engine : IEngine
    {
        private static Engine instance;
        public static IEngine Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Engine();
                }
                return instance;
            }
        }

        private readonly ICommandManager commandManager;
        
        private Engine()
        {
            this.commandManager = new CommandManager();
        }

        public void Run()
        {
            while (true)
            {
                Console.ResetColor();
                string input = Console.ReadLine();
                if (input == "exit")
                {
                    break;
                }
                string result = this.Process(input);
                this.Print(result);
            }
        }
        private string Process(string input)
        {
            try
            {
                Console.ForegroundColor = ConsoleColor.Green;
                ICommand command = this.commandManager.ParseCommand(input);
                string result = command.Execute();
                return result.Trim();
            }
            catch (Exception e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                while (e.InnerException != null)
                {
                    e = e.InnerException;

                }
                return $"ERROR: {e.Message}";
            }
        }

        private void Print(string result)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(result);
            sb.AppendLine("------------------");
            Console.WriteLine(sb.ToString().Trim());
        }
    }
}
