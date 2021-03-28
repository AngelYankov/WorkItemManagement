using System.Collections.Generic;

namespace WorkItemManagement.Models.Contracts
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
