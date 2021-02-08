using System;
using System.Collections.Generic;
using System.Text;
using WorkItemManagementConsoleApp.Models.Contracts;
using WorkItemManagementConsoleApp.Models.WorkItems;

namespace WorkItemManagementConsoleApp.Models.Abstract
{
    public abstract class WorkItem : IWorkItem
    {
        private static readonly List<string> allIds = new List<string>();
        private string title;
        private string description;
        protected WorkItem(string id, string title, string description)
        {
            EnsureIdIsValid(id);
            this.Title = title;
            this.Description = description;
        }
        public string Title
        {
            get => this.title;
            private set
            {
                if (value.Length < 10 || value.Length > 50)
                {
                    throw new ArgumentException("Title should be between 10 and 50 characters");
                }
                this.title = value;
            }
        }
        public string Description
        {
            get => this.description;
            private set
            {
                if (value.Length < 10 || value.Length > 500)
                {
                    throw new ArgumentException("Description should be between 10 and 500 characters.");
                }
                this.description = value;
            }
        }
        public List<string> History { get; }
        public IDictionary<Member, List<string>> Comments { get; }

        private void EnsureIdIsValid(string id)
        {
            if (allIds.Contains(id))
            {
                throw new ArgumentException("ID already exists.");
            }
            allIds.Add(id);
        }
        // add methods to add comments and history


    }
}
