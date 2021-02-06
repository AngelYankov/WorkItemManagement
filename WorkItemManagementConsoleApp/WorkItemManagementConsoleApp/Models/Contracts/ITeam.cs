using System;
using System.Collections.Generic;
using System.Text;
using WorkItemManagementConsoleApp.Models.WorkItems;

namespace WorkItemManagementConsoleApp.Models.Contracts
{
    public interface ITeam
    {
        string Name { get; }
        List<IMember> Members { get; }
        List<IBoard> Boards { get; }

    }
}
