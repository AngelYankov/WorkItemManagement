using WorkItemManagement.Models.Enums;

namespace WorkItemManagement.Models.Contracts
{
    public interface IFeedback : IWorkItem
    {
        int Rating { get; }
        FeedbackStatusType FeedbackStatus { get; }
        string ChangeStatus(FeedbackStatusType status);
    }
}
