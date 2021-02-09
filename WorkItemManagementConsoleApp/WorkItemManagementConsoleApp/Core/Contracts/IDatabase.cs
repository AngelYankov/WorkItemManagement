using System;
using System.Collections.Generic;
using System.Text;
using WorkItemManagementConsoleApp.Models.Contracts;

namespace WorkItemManagementConsoleApp.Core.Contracts
{
    public interface IDatabase
    {
        IList<IMember> AllMembers { get; }
        IList<ITeam> AllTeams { get; }
        IList<IWorkItem> AllWorkItems { get; }

    }
}
