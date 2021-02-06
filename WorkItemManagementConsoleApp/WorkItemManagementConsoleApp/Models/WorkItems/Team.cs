using System;
using System.Collections.Generic;
using System.Text;
using WorkItemManagementConsoleApp.Models.Contracts;

namespace WorkItemManagementConsoleApp.Models.WorkItems
{
    public class Team : ITeam
    {
        public Team(string name, List<IMember> members, List<IBoard> boards)
        {
            this.Name = name;
            this.Members = members;
            this.Boards = boards;
        }
        public string Name { get; }
        public List<IMember> Members { get; }
        public List<IBoard> Boards { get; }

    }
}
