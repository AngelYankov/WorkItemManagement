using System;
using System.Collections.Generic;
using System.Text;
using WorkItemManagement.Models.Contracts;
using WorkItemManagement.Models.Enums;

namespace WorkItemManagement.UnitTests.FakeClasses
{
    public class FakeBug : IBug
    {
        private readonly IList<string> steps;
        private PriorityType priorityType;
        private SeverityType severityType;
        private BugStatus bugStatus;
        private IMember assignee;
        private Dictionary<IMember, IList<string>> comments;
        public FakeBug(string id)
        {
            this.Id = id;
            this.steps = new List<string>();
            this.bugStatus = BugStatus.Active;
            this.comments = new Dictionary<IMember, IList<string>>();
            this.History = new List<string>();
    }

        public FakeBug(string id, string title)
        {
            this.Id = id;
            this.Title = title;
            this.steps = new List<string>();
        }

        public IList<string> Steps
        {
            get;set;
        }
        public PriorityType Priority
        {
            get;set;
        }
        public SeverityType Severity
        {
            get => this.severityType;
            private set
            {
                this.AddHistory($"Bug severity type changed from '{this.severityType}' to '{value}'.");
                this.severityType = value;
            }
        }
        public BugStatus Status
        {
            get => this.bugStatus;
            private set
            {
                this.AddHistory($"Bug status changed from '{this.bugStatus}' to '{value}'.");
                this.bugStatus = value;
            }
        }
        public IMember Assignee
        {
            get => this.assignee;
            private set
            {

                if (this.assignee == null)
                {
                    this.AddHistory($"Bug assigned to '{value.Name}'.");
                }
                else
                {
                    if (value == null)
                    {
                        this.AddHistory($"Bug assignee removed.");
                    }
                    else
                    {
                        this.AddHistory($"Bug assignee changed from '{this.assignee.Name}' to '{value.Name}'.");
                    }
                }
                this.assignee = value;
            }
        }

        public string Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public IDictionary<IMember, IList<string>> Comments { get; set; }

        public IList<string> History { get; set; }

        public void AddAssignee(IMember member)
        {
            this.assignee = member;
        }

        public void AddComment(IMember member, IList<string> comments)
        {
            this.Comments.Add(member, comments);
        }

        public void AddHistory(string info)
        {
            this.History.Add(info);
        }

        public string ChangePriority(PriorityType priorityType)
        {
            if (this.Priority == priorityType)
            {
                throw new ArgumentException($"Bug priority already at '{priorityType}'");
            }

            this.Priority = priorityType;
            return $"Bug priority changed to '{priorityType}'";
        }
        /// <summary>
        /// Changing the severity type of a bug
        /// </summary>
        /// <param name="severityType">The severity type we want the bug to be changed to</param>
        /// <returns>Returns a string saying what the bug severity has been changed to or returns a message that it is already at the desired severity type</returns>
        public string ChangeSeverity(SeverityType severityType)
        {
            if (this.Severity == severityType)
            {
                throw new ArgumentException($"Bug severity type already at '{severityType}'");
            }
            this.Severity = severityType;
            return $"Bug severity changed to '{severityType}'";
        }
        /// <summary>
        /// Changing the status of a bug
        /// </summary>
        /// <param name="bugStatus">The status we want the bug to be changed to</param>
        /// <returns>Returns a string saying what the bug status has been changed to or returns a message that it is already at the desired status</returns>
        public string ChangeStatus(BugStatus bugStatus)
        {
            if (this.Status == bugStatus)
            {
                throw new ArgumentException($"Bug status already at '{bugStatus}'");
            }
            this.Status = bugStatus;
            return $"Bug status changed to '{bugStatus}'";
        }

        public void RemoveAssignee()
        {
            if (this.Assignee == null)
            {
                throw new ArgumentException($"Bug has no assignee.");
            }
            this.Assignee = null;
        }
        public IMember GetAssignee()
        {
            if (this.Assignee == null)
            {
                throw new ArgumentException("There is no assignee.");
            }
            return this.Assignee;
        }
        public override string ToString()
        {
            string assigneetext = this.Assignee == null ? "No assignee" : this.Assignee.Name;
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Bug ----");
            sb.AppendLine(base.ToString());
            sb.AppendLine($"Priority: {this.priorityType}");
            sb.AppendLine($"Severity: {this.severityType}");
            sb.AppendLine($"Status: {this.bugStatus}");
            sb.AppendLine($"Assignee: {assigneetext}");
            sb.AppendLine($"Steps: {string.Join(", ", this.steps)}");

            return sb.ToString().Trim();
        }
    }
}
