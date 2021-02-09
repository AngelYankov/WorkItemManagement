using System;
using System.Collections.Generic;
using System.Text;
using WorkItemManagementConsoleApp.Models.Enums;

namespace WorkItemManagementConsoleApp.Models.Contracts
{
    public interface IFeedback : IWorkItem
    {
        int Rating { get; }
        FeedbackStatusType FeedbackStatus { get; }
        string ChangeStatus(FeedbackStatusType status);
    }
}
