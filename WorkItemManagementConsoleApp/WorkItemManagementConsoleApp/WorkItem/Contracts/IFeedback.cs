using System;
using System.Collections.Generic;
using System.Text;
using WorkItemManagementConsoleApp.Common;

namespace WorkItemManagementConsoleApp.WorkItem.Contracts
{
    interface IFeedback : IWorkItem
    {
        public int Rating { get; }

        public FeedbackStatusType FeedbackStatus { get; }
    }
}
