﻿using System;
using System.Collections.Generic;
using System.Text;
using WorkItemManagementConsoleApp.Models.Enums;
using WorkItemManagementConsoleApp.Models.WorkItems;

namespace WorkItemManagementConsoleApp.Models.Contracts
{
    public interface IBug : IWorkItem, IWorkItemsAssignee
    {
        IList<string> Steps { get; }
        PriorityType Priority { get; }
        SeverityType Severity { get; }
        BugStatus Status { get; }
        IMember Assignee { get; }
        string ChangePriority(PriorityType priorityType);
        string ChangeSeverity(SeverityType severityType);
        string ChangeStatus(BugStatus bugStatus);

    }
}
