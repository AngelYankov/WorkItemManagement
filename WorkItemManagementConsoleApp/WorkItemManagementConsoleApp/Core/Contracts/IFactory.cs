using System;
using System.Collections.Generic;
using System.Text;
using WorkItemManagementConsoleApp.Models.Contracts;
using WorkItemManagementConsoleApp.Models.Enums;
using WorkItemManagementConsoleApp.Models.WorkItems;

namespace WorkItemManagementConsoleApp.Core.Contracts
{
    public interface IFactory
    {
        IMember CreateMember(string name);
        ITeam CreateTeam(string name);
        IBoard CreateBoard(string name);
        IBug CreateBug(string id, string title, string description, PriorityType priority,
            SeverityType severity, BugStatus status, Member assignee, List<string> steps);
        IStory CreateStory(string id, string title, string description, Member assignee, 
            PriorityType priority, StoryStatusType storyStatus, SizeType size);
        IFeedback CreateFeedback(string id, string title, string description, int rating, 
            FeedbackStatusType status);

    }
}
