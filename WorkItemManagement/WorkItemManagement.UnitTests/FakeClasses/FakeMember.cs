using System;
using System.Collections.Generic;
using System.Text;
using WorkItemManagement.Models.Contracts;

namespace WorkItemManagement.UnitTests.FakeClasses
{
    public class FakeMember : IMember
    {
        public FakeMember()
        {
            this.WorkItems = new List<IWorkItem>();
            this.ActivityHistory = new List<string>();
        }
        public FakeMember(string name)
        {
            this.Name = name;
            this.WorkItems = new List<IWorkItem>();
            this.ActivityHistory = new List<string>();
        }
        public string Name { get; set; }

        public IList<IWorkItem> WorkItems { get; }

        public IList<string> ActivityHistory { get; }

        public void AddActivityHistory(string info)
        {
            this.ActivityHistory.Add(info);
        }

        public void AddWorkItems(IWorkItem item)
        {
            this.WorkItems.Add(item);
            AddActivityHistory($"Item: '{item.Id}' added.");
        }

        public void RemoveWorkItems(IWorkItem item)
        {
            this.WorkItems.Remove(item);
        }
    }
}
