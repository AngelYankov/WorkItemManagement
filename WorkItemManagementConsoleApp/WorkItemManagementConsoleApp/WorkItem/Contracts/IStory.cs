using System;
using System.Collections.Generic;
using System.Text;
using WorkItemManagementConsoleApp.Common;
using WorkItemManagementConsoleApp.WorkItem.WorkItems;

namespace WorkItemManagementConsoleApp.WorkItem.Contracts
{
    interface IStory : IWorkItem
    {
        public Member Assignee { get; set; }

        public PriorityType Priority { get; }

        public StoryStatusType StoryStatus { get; }

        public SizeType Size { get; }
    }
}
