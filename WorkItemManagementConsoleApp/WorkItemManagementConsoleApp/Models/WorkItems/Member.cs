using System;
using System.Collections.Generic;
using System.Text;
using WorkItemManagementConsoleApp.Models.Contracts;

namespace WorkItemManagementConsoleApp.Models.WorkItems
{
    public class Member : IMember
    {
        private readonly string name;
        private readonly IList<IWorkItem> workItems = new List<IWorkItem>();
        private readonly IList<string> activityHistory = new List<string>();
        public Member(string name)
        {
            EnsureNameIsValid(name);
            this.name = name;
        }
        public string Name { get => this.name; }
        public IList<IWorkItem> WorkItems { get => this.workItems; }
        public IList<string> ActivityHistory { get => this.activityHistory; }
        private void EnsureNameIsValid(string name)
        {
            if (name.Length < 5 || name.Length > 15)
            {
                throw new ArgumentException("Member name should be between 5 and 15 characters.");
            }
        }
        public void AddWorkItems(IWorkItem item)
        {
            this.workItems.Add(item);
            this.AddActivityHistory($"Item {item.Title} added.");
        }
        private void AddActivityHistory(string info)
        {
            this.activityHistory.Add(info);
        }

    }
}
