using System;
using System.Collections.Generic;
using System.Text;
using WorkItemManagementConsoleApp.Models.Enums;
using WorkItemManagementConsoleApp.Models.WorkItems;

namespace WorkItemManagementConsoleApp.Models.Contracts
{
    public interface IBug
    {
        List<string> Steps { get; }
        PriorityType Priority { get; }
        SeverityType Severity { get; }
        BugStatus Status { get; }
        Member Assignee { get; }

    }
}
