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
        private readonly string id;
        private readonly string title;
        private readonly string description;

        protected WorkItem(string id, string title, string description)
        {
            EnsureIdIsValid(id);
            ValidateTitle(title);
            ValidateDescription(description);
            this.id = id;
            this.title = title;
            this.description = description;
            this.History = new List<string>();
            this.Comments = new Dictionary<IMember, IList<string>>();
        }
        public string Id
        {
            get => this.id;
        }
        public string Title
        {
            get => this.title;
        }
        public string Description
        {
            get => this.description;
        }
        public IList<string> History { get; }
        public IDictionary<IMember, IList<string>> Comments { get; }
        private void ValidateTitle(string title)
        {
            if (title.Length < 10 || title.Length > 50)
            {
                throw new ArgumentException("Title should be between 10 and 50 characters");
            }
        }
        private void ValidateDescription(string description)
        {
            if (description.Length < 10 || description.Length > 500)
            {
                throw new ArgumentException("Description should be between 10 and 500 characters");
            }
        }

        private void EnsureIdIsValid(string id)
        {
            if (allIds.Contains(id))
            {
                throw new ArgumentException("ID already exists.");
            }
            allIds.Add(id);
        }

        public void AddHistory(string info)
        {
            this.History.Add(info);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"ID: {this.id}");
            sb.AppendLine($"Title: {this.title}");
            sb.AppendLine($"Description: {this.description}");
            sb.AppendLine($"Activity history: {string.Join(Environment.NewLine, this.History)}");
            sb.AppendLine($"Comments: {string.Join(Environment.NewLine, this.Comments)}");

            return sb.ToString().Trim();
        }
    }
}
