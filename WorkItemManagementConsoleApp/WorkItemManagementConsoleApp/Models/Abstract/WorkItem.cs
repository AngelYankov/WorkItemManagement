using System;
using System.Collections.Generic;
using System.Text;
using WorkItemManagementConsoleApp.Models.Contracts;
using WorkItemManagementConsoleApp.Models.WorkItems;

namespace WorkItemManagementConsoleApp.Models.Abstract
{
    public abstract class WorkItem : IWorkItem
    {
        private static int id = 0;
        private string title;
        private string description;
        public WorkItem(string title, string description,/* Dictionary<Member, List<string>> comments,*/ List<string> history)
        {
            this.Title = title;
            this.Description = description;
            //this.Comments = comments;
            this.History = history;
            id++;
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
        //IDictionary<Member, List<string>> Comments { get; }
        public List<string> History { get; }

    }
}
