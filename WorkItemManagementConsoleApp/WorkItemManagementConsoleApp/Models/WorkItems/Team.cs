using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WorkItemManagementConsoleApp.Models.Contracts;

namespace WorkItemManagementConsoleApp.Models.WorkItems
{
    public class Team : ITeam
    {
        public Team(string name)
        {
            this.Name = name;
        }
        public string Name { get; }
        public List<IMember> Members { get; }
        public List<IBoard> Boards { get; }

        // add 2 methods for adding members and boards
        public void AddBoard(IBoard board)
        {
            if (this.Boards.Any(x => x.Name.Equals(board.Name, StringComparison.OrdinalIgnoreCase)))
            {
                throw new ArgumentException("Board already exists.");
            }

            this.Boards.Add(board);
        }

        public void AddMember(IMember member)
        {
            if (this.Members.Any(x => x.Name.Equals(member.Name, StringComparison.OrdinalIgnoreCase)))
            {
                throw new ArgumentException("Member already exists.");
            }

            this.Members.Add(member);
        }

        public int GetIndex(IBoard board)
        {
            for (int i = 0; i < Boards.Count; i++)
            {
                if (this.Boards[i].Name.Equals(board.Name, StringComparison.OrdinalIgnoreCase))
                {
                    return i;
                }
            }
            return -1;
        }
    }
}
