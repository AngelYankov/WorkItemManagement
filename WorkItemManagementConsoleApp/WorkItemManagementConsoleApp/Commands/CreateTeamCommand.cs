using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WorkItemManagementConsoleApp.Commands.Abstract;
using WorkItemManagementConsoleApp.Models.Contracts;

namespace WorkItemManagementConsoleApp.Commands
{
    public class CreateTeamCommand : Command
    {
        public CreateTeamCommand(IList<string> commandParameters)
            :base(commandParameters)
        {

        }

        public override string Execute() // createteam team1
        {
            if(this.CommandParameters.Count != 1)
            {
                throw new ArgumentException("Parameters count is not valid");
            }

            string name = this.CommandParameters[0];
            bool teamExists = this.Database.AllTeams.Any(x => x.Name.Equals(name, StringComparison.OrdinalIgnoreCase));

            if (teamExists)
            {
                throw new ArgumentException($"Team: '{name}' already exists");
            }
            ITeam team = this.Factory.CreateTeam(name);
            this.Database.AllTeams.Add(team);

            return $"Team: '{name}' created";
        }
    }
}
