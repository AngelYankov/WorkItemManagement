using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WorkItemManagementConsoleApp.Commands.Abstract;
using WorkItemManagementConsoleApp.Core;
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
            Validator.ValidateParameters(this.CommandParameters, 1);
            string name = this.CommandParameters[0];
            Validator.TeamExists(name);

            ITeam team = this.Factory.CreateTeam(name);
            this.Database.AllTeams.Add(team);
            return $"Team: '{name}' created";
        }
    }
}
