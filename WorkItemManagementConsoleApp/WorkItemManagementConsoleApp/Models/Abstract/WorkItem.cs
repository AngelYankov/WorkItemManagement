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
            if (string.IsNullOrEmpty(title))
            {
                throw new ArgumentNullException();
            }
            if (title.Length < 10 || title.Length > 50)
            {
                throw new ArgumentException("Title should be between 10 and 50 characters");
            }
        }
        private void ValidateDescription(string description)
        {
            if (string.IsNullOrEmpty(description))
            {
                throw new ArgumentNullException();
            }
            if (description.Length < 10 || description.Length > 500)
            {
                throw new ArgumentException("Description should be between 10 and 500 characters");
            }
        }

        private void EnsureIdIsValid(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                throw new ArgumentNullException();
            }
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

        public void AddComment(IMember member, IList<string> comments)
        {
            this.Comments.Add(member, comments);
        }

        public override string ToString()
        {
            string history = this.History.Count == 0 ? "No history" : string.Join(" ", this.History);
            string comments = this.Comments.Count == 0 ? "No comments" : string.Join(" ", this.Comments);
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"ID: {this.id}");
            sb.AppendLine($"Title: {this.title}");
            sb.AppendLine($"Description: {this.description}");
            sb.AppendLine($"Activity history: {history}");
            sb.AppendLine($"Comments: {comments}");

            return sb.ToString().Trim();
        }
    }
}
