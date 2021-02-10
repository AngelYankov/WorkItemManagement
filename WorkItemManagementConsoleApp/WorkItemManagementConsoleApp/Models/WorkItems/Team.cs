using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WorkItemManagementConsoleApp.Models.Contracts;

namespace WorkItemManagementConsoleApp.Models.WorkItems
{
    public class Team : ITeam
    {
        private readonly string name;
        private readonly IList<IMember> members = new List<IMember>();
        private readonly IList<IBoard> boards = new List<IBoard>();
        public Team(string name)
        {
            this.name = name;
        }
        public string Name { get => this.name; }
        public IList<IMember> Members { get => this.members; }
        public IList<IBoard> Boards { get => this.boards; }
        public void AddBoard(IBoard board)
        {
            this.boards.Add(board);
        }
        public void AddMember(IMember member)
        {
            this.members.Add(member);
        }
    }
}
