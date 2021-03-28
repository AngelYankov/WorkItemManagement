using System.Collections.Generic;
using System.Linq;
using WorkItemManagement.Commands.Abstract;
using WorkItemManagement.Core;
using WorkItemManagement.Core.Contracts;

namespace WorkItemManagement.Commands
{
    public class ShowAllTeamMembersCommand : Command
    {
        public ShowAllTeamMembersCommand(IList<string> commandParameters, IDatabase database, IFactory factory)
            : base(commandParameters, database, factory)
        {
        }
        public override string Execute() //showteammembers team1
        {
            var validator = new Validator(Database);

            validator.ValidateParameters(this.CommandParameters, 1);
            string teamName = this.CommandParameters[0];
            var team = Database.GetTeam(teamName);

            return  team.Members.Count != 0
                ? string.Join(", ", team.Members.Select(m => m.Name))
                : $"There are no members in team: '{teamName}'.";
        }
    }
}
