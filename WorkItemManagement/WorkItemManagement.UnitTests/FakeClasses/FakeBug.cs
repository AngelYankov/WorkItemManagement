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
        public FakeBug(string id)
        {
            this.Id = id;
        }

        public FakeBug(string id, string title)
        {
            this.Id = id;
            this.Title = title;
        }

        public IList<string> Steps
        {
            get => this.steps;
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

        public string Description => throw new NotImplementedException();

        public IDictionary<IMember, IList<string>> Comments => throw new NotImplementedException();

        public IList<string> History => throw new NotImplementedException();

        public void AddAssignee(IMember member)
        {
            throw new NotImplementedException();
        }

        public void AddComment(IMember member, IList<string> comments)
        {
            throw new NotImplementedException();
        }

        public void AddHistory(string info)
        {
            throw new NotImplementedException();
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
    }
}
