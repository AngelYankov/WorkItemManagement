using System;
using System.Collections.Generic;
using System.Text;
using WorkItemManagementConsoleApp.Models.Abstract;
using WorkItemManagementConsoleApp.Models.Contracts;
using WorkItemManagementConsoleApp.Models.Enums;

namespace WorkItemManagementConsoleApp.Models.WorkItems
{
    public class Bug  : WorkItem, IBug
    {
        public Bug(string id, string title, string description, PriorityType priority, 
            SeverityType severity, BugStatus status, Member assignee, List<string> steps)
            : base(id, title, description)
        {
            this.Steps = steps;
            this.Priority = priority;
            this.Severity = severity;
            this.Status = status;
            this.Assignee = assignee;
        }

        public List<string> Steps { get; }
        public PriorityType Priority { get; }
        public SeverityType Severity { get; }
        public BugStatus Status { get; }
        public Member Assignee { get; }

        //Change Priority/Severity/Status of a bug

    }
}
