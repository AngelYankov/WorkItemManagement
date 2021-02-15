using System;
using System.Collections.Generic;
using System.Text;
using WorkItemManagementConsoleApp.Models.Abstract;
using WorkItemManagementConsoleApp.Models.Contracts;
using WorkItemManagementConsoleApp.Models.Enums;

namespace WorkItemManagementConsoleApp.Models.WorkItems
{
    public class Bug : WorkItem, IBug, IWorkItemsAssignee
    {
        private readonly IList<string> steps;
        private PriorityType priorityType;
        private SeverityType severityType;
        private BugStatus bugStatus;
        private IMember assignee;
        public Bug(string id, string title, PriorityType priority,
            SeverityType severity, BugStatus status, IList<string> steps, string description)
            : base(id, title, description)
        {
            this.priorityType = priority;
            this.severityType = severity;
            this.bugStatus = status;
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
                this.AddHistory($"Bug priority type changed from '{this.priorityType}' to '{value}'.");
                this.priorityType = value;
            }
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
        /// <summary>
        /// Add assignee if it doesn't match the current one
        /// </summary>
        /// <param name="member">Assignee to be added</param>
        public void AddAssignee(IMember member)
        {
            if (this.Assignee == member)
            {
                throw new ArgumentException($"Bug already assigned to '{member.Name}'");
            }
            this.Assignee = member;
        }
        /// <summary>
        /// Remove assignee if it already has one
        /// </summary>
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
            return this.Assignee;
        }
        /// <summary>
        /// Changing the priority type of a bug
        /// </summary>
        /// <param name="priorityType">The priority type we want the bug to be changed to</param>
        /// <returns>Returns a string saying what the bug priority has been changed to or returns a message that it is already at the desired priority type</returns>
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
