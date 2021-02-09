using System;
using System.Collections.Generic;
using System.Text;
using WorkItemManagementConsoleApp.Models.Abstract;
using WorkItemManagementConsoleApp.Models.Contracts;
using WorkItemManagementConsoleApp.Models.Enums;

namespace WorkItemManagementConsoleApp.Models.WorkItems
{
    public class Bug : WorkItem, IBug
    {
        private readonly IList<string> steps;
        private PriorityType priorityType;
        private SeverityType severityType;
        private BugStatus bugStatus;
        private IMember assignee;
        public Bug(string id, string title, string description, PriorityType priority,
            SeverityType severity, BugStatus status, IList<string> steps)
            : base(id, title, description)
        {
            this.Priority = priority;
            this.Severity = severity;
            this.Status = status;
            this.steps = steps;
        }

        public IList<string> Steps
        {
            get => this.steps;
        }
        public PriorityType Priority
        {
            get => this.priorityType;
            private set
            {
                this.AddHistory($"Bug priority type changed from {this.priorityType} to {value}.");
                this.priorityType = value;
            }
        }
        public SeverityType Severity
        {
            get => this.severityType;
            private set
            {
                this.AddHistory($"Bug severity type changed from {this.severityType} to {value}.");
                this.severityType = value;
            }
        }
        public BugStatus Status
        {
            get => this.bugStatus;
            private set
            {
                this.AddHistory($"Bug status changed from {this.bugStatus} to {value}.");
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
                    this.AddHistory($"Bug assigned to {value}.");
                }
                else
                {
                    this.AddHistory($"Bug assignee changed from {this.assignee} to {value}.");
                }
                this.assignee = value;
            }
        }
        public void AddAssignee(IMember member)
        {
            this.Assignee = member;
        }

        public string ChangePriority(PriorityType priorityType)
        {
            if (this.Priority == priorityType)
            {
                throw new ArgumentException($"Bug priority already at {priorityType}");
            }

            this.Priority = priorityType;
            return $"Bug priority changed to {priorityType}";
        }
        public string ChangeSeverity(SeverityType severityType)
        {
            if(this.Severity == severityType)
            {
                throw new ArgumentException($"Bug severity type already at {severityType}");
            }
            this.Severity = severityType;
            return $"Bug severity changed to {severityType}";
        }
        public string ChangeStatus(BugStatus bugStatus)
        {
            if(this.Status == bugStatus)
            {
                throw new ArgumentException($"Bug status already at {bugStatus}");
            }
            this.Status = bugStatus;
            return $"Bug status changed to {bugStatus}";
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Bug ----");
            sb.AppendLine(base.ToString());
            sb.AppendLine($"Priority: {this.priorityType}");
            sb.AppendLine($"Severity: {this.severityType}");
            sb.AppendLine($"Status: {this.bugStatus}");
            sb.AppendLine($"Assignee: {this.assignee}");
            sb.AppendLine($"Steps: {string.Join(Environment.NewLine, this.steps)}");

            return sb.ToString().Trim();
        }
    }
}
