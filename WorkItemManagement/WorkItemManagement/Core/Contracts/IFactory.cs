using System.Collections.Generic;
using WorkItemManagement.Models.Contracts;

namespace WorkItemManagement.Core.Contracts
{
    public interface IFactory
    {
        IMember CreateMember(string name);
        ITeam CreateTeam(string name);
        IBoard CreateBoard(string name);
        IBug CreateBug(string id, string title, string priority, string severity, string status, List<string> steps, string description);
        IStory CreateStory(string id, string title, string priority, string storyStatus, string size, string description);
        IFeedback CreateFeedback(string id, string title, int rating, string status, string description);

    }
}
