using System.Collections.Generic;
using WorkItemManagement.Commands.Abstract;
using WorkItemManagement.Core;
using WorkItemManagement.Core.Contracts;
using WorkItemManagement.Models.Contracts;

namespace WorkItemManagement.Commands
{
    public class CreateTeamCommand : Command
    {
        public CreateTeamCommand(IList<string> commandParameters, IDatabase database, IFactory factory)
            : base(commandParameters, database, factory)
        {
        }
        public override string Execute() // createteam team1
        {
            var validator = new Validator(Database);

            validator.ValidateParameters(this.CommandParameters, 1);
            string name = this.CommandParameters[0];
            validator.TeamExists(name);

            ITeam team = this.Factory.CreateTeam(name);
            Database.AddTeamToDB(team);

            return $"Created team: '{name}'.";
        }
    }
}
