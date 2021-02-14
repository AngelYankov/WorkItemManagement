using System;
using System.Collections.Generic;
using System.Text;
using WorkItemManagementConsoleApp.Models.Contracts;

namespace WorkItemManagementConsoleApp.Models.WorkItems
{
    public class Board : IBoard
    {
        private readonly string name;
        private readonly IList<string> activityHistory = new List<string>();
        private readonly IList<IWorkItem> workItems = new List<IWorkItem>();
        public Board(string name)
        {
            EnsureNameIsValid(name);
            this.name = name;
        }
        public string Name
        {
            get => this.name;
        }
        public IList<IWorkItem> WorkItems { get => this.workItems; }
        public IList<string> ActivityHistory { get => this.activityHistory;}
        private void EnsureNameIsValid(string name)
        {
            if (name.Length < 5 || name.Length > 10)
            {
                throw new ArgumentException("Board name should be between 5 and 10 characters.");
            }
        }
        /// <summary>
        /// Adding a work item to the work item database
        /// </summary>
        /// <param name="item">The work item that is added to the database</param>
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
