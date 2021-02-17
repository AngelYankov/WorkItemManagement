using System;
using System.Collections.Generic;
using WorkItemManagement.Models.Contracts;

namespace WorkItemManagement.Models.WorkItems
{
    public class Board : IBoard
    {
        private readonly string name;
        private readonly IList<string> activityHistory;
        private readonly IList<IWorkItem> workItems;
        public Board(string name)
        {
            EnsureNameIsValid(name);
            this.name = name;
            this.workItems = new List<IWorkItem>();
            this.activityHistory = new List<string>();
        }
        public string Name
        {
            get => this.name;
        }
        public IList<IWorkItem> WorkItems { get => this.workItems; }
        public IList<string> ActivityHistory { get => this.activityHistory;}
        private void EnsureNameIsValid(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException();
            }
            if (name.Length < 5 || name.Length > 10)
            {
                throw new ArgumentException("Board name should be between 5 and 10 characters.");
            }
        }
        /// <summary>
        /// Adding a work item to the Board's work items
        /// </summary>
        /// <param name="item">The work item that is added</param>
        public void AddWorkItem(IWorkItem item)
        {
            this.WorkItems.Add(item);
            AddHistory($"'{item.Title}' added.");
        }
        private void AddHistory(string info)
        {
            this.ActivityHistory.Add(info);
        }
    }
}
