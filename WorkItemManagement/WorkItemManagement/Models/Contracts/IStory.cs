using WorkItemManagement.Models.Enums;

namespace WorkItemManagement.Models.Contracts
{
    public interface IStory : IWorkItem, IWorkItemsAssignee
    {
        IMember Assignee { get; }

        PriorityType Priority { get; }

        StoryStatusType StoryStatus { get; }

        SizeType Size { get; }

    }
}
