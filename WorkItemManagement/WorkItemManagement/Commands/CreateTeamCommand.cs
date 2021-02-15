using System.Collections.Generic;
using WorkItemManagement.Commands.Abstract;
using WorkItemManagement.Core;
using WorkItemManagement.Models.Contracts;

namespace WorkItemManagement.Commands
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
            Validator.GetAllTeams().Add(team);
            return $"Created team: '{name}'.";
        }
    }
}
