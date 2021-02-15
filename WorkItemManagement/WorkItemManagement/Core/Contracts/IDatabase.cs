using System.Collections.Generic;
using WorkItemManagement.Models.Contracts;

namespace WorkItemManagement.Core.Contracts
{
    public interface IDatabase
    {
        IList<IMember> AllMembers { get; }
        IList<ITeam> AllTeams { get; }
        IList<IWorkItem> AllWorkItems { get; }

    }
}
