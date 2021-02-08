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

        public void AddBoard(IBoard board)
        {
            if (this.Boards.Any(x => x.Name.Equals(board.Name, StringComparison.OrdinalIgnoreCase)))
            {
                throw new ArgumentException("Board already exists.");
            }

            this.Boards.Add(board);
        }
        // add 2 methods for adding members and boards


    }
}
