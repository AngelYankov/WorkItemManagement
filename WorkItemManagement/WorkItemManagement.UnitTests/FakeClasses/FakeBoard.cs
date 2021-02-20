using System;
using System.Collections.Generic;
using System.Text;
using WorkItemManagement.Models.Contracts;

namespace WorkItemManagement.UnitTests.FakeClasses
{
    public class FakeBoard : IBoard
    {
        public FakeBoard() { }
        public FakeBoard(string name)
        {
            this.Name = name;
            this.WorkItems = new List<IWorkItem>();
            this.ActivityHistory = new List<string>();
        }
        public string Name { get; set; }

        public IList<IWorkItem> WorkItems { get; }

        public IList<string> ActivityHistory { get; }

        public void AddWorkItem(IWorkItem item)
        {
            this.WorkItems.Add(item);
            AddHistory($"Item added.");
        }
        private void AddHistory(string info)
        {
            this.ActivityHistory.Add(info);
        }
    }
}
