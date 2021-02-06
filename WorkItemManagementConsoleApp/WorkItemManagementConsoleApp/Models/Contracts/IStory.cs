using System;
using System.Collections.Generic;
using System.Text;
using WorkItemManagementConsoleApp.Models.Enums;
using WorkItemManagementConsoleApp.Models.WorkItems;

namespace WorkItemManagementConsoleApp.Models.Contracts
{
    public interface IStory : IWorkItem
    {
        Member Assignee { get; set; }

        PriorityType Priority { get; }

        StoryStatusType StoryStatus { get; }

        SizeType Size { get; }
    }
}
