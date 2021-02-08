using System;
using System.Collections.Generic;
using System.Text;
using WorkItemManagementConsoleApp.Commands.Contracts;
using WorkItemManagementConsoleApp.Core.Contracts;

namespace WorkItemManagementConsoleApp.Core
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
                ICommand command = this.commandManager.ParseCommand(input);
                string result = command.Execute();
                return result.Trim();
            }
            catch (Exception e)
            {
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
