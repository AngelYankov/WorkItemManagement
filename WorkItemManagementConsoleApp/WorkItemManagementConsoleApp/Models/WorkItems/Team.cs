using System;
using System.Collections.Generic;
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

    }
}
