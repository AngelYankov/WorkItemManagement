using System;
using System.Collections.Generic;
using System.Text;
using WorkItemManagementConsoleApp.Models.WorkItems;

namespace WorkItemManagementConsoleApp.Models.Contracts
{
    public interface ITeam
    {
        string Name { get; }
        IList<IMember> Members { get; }
        IList<IBoard> Boards { get; }
        void AddBoard(IBoard board);
        void AddMember(IMember member);
    }
}
