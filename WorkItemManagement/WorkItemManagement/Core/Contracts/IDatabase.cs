using System.Collections.Generic;
using WorkItemManagement.Models.Contracts;

namespace WorkItemManagement.Core.Contracts
{
    public interface IDatabase
    {
        IList<IMember> AllMembers { get; }
        IList<ITeam> AllTeams { get; }
        IList<IWorkItem> AllWorkItems { get; }
        void AddWorkItemToDB(IWorkItem workItem);
        void AddTeamToDB(ITeam team);
        void AddMemberToDB(IMember member);
        IWorkItem GetWorkItem(string id);
        ITeam GetTeam(string name);
        IBoard GetBoard(string name, ITeam team);
        IMember GetMember(string name);
        IWorkItemsAssignee GetWorkItemToAssign(string id);
        IList<IWorkItem> GetAllWorkItems();
        IList<ITeam> GetAllTeams();
        IList<IMember> GetAllMembers();
    }
}
