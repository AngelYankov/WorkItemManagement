using System;
using System.Collections.Generic;
using System.Text;
using WorkItemManagementConsoleApp.Models.Contracts;

namespace WorkItemManagementConsoleApp.Models.WorkItems
{
    public class Board : IBoard
    {
        private string name;
        public Board(string name)
        {
            this.Name = name;
        }
        public string Name
        {
            get => this.name;
            private set
            {
                if (value.Length < 5 || value.Length > 10)
                {
                    throw new ArgumentException("Board name should be between 5 and 10 characters.");
                }
                this.name = value;
            }
        }
        public List<IWorkItem> WorkItems { get; }
        public List<string> ActivityHistory { get; }

        // add methods for adding workitems and history
        
    }
}
